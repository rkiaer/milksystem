Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_central_pedido_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try

            'BUSCA OS PARAMETROS
            ViewState.Item("id_estabelecimento") = String.Empty
            ViewState.Item("id_pessoa") = String.Empty
            ViewState.Item("id_fornecedor") = String.Empty
            ViewState.Item("id_central_cotacao") = String.Empty
            ViewState.Item("id_central_pedido") = String.Empty
            ViewState.Item("dt_pedido") = String.Empty
            ViewState.Item("cd_pessoa") = String.Empty
            ViewState.Item("cd_fornecedor") = String.Empty
            ViewState.Item("id_item") = String.Empty
            ViewState.Item("cd_item") = String.Empty
            ViewState.Item("id_situacao_pedido") = String.Empty

            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                If Not (Request("id_pessoa") Is Nothing) Then
                    ViewState.Item("id_pessoa") = Request("id_pessoa")
                End If
                If Not (Request("id_fornecedor") Is Nothing) Then
                    ViewState.Item("id_fornecedor") = Request("id_fornecedor")
                End If
                If Not (Request("id_central_cotacao") Is Nothing) Then
                    ViewState.Item("id_central_cotacao") = Request("id_central_cotacao")
                End If
                If Not (Request("id_central_pedido") Is Nothing) Then
                    ViewState.Item("id_central_pedido") = Request("id_central_pedido")
                End If
                If Not (Request("dt_pedido") Is Nothing) Then
                    ViewState.Item("dt_pedido") = Request("dt_pedido")
                End If
                If Not (Request("cd_pessoa") Is Nothing) Then
                    ViewState.Item("cd_pessoa") = Request("cd_pessoa")
                End If
                If Not (Request("cd_fornecedor") Is Nothing) Then
                    ViewState.Item("cd_fornecedor") = Request("cd_fornecedor")
                End If
                If Not (Request("id_item") Is Nothing) Then
                    ViewState.Item("id_item") = Request("id_item")
                End If
                If Not (Request("cd_item") Is Nothing) Then
                    ViewState.Item("cd_item") = Request("cd_item")
                End If
                If Not (Request("id_situacao_pedido") Is Nothing) Then
                    ViewState.Item("id_situacao_pedido") = Request("id_situacao_pedido")
                End If

                'ASSOCIA OS PARAMETROS AO OBJETO PEDIDO
                Dim pedido As New Pedido

                If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                    pedido.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
                Else
                    pedido.id_pessoa = 0
                End If
                If Not (ViewState.Item("id_estabelecimento").Equals(String.Empty)) Then
                    pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                Else
                    pedido.id_estabelecimento = 0
                End If
                If Not (ViewState.Item("id_fornecedor").Equals(String.Empty)) Then
                    pedido.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor").ToString)
                Else
                    pedido.id_fornecedor = 0
                End If
                If Not (ViewState.Item("id_central_pedido").Equals(String.Empty)) Then
                    pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido").ToString)
                Else
                    pedido.id_central_pedido = 0
                End If
                If Not (ViewState.Item("id_central_cotacao").Equals(String.Empty)) Then
                    pedido.id_central_cotacao = Convert.ToInt32(ViewState.Item("id_central_cotacao").ToString)
                Else
                    pedido.id_central_cotacao = 0
                End If
                If Not (ViewState.Item("id_item").Equals(String.Empty)) Then
                    pedido.id_item = Convert.ToInt32(ViewState.Item("id_item").ToString)
                Else
                    pedido.id_item = 0
                End If
                pedido.dt_pedido = ViewState.Item("dt_pedido").ToString
                If Not (ViewState.Item("id_situacao_pedido").Equals(String.Empty)) Then
                    pedido.id_situacao_pedido = Convert.ToInt32(ViewState.Item("id_situacao_pedido").ToString)
                Else
                    pedido.id_situacao_pedido = 0
                End If
                If Not (ViewState.Item("cd_pessoa").Equals(String.Empty)) Then
                    pedido.cd_produtor = ViewState.Item("cd_pessoa").ToString
                Else
                    pedido.cd_produtor = String.Empty
                End If
                If Not (ViewState.Item("cd_fornecedor").Equals(String.Empty)) Then
                    pedido.cd_fornecedor = ViewState.Item("cd_fornecedor").ToString
                Else
                    pedido.cd_fornecedor = String.Empty
                End If
                If Not (ViewState.Item("cd_item").Equals(String.Empty)) Then
                    pedido.cd_item = ViewState.Item("cd_item").ToString
                Else
                    pedido.cd_item = String.Empty
                End If
                ViewState.Item("sortExpression") = "id_central_pedido desc"

                Dim dsPedidoItens As DataSet = pedido.getCentralPedidoseSeusItensbyFilter()

                If (dsPedidoItens.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsPedidoItens.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                End If

                gridResults.AllowPaging = False

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_Pedidos" & ".xls")
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

                    messageControl.Alert(" Planilha possui muitas linhas (mais de 65000), não é possível exportar para o Excel")

                End If
            Else
                messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then
            Try
                Dim entrega As New PedidoEntrega
                entrega.id_central_pedido_item = Convert.ToInt32(e.Row.Cells(17).Text)
                e.Row.Cells(18).Text = entrega.getCentralPedidoEntregaPrimeiraData 'atribui data de entrega
                If e.Row.Cells(18).Text = "01/01/1900" Then
                    e.Row.Cells(18).Text = String.Empty
                End If
                'atribui a cluna valor unitario o valor do frete se o fornecedor for tipo transportador (grupo =3)
                If e.Row.Cells(22).Text.ToString.Trim.Equals("3") Then 'se id do grupo é 3
                    e.Row.Cells(14).Text = e.Row.Cells(21).Text.ToString.Trim  'vl unitario = valor frete
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If

    End Sub
End Class
