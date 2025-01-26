Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GrupoAcessoProcesso

    Private _id_grupo_acesso_processo As Int32
    Private _id_grupo As Int32
    Private _id_usuario As Int32
    Private _nm_grupo As String
    Private _id_menu_item As Int32
    Private _id_menu_item_processo As Int32
    Private _id_tipo_acesso As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String


    Public Property id_grupo_acesso_processo() As Int32
        Get
            Return _id_grupo_acesso_processo
        End Get
        Set(ByVal value As Int32)
            _id_grupo_acesso_processo = value
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

    Public Property id_grupo() As Int32
        Get
            Return _id_grupo
        End Get
        Set(ByVal value As Int32)
            _id_grupo = value
        End Set
    End Property
    Public Property nm_grupo() As String
        Get
            Return _nm_grupo
        End Get
        Set(ByVal value As String)
            _nm_grupo = value
        End Set
    End Property
    Public Property id_menu_item_processo() As Int32
        Get
            Return _id_menu_item_processo
        End Get
        Set(ByVal value As Int32)
            _id_menu_item_processo = value
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
    Public Property id_tipo_acesso() As Int32
        Get
            Return _id_tipo_acesso
        End Get
        Set(ByVal value As Int32)
            _id_tipo_acesso = value
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

        Me.id_grupo_acesso_processo = id
        loadUsuarioGrupoAcessoProcesso()

    End Sub



    Public Sub New()

    End Sub


    Public Function getGrupoAcessoProcessoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getGrupoAcessoProcesso", parameters, "msc_grupo_acesso_processo")
            Return dataSet

        End Using

    End Function

    Private Sub loadUsuarioGrupoAcessoProcesso()

        Dim dataSet As DataSet = getGrupoAcessoProcessoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


End Class
