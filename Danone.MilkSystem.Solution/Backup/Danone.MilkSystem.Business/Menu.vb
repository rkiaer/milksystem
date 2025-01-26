Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Menu

    Private _id_menu As Int32
    Private _nm_menu As String
    Private _nr_sequencia As Int32
    Private _id_usuario As Int32
    Private _id_situacao As Int32

    Public Property id_menu() As Int32
        Get
            Return _id_menu
        End Get
        Set(ByVal value As Int32)
            _id_menu = value
        End Set
    End Property

    Public Property nm_menu() As String
        Get
            Return _nm_menu
        End Get
        Set(ByVal value As String)
            _nm_menu = value
        End Set
    End Property

    Public Property nr_sequencia() As Int32
        Get
            Return _nr_sequencia
        End Get
        Set(ByVal value As Int32)
            _nr_sequencia = value
        End Set
    End Property
    Public Property id_usuario() As Int32
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Int32)
            _id_usuario = value
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
    Public Sub New(ByVal id As Int32)

        Me.id_menu = id
        loadMenu()

    End Sub



    Public Sub New()

    End Sub


    Public Function getMenuByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getMenus", parameters, "msc_menu")
            Return dataSet

        End Using

    End Function
    Public Function getLoginMenuByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getLoginMenus", parameters, "msc_menu")
            Return dataSet

        End Using

    End Function

    Private Sub loadMenu()

        Dim dataSet As DataSet = getMenuByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


End Class
