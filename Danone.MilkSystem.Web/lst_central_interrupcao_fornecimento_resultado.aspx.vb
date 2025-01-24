Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class lst_central_interrupcao_fornecimento_resultado

    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_interrupcao_fornecimento_resultado.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim statuspreconegociado As New StatusPrecoNegociado



            ViewState.Item("sortExpression") = ""

            If Not (Request("id_execucao") Is Nothing) Then
                ViewState.Item("id_execucao") = Request("id_execucao")
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


            intfornec.id_execucao = Convert.ToInt32(ViewState.Item("id_execucao").ToString)
            Dim dsResultado As DataSet = intfornec.getInterrupcaoFornecimentoByFilters


            If (dsResultado.Tables(0).Rows.Count > 0) Then
                'lbl_dt_referencia.Text = Mid(dsResultado.Tables(0).Rows(0).Item("dt_referencia").ToString, 4, 7)
                lbl_dt_referencia.Text = DateTime.Parse(dsResultado.Tables(0).Rows(0).Item("dt_referencia")).ToString("MM/yyyy")  ' Adri 25/10/2010
                lbl_id_execucao.Text = ViewState.Item("id_execucao").ToString
                lbl_produtor.Text = dsResultado.Tables(0).Rows(0).Item("ds_produtor").ToString
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsResultado.Tables(0), ViewState.Item("sortExpression"))
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

            Case "ds_propriedade"
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

            Dim id_central_interrupcao_resultado As Label = CType(e.Row.FindControl("id_central_interrupcao_resultado"), Label)
            Dim hl_resultado As HyperLink = CType(e.Row.FindControl("hl_resultado"), HyperLink)

            If id_central_interrupcao_resultado.Text.Trim.Equals("2") Then 'se movimentos em aberto
                hl_resultado.NavigateUrl = String.Format("frm_central_interrupcao_fornec_movimentos.aspx?id_central_interrupcao_fornecimento={0}", gridResults.DataKeys.Item(e.Row.RowIndex).Value) & String.Format("&id_execucao={0}", ViewState.Item("id_execucao").ToString)
                hl_resultado.ToolTip = "Visualizar Movimentos em Aberto para Propriedade/UP"
            Else
                hl_resultado.NavigateUrl = String.Format("frm_central_interrupcao_fornec_resumo.aspx?id_central_interrupcao_fornecimento={0}", gridResults.DataKeys.Item(e.Row.RowIndex).Value) & String.Format("&id_execucao={0}", ViewState.Item("id_execucao").ToString)
                hl_resultado.ToolTip = "Visualizar Resumo Financeiro para Propriedade/UP"
            End If

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_central_interrupcao_fornecimento.aspx")

    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_central_interrupcao_fornecimento.aspx")

    End Sub
End Class
