Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_gold_custo_produtor_operacional_item
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        ViewState.Item("nm_gold_custo_produtor_operacional_item") = txt_nm_gold_custo_produtor_operacional_item.Text

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_gold_custo_produtor_operacional_item.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_gold_custo_produtor_operacional_item.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try


            Dim status As New Situacao

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.SelectedValue = 1

            ViewState.Item("sortExpression") = "nm_gold_custo_produtor_operacional_item asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean



        If Not (customPage.getFilterValue("ItemCusto", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("ItemCusto", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("ItemCusto", txt_nm_gold_custo_produtor_operacional_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_gold_custo_produtor_operacional_item") = customPage.getFilterValue("ItemCusto", txt_nm_gold_custo_produtor_operacional_item.ID)
            txt_nm_gold_custo_produtor_operacional_item.Text = ViewState.Item("nm_gold_custo_produtor_operacional_item").ToString()
        Else
            ViewState.Item("nm_gold_custo_produtor_operacional_item") = String.Empty
        End If


        If Not (customPage.getFilterValue("ItemCusto", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("ItemCusto", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("faixa")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim goldcustoprodutoroperacionalitem As New GoldCustoProdutorOperacionalItem


            goldcustoprodutoroperacionalitem.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            goldcustoprodutoroperacionalitem.nm_gold_custo_produtor_operacional_item = txt_nm_gold_custo_produtor_operacional_item.Text

            Dim dsItemCusto As DataSet = goldcustoprodutoroperacionalitem.getGoldCustoProdutorOperacionalItemByFilters()

            If (dsItemCusto.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsItemCusto.Tables(0), ViewState.Item("sortExpression"))
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

            Case "nm_gold_custo_produtor_operacional_item"
                If (ViewState.Item("sortExpression")) = "nm_gold_custo_produtor_operacional_item asc" Then
                    ViewState.Item("sortExpression") = "nm_gold_custo_produtor_operacional_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_gold_custo_produtor_operacional_item asc"
                End If
        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("ItemCusto", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("ItemCusto", txt_nm_gold_custo_produtor_operacional_item.ID, ViewState.Item("nm_gold_custo_produtor_operacional_item").ToString)
            Dim Teste As Object = gridResults.PageIndex.ToString()
            customPage.setFilter("ItemCusto", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_gold_custo_produtor_operacional_item.aspx?id_gold_custo_produtor_operacional_item=" + e.CommandArgument.ToString())

            Case "delete"
                deleteItemCusto(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteItemCusto(ByVal id_gold_custo_produtor_operacional_item As Integer)

        Try

            Dim goldcustoprodutoroperacionalitem As New GoldCustoProdutorOperacionalItem
            goldcustoprodutoroperacionalitem.id_gold_custo_produtor_operacional_item = id_gold_custo_produtor_operacional_item
            goldcustoprodutoroperacionalitem.id_modificador = Convert.ToInt32(Session("id_login"))
            goldcustoprodutoroperacionalitem.deleteGoldCustoProdutorOperacionalItem()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_gold_custo_produtor_operacional_item.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub
End Class
