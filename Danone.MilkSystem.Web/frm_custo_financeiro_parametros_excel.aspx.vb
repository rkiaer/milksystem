Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_custo_financeiro_parametros_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try


            If (Not Request("nr_ano") Is Nothing) Then
                ViewState.Item("nr_ano") = Request("nr_ano")
            Else
                ViewState.Item("nr_ano") = 0
            End If

            Dim custo As New CustoFinanceiro

            custo.nr_ano = ViewState.Item("nr_ano")

            Dim dscusto As DataSet = custo.getCustoFinanceiroByFilters()

            If (dscusto.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscusto.Tables(0), "")
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If




            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                Dim tw As New StringWriter()
                Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                Dim frm As HtmlForm = New HtmlForm()

                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_CustoFinanceiroParametros_" & ViewState.Item("nr_ano").ToString & ".xls")

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

            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(3).Text = String.Concat("JAN/", ViewState.Item("nr_ano").ToString)
                e.Row.Cells(4).Text = String.Concat("FEV/", ViewState.Item("nr_ano").ToString)
                e.Row.Cells(5).Text = String.Concat("MAR/", ViewState.Item("nr_ano").ToString)
                e.Row.Cells(6).Text = String.Concat("ABR/", ViewState.Item("nr_ano").ToString)
                e.Row.Cells(7).Text = String.Concat("MAI/", ViewState.Item("nr_ano").ToString)
                e.Row.Cells(8).Text = String.Concat("JUN/", ViewState.Item("nr_ano").ToString)
                e.Row.Cells(9).Text = String.Concat("JUL/", ViewState.Item("nr_ano").ToString)
                e.Row.Cells(10).Text = String.Concat("AGO/", ViewState.Item("nr_ano").ToString)
                e.Row.Cells(11).Text = String.Concat("SET/", ViewState.Item("nr_ano").ToString)
                e.Row.Cells(12).Text = String.Concat("OUT/", ViewState.Item("nr_ano").ToString)
                e.Row.Cells(13).Text = String.Concat("NOV/", ViewState.Item("nr_ano").ToString)
                e.Row.Cells(14).Text = String.Concat("DEZ/", ViewState.Item("nr_ano").ToString)
            End If

            If (e.Row.RowType <> DataControlRowType.Header _
                And e.Row.RowType <> DataControlRowType.Footer _
                And e.Row.RowType <> DataControlRowType.Pager) Then

                Dim mes1 As DataControlFieldCell = CType(e.Row.Cells.Item(3), DataControlFieldCell)
                Dim mes2 As DataControlFieldCell = CType(e.Row.Cells.Item(4), DataControlFieldCell)
                Dim mes3 As DataControlFieldCell = CType(e.Row.Cells.Item(5), DataControlFieldCell)
                Dim mes4 As DataControlFieldCell = CType(e.Row.Cells.Item(6), DataControlFieldCell)
                Dim mes5 As DataControlFieldCell = CType(e.Row.Cells.Item(7), DataControlFieldCell)
                Dim mes6 As DataControlFieldCell = CType(e.Row.Cells.Item(8), DataControlFieldCell)
                Dim mes7 As DataControlFieldCell = CType(e.Row.Cells.Item(9), DataControlFieldCell)
                Dim mes8 As DataControlFieldCell = CType(e.Row.Cells.Item(10), DataControlFieldCell)
                Dim mes9 As DataControlFieldCell = CType(e.Row.Cells.Item(11), DataControlFieldCell)
                Dim mes10 As DataControlFieldCell = CType(e.Row.Cells.Item(12), DataControlFieldCell)
                Dim mes11 As DataControlFieldCell = CType(e.Row.Cells.Item(13), DataControlFieldCell)
                Dim mes12 As DataControlFieldCell = CType(e.Row.Cells.Item(14), DataControlFieldCell)
                Dim lbl_id_conta As Label = CType(e.Row.FindControl("lbl_id_conta"), Label)

                Dim lbl_id_tipo_custo_financeiro As Label = CType(e.Row.FindControl("lbl_id_tipo_custo_financeiro"), Label)

                Select Case CInt(lbl_id_tipo_custo_financeiro.Text)

                    Case 4, 19 ' necessidade de leite e volume de coop e
                        If (Not mes1.Text.Equals(String.Empty) And Not mes1.Text = "&nbsp;") Then
                            mes1.Text = FormatNumber(mes1.Text, 0).ToString()
                        End If
                        If (Not mes2.Text.Equals(String.Empty) And Not mes2.Text = "&nbsp;") Then
                            mes2.Text = FormatNumber(mes2.Text, 0).ToString()
                        End If
                        If (Not mes3.Text.Equals(String.Empty) And Not mes3.Text = "&nbsp;") Then
                            mes3.Text = FormatNumber(mes3.Text, 0).ToString()
                        End If
                        If (Not mes4.Text.Equals(String.Empty) And Not mes4.Text = "&nbsp;") Then
                            mes4.Text = FormatNumber(mes4.Text, 0).ToString()
                        End If
                        If (Not mes5.Text.Equals(String.Empty) And Not mes5.Text = "&nbsp;") Then
                            mes5.Text = FormatNumber(mes5.Text, 0).ToString()
                        End If
                        If (Not mes6.Text.Equals(String.Empty) And Not mes6.Text = "&nbsp;") Then
                            mes6.Text = FormatNumber(mes6.Text, 0).ToString()
                        End If
                        If (Not mes7.Text.Equals(String.Empty) And Not mes7.Text = "&nbsp;") Then
                            mes7.Text = FormatNumber(mes7.Text, 0).ToString()
                        End If
                        If (Not mes8.Text.Equals(String.Empty) And Not mes8.Text = "&nbsp;") Then
                            mes8.Text = FormatNumber(mes8.Text, 0).ToString()
                        End If
                        If (Not mes9.Text.Equals(String.Empty) And Not mes9.Text = "&nbsp;") Then
                            mes9.Text = FormatNumber(mes9.Text, 0).ToString()
                        End If
                        If (Not mes10.Text.Equals(String.Empty) And Not mes10.Text = "&nbsp;") Then
                            mes10.Text = FormatNumber(mes10.Text, 0).ToString()
                        End If
                        If (Not mes11.Text.Equals(String.Empty) And Not mes11.Text = "&nbsp;") Then
                            mes11.Text = FormatNumber(mes11.Text, 0).ToString()
                        End If
                        If (Not mes12.Text.Equals(String.Empty) And Not mes12.Text = "&nbsp;") Then
                            mes12.Text = FormatNumber(mes12.Text, 0).ToString()
                        End If


                End Select

                If e.Row.Cells(1).Text = "N" Then
                    If (Not mes1.Text.Equals(String.Empty) And Not mes1.Text = "&nbsp;") Then
                        mes1.Text = FormatNumber(mes1.Text, 2).ToString()
                    End If
                    If (Not mes2.Text.Equals(String.Empty) And Not mes2.Text = "&nbsp;") Then
                        mes2.Text = FormatNumber(mes2.Text, 2).ToString()
                    End If
                    If (Not mes3.Text.Equals(String.Empty) And Not mes3.Text = "&nbsp;") Then
                        mes3.Text = FormatNumber(mes3.Text, 2).ToString()
                    End If
                    If (Not mes4.Text.Equals(String.Empty) And Not mes4.Text = "&nbsp;") Then
                        mes4.Text = FormatNumber(mes4.Text, 2).ToString()
                    End If
                    If (Not mes5.Text.Equals(String.Empty) And Not mes5.Text = "&nbsp;") Then
                        mes5.Text = FormatNumber(mes5.Text, 2).ToString()
                    End If
                    If (Not mes6.Text.Equals(String.Empty) And Not mes6.Text = "&nbsp;") Then
                        mes6.Text = FormatNumber(mes6.Text, 2).ToString()
                    End If
                    If (Not mes7.Text.Equals(String.Empty) And Not mes7.Text = "&nbsp;") Then
                        mes7.Text = FormatNumber(mes7.Text, 2).ToString()
                    End If
                    If (Not mes8.Text.Equals(String.Empty) And Not mes8.Text = "&nbsp;") Then
                        mes8.Text = FormatNumber(mes8.Text, 2).ToString()
                    End If
                    If (Not mes9.Text.Equals(String.Empty) And Not mes9.Text = "&nbsp;") Then
                        mes9.Text = FormatNumber(mes9.Text, 2).ToString()
                    End If
                    If (Not mes10.Text.Equals(String.Empty) And Not mes10.Text = "&nbsp;") Then
                        mes10.Text = FormatNumber(mes10.Text, 2).ToString()
                    End If
                    If (Not mes11.Text.Equals(String.Empty) And Not mes11.Text = "&nbsp;") Then
                        mes11.Text = FormatNumber(mes11.Text, 2).ToString()
                    End If
                    If (Not mes12.Text.Equals(String.Empty) And Not mes12.Text = "&nbsp;") Then
                        mes12.Text = FormatNumber(mes12.Text, 2).ToString()
                    End If
                End If
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
End Class
