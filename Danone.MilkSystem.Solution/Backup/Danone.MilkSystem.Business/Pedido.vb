Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class Pedido

    Private _id_central_pedido As Int32
    Private _id_central_pedido_item As Int32
    Private _id_central_cotacao As Int32
    Private _id_estabelecimento As Int32
    Private _id_unid_producao As Int32
    Private _id_propriedade As Int32
    Private _id_propriedade_matriz As Int32
    Private _id_fornecedor As Int32
    Private _id_produtor As Int32 'fran 04/2016 relatorio KPI
    Private _id_categoria_item As Int32 'fran 04/2016 relatorio KPI
    Private _id_canal As Int32 'fran 04/2016 relatorio KPI
    Private _id_item As Int32
    Private _dt_pedido As String
    Private _st_envio_email As String
    Private _nr_total_pedido As Decimal
    Private _id_situacao_pedido As Int32
    Private _nm_situacao_pedido As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    'Alexandre 30/10/2009 i.
    Private _id_pessoa As Int32
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _id_tecnico As Int32
    'Alexandre 30/10/2009 f.
    Private _ano As String 'Alexandre 06/11/2009 i.
    Private _dt_referencia As String    ' Adriana 10/11/2009
    Private _cd_item As String    ' Fran 07/05/2010 chamado 822
    Private _cd_fornecedor As String    ' Fran 07/05/2010 chamado 822
    Private _cd_produtor As String    ' Fran 07/05/2010 chamado 822
    Private _id_pedido_cancelar_motivo As Int32 'fran 11/10/2010 chamado 998
    Private _st_transferencia_volume As String    ' Fran 22/03/2012 themis
    Private _id_central_pedido_origem As Int32 'fran 22/03/2012 themis
    Private _id_propriedade_origem As Int32 'fran 22/03/2012 themis
    Private _id_unid_producao_origem As Int32 'fran 22/03/2012 themis
    Private _st_pedido_indireto As String 'fran fase 3
    Private _st_evento_compras As String 'fran mais solidos indica que o pedido foi gerado em evento de compras
    Private _id_central_status_aprovacao As Int32
    Private _id_central_justificativa_aprovacao As Int32
    Private _st_selecao As String
    Private _dt_fornec_fim As String  ' adri 21/04/2022 - Relatorio Concialiação Cenral Compras 
    Private _nr_saldoacumuladoSAP As Decimal  ' adri 21/04/2022 - Relatorio Concialiação Cenral Compras 
    Private _st_tipo_parcelamento As String
    Private _ds_tipofrete As String
    Private _ds_inclusao_pedido As String
    Private _nr_valor_limite_disponivel As Decimal
    Private _nr_valor_unitario As Decimal
    Private _nr_sacaria As Decimal
    Private _nr_qtde_parcelas As Int32
    Private _id_transportador As Int32
    Private _id_veiculo_central_compras_propriedade As Int32
    Private _pedidoitens As DataTable
    Private _ds_motivo_aprovacao As String
    Private _nr_total_pedido_frete As Decimal
    Private _nr_quantidade_total As Decimal
    Private _id_central_pedido_matriz As Int32
    Private _id_central_contrato As Int32
    Private _nm_produtor As String
    Private _nm_fornecedor As String
    Private _nr_valor_ini As Decimal
    Private _nr_valor_fim As Decimal
    Private _nr_valor_nota As Decimal
    Private _cd_cnpj As String
    Private _st_tipo_fornecedor As String

    Public Property ds_motivo_aprovacao() As String
        Get
            Return _ds_motivo_aprovacao
        End Get
        Set(ByVal value As String)
            _ds_motivo_aprovacao = value
        End Set
    End Property
    Public Property st_tipo_parcelamento() As String
        Get
            Return _st_tipo_parcelamento
        End Get
        Set(ByVal value As String)
            _st_tipo_parcelamento = value
        End Set
    End Property
    Public Property ds_inclusao_pedido() As String
        Get
            Return _ds_inclusao_pedido
        End Get
        Set(ByVal value As String)
            _ds_inclusao_pedido = value
        End Set
    End Property
    Public Property ds_tipofrete() As String
        Get
            Return _ds_tipofrete
        End Get
        Set(ByVal value As String)
            _ds_tipofrete = value
        End Set
    End Property
    Public Property st_tipo_fornecedor() As String
        Get
            Return _st_tipo_fornecedor
        End Get
        Set(ByVal value As String)
            _st_tipo_fornecedor = value
        End Set
    End Property
    Public Property nr_quantidade_total() As Decimal
        Get
            Return _nr_quantidade_total
        End Get
        Set(ByVal value As Decimal)
            _nr_quantidade_total = value
        End Set
    End Property
    Public Property nr_valor_limite_disponivel() As Decimal
        Get
            Return _nr_valor_limite_disponivel
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_limite_disponivel = value
        End Set
    End Property
    Public Property nr_valor_unitario() As Decimal
        Get
            Return _nr_valor_unitario
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_unitario = value
        End Set
    End Property
    Public Property nr_sacaria() As Decimal
        Get
            Return _nr_sacaria
        End Get
        Set(ByVal value As Decimal)
            _nr_sacaria = value
        End Set
    End Property
    Public Property nr_qtde_parcelas() As Int32
        Get
            Return _nr_qtde_parcelas
        End Get
        Set(ByVal value As Int32)
            _nr_qtde_parcelas = value
        End Set
    End Property
    Public Property id_veiculo_central_compras_propriedade() As Int32
        Get
            Return _id_veiculo_central_compras_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_veiculo_central_compras_propriedade = value
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
    Public Property pedidoitens() As DataTable
        Get
            Return _pedidoitens
        End Get
        Set(ByVal value As DataTable)
            _pedidoitens = value
        End Set
    End Property
    Public Property id_central_pedido_matriz() As Int32
        Get
            Return _id_central_pedido_matriz
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_matriz = value
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
    Public Property id_central_contrato() As Int32
        Get
            Return _id_central_contrato
        End Get
        Set(ByVal value As Int32)
            _id_central_contrato = value
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
    Public Property id_central_cotacao() As Int32
        Get
            Return _id_central_cotacao
        End Get
        Set(ByVal value As Int32)
            _id_central_cotacao = value
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
    Public Property id_propriedade_matriz() As Int32
        Get
            Return _id_propriedade_matriz
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_matriz = value
        End Set
    End Property
    Public Property id_fornecedor() As Int32
        Get
            Return _id_fornecedor
        End Get
        Set(ByVal value As Int32)
            _id_fornecedor = value
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
    Public Property id_canal() As Int32
        Get
            Return _id_canal
        End Get
        Set(ByVal value As Int32)
            _id_canal = value
        End Set
    End Property
    Public Property id_categoria_item() As Int32
        Get
            Return _id_categoria_item
        End Get
        Set(ByVal value As Int32)
            _id_categoria_item = value
        End Set
    End Property
    Public Property id_situacao_pedido() As Int32
        Get
            Return _id_situacao_pedido
        End Get
        Set(ByVal value As Int32)
            _id_situacao_pedido = value
        End Set
    End Property
    Public Property nm_situacao_pedido() As String
        Get
            Return _nm_situacao_pedido
        End Get
        Set(ByVal value As String)
            _nm_situacao_pedido = value
        End Set
    End Property
    Public Property dt_pedido() As String
        Get
            Return _dt_pedido
        End Get
        Set(ByVal value As String)
            _dt_pedido = value
        End Set
    End Property
    Public Property cd_cnpj() As String
        Get
            Return _cd_cnpj
        End Get
        Set(ByVal value As String)
            _cd_cnpj = value
        End Set
    End Property
    Public Property st_envio_email() As String
        Get
            Return _st_envio_email
        End Get
        Set(ByVal value As String)
            _st_envio_email = value
        End Set
    End Property
    Public Property nr_total_pedido() As Decimal
        Get
            Return _nr_total_pedido
        End Get
        Set(ByVal value As Decimal)
            _nr_total_pedido = value
        End Set
    End Property
    Public Property nr_valor_nota() As Decimal
        Get
            Return _nr_valor_nota
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nota = value
        End Set
    End Property
    Public Property nr_total_pedido_frete() As Decimal
        Get
            Return _nr_total_pedido_frete
        End Get
        Set(ByVal value As Decimal)
            _nr_total_pedido_frete = value
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
    'Alexandre 30/10/2009 i.
    Public Property id_pessoa() As Int32
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
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
    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
        End Set
    End Property
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
    Public Property nr_valor_ini() As Decimal
        Get
            Return _nr_valor_ini
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_ini = value
        End Set
    End Property
    Public Property nr_valor_fim() As Decimal
        Get
            Return _nr_valor_fim
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_fim = value
        End Set
    End Property
    Public Property nm_produtor() As String
        Get
            Return _nm_produtor
        End Get
        Set(ByVal value As String)
            _nm_produtor = value
        End Set
    End Property
    Public Property nm_fornecedor() As String
        Get
            Return _nm_fornecedor
        End Get
        Set(ByVal value As String)
            _nm_fornecedor = value
        End Set
    End Property

    'Alexandre 06/11/2009 i.
    Public Property ano() As String
        Get
            Return _ano
        End Get
        Set(ByVal value As String)
            _ano = value
        End Set
    End Property
    'Alexandre 06/11/2009 f.
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
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
    Public Property cd_fornecedor() As String
        Get
            Return _cd_fornecedor
        End Get
        Set(ByVal value As String)
            _cd_fornecedor = value
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
    Public Property id_pedido_cancelar_motivo() As Int32
        Get
            Return _id_pedido_cancelar_motivo
        End Get
        Set(ByVal value As Int32)
            _id_pedido_cancelar_motivo = value
        End Set
    End Property
    Public Property st_transferencia_volume() As String
        Get
            Return _st_transferencia_volume
        End Get
        Set(ByVal value As String)
            _st_transferencia_volume = value
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
    Public Property id_unid_producao_origem() As Int32
        Get
            Return _id_unid_producao_origem
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao_origem = value
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
    Public Property st_pedido_indireto() As String
        Get
            Return _st_pedido_indireto
        End Get
        Set(ByVal value As String)
            _st_pedido_indireto = value
        End Set
    End Property
    Public Property st_evento_compras() As String
        Get
            Return _st_evento_compras
        End Get
        Set(ByVal value As String)
            _st_evento_compras = value
        End Set
    End Property
    Public Property id_central_status_aprovacao() As Int32
        Get
            Return _id_central_status_aprovacao
        End Get
        Set(ByVal value As Int32)
            _id_central_status_aprovacao = value
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
    Public Property st_selecao() As String
        Get
            Return _st_selecao
        End Get
        Set(ByVal value As String)
            _st_selecao = value
        End Set
    End Property
    Public Property dt_fornec_fim() As String
        Get
            Return _dt_fornec_fim
        End Get
        Set(ByVal value As String)
            _dt_fornec_fim = value
        End Set
    End Property
    Public Property nr_saldoacumuladoSAP() As Decimal
        Get
            Return _nr_saldoacumuladoSAP
        End Get
        Set(ByVal value As Decimal)
            _nr_saldoacumuladoSAP = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_central_pedido = id
        loadPedido()

    End Sub

    Public Sub New()

    End Sub
    Public Function getPedidoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedido", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getPedidosAbertos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoAbertos", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getPedidosCancelar() As DataSet 'fran 14/10/2010 i chamado 998

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidosCancelar", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Private Sub loadPedido()

        Dim dataSet As DataSet = getPedidoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertCentralPedido() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralPedido", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateCentralPedido()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralCotacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralPedidoTipoFrete()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoTipoFrete", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralPedidoSituacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoSituacao", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateCentralPedidoEventoCompras()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoEventoCompras", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralPedidoDataEnvioEmail()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoDataEnvioEmail", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Function finalizarPedido() As Boolean

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        finalizarPedido = False
        Try
            'Pega os parametros para inclusão pedido
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Insere lançamentos
            transacao.Execute("ms_insertCentralPedidoLancamentos", parameters, ExecuteType.Insert)
            'Insere lançamentos MAIS SOLIDOS fran outubro 2017
            'transacao.Execute("ms_insertCentralPedidoLancamentosMaisSolidos", parameters, ExecuteType.Insert)

            'Atualizar status da cotacao
            'Fran 03/2023 i
            'Retirado do finalizar para ser informado a situacao por causa da situacao FINALIZADO PARCIAL
            'Me.id_situacao_pedido = 3 'Finalizado
            'Pega os parametros para inclusão pedido
            'parameters = ParametersEngine.getParametersFromObject(Me)
            'Fran 03/2023 f

            'Atualiza status cotacaoin
            transacao.Execute("ms_updateCentralPedidoSituacao", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            finalizarPedido = True
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            finalizarPedido = False
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function apurarSituacaoAprovacao(ByVal pvalortotalpedido As Decimal, ByVal pvalorlimite As Decimal, ByVal ptipoparcelamento As String, ByVal pnrparcelas As Int16, ByVal pdtfimcontrato As String, ByVal pdtultdescontoprodutor As String, ByRef pmotivo As String) As Int16

        Try
            Dim parametro As New Parametro
            Dim lipoloticaparcelas As Integer = parametro.nr_politica_parcelas


            'situacao pedido : 5- em aprovação / 6 - aprovado
            apurarSituacaoAprovacao = 0
            pmotivo = String.Empty

            'se nao encontrou limite
            If pvalorlimite = 0 Then
                apurarSituacaoAprovacao = 5
                pmotivo = "Limite Disponível Zerado. Sem Faturamento anterior ou projeção de custos para referência atual."
            Else
                'se valor a vista, deve apenas verificar limite
                If pnrparcelas <= 1 Then

                    If pvalortotalpedido <= pvalorlimite Then
                        apurarSituacaoAprovacao = 6
                    Else
                        apurarSituacaoAprovacao = 5
                        pmotivo = "Limite Disponível Insuficiente."
                    End If
                Else
                    If ptipoparcelamento = "P" Then
                        If (pvalortotalpedido / pnrparcelas) <= pvalorlimite Then
                            apurarSituacaoAprovacao = 6
                        Else
                            apurarSituacaoAprovacao = 5
                            pmotivo = "Limite Disponível Insuficiente."
                        End If
                    Else
                        'se tipo parcelamento = Danone

                        If pnrparcelas > lipoloticaparcelas Then
                            apurarSituacaoAprovacao = 5
                            pmotivo = "Nr. Parcelas ultrapassa política Danone."
                        Else
                            If pdtfimcontrato.Equals(String.Empty) Then
                                apurarSituacaoAprovacao = 5
                                pmotivo = "Sem Data Final de Contrato."
                            Else
                                'se tem a data fim do contrato mas ela é menor que o ultimo desconto parcelado
                                If CDate(pdtfimcontrato) < CDate(pdtultdescontoprodutor) Then
                                    apurarSituacaoAprovacao = 5
                                    pmotivo = "Última parcela ultrapassa a Data Final do Contrato."
                                Else
                                    'se fim do contrato ok e data ult parcela ok, verifica limite
                                    If pvalortotalpedido <= pvalorlimite Then
                                        apurarSituacaoAprovacao = 6
                                    Else
                                        apurarSituacaoAprovacao = 5
                                        pmotivo = "Limite Disponível Insuficiente."
                                    End If

                                End If

                            End If
                        End If
                    End If

                End If
            End If


        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
    End Function

    Public Sub calcularDataDescontoProdutor(ByVal pdtpedido As String, ByVal pnrparcelas As Int16, ByRef pdt1aparcela As String, ByRef pdtultparcela As String)

        Try

            Dim ldiapedido As Int16 = DatePart(DateInterval.Day, CDate(pdtpedido))
            Dim lmespedido As Int16 = DatePart(DateInterval.Month, CDate(pdtpedido))
            Dim lreferenciaatual As Date = CDate(String.Concat("01/", DateTime.Parse(Now()).ToString("MM/yyyy")))
            Dim lPrimParc As Date
            Dim lUltParc As Date

            'se a data de emissao for maior ou igual ao mes atual, nota no prazo
            If CDate(pdtpedido) >= lreferenciaatual Then

                If ldiapedido <= 25 Then
                    'se data pedido for menor que data de corte (entre dia 1 e 25), a primeira parcela será na propria referencia
                    lPrimParc = lreferenciaatual
                    If pnrparcelas > 1 Then
                        lUltParc = DateAdd(DateInterval.Month, pnrparcelas - 1, lPrimParc)
                    Else
                        lUltParc = lPrimParc
                    End If

                    lPrimParc = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, lPrimParc)) 'pega o ultimo dia do mes
                    lUltParc = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, lUltParc)) 'pega o ult dia do mes


                    'If lmespedido = 2 Then

                    '    pdt1aparcela = String.Concat("28/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))
                    'Else
                    '    pdt1aparcela = String.Concat("30/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))
                    'End If
                    'If pnrparcelas > 1 Then
                    '    pdtultparcela = DateAdd(DateInterval.Month, pnrparcelas - 1, Convert.ToDateTime(pdt1aparcela))
                    'Else
                    '    pdtultparcela = pdt1aparcela
                    'End If

                Else
                    'se data pedido for maior que data de corte (entre 26 e 31), a ´primeira parcela sera M+1

                    'If lmespedido + 1 = 2 Then
                    '    pdt1aparcela = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("28/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))))

                    'Else
                    '    'se data pedido for maior que data de corte (entre 26 e 31), a ´primeira parcela sera M+1
                    '    pdt1aparcela = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("30/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))))

                    'End If
                    'If pnrparcelas > 1 Then
                    '    pdtultparcela = DateAdd(DateInterval.Month, pnrparcelas - 1, Convert.ToDateTime(pdt1aparcela))
                    'Else
                    '    pdtultparcela = pdt1aparcela
                    'End If

                    'se data pedido for maior que data de corte (entre 26 e 31), a ´primeira parcela sera M+1
                    lPrimParc = DateAdd(DateInterval.Month, 1, lreferenciaatual)
                    If pnrparcelas > 1 Then
                        lUltParc = DateAdd(DateInterval.Month, pnrparcelas - 1, lPrimParc)
                    Else
                        lUltParc = lPrimParc
                    End If

                    lPrimParc = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, lPrimParc)) 'pega o ultimo dia do mes
                    lUltParc = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, lUltParc)) 'pega o ult dia do mes

                End If
                pdt1aparcela = DateTime.Parse(lPrimParc).ToString("dd/MM/yyyy")
                pdtultparcela = DateTime.Parse(lUltParc).ToString("dd/MM/yyyy")
            Else
                'se a data da nota estiver fora do prazo
                'assume pagamento na referencia atual
                lPrimParc = lreferenciaatual
                If pnrparcelas > 1 Then
                    lUltParc = DateAdd(DateInterval.Month, pnrparcelas - 1, lPrimParc)
                Else
                    lUltParc = lPrimParc
                End If

                lPrimParc = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, lPrimParc)) 'pega o ultimo dia do mes
                lUltParc = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, lUltParc)) 'pega o ult dia do mes
            End If

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub calcularDataPagtoFornecedor(ByVal pdtpedido As String, ByVal pstexcecaoprazo As String, ByVal ptipoparcelamento As String, ByVal pnrparcelas As Int16, ByRef pdt1aparcela As String, ByRef pdtultparcela As String)

        Try

            Dim ldiapedido As Int16 = DatePart(DateInterval.Day, CDate(pdtpedido))
            Dim lreferenciaatual As Date = CDate(String.Concat("01/", DateTime.Parse(Now()).ToString("MM/yyyy")))

            'DEFINE DATA PAGTO PAGTO FORNECEDOR
            'se a data de emissao for maior ou igual ao mes atual, nota no prazo
            If CDate(pdtpedido) >= lreferenciaatual Then

                'APURA DATA DE PAGTO INICIAL PARA FORNECEDOR
                'se o fornecedor tem excecao no prazo pagto
                If pstexcecaoprazo = "S" Then
                    Select Case ldiapedido
                        Case Is <= 10
                            'se data pedido for menor que dia 10 (entre dia 1 e 10), a primeira parcela será 10DFM (10 dias fora mes)
                            pdt1aparcela = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("10/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))))
                        Case ldiapedido >= 11 And ldiapedido <= 19
                            'se data pedido for maior que dia 11 e menor que 19 (entre dia 11 e 19), a primeira parcela será 20DFM (20 dias fora mes)
                            pdt1aparcela = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("20/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))))
                        Case Is >= 20
                            'se data pedido for maior que dia 20 (entre dia 20 e 31), a primeira parcela será 1o dia do mes subseuqente (dia 1o mais 2 meses)
                            pdt1aparcela = DateAdd(DateInterval.Month, 2, Convert.ToDateTime(String.Concat("01/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))))
                    End Select
                Else
                    Select Case ldiapedido
                        Case Is <= 25
                            'se data pedido for menor ou igual que dia 25 a primeira parcela será 20M+1
                            pdt1aparcela = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("20/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))))
                        Case Is >= 20
                            'se data pedido for maior que dia 25 (entre dia 26 e 31), a primeira parcela será dia 20 do mes subseuqente (dia 20 mais 2 meses)
                            pdt1aparcela = DateAdd(DateInterval.Month, 2, Convert.ToDateTime(String.Concat("20/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))))
                    End Select
                    ''se nao tem exceção no prazo de pagamento a primeira parcela será 20DFM (20 dias fora mes)
                    'pdt1aparcela = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("20/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))))

                End If

                'APURA DATA PAGAMENTO FINAL DE FORNECEDOR
                'se o parcelamento é do PARCEIRO, o pagamento feito à ele tambemé parcelado
                If pnrparcelas > 1 And ptipoparcelamento = "P" Then
                    pdtultparcela = DateAdd(DateInterval.Month, pnrparcelas - 1, Convert.ToDateTime(pdt1aparcela))
                Else 'se parcelamento danone ou a vista fornecedor pago em 1 x
                    pdtultparcela = pdt1aparcela
                End If
            Else
                'se nota fora do prazo

                'As notas fora do prazo serao pagas em M+1 da data de agora, nos dias 20
                pdt1aparcela = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("20/", DateTime.Parse(lreferenciaatual).ToString("MM/yyyy"))))
                'APURA DATA PAGAMENTO FINAL DE FORNECEDOR
                'se o parcelamento é do PARCEIRO, o pagamento feito à ele tambemé parcelado
                If pnrparcelas > 1 And ptipoparcelamento = "P" Then
                    pdtultparcela = DateAdd(DateInterval.Month, pnrparcelas - 1, Convert.ToDateTime(pdt1aparcela))
                Else 'se parcelamento danone ou a vista fornecedor pago em 1 x
                    pdtultparcela = pdt1aparcela
                End If

            End If

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub calcularDataPagtoTransportador(ByVal pdtpedido As String, ByVal pstexcecaoprazo As String, ByVal ptipoparcelamento As String, ByVal pnrparcelas As Int16, ByRef pdt1aparcela As String, ByRef pdtultparcela As String)

        Try

            Dim ldiapedido As Int16 = DatePart(DateInterval.Day, CDate(pdtpedido))
            Dim lreferenciaatual As Date = CDate(String.Concat("01/", DateTime.Parse(Now()).ToString("MM/yyyy")))

            'se a data de emissao for maior ou igual ao mes atual, nota no prazo
            If CDate(pdtpedido) >= lreferenciaatual Then

                'DEFINE DATA PAGTO PAGTO TRANSPORTADOR
                'se o transportador tem excecao no prazo pagto
                'APURA DATA DE PAGTO INICIAL PARA FORNECEDOR
                'se o fornecedor tem excecao no prazo pagto
                If pstexcecaoprazo = "S" Then
                    Select Case ldiapedido
                        Case Is <= 25
                            'se data pedido for menor igaual que dia 25 (entre dia 1 e 25), a primeira parcela será 10DFM (10 dias fora mes)
                            pdt1aparcela = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("10/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))))
                        Case Else
                            'se data pedido for maior que dia 25 (entre dia 26 e 31), a primeira parcela será 10 dia do mes subseuqente (dia 10 mais 2 meses)
                            pdt1aparcela = DateAdd(DateInterval.Month, 2, Convert.ToDateTime(String.Concat("10/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))))
                    End Select
                Else
                    Select Case ldiapedido
                        Case Is <= 25
                            'se data pedido for menor igaual que dia 25 (entre dia 1 e 25), a primeira parcela será 20DFM (20 dias fora mes)
                            pdt1aparcela = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("20/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))))
                        Case Else
                            'se data pedido for maior que dia 25 (entre dia 26 e 31), a primeira parcela será 20 dia do mes subseuqente (dia 20 mais 2 meses)
                            pdt1aparcela = DateAdd(DateInterval.Month, 2, Convert.ToDateTime(String.Concat("20/", DateTime.Parse(pdtpedido.ToString.Trim).ToString("MM/yyyy"))))
                    End Select

                End If

                'APURA DATA PAGAMENTO FINAL DE transportador
                'PAGAMENTO AO TRANSPORTADOR È SEMPRE A VISTA
                'If pnrparcelas > 1 And ptipoparcelamento = "P" Then
                '    pdtultparcela = DateAdd(DateInterval.Month, pnrparcelas - 1, Convert.ToDateTime(pdt1aparcela))
                'Else 'se parcelamento danone ou a vista fornecedor pago em 1 x
                '    pdtultparcela = pdt1aparcela
                'End If
                pdtultparcela = pdt1aparcela

            Else
                'se nota fora do prazo

                'As notas fora do prazo serao pagas em M+1 da data de agora, nos dias 20
                pdt1aparcela = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("20/", DateTime.Parse(lreferenciaatual).ToString("MM/yyyy"))))
                'TRANSPORTADOR SEMPRE RECEBE A VISTA
                pdtultparcela = pdt1aparcela


            End If


        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Function reabrirPedido() As Boolean

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        reabrirPedido = False
        Try
            'Pega os parametros para inclusão pedido
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inativa Lancamentos
            transacao.Execute("ms_deleteCentralPedidoReabrirLancamentos", parameters, ExecuteType.Update)

            'Atualizar status da cotacao
            Me.id_situacao_pedido = 4 'Reaberto
            'Pega os parametros 
            parameters = ParametersEngine.getParametersFromObject(Me)

            'Atualiza status Pedido para Reaberto
            transacao.Execute("ms_updateCentralPedidoSituacao", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            reabrirPedido = True
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            reabrirPedido = False
            Throw New Exception(err.Message)
        End Try
    End Function

    Public Sub deleteCentralPedido()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralPedido", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function getCentralPedidoPagtoFornecedorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoPagtoFornecedor", parameters, "ms_central_pedido_pagto_fornecedor")
            Return dataSet

        End Using

    End Function
    'Alexandre 30/10/2009 i.
    Public Function getParcelamento_Parceiros() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralParcelamentoParceiros", parameters, "ms_central_pedido_pagto_fornecedor")
            Return dataSet

        End Using

    End Function
    'Alexandre 30/10/2009 f.
    'Alexandre 06/11/2009 i.
    Public Function getParticipacaoProdutores() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralParticipacaoProdutores", parameters, "ms_central_pedido_desconto_produtor")
            Return dataSet

        End Using

    End Function

    Public Function getParticipacaoProdutoresTotaisCentral() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralParticipacaoProdutores_TotaisCentral", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getRelacaoProdutores() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralRelacaoProdutores", parameters, "ms_central_pedido_desconto_produtor")
            Return dataSet

        End Using

    End Function
    Public Function getSpendProdutoresAnalitico() As DataSet 'fran 01/2016

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSpendProdutoresAnalitico", parameters, "ms_central_pedido_desconto_produtor")
            Return dataSet

        End Using

    End Function
    Public Function getSpendProdutores() As DataSet 'fran 01/2016

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSpendProdutores", parameters, "ms_central_pedido_desconto_produtor")
            Return dataSet

        End Using

    End Function
    Public Function getSpendProdutoresbyEstabelecimento() As DataSet 'fran 01/2016

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSpendProdutoresbyEstabelecimento", parameters, "ms_central_pedido_desconto_produtor")
            Return dataSet

        End Using

    End Function
    'Alexandre 06/11/2009 f.
    'fran 30/11/2010 i chamado 1072
    Public Function getRelacaoProdutoresTotalLeite() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralRelProdutorTotalLeite", parameters, "ms_central_pedido_desconto_produtor")
            Return dataSet

        End Using

    End Function
    'fran 30/11/2010 f chamado 1072

    ' Adriana 10/11/2009 - i
    Public Function getCentralVolumeMesProdutores() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralVolumeMesProdutores", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCentralFaturamentoMesProdutores() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralFaturamentoMesProdutores", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCentralComprasCentral() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralComprasCentral", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCentralVolumeCentral() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralVolumeCentral", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCentralQtdMesProdutores() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralQtdMesProdutores", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCentralPedidoValorTotalNotas() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralPedidoValorTotalNotas", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCentralQtdMesProdutoresEducampo() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralQtdMesProdutoresEducampo", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCentralQtdMesProdutoresCentral() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralQtdMesProdutoresCentral", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCentralQtdMesProdutoresCentralEducampo() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralQtdMesProdutoresCentralEducampo", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCentralVolumeMesProdutoresCentral() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralVolumeMesProdutoresCentral", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    ' Adriana 10/11/2009 - f
    Public Function getCentralPedidoseSeusItensbyFilter() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoeSeusItens", parameters, "ms_central_pedido_item")
            Return dataSet

        End Using

    End Function

    Public Function getCentralPedidoMatriz() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoMatriz", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoReabrir() As DataSet 'fran fase 3

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoReabrir", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoNotasbyProdutor() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoNotasbyProdutor", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoNotasbyPropriedade() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoNotasbyPropriedade", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoEmailParceiro() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoEmailParceiro", parameters, "ms_central_pedido_item")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoEmailParceiroItens() As DataSet 'fran 14/05/2010 chamado 816

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoEmailParceiroItens", parameters, "ms_central_pedido_item")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoEmailParceiroEntrega() As DataSet 'fran 14/05/2010 chamado 816

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoEmailParceiroEntrega", parameters, "ms_central_pedido_item")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoEmailParceiroPagto() As DataSet 'fran 14/05/2010 chamado 816

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoEmailParceiroPagto", parameters, "ms_central_pedido_item")
            Return dataSet

        End Using

    End Function

    Public Function getCentralPedidoEmailProdutorPagto() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoEmailProdutorPagto", parameters, "ms_central_pedido_item")
            Return dataSet

        End Using

    End Function
    'Alexandre 16/11/2009 i.
    Public Function getEvolucaoVendas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getEvolucaoVendas", parameters, "ms_pessoa")
            Return dataSet

        End Using

    End Function
    Public Function getCentralRelatorioResultados() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralRelatorioResultadosSintetico", parameters, "ms_pessoa")
            Return dataSet

        End Using

    End Function
    Public Function getCentralRelatorioResultadosAnalitico() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralRelatorioResultadosAnalitico", parameters, "ms_pessoa")
            Return dataSet

        End Using

    End Function
    Public Function getCentralRelatorioResultadosMatriz() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralRelatorioResultadosMatriz", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralRelatorioResultadosFornecedorInsumo() As String

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralRelatorioResultadosFornecedorInsumo", parameters, ExecuteType.Select), String)

        End Using

    End Function
    
    Public Function getValorTotalJan() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totaljan", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorTotalFev() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totalfev", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorTotalMar() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totalmar", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorTotalAbr() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totalabr", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorTotalMai() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totalmai", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorTotalJun() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totaljun", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorTotalJul() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totaljul", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorTotalAgo() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totalago", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorTotalSet() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totalset", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorTotalOut() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totalout", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorTotalNov() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totalnov", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorTotalDez() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totaldez", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorTotalGeral() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_totalgeral", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    'Alexandre 16/11/2009 f.
    Public Function getCentralPedidoConsDataFornecedor() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsDataFornecedor", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoConsDataProdutor() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsDataProdutor", parameters, "ms_central_pedido")
            Return dataSet

        End Using
    End Function
    'fran 10/03/2010 i chamado 684
    Public Function getCentralPedidoConsParcelas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsParcelas", parameters, "ms_central_pedido")
            Return dataSet

        End Using
    End Function
    Public Function getCentralPedidoConsParcelasbyItem() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsParcelasbyItem", parameters, "ms_central_pedido")
            Return dataSet

        End Using
    End Function
    Public Function getCentralPedidoTotalParcelasByPedido() As DataSet 'fran fase 3 set/2014
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoTotalParcelasByPedido", parameters, "ms_central_pedido")
            Return dataSet

        End Using
    End Function
    Public Function getCentralPedidoConsSomaQtdePrevista() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsSomaQtdePrevista", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoConsSomaValorFornecedor() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsSomaValorFornecedor", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoConsSomaValorProdutor() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsSomaValorProdutor", parameters, "ms_central_pedido")
            Return dataSet

        End Using
    End Function
    'fran 10/10/2010 i chamado817
    Public Function getCentralPedidoConsNotaVlDiferenteFornec() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsNotaVlDiferenteFornec", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function

    Public Function getCentralPedidoConsNotaSerieEmissaoFornec() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsNotaSerieEmissaoFornec", parameters, "ms_central_pedido_pagto_fornecedor")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoConsSomaParcComVlNotaFornec() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsSomaParcComVlNotaFornec", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    'fran 10/10/2010 f chamado817
    'fran 25/08/2010 i chamado 945
    Public Function getCentralPedidoConsNotaVlDiferenteProdutor() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsNotaVlDiferenteProdutor", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function

    Public Function getCentralPedidoConsTotalPedidoExcedido() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsTotalPedidoExcedido", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoConsSomaParcComVlNotaProdutor() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsSomaParcComVlNotaProdutor", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoConsDataNotaProdutor() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsDataNotaProdutor", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoConsDataNotaFornecedor() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsDataNotaFornecedor", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function

    Public Function getCentralPedidoConsValorNotaFornecProd() As DataSet 'fran 08/2015

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsValorNotaFornecProd", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoConsNrNotaFornecProd() As DataSet 'fran 08/2015

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoConsNrNotaFornecProd", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoDescProdutorParcelas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoDescProdutorParcelas", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    'fran 25/08/2010 f chamado 945
    Public Function cancelarPedido() As Boolean 'fran 26/10/2010 i chamado 998

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        cancelarPedido = False
        Try
            'Pega os parametros para inclusão pedido
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualizar lançamentos - desativa lançamentos que não foram pagos como definitivo
            transacao.Execute("ms_updateCentralPedidoLancamentoCancelamento", parameters, ExecuteType.Insert)

            'Atualizar status pedido para cancelado e atualiza o motivo de cancelamento
            transacao.Execute("ms_updateCentralPedidoMaisSolidosCancelamento", parameters, ExecuteType.Update)

            'Atualizar status pedido para cancelado e atualiza o motivo de cancelamento
            transacao.Execute("ms_updateCentralPedidoCancelamento", parameters, ExecuteType.Insert)


            'Comita
            transacao.Commit()
            cancelarPedido = True
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            cancelarPedido = False
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function getValorJan() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_jan", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorFev() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_fev", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorMar() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_mar", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorAbr() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_abr", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorMai() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_mai", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorJun() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_jun", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorJul() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_jul", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorAgo() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_ago", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorSet() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_set", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorOut() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_out", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorNov() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_nov", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getValorDez() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEvolucaoVendas_dez", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    ' Fran 9/12/2010 - i
    Public Function getCentralParcelamentoSaldo() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralParcelamentoSaldo", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getTotalPedidosAbertos() As Decimal 'fran fase 2 melhoria
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralTotalPedidosAbertos", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getInterrupcaoTotalPedidosAbertos() As Decimal 'fran fase 2 melhoria
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralInterrupcaoTotalPedidosAbertos", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCentralPedidoTotalComprasbyReferencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoTotalComprasbyReferencia", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function

    Public Function getCentralPedidoTotalComprasbyGrupo() As Decimal 'fran 10/2016 - total valor pedidos comprados central
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralPedidoTotalComprasbyGrupo", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCentralPedidoTotalCompras() As Decimal 'fran 02/2016 - total valor pedidos comprados central
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralPedidoTotalCompras", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    'fran 03/2016 relatorios KPI
    Public Function getRelatorioKPI_ItensPeriodo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioKPI_ItensPeriodo", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getRelatorioKPI_ItensReferencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioKPI_ItensReferencia", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getRelatorioKPI_FornecedorItensPeriodo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioKPI_FornecedorItensPeriodo", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getRelatorioKPI_FornecedorItensReferencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioKPI_FornecedorItensReferencia", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getRelatorioKPI_ProdutorItensPeriodo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioKPI_ProdutorItensPeriodo", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getRelatorioKPI_ProdutorItensReferencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioKPI_ProdutorItensReferencia", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getRelatorioKPI_ValorQtde() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRelatorioKPI_ValorQtde", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getRelatorioKPI_ValorFrete() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRelatorioKPI_ValorFrete", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getRelatorioKPI_ValorNota() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRelatorioKPI_ValorNota", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function

    Public Function getValorTotalComprasbyPeriodo() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralValorTotalComprasbyPeriodo", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    'fran 03/2016 relatorios KPI f
    Public Function getCentralFornecedorEmAprovacao() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralFornecedorEmAprovacao", parameters, "ms_central_pedido")
            Return dataSet

        End Using
    End Function
    Public Function getCentralParcelamentoDanoneByItem() As DataSet
        Using data As New DataAccess()
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralParcelamentoDanoneByItem", parameters, "ms_central_pedido")
            Return dataSet
        End Using
    End Function

    Public Sub updateCentralPedidoAprovarFornecedorSelecao()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoAprovarFornecedorSelecao", parameters, ExecuteType.Update)

        End Using
    End Sub

    Public Sub updateCentralPedidoAprovarFornecedorSelecionados()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoAprovarFornecedorSelecionados", parameters, ExecuteType.Update)

        End Using
    End Sub
    Public Function getCentralPedidoAprovacao1Nivel() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoAprovacao1Nivel", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function

    Public Function getCentralPedidoAprovacao2Nivel() As System.Data.DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoAprovacao2Nivel", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function

    Public Function getCentralPedidoAprovacaoSelecionados() As System.Data.DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoAprovacaoSelecionados", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function

    Public Sub updateCentralPedidoAprovacaoJustificativa1N()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoAprovacaoJustificativa1N", parameters, ExecuteType.Update)

        End Using
    End Sub

    Public Sub updateCentralPedidoAprovacaoJustificativa2N()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoAprovacaoJustificativa2N", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateCentralPedidoAprovacaoSelecao()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoAprovacaoSelecao", parameters, ExecuteType.Update)

        End Using
    End Sub

    Public Sub updateCentralPedidoAprovacaoTodos1N()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoAprovacaoTodos1N", parameters, ExecuteType.Update)

        End Using
    End Sub

    Public Sub updateCentralPedidoAprovacaoTodos2N()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoAprovacaoTodos2N", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateCentralPedidoAprovarSelecionados1Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoAprovarSelecionados1Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateCentralPedidoAprovarSelecionados2Nivel()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoAprovarSelecionados2Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    ' Adri 18/04/2022 - Relatorio de Apoio Contabilidade - i 
    Public Function getCentralConciliacaoContabilidadeAnalitico() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralConciliacaoContabilidadeAnalitico", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralConciliacaoContabilidadeAnaliticoAbertos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralConciliacaoContabilidadeAnaliticoAbertos", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function

    Public Function getCentralConciliacaoContabilidadeSintetico() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralConciliacaoContabilidadeSintetico", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getCentralPedidoPagtosConciliacao() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoPagtosConciliacao", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    Public Function insertCentralSaldoAcumuladoSAP() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralSaldoAcumuladoSAP", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function getCentralSaldoAcumuladoSAP() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralSaldoAcumuladoSAP", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
    ' Adri 18/04/2022 - Relatorio de Apoio Contabilidade - f 
    Public Function gerarPedidoTransportador() As Integer

        Dim transacao As New DataAccess
        'Dim transacao2 As New DataAccess

        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        gerarPedidoTransportador = False
        Try
            'Pega os parametros para inclusão pedido
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim pedidoitem As New PedidoItem

            With Me.pedidoitens.Rows(0)
                pedidoitem.id_central_pedido = Me.id_central_pedido_matriz
                pedidoitem.id_fornecedor = Me.id_transportador
                pedidoitem.nr_frete = .Item(0)
                pedidoitem.nr_valor_total = Me.nr_total_pedido_frete
                pedidoitem.id_modificador = Me.id_modificador
                pedidoitem.id_central_tabela_frete_veiculos = .Item(1)
            End With

            'Pega os parametros para inclusão pedido
            Dim parametersitem As List(Of Parameters) = ParametersEngine.getParametersFromObject(pedidoitem)

            'inclui pedido completo para transportador e atualiza o valor frete no pedido matriz
            gerarPedidoTransportador = CType(transacao.ExecuteScalar("ms_insertCentralPedidoeItensFrete", parametersitem, ExecuteType.Insert), Int32)

            'Comita
            transacao.Commit()
            transacao.Dispose()


        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            gerarPedidoTransportador = False
            Throw New Exception(err.Message)
        End Try
    End Function


    Public Function gerarPedidoPropriedade() As Integer

        Dim transacao As New DataAccess
        'Dim transacao2 As New DataAccess

        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        gerarPedidoPropriedade = False
        Try
            'Pega os parametros para inclusão pedido
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim pedidoitem As New PedidoItem

            'Insere pedido
            Me.id_central_pedido_matriz = CType(transacao.ExecuteScalar("ms_insertCentralPedidoFornecedor", parameters, ExecuteType.Insert), Int32)

            parameters = ParametersEngine.getParametersFromObject(Me)

            If Me.ds_tipofrete = "D" Then 'se for fob-d inclui transportador
                'Insere pedido transportador
                pedidoitem.id_central_pedido_transportador = CType(transacao.ExecuteScalar("ms_insertCentralPedidoTransportador", parameters, ExecuteType.Insert), Int32)
            Else
                pedidoitem.id_central_pedido_transportador = 0
            End If

            With Me.pedidoitens.Rows(0)
                pedidoitem.id_central_pedido = Me.id_central_pedido_matriz
                pedidoitem.id_item = .Item(0)
                pedidoitem.nr_parcelas = Me.nr_qtde_parcelas
                pedidoitem.ds_tipo_medida = .Item(2)
                pedidoitem.nr_quantidade = .Item(3)
                pedidoitem.nr_valor_unitario = .Item(4)
                pedidoitem.nr_sacaria = .Item(5)
                pedidoitem.nr_frete = .Item(9)
                pedidoitem.nr_valor_total = .Item(7)
                pedidoitem.st_parcelamento = Me.st_tipo_parcelamento
                pedidoitem.id_modificador = Me.id_modificador
                pedidoitem.id_central_tabela_preco = .Item(6)
                pedidoitem.id_central_tabela_frete_veiculos = .Item(11)
                pedidoitem.ds_tipo_frete = Me.ds_tipofrete
                pedidoitem.id_situacao_pedido = Me.id_situacao_pedido
                pedidoitem.ds_motivo_aprovacao = .Item(13)
            End With

            'Pega os parametros para inclusão pedido
            Dim parametersitem As List(Of Parameters) = ParametersEngine.getParametersFromObject(pedidoitem)

            'finaliza inclusao de itens do fornecedor e transportador, coloca para aprovação de situacao pedido = 5, e se for pedido aprovado (6) 
            'envia email fornecedor de insumos
            transacao.Execute("ms_insertCentralPedidoItens", parametersitem, ExecuteType.Insert)

            gerarPedidoPropriedade = Me.id_central_pedido_matriz
            'Comita
            transacao.Commit()
            transacao.Dispose()


        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            gerarPedidoPropriedade = False
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function gerarPedidoGrupo() As Integer

        Dim transacao As New DataAccess

        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        gerarPedidoGrupo = False
        Try
            Dim row As DataRow
            Dim pedidoitem As New PedidoItem
            Dim ldtprimparcelaprodutor As String = String.Empty
            Dim ldtultparcelaprodutor As String = String.Empty
            Dim lmotivoaprovacao As String = String.Empty
            Dim contratopropriedade As New CentralContratoPropriedade

            'Pega os parametros para inclusão pedido
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Dim pool As New CentralContrato

            'pool.id_estabelecimento = Me.id_estabelecimento
            'pool.id_fornecedor = Me.id_fornecedor
            'pool.id_item = Me.id_item
            'pool.nr_quantidade_total = Me.nr_quantidade_total
            'pool.nr_valor_unitario = Me.nr_valor_unitario
            'pool.nr_sacaria = Me.nr_sacaria
            'pool.st_tipo_central_contrato = "P"
            'pool.dt_inicio_contrato = "01/" + DateTime.Now.ToString("MM/yyyy").ToString
            'pool.dt_fim_contrato = pool.dt_inicio_contrato
            'pool.id_modificador = Me.id_modificador

            ''Pega os parametros para grupo pedido
            'Dim parameterspool As List(Of Parameters) = ParametersEngine.getParametersFromObject(pool)

            ''insere contrato pool
            'Me.id_central_contrato = CType(transacao.ExecuteScalar("ms_insertCentralContrato", parameters, ExecuteType.Insert), Int32)
            'Me.id_central_contrato = pool.id_central_contrato

            For Each row In Me.pedidoitens.Rows 'para cada propriedade
                ldtprimparcelaprodutor = String.Empty
                ldtultparcelaprodutor = String.Empty

                'completa dados para inclusao do pedido
                Me.nr_valor_limite_disponivel = row(0).ToString
                Me.st_tipo_parcelamento = row(3).ToString
                Me.nr_qtde_parcelas = row(4).ToString
                Me.id_propriedade = row(12).ToString
                If row(13).ToString.Equals(String.Empty) Then
                    Me.id_propriedade_matriz = 0
                Else
                    Me.id_propriedade_matriz = row(13).ToString
                End If
                Me.nr_total_pedido = row(7).ToString
                Me.ds_tipofrete = row(17).ToString

                If Me.ds_tipofrete = "D" Then
                    Me.id_transportador = row(5).ToString
                    Me.nr_total_pedido_frete = row(8).ToString
                Else
                    Me.id_transportador = 0
                    Me.nr_total_pedido_frete = 0
                End If

                'verifica quais datas iniciara e finalizara desconto produtor
                Me.calcularDataDescontoProdutor(DateTime.Now.ToString("dd/MM/yyyy"), Me.nr_qtde_parcelas, ldtprimparcelaprodutor, ldtultparcelaprodutor)
                'busca qual situacao pedido (aprovado ou em aprovacao)
                Me.id_situacao_pedido = Me.apurarSituacaoAprovacao(Me.nr_total_pedido + Me.nr_total_pedido_frete, Me.nr_valor_limite_disponivel, Me.st_tipo_parcelamento, Me.nr_qtde_parcelas, row(15).ToString, ldtultparcelaprodutor, Me.ds_motivo_aprovacao)

                parameters = ParametersEngine.getParametersFromObject(Me)

                'Insere pedido
                Me.id_central_pedido_matriz = CType(transacao.ExecuteScalar("ms_insertCentralPedidoFornecedor", parameters, ExecuteType.Insert), Int32)

                parameters = ParametersEngine.getParametersFromObject(Me)

                If Me.ds_tipofrete = "D" Then 'se for fob-d inclui transportador
                    'Insere pedido transportador
                    pedidoitem.id_central_pedido_transportador = CType(transacao.ExecuteScalar("ms_insertCentralPedidoTransportador", parameters, ExecuteType.Insert), Int32)
                Else
                    pedidoitem.id_central_pedido_transportador = 0
                End If
                pedidoitem.id_central_pedido = Me.id_central_pedido_matriz
                pedidoitem.id_item = Me.id_item
                pedidoitem.nr_parcelas = Me.nr_qtde_parcelas
                pedidoitem.ds_tipo_medida = row.Item(1)
                pedidoitem.nr_quantidade = row.Item(2)
                pedidoitem.nr_valor_unitario = Me.nr_valor_unitario
                pedidoitem.nr_sacaria = Me.nr_sacaria
                pedidoitem.nr_frete = row.Item(6)
                pedidoitem.st_parcelamento = Me.st_tipo_parcelamento
                pedidoitem.id_modificador = Me.id_modificador
                pedidoitem.id_central_tabela_frete_veiculos = row.Item(9)
                pedidoitem.ds_tipo_frete = Me.ds_tipofrete
                pedidoitem.id_situacao_pedido = Me.id_situacao_pedido
                pedidoitem.id_modificador = Me.id_modificador
                pedidoitem.ds_motivo_aprovacao = Me.ds_motivo_aprovacao

                'Pega os parametros para inclusão pedido
                Dim parameterspi As List(Of Parameters) = ParametersEngine.getParametersFromObject(pedidoitem)

                'finaliza inclusao de itens do fornecedor e transportador, coloca para aprovação de situacao pedido = 5, e se for pedido aprovado (6) 
                'envia email fornecedor de insumos
                transacao.Execute("ms_insertCentralPedidoItens", parameterspi, ExecuteType.Insert)

                'atualiza nr de pedidos em contrato griupo
                contratopropriedade.id_central_contrato_propriedade = row.Item(16)
                contratopropriedade.id_central_pedido = id_central_pedido_matriz
                contratopropriedade.id_central_pedido_frete = pedidoitem.id_central_pedido_transportador

                Dim parameterscontrato As List(Of Parameters) = ParametersEngine.getParametersFromObject(contratopropriedade)
                transacao.Execute("ms_updateCentralContratoPropriedadePedido", parameterscontrato, ExecuteType.Update)


            Next

            ''atualiza contrato para finalizado
            transacao.Execute("ms_updateCentralContratoSituacaoFechado", parameters, ExecuteType.Update)

            gerarPedidoGrupo = Me.id_central_pedido_matriz


            'Comita
            transacao.Commit()
            transacao.Dispose()


        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            gerarPedidoGrupo = False
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function gerarPedidoContrato() As Integer

        Dim transacao As New DataAccess
        'Dim transacao2 As New DataAccess

        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        gerarPedidoContrato = False
        Try
            'Pega os parametros para inclusão pedido
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'inclui od pedidos por contrato
            transacao.Execute("ms_insertCentralPedidobyContrato", parameters, ExecuteType.Insert)

            'atualiza o contrato como finalizado
            transacao.Execute("ms_updateCentralContratoSituacaoFechado", parameters, ExecuteType.Update)


            gerarPedidoContrato = True
            'Comita
            transacao.Commit()
            transacao.Dispose()


        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            gerarPedidoContrato = False
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Sub updatePedidoItemQtde() 'fran 08/2015

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoItemQtde", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
