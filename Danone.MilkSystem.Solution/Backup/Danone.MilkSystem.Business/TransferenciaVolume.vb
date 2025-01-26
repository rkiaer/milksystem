Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports system.data

<Serializable()> Public Class TransferenciaVolume

    Private _dt_ini As String
    Private _dt_fim As String
    Private _dt_referencia As String
    Private _dt_referencia_ini As String
    Private _dt_referencia_fim As String
    Private _ano_referencia As String
    Private _id_propriedade As Int32
    Private _id_pedido_cancelar_motivo As Int32
    Private _id_transferencia_volume As Int32
    Private _id_transferencia_volume_itens As Int32
    Private _id_romaneio As Int32
    Private _id_propriedade_origem As Int32
    Private _id_propriedade_destino As Int32
    Private _id_unid_producao_destino As Int32
    Private _nr_unid_producao_destino As Int32
    Private _id_estabelecimento As Int32
    Private _id_modificador As Int32
    Private _id_situacao As Int32
    Private _id_st_selecionado As Int32
    Private _id_central_pedido As Int32
    Private _id_central_pedido_origem As Int32
    Private _limite_incentivo As Decimal
    Private _nr_volume_anual_fechado As Decimal
    Private _nr_volume_aberto As Decimal
    Private _nr_volume_total As Decimal
    Private _nr_volume_mensal As Decimal
    Private _nr_volume_selecionado As Decimal
    Private _id_romaneio_selecionado As New ArrayList
    Private _st_transferencia_destino As String ' fran 07/2016 indica que a propriedade destino esta inativa por transferencia
    Public Property id_romaneio_selecionado() As ArrayList
        Get
            Return _id_romaneio_selecionado
        End Get
        Set(ByVal value As ArrayList)
            _id_romaneio_selecionado = value
        End Set
    End Property
    Public Property dt_ini() As String
        Get
            Return _dt_ini
        End Get
        Set(ByVal value As String)
            _dt_ini = value
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
    Public Property st_transferencia_destino() As String
        Get
            Return _st_transferencia_destino
        End Get
        Set(ByVal value As String)
            _st_transferencia_destino = value
        End Set
    End Property
    Public Property ano_referencia() As String
        Get
            Return _ano_referencia
        End Get
        Set(ByVal value As String)
            _ano_referencia = value
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
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
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
    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property limite_incentivo() As Decimal
        Get
            Return _limite_incentivo
        End Get
        Set(ByVal value As Decimal)
            _limite_incentivo = value
        End Set
    End Property
    Public Property id_pedido_cancelar_motivo() As Int32
        Get
            Return _id_pedido_cancelar_motivo
        End Get
        Set(ByVal value As Int32)
            _id_pedido_cancelar_motivo = value
        End Set
    End Property

    Public Property id_propriedade_origem() As Int32
        Get
            Return _id_propriedade_origem
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_origem = value
        End Set
    End Property
    Public Property id_propriedade_destino() As Int32
        Get
            Return _id_propriedade_destino
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_destino = value
        End Set
    End Property
    Public Property id_unid_producao_destino() As Int32
        Get
            Return _id_unid_producao_destino
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao_destino = value
        End Set
    End Property
    Public Property id_transferencia_volume() As Int32
        Get
            Return _id_transferencia_volume
        End Get
        Set(ByVal value As Int32)
            _id_transferencia_volume = value
        End Set
    End Property
    Public Property id_transferencia_volume_itens() As Int32
        Get
            Return _id_transferencia_volume_itens
        End Get
        Set(ByVal value As Int32)
            _id_transferencia_volume_itens = value
        End Set
    End Property
    Public Property nr_unid_producao_destino() As Int32
        Get
            Return _nr_unid_producao_destino
        End Get
        Set(ByVal value As Int32)
            _nr_unid_producao_destino = value
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
    Public Property id_central_pedido() As Int32
        Get
            Return _id_central_pedido
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido = value
        End Set
    End Property
    Public Property id_central_pedido_origem() As Int32
        Get
            Return _id_central_pedido_origem
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_origem = value
        End Set
    End Property
    Public Property id_st_selecionado() As Int32
        Get
            Return _id_st_selecionado
        End Get
        Set(ByVal value As Int32)
            _id_st_selecionado = value
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
    Public Property nr_volume_anual_fechado() As Decimal
        Get
            Return _nr_volume_anual_fechado
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_anual_fechado = value
        End Set
    End Property
    Public Property nr_volume_aberto() As Decimal
        Get
            Return _nr_volume_aberto
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_aberto = value
        End Set
    End Property
    Public Property nr_volume_total() As Decimal
        Get
            Return _nr_volume_total
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_total = value
        End Set
    End Property
    Public Property nr_volume_mensal() As Decimal
        Get
            Return _nr_volume_mensal
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_mensal = value
        End Set
    End Property
    Public Property nr_volume_selecionado() As Decimal
        Get
            Return _nr_volume_selecionado
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_selecionado = value
        End Set
    End Property

    Public Sub New(ByVal id As String)

        Me.id_transferencia_volume = id
        loadTransferenciaVolume()

    End Sub

    Public Sub New()

    End Sub

    Public Function getVolumeTotalByPropriedade() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getTransferenciaVolumeSomaTotalbyPropriedade", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function

    Public Function getVolumeMensalByPropriedade() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransferenciaVolumeSomaMensalbyPropriedade", parameters, "ms_mapa_leite")
            Return dataSet
        End Using

    End Function

    Public Function getTransferenciaVolumeCentralPedidos() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransferenciaVolumeCentralPedidos", parameters, "ms_central_pedidos")
            Return dataSet
        End Using

    End Function
    Public Function getRomaneioUProducaoMaxOrdem() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioUProducaoMaxOrdem", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getTransferenciaPropriedadeDestino() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransferenciaPropriedadeDestino", parameters, "ms_transferencia_propriedade")
            Return dataSet

        End Using

    End Function
    Public Function getTransferenciaVolumeByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransferenciaVolume", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    Public Function getTransferenciaVolumeByPropriedade() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransferenciaVolumebyPropriedade", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function

    Public Function getTransferenciaVolumeHistorico() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransferenciaVolumeHistorico", parameters, "ms_transferencia_volume")
            Return dataSet

        End Using

    End Function
    Public Function getExportacaoBatchErrosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoBatchErros", parameters, "ms_exportacao_batch_erro")
            Return dataSet

        End Using

    End Function
    Public Function getTransferenciaVolumeItensRomaneio() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransferenciaVolumeItensbyRomaneio", parameters, "ms_transferencia_volume_itens")
            Return dataSet

        End Using

    End Function

    Private Sub loadTransferenciaVolume()

        Dim dataSet As DataSet = getTransferenciaVolumeByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertExportacaoBatchItens() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertExportacaoBatchItens", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateExportacaoBatchExecucao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateExportacaoBatchExecucao", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub updateTransferenciaVolumeItemSelecionado()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateTransferenciaVolumeItemSelecionado", parameters, ExecuteType.Update)

        End Using


    End Sub

    Public Sub updateExportacaoBatchItensMediasPO()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateExportacaoBatchItensMediasPO", parameters, ExecuteType.Update)

        End Using


    End Sub

    Public Sub updateBatchExportacaoStatusFinalizacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateBatchExportacaoStatusFinalizacao", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub deleteExportacaoBatchItensRealizadas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_deleteExportacaoBatchItensRealizadas", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub deleteExportacaoBatchExecucao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_deleteExportacaoBatchExecucao", parameters, ExecuteType.Delete)

        End Using


    End Sub

    Public Sub insertExportacaoBatchErro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_insertExportacaoBatchErro", parameters, ExecuteType.Update)

        End Using


    End Sub

    Public Function transferirVolume() As Boolean

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        transferirVolume = False
        Try
            'Pega os parametros 
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dstransf As New DataSet
            Dim dsrow As DataRow
            Dim lid_pedido_origem As New ArrayList
            Dim i As Int32
            Dim ldt_transferencia As String = Me.dt_referencia

            '###################################
            'INCLUSAO DADOS TRANSFERENCIA VOLUME
            '###################################

            Me.id_transferencia_volume = CType(transacao.ExecuteScalar("ms_insertTransferenciaVolume", parameters, ExecuteType.Insert), Int32)

            parameters = ParametersEngine.getParametersFromObject(Me)

            'Insere transf volume itens
            transacao.Execute("ms_insertTransferenciaVolumeItens", parameters, ExecuteType.Insert)

            For i = 0 To id_romaneio_selecionado.Count - 1
                Me.id_romaneio = Me.id_romaneio_selecionado(i).ToString
                Me.id_st_selecionado = 2
                parameters = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_updateTransferenciaVolumeItemSelecionado", parameters, ExecuteType.Update)
            Next

            
            'para cada romaneio da lista, atualiza o numero de ordem (para insert romaneiouproducao na itens)
            'dstransf = Me.getTransferenciaVolumeItensRomaneio
            Me.id_st_selecionado = 2 'indica para atualizar o proximo nr ordem de todos os romaneios
            parameters = ParametersEngine.getParametersFromObject(Me)
            transacao.Fill(dstransf, "ms_getTransferenciaVolumeItensbyRomaneio", parameters, "ms_transferencia_volume_itens")
            For Each dsrow In dstransf.Tables(0).Rows
                Me.id_romaneio = dsrow.Item("id_romaneio")
                parameters = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_updateTransferenciaVolumeMaxOrdem", parameters, ExecuteType.Update)
            Next

            '###################################
            'ATUALIZACAO DADOS DE ROMANEIO
            '###################################

            'Insere romaneio u produção para propriedade destino
            transacao.Execute("ms_insertTransferenciaVolumeRomaneioUProducao", parameters, ExecuteType.Insert)
            'Atualiza romaneio u produção para propriedade origem, zerando litragem
            transacao.Execute("ms_updateTransferenciaVolumeRomaneioUProducao", parameters, ExecuteType.Update)

            'Limpa Mapa fde Leite para a propriedade origem
            transacao.Execute("ms_deleteTransferenciaVolumeMapaLeite", parameters, ExecuteType.Delete)

            'para cada romaneio da lista, insere o novo mapa de leite da propriedade destino (simulacao da rotina FecharRomaneio)
            'dstransf = Me.getTransferenciaVolumeItensRomaneio
            Me.id_st_selecionado = 1 'indica para atualizar o mapa apenas dos romaneios selecionados
            Dim ds As New DataSet
            parameters = ParametersEngine.getParametersFromObject(Me)
            transacao.Fill(ds, "ms_getTransferenciaVolumeItensbyRomaneio", parameters, "ms_transferencia_volume_itens")

            For Each dsrow In ds.Tables(0).Rows
                If dsrow.Item("id_st_romaneio") = "4" Then 'so para os romaneios fechados
                    Me.id_romaneio = dsrow.Item("id_romaneio")
                    parameters = ParametersEngine.getParametersFromObject(Me)
                    'Insere romaneio mapa de leite
                    transacao.Execute("ms_insertRomaneioMapaLeite", parameters, ExecuteType.Insert)
                    'Insere romaneio mapa de leite
                    transacao.Execute("ms_insertRomaneioMapaLeiteDescartado", parameters, ExecuteType.Insert)
                    If dsrow.Item("st_romaneio_transbordo") = "S" Then
                        transacao.Execute("ms_updateRomaneioMapaLeiteTransbordo", parameters, ExecuteType.Update)
                    End If

                    'Atualiza a coluna Rejeicao_antibiotico para 'S' para as analises de produtores rejeitadas por antibitorico
                    transacao.Execute("ms_updateRomaneioMapaLeiteRejeicaoAntibiotico", parameters, ExecuteType.Update)
                End If
            Next

            '###################################
            'ATUALIZACAO DADOS DE LANCAMENTOS FUTUROS PARA PROPRIEDADE (sem a central)
            '###################################

            'sql insere duplicando lançamentos futuros sem calculo, atualiza lançamento da propriedade origem para situacao 2 e atualiza lançamento duplicado para nova propriedade
            transacao.Execute("ms_insertTransferenciaVolumeLancamentos", parameters, ExecuteType.Update)

            '##################################################
            'ATUALIZACAO CENTRAL COMPRAS
            '#################################################

            'fran 11/2022 i FAZ apenas troca propriedade na TRANSFERENCIA DA CENTRAL PORQUE NAO TROCA MAIS NUMERO DO PEDIDO

            ''busca pedidos finalizados que devem ser incluidos
            ''fran 30/10/2012 i - está gerando timeout em algumas transferencias, colocar na transação
            ''Dim dscentral As DataSet = Me.getTransferenciaVolumeCentralPedidos
            'Dim dscentral As New DataSet
            'parameters = ParametersEngine.getParametersFromObject(Me)
            'transacao.Fill(dscentral, "ms_getTransferenciaVolumeCentralPedidos", parameters, "ms_central_pedidos")
            ''fran 30/10/2012 f
            'For Each dsrow In dscentral.Tables(0).Rows
            '    Me.id_central_pedido_origem = dsrow.Item("id_central_pedido")
            '    lid_pedido_origem.Add(Me.id_central_pedido_origem)
            '    parameters = ParametersEngine.getParametersFromObject(Me)

            '    'insere novo pedido
            '    Me.id_central_pedido = CType(transacao.ExecuteScalar("ms_insertTransferenciaVolumeCentralPedido", parameters, ExecuteType.Insert), Int32)
            '    parameters = ParametersEngine.getParametersFromObject(Me)

            '    'insere item, entrega, desc produtor, pagto fornecedor
            '    'fran 30/10/2012 i
            '    'transacao.Execute("ms_insertTransferenciaVolumeCentralPedidoDados", parameters, ExecuteType.Insert)
            '    transacao.Execute("ms_insertTransferenciaVolumeCentralPedidoItem", parameters, ExecuteType.Insert)
            '    transacao.Execute("ms_insertTransferenciaVolumeCentralPedidoEntrega", parameters, ExecuteType.Insert)
            '    transacao.Execute("ms_insertTransferenciaVolumeCentralPedidoObservacao", parameters, ExecuteType.Insert) 'fran fase 3 set/2014
            '    transacao.Execute("ms_insertTransferenciaVolumeCentralPedidoDescProd", parameters, ExecuteType.Insert)
            '    'fran 04/2022 - nao precisa atualizar flag de calculado porque esta fazendo no insert i
            '    'transacao.Execute("ms_updateTransferenciaVolumeCentralPedidoDescProd", parameters, ExecuteType.Update)
            '    transacao.Execute("ms_insertTransferenciaVolumeCentralPedidoPagtoForn", parameters, ExecuteType.Insert)
            '    'fran 30/10/2012 f

            'Next

            ''inclui lançamentos da central para os que ainda não fizeram calculo
            'transacao.Execute("ms_insertTransferenciaVolumeCentralLancamentos", parameters, ExecuteType.Insert)

            ''Para cada pedido fazer o cancelamento (simulacao da rotina cancelarPedido)
            'Me.id_pedido_cancelar_motivo = 7 ' motivo transferencia volume
            'If Not lid_pedido_origem Is Nothing Then
            '    For i = 0 To Convert.ToInt32(lid_pedido_origem.Count) - 1
            '        Me.id_central_pedido = Convert.ToInt32(lid_pedido_origem(i))
            '        parameters = ParametersEngine.getParametersFromObject(Me)
            '        'Atualizar lançamentos - desativa lançamentos que não foram pagos como definitivo
            '        transacao.Execute("ms_updateCentralPedidoLancamentoCancelamento", parameters, ExecuteType.Update)

            '        'Atualizar status pedido para cancelado e atualiza o motivo de cancelamento
            '        transacao.Execute("ms_updateCentralPedidoCancelamento", parameters, ExecuteType.Update)
            '    Next
            'End If
            'Me.dt_referencia = DateAdd(DateInterval.Month, -1, CDate(Me.dt_referencia.ToString)).ToString("dd/MM/yyyy")
            'parameters = ParametersEngine.getParametersFromObject(Me)
            ''pedidos abertos, altera direto no pedido
            'transacao.Execute("ms_updateTransferenciaVolumeCentralPedidosAbertos", parameters, ExecuteType.Update)

            parameters = ParametersEngine.getParametersFromObject(Me)
            'Insere Histórico de transferencia de pedidoa (guarda todos os pedidos finalizados e finalizados parcial que irao para outra propriedade)
            transacao.Execute("ms_insertTransferenciaCentralPedidos", parameters, ExecuteType.Insert)

            'pedidos finalizados e finalizados parcial, altera direto no pedido
            transacao.Execute("ms_updateTransferenciaVolumeCentralPedidos", parameters, ExecuteType.Update)

            'inclui lançamentos da central para os que ainda não fizeram calculo e inativa os da prop anteior
            transacao.Execute("ms_insertTransferenciaVolumeCentralLancamentos", parameters, ExecuteType.Insert)

            'pedidos abertos, altera direto no pedido
            transacao.Execute("ms_updateTransferenciaVolumeCentralPedidosAbertos", parameters, ExecuteType.Update)

            '##################################################
            'TRANSFERIR HISTORICO DE POUPANCA fran 06/2016 - calculo geometrico
            '#################################################
            Me.dt_referencia = ldt_transferencia
            Me.dt_referencia_ini = Me.dt_referencia
            Me.dt_referencia_fim = Me.dt_referencia
            Me.id_situacao = 1

            'Dim dspoupanca As New DataSet
            'parameters = ParametersEngine.getParametersFromObject(Me)
            'transacao.Fill(dspoupanca, "ms_getPoupancaParametro", parameters, "ms_poupanca_parametro")
            ''se tem poupanca parametros
            'If dspoupanca.Tables(0).Rows.Count > 0 Then
            '    Me.dt_referencia_ini = Convert.ToDateTime(dspoupanca.Tables(0).Rows(0).Item("dt_referencia_ini")).ToString("dd/MM/yyyy")
            '    parameters = ParametersEngine.getParametersFromObject(Me)
            '    'insere toda conta de poupança que esta na ficha para a propriedade origem e cuja referencia esta entre o inicio do parametro de poupanca e a referencia da transf
            '    transacao.Execute("ms_insertTransferenciaPoupancaFicha", parameters, ExecuteType.Insert)

            '    'insere para prop destino toda conta de poupança que já estava na historico para a prop origem
            '    transacao.Execute("ms_insertTransferenciaPoupancaHistorico", parameters, ExecuteType.Insert)

            '    'Inativa os historicos de poupança que tem propriedade = a propriedade origem e
            '    'Inativa os historicos de poupança que tem propriedade destino e origem igual a nova propriedade da transferencia (ida e volta de propriedade)
            '    transacao.Execute("ms_updateTransferenciaPoupanca", parameters, ExecuteType.Update)
            'End If

            '##################################################
            'NOVO HISTORICO DE PROPRIEDADE ATIVA para futuros controles
            '#################################################

            Me.dt_referencia = ldt_transferencia
            Me.dt_referencia_ini = CDate(String.Concat("01/01/", Year(Me.dt_referencia.ToString))).ToString("dd/MM/yyyy")
            parameters = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_insertTransferenciaPropriedade", parameters, ExecuteType.Insert)

            transacao.Execute("ms_updateTransferenciaPropriedade", parameters, ExecuteType.Update)

            '##################################################
            'HISTORICO ANALISE ESALQ
            '#################################################

            'inclui historico de 2 meses anteriores da transferencia
            Me.dt_referencia = ldt_transferencia
            Me.dt_referencia_ini = DateAdd(DateInterval.Month, -2, CDate(String.Concat(Me.dt_referencia.ToString, " 00:00:00"))).ToString("dd/MM/yyyy HH:mm:ss")
            Me.dt_referencia_fim = DateAdd(DateInterval.Day, -1, CDate(String.Concat(Me.dt_referencia.ToString, " 23:59:59"))).ToString("dd/MM/yyyy HH:mm:ss")
            parameters = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_insertTransferenciaAnalisesEsalqHistorico", parameters, ExecuteType.Insert)

            'inclui no destino as analises esalq do periodo corrente da tarnsferencia e inativa as da origem
            Me.dt_referencia_fim = DateAdd(DateInterval.Month, 1, CDate(String.Concat(Me.dt_referencia.ToString, " 23:59:59"))).ToString("dd/MM/yyyy HH:mm:ss")
            Me.dt_referencia_fim = DateAdd(DateInterval.Day, -1, CDate(Me.dt_referencia_fim)).ToString("dd/MM/yyyy HH:mm:ss")
            parameters = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_insertTransferenciaAnalisesEsalq", parameters, ExecuteType.Insert)


            '##################################################
            'INATIVAR PROPRIEDADE ORIGEM
            '#################################################
            'inativar propriedade origem
            transacao.Execute("ms_updateTransferenciaInativarPropriedade", parameters, ExecuteType.Update)

            '##################################################
            'ATIVAR PROPRIEDADE DESTINO caso necessário
            '#################################################
            'se propriedade destino esta inativada por transferencia
            If Me.st_transferencia_destino.Equals("S") Then
                transacao.Execute("ms_updateTransferenciaAtivarPropriedade", parameters, ExecuteType.Update)
            End If


            'Comita
            transacao.Commit()
            transferirVolume = True
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            transferirVolume = False
            Throw New Exception(err.Message)
        End Try
    End Function

End Class
