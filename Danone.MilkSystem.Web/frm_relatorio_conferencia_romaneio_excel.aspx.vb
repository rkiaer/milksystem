Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_relatorio_conferencia_romaneio_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try

            'BUSCA OS PARAMETROS
            ViewState.Item("dt_inicio") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
            ViewState.Item("id_estabelecimento") = String.Empty

            If Not (Request("dt_inicio") Is Nothing) Then
                If Not (Request("dt_inicio") Is Nothing) Then
                    ViewState.Item("dt_inicio") = Request("dt_inicio")
                End If
                If Not (Request("dt_fim") Is Nothing) Then
                    ViewState.Item("dt_fim") = Request("dt_fim")
                End If
                If Not (Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                End If

                Dim ControleRomaneio As New ExportaAnalise

                If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                    ControleRomaneio.dt_inicio = Convert.ToString(ViewState.Item("dt_inicio"))
                End If
                If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                    ControleRomaneio.dt_fim = Convert.ToString(ViewState.Item("dt_fim"))
                End If

                If Not (ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty)) Then
                    ControleRomaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
                End If

                Dim dsromaneios As DataSet = ControleRomaneio.getRelatorioConferenciaRomaneio()

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
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_ControleEntradaRomaneios" & ".xls")
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

                    messageControl.Alert(" Planilha possui muitas linhas (mais de 65000), não é possível exportar para o Excel")

                End If
            Else
                messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then
            Try
                Dim ds_tempo_rota_minutos As Label = CType(e.Row.FindControl("lbl_ds_tempo_rota_minutos"), Label)

                Select Case CDec(ds_tempo_rota_minutos.Text)
                    Case Is <= 720 ' Até 12 horas (720 minutos)
                        e.Row.Cells(19).BackColor = System.Drawing.Color.FromName("#00C000") 'verde coluna tempo rota
                    Case Is <= 1200
                        e.Row.Cells(19).BackColor = System.Drawing.Color.Yellow 'amarelo coluna tempo rota

                    Case Is > 1200
                        e.Row.Cells(19).BackColor = System.Drawing.Color.Red 'vermelho coluna tempo rota
                End Select


            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If

    End Sub

End Class
