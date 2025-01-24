﻿Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_custo_financeiro_flash_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try


            If (Not Request("nr_ano") Is Nothing) Then
                ViewState.Item("nr_ano") = Request("nr_ano")
            Else
                ViewState.Item("nr_ano") = 0
            End If
            If (Not Request("id_execucao") Is Nothing) Then
                ViewState.Item("id_calculo_execucao") = Request("id_execucao")
            Else
                ViewState.Item("id_calculo_execucao") = 0
            End If
            If (Not Request("mesprovisorio") Is Nothing) Then
                ViewState.Item("mesprovisorio") = Request("mesprovisorio")
            Else
                ViewState.Item("mesprovisorio") = 0
            End If

            Dim custo As New CustoFinanceiro
            custo.nr_ano = ViewState.Item("nr_ano").ToString
            custo.id_custo_financeiro_calculo_execucao = ViewState.Item("id_calculo_execucao").ToString
            custo.dt_referencia_ini = DateTime.Parse(String.Concat("01/01/", ViewState.Item("nr_ano").ToString)).ToString("dd/MM/yyyy")
            custo.dt_referencia_fim = DateTime.Parse(String.Concat("01/12/", ViewState.Item("nr_ano").ToString)).ToString("dd/MM/yyyy")

            Dim lmesprovisorio As Integer = CInt(ViewState.Item("mesprovisorio").ToString) + 1

            Dim dscustopreco As DataSet = custo.getCustoFinanceiroRelatorioPreco
            If (dscustopreco.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscustopreco.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                gridResults.Rows(5).BackColor = Drawing.Color.LightCyan
                gridResults.Rows(5).Font.Bold = True
                gridResults.Rows(12).BackColor = Drawing.Color.LightCyan
                gridResults.Rows(12).Font.Bold = True
                gridResults.Rows(19).BackColor = Drawing.Color.LightCyan
                gridResults.Rows(19).Font.Bold = True
                gridResults.Rows(26).BackColor = Drawing.Color.LightCyan
                gridResults.Rows(26).Font.Bold = True
                gridResults.Rows(32).BackColor = Drawing.Color.LightCyan
                gridResults.Rows(32).Font.Bold = True
                gridResults.Rows(37).BackColor = Drawing.Color.LightCyan
                gridResults.Rows(37).Font.Bold = True

                gridResults.Rows(39).BackColor = Drawing.Color.LightBlue
                gridResults.Rows(40).BackColor = Drawing.Color.LightBlue
                gridResults.Rows(41).BackColor = Drawing.Color.LightBlue
                gridResults.Rows(42).BackColor = Drawing.Color.LightBlue
                gridResults.Rows(43).BackColor = Drawing.Color.LightBlue
                gridResults.Rows(44).BackColor = Drawing.Color.LightBlue
                gridResults.Rows(45).BackColor = Drawing.Color.LightBlue
                gridResults.Rows(45).Font.Bold = True

            Else
                gridResults.Visible = False
            End If


            Dim dscustovolume As DataSet = custo.getCustoFinanceiroRelatorioVolume()
            If (dscustovolume.Tables(0).Rows.Count > 0) Then
                gridVolume.Visible = True
                gridVolume.DataSource = Helper.getDataView(dscustovolume.Tables(0), ViewState.Item("sortExpression"))
                gridVolume.DataBind()
                gridVolume.Rows(4).BackColor = Drawing.Color.Aquamarine
                gridVolume.Rows(8).BackColor = Drawing.Color.Aquamarine
                gridVolume.Rows(10).BackColor = Drawing.Color.Aquamarine
                gridVolume.Rows(4).Font.Bold = True
                gridVolume.Rows(8).Font.Bold = True
                gridVolume.Rows(10).Font.Bold = True
                gridVolume.Rows(11).Font.Bold = True
            Else
                gridVolume.Visible = False
            End If

            Dim dscustooutroscustos As DataSet = custo.getCustoFinanceiroRelatorioOutrosCustos
            If (dscustooutroscustos.Tables(0).Rows.Count > 0) Then
                ViewState.Item("rowmedido") = 0

                gridOutrosCustos.Visible = True
                gridOutrosCustos.DataSource = Helper.getDataView(dscustooutroscustos.Tables(0), ViewState.Item("sortExpression"))
                gridOutrosCustos.DataBind()

                gridOutrosCustos.Rows(CInt(ViewState.Item("rowmedido").ToString) - 3).BackColor = Drawing.Color.LightCyan
                gridOutrosCustos.Rows(CInt(ViewState.Item("rowmedido").ToString) - 3).Font.Bold = True
                gridOutrosCustos.Rows(CInt(ViewState.Item("rowmedido").ToString) - 2).BackColor = Drawing.Color.LightCyan
                gridOutrosCustos.Rows(CInt(ViewState.Item("rowmedido").ToString) - 2).Font.Bold = True

                gridOutrosCustos.Rows(ViewState.Item("rowmedido").ToString).Font.Size = FontSize.XXLarge
                gridOutrosCustos.Rows(ViewState.Item("rowmedido").ToString).BackColor = Drawing.Color.PaleTurquoise
                gridOutrosCustos.Rows(ViewState.Item("rowmedido").ToString).Font.Bold = True


            Else
                gridOutrosCustos.Visible = False
                ViewState.Item("rowmedido") = 0

            End If

            If lmesprovisorio > 0 Then
                gridResults.Columns(lmesprovisorio).ItemStyle.Font.Italic = True
                gridOutrosCustos.Columns(lmesprovisorio).ItemStyle.Font.Italic = True
                gridVolume.Columns(lmesprovisorio).ItemStyle.Font.Italic = True

            End If


            If gridVolume.Rows.Count.ToString + 1 < 65536 Then
                Dim tw As New StringWriter()
                Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                Dim frm As HtmlForm = New HtmlForm()

                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_CustoFinanceiroFlash_" & ViewState.Item("nr_ano").ToString & ".xls")

                Response.Charset = ""
                EnableViewState = False
                Controls.Add(frm)
                frm.Controls.Add(gridVolume)
                frm.Controls.Add(gridResults)
                frm.Controls.Add(gridOutrosCustos)

                frm.RenderControl(hw)
                Response.Write(tw.ToString())

                Response.End()
                Response.Flush()
                gridVolume.AllowPaging = "True"
                gridVolume.DataBind()
            End If


        Catch ex As Exception

            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridVolume_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridVolume.RowDataBound
        Try

            If (e.Row.RowType <> DataControlRowType.Header _
                And e.Row.RowType <> DataControlRowType.Footer _
                And e.Row.RowType <> DataControlRowType.Pager) Then

                Dim lbl_seq As Label = CType(e.Row.FindControl("lbl_seq"), Label)

                'e.Row.Cells(0).Font.Bold = True
                'e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center

                Select Case CInt(lbl_seq.Text)
                    Case 6, 10, 13
                        e.Row.Cells(2).Text = " "
                        e.Row.Cells(3).Text = " "
                        e.Row.Cells(4).Text = " "
                        e.Row.Cells(5).Text = " "
                        e.Row.Cells(6).Text = " "
                        e.Row.Cells(7).Text = " "
                        e.Row.Cells(8).Text = " "
                        e.Row.Cells(9).Text = " "
                        e.Row.Cells(10).Text = " "
                        e.Row.Cells(11).Text = " "
                        e.Row.Cells(12).Text = " "
                        e.Row.Cells(13).Text = " "

                    Case 12

                        'se volume adquirido for diferente do volume necessario de producao
                        If CDec(gridVolume.Rows(10).Cells(2).Text) > CDec(e.Row.Cells(2).Text) Then
                            gridVolume.Rows(10).Cells(2).ForeColor = Drawing.Color.Red
                        Else
                            If CDec(gridVolume.Rows(10).Cells(2).Text) < CDec(e.Row.Cells(2).Text) Then
                                gridVolume.Rows(10).Cells(2).ForeColor = Drawing.Color.DarkOrange
                            End If
                        End If
                        'se volume adquirido for diferente do volume necessario de producao
                        If CDec(gridVolume.Rows(10).Cells(3).Text) > CDec(e.Row.Cells(3).Text) Then
                            gridVolume.Rows(10).Cells(3).ForeColor = Drawing.Color.Red
                        Else
                            If CDec(gridVolume.Rows(10).Cells(3).Text) < CDec(e.Row.Cells(3).Text) Then
                                gridVolume.Rows(10).Cells(3).ForeColor = Drawing.Color.DarkOrange
                            End If
                        End If
                        'se volume adquirido for diferente do volume necessario de producao
                        If CDec(gridVolume.Rows(10).Cells(4).Text) > CDec(e.Row.Cells(4).Text) Then
                            gridVolume.Rows(10).Cells(4).ForeColor = Drawing.Color.Red
                        Else
                            If CDec(gridVolume.Rows(10).Cells(4).Text) < CDec(e.Row.Cells(4).Text) Then
                                gridVolume.Rows(10).Cells(4).ForeColor = Drawing.Color.DarkOrange
                            End If
                        End If
                        'se volume adquirido for diferente do volume necessario de producao
                        If CDec(gridVolume.Rows(10).Cells(5).Text) > CDec(e.Row.Cells(5).Text) Then
                            gridVolume.Rows(10).Cells(5).ForeColor = Drawing.Color.Red
                        Else
                            If CDec(gridVolume.Rows(10).Cells(5).Text) < CDec(e.Row.Cells(5).Text) Then
                                gridVolume.Rows(10).Cells(5).ForeColor = Drawing.Color.DarkOrange
                            End If
                        End If
                        'se volume adquirido for diferente do volume necessario de producao
                        If CDec(gridVolume.Rows(10).Cells(6).Text) > CDec(e.Row.Cells(6).Text) Then
                            gridVolume.Rows(10).Cells(6).ForeColor = Drawing.Color.Red
                        Else
                            If CDec(gridVolume.Rows(10).Cells(6).Text) < CDec(e.Row.Cells(6).Text) Then
                                gridVolume.Rows(10).Cells(6).ForeColor = Drawing.Color.DarkOrange
                            End If
                        End If
                        'se volume adquirido for diferente do volume necessario de producao
                        If CDec(gridVolume.Rows(10).Cells(7).Text) > CDec(e.Row.Cells(7).Text) Then
                            gridVolume.Rows(10).Cells(7).ForeColor = Drawing.Color.Red
                        Else
                            If CDec(gridVolume.Rows(10).Cells(7).Text) < CDec(e.Row.Cells(7).Text) Then
                                gridVolume.Rows(10).Cells(7).ForeColor = Drawing.Color.DarkOrange
                            End If
                        End If
                        'se volume adquirido for diferente do volume necessario de producao
                        If CDec(gridVolume.Rows(10).Cells(8).Text) > CDec(e.Row.Cells(8).Text) Then
                            gridVolume.Rows(10).Cells(8).ForeColor = Drawing.Color.Red
                        Else
                            If CDec(gridVolume.Rows(10).Cells(8).Text) < CDec(e.Row.Cells(8).Text) Then
                                gridVolume.Rows(10).Cells(8).ForeColor = Drawing.Color.DarkOrange
                            End If
                        End If
                        'se volume adquirido for diferente do volume necessario de producao
                        If CDec(gridVolume.Rows(10).Cells(9).Text) > CDec(e.Row.Cells(9).Text) Then
                            gridVolume.Rows(10).Cells(9).ForeColor = Drawing.Color.Red
                        Else
                            If CDec(gridVolume.Rows(10).Cells(9).Text) < CDec(e.Row.Cells(9).Text) Then
                                gridVolume.Rows(10).Cells(9).ForeColor = Drawing.Color.DarkOrange
                            End If
                        End If
                        'se volume adquirido for diferente do volume necessario de producao
                        If CDec(gridVolume.Rows(10).Cells(10).Text) > CDec(e.Row.Cells(10).Text) Then
                            gridVolume.Rows(10).Cells(10).ForeColor = Drawing.Color.Red
                        Else
                            If CDec(gridVolume.Rows(10).Cells(10).Text) < CDec(e.Row.Cells(10).Text) Then
                                gridVolume.Rows(10).Cells(10).ForeColor = Drawing.Color.DarkOrange
                            End If
                        End If
                        'se volume adquirido for diferente do volume necessario de producao
                        If CDec(gridVolume.Rows(10).Cells(11).Text) > CDec(e.Row.Cells(11).Text) Then
                            gridVolume.Rows(10).Cells(11).ForeColor = Drawing.Color.Red
                        Else
                            If CDec(gridVolume.Rows(10).Cells(11).Text) < CDec(e.Row.Cells(11).Text) Then
                                gridVolume.Rows(10).Cells(11).ForeColor = Drawing.Color.DarkOrange
                            End If
                        End If
                        'se volume adquirido for diferente do volume necessario de producao
                        If CDec(gridVolume.Rows(10).Cells(12).Text) > CDec(e.Row.Cells(12).Text) Then
                            gridVolume.Rows(10).Cells(12).ForeColor = Drawing.Color.Red
                        Else
                            If CDec(gridVolume.Rows(10).Cells(12).Text) < CDec(e.Row.Cells(12).Text) Then
                                gridVolume.Rows(10).Cells(12).ForeColor = Drawing.Color.DarkOrange
                            End If
                        End If
                        'se volume adquirido for diferente do volume necessario de producao
                        If CDec(gridVolume.Rows(10).Cells(13).Text) > CDec(e.Row.Cells(13).Text) Then
                            gridVolume.Rows(10).Cells(13).ForeColor = Drawing.Color.Red
                        Else
                            If CDec(gridVolume.Rows(10).Cells(13).Text) < CDec(e.Row.Cells(13).Text) Then
                                gridVolume.Rows(10).Cells(13).ForeColor = Drawing.Color.DarkOrange
                            End If
                        End If

                End Select

 


            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridOutrosCustos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridOutrosCustos.RowDataBound
        Try

            If (e.Row.RowType <> DataControlRowType.Header _
                And e.Row.RowType <> DataControlRowType.Footer _
                And e.Row.RowType <> DataControlRowType.Pager) Then

                Dim lbl_seq As Label = CType(e.Row.FindControl("lbl_seq"), Label)

                'e.Row.Cells(0).Font.Bold = True
                'e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center

                Select Case e.Row.Cells(1).Text

                    Case "zzzPreco"
                        e.Row.Cells(1).Text = "Preço Médio Final"
                        ViewState.Item("rowmedido") = e.Row.DataItemIndex


                        e.Row.Cells(2).Text = ViewState.Item("customes1").ToString
                        e.Row.Cells(3).Text = ViewState.Item("customes2").ToString
                        e.Row.Cells(4).Text = ViewState.Item("customes3").ToString
                        e.Row.Cells(5).Text = ViewState.Item("customes4").ToString
                        e.Row.Cells(6).Text = ViewState.Item("customes5").ToString
                        e.Row.Cells(7).Text = ViewState.Item("customes6").ToString
                        e.Row.Cells(8).Text = ViewState.Item("customes7").ToString
                        e.Row.Cells(9).Text = ViewState.Item("customes8").ToString
                        e.Row.Cells(10).Text = ViewState.Item("customes9").ToString
                        e.Row.Cells(11).Text = ViewState.Item("customes10").ToString
                        e.Row.Cells(12).Text = ViewState.Item("customes11").ToString
                        e.Row.Cells(13).Text = ViewState.Item("customes12").ToString

                    Case "Custo de Outros Custos"
                        ViewState.Item("customes1") = CDec(ViewState.Item("customes1")) + CDec(e.Row.Cells(2).Text)
                        ViewState.Item("customes2") = CDec(ViewState.Item("customes2")) + CDec(e.Row.Cells(3).Text)
                        ViewState.Item("customes3") = CDec(ViewState.Item("customes3")) + CDec(e.Row.Cells(4).Text)
                        ViewState.Item("customes4") = CDec(ViewState.Item("customes4")) + CDec(e.Row.Cells(5).Text)
                        ViewState.Item("customes5") = CDec(ViewState.Item("customes5")) + CDec(e.Row.Cells(6).Text)
                        ViewState.Item("customes6") = CDec(ViewState.Item("customes6")) + CDec(e.Row.Cells(7).Text)
                        ViewState.Item("customes7") = CDec(ViewState.Item("customes7")) + CDec(e.Row.Cells(8).Text)
                        ViewState.Item("customes8") = CDec(ViewState.Item("customes8")) + CDec(e.Row.Cells(9).Text)
                        ViewState.Item("customes9") = CDec(ViewState.Item("customes9")) + CDec(e.Row.Cells(10).Text)
                        ViewState.Item("customes10") = CDec(ViewState.Item("customes10")) + CDec(e.Row.Cells(11).Text)
                        ViewState.Item("customes11") = CDec(ViewState.Item("customes11")) + CDec(e.Row.Cells(12).Text)
                        ViewState.Item("customes12") = CDec(ViewState.Item("customes12")) + CDec(e.Row.Cells(13).Text)


                    Case Else
                        If e.Row.Cells(1).Text <> String.Empty And e.Row.Cells(1).Text <> "&nbsp;" Then

                            If e.Row.Cells(2).Text <> String.Empty And e.Row.Cells(2).Text <> "&nbsp;" Then
                                e.Row.Cells(2).Text = FormatNumber(e.Row.Cells(2).Text, 2).ToString
                            End If
                            If e.Row.Cells(3).Text <> String.Empty And e.Row.Cells(3).Text <> "&nbsp;" Then
                                e.Row.Cells(3).Text = FormatNumber(e.Row.Cells(3).Text, 2).ToString
                            End If
                            If e.Row.Cells(4).Text <> String.Empty And e.Row.Cells(4).Text <> "&nbsp;" Then
                                e.Row.Cells(4).Text = FormatNumber(e.Row.Cells(4).Text, 2).ToString
                            End If
                            If e.Row.Cells(5).Text <> String.Empty And e.Row.Cells(5).Text <> "&nbsp;" Then
                                e.Row.Cells(5).Text = FormatNumber(e.Row.Cells(5).Text, 2).ToString
                            End If
                            If e.Row.Cells(6).Text <> String.Empty And e.Row.Cells(6).Text <> "&nbsp;" Then
                                e.Row.Cells(6).Text = FormatNumber(e.Row.Cells(6).Text, 2).ToString
                            End If
                            If e.Row.Cells(7).Text <> String.Empty And e.Row.Cells(7).Text <> "&nbsp;" Then
                                e.Row.Cells(7).Text = FormatNumber(e.Row.Cells(7).Text, 2).ToString
                            End If
                            If e.Row.Cells(8).Text <> String.Empty And e.Row.Cells(8).Text <> "&nbsp;" Then
                                e.Row.Cells(8).Text = FormatNumber(e.Row.Cells(8).Text, 2).ToString
                            End If
                            If e.Row.Cells(9).Text <> String.Empty And e.Row.Cells(9).Text <> "&nbsp;" Then
                                e.Row.Cells(9).Text = FormatNumber(e.Row.Cells(9).Text, 2).ToString
                            End If
                            If e.Row.Cells(11).Text <> String.Empty And e.Row.Cells(11).Text <> "&nbsp;" Then
                                e.Row.Cells(11).Text = FormatNumber(e.Row.Cells(11).Text, 2).ToString
                            End If
                            If e.Row.Cells(12).Text <> String.Empty And e.Row.Cells(12).Text <> "&nbsp;" Then
                                e.Row.Cells(12).Text = FormatNumber(e.Row.Cells(12).Text, 2).ToString
                            End If
                            If e.Row.Cells(13).Text <> String.Empty And e.Row.Cells(13).Text <> "&nbsp;" Then
                                e.Row.Cells(13).Text = FormatNumber(e.Row.Cells(13).Text, 2).ToString
                            End If
                        End If

                End Select


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

                Dim lbl_seq As Label = CType(e.Row.FindControl("lbl_seq"), Label)

                e.Row.Cells(0).Font.Bold = True
                e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center

                Select Case CInt(lbl_seq.Text)

                    Case 1, 7, 14, 21
                        e.Row.Cells(0).Text = "PRODUTORES"
                        e.Row.Cells(1).Text = "Preço"
                    Case 2
                        e.Row.Cells(0).Text = "CPM"
                        e.Row.Cells(1).Text = "Inc Prod Leite 2,5%"
                    Case 3, 10, 17, 24, 30, 57
                        e.Row.Cells(1).Text = "PIS&COFINS"
                    Case 4, 11, 18, 25, 31, 36, 58
                        e.Row.Cells(1).Text = "ICMS"
                    Case 5, 12, 19, 26
                        e.Row.Cells(1).Text = "Frete T1"
                    Case 6, 13, 20, 27, 33, 38
                        e.Row.Cells(1).Text = "Custo"
                    Case 60
                        e.Row.Cells(1).Text = "Custo do Leite"
                        ViewState.Item("customes1") = e.Row.Cells(2).Text
                        ViewState.Item("customes2") = e.Row.Cells(3).Text
                        ViewState.Item("customes3") = e.Row.Cells(4).Text
                        ViewState.Item("customes4") = e.Row.Cells(5).Text
                        ViewState.Item("customes5") = e.Row.Cells(6).Text
                        ViewState.Item("customes6") = e.Row.Cells(7).Text
                        ViewState.Item("customes7") = e.Row.Cells(8).Text
                        ViewState.Item("customes8") = e.Row.Cells(9).Text
                        ViewState.Item("customes9") = e.Row.Cells(10).Text
                        ViewState.Item("customes10") = e.Row.Cells(11).Text
                        ViewState.Item("customes11") = e.Row.Cells(12).Text
                        ViewState.Item("customes12") = e.Row.Cells(13).Text

                    Case 8
                        e.Row.Cells(0).Text = "NEGO. GERENCIAL"
                        e.Row.Cells(1).Text = "Qualidade"
                    Case 9, 16, 23, 56
                        e.Row.Cells(1).Text = "Inc Prod Leite 2,5%"
                    Case 15
                        e.Row.Cells(0).Text = "CONTRATO"
                        e.Row.Cells(1).Text = "Qualidade"
                    Case 22
                        e.Row.Cells(0).Text = "MERCADO"
                        e.Row.Cells(1).Text = "Qualidade"
                    Case 28, 34
                        e.Row.Cells(0).Text = "COOPERATIVAS"
                        e.Row.Cells(1).Text = "Preço"
                    Case 29
                        e.Row.Cells(0).Text = "CONTRATO"
                        e.Row.Cells(1).Text = "Qualidade"
                    Case 32, 37
                        e.Row.Cells(1).Text = "Frete T2"
                    Case 35
                        e.Row.Cells(0).Text = "SPOT"
                        e.Row.Cells(1).Text = "PIS&COFINS"

                    Case 54
                        e.Row.Cells(0).Text = "PREÇO MÉDIO"
                        e.Row.Cells(1).Text = "Preço"
                    Case 55
                        e.Row.Cells(1).Text = "Qualidade"
                    Case 59
                        e.Row.Cells(1).Text = "Frete"

                End Select



            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
End Class
