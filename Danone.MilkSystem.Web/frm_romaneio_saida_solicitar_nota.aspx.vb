Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail

Partial Class frm_romaneio_saida_solicitar_nota
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_saida_solicitar_nota.aspx")
            If Not Page.IsPostBack Then

                loadDetails()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Private Sub loadDetails()
        Try


            If Not (Request("id_romaneio_saida") Is Nothing) Then
                ViewState.Item("id_romaneio_saida") = Request("id_romaneio_saida")

                loadData()
            Else
                messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New RomaneioSaida()
            romaneio.id_romaneio_saida = ViewState.Item("id_romaneio_saida")

            Dim dsromaneio As DataSet = romaneio.getRomaneioSaidaSolicitacaoNF

            lbl_romaneio_saida.Text = ViewState.Item("id_romaneio_saida").ToString

            With dsromaneio.Tables(0).Rows(0)

                'DADOS GERAIS
                lbl_romaneio_situacao.Text = .Item("nm_situacao_romaneio_saida").ToString
                lbl_dt_abertura.Text = Format(DateTime.Parse(.Item("dt_hora_entrada").ToString), "dd/MM/yyyy hh:mm").ToString
                lbl_pesagem_inicial.Text = FormatNumber(.Item("nr_pesagem_inicial"), 0).ToString
                lbl_pesagem_final.Text = FormatNumber(.Item("nr_pesagem_final"), 0).ToString
                lbl_peso_liquido_romaneio.Text = FormatNumber(.Item("nr_peso_liquido"), 0).ToString
                If Not IsDBNull(.Item("id_romaneio_entrada")) Then
                    lbl_id_romaneio_entrada.Text = .Item("id_romaneio_entrada").ToString
                End If
                lbl_volume_estimado.Text = FormatNumber(.Item("nr_volume_estimado"), 0).ToString

                If Not IsDBNull(.Item("id_romaneio_saida_nota")) Then
                    tr_situacaonota.Visible = True
                    lbl_situacao_nf.Text = .Item("nm_situacao_romaneio_saida_nota").ToString
                    lbl_dt_modificacao_nf.Text = Format(DateTime.Parse(.Item("dt_modificacao").ToString), "dd/MM/yyyy hh:mm").ToString
                    lbl_usuario_nf.Text = Left(.Item("nm_usuario").ToString, 20)
                    ViewState.Item("id_romaneio_saida_nota") = .Item("id_romaneio_saida_nota")
                    ViewState.Item("id_situacao_romaneio_saida_nota") = .Item("id_situacao_romaneio_saida_nota")
                    'se situacao romaneio saida for aberta
                    If .Item("id_situacao_romaneio_saida_nota") <= "1" Then
                        lk_AnexarDocumento.Enabled = True
                        lk_solicitarnota.Enabled = True
                    Else
                        lk_AnexarDocumento.Enabled = False
                        lk_solicitarnota.Enabled = False
                        lk_concluir.Enabled = False
                        lk_concluirFooter.Enabled = False
                    End If
                Else
                    ViewState.Item("id_romaneio_saida_nota") = 0
                    ViewState.Item("id_situacao_romaneio_saida_nota") = 0

                    'se na solicitacao foi informdo valor frete e preco unit traz para os campos
                    If Not IsDBNull(.Item("nr_valor_frete_estimado")) Then
                        txt_valor_frete.Text = (CDec(.Item("nr_valor_frete_estimado"))).ToString("######.00")
                    End If

                End If

                'DESTINATARIO
                lbl_nm_destino.Text = .Item("nm_cooperativa").ToString
                lbl_cnpj_destino.Text = .Item("cd_cnpj_cooperativa").ToString
                lbl_ie_destino.Text = .Item("cd_incricao_estadual_destino").ToString
                lbl_endereco_destino.Text = .Item("ds_endereco").ToString
                lbl_endereco_numero.Text = .Item("nr_endereco").ToString
                If lbl_endereco_numero.Text.Equals("0") Then
                    lbl_endereco_numero.Text = "S/N"
                End If
                lbl_cidade_destino.Text = .Item("nm_cidade_destino").ToString
                lbl_cep_destino.Text = .Item("cd_cep_destino").ToString
                lbl_uf_destino.Text = .Item("cd_uf_destino").ToString

                'EMITENTE
                lbl_emitente.Text = .Item("ds_emitente").ToString
                lbl_cbu.Text = .Item("ds_cbu").ToString

                'Transportador
                lbl_nm_transportador.Text = .Item("nm_transportador").ToString
                lbl_cnpj_transportador.Text = .Item("cd_cnpj_transportador").ToString
                lbl_cidade_transportador.Text = .Item("nm_cidade_transp").ToString
                lbl_uf_transportador.Text = .Item("cd_uf_transp").ToString

                'Frete
                If Not IsDBNull(.Item("id_frete_nf")) Then
                    'se frete CIF quem paga é o emitente, nesta caso a Danone
                    If .Item("id_frete_nf").ToString.Equals("1") Then
                        opt_frete_danone.Checked = True
                        opt_frete_destinatario.Checked = False
                    End If
                    'se frete FOB quem paga é o destinatario, nesta caso a COOP
                    If .Item("id_frete_nf").ToString.Equals("2") Then
                        opt_frete_danone.Checked = False
                        opt_frete_destinatario.Checked = True
                    End If
                End If
                lbl_placa.Text = .Item("ds_placa").ToString
                If Not IsDBNull(.Item("nr_valor_frete_acordado")) Then
                    txt_valor_frete.Text = (CDec(.Item("nr_valor_frete_acordado"))).ToString("######.00")
                End If

                'natureza operacao
                If Not IsDBNull(.Item("id_natureza_operacao")) Then
                    ViewState.Item("id_natureza_operacao") = .Item("id_natureza_operacao").ToString
                    Select Case .Item("id_natureza_operacao")
                        Case 1
                            chk_no_1.Checked = True
                        Case 2
                            chk_no_2.Checked = True
                        Case 3
                            chk_no_3.Checked = True
                        Case 4
                            chk_no_4.Checked = True
                        Case 5
                            chk_no_5.Checked = True
                        Case 6
                            chk_no_6.Checked = True
                        Case 7
                            chk_no_7.Checked = True
                        Case 8
                            chk_no_8.Checked = True
                        Case 9
                            chk_no_9.Checked = True
                        Case 10
                            chk_no_10.Checked = True
                        Case 11
                            chk_no_11.Checked = True
                        Case 12
                            chk_no_12.Checked = True
                        Case 13
                            chk_no_13.Checked = True
                        Case 14
                            chk_no_14.Checked = True
                        Case 15
                            chk_no_15.Checked = True
                        Case 16
                            chk_no_16.Checked = True
                        Case 17
                            chk_no_17.Checked = True
                        Case 18
                            chk_no_18.Checked = True
                        Case 19
                            txt_natureza_outros.Text = .Item("ds_natureza_operacao_outros").ToString

                    End Select

                Else
                    ViewState.Item("id_natureza_operacao") = "0"
                    chk_no_1.Checked = False
                    chk_no_2.Checked = False
                    chk_no_3.Checked = False
                    chk_no_4.Checked = False
                    chk_no_5.Checked = False
                    chk_no_6.Checked = False
                    chk_no_7.Checked = False
                    chk_no_8.Checked = False
                    chk_no_9.Checked = False
                    chk_no_10.Checked = False
                    chk_no_11.Checked = False
                    chk_no_12.Checked = False
                    chk_no_13.Checked = False
                    chk_no_14.Checked = False
                    chk_no_15.Checked = False
                    chk_no_16.Checked = False
                    chk_no_17.Checked = False
                    chk_no_18.Checked = False

                    txt_natureza_outros.Text = String.Empty
                End If

                If Not IsDBNull(.Item("id_tipo_operacao")) Then
                    lbl_descricao_natureza.Text = String.Concat(.Item("nm_tipo_operacao").ToString, " de ", .Item("nm_item").ToString)
                End If

                'MATERIAL
                lbl_unidade.Text = .Item("cd_unidade_medida").ToString
                lbl_cd_item.Text = .Item("cd_item_sap").ToString
                lbl_nm_item.Text = .Item("nm_item").ToString

                If Not IsDBNull(.Item("id_romaneio_saida_nota")) Then
                    txt_qtde.Text = .Item("nr_quantidade")
                    txt_peso_liquido.Text = .Item("nr_peso_liquido_nota")
                    If Not IsDBNull(.Item("nr_peso_bruto")) Then
                        txt_peso_bruto.Text = .Item("nr_peso_bruto")
                    End If
                    txt_preco_unitario.Text = (CDec(.Item("nr_valor_unitario"))).ToString("######.0000")

                    If Not IsDBNull(.Item("ds_nota_fiscal_origem")) Then
                        txt_nota_origem.Text = .Item("ds_nota_fiscal_origem").ToString
                    End If
                    If Not IsDBNull(.Item("ds_contrato")) Then
                        txt_nr_contrato.Text = .Item("ds_contrato").ToString
                    End If
                    If Not IsDBNull(.Item("nr_especie_material")) Then
                        txt_nr_especie.Text = .Item("nr_especie_material")
                    End If
                    If Not IsDBNull(.Item("nr_volume_material")) Then
                        txt_volume_material.Text = .Item("nr_volume_material")
                    End If
                    lbl_valor_total.Text = FormatNumber(.Item("nr_valor_nota_fiscal").ToString, 2)
                    lbl_valor_total_nota.Text = FormatNumber(.Item("nr_valor_nota_fiscal").ToString, 2)

                    txt_ds_deposito.Text = .Item("ds_obs_deposito")
                    txt_ds_batch.Text = .Item("ds_obs_batch")
                    txt_lacres.Text = .Item("ds_obs_lacres")
                    txt_observacao.Text = .Item("ds_observacao")

                    lbl_data_solicitacao.Text = Format(DateTime.Parse(.Item("dt_solicitacao_nf").ToString), "dd/MM/yyyy hh:mm").ToString
                    lbl_nm_usuario.Text = .Item("nm_usuario_solicitante").ToString
                    lbl_depto.Text = .Item("ds_depto").ToString
                    lbl_centro_custo.Text = .Item("ds_centro_custo").ToString
                Else
                    lbl_depto.Text = "DAL"
                    lbl_centro_custo.Text = "321018"

                    Dim usuario As New Usuario(Convert.ToInt32(Session("id_login")))
                    lbl_nm_usuario.Text = usuario.nm_usuario.ToString

                    If Not IsDBNull(.Item("nr_preco_unitario_estimado")) Then
                        txt_preco_unitario.Text = (CDec(.Item("nr_preco_unitario_estimado"))).ToString("######.0000")
                    End If

                    txt_qtde.Text = lbl_volume_estimado.Text
                    If .Item("st_solicitacao_entrada_transportador").Equals("S") Then
                        txt_peso_liquido.Text = (CDec(.Item("nr_peso_liquido"))).ToString("######")
                        txt_peso_bruto.Text = txt_peso_liquido.Text
                    Else
                        txt_peso_liquido.Text = (CDec(.Item("nr_pesagem_final"))).ToString("######")
                        txt_peso_bruto.Text = txt_peso_liquido.Text
                    End If
                    txt_ds_batch.Text = lbl_id_romaneio_entrada.Text

                End If


            End With

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub lk_voltar_footer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar_footer.Click

        Response.Redirect("lst_romaneio_saida_solicitar_nota.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida"))

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click

        Response.Redirect("lst_romaneio_saida_solicitar_nota.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida"))

    End Sub

    Protected Sub cv_solicitar_nota_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_solicitar_nota.ServerValidate
        Try
            Dim lmsg As String
            Dim li As Integer = 0

            args.IsValid = True

            If opt_frete_danone.Checked = False AndAlso opt_frete_destinatario.Checked = False Then
                args.IsValid = False
                lmsg = "Alguma opção para campo 'Frete por Conta' deve ser informada."
            Else
                If opt_frete_danone.Checked = True AndAlso opt_frete_destinatario.Checked = True Then
                    args.IsValid = False
                    lmsg = "Apenas uma opção deve ser informada para o campo 'Frete por Conta'."
                End If
            End If
            If opt_frete_danone.Checked = True Then
                If txt_valor_frete.Text.Equals(String.Empty) OrElse txt_valor_frete.Text.Equals("0") Then
                    args.IsValid = False
                    lmsg = "Para tipo de frete por conta da Danone, o valor do Frete combinado com a Transportadora deve ser informado e maior que zero!"
                End If
            End If

            If chk_no_1.Checked = True Then
                li = li + 1
            End If
            If chk_no_2.Checked = True Then
                li = li + 1
            End If
            If chk_no_3.Checked = True Then
                li = li + 1
                'se natureza operação for devolucao
                If txt_nota_origem.Text.Equals(String.Empty) Then
                    args.IsValid = False
                    lmsg = "Para natureza de operação 'Devolução de Material' o número da nota fiscal de origem/aquisição deve ser informado!"
                End If
            End If
            If chk_no_4.Checked = True Then
                li = li + 1
            End If
            If chk_no_5.Checked = True Then
                li = li + 1
            End If
            If chk_no_6.Checked = True Then
                li = li + 1
            End If
            If chk_no_7.Checked = True Then
                li = li + 1
            End If
            If chk_no_8.Checked = True Then
                li = li + 1
            End If
            If chk_no_9.Checked = True Then
                li = li + 1
            End If
            If chk_no_10.Checked = True Then
                li = li + 1
                'se natureza operação for comodato
                If txt_nr_contrato.Text.Equals(String.Empty) Then
                    args.IsValid = False
                    lmsg = "Para natureza de operação Comodato, o número do contrato deve ser informado e anexado. Salve os dados, anexe o contrato e depois faça a solicitação."
                End If
                'verificar anexo
                If ViewState.Item("id_situacao_romaneio_saida_nota") = 1 Then
                    Dim anexo As New RomaneioSaidaNotaAnexo
                    anexo.id_origem = 1 'apenas anexos de solicitacao de nota
                    anexo.id_romaneio_saida = ViewState.Item("id_romaneio_saida")
                    If anexo.getRomaneioSaidaNotaAnexo().Tables(0).Rows.Count = 0 Then
                        args.IsValid = False
                        lmsg = "Para natureza de operação Comodato, o contrato deve ser anexado. Anexe o contrato e depois faça a solicitação."
                    End If
                End If
            End If
            If chk_no_11.Checked = True Then
                li = li + 1
            End If
            If chk_no_12.Checked = True Then
                li = li + 1
            End If
            If chk_no_13.Checked = True Then
                li = li + 1
            End If
            If chk_no_14.Checked = True Then
                li = li + 1
            End If
            If chk_no_15.Checked = True Then
                li = li + 1
            End If
            If chk_no_16.Checked = True Then
                li = li + 1
            End If
            If chk_no_17.Checked = True Then
                li = li + 1
            End If
            If chk_no_18.Checked = True Then
                li = li + 1
            End If

            If txt_natureza_outros.Text.Equals(String.Empty) Then
                If li = 0 Then
                    args.IsValid = False
                    lmsg = "Natureza de operação deve ser selecionado!"
                Else
                    If li > 1 Then
                        args.IsValid = False
                        lmsg = "Apenas um item deve ser selecionado para Natureza de Operação!"
                    End If
                End If
            Else
                If li > 0 Then
                    args.IsValid = False
                    lmsg = "Apenas um item deve ser selecionado para Natureza de Operação!"
                End If
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_AnexarDocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_AnexarDocumento.Click
        Response.Redirect("frm_romaneio_saida_nota_anexo.aspx?id=" + ViewState.Item("id_romaneio_saida").ToString() + "&id_origem=" + "1" + "&tela=frm_romaneio_saida_solicitar_nota.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida").ToString)

    End Sub


    Protected Sub txt_qtde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_qtde.TextChanged
        If Not txt_qtde.Text.Equals(String.Empty) Then
            If Not txt_preco_unitario.Text.Equals(String.Empty) Then
                lbl_valor_total.Text = round(CDec(txt_preco_unitario.Text) * CDec(txt_qtde.Text), 2).ToString("######.00")
                lbl_valor_total_nota.Text = lbl_valor_total.Text
            End If
        Else
            lbl_valor_total.Text = String.Empty
            lbl_valor_total_nota.Text = String.Empty
        End If
        
    End Sub

    Protected Sub txt_preco_unitario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_preco_unitario.TextChanged
        If Not txt_preco_unitario.Text.Equals(String.Empty) Then
            If Not txt_qtde.Text.Equals(String.Empty) Then
                lbl_valor_total.Text = round(CDec(txt_preco_unitario.Text) * CDec(txt_qtde.Text), 2).ToString("######.00")
                lbl_valor_total_nota.Text = lbl_valor_total.Text
            End If
        Else
            lbl_valor_total.Text = String.Empty
            lbl_valor_total_nota.Text = String.Empty
        End If

    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()

    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()

    End Sub
    Private Sub updateData()

        If Page.IsValid Then

            Try

                Dim romaneionota As New RomaneioSaidaNota()

                romaneionota.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
                romaneionota.id_romaneio_saida_nota = Convert.ToInt32(ViewState.Item("id_romaneio_saida_nota"))

                'Frete
                If opt_frete_danone.Checked = True Then
                    romaneionota.id_frete_nf = 1
                End If
                If opt_frete_destinatario.Checked = True Then
                    romaneionota.id_frete_nf = 2
                End If

                If Not txt_valor_frete.Text.Equals(String.Empty) Then
                    romaneionota.nr_valor_frete_acordado = CDec(txt_valor_frete.Text)
                End If

                If chk_no_1.Checked = True Then
                    romaneionota.id_natureza_operacao = 1
                End If
                If chk_no_2.Checked = True Then
                    romaneionota.id_natureza_operacao = 2
                End If
                If chk_no_3.Checked = True Then
                    romaneionota.id_natureza_operacao = 3
                End If
                If chk_no_4.Checked = True Then
                    romaneionota.id_natureza_operacao = 4
                End If
                If chk_no_5.Checked = True Then
                    romaneionota.id_natureza_operacao = 5
                End If
                If chk_no_6.Checked = True Then
                    romaneionota.id_natureza_operacao = 6
                End If
                If chk_no_7.Checked = True Then
                    romaneionota.id_natureza_operacao = 7
                End If
                If chk_no_8.Checked = True Then
                    romaneionota.id_natureza_operacao = 8
                End If
                If chk_no_9.Checked = True Then
                    romaneionota.id_natureza_operacao = 9
                End If
                If chk_no_10.Checked = True Then
                    romaneionota.id_natureza_operacao = 10
                End If
                If chk_no_11.Checked = True Then
                    romaneionota.id_natureza_operacao = 11
                End If
                If chk_no_12.Checked = True Then
                    romaneionota.id_natureza_operacao = 12
                End If
                If chk_no_13.Checked = True Then
                    romaneionota.id_natureza_operacao = 13
                End If
                If chk_no_14.Checked = True Then
                    romaneionota.id_natureza_operacao = 14
                End If
                If chk_no_15.Checked = True Then
                    romaneionota.id_natureza_operacao = 15
                End If
                If chk_no_16.Checked = True Then
                    romaneionota.id_natureza_operacao = 16
                End If
                If chk_no_17.Checked = True Then
                    romaneionota.id_natureza_operacao = 17
                End If
                If chk_no_18.Checked = True Then
                    romaneionota.id_natureza_operacao = 18
                End If
                If Not txt_natureza_outros.Text.Equals(String.Empty) Then
                    romaneionota.id_natureza_operacao = 19
                End If
                romaneionota.ds_natureza_operacao_outros = txt_natureza_outros.Text

                romaneionota.nr_quantidade = CDec(txt_qtde.Text)
                romaneionota.nr_peso_liquido_nota = CDec(txt_peso_liquido.Text)
                If Not txt_peso_bruto.Text.Equals(String.Empty) Then
                    romaneionota.nr_peso_bruto = CDec(txt_peso_bruto.Text)
                End If
                romaneionota.nr_valor_unitario = CDec(txt_preco_unitario.Text)

                romaneionota.ds_nota_fiscal_origem = txt_nota_origem.Text
                romaneionota.ds_contrato = txt_nr_contrato.Text

                If Not txt_nr_especie.Text.Equals(String.Empty) Then
                    romaneionota.nr_especie_material = CDec(txt_nr_especie.Text)
                End If
                If Not txt_volume_material.Text.Equals(String.Empty) Then
                    romaneionota.nr_volume_material = CDec(txt_volume_material.Text)
                End If
                romaneionota.nr_valor_nota_fiscal = CDec(lbl_valor_total_nota.Text)

                romaneionota.ds_obs_deposito = txt_ds_deposito.Text
                romaneionota.ds_obs_batch = txt_ds_batch.Text
                romaneionota.ds_obs_lacres = txt_lacres.Text
                romaneionota.ds_observacao = txt_observacao.Text
                romaneionota.ds_depto = lbl_depto.Text
                romaneionota.ds_centro_custo = lbl_centro_custo.Text

                romaneionota.id_modificador = Session("id_login")
                romaneionota.id_situacao_romaneio_saida_nota = 1 'Status Aberto

                Dim usuariolog As New UsuarioLog
                Dim lmsg As String

                If CInt(ViewState.Item("id_romaneio_saida_nota")) > 0 Then
                    romaneionota.updateRomaneioSaidaNota()
                    usuariolog.id_tipo_log = 3 'alteracao
                    lmsg = "Os dados da solicitação da nota do Romaneio de Saída foram atualizados com sucesso!"

                Else
                    romaneionota.id_romaneio_saida_nota = romaneionota.insertRomaneioSaidaNota
                    ViewState.Item("id_romaneio_saida_nota") = romaneionota.id_romaneio_saida_nota
                    usuariolog.id_tipo_log = 4 'inclusao
                    lmsg = "Os dados da solicitação da nota do Romaneio de Saída foram incluídos com sucesso!"

                End If

                'FRAN 08/12/2020 i incluir log 
                UsuarioLog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_menu_item = 250
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio_saida_nota")
                usuariolog.nm_nr_processo = ViewState.Item("id_romaneio_saida_nota")
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                messageControl.Alert(lmsg)
                loadData()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub lk_solicitarnota_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_solicitarnota.Click
        If Page.IsValid Then
            Try
                Dim lmsg As String
                'SOLICITAÇAO DE NOTA FISCAL*************************************************
                Dim romaneiosaida As New RomaneioSaidaNota
                romaneiosaida.id_romaneio_saida = ViewState.Item("id_romaneio_saida")
                romaneiosaida.id_romaneio_saida_nota = ViewState.Item("id_romaneio_saida_nota")
                romaneiosaida.id_modificador = Session("id_login")

                'Atualiza solicitação NF - romaneio saida situacao para 7 - Aguardando NF e romaneio nota para 2 - NF Solicitada
                romaneiosaida.solicitarNotaFiscal()

                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_menu_item = 250
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio_saida_nota")
                usuariolog.nm_nr_processo = ViewState.Item("id_romaneio_saida_nota")
                usuariolog.ds_nm_processo = String.Concat("Romaneio Saida ", ViewState.Item("id_romaneio_saida").ToString)
                usuariolog.insertUsuarioLog()

                lk_AnexarDocumento.Enabled = False
                lk_solicitarnota.Enabled = False
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False

                'ENVIO DE EMAIL *******************************************************************
                Dim notificacao As New Notificacao
                Dim lAssunto As String = String.Concat("Solicitação de Nota Fiscal para Romaneio Saída ", ViewState.Item("id_romaneio_saida").ToString, ".")
                Dim lCorpo As String = String.Concat("Existe uma nova solicitação de Nota Fiscal para o item ", lbl_nm_item.Text, " referente ao romaneio de saída ", ViewState.Item("id_romaneio_saida").ToString, ". Acesse o MILKSYSTEM para dar andamento ao processo.")

                usuariolog.id_tipo_log = 9 'e-mail
                usuariolog.id_menu_item = 250
                usuariolog.insertUsuarioLog()

                ' Parametro 27 - Romaneio Saida Nota Fiscal
                If notificacao.enviaMensagemEmail(27, lAssunto, lCorpo, MailPriority.High) = True Then
                    messageControl.Alert("Solicitação de Nota Fiscal realizada com sucesso! O E-MAIL de solicitação foi enviado aos destinatários com sucesso!")
                Else
                    messageControl.Alert("Solicitação de Nota Fiscal realizada com sucesso! O E-MAIL informando o departamento NÃO PODE SER ENVIADO. Verifique há destinatários cadastrados para este tipo de notificação.")
                End If

            Catch ex As Exception
                'messageControl.Alert(ex.Message)

                messageControl.Alert("Solicitação de Nota Fiscal realizada com sucesso! O E-MAIL de solicitação foi enviado aos destinatários com sucesso!")
                loadData()
            End Try
        End If
    End Sub
End Class
