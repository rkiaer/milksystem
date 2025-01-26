Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class PedidoNotas

    Private _id_central_pedido_notas As Int32
    Private _id_central_pedido As Int32
    Private _id_central_notas_importacao As Int32
    Private _nr_nota_fiscal As Int32
    Private _nr_serie As String
    Private _dt_emissao As String
    Private _nr_valor_nf As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Public Property id_central_pedido_notas() As Int32
        Get
            Return _id_central_pedido_notas
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_notas = value
        End Set
    End Property
    Public Property id_central_notas_importacao() As Int32
        Get
            Return _id_central_notas_importacao
        End Get
        Set(ByVal value As Int32)
            _id_central_notas_importacao = value
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
    Public Property nr_nota_fiscal() As Int32
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As Int32)
            _nr_nota_fiscal = value
        End Set
    End Property
    Public Property nr_serie() As String
        Get
            Return _nr_serie
        End Get
        Set(ByVal value As String)
            _nr_serie = value
        End Set
    End Property
    Public Property dt_emissao() As String
        Get
            Return _dt_emissao
        End Get
        Set(ByVal value As String)
            _dt_emissao = value
        End Set
    End Property
    Public Property nr_valor_nf() As Decimal
        Get
            Return _nr_valor_nf
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nf = value
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

        Me.id_central_pedido_notas = id
        loadPedidoNotas()

    End Sub

    Public Sub New()

    End Sub

 
     Private Sub loadPedidoNotas()

        Dim dataSet As DataSet = getPedidoNotasByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertCentralPedidoNotas() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralPedidoNotas", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub deleteCentralPedidoNotas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralPedidoNotas", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Function getPedidoNotasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoNotas", parameters, "ms_central_pedido_notas")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoNotasCombo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoNotasCombo", parameters, "ms_central_pedido_notas")
            Return dataSet

        End Using

    End Function


End Class
