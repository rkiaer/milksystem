Imports Danone.MilkSystem.Business

Partial Class frm_motorista
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_motorista.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportadores"
        End With

    End Sub
    Private Sub loadDetails()

        Try
            Dim estabel As New Estabelecimento

            'Dim grauInstrucao As New GrauInstrucao

            'cbo_grau_instrucao.DataSource = grauInstrucao.getGrausInstrucoesByFilters()
            'cbo_grau_instrucao.DataTextField = "nm_grau_instrucao"
            'cbo_grau_instrucao.DataValueField = "id_grau_instrucao"
            'cbo_grau_instrucao.DataBind()
            'cbo_grau_instrucao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim estado As New Estado

            cbo_estado.DataSource = estado.getEstadosByFilters()
            cbo_estado.DataTextField = "nm_estado"
            cbo_estado.DataValueField = "id_estado"
            cbo_estado.DataBind()
            cbo_estado.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_motorista") Is Nothing) Then
                ViewState.Item("id_motorista") = Request("id_motorista")
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub cbo_estado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estado.SelectedIndexChanged

        If Not (cbo_estado.SelectedValue.Trim().Equals("0")) Then
            loadCidadesByEstado(Convert.ToInt32(cbo_estado.SelectedValue))
        Else
            cbo_cidade.Items.Clear()
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_cidade.Enabled = False
        End If

    End Sub

    Private Sub loadCidadesByEstado(ByVal id_estado As Int32)

        Try

            cbo_cidade.Enabled = True

            Dim cidade As New Cidade
            cidade.id_estado = id_estado

            cbo_cidade.DataSource = cidade.getCidadeByFilters()
            cbo_cidade.DataTextField = "nm_cidade"
            cbo_cidade.DataValueField = "id_cidade"
            cbo_cidade.DataBind()
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", "0"))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim id_motorista As Int32 = Convert.ToInt32(ViewState.Item("id_motorista"))
            Dim motorista As New Motorista(id_motorista)

            txt_nm_motorista.Text = motorista.nm_motorista
            txt_cd_cnh.Text = motorista.cd_cnh
            txt_cd_cnh.Enabled = False

            If Not (motorista.dt_validade_cnh Is Nothing) Then  ' 16/08/2008
                txt_dt_validade_cnh.Text = DateTime.Parse(motorista.dt_validade_cnh).ToString("dd/MM/yyyy")
            End If

            If Not (motorista.dt_nascimento Is Nothing) Then
                txt_dt_nascimento.Text = DateTime.Parse(motorista.dt_nascimento).ToString("dd/MM/yyyy")
            End If

            If Not (motorista.st_sexo.Trim().Equals(String.Empty)) Then
                cbo_sexo.SelectedValue = motorista.st_sexo
            End If
            If (motorista.id_grau_instrucao > 0) Then
                cbo_grau_instrucao.SelectedValue = motorista.id_grau_instrucao.ToString()
            End If

            txt_nr_dependentes.Text = motorista.nr_dependentes
            txt_cpf.Text = motorista.cd_cpf
            txt_rg.Text = motorista.cd_rg
            txt_orgao_emissor.Text = motorista.cd_orgao_emissor
            If Not (motorista.dt_expedicao_rg Is Nothing) Then
                txt_dt_expedicao_rg.Text = DateTime.Parse(motorista.dt_expedicao_rg).ToString("dd/MM/yyyy")
            End If


            'txt_endereco.Text = motorista.ds_endereco
            'txt_numero.Text = motorista.nr_endereco.ToString()
            'txt_complemento.Text = motorista.ds_complemento
            'txt_bairro.Text = motorista.ds_bairro

            'If (motorista.id_cidade > 0) Then
            '    loadCidadesByEstado(motorista.id_estado)
            '    cbo_estado.SelectedValue = motorista.id_estado.ToString()
            '    cbo_cidade.SelectedValue = motorista.id_cidade.ToString()
            'End If

            'txt_cep.Text = motorista.cd_cep
            'txt_telefone1.Text = motorista.ds_telefone_1
            'txt_telefone2.Text = motorista.ds_telefone_2
            'txt_telefone3.Text = motorista.ds_telefone_3
            'txt_email.Text = motorista.ds_email

            If (motorista.id_pessoa > 0) Then
                txt_cd_transportador.Text = motorista.cd_pessoa.ToString
                lbl_nm_transportador.Visible = True
                lbl_nm_transportador.Text = motorista.nm_pessoa
                hf_id_pessoa.Value = motorista.id_pessoa
            End If

            If (motorista.id_situacao > 0) Then
                cbo_situacao.SelectedValue = motorista.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = motorista.id_modificador.ToString()
            lbl_dt_modificacao.Text = motorista.dt_modificacao.ToString()

            'fran fase 3 set/2014 i
            cbo_categoriacnh.SelectedValue = motorista.st_categoria_cnh.ToString
            txt_treinamento_esalq.Text = motorista.ds_treinamento_esalq.ToString
            'fran fase 3 set/2014 f



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        If Page.IsValid Then


            Try

                Dim motorista As New Motorista()



                motorista.nm_motorista = txt_nm_motorista.Text
                motorista.cd_cnh = txt_cd_cnh.Text
                motorista.dt_validade_cnh = txt_dt_validade_cnh.Text

                motorista.dt_nascimento = txt_dt_nascimento.Text
                If Not (cbo_sexo.SelectedValue.Trim().Equals(String.Empty)) Then
                    motorista.st_sexo = cbo_sexo.SelectedValue
                End If
                If Not (cbo_grau_instrucao.SelectedValue.Trim().Equals(String.Empty)) Then
                    motorista.id_grau_instrucao = Convert.ToInt32(cbo_grau_instrucao.SelectedValue)
                End If

                If Not (txt_nr_dependentes.Text.Trim.Equals(String.Empty)) Then
                    motorista.nr_dependentes = txt_nr_dependentes.Text
                End If
                motorista.cd_rg = txt_rg.Text
                motorista.cd_orgao_emissor = txt_orgao_emissor.Text
                motorista.cd_cpf = txt_cpf.Text
                motorista.dt_expedicao_rg = txt_dt_expedicao_rg.Text
                'motorista.ds_endereco = txt_endereco.Text
                'If Not (txt_numero.Text.Trim.Equals(String.Empty)) Then
                '    motorista.nr_endereco = txt_numero.Text
                'End If

                'motorista.ds_complemento = txt_complemento.Text
                'motorista.ds_bairro = txt_bairro.Text

                'If Not (cbo_cidade.SelectedValue.Trim().Equals(String.Empty)) Then
                '    motorista.id_cidade = Convert.ToInt32(cbo_cidade.SelectedValue)
                'End If

                'motorista.cd_cep = txt_cep.Text
                'motorista.ds_telefone_1 = txt_telefone1.Text
                'motorista.ds_telefone_2 = txt_telefone2.Text
                'motorista.ds_telefone_3 = txt_telefone3.Text
                'motorista.ds_email = txt_email.Text

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    motorista.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                If Not (txt_cd_transportador.Text.Trim.Equals(String.Empty)) Then
                    motorista.id_pessoa = hf_id_pessoa.Value
                End If

                'fran fase 3 i 
                motorista.st_categoria_cnh = cbo_categoriacnh.SelectedValue
                motorista.ds_treinamento_esalq = txt_treinamento_esalq.Text
                'fran fase 3 f

                motorista.id_modificador = Convert.ToInt32(Session("id_login"))

                If Not (ViewState.Item("id_motorista") Is Nothing) Then

                    motorista.id_motorista = Convert.ToInt32(ViewState.Item("id_motorista"))
                    motorista.updateMotorista()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'altercação
                    usuariolog.id_menu_item = 11
                    usuariolog.id_nr_processo = ViewState.Item("id_motorista")
                    usuariolog.nm_nr_processo = motorista.nm_motorista

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_motorista") = motorista.insertMotorista()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 11
                    usuariolog.id_nr_processo = ViewState.Item("id_motorista")
                    usuariolog.nm_nr_processo = motorista.nm_motorista

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
        Response.Redirect("lst_motorista.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_motorista.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
        Else
            txt_cd_transportador.Text = String.Empty
            hf_id_pessoa.Value = String.Empty
            lbl_nm_transportador.Text = String.Empty
            lbl_nm_transportador.Visible = False
        End If

    End Sub
    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidpessoa As Int32
            If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
            'lidpessoa = pessoa.validarTransportador'fran 09/01/2011 rls 27 gko
            lidpessoa = pessoa.validarTransportadorCooperativa 'fran 09/01/2011 rls 27 gko


            If lidpessoa > 0 Then
                args.IsValid = True
                hf_id_pessoa.Value = lidpessoa
            Else
                hf_id_pessoa.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Transportador não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposTransportador()

        Try


            'fran 09/01/2011 rls 27 gko i
            'If Not (customPage.getFilterValue("lupa_transportador", "nm_pessoa").Equals(String.Empty)) Then
            '    Me.lbl_nm_transportador.Visible = True
            '    Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transportador", "nm_pessoa").ToString
            'End If

            'If Not (customPage.getFilterValue("lupa_transportador", "cd_pessoa").Equals(String.Empty)) Then
            '    Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transportador", "cd_pessoa").ToString
            'End If

            ''loadData()
            'customPage.clearFilters("lupa_transportador")
            If Not (customPage.getFilterValue("lupa_transcoop", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transcoop", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transcoop", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transcoop", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_transcoop")
            'fran 09/01/2011 rls 27 gko f

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        lbl_nm_transportador.Text = String.Empty
        lbl_nm_transportador.Visible = False
        hf_id_pessoa.Value = String.Empty

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'Fran 02/03/2009 i
        Response.Redirect("frm_motorista.aspx")
    End Sub
End Class
