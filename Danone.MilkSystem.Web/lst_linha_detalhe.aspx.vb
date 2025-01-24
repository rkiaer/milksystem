Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_linha_detalhe
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        loadData()

    End Sub

 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_linha.aspx")
        If Not Page.IsPostBack Then

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            If Not (Request("id_linha") Is Nothing) Then
                ViewState.Item("id_linha") = Request("id_linha")
            End If


            Dim status As New Situacao

            Dim id_linha As Int32 = Convert.ToInt32(ViewState.Item("id_linha"))
            Dim linha As New Linha(id_linha)

            lbl_linha.Text = Convert.ToString(linha.id_linha) + "-" + linha.nm_linha
            lbl_estabelecimento.Text = linha.cd_estabelecimento + "-" + linha.nm_estabelecimento

           
            ViewState.Item("sortExpression") = "nr_seq_coleta asc"

            If Not (Request("id_linha") Is Nothing) Then
                ViewState.Item("id_linha") = Request("id_linha")

                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim linhaitens As New LinhaItens

            linhaitens.id_linha = Convert.ToInt32(ViewState.Item("id_linha"))
            linhaitens.dia_impar_par = 1 'sempre mandar impar

            Dim dsLinhaItens As DataSet = linhaitens.getLinhaItensByFilters()

            If (dsLinhaItens.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsLinhaItens.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Não há dados para a linha.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "nr_seq_coleta"
                If (ViewState.Item("sortExpression")) = "id_linha asc" Then
                    ViewState.Item("sortExpression") = "id_linha desc"
                Else
                    ViewState.Item("sortExpression") = "id_linha asc"
                End If

        End Select

        loadData()

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        'saveFilters()
        'Response.Redirect("frm_linha.aspx?id_linha=" + ViewState.Item("id_linha"))
        Response.Redirect("lst_linha.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
End Class
