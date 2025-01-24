Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_central_relacao_produtores_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            If Not (Request("cbo_tipo") Is Nothing) Then
                ViewState.Item("cbo_tipo") = Request("cbo_tipo")
            End If

            If Not (Request("id_pessoa") Is Nothing) Then
                ViewState.Item("id_pessoa") = Request("id_pessoa")
            End If
            If Not (Request("dt_inicio") Is Nothing) Then
                ViewState.Item("dt_inicio") = Request("dt_inicio")
            End If
            If Not (Request("dt_fim") Is Nothing) Then
                ViewState.Item("dt_fim") = Request("dt_fim")
            End If

            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
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
                    'gridResults.Columns.Item(5).Visible = True 'tecnico          
                Else
                    If ViewState.Item("cbo_tipo").ToString.Equals("2") Then
                        gridResults.Columns.Item(3).Visible = False 'propriedade
                        gridResults.Columns.Item(1).Visible = True 'produtor    
                        gridResults.Columns.Item(2).Visible = True 'nome         
                        gridResults.Columns.Item(4).Visible = True 'cluster        
                        'gridResults.Columns.Item(5).Visible = True 'tecnico          

                    Else
                        gridResults.Columns.Item(1).Visible = False 'produtor    
                        gridResults.Columns.Item(2).Visible = False 'nome         
                        gridResults.Columns.Item(3).Visible = False 'propriedade
                        gridResults.Columns.Item(4).Visible = False 'cluster        
                        'gridResults.Columns.Item(5).Visible = False 'tecnico          

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
                        'Response.AddHeader("content-disposition", "attachment;filename=" & "Spend Produtores" & ".xls")
                        Select Case ViewState.Item("cbo_tipo").ToString
                            Case "1"
                                Response.AddHeader("content-disposition", "attachment;filename=" & "Spend_Produtores_Analitico" & ".xls")

                            Case "2"
                                Response.AddHeader("content-disposition", "attachment;filename=" & "Spend_Produtores_Sintetico" & ".xls")
                            Case "3"
                                Response.AddHeader("content-disposition", "attachment;filename=" & "Spend_Produtores_Sintetico_Estabelecimento" & ".xls")
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

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
           And e.Row.RowType <> DataControlRowType.Footer _
           And e.Row.RowType <> DataControlRowType.Pager) Then

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

            'referencia
            e.Row.Cells(5).Text = DateTime.Parse(e.Row.Cells(5).Text).ToString("MM/yyyy")

            ''Valor Total da Nota
            'e.Row.Cells(6).Text = Round(CDec(e.Row.Cells(6).Text), 2).ToString

            ''Total Volume
            'e.Row.Cells(7).Text = FormatNumber(e.Row.Cells(7).Text, 0)

            ''Valor Total Compra Central
            'e.Row.Cells(8).Text = Round(CDec(e.Row.Cells(8).Text), 2).ToString

            ''Valor Spend
            'e.Row.Cells(9).Text = Round(CDec(e.Row.Cells(9).Text), 4).ToString


        End If

    End Sub
End Class
