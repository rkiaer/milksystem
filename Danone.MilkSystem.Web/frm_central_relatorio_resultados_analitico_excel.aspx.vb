Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_central_relatorio_resultados_analitico_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            End If

            If Not (Request("dt_referencia") Is Nothing) Then
                ViewState.Item("dt_referencia") = Request("dt_referencia")
            End If

            Try
                Dim pedido As New Pedido
                If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                    pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
                End If
                If Not (ViewState("dt_referencia").ToString().Equals(String.Empty)) Then
                    pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/01/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
                    pedido.dt_fim = Convert.ToDateTime(String.Concat("01/01/", (CInt(ViewState.Item("dt_referencia")) + 1).ToString)).ToString("dd/MM/yyyy")
                End If

                Dim dsresultados As DataSet = pedido.getCentralRelatorioResultadosAnalitico

                If (dsresultados.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsresultados.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()

                End If

                gridResults.AllowPaging = False

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "CentralComprasResultadosAnalitico_" & ViewState.Item("dt_referencia").ToString & "_" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".xls")

                        Response.Charset = ""
                        EnableViewState = False
                        Controls.Add(frm)
                        frm.Controls.Add(gridResults)
                        frm.RenderControl(hw)
                        Response.Write(tw.ToString())
                        Response.End()
                        gridResults.AllowPaging = "True"
                        gridResults.DataBind()
                    Else

                        messageControl.Alert("Não há linhas a serem exportadas!")
                    End If


                Else

                    messageControl.Alert(" Planilha possui muitas linhas, não é possível exportar para o Excel")

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            'Dim lbl_comprasnf As Label = CType(e.Row.FindControl("lbl_comprasnf"), Label)
            'Dim lbl_id_ficha_central As Label = CType(e.Row.FindControl("lbl_id_ficha_central"), Label)

            'If lbl_id_ficha_central.Text = String.Empty Then
            '    lbl_comprasnf.Text = "N"
            'Else
            '    lbl_comprasnf.Text = "S"

            'End If


        End If

    End Sub
End Class
