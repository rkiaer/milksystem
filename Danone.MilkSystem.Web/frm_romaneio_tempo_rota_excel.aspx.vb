Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_romaneio_tempo_rota_excel
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
                If Not (Request("periodo") Is Nothing) Then
                    ViewState.Item("periodo") = Request("periodo")  '  
                End If
                If Not (Request("temporota") Is Nothing) Then
                    ViewState.Item("temporota") = Request("temporota")  '  
                End If
                If Not (Request("tiporomaneio") Is Nothing) Then
                    ViewState.Item("tiporomaneio") = Request("tiporomaneio")  '  
                End If
                If Not (Request("id_romaneio") Is Nothing) Then
                    ViewState.Item("id_romaneio") = Request("id_romaneio")  '  
                End If
                If Not (Request("id_transit_point") Is Nothing) Then
                    ViewState.Item("id_transit_point") = Request("id_transit_point")  '  
                End If
                If Not (Request("id_transvase") Is Nothing) Then
                    ViewState.Item("id_transvase") = Request("id_transvase")  '  
                End If
                If Not (Request("nm_rota") Is Nothing) Then
                    ViewState.Item("nm_rota") = Request("nm_rota")  '  
                End If


                Dim romaneio As New Romaneio

                If ViewState.Item("periodo") = "1" Then 'data de abertura de romaneio
                    If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                        romaneio.dt_hora_entrada_ini = Convert.ToString(ViewState.Item("dt_inicio"))
                    End If
                    If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                        romaneio.dt_hora_entrada_fim = Convert.ToString(ViewState.Item("dt_fim"))
                    End If
                Else 'data de tarnsmissao
                    If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                        romaneio.dt_transmissao_ini = Convert.ToString(ViewState.Item("dt_inicio"))
                    End If
                    If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                        romaneio.dt_transmissao_fim = Convert.ToString(ViewState.Item("dt_fim"))
                    End If

                End If

                romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

                Select Case ViewState.Item("tiporomaneio").ToString
                    Case "0" 'todos
                        romaneio.st_romaneio_transbordo_nulo = "0"
                        romaneio.st_romaneio_transbordo = "S"
                        romaneio.id_st_romaneio_ini = 1
                        romaneio.id_st_romaneio = 12
                        romaneio.id_transit_point = 0


                    Case "N" 'romaneios normais
                        romaneio.st_romaneio_transbordo_nulo = "0" 'traz transbordo nulo
                        romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                        romaneio.id_st_romaneio_ini = 1
                        romaneio.id_st_romaneio = 4
                        romaneio.id_transit_point = -1 'nenhum transit point

                    Case "T" 'transbordo
                        romaneio.st_romaneio_transbordo_nulo = "1" ' nao traz transbordo nulo
                        romaneio.st_romaneio_transbordo = "S" 'apenas trannsbordo S
                        romaneio.id_st_romaneio_ini = 1
                        romaneio.id_st_romaneio = 4
                        romaneio.id_transit_point = -1 'nenhum transit point

                    Case "PRTP" ' pre romaneio transit point
                        romaneio.st_romaneio_transbordo_nulo = "0" 'traz transbordo nulo
                        romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                        romaneio.id_st_romaneio_ini = 7
                        romaneio.id_st_romaneio = 12
                        romaneio.id_transit_point = -1 'nenhum transit point

                    Case "TP" 'trasit point
                        romaneio.st_romaneio_transbordo_nulo = "1" 'nao traz transbordo nulo
                        romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                        romaneio.id_transit_point = 0 'nenhum transit point
                    Case "PRTV" ' pre romaneio pre transvase
                        romaneio.st_romaneio_transbordo_nulo = "0" 'traz transbordo nulo
                        romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                        romaneio.id_st_romaneio_ini = 13
                        romaneio.id_st_romaneio = 17
                        romaneio.id_transvase = -1 'nenhum transvase

                    Case "TV" 'trasvase
                        romaneio.st_romaneio_transbordo_nulo = "1" 'nao traz transbordo nulo
                        romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                        romaneio.id_transvase = 0 'nenhum transvase

                End Select

                If Not ViewState.Item("id_romaneio").ToString.Equals(String.Empty) Then
                    romaneio.id_romaneio = ViewState.Item("id_romaneio") 'nenhum transit point

                End If

                If Not ViewState.Item("id_transit_point").ToString.Equals(String.Empty) Then
                    'se informou transit point, nao pode deixar vir os outros tipos de romaneios, entao forca parametros de TP
                    romaneio.st_romaneio_transbordo_nulo = "1" 'nao traz transbordo nulo
                    romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                    romaneio.id_transit_point = ViewState.Item("id_transit_point") 'nenhum transit point

                End If

                If Not ViewState.Item("id_transvase").ToString.Equals(String.Empty) Then
                    'se informou transvase, nao pode deixar vir os outros tipos de romaneios, entao forca parametros de TP
                    romaneio.st_romaneio_transbordo_nulo = "1" 'nao traz transbordo nulo
                    romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                    romaneio.id_transvase = ViewState.Item("id_transvase") 'nenhum transit point

                End If

                romaneio.nm_linha = ViewState.Item("nm_rota").ToString

                'acerta variavel de tempo rota para buscar os dados do grid
                Select Case ViewState.Item("temporota").ToString
                    Case "0" 'sem seleçao
                        romaneio.nr_tempo_rota_ini = 0
                        romaneio.nr_tempo_rota_fim = 0

                    Case "1" 'ate 12 horas
                        romaneio.nr_tempo_rota_ini = 0
                        romaneio.nr_tempo_rota_fim = 720

                    Case "2" 'entre 12:01 e 20 horas
                        romaneio.nr_tempo_rota_ini = 721
                        romaneio.nr_tempo_rota_fim = 1200

                    Case "3" 'acima de 20 horas
                        romaneio.nr_tempo_rota_ini = 1201
                        romaneio.nr_tempo_rota_fim = 99999
                End Select

                Dim dsRomaneios As DataSet = romaneio.getRomaneioTempoRota()

                If (dsRomaneios.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsRomaneios.Tables(0), ViewState.Item("sortExpression"))
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
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_RomaneioTempoRota" & ".xls")
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
                        e.Row.Cells(14).BackColor = System.Drawing.Color.FromName("#00C000") 'verde coluna tempo rota
                    Case Is <= 1200
                        e.Row.Cells(14).BackColor = System.Drawing.Color.Yellow 'amarelo coluna tempo rota

                    Case Is > 1200
                        e.Row.Cells(14).BackColor = System.Drawing.Color.Red 'vermelho coluna tempo rota
                End Select


            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If

    End Sub

End Class
