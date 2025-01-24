Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_romaneio_excel
    Inherits System.Web.UI.Page

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.ContentType = "application/vnd.ms-excel"
        'If gridResults.Rows.Count.ToString + 1 < 65536 Then
        'fran chamado 899 05/08/2010 i
        'If Not (Request("nm_tecnico") Is Nothing) Then
        '    ViewState.Item("nm_tecnico") = Request("nm_tecnico")
        'End If

        If Not (Request("id_tecnico") Is Nothing) Then
            ViewState.Item("id_tecnico") = Request("id_tecnico")
        End If
        If Not (Request("id_pessoa") Is Nothing) Then
            ViewState.Item("id_pessoa") = Request("id_pessoa")
        Else
            ViewState.Item("id_pessoa") = String.Empty  ' adri 08/08/2012 - Estava dando erro crítico ?????
        End If
        'fran chamado 899 05/08/2010 f
        If Not (Request("cd_pessoa") Is Nothing) Then
            ViewState.Item("cd_pessoa") = Request("cd_pessoa")
        End If
        If Not (Request("dt_fim") Is Nothing) Then
            ViewState.Item("dt_fim") = Request("dt_fim")
        End If
        If Not (Request("dt_inicio") Is Nothing) Then
            ViewState.Item("dt_inicio") = Request("dt_inicio")
        End If
        If Not (Request("id_estabelecimento") Is Nothing) Then
            ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
        End If
        If Not (Request("id_propriedade") Is Nothing) Then
            ViewState.Item("id_propriedade") = Request("id_propriedade")
        End If

        'chamado 1576 - 31/07/2012 - Mirella i
        If Not (Request("cd_codigo_sap") Is Nothing) Then
            ViewState.Item("cd_codigo_sap") = Request("cd_codigo_sap")
        End If
        'chamado 1576 - 31/07/2012 - Mirella f

        If Not (Request("id_romaneio") Is Nothing) Then
            ViewState.Item("id_romaneio") = Request("id_romaneio")
        End If

        If Not (Request("preromaneiotp") Is Nothing) Then
            ViewState.Item("preromaneiotp") = Request("preromaneiotp")
        End If

        Try
            Dim Volume As New ExportaVolume
            'fran chamado 899 05/08/2010 i
            'If Not (ViewState("nm_tecnico").ToString().Equals(String.Empty)) Then
            '    Volume.nm_tecnico = Convert.ToString(ViewState.Item("nm_tecnico"))
            'End If
            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                Volume.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico"))
            End If
            If Not (ViewState("id_pessoa").ToString().Equals(String.Empty)) Then
                Volume.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            'fran chamado 899 05/08/2010 f
            If Not (ViewState("cd_pessoa").ToString().Equals(String.Empty)) Then
                Volume.cd_pessoa = Convert.ToInt32(ViewState.Item("cd_pessoa"))
            End If
            If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                Volume.dt_fim = Convert.ToString(ViewState.Item("dt_fim"))
            End If
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                Volume.dt_inicio = Convert.ToString(ViewState.Item("dt_inicio"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                Volume.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("id_propriedade").ToString().Equals(String.Empty)) Then
                Volume.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If
            'chamado 1576 - 31/07/2012 - Mirella i
            If Not (ViewState("cd_codigo_sap").ToString().Equals(String.Empty)) Then
                Volume.cd_codigo_sap = Convert.ToString(ViewState.Item("cd_codigo_sap"))
            End If
            'chamado 1576 - 31/07/2012 - Mirella f
            If Not (ViewState("id_romaneio").ToString().Equals(String.Empty)) Then
                Volume.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            End If

            Dim ds As DataSet

            If ViewState("preromaneiotp").ToString().Equals("S") Then
                ds = Volume.getExportaVolumeRomaneioTP()
            Else
                ds = Volume.getExportaVolumebyRomaneio()

            End If


            gridResults.Visible = True
            gridResults.DataSource = Helper.getDataView(ds.Tables(0), ViewState.Item("sortExpression"))
            gridResults.AllowPaging = False
            gridResults.DataBind()

            Response.AddHeader("content-disposition", "attachment;filename=" & "ExportarVolumeRomaneio" & ".xls")
            Response.Charset = ""
            EnableViewState = False

            Dim tw As New System.IO.StringWriter
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            gridResults.RenderControl(hw)
            HttpContext.Current.Response.Write(tw.ToString())
            HttpContext.Current.Response.End()
            gridResults.DataBind()


        Catch ex As Exception

            ' messageControl.Alert(ex.Message)
        End Try
        'End If
    End Sub
End Class
