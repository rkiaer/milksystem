Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Balanca

    Private _id_balanca As Int32
    Private _id_estabelecimento As Int32
    Private _nm_balanca As String
    Private _ds_end_ip As String
    Private _ds_porta As String
    Private _id_tipo_pesagem As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_balanca() As Int32
        Get
            Return _id_balanca
        End Get
        Set(ByVal value As Int32)
            _id_balanca = value
        End Set
    End Property

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property nm_balanca() As String
        Get
            Return _nm_balanca
        End Get
        Set(ByVal value As String)
            _nm_balanca = value
        End Set
    End Property
    Public Property ds_end_ip() As String
        Get
            Return _ds_end_ip
        End Get
        Set(ByVal value As String)
            _ds_end_ip = value
        End Set
    End Property
    Public Property ds_porta() As String
        Get
            Return _ds_porta
        End Get
        Set(ByVal value As String)
            _ds_porta = value
        End Set
    End Property
    Public Property id_tipo_pesagem() As Int32
        Get
            Return _id_tipo_pesagem
        End Get
        Set(ByVal value As Int32)
            _id_tipo_pesagem = value
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
    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
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

        Me.id_balanca = id
        loadBalanca()

    End Sub



    Public Sub New()

    End Sub


    Public Function getBalancaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getBalanca", parameters, "ms_balanca")
            Return dataSet

        End Using

    End Function

    Private Sub loadBalanca()

        Dim dataSet As DataSet = getBalancaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Sub updateBalanca()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateBalanca", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteBalanca()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteBalanca", parameters, ExecuteType.Delete)

        End Using


    End Sub

    Public Function insertBalanca() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertBalanca", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

End Class
