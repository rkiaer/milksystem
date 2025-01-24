Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_frete_lancamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_frete_lancamento.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_cooperativa
            .Attributes.Add("onclick", "javascript:ShowDialogCooperativa()")
            .ToolTip = "Filtrar Cooperativas"
        End With
        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportadores"
        End With

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim conta As New FreteConta
            If (Request("id_frete_lancamento") Is Nothing) Then
                conta.id_situacao = 1
            End If

            cbo_conta.DataSource = conta.getFreteContaByFilters
            cbo_conta.DataTextField = "ds_frete_conta"
            cbo_conta.DataValueField = "id_frete_conta"
            cbo_conta.DataBind()
            cbo_conta.Items.Insert(0, New ListItem("[Selecione]", 0))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_frete_lancamento") Is Nothing) Then
                ViewState.Item("id_frete_lancamento") = Request("id_frete_lancamento")

                Dim lanc As New FreteLancamento(ViewState.Item("id_frete_lancamento"))
                Dim periodo As New FretePeriodo(lanc.id_frete_periodo)

                'nao pode alterar 
                If periodo.st_calculo_definitivo = "S" Then
                    btn_lupa_cooperativa.Visible = False
                    btn_lupa_transportador.Visible = False
                    lk_concluir.Enabled = False
                    lk_concluirFooter.Enabled = False
                    lk_concluir.ToolTip = "Cálculo Definitivo pra referência já foi efetuado. O registro de lançamento não pode ser alterado."
                    lk_concluirFooter.ToolTip = "Cálculo Definitivo pra referência já foi efetuado. O registro de lançamento não pode ser alterado."
                End If

                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()

        Try

            Dim id_frete_lancamento As Int32 = Convert.ToInt32(ViewState.Item("id_frete_lancamento"))
            Dim lancamento As New FreteLancamento()

            lancamento.id_frete_lancamento = id_frete_lancamento

            Dim dslancamento As DataSet = lancamento.getFreteLancamentoByFilters

            If dslancamento.Tables(0).Rows.Count > 0 Then
                With dslancamento.Tables(0).Rows(0)
                    cbo_estabelecimento.SelectedValue = .Item("id_estabelecimento").ToString
                    txt_cd_transportador.Text = .Item("cd_transportador").ToString
                    lbl_nm_transportador.Text = .Item("nm_transportador").ToString
                    hf_id_transportador.Value = .Item("id_transportador").ToString
                    cbo_tipofrete.SelectedValue = .Item("id_tipo_frete").ToString

                    If cbo_tipofrete.SelectedValue.Equals("2") Then
                        txt_cd_cooperativa.Text = .Item("cd_cooperativa").ToString
                        lbl_nm_cooperativa.Text = .Item("nm_cooperativa").ToString
                        hf_id_cooperativa.Value = .Item("id_cooperativa").ToString
                        lbl_cd_cnpj.Text = .Item("cd_cnpj_cooperativa").ToString
                        lbl_nm_cnpj.Text = "CNPJ:"
                        txt_rota.Enabled = False
                        chk_rotas_todas.Enabled = False
                    End If

                    'dados do romaneio
                    If Not IsDBNull(.Item("id_romaneio")) Then
                        txt_nr_romaneio.Text = .Item("id_romaneio")
                    Else
                        txt_nr_romaneio.Text = String.Empty
                    End If
                    chk_romaneio_todos.Checked = .Item("st_todos_romaneios")

                    If Not IsDBNull(.Item("id_linha")) Then
                        txt_rota.Text = .Item("nm_linha")
                        hf_id_linha.Value = .Item("id_linha")
                    Else
                        txt_rota.Text = String.Empty
                        hf_id_linha.Value = String.Empty
                    End If
                    chk_rotas_todas.Checked = .Item("st_todas_rotas")

                    txt_ds_referencia.Text = .Item("ds_referencia").ToString()

                    hf_id_frete_periodo.Value = .Item("id_frete_periodo").ToString()

                    cbo_conta.SelectedValue = .Item("id_frete_conta").ToString()

                    txt_valor.Text = .Item("nr_valor").ToString()

                    If .Item("id_situacao") > 0 Then
                        cbo_situacao.SelectedValue = .Item("id_situacao").ToString
                        cbo_situacao.Enabled = True
                    End If

                    lbl_modificador.Text = .Item("id_modificador").ToString
                    lbl_dt_modificacao.Text = .Item("dt_modificacao").ToString

                End With

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        If Page.IsValid Then

            Try

                Dim lancamento As New FreteLancamento()


                lancamento.id_estabelecimento = cbo_estabelecimento.SelectedValue
                lancamento.id_transportador = hf_id_transportador.Value
                lancamento.id_tipo_frete = cbo_tipofrete.SelectedValue

                If Not (Me.hf_id_cooperativa.Value.Trim.Equals(String.Empty)) Then
                    lancamento.id_cooperativa = Convert.ToInt32(hf_id_cooperativa.Value)
                End If
                If Not (Me.txt_nr_romaneio.Text.Equals(String.Empty)) Then
                    lancamento.id_romaneio = Convert.ToInt32(txt_nr_romaneio.Text)
                Else
                    lancamento.id_romaneio = 0
                End If
                lancamento.st_todos_romaneios = chk_romaneio_todos.Checked
                If Not (Me.txt_rota.Text.Equals(String.Empty)) Then
                    lancamento.id_linha = Convert.ToInt32(hf_id_linha.Value)
                Else
                    lancamento.id_linha = 0
                End If
                lancamento.st_todas_rotas = chk_rotas_todas.Checked

                lancamento.dt_referencia = String.Concat("01/", txt_ds_referencia.Text.Trim)
                lancamento.id_frete_periodo = hf_id_frete_periodo.Value
                lancamento.id_frete_conta = cbo_conta.SelectedValue

                If Not (txt_valor.Text.Trim().Equals(String.Empty)) Then
                    lancamento.nr_valor = txt_valor.Text
                End If

                lancamento.id_situacao = cbo_situacao.SelectedValue

                lancamento.id_modificador = Session("id_login")

                If Not (ViewState.Item("id_frete_lancamento") Is Nothing) Then

                    lancamento.id_frete_lancamento = Convert.ToInt32(ViewState.Item("id_frete_lancamento"))
                    lancamento.updateLancamento()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 256
                    usuariolog.id_nr_processo = ViewState.Item("id_frete_lancamento")

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_frete_lancamento") = lancamento.insertFreteLancamento()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 256
                    usuariolog.id_nr_processo = ViewState.Item("id_frete_lancamento")
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro inserido com sucesso.")

                End If

                loadData()
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_frete_lancamento.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_frete_lancamento.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_frete_lancamento.aspx")

    End Sub

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        'fran 21/02/2011 gko fase 2 i
        If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
        Else
            txt_cd_transportador.Text = String.Empty
            hf_id_transportador.Value = String.Empty
            lbl_nm_transportador.Text = String.Empty
            lbl_nm_transportador.Visible = False
        End If
        'fran 21/02/2011 gko fase 2 f


    End Sub
    Private Sub carregarCamposTransportador()
        'fran 21/01/2011 1 gko fase 2

        Try

            If Not (customPage.getFilterValue("lupa_transcoop", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transcoop", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transcoop", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transcoop", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_transcoop")
            'fran 21/01/2011 f gko fase 2

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

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        lbl_nm_transportador.Text = String.Empty
        hf_id_transportador.Value = String.Empty

        loadTransportadorByCodigo()

    End Sub
    Private Sub loadCooperativaByCodigo(Optional ByVal id As Integer = 0)

        Try


            Dim cooperativa As New Pessoa

            If id > 0 Then
                cooperativa.id_pessoa = id
            Else
                cooperativa.cd_pessoa = txt_cd_cooperativa.Text
            End If

            Dim dscooperativa As DataSet = cooperativa.getCooperativasByCodigo()
            If dscooperativa.Tables(0).Rows.Count > 0 Then
                'lbl_nm_cooperativa.Visible = True
                'lbl_cd_cnpj.Visible = True
                'Me.lbl_nm_cnpj.Visible = True
                txt_cd_cooperativa.Text = dscooperativa.Tables(0).Rows(0).Item("cd_pessoa")
                lbl_nm_cooperativa.Text = dscooperativa.Tables(0).Rows(0).Item("nm_pessoa")
                lbl_cd_cnpj.Text = dscooperativa.Tables(0).Rows(0).Item("cd_cnpj")
                hf_id_cooperativa.Value = dscooperativa.Tables(0).Rows(0).Item("id_pessoa")
                'ViewState.Item("id_estado_cooperativa") = dscooperativa.Tables(0).Rows(0).Item("id_estado")
            Else
                'lbl_nm_cooperativa.Visible = False
                'lbl_cd_cnpj.Visible = False
                'Me.lbl_nm_cnpj.Visible = False
                hf_id_cooperativa.Value = String.Empty
                lbl_nm_cooperativa.Text = String.Empty
                lbl_cd_cnpj.Text = String.Empty
                'ViewState.Item("id_estado_cooperativa") = 0
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadTransportadorByCodigo(Optional ByVal id As Integer = 0)

        Try


            Dim transp As New Pessoa

            If id > 0 Then
                transp.id_pessoa = id
            Else
                transp.cd_pessoa = txt_cd_transportador.Text
            End If

            Dim dstransp As DataSet = transp.getTransportadorCooperativaByFilters()
            If dstransp.Tables(0).Rows.Count > 0 Then
                txt_cd_transportador.Text = dstransp.Tables(0).Rows(0).Item("cd_pessoa")
                'lbl_nm_transportador.Visible = True
                lbl_nm_transportador.Text = dstransp.Tables(0).Rows(0).Item("nm_pessoa")
                hf_id_transportador.Value = dstransp.Tables(0).Rows(0).Item("id_pessoa")
            Else
                'lbl_nm_transportador.Visible = False
                hf_id_transportador.Value = String.Empty
                lbl_nm_transportador.Text = String.Empty
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cbo_tipofrete_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipofrete.SelectedIndexChanged
        If cbo_tipofrete.SelectedValue = 2 Then
            txt_cd_cooperativa.Enabled = True
            btn_lupa_cooperativa.Enabled = True
            lbl_nm_cnpj.Text = "CNPJ:"
            rf_cd_cooperativa.Enabled = True
            txt_rota.Text = String.Empty
            chk_rotas_todas.Checked = False
            chk_rotas_todas.Enabled = False
            txt_rota.Enabled = False
        Else
            txt_cd_cooperativa.Text = String.Empty
            txt_cd_cooperativa.Enabled = False
            btn_lupa_cooperativa.Enabled = False
            rf_cd_cooperativa.Enabled = False
            lbl_nm_cooperativa.Text = String.Empty
            lbl_cd_cnpj.Text = String.Empty
            lbl_nm_cnpj.Text = String.Empty
            chk_rotas_todas.Enabled = True
            txt_rota.Enabled = True

        End If
    End Sub

    Protected Sub txt_cd_cooperativa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_cooperativa.TextChanged
        loadCooperativaByCodigo()
    End Sub

    Protected Sub cv_lancamento_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_lancamento.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True

            If Not txt_nr_romaneio.Text.Equals(String.Empty) AndAlso chk_romaneio_todos.Checked = True Then
                lmsg = "Lançamento por Romaneio deve ser informado o Número OU opção de 'Todos Romaneios'."
                args.IsValid = False
            End If
            If Not txt_rota.Text.Equals(String.Empty) AndAlso chk_rotas_todas.Checked = True Then
                lmsg = "Lançamento por Rota deve ser informado a Rota OU opção de 'Todas Rotas'."
                args.IsValid = False
            End If

            If args.IsValid = True AndAlso Not txt_nr_romaneio.Text.Equals(String.Empty) Then
                If Not txt_rota.Text.Equals(String.Empty) OrElse chk_rotas_todas.Checked = True Then
                    lmsg = "Lançamento para Romaneio específico não deve ser informada Rota OU opção de 'Todas Rotas'."
                    args.IsValid = False

                End If
            End If
            If args.IsValid = True AndAlso chk_romaneio_todos.Checked = True AndAlso chk_rotas_todas.Checked = True Then
                lmsg = "Lançamento para 'Todos Romaneios' não deve ser informada opção de 'Todas Rotas'."
                args.IsValid = False
            End If
            If Not txt_rota.Text.Equals(String.Empty) Then
                Dim rota As New Linha
                rota.nm_linha = txt_rota.Text
                Dim dsrota As DataSet = rota.getLinhaByNome
                If dsrota.Tables(0).Rows.Count > 0 Then
                    hf_id_linha.Value = dsrota.Tables(0).Rows(0).Item("id_linha")
                Else
                    lmsg = "Rota informada não cadastrada no sistema."
                    args.IsValid = False
                End If
            End If

            If args.IsValid = True Then
                Dim periodo As New FretePeriodo
                periodo.dt_referencia = String.Concat("01/", txt_ds_referencia.Text)

                Dim dsperiodo As DataSet = periodo.getFretePeriodo
                If dsperiodo.Tables(0).Rows.Count > 0 Then
                    hf_id_frete_periodo.Value = dsperiodo.Tables(0).Rows(0).Item("id_frete_periodo")
                Else
                    lmsg = "Referência informada não está cadastrada em Frete Período."
                    args.IsValid = False
                End If

            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class
