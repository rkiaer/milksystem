Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PrecoAdicionalMercado

    Private _id_preco_objetivo As Int32
    Private _nr_mes As String
    Private _nr_adic_mercado As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_preco_objetivo() As Int32
        Get
            Return _id_preco_objetivo
        End Get
        Set(ByVal value As Int32)
            _id_preco_objetivo = value
        End Set
    End Property

    Public Property nr_mes() As String
        Get
            Return _nr_mes
        End Get
        Set(ByVal value As String)
            _nr_mes = value
        End Set
    End Property

    Public Property nr_adic_mercado() As Decimal
        Get
            Return _nr_adic_mercado
        End Get
        Set(ByVal value As Decimal)
            _nr_adic_mercado = value
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

    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Int32, ByVal mes As String)
        Me.id_preco_objetivo = id
        Me.nr_mes = mes
        loadAdicionalMercado()
    End Sub

    Public Function getAdicionalMercadoByFilters() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAdicionaisMercado", parameters, "ms_adicional_mercado")
            Return dataSet

        End Using
    End Function

    Private Sub loadAdicionalMercado()
        Dim dataSet As DataSet = getAdicionalMercadoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)
    End Sub

End Class
