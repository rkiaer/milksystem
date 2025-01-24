Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_pagto_transportador

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then

            ViewState.Item("id_transportador") = Me.hf_id_transportador.Value
            ViewState.Item("txt_dt_pagto_ini") = Me.txt_dt_pagto_ini.Text.Trim
            ViewState.Item("txt_dt_pagto_fim") = Me.txt_dt_pagto_fim.Text.Trim
            If (Me.txt_dt_pagto_fim.Text.Trim) = "" Then
                ViewState.Item("txt_dt_pagto_fim") = Me.txt_dt_pagto_ini.Text.Trim
            End If
            ViewState.Item("cd_codigo_sap") = Me.txt_cd_sap.Text
            ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

            loadData()
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_pagto_transportador.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_pagto_transportador.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 132
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportadores"
        End With
    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao


            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            'cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_situacao.SelectedValue = 1

            txt_dt_pagto_ini.Text = "01/" & DateTime.Parse(Now).ToString("MM/yyyy")
            txt_dt_pagto_fim.Text = "01/" & DateTime.Parse(DateAdd(DateInterval.Month, 1, Convert.ToDateTime(txt_dt_pagto_ini.Text))).ToString("MM/yyyy")

            ViewState.Item("sortExpression") = "dt_pagto asc"

            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean


    '    If Not (customPage.getFilterValue("pagt", txt_cd_transportador.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("cd_pessoa") = customPage.getFilterValue("analise_esalq", txt_cd_transportador.ID)
    '        txt_cd_transportador.Text = ViewState.Item("cd_pessoa").ToString()
    '    Else
    '        ViewState.Item("cd_pessoa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("analise_esalq", lbl_nm_transportador.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("nm_pessoa") = customPage.getFilterValue("analise_esalq", lbl_nm_transportador.ID)
    '        lbl_nm_transportador.Text = ViewState.Item("nm_pessoa").ToString()
    '    Else
    '        ViewState.Item("nm_pessoa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("analise_esalq", txt_cd_propriedade.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_propriedade") = customPage.getFilterValue("analise_esalq", txt_cd_propriedade.ID)
    '        txt_cd_propriedade.Text = ViewState.Item("id_propriedade").ToString()

    '    Else
    '        ViewState.Item("id_propriedade") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("analise_esalq(", lbl_nm_propriedade.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("nm_propriedade") = customPage.getFilterValue("analise_esalq", lbl_nm_propriedade.ID)
    '        lbl_nm_propriedade.Text = ViewState.Item("nm_propriedade").ToString()
    '        hf_id_propriedade.Value = ViewState.Item("id_propriedade")
    '    Else
    '        ViewState.Item("nm_propriedade") = String.Empty
    '        hf_id_propriedade.Value = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("analise_esalq", hf_id_transportador.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_pessoa") = customPage.getFilterValue("analise_esalq", hf_id_transportador.ID)
    '        hf_id_transportador.Value = ViewState.Item("id_pessoa").ToString()
    '    Else
    '        ViewState.Item("id_pessoa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("analise_esalq", txt_dt_coleta_ini.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("txt_dt_coleta_ini") = customPage.getFilterValue("analise_esalq", txt_dt_coleta_ini.ID)
    '        txt_dt_coleta_ini.Text = ViewState.Item("txt_dt_coleta_ini").ToString()
    '    Else
    '        ViewState.Item("txt_dt_coleta_ini") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("analise_esalq", txt_dt_coleta_fim.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("txt_dt_coleta_fim") = customPage.getFilterValue("analise_esalq", txt_dt_coleta_fim.ID)
    '        txt_dt_coleta_fim.Text = ViewState.Item("txt_dt_coleta_fim").ToString()
    '    Else
    '        ViewState.Item("txt_dt_coleta_fim") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("analise_esalq", cbo_codigo_esalq.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("cd_analise_esalq") = customPage.getFilterValue("analise_esalq", cbo_codigo_esalq.ID)
    '        cbo_codigo_esalq.Text = ViewState.Item("cd_analise_esalq").ToString()
    '    Else
    '        ViewState.Item("cd_analise_esalq") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("analise_esalq", cbo_situacao.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_situacao") = customPage.getFilterValue("analise_esalq", cbo_situacao.ID)
    '        cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
    '    Else
    '        ViewState.Item("id_situacao") = String.Empty
    '    End If


    '    If Not (customPage.getFilterValue("analise_esalq", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("analise_esalq", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("analise_esalq")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim pagtotransp As New PagtoTransportador

            If Trim(ViewState.Item("id_transportador")) <> "" Then
                pagtotransp.id_transportador = Convert.ToInt32(ViewState.Item("id_transportador").ToString)
            End If
            pagtotransp.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            pagtotransp.dt_pagto_ini = ViewState.Item("txt_dt_pagto_ini").ToString
            pagtotransp.dt_pagto_fim = ViewState.Item("txt_dt_pagto_fim").ToString
            pagtotransp.cd_codigo_sap = ViewState.Item("cd_codigo_sap").ToString()
            Dim dspagtotransp As DataSet = pagtotransp.getPagtoTransportadorByFilters()

            If (dspagtotransp.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dspagtotransp.Tables(0), ViewState.Item("sortExpression"))
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


            Case "ds_transportador"
                If (ViewState.Item("sortExpression")) = "ds_transportador asc" Then
                    ViewState.Item("sortExpression") = "ds_transportador desc"
                Else
                    ViewState.Item("sortExpression") = "ds_transportador asc"
                End If


            Case "dt_pagto"
                If (ViewState.Item("sortExpression")) = "dt_pagto asc" Then
                    ViewState.Item("sortExpression") = "dt_pagto desc"
                Else
                    ViewState.Item("sortExpression") = "dt_pagto asc"
                End If


            Case "cd_codigo_sap"
                If (ViewState.Item("sortExpression")) = "cd_codigo_sap asc" Then
                    ViewState.Item("sortExpression") = "cd_codigo_sap desc"
                Else
                    ViewState.Item("sortExpression") = "cd_codigo_sap asc"
                End If

        End Select

        loadData()

    End Sub

    'Private Sub saveFilters()

    '    Try


    '        customPage.setFilter("analise_esaq", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
    '        customPage.setFilter("analise_esaq", txt_cd_transportador.ID, ViewState.Item("cd_pessoa").ToString)
    '        customPage.setFilter("analise_esaq", lbl_nm_transportador.ID, lbl_nm_transportador.Text)
    '        customPage.setFilter("analise_esaq", txt_cd_propriedade.ID, ViewState.Item("id_propriedade").ToString)
    '        customPage.setFilter("analise_esaq", hf_id_transportador.ID, ViewState.Item("id_pessoa").ToString)
    '        customPage.setFilter("analise_esaq", lbl_nm_propriedade.ID, ViewState.Item("nm_propriedade").ToString)
    '        customPage.setFilter("analise_esaq", txt_dt_coleta_ini.ID, ViewState.Item("txt_dt_coleta_ini").ToString)
    '        customPage.setFilter("analise_esaq", txt_dt_coleta_fim.ID, ViewState.Item("txt_dt_coleta_fim").ToString)
    '        customPage.setFilter("analise_esaq", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
    '        customPage.setFilter("analise_esaq", cbo_codigo_esalq.ID, ViewState.Item("cd_analise_esalq").ToString)
    '        customPage.setFilter("analise_esaq", "PageIndex", gridResults.PageIndex.ToString())

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()


            Case "delete"
                deletePagtoTransportador(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deletePagtoTransportador(ByVal id_pagto_transportador As Integer)

        Try
            Dim pagtotransp As New PagtoTransportador()
            pagtotransp.id_pagto_transportador = id_pagto_transportador
            pagtotransp.id_modificador = Convert.ToInt32(Session("id_login"))
            pagtotransp.deletePagtoTransportador()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 132
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_st_exportacao As Label = CType(e.Row.FindControl("lbl_st_exportacao"), Label)
            Dim img_st_exportacao As Anthem.Image = CType(e.Row.FindControl("img_st_exportacao"), Anthem.Image)
            Dim img_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)

            If lbl_st_exportacao.Text = "S" Then 'se tem exportacao
                img_st_exportacao.ImageUrl = "~/img/ico_chk_true.gif"
                img_st_exportacao.ToolTip = "Exportação para o SAP realizada."
                img_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                img_delete.ToolTip = "Não pode ser Desativado pois já foi exportado."
            Else
                img_st_exportacao.ImageUrl = "~/img/ico_chk_false.gif"
                img_st_exportacao.ToolTip = "Exportação para o SAP não realizada."
                img_delete.ImageUrl = "~/img/icone_excluir.gif"
                img_delete.ToolTip = "Desativar"

            End If
        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
        Else
            txt_cd_transportador.Text = String.Empty
            hf_id_transportador.Value = String.Empty
            lbl_nm_transportador.Text = String.Empty
            lbl_nm_transportador.Visible = False
        End If

    End Sub

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        lbl_nm_transportador.Text = String.Empty
        lbl_nm_transportador.Visible = False
        hf_id_transportador.Value = String.Empty

    End Sub

    Private Sub carregarCamposTransportador()

        Try

            If Not (customPage.getFilterValue("lupa_transcoop", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transcoop", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transcoop", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transcoop", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_transcoop")

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidtransportador As Int32
            If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_transportador.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
            'lidtransportador = pessoa.validarTransportador Fran 09/01/2011 i
            lidtransportador = pessoa.validarTransportadorCooperativa

            If lidtransportador > 0 Then
                args.IsValid = True
                hf_id_transportador.Value = lidtransportador
            Else
                hf_id_transportador.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Transportador não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Page.IsValid Then

            ViewState.Item("id_transportador") = Me.hf_id_transportador.Value
            ViewState.Item("txt_dt_pagto_ini") = Me.txt_dt_pagto_ini.Text.Trim
            ViewState.Item("txt_dt_pagto_fim") = Me.txt_dt_pagto_fim.Text.Trim
            If (Me.txt_dt_pagto_fim.Text.Trim) = "" Then
                ViewState.Item("txt_dt_pagto_fim") = Me.txt_dt_pagto_ini.Text.Trim
            End If
            ViewState.Item("cd_codigo_sap") = Me.txt_cd_sap.Text
            ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

            loadData()

            'se o grid tiver mais que 65536  linhas não podemos exportar
            If gridResults.Visible = True Then
                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 8 'exporta~ção
                    usuariolog.id_menu_item = 132
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    Response.Redirect("frm_pagto_transportador_excel.aspx?id_transportador=" + ViewState.Item("id_transportador").ToString + "&id_situacao=" + ViewState.Item("id_situacao").ToString + "&dt_pagto_ini=" + ViewState.Item("txt_dt_pagto_ini").ToString + "&dt_pagto_fim=" + ViewState.Item("txt_dt_pagto_fim").ToString + "&cd_codigo_sap=" + ViewState.Item("cd_codigo_sap"))
                Else
                    messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
                End If
            End If

        End If

    End Sub
End Class
