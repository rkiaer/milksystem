Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_pessoa
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_pessoa.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        'fran 07/2017 i
        'With btn_lupa_contrato
        '    .Attributes.Add("onclick", "javascript:ShowDialogContrato()")
        '    .ToolTip = "Filtrar Contratos"
        'End With

    End Sub
    Private Sub habilitarPessoa()

        ' 08/08/2008 - Os dados vem do EMS e não podem ser alterados nesta aplicação

        'txt_rg.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'txt_orgao_emissor.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'txt_cpf.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'txt_dt_nascimento.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'cbo_sexo.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'cbo_grau_instrucao.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'cbo_nacionalidades.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'rfv_cpf.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'txt_nr_dependentes.Enabled = cbo_categoria.SelectedValue.Equals("F")

        'txt_cnpj.Enabled = cbo_categoria.SelectedValue.Equals("J")
        'cbo_empresa_nacional.Enabled = cbo_categoria.SelectedValue.Equals("J")
        'txt_inscricao_estadual.Enabled = cbo_categoria.SelectedValue.Equals("J")
        'txt_inscricao_municipal.Enabled = cbo_categoria.SelectedValue.Equals("J")
        'rfv_cnpj.Enabled = cbo_categoria.SelectedValue.Equals("J")

        'Fran 30/03/2009 rls 17 - habilitei campos pois há campos que devem ser alterados - i
        txt_rg.Enabled = cbo_categoria.SelectedValue.Equals("F")
        txt_orgao_emissor.Enabled = cbo_categoria.SelectedValue.Equals("F")
        txt_dt_nascimento.Enabled = cbo_categoria.SelectedValue.Equals("F")
        cbo_sexo.Enabled = cbo_categoria.SelectedValue.Equals("F")
        cbo_nacionalidades.Enabled = cbo_categoria.SelectedValue.Equals("F")
        txt_nr_dependentes.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'Fran 30/03/2009 rls 17 - habilitei campos pois há campos que devem ser alterados - f

    End Sub
    Private Sub loadDetails()

        Try

            Dim estabel As New Estabelecimento

            ' 08/08/2008 - Somente nesta tela pode exibir o estabelecimento reservado '999' para pessoas vindas do EMS
            cbo_estabelecimento.DataSource = estabel.getEstabelecimentoPessoaByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim grupo As New Grupo

            cbo_grupo.DataSource = grupo.getGruposByFilters()
            cbo_grupo.DataTextField = "nm_grupo"
            cbo_grupo.DataValueField = "id_grupo"
            cbo_grupo.DataBind()
            cbo_grupo.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            Dim nacionalidade As New Nacionalidade

            cbo_nacionalidades.DataSource = nacionalidade.getNacionalidadesByFilters()
            cbo_nacionalidades.DataTextField = "nm_nacionalidade"
            cbo_nacionalidades.DataValueField = "id_nacionalidade"
            cbo_nacionalidades.DataBind()
            cbo_nacionalidades.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            Dim grauInstrucao As New GrauInstrucao

            cbo_grau_instrucao.DataSource = grauInstrucao.getGrausInstrucoesByFilters()
            cbo_grau_instrucao.DataTextField = "nm_grau_instrucao"
            cbo_grau_instrucao.DataValueField = "id_grau_instrucao"
            cbo_grau_instrucao.DataBind()
            cbo_grau_instrucao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            Dim estado As New Estado

            cbo_estado.DataSource = estado.getEstadosByFilters()
            cbo_estado.DataTextField = "nm_estado"
            cbo_estado.DataValueField = "id_estado"
            cbo_estado.DataBind()
            cbo_estado.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim tipoConta As New TipoConta

            cbo_tipo_conta.DataSource = tipoConta.getTiposConta()
            cbo_tipo_conta.DataTextField = "nm_tipo_conta"
            cbo_tipo_conta.DataValueField = "id_tipo_conta"
            cbo_tipo_conta.DataBind()
            cbo_tipo_conta.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            Dim banco As New Banco

            cbo_bancos.DataSource = banco.getBancosByFilters()
            cbo_bancos.DataTextField = "ds_banco" 'visualiza o numero do banco e o nome do banco
            cbo_bancos.DataValueField = "id_banco"
            cbo_bancos.DataBind()
            cbo_bancos.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            Dim pessoaSituacoes As New PessoaSituacao

            cbo_pessoa_situacao.DataSource = pessoaSituacoes.getPessoaSituacoesByFilters()
            cbo_pessoa_situacao.DataTextField = "nm_pessoa_situacao"
            cbo_pessoa_situacao.DataValueField = "id_pessoa_situacao"
            cbo_pessoa_situacao.DataBind()
            cbo_pessoa_situacao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            'fran fase 3 i
            Dim cluster As New Cluster
            cbo_cluster.DataSource = cluster.getClusterByFilters()
            cbo_cluster.DataTextField = "nm_cluster"
            cbo_cluster.DataValueField = "id_cluster"
            cbo_cluster.DataBind()
            cbo_cluster.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'fran fase 3 f

            If Not (Request("id_pessoa") Is Nothing) Then
                'fran 07/2018 i
                'BUSCA SE O USURIO TEM ACESSO AO PROCESSO MODELO DE CONTRATO PRODUTOR
                Dim usuarioprocesso As New GrupoAcessoProcesso
                usuarioprocesso.id_menu_item_processo = 1 'Proceurar o processo 1 - Modelo de COntrato Produtor
                usuarioprocesso.id_usuario = Session("id_login") 'usuario de acesso
                Dim dsusuarioprocesso As DataSet = usuarioprocesso.getGrupoAcessoProcessoByFilters
                'SE TEM DIREIRO A ACESSAR MODELO DE CONBTRATO
                If dsusuarioprocesso.Tables(0).Rows.Count > 0 Then
                    ViewState.Item("acessomodelodecontrato") = True
                    lk_modelo_contrato.Visible = True
                Else 'SE NAO TEM ACESSO
                    ViewState.Item("acessomodelodecontrato") = False
                    lk_modelo_contrato.Visible = False
                End If
                'fran 07/2018 f
                ViewState.Item("id_pessoa") = Request("id_pessoa")
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub cbo_categoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_categoria.SelectedIndexChanged

        habilitarPessoa()

        'txt_rg.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'txt_orgao_emissor.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'txt_cpf.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'txt_dt_nascimento.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'cbo_sexo.Enabled = cbo_categoria.SelectedValue.Equals("F")
        'cbo_grau_instrucao.Enabled = cbo_categoria.SelectedValue.Equals("F")

        'txt_cnpj.Enabled = cbo_categoria.SelectedValue.Equals("J")
        'cbo_empresa_nacional.Enabled = cbo_categoria.SelectedValue.Equals("J")
        'txt_inscricao_estadual.Enabled = cbo_categoria.SelectedValue.Equals("J")
        'txt_inscricao_municipal.Enabled = cbo_categoria.SelectedValue.Equals("J")


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

            'cbo_cidade.Enabled = True

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

            Dim id_pessoa As Int32 = Convert.ToInt32(ViewState.Item("id_pessoa"))
            Dim pessoa As New Pessoa(id_pessoa)

            ViewState.Item("st_transportador_central_cadastro") = pessoa.st_transportador_central

            txt_cd_pessoa.Text = pessoa.cd_pessoa
            txt_cd_pessoa.Enabled = False
            txt_codigo_SAP.Text = pessoa.cd_codigo_SAP  ' 02/2012 - Projeto Themis Rls 31

            If Not (pessoa.st_categoria.Trim().Equals(String.Empty)) Then
                cbo_categoria.SelectedValue = pessoa.st_categoria
                habilitarPessoa()
                cbo_categoria.Enabled = False
            End If


            txt_nm_pessoa.Text = pessoa.nm_pessoa

            'Fran 27/08/2009 i Rls 19
            txt_nm_abreviado.Text = pessoa.nm_abreviado
            'fran 27/08/2009 f 

            If (pessoa.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = pessoa.id_estabelecimento.ToString()
                Dim estabelecimento As New Estabelecimento

                estabelecimento.id_estabelecimento = pessoa.id_estabelecimento
                Dim dsEstabelecimento As DataSet = estabelecimento.getEstabelecimentoPessoaByFilters()
                If (dsEstabelecimento.Tables(0).Rows.Count > 0) Then
                    If dsEstabelecimento.Tables(0).Rows(0).Item("cd_estabelecimento") = "999" Then   ' Se estabelecimento reservado para novas pessoas vindas do EMS (lá não tem código de estabelecimento)
                        cbo_estabelecimento.Enabled = True
                    Else
                        cbo_estabelecimento.Enabled = False
                    End If
                End If
            End If


            If (pessoa.id_grupo > 0) Then
                cbo_grupo.SelectedValue = pessoa.id_grupo.ToString()
                cbo_grupo.Enabled = False
            End If
			'Fran 19/11/2009 i
			If pessoa.id_grupo = 4 Then 'se cooperativa
				txt_nr_distancia.enabled = true
				txt_nr_distancia.text = pessoa.nr_distancia
                txt_pedagio_eixo_cooperativa.Enabled = True
                txt_pedagio_eixo_cooperativa.Text = pessoa.nr_pedagio_eixo_cooperativa
            Else
                txt_nr_distancia.Enabled = False
                txt_nr_distancia.Text = String.Empty
                txt_pedagio_eixo_cooperativa.Enabled = False
                txt_pedagio_eixo_cooperativa.Text = String.Empty
            End If
			'Fran 19/11/2009 f
            txt_cnpj.Text = pessoa.cd_cnpj

            If Not (pessoa.st_empresa_nacional.Trim().Equals(String.Empty)) Then
                cbo_empresa_nacional.SelectedValue = pessoa.st_empresa_nacional
            End If

            txt_inscricao_estadual.Text = pessoa.cd_inscricao_estadual
            txt_inscricao_municipal.Text = pessoa.cd_inscricao_municipal
            txt_rg.Text = pessoa.cd_rg
            txt_orgao_emissor.Text = pessoa.cd_orgao_emissor
            txt_cpf.Text = pessoa.cd_cpf

            If Not (pessoa.dt_nascimento Is Nothing) Then
                txt_dt_nascimento.Text = DateTime.Parse(pessoa.dt_nascimento).ToString("dd/MM/yyyy")
            End If

            If Not (pessoa.st_sexo.Trim().Equals(String.Empty)) Then
                cbo_sexo.SelectedValue = pessoa.st_sexo
            End If

            If (pessoa.id_nacionalidade > 0) Then
                cbo_nacionalidades.SelectedValue = pessoa.id_nacionalidade.ToString()
            End If

            If (pessoa.id_grau_instrucao > 0) Then
                cbo_grau_instrucao.SelectedValue = pessoa.id_grau_instrucao.ToString()
            End If
            txt_nr_dependentes.Text = pessoa.nr_dependentes

            txt_endereco.Text = pessoa.ds_endereco
            txt_numero.Text = pessoa.nr_endereco.ToString()
            txt_complemento.Text = pessoa.ds_complemento
            txt_bairro.Text = pessoa.ds_bairro

            If (pessoa.id_cidade > 0) Then
                loadCidadesByEstado(pessoa.id_estado)
                cbo_estado.SelectedValue = pessoa.id_estado.ToString()
                cbo_cidade.SelectedValue = pessoa.id_cidade.ToString()
            End If

            txt_cep.Text = pessoa.cd_cep
            txt_caixa_postal.Text = pessoa.cd_caixa_postal
            txt_telefone1.Text = pessoa.ds_telefone_1
            txt_telefone2.Text = pessoa.ds_telefone_2
            txt_fax.Text = pessoa.ds_telefone_3
            txt_email.Text = pessoa.ds_email

            If (pessoa.id_tipo_conta > 0) Then
                cbo_tipo_conta.SelectedValue = pessoa.id_tipo_conta.ToString()
            End If

            If (pessoa.id_banco > 0) Then
                cbo_bancos.SelectedValue = pessoa.id_banco.ToString()
            End If

            txt_conta.Text = pessoa.cd_conta
            txt_cd_agencia.Text = pessoa.cd_agencia

            txt_sif.Text = pessoa.cd_sif
            If Not (pessoa.dt_expiracao_dqse Is Nothing) Then
                txt_expiracao_dqse.Text = DateTime.Parse(pessoa.dt_expiracao_dqse).ToString("dd/MM/yyyy")
            End If

            txt_valor_disponivel.Text = pessoa.nr_valor_disponivel

            If Not (pessoa.st_emite_nota_fiscal.Trim().Equals(String.Empty)) Then   ' 29/09/2008
                cbo_emite_nota_fiscal.SelectedValue = pessoa.st_emite_nota_fiscal
            End If
            'fran chamado 905 rls 24.10 i
            If Not (pessoa.st_acordo_aquisicao_insumos Is Nothing) Then 'fran 29/09/2010 i para produção
                If Not (pessoa.st_acordo_aquisicao_insumos.Trim().Equals(String.Empty)) Then
                    cbo_st_acordo_aquisicao_insumos.SelectedValue = pessoa.st_acordo_aquisicao_insumos
                End If

            End If
            If Not (pessoa.dt_adesao_acordo_insumos Is Nothing) Then
                txt_dt_adesao_acordo_insumos.Text = DateTime.Parse(pessoa.dt_adesao_acordo_insumos).ToString("dd/MM/yyyy")
            End If
            'fran chamado 905 rls 24.10 f
            If (pessoa.id_pessoa_situacao > 0) Then
                cbo_pessoa_situacao.SelectedValue = pessoa.id_pessoa_situacao.ToString()
            End If

            If (pessoa.id_situacao > 0) Then
                cbo_situacao.SelectedValue = pessoa.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If
            'Fran 14/10/2009 i Central Compras
            txt_ds_email2.Text = pessoa.ds_email2
            txt_ds_contato.Text = pessoa.ds_contato
            If pessoa.nr_contrato > 0 Then
                txt_nr_contrato.Text = pessoa.nr_contrato
            End If
            'Fran 14/10/2009 f
            'fran fase 3
            'se for grupo produtor
            If pessoa.id_grupo.Equals(1) Then
                'fran dango 2018 rf_cluster.Enabled = True
                'fran dango 2018 cbo_cluster.Enabled = True
                If pessoa.id_cluster > 0 Then
                    cbo_cluster.SelectedValue = pessoa.id_cluster
                End If
                'fran 07/2017 i
                'fran dango 2018 cbo_adicional_volume.Enabled = True
                If pessoa.nr_adicional_volume > 0 Then
                    cbo_adicional_volume.SelectedValue = pessoa.nr_adicional_volume
                Else
                    cbo_adicional_volume.SelectedValue = 24
                End If
                'fran dango 2018 rf_contrato.Enabled = True
                'fran dango 2018 cv_contrato.Enabled = True
                'fran dango 2018 txt_cd_contrato.Enabled = True
                'fran dango 2018 btn_lupa_contrato.Visible = True
                'fran dango 2018 btn_lupa_contrato.Enabled = True
                If pessoa.id_contrato > 0 Then
                    Dim contrato As New Contrato(pessoa.id_contrato)
                    txt_cd_contrato.Text = contrato.cd_contrato.ToString
                    hf_id_contrato.Value = pessoa.id_contrato
                    lbl_nm_contrato.Text = contrato.nm_contrato.ToString

                    Dim pessoacontrato As New PessoaContrato()
                    Dim dspessoacontrato As DataSet
                    pessoacontrato.id_pessoa = pessoa.id_pessoa
                    dspessoacontrato = pessoacontrato.getPessoaContratoByFilters
                    'pega a situação contrato (aprovado em aprovacao etc)
                    If dspessoacontrato.Tables(0).Rows.Count > 0 Then
                        lbl_contrato_situacao.Text = String.Concat("*", dspessoacontrato.Tables(0).Rows(0).Item("nm_situacao_pessoa_contrato").ToString)
                    Else
                        lbl_contrato_situacao.Text = String.Empty
                    End If

                Else
                    lbl_nm_contrato.Text = String.Empty
                    lbl_contrato_situacao.Text = "CONTRATO NÃO INFORMADO."
                End If

                'fran 07/2017 f
                If cbo_estabelecimento.Enabled = False And ViewState.Item("acessomodelodecontrato") = True Then 'se ja salvou o estabelecimento
                    lk_modelo_contrato.Enabled = True
                End If
                'Fran 31/01/2019 i - FUNRURAL 2019
                cbo_st_funrural.Enabled = True
                If pessoa.st_funrural = "P" Then
                    cbo_st_funrural.SelectedValue = "P"
                Else
                    cbo_st_funrural.SelectedValue = "D"
                End If
                'Fran 31/01/2019 f - FUNRURAL 2019
            Else
                'fran dango 2018 rf_cluster.Enabled = False
                'fran dango 2018 cbo_cluster.Enabled = False
                'fran 07/2017 i
                cbo_adicional_volume.Enabled = False
                'fran dango 2018 rf_contrato.Enabled = False
                'fran dango 2018 cv_contrato.Enabled = False
                txt_cd_contrato.Enabled = False
                'fran dango 2018 btn_lupa_contrato.Visible = False
                txt_cd_contrato.Enabled = False
                hf_id_contrato.Value = String.Empty
                lbl_nm_contrato.Text = String.Empty
                'fran 07/2017 f
                'Fran 31/01/2019 i - FUNRURAL 2019
                cbo_st_funrural.Enabled = False
                'Fran 31/01/2019 f - FUNRURAL 2019

            End If
            'fran fase 3 f

            If (Not pessoa.ds_celular.Equals(String.Empty)) Then
                Me.txt_celular_ddd.Text = Strings.Left(pessoa.ds_celular, 2)
                Me.txt_celular.Text = Strings.Right(Strings.Trim(pessoa.ds_celular), 9)
            End If
            Select Case pessoa.id_grupo
                Case 1
                    Me.cbo_st_transportador_central.Enabled = False
                    Me.cbo_st_frete_cif.Enabled = False
                    Me.cbo_excecao_prazo_pagto.Enabled = False
                    Me.txt_nr_fornecedor_parcelas_central.Text = String.Empty
                    Me.txt_nr_fornecedor_parcelas_central.Enabled = False
                Case 2
                    Me.cbo_st_transportador_central.Enabled = False
                    Me.cbo_st_frete_cif.Enabled = True
                    Me.cbo_excecao_prazo_pagto.Enabled = True
                    Me.txt_nr_fornecedor_parcelas_central.Enabled = True
                    Me.cbo_st_frete_cif.SelectedValue = pessoa.st_fornecedor_CIF
                    Me.cbo_excecao_prazo_pagto.SelectedValue = pessoa.st_excecao_prazo_pagto
                    Me.txt_nr_fornecedor_parcelas_central.Text = pessoa.nr_fornecedor_parcelas_central.ToString
                Case 3
                    Me.cbo_st_transportador_central.Enabled = True
                    Me.cbo_st_frete_cif.Enabled = False
                    Me.cbo_excecao_prazo_pagto.Enabled = True
                    Me.txt_nr_fornecedor_parcelas_central.Text = String.Empty
                    Me.txt_nr_fornecedor_parcelas_central.Enabled = False
                    Me.cbo_excecao_prazo_pagto.SelectedValue = pessoa.st_excecao_prazo_pagto
                    Me.cbo_st_transportador_central.SelectedValue = pessoa.st_transportador_central
            End Select


            lbl_modificador.Text = pessoa.id_modificador.ToString()
            lbl_dt_modificacao.Text = pessoa.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid Then

            Try

                Dim pessoa As New Pessoa()

                pessoa.cd_pessoa = txt_cd_pessoa.Text

                If Not (cbo_categoria.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.st_categoria = cbo_categoria.SelectedValue
                End If

                pessoa.nm_pessoa = txt_nm_pessoa.Text

                'Fran 27/08/2009 i - rls 19 
                pessoa.nm_abreviado = txt_nm_abreviado.Text
                'fran 27/08/2009 f

                If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                End If

                If Not (cbo_grupo.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.id_grupo = Convert.ToInt32(cbo_grupo.SelectedValue)
                End If

                'Fran 19/11/2009 i
                If pessoa.id_grupo = 4 Then 'se cooperativa
                    If Not (txt_nr_distancia.Text.Trim().Equals(String.Empty)) Then
                        pessoa.nr_distancia = txt_nr_distancia.Text
                    End If
                    If Not (txt_pedagio_eixo_cooperativa.Text.Trim().Equals(String.Empty)) Then
                        pessoa.nr_pedagio_eixo_cooperativa = txt_pedagio_eixo_cooperativa.Text
                    End If

                End If
                'Fran 19/11/2009 f

                pessoa.cd_cnpj = txt_cnpj.Text

                If Not (cbo_empresa_nacional.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.st_empresa_nacional = cbo_empresa_nacional.SelectedValue
                End If

                pessoa.cd_inscricao_estadual = txt_inscricao_estadual.Text
                pessoa.cd_inscricao_municipal = txt_inscricao_municipal.Text
                pessoa.cd_rg = txt_rg.Text
                pessoa.cd_orgao_emissor = txt_orgao_emissor.Text
                pessoa.cd_cpf = txt_cpf.Text
                pessoa.dt_nascimento = txt_dt_nascimento.Text

                If Not (cbo_sexo.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.st_sexo = cbo_sexo.SelectedValue
                End If

                If Not (cbo_nacionalidades.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.id_nacionalidade = Convert.ToInt32(cbo_nacionalidades.SelectedValue)
                End If

                If Not (cbo_grau_instrucao.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.id_grau_instrucao = Convert.ToInt32(cbo_grau_instrucao.SelectedValue)
                End If

                If Not (txt_nr_dependentes.Text.Trim.Equals(String.Empty)) Then
                    pessoa.nr_dependentes = txt_nr_dependentes.Text
                End If

                pessoa.ds_endereco = txt_endereco.Text

                If Not (txt_numero.Text.Trim.Equals(String.Empty)) Then
                    pessoa.nr_endereco = txt_numero.Text
                End If

                pessoa.ds_complemento = txt_complemento.Text
                pessoa.ds_bairro = txt_bairro.Text

                If Not (cbo_cidade.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.id_cidade = Convert.ToInt32(cbo_cidade.SelectedValue)
                End If

                pessoa.cd_cep = txt_cep.Text
                pessoa.cd_caixa_postal = txt_caixa_postal.Text
                pessoa.ds_telefone_1 = txt_telefone1.Text
                pessoa.ds_telefone_2 = txt_telefone2.Text
                pessoa.ds_telefone_3 = txt_fax.Text
                pessoa.ds_email = txt_email.Text
                'Fran 14/10/2009 i Central Compras
                pessoa.ds_email2 = txt_ds_email2.Text
                pessoa.ds_contato = txt_ds_contato.Text
                If Not (txt_nr_contrato.Text.Trim.Equals(String.Empty)) Then
                    pessoa.nr_contrato = txt_nr_contrato.Text
                End If
                'Fran 14/10/2009 f
                If Not (cbo_tipo_conta.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.id_tipo_conta = Convert.ToInt32(cbo_tipo_conta.SelectedValue)
                End If

                If Not (cbo_bancos.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.id_banco = Convert.ToInt32(cbo_bancos.SelectedValue)
                End If

                pessoa.cd_conta = txt_conta.Text
                pessoa.cd_agencia = txt_cd_agencia.Text

                pessoa.cd_sif = txt_sif.Text
                pessoa.dt_expiracao_dqse = txt_expiracao_dqse.Text

                If Not (txt_valor_disponivel.Text.Trim().Equals(String.Empty)) Then
                    pessoa.nr_valor_disponivel = txt_valor_disponivel.Text
                End If

                If Not (cbo_emite_nota_fiscal.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.st_emite_nota_fiscal = cbo_emite_nota_fiscal.SelectedValue
                End If
                'fran chamado 905 rls 24.10 i
                If Not (cbo_st_acordo_aquisicao_insumos.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.st_acordo_aquisicao_insumos = cbo_st_acordo_aquisicao_insumos.SelectedValue
                End If
                pessoa.dt_adesao_acordo_insumos = txt_dt_adesao_acordo_insumos.Text

                'fran chamado 905 rls 24.10 f

                If Not (cbo_pessoa_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.id_pessoa_situacao = Convert.ToInt32(cbo_pessoa_situacao.SelectedValue)
                End If

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    pessoa.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                'Fran 12/12/2013 i Precisa do codigo do sap pois caso contrario salva vazio
                pessoa.cd_codigo_SAP = txt_codigo_SAP.Text
                'Fran 12/12/2013 f Precisa do codigo do sap pois caso contrario salva vazio

                'fran fase 3 i
                If Not (cbo_cluster.SelectedValue.Trim.Equals(String.Empty)) Then
                    pessoa.id_cluster = cbo_cluster.SelectedValue
                End If
                'fran fase 3 f

                'fran 07/2017 i
                If pessoa.id_grupo.Equals(1) Then
                    'fran 07/2018 i 
                    If hf_id_contrato.Value.Equals(String.Empty) Then
                        pessoa.id_contrato = 0
                        'fran 07/2018 f

                    Else
                        pessoa.id_contrato = hf_id_contrato.Value
                    End If
                    pessoa.nr_adicional_volume = cbo_adicional_volume.SelectedValue

                End If
                'fran 07/2017 f

                'Fran 31/01/2019 i - FUNRURAL 2019
                pessoa.st_funrural = cbo_st_funrural.SelectedValue
                'Fran 31/01/2019 f - FUNRURAL 2019

                pessoa.st_transportador_central = cbo_st_transportador_central.SelectedValue
                pessoa.st_fornecedor_CIF = cbo_st_frete_cif.SelectedValue
                If txt_nr_fornecedor_parcelas_central.Text.Equals(String.Empty) Then
                    If (pessoa.id_grupo <> 2) Then
                        pessoa.nr_fornecedor_parcelas_central = 0
                    Else
                        pessoa.nr_fornecedor_parcelas_central = 1
                    End If
                Else 'se tem valor em parcelas
                    If (pessoa.id_grupo <> 2) Then
                        pessoa.nr_fornecedor_parcelas_central = 0
                    Else
                        pessoa.nr_fornecedor_parcelas_central = CInt(txt_nr_fornecedor_parcelas_central.Text)
                    End If
                End If
                pessoa.st_excecao_prazo_pagto = cbo_excecao_prazo_pagto.SelectedValue
                pessoa.ds_celular = String.Concat(Me.txt_celular_ddd.Text, Me.txt_celular.Text)

                pessoa.id_modificador = Session("id_login")

                If Not (ViewState.Item("id_pessoa") Is Nothing) Then

                    pessoa.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))

                    ' 16/08/2008 - Gera Propriedade e Unidade Produção default para Cooperativas - i
                    If cbo_estabelecimento.Enabled = True And pessoa.id_grupo = 4 Then   '  Se está salvando no estabelecimento '999' e é uma Cooperativa
                        Dim estabelecimento As New Estabelecimento(pessoa.id_estabelecimento)
                        If estabelecimento.cd_estabelecimento <> "999" Then  'Se está trocando de estabelecimento
                            pessoa.updatePessoaPropriedade()
                        Else
                            pessoa.updatePessoa()
                        End If
                    Else

                        ' 28/02/2012 - Projeto Themis - Importação de Fornecedores - i
                        'pessoa.updatePessoa()

                        ' O sistema não permitia a criação de uma propriedade enquanto o Produtor estivesse no estabelecimento
                        ' temporário. Através do novo modelo de importação do projeto Themis esta situação é possível, ou seja,
                        ' uma propriedade pode ser criada na importação debaixo de um novo produtor no estabelecimento 999, 
                        ' portanto, na troca de estabelecimento do Produtor também trocar na Propriedade
                        If cbo_estabelecimento.Enabled = True And pessoa.id_grupo = 1 Then   '  Se está salvando no estabelecimento '999' e é um Produtor Rural
                            Dim estabelecimento As New Estabelecimento(pessoa.id_estabelecimento)
                            If estabelecimento.cd_estabelecimento <> "999" Then  'Se está trocando de estabelecimento
                                pessoa.updatePessoaPropriedadeNovoEstabelecimento()
                            Else
                                pessoa.updatePessoa()
                            End If
                        Else
                            pessoa.updatePessoa()
                        End If
                        ' 28/02/2012 - Projeto Themis - Importação de Fornecedores - f

                        If cbo_estabelecimento.Enabled = True And pessoa.id_grupo <> 4 Then
                            If (pessoa.id_grupo <> 3) Then
                                pessoa.insertPessoaIntegracaoAPP()
                            Else
                                If pessoa.st_transportador_central = "S" Then
                                    pessoa.insertPessoaIntegracaoAPP()
                                End If
                            End If
                        Else
                            If pessoa.id_grupo = 3 AndAlso pessoa.st_transportador_central <> ViewState.Item("st_transportador_central_cadastro").ToString Then
                                pessoa.insertPessoaIntegracaoAPP()
                            End If
                        End If

                    End If
                    ' 16/08/2008 - Gera Propriedade e Unidade Produção default para Cooperativas - f

                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 4
                    usuariolog.id_nr_processo = ViewState.Item("id_pessoa")
                    usuariolog.nm_nr_processo = pessoa.cd_pessoa

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango


                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_pessoa") = pessoa.insertPessoa()
                    messageControl.Alert("Registro inserido com sucesso.")

                End If

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_pessoa.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_pessoa.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_propriedades_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_propriedades.Click
        Response.Redirect("lst_pessoa_propriedade.aspx?id_pessoa=" & ViewState.Item("id_pessoa") & "&id_estabelecimento=" & cbo_estabelecimento.SelectedValue)
    End Sub

    'Protected Sub cv_contrato_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_contrato.ServerValidate
    '    Try
    '        Dim contrato As New Contrato()
    '        Dim dscontrato As DataSet
    '        Dim lidcontrato As Int32 = 0
    '        Dim lmsg As String

    '        If Not (Me.hf_id_contrato.Value.Trim.Equals(String.Empty)) Then
    '            contrato.id_contrato = Convert.ToInt32(Me.hf_id_contrato.Value)
    '        End If

    '        contrato.cd_contrato = Me.txt_cd_contrato.Text.Trim
    '        dscontrato = contrato.getContratoByFilters

    '        args.IsValid = True

    '        If dscontrato.Tables(0).Rows.Count > 0 Then
    '            lidcontrato = dscontrato.Tables(0).Rows(0).Item("id_contrato").ToString
    '            If dscontrato.Tables(0).Rows(0).Item("id_situacao").ToString.Equals("2") Then
    '                args.IsValid = False
    '                lmsg = "Contrato desativado."
    '            Else
    '                If (Me.hf_id_contrato.Value.Trim.Equals(String.Empty)) Then
    '                    hf_id_contrato.Value = Convert.ToInt32(dscontrato.Tables(0).Rows(0).Item("id_contrato").ToString)
    '                    lbl_nm_contrato.Text = dscontrato.Tables(0).Rows(0).Item("nm_contrato").ToString
    '                End If

    '            End If
    '        Else
    '            args.IsValid = False
    '            lmsg = "Contrato não cadastrado."
    '        End If

    '        If args.IsValid = False Then
    '            hf_id_contrato.Value = String.Empty
    '            messageControl.Alert(lmsg)
    '        Else
    '            hf_id_contrato.Value = lidcontrato
    '        End If

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub btn_lupa_contrato_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_contrato.Click
    '    If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
    '        'A´pós retornar da modal, carrega os campos
    '        carregarCamposContrato()
    '    End If

    'End Sub
    Private Sub carregarCamposContrato()

        Try


            If Not (customPage.getFilterValue("lupa_contrato", "nm_contrato").Equals(String.Empty)) Then
                Me.lbl_nm_contrato.Text = customPage.getFilterValue("lupa_contrato", "nm_contrato").ToString
            End If

            If Not (customPage.getFilterValue("lupa_contrato", "cd_contrato").Equals(String.Empty)) Then
                Me.txt_cd_contrato.Text = customPage.getFilterValue("lupa_contrato", "cd_contrato").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_contrato")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_contrato_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_contrato.TextChanged
        lbl_nm_contrato.Text = String.Empty
        hf_id_contrato.Value = String.Empty

        Try
            If Not txt_cd_contrato.Text.Equals(String.Empty) Then
                Dim contrato As New Contrato
                contrato.cd_contrato = Me.txt_cd_contrato.Text.Trim
                contrato.id_estabelecimento = cbo_estabelecimento.SelectedValue
                contrato.id_situacao = 1
                Dim dscontrato As DataSet = contrato.getContratoByFilters
                'se encontrou contrato ativo
                If dscontrato.Tables(0).Rows.Count > 0 Then
                    lbl_nm_contrato.Enabled = True
                    lbl_nm_contrato.Text = dscontrato.Tables(0).Rows(0).Item("nm_contrato")
                    hf_id_contrato.Value = dscontrato.Tables(0).Rows(0).Item("id_contrato")

                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_modelo_contrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_modelo_contrato.Click

        Response.Redirect("frm_pessoa_contrato.aspx?id_pessoa=" & ViewState.Item("id_pessoa") & "&id_estabelecimento=" & cbo_estabelecimento.SelectedValue)

    End Sub

    Protected Sub cv_celular_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_celular.ServerValidate
        Dim lmsg As String = Nothing
        Try
            args.IsValid = True
            If (Me.txt_celular_ddd.Text.Equals(String.Empty) And Not Me.txt_celular.Text.Equals(String.Empty)) Then
                lmsg = "O campo DDD do celular deve ser informado!"
                args.IsValid = False
            End If
            If (Not Me.txt_celular_ddd.Text.Equals(String.Empty) And Me.txt_celular.Text.Equals(String.Empty)) Then
                lmsg = "O campo celular deve ser informado!."
                args.IsValid = False
            End If
            If (Not args.IsValid) Then
                args.IsValid = False
                Me.messageControl.Alert(lmsg)
            End If
        Catch ex As System.Exception
            Me.messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
