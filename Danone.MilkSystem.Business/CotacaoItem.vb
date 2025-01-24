Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class CotacaoItem

    Private _id_central_cotacao As Int32
    Private _id_central_cotacao_item As Int32
    Private _id_item As Int32
    Private _cd_item As String
    Private _nm_item As String
    Private _nr_quantidade As Decimal
    Private _nr_parcelas As Int32
    Private _st_ver_mercado As String
    Private _st_produtor_informado As String
    Private _ds_tipo_medida As String
    Private _id_central_justificativa_aprovacao As Int32
    Private _id_central_status_aprovacao As Int32  ' 1-Reprovado Tecnico 2-Aprovado Tecnico 3-Reprovado Gestor 4-Aprovado Gestor (ms_zcentral_status_aprovacao)
    Private _nm_central_status_aprovacao As String
    Private _id_aprovador_tecnico As Int32
    Private _id_aprovador_gestor As Int32
    Private _dt_aprovacao_tecnico As String
    Private _dt_aprovacao_gestor As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _dt_entrega As String 'fran chamaso 602
    Private _st_selecao As String
    Private _id_central_prazo_pagto As Int32 'fran fase 2 melhorias
    Private _st_parcelamento As String 'fran fase 3 melhorias


    Public Property id_central_cotacao() As Int32
        Get
            Return _id_central_cotacao
        End Get
        Set(ByVal value As Int32)
            _id_central_cotacao = value
        End Set
    End Property
    Public Property id_central_cotacao_item() As Int32
        Get
            Return _id_central_cotacao_item
        End Get
        Set(ByVal value As Int32)
            _id_central_cotacao_item = value
        End Set
    End Property
    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
        End Set
    End Property
    Public Property cd_item() As String
        Get
            Return _cd_item
        End Get
        Set(ByVal value As String)
            _cd_item = value
        End Set
    End Property
    Public Property nm_item() As String
        Get
            Return _nm_item
        End Get
        Set(ByVal value As String)
            _nm_item = value
        End Set
    End Property
    Public Property nr_quantidade() As Decimal
        Get
            Return _nr_quantidade
        End Get
        Set(ByVal value As Decimal)
            _nr_quantidade = value
        End Set
    End Property
    Public Property nr_parcelas() As Int32
        Get
            Return _nr_parcelas
        End Get
        Set(ByVal value As Int32)
            _nr_parcelas = value
        End Set
    End Property
    Public Property st_ver_mercado() As String
        Get
            Return _st_ver_mercado
        End Get
        Set(ByVal value As String)
            _st_ver_mercado = value
        End Set
    End Property
    Public Property dt_entrega() As String
        Get
            Return _dt_entrega
        End Get
        Set(ByVal value As String)
            _dt_entrega = value
        End Set
    End Property
    Public Property st_produtor_informado() As String
        Get
            Return _st_produtor_informado
        End Get
        Set(ByVal value As String)
            _st_produtor_informado = value
        End Set
    End Property
    Public Property ds_tipo_medida() As String
        Get
            Return _ds_tipo_medida
        End Get
        Set(ByVal value As String)
            _ds_tipo_medida = value
        End Set
    End Property
    Public Property id_aprovador_tecnico() As Int32
        Get
            Return _id_aprovador_tecnico
        End Get
        Set(ByVal value As Int32)
            _id_aprovador_tecnico = value
        End Set
    End Property
    Public Property id_aprovador_gestor() As Int32
        Get
            Return _id_aprovador_gestor
        End Get
        Set(ByVal value As Int32)
            _id_aprovador_gestor = value
        End Set
    End Property
    Public Property dt_aprovacao_tecnico() As String
        Get
            Return _dt_aprovacao_tecnico
        End Get
        Set(ByVal value As String)
            _dt_aprovacao_tecnico = value
        End Set
    End Property
    Public Property dt_aprovacao_gestor() As String
        Get
            Return _dt_aprovacao_gestor
        End Get
        Set(ByVal value As String)
            _dt_aprovacao_gestor = value
        End Set
    End Property
    Public Property id_central_justificativa_aprovacao() As Int32
        Get
            Return _id_central_justificativa_aprovacao
        End Get
        Set(ByVal value As Int32)
            _id_central_justificativa_aprovacao = value
        End Set
    End Property
    Public Property nm_central_status_aprovacao() As String
        Get
            Return _nm_central_status_aprovacao
        End Get
        Set(ByVal value As String)
            _nm_central_status_aprovacao = value
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
    Public Property id_central_status_aprovacao() As String
        Get
            Return _id_central_status_aprovacao
        End Get
        Set(ByVal value As String)
            _id_central_status_aprovacao = value
        End Set
    End Property
    Public Property st_selecao() As String
        Get
            Return _st_selecao
        End Get
        Set(ByVal value As String)
            _st_selecao = value
        End Set
    End Property
    Public Property id_central_prazo_pagto() As Int32
        Get
            Return _id_central_prazo_pagto
        End Get
        Set(ByVal value As Int32)
            _id_central_prazo_pagto = value
        End Set
    End Property
    Public Property st_parcelamento() As String
        Get
            Return _st_parcelamento
        End Get
        Set(ByVal value As String)
            _st_parcelamento = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_central_cotacao_item = id
        loadCotacaoItem()

    End Sub

    Public Sub New()

    End Sub
    Public Function getCotacaoItensByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralCotacaoItens", parameters, "ms_central_cotacao_itens")
            Return dataSet

        End Using

    End Function

    Public Function getCotacaoItensGrid() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralCotacaoItensGrid", parameters, "ms_central_cotacao_itens")
            Return dataSet

        End Using

    End Function
    Private Sub loadCotacaoItem()

        Dim dataSet As DataSet = getCotacaoItensByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertCotacaoItem() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralCotacaoItem", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    'fran 27/07/2010 i 717/860
    Public Sub updateCentralCotacaoItemSituacaobyCotacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacaoItemSituacaobyCotacao", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateCotacaoItem()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacaoItem", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCotacaoItemSituacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacaoItemSituacao", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deleteCotacaoItem()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralCotacaoItem", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub deleteCotacaoItemESeusFornecedores()
        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para deleção
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Delete cotacao fornecedores
            transacao.Execute("ms_deleteCentralCotacaoFornecedor", parameters, ExecuteType.Delete)

            'Delete cotacao item
            transacao.Execute("ms_deleteCentralCotacaoItem", parameters, ExecuteType.Delete)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub

End Class
