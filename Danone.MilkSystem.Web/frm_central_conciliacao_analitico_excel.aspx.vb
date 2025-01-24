Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_central_conciliacao_analitico_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResultsAnalitico.Rows.Count.ToString + 1 < 65536 Then

            Try


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
                If (Not Request("pedidos_abertos") Is Nothing) Then
                    ViewState.Item("chk_pedidos_abertos") = Request("pedidos_abertos")
                Else
                    ViewState.Item("chk_pedidos_abertos") = String.Empty
                End If

                Dim pedido As New Pedido

                pedido.dt_inicio = ViewState.Item("dt_referencia_ini")
                pedido.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_referencia_fim"))))

                If ViewState.Item("chk_pedidos_abertos") = False Then

                    Dim dsPedidoVisaoAnalitica As DataSet = pedido.getCentralConciliacaoContabilidadeAnalitico()

                    gridResultsAnalitico.DataSource = Helper.getDataView(dsPedidoVisaoAnalitica.Tables(0), ViewState.Item("sortExpression"))
                    gridResultsAnalitico.AllowPaging = False
                    gridResultsAnalitico.DataBind()
                Else
                    Dim dsPedidoVisaoAnaliticaAberto As DataSet = pedido.getCentralConciliacaoContabilidadeAnaliticoAbertos()
                    gridAbertos.DataSource = Helper.getDataView(dsPedidoVisaoAnaliticaAberto.Tables(0), ViewState.Item("sortExpression"))
                    gridAbertos.AllowPaging = False
                    gridAbertos.DataBind()
                End If

                If gridResultsAnalitico.Rows.Count.ToString + 1 < 65536 Then
                    If gridResultsAnalitico.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()

                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_RelatorioApoioContabilidade_Analitico" & ".xls")

                        Response.Charset = ""
                        EnableViewState = False
                        Controls.Add(frm)
                        frm.Controls.Add(tb_header)
                        frm.Controls.Add(gridResultsAnalitico)
                        frm.RenderControl(hw)
                        Response.Write(tw.ToString())

                        Response.End()
                        Response.Flush()
                        gridResultsAnalitico.AllowPaging = "True"
                        gridResultsAnalitico.DataBind()
                    End If
                End If

                If gridAbertos.Rows.Count.ToString + 1 < 65536 Then
                    If gridAbertos.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()

                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_RelatorioApoioContabilidade_Analitico_PedidosEmAberto" & ".xls")

                        Response.Charset = ""
                        EnableViewState = False
                        Controls.Add(frm)
                        frm.Controls.Add(tb_header_abertos)
                        frm.Controls.Add(gridAbertos)
                        frm.RenderControl(hw)
                        Response.Write(tw.ToString())

                        Response.End()
                        Response.Flush()
                        gridAbertos.AllowPaging = "True"
                        gridAbertos.DataBind()
                    End If


                End If

            Catch ex As Exception

                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

End Class
