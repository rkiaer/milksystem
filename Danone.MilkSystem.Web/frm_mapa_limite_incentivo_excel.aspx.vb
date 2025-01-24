Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_mapa_limite_incentivo_excel
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
                If (Not Request("st_limite_excedido") Is Nothing) Then
                    ViewState.Item("st_limite_excedido") = Request("st_limite_excedido")
                Else
                    ViewState.Item("st_limite_excedido") = String.Empty
                End If
                If (Not Request("mesprovisorio") Is Nothing) Then
                    ViewState.Item("mesprovisorio") = Request("mesprovisorio")
                Else
                    ViewState.Item("mesprovisorio") = 0
                End If
                If (Not Request("id_execucao") Is Nothing) Then
                    ViewState.Item("id_calculo_execucao_ultima") = Request("id_execucao")
                Else
                    ViewState.Item("id_calculo_execucao_ultima") = 0
                End If

                Dim mapa As New CustoFinanceiro

                mapa.dt_referencia_ini = ViewState.Item("dt_referencia_ini")
                mapa.dt_referencia_fim = ViewState.Item("dt_referencia_fim")
                mapa.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

                If ViewState.Item("st_limite_excedido") = True Then
                    mapa.st_limite_incentivo = "S"
                Else
                    mapa.st_limite_incentivo = "N"

                End If

                mapa.id_custo_financeiro_calculo_execucao = ViewState.Item("id_calculo_execucao_ultima")

                lbl_flash.Text = String.Concat("MAPA LIMITE INCENTIVO ", DateTime.Parse(ViewState.Item("dt_referencia_ini")).ToString("yyyy"))

                '' Trazer Poços e Aguas Juntos - i
                'If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                '    ficha.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                'Else
                '    ficha.estabelecimentos = ficha.id_estabelecimento
                'End If
                ''ficha.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                ' Trazer Poços e Aguas Juntos - f

                Dim dsmapa As DataSet = mapa.getMapaLimiteIncentivo()

                gridResults.DataSource = Helper.getDataView(dsmapa.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_MapaLimiteIncentivo_" & DateTime.Parse(ViewState.Item("dt_referencia_ini")).ToString("yyyy").ToString & ".xls")
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

            Dim mes1 As DataControlFieldCell = CType(e.Row.Cells.Item(5), DataControlFieldCell)
            Dim mes2 As DataControlFieldCell = CType(e.Row.Cells.Item(6), DataControlFieldCell)
            Dim mes3 As DataControlFieldCell = CType(e.Row.Cells.Item(7), DataControlFieldCell)
            Dim mes4 As DataControlFieldCell = CType(e.Row.Cells.Item(8), DataControlFieldCell)
            Dim mes5 As DataControlFieldCell = CType(e.Row.Cells.Item(9), DataControlFieldCell)
            Dim mes6 As DataControlFieldCell = CType(e.Row.Cells.Item(10), DataControlFieldCell)
            Dim mes7 As DataControlFieldCell = CType(e.Row.Cells.Item(11), DataControlFieldCell)
            Dim mes8 As DataControlFieldCell = CType(e.Row.Cells.Item(12), DataControlFieldCell)
            Dim mes9 As DataControlFieldCell = CType(e.Row.Cells.Item(13), DataControlFieldCell)
            Dim mes10 As DataControlFieldCell = CType(e.Row.Cells.Item(14), DataControlFieldCell)
            Dim mes11 As DataControlFieldCell = CType(e.Row.Cells.Item(15), DataControlFieldCell)
            Dim mes12 As DataControlFieldCell = CType(e.Row.Cells.Item(16), DataControlFieldCell)
            Dim lbl_id_propriedade_matriz As Label = CType(e.Row.FindControl("lbl_id_propriedade_matriz"), Label)
            Dim lbl_volumeprojetado As Label = CType(e.Row.FindControl("lbl_volumeprojetado"), Label)
            Dim lbl_propordenacao As Label = CType(e.Row.FindControl("lbl_propordenacao"), Label)
            Dim lbl_volumetotal As Label = CType(e.Row.FindControl("lbl_volumetotal"), Label)
            Dim lbl_nr_saldo_limite As Label = CType(e.Row.FindControl("lbl_nr_saldo_limite"), Label)


            'No mes provisorio colocar volume em azul
            If CInt(ViewState.Item("mesprovisorio")) > 0 Then

                lbl_informativo.Visible = True

                Select Case CInt(ViewState.Item("mesprovisorio").ToString)
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

            Dim lsomavolume As Integer = 0
            Dim lcor As System.Drawing.Color
            Dim lnrvolumetotal As Integer = 0
            If (Not lbl_volumetotal.Text.Equals(String.Empty) And Not lbl_volumetotal.Text = "&nbsp;") Then
                If lbl_volumetotal.Text = "0" Then
                    lnrvolumetotal = 0
                Else
                    If CDec(lbl_volumetotal.Text) >= 637000 Then 'se falta 20000 para estourar
                        lcor = Drawing.Color.Yellow
                        If CDec(lbl_volumetotal.Text) >= 657000 Then
                            lcor = Drawing.Color.MistyRose
                        End If

                        e.Row.Cells.Item(17).BackColor = lcor
                        e.Row.Cells.Item(18).BackColor = lcor

                        lbl_volumetotal.ForeColor = Drawing.Color.Red
                        lbl_nr_saldo_limite.ForeColor = Drawing.Color.Red

                    End If
                    lbl_volumetotal.Text = FormatNumber(lbl_volumetotal.Text, 0).ToString
                    lbl_nr_saldo_limite.Text = FormatNumber(lbl_nr_saldo_limite.Text, 0).ToString
                    lnrvolumetotal = CInt(lbl_volumetotal.Text)
                End If
            End If
            If (Not lbl_volumeprojetado.Text.Equals(String.Empty) And Not lbl_volumetotal.Text = "&nbsp;") Then
                If Not lbl_volumeprojetado.Text = "0" Then
                    If CInt(lbl_volumeprojetado.Text) >= 657000 AndAlso lnrvolumetotal < 637000 Then
                        e.Row.BackColor = Drawing.Color.PaleTurquoise
                    End If

                End If

            End If

            If (Not mes1.Text.Equals(String.Empty) And Not mes1.Text = "&nbsp;") Then
                If mes1.Text = "0" Then
                    mes1.Text = "-"
                Else
                    mes1.Text = FormatNumber(Abs(CDec(mes1.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes1.Text)
                    If lsomavolume >= 637000 Then
                        mes1.BackColor = lcor
                        mes1.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes1.Text = "-"
            End If
            If (Not mes2.Text.Equals(String.Empty) And Not mes2.Text = "&nbsp;") Then
                If mes2.Text = "0" Then
                    mes2.Text = "-"
                Else
                    mes2.Text = FormatNumber(Abs(CDec(mes2.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes2.Text)
                    If lsomavolume >= 637000 Then
                        mes2.BackColor = lcor
                        mes2.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes2.Text = "-"
            End If

            If (Not mes3.Text.Equals(String.Empty) And Not mes3.Text = "&nbsp;") Then
                If mes3.Text = "0" Then
                    mes3.Text = "-"
                Else
                    mes3.Text = FormatNumber(Abs(CDec(mes3.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes3.Text)
                    If lsomavolume >= 637000 Then
                        mes3.BackColor = lcor
                        mes3.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes3.Text = "-"
            End If

            If (Not mes4.Text.Equals(String.Empty) And Not mes4.Text = "&nbsp;") Then
                If mes4.Text = "0" Then
                    mes4.Text = "-"
                Else
                    mes4.Text = FormatNumber(Abs(CDec(mes4.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes4.Text)
                    If lsomavolume >= 637000 Then
                        mes4.BackColor = lcor
                        mes4.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes4.Text = "-"
            End If

            If (Not mes5.Text.Equals(String.Empty) And Not mes5.Text = "&nbsp;") Then
                If mes5.Text = "0" Then
                    mes5.Text = "-"
                Else
                    mes5.Text = FormatNumber(Abs(CDec(mes5.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes5.Text)
                    If lsomavolume >= 637000 Then
                        mes5.BackColor = lcor
                        mes5.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes5.Text = "-"
            End If
            If (Not mes6.Text.Equals(String.Empty) And Not mes6.Text = "&nbsp;") Then
                If mes6.Text = "0" Then
                    mes6.Text = "-"
                Else
                    mes6.Text = FormatNumber(Abs(CDec(mes6.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes6.Text)
                    If lsomavolume >= 637000 Then
                        mes6.BackColor = lcor
                        mes6.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes6.Text = "-"
            End If

            If (Not mes7.Text.Equals(String.Empty) And Not mes7.Text = "&nbsp;") Then
                If mes7.Text = "0" Then
                    mes7.Text = "-"
                Else
                    mes7.Text = FormatNumber(Abs(CDec(mes7.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes7.Text)
                    If lsomavolume >= 637000 Then
                        mes7.BackColor = lcor
                        mes7.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes7.Text = "-"
            End If

            If (Not mes8.Text.Equals(String.Empty) And Not mes8.Text = "&nbsp;") Then
                If mes8.Text = "0" Then
                    mes8.Text = "-"
                Else
                    mes8.Text = FormatNumber(Abs(CDec(mes8.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes8.Text)
                    If lsomavolume >= 637000 Then
                        mes8.BackColor = lcor
                        mes8.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes8.Text = "-"
            End If

            If (Not mes9.Text.Equals(String.Empty) And Not mes9.Text = "&nbsp;") Then
                If mes9.Text = "0" Then
                    mes9.Text = "-"
                Else
                    mes9.Text = FormatNumber(Abs(CDec(mes9.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes9.Text)
                    If lsomavolume >= 637000 Then
                        mes9.BackColor = lcor
                        mes9.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes9.Text = "-"
            End If

            If (Not mes10.Text.Equals(String.Empty) And Not mes10.Text = "&nbsp;") Then
                If mes10.Text = "0" Then
                    mes10.Text = "-"
                Else
                    mes10.Text = FormatNumber(Abs(CDec(mes10.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes10.Text)
                    If lsomavolume >= 637000 Then
                        mes10.BackColor = lcor
                        mes10.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes10.Text = "-"
            End If

            If (Not mes11.Text.Equals(String.Empty) And Not mes11.Text = "&nbsp;") Then
                If mes11.Text = "0" Then
                    mes11.Text = "-"
                Else
                    mes11.Text = FormatNumber(Abs(CDec(mes11.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes11.Text)
                    If lsomavolume >= 637000 Then
                        mes11.BackColor = lcor
                        mes11.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes11.Text = "-"
            End If

            If (Not mes12.Text.Equals(String.Empty) And Not mes12.Text = "&nbsp;") Then
                If mes12.Text = "0" Then
                    mes12.Text = "-"
                Else
                    mes12.Text = FormatNumber(Abs(CDec(mes12.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes12.Text)
                    If lsomavolume >= 637000 Then
                        mes12.BackColor = lcor
                        mes12.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes12.Text = "-"
            End If


        End If


    End Sub

End Class
