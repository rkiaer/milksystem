Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_gold_custo

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("dt_referencia_inicial") = Me.txt_dt_referencia_inicial.Text()
            ViewState.Item("dt_referencia_final") = Me.txt_dt_referencia_final.Text()
            ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

            loadData()
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_gold_custo.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_gold_custo.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim status As New Situacao

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()

            ViewState.Item("sortExpression") = "dt_referencia_inicial desc"

            loadFilters()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("gold_custo", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("gold_custo", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("gold_custo", txt_dt_referencia_inicial.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia_inicial") = customPage.getFilterValue("gold_custo", txt_dt_referencia_inicial.ID)
            txt_dt_referencia_inicial.Text = ViewState.Item("dt_referencia_inicial").ToString()
        Else
            ViewState.Item("dt_referencia_inicial") = String.Empty
        End If


        If Not (customPage.getFilterValue("gold_custo", txt_dt_referencia_final.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia_final") = customPage.getFilterValue("gold_custo", txt_dt_referencia_final.ID)
            txt_dt_referencia_final.Text = ViewState.Item("dt_referencia_final").ToString()
        Else
            ViewState.Item("dt_referencia_final") = String.Empty
        End If


        If Not (customPage.getFilterValue("gold_custo", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("gold_custo", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("gold_custo", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("gold_custo", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("gold_custo")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim goldcusto As New GoldCusto

            goldcusto.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            If ViewState("dt_referencia_inicial").ToString <> "" Then
                goldcusto.dt_referencia_inicial = String.Concat("01/" & ViewState("dt_referencia_inicial").ToString)
            End If
            If ViewState("dt_referencia_final").ToString <> "" Then
                goldcusto.dt_referencia_final = String.Concat("01/" & ViewState("dt_referencia_final").ToString)
            End If

            If Trim(ViewState.Item("id_situacao")) <> "" Then
                goldcusto.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            End If

            Dim dsGoldCusto As DataSet = goldcusto.getGoldCustoByFilters()

            If (dsGoldCusto.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsGoldCusto.Tables(0), ViewState.Item("sortExpression"))
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


            Case "dt_referencia_inicial"
                If (ViewState.Item("sortExpression")) = "dt_referencia_inicial asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia_inicial desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia_inicial asc"
                End If

            Case "dt_referencia_final"
                If (ViewState.Item("sortExpression")) = "dt_referencia_final asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia_final desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia_final asc"
                End If


        End Select

        loadData()

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("gold_custo", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("gold_custo", txt_dt_referencia_inicial.ID, ViewState.Item("dt_referencia_inicial").ToString)
            customPage.setFilter("gold_custo", txt_dt_referencia_final.ID, ViewState.Item("dt_referencia_final").ToString)
            customPage.setFilter("gold_custo", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("gold_custo", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_gold_custo.aspx?id_gold_custo=" + e.CommandArgument.ToString())
            Case "delete"
                deleteGoldCusto(e.CommandArgument.ToString())

        End Select

    End Sub

    Private Sub deleteGoldCusto(ByVal id_gold_custo As String)

        Try

            Dim goldcusto As New GoldCusto()
            goldcusto.id_gold_custo = Convert.ToInt32(id_gold_custo)
            goldcusto.id_modificador = Convert.ToInt32(Session("id_login"))
            goldcusto.deleteGoldCusto()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_gold_custo.aspx")
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


End Class
