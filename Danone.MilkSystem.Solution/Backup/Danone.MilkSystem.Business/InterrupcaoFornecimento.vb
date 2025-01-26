Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class InterrupcaoFornecimento 'fran 20/10/2010 i chamado 860 item 7

    Private _id_central_interrupcao_fornecimento As Int32
    Private _id_central_pedido_desconto_produtor As Int32
    Private _id_central_pedido_pagto_fornecedor As Int32
    Private _id_execucao As Int32
    Private _id_estabelecimento As Int32
    Private _id_produtor As Int32
    Private _cd_produtor As Int32
    Private _id_propriedade As Int32
    Private _id_propriedade_matriz As Int32
    Private _dt_referencia As String
    Private _id_unid_producao As Int32
    Private _nr_unid_producao As Int32
    Private _id_central_interrupcao_resultado As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String


    Public Property id_central_interrupcao_fornecimento() As Int32
        Get
            Return _id_central_interrupcao_fornecimento
        End Get
        Set(ByVal value As Int32)
            _id_central_interrupcao_fornecimento = value
        End Set
    End Property
    Public Property id_central_pedido_desconto_produtor() As Int32
        Get
            Return _id_central_pedido_desconto_produtor
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_desconto_produtor = value
        End Set
    End Property
    Public Property id_central_pedido_pagto_fornecedor() As Int32
        Get
            Return _id_central_pedido_pagto_fornecedor
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_pagto_fornecedor = value
        End Set
    End Property
    Public Property id_central_interrupcao_resultado() As Int32
        Get
            Return _id_central_interrupcao_resultado
        End Get
        Set(ByVal value As Int32)
            _id_central_interrupcao_resultado = value
        End Set
    End Property
    Public Property id_execucao() As Int32
        Get
            Return _id_execucao
        End Get
        Set(ByVal value As Int32)
            _id_execucao = value
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
    Public Property id_produtor() As Int32
        Get
            Return _id_produtor
        End Get
        Set(ByVal value As Int32)
            _id_produtor = value
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
    Public Property id_propriedade_matriz() As Int32
        Get
            Return _id_propriedade_matriz
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_matriz = value
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
    Public Property cd_produtor() As String
        Get
            Return _cd_produtor
        End Get
        Set(ByVal value As String)
            _cd_produtor = value
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

    Public Sub New(ByVal id As Int32)

        Me.id_central_interrupcao_fornecimento = id
        loadCentralInterrupcaoFornecimento()

    End Sub

    Public Sub New()

    End Sub
    Public Function getInterrupcaoFornecimentoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralInterrupcaoFornecimento", parameters, "ms_central_interrupcao_fornecimento")
            Return dataSet

        End Using
    End Function
    Public Function getProdutoreseSuasUnidProducoes() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getProdutoreseSuasUnidProducoes", parameters, "ms_central_interrupcao_fornecimento")
            Return dataSet

        End Using
    End Function
    Public Function getPagtoFornecedorbyPropriedade() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralInterrupcaoFornecPagtoFornecedor", parameters, "ms_central_interrupcao_fornecimento")
            Return dataSet

        End Using
    End Function

    Public Function getCentralInterrupcaoFornecTotais() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralInterrupcaoFornecTotais", parameters, "ms_central_interrupcao_fornecimento")
            Return dataSet

        End Using
    End Function
    Public Function getDescontoProdutorbyPropriedade() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralInterrupcaoFornecDescontoProdutor", parameters, "ms_central_interrupcao_fornecimento")
            Return dataSet

        End Using
    End Function
    Public Function getMovimentosAbertosByPropriedade() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMovimentosAbertosByPropriedade", parameters, "ms_central_interrupcao_fornecimento")
            Return dataSet

        End Using
    End Function
    Public Function getCentralInterrupcaoPedidos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralInterrupcaoPedidos", parameters, "ms_central_pedido")
            Return dataSet

        End Using
    End Function
    Private Sub loadCentralInterrupcaoFornecimento()

        Dim dataSet As DataSet = getInterrupcaoFornecimentoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertInterrupcaoFornecimento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralInterrupcaoFornecimento", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    

    Public Sub updateInterrupcaoFornecimentoResultado()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralInterrupcaoFornecimentoResultado", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getExecucaoInterrupcaoFornecimento() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getIdentityInterrupcaoFornecimento", parameters, ExecuteType.Select), Int32)
        End Using
    End Function

    Public Function getCalculoDefinitivoByPropriedade() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoDefinitivoByPropriedade", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Function interrupcaoFornecimentoLeite() As Boolean 'fran 20/10/2010 i chamado 860 item 7

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        interrupcaoFornecimentoLeite = False
        Try
            'Pega os parametros para processo
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Cancelar todos os pedido em aberto para a propriedade/up
            transacao.Execute("ms_updateCentralPedidosAbertosCancelar", parameters, ExecuteType.Update)

            'Insere lançamentos pendentes de desconto ao produtor na referencia informada (os uqe não foram pagos), desativa os pendentes para frente
            transacao.Execute("ms_insertCentralLancamentoAntecipaDescProdutor", parameters, ExecuteType.Insert)

            'Insere na PagtoFornecedor os pagamentos que ainda não foram exportados para EMS, antecipando-os para ref informada, desativa os cadastrados em referencias posteriroes
            transacao.Execute("ms_insertCentralAntecipaPagtoFornecedor", parameters, ExecuteType.Insert)

            'atualiza execucao com resultado de sucesso

            transacao.Execute("ms_updateCentralInterrupcaoFornecimentoResultado", parameters, ExecuteType.Update)

            transacao.Execute("ms_updateCentralPedidoInterrupcao", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            interrupcaoFornecimentoLeite = True
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            interrupcaoFornecimentoLeite = False
            Throw New Exception(err.Message)
        End Try
    End Function

End Class
