Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.Math

Partial Class lst_adiantamento_aprovar_1N

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("dt_referencia") = Me.txt_MesAno.Text()
        ViewState.Item("id_tecnico") = txt_cd_tecnico.Text()
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue
        ViewState.Item("st_aprovado") = Me.cbo_status.SelectedValue

        Dim adiantamento As New Adiantamento

        adiantamento.dt_referencia = String.Concat("01/", Me.txt_MesAno.Text.Trim())
        adiantamento.st_selecao = "0"

        adiantamento.updateAdiantamentoTodos1N()
        If (gridResults.Rows.Count > 0) Then
            gridResults.DataSource = String.Empty
            gridResults.Visible = False
        End If

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_adiantamento_aprovar_1N.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_adiantamento_aprovar_1N.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 41
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

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim statusadiantamento As New StatusAdiantamento

            statusadiantamento.st_aprovado = "2"  ' não traz o item 2 - Aprovado 2.Nivel
            cbo_status.DataSource = statusadiantamento.getStatusAdiantamentoByFilters()
            cbo_status.DataTextField = "nm_aprovado"
            cbo_status.DataValueField = "st_aprovado"
            cbo_status.DataBind()


            ViewState.Item("sortExpression") = "ds_produtor asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("adiantamento_solicitar", cbo_status.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("st_aprovado") = customPage.getFilterValue("adiantamento_solicitar", cbo_status.ID)
            Me.cbo_status.Text = ViewState.Item("st_aprovado").ToString()
        Else
            ViewState.Item("st_aprovado") = String.Empty
        End If


        If Not (customPage.getFilterValue("adiantamento_solicitar", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("adiantamento_solicitar", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("adiantamento_solicitar", txt_MesAno.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("adiantamento_solicitar", txt_MesAno.ID)
            txt_MesAno.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        If Not (customPage.getFilterValue("adiantamento_solicitar", txt_cd_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_tecnico") = customPage.getFilterValue("adiantamento_solicitar", txt_cd_tecnico.ID)
            txt_cd_tecnico.Text = ViewState.Item("id_tecnico").ToString()
        Else
            ViewState.Item("id_tecnico") = String.Empty
        End If

        If Not (customPage.getFilterValue("adiantamento_solicitar", lbl_nm_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_tecnico") = customPage.getFilterValue("adiantamento_solicitar", lbl_nm_tecnico.ID)
            lbl_nm_tecnico.Text = ViewState.Item("nm_tecnico").ToString()
            hf_id_tecnico.Value = ViewState.Item("id_tecnico").ToString
        Else
            ViewState.Item("nm_tecnico") = String.Empty
            hf_id_tecnico.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("adiantamento_solicitar", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("adiantamento_solicitar", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("adiantamento_solicitar")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim adiantamento As New Adiantamento

            If Trim(ViewState.Item("id_tecnico")) <> "" Then
                adiantamento.id_tecnico = ViewState("id_tecnico").ToString
            End If
            adiantamento.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            If Trim(ViewState.Item("st_aprovado")) <> "0" Then
                adiantamento.st_aprovado = ViewState.Item("st_aprovado").ToString
            End If
            adiantamento.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)

            Me.lbl_total_adto.Visible = True
            Me.lbl_valor_total_adto.Visible = True
            Me.lk_aprovar.Enabled = True
            Me.lk_reprovar.Enabled = True

            Me.lbl_valor_total_adto.Text = adiantamento.getAdiantamentoValorTotal()

            '' Limpar itens selecionados antes de carregar dados
            'adiantamento.st_selecao = "0"
            'adiantamento.updateAdiantamentoSelecao()

            Dim dsAdiantamento As DataSet = adiantamento.getAdiantamentoByFilters()

            If (dsAdiantamento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsAdiantamento.Tables(0), ViewState.Item("sortExpression"))
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

                ' 26/11/2009 - Chamado 499 - i
                'Case "nr_percentual_adto"
                '    If (ViewState.Item("sortExpression")) = "nr_percentual_adto asc" Then
                '        ViewState.Item("sortExpression") = "nr_percentual_adto desc"
                '    Else
                '        ViewState.Item("sortExpression") = "nr_percentual_adto asc"
                '    End If
                ' 26/11/2009 - Chamado 499 - f

            Case "nr_valor_adto"
                If (ViewState.Item("sortExpression")) = "nr_valor_adto asc" Then
                    ViewState.Item("sortExpression") = "nr_valor_adto desc"
                Else
                    ViewState.Item("sortExpression") = "nr_valor_adto asc"
                End If

            Case "nr_volume_mensal"
                If (ViewState.Item("sortExpression")) = "nr_volume_mensal asc" Then
                    ViewState.Item("sortExpression") = "nr_volume_mensal desc"
                Else
                    ViewState.Item("sortExpression") = "nr_volume_mensal asc"
                End If


            Case "st_aprovado"
                If (ViewState.Item("sortExpression")) = "st_aprovado asc" Then
                    ViewState.Item("sortExpression") = "st_aprovado desc"
                Else
                    ViewState.Item("sortExpression") = "st_aprovado asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub carregarCamposTecnico()

        Try

            Me.txt_cd_tecnico.Text = hf_id_tecnico.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try

            customPage.setFilter("adiantamento_solicitar", cbo_status.ID, ViewState.Item("st_aprovado").ToString)
            customPage.setFilter("adiantamento_solicitar", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("adiantamento_solicitar", txt_MesAno.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("adiantamento_solicitar", txt_cd_tecnico.ID, ViewState("id_tecnico").ToString)
            customPage.setFilter("adiantamento_solicitar", lbl_nm_tecnico.ID, lbl_nm_tecnico.Text)
            customPage.setFilter("adiantamento_solicitar", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        'e.Cancel = True
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
        lbl_nm_tecnico.Text = String.Empty
        lbl_nm_tecnico.Visible = False
        hf_id_tecnico.Value = String.Empty
    End Sub

    Protected Sub gridResults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridResults.RowCancelingEdit
        'Try

        '    gridResults.EditIndex = -1
        '    loadData()
        'Catch ex As Exception
        '    messageControl.Alert(ex.Message)
        'End Try
    End Sub
    Protected Sub gridResults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridResults.RowEditing
        'Try

        '    Dim lbl_status As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_status"), Label)
        '    ViewState.Item("label_status") = Trim(lbl_status.Text)
        '    gridResults.EditIndex = e.NewEditIndex
        '    loadData()
        'Catch ex As Exception
        '    messageControl.Alert(ex.Message)
        'End Try
    End Sub
    Protected Sub gridResults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridResults.RowUpdating
        ''Capturar valores
        'Dim row As GridViewRow = gridResults.Rows(e.RowIndex)
        'Try

        '    If (Not (row) Is Nothing) Then

        '        Dim adiantamento As New Adiantamento

        '        Dim cbo_status As DropDownList = CType(row.FindControl("cbo_status"), DropDownList)

        '        adiantamento.id_adiantamento = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)
        '        If Not (cbo_status.SelectedValue.Trim().Equals(String.Empty)) Then
        '            adiantamento.st_aprovado = Convert.ToInt32(cbo_status.SelectedValue)
        '        End If

        '        If Not (cbo_status.SelectedValue.Trim().Equals(String.Empty)) Then
        '            adiantamento.id_adiantamento_justificativa = Convert.ToInt32(cbo_status.SelectedValue)
        '        End If

        '        adiantamento.id_modificador = Session("id_login")

        '        adiantamento.updateAdiantamentoStatus()
        '        gridResults.EditIndex = -1
        '        loadData()
        '    End If

        'Catch ex As Exception
        '    messageControl.Alert(ex.Message)
        'End Try

    End Sub
    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated

        'If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

        '    Try
        '        If Not (ViewState("label_status") Is Nothing) Then

        '            Dim cbo_status As DropDownList = CType(e.Row.FindControl("cbo_status"), DropDownList)

        '            Dim statusadiantamento As New StatusAdiantamento

        '            cbo_status.DataSource = statusadiantamento.getStatusAdiantamentoByFilters()
        '            cbo_status.DataTextField = "nm_aprovado"
        '            cbo_status.DataValueField = "st_aprovado"
        '            cbo_status.DataBind()

        '            cbo_status.SelectedValue = cbo_status.Items.FindByText(ViewState("label_status").Trim.ToString).Value
        '            ViewState("label_justificativa") = Nothing 'Assume que  tem valor

        '        End If


        '    Catch ex As Exception
        '        messageControl.Alert(ex.Message)
        '    End Try

        'End If
    End Sub
    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        'Select Case e.CommandName.Trim.ToString
        '    Case "Edit", "Editar", "Cancel", "Cancelar", "Update"
        '        Return
        'End Select
    End Sub
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        ' 25/11/2009 - Chamado 499 - i
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then


            'Formatações
            If e.Row.Cells(7).Text.Equals(String.Empty) Then
                e.Row.Cells(7).Text = "0"
            End If

            'Total descontos + adto deve ser somado ao novo adto
            e.Row.Cells(7).Text = (Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) + Convert.ToDecimal(e.Row.Cells(6).Text.Trim()))

            ' Calcular % Comprometido (Total Desc + Adtos) / Valor Mensal Estimado
            If IsNumeric(e.Row.Cells(4).Text.Trim()) Then  ' Se tem Valor Mensal Estimado
                If Convert.ToDecimal(e.Row.Cells(4).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    'fran fase 3 formatação i
                    'e.Row.Cells(8).Text = Round(Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) / Convert.ToDecimal(e.Row.Cells(4).Text.Trim()), 2)
                    e.Row.Cells(8).Text = FormatPercent(Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) / Convert.ToDecimal(e.Row.Cells(4).Text.Trim()), 2)
                    'fran fase 3 formatação f
                End If
            End If



            If IsNumeric(e.Row.Cells(3).Text.Trim()) Then  ' volume
                If Convert.ToInt64(e.Row.Cells(3).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(3).Text = FormatNumber(Convert.ToInt64(e.Row.Cells(3).Text.Trim()))
                End If
            End If
            If IsNumeric(e.Row.Cells(4).Text.Trim()) Then  ' valor mensal
                If Convert.ToDecimal(e.Row.Cells(4).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(4).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(4).Text.Trim()), 2, , , TriState.True)
                End If
            End If
            If IsNumeric(e.Row.Cells(5).Text.Trim()) Then  ' descontos
                If Convert.ToDecimal(e.Row.Cells(5).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(5).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(5).Text.Trim()), 2, , , TriState.True)
                End If
            End If
            If IsNumeric(e.Row.Cells(6).Text.Trim()) Then  ' valor adto
                If Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(6).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(6).Text.Trim()), 2, , , TriState.True)
                End If
            End If
            If IsNumeric(e.Row.Cells(7).Text.Trim()) Then  ' total desc + adto
                If Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(7).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(7).Text.Trim()), 2, , , TriState.True)
                End If
            End If

            If IsNumeric(e.Row.Cells(11).Text.Trim()) Then  ' saldo x politica adto
                If Convert.ToDecimal(e.Row.Cells(11).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(11).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(11).Text.Trim()), 2, , , TriState.True)
                End If
            End If



        End If
        ' 25/11/2009 - Chamado 499 - f

    End Sub

    Protected Sub lk_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_aprovar.Click
        Try
            Dim adiantamento As New Adiantamento

            If verificarCheckBox() = True Then
                If Trim(ViewState.Item("dt_referencia")) = "" Then
                    messageControl.Alert("O Mes/Ano de Referência deve ser informado.")
                Else

                    adiantamento.dt_referencia = String.Concat("01/" & ViewState.Item("dt_referencia").ToString)
                    adiantamento.st_aprovado = "4"   '  Aprovados 1Niv
                    adiantamento.id_modificador = Session("id_login")

                    adiantamento.updateAdiantamentoAprovarSelecionados()

                    cbo_status.SelectedValue = "4" ' Listar os Aprovados 1Niv
                    ViewState.Item("st_aprovado") = Me.cbo_status.SelectedValue

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'PROCESSO
                    usuariolog.id_menu_item = 41
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f

                    loadData()

                    messageControl.Alert("Aprovação 1.o Nível concluída com sucesso.")
                End If
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione alguma propriedade.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function saveCheckBox() As Boolean

        Try

            Dim li As Integer
            Dim adiantamento As New Adiantamento()

            For li = 0 To gridResults.Rows.Count - 1
                adiantamento.id_adiantamento = gridResults.DataKeys(li).Value.ToString
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    adiantamento.st_selecao = "1"
                    saveCheckBox = True     ' Indica que tem item selecionado
                Else
                    adiantamento.st_selecao = "0"
                End If
                adiantamento.updateAdiantamentoSelecao()
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub lk_reprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_reprovar.Click
        Try
            Dim adiantamento As New Adiantamento

            If verificarCheckBox() = True Then
                If Trim(ViewState.Item("dt_referencia")) = "" Then
                    messageControl.Alert("O Mes/Ano de Referência deve ser informado.")
                Else

                    adiantamento.dt_referencia = String.Concat("01/" & ViewState.Item("dt_referencia").ToString)
                    adiantamento.st_aprovado = "3"   '  Reprovado
                    adiantamento.id_modificador = Session("id_login")

                    adiantamento.updateAdiantamentoAprovarSelecionados()

                    cbo_status.SelectedValue = "3" ' Listar os reprovados
                    ViewState.Item("st_aprovado") = Me.cbo_status.SelectedValue

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'PROCESSO
                    usuariolog.id_menu_item = 41
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f

                    loadData()

                    messageControl.Alert("Itens reprovados com sucesso.")
                End If
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione alguma propriedade.")
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

            Dim adiantamento As New Adiantamento
            If Trim(ViewState.Item("id_tecnico")) <> "" Then
                adiantamento.id_tecnico = ViewState("id_tecnico").ToString
            End If
            adiantamento.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            If Trim(ViewState.Item("st_aprovado")) <> "0" Then
                adiantamento.st_aprovado = ViewState.Item("st_aprovado").ToString
            End If
            adiantamento.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)

            If ck_header.Checked = True Then
                adiantamento.st_selecao = "1"
            Else
                adiantamento.st_selecao = "0"
            End If

            adiantamento.updateAdiantamentoTodos1N()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        Try
            If Page.IsValid = True Then
                Try

                    Dim notificacao As New Notificacao
                    Dim lAssunto As String = "Aprovação 2.o Nível de Adiantamento para Produtores "
                    Dim lCorpo As String = "Existem adiantamentos para Produtores aprovados em 1.o Nível pendentes para aprovação 2.o Nível."

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 9 'ENVIO EMAIL
                    usuariolog.id_menu_item = 41
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f

                    ' Parametro 6 - Adiantamento 2.o Nível
                    If notificacao.enviaMensagemEmail(6, lAssunto, lCorpo, MailPriority.High) = True Then

                        messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível foi enviada aos destinatários com sucesso!")
                    Else

                        messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")

                    End If

                Catch ex As Exception
                    messageControl.Alert(ex.Message)
                End Try


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub ck_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim chk_selec As CheckBox

            chk_selec = CType(sender, CheckBox)

            Dim adiantamento As New Adiantamento

            adiantamento.id_adiantamento = Convert.ToInt32(gridResults.DataKeys.Item(row.RowIndex).Value)
            If chk_selec.Checked = True Then
                adiantamento.st_selecao = "1"
            Else
                adiantamento.st_selecao = "0"
            End If
            adiantamento.updateAdiantamentoSelecao()

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try


    End Sub

    Private Function verificarCheckBox() As Boolean

        Try

            Dim adiantamento As New Adiantamento
            If Trim(ViewState.Item("id_tecnico")) <> "" Then
                adiantamento.id_tecnico = ViewState("id_tecnico").ToString
            End If
            adiantamento.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            If Trim(ViewState.Item("st_aprovado")) <> "0" Then
                adiantamento.st_aprovado = ViewState.Item("st_aprovado").ToString
            End If
            adiantamento.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)

            Dim dsadiantamento As DataSet = adiantamento.getAdiantamentosSelecionados

            If dsadiantamento.Tables(0).Rows.Count > 0 Then
                verificarCheckBox = True
            Else
                verificarCheckBox = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

End Class
