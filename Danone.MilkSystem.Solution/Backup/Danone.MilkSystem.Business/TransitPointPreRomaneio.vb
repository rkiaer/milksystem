Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math
Imports System.Data


<Serializable()> Public Class TransitPointPreRomaneio

    Private _id_transit_point_pre_romaneio As Int32
    Private _id_transit_point As Int32
    Private _id_pre_romaneio As Int32
    Private _nr_total_litros As Decimal
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String

    Public Property id_transit_point() As Int32
        Get
            Return _id_transit_point
        End Get
        Set(ByVal value As Int32)
            _id_transit_point = value
        End Set
    End Property
    Public Property id_transit_point_pre_romaneio() As Int32
        Get
            Return _id_transit_point_pre_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_transit_point_pre_romaneio = value
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

    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
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
    Public Property id_pre_romaneio() As Int32
        Get
            Return _id_pre_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_pre_romaneio = value
        End Set
    End Property
    Public Property nr_total_litros() As Decimal
        Get
            Return _nr_total_litros
        End Get
        Set(ByVal value As Decimal)
            _nr_total_litros = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Int32)

        Me._id_transit_point_pre_romaneio = id
        loadTransitPointPreRomaneio()

    End Sub

    Public Function getTransitPointPreRomaneioByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransitPointPreRomaneio", parameters, "ms_transit_point_pre_romaneio")
            Return dataSet

        End Using

    End Function


    Private Sub loadTransitPointPreRomaneio()

        Dim dataSet As DataSet = getTransitPointPreRomaneioByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertTransitPointPreRomaneio() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertTransitPointPreRomaneio", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Sub deleteTransitPointPreRomaneio()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteTransitPointPreRomaneio", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub updateTransitPointPreRomaneio()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateTransitPointPreRomaneio", parameters, ExecuteType.Update)

        End Using

    End Sub
  

End Class
