Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class PedidoItem

    Private _id_central_pedido As Int32
    Private _id_central_pedido_item As Int32
    Private _id_central_cotacao_fornecedor As Int32
    Private _id_item As Int32
    Private _cd_item As String
    Private _nm_item As String
    Private _nr_quantidade As Decimal
    Private _nr_parcelas As Int32
    Private _st_parcelamento As String 'fase 3
    Private _st_alteracao As String
    Private _ds_tipo_medida As String
    Private _nr_valor_unitario As Decimal
    Private _nr_sacaria As Decimal
    Private _nr_frete As Decimal
    Private _nr_perc_icms As Decimal
    Private _nr_valor_total As Decimal
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_central_prazo_pagto As Int32
    Private _nr_valor_fornecedor As Decimal
    Private _id_central_tabela_preco As Int32
    Private _id_central_tabela_frete_veiculos As Int32
    Private _ds_tipo_frete As String
    Private _id_central_pedido_transportador As Int32
    Private _id_situacao_pedido As Int32
    Private _ds_motivo_aprovacao As String
    Private _id_fornecedor As Int32

    Public Property id_central_pedido() As Int32
        Get
            Return _id_central_pedido
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido = value
        End Set
    End Property
    Public Property id_central_tabela_preco() As Int32
        Get
            Return _id_central_tabela_preco
        End Get
        Set(ByVal value As Int32)
            _id_central_tabela_preco = value
        End Set
    End Property
    Public Property id_central_tabela_frete_veiculos() As Int32
        Get
            Return _id_central_tabela_frete_veiculos
        End Get
        Set(ByVal value As Int32)
            _id_central_tabela_frete_veiculos = value
        End Set
    End Property
    Public Property id_central_pedido_transportador() As Int32
        Get
            Return _id_central_pedido_transportador
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_transportador = value
        End Set
    End Property
    Public Property id_situacao_pedido() As Int32
        Get
            Return _id_situacao_pedido
        End Get
        Set(ByVal value As Int32)
            _id_situacao_pedido = value
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
    Public Property ds_motivo_aprovacao() As String
        Get
            Return _ds_motivo_aprovacao
        End Get
        Set(ByVal value As String)
            _ds_motivo_aprovacao = value
        End Set
    End Property
    Public Property id_central_pedido_item() As Int32
        Get
            Return _id_central_pedido_item
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_item = value
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
    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
        End Set
    End Property
    Public Property cd_item() As String
        Get
            Return _cd_item
        End Get
        Set(ByVal value As String)
            _cd_item = value
        End Set
    End Property
    Public Property nm_item() As String
        Get
            Return _nm_item
        End Get
        Set(ByVal value As String)
            _nm_item = value
        End Set
    End Property
    Public Property nr_quantidade() As Decimal
        Get
            Return _nr_quantidade
        End Get
        Set(ByVal value As Decimal)
            _nr_quantidade = value
        End Set
    End Property
    Public Property nr_parcelas() As Int32
        Get
            Return _nr_parcelas
        End Get
        Set(ByVal value As Int32)
            _nr_parcelas = value
        End Set
    End Property
    Public Property st_parcelamento() As String
        Get
            Return _st_parcelamento
        End Get
        Set(ByVal value As String)
            _st_parcelamento = value
        End Set
    End Property
    Public Property ds_tipo_medida() As String
        Get
            Return _ds_tipo_medida
        End Get
        Set(ByVal value As String)
            _ds_tipo_medida = value
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
    Public Property st_alteracao() As String
        Get
            Return _st_alteracao
        End Get
        Set(ByVal value As String)
            _st_alteracao = value
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
    Public Property nr_valor_fornecedor() As Decimal
        Get
            Return _nr_valor_fornecedor
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_fornecedor = value
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
    Public Property nr_perc_icms() As Decimal
        Get
            Return _nr_perc_icms
        End Get
        Set(ByVal value As Decimal)
            _nr_perc_icms = value
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
    Public Property id_central_prazo_pagto() As Int32
        Get
            Return _id_central_prazo_pagto
        End Get
        Set(ByVal value As Int32)
            _id_central_prazo_pagto = value
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
    Public Sub New(ByVal id As Int32)

        Me.id_central_pedido_item = id
        loadPedidoItem()

    End Sub

    Public Sub New()

    End Sub
    Public Function getPedidoItensByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoItem", parameters, "ms_central_pedido_item")
            Return dataSet

        End Using

    End Function

    Private Sub loadPedidoItem()

        Dim dataSet As DataSet = getPedidoItensByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertPedidoItem() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralPedidoItem", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updatePedidoItem()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoItem", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePedidoItemParcelamento() 'fran 08/2015

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoItemParcelamento", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePedidoItemParcelas() 'fran 08/2015

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoItemParcelas", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub deletePedidoItem()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralPedidoItem", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub updatePedidoItemValor()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoItemValor", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updatePedidoItemValorFornecedor()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoItemValorFornecedor", parameters, ExecuteType.Update)

        End Using
    End Sub

End Class
