Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.DirectoryServices

<Serializable()> Public Class Usuario

    Private _id_usuario As Int32
    Private _nm_usuario As String
    Private _ds_login As String
    Private _id_tipo_usuario As Int32
    Private _pw_senha As String
    Private _ds_email As String
    Private _ds_depto As String
    Private _ds_telefone As String
    Private _cd_cpf As String
    Private _ds_dominio As String
    Private _st_senha_default As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_usuario() As Int32
        Get
            Return _id_usuario
        End Get
        Set(ByVal value As Int32)
            _id_usuario = value
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
    Public Property pw_senha() As String
        Get
            Return _pw_senha
        End Get
        Set(ByVal value As String)
            _pw_senha = value
        End Set
    End Property
    Public Property ds_email() As String
        Get
            Return _ds_email
        End Get
        Set(ByVal value As String)
            _ds_email = value
        End Set
    End Property
    Public Property ds_depto() As String
        Get
            Return _ds_depto
        End Get
        Set(ByVal value As String)
            _ds_depto = value
        End Set
    End Property
    Public Property ds_telefone() As String
        Get
            Return _ds_telefone
        End Get
        Set(ByVal value As String)
            _ds_telefone = value
        End Set
    End Property
    Public Property cd_cpf() As String
        Get
            Return _cd_cpf
        End Get
        Set(ByVal value As String)
            _cd_cpf = value
        End Set
    End Property
    Public Property ds_dominio() As String
        Get
            Return _ds_dominio
        End Get
        Set(ByVal value As String)
            _ds_dominio = value
        End Set
    End Property
    Public Property st_senha_default() As String
        Get
            Return _st_senha_default
        End Get
        Set(ByVal value As String)
            _st_senha_default = value
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

        Me.id_usuario = id
        loadUsuario()

    End Sub



    Public Sub New()

    End Sub


    Public Function getUsuarioByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getUsuarios", parameters, "msc_usuario")
            Return dataSet

        End Using

    End Function

    Private Sub loadUsuario()

        Dim dataSet As DataSet = getUsuarioByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertUsuario() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("msc_insertUsuarios", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateUsuario()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("msc_updateUsuarios", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateUsuarioSenha()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("msc_updateUsuarioSenha", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteUsuario()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("msc_deleteUsuarios", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function autentica(ByVal usuario As String, ByVal senha As String, Optional ByRef errmsg As String = "", Optional ByRef errdesc As String = "") As Boolean
        Dim resultado As String = ""
        Dim LDAPServer As String = RK.GlobalTools.Tools.getConfigTagByName("LDAPServer")

        Try
            'Dim oAD As DirectoryEntry = New DirectoryEntry("LDAP://" + server, usuario, senha)
            Dim oAD As DirectoryEntry = New DirectoryEntry(LDAPServer, usuario, senha)
            resultado = oAD.Name
            Return True
        Catch ex As Exception
            'Fran 14/10/2024 - tratar erros ldap
            errdesc = ex.ToString
            errmsg = ex.Message
            Return False
        End Try
    End Function



End Class
