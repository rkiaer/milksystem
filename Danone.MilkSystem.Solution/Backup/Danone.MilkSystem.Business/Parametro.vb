Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Parametro

    Private _id_parametro As Int32
    Private _nr_perc_adto As Decimal
    Private _nr_perc_limite1q_cc As Decimal
    Private _nr_perc_limite2q_cc As Decimal
    Private _nr_deflator As Decimal
    Private _nr_politica_parcelas As Int32 'fran fase 3 08/2014
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_parametro() As Int32
        Get
            Return _id_parametro
        End Get
        Set(ByVal value As Int32)
            _id_parametro = value
        End Set
    End Property
    Public Property nr_politica_parcelas() As Int32
        Get
            Return _nr_politica_parcelas
        End Get
        Set(ByVal value As Int32)
            _nr_politica_parcelas = value
        End Set
    End Property
    Public Property nr_perc_adto() As Decimal
        Get
            Return _nr_perc_adto
        End Get
        Set(ByVal value As Decimal)
            _nr_perc_adto = value
        End Set
    End Property

    Public Property nr_perc_limite1q_cc() As Decimal
        Get
            Return _nr_perc_limite1q_cc
        End Get
        Set(ByVal value As Decimal)
            _nr_perc_limite1q_cc = value
        End Set
    End Property

    Public Property nr_perc_limite2q_cc() As Decimal
        Get
            Return _nr_perc_limite2q_cc
        End Get
        Set(ByVal value As Decimal)
            _nr_perc_limite2q_cc = value
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
    Public Property nr_deflator() As Decimal
        Get
            Return _nr_deflator
        End Get
        Set(ByVal value As Decimal)
            _nr_deflator = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)
        Me.id_parametro = id
        loadParametro()
    End Sub

    Public Sub New()
        loadParametro()

    End Sub


    Public Function getParametros() As DataSet

        Using data As New DataAccess

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getParametros", "ms_parametros")
            Return dataSet

        End Using

    End Function

    Private Sub loadParametro()

        Dim dataSet As DataSet = getParametros()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updateParametro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateParametros", parameters, ExecuteType.Update)

        End Using

    End Sub

End Class
