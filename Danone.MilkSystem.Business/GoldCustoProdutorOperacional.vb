Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GoldCustoProdutorOperacional

    Private _id_gold_custo_produtor_operacional As Int32
    Private _id_gold_custo_produtor As Int32
    Private _id_gold_custo_produtor_operacional_item As Int32
    Private _nr_custo_operacional As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_gold_custo_produtor_operacional() As Int32
        Get
            Return _id_gold_custo_produtor_operacional
        End Get
        Set(ByVal value As Int32)
            _id_gold_custo_produtor_operacional = value
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
    Public Property id_gold_custo_produtor_operacional_item() As Int32
        Get
            Return _id_gold_custo_produtor_operacional_item
        End Get
        Set(ByVal value As Int32)
            _id_gold_custo_produtor_operacional_item = value
        End Set
    End Property
    Public Property nr_custo_operacional() As Decimal
        Get
            Return _nr_custo_operacional
        End Get
        Set(ByVal value As Decimal)
            _nr_custo_operacional = value
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


    Public Function getGoldCustoProdutorOperacionalByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCustoProdutorOperacional", parameters, "ms_gold_custo_produtor_operacional")
            Return dataSet

        End Using

    End Function

 End Class