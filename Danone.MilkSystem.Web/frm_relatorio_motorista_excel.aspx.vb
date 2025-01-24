Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_relatorio_motorista_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            Try

                If (Not Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                Else
                    ViewState.Item("id_estabelecimento") = String.Empty
                End If
                If (Not Request("dt_hora_ini") Is Nothing) Then
                    ViewState.Item("dt_hora_ini") = Request("dt_hora_ini")
                Else
                    ViewState.Item("dt_hora_ini") = String.Empty
                End If
                If (Not Request("dt_hora_fim") Is Nothing) Then
                    ViewState.Item("dt_hora_fim") = Request("dt_hora_fim")
                Else
                    ViewState.Item("dt_hora_fim") = String.Empty
                End If
                
                Dim romaneio As New Romaneio

                romaneio.data_inicio = ViewState.Item("dt_hora_ini").ToString
                romaneio.data_fim = ViewState.Item("dt_hora_fim").ToString
                romaneio.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString

                Dim dsMotoristas As DataSet = romaneio.getRomaneioMotoristaByFilters()

                If (dsMotoristas.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsMotoristas.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If


                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_RelatorioMotorista" & ".xls")
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

                    messageControl.Alert("A planilha possui muitas linhas, não é possível exportar para o Excel")

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

End Class
