Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.DirectoryServices

<Serializable()> Public Class UsuarioLog

    Private _id_usuario_log As Int32
    Private _id_usuario As Int32
    Private _id_tipo_log As Int32
    Private _id_menu As Int32
    Private _id_menu_item As Int32
    Private _id_menu_item_processo As Int32
    Private _id_nr_processo As Int32
    Private _ds_id_session As String
    Private _ds_login As String
    Private _ds_nm_processo As String
    Private _nm_nr_processo As String
    Private _dt_criacao As String
    Private _dt_inicio As String
    Private _dt_fim As String

    Public Property id_usuario_log() As Int32
        Get
            Return _id_usuario_log
        End Get
        Set(ByVal value As Int32)
            _id_usuario_log = value
        End Set
    End Property
    Public Property id_nr_processo() As Int32
        Get
            Return _id_nr_processo
        End Get
        Set(ByVal value As Int32)
            _id_nr_processo = value
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
    Public Property id_tipo_log() As Int32
        Get
            Return _id_tipo_log
        End Get
        Set(ByVal value As Int32)
            _id_tipo_log = value
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
    Public Property id_menu() As Int32
        Get
            Return _id_menu
        End Get
        Set(ByVal value As Int32)
            _id_menu = value
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
    Public Property ds_id_session() As String
        Get
            Return _ds_id_session
        End Get
        Set(ByVal value As String)
            _ds_id_session = value
        End Set
    End Property
    Public Property ds_nm_processo() As String
        Get
            Return _ds_nm_processo
        End Get
        Set(ByVal value As String)
            _ds_nm_processo = value
        End Set
    End Property
    Public Property nm_nr_processo() As String
        Get
            Return _nm_nr_processo
        End Get
        Set(ByVal value As String)
            _nm_nr_processo = value
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
    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
        End Set
    End Property
    Public Property dt_inicio() As String
        Get
            Return _dt_inicio
        End Get
        Set(ByVal value As String)
            _dt_inicio = value
        End Set
    End Property
    Public Property dt_fim() As String
        Get
            Return _dt_fim
        End Get
        Set(ByVal value As String)
            _dt_fim = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_usuario_log = id
        loadUsuarioLog()

    End Sub



    Public Sub New()

    End Sub
    Public Function getUsuarioLogCriticos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getUsuarioLogCriticos", parameters, "ms_calculo_execucao_erro")
            Return dataSet

        End Using

    End Function

    Public Function getUsuarioLogByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getUsuarioLog", parameters, "msc_usuario_log")
            Return dataSet

        End Using

    End Function

    Private Sub loadUsuarioLog()

        Dim dataSet As DataSet = getUsuarioLogByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertUsuarioLog() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("msc_insertUsuarioLog", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function



End Class
