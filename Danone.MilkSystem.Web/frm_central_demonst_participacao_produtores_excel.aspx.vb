Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_central_demonst_participacao_produtores_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            If Not (Request("id_tecnico") Is Nothing) Then
                ViewState.Item("id_tecnico") = Request("id_tecnico")
            End If
            If Not (Request("dt_referencia") Is Nothing) Then
                ViewState.Item("dt_referencia") = Request("dt_referencia")
            End If

            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            End If



            Dim pedido As New Pedido

            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                pedido.id_tecnico = Convert.ToString(ViewState.Item("id_tecnico"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState.Item("dt_referencia").ToString().Equals(String.Empty)) Then
                pedido.ano = ViewState.Item("dt_referencia")

            End If

            pedido.dt_inicio = String.Concat("01/01/", pedido.ano.ToString)
            'pedido.dt_fim = String.Concat("01/", Right("0" + Month(Now).ToString, 2), "/", pedido.ano.ToString) fran maio/2016 não pode pegar now pois qdo gera retroativo o now nao pega ano inteiro
            pedido.dt_fim = String.Concat("01/12/", pedido.ano.ToString)

            Try
                Dim row As DataRow
                Dim dspedido As DataSet = pedido.getParticipacaoProdutores
                Dim dsparticipacaototaiscentral As DataSet = pedido.getParticipacaoProdutoresTotaisCentral

                For Each row In dspedido.Tables(0).Rows

                    Select Case row.Item("periodo")
                        Case 1
                            If dsparticipacaototaiscentral.Tables(0).Select("periodo = 1").Length = 1 Then
                                row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 1")(0).ItemArray(1)
                                row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 1")(0).ItemArray(2)
                                row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 1")(0).ItemArray(3)
                                row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 1")(0).ItemArray(4)
                            End If
                        Case 2
                            If dsparticipacaototaiscentral.Tables(0).Select("periodo = 2").Length = 1 Then
                                row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 2")(0).ItemArray(1)
                                row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 2")(0).ItemArray(2)
                                row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 2")(0).ItemArray(3)
                                row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 2")(0).ItemArray(4)
                            End If
                        Case 3
                            If dsparticipacaototaiscentral.Tables(0).Select("periodo = 3").Length = 1 Then
                                row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 3")(0).ItemArray(1)
                                row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 3")(0).ItemArray(2)
                                row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 3")(0).ItemArray(3)
                                row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 3")(0).ItemArray(4)
                            End If
                        Case 4
                            If dsparticipacaototaiscentral.Tables(0).Select("periodo = 4").Length = 1 Then
                                row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 4")(0).ItemArray(1)
                                row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 4")(0).ItemArray(2)
                                row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 4")(0).ItemArray(3)
                                row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 4")(0).ItemArray(4)
                            End If
                        Case 5
                            If dsparticipacaototaiscentral.Tables(0).Select("periodo = 5").Length = 1 Then
                                row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 5")(0).ItemArray(1)
                                row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 5")(0).ItemArray(2)
                                row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 5")(0).ItemArray(3)
                                row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 5")(0).ItemArray(4)
                            End If
                        Case 6
                            If dsparticipacaototaiscentral.Tables(0).Select("periodo = 6").Length = 1 Then
                                row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 6")(0).ItemArray(1)
                                row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 6")(0).ItemArray(2)
                                row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 6")(0).ItemArray(3)
                                row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 6")(0).ItemArray(4)
                            End If
                        Case 7
                            If dsparticipacaototaiscentral.Tables(0).Select("periodo = 7").Length = 1 Then
                                row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 7")(0).ItemArray(1)
                                row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 7")(0).ItemArray(2)
                                row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 7")(0).ItemArray(3)
                                row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 7")(0).ItemArray(4)
                            End If
                        Case 8
                            If dsparticipacaototaiscentral.Tables(0).Select("periodo = 8").Length = 1 Then
                                row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 8")(0).ItemArray(1)
                                row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 8")(0).ItemArray(2)
                                row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 8")(0).ItemArray(3)
                                row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 8")(0).ItemArray(4)
                            End If
                        Case 9
                            If dsparticipacaototaiscentral.Tables(0).Select("periodo = 9").Length = 1 Then
                                row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 9")(0).ItemArray(1)
                                row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 9")(0).ItemArray(2)
                                row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 9")(0).ItemArray(3)
                                row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 9")(0).ItemArray(4)
                            End If
                        Case 10
                            If dsparticipacaototaiscentral.Tables(0).Select("periodo = 10").Length = 1 Then
                                row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 10")(0).ItemArray(1)
                                row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 10")(0).ItemArray(2)
                                row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 10")(0).ItemArray(3)
                                row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 10")(0).ItemArray(4)
                            End If
                        Case 11
                            If dsparticipacaototaiscentral.Tables(0).Select("periodo = 11").Length = 1 Then
                                row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 11")(0).ItemArray(1)
                                row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 11")(0).ItemArray(2)
                                row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 11")(0).ItemArray(3)
                                row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 11")(0).ItemArray(4)
                            End If
                        Case 12
                            If dsparticipacaototaiscentral.Tables(0).Select("periodo = 12").Length = 1 Then
                                row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 12")(0).ItemArray(1)
                                row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 12")(0).ItemArray(2)
                                row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 12")(0).ItemArray(3)
                                row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 12")(0).ItemArray(4)
                            End If
                    End Select
                Next

                gridResults.DataSource = Helper.getDataView(dspedido.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "Demonstrativo Participacao Produtores" & ".xls")
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
        ' Adri 04/11/2009 - i
        If (e.Row.RowType <> DataControlRowType.Header _
           And e.Row.RowType <> DataControlRowType.Footer _
           And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim data As Date = Convert.ToDateTime(e.Row.Cells(0).Text + "/" + ViewState.Item("dt_referencia"))
            If (e.Row.Cells(0).Text.Trim() > 0) Then
                'e.Row.Cells(0).Text = Format(data, "MMM")fran fase 2 melhoria
                e.Row.Cells(0).Text = Format(data, "MMM/yyyy") 'fran fase 2 melhoria

            End If

            Dim pedido As New Pedido
            Dim nr_percentual As Decimal

            pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            pedido.dt_referencia = "01/" & Month(data) & "/" & ViewState.Item("dt_referencia")
            pedido.dt_inicio = "01/" & Month(data) & "/" & ViewState.Item("dt_referencia")
            pedido.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pedido.dt_inicio)))
            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                'fran 10/05/2010 f chamado 833
                pedido.id_tecnico = Convert.ToString(ViewState.Item("id_tecnico"))
            End If

            ' Faturamento Mensal de todos os Produtores
            e.Row.Cells(1).Text = FormatNumber(pedido.getCentralFaturamentoMesProdutores(), 2)

            ' Volume Mensal de todos os Produtores no mes
            'fran chamado 833 i - 12/05/2010
            'e.Row.Cells(2).Text = FormatNumber(pedido.getCentralVolumeMesProdutores(), 0)
            e.Row.Cells(2).Text = FormatNumber(e.Row.Cells(2).Text, 0)
            'fran chamado 833 i - 12/05/2010

            ' Número de Produtores no mes
            'fran chamado 833 i - 12/05/2010
            'e.Row.Cells(3).Text = FormatNumber(pedido.getCentralQtdMesProdutores(), 0)
            e.Row.Cells(3).Text = FormatNumber(e.Row.Cells(3).Text, 0)
            'fran chamado 833 i - 12/05/2010

            ' Número de Produtores Educampo no mes
            'fran chamado 833 i - 12/05/2010
            'e.Row.Cells(4).Text = FormatNumber(pedido.getCentralQtdMesProdutoresEducampo(), 0)
            e.Row.Cells(4).Text = FormatNumber(e.Row.Cells(4).Text, 0)

            pedido.dt_fim = pedido.dt_inicio 'mesma referencia inico e fim (faz between)

            'e.Row.Cells(9).Text = FormatNumber(pedido.getCentralComprasCentral(), 2)
            'e.Row.Cells(9).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2) 'fran 2016
            'e.Row.Cells(11).Text = FormatNumber(pedido.getCentralVolumeCentral(), 0)

            e.Row.Cells(9).Text = FormatNumber(e.Row.Cells(9).Text, 2) 'fran 2016
            e.Row.Cells(11).Text = FormatNumber(e.Row.Cells(11).Text, 0)

            'fran chamado 833 f - 12/05/2010

            ' Número de Produtores Central no mes
            pedido.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pedido.dt_inicio)))
            'e.Row.Cells(5).Text = FormatNumber(pedido.getCentralQtdMesProdutoresCentral(), 0)
            e.Row.Cells(5).Text = FormatNumber(e.Row.Cells(5).Text, 0)

            ' % Produtores Central no mes
            If Convert.ToDecimal(e.Row.Cells(3).Text) > 0 Then
                nr_percentual = FormatNumber((Convert.ToDecimal(e.Row.Cells(5).Text) / Convert.ToDecimal(e.Row.Cells(3).Text)) * 100, 2)
            Else
                nr_percentual = 0
            End If

            'e.Row.Cells(5).Text = e.Row.Cells(5).Text & "     " & Convert.ToString(nr_percentual) & "%"
            e.Row.Cells(6).Text = Convert.ToString(nr_percentual) & "%"

            ' Número de Produtores Central Educampo no mes
            'e.Row.Cells(7).Text = FormatNumber(pedido.getCentralQtdMesProdutoresCentralEducampo(), 0)
            e.Row.Cells(7).Text = FormatNumber(e.Row.Cells(7).Text, 0)

            ' % Produtores Central Educampo no mes
            If Convert.ToDecimal(e.Row.Cells(4).Text) > 0 Then
                nr_percentual = FormatNumber((Convert.ToDecimal(e.Row.Cells(7).Text) / Convert.ToDecimal(e.Row.Cells(4).Text)) * 100, 2)
            Else
                nr_percentual = 0
            End If

            'e.Row.Cells(6).Text = e.Row.Cells(6).Text & "     " & Convert.ToString(nr_percentual) & "%"
            e.Row.Cells(8).Text = Convert.ToString(nr_percentual) & "%"

            ' % Compras na Central
            If Convert.ToDecimal(e.Row.Cells(1).Text) > 0 Then
                nr_percentual = FormatNumber((Convert.ToDecimal(e.Row.Cells(9).Text) / Convert.ToDecimal(e.Row.Cells(1).Text)) * 100, 2)
            Else
                nr_percentual = 0
            End If

            'e.Row.Cells(7).Text = e.Row.Cells(7).Text & "     " & Convert.ToString(nr_percentual) & "%"
            e.Row.Cells(10).Text = Convert.ToString(nr_percentual) & "%"

            ' % Volume Central
            If Convert.ToDecimal(e.Row.Cells(2).Text) > 0 Then
                nr_percentual = FormatNumber((Convert.ToDecimal(e.Row.Cells(11).Text) / Convert.ToDecimal(e.Row.Cells(2).Text)) * 100, 2)
            Else
                nr_percentual = 0
            End If

            'e.Row.Cells(8).Text = e.Row.Cells(8).Text & "     " & Convert.ToString(nr_percentual) & "%"
            e.Row.Cells(12).Text = Convert.ToString(nr_percentual) & "%"


        End If

    End Sub
End Class
