Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GrupoAcesso

    Private _id_grupo_acesso As Int32
    Private _id_grupo As Int32
    Private _nm_grupo As String
    Private _id_menu As Int32
    Private _id_menu_item As Int32
    Private _id_tipo_acesso As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _menuitem As New ArrayList


    Public Property id_grupo_acesso() As Int32
        Get
            Return _id_grupo_acesso
        End Get
        Set(ByVal value As Int32)
            _id_grupo_acesso = value
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
    Public Property menuitem() As ArrayList
        Get
            Return _menuitem
        End Get
        Set(ByVal value As ArrayList)
            _menuitem = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_grupo_acesso = id
        loadUsuarioGrupoAcesso()

    End Sub



    Public Sub New()

    End Sub
    Public Function getUSuarioGrupoAcessoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getUsuarioGrupos", parameters, "msc_usuario_grupo")
            Return dataSet

        End Using

    End Function

    Public Function getRelatorioGruposMenus() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getRelatorioGruposMenus", parameters, "msc_grupo_acesso")
            Return dataSet

        End Using

    End Function

    Private Sub loadUsuarioGrupoAcesso()

        Dim dataSet As DataSet = getUSuarioGrupoAcessoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function updateGrupoAcesso() As Int32

        Dim transacao As New DataAccess

        transacao.StartTransaction()
        Try
            Dim i As Int32


            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

 

            For i = 0 To Me.menuitem.Count - 1
                Me.id_menu_item = Me.menuitem(i)
                parameters = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("msc_deleteGrupoAcesso", parameters, ExecuteType.Delete)
                transacao.ExecuteScalar("msc_insertGrupoAcesso", parameters, ExecuteType.Insert)
            Next


            transacao.Commit()


        Catch ex As Exception
            transacao.RollBack()
            Throw New Exception(ex.Message)

        End Try


    End Function


    Public Sub deleteUsuarioGrupo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("msc_deleteUsuarioGrupos", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
