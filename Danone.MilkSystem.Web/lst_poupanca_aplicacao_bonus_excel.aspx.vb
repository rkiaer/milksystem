Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class lst_poupanca_aplicacao_bonus_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            End If

            If Not (Request("id_poupanca_parametro") Is Nothing) Then
                ViewState.Item("id_poupanca_parametro") = Request("id_poupanca_parametro")
            End If
            If Not (Request("id_cluster") Is Nothing) Then
                ViewState.Item("id_cluster") = Request("id_cluster")
            End If
            If Not (Request("id_pessoa") Is Nothing) Then
                ViewState.Item("id_pessoa") = Request("id_pessoa")
            End If
            If Not (Request("id_propriedade") Is Nothing) Then
                ViewState.Item("id_propriedade") = Request("id_propriedade")
            End If
            If Not (Request("st_bonus_poupanca_lancamento") Is Nothing) Then
                ViewState.Item("st_bonus_poupanca_lancamento") = Request("st_bonus_poupanca_lancamento")
            End If
            If Not (Request("st_bonus_poupanca_central") Is Nothing) Then
                ViewState.Item("st_bonus_poupanca_central") = Request("st_bonus_poupanca_central")
            End If
            If Not (Request("id_propriedade_titular") Is Nothing) Then
                ViewState.Item("id_propriedade_titular") = Request("id_propriedade_titular")
            End If
            If Not (Request("dt_referencia_ini_poupanca_parametro") Is Nothing) Then
                ViewState.Item("dt_referencia_ini_poupanca_parametro") = Request("dt_referencia_ini_poupanca_parametro")
            End If
            If Not (Request("dt_referencia_fim_poupanca_parametro") Is Nothing) Then
                ViewState.Item("dt_referencia_fim_poupanca_parametro") = Request("dt_referencia_fim_poupanca_parametro")
            End If



            Dim pedido As New Pedido
            Dim dspedido As DataSet

            If Not (ViewState("id_pessoa").ToString().Equals(String.Empty)) Then
                pedido.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                pedido.dt_inicio = ViewState.Item("dt_inicio")
                pedido.dt_fim = ViewState.Item("dt_fim")
            End If
            If ViewState.Item("cbo_tipo").ToString.Equals("1") Then 'se tipo do relatorio é ANALITICO
                dspedido = pedido.getSpendProdutoresAnalitico
            Else
                If ViewState.Item("cbo_tipo").ToString.Equals("2") Then 'se tipo do relatorio é ANALITICO
                    dspedido = pedido.getSpendProdutores
                Else
                    dspedido = pedido.getSpendProdutoresbyEstabelecimento
                End If
            End If

            Try
                If ViewState.Item("cbo_tipo").ToString.Equals("1") Then 'se é tipo analitico
                    gridResults.Columns.Item(3).Visible = True 'propriedade
                    gridResults.Columns.Item(1).Visible = True 'produtor    
                    gridResults.Columns.Item(2).Visible = True 'nome         
                    gridResults.Columns.Item(4).Visible = True 'cluster        
                    gridResults.Columns.Item(5).Visible = True 'tecnico          
                Else
                    If ViewState.Item("cbo_tipo").ToString.Equals("2") Then
                        gridResults.Columns.Item(3).Visible = False 'propriedade
                        gridResults.Columns.Item(1).Visible = True 'produtor    
                        gridResults.Columns.Item(2).Visible = True 'nome         
                        gridResults.Columns.Item(4).Visible = True 'cluster        
                        gridResults.Columns.Item(5).Visible = True 'tecnico          

                    Else
                        gridResults.Columns.Item(1).Visible = False 'produtor    
                        gridResults.Columns.Item(2).Visible = False 'nome         
                        gridResults.Columns.Item(3).Visible = False 'propriedade
                        gridResults.Columns.Item(4).Visible = False 'cluster        
                        gridResults.Columns.Item(5).Visible = False 'tecnico          

                    End If
                End If

                gridResults.DataSource = Helper.getDataView(dspedido.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "Spend Produtores" & ".xls")
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

            Dim lbl_nr_volume As Label = CType(e.Row.FindControl("lbl_nr_volume"), Label)
            Dim lbl_nr_valor_volume_transferencia = CType(e.Row.FindControl("lbl_nr_valor_volume_transferencia"), Label)
            Dim lbl_nr_volume_total As Label = CType(e.Row.FindControl("lbl_nr_volume_total"), Label)
            Dim lbl_nr_valor_compras_central As Label = CType(e.Row.FindControl("lbl_nr_valor_compras_central"), Label)
            Dim lbl_nr_valor_compras_central_transferencia As Label = CType(e.Row.FindControl("lbl_nr_valor_compras_central_transferencia"), Label)
            Dim lbl_nr_valor_compras_central_total As Label = CType(e.Row.FindControl("lbl_nr_valor_compras_central_total"), Label)
            Dim lbl_valor_bonus As Label = CType(e.Row.FindControl("lbl_valor_bonus"), Label)
            Dim lbl_valor_bonus_poupanca As Label = CType(e.Row.FindControl("lbl_valor_bonus_poupanca"), Label)
            Dim lbl_valor_bonus_transf As Label = CType(e.Row.FindControl("lbl_valor_bonus_transf"), Label)
            Dim lbl_nr_valor_spend As Label = CType(e.Row.FindControl("lbl_nr_valor_spend"), Label)
            Dim lbl_nr_bonus_extra_spend As Label = CType(e.Row.FindControl("lbl_nr_bonus_extra_spend"), Label)
            Dim lbl_valor_bonus_central As Label = CType(e.Row.FindControl("lbl_valor_bonus_central"), Label)
            Dim lbl_valor_bonus_extra As Label = CType(e.Row.FindControl("lbl_valor_bonus_extra"), Label)
            Dim nr_tempo_adesao As Integer = CType(e.Row.Cells(6).Text.Trim, Integer)
            Dim dt_bonus_aplicacao As Label = CType(e.Row.FindControl("dt_bonus_aplicacao"), Label)
            Dim st_bonus_central As Label = CType(e.Row.FindControl("st_bonus_central"), Label)
            Dim st_bonus_lancamemto As Label = CType(e.Row.FindControl("st_bonus_lancamento"), Label)
            Dim lbl_id_propriedade As Label = CType(e.Row.FindControl("id_propriedade"), Label)
            Dim lbl_dt_ref_ini_calc As Label = CType(e.Row.FindControl("lbl_dt_ref_ini_calc"), Label)
            Dim dt_referencia_ini As String = CType(e.Row.Cells(8).Text.Trim, String)

            Dim nr_volume_periodo As Decimal
            Dim nr_total_compras_central As Decimal
            Dim nr_valor_bonus As Decimal
            Dim nr_valor_bonus_extra As Decimal
            Dim nr_valor_bonus_transf As Decimal
            Dim nr_volume_transf As Decimal
            Dim nr_compras_central_transf As Decimal

            Dim lbl_id_estabelecimento As Label = CType(e.Row.FindControl("lbl_id_estabelecimento"), Label)

            'Campo estabelecimento
            Select Case CInt(lbl_id_estabelecimento.Text)
                Case 1
                    e.Row.Cells(0).Text = "Poços de Caldas"
                Case 2
                    e.Row.Cells(0).Text = "Guaratinguetá"
                Case 6
                    e.Row.Cells(0).Text = "Águas da Prata"
                Case 9
                    e.Row.Cells(0).Text = "Maracanaú"
                Case Else
                    e.Row.Cells(0).Text = lbl_id_estabelecimento.Text
            End Select

            If lbl_nr_volume.Text.Equals(String.Empty) Then
                nr_volume_periodo = 0
            Else
                nr_volume_periodo = lbl_nr_volume.Text
            End If
            'BUSCA volume de transferencia
            If lbl_nr_valor_volume_transferencia.Text.Equals(String.Empty) Then
                nr_volume_transf = 0
            Else
                nr_volume_transf = lbl_nr_valor_volume_transferencia.Text
            End If

            'Total Volume
            lbl_nr_volume.Text = FormatNumber(lbl_nr_volume.Text, 0)
            lbl_nr_valor_volume_transferencia.Text = FormatNumber(lbl_nr_valor_volume_transferencia.Text, 0)
            lbl_nr_volume_total.Text = FormatNumber(nr_volume_periodo + nr_volume_transf, 0)

            'BUSCA COMPRAS CENTRAL
            If lbl_nr_valor_compras_central.Text.Equals(String.Empty) Then
                nr_total_compras_central = 0
            Else
                nr_total_compras_central = lbl_nr_valor_compras_central.Text
            End If

            'compras central transferencia
            If lbl_nr_valor_compras_central_transferencia.Text.Equals(String.Empty) Then
                nr_compras_central_transf = 0
            Else
                nr_compras_central_transf = lbl_nr_valor_compras_central_transferencia.Text
            End If

            'Valor Total Compra Central
            If Not lbl_nr_valor_compras_central.Text.Equals(String.Empty) Then
                lbl_nr_valor_compras_central.Text = FormatNumber(Round(CDec(lbl_nr_valor_compras_central.Text), 2).ToString)
            End If
            If Not lbl_nr_valor_compras_central_transferencia.Text.Equals(String.Empty) Then
                lbl_nr_valor_compras_central_transferencia.Text = FormatNumber(Round(CDec(lbl_nr_valor_compras_central_transferencia.Text), 2).ToString)
            End If
            If Not lbl_nr_valor_compras_central_transferencia.Text.Equals(String.Empty) OrElse Not lbl_nr_valor_compras_central.Text.Equals(String.Empty) Then
                lbl_nr_valor_compras_central_total.Text = FormatNumber(Round(nr_total_compras_central + nr_compras_central_transf, 2).ToString)
            End If

            'SOMATORIO DAS CONTAS DE BONUS POUPANCA
            If lbl_valor_bonus_poupanca.Text.Equals(String.Empty) Then
                nr_valor_bonus = 0
            Else
                nr_valor_bonus = lbl_valor_bonus_poupanca.Text
            End If

            lbl_valor_bonus.Text = nr_valor_bonus.ToString

            'SOMATORIO DAS CONTAS DE BONUS POUPANCA TRANSFERIDOS
            nr_valor_bonus_transf = lbl_valor_bonus_transf.Text

            nr_valor_bonus = nr_valor_bonus + nr_valor_bonus_transf
            lbl_valor_bonus.Text = nr_valor_bonus

            'valor bonus total
            lbl_valor_bonus.Text = FormatNumber(Round(CDec(lbl_valor_bonus.Text), 2).ToString)

            'valor bonus transferencia
            If Not lbl_valor_bonus_transf.Text.Equals(String.Empty) Then
                lbl_valor_bonus_transf.Text = FormatNumber(Round(CDec(lbl_valor_bonus_transf.Text), 2).ToString)
            End If

            'valor bonus poupanca
            If Not lbl_valor_bonus_poupanca.Text.Equals(String.Empty) Then
                lbl_valor_bonus_poupanca.Text = FormatNumber(Round(CDec(lbl_valor_bonus_poupanca.Text), 2).ToString)
            End If

            'Valor Bonus extra
            nr_valor_bonus_extra = lbl_valor_bonus_extra.Text

            'SPEND
            If (nr_total_compras_central + nr_compras_central_transf) <= 0 Or (nr_volume_periodo + nr_volume_transf) <= 0 Then
                lbl_nr_valor_spend.Text = String.Empty
                lbl_valor_bonus_central.Text = nr_valor_bonus.ToString
            Else
                ''Se o valor do spend do periodo (gastos da central divbidido pelo volume total) for maior ou igual ao parametro especificado, o bonus da poupanca ganha valor extra para ser aplicado na central.
                'lbl_nr_valor_spend.Text = CDec(nr_total_compras_central / nr_volume_periodo).ToString
                lbl_valor_bonus_central.Text = CDec(nr_valor_bonus + nr_valor_bonus_extra).ToString

            End If

            'Valor Spend
            If Not lbl_nr_valor_spend.Text.Equals(String.Empty) Then
                lbl_nr_valor_spend.Text = Round(CDec(lbl_nr_valor_spend.Text), 4).ToString
            End If



            'referencia inicial de poupanca de acordo com regra de calculo: se ficar 1 mes sem entregar leite
            e.Row.Cells(8).Text = DateTime.Parse(e.Row.Cells(8).Text).ToString("MM/yyyy")


            '%
            If Not lbl_nr_bonus_extra_spend.Text.Equals(String.Empty) Then
                lbl_nr_bonus_extra_spend.Text = Round(CDec(lbl_nr_bonus_extra_spend.Text), 2).ToString
            End If
            'bonus extra
            If Not lbl_valor_bonus_extra.Text.Equals(String.Empty) Then
                lbl_valor_bonus_extra.Text = Round(CDec(lbl_valor_bonus_extra.Text), 2).ToString
            End If

            'Bonus na central
            If Not lbl_valor_bonus_central.Text.Equals(String.Empty) Then
                lbl_valor_bonus_central.Text = Round(CDec(lbl_valor_bonus_central.Text), 2).ToString
            End If


        End If



    End Sub

End Class
