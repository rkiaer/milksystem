Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class InterrupcaoFornecimentoPedidos 'fran 20/10/2010 i chamado 860 item 7

    Private _id_central_interrupcao_fornecimento_pedidos As Int32
    Private _id_central_interrupcao_fornecimento As Int32
    Private _id_central_pedido As Int32
    Private _id_situacao_pedido As Int32
    Private _id_central_pedido_notas As Int32
    Private _id_propriedade As Int32
    Private _id_propriedade_matriz As Int32
    Private _st_pagto_fornecedor As String
    Private _nr_saldo_pagto_fornecedor As Decimal
    Private _nr_saldo_desconto_produtor As Decimal
    Private _nr_desconto_calculo As Decimal
    Private _nr_desconto_deposito As Decimal
    Private _nr_pagto_exportacao As Decimal
    Private _nr_pagto_produtor As Decimal
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_central_interrupcao_fornecimento_pedidos() As Int32
        Get
            Return _id_central_interrupcao_fornecimento_pedidos
        End Get
        Set(ByVal value As Int32)
            _id_central_interrupcao_fornecimento_pedidos = value
        End Set
    End Property
    Public Property id_central_interrupcao_fornecimento() As Int32
        Get
            Return _id_central_interrupcao_fornecimento
        End Get
        Set(ByVal value As Int32)
            _id_central_interrupcao_fornecimento = value
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
    Public Property id_central_pedido_notas() As Int32
        Get
            Return _id_central_pedido_notas
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_notas = value
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
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
        End Set
    End Property
    Public Property id_propriedade_matriz() As Int32
        Get
            Return _id_propriedade_matriz
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_matriz = value
        End Set
    End Property
    Public Property st_pagto_fornecedor() As String
        Get
            Return _st_pagto_fornecedor
        End Get
        Set(ByVal value As String)
            _st_pagto_fornecedor = value
        End Set
    End Property
    Public Property nr_saldo_pagto_fornecedor() As Decimal
        Get
            Return _nr_saldo_pagto_fornecedor
        End Get
        Set(ByVal value As Decimal)
            _nr_saldo_pagto_fornecedor = value
        End Set
    End Property
    Public Property nr_saldo_desconto_produtor() As Decimal
        Get
            Return _nr_saldo_desconto_produtor
        End Get
        Set(ByVal value As Decimal)
            _nr_saldo_desconto_produtor = value
        End Set
    End Property
    Public Property nr_desconto_calculo() As Decimal
        Get
            Return _nr_desconto_calculo
        End Get
        Set(ByVal value As Decimal)
            _nr_desconto_calculo = value
        End Set
    End Property
    Public Property nr_desconto_deposito() As Decimal
        Get
            Return _nr_desconto_deposito
        End Get
        Set(ByVal value As Decimal)
            _nr_desconto_deposito = value
        End Set
    End Property
    Public Property nr_pagto_exportacao() As Decimal
        Get
            Return _nr_pagto_exportacao
        End Get
        Set(ByVal value As Decimal)
            _nr_pagto_exportacao = value
        End Set
    End Property
    Public Property nr_pagto_produtor() As Decimal
        Get
            Return _nr_pagto_produtor
        End Get
        Set(ByVal value As Decimal)
            _nr_pagto_produtor = value
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

    Public Sub New(ByVal id As Int32)

        Me.id_central_interrupcao_fornecimento_pedidos = id
        loadCentralInterrupcaoFornecimentoPedidos()

    End Sub

    Public Sub New()

    End Sub
    Public Function getInterrupcaoFornecimentoPedidosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralInterrupcaoFornecimentoPedidos", parameters, "ms_central_pedido")
            Return dataSet

        End Using
    End Function
    Private Sub loadCentralInterrupcaoFornecimentoPedidos()

        Dim dataSet As DataSet = getInterrupcaoFornecimentoPedidosByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertInterrupcaoFornecimentoPedidos() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralInterrupcaoPedidos", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub updateInterrupcaoFornecimentoPedidosNota()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralInterrupcaoPedidosNota", parameters, ExecuteType.Update)

        End Using

    End Sub

End Class
