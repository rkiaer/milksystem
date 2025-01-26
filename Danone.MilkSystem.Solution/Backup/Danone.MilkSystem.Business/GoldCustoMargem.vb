Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GoldCustoMargem

    Private _id_gold_custo As Int32

    ' Para update/insert de uma lnha da tabela
    Private _nr_margem As Decimal
    Private _id_gold_faixa_custo As Int32
    Private _id_gold_custo_margem As Int32  ' Para o Update

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
    Public Property nr_margem() As Decimal
        Get
            Return _nr_margem
        End Get
        Set(ByVal value As Decimal)
            _nr_margem = value
        End Set
    End Property
    Public Property id_gold_faixa_custo() As Int32
        Get
            Return _id_gold_faixa_custo
        End Get
        Set(ByVal value As Int32)
            _id_gold_faixa_custo = value
        End Set
    End Property
    Public Property id_gold_custo_margem() As Int32
        Get
            Return _id_gold_custo_margem
        End Get
        Set(ByVal value As Int32)
            _id_gold_custo_margem = value
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


    Public Function getGoldCustoMargem() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCustoMargem", parameters, "ms_gold_custo_margem")
            Return dataSet

        End Using

    End Function

End Class