Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_central_interrupcao_fornec_movimentos

    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_central_interrupcao_fornec_movimentos.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            ViewState.Item("sortExpression") = ""

            If Not (Request("id_central_interrupcao_fornecimento") Is Nothing) Then
                ViewState.Item("id_central_interrupcao_fornecimento") = Request("id_central_interrupcao_fornecimento")
                loadData()
            Else
                messageControl.Alert("Há problemas na passagem de parametros. A tela não pode ser montada!")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim intfornec As New InterrupcaoFornecimento


            intfornec.id_central_interrupcao_fornecimento = Convert.ToInt32(ViewState.Item("id_central_interrupcao_fornecimento").ToString)

            Dim dsDetalhesTela As DataSet = intfornec.getInterrupcaoFornecimentoByFilters

            If dsDetalhesTela.Tables(0).Rows.Count > 0 Then
                With dsDetalhesTela.Tables(0).Rows(0)
                    lbl_dt_referencia.Text = DateTime.Parse(.Item("dt_referencia").ToString).ToString("MM/yyyy")
                    lbl_produtor.Text = .Item("ds_produtor").ToString
                    lbl_id_execucao.Text = .Item("id_execucao").ToString
                    ViewState.Item("id_execucao") = .Item("id_execucao").ToString
                    intfornec.id_propriedade = Convert.ToInt32(.Item("id_propriedade").ToString)
                    intfornec.id_unid_producao = Convert.ToInt32(.Item("id_unid_producao").ToString)
                    intfornec.dt_referencia = DateTime.Parse(.Item("dt_referencia").ToString).ToString("dd/MM/yyyy")

                End With
            End If

            Dim dsmovimentos As DataSet = intfornec.getMovimentosAbertosByPropriedade

            If (dsmovimentos.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsmovimentos.Tables(0), "")
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado.")
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

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If


        End Select

        loadData()

    End Sub



    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then


        End If
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_central_interrupcao_fornecimento_resultado.aspx?id_execucao=" & ViewState.Item("id_execucao").ToString)
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_central_interrupcao_fornecimento_resultado.aspx?id_execucao=" & ViewState.Item("id_execucao").ToString)
    End Sub
End Class
