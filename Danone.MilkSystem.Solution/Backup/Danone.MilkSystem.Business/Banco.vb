Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class Banco

    Public Sub New()

    End Sub

    Public Sub New(ByVal pid_banco As Int32)

        _id_banco = pid_banco
        loadBanco()

    End Sub

    Private _id_banco As Int32
    Private _cd_banco As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nm_banco As String

    Public Property id_banco() As Int32
        Get
            Return _id_banco
        End Get
        Set(ByVal value As Int32)
            _id_banco = value
        End Set
    End Property

    Public Property cd_banco() As String
        Get
            Return _cd_banco
        End Get
        Set(ByVal value As String)
            _cd_banco = value
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

    Public Property nm_banco() As String
        Get
            Return _nm_banco
        End Get
        Set(ByVal value As String)
            _nm_banco = value
        End Set
    End Property


    Public Function getBancosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getBancos", parameters, "ms_banco")

            Return dataSet

        End Using

    End Function
    Public Function getBancosByCodigo() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getBancosCodigo", parameters, ExecuteType.Select), Int32)

        End Using
    End Function

    Private Sub loadBanco()

        Dim dataSet As DataSet = getBancosByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertBanco() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertBancos", parameters, ExecuteType.Insert), Int32)

        End Using

    End Function

    Public Sub updateBanco()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateBancos", parameters, ExecuteType.Update)

        End Using


    End Sub

    Public Sub deleteBanco()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteBancos", parameters, ExecuteType.Delete)

        End Using

    End Sub

End Class
