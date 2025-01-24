Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_motorista_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            ViewState.Item("cd_cnh") = String.Empty
            ViewState.Item("st_categoria_cnh") = String.Empty
            ViewState.Item("nm_motorista") = String.Empty
            ViewState.Item("id_situacao") = String.Empty

            If Not (Request("cd_cnh") Is Nothing) Then
                ViewState.Item("cd_cnh") = Request("cd_cnh")
            End If
            If Not (Request("st_categoria_cnh") Is Nothing) Then
                ViewState.Item("st_categoria_cnh") = Request("st_categoria_cnh")
            End If
            If Not (Request("nm_motorista") Is Nothing) Then
                ViewState.Item("nm_motorista") = Request("nm_motorista")
            End If

            If Not (Request("id_situacao") Is Nothing) Then
                ViewState.Item("id_situacao") = Request("id_situacao")
            End If

            Dim motorista As New Motorista

            motorista.cd_cnh = ViewState.Item("cd_cnh").ToString()
            motorista.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            motorista.nm_motorista = ViewState.Item("nm_motorista").ToString
            motorista.st_categoria_cnh = ViewState.Item("st_categoria_cnh").ToString

            ViewState.Item("sortExpression") = "nm_motorista asc"

            Dim dsmotorista As DataSet = motorista.getMotoristasByFilters()

            Try
                gridResults.DataSource = Helper.getDataView(dsmotorista.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_Motoristas" & ".xls")
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
        End If
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

    End Sub
End Class
