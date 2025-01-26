Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class CustoFinanceiro


    Private _id_custo_financeiro As Int32
    Private _id_tipo_custo_financeiro As Int32
    Private _id_situacao As Int32
    Private _nm_tipo_custo_financeiro As String
    Private _nr_ano As Int32
    Private _id_estabelecimento As Int32
    Private _dt_referencia As String
    Private _dt_referencia_ini As String
    Private _dt_referencia_fim As String
    Private _id_custo_financeiro_calculo_execucao As Int32
    Private _st_calculo_execucao As String
    Private _id_modificador As Int32
    Private _st_sistema As String
    Private _nr_valor_01 As Decimal
    Private _nr_valor_02 As Decimal
    Private _nr_valor_03 As Decimal
    Private _nr_valor_04 As Decimal
    Private _nr_valor_05 As Decimal
    Private _nr_valor_06 As Decimal
    Private _nr_valor_07 As Decimal
    Private _nr_valor_08 As Decimal
    Private _nr_valor_09 As Decimal
    Private _nr_valor_10 As Decimal
    Private _nr_valor_11 As Decimal
    Private _nr_valor_12 As Decimal
    Private _st_limite_incentivo As String
    Public Property st_limite_incentivo() As String
        Get
            Return _st_limite_incentivo
        End Get
        Set(ByVal value As String)
            _st_limite_incentivo = value
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
    Public Property id_custo_financeiro() As Int32
        Get
            Return _id_custo_financeiro
        End Get
        Set(ByVal value As Int32)
            _id_custo_financeiro = value
        End Set
    End Property
    Public Property id_tipo_custo_financeiro() As Int32
        Get
            Return _id_tipo_custo_financeiro
        End Get
        Set(ByVal value As Int32)
            _id_tipo_custo_financeiro = value
        End Set
    End Property
    Public Property nm_tipo_custo_financeiro() As String
        Get
            Return _nm_tipo_custo_financeiro
        End Get
        Set(ByVal value As String)
            _nm_tipo_custo_financeiro = value
        End Set
    End Property
    Public Property st_sistema() As String
        Get
            Return _st_sistema
        End Get
        Set(ByVal value As String)
            _st_sistema = value
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
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
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
    Public Property id_custo_financeiro_calculo_execucao() As Int32
        Get
            Return _id_custo_financeiro_calculo_execucao
        End Get
        Set(ByVal value As Int32)
            _id_custo_financeiro_calculo_execucao = value
        End Set
    End Property
    Public Property st_calculo_execucao() As String
        Get
            Return _st_calculo_execucao
        End Get
        Set(ByVal value As String)
            _st_calculo_execucao = value
        End Set
    End Property
    Public Property nr_valor_01() As Decimal
        Get
            Return _nr_valor_01
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_01 = value
        End Set
    End Property
    Public Property nr_valor_02() As Decimal
        Get
            Return _nr_valor_02
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_02 = value
        End Set
    End Property
    Public Property nr_valor_03() As Decimal
        Get
            Return _nr_valor_03
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_03 = value
        End Set
    End Property
    Public Property nr_valor_04() As Decimal
        Get
            Return _nr_valor_04
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_04 = value
        End Set
    End Property
    Public Property nr_valor_05() As Decimal
        Get
            Return _nr_valor_05
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_05 = value
        End Set
    End Property
    Public Property nr_valor_06() As Decimal
        Get
            Return _nr_valor_06
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_06 = value
        End Set
    End Property
    Public Property nr_valor_07() As Decimal
        Get
            Return _nr_valor_07
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_07 = value
        End Set
    End Property
    Public Property nr_valor_08() As Decimal
        Get
            Return _nr_valor_08
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_08 = value
        End Set
    End Property
    Public Property nr_valor_09() As Decimal
        Get
            Return _nr_valor_09
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_09 = value
        End Set
    End Property
    Public Property nr_valor_10() As Decimal
        Get
            Return _nr_valor_10
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_10 = value
        End Set
    End Property
    Public Property nr_valor_11() As Decimal
        Get
            Return _nr_valor_11
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_11 = value
        End Set
    End Property
    Public Property nr_valor_12() As Decimal
        Get
            Return _nr_valor_12
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_12 = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_custo_financeiro = id
        loadCustoFinanceiro()

    End Sub

    Public Sub New()

    End Sub

    Public Function getCustoFinanceiroByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCustoFinanceiro", parameters, "ms_custo_financeiro")
            Return dataSet

        End Using

    End Function

    Private Sub loadCustoFinanceiro()

        Dim dataSet As DataSet = getCustoFinanceiroByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function getDataUltimoCalculoProjetado() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCustoFinanceiroUltimoCalculoProjetado", parameters, "ms_custo_financeiro")
            Return dataSet

        End Using
    End Function

    Public Function getCustoFinanceiroRelatorioVolume() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCustoFinanceiroRelatorioVolume", parameters, "ms_custo_financeiro")
            Return dataSet

        End Using

    End Function
    Public Function getCustoFinanceiroRelatorioPreco() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCustoFinanceiroRelatorioPreco", parameters, "ms_custo_financeiro")
            Return dataSet

        End Using

    End Function
    Public Function getCustoFinanceiroRelatorioOutrosCustos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCustoFinanceiroRelatorioOutrosCustos", parameters, "ms_custo_financeiro")
            Return dataSet

        End Using

    End Function

    Public Function getCustoFinanceiroFichaMesProvisorio() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_getCustoFinanceiroFichaMesProvisorio", parameters, ExecuteType.Select), Int32)

        End Using


    End Function
    Public Function getCustoFinanceiroConsistirObrigatorio() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCustoFinanceiroConsistirObrigatorio", parameters, "ms_custo_financeiro")
            Return dataSet

        End Using

    End Function
    Public Function getTipoCustoFinanceiro() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTipoCustoFinanceiro", parameters, "ms_ztipo_custo_financeiro")
            Return dataSet

        End Using

    End Function
    Public Function getCustoFinanceiroCalculo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCustoFinanceiroCalculo", parameters, "ms_custo_financeiro")
            Return dataSet

        End Using

    End Function
    Public Function getCustoFinanceiroConsistirVolumeLeite() As Decimal

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_getCustoFinanceiroConsistirVolumeLeite", parameters, ExecuteType.Select), Decimal)

        End Using


    End Function
    Public Function insertCustoFinanceiroCalculoExecucao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertCustoFinanceiroCalculoExecucao", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateCustoFinanceiroCalculoExecucao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateCustoFinanceiroCalculoExecucao", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub calcularCustoFinanceiroProjetado()

        Try

            Me.insertCustoFinanceiroCalculoProdutor()
            Me.insertCustoFinanceiroCalculoProdutorCooperativa()

            Me.st_calculo_execucao = "F"       ' Finalizado
            Me.updateCustoFinanceiroCalculoExecucao()


        Catch err As Exception
            Me.st_calculo_execucao = "E"       ' Finalizado com erro
            Me.updateCustoFinanceiroCalculoExecucao()
            'CalculoExecucao.nm_erro = err.Message
            'CalculoExecucao.insertCalculoExecucaoErro()

            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Function getCustoFinanceiroCalculoStatusExecucao() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCustoFinanceiroCalculoStatusExecucao", parameters, ExecuteType.Select), String)

        End Using
    End Function

    Public Function insertCustoFinanceiroCalculoProdutor() As Int32


        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertCustoFinanceiroCalculoProdutor", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertCustoFinanceiroCalculoProdutorCooperativa() As Int32


        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertCustoFinanceiroCalculoCooperativa", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Function getCustoFinanceiroParametroUltimoAno() As Int64
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCustoFinanceiroParametroUltimoAno", parameters, ExecuteType.Select), Int64)

        End Using
    End Function
    Public Function getCustoFinanceiroNovoAno() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCustoFinanceiroNovoAno", parameters, "ms_custo_financeiro")
            Return dataSet

        End Using

    End Function
    Public Function insertCustoFinanceiro() As Int32


        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertCustoFinanceiro", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function getMapaLimiteIncentivo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMapaLimiteIncentivo", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    Public Sub updateCustoFinanceiro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateCustoFinanceiro", parameters, ExecuteType.Update)

        End Using


    End Sub
End Class
