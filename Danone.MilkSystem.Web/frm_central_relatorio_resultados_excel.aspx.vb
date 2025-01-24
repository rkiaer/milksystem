Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_central_relatorio_resultados_excel
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

                Dim dsresultados As DataSet = pedido.getCentralRelatorioResultados

                Dim lano As String = ViewState("dt_referencia").ToString
                pedido.dt_inicio = DateTime.Parse(String.Concat("01/01/", lano.Trim)).ToString("dd/MM/yyyy")
                pedido.dt_fim = DateTime.Parse(String.Concat("01/12/", lano.Trim)).ToString("dd/MM/yyyy")
                pedido.dt_fornec_fim = DateTime.Parse(String.Concat("31/12/", lano.Trim)).ToString("dd/MM/yyyy")

                Dim dsPedidoVisaoSintetica As DataSet = pedido.getCentralConciliacaoContabilidadeSintetico()


                If (dsresultados.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsresultados.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()

                    Dim row As GridViewRow
                    Dim ilinha As Integer = 0
                    Dim irow As Integer = 0

                    For Each row In gridResults.Rows
                        Dim lbl_total_desconto As Anthem.Label = CType(row.FindControl("lbl_total_desconto"), Anthem.Label)
                        Dim lbl_total_pagto As Anthem.Label = CType(row.FindControl("lbl_total_pagto"), Anthem.Label)
                        Dim lbl_dt_referencia As Label = CType(row.FindControl("lbl_dt_referencia"), Label)

                        irow = row.RowIndex

                        If (dsPedidoVisaoSintetica.Tables(0).Rows.Count > 0) Then
                            For ilinha = irow To dsPedidoVisaoSintetica.Tables(0).Rows.Count - 1
                                If CDate(dsPedidoVisaoSintetica.Tables(0).Rows(ilinha).Item("dt_referencia")) = CDate(lbl_dt_referencia.Text) Then

                                    If Not IsDBNull(dsPedidoVisaoSintetica.Tables(0).Rows(ilinha).Item("nr_credito")) Then
                                        lbl_total_desconto.Text = FormatNumber(dsPedidoVisaoSintetica.Tables(0).Rows(ilinha).Item("nr_credito").ToString, 2)
                                    Else
                                        lbl_total_desconto.Text = String.Empty
                                    End If

                                    If Not IsDBNull(dsPedidoVisaoSintetica.Tables(0).Rows(ilinha).Item("nr_debito")) Then
                                        lbl_total_pagto.Text = FormatNumber(dsPedidoVisaoSintetica.Tables(0).Rows(ilinha).Item("nr_debito").ToString, 2)
                                    Else
                                        lbl_total_pagto.Text = String.Empty
                                    End If

                                Else
                                    If CDate(dsPedidoVisaoSintetica.Tables(0).Rows(ilinha).Item("dt_referencia")) > CDate(lbl_dt_referencia.Text) Then
                                        Exit For
                                    End If
                                End If
                            Next
                        Else
                            Exit For
                        End If


                    Next
                End If

                gridResults.AllowPaging = False

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "CentralComprasResultadosSintetico_" & lano & "_" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".xls")

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

End Class
