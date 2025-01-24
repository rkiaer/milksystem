Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_romaneio_controle_frete_excel
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
                If Not (Request("id_grupo") Is Nothing) Then
                    ViewState.Item("id_grupo") = Request("id_grupo")  '  
                End If
                If Not (Request("id_transit_point") Is Nothing) Then
                    ViewState.Item("id_transit_point") = Request("id_transit_point")  '  
                End If
                If Not (Request("id_transvase") Is Nothing) Then
                    ViewState.Item("id_transvase") = Request("id_transvase")  '  
                End If
                If Not (Request("id_pre_romaneio") Is Nothing) Then
                    ViewState.Item("id_pre_romaneio") = Request("id_pre_romaneio")  '  
                End If
                If Not (Request("id_romaneio") Is Nothing) Then
                    ViewState.Item("id_romaneio") = Request("id_romaneio")  '  
                End If
                If Not (Request("nm_linha") Is Nothing) Then
                    ViewState.Item("nm_linha") = Request("nm_linha")  '  
                End If
                If Not (Request("id_cooperativa") Is Nothing) Then
                    ViewState.Item("id_cooperativa") = Request("id_cooperativa")  '  
                End If


                Dim romaneio As New Romaneio
                Dim dsromaneios As DataSet

                If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                    romaneio.dt_hora_entrada_ini = Convert.ToString(ViewState.Item("dt_inicio"))
                End If
                If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                    romaneio.dt_hora_entrada_fim = Convert.ToString(ViewState.Item("dt_fim"))
                End If

                romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

                If Not ViewState.Item("id_romaneio").ToString.Equals(String.Empty) Then
                    romaneio.id_romaneio = ViewState.Item("id_romaneio")
                End If

                'se cooperativa
                If ViewState.Item("id_grupo").ToString.Equals("4") Then

                    If Trim(ViewState.Item("id_cooperativa")) <> "" Then
                        romaneio.id_cooperativa = Convert.ToInt32(ViewState.Item("id_cooperativa").ToString)
                    End If

                    dsromaneios = romaneio.getRomaneioControleFreteCooperativa
                Else

                    If Not ViewState.Item("id_transit_point").ToString.Equals(String.Empty) Then
                        romaneio.id_transit_point = ViewState.Item("id_transit_point")
                    End If
                    If Not ViewState.Item("id_transvase").ToString.Equals(String.Empty) Then
                        romaneio.id_transit_point = ViewState.Item("id_transvase")
                    End If
                    If Not ViewState.Item("id_pre_romaneio").ToString.Equals(String.Empty) Then
                        romaneio.id_pre_romaneio_transit_point = ViewState.Item("id_pre_romaneio")
                    End If
                    romaneio.nm_linha = ViewState.Item("nm_linha").ToString

                    dsromaneios = romaneio.getRomaneioControleFrete
                End If


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
                        'se cooperativa
                        If ViewState.Item("id_grupo").ToString.Equals("4") Then 'se coopertaiva
                            Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_ControleFreteCooperativa" & ".xls")
                        Else
                            Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_ControleFreteProdutor" & ".xls")
                        End If
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

                'romaneio
                If e.Row.Cells(2).Text = "0" Then
                    e.Row.Cells(2).Text = String.Empty
                End If
                'transit
                If e.Row.Cells(3).Text = "0" Then
                    e.Row.Cells(3).Text = String.Empty
                End If
                'trnasvase
                If e.Row.Cells(4).Text = "0" Then
                    e.Row.Cells(4).Text = String.Empty
                End If
                'pre romaneio
                If e.Row.Cells(5).Text = "0" Then
                    e.Row.Cells(5).Text = String.Empty
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If

    End Sub
End Class
