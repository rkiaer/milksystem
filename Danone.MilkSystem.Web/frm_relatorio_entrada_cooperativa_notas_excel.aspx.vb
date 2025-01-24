Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_relatorio_entrada_cooperativa_notas_excel
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.ContentType = "application/vnd.ms-excel"
        If Not (Request("dt_inicio") Is Nothing) Then
            ViewState.Item("dt_inicio") = Request("dt_inicio")
        End If
        If Not (Request("dt_fim") Is Nothing) Then
            ViewState.Item("dt_fim") = Request("dt_fim")
        End If
        If Not (Request("id_estabelecimento") Is Nothing) Then

            ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
        End If
        Try
            Dim Nota As New NotaFiscal
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                Nota.dt_inicio = Convert.ToString(ViewState.Item("dt_inicio"))
                Nota.dt_fim = Convert.ToString(ViewState.Item("dt_fim"))
            End If
            Nota.id_estabelecimento = ViewState.Item("id_estabelecimento")

            Dim dsNota As DataSet = Nota.getRelatorioEntradaCooperativaNotas

            If (dsNota.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsNota.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()
                Response.AddHeader("content-disposition", "attachment;filename=" & "Relacao_Entrada_Cooperativa_Notas_Fiscais_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")
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

        Catch ex As Exception
        End Try
    End Sub

 
End Class
