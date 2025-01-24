Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_central_demonst_parcelas_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            If Not (Request("id_tecnico") Is Nothing) Then
                ViewState.Item("id_tecnico") = Request("id_tecnico")
            End If

            If Not (Request("id_fornecedor") Is Nothing) Then
                ViewState.Item("id_fornecedor") = Request("id_fornecedor")
            End If
            If Not (Request("id_produtor") Is Nothing) Then
                ViewState.Item("id_produtor") = Request("id_produtor")
            End If
            If Not (Request("dt_referencia") Is Nothing) Then
                ViewState.Item("dt_referencia") = Request("dt_referencia")
            End If

            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            End If

            'fran 10/05/2010 i chamado 830
            If Not (Request("cd_produtor") Is Nothing) Then
                ViewState.Item("cd_produtor") = Request("cd_produtor")
            End If
            If Not (Request("cd_fornecedor") Is Nothing) Then
                ViewState.Item("cd_fornecedor") = Request("cd_fornecedor")
            End If
            'fran 10/05/2010 f chamado 830


            Dim pedido As New Pedido

            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                pedido.id_tecnico = Convert.ToString(ViewState.Item("id_tecnico"))
            End If
            If Not (ViewState("id_produtor").ToString().Equals(String.Empty)) Then
                pedido.id_pessoa = Convert.ToInt32(ViewState.Item("id_produto"))
            End If
            If Not (ViewState("id_fornecedor").ToString().Equals(String.Empty)) Then
                pedido.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If

            If Not (ViewState.Item("dt_referencia").ToString().Equals(String.Empty)) Then
                Dim data_fim As String
                ViewState.Item("dt_inicio") = "01/" + ViewState.Item("dt_referencia")
                data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))) ' Adri
                ViewState.Item("dt_fim") = data_fim
                pedido.dt_inicio = ViewState.Item("dt_inicio")
                pedido.dt_fim = ViewState.Item("dt_fim")
            End If

            'fran 10/05/2010 i chamado 830
            pedido.cd_produtor = ViewState.Item("cd_produtor").ToString
            pedido.cd_fornecedor = ViewState.Item("cd_fornecedor").ToString()
            'fran 10/05/2010 f chamado 830

            Dim dspedido As DataSet = pedido.getParcelamento_Parceiros

            Try
                gridResults.DataSource = Helper.getDataView(dspedido.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                ViewState.Item("totalsaldo") = "0" 'fran 09/12/2010 i

                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "Demonstrativo Parcelas" & ".xls")
                        Response.Charset = ""
                        EnableViewState = False
                        Controls.Add(frm)
                        frm.Controls.Add(gridResults)
                        frm.RenderControl(hw)
                        Response.Write(tw.ToString())
                        Response.End()
                        gridResults.AllowPaging = "True"
                        ViewState.Item("totalsaldo") = "0" 'fran 09/12/2010 i

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
            Dim lbl_calculo As Label = CType(e.Row.FindControl("lbl_calculo"), Label)
            Dim lbl_st_calculo As Label = CType(e.Row.FindControl("lbl_st_calculo"), Label)

            ' Coluna 6 - Nome do Técnico
            'If (e.Row.Cells(6).Text.Trim().Equals("Total")) Then  ' Se é a linha de total, limpa o código do parceiro
            If (e.Row.Cells(4).Text.Trim().Equals("&nbsp;")) OrElse e.Row.Cells(4).Text.Trim().Equals("") Then  ' Se é a linha de total, limpa o código do parceiro
                e.Row.Cells(0).Text = ""
                'e.Row.Cells(13).Text = ViewState.Item("totalsaldo").ToString 'fran 09/12/2010 i
                ViewState.Item("totalsaldo") = "0" 'fran 09/12/2010 i
                lbl_st_calculo.Text = ""
            Else
                'fran 09/12/2010 i
                Dim pedido As New Pedido
                Dim dt_pagto As Label = CType(e.Row.FindControl("dt_pagto"), Label)

                If lbl_calculo.Text.Equals(String.Empty) Then
                    lbl_st_calculo.Text = "N"
                Else
                    lbl_st_calculo.Text = "S"
                End If

                'Dim nrsaldo As Decimal
                'pedido.id_central_pedido = Convert.ToInt32(e.Row.Cells(7).Text.Trim)
                'pedido.dt_fim = dt_pagto.Text.ToString
                'nrsaldo = pedido.getCentralParcelamentoSaldo
                'e.Row.Cells(13).Text = nrsaldo.ToString
                'nrsaldo = CDbl(ViewState.Item("totalsaldo").ToString) + nrsaldo
                'ViewState.Item("totalsaldo") = nrsaldo.ToString
                'fran 09/12/2010 f
            End If

            ' Adri 04/11/2009 - f

        End If

    End Sub
End Class
