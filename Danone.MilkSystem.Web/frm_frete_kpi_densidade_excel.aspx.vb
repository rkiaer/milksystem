Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_frete_kpi_densidade_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            If (Not Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            Else
                ViewState.Item("id_estabelecimento") = "0"
            End If

            If (Not Request("id_frete_periodo") Is Nothing) Then
                ViewState.Item("id_frete_periodo") = Request("id_frete_periodo")
            End If
            ViewState.Item("dt_referencia") = Request("dt_referencia")

            Dim frete As New CalculoFrete

            frete.id_estabelecimento = ViewState.Item("id_estabelecimento")
            If ViewState.Item("dt_referencia").Equals(String.Empty) Then
                frete.dt_referencia = String.Empty
            Else
                frete.dt_referencia = ViewState.Item("dt_referencia").ToString()
            End If
            frete.id_frete_periodo = ViewState.Item("id_frete_periodo").ToString

            Dim dsfrete As DataSet = frete.getFreteKpiDensidade
            ViewState.Item("totalkmfrete") = CDec(dsfrete.Tables(0).Rows(0).Item("totalkmfrete"))
            ViewState.Item("totalvolume") = CDec(dsfrete.Tables(0).Rows(0).Item("totalvolume"))
            ViewState.Item("totalplaca1") = CDec(dsfrete.Tables(0).Rows(0).Item("totalplaca1"))
            ViewState.Item("totalplaca2") = CDec(dsfrete.Tables(0).Rows(0).Item("totalplaca2"))
            ViewState.Item("totalcapacidadetotal") = CDec(dsfrete.Tables(0).Rows(0).Item("totalcapacidadetotal"))

            gridResults.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
            gridResults.AllowPaging = False
            gridResults.DataBind()

            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                If gridResults.Rows.Count > 0 Then
                    Dim tw As New StringWriter()
                    Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                    Dim frm As HtmlForm = New HtmlForm()
                    Response.ContentType = "application/vnd.ms-excel"
                    Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_FreteKPIDensidade_" & DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MMMyyyy").ToUpper & "_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")
                    Response.Charset = ""
                    EnableViewState = False
                    Controls.Add(frm)
                    frm.Controls.Add(gridResults)
                    frm.RenderControl(hw)
                    Response.Write(tw.ToString())
                    Response.End()
                    gridResults.AllowPaging = "True"
                    gridResults.DataBind()
                Else
                    messageControl.Alert("Não há linhas a serem exportadas!")
                End If
            Else
                messageControl.Alert(" Planilha possui muitas linhas, não é possível exportar para o Excel")
            End If



        Catch ex As Exception

            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound


        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

        Else
            If e.Row.RowType = DataControlRowType.Footer Then

                e.Row.Cells(11).Text = FormatNumber(ViewState.Item("totalplaca1"), 0)
                e.Row.Cells(13).Text = FormatNumber(ViewState.Item("totalplaca2"), 0)
                e.Row.Cells(14).Text = FormatNumber(ViewState.Item("totalvolume"), 0)
                e.Row.Cells(15).Text = FormatNumber(ViewState.Item("totalkmfrete"), 0)
                e.Row.Cells(16).Text = FormatNumber(ViewState.Item("totalcapacidadetotal"), 0)
                e.Row.Cells(17).Text = FormatNumber(ViewState.Item("totalvolume") / ViewState.Item("totalkmfrete"), 0)
                e.Row.Cells(18).Text = FormatNumber((ViewState.Item("totalvolume") * 100) / ViewState.Item("totalcapacidadetotal"), 2)

            End If

        End If
    End Sub

End Class
