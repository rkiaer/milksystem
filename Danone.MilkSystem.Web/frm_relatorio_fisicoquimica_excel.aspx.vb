Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_relatorio_fisicoquimica_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            If Not (Request("data_inicio") Is Nothing) Then
                ViewState.Item("data_inicio") = Request("data_inicio")
            End If

            If Not (Request("data_fim") Is Nothing) Then
                ViewState.Item("data_fim") = Request("data_fim")
            End If
            If Not (Request("nm_linha") Is Nothing) Then
                ViewState.Item("nm_linha") = Request("nm_linha")
            End If
            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            End If

            Dim romaneio As New Romaneio

            romaneio.data_inicio = ViewState.Item("data_inicio").ToString
            romaneio.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
            romaneio.data_fim = ViewState.Item("data_fim").ToString
            romaneio.nm_linha = ViewState.Item("nm_linha").ToString


            Dim dsAnaliseFisicoQuimica As DataSet = romaneio.getRomaneioAnaliseFisicoQuimica()
            Try
                gridResults.DataSource = Helper.getDataView(dsAnaliseFisicoQuimica.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_RelatorioFisicoQuimica" & ".xls")
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

            Dim li As Int32

            
            ' Busca Análises
            Dim lvalor_analise As String
            Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento()
            romaneioanalisecompartimento.id_romaneio_compartimento = Convert.ToInt32(gridResults.DataKeys.Item(e.Row.RowIndex).Item("id_romaneio_compartimento"))
            Dim dsAnalisesCompartimento As DataSet = romaneioanalisecompartimento.getRomaneioAnalisesCompartimentosByFilters()

            li = 0
            For li = 0 To dsAnalisesCompartimento.Tables(0).Rows.Count - 1


                If dsAnalisesCompartimento.Tables(0).Rows(li).Item("id_formato_analise") = 3 Then
                    If IsDBNull(dsAnalisesCompartimento.Tables(0).Rows(li).Item("nr_valor")) Then
                        lvalor_analise = ""
                    Else
                        'Fran 28/08/2009 i rls 18 
                        'lvalor_analise = dsAnalisesCompartimento.Tables(0).Rows(li).Item("nm_analise_logica")
                        Select Case CInt(dsAnalisesCompartimento.Tables(0).Rows(li).Item("nr_valor"))
                            Case 1
                                lvalor_analise = "Neg"
                            Case 2
                                lvalor_analise = "Pos"
                            Case 3
                                lvalor_analise = "Conf"
                            Case 4
                                lvalor_analise = "NConf"
                        End Select
                        'Fran 28/08/2009 f rls 18 


                    End If
                Else
                    If IsDBNull(dsAnalisesCompartimento.Tables(0).Rows(li).Item("nr_valor")) Then
                        lvalor_analise = 0
                    Else
                        lvalor_analise = dsAnalisesCompartimento.Tables(0).Rows(li).Item("nr_valor")
                    End If
                End If
                Select Case UCase(dsAnalisesCompartimento.Tables(0).Rows(li).Item("nm_sigla"))

                    Case "LCR" 'Fran 28/08/2009 i rls19
                        'e.Row.Cells(5).Text = lvalor_analise fran 17/05/2017 inclusao novas analises
                    Case "IDM"
                        'e.Row.Cells(6).Text = lvalor_analise fran 17/05/2017 inclusao novas analises
                    Case "HIM"
                        'e.Row.Cells(7).Text = lvalor_analise fran 17/05/2017 inclusao novas analises
                    Case "LIT"
                        'e.Row.Cells(8).Text = lvalor_analise
                        e.Row.Cells(7).Text = lvalor_analise
                    Case "LIB"
                        e.Row.Cells(8).Text = lvalor_analise
                    Case "LIM"
                        e.Row.Cells(9).Text = lvalor_analise
                    Case "CEA"
                        e.Row.Cells(10).Text = lvalor_analise
                    Case "DENS"
                        e.Row.Cells(12).Text = lvalor_analise
                    Case "MG"
                        'e.Row.Cells(14).Text = lvalor_analise
                        e.Row.Cells(13).Text = FormatNumber(lvalor_analise, 2)  ' 20/01/2009 - Rls15
                    Case "PROT"
                        'e.Row.Cells(15).Text = lvalor_analise
                        e.Row.Cells(14).Text = FormatNumber(lvalor_analise, 2)  ' 20/01/2009 - Rls15
                    Case "EST"
                        'e.Row.Cells(16).Text = lvalor_analise
                        e.Row.Cells(15).Text = FormatNumber(lvalor_analise, 2)  ' 20/01/2009 - Rls15
                    Case "ESD"
                        ' 24/11/2008 - i
                        'e.Row.Cells(17).Text = lvalor_analise
                        ' 20/01/2009 - Rls15 - Desabilitado pois esta análise não é mais preenchida
                        'If IsNumeric(e.Row.Cells(16).Text) And IsNumeric(e.Row.Cells(14).Text) Then
                        '    e.Row.Cells(17).Text = e.Row.Cells(16).Text - e.Row.Cells(14).Text
                        'End If
                        '03/12/2018  i - fran  esd é importado e nao precisa ser calculado
                        e.Row.Cells(16).Text = FormatNumber(lvalor_analise, 2)
                        '03/12/2018  f - fran  esd é importado e nao precisa ser calculado

                        'fran 06/2019 i
                        'Case "ACIDEZ"
                        '    e.Row.Cells(16).Text = lvalor_analise
                    Case "A.L."
                        e.Row.Cells(17).Text = lvalor_analise
                        'fran 06/2019 f
                        'fran 17/05/2017 inclusao novas analises i
                    Case "N. A."
                        e.Row.Cells(18).Text = lvalor_analise
                        'fran 17/05/2017 inclusao novas analises f
                    Case "TEMP"
                        'e.Row.Cells(19).Text = lvalor_analise
                        'e.Row.Cells(19).Text = FormatNumber(lvalor_analise, 2)  ' 20/01/2009 - Rls15
                        e.Row.Cells(19).Text = FormatNumber(lvalor_analise, 1)  ' 12/02/2009 - Rls16
                    Case "ALIZ78"
                        e.Row.Cells(20).Text = lvalor_analise
                    Case "ALIZ74"
                        'e.Row.Cells(21).Text = lvalor_analise fran 17/05/2017 inclusao novas analises
                    Case "CRIOSC"
                        ' 24/11/2008 - i
                        'e.Row.Cells(22).Text = lvalor_analise
                        If IsNumeric(lvalor_analise) Then
                            e.Row.Cells(21).Text = (lvalor_analise / -1000)
                        End If
                        'fran 02/2016 i devol foi retirada para verificar SNAP
                        'Case "DEVOL"
                        '    e.Row.Cells(23).Text = lvalor_analise
                    Case "SNAP"
                        e.Row.Cells(22).Text = lvalor_analise
                        'fran 02/2016 f devol foi retirada para verificar SNAP
                    Case "CHARM"
                        e.Row.Cells(23).Text = lvalor_analise
                    Case "REDUT"
                        e.Row.Cells(24).Text = lvalor_analise
                        'Case "PEROX" fran 17/05/2017 inclusao novas analises
                    Case "PEROXIDO"
                        e.Row.Cells(25).Text = lvalor_analise
                    Case "FOSFAT"
                        e.Row.Cells(26).Text = lvalor_analise
                        'fran 17/05/2017 inclusao novas analises i
                    Case "CLORETO"
                        e.Row.Cells(27).Text = lvalor_analise
                        'fran 17/05/2017 inclusao novas analises f
                    Case "No. Lacres".ToUpper
                        e.Row.Cells(28).Text = lvalor_analise
                    Case "PH"
                        e.Row.Cells(29).Text = lvalor_analise


                End Select

            Next

            '03/12/2018  i - fran  esd é importado e nao precisa ser calculado
            '' 20/01/2009 - Rls15 - Formata coluna 17 - ESD - i ESD = EST - MG
            'If IsNumeric(e.Row.Cells(15).Text) And IsNumeric(e.Row.Cells(13).Text) Then
            '    e.Row.Cells(16).Text = FormatNumber(e.Row.Cells(15).Text - e.Row.Cells(13).Text, 2)
            'End If
            '' 20/01/2009 - Rls15 - Formata coluna 17 - ESD - f
            '03/12/2018  f - fran  esd é importado e nao precisa ser calculado

            If IsNumeric(e.Row.Cells(5).Text) Then
                e.Row.Cells(5).Text = FormatNumber(e.Row.Cells(5).Text, 0)
            End If
            If IsNumeric(e.Row.Cells(28).Text) Then
                e.Row.Cells(28).Text = FormatNumber(e.Row.Cells(28).Text, 0)
            End If

        End If


    End Sub
End Class
