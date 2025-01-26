Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GoldCustoVolume

    Private _id_gold_custo As Int32

    Private _nr_adicional_volume As Decimal
    Private _id_gold_faixa_volume As Int32
    Private _id_gold_custo_volume As Int32  ' Para o Update

    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_gold_custo() As Int32
        Get
            Return _id_gold_custo
        End Get
        Set(ByVal value As Int32)
            _id_gold_custo = value
        End Set
    End Property
    Public Property nr_adicional_volume() As Decimal
        Get
            Return _nr_adicional_volume
        End Get
        Set(ByVal value As Decimal)
            _nr_adicional_volume = value
        End Set
    End Property
    Public Property id_gold_faixa_volume() As Int32
        Get
            Return _id_gold_faixa_volume
        End Get
        Set(ByVal value As Int32)
            _id_gold_faixa_volume = value
        End Set
    End Property
    Public Property id_gold_custo_volume() As Int32
        Get
            Return _id_gold_custo_volume
        End Get
        Set(ByVal value As Int32)
            _id_gold_custo_volume = value
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


    Public Function getGoldCustoVolume() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCustoVolume", parameters, "ms_gold_custo_volume")
            Return dataSet

        End Using

    End Function
 End Class