Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class PedidoDescontoProdutor

    Private _id_central_pedido_desconto_produtor As Int32
    Private _id_central_pedido_item As Int32
    Private _id_central_pedido_notas As Int32
    Private _nr_parcela As Int32
    Private _nr_nota_fiscal As Int32
    Private _nr_valor_nota_fiscal As Decimal
    Private _dt_pagto As String
    Private _dt_acerto As String
    Private _nr_valor_parcela As Decimal
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nr_mais_solidos_valor_utilizado As Decimal
    Private _st_mais_solidos As String
    Private _id_central_pedido As Int32
    Private _st_tipo_desconto As String

    Public Property id_central_pedido_notas() As Int32
        Get
            Return _id_central_pedido_notas
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_notas = value
        End Set
    End Property

    Public Property id_central_pedido() As Int32
        Get
            Return _id_central_pedido
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido = value
        End Set
    End Property
    Public Property id_central_pedido_desconto_produtor() As Int32
        Get
            Return _id_central_pedido_desconto_produtor
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_desconto_produtor = value
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
    Public Property nr_parcela() As Int32
        Get
            Return _nr_parcela
        End Get
        Set(ByVal value As Int32)
            _nr_parcela = value
        End Set
    End Property
    Public Property dt_pagto() As String
        Get
            Return _dt_pagto
        End Get
        Set(ByVal value As String)
            _dt_pagto = value
        End Set
    End Property
    Public Property dt_acerto() As String
        Get
            Return _dt_acerto
        End Get
        Set(ByVal value As String)
            _dt_acerto = value
        End Set
    End Property
    Public Property st_tipo_desconto() As String
        Get
            Return _st_tipo_desconto
        End Get
        Set(ByVal value As String)
            _st_tipo_desconto = value
        End Set
    End Property
    Public Property nr_valor_parcela() As Decimal
        Get
            Return _nr_valor_parcela
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_parcela = value
        End Set
    End Property
    Public Property nr_valor_nota_fiscal() As Decimal
        Get
            Return _nr_valor_nota_fiscal
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nota_fiscal = value
        End Set
    End Property
    Public Property nr_nota_fiscal() As Int32
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As Int32)
            _nr_nota_fiscal = value
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
    Public Property st_mais_solidos() As String
        Get
            Return _st_mais_solidos
        End Get
        Set(ByVal value As String)
            _st_mais_solidos = value
        End Set
    End Property
    Public Property nr_mais_solidos_valor_utilizado() As Decimal
        Get
            Return _nr_mais_solidos_valor_utilizado
        End Get
        Set(ByVal value As Decimal)
            _nr_mais_solidos_valor_utilizado = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_central_pedido_desconto_produtor = id
        loadPedidoDescontoProdutor()

    End Sub

    Public Sub New()

    End Sub
    Public Function getPedidoDescontoProdutorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoDescontoProdutor", parameters, "ms_central_pedido_desconto_produtor")
            Return dataSet

        End Using

    End Function

    Private Sub loadPedidoDescontoProdutor()

        Dim dataSet As DataSet = getPedidoDescontoProdutorByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertPedidoCentralDescontoProdutor() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralPedidoDescontoProdutor", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub updatePedidoDescontoProdutorAcerto()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoDescontoProdutorAcerto", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updatePedidoDescontoProdutor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoDescontoProdutor", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updatePedidoDescontoProdutorNotaData()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoDescontoProdutor_NotaData", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub deletePedidoDescontoProdutor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralPedidoDescontoProdutor", parameters, ExecuteType.Delete)

        End Using


    End Sub
    'fran 15/05/2012 i themis
    Public Function getPedidoDescontoProdutorCalculado() As Int64
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralPedidoDescontoProdutorCalculado", parameters, ExecuteType.Select), Int64)

        End Using
    End Function
    Public Function getDescontoProdutorMaxParcela() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralPedidoDescProdutorMaxParcela", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Function getCentralPedidoDescontoProdutorNotas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoDescontoProdutorNotas", parameters, "ms_central_pedido_desconto_produtor")
            Return dataSet

        End Using

    End Function

    Public Sub updatePedidoDescontoProdutorMaisSolidos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoDescontoProdutorMaisSolidos", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
