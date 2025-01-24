Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_frete_kpi_custos_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            If (Not Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            Else
                ViewState.Item("id_estabelecimento") = "0"
            End If

            If (Not Request("ano") Is Nothing) Then
                ViewState.Item("ano") = Request("ano")
            End If

            Dim frete As New CalculoFrete

            frete.id_estabelecimento = ViewState.Item("id_estabelecimento")
            frete.nr_ano = ViewState.Item("ano").ToString

            Dim dsfrete As DataSet = frete.getFreteKpiCustos

            gridResults.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
            gridResults.AllowPaging = False
            gridResults.DataBind()

            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                If gridResults.Rows.Count > 0 Then
                    Dim tw As New StringWriter()
                    Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                    Dim frm As HtmlForm = New HtmlForm()
                    Response.ContentType = "application/vnd.ms-excel"
                    Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_FreteKPICustos_" & ViewState.Item("ano").ToString & "_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")
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


End Class
