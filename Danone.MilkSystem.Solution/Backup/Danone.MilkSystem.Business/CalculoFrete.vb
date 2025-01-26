Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class CalculoFrete

    Private _id_estabelecimento As Int32
    Private _dt_referencia As String
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _st_tipo_calculo As String
    Private _st_calculo_definitivo As String
    Private _st_calculo_definitivo_t1 As String
    Private _st_calculo_definitivo_t2 As String
    Private _st_calculo_definitivo_tp As String
    Private _id_calculo_frete_execucao As Int32
    Private _id_frete_periodo As Int32
    Private _id_tipo_frete As Int32
    Private _id_transportador As Int32
    Private _id_cooperativa As Int32
    Private _st_calculo_frete_execucao As String
    Private _id_modificador As Int32
    Private _cd_erro As String
    Private _nm_erro As String
    Private _id_calculo_frete_transportador As Int32
    Private _nr_cte_multi As String
    Private _nr_viagem_multi As Int32
    Private _nr_ano As Int32

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property id_tipo_frete() As Int32
        Get
            Return _id_tipo_frete
        End Get
        Set(ByVal value As Int32)
            _id_tipo_frete = value
        End Set
    End Property
    Public Property id_frete_periodo() As Int32
        Get
            Return _id_frete_periodo
        End Get
        Set(ByVal value As Int32)
            _id_frete_periodo = value
        End Set
    End Property
    Public Property id_cooperativa() As Int32
        Get
            Return _id_cooperativa
        End Get
        Set(ByVal value As Int32)
            _id_cooperativa = value
        End Set
    End Property
    Public Property id_transportador() As Int32
        Get
            Return _id_transportador
        End Get
        Set(ByVal value As Int32)
            _id_transportador = value
        End Set
    End Property
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
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
    Public Property st_tipo_calculo() As String
        Get
            Return _st_tipo_calculo
        End Get
        Set(ByVal value As String)
            _st_tipo_calculo = value
        End Set
    End Property
    Public Property id_calculo_frete_execucao() As Int32
        Get
            Return _id_calculo_frete_execucao
        End Get
        Set(ByVal value As Int32)
            _id_calculo_frete_execucao = value
        End Set
    End Property
    Public Property st_calculo_frete_execucao() As String
        Get
            Return _st_calculo_frete_execucao
        End Get
        Set(ByVal value As String)
            _st_calculo_frete_execucao = value
        End Set
    End Property
    Public Property nr_ano() As Int32
        Get
            Return _nr_ano
        End Get
        Set(ByVal value As Int32)
            _nr_ano = value
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
    Public Property cd_erro() As String
        Get
            Return _cd_erro
        End Get
        Set(ByVal value As String)
            _cd_erro = value
        End Set
    End Property
    Public Property nm_erro() As String
        Get
            Return _nm_erro
        End Get
        Set(ByVal value As String)
            _nm_erro = value
        End Set
    End Property
    Public Property st_calculo_definitivo() As String
        Get
            Return _st_calculo_definitivo
        End Get
        Set(ByVal value As String)
            _st_calculo_definitivo = value
        End Set
    End Property
    Public Property st_calculo_definitivo_t1() As String
        Get
            Return _st_calculo_definitivo_t1
        End Get
        Set(ByVal value As String)
            _st_calculo_definitivo_t1 = value
        End Set
    End Property
    Public Property st_calculo_definitivo_t2() As String
        Get
            Return _st_calculo_definitivo_t2
        End Get
        Set(ByVal value As String)
            _st_calculo_definitivo_t2 = value
        End Set
    End Property
    Public Property st_calculo_definitivo_tp() As String
        Get
            Return _st_calculo_definitivo_tp
        End Get
        Set(ByVal value As String)
            _st_calculo_definitivo_tp = value
        End Set
    End Property
    Public Property id_calculo_frete_transportador() As Int32
        Get
            Return _id_calculo_frete_transportador
        End Get
        Set(ByVal value As Int32)
            _id_calculo_frete_transportador = value
        End Set
    End Property
    Public Property nr_viagem_multi() As Int32
        Get
            Return _nr_viagem_multi
        End Get
        Set(ByVal value As Int32)
            _nr_viagem_multi = value
        End Set
    End Property
    Public Property nr_cte_multi() As String
        Get
            Return _nr_cte_multi
        End Get
        Set(ByVal value As String)
            _nr_cte_multi = value
        End Set
    End Property
    Public Sub New(ByVal id As String)

        Me.id_calculo_frete_execucao = id
        loadCalculoFreteExecucao()

    End Sub
    Public Function getCalculoFreteStatusExecucao() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoFreteStatusExecucao", parameters, ExecuteType.Select), String)

        End Using
    End Function



    Public Sub New()

    End Sub
    Public Function getCalculoFreteRomaneiosErrosT2() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoFreteRomaneiosErrosT2", parameters, "ms_calculo_frete_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoFreteRomaneiosErros() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoFreteRomaneiosErros", parameters, "ms_calculo_frete_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoFreteRomaneiosT2() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoFreteRomaneiosT2", parameters, "ms_calculo_frete_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoFreteRomaneios() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoFreteRomaneios", parameters, "ms_calculo_frete_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoFreteTransportador() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoFreteTransportador", parameters, "ms_calculo_frete_transportador")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoFretebyTransportador() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoFretebyTransportador", parameters, "ms_calculo_frete_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoFreteFlashFechamento() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoFreteFlashFechamento", parameters, "ms_calculo_frete_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoFreteFlashFechamentoT2() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoFreteFlashFechamentoT2", parameters, "ms_calculo_frete_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoFreteFlashFechamentoTotais() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoFreteFlashFechamentoTotais", parameters, "ms_calculo_frete_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoFreteFlashFechamentoTotaisT2() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoFreteFlashFechamentoTotaisT2", parameters, "ms_calculo_frete_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getFreteKpiDensidade() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFreteKpiDensidade", parameters, "ms_calculo_frete_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getFreteKpiCustos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFreteKpiCustos", parameters, "ms_calculo_frete_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoFreteExecucaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoFreteExecucao", parameters, "ms_calculo_frete_execucao")
            Return dataSet

        End Using

    End Function
    Private Sub loadCalculoFreteExecucao()

        Dim dataSet As DataSet = getCalculoFreteExecucaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertCalculoFreteExecucao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertCalculoFreteExecucao", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateCalculoFreteExecucao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateCalculoFreteExecucao", parameters, ExecuteType.Update)

        End Using


    End Sub

    Public Sub updateCalculoFreteTransportadorMulti()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateCalculoFreteTransportadorMulti", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub CalcularFreteT1()

        Dim transacao As New DataAccess

        'Inicia Transação
        'transacao.StartTransaction(IsolationLevel.RepeatableRead)
        transacao.StartTransaction()
        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'insere dados de romaneio de T1
            transacao.Execute("ms_insertCalculoFreteT1Dados", parameters, ExecuteType.Insert)
            transacao.Execute("ms_updateCalculoFreteDados", parameters, ExecuteType.Update)
            transacao.Execute("ms_updateCalculoFreteDivergencias", parameters, ExecuteType.Update)
            transacao.Execute("ms_insertCalculoFreteT1Ficha", parameters, ExecuteType.Insert)
            transacao.Execute("ms_insertCalculoFreteT1FichaItens", parameters, ExecuteType.Insert)
            transacao.Execute("ms_insertCalculoFreteT1Transportador", parameters, ExecuteType.Insert)
            transacao.Execute("ms_updateCalculoFreteExecucaoFim", parameters, ExecuteType.Update)
            If Me.st_calculo_definitivo = "S" Then
                transacao.Execute("ms_updateCalculoFreteDefinitivo", parameters, ExecuteType.Update)
            End If
            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub CalcularFreteT2()

        Dim transacao As New DataAccess

        'Inicia Transação
        'transacao.StartTransaction(IsolationLevel.RepeatableRead)
        transacao.StartTransaction()
        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'insere dados de romaneio de T2
            transacao.Execute("ms_insertCalculoFreteT2Dados", parameters, ExecuteType.Insert)
            transacao.Execute("ms_updateCalculoFreteDadosT2", parameters, ExecuteType.Update)
            transacao.Execute("ms_updateCalculoFreteDivergenciasT2", parameters, ExecuteType.Update)
            transacao.Execute("ms_insertCalculoFreteT2Ficha", parameters, ExecuteType.Insert)
            transacao.Execute("ms_insertCalculoFreteT2FichaItens", parameters, ExecuteType.Insert)
            transacao.Execute("ms_insertCalculoFreteT2Transportador", parameters, ExecuteType.Insert)
            transacao.Execute("ms_updateCalculoFreteExecucaoFim ", parameters, ExecuteType.Update)
            If Me.st_calculo_definitivo = "S" Then
                transacao.Execute("ms_updateCalculoFreteDefinitivo", parameters, ExecuteType.Update)
            End If

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Sub

    Public Sub CalcularFreteT3T4()

        Dim transacao As New DataAccess

        'Inicia Transação
        'transacao.StartTransaction(IsolationLevel.RepeatableRead)
        transacao.StartTransaction()
        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'insere dados de romaneio de T3T4
            transacao.Execute("ms_insertCalculoFreteT3T4Dados", parameters, ExecuteType.Insert)
            transacao.Execute("ms_updateCalculoFreteDados", parameters, ExecuteType.Update)
            transacao.Execute("ms_updateCalculoFreteDivergencias", parameters, ExecuteType.Update)
            transacao.Execute("ms_insertCalculoFreteT3T4Ficha", parameters, ExecuteType.Insert)
            transacao.Execute("ms_insertCalculoFreteT3T4FichaItens", parameters, ExecuteType.Insert)
            transacao.Execute("ms_insertCalculoFreteT3T4Transportador", parameters, ExecuteType.Insert)
            transacao.Execute("ms_updateCalculoFreteExecucaoFim ", parameters, ExecuteType.Update)
            If Me.st_calculo_definitivo = "S" Then
                transacao.Execute("ms_updateCalculoFreteDefinitivo", parameters, ExecuteType.Update)
            End If

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Sub
End Class
