Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PagtoTransportador

    Private _id_pagto_transportador As Int32
    Private _id_transportador As Int32
    Private _nr_valor_frete As Decimal
    Private _dt_referencia As String
    Private _ds_referencia As String
    Private _dt_emissao As String
    Private _dt_pagto As String
    Private _st_exportacao As String
    Private _dt_exportacao As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _cd_transportador As String
    Private _nm_transportador As String
    Private _cd_codigo_sap As String
    Private _dt_pagto_ini As String
    Private _dt_pagto_fim As String

    Public Property id_pagto_transportador() As Int32
        Get
            Return _id_pagto_transportador
        End Get
        Set(ByVal value As Int32)
            _id_pagto_transportador = value
        End Set
    End Property
    Public Property id_transportador() As Int32
        Get
            Return _id_transportador
        End Get
        Set(ByVal value As Int32)
            _id_transportador = value
        End Set
    End Property

    Public Property dt_pagto() As String
        Get
            Return _dt_pagto
        End Get
        Set(ByVal value As String)
            _dt_pagto = value
        End Set
    End Property
    Public Property dt_emissao() As String
        Get
            Return _dt_emissao
        End Get
        Set(ByVal value As String)
            _dt_emissao = value
        End Set
    End Property

    Public Property dt_exportacao() As String
        Get
            Return _dt_exportacao
        End Get
        Set(ByVal value As String)
            _dt_exportacao = value
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

    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property

    Public Property ds_referencia() As String
        Get
            Return _ds_referencia
        End Get
        Set(ByVal value As String)
            _ds_referencia = value
        End Set
    End Property

    Public Property nr_valor_frete() As Decimal
        Get
            Return _nr_valor_frete
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_frete = value
        End Set
    End Property

    Public Property cd_transportador() As String
        Get
            Return _cd_transportador
        End Get
        Set(ByVal value As String)
            _cd_transportador = value
        End Set
    End Property

    Public Property nm_transportador() As String
        Get
            Return _nm_transportador
        End Get
        Set(ByVal value As String)
            _nm_transportador = value
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
    Public Property dt_pagto_ini() As String
        Get
            Return _dt_pagto_ini
        End Get
        Set(ByVal value As String)
            _dt_pagto_ini = value
        End Set
    End Property
    Public Property dt_pagto_fim() As String
        Get
            Return _dt_pagto_fim
        End Get
        Set(ByVal value As String)
            _dt_pagto_fim = value
        End Set
    End Property
    Public Property cd_codigo_sap() As String
        Get
            Return _cd_codigo_sap
        End Get
        Set(ByVal value As String)
            _cd_codigo_sap = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me._id_pagto_transportador = id
        loadPagtoTransportador()

    End Sub

    Public Sub New()

    End Sub

    Public Function getPagtoTransportadorSemExportacao() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPagtoTransportadorSemExportacao", parameters, "ms_pagto_transportador")
            Return dataSet

        End Using

    End Function
    Public Function getPagtoTransportadorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPagtoTransportador", parameters, "ms_pagto_transportador")
            Return dataSet

        End Using

    End Function

    Private Sub loadPagtoTransportador()

        Dim dataSet As DataSet = getPagtoTransportadorByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Sub deletePagtoTransportador()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deletePagtoTransportador", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
