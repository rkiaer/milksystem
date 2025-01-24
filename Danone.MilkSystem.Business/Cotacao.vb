Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class Cotacao

    Private _id_central_cotacao As Int32
    Private _id_central_cotacao_item As Int32
    Private _id_estabelecimento As Int32
    Private _id_central_justificativa_aprovacao As Int32
    Private _id_central_status_aprovacao As Int32  ' 1-Reprovado Tecnico 2-Aprovado Tecnico 3-Reprovado Gestor 4-Aprovado Gestor (ms_zcentral_status_aprovacao)
    Private _id_tecnico As Int32
    Private _dt_cotacao_inicio As String
    Private _dt_cotacao_fim As String
    Private _nm_propriedade As String
    Private _id_unid_producao As Int32
    Private _id_propriedade As Int32
    Private _id_pessoa As Int32
    Private _cd_pessoa As String 'fran chamado 559
    Private _id_item As Int32
    Private _cd_item As String 'fran chamado 559
    Private _st_ver_mercado As String
    Private _st_produtor_informado As String
    Private _id_situacao_cotacao As Int32
    Private _nm_situacao_cotacao As String
    Private _dt_cotacao As String
    Private _nr_total_cotacao As Decimal
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    'Private _st_aprovado As String  ' Desabilitado Adriana
    Private _st_selecao As String
    Private _st_selecionado As String 'chamado 717
    Private _nr_limite_disponivel As Decimal 'chamado 1069
    Private _nr_valor_mensal_estimado As Decimal 'melhoria fase 2
    Private _st_saldo_romaneio_aberto As String 'melhoria fase 2
    Private _st_pedido_indireto As String 'melhoria fase 3
    Private _id_central_pedido_item As Int32 'melhoria fase 3
    Private _nr_valor_nota_fiscal As Decimal 'melhoria fase 3
    Private _nr_parcela As Int32 'melhoria fase 3
    Private _nr_valor_parcela As Decimal 'melhoria fase 3
    Private _dt_pagto As String 'melhora fase 3

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
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property id_tecnico() As Int32
        Get
            Return _id_tecnico
        End Get
        Set(ByVal value As Int32)
            _id_tecnico = value
        End Set
    End Property
    Public Property dt_cotacao_inicio() As String
        Get
            Return _dt_cotacao_inicio
        End Get
        Set(ByVal value As String)
            _dt_cotacao_inicio = value
        End Set
    End Property
    Public Property nm_propriedade() As String
        Get
            Return _nm_propriedade
        End Get
        Set(ByVal value As String)
            _nm_propriedade = value
        End Set
    End Property
    Public Property dt_cotacao_fim() As String
        Get
            Return _dt_cotacao_fim
        End Get
        Set(ByVal value As String)
            _dt_cotacao_fim = value
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
    Public Property id_unid_producao() As Int32
        Get
            Return _id_unid_producao
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao = value
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
    Public Property id_pessoa() As Int32
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
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
    Public Property id_situacao_cotacao() As Int32
        Get
            Return _id_situacao_cotacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao_cotacao = value
        End Set
    End Property
    Public Property nm_situacao_cotacao() As String
        Get
            Return _nm_situacao_cotacao
        End Get
        Set(ByVal value As String)
            _nm_situacao_cotacao = value
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
    Public Property cd_item() As String
        Get
            Return _cd_item
        End Get
        Set(ByVal value As String)
            _cd_item = value
        End Set
    End Property
    Public Property dt_cotacao() As String
        Get
            Return _dt_cotacao
        End Get
        Set(ByVal value As String)
            _dt_cotacao = value
        End Set
    End Property
    Public Property nr_limite_disponivel() As Decimal
        Get
            Return _nr_limite_disponivel
        End Get
        Set(ByVal value As Decimal)
            _nr_limite_disponivel = value
        End Set
    End Property
    Public Property nr_valor_mensal_estimado() As Decimal
        Get
            Return _nr_valor_mensal_estimado
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_mensal_estimado = value
        End Set
    End Property
    Public Property nr_total_cotacao() As Decimal
        Get
            Return _nr_total_cotacao
        End Get
        Set(ByVal value As Decimal)
            _nr_total_cotacao = value
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
    Public Property st_selecionado() As String
        Get
            Return _st_selecionado
        End Get
        Set(ByVal value As String)
            _st_selecionado = value
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
    Public Property st_produtor_informado() As String
        Get
            Return _st_produtor_informado
        End Get
        Set(ByVal value As String)
            _st_produtor_informado = value
        End Set
    End Property
    Public Property st_pedido_indireto() As String
        Get
            Return _st_pedido_indireto
        End Get
        Set(ByVal value As String)
            _st_pedido_indireto = value
        End Set
    End Property
    Public Property st_saldo_romaneio_aberto() As String
        Get
            Return _st_saldo_romaneio_aberto
        End Get
        Set(ByVal value As String)
            _st_saldo_romaneio_aberto = value
        End Set
    End Property
    Public Property nr_valor_nota_fiscal() As Decimal
        Get
            Return _nr_valor_nota_fiscal
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nota_fiscal = value
        End Set
    End Property
    Public Property nr_valor_parcela() As Decimal
        Get
            Return _nr_valor_parcela
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_parcela = value
        End Set
    End Property

    Public Property id_central_pedido_item() As Int32
        Get
            Return _id_central_pedido_item
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_item = value
        End Set
    End Property
    Public Property nr_parcela() As Int32
        Get
            Return _nr_parcela
        End Get
        Set(ByVal value As Int32)
            _nr_parcela = value
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
    Public Sub New(ByVal id As Int32)

        Me.id_central_cotacao = id
        loadCotacao()

    End Sub

    Public Sub New()

    End Sub
    Public Function getCotacaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralCotacao", parameters, "ms_central_cotacao")
            Return dataSet

        End Using

    End Function

    Private Sub loadCotacao()

        Dim dataSet As DataSet = getCotacaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function getCentralCotacaoByTecnico() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralCotacaoTecnico", parameters, "ms_central_cotacao")
            Return dataSet

        End Using

    End Function
    Public Function getCentralCotacaoByGestor() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralCotacaoGestor", parameters, "ms_central_cotacao")
            Return dataSet

        End Using

    End Function
    Public Function getCentralCotacoeseSeusItensbyFilter() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralCotacaoeSeusItens", parameters, "ms_central_cotacao_item")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoItensbyCotacao() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoItemValorParcelas", parameters, "ms_central_pedido_item")
            Return dataSet

        End Using

    End Function
    Public Function insertCotacao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralCotacao", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function getCotacaoItensParcelados() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralCotacaoItensParcelados", parameters, ExecuteType.Select), Int32)

        End Using


    End Function

    Public Function getCentralCotacaoItensParcelaSemParceiro() As Int32 'fran fase 3 08/2014

        Using data As New DataAccess
            'Retorna o id da central cotacao itens cujo st_parcelamento for <> P (diferente de parcelamento do Parceiro) (igual a N (nao parcelado) ou D (parcelamento Danone)
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralCotacaoItensParcelaSemParceiro", parameters, ExecuteType.Select), Int32)

        End Using


    End Function

    Public Sub updateCotacaoQtdeItensAprovacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacaoQtdeItensAprovacao", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateCotacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCotacaoAprovarTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCotacaoAprovarTodos", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteCotacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralCotacao", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub updateAdiantamentoSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCotacaoSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralCotacaoAprovarSelecionados()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacaoAprovarSelecionados", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralCotacaoAprovador()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacaoAprovador", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralCotacaoTodos1N()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacaoTodos1N", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateCentralCotacaoTodos2N()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacaoTodos2N", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralCotacaoSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Data.Execute("ms_updateCentralCotacaoSelecao", Parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralCotacaoTotal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacaoTotal", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralCotacaoSituacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacaoSituacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function gerarPedido() As Boolean

        Dim transacao As New DataAccess
        'Dim transacao2 As New DataAccess

        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        gerarPedido = False
        Try
            'Pega os parametros para inclusão pedido
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'fran 15/02/2011 i chamado 1170
            Dim pedido As New Pedido
            pedido.id_central_cotacao = Me.id_central_cotacao
            Dim dataSet As New DataSet
            transacao.Fill(dataSet, "ms_getCentralPedido", parameters, "ms_central_pedido")
            'fran 15/02/2011 f chamado 1170

            If (dataSet.Tables(0).Rows.Count = 0) Then

                'Insere cotacao pedido
                transacao.Execute("ms_insertCentralPedido", parameters, ExecuteType.Insert)

                'Insere cotacao pedido
                transacao.Execute("ms_insertCentralPedidoItem", parameters, ExecuteType.Insert)

                'Insere data de entrega do fornecedor e quantidade em ms_central_pedido_entrega
                transacao.Execute("ms_insertCentralPedidoEntregabyCotacao", parameters, ExecuteType.Insert)

                'Atualizar status da cotacao
                Me.id_situacao_cotacao = 6 'Finalizado
                'Pega os parametros para inclusão pedido
                parameters = ParametersEngine.getParametersFromObject(Me)

                'Atualiza status cotacao
                transacao.Execute("ms_updateCentralCotacaoSituacao", parameters, ExecuteType.Update)
            End If

            '' ''fran set/2014 fase 3 i
            '' ''Comita
            ' ''transacao.Commit()
            ' ''transacao.Dispose()


            '' ''fran set/2014 fase 3 f

            '' ''fran set/2014 i
            '' ''Busca os pedidos acabados de incluir
            ' ''Dim dspedidositens As DataSet = Me.getCentralPedidoItensbyCotacao()

            ' ''Dim row As DataRow
            ' ''Dim i As Int32 = 1

            ' ''If dspedidositens.Tables(0).Rows.Count > 0 Then

            ' ''    'Inicia Transação
            ' ''    transacao2.StartTransaction(IsolationLevel.RepeatableRead)

            ' ''    For Each row In dspedidositens.Tables(0).Rows 'para cada item de pedido incluido
            ' ''        'pega os parametros
            ' ''        Me.id_central_pedido_item = row.Item("id_central_pedido_item")
            ' ''        Me.nr_valor_nota_fiscal = row.Item("nr_valor_total")
            ' ''        Me.nr_valor_parcela = row.Item("nr_valor_parcela")
            ' ''        Me.nr_parcela = 1

            ' ''        'INSERE DESCONTOS AO PRODUTOR....
            ' ''        If CInt(row.Item("nr_parcelas")) > 1 Then 'se é Parcelado
            ' ''            For i = 1 To CInt(row.Item("nr_parcelas"))
            ' ''                Me.nr_parcela = i
            ' ''                'Pega os parametros para inclusão pedido desconto produtor
            ' ''                parameters = ParametersEngine.getParametersFromObject(Me)
            ' ''                transacao2.Execute("ms_insertCentralPedidoDescontoProdutorbyCotacao", parameters, ExecuteType.Insert)
            ' ''                'i = i + 1
            ' ''            Next
            ' ''        Else
            ' ''            'Pega os parametros para inclusão pedido desconto produtor
            ' ''            parameters = ParametersEngine.getParametersFromObject(Me)
            ' ''            transacao2.Execute("ms_insertCentralPedidoDescontoProdutorbyCotacao", parameters, ExecuteType.Insert)
            ' ''        End If

            ' ''        'INSERE PAGTO AO FORNECEDOR
            ' ''        Me.nr_parcela = 1
            ' ''        Me.nr_valor_parcela = Me.nr_valor_nota_fiscal

            ' ''        Select Case CInt(row.Item("id_central_prazo_pagto"))
            ' ''            Case 0, 1 '10 dias fora mes
            ' ''                Me.dt_pagto = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("10/", Format(DateTime.Parse(Now), "MM/yyyy").ToString)))

            ' ''            Case 2 '20 dias fora me
            ' ''                Me.dt_pagto = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("20/", Format(DateTime.Parse(Now), "MM/yyyy").ToString)))

            ' ''            Case 3 '32 dias fora me
            ' ''                Me.dt_pagto = DateAdd(DateInterval.Day, 32, (DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("01/", Format(DateTime.Parse(Now), "MM/yyyy").ToString)))))

            ' ''            Case 4 '63 dias fora me 
            ' ''                Me.dt_pagto = DateAdd(DateInterval.Day, 63, (DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("01/", Format(DateTime.Parse(Now), "MM/yyyy").ToString)))))
            ' ''        End Select
            ' ''        'Pega os parametros para inclusão pedido desconto produtor
            ' ''        parameters = ParametersEngine.getParametersFromObject(Me)
            ' ''        transacao2.Execute("ms_insertCentralPedidoPagtoFornecedorbyCotacao", parameters, ExecuteType.Insert)
            ' ''    Next
            ' ''    'Comita
            ' ''    transacao2.Commit()
            ' ''    transacao2.Dispose()

            ' ''    'fran set/2014 f
            ' ''End If

            'Comita
            transacao.Commit()
            transacao.Dispose()

            gerarPedido = True

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            'transacao2.RollBack()
            'transacao2.Dispose()
            gerarPedido = False
            Throw New Exception(err.Message)
        End Try
    End Function

End Class
