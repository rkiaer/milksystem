Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.Math



<Serializable()> Public Class Poupanca

    Private _id_estabelecimento As Int32
    Private _id_propriedade As Int32
    Private _id_propriedade_titular As Int32
    Private _id_pessoa As Int32
    Private _id_poupanca_parametro As Int32
    Private _id_poupanca_adesao As Int32
    Private _id_poupanca_calculo_execucao As Int32
    Private _dt_referencia As String
    Private _dt_referencia_ini As String
    Private _dt_referencia_fim As String
    Private _id_ficha_financeira As Int32
    Private _st_selecao As String
    Private _id_selecao As String
    Private _id_modificador As Int32
    Private _nr_valor_central As Decimal

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
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
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
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
    Public Property id_poupanca_parametro() As Int32
        Get
            Return _id_poupanca_parametro
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_parametro = value
        End Set
    End Property
    Public Property id_poupanca_adesao() As Int32
        Get
            Return _id_poupanca_adesao
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_adesao = value
        End Set
    End Property
    Public Property id_poupanca_calculo_execucao() As Int32
        Get
            Return _id_poupanca_calculo_execucao
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_calculo_execucao = value
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
    Public Property st_selecao() As String
        Get
            Return _st_selecao
        End Get
        Set(ByVal value As String)
            _st_selecao = value
        End Set
    End Property
    Public Property id_selecao() As String
        Get
            Return _id_selecao
        End Get
        Set(ByVal value As String)
            _id_selecao = value
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

    Public Property id_ficha_financeira() As Int32
        Get
            Return _id_ficha_financeira
        End Get
        Set(ByVal value As Int32)
            _id_ficha_financeira = value
        End Set
    End Property

    Public Property nr_valor_central() As Decimal
        Get
            Return _nr_valor_central
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_central = value
        End Set
    End Property
    'Public Sub New(ByVal id As String)

    '    Me.id_selecao = id
    '    loadCalculoProdutor()

    'End Sub



    Public Sub New()

    End Sub

    'Private Sub loadCalculoProdutor()

    '    Dim dataSet As DataSet = getCalculoProdutorByFilters()
    '    ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    'End Sub
    Public Function getPoupancaValorBonusbyGrupo() As Decimal
        'Busca um somatorio da conta id 254 cd 2500 BONUS POUPANCA MENSAL
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getPoupancaValorBonusbyGrupo", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function

    Public Function getPoupancaValorBonusTransferenciabyGrupo() As Decimal
        'Busca um somatorio da ms_transferencia_poupanca para a propriedade
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getPoupancaValorBonusTransferenciabyGrupo", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getPoupancaValorBonus() As Decimal
        'Busca um somatorio da conta id 254 cd 2500 BONUS POUPANCA MENSAL
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getPoupancaValorBonus", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function

    Public Function getPoupancaValorBonusTransferencia() As Decimal
        'Busca um somatorio da ms_transferencia_poupanca para a propriedade
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getPoupancaValorBonusTransferencia", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getPoupancaUltimoCalculoMensal() As String
        Using data As New DataAccess

            'Busca da ficha o ultimo calco de poupanca mensal realizado
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getPoupancaUltimoCalculoMensal", parameters, ExecuteType.Select), String)

        End Using

    End Function
    Public Function getPoupancaPropriedades() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaPropriedades", parameters, "ms_poupanca_parametro")
            Return dataSet

        End Using

    End Function
    Public Function getExtratoPoupancaMensal() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getExtratoPoupancaMensal", parameters, "ms_poupanca_parametro")
            Return dataSet

        End Using

    End Function
    'fran 23/10/2018
    Public Function getMaisSolidosProdutorPremiado() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getMaisSolidosProdutorPremiado", parameters, "ms_poupanca_premio")
            Return dataSet

        End Using

    End Function

    Public Function getMaisSolidosProdutorSaldoDisponivel() As Decimal
        'Busca um somatorio da ms_transferencia_poupanca para a propriedade
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getMaisSolidosProdutorSaldoDisponivel", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getMaisSolidosMaiorReferenciaComPedido() As DataSet
        Using data As New DataAccess

            'Busca a maior referencia que foi incluido pedido para o produtor ou propriedade titular
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getMaisSolidosMaiorReferenciaComPedido", parameters, "ms_poupanca_premio")
            Return dataSet

        End Using

    End Function
    Public Function getMaisSolidosSaldoDisponivelReferencia() As Decimal

        'Busca os valores da central já utilizados no premio
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getMaisSolidosSaldoDisponivelReferencia", parameters, ExecuteType.Select), Decimal)

        End Using


    End Function
    Public Sub updateMaisSolidosPremio()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateMaisSolidosPremio", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
