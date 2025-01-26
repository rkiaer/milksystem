Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class PedidoPagtoFornecedor

    ' Adri - i
    Private _id_central_pedido_pagto_fornecedor As Int32
    Private _id_central_pedido_item As Int32
    Private _id_central_pedido_notas As Int32
    Private _id_central_pedido As Int32
    Private _dt_referencia As String
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _dt_processamento As String
    Private _dt_vencimento As String
    Private _nm_portador As String
    Private _nm_arquivo As String
    Private _st_exportacao As String
    Private _nr_linhaslidas As Int32
    Private _nr_linhasexportadas As Int32
    ' Adri - f
    Private _nr_parcela As Int32
    Private _id_estabelecimento As Int32 'fran 31/05/2010 i chamado 818
    Private _id_modificador As Int32
    Private _nr_nota_fiscal As Int32
    Private _nr_valor_nota_fiscal As Decimal
    Private _dt_pagto As String
    Private _dt_acerto As String
    Private _nr_serie_nota_fiscal As String
    Private _dt_emissao_nota_fiscal As String
    Private _nr_valor_parcela As Decimal
    Private _cd_erro As String 'fran 31/05/2010 i chamado 818
    Private _nm_erro As String 'fran 31/05/2010 i chamado 818
    Private _st_natureza_operacao As String 'fran 31/05/2010 i chamado 818
    Private _st_item As String 'fran 31/05/2010 i chamado 818
    Private _id_situacao As Int32 'fran 19/10/2010 chamado 860 item 7
    Private _id_fornecedor As Int32 'fran 27/09/2013
    Private _st_tipo_pagto As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
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
    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
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
    Public Property dt_acerto() As String
        Get
            Return _dt_acerto
        End Get
        Set(ByVal value As String)
            _dt_acerto = value
        End Set
    End Property
    Public Property dt_emissao_nota_fiscal() As String
        Get
            Return _dt_emissao_nota_fiscal
        End Get
        Set(ByVal value As String)
            _dt_emissao_nota_fiscal = value
        End Set
    End Property
    Public Property nr_serie_nota_fiscal() As String
        Get
            Return _nr_serie_nota_fiscal
        End Get
        Set(ByVal value As String)
            _nr_serie_nota_fiscal = value
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
    Public Property nr_valor_nota_fiscal() As Decimal
        Get
            Return _nr_valor_nota_fiscal
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nota_fiscal = value
        End Set
    End Property
    Public Property nr_nota_fiscal() As Int32
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As Int32)
            _nr_nota_fiscal = value
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
    Public Property id_central_pedido() As Int32
        Get
            Return _id_central_pedido
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido = value
        End Set
    End Property
    Public Property id_central_pedido_notas() As Int32
        Get
            Return _id_central_pedido_notas
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_notas = value
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
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
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

    Public Property nm_portador() As String
        Get
            Return _nm_portador
        End Get
        Set(ByVal value As String)
            _nm_portador = value
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
    Public Property st_exportacao() As String
        Get
            Return _st_exportacao
        End Get
        Set(ByVal value As String)
            _st_exportacao = value
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
    Public Property cd_erro() As String
        Get
            Return _cd_erro
        End Get
        Set(ByVal value As String)
            _cd_erro = value
        End Set
    End Property
    Public Property nm_erro() As String
        Get
            Return _nm_erro
        End Get
        Set(ByVal value As String)
            _nm_erro = value
        End Set
    End Property
    Public Property st_natureza_operacao() As String
        Get
            Return _st_natureza_operacao
        End Get
        Set(ByVal value As String)
            _st_natureza_operacao = value
        End Set
    End Property
    Public Property st_item() As String
        Get
            Return _st_item
        End Get
        Set(ByVal value As String)
            _st_item = value
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
    Public Property st_tipo_pagto() As String
        Get
            Return _st_tipo_pagto
        End Get
        Set(ByVal value As String)
            _st_tipo_pagto = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_central_pedido_pagto_fornecedor = id
        loadPedidoPagtoFornecedor()

    End Sub

    Public Sub New()

    End Sub

    Public Function exportPagtoFornecedor() As Boolean
        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim li As Int32
            Dim linhatexto As String
            Dim liexportada As Int32

            Dim dsnaturezaoperacao As DataSet
            Dim dsitem As DataSet

            linhatexto = ""

            'BUSCA DADOS NATUREZA OPERACAO
            Dim naturezaoperacao As New NaturezaOperacao
            naturezaoperacao.cd_natureza_operacao = "4100AA"
            naturezaoperacao.id_situacao = 1 'ativa
            dsnaturezaoperacao = naturezaoperacao.getNaturezaOperacoesByFilters
            If dsnaturezaoperacao.Tables(0).Rows.Count = 0 Then
                Me.st_natureza_operacao = "N"
                exportPagtoFornecedor = False
            Else
                Me.st_natureza_operacao = "S"
            End If

            'BUSCA DADOS ITEM
            Dim item As New Item
            item.cd_item = "41242005"
            item.id_situacao = 1 'ativa
            'fran chamado 943 - a procedure getitens força st_central_compras = 'N' não trazendo o item
            'dsitem = item.getItensByFilters
            dsitem = item.getItensCentralByFilters
            'fran chamado 943 f

            If dsitem.Tables(0).Rows.Count = 0 Then
                exportPagtoFornecedor = False
                Me.st_item = "N"
            Else
                Me.st_item = "S"
            End If

            'se tem cadastro de natureza de operacao e de item
            If Me.st_item = "S" And Me.st_natureza_operacao = "S" Then
                'BUSCA as propriedades queserao exportadas de acordo com o filtro
                Dim dsNotaFiscal As DataSet = Me.getCentralPedidoPagtoFornecedorExportacao()

                'Para cada propriedade/produtor/unid producao
                For li = 0 To dsNotaFiscal.Tables(0).Rows.Count - 1

                    Me.id_central_pedido_item = dsNotaFiscal.Tables(0).Rows(li).Item("id_central_pedido_item").ToString
                    Me.id_central_pedido_pagto_fornecedor = dsNotaFiscal.Tables(0).Rows(li).Item("id_central_pedido_pagto_fornecedor").ToString

                    'Buscando Dados

                    '====================================================================================
                    ' Registro Tipo 1
                    '====================================================================================
                    linhatexto = PagtoFornecedor_Registro_1(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0))
                    ArquivoTexto.WriteLine(linhatexto)
                    linhatexto = ""


                    '====================================================================================
                    ' Registro Tipo 2
                    '====================================================================================
                    linhatexto = PagtoFornecedor_Registro_2(dsNotaFiscal.Tables(0).Rows(li).Item("nr_valor_nota_fiscal").ToString, dsNotaFiscal.Tables(0).Rows(li).Item("id_item").ToString, dsNotaFiscal.Tables(0).Rows(li).Item("id_central_pedido").ToString, dsNotaFiscal.Tables(0).Rows(li).Item("dt_pedido").ToString, dsnaturezaoperacao.Tables(0).Rows(0), dsitem.Tables(0).Rows(0))
                    ArquivoTexto.WriteLine(linhatexto)
                    linhatexto = ""

                    '====================================================================================
                    ' Registro Tipo 3  - Duplicatas
                    '====================================================================================

                    linhatexto = PagtoFornecedor_Registro_3(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0))
                    ArquivoTexto.WriteLine(linhatexto)
                    linhatexto = ""


                    liexportada = liexportada + 1

                Next
            End If
            Me.nr_linhaslidas = li
            Me.nr_linhasexportadas = liexportada
            'Se exportou todas as linhas lidas
            If liexportada > 0 Then
                ' Atualiza Data e Status de Exportação de todas as parcelas do mes para todos os fornecedores
                Me.updateCentralPedidoPagtoFornecedorExportacao()   ' Atualiza Status=S e data de exportacao
                exportPagtoFornecedor = True
            Else
                exportPagtoFornecedor = False
                Me.cd_erro = "Sem Linhas"
            End If
            ArquivoTexto.Close()



        Catch ex As Exception
            exportPagtoFornecedor = False
            Me.nm_erro = ex.Message
            Me.cd_erro = "Exception"
            Me.insertCentralExportacaoPagtoFornecedorErro()
            ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    ''Public Sub exportPagtoFornecedor() 'fran 31/05/2010 chamado 818
    ''    Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

    ''    Try

    ''        Dim li As Int32
    ''        Dim linhatexto As String
    ''        Dim liexportada As Int32 = 0
    ''        Dim lpos As Int16

    ''        Dim cd_pessoa As String
    ''        Dim cd_cnpj As String
    ''        Dim valor_parcelas As String
    ''        Dim valor_parcelas_int As String
    ''        Dim valor_parcelas_dec As String
    ''        Dim nr_sequencial As String

    ''        Dim dsCentralPedidoPagtoFornecedor As DataSet = Me.getCentralPedidoPagtoFornecedorExportacao()


    ''        For li = 0 To dsCentralPedidoPagtoFornecedor.Tables(0).Rows.Count - 1
    ''            linhatexto = "100"
    ''            linhatexto = linhatexto + "001"
    ''            linhatexto = linhatexto + dsCentralPedidoPagtoFornecedor.Tables(0).Rows(li).Item("cd_estabelecimento")     ' Confirmar Código do Estabelecimento EMS
    ''            linhatexto = linhatexto + "AE"
    ''            linhatexto = linhatexto + "     "

    ''            'linhatexto = linhatexto + Space(16)
    ''            nr_sequencial = CStr(Me.getPagtoFornecedorSequencia())  ' Pega próxima sequencia para exportação
    ''            nr_sequencial = Left(nr_sequencial + StrDup(16 - Len(nr_sequencial), " "), 16)
    ''            linhatexto = linhatexto + nr_sequencial

    ''            linhatexto = linhatexto + "01"

    ''            cd_pessoa = dsCentralPedidoPagtoFornecedor.Tables(0).Rows(li).Item("cd_pessoa")
    ''            cd_pessoa = Left(StrDup(9 - Len(cd_pessoa), "0") + cd_pessoa, 9)
    ''            linhatexto = linhatexto + cd_pessoa

    ''            linhatexto = linhatexto + "01"

    ''            'linhatexto = linhatexto + Space(10) ' DDAAAAMMDD da emissão da NF
    ''            linhatexto = linhatexto + "CPAG" + DateTime.Parse(Me.dt_referencia.ToString).ToString("yyyyMM") ' 11/11/2008

    ''            linhatexto = linhatexto + DateTime.Parse(Me.dt_processamento.ToString).ToString("ddMMyyyy") ' 11/11/2008
    ''            linhatexto = linhatexto + DateTime.Parse(Me.dt_processamento.ToString).ToString("ddMMyyyy") ' 11/11/2008
    ''            linhatexto = linhatexto + DateTime.Parse(Me.dt_vencimento.ToString).ToString("ddMMyyyy") ' 11/11/2008

    ''            valor_parcelas = CStr(Round(dsCentralPedidoPagtoFornecedor.Tables(0).Rows(li).Item("nr_valor_parcela"), 2))
    ''            lpos = InStr(1, valor_parcelas, ",", 1)
    ''            If lpos = 0 Then   ' Se não tem casas decimais
    ''                valor_parcelas = CStr(valor_parcelas)
    ''                valor_parcelas = Left(StrDup(10 - Len(valor_parcelas), "0") + valor_parcelas, 10)
    ''                valor_parcelas = valor_parcelas & "00"
    ''            Else
    ''                valor_parcelas_int = CStr(Left(valor_parcelas, lpos - 1))  ' Pegar somente o valor inteiro
    ''                valor_parcelas_int = Left(StrDup(10 - Len(valor_parcelas_int), "0") + valor_parcelas_int, 10)
    ''                valor_parcelas_dec = CStr(Mid(CStr(valor_parcelas), lpos + 1))  ' Pegar somente o valor decimal
    ''                valor_parcelas_dec = Left(valor_parcelas_dec + StrDup(2 - Len(valor_parcelas_dec), "0"), 2)
    ''                valor_parcelas = valor_parcelas_int & valor_parcelas_dec
    ''            End If
    ''            linhatexto = linhatexto + valor_parcelas ' Somatório das parcelas

    ''            linhatexto = linhatexto + Space(8)
    ''            linhatexto = linhatexto + Space(8)
    ''            linhatexto = linhatexto + Space(8)
    ''            linhatexto = linhatexto + StrDup(12, "0") ' Valor do Desconto

    ''            valor_parcelas = CStr(Round(dsCentralPedidoPagtoFornecedor.Tables(0).Rows(li).Item("nr_valor_parcela"), 2))
    ''            lpos = InStr(1, valor_parcelas, ",", 1)
    ''            If lpos = 0 Then   ' Se não tem casas decimais
    ''                valor_parcelas = CStr(valor_parcelas)
    ''                valor_parcelas = Left(StrDup(10 - Len(valor_parcelas), "0") + valor_parcelas, 10)
    ''                valor_parcelas = valor_parcelas & "00"
    ''            Else
    ''                valor_parcelas_int = CStr(Left(valor_parcelas, lpos - 1))  ' Pegar somente o valor inteiro
    ''                valor_parcelas_int = Left(StrDup(10 - Len(valor_parcelas_int), "0") + valor_parcelas_int, 10)
    ''                valor_parcelas_dec = CStr(Mid(CStr(valor_parcelas), lpos + 1))  ' Pegar somente o valor decimal
    ''                valor_parcelas_dec = Left(valor_parcelas_dec + StrDup(2 - Len(valor_parcelas_dec), "0"), 2)
    ''                valor_parcelas = valor_parcelas_int & valor_parcelas_dec
    ''            End If
    ''            linhatexto = linhatexto + valor_parcelas ' Somatória das parcelas do mes
    ''            linhatexto = linhatexto + Space(8)
    ''            linhatexto = linhatexto + "11406001"
    ''            linhatexto = linhatexto + StrDup(8, "0")
    ''            linhatexto = linhatexto + "01"

    ''            linhatexto = linhatexto + DateTime.Parse(Me.dt_vencimento.ToString).ToString("ddMMyyyy") ' 11/11/2008

    ''            linhatexto = linhatexto + Space(12)
    ''            linhatexto = linhatexto + "5"
    ''            linhatexto = linhatexto + Space(80)

    ''            'linhatexto = linhatexto + "88888"   
    ''            'linhatexto = linhatexto + dsCentralPedidoPagtoFornecedor.Tables(0).Rows(li).Item("nm_portador")   ' 11/11/2008
    ''            linhatexto = linhatexto + Left(Me.nm_portador, 5)

    ''            linhatexto = linhatexto + "00"
    ''            linhatexto = linhatexto + "01"
    ''            linhatexto = linhatexto + "02"
    ''            linhatexto = linhatexto + StrDup(9, "0")
    ''            linhatexto = linhatexto + StrDup(8, "0")
    ''            linhatexto = linhatexto + "N"
    ''            linhatexto = linhatexto + "N"
    ''            linhatexto = linhatexto + "1"       ' 11/11/2008
    ''            linhatexto = linhatexto + Space(2)
    ''            linhatexto = linhatexto + Space(5)
    ''            linhatexto = linhatexto + Space(16)
    ''            linhatexto = linhatexto + Space(2)
    ''            linhatexto = linhatexto + StrDup(4, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(14, "0")
    ''            linhatexto = linhatexto + StrDup(13, "0")
    ''            linhatexto = linhatexto + Space(60)
    ''            linhatexto = linhatexto + Space(12)
    ''            linhatexto = linhatexto + Space(40)
    ''            linhatexto = linhatexto + Space(8)
    ''            linhatexto = linhatexto + StrDup(5, "0")
    ''            linhatexto = linhatexto + StrDup(9, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(3, "0")
    ''            linhatexto = linhatexto + StrDup(8, "0")
    ''            linhatexto = linhatexto + StrDup(8, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + "N"
    ''            linhatexto = linhatexto + "N"
    ''            linhatexto = linhatexto + StrDup(13, "0")
    ''            linhatexto = linhatexto + StrDup(13, "0")
    ''            linhatexto = linhatexto + StrDup(17, "0")

    ''            'CNPJ
    ''            cd_cnpj = Trim(dsCentralPedidoPagtoFornecedor.Tables(0).Rows(li).Item("cd_cnpj"))
    ''            cd_cnpj = Left(cd_cnpj + StrDup(19 - Len(cd_cnpj), " "), 19)
    ''            linhatexto = linhatexto + cd_cnpj

    ''            linhatexto = linhatexto + StrDup(14, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + "201"
    ''            linhatexto = linhatexto + DateTime.Parse(Me.dt_vencimento.ToString).ToString("ddMMyyyy") ' 11/11/2008
    ''            linhatexto = linhatexto + StrDup(3, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + Space(8)
    ''            linhatexto = linhatexto + StrDup(2, "0")
    ''            linhatexto = linhatexto + "N"
    ''            linhatexto = linhatexto + Space(20)
    ''            linhatexto = linhatexto + StrDup(3, "0")
    ''            linhatexto = linhatexto + StrDup(5, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + DateTime.Parse(Me.dt_vencimento.ToString).ToString("ddMMyyyy") ' 11/11/2008
    ''            linhatexto = linhatexto + StrDup(7, "0")
    ''            linhatexto = linhatexto + StrDup(5, "0")
    ''            linhatexto = linhatexto + Space(20)
    ''            linhatexto = linhatexto + StrDup(3, "0")
    ''            linhatexto = linhatexto + "N"
    ''            linhatexto = linhatexto + StrDup(13, "0")
    ''            linhatexto = linhatexto + Space(8)
    ''            linhatexto = linhatexto + "N"
    ''            linhatexto = linhatexto + StrDup(6, "0")
    ''            linhatexto = linhatexto + "08"          ' 11/11/2008
    ''            linhatexto = linhatexto + Space(17)     ' 11/11/2008
    ''            linhatexto = linhatexto + Space(17)
    ''            linhatexto = linhatexto + StrDup(4, "0")
    ''            linhatexto = linhatexto + StrDup(13, "0")
    ''            linhatexto = linhatexto + StrDup(14, "0")
    ''            linhatexto = linhatexto + StrDup(8, "0")
    ''            linhatexto = linhatexto + StrDup(14, "0")
    ''            linhatexto = linhatexto + Space(6)  ' Seq 96
    ''            linhatexto = linhatexto + "N"
    ''            linhatexto = linhatexto + StrDup(1, "0")
    ''            linhatexto = linhatexto + StrDup(10, "0")
    ''            linhatexto = linhatexto + StrDup(15, "0")
    ''            linhatexto = linhatexto + StrDup(11, "0")
    ''            linhatexto = linhatexto + StrDup(11, "0")

    ''            valor_parcelas = CStr(Round(dsCentralPedidoPagtoFornecedor.Tables(0).Rows(li).Item("nr_valor_parcela"), 2))
    ''            lpos = InStr(1, valor_parcelas, ",", 1)
    ''            If lpos = 0 Then   ' Se não tem casas decimais
    ''                valor_parcelas = CStr(valor_parcelas)
    ''                valor_parcelas = Left(StrDup(13 - Len(valor_parcelas), "0") + valor_parcelas, 13)
    ''                valor_parcelas = valor_parcelas & "00"
    ''            Else
    ''                valor_parcelas_int = CStr(Left(valor_parcelas, lpos - 1))  ' Pegar somente o valor inteiro
    ''                valor_parcelas_int = Left(StrDup(13 - Len(valor_parcelas_int), "0") + valor_parcelas_int, 13)
    ''                valor_parcelas_dec = CStr(Mid(CStr(valor_parcelas), lpos + 1))  ' Pegar somente o valor decimal
    ''                valor_parcelas_dec = Left(valor_parcelas_dec + StrDup(2 - Len(valor_parcelas_dec), "0"), 2)
    ''                valor_parcelas = valor_parcelas_int & valor_parcelas_dec
    ''            End If
    ''            linhatexto = linhatexto + valor_parcelas ' Somatório das parcelas

    ''            linhatexto = linhatexto + StrDup(14, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(14, "0")
    ''            linhatexto = linhatexto + StrDup(15, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(14, "0")
    ''            linhatexto = linhatexto + StrDup(14, "0")
    ''            linhatexto = linhatexto + StrDup(2, "0")    ' Seq 112
    ''            linhatexto = linhatexto + Space(16)
    ''            linhatexto = linhatexto + Space(2)
    ''            linhatexto = linhatexto + StrDup(9, "0")
    ''            linhatexto = linhatexto + Space(2)
    ''            linhatexto = linhatexto + Space(5)
    ''            linhatexto = linhatexto + StrDup(3, "0")
    ''            linhatexto = linhatexto + Space(100)
    ''            linhatexto = linhatexto + Space(100)
    ''            linhatexto = linhatexto + StrDup(21, "0")
    ''            linhatexto = linhatexto + StrDup(21, "0")
    ''            linhatexto = linhatexto + StrDup(11, "0")
    ''            linhatexto = linhatexto + StrDup(11, "0")
    ''            linhatexto = linhatexto + "N"
    ''            linhatexto = linhatexto + "N"
    ''            linhatexto = linhatexto + Space(8)
    ''            linhatexto = linhatexto + Space(8)
    ''            linhatexto = linhatexto + StrDup(3, "0")
    ''            linhatexto = linhatexto + "N"
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + Space(20)
    ''            linhatexto = linhatexto + StrDup(3, "0")   ' Seq 133
    ''            linhatexto = linhatexto + Space(8)
    ''            linhatexto = linhatexto + Space(20)
    ''            linhatexto = linhatexto + Space(50)
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + "N"
    ''            linhatexto = linhatexto + Space(12)
    ''            linhatexto = linhatexto + StrDup(5, "0")
    ''            linhatexto = linhatexto + StrDup(3, "0")
    ''            linhatexto = linhatexto + Space(2)
    ''            linhatexto = linhatexto + Space(5)
    ''            linhatexto = linhatexto + Space(16)
    ''            linhatexto = linhatexto + Space(2)
    ''            linhatexto = linhatexto + Space(8)
    ''            linhatexto = linhatexto + StrDup(3, "0")
    ''            linhatexto = linhatexto + Space(12)
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(3, "0")
    ''            linhatexto = linhatexto + Space(80)
    ''            linhatexto = linhatexto + StrDup(3, "0")
    ''            linhatexto = linhatexto + "N"               'Seq 162
    ''            linhatexto = linhatexto + StrDup(3, "0")
    ''            linhatexto = linhatexto + Space(80)
    ''            linhatexto = linhatexto + StrDup(2, "0")
    ''            linhatexto = linhatexto + Space(50)
    ''            linhatexto = linhatexto + "02"              ' 12/11/2008
    ''            linhatexto = linhatexto + StrDup(6, "0")
    ''            linhatexto = linhatexto + StrDup(8, "0")
    ''            linhatexto = linhatexto + StrDup(7, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + StrDup(12, "0")
    ''            linhatexto = linhatexto + Space(16)         ' 11/11/2008


    ''            ArquivoTexto.WriteLine(linhatexto)

    ''            '' Atualiza Data e Status de Exportação
    ''            'Me.id_central_pedido_pagto_fornecedor = dsCentralPedidoPagtoFornecedor.Tables(0).Rows(li).Item("id_central_pedido_pagto_fornecedor")
    ''            'Me.updateCentralPedidoPagtoFornecedorExportacao()   ' Atualiza Status=S e data de exportacao

    ''            liexportada = liexportada + 1

    ''        Next

    ''        'Se exportou todas as linhas lidas
    ''        If liexportada > 0 And liexportada = dsCentralPedidoPagtoFornecedor.Tables(0).Rows.Count Then
    ''            ' Atualiza Data e Status de Exportação de todas as parcelas do mes para todos os fornecedores
    ''            Me.updateCentralPedidoPagtoFornecedorExportacao()   ' Atualiza Status=S e data de exportacao

    ''        End If

    ''        Me.nr_linhaslidas = li
    ''        Me.nr_linhasexportadas = liexportada


    ''        ArquivoTexto.Close()

    ''    Catch ex As Exception
    ''        ArquivoTexto.Close()
    ''        Throw New Exception(ex.Message)

    ''    End Try

    ''End Sub
    Public Function getCentralPedidoPagtoFornecedorExportacao() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoPagtoFornecedorExportacao", parameters, "ms_central_pedido_pagto_fornecedor")
            Return dataSet

        End Using

    End Function

    Public Function getCentralPedidoPagtoFornecedorNotas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoPagtoFornecedorNotas", parameters, "ms_central_pedido_pagto_fornecedor")
            Return dataSet

        End Using

    End Function

    Public Function getPagtoTransportadorExportacao() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPagtoTransportadorExportacao", parameters, "ms_pagto_transportador")
            Return dataSet

        End Using

    End Function
    Public Function getPagtoFornecedorSequencia() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getPagtoFornecedorSequencia", parameters, ExecuteType.Select), Int32)

        End Using
    End Function

    Public Function getPagtoFornecedorMaxParcela() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralPedidoPagtoFornecedorMaxParcela", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Sub updateCentralPedidoPagtoFornecedorExportacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoPagtoFornecedorExportacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralPedidoPagtoFornecedorExportacaoSAP() 'fran 04/2016

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoPagtoFornecedorExportacaoSAP", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePagtoTransportadorExportacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePagtoTransportadorExportacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Private Sub loadPedidoPagtoFornecedor()

        Dim dataSet As DataSet = getPedidoPagtoFornecedorByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertPedidoCentralPagtoFornecedor() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralPedidoPagtoFornecedor", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertCentralExportacaoPagtoFornecedorErro() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralExportacaoPagtoFornecedorErro", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updatePedidoPagtoFornecedor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoPagtoFornecedor", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePedidoPagtoFornecedorAcerto()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralPedidoPagtoFornecedorAcerto", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub deletePedidoPagtoFornecedor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralPedidoPagtoFornecedor", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function getPedidoPagtoFornecedorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoPagtoFornecedor", parameters, "ms_central_pedido_pagto_fornecedor")
            Return dataSet

        End Using

    End Function
    Private Function PagtoFornecedor_Registro_1(ByVal pRegistro As DataRow, ByVal pdsNaturezaOperacao As DataRow) As String

        'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim linhatexto As String
            Dim lpos As Int16

            ' Registro 1
            Dim cd_registro As String
            Dim numero_notafiscal As String
            Dim nr_nota_fiscal_formatado As String
            Dim serie_notafiscal As String
            Dim cd_emitente As String
            Dim cd_natureza_operacao As String
            Dim cd_estabelecimento As String
            Dim cd_estabelecimento_fiscal As String
            Dim conta_contabil As String
            Dim dt_emissao As String
            Dim dt_transacao As String
            Dim cd_uf As String
            Dim cd_frete As String
            Dim nr_valor As String
            Dim peso_total As String
            Dim total_descontos As String
            Dim valor_mercadoria As String
            Dim valor_total_nota As String
            Dim nr_valor_int As String
            Dim nr_valor_dec As String
            Dim especie_nf As String
            Dim usuario_responsavel As String
            Dim obs As String

            Dim usuario As New Usuario(Me.id_modificador)

            linhatexto = ""

            '====================================================================================
            ' Registro Tipo 1
            '====================================================================================

            cd_registro = "1"  ' Registro tipo 1

            If IsDBNull(pRegistro.Item("nr_serie_nota_fiscal")) Then
                serie_notafiscal = Space(5)
            Else
                serie_notafiscal = pRegistro.Item("nr_serie_nota_fiscal")
                serie_notafiscal = Left(serie_notafiscal + StrDup(5 - Len(serie_notafiscal), " "), 5)
            End If

            nr_nota_fiscal_formatado = CStr(pRegistro.Item("nr_nota_fiscal"))
            'nr_nota_fiscal_formatado = Left(StrDup(7 - Len(nr_nota_fiscal_formatado), "0") + nr_nota_fiscal_formatado, 7)
            nr_nota_fiscal_formatado = Left(StrDup(9 - Len(nr_nota_fiscal_formatado), "0") + nr_nota_fiscal_formatado, 9)
            numero_notafiscal = Left(nr_nota_fiscal_formatado + StrDup(16 - Len(nr_nota_fiscal_formatado), " "), 16)
            'numero_notafiscal = Left(nr_nota_fiscal_formatado + StrDup(14 - Len(nr_nota_fiscal_formatado), " "), 14)


            cd_emitente = pRegistro.Item("cd_fornecedor")
            cd_emitente = Left(StrDup(6 - Len(cd_emitente), "0") + cd_emitente, 6)

            cd_natureza_operacao = "4100AA"

            cd_estabelecimento = Space(3)
            cd_estabelecimento = pRegistro.Item("cd_estabelecimento_produtor")
            cd_estabelecimento = Left(cd_estabelecimento + StrDup(3 - Len(cd_estabelecimento), " "), 3)

            cd_estabelecimento_fiscal = cd_estabelecimento

            'Preciso saber qual o cd_natureza_operacao para depois buscar conta contabil no cadastro
            conta_contabil = Left(pdsNaturezaOperacao.Item("nr_conta_transitoria").ToString + StrDup(17, " "), 17)


            'Data de emissão - ultimo dia do mês de referencia
            dt_emissao = DateTime.Parse(pRegistro.Item("dt_pedido").ToString).ToString("ddMMyyyy")
            dt_transacao = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateTime.Parse(Me.dt_referencia.ToString))).ToString("ddMMyyyy")

            usuario_responsavel = usuario.ds_login
            usuario_responsavel = Left(usuario_responsavel + StrDup(12 - Len(usuario_responsavel), " "), 12)

            If IsDBNull(pRegistro.Item("cd_uf").ToString) Then 'cdUf do fornecedor
                cd_uf = Space(4)
            Else
                cd_uf = pRegistro.Item("cd_uf").ToString
                cd_uf = Left(cd_uf + StrDup(4 - Len(cd_uf), " "), 4)
            End If

            cd_frete = "01"

            peso_total = "00000000000000"

            total_descontos = "0000000000000"

            nr_valor = CStr(pRegistro.Item("nr_valor_nota_fiscal").ToString)
            If nr_valor.Equals(String.Empty) Then
                nr_valor = "0"
            End If

            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(10 - Len(nr_valor), "0") + nr_valor, 10)
                nr_valor = nr_valor & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(11 - Len(nr_valor_int), "0") + nr_valor_int, 11)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            valor_mercadoria = nr_valor 'nr valor total da nota nr_valor_nota_fiscal

            valor_total_nota = String.Concat("00", nr_valor)  'valor total da nota

            especie_nf = "21"
            obs = Space(2000)

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = cd_registro + serie_notafiscal + numero_notafiscal + cd_emitente
            linhatexto = linhatexto + cd_natureza_operacao + "4" + cd_estabelecimento + cd_estabelecimento_fiscal
            linhatexto = linhatexto + conta_contabil + dt_emissao + dt_transacao + usuario_responsavel
            linhatexto = linhatexto + cd_uf + "1" + cd_frete + "nao" + peso_total
            linhatexto = linhatexto + total_descontos
            linhatexto = linhatexto + StrDup(13, "0")
            linhatexto = linhatexto + StrDup(13, "0")
            linhatexto = linhatexto + StrDup(13, "0")
            linhatexto = linhatexto + StrDup(13, "0")
            linhatexto = linhatexto + valor_mercadoria + dt_emissao + dt_emissao
            linhatexto = linhatexto + valor_total_nota + "2" + especie_nf
            linhatexto = linhatexto + "0"
            linhatexto = linhatexto + obs
            linhatexto = linhatexto + Space(12)
            linhatexto = linhatexto + Space(7)
            linhatexto = linhatexto + Space(7)
            linhatexto = linhatexto + Space(7)
            linhatexto = linhatexto + Space(2)
            linhatexto = linhatexto + Space(2)
            linhatexto = linhatexto + Space(2)
            linhatexto = linhatexto + Space(60)
            linhatexto = linhatexto + "0"

            PagtoFornecedor_Registro_1 = formatarTexto(linhatexto)

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try

    End Function
    Private Function PagtoFornecedor_Registro_2(ByVal pValorTotalNotaFiscal As String, ByVal pIdItem As String, ByVal pIdCentralPedido As String, ByVal pDtPedido As String, ByVal pdsNaturezaOperacao As DataRow, ByVal pdsItem As DataRow) As String


        Try

            Dim linhatexto As String
            Dim lpos As Int16
            Dim cd_registro As String
            Dim nr_valor As String
            Dim nr_valor_int As String
            Dim nr_valor_dec As String

            ' Registro 2
            Dim cd_item As String
            Dim qtde_med_emitente As String
            Dim qtde_med_nossa As String
            Dim preco_total_item As String
            Dim peso_liquido As String
            Dim cd_classificacao_fiscal As String
            Dim nr_aliquota_ipi As String
            Dim nr_tributacao_ipi As String
            Dim base_calculo_ipi As String
            Dim valor_ipi As String
            Dim nr_aliquota_icms As String
            Dim nr_tributacao_icms As String
            Dim base_calculo_icms As String
            Dim valor_icms As String
            Dim valor_icms_outras As String
            Dim valor_ipi_outras As String
            Dim valor_icms_isento As String
            Dim valor_ipi_isento As String
            Dim narrativa As String
            Dim valor_aliquota_icms As Decimal

            Dim item As New Item(Convert.ToInt32(pIdItem))

            linhatexto = ""


            '====================================================================================
            ' Registro Tipo 2
            '====================================================================================
            linhatexto = ""
            cd_registro = "2"  ' Registro tipo 1

            cd_item = "41242005"
            cd_item = Left(cd_item + StrDup(16 - Len(cd_item), " "), 16)

            qtde_med_emitente = "00000000000000"

            qtde_med_nossa = "000000000000"

            ' 10 inteiros e 2 decimais (campo 16)
            nr_valor = CStr(pValorTotalNotaFiscal)

            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(10 - Len(nr_valor), "0") + nr_valor, 10)
                nr_valor = nr_valor & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), "0") + nr_valor_int, 10)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            preco_total_item = nr_valor 'valor total da nota informado na linha pagto fornecedor

            peso_liquido = "000000000000"   ' Peso Líquido

            cd_classificacao_fiscal = Left(pdsItem.Item("cd_classificacao_fiscal").ToString, 8)
            cd_classificacao_fiscal = Left(cd_classificacao_fiscal + StrDup(8 - Len(cd_classificacao_fiscal), " "), 8)

            ' Aliquota IPI
            ' 3 inteiros e 2 decimais (campo 26)
            If IsDBNull(pdsNaturezaOperacao.Item("nr_aliquota_ipi")) Then
                nr_valor = 0
            Else
                nr_valor = CStr(pdsNaturezaOperacao.Item("nr_aliquota_ipi"))
            End If
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(3 - Len(nr_valor), "0") + nr_valor, 3)
                nr_valor = nr_valor & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(3 - Len(nr_valor_int), "0") + nr_valor_int, 3)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            nr_aliquota_ipi = nr_valor

            'id_tributacao_ipi
            nr_tributacao_ipi = converteCodigoTributacao(pdsNaturezaOperacao.Item("id_tributacao_ipi"))
            nr_tributacao_ipi = Left(StrDup(2 - Len(nr_tributacao_ipi), "0") + nr_tributacao_ipi, 2)

            'Se ipi = 1 Tributado
            If nr_tributacao_ipi = "01" Then
                ' 10 inteiros e 2 decimais (campo 28)
                base_calculo_ipi = preco_total_item ' Preço Total (Base IPI)

                ' 10 inteiros e 2 decimais (campo 29) Valor IPI
                'base_calculo_ipi * nr_aliquota_ipi
                If IsDBNull(pdsNaturezaOperacao.Item("nr_aliquota_ipi")) Then
                    nr_valor = "0"
                Else
                    nr_valor = pdsNaturezaOperacao.Item("nr_aliquota_ipi")
                End If
                nr_valor = CStr(Round(CDbl(pValorTotalNotaFiscal) * CDbl(nr_valor), 2))
                lpos = InStr(1, nr_valor, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    nr_valor = CStr(nr_valor)
                    nr_valor = Left(StrDup(10 - Len(nr_valor), "0") + nr_valor, 10)
                    nr_valor = nr_valor & "00"
                Else
                    nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                    nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), "0") + nr_valor_int, 10)
                    nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                    nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                    nr_valor = nr_valor_int & nr_valor_dec
                End If
                valor_ipi = nr_valor
            Else
                base_calculo_ipi = StrDup(12, "0")
                valor_ipi = StrDup(12, "0")
            End If

            ' Aliquota ICMS
            ' 3 inteiros e 2 decimais (campo 26)
            If IsDBNull(pdsNaturezaOperacao.Item("nr_aliquota_icms")) Then
                nr_valor = 0
                valor_aliquota_icms = 0
            Else
                nr_valor = CStr(pdsNaturezaOperacao.Item("nr_aliquota_icms"))
                valor_aliquota_icms = Convert.ToDecimal(pdsNaturezaOperacao.Item("nr_aliquota_icms"))
            End If
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(3 - Len(nr_valor), "0") + nr_valor, 3)
                nr_valor = nr_valor & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(3 - Len(nr_valor_int), "0") + nr_valor_int, 3)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            nr_aliquota_icms = nr_valor

            ' id_tributacao_icms
            nr_tributacao_icms = converteCodigoTributacao(pdsNaturezaOperacao.Item("id_tributacao_icms"))
            nr_tributacao_icms = Left(StrDup(2 - Len(nr_tributacao_icms), "0") + nr_tributacao_icms, 2)


            ' 10 inteiros e 2 decimais (campo 36)
            base_calculo_icms = preco_total_item     ' Preço Total (Base ICMS)

            'Calcula ICMS
            nr_valor = CStr(Round(CDbl(pValorTotalNotaFiscal) * CDbl(valor_aliquota_icms), 2))
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(10 - Len(nr_valor), "0") + nr_valor, 10)
                nr_valor = nr_valor & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), "0") + nr_valor_int, 10)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            valor_icms = nr_valor     ' ICMS

            'Narrativa campo 42
            narrativa = "DAL" & Space(115)
            'fran 02/08/2012 i pagto transportador de frete - Se não tem pedido da central não envia dados danarrativa
            If pIdCentralPedido.ToString.Equals(String.Empty) Then
                narrativa = narrativa & "Pagto de Frete ao Transportador" & Space(109 - 31)
            Else
                'fran 02/08/2012 f
                narrativa = narrativa & "Central de Compras" & Space(109 - 18)
                narrativa = narrativa & "Número do Pedido: " & pIdCentralPedido.ToString & Space(109 - 18 - Len(pIdCentralPedido.ToString))
                nr_valor = DateTime.Parse(pDtPedido.ToString).ToString("dd/MM/yyyy")
                narrativa = narrativa & "Data do Pedido: " & nr_valor & Space(109 - 16 - Len(nr_valor))
                narrativa = narrativa & "Código do Item: " & item.cd_item.ToString & Space(109 - 16 - Len(item.cd_item.ToString))

            End If

            narrativa = Left(narrativa & Space(2000 - Len(narrativa)), 2000)

            'Se icms = 3 Outros 
            If nr_tributacao_icms = "03" Then
                ' 10 inteiros e 2 decimais (campo 48)
                valor_icms_outras = preco_total_item 'valor total da nota
            Else
                valor_icms_outras = StrDup(12, "0")
            End If
            'Se ipi = 3 Outros
            If nr_tributacao_ipi = "03" Then
                ' 10 inteiros e 2 decimais (campo 50)
                valor_ipi_outras = preco_total_item
            Else
                valor_ipi_outras = StrDup(12, "0")
            End If
            'Se icms = 2 Isento
            If nr_tributacao_icms = "02" Then
                ' 10 inteiros e 2 decimais (campo 51)
                valor_icms_isento = preco_total_item
            Else
                valor_icms_isento = StrDup(12, "0")
            End If
            'Se ipi = 2 isento
            If nr_tributacao_ipi = "02" Then
                ' 10 inteiros e 2 decimais (campo 52)
                valor_ipi_isento = preco_total_item
            Else
                valor_ipi_isento = StrDup(12, "0")
            End If

            linhatexto = linhatexto + cd_registro + cd_item
            linhatexto = linhatexto + Space(8) + StrDup(8, "0") + StrDup(5, "0")
            linhatexto = linhatexto + "nao" + StrDup(9, "0") + Space(16)
            linhatexto = linhatexto + StrDup(4, "0") + Space(16) + Space(17)
            linhatexto = linhatexto + "nao" + StrDup(3, "0")
            linhatexto = linhatexto + qtde_med_emitente + qtde_med_nossa + preco_total_item
            linhatexto = linhatexto + StrDup(12, "0") + StrDup(12, "0") + StrDup(12, "0")
            linhatexto = linhatexto + peso_liquido + Space(3) + Space(10) + Space(10)
            linhatexto = linhatexto + "31122999" + cd_classificacao_fiscal
            linhatexto = linhatexto + nr_aliquota_ipi + nr_tributacao_ipi + base_calculo_ipi + valor_ipi
            linhatexto = linhatexto + StrDup(5, "0") + "03"
            linhatexto = linhatexto + StrDup(12, "0") + StrDup(12, "0")
            linhatexto = linhatexto + nr_aliquota_icms + nr_tributacao_icms + base_calculo_icms + valor_icms
            linhatexto = linhatexto + StrDup(13, "0") + StrDup(13, "0") + StrDup(12, "0")
            linhatexto = linhatexto + "nao" + narrativa + Space(5) + Space(16) + Space(6)
            linhatexto = linhatexto + "010" + StrDup(8, "0") + valor_icms_outras + valor_ipi_outras
            linhatexto = linhatexto + StrDup(12, "0") + valor_icms_isento + valor_ipi_isento + StrDup(12, "0")

            PagtoFornecedor_Registro_2 = formatarTexto(linhatexto)
        Catch ex As Exception
            '   ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    Private Function PagtoFornecedor_Registro_3(ByVal pRegistro As DataRow, ByVal pdsNaturezaOperacao As DataRow) As String


        Try

            Dim linhatexto As String
            Dim lpos As Int16
            Dim nr_valor As String
            Dim nr_valor_int As String
            Dim nr_valor_dec As String

            ' Registro 3
            Dim cd_registro As String 'campo 1
            Dim nr_parcela As String  'campo 2
            Dim nr_duplicata As String  'campo 3
            Dim tp_especie As String    'campo 4
            Dim dt_vencto As String     'campo 6

            linhatexto = ""

            '====================================================================================
            ' Registro Tipo 3  - Duplicatas
            '====================================================================================

            linhatexto = ""

            cd_registro = "3"
            nr_parcela = Left(pRegistro.Item("nr_parcela").ToString & Space(2), 2)

            nr_duplicata = CStr(pRegistro.Item("nr_nota_fiscal"))
            'nr_duplicata = Left(StrDup(7 - Len(nr_duplicata), "0") + nr_duplicata, 7)
            nr_duplicata = Left(StrDup(9 - Len(nr_duplicata), "0") + nr_duplicata, 9)
            nr_duplicata = Left(nr_duplicata + StrDup(16 - Len(nr_duplicata), " "), 16)
            'nr_duplicata = Left(StrDup(9 - Len(nr_duplicata), "0") + nr_duplicata, 9)
            'nr_duplicata = Left(nr_duplicata + StrDup(14 - Len(nr_duplicata), " "), 14)

            'If pRegistro("st_categoria") = "F" Then
            'tp_especie = "DL"
            'Else
            'tp_especie = "DJ"
            'End If
            tp_especie = Left(String.Concat(pdsNaturezaOperacao.Item("ds_tipo_especie").ToString, Space(2)), 2)

            dt_vencto = DateTime.Parse(pRegistro.Item("dt_pagto")).ToString("ddMMyyyy")

            nr_valor = CStr(Round(Convert.ToDecimal(pRegistro.Item("nr_valor_parcela")), 2))
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(11 - Len(nr_valor), "0") + nr_valor, 11)
                nr_valor = nr_valor & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(11 - Len(nr_valor_int), "0") + nr_valor_int, 11)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & nr_valor_dec
            End If

            linhatexto = linhatexto + cd_registro + nr_parcela + nr_duplicata
            linhatexto = linhatexto + tp_especie + "210" + dt_vencto + nr_valor
            linhatexto = linhatexto + StrDup(13, "0") + Space(8)
            linhatexto = linhatexto + StrDup(5, "0")

            PagtoFornecedor_Registro_3 = linhatexto

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try

    End Function
    Private Function converteCodigoTributacao(ByVal id_tributacao As Int32) As String

        Select Case id_tributacao
            Case 1, 5 'Diferido ou Outros
                converteCodigoTributacao = "3"
            Case 2 'Isento
                converteCodigoTributacao = "2"
            Case 3 'Reduzido
                converteCodigoTributacao = "4"
            Case 4 'Tributado
                converteCodigoTributacao = "1"
            Case Else
                converteCodigoTributacao = "3"
        End Select

    End Function
    Private Function formatarTexto(ByVal texto As String) As String
        Try
            Dim ltexto As String

            ltexto = texto

            ltexto = Replace(ltexto, "á", "a")
            ltexto = Replace(ltexto, "à", "a")
            ltexto = Replace(ltexto, "ã", "a")
            ltexto = Replace(ltexto, "â", "a") 'Fran chamado 840 20/05/2010
            ltexto = Replace(ltexto, "Á", "A")
            ltexto = Replace(ltexto, "À", "A")
            ltexto = Replace(ltexto, "Ã", "A")
            ltexto = Replace(ltexto, "Â", "A") 'Fran chamado 840 20/05/2010
            ltexto = Replace(ltexto, "é", "e")
            ltexto = Replace(ltexto, "ê", "e")
            ltexto = Replace(ltexto, "É", "E")
            ltexto = Replace(ltexto, "Ê", "E")
            ltexto = Replace(ltexto, "í", "i")
            ltexto = Replace(ltexto, "Í", "I")
            ltexto = Replace(ltexto, "ó", "o")
            ltexto = Replace(ltexto, "ô", "o")
            ltexto = Replace(ltexto, "õ", "o")
            ltexto = Replace(ltexto, "Ó", "O")
            ltexto = Replace(ltexto, "Ô", "O")
            ltexto = Replace(ltexto, "Õ", "O")
            ltexto = Replace(ltexto, "ú", "u")
            ltexto = Replace(ltexto, "Ú", "U")
            ltexto = Replace(ltexto, "ü", "u")
            ltexto = Replace(ltexto, "Ü", "U")
            ltexto = Replace(ltexto, "'", " ")
            ltexto = Replace(ltexto, "ç", "c")
            ltexto = Replace(ltexto, "Ç", "C")
            ltexto = Replace(ltexto, ",", " ")


            formatarTexto = ltexto
        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
    End Function
    ' 08/03/2012 adri - Projeto Themis - i 
    Public Function exportPagtoFornecedorSAP() As Boolean

        ' 14/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - i
        'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo, False, utf8WithoutBom)
        ' 14/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - f

        Try

            Dim li As Int32
            Dim linhatexto As String
            Dim liexportada As Int32

            Dim dsnaturezaoperacao As DataSet
            Dim dsitem As DataSet
            Dim liexportada_transportador As Int32 = 0 'fran 03/08/2012

            linhatexto = ""

            'BUSCA DADOS NATUREZA OPERACAO
            Dim naturezaoperacao As New NaturezaOperacao
            naturezaoperacao.cd_natureza_operacao = "4100AA"
            naturezaoperacao.id_situacao = 1 'ativa
            dsnaturezaoperacao = naturezaoperacao.getNaturezaOperacoesByFilters
            If dsnaturezaoperacao.Tables(0).Rows.Count = 0 Then
                Me.st_natureza_operacao = "N"
                exportPagtoFornecedorSAP = False
            Else
                Me.st_natureza_operacao = "S"
            End If

            'BUSCA DADOS ITEM
            Dim item As New Item
            item.cd_item = "41242005"
            item.id_situacao = 1 'ativa
            dsitem = item.getItensCentralByFilters

            If dsitem.Tables(0).Rows.Count = 0 Then
                exportPagtoFornecedorSAP = False
                Me.st_item = "N"
            Else
                Me.st_item = "S"
            End If

            'se tem cadastro de natureza de operacao e de item
            If Me.st_item = "S" And Me.st_natureza_operacao = "S" Then
                'BUSCA as propriedades queserao exportadas de acordo com o filtro
                Dim dsNotaFiscal As DataSet = Me.getCentralPedidoPagtoFornecedorExportacao()
                'Para cada propriedade/produtor/unid producao
                For li = 0 To dsNotaFiscal.Tables(0).Rows.Count - 1

                    Me.id_central_pedido_item = dsNotaFiscal.Tables(0).Rows(li).Item("id_central_pedido_item").ToString
                    Me.id_central_pedido_pagto_fornecedor = dsNotaFiscal.Tables(0).Rows(li).Item("id_central_pedido_pagto_fornecedor").ToString
                    'Buscando Dados
                    '====================================================================================
                    ' Registro Tipo 1
                    '====================================================================================
                    'linhatexto = PagtoFornecedor_Registro_1(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0))
                    linhatexto = PagtoFornecedor_Registro_1_SAP(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0))
                    ArquivoTexto.WriteLine(linhatexto)
                    linhatexto = ""
                    '====================================================================================
                    ' Registro Tipo 2
                    '====================================================================================
                    'fran 30/09/2013 fase 1
                    'linhatexto = PagtoFornecedor_Registro_2(dsNotaFiscal.Tables(0).Rows(li).Item("nr_valor_nota_fiscal").ToString, dsNotaFiscal.Tables(0).Rows(li).Item("id_item").ToString, dsNotaFiscal.Tables(0).Rows(li).Item("id_central_pedido").ToString, dsNotaFiscal.Tables(0).Rows(li).Item("dt_pedido").ToString, dsnaturezaoperacao.Tables(0).Rows(0), dsitem.Tables(0).Rows(0))
                    linhatexto = PagtoFornecedor_Registro_2(dsNotaFiscal.Tables(0).Rows(li).Item("nr_valor_parcela").ToString, dsNotaFiscal.Tables(0).Rows(li).Item("id_item").ToString, dsNotaFiscal.Tables(0).Rows(li).Item("id_central_pedido").ToString, dsNotaFiscal.Tables(0).Rows(li).Item("dt_pedido").ToString, dsnaturezaoperacao.Tables(0).Rows(0), dsitem.Tables(0).Rows(0))
                    'fran 30/09/2013 fase 1
                    ArquivoTexto.WriteLine(linhatexto)
                    linhatexto = ""
                    '====================================================================================
                    ' Registro Tipo 3  - Duplicatas
                    '====================================================================================
                    linhatexto = PagtoFornecedor_Registro_3(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0))
                    ArquivoTexto.WriteLine(linhatexto)
                    linhatexto = ""

                    liexportada = liexportada + 1

                    'fra 05/2016
                    'atualiza exportação sap 
                    Me.updateCentralPedidoPagtoFornecedorExportacaoSAP()   ' Atualiza Status=S e data de exportacao e data_exportacao_1vez

                Next
                '02/08/2012 i Fran - Envia dados tb da improtação de pagamento de frete ao transportador
                'BUSCA as propriedades queserao exportadas de acordo com o filtro
                Dim dspagtotransp As DataSet = Me.getPagtoTransportadorExportacao()
                'Para cada transportador
                For li = 0 To dspagtotransp.Tables(0).Rows.Count - 1

                    Me.id_central_pedido_item = 0
                    Me.id_central_pedido_pagto_fornecedor = 0
                    'Buscando Dados
                    '====================================================================================
                    ' Registro Tipo 1
                    '====================================================================================
                    linhatexto = PagtoFornecedor_Registro_1_SAP(dspagtotransp.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0))
                    ArquivoTexto.WriteLine(linhatexto)
                    linhatexto = ""
                    '====================================================================================
                    ' Registro Tipo 2
                    '====================================================================================
                    linhatexto = PagtoFornecedor_Registro_2(dspagtotransp.Tables(0).Rows(li).Item("nr_valor_nota_fiscal").ToString, "1", "", dspagtotransp.Tables(0).Rows(li).Item("dt_pedido").ToString, dsnaturezaoperacao.Tables(0).Rows(0), dsitem.Tables(0).Rows(0))
                    ArquivoTexto.WriteLine(linhatexto)
                    linhatexto = ""
                    '====================================================================================
                    ' Registro Tipo 3  - Duplicatas
                    '====================================================================================
                    linhatexto = PagtoFornecedor_Registro_3(dspagtotransp.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0))
                    ArquivoTexto.WriteLine(linhatexto)
                    linhatexto = ""

                    liexportada_transportador = liexportada_transportador + 1
                Next
                '02/08/2012 f Fran - Envia dados tb da improtação de pagamento de frete ao transportador

            End If
            Me.nr_linhaslidas = li
            'fran 03/08/2012 i 
            ' Me.nr_linhasexportadas = liexportada
            Me.nr_linhasexportadas = liexportada + liexportada_transportador
            'fran 03/08/2012 f 

            'Se exportou todas as linhas lidas
            If liexportada > 0 Then
                ' Atualiza Data e Status de Exportação de todas as parcelas do mes para todos os fornecedores
                ' ja faz atualização linha a linha acima Me.updateCentralPedidoPagtoFornecedorExportacao()   ' Atualiza Status=S e data de exportacao
                exportPagtoFornecedorSAP = True
                If liexportada_transportador > 0 Then
                    ' Atualiza Data e Status de Exportação de todas as pagamentos dos transportadores
                    Me.updatePagtoTransportadorExportacao()   ' Atualiza Status=S e data de exportacao
                    'fran 03/08/2012 f
                End If
            Else
                'fran 03/08/2012 i 
                If liexportada_transportador > 0 Then
                    ' Atualiza Data e Status de Exportação de todas as parcelas do mes para todos os fornecedores
                    Me.updatePagtoTransportadorExportacao()   ' Atualiza Status=S e data de exportacao
                    exportPagtoFornecedorSAP = True
                    'fran 03/08/2012 f
                Else
                    exportPagtoFornecedorSAP = False
                    Me.cd_erro = "Sem Linhas"
                End If
            End If
            ArquivoTexto.Close()



        Catch ex As Exception
            exportPagtoFornecedorSAP = False
            Me.nm_erro = ex.Message
            Me.cd_erro = "Exception"
            Me.insertCentralExportacaoPagtoFornecedorErro()
            ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    Private Function PagtoFornecedor_Registro_1_SAP(ByVal pRegistro As DataRow, ByVal pdsNaturezaOperacao As DataRow) As String


        Try

            Dim linhatexto As String
            Dim lpos As Int16

            ' Registro 1
            Dim cd_registro As String
            Dim numero_notafiscal As String
            Dim nr_nota_fiscal_formatado As String
            Dim serie_notafiscal As String
            Dim cd_emitente As String
            Dim cd_natureza_operacao As String
            Dim cd_estabelecimento As String
            Dim cd_estabelecimento_fiscal As String
            Dim conta_contabil As String
            Dim dt_emissao As String
            Dim dt_transacao As String
            Dim cd_uf As String
            Dim cd_frete As String
            Dim nr_valor As String
            Dim peso_total As String
            Dim total_descontos As String
            Dim valor_mercadoria As String
            Dim valor_total_nota As String
            Dim nr_valor_int As String
            Dim nr_valor_dec As String
            Dim especie_nf As String
            Dim usuario_responsavel As String
            Dim obs As String

            Dim usuario As New Usuario(Me.id_modificador)

            linhatexto = ""

            '====================================================================================
            ' Registro Tipo 1
            '====================================================================================

            cd_registro = "1"  ' Registro tipo 1

            If IsDBNull(pRegistro.Item("nr_serie_nota_fiscal")) Then
                serie_notafiscal = Space(5)
            Else
                serie_notafiscal = pRegistro.Item("nr_serie_nota_fiscal")
                serie_notafiscal = Left(serie_notafiscal + StrDup(5 - Len(serie_notafiscal), " "), 5)
            End If

            nr_nota_fiscal_formatado = CStr(pRegistro.Item("nr_nota_fiscal"))
            'nr_nota_fiscal_formatado = Left(StrDup(7 - Len(nr_nota_fiscal_formatado), "0") + nr_nota_fiscal_formatado, 7)
            nr_nota_fiscal_formatado = Left(StrDup(9 - Len(nr_nota_fiscal_formatado), "0") + nr_nota_fiscal_formatado, 9)
            numero_notafiscal = Left(nr_nota_fiscal_formatado + StrDup(16 - Len(nr_nota_fiscal_formatado), " "), 16)
            'nr_nota_fiscal_formatado = Left(StrDup(9 - Len(nr_nota_fiscal_formatado), "0") + nr_nota_fiscal_formatado, 9)
            'numero_notafiscal = Left(nr_nota_fiscal_formatado + StrDup(14 - Len(nr_nota_fiscal_formatado), " "), 14)


            'cd_emitente = pRegistro.Item("cd_fornecedor")
            cd_emitente = pRegistro.Item("cd_fornecedor_sap").ToString  ' 09/03/2012 - Projeto Themis
            'cd_emitente = Left(StrDup(6 - Len(cd_emitente), "0") + cd_emitente, 6)
            cd_emitente = Left(StrDup(10 - Len(cd_emitente), "0") + cd_emitente, 10)    ' 09/03/2012 - Projeto Themis

            cd_natureza_operacao = "4100AA"

            cd_estabelecimento = Space(3)
            'cd_estabelecimento = pRegistro.Item("cd_estabelecimento_produtor")
            cd_estabelecimento = pRegistro.Item("cd_estabelecimento_produtor_sap").ToString  ' 09/03/2012 - Projeto Themis
            'cd_estabelecimento = Left(cd_estabelecimento + StrDup(3 - Len(cd_estabelecimento), " "), 3)
            cd_estabelecimento = Left(cd_estabelecimento + StrDup(4 - Len(cd_estabelecimento), " "), 4)  ' 09/03/2012 - Projeto Themis

            cd_estabelecimento_fiscal = cd_estabelecimento

            'Preciso saber qual o cd_natureza_operacao para depois buscar conta contabil no cadastro
            'Fran 02/08/2012 i - Themis - Enviar a seguinte regra de acordo com escopo:
            'Para Central: 00000000000220061 Para GKO:00000000000220316:
            'conta_contabil = Left(pdsNaturezaOperacao.Item("nr_conta_transitoria").ToString + StrDup(17, " "), 17)
            If pRegistro.Item("id_produtor").ToString.Equals("0") Then 'se nao tem produtor é transportador de frete 
                conta_contabil = Right("00000000000220316", 17)
            Else 'se tem produtor é Central
                conta_contabil = Right("00000000000220061", 17)
            End If
            'Fran 02/08/2012 f - Themis - Enviar a seguinte regra de acordo com escopo:


            'Data de emissão - ultimo dia do mês de referencia
            dt_emissao = DateTime.Parse(pRegistro.Item("dt_pedido").ToString).ToString("ddMMyyyy")
            'fran 25/09/2013 i melhorias fase1
            'dt_transacao = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateTime.Parse(Me.dt_referencia.ToString))).ToString("ddMMyyyy")
            dt_transacao = DateTime.Parse(Now).ToString("ddMMyyyy")
            'fran 25/09/2013 2 melhorias fase1

            usuario_responsavel = usuario.ds_login
            usuario_responsavel = Left(usuario_responsavel + StrDup(12 - Len(usuario_responsavel), " "), 12)

            If IsDBNull(pRegistro.Item("cd_uf").ToString) Then 'cdUf do fornecedor
                cd_uf = Space(4)
            Else
                cd_uf = pRegistro.Item("cd_uf").ToString
                cd_uf = Left(cd_uf + StrDup(4 - Len(cd_uf), " "), 4)
            End If

            cd_frete = "01"

            peso_total = "00000000000000"

            total_descontos = "0000000000000"

            'fran 30/09/2013 i fase 1 deve enviar apenas o valor da parcela
            'nr_valor = CStr(pRegistro.Item("nr_valor_nota_fiscal").ToString)
            nr_valor = CStr(pRegistro.Item("nr_valor_parcela").ToString)
            'fran 30/09/2013 f. fase 1 deve enviar apenas o valor da parcela


            If nr_valor.Equals(String.Empty) Then
                nr_valor = "0"
            End If

            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(10 - Len(nr_valor), "0") + nr_valor, 10)
                nr_valor = nr_valor & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(11 - Len(nr_valor_int), "0") + nr_valor_int, 11)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            valor_mercadoria = nr_valor 'nr valor total da nota nr_valor_nota_fiscal

            valor_total_nota = String.Concat("00", nr_valor)  'valor total da nota

            especie_nf = "21"
            obs = Space(2000)

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = cd_registro + serie_notafiscal + numero_notafiscal + cd_emitente
            linhatexto = linhatexto + cd_natureza_operacao + "4" + cd_estabelecimento + cd_estabelecimento_fiscal
            linhatexto = linhatexto + conta_contabil + dt_emissao + dt_transacao + usuario_responsavel
            linhatexto = linhatexto + cd_uf + "1" + cd_frete + "nao" + peso_total
            linhatexto = linhatexto + total_descontos
            linhatexto = linhatexto + StrDup(13, "0")
            linhatexto = linhatexto + StrDup(13, "0")
            linhatexto = linhatexto + StrDup(13, "0")
            linhatexto = linhatexto + StrDup(13, "0")
            linhatexto = linhatexto + valor_mercadoria + dt_emissao + dt_emissao
            linhatexto = linhatexto + valor_total_nota + "2" + especie_nf
            linhatexto = linhatexto + "0"
            linhatexto = linhatexto + obs
            linhatexto = linhatexto + Space(12)
            linhatexto = linhatexto + Space(7)
            linhatexto = linhatexto + Space(7)
            linhatexto = linhatexto + Space(7)
            linhatexto = linhatexto + Space(2)
            linhatexto = linhatexto + Space(2)
            linhatexto = linhatexto + Space(2)
            linhatexto = linhatexto + Space(60)
            linhatexto = linhatexto + "0"

            PagtoFornecedor_Registro_1_SAP = formatarTexto(linhatexto)

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try

    End Function

    ' 08/03/2012 adri - Projeto Themis - f 

End Class
