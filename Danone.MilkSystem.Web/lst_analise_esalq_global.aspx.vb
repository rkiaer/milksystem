Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_analise_esalq_global

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        'fran 29/11/2009 i maracanau chamado 523
        ViewState.Item("id_estabelecimento") = Me.cbo_estabelecimento.SelectedValue
        'fran 29/11/2009 i maracanau chamado 523

        ViewState.Item("txt_dt_coleta_ini") = Me.txt_dt_coleta_ini.Text.Trim
        ViewState.Item("txt_dt_coleta_fim") = Me.txt_dt_coleta_fim.Text.Trim
        If (Me.txt_dt_coleta_fim.Text.Trim) = "" Then
            ViewState.Item("txt_dt_coleta_fim") = Me.txt_dt_coleta_ini.Text.Trim
        End If
        ViewState.Item("id_romaneio") = Me.txt_id_romaneio.Text
        ViewState.Item("ds_placa") = Me.txt_ds_placa.Text
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_analise_esalq_global.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_analise_esalq_global.aspx")

        If Not Page.IsPostBack Then
            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim codigoesalq As New CodigoEsalq

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'fran 29/11/2009 i maracanau chamado 523
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'fran 29/11/2009 i maracanau chamado 523

            txt_dt_coleta_ini.Text = "01/" & DateTime.Parse(Now).ToString("MM/yyyy")
            txt_dt_coleta_fim.Text = "01/" & DateTime.Parse(DateAdd(DateInterval.Month, 1, Convert.ToDateTime(txt_dt_coleta_ini.Text))).ToString("MM/yyyy")

            ViewState.Item("sortExpression") = "ds_placa asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("analise_esalq_global", txt_id_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("analise_esalq_global", txt_id_romaneio.ID)
            txt_id_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If
        'fran 29/11/2009 i maracanau chamado 523
        If Not (customPage.getFilterValue("analise_esalq_global", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("analise_esalq_global", cbo_estabelecimento.ID)
            cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        'fran 29/11/2009 f maracanau chamado 523

        If Not (customPage.getFilterValue("analise_esalq_global", txt_ds_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("analise_esalq_global", txt_ds_placa.ID)
            txt_ds_placa.Text = ViewState.Item("ds_placa").ToString()

        Else
            ViewState.Item("ds_placa") = String.Empty
        End If


        If Not (customPage.getFilterValue("analise_esalq_global", txt_dt_coleta_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_coleta_ini") = customPage.getFilterValue("analise_esalq_global", txt_dt_coleta_ini.ID)
            txt_dt_coleta_ini.Text = ViewState.Item("txt_dt_coleta_ini").ToString()
        Else
            ViewState.Item("txt_dt_coleta_ini") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq_global", txt_dt_coleta_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_coleta_fim") = customPage.getFilterValue("analise_esalq_global", txt_dt_coleta_fim.ID)
            txt_dt_coleta_fim.Text = ViewState.Item("txt_dt_coleta_fim").ToString()
        Else
            ViewState.Item("txt_dt_coleta_fim") = String.Empty
        End If


        If Not (customPage.getFilterValue("analise_esalq_global", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("analise_esalq_global", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("analise_esalq_global", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("analise_esalq_global", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("analise_esalq_global")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim analiseesalq As New AnaliseEsalq

            If Trim(ViewState.Item("id_romaneio")) <> "" Then
                analiseesalq.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            End If
            analiseesalq.ds_placa = ViewState.Item("ds_placa").ToString
            analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta_ini").ToString
            analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta_fim").ToString
            'fran 29/11/2009 i maracanau chamado 523
            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            'fran 29/11/2009 i maracanau chamado 523

            Dim dsAnaliseEsalc As DataSet = analiseesalq.getAnaliseEsalqGlobalByFilters()

            If (dsAnaliseEsalc.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsAnaliseEsalc.Tables(0), ViewState.Item("sortExpression"))
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


            Case "id_romaneio"
                If (ViewState.Item("sortExpression")) = "id_romaneio asc" Then
                    ViewState.Item("sortExpression") = "id_romaneio desc"
                Else
                    ViewState.Item("sortExpression") = "id_romaneio asc"
                End If


            Case "dt_coleta"
                If (ViewState.Item("sortExpression")) = "dt_coleta asc" Then
                    ViewState.Item("sortExpression") = "dt_coleta desc"
                Else
                    ViewState.Item("sortExpression") = "dt_coleta asc"
                End If


            Case "dt_processamento"
                If (ViewState.Item("sortExpression")) = "dt_processamento asc" Then
                    ViewState.Item("sortExpression") = "dt_processamento desc"
                Else
                    ViewState.Item("sortExpression") = "dt_processamento asc"
                End If

            Case "dt_analise"
                If (ViewState.Item("sortExpression")) = "dt_analise asc" Then
                    ViewState.Item("sortExpression") = "dt_analise desc"
                Else
                    ViewState.Item("sortExpression") = "dt_analise asc"
                End If


            Case "nr_valor_esalq"
                If (ViewState.Item("sortExpression")) = "nr_valor_esalq asc" Then
                    ViewState.Item("sortExpression") = "nr_valor_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "nr_valor_esalq asc"
                End If
        End Select

        loadData()

    End Sub
    Private Sub saveFilters()

        Try


            'fran 29/11/2009 i maracanau chamado 523
            customPage.setFilter("analise_esaq_global", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            'fran 29/11/2009 f maracanau chamado 523
            customPage.setFilter("analise_esaq_global", txt_id_romaneio.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("analise_esaq_global", txt_ds_placa.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("analise_esaq_global", txt_dt_coleta_ini.ID, ViewState.Item("txt_dt_coleta_ini").ToString)
            customPage.setFilter("analise_esaq_global", txt_dt_coleta_fim.ID, ViewState.Item("txt_dt_coleta_fim").ToString)
            customPage.setFilter("analise_esaq_global", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("analise_esaq_global", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "delete"
                deleteAnaliseEsalqGlobal(Convert.ToInt32(e.CommandArgument.ToString()))     ' 10/12/2008

        End Select

    End Sub

    Private Sub deleteAnaliseEsalqGlobal(ByVal id_analise_esalq As Integer)

        Try
            Dim analiseesalq As New AnaliseEsalq()
            'fran 29/11/2009 i maracanau chamado 523
            'analiseesalq.id_analise_esalq = id_analise_esalq
            analiseesalq.id_analise_esalq_global = id_analise_esalq
            'fran 29/11/2009 f maracanau chamado 523
            analiseesalq.id_modificador = Convert.ToInt32(Session("id_login"))
            analiseesalq.deleteAnaliseEsalqGlobal()     ' 10/12/2008
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


        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub



End Class
