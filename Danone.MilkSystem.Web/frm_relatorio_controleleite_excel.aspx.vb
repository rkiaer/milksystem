Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_relatorio_controleleite_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            Try

                If (Not Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                Else
                    ViewState.Item("id_estabelecimento") = String.Empty
                End If

                If (Not Request("data_ini") Is Nothing) Then
                    ViewState.Item("data") = Request("data_ini")
                Else
                    ViewState.Item("data") = String.Empty
                End If

                If (Not Request("data_fim") Is Nothing) Then
                    ViewState.Item("data_fim") = Request("data_fim")
                Else
                    ViewState.Item("data_fim") = String.Empty
                End If

                If (Not Request("emitirpor") Is Nothing) Then
                    ViewState.Item("emitirpor") = Request("emitirpor")
                Else
                    ViewState.Item("emitirpor") = String.Empty
                End If

                If (Not Request("cd_rota_ini") Is Nothing) Then
                    ViewState.Item("cd_rota_ini") = Request("cd_rota_ini")
                Else
                    ViewState.Item("cd_rota_ini") = String.Empty
                End If


                If (Not Request("cd_rota_fim") Is Nothing) Then
                    ViewState.Item("cd_rota_fim") = Request("cd_rota_fim")
                Else
                    ViewState.Item("cd_rota_fim") = String.Empty
                End If

                Dim romaneio As New Romaneio

                If Not (ViewState.Item("id_estabelecimento").Equals(String.Empty)) Then
                    romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                Else
                    romaneio.id_estabelecimento = 0
                End If

                romaneio.data_inicio = ViewState.Item("data").ToString

                If ViewState.Item("data_fim").ToString = "" Then
                    romaneio.data_fim = ViewState.Item("data").ToString
                Else
                    romaneio.data_fim = ViewState.Item("data_fim").ToString
                End If
                romaneio.nm_linha_ini = ViewState.Item("cd_rota_ini").ToString
                If ViewState.Item("cd_rota_fim").ToString = "" Then
                    romaneio.nm_linha_fim = ViewState.Item("cd_rota_ini").ToString
                Else
                    romaneio.nm_linha_fim = ViewState.Item("cd_rota_fim").ToString
                End If

                Dim ltotalvolume As Decimal = romaneio.getRomaneioSomaControleLeitebyDia
                ViewState.Item("total_volume") = ltotalvolume

                ViewState.Item("total_leite") = 0
                ViewState.Item("total_creme") = 0

                Dim dsControleLeite As DataSet
                If ViewState.Item("emitirpor") = 1 Then
                    dsControleLeite = romaneio.getRomaneioControleLeite()
                    If gridResults.Rows.Count.ToString + 1 < 65536 Then

                        If (dsControleLeite.Tables(0).Rows.Count > 0) Then
                            'gridResults.Visible = True
                            gridResults.AllowPaging = False
                            gridResults.DataSource = Helper.getDataView(dsControleLeite.Tables(0), ViewState.Item("sortExpression"))
                            gridResults.DataBind()

                            Response.ContentType = "application/vnd.ms-excel" 'fran 20/08/2012
                            Response.AddHeader("content-disposition", "attachment;filename=" & "Relatorio Controle de Leite_Compartimento" & ".xls")
                            Response.Charset = ""
                            EnableViewState = False

                            Dim tw As New System.IO.StringWriter
                            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                            gridResults.RenderControl(hw)
                            HttpContext.Current.Response.Write(tw.ToString())
                            HttpContext.Current.Response.End()
                            gridResults.DataBind()


                        Else
                            gridResults.Visible = False

                        End If

                    Else

                        'messageControl.Alert("A planilha possui muitas linhas, não é possível exportar para o Excel")

                    End If

                Else
                    dsControleLeite = romaneio.getRomaneioControleLeiteByRomaneio()
                    If gridResultsRom.Rows.Count.ToString + 1 < 65536 Then

                        If (dsControleLeite.Tables(0).Rows.Count > 0) Then
                            'gridResults.Visible = True
                            gridResultsRom.AllowPaging = False
                            gridResultsRom.DataSource = Helper.getDataView(dsControleLeite.Tables(0), ViewState.Item("sortExpression"))
                            gridResultsRom.DataBind()

                            Response.ContentType = "application/vnd.ms-excel" 'fran 20/08/2012
                            Response.AddHeader("content-disposition", "attachment;filename=" & "Relatorio Controle de Leite_Romaneio" & ".xls")
                            Response.Charset = ""
                            EnableViewState = False

                            Dim tw As New System.IO.StringWriter
                            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                            gridResultsRom.RenderControl(hw)
                            HttpContext.Current.Response.Write(tw.ToString())
                            HttpContext.Current.Response.End()
                            gridResultsRom.DataBind()


                        Else
                            gridResultsRom.Visible = False

                        End If

                    Else

                        'messageControl.Alert("A planilha possui muitas linhas, não é possível exportar para o Excel")

                    End If

                End If


                ' ''If gridResults.Rows.Count.ToString + 1 < 65536 Then

                ' ''    If (dsControleLeite.Tables(0).Rows.Count > 0) Then
                ' ''        'gridResults.Visible = True
                ' ''        gridResults.AllowPaging = False
                ' ''        gridResults.DataSource = Helper.getDataView(dsControleLeite.Tables(0), ViewState.Item("sortExpression"))
                ' ''        gridResults.DataBind()

                ' ''        Response.ContentType = "application/vnd.ms-excel" 'fran 20/08/2012
                ' ''        Response.AddHeader("content-disposition", "attachment;filename=" & "Relatorio Controle de Leite" & ".xls")
                ' ''        Response.Charset = ""
                ' ''        EnableViewState = False

                ' ''        Dim tw As New System.IO.StringWriter
                ' ''        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                ' ''        gridResults.RenderControl(hw)
                ' ''        HttpContext.Current.Response.Write(tw.ToString())
                ' ''        HttpContext.Current.Response.End()
                ' ''        gridResults.DataBind()


                ' ''    Else
                ' ''        gridResults.Visible = False

                ' ''    End If

                ' ''Else

                ' ''    'messageControl.Alert("A planilha possui muitas linhas, não é possível exportar para o Excel")

                ' ''End If

            Catch ex As Exception
                'messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        'If (e.Row.RowType = DataControlRowType.Header) Then
        '    e.Row.Cells(12).Text = "XX"

        'End If
        Try

            If (e.Row.RowType <> DataControlRowType.Header _
                 And e.Row.RowType <> DataControlRowType.Footer _
                 And e.Row.RowType <> DataControlRowType.Pager) Then

                Dim lvalor_volume As Decimal
                Dim lvalor_creme As Decimal
                Dim lvalor_leite As Decimal
                Dim lvariacao_volume_real As Decimal

                e.Row.Cells(0).Text = e.Row.RowIndex + 1

                '' '' ''Fran rls17 i - A coluna de volume era coluna 9 e passou a ser 11
                '' '' ''A coluna 11 era Leite, mas foi excluida e a coluna 12 era creme e tb foi excluida
                '' '' ''e.Row.Cells(9).Text = 0
                '' '' ''e.Row.Cells(11).Text = 0
                '' '' ''e.Row.Cells(12).Text = 0
                ' '' ''e.Row.Cells(11).Text = 0
                '' '' ''Fran rls 17 f

                ' '' ''lvalor_volume = 0
                ' '' ''lvalor_creme = 0
                ' '' ''lvalor_creme = 0

                '' '' '' Busca Densidade e MG
                ' '' ''Dim lvalor_densidade As Decimal
                ' '' ''Dim lvalor_mg As Decimal

                '' '' ''If IsDBNull(gridResults.DataKeys.Item(e.Row.RowIndex).Value) Then
                ' '' ''If IsDBNull(gridResults.DataKeys.Item(e.Row.RowIndex).Value) Or gridResults.DataKeys.Item(e.Row.RowIndex).Value = 0 Then  ' adri 01/08/2012 chamado 1577 - Se está consultando por Romaneio
                ' '' ''    lvalor_mg = 0 ' adri 01/08/2012 - chamado 1577
                ' '' ''    'fran 17/08/2012 i deve colocar densidade emateria gorada (media caminhao)
                ' '' ''    'lvalor_densidade = 0
                ' '' ''    Dim romaneio As New Romaneio
                ' '' ''    romaneio.id_romaneio = Convert.ToInt64(e.Row.Cells(3).Text) 'romaneio
                ' '' ''    lvalor_densidade = romaneio.getRomaneioCompartimentoMediaDens()
                ' '' ''    'fran 17/08/2012 f deve colocar densidade emateria gorada (media caminhao)

                ' '' ''Else
                ' '' ''    Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento
                ' '' ''    romaneioanalisecompartimento.id_romaneio_compartimento = Convert.ToInt32(gridResults.DataKeys.Item(e.Row.RowIndex).Value)
                ' '' ''    romaneioanalisecompartimento.nm_sigla = "DENS"  ' Densidade
                ' '' ''    lvalor_densidade = romaneioanalisecompartimento.getRomaneioAnaliseValorAnalise()

                ' '' ''    romaneioanalisecompartimento.nm_sigla = "MG"  ' MG
                ' '' ''    lvalor_mg = romaneioanalisecompartimento.getRomaneioAnaliseValorAnalise()
                ' '' ''End If

                '' '' ''Fran rls 17 Coluna densidade era 8 e passa a ser 10 i
                '' '' ''e.Row.Cells(8).Text = FormatNumber(lvalor_densidade, 0)
                '' '' ''e.Row.Cells(8).Text = FormatNumber(lvalor_densidade, 4)  ' 20/01/2009 - Rls15
                ' '' ''e.Row.Cells(10).Text = FormatNumber(lvalor_densidade, 4)
                '' '' ''Fran f

                '' '' ''Fran rls 17 Coluna MG era 10 passa a ser 12  i
                '' '' ''e.Row.Cells(10).Text = FormatNumber(lvalor_mg, 0)
                '' '' ''e.Row.Cells(10).Text = FormatNumber(lvalor_mg, 2)   ' 20/01/2009 - Rls15
                ' '' ''e.Row.Cells(12).Text = FormatNumber(lvalor_mg, 2)   ' 20/01/2009 - Rls15
                '' '' ''Fran rls 17 f

                '' '' ''Calcula Volume
                ' '' ''Dim lpeso As Decimal

                '' '' ''Fran rls17 - coluna pesobalanca de 7 foi para 9 i
                '' '' ''If Trim(e.Row.Cells(7).Text) <> "" Then
                '' '' ''lpeso = Convert.ToDecimal(e.Row.Cells(7).Text)
                ' '' ''If Trim(e.Row.Cells(9).Text) <> "" Then
                ' '' ''    lpeso = Decimal.Truncate(Convert.ToDecimal(e.Row.Cells(9).Text))
                ' '' ''    e.Row.Cells(9).Text = lpeso.ToString
                ' '' ''    'Fran rls17 - coluna pesobalanca de 7 foi para 9 f
                ' '' ''Else
                ' '' ''    lpeso = 0
                ' '' ''End If
                ' '' ''If lvalor_densidade <> 0 Then
                ' '' ''    'Fran rls17 - volume(lts) passa a ser pesobalança * dens
                ' '' ''    'lvalor_volume = Round(lpeso / lvalor_densidade, 4)
                ' '' ''    'lvalor_volume = Round(lpeso * lvalor_densidade, 4)
                ' '' ''    lvalor_volume = Round(lpeso / lvalor_densidade, 4)  ' Adriana 11/01/2011 - chamado 1134
                ' '' ''    'Fran rls 17 f
                ' '' ''Else
                ' '' ''    lvalor_volume = 0
                ' '' ''End If

                '' '' ''Fran rls17 i - Creme foi retirado
                ' '' '' '' Calculo Creme
                '' '' ''If lvalor_mg < 0.001 Then
                '' '' ''    lvalor_creme = 0
                '' '' ''Else
                '' '' ''    lvalor_creme = Round((lvalor_volume * lvalor_mg / 0.4) / 0.9884, 4)
                '' '' ''End If
                '' '' ''Fran rls 17 f

                '' '' ''Fran rls17 - retirada calculo leite i
                '' '' ''Calcula Leite
                '' '' ''lvalor_leite = lvalor_volume - lvalor_leite
                '' '' ''Fran rls17 - retirada calculo leite f

                '' '' ''ViewState.Item("total_volume") = Convert.ToDecimal(ViewState.Item("total_volume")) + Convert.ToDecimal(lvalor_volume)
                '' '' ''Fran rls17 - retirada de leite e creme do gruid i
                '' '' ''ViewState.Item("total_leite") = Convert.ToDecimal(ViewState.Item("total_leite")) + Convert.ToDecimal(lvalor_leite)
                '' '' ''ViewState.Item("total_creme") = Convert.ToDecimal(ViewState.Item("total_creme")) + Convert.ToDecimal(lvalor_creme)
                '' '' ''Fran rls17  f

                '' '' ''Fran rls17 - coluna volume deixa de ser 9 e passa a ser 11 i
                '' '' ''e.Row.Cells(9).Text = FormatNumber(lvalor_volume, 0)
                ' '' ''e.Row.Cells(11).Text = Decimal.Truncate(lvalor_volume).ToString
                '' '' ''Fran rls17 - coluna volume deixa de ser 9 e passa a ser 11 f

                '' '' ''Fran rls17 - retirada de leite e creme do gruid i
                '' '' ''e.Row.Cells(11).Text = FormatNumber(lvalor_leite, 0)
                '' '' ''e.Row.Cells(12).Text = FormatNumber(lvalor_creme, 0)
                '' '' ''Fran rls17 - retirada de leite e creme do gruid f

                '' '' ''fran rls 17 i inclusão da coluna de variacao do volume
                ' '' ''lvariacao_volume_real = Decimal.Truncate(lvalor_volume - CDec(e.Row.Cells(13).Text))
                ' '' ''e.Row.Cells(14).Text = lvariacao_volume_real.ToString
                ' '' ''If Not e.Row.Cells(13).Text.Equals(String.Empty) Then
                ' '' ''    e.Row.Cells(13).Text = Decimal.Truncate(e.Row.Cells(13).Text)
                ' '' ''End If
                ' '' ''If Not e.Row.Cells(13).Text.Equals(String.Empty) Then
                ' '' ''    e.Row.Cells(13).Text = Decimal.Truncate(e.Row.Cells(13).Text)
                ' '' ''End If

                '' '' ''Fran ls 17 f

            End If

            ' '' ''If (e.Row.RowType = DataControlRowType.Footer) Then
            ' '' ''    e.Row.Cells(1).Text = "Total"
            ' '' ''    'Fran rls 17 i 
            ' '' ''    'Ações: coluna 9 passou para 11; as colunas leite e creme foram excluidas; apartir deste rls o total será apurado por procedure pois deve ser visualizado no rodape o total do dia e não o total da pagina
            ' '' ''    'e.Row.Cells(9).Text = Convert.ToString(FormatNumber(ViewState.Item("total_volume"), 0))
            ' '' ''    'e.Row.Cells(11).Text = Convert.ToString(FormatNumber(ViewState.Item("total_leite"), 0))
            ' '' ''    'e.Row.Cells(12).Text = Convert.ToString(FormatNumber(ViewState.Item("total_creme"), 0))

            ' '' ''    e.Row.Cells(11).Text = Convert.ToString(FormatNumber(Decimal.Truncate(Convert.ToDecimal(ViewState.Item("total_volume"))), 0))

            ' '' ''    'Fran rls17 f
            ' '' ''End If
        Catch ex As Exception

            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResultsRom_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsRom.RowDataBound
        Try

            If (e.Row.RowType <> DataControlRowType.Header _
                 And e.Row.RowType <> DataControlRowType.Footer _
                 And e.Row.RowType <> DataControlRowType.Pager) Then

                Dim lbl_id_cooperativa As Label = CType(e.Row.FindControl("lbl_id_cooperativa"), Label)

                Dim lbdescontotransp As Boolean = False

                e.Row.Cells(0).Text = e.Row.RowIndex + 1

                'se o volume rejeitado for 0 limpa o campo
                If e.Row.Cells(16).Text.Equals("0") Then
                    e.Row.Cells(16).Text = String.Empty
                End If

                ''se o volume da balança é maior do que o volume da cadaerneta/nf,
                ''neste caso não emite desconto transportador (se o sinal da variacao for negativo caderneta 'e maior
                'If Not (Sign(CDec(e.Row.Cells(13).Text)) = -1) Or e.Row.Cells(11).Text.Equals("0") Then
                '    lbdescontotransp = False
                'Else
                '    If Sign(CDec(e.Row.Cells(13).Text)) = -1 Then 'se balança valor negativo
                '        lbdescontotransp = True
                '    Else
                '        lbdescontotransp = False
                '    End If
                'End If


                ''se a diferença de volume sem sinal for maior que o percentual de tolerancia deve emitir desconto caso contrario não deve emitir desconto
                'If +Abs(CDec(e.Row.Cells(13).Text)) > CDec(e.Row.Cells(24).Text) Then
                '    lbdescontotransp = True
                'Else
                '    lbdescontotransp = False
                'End If

                ''se for cooperativa nao deve ter desconto transportadr
                'If Not lbl_id_cooperativa.Text.Equals(String.Empty) AndAlso Not lbl_id_cooperativa.Text.Equals("0") Then
                '    lbdescontotransp = False
                'End If

                ''se não deve imprimir, não calcula valor a ser descontado  trasnportador
                'If lbdescontotransp = False Then
                '    e.Row.Cells(25).Text = String.Empty
                'Else
                '    'Valor a ser descontado do transportador (diferença - valor 0,2%
                '    e.Row.Cells(25).Text = Decimal.Truncate(+Abs(CDec(e.Row.Cells(13).Text)) - CDec(e.Row.Cells(24).Text))

                'End If


            End If

        Catch ex As Exception

            messageControl.Alert(ex.Message)
        End Try


    End Sub
End Class
