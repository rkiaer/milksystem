Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_transferencia_volume_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            Try

                If (Not Request("dt_referencia") Is Nothing) Then
                    ViewState.Item("dt_referencia") = Request("dt_referencia")

                    If (Not Request("id_propriedade") Is Nothing) Then
                        ViewState.Item("id_propriedade") = Request("id_propriedade")
                    Else
                        ViewState.Item("id_propriedade") = String.Empty
                    End If

                    ViewState.Item("dt_ini") = ViewState.Item("dt_referencia")
                    ViewState.Item("dt_fim") = DateAdd(DateInterval.Month, 1, CDate(ViewState.Item("dt_referencia")))
                    ViewState.Item("dt_fim") = DateAdd(DateInterval.Day, -1, CDate(ViewState.Item("dt_fim")))
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                    Dim transfvolume As New TransferenciaVolume

                    If Not (ViewState.Item("id_propriedade").Equals(String.Empty)) Then
                        transfvolume.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
                    Else
                        transfvolume.id_propriedade = 0
                    End If
                    If Not (ViewState.Item("dt_referencia").Equals(String.Empty)) Then
                        transfvolume.dt_referencia = ViewState.Item("dt_referencia").ToString
                        transfvolume.dt_ini = ViewState.Item("dt_ini").ToString
                        transfvolume.dt_fim = ViewState.Item("dt_fim").ToString
                    Else
                        transfvolume.dt_referencia = String.Empty
                        transfvolume.dt_ini = String.Empty
                        transfvolume.dt_fim = String.Empty
                    End If
                    transfvolume.limite_incentivo = System.Configuration.ConfigurationManager.AppSettings("limite_incentivo").ToString()
                    transfvolume.ano_referencia = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("yyyy")
                    transfvolume.id_estabelecimento = ViewState.Item("id_estabelecimento")
                    Dim dstransfvolume As DataSet = transfvolume.getTransferenciaVolumeByFilters()
                    If (dstransfvolume.Tables(0).Rows.Count > 0) Then
                        gridResults.Visible = True
                        gridResults.DataSource = Helper.getDataView(dstransfvolume.Tables(0), ViewState.Item("sortExpression"))
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
                            Response.AddHeader("content-disposition", "attachment;filename=" & "TransferenciadeVolumesExcel" & ".xls")
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

                        messageControl.Alert("A planilha possui muitas linhas (mais de 65000), não é possível exportar para o Excel")

                    End If

                Else
                    messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")

                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim aux As New InterrupcaoFornecimento
            aux.dt_referencia = ViewState.Item("dt_referencia").ToString
            aux.id_propriedade = e.Row.Cells(4).Text
            If aux.getCalculoDefinitivoByPropriedade > 0 Then 'se tem calculo definitivo para referecia atual
                e.Row.Cells(10).Text = "S"
            Else
                e.Row.Cells(10).Text = "N"
            End If
            e.Row.Cells(7).Text = FormatNumber(e.Row.Cells(7).Text, 0)
            e.Row.Cells(8).Text = FormatNumber(e.Row.Cells(8).Text, 0)
            e.Row.Cells(9).Text = FormatNumber(e.Row.Cells(9).Text, 0)
            e.Row.Cells(0).Text = DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("MM/yyyy")

        End If
    End Sub
End Class
