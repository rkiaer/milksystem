Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_relatorio_entrada_cooperativa_excel
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
        If Not (Request("id_estabelecimento") Is Nothing) Then

            ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
        End If
        Try
            Dim Nota As New NotaFiscal
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                Nota.dt_inicio = Convert.ToString(ViewState.Item("dt_inicio"))
                Nota.dt_fim = Convert.ToString(ViewState.Item("dt_fim"))
                Nota.dt_referencia = Convert.ToString(ViewState.Item("dt_referencia"))
                Nota.dt_fim_1quinz = String.Concat("15/", Right(ViewState.Item("dt_inicio"), 7))
                Nota.dt_ini_2quinz = String.Concat("16/", Right(ViewState.Item("dt_inicio"), 7))

            End If
            Nota.id_estabelecimento = ViewState.Item("id_estabelecimento")

            Dim dsNota As DataSet = Nota.getRelatorioEntradaCooperativa

            If (dsNota.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                ViewState.Item("diferenca") = "0"
                gridResults.DataSource = Helper.getDataView(dsNota.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()
                Response.AddHeader("content-disposition", "attachment;filename=" & "Relacao_Entrada_Cooperativa" & ".xls")
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

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then
            Dim nr_diferenca As Decimal

            If e.Row.Cells(3).Text = "Total 1.a Quinzena" Then
                ' Coluna 12 - diferença
                nr_diferenca = CDbl(ViewState.Item("diferenca")) + CDbl(e.Row.Cells(12).Text)
                ViewState.Item("diferenca") = nr_diferenca.ToString
            End If
            If e.Row.Cells(3).Text = "Total 2.a Quinzena" Then
                ' Coluna 12 - diferença
                nr_diferenca = CDbl(ViewState.Item("diferenca")) + CDbl(e.Row.Cells(12).Text)
                ViewState.Item("diferenca") = nr_diferenca.ToString
            End If
            If e.Row.Cells(3).Text = "Cálculo Final" Or e.Row.Cells(3).Text = "C&#225;lculo Final" Then
                e.Row.Cells(12).Text = ViewState.Item("diferenca").ToString
                ViewState.Item("diferenca") = "0"
            End If
        End If

    End Sub
End Class
