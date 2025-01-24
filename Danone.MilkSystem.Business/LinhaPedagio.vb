Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class LinhaPedagio

    Private _id_linha As Int32
    Private _id_linha_pedagio As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _id_criacao As Int32
    Private _dt_modificacao As String
    Private _dt_criacao As String
    Private _nm_linha As String
    Private _nr_valor_pedagio_eixo As Decimal
    Private _dt_validade As String
    Private _dt_inicio_validade As String

    Public Property id_linha() As Int32
        Get
            Return _id_Linha
        End Get
        Set(ByVal value As Int32)
            _id_Linha = value
        End Set
    End Property

    Public Property id_linha_pedagio() As Int32
        Get
            Return _id_linha_pedagio
        End Get
        Set(ByVal value As Int32)
            _id_linha_pedagio = value
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

    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
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

    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
        End Set
    End Property

    Public Property nm_linha() As String
        Get
            Return _nm_linha
        End Get
        Set(ByVal value As String)
            _nm_linha = value
        End Set
    End Property
    Public Property nr_valor_pedagio_eixo() As Decimal
        Get
            Return _nr_valor_pedagio_eixo
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_pedagio_eixo = value
        End Set
    End Property

    Public Property dt_validade() As String
        Get
            Return _dt_validade
        End Get
        Set(ByVal value As String)
            _dt_validade = value
        End Set
    End Property
    Public Property dt_inicio_validade() As String
        Get
            Return _dt_inicio_validade
        End Get
        Set(ByVal value As String)
            _dt_inicio_validade = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_linha = id
        loadLinhaPedagio()

    End Sub

    Public Sub New()

    End Sub
    Public Function getLinhaPedagioByValidade() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhaPedagiobyValidade", parameters, "ms_linha_pedagio")
            Return dataSet

        End Using

    End Function
    Public Function getLinhaPedagioConsValidade() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhaPedagioConsValidade", parameters, "ms_linha_pedagio")
            Return dataSet

        End Using

    End Function
    Public Function getLinhaPedagioByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhaPedagio", parameters, "ms_linha_pedagio")
            Return dataSet

        End Using

    End Function
    Public Function getLinhaPedagioConsRomaneioExportado() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhaPedagioConsRomaneioExportado", parameters, "ms_linha_pedagio")
            Return dataSet

        End Using

    End Function
    Private Sub loadLinhaPedagio()

        Dim dataSet As DataSet = getLinhaPedagioByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertLinhaPedagio() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertLinhaPedagio", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub deleteLinhaPedagio()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteLinhaPedagio", parameters, ExecuteType.Delete)

        End Using


    End Sub



End Class
