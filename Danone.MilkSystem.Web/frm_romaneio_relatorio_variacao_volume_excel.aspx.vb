Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_romaneio_relatorio_variacao_volume_excel
    Inherits System.Web.UI.Page

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then
            Try
                Dim lbl_matriz As Label = CType(e.Row.FindControl("lbl_matriz"), Label)
                Dim lbl_variacao As Label = CType(e.Row.FindControl("lbl_variacao"), Label)

                'se é matriz
                If Not lbl_matriz.Text.Equals(String.Empty) Then
                    lbl_matriz.Text = "S"
                Else
                    lbl_matriz.Text = "N"
                End If

                If Not lbl_variacao.Text = String.Empty Then

                    Select Case Abs(CDec(lbl_variacao.Text))
                        Case Is <= 2 ' Até 2%
                            'e.Row.Cells(11).BackColor = System.Drawing.Color.White
                        Case Is <= 10 'ate 10%
                            e.Row.Cells(11).BackColor = System.Drawing.Color.Yellow 'amarelo coluna tempo rota
                        Case Is > 10
                            e.Row.Cells(11).BackColor = System.Drawing.Color.Red 'vermelho coluna tempo rota
                    End Select
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.ContentType = "application/vnd.ms-excel"

        If Not (Request("id_tecnico") Is Nothing) Then
            ViewState.Item("id_tecnico") = Request("id_tecnico")
        End If
        If Not (Request("id_pessoa") Is Nothing) Then
            ViewState.Item("id_pessoa") = Request("id_pessoa")
        Else
            ViewState.Item("id_pessoa") = String.Empty  ' adri 08/08/2012 - Estava dando erro crítico ?????
        End If
        If Not (Request("dt_fim") Is Nothing) Then
            ViewState.Item("dt_fim") = Request("dt_fim")
        End If
        If Not (Request("dt_inicio") Is Nothing) Then
            ViewState.Item("dt_inicio") = Request("dt_inicio")
        End If
        If Not (Request("id_estabelecimento") Is Nothing) Then
            ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
        End If
        If Not (Request("id_propriedade") Is Nothing) Then
            ViewState.Item("id_propriedade") = Request("id_propriedade")
        End If

        If Not (Request("cd_codigo_sap") Is Nothing) Then
            ViewState.Item("cd_codigo_sap") = Request("cd_codigo_sap")
        End If

        If Not (Request("id_romaneio") Is Nothing) Then
            ViewState.Item("id_romaneio") = Request("id_romaneio")
        End If

        If Not (Request("preromaneiotp") Is Nothing) Then
            ViewState.Item("preromaneiotp") = Request("preromaneiotp")
        End If

        Try
            Dim Volume As New ExportaVolume
            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                Volume.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico"))
            End If
            If Not (ViewState("id_pessoa").ToString().Equals(String.Empty)) Then
                Volume.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                Volume.dt_fim = Convert.ToString(ViewState.Item("dt_fim"))
            End If
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                Volume.dt_inicio = Convert.ToString(ViewState.Item("dt_inicio"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                Volume.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("id_propriedade").ToString().Equals(String.Empty)) Then
                Volume.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If
            If Not (ViewState("cd_codigo_sap").ToString().Equals(String.Empty)) Then
                Volume.cd_codigo_sap = Convert.ToString(ViewState.Item("cd_codigo_sap"))
            End If
            If Not (ViewState("id_romaneio").ToString().Equals(String.Empty)) Then
                Volume.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            End If

            Dim ds As DataSet

            If ViewState("preromaneiotp").ToString().Equals("S") Then
                ds = Volume.getRomaneioDesvioMarcacaoTP()
            Else
                ds = Volume.getRomaneioDesvioMarcacao()

            End If


            gridResults.Visible = True
            gridResults.DataSource = Helper.getDataView(ds.Tables(0), "")
            gridResults.AllowPaging = False
            gridResults.DataBind()

            'Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_RelatorioRomaneioDesvioMarcacao_" & ".xls")
            'Response.Charset = ""
            'EnableViewState = False

            'Dim tw As New System.IO.StringWriter
            'Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            'gridResults.RenderControl(hw)
            'HttpContext.Current.Response.Write(tw.ToString())
            'HttpContext.Current.Response.End()
            'gridResults.DataBind()

            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                If gridResults.Rows.Count > 0 Then
                    Dim tw As New StringWriter()
                    Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                    Dim frm As HtmlForm = New HtmlForm()
                    Response.ContentType = "application/vnd.ms-excel"
                    Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_RelatorioRomaneioDesvioMarcacao_" & DateTime.Parse(Now()).ToString("ddMMyyyyhhmmss") & ".xls")
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

        Catch ex As Exception

            ' messageControl.Alert(ex.Message)
        End Try
        'End If
    End Sub
End Class
