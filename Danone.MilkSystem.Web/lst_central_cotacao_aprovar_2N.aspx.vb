Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class lst_central_cotacao_aprovar_2N

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia") = Me.txt_MesAno.Text()
        'ViewState.Item("id_tecnico") = txt_cd_tecnico.Text()

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_cotacao_aprovar_2N.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_preco_negociado_aprovar_1N.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 96
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log

            loadDetails()
        End If

        'With img_lupa_tecnico
        '    .Attributes.Add("onclick", "javascript:ShowDialogTecnico()")
        '    .ToolTip = "Filtrar Técnicos"
        'End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim statuspreconegociado As New StatusPrecoNegociado

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = "ds_produtor asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("central_cotacao_aprovar_2N", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("central_cotacao_aprovar_2N", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If


        If Not (customPage.getFilterValue("central_cotacao_aprovar_2N", txt_MesAno.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("central_cotacao_aprovar_2N", txt_MesAno.ID)
            txt_MesAno.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        'If Not (customPage.getFilterValue("central_cotacao_aprovar_2N", txt_cd_tecnico.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("id_tecnico") = customPage.getFilterValue("central_cotacao_aprovar_2N", txt_cd_tecnico.ID)
        '    txt_cd_tecnico.Text = ViewState.Item("id_tecnico").ToString()
        'Else
        '    ViewState.Item("id_tecnico") = String.Empty
        'End If

        'If Not (customPage.getFilterValue("central_cotacao_aprovar_2N", lbl_nm_tecnico.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("nm_tecnico") = customPage.getFilterValue("central_cotacao_aprovar_2N", lbl_nm_tecnico.ID)
        '    lbl_nm_tecnico.Text = ViewState.Item("nm_tecnico").ToString()
        '    hf_id_tecnico.Value = ViewState.Item("id_tecnico").ToString
        'Else
        '    ViewState.Item("nm_tecnico") = String.Empty
        '    hf_id_tecnico.Value = String.Empty
        'End If


        If Not (customPage.getFilterValue("central_cotacao_aprovar_2N", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("central_cotacao_aprovar_2N", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("central_cotacao_aprovar_2N")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim cotacao As New Cotacao

            cotacao.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            cotacao.dt_cotacao_inicio = String.Concat("01/" & ViewState("dt_referencia").ToString)
            cotacao.dt_cotacao_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(cotacao.dt_cotacao_inicio)))
            'cotacao.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)


            Me.lk_aprovar.Enabled = True
            Me.lk_reprovar.Enabled = True

            ' 30/11/2008 (não exibir itens aprovador 2.o Nível para a tela de Aprovação 1.o Nível)
            'Dim dsPrecoNegociado As DataSet = PrecoNegociado.getPrecoNegociado1NByFilters()
            Dim dsCotacao As DataSet = cotacao.getCentralCotacaoByGestor()

            If (dsCotacao.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsCotacao.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        saveCheckBox()
        loadData()

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "ds_produtor"
                If (ViewState.Item("sortExpression")) = "ds_produtor asc" Then
                    ViewState.Item("sortExpression") = "ds_produtor desc"
                Else
                    ViewState.Item("sortExpression") = "ds_produtor asc"
                End If

            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If

            Case "nm_item"
                If (ViewState.Item("sortExpression")) = "nm_item asc" Then
                    ViewState.Item("sortExpression") = "nm_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_item asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("central_cotacao_aprovar_2N", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("central_cotacao_aprovar_2N", txt_MesAno.ID, ViewState.Item("dt_referencia").ToString)
            'customPage.setFilter("central_cotacao_aprovar_2N", txt_cd_tecnico.ID, ViewState("id_tecnico").ToString)
            'customPage.setFilter("central_cotacao_aprovar_2N", lbl_nm_tecnico.ID, lbl_nm_tecnico.Text)
            customPage.setFilter("central_cotacao_aprovar_2N", "PageIndex", gridResults.PageIndex.ToString())


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.Trim.ToString
            Case "Edit", "Editar", "Cancel", "Cancelar", "Update"
                Return
        End Select

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then


            Dim lbl_saldo_disponivel As Label = CType(e.Row.FindControl("lbl_saldo_disponivel"), Label)
            Dim lbl_percentual As Label = CType(e.Row.FindControl("lbl_percentual"), Label)
            'Fran 12/2013 i fase 2 
            Dim lbl_faturamento As Label = CType(e.Row.FindControl("lbl_faturamento"), Label)
            Dim lbl_percentual_faturamento As Label = CType(e.Row.FindControl("lbl_percentual_faturamento"), Label)
            'Fran 12/2013 f fase 2 

            Dim saldodisponivel As New SaldoDisponivel
            saldodisponivel.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)

            saldodisponivel.id_propriedade = Convert.ToInt32(e.Row.Cells(2).Text)
            'fran 12/2013 i fase 2 melhorias 
            'lbl_saldo_disponivel.Text = FormatNumber(saldodisponivel.getSaldoDisponivel(), 2)
            lbl_saldo_disponivel.Text = FormatNumber(saldodisponivel.getSaldoDisponivel(True), 2)
            'fran 12/2013 f fase 2 melhorias 

            lbl_faturamento.Text = FormatNumber(saldodisponivel.nr_valor_faturamento, 2) 'Fran 12/2013 i fase 2 

            If IsNumeric(lbl_saldo_disponivel.Text) Then
                'fran 9/12/2010 i
                'If lbl_saldo_disponivel.Text > 0 And IsNumeric(e.Row.Cells(9).Text) Then
                '    lbl_percentual.Text = FormatNumber((Convert.ToDecimal(e.Row.Cells(9).Text) / Convert.ToDecimal(lbl_saldo_disponivel.Text)) * 100, 2)
                If lbl_saldo_disponivel.Text > 0 And IsNumeric(e.Row.Cells(10).Text) Then
                    ' Divide o Valor Total pelo Saldo Disponível
                    lbl_percentual.Text = FormatNumber((Convert.ToDecimal(e.Row.Cells(10).Text) / Convert.ToDecimal(lbl_saldo_disponivel.Text)) * 100, 2)
                    'fran 9/12/2010 f
                End If
            End If
            'Fran 12/2013 i fase 2  - Verifica o percentual do Valor a ser aprovado em cima do faturamento mensal estimado
            If IsNumeric(lbl_faturamento.Text) Then
                If lbl_faturamento.Text > 0 And IsNumeric(e.Row.Cells(10).Text) Then
                    ' Divide o Valor Total pelo Faturamento Mensal
                    lbl_percentual_faturamento.Text = FormatNumber((Convert.ToDecimal(e.Row.Cells(10).Text) / Convert.ToDecimal(lbl_faturamento.Text)) * 100, 2)
                End If
            End If
            'Fran 12/2013 f fase 2 

        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub lk_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_aprovar.Click
        Try
            Dim cotacao As New Cotacao

            If saveCheckBox() = True Then

                'Filtro
                cotacao.id_estabelecimento = ViewState.Item("id_estabelecimento")  ' 11/09/2008
                cotacao.dt_cotacao_inicio = String.Concat("01/" & ViewState("dt_referencia").ToString)
                cotacao.dt_cotacao_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(cotacao.dt_cotacao_inicio)))
                'cotacao.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)

                'Dados para o Update
                cotacao.id_central_status_aprovacao = "4"   '  Aprovado Gestor
                cotacao.id_modificador = Session("id_login")

                cotacao.updateCentralCotacaoAprovarSelecionados()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'PROCESSO
                usuariolog.id_menu_item = 96
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f
                loadData()

                messageControl.Alert("Aprovação 2.o Nível Gestor concluída com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para a aprovação. Por favor selecione alguma propriedade.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                ch.Checked = ck_header.Checked
            Next

            'fran 13/12/2010 i rls 26.04
            '' Seleciona tudo o que o botão Pesquisar trouxe - i
            'Dim cotacao As New Cotacao
            'cotacao.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'cotacao.dt_cotacao_inicio = String.Concat("01/" & ViewState("dt_referencia").ToString)
            'cotacao.dt_cotacao_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(cotacao.dt_cotacao_inicio)))
            ''cotacao.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)

            'If ck_header.Checked = True Then
            '    cotacao.st_selecao = "1"
            'Else
            '    cotacao.st_selecao = "0"
            'End If
            'cotacao.updateCentralCotacaoTodos2N()
            '' 30/11/2008  -  Seleciona tudo o que o botão Pesquisar trouxe - f
            'fran 13/12/2010 f rls 26.04


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function saveCheckBox() As Boolean

        Try

            Dim li As Integer

            For li = 0 To gridResults.Rows.Count - 1
                Dim cotacao As New Cotacao()
                cotacao.id_central_cotacao_item = gridResults.DataKeys(li).Value.ToString
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    cotacao.st_selecao = "1"
                    saveCheckBox = True     ' Indica que tem item selecionado
                Else
                    cotacao.st_selecao = "0"
                End If
                cotacao.updateCentralCotacaoSelecao()
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub lk_reprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_reprovar.Click
        Try
            Dim cotacao As New Cotacao

            If saveCheckBox() = True Then

                ' Dados do filtro
                cotacao.id_estabelecimento = ViewState.Item("id_estabelecimento")
                cotacao.dt_cotacao_inicio = String.Concat("01/" & ViewState("dt_referencia").ToString)
                cotacao.dt_cotacao_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(cotacao.dt_cotacao_inicio)))
                'cotacao.id_tecnico = ViewState.Item("id_tecnico")

                'Dados para o update
                cotacao.id_central_status_aprovacao = "3"   '  Reprovado Gestor
                cotacao.id_modificador = Session("id_login")

                cotacao.updateCentralCotacaoAprovarSelecionados()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'PROCESSO
                usuariolog.id_menu_item = 96
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f
                loadData()

                messageControl.Alert("Itens reprovados com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione alguma propriedade.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub carregarCamposTecnico()

        'Try

        '    Me.txt_cd_tecnico.Text = hf_id_tecnico.Value

        '    If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
        '        Me.lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
        '    End If

        '    customPage.clearFilters("lupa_tecnico")


        'Catch ex As Exception
        '    messageControl.Alert(ex.Message)
        'End Try

    End Sub

    'Protected Sub img_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_tecnico.Click
    '    If Not (hf_id_tecnico.Value.Trim.Equals(String.Empty)) Then
    '        Me.lbl_nm_tecnico.Visible = True
    '        carregarCamposTecnico()

    '    End If

    'End Sub

    'Protected Sub cv_tecnico_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_tecnico.ServerValidate
    '    Try
    '        Dim tecnico As New Tecnico()

    '        tecnico.id_tecnico = Me.txt_cd_tecnico.Text.Trim

    '        args.IsValid = tecnico.validarTecnico()

    '        If Not args.IsValid Then
    '            messageControl.Alert("Técnico não cadastrado.")
    '        End If
    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
    '    lbl_nm_tecnico.Text = String.Empty
    '    lbl_nm_tecnico.Visible = False
    '    hf_id_tecnico.Value = String.Empty

    'End Sub

End Class
