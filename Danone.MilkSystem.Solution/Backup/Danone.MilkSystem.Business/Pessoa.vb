Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Pessoa

    Private _id_pessoa As Int32
    Private _id_grupo As Int32
    Private _nm_grupo As String
    Private _ds_senha As String 'fran extranet 03/2016
    Private _id_nacionalidade As Int32
    Private _nm_nacionalidade As String
    Private _id_grau_instrucao As Int32
    Private _nm_grau_instrucao As String
    Private _nr_endereco As Int32
    Private _id_cidade As Int32
    Private _id_estado As Int32
    Private _nm_cidade As String
    Private _nm_estado As String
    Private _cd_uf As String
    Private _id_tipo_conta As Int32
    Private _id_banco As Int32
    Private _id_pessoa_situacao As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _id_estabelecimento As Int32
    Private _nr_dependentes As Int32
    Private _nr_contrato As Int32 'Fran 14/12/2009 i rls22
    Private _id_cluster As Int32 'fran fase 3
    Private _id_contrato As Int32 'fran 07/2017
    Private _nr_adicional_volume As Int32 'fran 07/2017 '24 para 24hrs e 48 para 48hrs
    Private _dt_nascimento As String
    Private _dt_nascimento_start As String
    Private _dt_nascimento_end As String
    Private _dt_inicio As String
    Private _dt_inicio_start As String
    Private _dt_inicio_end As String
    Private _dt_desligamento As String
    Private _dt_desligamento_start As String
    Private _dt_desligamento_end As String
    Private _dt_reativacao As String
    Private _dt_reativacao_start As String
    Private _dt_reativacao_end As String
    Private _dt_modificacao As String
    Private _nr_valor_disponivel As Decimal
    Private _nr_pedagio_eixo_cooperativa As Decimal
    Private _nm_pessoa As String
    Private _nm_abreviado As String 'Fran 27/08/2009 i rls19
    Private _cd_pessoa As String
    Private _cd_sif As String
    Private _cd_cpf As String
    Private _cd_cnpj As String
    Private _cd_rg As String
    Private _ds_email As String
    Private _ds_email2 As String 'Fran 14/12/2009 i rls22
    Private _cd_agencia As String
    Private _cd_conta As String
    Private _dt_expiracao_dqse As String
    Private _dt_expiracao_dqse_start As String
    Private _dt_expiracao_dqse_end As String
    Private _cd_cep As String
    Private _cd_caixa_postal As String
    Private _ds_telefone_1 As String
    Private _ds_telefone_2 As String
    Private _ds_telefone_3 As String
    Private _ds_contato As String
    Private _cd_orgao_emissor As String
    Private _cd_inscricao_estadual As String
    Private _cd_inscricao_municipal As String
    Private _ds_endereco As String
    Private _ds_complemento As String
    Private _ds_bairro As String
    Private _st_categoria As String
    Private _st_empresa_nacional As String
    Private _st_sexo As String
    Private _st_emite_nota_fiscal As String
    Private _nr_distancia As Decimal 'Fran 19/11/2009 i rls22
    Private _st_acordo_aquisicao_insumos As String 'Fran chamado 905 rls 24.10
    Private _dt_adesao_acordo_insumos As String 'Fran chamado 905 rls 24.10
    Private _cd_codigo_SAP As String    ' 02/2012 Projeto Themis
    Private _id_pessoa_contrato As Int32 'Fran dango 2018
    Private _cd_contrato As String 'Fran dango 2018
    Private _nm_contrato As String 'Fran dango 2018
    Private _st_funrural As String 'Fran funrural 2019 D DANONE e P PRODUTOR indica quem recolhe o FUNRURAL, se DANONE paga 1.2 FUNRURAL + 0.3 SENAR/RAT; SE PRODUTOR danone desconta apenas SENAR/RAT 0.3
    Private _st_transportador_central As String
    Private _st_fornecedor_CIF As String
    Private _nr_fornecedor_parcelas_central As Int32
    Private _ds_celular As String
    Private _st_excecao_prazo_pagto As String
    Public Property id_pessoa() As Int32
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
        End Set
    End Property
    Public Property id_pessoa_contrato() As Int32
        Get
            Return _id_pessoa_contrato
        End Get
        Set(ByVal value As Int32)
            _id_pessoa_contrato = value
        End Set
    End Property
    Public Property id_grupo() As Int32
        Get
            Return _id_grupo
        End Get
        Set(ByVal value As Int32)
            _id_grupo = value
        End Set
    End Property

    Public Property nm_grupo() As String
        Get
            Return _nm_grupo
        End Get
        Set(ByVal value As String)
            _nm_grupo = value
        End Set
    End Property

    Public Property nr_adicional_volume() As Int32
        Get
            Return _nr_adicional_volume
        End Get
        Set(ByVal value As Int32)
            _nr_adicional_volume = value
        End Set
    End Property
    Public Property id_nacionalidade() As Int32
        Get
            Return _id_nacionalidade
        End Get
        Set(ByVal value As Int32)
            _id_nacionalidade = value
        End Set
    End Property

    Public Property nm_nacionalidade() As String
        Get
            Return _nm_nacionalidade
        End Get
        Set(ByVal value As String)
            _nm_nacionalidade = value
        End Set
    End Property


    Public Property id_grau_instrucao() As Int32
        Get
            Return _id_grau_instrucao
        End Get
        Set(ByVal value As Int32)
            _id_grau_instrucao = value
        End Set
    End Property

    Public Property nm_grau_instrucao() As String
        Get
            Return _nm_grau_instrucao
        End Get
        Set(ByVal value As String)
            _nm_grau_instrucao = value
        End Set
    End Property


    Public Property nr_endereco() As Int32
        Get
            Return _nr_endereco
        End Get
        Set(ByVal value As Int32)
            _nr_endereco = value
        End Set
    End Property

    Public Property id_estado() As Int32
        Get
            Return _id_estado
        End Get
        Set(ByVal value As Int32)
            _id_estado = value
        End Set
    End Property

    Public Property nm_estado() As String
        Get
            Return _nm_estado
        End Get
        Set(ByVal value As String)
            _nm_estado = value
        End Set
    End Property


    Public Property cd_uf() As String
        Get
            Return _cd_uf
        End Get
        Set(ByVal value As String)
            _cd_uf = value
        End Set
    End Property
    Public Property ds_senha() As String
        Get
            Return _ds_senha
        End Get
        Set(ByVal value As String)
            _ds_senha = value
        End Set
    End Property

    Public Property id_cidade() As Int32
        Get
            Return _id_cidade
        End Get
        Set(ByVal value As Int32)
            _id_cidade = value
        End Set
    End Property

    Public Property nm_cidade() As String
        Get
            Return _nm_cidade
        End Get
        Set(ByVal value As String)
            _nm_cidade = value
        End Set
    End Property

    Public Property id_tipo_conta() As Int32
        Get
            Return _id_tipo_conta
        End Get
        Set(ByVal value As Int32)
            _id_tipo_conta = value
        End Set
    End Property

    Public Property id_banco() As Int32
        Get
            Return _id_banco
        End Get
        Set(ByVal value As Int32)
            _id_banco = value
        End Set
    End Property

    Public Property id_pessoa_situacao() As Int32
        Get
            Return _id_pessoa_situacao
        End Get
        Set(ByVal value As Int32)
            _id_pessoa_situacao = value
        End Set
    End Property

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property

    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
        End Set
    End Property

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property id_cluster() As Int32
        Get
            Return _id_cluster
        End Get
        Set(ByVal value As Int32)
            _id_cluster = value
        End Set
    End Property
    Public Property id_contrato() As Int32
        Get
            Return _id_contrato
        End Get
        Set(ByVal value As Int32)
            _id_contrato = value
        End Set
    End Property
    Public Property nr_dependentes() As Int32
        Get
            Return _nr_dependentes
        End Get
        Set(ByVal value As Int32)
            _nr_dependentes = value
        End Set
    End Property
    Public Property nr_contrato() As Int32
        Get
            Return _nr_contrato
        End Get
        Set(ByVal value As Int32)
            _nr_contrato = value
        End Set
    End Property
    Public Property dt_nascimento() As String
        Get
            Return _dt_nascimento
        End Get
        Set(ByVal value As String)
            _dt_nascimento = value
        End Set
    End Property

    Public Property dt_inicio() As String
        Get
            Return _dt_inicio
        End Get
        Set(ByVal value As String)
            _dt_inicio = value
        End Set
    End Property

    Public Property dt_inicio_start() As String
        Get
            Return _dt_inicio_start
        End Get
        Set(ByVal value As String)
            _dt_inicio_start = value
        End Set
    End Property

    Public Property dt_inicio_end() As String
        Get
            Return _dt_inicio_end
        End Get
        Set(ByVal value As String)
            _dt_inicio_end = value
        End Set
    End Property


    Public Property dt_desligamento() As String
        Get
            Return _dt_desligamento
        End Get
        Set(ByVal value As String)
            _dt_desligamento = value
        End Set
    End Property


    Public Property dt_desligamento_start() As String
        Get
            Return _dt_desligamento_start
        End Get
        Set(ByVal value As String)
            _dt_desligamento_start = value
        End Set
    End Property

    Public Property dt_desligamento_end() As String
        Get
            Return _dt_desligamento_end
        End Get
        Set(ByVal value As String)
            _dt_desligamento_end = value
        End Set
    End Property



    Public Property dt_reativacao() As String
        Get
            Return _dt_reativacao
        End Get
        Set(ByVal value As String)
            _dt_reativacao = value
        End Set
    End Property

    Public Property dt_reativacao_start() As String
        Get
            Return _dt_reativacao_start
        End Get
        Set(ByVal value As String)
            _dt_reativacao_start = value
        End Set
    End Property


    Public Property dt_reativacao_end() As String
        Get
            Return _dt_reativacao_end
        End Get
        Set(ByVal value As String)
            _dt_reativacao_end = value
        End Set
    End Property


    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
        End Set
    End Property

    Public Property nr_valor_disponivel() As Decimal
        Get
            Return _nr_valor_disponivel
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_disponivel = value
        End Set
    End Property

    Public Property nr_distancia() As Decimal
        Get
            Return _nr_distancia
        End Get
        Set(ByVal value As Decimal)
            _nr_distancia = value
        End Set
    End Property
    Public Property nr_pedagio_eixo_cooperativa() As Decimal
        Get
            Return _nr_pedagio_eixo_cooperativa
        End Get
        Set(ByVal value As Decimal)
            _nr_pedagio_eixo_cooperativa = value
        End Set
    End Property
    Public Property nm_pessoa() As String
        Get
            Return _nm_pessoa
        End Get
        Set(ByVal value As String)
            _nm_pessoa = value
        End Set
    End Property
    Public Property nm_abreviado() As String
        Get
            Return _nm_abreviado
        End Get
        Set(ByVal value As String)
            _nm_abreviado = value
        End Set
    End Property

    Public Property cd_pessoa() As String
        Get
            Return _cd_pessoa
        End Get
        Set(ByVal value As String)
            _cd_pessoa = value
        End Set
    End Property

    Public Property cd_sif() As String
        Get
            Return _cd_sif
        End Get
        Set(ByVal value As String)
            _cd_sif = value
        End Set
    End Property

    Public Property cd_cpf() As String
        Get
            Return _cd_cpf
        End Get
        Set(ByVal value As String)
            _cd_cpf = value
        End Set
    End Property

    Public Property cd_cnpj() As String
        Get
            Return _cd_cnpj
        End Get
        Set(ByVal value As String)
            _cd_cnpj = value
        End Set
    End Property

    Public Property cd_rg() As String
        Get
            Return _cd_rg
        End Get
        Set(ByVal value As String)
            _cd_rg = value
        End Set
    End Property

    Public Property ds_email() As String
        Get
            Return _ds_email
        End Get
        Set(ByVal value As String)
            _ds_email = value
        End Set
    End Property

    Public Property cd_agencia() As String
        Get
            Return _cd_agencia
        End Get
        Set(ByVal value As String)
            _cd_agencia = value
        End Set
    End Property

    Public Property cd_conta() As String
        Get
            Return _cd_conta
        End Get
        Set(ByVal value As String)
            _cd_conta = value
        End Set
    End Property

    Public Property dt_expiracao_dqse() As String
        Get
            Return _dt_expiracao_dqse
        End Get
        Set(ByVal value As String)
            _dt_expiracao_dqse = value
        End Set
    End Property

    Public Property dt_expiracao_dqse_start() As String
        Get
            Return _dt_expiracao_dqse_start
        End Get
        Set(ByVal value As String)
            _dt_expiracao_dqse_start = value
        End Set
    End Property

    Public Property dt_expiracao_dqse_end() As String
        Get
            Return _dt_expiracao_dqse_end
        End Get
        Set(ByVal value As String)
            _dt_expiracao_dqse_end = value
        End Set
    End Property


    Public Property cd_cep() As String
        Get
            Return _cd_cep
        End Get
        Set(ByVal value As String)
            _cd_cep = value
        End Set
    End Property

    Public Property cd_caixa_postal() As String
        Get
            Return _cd_caixa_postal
        End Get
        Set(ByVal value As String)
            _cd_caixa_postal = value
        End Set
    End Property

    Public Property ds_telefone_1() As String
        Get
            Return _ds_telefone_1
        End Get
        Set(ByVal value As String)
            _ds_telefone_1 = value
        End Set
    End Property

    Public Property ds_telefone_2() As String
        Get
            Return _ds_telefone_2
        End Get
        Set(ByVal value As String)
            _ds_telefone_2 = value
        End Set
    End Property

    Public Property ds_telefone_3() As String
        Get
            Return _ds_telefone_3
        End Get
        Set(ByVal value As String)
            _ds_telefone_3 = value
        End Set
    End Property

    Public Property ds_contato() As String
        Get
            Return _ds_contato
        End Get
        Set(ByVal value As String)
            _ds_contato = value
        End Set
    End Property

    Public Property cd_orgao_emissor() As String
        Get
            Return _cd_orgao_emissor
        End Get
        Set(ByVal value As String)
            _cd_orgao_emissor = value
        End Set
    End Property

    Public Property cd_inscricao_estadual() As String
        Get
            Return _cd_inscricao_estadual
        End Get
        Set(ByVal value As String)
            _cd_inscricao_estadual = value
        End Set
    End Property

    Public Property cd_inscricao_municipal() As String
        Get
            Return _cd_inscricao_municipal
        End Get
        Set(ByVal value As String)
            _cd_inscricao_municipal = value
        End Set
    End Property

    Public Property ds_endereco() As String
        Get
            Return _ds_endereco
        End Get
        Set(ByVal value As String)
            _ds_endereco = value
        End Set
    End Property

    Public Property ds_complemento() As String
        Get
            Return _ds_complemento
        End Get
        Set(ByVal value As String)
            _ds_complemento = value
        End Set
    End Property

    Public Property ds_bairro() As String
        Get
            Return _ds_bairro
        End Get
        Set(ByVal value As String)
            _ds_bairro = value
        End Set
    End Property

    Public Property st_categoria() As String
        Get
            Return _st_categoria
        End Get
        Set(ByVal value As String)
            _st_categoria = value
        End Set
    End Property

    Public Property st_empresa_nacional() As String
        Get
            Return _st_empresa_nacional
        End Get
        Set(ByVal value As String)
            _st_empresa_nacional = value
        End Set
    End Property

    Public Property st_sexo() As String
        Get
            Return _st_sexo
        End Get
        Set(ByVal value As String)
            _st_sexo = value
        End Set
    End Property

    Public Property st_emite_nota_fiscal() As String
        Get
            Return _st_emite_nota_fiscal
        End Get
        Set(ByVal value As String)
            _st_emite_nota_fiscal = value
        End Set
    End Property
    Public Property ds_email2() As String
        Get
            Return _ds_email2
        End Get
        Set(ByVal value As String)
            _ds_email2 = value
        End Set
    End Property
    'fran chamado 905 rls 24.10 I
    Public Property st_acordo_aquisicao_insumos() As String
        Get
            Return _st_acordo_aquisicao_insumos
        End Get
        Set(ByVal value As String)
            _st_acordo_aquisicao_insumos = value
        End Set
    End Property
    Public Property dt_adesao_acordo_insumos() As String
        Get
            Return _dt_adesao_acordo_insumos
        End Get
        Set(ByVal value As String)
            _dt_adesao_acordo_insumos = value
        End Set
    End Property
    'fran chamado 905 rls 24.10 F

    Public Property cd_contrato() As String
        Get
            Return _cd_contrato
        End Get
        Set(ByVal value As String)
            _cd_contrato = value
        End Set
    End Property
    Public Property nm_contrato() As String
        Get
            Return _nm_contrato
        End Get
        Set(ByVal value As String)
            _nm_contrato = value
        End Set
    End Property
    Public Property st_funrural() As String
        Get
            Return _st_funrural
        End Get
        Set(ByVal value As String)
            _st_funrural = value
        End Set
    End Property
    ' 02/02/2012 - Projeto Themis - i
    Public Property cd_codigo_SAP() As String
        Get
            Return _cd_codigo_SAP
        End Get
        Set(ByVal value As String)
            _cd_codigo_SAP = value
        End Set
    End Property
    ' 02/02/2012 - Projeto Themis - i

    Public Property st_transportador_central() As String
        Get
            Return _st_transportador_central
        End Get
        Set(ByVal value As String)
            _st_transportador_central = value
        End Set
    End Property
    Public Property st_fornecedor_CIF() As String
        Get
            Return _st_fornecedor_CIF
        End Get
        Set(ByVal value As String)
            _st_fornecedor_CIF = value
        End Set
    End Property
    Public Property ds_celular() As String
        Get
            Return _ds_celular
        End Get
        Set(ByVal value As String)
            _ds_celular = value
        End Set
    End Property
    Public Property st_excecao_prazo_pagto() As String
        Get
            Return _st_excecao_prazo_pagto
        End Get
        Set(ByVal value As String)
            _st_excecao_prazo_pagto = value
        End Set
    End Property
    Public Property nr_fornecedor_parcelas_central() As Int32
        Get
            Return _nr_fornecedor_parcelas_central
        End Get
        Set(ByVal value As Int32)
            _nr_fornecedor_parcelas_central = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me._id_pessoa = id
        loadPessoa()

    End Sub



    Public Sub New()

    End Sub


    Public Function getPessoaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPessoas", parameters, "ms_pessoa")
            Return dataSet

        End Using

    End Function

    Public Function getProdutorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getProdutores", parameters, "ms_pessoa")
            Return dataSet

        End Using

    End Function
    Public Function getPropriedadesProdutoresEGrupo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPropriedadesProdutoresEGrupo", parameters, "ms_propriedades")
            Return dataSet

        End Using

    End Function


    Public Function getCooperativasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCooperativas", parameters, "ms_pessoa")
            Return dataSet

        End Using

    End Function
    Public Function getCooperativasByCodigo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCooperativaByCodigo", parameters, "ms_pessoa")
            Return dataSet

        End Using

    End Function
    Public Function validarProdutor() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getProdutorbyCodigo", parameters, "ms_pessoa")
            If dataSet.Tables(0).Rows.Count > 0 Then
                Return Convert.ToInt32(dataSet.Tables(0).Rows(0).Item(0).ToString)
            Else
                Return 0
            End If

        End Using


    End Function
    Public Function validarCooperativa() As Int32


        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCooperativabyCodigo", parameters, "ms_pessoa")
            If dataSet.Tables(0).Rows.Count > 0 Then
                Return Convert.ToInt32(dataSet.Tables(0).Rows(0).Item(0).ToString)
            Else
                Return 0
            End If

        End Using


    End Function
    Public Function getFornecedorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFornecedores", parameters, "ms_pessoa")
            Return dataSet

        End Using

    End Function
    Public Function validarFornecedor() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFornecedorbyCodigo", parameters, "ms_pessoa")
            If dataSet.Tables(0).Rows.Count > 0 Then
                Return Convert.ToInt32(dataSet.Tables(0).Rows(0).Item(0).ToString)
            Else
                Return 0
            End If

        End Using


    End Function
    Public Function getTransportadorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransportadores", parameters, "ms_pessoa")
            Return dataSet

        End Using

    End Function
    Public Function validarTransportador() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransportadorbyCodigo", parameters, "ms_pessoa")
            If dataSet.Tables(0).Rows.Count > 0 Then
                Return Convert.ToInt32(dataSet.Tables(0).Rows(0).Item(0).ToString)
            Else
                Return 0
            End If

        End Using


    End Function

    Public Sub loadPessoa()

        Dim dataSet As DataSet = getPessoaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertPessoa() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPessoas", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertPessoaIntegracaoAPP() As Int32
        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAPIIntegracaoPessoa", parameters, ExecuteType.Insert), Int32)
        End Using
    End Function

    Public Sub updatePessoaSenha() 'fran extranet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePessoaSenha", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePessoa()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePessoas", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updatePessoaPropriedade()

        Dim transacao As New DataAccess
        Dim propriedade As New Propriedade

        transacao.StartTransaction()
        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_updatePessoas", parameters, ExecuteType.Update)

            'Dados default da Propriedade
            propriedade.nm_propriedade = Me.nm_pessoa
            propriedade.id_estabelecimento = Me.id_estabelecimento
            propriedade.id_pessoa = Me.id_pessoa
            propriedade.cd_inscricao_estadual = Me.cd_inscricao_estadual
            propriedade.dt_inicio = Me.dt_inicio
            propriedade.ds_endereco = Me.ds_endereco
            propriedade.nr_endereco = Me.nr_endereco
            propriedade.ds_complemento = Me.ds_complemento
            propriedade.ds_bairro = Me.ds_bairro
            propriedade.id_cidade = Me.id_cidade
            propriedade.cd_cep = Me.cd_cep
            'fran dango 2018
            'propriedade.st_considera_qualidade = "N"
            propriedade.st_considera_qualidade = "S"
            propriedade.st_gold = "N"
            'fran dango f
            propriedade.st_incentivo_fiscal = "N"
            propriedade.st_transferencia_credito = "N"
            propriedade.id_situacao = 1
            propriedade.id_item = 1
            propriedade.id_modificador = Me.id_modificador
            propriedade.id_criacao = Me.id_modificador
            parameters = ParametersEngine.getParametersFromObject(propriedade)
            propriedade.unidadeproducao.id_propriedade = CType(transacao.ExecuteScalar("ms_insertPropriedade", parameters, ExecuteType.Insert), Int32)

            'Dados defualt da Unidade de Produção
            propriedade.unidadeproducao.nm_unid_producao = Me.nm_pessoa
            propriedade.unidadeproducao.id_modificador = Me.id_modificador
            propriedade.unidadeproducao.id_situacao = "1"
            parameters = ParametersEngine.getParametersFromObject(propriedade.unidadeproducao)
            transacao.Execute("ms_insertUnidadesProducao", parameters, ExecuteType.Insert)

            transacao.Commit()

        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try

    End Sub

    Public Sub deletePessoa()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deletePessoas", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function getCNPJPessoa() As String

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCNPJPessoa", parameters, ExecuteType.Select), String)

        End Using


    End Function

    'fran 08/01/2011 i
    Public Function getTransportadorCooperativaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransportadoresCooperativas", parameters, "ms_pessoa")
            Return dataSet

        End Using

    End Function

    Public Function validarTransportadorCooperativa() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransportadorCooperativabyCodigo", parameters, "ms_pessoa")
            If dataSet.Tables(0).Rows.Count > 0 Then
                Return Convert.ToInt32(dataSet.Tables(0).Rows(0).Item(0).ToString)
            Else
                Return 0
            End If

        End Using


    End Function
    ' 28/02/2012 - Projeto Themis - Importação de Fornecedores - i
    Public Sub updatePessoaPropriedadeNovoEstabelecimento()

        Dim transacao As New DataAccess
        Dim propriedade As New Propriedade

        transacao.StartTransaction()
        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_updatePessoas", parameters, ExecuteType.Update)

            'Altera Estabelecimento de todas as Propriedades deste Produtor
            propriedade.id_estabelecimento = Me.id_estabelecimento
            propriedade.id_pessoa = Me.id_pessoa
            parameters = ParametersEngine.getParametersFromObject(propriedade)
            transacao.Execute("ms_updatePropriedadeNovoEstabelecimento", parameters, ExecuteType.Update)

            transacao.Commit()

        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try

    End Sub
    ' 28/02/2012 - Projeto Themis - Importação de Fornecedores - f
    'fran 15/05/2012 chamado 1548
    Public Function validarProdutorAgropecuaria() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getProdutorbyCodigo", parameters, "ms_pessoa")
            Return dataSet

        End Using


    End Function
    Public Function getTransportadorCentralByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransportadoresCentral", parameters, "ms_pessoa")
            Return dataSet

        End Using

    End Function
End Class
