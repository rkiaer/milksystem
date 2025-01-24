Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class lst_poupanca_adesao

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        Dim poupancaadesaoselecao As New PoupancaAdesao

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_poupanca_parametro") = cbo_referencia_poupanca.SelectedValue
        ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()

        If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
            ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        Else
            ViewState.Item("id_pessoa") = 0
        End If

        If Not (Me.txt_id_propriedade.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_propriedade") = Me.txt_id_propriedade.Text.Trim()
        Else
            ViewState.Item("id_propriedade") = 0
        End If

        ViewState.Item("dt_referencia_ini_poupanca_parametro") = String.Concat("01/", Left(cbo_referencia_poupanca.SelectedItem.Text.Trim, 7)).ToString

        'Ao realizar nova pesquisa, insere dados novos a selção
        poupancaadesaoselecao.tablename = "ms_poupanca_adesao_selecao"
        poupancaadesaoselecao.id_poupanca_adesao_execucao = poupancaadesaoselecao.getExecucaoPoupancaAdesao 'pega novo numero de execucao

        poupancaadesaoselecao.id_estabelecimento_filtro = cbo_estabelecimento.SelectedValue
        poupancaadesaoselecao.id_poupanca_parametro_filtro = cbo_referencia_poupanca.SelectedValue
        poupancaadesaoselecao.id_pessoa_filtro = ViewState.Item("id_pessoa").ToString
        poupancaadesaoselecao.id_propriedade_filtro = ViewState.Item("id_propriedade").ToString
        poupancaadesaoselecao.incluirAdesaoSelecao() 'inclui na tabela de seleção

        ViewState.Item("id_poupanca_adesao_execucao") = poupancaadesaoselecao.id_poupanca_adesao_execucao

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_poupanca_adesao.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_poupanca_adesao.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
            '.Style("cursor") = "hand"
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


            ViewState.Item("sortExpression") = "st_selecao, ds_produtor, id_propriedade"




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("poupancaadesao", cbo_estabelecimento.ID).Equals("0")) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("poupancaadesao", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = "0"
        End If

        If Not (customPage.getFilterValue("poupancaadesao", cbo_referencia_poupanca.ID).Equals("0")) Then
            hasFilters = True
            ViewState.Item("id_poupanca_parametro") = customPage.getFilterValue("poupancaadesao", cbo_referencia_poupanca.ID)
            cbo_referencia_poupanca.Text = ViewState.Item("id_poupanca_parametro").ToString()
        Else
            ViewState.Item("id_poupanca_parametro") = "0"
        End If

        If Not (customPage.getFilterValue("poupancaadesao", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("poupancaadesao", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("poupancaadesao", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("poupancaadesao", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("poupancaadesao", txt_id_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("poupancaadesao", txt_id_propriedade.ID)
            txt_id_propriedade.Text = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("poupancaadesao", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("poupancaadesao", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("poupancaadesao", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("poupancaadesao", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("poupancaadesao")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim poupancaadesao As New PoupancaAdesao


            'preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            poupancaadesao.id_poupanca_adesao_execucao = Convert.ToInt32(ViewState.Item("id_poupanca_adesao_execucao").ToString)

            Dim dspoupancaadesaoselecao As DataSet = poupancaadesao.getPoupancaAdesaoSelecao()

            If (dspoupancaadesaoselecao.Tables(0).Rows.Count > 0) Then
                Me.lk_incluir_adesao.Enabled = True
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dspoupancaadesaoselecao.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                Me.lk_incluir_adesao.Enabled = False
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If
            Case "ds_produtor"
                If (ViewState.Item("sortExpression")) = "ds_produtor asc" Then
                    ViewState.Item("sortExpression") = "ds_produtor desc"
                Else
                    ViewState.Item("sortExpression") = "ds_produtor asc"
                End If
            Case "dt_adesao"
                If (ViewState.Item("sortExpression")) = "dt_adesao asc" Then
                    ViewState.Item("sortExpression") = "dt_adesao desc"
                Else
                    ViewState.Item("sortExpression") = "dt_adesao asc"
                End If
            Case "nr_tempo_adesao"
                If (ViewState.Item("sortExpression")) = "nr_tempo_adesao asc" Then
                    ViewState.Item("sortExpression") = "nr_tempo_adesao desc"
                Else
                    ViewState.Item("sortExpression") = "nr_tempo_adesao asc"
                End If


        End Select

        loadData()

    End Sub

    'Private Sub saveFilters()

    '    Try

    '        customPage.setFilter("centraldeslig", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
    '        customPage.setFilter("centraldeslig", txt_MesAno.ID, ViewState.Item("dt_referencia").ToString)
    '        customPage.setFilter("centraldeslig", "PageIndex", gridResults.PageIndex.ToString())
    '        customPage.setFilter("centraldeslig", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
    '        customPage.setFilter("centraldeslig", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
    '        customPage.setFilter("centraldeslig", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
    '        customPage.setFilter("centraldeslig", txt_id_propriedade.ID, ViewState.Item("id_propriedade").ToString)
    '        customPage.setFilter("centraldeslig", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        Try

            If (e.Row.RowType <> DataControlRowType.Header _
                And e.Row.RowType <> DataControlRowType.Footer _
                And e.Row.RowType <> DataControlRowType.Pager) Then

                Dim st_adesao_ok As Label = CType(e.Row.FindControl("st_adesao_ok"), Label)
                Dim ck_item As Anthem.CheckBox = CType(e.Row.FindControl("ck_item"), Anthem.CheckBox)
                Dim img_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)

                'se já aderiu a poupanca nao deixa selecionar
                If st_adesao_ok.Text.Equals("1") Then
                    ck_item.Enabled = False
                    ck_item.ToolTip = "A propriedade já aderiu à Poupança."
                    img_delete.ImageUrl = "~/img/icone_excluir.gif"
                    img_delete.Enabled = True
                    img_delete.ToolTip = "Desativar registro de adesão."
                Else
                    ck_item.Enabled = True
                    ck_item.ToolTip = String.Empty
                    img_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                    img_delete.Enabled = False
                    img_delete.ToolTip = String.Empty
                End If

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try



    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub lk_incluir_adesao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_incluir_adesao.Click
        If Page.IsValid Then

            Try
                Dim poupancaadesao As New PoupancaAdesao

                'B usca os selecionados e inclui propriedades na tabela poupanca adesao antes de inicializar processo 
                poupancaadesao.id_poupanca_adesao_execucao = ViewState.Item("id_poupanca_adesao_execucao")
                poupancaadesao.dt_referencia_ini_poupanca_parametro = DateAdd(DateInterval.Year, -1, Convert.ToDateTime(ViewState.Item("dt_referencia_ini_poupanca_parametro")))
                poupancaadesao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
                poupancaadesao.dt_adesao = txt_dt_adesao.Text
                poupancaadesao.id_modificador = Session("id_login")
                poupancaadesao.incluirPoupancaAdesao()

                txt_dt_adesao.Text = String.Empty

                loadData()
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox
            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

            Dim st_adesao_ok As Label = CType(Row.FindControl("st_adesao_ok"), Label)

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                If ch.Enabled = True Then 'se estiver habilitado, ainda nao tem adesao poupanca
                    ch.Checked = ck_header.Checked
                End If
            Next

            '' Seleciona tudo o que o botão Pesquisar trouxe - i
            Dim poupancaadesaoselecao As New PoupancaAdesao
            poupancaadesaoselecao.id_poupanca_adesao_execucao = Convert.ToInt32(ViewState.Item("id_poupanca_adesao_execucao").ToString)
            If ck_header.Checked = True Then
                poupancaadesaoselecao.st_selecao = "1"
            Else
                poupancaadesaoselecao.st_selecao = "0"
            End If
            poupancaadesaoselecao.updatePoupancaAdesaoSelecaoTodos()
            '  Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        'lbl_nm_pessoa.Text = String.Empty
        'lbl_nm_pessoa.Visible = False
        'hf_id_pessoa.Value = String.Empty

        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty
        'fran chamado 684 i 
        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 'fran 05/05/2010
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
        End If

    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_aderir_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_aderir.ServerValidate
        Try
            args.IsValid = True
            Dim lmsg As String = String.Empty
            Dim poupancaadesao As New PoupancaAdesao
            Dim ldtrefini As String
            Dim ldtreffim As String

            ldtrefini = String.Concat("01/", Left(cbo_referencia_poupanca.SelectedItem.Text.Trim, 7)).ToString()
            ldtreffim = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("01/", Right(cbo_referencia_poupanca.SelectedItem.Text.Trim, 7)).ToString))))

            If (CDate(txt_dt_adesao.text) > CDate(ldtreffim)) Then
                args.IsValid = False
                lmsg = "A Data de Adesão não pode ser maior que a data final do período de referência da Poupança."
            End If

            If (CDate(txt_dt_adesao.text) < CDate(ldtrefini)) Then
                args.IsValid = False
                lmsg = "A Data de Adesão não pode ser menor que a data inicial do período de referência da Poupança."
            End If

            poupancaadesao.id_poupanca_adesao_execucao = Convert.ToInt32(ViewState.Item("id_poupanca_adesao_execucao").ToString)
            Dim dspoupancaadesaoselecao As DataSet = poupancaadesao.getPoupancaAdesaoConsistirSelecao()
            'se tem itens selecionados que ainda nao aderiram à poupanca
            If (dspoupancaadesaoselecao.Tables(0).Rows.Count = 0) Then
                args.IsValid = False
                lmsg = "Nenhum registro foi selecionado. Por favor, selecione alguma Propriedade sem data de adesão informada!"
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        If cbo_estabelecimento.SelectedValue <> "0" Then
            cbo_referencia_poupanca.Enabled = True

            Dim poupancaparametro As New PoupancaParametro

            poupancaparametro.id_estabelecimento = cbo_estabelecimento.SelectedValue
            poupancaparametro.id_situacao_poupanca = 1 'aberto (traz apenas as referencias abertas

            cbo_referencia_poupanca.DataSource = poupancaparametro.getPoupancaParametro()
            cbo_referencia_poupanca.DataTextField = "ds_periodo_poupanca"
            cbo_referencia_poupanca.DataValueField = "id_poupanca_parametro"
            cbo_referencia_poupanca.DataBind()
            cbo_referencia_poupanca.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_referencia_poupanca.SelectedValue = 0
        Else
            cbo_referencia_poupanca.Items.Clear()
            cbo_referencia_poupanca.Enabled = False
        End If
    End Sub

    Protected Sub ck_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim chk_selec As CheckBox

        chk_selec = CType(sender, CheckBox)

        Dim id_poupanca_adesao_selecao As Label = CType(row.FindControl("id_poupanca_adesao_selecao"), Label)
        '' Seleciona o item selecionado
        Dim poupancaadesaoselecao As New PoupancaAdesao
        poupancaadesaoselecao.id_poupanca_adesao_selecao = Convert.ToInt32(id_poupanca_adesao_selecao.Text)
        If chk_selec.Checked = True Then
            poupancaadesaoselecao.st_selecao = "1"
        Else
            poupancaadesaoselecao.st_selecao = "0"
        End If
        poupancaadesaoselecao.updatePoupancaAdesaoSelecao()

    End Sub

    Protected Sub cbo_referencia_poupanca_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_referencia_poupanca.SelectedIndexChanged
        If Not cbo_referencia_poupanca.SelectedValue.Equals("0") Then
            dt_referencia_ini.Text = String.Concat("01/", Left(cbo_referencia_poupanca.SelectedItem.Text.Trim, 7)).ToString
            dt_referencia_fim.Text = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("01/", Right(cbo_referencia_poupanca.SelectedItem.Text.Trim, 7)).ToString))))

        End If

    End Sub

   
    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "delete"
                'deletePoupancaAdesao(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deletePoupancaAdesao(ByVal id_poupanca_adesao As Integer)

        Try

            'Dim poupancaparametro As New PoupancaParametro()
            'poupancaparametro.id_poupanca_parametro = id_analise
            'poupancaparametro.id_modificador = Convert.ToInt32(Session("id_login"))
            'poupancaparametro.deletePoupancaParametro()
            'messageControl.Alert("Registro desativado com sucesso!")
            'loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
