Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_relatorio_central_KPI_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If gridResults.Rows.Count.ToString + 1 < 65536 Then
            If Not (Request("dt_inicio") Is Nothing) Then
                ViewState.Item("dt_inicio") = Request("dt_inicio")
            End If
            If Not (Request("dt_fim") Is Nothing) Then
                ViewState.Item("dt_fim") = Request("dt_fim")
            End If

            If Not (Request("id_item") Is Nothing) Then
                ViewState.Item("id_item") = Request("id_item")
            End If
            If Not (Request("id_categoria") Is Nothing) Then
                ViewState.Item("id_categoria") = Request("id_categoria")
            End If
            If Not (Request("id_canal") Is Nothing) Then
                ViewState.Item("id_canal") = Request("id_canal")
            End If

            If Not (Request("id_fornecedor") Is Nothing) Then
                ViewState.Item("id_fornecedor") = Request("id_fornecedor")
            End If
            If Not (Request("id_produtor") Is Nothing) Then
                ViewState.Item("id_produtor") = Request("id_produtor")
            End If
            If Not (Request("cbo_exibir_kpi_tipo") Is Nothing) Then
                ViewState.Item("cbo_exibir_kpi_tipo") = Request("cbo_exibir_kpi_tipo")
            End If

            If Not (Request("cbo_referencia") Is Nothing) Then
                ViewState.Item("cbo_referencia") = Request("cbo_referencia")
            End If

            Dim pedido As New Pedido

            Dim dscentralKPI As DataSet

            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                pedido.dt_inicio = ViewState.Item("dt_inicio")
                pedido.dt_fim = ViewState.Item("dt_fim")
            End If
            If Not (ViewState("id_item").ToString().Equals(String.Empty)) Then
                pedido.id_item = Convert.ToInt32(ViewState.Item("id_item"))
            End If
            If Not (ViewState("id_categoria").ToString().Equals(String.Empty)) Then
                pedido.id_categoria_item = Convert.ToInt32(ViewState.Item("id_categoria"))
            End If
            If Not (ViewState("id_canal").ToString().Equals(String.Empty)) Then
                pedido.id_canal = Convert.ToInt32(ViewState.Item("id_canal"))
            End If
            If Not (ViewState("id_produtor").ToString().Equals(String.Empty)) Then
                pedido.id_produtor = Convert.ToInt32(ViewState.Item("id_produtor"))
            End If
            If Not (ViewState("id_fornecedor").ToString().Equals(String.Empty)) Then
                pedido.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor"))
            End If


            If ViewState.Item("cbo_referencia").ToString.Equals("P") Then 'se deve exibir por periodo

                Select Case ViewState.Item("cbo_exibir_kpi_tipo").ToString
                    Case "I" 'Exibir apenas itens
                        dscentralKPI = pedido.getRelatorioKPI_ItensPeriodo
                    Case "F" 'Exibir por parceiro
                        dscentralKPI = pedido.getRelatorioKPI_FornecedorItensPeriodo
                    Case "P" 'Exibir por produtor
                        dscentralKPI = pedido.getRelatorioKPI_ProdutorItensPeriodo
                End Select
            Else 'se por referencia
                Select Case ViewState.Item("cbo_exibir_kpi_tipo").ToString
                    Case "I" 'Exibir apenas itens
                        dscentralKPI = pedido.getRelatorioKPI_ItensReferencia
                    Case "F" 'Exibir por parceiro
                        dscentralKPI = pedido.getRelatorioKPI_FornecedorItensReferencia
                    Case "P" 'Exibir por produtor
                        dscentralKPI = pedido.getRelatorioKPI_ProdutorItensReferencia
                End Select
            End If

            Try
                'gridResults.Visible = True

                Select Case ViewState.Item("cbo_exibir_kpi_tipo").ToString
                    Case "I" 'Exibir apenas itens
                        gridResults.Columns.Item(1).Visible = False 'produtor
                        gridResults.Columns.Item(13).Visible = False 'idprodutor
                        gridResults.Columns.Item(2).Visible = False 'parceiro
                        gridResults.Columns.Item(12).Visible = False 'idparceiro
                    Case "F" 'Exibir por parceiro
                        gridResults.Columns.Item(1).Visible = False 'produtor
                        gridResults.Columns.Item(13).Visible = False 'idprodutor
                        gridResults.Columns.Item(2).Visible = True 'parceiro
                        gridResults.Columns.Item(12).Visible = True 'idparceiro
                    Case "P" 'Exibir por produtor
                        gridResults.Columns.Item(1).Visible = True 'produtor
                        gridResults.Columns.Item(13).Visible = True 'idprodutor
                        gridResults.Columns.Item(2).Visible = True 'parceiro
                        gridResults.Columns.Item(12).Visible = True 'idparceiro
                End Select

                gridResults.DataSource = Helper.getDataView(dscentralKPI.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                'Dim tw As New StringWriter()
                'Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                'Dim frm As New HtmlTable

                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("content-disposition", "attachment;filename=" & "ExportarRelatorioCentralKPI" & ".xls")
                Response.Charset = ""
                EnableViewState = False

                Dim tw As New System.IO.StringWriter
                Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                gridResults.RenderControl(hw)
                HttpContext.Current.Response.Write(tw.ToString())
                HttpContext.Current.Response.End()
                'Controls.Add(frm)
                'frm.Controls.Add(gridResults)
                'frm.RenderControl(hw)

                ' Response.Write(tw.ToString())
                'Response.End()

                'gridResults.AllowPaging = "True"
                gridResults.DataBind()

            Catch ex As Exception
                'messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
   
        If (e.Row.RowType <> DataControlRowType.Header _
          And e.Row.RowType <> DataControlRowType.Footer _
          And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_id_item As Label = CType(e.Row.FindControl("lbl_id_item"), Label)
            Dim lbl_id_fornecedor As Label = CType(e.Row.FindControl("lbl_id_fornecedor"), Label)
            Dim lbl_id_produtor As Label = CType(e.Row.FindControl("lbl_id_produtor"), Label)
            Dim lbl_nr_quantidade As Label = CType(e.Row.FindControl("lbl_nr_quantidade"), Label)
            Dim lbl_nr_valor_nf As Label = CType(e.Row.FindControl("lbl_nr_valor_nf"), Label)
            Dim lbl_nr_frete As Label = CType(e.Row.FindControl("lbl_nr_frete"), Label)
            Dim lbl_nr_valor_cif As Label = CType(e.Row.FindControl("lbl_nr_valor_cif"), Label)

            If ViewState.Item("cbo_referencia").Equals("R") Then 'Se for referencia
                e.Row.Cells(0).Text = Mid(e.Row.Cells(0).Text, 4, 7) 'referencia
            End If

            Dim relatorioKPI As New Pedido

            relatorioKPI.dt_inicio = ViewState.Item("dt_inicio").ToString
            relatorioKPI.dt_fim = ViewState.Item("dt_fim").ToString
            relatorioKPI.id_item = lbl_id_item.Text

            If ViewState.Item("cbo_exibir_kpi_tipo").ToString.Equals("F") Then
                relatorioKPI.id_fornecedor = lbl_id_fornecedor.Text
            End If
            If ViewState.Item("cbo_exibir_kpi_tipo").ToString.Equals("P") Then
                relatorioKPI.id_fornecedor = lbl_id_fornecedor.Text
                relatorioKPI.id_produtor = lbl_id_produtor.Text
            End If

            'total quantidade
            lbl_nr_quantidade.Text = Round(relatorioKPI.getRelatorioKPI_ValorQtde, 2).ToString

            'valor frete 
            lbl_nr_frete.Text = Round(relatorioKPI.getRelatorioKPI_ValorFrete, 2).ToString

            'valor cif
            lbl_nr_valor_cif.Text = CDec(lbl_nr_valor_nf.Text) + CDec(lbl_nr_frete.Text)

        End If
        If (e.Row.RowType = DataControlRowType.Footer) Then

            Dim pedido As New Pedido

            pedido.dt_inicio = ViewState.Item("dt_inicio")
            pedido.dt_fim = ViewState.Item("dt_fim")

            If Not (ViewState("id_item").ToString().Equals(String.Empty)) Then
                pedido.id_item = Convert.ToInt32(ViewState.Item("id_item"))
            End If
            If Not (ViewState("id_categoria").ToString().Equals(String.Empty)) Then
                pedido.id_categoria_item = Convert.ToInt32(ViewState.Item("id_categoria"))
            End If
            If Not (ViewState("id_canal").ToString().Equals(String.Empty)) Then
                pedido.id_canal = Convert.ToInt32(ViewState.Item("id_canal"))
            End If
            If Not (ViewState("id_produtor").ToString().Equals(String.Empty)) Then
                pedido.id_produtor = Convert.ToInt32(ViewState.Item("id_produtor"))
            End If
            If Not (ViewState("id_fornecedor").ToString().Equals(String.Empty)) Then
                pedido.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor"))
            End If

            e.Row.Cells(5).Text = "Total"
            e.Row.Cells(6).Text = Round(pedido.getRelatorioKPI_ValorQtde, 2).ToString
            e.Row.Cells(8).Text = Round(pedido.getRelatorioKPI_ValorNota, 2).ToString
            e.Row.Cells(9).Text = Round(pedido.getRelatorioKPI_ValorFrete, 2).ToString
            e.Row.Cells(10).Text = CDec(e.Row.Cells(8).Text) + CDec(e.Row.Cells(9).Text)
        End If
    End Sub


End Class
