Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math
Imports System.Data

<Serializable()> Public Class PreRomaneioAmostra

    Private _id_pre_romaneio_amostras As Int32
    Private _id_transit_point As Int32
    Private _id_pre_romaneio As Int32
    Private _st_leite_total_rejeitado As String
    Private _id_coleta As Int32
    Private _id_situacao As Int32
    Private _id_transit_point_registro As Int32
    Private _id_situacao_tp_amostra As Int32
    Private _id_motivo_descarte_tp_amostra As Int32
    Private _id_usuario_registro As Int32
    Private _dt_modificacao_registro As String
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
    Public Property id_transit_point_registro() As Int32
        Get
            Return _id_transit_point_registro
        End Get
        Set(ByVal value As Int32)
            _id_transit_point_registro = value
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
    Public Property id_pre_romaneio_amostras() As Int32
        Get
            Return _id_pre_romaneio_amostras
        End Get
        Set(ByVal value As Int32)
            _id_pre_romaneio_amostras = value
        End Set
    End Property
    Public Property st_leite_total_rejeitado() As String
        Get
            Return _st_leite_total_rejeitado
        End Get
        Set(ByVal value As String)
            _st_leite_total_rejeitado = value
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
    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_situacao_tp_amostra() As Int32
        Get
            Return _id_situacao_tp_amostra
        End Get
        Set(ByVal value As Int32)
            _id_situacao_tp_amostra = value
        End Set
    End Property
    Public Property id_motivo_descarte_tp_amostra() As Int32
        Get
            Return _id_motivo_descarte_tp_amostra
        End Get
        Set(ByVal value As Int32)
            _id_motivo_descarte_tp_amostra = value
        End Set
    End Property
    Public Property id_usuario_registro() As Int32
        Get
            Return _id_usuario_registro
        End Get
        Set(ByVal value As Int32)
            _id_usuario_registro = value
        End Set
    End Property

    Public Property dt_modificacao_registro() As String
        Get
            Return _dt_modificacao_registro
        End Get
        Set(ByVal value As String)
            _dt_modificacao_registro = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Int32)

        Me._id_pre_romaneio_amostras = id
        loadPreRomaneioAmostras()

    End Sub

    Public Function getPreRomaneioAmostrasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPreRomaneioAmostras", parameters, "ms_pre_romaneio_amostras")
            Return dataSet

        End Using

    End Function


    Private Sub loadPreRomaneioAmostras()

        Dim dataSet As DataSet = getPreRomaneioAmostrasByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updatePreRomaneioAmostras()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePreRomaneioAmostras", parameters, ExecuteType.Update)

        End Using

    End Sub


End Class
