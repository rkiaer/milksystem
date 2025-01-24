Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.Math



<Serializable()> Public Class CalculoProdutor

    Private _id_calculo_produtor As Int32
    Private _id_estabelecimento As Int32
    Private _id_pessoa As Int32
    Private _id_propriedade As Int32
    Private _id_unid_producao As Int32
    Private _id_propriedade_matriz As Int32 'fran 06/2021
    Private _cd_pessoa As String
    Private _ds_produtor As String
    Private _ds_propriedade As String
    Private _dt_referencia As String
    Private _dt_referencia_start As String
    Private _dt_referencia_end As String
    Private _st_tipo_pagamento As String
    Private _st_pagamento As String ' 18/11/2008 - P-Provisorio ou D-Definitivo
    Private _st_selecao As String
    Private _id_selecao As String
    Private _id_modificador As Int32
    Private _id_ficha_financeira As Int32
    Private _id_calculo_execucao As Int32
    Private _cd_analise_esalq As Int32
    Private _id_categoria As Int32
    Private _nr_valor As Decimal
    Private _fichafinanceira As New FichaFinanceira
    Private _calculoexecucao As New CalculoExecucao
    Private _nr_media_analise As Decimal   ' Adri 12/04/2010 - chamado 772 - disponibiliza a média em um campo da classe para gravar na conta 0152
    Private _nr_media_analise_geometrico_mensal As Decimal   ' Fran 12/09/2016 - para guardar teor geometrico mensal
    Private _st_gold As String   ' Fran 11/2014 projeto gold
    ' Adri 16/06/2016 - chamado 2448 - i
    Private _dt_referencia_calculogeometrico_start As String
    Private _dt_referencia_calculogeometrico_end As String
    ' Adri 16/06/2016 - chamado 2448 - f
    Private _nr_media_analise_complience As Boolean   ' Adri 19/12/2016 - Disponibiliza se média é complience ou não
    Private _nr_dias_antecipacao As Int32 'fran 07/2017
    Private _nr_litros As Int32 'fran 07/2017
    Private _id_contrato_validade As Int32 'fran 07/2017
    Private _nr_valor_juros As Decimal   ' Fran 12/2021 


    Public Property fichafinanceira() As FichaFinanceira

        Get
            Return _fichafinanceira
        End Get

        Set(ByVal value As FichaFinanceira)
            _fichafinanceira = value
        End Set
    End Property
    Public Property calculoexecucao() As CalculoExecucao

        Get
            Return _calculoexecucao
        End Get

        Set(ByVal value As CalculoExecucao)
            _calculoexecucao = value
        End Set
    End Property
    Public Property id_calculo_produtor() As Int32
        Get
            Return _id_calculo_produtor
        End Get
        Set(ByVal value As Int32)
            _id_calculo_produtor = value
        End Set
    End Property
    Public Property nr_dias_antecipacao() As Int32
        Get
            Return _nr_dias_antecipacao
        End Get
        Set(ByVal value As Int32)
            _nr_dias_antecipacao = value
        End Set
    End Property
    Public Property nr_litros() As Int32
        Get
            Return _nr_litros
        End Get
        Set(ByVal value As Int32)
            _nr_litros = value
        End Set
    End Property
    Public Property id_contrato_validade() As Int32
        Get
            Return _id_contrato_validade
        End Get
        Set(ByVal value As Int32)
            _id_contrato_validade = value
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

    Public Property id_pessoa() As Int32
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
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
    Public Property id_unid_producao() As Int32
        Get
            Return _id_unid_producao
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao = value
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
    Public Property ds_produtor() As String
        Get
            Return _ds_produtor
        End Get
        Set(ByVal value As String)
            _ds_produtor = value
        End Set
    End Property
    Public Property ds_propriedade() As String
        Get
            Return _ds_propriedade
        End Get
        Set(ByVal value As String)
            _ds_propriedade = value
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
    Public Property dt_referencia_start() As String
        Get
            Return _dt_referencia_start
        End Get
        Set(ByVal value As String)
            _dt_referencia_start = value
        End Set
    End Property
    Public Property dt_referencia_end() As String
        Get
            Return _dt_referencia_end
        End Get
        Set(ByVal value As String)
            _dt_referencia_end = value
        End Set
    End Property
    Public Property st_tipo_pagamento() As String
        Get
            Return _st_tipo_pagamento
        End Get
        Set(ByVal value As String)
            _st_tipo_pagamento = value
        End Set
    End Property
    Public Property st_pagamento() As String
        Get
            Return _st_pagamento
        End Get
        Set(ByVal value As String)
            _st_pagamento = value
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
    Public Property st_gold() As String
        Get
            Return _st_gold
        End Get
        Set(ByVal value As String)
            _st_gold = value
        End Set
    End Property
    Public Property id_selecao() As String
        Get
            Return _id_selecao
        End Get
        Set(ByVal value As String)
            _id_selecao = value
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

    Public Property id_ficha_financeira() As Int32
        Get
            Return _id_ficha_financeira
        End Get
        Set(ByVal value As Int32)
            _id_ficha_financeira = value
        End Set
    End Property
    Public Property id_calculo_execucao() As Int32
        Get
            Return _id_calculo_execucao
        End Get
        Set(ByVal value As Int32)
            _id_calculo_execucao = value
        End Set
    End Property
    Public Property cd_analise_esalq() As Int32
        Get
            Return _cd_analise_esalq
        End Get
        Set(ByVal value As Int32)
            _cd_analise_esalq = value
        End Set
    End Property
    Public Property nr_valor() As Decimal
        Get
            Return _nr_valor
        End Get
        Set(ByVal value As Decimal)
            _nr_valor = value
        End Set
    End Property
    Public Property id_categoria() As Int32
        Get
            Return _id_categoria
        End Get
        Set(ByVal value As Int32)
            _id_categoria = value
        End Set
    End Property
    ' Adri 12/04/2010 - chamado 772 - disponibiliza a média em um campo da classe para gravar na conta 0152 - i
    Public Property nr_media_analise() As Decimal
        Get
            Return _nr_media_analise
        End Get
        Set(ByVal value As Decimal)
            _nr_media_analise = value
        End Set
    End Property
    ' Adri 12/04/2010 - chamado 772 - disponibiliza a média em um campo da classe para gravar na conta 0152 - f
    Public Property nr_media_analise_complience() As Boolean   ' adri - 19/12/2016 0 curva ABC
        Get
            Return _nr_media_analise_complience
        End Get
        Set(ByVal value As Boolean)
            _nr_media_analise_complience = value
        End Set
    End Property
    Public Property nr_valor_juros() As Decimal
        Get
            Return _nr_valor_juros
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_juros = value
        End Set
    End Property
    Public Property nr_media_analise_geometrico_mensal() As Decimal
        Get
            Return _nr_media_analise_geometrico_mensal
        End Get
        Set(ByVal value As Decimal)
            _nr_media_analise_geometrico_mensal = value
        End Set
    End Property
    ' Adri 16/06/2016 - chamado 2448 - i
    Public Property dt_referencia_calculogeometrico_start() As String
        Get
            Return _dt_referencia_calculogeometrico_start
        End Get
        Set(ByVal value As String)
            _dt_referencia_calculogeometrico_start = value
        End Set
    End Property
    Public Property dt_referencia_calculogeometrico_end() As String
        Get
            Return _dt_referencia_calculogeometrico_end
        End Get
        Set(ByVal value As String)
            _dt_referencia_calculogeometrico_end = value
        End Set
    End Property
    ' Adri 16/06/2016 - chamado 2448 - f

    Public Sub New(ByVal id As String)

        Me.id_selecao = id
        loadCalculoProdutor()

    End Sub



    Public Sub New()

    End Sub


    Public Function getCalculoProdutorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoProdutor", parameters, "ms_calculo_produtor")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoAdiantamentoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoAdiantamento", parameters, "ms_calculo_produtor")
            Return dataSet

        End Using

    End Function

    Private Sub loadCalculoProdutor()

        Dim dataSet As DataSet = getCalculoProdutorByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Sub calcularAdiantamento()

        Try

            ' Status de Resultado
            ' 1 - Calculado com Erro
            ' 2 - Calculado com Sucesso
            ' 3 - Cálculo Definitivo
            ' 4 - Não Calculado
            ' 5 - Sem Preço Aprovado
            Dim li As Int32
            Dim lid_propriedade_anterior As Int32
            Dim lvalor_volumeleite As Decimal
            Dim lvalor_volumeleitemes As Decimal
            Dim lqtd_dias As Int16
            Dim ldata_atual As String
            Dim lqtd_litropordia As Decimal
            Dim lpreco_negociado As Decimal
            Dim lnr_deflator As Decimal
            Dim lvalor_rendbruto As Decimal
            Dim lvalor_saldo_disponivel As Decimal
            Dim lvalor_adiantamento As Decimal
            Dim lvalor_descontos As Decimal
            'Dim lnr_percentual_adto As Decimal
            'Dim lnr_valor_adto As Decimal

            Dim parametro As New Parametro


            ' Inicializa Ficha Financeira
            fichafinanceira.dt_referencia = Me.dt_referencia
            fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
            fichafinanceira.id_modificador = Me.id_modificador
            fichafinanceira.id_calculo_execucao = Me.id_calculo_execucao

            Me.dt_referencia_start = Me.dt_referencia
            Me.dt_referencia_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))


            Dim dsCalculoProdutor As DataSet = getCalculoProdutorAdiantamentoSelecionado()

            ' Para cada Unidade de Produção
            For li = 0 To dsCalculoProdutor.Tables(0).Rows.Count - 1

                '====================================
                ' Inicializa Unidade de Produção
                '====================================

                ' Verifica se o pagamento já foi feito pata a Unidade de Producao
                If getCalculoStatusPagamento() = "D" Then  'Se já pagou definitivo esta unidade de produção, não recalcula
                    Me.calculoexecucao.st_calculo_execucao_itens = "3"   '  Seta status 3-Pagamento Definitivo e não calcula
                    Me.calculoexecucao.insertCalculoExecucaoItens()
                Else


                    Me.id_propriedade = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_propriedade"))
                    Me.id_unid_producao = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_unid_producao"))

                    Me.calculoexecucao.st_calculo_execucao_itens = "1"   '  Seta status 1-Iniada como default
                    Me.calculoexecucao.id_propriedade = Me.id_propriedade
                    Me.calculoexecucao.id_unid_producao = Me.id_unid_producao
                    Me.calculoexecucao.insertCalculoExecucaoItens()

                    ' Grava Ficha Financeira
                    Me.fichafinanceira.id_propriedade = id_propriedade
                    Me.fichafinanceira.id_unid_producao = id_unid_producao
                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento

                    Me.fichafinanceira.deleteFichaFinanceira()   ' deleta dados provisório da propriedade/unid. Producao/dt referencia/tipo pagamento
                    Me.fichafinanceira.id_ficha_financeira = fichafinanceira.insertFichaFinanceira()

                    ' Só gera Adiantamento para a primeira Unidade de Produçao da Propriedade
                    If Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_propriedade")) <> lid_propriedade_anterior Then
                        lid_propriedade_anterior = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(0).Item("id_propriedade"))

                        '============================================
                        ' Ponto 1 - Apurar Volume de Leite da UNIDADE
                        '============================================
                        Me.id_unid_producao = 0
                        lvalor_volumeleite = getCalculoVolumeLeite()

                        ' Grava conta 0010 - Volume Leite
                        Me.fichafinanceira.cd_conta = "0010"
                        Me.fichafinanceira.nr_valor_conta = lvalor_volumeleite
                        Me.fichafinanceira.st_origem_conta = "C"
                        Me.fichafinanceira.insertFichaFinanceiraItens()

                        Me.id_unid_producao = Me.fichafinanceira.id_unid_producao

                        If lvalor_volumeleite > 0 Then  ' Não calcular (setar mensagem)

                            '==========================================
                            ' Ponto 2 -Proporcionaliza para apurar o Volume Mensal de Leite
                            '==========================================

                            If DateTime.Parse(Now).ToString("MM/yyyy") > DateTime.Parse(Me.dt_referencia).ToString("MM/yyyy") Then
                                ldata_atual = "15/" & DateTime.Parse(Me.dt_referencia).ToString("MM/yyyy")
                            Else
                                ldata_atual = DateTime.Parse(Now).ToString("dd/MM/yyyy")
                            End If
                            lqtd_dias = DateDiff(DateInterval.Day, Convert.ToDateTime(Me.dt_referencia_start), Convert.ToDateTime(ldata_atual))
                            lqtd_litropordia = lvalor_volumeleite / lqtd_dias
                            lvalor_volumeleitemes = 30 * lqtd_litropordia

                            ' Grava conta 0011 - Volume Leite Proporcionalizado
                            Me.fichafinanceira.cd_conta = "0011"
                            Me.fichafinanceira.nr_valor_conta = lvalor_volumeleitemes
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            '======================================
                            ' Ponto 3 - Apurar Preço Negociado
                            '======================================
                            lpreco_negociado = getCalculoPrecoNegociado()


                            If lpreco_negociado = 0 Then  ' Se não tem ainda aprovado preço, utiliza o do mes anterior aplicado um deflator 
                                Me.dt_referencia = DateAdd(DateInterval.Month, -1, Convert.ToDateTime(Me.dt_referencia))
                                lpreco_negociado = getCalculoPrecoNegociado()  '  Preço do mes anterior

                                If lpreco_negociado > 0 Then  ' Aplica deflator

                                    ' Grava conta 0031 - Deflator Preço Negociado
                                    Me.fichafinanceira.cd_conta = "0031"
                                    Me.fichafinanceira.nr_valor_conta = parametro.nr_deflator
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.insertFichaFinanceiraItens()

                                    ' 24/07/2008 - Deflator é em centavos
                                    'lnr_deflator = 1 - (parametro.nr_deflator / 100)  ' Ex: 17% o deflator é de 0,83
                                    'lpreco_negociado = lpreco_negociado * lnr_deflator
                                    lnr_deflator = parametro.nr_deflator
                                    lpreco_negociado = lpreco_negociado - lnr_deflator
                                End If

                                Me.dt_referencia = Me.dt_referencia_start   ' Volta referência atual
                            End If

                            ' Grava conta 0030 - Preço Negociado
                            Me.fichafinanceira.cd_conta = "0030"
                            Me.fichafinanceira.nr_valor_conta = lpreco_negociado
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.insertFichaFinanceiraItens()


                            '======================================================
                            ' Ponto 4 - Apurar Rendimento Bruto da Unidade Produção
                            '======================================================
                            'lvalor_rendbruto = Round(lvalor_volumeleite * lpreco_negociado, 2)
                            lvalor_rendbruto = Round(lvalor_volumeleitemes * lpreco_negociado, 2)

                            Me.fichafinanceira.cd_conta = "0200"  ' Grava conta - Rendimento Bruto
                            Me.fichafinanceira.nr_valor_conta = lvalor_rendbruto
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            '======================================================
                            ' Ponto 4 - Apurar o Saldo Disponível
                            '======================================================
                            lvalor_saldo_disponivel = Round(lvalor_rendbruto * (parametro.nr_perc_adto / 100), 2)

                            ' Abate Contas de Desconto
                            Me.calculoApurarLancamentos("D")   ' Gera as contas de desconto lançadas na Ficha Financeira 
                            Me.calculoApurarContasParceladas()  ' Gera as parcelas de emprestimo na Ficha Financeira

                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.id_natureza = 2  ' Desconto
                            Me.fichafinanceira.cd_conta = ""    ' Limpa a conta 
                            lvalor_descontos = Me.fichafinanceira.getFichaFinanceiraValorConta()  ' Somatório dos descontos no mes de referencia

                            lvalor_saldo_disponivel = lvalor_saldo_disponivel - lvalor_descontos

                            Me.fichafinanceira.cd_conta = "2020"  ' Grava conta - Rendimento Bruto
                            Me.fichafinanceira.nr_valor_conta = lvalor_saldo_disponivel
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            '======================================================
                            ' Ponto 6 - Gera o Adiantamento Quinzenal
                            '======================================================
                            ' 22/07/2008 - i
                            'lnr_percentual_adto = dsCalculoProdutor.Tables(0).Rows(li).Item("nr_percentual_adto")
                            'lnr_valor_adto = dsCalculoProdutor.Tables(0).Rows(li).Item("nr_valor_adto")

                            'If lnr_valor_adto > 0 Then  ' Se informou valor
                            '    lvalor_adiantamento = lvalor_rendbruto * parametro.nr_perc_adto  ' Calcula o máximo permitido
                            '    If lnr_valor_adto < lvalor_adiantamento Then
                            '        lvalor_adiantamento = lnr_valor_adto
                            '    End If
                            'Else ' Se informou percentual
                            '    lvalor_adiantamento = Round(lvalor_rendbruto * (lnr_percentual_adto / 100), 2)
                            'End If
                            lvalor_adiantamento = dsCalculoProdutor.Tables(0).Rows(li).Item("nr_valor_adto")
                            ' 22/07/2008 - f

                            Me.fichafinanceira.cd_conta = "0600"    ' Adiantamento Quinzenal
                            Me.fichafinanceira.nr_valor_conta = lvalor_adiantamento
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.insertFichaFinanceiraItens()


                            Me.calculoexecucao.st_calculo_execucao_itens = "2"   '  Seta Unidade/U.Producao = status 2-Sucesso
                            Me.calculoexecucao.updateCalculoExecucaoItens()

                        Else  ' Se não tem volume de leite

                            Me.calculoexecucao.st_calculo_execucao_itens = "4"   '  Seta Unidade/U.Producao = status 4-Não Calculado
                            Me.calculoexecucao.updateCalculoExecucaoItens()
                        End If

                    Else  ' Se ainda é mesma Propriedade, gera o adiantamento com valor zerado

                        Me.fichafinanceira.cd_conta = "0600"    ' Adiantamento Quinzenal
                        Me.fichafinanceira.nr_valor_conta = 0
                        Me.fichafinanceira.st_origem_conta = "C"
                        Me.fichafinanceira.insertFichaFinanceiraItens()

                        Me.calculoexecucao.st_calculo_execucao_itens = "2"   '  Seta Unidade/U.Producao = status 2-Sucesso
                        Me.calculoexecucao.updateCalculoExecucaoItens()

                    End If

                End If
            Next
            'Fran 18/12/2008 i  - para finalizar calculo adiantamento e nao ficar laço eterno
            ' Finaliza Cálculo
            calculoexecucao.st_calculo_execucao = "F"       ' Finalizado
            'Fran 18/12/2008 f  - para finalizar calculo adiantamento e nao ficar laço eterno
            calculoexecucao.updateCalculoExecucao()
            deleteCalculoAdiantamento()

        Catch err As Exception
            'Fran 18/12/2008 i  - para tratar erro como no calculo definitivo caso ocorra
            calculoexecucao.st_calculo_execucao = "E"       ' Finalizado com erro
            calculoexecucao.updateCalculoExecucao()
            calculoexecucao.nm_erro = err.Message
            calculoexecucao.insertCalculoExecucaoErro()
            'Fran 18/12/2008 f
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub calcularProdutor()


        Try

            ' Status de Resultado
            ' 1 - Calculado com Erro
            ' 2 - Calculado com Sucesso
            ' 3 - Cálculo Definitivo
            ' 4 - Não Calculado - Sem Volume
            ' 5 - Não Calculado - Sem Preço
            ' 6 - Não Calculado - Sem Qualidade Liberada
            ' 7 - Não Calculado - Sem Faixa Adicional de Volume

            Dim li As Int32
            Dim lid_pessoa_anterior As Int32
            Dim lid_propriedade_anterior As Int32
            Dim lvalor_conta As Decimal
            Dim lpreco_negociado As Decimal
            Dim lpreco_base As Decimal  ' 28/11/2008 (troquei o que era lpreco_variavel pelo nome lpreco_base
            Dim lpreco_notafiscal As Decimal
            Dim lpreco_unitario As Decimal
            Dim lvalor_volumeleite As Decimal
            Dim lvalor_volumeleite_referenciaanterior As Decimal ' Adri 10/07/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês 
            Dim lvalor_volumeleite_antibiotico As Decimal  ' adri 05/07/2016 - chamado 2452 - Descarte de antibiótico
            Dim lvalor_CCS As Decimal
            Dim lvalor_CTM As Decimal
            Dim lvalor_total_qualidade As Decimal
            Dim lvalor_proteina As Decimal
            Dim lvalor_gordura As Decimal 'fran 01/01/2013
            Dim lvalor_incentivofiscal As Decimal
            Dim lvalor_funrural As Decimal
            Dim lvalor_aliquota_funrural As Decimal = 0 'fran 31/01/2019
            Dim lvalor_rendbruto As Decimal
            Dim lvalor_baseICMS As Decimal
            Dim lvalor_ICMS As Decimal
            Dim lvalor_totalnota As Decimal
            Dim lvalor_totalfunrural As Decimal
            Dim lvalor_creditoICMS As Decimal
            Dim lvalor_antesPISCONFINS As Decimal
            Dim lvalor_custounitario As Decimal
            Dim lvalor_PISCOFINS As Decimal
            Dim lvalor_totalERP As Decimal
            Dim lvalor_custounitarioERP As Decimal
            Dim lvalor_subtotal_receber As Decimal
            Dim lvalor_descontos As Decimal
            Dim lvalor_descontos_antecipacao As Decimal
            Dim lvalor_bonus_poupanca As Decimal 'fran 10/2017 valor bonus + bonus extra de poupanca
            Dim lvalor_reposicao_antecipacao As Decimal 'fran 02/2019 valor reposicao de qualidade + reposicao preco 
            Dim lpercentual_ICMS As Decimal
            Dim lst_incentivo_fiscal As String
            Dim lst_considera_qualidade As String
            Dim lst_transferencia_credito As String
            Dim lid_pessoa_grupo As Int32
            Dim lst_categoria As String
            Dim lvalor_preconegociado_1q As Decimal
            Dim lvalor_preconegociado_2q As Decimal
            Dim lvalor_volumeleite_1q As Decimal
            Dim lvalor_volumeleite_2q As Decimal
            Dim lvalor_frete As Decimal
            Dim lvalor_qualidade As Decimal   ' 22/10/2008
            Dim lvalor_transferencia_ICMS As Decimal ' 22/10/2008
            Dim lvalor_incentivo_21 As Decimal ' 22/10/2008
            Dim lst_incentivo_21 As String ' 22/10/2008

            ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5 - i
            Dim lvalor_incentivo_24 As Decimal ' 22/10/2008
            Dim lst_incentivo_24 As String ' 22/10/2008
            ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5 - f
            Dim lst_uf_produtor As String ' 22/10/2008
            Dim preconegociadocooperativa As New PrecoNegociadoCooperativa
            Dim lvalor_redutase As Decimal  ' 24/11/2008
            Dim lvalor_reposicao As Decimal  ' 24/11/2008
            Dim lvalor_adiantamento As Decimal  ' 16/01/2009 (erro depois de ter liberado o rls14 para o Ricardo)
            Dim lvalor_composicao_preco As Decimal  ' 19/02/2009 Rls16
            Dim lvalor_composicao_preco_unitario As Decimal  ' 13/01/2010 - Chamado 581
            Dim lvalor_composicao_preco_total As Decimal  ' 13/01/2010 - Chamado 581
            ' 07/03/2012 - Projeto Themis - Novas Contas para Nota Fiscal no SAP - i
            Dim lbase_COFINS As Decimal
            Dim lbase_PIS As Decimal
            Dim lvalor_COFINS As Decimal
            Dim lvalor_PIS As Decimal
            ' 07/03/2012 - Projeto Themis - Novas Contas para Nota Fiscal no SAP - f
            Dim lst_gold As String  ' Adriana 22/10/2014 - Projeto GOLD (indica se a propriedade é GOLD)
            Dim lst_qualidade_liberada_calculo As String  ' Adri 16/06/2016 - chamado 2448 - Cálculo Geométrico
            Dim ltotal_complience As Int32 = 0  ' Adri 20/12/2016 - Curva ABC (variável para verificar se propriedade é complience em todas as categorias)
            Dim ltotal_contas_complience As Int32 = 0  ' fran 25/04/2017 i guarda o nr de copntas complience que foram incluidas na ficha

            'Fran 07/2017 i Variaveis para calculo por contrato
            Dim lvalor_volumetabela As Decimal 'guarda o volume de leite apurado do produtor + grupo dde relacionamento
            Dim lvalor_volumetabela_dia As Decimal 'guarda o volume de leite apurado do produtor + grupo dde relacionamento por dia
            Dim lbcontratomercado As Boolean 'guarda  se o contrato é do tipo mercado ou seja utiliza preco negociado ou contrato
            Dim lnr_adicional_volume As Int16 'grauda se o produtor tem adicional 24 ou 48
            Dim lvalor_indicador As Decimal 'guardo o valor apurado sobre o indicador de preço
            Dim lvalor_adicional24hrs As Decimal
            Dim lvalor_adicional48hrs As Decimal
            Dim lvalor_volume_total_propriedade As Decimal 'guarda o volume total da propriedade (antecipação)
            Dim lvalor_volume_antecipacao As Decimal 'guarda o volume de leite que sera antecipado
            Dim lnr_dias_referencia As Int16 'guarda o nr de dias da reefrencia
            Dim lvalor_antecipacao As Decimal 'valor apurado para antecipacao
            Dim lvalor_incentivo_24_unitario As Decimal ' 22/10/2008
            'Fran 07/2017 f Variaveis para calculo por contrato

            Dim lst_funrural As String  'fran 01/2019 i FUNRURAL 2019 - guarda a opção de recolhimento FUNRURAL: 'D' DANONE 'P' Produtor, indicando que o recolhimento é feito INTEGRALMENTE pela DANONE (FUNRURAL 1.2 + SENAR/RAT 0.3) quando D ou PARCIALMENTE (quando P) indicando que a danone so recolhe SENAR/RAT 0.3

            'fran 30/09/2018 i Alteração LEgal IMA
            Dim lvalor_IMA_taxa As Decimal = 0 'pega parametro que esta em estabelecimento do valor que deverá ser pago integralmento ao IMA por litro de leite
            Dim lvalor_IMA As Decimal = 0 'guarda valor da conta 9995
            'fran 30/09/2018 f Alteração LEgal IMA

            'fran 11/2022 - limite incentivo i
            Dim lconfiglimiteincentivo As Decimal = 657000
            Dim lnr_volume_anual_pago As Decimal = 0 'guarda o volume anual pago de janeiro até a referencia - 1 mes
            Dim lnr_volume_incentivo25 As Decimal = 0 'guarda o volume destinado a incentivo 25 (dentro do limite incentivo)
            Dim lnr_volume_incentivo24 As Decimal = 0 'guarda o volume destinado a incentivo 24 (fora do limite incentivo)
            Dim lnr_volume_saldo_limite As Decimal = 0 'guarda o saldo do limite (657000 - volume anual pago)
            Dim lbapurar24 As Boolean = False
            Dim lbapurar25 As Boolean = False
            Dim lnrvaloraux As Decimal = 0
            'fran 11/2022 - limite incentivo f


            Dim lid_situacao_pessoa_contrato As Integer 'verifica se o contrato dop produtor esta aprovado DANGO 2018
            Dim lid_situacao_indicador_preco As Integer 'guardo o valor da situacao de aprovacao indicador de preço DANGO 2018

            Dim lst_calculo_com_juros As String 'Fran 12/2021 calculo com juros
            Dim lvalor_custo_financeiro As Decimal = 0 'Fran 12/2021 calculo com juros
            Dim lunidproducaoconsolidada As Int32 = 0

            ' Inicializa Ficha Financeira
            fichafinanceira.dt_referencia = Me.dt_referencia
            fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
            fichafinanceira.id_modificador = Me.id_modificador
            fichafinanceira.id_calculo_execucao = Me.id_calculo_execucao

            Dim dsCalculoProdutor As DataSet = getCalculoProdutorSelecionado()

            'If dsCalculoProdutor.Tables(0).Rows.Count > 0 Then
            '    lid_propriedade_anterior = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(0).Item("id_propriedade"))
            'End If

            'fran 30/09/2018 i Alteração LEgal IMA
            If dsCalculoProdutor.Tables(0).Rows.Count > 0 Then
                lvalor_IMA_taxa = Convert.ToDecimal(dsCalculoProdutor.Tables(0).Rows(0).Item("nr_valor_ima"))
            End If
            'fran 30/09/2018 f Alteração LEgal IMA

            lst_gold = "N" 'fran 11/2014 i
            lst_incentivo_fiscal = "N"
            lst_considera_qualidade = "N"
            lst_transferencia_credito = "N"
            lst_incentivo_21 = "N"
            lst_incentivo_24 = "N" ' Chamado 263 - Incentivo 2,4 - Rls 17.5
            lst_categoria = "F" ' 21/10/2008  (Pessoa Física ou Jurídica)
            lpercentual_ICMS = 0
            lst_uf_produtor = ""
            Me.dt_referencia_start = Me.dt_referencia
            Me.dt_referencia_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))

            lnr_dias_referencia = Day((CDate(Me.dt_referencia).AddMonths(1)).AddDays(-1)) 'fran 07/2017 guarda os dias da referencia para ser utilizado no contrato e na antecipação se houver.
            'lnr_dias_referencia = 24 'fran 29/05/2018

            ' Adri 16/06/2016 - chamado 2448 - i
            ' Considerar as 3 últimas referências, já incluída a referência atual
            Me.dt_referencia_calculogeometrico_start = DateAdd(DateInterval.Month, -2, Convert.ToDateTime(Me.dt_referencia))
            Me.dt_referencia_calculogeometrico_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))

            lst_qualidade_liberada_calculo = "N"
            If Me.st_pagamento = "D" Then   ' Se Cálculo Definitivo
                Dim dsCalculoAnaliseEsalqLiberada As DataSet = getCalculoAnaliseEsalqLiberada()  ' 04/07/2016 - A procedure está verificando o estabelecimento
                If dsCalculoAnaliseEsalqLiberada.Tables(0).Rows.Count > 0 Then
                    'lst_qualidade_liberada_calculo = dsCalculoAnaliseEsalqLiberada.Tables(0).Rows(li).Item("st_liberado_calculo").ToString
                    lst_qualidade_liberada_calculo = dsCalculoAnaliseEsalqLiberada.Tables(0).Rows(0).Item("st_liberado_calculo").ToString  ' 06/07/2016 - Passar correção pra Fran
                End If
            Else
                lst_qualidade_liberada_calculo = "S"  ' 05/07/2016 - Enquanto o cálculo for provivório, permite a utilização das análises
            End If

            ' Adri 16/06/2016 - chamado 2448 - f

            ' Para cada Unidade de Produção
            'For li_teste = 0 To 50
            For li = 0 To dsCalculoProdutor.Tables(0).Rows.Count - 1

                ' Inicializar Dados do Produtor
                If Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_pessoa")) <> lid_pessoa_anterior Then
                    'lid_pessoa_anterior = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(0).Item("id_pessoa"))
                    lid_pessoa_anterior = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_pessoa"))  ' 07/04/2009 - Rls17.3 (não causa erro no cálculo, mas gera processamento desnecessário)

                    lid_pessoa_grupo = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_grupo"))   ' 02/12/2008 (estava fixo linha 0)
                    lst_categoria = dsCalculoProdutor.Tables(0).Rows(li).Item("st_categoria")                   ' 02/12/2008 (estava fixo linha 0)
                    'lst_incentivo_21 = dsCalculoProdutor.Tables(0).Rows(0).Item("st_incentivo_21") ' Desabilitado em 02/12/2008
                    lst_uf_produtor = dsCalculoProdutor.Tables(0).Rows(li).Item("cd_uf")                        ' 02/12/2008 (estava fixo linha 0)

                    'fran 31/01/2019 i FUNRURAL 2019 LEI 13606
                    If Not (IsDBNull(dsCalculoProdutor.Tables(0).Rows(li).Item("st_funrural"))) AndAlso dsCalculoProdutor.Tables(0).Rows(li).Item("st_funrural").ToString.Equals("P") Then
                        lst_funrural = "P" 'funrural pago pelo PRODUTOR, DANONE desconta apenas 0.3 do SENAR/RAT
                        'lvalor_aliquota_funrural = 0.3
                        lvalor_aliquota_funrural = 0.2
                    Else
                        lst_funrural = "D" 'funrural recolhido pela DANONE, DANONE desconta apenas 1.5 (0.3 do SENAR/RAT + 1.2 FUNRURAL)
                        lvalor_aliquota_funrural = 1.5
                    End If
                    'Fran 31/01/2019 f 

                    'fran 07/2017 i- calculo por contrato
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    'CALCULO POR CONTRATO - BUSCAR VARIAVEIS A CADA PRODUTOR
                    '*************************************************************************************************************************************************
                    lvalor_volumetabela = 0
                    lvalor_volumetabela_dia = 0
                    lvalor_indicador = 0
                    lvalor_adicional24hrs = 0
                    lvalor_adicional48hrs = 0
                    lid_situacao_indicador_preco = 0 'fran dango 2018
                    lid_situacao_pessoa_contrato = 0 'fran dango 2018

                    Me.id_contrato_validade = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_contrato_validade")) 'guarda o contrato validade para buscar adiconal de volume e qualidade

                    If Not (IsDBNull(dsCalculoProdutor.Tables(0).Rows(li).Item("st_contrato_mercado"))) AndAlso dsCalculoProdutor.Tables(0).Rows(li).Item("st_contrato_mercado").ToString.Equals("S") Then
                        lbcontratomercado = True 'contrato mercado, ou seja, contrato com preco negociado
                    Else
                        lbcontratomercado = False 'contrato nao mercado, ou seja, contrato com tabela de adicional de volume para buscar preco 
                    End If
                    lnr_adicional_volume = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("nr_adicional_volume")) 'adicional de volume do cadastro de pessoa com a informacao se produtor é 24hrs ou 48horas

                    'se não é contrato mercado, tem adicional de volume
                    If lbcontratomercado = False Then
                        'volume tabela contrato - buca volume referencia atual  + volume refrencia anterior + volume grupo relacionamento todas as propriedades do produtor
                        Me.id_pessoa = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_pessoa"))
                        Me.id_propriedade = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_propriedade"))
                        lvalor_volumetabela = getCalculoVolumeLeiteTabela()

                        'obtem volume tabela de contrato (soma das propriedades do produtor) por dia 
                        lvalor_volumetabela_dia = CLng(lvalor_volumetabela / lnr_dias_referencia)

                        'Fran 11/2022 i
                        'se nao tem leite por dia então nao tem volume
                        If lvalor_volumetabela_dia = 0 Then
                            Me.calculoexecucao.st_calculo_execucao_itens = "4"   '  Seta status 4-Pagamento Sem Volume leite
                            Me.calculoexecucao.id_propriedade = Me.id_propriedade
                            Me.calculoexecucao.id_unid_producao = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_unid_producao"))
                            Me.calculoexecucao.insertCalculoExecucaoItens()
                            GoTo Calcular_Proxima
                        End If
                        'Fran 11/2022 f

                        Me.nr_litros = lvalor_volumetabela_dia 'valor da conta 0015 volume por dia
                        Dim dsadicionalvolume As DataSet = Me.getCalculoContratoFaixaAdicionalVolume 'busca a faixa do adicional de volume do contrato do produtor

                        'se nao ecnontrou a faixa de volume para verificar preço
                        If dsadicionalvolume.Tables(0).Rows.Count = 0 Then
                            If Me.st_pagamento = "D" Then  ' deixar calcular sem preço aprovado somente para Provisório, para permitir a extração do relatório Cruva ABC Produtores Pagamentos
                                Me.calculoexecucao.st_calculo_execucao_itens = "7"   '  status 7-Erro: Sem Faixa de Adicional de Volume
                                Me.calculoexecucao.id_propriedade = Me.id_propriedade
                                Me.calculoexecucao.id_unid_producao = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_unid_producao"))
                                Me.calculoexecucao.insertCalculoExecucaoItens()
                                GoTo Calcular_Proxima
                            End If
                        Else
                            With dsadicionalvolume.Tables(0).Rows(0)
                                lvalor_indicador = Convert.ToDecimal(.Item("nr_valor_indicador"))
                                lid_situacao_indicador_preco = CInt(.Item("id_situacao_indicador_preco")) 'dango 2018 julho/2018 fran
                                If .Item("st_formato_24hrs").Equals("V") Then 'se o adicional 24hrs da faixa é valor
                                    lvalor_adicional24hrs = Convert.ToDecimal(.Item("nr_adicional_24hrs"))
                                Else 'se foi informado percentual do indicador de preço
                                    lvalor_adicional24hrs = Convert.ToDecimal(.Item("nr_adicional_perc_24hrs"))  'traz o valor do adicional pegando o % da faixa em relaçao ao valor do indicador de preco
                                End If
                                If .Item("st_formato_48hrs").Equals("V") Then 'se foi informado em valor
                                    lvalor_adicional48hrs = Convert.ToDecimal(.Item("nr_adicional_48hrs"))
                                Else 'se foi informado em percentual
                                    lvalor_adicional48hrs = Convert.ToDecimal(.Item("nr_adicional_perc_48hrs")) 'traz o valor em cima do indicador de preco, o percentual informado
                                End If
                            End With

                        End If

                    End If

                    'fran 07/2018 DANGO i
                    If lid_pessoa_grupo = 1 Then
                        Me.id_pessoa = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_pessoa"))
                        lid_situacao_pessoa_contrato = Me.getCalculoPessoaContratoSituacao
                    End If
                    'fran 07/2018 DANGO f

                    'fran 07/2017 f- calculo por contrato

                    '===========================================================
                    ' Release 1  (campos passaram para a entidade Propriedade)
                    '===========================================================
                    'Me.id_pessoa = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(0).Item("id_pessoa"))
                    'lst_incentivo_fiscal = getCalculoIncentivoFiscal()
                    'lst_considera_qualidade = getCalculoConsideraQualidade()

                    ' 18/11/2008 - Desabilitado i
                    'If lid_pessoa_grupo <> 4 Then   ' Se não for COOPERATIVA
                    '    ' Apura Faturamento Anual do Produtor
                    '    Me.nr_valor = Me.getCalculoVolumeProdutor()  ' Somatório do último ano da conta 1200

                    '    lpercentual_ICMS = getCalculoFaixaIncentivoFiscal()     ' Pesquisa faixa do percentual
                    'End If
                    ' 18/11/2008 - Desabilitado f
                End If

                'Fran 11/2022 i
                'se nao tem leite por dia então nao tem volume, e se for produtor contrato cepea (so tem leite por dia produtor com contrato) 
                'volumetabela é a soma de todo leite do produtor, se esta fazendo outra propriedade do mesmo produtor, verifica novamente volume
                If lvalor_volumetabela_dia = 0 And lbcontratomercado = False Then
                    Me.calculoexecucao.st_calculo_execucao_itens = "4"   '  Seta status 4-Pagamento Sem Volume leite
                    Me.calculoexecucao.id_propriedade = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_propriedade"))
                    Me.calculoexecucao.id_unid_producao = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_unid_producao"))
                    Me.calculoexecucao.insertCalculoExecucaoItens() 'insere na itens porque ainda nao incluiu esta prop
                    GoTo Calcular_Proxima
                End If
                'Fran 11/2022 f

                'fran 07/2018 DANGO i
                If lid_pessoa_grupo = 1 And Me.st_pagamento = "D" Then 'se for produtor e estiver rodando calculo definitivo

                    If lid_situacao_indicador_preco <> 4 And lbcontratomercado = False Then 'se indicador de preço que esta utilizando não está aprovado 2o nivel
                        Me.calculoexecucao.st_calculo_execucao_itens = "8"   '  status 8-Erro: Indicador de Preço não aprovado em 2o Nível
                        Me.calculoexecucao.id_propriedade = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_propriedade"))
                        Me.calculoexecucao.id_unid_producao = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_unid_producao"))
                        Me.calculoexecucao.insertCalculoExecucaoItens() 'insere na itens porque ainda nao incluiu esta prop
                        GoTo Calcular_Proxima
                    End If
                    If lid_situacao_pessoa_contrato <> 4 Then 'se o ,odelo de contrato do produtor que esta utilizando não está aprovado 2o nivel
                        Me.calculoexecucao.st_calculo_execucao_itens = "9"   '  status 9-Erro: Modelo de Contrato do Produtor não aprovado em 2o Nível
                        Me.calculoexecucao.id_propriedade = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_propriedade"))
                        Me.calculoexecucao.id_unid_producao = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_unid_producao"))
                        Me.calculoexecucao.insertCalculoExecucaoItens() 'insere na itens porque ainda nao incluiu esta prop
                        GoTo Calcular_Proxima
                    End If

                End If
                'fran 07/2018 DANGO f


                ' Inicializar Dados da Propriedade

                '====================================
                ' Inicializa Unidade de Produção
                '====================================

                Me.id_estabelecimento = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_estabelecimento"))  ' 18/11/2008
                Me.id_pessoa = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_pessoa"))
                Me.id_propriedade = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_propriedade"))
                Me.id_unid_producao = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_unid_producao"))
                Me.id_propriedade_matriz = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_propriedade_matriz")) 'fran 06/2021
                lst_calculo_com_juros = dsCalculoProdutor.Tables(0).Rows(li).Item("st_calculo_com_juros") 'fran 12/2021

                ' Verifica se o pagamento já foi feito pata a Unidade de Producao
                If getCalculoStatusPagamento() = "D" Then  'Se já pagou definitivo esta unidade de produção, não recalcula
                    Me.calculoexecucao.st_calculo_execucao_itens = "3"   '  Seta status 3-Pagamento Definitivo e não calcula
                    Me.calculoexecucao.id_propriedade = Me.id_propriedade       ' 18/11/2008
                    Me.calculoexecucao.id_unid_producao = Me.id_unid_producao   ' 18/11/2008
                    Me.calculoexecucao.insertCalculoExecucaoItens()
                Else

                    '===========================================================
                    ' Release 1  (campos passaram para a entidade Propriedade)
                    '===========================================================
                    lst_incentivo_fiscal = getCalculoIncentivoFiscal()
                    lst_considera_qualidade = getCalculoConsideraQualidade()
                    lst_transferencia_credito = getCalculoTransferenciaCredito()  ' 21/10/2008

                    'fran 11/2014 projeto gold  i
                    If IsDBNull(dsCalculoProdutor.Tables(0).Rows(li).Item("st_gold")) Then
                        lst_gold = "N"   ' Assume 'N'
                    Else
                        lst_gold = dsCalculoProdutor.Tables(0).Rows(li).Item("st_gold")
                    End If
                    'fran 11/2014 projeto gold  f

                    ' 16/02/2009 - Rls16 - i
                    'lst_incentivo_21 = dsCalculoProdutor.Tables(0).Rows(li).Item("st_incentivo_21") ' 02/12/2008
                    If IsDBNull(dsCalculoProdutor.Tables(0).Rows(li).Item("st_incentivo_21")) Then
                        lst_incentivo_21 = "N"   ' Assume 'N'
                    Else
                        lst_incentivo_21 = dsCalculoProdutor.Tables(0).Rows(li).Item("st_incentivo_21") ' 02/12/2008
                    End If
                    ' 16/02/2009 - Rls16 - f

                    ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5 - i
                    If IsDBNull(dsCalculoProdutor.Tables(0).Rows(li).Item("st_incentivo_24")) Then
                        lst_incentivo_24 = "N"   ' Assume 'N'
                    Else
                        lst_incentivo_24 = dsCalculoProdutor.Tables(0).Rows(li).Item("st_incentivo_24")
                    End If
                    ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5 - f

                    Me.calculoexecucao.st_calculo_execucao_itens = "1"   '  Seta status 1-Iniada como default
                    Me.calculoexecucao.id_propriedade = Me.id_propriedade
                    Me.calculoexecucao.id_unid_producao = Me.id_unid_producao
                    Me.calculoexecucao.insertCalculoExecucaoItens()

                    ' 22/10/2008 - i
                    'lpercentual_ICMS = 0.05     ' Criar método para descobrir o percentual (5, 10 ou 20)
                    If lst_incentivo_fiscal = "N" Then  ' Se não tem incentivo fiscal 
                        lpercentual_ICMS = 0
                    Else
                        If lst_uf_produtor = "RJ" Then
                            lst_incentivo_fiscal = "N"      ' RJ não possui incentivo Fiscal
                            lpercentual_ICMS = 0
                        Else

                            Select Case lst_incentivo_fiscal
                                Case "A"
                                    lpercentual_ICMS = 0.05
                                Case "B"
                                    lpercentual_ICMS = 0.1
                                Case "C"
                                    lpercentual_ICMS = 0.2
                            End Select

                        End If
                    End If
                    ' 22/10/2008 - f
                    lvalor_conta = 0
                    lpreco_negociado = 0
                    lpreco_base = 0
                    lpreco_notafiscal = 0
                    lpreco_unitario = 0
                    lvalor_volumeleite = 0
                    lvalor_CCS = 0
                    lvalor_CTM = 0
                    lvalor_proteina = 0
                    lvalor_gordura = 0 'fran 01/01/2014
                    lvalor_total_qualidade = 0
                    lvalor_incentivofiscal = 0
                    lvalor_funrural = 0
                    lvalor_rendbruto = 0
                    lvalor_baseICMS = 0
                    lvalor_ICMS = 0
                    lvalor_totalnota = 0
                    lvalor_totalfunrural = 0
                    lvalor_creditoICMS = 0
                    lvalor_antesPISCONFINS = 0
                    lvalor_custounitario = 0
                    lvalor_PISCOFINS = 0
                    lvalor_totalERP = 0
                    lvalor_custounitarioERP = 0
                    lvalor_subtotal_receber = 0
                    lvalor_volumeleite_1q = 0
                    lvalor_volumeleite_2q = 0
                    lvalor_preconegociado_1q = 0
                    lvalor_preconegociado_2q = 0
                    lvalor_frete = 0
                    lvalor_transferencia_ICMS = 0
                    lvalor_incentivo_21 = 0
                    lvalor_incentivo_24 = 0  ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5
                    lvalor_incentivo_24_unitario = 0
                    ltotal_complience = 0 'fran 25/04/2017
                    ltotal_contas_complience = 0 'fran 25/04/2017
                    lvalor_IMA = 0 'fran 30/09/2018 i
                    lvalor_custo_financeiro = 0
                    lnr_volume_anual_pago = 0 'fran 11/2022
                    lnr_volume_incentivo25 = 0 'fran 11/2022
                    lnr_volume_incentivo24 = 0 'fran 11/2022
                    lnr_volume_saldo_limite = 0 'fran 11/2022
                    lbapurar24 = False
                    lbapurar25 = False


                    ' Grava Ficha Financeira
                    Me.fichafinanceira.id_propriedade = id_propriedade
                    Me.fichafinanceira.id_unid_producao = id_unid_producao
                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento

                    Me.fichafinanceira.deleteFichaFinanceira()   ' deleta dados provisório da propriedade/unid. Producao/dt referencia/tipo pagamento 

                    ' Adri - 20/06/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês - i
                    'lvalor_volumeleite = getCalculoVolumeLeite()  ' 28/11/2008 - Para cálculo definitivo somente pode ser gerado nota se tem volume
                    If Me.st_pagamento = "D" Then  'Se Cálculo Definitivo
                        Me.updateCalculoVolumeLeitePago()  ' Atualiza coluna st_leite_pago_referencia com 'S'
                        lvalor_volumeleite = getCalculoVolumeLeiteDefinitivo()  ' Só traz os volumes que participaram no update anterior
                    Else
                        lvalor_volumeleite = getCalculoVolumeLeite()  ' 28/11/2008 - Para cálculo definitivo somente pode ser gerado nota se tem volume
                    End If

                    ' 10/07/2016 - Obtem o volume de leite da referência anterior que não entrou para o cálculo, para gerar conta 0011
                    lvalor_volumeleite_referenciaanterior = getCalculoVolumeLeiteReferenciaAnterior()
                    ' Adri - 20/06/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês - f

                    ' Chamado 243 - 28/04/2009 Rls 17.5 - Não gerar Nota Fiscal quando também não há Preço Negociado - i
                    ''===============================================================
                    '' Ponto 0 - 18/11/2008 Apurar N.o da Nota Fiscal (se Cálculo Definitivo e for Produtor)
                    ''===============================================================
                    'If Me.st_pagamento = "D" And lid_pessoa_grupo <> 4 Then   ' Se Cálculo Definitivo e Produtor
                    '    If lvalor_volumeleite > 0 Then  ' 28/11/2008 - só pegar próximo número se tem volume leite
                    '        Me.fichafinanceira.nr_nota_fiscal = Me.getCalculoNumeroNotaFiscal()
                    '        If IsDBNull(dsCalculoProdutor.Tables(0).Rows(li).Item("nr_serie")) Then
                    '            Me.fichafinanceira.nr_serie = ""
                    '        Else
                    '            Me.fichafinanceira.nr_serie = dsCalculoProdutor.Tables(0).Rows(li).Item("nr_serie")
                    '        End If
                    '    Else
                    '        Me.fichafinanceira.nr_nota_fiscal = ""  ' 28/11/2008
                    '        Me.fichafinanceira.nr_serie = ""        ' 28/11/2008
                    '    End If
                    'End If

                    'If Me.st_pagamento = "D" And lid_pessoa_grupo <> 4 Then   ' Se Cálculo Definitivo e Produtor
                    If Me.st_pagamento = "D" Then   ' 31/08/2009 - Rls19.1 - Se Cálculo Definitivo (sempre limpar a n.o da Nota pois estava ficando com o do útlimo Produtor
                        Me.fichafinanceira.nr_nota_fiscal = ""
                        Me.fichafinanceira.nr_serie = ""
                    End If
                    ' Chamado 243 - 28/04/2009 Rls 17.5 - Não gerar Nota Fiscal quando também não há Preço Negociado - f


                    ' adri 06/03/2013 Chamado 1678 (Iniciar o cáluclo como P - Provisório e somente no final fazer update para D - Definitivo ) - erro pego com time-out no meio do processo - i
                    'Me.fichafinanceira.st_pagamento = Me.st_pagamento  ' 18/11/2008 (P - Provisório ou D - Definitivo )
                    Me.fichafinanceira.st_pagamento = "P"
                    Me.fichafinanceira.id_contrato_validade_pessoa = Me.id_contrato_validade
                    Me.fichafinanceira.id_ficha_financeira = fichafinanceira.insertFichaFinanceira()
                    Me.fichafinanceira.st_pagamento = Me.st_pagamento
                    ' adri 06/03/2013 Chamado 1678 (Volta o status para não interferir em outras rotinas ) - f

                    '======================================
                    ' Ponto 1 - Apurar Volume de Leite
                    '======================================
                    'lvalor_volumeleite = getCalculoVolumeLeite()   ' 28/11/2008 - Deslocado para antes do ponto 0
                    lvalor_volumeleite = lvalor_volumeleite + lvalor_volumeleite_referenciaanterior ' 26/07/2016 - A conta 0010 deve ser gravada com o saldo de volume de leite não pago do mes anterior, para bater com o Extrato e Nota Fiscal

                    ' Grava conta 0010 - Volume Leite
                    Me.fichafinanceira.cd_conta = "0010"
                    Me.fichafinanceira.nr_valor_conta = lvalor_volumeleite
                    Me.fichafinanceira.st_origem_conta = "C"
                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                    Me.fichafinanceira.insertFichaFinanceiraItens()

                    ' Adri 10/07/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês - i
                    ' Grava conta 0011 - Volume Leite
                    Me.fichafinanceira.cd_conta = "0011"
                    Me.fichafinanceira.nr_valor_conta = lvalor_volumeleite_referenciaanterior
                    Me.fichafinanceira.st_origem_conta = "C"
                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                    Me.fichafinanceira.insertFichaFinanceiraItens()
                    'lvalor_volumeleite = lvalor_volumeleite + lvalor_volumeleite_referenciaanterior  ' Para pagar na referência o que não foi pago no mês anterior
                    ' Adri 10/07/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês - f

                    'fran 07/2017 i
                    'volume total todas as propriedades do produtor + do grupo de relacionamento da referencia atual e da referencia anterior que nao foi pago
                    Me.fichafinanceira.cd_conta = "0014"
                    Me.fichafinanceira.nr_valor_conta = lvalor_volumetabela
                    Me.fichafinanceira.st_origem_conta = "C"
                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                    Me.fichafinanceira.insertFichaFinanceiraItens()

                    'volume por dia - conta 0014 dividido pelo nr de dias da referencia de calculo
                    Me.fichafinanceira.cd_conta = "0015"
                    Me.fichafinanceira.nr_valor_conta = lvalor_volumetabela_dia
                    Me.fichafinanceira.st_origem_conta = "C"
                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                    Me.fichafinanceira.insertFichaFinanceiraItens()
                    'fran 07/2017 f

                    'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4
                    'FRAN 11/2022
                    '=====================================================
                    'APURAR VOLUME LEITE INCENTIVO SE TIVER ICENTIVO
                    If lvalor_volumeleite > 0 Then
                        If lst_incentivo_fiscal <> "N" Then 'se  tem incentivo 2.5
                            'se tem incentivo deve verificar limite incentivo da propriedade
                            Me.dt_referencia_start = String.Concat("01/01/", Right(Me.dt_referencia, 4))
                            Me.dt_referencia_end = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(Me.dt_referencia))
                            Me.id_unid_producao = 0
                            'busca o volume pago ate o mes anterior e retira o valor da conta 11 (porque este volume deve entrar no mes atual)
                            lnr_volume_anual_pago = Math.Truncate(getCalculoVolumeLeite() - lvalor_volumeleite_referenciaanterior)

                            lnr_volume_saldo_limite = lconfiglimiteincentivo - lnr_volume_anual_pago

                            'se o valor anual da propriedade já for maior ou igual ao limite de incentivo
                            If lnr_volume_anual_pago >= lconfiglimiteincentivo Then
                                'assume que o volume da referencia é todo 2,4
                                lnr_volume_incentivo24 = lvalor_volumeleite
                                lnr_volume_incentivo25 = 0
                                lbapurar24 = True 'forca apuração 2.4
                                lbapurar25 = False

                                If lst_categoria = "J" Then
                                    lnr_volume_incentivo24 = 0
                                    lbapurar24 = False
                                End If
                            Else
                                If lvalor_volumeleite <= lnr_volume_saldo_limite Then
                                    lnr_volume_incentivo25 = lvalor_volumeleite
                                    lnr_volume_incentivo24 = 0
                                    lbapurar24 = False
                                    lbapurar25 = True
                                Else
                                    If lst_categoria = "J" Then
                                        lnr_volume_incentivo25 = 0
                                        lnr_volume_incentivo24 = 0
                                        lbapurar24 = False 'forca apuração 2.4
                                        lbapurar25 = False
                                    Else
                                        lnr_volume_incentivo25 = lnr_volume_saldo_limite
                                        lnr_volume_incentivo24 = lvalor_volumeleite - lnr_volume_saldo_limite
                                        lbapurar24 = True 'forca apuração 2.4
                                        lbapurar25 = True
                                    End If
                                End If
                            End If

                            'retorna variaveis
                            Me.dt_referencia_start = Me.dt_referencia
                            Me.dt_referencia_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))
                            Me.id_unid_producao = Me.fichafinanceira.id_unid_producao

                            ' Grava conta 0016 - Volume Leite Incentivo 2,5%
                            Me.fichafinanceira.cd_conta = "0016"
                            Me.fichafinanceira.nr_valor_conta = lnr_volume_incentivo25
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            ' Grava conta 0017 - Volume Leite Incentivo 2,4%
                            Me.fichafinanceira.cd_conta = "0017"
                            Me.fichafinanceira.nr_valor_conta = lnr_volume_incentivo24
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            ' Grava conta 0018 - Volume Leite Pago Anual M-1
                            Me.fichafinanceira.cd_conta = "0018"
                            Me.fichafinanceira.nr_valor_conta = lnr_volume_anual_pago
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                        End If
                    End If

                    ''FRAN 11/2022 f
                    ''=====================================================

                    If lvalor_volumeleite > 0 Then  ' Não calcular (setar mensagem)

                        If lid_pessoa_grupo = 4 Then   ' Se for COOPERATIVA

                            '==============================================
                            ' Ponto 1 - Apurar Volume de Leite 1.a Q 2.a Q
                            '==============================================
                            Me.dt_referencia_start = Me.dt_referencia
                            Me.dt_referencia_end = "15/" & DateTime.Parse(Me.dt_referencia).ToString("MM/yyyy")
                            lvalor_volumeleite_1q = getCalculoVolumeLeite()

                            ' Grava conta 0012 - Volume Leite 1Q
                            Me.fichafinanceira.cd_conta = "0012"
                            Me.fichafinanceira.nr_valor_conta = lvalor_volumeleite_1q
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.dt_referencia_start = "16/" & DateTime.Parse(Me.dt_referencia).ToString("MM/yyyy")
                            Me.dt_referencia_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))
                            lvalor_volumeleite_2q = getCalculoVolumeLeite()

                            ' Grava conta 0013 - Volume Leite
                            Me.fichafinanceira.cd_conta = "0013"
                            Me.fichafinanceira.nr_valor_conta = lvalor_volumeleite_2q
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            ' Volta configuracao
                            Me.dt_referencia_start = Me.dt_referencia
                            Me.dt_referencia_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))

                            '====================================================
                            ' Ponto 2 - Apurar Preço Negociado 1.q, 2.a q e frete
                            '====================================================
                            preconegociadocooperativa.id_pessoa = Me.id_pessoa
                            preconegociadocooperativa.dt_referencia = Me.dt_referencia
                            Dim dsPrecoNegociadoCooperativa As DataSet = preconegociadocooperativa.getPrecoNegociadoCooperativaByFilters()

                            If dsPrecoNegociadoCooperativa.Tables(0).Rows.Count > 0 Then
                                'lvalor_preconegociado_1q = Convert.ToDecimal(dsPrecoNegociadoCooperativa.Tables(0).Rows(li).Item("nr_preco_negociado_1q"))
                                lvalor_preconegociado_1q = Convert.ToDecimal(dsPrecoNegociadoCooperativa.Tables(0).Rows(0).Item("nr_preco_negociado_1q"))  ' 31/08/2009 - Chamado 421 - Deveria estar pegando a linha 0

                                ' Grava conta 0032 - Preço Negociado 1q
                                Me.fichafinanceira.cd_conta = "0032"
                                Me.fichafinanceira.nr_valor_conta = lvalor_preconegociado_1q
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' Grava conta 0201 - Rendimento Bruto 1.a q
                                lvalor_conta = Round(lvalor_volumeleite_1q * lvalor_preconegociado_1q, 2)
                                Me.fichafinanceira.cd_conta = "0201"
                                Me.fichafinanceira.nr_valor_conta = lvalor_conta
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'lvalor_preconegociado_2q = Convert.ToDecimal(dsPrecoNegociadoCooperativa.Tables(0).Rows(li).Item("nr_preco_negociado_2q"))
                                lvalor_preconegociado_2q = Convert.ToDecimal(dsPrecoNegociadoCooperativa.Tables(0).Rows(0).Item("nr_preco_negociado_2q"))  ' 31/08/2009 - Chamado 421 - Deveria estar pegando a linha 0

                                ' Grava conta 0033 - Preço Negociado 2q
                                Me.fichafinanceira.cd_conta = "0033"
                                Me.fichafinanceira.nr_valor_conta = lvalor_preconegociado_2q
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' Grava conta 0202 - Rendimento Bruto 2.a q
                                lvalor_conta = Round(lvalor_volumeleite_2q * lvalor_preconegociado_2q, 2)
                                Me.fichafinanceira.cd_conta = "0202"
                                Me.fichafinanceira.nr_valor_conta = lvalor_conta
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' Frete
                                'lvalor_frete = Convert.ToDecimal(dsPrecoNegociadoCooperativa.Tables(0).Rows(li).Item("nr_valor_frete"))
                                lvalor_frete = Convert.ToDecimal(dsPrecoNegociadoCooperativa.Tables(0).Rows(0).Item("nr_valor_frete"))  ' 31/08/2009 - Chamado 421 - Deveria estar pegando a linha 0

                                ' Grava conta 0034 - Valor do Frete
                                Me.fichafinanceira.cd_conta = "0034"
                                Me.fichafinanceira.nr_valor_conta = lvalor_frete
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' Planta R$/Litros  (Preço Negociado + Frete)
                                lvalor_conta = lvalor_preconegociado_1q + lvalor_frete

                                ' Grava conta 0901 - Valor do Planta R$/litros 1q
                                Me.fichafinanceira.cd_conta = "0901"
                                Me.fichafinanceira.nr_valor_conta = lvalor_conta
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                lvalor_conta = lvalor_preconegociado_2q + lvalor_frete

                                ' Grava conta 0902 - Valor do Planta R$/litros 2q
                                Me.fichafinanceira.cd_conta = "0902"
                                Me.fichafinanceira.nr_valor_conta = lvalor_conta
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' 17/09/2008 (Frete x Volume )
                                lvalor_conta = lvalor_volumeleite_1q * lvalor_frete

                                ' Grava conta 0951 - Valor do Frete x Volume  1q
                                Me.fichafinanceira.cd_conta = "0951"
                                Me.fichafinanceira.nr_valor_conta = lvalor_conta
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                lvalor_conta = lvalor_volumeleite_2q * lvalor_frete

                                ' Grava conta 0952 - Valor do Frete x Volume  2q
                                Me.fichafinanceira.cd_conta = "0952"
                                Me.fichafinanceira.nr_valor_conta = lvalor_conta
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                            End If

                        End If   ' Fim - Se for Cooperativa

                        If lid_pessoa_grupo = 1 Then   ' Se for Produtor
                            '==========================================================================================
                            ' Ponto 1-a - Apurar lançamentos venciomentos/descontos (só para a 1.a Unidade de Produção)
                            '==========================================================================================

                            lvalor_volumeleite_antibiotico = 0  ' Adri 05/07/2016 - Inicializa volume de antibiótico para cada Prop/UP (pq só vai calcular para a 1.a UP)

                            If Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_propriedade")) <> lid_propriedade_anterior Then
                                'lid_propriedade_anterior = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(0).Item("id_propriedade"))
                                lid_propriedade_anterior = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_propriedade"))  ' 01/06/2009 - Chamado 280 - Lançamentos para Central de Compras replicado para as Unidades de Produção


                                Me.calculoApurarLancamentos("T")  ' Gera as contas lançadas na Ficha Financeira (As contas Informadas prevalecem às contas Calculadas)

                                Me.calculoApurarContasParceladas()  ' Gera as parcelas de emprestimo na Ficha Financeira

                                ' Desabilitado em 10/11/2009, pq as contas devem ser geradas na ms_lancamentos qdo o pedido for finalizado (para entrar no cálculo de Saldo Disponível) - l
                                'Me.calculoApurarDescontosCentral()   ' 03/11/2009 - Rls22 Central de Compras - Gera as contas de desconto lançadas na Central de Compras

                                '=======================================================================================
                                ' 13/01/2009 - Ponto 11 - Gerar Valor do Adiantamento (Só para a 1.a Unidade de Produção)
                                '=======================================================================================
                                'Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                                'Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                                'Me.fichafinanceira.cd_conta = "0600"   ' Conta de Adiantamento
                                'Me.fichafinanceira.st_tipo_pagamento = "Q"
                                'lvalor_conta = Me.fichafinanceira.getFichaFinanceiraValorConta()
                                lvalor_adiantamento = Me.getCalculoValorAdiantamento()  'Busca diretamente da tabela ms_adiantamento se aprovado

                                '======================================================================================================
                                ' 05/07/2016 - adri chamado 2452 - Gerar Volume de Descarte de Antibiótivo (Só para a 1.a Unidade de Produção)

                                '======================================================================================================
                                Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                                Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.id_natureza = 3  ' Natureza 3-Outros
                                Me.fichafinanceira.cd_conta = "0114"    ' Conta "0114" gerada no processo de romaneio
                                Me.fichafinanceira.st_qtd_valor = "Q"  ' Contas lançadas em Quantidade (volume de leite descartado) 
                                lvalor_volumeleite_antibiotico = Me.fichafinanceira.getFichaFinanceiraValorConta()  ' Somatório das contas 0114 com a litragem descartada por antibiótico,  no mes de referencia
                                Me.fichafinanceira.st_qtd_valor = ""
                                Me.fichafinanceira.id_natureza = 0

                                'fran 07/2017 i
                                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                                'ANTECIPAÇÂO DE VALOR DE CALCULO
                                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                                lvalor_volume_antecipacao = 0
                                lvalor_volume_total_propriedade = 0

                                'fran 11/2022 i faz semptre total volume propriedade para usar tbm na composicao preco i
                                'busca o volume total da referencia atual e da anterior (conta0011) para todas as UPS da propriedade
                                lvalor_volume_total_propriedade = Me.getCalculoVolumeLeitebyPropriedade
                                'fran 11/2022 f faz semptre total volume propriedade para isar na composicao preco i

                                'Se deve fazer antecipação de cálculo na nota
                                'If Me.nr_dias_antecipacao > 0 Then 'fran 12/2021
                                If lst_calculo_com_juros = "N" AndAlso Me.nr_dias_antecipacao > 0 Then 'fran 12/2021
                                    'busca o volume total da referencia atual e da anterior (conta0011) para todas as UPS da propriedade
                                    'lvalor_volume_total_propriedade = Me.getCalculoVolumeLeitebyPropriedade fran 11/2022
                                    'lvalor_volume_antecipacao = CLng((lvalor_volume_total_propriedade / lnr_dias_referencia) * Me.nr_dias_antecipacao)
                                    lvalor_volume_antecipacao = getCalculoVolumeLeiteAntecipacaobyPropriedade()
                                End If
                                'fran 07/2017 f

                            End If

                            '======================================
                            ' Ponto 2 - Apurar Preço Negociado
                            '======================================

                            ' Adriana 22/10/2014 - Projeto GOLD - i
                            'lvalor_conta = getCalculoPrecoNegociado()
                            If lst_gold = "S" Then
                                'fran 29/05/2018 i se for provisorio deixa trazer preco negociado
                                'lvalor_conta = getCalculoPrecoGold()
                                If Me.st_pagamento = "D" Then
                                    lvalor_conta = getCalculoPrecoGold()
                                Else
                                    lvalor_conta = getCalculoPrecoGoldProvisorio() 'Busca no preço negociado o que nao seja rejeitado
                                End If
                                'fran 29/05/2018 f se for provisorio deixa trazer preco negociado
                            Else
                                'fran 07/2017 i 
                                'se não é contrato mercado, tem adicional de volume
                                If lbcontratomercado = False Then
                                    ' Grava conta 0025 - Valor Indicador de Mercado Conforme contrato (aplicando percentuais se necessario)
                                    Me.fichafinanceira.cd_conta = "0025"
                                    Me.fichafinanceira.nr_valor_conta = lvalor_indicador
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                    ' Grava conta 0026 - Valor Adicional 24 hrs
                                    Me.fichafinanceira.cd_conta = "0026"
                                    Me.fichafinanceira.nr_valor_conta = lvalor_adicional24hrs
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                    ' Grava conta 0027 - Valor Adicional 48 hrs
                                    Me.fichafinanceira.cd_conta = "0027"
                                    Me.fichafinanceira.nr_valor_conta = lvalor_adicional48hrs
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()

                                    'se o adicional do produtor é 48 hrs, soma ao valor do indicador de preco o adicional para 48hrs
                                    If lnr_adicional_volume = 48 Then
                                        lvalor_conta = lvalor_indicador + lvalor_adicional48hrs
                                    Else 'se o adicional do produtor é 24 hrs, soma ao valor do indicador de preco o adicional para 24hrs
                                        lvalor_conta = lvalor_indicador + lvalor_adicional24hrs
                                    End If
                                Else
                                    'fran 07/2017 f
                                    'fran 29/05/2018 i se for provisorio deixa trazer preco negociado
                                    'lvalor_conta = getCalculoPrecoNegociado()
                                    If Me.st_pagamento = "D" Then
                                        lvalor_conta = getCalculoPrecoNegociado()
                                    Else
                                        lvalor_conta = getCalculoPrecoNegociadoProvisorio() 'Busca no preço negociado o que nao seja rejeitado
                                    End If
                                    'fran 29/05/2018 f se for provisorio deixa trazer preco negociado

                                End If

                            End If
                            ' Adriana 22/10/2014 - Projeto GOLD - i

                            lpreco_negociado = lvalor_conta
                            lpreco_base = lpreco_negociado ' Inicia apuração do preço da Nota Fiscal

                            ' Grava conta 0030 - Preço Negociado
                            Me.fichafinanceira.cd_conta = "0030"
                            Me.fichafinanceira.nr_valor_conta = lvalor_conta
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            ' 20/01/2009 - Rls15 - Se não tem preço aprovado, setar erro e não calcular - i
                            If lpreco_negociado <= 0 Then

                                If Me.st_pagamento = "D" Then  ' adri 14/02/2017 - chamado 2502 - deixar calcular sem preço aprovado somente para Provisório, para permitir a extração do relatório Cruva ABC Produtores Pagamentos
                                    Me.calculoexecucao.st_calculo_execucao_itens = "5"   '  Seta Unidade/U.Producao = status 5-Erro: Sem Preço Aprovado
                                    Me.calculoexecucao.updateCalculoExecucaoItens()
                                    ' chamado 2451 - adri 26/07/2016 - Volta coluna st_leite_pago_referencia para Null - i
                                    'If Me.st_pagamento = "D" Then  'Se Cálculo Definitivo
                                    Me.updateCalculoVolumeLeitePagoDesfazer()
                                    'End If
                                    ' chamado 2451 - adri 26/07/2016 - Volta coluna st_leite_pago_referencia para Null - f

                                    GoTo Calcular_Proxima
                                End If
                            End If
                            ' 20/01/2009 - Rls15 - Se não tem preço aprovado, setar erro e não calcular - i

                            ' fran 12/2021 - i
                            If lst_calculo_com_juros = "S" AndAlso Not Me.nr_valor_juros > 0 Then
                                Me.calculoexecucao.st_calculo_execucao_itens = "0"   '  Staxa de juros nao cadastrda
                                Me.calculoexecucao.updateCalculoExecucaoItens()

                                GoTo Calcular_Proxima
                            End If
                            ' fran 12/2021 - f


                            '======================================================================================================
                            ' 05/07/2016 - adri chamado 2452 - Gerar Valor de Descarte de Antibiótivo (conta de Reposição)
                            '======================================================================================================
                            ' Grava conta 0104 - Volume Rejeitado - Desconto (conta de Reposição no valor Total)
                            If lvalor_volumeleite_antibiotico > 0 Then ' Se tem volume de descarte de antibiótico para ser descontado como Reposição
                                Me.fichafinanceira.cd_conta = "0104"
                                'fran 1/08/2016 i valor do antibiotico deve subtrair na composicao lkeite
                                'Me.fichafinanceira.nr_valor_conta = lvalor_volumeleite_antibiotico * lpreco_negociado
                                Me.fichafinanceira.nr_valor_conta = -(lvalor_volumeleite_antibiotico * lpreco_negociado)
                                'fran 1/08/2016 f
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If


                            '======================================
                            ' Ponto 3 - Apurar Índices da Qualidade 
                            '======================================

                            If lst_considera_qualidade = "S" Then

                                ltotal_complience = 0  ' adri 20/12/2016 - Curva ABC (zera variável para verificar se todas as categorias são complience)

                                ' Adri 16/06/2016 - chamado 2448 - Cálculo Geométrico - Verifica se qualidade liberada para a referência - i
                                If lst_qualidade_liberada_calculo = "N" Then
                                    Me.calculoexecucao.st_calculo_execucao_itens = "6"   '  Seta Unidade/U.Producao = status 6-Erro: Sem Qualidade Liberada
                                    Me.calculoexecucao.updateCalculoExecucaoItens()
                                    ' chamado 2451 - adri 26/07/2016 - Volta coluna st_leite_pago_referencia para Null - i
                                    If Me.st_pagamento = "D" Then  'Se Cálculo Definitivo
                                        Me.updateCalculoVolumeLeitePagoDesfazer()
                                    End If
                                    ' chamado 2451 - adri 26/07/2016 - Volta coluna st_leite_pago_referencia para Null - f

                                    GoTo Calcular_Proxima
                                End If
                                ' 20/01/2009 - Rls15 - Se não tem preço aprovado, setar erro e não calcular - i


                                ' Fran 11/2014 - Projeto GOLD - i
                                'seta a propriedade gold para utilizar na rotina de faixa de qualidade 
                                If lst_gold = "S" Then
                                    Me.st_gold = "S"
                                Else
                                    Me.st_gold = "N"
                                End If
                                ' Fran 11/2014 - Projeto GOLD - f

                                'fran 30/11/2009 i maracanau chamdo 524
                                Me.id_estabelecimento = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_estabelecimento"))
                                'fran 30/11/2009 f maracanau chamdo 524
                                Me.cd_analise_esalq = 11    ' Apura Proteína
                                Me.id_categoria = 3 ' Categora 3-Proteína

                                lvalor_proteina = Me.apurarIndiceQualidade()
                                lpreco_base = lpreco_base + lvalor_proteina  ' bonus ou desconto no preco

                                If lvalor_proteina >= 0 Then
                                    Me.fichafinanceira.cd_conta = "0080"  ' Grava conta 0080 - Bônus Proteína
                                Else
                                    Me.fichafinanceira.cd_conta = "0081"  ' Grava conta 0081 - Desconto Proteína
                                End If
                                Me.fichafinanceira.nr_valor_conta = lvalor_proteina
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                lvalor_total_qualidade = lvalor_total_qualidade + lvalor_proteina

                                'fran 10/10/2015 - poupança i
                                'Guarda media analise proteina
                                Me.fichafinanceira.cd_conta = "0082"  ' Grava conta 0082 - Teor Proteína
                                Me.fichafinanceira.nr_valor_conta = Me.nr_media_analise
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                'fran 10/10/2015 - poupança f

                                If Me.nr_media_analise <> 0 Then 'fran 25/04/2017 i se o teor for = 0 nao deve gravar conta de complience para nao participar dos relatorios
                                    'adri 19/12/2016 - curva ABC i
                                    Me.fichafinanceira.cd_conta = "0084"  ' Grava conta 0084 - Teor Proteína Complience (true ou false)
                                    Me.fichafinanceira.nr_valor_conta = Me.nr_media_analise_complience
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                    ltotal_complience = ltotal_complience + nr_media_analise_complience
                                    'adri 19/12/2016 - curva ABC f
                                    ltotal_contas_complience = ltotal_contas_complience + 1 'fran 25/04/2017 i
                                End If


                                Me.cd_analise_esalq = 52    ' Apura CTM
                                Me.id_categoria = 2  ' Apura CTM

                                lvalor_CTM = Me.apurarIndiceQualidade()
                                lpreco_base = lpreco_base + lvalor_CTM  ' bonus ou desconto no preco

                                If lvalor_CTM >= 0 Then
                                    Me.fichafinanceira.cd_conta = "0090"  ' Grava conta 0090 - Bônus CTM
                                Else
                                    Me.fichafinanceira.cd_conta = "0091"  ' Grava conta 0091 - Desconto CTM
                                End If
                                Me.fichafinanceira.nr_valor_conta = lvalor_CTM
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                lvalor_total_qualidade = lvalor_total_qualidade + lvalor_CTM

                                'fran 10/10/2015 - poupança i
                                'Guarda media analise CTM
                                Me.fichafinanceira.cd_conta = "0092"  ' Grava conta 0092 - Teor CTM
                                Me.fichafinanceira.nr_valor_conta = Me.nr_media_analise
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                'fran 10/10/2015 - poupança f

                                'fran 12/09/2016 - calculo geometrico mensal poupança i
                                'Guarda media analise CTM
                                Me.fichafinanceira.cd_conta = "0093"  ' Grava conta 0093 - Teor CTM MENSAL
                                Me.fichafinanceira.nr_valor_conta = Me.nr_media_analise_geometrico_mensal
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                'fran 12/09/2016 - calculo geometrico mensal poupança f

                                If Me.nr_media_analise <> 0 Then 'fran 25/04/2017 i se o teor for = 0 nao deve gravar conta de complience para nao participar dos relatorios
                                    'adri 19/12/2016 - curva ABC i
                                    Me.fichafinanceira.cd_conta = "0094"  ' Grava conta 0094 - Teor CTM Complience (true ou false)
                                    Me.fichafinanceira.nr_valor_conta = Me.nr_media_analise_complience
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                    ltotal_complience = ltotal_complience + nr_media_analise_complience
                                    'adri 19/12/2016 - curva ABC f
                                    ltotal_contas_complience = ltotal_contas_complience + 1 'fran 25/04/2017 i
                                End If

                                Me.cd_analise_esalq = 53    ' Apura CCS
                                Me.id_categoria = 1  ' Apura CTM

                                lvalor_CCS = Me.apurarIndiceQualidade()
                                lpreco_base = lpreco_base + lvalor_CCS  ' bonus ou desconto no preco

                                If lvalor_CCS >= 0 Then
                                    Me.fichafinanceira.cd_conta = "0100"  ' Grava conta 0100 - Bônus CCS
                                Else
                                    Me.fichafinanceira.cd_conta = "0101"  ' Grava conta 0101 - Desconto CCS
                                End If
                                Me.fichafinanceira.nr_valor_conta = lvalor_CCS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' 16/09/2008 - Total da Qualidade - i
                                lvalor_total_qualidade = lvalor_total_qualidade + lvalor_CCS

                                'fran 10/10/2015 - poupança i
                                'Guarda media analise CCS
                                Me.fichafinanceira.cd_conta = "0105"  ' Grava conta 0105 - Teor CCS
                                Me.fichafinanceira.nr_valor_conta = Me.nr_media_analise
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                'fran 10/10/2015 - poupança f

                                'fran 12/09/2016 - calculo geometrico mensal poupança i
                                'Guarda media analise CCS
                                Me.fichafinanceira.cd_conta = "0106"  ' Grava conta 0106 - Teor CCS MENSAL
                                Me.fichafinanceira.nr_valor_conta = Me.nr_media_analise_geometrico_mensal
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                'fran 12/09/2016 - calculo geometrico mensal poupança f

                                If Me.nr_media_analise <> 0 Then 'fran 25/04/2017 i se o teor for = 0 nao deve gravar conta de complience para nao participar dos relatorios
                                    'adri 19/12/2016 - curva ABC i
                                    Me.fichafinanceira.cd_conta = "0107"  ' Grava conta 0107 - Teor CCS Complience (true ou false)
                                    Me.fichafinanceira.nr_valor_conta = Me.nr_media_analise_complience
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                    ltotal_complience = ltotal_complience + nr_media_analise_complience
                                    'adri 19/12/2016 - curva ABC f
                                    ltotal_contas_complience = ltotal_contas_complience + 1 'fran 25/04/2017 i

                                End If

                                'fran 01/01/2014 i GORDURA
                                Me.cd_analise_esalq = 8    ' Apura MG
                                Me.id_categoria = 4  ' Apura MG

                                lvalor_gordura = Me.apurarIndiceQualidade()
                                lpreco_base = lpreco_base + lvalor_gordura  ' bonus ou desconto no preco

                                If lvalor_gordura >= 0 Then
                                    Me.fichafinanceira.cd_conta = "0110"  ' Grava conta 0110 - Bônus gordura
                                Else
                                    Me.fichafinanceira.cd_conta = "0111"  ' Grava conta 0111 - Desconto gordura
                                End If
                                Me.fichafinanceira.nr_valor_conta = lvalor_gordura
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                lvalor_total_qualidade = lvalor_total_qualidade + lvalor_gordura
                                'fran 01/01/2014 f

                                Me.fichafinanceira.cd_conta = "0150"  ' Grava conta 0150 - Total Qualidade
                                Me.fichafinanceira.nr_valor_conta = lvalor_total_qualidade
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                lvalor_qualidade = lvalor_total_qualidade ' 22/10/2008 (salva a somatória unitária da qualidade)
                                lvalor_total_qualidade = lvalor_total_qualidade * lvalor_volumeleite

                                Me.fichafinanceira.cd_conta = "0151"  ' Grava conta 0151 - Total Qualidade x Volume
                                Me.fichafinanceira.nr_valor_conta = lvalor_total_qualidade
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                ' 16/09/2008 - Total da Qualidade - f

                                If Me.nr_media_analise <> 0 Then 'fran 25/04/2017 i se o teor for = 0 nao deve gravar conta de complience para nao participar dos relatorios
                                    'adri 19/12/2016 - curva ABC i
                                    Me.fichafinanceira.cd_conta = "0153"  ' Grava conta 0153 - Teor Gordura Complience (true ou false)
                                    Me.fichafinanceira.nr_valor_conta = Me.nr_media_analise_complience
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                    ltotal_complience = ltotal_complience + nr_media_analise_complience
                                    'adri 19/12/2016 - curva ABC f
                                    ltotal_contas_complience = ltotal_contas_complience + 1 'fran 25/04/2017 i
                                End If

                                ' Adri 12/04/2010 - Chamado 772 - Salva média de Teor de Gordura para Nota Fiscal - i
                                Me.cd_analise_esalq = 8    ' Apura Teor de Gordura
                                Me.id_categoria = 0  ' Não possui faixa de qualidade para pagamento de bônus ou desconto

                                Me.apurarIndiceQualidade()
                                Me.fichafinanceira.cd_conta = "0152"  ' Grava conta 0100 - Bônus CCS
                                Me.fichafinanceira.nr_valor_conta = Me.nr_media_analise
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' Adri 12/04/2010 - Chamado 772 - Salva média de Teor de Gordura para Nota Fiscal - f

                                If ltotal_contas_complience > 0 Then 'fran 25/04/2017 i se tem mais de uma conta complience, deixa criar a conta de totalizador complience
                                    ' Adri 20/12/2016 - Curva ABC - i
                                    If ltotal_complience = -4 Then  ' Se a soma de todos os resultados for -4 (cada resultado complience equivale a -1), a propriedade é Complience em todas as categorias
                                        nr_media_analise_complience = True
                                    Else
                                        nr_media_analise_complience = False
                                    End If
                                    Me.fichafinanceira.cd_conta = "0154"  ' Grava conta 0154 - Qualidade Total Complience (true ou false)
                                    Me.fichafinanceira.nr_valor_conta = Me.nr_media_analise_complience
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                    ' Adri 20/12/2016 - Curva ABC - f

                                End If
                            End If

                            'fran 11/2022 i
                            'composicao de preco deve pegar por propriedade
                            Me.fichafinanceira.id_unid_producao = 0
                            'fran 11/2022 f

                            '19/02/2009 Rls16 (Busca contas que compõem o Preço da Nota, ou seja, que tem o mesmo comportamento da conta de Reposição - Pode ser lançada com Positiva ou Negativa) - i
                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.id_natureza = 5  ' Natureza 5-Composição de Preço
                            Me.fichafinanceira.cd_conta = ""    ' Limpa a conta 
                            Me.fichafinanceira.st_qtd_valor = "V"  ' 13/01/2010 - Chamado 581 (Busca todas as contas lançadas em valor Unitário)
                            'lvalor_composicao_preco = Me.fichafinanceira.getFichaFinanceiraValorConta()  ' Somatório dos descontos no mes de referencia
                            lvalor_composicao_preco_unitario = Me.fichafinanceira.getFichaFinanceiraValorConta()  ' Somatório dos descontos no mes de referencia
                            Me.fichafinanceira.st_qtd_valor = ""  ' 13/01/2010 - Chamado 581 Limpa o atributo
                            '19/02/2009 Rls16 (Busca contas que compõem o Preço da Nota, ou seja, que tem o mesmo comportamento da conta de Reposição - Pode ser lançada com Positiva ou Negativa) - f

                            ' 13/01/2010 - Chamado 581 - Adicional Distância - i
                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.id_natureza = 5  ' Natureza 5-Composição de Preço
                            Me.fichafinanceira.cd_conta = ""    ' Limpa a conta 
                            Me.fichafinanceira.st_qtd_valor = "T"  ' 13/01/2010 - Chamado 581 (Busca todas as contas lançadas em valor Total)
                            lvalor_composicao_preco_total = Me.fichafinanceira.getFichaFinanceiraValorConta()  ' Somatório dos descontos no mes de referencia

                            'fran 11/2022 busca conta 8999 e retira da composição neste momento (ela so aparece aqui se for mais de uma UP porque é calculada no final)
                            Me.fichafinanceira.cd_conta = "8999"
                            lvalor_composicao_preco_total = lvalor_composicao_preco_total - Me.fichafinanceira.getFichaFinanceiraValorConta()  ' Somatório dos descontos no mes de referencia

                            Me.fichafinanceira.id_unid_producao = id_unid_producao
                            'fran 11/2022 f

                            Me.fichafinanceira.st_qtd_valor = ""  ' 13/01/2010 - Chamado 581 Limpa o atributo
                            Me.fichafinanceira.id_natureza = 0

                            'lvalor_composicao_preco = lvalor_composicao_preco_unitario + Round((lvalor_composicao_preco_total / lvalor_volumeleite), 4)
                            'fran 11/2022 i
                            'lvalor_composicao_preco = lvalor_composicao_preco_unitario + (lvalor_composicao_preco_total / lvalor_volumeleite)  ' adri 14/09/2015 - chamado 2377 - Erro de arredondamento na divisão do ADC lançado em total e quando divide pelo volume perde muito se arredondar pra 4 casas
                            lvalor_composicao_preco = lvalor_composicao_preco_unitario + (lvalor_composicao_preco_total / lvalor_volume_total_propriedade)
                            'fran 11/2022
                            ' 13/01/2010 - Chamado 581 - Adicional Distância - f

                            'fran 08/2022 i
                            If lst_calculo_com_juros.Equals("N") Then
                                Me.fichafinanceira.cd_conta = "0250"  ' Grava conta - composicao preco
                                Me.fichafinanceira.nr_valor_conta = lvalor_composicao_preco
                                Me.fichafinanceira.nr_valor_12 = lvalor_composicao_preco
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                Me.fichafinanceira.nr_valor_12 = 0 'limpa campo

                                'fran 08/2022 f
                            End If

                            '28/11/2008 (complementa o preço base com Redutase e Reposicao) - i
                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.cd_conta = "0102"   ' Conta Redutase
                            Me.fichafinanceira.st_tipo_pagamento = "M"
                            'Fran 07/01/2009 i 
                            Me.fichafinanceira.id_natureza = 0
                            'Fran 07/01/2009 f
                            lvalor_redutase = Me.fichafinanceira.getFichaFinanceiraValorConta()

                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.cd_conta = "3000"   ' Conta Reposição
                            Me.fichafinanceira.st_tipo_pagamento = "M"
                            'Fran 07/01/2009 i 
                            Me.fichafinanceira.id_natureza = 0
                            'Fran 07/01/2009 f
                            lvalor_reposicao = Me.fichafinanceira.getFichaFinanceiraValorConta()

                            'lpreco_base = lpreco_base + lvalor_redutase + lvalor_reposicao 
                            lpreco_base = lpreco_base + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco   ' 19/02/2009 Rls16
                            '28/11/2008 (complementa o preço base com Redutase e Reposicao) - f

                            'fran 11/2022 i
                            If lst_calculo_com_juros.Equals("N") Then
                                Me.fichafinanceira.cd_conta = "0050"  ' Grava conta - Preço Bruto
                                Me.fichafinanceira.nr_valor_conta = lpreco_base
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'fran 11/2022 f
                            End If

                            '======================================
                            ' Ponto 4 - Apurar Preço Nota Fiscal 
                            '======================================

                            ' 21/10/2008 - Nova Regra - i
                            'If lst_incentivo_fiscal = "S" Then
                            '    lvalor_incentivofiscal = lpreco_base * 0.025  ' Calcula 2,5% de Incentivo Fiscal
                            '    lvalor_funrural = (lpreco_base + lvalor_incentivofiscal) * 0.023  ' Calculo FunRural
                            '    lpreco_notafiscal = lpreco_negociado - lvalor_incentivofiscal + lvalor_funrural

                            '    Me.fichafinanceira.cd_conta = "0300"  ' Grava conta - Incentivo Fiscal
                            '    Me.fichafinanceira.nr_valor_conta = lvalor_incentivofiscal
                            '    Me.fichafinanceira.st_origem_conta = "C"
                            '    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            '    Me.fichafinanceira.insertFichaFinanceiraItens()
                            'Else
                            '    lvalor_funrural = lpreco_base * 0.023  ' Calculo FunRural
                            '    lpreco_notafiscal = lpreco_negociado + lvalor_funrural
                            'End If

                            If lst_transferencia_credito = "S" Then
                                ' 20081127 - i (especificação do Milton)  ( (preco negociado (0030) / 0,977 )  +  qualidade (0150) + redutase (0102) + reposição (3000) ) / 0.88
                                'lpreco_notafiscal = Round(lpreco_base / 0.977 / 0.88, 4)
                                'lpreco_notafiscal = Round((Round(lpreco_negociado / 0.977, 4) + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao ) / 0.88, 4)  ' 28/11/2008 (usar preço negociado e não preco variavel)
                                'lpreco_notafiscal = Round((Round(lpreco_negociado / 0.977, 4) + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) / 0.88, 4)  ' 19/02/2009 Rls16 - Fran 01/01/2014 inclusao grodura
                                lpreco_notafiscal = Round((Round(lpreco_negociado / 0.977, 4) + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) / 0.88, 4)  '01/01/2014 rls 1.03.35.05

                                'fran 31/01/2019 i FUNRURAL 2019 LEI 13606
                                ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018
                                'fran 23/04/2017 i retorno do funrural para referencia Abril/2017
                                'fran 28/09/2016 i 'funrural nao existe mais deve apenas calcular sest/senat (2.3 antes 2.1 para funrural e 0.2 para sestsenat)
                                'lvalor_funrural = lpreco_notafiscal * 0.023  ' Calculo FunRural
                                'lvalor_funrural = lpreco_notafiscal * 0.002  ' Calculo FunRural
                                'fran 28/09/2016 i
                                ''lvalor_funrural = lpreco_notafiscal * 0.023  ' Calculo FunRural
                                'fran 23/04/2017 f retorno do funrural para referencia Abril/2017
                                'lvalor_funrural = lpreco_notafiscal * 0.015  ' Calculo FunRural
                                ''fran 31/01/2018 f FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018

                                'Se o produtor optou por recolher FUNRURAL
                                If lst_funrural = "P" Then
                                    'lvalor_funrural = lpreco_notafiscal * 0.003  ' Calculo FunRural - desconta apenas SENAR/RAT
                                    lvalor_funrural = lpreco_notafiscal * 0.002  ' mudanca de legislacao
                                Else
                                    'SE A DANONE recolhe o FUNRURAL de acordo com cadastro de fornecedor

                                    lvalor_funrural = lpreco_notafiscal * 0.015  ' Calculo FunRural -desconta FUNRURAL + SENAR/RAT
                                End If
                                'fran 31/01/2019 f FUNRURAL 2019 LEI 13606
                            Else
                                'fran 11/2022 categoria juridica deve deixa calcular incentivo
                                'If lst_categoria = "J" Then  'Se pessoa jurídica
                                '    'fran 22/07/2016 i Calculo Geometricco - Não deve imbutir funrural - Solicitação ANa Souza/Ricardo referente ao calculo
                                '    'lpreco_notafiscal = Round(lpreco_negociado / 0.977, 4)
                                '    lpreco_notafiscal = Round(lpreco_negociado, 4)
                                '    'fran 22/07/2016 f

                                '    lvalor_funrural = 0
                                'Else
                                'fran 11/2022
                                ' If lst_incentivo_fiscal <> "N"  Then  ' Se tem Incentivo Fiscal, Permaneu a mesma coisa da versão anterior
                                'se tem incentivo e deve apurar25
                                'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i
                                If lst_incentivo_fiscal <> "N" AndAlso lbapurar25 = True Then  ' Se tem Incentivo Fiscal, Permaneu a mesma coisa da versão anterior
                                    'If lst_incentivo_fiscal <> "N" Then  ' Se tem Incentivo Fiscal, Permaneu a mesma coisa da versão anterior
                                    'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 f

                                    'lvalor_incentivofiscal = lpreco_base * 0.025  ' Calcula 2,5% de Incentivo Fiscal

                                    'fran 03/2023 i - foi solicitado retirar as 4 casas do calculo por causa da nota do sap
                                    'lvalor_incentivofiscal = Round(lpreco_base * 0.025, 4)  ' Adri Projeto Themis 28/05/2012 - chamado 1553 - Calcula 2,5% de Incentivo Fiscal com arredondamento devido ao SAP
                                    lvalor_incentivofiscal = lpreco_base * 0.025
                                    'fran 03/2023 f

                                    'fran 31/01/2019 i FUNRURAL 2019 LEI 13606

                                    ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018
                                    'fran 23/04/2017 i retorno do funrural para referencia Abril/2017
                                    'fran 28/09/2016 i 'funrural nao existe mais deve apenas calcular sest/senat (2.3 antes 2.1 para funrural e 0.2 para sestsenat)
                                    'lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.023, 4)  ' Calculo FunRural
                                    'lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.002, 4)  ' Calculo FunRural
                                    'fran 28/09/2016 f
                                    ''lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.023, 4)  ' Calculo FunRural
                                    'fran 23/04/2017 f retorno do funrural para referencia Abril/2017
                                    'lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.015, 4)  ' Calculo FunRural
                                    ''fran 31/01/2018 f FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018
                                    If lst_categoria = "J" Then
                                        lvalor_funrural = 0
                                    Else
                                        'Se o produtor optou por recolher FUNRURAL
                                        If lst_funrural = "P" Then
                                            'lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.003, 4)  ' Calculo FunRural - desconta apenas SENAR/RAT
                                            lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.002, 4)  ' nova legislacao
                                        Else
                                            'SE A DANONE recolhe o FUNRURAL de acordo com cadastro de fornecedor
                                            lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.015, 4)  ' Calculo FunRural -desconta FUNRURAL + SENAR/RAT
                                        End If
                                        'fran 01/2019 f FUNRURAL 2019 LEI 13606
                                    End If

                                    'fran 22/07/2016 i Calculo Geometricco - Não deve imbutir funrural - Solicitação ANa Souza/Ricardo referente ao calculo
                                    'lpreco_notafiscal = (lpreco_negociado - lvalor_incentivofiscal + lvalor_funrural)
                                    lpreco_notafiscal = Round(lpreco_negociado, 4)
                                    'fran 22/07/2016 f

                                    If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021
                                        Me.fichafinanceira.cd_conta = "0300"  ' Grava conta - Incentivo Fiscal
                                        Me.fichafinanceira.nr_valor_conta = lvalor_incentivofiscal
                                        Me.fichafinanceira.nr_valor_12 = lvalor_incentivofiscal
                                        Me.fichafinanceira.st_origem_conta = "C"
                                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                        Me.fichafinanceira.insertFichaFinanceiraItens()
                                        Me.fichafinanceira.nr_valor_12 = 0 'limpa campo

                                        lnrvaloraux = 0
                                        Me.fichafinanceira.cd_conta = "2065"  ' Grava conta - Incentivo Fiscal
                                        If lnr_volume_incentivo25 > 0 Then
                                            Me.fichafinanceira.nr_valor_conta = Round(lvalor_incentivofiscal * lnr_volume_incentivo25, 2)
                                            lnrvaloraux = lvalor_incentivofiscal * lnr_volume_incentivo25
                                        Else
                                            Me.fichafinanceira.nr_valor_conta = Round(lvalor_incentivofiscal * lvalor_volumeleite, 2)
                                            lnrvaloraux = lvalor_incentivofiscal * lvalor_volumeleite
                                        End If
                                        Me.fichafinanceira.st_origem_conta = "C"
                                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                        Me.fichafinanceira.insertFichaFinanceiraItens()

                                        Me.fichafinanceira.cd_conta = "2070"  ' Grava conta - 2070 Incentivo 2.5 liquido VALOR INCENTIVO - PISCOFINS 4,625%
                                        Me.fichafinanceira.nr_valor_conta = Round(lnrvaloraux * (1 - (0.04625)), 2)
                                        Me.fichafinanceira.nr_valor_12 = Round(lnrvaloraux * (1 - (0.04625)), 12)
                                        Me.fichafinanceira.st_origem_conta = "C"
                                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                        Me.fichafinanceira.insertFichaFinanceiraItens()

                                        'fran 12/2022 - o preco liquido deve ser gerado para todas propriedades independente do incentivo
                                        Me.fichafinanceira.cd_conta = "0055"  ' Grava conta - 0055 preço liquido 2.5 preço bruto - piscofins 4,625% sem desconto ICMS sobre reço
                                        Me.fichafinanceira.nr_valor_conta = Round(lpreco_base - Round(lpreco_base * 0.12, 4) - Round(lpreco_base * 0.04625, 4), 4)
                                        Me.fichafinanceira.nr_valor_12 = Round(lpreco_base - (lpreco_base * 0.12) - (lpreco_base * 0.04625), 12)
                                        Me.fichafinanceira.st_origem_conta = "C"
                                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                        Me.fichafinanceira.insertFichaFinanceiraItens()

                                        Me.fichafinanceira.nr_valor_12 = 0 'limpa campo

                                    End If

                                Else
                                    'fran 22/07/2016 i Calculo Geometricco - Não deve imbutir funrural - Solicitação ANa Souza/Ricardo referente ao calculo
                                    'lpreco_notafiscal = Round(lpreco_negociado / 0.977, 4)
                                    lpreco_notafiscal = Round(lpreco_negociado, 4)
                                    'fran 22/07/2016 f
                                    'lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal) * 0.023, 4)  ' 22/10/2008 Calculo FunRural

                                    'fran 31/01/2019 1 FUNRURAL 2019 LEI 13606
                                    ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018
                                    'fran 23/04/2017 i retorno do funrural para referencia Abril/2017
                                    ''fran 28/09/2016 i 'funrural nao existe mais deve apenas calcular sest/senat (2.3 antes 2.1 para funrural e 0.2 para sestsenat)
                                    ''lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.023, 4)  ' 19/02/2009 Rls16
                                    'lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.002, 4)  ' 19/02/2009 Rls16
                                    ''fran 28/09/2016 f
                                    ''lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.023, 4)
                                    'fran 23/04/2017 f retorno do funrural para referencia Abril/2017
                                    'lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.015, 4)
                                    ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018
                                    If lst_categoria = "J" Then
                                        lvalor_funrural = 0
                                    Else

                                        'Se o produtor optou por recolher FUNRURAL
                                        If lst_funrural = "P" Then
                                            'lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.003, 4) ' Calculo FunRural - desconta apenas SENAR/RAT
                                            lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.002, 4) ' Calculo FunRural - desconta apenas SENAR/RAT
                                        Else
                                            'SE A DANONE recolhe o FUNRURAL de acordo com cadastro de fornecedor
                                            lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.015, 4) ' Calculo FunRural - desconta FUNRURAL +  SENAR/RAT
                                        End If
                                        'fran 31/01/2019 f FUNRURAL 2019 LEI 13606
                                    End If
                                End If
                                'End If

                            End If
                            ' 21/10/2008 - Nova Regra - f
                            If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021

                                Me.fichafinanceira.cd_conta = "0041"  ' Grava conta - Preco Nota Fiscal
                                Me.fichafinanceira.nr_valor_conta = lpreco_notafiscal
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "0800"  ' Grava conta - Preco Funrural
                                Me.fichafinanceira.nr_valor_conta = lvalor_funrural
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'fran 31/01/2019 i aliquota funrural
                                If lvalor_funrural <> 0 Then
                                    Me.fichafinanceira.cd_conta = "0801"  ' Grava conta - ALIQUOTA Funrural
                                    Me.fichafinanceira.nr_valor_conta = lvalor_aliquota_funrural
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                End If
                                'fran 31/01/2019 f aliquota funrural
                            End If 'fran 12/2021
                            '======================================
                            ' Ponto 5 - Apurar Preço Unitário 
                            '======================================
                            'lpreco_unitario = lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_incentivofiscal - lvalor_funrural
                            ' 21/10/2008 - i
                            If lst_transferencia_credito = "S" Then
                                lpreco_unitario = Round(lpreco_notafiscal - lvalor_funrural, 4)
                            Else
                                'fran 01/01/2014 - inclusao gordura i
                                'lpreco_unitario = Round(lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_incentivofiscal - lvalor_funrural, 4)
                                lpreco_unitario = Round(lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_incentivofiscal - lvalor_funrural, 4)
                                'fran 01/01/2014 - inclusao gordura f

                            End If
                            ' 21/10/2008 - f

                            If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021

                                Me.fichafinanceira.cd_conta = "0040"  ' Grava conta - Preco Unitário
                                Me.fichafinanceira.nr_valor_conta = lpreco_unitario
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If
                            '======================================================
                            ' Ponto 6 - Apurar Rendimento Bruto da Unidade Produção
                            '======================================================
                            lvalor_rendbruto = Round(lvalor_volumeleite * lpreco_unitario, 2)

                            If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021

                                Me.fichafinanceira.cd_conta = "0200"  ' Grava conta - Preco Unitário
                                Me.fichafinanceira.nr_valor_conta = lvalor_rendbruto
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If
                            '======================================================
                            ' Ponto 7 - Apurar dados da Nota Fiscal
                            '======================================================
                            ' 22/10/2008 - i
                            If lst_incentivo_21 = "S" Then
                                ' 20081126 - Solicitação do Milton via email - i
                                'lvalor_incentivo_21 = Round(lpreco_notafiscal * lvalor_volumeleite * 0.021, 2)
                                'lvalor_incentivo_21 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal) * 0.021, 4) * lvalor_volumeleite, 2)
                                'lvalor_incentivo_21 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.021, 4) * lvalor_volumeleite, 2)  ' 19/02/2009 Rls16 'fran 01/01/2014
                                'lvalor_incentivo_21 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.021, 4) * lvalor_volumeleite, 2)  ' fran 01/01/2014 inclusao gordura
                                lvalor_incentivo_21 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * 0.021, 4) * lvalor_volumeleite, 2)  ' fran 11/2022 nao pode somar mais de um incentivo

                                If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021

                                    Me.fichafinanceira.cd_conta = "2050"  ' Grava conta - Incentivo 2.1%
                                    Me.fichafinanceira.nr_valor_conta = lvalor_incentivo_21
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                End If
                            End If
                            ' 22/10/2008 - f

                            ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5 - i
                            'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i
                            If lst_incentivo_24 = "S" OrElse lbapurar24 = True Then 'se no cadastro é 2,4 ou se por causo do limite de incentivo vai ter  2,4 e 2,5 no mesmo calculo
                                'If lst_incentivo_24 = "S" Then 'se no cadastro é 2,4 ou se por causo do limite de incentivo vai ter  2,4 e 2,5 no mesmo calculo
                                'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i
                                'fran 25/06/2012 i escopo complementar calculo Themis (acerto de formula 1400 e incentivo24)
                                'lvalor_incentivo_24 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.024, 4) * lvalor_volumeleite, 2)
                                'fran 19/07/2012 i incentivo 2,4 email enviado em 19/07, solicitando alteraçãoo da formula
                                'lvalor_incentivo_24 = Round(Round(((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) / 0.976) * lvalor_volumeleite, 4) * 0.024, 2)
                                'lvalor_incentivo_24 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * lvalor_volumeleite, 4) * 0.024, 2) 'fran 01/01/2014
                                'fran 11/2022 i - gravar unitario igual 2,5
                                'lvalor_incentivo_24 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * lvalor_volumeleite, 4) * 0.024, 2) 'fran 01/01/2014 - inclusao gordutra
                                'lvalor_incentivo_24_unitario = lvalor_incentivo_24 / lvalor_volumeleite 'fran 08/2017
                                lnrvaloraux = 0 'fran 03/2023

                                lvalor_incentivo_24_unitario = lpreco_base * 0.024
                                If lnr_volume_incentivo24 > 0 Then 'se tem volume 2,4 apurado
                                    lvalor_incentivo_24 = Round(lvalor_incentivo_24_unitario * lnr_volume_incentivo24, 2)
                                    lnrvaloraux = Round(lvalor_incentivo_24_unitario * lnr_volume_incentivo24, 12)
                                Else
                                    lvalor_incentivo_24 = Round(lvalor_incentivo_24_unitario * lvalor_volumeleite, 2)
                                    lnrvaloraux = Round(lvalor_incentivo_24_unitario * lvalor_volumeleite, 12)
                                End If
                                'fran 11/2022 f - gravar unitario igual 2,5
                                'fran 19/07/2012 f incentivo 2,4 email enviado em 19/07, solicitando alteraçãoo da formula
                                'fran 25/06/2012 f escopo complementar calculo Themis (acerto de formula 1400 e incentivo24)
                                If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021

                                    Me.fichafinanceira.cd_conta = "2055"  ' Grava conta - Incentivo 2.4%
                                    Me.fichafinanceira.nr_valor_conta = lvalor_incentivo_24
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()

                                    Me.fichafinanceira.cd_conta = "0350"  ' Grava conta - Incentivo 2.4%
                                    Me.fichafinanceira.nr_valor_conta = lvalor_incentivo_24_unitario
                                    Me.fichafinanceira.nr_valor_12 = lvalor_incentivo_24_unitario
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()

                                    Me.fichafinanceira.cd_conta = "2060"  ' Grava conta - 2060 Incentivo 2.4 liquido VALOR INCENTIVO - PISCOFINS 4,625%
                                    Me.fichafinanceira.nr_valor_conta = Round(lnrvaloraux * (1 - (0.04625)), 2)
                                    Me.fichafinanceira.nr_valor_12 = Round(lnrvaloraux * (1 - (0.04625)), 12)
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()

                                    Me.fichafinanceira.cd_conta = "0060"  ' Grava conta - 0060 preço liquido 2.4 preço bruto - piscofins 4,625% sem desconto ICMS sobre reço
                                    Me.fichafinanceira.nr_valor_conta = Round(lpreco_base - Round(lpreco_base * 0.04625, 4), 4)
                                    Me.fichafinanceira.nr_valor_12 = Round(lpreco_base - (lpreco_base * 0.04625), 12)
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()

                                    Me.fichafinanceira.nr_valor_12 = 0 'limpa valor

                                End If
                            End If
                            ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5 - f

                            'fran dez/2022 i
                            If lst_calculo_com_juros.Equals("N") AndAlso lvalor_incentivofiscal = 0 AndAlso lvalor_incentivo_24 = 0 Then 'fran 12/2022
                                'grava a 0060 preco liq icms 0, se nao tem a conta 55 (preco liq quando tem que abater icms) e nao apurou a 0060 com incentivo 2.4 ou seja se nao tem nenhum incentivo, calcula o preco liq
                                Me.fichafinanceira.cd_conta = "0060"  ' Grava conta - 0060 preço liquido sem icms preço bruto - piscofins 4,625% sem desconto ICMS sobre reço
                                Me.fichafinanceira.nr_valor_conta = Round(lpreco_base - Round(lpreco_base * 0.04625, 4), 4)
                                Me.fichafinanceira.nr_valor_12 = Round(lpreco_base - (lpreco_base * 0.04625), 12)
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                Me.fichafinanceira.nr_valor_12 = 0 'limpa valor

                            End If
                            'fran dez/2022 f


                            'lvalor_totalnota = lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_incentivofiscal
                            ' 22/10/2008 - i
                            'lvalor_totalnota = Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_incentivofiscal) * lvalor_volumeleite, 2)
                            If lst_transferencia_credito = "S" Then
                                lvalor_totalnota = Round(lpreco_notafiscal * lvalor_volumeleite, 2)
                            Else
                                ' 24/11/2008 - i  (Busca Redutase lançada)
                                'Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                                'Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                                'Me.fichafinanceira.cd_conta = "0102"   ' Conta Redutase
                                'Me.fichafinanceira.st_tipo_pagamento = "M"
                                'lvalor_redutase = Me.fichafinanceira.getFichaFinanceiraValorConta()

                                'Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                                'Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                                'Me.fichafinanceira.cd_conta = "3000"   ' Conta Reposição
                                'Me.fichafinanceira.st_tipo_pagamento = "M"
                                'lvalor_reposicao = Me.fichafinanceira.getFichaFinanceiraValorConta()

                                'lvalor_totalnota = Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_incentivofiscal) * lvalor_volumeleite + lvalor_incentivo_21, 2)   
                                'lvalor_totalnota = Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal) * lvalor_volumeleite + lvalor_incentivo_21, 2)

                                ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5 - i
                                'lvalor_totalnota = Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * lvalor_volumeleite + lvalor_incentivo_21, 2)
                                'fran 25/06/2012 i escopo complementar calculo Themis (acerto de formula 1400 e incentivo24)
                                'lvalor_totalnota = Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * lvalor_volumeleite + lvalor_incentivo_21 + lvalor_incentivo_24, 2)
                                If lst_incentivo_fiscal = "N" Then 'se nao tem incentivo
                                    'Conta 1400 = (Preço NT + Total Qualidade + Redutase + Reposicao + Composicao Preço) * VOLUME + Incentivo 21 + incentivo 24
                                    'lvalor_totalnota = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2) 'fran 01/01/2014 inclusao gordura
                                    lvalor_totalnota = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2) 'fran 01/01/2014 inclusao gordura
                                Else 'se tem incentivo
                                    'Conta 1400 = (Preço NT + Total Qualidade + Redutase + Reposicao + Composicao Preço) * VOLUME + ((Preço NT + Total Qualidade + Redutase + Reposicao + Composicao Preço) * VOLUME) * 0.025 + Incentivo 21 + incentivo 24 que na verdade é:
                                    'Conta 1400 = (Preço NT + Total Qualidade + Redutase + Reposicao + Composicao Preço) * VOLUME + (BASEICMS * 0.025) + Incentivo 21 + incentivo 24 que na verdade é:
                                    'lvalor_totalnota = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) + (Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) * 0.025) + lvalor_incentivo_21 + lvalor_incentivo_24, 2) 'fran 01/01/2014 inclusao gordura

                                    'lvalor_totalnota = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) + (Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) * 0.025) + lvalor_incentivo_21 + lvalor_incentivo_24, 2) 'fran 01/01/2014 inclusao gordura
                                    'fran 11/2022
                                    'lvalor_totalnota = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) + Round(lvalor_incentivofiscal * lvalor_volumeleite, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2) ' adri 14/09/2015 - chamado 2377 - considerar o incentivo fiscal 2,5% que já está calculado, pois gerava diferença no extrato
                                    If lnr_volume_incentivo25 > 0 Then

                                        lvalor_totalnota = Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)
                                        lvalor_totalnota = Round(lvalor_totalnota + Round(lvalor_incentivofiscal * lnr_volume_incentivo25, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2)
                                    Else
                                        lvalor_totalnota = Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)
                                        lvalor_totalnota = Round(lvalor_totalnota + Round(lvalor_incentivofiscal * lvalor_volumeleite, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2)

                                    End If

                                End If
                                'fran 25/06/2012 f escopo complementar calculo Themis
                                ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5 - f

                                ' 24/11/2008 - f  (Busca Redutase lançada)
                            End If
                            ' 22/10/2008 - f

                            ' 22/10/2008 - i
                            'If lst_incentivo_fiscal = "S" Then
                            '    lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM) * lvalor_volumeleite, 2)
                            '    lvalor_ICMS = Round(lvalor_baseICMS * 0.12, 2)
                            'Else
                            '    lvalor_baseICMS = 0
                            '    lvalor_ICMS = 0
                            'End If
                            If lst_transferencia_credito = "S" Then
                                lvalor_baseICMS = lvalor_totalnota
                                lvalor_ICMS = Round(lvalor_baseICMS * 0.12, 2)
                                lvalor_transferencia_ICMS = Round(lpreco_notafiscal * 0.12 * lvalor_volumeleite, 2)
                            Else
                                'If lst_incentivo_fiscal = "S"  Then
                                If lst_incentivo_fiscal <> "N" Or lst_uf_produtor = "RJ" Then  ' 22/10/2008
                                    'lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM ) * lvalor_volumeleite, 2)
                                    'lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao) * lvalor_volumeleite, 2)  ' 24/11/2008
                                    'lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)  ' 19/02/2009 Rls16 'fran 01/01/2014 inclusao gordura
                                    'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i
                                    If lbapurar25 = False Then ' fran 11/2022 se nao é pra apurar 2.5
                                        lvalor_baseICMS = 0
                                        lvalor_ICMS = 0
                                    Else
                                        If lnr_volume_incentivo25 > 0 Then
                                            lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lnr_volume_incentivo25, 2)
                                        Else
                                            lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)  ' fran 01/01/2014 inclusao gordura

                                        End If

                                        lvalor_ICMS = Round(lvalor_baseICMS * 0.12, 2)

                                    End If

                                    'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i

                                Else
                                    lvalor_baseICMS = 0
                                    lvalor_ICMS = 0
                                End If
                            End If
                            ' 22/10/2008 - f

                            If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021

                                Me.fichafinanceira.cd_conta = "1200"  ' Grava conta - Base ICMS
                                Me.fichafinanceira.nr_valor_conta = lvalor_baseICMS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "1300"  ' Grava conta - Base ICMS
                                Me.fichafinanceira.nr_valor_conta = lvalor_ICMS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' 22/10/2008 - i
                                Me.fichafinanceira.cd_conta = "2040"  ' Grava conta - Transferência de ICMS
                                Me.fichafinanceira.nr_valor_conta = lvalor_transferencia_ICMS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                ' 22/10/2008 - f

                                Me.fichafinanceira.cd_conta = "1400"  ' Grava conta - Total da Nota Fiscal
                                Me.fichafinanceira.nr_valor_conta = lvalor_totalnota
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If

                            '======================================================
                            ' Ponto 8 - Apurar Recolhimentos
                            '======================================================

                            ' 12/02/2009 - Rls16 (Milton solicitou que o Total de Funrural sempre seja 2.3 do Valor Total da Nota) - i
                            '' 29/11/2008 - i 
                            ''lvalor_totalfunrural = Round(lvalor_volumeleite * FormatNumber(lvalor_funrural, 4), 2)  ' 22/10/2008
                            'If lst_incentivo_21 = "S" Then
                            '    lvalor_totalfunrural = Round(lvalor_totalnota * 0.023, 2)
                            'Else
                            '    lvalor_totalfunrural = Round(lvalor_volumeleite * FormatNumber(lvalor_funrural, 4), 2)  ' 22/10/2008
                            'End If
                            '' 29/11/2008 - f
                            'Fran 01/04/2009 i 
                            If lvalor_funrural = 0 Then 'Só gera 1500 se 0800 tiver valor
                                lvalor_totalfunrural = 0
                            Else
                                'Fran 01/04/2009 f

                                'fran 31/01/2019 i FUNRURAL 2019 LEI 13606
                                ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018
                                'fran 23/04/2017 f retorno do funrural para referencia Abril/2017
                                ''fran 28/09/2016 i 'funrural nao existe mais deve apenas calcular sest/senat (2.3 antes 2.1 para funrural e 0.2 para sestsenat)
                                ''lvalor_totalfunrural = Round(lvalor_totalnota * 0.023, 2)
                                'lvalor_totalfunrural = Round(lvalor_totalnota * 0.002, 2)
                                ''fran 28/09/2016 f
                                ''lvalor_totalfunrural = Round(lvalor_totalnota * 0.023, 2)
                                'fran 23/04/2017 f retorno do funrural para referencia Abril/2017
                                'lvalor_totalfunrural = Round(lvalor_totalnota * 0.015, 2)
                                ''fran 31/01/2018 f FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018

                                'Se o produtor optou por recolher FUNRURAL
                                If lst_funrural = "P" Then
                                    'lvalor_totalfunrural = Round(lvalor_totalnota * 0.003, 2) ' Calculo FunRural - desconta apenas SENAR/RAT
                                    lvalor_totalfunrural = Round(lvalor_totalnota * 0.002, 2) ' Calculo FunRural - desconta apenas SENAR/RAT
                                Else
                                    'SE A DANONE recolhe o FUNRURAL de acordo com cadastro de fornecedor
                                    lvalor_totalfunrural = Round(lvalor_totalnota * 0.015, 2) ' Calculo FunRural - desconta FUNRURAL +  SENAR/RAT
                                End If
                                'fran 31/01/2019 f FUNRURAL 2019 LEI 13606

                            End If
                            ' 12/02/2009 - Rls16 (Milton solicitou que o Total de Funrural sempre seja 2.3 do Valor Total da Nota) - f
                            If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021

                                Me.fichafinanceira.cd_conta = "1500"  ' Grava conta - Total FunRural
                                Me.fichafinanceira.nr_valor_conta = lvalor_totalfunrural
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If

                            lvalor_creditoICMS = Round(lvalor_ICMS * lpercentual_ICMS, 2)  ' 5%, 10% ou 20%, dependendo da faixa de volume

                            If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021

                                Me.fichafinanceira.cd_conta = "1600"  ' Grava conta - Incentivo ICMS
                                Me.fichafinanceira.nr_valor_conta = lvalor_creditoICMS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' 08/03/2012 - Projeto Themis - Novas Contas para Nota Fiscal no SAP - i
                                '======================================================
                                ' Ponto 8.a - Novas Contas para o SAP
                                '======================================================

                                ' ICMS
                                Me.fichafinanceira.cd_conta = "1250"  ' Grava conta - Alíquota ICMS
                                Me.fichafinanceira.nr_valor_conta = 0.12
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If

                            ' COFINS
                            lbase_COFINS = lvalor_totalnota  '  Definição em 08/03/2012 da Marildes (Danone)

                            If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021
                                Me.fichafinanceira.cd_conta = "2100"  ' Grava conta - Base COFINS
                                Me.fichafinanceira.nr_valor_conta = lbase_COFINS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "2150"  ' Grava conta - Alíquota COFINS
                                'Me.fichafinanceira.nr_valor_conta = 4.56
                                'fran 25/06/2012 i escopo complementar calculo Themis
                                'Me.fichafinanceira.nr_valor_conta = 0   ' 08/03/2012 - Definição da Marildes da Danone
                                'Fran 02/11/2015 i troca de aliquota de 4.56 para 3,80 de acordo com email em 30/10 de Ricardo Francisco /Ana
                                'Me.fichafinanceira.nr_valor_conta = 4.56
                                Me.fichafinanceira.nr_valor_conta = 3.8
                                'Fran 02/11/2015 f troca de aliquota de 4.56 para 3,80 de acordo com email em 30/10 de Ricardo Francisco /Ana
                                'fran 25/06/2012 f
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If
                            'fran 25/06/2012 i escopo complementar calculo Themis
                            'lvalor_COFINS = Convert.ToDecimal(lbase_COFINS * 0)
                            'Fran 02/11/2015 i troca de aliquota de 4.56 para 3,80 de acordo com email em 30/10 de Ricardo Francisco /Ana
                            'lvalor_COFINS = Convert.ToDecimal(Round(lbase_COFINS * 0.0456, 2))
                            lvalor_COFINS = Convert.ToDecimal(Round(lbase_COFINS * 0.038, 2))
                            'Fran 02/11/2015 f troca de aliquota de 4.56 para 3,80 de acordo com email em 30/10 de Ricardo Francisco /Ana
                            'fran 25/06/2012 f escopo complementar calculo Themis
                            If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021
                                Me.fichafinanceira.cd_conta = "2200"  ' Grava conta - Valor COFINS
                                Me.fichafinanceira.nr_valor_conta = lvalor_COFINS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If
                            ' PIS

                            lbase_PIS = lvalor_totalnota   '  Definição em 08/03/2012 da Marildes (Danone)
                            If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021
                                Me.fichafinanceira.cd_conta = "2300"  ' Grava conta - Base PIS
                                Me.fichafinanceira.nr_valor_conta = lbase_PIS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "2350"  ' Grava conta - Alíquota PIS
                                'Me.fichafinanceira.nr_valor_conta = 0.99
                                Me.fichafinanceira.nr_valor_conta = 0 ' 08/03/2012 - Definição da Marildes da Danone
                                'Me.fichafinanceira.nr_valor_conta = 0.825 'FRAN 26/08/2020 i ALTERACAO ALIQUOTA PIS 
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If
                            'fran 25/06/2012 i escopo complementar calculo Themis
                            'lvalor_PIS = Convert.ToDecimal(lbase_PIS * 0)
                            'Fran 02/11/2015 i troca de aliquota de 0,99 para 0,83 de acordo com email em 30/10 de Ricardo Francisco /Ana
                            'lvalor_PIS = Convert.ToDecimal(Round(lbase_PIS * 0.0099, 2))
                            'lvalor_PIS = Convert.ToDecimal(Round(lbase_PIS * 0.0083, 2)) FRAN 26/08/2020 i ALTERACAO ALIQUOTA PIS
                            lvalor_PIS = Convert.ToDecimal(Round(lbase_PIS * 0.00825, 2)) 'FRAN 26/08/2020 i ALTERACAO ALIQUOTA PIS

                            'Fran 02/11/2015 f troca de aliquota de 0,99 para 0,83 de acordo com email em 30/10 de Ricardo Francisco /Ana
                            'fran 25/06/2012 i escopo complementar calculo Themis
                            If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021
                                Me.fichafinanceira.cd_conta = "2400"  ' Grava conta - Valor PIS
                                Me.fichafinanceira.nr_valor_conta = lvalor_PIS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If
                            ' 08/03/2012 - Projeto Themis - Novas Contas para Nota Fiscal no SAP - f


                            '======================================================
                            ' Ponto 9 - Apurar Custos Danone  
                            '======================================================

                            lvalor_antesPISCONFINS = Round(lvalor_totalnota - lvalor_ICMS + lvalor_creditoICMS, 2)
                            lvalor_custounitario = lvalor_antesPISCONFINS / lvalor_volumeleite
                            lvalor_PISCOFINS = Round(lvalor_totalnota * 0.0555, 2)
                            lvalor_totalERP = Round(lvalor_antesPISCONFINS - lvalor_PISCOFINS, 2)
                            lvalor_custounitarioERP = lvalor_totalERP / lvalor_volumeleite

                            If lst_calculo_com_juros.Equals("N") Then 'fran 12/2021

                                Me.fichafinanceira.cd_conta = "1700"  ' Grava conta - Valor antes PIS e COFINS
                                Me.fichafinanceira.nr_valor_conta = lvalor_antesPISCONFINS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "1800"  ' Grava conta - Custo Unitário
                                Me.fichafinanceira.nr_valor_conta = lvalor_custounitario
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "1900"  ' Grava conta - PIS e COFINS
                                Me.fichafinanceira.nr_valor_conta = lvalor_PISCOFINS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "2000"  ' Grava conta - Total ERP
                                Me.fichafinanceira.nr_valor_conta = lvalor_totalERP
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "2010"  ' Grava conta - Custo Unitário ERP
                                Me.fichafinanceira.nr_valor_conta = lvalor_custounitarioERP
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                ' Desabilitar até a aprovação - f


                                ' 13/01/2009 - Desabilitado para buscar só na 1.a Unidade de Produção - i
                                ''======================================================
                                '' Ponto 11 - Gerar Valor do Adiantamento
                                ''======================================================
                                'Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                                'Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                                'Me.fichafinanceira.cd_conta = "0600"   ' Conta de Adiantamento
                                'Me.fichafinanceira.st_tipo_pagamento = "Q"
                                'lvalor_conta = Me.fichafinanceira.getFichaFinanceiraValorConta()
                                ' 13/01/2009 - Desabilitado para buscar só na 1.a Unidade de Produção - f


                                Me.fichafinanceira.cd_conta = "0600"    ' Adiantamento Quinzenal
                                Me.fichafinanceira.nr_valor_conta = lvalor_adiantamento     ' 16/01/2009
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If
                            '======================================================
                            ' Apurar DESCONTO TAXA IMA
                            '======================================================

                            'fran 09/2018 i alteração legal IMA
                            If lvalor_IMA_taxa > 0 Then
                                'Valor da taxa do iMA = para cada 1000 litros de leite deve ser pago ao IMA 0,49 centavos, sendo metade da DANONE metade do produtor
                                'formula volume leite dividido por 1000, resultado multiplicar pelo parametro em estabelecimento (0,49), e por fim dividir por 2 para colocar a parte do produtor
                                lvalor_IMA = Round((((lvalor_volumeleite / 1000) * lvalor_IMA_taxa) / 2), 2)

                                Me.fichafinanceira.cd_conta = "9995"    ' TAXA IMA DO PRODUTOR
                                Me.fichafinanceira.nr_valor_conta = lvalor_IMA
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'fran 02/2019 i aliquota ima
                                Me.fichafinanceira.cd_conta = "9994"  ' Grava conta - ALIQUOTA ima
                                Me.fichafinanceira.nr_valor_conta = lvalor_IMA_taxa
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                'fran 02/2019 f aliquota ima

                            Else
                                lvalor_IMA = 0
                            End If
                            'fran 09/2018 f alteração legal IMA

                            '======================================================
                            ' Ponto 13 - Apurar DESCONTO CLUBE DE COMPRAS
                            '======================================================

                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.id_natureza = 2  ' Desconto
                            Me.fichafinanceira.st_clube_compra = "S"  ' 20/08/2009 - Rls18 - Trazer somente somatório de descontos da Central para corrigir conta 1000
                            Me.fichafinanceira.cd_conta = ""    ' Limpa a conta 

                            ' 01/09/2009 - Rls19.2 - Trazer o valor absoluto dos descontos (sem sinal), pois eles lançam com sinal de negativo - i
                            'lvalor_descontos = Me.fichafinanceira.getFichaFinanceiraValorConta()  ' Somatório dos descontos no mes de referencia
                            lvalor_descontos = Math.Abs(Me.fichafinanceira.getFichaFinanceiraValorConta())  ' Somatório dos descontos no mes de referencia
                            ' 01/09/2009 - Rls19.2 - Trazer o valor absoluto dos descontos (sem sinal), pois eles lançam com sinal de negativo - f


                            Me.fichafinanceira.st_clube_compra = ""  ' 20/08/2009 - Rls18 - Limpa atributo para próximas utilizações
                            'fran 07/2017 - guarda desconto para facilitar conferencia calculo i
                            Me.fichafinanceira.cd_conta = "0900"    ' Desconto Clube Compras
                            Me.fichafinanceira.nr_valor_conta = lvalor_descontos
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()
                            'fran 07/2017 - guarda desconto para facilitar conferencia calculo f

                            'fran 07/2017 i 
                            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                            'APURAR ANTECIPACAO
                            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                            lvalor_antecipacao = 0
                            lvalor_descontos_antecipacao = 0
                            lvalor_bonus_poupanca = 0
                            lvalor_reposicao_antecipacao = 0 'fran 02/2019 reposicao de preco antecipacao
                            'se deve tratar antecipacao e nao é propriedade com consolidação (se o volume de todas as UPs ds propriedade for igual ao volume apurado para a UP, tem apenas uma UP com volume)
                            'If Me.nr_dias_antecipacao > 0 AndAlso lvalor_volume_total_propriedade = lvalor_volumeleite Then
                            'If Me.nr_dias_antecipacao > 0 Then 'fran 12/2021
                            If lst_calculo_com_juros = "N" AndAlso Me.nr_dias_antecipacao > 0 Then 'fran 12/2021

                                'fran 10/2017 - deve somar bonus da poupanca a antecipacao
                                lvalor_bonus_poupanca = Math.Abs(Me.fichafinanceira.getFichaFinanceiraValorBonusPoupanca())  ' Somatório das contas de bonus poupanca 5500 e bonus extra poupanca 5550

                                'fran 02/2019 i antecipaçlao deve considerar contas de reposicao de preco (natureza composicao do preço)
                                lvalor_reposicao_antecipacao = Math.Abs(Me.fichafinanceira.getFichaFinanceiraValorReposAntecipacao())  ' Somatório das contas de reposicao qualidade e reposicao de preço 9997 e 9998
                                'fran 02/2019 f 

                                'fran 09/2017 i antecipação
                                lvalor_descontos_antecipacao = Math.Abs(Me.fichafinanceira.getFichaFinanceiraValorDescontosAntecipacao())  ' Somatório dos descontos do tipo central retirando frete (8000) e educampo (4000)
                                Me.fichafinanceira.st_clube_compra = ""
                                'guarda desconto antecipacao para facilitar conferencia calculo 
                                Me.fichafinanceira.cd_conta = "0910"    ' Desconto Antecipação
                                Me.fichafinanceira.nr_valor_conta = lvalor_descontos_antecipacao
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                'fran 09/2017 f antecipação

                                'guarda as contas de volume utilizas na apuracao antecipação
                                Me.fichafinanceira.cd_conta = "0710"    ' Volume Total Propriedade
                                Me.fichafinanceira.nr_valor_conta = lvalor_volume_total_propriedade
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "0720"    ' Volume Leite Antecipação
                                Me.fichafinanceira.nr_valor_conta = lvalor_volume_antecipacao
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'apura valor de antecipação bruto
                                'lvalor_antecipacao = Round((lpreco_negociado + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_incentivofiscal - lvalor_funrural + lvalor_incentivo_21 + lvalor_incentivo_24) * lvalor_volume_antecipacao, 4)
                                lvalor_antecipacao = Round((lpreco_negociado + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_incentivofiscal - lvalor_funrural + lvalor_incentivo_24_unitario) * lvalor_volume_antecipacao, 4)

                                'fran 02/2019 i ao valor bruto de antecipacao deve ser somado as contas de reposicao de preço e de qualidade
                                'fran 10/2017 i
                                'soma ao valor bruto, o bonus de poupanca
                                'lvalor_antecipacao = lvalor_antecipacao + lvalor_bonus_poupanca
                                'fran 10/2017 f
                                lvalor_antecipacao = lvalor_antecipacao + lvalor_bonus_poupanca + lvalor_reposicao_antecipacao
                                'fran 02/2019 f 

                                Me.fichafinanceira.cd_conta = "0750"    ' Antecipação Bruto
                                Me.fichafinanceira.nr_valor_conta = Round(lvalor_antecipacao, 2)
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'fran 09/2017i
                                'lvalor_antecipacao = Round(lvalor_antecipacao - lvalor_adiantamento - lvalor_descontos, 2)
                                lvalor_antecipacao = Round(lvalor_antecipacao - lvalor_adiantamento - lvalor_descontos_antecipacao, 2)

                                'fran 27/10/2017 i
                                ''se valor antecipacao liquido for menor que zero ou  a conta de rendimento liquido for menor que zero, nao antecipar valor
                                'If lvalor_antecipacao < 0 OrElse (lvalor_totalnota - lvalor_totalfunrural - lvalor_adiantamento - lvalor_descontos - lvalor_antecipacao) < 0 Then
                                '    lvalor_antecipacao = 0
                                'End If
                                ''fran 09/2017f

                                'se valor antecipacao liquido for negativo ou igual a zero
                                If lvalor_antecipacao <= 0 Then
                                    lvalor_antecipacao = 0
                                End If

                                'se valor antecipacao liquido maior que zero e  a conta de rendimento liquido for menor que zero, nao antecipar valor
                                If lvalor_antecipacao > 0 Then
                                    'se o rendimento liquido for ficar negativo
                                    If (lvalor_totalnota - lvalor_totalfunrural - lvalor_adiantamento - lvalor_descontos - lvalor_antecipacao) < 0 Then
                                        'valor antecipacao liquido será o valor antecipação subtraindo a diferenca do rendimento liquito sobre a antecipação + 10 (valor simbolico de  seguranca para nao gerar nota final com valor zero
                                        lvalor_antecipacao = lvalor_antecipacao - (Math.Abs(lvalor_totalnota - lvalor_totalfunrural - lvalor_adiantamento - lvalor_descontos - lvalor_antecipacao) + 10)
                                        'se mesmo retirando a difereça e somando apenas 10 reais a anetcipação ficar negativa
                                        If lvalor_antecipacao < 0 Then
                                            lvalor_antecipacao = 0
                                        End If
                                    End If
                                End If
                                'fran 10/2017f

                                Me.fichafinanceira.cd_conta = "0700"    ' Antecipação Liquido
                                Me.fichafinanceira.nr_valor_conta = lvalor_antecipacao
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If

                            'fran 07/2017 f 

                            '======================================================
                            ' Ponto 13 - Apurar Rendimento Líquido
                            '======================================================


                            ' 20/08/2009 - Rls18 - Calcular a conta 1000 da mesma forma como é calculada na emissão da Nota Fiscal - i
                            'lvalor_subtotal_receber = lvalor_rendbruto - lvalor_totalfunrural - lvalor_descontos
                            'fran 07/2017 i rendimento liquido deve descontar antecipacao
                            'lvalor_subtotal_receber = lvalor_totalnota - lvalor_totalfunrural - lvalor_adiantamento - lvalor_descontos
                            lvalor_subtotal_receber = lvalor_totalnota - lvalor_totalfunrural - lvalor_adiantamento - lvalor_descontos - lvalor_antecipacao
                            'fran 07/2017 f rendimento liquido deve descontar antecipacao
                            ' 20/08/2009 - Rls18 - Calcular a conta 1000 da mesma forma como é calculada na emissão da Nota Fiscal - f

                            'se faz calculo com juros, apura a conta de custo financeiro sobre o rendimento liquido e reapura as contas do calculo que utilizam composicao de preco
                            If lst_calculo_com_juros.Equals("S") Then 'fran 12/2021
                                'apura a conta de rendimento liquido base (serve de base para o custo financeiro)
                                Me.fichafinanceira.cd_conta = "1100"    ' Rendimento Líquido Base
                                Me.fichafinanceira.nr_valor_conta = lvalor_subtotal_receber
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'apura custo financeiro para juros
                                Me.fichafinanceira.cd_conta = "8999"
                                Me.fichafinanceira.nr_valor_conta = Round(lvalor_subtotal_receber * nr_valor_juros, 2)
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                lvalor_custo_financeiro = Me.fichafinanceira.nr_valor_conta


                                Me.fichafinanceira.cd_conta = "0255"  ' Grava conta - composicao preco base
                                Me.fichafinanceira.nr_valor_conta = lvalor_composicao_preco
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'fran 11/2022 i
                                'lvalor_composicao_preco_total = lvalor_composicao_preco_total + lvalor_custo_financeiro
                                'lvalor_composicao_preco = lvalor_composicao_preco_unitario + (lvalor_composicao_preco_total / lvalor_volumeleite)
                                lvalor_composicao_preco = lvalor_composicao_preco + (lvalor_custo_financeiro / lvalor_volumeleite)
                                'fran 11/2022 f

                                Me.fichafinanceira.cd_conta = "0250"  ' Grava conta - composicao preco final
                                Me.fichafinanceira.nr_valor_conta = lvalor_composicao_preco
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'novo preco base
                                lpreco_base = lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco
                                'repete o final do calculo para considerar o custo financeiro dos juros na composicao de preco
                                'agora grava as contas
                                Me.fichafinanceira.cd_conta = "0050"  ' Grava conta - Preço Bruto
                                Me.fichafinanceira.nr_valor_conta = lpreco_base
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                If lst_transferencia_credito = "S" Then
                                    lpreco_notafiscal = Round((Round(lpreco_negociado / 0.977, 4) + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) / 0.88, 4)  '01/01/2014 rls 1.03.35.05

                                    'Se o produtor optou por recolher FUNRURAL
                                    If lst_funrural = "P" Then
                                        'lvalor_funrural = lpreco_notafiscal * 0.003  ' Calculo FunRural - desconta apenas SENAR/RAT
                                        lvalor_funrural = lpreco_notafiscal * 0.002  ' Calculo FunRural - desconta apenas SENAR/RAT
                                    Else
                                        'SE A DANONE recolhe o FUNRURAL de acordo com cadastro de fornecedor
                                        lvalor_funrural = lpreco_notafiscal * 0.015  ' Calculo FunRural -desconta FUNRURAL + SENAR/RAT
                                    End If
                                    'fran 31/01/2019 f FUNRURAL 2019 LEI 13606
                                Else
                                    'If lst_categoria = "J" Then  'Se pessoa jurídica
                                    '    'fran 22/07/2016 i Calculo Geometricco - Não deve imbutir funrural - Solicitação ANa Souza/Ricardo referente ao calculo
                                    '    lpreco_notafiscal = Round(lpreco_negociado, 4)
                                    '    'fran 22/07/2016 f

                                    '    lvalor_funrural = 0

                                    'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i
                                    If lst_incentivo_fiscal <> "N" AndAlso lbapurar25 = True Then  ' Se tem Incentivo Fiscal, Permaneu a mesma coisa da versão anterior
                                        'If lst_incentivo_fiscal <> "N" Then  ' Se tem Incentivo Fiscal, Permaneu a mesma coisa da versão anterior
                                        'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i
                                        'lvalor_incentivofiscal = Round(lpreco_base * 0.025, 4)  ' Adri Projeto Themis 28/05/2012 - chamado 1553 - Calcula 2,5% de Incentivo Fiscal com arredondamento devido ao SAP
                                        lvalor_incentivofiscal = lpreco_base * 0.025

                                        If lst_categoria = "J" Then  'Se pessoa jurídica
                                            lvalor_funrural = 0
                                        Else
                                            'Se o produtor optou por recolher FUNRURAL
                                            If lst_funrural = "P" Then
                                                'lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.003, 4)  ' Calculo FunRural - desconta apenas SENAR/RAT
                                                lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.002, 4)  ' Calculo FunRural - desconta apenas SENAR/RAT
                                            Else
                                                'SE A DANONE recolhe o FUNRURAL de acordo com cadastro de fornecedor
                                                lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.015, 4)  ' Calculo FunRural -desconta FUNRURAL + SENAR/RAT
                                            End If
                                            'fran 01/2019 f FUNRURAL 2019 LEI 13606
                                        End If

                                        lpreco_notafiscal = Round(lpreco_negociado, 4)

                                        Me.fichafinanceira.cd_conta = "0300"  ' Grava conta - Incentivo Fiscal
                                        Me.fichafinanceira.nr_valor_conta = lvalor_incentivofiscal
                                        Me.fichafinanceira.nr_valor_12 = lvalor_incentivofiscal
                                        Me.fichafinanceira.st_origem_conta = "C"
                                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                        Me.fichafinanceira.insertFichaFinanceiraItens()
                                        Me.fichafinanceira.nr_valor_12 = 0

                                        lnrvaloraux = 0
                                        Me.fichafinanceira.cd_conta = "2065"  ' Grava conta - Incentivo Fiscal
                                        If lnr_volume_incentivo25 > 0 Then
                                            Me.fichafinanceira.nr_valor_conta = Round(lvalor_incentivofiscal * lnr_volume_incentivo25, 2)
                                            lnrvaloraux = lvalor_incentivofiscal * lnr_volume_incentivo25
                                        Else
                                            Me.fichafinanceira.nr_valor_conta = Round(lvalor_incentivofiscal * lvalor_volumeleite, 2)
                                            lnrvaloraux = lvalor_incentivofiscal * lvalor_volumeleite
                                        End If

                                        Me.fichafinanceira.st_origem_conta = "C"
                                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                        Me.fichafinanceira.insertFichaFinanceiraItens()

                                        Me.fichafinanceira.cd_conta = "2070"  ' Grava conta - 2070 Incentivo 2.5 liquido VALOR INCENTIVO - PISCOFINS 4,625%
                                        Me.fichafinanceira.nr_valor_conta = Round(lnrvaloraux * (1 - (0.04625)), 2)
                                        Me.fichafinanceira.nr_valor_12 = Round(lnrvaloraux * (1 - (0.04625)), 12)
                                        Me.fichafinanceira.st_origem_conta = "C"
                                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                        Me.fichafinanceira.insertFichaFinanceiraItens()

                                        Me.fichafinanceira.cd_conta = "0055"  ' Grava conta - 0055 preço liquido 2.5 preço bruto - piscofins 4,625% sem desconto ICMS sobre reço
                                        Me.fichafinanceira.nr_valor_conta = Round(lpreco_base - (lpreco_base * 0.12) - (lpreco_base * 0.04625), 4)
                                        Me.fichafinanceira.nr_valor_12 = Round(lpreco_base - (lpreco_base * 0.12) - (lpreco_base * 0.04625), 12)
                                        Me.fichafinanceira.st_origem_conta = "C"
                                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                        Me.fichafinanceira.insertFichaFinanceiraItens()

                                        Me.fichafinanceira.nr_valor_12 = 0

                                    Else
                                        lpreco_notafiscal = Round(lpreco_negociado, 4)

                                        If lst_categoria = "J" Then  'Se pessoa jurídica
                                            lvalor_funrural = 0
                                        Else
                                            'Se o produtor optou por recolher FUNRURAL
                                            If lst_funrural = "P" Then
                                                'lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.003, 4) ' Calculo FunRural - desconta apenas SENAR/RAT
                                                lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.002, 4) ' Calculo FunRural - desconta apenas SENAR/RAT
                                            Else
                                                'SE A DANONE recolhe o FUNRURAL de acordo com cadastro de fornecedor
                                                lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.015, 4) ' Calculo FunRural - desconta FUNRURAL +  SENAR/RAT
                                            End If
                                        End If
                                        'fran 31/01/2019 f FUNRURAL 2019 LEI 13606
                                    End If
                                End If

                                Me.fichafinanceira.cd_conta = "0041"  ' Grava conta - Preco Nota Fiscal
                                Me.fichafinanceira.nr_valor_conta = lpreco_notafiscal
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "0800"  ' Grava conta - Preco Funrural
                                Me.fichafinanceira.nr_valor_conta = lvalor_funrural
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                If lvalor_funrural <> 0 Then
                                    Me.fichafinanceira.cd_conta = "0801"  ' Grava conta - ALIQUOTA Funrural
                                    Me.fichafinanceira.nr_valor_conta = lvalor_aliquota_funrural
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                End If

                                '======================================
                                ' Ponto 5 - Apurar Preço Unitário 
                                '======================================
                                If lst_transferencia_credito = "S" Then
                                    lpreco_unitario = Round(lpreco_notafiscal - lvalor_funrural, 4)
                                Else
                                    lpreco_unitario = Round(lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_incentivofiscal - lvalor_funrural, 4)

                                End If

                                Me.fichafinanceira.cd_conta = "0040"  ' Grava conta - Preco Unitário
                                Me.fichafinanceira.nr_valor_conta = lpreco_unitario
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                '======================================================
                                ' Ponto 6 - Apurar Rendimento Bruto da Unidade Produção
                                '======================================================
                                lvalor_rendbruto = Round(lvalor_volumeleite * lpreco_unitario, 2)

                                Me.fichafinanceira.cd_conta = "0200"  ' Grava conta - Preco Unitário
                                Me.fichafinanceira.nr_valor_conta = lvalor_rendbruto
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                '======================================================
                                ' Ponto 7 - Apurar dados da Nota Fiscal
                                '======================================================
                                ' 22/10/2008 - i
                                If lst_incentivo_21 = "S" Then
                                    lvalor_incentivo_21 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * 0.021, 4) * lvalor_volumeleite, 2)  ' fran 01/01/2014 inclusao gordura
                                    Me.fichafinanceira.cd_conta = "2050"  ' Grava conta - Incentivo 2.1%
                                    Me.fichafinanceira.nr_valor_conta = lvalor_incentivo_21
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                End If
                                'fran 11/2022 i
                                'If lst_incentivo_24 = "S"  Then
                                '    lvalor_incentivo_24 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * lvalor_volumeleite, 4) * 0.024, 2) 'fran 01/01/2014 - inclusao gordutra
                                '    lvalor_incentivo_24_unitario = lvalor_incentivo_24 / lvalor_volumeleite 'fran 08/2017
                                'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i
                                lnrvaloraux = 0
                                If lst_incentivo_24 = "S" OrElse lbapurar24 = True Then
                                    'If lst_incentivo_24 = "S" Then
                                    'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i
                                    lvalor_incentivo_24_unitario = lpreco_base * 0.024
                                    If lnr_volume_incentivo24 > 0 Then 'se tem volume 2,4 apurado
                                        lvalor_incentivo_24 = Round(lvalor_incentivo_24_unitario * lnr_volume_incentivo24, 2)
                                        lnrvaloraux = Round(lvalor_incentivo_24_unitario * lnr_volume_incentivo24, 12)
                                    Else
                                        lvalor_incentivo_24 = Round(lvalor_incentivo_24_unitario * lvalor_volumeleite, 2)
                                        lnrvaloraux = Round(lvalor_incentivo_24_unitario * lvalor_volumeleite, 12)
                                    End If
                                    'fran 11/2022 f - gravar unitario igual 2,5

                                    Me.fichafinanceira.cd_conta = "2055"  ' Grava conta - Incentivo 2.4%
                                    Me.fichafinanceira.nr_valor_conta = lvalor_incentivo_24
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()

                                    Me.fichafinanceira.cd_conta = "0350"  ' Grava conta - Incentivo 2.4%
                                    Me.fichafinanceira.nr_valor_conta = lvalor_incentivo_24_unitario
                                    Me.fichafinanceira.nr_valor_12 = lvalor_incentivo_24_unitario
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()

                                    Me.fichafinanceira.cd_conta = "2060"  ' Grava conta - 2060 Incentivo 2.4 liquido VALOR INCENTIVO - PISCOFINS 4,625%
                                    Me.fichafinanceira.nr_valor_conta = Round(lnrvaloraux * (1 - (0.04625)), 2)
                                    Me.fichafinanceira.nr_valor_12 = Round(lnrvaloraux * (1 - (0.04625)), 12)
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()

                                    Me.fichafinanceira.cd_conta = "0060"  ' Grava conta - 0060 preço liquido 2.4 preço bruto - piscofins 4,625% sem desconto ICMS sobre reço
                                    Me.fichafinanceira.nr_valor_conta = Round(lpreco_base - Round(lpreco_base * 0.04625, 4), 4)
                                    Me.fichafinanceira.nr_valor_12 = Round(lpreco_base - (lpreco_base * 0.04625), 12)
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()

                                    Me.fichafinanceira.nr_valor_12 = 0 'limpa campo
                                End If

                                'fran dez/2022 i
                                If lvalor_incentivofiscal = 0 AndAlso lvalor_incentivo_24 = 0 Then 'fran 12/2022
                                    'grava a 0060 preco liq icms 0, se nao tem a conta 55 (preco liq quando tem que abater icms) e nao apurou a 0060 com incentivo 2.4 ou seja se nao tem nenhum incentivo, calcula o preco liq
                                    Me.fichafinanceira.cd_conta = "0060"  ' Grava conta - 0060 preço liquido sem icms preço bruto - piscofins 4,625% sem desconto ICMS sobre reço
                                    Me.fichafinanceira.nr_valor_conta = Round(lpreco_base - Round(lpreco_base * 0.04625, 4), 4)
                                    Me.fichafinanceira.nr_valor_12 = Round(lpreco_base - (lpreco_base * 0.04625), 12)
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                    Me.fichafinanceira.nr_valor_12 = 0 'limpa campo

                                End If
                                'fran dez/2022 f

                                If lst_transferencia_credito = "S" Then
                                    lvalor_totalnota = Round(lpreco_notafiscal * lvalor_volumeleite, 2)
                                Else
                                    If lst_incentivo_fiscal = "N" Then 'se nao tem incentivo
                                        'Conta 1400 = (Preço NT + Total Qualidade + Redutase + Reposicao + Composicao Preço) * VOLUME + Incentivo 21 + incentivo 24
                                        lvalor_totalnota = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2) 'fran 01/01/2014 inclusao gordura
                                    Else 'se tem incentivo
                                        'fran 11/2022
                                        'lvalor_totalnota = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) + Round(lvalor_incentivofiscal * lvalor_volumeleite, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2) ' adri 14/09/2015 - chamado 2377 - considerar o incentivo fiscal 2,5% que já está calculado, pois gerava diferença no extrato
                                        If lnr_volume_incentivo25 > 0 Then

                                            lvalor_totalnota = Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)
                                            lvalor_totalnota = Round(lvalor_totalnota + Round(lvalor_incentivofiscal * lnr_volume_incentivo25, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2)
                                        Else
                                            lvalor_totalnota = Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)
                                            lvalor_totalnota = Round(lvalor_totalnota + Round(lvalor_incentivofiscal * lvalor_volumeleite, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2)

                                        End If

                                    End If
                                End If

                                If lst_transferencia_credito = "S" Then
                                    lvalor_baseICMS = lvalor_totalnota
                                    lvalor_ICMS = Round(lvalor_baseICMS * 0.12, 2)
                                    lvalor_transferencia_ICMS = Round(lpreco_notafiscal * 0.12 * lvalor_volumeleite, 2)
                                Else
                                    If lst_incentivo_fiscal <> "N" Or lst_uf_produtor = "RJ" Then  ' 22/10/2008
                                        'lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)  ' fran 01/01/2014 inclusao gordura
                                        'lvalor_ICMS = Round(lvalor_baseICMS * 0.12, 2)
                                        'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i
                                        If lbapurar25 = False Then ' fran 11/2022 se nao é pra apurar 2.5
                                            lvalor_baseICMS = 0
                                            lvalor_ICMS = 0
                                        Else
                                            If lnr_volume_incentivo25 > 0 Then
                                                lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lnr_volume_incentivo25, 2)
                                            Else
                                                lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)  ' fran 01/01/2014 inclusao gordura

                                            End If

                                            lvalor_ICMS = Round(lvalor_baseICMS * 0.12, 2)

                                        End If
                                        'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i

                                    Else
                                        lvalor_baseICMS = 0
                                        lvalor_ICMS = 0
                                    End If
                                End If

                                Me.fichafinanceira.cd_conta = "1200"  ' Grava conta - Base ICMS
                                Me.fichafinanceira.nr_valor_conta = lvalor_baseICMS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "1300"  ' Grava conta - Base ICMS
                                Me.fichafinanceira.nr_valor_conta = lvalor_ICMS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' 22/10/2008 - i
                                Me.fichafinanceira.cd_conta = "2040"  ' Grava conta - Transferência de ICMS
                                Me.fichafinanceira.nr_valor_conta = lvalor_transferencia_ICMS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                ' 22/10/2008 - f

                                Me.fichafinanceira.cd_conta = "1400"  ' Grava conta - Total da Nota Fiscal
                                Me.fichafinanceira.nr_valor_conta = lvalor_totalnota
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()


                                '======================================================
                                ' Ponto 8 - Apurar Recolhimentos
                                '======================================================
                                If lvalor_funrural = 0 Then 'Só gera 1500 se 0800 tiver valor
                                    lvalor_totalfunrural = 0
                                Else

                                    'Se o produtor optou por recolher FUNRURAL
                                    If lst_funrural = "P" Then
                                        'lvalor_totalfunrural = Round(lvalor_totalnota * 0.003, 2) ' Calculo FunRural - desconta apenas SENAR/RAT
                                        lvalor_totalfunrural = Round(lvalor_totalnota * 0.002, 2) ' Calculo FunRural - desconta apenas SENAR/RAT
                                    Else
                                        'SE A DANONE recolhe o FUNRURAL de acordo com cadastro de fornecedor
                                        lvalor_totalfunrural = Round(lvalor_totalnota * 0.015, 2) ' Calculo FunRural - desconta FUNRURAL +  SENAR/RAT
                                    End If
                                    'fran 31/01/2019 f FUNRURAL 2019 LEI 13606

                                End If

                                Me.fichafinanceira.cd_conta = "1500"  ' Grava conta - Total FunRural
                                Me.fichafinanceira.nr_valor_conta = lvalor_totalfunrural
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                lvalor_creditoICMS = Round(lvalor_ICMS * lpercentual_ICMS, 2)  ' 5%, 10% ou 20%, dependendo da faixa de volume

                                Me.fichafinanceira.cd_conta = "1600"  ' Grava conta - Incentivo ICMS
                                Me.fichafinanceira.nr_valor_conta = lvalor_creditoICMS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' 08/03/2012 - Projeto Themis - Novas Contas para Nota Fiscal no SAP - i
                                '======================================================
                                ' Ponto 8.a - Novas Contas para o SAP
                                '======================================================

                                ' ICMS
                                Me.fichafinanceira.cd_conta = "1250"  ' Grava conta - Alíquota ICMS
                                Me.fichafinanceira.nr_valor_conta = 0.12
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' COFINS
                                lbase_COFINS = lvalor_totalnota  '  Definição em 08/03/2012 da Marildes (Danone)
                                Me.fichafinanceira.cd_conta = "2100"  ' Grava conta - Base COFINS
                                Me.fichafinanceira.nr_valor_conta = lbase_COFINS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "2150"  ' Grava conta - Alíquota COFINS
                                Me.fichafinanceira.nr_valor_conta = 3.8
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                lvalor_COFINS = Convert.ToDecimal(Round(lbase_COFINS * 0.038, 2))
                                Me.fichafinanceira.cd_conta = "2200"  ' Grava conta - Valor COFINS
                                Me.fichafinanceira.nr_valor_conta = lvalor_COFINS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' PIS

                                lbase_PIS = lvalor_totalnota   '  Definição em 08/03/2012 da Marildes (Danone)
                                Me.fichafinanceira.cd_conta = "2300"  ' Grava conta - Base PIS
                                Me.fichafinanceira.nr_valor_conta = lbase_PIS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "2350"  ' Grava conta - Alíquota PIS
                                Me.fichafinanceira.nr_valor_conta = 0 ' 08/03/2012 - Definição da Marildes da Danone
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                lvalor_PIS = Convert.ToDecimal(Round(lbase_PIS * 0.00825, 2)) 'FRAN 26/08/2020 i ALTERACAO ALIQUOTA PIS

                                Me.fichafinanceira.cd_conta = "2400"  ' Grava conta - Valor PIS
                                Me.fichafinanceira.nr_valor_conta = lvalor_PIS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                '======================================================
                                ' Ponto 9 - Apurar Custos Danone  
                                '======================================================

                                lvalor_antesPISCONFINS = Round(lvalor_totalnota - lvalor_ICMS + lvalor_creditoICMS, 2)
                                lvalor_custounitario = lvalor_antesPISCONFINS / lvalor_volumeleite
                                lvalor_PISCOFINS = Round(lvalor_totalnota * 0.0555, 2)
                                lvalor_totalERP = Round(lvalor_antesPISCONFINS - lvalor_PISCOFINS, 2)
                                lvalor_custounitarioERP = lvalor_totalERP / lvalor_volumeleite

                                Me.fichafinanceira.cd_conta = "1700"  ' Grava conta - Valor antes PIS e COFINS
                                Me.fichafinanceira.nr_valor_conta = lvalor_antesPISCONFINS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "1800"  ' Grava conta - Custo Unitário
                                Me.fichafinanceira.nr_valor_conta = lvalor_custounitario
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "1900"  ' Grava conta - PIS e COFINS
                                Me.fichafinanceira.nr_valor_conta = lvalor_PISCOFINS
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "2000"  ' Grava conta - Total ERP
                                Me.fichafinanceira.nr_valor_conta = lvalor_totalERP
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "2010"  ' Grava conta - Custo Unitário ERP
                                Me.fichafinanceira.nr_valor_conta = lvalor_custounitarioERP
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                ' Desabilitar até a aprovação - f

                                ''======================================================
                                '' Ponto 11 - Gerar Valor do Adiantamento
                                ''======================================================


                                Me.fichafinanceira.cd_conta = "0600"    ' Adiantamento Quinzenal
                                Me.fichafinanceira.nr_valor_conta = lvalor_adiantamento     ' 16/01/2009
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()


                                '======================================================
                                ' Ponto 13 - Apurar Rendimento Líquido
                                '======================================================
                                lvalor_subtotal_receber = lvalor_totalnota - lvalor_totalfunrural - lvalor_adiantamento - lvalor_descontos - lvalor_antecipacao

                            End If


                            Me.fichafinanceira.cd_conta = "1000"    ' Rendimento Líquido
                            Me.fichafinanceira.nr_valor_conta = lvalor_subtotal_receber
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()


                            ' Chamado 243 - 28/04/2009 Rls 17.5 - Não gerar Nota Fiscal quando também não há Preço Negociado - i
                            '==============================================================================
                            ' Ponto 99 - Atualiza N.o da Nota Fiscal (se Cálculo Definitivo e for Produtor)
                            '===============================================================================
                            If Me.st_pagamento = "D" Then   ' Se Cálculo Definitivo 
                                Me.fichafinanceira.nr_nota_fiscal = Me.getCalculoNumeroNotaFiscal()
                                If IsDBNull(dsCalculoProdutor.Tables(0).Rows(li).Item("nr_serie")) Then
                                    Me.fichafinanceira.nr_serie = ""
                                Else
                                    Me.fichafinanceira.nr_serie = dsCalculoProdutor.Tables(0).Rows(li).Item("nr_serie")
                                End If
                                Me.fichafinanceira.updateFichaFinanceiraNF()   ' Nova procedure


                            End If
                            ' Chamado 243 - 28/04/2009 Rls 17.5 - Não gerar Nota Fiscal quando também não há Preço Negociado - f


                        End If   ' Fim Se grupo 1- Produtor

                        Me.calculoexecucao.st_calculo_execucao_itens = "2"   '  Seta Unidade/U.Producao = status 2-Sucesso
                        Me.calculoexecucao.updateCalculoExecucaoItens()

                        ' adri 06/03/2013 Chamado 1678 (Seta status para 'D' - Definitivo somente se o cálculo foi executado até o fim) - i
                        If Me.st_pagamento = "D" Then
                            Me.fichafinanceira.updateFichaFinanceiraDefinitivobyUnidadeProducao()
                            'fran 01/2016 i 
                            'Atualiza campo ULTREFCALC da poupanca adesao quando o calculo ficou definitivo
                            Me.updateCalculoPoupancaAdesao()
                            'fran 01/2016 f

                        End If
                        ' adri 06/03/2013 Chamado 1678 (Seta status para 'D' - Definitivo somente se o cálculo foi executado até o fim) - f

                    Else
                        Me.calculoexecucao.st_calculo_execucao_itens = "4"   '  Seta Unidade/U.Producao = status 4-Não Calculado
                        Me.calculoexecucao.updateCalculoExecucaoItens()
                    End If  ' Se fim Volume Leite = 0


                End If  '  Fim se status pagamento <> "D" - Definitivo
Calcular_Proxima:
            Next
            'Next

            '=============================================================================================================
            '  PROJETO THEMIS - PROCESSO DE CÁLCULO CONSOLIDADO POR INSCRIÇÃO ESTADUAL
            '=============================================================================================================
            ' 06/03/2012 - Projeto Themis - Processo de Cálculo unificado por IE - i
            Dim li_precomedio As Int32
            'Dim lvalor_volumeleitemedio As Decimal

            Me.st_tipo_pagamento = "C"  ' Inicializa C - Cálculo Consolidado

            ' Inicializa Ficha Financeira

            fichafinanceira.dt_referencia = Me.dt_referencia
            fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento  ' Cálculo Consolidado
            fichafinanceira.id_modificador = Me.id_modificador
            fichafinanceira.id_calculo_execucao = Me.id_calculo_execucao

            ' Inicializa variáveis
            lid_pessoa_anterior = 0
            lid_propriedade_anterior = 0
            lst_incentivo_fiscal = "N"
            lst_considera_qualidade = "N"
            lst_transferencia_credito = "N"
            lst_incentivo_21 = "N"
            lst_incentivo_24 = "N"
            lst_categoria = "F"
            lpercentual_ICMS = 0
            lst_uf_produtor = ""
            Me.dt_referencia_start = Me.dt_referencia
            Me.dt_referencia_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))
            Dim lmedia_analise As Decimal  ' adri 11/07/2016 - chamado 2448 - Campo para apurar média ponderada do teor da análise
            lnr_volume_anual_pago = 0 'fran 11/2022
            lnr_volume_incentivo25 = 0 'fran 11/2022
            lnr_volume_incentivo24 = 0 'fran 11/2022
            lnr_volume_saldo_limite = 0 'fran 11/2022
            lbapurar24 = False
            lbapurar25 = False


            Dim dsCalculoProdutorConsolidado As DataSet = getCalculoProdutorSelecionadoConsolidado()

            ' Para cada Propriedade/Up (traz a primeira somente)
            For li = 0 To dsCalculoProdutorConsolidado.Tables(0).Rows.Count - 1

                '====================================
                ' Inicializar Dados do Produtor
                '====================================
                If Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_pessoa")) <> lid_pessoa_anterior Then
                    lid_pessoa_anterior = Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_pessoa"))
                    lid_pessoa_grupo = Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_grupo"))
                    lst_categoria = dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("st_categoria")
                    lst_uf_produtor = dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("cd_uf")

                    'fran 31/01/2019 i FUNRURAL 2019 LEI 13606
                    If Not (IsDBNull(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("st_funrural"))) AndAlso dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("st_funrural").ToString.Equals("P") Then
                        lst_funrural = "P" 'funrural pago pelo PRODUTOR, DANONE desconta apenas 0.3 do SENAR/RAT
                        'lvalor_aliquota_funrural = 0.3
                        lvalor_aliquota_funrural = 0.2
                    Else
                        lst_funrural = "D" 'funrural recolhido pela DANONE, DANONE desconta apenas 1.5 (0.3 do SENAR/RAT + 1.2 FUNRURAL)
                        lvalor_aliquota_funrural = 1.5
                    End If
                    'Fran 31/01/2019 f 

                    'fran 07/2017 i- calculo por contrato
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    'CALCULO POR CONTRATO - BUSCAR VARIAVEIS A CADA PRODUTOR
                    '*************************************************************************************************************************************************
                    lvalor_volumetabela = 0
                    lvalor_volumetabela_dia = 0
                    lvalor_indicador = 0
                    lvalor_adicional24hrs = 0
                    lvalor_adicional48hrs = 0
                    lid_situacao_indicador_preco = 0 'fran dango 2018
                    lid_situacao_pessoa_contrato = 0 'fran dango 2018

                    Me.id_contrato_validade = Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_contrato_validade")) 'guarda o contrato validade para buscar adiconal de volume e qualidade

                    If Not (IsDBNull(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("st_contrato_mercado"))) AndAlso dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("st_contrato_mercado").ToString.Equals("S") Then
                        lbcontratomercado = True 'contrato mercado, ou seja, contrato com preco negociado
                    Else
                        lbcontratomercado = False 'contrato nao mercado, ou seja, contrato com tabela de adicional de volume para buscar preco 
                    End If
                    lnr_adicional_volume = Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("nr_adicional_volume")) 'adicional de volume do cadastro de pessoa com a informacao se produtor é 24hrs ou 48horas

                    'se não é contrato mercado, tem adicional de volume
                    If lbcontratomercado = False Then
                        'volume tabela contrato - buca volume referencia atual  + volume refrencia anterior + volume grupo relacionamento todas as propriedades do produtor
                        Me.id_pessoa = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_pessoa"))
                        Me.id_propriedade = Convert.ToInt32(dsCalculoProdutor.Tables(0).Rows(li).Item("id_propriedade"))
                        lvalor_volumetabela = getCalculoVolumeLeiteTabela()

                        'obtem volume tabela de contrato (soma das propriedades do produtor) por dia 
                        lvalor_volumetabela_dia = CLng(lvalor_volumetabela / lnr_dias_referencia)
                    End If

                    'fran 07/2017 f- calculo por contrato

                End If

                '====================================
                ' Inicializa Unidade de Produção
                '====================================
                Me.id_estabelecimento = Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_estabelecimento"))  ' 18/11/2008
                Me.id_pessoa = Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_pessoa"))
                Me.id_propriedade = Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_propriedade"))
                Me.id_unid_producao = Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_unid_producao"))
                Me.id_propriedade_matriz = Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_propriedade_matriz")) 'fran 06/2021

                If Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_propriedade")) <> lid_propriedade_anterior Then
                    lid_propriedade_anterior = Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_propriedade"))

                    '====================================
                    ' Inicializa o cálculo
                    '====================================
                    ' Verifica se o pagamento já foi feito pata a Unidade de Producao
                    fichafinanceira.id_calculo_execucao = Me.id_calculo_execucao  ' Projeto Themis
                    If getCalculoStatusPagamentoConsolidado() = "D" Then  'Se já pagou definitivo esta unidade de produção em outro número de execução, não recalcula
                        ' 08/03/2012 - Não gravar dados do pagamento consolidado na ms_calculo_execucao_itens
                        'Me.calculoexecucao.st_calculo_execucao_itens = "3"   '  Seta status 3-Pagamento Definitivo e não calcula
                        'Me.calculoexecucao.id_propriedade = Me.id_propriedade
                        'Me.calculoexecucao.id_unid_producao = Me.id_unid_producao
                        'Me.calculoexecucao.insertCalculoExecucaoItens()
                    Else

                        lst_incentivo_fiscal = getCalculoIncentivoFiscal()
                        lst_transferencia_credito = getCalculoTransferenciaCredito()

                        If IsDBNull(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("st_incentivo_21")) Then
                            lst_incentivo_21 = "N"   ' Assume 'N'
                        Else
                            lst_incentivo_21 = dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("st_incentivo_21")
                        End If

                        If IsDBNull(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("st_incentivo_24")) Then
                            lst_incentivo_24 = "N"   ' Assume 'N'
                        Else
                            lst_incentivo_24 = dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("st_incentivo_24")
                        End If

                        ' 08/03/2012 - Não gravar dados do pagamento consolidado na ms_calculo_execucao_itens
                        'Me.calculoexecucao.st_calculo_execucao_itens = "1"   '  Seta status 1-Iniada como default
                        'Me.calculoexecucao.id_propriedade = Me.id_propriedade
                        'Me.calculoexecucao.id_unid_producao = Me.id_unid_producao
                        'Me.calculoexecucao.insertCalculoExecucaoItens()

                        If lst_incentivo_fiscal = "N" Then  ' Se não tem incentivo fiscal 
                            lpercentual_ICMS = 0
                        Else
                            If lst_uf_produtor = "RJ" Then
                                lst_incentivo_fiscal = "N"      ' RJ não possui incentivo Fiscal
                                lpercentual_ICMS = 0
                            Else

                                Select Case lst_incentivo_fiscal
                                    Case "A"
                                        lpercentual_ICMS = 0.05
                                    Case "B"
                                        lpercentual_ICMS = 0.1
                                    Case "C"
                                        lpercentual_ICMS = 0.2
                                End Select

                            End If
                        End If
                        lvalor_conta = 0
                        lpreco_negociado = 0
                        lpreco_base = 0
                        lpreco_notafiscal = 0
                        lpreco_unitario = 0
                        lvalor_volumeleite = 0
                        lvalor_CCS = 0
                        lvalor_CTM = 0
                        lvalor_proteina = 0
                        lvalor_gordura = 0 ' fran 01/01/2014 inclusao gordura
                        lvalor_total_qualidade = 0
                        lvalor_incentivofiscal = 0
                        lvalor_funrural = 0
                        lvalor_rendbruto = 0
                        lvalor_baseICMS = 0
                        lvalor_ICMS = 0
                        lvalor_totalnota = 0
                        lvalor_totalfunrural = 0
                        lvalor_creditoICMS = 0
                        lvalor_antesPISCONFINS = 0
                        lvalor_custounitario = 0
                        lvalor_PISCOFINS = 0
                        lvalor_totalERP = 0
                        lvalor_custounitarioERP = 0
                        lvalor_subtotal_receber = 0
                        lvalor_frete = 0
                        lvalor_transferencia_ICMS = 0
                        lvalor_incentivo_21 = 0
                        lvalor_incentivo_24 = 0
                        lvalor_incentivo_24_unitario = 0
                        lnr_volume_anual_pago = 0 'fran 11/2022
                        lnr_volume_incentivo25 = 0 'fran 11/2022
                        lnr_volume_incentivo24 = 0 'fran 11/2022
                        lnr_volume_saldo_limite = 0 'fran 11/2022
                        lbapurar24 = False
                        lbapurar25 = False


                        ' Grava Ficha Financeira
                        Me.fichafinanceira.id_propriedade = id_propriedade
                        Me.fichafinanceira.id_unid_producao = id_unid_producao
                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento  ' C - Consolidado

                        Me.fichafinanceira.deleteFichaFinanceira()   ' deleta dados provisório da propriedade/unid. Producao/dt referencia/tipo pagamento

                        ' Adri - 11/07/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês - i
                        'lvalor_volumeleite = getCalculoVolumeLeiteConsolidado()
                        If Me.st_pagamento = "D" Then  'Se Cálculo Definitivo
                            'Me.updateCalculoVolumeLeitePago()  ' Atualiza coluna st_leite_pago_referencia com 'S' (este update não deve ser executado para o consolidado, pois o mesmo deve assumir o que foi considerado de volume no pagamento Mensal, caso contrário pode haver diferença)
                            lvalor_volumeleite = getCalculoVolumeLeiteConsolidadoDefinitivo()  ' Só traz os volumes que participaram no update anterior
                        Else
                            lvalor_volumeleite = getCalculoVolumeLeiteConsolidado()
                        End If

                        lvalor_volumeleite_referenciaanterior = getCalculoVolumeLeiteConsolidadoReferenciaAnterior() ' Obtem o volume de leite de todas as UP's da referência anterior que não entrou para o cálculo, para gerar conta 0011
                        ' Adri - 11/07/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês - f


                        If Me.st_pagamento = "D" Then
                            Me.fichafinanceira.nr_nota_fiscal = ""
                            Me.fichafinanceira.nr_serie = ""
                        End If

                        Me.fichafinanceira.st_pagamento = Me.st_pagamento  ' C - Consolidado
                        Me.fichafinanceira.id_contrato_validade_pessoa = Me.id_contrato_validade
                        Me.fichafinanceira.id_ficha_financeira = fichafinanceira.insertFichaFinanceira()

                        '======================================================================
                        ' Ponto 1 - Apurar Volume de Leite de todas as unidades de produção
                        '=====================================================================
                        lvalor_volumeleite = lvalor_volumeleite + lvalor_volumeleite_referenciaanterior  ' 26/07/2016 - A conta 0010 deve ser gravada com o saldo de volume de leite não pago do mes anterior, para bater com o Extrato e Nota Fiscal

                        ' Grava conta 0010 - Volume Leite
                        Me.fichafinanceira.cd_conta = "0010"
                        Me.fichafinanceira.nr_valor_conta = lvalor_volumeleite
                        Me.fichafinanceira.st_origem_conta = "C"
                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento ' C - Consolidado
                        Me.fichafinanceira.insertFichaFinanceiraItens()

                        ' Adri 11/07/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês - i
                        ' Grava conta 0011 - Volume Leite
                        Me.fichafinanceira.cd_conta = "0011"
                        Me.fichafinanceira.nr_valor_conta = lvalor_volumeleite_referenciaanterior
                        Me.fichafinanceira.st_origem_conta = "C"
                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                        Me.fichafinanceira.insertFichaFinanceiraItens()

                        'lvalor_volumeleite = lvalor_volumeleite + lvalor_volumeleite_referenciaanterior  ' Para pagar na referência o que não foi pago no mês anterior
                        ' Adri 11/07/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês - f

                        'fran 07/2017 i
                        'volume total todas as propriedades do produtor + do grupo de relacionamento da referencia atual e da referencia anterior que nao foi pago
                        Me.fichafinanceira.cd_conta = "0014"
                        Me.fichafinanceira.nr_valor_conta = lvalor_volumetabela
                        Me.fichafinanceira.st_origem_conta = "C"
                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                        Me.fichafinanceira.insertFichaFinanceiraItens()

                        'volume por dia - conta 0014 dividido pelo nr de dias da referencia de calculo
                        Me.fichafinanceira.cd_conta = "0015"
                        Me.fichafinanceira.nr_valor_conta = lvalor_volumetabela_dia
                        Me.fichafinanceira.st_origem_conta = "C"
                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                        Me.fichafinanceira.insertFichaFinanceiraItens()
                        'fran 07/2017 f

                        'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4
                        'FRAN 11/2022
                        '=====================================================
                        'APURAR VOLUME LEITE INCENTIVO SE TIVER ICENTIVO
                        If lvalor_volumeleite > 0 Then
                            If lst_incentivo_fiscal <> "N" Then 'se  tem incentivo 2.5
                                'se tem incentivo deve verificar limite incentivo da propriedade
                                Me.dt_referencia_start = String.Concat("01/01/", Right(Me.dt_referencia, 4))
                                Me.dt_referencia_end = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(Me.dt_referencia))
                                'busca o volume pago ate o mes anterior e retira o valor da conta 11 (porque este volume deve entrar no mes atual)
                                lnr_volume_anual_pago = Math.Truncate(getCalculoVolumeLeiteConsolidado() - lvalor_volumeleite_referenciaanterior)

                                lnr_volume_saldo_limite = lconfiglimiteincentivo - lnr_volume_anual_pago

                                'se o valor anual da propriedade já for maior ou igual ao limite de incentivo
                                If lnr_volume_anual_pago >= lconfiglimiteincentivo Then
                                    'assume que o volume da referencia é todo 2,4
                                    lnr_volume_incentivo24 = lvalor_volumeleite
                                    lnr_volume_incentivo25 = 0
                                    lbapurar24 = True 'forca apuração 2.4
                                    lbapurar25 = False
                                Else
                                    If lvalor_volumeleite <= lnr_volume_saldo_limite Then
                                        lnr_volume_incentivo25 = lvalor_volumeleite
                                        lnr_volume_incentivo24 = 0
                                        lbapurar24 = False
                                        lbapurar25 = True
                                    Else
                                        If lst_categoria = "J" Then
                                            lnr_volume_incentivo25 = 0
                                            lnr_volume_incentivo24 = lvalor_volumeleite
                                            lbapurar24 = True 'forca apuração 2.4
                                            lbapurar25 = False
                                        Else
                                            lnr_volume_incentivo25 = lnr_volume_saldo_limite
                                            lnr_volume_incentivo24 = lvalor_volumeleite - lnr_volume_saldo_limite
                                            lbapurar24 = True 'forca apuração 2.4
                                            lbapurar25 = True
                                        End If
                                    End If
                                End If

                                'retorna variaveis
                                Me.dt_referencia_start = Me.dt_referencia
                                Me.dt_referencia_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))

                                ' Grava conta 0016 - Volume Leite Incentivo 2,5%
                                Me.fichafinanceira.cd_conta = "0016"
                                Me.fichafinanceira.nr_valor_conta = lnr_volume_incentivo25
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' Grava conta 0017 - Volume Leite Incentivo 2,4%
                                Me.fichafinanceira.cd_conta = "0017"
                                Me.fichafinanceira.nr_valor_conta = lnr_volume_incentivo24
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                ' Grava conta 0018 - Volume Leite Pago Anual M-1
                                Me.fichafinanceira.cd_conta = "0018"
                                Me.fichafinanceira.nr_valor_conta = lnr_volume_anual_pago
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                            End If
                        End If

                        ''FRAN 11/2022 f
                        ''=====================================================

                        If lvalor_volumeleite > 0 Then  ' Não calcular 

                            '==========================================================================================
                            ' Ponto 1 - Apurar lançamentos venciomentos/descontos (só para a 1.a Unidade de Produção)
                            '==========================================================================================
                            'If Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_propriedade")) <> lid_propriedade_anterior Then
                            '    lid_propriedade_anterior = Convert.ToInt32(dsCalculoProdutorConsolidado.Tables(0).Rows(li).Item("id_propriedade"))
                            Me.calculoApurarLancamentos("T")
                            Me.calculoApurarContasParceladas()
                            lvalor_adiantamento = Me.getCalculoValorAdiantamento()  'Busca diretamente da tabela ms_adiantamento se aprovado

                            ' 11/07/2016 - adri chamado 2452 - Gerar Volume de Descarte de Antibiótivo (Só para a 1.a Unidade de Produção)
                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.id_natureza = 3  ' Natureza 3-Outros
                            Me.fichafinanceira.cd_conta = "0114"    ' Conta "0114" gerada no processo de romaneio
                            Me.fichafinanceira.st_qtd_valor = "Q"  ' Contas lançadas em Quantidade (volume de leite descartado) 
                            lvalor_volumeleite_antibiotico = Me.fichafinanceira.getFichaFinanceiraValorConta()  ' Somatório das contas 0114 com a litragem descartada por antibiótico,  no mes de referencia
                            Me.fichafinanceira.st_qtd_valor = ""
                            Me.fichafinanceira.id_natureza = 0

                            '================================================================================================================================================================================
                            ' Ponto 2 - Apurar Preço Médio 0041- Preço Nota Fiscal, conta 0030-Preço Base e conta 0150-Total da Qualidade (Média ponderada utilizando-se a conta 0010 como base de ponderação)
                            '=================================================================================================================================================================================

                            lpreco_notafiscal = 0
                            fichafinanceira.cd_conta = "0041"  ' Apura média ponderada do Preço da Nota Fiscal
                            Dim dsCalculoPrecoMedio As DataSet = fichafinanceira.getCalculoValorContaPonderado()  ' Traz todas as contas que interferem no Preço Médio (0010, 0030, 0041, 0080, 0081, 0090, 0091, 0100, 0101) das UP´s da propriedade
                            For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                                lpreco_notafiscal = lpreco_notafiscal + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                            Next
                            lpreco_notafiscal = lpreco_notafiscal / lvalor_volumeleite  ' calcula média poderada com base no volume de cada UP

                            'lvalor_volumeleitemedio = lvalor_volumeleite / li_precomedio  ' Divide total de volume total pela qtd de up´s

                            'fran 07/2017 i 
                            'se contrato do proddutor nao é mercado
                            If lbcontratomercado = False Then
                                'Indicador Mercado
                                lvalor_indicador = 0
                                fichafinanceira.cd_conta = "0025"  ' Apura média ponderada do Indicador Mercado
                                dsCalculoPrecoMedio = fichafinanceira.getCalculoValorContaPonderado()  ' Traz todas as contas que interferem no Preço Médio (0010, 0030, 0041, 0080, 0081, 0090, 0091, 0100, 0101) das UP´s da propriedade
                                For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                                    lvalor_indicador = lvalor_indicador + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                                Next
                                lvalor_indicador = lvalor_indicador / lvalor_volumeleite  ' calcula média poderada com base no volume de cada UP

                                ' Grava conta 0025 - indicador
                                Me.fichafinanceira.cd_conta = "0025"
                                Me.fichafinanceira.nr_valor_conta = lvalor_indicador
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'Antecipação 24hrs
                                lvalor_adicional24hrs = 0
                                fichafinanceira.cd_conta = "0026"  ' Apura média ponderada do Indicador Mercado
                                dsCalculoPrecoMedio = fichafinanceira.getCalculoValorContaPonderado()  ' Traz todas as contas que interferem no Preço Médio (0010, 0030, 0041, 0080, 0081, 0090, 0091, 0100, 0101) das UP´s da propriedade
                                For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                                    lvalor_adicional24hrs = lvalor_adicional24hrs + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                                Next
                                lvalor_adicional24hrs = lvalor_adicional24hrs / lvalor_volumeleite  ' calcula média poderada com base no volume de cada UP

                                ' Grava conta 0026 - adicional 24hrs
                                Me.fichafinanceira.cd_conta = "0026"
                                Me.fichafinanceira.nr_valor_conta = lvalor_adicional24hrs
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'Antecipação 48hrs
                                lvalor_adicional48hrs = 0
                                fichafinanceira.cd_conta = "0027"  ' Apura média ponderada do Indicador Mercado
                                dsCalculoPrecoMedio = fichafinanceira.getCalculoValorContaPonderado()  ' Traz todas as contas que interferem no Preço Médio (0010, 0030, 0041, 0080, 0081, 0090, 0091, 0100, 0101) das UP´s da propriedade
                                For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                                    lvalor_adicional48hrs = lvalor_adicional48hrs + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                                Next
                                lvalor_adicional48hrs = lvalor_adicional48hrs / lvalor_volumeleite  ' calcula média poderada com base no volume de cada UP

                                ' Grava conta 0027 - adicional 24hrs
                                Me.fichafinanceira.cd_conta = "0027"
                                Me.fichafinanceira.nr_valor_conta = lvalor_adicional48hrs
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                            End If
                            'fran 07/2017 f


                            lpreco_base = 0
                            fichafinanceira.cd_conta = "0030"  ' Apura média ponderada do Preço Base
                            dsCalculoPrecoMedio = fichafinanceira.getCalculoValorContaPonderado()  ' Traz todas as contas que interferem no Preço Médio (0010, 0030, 0041, 0080, 0081, 0090, 0091, 0100, 0101) das UP´s da propriedade
                            For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                                lpreco_base = lpreco_base + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                            Next
                            lpreco_base = lpreco_base / lvalor_volumeleite  ' calcula média poderada com base no volume de cada UP

                            lpreco_negociado = lpreco_base 'fran 07/2017 i

                            'fran 07/2016 i
                            ' Grava conta 0030 - Preço Negociado
                            Me.fichafinanceira.cd_conta = "0030"
                            Me.fichafinanceira.nr_valor_conta = lpreco_base
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()
                            'fran 07/2016 f


                            ' 11/07/2016 - adri chamado 2452 - Gerar Valor de Descarte de Antibiótivo (conta de Reposição em Valor) - i
                            ' Grava conta 0104 - Volume Rejeitado - Desconto (conta de Reposição no valor Total)
                            If lvalor_volumeleite_antibiotico > 0 Then ' Se tem volume de descarte de antibiótico para ser descontado como Reposição
                                Me.fichafinanceira.cd_conta = "0104"
                                'fran 1/08/2016 i p deve subtrir antibiotico da composiçao de preço
                                'Me.fichafinanceira.nr_valor_conta = lvalor_volumeleite_antibiotico * lpreco_base  ' utiliza a média ponderada do preço negociado
                                Me.fichafinanceira.nr_valor_conta = -(lvalor_volumeleite_antibiotico * lpreco_base)  ' utiliza a média ponderada do preço negociado
                                'fran 1/08/2016 f
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If
                            ' 11/07/2016 - adri chamado 2452 - Gerar Valor de Descarte de Antibiótivo (conta de Reposição em Valor) - i

                            '===============================================================================================================
                            ' 11/07/2016 - chamado 2448 - Cálculo Geométrico - Média ponderada dos Teores das Qualidades e reapuração dos bônus e desconto - i
                            'lvalor_qualidade = 0  ' somatória unitária da qualidade
                            'fichafinanceira.cd_conta = "0150"  ' Apura média ponderada do Total da Qualidade
                            'dsCalculoPrecoMedio = fichafinanceira.getCalculoValorContaPonderado()  ' Traz todas as contas que interferem no Preço Médio (0010, 0030, 0041, 0080, 0081, 0090, 0091, 0100, 0101) das UP´s da propriedade
                            'For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                            '    lvalor_qualidade = lvalor_qualidade + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                            'Next
                            'lvalor_qualidade = lvalor_qualidade / lvalor_volumeleite  ' calcula média poderada com base no volume de cada UP

                            lvalor_qualidade = 0  ' valor para compor o preço
                            lmedia_analise = 0  ' teor ponderado Proteína
                            fichafinanceira.cd_conta = "0082"  ' Apura média ponderada do Teor de Proteína
                            dsCalculoPrecoMedio = fichafinanceira.getCalculoValorContaPonderado()  ' Traz todas as contas que interferem no Preço Médio (0010, 0030, 0041, 0080, 0081, 0090, 0091, 0100, 0101) das UP´s da propriedade
                            For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                                lmedia_analise = lmedia_analise + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                            Next
                            lmedia_analise = lmedia_analise / lvalor_volumeleite  ' calcula média poderada do teor da análise com base no volume de cad

                            Me.cd_analise_esalq = 11    ' Apura Proteína
                            Me.id_categoria = 3 ' Categora 3-Proteína
                            lvalor_proteina = Me.apurarIndiceQualidadeConsolidado(lmedia_analise)
                            lvalor_qualidade = lvalor_qualidade + lvalor_proteina  ' bonus ou desconto para compor preco

                            'fran 15/07/2016 i calculo geometrico 
                            'APURA CONTA PROTEINA E TEOR
                            If lvalor_proteina >= 0 Then
                                Me.fichafinanceira.cd_conta = "0080"  ' Grava conta 0080 - Bônus Proteína
                            Else
                                Me.fichafinanceira.cd_conta = "0081"  ' Grava conta 0081 - Desconto Proteína
                            End If
                            Me.fichafinanceira.nr_valor_conta = lvalor_proteina
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            'Guarda media analise proteina
                            Me.fichafinanceira.cd_conta = "0082"  ' Grava conta 0082 - Teor Proteína
                            Me.fichafinanceira.nr_valor_conta = Round(lmedia_analise, 4)
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()
                            'fran 15/07/2016 f calculo geometrico

                            lmedia_analise = 0  ' teor ponderado CTM
                            fichafinanceira.cd_conta = "0092"  ' Apura média ponderada do Teor de CTM
                            dsCalculoPrecoMedio = fichafinanceira.getCalculoValorContaPonderado()  ' Traz todas as contas que interferem no Preço Médio (0010, 0030, 0041, 0080, 0081, 0090, 0091, 0100, 0101) das UP´s da propriedade
                            For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                                lmedia_analise = lmedia_analise + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                            Next
                            lmedia_analise = lmedia_analise / lvalor_volumeleite  ' calcula média poderada do teor da análise com base no volume de cada UP
                            Me.cd_analise_esalq = 52    ' Apura CTM
                            Me.id_categoria = 2 ' Categora 2-CTM
                            lvalor_CTM = Me.apurarIndiceQualidadeConsolidado(lmedia_analise)
                            lvalor_qualidade = lvalor_qualidade + lvalor_CTM  ' bonus ou desconto para compor preco

                            'fran 15/07/2016 i calculo geometrico
                            If lvalor_CTM >= 0 Then
                                Me.fichafinanceira.cd_conta = "0090"  ' Grava conta 0090 - Bônus CTM
                            Else
                                Me.fichafinanceira.cd_conta = "0091"  ' Grava conta 0091 - Desconto CTM
                            End If
                            Me.fichafinanceira.nr_valor_conta = lvalor_CTM
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            'Guarda media analise CTM
                            Me.fichafinanceira.cd_conta = "0092"  ' Grava conta 0092 - Teor CTM
                            Me.fichafinanceira.nr_valor_conta = Round(lmedia_analise, 0)
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()
                            'fran 15/07/2016 f calculo geometrico

                            'fran 13/09/2016 i calculo geometrico mensla poupanca
                            lmedia_analise = 0  ' teor ponderado geometrico mensal
                            fichafinanceira.cd_conta = "0093"  ' Apura média ponderada mensal geometrica do Teor de CTM
                            dsCalculoPrecoMedio = fichafinanceira.getCalculoValorContaPonderado()
                            For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                                lmedia_analise = lmedia_analise + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                            Next
                            lmedia_analise = lmedia_analise / lvalor_volumeleite  ' calcula média poderada do teor da análise com base no volume de cada UP
                            'Guarda media analise CTM
                            Me.fichafinanceira.cd_conta = "0093"  ' Grava conta 0092 - Teor CTM
                            Me.fichafinanceira.nr_valor_conta = Round(lmedia_analise, 0)
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()
                            'fran 13/09/2016 f calculo geometrico mensla poupanca

                            lmedia_analise = 0  ' teor ponderado CCS
                            fichafinanceira.cd_conta = "0105"  ' Apura média ponderada do Teor de CCS
                            dsCalculoPrecoMedio = fichafinanceira.getCalculoValorContaPonderado()  ' Traz todas as contas que interferem no Preço Médio (0010, 0030, 0041, 0080, 0081, 0090, 0091, 0100, 0101) das UP´s da propriedade
                            For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                                lmedia_analise = lmedia_analise + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                            Next
                            lmedia_analise = lmedia_analise / lvalor_volumeleite  ' calcula média poderada do teor da análise com base no volume de cada UP
                            Me.cd_analise_esalq = 53    ' Apura CCS
                            Me.id_categoria = 1 ' Categora 1-CCS
                            lvalor_CCS = Me.apurarIndiceQualidadeConsolidado(lmedia_analise)
                            lvalor_qualidade = lvalor_qualidade + lvalor_CCS  ' bonus ou desconto para compor preco

                            'fran 15/07/2016 i calculo geometrico
                            If lvalor_CCS >= 0 Then
                                Me.fichafinanceira.cd_conta = "0100"  ' Grava conta 0100 - Bônus CCS
                            Else
                                Me.fichafinanceira.cd_conta = "0101"  ' Grava conta 0101 - Desconto CCS
                            End If
                            Me.fichafinanceira.nr_valor_conta = lvalor_CCS
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            'Guarda media analise CCS
                            Me.fichafinanceira.cd_conta = "0105"  ' Grava conta 0105 - Teor CCS
                            Me.fichafinanceira.nr_valor_conta = Round(lmedia_analise, 0)
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()
                            'fran 15/07/2016 f calculo geometrico

                            'fran 13/09/2016 i calculo geometrico mensla poupanca
                            lmedia_analise = 0  ' teor ponderado geometrico mensal
                            fichafinanceira.cd_conta = "0106"  ' Apura média ponderada mensal geometrica do Teor de CCS
                            dsCalculoPrecoMedio = fichafinanceira.getCalculoValorContaPonderado()
                            For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                                lmedia_analise = lmedia_analise + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                            Next
                            lmedia_analise = lmedia_analise / lvalor_volumeleite  ' calcula média poderada do teor da análise com base no volume de cada UP
                            'Guarda media analise CSS
                            Me.fichafinanceira.cd_conta = "0106"  ' Grava conta 0106 - Teor CCS
                            Me.fichafinanceira.nr_valor_conta = Round(lmedia_analise, 0)
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()
                            'fran 13/09/2016 f calculo geometrico mensla poupanca


                            lmedia_analise = 0  ' teor ponderado MG
                            fichafinanceira.cd_conta = "0152"  ' Apura média ponderada do Teor de MG
                            dsCalculoPrecoMedio = fichafinanceira.getCalculoValorContaPonderado()  ' Traz todas as contas que interferem no Preço Médio (0010, 0030, 0041, 0080, 0081, 0090, 0091, 0100, 0101) das UP´s da propriedade
                            For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                                lmedia_analise = lmedia_analise + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                            Next
                            lmedia_analise = lmedia_analise / lvalor_volumeleite  ' calcula média poderada do teor da análise com base no volume de cada UP
                            Me.cd_analise_esalq = 8    ' Apura CCS
                            Me.id_categoria = 4 ' Categora 1-CCS
                            lvalor_gordura = Me.apurarIndiceQualidadeConsolidado(lmedia_analise)
                            lvalor_qualidade = lvalor_qualidade + lvalor_gordura  ' bonus ou desconto para compor preco

                            'fran 15/07/2016 i calculo geometrico
                            If lvalor_gordura >= 0 Then
                                Me.fichafinanceira.cd_conta = "0110"  ' Grava conta 0110 - Bônus gordura
                            Else
                                Me.fichafinanceira.cd_conta = "0111"  ' Grava conta 0111 - Desconto gordura
                            End If
                            Me.fichafinanceira.nr_valor_conta = lvalor_gordura
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.cd_conta = "0152"  ' teor - Bônus CCS
                            Me.fichafinanceira.nr_valor_conta = Round(lmedia_analise, 4)
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.cd_conta = "0150"  ' Grava conta 0150 - Total Qualidade
                            Me.fichafinanceira.nr_valor_conta = lvalor_qualidade
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()


                            Me.fichafinanceira.cd_conta = "0151"  ' Grava conta 0151 - Total Qualidade x Volume
                            Me.fichafinanceira.nr_valor_conta = lvalor_qualidade * lvalor_volumeleite
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            'fran 15/07/2016 f calculo geometrico


                            ' 11/07/2016 - chamado 2448 - Cálculo Geométrico - Média ponderada dos Teores das Qualidades e reapuração dos bônus e desconto - f
                            '===============================================================================================================

                            '==========================================================================================
                            ' Ponto 3 - Busca contas que participam dos cálculos de impostos, lançadas por Propriedade
                            '==========================================================================================
                            'fran 08/2022 - na consolidada traz as contas calculadas de custo finaneiro para atuar na composição de preco
                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.st_tipo_pagamento = "M"
                            Me.fichafinanceira.id_natureza = 0
                            Me.fichafinanceira.cd_conta = "8999"    ' conta custo financeiro calculada
                            Me.fichafinanceira.st_qtd_valor = ""

                            'busca de todas as de todas as ups
                            lunidproducaoconsolidada = Me.fichafinanceira.id_unid_producao
                            Me.fichafinanceira.id_unid_producao = 0

                            Me.fichafinanceira.cd_conta = "8999"  ' Grava conta - Incentivo Fiscal
                            Me.fichafinanceira.nr_valor_conta = Me.fichafinanceira.getFichaFinanceiraValorConta() 'somatorio da conta 8999 apurada para cada up
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()
                            'fran 8/2022 f

                            'Busca contas que compõem o Preço da Nota, ou seja, que tem o mesmo comportamento da conta de Reposição - Pode ser lançada com Positiva ou Negativa) - i
                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.st_tipo_pagamento = "M"
                            Me.fichafinanceira.id_natureza = 5  ' Natureza 5-Composição de Preço
                            Me.fichafinanceira.cd_conta = ""    ' Limpa a conta 
                            Me.fichafinanceira.st_qtd_valor = "V"  ' 13/01/2010 - Chamado 581 (Busca todas as contas lançadas em valor Unitário)
                            lvalor_composicao_preco_unitario = Me.fichafinanceira.getFichaFinanceiraValorConta()  ' Somatório dos descontos no mes de referencia
                            Me.fichafinanceira.st_qtd_valor = ""  ' 13/01/2010 - Chamado 581 Limpa o atributo

                            ' Adicional Distância - i
                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.st_tipo_pagamento = "M"
                            Me.fichafinanceira.id_natureza = 5  ' Natureza 5-Composição de Preço
                            Me.fichafinanceira.cd_conta = ""    ' Limpa a conta 
                            Me.fichafinanceira.st_qtd_valor = "T"  ' 13/01/2010 - Chamado 581 (Busca todas as contas lançadas em valor Total)


                            lvalor_composicao_preco_total = Me.fichafinanceira.getFichaFinanceiraValorConta()  ' Somatório dos descontos no mes de referencia
                            Me.fichafinanceira.st_qtd_valor = ""  ' 13/01/2010 - Chamado 581 Limpa o atributo
                            Me.fichafinanceira.id_natureza = 0

                            ' ????????? 07/03/2012 - 
                            'lvalor_composicao_preco = lvalor_composicao_preco_unitario + Round((lvalor_composicao_preco_total / lvalor_volumeleite), 4)
                            'lvalor_composicao_preco = lvalor_composicao_preco_unitario + Round((lvalor_composicao_preco_total / lvalor_volumeleitemedio), 4)  ' Como consolidou a conta para todas as UP´s, calcula a média simples do volume (ficou muito alto o valor total da nota)
                            lvalor_composicao_preco = lvalor_composicao_preco_unitario + (lvalor_composicao_preco_total / lvalor_volumeleite)  ' adri 14/09/2015 - chamado 2377 - Erro de arredondamento na divisão do ADC lançado em total e quando divide pelo volume perde muito se arredonda pra 4 casas


                            'fran 08/2022 i
                            Me.fichafinanceira.cd_conta = "0250"  ' Grava conta - composicao preco
                            Me.fichafinanceira.nr_valor_conta = lvalor_composicao_preco
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.id_unid_producao = lunidproducaoconsolidada 'fran 08/2022 retorna a variavel
                            'fran 08/2022 f

                            'Complementa o preço base com Redutase e Reposicao
                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.cd_conta = "0102"   ' Conta Redutase
                            Me.fichafinanceira.st_tipo_pagamento = "M"
                            Me.fichafinanceira.id_natureza = 0
                            lvalor_redutase = Me.fichafinanceira.getFichaFinanceiraValorConta()

                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.cd_conta = "3000"   ' Conta Reposição
                            Me.fichafinanceira.st_tipo_pagamento = "M"
                            Me.fichafinanceira.id_natureza = 0
                            lvalor_reposicao = Me.fichafinanceira.getFichaFinanceiraValorConta()

                            'Fran 01/06/2012 chamado 1562 Diferença de Valor na conta 1400 i 
                            'Estava faltando a qualidade na composição do preço base
                            'lpreco_base = lpreco_base + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco
                            lpreco_base = lpreco_base + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco + lvalor_qualidade
                            'Fran 01/06/2012 chamado 1562 Diferença de Valor na conta 1400 f 

                            'fran 11/2022 i
                            Me.fichafinanceira.cd_conta = "0050"  ' Grava conta - Preço Bruto
                            Me.fichafinanceira.nr_valor_conta = lpreco_base
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            'fran 11/2022 f

                            '=============================================================================
                            ' Ponto 4 - Cálculo dos Impostos para Nota Fiscal consolidada por IE
                            '=============================================================================
                            If lst_transferencia_credito = "S" Then
                                'lpreco_notafiscal = Round((Round(lpreco_negociado / 0.977, 4) + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) / 0.88, 4)  ' Retirado porque já calculou a média poderada 

                                'fran 31/01/2019 i FUNRURAL 2019 LEI 13606
                                ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018
                                'fran 23/04/2017 i retorno do funrural para referencia Abril/2017
                                ''fran 28/09/2016 i 'funrural nao existe mais deve apenas calcular sest/senat (2.3 antes 2.1 para funrural e 0.2 para sestsenat)
                                ''lvalor_funrural = lpreco_notafiscal * 0.023  ' Calculo FunRural
                                'lvalor_funrural = lpreco_notafiscal * 0.002  ' Calculo FunRural
                                ''fran 28/09/2016 f
                                ''lvalor_funrural = lpreco_notafiscal * 0.023  ' Calculo FunRural
                                'fran 23/04/2017 f retorno do funrural para referencia Abril/2017
                                'lvalor_funrural = lpreco_notafiscal * 0.015  ' Calculo FunRural
                                ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018

                                'Se o produtor optou por recolher FUNRURAL
                                If lst_funrural = "P" Then
                                    'lvalor_funrural = lpreco_notafiscal * 0.003  ' Calculo FunRural - desconta apenas SENAR/RAT
                                    lvalor_funrural = lpreco_notafiscal * 0.002 ' Calculo FunRural - desconta apenas SENAR/RAT
                                Else
                                    'SE A DANONE recolhe o FUNRURAL de acordo com cadastro de fornecedor
                                    lvalor_funrural = lpreco_notafiscal * 0.015  ' Calculo FunRural -desconta FUNRURAL + SENAR/RAT
                                End If
                                'fran 31/01/2019 f FUNRURAL 2019 LEI 13606

                            Else
                                'If lst_categoria = "J" Then  'Se pessoa jurídica
                                'lpreco_notafiscal = Round(lpreco_negociado / 0.977, 4)  ' Retirado porque já calculou a média poderada 
                                '    lvalor_funrural = 0
                                'Else
                                'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i
                                If lst_incentivo_fiscal <> "N" AndAlso lbapurar25 = True Then  ' Se tem Incentivo Fiscal, Permaneu a mesma coisa da versão anterior
                                    'If lst_incentivo_fiscal <> "N" Then  ' Se tem Incentivo Fiscal, Permaneu a mesma coisa da versão anterior
                                    'lvalor_incentivofiscal = lpreco_base * 0.025  ' Calcula 2,5% de Incentivo Fiscal

                                    'Fran 01/06/2012 chamado 1562 Diferença de Valor na conta 1400 i 
                                    'O valor incentivo ponderado fica mais proximo do real (diferença nas inumeras casas decimais)
                                    'lvalor_incentivofiscal = Round(lpreco_base * 0.025, 4)  ' Adri Projeto Themis 28/05/2012 - chamado 1553 - Calcula 2,5% de Incentivo Fiscal com arredondamento devido ao SAP
                                    'fran 11/2022 i
                                    'lvalor_incentivofiscal = 0
                                    'fichafinanceira.cd_conta = "0300"  ' Apura média ponderada do Incentivo
                                    'dsCalculoPrecoMedio = fichafinanceira.getCalculoValorContaPonderado()  ' 
                                    'For li_precomedio = 0 To dsCalculoPrecoMedio.Tables(0).Rows.Count - 1
                                    '    lvalor_incentivofiscal = lvalor_incentivofiscal + Convert.ToDecimal(dsCalculoPrecoMedio.Tables(0).Rows(li_precomedio).Item("nr_valor_ponderado"))
                                    'Next
                                    'lvalor_incentivofiscal = lvalor_incentivofiscal / lvalor_volumeleite  ' calcula média poderada com base no volume de cada UP
                                    'fran(03/ 2023I)
                                    'lvalor_incentivofiscal = Round(lpreco_base * 0.025, 4)
                                    lvalor_incentivofiscal = lpreco_base * 0.025

                                    'fran 11/2022 f
                                    'Fran 01/06/2012 chamado 1562 Diferença de Valor na conta 1400 f 

                                    'fran 31/01/2019 i FUNRURAL 2019 LEI 13606

                                    ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018
                                    'fran 23/04/2017 i retorno do funrural para referencia Abril/2017
                                    ''fran 28/09/2016 i 'funrural nao existe mais deve apenas calcular sest/senat (2.3 antes 2.1 para funrural e 0.2 para sestsenat)
                                    ''lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.023, 4)  ' Calculo FunRural
                                    'lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.002, 4)  ' Calculo FunRural
                                    ''fran 28/09/2016 f
                                    ''lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.023, 4)  ' Calculo FunRural
                                    'fran 23/04/2017 f retorno do funrural para referencia Abril/2017
                                    'lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.015, 4)  ' Calculo FunRural
                                    ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018

                                    If lst_categoria = "J" Then
                                        lvalor_funrural = 0
                                    Else
                                        'Se o produtor optou por recolher FUNRURAL
                                        If lst_funrural = "P" Then
                                            'lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.003, 4)  ' Calculo FunRural - desconta apenas SENAR/RAT
                                            lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.002, 4)  ' nova legislacao
                                        Else
                                            'SE A DANONE recolhe o FUNRURAL de acordo com cadastro de fornecedor
                                            lvalor_funrural = Round((lpreco_base + lvalor_incentivofiscal) * 0.015, 4)  ' Calculo FunRural -desconta FUNRURAL + SENAR/RAT
                                        End If
                                        'fran 01/2019 f FUNRURAL 2019 LEI 13606
                                    End If

                                    'lpreco_notafiscal = (lpreco_negociado - lvalor_incentivofiscal + lvalor_funrural) ' Retirado porque já calculou a média poderada 

                                    Me.fichafinanceira.cd_conta = "0300"  ' Grava conta - Incentivo Fiscal
                                    Me.fichafinanceira.nr_valor_conta = lvalor_incentivofiscal
                                    Me.fichafinanceira.nr_valor_12 = lvalor_incentivofiscal

                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                    Me.fichafinanceira.nr_valor_12 = 0

                                    'fran 11/2022 i
                                    lnrvaloraux = 0
                                    Me.fichafinanceira.cd_conta = "2065"  ' Grava conta - Incentivo Fiscal
                                    If lnr_volume_incentivo25 > 0 Then
                                        Me.fichafinanceira.nr_valor_conta = Round(lvalor_incentivofiscal * lnr_volume_incentivo25, 2)
                                        lnrvaloraux = lvalor_incentivofiscal * lnr_volume_incentivo25
                                    Else
                                        Me.fichafinanceira.nr_valor_conta = Round(lvalor_incentivofiscal * lvalor_volumeleite, 2)
                                        lnrvaloraux = lvalor_incentivofiscal * lvalor_volumeleite
                                    End If

                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()

                                    Me.fichafinanceira.cd_conta = "2070"  ' Grava conta - 2070 Incentivo 2.5 liquido VALOR INCENTIVO - PISCOFINS 4,625%
                                    Me.fichafinanceira.nr_valor_conta = Round(lnrvaloraux * (1 - (0.04625)), 2)
                                    Me.fichafinanceira.nr_valor_12 = Round(lnrvaloraux * (1 - (0.04625)), 12)
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()

                                    Me.fichafinanceira.cd_conta = "0055"  ' Grava conta - 0055 preço liquido 2.5 preço bruto - piscofins 4,625% sem desconto ICMS sobre reço
                                    Me.fichafinanceira.nr_valor_conta = Round(lpreco_base - (lpreco_base * 0.12) - (lpreco_base * 0.04625), 4)
                                    Me.fichafinanceira.nr_valor_12 = Round(lpreco_base - (lpreco_base * 0.12) - (lpreco_base * 0.04625), 12)
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                    'fran 11/2022 f

                                    Me.fichafinanceira.nr_valor_12 = 0


                                Else
                                    'lpreco_notafiscal = Round(lpreco_negociado / 0.977, 4)  ' Retirado porque já calculou a média poderada 

                                    'fran 31/01/2019 i FUNRURAL 2019 LEI 13606

                                    ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018
                                    'fran 23/04/2017 i retorno do funrural para referencia Abril/2017
                                    ''fran 28/09/2016 i 'funrural nao existe mais deve apenas calcular sest/senat (2.3 antes 2.1 para funrural e 0.2 para sestsenat)
                                    ''lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.023, 4)  ' 19/02/2009 Rls16
                                    'lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.002, 4)  ' 19/02/2009 Rls16
                                    ''fran 28/09/2016 f
                                    ''lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.023, 4)  ' 19/02/2009 Rls16
                                    'fran 23/04/2017 f retorno do funrural para referencia Abril/2017
                                    'lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.015, 4)  ' 19/02/2009 Rls16
                                    ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018
                                    'fran 31/01/2019 f FUNRURAL 2019 LEI 13606
                                    If lst_categoria = "J" Then
                                        lvalor_funrural = 0
                                    Else

                                        'Se o produtor optou por recolher FUNRURAL
                                        If lst_funrural = "P" Then
                                            'lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.003, 4) ' Calculo FunRural - desconta apenas SENAR/RAT
                                            lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.002, 4) ' Calculo FunRural - desconta apenas SENAR/RAT
                                        Else
                                            'SE A DANONE recolhe o FUNRURAL de acordo com cadastro de fornecedor
                                            lvalor_funrural = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.015, 4) ' Calculo FunRural - desconta FUNRURAL +  SENAR/RAT
                                        End If
                                        'fran 31/01/2019 f FUNRURAL 2019 LEI 13606
                                    End If

                                End If
                                'End If

                            End If

                            Me.fichafinanceira.cd_conta = "0041"  ' Grava conta - Preco Nota Fiscal Média Ponderada
                            Me.fichafinanceira.nr_valor_conta = lpreco_notafiscal
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "0800"  ' Grava conta - Preco Funrural
                                Me.fichafinanceira.nr_valor_conta = lvalor_funrural
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'fran 31/01/2019 i aliquota funrural
                                If lvalor_funrural <> 0 Then
                                    Me.fichafinanceira.cd_conta = "0801"  ' Grava conta - ALIQUOTA Funrural
                                    Me.fichafinanceira.nr_valor_conta = lvalor_aliquota_funrural
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                End If

                            'fran 31/01/2019 f aliquota funrural

                                'fran 18/07/2016 i 
                                '======================================
                                ' Ponto 5 - Apurar Preço Unitário 
                                '======================================
                                If lst_transferencia_credito = "S" Then
                                    lpreco_unitario = Round(lpreco_notafiscal - lvalor_funrural, 4)
                                Else
                                    lpreco_unitario = Round(lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_incentivofiscal - lvalor_funrural, 4)
                                End If

                                Me.fichafinanceira.cd_conta = "0040"  ' Grava conta - Preco Unitário
                                Me.fichafinanceira.nr_valor_conta = lpreco_unitario
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                '======================================================
                                ' Ponto 6 - Apurar Rendimento Bruto da Unidade Produção
                                '======================================================
                                lvalor_rendbruto = Round(lvalor_volumeleite * lpreco_unitario, 2)

                                Me.fichafinanceira.cd_conta = "0200"  ' Grava conta - Preco Unitário
                                Me.fichafinanceira.nr_valor_conta = lvalor_rendbruto
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                'fran 18/07/2016 f

                                '======================================================
                                ' Ponto 7 - Apurar dados da Nota Fiscal
                                '======================================================
                                If lst_incentivo_21 = "S" Then
                                    'lvalor_incentivo_21 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.021, 4) * lvalor_volumeleite, 2)  ' 19/02/2009 Rls16 ' fran 01/01/2014 inclusao gordura
                                    lvalor_incentivo_21 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.021, 4) * lvalor_volumeleite, 2)  ' fran 01/01/2014 inclusao gordura

                                    Me.fichafinanceira.cd_conta = "2050"  ' Grava conta - Incentivo 2.1%
                                    Me.fichafinanceira.nr_valor_conta = lvalor_incentivo_21
                                    Me.fichafinanceira.st_origem_conta = "C"
                                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                    Me.fichafinanceira.insertFichaFinanceiraItens()
                                End If

                            'fran 11/2022 i
                            '                                If lst_incentivo_24 = "S" Then
                            If lst_incentivo_24 = "S" OrElse lbapurar24 = True Then 'se no cadastro é 2,4 ou se por causo do limite de incentivo vai ter  2,4 e 2,5 no mesmo calculo
                                'fran 11/2022 f
                                'fran 25/06/2012 i escopo complementar calculo Themis (acerto de formula 1400 e incentivo24)
                                'lvalor_incentivo_24 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * 0.024, 4) * lvalor_volumeleite, 2)
                                'fran 19/07/2012 i incentivo 2,4 email enviado em 19/07, solicitando alteraçãoo da formula
                                'lvalor_incentivo_24 = Round(Round(((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) / 0.976) * lvalor_volumeleite, 4) * 0.024, 2)
                                'lvalor_incentivo_24 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * lvalor_volumeleite, 4) * 0.024, 2) ' fran 01/01/2014 inclusao gordura

                                'fran 11/2022 i
                                'lvalor_incentivo_24 = Round(Round((lpreco_notafiscal + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * lvalor_volumeleite, 4) * 0.024, 2) ' fran 01/01/2014 inclusao gordura
                                'lvalor_incentivo_24_unitario = lvalor_incentivo_24 / lvalor_volumeleite
                                lvalor_incentivo_24_unitario = lpreco_base * 0.024
                                If lnr_volume_incentivo24 > 0 Then 'se tem volume 2,4 apurado
                                    lvalor_incentivo_24 = Round(lvalor_incentivo_24_unitario * lnr_volume_incentivo24, 2)
                                    lnrvaloraux = Round(lvalor_incentivo_24_unitario * lnr_volume_incentivo24, 12)
                                Else
                                    lvalor_incentivo_24 = Round(lvalor_incentivo_24_unitario * lvalor_volumeleite, 2)
                                    lnrvaloraux = Round(lvalor_incentivo_24_unitario * lvalor_volumeleite, 12)
                                End If
                                'fran 11/2022 f

                                'fran 19/07/2012 f incentivo 2,4 email enviado em 19/07, solicitando alteraçãoo da formula
                                'fran 25/06/2012 f escopo complementar calculo Themis (acerto de formula 1400 e incentivo24)

                                Me.fichafinanceira.cd_conta = "2055"  ' Grava conta - Incentivo 2.4%
                                Me.fichafinanceira.nr_valor_conta = lvalor_incentivo_24
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "0350"  ' Grava conta - Incentivo 2.4%
                                Me.fichafinanceira.nr_valor_conta = lvalor_incentivo_24_unitario
                                Me.fichafinanceira.nr_valor_12 = lvalor_incentivo_24_unitario
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "2060"  ' Grava conta - 2060 Incentivo 2.4 liquido VALOR INCENTIVO - PISCOFINS 4,625%
                                Me.fichafinanceira.nr_valor_conta = Round(lnrvaloraux * (1 - (0.04625)), 2)
                                Me.fichafinanceira.nr_valor_12 = Round(lnrvaloraux * (1 - (0.04625)), 12)
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "0060"  ' Grava conta - 0060 preço liquido 2.4 preço bruto - piscofins 4,625% sem desconto ICMS sobre reço
                                Me.fichafinanceira.nr_valor_conta = Round(lpreco_base - (lpreco_base * 0.04625), 4)
                                Me.fichafinanceira.nr_valor_12 = Round(lpreco_base - (lpreco_base * 0.04625), 12)
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.nr_valor_12 = 0 'limpa campo
                            End If

                            'fran dez/2022 i
                            If lvalor_incentivofiscal = 0 AndAlso lvalor_incentivo_24 = 0 Then 'fran 12/2022
                                'grava a 0060 preco liq icms 0, se nao tem a conta 55 (preco liq quando tem que abater icms) e nao apurou a 0060 com incentivo 2.4 ou seja se nao tem nenhum incentivo, calcula o preco liq
                                Me.fichafinanceira.cd_conta = "0060"  ' Grava conta - 0060 preço liquido sem icms preço bruto - piscofins 4,625% sem desconto ICMS sobre reço
                                Me.fichafinanceira.nr_valor_conta = Round(lpreco_base - Round(lpreco_base * 0.04625, 4), 4)
                                Me.fichafinanceira.nr_valor_12 = Round(lpreco_base - (lpreco_base * 0.04625), 12)
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                Me.fichafinanceira.nr_valor_12 = 0 'limpa campo

                            End If
                            'fran dez/2022 f
                            If lst_transferencia_credito = "S" Then
                                lvalor_totalnota = Round(lpreco_notafiscal * lvalor_volumeleite, 2)
                            Else

                                'fran 25/06/2012 i escopo complementar calculo Themis (acerto de formula 1400 e incentivo24)
                                'lvalor_totalnota = Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * lvalor_volumeleite + lvalor_incentivo_21 + lvalor_incentivo_24, 2)
                                'lvalor_totalnota = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_incentivofiscal + lvalor_composicao_preco) * lvalor_volumeleite + lvalor_incentivo_21 + lvalor_incentivo_24, 2)  ' Para o consolidado utilizar o valor qualidade média ponderada 
                                If lst_incentivo_fiscal = "N" Then 'se nao tem incentivo
                                    'Conta 1400 = (Preço NT + Total Qualidade + Redutase + Reposicao + Composicao Preço) * VOLUME + Incentivo 21 + incentivo 24
                                    lvalor_totalnota = Round(Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2)
                                Else 'se tem incentivo
                                    'Conta 1400 = (Preço NT + Total Qualidade + Redutase + Reposicao + Composicao Preço) * VOLUME + ((Preço NT + Total Qualidade + Redutase + Reposicao + Composicao Preço) * VOLUME) * 0.025 + Incentivo 21 + incentivo 24 que na verdade é:
                                    'Conta 1400 = (Preço NT + Total Qualidade + Redutase + Reposicao + Composicao Preço) * VOLUME + (BASEICMS * 0.025) + Incentivo 21 + incentivo 24 que na verdade é:
                                    'lvalor_totalnota = Round(Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) + (Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) * 0.025) + lvalor_incentivo_21 + lvalor_incentivo_24, 2)
                                    'fran 11/2022 i
                                    'lvalor_totalnota = Round(Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2) + Round(lvalor_incentivofiscal * lvalor_volumeleite, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2) ' adri 14/09/2015 - chamado 2377 - considerar o incentivo fiscal 2,5% que já está calculado, pois gerava diferença no extrato
                                    If lnr_volume_incentivo25 > 0 Then

                                        lvalor_totalnota = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)
                                        lvalor_totalnota = Round(lvalor_totalnota + Round(lvalor_incentivofiscal * lnr_volume_incentivo25, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2)
                                    Else
                                        lvalor_totalnota = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)
                                        lvalor_totalnota = Round(lvalor_totalnota + Round(lvalor_incentivofiscal * lvalor_volumeleite, 2) + lvalor_incentivo_21 + lvalor_incentivo_24, 2)

                                    End If
                                    'fran 11/2022 f

                                End If
                                'fran 25/06/2012 f escopo complementar calculo Themis

                            End If

                            If lst_transferencia_credito = "S" Then
                                lvalor_baseICMS = lvalor_totalnota
                                lvalor_ICMS = Round(lvalor_baseICMS * 0.12, 2)
                                lvalor_transferencia_ICMS = Round(lpreco_notafiscal * 0.12 * lvalor_volumeleite, 2)
                            Else
                                If lst_incentivo_fiscal <> "N" Or lst_uf_produtor = "RJ" Then
                                    'lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_proteina + lvalor_CCS + lvalor_CTM + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)  ' 19/02/2009 Rls16
                                    'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i
                                    'lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)  ' Para o consolidado utilizar o valor qualidade média ponderada
                                    'lvalor_ICMS = Round(lvalor_baseICMS * 0.12, 2)
                                    If lbapurar25 = False Then ' fran 11/2022 se nao é pra apurar 2.5
                                        lvalor_baseICMS = 0
                                        lvalor_ICMS = 0
                                    Else
                                        If lnr_volume_incentivo25 > 0 Then
                                            lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lnr_volume_incentivo25, 2)
                                        Else
                                            lvalor_baseICMS = Round((lpreco_notafiscal + lvalor_qualidade + lvalor_redutase + lvalor_reposicao + lvalor_composicao_preco) * lvalor_volumeleite, 2)  ' fran 01/01/2014 inclusao gordura

                                        End If

                                        lvalor_ICMS = Round(lvalor_baseICMS * 0.12, 2)

                                    End If

                                    'FRAN 11/2022 - CALCULO LIMITE 2.5 e 2.4 i

                                Else
                                    lvalor_baseICMS = 0
                                    lvalor_ICMS = 0
                                End If

                            End If


                            Me.fichafinanceira.cd_conta = "1200"  ' Grava conta - Base ICMS
                            Me.fichafinanceira.nr_valor_conta = lvalor_baseICMS
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.cd_conta = "1300"  ' Grava conta - Base ICMS
                            Me.fichafinanceira.nr_valor_conta = lvalor_ICMS
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.cd_conta = "2040"  ' Grava conta - Transferência de ICMS
                            Me.fichafinanceira.nr_valor_conta = lvalor_transferencia_ICMS
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.cd_conta = "1400"  ' Grava conta - Total da Nota Fiscal
                            Me.fichafinanceira.nr_valor_conta = lvalor_totalnota
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()


                            '======================================================
                            ' Ponto 8 - Apurar Recolhimentos
                            '======================================================

                            If lvalor_funrural = 0 Then 'Só gera 1500 se 0800 tiver valor
                                lvalor_totalfunrural = 0
                            Else
                                'fran 31/01/2019 i FUNRURAL 2019 LEI 13606

                                ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018
                                'fran 23/04/2017 i retorno do funrural para referencia Abril/2017
                                ''fran 28/09/2016 i 'funrural nao existe mais deve apenas calcular sest/senat (2.3 antes 2.1 para funrural e 0.2 para sestsenat)
                                ''lvalor_totalfunrural = Round(lvalor_totalnota * 0.023, 2)
                                'lvalor_totalfunrural = Round(lvalor_totalnota * 0.002, 2)
                                ''fran 28/09/2016 f
                                ''lvalor_totalfunrural = Round(lvalor_totalnota * 0.023, 2)
                                'fran 23/04/2017 i retorno do funrural para referencia Abril/2017
                                'lvalor_totalfunrural = Round(lvalor_totalnota * 0.015, 2)
                                ''fran 31/01/2018 f FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018

                                'Se o produtor optou por recolher FUNRURAL
                                If lst_funrural = "P" Then
                                    'lvalor_totalfunrural = Round(lvalor_totalnota * 0.003, 2)  ' Calculo FunRural - desconta apenas SENAR/RAT
                                    lvalor_totalfunrural = Round(lvalor_totalnota * 0.002, 2)  ' Calculo FunRural - desconta apenas SENAR/RAT
                                Else
                                    'SE A DANONE recolhe o FUNRURAL de acordo com cadastro de fornecedor
                                    lvalor_totalfunrural = Round(lvalor_totalnota * 0.015, 2)  ' Calculo FunRural -desconta FUNRURAL + SENAR/RAT
                                End If
                                'fran 31/01/2019 f FUNRURAL 2019 LEI 13606

                            End If

                            Me.fichafinanceira.cd_conta = "1500"  ' Grava conta - Total FunRural
                            Me.fichafinanceira.nr_valor_conta = lvalor_totalfunrural
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            lvalor_creditoICMS = Round(lvalor_ICMS * lpercentual_ICMS, 2)  ' 5%, 10% ou 20%, dependendo da faixa de volume

                            Me.fichafinanceira.cd_conta = "1600"  ' Grava conta - Incentivo ICMS
                            Me.fichafinanceira.nr_valor_conta = lvalor_creditoICMS
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            '======================================================
                            ' Ponto 9 - Novas Contas para o SAP
                            '======================================================

                            ' ICMS
                            Me.fichafinanceira.cd_conta = "1250"  ' Grava conta - Alíquota ICMS
                            Me.fichafinanceira.nr_valor_conta = 0.12
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            ' COFINS
                            lbase_COFINS = lvalor_totalnota  '  Definição em 08/03/2012 da Marildes (Danone)
                            Me.fichafinanceira.cd_conta = "2100"  ' Grava conta - Base COFINS
                            Me.fichafinanceira.nr_valor_conta = lbase_COFINS
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.cd_conta = "2150"  ' Grava conta - Alíquota COFINS
                            'Me.fichafinanceira.nr_valor_conta = 4.56
                            'fran 25/06/2012 i escopo complementar calculo Themis
                            'Me.fichafinanceira.nr_valor_conta = 0   ' 08/03/2012 - Definição da Marildes da Danone
                            'Fran 02/11/2015 i troca de aliquota de 4.56 para 3,80 de acordo com email em 30/10 de Ricardo Francisco /Ana
                            'Me.fichafinanceira.nr_valor_conta = 4.56
                            Me.fichafinanceira.nr_valor_conta = 3.8
                            'Fran 02/11/2015 f troca de aliquota de 4.56 para 3.80 de acordo com email em 30/10 de Ricardo Francisco /Ana
                            'fran 25/06/2012 f
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            'fran 25/06/2012 i escopo complementar calculo Themis
                            'lvalor_COFINS = Convert.ToDecimal(lbase_COFINS * 0)
                            'Fran 02/11/2015 i troca de aliquota de 4.56 para 3,80 de acordo com email em 30/10 de Ricardo Francisco /Ana
                            'lvalor_COFINS = Convert.ToDecimal(Round(lbase_COFINS * 0.0456, 2))
                            lvalor_COFINS = Convert.ToDecimal(Round(lbase_COFINS * 0.038, 2))
                            'Fran 02/11/2015 f troca de aliquota de 4.56 para 3,80 de acordo com email em 30/10 de Ricardo Francisco /Ana
                            'fran 25/06/2012 f escopo complementar calculo Themis
                            Me.fichafinanceira.cd_conta = "2200"  ' Grava conta - Valor COFINS
                            Me.fichafinanceira.nr_valor_conta = lvalor_COFINS
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            ' PIS

                            lbase_PIS = lvalor_totalnota   '  Definição em 08/03/2012 da Marildes (Danone)
                            Me.fichafinanceira.cd_conta = "2300"  ' Grava conta - Base PIS
                            Me.fichafinanceira.nr_valor_conta = lbase_PIS
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.cd_conta = "2350"  ' Grava conta - Alíquota PIS
                            'Me.fichafinanceira.nr_valor_conta = 0.99
                            'fran 25/06/2012 i escopo complementar calculo Themis
                            'Me.fichafinanceira.nr_valor_conta = 0 ' 08/03/2012 - Definição da Marildes da Danone
                            'Fran 02/11/2015 i troca de aliquota de 0,99 para 0,83 de acordo com email em 30/10 de Ricardo Francisco /Ana
                            'Me.fichafinanceira.nr_valor_conta = 0.99
                            'Me.fichafinanceira.nr_valor_conta = 0.83 'FRAN 26/08/2020 i ALTERACAO ALIQUOTA PIS
                            Me.fichafinanceira.nr_valor_conta = 0.825 'FRAN 26/08/2020 i ALTERACAO ALIQUOTA PIS 
                            'Fran 02/11/2015 f troca de aliquota de 0,99 para 0,83 de acordo com email em 30/10 de Ricardo Francisco /Ana
                            'fran 25/06/2012 f escopo complementar calculo Themis
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            'fran 25/06/2012 i escopo complementar calculo Themis
                            'lvalor_PIS = Convert.ToDecimal(lbase_PIS * 0)
                            'Fran 02/11/2015 i troca de aliquota de 0,99 para 0,83 de acordo com email em 30/10 de Ricardo Francisco /Ana
                            'lvalor_PIS = Convert.ToDecimal(Round(lbase_PIS * 0.0099, 2))
                            'lvalor_PIS = Convert.ToDecimal(Round(lbase_PIS * 0.0083, 2)) FRAN 26/08/2020 i ALTERACAO ALIQUOTA PIS
                            lvalor_PIS = Convert.ToDecimal(Round(lbase_PIS * 0.00825, 2)) 'FRAN 26/08/2020 i ALTERACAO ALIQUOTA PIS
                            'Fran 02/11/2015 f troca de aliquota de 0,99 para 0,83 de acordo com email em 30/10 de Ricardo Francisco /Ana
                            'fran 25/06/2012 f escopo complementar calculo Themis
                            Me.fichafinanceira.cd_conta = "2400"  ' Grava conta - Valor PIS
                            Me.fichafinanceira.nr_valor_conta = lvalor_PIS
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            'fran 18/07/2016 i
                            '======================================================
                            ' Ponto 9 - Apurar Custos Danone  
                            '======================================================

                            lvalor_antesPISCONFINS = Round(lvalor_totalnota - lvalor_ICMS + lvalor_creditoICMS, 2)
                            lvalor_custounitario = lvalor_antesPISCONFINS / lvalor_volumeleite
                            lvalor_PISCOFINS = Round(lvalor_totalnota * 0.0555, 2)
                            lvalor_totalERP = Round(lvalor_antesPISCONFINS - lvalor_PISCOFINS, 2)
                            lvalor_custounitarioERP = lvalor_totalERP / lvalor_volumeleite

                            Me.fichafinanceira.cd_conta = "1700"  ' Grava conta - Valor antes PIS e COFINS
                            Me.fichafinanceira.nr_valor_conta = lvalor_antesPISCONFINS
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.cd_conta = "1800"  ' Grava conta - Custo Unitário
                            Me.fichafinanceira.nr_valor_conta = lvalor_custounitario
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.cd_conta = "1900"  ' Grava conta - PIS e COFINS
                            Me.fichafinanceira.nr_valor_conta = lvalor_PISCOFINS
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.cd_conta = "2000"  ' Grava conta - Total ERP
                            Me.fichafinanceira.nr_valor_conta = lvalor_totalERP
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.cd_conta = "2010"  ' Grava conta - Custo Unitário ERP
                            Me.fichafinanceira.nr_valor_conta = lvalor_custounitarioERP
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            Me.fichafinanceira.cd_conta = "0600"    ' Adiantamento Quinzenal
                            Me.fichafinanceira.nr_valor_conta = lvalor_adiantamento     ' 16/01/2009
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()

                            '======================================================
                            ' Apurar DESCONTO TAXA IMA
                            '======================================================

                            'fran 09/2018 i alteração legal IMA
                            If lvalor_IMA_taxa > 0 Then
                                'Valor da taxa do iMA = para cada 1000 litros de leite deve ser pago ao IMA 0,49 centavos, sendo metade da DANONE metade do produtor
                                'formula volume leite dividido por 1000, resultado multiplicar pelo parametro em estabelecimento (0,49), e por fim dividir por 2 para colocar a parte do produtor
                                lvalor_IMA = Round((((lvalor_volumeleite / 1000) * lvalor_IMA_taxa) / 2), 2)

                                Me.fichafinanceira.cd_conta = "9995"    ' TAXA IMA DO PRODUTOR
                                Me.fichafinanceira.nr_valor_conta = lvalor_IMA
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'fran 02/2019 i aliquota ima
                                Me.fichafinanceira.cd_conta = "9994"  ' Grava conta - ALIQUOTA ima
                                Me.fichafinanceira.nr_valor_conta = lvalor_IMA_taxa
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                'fran 02/2019 f aliquota ima
                            Else
                                lvalor_IMA = 0
                            End If
                            'fran 09/2018 f alteração legal IMA

                            '======================================================
                            ' Ponto 13 - Apurar DESCONTO CLUBE DE COMPRAS
                            '======================================================

                            Me.fichafinanceira.dt_referencia_ficha_start = Me.dt_referencia_start
                            Me.fichafinanceira.dt_referencia_ficha_end = Me.dt_referencia_end
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.id_natureza = 2  ' Desconto
                            Me.fichafinanceira.st_clube_compra = "S"  ' 20/08/2009 - Rls18 - Trazer somente somatório de descontos da Central para corrigir conta 1000
                            Me.fichafinanceira.cd_conta = ""    ' Limpa a conta 

                            lvalor_descontos = Math.Abs(Me.fichafinanceira.getFichaFinanceiraValorConta())  ' Somatório dos descontos no mes de referencia

                            Me.fichafinanceira.st_clube_compra = ""  ' 20/08/2009 - Rls18 - Limpa atributo para próximas utilizações
                            'fran 07/2017 - guarda desconto para facilitar conferencia calculo i

                            Me.fichafinanceira.cd_conta = "0900"    ' Desconto Clube Compras
                            Me.fichafinanceira.nr_valor_conta = lvalor_descontos
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()
                            'fran 07/2017 - guarda desconto para facilitar conferencia calculo f

                            'fran 07/2017 i 
                            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                            'APURAR ANTECIPACAO
                            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                            lvalor_antecipacao = 0
                            lvalor_descontos_antecipacao = 0
                            lvalor_bonus_poupanca = 0
                            lvalor_reposicao_antecipacao = 0
                            lvalor_volume_total_propriedade = 0
                            lvalor_volume_antecipacao = 0
                            'se deve tratar antecipacao
                            If Me.nr_dias_antecipacao > 0 Then

                                'fran 10/2017 - deve somar bonus da poupanca a antecipacao
                                lvalor_bonus_poupanca = Math.Abs(Me.fichafinanceira.getFichaFinanceiraValorBonusPoupanca())  ' Somatório das contas de bonus poupanca 5500 e bonus extra poupanca 5550

                                'fran 02/2019 i antecipaçlao deve considerar contas de reposicao de preco (natureza composicao do preço)
                                lvalor_reposicao_antecipacao = Math.Abs(Me.fichafinanceira.getFichaFinanceiraValorReposAntecipacao())  ' Somatório das contas de reposicao qualidade e reposicao de preço 9997 e 9998
                                'fran 02/2019 f 

                                'fran 09/2017 i antecipação
                                lvalor_descontos_antecipacao = Math.Abs(Me.fichafinanceira.getFichaFinanceiraValorDescontosAntecipacao())  ' Somatório dos descontos do tipo central retirando frete (8000) e educampo (4000)
                                Me.fichafinanceira.st_clube_compra = ""
                                'guarda desconto antecipacao para facilitar conferencia calculo 
                                Me.fichafinanceira.cd_conta = "0910"    ' Desconto Antecipação
                                Me.fichafinanceira.nr_valor_conta = lvalor_descontos_antecipacao
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                                'fran 09/2017 f antecipação

                                lvalor_volume_total_propriedade = lvalor_volumeleite
                                'lvalor_volume_antecipacao = CLng((lvalor_volume_total_propriedade / lnr_dias_referencia) * Me.nr_dias_antecipacao)
                                lvalor_volume_antecipacao = Me.getCalculoVolumeLeiteAntecipacaobyPropriedade
                                'guarda as contas de volume utilizas na apuracao antecipação
                                Me.fichafinanceira.cd_conta = "0710"    ' Volume Total Propriedade
                                Me.fichafinanceira.nr_valor_conta = lvalor_volume_total_propriedade
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                Me.fichafinanceira.cd_conta = "0720"    ' Volume Leite Antecipação
                                Me.fichafinanceira.nr_valor_conta = lvalor_volume_antecipacao
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'apura valor de antecipação bruto
                                'lvalor_antecipacao = Round((lpreco_negociado + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_incentivofiscal - lvalor_funrural + lvalor_incentivo_21 + lvalor_incentivo_24) * lvalor_volume_antecipacao, 4)
                                lvalor_antecipacao = Round((lpreco_negociado + lvalor_proteina + lvalor_gordura + lvalor_CCS + lvalor_CTM + lvalor_incentivofiscal - lvalor_funrural + lvalor_incentivo_24_unitario) * lvalor_volume_antecipacao, 4)

                                'fran 02/2019 i ao valor bruto de antecipacao deve ser somado as contas de reposicao de preço e de qualidade
                                'fran 10/2017 i
                                'soma ao valor bruto, o bonus de poupanca
                                'lvalor_antecipacao = lvalor_antecipacao + lvalor_bonus_poupanca
                                'fran 10/2017 f
                                lvalor_antecipacao = lvalor_antecipacao + lvalor_bonus_poupanca + lvalor_reposicao_antecipacao
                                'fran 02/2019 f 

                                Me.fichafinanceira.cd_conta = "0750"    ' Antecipação Bruto
                                Me.fichafinanceira.nr_valor_conta = lvalor_antecipacao
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()

                                'fran 09/2017i
                                'lvalor_antecipacao = Round(lvalor_antecipacao - lvalor_adiantamento - lvalor_descontos, 2)
                                lvalor_antecipacao = Round(lvalor_antecipacao - lvalor_adiantamento - lvalor_descontos_antecipacao, 2)

                                'fran 27/10/2017 i
                                'se valor antecipacao liquido for negativo ou igual a zero
                                If lvalor_antecipacao <= 0 Then
                                    lvalor_antecipacao = 0
                                End If

                                'se valor antecipacao liquido maior que zero e  a conta de rendimento liquido for menor que zero, nao antecipar valor
                                If lvalor_antecipacao > 0 Then
                                    'se o rendimento liquido for ficar negativo
                                    If (lvalor_totalnota - lvalor_totalfunrural - lvalor_adiantamento - lvalor_descontos - lvalor_antecipacao) < 0 Then
                                        'valor antecipacao liquido será o valor antecipação subtraindo a diferenca do rendimento liquito sobre a antecipação + 10 (valor simbolico de  seguranca para nao gerar nota final com valor zero
                                        lvalor_antecipacao = lvalor_antecipacao - (Abs(lvalor_totalnota - lvalor_totalfunrural - lvalor_adiantamento - lvalor_descontos - lvalor_antecipacao) + 10)
                                        'se mesmo retirando a difereça e somando apenas 10 reais a anetcipação ficar negativa
                                        If lvalor_antecipacao < 0 Then
                                            lvalor_antecipacao = 0
                                        End If
                                    End If
                                    'lvalor_antecipacao = 0

                                End If
                                'fran 09/2017f

                                Me.fichafinanceira.cd_conta = "0700"    ' Antecipação Liquido
                                Me.fichafinanceira.nr_valor_conta = lvalor_antecipacao
                                Me.fichafinanceira.st_origem_conta = "C"
                                Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                                Me.fichafinanceira.insertFichaFinanceiraItens()
                            End If

                            'fran 07/2017 f 

                            '======================================================
                            ' Ponto 13 - Apurar Rendimento Líquido
                            '======================================================
                            'fran 07/2017 i deduzir valor antecipado
                            lvalor_subtotal_receber = lvalor_totalnota - lvalor_totalfunrural - lvalor_adiantamento - lvalor_descontos - lvalor_antecipacao
                            'fran 07/2017 f deduzir valor antecipado

                            Me.fichafinanceira.cd_conta = "1000"    ' Rendimento Líquido
                            Me.fichafinanceira.nr_valor_conta = lvalor_subtotal_receber
                            Me.fichafinanceira.st_origem_conta = "C"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            Me.fichafinanceira.insertFichaFinanceiraItens()
                            'fran 18/07/2016 f


                            ' Chamado 1151 - 29/05/2012 Projeto Themis - Gerar Nota Fiscal para pagamento consolidado, pois é necessário ao SAP - i
                            '==============================================================================
                            ' Ponto 10 - Atualiza N.o da Nota Fiscal (se Cálculo Definitivo)
                            '===============================================================================
                            If Me.st_pagamento = "D" Then   ' Se Cálculo Definitivo 
                                Me.fichafinanceira.nr_nota_fiscal = Me.getCalculoNumeroNotaFiscal()
                                Me.fichafinanceira.updateFichaFinanceiraNF()   ' Nova procedure
                            End If
                            ' Chamado 1151 - 29/05/2012 Projeto Themis - Gerar Nota Fiscal para pagamento consolidado, pois é necessário ao SAP - f

                            ' 07/03/2012 - Nas tabelas ms_calculo_execucao e ms_calculo_execucao_itens não é registrado o Tipo Pagamento C, e estes inserts atrapaham a conferência do resultado após o processamento
                            'Me.calculoexecucao.st_calculo_execucao_itens = "2"   '  Seta Unidade/U.Producao = status 2-Sucesso
                            'Me.calculoexecucao.updateCalculoExecucaoItens()

                            'End If  ' Fim se primeira Unidade de Produção (só calcula para a primeira, pois dados vem consolidado)

                        Else

                            'Me.calculoexecucao.st_calculo_execucao_itens = "4"   '  Seta Unidade/U.Producao = status 4-Não Calculado
                            'Me.calculoexecucao.updateCalculoExecucaoItens()

                        End If  ' Se fim Volume Leite = 0


                    End If  '  Fim se status pagamento <> "D" - Definitivo

                End If  ' Fim se primeira Unidade de Produção (só calcula para a primeira, pois dados vem consolidado)

            Next
            ' 06/03/2012 - Projeto Themis - Processo de Cálculo unificado por IE - f

            ' Finaliza Cálculo
            calculoexecucao.st_calculo_execucao = "F"       ' Finalizado
            calculoexecucao.updateCalculoExecucao()
            deleteCalculoProdutor()

        Catch err As Exception
            calculoexecucao.st_calculo_execucao = "E"       ' Finalizado com erro
            calculoexecucao.updateCalculoExecucao()
            ' 20081126 - i
            calculoexecucao.nm_erro = err.Message
            calculoexecucao.insertCalculoExecucaoErro()
            ' 20081126 - f
            Throw New Exception(err.Message)
        End Try

    End Sub
    Public Function apurarIndiceQualidade() As Decimal

        Try

            ' Salva as coletas de Proteína
            Dim li_analise As Int16 = 0
            Dim li_coletas As Int16 = 0
            Dim lmedia_analise As Decimal = 0  ' Adri 12/04/2010
            Dim lvalor_analise_esalq(5) As Decimal
            Dim lmedia_analise_geometrico_mensal As Decimal = 0 'fran 09/2016

            Dim lid_operador_faixa_qualidade_complience As Integer = 0  ' adri 19/12/2016 - Curva ABC
            Dim lnr_valor_faixa_qualidade_complience As Decimal = 0 ' adri 19/12/2016 - Curva ABC

            Me.nr_media_analise_geometrico_mensal = lmedia_analise_geometrico_mensal ' fran 09/2016 limpa variavel

            '===========================================================
            ' Adri 14/06/2016 - chamado 2448 - Cálculo Geométrico - i
            '===========================================================
            If Me.id_categoria = 1 Or Me.id_categoria = 2 Then  ' Se CCS ou CBT(CTM)
                Dim dsCalculoAnaliseEsalqCalculoGeometrico As DataSet = getCalculoAnaliseEsalqCalculoGeometrico()

                ' Salva as coletas de CCS e CTB 
                Dim lvalor_multiplicado As Double = 1
                Dim lpotencia As Decimal = 0

                If dsCalculoAnaliseEsalqCalculoGeometrico.Tables(0).Rows.Count > 0 Then
                    For li_analise = 0 To dsCalculoAnaliseEsalqCalculoGeometrico.Tables(0).Rows.Count - 1
                        li_coletas = li_coletas + 1
                        lvalor_multiplicado = lvalor_multiplicado * Convert.ToDecimal(dsCalculoAnaliseEsalqCalculoGeometrico.Tables(0).Rows(li_analise).Item("nr_valor_esalq"))
                    Next
                    lpotencia = 1 / li_coletas
                    lmedia_analise = lvalor_multiplicado ^ lpotencia
                End If
                'FRan 07/2016 i calculo geometrico
                lmedia_analise = Round(lmedia_analise, 0)
                'FRan 07/2016 f. calculo geometrico

                'FRan 09/2016 i calculo geometrico mensal para poupança
                'Apura Teor de CTM e CCS geometrico mensal (utilizado em poupança e relatorios de qualidade)
                lvalor_multiplicado = 1
                lpotencia = 0
                Dim li_coletasmensal As Int16 = 0
                Dim dsCalculoAnaliseEsalqCalculoGeometricoMensal As DataSet = getCalculoAnaliseEsalqCalculoGeometricoMensal()

                If dsCalculoAnaliseEsalqCalculoGeometricoMensal.Tables(0).Rows.Count > 0 Then
                    For li_analise = 0 To dsCalculoAnaliseEsalqCalculoGeometricoMensal.Tables(0).Rows.Count - 1
                        li_coletasmensal = li_coletasmensal + 1
                        lvalor_multiplicado = lvalor_multiplicado * Convert.ToDecimal(dsCalculoAnaliseEsalqCalculoGeometricoMensal.Tables(0).Rows(li_analise).Item("nr_valor_esalq"))
                    Next
                    lpotencia = 1 / li_coletasmensal
                    lmedia_analise_geometrico_mensal = lvalor_multiplicado ^ lpotencia
                End If
                lmedia_analise_geometrico_mensal = Round(lmedia_analise_geometrico_mensal, 0)
                Me.nr_media_analise_geometrico_mensal = lmedia_analise_geometrico_mensal
                'FRan 09/2016 f calculo geometrico mensal para poupança

                ' Adri 19/12/2016 - Verifica se a Média Geométrica Trimestral de CTM é complience


            Else
                '===========================================================
                ' Adri 14/06/2016 - chamado 2448 - Cálculo Geométrico - f
                '===========================================================

                Dim dsCalculoAnaliseEsalq As DataSet = getCalculoAnaliseEsalq()

                'fran 31/08/2016 i- A partir da referencia de agosto/2016 o calculo deve considerar todas as analises encontradas e dividir pelo numero de coletas
                'If dsCalculoAnaliseEsalq.Tables(0).Rows.Count > 0 Then
                '    For li_analise = 0 To dsCalculoAnaliseEsalq.Tables(0).Rows.Count - 1
                '        li_coletas = li_coletas + 1
                '        If li_coletas > 5 Then  ' considera somente 5 coletas
                '            li_coletas = 5  ' 14/04/2009 - Chamdo 225 - Acerto para o Rls17.4
                '            Exit For
                '        End If
                '        lvalor_analise_esalq(li_coletas) = Convert.ToDecimal(dsCalculoAnaliseEsalq.Tables(0).Rows(li_analise).Item("nr_valor_esalq"))
                '    Next
                'End If

                'Select Case li_coletas
                '    Case 5  ' Se 5 coletas, despreza o menor e maior valor e faz media dos tres
                '        lmedia_analise = (lvalor_analise_esalq(2) + lvalor_analise_esalq(3) + lvalor_analise_esalq(4)) / 3
                '    Case 4  ' Se 4 coletas, despreza o menor e maior valor e faz media das duas
                '        lmedia_analise = (lvalor_analise_esalq(2) + lvalor_analise_esalq(3)) / 2
                '    Case 3  ' Se 3 coletas, faz media das tres
                '        lmedia_analise = (lvalor_analise_esalq(1) + lvalor_analise_esalq(2) + lvalor_analise_esalq(3)) / 3
                '    Case 2  ' Se 2 coletas, faz media das duas
                '        lmedia_analise = (lvalor_analise_esalq(1) + lvalor_analise_esalq(2)) / 2
                '    Case 1  ' Se 1 coleta
                '        lmedia_analise = lvalor_analise_esalq(1)
                'End Select
                If dsCalculoAnaliseEsalq.Tables(0).Rows.Count > 0 Then
                    For li_analise = 0 To dsCalculoAnaliseEsalq.Tables(0).Rows.Count - 1
                        li_coletas = li_coletas + 1

                        lmedia_analise = lmedia_analise + Convert.ToDecimal(dsCalculoAnaliseEsalq.Tables(0).Rows(li_analise).Item("nr_valor_esalq"))
                    Next
                End If
                'se tem mais de duas coletas faz a media , caso tenha uma so, fica mesmo valor, e se não tiver nenhuma assume media = 0
                If li_coletas > 1 Then
                    lmedia_analise = (lmedia_analise) / li_coletas
                End If
                'fran 31/08/2016 f- A partir da referencia de agosto/2016 o calculo deve considerar todas as analises encontradas e dividir pelo numero de coletas

                'FRan 07/2016 i calculo geometrico
                lmedia_analise = Round(lmedia_analise, 4)
                'FRan 07/2016 f. calculo geometrico

            End If

            'FRan 07/2016 i calculo geometrico
            'fran fase 2 melhoria fev/2014
            '' 15/10/2009 - Chamado 496 - Arredondar o resultado da média para buscar na Faixa de Qualidade (ex: media=3,0066666666... deve ficar com 3,01)
            'lmedia_analise = Round(lmedia_analise, 2)
            'lmedia_analise = Round(lmedia_analise, 4)
            'fran fase 2 melhoria f
            'FRan 07/2016 f. calculo geometrico

            nr_media_analise = lmedia_analise  ' Adri 12/04/2010 - chamado 772 - disponibiliza a média em um campo da classe para gravar na conta 0152

            If li_coletas > 0 Then  ' Se teve coletas
                Me.nr_valor = lmedia_analise
                'fran 11/2014 gold fase 3 i
                If Me.st_gold = "S" Then 'se for gold pega faixas de qualidade do gold
                    Select Case Me.id_categoria
                        Case 1 'CCS
                            Me.id_categoria = 5 'CCs GOLD
                        Case 2 'CTM
                            Me.id_categoria = 6 'CTM GOLD
                        Case 3 'Proteina
                            Me.id_categoria = 7 'Proteina GOLD
                        Case 4 'MG
                            Me.id_categoria = 8 'MG GOLD
                    End Select
                End If
                'fran 11/2014 gold fase 3 i

                '=========================================================================================
                ' adri 19/12/2016 - Curva ABC - Verifica se média é cmplience de acordo com a cetgoria - i
                '=========================================================================================
                nr_media_analise_complience = False  ' Inicializa média Não Complience
                'fran 18/04/2017 i - se teor for zerado deve assumir SEM COMPLIECENCE
                If nr_media_analise <> 0 Then
                    'fran 18/04/2017 f - se teor for zerado deve assumir SEM COMPLIECENCE
                    Dim dsCalculoFaixaQualidadeComplience As DataSet = Me.getCalculoFaixaQualidadeComplience()
                    If dsCalculoFaixaQualidadeComplience.Tables(0).Rows.Count > 0 Then

                        Select Case dsCalculoFaixaQualidadeComplience.Tables(0).Rows(0).Item("id_operador")
                            Case 1  ' > que
                                If nr_media_analise > Convert.ToDecimal(dsCalculoFaixaQualidadeComplience.Tables(0).Rows(0).Item("nr_valor")) Then
                                    nr_media_analise_complience = True
                                End If
                            Case 2  ' < que
                                If nr_media_analise < Convert.ToDecimal(dsCalculoFaixaQualidadeComplience.Tables(0).Rows(0).Item("nr_valor")) Then
                                    nr_media_analise_complience = True
                                End If
                            Case 3  ' = 
                                If nr_media_analise = Convert.ToDecimal(dsCalculoFaixaQualidadeComplience.Tables(0).Rows(0).Item("nr_valor")) Then
                                    nr_media_analise_complience = True
                                End If

                        End Select
                    End If
                End If

                '=========================================================================================
                ' adri 19/12/2016 - Curva ABC - Verifica se média é cmplience de acordo com a cetgoria - f
                '=========================================================================================

                Return Me.getCalculoFaixaQualidade ' Busca de acordo com a faixa o  valor do bônus ou desconto
            End If

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
    End Function
    ' adri 11/07/2016 - chmado 2448 - Cálculo Geométrico - Consoidado - i
    Public Function apurarIndiceQualidadeConsolidado(ByVal pmedia_analise As Decimal) As Decimal

        Try

            'fran 07/2016 calculo geometrico
            'se ccs ou ctm desprezar zeros e arredondar, as outras utilizar 4 decimais
            If Me.id_categoria = 1 Or Me.id_categoria = 2 Then
                pmedia_analise = Round(pmedia_analise, 0)
            Else
                pmedia_analise = Round(pmedia_analise, 4)
            End If
            'pmedia_analise = Round(pmedia_analise, 4)
            'fran 07/2016 f calculo geometrico

            nr_media_analise = pmedia_analise

            Me.nr_valor = pmedia_analise
            If Me.st_gold = "S" Then 'se for gold pega faixas de qualidade do gold
                Select Case Me.id_categoria
                    Case 1 'CCS
                        Me.id_categoria = 5 'CCs GOLD
                    Case 2 'CTM
                        Me.id_categoria = 6 'CTM GOLD
                    Case 3 'Proteina
                        Me.id_categoria = 7 'Proteina GOLD
                    Case 4 'MG
                        Me.id_categoria = 8 'MG GOLD
                End Select
            End If

            Return Me.getCalculoFaixaQualidade ' Busca de acordo com a faixa o teor ponderado

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
    End Function
    ' adri 11/07/2016 - chmado 2448 - Cálculo Geométrico - Consoidado - f

    Public Sub insertCalculoProdutor()


        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_deleteCalculoProdutor", parameters, ExecuteType.Update)

            transacao.Execute("ms_insertCalculoProdutor", parameters, ExecuteType.Insert)

            transacao.Commit()

        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try


    End Sub
    Public Sub insertCalculoAdiantamento()


        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_deleteCalculoAdiantamento", parameters, ExecuteType.Update)

            transacao.Execute("ms_insertCalculoAdiantamento", parameters, ExecuteType.Insert)

            transacao.Commit()

        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try


    End Sub

    Public Sub updateCalculoProdutor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCalculoProdutor", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCalculoProdutorTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCalculoProdutorTodos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCalculoAdiantamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCalculoAdiantamento", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCalculoAdiantamentoTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCalculoAdiantamentoTodos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub deleteCalculoProdutor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCalculoProdutor", parameters, ExecuteType.Delete)

        End Using

    End Sub
    Public Sub deleteCalculoAdiantamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCalculoAdiantamento", parameters, ExecuteType.Delete)

        End Using

    End Sub

    Public Function getCalculoProdutorSelecionado() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoProdutorSelecionado", parameters, "ms_calculo_produtor")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoProdutorAdiantamentoSelecionado() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoProdutorAdiantamentoSelecionado", parameters, "ms_calculo_adiantamento")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoAnaliseEsalq() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoAnaliseEsalq", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    ' Adri 14/06/2016 - chamado 2448 - i
    Public Function getCalculoAnaliseEsalqCalculoGeometrico() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoAnaliseEsalqCalculoGeometrico", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoAnaliseEsalqCalculoGeometricoMensal() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoAnaliseEsalqCalculoGeometricoMensal", parameters, "ms_analise_esalq")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoAnaliseEsalqLiberada() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoAnaliseEsalqLiberada", parameters, "ms_analise_esalq_header")
            Return dataSet

        End Using

    End Function
    ' Adri 14/06/2016 - chamado 2448 - f

    ' Adri - 20/06/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês - i
    Public Sub updateCalculoVolumeLeitePago()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCalculoVolumeLeitePago", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCalculoVolumeLeitePagoDesfazer()  ' Adri - 26/07/2016 - chamado 2451

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCalculoVolumeLeitePagoDesfazer", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getCalculoVolumeLeiteDefinitivo() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoVolumeLeiteDefinitivo", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCalculoVolumeLeitebyPropriedade() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoVolumeLeitebyPropriedade", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCalculoVolumeLeiteAntecipacaobyPropriedade() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoVolumeLeiteAntecipacaobyPropriedade", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCalculoVolumeLeiteTabela() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoVolumeLeiteTabela", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCalculoVolumeLeiteReferenciaAnterior() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoVolumeLeiteReferenciaAnterior", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCalculoVolumeLeiteConsolidadoReferenciaAnterior() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoVolumeLeiteConsolidadoReferenciaAnterior", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    ' Adri - 20/06/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês - f

    Public Function getCalculoVolumeLeite() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoVolumeLeite", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCalculoFaixaQualidade() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoFaixaQualidade", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    ' 19/12/2016 - Adri - Curva ABC - i
    Public Function getCalculoFaixaQualidadeComplience() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoFaixaQualidadeComplience", parameters, "ms_faixa_qualidade_complience")
            Return dataSet

        End Using

    End Function
    ' 19/12/2016 - Adri - Curva ABC - f
    Public Function getCalculoPessoaContratoSituacao() As Integer 'fran dango 2018
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoPessoaContratoSituacao", parameters, ExecuteType.Select), Integer)

        End Using
    End Function

    Public Function getCalculoContratoFaixaAdicionalVolume() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoContratoFaixaAdicionalVolume", parameters, "ms_contrato_adicional_volume")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoPrecoNegociado() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoPrecoNegociado", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getCalculoPrecoNegociadoProvisorio() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoPrecoNegociadoProvisorio", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getFichaFinanceiraPrecoNegociado() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFichaFinanceiraPrecoNegociado", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    ' Adriana 22/10/2014 - Projeto GOLD - i
    Public Function getCalculoPrecoGold() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoPrecoGold", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    ' Adriana 22/10/2014 - Projeto GOLD - f
    Public Function getCalculoPrecoGoldProvisorio() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoPrecoGoldProvisorio", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Sub calculoDescontarEmprestimo()

        Try

            'Dim dsCalculoContasParceladas As DataSet = getCalculoContasPerceladas()
            'Dim li As Int32
            'Dim dt_inicio_desconto As String

            'For li = 0 To dsCalculoContasParceladas.Tables(0).Rows.Count - 1
            'dt_inicio_desconto = dsCalculoContasParceladas.Tables(0).Rows(0).Item("dt_inicio_desconto")

            'Next


            'Ler Cadastro de Empréstimos, as contas com data maior ou igual ao mês do cálculo;
            'Se Número Total de Parcelas for maior que o número de parcelas já descontadas:
            '    SUBTOTAL RECEBER = SUBTOTAL RECEBER – Valor Parcela;
            '    Subtrai 1 do Numero de Parcelas Descontadas se não for recalculo no mês;
            '    Gera Conta 0900 – Empréstimo
            'Fim(Se)

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try

    End Sub
    Public Function getCalculoContaAdtoQuinzenal() As Decimal
        'Using data As New DataAccess

        '    Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
        '    Return CType(data.ExecuteScalar("getCalculoContaAdtoQuinzenal", parameters, ExecuteType.Select), Decimal)

        'End Using
    End Function
    Public Function getCalculoVolumeProdutor() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoVolumeProdutor", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function

    Public Function getCalculoStatusPagamento() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoStatusPagamento", parameters, ExecuteType.Select), String)

        End Using
    End Function

    Public Function getCalculoIncentivoFiscal() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoIncentivoFiscal", parameters, ExecuteType.Select), String)

        End Using
    End Function
    Public Function getCalculoConsideraQualidade() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoConsideraQualidade", parameters, ExecuteType.Select), String)

        End Using
    End Function
    Public Function getCalculoTransferenciaCredito() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoTransferenciaCredito", parameters, ExecuteType.Select), String)

        End Using
    End Function
    Public Function getCalculoFaixaIncentivoFiscal() As Decimal

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoFaixaIncentivoFiscal", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Sub calculoApurarLancamentos(ByVal natureza As String)

        Try

            ' 12/01/2010 - Chamado 581 - código desnecessário - i
            'Dim lancamento As New Lancamento

            'lancamento.dt_referencia = Me.dt_referencia
            'lancamento.id_propriedade = Me.id_propriedade
            'lancamento.id_situacao = 1      ' 01/06/2009 - Chamado 280 (trazer somente lançamentos ativos)
            ' 12/01/2010 - Chamado 581 - código desnecessário - f

            Dim dsCalculoLancamento As DataSet = getCalculoLancamento()
            Dim lvalor As Decimal = 0
            Dim li As Int16 = 0

            If dsCalculoLancamento.Tables(0).Rows.Count > 0 Then
                For li = 0 To dsCalculoLancamento.Tables(0).Rows.Count - 1

                    If natureza = "D" Then  ' Se é para descareegar só os descontos
                        If dsCalculoLancamento.Tables(0).Rows(li).Item("id_natureza") = 2 Then  ' Se a conta tem Natureza de desconto 
                            Me.fichafinanceira.cd_conta = dsCalculoLancamento.Tables(0).Rows(li).Item("cd_conta")    ' Código da Conta
                            Me.fichafinanceira.nr_valor_conta = dsCalculoLancamento.Tables(0).Rows(li).Item("nr_valor")
                            Me.fichafinanceira.st_origem_conta = "I"
                            Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                            ' Habilitar para Releases da Central de Compras - i
                            ' Adriana 20/05/2010 - chamado 843 - i
                            If Not IsDBNull(dsCalculoLancamento.Tables(0).Rows(li).Item("id_central_pedido")) Then
                                Me.fichafinanceira.id_central_pedido = dsCalculoLancamento.Tables(0).Rows(li).Item("id_central_pedido")
                            Else
                                Me.fichafinanceira.id_central_pedido = 0
                            End If
                            ' Adriana 20/05/2010 - chamado 843 - f
                            ' fran 1/12/2010 - chamado 1066 - i
                            If Not IsDBNull(dsCalculoLancamento.Tables(0).Rows(li).Item("id_central_pedido_desconto_produtor")) Then
                                Me.fichafinanceira.id_central_pedido_desconto_produtor = dsCalculoLancamento.Tables(0).Rows(li).Item("id_central_pedido_desconto_produtor")
                            Else
                                Me.fichafinanceira.id_central_pedido_desconto_produtor = 0
                            End If
                            ' fran 1/12/2010 - chamado 1066 - f
                            'Fran 21/01/2011 i gko fase 2
                            If Not IsDBNull(dsCalculoLancamento.Tables(0).Rows(li).Item("id_transportador")) Then
                                Me.fichafinanceira.id_transportador = dsCalculoLancamento.Tables(0).Rows(li).Item("id_transportador")
                            Else
                                Me.fichafinanceira.id_transportador = 0
                            End If

                            'Fran 21/01/2011 f gko fase 2

                            ' Habilitar para Releases da Central de Compras - f
                            Me.fichafinanceira.insertFichaFinanceiraItens()
                        End If
                    Else
                        Me.fichafinanceira.cd_conta = dsCalculoLancamento.Tables(0).Rows(li).Item("cd_conta")    ' Código da Conta
                        Me.fichafinanceira.nr_valor_conta = dsCalculoLancamento.Tables(0).Rows(li).Item("nr_valor")
                        Me.fichafinanceira.st_origem_conta = "I"
                        Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                        ' Habilitar para Releases da Central de Compras - i
                        ' Adriana 20/05/2010 - chamado 843 - i
                        If Not IsDBNull(dsCalculoLancamento.Tables(0).Rows(li).Item("id_central_pedido")) Then
                            Me.fichafinanceira.id_central_pedido = dsCalculoLancamento.Tables(0).Rows(li).Item("id_central_pedido")
                        Else
                            Me.fichafinanceira.id_central_pedido = 0
                        End If
                        ' Adriana 20/05/2010 - chamado 843 - f
                        ' fran 1/12/2010 - chamado 1066 - i
                        If Not IsDBNull(dsCalculoLancamento.Tables(0).Rows(li).Item("id_central_pedido_desconto_produtor")) Then
                            Me.fichafinanceira.id_central_pedido_desconto_produtor = dsCalculoLancamento.Tables(0).Rows(li).Item("id_central_pedido_desconto_produtor")
                        Else
                            Me.fichafinanceira.id_central_pedido_desconto_produtor = 0
                        End If
                        ' fran 1/12/2010 - chamado 1066 - f
                        'Fran 21/01/2011 i gko fase 2
                        If Not IsDBNull(dsCalculoLancamento.Tables(0).Rows(li).Item("id_transportador")) Then
                            Me.fichafinanceira.id_transportador = dsCalculoLancamento.Tables(0).Rows(li).Item("id_transportador")
                        Else
                            Me.fichafinanceira.id_transportador = 0
                        End If

                        'Fran 21/01/2011 f gko fase 2

                        ' Habilitar para Releases da Central de Compras - f
                        Me.fichafinanceira.insertFichaFinanceiraItens()

                        'fran 12/2021 - i
                        'se for a conta 3990, rendimento liquido pago efetivamente pelo banco (pagamento com jjuros)
                        If Me.fichafinanceira.cd_conta.Equals("3990") Then

                            Me.fichafinanceira.id_propriedade_matriz = Me.id_propriedade_matriz
                            Me.fichafinanceira.cd_conta = "1100" 'rendimento liquido base
                            'assume que a didferenca de custo será a base de rendimento liquido 1100 - o valor enviado pelo banco conta 3990 deste mes
                            lvalor = fichafinanceira.getFichaFinanceiraValorContaMesAnterior()
                            If lvalor > 0 Then
                                'Me.fichafinanceira.nr_valor_conta = fichafinanceira.getFichaFinanceiraValorContaMesAnterior() - Me.fichafinanceira.nr_valor_conta
                                Me.fichafinanceira.nr_valor_conta = lvalor - Me.fichafinanceira.nr_valor_conta
                                Me.fichafinanceira.cd_conta = "8990" 'diferenca do custo financeiro pago no mes anterior
                                Me.fichafinanceira.st_origem_conta = "C"

                                Me.fichafinanceira.insertFichaFinanceiraItens()

                            End If

                        End If
                        'fran 12/2021 - f

                    End If
                    ' fran 1/12/2010 - chamado 1066 - i
                    Me.fichafinanceira.id_central_pedido = 0
                    Me.fichafinanceira.id_central_pedido_desconto_produtor = 0
                    ' fran 1/12/2010 - chamado 1066 - f
                    'Fran 21/01/2011 i gko fase 2
                    Me.fichafinanceira.id_transportador = 0
                    'Fran 21/01/2011 f gko fase 2

                Next
            End If


        Catch err As Exception
            Throw New Exception(err.Message)
        End Try

    End Sub
    Public Sub calculoApurarDescontosCentral()

        ' 03/11/2009 - Rls22 Central de Compras - i
        Try

            ' Busca todas as parcelas da propriedade com vencimento na referencia
            Dim dsCalculoDescontosCentral As DataSet = Me.getCalculoDescontosCentral()
            Dim li As Int16 = 0

            If dsCalculoDescontosCentral.Tables(0).Rows.Count > 0 Then
                For li = 0 To dsCalculoDescontosCentral.Tables(0).Rows.Count - 1

                    Me.fichafinanceira.cd_conta = dsCalculoDescontosCentral.Tables(0).Rows(li).Item("cd_conta")    ' Código da Conta
                    Me.fichafinanceira.nr_valor_conta = dsCalculoDescontosCentral.Tables(0).Rows(li).Item("nr_valor_parcela")
                    Me.fichafinanceira.st_origem_conta = "S"  ' Central de Compras
                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                    Me.fichafinanceira.insertFichaFinanceiraItens()

                Next
            End If
            ' 03/11/2009 - Rls22 Central de Compras - f


        Catch err As Exception
            Throw New Exception(err.Message)
        End Try

    End Sub
    Public Sub calculoApurarContasParceladas()

        Try
            Dim contaparcelada As New ContaParcelada

            contaparcelada.dt_referencia_desconto_end = Me.dt_referencia_end
            contaparcelada.id_propriedade = Me.id_propriedade

            Dim dsCalculoContaParcelada As DataSet = getCalculoContasParceladas()

            Dim li As Int16 = 0

            If dsCalculoContaParcelada.Tables(0).Rows.Count > 0 Then
                For li = 0 To dsCalculoContaParcelada.Tables(0).Rows.Count - 1

                    Me.fichafinanceira.cd_conta = dsCalculoContaParcelada.Tables(0).Rows(li).Item("cd_conta")    ' Código da Conta
                    Me.fichafinanceira.nr_valor_conta = dsCalculoContaParcelada.Tables(0).Rows(li).Item("nr_valor_parcela")
                    Me.fichafinanceira.st_origem_conta = "I"
                    Me.fichafinanceira.st_tipo_pagamento = Me.st_tipo_pagamento
                    Me.fichafinanceira.insertFichaFinanceiraItens()
                    'fran 01/08/2016 i 
                    'If Me.st_tipo_pagamento = "M" then
                    If Me.st_pagamento = "D" AndAlso Me.st_tipo_pagamento = "M" Then  '22/07/2008 - Só grava dados na ms_conta_parcelada se for o Mensal
                        'fran 01/08/2016 f 
                        'Se ainda não descontou nenhuma parcela
                        If dsCalculoContaParcelada.Tables(0).Rows(li).Item("dt_referencia_desconto") Is DBNull.Value Then
                            contaparcelada.nr_qtd_parcela_descontada = 1
                            contaparcelada.dt_referencia_desconto = Me.dt_referencia
                            contaparcelada.id_conta_parcelada = dsCalculoContaParcelada.Tables(0).Rows(li).Item("id_conta_parcelada")
                            contaparcelada.updateCalculoContaParcelada()
                        Else
                            'Se ainda não descontou nesta referencia
                            If Convert.ToDateTime(dsCalculoContaParcelada.Tables(0).Rows(li).Item("dt_referencia_desconto")) < Convert.ToDateTime(Me.dt_referencia) Then
                                contaparcelada.nr_qtd_parcela_descontada = dsCalculoContaParcelada.Tables(0).Rows(li).Item("nr_qtd_parcela_descontada") + 1
                                contaparcelada.dt_referencia_desconto = Me.dt_referencia
                                contaparcelada.id_conta_parcelada = dsCalculoContaParcelada.Tables(0).Rows(li).Item("id_conta_parcelada")
                                contaparcelada.updateCalculoContaParcelada()
                            End If
                        End If
                    End If
                Next
            End If


        Catch err As Exception
            Throw New Exception(err.Message)
        End Try

    End Sub
    Public Function getCalculoLancamento() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            ' 12/01/2010 - Chamado 581 - Não trazer lançamentos desativados - i
            'data.Fill(dataSet, "ms_getLancamentos", parameters, "ms_lancamento")
            data.Fill(dataSet, "ms_getCalculoLancamento", parameters, "ms_lancamento")
            ' 12/01/2010 - Chamado 581 - Não trazer lançamentos desativados - f
            Return dataSet

        End Using
    End Function

    Public Function getCalculoStatusPagamentoReferencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoStatusPagamentoReferencia", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using
    End Function
    Public Function getCalculoContasParceladas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoContasParceladas", parameters, "ms_conta_parcelada")
            Return dataSet

        End Using
    End Function
    Public Function getCalculoDescontosCentral() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoDescontosCentral", parameters, "ms_central_pedido_desconto_produtor")
            Return dataSet

        End Using
    End Function
    Public Function getCalculoNumeroNotaFiscal() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoNumeroNotaFiscal", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Function getCalculoValorAdiantamento() As Decimal
        ' Adriana - 15/01/2009 - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoValorAdiantamento", parameters, ExecuteType.Select), Decimal)

        End Using
        ' Adriana - 15/01/2009 - f
    End Function
    ' 06/03/2012 - Projeto Themis - Processo de Cálculo unificado por IE - i
    Public Function getCalculoProdutorSelecionadoConsolidado() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoProdutorSelecionadoConsolidado", parameters, "ms_calculo_produtor")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoVolumeLeiteConsolidado() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoVolumeLeiteConsolidado", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    ' Adri - 11/07/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês - i
    Public Function getCalculoVolumeLeiteConsolidadoDefinitivo() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoVolumeLeiteConsolidadoDefinitivo", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    ' Adri - 11/07/2016 - chamado 2451 - Extrato Pagamento Produtor -  Volume de Leite entregue e não pago ao produtor no mês - f

    Public Function getCalculoStatusPagamentoConsolidado() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoStatusPagamentoConsolidado", parameters, ExecuteType.Select), String)

        End Using
    End Function
    ' 06/03/2012 - Projeto Themis - Processo de Cálculo unificado por IE - f
    Public Function getCalculoDefinitivoByPeriodo() As String 'fran 20/10/2015 i Poupança
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoDefinitivoByPeriodo", parameters, ExecuteType.Select), String)

        End Using
    End Function
    'fran 01/2016 i Atualizar ult ref de calculo efetuada para Bonus Poupança
    Public Sub updateCalculoPoupancaAdesao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCalculoPoupancaAdesao", parameters, ExecuteType.Update)

        End Using

    End Sub
    'fran 01/2016 f
End Class
