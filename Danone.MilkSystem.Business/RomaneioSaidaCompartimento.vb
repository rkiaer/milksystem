Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class RomaneioSaidaCompartimento

    Private _id_romaneio_saida_compartimento As Int32
    Private _id_romaneio_saida As Int32
    Private _id_compartimento As Int32
    Private _nr_compartimento As Int32
    Private _nm_compartimento As String
    Private _id_silo As Int32
    Private _id_st_analise As Int32
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String
    Private _nr_total_litros As Decimal
    Private _nr_total_litros_sem_reajuste As Decimal
    Private _cd_amostra As String
    Private _st_volume_descartado As String
    Private _nm_motivo_descarte As String
    Private _ds_motivo_aprovado_sob_concessao As String
    Private _nm_st_analise As String
    Private _st_reanalise As String
    Private _nm_analista As String
    Private _dt_inicio_analise As String
    Private _ds_compartimento As String
    Private _ds_placa As String
    Private _st_responsavel_ciq As String 'fran 03/22022
    Private _st_primeiro_responsavel_ciq As String 'fran 03/22022
    Private _dt_modificacao_ciq As String 'fran 03/22022
    Private _id_modificador_ciq As Int32 'fran 03/22022
    Private _id_motivo_responsavel_ciq As Int32 'fran 03/22022
    Private _ds_motivo_responsavel_ciq As String 'fran 03/22022
    Private _st_mudanca_responsavel_ciq As String 'fran 03/22022
    Private _st_emitente As String 'fran 03/22022
    Private _st_atualizar_produtor As String 'fran 03/22022
    Public Property id_romaneio_saida_compartimento() As Int32
        Get
            Return _id_romaneio_saida_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_saida_compartimento = value
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
    Public Property id_compartimento() As Int32
        Get
            Return _id_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_compartimento = value
        End Set
    End Property

    Public Property nr_compartimento() As Int32
        Get
            Return _nr_compartimento
        End Get
        Set(ByVal value As Int32)
            _nr_compartimento = value
        End Set
    End Property

    Public Property id_silo() As Int32
        Get
            Return _id_silo
        End Get
        Set(ByVal value As Int32)
            _id_silo = value
        End Set
    End Property

    Public Property id_st_analise() As Int32
        Get
            Return _id_st_analise
        End Get
        Set(ByVal value As Int32)
            _id_st_analise = value
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

    Public Property cd_amostra() As String
        Get
            Return _cd_amostra
        End Get
        Set(ByVal value As String)
            _cd_amostra = value
        End Set
    End Property

    Public Property st_volume_descartado() As String
        Get
            Return _st_volume_descartado
        End Get
        Set(ByVal value As String)
            _st_volume_descartado = value
        End Set
    End Property
    Public Property st_reanalise() As String
        Get
            Return _st_reanalise
        End Get
        Set(ByVal value As String)
            _st_reanalise = value
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
    Public Property dt_inicio_analise() As String
        Get
            Return _dt_inicio_analise
        End Get
        Set(ByVal value As String)
            _dt_inicio_analise = value
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

    Public Property nm_motivo_descarte() As String
        Get
            Return _nm_motivo_descarte
        End Get
        Set(ByVal value As String)
            _nm_motivo_descarte = value
        End Set
    End Property
    Public Property ds_motivo_aprovado_sob_concessao() As String
        Get
            Return _ds_motivo_aprovado_sob_concessao
        End Get
        Set(ByVal value As String)
            _ds_motivo_aprovado_sob_concessao = value
        End Set
    End Property
    Public Property nm_compartimento() As String
        Get
            Return _nm_compartimento
        End Get
        Set(ByVal value As String)
            _nm_compartimento = value
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
    Public Property nm_st_analise() As String
        Get
            Return _nm_st_analise
        End Get
        Set(ByVal value As String)
            _nm_st_analise = value
        End Set
    End Property
    Public Property id_modificador_ciq() As Int32
        Get
            Return _id_modificador_ciq
        End Get
        Set(ByVal value As Int32)
            _id_modificador_ciq = value
        End Set
    End Property
    Public Property dt_modificacao_ciq() As String
        Get
            Return _dt_modificacao_ciq
        End Get
        Set(ByVal value As String)
            _dt_modificacao_ciq = value
        End Set
    End Property
    Public Property id_motivo_responsavel_ciq() As Int32
        Get
            Return _id_motivo_responsavel_ciq
        End Get
        Set(ByVal value As Int32)
            _id_motivo_responsavel_ciq = value
        End Set
    End Property
    Public Property ds_motivo_responsavel_ciq() As String
        Get
            Return _ds_motivo_responsavel_ciq
        End Get
        Set(ByVal value As String)
            _ds_motivo_responsavel_ciq = value
        End Set
    End Property
    Public Property st_responsavel_ciq() As String
        Get
            Return _st_responsavel_ciq
        End Get
        Set(ByVal value As String)
            _st_responsavel_ciq = value
        End Set
    End Property
    Public Property st_primeiro_responsavel_ciq() As String
        Get
            Return _st_primeiro_responsavel_ciq
        End Get
        Set(ByVal value As String)
            _st_primeiro_responsavel_ciq = value
        End Set
    End Property
    Public Property st_mudanca_responsavel_ciq() As String
        Get
            Return _st_mudanca_responsavel_ciq
        End Get
        Set(ByVal value As String)
            _st_mudanca_responsavel_ciq = value
        End Set
    End Property
    Public Property st_emitente() As String
        Get
            Return _st_emitente
        End Get
        Set(ByVal value As String)
            _st_emitente = value
        End Set
    End Property
    Public Property st_atualizar_produtor() As String
        Get
            Return _st_atualizar_produtor
        End Get
        Set(ByVal value As String)
            _st_atualizar_produtor = value
        End Set
    End Property

    Public Sub New()

    End Sub


    Public Sub New(ByVal id As Int32)

        Me._id_romaneio_saida_compartimento = id
        loadRomaneioSaidaCompartimento()

    End Sub

    Public Function getRomaneioSaidaCompartimentoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaCompartimentos", parameters, "ms_romaneio_compartimento")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSaidaCompartimentosAprovados() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioSaidaCompartimentoSituacaoAprovadoouNull", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Function getRomaneioSaidaAnaliseCompartimentoAprovadoNuloObrigatoriaSemValor() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioSaidaAnaliseCompartimentoAprovadoNuloObrigatoriaSemValor", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Function getRomaneioSaidaCompartimentosSemRegistroAnaliseRejeitada() As Int32
        Using data As New DataAccess
            'Busca as analises rejeitadas do romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioSaidaCompartimentoSemRegistroAnaliseRejeitada", parameters, ExecuteType.Select), Int32)

        End Using

    End Function


    Private Sub loadRomaneioSaidaCompartimento()

        Dim dataSet As DataSet = getRomaneioSaidaCompartimentoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Sub updateRomaneioSaidaCompartimentosAnalista()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaCompartimentoAnalista", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateRomaneioSaidaCompartimento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioSaidaCompartimento", parameters, ExecuteType.Update)

        End Using

    End Sub
    'Public Sub updateRomaneioCompartimentoReajuste()

    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        data.Execute("ms_updateRomaneioCompartimentoReajuste", parameters, ExecuteType.Update)

    '    End Using

    'End Sub
    'Public Sub updateRomaneioSaidaCompartimentoReajuste()

    '    Using data As New DataAccess

    '        'Fran 30/09/2008 i - Transação
    '        Dim transacao As New DataAccess
    '        'Inicia Transação
    '        transacao.StartTransaction(IsolationLevel.RepeatableRead)
    '        Try
    '            'Pega os parametros para atualização romaneio
    '            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '            transacao.Execute("ms_updateRomaneioSaidaCompartimentoReajuste", parameters, ExecuteType.Update)
    '            transacao.Execute("ms_updateRomaneioSaidaSomaVolumeCompartimentosbyRomaneio", parameters, ExecuteType.Update)

    '            'Comita
    '            transacao.Commit()
    '        Catch err As Exception
    '            transacao.RollBack()
    '            Throw New Exception(err.Message)
    '        End Try

    '    End Using

    'End Sub

    Public Sub deleteRomaneioSaidaCompartimento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteRomaneioSaidaCompartimento", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function getRomaneioSaidaCompartimentoSemRegistroAnalise() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioSaidaCompartimentoSemRegistroAnalise", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    '    Public Function getRelatorioCIQ() As DataSet

    '        Using data As New DataAccess

    '            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '            Dim dataSet As New DataSet

    '            data.Fill(dataSet, "ms_getRelatorioCIQ", parameters, "ms_romaneio_compartimento")
    '            Return dataSet

    '        End Using

    '    End Function
    '    Public Function getRelatorioCIQT() As DataSet

    '        Using data As New DataAccess

    '            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '            Dim dataSet As New DataSet

    '            data.Fill(dataSet, "ms_getRelatorioCIQT", parameters, "ms_romaneio_compartimento")
    '            Return dataSet

    '        End Using

    '    End Function
    '    Public Function getRelatorioCIQ_Analises() As DataSet

    '        Using data As New DataAccess

    '            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '            Dim dataSet As New DataSet

    '            data.Fill(dataSet, "ms_getRelatorioCIQ_analises", parameters, "ms_romaneio_compartimento")
    '            Return dataSet

    '        End Using

    '    End Function
    '    'fran 09/01/2011 i chamado 1101
    '    Public Function getAjusteExcedeuVolume() As Integer

    '        Using data As New DataAccess

    '            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '            Return CType(data.ExecuteScalar("ms_getRomaneioCompAjusteExcedeuVolume", parameters, ExecuteType.Select), Integer)

    '        End Using
    '    End Function

    '    Public Function getPreRomaneioCompQtdeRejeitado() As Integer

    '        Using data As New DataAccess

    '            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '            Return CType(data.ExecuteScalar("ms_getPreRomaneioCompQtdeRejeitado", parameters, ExecuteType.Select), Integer)

    '        End Using
    '    End Function
    '    Public Function getPreRomaneioCompQtdeAprovado() As Integer

    '        Using data As New DataAccess

    '            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '            Return CType(data.ExecuteScalar("ms_getPreRomaneioCompQtdeAprovado", parameters, ExecuteType.Select), Integer)

    '        End Using
    '    End Function

    '    Public Sub AtualizarResponsavelCIQ() 'fran 04/2022

    '        Dim transacao As New DataAccess
    '        Dim dsromcomprejeitado As New DataSet

    '        'Inicia Transação
    '        transacao.StartTransaction(IsolationLevel.RepeatableRead)
    '        Try
    '            'Pega os parametros para atualizacao responsavel
    '            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '            'Atualizar romaneio compartimento com o novo responsavel pelo CIQ
    '            transacao.Execute("ms_updateRomaneioCompartimentoResponsavelCIQ", parameters, ExecuteType.Update)

    '            'se emitente é produtor verifica se deve atuaizar dados de produtor (mapa e contas parceladas)
    '            If Me.st_emitente = "P" Then

    '                If Me.st_atualizar_produtor = "S" Then

    '                    transacao.Execute("ms_updateRomaneioCompartimentoResponsavelCIQProdutor", parameters, ExecuteType.Update)

    '                End If

    '            End If

    '            'Comita
    '            transacao.Commit()

    '        Catch err As Exception
    '            transacao.RollBack()
    '            Throw New Exception(err.Message)
    '        End Try
    '    End Sub

End Class
