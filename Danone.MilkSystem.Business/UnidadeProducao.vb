Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class UnidadeProducao

    Private _id_unid_producao As Int32
    Private _nr_unid_producao As Int32
    Private _id_situacao As Int32
    Private _id_propriedade As Int32
    Private _id_pessoa As Int32
    Private _id_estabelecimento As Int32
    Private _cd_pessoa As String
    Private _cd_estabelecimento As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _nm_unid_producao As String
    Private _nm_pessoa As String
    Private _nm_propriedade As String
    Private _nm_estabelecimento As String
    Private _nr_latitude As Decimal
    Private _nr_longitude As Decimal


    Public Property id_unid_producao() As Int32
        Get
            Return _id_unid_producao
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao = value
        End Set
    End Property
    Public Property nr_unid_producao() As Int32
        Get
            Return _nr_unid_producao
        End Get
        Set(ByVal value As Int32)
            _nr_unid_producao = value
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
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
        End Set
    End Property
    Public Property id_pessoa() As Int32
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
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

    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
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

    Public Property nm_unid_producao() As String
        Get
            Return _nm_unid_producao
        End Get
        Set(ByVal value As String)
            _nm_unid_producao = value
        End Set
    End Property
    Public Property nm_propriedade() As String
        Get
            Return _nm_propriedade
        End Get
        Set(ByVal value As String)
            _nm_propriedade = value
        End Set
    End Property
    Public Property nm_pessoa() As String
        Get
            Return _nm_pessoa
        End Get
        Set(ByVal value As String)
            _nm_pessoa = value
        End Set
    End Property
    Public Property nm_estabelecimento() As String
        Get
            Return _nm_estabelecimento
        End Get
        Set(ByVal value As String)
            _nm_estabelecimento = value
        End Set
    End Property
    Public Property cd_pessoa() As String
        Get
            Return _cd_pessoa
        End Get
        Set(ByVal value As String)
            _cd_pessoa = value
        End Set
    End Property
    Public Property cd_estabelecimento() As String
        Get
            Return _cd_estabelecimento
        End Get
        Set(ByVal value As String)
            _cd_estabelecimento = value
        End Set
    End Property
    Public Property nr_latitude() As Decimal
        Get
            Return _nr_latitude
        End Get
        Set(ByVal value As Decimal)
            _nr_latitude = value
        End Set
    End Property

    Public Property nr_longitude() As Decimal
        Get
            Return _nr_longitude
        End Get
        Set(ByVal value As Decimal)
            _nr_longitude = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_unid_producao = id
        loadUnidadeProducao()

    End Sub



    Public Sub New()

    End Sub


    Public Function getUnidadeProducaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getunidadesproducao", parameters, "ms_unidade_producao")
            Return dataSet

        End Using

    End Function

    Private Sub loadUnidadeProducao()

        Dim dataSet As DataSet = getUnidadeProducaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertUnidadeProducao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertUnidadesProducao", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateUnidadeProducao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateUnidadesProducao", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteUnidadeProducao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteUnidadesProducao", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function validarUnidadeProcucao() As Boolean

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getunidadesproducao", parameters, "ms_unidade_producao")
            If dataSet.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        End Using

    End Function
End Class
