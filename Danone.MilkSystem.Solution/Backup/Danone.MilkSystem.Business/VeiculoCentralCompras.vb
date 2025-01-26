Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class VeiculoCentralCompras

    Private _id_veiculocentralcompras As Int32
    Private _nr_capacidade_min As Int32
    Private _nr_capacidade_max As Int32
    Private _nm_veiculocentralcompras As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Public Property id_veiculocentralcompras() As Int32
        Get
            Return _id_veiculocentralcompras
        End Get
        Set(ByVal value As Int32)
            _id_veiculocentralcompras = value
        End Set
    End Property
    Public Property nr_capacidade_min() As Int32
        Get
            Return _nr_capacidade_min
        End Get
        Set(ByVal value As Int32)
            _nr_capacidade_min = value
        End Set
    End Property
    Public Property nr_capacidade_max() As Int32
        Get
            Return _nr_capacidade_max
        End Get
        Set(ByVal value As Int32)
            _nr_capacidade_max = value
        End Set
    End Property
    Public Property nm_veiculocentralcompras() As String
        Get
            Return _nm_veiculocentralcompras
        End Get
        Set(ByVal value As String)
            _nm_veiculocentralcompras = value
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
    Public Sub New(ByVal id As Int32)

        Me._id_veiculocentralcompras = id
        loadVeiculoCentralCompras()

    End Sub



    Public Sub New()

    End Sub


    Public Function getVeiculoCentralComprasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getVeiculoCentralCompras", parameters, "ms_zveiculocentralcompras")
            Return dataSet

        End Using

    End Function
    Private Sub loadVeiculoCentralCompras()

        Dim dataSet As DataSet = getVeiculoCentralComprasByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
End Class
