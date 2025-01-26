Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class MenuItem

    Private _id_menu_item As Int32
    Private _nm_menu_item As String
    Private _ds_navigateurl As String
    Private _nr_sequencia As Int32
    Private _id_menu As Int32
    Private _id_grupo As Int32
    Private _id_usuario As Int32
    Private _id_situacao As Int32

    Public Property id_menu_item() As Int32
        Get
            Return _id_menu_item
        End Get
        Set(ByVal value As Int32)
            _id_menu_item = value
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
    Public Property nm_menu_item() As String
        Get
            Return _nm_menu_item
        End Get
        Set(ByVal value As String)
            _nm_menu_item = value
        End Set
    End Property
    Public Property ds_navigateurl() As String
        Get
            Return _ds_navigateurl
        End Get
        Set(ByVal value As String)
            _ds_navigateurl = value
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
    Public Property id_menu() As Int32
        Get
            Return _id_menu
        End Get
        Set(ByVal value As Int32)
            _id_menu = value
        End Set
    End Property
    Public Property id_grupo() As Int32
        Get
            Return _id_grupo
        End Get
        Set(ByVal value As Int32)
            _id_grupo = value
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

    Public Sub New(ByVal id As Int32)

        Me.id_menu = id
        loadMenuItem()

    End Sub



    Public Sub New()

    End Sub


    Public Function getMenuItemByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getMenuItens", parameters, "msc_menu_item")
            Return dataSet

        End Using

    End Function
    Public Function getMenuItem() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getMenuItem", parameters, "msc_menu_item")
            Return dataSet

        End Using

    End Function
    Public Function getLoginMenuItemByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getLoginMenuItens", parameters, "msc_menu_item")
            Return dataSet

        End Using

    End Function

    Private Sub loadMenuItem()

        Dim dataSet As DataSet = getMenuItemByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


End Class
