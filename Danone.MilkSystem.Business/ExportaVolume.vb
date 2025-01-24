Imports System
Imports System.data
Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


Public Class ExportaVolume
    Private _dt_referencia As String
    Private _id_estabelecimento As Int32
    Private _id_romaneio As Int32 'fran 08/2015
    Private _nm_tecnico As String
    Private _cd_pessoa As String
    Private _id_propriedade As Int32
    Private _id_tecnico As Int32 'fran 04/08/2010
    Private _id_pessoa As Int32 'fran 04/08/2010
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _tp_pagamento As String  ' adri 06/03/2012 - projeto Themis - Processo de Cálculo unificado por IE
    Private _cd_codigo_sap As String     'chamado 1576 - 31/07/2012 - Mirella
    Private _st_pagamento As String  'fran dango 2018


    Public Property cd_codigo_sap() As String    'chamado 1576 - 31/07/2012 - Mirella i
        Get
            Return _cd_codigo_sap
        End Get
        Set(ByVal value As String)
            _cd_codigo_sap = value
        End Set
    End Property     'chamado 1576 - 31/07/2012 - Mirella f
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
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property id_romaneio() As Int32
        Get
            Return _id_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_romaneio = value
        End Set
    End Property
    Public Property id_tecnico() As Int32 'fran chamado 899
        Get
            Return _id_tecnico
        End Get
        Set(ByVal value As Int32)
            _id_tecnico = value
        End Set
    End Property
    Public Property id_pessoa() As Int32 'fran chamado 899
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
        End Set
    End Property

    Public Property nm_tecnico() As String
        Get
            Return _nm_tecnico
        End Get
        Set(ByVal value As String)
            _nm_tecnico = value
        End Set
    End Property

    Public Property cd_pessoa() As String
        Get
            Return _cd_pessoa
        End Get
        Set(ByVal value As String)
            _cd_pessoa = value
        End Set
    End Property

    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
        End Set
    End Property

    Public Property tp_pagamento() As String
        Get
            Return _tp_pagamento
        End Get
        Set(ByVal value As String)
            _tp_pagamento = value
        End Set
    End Property
    Public Property st_pagamento() As String
        Get
            Return _st_pagamento
        End Get
        Set(ByVal value As String)
            _st_pagamento = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Function getExportaVolumebyFilters() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExportaVolumeFicha", parameter, "ms_ficha_financeira_itens")
            Return dataset
        End Using
    End Function
    Public Function getRomaneioDesvioMarcacao() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getRomaneioDesvioMarcacao", parameter, "ms_romaneio_uproducao")
            Return dataset
        End Using
    End Function
    Public Function getRomaneioDesvioMarcacaoTP() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getRomaneioDesvioMarcacaoTP", parameter, "ms_romaneio_uproducao")
            Return dataset
        End Using
    End Function
    Public Function getExportaVolumebyRomaneio() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExportaVolumeRomaneio", parameter, "ms_romaneio_uproducao")
            Return dataset
        End Using
    End Function
    Public Function getExportaVolumeRomaneioTP() As DataSet
        Using data As New DataAccess
            Dim parameter As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataset As New DataSet

            data.Fill(dataset, "ms_getExportaVolumeRomaneioTP", parameter, "ms_romaneio_uproducao")
            Return dataset
        End Using
    End Function
    Public Function getExportaVolumeRomaneioTotalLitros() As Int64 'fran 08/2015
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getExportaVolumeRomaneioTotalLitros", parameters, ExecuteType.Select), Int64)

        End Using

    End Function
    Public Function getExportaVolumeRomaneioTotalLitrosRejeitados() As Int64 'fran 08/2015
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getExportaVolumeRomaneioTotalLitrosRejeitados", parameters, ExecuteType.Select), Int64)

        End Using

    End Function
    Public Function getExportaVolumeRomaneioTotalLitrosTP() As Int64 'fran 08/2015
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getExportaVolumeRomaneioTotalLitrosTP", parameters, ExecuteType.Select), Int64)

        End Using

    End Function
    Public Function getExportaVolumeRomaneioTotalLitrosRejeitadosTP() As Int64 'fran 08/2015
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getExportaVolumeRomaneioTotalLitrosRejeitadosTP", parameters, ExecuteType.Select), Int64)

        End Using

    End Function
End Class
