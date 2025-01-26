Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.Math

<Serializable()> Public Class PoupancaAdesao
    Private _id_poupanca_adesao As Int32
    Private _id_propriedade As Int32
    Private _id_pessoa As Int32
    Private _id_estabelecimento As Int32
    Private _id_poupanca_parametro As Int32
    Private _dt_adesao As String
    Private _dt_referencia_ini As String
    Private _dt_referencia_fim As String
    Private _nr_tempo_adesao As Int32
    Private _st_bonus_poupanca_central As String
    Private _st_bonus_poupanca_lancamento As String
    Private _dt_bonus_aplicacao As String
    Private _id_usuario_bonus_aplicacao As Int32
    Private _dt_ref_ini_calc As String 'data de referencia inicial para realizacao do calculo poupanca
    Private _dt_ult_ref_calc As String 'ultima referencia de calculo de produtor realizada
    Private _dt_referencia_ini_poupanca_parametro As String
    Private _id_situacao_poupanca As Int32
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    'Poupanca Adesao Seleção
    Private _id_poupanca_adesao_execucao As Int32
    Private _id_poupanca_adesao_selecao As Int32
    Private _id_estabelecimento_filtro As Int32
    Private _id_poupanca_parametro_filtro As Int32
    Private _id_pessoa_filtro As Int32
    Private _id_propriedade_filtro As Int32
    Private _st_selecao As String
    Private _id_poupanca_selecao_execucao As Int32

    'Poupanca Adesao Aplicacao do Bonus
    Private _nr_valor_bonus_poupanca As Decimal
    Private _nr_valor_spend As Decimal
    Private _nr_valor_bonus_extra As Decimal
    Private _nr_valor_bonus_transferencia As Decimal
    Private _nr_valor_compras_central As Decimal
    Private _nr_valor_volume_leite As Decimal
    Private _st_participa_fechamento As String
    Private _id_cluster As Int32

    'Poupanca Adesao Grupo Relacionamento
    Private _id_propriedade_titular As Int32
    Private _st_participa_poupanca As String
    Private _st_relacionamento As String
    Private _st_relacionamento2 As String

    'Poupanca Adesao Concessao do Bonus
    Private _id_motivo_bonus_concessao As Int32

    Private _dt_adesao_usuario As String
    Private _id_usuario_adesao As Int32
    Private _st_adesao_site As String


    Private _tablename As String

    Public Property id_poupanca_adesao() As Int32
        Get
            Return _id_poupanca_adesao
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_adesao = value
        End Set
    End Property
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
        End Set
    End Property
    Public Property id_pessoa() As Int32
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
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
    Public Property id_poupanca_parametro() As Int32
        Get
            Return _id_poupanca_parametro
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_parametro = value
        End Set
    End Property
    Public Property nr_tempo_adesao() As Int32
        Get
            Return _nr_tempo_adesao
        End Get
        Set(ByVal value As Int32)
            _nr_tempo_adesao = value
        End Set
    End Property
    Public Property dt_adesao() As String
        Get
            Return _dt_adesao
        End Get
        Set(ByVal value As String)
            _dt_adesao = value
        End Set
    End Property
    Public Property id_usuario_adesao() As Int32
        Get
            Return _id_usuario_adesao
        End Get
        Set(ByVal value As Int32)
            _id_usuario_adesao = value
        End Set
    End Property
    Public Property dt_adesao_usuario() As String
        Get
            Return _dt_adesao_usuario
        End Get
        Set(ByVal value As String)
            _dt_adesao_usuario = value
        End Set
    End Property
    Public Property st_adesao_site() As String
        Get
            Return _st_adesao_site
        End Get
        Set(ByVal value As String)
            _st_adesao_site = value
        End Set
    End Property
    Public Property dt_referencia_ini_poupanca_parametro() As String
        Get
            Return _dt_referencia_ini_poupanca_parametro
        End Get
        Set(ByVal value As String)
            _dt_referencia_ini_poupanca_parametro = value
        End Set
    End Property
    Public Property dt_referencia_ini() As String
        Get
            Return _dt_referencia_ini
        End Get
        Set(ByVal value As String)
            _dt_referencia_ini = value
        End Set
    End Property
    Public Property dt_referencia_fim() As String
        Get
            Return _dt_referencia_fim
        End Get
        Set(ByVal value As String)
            _dt_referencia_fim = value
        End Set
    End Property
    Public Property st_bonus_poupanca_central() As String
        Get
            Return _st_bonus_poupanca_central
        End Get
        Set(ByVal value As String)
            _st_bonus_poupanca_central = value
        End Set
    End Property
    Public Property st_bonus_poupanca_lancamento() As String
        Get
            Return _st_bonus_poupanca_lancamento
        End Get
        Set(ByVal value As String)
            _st_bonus_poupanca_lancamento = value
        End Set
    End Property
    Public Property dt_ref_ini_calc() As String
        Get
            Return _dt_ref_ini_calc
        End Get
        Set(ByVal value As String)
            _dt_ref_ini_calc = value
        End Set
    End Property
    Public Property dt_ult_ref_calc() As String
        Get
            Return _dt_ult_ref_calc
        End Get
        Set(ByVal value As String)
            _dt_ult_ref_calc = value
        End Set
    End Property
    Public Property id_usuario_bonus_aplicacao() As Int32
        Get
            Return _id_usuario_bonus_aplicacao
        End Get
        Set(ByVal value As Int32)
            _id_usuario_bonus_aplicacao = value
        End Set
    End Property
    Public Property dt_bonus_aplicacao() As String
        Get
            Return _dt_bonus_aplicacao
        End Get
        Set(ByVal value As String)
            _dt_bonus_aplicacao = value
        End Set
    End Property
    Public Property id_situacao_poupanca() As Int32
        Get
            Return _id_situacao_poupanca
        End Get
        Set(ByVal value As Int32)
            _id_situacao_poupanca = value
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
    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
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
    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
        End Set
    End Property
    Public Property st_participa_fechamento() As String
        Get
            Return _st_participa_fechamento
        End Get
        Set(ByVal value As String)
            _st_participa_fechamento = value
        End Set
    End Property
    Public Property st_relacionamento() As String
        Get
            Return _st_relacionamento
        End Get
        Set(ByVal value As String)
            _st_relacionamento = value
        End Set
    End Property
    Public Property st_relacionamento2() As String
        Get
            Return _st_relacionamento2
        End Get
        Set(ByVal value As String)
            _st_relacionamento2 = value
        End Set
    End Property
    Public Property nr_valor_spend() As Decimal
        Get
            Return _nr_valor_spend
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_spend = value
        End Set
    End Property
    Public Property nr_valor_bonus_poupanca() As Decimal
        Get
            Return _nr_valor_bonus_poupanca
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_bonus_poupanca = value
        End Set
    End Property
    Public Property nr_valor_bonus_transferencia() As Decimal
        Get
            Return _nr_valor_bonus_transferencia
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_bonus_transferencia = value
        End Set
    End Property
    Public Property nr_valor_bonus_extra() As Decimal
        Get
            Return _nr_valor_bonus_extra
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_bonus_extra = value
        End Set
    End Property
    Public Property nr_valor_compras_central() As Decimal
        Get
            Return _nr_valor_compras_central
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_compras_central = value
        End Set
    End Property
    Public Property nr_valor_volume_leite() As Decimal
        Get
            Return _nr_valor_volume_leite
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_volume_leite = value
        End Set
    End Property
    Public Property id_poupanca_adesao_execucao() As Int32
        Get
            Return _id_poupanca_adesao_execucao
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_adesao_execucao = value
        End Set
    End Property
    Public Property id_poupanca_adesao_selecao() As Int32
        Get
            Return _id_poupanca_adesao_selecao
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_adesao_selecao = value
        End Set
    End Property
    Public Property id_propriedade_filtro() As Int32
        Get
            Return _id_propriedade_filtro
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_filtro = value
        End Set
    End Property
    Public Property id_estabelecimento_filtro() As Int32
        Get
            Return _id_estabelecimento_filtro
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento_filtro = value
        End Set
    End Property
    Public Property id_pessoa_filtro() As Int32
        Get
            Return _id_pessoa_filtro
        End Get
        Set(ByVal value As Int32)
            _id_pessoa_filtro = value
        End Set
    End Property
    Public Property id_poupanca_parametro_filtro() As Int32
        Get
            Return _id_poupanca_parametro_filtro
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_parametro_filtro = value
        End Set
    End Property
    Public Property id_propriedade_titular() As Int32
        Get
            Return _id_propriedade_titular
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_titular = value
        End Set
    End Property
    Public Property id_motivo_bonus_concessao() As Int32
        Get
            Return _id_motivo_bonus_concessao
        End Get
        Set(ByVal value As Int32)
            _id_motivo_bonus_concessao = value
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
    Public Property tablename() As String
        Get
            Return _tablename
        End Get
        Set(ByVal value As String)
            _tablename = value
        End Set
    End Property
    Public Property id_poupanca_selecao_execucao() As Int32
        Get
            Return _id_poupanca_selecao_execucao
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_selecao_execucao = value
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
    Public Property st_participa_poupanca() As String
        Get
            Return _st_participa_poupanca
        End Get
        Set(ByVal value As String)
            _st_participa_poupanca = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)
        Me.id_poupanca_adesao = id
        loadPoupancaAdesao()
    End Sub

    Public Sub New()

    End Sub
    Public Function getPoupancaAdesaoComOrderBy() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaAdesaoComOrderBy", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function

    Public Function getPoupancaAdesaoSemBonusExtra() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaAdesaoSemBonusExtra", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaAdesao() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaAdesao", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaAdesaoSelecao() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaAdesaoSelecao", parameters, "ms_poupanca_adesao_selecao")
            Return dataSet

        End Using

    End Function

    Public Function getPoupancaAdesaoConsistirSelecao() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaAdesaoConsSelecao", parameters, "ms_poupanca_adesao_selecao")
            Return dataSet

        End Using

    End Function
    Private Sub loadPoupancaAdesao()

        Dim dataSet As DataSet = getPoupancaAdesao()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updatePoupancaAdesao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaAdesao", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updatePoupancaAdesaoSelecaoTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaAdesaoSelecaoTodos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePoupancaAdesaoValores()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaAdesaoValores", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePoupancaAdesaoSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaAdesaoSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Function getExecucaoPoupancaAdesao() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getPoupancaAdesaoSelecaoIdentity", parameters, ExecuteType.Select), Int32)
        End Using
    End Function

    Public Function getPoupancaBonusbyAdesao() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaBonusbyAdesao", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaPropriedadeBonus() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaPropriedadeBonus", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaBonusbyAdesaoSelecao() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaBonusbyAdesaoSelecao", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaBonusbyAdesaoSelecaoGrupos() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaBonusbyAdesaoSelecaoGrupos", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function

    Public Function getPoupancaGrupoRelacionamentoAdesaobyTitular() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaGrupoRelacionamentoAdesaobyTitular", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaGrupoRelacionamentoTitular() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaGrupoRelacionamentoTitular", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaGrupoRelacionamentoTitularbyPessoa() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaGrupoRelacionamentoTitularbyPessoa", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function
    Public Function incluirAdesaoSelecao() As Integer

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        incluirAdesaoSelecao = 0
        Try
            'Pega os parametros para processo
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Insere Poupanca Adesao Seleção todas as propriedades de acordo com filtro
            transacao.Execute("ms_insertPoupancaAdesaoSelecao", parameters, ExecuteType.Insert)


            'Comita
            transacao.Commit()
            incluirAdesaoSelecao = True
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            incluirAdesaoSelecao = False
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Sub incluirPoupancaAdesaoMaisSolidosGrupo()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para processo
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Insere Poupanca Adesao todos os produtores do grupo de relacionament se nao existirem na adesao
            transacao.Execute("ms_insertPoupancaAdesaoMaisSolidosGrupo", parameters, ExecuteType.Insert)

            'atualiza aceite do termo para todos os produtores da prop titular
            transacao.Execute("ms_updatePoupancaAdesao", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub

    Public Function incluirPoupancaAdesaoMaisSolidos() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPoupancaAdesaoMaisSolidos", parameters, ExecuteType.Insert), Int32)

        End Using

    End Function
    Public Function incluirPoupancaAdesao() As Integer

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        incluirPoupancaAdesao = 0
        Try
            'Pega os parametros para processo
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Insere Poupanca Adesao todos os itens selecionados (st_selecao = 1) e que nao aderiram a poupanca (st_adesao_ok=0) para a execução do filtro
            transacao.Execute("ms_insertPoupancaAdesao", parameters, ExecuteType.Insert)

            'atualiza execucao com as novas propriedades aderidas
            transacao.Execute("ms_updatePoupancaAdesaoSelecaoAtualizacao", parameters, ExecuteType.Update)

            'atualiza nr_tempo_adesao na ms_poupancaadesao para as propriedades, pega o tempo de adesao da referencia anterior  e adiciona + 1
            transacao.Execute("ms_updatePoupancaAdesaoTempo", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            incluirPoupancaAdesao = True
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            incluirPoupancaAdesao = False
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Sub updatePoupancaAdesaoValoresBonus()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para processo
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza VOLUME DE LEITE DAS CONTAS 0010 e Bonus de poupanca conra 254
            transacao.Execute("ms_updatePoupancaAdesaoBonusVolume", parameters, ExecuteType.Update)

            'Atualiza bonus transferencia
            transacao.Execute("ms_updatePoupancaAdesaoBonusTransferencia", parameters, ExecuteType.Update)

            'Atualizar COMPRAS CENTRAL
            transacao.Execute("ms_updatePoupancaAdesaoComprasCentral", parameters, ExecuteType.Update)

            'Atualiza VOLUME DE LEITE dos transferidos
            transacao.Execute("ms_updatePoupancaAdesaoVolumeTransferencia", parameters, ExecuteType.Update)

            'Atualiza Compras Central transferencia
            transacao.Execute("ms_updatePoupancaAdesaoComprasCentralTransferencia", parameters, ExecuteType.Update)

            'Atualiza VOLUME DE LEITE DAS CONTAS 0010 e Bonus de poupanca conra 254 para grupo de relacionamento
            transacao.Execute("ms_updatePoupancaAdesaoBonusVolumeGrupo", parameters, ExecuteType.Update)

            'Atualiza bonus transferencia de grupo de relacionamento- Para grupo de relacionamento nao precisa pegar transferencia pois buca todoas as propriedades do grupo da ficha
            'transacao.Execute("ms_updatePoupancaAdesaoBonusTransferenciaGrupo", parameters, ExecuteType.Update)

            'Atualizar COMPRAS CENTRAL de grupo de relaionamento
            transacao.Execute("ms_updatePoupancaAdesaoComprasCentralGrupo", parameters, ExecuteType.Update)

            'Atualizar Bonus Extra e Spend
            transacao.Execute("ms_updatePoupancaAdesaoBonusExtraSpend", parameters, ExecuteType.Update)
 
            'Comita
            transacao.Commit()
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub updatePoupancaAdesaoValoresBonusGrupoRelacionamento()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para processo
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim ficha As New FichaFinanceira
            Dim pedido As New Pedido
            Dim bonus As New Poupanca
            Dim dsficha As New DataSet
            Dim dspedido As New DataSet
            Dim dsbonus As New DataSet
            Dim dspoupanca As New DataSet

            Dim dsrow As DataRow
            Dim nr_volume_periodo As Decimal
            Dim nr_total_compras_central As Decimal
            Dim nr_valor_bonus As Decimal
            Dim nr_valor_bonus_transf As Decimal
            Dim nrspendperiodo As Decimal
            Dim nrpercbonusextra As Decimal
            Dim lid_propriedade As Int64

            parameters = ParametersEngine.getParametersFromObject(Me)
            transacao.Fill(dspoupanca, "ms_getPoupancaAdesaoParticipaFechamentoGrupo", parameters, "ms_poupanca_adesao")

            For Each dsrow In dspoupanca.Tables(0).Rows

                lid_propriedade = dsrow.Item("id_propriedade")
                nrspendperiodo = dsrow.Item("nr_spend_periodo")
                nrpercbonusextra = dsrow.Item("nr_bonus_extra_spend")
                Me.nr_valor_volume_leite = 0
                Me.nr_valor_compras_central = 0
                Me.nr_valor_bonus_poupanca = 0
                Me.nr_valor_bonus_transferencia = 0
                Me.nr_valor_bonus_extra = 0
                Me.nr_valor_spend = 0


                'BUSCA VOLUME DE LEITE DAS CONTAS 0010
                ficha.dt_referencia_ficha_start = DateTime.Parse(Me.dt_referencia_ini).ToString("dd/MM/yyyy")
                ficha.dt_referencia_ficha_end = DateTime.Parse(Me.dt_referencia_fim).ToString("dd/MM/yyyy")
                ficha.id_propriedade = lid_propriedade
                nr_volume_periodo = ficha.getFichaFinanceiraVolumeLeitebyGrupo
                Me.nr_valor_volume_leite = nr_volume_periodo

                'BUSCA COMPRAS CENTRAL
                pedido.id_propriedade = lid_propriedade
                pedido.dt_inicio = DateTime.Parse(Me.dt_referencia_ini).ToString("dd/MM/yyyy")
                pedido.dt_fim = DateTime.Parse(Me.dt_referencia_fim).ToString("dd/MM/yyyy")
                nr_total_compras_central = pedido.getCentralPedidoTotalComprasbyGrupo
                Me.nr_valor_compras_central = nr_total_compras_central

                'SOMATORIO DAS CONTAS DE BONUS POUPANCA
                bonus.id_propriedade = lid_propriedade
                bonus.dt_referencia_ini = DateTime.Parse(Me.dt_referencia_ini).ToString("dd/MM/yyyy") 'Referencia que se deve iniciar calculo bonus poupanca (muda caso deixe de entregar leite)
                bonus.dt_referencia_fim = DateTime.Parse(Me.dt_referencia_fim).ToString("dd/MM/yyyy")
                nr_valor_bonus = bonus.getPoupancaValorBonusbyGrupo
                Me.nr_valor_bonus_poupanca = nr_valor_bonus

                'SOMATORIO DAS CONTAS DE BONUS POUPANCA TRANSFERIDOS
                bonus.id_propriedade = lid_propriedade
                bonus.dt_referencia_ini = DateTime.Parse(Me.dt_referencia_ini).ToString("dd/MM/yyyy") 'Referencia que se deve iniciar calculo bonus poupanca (muda caso deixe de entregar leite)
                bonus.dt_referencia_fim = DateTime.Parse(Me.dt_referencia_fim).ToString("dd/MM/yyyy")
                nr_valor_bonus_transf = bonus.getPoupancaValorBonusTransferenciabyGrupo
                Me.nr_valor_bonus_transferencia = nr_valor_bonus_transf

                nr_valor_bonus = nr_valor_bonus + nr_valor_bonus_transf

                'SPEND
                If nr_total_compras_central <= 0 Or nr_volume_periodo <= 0 Then
                    Me.nr_valor_bonus_extra = 0
                    Me.nr_valor_spend = 0
                Else
                    'Se o valor do spend do periodo (gastos da central divbidido pelo volume total) for maior ou igual ao parametro especificado, o bonus da poupanca ganha valor extra para ser aplicado na central.
                    Me.nr_valor_spend = Round(CDec(nr_total_compras_central / nr_volume_periodo), 4)
                    'Se o spend for menor que o parametro definido, nao acrescenta nada ao bonus
                    If Me.nr_valor_spend >= CDec(nrspendperiodo) Then
                        Me.nr_valor_bonus_extra = ((nr_valor_bonus * nrpercbonusextra) / 100)
                    Else
                        Me.nr_valor_bonus_extra = 0

                    End If
                End If
                'atualiza valores para propriedade
                Me.updatePoupancaAdesaoValores()

            Next


            'Comita
            transacao.Commit()
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub updatePoupancaAplicacaoBonusSelecaoTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaAplicacaoBonusSelecaoTodos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePoupancaAplicacaoBonusSelecaoTodosGrupo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaAplicacaoBonusSelecaoTodosGrupo", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePoupancaAdesaoBonusExtraConcessao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaAdesaoBonusExtraConcessao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePoupancaAplicacaoBonusSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaAplicacaoBonusSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePoupancaAdesaoAplicacaoBonus()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaAdesaoAplicacaoBonus", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updatePoupancaLiberarParticiparFechamentoSelecionadas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaLiberarParticiparFechamentoSelecionadas", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getPoupancaLiberarConsGrupoSemParametro() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaLiberarConsGrupoSemParametro", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaLiberarConsPropInativas() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaLiberarConsPropInativas", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaLiberarConsFechamentoNulo() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaLiberarConsFechamentoNulo", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function

    Public Function getPoupancaLiberarConsGrupoRespInativo() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaLiberarConsGrupoRespInativo", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaLiberarbyAdesaoSelecao() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaLiberarbyAdesaoSelecao", parameters, "ms_poupanca_adesao")
            Return dataSet

        End Using

    End Function
    Public Sub updatePoupancaLiberarSelecaoTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaLiberarSelecaoTodos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePoupancaLiberarSelecaoTodasFechamentoNulo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaLiberarSelecaoTodasFechamentoNulo", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePoupancaLiberarSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaLiberarSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePoupancaLiberar()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaLiberar", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
