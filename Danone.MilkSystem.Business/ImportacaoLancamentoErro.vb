Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ImportacaoLancamentoErro

    Private _id_importacao_lancamento_erro As Int32
    Private _id_importacao_lancamento As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_importacao_log As Int32


    Public Property id_importacao_lancamento_erro() As Int32
        Get
            Return _id_importacao_lancamento_erro
        End Get
        Set(ByVal value As Int32)
            _id_importacao_lancamento_erro = value
        End Set
    End Property
    Public Property id_importacao_lancamento() As Int32
        Get
            Return _id_importacao_lancamento
        End Get
        Set(ByVal value As Int32)
            _id_importacao_lancamento = value
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



    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
        End Set
    End Property
    Public Property id_importacao_log() As Int32
        Get
            Return _id_importacao_log
        End Get
        Set(ByVal value As Int32)
            _id_importacao_log = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_importacao_lancamento_erro = id
        loadImportacaolancamentoErro()

    End Sub



    Public Sub New()

    End Sub


    Public Function getImportacaolancamentoErroByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getImportacaolancamentoErro", parameters, "ms_importacao_pagto_transportador_erro")
            Return dataSet

        End Using

    End Function

    Private Sub loadImportacaolancamentoErro()

        Dim dataSet As DataSet = getImportacaolancamentoErroByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertImportacaolancamentoErro() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertImportacaolancamentoErro", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateImportacaolancamentoErro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateImportacaolancamentoErro", parameters, ExecuteType.Update)

        End Using

    End Sub


End Class
