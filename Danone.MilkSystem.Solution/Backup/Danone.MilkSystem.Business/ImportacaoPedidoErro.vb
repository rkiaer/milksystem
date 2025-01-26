Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ImportacaoPedidoErro

    Private _id_importacao_pedido_erro As Int32
    Private _id_importacao_pedido As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_importacao_log As Int32


    Public Property id_importacao_pedido_erro() As Int32
        Get
            Return _id_importacao_pedido_erro
        End Get
        Set(ByVal value As Int32)
            _id_importacao_pedido_erro = value
        End Set
    End Property
    Public Property id_importacao_pedido() As Int32
        Get
            Return _id_importacao_pedido
        End Get
        Set(ByVal value As Int32)
            _id_importacao_pedido = value
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
    Public Property id_importacao_log() As Int32
        Get
            Return _id_importacao_log
        End Get
        Set(ByVal value As Int32)
            _id_importacao_log = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_importacao_pedido_erro = id
        loadImportacaoPedidoErro()

    End Sub



    Public Sub New()

    End Sub


    Public Function getImportacaoPedidoErroByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getImportacaoPedidoErro", parameters, "ms_importacao_pagto_transportador_erro")
            Return dataSet

        End Using

    End Function

    Private Sub loadImportacaoPedidoErro()

        Dim dataSet As DataSet = getImportacaoPedidoErroByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertImportacaoPedidoErro() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertImportacaoPedidoErro", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateImportacaoPedidoErro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateImportacaoPedidoErro", parameters, ExecuteType.Update)

        End Using

    End Sub


End Class
