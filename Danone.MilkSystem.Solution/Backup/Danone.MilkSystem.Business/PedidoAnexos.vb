Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PedidoAnexos
    Private _id_central_pedido_anexos As Int32
    Private _id_central_pedido As Int32
    Private _id_central_pedido_notas As Int32
    Private _id_central_pedido_desconto_produtor As Int32
    Private _id_central_pedido_pagto_fornecedor As Int32
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_documento As String
    Private _nr_valor As Decimal
    Private _st_origem As String
    Private _nm_documento As String
    Private _nm_extensao As String
    Private _nm_arquivo As String
    Private _st_obrigatorio As String
    Private _nr_tamanho As Integer
    Private _varbin_documento As Byte
    Private _dt_modificacao As String

    Public Property id_central_pedido_anexos() As Int32
        Get
            Return _id_central_pedido_anexos
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_anexos = value
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
    Public Property id_central_pedido_desconto_produtor() As Int32
        Get
            Return _id_central_pedido_desconto_produtor
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_desconto_produtor = value
        End Set
    End Property
    Public Property id_central_pedido_pagto_fornecedor() As Integer
        Get
            Return _id_central_pedido_pagto_fornecedor
        End Get
        Set(ByVal value As Integer)
            _id_central_pedido_pagto_fornecedor = value
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
    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
        End Set
    End Property
    Public Property dt_documento() As String
        Get
            Return _dt_documento
        End Get
        Set(ByVal value As String)
            _dt_documento = value
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
    Public Property st_origem() As String
        Get
            Return _st_origem
        End Get
        Set(ByVal value As String)
            _st_origem = value
        End Set
    End Property
    Public Property nm_documento() As String
        Get
            Return _nm_documento
        End Get
        Set(ByVal value As String)
            _nm_documento = value
        End Set
    End Property
    Public Property nm_extensao() As String
        Get
            Return _nm_extensao
        End Get
        Set(ByVal value As String)
            _nm_extensao = value
        End Set
    End Property
    Public Property nm_arquivo() As String
        Get
            Return _nm_arquivo
        End Get
        Set(ByVal value As String)
            _nm_arquivo = value
        End Set
    End Property
    Public Property st_obrigatorio() As String
        Get
            Return _st_obrigatorio
        End Get
        Set(ByVal value As String)
            _st_obrigatorio = value
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
    Public Property varbin_documento() As Byte
        Get
            Return _varbin_documento
        End Get
        Set(ByVal value As Byte)
            _varbin_documento = value
        End Set
    End Property
    Public Property nr_tamanho() As Int32
        Get
            Return _nr_tamanho
        End Get
        Set(ByVal value As Int32)
            _nr_tamanho = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)
        Me.id_central_pedido_anexos = id
        loadPedidoAnexos()
    End Sub

    Public Sub New()

    End Sub


    Public Function getPedidoAnexos() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getCentralPedidoAnexos", parameters, "ms_central_pedido_anexos")
            Return dataSet

        End Using

    End Function
    Private Sub loadPedidoAnexos()

        Dim dataSet As DataSet = getPedidoAnexos()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Sub deletePedidoAnexos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralPedidoAnexos", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function insertPedidosAnexo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralPedidoAnexos", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
End Class
