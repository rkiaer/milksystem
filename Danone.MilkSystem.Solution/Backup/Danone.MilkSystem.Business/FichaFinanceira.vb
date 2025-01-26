Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class FichaFinanceira

    Private _id_estabelecimento As Int32
    Private _id_propriedade As Int32
    Private _id_propriedade_matriz As Int32
    Private _id_unid_producao As Int32
    Private _dt_referencia As String
    Private _st_tipo_pagamento As String
    Private _id_modificador As Int32
    Private _cd_conta As String
    Private _nr_valor_conta As Decimal
    Private _nr_valor_12 As Decimal 'fran 03/2023
    Private _id_calculo_execucao As Int32
    Private _id_ficha_financeira As Int32
    Private _st_origem_conta As String
    Private _dt_referencia_ficha_start As String
    Private _dt_referencia_ficha_end As String
    Private _id_natureza As Int32
    Private _st_visualizar As String
    Private _st_pagamento As String
    Private _nm_arquivo As String
    Private _nr_linhaslidas As Int32
    Private _nr_linhasexportadas As Int32
    Private _id_portador As Int32
    Private _dt_processamento As String   ' 11/11/2008 - Exportar Adto
    Private _dt_vencimento As String      ' 11/11/2008 - Exportar Adto
    Private _nr_nota_fiscal As String     ' 18/11/2008
    Private _nr_serie As String           ' 18/11/2008
    Private _st_exportacao_nota As String '22/11/2008 - Exportar NF Produtor
    Private _id_grupo As Int32 '22/11/2008 - Exportar NF Produtor - grupo do produtor
    Private _st_emite_nota_fiscal As String '22/11/2008 - Exportar NF produtor emite nf
    Private _nr_nota_fiscal_ini As Decimal
    Private _nr_nota_fiscal_fim As Decimal
    Private _st_clube_compra As String  ' 20/08/2009 - Rls18 -  Corrigir calculo da conta 1000 para Extrato Pagamento Mensal Produtor
    Private _st_exportacao As String        ' 10/10/2009 - Rls 20 - Desconto ao Produtor
    Private _st_qtd_valor As String        ' 13/01/2010 - Rls 23 - Chamado 581
    Private _id_central_pedido As Int32     'Adriana 20/05/2010 - chamado 843
    Private _id_central_pedido_desconto_produtor As Int32     'fran 1/12/2010 - chamado 1066
    Private _id_transportador As Int32     'fran 21/01/2011 gko fase 2
    Private _id_pessoa As Int32     'fran dango 2018
    Private _id_tecnico As Int32     'fran dango 2018
    Private _cd_codigo_sap As String 'fran dango 2018
    Private _estabelecimentos As String
    Private _id_contrato_validade_pessoa As Int32 'fran 04/2022 flash
    Private _st_exportacao_nota_24 As String

    Public Property nr_valor_12() As Decimal
        Get
            Return _nr_valor_12
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_12 = value
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
    Public Property id_transportador() As Int32
        Get
            Return _id_transportador
        End Get
        Set(ByVal value As Int32)
            _id_transportador = value
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
    Public Property estabelecimentos() As String
        Get
            Return _estabelecimentos
        End Get
        Set(ByVal value As String)
            _estabelecimentos = value
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
    Public Property st_tipo_pagamento() As String
        Get
            Return _st_tipo_pagamento
        End Get
        Set(ByVal value As String)
            _st_tipo_pagamento = value
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
    
    Public Property cd_conta() As String
        Get
            Return _cd_conta
        End Get
        Set(ByVal value As String)
            _cd_conta = value
        End Set
    End Property

    Public Property nr_valor_conta() As Decimal
        Get
            Return _nr_valor_conta
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_conta = value
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
    Public Property id_ficha_financeira() As Int32
        Get
            Return _id_ficha_financeira
        End Get
        Set(ByVal value As Int32)
            _id_ficha_financeira = value
        End Set
    End Property
    Public Property id_grupo() As Int32
        Get
            Return _id_grupo
        End Get
        Set(ByVal value As Int32)
            _id_grupo = value
        End Set
    End Property


    Public Property st_emite_nota_fiscal() As String
        Get
            Return _st_emite_nota_fiscal
        End Get
        Set(ByVal value As String)
            _st_emite_nota_fiscal = value
        End Set
    End Property
    Public Property st_origem_conta() As String
        Get
            Return _st_origem_conta
        End Get
        Set(ByVal value As String)
            _st_origem_conta = value
        End Set
    End Property
    Public Property dt_referencia_ficha_start() As String
        Get
            Return _dt_referencia_ficha_start
        End Get
        Set(ByVal value As String)
            _dt_referencia_ficha_start = value
        End Set
    End Property
    Public Property dt_referencia_ficha_end() As String
        Get
            Return _dt_referencia_ficha_end
        End Get
        Set(ByVal value As String)
            _dt_referencia_ficha_end = value
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
    Public Property id_natureza() As Int32
        Get
            Return _id_natureza
        End Get
        Set(ByVal value As Int32)
            _id_natureza = value
        End Set
    End Property
    Public Property id_contrato_validade_pessoa() As Int32
        Get
            Return _id_contrato_validade_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_contrato_validade_pessoa = value
        End Set
    End Property
    Public Property st_visualizar() As String
        Get
            Return _st_visualizar
        End Get
        Set(ByVal value As String)
            _st_visualizar = value
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
    Public Property nm_arquivo() As String
        Get
            Return _nm_arquivo
        End Get
        Set(ByVal value As String)
            _nm_arquivo = value
        End Set
    End Property
    Public Property nr_linhaslidas() As Int32
        Get
            Return _nr_linhaslidas
        End Get
        Set(ByVal value As Int32)
            _nr_linhaslidas = value
        End Set
    End Property
    Public Property nr_linhasexportadas() As Int32
        Get
            Return _nr_linhasexportadas
        End Get
        Set(ByVal value As Int32)
            _nr_linhasexportadas = value
        End Set
    End Property
    Public Property id_portador() As Int32
        Get
            Return _id_portador
        End Get
        Set(ByVal value As Int32)
            _id_portador = value
        End Set
    End Property
    Public Property dt_processamento() As String
        Get
            Return _dt_processamento
        End Get
        Set(ByVal value As String)
            _dt_processamento = value
        End Set
    End Property
    Public Property dt_vencimento() As String
        Get
            Return _dt_vencimento
        End Get
        Set(ByVal value As String)
            _dt_vencimento = value
        End Set
    End Property
    Public Property nr_nota_fiscal() As String
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As String)
            _nr_nota_fiscal = value
        End Set
    End Property
    Public Property nr_serie() As String
        Get
            Return _nr_serie
        End Get
        Set(ByVal value As String)
            _nr_serie = value
        End Set
    End Property
    Public Property st_exportacao_nota() As String
        Get
            Return _st_exportacao_nota
        End Get
        Set(ByVal value As String)
            _st_exportacao_nota = value
        End Set
    End Property
    Public Property st_exportacao_nota_24() As String
        Get
            Return _st_exportacao_nota_24
        End Get
        Set(ByVal value As String)
            _st_exportacao_nota_24 = value
        End Set
    End Property
    Public Property nr_nota_fiscal_fim() As Decimal
        Get
            Return _nr_nota_fiscal_fim
        End Get
        Set(ByVal value As Decimal)
            _nr_nota_fiscal_fim = value
        End Set
    End Property
    Public Property nr_nota_fiscal_ini() As Decimal
        Get
            Return _nr_nota_fiscal_ini
        End Get
        Set(ByVal value As Decimal)
            _nr_nota_fiscal_ini = value
        End Set
    End Property
    Public Property st_clube_compra() As String
        Get
            Return _st_clube_compra
        End Get
        Set(ByVal value As String)
            _st_clube_compra = value
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
    Public Property st_qtd_valor() As String
        Get
            Return _st_qtd_valor
        End Get
        Set(ByVal value As String)
            _st_qtd_valor = value
        End Set
    End Property
    'Adriana 20/05/2010 - chamado 843 - i
    Public Property id_central_pedido() As Int32
        Get
            Return _id_central_pedido
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido = value
        End Set
    End Property
    'Adriana 20/05/2010 - chamado 843 - f

    Public Sub New()

    End Sub


    Public Function insertFichaFinanceira() As Int32


        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertFichaFinanceira", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertFichaFinanceiraItens() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertFichaFinanceiraItens", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function getFichaFinanceiraHeader() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFichaFinanceiraHeader", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getFichaFinanceiraByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFichaFinanceira", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getFichaRelatorio() As DataSet 'DANGO 2018

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFichaRelatorio", parameters, "ms_ficha_relatorio")
            Return dataSet

        End Using

    End Function
    Public Function getFlashFinanceiro() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFlashFinanceiro", parameters, "ms_ficha_financeiro")
            Return dataSet

        End Using

    End Function

    Public Function getFichaFinanceiraItens() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFichaFinanceiraItens", parameters, "ms_ficha_financeira_itens")
            Return dataSet

        End Using

    End Function
    Public Function getExportacaoAdtoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoAdto", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function

    Public Sub deleteFichaFinanceira()

        Dim transacao As New DataAccess
        transacao.StartTransaction()
        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_deleteFichaFinanceiraItens", parameters, ExecuteType.Delete)

            transacao.Execute("ms_deleteFichaFinanceira", parameters, ExecuteType.Delete)

            transacao.Commit()

        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try


    End Sub
    Public Function getFichaFinanceiraValorConta() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFichaFinanceiraValorConta", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getFichaFinanceiraValorContaMesAnterior() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFichaFinanceiraValorContaMesAnterior", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getFichaFinanceiraValorDescontosAntecipacao() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFichaFinanceiraValorDescontosAntecipacao", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getFichaFinanceiraValorBonusPoupanca() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFichaFinanceiraValorBonusPoupanca", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getFichaFinanceiraValorReposAntecipacao() As Decimal 'fran 02/2019
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFichaFinanceiraValorReposAntecipacao", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getAdiantamentoSequencia() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getAdiantamentoSequencia", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Sub exportDescontosProdutor()

        ' 10/09/2009 - Rls20 - Descontos ao Produtor - i
        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim li As Int32
            Dim linhatexto As String
            Dim liexportada As Int32
            Dim lpos As Int16

            Dim cd_estabelecimento As String
            Dim nr_serie As String
            Dim nr_docto As String
            Dim cd_pessoa As String
            Dim cd_conta_contabil As String
            Dim valor_desconto As String
            Dim valor_desconto_int As String
            Dim valor_desconto_dec As String
            Dim dt_emissao As Date

            Dim dsFichaFinanceira As DataSet = Me.getExportacaoDescontosProdutor()


            For li = 0 To dsFichaFinanceira.Tables(0).Rows.Count - 1

                ' Estabelecimento
                cd_estabelecimento = Left(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_estabelecimento"), 3)
                cd_estabelecimento = Left(StrDup(3 - Len(cd_estabelecimento), "0") + cd_estabelecimento, 3)
                linhatexto = cd_estabelecimento

                ' Número de Série
                nr_serie = Left(dsFichaFinanceira.Tables(0).Rows(li).Item("nr_serie"), 5)
                nr_serie = Left(nr_serie + StrDup(5 - Len(nr_serie), " "), 5)
                linhatexto = linhatexto + nr_serie

                ' Número de Nota Fiscal
                nr_docto = CStr(dsFichaFinanceira.Tables(0).Rows(li).Item("nr_nota_fiscal"))
                nr_docto = Left(StrDup(7 - Len(nr_docto), "0") + nr_docto, 7)  ' 16/09/2009 - Email Ricardo
                nr_docto = Left(nr_docto + StrDup(16 - Len(nr_docto), " "), 16)
                linhatexto = linhatexto + nr_docto

                ' Código do Produtor
                cd_pessoa = dsFichaFinanceira.Tables(0).Rows(li).Item("cd_pessoa")
                cd_pessoa = Left(StrDup(6 - Len(cd_pessoa), "0") + cd_pessoa, 6)
                linhatexto = linhatexto + cd_pessoa

                ' 07/10/2009 - Inlcluído o campo Espécie - i
                If dsFichaFinanceira.Tables(0).Rows(li).Item("st_categoria") = "F" Then  'Se pessoa Física
                    linhatexto = linhatexto + "DL"
                Else
                    linhatexto = linhatexto + "DJ"
                End If
                ' 07/10/2009 - Inlcluído o campo Espécie - f

                ' Conta Contábil
                If Not IsDBNull(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_conta_contabil")) Then
                    cd_conta_contabil = CStr(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_conta_contabil"))
                    cd_conta_contabil = Left(cd_conta_contabil + StrDup(16 - Len(cd_conta_contabil), " "), 16)
                Else
                    cd_conta_contabil = Space$(16)
                End If
                linhatexto = linhatexto + cd_conta_contabil

                ' Data de Emissão  (Soma 1 mes na referência e subtrai 1 dia)
                dt_emissao = DateAdd(DateInterval.Month, 1, CDate(Me.dt_referencia))
                dt_emissao = DateAdd(DateInterval.Day, -1, dt_emissao)
                linhatexto = linhatexto + DateTime.Parse(dt_emissao.ToString).ToString("ddMMyyyy")

                ' Data da Transação (mesma data que a da emissão)
                'linhatexto = linhatexto + DateTime.Parse(Now).ToString("ddMMyyyy")
                linhatexto = linhatexto + DateTime.Parse(dt_emissao.ToString).ToString("ddMMyyyy")   ' Solicitado em 24/09/2009

                valor_desconto = CStr(Abs(Round(dsFichaFinanceira.Tables(0).Rows(li).Item("totaldescontos"), 2)))
                lpos = InStr(1, valor_desconto, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    valor_desconto = CStr(valor_desconto)
                    'valor_desconto = Left(StrDup(13 - Len(valor_desconto), "0") + valor_desconto, 13)
                    valor_desconto = Left(StrDup(12 - Len(valor_desconto), "0") + valor_desconto, 12)
                    'valor_desconto = valor_desconto & "00"
                    valor_desconto = valor_desconto & "," & "00"  ' Solicitado pelo Ricardo via email em 22/09/2009
                Else
                    valor_desconto_int = CStr(Left(valor_desconto, lpos - 1))  ' Pegar somente o valor inteiro
                    'valor_desconto_int = Left(StrDup(13 - Len(valor_desconto_int), "0") + valor_desconto_int, 13)
                    valor_desconto_int = Left(StrDup(12 - Len(valor_desconto_int), "0") + valor_desconto_int, 12)
                    valor_desconto_dec = CStr(Mid(CStr(valor_desconto), lpos + 1))  ' Pegar somente o valor decimal
                    valor_desconto_dec = Left(valor_desconto_dec + StrDup(2 - Len(valor_desconto_dec), "0"), 2)
                    'valor_desconto = valor_desconto_int & valor_desconto_dec
                    valor_desconto = valor_desconto_int & "," & valor_desconto_dec  ' Solicitado pelo Ricardo via email em 22/09/2009
                End If
                linhatexto = linhatexto + valor_desconto ' Valor dos Descontos
 
                ' Conta Contábil  (solicitado em 24/09/2009)
                If Not IsDBNull(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_conta_contabil")) Then
                    If Left(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_conta_contabil"), 8) = "11309005" Then  ' 20/09/2009 (usar o left e não right)
                        linhatexto = linhatexto + "Desconto Insumos" + Space(64)
                    Else
                        linhatexto = linhatexto + "Desconto Educampo" + Space(63)
                    End If
                Else
                    linhatexto = linhatexto + Space(80)
                End If

                ArquivoTexto.WriteLine(linhatexto)

                ' 19/11/2008 - Atualiza Data e Status de Exportação
                Me.nr_serie = dsFichaFinanceira.Tables(0).Rows(li).Item("nr_serie")
                Me.nr_nota_fiscal = dsFichaFinanceira.Tables(0).Rows(li).Item("nr_nota_fiscal")
                Me.updateFichaFinanceiraExportacaoDescto()   ' Atualiza Status=S e data de exportacao

                liexportada = liexportada + 1

            Next

            Me.nr_linhaslidas = li
            Me.nr_linhasexportadas = liexportada


            ArquivoTexto.Close()

        Catch ex As Exception
            ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try
        ' 10/09/2009 - Rls20 - Descontos ao Produtor - f

    End Sub
    Public Sub exportFichaFinanceiraAdto()

        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim li As Int32
            Dim linhatexto As String
            Dim liexportada As Int32
            Dim lpos As Int16

            Dim cd_pessoa As String
            Dim cd_cnpj As String
            Dim valor_adto As String
            Dim valor_adto_int As String
            Dim valor_adto_dec As String
            Dim nr_sequencial As String

            Dim dsFichaFinanceira As DataSet = Me.getExportacaoAdtoByFilters()


            For li = 0 To dsFichaFinanceira.Tables(0).Rows.Count - 1
                linhatexto = "100"
                linhatexto = linhatexto + "001"
                linhatexto = linhatexto + dsFichaFinanceira.Tables(0).Rows(li).Item("cd_estabelecimento")     ' Confirmar Código do Estabelecimento EMS
                linhatexto = linhatexto + "AE"      ' 11/11/2008
                linhatexto = linhatexto + "     "   ' 11/11/2008 

                ' 11/11/2008  - i
                'linhatexto = linhatexto + Space(16)
                nr_sequencial = CStr(Me.getAdiantamentoSequencia())  ' Pega próxima sequencia para exportação
                nr_sequencial = Left(nr_sequencial + StrDup(16 - Len(nr_sequencial), " "), 16)
                linhatexto = linhatexto + nr_sequencial
                ' 11/11/2008  - f

                linhatexto = linhatexto + "01"

                cd_pessoa = dsFichaFinanceira.Tables(0).Rows(li).Item("cd_pessoa")
                cd_pessoa = Left(StrDup(9 - Len(cd_pessoa), "0") + cd_pessoa, 9)
                linhatexto = linhatexto + cd_pessoa

                linhatexto = linhatexto + "01"

                'linhatexto = linhatexto + Space(10) ' DDAAAAMMDD da emissão da NF
                linhatexto = linhatexto + "CPAG" + DateTime.Parse(Me.dt_referencia.ToString).ToString("yyyyMM") ' 11/11/2008

                linhatexto = linhatexto + DateTime.Parse(Me.dt_processamento.ToString).ToString("ddMMyyyy") ' 11/11/2008
                linhatexto = linhatexto + DateTime.Parse(Me.dt_processamento.ToString).ToString("ddMMyyyy") ' 11/11/2008
                linhatexto = linhatexto + DateTime.Parse(Me.dt_vencimento.ToString).ToString("ddMMyyyy") ' 11/11/2008

                ' 11/10/2008 - i
                'linhatexto = linhatexto + StrDup(12, "0") ' Valor do Saldo
                valor_adto = CStr(Round(dsFichaFinanceira.Tables(0).Rows(li).Item("valor_adto"), 2))
                lpos = InStr(1, valor_adto, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    valor_adto = CStr(valor_adto)
                    valor_adto = Left(StrDup(10 - Len(valor_adto), "0") + valor_adto, 10)
                    valor_adto = valor_adto & "00"
                Else
                    valor_adto_int = CStr(Left(valor_adto, lpos - 1))  ' Pegar somente o valor inteiro
                    valor_adto_int = Left(StrDup(10 - Len(valor_adto_int), "0") + valor_adto_int, 10)
                    valor_adto_dec = CStr(Mid(CStr(valor_adto), lpos + 1))  ' Pegar somente o valor decimal
                    valor_adto_dec = Left(valor_adto_dec + StrDup(2 - Len(valor_adto_dec), "0"), 2)
                    valor_adto = valor_adto_int & valor_adto_dec
                End If
                linhatexto = linhatexto + valor_adto ' Valor do Adiantamento
                ' 11/10/2008 - f

                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + StrDup(12, "0") ' Valor do Desconto

                valor_adto = CStr(Round(dsFichaFinanceira.Tables(0).Rows(li).Item("valor_adto"), 2))
                lpos = InStr(1, valor_adto, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    valor_adto = CStr(valor_adto)
                    valor_adto = Left(StrDup(10 - Len(valor_adto), "0") + valor_adto, 10)
                    valor_adto = valor_adto & "00"
                Else
                    valor_adto_int = CStr(Left(valor_adto, lpos - 1))  ' Pegar somente o valor inteiro
                    valor_adto_int = Left(StrDup(10 - Len(valor_adto_int), "0") + valor_adto_int, 10)
                    valor_adto_dec = CStr(Mid(CStr(valor_adto), lpos + 1))  ' Pegar somente o valor decimal
                    valor_adto_dec = Left(valor_adto_dec + StrDup(2 - Len(valor_adto_dec), "0"), 2)
                    valor_adto = valor_adto_int & valor_adto_dec
                End If
                linhatexto = linhatexto + valor_adto ' Valor do Adiantamento
                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + "11406001"
                linhatexto = linhatexto + StrDup(8, "0")
                linhatexto = linhatexto + "01"

                linhatexto = linhatexto + DateTime.Parse(Me.dt_vencimento.ToString).ToString("ddMMyyyy") ' 11/11/2008

                linhatexto = linhatexto + Space(12)
                linhatexto = linhatexto + "5"
                linhatexto = linhatexto + Space(80)

                'linhatexto = linhatexto + "88888"   
                linhatexto = linhatexto + dsFichaFinanceira.Tables(0).Rows(li).Item("nm_portador")   ' 11/11/2008

                linhatexto = linhatexto + "00"
                linhatexto = linhatexto + "01"
                linhatexto = linhatexto + "02"
                linhatexto = linhatexto + StrDup(9, "0")
                linhatexto = linhatexto + StrDup(8, "0")
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + "1"       ' 11/11/2008
                linhatexto = linhatexto + Space(2)
                linhatexto = linhatexto + Space(5)
                linhatexto = linhatexto + Space(16)
                linhatexto = linhatexto + Space(2)
                linhatexto = linhatexto + StrDup(4, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(13, "0")
                linhatexto = linhatexto + Space(60)
                linhatexto = linhatexto + Space(12)
                linhatexto = linhatexto + Space(40)
                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + StrDup(5, "0")
                linhatexto = linhatexto + StrDup(9, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(3, "0")
                linhatexto = linhatexto + StrDup(8, "0")
                linhatexto = linhatexto + StrDup(8, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + StrDup(13, "0")
                linhatexto = linhatexto + StrDup(13, "0")
                linhatexto = linhatexto + StrDup(17, "0")

                'CNPJ
                cd_cnpj = Trim(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_cnpj"))
                cd_cnpj = Left(cd_cnpj + StrDup(19 - Len(cd_cnpj), " "), 19)
                linhatexto = linhatexto + cd_cnpj

                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + "201"
                linhatexto = linhatexto + DateTime.Parse(Me.dt_vencimento.ToString).ToString("ddMMyyyy") ' 11/11/2008
                linhatexto = linhatexto + StrDup(3, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + StrDup(2, "0")
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + Space(20)
                linhatexto = linhatexto + StrDup(3, "0")
                linhatexto = linhatexto + StrDup(5, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + DateTime.Parse(Me.dt_vencimento.ToString).ToString("ddMMyyyy") ' 11/11/2008
                linhatexto = linhatexto + StrDup(7, "0")
                linhatexto = linhatexto + StrDup(5, "0")
                linhatexto = linhatexto + Space(20)
                linhatexto = linhatexto + StrDup(3, "0")
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + StrDup(13, "0")
                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + StrDup(6, "0")
                linhatexto = linhatexto + "08"          ' 11/11/2008
                linhatexto = linhatexto + Space(17)     ' 11/11/2008
                linhatexto = linhatexto + Space(17)
                linhatexto = linhatexto + StrDup(4, "0")
                linhatexto = linhatexto + StrDup(13, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(8, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + Space(6)  ' Seq 96
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + StrDup(1, "0")
                linhatexto = linhatexto + StrDup(10, "0")
                linhatexto = linhatexto + StrDup(15, "0")
                linhatexto = linhatexto + StrDup(11, "0")
                linhatexto = linhatexto + StrDup(11, "0")

                ' 11/11/2008 - i 
                'linhatexto = linhatexto + StrDup(15, "0")   ' Valor do desconto correspondente à espécie
                valor_adto = CStr(Round(dsFichaFinanceira.Tables(0).Rows(li).Item("valor_adto"), 2))
                lpos = InStr(1, valor_adto, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    valor_adto = CStr(valor_adto)
                    valor_adto = Left(StrDup(13 - Len(valor_adto), "0") + valor_adto, 13)
                    valor_adto = valor_adto & "00"
                Else
                    valor_adto_int = CStr(Left(valor_adto, lpos - 1))  ' Pegar somente o valor inteiro
                    valor_adto_int = Left(StrDup(13 - Len(valor_adto_int), "0") + valor_adto_int, 13)
                    valor_adto_dec = CStr(Mid(CStr(valor_adto), lpos + 1))  ' Pegar somente o valor decimal
                    valor_adto_dec = Left(valor_adto_dec + StrDup(2 - Len(valor_adto_dec), "0"), 2)
                    valor_adto = valor_adto_int & valor_adto_dec
                End If
                linhatexto = linhatexto + valor_adto ' Valor do Adiantamento
                ' 11/11/2008 - f 

                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(15, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(2, "0")    ' Seq 112
                linhatexto = linhatexto + Space(16)
                linhatexto = linhatexto + Space(2)
                linhatexto = linhatexto + StrDup(9, "0")
                linhatexto = linhatexto + Space(2)
                linhatexto = linhatexto + Space(5)
                linhatexto = linhatexto + StrDup(3, "0")
                linhatexto = linhatexto + Space(100)
                linhatexto = linhatexto + Space(100)
                linhatexto = linhatexto + StrDup(21, "0")
                linhatexto = linhatexto + StrDup(21, "0")
                linhatexto = linhatexto + StrDup(11, "0")
                linhatexto = linhatexto + StrDup(11, "0")
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + StrDup(3, "0")
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + Space(20)
                linhatexto = linhatexto + StrDup(3, "0")   ' Seq 133
                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + Space(20)
                linhatexto = linhatexto + Space(50)
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + Space(12)
                linhatexto = linhatexto + StrDup(5, "0")
                linhatexto = linhatexto + StrDup(3, "0")
                linhatexto = linhatexto + Space(2)
                linhatexto = linhatexto + Space(5)
                linhatexto = linhatexto + Space(16)
                linhatexto = linhatexto + Space(2)
                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + StrDup(3, "0")
                linhatexto = linhatexto + Space(12)
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(3, "0")
                linhatexto = linhatexto + Space(80)
                linhatexto = linhatexto + StrDup(3, "0")
                linhatexto = linhatexto + "N"               'Seq 162
                linhatexto = linhatexto + StrDup(3, "0")
                linhatexto = linhatexto + Space(80)
                linhatexto = linhatexto + StrDup(2, "0")
                linhatexto = linhatexto + Space(50)
                linhatexto = linhatexto + "02"              ' 12/11/2008
                linhatexto = linhatexto + StrDup(6, "0")
                linhatexto = linhatexto + StrDup(8, "0")
                linhatexto = linhatexto + StrDup(7, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + StrDup(12, "0")
                linhatexto = linhatexto + Space(16)         ' 11/11/2008


                ArquivoTexto.WriteLine(linhatexto)

                liexportada = liexportada + 1

            Next

            Me.nr_linhaslidas = li
            Me.nr_linhasexportadas = liexportada


            ArquivoTexto.Close()

        Catch ex As Exception
            ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Sub
    Public Sub updateFichaFinanceiraDefinitivo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFichaFinanceiraDefinitivo", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub atualizarFichaRelatorio()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFichaRelatorio", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateFichaFinanceiraExportacaoNF()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFichaFinanceiraExportacaoNF", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateFichaFinanceiraExportacaoNF_CreditoICMS24()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFichaFinanceiraExportacaoNFCreditoICMS24", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getCalculoResumoProdutor() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoResumoProdutor", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoResumoCooperativa() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoResumoCooperativa", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getFichaFinanceiraTotalDescontos() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFichaFinanceiraTotalDescontos", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getFichaFinanceiraContasDescontos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFichaFinanceiraContasDescontos", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getFichaFinanceiraCountNota() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFichaFinanceiraCountNota", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function

    Public Function getMediaAcidezbyReferenciaRomaneio() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getMediaAcidezbyReferenciaRomaneio", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Sub updateFichaFinanceiraNF()

        ' Chamado 243 28/04/2009 - Rls 17.5 - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFichaFinanceiraNF", parameters, ExecuteType.Update)

        End Using
        ' Chamado 243 28/04/2009 - Rls 17.5 - f

    End Sub
    Public Function getExportacaoDescontosProdutor() As DataSet

        ' 10/09/2009 - Rls20 - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoDescontosProdutor", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using
        ' 10/09/2009 - Rls20 - f

    End Function
    Public Sub updateFichaFinanceiraExportacaoDescto()

        ' 14/09/2009 - Rls20 - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFichaFinanceiraExportacaoDescto", parameters, ExecuteType.Update)

        End Using
        ' 14/09/2009 - Rls20 - i

    End Sub
    ' 07/03/2012 - Projeto Themis - Processo de Cálculo unificado por IE - i
    Public Function getCalculoValorContaPonderado() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoValorContaPonderado", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function

    ' 07/03/2012 - Projeto Themis - Processo de Cálculo unificado por IE - f
    ' 09/03/2012 - Projeto Themis - Exportar Drescontos ao Produtor para o SAP - i
    Public Sub exportDescontosProdutorSAP()

        ' 14/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - i
        'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo, False, utf8WithoutBom)
        ' 14/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - f

        Try

            Dim li As Int32
            Dim linhatexto As String
            Dim liexportada As Int32
            Dim lpos As Int16

            Dim cd_estabelecimento As String
            Dim nr_serie As String
            Dim nr_docto As String
            Dim cd_pessoa As String
            Dim cd_conta_contabil As String
            Dim valor_desconto As String
            Dim valor_desconto_int As String
            Dim valor_desconto_dec As String
            Dim dt_emissao As Date

            Dim dsFichaFinanceira As DataSet = Me.getExportacaoDescontosProdutorSAP()


            For li = 0 To dsFichaFinanceira.Tables(0).Rows.Count - 1

                ' Estabelecimento
                'cd_estabelecimento = Left(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_estabelecimento"), 3)
                cd_estabelecimento = Left(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_estabelecimento_sap").ToString, 4) ' 09/03/2012 -Projeto Themis
                'cd_estabelecimento = Left(StrDup(3 - Len(cd_estabelecimento), "0") + cd_estabelecimento, 3)  
                cd_estabelecimento = Left(StrDup(4 - Len(cd_estabelecimento), "0") + cd_estabelecimento, 4)  ' 09/03/2012 -Projeto Themis
                linhatexto = cd_estabelecimento

                ' Número de Série
                nr_serie = Left(dsFichaFinanceira.Tables(0).Rows(li).Item("nr_serie"), 5)
                nr_serie = Left(nr_serie + StrDup(5 - Len(nr_serie), " "), 5)
                linhatexto = linhatexto + nr_serie

                ' Número de Nota Fiscal
                nr_docto = CStr(dsFichaFinanceira.Tables(0).Rows(li).Item("nr_nota_fiscal"))
                nr_docto = Left(StrDup(7 - Len(nr_docto), "0") + nr_docto, 7)
                nr_docto = Left(nr_docto + StrDup(16 - Len(nr_docto), " "), 16)
                linhatexto = linhatexto + nr_docto

                ' Código do Produtor
                'cd_pessoa = dsFichaFinanceira.Tables(0).Rows(li).Item("cd_pessoa")
                cd_pessoa = dsFichaFinanceira.Tables(0).Rows(li).Item("cd_pessoa_sap").ToString  ' 09/03/2012 -Projeto Themis
                'cd_pessoa = Left(StrDup(6 - Len(cd_pessoa), "0") + cd_pessoa, 6)
                cd_pessoa = Left(StrDup(10 - Len(cd_pessoa), "0") + cd_pessoa, 10)
                linhatexto = linhatexto + cd_pessoa

                ' 09/03/2012 -Projeto Themis (desabilitado) - i
                '' 07/10/2009 - Inlcluído o campo Espécie - i
                'If dsFichaFinanceira.Tables(0).Rows(li).Item("st_categoria") = "F" Then  'Se pessoa Física
                '    linhatexto = linhatexto + "DL"
                'Else
                '    linhatexto = linhatexto + "DJ"
                'End If
                '' 07/10/2009 - Inlcluído o campo Espécie - f
                ' 09/03/2012 -Projeto Themis (desabilitado) - f

                ' Conta Contábil
                If Not IsDBNull(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_conta_contabil")) Then
                    cd_conta_contabil = CStr(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_conta_contabil"))
                    cd_conta_contabil = Left(cd_conta_contabil + StrDup(16 - Len(cd_conta_contabil), " "), 16)
                Else
                    cd_conta_contabil = Space$(16)
                End If
                linhatexto = linhatexto + cd_conta_contabil

                ' Data de Emissão  (Soma 1 mes na referência e subtrai 1 dia)
                dt_emissao = DateAdd(DateInterval.Month, 1, CDate(Me.dt_referencia))
                dt_emissao = DateAdd(DateInterval.Day, -1, dt_emissao)
                linhatexto = linhatexto + DateTime.Parse(dt_emissao.ToString).ToString("ddMMyyyy")

                ' Data da Transação (mesma data que a da emissão)
                'linhatexto = linhatexto + DateTime.Parse(Now).ToString("ddMMyyyy")
                linhatexto = linhatexto + DateTime.Parse(dt_emissao.ToString).ToString("ddMMyyyy")   ' Solicitado em 24/09/2009

                valor_desconto = CStr(Abs(Round(dsFichaFinanceira.Tables(0).Rows(li).Item("totaldescontos"), 2)))
                lpos = InStr(1, valor_desconto, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    valor_desconto = CStr(valor_desconto)
                    valor_desconto = Left(StrDup(12 - Len(valor_desconto), "0") + valor_desconto, 12)
                    valor_desconto = valor_desconto & "," & "00"  ' Solicitado pelo Ricardo via email em 22/09/2009
                Else
                    valor_desconto_int = CStr(Left(valor_desconto, lpos - 1))  ' Pegar somente o valor inteiro
                    valor_desconto_int = Left(StrDup(12 - Len(valor_desconto_int), "0") + valor_desconto_int, 12)
                    valor_desconto_dec = CStr(Mid(CStr(valor_desconto), lpos + 1))  ' Pegar somente o valor decimal
                    valor_desconto_dec = Left(valor_desconto_dec + StrDup(2 - Len(valor_desconto_dec), "0"), 2)
                    valor_desconto = valor_desconto_int & "," & valor_desconto_dec  ' Solicitado pelo Ricardo via email em 22/09/2009
                End If
                linhatexto = linhatexto + valor_desconto ' Valor dos Descontos

                ' Conta Contábil  (solicitado em 24/09/2009)
                If Not IsDBNull(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_conta_contabil")) Then
                    If Left(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_conta_contabil"), 8) = "11309005" Then  ' 20/09/2009 (usar o left e não right)
                        linhatexto = linhatexto + "Desconto Insumos" + Space(64)
                    Else
                        linhatexto = linhatexto + "Desconto Educampo" + Space(63)
                    End If
                Else
                    linhatexto = linhatexto + Space(80)
                End If

                ArquivoTexto.WriteLine(linhatexto)

                ' 19/11/2008 - Atualiza Data e Status de Exportação
                Me.nr_serie = dsFichaFinanceira.Tables(0).Rows(li).Item("nr_serie")
                Me.nr_nota_fiscal = dsFichaFinanceira.Tables(0).Rows(li).Item("nr_nota_fiscal")
                Me.updateFichaFinanceiraExportacaoDescto()   ' Atualiza Status=S e data de exportacao

                liexportada = liexportada + 1

            Next

            Me.nr_linhaslidas = li
            Me.nr_linhasexportadas = liexportada


            ArquivoTexto.Close()

        Catch ex As Exception
            ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Sub
    Public Function getExportacaoDescontosProdutorSAP() As DataSet

        ' 10/09/2009 - Rls20 - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoDescontosProdutorSAP", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using
        ' 10/09/2009 - Rls20 - f

    End Function
    Public Function getFichaFinanceiraHeaderSAP() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFichaFinanceiraHeaderSAP", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getFichaFinanceiraCreditoICMS24SAP() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFichaFinanceiraCreditoICMS24SAP", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    ' 09/03/2012 - Projeto Themis - Exportar Drescontos ao Produtor para o SAP - f

    ' adri 06/03/2013 Chamado 1678 (Seta status para 'D' - Definitivo somente se o cálculo foi executado até o fim) - i
    Public Sub updateFichaFinanceiraDefinitivobyUnidadeProducao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFichaFinanceiraDefinitivoByUnidadeProducao", parameters, ExecuteType.Update)

        End Using

    End Sub
    ' adri 06/03/2013 Chamado 1678 (Seta status para 'D' - Definitivo somente se o cálculo foi executado até o fim) - i
    Public Function getFichaFinanceiraVolumeLeite() As Decimal 'fran 09/2016 poupança traz o somatorio do volume de leite por periodo das conta 0010 e 0011
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFichaFinanceiraVolumeLeite", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function

    Public Function getFichaFinanceiraVolumeLeitebyGrupo() As Decimal 'fran 09/2016 poupança traz o somatorio do volume de leite por periodo das conta 0010 e 0011
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getFichaFinanceiraVolumeLeitebyGrupo", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function

End Class
