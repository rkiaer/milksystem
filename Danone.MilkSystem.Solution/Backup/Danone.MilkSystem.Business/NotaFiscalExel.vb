Imports Danone.MilkSystem.Business
Imports RK.DataEngine
Imports RK.GenericParameters


Public Class NotaFiscalExel
    Private _dt_referencia As String
    Private _dt_referencia_ini As String
    Private _dt_referencia_fim As String
    Private _cd_codigo_sap As String     'chamado 1576 - 03/08/2012 - Mirella


    Public Property cd_codigo_sap() As String    'chamado 1576 - 03/08/2012 - Mirella i
        Get
            Return _cd_codigo_sap
        End Get
        Set(ByVal value As String)
            _cd_codigo_sap = value
        End Set
    End Property     'chamado 1576 - 03/08/2012 - Mirella f

    Public Property dt_referencia_ini() As String
        Get
            Return _dt_referencia_ini
        End Get
        Set(ByVal value As String)
            _dt_referencia_ini = value
        End Set
    End Property
    Public Property dt_referencia_fim() As String
        Get
            Return _dt_referencia_fim
        End Get
        Set(ByVal value As String)
            _dt_referencia_fim = value
        End Set
    End Property
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property
    Public Function getNotaCooperativabyFilters() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getRelatorioNotasFiscaisCooperativas", parameter, "ms_nota_fiscal")
            Return dataset
        End Using
    End Function
    Public Function getNotaProdutorbyFilters() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getRelatorioNotasFiscaisProdutor", parameter, "ms_ficha_financeira")
            Return dataset
        End Using
    End Function



End Class
