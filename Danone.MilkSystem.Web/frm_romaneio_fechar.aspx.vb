Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_romaneio_fechar
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_fechar.aspx")
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
                'loadCampos()
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
                'Fran 24/03/2009 i
                'lbl_litros_caderneta_nf.Text = romaneio.nr_peso_liquido_caderneta
                lbl_litros_caderneta_nf.Text = Decimal.Truncate(romaneio.nr_peso_liquido_caderneta)
                'Fran 24/03/2009 f
                lbl_caderneta.Text = romaneio.nr_caderneta.ToString
                lbl_peso_liquido_caderneta.Text = FormatNumber(romaneio.nr_peso_liquido_caderneta, 0).ToString
                lbl_tipoleite.Text = romaneio.nm_item
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
                'Fran 24/03/2009 i
                'lbl_litros_caderneta_nf.Text = romaneio.nr_peso_liquido_nota
                lbl_litros_caderneta_nf.Text = Decimal.Truncate(romaneio.nr_peso_liquido_nota)
                'Fran 24/03/2009 f
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
                'Fran 24/03/2009 i
                'lbl_litros_caderneta_nf.Text = romaneio.nr_peso_liquido_caderneta
                lbl_litros_caderneta_nf.Text = Decimal.Truncate(romaneio.nr_peso_liquido_caderneta)
                'Fran 24/03/2009 f
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
            lbl_placa.Text = romaneio.ds_placa.ToString
            lbl_tara.Text = FormatNumber(romaneio.nr_tara, 0).ToString
            If romaneio.nr_pesagem_inicial > 0 Then
                txt_pesagem_inicial.Text = romaneio.nr_pesagem_inicial
            Else
                txt_pesagem_inicial.Text = String.Empty
            End If
            If Not romaneio.dt_pesagem_inicial Is Nothing Then
                txt_hr_ini.Text = Format(DateTime.Parse(romaneio.dt_pesagem_inicial), "HH")
                txt_mm_ini.Text = Format(DateTime.Parse(romaneio.dt_pesagem_inicial), "mm")
                txt_dt_pesagem_inicial.Text = Format(DateTime.Parse(romaneio.dt_pesagem_inicial), "dd/MM/yyyy")
            Else
                txt_hr_ini.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_ini.Text = Format(DateTime.Parse(Now), "mm")
                txt_dt_pesagem_inicial.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            End If

            If Not romaneio.dt_pesagem_final Is Nothing Then
                txt_hr_fim.Text = Format(DateTime.Parse(romaneio.dt_pesagem_final), "HH")
                txt_mm_fim.Text = Format(DateTime.Parse(romaneio.dt_pesagem_final), "mm")
                txt_dt_pesagem_final.Text = Format(DateTime.Parse(romaneio.dt_pesagem_final), "dd/MM/yyyy")
            Else
                txt_hr_fim.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_fim.Text = Format(DateTime.Parse(Now), "mm")
                txt_dt_pesagem_final.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            End If

            If Not romaneio.dt_hora_saida Is Nothing Then
                lbl_dt_saida.Text = Format(DateTime.Parse(romaneio.dt_hora_saida), "dd/MM/yyyy HH:mm")
            End If

            'Fran 25/03/2009 i
            'lbl_litros_ajustados.Text = Round(romaneio.getRomaneioCompartimentosSomaVolumeAjustadobyRomaneio, 4)
            lbl_litros_ajustados.Text = Decimal.Truncate(romaneio.getRomaneioCompartimentosSomaVolumeAjustadobyRomaneio)
            'Fran 25/03/2009 f
            Select Case Sign(CDec(lbl_litros_ajustados.Text))
                Case -1 'se negativo, adicionou litros quando fez ajustes
                    lbl_litros_ajustados.Text = Abs(CDec(lbl_litros_ajustados.Text))
                Case 1  'se positivo, diminui litros qdo fez ajustes
                    lbl_litros_ajustados.Text = -CDec(lbl_litros_ajustados.Text)
            End Select
            'Fran 25/03/2009 i
            'lbl_litros_rejeitados.Text = Round(romaneio.getRomaneioCompartimentosSomaVolumeRejeitadobyRomaneio, 4)
            lbl_litros_rejeitados.Text = Decimal.Truncate(romaneio.getRomaneioCompartimentosSomaVolumeRejeitadobyRomaneio)
            'Fran 25/03/2009 f
            If romaneio.nr_pesagem_final > 0 Then
                txt_nr_pesagem_final.Text = romaneio.nr_pesagem_final
            Else
                txt_nr_pesagem_final.Text = String.Empty
            End If

            loadCampos()

            If Not txt_nr_pesagem_final.Text.Equals(String.Empty) And Not txt_pesagem_inicial.Text.Equals(String.Empty) Then
                lbl_nr_peso_liquido_balanca.Text = CLng(CDbl(txt_pesagem_inicial.Text) - CDbl(txt_nr_pesagem_final.Text))
            End If

            If txt_nr_pesagem_final.Text > 0 Then
                lbl_nr_peso_liquido_balanca.Text = CLng(CDec(txt_pesagem_inicial.Text) - CDec(FormatNumber(txt_nr_pesagem_final.Text, 0)))
                Dim mediadensidade As Decimal = romaneio.getRomaneioCompartimentoMediaDens()
                'Fran 25/03/2009 i rls 17
                'lbl_litros_reais.Text = Round(CDec(lbl_nr_peso_liquido_balanca.Text) * mediadensidade, 4)
                lbl_litros_reais.Text = Decimal.Truncate(CDec(lbl_nr_peso_liquido_balanca.Text) / mediadensidade)

                'Fran 25/03/2009 f
                'Fran 25/03/2009 i
                'lbl_diferenca.Text = CDec(lbl_litros_caderneta_nf.Text) - CDec(lbl_litros_reais.Text)
                lbl_diferenca.Text = Decimal.Truncate(CDec(lbl_litros_caderneta_nf.Text) - CDec(lbl_litros_reais.Text))
                'Fran 25/03/2009 f
                Select Case Sign(CDec(lbl_diferenca.Text))
                    Case -1 'se negativo, litros reais está com uma diferença maior que a caderneta, então muda o sinal
                        lbl_diferenca.Text = +Abs(CDec(lbl_diferenca.Text))
                        lbl_diferenca_percentual.Text = FormatPercent(+Abs(CDec(lbl_diferenca.Text) / CDec(lbl_litros_caderneta_nf.Text)))
                    Case 1  'se positivo, caderneta maior que o real
                        lbl_diferenca.Text = -CDec(lbl_diferenca.Text)
                        lbl_diferenca_percentual.Text = FormatPercent(-Abs(CDec(lbl_diferenca.Text) / CDec(lbl_litros_caderneta_nf.Text)))
                End Select

                If tr_diferenca_nf_transferencia.Visible = True Then
                    'Fran 25/03/2009 i
                    'lbl_diferenca_nftransf.Text = CDec(lbl_nr_peso_liquido_nota_transf.Text) - CDec(lbl_litros_reais.Text)
                    lbl_diferenca_nftransf.Text = Decimal.Truncate(CDec(lbl_nr_peso_liquido_nota_transf.Text) - CDec(lbl_litros_reais.Text))
                    'Fran 25/03/2009 f
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
        Response.Redirect("lst_romaneio_fechar.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_fechar.aspx")


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
    '            'saveFilters()

    '            Response.Redirect("frm_romaneio_consulta_analise.aspx?id_romaneio_compartimento=" + e.CommandArgument.ToString)
    '    End Select

    'End Sub

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

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()

    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()

    End Sub
    Private Sub updateData()
        If Page.IsValid Then
            Try


                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                If romaneio.id_st_romaneio <> 4 Then
                    romaneio.nr_pesagem_inicial = Convert.ToDecimal(txt_pesagem_inicial.Text)
                    romaneio.dt_pesagem_inicial = Convert.ToDateTime(Me.txt_dt_pesagem_inicial.Text & " " & txt_hr_ini.Text & ":" & txt_mm_ini.Text & ":00")
                    romaneio.nr_pesagem_final = Convert.ToDecimal(txt_nr_pesagem_final.Text)
                    romaneio.dt_pesagem_final = Convert.ToDateTime(Me.txt_dt_pesagem_final.Text & " " & txt_hr_fim.Text & ":" & txt_mm_fim.Text & ":00")
                    If Not (lbl_nr_peso_liquido_balanca.Text.Trim.Equals(String.Empty)) Then
                        romaneio.nr_peso_liquido = Convert.ToDecimal(lbl_nr_peso_liquido_balanca.Text)
                    End If

                    romaneio.id_modificador = Session("id_login")


                    romaneio.updateRomaneioPesagens()

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 24
                    usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    messageControl.Alert("Romaneio salvo com sucesso.")
                    loadData()  ' 22/01/2008 - Rls15
                Else
                    messageControl.Alert("Este romaneio já está fechado.")
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub


    Protected Sub lk_fechar_romaneio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_fechar_romaneio.Click
        finalizarRomaneio()

    End Sub
    Private Sub finalizarRomaneio()
        If Page.IsValid Then
            Try

                Dim berro As Boolean = False
                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                If romaneio.id_st_romaneio <> 4 Then
                    romaneio.nr_pesagem_inicial = Convert.ToDecimal(txt_pesagem_inicial.Text)
                    romaneio.dt_pesagem_inicial = Convert.ToDateTime(Me.txt_dt_pesagem_inicial.Text & " " & txt_hr_ini.Text & ":" & txt_mm_ini.Text & ":00")
                    romaneio.nr_pesagem_final = Convert.ToDecimal(txt_nr_pesagem_final.Text)
                    romaneio.dt_pesagem_final = Convert.ToDateTime(Me.txt_dt_pesagem_final.Text & " " & txt_hr_fim.Text & ":" & txt_mm_fim.Text & ":00")
                    If Not (lbl_nr_peso_liquido_balanca.Text.Trim.Equals(String.Empty)) Then
                        romaneio.nr_peso_liquido = Convert.ToDecimal(lbl_nr_peso_liquido_balanca.Text)
                    End If

                    romaneio.id_modificador = Session("id_login")

                    ''verifica se tem amostra pendente para romaneio
                    'If romaneio.getRomaneioFecharAmostraPendente.Tables(0).Rows.Count > 0 Then
                    '    berro = True
                    '    messageControl.Alert("Há amostras de coletas do Romaneio pendentes para recepcionar ou descartar. O Romaneio não pode ser fechado até que as amostras estejam recepcionadas.")
                    'End If


                    If berro = False AndAlso romaneio.FecharRomaneioConsistir = True Then
                        romaneio.id_st_romaneio = 4
                        romaneio.FecharRomaneio()
                        'FRAN 08/12/2020 i incluir log 
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 6 'processo
                        usuariolog.id_menu_item = 24
                        usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                        usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                        usuariolog.insertUsuarioLog()
                        'FRAN 08/12/2020  incluir log 

                        'Fran 22/01/2011 i gko fase 2
                        'messageControl.Alert("Romaneio fechado com sucesso.")
                        If romaneio.id_cooperativa > 0 Then
                            Dim notafiscal As New NotaFiscal
                            notafiscal.nr_nota_fiscal = romaneio.nr_nota_fiscal
                            notafiscal.id_situacao = 1
                            Dim dsnota As DataSet = notafiscal.getNotasFiscaisByFilters
                            If dsnota.Tables(0).Rows.Count > 0 Then
                                If IsDBNull(dsnota.Tables(0).Rows(0).Item("id_natureza_operacao")) Then
                                    messageControl.Alert("Romaneio fechado com sucesso. A natureza de operação não foi informada no cadastro da nota fiscal deste romaneio.")
                                Else
                                    messageControl.Alert("Romaneio fechado com sucesso.")

                                End If
                            Else
                                messageControl.Alert("Romaneio fechado com sucesso. A natureza de operação não foi informada no cadastro da nota fiscal deste romaneio.")
                            End If
                        Else
                            messageControl.Alert("Romaneio fechado com sucesso.")
                        End If
                        'Fran 22/01/2011 f gko fase 2
                    End If

                Else
                    messageControl.Alert("Este romaneio já está fechado.")
                End If
                loadData()
                'End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub lk_fechar_romaneio_footer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_fechar_romaneio_footer.Click
        finalizarRomaneio()
    End Sub

    Protected Sub lk_Placas_Comp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_Placas_Comp.Click
        saveCampos()
        Response.Redirect("frm_romaneio_consulta_placa.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString + "&tela=frm_romaneio_fechar.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString + "&titulo=Fechar Romaneio")
    End Sub
    Private Sub loadCampos()

        Dim hascampos As Boolean

        hascampos = False

        If Not (customPage.getFilterValue("romaneiofechar", txt_dt_pesagem_inicial.ID).Equals(String.Empty)) Then
            txt_dt_pesagem_inicial.Text = customPage.getFilterValue("romaneiofechar", txt_dt_pesagem_inicial.ID)
            hascampos = True
        End If

        If Not (customPage.getFilterValue("romaneiofechar", txt_hr_ini.ID).Equals(String.Empty)) Then
            txt_hr_ini.Text = customPage.getFilterValue("romaneiofechar", txt_hr_ini.ID)
            hascampos = True
        End If

        If Not (customPage.getFilterValue("romaneiofechar", txt_mm_ini.ID).Equals(String.Empty)) Then
            txt_mm_ini.Text = customPage.getFilterValue("romaneiofechar", txt_mm_ini.ID)
            hascampos = True
        End If

        If Not (customPage.getFilterValue("romaneiofechar", txt_pesagem_inicial.ID).Equals(String.Empty)) Then
            txt_pesagem_inicial.Text = customPage.getFilterValue("romaneiofechar", txt_pesagem_inicial.ID)
            hascampos = True
        End If

        If Not (customPage.getFilterValue("romaneiofechar", txt_dt_pesagem_final.ID).Equals(String.Empty)) Then
            txt_dt_pesagem_final.Text = customPage.getFilterValue("romaneiofechar", txt_dt_pesagem_final.ID)
            hascampos = True
        End If
        If Not (customPage.getFilterValue("romaneiofechar", txt_hr_fim.ID).Equals(String.Empty)) Then
            txt_hr_fim.Text = customPage.getFilterValue("romaneiofechar", txt_hr_fim.ID)
            hascampos = True
        End If

        If Not (customPage.getFilterValue("romaneiofechar", txt_mm_fim.ID).Equals(String.Empty)) Then
            txt_mm_fim.Text = customPage.getFilterValue("romaneiofechar", txt_mm_fim.ID)
            hascampos = True
        End If

        If Not (customPage.getFilterValue("romaneiofechar", txt_nr_pesagem_final.ID).Equals(String.Empty)) Then
            txt_nr_pesagem_final.Text = customPage.getFilterValue("romaneiofechar", txt_nr_pesagem_final.ID)
            hascampos = True
        End If


        If (hascampos) Then
            customPage.clearFilters("romaneiofechar")
        End If

    End Sub
    Private Sub saveCampos()

        Try

            customPage.setFilter("romaneiofechar", txt_dt_pesagem_inicial.ID, txt_dt_pesagem_inicial.Text)
            customPage.setFilter("romaneiofechar", txt_hr_ini.ID, txt_hr_ini.Text)
            customPage.setFilter("romaneiofechar", txt_mm_ini.ID, txt_mm_ini.Text)
            customPage.setFilter("romaneiofechar", txt_pesagem_inicial.ID, txt_pesagem_inicial.Text)
            customPage.setFilter("romaneiofechar", txt_dt_pesagem_final.ID, txt_dt_pesagem_final.Text)
            customPage.setFilter("romaneiofechar", txt_hr_fim.ID, txt_hr_fim.Text)
            customPage.setFilter("romaneiofechar", txt_mm_fim.ID, txt_mm_fim.Text)
            customPage.setFilter("romaneiofechar", txt_nr_pesagem_final.ID, txt_nr_pesagem_final.Text)


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

End Class
