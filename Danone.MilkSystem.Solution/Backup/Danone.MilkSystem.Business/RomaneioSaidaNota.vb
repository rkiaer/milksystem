Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class RomaneioSaidaNota
    Private _id_romaneio_saida_nota As Int32
    Private _id_romaneio_saida As Int32
    Private _id_cooperativa As Int32
    Private _id_transportador As Int32
    Private _id_romaneio_saida_tipo_nota As Int32
    Private _id_frete_nf As Int32
    Private _cd_cst As String
    Private _cd_cfop As String
    Private _nr_valor_frete_acordado As Decimal
    Private _id_natureza_operacao As Int32
    Private _ds_natureza_operacao_outros As String
    Private _nr_peso_liquido_nota As Decimal
    Private _nr_valor_unitario As Decimal
    Private _nr_valor_nota_fiscal As Decimal
    Private _ds_nota_fiscal_origem As String
    Private _ds_contrato As String
    Private _nr_especie_material As Decimal
    Private _nr_volume_material As Decimal
    Private _ds_obs_deposito As String
    Private _ds_obs_batch As String
    Private _ds_obs_lacres As String
    Private _ds_observacao As String
    Private _nm_solicitante As String
    Private _ds_depto As String
    Private _ds_centro_custo As String
    Private _nr_nota_fiscal As String
    Private _nr_serie_nota_fiscal As String
    Private _dt_emissao_nota As String
    Private _dt_emissao_cte As String
    Private _ds_chave_nf As String
    Private _nr_valor_icms As Decimal
    Private _nr_nota_fiscal_cte As String
    Private _nr_serie_cte As String
    Private _ds_chave_cte As String
    Private _nr_valor_nota_fiscal_cte As Decimal
    Private _nr_valor_icms_cte As Decimal
    Private _id_usuario_solicitante_nf As Int32
    Private _dt_solicitacao_nf As String
    Private _id_situacao_romaneio_saida_nota As Int32
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_usuario_anexo_nf As Int32
    Private _dt_usuario_anexo_nf As String
    Private _id_usuario_anexo_cte As Int32
    Private _dt_usuario_anexo_cte As String
    Private _st_selecao As String
    Private _nr_quantidade As Decimal
    Private _nr_peso_bruto As Decimal
    Private _id_situacao_romaneio_saida As Int32
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _id_estabelecimento As Int32
    Private _id_item As Int32
    Private _ds_placa As String
    Private _nr_valor_nf_anexo As Decimal
    Private _nr_qtde_nf_anexo As Decimal
    Private _nr_modelo_frete As Int32


    Public Property id_romaneio_saida_nota() As Int32
        Get
            Return _id_romaneio_saida_nota
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_saida_nota = value
        End Set
    End Property
    Public Property id_romaneio_saida() As Int32
        Get
            Return _id_romaneio_saida
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_saida = value
        End Set
    End Property
    Public Property id_romaneio_saida_tipo_nota() As Integer
        Get
            Return _id_romaneio_saida_tipo_nota
        End Get
        Set(ByVal value As Integer)
            _id_romaneio_saida_tipo_nota = value
        End Set
    End Property
    Public Property id_cooperativa() As Integer
        Get
            Return _id_cooperativa
        End Get
        Set(ByVal value As Integer)
            _id_cooperativa = value
        End Set
    End Property
    Public Property id_transportador() As Integer
        Get
            Return _id_transportador
        End Get
        Set(ByVal value As Integer)
            _id_transportador = value
        End Set
    End Property
    Public Property cd_cst() As String
        Get
            Return _cd_cst
        End Get
        Set(ByVal value As String)
            _cd_cst = value
        End Set
    End Property
    Public Property cd_cfop() As String
        Get
            Return _cd_cfop
        End Get
        Set(ByVal value As String)
            _cd_cfop = value
        End Set
    End Property

    Public Property id_frete_nf() As Int32
        Get
            Return _id_frete_nf
        End Get
        Set(ByVal value As Int32)
            _id_frete_nf = value
        End Set
    End Property

    Public Property nr_valor_frete_acordado() As Decimal
        Get
            Return _nr_valor_frete_acordado
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_frete_acordado = value
        End Set
    End Property
    Public Property nr_valor_nota_fiscal() As Decimal
        Get
            Return _nr_valor_nota_fiscal
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nota_fiscal = value
        End Set
    End Property
    Public Property nr_especie_material() As Decimal
        Get
            Return _nr_especie_material
        End Get
        Set(ByVal value As Decimal)
            _nr_especie_material = value
        End Set
    End Property
    Public Property nr_volume_material() As Decimal
        Get
            Return _nr_volume_material
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_material = value
        End Set
    End Property
    Public Property nr_peso_liquido_nota() As Decimal
        Get
            Return _nr_peso_liquido_nota
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_liquido_nota = value
        End Set
    End Property
    Public Property nr_valor_unitario() As Decimal
        Get
            Return _nr_valor_unitario
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_unitario = value
        End Set
    End Property
    Public Property nr_valor_icms() As Decimal
        Get
            Return _nr_valor_icms
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_icms = value
        End Set
    End Property
    Public Property nr_valor_nota_fiscal_cte() As Decimal
        Get
            Return _nr_valor_nota_fiscal_cte
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nota_fiscal_cte = value
        End Set
    End Property
    Public Property nr_valor_icms_cte() As Decimal
        Get
            Return _nr_valor_icms_cte
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_icms_cte = value
        End Set
    End Property
    Public Property nr_quantidade() As Decimal
        Get
            Return _nr_quantidade
        End Get
        Set(ByVal value As Decimal)
            _nr_quantidade = value
        End Set
    End Property
    Public Property nr_peso_bruto() As Decimal
        Get
            Return _nr_peso_bruto
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_bruto = value
        End Set
    End Property

    Public Property id_natureza_operacao() As Int32
        Get
            Return _id_natureza_operacao
        End Get
        Set(ByVal value As Int32)
            _id_natureza_operacao = value
        End Set
    End Property

    Public Property ds_natureza_operacao_outros() As String
        Get
            Return _ds_natureza_operacao_outros
        End Get
        Set(ByVal value As String)
            _ds_natureza_operacao_outros = value
        End Set
    End Property
    Public Property ds_nota_fiscal_origem() As String
        Get
            Return _ds_nota_fiscal_origem
        End Get
        Set(ByVal value As String)
            _ds_nota_fiscal_origem = value
        End Set
    End Property
    Public Property ds_contrato() As String
        Get
            Return _ds_contrato
        End Get
        Set(ByVal value As String)
            _ds_contrato = value
        End Set
    End Property
    Public Property ds_obs_deposito() As String
        Get
            Return _ds_obs_deposito
        End Get
        Set(ByVal value As String)
            _ds_obs_deposito = value
        End Set
    End Property
    Public Property ds_obs_batch() As String
        Get
            Return _ds_obs_batch
        End Get
        Set(ByVal value As String)
            _ds_obs_batch = value
        End Set
    End Property
    Public Property ds_obs_lacres() As String
        Get
            Return _ds_obs_lacres
        End Get
        Set(ByVal value As String)
            _ds_obs_lacres = value
        End Set
    End Property
    Public Property ds_observacao() As String
        Get
            Return _ds_observacao
        End Get
        Set(ByVal value As String)
            _ds_observacao = value
        End Set
    End Property
    Public Property nm_solicitante() As String
        Get
            Return _nm_solicitante
        End Get
        Set(ByVal value As String)
            _nm_solicitante = value
        End Set
    End Property
    Public Property ds_depto() As String
        Get
            Return _ds_depto
        End Get
        Set(ByVal value As String)
            _ds_depto = value
        End Set
    End Property
    Public Property ds_centro_custo() As String
        Get
            Return _ds_centro_custo
        End Get
        Set(ByVal value As String)
            _ds_centro_custo = value
        End Set
    End Property
    Public Property nr_nota_fiscal() As String
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As String)
            _nr_nota_fiscal = value
        End Set
    End Property
    Public Property nr_serie_nota_fiscal() As String
        Get
            Return _nr_serie_nota_fiscal
        End Get
        Set(ByVal value As String)
            _nr_serie_nota_fiscal = value
        End Set
    End Property
    Public Property dt_emissao_nota() As String
        Get
            Return _dt_emissao_nota
        End Get
        Set(ByVal value As String)
            _dt_emissao_nota = value
        End Set
    End Property
    Public Property dt_emissao_cte() As String
        Get
            Return _dt_emissao_cte
        End Get
        Set(ByVal value As String)
            _dt_emissao_cte = value
        End Set
    End Property

    Public Property ds_chave_nf() As String
        Get
            Return _ds_chave_nf
        End Get
        Set(ByVal value As String)
            _ds_chave_nf = value
        End Set
    End Property
    Public Property nr_nota_fiscal_cte() As String
        Get
            Return _nr_nota_fiscal_cte
        End Get
        Set(ByVal value As String)
            _nr_nota_fiscal_cte = value
        End Set
    End Property
    Public Property nr_serie_cte() As String
        Get
            Return _nr_serie_cte
        End Get
        Set(ByVal value As String)
            _nr_serie_cte = value
        End Set
    End Property
    Public Property ds_chave_cte() As String
        Get
            Return _ds_chave_cte
        End Get
        Set(ByVal value As String)
            _ds_chave_cte = value
        End Set
    End Property
    Public Property dt_solicitacao_nf() As String
        Get
            Return _dt_solicitacao_nf
        End Get
        Set(ByVal value As String)
            _dt_solicitacao_nf = value
        End Set
    End Property
    Public Property id_usuario_solicitante_nf() As Int32
        Get
            Return _id_usuario_solicitante_nf
        End Get
        Set(ByVal value As Int32)
            _id_usuario_solicitante_nf = value
        End Set
    End Property
    Public Property id_situacao_romaneio_saida_nota() As Int32
        Get
            Return _id_situacao_romaneio_saida_nota
        End Get
        Set(ByVal value As Int32)
            _id_situacao_romaneio_saida_nota = value
        End Set
    End Property
    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
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
    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
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
    Public Property id_usuario_anexo_nf() As Int32
        Get
            Return _id_usuario_anexo_nf
        End Get
        Set(ByVal value As Int32)
            _id_usuario_anexo_nf = value
        End Set
    End Property
    Public Property dt_usuario_anexo_nf() As String
        Get
            Return _dt_usuario_anexo_nf
        End Get
        Set(ByVal value As String)
            _dt_usuario_anexo_nf = value
        End Set
    End Property
    Public Property id_usuario_anexo_cte() As Int32
        Get
            Return _id_usuario_anexo_cte
        End Get
        Set(ByVal value As Int32)
            _id_usuario_anexo_cte = value
        End Set
    End Property
    Public Property dt_usuario_anexo_cte() As String
        Get
            Return _dt_usuario_anexo_cte
        End Get
        Set(ByVal value As String)
            _dt_usuario_anexo_cte = value
        End Set
    End Property
    Public Property st_selecao() As String
        Get
            Return _st_selecao
        End Get
        Set(ByVal value As String)
            _st_selecao = value
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
    Public Property dt_fim() As String
        Get
            Return _dt_fim
        End Get
        Set(ByVal value As String)
            _dt_fim = value
        End Set
    End Property
    Public Property id_situacao_romaneio_saida() As Int32
        Get
            Return _id_situacao_romaneio_saida
        End Get
        Set(ByVal value As Int32)
            _id_situacao_romaneio_saida = value
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

    Public Property ds_placa() As String
        Get
            Return _ds_placa
        End Get
        Set(ByVal value As String)
            _ds_placa = value
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
    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
        End Set
    End Property
    Public Property nr_valor_nf_anexo() As Decimal
        Get
            Return _nr_valor_nf_anexo
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nf_anexo = value
        End Set
    End Property
    Public Property nr_qtde_nf_anexo() As Decimal
        Get
            Return _nr_qtde_nf_anexo
        End Get
        Set(ByVal value As Decimal)
            _nr_qtde_nf_anexo = value
        End Set
    End Property
    Public Property nr_modelo_frete() As Int32
        Get
            Return _nr_modelo_frete
        End Get
        Set(ByVal value As Int32)
            _nr_modelo_frete = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)
        Me.id_romaneio_saida_nota = id
        loadRomaneioSaidaNota()
    End Sub

    Public Sub New()

    End Sub
    Public Function getRomaneioSaidaNota() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getRomaneioSaidaNota", parameters, "ms_romaneio_saida_nota")
            Return dataSet

        End Using

    End Function
    Private Sub loadRomaneioSaidaNota()

        Dim dataSet As DataSet = getRomaneioSaidaNota()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertRomaneioSaidaNota() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioSaidaNota", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub updateRomaneioSaidaNota()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaNota", parameters, ExecuteType.Update)

        End Using
    End Sub
    Public Sub updateRomaneioSaidaNotaAnexoCte()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaNotaAnexoCTE", parameters, ExecuteType.Update)

        End Using
    End Sub
    Public Sub updateRomaneioSaidaNotaAnexoNF()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaNotaAnexoNF", parameters, ExecuteType.Update)

        End Using
    End Sub
    Public Sub updateRomaneioSaidaNotaEAnexos()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaNotaEAnexos", parameters, ExecuteType.Update)

        End Using
    End Sub
    Public Sub updateRomaneioSaidaNotaSelecao()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaNotaSelecao", parameters, ExecuteType.Update)

        End Using
    End Sub
    Public Sub solicitarNotaFiscal()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros 
            'o romaneio de saida deve ficar com situacao 7 (aguardando NF) e 
            'o romaneio saida nota deve ficar com situacao 2 NF solicitada
            Me.id_situacao_romaneio_saida = 7
            Me.id_situacao_romaneio_saida_nota = 2
            Me.id_situacao = 2 'situacao é para o log de situacoes do romaneio saida nota

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_updateRomaneioSaidaSituacao", parameters, ExecuteType.Update)
            transacao.Execute("ms_updateRomaneioSaidaNotaSituacao", parameters, ExecuteType.Update)
            'insere o log de situacao do romaneio nota
            transacao.Execute("ms_insertRomaneioSaidaSituacaoLog", parameters, ExecuteType.Insert)

            Me.id_romaneio_saida_nota = 0 'seta sem romaneio saida nota para atulializar log do romaneio saida
            Me.id_situacao = 7 'log de situacao para romaneio saida
            parameters = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_insertRomaneioSaidaSituacaoLog", parameters, ExecuteType.Insert)

            'Comita
            transacao.Commit()

        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub registrarNotaFiscalEmAndamento()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros 
            'o romaneio saida nota deve ficar com situacao 3 NF Em Andamento
            Me.id_situacao_romaneio_saida_nota = 3
            Me.id_situacao = 3 'situacao é para o log de situacoes do romaneio saida nota

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_updateRomaneioSaidaNotaSituacao", parameters, ExecuteType.Update)
            'insere o log de situacao do romaneio nota
            transacao.Execute("ms_insertRomaneioSaidaSituacaoLog", parameters, ExecuteType.Insert)

            'Comita
            transacao.Commit()

        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub registrarNotaFiscalLiberadaNF()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros 
            'o romaneio de saida deve ficar com situacao 7 (aguardando NF) e 
            'o romaneio saida nota deve ficar com situacao 4 NF anexada
            Me.id_situacao_romaneio_saida_nota = 4
            Me.id_situacao = 4 'situacao é para o log de situacoes do romaneio saida nota

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_updateRomaneioSaidaNotaLiberarNF", parameters, ExecuteType.Update)
            'insere o log de situacao do romaneio nota
            transacao.Execute("ms_insertRomaneioSaidaSituacaoLog", parameters, ExecuteType.Insert)


            'Comita
            transacao.Commit()

        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub registrarNotaFiscalLiberadaCTE()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros 
            'o romaneio de saida deve ficar com situacao 8 (NF ANEXADA) e 
            'o romaneio saida nota deve ficar com situacao 5 NF e CTE Anexados
            Me.id_situacao_romaneio_saida = 8
            Me.id_situacao_romaneio_saida_nota = 5
            Me.id_situacao = 5 'situacao é para o log de situacoes do romaneio saida nota

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_updateRomaneioSaidaSituacao", parameters, ExecuteType.Update)
            transacao.Execute("ms_updateRomaneioSaidaNotaLiberarCTE", parameters, ExecuteType.Update)
            'insere o log de situacao do romaneio nota
            transacao.Execute("ms_insertRomaneioSaidaSituacaoLog", parameters, ExecuteType.Insert)

            Me.id_romaneio_saida_nota = 0 'seta sem romaneio saida nota para atulializar log do romaneio saida
            Me.id_situacao = 8 'log de situacao para romaneio saida
            parameters = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_insertRomaneioSaidaSituacaoLog", parameters, ExecuteType.Insert)

            'Comita
            transacao.Commit()

        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Sub

End Class
