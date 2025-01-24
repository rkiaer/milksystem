Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail

Partial Class frm_romaneio_saida_solicitar_abertura
    Inherits Page
    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_saida_solicitar_abertura.aspx")

        If Not Page.IsPostBack Then
            If Not (Request("id_romaneio_saida") Is Nothing) Then
                ViewState.Item("id_romaneio_saida") = Request("id_romaneio_saida")
            Else
                ViewState.Item("id_romaneio_saida") = 0
            End If

            loadDetails()
        End If
        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportador"
        End With
        With btn_lupa_cooperativa
            .Attributes.Add("onclick", "javascript:ShowDialogCooperativa()")
            .ToolTip = "Filtrar Destino"
        End With

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabel As New Estabelecimento

            estabel.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_estabelecimento.SelectedIndex = 1

            'tipo de leite 
            Dim item As New Item
            cbo_id_item.DataSource = item.getItensByFilters()
            cbo_id_item.DataTextField = "nm_item"
            cbo_id_item.DataValueField = "id_item"
            cbo_id_item.DataBind()
            cbo_id_item.Items.Insert(0, New ListItem("[Selecione]", 0))
            cbo_id_item.SelectedValue = 1 'assumir leite in natura

            Dim motivo As New MotivoSaida
            cbo_motivo_saida.DataSource = motivo.getMotivoSaidaByFilters()
            cbo_motivo_saida.DataTextField = "nm_motivo_saida"
            cbo_motivo_saida.DataValueField = "id_motivo_saida"
            cbo_motivo_saida.DataBind()
            cbo_motivo_saida.Items.Insert(0, New ListItem("[Selecione]", 0))

            Dim frete As New FreteNotaFiscal
            frete.id_situacao = 1
            cbo_tipo_frete.DataSource = frete.getFretesNotasFiscaisByFilters()
            cbo_tipo_frete.DataTextField = "nm_frete_nf"
            cbo_tipo_frete.DataValueField = "id_frete_nf"
            cbo_tipo_frete.DataBind()
            cbo_tipo_frete.Items.Insert(0, New ListItem("[Selecione]", 0))
            cbo_tipo_frete.Items(1).Text = "Danone"
            cbo_tipo_frete.Items(2).Text = "Destinatário"

            Dim tipooperacao As New TipoOperacao
            tipooperacao.id_situacao = 1
            cbo_tipo_operacao.DataSource = tipooperacao.getTipoOperacaoByFilters()
            cbo_tipo_operacao.DataTextField = "nm_tipo_operacao"
            cbo_tipo_operacao.DataValueField = "id_tipo_operacao"
            cbo_tipo_operacao.DataBind()
            cbo_tipo_operacao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            If txt_dt_estimada.Text.Equals(String.Empty) Then
                txt_dt_estimada.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            End If

            If CInt(ViewState.Item("id_romaneio_saida")) > 0 Then
                'se entrou na tela com arametro de romaneio , veio da abertura por nota e precisa complementar os dados
                loadData()
            Else
                ViewState.Item("id_situacao_romaneio_saida") = 0
                tr_romaneio.Visible = False
                lbl_romaneio_inf.Text = String.Empty
                lk_cancelar_abertura.Visible = False
                img_cancelar.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()

        Try

            Dim romaneio As New RomaneioSaida
            romaneio.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))

            Dim dsromaneio As DataSet = romaneio.getRomaneioSaidaSolicitarAbertura

            tr_romaneio.Visible = True
            lbl_romaneio_saida.Text = ViewState.Item("id_romaneio_saida").ToString

            With dsromaneio.Tables(0).Rows(0)

                cbo_estabelecimento.SelectedValue = .Item("id_estabelecimento").ToString
                cbo_id_item.SelectedValue = .Item("id_item").ToString
                cbo_tipo_operacao.SelectedValue = .Item("id_tipo_operacao").ToString
                cbo_motivo_saida.SelectedValue = .Item("id_motivo_saida").ToString
                cbo_tipo_frete.SelectedValue = .Item("id_frete_nf").ToString
                txt_dt_estimada.Text = Format(DateTime.Parse(.Item("dt_entrada_estimada").ToString), "dd/MM/yyyy").ToString
                hf_id_transportador.Value = .Item("id_transportador").ToString
                txt_cd_transportador.Text = .Item("cd_transportador").ToString
                lbl_nm_transportador.Text = .Item("nm_transportador").ToString
                hf_id_cooperativa.Value = .Item("id_cooperativa").ToString
                txt_cd_cooperativa.Text = .Item("cd_destino").ToString
                lbl_nm_cooperativa.Text = .Item("nm_destino").ToString
                lbl_cd_cnpj.Text = .Item("cd_cnpj_destino").ToString
                ViewState.Item("id_situacao_romaneio_saida") = .Item("id_situacao_romaneio_saida")
                If Not IsDBNull(.Item("nr_peso_liquido_nota")) Then
                    txt_nr_peso_liquido_estimado.Text = (CDec(.Item("nr_peso_liquido_nota"))).ToString("######")
                Else
                    txt_nr_peso_liquido_estimado.Text = String.Empty
                End If
                If Not IsDBNull(.Item("nr_preco_unitario_estimado")) Then
                    txt_preco_unitario.Text = (CDec(.Item("nr_preco_unitario_estimado"))).ToString("######.00")
                Else
                    txt_preco_unitario.Text = String.Empty
                End If
                If Not IsDBNull(.Item("nr_valor_frete_estimado")) Then
                    txt_valor_frete.Text = (CDec(.Item("nr_valor_frete_estimado"))).ToString("######.00")
                Else
                    txt_valor_frete.Text = String.Empty
                End If
                If Not IsDBNull(.Item("dt_hora_entrada")) Then
                    lbl_dt_hora_entrada.Text = Format(DateTime.Parse(.Item("dt_hora_entrada").ToString), "dd/MM/yyyy hh:mm").ToString
                Else
                    lbl_dt_hora_entrada.Text = String.Empty
                End If

                'dados do romaneio]
                If Not IsDBNull(.Item("id_romaneio_entrada")) Then
                    txt_id_romaneio_entrada.Text = .Item("id_romaneio_entrada")
                    loadDataRomaneioEntrada(.Item("id_romaneio_entrada"))
                Else
                    lbl_romaneio_inf.Text = String.Empty
                End If

                lbl_situacao.Text = .Item("nm_situacao_romaneio_saida").ToString
                lbl_modificador.Text = .Item("ds_login").ToString
                lbl_dt_modificacao.Text = Format(DateTime.Parse(.Item("dt_modificacao").ToString), "dd/MM/yyyy HH:mm").ToString

            End With

            If CInt(ViewState.Item("id_situacao_romaneio_saida")) > 1 Then
                'se caminhao ja chegou na portaria nao permite alteracao
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
                lk_cancelar_abertura.Enabled = False
                btn_lupa_cooperativa.Visible = False
                btn_lupa_transportador.Visible = False
                txt_id_romaneio_entrada.Enabled = False
                If CInt(ViewState.Item("id_situacao_romaneio_saida")) = 2 Then 'abertura cancelada
                    lk_concluir.ToolTip = "O romaneio de saída foi cancelado. Não pode ser alterado."
                    lk_cancelar_abertura.ToolTip = "O romaneio de saída já está cancelado."

                Else
                    lk_concluir.ToolTip = "O romaneio de saída já foi aberto. Não pode ser alterado."
                    lk_cancelar_abertura.ToolTip = "O romaneio de saída já foi aberto. A solicitação de abertura não pode ser cancelada."

                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadDataRomaneioEntrada(ByVal id_romaneio_entrada As Integer)


        Dim romaneioentrada As New Romaneio
        Dim romaneiosituacao As Int16 = 0
        romaneioentrada.id_romaneio = id_romaneio_entrada

        Dim dsromaneio As DataSet = romaneioentrada.getRomaneioByFilters

        If dsromaneio.Tables(0).Rows.Count > 0 Then
            With dsromaneio.Tables(0).Rows(0)
                romaneiosituacao = .Item("id_st_romaneio")

                If romaneiosituacao = 4 Then
                    lbl_romaneio_inf.Text = String.Concat("SAÍDA: ", Format(DateTime.Parse(.Item("dt_hora_saida")), "dd/MM/yyyy").ToString, " - TRANSP.: ", Left(.Item("nm_transportador").ToString, 20), " - PESO LÍQUIDO: ")
                    If romaneioentrada.id_cooperativa > 0 Then
                        lbl_romaneio_inf.Text = String.Concat(lbl_romaneio_inf.Text, .Item("nr_peso_liquido_nota").ToString("###.###"), " - SITUAÇÃO: ", .Item("nm_st_romaneio"))
                    Else
                        lbl_romaneio_inf.Text = String.Concat(lbl_romaneio_inf.Text, .Item("nr_peso_liquido_caderneta").ToString("###.###"), " - SITUAÇÃO: ", .Item("nm_st_romaneio"))
                    End If
                Else
                    lbl_romaneio_inf.Text = String.Concat("Romaneio informado está com situação ", .Item("nm_st_romaneio").ToString, ". O romaneio de entrada deve ter situação 'FECHADO'.")
                End If
            End With
        Else
            lbl_romaneio_inf.Text = String.Empty
        End If
        'If txt_id_romaneio_entrada.Text.Equals(String.Empty) Then
        '    lbl_romaneio_inf.Text = String.Empty
        'Else
        '    Dim romaneioentrada As New Romaneio(.Item("id_romaneio_entrada"))

        '    lbl_romaneio_inf.Text = String.Concat("SAÍDA: ", Format(DateTime.Parse(romaneioentrada.dt_hora_saida), "dd/MM/yyyy").ToString, " - TRANSP.: ", Left(romaneioentrada.nm_transportador, 20), " - PESO LÍQUIDO: ")
        '    If romaneioentrada.id_cooperativa > 0 Then
        '        lbl_romaneio_inf.Text = String.Concat(lbl_romaneio_inf.Text, romaneioentrada.nr_peso_liquido_nota.ToString("###.###"), " - SITUAÇÃO: ", romaneioentrada.nm_st_romaneio)
        '    Else
        '        lbl_romaneio_inf.Text = String.Concat(lbl_romaneio_inf.Text, romaneioentrada.nr_peso_liquido_caderneta.ToString("###.###"), " - SITUAÇÃO: ", romaneioentrada.nm_st_romaneio)
        '    End If

        'End If

    End Sub
    Private Sub updateData()
        If Page.IsValid Then

            Try

                Dim romaneio As New RomaneioSaida()
                Dim usuariolog As New UsuarioLog
                Dim lmsg As String = String.Empty

                romaneio.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                romaneio.id_item = Convert.ToInt32(cbo_id_item.SelectedValue)
                If Not (cbo_tipo_operacao.SelectedValue.Equals(String.Empty)) Then
                    romaneio.id_tipo_operacao = cbo_tipo_operacao.SelectedValue
                Else
                    romaneio.id_tipo_operacao = 0
                End If
                romaneio.id_motivo_saida = cbo_motivo_saida.SelectedValue
                romaneio.dt_entrada_estimada = txt_dt_estimada.Text.ToString
                romaneio.id_frete_nf = cbo_tipo_frete.SelectedValue
                romaneio.id_cooperativa = Convert.ToInt32(hf_id_cooperativa.Value)
                romaneio.id_transportador = Convert.ToInt32(hf_id_transportador.Value)
                If Not (txt_nr_peso_liquido_estimado.Text.Trim.Equals(String.Empty)) Then
                    romaneio.nr_volume_estimado = Convert.ToDecimal(txt_nr_peso_liquido_estimado.Text)
                End If
                If Not (txt_id_romaneio_entrada.Text.Trim.Equals(String.Empty)) Then
                    romaneio.id_romaneio_entrada = txt_id_romaneio_entrada.Text
                End If
                If Not (txt_preco_unitario.Text.Trim.Equals(String.Empty)) Then
                    romaneio.nr_preco_unitario_estimado = Convert.ToDecimal(txt_preco_unitario.Text)
                End If
                If Not (txt_valor_frete.Text.Trim.Equals(String.Empty)) Then
                    romaneio.nr_valor_frete_estimado = Convert.ToDecimal(txt_valor_frete.Text)
                End If

                romaneio.id_modificador = Session("id_login")

                If CInt(ViewState.Item("id_romaneio_saida")) > 0 Then
                    romaneio.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
                    romaneio.updateRomaneioSaidaSolicitacao()
                    usuariolog.id_tipo_log = 3 'alteraçao
                    lmsg = "Registro alterado com sucesso."
                Else
                    romaneio.id_romaneio_saida = romaneio.insertRomaneioSaidaSolicitacao()
                    ViewState.Item("id_romaneio_saida") = romaneio.id_romaneio_saida
                    usuariolog.id_tipo_log = 4 'insercao
                    lmsg = "Registro inserido com sucesso."


                End If
                'fran 03/01/2024 f

                'log
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_menu_item = 244
                usuariolog.id_nr_processo = romaneio.id_romaneio_saida.ToString
                usuariolog.nm_nr_processo = romaneio.id_romaneio_saida.ToString
                usuariolog.insertUsuarioLog()

                If usuariolog.id_tipo_log = 4 Then
                    'ENVIO DE EMAIL *******************************************************************
                    Dim notificacao As New Notificacao
                    Dim lAssunto As String = String.Concat("Solicitação/Autorização de Entrada de Veículo para o Romaneio de Saída ", ViewState.Item("id_romaneio_saida").ToString, ".")
                    Dim lCorpo As String = String.Concat("Existe uma nova solicitação/autorização de entrada de veículo referente ao romaneio de saída de número ", ViewState.Item("id_romaneio_saida").ToString, ". Na chegada do veículo, acesse o MILKSYSTEM e complemente as informações solicitadas para prosseguir com a abertura do Romaneio de Saída.")

                    usuariolog.id_tipo_log = 9 'e-mail
                    usuariolog.insertUsuarioLog()

                    ' Parametro 27 - Romaneio Saida Nota Fiscal
                    If notificacao.enviaMensagemEmail(31, lAssunto, lCorpo, MailPriority.High) = True Then
                        lmsg = "Registro inserido com sucesso. O E-MAIL informando sobre a nova autorização de entrada foi enviado aos destinatários com sucesso!"
                    Else
                        lmsg = "Registro inserido com sucesso. O E-MAIL informando sobre a nova autorização de entrada NÃO PODE SER ENVIADO. Verifique há destinatários cadastrados para este tipo de notificação"
                    End If

                End If

                messageControl.Alert(lmsg)

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Private Sub carregarCamposTransportador()

        Try

            If Not (customPage.getFilterValue("lupa_transcoop", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transcoop", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transcoop", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transcoop", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_transcoop")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub carregarCamposCooperativa()

        Try

            If Not (customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").Equals(String.Empty)) Then
                Me.lbl_nm_cooperativa.Visible = True
                Me.lbl_nm_cooperativa.Text = customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").Equals(String.Empty)) Then
                Me.txt_cd_cooperativa.Text = customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").Equals(String.Empty)) Then
                Me.lbl_cd_cnpj.Visible = True
                Me.lbl_cd_cnpj.Text = customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").ToString
                Me.lbl_nm_cnpj.Visible = True
            End If

            'loadData()
            customPage.clearFilters("lupa_cooperativa")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidtransportador As Int32
            If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_transportador.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
            lidtransportador = pessoa.validarTransportadorCooperativa

            If lidtransportador > 0 Then
                args.IsValid = True
                hf_id_transportador.Value = lidtransportador
            Else
                hf_id_transportador.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Transportador não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        lbl_nm_transportador.Text = String.Empty
        lbl_nm_transportador.Visible = False
        hf_id_transportador.Value = String.Empty


    End Sub

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        'If Not (Me.cbo_estabelecimento.SelectedValue.ToString.Equals(String.Empty)) Then
        If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
            'loadMotoristaByTransportador(Convert.ToInt32(hf_id_transportador.Value))
        Else
            txt_cd_transportador.Text = String.Empty
            hf_id_transportador.Value = String.Empty
            lbl_nm_transportador.Text = String.Empty
            lbl_nm_transportador.Visible = False
        End If
        'End If

    End Sub

    Private Sub loadCooperativaByCodigo()

        Try


            Dim cooperativa As New Pessoa
            cooperativa.cd_pessoa = txt_cd_cooperativa.Text
            Dim dscooperativa As DataSet = cooperativa.getCooperativasByCodigo()
            If dscooperativa.Tables(0).Rows.Count > 0 Then
                lbl_nm_cooperativa.Visible = True
                lbl_cd_cnpj.Visible = True
                Me.lbl_nm_cnpj.Visible = True
                lbl_nm_cooperativa.Text = dscooperativa.Tables(0).Rows(0).Item("nm_pessoa")
                lbl_cd_cnpj.Text = dscooperativa.Tables(0).Rows(0).Item("cd_cnpj")
                hf_id_cooperativa.Value = dscooperativa.Tables(0).Rows(0).Item("id_pessoa")
                ViewState.Item("id_estado_cooperativa") = dscooperativa.Tables(0).Rows(0).Item("id_estado")
            Else
                lbl_nm_cooperativa.Visible = False
                lbl_cd_cnpj.Visible = False
                Me.lbl_nm_cnpj.Visible = False
                hf_id_cooperativa.Value = String.Empty
                ViewState.Item("id_estado_cooperativa") = 0
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub cv_cooperativa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_cooperativa.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidcooperativa As Int32

            'If Not cbo_estabelecimento.SelectedValue.Equals(String.Empty) Then
            'pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            'End If
            If Not (Me.hf_id_cooperativa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_cooperativa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_cooperativa.Text.Trim
            lidcooperativa = pessoa.validarCooperativa

            If lidcooperativa > 0 Then
                args.IsValid = True
                hf_id_cooperativa.Value = lidcooperativa
            Else
                hf_id_cooperativa.Value = String.Empty
                args.IsValid = False
                'messageControl.Alert("Cooperativa não cadastrada.")
                messageControl.Alert("Cooperativa não cadastrada para o Estabelecimento do Romaneio!")  ' 19/08/2010 Adriana Chamado 932
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click

        Response.Redirect("lst_romaneio_saida_solicitar_abertura.aspx")

    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_saida_solicitar_abertura.aspx")

    End Sub

    Protected Sub btn_lupa_cooperativa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_cooperativa.Click
        If Not (Me.hf_id_cooperativa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposCooperativa()
        Else
            txt_cd_cooperativa.Text = String.Empty
            hf_id_cooperativa.Value = String.Empty
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            lbl_cd_cnpj.Text = String.Empty
            lbl_cd_cnpj.Visible = False
            Me.lbl_nm_cnpj.Visible = False
        End If

    End Sub

    Protected Sub txt_cd_cooperativa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_cooperativa.TextChanged

        If Not txt_cd_cooperativa.Text.Equals(String.Empty) Then
            loadCooperativaByCodigo()
        Else
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            hf_id_cooperativa.Value = String.Empty
            lbl_cd_cnpj.Text = String.Empty
            lbl_cd_cnpj.Visible = False
            Me.lbl_nm_cnpj.Visible = False
        End If
    End Sub
    Protected Sub txt_id_romaneio_entrada_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_romaneio_entrada.TextChanged

        If txt_id_romaneio_entrada.Text.Equals(String.Empty) Then
            lbl_romaneio_inf.Text = String.Empty
        Else
            loadDataRomaneioEntrada(CLng(txt_id_romaneio_entrada.Text))
        End If
    End Sub

    Protected Sub cv_romaneio_entrada_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_romaneio_entrada.ServerValidate
        Try
            Dim lmsg As String = String.Empty

            args.IsValid = True

            If Not txt_id_romaneio_entrada.Text.Equals(String.Empty) Then
                If lbl_romaneio_inf.Text.Equals(String.Empty) Then
                    lmsg = "Romaneio de Entrada Origem informado não existe no cadastro do sistema."
                    args.IsValid = False
                Else
                    If Left(lbl_romaneio_inf.Text, 18).Equals("Romaneio informado") Then
                        lmsg = "Romaneio de Entrada Origem informado deve estar com situação 'Fechado'."
                        args.IsValid = False
                    End If
                End If
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_cancelar_abertura_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_cancelar_abertura.Click
        Try
            If Page.IsValid Then

                Dim romaneio As New RomaneioSaida
                romaneio.id_romaneio_saida = ViewState.Item("id_romaneio_saida")
                romaneio.id_modificador = Convert.ToInt32(Session("id_login"))
                romaneio.updateRomaneioSaidaCancelarAbertura()

                romaneio.id_situacao = 2 'inclui log de situacao
                romaneio.insertRomaneioSaidaSituacaoLog()

                ' incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 5 'delecao
                usuariolog.id_menu_item = 244
                usuariolog.id_nr_processo = romaneio.id_romaneio_saida
                usuariolog.nm_nr_processo = romaneio.id_romaneio_saida
                usuariolog.ds_nm_processo = "Cancelamento Abertura"
                usuariolog.insertUsuarioLog()

                messageControl.Alert("Registro cancelado com sucesso!")
                loadData()


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class
