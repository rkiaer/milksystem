Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_Ficha_excel
    Inherits System.Web.UI.Page

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.ContentType = "application/vnd.ms_excel"
        If gridResults.Rows.Count.ToString + 1 < 65536 Then
            If Not (Request("nm_tecnico") Is Nothing) Then

                ViewState.Item("nm_tecnico") = Request("nm_tecnico")

            End If
            If Not (Request("cd_pessoa") Is Nothing) Then

                ViewState.Item("cd_pessoa") = Request("cd_pessoa")

            End If

            If Not (Request("dt_referencia") Is Nothing) Then

                ViewState.Item("dt_referencia") = Request("dt_referencia")

            End If
            If Not (Request("id_estabelecimento") Is Nothing) Then

                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")

            End If
            If Not (Request("id_propriedade") Is Nothing) Then

                ViewState.Item("id_propriedade") = Request("id_propriedade")

            End If
            ' fran dango 2018
            If Not (Request("st_pagamento") Is Nothing) Then
                ViewState.Item("st_pagamento") = Request("st_pagamento")
            End If

            ' adri 10/05/2012 - chamado 1549 - i
            If Not (Request("tp_pagamento") Is Nothing) Then
                ViewState.Item("tp_pagamento") = Request("tp_pagamento")
            End If
            ' adri 10/05/2012 - chamado 1549 - f



            'chamado 1576 - 01/08/2012 - Mirella i
            If Not (Request("cd_codigo_sap") Is Nothing) Then

                ViewState.Item("cd_codigo_sap") = Request("cd_codigo_sap")

            End If
            'chamado 1576 - 01/08/2012 - Mirella f


            Dim tecnico As New ExportaVolume

            If Not (ViewState("nm_tecnico").ToString().Equals(String.Empty)) Then
                tecnico.nm_tecnico = Convert.ToString(ViewState.Item("nm_tecnico"))
            End If
            If Not (ViewState("cd_pessoa").ToString().Equals(String.Empty)) Then
                tecnico.cd_pessoa = Convert.ToInt32(ViewState.Item("cd_pessoa"))
            End If
            If Not (ViewState("dt_referencia").ToString().Equals(String.Empty)) Then
                tecnico.dt_referencia = Convert.ToString(ViewState.Item("dt_referencia"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                tecnico.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("id_propriedade").ToString().Equals(String.Empty)) Then
                tecnico.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If
            'fran dango 2018
            If Not (ViewState("st_pagamento").ToString().Equals(String.Empty)) Then
                tecnico.st_pagamento = ViewState.Item("st_pagamento").ToString
            End If

            ' adri 06/03/2012 - projeto Themis - Processo de Cálculo unificado por IE - i
            If Not (ViewState("tp_pagamento").ToString().Equals(String.Empty)) Then
                'tecnico.tp_pagamento = Convert.ToInt32(ViewState.Item("tp_pagamento"))
                tecnico.tp_pagamento = ViewState.Item("tp_pagamento").ToString
            End If
            ' adri 06/03/2012 - projeto Themis - Processo de Cálculo unificado por IE - f


            'chamado 1576 - 01/08/2012 - Mirella i
            If Not (ViewState("cd_codigo_sap").ToString().Equals(String.Empty)) Then
                tecnico.cd_codigo_sap = Convert.ToString(ViewState.Item("cd_codigo_sap"))
            End If
            'chamado 1576 - 01/08/2012 - Mirella f


            Dim ds As DataSet = tecnico.getExportaVolumebyFilters()

            Try
                'gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(ds.Tables(0), ViewState.Item("sortExpression"))
                'gridResults.DataBind()
                gridResults.AllowPaging = False
                gridResults.DataBind()

                'Dim tw As New StringWriter()
                'Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                'Dim frm As New HtmlTable

                Response.ContentType = "application/vnd.ms-excel"
                'Response.AddHeader("content-disposition", "attachment;filename=" & "ExportarVolume" & ".xls")
                Response.AddHeader("content-disposition", "attachment;filename=" & "ExportarVolumeFicha" & ".xls")  ' 07/04/2009 - Rls17.3
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
End Class
