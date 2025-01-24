Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_relatorio_notasFiscais
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.ContentType = "application/vnd.ms-excel"
        If Not (Request("dt_referencia") Is Nothing) Then
            ViewState.Item("dt_referencia") = Request("dt_referencia")
        End If
        If Not (Request("dt_inicio") Is Nothing) Then
            ViewState.Item("dt_inicio") = Request("dt_inicio")
        End If
        If Not (Request("dt_fim") Is Nothing) Then
            ViewState.Item("dt_fim") = Request("dt_fim")
        End If
        If Not (Request("emitente") Is Nothing) Then

            ViewState.Item("emitente") = Request("emitente")
        End If


        'chamado 1576 - 02/08/2012 - Mirella i
        If Not (Request("cd_codigo_sap") Is Nothing) Then

            ViewState.Item("cd_codigo_sap") = Request("cd_codigo_sap")

        End If
        'chamado 1576 - 02/08/2012 - Mirella f


        Try
            Dim Nota As New NotaFiscalExel
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                Nota.dt_referencia_ini = Convert.ToString(ViewState.Item("dt_inicio"))
                Nota.dt_referencia_fim = Convert.ToString(ViewState.Item("dt_fim"))
                Nota.dt_referencia = Convert.ToString(ViewState.Item("dt_referencia"))
            End If

            'chamado 1576 - 01/08/2012 - Mirella i
            If Not (ViewState("cd_codigo_sap").ToString().Equals(String.Empty)) Then
                Nota.cd_codigo_sap = Convert.ToString(ViewState.Item("cd_codigo_sap"))
            End If
            'chamado 1576 - 01/08/2012 - Mirella f


            If (ViewState.Item("emitente") = 1) Then
                Dim dsNota As DataSet = Nota.getNotaProdutorbyFilters

                If (dsNota.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    'fran 24/01/2011 gko fase 2 i
                    gridResults.Columns(11).Visible = False 'placa
                    gridResults.Columns(12).Visible = False 'variação
                    gridResults.Columns(13).Visible = False 'valor icms
                    'fran 24/01/2011 gko fase 2 f

                    gridResults.DataSource = Helper.getDataView(dsNota.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.AllowPaging = False
                    gridResults.DataBind()
                    Response.AddHeader("content-disposition", "attachment;filename=" & "Relacao_Notas_Fiscais_Produtor" & ".xls")
                    Response.Charset = ""
                    EnableViewState = False

                    Dim tw As New System.IO.StringWriter
                    Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                    gridResults.RenderControl(hw)
                    HttpContext.Current.Response.Write(tw.ToString())
                    HttpContext.Current.Response.End()
                    gridResults.DataBind()

                Else
                    gridResults.Visible = False

                End If
            ElseIf (ViewState.Item("emitente") = 2) Then
                Dim dsNota As DataSet = Nota.getNotaCooperativabyFilters

                If (dsNota.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    'fran 24/01/2011 gko fase 2 i
                    gridResults.Columns(11).Visible = True 'placa
                    gridResults.Columns(12).Visible = True 'variação
                    gridResults.Columns(13).Visible = True 'valor icms
                    'fran 24/01/2011 gko fase 2 f

                    gridResults.DataSource = Helper.getDataView(dsNota.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.AllowPaging = False
                    gridResults.DataBind()
                    Response.AddHeader("content-disposition", "attachment;filename=" & "Relacao_Notas_Fiscais_Cooperativa" & ".xls")
                    Response.Charset = ""
                    EnableViewState = False

                    Dim tw As New System.IO.StringWriter
                    Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                    gridResults.RenderControl(hw)
                    HttpContext.Current.Response.Write(tw.ToString())
                    HttpContext.Current.Response.End()
                    gridResults.DataBind()

                Else
                    gridResults.Visible = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        'fran 24/01/2011 gko fase 2 i

        If (e.Row.RowType <> DataControlRowType.Header _
   And e.Row.RowType <> DataControlRowType.Footer _
   And e.Row.RowType <> DataControlRowType.Pager) Then
            If (ViewState.Item("emitente") = 2) Then
                Dim id_romaneio As Label = CType(e.Row.FindControl("id_romaneio"), Label)
                Dim diferenca_pesagem As Label = CType(e.Row.FindControl("diferenca_pesagem"), Label)
                Dim nr_litros_reais_romaneio As Decimal
                Dim romaneio As New Romaneio

                romaneio.id_romaneio = Convert.ToInt32(id_romaneio.Text)
                Dim nr_mediadens As Decimal = romaneio.getRomaneioCompartimentoMediaDens()

                'litros reais do romaneio = (Pesagem Inicial – Pesagem Final) * Média Dens.	Romaneio
                nr_litros_reais_romaneio = CDbl(diferenca_pesagem.Text) * nr_mediadens

                ' Coluna 12 - Variação = Litros Reais Romaneio - Quantidade de litros da Nota Fiscal 
                e.Row.Cells(12).Text = FormatNumber((nr_litros_reais_romaneio - CDbl(e.Row.Cells(8).Text)), 4)
            End If
        End If

    End Sub
End Class
