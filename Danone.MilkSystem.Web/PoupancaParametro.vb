Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PoupancaParametro
    Private _id_poupanca_parametro As Int32
    Private _id_estabelecimento As Int32
    Private _dt_referencia_ini As String
    Private _dt_referencia_fim As String
    Private _nr_bonus_1ano As Decimal
    Private _nr_bonus_2ano As Decimal
    Private _nr_bonus_3ano As Decimal
    Private _nr_spend_periodo As Decimal
    Private _nr_bonus_extra_1ano As Decimal
    Private _nr_bonus_extra_2ano As Decimal
    Private _nr_bonus_extra_3ano As Decimal
    Private _id_situacao_poupanca As Int32
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Public Property id_poupanca_parametro() As Int32
        Get
            Return _id_poupanca_parametro
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_parametro = value
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
    Public Property dt_referencia_ini() As Decimal
        Get
            Return _dt_referencia_ini
        End Get
        Set(ByVal value As Decimal)
            _dt_referencia_ini = value
        End Set
    End Property

    Public Property dt_referencia_fim() As Decimal
        Get
            Return _dt_referencia_fim
        End Get
        Set(ByVal value As Decimal)
            _dt_referencia_fim = value
        End Set
    End Property

    Public Property nr_bonus_1ano() As Decimal
        Get
            Return _nr_bonus_1ano
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_1ano = value
        End Set
    End Property
    Public Property nr_bonus_2ano() As Decimal
        Get
            Return _nr_bonus_2ano
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_2ano = value
        End Set
    End Property
    Public Property nr_bonus_3ano() As Decimal
        Get
            Return _nr_bonus_3ano
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_3ano = value
        End Set
    End Property
    Public Property nr_spend_periodo() As Decimal
        Get
            Return _nr_spend_periodo
        End Get
        Set(ByVal value As Decimal)
            _nr_spend_periodo = value
        End Set
    End Property
    Public Property nr_bonus_extra_1ano() As Decimal
        Get
            Return _nr_bonus_extra_1ano
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_extra_1ano = value
        End Set
    End Property
    Public Property nr_bonus_extra_2ano() As Decimal
        Get
            Return _nr_bonus_extra_2ano
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_extra_2ano = value
        End Set
    End Property
    Public Property nr_bonus_extra_3ano() As Decimal
        Get
            Return _nr_bonus_extra_3ano
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_extra_3ano = value
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

    Public Sub New(ByVal id As Int32)
        Me.id_poupanca_parametro = id
        loadPoupancaParametro()
    End Sub

    Public Sub New()
        loadPoupancaParametro()

    End Sub


    Public Function getPoupancaParametro() As DataSet

        Using data As New DataAccess

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaParametro", "ms_poupanca_parametro")
            Return dataSet

        End Using

    End Function

    Private Sub loadPoupancaParametro()

        Dim dataSet As DataSet = getPoupancaParametro()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updatePoupancaParametro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaParametro", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function insertPoupancaParametro() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPoupancaParametro", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
End Class
