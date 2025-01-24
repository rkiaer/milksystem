Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class UsuarioGrupo

    Private _id_usuario_grupo As Int32
    Private _id_usuario As Int32
    Private _id_grupo As Int32
    Private _id_modificador As Int32
    Private _nm_usuario As String
    Private _ds_login As String
    Private _id_tipo_usuario As Int32
    Private _id_situacao As Int32
    Private _id_menu As Int32
    Private _id_menu_item As Int32

    Public Property id_usuario_grupo() As Int32
        Get
            Return _id_usuario_grupo
        End Get
        Set(ByVal value As Int32)
            _id_usuario_grupo = value
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
    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
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

    Public Property nm_usuario() As String
        Get
            Return _nm_usuario
        End Get
        Set(ByVal value As String)
            _nm_usuario = value
        End Set
    End Property
    Public Property ds_login() As String
        Get
            Return _ds_login
        End Get
        Set(ByVal value As String)
            _ds_login = value
        End Set
    End Property
    Public Property id_tipo_usuario() As Int32
        Get
            Return _id_tipo_usuario
        End Get
        Set(ByVal value As Int32)
            _id_tipo_usuario = value
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
    Public Property id_menu() As Int32
        Get
            Return _id_menu
        End Get
        Set(ByVal value As Int32)
            _id_menu = value
        End Set
    End Property
    Public Property id_menu_item() As Int32
        Get
            Return _id_menu_item
        End Get
        Set(ByVal value As Int32)
            _id_menu_item = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_grupo = id
        loadUsuarioGrupo()

    End Sub



    Public Sub New()

    End Sub
    Public Function getRelatorioUsuarioGrupos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getRelatorioUsuarioGrupos", parameters, "msc_usuario_grupo")
            Return dataSet

        End Using

    End Function
    Public Function getRelatorioUsuarioGruposMenus() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getRelatorioUsuarioGruposMenus", parameters, "msc_usuario_grupo")
            Return dataSet

        End Using

    End Function
    Public Function getUSuarioGrupoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getUsuarioGrupos", parameters, "msc_usuario_grupo")
            Return dataSet

        End Using

    End Function

    Private Sub loadUsuarioGrupo()

        Dim dataSet As DataSet = getUSuarioGrupoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertUsuarioGrupo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("msc_insertUsuarioGrupos", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub deleteUsuarioGrupo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("msc_deleteUsuarioGrupos", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
