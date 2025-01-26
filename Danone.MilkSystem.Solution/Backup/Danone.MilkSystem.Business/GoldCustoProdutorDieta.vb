Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GoldCustoProdutorDieta

    Private _id_gold_custo_produtor_dieta As Int32
    Private _id_gold_custo_produtor As Int32
    Private _id_item As Int32
    Private _nr_quantidade As Decimal
    Private _nr_valor_unitario As Decimal
    Private _st_tipo_compra As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_gold_custo_produtor_dieta() As Int32
        Get
            Return _id_gold_custo_produtor_dieta
        End Get
        Set(ByVal value As Int32)
            _id_gold_custo_produtor_dieta = value
        End Set
    End Property
    Public Property id_gold_custo_produtor() As Int32
        Get
            Return _id_gold_custo_produtor
        End Get
        Set(ByVal value As Int32)
            _id_gold_custo_produtor = value
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
    Public Property nr_quantidade() As Decimal
        Get
            Return _nr_quantidade
        End Get
        Set(ByVal value As Decimal)
            _nr_quantidade = value
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


    Public Property st_tipo_compra() As String
        Get
            Return _st_tipo_compra
        End Get
        Set(ByVal value As String)
            _st_tipo_compra = value
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

    Public Sub New()

    End Sub


    Public Function getGoldCustoProdutorDietaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCustoProdutorDieta", parameters, "ms_gold_custo_produtor_dieta")
            Return dataSet

        End Using

    End Function


    Public Sub updateGoldCustoProdutorDieta()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldCustoProdutorDieta", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deleteGoldCustoProdutorDieta()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteGoldCustoProdutorDieta", parameters, ExecuteType.Delete)

        End Using

    End Sub
    Public Function insertGoldCustoProdutorDieta() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertGoldCustoProdutorDieta", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


End Class