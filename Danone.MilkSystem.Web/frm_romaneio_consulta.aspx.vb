Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_romaneio_consulta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_consulta.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                ViewState.Item("placa_ativa") = 0 'Assume que a placa ativa é a da 1a aba

                Dim romaneio As New Romaneio(ViewState.Item("id_romaneio"))

                loadData()
            Else
                loadFilters()
                If ViewState.Item("id_romaneio").Equals(String.Empty) Then
                    messageControl.Alert("Há problemas na passagem de parametros. A tela não pode ser montada!")
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim romaneio As New Romaneio(id_romaneio)

            lbl_placa.Text = romaneio.ds_placa.ToString   ' 28/09/2009 - Adriana Rls21 Frete

            'Se é um romaneio com entrada de produtores
            If romaneio.nr_caderneta > 0 Then
                ViewState.Item("cooperativa") = "N"
                tr_pnl_dados_cooperativa.Visible = False
                If Not romaneio.nr_nota_fiscal_transf Is Nothing Then
                    If Not romaneio.nr_nota_fiscal_transf.Equals(String.Empty) Then
                        tr_pnl_nota_fiscal_transferencia.Visible = True
                        tr_diferenca_nf_transferencia.Visible = True
                        lbl_nr_nota_fiscal_transf.Text = romaneio.nr_nota_fiscal_transf
                        lbl_serie_nota_fiscal_transf.Text = romaneio.nr_serie_nota_fiscal_transf
                        If Not (romaneio.dt_emissao_nota_transf Is Nothing) Then
                            If Not (romaneio.dt_emissao_nota_transf.ToString.Equals(String.Empty)) Then
                                lbl_dt_emissao_nota.Text = Format(DateTime.Parse(romaneio.dt_emissao_nota_transf), "dd/MM/yyyy").ToString
                            End If
                        End If
                        If romaneio.nr_peso_liquido_nota_transf > 0 Then
                            lbl_nr_peso_liquido_nota_transf.Text = romaneio.nr_peso_liquido_nota_transf
                        End If
                    Else
                        tr_pnl_nota_fiscal_transferencia.Visible = False
                        tr_diferenca_nf_transferencia.Visible = False
                    End If
                Else
                    tr_pnl_nota_fiscal_transferencia.Visible = False
                    tr_diferenca_nf_transferencia.Visible = False
                End If
                lbl_litros_caderneta_nf.Text = romaneio.nr_peso_liquido_caderneta
                lbl_caderneta.Text = romaneio.nr_caderneta.ToString
                'Fran 19/10/2009 i chamado 477
                hl_nr_caderneta.Text = romaneio.nr_caderneta.ToString
                hl_nr_caderneta.NavigateUrl = String.Format("frm_caderneta.aspx?nr_caderneta={0}", romaneio.nr_caderneta)
                'Fran 19/10/2009 f chamado 477

                lbl_peso_liquido_caderneta.Text = FormatNumber(romaneio.nr_peso_liquido_caderneta, 0).ToString
                lbl_tipoleite.Text = romaneio.nm_item

                ' 28/09/2009 - Adriana Rls21 Frete - i  (o coletor deve gravar esta tabela também)
                Dim caderneta As New Caderneta
                caderneta.currentidentity = romaneio.nr_caderneta
                Dim dsCaderneta As DataSet = caderneta.getCadernetaNovaPlaca()
                If dsCaderneta.Tables(0).Rows.Count > 0 Then
                    lbl_placa_frete.Text = dsCaderneta.Tables(0).Rows(0).Item("ds_placa_frete")
                End If
                ' 28/09/2009 - Adriana Rls21 Frete - i
                'fran tempo rota dez/2018 i
                'SE for pre romaneio transbordo nao deixa visualizar tempo rota
                If romaneio.id_st_romaneio = 5 Or romaneio.id_st_romaneio = 6 Then
                    tr_tempo_rota.Visible = False 'fran tempo rota dez/2018
                Else
                    tr_tempo_rota.Visible = True 'fran tempo rota dez/2018
                    If romaneio.id_transit_point > 0 Then 'se é romaneio de transit point, demonstra o numero
                        lbl_transit_point.Visible = True
                        lbl_id_transit_point.Visible = True
                        lbl_id_transit_point.Text = romaneio.id_transit_point.ToString
                        tr_transitpoint.Visible = True

                        Dim dstransit As DataSet = romaneio.getRomaneioTransitPointUP()
                        'se tem linhas em compartimento
                        If (dstransit.Tables(0).Rows.Count > 0) Then
                            gridTransitPoint.Visible = True
                            gridTransitPoint.DataSource = Helper.getDataView(dstransit.Tables(0), "")
                            gridTransitPoint.DataBind()
                        Else
                            Dim dr As DataRow = dstransit.Tables(0).NewRow()
                            dstransit.Tables(0).Rows.InsertAt(dr, 0)
                            gridTransitPoint.Visible = True
                            gridTransitPoint.DataSource = Helper.getDataView(dstransit.Tables(0), "")
                            gridTransitPoint.DataBind()
                            gridTransitPoint.Rows(0).Cells.Clear()
                            gridTransitPoint.Rows(0).Cells.Add(New TableCell())
                            gridTransitPoint.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                            gridTransitPoint.Rows(0).Cells(0).Text = "Não existe nenhum registro para o Transit Point!"
                            gridTransitPoint.Rows(0).Cells(0).ColumnSpan = 5
                        End If

                    Else
                        lbl_transit_point.Visible = False
                        lbl_id_transit_point.Visible = False
                    End If
                    If romaneio.st_romaneio_transbordo = "S" Then 'se é romaneio de transordo, 
                        lbl_transit_point.Visible = True
                        lbl_transit_point.Text = "Transbordo:"
                        lbl_id_transit_point.Visible = True
                        lbl_id_transit_point.Text = "SIM"
                    Else
                        If romaneio.id_transit_point = 0 Then
                            lbl_transit_point.Visible = False
                            lbl_id_transit_point.Visible = False
                        End If
                    End If
                    If romaneio.id_transvase > 0 Then 'se é romaneio de transordo, 
                        lbl_transit_point.Visible = True
                        lbl_transit_point.Text = "Transvase:"
                        lbl_id_transit_point.Visible = True
                        lbl_id_transit_point.Text = romaneio.id_transvase.ToString

                        tr_transvase.Visible = True

                        Dim dstransvase As DataSet = romaneio.getRomaneioTransvaseUP()
                        'se tem linhas em compartimento
                        If (dstransvase.Tables(0).Rows.Count > 0) Then
                            gridTransvase.Visible = True
                            gridTransvase.DataSource = Helper.getDataView(dstransvase.Tables(0), "")
                            gridTransvase.DataBind()
                        Else
                            Dim dr As DataRow = dstransvase.Tables(0).NewRow()
                            dstransvase.Tables(0).Rows.InsertAt(dr, 0)
                            gridTransvase.Visible = True
                            gridTransvase.DataSource = Helper.getDataView(dstransvase.Tables(0), "")
                            gridTransvase.DataBind()
                            gridTransvase.Rows(0).Cells.Clear()
                            gridTransvase.Rows(0).Cells.Add(New TableCell())
                            gridTransvase.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                            gridTransvase.Rows(0).Cells(0).Text = "Não existe nenhum registro para o Transvase!"
                            gridTransvase.Rows(0).Cells(0).ColumnSpan = 5
                        End If

                    Else
                        If romaneio.id_transit_point = 0 AndAlso romaneio.st_romaneio_transbordo <> "S" Then
                            lbl_transit_point.Visible = False
                            lbl_id_transit_point.Visible = False
                        End If
                    End If

                    Dim dstemporota As DataSet = romaneio.getRomaneioTempoRotabyRomaneio
                    If dstemporota.Tables(0).Rows.Count > 0 Then
                        lbl_tempo_rota.Text = dstemporota.Tables(0).Rows(0).Item("ds_tempo_rota").ToString
                        Dim lnr_tempo_rota As Decimal = dstemporota.Tables(0).Rows(0).Item("ds_tempo_rota_minutos")
                        Select Case lnr_tempo_rota
                            Case Is <= 720 ' Até 12 horas (720 minutos)
                                lbl_tempo_rota_descr.Text = "Até 12 Horas"
                                lbl_tempo_rota_descr.CssClass = "text temporotagreen"
                                img_tempo_rota.ImageUrl = "~/img/icon_status_verde.gif"

                            Case Is <= 1200
                                lbl_tempo_rota_descr.Text = "De 12:01 à 20:00 Horas"
                                lbl_tempo_rota_descr.CssClass = "text temporotayellow"
                                img_tempo_rota.ImageUrl = "~/img/icon_status_amarelo.gif"

                            Case Is > 1200
                                lbl_tempo_rota_descr.Text = "Acima de 20 Horas"
                                lbl_tempo_rota_descr.CssClass = "text temporotared"
                                img_tempo_rota.ImageUrl = "~/img/icon_status_vermelho.gif"
                        End Select
                    Else 'se nao encontrou, tempo rota esta com valor negativo, ou sej adata coleta é maior que data entrada romaneio
                        lbl_tempo_rota_descr.Text = "SEM TEMPO DE ROTA"
                        lbl_tempo_rota_descr.CssClass = "text temporotadesabilitado"
                        img_tempo_rota.ImageUrl = "~/img/icon_status_cinza.gif"
                        lbl_tempo_rota.Text = String.Empty
                    End If
                End If

            End If
            'Se é um romaneio de cooperativa
            If romaneio.id_cooperativa > 0 Then
                ViewState.Item("cooperativa") = "S"
                tr_caderneta.Visible = False
                tr_caderneta2.Visible = False
                tr_pnl_nota_fiscal_transferencia.Visible = False
                tr_diferenca_nf_transferencia.Visible = False
                lbl_labeltipoleite.Visible = False
                lbl_tipoleite.Visible = False

                'Dados cooperativa
                lbl_cooperativa.Text = String.Concat(romaneio.cd_cooperativa.ToString, " - ", romaneio.nm_cooperativa.ToString)
                lbl_nr_nota_fiscal.Text = romaneio.nr_nota_fiscal.ToString
                lbl_dt_saida_nota.Text = DateTime.Parse(romaneio.dt_saida_nota.ToString).ToString
                lbl_nm_item.Text = romaneio.nm_item.ToString
                lbl_nr_valor_nota.Text = FormatCurrency(romaneio.nr_valor_nota_fiscal, 2)
                lbl_nr_peso_liquido_nota.Text = romaneio.nr_peso_liquido_nota.ToString
                lbl_litros_caderneta_nf.Text = romaneio.nr_peso_liquido_nota
                lbl_nr_po_cooperativa.Text = romaneio.nr_po_cooperativa.ToString 'fran 07/02/2024
                tr_tempo_rota.Visible = False 'fran tempo rota dez/2018

                If romaneio.st_tipo_romaneio_cooperativa = "A" Then
                    Dim coopnotas As New Romaneio
                    coopnotas.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
                    Dim dsnotas As DataSet = coopnotas.getRomaneioCooperativaNotas
                    If dsnotas.Tables(0).Rows.Count > 0 Then
                        hl_nrnota.Visible = True
                        hl_nrnota.Text = lbl_nr_nota_fiscal.Text
                        hl_nrnota.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", dsnotas.Tables(0).Rows(0).Item("id_romaneio_notas_nf").ToString) + String.Format("&id_processo={0}", 8) + String.Format("&txt={0}", ".pdf")
                        'hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", pedidoanexo.id_central_pedido_notas.ToString) + String.Format("&id_processo={0}", "7")
                        lbl_nr_nota_fiscal.Visible = False
                        'se tem cte
                        If dsnotas.Tables(0).Rows(0).Item("nr_modelo_frete") = "1" Then
                            lbl_cte.Visible = True
                            lbl_nr_cte.Visible = False
                            hl_nrnotacte.Visible = True
                            hl_nrnotacte.Text = dsnotas.Tables(0).Rows(0).Item("nr_nota_fiscal_cte")
                            hl_nrnotacte.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", dsnotas.Tables(0).Rows(0).Item("id_romaneio_notas_cte").ToString) + String.Format("&id_processo={0}", 8) + String.Format("&txt={0}", ".pdf")
                        End If
                    End If
                Else ' se romaneio cooperativa foi inserido manualmente
                    Dim coopnotas As New NotaFiscal
                    coopnotas.id_romaneio = ViewState.Item("id_romaneio").ToString
                    Dim dscoopnota As DataSet = coopnotas.getNotasFiscaisByFilters

                    Dim romanexo As New RomaneioAnexo
                    romanexo.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
                    romanexo.nr_nota_fiscal = lbl_nr_nota_fiscal.Text
                    romanexo.id_tipo_anexo = 1
                    Dim dsnotas As DataSet = romanexo.getRomaneioAnexo
                    If dsnotas.Tables(0).Rows.Count > 0 Then
                        hl_nrnota.Visible = True
                        hl_nrnota.Text = lbl_nr_nota_fiscal.Text
                        hl_nrnota.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", dsnotas.Tables(0).Rows(0).Item("id_romaneio_anexo").ToString) + String.Format("&id_processo={0}", 10) + String.Format("&txt={0}", ".pdf")
                        lbl_nr_nota_fiscal.Visible = False
                    End If
                    'se na nf veio informado que frete fob verifica se tem anexo para cte
                    If dscoopnota.Tables(0).Rows.Count > 0 Then
                        With dscoopnota.Tables(0).Rows(0)
                            If .Item("id_frete_nf").ToString = "2" Then
                                lbl_cte.Visible = True
                                lbl_nr_cte.Text = .Item("nr_cte").ToString

                                romanexo.nr_nota_fiscal = lbl_nr_cte.Text
                                romanexo.id_tipo_anexo = 3 'cte pdf
                                dsnotas = romanexo.getRomaneioAnexo
                                If dsnotas.Tables(0).Rows.Count > 0 Then 'se tem anexo de cte
                                    hl_nrnotacte.Visible = True
                                    hl_nrnotacte.Text = lbl_nr_cte.Text
                                    hl_nrnotacte.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", dsnotas.Tables(0).Rows(0).Item("id_romaneio_anexo").ToString) + String.Format("&id_processo={0}", 10) + String.Format("&txt={0}", ".pdf")
                                Else
                                    lbl_nr_cte.Visible = True
                                End If

                            End If

                        End With
                    End If

                End If

            End If
            If romaneio.st_romaneio_transbordo = "S" Then
                ViewState.Item("cooperativa") = "N"
                tr_pnl_dados_cooperativa.Visible = False
                'tr_pnl_nota_fiscal_transferencia.Visible = True
                'tr_diferenca_nf_transferencia.Visible = True
                tr_pnl_nota_fiscal_transferencia.Visible = False
                tr_diferenca_nf_transferencia.Visible = False
                lbl_nr_nota_fiscal_transf.Text = romaneio.nr_nota_fiscal_transf
                lbl_serie_nota_fiscal_transf.Text = romaneio.nr_serie_nota_fiscal_transf
                If Not (romaneio.dt_emissao_nota_transf Is Nothing) Then
                    If Not (romaneio.dt_emissao_nota_transf.ToString.Equals(String.Empty)) Then
                        lbl_dt_emissao_nota.Text = Format(DateTime.Parse(romaneio.dt_emissao_nota_transf), "dd/MM/yyyy").ToString
                    End If
                End If
                If romaneio.nr_peso_liquido_nota_transf > 0 Then
                    lbl_nr_peso_liquido_nota_transf.Text = romaneio.nr_peso_liquido_nota_transf
                End If
                tr_transbordo.Visible = True
                lbl_nr_peso_liquido_caderneta.Text = FormatNumber(romaneio.nr_peso_liquido_caderneta, 0).ToString
                lbl_id_item.Text = romaneio.nm_item
                tr_caderneta.Visible = False
                tr_caderneta2.Visible = False
                lbl_litros_caderneta_nf.Text = romaneio.nr_peso_liquido_caderneta
            End If
            lbl_romaneio.Text = romaneio.id_romaneio.ToString
            If Not romaneio.ds_estabelecimento Is Nothing Then
                lbl_estabelecimento.Text = romaneio.ds_estabelecimento.ToString
            End If
            lbl_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            lbl_transportador.Text = romaneio.ds_transportador.ToString
            lbl_motorista.Text = romaneio.nm_motorista
            lbl_cd_cnh.Text = romaneio.cd_cnh
            lbl_dt_entrada.Text = Format(DateTime.Parse(romaneio.dt_hora_entrada), "dd/MM/yyyy HH:mm").ToString
            If Not (romaneio.dt_hora_saida Is Nothing) Then
                If Not (romaneio.dt_hora_saida.ToString.Equals(String.Empty)) Then
                    lbl_dt_saida.Text = Format(DateTime.Parse(romaneio.dt_hora_saida), "dd/MM/yyyy HH:mm").ToString
                End If
            End If
            If Not romaneio.ds_linha Is Nothing Then
                lbl_linha.Text = romaneio.ds_linha.ToString
            End If
            'lbl_placa.Text = romaneio.ds_placa.ToString   ' 28/09/2009 - Adriana Rls21 Frete
            lbl_tara.Text = FormatNumber(romaneio.nr_tara, 0).ToString
            lbl_nr_pesagem_inicial.Text = FormatNumber(romaneio.nr_pesagem_inicial, 0).ToString
            If Not romaneio.dt_pesagem_inicial Is Nothing Then
                lbl_dt_pesagem_inicial.Text = Format(DateTime.Parse(romaneio.dt_pesagem_inicial), "dd/MM/yyyy HH:mm")
            End If

            ' adri Themis 18/05/2012 - chamado 1547 - i
            If Not romaneio.dt_pesagem_intermediaria Is Nothing Then
                lbl_dt_pesagem_intermediaria.Text = Format(DateTime.Parse(romaneio.dt_pesagem_intermediaria), "dd/MM/yyyy HH:mm")
            End If
            lbl_nr_pesagem_intermediaria.Text = FormatNumber(romaneio.nr_pesagem_intermediaria, 0).ToString
            ' adri Themis 18/05/2012 - chamado 1547 - i

            If Not romaneio.dt_pesagem_final Is Nothing Then
                lbl_dt_pesagem_final.Text = Format(DateTime.Parse(romaneio.dt_pesagem_final), "dd/MM/yyyy HH:mm")
            End If
            If Not romaneio.dt_hora_saida Is Nothing Then
                lbl_dt_saida.Text = Format(DateTime.Parse(romaneio.dt_hora_saida), "dd/MM/yyyy HH:mm")
            End If

            lbl_litros_ajustados.Text = Round(romaneio.getRomaneioCompartimentosSomaVolumeAjustadobyRomaneio, 4)
            Select Case Sign(CDec(lbl_litros_ajustados.Text))
                Case -1 'se negativo, adicionou litros quando fez ajustes
                    lbl_litros_ajustados.Text = Abs(CDec(lbl_litros_ajustados.Text))
                Case 1  'se positivo, diminui litros qdo fez ajustes
                    lbl_litros_ajustados.Text = -CDec(lbl_litros_ajustados.Text)
            End Select

            lbl_litros_rejeitados.Text = Round(romaneio.getRomaneioCompartimentosSomaVolumeRejeitadobyRomaneio, 4)

            lbl_nr_pesagem_final.Text = FormatNumber(romaneio.nr_pesagem_final, 0).ToString
            If lbl_nr_pesagem_final.Text > 0 Then
                lbl_nr_peso_liquido_balanca.Text = CLng(CDec(lbl_nr_pesagem_inicial.Text) - CDec(FormatNumber(lbl_nr_pesagem_final.Text, 0)))
                Dim mediadensidade As Decimal = romaneio.getRomaneioCompartimentoMediaDens()
                'fran 15/05/2012 themis i
                'lbl_litros_reais.Text = Round(CDec(lbl_nr_peso_liquido_balanca.Text) * mediadensidade, 4)
                lbl_litros_reais.Text = Round(CDec(lbl_nr_peso_liquido_balanca.Text) / mediadensidade, 0)
                'fran 15/05/2012 themis f

                lbl_diferenca.Text = Round(CDec(lbl_litros_caderneta_nf.Text) - CDec(lbl_litros_reais.Text), 0)
                Select Case Sign(CDec(lbl_diferenca.Text))
                    Case -1 'se negativo, litros reais está com uma diferença maior que a caderneta, então muda o sinal
                        lbl_diferenca.Text = +Abs(CDec(lbl_diferenca.Text))
                        lbl_diferenca_percentual.Text = FormatPercent(+Abs(CDec(lbl_diferenca.Text) / CDec(lbl_litros_caderneta_nf.Text)))
                    Case 1  'se positivo, caderneta maior que o real
                        lbl_diferenca.Text = -CDec(lbl_diferenca.Text)
                        lbl_diferenca_percentual.Text = FormatPercent(-Abs(CDec(lbl_diferenca.Text) / CDec(lbl_litros_caderneta_nf.Text)))
                End Select

                If tr_diferenca_nf_transferencia.Visible = True Then
                    lbl_diferenca_nftransf.Text = CDec(lbl_nr_peso_liquido_nota_transf.Text) - CDec(lbl_litros_reais.Text)

                    Select Case Sign(CDec(lbl_diferenca_nftransf.Text))
                        Case -1 'se negativo, litros reais está com uma diferença maior que a caderneta, então muda o sinal
                            lbl_diferenca_nftransf.Text = +Abs(CDec(lbl_diferenca_nftransf.Text))
                            lbl_diferenca_percentual_nftransf.Text = FormatPercent(+Abs(CDec(lbl_diferenca_nftransf.Text) / CDec(lbl_nr_peso_liquido_nota_transf.Text)))
                        Case 1  'se positivo, caderneta maior que o real
                            lbl_diferenca_nftransf.Text = -CDec(lbl_diferenca_nftransf.Text)
                            lbl_diferenca_percentual_nftransf.Text = FormatPercent(-Abs(CDec(lbl_diferenca_nftransf.Text) / CDec(lbl_nr_peso_liquido_nota_transf.Text)))
                    End Select

                End If

            End If

            'fran themis batch
            Select Case romaneio.id_registro_exportacao_batch
                Case 1
                    lbl_registro_exportacao.Text = "Pendente"
                Case 2
                    lbl_registro_exportacao.Text = "Liberada"
                Case 3
                    lbl_registro_exportacao.Text = "Não Exportar"
            End Select
            If romaneio.st_exportacao_batch.Equals("S") Then
                lbl_st_exportacao_batch.Text = "Arquivo Exportado"
                lbl_dt_exportacao.Text = Format(DateTime.Parse(romaneio.dt_exportacao_batch), "dd/MM/yyyy HH:mm")
            Else
                lbl_st_exportacao_batch.Text = "Arquivo Não Exportado"
                lbl_dt_exportacao.Text = String.Empty
            End If
            If romaneio.id_registro_exportacao_batch = 1 Then
                lbl_data_registro_exportacao.Text = String.Empty
                lbl_usuario_registro_exportacao.Text = String.Empty
            Else
                If Not romaneio.dt_exportacao_batch Is Nothing Then

                    lbl_data_registro_exportacao.Text = Format(DateTime.Parse(romaneio.dt_exportacao_batch), "dd/MM/yyyy HH:mm")

                End If
                Dim usuario As New Usuario(Convert.ToInt32(romaneio.id_usuario_registro_exportacao_batch))
                lbl_usuario_registro_exportacao.Text = usuario.ds_login
            End If
            'fran 06/03/2012 THEMIS - BATCH f

            'loadplacas()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadplacas()

    '    Try

    '        Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
    '        Dim rplaca As New RomaneioPlaca
    '        Dim placa As Integer

    '        rplaca.id_romaneio = id_romaneio

    '        Dim dsplacas As DataSet = rplaca.getRomaneioPlacasByRomaneio()

    '        If (dsplacas.Tables(0).Rows.Count > 0) Then
    '            For placa = 0 To dsplacas.Tables(0).Rows.Count - 1
    '                With dsplacas.Tables(0).Rows(placa)
    '                    Select Case placa
    '                        Case 0
    '                            Me.btn_placa1.Text = .Item("ds_placa")
    '                            Me.btn_placa1.CommandArgument = .Item("id_romaneio_placa")
    '                        Case 1
    '                            Me.pnl_placa2.Visible = True
    '                            Me.btn_placa2.Visible = True
    '                            Me.btn_placa2.Text = .Item("ds_placa")
    '                            Me.btn_placa2.CommandArgument = .Item("id_romaneio_placa")
    '                        Case 2
    '                            Me.pnl_placa3.Visible = True
    '                            Me.btn_placa3.Visible = True
    '                            Me.btn_placa3.Text = .Item("ds_placa")
    '                            Me.btn_placa3.CommandArgument = .Item("id_romaneio_placa")
    '                        Case 3
    '                            Me.pnl_placa4.Visible = True
    '                            Me.btn_placa4.Visible = True
    '                            Me.btn_placa4.Text = .Item("ds_placa")
    '                            Me.btn_placa4.CommandArgument = .Item("id_romaneio_placa")
    '                        Case 4
    '                            Me.pnl_placa4.Visible = True
    '                            Me.btn_placa5.Visible = True
    '                            Me.btn_placa5.Text = .Item("ds_placa")
    '                            Me.btn_placa5.CommandArgument = .Item("id_romaneio_placa")
    '                    End Select
    '                End With
    '            Next
    '            loadabasplacas()
    '        Else
    '            messageControl.Alert("Não há placas cadastradas para este romaneio. Há problemas na passagem de parametros.")
    '        End If



    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try


    'End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_romaneio_consulta.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_consulta.aspx")


    End Sub


    'Private Sub loadabasplacas()

    '    Try

    '        Dim lid_romaneio_placa_ativa As Int32
    '        td_placa1.Attributes.Remove("class")
    '        If ViewState("placa_ativa") = 0 Then
    '            'td_placa1.Attributes.Add("class", "aba_ativa")
    '            pnl_placa1.BackImageUrl = "~/img/aba_ativa.gif"
    '            pnl_placa1.ForeColor = System.Drawing.Color.FromName("#0000F5")
    '            btn_placa1.ForeColor = System.Drawing.Color.FromName("#0000F5")
    '            'btn_placa1.Attributes.Add("forecolor", "#0000F5")
    '            lid_romaneio_placa_ativa = btn_placa1.CommandArgument
    '        Else
    '            pnl_placa1.BackImageUrl = "~/img/aba_nao_ativa.gif"
    '            pnl_placa1.ForeColor = System.Drawing.Color.FromName("#6767CC")
    '            btn_placa1.ForeColor = System.Drawing.Color.FromName("#6767CC")
    '        End If
    '        If btn_placa2.Visible = True Then
    '            'td_placa2.Attributes.Remove("class")
    '            If ViewState("placa_ativa") = 1 Then
    '                'td_placa2.Attributes.Add("class", "aba_ativa")
    '                pnl_placa2.BackImageUrl = "~/img/aba_ativa.gif"
    '                pnl_placa2.ForeColor = System.Drawing.Color.FromName("#0000F5")
    '                btn_placa2.ForeColor = System.Drawing.Color.FromName("#0000F5")
    '                lid_romaneio_placa_ativa = btn_placa2.CommandArgument
    '            Else
    '                'td_placa2.Attributes.Add("class", "aba_nao_ativa")
    '                pnl_placa2.BackImageUrl = "~/img/aba_nao_ativa.gif"
    '                pnl_placa2.ForeColor = System.Drawing.Color.FromName("#6767CC")
    '                btn_placa2.ForeColor = System.Drawing.Color.FromName("#6767CC")
    '            End If
    '        End If
    '        If btn_placa3.Visible = True Then
    '            'td_placa3.Attributes.Remove("class")
    '            If ViewState("placa_ativa") = 2 Then
    '                pnl_placa3.BackImageUrl = "~/img/aba_ativa.gif"
    '                pnl_placa3.ForeColor = System.Drawing.Color.FromName("#0000F5")
    '                btn_placa3.ForeColor = System.Drawing.Color.FromName("#0000F5")
    '                lid_romaneio_placa_ativa = btn_placa3.CommandArgument
    '            Else
    '                pnl_placa3.BackImageUrl = "~/img/aba_nao_ativa.gif"
    '                pnl_placa3.ForeColor = System.Drawing.Color.FromName("#6767CC")
    '                btn_placa3.ForeColor = System.Drawing.Color.FromName("#6767CC")
    '            End If
    '        End If
    '        If btn_placa4.Visible = True Then
    '            'td_placa4.Attributes.Remove("class")
    '            If ViewState("placa_ativa") = 3 Then
    '                pnl_placa4.BackImageUrl = "~/img/aba_ativa.gif"
    '                pnl_placa4.ForeColor = System.Drawing.Color.FromName("#0000F5")
    '                btn_placa4.ForeColor = System.Drawing.Color.FromName("#0000F5")
    '                lid_romaneio_placa_ativa = btn_placa4.CommandArgument

    '            Else
    '                pnl_placa4.BackImageUrl = "~/img/aba_nao_ativa.gif"
    '                pnl_placa4.ForeColor = System.Drawing.Color.FromName("#6767CC")
    '                btn_placa4.ForeColor = System.Drawing.Color.FromName("#6767CC")
    '            End If
    '        End If
    '        If btn_placa5.Visible = True Then
    '            'td_placa5.Attributes.Remove("class")
    '            If ViewState("placa_ativa") = 4 Then
    '                pnl_placa5.BackImageUrl = "~/img/aba_ativa.gif"
    '                pnl_placa5.ForeColor = System.Drawing.Color.FromName("#0000F5")
    '                btn_placa5.ForeColor = System.Drawing.Color.FromName("#0000F5")
    '                lid_romaneio_placa_ativa = btn_placa5.CommandArgument

    '            Else
    '                pnl_placa5.BackImageUrl = "~/img/aba_nao_ativa.gif"
    '                pnl_placa5.ForeColor = System.Drawing.Color.FromName("#6767CC")
    '                btn_placa5.ForeColor = System.Drawing.Color.FromName("#6767CC")

    '            End If
    '        End If

    '        loadPlacaAtiva(lid_romaneio_placa_ativa)

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try


    'End Sub


    'Protected Sub btn_placa1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa1.Click
    '    ViewState("placa_ativa") = 0
    '    loadabasplacas()

    'End Sub
    'Private Sub loadPlacaAtiva(ByVal id_romaneio_placa As Int32)

    '    Try

    '        'Dim id_romaneio_placa As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_placa").ToString)
    '        Dim rplaca As New RomaneioPlaca(id_romaneio_placa)

    '        lbl_nr_total_volume_coletado.Text = rplaca.nr_total_volume_coletado
    '        lbl_nr_total_volume_rejeitado.Text = rplaca.nr_total_volume_rejeitado
    '        lbl_nr_volume_descarregado.Text = rplaca.nr_volume_descarregado
    '        If (rplaca.id_nr_silo1 > 0) Then
    '            lbl_id_silo1.Text = rplaca.nr_silo1.ToString & " - " & rplaca.nm_silo1.ToString
    '        End If
    '        If (rplaca.id_nr_silo2 > 0) Then
    '            lbl_id_silo2.Text = rplaca.nr_silo2.ToString & " - " & rplaca.nm_silo2.ToString
    '        End If
    '        If Not rplaca.dt_ini_descarga Is Nothing Then
    '            lbl_dt_ini_descarga.Text = Format(DateTime.Parse(rplaca.dt_ini_descarga), "dd/MM/yyyy HH:mm")
    '        End If
    '        If Not rplaca.dt_fim_descarga Is Nothing Then
    '            lbl_dt_fim_descarga.Text = Format(DateTime.Parse(rplaca.dt_fim_descarga), "dd/MM/yyyy HH:mm")
    '        End If
    '        If Not rplaca.dt_ini_CIP Is Nothing Then
    '            lbl_dt_ini_cip.Text = Format(DateTime.Parse(rplaca.dt_ini_descarga), "dd/MM/yyyy HH:mm")
    '        End If
    '        If Not rplaca.dt_fim_CIP Is Nothing Then
    '            lbl_dt_fim_cip.Text = Format(DateTime.Parse(rplaca.dt_fim_CIP), "dd/MM/yyyy HH:mm")
    '        End If

    '        'Alternativa para o 0 do framework pois o inteiro qdo sem valor sempre assume 0 porem 0 para este campo é um valor válido
    '        Dim dsrplaca As DataSet = rplaca.getRomaneioPlacasByFilters
    '        If dsrplaca.Tables(0).Rows.Count > 0 Then
    '            If Not IsDBNull(dsrplaca.Tables(0).Rows(0).Item("nr_ph_solucao")) Then
    '                lbl_nr_ph_solucao.Text = dsrplaca.Tables(0).Rows(0).Item("nr_ph_solucao")
    '            End If
    '        End If

    '        loadgridlacre(id_romaneio_placa)

    '        loadgridcompartimento(rplaca.ds_placa)
    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try


    'End Sub
    'Private Sub loadgridlacre(ByVal id_romaneio_placa As Int32)

    '    Try

    '        Dim lacre As New RomaneioLacre

    '        lacre.id_romaneio_placa = id_romaneio_placa

    '        Dim dslacre As DataSet = lacre.getRomaneioLacresByFilters()

    '        If (dslacre.Tables(0).Rows.Count > 0) Then
    '            grdlacres.Visible = True
    '            grdlacres.DataSource = Helper.getDataView(dslacre.Tables(0), "nr_lacre_entrada asc")
    '            grdlacres.DataBind()
    '        Else
    '            Dim dr As DataRow = dslacre.Tables(0).NewRow()
    '            'dr("id_candidato_idioma") = -1
    '            dslacre.Tables(0).Rows.InsertAt(dr, 0)
    '            grdlacres.Visible = True
    '            grdlacres.DataSource = Helper.getDataView(dslacre.Tables(0), ViewState.Item("sortExpression"))
    '            grdlacres.DataBind()
    '            grdlacres.Rows(0).Cells.Clear()
    '            grdlacres.Rows(0).Cells.Add(New TableCell())
    '            grdlacres.Rows(0).Attributes.CssStyle.Add("text-align", "center")
    '            grdlacres.Rows(0).Cells(0).Text = "Não existe nenhum lacre cadastrado!"
    '            grdlacres.Rows(0).Cells(0).ColumnSpan = 4
    '        End If



    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try


    'End Sub
    'Private Sub loadgridcompartimento(ByVal ds_placa As String)

    '    Try

    '        Dim rc As New Romaneio_Compartimento

    '        rc.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
    '        rc.ds_placa = ds_placa

    '        Dim dsrc As DataSet = rc.getRomaneio_CompartimentoByFilters()

    '        If (dsrc.Tables(0).Rows.Count > 0) Then
    '            gridCompartimento.Visible = True
    '            gridCompartimento.DataSource = Helper.getDataView(dsrc.Tables(0), "")
    '            gridCompartimento.DataBind()
    '        Else
    '            Dim dr As DataRow = dsrc.Tables(0).NewRow()
    '            'dr("id_candidato_idioma") = -1
    '            dsrc.Tables(0).Rows.InsertAt(dr, 0)
    '            gridCompartimento.Visible = True
    '            gridCompartimento.DataSource = Helper.getDataView(dsrc.Tables(0), ViewState.Item("sortExpression"))
    '            gridCompartimento.DataBind()
    '            gridCompartimento.Rows(0).Cells.Clear()
    '            gridCompartimento.Rows(0).Cells.Add(New TableCell())
    '            gridCompartimento.Rows(0).Attributes.CssStyle.Add("text-align", "center")
    '            gridCompartimento.Rows(0).Cells(0).Text = "Não existe nenhum compartimento cadastrado!"
    '            gridCompartimento.Rows(0).Cells(0).ColumnSpan = 6
    '        End If



    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try


    'End Sub
    'Protected Sub btn_placa2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa2.Click
    '    ViewState("placa_ativa") = 1
    '    loadabasplacas()

    'End Sub

    'Protected Sub btn_placa3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa3.Click
    '    ViewState("placa_ativa") = 2
    '    loadabasplacas()

    'End Sub

    'Protected Sub btn_placa4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa4.Click
    '    ViewState("placa_ativa") = 3
    '    loadabasplacas()

    'End Sub

    'Protected Sub btn_placa5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa5.Click
    '    ViewState("placa_ativa") = 4
    '    loadabasplacas()

    'End Sub

    'Protected Sub gridCompartimento_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridCompartimento.RowCommand
    '    Select Case e.CommandName.ToString().ToLower()
    '        Case "analises"
    '            saveFilters()

    '            Response.Redirect("frm_romaneio_consulta_analise.aspx?id_romaneio_compartimento=" + e.CommandArgument.ToString)
    '    End Select

    'End Sub
    Private Sub saveFilters()

        Try

            customPage.setFilter("frm_r_consulta", "id_romaneio", ViewState.Item("id_romaneio").ToString)
            customPage.setFilter("frm_r_consulta", "placa_ativa", ViewState.Item("placa_ativa").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("frm_r_consulta", "id_romaneio").Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("frm_r_consulta", "id_romaneio")
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If

        'If Not (customPage.getFilterValue("frm_r_consulta", "placa_ativa").Equals(String.Empty)) Then
        'hasFilters = True
        'ViewState.Item("placa_ativa") = customPage.getFilterValue("frm_r_consulta", "placa_ativa")
        'Else
        ViewState.Item("placa_ativa") = 0
        'End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("frm_r_consulta")
        End If

    End Sub

    'Protected Sub gridCompartimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCompartimento.RowDataBound
    '    If (e.Row.RowType = DataControlRowType.DataRow) Then
    '        Try

    '            Dim lbl_st_reanalise As Label = CType(e.Row.FindControl("lbl_st_reanalise"), Label)
    '            Dim img_reanalise As Image = CType(e.Row.FindControl("img_reanalise"), Image)
    '            Dim lbl_st_registro As Label = CType(e.Row.FindControl("lbl_st_registro"), Label)


    '            'Se o romaneio compartimento é reanalise
    '            If lbl_st_reanalise.Text.Trim = "S" Then
    '                img_reanalise.ImageUrl = "~/img/ico_chk_true.gif"
    '            Else
    '                img_reanalise.ImageUrl = "~/img/ico_chk_false.gif"
    '            End If



    '        Catch ex As Exception
    '            messageControl.Alert(ex.Message)
    '        End Try
    '    End If

    'End Sub

    Protected Sub lk_Placas_Comp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_Placas_Comp.Click
        saveFilters()
        Response.Redirect("frm_romaneio_consulta_placa.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString)

    End Sub

    Protected Sub lk_AnexarDocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_AnexarDocumento.Click

        Response.Redirect("frm_romaneio_anexos.aspx?id=" + ViewState.Item("id_romaneio").ToString() + "&tela=frm_romaneio_consulta.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString)

    End Sub
End Class
