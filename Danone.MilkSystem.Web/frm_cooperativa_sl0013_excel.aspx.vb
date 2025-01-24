Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_cooperativa_sl0013_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try

            'BUSCA OS PARAMETROS
            ViewState.Item("dt_ini") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
            ViewState.Item("id_estabelecimento") = String.Empty
            ViewState.Item("id_cooperativa") = String.Empty
            ViewState.Item("tipo") = String.Empty

            If Not (Request("data_ini") Is Nothing) Then
                If Not (Request("data_ini") Is Nothing) Then
                    ViewState.Item("dt_ini") = Request("data_ini")
                End If
                If Not (Request("data_fim") Is Nothing) Then
                    ViewState.Item("dt_fim") = Request("data_fim")
                End If
                If Not (Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                End If
                If Not (Request("tipo") Is Nothing) Then
                    ViewState.Item("tipo") = Request("tipo")  '  
                End If
                If Not (Request("id_cooperativa") Is Nothing) Then
                    ViewState.Item("id_cooperativa") = Request("id_cooperativa")  '  
                End If


                Dim romaneio As New Romaneio
                Dim dsromaneios As DataSet

                If Not (ViewState("dt_ini").ToString().Equals(String.Empty)) Then
                    romaneio.data_inicio = Convert.ToString(ViewState.Item("dt_ini"))
                End If
                If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                    romaneio.data_fim = Convert.ToString(ViewState.Item("dt_fim"))
                End If

                romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

                If Trim(ViewState.Item("id_cooperativa")) <> "" Then
                    romaneio.id_cooperativa = Convert.ToInt32(ViewState.Item("id_cooperativa").ToString)
                End If

                If ViewState.Item("tipo").ToString.Equals("A") Then


                    dsromaneios = romaneio.getRomaneioSL0013
                    If (dsromaneios.Tables(0).Rows.Count > 0) Then
                        gridResults.Visible = True
                        gridResults.DataSource = Helper.getDataView(dsromaneios.Tables(0), ViewState.Item("sortExpression"))
                        gridResults.DataBind()
                    Else
                        gridResults.Visible = False
                        'messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If


                    gridResults.AllowPaging = False

                    If gridResults.Rows.Count.ToString + 1 < 65536 Then
                        If gridResults.Rows.Count > 0 Then
                            Dim tw As New StringWriter()
                            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                            Dim frm As HtmlForm = New HtmlForm()
                            Response.ContentType = "application/vnd.ms-excel"
                            Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_SL0013Analtico_" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".xls")
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

                        messageControl.Alert("Planilha possui muitas linhas (mais de 65000), não é possível exportar para o Excel")

                    End If

                Else

                    dsromaneios = romaneio.getRomaneioSL0013Sintetico
                    If (dsromaneios.Tables(0).Rows.Count > 0) Then
                        gridResultsSint.Visible = True
                        gridResultsSint.DataSource = Helper.getDataView(dsromaneios.Tables(0), ViewState.Item("sortExpression"))
                        gridResultsSint.DataBind()
                    Else
                        gridResultsSint.Visible = False
                        'messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If


                    gridResultsSint.AllowPaging = False

                    If gridResultsSint.Rows.Count.ToString + 1 < 65536 Then
                        If gridResultsSint.Rows.Count > 0 Then
                            Dim tw As New StringWriter()
                            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                            Dim frm As HtmlForm = New HtmlForm()
                            Response.ContentType = "application/vnd.ms-excel"
                            Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_SL0013Sintetico_" & DateTime.Now.ToString("ddMMyyyyHHmmss") & ".xls")
                            Response.Charset = ""
                            EnableViewState = False
                            Controls.Add(frm)
                            frm.Controls.Add(gridResultsSint)
                            frm.RenderControl(hw)
                            Response.Write(tw.ToString())
                            Response.End()
                            gridResults.AllowPaging = "True"
                            gridResults.DataBind()
                        Else

                            messageControl.Alert("Não há linhas a serem exportadas!")
                        End If


                    Else

                        messageControl.Alert("Planilha possui muitas linhas (mais de 65000), não é possível exportar para o Excel")

                    End If
                End If


            Else
                messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


End Class
