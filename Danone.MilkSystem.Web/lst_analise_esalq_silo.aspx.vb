Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_analise_esalq_silo

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("nr_silo") = txt_nr_silo.Text.Trim()
        ViewState.Item("txt_dt_coleta_ini") = Me.txt_dt_coleta_ini.Text.Trim
        ViewState.Item("txt_dt_coleta_fim") = Me.txt_dt_coleta_fim.Text.Trim
        If (Me.txt_dt_coleta_fim.Text.Trim) = "" Then
            ViewState.Item("txt_dt_coleta_fim") = Me.txt_dt_coleta_ini.Text.Trim
        End If
        ViewState.Item("cd_analise_esalq") = Me.cbo_codigo_esalq.SelectedValue()
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_analise_esalq_silo.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_analise_esalq_silo.aspx")

        If Not Page.IsPostBack Then
            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim codigoesalq As New CodigoEsalq

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            'fran 29/11/2009 i chamado 523 Maracanau
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'fran 29/11/2009 f chamado 523 Maracanau
            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_codigo_esalq.DataSource = codigoesalq.getCodigosEsalqByFilters()
            cbo_codigo_esalq.DataTextField = "ds_analise_esalq"
            cbo_codigo_esalq.DataValueField = "cd_analise_esalq"
            cbo_codigo_esalq.DataBind()
            cbo_codigo_esalq.Items.Insert(0, New ListItem("[Selecione]", "0"))


            txt_dt_coleta_ini.Text = "01/" & DateTime.Parse(Now).ToString("MM/yyyy")
            txt_dt_coleta_fim.Text = "01/" & DateTime.Parse(DateAdd(DateInterval.Month, 1, Convert.ToDateTime(txt_dt_coleta_ini.Text))).ToString("MM/yyyy")

            ViewState.Item("sortExpression") = "nr_silo asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("aesalq_silo", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("aesalq_silo", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("aesalq_silo", txt_nr_silo.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_silo") = customPage.getFilterValue("aesalq_silo", txt_nr_silo.ID)
            txt_nr_silo.Text = ViewState.Item("nr_silo").ToString()
        Else
            ViewState.Item("nr_silo") = String.Empty
        End If


        If Not (customPage.getFilterValue("aesalq_silo", txt_dt_coleta_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_coleta_ini") = customPage.getFilterValue("aesalq_silo", txt_dt_coleta_ini.ID)
            txt_dt_coleta_ini.Text = ViewState.Item("txt_dt_coleta_ini").ToString()
        Else
            ViewState.Item("txt_dt_coleta_ini") = String.Empty
        End If

        If Not (customPage.getFilterValue("aesalq_silo", txt_dt_coleta_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_coleta_fim") = customPage.getFilterValue("aesalq_silo", txt_dt_coleta_fim.ID)
            txt_dt_coleta_fim.Text = ViewState.Item("txt_dt_coleta_fim").ToString()
        Else
            ViewState.Item("txt_dt_coleta_fim") = String.Empty
        End If

        If Not (customPage.getFilterValue("aesalq_silo", cbo_codigo_esalq.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_analise_esalq") = customPage.getFilterValue("aesalq_silo", cbo_codigo_esalq.ID)
            cbo_codigo_esalq.Text = ViewState.Item("cd_analise_esalq").ToString()
        Else
            ViewState.Item("cd_analise_esalq") = String.Empty
        End If

        If Not (customPage.getFilterValue("aesalq_silo", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("aesalq_silo", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("aesalq_silo", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("aesalq_silo", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("aesalq_silo")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim analiseesalq As New AnaliseEsalq

            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            If Trim(ViewState.Item("nr_silo")) <> "" Then
                analiseesalq.nr_silo = Convert.ToInt32(ViewState.Item("nr_silo").ToString)
            End If
            analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta_ini").ToString
            analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta_fim").ToString
            analiseesalq.cd_analise_esalq = Convert.ToInt32(ViewState.Item("cd_analise_esalq").ToString())
            Dim dsAnaliseEsalc As DataSet = analiseesalq.getAnaliseEsalqSiloByFilters()

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


            Case "id_estabelecimento"
                If (ViewState.Item("sortExpression")) = "id_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "id_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "id_estabelecimento asc"
                End If

            Case "nr_silo"
                If (ViewState.Item("sortExpression")) = "nr_silo asc" Then
                    ViewState.Item("sortExpression") = "nr_silo desc"
                Else
                    ViewState.Item("sortExpression") = "nr_silo asc"
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

            Case "cd_analise_esalq"
                If (ViewState.Item("sortExpression")) = "ds_analise_esalq asc" Then
                    ViewState.Item("sortExpression") = "ds_analise_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "cd_analise_esalq asc"
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


            customPage.setFilter("analise_esaq_silo", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("analise_esaq_silo", txt_nr_silo.ID, ViewState.Item("nr_silo").ToString)
            customPage.setFilter("analise_esaq_silo", txt_dt_coleta_ini.ID, ViewState.Item("txt_dt_coleta_ini").ToString)
            customPage.setFilter("analise_esaq_silo", txt_dt_coleta_fim.ID, ViewState.Item("txt_dt_coleta_fim").ToString)
            customPage.setFilter("analise_esaq_silo", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("analise_esaq_silo", cbo_codigo_esalq.ID, ViewState.Item("cd_analise_esalq").ToString)
            customPage.setFilter("analise_esaq_silo", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_analise_esalq_silo.aspx?id_analise_esalq=" + e.CommandArgument.ToString())

            Case "delete"
                deleteAnaliseEsalqSilo(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteAnaliseEsalqSilo(ByVal id_analise_esalq_silo As Integer)

        Try
            Dim analiseesalq As New AnaliseEsalq()
            analiseesalq.id_analise_esalq_silo = id_analise_esalq_silo
            analiseesalq.id_modificador = Convert.ToInt32(Session("id_login"))
            analiseesalq.deleteAnaliseEsalqSilo()
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

            Dim id_situacao As Label = CType(e.Row.FindControl("id_situacao"), Label)
            Dim img_delete As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)

            If id_situacao.Text.Trim = "1" Then
                img_delete.ImageUrl = "~/img/icone_excluir.gif"
                img_delete.Enabled = True
            Else
                img_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                img_delete.Enabled = False
            End If

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        'Me.txt_nr_silo.Text = ""

    End Sub

End Class
