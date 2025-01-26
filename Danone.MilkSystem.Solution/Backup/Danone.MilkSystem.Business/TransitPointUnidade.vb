Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class TransitPointUnidade

    Private _id_transit_point_unidade As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _id_estabelecimento As Int32
    Private _dt_modificacao As String
    Private _nm_transit_point_unidade As String
    Private _cd_transit_point_unidade As String
    Private _nm_situacao As String
    Private _ds_endereco As String
    Private _nr_endereco As Int32
    Private _ds_complemento As String
    Private _ds_bairro As String
    Private _id_cidade As Int32
    Private _nm_cidade As String
    Private _id_estado As Int32
    Private _cd_uf As String
    Private _cd_cep As String


    Public Property id_transit_point_unidade() As Int32
        Get
            Return _id_transit_point_unidade
        End Get
        Set(ByVal value As Int32)
            _id_transit_point_unidade = value
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

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
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


    Public Property nm_transit_point_unidade() As String
        Get
            Return _nm_transit_point_unidade
        End Get
        Set(ByVal value As String)
            _nm_transit_point_unidade = value
        End Set
    End Property
    Public Property cd_transit_point_unidade() As String
        Get
            Return _cd_transit_point_unidade
        End Get
        Set(ByVal value As String)
            _cd_transit_point_unidade = value
        End Set
    End Property

    Public Property nm_situacao() As String
        Get
            Return _nm_situacao
        End Get
        Set(ByVal value As String)
            _nm_situacao = value
        End Set
    End Property
    Public Property ds_endereco() As String
        Get
            Return _ds_endereco
        End Get
        Set(ByVal value As String)
            _ds_endereco = value
        End Set
    End Property

    Public Property nr_endereco() As Int32
        Get
            Return _nr_endereco
        End Get
        Set(ByVal value As Int32)
            _nr_endereco = value
        End Set
    End Property

    Public Property ds_complemento() As String
        Get
            Return _ds_complemento
        End Get
        Set(ByVal value As String)
            _ds_complemento = value
        End Set
    End Property
    Public Property ds_bairro() As String
        Get
            Return _ds_bairro
        End Get
        Set(ByVal value As String)
            _ds_bairro = value
        End Set
    End Property
    Public Property id_cidade() As Int32
        Get
            Return _id_cidade
        End Get
        Set(ByVal value As Int32)
            _id_cidade = value
        End Set
    End Property
    Public Property id_estado() As Int32
        Get
            Return _id_estado
        End Get
        Set(ByVal value As Int32)
            _id_estado = value
        End Set
    End Property

    Public Property cd_cep() As String
        Get
            Return _cd_cep
        End Get
        Set(ByVal value As String)
            _cd_cep = value
        End Set
    End Property
    Public Property cd_uf() As String
        Get
            Return _cd_uf
        End Get
        Set(ByVal value As String)
            _cd_uf = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_transit_point_unidade = id
        loadTransitPointUnidade()

    End Sub



    Public Sub New()

    End Sub


    Public Function getTransitPointUnidadeByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransitPointUnidade", parameters, "ms_transit_point_unidade")
            Return dataSet

        End Using

    End Function

    Private Sub loadTransitPointUnidade()

        Dim dataSet As DataSet = getTransitPointUnidadeByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertTransitPointUnidade() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertTransitPointUnidade", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateTransitPointUnidade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateTransitPointUnidade", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteTransitPointUnidade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteTransitPointUnidade", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
