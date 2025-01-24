Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class FreteLancamento

    Private _id_frete_lancamento As Int32
    Private _id_frete_conta As Int32
    Private _cd_frete_conta As String
    Private _nm_frete_conta As String
    Private _id_estabelecimento As Int32
    Private _id_cooperativa As Int32
    Private _id_romaneio As Int32
    Private _id_linha As Int32
    Private _st_todos_romaneios As Int32
    Private _st_todas_rotas As Int32
    Private _id_tipo_frete As Int32
    Private _nr_valor As Decimal
    Private _dt_referencia As String
    Private _id_frete_periodo As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_transportador As Int32
    Private _cd_transportador As String
    Private _nm_transportador As String
    Private _id_importacao As Int32
    Private _id_tipo_equipamento As Int32
    Public Property id_frete_lancamento() As Int32
        Get
            Return _id_frete_lancamento
        End Get
        Set(ByVal value As Int32)
            _id_frete_lancamento = value
        End Set
    End Property
    Public Property id_importacao() As Int32
        Get
            Return _id_importacao
        End Get
        Set(ByVal value As Int32)
            _id_importacao = value
        End Set
    End Property
    Public Property id_frete_conta() As Int32
        Get
            Return _id_frete_conta
        End Get
        Set(ByVal value As Int32)
            _id_frete_conta = value
        End Set
    End Property
    Public Property cd_frete_conta() As String
        Get
            Return _cd_frete_conta
        End Get
        Set(ByVal value As String)
            _cd_frete_conta = value
        End Set
    End Property
    Public Property nm_frete_conta() As String
        Get
            Return _nm_frete_conta
        End Get
        Set(ByVal value As String)
            _nm_frete_conta = value
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
    Public Property id_cooperativa() As Int32
        Get
            Return _id_cooperativa
        End Get
        Set(ByVal value As Int32)
            _id_cooperativa = value
        End Set
    End Property
    Public Property id_romaneio() As Int32
        Get
            Return _id_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_romaneio = value
        End Set
    End Property
    Public Property id_linha() As Int32
        Get
            Return _id_linha
        End Get
        Set(ByVal value As Int32)
            _id_linha = value
        End Set
    End Property
    Public Property id_tipo_frete() As Int32
        Get
            Return _id_tipo_frete
        End Get
        Set(ByVal value As Int32)
            _id_tipo_frete = value
        End Set
    End Property
    Public Property id_frete_periodo() As Int32
        Get
            Return _id_frete_periodo
        End Get
        Set(ByVal value As Int32)
            _id_frete_periodo = value
        End Set
    End Property
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property
    Public Property nr_valor() As Decimal
        Get
            Return _nr_valor
        End Get
        Set(ByVal value As Decimal)
            _nr_valor = value
        End Set
    End Property
    Public Property cd_transportador() As String
        Get
            Return _cd_transportador
        End Get
        Set(ByVal value As String)
            _cd_transportador = value
        End Set
    End Property
    Public Property nm_transportador() As String
        Get
            Return _nm_transportador
        End Get
        Set(ByVal value As String)
            _nm_transportador = value
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
    Public Property id_transportador() As Int32
        Get
            Return _id_transportador
        End Get
        Set(ByVal value As Int32)
            _id_transportador = value
        End Set
    End Property
    Public Property id_tipo_equipamento() As Int32
        Get
            Return _id_tipo_equipamento
        End Get
        Set(ByVal value As Int32)
            _id_tipo_equipamento = value
        End Set
    End Property
    Public Property st_todos_romaneios() As Int32
        Get
            Return _st_todos_romaneios
        End Get
        Set(ByVal value As Int32)
            _st_todos_romaneios = value
        End Set
    End Property
    Public Property st_todas_rotas() As Int32
        Get
            Return _st_todas_rotas
        End Get
        Set(ByVal value As Int32)
            _st_todas_rotas = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me._id_frete_lancamento = id
        loadFreteLancamento()

    End Sub

    Public Sub New()

    End Sub


    Public Function getFreteLancamentoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFreteLancamento", parameters, "ms_frete_lancamento")
            Return dataSet

        End Using

    End Function

    Private Sub loadFreteLancamento()

        Dim dataSet As DataSet = getFreteLancamentoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertFreteLancamento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertFreteLancamento", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateLancamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFreteLancamento", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteFreteLancamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteFreteLancamento", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
