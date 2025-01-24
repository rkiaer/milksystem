Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class CotacaoFornecedor

    Private _id_central_cotacao As Int32
    Private _id_central_cotacao_item As Int32
    Private _id_central_cotacao_fornecedor As Int32
    Private _id_fornecedor As Int32
    Private _cd_fornecedor As String
    Private _nm_fornecedor As String
    Private _nm_abreviado_fornecedor As String
    Private _nr_valor_unitario As Decimal
    Private _nr_sacaria As Decimal
    Private _nr_frete As Decimal
    Private _ds_tipo_frete As String
    Private _nr_perc_icms As Decimal
    Private _nr_valor_total As Decimal
    Private _st_selecionado As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _st_ver_mercado As String
    Private _dt_entrega As String 'fran chamado 602
    Private _id_transportador As Int32
    Private _id_item As Int32 'fran chamado 1080
    Private _cd_transportador As String
    Private _nm_transportador As String
    Private _nm_abreviado_transportador As String


    Public Property id_central_cotacao() As Int32
        Get
            Return _id_central_cotacao
        End Get
        Set(ByVal value As Int32)
            _id_central_cotacao = value
        End Set
    End Property
    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
        End Set
    End Property
    Public Property id_central_cotacao_item() As Int32
        Get
            Return _id_central_cotacao_item
        End Get
        Set(ByVal value As Int32)
            _id_central_cotacao_item = value
        End Set
    End Property
    Public Property id_central_cotacao_fornecedor() As Int32
        Get
            Return _id_central_cotacao_fornecedor
        End Get
        Set(ByVal value As Int32)
            _id_central_cotacao_fornecedor = value
        End Set
    End Property
    Public Property id_fornecedor() As Int32
        Get
            Return _id_fornecedor
        End Get
        Set(ByVal value As Int32)
            _id_fornecedor = value
        End Set
    End Property
    Public Property cd_fornecedor() As String
        Get
            Return _cd_fornecedor
        End Get
        Set(ByVal value As String)

            _cd_fornecedor = value
        End Set
    End Property
    Public Property dt_entrega() As String
        Get
            Return _dt_entrega
        End Get
        Set(ByVal value As String)

            _dt_entrega = value
        End Set
    End Property
    Public Property st_ver_mercado() As String
        Get
            Return _st_ver_mercado
        End Get
        Set(ByVal value As String)
            _st_ver_mercado = value
        End Set
    End Property
    Public Property nm_fornecedor() As String
        Get
            Return _nm_fornecedor
        End Get
        Set(ByVal value As String)
            _nm_fornecedor = value
        End Set
    End Property
    Public Property nm_abreviado_fornecedor() As String
        Get
            Return _nm_abreviado_fornecedor
        End Get
        Set(ByVal value As String)
            _nm_abreviado_fornecedor = value
        End Set
    End Property
    Public Property nr_valor_unitario() As Decimal
        Get
            Return _nr_valor_unitario
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_unitario = value
        End Set
    End Property
    Public Property nr_valor_total() As Decimal
        Get
            Return _nr_valor_total
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_total = value
        End Set
    End Property
    Public Property nr_sacaria() As Decimal
        Get
            Return _nr_sacaria
        End Get
        Set(ByVal value As Decimal)
            _nr_sacaria = value
        End Set
    End Property
    Public Property nr_frete() As Decimal
        Get
            Return _nr_frete
        End Get
        Set(ByVal value As Decimal)
            _nr_frete = value
        End Set
    End Property
    Public Property ds_tipo_frete() As String
        Get
            Return _ds_tipo_frete
        End Get
        Set(ByVal value As String)
            _ds_tipo_frete = value
        End Set
    End Property
    Public Property nr_perc_icms() As Decimal
        Get
            Return _nr_perc_icms
        End Get
        Set(ByVal value As Decimal)
            _nr_perc_icms = value
        End Set
    End Property
    Public Property st_selecionado() As String
        Get
            Return _st_selecionado
        End Get
        Set(ByVal value As String)
            _st_selecionado = value
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
    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
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
    Public Property nm_abreviado_transportador() As String
        Get
            Return _nm_abreviado_transportador
        End Get
        Set(ByVal value As String)
            _nm_abreviado_transportador = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_central_cotacao_fornecedor = id
        loadCotacaoFornecedor()

    End Sub

    Public Sub New()

    End Sub
    Public Function getCotacaoFornecedorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralCotacaoFornecedores", parameters, "ms_central_cotacao_fornecedor")
            Return dataSet

        End Using

    End Function

    Private Sub loadCotacaoFornecedor()

        Dim dataSet As DataSet = getCotacaoFornecedorByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertCotacaoFornecedor() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralCotacaoFornecedor", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateCotacaoFornecedor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacaoFornecedor", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCotacaoFornecedorSelecionado()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacaoFornecedorSelecionado", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deleteCotacaoFornecedor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralCotacaoFornecedor", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
