Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_custo_financeiro_calculo_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try


            If (Not Request("id_execucao") Is Nothing) Then
                ViewState.Item("id_calculo_execucao") = Request("id_execucao")
            Else
                ViewState.Item("id_calculo_execucao") = 0
            End If

            Dim custo As New CustoFinanceiro
            custo.id_custo_financeiro_calculo_execucao = ViewState.Item("id_calculo_execucao").ToString

            Dim dscustopreco As DataSet = custo.getCustoFinanceiroCalculo
            If (dscustopreco.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscustopreco.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

            Else
                gridResults.Visible = False
            End If



            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                Dim tw As New StringWriter()
                Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                Dim frm As HtmlForm = New HtmlForm()

                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_CustoFinanceiroCalculo_" & ViewState.Item("id_calculo_execucao").ToString & ".xls")

                Response.Charset = ""
                EnableViewState = False
                Controls.Add(frm)
                frm.Controls.Add(gridResults)

                frm.RenderControl(hw)
                Response.Write(tw.ToString())

                Response.End()
                Response.Flush()
                gridResults.AllowPaging = "True"
                gridResults.DataBind()
            End If


        Catch ex As Exception

            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        Try

            If (e.Row.RowType <> DataControlRowType.Header _
                And e.Row.RowType <> DataControlRowType.Footer _
                And e.Row.RowType <> DataControlRowType.Pager) Then

                'Dim lbl_seq As Label = CType(e.Row.FindControl("lbl_seq"), Label)

                'e.Row.Cells(0).Font.Bold = True
                'e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center

                'Select Case CInt(lbl_seq.Text)

                '    Case 1, 7, 14, 21
                '        e.Row.Cells(0).Text = "PRODUTORES"
                '        e.Row.Cells(1).Text = "Preço"
                '    Case 2
                '        e.Row.Cells(0).Text = "CPM"
                '        e.Row.Cells(1).Text = "Inc Prod Leite 2,5%"
                '    Case 3, 10, 17, 24, 30, 57
                '        e.Row.Cells(1).Text = "PIS&COFINS"
                '    Case 4, 11, 18, 25, 31, 36, 58
                '        e.Row.Cells(1).Text = "ICMS"
                '    Case 5, 12, 19, 26
                '        e.Row.Cells(1).Text = "Frete T1"
                '    Case 6, 13, 20, 27, 33, 38, 60
                '        e.Row.Cells(1).Text = "Custo"

                '    Case 8
                '        e.Row.Cells(0).Text = "NEGO. GERENCIAL"
                '        e.Row.Cells(1).Text = "Qualidade"
                '    Case 9, 16, 23, 56
                '        e.Row.Cells(1).Text = "Inc Prod Leite 2,5%"
                '    Case 15
                '        e.Row.Cells(0).Text = "CONTRATO"
                '        e.Row.Cells(1).Text = "Qualidade"
                '    Case 22
                '        e.Row.Cells(0).Text = "MERCADO"
                '        e.Row.Cells(1).Text = "Qualidade"
                '    Case 28, 34
                '        e.Row.Cells(0).Text = "COOPERATIVAS"
                '        e.Row.Cells(1).Text = "Preço"
                '    Case 29
                '        e.Row.Cells(0).Text = "CONTRATO"
                '        e.Row.Cells(1).Text = "Qualidade"
                '    Case 32, 37
                '        e.Row.Cells(1).Text = "Frete T2"
                '    Case 35
                '        e.Row.Cells(0).Text = "SPOT"
                '        e.Row.Cells(1).Text = "PIS&COFINS"

                '    Case 54
                '        e.Row.Cells(0).Text = "PREÇO MÉDIO"
                '        e.Row.Cells(1).Text = "Preço"
                '    Case 55
                '        e.Row.Cells(1).Text = "Qualidade"
                '    Case 59
                '        e.Row.Cells(1).Text = "Frete"

                'End Select



            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
End Class
