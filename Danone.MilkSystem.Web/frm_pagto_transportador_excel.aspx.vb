Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_pagto_transportador_excel
    Inherits System.Web.UI.Page

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.ContentType = "application/vnd.ms_excel"


        If gridResults.Rows.Count.ToString + 1 < 65536 Then
            If Not (Request("id_transportador") Is Nothing) Then
                ViewState.Item("id_transportador") = Request("id_transportador")
            End If
            If Not (Request("id_situacao") Is Nothing) Then
                ViewState.Item("id_situacao") = Request("id_situacao")
            End If
            If Not (Request("dt_pagto_ini") Is Nothing) Then
                ViewState.Item("dt_pagto_ini") = Request("dt_pagto_ini")
            End If
            If Not (Request("dt_pagto_fim") Is Nothing) Then
                ViewState.Item("dt_pagto_fim") = Request("dt_pagto_fim")
            End If
            If Not (Request("cd_codigo_sap") Is Nothing) Then
                ViewState.Item("cd_codigo_sap") = Request("cd_codigo_sap")
            End If

            Dim pagtotransp As New PagtoTransportador

            If Trim(ViewState.Item("id_transportador")) <> "" Then
                pagtotransp.id_transportador = Convert.ToInt32(ViewState.Item("id_transportador").ToString)
            End If
            pagtotransp.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            pagtotransp.dt_pagto_ini = ViewState.Item("dt_pagto_ini").ToString
            pagtotransp.dt_pagto_fim = ViewState.Item("dt_pagto_fim").ToString
            pagtotransp.cd_codigo_sap = ViewState.Item("cd_codigo_sap").ToString()
            Dim ds As DataSet = pagtotransp.getPagtoTransportadorByFilters()

            Try
                gridResults.DataSource = Helper.getDataView(ds.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("content-disposition", "attachment;filename=" & "ExportarPagtoFreteTransportador" & ".xls")  ' 07/04/2009 - Rls17.3
                Response.Charset = ""
                EnableViewState = False

                Dim tw As New System.IO.StringWriter
                Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                gridResults.RenderControl(hw)
                HttpContext.Current.Response.Write(tw.ToString())
                HttpContext.Current.Response.End()
                gridResults.DataBind()

            Catch ex As Exception
                'messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
End Class
