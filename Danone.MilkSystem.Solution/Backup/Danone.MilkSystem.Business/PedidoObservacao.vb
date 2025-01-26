Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class PedidoObservacao

    Private _id_central_pedido_observacao As Int32
    Private _id_central_pedido As Int32
    Private _dt_criacao As String
    Private _ds_observacao As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String


    Public Property id_central_pedido_observacao() As Int32
        Get
            Return _id_central_pedido_observacao
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_observacao = value
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
    
    Public Property ds_observacao() As String
        Get
            Return _ds_observacao
        End Get
        Set(ByVal value As String)
            _ds_observacao = value
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
    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_central_pedido_observacao = id
        loadPedidoObservacao()

    End Sub

    Public Sub New()

    End Sub
    Public Function getPedidoObservacaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoObservacao", parameters, "ms_central_pedido_observacao")
            Return dataSet

        End Using

    End Function

    Private Sub loadPedidoObservacao()

        Dim dataSet As DataSet = getPedidoObservacaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertPedidoCentralObservacao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralPedidoObservacao", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updatePedidoObservacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoObservacao", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deletePedidoObservacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralPedidoObservacao", parameters, ExecuteType.Delete)

        End Using


    End Sub
   

End Class
