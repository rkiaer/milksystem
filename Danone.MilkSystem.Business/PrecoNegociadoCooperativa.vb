Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PrecoNegociadoCooperativa

    Private _id_preco_negociado_cooperativa As Int32
    Private _id_estabelecimento As Int32
    Private _ds_estabelecimento As String
    Private _cd_pessoa As String
    Private _ds_produtor As String
    Private _id_pessoa As Int32
    Private _nm_propriedade As String
    Private _dt_referencia As String
    Private _ds_referencia As String
    Private _nr_ano As String
    Private _nr_preco_negociado_1q As Decimal
    Private _nr_preco_negociado_2q As Decimal
    Private _nr_valor_frete As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nr_periodo As Int32
    Private _nr_preco_negociado As Decimal
    Private _nr_volume As Decimal
    Private _st_aprovado As String
    Private _st_selecao As String

    Public Property id_preco_negociado_cooperativa() As Int32
        Get
            Return _id_preco_negociado_cooperativa
        End Get
        Set(ByVal value As Int32)
            _id_preco_negociado_cooperativa = value
        End Set
    End Property
    Public Property nr_periodo() As Int32
        Get
            Return _nr_periodo
        End Get
        Set(ByVal value As Int32)
            _nr_periodo = value
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

    Public Property ds_estabelecimento() As String
        Get
            Return _ds_estabelecimento
        End Get
        Set(ByVal value As String)
            _ds_estabelecimento = value
        End Set
    End Property
    Public Property st_aprovado() As String
        Get
            Return _st_aprovado
        End Get
        Set(ByVal value As String)
            _st_aprovado = value
        End Set
    End Property
    Public Property st_selecao() As String
        Get
            Return _st_selecao
        End Get
        Set(ByVal value As String)
            _st_selecao = value
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

    Public Property ds_produtor() As String
        Get
            Return _ds_produtor
        End Get
        Set(ByVal value As String)
            _ds_produtor = value
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

    Public Property nm_propriedade() As String
        Get
            Return _nm_propriedade
        End Get
        Set(ByVal value As String)
            _nm_propriedade = value
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

    Public Property ds_referencia() As String
        Get
            Return _ds_referencia
        End Get
        Set(ByVal value As String)
            _ds_referencia = value
        End Set
    End Property

    Public Property nr_ano() As String
        Get
            Return _nr_ano
        End Get
        Set(ByVal value As String)
            _nr_ano = value
        End Set
    End Property


    Public Property nr_preco_negociado_1q() As Decimal
        Get
            Return _nr_preco_negociado_1q
        End Get
        Set(ByVal value As Decimal)
            _nr_preco_negociado_1q = value
        End Set
    End Property

    Public Property nr_preco_negociado_2q() As Decimal
        Get
            Return _nr_preco_negociado_2q
        End Get
        Set(ByVal value As Decimal)
            _nr_preco_negociado_2q = value
        End Set
    End Property

    Public Property nr_valor_frete() As Decimal
        Get
            Return _nr_valor_frete
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_frete = value
        End Set
    End Property
    Public Property nr_preco_negociado() As Decimal
        Get
            Return _nr_preco_negociado
        End Get
        Set(ByVal value As Decimal)
            _nr_preco_negociado = value
        End Set
    End Property

    Public Property nr_volume() As Decimal
        Get
            Return _nr_volume
        End Get
        Set(ByVal value As Decimal)
            _nr_volume = value
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

        Me._id_preco_negociado_cooperativa = id
        loadPrecoNegociadoCooperativa()

    End Sub

    Public Sub New()

    End Sub

    Public Function getPrecoNegociadoCooperativaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPrecosNegociadosCooperativas", parameters, "ms_preco_negociado_cooperativa")
            Return dataSet

        End Using

    End Function

    Private Sub loadPrecoNegociadoCooperativa()

        Dim dataSet As DataSet = getPrecoNegociadoCooperativaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertPrecoNegociadoCooperativa() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPrecosNegociadosCooperativas", parameters, ExecuteType.Insert), Int32)

        End Using

    End Function

    Public Sub updatePrecoNegociadoCooperativa()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePrecosNegociadosCooperativas", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deletePrecoNegociadoCooperativa()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deletePrecosNegociadosCooperativas", parameters, ExecuteType.Delete)

        End Using

    End Sub
    Public Function getPrecoNegociadoCooperativaTotalizador() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPrecosNegociadosCooperativasTotalizador", parameters, "ms_preco_negociado_cooperativa")
            Return dataSet

        End Using

    End Function
    Public Sub updatePrecoNegociadoCooperativaSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePrecosNegociadosCooperativaSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePrecoNegociadoCooperativaAprovarSelecionados()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePrecoNegociadoCooperativaAprovarSelecionados", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePrecoNegociadoCooperativaTodos2N()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePrecosNegociadosCooperativaTodos2N", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
