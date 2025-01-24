Imports System
Imports System.data
Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports Danone.MilkSystem.Business

Public Class ExportaAnalise
    Private _dt_inicio As String
    Private _dt_fim As String
    'fran 27/11/2009 i chamado 527 Maracanau
    Private _id_estabelecimento As Int32
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property

    'fran 27/11/2009 f chamado 527 Maracanau

    Public Property dt_inicio() As String
        Get
            Return _dt_inicio
        End Get
        Set(ByVal value As String)
            _dt_inicio = value
        End Set
    End Property

    Public Property dt_fim() As String
        Get
            Return _dt_fim
        End Get
        Set(ByVal value As String)
            _dt_fim = value
        End Set
    End Property



    Public Sub New()

    End Sub

    Public Function getExportaAnalisebyFilters() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExportaAnalise", parameter, "ms_view_StatusDigitacao")
            Return dataset
        End Using
    End Function
    Public Function getRelatorioConferenciaRomaneio() As DataSet 'fran 08/2015
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getRelatorioControleEntradaRomaneio", parameter, "ms_romaneio")
            Return dataset
        End Using
    End Function
    Public Function loadAnaliseAberta() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getAnaliseOkExporta", parameters, ExecuteType.Select), Int32)

        End Using


    End Function
    Public Function loadAnaliseIniciada() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getAnaliseIniciadaExporta", parameters, ExecuteType.Select), Int32)

        End Using


    End Function
    Public Function loadAnaliseNOK() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getAnaliseNokExporta", parameters, ExecuteType.Select), Int32)

        End Using


    End Function
    Public Function loadSiloOK() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getSiloOKExporta", parameters, ExecuteType.Select), Int32)

        End Using


    End Function
    Public Function loadSiloNOK() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getSiloNokExporta", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Function loadRomaneioAberto() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioAbertoExporta", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Function loadRomaneioFechado() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioFechadoExporta", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
End Class
