Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_relatorio_sif_sintetico_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResultsSintetico.Rows.Count.ToString + 1 < 65536 Then

            Try


                If (Not Request("dt_referencia") Is Nothing) Then
                    ViewState.Item("dt_referencia") = Request("dt_referencia")
                Else
                    ViewState.Item("dt_referencia") = String.Empty
                End If

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

                If (Not Request("id_grupo") Is Nothing) Then
                    ViewState.Item("id_grupo") = Request("id_grupo")
                Else
                    ViewState.Item("id_grupo") = "0"
                End If

                If (Not Request("id_estado") Is Nothing) Then
                    ViewState.Item("id_estado") = Request("id_estado")
                Else
                    ViewState.Item("id_estado") = "0"
                End If

                If (Not Request("nm_cidade") Is Nothing) Then
                    ViewState.Item("nm_cidade") = Request("nm_cidade")
                Else
                    ViewState.Item("nm_cidade") = String.Empty
                End If

                If (Not Request("tiporelatorio") Is Nothing) Then
                    ViewState.Item("tiporelatorio") = Request("tiporelatorio")
                Else
                    ViewState.Item("tiporelatorio") = String.Empty
                End If

                Dim mapasif As New MapaLeite

                mapasif.dt_referencia = ViewState.Item("dt_referencia")
                mapasif.id_estado = ViewState.Item("id_estado")
                mapasif.nm_cidade = ViewState.Item("nm_cidade")
                mapasif.dt_inicio = ViewState.Item("dt_referencia_ini")
                mapasif.dt_fim = ViewState.Item("dt_referencia_fim")
                mapasif.id_grupo = ViewState.Item("id_grupo")

                Dim dsmapa As DataSet = mapasif.getRelatorioSIF

                gridResultsSintetico.DataSource = Helper.getDataView(dsmapa.Tables(0), ViewState.Item("sortExpression"))
                gridResultsSintetico.AllowPaging = False
                gridResultsSintetico.DataBind()

                If gridResultsSintetico.Rows.Count.ToString + 1 < 65536 Then
                    If gridResultsSintetico.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "ReportSIF_Sintetico" & ".xls")
                        Response.Charset = ""
                        EnableViewState = False
                        Controls.Add(frm)
                        frm.Controls.Add(gridResultsSintetico)
                        frm.RenderControl(hw)
                        Response.Write(tw.ToString())
                        Response.End()
                        gridResultsSintetico.AllowPaging = "True"
                        gridResultsSintetico.DataBind()
                    Else

                        messageControl.Alert("Não há linhas a serem exportadas!")
                    End If


                Else

                    messageControl.Alert(" Planilha possui muitas linhas, não é possível exportar para o Excel")

                End If

            Catch ex As Exception

                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub gridResultsSintetico_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsSintetico.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_dt_referencia As Label = CType(e.Row.FindControl("lbl_dt_referencia"), Label)
            Dim lbl_nr_volume As Label = CType(e.Row.FindControl("lbl_nr_volume"), Label)

            lbl_dt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MMM/yyyy")

            If (Not lbl_nr_volume.Text.Equals(String.Empty) And Not lbl_nr_volume.Text = "&nbsp;") Then
                lbl_nr_volume.Text = FormatNumber(lbl_nr_volume.Text, 0).ToString()
            End If
        End If

    End Sub
End Class
