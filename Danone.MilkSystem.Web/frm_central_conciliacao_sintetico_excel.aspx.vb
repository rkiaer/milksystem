Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_central_conciliacao_sintetico_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResultsSintetico.Rows.Count.ToString + 1 < 65536 Then

            Try



                If (Not Request("dt_referencia_ini") Is Nothing) Then
                    ViewState.Item("dt_referencia_ini") = Request("dt_referencia_ini")
                Else
                    ViewState.Item("dt_referencia_ini") = String.Empty
                End If

                If (Not Request("dt_referencia_fim") Is Nothing) Then
                    ViewState.Item("dt_referencia_fim") = Request("dt_referencia_fim")
                Else
                    ViewState.Item("dt_referencia_fim") = String.Empty
                End If

                If (Not Request("nr_saldoacumuladoSAP") Is Nothing) Then
                    ViewState.Item("nr_saldoacumuladoSAP") = Request("nr_saldoacumuladoSAP")
                Else
                    ViewState.Item("nr_saldoacumuladoSAP") = "0"
                End If

                Dim pedido As New Pedido

                'pedido.dt_inicio = ViewState.Item("dt_referencia_ini")
                'Pedido.dt_fim = ViewState.Item("dt_referencia_fim")
                'Pedido.dt_fornec_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_referencia_fim"))))

                Dim lano As String = DatePart(DateInterval.Year, CDate(ViewState.Item("dt_referencia_ini"))).ToString
                pedido.dt_inicio = DateTime.Parse(String.Concat("01/01/", lano.Trim)).ToString("dd/MM/yyyy")
                pedido.dt_fim = DateTime.Parse(String.Concat("01/12/", lano.Trim)).ToString("dd/MM/yyyy")
                pedido.dt_fornec_fim = DateTime.Parse(String.Concat("31/12/", lano.Trim)).ToString("dd/MM/yyyy")
                pedido.nr_saldoacumuladoSAP = Convert.ToDecimal(ViewState.Item("nr_saldoacumuladoSAP"))

                Dim dsPedidoVisaoSintetica As DataSet = pedido.getCentralConciliacaoContabilidadeSintetico()
                ViewState.Item("saldoacumuladoanterior") = 0

                gridResultsSintetico.DataSource = Helper.getDataView(dsPedidoVisaoSintetica.Tables(0), ViewState.Item("sortExpression"))
                gridResultsSintetico.AllowPaging = False
                gridResultsSintetico.DataBind()
                ViewState.Item("saldoacumuladoanterior") = 0

                If gridResultsSintetico.Rows.Count.ToString + 1 < 65536 Then
                    If gridResultsSintetico.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_RelatorioApoioContabilidade_Sintético" & ".xls")
                        Response.Charset = ""
                        EnableViewState = False
                        Controls.Add(frm)
                        frm.Controls.Add(gridResultsSintetico)
                        frm.RenderControl(hw)
                        Response.Write(tw.ToString())
                        Response.End()
                        gridResultsSintetico.AllowPaging = "True"
                        gridResultsSintetico.DataBind()
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

    Protected Sub gridResultsSintetico_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsSintetico.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_nr_saldoinicialconta As Label = CType(e.Row.FindControl("lbl_nr_saldoinicialconta"), Label)

            'se a data de referencia é um mes anterior ao inicio do filtro
            If CDate(e.Row.Cells(0).Text) = DateAdd(DateInterval.Month, -1, CDate(ViewState.Item("txt_dt_referencia_ini").ToString)) Then
                'limpa tudo se for 0 deixa o acumuado que veio calcuado se for null, assume valor ac
                If lbl_nr_saldoinicialconta.Text = String.Empty Then
                    e.Row.Cells(1).Text = String.Empty
                    e.Row.Cells(2).Text = String.Empty
                    e.Row.Cells(3).Text = String.Empty
                    e.Row.Cells(4).Text = ViewState.Item("nr_saldoacumuladoSAP").ToString
                Else
                    If CInt(lbl_nr_saldoinicialconta.Text) = 0 Then
                        e.Row.Cells(1).Text = String.Empty
                        e.Row.Cells(2).Text = String.Empty
                        e.Row.Cells(3).Text = String.Empty
                    End If

                End If
                ViewState.Item("saldoacumuladoanterior") = e.Row.Cells(4).Text
            Else

                If e.Row.Cells(4).Text = "&nbsp;" OrElse CInt(e.Row.Cells(4).Text) = 0 Then
                    e.Row.Cells(4).Text = ViewState.Item("saldoacumuladoanterior")
                Else
                    ViewState.Item("saldoacumuladoanterior") = e.Row.Cells(4).Text
                End If
            End If

            'If nrcomplcbt.Text = "0" Then
            '    nrnaocompl = nrnaocompl + 1
            'End If
            'If nrcomplcbt1.Text = "0" Then
            '    nrnaocompl = nrnaocompl + 1
            'End If
            'If nrcomplcbt2.Text = "0" Then
            '    nrnaocompl = nrnaocompl + 1
            'End If


            'If (nrnaocompl = 3 And nranalisecomplcbt.Text = "-1") OrElse nrnaocompl = 2 Then
            '    e.Row.BackColor = Drawing.Color.Yellow
            '    e.Row.Cells(2).BackColor = Drawing.Color.Yellow
            '    e.Row.Cells(7).BackColor = Drawing.Color.Yellow
            '    e.Row.Cells(8).BackColor = Drawing.Color.Yellow
            '    e.Row.Cells(9).BackColor = Drawing.Color.Yellow
            '    e.Row.Cells(10).BackColor = Drawing.Color.Yellow
            '    e.Row.Cells(11).BackColor = Drawing.Color.Yellow
            '    e.Row.Cells(12).BackColor = Drawing.Color.Yellow
            '    e.Row.Cells(13).BackColor = Drawing.Color.Yellow
            'End If

            'If Not lbl_nr_teor_ctm.Text.Equals(String.Empty) Then
            '    lbl_nr_teor_ctm.Text = FormatNumber(lbl_nr_teor_ctm.Text, 0).ToString
            '    If nrcomplcbt.Text = "0" Then
            '        e.Row.Cells(11).BackColor = Drawing.Color.Red
            '    End If
            'End If
            'If Not lbl_nr_teor_ctm1.Text.Equals(String.Empty) Then
            '    lbl_nr_teor_ctm1.Text = FormatNumber(lbl_nr_teor_ctm1.Text, 0).ToString
            '    If nrcomplcbt1.Text = "0" Then
            '        e.Row.Cells(9).BackColor = Drawing.Color.Red
            '    End If
            'End If
            'If Not lbl_nr_teor_ctm2.Text.Equals(String.Empty) Then
            '    lbl_nr_teor_ctm2.Text = FormatNumber(lbl_nr_teor_ctm2.Text, 0).ToString
            '    If nrcomplcbt2.Text = "0" Then
            '        e.Row.Cells(7).BackColor = Drawing.Color.Red
            '    End If

            'End If

            'If Not lbl_menoresalq.Text.Equals(String.Empty) Then
            '    lbl_menoresalq.Text = FormatNumber(lbl_menoresalq.Text, 0).ToString
            '    If nranalisecomplcbt.Text = "0" Then
            '        e.Row.Cells(13).BackColor = Drawing.Color.Red
            '        'se tem 3 nao compl e menor analise tbm nao complience
            '        If nrnaocompl = 3 Then
            '            e.Row.BackColor = Drawing.Color.Red
            '            e.Row.ForeColor = Drawing.Color.White
            '            e.Row.Cells(6).BackColor = Drawing.Color.Red
            '            e.Row.Cells(7).BackColor = Drawing.Color.Red
            '            e.Row.Cells(8).BackColor = Drawing.Color.Red
            '            e.Row.Cells(9).BackColor = Drawing.Color.Red
            '            e.Row.Cells(10).BackColor = Drawing.Color.Red
            '            e.Row.Cells(11).BackColor = Drawing.Color.Red
            '            e.Row.Cells(12).BackColor = Drawing.Color.Red
            '            e.Row.Cells(13).BackColor = Drawing.Color.Red
            '            e.Row.Cells(6).ForeColor = Drawing.Color.White
            '            e.Row.Cells(7).ForeColor = Drawing.Color.White
            '            e.Row.Cells(8).ForeColor = Drawing.Color.White
            '            e.Row.Cells(9).ForeColor = Drawing.Color.White
            '            e.Row.Cells(10).ForeColor = Drawing.Color.White
            '            e.Row.Cells(11).ForeColor = Drawing.Color.White
            '            e.Row.Cells(12).ForeColor = Drawing.Color.White
            '            e.Row.Cells(13).ForeColor = Drawing.Color.White

            '        End If
            '    End If
            'End If

        End If

    End Sub
End Class
