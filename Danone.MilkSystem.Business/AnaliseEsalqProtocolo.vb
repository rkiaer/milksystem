Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class AnaliseEsalqProtocolo

    Private _id_analise_esalq_protocolo As Int32
    Private _id_estabelecimento As Int32
    Private _dt_referencia As String
    Private _dt_coleta As String
    Private _id_propriedade As Int32
    Private _id_unid_producao As Int32
    Private _nr_unid_producao As Int32
    Private _id_propriedade_matriz As Int32
    Private _cd_protocolo_esalq As String
    Private _id_tipo_coleta_analise_esalq As Int32
    Private _id_coleta As Int32
    Private _id_coleta_amostra As Int32
    Private _id_coleta_amostra_frasco As Int32
    Private _nr_caderneta As Int32
    Private _st_exportacao As String
    Private _id_modificador_exportacao As Int32
    Private _dt_exportacao As String
    Private _dt_exportacao_1vez As String
    Private _nm_arquivo As String
    Private _id_situacao As Int32
    Private _dt_modificacao As String
    Private _id_modificador As Int32

    'filtros
    Private _nr_linhaslidas As Int32
    Private _nr_linhasimportadas As Int32
    Private _id_romaneio As Int32
    Private _dt_coleta_ini As String
    Private _dt_coleta_fim As String
    Public Property id_analise_esalq_protocolo() As Int32
        Get
            Return _id_analise_esalq_protocolo
        End Get
        Set(ByVal value As Int32)
            _id_analise_esalq_protocolo = value
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
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property
    Public Property dt_coleta() As String
        Get
            Return _dt_coleta
        End Get
        Set(ByVal value As String)
            _dt_coleta = value
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
    Public Property id_unid_producao() As Int32
        Get
            Return _id_unid_producao
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao = value
        End Set
    End Property
    Public Property nr_unid_producao() As Int32
        Get
            Return _nr_unid_producao
        End Get
        Set(ByVal value As Int32)
            _nr_unid_producao = value
        End Set
    End Property
    Public Property id_propriedade_matriz() As Int32
        Get
            Return _id_propriedade_matriz
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_matriz = value
        End Set
    End Property
    Public Property cd_protocolo_esalq() As String
        Get
            Return _cd_protocolo_esalq
        End Get
        Set(ByVal value As String)
            _cd_protocolo_esalq = value
        End Set
    End Property
    Public Property id_tipo_coleta_analise_esalq() As Int32
        Get
            Return _id_tipo_coleta_analise_esalq
        End Get
        Set(ByVal value As Int32)
            _id_tipo_coleta_analise_esalq = value
        End Set
    End Property
    Public Property id_coleta() As Int32
        Get
            Return _id_coleta
        End Get
        Set(ByVal value As Int32)
            _id_coleta = value
        End Set
    End Property
    Public Property id_coleta_amostra() As Int32
        Get
            Return _id_coleta_amostra
        End Get
        Set(ByVal value As Int32)
            _id_coleta_amostra = value
        End Set
    End Property
    Public Property id_coleta_amostra_frasco() As Int32
        Get
            Return _id_coleta_amostra_frasco
        End Get
        Set(ByVal value As Int32)
            _id_coleta_amostra_frasco = value
        End Set
    End Property
    Public Property nr_caderneta() As Int32
        Get
            Return _nr_caderneta
        End Get
        Set(ByVal value As Int32)
            _nr_caderneta = value
        End Set
    End Property
    Public Property st_exportacao() As String
        Get
            Return _st_exportacao
        End Get
        Set(ByVal value As String)
            _st_exportacao = value
        End Set
    End Property
    Public Property id_modificador_exportacao() As Int32
        Get
            Return _id_modificador_exportacao
        End Get
        Set(ByVal value As Int32)
            _id_modificador_exportacao = value
        End Set
    End Property
    Public Property dt_extportacao() As String
        Get
            Return _dt_exportacao
        End Get
        Set(ByVal value As String)
            _dt_exportacao = value
        End Set
    End Property
    Public Property dt_extportacao_1vez() As String
        Get
            Return _dt_exportacao_1vez
        End Get
        Set(ByVal value As String)
            _dt_exportacao_1vez = value
        End Set
    End Property
    Public Property nm_arquivo() As String
        Get
            Return _nm_arquivo
        End Get
        Set(ByVal value As String)
            _nm_arquivo = value
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
    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
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


    Public Property nr_linhaslidas() As Int32
        Get
            Return _nr_linhaslidas
        End Get
        Set(ByVal value As Int32)
            _nr_linhaslidas = value
        End Set
    End Property
    Public Property nr_linhasimportadas() As Int32
        Get
            Return _nr_linhasimportadas
        End Get
        Set(ByVal value As Int32)
            _nr_linhasimportadas = value
        End Set
    End Property
    Public Property dt_coleta_ini() As String
        Get
            Return _dt_coleta_ini
        End Get
        Set(ByVal value As String)
            _dt_coleta_ini = value
        End Set
    End Property
    Public Property dt_coleta_fim() As String
        Get
            Return _dt_coleta_fim
        End Get
        Set(ByVal value As String)
            _dt_coleta_fim = value
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


    Public Sub New(ByVal id As Int32)

        Me._id_analise_esalq_protocolo = id
        loadAnaliseEsalqProtocolo()

    End Sub
    Public Sub New()

    End Sub
    Public Function getAnaliseEsalqProtocoloByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnaliseEsalqProtocolo", parameters, "ms_analise_esalq_protocolo")
            Return dataSet

        End Using

    End Function
    Public Function getAnaliseEsalqProtocoloExportar() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnaliseEsalqProtocoloExportar", parameters, "ms_analise_esalq_protocolo")
            Return dataSet

        End Using

    End Function
    Private Sub loadAnaliseEsalqProtocolo()

        Dim dataSet As DataSet = getAnaliseEsalqProtocoloByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertAnaliseEsalqProtocolobyColeta() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAnaliseEsalqProtocolobyColeta", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertAnaliseEsalqProtocolobyProtocolo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAnaliseEsalqProtocolobyProtocolo", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub updateAnaliseEsalqProtocoloExportacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnaliseEsalqProtocoloExportacao", parameters, ExecuteType.Update)

        End Using

    End Sub

 

End Class

