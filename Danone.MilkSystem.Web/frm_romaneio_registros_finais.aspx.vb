Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math


Partial Class frm_romaneio_registros_finais
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_registros_finais.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")

                'fran themis batch i
                'Dim romaneio As New Romaneio(ViewState.Item("id_romaneio"))
                Dim registroexportacao As New RegistroExportacaoBatch
                cbo_registro_exportacao.DataSource = registroexportacao.getRegistroExportacaoBatch()
                cbo_registro_exportacao.DataTextField = "nm_registro_exportacao_batch"
                cbo_registro_exportacao.DataValueField = "id_registro_exportacao_batch"
                cbo_registro_exportacao.DataBind()
                cbo_registro_exportacao.SelectedValue = 1 'pendente
                'fran themis batch f

                loadData()
            Else
                messageControl.Alert("Há problemas na passagem de parametros. A tela não pode ser montada!")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim romaneio As New Romaneio(id_romaneio)

            If romaneio.nr_caderneta > 0 Then
                ViewState.Item("cooperativa") = "N"
                tr_pnl_dados_cooperativa.Visible = False
                lbl_caderneta.Text = romaneio.nr_caderneta.ToString
                lbl_peso_liquido_caderneta.Text = FormatNumber(romaneio.nr_peso_liquido_caderneta, 0).ToString
                'Fran24/03/2009
                'lbl_litros_caderneta_nf.Text = romaneio.nr_peso_liquido_caderneta
                lbl_litros_caderneta_nf.Text = Decimal.Truncate(romaneio.nr_peso_liquido_caderneta)
                lbl_tipoleite.Text = romaneio.nm_item
                If romaneio.nr_nota_fiscal_transf Is Nothing Then
                    tr_pnl_nota_fiscal_transferencia.Visible = False
                    tr_nf_transfer_2.Visible = False
                Else
                    If romaneio.nr_nota_fiscal_transf.Equals(String.Empty) Then
                        tr_pnl_nota_fiscal_transferencia.Visible = False
                        tr_nf_transfer_2.Visible = False
                    Else
                        tr_nf_transfer_2.Visible = True
                        tr_pnl_nota_fiscal_transferencia.Visible = True
                        lbl_nr_nota_fiscal_transf.Text = romaneio.nr_nota_fiscal_transf
                        lbl_nr_serie_nota_transf.Text = romaneio.nr_serie_nota_fiscal_transf
                        If Not (romaneio.dt_emissao_nota_transf Is Nothing) Then
                            If Not (romaneio.dt_emissao_nota_transf.ToString.Equals(String.Empty)) Then
                                lbl_dt_emissao_nota_transf.Text = Format(DateTime.Parse(romaneio.dt_emissao_nota_transf), "dd/MM/yyyy").ToString
                            End If
                        End If
                        lbl_nr_peso_nota_transf.Text = romaneio.nr_peso_liquido_nota_transf
                    End If
                End If

            End If
            If romaneio.id_cooperativa > 0 Then
                ViewState.Item("cooperativa") = "S"
                tr_pnl_nota_fiscal_transferencia.Visible = False
                tr_caderneta.Visible = False
                tr_caderneta2.Visible = False
                lbl_labeltipoleite.Visible = False
                lbl_tipoleite.Visible = False
                tr_nf_transfer_2.Visible = False
                'Dados cooperativa
                lbl_cooperativa.Text = String.Concat(romaneio.cd_cooperativa.ToString, " - ", romaneio.nm_cooperativa.ToString)
                lbl_nr_nota_fiscal.Text = romaneio.nr_nota_fiscal.ToString
                lbl_dt_saida_nota.Text = DateTime.Parse(romaneio.dt_saida_nota.ToString).ToString
                lbl_nm_item.Text = romaneio.nm_item.ToString
                lbl_nr_valor_nota.Text = FormatCurrency(romaneio.nr_valor_nota_fiscal, 2)
                lbl_nr_peso_liquido_nota.Text = romaneio.nr_peso_liquido_nota.ToString
                'lbl_litros_caderneta_nf.Text = romaneio.nr_peso_liquido_nota
                lbl_litros_caderneta_nf.Text = Decimal.Truncate(romaneio.nr_peso_liquido_nota)
            End If
            If romaneio.st_romaneio_transbordo = "S" Then
                ViewState.Item("cooperativa") = "N"
                tr_caderneta.Visible = False
                tr_caderneta2.Visible = False
                tr_pnl_dados_cooperativa.Visible = False
                'tr_pnl_nota_fiscal_transferencia.Visible = True
                tr_pnl_nota_fiscal_transferencia.Visible = False
                lbl_nr_nota_fiscal_transf.Text = romaneio.nr_nota_fiscal_transf
                lbl_nr_serie_nota_transf.Text = romaneio.nr_serie_nota_fiscal_transf
                If Not (romaneio.dt_emissao_nota_transf Is Nothing) Then
                    If Not (romaneio.dt_emissao_nota_transf.ToString.Equals(String.Empty)) Then
                        lbl_dt_emissao_nota_transf.Text = Format(DateTime.Parse(romaneio.dt_emissao_nota_transf), "dd/MM/yyyy").ToString
                    End If
                End If
                If romaneio.nr_peso_liquido_nota_transf > 0 Then
                    lbl_nr_peso_nota_transf.Text = romaneio.nr_peso_liquido_nota_transf
                End If
                tr_transbordo.Visible = True
                lbl_nr_peso_liquido_caderneta.Text = FormatNumber(romaneio.nr_peso_liquido_caderneta, 0).ToString
                'lbl_litros_caderneta_nf.Text = romaneio.nr_peso_liquido_caderneta
                lbl_litros_caderneta_nf.Text = Decimal.Truncate(romaneio.nr_peso_liquido_caderneta)
                lbl_id_item.Text = romaneio.nm_item

            End If

            lbl_romaneio.Text = romaneio.id_romaneio.ToString
            lbl_estabelecimento.Text = romaneio.ds_estabelecimento.ToString
            lbl_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            lbl_transportador.Text = romaneio.ds_transportador.ToString
            lbl_motorista.Text = romaneio.nm_motorista
            lbl_cd_cnh.Text = romaneio.cd_cnh
            lbl_dt_entrada.Text = Format(DateTime.Parse(romaneio.dt_hora_entrada), "dd/MM/yyyy HH:mm").ToString
            If Not (romaneio.dt_hora_saida Is Nothing) Then
                If Not (romaneio.dt_hora_saida.ToString.Equals(String.Empty)) Then
                    lbl_dt_saida.Text = DateTime.Parse(romaneio.dt_hora_saida.ToString).ToString
                End If
            End If
            If Not romaneio.ds_linha Is Nothing Then
                lbl_linha.Text = romaneio.ds_linha.ToString
            End If
            lbl_placa.Text = romaneio.ds_placa.ToString
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

            lbl_nr_pesagem_final.Text = romaneio.nr_pesagem_final

            If Not lbl_nr_pesagem_final.Text.Equals(String.Empty) Then
                lbl_nr_peso_liquido_balanca.Text = CLng(CDbl(lbl_nr_pesagem_inicial.Text) - CDbl(lbl_nr_pesagem_final.Text))
                lbl_litros_reais.Text = Decimal.Truncate(lbl_nr_peso_liquido_balanca.Text)
            End If

            'lbl_litros_ajustados.Text = Round(romaneio.getRomaneioCompartimentosSomaVolumeAjustadobyRomaneio, 4)
            lbl_litros_ajustados.Text = Decimal.Truncate(romaneio.getRomaneioCompartimentosSomaVolumeAjustadobyRomaneio)
            Select Case Sign(CDec(lbl_litros_ajustados.Text))
                Case -1 'se negativo, adicionou litros quando fez ajustes
                    lbl_litros_ajustados.Text = Abs(CDec(lbl_litros_ajustados.Text))
                Case 1  'se positivo, diminui litros qdo fez ajustes
                    lbl_litros_ajustados.Text = -CDec(lbl_litros_ajustados.Text)
            End Select
            Decimal.Truncate(lbl_litros_ajustados.Text)

            'lbl_litros_rejeitados.Text = Round(romaneio.getRomaneioCompartimentosSomaVolumeRejeitadobyRomaneio, 4)
            lbl_litros_rejeitados.Text = Decimal.Truncate(romaneio.getRomaneioCompartimentosSomaVolumeRejeitadobyRomaneio)
            'loadCampos()

            If lbl_nr_pesagem_final.Text > 0 Then
                atualizarResumo()
            End If

            'fran 06/03/2012 THEMIS - BATCH i
            cbo_registro_exportacao.SelectedValue = romaneio.id_registro_exportacao_batch
            If romaneio.st_exportacao_batch.Equals("S") Then
                lbl_st_exportacao_batch.Text = "Arquivo Exportado"
                lbl_dt_exportacao.Text = Format(DateTime.Parse(romaneio.dt_exportacao_batch), "dd/MM/yyyy HH:mm")
            Else
                lbl_st_exportacao_batch.Text = "Arquivo Não Exportado"
                lbl_dt_exportacao.Text = String.Empty
            End If
            If romaneio.id_registro_exportacao_batch = 1 Then
                lk_registrar_status.Enabled = True
                lk_registrar_status_footer.Enabled = True
                lbl_data_registro_exportacao.Text = String.Empty
                lbl_usuario_registro_exportacao.Text = String.Empty
            Else
                lk_registrar_status.Enabled = False
                lk_registrar_status_footer.Enabled = False
                lbl_data_registro_exportacao.Text = Format(DateTime.Parse(romaneio.dt_registro_exportacao_batch), "dd/MM/yyyy HH:mm")
                Dim usuario As New Usuario(Convert.ToInt32(romaneio.id_usuario_registro_exportacao_batch))
                lbl_usuario_registro_exportacao.Text = usuario.ds_login
            End If
            'fran 06/03/2012 THEMIS - BATCH f


            loadgrid()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadgrid()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim rplaca As New RomaneioPlaca

            rplaca.id_romaneio = id_romaneio

            Dim dsplacas As DataSet = rplaca.getRomaneioPlacasByFilters()

            If (dsplacas.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsplacas.Tables(0), "ds_placa asc")
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Não há placas cadastradas para este romaneio. Há problemas na passagem de parametros.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Dim id_romaneio_placa As Int32 = Convert.ToInt32(e.CommandArgument.ToString)
        Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio"))
        Select Case e.CommandName.ToString().ToLower()
            Case "edit"
                'saveCampos()
                Response.Redirect("frm_romaneio_registros_finais_placas.aspx?id_romaneio_placa=" + id_romaneio_placa.ToString + "&id_romaneio=" + id_romaneio.ToString)


        End Select

    End Sub



    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_romaneio_registros_finais.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_registros_finais.aspx")


    End Sub

    Protected Sub cv_validar_lacres_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_validar_lacres.ServerValidate
        Try
            args.IsValid = True
            Dim lacres As New RomaneioLacre

            lacres.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            If lacres.getRomaneioLacresSaidaNulosByRomaneio > 0 Then
                args.IsValid = False
            End If

            If args.IsValid = False Then
                messageControl.Alert("Para Fechar o romaneio todos os lacres de saída devem ser informados.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_placas_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_placas.ServerValidate
        Try
            args.IsValid = True
            Dim placas As New RomaneioPlaca

            placas.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            If placas.getRomaneioPlacasNulasByRomaneio > 0 Then
                args.IsValid = False
            End If

            If args.IsValid = False Then
                messageControl.Alert("Para Fechar o romaneio as informações das placas devem ser informadas.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_compartimentos_semresultado_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_compartimentos_semresultado.ServerValidate
        Try
            args.IsValid = True
            Dim analisescomp As New RomaneioAnaliseCompartimento

            analisescomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            If analisescomp.getRomaneioAnaliseCompartimentoSemResultado > 0 Then
                args.IsValid = False
            End If

            If args.IsValid = False Then
                messageControl.Alert("Há análises obrigatórias de Compartimentos sem preenchimento de resultado. O Romaneio não pode ser fechado enquanto o registro de análises não for concluído.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub cv_uproducao_semresultado_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_uproducao_semresultado.ServerValidate
        Try
            args.IsValid = True
            Dim analisesup As New RomaneioAnaliseUProducao

            analisesup.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            If analisesup.getRomaneioAnaliseUProducaoSemResultado > 0 Then
                args.IsValid = False
            End If

            If args.IsValid = False Then
                messageControl.Alert("Há análises obrigatórias de Unidades de Produção/Produtores sem preenchimento de resultado. O Romaneio não pode ser fechado enquanto o registro de análises não for concluído.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub cv_compartimentos_semregistroanalise_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_compartimentos_semregistroanalise.ServerValidate
        Try
            args.IsValid = True
            Dim analises As New Romaneio_Compartimento

            analises.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            If analises.getRomaneioCompartimentoSemRegistroAnalise > 0 Then
                args.IsValid = False
            End If

            If args.IsValid = False Then
                messageControl.Alert("Há Compartimentos sem o Registro do Resultado das análises. O Romaneio não pode ser fechado enquanto o registro de análises não for concluído.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub cv_uproducao_semregistroanalise_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_uproducao_semregistroanalise.ServerValidate
        Try
            args.IsValid = True
            Dim analisesup As New Romaneio_Comp_UProducao

            analisesup.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            If analisesup.getRomaneioUProducaoSemRegistroAnalise > 0 Then
                args.IsValid = False
            End If

            If args.IsValid = False Then
                messageControl.Alert("Há Unid. Produção/Produtores sem o Registro do Resultado das análises. O Romaneio não pode ser fechado enquanto o registro de análises não for concluído.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub atualizarResumo()

        Try

            lbl_nr_peso_liquido_balanca.Text = CLng(CDec(lbl_nr_pesagem_inicial.Text) - CDec(FormatNumber(lbl_nr_pesagem_final.Text, 0)))
            Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))
            Dim mediadensidade As Decimal = romaneio.getRomaneioCompartimentoMediaDens()
            '            lbl_litros_reais.Text = Round(CDec(lbl_nr_peso_liquido_balanca.Text) * mediadensidade, 4)
            '           lbl_diferenca.Text = CDec(lbl_litros_caderneta_nf.Text) - CDec(lbl_litros_reais.Text)
            lbl_litros_reais.Text = Decimal.Truncate(CDec(lbl_nr_peso_liquido_balanca.Text) / mediadensidade)
            lbl_diferenca.Text = Decimal.Truncate((lbl_litros_caderneta_nf.Text) - CDec(lbl_litros_reais.Text))
            Select Case Sign(CDec(lbl_diferenca.Text))
                Case -1 'se negativo, litros reais está com uma diferença maior que a caderneta, então muda o sinal
                    lbl_diferenca.Text = +Abs(Decimal.Truncate(CDec(lbl_diferenca.Text)))
                    lbl_diferenca_percentual.Text = FormatPercent(+Abs(CDec(lbl_diferenca.Text) / CDec(lbl_litros_caderneta_nf.Text)))
                Case 1  'se positivo, caderneta maior que o real
                    lbl_diferenca.Text = -Decimal.Truncate(CDec(lbl_diferenca.Text))
                    lbl_diferenca_percentual.Text = FormatPercent(-Abs(CDec(lbl_diferenca.Text) / CDec(lbl_litros_caderneta_nf.Text)))
            End Select

            If tr_nf_transfer_2.Visible = True Then
                lbl_diferenca_nftransf.Text = Decimal.Truncate(CDec(lbl_nr_peso_nota_transf.Text) - CDec(lbl_litros_reais.Text))

                Select Case Sign(CDec(lbl_diferenca_nftransf.Text))
                    Case -1 'se negativo, litros reais está com uma diferença maior que a caderneta, então muda o sinal
                        lbl_diferenca_nftransf.Text = +Abs(Decimal.Truncate(CDec(lbl_diferenca_nftransf.Text)))
                        lbl_diferenca_percentual_nftransf.Text = FormatPercent(+Abs(CDec(lbl_diferenca_nftransf.Text) / CDec(lbl_nr_peso_nota_transf.Text)))
                    Case 1  'se positivo, caderneta maior que o real
                        lbl_diferenca_nftransf.Text = -Decimal.Truncate(CDec(lbl_diferenca_nftransf.Text))
                        lbl_diferenca_percentual_nftransf.Text = FormatPercent(-Abs(CDec(lbl_diferenca_nftransf.Text) / CDec(lbl_nr_peso_nota_transf.Text)))
                End Select

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_registrar_status_footer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_registrar_status_footer.Click
        RegistrarStatusExportacao()
    End Sub
    Private Sub RegistrarStatusExportacao() 'fran themis batch 5/03/2012
        If Page.IsValid Then
            Try

                Dim lbpageisvalid As Boolean = True
                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                If romaneio.id_registro_exportacao_batch = 1 Then 'se pendente
                    'verificar se os dados de placa foram preenchidos...
                    Dim placas As New RomaneioPlaca
                    placas.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                    If placas.getRomaneioPlacasNulasByRomaneio > 0 Then
                        lbpageisvalid = False
                        Throw New Exception("Para registrar o status da exportação todas as informações das placas no menu 'Registros Finais' devem ser preenchidas.")
                    End If
                    If cbo_registro_exportacao.SelectedValue = "2" Then 'se registro de exportacao é Liberada
                        If placas.getRomaneioPlacasLeiteDescarregadoByRomaneio > 0 Then 'se há leite não descarregado em silo, não pode exportar dados para SAP
                            lbpageisvalid = False
                            Throw New Exception("O registro do status da exportação deve ser 'Não Exportar' pois, há placas com leite não descarregado em silos, impedindo a exportação do romaneio para arquivo.")
                        End If
                    End If
                    'se tudo está ok... registra a exportação de batch no romaneio
                    If lbpageisvalid = True Then
                        romaneio.id_modificador = Session("id_login")
                        romaneio.id_registro_exportacao_batch = Convert.ToInt32(cbo_registro_exportacao.SelectedValue)
                        romaneio.updateRomaneioRegistroExportacaoBatch()

                        'FRAN 08/12/2020 i incluir log 
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 6 'processo
                        usuariolog.id_menu_item = 63
                        usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                        usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                        usuariolog.ds_nm_processo = "Registros Finais - Registro Status Exportacao"
                        usuariolog.insertUsuarioLog()
                        'FRAN 08/12/2020  incluir log 

                    End If
                Else
                    messageControl.Alert("Este romaneio já tem o status de exportação registrado.")
                End If
                loadData()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub lk_registrar_status_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_registrar_status.Click
        RegistrarStatusExportacao()
    End Sub
End Class
