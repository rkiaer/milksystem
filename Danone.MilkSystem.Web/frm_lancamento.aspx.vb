Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_lancamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_lancamento.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With bt_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With
        'fran 21/02/2011 gko fase 2 i
        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportadores"
        End With
        'fran 21/02/2011 gko fase 2 2

    End Sub

    Private Sub loadDetails()

        Try


            Dim conta As New Conta
            If (Request("id_lancamento") Is Nothing) Then
                conta.id_situacao = 1
            End If

            cbo_conta.DataSource = conta.getContaLancamentoByFilters()
            cbo_conta.DataTextField = "ds_conta"
            cbo_conta.DataValueField = "id_conta"
            cbo_conta.DataBind()
            cbo_conta.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_lancamento") Is Nothing) Then
                ViewState.Item("id_lancamento") = Request("id_lancamento")
                loadData()
            Else
                lbl_titulo_produtor.Visible = False
                lbl_titulo_estabelecimento.Visible = False
                bt_lupa_propriedade.Visible = True
                lbl_nm_propriedade.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub




    Private Sub loadData()

        Try

            Dim id_lancamento As Int32 = Convert.ToInt32(ViewState.Item("id_lancamento"))
            Dim lancamento As New Lancamento(id_lancamento)

            cbo_conta.Enabled = False
            txt_ds_referencia.Enabled = False

            lbl_produtor.Text = lancamento.ds_produtor
            lbl_estabelecimento.Visible = True
            lbl_estabelecimento.Text = lancamento.ds_estabelecimento
            txt_cd_propriedade.Text = lancamento.id_propriedade.ToString()
            lbl_nm_propriedade.Visible = True
            lbl_nm_propriedade.Text = lancamento.nm_propriedade
            txt_cd_propriedade.Enabled = False
            bt_lupa_propriedade.Visible = False
            'Fran 21/01/2011 gko fase 2
            If lancamento.id_transportador > 0 Then
                txt_cd_transportador.Text = lancamento.cd_transportador
                lbl_nm_transportador.Visible = True
                lbl_nm_transportador.Text = lancamento.nm_transportador
                txt_cd_transportador.Enabled = False
                btn_lupa_transportador.Visible = False
                hf_id_transportador.Value = lancamento.id_transportador
            End If
            'Fran 21/01/2011 gko fase 2

            If (lancamento.id_conta > 0) Then
                cbo_conta.SelectedValue = lancamento.id_conta.ToString()
            End If

            txt_valor.Text = lancamento.nr_valor

            'If Not (lancamento.dt_referencia Is Nothing) Then
            'txt_dt_referencia.Text = DateTime.Parse(lancamento.dt_referencia).ToString("dd/MM/yyyy")
            'End If

            txt_ds_referencia.Text = lancamento.ds_referencia.ToString()

            If (lancamento.id_situacao > 0) Then
                cbo_situacao.SelectedValue = lancamento.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = lancamento.id_modificador.ToString()
            lbl_dt_modificacao.Text = lancamento.dt_modificacao.ToString()

            lbl_titulo_produtor.Visible = True
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        If Page.IsValid Then

            Try

                Dim lancamento As New Lancamento()


                lancamento.id_propriedade = txt_cd_propriedade.Text

                If Not (cbo_conta.SelectedValue.Trim().Equals(String.Empty)) Then
                    lancamento.id_conta = Convert.ToInt32(cbo_conta.SelectedValue)
                End If

                If Not (txt_valor.Text.Trim().Equals(String.Empty)) Then
                    lancamento.nr_valor = txt_valor.Text
                End If

                lancamento.ds_referencia = txt_ds_referencia.Text.Trim
                lancamento.dt_referencia = String.Concat("01/", lancamento.ds_referencia)

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    lancamento.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                lancamento.id_modificador = Session("id_login")
                'Fran 21/01/2011 gko fase 2
                If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then  '  21/02/2011 - Adriana - chamado 1192 - Campo não pode ser obrigatório - i
                    lancamento.id_transportador = Convert.ToInt32(hf_id_transportador.Value)
                End If
                'Fran 21/01/2011 gko fase 2

                If Page.IsValid Then
                    If Not (ViewState.Item("id_lancamento") Is Nothing) Then

                        lancamento.id_lancamento = Convert.ToInt32(ViewState.Item("id_lancamento"))
                        lancamento.updateLancamento()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alteracao
                        usuariolog.id_menu_item = 31
                        usuariolog.id_nr_processo = ViewState.Item("id_lancamento")

                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro alterado com sucesso.")

                    Else

                        ViewState.Item("id_lancamento") = lancamento.insertLancamento()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 4 'inclusao
                        usuariolog.id_menu_item = 31
                        usuariolog.id_nr_processo = ViewState.Item("id_lancamento")

                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro inserido com sucesso.")

                    End If

                    loadData()
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_lancamento.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_lancamento.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Private Sub carregarCamposPropriedade()

        Try

            If Not (customPage.getFilterValue("lupa_propriedade", "pessoa").Equals(String.Empty)) Then
                Me.lbl_titulo_produtor.Visible = True
                Me.lbl_produtor.Visible = True
                Me.lbl_produtor.Text = customPage.getFilterValue("lupa_propriedade", "pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_propriedade", "estabelecimento").Equals(String.Empty)) Then
                Me.lbl_titulo_estabelecimento.Visible = True
                Me.lbl_estabelecimento.Visible = True
                Me.lbl_estabelecimento.Text = customPage.getFilterValue("lupa_propriedade", "estabelecimento").ToString
            End If
            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.lbl_nm_propriedade.Visible = True
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cmv_propriedade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_propriedade.ServerValidate, cmv_propriedade.ServerValidate
        Try
            Dim propriedade As New Propriedade()

            propriedade.id_propriedade = Trim(txt_cd_propriedade.Text)

            args.IsValid = propriedade.validarPropriedade()

            If Not args.IsValid Then
                messageControl.Alert("Propriedade não cadastrada.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub bt_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_propriedade.Click
        If Not (Me.hf_id_propriedade.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            txt_cd_propriedade.Text = hf_id_propriedade.Value.ToString
            carregarCamposPropriedade()
        End If

    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
        hf_id_propriedade.Value = String.Empty
        lbl_estabelecimento.Text = String.Empty
        lbl_estabelecimento.Visible = False
        lbl_produtor.Text = String.Empty
        lbl_produtor.Visible = False
        lbl_titulo_estabelecimento.Visible = False
        lbl_titulo_produtor.Visible = False
        lbl_nm_propriedade.Text = String.Empty
        lbl_nm_propriedade.Visible = False
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_lancamento.aspx")

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
        lbl_nm_transportador.Visible = False
        hf_id_transportador.Value = String.Empty

        ' Adriana - chamado 1192 - Para gravar o transportador se o código for digitado - i
        Try
            If Not txt_cd_transportador.Text.ToString.Equals(String.Empty) Then
                Dim pessoa As New Pessoa
                pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
                Dim dsPessoa As DataSet = pessoa.getTransportadorCooperativaByFilters
                If dsPessoa.Tables(0).Rows.Count > 0 Then
                    lbl_nm_transportador.Visible = True
                    lbl_nm_transportador.Text = dsPessoa.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_transportador.Value = dsPessoa.Tables(0).Rows(0).Item("id_pessoa").ToString
                Else
                    lbl_nm_transportador.Text = String.Empty
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' Adriana - chamado 1192 - Para gravar o transportador se o código for digitado - f

    End Sub
End Class
