Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Romaneio_Comp_UProducao

    Private _id_romaneio_uproducao As Int32
    Private _id_romaneio_compartimento As Int32
    Private _id_romaneio As Int32
    Private _nm_analista As String
    Private _dt_inicio_analise As String
    Private _ds_compartimento As String
    Private _nm_st_analise_compartimento As String
    Private _ds_placa As String
    Private _ds_propriedade As String
    Private _ds_uproducao As String
    Private _nm_pessoa As String
    Private _ds_pessoa As String
    Private _nm_status_analise_uproducao As String
    Private _id_propriedade As Int32
    Private _nr_unid_producao As Int32
    Private _id_resfriador As Int32
    Private _id_motivo_nao_coleta As Int32
    Private _id_status_analise_uproducao As Int32
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _nr_ordem As Int32
    Private _dt_coleta As String
    Private _dt_criacao As String
    Private _dt_modificacao As String
    Private _nr_litros As Decimal
    Private _nr_litros_sem_reajuste As Decimal
    Private _nr_total_litros As Decimal
    Private _nr_total_litros_sem_reajuste As Decimal
    Private _nr_temperatura As Decimal
    Private _id_alizarol As Int32
    Private _st_leite_coletado As String
    Private _cd_amostra As String
    Private _id_tecnico As Int32
    Private _dt_inicio As String 'Fran 01/07/2009 i chamado 286
    Private _dt_fim As String 'Fran 01/07/2009 i chamado 286
    Private _nr_litros_pre_romaneio_transit_point As Decimal 'total de litros transferidos para transit point
    Private _nr_litros_pre_romaneio_saldo As Decimal 'total de litros para transferir

    Public Property id_romaneio_uproducao() As Int32
        Get
            Return _id_romaneio_uproducao
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_uproducao = value
        End Set
    End Property

    Public Property id_romaneio_compartimento() As Int32
        Get
            Return _id_romaneio_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_compartimento = value
        End Set
    End Property
    Public Property nm_analista() As String
        Get
            Return _nm_analista
        End Get
        Set(ByVal value As String)
            _nm_analista = value
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
    Public Property dt_inicio_analise() As String
        Get
            Return _dt_inicio_analise
        End Get
        Set(ByVal value As String)
            _dt_inicio_analise = value
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

    Public Property nr_unid_producao() As Int32
        Get
            Return _nr_unid_producao
        End Get
        Set(ByVal value As Int32)
            _nr_unid_producao = value
        End Set
    End Property

    Public Property id_resfriador() As Int32
        Get
            Return _id_resfriador
        End Get
        Set(ByVal value As Int32)
            _id_resfriador = value
        End Set
    End Property

    Public Property id_motivo_nao_coleta() As Int32
        Get
            Return _id_motivo_nao_coleta
        End Get
        Set(ByVal value As Int32)
            _id_motivo_nao_coleta = value
        End Set
    End Property

    Public Property id_status_analise_uproducao() As Int32
        Get
            Return _id_status_analise_uproducao
        End Get
        Set(ByVal value As Int32)
            _id_status_analise_uproducao = value
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

    Public Property nr_ordem() As Int32
        Get
            Return _nr_ordem
        End Get
        Set(ByVal value As Int32)
            _nr_ordem = value
        End Set
    End Property

    Public Property dt_coleta() As String
        Get
            Return _dt_coleta
        End Get
        Set(ByVal value As String)
            _dt_coleta = value
        End Set
    End Property
    Public Property nm_st_analise_compartimento() As String
        Get
            Return _nm_st_analise_compartimento
        End Get
        Set(ByVal value As String)
            _nm_st_analise_compartimento = value
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

    Public Property nr_litros() As Decimal
        Get
            Return _nr_litros
        End Get
        Set(ByVal value As Decimal)
            _nr_litros = value
        End Set
    End Property
    Public Property nr_litros_sem_reajuste() As Decimal
        Get
            Return _nr_litros_sem_reajuste
        End Get
        Set(ByVal value As Decimal)
            _nr_litros_sem_reajuste = value
        End Set
    End Property
    Public Property nr_total_litros() As Decimal
        Get
            Return _nr_total_litros
        End Get
        Set(ByVal value As Decimal)
            _nr_total_litros = value
        End Set
    End Property
    Public Property nr_total_litros_sem_reajuste() As Decimal
        Get
            Return _nr_total_litros_sem_reajuste
        End Get
        Set(ByVal value As Decimal)
            _nr_total_litros_sem_reajuste = value
        End Set
    End Property

    Public Property nr_temperatura() As Decimal
        Get
            Return _nr_temperatura
        End Get
        Set(ByVal value As Decimal)
            _nr_temperatura = value
        End Set
    End Property

    Public Property id_alizarol() As Int32
        Get
            Return _id_alizarol
        End Get
        Set(ByVal value As Int32)
            _id_alizarol = value
        End Set
    End Property

    Public Property st_leite_coletado() As String
        Get
            Return _st_leite_coletado
        End Get
        Set(ByVal value As String)
            _st_leite_coletado = value
        End Set
    End Property

    Public Property cd_amostra() As String
        Get
            Return _cd_amostra
        End Get
        Set(ByVal value As String)
            _cd_amostra = value
        End Set
    End Property
    Public Property id_romaneio() As Int32
        Get
            Return _id_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_romaneio = value
        End Set
    End Property
    Public Property ds_compartimento() As String
        Get
            Return _ds_compartimento
        End Get
        Set(ByVal value As String)
            _ds_compartimento = value
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
    Public Property ds_propriedade() As String
        Get
            Return _ds_propriedade
        End Get
        Set(ByVal value As String)
            _ds_propriedade = value
        End Set
    End Property
    Public Property ds_uproducao() As String
        Get
            Return _ds_uproducao
        End Get
        Set(ByVal value As String)
            _ds_uproducao = value
        End Set
    End Property
    Public Property ds_pessoa() As String
        Get
            Return _ds_pessoa
        End Get
        Set(ByVal value As String)
            _ds_pessoa = value
        End Set
    End Property
    'Fran 01/07/2009 i chamado 286
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
    'Fran 01/07/2009 f chamado 286
    Public Property nm_status_analise_uproducao() As String
        Get
            Return _nm_status_analise_uproducao
        End Get
        Set(ByVal value As String)
            _nm_status_analise_uproducao = value
        End Set
    End Property
    Public Property id_tecnico() As Int32
        Get
            Return _id_tecnico
        End Get
        Set(ByVal value As Int32)
            _id_tecnico = value
        End Set
    End Property
    Public Property nr_litros_pre_romaneio_saldo() As Decimal
        Get
            Return _nr_litros_pre_romaneio_saldo
        End Get
        Set(ByVal value As Decimal)
            _nr_litros_pre_romaneio_saldo = value
        End Set
    End Property
    Public Property nr_litros_pre_romaneio_transit_point() As Decimal
        Get
            Return _nr_litros_pre_romaneio_transit_point
        End Get
        Set(ByVal value As Decimal)
            _nr_litros_pre_romaneio_transit_point = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Int32)

        Me.id_romaneio_uproducao = id
        loadRomaneio_Comp_UProducao()

    End Sub
    Public Function getRomaneio_Comp_UProducaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioUProducao", parameters, "ms_romaneio_uproducao")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioUProducaoReajuste() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioUProducaoReajuste", parameters, "ms_romaneio_uproducao")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioUProducaoRejeitados() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet
            'pega a unidades de producao com status Rejeitadas
            'pega os produtors rejeitados
            data.Fill(dataSet, "ms_getRomaneioUProducaoSituacao", parameters, "ms_romaneio_uproducao")
            Return dataSet

        End Using

    End Function

    Private Sub loadRomaneio_Comp_UProducao()

        Dim dataSet As DataSet = getRomaneio_Comp_UProducaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updateRomaneio_Comp_UProducao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneio_Comp_UProducao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function registrarStatusAnaliseUProducao()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para atualização romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza status em Romaneio Uproduvcao
            transacao.Execute("ms_updateRomaneioUProducao", parameters, ExecuteType.Update)

            'Se for confome
            If Me.id_status_analise_uproducao = 1 Then 'Se status é 'Aprovado'

                Dim dataSet As New DataSet
                'Busca todos os registros do romaio unid producao com status <> 1 ou seja todos que estejam aprovados sob concessao ou rejeitados
                transacao.Fill(dataSet, "ms_getRomaneioUProducaoSituacaoRejeitados", parameters, "ms_romaneio_compartimento")

                If (dataSet.Tables(0).Rows.Count = 0) Then
                    Dim romaneio As New Romaneio
                    romaneio.id_romaneio = Me.id_romaneio
                    romaneio.id_modificador = Me.id_modificador
                    romaneio.id_st_analise_uproducao = 1 'Aprovado

                    Dim params As List(Of Parameters) = ParametersEngine.getParametersFromObject(romaneio)

                    'Atualiza status da analise unid producao do romaneio para Aprovado
                    transacao.Execute("ms_updateRomaneioStatusAnaliseUProducao", params, ExecuteType.Update)
                End If
            Else
                'Se status rejeitado ou aprovado sob concessao atualiza status romaneio para REJEITADO
                Dim romaneio As New Romaneio
                romaneio.id_romaneio = Me.id_romaneio
                romaneio.id_modificador = Me.id_modificador
                romaneio.id_st_analise_uproducao = 2 'Rejeitado

                Dim params As List(Of Parameters) = ParametersEngine.getParametersFromObject(romaneio)

                'Atualiza status da analise unid producao do romaneio para Rejeitado
                transacao.Execute("ms_updateRomaneioStatusAnaliseUProducao", params, ExecuteType.Update)
            End If


            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
            Return Me.id_romaneio
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function getRomaneioUProducaoSemRegistroAnalise() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioUProducaoSemRegistroAnalise", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Sub updateRomaneioUProducaoReajuste()

        Using data As New DataAccess


            Dim transacao As New DataAccess
            'Inicia Transação
            transacao.StartTransaction(IsolationLevel.RepeatableRead)
            Try
                'Pega os parametros para atualização romaneio
                Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

                'Atualiza status em Romaneio Uproduvcao
                transacao.Execute("ms_updateRomaneioUProducaoReajuste", parameters, ExecuteType.Update)
                transacao.Execute("ms_updateRomaneioCompartimentoReajuste", parameters, ExecuteType.Update)
                'Fran 30/09/2008 i - Atualiza somatorio da caderneta no romaneio
                transacao.Execute("ms_updateRomaneioSomaVolumeCompartimentosbyRomaneio", parameters, ExecuteType.Update)

                'Comita
                transacao.Commit()
            Catch err As Exception
                transacao.RollBack()
                Throw New Exception(err.Message)
            End Try

        End Using

    End Sub
    Public Function getRelatorioCIQP() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioCIQP", parameters, "ms_romaneio_uproducao")
            Return dataSet

        End Using

    End Function
    Public Function getRelatorioCIQP_Analises() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioCIQP_analises", parameters, "ms_romaneio_uproducao")
            Return dataSet

        End Using

    End Function
    Public Function insertRomaneioUProducaoPropriedade() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioUProducaoPropriedade", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Function getRomaneioUProducaoSomaVolumeByPropriedade() As Decimal

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioUProducaoSomaVolumeByPropriedade", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    'fran 09/01/2011 i chamado 1101
    Public Function getAjusteExcedeuVolume() As Integer

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioProdAjusteExcedeuVolume", parameters, ExecuteType.Select), Integer)

        End Using
    End Function
    Public Function getPreRomaneioProdutor() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioProdutor", parameters, "ms_romaneio_uproducao")
            Return dataSet

        End Using

    End Function
End Class
