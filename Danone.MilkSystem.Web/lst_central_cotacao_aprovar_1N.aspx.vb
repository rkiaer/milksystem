Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.IO

Partial Class lst_central_cotacao_aprovar_1N

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia") = Me.txt_MesAno.Text()
        ViewState.Item("id_tecnico") = txt_cd_tecnico.Text()

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_cotacao_aprovar_1N.aspx?st_incluirlog=N")

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
                usuariolog.id_menu_item = 93
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With img_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialogTecnico()")
            .ToolTip = "Filtrar Técnicos"
        End With

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

        If Not (customPage.getFilterValue("central_cotacao_aprovar_1N", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("central_cotacao_aprovar_1N", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If


        If Not (customPage.getFilterValue("central_cotacao_aprovar_1N", txt_MesAno.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("central_cotacao_aprovar_1N", txt_MesAno.ID)
            txt_MesAno.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        If Not (customPage.getFilterValue("central_cotacao_aprovar_1N", txt_cd_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_tecnico") = customPage.getFilterValue("central_cotacao_aprovar_1N", txt_cd_tecnico.ID)
            txt_cd_tecnico.Text = ViewState.Item("id_tecnico").ToString()
        Else
            ViewState.Item("id_tecnico") = String.Empty
        End If

        If Not (customPage.getFilterValue("central_cotacao_aprovar_1N", lbl_nm_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_tecnico") = customPage.getFilterValue("central_cotacao_aprovar_1N", lbl_nm_tecnico.ID)
            lbl_nm_tecnico.Text = ViewState.Item("nm_tecnico").ToString()
            hf_id_tecnico.Value = ViewState.Item("id_tecnico").ToString
        Else
            ViewState.Item("nm_tecnico") = String.Empty
            hf_id_tecnico.Value = String.Empty
        End If


        If Not (customPage.getFilterValue("central_cotacao_aprovar_1N", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("central_cotacao_aprovar_1N", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("central_cotacao_aprovar_1N")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim cotacao As New Cotacao


            cotacao.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            cotacao.dt_cotacao_inicio = String.Concat("01/" & ViewState("dt_referencia").ToString)
            cotacao.dt_cotacao_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(cotacao.dt_cotacao_inicio)))

            'Fran 05/08/2015 i
            If ViewState.Item("id_tecnico").ToString.Equals(String.Empty) Then
                cotacao.id_tecnico = 0
            Else
                cotacao.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)
            End If
            'Fran 05/08/2015 f


            Me.lk_aprovar.Enabled = True
            Me.lk_reprovar.Enabled = True
            Me.lk_email.Enabled = True

            ' 30/11/2008 (não exibir itens aprovador 2.o Nível para a tela de Aprovação 1.o Nível)
            'Dim dsPrecoNegociado As DataSet = PrecoNegociado.getPrecoNegociado1NByFilters()
            Dim dsCotacao As DataSet = cotacao.getCentralCotacaoByTecnico()

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

            customPage.setFilter("central_cotacao_aprovar_1N", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("central_cotacao_aprovar_1N", txt_MesAno.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("central_cotacao_aprovar_1N", txt_cd_tecnico.ID, ViewState("id_tecnico").ToString)
            customPage.setFilter("central_cotacao_aprovar_1N", lbl_nm_tecnico.ID, lbl_nm_tecnico.Text)
            customPage.setFilter("central_cotacao_aprovar_1N", "PageIndex", gridResults.PageIndex.ToString())


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

        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Dim txt_parcelas As DataControlFieldCell = CType(e.Row.Cells(15), DataControlFieldCell) 'fran 10/10/2010 i chamado 814

            'Se já fez a criação  da linha e esta sem valor no combo 
            Dim cbo_justificativa As DropDownList = CType(e.Row.FindControl("cbo_justificativa"), DropDownList)
            If Not (cbo_justificativa Is Nothing) Then
                cbo_justificativa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            End If
            ViewState("label_justificativa") = Nothing 'Assume que  tem valor
            'fran 10/10/2010 i chamado 814
            If txt_parcelas.Text.Equals("0") Then
                txt_parcelas.Text = 1
            End If
            'fran 10/10/2010 f chamado 814

        Else  ' Se não está editando

            If (e.Row.RowType <> DataControlRowType.Header _
                And e.Row.RowType <> DataControlRowType.Footer _
                And e.Row.RowType <> DataControlRowType.Pager) Then

                Dim txt_parcelas As DataControlFieldCell = CType(e.Row.Cells(15), DataControlFieldCell) 'fran 10/10/2010 i chamado 814

                Dim lbl_saldo_disponivel As Label = CType(e.Row.FindControl("lbl_saldo_disponivel"), Label)
                Dim lbl_percentual As Label = CType(e.Row.FindControl("lbl_percentual"), Label)
                'Fran 12/2013 i fase 2 
                Dim lbl_faturamento As Label = CType(e.Row.FindControl("lbl_faturamento"), Label)
                Dim lbl_percentual_faturamento As Label = CType(e.Row.FindControl("lbl_percentual_faturamento"), Label)
                'Fran 12/2013 f fase 2 

                Dim saldodisponivel As New SaldoDisponivel
                saldodisponivel.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
                saldodisponivel.id_propriedade = Convert.ToInt32(e.Row.Cells(2).Text)
                'fran 12/2013 i melhorias fase 2
                'lbl_saldo_disponivel.Text = FormatNumber(saldodisponivel.getSaldoDisponivel(), 2)
                lbl_saldo_disponivel.Text = FormatNumber(saldodisponivel.getSaldoDisponivel(True), 2) 'se nao tiver saldo em mapa de leite pega fdos romaneios abertos
                'fran 12/2013 f melhorias fase 2

                lbl_faturamento.Text = FormatNumber(saldodisponivel.nr_valor_faturamento, 2) 'Fran 12/2013 i fase 2 

                If IsNumeric(lbl_saldo_disponivel.Text) Then
                    'If lbl_saldo_disponivel.Text > 0 And IsNumeric(e.Row.Cells(9).Text) Then
                    If lbl_saldo_disponivel.Text > 0 And IsNumeric(e.Row.Cells(10).Text) Then
                        ' Divide o Valor Total pelo Saldo Disponível
                        'lbl_percentual.Text = FormatNumber((Convert.ToDecimal(e.Row.Cells(9).Text) / Convert.ToDecimal(lbl_saldo_disponivel.Text)) * 100, 2)
                        lbl_percentual.Text = FormatNumber((Convert.ToDecimal(e.Row.Cells(10).Text) / Convert.ToDecimal(lbl_saldo_disponivel.Text)) * 100, 2)  ' 08/12/2010 - Erro pego na validação em reunião
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

                'fran 10/10/2010 i chamado 814
                If txt_parcelas.Text.Equals("0") Then
                    txt_parcelas.Text = 1
                End If
                'fran 10/10/2010 f chamado 814
            End If

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
                'Fran 10/10/2017 i
                'cotacao.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)
                If ViewState.Item("id_tecnico").ToString.Equals(String.Empty) Then
                    cotacao.id_tecnico = 0
                Else
                    cotacao.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)
                End If
                'Fran 10/10/2017 f

                'Dados para o Update
                cotacao.id_central_status_aprovacao = "2"   '  Aprovado Técnico
                cotacao.id_modificador = Session("id_login")

                cotacao.updateCentralCotacaoAprovarSelecionados()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'PROCESSO
                usuariolog.id_menu_item = 93
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f

                loadData()

                messageControl.Alert("Aprovação 1.o Nível Técnico concluída com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para a aprovação. Por favor selecione alguma propriedade.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridResults.RowCancelingEdit
        Try

            gridResults.EditIndex = -1
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridResults.RowEditing
        Try

            Dim lbl_justificativa As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_justificativa"), Label)
            ViewState.Item("label_justificativa") = Trim(lbl_justificativa.Text)
            gridResults.EditIndex = e.NewEditIndex
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridResults.RowUpdating
        'Capturar valores
        Dim row As GridViewRow = gridResults.Rows(e.RowIndex)
        Try

            If (Not (row) Is Nothing) Then

                Dim cotacao As New Cotacao
                Dim erro As Boolean


                cotacao.id_central_cotacao_item = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)

                Dim cbo_justificativa As DropDownList = CType(row.FindControl("cbo_justificativa"), DropDownList)


                If Not (cbo_justificativa.SelectedValue.Trim().Equals(String.Empty)) Then
                    cotacao.id_central_justificativa_aprovacao = Convert.ToInt32(cbo_justificativa.SelectedValue)
                End If


                cotacao.id_modificador = Session("id_login")


                erro = False

                If erro = False Then
                    cotacao.updateCentralCotacaoAprovador()
                    gridResults.EditIndex = -1
                    loadData()
                End If
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
            'cotacao.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)

            'If ck_header.Checked = True Then
            '    cotacao.st_selecao = "1"
            'Else
            '    cotacao.st_selecao = "0"
            'End If
            'cotacao.updateCentralCotacaoTodos1N()
            '' 30/11/2008  -  Seleciona tudo o que o botão Pesquisar trouxe - f
            'fran 13/12/2010 i rls 26.04


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
                'Fran 10/10/2017 i
                'cotacao.id_tecnico = ViewState.Item("id_tecnico")
                If ViewState.Item("id_tecnico").ToString.Equals(String.Empty) Then
                    cotacao.id_tecnico = 0
                Else
                    cotacao.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)
                End If
                'Fran 10/10/2017 f

                'Dados para o update
                cotacao.id_central_status_aprovacao = "1"   '  Reprovado Técnico
                cotacao.id_modificador = Session("id_login")

                cotacao.updateCentralCotacaoAprovarSelecionados()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'PROCESSO
                usuariolog.id_menu_item = 93
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

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        Try
            If Page.IsValid = True Then
                Try

                    Dim notificacao As New Notificacao
                    Dim lAssunto As String = "Aprovação 2.o Nível de Cotações Central de Compras para Produtores "
                    Dim lCorpo As String = "Existem cotações para Produtores da Central de Compras aprovadas em 1.o Nível pelos Técnicos responsáveis, pendentes para aprovação 2.o Nível."

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 9 'ENVIO EMAIL
                    usuariolog.id_menu_item = 93
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f

                    ' Parametro 8 - Central Cotacao 2.o Nível Gestor (enviar aos Gestores) 
                    If notificacao.enviaMensagemEmail(8, lAssunto, lCorpo, MailPriority.High) = True Then

                        messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível pelo Gestor foi enviada aos destinatários com sucesso!")
                    Else

                        messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível pelo Gestor não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")

                    End If

                    ' '' Somente para teste do email para fornecedores - i
                    'lAssunto = "DANONE - Pedido de Compra "
                    'Dim arqTemp As StreamReader
                    'Dim lcaminhoservidor As String = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString()
                    'arqTemp = New StreamReader(lcaminhoservidor & "\email_fornecedor.html", Encoding.UTF7)
                    'lCorpo = ""
                    'Do While Not arqTemp.EndOfStream
                    '    lCorpo = lCorpo & arqTemp.ReadLine
                    'Loop
                    'arqTemp.Close()
                    'If notificacao.enviaMensagemEmail(8, lAssunto, lCorpo, MailPriority.High, "", True) = True Then

                    '    messageControl.Alert("A mensagem HTML foi enviada com sucesso!")
                    'Else

                    '    messageControl.Alert("A mensagem HTML não foi enviada com sucesso!")

                    'End If

                    ' '' Somente para teste do email para fornecedores - f

                Catch ex As Exception
                    messageControl.Alert(ex.Message)
                End Try


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub carregarCamposTecnico()

        Try

            Me.txt_cd_tecnico.Text = hf_id_tecnico.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If

            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub img_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_tecnico.Click
        If Not (hf_id_tecnico.Value.Trim.Equals(String.Empty)) Then
            Me.lbl_nm_tecnico.Visible = True
            carregarCamposTecnico()

        End If

    End Sub

    Protected Sub cv_tecnico_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_tecnico.ServerValidate
        Try
            Dim tecnico As New Tecnico()

            tecnico.id_tecnico = Me.txt_cd_tecnico.Text.Trim

            args.IsValid = tecnico.validarTecnico()

            If Not args.IsValid Then
                messageControl.Alert("Técnico não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
        'lbl_nm_tecnico.Text = String.Empty
        'lbl_nm_tecnico.Visible = False
        'hf_id_tecnico.Value = String.Empty

        ' Adri 04/05/2010 - i
        lbl_nm_tecnico.Text = String.Empty
        hf_id_tecnico.Value = String.Empty
        Try
            If Not txt_cd_tecnico.Text.ToString.Equals(String.Empty) Then
                Dim tecnico As New Tecnico
                tecnico.id_tecnico = txt_cd_tecnico.Text.Trim
                Dim dstecnico As DataSet = tecnico.getTecnicoByFilters
                If dstecnico.Tables(0).Rows.Count > 0 Then
                    lbl_nm_tecnico.Visible = True
                    lbl_nm_tecnico.Enabled = True
                    lbl_nm_tecnico.Text = dstecnico.Tables(0).Rows(0).Item("nm_tecnico")
                    hf_id_tecnico.Value = dstecnico.Tables(0).Rows(0).Item("id_tecnico").ToString
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' Adri 04/05/2010 - f

    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            Try
                If Not (ViewState("label_justificativa") Is Nothing) Then

                    Dim cbo_justificativa As DropDownList = CType(e.Row.FindControl("cbo_justificativa"), DropDownList)

                    Dim justificativacentral As New JustificativaCentral

                    cbo_justificativa.DataSource = justificativacentral.getCentralJustificativaByFilters()
                    cbo_justificativa.DataTextField = "nm_central_justificativa_aprovacao"
                    cbo_justificativa.DataValueField = "id_central_justificativa_aprovacao"
                    cbo_justificativa.DataBind()

                    If (ViewState("label_justificativa").ToString.Equals(String.Empty)) Then
                        cbo_justificativa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState("label_justificativa") = "SEM_VALOR" 'Assume que  esta sem valor
                    Else
                        cbo_justificativa.SelectedValue = cbo_justificativa.Items.FindByText(ViewState("label_justificativa").Trim.ToString).Value
                        ViewState("label_justificativa") = Nothing 'Assume que  tem valor
                    End If

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub
End Class
