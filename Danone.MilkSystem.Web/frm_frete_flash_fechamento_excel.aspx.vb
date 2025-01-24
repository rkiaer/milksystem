Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_frete_flash_fechamento_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            If (Not Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            Else
                ViewState.Item("id_estabelecimento") = String.Empty
            End If

            If (Not Request("id_transportador") Is Nothing) Then
                ViewState.Item("id_transportador") = Request("id_transportador")
            Else
                ViewState.Item("id_transportador") = "0"
            End If

            If (Not Request("id_frete_periodo") Is Nothing) Then
                ViewState.Item("id_frete_periodo") = Request("id_frete_periodo")
            End If
            ViewState.Item("dt_referencia") = Request("dt_referencia")
            ViewState.Item("id_visao") = Request("id_visao")
            ViewState.Item("id_tipo_frete") = Request("id_tipo_frete")

            Dim frete As New CalculoFrete

            If Trim(ViewState.Item("id_transportador")) <> "" Then
                frete.id_transportador = Convert.ToInt32(ViewState.Item("id_transportador").ToString)
            End If
            frete.id_estabelecimento = ViewState.Item("id_estabelecimento")
            If ViewState.Item("dt_referencia").Equals(String.Empty) Then
                frete.dt_referencia = String.Empty
            Else
                frete.dt_referencia = ViewState.Item("dt_referencia").ToString()
            End If
            frete.id_frete_periodo = ViewState.Item("id_frete_periodo").ToString
            frete.id_tipo_frete = ViewState.Item("id_tipo_frete").ToString

            Dim periodo As New FretePeriodo
            periodo.id_frete_periodo = frete.id_frete_periodo.ToString
            Dim dsperiodo As DataSet = periodo.getFretePeriodo
            If dsperiodo.Tables(0).Rows.Count > 0 Then
                frete.dt_inicio = DateTime.Parse(dsperiodo.Tables(0).Rows(0).Item("dt_inicio").ToString).ToString("dd/MM/yyyy")
                frete.dt_fim = DateTime.Parse(dsperiodo.Tables(0).Rows(0).Item("dt_fim").ToString).ToString("dd/MM/yyyy")
            End If

            Dim dsfrete As DataSet

            Select Case ViewState.Item("id_visao").ToString
                Case "F"
                    dsfrete = frete.getCalculoFreteFlashFechamento
                    gridResults.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                    gridResults.AllowPaging = False
                    gridResults.DataBind()

                    If gridResults.Rows.Count.ToString + 1 < 65536 Then
                        If gridResults.Rows.Count > 0 Then
                            Dim tw As New StringWriter()
                            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                            Dim frm As HtmlForm = New HtmlForm()
                            Response.ContentType = "application/vnd.ms-excel"
                            'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                            Select Case ViewState.Item("id_tipo_frete").ToString
                                Case "1"
                                    Response.AddHeader("content-disposition", "attachment;filename=" & "FreteT1_FlashFechamento_" & DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MMMyyyy").ToUpper & "_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")

                                Case "3"
                                    Response.AddHeader("content-disposition", "attachment;filename=" & "FreteT2TP_FlashFechamento_" & DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MMMyyyy").ToUpper & "_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")

                                Case "4"
                                    Response.AddHeader("content-disposition", "attachment;filename=" & "FreteT2TVASE_FlashFechamento_" & DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MMMyyyy").ToUpper & "_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")

                            End Select

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

                Case "R"
                    dsfrete = frete.getCalculoFreteRomaneiosErros
                    gridDivergencia.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                    gridDivergencia.AllowPaging = False
                    gridDivergencia.DataBind()

                    If gridDivergencia.Rows.Count.ToString + 1 < 65536 Then
                        If gridDivergencia.Rows.Count > 0 Then
                            Dim tw As New StringWriter()
                            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                            Dim frm As HtmlForm = New HtmlForm()
                            Response.ContentType = "application/vnd.ms-excel"
                            'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                            Select Case ViewState.Item("id_tipo_frete").ToString
                                Case "1"
                                    Response.AddHeader("content-disposition", "attachment;filename=" & "FreteT1_FlashRomaneios_Divergencias_" & DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MMMyyyy").ToUpper & "_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")

                                Case "3"
                                    Response.AddHeader("content-disposition", "attachment;filename=" & "FreteT2TP_FlashRomaneios_Divergencias_" & DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MMMyyyy").ToUpper & "_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")

                                Case "4"
                                    Response.AddHeader("content-disposition", "attachment;filename=" & "FreteT2TVASE_FlashRomaneios_Divergencias_" & DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MMMyyyy").ToUpper & "_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")
                            End Select
                            Response.Charset = ""
                            EnableViewState = False
                            Controls.Add(frm)
                            frm.Controls.Add(gridDivergencia)
                            frm.RenderControl(hw)
                            Response.Write(tw.ToString())
                            Response.End()
                            gridDivergencia.AllowPaging = "True"
                            gridDivergencia.DataBind()
                        Else
                            messageControl.Alert("Não há linhas a serem exportadas!")
                        End If
                    Else
                        messageControl.Alert(" Planilha possui muitas linhas, não é possível exportar para o Excel")
                    End If

                Case "RC"
                    dsfrete = frete.getCalculoFreteRomaneios
                    gridDivergencia.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                    gridDivergencia.AllowPaging = False
                    gridDivergencia.DataBind()

                    If gridDivergencia.Rows.Count.ToString + 1 < 65536 Then
                        If gridDivergencia.Rows.Count > 0 Then
                            Dim tw As New StringWriter()
                            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                            Dim frm As HtmlForm = New HtmlForm()
                            Response.ContentType = "application/vnd.ms-excel"
                            'Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                            Select Case ViewState.Item("id_tipo_frete").ToString
                                Case "1"
                                    Response.AddHeader("content-disposition", "attachment;filename=" & "FreteT1_FlashRomaneios_Calculados_" & DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MMMyyyy").ToUpper & "_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")

                                Case "3"
                                    Response.AddHeader("content-disposition", "attachment;filename=" & "FreteT2TP_FlashRomaneios_Calculados_" & DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MMMyyyy").ToUpper & "_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")

                                Case "4"
                                    Response.AddHeader("content-disposition", "attachment;filename=" & "FreteT2TVASE_FlashRomaneios_Calculados_" & DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MMMyyyy").ToUpper & "_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")

                            End Select
                            Response.Charset = ""
                            EnableViewState = False
                            Controls.Add(frm)
                            frm.Controls.Add(gridDivergencia)
                            frm.RenderControl(hw)
                            Response.Write(tw.ToString())
                            Response.End()
                            gridDivergencia.AllowPaging = "True"
                            gridDivergencia.DataBind()
                        Else
                            messageControl.Alert("Não há linhas a serem exportadas!")
                        End If
                    Else
                        messageControl.Alert(" Planilha possui muitas linhas, não é possível exportar para o Excel")
                    End If

            End Select


        Catch ex As Exception

            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound


        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            Dim lbl_seq As Label = CType(e.Row.FindControl("lbl_seq"), Label)

            If lbl_seq.Text = "4" Then
                e.Row.BackColor = Drawing.Color.CornflowerBlue
                e.Row.ForeColor = Drawing.Color.White
                e.Row.Font.Bold = True
            End If


        End If
    End Sub

End Class
