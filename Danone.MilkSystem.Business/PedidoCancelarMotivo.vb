Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class PedidoCancelarMotivo


    Private _id_pedido_cancelar_motivo As Int32
    Private _id_situacao As Int32
    Private _nm_pedido_cancelar_motivo As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_pedido_cancelar_motivo() As Int32
        Get
            Return _id_pedido_cancelar_motivo
        End Get
        Set(ByVal value As Int32)
            _id_pedido_cancelar_motivo = value
        End Set
    End Property

    Public Property nm_pedido_cancelar_motivo() As String
        Get
            Return _nm_pedido_cancelar_motivo
        End Get
        Set(ByVal value As String)
            _nm_pedido_cancelar_motivo = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_situacao = id
        loadPedidoCancelarMotivo()

    End Sub

    Public Sub New()

    End Sub

    Public Function getPedidoCancelarMotivoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPedidoCancelarMotivo", parameters, "ms_zpedido_cancelar_motivo")
            Return dataSet

        End Using

    End Function

    Private Sub loadPedidoCancelarMotivo()

        Dim dataSet As DataSet = getPedidoCancelarMotivoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
