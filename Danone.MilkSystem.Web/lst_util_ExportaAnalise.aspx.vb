Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_util_ExportaAnalise
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        btn_exportar.Visible = True


        If Not (dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = dt_inicio.Text.Trim()
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If

        If Not (dt_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = dt_fim.Text.Trim()
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If
        'Fran 27/11/2009 i chamado 527 Maracanau
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        'Fran 27/11/2009 f chamado 527 Maracanau


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_util_ExportaAnalise.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_tecnico.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 83
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 


            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            'fran 27/11/2009 i chamado 527 Maracanau
            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'fran 27/11/2009 f chamado 527 Maracanau

            ' 06/04/2009 Rls17.3 - Desabilitado (solicitado pelo Ricardo pois está lento) - i
            Label1.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            Label4.Visible = False
            Label2.Visible = False
            Label8.Visible = False
            Label9.Visible = False
            ' 06/04/2009 Rls17.3 - Desabilitado (solicitado pelo Ricardo pois está lento) - f

            ViewState.Item("sortExpression") = "REG_ANALISE asc"




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean


    '    If Not (customPage.getFilterValue("exportar3", dt_inicio.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("dt_fim") = customPage.getFilterValue("exportar", dt_inicio.ID)
    '        dt_inicio.Text = ViewState.Item("dt_fim").ToString()
    '    Else
    '        ViewState.Item("dt_fim") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("exportar3", dt_inicio.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("dt_inicio") = customPage.getFilterValue("exportar", dt_inicio.ID)
    '        dt_inicio.Text = ViewState.Item("dt_inicio").ToString()
    '    Else
    '        ViewState.Item("dt_inicio") = String.Empty
    '    End If
    '    'fran 27/11/2009 i chamado 527 Maracanau
    '    If Not (customPage.getFilterValue("exportar3", cbo_estabelecimento.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_estabelecimento") = customPage.getFilterValue("exportar", dt_inicio.ID)
    '        dt_inicio.Text = ViewState.Item("dt_inicio").ToString()
    '    Else
    '        ViewState.Item("dt_inicio") = String.Empty
    '    End If
    '    'fran 27/11/2009 f chamado 527 Maracanau

    '    If Not (customPage.getFilterValue("exportar3", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("exportar3", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("exportar")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim Export As New ExportaAnalise

         
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                Export.dt_inicio = Convert.ToString(ViewState.Item("dt_inicio"))
            End If
            If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                Export.dt_fim = Convert.ToString(ViewState.Item("dt_fim"))
            End If
            'fran 27/11/2009 i chamado 527 Maracanau
            Export.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            'fran 27/11/2009 f chamado 527 Maracanau

            Dim a As Int32

            'fran 08/2015 i
            'Dim dsTecnico As DataSet = Export.getExportaAnalisebyFilters()
            Dim dsRomaneios As DataSet = Export.getRelatorioConferenciaRomaneio()
            'fran 08/2015 f

            If (dsRomaneios.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsRomaneios.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                ' 06/04/2009 Rls17.3 - Desabilirtado (solicitado pelo Ricardo pois está lento) - i
                'a = dsTecnico.Tables(0).Rows.Count
                'Label1.Text = dsTecnico.Tables(0).Rows.Count.ToString
                'Label5.Text = (Export.loadAnaliseAberta).ToString

                'Label6.Text = (Export.loadAnaliseIniciada).ToString
                'Label7.Text = (Export.loadAnaliseNOK).ToString & "     (" & CType((CType(Export.loadAnaliseNOK, Int32) / a * 100), Int32) & "%)"
                'Label4.Text = (Export.loadRomaneioFechado).ToString
                'Label2.Text = (Export.loadRomaneioAberto).ToString & "     (" & CType((CType(Export.loadRomaneioAberto, Int32) / a * 100), Int32) & "%)"
                'Label8.Text = (Export.loadSiloOK).ToString
                'Label9.Text = (Export.loadSiloNOK).ToString & "     (" & CType((CType(Export.loadSiloNOK, Int32) / a * 100), Int32) & "%)"
                ' 06/04/2009 Rls17.3 - Desabilirtado (solicitado pelo Ricardo pois está lento) - f

            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then
            Try
                Dim ds_tempo_rota_minutos As Label = CType(e.Row.FindControl("lbl_ds_tempo_rota_minutos"), Label)

                Select Case CDec(ds_tempo_rota_minutos.Text)
                    Case Is <= 720 ' Até 12 horas (720 minutos)
                        e.Row.Cells(16).BackColor = System.Drawing.Color.FromName("#00C000") 'verde coluna tempo rota
                    Case Is <= 1200
                        e.Row.Cells(16).BackColor = System.Drawing.Color.Yellow 'amarelo coluna tempo rota

                    Case Is > 1200
                        e.Row.Cells(16).BackColor = System.Drawing.Color.Red 'vermelho coluna tempo rota
                End Select


            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            'Case "id_tecnico"
            '    If (ViewState.Item("sortExpression")) = "id_tecnico asc" Then
            '        ViewState.Item("sortExpression") = "id_tecnico desc"
            '    Else
            '        ViewState.Item("sortExpression") = "id_tecnico asc"
            '    End If



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
        'fran 01/04/2009 i
        'Response.Redirect("frm_Analise_excel.aspx?dt_fim=" + ViewState.Item("dt_fim").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString)

        If Not (dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = dt_inicio.Text.Trim()
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If

        If Not (dt_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = dt_fim.Text.Trim()
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If

        'Fran 27/11/2009 i chamado 527 Maracanau
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        'Fran 27/11/2009 f chamado 527 Maracanau

        loadData()

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 83
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            'Fran 27/11/2009 i chamado 527 Maracanau
            'Response.Redirect("frm_Analise_excel.aspx?dt_fim=" + ViewState.Item("dt_fim").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString)
            'Response.Redirect("frm_Analise_excel.aspx?dt_fim=" + ViewState.Item("dt_fim").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString)
            Response.Redirect("frm_relatorio_conferencia_romaneio_excel.aspx?dt_fim=" + ViewState.Item("dt_fim").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString) 'fran 08/2015
            'Fran 27/11/2009 f chamado 527 Maracanau
        Else
            messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")  ' Adri
        End If
        'fran 01/04/2009 f
    End Sub








End Class

