Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_util_ExportaVolumeFicha
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        btn_exportar.Visible = True
        If Not (txt_nm_tecnico.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("nm_tecnico") = txt_nm_tecnico.Text.Trim()
        Else
            ViewState.Item("nm_tecnico") = String.Empty
        End If

        If Not (dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia") = "01/" + dt_referencia.Text.Trim()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        If Not (txt_produtor.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_pessoa") = txt_produtor.Text.Trim()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If
        If Not (txt_propriedade.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_propriedade") = txt_propriedade.Text.Trim()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        ' adri 06/03/2012 - projeto Themis - Processo de Cálculo unificado por IE - i
        ViewState.Item("tp_pagamento") = cbo_tipo_pagamento.SelectedValue
        ' adri 06/03/2012 - projeto Themis - Processo de Cálculo unificado por IE - f

        'chamado 1576 - 01/08/2012 - Mirella i
        If Not (txt_cd_sap.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_codigo_sap") = txt_cd_sap.Text.Trim()
        Else
            ViewState.Item("cd_codigo_sap") = String.Empty
        End If
        'chamado 1576 - 01/08/2012 - Mirella f
        ViewState.Item("st_pagamento") = cbo_calculo.SelectedValue 'DANGO 2018

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_util_ExportaVolumeFicha.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_util_ExportaVolumeFicha.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 81
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 


            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ' adri 06/03/2012 - projeto Themis - Processo de Cálculo unificado por IE - i
            cbo_tipo_pagamento.Items.Add(New ListItem("Mensal", "M"))
            cbo_tipo_pagamento.Items.Add(New ListItem("Consolidado", "C"))
            ' adri 06/03/2012 - projeto Themis - Processo de Cálculo unificado por IE - f


            ViewState.Item("sortExpression") = "nm_tecnico asc"




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("exportar", txt_nm_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_tecnico") = customPage.getFilterValue("exportar", txt_nm_tecnico.ID)
            txt_nm_tecnico.Text = ViewState.Item("nm_tecnico").ToString()
        Else
            ViewState.Item("nm_tecnico") = String.Empty
        End If

        If Not (customPage.getFilterValue("exportar", dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("exportar", dt_referencia.ID)
            dt_referencia.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If
        If Not (customPage.getFilterValue("exportar", txt_produtor.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("exportar", txt_produtor.ID)
            txt_produtor.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("exportar", txt_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("exportar", txt_propriedade.ID)
            txt_propriedade.Text = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If


        'chamado 1576 - 02/08/2012 - Mirella i
        If Not (customPage.getFilterValue("propriedade", txt_cd_sap.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_codigo_sap") = customPage.getFilterValue("propriedade", txt_cd_sap.ID)
            txt_cd_sap.Text = ViewState.Item("cd_codigo_sap").ToString()
        Else
            ViewState.Item("cd_codigo_sap") = String.Empty
        End If
        'chamado 1576 - 02/08/2012 - Mirella f


        If Not (customPage.getFilterValue("exportar", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("exportar", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("exportar")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim exportavolume As New ExportaVolume

            If Not (ViewState("nm_tecnico").ToString().Equals(String.Empty)) Then
                exportavolume.nm_tecnico = Convert.ToString(ViewState.Item("nm_tecnico"))
            End If
            If Not (ViewState("cd_pessoa").ToString().Equals(String.Empty)) Then
                exportavolume.cd_pessoa = Convert.ToInt32(ViewState.Item("cd_pessoa"))
            End If
            If Not (ViewState("dt_referencia").ToString().Equals(String.Empty)) Then
                exportavolume.dt_referencia = Convert.ToString(ViewState.Item("dt_referencia"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                exportavolume.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("id_propriedade").ToString().Equals(String.Empty)) Then
                exportavolume.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If
            ' adri 06/03/2012 - projeto Themis - Processo de Cálculo unificado por IE - i
            If Not (ViewState("tp_pagamento").ToString().Equals(String.Empty)) Then
                exportavolume.tp_pagamento = ViewState.Item("tp_pagamento")
            End If
            ' adri 06/03/2012 - projeto Themis - Processo de Cálculo unificado por IE - f


            'chamado 1576 - 01/08/2012 - Mirella i
            If Not (ViewState("cd_codigo_sap").ToString().Equals(String.Empty)) Then
                exportavolume.cd_codigo_sap = Convert.ToString(ViewState.Item("cd_codigo_sap"))
            End If
            'chamado 1576 - 01/08/2012 - Mirella f
            'DANGO 2018 Fran i
            exportavolume.st_pagamento = ViewState.Item("st_pagamento").ToString 'DANGO 2018

            'DANGO 2018 Fran f

            Dim dsExportaVolume As DataSet = exportavolume.getExportaVolumebyFilters()

            If (dsExportaVolume.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsExportaVolume.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()



            Case "nm_tecnico"
                If (ViewState.Item("sortExpression")) = "nm_tecnico asc" Then
                    ViewState.Item("sortExpression") = "nm_tecnico desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tecnico asc"
                End If


            Case "st_categoria"
                If (ViewState.Item("sortExpression")) = "st_categoria asc" Then
                    ViewState.Item("sortExpression") = "st_categoria desc"
                Else
                    ViewState.Item("sortExpression") = "st_categoria asc"
                End If

                'chamado 1576 - 01/08/2012 - Mirella i
            Case "cd_codigo_sap"
                If (ViewState.Item("sortExpression")) = "cd_codigo_sap asc" Then
                    ViewState.Item("sortExpression") = "cd_codigo_sap desc"
                Else
                    ViewState.Item("sortExpression") = "cd_codigo_sap asc"
                End If
                'chamado 1576 - 01/08/2012 - Mirella f


        End Select

        loadData()

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub

    Protected Sub gridResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        If Not (txt_nm_tecnico.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("nm_tecnico") = txt_nm_tecnico.Text.Trim()
        Else
            ViewState.Item("nm_tecnico") = String.Empty
        End If

        If Not (dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia") = "01/" + dt_referencia.Text.Trim()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        If Not (txt_produtor.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_pessoa") = txt_produtor.Text.Trim()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If
        If Not (txt_propriedade.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_propriedade") = txt_propriedade.Text.Trim()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        ' adri 06/03/2012 - projeto Themis - Processo de Cálculo unificado por IE - i
        ViewState.Item("tp_pagamento") = cbo_tipo_pagamento.SelectedValue
        ' adri 06/03/2012 - projeto Themis - Processo de Cálculo unificado por IE - f
        ViewState.Item("st_pagamento") = cbo_calculo.SelectedValue 'DANGO 2018


        'chamado 1576 - 01/08/2012 - Mirella i
        If Not (txt_cd_sap.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_codigo_sap") = txt_cd_sap.Text.Trim()
        Else
            ViewState.Item("cd_codigo_sap") = String.Empty
        End If
        'chamado 1576 - 01/08/2012 - Mirella f


        loadData()
        'fran 01/04/2009 i
        'Response.Redirect("frm_Ficha_excel.aspx?nm_tecnico=" + ViewState.Item("nm_tecnico").ToString + "&cd_pessoa=" + ViewState.Item("cd_pessoa").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString())
        If gridResults.Rows.Count.ToString + 1 < 65536 Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 81
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            'Response.Redirect("frm_Ficha_excel.aspx?nm_tecnico=" + ViewState.Item("nm_tecnico").ToString + "&cd_pessoa=" + ViewState.Item("cd_pessoa").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString())
            'Response.Redirect("frm_Ficha_excel.aspx?nm_tecnico=" + ViewState.Item("nm_tecnico").ToString + "&cd_pessoa=" + ViewState.Item("cd_pessoa").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&tp_pagamento=" + ViewState.Item("tp_pagamento").ToString)   ' adri 10/09/2012 - chamado 1549
            Response.Redirect("frm_Ficha_excel.aspx?nm_tecnico=" + ViewState.Item("nm_tecnico").ToString + "&cd_pessoa=" + ViewState.Item("cd_pessoa").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&st_pagamento=" + ViewState.Item("st_pagamento").ToString + "&tp_pagamento=" + ViewState.Item("tp_pagamento").ToString + "&cd_codigo_sap=" + ViewState.Item("cd_codigo_sap").ToString)   'chamado 1576 - 01/08/2012 - Mirella 
        Else
            messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")  ' Adri
        End If
        'fran 01/04/2009 f


    End Sub








End Class

