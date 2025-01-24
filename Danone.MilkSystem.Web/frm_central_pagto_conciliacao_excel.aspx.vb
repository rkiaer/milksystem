Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_central_pagto_conciliacao_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridAbertos.Rows.Count.ToString + 1 < 65536 Then

            Try


                If (Not Request("dt_referencia") Is Nothing) Then
                    ViewState.Item("dt_referencia") = Request("dt_referencia")
                Else
                    ViewState.Item("dt_referencia") = String.Empty
                End If

                If (Not Request("st_pedido_indireto") Is Nothing) Then
                    ViewState.Item("st_pedido_indireto") = Request("st_pedido_indireto")
                Else
                    ViewState.Item("st_pedido_indireto") = "N"
                End If

                If (Not Request("st_todas_referencias") Is Nothing) Then
                    ViewState.Item("st_todas_referencias") = Request("st_todas_referencias")
                Else
                    ViewState.Item("st_todas_referencias") = "N"
                End If

                'acerta visual do grid
                Dim i As Int16
                Dim imes As Int16 = 0
                Dim lauxdata As Date = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("dd/MM/yyyy")
                Dim lauxmesano As Date = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("dd/MM/yyyy")

                'coluna fornecedor
                For i = 20 To 43

                    'Select Case i
                    '    'dia 01
                    '    Case 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60, 64
                    '        gridAbertos.Columns.Item(i).HeaderText = DateAdd(DateInterval.Month, imes, lauxdata).ToString("dd/MM/yy").ToString
                    '        'dia 10
                    '    Case 21, 25, 29, 33, 37, 41, 45, 49, 53, 57, 61, 65
                    '        gridAbertos.Columns.Item(i).HeaderText = DateAdd(DateInterval.Day, 9, DateAdd(DateInterval.Month, imes, lauxdata)).ToString("dd/MM/yy").ToString

                    '        'dia 15
                    '    Case 22, 26, 30, 34, 38, 42, 46, 50, 54, 58, 62, 66
                    '        gridAbertos.Columns.Item(i).HeaderText = DateAdd(DateInterval.Day, 14, DateAdd(DateInterval.Month, imes, lauxdata)).ToString("dd/MM/yy").ToString

                    '        'dia20
                    '    Case 23, 27, 31, 35, 39, 43, 47, 51, 55, 59, 63, 67
                    '        gridAbertos.Columns.Item(i).HeaderText = DateAdd(DateInterval.Day, 19, DateAdd(DateInterval.Month, imes, lauxdata)).ToString("dd/MM/yy").ToString
                    '        imes = imes + 1
                    'End Select
                    'coluna par 
                    If i Mod 2 = 0 Then
                        gridAbertos.Columns.Item(i).HeaderText = DateAdd(DateInterval.Month, imes, lauxdata).ToString("MMM/yy").ToString.ToUpper
                    Else
                        'impar
                        gridAbertos.Columns.Item(i).HeaderText = DateAdd(DateInterval.Month, imes, lauxdata).ToString("MMM/yy").ToString.ToUpper
                        imes = imes + 1

                    End If
                Next

                imes = 0
                'coluna produtor
                For i = 46 To 57
                    gridAbertos.Columns.Item(i).HeaderText = DateAdd(DateInterval.Month, imes, lauxdata).ToString("MMM/yy").ToString.ToUpper
                    imes = imes + 1
                Next

                If ViewState.Item("st_todas_referencias") = "N" Then
                    For i = 22 To 43

                        gridAbertos.Columns.Item(i).Visible = False
                    Next
                End If


                Dim pedido As New Pedido

                pedido.dt_referencia = ViewState.Item("dt_referencia")
                pedido.st_pedido_indireto = ViewState.Item("st_pedido_indireto").ToString

                Dim dspedidos As DataSet = pedido.getCentralPedidoPagtosConciliacao
                gridAbertos.DataSource = Helper.getDataView(dspedidos.Tables(0), "")
                gridAbertos.AllowPaging = False
                gridAbertos.DataBind()


                If gridAbertos.Rows.Count.ToString + 1 < 65536 Then
                    If gridAbertos.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()

                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_RelatorioApoioCentralPagtos_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")

                        Response.Charset = ""
                        EnableViewState = False
                        Controls.Add(frm)
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
