Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_flash_financeiro_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            Try


                If (Not Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                Else
                    ViewState.Item("id_estabelecimento") = String.Empty
                End If

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

                Dim ficha As New FichaFinanceira

                ficha.dt_referencia_ficha_start = ViewState.Item("dt_referencia_ini")
                ficha.dt_referencia_ficha_end = ViewState.Item("dt_referencia_fim")
                ficha.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

                lbl_flash.Text = String.Concat("FLASH FINANCEIRO ", DateTime.Parse(ViewState.Item("dt_referencia_ini")).ToString("yyyy"))

                ' Trazer Poços e Aguas Juntos - i
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    ficha.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    ficha.estabelecimentos = ficha.id_estabelecimento
                End If
                'ficha.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                ' Trazer Poços e Aguas Juntos - f

                Dim dsficha As DataSet = ficha.getFlashFinanceiro()

                gridResults.DataSource = Helper.getDataView(dsficha.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "FlashFinanceiro" & ".xls")
                        Response.Charset = ""
                        EnableViewState = False
                        Controls.Add(frm)
                        frm.Controls.Add(tb_header)
                        frm.Controls.Add(gridResults)
                        frm.Controls.Add(lbl_informativo)
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

            Dim mes1 As DataControlFieldCell = CType(e.Row.Cells.Item(1), DataControlFieldCell)
            Dim mes2 As DataControlFieldCell = CType(e.Row.Cells.Item(2), DataControlFieldCell)
            Dim mes3 As DataControlFieldCell = CType(e.Row.Cells.Item(3), DataControlFieldCell)
            Dim mes4 As DataControlFieldCell = CType(e.Row.Cells.Item(4), DataControlFieldCell)
            Dim mes5 As DataControlFieldCell = CType(e.Row.Cells.Item(5), DataControlFieldCell)
            Dim mes6 As DataControlFieldCell = CType(e.Row.Cells.Item(6), DataControlFieldCell)
            Dim mes7 As DataControlFieldCell = CType(e.Row.Cells.Item(7), DataControlFieldCell)
            Dim mes8 As DataControlFieldCell = CType(e.Row.Cells.Item(8), DataControlFieldCell)
            Dim mes9 As DataControlFieldCell = CType(e.Row.Cells.Item(9), DataControlFieldCell)
            Dim mes10 As DataControlFieldCell = CType(e.Row.Cells.Item(10), DataControlFieldCell)
            Dim mes11 As DataControlFieldCell = CType(e.Row.Cells.Item(11), DataControlFieldCell)
            Dim mes12 As DataControlFieldCell = CType(e.Row.Cells.Item(12), DataControlFieldCell)
            Dim lbl_id_conta As Label = CType(e.Row.FindControl("lbl_id_conta"), Label)

            Dim lbl_nr_mes_provisorio As Label = CType(e.Row.FindControl("lbl_nr_mes_provisorio"), Label)

            If CInt(lbl_nr_mes_provisorio.Text) > 0 Then

                lbl_informativo.Visible = True

                Select Case CInt(lbl_nr_mes_provisorio.Text)
                    Case 1
                        mes1.Font.Italic = True
                        mes1.ForeColor = Drawing.Color.Blue
                    Case 2
                        mes2.Font.Italic = True
                        mes2.ForeColor = Drawing.Color.Blue
                    Case 3
                        mes3.Font.Italic = True
                        mes3.ForeColor = Drawing.Color.Blue
                    Case 4
                        mes4.Font.Italic = True
                        mes4.ForeColor = Drawing.Color.Blue
                    Case 5
                        mes5.Font.Italic = True
                        mes5.ForeColor = Drawing.Color.Blue
                    Case 6
                        mes6.Font.Italic = True
                        mes6.ForeColor = Drawing.Color.Blue
                    Case 7
                        mes7.Font.Italic = True
                        mes7.ForeColor = Drawing.Color.Blue
                    Case 8
                        mes8.Font.Italic = True
                        mes8.ForeColor = Drawing.Color.Blue
                    Case 9
                        mes9.Font.Italic = True
                        mes9.ForeColor = Drawing.Color.Blue
                    Case 10
                        mes10.Font.Italic = True
                        mes10.ForeColor = Drawing.Color.Blue
                    Case 11
                        mes11.Font.Italic = True
                        mes11.ForeColor = Drawing.Color.Blue
                    Case 12
                        mes12.Font.Italic = True
                        mes12.ForeColor = Drawing.Color.Blue
                End Select

            Else
                lbl_informativo.Visible = False
            End If

            If lbl_id_conta.Text = "1" Then 'COnta 0010 Volume
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
            End If


            If lbl_id_conta.Text = "64" Then 'COnta total de qualidade X volume
                If (Not mes1.Text.Equals(String.Empty) And Not mes1.Text = "&nbsp;") Then
                    mes1.Text = FormatCurrency(mes1.Text, 2).ToString()
                End If
                If (Not mes2.Text.Equals(String.Empty) And Not mes2.Text = "&nbsp;") Then
                    mes2.Text = FormatCurrency(mes2.Text, 2).ToString()
                End If
                If (Not mes3.Text.Equals(String.Empty) And Not mes3.Text = "&nbsp;") Then
                    mes3.Text = FormatCurrency(mes3.Text, 2).ToString()
                End If
                If (Not mes4.Text.Equals(String.Empty) And Not mes4.Text = "&nbsp;") Then
                    mes4.Text = FormatCurrency(mes4.Text, 2).ToString()
                End If
                If (Not mes5.Text.Equals(String.Empty) And Not mes5.Text = "&nbsp;") Then
                    mes5.Text = FormatCurrency(mes5.Text, 2).ToString()
                End If
                If (Not mes6.Text.Equals(String.Empty) And Not mes6.Text = "&nbsp;") Then
                    mes6.Text = FormatCurrency(mes6.Text, 2).ToString()
                End If
                If (Not mes7.Text.Equals(String.Empty) And Not mes7.Text = "&nbsp;") Then
                    mes7.Text = FormatCurrency(mes7.Text, 2).ToString()
                End If
                If (Not mes8.Text.Equals(String.Empty) And Not mes8.Text = "&nbsp;") Then
                    mes8.Text = FormatCurrency(mes8.Text, 2).ToString()
                End If
                If (Not mes9.Text.Equals(String.Empty) And Not mes9.Text = "&nbsp;") Then
                    mes9.Text = FormatCurrency(mes9.Text, 2).ToString()
                End If
                If (Not mes10.Text.Equals(String.Empty) And Not mes10.Text = "&nbsp;") Then
                    mes10.Text = FormatCurrency(mes10.Text, 2).ToString()
                End If
                If (Not mes11.Text.Equals(String.Empty) And Not mes11.Text = "&nbsp;") Then
                    mes11.Text = FormatCurrency(mes11.Text, 2).ToString()
                End If
                If (Not mes12.Text.Equals(String.Empty) And Not mes12.Text = "&nbsp;") Then
                    mes12.Text = FormatCurrency(mes12.Text, 2).ToString()
                End If
            End If
        End If


    End Sub

End Class
