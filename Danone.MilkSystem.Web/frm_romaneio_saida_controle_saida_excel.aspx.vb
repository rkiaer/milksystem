Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_romaneio_saida_controle_saida_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try

            'BUSCA OS PARAMETROS
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
                If Not (Request("id_romaneio_saida") Is Nothing) Then
                    ViewState.Item("id_romaneio_saida") = Request("id_romaneio_saida")  '  
                End If
                If Not (Request("id_romaneio_entrada") Is Nothing) Then
                    ViewState.Item("id_romaneio_entrada") = Request("id_romaneio_entrada")  '  
                End If
                If Not (Request("id_tipo_operacao") Is Nothing) Then
                    ViewState.Item("id_tipo_operacao") = Request("id_tipo_operacao")  '  
                End If
                If Not (Request("id_motivo_saida") Is Nothing) Then
                    ViewState.Item("id_motivo_saida") = Request("id_motivo_saida")  '  
                End If
                If Not (Request("id_item") Is Nothing) Then
                    ViewState.Item("id_item") = Request("id_item")  '  
                End If

                Dim romaneio As New RomaneioSaida
                Dim dsromaneios As DataSet

                If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                    romaneio.dt_inicio = Convert.ToString(ViewState.Item("dt_inicio"))
                End If
                If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                    romaneio.dt_fim = Convert.ToString(ViewState.Item("dt_fim"))
                End If

                romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

                If Not ViewState.Item("id_romaneio_saida").ToString.Equals(String.Empty) Then
                    romaneio.id_romaneio_saida = ViewState.Item("id_romaneio_saida")
                End If
                If Not ViewState.Item("id_romaneio_entrada").ToString.Equals(String.Empty) Then
                    romaneio.id_romaneio_entrada = ViewState.Item("id_romaneio_entrada")
                End If
                If Not ViewState.Item("id_item").ToString.Equals(String.Empty) Then
                    romaneio.id_romaneio_saida = ViewState.Item("id_romaneio_saida")
                End If
                If Not ViewState.Item("id_tipo_operacao").ToString.Equals(String.Empty) Then
                    romaneio.id_tipo_operacao = ViewState.Item("id_tipo_operacao")
                End If
                If Not ViewState.Item("id_motivo_saida").ToString.Equals(String.Empty) Then
                    romaneio.id_motivo_saida = ViewState.Item("id_motivo_saida")
                End If

                dsromaneios = romaneio.getRomaneioSaidaControleSaida


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

                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_RomaneioSaida_ControleSaida" & ".xls")

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
End Class
