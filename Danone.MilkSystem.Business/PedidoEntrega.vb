Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class PedidoEntrega

    Private _id_central_pedido_entrega As Int32
    Private _id_central_pedido_item As Int32
    Private _nr_parcela As Int32
    Private _dt_entrega_prevista As String
    Private _nr_quantidade_prevista As Decimal
    Private _dt_entrega_real As String
    Private _nr_quantidade_real As Decimal
    Private _id_modificador As Int32
    Private _dt_modificacao As String


    Public Property id_central_pedido_entrega() As Int32
        Get
            Return _id_central_pedido_entrega
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_entrega = value
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
    Public Property dt_entrega_prevista() As String
        Get
            Return _dt_entrega_prevista
        End Get
        Set(ByVal value As String)
            _dt_entrega_prevista = value
        End Set
    End Property
    Public Property nr_quantidade_prevista() As Decimal
        Get
            Return _nr_quantidade_prevista
        End Get
        Set(ByVal value As Decimal)
            _nr_quantidade_prevista = value
        End Set
    End Property
    Public Property dt_entrega_real() As String
        Get
            Return _dt_entrega_real
        End Get
        Set(ByVal value As String)
            _dt_entrega_real = value
        End Set
    End Property
    Public Property nr_quantidade_real() As Decimal
        Get
            Return _nr_quantidade_real
        End Get
        Set(ByVal value As Decimal)
            _nr_quantidade_real = value
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

        Me.id_central_pedido_entrega = id
        loadPedidoEntrega()

    End Sub

    Public Sub New()

    End Sub
    Public Function getPedidoEntregaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoEntrega", parameters, "ms_central_pedido_entrega")
            Return dataSet

        End Using

    End Function

    Private Sub loadPedidoEntrega()

        Dim dataSet As DataSet = getPedidoEntregaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertPedidoCentralEntrega() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralPedidoEntrega", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updatePedidoEntrega()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoEntrega", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deletePedidoEntrega()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralPedidoEntrega", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function getCentralPedidoEntregaPrimeiraData() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralPedidoEntregaPrimeiraData", parameters, ExecuteType.Select), String)

        End Using
    End Function

End Class
