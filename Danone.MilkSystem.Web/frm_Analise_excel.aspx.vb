Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_Analise_excel
    Inherits System.Web.UI.Page

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.ContentType = "application/vnd.ms_excel"
        If gridResults.Rows.Count.ToString + 1 < 65536 Then
            If Not (Request("dt_inicio") Is Nothing) Then

                ViewState.Item("dt_inicio") = Request("dt_inicio")

            End If
            If Not (Request("cd_pessoa") Is Nothing) Then

                ViewState.Item("cd_pessoa") = Request("cd_pessoa")

            End If

            If Not (Request("dt_fim") Is Nothing) Then

                ViewState.Item("dt_fim") = Request("dt_fim")

            End If

            'Fran 27/11/2009 i chamado 527 Maracanau
            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            End If
            'Fran 27/11/2009 f chamado 527 Maracanau


            Dim Analise As New ExportaAnalise

            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                Analise.dt_inicio = Convert.ToString(ViewState.Item("dt_inicio"))
            End If
            If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                Analise.dt_fim = Convert.ToString(ViewState.Item("dt_fim"))
            End If
            'Fran 27/11/2009 i chamado 527 Maracanau
            If Not (ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty)) Then
                Analise.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            'Fran 27/11/2009 f chamado 527 Maracanau

            Dim ds As DataSet = Analise.getExportaAnalisebyFilters()

            Try
                'gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(ds.Tables(0), ViewState.Item("sortExpression"))
                'gridResults.DataBind()
                gridResults.AllowPaging = False
                gridResults.DataBind()
                'Fran 27/11/2009 I chamado 527 Maracanau
                'gridResults.Columns.Item(5).Visible = False
                'Fran 27/11/2009 f chamado 527 Maracanau

                'Dim tw As New StringWriter()
                'Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                'Dim frm As New HtmlTable

                Response.ContentType = "application/vnd.ms-excel"
                Response.AddHeader("content-disposition", "attachment;filename=" & "ExportarAnalise" & ".xls")
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
