Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class NotaFiscal

    Private _id_nota_fiscal As Int32
    Private _nr_nota_fiscal As String
    Private _nr_serie As String
    Private _id_natureza_operacao As Int32
    Private _nm_natureza_operacao As String
    Private _cd_natureza_operacao As String
    Private _ds_tipo_especie As String
    Private _id_pessoa As Int32
    Private _nm_pessoa As String
    Private _cd_pessoa As String
    Private _cd_cnpj As String
    Private _id_estabelecimento As Int32
    Private _cd_estabelecimento As String
    Private _nm_estabelecimento As String
    Private _dt_emissao As String
    Private _dt_transacao As String
    Private _id_frete_nf As Int32
    Private _nm_frete_nf As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _nr_linhaslidas As Int32
    Private _nr_linhasexportadas As Int32
    Private _nm_arquivo As String
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _st_exportacao As String
    Private _dt_exportacao As String
    Private _nr_preco_total As Decimal
    Private _dt_referencia As String 'Fran 19/11/2008 - Referencia que foi gerada nota de produtor
    Private _cd_uf As String 'Fran 19/11/2008 - Cd_UF da propriedade
    Private _id_propriedade As Int32 'Fran 25/11/2008 - Cd_UF da propriedade
    Private _linhatexto As String   ' Adri 25/11/2008
    'Private _cabecalho_linhatexto As String  'Fran 03122008
    Private _st_tem_grampo As String ' Adri 25/11/2008
    Private _nr_nota_fiscal_ini As Decimal
    Private _nr_nota_fiscal_fim As Decimal
    Private _cd_erro As String 'fran 07/06/2010 i chamado 818
    Private _nm_erro As String 'fran 07/06/2010 i chamado 818
    Private _id_romaneio As Int32 'fran 05/1/2011 gko
    Private _ds_chave_nfe As String 'fran 05/1/2011 gko
    Private _nr_valor_icms As Decimal 'fran 05/1/2011 gko
    Private _dt_ini_2quinz As String
    Private _dt_fim_1quinz As String
    Private _id_tipo_nota_fiscal As Int32 'fran 21/10/2011
    'Fran 03/2017 - NOTA FRETE  i
    Private _nr_cte As Int32 'Nr CTE em ms_nota_fiscal
    Private _nr_valor_cte As Decimal 'Valor CTE em ms_nota_fiscal
    Private _nr_serie_cte As String
    Private _ds_chave_cte As String 'chave cte em ms_nota_fiscal
    Private _id_tipo_nota_fiscal2 As Int32 'Tipo Nota Fiscal 2 em ms_nota_fiscal
    Private _nr_nota_fiscal2 As String 'numero nota fiscal 2 em ms_nota_fiscal
    Private _nr_serie_nota_fiscal2 As String 'numero serie nota fiscal 2 em ms_nota_fiscal
    Private _nr_valor_nota_fiscal2 As Decimal ' valor nota fiscal 2 em ms_nota_fiscal
    Private _nr_litros_nota_fiscal2 As Decimal 'litros nota fiscal 2 em ms_nota_fiscal
    'Fran 03/2017 - NOTA FRETE  f
    Private _nr_valor_icms_cte As Decimal
    Private _cd_cst_cte As String
    Private _cd_cfop_cte As String
    Private _dt_emissao_completa_cte As String
    Private _nr_base_icms_cte As Decimal
    Private _cd_uf_origem_cte As String
    Private _cd_uf_destino_cte As String
    Private _cd_ibge_origem_cte As String
    Private _cd_ibge_destino_cte As String
    Private _ds_protocolo_cte As String

    Public Property id_nota_fiscal() As Int32
        Get
            Return _id_nota_fiscal
        End Get
        Set(ByVal value As Int32)
            _id_nota_fiscal = value
        End Set
    End Property
    Public Property id_tipo_nota_fiscal() As Int32
        Get
            Return _id_tipo_nota_fiscal
        End Get
        Set(ByVal value As Int32)
            _id_tipo_nota_fiscal = value
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
    Public Property id_natureza_operacao() As Int32
        Get
            Return _id_natureza_operacao
        End Get
        Set(ByVal value As Int32)
            _id_natureza_operacao = value
        End Set
    End Property
    Public Property ds_tipo_especie() As String
        Get
            Return _ds_tipo_especie
        End Get
        Set(ByVal value As String)
            _ds_tipo_especie = value
        End Set
    End Property
    Public Property cd_natureza_operacao() As String
        Get
            Return _cd_natureza_operacao
        End Get
        Set(ByVal value As String)
            _cd_natureza_operacao = value
        End Set
    End Property
    Public Property nm_natureza_operacao() As String
        Get
            Return _nm_natureza_operacao
        End Get
        Set(ByVal value As String)
            _nm_natureza_operacao = value
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
    Public Property nm_pessoa() As String
        Get
            Return _nm_pessoa
        End Get
        Set(ByVal value As String)
            _nm_pessoa = value
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
    Public Property cd_cnpj() As String
        Get
            Return _cd_cnpj
        End Get
        Set(ByVal value As String)
            _cd_cnpj = value
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
    Public Property nm_estabelecimento() As String
        Get
            Return _nm_estabelecimento
        End Get
        Set(ByVal value As String)
            _nm_estabelecimento = value
        End Set
    End Property
    Public Property cd_estabelecimento() As String
        Get
            Return _cd_estabelecimento
        End Get
        Set(ByVal value As String)
            _cd_estabelecimento = value
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
    Public Property dt_transacao() As String
        Get
            Return _dt_transacao
        End Get
        Set(ByVal value As String)
            _dt_transacao = value
        End Set
    End Property
    Public Property nm_frete_nf() As String
        Get
            Return _nm_frete_nf
        End Get
        Set(ByVal value As String)
            _nm_frete_nf = value
        End Set
    End Property
    Public Property id_frete_nf() As Int32
        Get
            Return _id_frete_nf
        End Get
        Set(ByVal value As Int32)
            _id_frete_nf = value
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
    Public Property nm_arquivo() As String
        Get
            Return _nm_arquivo
        End Get
        Set(ByVal value As String)
            _nm_arquivo = value
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
    Public Property dt_ini_2quinz() As String
        Get
            Return _dt_ini_2quinz
        End Get
        Set(ByVal value As String)
            _dt_ini_2quinz = value
        End Set
    End Property
    Public Property dt_fim_1quinz() As String
        Get
            Return _dt_fim_1quinz
        End Get
        Set(ByVal value As String)
            _dt_fim_1quinz = value
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
    Public Property dt_exportacao() As String
        Get
            Return _dt_exportacao
        End Get
        Set(ByVal value As String)
            _dt_exportacao = value
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
    Public Property nr_preco_total() As Decimal
        Get
            Return _nr_preco_total
        End Get
        Set(ByVal value As Decimal)
            _nr_preco_total = value
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
    Public Property cd_uf() As String
        Get
            Return _cd_uf
        End Get
        Set(ByVal value As String)
            _cd_uf = value
        End Set
    End Property
    Public Property linhatexto() As String
        Get
            Return _linhatexto
        End Get
        Set(ByVal value As String)
            _linhatexto = value
        End Set
    End Property

    Public Property st_tem_grampo() As String
        Get
            Return _st_tem_grampo
        End Get
        Set(ByVal value As String)
            _st_tem_grampo = value
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
    Public Property id_romaneio() As Int32
        Get
            Return _id_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_romaneio = value
        End Set
    End Property
    Public Property nr_valor_icms() As Decimal
        Get
            Return _nr_valor_icms
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_icms = value
        End Set
    End Property
    Public Property ds_chave_nfe() As String
        Get
            Return _ds_chave_nfe
        End Get
        Set(ByVal value As String)
            _ds_chave_nfe = value
        End Set
    End Property
    Public Property nr_cte() As Int32
        Get
            Return _nr_cte
        End Get
        Set(ByVal value As Int32)
            _nr_cte = value
        End Set
    End Property
    Public Property nr_valor_cte() As Decimal
        Get
            Return _nr_valor_cte
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_cte = value
        End Set
    End Property
    Public Property nr_serie_cte() As String
        Get
            Return _nr_serie_cte
        End Get
        Set(ByVal value As String)
            _nr_serie_cte = value
        End Set
    End Property
    Public Property ds_chave_cte() As String
        Get
            Return _ds_chave_cte
        End Get
        Set(ByVal value As String)
            _ds_chave_cte = value
        End Set
    End Property
    Public Property id_tipo_nota_fiscal2() As Int32
        Get
            Return _id_tipo_nota_fiscal2
        End Get
        Set(ByVal value As Int32)
            _id_tipo_nota_fiscal2 = value
        End Set
    End Property
    Public Property nr_nota_fiscal2() As String
        Get
            Return _nr_nota_fiscal2
        End Get
        Set(ByVal value As String)
            _nr_nota_fiscal2 = value
        End Set
    End Property
    Public Property nr_serie_nota_fiscal2() As String
        Get
            Return _nr_serie_nota_fiscal2
        End Get
        Set(ByVal value As String)
            _nr_serie_nota_fiscal2 = value
        End Set
    End Property

    Public Property nr_valor_nota_fiscal2() As Decimal
        Get
            Return _nr_valor_nota_fiscal2
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nota_fiscal2 = value
        End Set
    End Property
    Public Property nr_litros_nota_fiscal2() As Decimal
        Get
            Return _nr_litros_nota_fiscal2
        End Get
        Set(ByVal value As Decimal)
            _nr_litros_nota_fiscal2 = value
        End Set
    End Property
    Public Property nr_valor_icms_cte() As Decimal
        Get
            Return _nr_valor_icms_cte
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_icms_cte = value
        End Set
    End Property
    Public Property cd_cst_cte() As String
        Get
            Return _cd_cst_cte
        End Get
        Set(ByVal value As String)
            _cd_cst_cte = value
        End Set
    End Property
    Public Property cd_cfop_cte() As String
        Get
            Return _cd_cfop_cte
        End Get
        Set(ByVal value As String)
            _cd_cfop_cte = value
        End Set
    End Property
    Public Property dt_emissao_completa_cte() As String
        Get
            Return _dt_emissao_completa_cte
        End Get
        Set(ByVal value As String)
            _dt_emissao_completa_cte = value
        End Set
    End Property
    Public Property nr_base_icms_cte() As Decimal
        Get
            Return _nr_base_icms_cte
        End Get
        Set(ByVal value As Decimal)
            _nr_base_icms_cte = value
        End Set
    End Property
    Public Property cd_uf_origem_cte() As String
        Get
            Return _cd_uf_origem_cte
        End Get
        Set(ByVal value As String)
            _cd_uf_origem_cte = value
        End Set
    End Property
    Public Property cd_uf_destino_cte() As String
        Get
            Return _cd_uf_destino_cte
        End Get
        Set(ByVal value As String)
            _cd_uf_destino_cte = value
        End Set
    End Property
    Public Property cd_ibge_origem_cte() As String
        Get
            Return _cd_ibge_origem_cte
        End Get
        Set(ByVal value As String)
            _cd_ibge_origem_cte = value
        End Set
    End Property
    Public Property cd_ibge_destino_cte() As String
        Get
            Return _cd_ibge_destino_cte
        End Get
        Set(ByVal value As String)
            _cd_ibge_destino_cte = value
        End Set
    End Property
    Public Property ds_protocolo_cte() As String
        Get
            Return _ds_protocolo_cte
        End Get
        Set(ByVal value As String)
            _ds_protocolo_cte = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_nota_fiscal = id
        loadNotaFiscal()

    End Sub



    Public Sub New()

    End Sub


    Public Function getNotasFiscaisByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCapaNotasFiscais", parameters, "ms_nota_fiscal")
            Return dataSet

        End Using

    End Function
    Public Function getNotasFiscaisTotalDuplicata() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getNotasFiscaisTotalDuplicata", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function

    Private Sub loadNotaFiscal()

        Dim dataSet As DataSet = getNotasFiscaisByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertNotaFiscal() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertNotaFiscal", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateNotaFiscal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateNotaFiscal", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateNotaFiscalExportacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateNotaFiscalExportacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub deleteNotaFiscal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteNotaFiscal", parameters, ExecuteType.Delete)

        End Using


    End Sub

    Public Sub exportNotaFiscal()

        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim li As Int32
            Dim li_item As Int32
            Dim li_dup As Int32
            Dim linhatexto As String
            Dim liexportada As Int32
            Dim lpos As Int16

            ' Registro 1
            Dim cd_registro As String
            Dim numero_notafiscal As String
            Dim nr_nota_fiscal_formatado As String  ' 24/11/2008
            Dim serie_notafiscal As String
            Dim cd_emitente As String
            Dim cd_natureza_operacao As String
            Dim cd_estabelecimento As String
            Dim cd_uf As String
            Dim cd_frete As String
            Dim nr_valor As String
            Dim nr_valor_int As String
            Dim nr_valor_dec As String
            Dim especie_nf As String
            Dim usuario_responsavel As String
            Dim chaveacessonfe As String 'fran 10/01/2011

            ' Registro 2
            Dim cd_item As String
            Dim cd_classificacao_fiscal As String
            Dim nr_aliquota_ipi As String
            Dim nr_tributacao_ipi As String
            Dim nr_aliquota_icms As String
            Dim nr_tributacao_icms As String
            Dim valor_aliquota_icms As Decimal
            Dim valor_base_icms As Decimal
            Dim ds_narrativa As String

            ' Registro 3
            Dim nr_parcela As String
            Dim nr_duplicata As String
            Dim dt_duplicata As Date

            Dim usuario As New Usuario(id_modificador)  ' 29/10/2008



            Dim dsNotaFiscal As DataSet = Me.getNotasFiscaisByFilters()

            For li = 0 To dsNotaFiscal.Tables(0).Rows.Count - 1

                linhatexto = ""

                '====================================================================================
                ' Registro Tipo 1
                '====================================================================================

                cd_registro = "1"  ' Registro tipo 1
                linhatexto = linhatexto + cd_registro           ' 29/10/2008

                If IsDBNull(dsNotaFiscal.Tables(0).Rows(li).Item("nr_serie")) Then
                    linhatexto = linhatexto + Space(5)
                Else
                    serie_notafiscal = dsNotaFiscal.Tables(0).Rows(li).Item("nr_serie")
                    serie_notafiscal = Left(serie_notafiscal + StrDup(5 - Len(serie_notafiscal), " "), 5)
                    linhatexto = linhatexto + serie_notafiscal
                End If

                ' 24/11/2008 - i
                'numero_notafiscal = dsNotaFiscal.Tables(0).Rows(li).Item("nr_nota_fiscal")
                nr_nota_fiscal_formatado = CStr(dsNotaFiscal.Tables(0).Rows(li).Item("nr_nota_fiscal"))
                nr_nota_fiscal_formatado = Left(StrDup(7 - Len(nr_nota_fiscal_formatado), "0") + nr_nota_fiscal_formatado, 7)
                numero_notafiscal = Left(nr_nota_fiscal_formatado + StrDup(16 - Len(nr_nota_fiscal_formatado), " "), 16)
                ' 24/11/2008 - f
                linhatexto = linhatexto + numero_notafiscal

                cd_emitente = dsNotaFiscal.Tables(0).Rows(li).Item("cd_pessoa")
                cd_emitente = Left(StrDup(6 - Len(cd_emitente), "0") + cd_emitente, 6)
                linhatexto = linhatexto + cd_emitente

                cd_natureza_operacao = dsNotaFiscal.Tables(0).Rows(li).Item("cd_natureza_operacao")
                cd_natureza_operacao = Left(cd_natureza_operacao + StrDup(6 - Len(cd_natureza_operacao), " "), 6)
                linhatexto = linhatexto + cd_natureza_operacao

                linhatexto = linhatexto + "1"

                Dim estabelecimento As New Estabelecimento(dsNotaFiscal.Tables(0).Rows(li).Item("id_estabelecimento"))
                cd_estabelecimento = Space(3)
                cd_estabelecimento = estabelecimento.cd_estabelecimento
                cd_estabelecimento = Left(cd_estabelecimento + StrDup(3 - Len(cd_estabelecimento), " "), 3)
                linhatexto = linhatexto + cd_estabelecimento

                linhatexto = linhatexto + cd_estabelecimento  ' Estabelecimento Fiscal

                ' 29/10/2008 - i
                'linhatexto = linhatexto + StrDup(17, "0")     ' Conta Contabil  
                If cd_natureza_operacao = "1151AA" Or cd_natureza_operacao = "2151AA" Then
                    linhatexto = linhatexto + "1140700100000000 "     ' Conta Contabil  
                Else
                    linhatexto = linhatexto + "1990100900000000 "     ' Conta Contabil  
                End If
                ' 29/10/2008 - f

                linhatexto = linhatexto + DateTime.Parse(dsNotaFiscal.Tables(0).Rows(li).Item("dt_emissao").ToString).ToString("ddMMyyyy")
                linhatexto = linhatexto + DateTime.Parse(dsNotaFiscal.Tables(0).Rows(li).Item("dt_transacao").ToString).ToString("ddMMyyyy")

                ' 29/10/2008 - i
                'linhatexto = linhatexto + Space(12)
                usuario_responsavel = usuario.ds_login
                usuario_responsavel = Left(usuario_responsavel + StrDup(12 - Len(usuario_responsavel), " "), 12)
                linhatexto = linhatexto + usuario_responsavel
                ' 29/10/2008 - f

                If IsDBNull(dsNotaFiscal.Tables(0).Rows(li).Item("cd_uf")) Then
                    cd_uf = Space(4)
                Else
                    cd_uf = dsNotaFiscal.Tables(0).Rows(li).Item("cd_uf")
                    cd_uf = Left(cd_uf + StrDup(4 - Len(cd_uf), " "), 4)   ' 29/10/2008
                End If
                'cd_uf = Left(cd_uf + StrDup(6 - Len(cd_uf), " "), 6)
                linhatexto = linhatexto + cd_uf

                linhatexto = linhatexto + "1"  ' Via transporte

                cd_frete = dsNotaFiscal.Tables(0).Rows(li).Item("id_frete_nf")
                cd_frete = Left(StrDup(2 - Len(cd_frete), "0") + cd_frete, 2)
                linhatexto = linhatexto + cd_frete

                linhatexto = linhatexto + "nao"

                nr_valor = CStr(Round(dsNotaFiscal.Tables(0).Rows(li).Item("nr_total_peso_liquido"), 4))
                lpos = InStr(1, nr_valor, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    nr_valor = CStr(nr_valor)
                    nr_valor = Left(StrDup(10 - Len(nr_valor), "0") + nr_valor, 10)
                    nr_valor = nr_valor & "0000"
                Else
                    nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                    nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), "0") + nr_valor_int, 10)
                    nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                    nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                    nr_valor = nr_valor_int & nr_valor_dec
                End If
                linhatexto = linhatexto + nr_valor     ' Somatória dos Pesos dos itens

                linhatexto = linhatexto + StrDup(13, "0")
                linhatexto = linhatexto + StrDup(13, "0")
                linhatexto = linhatexto + StrDup(13, "0")
                linhatexto = linhatexto + StrDup(13, "0")
                linhatexto = linhatexto + StrDup(13, "0")

                ' 11 inteiros e 2 decimais (campo 23-Valor da Mercadoria)
                'nr_valor = CStr(Round(dsNotaFiscal.Tables(0).Rows(li).Item("nr_preco_unitario"), 2))
                nr_valor = CStr(Round(dsNotaFiscal.Tables(0).Rows(li).Item("nr_preco_total"), 2))  ' 29/10/2008
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
                linhatexto = linhatexto + nr_valor     ' Somatória dos Preços Unitários dos itens

                'fran 12/10/2011 i
                'linhatexto = linhatexto + "?       "
                'linhatexto = linhatexto + "?       "
                linhatexto = linhatexto + "        "
                linhatexto = linhatexto + "        "
                'fran 12/102011 f
                ' 13 inteiros e 2 decimais (campo 26-Valor Total da Nota)
                nr_valor = CStr(dsNotaFiscal.Tables(0).Rows(li).Item("nr_preco_total"))
                lpos = InStr(1, nr_valor, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    nr_valor = CStr(nr_valor)
                    nr_valor = Left(StrDup(13 - Len(nr_valor), "0") + nr_valor, 13)
                    nr_valor = nr_valor & "00"
                Else
                    nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                    nr_valor_int = Left(StrDup(13 - Len(nr_valor_int), "0") + nr_valor_int, 13)
                    nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                    nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                    nr_valor = nr_valor_int & nr_valor_dec
                End If
                linhatexto = linhatexto + nr_valor     ' Somatória dos Preços Totais dos itens

                linhatexto = linhatexto + "2"

                especie_nf = dsNotaFiscal.Tables(0).Rows(li).Item("id_especie_nf")
                Select Case especie_nf
                    Case "1"
                        especie_nf = "20"   ' NFD
                    Case "2"
                        especie_nf = "21"   ' NFE
                    Case "3"
                        especie_nf = "23"   ' NFT
                End Select
                linhatexto = linhatexto + especie_nf

                linhatexto = linhatexto + "0"
                linhatexto = linhatexto + Space(2000) 'campo 30
                linhatexto = linhatexto + Space(12)
                linhatexto = linhatexto + Space(7)
                linhatexto = linhatexto + Space(7)
                linhatexto = linhatexto + Space(7)
                linhatexto = linhatexto + Space(2)
                linhatexto = linhatexto + Space(2)
                linhatexto = linhatexto + Space(2)
                'fran 10/01/2011 i gko rls 27 inclusao chave de acesso nfe no campo 38
                'linhatexto = linhatexto + Space(60)
                'adri 19/01/2011 chamado 1141 -  Tirar a máscara do campo - i
                Dim chaveacessonfe_aux As String
                Dim i As Int16
                chaveacessonfe_aux = dsNotaFiscal.Tables(0).Rows(li).Item("ds_chave_nfe")
                chaveacessonfe = ""
                For i = 1 To Len(chaveacessonfe_aux)
                    If Mid(chaveacessonfe_aux, i, 1) <> "." Then
                        chaveacessonfe = chaveacessonfe + Mid(chaveacessonfe_aux, i, 1)
                    End If
                Next
                'adri 19/01/2011 chamado 1141 -  Tirar os pontos do campo - f
                chaveacessonfe = Left(chaveacessonfe + StrDup(60 - Len(chaveacessonfe), " "), 60)
                linhatexto = linhatexto + chaveacessonfe
                'fran 10/01/2011 f gko rls 27 inclusao chave de acesso nfe no campo 38

                linhatexto = linhatexto + "0"

                ArquivoTexto.WriteLine(linhatexto)


                '====================================================================================
                ' Registro Tipo 2
                '====================================================================================

                ' Salva Aliquota IPI
                ' 3 inteiros e 2 decimais (campo 26)
                If IsDBNull(dsNotaFiscal.Tables(0).Rows(li).Item("nr_aliquota_ipi")) Then
                    nr_valor = 0
                Else
                    nr_valor = CStr(dsNotaFiscal.Tables(0).Rows(li).Item("nr_aliquota_ipi"))
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

                ' Salva id_tributacao_ipi

                'Fran 05/12/2008 - Deve fazer tradução
                'nr_tributacao_ipi = CStr(dsNotaFiscal.Tables(0).Rows(li).Item("id_tributacao_ipi"))
                nr_tributacao_ipi = converteCodigoTributacao(dsNotaFiscal.Tables(0).Rows(li).Item("id_tributacao_ipi"))
                'Fran 05/12/2008 f
                nr_tributacao_ipi = Left(StrDup(2 - Len(nr_tributacao_ipi), "0") + nr_tributacao_ipi, 2)

                ' Salva Aliquota ICMS
                ' 3 inteiros e 2 decimais (campo 26)
                If IsDBNull(dsNotaFiscal.Tables(0).Rows(li).Item("nr_aliquota_icms")) Then
                    nr_valor = 0
                    valor_aliquota_icms = 0
                Else
                    nr_valor = CStr(dsNotaFiscal.Tables(0).Rows(li).Item("nr_aliquota_icms"))
                    valor_aliquota_icms = Convert.ToDecimal(dsNotaFiscal.Tables(0).Rows(li).Item("nr_aliquota_icms"))
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

                ' Salva id_tributacao_icms
                'Fran 05/12/2008 i - deve fazer tradução
                'nr_tributacao_icms = CStr(dsNotaFiscal.Tables(0).Rows(li).Item("id_tributacao_icms"))
                nr_tributacao_icms = converteCodigoTributacao(dsNotaFiscal.Tables(0).Rows(li).Item("id_tributacao_icms"))
                'Fran 05/12/2008 f
                nr_tributacao_icms = Left(StrDup(2 - Len(nr_tributacao_icms), "0") + nr_tributacao_icms, 2)

                Dim itemnotafiscal As New ItemNotaFiscal
                itemnotafiscal.id_nota_fiscal = dsNotaFiscal.Tables(0).Rows(li).Item("id_nota_fiscal")
                Dim dsNotaFiscalItem As DataSet = itemnotafiscal.getItensNotasByFilters()

                For li_item = 0 To dsNotaFiscalItem.Tables(0).Rows.Count - 1
                    linhatexto = ""
                    cd_registro = "2"  ' Registro tipo 1
                    linhatexto = linhatexto + cd_registro           ' 29/10/2008

                    cd_item = Left(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("cd_item"), 16)
                    cd_item = Left(cd_item + StrDup(16 - Len(cd_item), " "), 16)
                    linhatexto = linhatexto + cd_item

                    linhatexto = linhatexto + Space(8)
                    linhatexto = linhatexto + StrDup(8, "0")
                    linhatexto = linhatexto + StrDup(5, "0")
                    'linhatexto = linhatexto + StrDup(3, "nao")
                    linhatexto = linhatexto + "nao"  ' 29/10/2008
                    linhatexto = linhatexto + StrDup(9, "0")
                    linhatexto = linhatexto + Space(16)
                    linhatexto = linhatexto + StrDup(4, "0")
                    linhatexto = linhatexto + Space(16)
                    linhatexto = linhatexto + Space(17)
                    linhatexto = linhatexto + "sim"
                    linhatexto = linhatexto + StrDup(3, "0")

                    ' 10 inteiros e 4 decimais (campo 14-Qtde digitada na tela)
                    nr_valor = CStr(Round(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_quantidade"), 4))
                    lpos = InStr(1, nr_valor, ",", 1)
                    If lpos = 0 Then   ' Se não tem casas decimais
                        nr_valor = CStr(nr_valor)
                        nr_valor = Left(StrDup(10 - Len(nr_valor), "0") + nr_valor, 10)
                        nr_valor = nr_valor & "0000"
                    Else
                        nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                        nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), "0") + nr_valor_int, 10)
                        nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                        nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                        nr_valor = nr_valor_int & nr_valor_dec
                    End If
                    linhatexto = linhatexto + nr_valor     ' Quantidade

                    ' 8 inteiros e 4 decimais (campo 15-Qtde na nossa unidade de medida)
                    nr_valor = CStr(Round(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_quantidade"), 4))
                    lpos = InStr(1, nr_valor, ",", 1)
                    If lpos = 0 Then   ' Se não tem casas decimais
                        nr_valor = CStr(nr_valor)
                        nr_valor = Left(StrDup(8 - Len(nr_valor), "0") + nr_valor, 8)
                        nr_valor = nr_valor & "0000"
                    Else
                        nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                        nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), "0") + nr_valor_int, 8)
                        nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                        nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                        nr_valor = nr_valor_int & nr_valor_dec
                    End If
                    linhatexto = linhatexto + nr_valor     ' Quantidade

                    ' 10 inteiros e 2 decimais (campo 16)
                    nr_valor = CStr(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_preco_total"))
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
                    linhatexto = linhatexto + nr_valor     ' Preço Total

                    linhatexto = linhatexto + StrDup(12, "0")
                    linhatexto = linhatexto + StrDup(12, "0")
                    linhatexto = linhatexto + StrDup(12, "0")

                    ' 7 inteiros e 5 decimais (campo 20)
                    nr_valor = CStr(Round(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_peso_liquido"), 4))
                    lpos = InStr(1, nr_valor, ",", 1)
                    If lpos = 0 Then   ' Se não tem casas decimais
                        nr_valor = CStr(nr_valor)
                        nr_valor = Left(StrDup(7 - Len(nr_valor), "0") + nr_valor, 7)
                        nr_valor = nr_valor & "00000"
                    Else
                        nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                        nr_valor_int = Left(StrDup(7 - Len(nr_valor_int), "0") + nr_valor_int, 7)
                        nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                        nr_valor_dec = Left(nr_valor_dec + StrDup(5 - Len(nr_valor_dec), "0"), 5)
                        nr_valor = nr_valor_int & nr_valor_dec
                    End If
                    linhatexto = linhatexto + nr_valor     ' Peso Líquido

                    linhatexto = linhatexto + "RCP"
                    linhatexto = linhatexto + Space(10)
                    linhatexto = linhatexto + Space(10)
                    linhatexto = linhatexto + "31122999"

                    cd_classificacao_fiscal = Left(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("cd_classificacao_fiscal"), 8)
                    cd_classificacao_fiscal = Left(cd_classificacao_fiscal + StrDup(8 - Len(cd_classificacao_fiscal), " "), 8)
                    linhatexto = linhatexto + cd_classificacao_fiscal

                    linhatexto = linhatexto + nr_aliquota_ipi
                    linhatexto = linhatexto + nr_tributacao_ipi


                    ' 10 inteiros e 2 decimais (campo 28)
                    nr_valor = CStr(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_preco_total"))
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
                    linhatexto = linhatexto + nr_valor     ' Preço Total (Base IPI)

                    linhatexto = linhatexto + StrDup(12, "0")
                    linhatexto = linhatexto + StrDup(5, "0")
                    linhatexto = linhatexto + "03"
                    linhatexto = linhatexto + StrDup(12, "0")
                    linhatexto = linhatexto + StrDup(12, "0")

                    linhatexto = linhatexto + nr_aliquota_icms
                    linhatexto = linhatexto + nr_tributacao_icms

                    ' 10 inteiros e 2 decimais (campo 36)
                    If IsDBNull(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_preco_total")) Then
                        nr_valor = "0"
                        valor_base_icms = 0
                    Else
                        nr_valor = CStr(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_preco_total"))
                        valor_base_icms = Convert.ToDecimal(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_preco_total"))
                    End If
                    nr_valor = CStr(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_preco_total"))
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
                    linhatexto = linhatexto + nr_valor     ' Preço Total (Base ICMS)

                    'Calcula ICMS
                    nr_valor = Round((valor_base_icms * valor_aliquota_icms) / 100, 2)
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
                    linhatexto = linhatexto + nr_valor     ' ICMS

                    linhatexto = linhatexto + StrDup(13, "0")
                    linhatexto = linhatexto + StrDup(13, "0")
                    linhatexto = linhatexto + StrDup(12, "0")
                    linhatexto = linhatexto + "nao"

                    ' 08/10/2008 - i
                    'linhatexto = linhatexto + Space(2000)   ' Campo Narrativa
                    If IsDBNull(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("ds_narrativa")) Then
                        ds_narrativa = Space(2000)
                    Else
                        ds_narrativa = CStr(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("ds_narrativa"))
                        ds_narrativa = Left(ds_narrativa + StrDup(2000 - Len(ds_narrativa), " "), 2000)
                    End If
                    linhatexto = linhatexto + ds_narrativa      ' 29/10/2008
                    ' 08/10/2008 - f

                    linhatexto = linhatexto + Space(5)
                    linhatexto = linhatexto + Space(16)
                    linhatexto = linhatexto + Space(6)

                    ' Campo sequencia
                    ' 29/10/2008 - i
                    'nr_valor = CStr(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_sequencia"))
                    'nr_valor = Left(StrDup(3 - Len(nr_valor), "0") + nr_valor, 3)
                    'linhatexto = linhatexto + nr_valor
                    linhatexto = linhatexto + "000"
                    ' 29/10/2008 - f

                    linhatexto = linhatexto + StrDup(8, "0")
                    linhatexto = linhatexto + StrDup(12, "0")
                    linhatexto = linhatexto + StrDup(12, "0")
                    linhatexto = linhatexto + StrDup(12, "0")
                    linhatexto = linhatexto + StrDup(12, "0")
                    linhatexto = linhatexto + StrDup(12, "0")
                    linhatexto = linhatexto + StrDup(12, "0")

                    ArquivoTexto.WriteLine(linhatexto)   ' Registro Tipo 2
                Next

                '====================================================================================
                ' Registro Tipo 3  - Duplicatas
                '====================================================================================
                Dim duplicatanotafiscal As New DuplicataNotaFiscal
                duplicatanotafiscal.id_nota_fiscal = dsNotaFiscal.Tables(0).Rows(li).Item("id_nota_fiscal")
                Dim dsNotaFiscalDup As DataSet = duplicatanotafiscal.getDuplicatasNotasByFilters()

                For li_dup = 0 To dsNotaFiscalDup.Tables(0).Rows.Count - 1
                    linhatexto = ""
                    linhatexto = linhatexto + "3"

                    ' 29/10/2008 - i
                    'linhatexto = linhatexto + "01"
                    nr_parcela = dsNotaFiscalDup.Tables(0).Rows(li_dup).Item("nr_parcela")
                    nr_parcela = Left(StrDup(2 - Len(nr_parcela), "0") + nr_parcela, 2)
                    linhatexto = linhatexto + nr_parcela
                    ' 29/10/2008 - f

                    nr_duplicata = Left(dsNotaFiscalDup.Tables(0).Rows(li_dup).Item("nr_duplicata"), 16)
                    nr_duplicata = Left(nr_duplicata + StrDup(16 - Len(nr_duplicata), " "), 16)
                    linhatexto = linhatexto + nr_duplicata

                    'linhatexto = linhatexto + especie_nf
                    linhatexto = linhatexto + "DJ"   ' 29/10/2008

                    linhatexto = linhatexto + "206"

                    ' Data de vencimento (utilizar a data de emissão da Nota Fiscal
                    If IsDBNull(dsNotaFiscal.Tables(0).Rows(li).Item("dt_emissao")) Then
                        linhatexto = linhatexto + StrDup(8, "0")
                    Else
                        dt_duplicata = Convert.ToDateTime(dsNotaFiscal.Tables(0).Rows(li).Item("dt_emissao"))
                        If Day(dt_duplicata) >= 1 And Day(dt_duplicata) <= 15 Then
                            dt_duplicata = DateAdd(DateInterval.Month, 1, dt_duplicata)
                        Else
                            dt_duplicata = DateAdd(DateInterval.Month, 2, dt_duplicata)
                        End If
                    End If
                    linhatexto = linhatexto + "01" + DateTime.Parse(dt_duplicata).ToString("MMyyyy")


                    ' 11 inteiros e 2 decimais (campo 7 - Valor da Duplicata)
                    nr_valor = CStr(dsNotaFiscalDup.Tables(0).Rows(li_dup).Item("nr_valor_duplicata"))
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
                    linhatexto = linhatexto + nr_valor     ' Somatória dos Preços Unitários dos itens

                    linhatexto = linhatexto + StrDup(13, "0")
                    linhatexto = linhatexto + "?       "  ' Data do Vencimento Desconto
                    linhatexto = linhatexto + StrDup(5, "0")

                    ArquivoTexto.WriteLine(linhatexto)   ' Registro Tipo 3

                    ' 29/10/2008 - i
                    ''====================================================================================
                    '' Registro Tipo 4  - Impostos da Duplicata
                    ''====================================================================================

                    'linhatexto = ""
                    'linhatexto = linhatexto + "4"
                    'linhatexto = linhatexto + StrDup(4, "0")
                    'linhatexto = linhatexto + Space(2)
                    'linhatexto = linhatexto + "????????"  ' Data do Vencimento 
                    'linhatexto = linhatexto + StrDup(11, "0")
                    'linhatexto = linhatexto + StrDup(5, "0")
                    'linhatexto = linhatexto + StrDup(14, "0")
                    'linhatexto = linhatexto + StrDup(3, "0")
                    'linhatexto = linhatexto + StrDup(5, "0")

                    'ArquivoTexto.WriteLine(linhatexto)   ' Registro Tipo 4
                    ' 29/10/2008 - f

                Next

                ' 29/10/2008 - i
                ''====================================================================================
                '' Registro Tipo 5
                ''====================================================================================

                'linhatexto = ""
                'linhatexto = linhatexto + "5"
                'linhatexto = linhatexto + Space(3)
                'linhatexto = linhatexto + StrDup(7, "0")

                'ArquivoTexto.WriteLine(linhatexto)   ' Registro Tipo 5
                ' 29/10/2008 - f

                ' 06/10/2008 - Atualiza Data e Status de Exportação
                Me.id_nota_fiscal = dsNotaFiscal.Tables(0).Rows(li).Item("id_nota_fiscal")
                Me.updateNotaFiscalExportacao()   ' Atualiza Status=S e data de exportacao

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

    Public Function exportNotaFiscalProdutor() As Boolean  ' 01/12/2008

        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim li As Int32
            Dim linhatexto As String
            Dim liexportada As Int32

            Dim idestabelecimento As Int32
            Dim dsrowfichaitem As DataRow
            Dim cta0010_valor As Decimal
            'Dim ctaInsumos_valor As Decimal
            Dim cta4000_valor As Decimal
            Dim cta0041_valor As Decimal
            Dim cta1400_valor As Decimal
            Dim cta1200_valor As Decimal
            Dim cta1300_valor As Decimal
            Dim cta1500_valor As Decimal
            'Dim cta1600_valor As Decimal 'fran 12/04/2010 i chamado 772
            Dim cta2055_valor As Decimal 'fran 26/05/2010 i chamado 805
            Dim cta0300_valor As Decimal 'fran 03/05/2010 i chamado 805
            Dim cta0152_valor As Decimal 'fran 12/04/2010 i chamado 772
            Dim media_acidez As Decimal 'fran 12/04/2010 i chamado 772
            Dim incentivo As String 'fran 12/04/2010 i chamado 772
            Dim ctaDesc_valor As Decimal 'Total descontos

            Dim dsfichaitens As DataSet
            Dim naturezaoperacao As New NaturezaOperacao
            Dim dsnaturezaoperacao As DataSet


            Dim usuario As New Usuario(id_modificador)  ' 29/10/2008

            Dim contas As String

            linhatexto = ""


            'BUSCA as propriedades queserao exportadas de acordo com o filtro

            Dim fichafinanceira As New FichaFinanceira
            fichafinanceira.dt_referencia = Me.dt_referencia
            fichafinanceira.st_pagamento = "D"
            fichafinanceira.id_estabelecimento = Me.id_estabelecimento
            fichafinanceira.st_exportacao_nota = Me.st_exportacao
            fichafinanceira.id_grupo = 1
            fichafinanceira.st_emite_nota_fiscal = "N"

            Dim dsNotaFiscal As DataSet = fichafinanceira.getFichaFinanceiraHeader()
            Me.cd_erro = String.Empty 'fran 007/06/2010 

            'Para cada propriedade/produtor/unid producao
            For li = 0 To dsNotaFiscal.Tables(0).Rows.Count - 1


                'Buscando Dados

                'Estabelecimento da Propriedade
                idestabelecimento = dsNotaFiscal.Tables(0).Rows(li).Item("id_estabelecimento")

                'Busca dados da propriedade
                Dim propriedade As New Propriedade(dsNotaFiscal.Tables(0).Rows(li).Item("id_propriedade"))

                'assume que a propriedade cd_natureza_operacao está vazia
                Me.cd_natureza_operacao = String.Empty
                Me.cd_uf = propriedade.cd_uf

                'NATUREZA de OPERAÇÃO
                'Verifica qual o estado da propriedade/produtotr
                Select Case propriedade.cd_uf
                    Case "MG"
                        'Fran 20/05/2009 i  - rls 17.5 chamdo 263 - Incentivo 2.4
                        ''Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" Then
                        'Se NAO TEM incentivo 2,5, NAO TEM transf credito,  NAO TEM incentivo 2,1 e NAO TEM incentivo 2,4
                        If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                            'Fran 20/05/2009 f 
                            Me.cd_natureza_operacao = "1101AH"
                            incentivo = "Sem Incentivo" 'fran 12/04/2010 chamado 772
                        End If
                        'Fran 20/05/2009 i  - rls 17.5 chamdo 263 - Incentivo 2.4
                        ''Se TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        'If propriedade.st_incentivo_fiscal <> "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" Then
                        'Se TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        If propriedade.st_incentivo_fiscal <> "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                            'Fran 20/05/2009 f 
                            Me.cd_natureza_operacao = "1101AS"
                            incentivo = "2.5%" 'fran 12/04/2010 chamado 772
                        End If
                        'Fran 20/05/2009 i  - rls 17.5 chamdo 263 - Incentivo 2.4
                        'Se NAO TEM incentivo 2,5, TEM transf credito e NAO TEM incentivo 2,1
                        'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "S" And propriedade.st_incentivo_21 = "N" Then
                        If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "S" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                            'Fran 20/05/2009 f 
                            Me.cd_natureza_operacao = "1101AS"
                            incentivo = "Sem Incentivo" 'fran 12/04/2010 chamado 772
                        End If
                        'Fran 20/05/2009 i  - rls 17.5 chamdo 263 - Incentivo 2.4
                        'Se NAO TEM incentivo 2,5, NAO TEM transf credito e TEM incentivo 2,1
                        'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "S" Then
                        If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And (propriedade.st_incentivo_21 = "S" Or propriedade.st_incentivo_24 = "S") Then
                            'Fran 20/05/2009 f 
                            Me.cd_natureza_operacao = "1101AH"
                            incentivo = "2.4%" 'fran 12/04/2010 chamado 772
                        End If
                    Case "SP"
                        'Fran 20/05/2009 i  - rls 17.5 chamdo 263 - Incentivo 2.4
                        'Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" Then
                        If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                            'Fran 20/05/2009 f 
                            'poços dde caldas
                            If idestabelecimento = 1 Then
                                Me.cd_natureza_operacao = "2101AS"
                            End If
                            'guara
                            If idestabelecimento = 2 Then
                                Me.cd_natureza_operacao = "1101AP"
                            End If
                            'águas prata
                            If idestabelecimento = 6 Then
                                Me.cd_natureza_operacao = "1101AP"
                            End If
                            If idestabelecimento = 10 Then 'amparo
                                Me.cd_natureza_operacao = "1101AP"
                            End If

                            incentivo = "Sem Incentivo" 'fran 12/04/2010 chamado 772

                        End If
                    Case "RJ"
                        'Fran 20/05/2009 i  - rls 17.5 chamdo 263 - Incentivo 2.4
                        'Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" Then
                        If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                            'Fran 20/05/2009 f 
                            'guara
                            If idestabelecimento = 2 Then
                                Me.cd_natureza_operacao = "2101AF"
                            End If
                            incentivo = "Sem Incentivo" 'fran 12/04/2010 chamado 772

                        End If
                    Case "CE"
                        'Adri 02/03/2010 i  - rls 23.11 chamdo 701 - Regra para estado do Ceará - i
                        If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                            'Maracanaú
                            If idestabelecimento = 9 Then
                                Me.cd_natureza_operacao = "1101AV"
                            End If
                            incentivo = "Sem Incentivo" 'fran 12/04/2010 chamado 772

                        End If
                        'Adri 02/03/2010 i  - rls 23.11 chamdo 701 - Regra para estado do Ceará - f
                    Case Else
                        Me.cd_natureza_operacao = "SEM REGRA"

                End Select
                'Me.cd_natureza_operacao = "1101AO"
                'BUSCA DADOS NATUREZA OPERACAO
                'buscarNaturezaOperacao(propriedade, idestabelecimento)
                'Se encontrou regra
                'fran 07/06/2010 i - se diferente de sem regra e diferente de string.empty
                'If Me.cd_natureza_operacao <> "SEM REGRA" Then
                If Me.cd_natureza_operacao <> "SEM REGRA" And Not Me.cd_natureza_operacao.ToString.Equals(String.Empty) Then
                    'fran 06/07/2010 f
                    'Busca dados no cadastro
                    naturezaoperacao.cd_natureza_operacao = Me.cd_natureza_operacao
                    naturezaoperacao.id_situacao = 1 'ativa
                    dsnaturezaoperacao = naturezaoperacao.getNaturezaOperacoesByFilters
                    'Se nao tem cadstro 
                    If dsnaturezaoperacao.Tables(0).Rows.Count = 0 Then
                        Me.cd_erro = "SEM CADASTRO"
                        Me.nm_erro = "Não existe cadastro para a natureza de operação " & Me.cd_natureza_operacao.ToString & "."
                        Me.cd_natureza_operacao = "SEM CADASTRO"
                    End If
                End If

                'Se não há cadastro para natureza operacao ou não foi encontrada regra, Para a geração do arquivo
                'fran 07/06/2010 i - se diferente de sem regra e diferente de string.empty
                'If Left(Me.cd_natureza_operacao, 3) = "SEM"  Then
                If Left(Me.cd_natureza_operacao, 3) = "SEM" Or Me.cd_natureza_operacao.ToString.Equals(String.Empty) Then
                    'fran 07/06/2010 f - se diferente de sem regra e diferente de string.empty
                    Me.nr_linhaslidas = li
                    Me.nr_linhasexportadas = liexportada
                    'Fran 04/03/2010 i 
                    Me.cd_pessoa = dsNotaFiscal.Tables(0).Rows(li).Item("cd_pessoa")
                    Me.nr_nota_fiscal = dsNotaFiscal.Tables(0).Rows(li).Item("nr_nota_fiscal")
                    Me.nr_serie = dsNotaFiscal.Tables(0).Rows(li).Item("nr_serie")
                    Me.id_propriedade = dsNotaFiscal.Tables(0).Rows(li).Item("id_propriedade")
                    'Fran 04/03/2010 f
                    'fran 07/06/2010 i
                    If Me.cd_natureza_operacao = "SEM REGRA" Then
                        Me.cd_erro = "SEM REGRA"
                        Me.nm_erro = "Não existem regras de natureza de operação especificadas para o estado " & propriedade.cd_uf & "."
                    End If
                    If Me.cd_natureza_operacao.ToString.Equals(String.Empty) Then
                        Me.cd_erro = "SEM NATUREZA"
                        Me.nm_erro = "Para as informações encontradas no cadastro da propriedade, não há regras de natureza de operação especificadas."
                    End If
                    'fran 07/06/2010 f

                    ArquivoTexto.Close()
                    exportNotaFiscalProdutor = False   ' 01/12/2008
                    Exit Try

                End If

                'BUSCA DADOS DAS CONTAS
                fichafinanceira.id_ficha_financeira = dsNotaFiscal.Tables(0).Rows(li).Item("id_ficha_financeira")
                dsfichaitens = fichafinanceira.getFichaFinanceiraItens

                cta0010_valor = 0
                'ctaInsumos_valor = 0
                cta4000_valor = 0
                cta0041_valor = 0
                cta1400_valor = 0
                cta1200_valor = 0
                cta1300_valor = 0
                cta1500_valor = 0
                'cta1600_valor = 0 'fran 12/04/2010 i chamado 772
                cta0152_valor = 0 'fran 12/04/2010 i chamado 772
                cta2055_valor = 0 'fran 26/05/2010 i chamado 805
                cta0300_valor = 0 'fran 03/05/2010 i chamado 805
                ctaDesc_valor = 0

                If dsfichaitens.Tables(0).Rows.Count > 0 Then
                    For Each dsrowfichaitem In dsfichaitens.Tables(0).Rows
                        Select Case UCase(Trim(dsrowfichaitem.Item("cd_conta")))
                            Case "0010" 'Volume Leite
                                cta0010_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "0041" 'Preço NF
                                cta0041_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1200" 'Base ICMS
                                cta1200_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1300" 'ICMS
                                cta1300_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1500" 'Total FUNRURAL
                                cta1500_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1400" 'Total Nota Fiscal
                                cta1400_valor = dsrowfichaitem.Item("nr_valor_conta")
                                'Case "1600" 'incentivo 2.5 Fran 12/04/2010 i chamado 772
                                'cta1600_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "0152" 'teor de gordura fran 12/04/2010 i chamado 772
                                cta0152_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "0300" 'incentivo fiscal 2.5 fran 03/05/2010 i chamado 805
                                cta0300_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2055" 'incentivo 2.4 fran 26/05/2010 i chamado 805
                                cta2055_valor = dsrowfichaitem.Item("nr_valor_conta")
                        End Select

                    Next
                End If

                'Busca Total dos descontos
                ctaDesc_valor = fichafinanceira.getFichaFinanceiraTotalDescontos

                'Fran 12/04/2010 i chamado 772
                'Busca media de acidez (cd_analise=3) dos romaneios para a referencia e propriedade
                fichafinanceira.id_propriedade = Convert.ToInt32(dsNotaFiscal.Tables(0).Rows(li).Item("id_propriedade"))
                fichafinanceira.id_unid_producao = Convert.ToInt32(dsNotaFiscal.Tables(0).Rows(li).Item("id_unid_producao"))
                media_acidez = fichafinanceira.getMediaAcidezbyReferenciaRomaneio()
                'Fran 12/04/2010 f chamado 772

                '====================================================================================
                ' Registro Tipo 1
                '====================================================================================
                'Guarda as contas utilizadas registro tipo 1
                'fran 12/04/2010 i chamado 772
                'contas = "0010=" + Round(cta0010_valor, 4).ToString + "&0041=" + Round(cta0041_valor, 4).ToString + "&1400=" + Round(cta1400_valor, 2).ToString + "&desc=" + Round(ctaDesc_valor, 2).ToString + "&"
                'linhatexto = NotaFiscalProdutor_Registro_1(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0), contas)
                'fran 3/05/2010 i
                'contas = "0010=" + Round(cta0010_valor, 4).ToString + "&0041=" + Round(cta0041_valor, 4).ToString + "&1400=" + Round(cta1400_valor, 2).ToString + "&desc=" + Round(ctaDesc_valor, 2).ToString + "&1600=" + Round(cta1600_valor, 2).ToString + "&0152=" + Round(cta0152_valor, 2).ToString + "&1500=" + Round(cta1500_valor, 2).ToString + "&"
                'linhatexto = NotaFiscalProdutor_Registro_1(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0), contas, incentivo, Round(media_acidez, 4).ToString)
                contas = "0010=" + Round(cta0010_valor, 4).ToString + "&0041=" + Round(cta0041_valor, 4).ToString + "&1400=" + Round(cta1400_valor, 2).ToString + "&desc=" + Round(ctaDesc_valor, 2).ToString + "&0152=" + Round(cta0152_valor, 2).ToString + "&1500=" + Round(cta1500_valor, 2).ToString + "&0300=" + Round(cta0300_valor, 4).ToString + "&2055=" + Round(cta2055_valor, 4).ToString + "&"
                linhatexto = NotaFiscalProdutor_Registro_1(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0), contas, incentivo, Round(media_acidez, 4).ToString, propriedade.cd_uf)
                'fran 3/05/2010 f
                'fran 12/04/2010 f chamado 772
                ArquivoTexto.WriteLine(linhatexto)
                linhatexto = ""


                '====================================================================================
                ' Registro Tipo 2
                '====================================================================================

                'Guarda as contas utilizadas registro tipo 2
                contas = "0010=" + Round(cta0010_valor, 4).ToString + "&0041=" + Round(cta0041_valor, 4).ToString + "&1200=" + Round(cta1200_valor, 2).ToString + "&1300=" + Round(cta1300_valor, 2).ToString + "&1400=" + Round(cta1400_valor, 2).ToString + "&"
                linhatexto = NotaFiscalProdutor_Registro_2(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0), contas)
                ArquivoTexto.WriteLine(linhatexto)
                linhatexto = ""

                '====================================================================================
                ' Registro Tipo 3  - Duplicatas
                '====================================================================================

                'Guarda as contas utilizadas registro tipo 3
                contas = "1400=" + Round(cta1400_valor, 4).ToString + "&desc=" + Round(ctaDesc_valor, 4).ToString + "&"
                linhatexto = NotaFiscalProdutor_Registro_3(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0), contas)
                ArquivoTexto.WriteLine(linhatexto)
                linhatexto = ""

                '====================================================================================
                ' Registro Tipo 4  - Duplicatas
                '====================================================================================
                If cta1500_valor > 0 Then
                    'fran 04/08/2010 i - chamado 811
                    'linhatexto = NotaFiscalProdutor_Registro_4(Me.dt_emissao, cta1400_valor, cta1500_valor)
                    'linhatexto = NotaFiscalProdutor_Registro_4(Me.dt_emissao, "IP", cta1400_valor)
                    linhatexto = NotaFiscalProdutor_Registro_4(Me.dt_emissao, "IQ", cta1400_valor)   ' Adriana 18/08/2010 - Chamado 936 (Trocar código IP para IQ)
                    'fran 04/08/2010 f - chamado 811
                    ArquivoTexto.WriteLine(linhatexto)
                    linhatexto = ""
                    'fran 04/08/2010 i - chamado 811
                    'linhatexto = NotaFiscalProdutor_Registro_4(Me.dt_emissao, "IF", cta1400_valor)
                    linhatexto = NotaFiscalProdutor_Registro_4(Me.dt_emissao, "IZ", cta1400_valor)   ' Adriana 18/08/2010 - Chamado 936 (Trocar código IP para IQ)
                    ArquivoTexto.WriteLine(linhatexto)
                    linhatexto = ""
                    'fran 04/08/2010 f - chamado 811

                End If


                liexportada = liexportada + 1

            Next

            Me.nr_linhaslidas = li
            Me.nr_linhasexportadas = liexportada
            If liexportada > 0 Then
                exportNotaFiscalProdutor = True 'fran 07/06/2010 
                ' 06/10/2008 - Atualiza Data e Status de Exportação
                fichafinanceira.id_modificador = Me.id_modificador
                fichafinanceira.updateFichaFinanceiraExportacaoNF()   ' Atualiza Status=S e data de exportacao
            Else 'fran 07/06/2010
                exportNotaFiscalProdutor = False
                Me.cd_erro = "SEM LINHAS"
                Me.nm_erro = "Nenhum registro foi encontrado para geração do arquivo de nota fiscal do produtor."
            End If
            ArquivoTexto.Close()

            'exportNotaFiscalProdutor = True   ' 01/12/2008 'fran 07/06/2010

        Catch ex As Exception
            exportNotaFiscalProdutor = False   ' 01/12/2008
            'fran 07/06/2010 i
            Me.cd_erro = "EXCEPTION"
            Me.nm_erro = ex.Message.ToString
            'fran 07/06/2010 f

            ' 01/12/2008 - i
            Dim calculoexecucao As New CalculoExecucao
            calculoexecucao.nm_erro = ex.Message
            calculoexecucao.insertCalculoExecucaoErro()
            ' 01/12/2008 - f
            ArquivoTexto.Close()
            'Throw New Exception(ex.Message)

        End Try

    End Function
    Private Function NotaFiscalProdutor_Registro_1(ByVal pRegistro As DataRow, ByVal pdsNaturezaOperacao As DataRow, ByVal pContas As String, ByVal pIncentivo As String, ByVal pMedia_Acidez As String, ByVal pCd_UF As String) As String

        'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim linhatexto As String
            Dim lpos As Int16

            ' Registro 1
            Dim cd_registro As String
            Dim numero_notafiscal As String
            Dim nr_nota_fiscal_formatado As String    ' 24/11/2008
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
            Dim cta_0010 As String
            Dim cta_0041 As String
            Dim cta_1400 As String
            Dim cta_desc As String
            'Dim cta_1600 As String 'Fran 12/04/2010 i chamado 772
            Dim cta_0152 As String 'Fran 12/04/2010 i chamado 772
            Dim cta_1500 As String 'Fran 12/04/2010 i chamado 772
            Dim obs As String 'Fran 12/04/2010 i chamado 772
            Dim cta_2055 As String 'Fran 26/05/2010 i chamado 805
            Dim cta_0300 As String 'Fran 03/05/2010 i chamado 805
            Dim lposfim As Integer

            Dim especie_nf As String
            Dim usuario_responsavel As String

            Dim usuario As New Usuario(Me.id_modificador)


            lpos = InStr(1, pContas, "0010=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0010 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0041=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0041 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "1400=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_1400 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "desc=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_desc = Mid(pContas, lpos, lposfim - lpos)
            'Fran 12/04/2010 i chamado 772
            'lpos = InStr(1, pContas, "1600=", 1) + 5
            'lposfim = InStr(lpos, pContas, "&", 1)
            'cta_1600 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0152=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0152 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "1500=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_1500 = Mid(pContas, lpos, lposfim - lpos)
            'Fran 12/04/2010 f chamado 772
            'Fran 03/05/2010 i chamado 805
            lpos = InStr(1, pContas, "0300=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0300 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2055=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2055 = Mid(pContas, lpos, lposfim - lpos)
            'Fran 03/05/2010 f chamado 805

            linhatexto = ""

            '====================================================================================
            ' Registro Tipo 1
            '====================================================================================

            cd_registro = "1"  ' Registro tipo 1

            If IsDBNull(pRegistro.Item("nr_serie")) Then
                serie_notafiscal = Space(5)
            Else
                serie_notafiscal = pRegistro.Item("nr_serie")
                serie_notafiscal = Left(serie_notafiscal + StrDup(5 - Len(serie_notafiscal), " "), 5)
            End If

            ' 24/11/2008 - i
            'numero_notafiscal = pRegistro.Item("nr_nota_fiscal")
            nr_nota_fiscal_formatado = CStr(pRegistro.Item("nr_nota_fiscal"))
            nr_nota_fiscal_formatado = Left(StrDup(7 - Len(nr_nota_fiscal_formatado), "0") + nr_nota_fiscal_formatado, 7)
            numero_notafiscal = Left(nr_nota_fiscal_formatado + StrDup(16 - Len(nr_nota_fiscal_formatado), " "), 16)
            ' 24/11/2008 - f

            cd_emitente = pRegistro.Item("cd_pessoa")
            cd_emitente = Left(StrDup(6 - Len(cd_emitente), "0") + cd_emitente, 6)

            cd_natureza_operacao = Me.cd_natureza_operacao
            cd_natureza_operacao = Left(cd_natureza_operacao + StrDup(6 - Len(cd_natureza_operacao), " "), 6)

            'Dim estabelecimento As New Estabelecimento(pRegistro.Item("id_estabelecimento"))
            cd_estabelecimento = Space(3)
            cd_estabelecimento = pRegistro.Item("cd_estabelecimento")
            cd_estabelecimento = Left(cd_estabelecimento + StrDup(3 - Len(cd_estabelecimento), " "), 3)

            cd_estabelecimento_fiscal = cd_estabelecimento

            'Preciso saber qual o cd_natureza_operacao para depois buscar conta contabil no cadastro
            conta_contabil = Left(pdsNaturezaOperacao.Item("nr_conta_transitoria").ToString + StrDup(17, " "), 17)


            'Data de emissão - ultimo dia do mês de referencia
            dt_emissao = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateTime.Parse(Me.dt_referencia.ToString))).ToString("ddMMyyyy")
            dt_transacao = dt_emissao

            usuario_responsavel = usuario.ds_login
            usuario_responsavel = Left(usuario_responsavel + StrDup(12 - Len(usuario_responsavel), " "), 12)
            'linhatexto = linhatexto + usuario_responsavel

            If IsDBNull(Me.cd_uf) Then
                cd_uf = Space(4)
            Else
                cd_uf = Me.cd_uf
                cd_uf = Left(cd_uf + StrDup(4 - Len(cd_uf), " "), 4)   ' 29/10/2008
            End If

            cd_frete = "01"

            nr_valor = cta_0010
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                peso_total = CStr(nr_valor)
                peso_total = Left(StrDup(10 - Len(peso_total), "0") + peso_total, 10)
                peso_total = nr_valor & "0000"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), "0") + nr_valor_int, 10)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            peso_total = nr_valor

            ' Adri - 28/11/2008 - i
            'Total dos descontos => Somatoria das contas com natureza 2 + 0081, 0091,0101,0102
            'nr_valor = cta_desc
            'lpos = InStr(1, nr_valor, ",", 1)
            'If lpos = 0 Then   ' Se não tem casas decimais
            '    nr_valor = CStr(nr_valor)
            '    nr_valor = Left(StrDup(11 - Len(nr_valor), "0") + nr_valor, 11)
            '    nr_valor = nr_valor & "00"
            'Else
            '    nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
            '    nr_valor_int = Left(StrDup(11 - Len(nr_valor_int), "0") + nr_valor_int, 11)
            '    nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
            '    nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
            '    nr_valor = nr_valor_int & nr_valor_dec
            'End If
            'total_descontos = nr_valor
            total_descontos = "0000000000000"
            ' Adri - 28/11/2008 - f

            ' Adri - 28/11/2008 - i
            ' 11 inteiros e 2 decimais (campo 23-Valor da Mercadoria)
            'nr_valor = CStr(Round(CDbl(cta_0010) * CDbl(cta_0041), 2))  ' 29/10/2008
            nr_valor = CStr(cta_1400)
            ' Adri - 28/11/2008 - f
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
            valor_mercadoria = nr_valor
            ' Adri - 28/11/2008 - f

            ' 13 inteiros e 2 decimais (campo 26-Valor Total da Nota)
            nr_valor = CStr(cta_1400)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(13 - Len(nr_valor), "0") + nr_valor, 13)
                nr_valor = nr_valor & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(13 - Len(nr_valor_int), "0") + nr_valor_int, 13)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            valor_total_nota = nr_valor

            especie_nf = "21"
            'fran i chamado 772 12/04/2010
            'Quantidade recebida (total mensal)
            nr_valor = cta_0010
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = Trim(CStr(nr_valor))
            Else
                nr_valor = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
            End If

            'Fran 02/06/2010 i chamado 859
            'obs = "Quantidade Recebida: " & nr_valor & " litros" & Space(70 - 28 - Len(nr_valor))
            'Fran 03/05/2010 i chamado 805 
            'obs = "Quantidade Recebida: " & nr_valor & " litros" & Space(118 - 28 - Len(nr_valor))
            'Fran 03/05/2010 f chamado 805 
            obs = "Quantidade Recebida: " & nr_valor & " litros" & Space(109 - 28 - Len(nr_valor))
            'Fran 02/06/2010 f chamado 859

            'Preço do Leite recebido
            'Fran 26/05/2010 i chamado 805
            'nr_valor = CStr(cta_0041)
            'o mesmo vavlor do campo valor unitário impresso na nota (total nota / volume leite)
            nr_valor = CStr(Round(CDbl(cta_1400) / CDbl(cta_0010), 2))
            'Fran 26/05/2010 f chamado 805
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                'Fran 02/06/2010 i chamado 859
                'nr_valor = Trim(CStr(nr_valor))
                nr_valor = Trim(CStr(nr_valor)) & ",00"
                'Fran 02/06/2010 f chamado 859
            Else
                nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If

            'Fran 03/05/2010 i chamado 805 
            'obs = obs & "Preço do Leite Recebido: R$ " & nr_valor & Space(70 - 28 - Len(nr_valor))
            'Fran 02/06/2010 i chamado 859
            'obs = obs & "Preço do Leite Recebido: R$ " & nr_valor & Space(118 - 28 - Len(nr_valor))
            obs = obs & "Preço do Leite Recebido: R$ " & nr_valor & Space(109 - 28 - Len(nr_valor))
            'Fran 02/06/2010 f chamado 859
            'Fran 03/05/2010 f chamado 805 

            'Grau de acidez - será informado a media dos resultados de acidez
            nr_valor = CStr(pMedia_Acidez)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                'Fran 02/06/2010 i chamado 859
                'nr_valor = Trim(CStr(nr_valor))
                nr_valor = Trim(CStr(nr_valor)) & ",0000"
                'Fran 02/06/2010 f chamado 859
            Else
                nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            'Fran 03/05/2010 i chamado 805 
            'obs = obs & "Grau de Acidez: " & nr_valor & Space(70 - 16 - Len(nr_valor))
            'Fran 02/06/2010 i chamado 859
            'obs = obs & "Grau de Acidez: " & nr_valor & Space(118 - 16 - Len(nr_valor))
            obs = obs & "Grau de Acidez: " & nr_valor & Space(109 - 16 - Len(nr_valor))
            'Fran 02/06/2010 f chamado 859
            'Fran 03/05/2010 f chamado 805 

            'Teor de Gordura
            nr_valor = CStr(cta_0152)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                'Fran 02/06/2010 i chamado 859
                'nr_valor = Trim(CStr(nr_valor))
                nr_valor = Trim(CStr(nr_valor)) & ",0000"
                'Fran 02/06/2010 f chamado 859

            Else
                nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If

            'Fran 03/05/2010 i chamado 805 
            'obs = obs & "Teor de Gordura: " & nr_valor & Space(70 - 17 - Len(nr_valor))
            'Fran 02/06/2010 i chamado 859
            'obs = obs & "Teor de Gordura: " & nr_valor & Space(118 - 17 - Len(nr_valor))
            obs = obs & "Teor de Gordura: " & nr_valor & Space(109 - 17 - Len(nr_valor))
            'Fran 02/06/2010 f chamado 859
            'Fran 03/05/2010 f chamado 805 

            'Aplicabilidade: Leite indústria
            'Fran 03/05/2010 i chamado 805 
            'obs = obs & "Aplicabilidade: Leite Indústria" & Space(70 - 31)
            'Fran 02/06/2010 i chamado 859
            'obs = obs & "Aplicabilidade: Leite Indústria" & Space(118 - 31)
            obs = obs & "Aplicabilidade: Leite Indústria" & Space(109 - 31)
            'Fran 02/06/2010 f chamado 859
            'Fran 03/05/2010 f chamado 805 

            'Incentivo à produção e à industrialização do leite (2,5%)
            'fran 03/05/2010 i chmado 805
            'nr_valor = CStr(cta_1600)
            nr_valor = CStr(Round(CDbl(cta_0300) * CDbl(cta_0010), 2))
            'fran 03/05/2010 f chmado 805
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                'Fran 02/06/2010 i chamado 859
                'nr_valor = Trim(CStr(nr_valor))
                nr_valor = Trim(CStr(nr_valor)) & ",00"
                'Fran 02/06/2010 f chamado 859
            Else
                nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4, "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If

            'Fran 03/05/2010 i chamado 805 
            'obs = obs & "Incentivo à produção e industrialização do leite(2,5%): R$" & nr_valor & Space(70 - 58 - Len(nr_valor))
            If CInt(nr_valor) > 0 Then
                'Fran 02/06/2010 i chamado 859
                'obs = obs & "Incentivo à produção e à industrialização do leite(2,5%): R$" & nr_valor & Space(118 - 60 - Len(nr_valor))
                obs = obs & "Incentivo à produção e à industrialização do leite(2,5%): R$ " & nr_valor & Space(109 - 61 - Len(nr_valor))
                'Fran 02/06/2010 f chamado 859

            End If
            'Fran 03/05/2010 f chamado 805 

            'fran 26/05/2010 i chamado 805
            'Incentivo à produção e à industrialização do leite (2,4%)
            nr_valor = CStr(Round(CDbl(cta_2055), 2))
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                'Fran 02/06/2010 i chamado 859
                'nr_valor = Trim(CStr(nr_valor))
                nr_valor = Trim(CStr(nr_valor)) & ",00"
                'Fran 02/06/2010 f chamado 859
            Else
                nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4, "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If

            If CInt(nr_valor) > 0 Then
                'Fran 02/06/2010 i chamado 859
                'obs = obs & "Incentivo à produção e à industrialização do leite(2,4%): R$" & nr_valor & Space(118 - 60 - Len(nr_valor))
                obs = obs & "Incentivo à produção e à industrialização do leite(2,4%): R$ " & nr_valor & Space(109 - 61 - Len(nr_valor))
                'Fran 02/06/2010 f chamado 859
            End If
            'Fran 26/05/2010 f chamado 805 

            'INSS Produtor Rural
            nr_valor = CStr(cta_1500)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                'Fran 02/06/2010 i chamado 859
                'nr_valor = Trim(CStr(nr_valor))
                nr_valor = Trim(CStr(nr_valor)) & ",00"
                'Fran 02/06/2010 f chamado 859
            Else
                nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4, "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If

            'Fran 03/05/2010 i chamado 805 
            'obs = obs & "INSS Produtor Rural: R$ " & nr_valor & Space(70 - 24 - Len(nr_valor))
            'Fran 02/06/2010 i chamado 859
            'obs = obs & "INSS Produtor Rural: R$ " & nr_valor & Space(118 - 24 - Len(nr_valor))
            obs = obs & "INSS Produtor Rural: R$ " & nr_valor & Space(109 - 24 - Len(nr_valor))
            'Fran 02/06/2010 f chamado 859
            'Fran 03/05/2010 f chamado 805 

            'Mensagens CFOP
            Select Case Trim(pIncentivo)
                Case "Sem Incentivo"
                    'Fran 03/05/2010 i chamado 805 
                    'obs = obs & "Operação Isenta - art. 459 da Parte 1 do Anexo IX do RICMS" & Space(70 - 58)
                    'Fran 02/06/2010 i chamado 859
                    'obs = obs & "Operação Isenta - art. 459 da Parte 1 do Anexo IX do RICMS" & Space(118 - 58)
                    obs = obs & "Operação Isenta - art. 459 da Parte 1 do Anexo IX do RICMS" & Space(109 - 58)
                    'Fran 02/06/2010 f chamado 859
                    'Fran 03/05/2010 f chamado 805 
                Case "2.4%"
                    'Fran 03/05/2010 i chamado 805 
                    'obs = obs & "Ressarcimento ao Produtor - art. 75, XXXIII, do RICMS" & Space(70 - 53)
                    'Fran 02/06/2010 i chamado 859
                    'obs = obs & "Ressarcimento ao Produtor - art. 75, XXXIII, do RICMS" & Space(118 - 53)
                    obs = obs & "Ressarcimento ao Produtor - art. 75, XXXIII, do RICMS" & Space(109 - 53)
                    'Fran 02/06/2010 f chamado 859
                    'Fran 03/05/2010 f chamado 805 
                Case "2.5%"
                    'Fran 03/05/2010 i chamado 805 
                    'obs = obs & "Operação tributada nos termos do art.461 Parte 1 do Anexo IX do RICMS" & Space(70 - 69)
                    'Fran 02/06/2010 i chamado 859
                    'obs = obs & "Operação tributada nos termos do art. 461 Parte 1 do Anexo IX do RICMS" & Space(118 - 70)
                    obs = obs & "Operação tributada nos termos do art. 461 Parte 1 do Anexo IX do RICMS" & Space(109 - 70)
                    'Fran 02/06/2010 f chamado 859
                    'Fran 03/05/2010 f chamado 805 
            End Select

            obs = Left(obs & Space(2000 - Len(obs)), 2000)
            'fran f chamado 772 12/04/2010

            'Fran i 03/05/2010 
            If pCd_UF.Trim.ToString <> "MG" Then
                obs = Space(2000)
            End If
            'Fran f 03/05/2010 

            'Monta a linha a ser inserida no arquivo texto
            linhatexto = cd_registro + serie_notafiscal + numero_notafiscal + cd_emitente
            linhatexto = linhatexto + cd_natureza_operacao + "1" + cd_estabelecimento + cd_estabelecimento_fiscal
            linhatexto = linhatexto + conta_contabil + dt_emissao + dt_transacao + usuario_responsavel
            linhatexto = linhatexto + cd_uf + "1" + cd_frete + "nao" + peso_total
            linhatexto = linhatexto + total_descontos
            linhatexto = linhatexto + StrDup(13, "0")
            linhatexto = linhatexto + StrDup(13, "0")
            linhatexto = linhatexto + StrDup(13, "0")
            linhatexto = linhatexto + StrDup(13, "0")
            'linhatexto = linhatexto + valor_mercadoria + "?       " + "?       "
            linhatexto = linhatexto + valor_mercadoria + dt_emissao + dt_emissao   ' Adri 02/03/2010 - chamdo 701
            linhatexto = linhatexto + valor_total_nota + "2" + especie_nf
            linhatexto = linhatexto + "0"
            'fran 12/04/2010 i chamado 772
            'linhatexto = linhatexto + Space(2000)
            linhatexto = linhatexto + obs
            'fran 12/04/2010 f chamado 772
            linhatexto = linhatexto + Space(12)
            linhatexto = linhatexto + Space(7)
            linhatexto = linhatexto + Space(7)
            linhatexto = linhatexto + Space(7)
            linhatexto = linhatexto + Space(2)
            linhatexto = linhatexto + Space(2)
            linhatexto = linhatexto + Space(2)
            'linhatexto = linhatexto + Space(60)
            linhatexto = linhatexto + Space(61)
            linhatexto = linhatexto + "0"

            NotaFiscalProdutor_Registro_1 = linhatexto

        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    Private Function NotaFiscalProdutor_Registro_2(ByVal pRegistro As DataRow, ByVal pdsNaturezaOperacao As DataRow, ByVal pcontas As String) As String

        'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

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

            Dim valor_aliquota_icms As Decimal

            Dim usuario As New Usuario(id_modificador)

            Dim dsNotaFiscal As DataSet = Me.getNotasFiscaisByFilters()
            Dim item As New Item(1)
            Dim lposfim As Integer
            Dim cta_0010 As String
            Dim cta_0041 As String
            Dim cta_1200 As String
            Dim cta_1300 As String
            Dim cta_1400 As String

            linhatexto = ""

            lpos = InStr(1, pcontas, "0010=", 1) + 5
            lposfim = InStr(lpos, pcontas, "&", 1)
            cta_0010 = Mid(pcontas, lpos, lposfim - lpos)
            lpos = InStr(1, pcontas, "0041=", 1) + 5
            lposfim = InStr(lpos, pcontas, "&", 1)
            cta_0041 = Mid(pcontas, lpos, lposfim - lpos)
            lpos = InStr(1, pcontas, "1200=", 1) + 5
            lposfim = InStr(lpos, pcontas, "&", 1)
            cta_1200 = Mid(pcontas, lpos, lposfim - lpos)
            lpos = InStr(1, pcontas, "1300=", 1) + 5
            lposfim = InStr(lpos, pcontas, "&", 1)
            cta_1300 = Mid(pcontas, lpos, lposfim - lpos)
            lpos = InStr(1, pcontas, "1400=", 1) + 5
            lposfim = InStr(lpos, pcontas, "&", 1)
            cta_1400 = Mid(pcontas, lpos, lposfim - lpos)

            '====================================================================================
            ' Registro Tipo 2
            '====================================================================================
            linhatexto = ""
            cd_registro = "2"  ' Registro tipo 1

            cd_item = Left(item.cd_item, 16)
            cd_item = Left(cd_item + StrDup(16 - Len(cd_item), " "), 16)

            ' 10 inteiros e 4 decimais (campo 14-Qtde digitada na tela)
            nr_valor = CStr(cta_0010)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(10 - Len(nr_valor), "0") + nr_valor, 10)
                nr_valor = nr_valor & "0000"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), "0") + nr_valor_int, 10)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            qtde_med_emitente = nr_valor

            ' 8 inteiros e 4 decimais (campo 15-Qtde na nossa unidade de medida)
            nr_valor = CStr(cta_0010)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(8 - Len(nr_valor), "0") + nr_valor, 8)
                nr_valor = nr_valor & "0000"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), "0") + nr_valor_int, 8)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            qtde_med_nossa = nr_valor

            ' 10 inteiros e 2 decimais (campo 16)
            'nr_valor = CStr(cta_0010 * cta_0041)
            'nr_valor = CStr(Round(CDbl(cta_0010) * CDbl(cta_0041), 2))  ' 29/10/2008
            nr_valor = CStr(cta_1400)   ' Adri 28/11/2008

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
            preco_total_item = nr_valor

            ' 7 inteiros e 5 decimais (campo 20)
            nr_valor = CStr(cta_0010)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(7 - Len(nr_valor), "0") + nr_valor, 7)
                nr_valor = nr_valor & "00000"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(7 - Len(nr_valor_int), "0") + nr_valor_int, 7)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(5 - Len(nr_valor_dec), "0"), 5)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            peso_liquido = nr_valor     ' Peso Líquido

            cd_classificacao_fiscal = Left(item.cd_classificacao_fiscal, 8)
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
                nr_valor = CStr(cta_1200)
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
                base_calculo_ipi = nr_valor     ' Preço Total (Base IPI)


                ' 10 inteiros e 2 decimais (campo 29) Valor IPI
                'base_calculo_ipi * nr_aliquota_ipi
                If IsDBNull(pdsNaturezaOperacao.Item("nr_aliquota_ipi")) Then
                    nr_valor = "0"
                Else
                    nr_valor = pdsNaturezaOperacao.Item("nr_aliquota_ipi")
                End If
                nr_valor = CStr(Round(CDbl(cta_1200) * CDbl(nr_valor), 2))  ' 29/10/2008
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
            If cta_1200 = "" Then
                nr_valor = "0"
            Else
                nr_valor = CStr(cta_1200)
                'valor_base_icms = Convert.ToDecimal(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_preco_total"))
            End If
            'nr_valor = CStr(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_preco_total"))
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
            base_calculo_icms = nr_valor     ' Preço Total (Base ICMS)

            'Calcula ICMS
            nr_valor = cta_1300
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

            'Se icms = 3 Outros 
            If nr_tributacao_icms = "03" Then
                ' 10 inteiros e 2 decimais (campo 48)
                '12/12/2008 i
                'nr_valor = CStr(cta_1400)
                nr_valor = CStr(CDec(cta_1400) - CDec(cta_1200))
                '12/12/2008 f
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
                valor_icms_outras = nr_valor

                'valor_icms_outras = base_calculo_icms     ' valor do icms outras = base icms
            Else
                valor_icms_outras = StrDup(12, "0")
            End If
            'Se ipi = 3 Outros
            If nr_tributacao_ipi = "03" Then
                ' 10 inteiros e 2 decimais (campo 50)
                nr_valor = CStr(cta_1400)

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
                valor_ipi_outras = nr_valor

                'valor_ipi_outras = base_calculo_icms     ' valor do ipi outras = base icms
            Else
                valor_ipi_outras = StrDup(12, "0")
            End If
            'Se icms = 2 Isento
            If nr_tributacao_icms = "02" Then
                ' 10 inteiros e 2 decimais (campo 51)
                nr_valor = CStr(cta_1400)
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
                valor_icms_isento = nr_valor
                'valor_icms_isento = base_calculo_icms     ' valor do icms isento = base icms
            Else
                valor_icms_isento = StrDup(12, "0")
            End If
            'Se ipi = 2 isento
            If nr_tributacao_ipi = "02" Then
                ' 10 inteiros e 2 decimais (campo 52)
                nr_valor = CStr(cta_1400)
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
                valor_ipi_isento = nr_valor
                'valor_ipi_isento = base_calculo_icms     ' valor do ipi isento = base icms
            Else
                valor_ipi_isento = StrDup(12, "0")
            End If

            linhatexto = linhatexto + cd_registro + cd_item
            linhatexto = linhatexto + Space(8) + StrDup(8, "0") + StrDup(5, "0")
            linhatexto = linhatexto + "nao" + StrDup(9, "0") + Space(16)
            linhatexto = linhatexto + StrDup(4, "0") + Space(16) + Space(17)
            linhatexto = linhatexto + "sim" + StrDup(3, "0")
            linhatexto = linhatexto + qtde_med_emitente + qtde_med_nossa + preco_total_item
            linhatexto = linhatexto + StrDup(12, "0") + StrDup(12, "0") + StrDup(12, "0")
            linhatexto = linhatexto + peso_liquido + "RCP" + Space(10) + Space(10)
            linhatexto = linhatexto + "31122999" + cd_classificacao_fiscal
            linhatexto = linhatexto + nr_aliquota_ipi + nr_tributacao_ipi + base_calculo_ipi + valor_ipi
            linhatexto = linhatexto + StrDup(5, "0") + "03"
            linhatexto = linhatexto + StrDup(12, "0") + StrDup(12, "0")
            linhatexto = linhatexto + nr_aliquota_icms + nr_tributacao_icms + base_calculo_icms + valor_icms
            linhatexto = linhatexto + StrDup(13, "0") + StrDup(13, "0") + StrDup(12, "0")
            linhatexto = linhatexto + "nao" + Space(2000) + Space(5) + Space(16) + Space(6)
            linhatexto = linhatexto + "010" + StrDup(8, "0") + valor_icms_outras + valor_ipi_outras
            linhatexto = linhatexto + StrDup(12, "0") + valor_icms_isento + valor_ipi_isento + StrDup(12, "0")

            NotaFiscalProdutor_Registro_2 = linhatexto
        Catch ex As Exception
            '   ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    Private Function NotaFiscalProdutor_Registro_3(ByVal pRegistro As DataRow, ByVal pdsNaturezaOperacao As DataRow, ByVal pcontas As String) As String

        'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim linhatexto As String
            Dim lpos As Int16
            Dim nr_valor As String
            Dim nr_valor_int As String
            Dim nr_valor_dec As String

            ' Registro 3
            Dim cd_registro As String
            Dim nr_parcela As String
            Dim nr_duplicata As String
            Dim tp_especie As String
            Dim dt_duplicata As Date
            Dim dt_vencto As String
            Dim dia_pagto As Integer

            Dim lposfim As Integer
            Dim cta_1400 As String
            Dim cta_desc As String

            linhatexto = ""

            lpos = InStr(1, pcontas, "1400=", 1) + 5
            lposfim = InStr(lpos, pcontas, "&", 1)
            cta_1400 = Mid(pcontas, lpos, lposfim - lpos)
            lpos = InStr(1, pcontas, "desc=", 1) + 5
            lposfim = InStr(lpos, pcontas, "&", 1)
            cta_desc = Mid(pcontas, lpos, lposfim - lpos)
            '====================================================================================
            ' Registro Tipo 3  - Duplicatas
            '====================================================================================

            linhatexto = ""

            cd_registro = "3"
            nr_parcela = "01"

            ' 28/11/2008 - i
            'nr_duplicata = Left(pRegistro.Item("nr_nota_fiscal"), 16)
            'nr_duplicata = Left(nr_duplicata + StrDup(16 - Len(nr_duplicata), " "), 16)
            nr_duplicata = CStr(pRegistro.Item("nr_nota_fiscal"))
            nr_duplicata = Left(StrDup(7 - Len(nr_duplicata), "0") + nr_duplicata, 7)
            nr_duplicata = Left(nr_duplicata + StrDup(16 - Len(nr_duplicata), " "), 16)
            ' 28/11/2008 - f

            ' 28/11/2008 - i
            'tp_especie = Left(pdsNaturezaOperacao.Item("ds_tipo_especie"), 2)
            'tp_especie = Left(tp_especie + StrDup(2 - Len(tp_especie), " "), 2)
            If pRegistro("st_categoria") = "F" Then
                tp_especie = "DL"
            Else
                tp_especie = "DJ"
            End If
            ' 28/11/2008 - f

            Dim faixapgtoprodutor As New FaixaPagamentoProdutor
            faixapgtoprodutor.nr_valor_produtor = cta_1400
            dia_pagto = faixapgtoprodutor.getFaixaPagamentoProdutorbyValor

            ' 01/12/2008 (para não dar erro crítico) - i
            'If dia_pagto = 0 Then  ' Se não encontrou a faixa
            '    dia_pagto = 1
            'End If
            ' 01/12/2008 (para não dar erro crítico) - f

            dt_duplicata = Convert.ToDateTime(Right("0" + dia_pagto.ToString, 2) + "/" + Right(Me.dt_referencia, 7))
            'Se o dia cadastrado é menor que o dia de hoje assume 1 mes a mais
            'Fran 2/12/2008 i data duplocata deve ser 1 mes a mais que referencia com o dia encontrado na faixa
            'If Day(Now) > dia_pagto Then
            dt_duplicata = DateAdd(DateInterval.Month, 1, dt_duplicata)
            'End If
            dt_vencto = DateTime.Parse(dt_duplicata).ToString("ddMMyyyy")
            Me.dt_emissao = dt_vencto 'guarda para possivel registro 4
            ' 11 inteiros e 2 decimais (campo 7 - Valor da Duplicata)
            'nr_valor = CStr(cta_1400 - cta_4000)
            ' Adri 28/11/2008 - i
            'nr_valor = CStr(Round(CDbl(cta_1400) - CDbl(cta_desc), 2))  ' 29/10/2008
            nr_valor = CStr(Round(Convert.ToDecimal(cta_1400), 2))
            ' Adri 28/11/2008 - f
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
            linhatexto = linhatexto + tp_especie + "206" + dt_vencto + nr_valor
            'linhatexto = linhatexto + StrDup(13, "0") + "?       "  ' Data do Vencimento Desconto
            linhatexto = linhatexto + StrDup(13, "0") + "        "  ' Data do Vencimento Desconto  ' Adri 02/03/2010 - chamado 701 (mudanças no EMS)
            linhatexto = linhatexto + StrDup(5, "0")

            NotaFiscalProdutor_Registro_3 = linhatexto

        Catch ex As Exception
            '   ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    'fran 04/08/2010 i chamado 811
    'Private Function NotaFiscalProdutor_Registro_4(ByVal pdt_vencto As String, ByVal prend_tributados As Decimal, ByVal pvalor_imposto As Decimal) As String
    Private Function NotaFiscalProdutor_Registro_4(ByVal pdt_vencto As String, ByVal pespecie_documento As String, ByVal prend_tributados As Decimal) As String

        'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim linhatexto As String
            Dim lpos As Int16
            Dim nr_valor As String
            Dim nr_valor_int As String
            Dim nr_valor_dec As String

            ' Registro 4
            Dim cd_registro As String
            Dim rend_tributado As String
            Dim valor_imposto As String
            Dim aliquota_imposto As String 'fran 04/08/2010 i chamado 811
            Dim cd_especie_documento As String 'fran 04/08/2010 i chamado 811
            Dim cd_imposto As String    ' Adriana 26/08/2010 i chamado 936


            linhatexto = ""

            '====================================================================================
            ' Registro Tipo 4  - Impostos Duplicatas
            '====================================================================================

            linhatexto = ""

            cd_registro = "4"

            ' 9 inteiros e 2 decimais (campo 5 - Rendimentos Tributados)
            nr_valor = CStr(Round(prend_tributados, 2))
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(9 - Len(nr_valor), "0") + nr_valor, 9)
                nr_valor = nr_valor & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(9 - Len(nr_valor_int), "0") + nr_valor_int, 9)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            rend_tributado = nr_valor

            'fran 04/08/2010 i - chamado 811 
            'Apurar Valor do imporsto
            Select Case pespecie_documento
                'Case "IP"
                Case "IQ"   ' Adriana 18/08/2010 - Chamado 936
                    'cd_especie_documento = "IP"
                    cd_especie_documento = "IQ"  ' Adriana 18/08/2010 - Chamado 936
                    cd_imposto = "2608"  ' Adriana 26/08/2010 - Chamado 936
                    aliquota_imposto = "00210"
                    nr_valor = CStr(Round((prend_tributados * 2.1) / 100, 2))
                Case "IZ"
                    'Case "IF"
                    'cd_especie_documento = "IF"
                    cd_especie_documento = "IZ"
                    cd_imposto = "2609"  ' Adriana 26/08/2010 - Chamado 936
                    aliquota_imposto = "00020"
                    nr_valor = CStr(Round((prend_tributados * 0.2) / 100, 2))
                Case Else
                    nr_valor = "0,00"
                    cd_especie_documento = "  "
                    cd_imposto = "    "  ' Adriana 26/08/2010 - Chamado 936
                    aliquota_imposto = "00000"
            End Select
            'fran 04/08/2010 f - chamado 811
            ' 12 inteiros e 2 decimais (campo 7 - Valor Imposto)
            'nr_valor = CStr(Round(pvalor_imposto, 2)) 'fran 04/08/2010 i - chamado 811
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(12 - Len(nr_valor), "0") + nr_valor, 12)
                nr_valor = nr_valor & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), "0") + nr_valor_int, 12)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & nr_valor_dec
            End If
            valor_imposto = nr_valor

            'fran 04/08/2010 i - chamado 811
            'linhatexto = linhatexto + cd_registro + "2607" + "IP" + pdt_vencto
            'linhatexto = linhatexto + rend_tributado + "00230" + valor_imposto + "201" + "2607"
            'linhatexto = linhatexto + cd_registro + "2607" + cd_especie_documento + pdt_vencto
            linhatexto = linhatexto + cd_registro + cd_imposto + cd_especie_documento + pdt_vencto   ' Adriana 26/08/2010 - Chamado 936
            'linhatexto = linhatexto + rend_tributado + aliquota_imposto + valor_imposto + "201" + "2607"
            linhatexto = linhatexto + rend_tributado + aliquota_imposto + valor_imposto + "201" + cd_imposto  ' Adriana 26/08/2010 - Chamado 936
            'fran 04/08/2010 f - chamado 811

            NotaFiscalProdutor_Registro_4 = linhatexto

        Catch ex As Exception
            '   ArquivoTexto.Close()
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
    Private Function converteCodigoBarra(ByVal cd_barra As String) As String

        Dim i As Integer
        Dim lPos As Integer
        Dim dig_ver As String
        Dim cal_dig As Int32 = 105
        Dim cod_bar As String

        If Int(Len(cd_barra)) Mod 2 <> 0 Then
            converteCodigoBarra = Space(50)
        Else
            For lPos = 1 To Len(cd_barra) Step 2
                i = i + 1


                ' soma os valores de dos campos os blocos */ 
                cal_dig = cal_dig + Int(Mid(cd_barra, lPos, 2)) * i
                'converte par de digitos em ASCII */ 
                Select Case Mid(cd_barra, lPos, 2)
                    Case "00"
                        cod_bar = cod_bar + Chr(32)
                    Case "95"
                        cod_bar = cod_bar + Chr(127)
                    Case "96"
                        cod_bar = cod_bar + Chr(192)
                    Case "97"
                        cod_bar = cod_bar + Chr(193)
                    Case "98"
                        cod_bar = cod_bar + Chr(194)
                    Case "99"
                        cod_bar = cod_bar + Chr(195)
                    Case Else
                        cod_bar = cod_bar + Chr(Int(Mid(cd_barra, lPos, 2)) + 32)
                End Select

            Next

            'calcula o digito verificador */ 
            cal_dig = cal_dig - (Fix(cal_dig / 103) * 103)

            '/* excessoes do digito verificar */ 
            Select Case cal_dig
                Case 0
                    dig_ver = Chr(32)
                Case 95
                    dig_ver = Chr(127)
                Case 96
                    dig_ver = Chr(192)
                Case 97
                    dig_ver = Chr(193)
                Case 98
                    dig_ver = Chr(194)
                Case 99
                    dig_ver = Chr(195)
                Case Else
                    dig_ver = Chr(cal_dig + 32)
            End Select

            '/* aplica digito inicial, vefificador e final ao codigo de barra */ 
            cod_bar = Chr(201) + cod_bar + dig_ver + Chr(202)

            converteCodigoBarra = cod_bar

        End If



    End Function
    Private Sub buscarNaturezaOperacao(ByVal propriedade As Propriedade, ByVal idestabelecimento As Int32)
        Try

            'NATUREZA de OPERAÇÃO
            'Verifica qual o estado da propriedade/produtotr
            Select Case propriedade.cd_uf
                Case "MG"
                    'Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                    'Fran 20/05/2009 i rls17.5 chamado 263 Incentivo 2.4
                    'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" Then
                    If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                        'Fran 20/05/2009 f
                        Me.cd_natureza_operacao = "1101AH"
                    End If
                    'Se TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                    'Fran 20/05/2009 i rls17.5 chamado 263 Incentivo 2.4
                    'If propriedade.st_incentivo_fiscal <> "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" Then
                    If propriedade.st_incentivo_fiscal <> "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                        'Fran 20/05/2009 f
                        Me.cd_natureza_operacao = "1101AS"
                    End If
                    'Se NAO TEM incentivo 2,5, TEM transf credito e NAO TEM incentivo 2,1
                    'Fran 20/05/2009 i rls17.5 chamado 263 Incentivo 2.4
                    'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "S" And propriedade.st_incentivo_21 = "N" Then
                    If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "S" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                        'Fran 20/05/2009 f
                        Me.cd_natureza_operacao = "1101AS"
                    End If
                    'Se NAO TEM incentivo 2,5, NAO TEM transf credito e TEM incentivo 2,1
                    'Fran 20/05/2009 i rls17.5 chamado 263 Incentivo 2.4
                    'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "S" Then
                    If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And (propriedade.st_incentivo_21 = "S" Or propriedade.st_incentivo_24 = "N") Then
                        'Fran 20/05/2009 f
                        Me.cd_natureza_operacao = "1101AH"
                    End If
                Case "SP"
                    'Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                    'Fran 20/05/2009 i rls17.5 chamado 263 Incentivo 2.4
                    'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" Then
                    If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                        'Fran 20/05/2009 f
                        'poços dde caldas
                        If idestabelecimento = 1 Then
                            Me.cd_natureza_operacao = "2101AS"
                        End If
                        'guara
                        If idestabelecimento = 2 Then
                            Me.cd_natureza_operacao = "1101AP"
                        End If
                        'águas prata
                        If idestabelecimento = 6 Then
                            Me.cd_natureza_operacao = "1101AP"
                        End If
                    End If
                Case "RJ"
                    'Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                    'Fran 20/05/2009 i rls17.5 chamado 263 Incentivo 2.4
                    'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" Then
                    If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                        'Fran 20/05/2009 f
                        'guara
                        If idestabelecimento = 2 Then
                            Me.cd_natureza_operacao = "2101AF"
                        End If
                    End If
                Case Else
                    Me.cd_natureza_operacao = "SEM REGRA"

            End Select
        Catch ex As Exception

        End Try

    End Sub
    Public Sub imprimeNotaFiscalProdutor()

        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim li As Int32
            Dim liexportada As Int32
            Dim dia_pagto As Integer
            Dim dsfichaitens As DataSet
            Dim dsfichacontasdesconto As DataSet
            Dim dsnaturezaoperacao As DataSet
            Dim dsmapaleite As DataSet
            Dim dsrowfichaitem As DataRow
            Dim cta0010_valor As Decimal
            Dim cta0041_valor As Decimal
            Dim cta1400_valor As Decimal
            Dim cta1200_valor As Decimal
            Dim cta1300_valor As Decimal
            Dim cta1500_valor As Decimal
            Dim cta0800_valor As Decimal
            Dim cta0300_valor As Decimal '18/12/2008
            Dim cta2050_valor As Decimal '18/12/2008
            Dim cta2055_valor As Decimal '20/05/2009
            Dim cta0600_valor As Decimal '23/12/2008
            Dim dt_duplicata As Date
            Dim aidf As String
            Dim linhacabecalho As String
            Dim linha90graus As String
            Dim linhanotaprodutor As String
            Dim linhanotaprodutor2 As String
            Dim contas As String
            Dim dt_vencto As String
            Dim cod_natureza_operacao As String
            Dim st_buscar_estabelecimento As String
            Dim mensagem_nota As String
            Dim mapaleite As New MapaLeite
            Dim estabelecimento As New Estabelecimento(Me.id_estabelecimento)
            Dim item As New Item(1)
            Dim naturezaoperacao As New NaturezaOperacao
            Dim faixapgtoprodutor As New FaixaPagamentoProdutor
            'BUSCA as propriedades que serao exportadas de acordo com o filtro

            Dim fichafinanceira As New FichaFinanceira
            fichafinanceira.dt_referencia = Me.dt_referencia
            fichafinanceira.st_pagamento = "D"
            fichafinanceira.id_estabelecimento = Me.id_estabelecimento
            fichafinanceira.id_propriedade = Me.id_propriedade
            fichafinanceira.nr_nota_fiscal_ini = Me.nr_nota_fiscal_ini
            fichafinanceira.nr_nota_fiscal_fim = Me.nr_nota_fiscal_fim
            fichafinanceira.st_exportacao_nota = "S"
            fichafinanceira.id_grupo = 1
            fichafinanceira.st_emite_nota_fiscal = "N"
            Dim dsNotaFiscal As DataSet = fichafinanceira.getFichaFinanceiraHeader()
            aidf = estabelecimento.ds_aidf_nf_produtor
            'If estabelecimento Then
            linhatexto = ""
            linhanotaprodutor = ""
            linhanotaprodutor2 = ""
            linha90graus = ""
            liexportada = 0
            'st_buscar_estabelecimento = "S"     ' Só busca a primeira vez
            For li = 0 To dsNotaFiscal.Tables(0).Rows.Count - 1
                'Carrega os dados do produtor

                Dim produtor As New Pessoa(Convert.ToInt32(dsNotaFiscal.Tables(0).Rows(li).Item("id_pessoa")))

                'produtor.id_pessoa = Convert.ToInt32(dsNotaFiscal.Tables(0).Rows(li).Item("id_pessoa"))
                'produtor.loadPessoa()
                'Carrega os dados do propriedade
                Dim propriedade As New Propriedade(Convert.ToInt32(dsNotaFiscal.Tables(0).Rows(li).Item("id_propriedade")))

                'propriedade.id_propriedade = Convert.ToInt32(dsNotaFiscal.Tables(0).Rows(li).Item("id_propriedade"))
                'propriedade.loadPropriedade()
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'NATUREZA OPERAÇÃO
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'guarda a natureza
                cod_natureza_operacao = Me.cd_natureza_operacao
                'busca o cód natureza de acordo com a propriedade 
                buscarNaturezaOperacao(propriedade, estabelecimento.id_estabelecimento)

                'Se não for a mesma, faz novamente consulta dos dados da natureza
                If cod_natureza_operacao <> Me.cd_natureza_operacao Then
                    naturezaoperacao.cd_natureza_operacao = Me.cd_natureza_operacao
                End If
                'Se encontrou regra
                If Me.cd_natureza_operacao <> "SEM REGRA" Then
                    'Busca dados no cadastro
                    naturezaoperacao.cd_natureza_operacao = Me.cd_natureza_operacao
                    naturezaoperacao.id_situacao = 1 'ativa
                    dsnaturezaoperacao = naturezaoperacao.getNaturezaOperacoesByFilters()
                    'Se nao tem cadstro 
                    If dsnaturezaoperacao.Tables(0).Rows.Count <= 0 Then
                        Me.cd_natureza_operacao = "SEM CADASTRO"
                    End If
                End If

                'Se não há cadastro para natureza operacao ou não foi encontrada regra, Para a geração do arquivo
                If Left(Me.cd_natureza_operacao, 3) = "SEM" Then
                    'Sai da rotina pois não pode continuar sem natureza operacao
                    If Me.cd_natureza_operacao = "SEM CADASTRO" Then
                        'Fran 06/03/2009 i
                        'Throw New Exception("O código de natureza de operação informado para a propriedade " + propriedade.id_propriedade + " não está cadastrado.")
                        Throw New Exception("O código de natureza de operação informado para a propriedade " + propriedade.id_propriedade.ToString + " não está cadastrado.")
                    End If

                    If Me.cd_natureza_operacao = "SEM REGRA" Then
                        'Fran 06/03/2009 i
                        'Throw New Exception("Para a propriedade " + propriedade.id_propriedade + " não foi encontrada regras de negócio válidas para obteção do código da natureza de operação.")
                        Throw New Exception("Para a propriedade " + propriedade.id_propriedade.ToString + " não foi encontrada regras de negócio válidas para obteção do código da natureza de operação.")
                    End If

                    'Exit Try
                End If

                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'CONTAS
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'BUSCA DADOS DAS CONTAS
                fichafinanceira.id_ficha_financeira = dsNotaFiscal.Tables(0).Rows(li).Item("id_ficha_financeira")
                dsfichaitens = fichafinanceira.getFichaFinanceiraItens
                'Guarda os valores e contas de desconto para o registro dos itens
                dsfichacontasdesconto = fichafinanceira.getFichaFinanceiraContasDescontos
                cta0010_valor = 0
                cta0041_valor = 0
                cta1400_valor = 0
                cta1200_valor = 0
                cta1300_valor = 0
                cta1500_valor = 0
                cta0800_valor = 0
                '18/12/2008 I
                cta0300_valor = 0
                cta2050_valor = 0
                '18/12/2008 F
                cta2055_valor = 0 'Fran 20/05/2009 rls17.5
                '23/12/2008 i
                cta0600_valor = 0
                '23/12/2008 f

                If dsfichaitens.Tables(0).Rows.Count > 0 Then
                    For Each dsrowfichaitem In dsfichaitens.Tables(0).Rows
                        Select Case UCase(Trim(dsrowfichaitem.Item("cd_conta")))
                            Case "0010" 'Volume Leite
                                cta0010_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "0041" 'Preço NF
                                cta0041_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1200" 'Base ICMS
                                cta1200_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1300" 'ICMS
                                cta1300_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1400" 'Total Nota Fiscal
                                cta1400_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1500" 'FUNRURAL
                                cta1500_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "0800" 'FUNRURAL valor unitario
                                cta0800_valor = dsrowfichaitem.Item("nr_valor_conta")
                                '18/12/2008 i incluir item nota
                            Case "0300" 'iNCENTIVO Fiscal 2,5
                                cta0300_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2050" 'incentivo 2,1
                                cta2050_valor = dsrowfichaitem.Item("nr_valor_conta")
                                '18/12/2008 f
                                'fran 20/05/2009 i chamado 263 rls17.5
                            Case "2055" 'incentivo 2,4
                                cta2055_valor = dsrowfichaitem.Item("nr_valor_conta")
                                'fran 20/05/2009 f
                            Case "0600" 'adiantamento
                                cta0600_valor = dsrowfichaitem.Item("nr_valor_conta")
                        End Select

                    Next
                End If
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'DADOS DA TRANSPORTADORA (pega a 1a que encontra no pmapa de leite para a propriedade /referencia)
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&


                mapaleite.id_estabelecimento = propriedade.id_estabelecimento
                mapaleite.id_propriedade = propriedade.id_propriedade
                mapaleite.dt_referencia = Me.dt_referencia
                ' Adriana 16/01/2009 - i - Foi criada procedure específica para esta rotina pois há casos de transbordo que estão sem id_linha no Romaneio, e portanto deve ser left join com a ms_linha
                ' Importante: Rever o transbordo, pois deveria ter uma rota, mesmo que a da primeira caderneta, pois ocorreu erro na geraçao do Mapa Leite Laser quando executado com left join na ms_linha
                'dsmapaleite = mapaleite.getMapaLeiteByFilters
                dsmapaleite = mapaleite.getMapaLeiteNotaFiscalProdutor
                ' Adriana 16/01/2009 - f
                Dim transportador As New Pessoa(Convert.ToInt32(dsmapaleite.Tables(0).Rows(0).Item("id_transportador")))
                'transportador.id_pessoa = Convert.ToInt32(dsmapaleite.Tables(0).Rows(0).Item("id_transportador"))
                'transportador.loadPessoa()
                'data pagamento

                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'BUSCA FAIXA PAGAMENTO PARA PEGAR O DIA DE PAGAMENTO
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                faixapgtoprodutor.nr_valor_produtor = cta1400_valor
                dia_pagto = faixapgtoprodutor.getFaixaPagamentoProdutorbyValor

                dt_duplicata = Convert.ToDateTime(Right("0" + dia_pagto.ToString, 2) + "/" + Right(Me.dt_referencia, 7))
                'Se o dia cadastrado é menor que o dia de hoje assume 1 mes a mais
                dt_duplicata = DateAdd(DateInterval.Month, 1, dt_duplicata)
                dt_vencto = DateTime.Parse(dt_duplicata).ToString("dd/MM/yyyy")

                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'BUSCA MENSAGEM NOTA
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                If propriedade.st_incentivo_fiscal = "N" Then
                    propriedade.st_incentivo_25 = "N"
                Else
                    propriedade.st_incentivo_25 = "S"
                End If
                mensagem_nota = propriedade.getNotaFiscalMensagembyPropriedade

                'For nr_via = 1 To 4
                'Imprime a nota
                'Se não encontrou natureza_operacao, para o processo
                'If Left(Me.cd_natureza_operacao, 3) = "SEM" Then
                'Me.nr_linhaslidas = li
                'Me.nr_linhasexportadas = liexportada
                'ArquivoTexto.Close()
                'Throw New Exception("O código de natureza de operação informado para a propriedade " + propriedade.id_propriedade + " não está cadastrado.")

                'Exit Try
                'End If

                'Monta os valores do corpo da nota na linhatexto
                'Guarda as contas utilizadas registro tipo 1
                Me.linhatexto = ""
                'Fran 23/12/2008 i - Incluir adiantamento nos itens da nota
                'Fran 18/12/2008 i - Incentivo deve estar no item da nota - Adriana RAmos por telefone
                'contas = "0010=" + Round(cta0010_valor, 4).ToString + "&0041=" + Round(cta0041_valor, 4).ToString + "&1300=" + Round(cta1300_valor, 2).ToString + "&0800=" + Round(cta0800_valor, 4).ToString + "&"
                'contas = "0010=" + Round(cta0010_valor, 4).ToString + "&0041=" + Round(cta0041_valor, 4).ToString + "&1300=" + Round(cta1300_valor, 2).ToString + "&0800=" + Round(cta0800_valor, 4).ToString + "&0300=" + Round(cta0300_valor, 4).ToString + "&2050=" + Round(cta2050_valor, 4).ToString + "&1400=" + Round(cta1400_valor, 4).ToString + "&"
                'Fran 18/12/2008 f
                'Fran 12/02/2009 i 
                'contas = "0010=" + Round(cta0010_valor, 4).ToString + "&0041=" + Round(cta0041_valor, 4).ToString + "&1300=" + Round(cta1300_valor, 2).ToString + "&0800=" + Round(cta0800_valor, 4).ToString + "&0300=" + Round(cta0300_valor, 4).ToString + "&2050=" + Round(cta2050_valor, 4).ToString + "&1400=" + Round(cta1400_valor, 4).ToString + "&0600=" + Round(cta0600_valor, 4).ToString + "&"
                'Fran 23/12/2008 f
                'Fran 20/05/2009 i chamado 263 rls17.5
                'contas = "0010=" + Round(cta0010_valor, 4).ToString + "&0041=" + Round(cta0041_valor, 4).ToString + "&1300=" + Round(cta1300_valor, 2).ToString + "&0800=" + Round(cta0800_valor, 4).ToString + "&0300=" + Round(cta0300_valor, 4).ToString + "&2050=" + Round(cta2050_valor, 4).ToString + "&1400=" + Round(cta1400_valor, 4).ToString + "&0600=" + Round(cta0600_valor, 4).ToString + "&1500=" + Round(cta1500_valor, 2).ToString + "&"
                contas = "0010=" + Round(cta0010_valor, 4).ToString + "&0041=" + Round(cta0041_valor, 4).ToString + "&1300=" + Round(cta1300_valor, 2).ToString + "&0800=" + Round(cta0800_valor, 4).ToString + "&0300=" + Round(cta0300_valor, 4).ToString + "&2050=" + Round(cta2050_valor, 4).ToString + "&1400=" + Round(cta1400_valor, 4).ToString + "&0600=" + Round(cta0600_valor, 4).ToString + "&1500=" + Round(cta1500_valor, 2).ToString + "&2055=" + Round(cta2055_valor, 4).ToString + "&"
                'Fran 20/05/2009 f
                'Fran 12/02/2009 f
                formataNotaFiscalProdutor_itens(item.cd_item, item.nm_item, item.cd_classificacao_fiscal, item.cd_unidade_medida, contas, dsfichacontasdesconto)
                contas = "0010=" + Round(cta0010_valor, 4).ToString + "&1200=" + Round(cta1200_valor, 2).ToString + "&1300=" + Round(cta1300_valor, 2).ToString + "&1400=" + Round(cta1400_valor, 2).ToString + "&"
                formataNotaFiscalProdutor_impostos(transportador, contas, Me.cd_natureza_operacao)
                formataNotaFiscalProdutor_adicionais(dt_vencto, mensagem_nota)

                'Fran rls 17 i acentuação
                Me.linhatexto = formatarTexto(Me.linhatexto)

                'Fran rls 17 f

                'Busca Cabeçalho da via 1
                '18/12/2008 dados de endereço da propriedade
                'linhacabecalho = formataNotaFiscalProdutor_cabecalho(1, dsNotaFiscal.Tables(0).Rows(li), estabelecimento, produtor, dsnaturezaoperacao.Tables(0).Rows(0), cta1300_valor, cta1400_valor)
                linhacabecalho = formataNotaFiscalProdutor_cabecalho(1, dsNotaFiscal.Tables(0).Rows(li), estabelecimento, produtor, dsnaturezaoperacao.Tables(0).Rows(0), cta1300_valor, cta1400_valor, propriedade.ds_endereco + " " + propriedade.nr_endereco.ToString, propriedade.ds_bairro, propriedade.nm_cidade, propriedade.cd_cep, propriedade.cd_uf)
                'Busca dados da linha 90 graus que finaliza impressão para a via 1
                linha90graus = formataNotaFiscalProdutor_mensagem90graus(1, aidf)
                'Inlui a linha cabecalho e os dados do corpo da nota e a linha 90 grtaus para a 1a via

                linhanotaprodutor = linhanotaprodutor + linhacabecalho + Me.linhatexto + linha90graus

                'Busca Cabeçalho da via 3
                '18/12/2008 dados de endereço da propriedade
                'linhacabecalho = formataNotaFiscalProdutor_cabecalho(3, dsNotaFiscal.Tables(0).Rows(li), estabelecimento, produtor, dsnaturezaoperacao.Tables(0).Rows(0), cta1300_valor, cta1400_valor)
                linhacabecalho = formataNotaFiscalProdutor_cabecalho(3, dsNotaFiscal.Tables(0).Rows(li), estabelecimento, produtor, dsnaturezaoperacao.Tables(0).Rows(0), cta1300_valor, cta1400_valor, propriedade.ds_endereco + " " + propriedade.nr_endereco.ToString, propriedade.ds_bairro, propriedade.nm_cidade, propriedade.cd_cep, propriedade.cd_uf)
                'Busca dados da linha 90 graus que finaliza impressão para a via 1
                linha90graus = formataNotaFiscalProdutor_mensagem90graus(3, aidf)
                'Inlui a linha cabecalho e os dados do corpo da nota e a linha 90 grtaus para a 1a via
                linhanotaprodutor = linhanotaprodutor + linhacabecalho + Me.linhatexto + linha90graus

                'Busca Cabeçalho da via 4
                '18/12/2008 dados de endereço da propriedade
                'linhacabecalho = formataNotaFiscalProdutor_cabecalho(4, dsNotaFiscal.Tables(0).Rows(li), estabelecimento, produtor, dsnaturezaoperacao.Tables(0).Rows(0), cta1300_valor, cta1400_valor)
                linhacabecalho = formataNotaFiscalProdutor_cabecalho(4, dsNotaFiscal.Tables(0).Rows(li), estabelecimento, produtor, dsnaturezaoperacao.Tables(0).Rows(0), cta1300_valor, cta1400_valor, propriedade.ds_endereco + " " + propriedade.nr_endereco.ToString, propriedade.ds_bairro, propriedade.nm_cidade, propriedade.cd_cep, propriedade.cd_uf)
                'Busca dados da linha 90 graus que finaliza impressão para a via 1
                linha90graus = formataNotaFiscalProdutor_mensagem90graus(4, aidf)
                'Inlui a linha cabecalho e os dados do corpo da nota e a linha 90 grtaus para a 1a via
                linhanotaprodutor = linhanotaprodutor + linhacabecalho + Me.linhatexto + linha90graus

                'Busca Cabeçalho da via 2
                '18/12/2008 dados de endereço da propriedade
                'linhacabecalho = formataNotaFiscalProdutor_cabecalho(2, dsNotaFiscal.Tables(0).Rows(li), estabelecimento, produtor, dsnaturezaoperacao.Tables(0).Rows(0), cta1300_valor, cta1400_valor)
                linhacabecalho = formataNotaFiscalProdutor_cabecalho(2, dsNotaFiscal.Tables(0).Rows(li), estabelecimento, produtor, dsnaturezaoperacao.Tables(0).Rows(0), cta1300_valor, cta1400_valor, propriedade.ds_endereco + " " + propriedade.nr_endereco.ToString, propriedade.ds_bairro, propriedade.nm_cidade, propriedade.cd_cep, propriedade.cd_uf)
                'Busca dados da linha 90 graus que finaliza impressão para a via 1
                linha90graus = formataNotaFiscalProdutor_mensagem90graus(2, aidf)
                'Inlui a linha cabecalho e os dados do corpo da nota e a linha 90 grtaus para a 1a via
                linhanotaprodutor = linhanotaprodutor + linhacabecalho + Me.linhatexto + linha90graus
                'Next
                liexportada = liexportada + 1

                'fran rls 17 i - Imprime cada nota
                ArquivoTexto.WriteLine(linhanotaprodutor)
                linhanotaprodutor = String.Empty
                'fran rls 17 f
                'Fran rls17 i
                'If liexportada = 300 Then
                'linhanotaprodutor2 = linhanotaprodutor
                'linhanotaprodutor = ""
                'End If
                'Fran rls 17 f
            Next

            'fran rls 17 i
            'ArquivoTexto.WriteLine(linhanotaprodutor2 + linhanotaprodutor)
            'fran rls 17 f

            'liexportada = liexportada + 1

            Me.nr_linhaslidas = li
            Me.nr_linhasexportadas = liexportada


            ArquivoTexto.Close()

        Catch ex As Exception
            ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Sub

    Private Function formataNotaFiscalProdutor_cabecalho(ByVal nr_via As Int32, ByVal pRegistro As DataRow, ByVal pEstabelecimento As Estabelecimento, ByVal pProdutor As Pessoa, ByVal pNaturezaOperacao As DataRow, ByVal pTotalIcm As Decimal, ByVal pTotalNota As Decimal, ByVal pEnderecoDestino As String, ByVal pBairroDestino As String, ByVal pCidadeDestino As String, ByVal pCEPDestino As String, ByVal pUFDestino As String) As String

        Try

            'Dim codigo_barra_1 As String
            'Dim codigo_barra_2 As String
            'Dim codigo_barra_3 As String
            Dim nr_nota_fiscal As String
            Dim nr_serie As String
            Dim linhacabecalho As String
            'Dim barra_nrserie As String
            'Dim barra_cnpj As String
            'Dim barra_cdsinief As String
            'Dim barra_cd_estabel As String
            'Dim barra_dtemissao As String
            'Dim barra_totalnota As String
            'Dim barra_totalicm As String
            'Dim lpos As Integer

            nr_nota_fiscal = Left(CStr(pRegistro.Item("nr_nota_fiscal")), 6)
            nr_nota_fiscal = Left(StrDup(6 - Len(nr_nota_fiscal), "0") + nr_nota_fiscal, 6)

            'Definição cod barra
            'BARRA 1: NotaFiscal(6) + CNPJ(14) + cd_sinief(2) + dt_emissao(8-yyyymmdd)
            'BARRA2 : NotaFiscal(6) + CNPJ(14) + cd_sinief(2) + valornotacta1400(10-semdecimal) * 100 + totalicmcta1300(9-semdecimal) * 100
            'BARRA 3: CdEstabel(3) + serie(3) + NF(6)

            'Fran 06/12/2008 nao precisa gerar cod barra
            'barra_cnpj = Left(pEstabelecimento.cd_cnpj, 18)
            'Deixa o cnpj com 18 posicoes (XX.XXX.XXX/XXXX-XX)
            'barra_cnpj = Left(StrDup(18 - Len(barra_cnpj), "0") + barra_cnpj, 18).Trim
            'barra_cnpj = Left(Left(barra_cnpj, 2) + Mid$(barra_cnpj, 4, 3) + Mid$(barra_cnpj, 8, 3) + Mid$(barra_cnpj, 12, 4) + Right(barra_cnpj, 2), 14)

            'If pEstabelecimento.cd_uf = "SP" Then
            'barra_cdsinief = "26"
            'End If
            'If pEstabelecimento.cd_uf = "MG" Then
            ' barra_cdsinief = "14"
            'End If
            'barra_dtemissao = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateTime.Parse(Me.dt_referencia.ToString))).ToString("yyyyMMdd")

            'barra_totalnota = Left(CStr(CInt(Fix(pTotalNota)) * 100), 10)
            'barra_totalnota = Left(StrDup(10 - Len(barra_totalnota), "0") + barra_totalnota, 10)

            'barra_totalicm = Left(CStr(CInt(Fix(pTotalIcm)) * 100), 9)
            'barra_totalicm = Left(StrDup(10 - Len(barra_totalicm), "0") + barra_totalicm, 9)

            'barra_cd_estabel = Left(pEstabelecimento.cd_estabelecimento.Trim, 3)
            'barra_cd_estabel = Left(StrDup(3 - Len(barra_cd_estabel), "0") + barra_cd_estabel, 3)

            'barra_nrserie = Left(pEstabelecimento.nr_serie.Trim, 3)
            'barra_nrserie = Left(StrDup(3 - Len(barra_nrserie), "0") + barra_nrserie, 3)

            'codigo_barra_1 = "1" + nr_nota_fiscal + barra_cnpj + barra_cdsinief + barra_dtemissao + "2"
            'codigo_barra_1 = converteCodigoBarra(codigo_barra_1)
            'codigo_barra_1 = Left(codigo_barra_1 + StrDup(50 - Len(codigo_barra_1), " "), 50)
            'codigo_barra_2 = "2" + nr_nota_fiscal + barra_cnpj + barra_cdsinief + barra_totalnota + barra_totalicm
            'codigo_barra_2 = converteCodigoBarra(codigo_barra_2)
            'codigo_barra_2 = Left(codigo_barra_2 + StrDup(50 - Len(codigo_barra_2), " "), 50)
            'codigo_barra_3 = "03" + barra_cd_estabel + barra_nrserie + nr_nota_fiscal
            'codigo_barra_3 = converteCodigoBarra(codigo_barra_3)
            'codigo_barra_3 = Left(codigo_barra_3 + StrDup(50 - Len(codigo_barra_3), " "), 50)

            'Se for a 1a vez (2via)
            Dim temgrampo As Boolean = True
            'assume que a bandeja1 utiliza a bandeja 1 da impressora
            Dim bandeja1 As String = "8"
            'assume que a bandeja2 utiliza a bandeja 2 da impressora
            Dim bandeja2 As String = "1"
            linhacabecalho = ""
            'formataNotaFiscalProdutor_cabecalho = linhacabecalho
            If nr_via = 2 Then
                If temgrampo = True Then
                    linhacabecalho = linhacabecalho + Chr(13) + Chr(10) + Chr(27) + "%-12345X@PJL EOJ" + Chr(13) + Chr(10) '.   /* Grampo antes do inicio da 2 via */
                    linhacabecalho = linhacabecalho + Chr(27) + "%-12345X@PJL JOB" + Chr(13) + Chr(10) '.   /* Callegari  */
                    linhacabecalho = linhacabecalho + "@PJL SET OUTBIN = UPPER" + Chr(13) + Chr(10) '.      /* Salta para a outra bandeja */
                    linhacabecalho = linhacabecalho + "@PJL ENTER LANGUAGE = PCL" + Chr(13) + Chr(10) '.   /* Callegari  */
                Else
                    linhacabecalho = linhacabecalho + Chr(13) + Chr(10) + Chr(27) + "%-12345X@PJL EOJ" + Chr(13) + Chr(10) '.   /* Encerra o Job do grampo */
                End If
                linhacabecalho = linhacabecalho + Chr(27) + "&l0O" + Chr(27) + "&l26A" + Chr(27) + "&l" + bandeja2 + "H" + Chr(27) + "&l-40U" + Chr(27) + "&f55Y" + Chr(27) + "&n7W" + Chr(5) + "NF_1_2" + Chr(27) + "&f2xS" + Chr(27) + "&u300D" '. '/* Utilizado em HD*/
            End If

            If nr_via = 1 Then
                linhacabecalho = linhacabecalho + Chr(27) + "&l0O" + Chr(27) + "&l26A" + Chr(27) + "&l" + bandeja2 + "H" + Chr(27) + "&l-40U" + Chr(27) + "&a0P" + Chr(27) + "&f55Y" + Chr(27) + "&n7W" + Chr(5) + "NF_1_2" + Chr(27) + "&f2xS" + Chr(27) + "&u300D"
            End If
            If nr_via = 3 Or nr_via = 4 Or nr_via = 5 Then
                linhacabecalho = linhacabecalho + Chr(27) + "&l0O" + Chr(27) + "&l26A" + Chr(27) + "&l" + bandeja1 + "H" + Chr(27) + "&l-40U" + Chr(27) + "&a0P" + Chr(27) + "&f56Y" + Chr(27) + "&n7W" + Chr(5) + "NF_3_4" + Chr(27) + "&f2xS" + Chr(27) + "&u300D"
            End If

            'Fran 06/12/2008 i Retirar cod barras
            ' Codigo de barras do topo da pagina (?)
            'If nr_via = 2 Or nr_via = 1 Then
            'linhacabecalho = linhacabecalho + Chr(27) + "(7Y" + Chr(27) + "(s1p14v0s0b9002T" + Chr(27) + "*p60x267Y" + codigo_barra_3
            'End If

            'Codigo de barras do fim da pagina */
            'linhacabecalho = linhacabecalho + Chr(27) + "(7Y" + Chr(27) + "(s1p12v0s0b9002T" + Chr(27) + "*p70x3465Y" + codigo_barra_1 + Chr(27) + "*p780x3465Y" + codigo_barra_2
            'Fran 06/12/2008 f

            linhacabecalho = linhacabecalho + Chr(27) + "(19U" + Chr(27) + "(s1p9v4s3b4148T"


            ' numero da nota fiscal 
            If nr_via = 2 Or nr_via = 1 Then
                linhacabecalho = linhacabecalho + Chr(27) + "*p2230x195Y" + nr_nota_fiscal
            End If

            linhacabecalho = linhacabecalho + Chr(27) + "*p2230x375Y" + nr_nota_fiscal
            linhacabecalho = linhacabecalho + Chr(27) + "(19U" + Chr(27) + "(s1p7v4s3b4148T"

            'ImpressÆo da serie da nota fiscal */
            nr_serie = Left(CStr(pRegistro.Item("nr_serie")), 5)
            nr_serie = Left(nr_serie + StrDup(5 - Len(nr_serie), " "), 5)


            If nr_via = 2 Or nr_via = 1 Then
                linhacabecalho = linhacabecalho + Chr(27) + "*p2330x245Y" + nr_serie
            End If

            linhacabecalho = linhacabecalho + Chr(27) + "*p2330x405Y" + nr_serie
            linhacabecalho = linhacabecalho + Chr(27) + "*p1880x380Y" + CStr(nr_via) + " VIA"
            linhacabecalho = linhacabecalho + Chr(27) + "(19U" + Chr(27) + "(s1p5v4s3b4148T"

            If nr_via = 2 Then
                linhacabecalho = linhacabecalho + Chr(27) + "*p1880x420Y" + "ARQUIVO FISCAL"
            End If

            If nr_via = 1 Then
                linhacabecalho = linhacabecalho + Chr(27) + "*p1880x420Y" + "REMETENTE /"
                linhacabecalho = linhacabecalho + Chr(27) + "*p1880x450Y" + "DESTINATÁRIO"
            End If

            If nr_via = 3 Then
                linhacabecalho = linhacabecalho + Chr(27) + "*p1880x420Y" + "FISCO DESTINO"
            End If

            If nr_via = 4 Then
                linhacabecalho = linhacabecalho + Chr(27) + "*p1880x420Y" + "FISCO ORIGEM"
            End If

            If nr_via = 5 Then  ' ?????
                linhacabecalho = linhacabecalho + Chr(27) + "*p1880x420Y" + "CONTABILIDADE"
            End If


            linhacabecalho = linhacabecalho + Chr(27) + "(19U" + Chr(27) + "(s1p6.5v4s3b4148T"


            'FIELD endereco              AS CHAR FORMAT "x(40)"
            'FIELD bairro                AS CHAR FORMAT "x(15)"
            'FIELD municipio             AS CHAR FORMAT "x(25)"
            'FIELD uf                    AS CHAR FORMAT "x(2)"
            'FIELD cep                   AS CHAR FORMAT "x(9)"
            'FIELD fone                  AS CHAR FORMAT "x(15)"
            'FIELD fax                   AS CHAR FORMAT "x(15)"
            'FIELD saida                 AS CHAR FORMAT "x(1)"
            'FIELD entrada               AS CHAR FORMAT "x(1)"
            'FIELD pagina-pa             AS CHAR FORMAT "x(2)"
            'FIELD pagina-pb             AS CHAR FORMAT "x(2)"
            'FIELD data-lim              AS CHAR FORMAT "x(10)"
            'FIELD nat-oper              AS CHAR FORMAT "x(35)"
            'FIELD cfop                  AS CHAR FORMAT "x(5)"
            'FIELD ins-estad-trib        AS CHAR FORMAT "x(19)"
            'FIELD ins-estad             AS CHAR FORMAT "x(18)"
            'FIELD cnpj                  AS CHAR FORMAT "x(18)"
            'FIELD data-emis             AS CHAR FORMAT "x(10)"
            'FIELD razao-social          AS CHAR FORMAT "x(40)"
            'FIELD fone-destin           AS CHAR FORMAT "x(18)"
            'FIELD ins-estad-destin      AS CHAR FORMAT "x(18)"
            'FIELD cnpj-destin           AS CHAR FORMAT "x(18)"
            'FIELD data-ent-saida        AS CHAR FORMAT "x(10)"
            'FIELD endereco-destin       AS CHAR FORMAT "x(40)"
            'FIELD bairro-destin         AS CHAR FORMAT "x(18)"
            'FIELD municipio-destin      AS CHAR FORMAT "x(25)"
            'FIELD cep-destin            AS CHAR FORMAT "x(9)"
            'FIELD uf-destin             AS CHAR FORMAT "x(2)"
            'FIELD hora-saida            AS CHAR FORMAT "x(9)"
            'FIELD nr-fatura             AS CHAR FORMAT "x(7)"
            'FIELD portador              AS CHAR FORMAT "x(40)"
            'FIELD duplicata-1           AS CHAR FORMAT "x(13)"
            'FIELD data-venc-1           AS CHAR FORMAT "x(10)"
            'FIELD valor-1               AS CHAR FORMAT "x(13)"
            'FIELD duplicata-2           AS CHAR FORMAT "x(13)"
            'FIELD data-venc-2           AS CHAR FORMAT "x(10)"
            'FIELD valor-2               AS CHAR FORMAT "x(13)"
            'FIELD duplicata-3           AS CHAR FORMAT "x(13)"
            'FIELD data-venc-3           AS CHAR FORMAT "x(10)"
            'FIELD valor-3               AS CHAR FORMAT "x(13)"
            'FIELD emitente              AS CHAR FORMAT "x(17)"
            'FIELD num-pedido            AS CHAR FORMAT "x(12)".

            ' Dados do estabelecimento do Produtor
            Dim endereco As String
            Dim bairro As String
            Dim municipio As String
            Dim uf As String
            Dim cep As String
            Dim fone As String
            Dim fax As String
            Dim saida As String
            Dim entrada As String
            Dim pagina_pa As String
            Dim pagina_pb As String
            Dim data_limite As String
            Dim nat_operacao As String
            Dim cfop As String
            Dim insc_estad_trib As String
            Dim insc_estadual As String
            Dim cnpj As String
            Dim data_emissao As String
            Dim razao_social As String
            Dim fone_destino As String
            Dim insc_estadual_destino As String
            Dim cnpj_destino As String
            Dim data_ent_saida As String
            Dim endereco_destino As String
            Dim bairro_destino As String
            Dim municipio_destino As String
            Dim cep_destino As String
            Dim uf_destino As String
            Dim hora_saida As String
            Dim nr_fatura As String
            Dim portador As String
            Dim duplicata_1 As String
            Dim data_venc_1 As String
            Dim valor_1 As String
            Dim duplicata_2 As String
            Dim data_venc_2 As String
            Dim valor_2 As String
            Dim duplicata_3 As String
            Dim data_venc_3 As String
            Dim valor_3 As String
            Dim emitente As String
            Dim num_pedido As String
            Dim nr_embarque As String
            Dim viagem As String

            'Dim estabelecimento As New Estabelecimento(pRegistro.Item("id_estabelecimento"))
            'Dim propriedade As New Propriedade(pRegistro.Item("id_propriedade"))

            endereco = Left(pEstabelecimento.ds_endereco, 40)
            endereco = Left(endereco + StrDup(40 - Len(endereco), " "), 40)

            bairro = Left(pEstabelecimento.ds_bairro, 15)
            bairro = Left(bairro + StrDup(15 - Len(bairro), " "), 15)

            municipio = Left(pEstabelecimento.nm_cidade, 25)
            municipio = Left(municipio + StrDup(25 - Len(municipio), " "), 25)

            uf = Left(pEstabelecimento.cd_uf, 2)
            uf = Left(uf + StrDup(2 - Len(uf), " "), 2)

            cep = Left(pEstabelecimento.cd_cep, 9)
            cep = Left(cep + StrDup(9 - Len(cep), " "), 9)

            fone = StrDup(15, " ")
            'fone = Left(bairro + StrDup(15 - Len(fone), " "), 15)

            fax = StrDup(15, " ")
            'fax = Left(fax + StrDup(25 - Len(fax), " "), 25)

            saida = " "
            entrada = "X"
            pagina_pa = "01"
            pagina_pb = "01"

            'Fran 01/04/2009 i Rls 17 correcao 2 - PEga do cadastro de estabelecimento 
            'Fran 17/03/2009 i rls 17
            'Fran 11/03/2009 i Rls 17
            'data_limite = "99/99/9999"
            'If Not pEstabelecimento.dt_validade_formulario Is Nothing Then
            'data_limite = pEstabelecimento.dt_validade_formulario
            'Else
            'data_limite = Space(10)
            'End If
            'data_limite = Space(10)
            'Fran 11/03/2009 f Rls 17

            If Not pEstabelecimento.dt_validade_formulario Is Nothing Then
                If pEstabelecimento.dt_validade_formulario.Equals(String.Empty) Then
                    data_limite = Space(10)
                Else
                    data_limite = pEstabelecimento.dt_validade_formulario
                End If
            Else
                data_limite = Space(10)
            End If
            'Fran 01/04/2009 f Rls 17 correcao 2

            nat_operacao = Left(pNaturezaOperacao.Item("nm_natureza_operacao"), 35)
            nat_operacao = Left(nat_operacao + StrDup(35 - Len(nat_operacao), " "), 35)

            cfop = CStr(Left(pNaturezaOperacao.Item("cd_natureza_operacao"), 4))
            cfop = Left(cfop + StrDup(5 - Len(cfop), " "), 5)

            insc_estad_trib = Space(19)

            insc_estadual = Left(pEstabelecimento.cd_inscricao_estadual, 18)
            insc_estadual = Left(insc_estadual + StrDup(18 - Len(insc_estadual), " "), 18)

            cnpj = Left(pEstabelecimento.cd_cnpj, 18)
            cnpj = Left(cnpj + StrDup(18 - Len(cnpj), " "), 18)

            'Data de emissão - ultimo dia do mês de referencia
            data_emissao = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateTime.Parse(Me.dt_referencia.ToString))).ToString("dd/MM/yyyy")

            'Alteração pedida pela Adriana Ramos 18/12/2008 i
            'razao_social = Left(pProdutor.nm_pessoa.Trim + Space(2) + pRegistro.Item("ds_produtor_prop_uprod"), 40)
            'razao_social = Left(razao_social + StrDup(40 - Len(razao_social), " "), 40)
            razao_social = Left(pProdutor.nm_pessoa.Trim + Space(2) + pRegistro.Item("ds_produtor_prop_uprod"), 80)
            razao_social = Left(razao_social + StrDup(80 - Len(razao_social), " "), 80)
            'Alteração pedida pela Adriana Ramos 18/12/2008 f
            fone_destino = Left(pProdutor.ds_telefone_1 + StrDup(18 - Len(pProdutor.ds_telefone_1), " "), 18)

            insc_estadual_destino = Left(pProdutor.cd_inscricao_estadual + StrDup(18 - Len(pProdutor.cd_inscricao_estadual), " "), 18)

            cnpj_destino = Space(18)
            If Not IsDBNull(pProdutor.cd_cnpj) Then 'se não tem cnpj 
                If Not pProdutor.cd_cnpj.Trim.Equals(String.Empty) Then 'se não tem cnpj
                    cnpj_destino = Left(pProdutor.cd_cnpj + StrDup(18 - Len(pProdutor.cd_cnpj), " "), 18)
                Else
                    If Not IsDBNull(pProdutor.cd_cpf) Then 'se não tem cnpj 
                        If Not pProdutor.cd_cpf.Trim.Equals(String.Empty) Then 'se não tem cpj
                            cnpj_destino = Left(pProdutor.cd_cpf + StrDup(18 - Len(pProdutor.cd_cpf), " "), 18)
                        End If
                    End If
                End If
            Else
                If Not IsDBNull(pProdutor.cd_cpf) Then 'se não tem cnpj 
                    If Not pProdutor.cd_cpf.Trim.Equals(String.Empty) Then 'se não tem cpj
                        cnpj_destino = Left(pProdutor.cd_cpf + StrDup(18 - Len(pProdutor.cd_cpf), " "), 18)
                    End If
                End If
            End If

            data_ent_saida = data_emissao
            '18/12/2008 i Os dados de endereço devem ser da propriedade de acordo com Adriana Ramos
            'endereco_destino = Left(pProdutor.ds_endereco + " " + pProdutor.nr_endereco.ToString, 40)
            endereco_destino = Left(pEnderecoDestino.Trim, 40)
            endereco_destino = Left(endereco_destino + StrDup(40 - Len(endereco_destino), " "), 40)

            '18/12/2008 i Os dados de endereço devem ser da propriedade de acordo com Adriana Ramos
            'bairro_destino = Left(pProdutor.ds_bairro, 18)
            bairro_destino = Left(pBairroDestino.Trim, 18)
            '18/12/2008 f
            bairro_destino = Left(bairro_destino + StrDup(18 - Len(bairro_destino), " "), 18)

            '18/12/2008 i Os dados de endereço devem ser da propriedade de acordo com Adriana Ramos
            'municipio_destino = Left(pProdutor.nm_cidade, 25)
            municipio_destino = Left(pCidadeDestino, 25)
            '18/12/2008 f
            municipio_destino = Left(municipio_destino + StrDup(25 - Len(municipio_destino), " "), 25)

            '18/12/2008 i Os dados de endereço devem ser da propriedade de acordo com Adriana Ramos
            'cep_destino = Left(pProdutor.cd_cep, 9)
            cep_destino = Left(pCEPDestino, 9)
            '18/12/2008 f
            cep_destino = Left(cep_destino + StrDup(9 - Len(cep_destino), " "), 9)

            '18/12/2008 i Os dados de endereço devem ser da propriedade de acordo com Adriana Ramos
            'uf_destino = Left(pProdutor.cd_uf, 2)
            uf_destino = Left(pUFDestino, 2)
            '18/12/2008 f
            uf_destino = Left(uf_destino + StrDup(2 - Len(uf_destino), " "), 2)

            hora_saida = Space(9)
            nr_fatura = Space(7)
            portador = Space(40)
            duplicata_1 = Space(13)
            data_venc_1 = Space(10)
            valor_1 = Space(13)
            duplicata_2 = Space(13)
            data_venc_2 = Space(10)
            valor_2 = Space(13)
            duplicata_3 = Space(13)
            data_venc_3 = Space(10)
            valor_3 = Space(13)
            emitente = Left("DANONE LTDA." + StrDup(17 - Len("DANONE LTDA."), " "), 17)
            'num_pedido = Left(pProdutor.cd_cpf + StrDup(40 - Len(pProdutor.cd_cpf), " "), 12)
            num_pedido = Space(12)
            viagem = "0"
            nr_embarque = "0"

            linhacabecalho = linhacabecalho + Chr(27) + "*p392x405Y" + endereco
            linhacabecalho = linhacabecalho + Chr(27) + "*p1000x405Y" + bairro
            linhacabecalho = linhacabecalho + Chr(27) + "*p392x430Y" + municipio
            linhacabecalho = linhacabecalho + Chr(27) + "*p880x430Y" + uf
            linhacabecalho = linhacabecalho + Chr(27) + "*p1030x430Y" + cep
            linhacabecalho = linhacabecalho + Chr(27) + "*p480x462Y" + fone
            linhacabecalho = linhacabecalho + Chr(27) + "*p940x462Y" + fax
            linhacabecalho = linhacabecalho + Chr(27) + "*p1270x445Y" + saida
            linhacabecalho = linhacabecalho + Chr(27) + "*p1410x445Y" + entrada
            linhacabecalho = linhacabecalho + Chr(27) + "*p2080x395Y" + pagina_pa
            linhacabecalho = linhacabecalho + Chr(27) + "*p2080x440Y" + pagina_pb
            linhacabecalho = linhacabecalho + Chr(27) + "*p2240x460Y" + data_limite
            linhacabecalho = linhacabecalho + Chr(27) + "*p85x512Y" + nat_operacao
            linhacabecalho = linhacabecalho + Chr(27) + "*p1035x512Y" + cfop
            linhacabecalho = linhacabecalho + Chr(27) + "*p1245x512Y" + insc_estad_trib
            linhacabecalho = linhacabecalho + Chr(27) + "*p1605x512Y" + insc_estadual
            linhacabecalho = linhacabecalho + Chr(27) + "*p1925x512Y" + cnpj
            linhacabecalho = linhacabecalho + Chr(27) + "*p2235x512Y" + data_emissao

            ' Dados do Produtor
            linhacabecalho = linhacabecalho + Chr(27) + "*p85x594Y" + razao_social
            linhacabecalho = linhacabecalho + Chr(27) + "*p1245x594Y" + fone_destino
            linhacabecalho = linhacabecalho + Chr(27) + "*p1605x594Y" + insc_estadual_destino
            linhacabecalho = linhacabecalho + Chr(27) + "*p1925x594Y" + cnpj_destino
            linhacabecalho = linhacabecalho + Chr(27) + "*p2235x594Y" + data_ent_saida
            linhacabecalho = linhacabecalho + Chr(27) + "*p85x644Y" + endereco_destino
            linhacabecalho = linhacabecalho + Chr(27) + "*p1245x644Y" + bairro_destino
            linhacabecalho = linhacabecalho + Chr(27) + "*p1635x644Y" + municipio_destino
            linhacabecalho = linhacabecalho + Chr(27) + "*p2005x644Y" + cep_destino
            linhacabecalho = linhacabecalho + Chr(27) + "*p2165x644Y" + uf_destino
            linhacabecalho = linhacabecalho + Chr(27) + "*p2235x644Y" + hora_saida
            linhacabecalho = linhacabecalho + Chr(27) + "*p85x724Y" + nr_fatura
            linhacabecalho = linhacabecalho + Chr(27) + "*p85x770Y" + portador
            linhacabecalho = linhacabecalho + Chr(27) + "*p1260x714Y" + duplicata_1
            linhacabecalho = linhacabecalho + Chr(27) + "*p1260x744Y" + data_venc_1
            linhacabecalho = linhacabecalho + Chr(27) + "*p1260x774Y" + valor_1
            linhacabecalho = linhacabecalho + Chr(27) + "*p1700x714Y" + duplicata_2
            linhacabecalho = linhacabecalho + Chr(27) + "*p1700x744Y" + data_venc_2
            linhacabecalho = linhacabecalho + Chr(27) + "*p1700x774Y" + valor_2
            linhacabecalho = linhacabecalho + Chr(27) + "*p2140x714Y" + duplicata_3
            linhacabecalho = linhacabecalho + Chr(27) + "*p2140x744Y" + data_venc_3
            linhacabecalho = linhacabecalho + Chr(27) + "*p2140x774Y" + valor_3

            If nr_via = 2 Or nr_via = 1 Then
                linhacabecalho = linhacabecalho + Chr(27) + "(19U" + Chr(27) + "(s1p6.5v4s3b4148T"
                linhacabecalho = linhacabecalho + Chr(27) + "*p970x255Y" + emitente
                linhacabecalho = linhacabecalho + Chr(27) + "*p1160x255Y" + "VIAGEM NR: " + viagem
                linhacabecalho = linhacabecalho + Chr(27) + "*p1680x250Y" + num_pedido
                linhacabecalho = linhacabecalho + Chr(27) + "*p1880x250Y" + "EMBARQUE NR: " + nr_embarque 'STRING(i-nr-embarque,">>>>>>>9").
            End If

            linhacabecalho = linhacabecalho + Chr(27) + "(19U" + Chr(27) + "(s0p21h0s3b4102T"

            'Fran rls17 i
            linhacabecalho = formatarTexto(linhacabecalho)
            'fran rls 17 f

            formataNotaFiscalProdutor_cabecalho = linhacabecalho

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    'Private Sub formataNotaFiscalProdutor_itens(ByVal pItem As Item, ByVal pContas As String, ByVal pContasDesconto As DataSet)
    Private Sub formataNotaFiscalProdutor_itens(ByVal pitem_cd_item As String, ByVal pitem_nm_item As String, ByVal pitem_cd_clas_fiscal As String, ByVal pitem_cd_unid_medida As String, ByVal pContas As String, ByVal pContasDesconto As DataSet)
        Try

            Dim linha_plc As Int32


            'FIELD it-codigo             AS CHAR FORMAT "x(10)"
            'FIELD descricao             AS CHAR FORMAT "x(48)"
            'FIELD cod-class-fisc        AS CHAR FORMAT "x(8)"
            'FIELD sit-trib              AS CHAR FORMAT "x(3)"
            'FIELD un-fatur              AS CHAR FORMAT "x(2)"
            'FIELD qt-faturada           AS CHAR FORMAT "x(12)"
            'FIELD vl-unit               AS CHAR FORMAT "x(10)"
            'FIELD vl-tot-item           AS CHAR FORMAT "x(11)"
            'FIELD desconto              AS CHAR FORMAT "x(10)"
            'FIELD abatimento            AS CHAR FORMAT "x(10)"
            'FIELD vl-liq-item           AS CHAR FORMAT "x(11)"
            'FIELD icms                  AS CHAR FORMAT "x(4)".
            Dim nr_valor As String
            Dim nr_valor_int As String
            Dim nr_valor_dec As String
            Dim nr_valor_conta As Decimal
            Dim nr_valor_total_bruto As Decimal
            Dim nr_valor_total_receber As Decimal
            Dim nr_valor_total_funrural As Decimal
            Dim nr_valor_total_central_compras As Decimal 'fran 27/05/2009 rls17.7 chamdo 275
            Dim nr_valor_total_adto As Decimal
            Dim nr_valor_total As Decimal
            Dim cd_item As String '10 posições
            Dim descricao As String '10 posições
            Dim cd_classificacao_fiscal As String
            Dim sit_trib As String
            Dim un_medida As String
            Dim quantidade_faturada As String
            Dim valor_unit As String
            Dim valor_total_item As String
            Dim desconto As String
            Dim abatimento As String
            Dim valor_liquido_item As String
            Dim icms As String
            Dim lpos As Integer
            Dim lposfim As Integer
            Dim cta_0010 As String
            Dim cta_0041 As String
            Dim cta_1300 As String
            Dim cta_0800 As String
            Dim cta_0300 As String
            Dim cta_2050 As String
            Dim cta_2055 As String
            Dim cta_1400 As String
            Dim cta_0600 As String
            Dim cta_1500 As String
            Dim lrow As DataRow
            'linhatexto = ""

            lpos = InStr(1, pContas, "0010=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0010 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0041=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0041 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "1300=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_1300 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0800=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0800 = Mid(pContas, lpos, lposfim - lpos)
            '18/12/2008 i
            lpos = InStr(1, pContas, "0300=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0300 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2050=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2050 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "1400=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_1400 = Mid(pContas, lpos, lposfim - lpos)
            '18/12/2008 f
            '23/12/2008 i
            lpos = InStr(1, pContas, "0600=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0600 = Mid(pContas, lpos, lposfim - lpos)
            '23/12/2008 f
            'Fran 12/02/2009 i
            lpos = InStr(1, pContas, "1500=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_1500 = Mid(pContas, lpos, lposfim - lpos)
            'Fran 12/02/2009 f
            'Fran 20/05/2009 i
            lpos = InStr(1, pContas, "2055=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2055 = Mid(pContas, lpos, lposfim - lpos)
            'Fran 20/05/2009 f

            'Fran rls 17 i
            'cd_item = Left(pItem.cd_item, 10)
            cd_item = Left(pitem_cd_item, 10)
            'Fran rls 17 f
            cd_item = Left(cd_item + StrDup(10 - Len(cd_item), " "), 10)

            'Fran rls 17 i
            'descricao = pItem.nm_item
            descricao = pitem_nm_item
            'Fran rls 17 f
            descricao = Left(descricao + StrDup(48 - Len(descricao), " "), 48)

            'Fran rls 17 i
            'cd_classificacao_fiscal = pItem.cd_classificacao_fiscal
            cd_classificacao_fiscal = pitem_cd_clas_fiscal
            'Fran rls 17 i
            cd_classificacao_fiscal = Left(cd_classificacao_fiscal + StrDup(8 - Len(cd_classificacao_fiscal), " "), 8)

            sit_trib = "041"
            'Fran rls 17 i
            'un_medida = Left(pItem.cd_unidade_medida, 2)
            un_medida = Left(pitem_cd_unid_medida, 2)
            'Fran rls 17 i
            un_medida = Left(un_medida + StrDup(2 - Len(un_medida), " "), 2)

            ' 9 inteiros, a virgula  e 2 decimais (12 caracteres)
            nr_valor = FormatNumber(CStr(Round(CDbl(cta_0010), 0)), 0, , TriState.False, TriState.True)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(12 - Len(nr_valor), " ") + nr_valor, 12)
                'nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), " ") + nr_valor_int, 12)
                'nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                'nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                'nr_valor = nr_valor_int & "," & nr_valor_dec
                nr_valor = nr_valor_int
            End If
            quantidade_faturada = nr_valor

            ' 7 inteiros, a virgula  e 2 decimais (10 caracteres)
            'Fran 12/02/2009 i RLS16. valor unit com 4 casas
            'nr_valor = FormatNumber(CStr(Round(CDbl(cta_0041), 2)), 2, , TriState.False, TriState.True)
            nr_valor = FormatNumber(CStr(Round(CDbl(cta_0041), 4)), 4, , TriState.False, TriState.True)
            'Fran 12/02/2009 f
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(7 - Len(nr_valor), " ") + nr_valor, 7)
                'Fran 12/02/2009 i RLS16
                'nr_valor = nr_valor & ",00"
                nr_valor = nr_valor & ",0000"
                'Fran 12/02/2009 f RLS16
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(7 - Len(nr_valor_int), " ") + nr_valor_int, 7)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                'Fran 12/02/2009 i
                'nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                'Fran 12/02/2009 f
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_unit = nr_valor

            ' 8 inteiros, virgula e 2 decimais (11 carcateres)
            nr_valor = FormatNumber(CStr(Round(CDbl(cta_0010) * CDbl(cta_0041), 2)), 2, , TriState.False, TriState.True)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(8 - Len(nr_valor), " ") + nr_valor, 8)
                nr_valor = nr_valor & "," & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), " ") + nr_valor_int, 8)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_total_item = nr_valor
            valor_liquido_item = valor_total_item
            nr_valor_total_bruto = Convert.ToDecimal(valor_total_item)
            desconto = Space(10)
            abatimento = Space(10)

            If CDbl(cta_1300) > 0 Then
                icms = "  12"
            Else
                icms = "   0"
            End If

            linha_plc = 865

            ' Para cada item (no máximo 50 por nota)

            linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + cd_item
            linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + descricao
            linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + cd_classificacao_fiscal
            linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + sit_trib
            linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + un_medida
            linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + quantidade_faturada
            'linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + valor_unit
            linhatexto = linhatexto + Chr(27) + "*p1470x" + CStr(linha_plc) + "Y" + valor_unit
            linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + valor_total_item
            linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + desconto
            linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + abatimento
            linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + valor_liquido_item
            linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + icms
            'linha_plc = linha_plc + 30

            'Fran 30/11/2008 i 
            'linha_plc = 895
            'Coloca 2 linhas em branco
            For linha_plc = 895 To 925 Step 30
                linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + Space(48)
                linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
                linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
                linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
                linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
                linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + Space(11)
                linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + Space(11)
                linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)
            Next
            'Linhas + 30
            linha_plc = 955

            '18/12/2008 i 
            'Incluir incentivo 2,5 no item
            If CDbl(cta_0300) <> 0 Then
                descricao = Left("Incentivo Fiscal - 2,5%", 48)
                descricao = Left(descricao + StrDup(48 - Len(descricao), " "), 48)

                valor_unit = "     0,00%"

                nr_valor_conta = Round(CDec(cta_0010) * CDec(cta_0300), 2)
                nr_valor = FormatNumber(CStr(nr_valor_conta), 2, , TriState.False, TriState.True)
                lpos = InStr(1, nr_valor, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    nr_valor = CStr(nr_valor)
                    nr_valor = Left(StrDup(8 - Len(nr_valor), " ") + nr_valor, 8)
                    nr_valor = nr_valor & "," & "00"
                Else
                    nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                    nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), " ") + nr_valor_int, 8)
                    nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                    nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                    nr_valor = nr_valor_int & "," & nr_valor_dec
                End If
                valor_total_item = nr_valor
                valor_liquido_item = valor_total_item

                linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + descricao
                linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
                linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
                linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
                linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
                'linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + valor_unit
                linhatexto = linhatexto + Chr(27) + "*p1470x" + CStr(linha_plc) + "Y" + valor_unit
                linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + valor_total_item
                linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + valor_liquido_item
                linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)
                linha_plc = linha_plc + 30
            End If
            'Incluir incentivo 2,1 no item
            If CDbl(cta_2050) <> 0 Then
                descricao = Left("Incentivo Fiscal - 2,1%", 48)
                descricao = Left(descricao + StrDup(48 - Len(descricao), " "), 48)

                valor_unit = "     0,00%"

                nr_valor_conta = Round(CDec(cta_2050), 2) 'ja esta somatizada
                nr_valor = FormatNumber(CStr(nr_valor_conta), 2, , TriState.False, TriState.True)
                lpos = InStr(1, nr_valor, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    nr_valor = CStr(nr_valor)
                    nr_valor = Left(StrDup(8 - Len(nr_valor), " ") + nr_valor, 8)
                    nr_valor = nr_valor & "," & "00"
                Else
                    nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                    nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), " ") + nr_valor_int, 8)
                    nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                    nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                    nr_valor = nr_valor_int & "," & nr_valor_dec
                End If
                valor_total_item = nr_valor
                valor_liquido_item = valor_total_item

                linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + descricao
                linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
                linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
                linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
                linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
                'linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + valor_unit
                linhatexto = linhatexto + Chr(27) + "*p1470x" + CStr(linha_plc) + "Y" + valor_unit
                linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + valor_total_item
                linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + valor_liquido_item
                linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)
                linha_plc = linha_plc + 30
            End If

            'Fran 20/05/2009 i rls17.5 chamado 263
            'Incluir incentivo 2,4 no item
            If CDbl(cta_2055) <> 0 Then
                descricao = Left("Incentivo Fiscal - 2,4%", 48)
                descricao = Left(descricao + StrDup(48 - Len(descricao), " "), 48)

                valor_unit = "     0,00%"

                nr_valor_conta = Round(CDec(cta_2055), 2) 'ja esta somatizada
                nr_valor = FormatNumber(CStr(nr_valor_conta), 2, , TriState.False, TriState.True)
                lpos = InStr(1, nr_valor, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    nr_valor = CStr(nr_valor)
                    nr_valor = Left(StrDup(8 - Len(nr_valor), " ") + nr_valor, 8)
                    nr_valor = nr_valor & "," & "00"
                Else
                    nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                    nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), " ") + nr_valor_int, 8)
                    nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                    nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                    nr_valor = nr_valor_int & "," & nr_valor_dec
                End If
                valor_total_item = nr_valor
                valor_liquido_item = valor_total_item

                linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + descricao
                linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
                linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
                linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
                linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
                linhatexto = linhatexto + Chr(27) + "*p1470x" + CStr(linha_plc) + "Y" + valor_unit
                linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + valor_total_item
                linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + valor_liquido_item
                linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)
                linha_plc = linha_plc + 30
            End If
            'fran 20/05/2009 f
            'Para cada conta de desconto.....
            For Each lrow In pContasDesconto.Tables(0).Rows
                'Fran 27/05/2009 i - Chamado 275 rls17.7
                'Não deve mostrar as contas de clube de compra nesta linha
                If lrow.Item("st_clube_compra").ToString.Trim = "N" Then
                    'Fran 27/05/2009 f - Chamado 275 rls17.7
                    If (Me.dt_referencia <> "01/12/2008") Or (Me.dt_referencia = "01/12/2008" And lrow.Item("cd_conta") <> "0102" And lrow.Item("cd_conta") <> "3000") Then
                        descricao = Left(lrow.Item("nm_conta"), 48)
                        descricao = Left(descricao + StrDup(48 - Len(descricao), " "), 48)

                        valor_unit = "     0,00%"


                        If Not IsDBNull(lrow.Item("nr_valor_conta")) Then
                            If Not lrow.Item("nr_valor_conta").ToString.Equals(String.Empty) Then
                                nr_valor_conta = lrow.Item("nr_valor_conta")
                            Else
                                nr_valor_conta = 0
                            End If
                        Else
                            nr_valor_conta = 0
                        End If

                        'If nr_valor_conta <> 0 Then
                        ' 8 inteiros, virgula e 2 decimais (11 carcateres)
                        'Fran 20/05/2009 i rls17.5 chamado 263
                        'nr_valor = FormatNumber(CStr(Round(CDbl(cta_0010) * CDbl(nr_valor_conta), 2)), 2, , TriState.False, TriState.True)
                        If lrow.Item("st_qtd_valor").ToString = "V" Then
                            nr_valor = FormatNumber(CStr(Round(CDbl(cta_0010) * CDbl(nr_valor_conta), 2)), 2, , TriState.False, TriState.True)
                        Else
                            nr_valor = FormatNumber(CStr(Round(CDbl(nr_valor_conta), 2)), 2, , TriState.False, TriState.True)
                        End If
                        'Fran 20/05/2009 f
                        lpos = InStr(1, nr_valor, ",", 1)
                        If lpos = 0 Then   ' Se não tem casas decimais
                            nr_valor = CStr(nr_valor)
                            nr_valor = Left(StrDup(8 - Len(nr_valor), " ") + nr_valor, 8)
                            nr_valor = nr_valor & "," & "00"
                        Else
                            nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                            nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), " ") + nr_valor_int, 8)
                            nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                            nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                            nr_valor = nr_valor_int & "," & nr_valor_dec
                        End If
                        valor_total_item = nr_valor
                        valor_liquido_item = valor_total_item

                        linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
                        linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + descricao
                        linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
                        linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
                        linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
                        linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
                        linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + valor_unit
                        linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + valor_total_item
                        linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
                        linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
                        linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + valor_liquido_item
                        linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)

                        linha_plc = linha_plc + 30
                        'End If
                    End If
                End If
            Next
            'Coloca 1 linhas em branco
            linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
            linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + Space(48)
            linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
            linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
            linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
            linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
            linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + Space(10)
            linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + Space(11)
            linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
            linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
            linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + Space(11)
            linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)

            linha_plc = linha_plc + 30

            'Coloca linha total bruto
            descricao = Left("Total Bruto", 48)
            descricao = Left(descricao + StrDup(48 - Len(descricao), " "), 48)

            ' 8 inteiros, virgula e 2 decimais (11 carcateres)
            'Fran 19/12/2008
            'nr_valor = FormatNumber(CStr(nr_valor_total_bruto), 2, , TriState.False, TriState.True)
            nr_valor = FormatNumber(CStr(cta_1400), 2, , TriState.False, TriState.True)
            'Fran 19/12/2008 f
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(8 - Len(nr_valor), " ") + nr_valor, 8)
                nr_valor = nr_valor & "," & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), " ") + nr_valor_int, 8)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_total_item = nr_valor
            'Fran 19/12/2008 - para realizar soma abaixo
            nr_valor_total_bruto = Convert.ToDecimal(valor_total_item)
            'fran 19/12/2008 f

            linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
            linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + descricao
            linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
            linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
            linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
            linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
            linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + Space(10)
            linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + valor_total_item
            linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
            linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
            linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + Space(11)
            linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)

            linha_plc = linha_plc + 30
            nr_valor_total_receber = 0
            'Para as contas de desconto grava demonstrativo
            '19/12/2008 i - Não gera contas descontono demonstrativo apenas funrural, sebrae, etc Adriana Ramos por telefone
            ''For Each lrow In pContasDesconto.Tables(0).Rows

            ''    descricao = Left(lrow.Item("nm_conta"), 48)
            ''    descricao = Left(descricao + StrDup(48 - Len(descricao), " "), 48)

            ''    ' 7 inteiros, a virgula  e 2 decimais (10 caracteres)
            ''    If Not IsDBNull(lrow.Item("nr_valor_conta")) Then
            ''        If Not lrow.Item("nr_valor_conta").ToString.Equals(String.Empty) Then
            ''            nr_valor_total = Round(CDbl(cta_0010) * lrow.Item("nr_valor_conta"), 2)
            ''            nr_valor_total_receber = nr_valor_total_receber + nr_valor_total
            ''            nr_valor = FormatNumber(CStr(Round(lrow.Item("nr_valor_conta"), 4)), 4, , TriState.False, TriState.True)
            ''        Else
            ''            nr_valor = "0"
            ''            nr_valor_total = 0
            ''        End If
            ''    Else
            ''        nr_valor = "0"
            ''        nr_valor_total = 0
            ''    End If
            ''    If nr_valor_total <> 0 Then
            ''        lpos = InStr(1, nr_valor, ",", 1)
            ''        If lpos = 0 Then   ' Se não tem casas decimais
            ''            nr_valor = CStr(nr_valor)
            ''            nr_valor = Left(StrDup(5 - Len(nr_valor), " ") + nr_valor, 5)
            ''            nr_valor = nr_valor & ",0000"
            ''        Else
            ''            nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
            ''            nr_valor_int = Left(StrDup(5 - Len(nr_valor_int), " ") + nr_valor_int, 5)
            ''            nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
            ''            nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
            ''            nr_valor = nr_valor_int & "," & nr_valor_dec
            ''        End If
            ''        valor_unit = nr_valor


            ''        ' 8 inteiros, virgula e 2 decimais (11 carcateres)
            ''        nr_valor = FormatNumber(CStr(nr_valor_total), 2, , TriState.False, TriState.True)
            ''        lpos = InStr(1, nr_valor, ",", 1)
            ''        If lpos = 0 Then   ' Se não tem casas decimais
            ''            nr_valor = CStr(nr_valor)
            ''            nr_valor = Left(StrDup(8 - Len(nr_valor), " ") + nr_valor, 8)
            ''            nr_valor = nr_valor & "," & "00"
            ''        Else
            ''            nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
            ''            nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), " ") + nr_valor_int, 8)
            ''            nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
            ''            nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
            ''            nr_valor = nr_valor_int & "," & nr_valor_dec
            ''        End If
            ''        valor_total_item = nr_valor

            ''        linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
            ''        linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + descricao
            ''        linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
            ''        linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
            ''        linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
            ''        linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
            ''        linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + valor_unit
            ''        linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + valor_total_item
            ''        linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
            ''        linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
            ''        linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + Space(11)
            ''        linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)

            ''        linha_plc = linha_plc + 30
            ''    End If
            ''Next
            'Fran 19/12/2008 f
            'Fran 23/12/2008 i
            nr_valor_total_adto = 0
            If CDbl(cta_0600) <> 0 Then
                'Coloca Linha adiantamento
                descricao = Left("Adiantamento Quinzenal", 48)
                descricao = Left(descricao + StrDup(48 - Len(descricao), " "), 48)

                ' 8 inteiros, virgula e 2 decimais (11 carcateres)
                nr_valor = FormatNumber(CStr(cta_0600), 2, , TriState.False, TriState.True)
                lpos = InStr(1, nr_valor, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    nr_valor = CStr(nr_valor)
                    nr_valor = Left(StrDup(8 - Len(nr_valor), " ") + nr_valor, 8)
                    nr_valor = nr_valor & "," & "00"
                Else
                    nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                    nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), " ") + nr_valor_int, 8)
                    nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                    nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                    nr_valor = nr_valor_int & "," & nr_valor_dec
                End If
                valor_total_item = nr_valor
                'Fran 23/12/2008 - para realizar soma abaixo
                nr_valor_total_adto = Convert.ToDecimal(valor_total_item)
                'fran 23/12/2008 f

                linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + descricao
                linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
                linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
                linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
                linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
                linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + valor_total_item
                linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + Space(11)
                linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)

                linha_plc = linha_plc + 30


            End If
            'Fran 23/12/2008 f
            'se tem funrural
            nr_valor_total_funrural = 0
            'Fran 12/02/2009 i rls16 Total Funrural deve ser conta 1500 sem valor unitario
            'If CDbl(cta_0800) <> 0 Then
            If CDbl(cta_1500) <> 0 Then
                'Fran 12/02/2009 f
                'Coloca Linha FUNRURAL
                'Fran 18/12/2008 i Adriana Ramos pediu alteração
                'descricao = Left("Total FunRural", 48)
                descricao = Left("INSS Produtor Rural", 48)
                'Fran 18/12/2008 i Adriana Ramos pediu alteração
                descricao = Left(descricao + StrDup(48 - Len(descricao), " "), 48)

                'Fran 12/02/2009 f Rls16 - não mandar valor unitario
                'nr_valor = FormatNumber(CStr(cta_0800), 4, , TriState.False, TriState.True)
                'lpos = InStr(1, nr_valor, ",", 1)
                'If lpos = 0 Then   ' Se não tem casas decimais
                '    nr_valor = CStr(nr_valor)
                '    nr_valor = Left(StrDup(7 - Len(nr_valor), " ") + nr_valor, 5)
                '    nr_valor = nr_valor & ",0000"
                'Else
                '    nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                '    nr_valor_int = Left(StrDup(5 - Len(nr_valor_int), " ") + nr_valor_int, 5)
                '    nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                '    nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                '    nr_valor = nr_valor_int & "," & nr_valor_dec
                'End If
                'valor_unit = nr_valor
                'Fran 12/02/2009 f rls16

                'Pega o valor do funrural e multiplica pela atde
                'Fran 12/02/2009 i rls16 - valor funrual conta 1500
                'nr_valor_total = Round(CDec(cta_0010) * CDec(cta_0800), 2)
                nr_valor_total = Round(CDec(cta_1500), 2)
                'Fran 12/02/2009 f rls 16
                'Soma ao total a receber
                'Fran 19/12/2008 i De acordo com Adriana Ramos o funrural deve ser deduzido da soma
                'nr_valor_total_receber = nr_valor_total_receber + nr_valor_total
                nr_valor_total_funrural = nr_valor_total
                'Fran 19/12/2008 f
                'Formata
                'nr_valor = CStr(nr_valor_total)
                ' 8 inteiros, virgula e 2 decimais (11 carcateres)
                nr_valor = FormatNumber(CStr(nr_valor_total), 2, , TriState.False, TriState.True)
                lpos = InStr(1, nr_valor, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    nr_valor = CStr(nr_valor)
                    nr_valor = Left(StrDup(8 - Len(nr_valor), " ") + nr_valor, 8)
                    nr_valor = nr_valor & "," & "00"
                Else
                    nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                    nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), " ") + nr_valor_int, 8)
                    nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                    nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                    nr_valor = nr_valor_int & "," & nr_valor_dec
                End If
                valor_total_item = nr_valor

                linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + descricao
                linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
                linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
                linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
                linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
                'Fran 12/02/2009 i rls16
                'linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + valor_unit
                linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + Space(10)
                'Fran 12/09/2009 f
                linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + valor_total_item
                linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + Space(11)
                linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)

                linha_plc = linha_plc + 30


            End If

            'Fran 27/05/2009 i - Chamado 275 rls17.7 - CENTRAL DE COMPRAS
            nr_valor_total_central_compras = 0
            'Para cada conta de desconto da central de compras
            For Each lrow In pContasDesconto.Tables(0).Rows
                'Se conta da Central
                If lrow.Item("st_clube_compra").ToString.Trim = "S" Then
                    If (Me.dt_referencia <> "01/12/2008") Or (Me.dt_referencia = "01/12/2008" And lrow.Item("cd_conta") <> "0102" And lrow.Item("cd_conta") <> "3000") Then
                        descricao = Left(lrow.Item("nm_conta"), 48)
                        descricao = Left(descricao + StrDup(48 - Len(descricao), " "), 48)

                        'Pega o valor da conta
                        If Not IsDBNull(lrow.Item("nr_valor_conta")) Then
                            If Not lrow.Item("nr_valor_conta").ToString.Equals(String.Empty) Then
                                nr_valor_conta = lrow.Item("nr_valor_conta")
                            Else
                                nr_valor_conta = 0
                            End If
                        Else
                            nr_valor_conta = 0
                        End If
                        'Se for valor unitario multiplica pelo volume
                        If lrow.Item("st_qtd_valor").ToString = "V" Then
                            nr_valor = FormatNumber(CStr(Round(CDbl(cta_0010) * CDbl(nr_valor_conta), 2)), 2, , TriState.False, TriState.True)
                            nr_valor_total_central_compras = nr_valor_total_central_compras + Math.Abs(Round(CDbl(cta_0010) * CDbl(nr_valor_conta), 2))
                        Else
                            nr_valor = FormatNumber(CStr(Round(CDbl(nr_valor_conta), 2)), 2, , TriState.False, TriState.True)
                            nr_valor_total_central_compras = nr_valor_total_central_compras + Math.Abs(Round(CDbl(nr_valor_conta), 2))
                        End If

                        lpos = InStr(1, nr_valor, ",", 1)
                        If lpos = 0 Then   ' Se não tem casas decimais
                            nr_valor = CStr(nr_valor)
                            nr_valor = Left(StrDup(8 - Len(nr_valor), " ") + nr_valor, 8)
                            nr_valor = nr_valor & "," & "00"
                        Else
                            nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                            nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), " ") + nr_valor_int, 8)
                            nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                            nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                            nr_valor = nr_valor_int & "," & nr_valor_dec
                        End If
                        valor_total_item = nr_valor

                        linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
                        linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + descricao
                        linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
                        linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
                        linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
                        linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
                        linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + Space(10)
                        linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + valor_total_item
                        linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
                        linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
                        linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + Space(11)
                        linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)

                        linha_plc = linha_plc + 30
                        'End If
                    End If
                End If
            Next
            'Fran 27/05/2009 f - Chamado 275 rls17.7

            'Coloca linha total RECEBER
            descricao = Left("Valor Total a Receber:", 48)
            descricao = Left(descricao + StrDup(48 - Len(descricao), " "), 48)

            ' 8 inteiros, virgula e 2 decimais (11 carcateres)
            'Fran 23/12/2008 i 
            'fRAN 19/12/2008 i por enquanto pega o valor da nota - funrual depois quando tiver sebrae deve verificar se soma ou nao) Adriana Ramos
            'nr_valor = FormatNumber(CStr(nr_valor_total_bruto + nr_valor_total_receber), 2, , TriState.False, TriState.True)
            'nr_valor = FormatNumber(CStr(nr_valor_total_bruto - nr_valor_total_funrural), 2, , TriState.False, TriState.True)
            '19/12/2008
            'Fran 27/05/2009 i - Chamado 275 rls17.7 Deve deduzir a central de compras
            'nr_valor = FormatNumber(CStr(nr_valor_total_bruto - nr_valor_total_funrural - nr_valor_total_adto), 2, , TriState.False, TriState.True)
            nr_valor = FormatNumber(CStr(nr_valor_total_bruto - nr_valor_total_funrural - nr_valor_total_adto - nr_valor_total_central_compras), 2, , TriState.False, TriState.True)
            'Fran 27/05/2009 f - Chamado 275 rls17.7
            'Fran 23/12/2008 f
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(8 - Len(nr_valor), " ") + nr_valor, 8)
                nr_valor = nr_valor & "," & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(8 - Len(nr_valor_int), " ") + nr_valor_int, 8)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_total_item = nr_valor

            linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
            linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + descricao
            linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
            linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
            linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
            linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
            linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + Space(10)
            linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + valor_total_item
            linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
            linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
            linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + Space(11)
            linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)

            linha_plc = linha_plc + 30

            For linha_plc = linha_plc To 2785 Step 30
                linhatexto = linhatexto + Chr(27) + "*p130x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p340x" + CStr(linha_plc) + "Y" + Space(48)
                linhatexto = linhatexto + Chr(27) + "*p1065x" + CStr(linha_plc) + "Y" + Space(8)
                linhatexto = linhatexto + Chr(27) + "*p1205x" + CStr(linha_plc) + "Y" + Space(3)
                linhatexto = linhatexto + Chr(27) + "*p1275x" + CStr(linha_plc) + "Y" + Space(2)
                linhatexto = linhatexto + Chr(27) + "*p1323x" + CStr(linha_plc) + "Y" + Space(12)
                linhatexto = linhatexto + Chr(27) + "*p1515x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p1680x" + CStr(linha_plc) + "Y" + Space(11)
                linhatexto = linhatexto + Chr(27) + "*p1860x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2015x" + CStr(linha_plc) + "Y" + Space(10)
                linhatexto = linhatexto + Chr(27) + "*p2165x" + CStr(linha_plc) + "Y" + Space(11)
                linhatexto = linhatexto + Chr(27) + "*p2335x" + CStr(linha_plc) + "Y" + Space(4)

            Next


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub formataNotaFiscalProdutor_impostos(ByVal pTransportador As Pessoa, ByVal pcontas As String, ByVal pCFOP As String)
        Try

            'FIELD base-icms             AS CHAR FORMAT "x(13)"
            'FIELD valor-icms            AS CHAR FORMAT "x(13)"
            'FIELD base-icms-sub         AS CHAR FORMAT "x(13)"
            'FIELD valor-icms-sub        AS CHAR FORMAT "x(13)"
            'FIELD valor-frete           AS CHAR FORMAT "x(13)"
            'FIELD valor-seguro          AS CHAR FORMAT "x(13)"
            'FIELD valor-out-despes      AS CHAR FORMAT "x(13)"
            'FIELD valor-tot-ipi         AS CHAR FORMAT "x(13)"
            'FIELD valor-total-prod      AS CHAR FORMAT "x(13)"
            'FIELD valor-total-nf        AS CHAR FORMAT "x(13)"
            'FIELD nome-transp           AS CHAR FORMAT "x(40)"
            'FIELD pagt-frete           AS CHAR FORMAT "x(1)"
            'FIELD cnpj-transp           AS CHAR FORMAT "x(18)"
            'FIELD incr-est-transp       AS CHAR FORMAT "x(18)"
            'FIELD placa-transp          AS CHAR FORMAT "x(10)"
            'FIELD placa-uf-transp       AS CHAR FORMAT "x(2)"
            'FIELD quantidade            AS CHAR FORMAT "x(9)"
            'FIELD endereco-transp       AS CHAR FORMAT "x(40)"
            'FIELD municipio-transp      AS CHAR FORMAT "x(25)"
            'FIELD estado-transp         AS CHAR FORMAT "x(2)"
            'FIELD especie               AS CHAR FORMAT "x(10)"
            'FIELD marca                 AS CHAR FORMAT "x(10)"
            'FIELD numero                AS CHAR FORMAT "x(10)"
            'FIELD peso-bruto            AS CHAR FORMAT "x(11)"
            'FIELD peso-liquido          AS CHAR FORMAT "x(11)"
            'FIELD cfop                  AS CHAR FORMAT "x(8)"
            'FIELD num-pedido            AS CHAR FORMAT "x(16)"
            'FIELD cod-canal-venda       AS CHAR FORMAT "x(5)"
            'FIELD agrupamento           AS CHAR FORMAT "x(12)".
            Dim base_icms As String
            Dim valor_icms As String
            Dim base_icms_sub As String
            Dim valor_icms_sub As String
            Dim valor_frete As String
            Dim valor_seguro As String
            Dim valor_out_despesas As String
            Dim valor_total_ipi As String
            Dim valor_total_prod As String
            Dim valor_total_nf As String
            Dim nome_transp As String
            Dim pagto_frete As String
            Dim cnpj_transp As String
            Dim inscr_estadual_transp As String
            Dim placa_transp As String
            Dim placa_uf_transporte As String
            Dim quantidade As String
            Dim endereco_transp As String
            Dim municipio_transp As String
            Dim estado_transp As String
            Dim especie As String
            Dim marca As String
            Dim numero As String
            Dim peso_bruto As String
            Dim peso_liquido As String
            Dim cfop As String
            Dim num_pedido As String
            Dim cod_canal_venda As String
            Dim agrupamento As String

            Dim lpos As Int16
            Dim nr_valor As String
            Dim nr_valor_int As String
            Dim nr_valor_dec As String

            Dim lposfim As Integer
            Dim cta_1200 As String
            Dim cta_1300 As String
            Dim cta_1400 As String
            Dim cta_0010 As String

            'linhatexto = ""

            lpos = InStr(1, pcontas, "0010=", 1) + 5
            lposfim = InStr(lpos, pcontas, "&", 1)
            cta_0010 = Mid(pcontas, lpos, lposfim - lpos)
            lpos = InStr(1, pcontas, "1200=", 1) + 5
            lposfim = InStr(lpos, pcontas, "&", 1)
            cta_1200 = Mid(pcontas, lpos, lposfim - lpos)
            lpos = InStr(1, pcontas, "1300=", 1) + 5
            lposfim = InStr(lpos, pcontas, "&", 1)
            cta_1300 = Mid(pcontas, lpos, lposfim - lpos)
            lpos = InStr(1, pcontas, "1400=", 1) + 5
            lposfim = InStr(lpos, pcontas, "&", 1)
            cta_1400 = Mid(pcontas, lpos, lposfim - lpos)

            ' 10 inteirosE VIRGULA e 2 decimais (13 caracteres)
            If cta_1200 = "" Then
                nr_valor = "0"
            Else
                nr_valor = FormatNumber(CStr(cta_1200), 2, , TriState.False, TriState.True)
            End If
            'nr_valor = CStr(dsNotaFiscalItem.Tables(0).Rows(li_item).Item("nr_preco_total"))
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(10 - Len(nr_valor), " ") + nr_valor, 10)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), " ") + nr_valor_int, 10)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            base_icms = nr_valor     ' Preço Total (Base ICMS)

            'Calcula ICMS
            nr_valor = FormatNumber(cta_1300, 2, , TriState.False, TriState.True)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(10 - Len(nr_valor), " ") + nr_valor, 10)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), " ") + nr_valor_int, 10)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_icms = nr_valor     ' ICMS

            base_icms_sub = Left(Space(9) + "0,00", 13)
            valor_icms_sub = Left(Space(9) + "0,00", 13)
            valor_frete = Left(Space(9) + "0,00", 13)
            valor_seguro = Left(Space(9) + "0,00", 13)
            valor_out_despesas = Left(Space(9) + "0,00", 13)
            valor_total_ipi = Left(Space(9) + "0,00", 13)

            ' 10 inteiros e 2 decimais (campo 26-Valor Total da Nota)
            nr_valor = FormatNumber(CStr(cta_1400), 2, , TriState.False, TriState.True)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(10 - Len(nr_valor), " ") + nr_valor, 10)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), " ") + nr_valor_int, 10)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_total_nf = nr_valor
            valor_total_prod = valor_total_nf

            nome_transp = Left(pTransportador.nm_pessoa, 40)
            nome_transp = Left(nome_transp + StrDup(40 - Len(nome_transp), " "), 40)

            pagto_frete = "1"
            cnpj_transp = Left(pTransportador.cd_cnpj, 18)
            cnpj_transp = Left(cnpj_transp + StrDup(18 - Len(cnpj_transp), " "), 18)
            inscr_estadual_transp = Left(pTransportador.cd_inscricao_estadual, 18)
            inscr_estadual_transp = Left(inscr_estadual_transp + StrDup(18 - Len(inscr_estadual_transp), " "), 18)
            placa_transp = Space(10)
            'placa_uf_transporte = Left(pTransportador.cd_uf, 2)
            'placa_uf_transporte = Left(placa_uf_transporte + StrDup(2 - Len(placa_uf_transporte), " "), 2)
            placa_uf_transporte = Space(2)

            'ATENÇÃO - INFORMAR  A QUANTIDADE DO ITEM DA NOTA
            'quantidade = Space(9)
            ' 9 inteiros, a virgula  e 2 decimais (12 caracteres)
            nr_valor = FormatNumber(CStr(Round(CDbl(cta_0010), 0)), 0, , TriState.False, TriState.True)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(9 - Len(nr_valor), " ") + nr_valor, 9)
                'nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(9 - Len(nr_valor_int), " ") + nr_valor_int, 9)
                'nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                'nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                'nr_valor = nr_valor_int & "," & nr_valor_dec
                nr_valor = nr_valor_int
            End If
            quantidade = nr_valor

            endereco_transp = Left(pTransportador.ds_endereco, 40)
            endereco_transp = Left(endereco_transp + StrDup(40 - Len(endereco_transp), " "), 40)
            municipio_transp = Left(pTransportador.nm_cidade, 25)
            municipio_transp = Left(municipio_transp + StrDup(25 - Len(municipio_transp), " "), 25)
            estado_transp = Left(pTransportador.cd_uf, 2)
            especie = Space(10)
            marca = Space(10)
            numero = Space(10)
            peso_bruto = Space(11)
            peso_liquido = Left(StrDup(11 - Len(quantidade), " ") + quantidade, 11)
            cfop = Left(pCFOP, 8)
            cfop = Left(cfop + StrDup(8 - Len(cfop), " "), 8)
            num_pedido = Space(16)
            cod_canal_venda = Space(5)
            agrupamento = Space(12)

            '
            linhatexto = linhatexto + Chr(27) + "*p70x2860Y" + base_icms
            linhatexto = linhatexto + Chr(27) + "*p310x2860Y" + valor_icms
            linhatexto = linhatexto + Chr(27) + "*p545x2860Y" + base_icms_sub
            linhatexto = linhatexto + Chr(27) + "*p775x2860Y" + valor_icms_sub
            linhatexto = linhatexto + Chr(27) + "*p1000x2860Y" + valor_frete
            linhatexto = linhatexto + Chr(27) + "*p1220x2860Y" + valor_seguro
            linhatexto = linhatexto + Chr(27) + "*p1440x2860Y" + valor_out_despesas
            linhatexto = linhatexto + Chr(27) + "*p1670x2860Y" + valor_total_ipi
            linhatexto = linhatexto + Chr(27) + "*p1890x2860Y" + valor_total_prod

            linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p7v4s3b4148T"
            linhatexto = linhatexto + Chr(27) + "*p2150x2860Y" + valor_total_nf
            linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p21h0s3b4102T"

            ' Dados do Transportador
            linhatexto = linhatexto + Chr(27) + "*p85x2940Y" + nome_transp
            linhatexto = linhatexto + Chr(27) + "*p1280x2940Y" + pagto_frete
            linhatexto = linhatexto + Chr(27) + "*p1350x2940Y" + cnpj_transp
            linhatexto = linhatexto + Chr(27) + "*p1680x2940Y" + inscr_estadual_transp
            linhatexto = linhatexto + Chr(27) + "*p1980x2940Y" + placa_transp
            linhatexto = linhatexto + Chr(27) + "*p2140x2940Y" + placa_uf_transporte
            linhatexto = linhatexto + Chr(27) + "*p2220x2940Y" + quantidade
            linhatexto = linhatexto + Chr(27) + "*p85x2990Y" + endereco_transp
            linhatexto = linhatexto + Chr(27) + "*p875x2990Y" + municipio_transp
            linhatexto = linhatexto + Chr(27) + "*p1380x2990Y" + estado_transp
            linhatexto = linhatexto + Chr(27) + "*p1460x2990Y" + especie
            linhatexto = linhatexto + Chr(27) + "*p1660x2990Y" + marca
            linhatexto = linhatexto + Chr(27) + "*p1860x2990Y" + numero
            linhatexto = linhatexto + Chr(27) + "*p2030x2990Y" + peso_bruto
            linhatexto = linhatexto + Chr(27) + "*p2220x2990Y" + peso_liquido
            linhatexto = linhatexto + Chr(27) + "*p1570x3390Y" + cfop
            linhatexto = linhatexto + Chr(27) + "*p1740x3390Y" + num_pedido
            linhatexto = linhatexto + Chr(27) + "*p1985x3390Y" + cod_canal_venda
            linhatexto = linhatexto + Chr(27) + "*p2150x3390Y" + agrupamento



        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub formataNotaFiscalProdutor_adicionais(ByVal pDataPagamento As String, ByVal pMensagemAdicionalNF As String)

        Dim adicional_1 As String
        Dim adicional_2 As String
        Dim adicional_3 As String
        Dim adicional(14) As String
        Dim laux As String
        Dim lmsg As String
        Dim i As Integer

        adicional_1 = Space(100)
        adicional_2 = "*DATA DE PAGAMENTO: " + pDataPagamento
        adicional_2 = Left(adicional_2 + StrDup(100 - Len(adicional_2), " "), 100)
        adicional_3 = Space(100)

        For i = 4 To 14
            adicional(i) = Space(100)
        Next

        'Fran rls 17 i
        'laux = pMensagemAdicionalNF
        laux = formatarTexto(pMensagemAdicionalNF)
        'fran rls 17 f
        i = 3
        Do While Len(laux) > 0
            'Pega as 100 primeiras posições
            lmsg = Space(1) + Left(laux, 98)
            lmsg = Left(lmsg + StrDup(100 - Len(lmsg), " "), 100)
            i = i + 1
            adicional(i) = (lmsg)
            'Retira da string as 98 posições já utilizadas
            laux = Mid(laux, 99)
        Loop

        linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p5.2v4s3b4148T"
        linhatexto = linhatexto + Chr(27) + "*p85x3079Y" + adicional_1
        linhatexto = linhatexto + Chr(27) + "*p85x3099Y" + adicional_2
        linhatexto = linhatexto + Chr(27) + "*p85x3119Y" + adicional_3
        linhatexto = linhatexto + Chr(27) + "*p85x3139Y" + adicional(4)
        linhatexto = linhatexto + Chr(27) + "*p85x3159Y" + adicional(5)
        linhatexto = linhatexto + Chr(27) + "*p85x3179Y" + adicional(6)
        linhatexto = linhatexto + Chr(27) + "*p85x3199Y" + adicional(7)
        linhatexto = linhatexto + Chr(27) + "*p85x3219Y" + adicional(8)
        linhatexto = linhatexto + Chr(27) + "*p85x3239Y" + adicional(9)
        linhatexto = linhatexto + Chr(27) + "*p85x3259Y" + adicional(10)
        linhatexto = linhatexto + Chr(27) + "*p85x3279Y" + adicional(11)
        linhatexto = linhatexto + Chr(27) + "*p85x3299Y" + adicional(12)
        linhatexto = linhatexto + Chr(27) + "*p85x3319Y" + adicional(13)
        linhatexto = linhatexto + Chr(27) + "*p85x3339Y" + adicional(14)


    End Sub
    Private Function formataNotaFiscalProdutor_mensagem90graus(ByVal nr_via As Int32, ByVal paidf As String) As String
        Try
            Dim mensagem_90g As String
            Dim linha90graus As String

            linha90graus = ""

            mensagem_90g = Left(paidf, 300)
            mensagem_90g = Left(paidf + StrDup(300 - Len(paidf), " "), 300)
            'Fran rls 17 i
            mensagem_90g = formatarTexto(mensagem_90g)
            'Fran rls 17 f
            linha90graus = linha90graus + Chr(27) + "(8U" + Chr(27) + "(s1p29.04v0s0b5T" + Chr(27) + "*p80x450YAB"

            If nr_via = 2 Or nr_via = 1 Then
                linha90graus = linha90graus + Chr(27) + "(8U" + Chr(27) + "(s1p21.12v0s0b5T" + Chr(27) + "*p80x190YA"
            End If

            linha90graus = linha90graus + Chr(27) + "(19U" + Chr(27) + "(s1p4.5v4s3b4148T"
            linha90graus = linha90graus + Chr(27) + "&a90P" + Chr(27) + "*p700x2430Y" + mensagem_90g

            linha90graus = linha90graus + Space(1)

            'If grampeou = False Then

            'End If
            'linhatexto = linhatexto + Chr(27) + "(9149X" + Chr(27) + "*p80x450YAB"
            'linhatexto = linhatexto + Chr(27) + "(9097X" + Chr(27) + "*p80x190YA"

            'linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p4.5v4s3b4148T"
            'linhatexto = linhatexto + Chr(27) + "&a90P" + Chr(27) + "*p700x2430Y" + mensagem_90g

            formataNotaFiscalProdutor_mensagem90graus = linha90graus
        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
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


            formatarTexto = ltexto
        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
    End Function
    Public Function getRelatorioEntradaCooperativa() As DataSet 'fran 25/01/2011 i

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioEntradaCooperativa", parameters, "ms_nota_fiscal")
            Return dataSet

        End Using

    End Function
    Public Function getRelatorioEntradaCooperativaNotas() As DataSet 'fran 07/2024 i

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioEntradaCooperativaNotas", parameters, "ms_nota_fiscal")
            Return dataSet

        End Using

    End Function
    ' 12/03/2012 - Projeto Themis - Exportação Nota Fiscal Produtor por IE - i
    Public Function exportNotaFiscalProdutorSAP() As Boolean

        ' 14/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - i
        'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo, False, utf8WithoutBom)
        ' 14/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - f

        Try

            Dim li As Int32
            Dim linhatexto As String
            Dim liexportada As Int32

            Dim idestabelecimento As Int32
            Dim dsrowfichaitem As DataRow
            Dim cta0010_valor As Decimal
            Dim cta4000_valor As Decimal
            Dim cta0041_valor As Decimal
            Dim cta1400_valor As Decimal
            Dim cta1200_valor As Decimal
            Dim cta1300_valor As Decimal
            Dim cta1500_valor As Decimal
            Dim cta2055_valor As Decimal 'fran 26/05/2010 i chamado 805
            Dim cta0300_valor As Decimal 'fran 03/05/2010 i chamado 805
            Dim cta0152_valor As Decimal 'fran 12/04/2010 i chamado 772
            Dim media_acidez As Decimal 'fran 12/04/2010 i chamado 772
            Dim incentivo As String 'fran 12/04/2010 i chamado 772
            Dim ctaDesc_valor As Decimal 'Total descontos

            ' Projeto Themis - i
            Dim cta1250_valor As Decimal
            Dim cta2300_valor As Decimal  ' Base PIS
            Dim cta2350_valor As Decimal  ' Aliquota PIS
            Dim cta2400_valor As Decimal  ' Valor PIS
            Dim cta2100_valor As Decimal  ' Base COFINS
            Dim cta2150_valor As Decimal  ' Aliquota COFINS
            Dim cta2200_valor As Decimal  ' Valor COFINS
            ' Projeto Themis - f


            Dim cta2065_valor As Decimal  ' INC 2.5 x Volume
            Dim cta2070_valor As Decimal  ' Valor Liq INC 2.5
            Dim cta0055_valor As Decimal  ' Preço Liq Inc 2.5
            Dim cta2060_valor As Decimal  ' Valor Liq Inc 2.4
            Dim cta0060_valor As Decimal  ' Preço Liq Inc 2.4
            Dim cta0016_valor As Decimal  ' Volume 2.5
            Dim cta0017_valor As Decimal  ' Volume 2.4

            Dim dsfichaitens As DataSet
            Dim naturezaoperacao As New NaturezaOperacao
            Dim dsnaturezaoperacao As DataSet


            Dim usuario As New Usuario(id_modificador)  ' 29/10/2008

            Dim contas As String

            linhatexto = ""


            'BUSCA as propriedades que serao exportadas de acordo com o filtro

            Dim fichafinanceira As New FichaFinanceira
            fichafinanceira.dt_referencia = Me.dt_referencia
            fichafinanceira.st_pagamento = "D"
            fichafinanceira.id_estabelecimento = Me.id_estabelecimento
            fichafinanceira.st_exportacao_nota = Me.st_exportacao
            fichafinanceira.id_grupo = 1
            fichafinanceira.st_emite_nota_fiscal = "N"

            Dim dsNotaFiscal As DataSet = fichafinanceira.getFichaFinanceiraHeaderSAP()  ' 14/03/2012 Projeto Themis
            Me.cd_erro = String.Empty

            'Para cada propriedade/produtor/unid producao
            For li = 0 To dsNotaFiscal.Tables(0).Rows.Count - 1


                'Buscando Dados

                'Estabelecimento da Propriedade
                idestabelecimento = dsNotaFiscal.Tables(0).Rows(li).Item("id_estabelecimento")

                'Busca dados da propriedade
                Dim propriedade As New Propriedade(dsNotaFiscal.Tables(0).Rows(li).Item("id_propriedade"))

                'assume que a propriedade cd_natureza_operacao está vazia
                Me.cd_natureza_operacao = String.Empty
                Me.cd_uf = propriedade.cd_uf

                'NATUREZA de OPERAÇÃO
                'Verifica qual o estado da propriedade/produtotr
                Select Case propriedade.cd_uf
                    Case "MG"
                        'Fran 20/05/2009 i  - rls 17.5 chamdo 263 - Incentivo 2.4
                        ''Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" Then
                        'Se NAO TEM incentivo 2,5, NAO TEM transf credito,  NAO TEM incentivo 2,1 e NAO TEM incentivo 2,4
                        If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                            'Fran 20/05/2009 f 
                            Me.cd_natureza_operacao = "1101AH"
                            incentivo = "Sem Incentivo" 'fran 12/04/2010 chamado 772
                        End If
                        'Fran 20/05/2009 i  - rls 17.5 chamdo 263 - Incentivo 2.4
                        ''Se TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        'If propriedade.st_incentivo_fiscal <> "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" Then
                        'Se TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        If propriedade.st_incentivo_fiscal <> "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                            'Fran 20/05/2009 f 
                            Me.cd_natureza_operacao = "1101AS"
                            incentivo = "2.5%" 'fran 12/04/2010 chamado 772
                        End If
                        'Fran 20/05/2009 i  - rls 17.5 chamdo 263 - Incentivo 2.4
                        'Se NAO TEM incentivo 2,5, TEM transf credito e NAO TEM incentivo 2,1
                        'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "S" And propriedade.st_incentivo_21 = "N" Then
                        If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "S" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                            'Fran 20/05/2009 f 
                            Me.cd_natureza_operacao = "1101AS"
                            incentivo = "Sem Incentivo" 'fran 12/04/2010 chamado 772
                        End If
                        'Fran 20/05/2009 i  - rls 17.5 chamdo 263 - Incentivo 2.4
                        'Se NAO TEM incentivo 2,5, NAO TEM transf credito e TEM incentivo 2,1
                        'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "S" Then
                        If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And (propriedade.st_incentivo_21 = "S" Or propriedade.st_incentivo_24 = "S") Then
                            'Fran 20/05/2009 f 
                            Me.cd_natureza_operacao = "1101AH"
                            incentivo = "2.4%" 'fran 12/04/2010 chamado 772
                        End If
                    Case "SP"
                        'Fran 20/05/2009 i  - rls 17.5 chamdo 263 - Incentivo 2.4
                        'Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" Then
                        If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                            'Fran 20/05/2009 f 
                            'poços dde caldas
                            If idestabelecimento = 1 Then
                                Me.cd_natureza_operacao = "2101AS"
                            End If
                            'guara
                            If idestabelecimento = 2 Then
                                Me.cd_natureza_operacao = "1101AP"
                            End If
                            'águas prata
                            If idestabelecimento = 6 Then
                                Me.cd_natureza_operacao = "1101AP"
                            End If
                            If idestabelecimento = 10 Then 'amparo
                                Me.cd_natureza_operacao = "1101AP"
                            End If
                            incentivo = "Sem Incentivo" 'fran 12/04/2010 chamado 772

                        End If
                    Case "RJ"
                        'Fran 20/05/2009 i  - rls 17.5 chamdo 263 - Incentivo 2.4
                        'Se NAO TEM incentivo 2,5, NAO TEM transf credito e NAO TEM incentivo 2,1
                        'If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" Then
                        If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                            'Fran 20/05/2009 f 
                            'guara
                            If idestabelecimento = 2 Then
                                Me.cd_natureza_operacao = "2101AF"
                            End If
                            incentivo = "Sem Incentivo" 'fran 12/04/2010 chamado 772

                        End If
                    Case "CE"
                        'Adri 02/03/2010 i  - rls 23.11 chamdo 701 - Regra para estado do Ceará - i
                        If propriedade.st_incentivo_fiscal = "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                            'Maracanaú
                            If idestabelecimento = 9 Then
                                Me.cd_natureza_operacao = "1101AV"
                            End If
                            incentivo = "Sem Incentivo" 'fran 12/04/2010 chamado 772

                        End If
                        'Adri 02/03/2010 i  - rls 23.11 chamdo 701 - Regra para estado do Ceará - f
                    Case Else
                        Me.cd_natureza_operacao = "SEM REGRA"

                End Select

                If Me.cd_natureza_operacao <> "SEM REGRA" And Not Me.cd_natureza_operacao.ToString.Equals(String.Empty) Then
                    'Busca dados no cadastro
                    naturezaoperacao.cd_natureza_operacao = Me.cd_natureza_operacao
                    naturezaoperacao.id_situacao = 1 'ativa
                    dsnaturezaoperacao = naturezaoperacao.getNaturezaOperacoesByFilters
                    'Se nao tem cadstro 
                    If dsnaturezaoperacao.Tables(0).Rows.Count = 0 Then
                        Me.cd_erro = "SEM CADASTRO"
                        Me.nm_erro = "Não existe cadastro para a natureza de operação " & Me.cd_natureza_operacao.ToString & "."
                        Me.cd_natureza_operacao = "SEM CADASTRO"
                    End If
                End If

                'Se não há cadastro para natureza operacao ou não foi encontrada regra, Para a geração do arquivo
                If Left(Me.cd_natureza_operacao, 3) = "SEM" Or Me.cd_natureza_operacao.ToString.Equals(String.Empty) Then
                    Me.nr_linhaslidas = li
                    Me.nr_linhasexportadas = liexportada
                    Me.cd_pessoa = dsNotaFiscal.Tables(0).Rows(li).Item("cd_pessoa")
                    Me.nr_nota_fiscal = dsNotaFiscal.Tables(0).Rows(li).Item("nr_nota_fiscal")
                    Me.nr_serie = dsNotaFiscal.Tables(0).Rows(li).Item("nr_serie")
                    Me.id_propriedade = dsNotaFiscal.Tables(0).Rows(li).Item("id_propriedade")
                    If Me.cd_natureza_operacao = "SEM REGRA" Then
                        Me.cd_erro = "SEM REGRA"
                        Me.nm_erro = "Não existem regras de natureza de operação especificadas para o estado " & propriedade.cd_uf & "."
                    End If
                    If Me.cd_natureza_operacao.ToString.Equals(String.Empty) Then
                        Me.cd_erro = "SEM NATUREZA"
                        Me.nm_erro = "Para as informações encontradas no cadastro da propriedade, não há regras de natureza de operação especificadas."
                    End If

                    ArquivoTexto.Close()
                    exportNotaFiscalProdutorSAP = False
                    Exit Try

                End If

                'BUSCA DADOS DAS CONTAS
                fichafinanceira.id_ficha_financeira = dsNotaFiscal.Tables(0).Rows(li).Item("id_ficha_financeira")
                dsfichaitens = fichafinanceira.getFichaFinanceiraItens

                cta0010_valor = 0
                cta4000_valor = 0
                cta0041_valor = 0
                cta1400_valor = 0
                cta1200_valor = 0
                cta1300_valor = 0
                cta1500_valor = 0
                cta0152_valor = 0 'fran 12/04/2010 i chamado 772
                cta2055_valor = 0 'fran 26/05/2010 i chamado 805
                cta0300_valor = 0 'fran 03/05/2010 i chamado 805
                ctaDesc_valor = 0
                cta2065_valor = 0 'fran 11/2022 i  ' INC 2.5 x Volume
                cta2070_valor = 0 'fran 11/2022 i ' Valor Liq INC 2.5
                cta0055_valor = 0 'fran 11/2022 i  ' Preço Liq Inc 2.5
                cta2060_valor = 0 'fran 11/2022 i  ' Valor Liq Inc 2.4
                cta0060_valor = 0 'fran 11/2022 i ' Preço Liq Inc 2.4
                cta0016_valor = 0 'fran 11/2022 i  ' Volume 2.5
                cta0017_valor = 0 'fran 11/2022 i ' Volume 2.4

                If dsfichaitens.Tables(0).Rows.Count > 0 Then
                    For Each dsrowfichaitem In dsfichaitens.Tables(0).Rows
                        Select Case UCase(Trim(dsrowfichaitem.Item("cd_conta")))
                            Case "0010" 'Volume Leite
                                cta0010_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "0041" 'Preço NF
                                cta0041_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1200" 'Base ICMS
                                cta1200_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1300" 'ICMS
                                cta1300_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1500" 'Total FUNRURAL
                                cta1500_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1400" 'Total Nota Fiscal
                                cta1400_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "0152" 'teor de gordura fran 12/04/2010 i chamado 772
                                cta0152_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "0300" 'incentivo fiscal 2.5 fran 03/05/2010 i chamado 805
                                cta0300_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2055" 'incentivo 2.4 fran 26/05/2010 i chamado 805
                                cta2055_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1250" ' Alíquota ICMS - Projeto Themis
                                cta1250_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2300" ' Base PIS - Projeto Themis
                                cta2300_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2350" ' Alíquota PIS - Projeto Themis
                                cta2350_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2400" ' Valor PIS - Projeto Themis
                                cta2400_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2100" ' Base COFINS - Projeto Themis
                                cta2100_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2150" ' Alíquota COFINS - Projeto Themis
                                cta2150_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2200" ' Valor COFINS - Projeto Themis
                                cta2200_valor = dsrowfichaitem.Item("nr_valor_conta")
                                'fran 11/2022 i
                            Case "0016" ' volume 2.5
                                cta0016_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "0017" ' volume 2.4
                                cta0017_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2065" ' incentivo 2.5 x volume
                                cta2065_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2070" ' Valor liq INCENTIVO 2,5
                                cta2070_valor = dsrowfichaitem.Item("nr_valor_12")
                            Case "0055" ' preço liq incentivo 2.5
                                cta0055_valor = dsrowfichaitem.Item("nr_valor_12")
                            Case "2060" ' liq incent 2,4
                                cta2060_valor = dsrowfichaitem.Item("nr_valor_12")
                            Case "0060" ' preço liq inc 2,4
                                cta0060_valor = dsrowfichaitem.Item("nr_valor_12")


                        End Select

                    Next
                End If

                'fran 11/2022 i  verifica se permanece a natureza colocada para propriedade de MG com incentivo fiscal (pode ter incentivo 2.4 por causa do limite de transfererncia 657000
                'se prop MG, tem incentivo 2.5 no cadastro mas não tem volume de leite inc 2.5, assume natureza operacao inc 2.4
                If propriedade.cd_uf = "MG" Then
                    If propriedade.st_incentivo_fiscal <> "N" And propriedade.st_transferencia_credito = "N" And propriedade.st_incentivo_21 = "N" And propriedade.st_incentivo_24 = "N" Then
                        'se tem incentivo 2.5 pelo cadastro mas ñão tem volume de leite na conta 0016 (volume leite 2.5) tem valor
                        If cta0016_valor = 0 Then
                            Me.cd_natureza_operacao = "1101AH"
                            incentivo = "2.4%" 'fran 12/04/2010 chamado 772
                        End If
                    End If
                End If

                'Busca Total dos descontos
                ctaDesc_valor = fichafinanceira.getFichaFinanceiraTotalDescontos

                'Busca media de acidez (cd_analise=3) dos romaneios para a referencia e propriedade
                fichafinanceira.id_propriedade = Convert.ToInt32(dsNotaFiscal.Tables(0).Rows(li).Item("id_propriedade"))
                fichafinanceira.id_unid_producao = Convert.ToInt32(dsNotaFiscal.Tables(0).Rows(li).Item("id_unid_producao"))
                media_acidez = fichafinanceira.getMediaAcidezbyReferenciaRomaneio()

                '====================================================================================
                ' Registro SAP
                '====================================================================================
                'contas = "0010=" + Round(cta0010_valor, 4).ToString + "&0041=" + Round(cta0041_valor, 4).ToString + "&1400=" + Round(cta1400_valor, 2).ToString + "&desc=" + Round(ctaDesc_valor, 2).ToString + "&0152=" + Round(cta0152_valor, 2).ToString + "&1500=" + Round(cta1500_valor, 2).ToString + "&0300=" + Round(cta0300_valor, 4).ToString + "&2055=" + Round(cta2055_valor, 4).ToString + "&"
                contas = "0010=" + Round(cta0010_valor, 4).ToString + "&0041=" + Round(cta0041_valor, 4).ToString + "&1400=" + Round(cta1400_valor, 2).ToString + "&desc=" + Round(ctaDesc_valor, 2).ToString + "&0152=" + Round(cta0152_valor, 2).ToString + "&1500=" + Round(cta1500_valor, 2).ToString + "&0300=" + Round(cta0300_valor, 4).ToString + "&2055=" + Round(cta2055_valor, 4).ToString + "&1250=" + Round(cta1250_valor, 2).ToString + "&1300=" + Round(cta1300_valor, 2).ToString + "&1200=" + Round(cta1200_valor, 2).ToString + "&2300=" + Round(cta2300_valor, 2).ToString + "&2350=" + Round(cta2350_valor, 2).ToString + "&2400=" + Round(cta2400_valor, 2).ToString + "&2100=" + Round(cta2100_valor, 2).ToString + "&2150=" + Round(cta2150_valor, 2).ToString + "&2200=" + Round(cta2200_valor, 2).ToString + "&2065=" + Round(cta2065_valor, 2).ToString + "&2070=" + Round(cta2070_valor, 12).ToString + "&0055=" + Round(cta0055_valor, 12).ToString + "&2060=" + Round(cta2060_valor, 12).ToString + "&0060=" + Round(cta0060_valor, 12).ToString + "&0016=" + Round(cta0016_valor, 4).ToString + "&0017=" + Round(cta0017_valor, 4).ToString + "&"
                'linhatexto = NotaFiscalProdutor_Registro_SAP(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0), contas, incentivo, Round(media_acidez, 4).ToString, propriedade.cd_uf)
                linhatexto = NotaFiscalProdutor_Registro_SAP(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0), contas, incentivo, Round(media_acidez, 4).ToString, propriedade.cd_uf, propriedade.id_item)
                ArquivoTexto.WriteLine(linhatexto)
                linhatexto = ""

                ''====================================================================================
                '' Registro Tipo 2
                ''====================================================================================

                ''Guarda as contas utilizadas registro tipo 2
                'contas = "0010=" + Round(cta0010_valor, 4).ToString + "&0041=" + Round(cta0041_valor, 4).ToString + "&1200=" + Round(cta1200_valor, 2).ToString + "&1300=" + Round(cta1300_valor, 2).ToString + "&1400=" + Round(cta1400_valor, 2).ToString + "&"
                'linhatexto = NotaFiscalProdutor_Registro_2(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0), contas)
                'ArquivoTexto.WriteLine(linhatexto)
                'linhatexto = ""

                ''====================================================================================
                '' Registro Tipo 3  - Duplicatas
                ''====================================================================================

                ''Guarda as contas utilizadas registro tipo 3
                'contas = "1400=" + Round(cta1400_valor, 4).ToString + "&desc=" + Round(ctaDesc_valor, 4).ToString + "&"
                'linhatexto = NotaFiscalProdutor_Registro_3(dsNotaFiscal.Tables(0).Rows(li), dsnaturezaoperacao.Tables(0).Rows(0), contas)
                'ArquivoTexto.WriteLine(linhatexto)
                'linhatexto = ""

                ''====================================================================================
                '' Registro Tipo 4  - Duplicatas
                ''====================================================================================
                'If cta1500_valor > 0 Then
                '    'fran 04/08/2010 i - chamado 811
                '    'linhatexto = NotaFiscalProdutor_Registro_4(Me.dt_emissao, cta1400_valor, cta1500_valor)
                '    'linhatexto = NotaFiscalProdutor_Registro_4(Me.dt_emissao, "IP", cta1400_valor)
                '    linhatexto = NotaFiscalProdutor_Registro_4(Me.dt_emissao, "IQ", cta1400_valor)   ' Adriana 18/08/2010 - Chamado 936 (Trocar código IP para IQ)
                '    'fran 04/08/2010 f - chamado 811
                '    ArquivoTexto.WriteLine(linhatexto)
                '    linhatexto = ""
                '    'fran 04/08/2010 i - chamado 811
                '    'linhatexto = NotaFiscalProdutor_Registro_4(Me.dt_emissao, "IF", cta1400_valor)
                '    linhatexto = NotaFiscalProdutor_Registro_4(Me.dt_emissao, "IZ", cta1400_valor)   ' Adriana 18/08/2010 - Chamado 936 (Trocar código IP para IQ)
                '    ArquivoTexto.WriteLine(linhatexto)
                '    linhatexto = ""
                '    'fran 04/08/2010 f - chamado 811

                'End If


                liexportada = liexportada + 1

            Next

            Me.nr_linhaslidas = li
            Me.nr_linhasexportadas = liexportada
            If liexportada > 0 Then
                exportNotaFiscalProdutorSAP = True 'fran 07/06/2010 
                fichafinanceira.id_modificador = Me.id_modificador
                fichafinanceira.updateFichaFinanceiraExportacaoNF()   ' Atualiza Status=S e data de exportacao
            Else
                exportNotaFiscalProdutorSAP = False
                Me.cd_erro = "SEM LINHAS"
                Me.nm_erro = "Nenhum registro foi encontrado para geração do arquivo de nota fiscal do produtor."
            End If
            ArquivoTexto.Close()


        Catch ex As Exception
            exportNotaFiscalProdutorSAP = False
            Me.cd_erro = "EXCEPTION"
            Me.nm_erro = ex.Message.ToString

            ' 01/12/2008 - i
            Dim calculoexecucao As New CalculoExecucao
            calculoexecucao.nm_erro = ex.Message
            calculoexecucao.insertCalculoExecucaoErro()
            ' 01/12/2008 - f
            ArquivoTexto.Close()

        End Try

    End Function
    Private Function NotaFiscalProdutor_Registro_SAP(ByVal pRegistro As DataRow, ByVal pdsNaturezaOperacao As DataRow, ByVal pContas As String, ByVal pIncentivo As String, ByVal pMedia_Acidez As String, ByVal pCd_UF As String, ByVal pId_Item_Propriedade As Integer) As String

        Try

            Dim linhatexto As String
            Dim lpos As Int16

            ' Registro SAP
            Dim cd_emitente As String
            Dim cd_estabelecimento As String
            Dim dt_emissao As String
            Dim nr_valor As String
            Dim peso_total As String
            Dim valor_total_nota As String
            Dim nr_valor_int As String
            Dim nr_valor_dec As String
            Dim cta_0010 As String
            Dim cta_0041 As String
            Dim cta_1400 As String
            Dim cta_desc As String
            Dim cta_0152 As String
            Dim cta_1500 As String
            Dim cta_2055 As String
            Dim cta_0300 As String
            Dim lposfim As Integer

            Dim lbFunRuralProdutor As Boolean = False

            ' 12/03/2012 - Projeto Themis - i
            Dim cd_item As String
            Dim valor_incentivo_25_24 As String
            Dim valor_aliquota_icms As String
            Dim valor_icms As String
            Dim base_calculo_icms As String
            Dim valor_aliquota_pis As String
            Dim valor_pis As String
            Dim base_calculo_pis As String
            Dim valor_aliquota_cofins As String
            Dim valor_cofins As String
            Dim base_calculo_cofins As String
            Dim valor_funrural As String
            Dim obs1 As String
            Dim obs2 As String
            Dim obs3 As String
            Dim obs4 As String
            Dim obs5 As String
            Dim obs6 As String
            Dim obs7 As String
            Dim obs8 As String
            Dim cta_1200 As String
            Dim cta_1250 As String
            Dim cta_1300 As String
            Dim cta_2300 As String
            Dim cta_2350 As String
            Dim cta_2400 As String
            Dim cta_2100 As String
            Dim cta_2150 As String
            Dim cta_2200 As String
            Dim nr_nota_fiscal_formatado As String   '22/05/2012 - chamado 1551
            ' 12/03/2012 - Projeto Themis - f
            'fran 11/2022 i
            Dim cta_2065 As String  ' INC 2.5 x Volume
            Dim cta_2070 As String  ' Valor Liq INC 2.5
            Dim cta_0055 As String  ' Preço Liq Inc 2.5
            Dim cta_2060 As String  ' Valor Liq Inc 2.4
            Dim cta_0060 As String  ' Preço Liq Inc 2.4
            Dim cta_0016 As String  ' Volume 2.5
            Dim cta_0017 As String  ' Volume 2.4
            Dim preco_liq_incentivo1 As String
            Dim valor_liq_incentivo1 As String
            Dim preco_liq_incentivo2 As String
            Dim valor_liq_incentivo2 As String
            Dim pesototal2 As String

            'fran 11/2022 f


            lpos = InStr(1, pContas, "0010=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0010 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0041=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0041 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "1400=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_1400 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "desc=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_desc = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0152=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0152 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "1500=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_1500 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0300=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0300 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2055=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2055 = Mid(pContas, lpos, lposfim - lpos)
            ' Projeto Themis - i
            lpos = InStr(1, pContas, "1250=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_1250 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "1300=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_1300 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "1200=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_1200 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2300=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2300 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2350=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2350 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2400=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2400 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2100=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2100 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2150=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2150 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2200=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2200 = Mid(pContas, lpos, lposfim - lpos)

            lpos = InStr(1, pContas, "2065=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2065 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2070=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2070 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0055=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0055 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2060=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2060 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0060=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0060 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0016=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0016 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0017=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0017 = Mid(pContas, lpos, lposfim - lpos)

            ' Projeto Themis - f

            linhatexto = ""

            '====================================================================================
            ' Registro SAP
            '====================================================================================

            'fran 31/01/2019 i FUNRURAL 2019 - Se o produtor paga FUNRURAL
            If pRegistro.Item("st_funrural").ToString.Equals("P") Then
                lbFunRuralProdutor = True
            Else
                lbFunRuralProdutor = False
            End If
            'fran 31/01/2019 f FUNRURAL 2019 

            cd_emitente = pRegistro.Item("cd_pessoa_sap").ToString
            cd_emitente = Left(StrDup(10 - Len(cd_emitente), "0") + cd_emitente, 10)

            cd_estabelecimento = Space(4)
            cd_estabelecimento = pRegistro.Item("cd_estabelecimento_sap").ToString
            cd_estabelecimento = Left(cd_estabelecimento + StrDup(4 - Len(cd_estabelecimento), " "), 4)

            'Data de emissão - ultimo dia do mês de referencia
            dt_emissao = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateTime.Parse(Me.dt_referencia.ToString))).ToString("ddMMyyyy")

            'Dim item As New Item(1)
            Dim item As New Item(pId_Item_Propriedade)
            'Fran 18/05 deve ter 18 posiçõews themis
            'cd_item = Left(item.cd_item_sap, 16)
            'cd_item = Left(cd_item + StrDup(16 - Len(cd_item), " "), 16)
            cd_item = Left(item.cd_item_sap, 18)
            'fran 11/07/2012 i zeros a esquerda
            'cd_item = Left(cd_item + StrDup(18 - Len(cd_item), " "), 18)
            cd_item = Left(cd_item + StrDup(18 - Len(cd_item), "0"), 18)
            'fran 11/07/2012 i zeros a esquerda
            'Fran 18/05 deve ter 18 posiçõews themis

            ' Quantity 1 Tamanho 13 posições 

            'fran 11/2022
            'nr_valor = cta_0010

            'se ja verificou que tem incentivo 2.5 e tambem tem a conta de volume 2.4, nota tem os dois incentivos
            If Trim(pIncentivo) = "2.5%" AndAlso CDbl(cta_0017) > 0 Then
                nr_valor = cta_0016
            Else
                nr_valor = cta_0010
            End If
            'fran 11/2022 f

            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'peso_total = Left(StrDup(9 - Len(peso_total), "0") + peso_total, 9)
                'peso_total = nr_valor & "," & "0000"
                nr_valor = Left(StrDup(10 - Len(nr_valor), "0") + nr_valor, 10)
                nr_valor = nr_valor & "," & "00"
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)

            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor_int = Left(StrDup(9 - Len(nr_valor_int), "0") + nr_valor_int, 9)
                nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), "0") + nr_valor_int, 10)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 2)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            peso_total = nr_valor
            'fran 6/07/2012 i deve ser 72 posições
            'obs1 = "Quantidade Recebida: " & FormatNumber(cta_0010, 0) & " litros" & Space(72 - 21 - Len(nr_valor))
            obs1 = Left("Quantidade Recebida: " & FormatNumber(cta_0010, 0) & " litros" & Space(72 - 21 - 7 - Len(FormatNumber(cta_0010, 0))), 72)
            'fran 6/07/2012 f deve ser 72 posições

            ' 13 inteiros e 2 decimais (Valor Total da Nota 15 posicoes) 
            nr_valor = CStr(cta_1400)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor = Left(StrDup(13 - Len(nr_valor), "0") + nr_valor, 13)
                nr_valor = Left(StrDup(12 - Len(nr_valor), "0") + nr_valor, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor = nr_valor & "," & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor_int = Left(StrDup(13 - Len(nr_valor_int), "0") + nr_valor_int, 13)
                nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), "0") + nr_valor_int, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_total_nota = nr_valor

            ' Incentivo 2,5%
            'Fran 01/06/2012 chamado 1561 i Arrendondamento Consolidada SAP
            'Se enviar a conta 0300 * volume, o calculo nao bate por causa do arredondamento. O valor do incentivo está calculado corretamente. Para resolver enviaremos o valor da nota 
            'nr_valor = CStr(Round(CDbl(cta_0300) * CDbl(cta_0010), 2))
            If CDbl(cta_0300) > 0 Then 'se tem incentivo 2,5
                'Pega o valor total do incentivo da diferená do valor total da nota menos o valor da base de icms
                'fran 11/2022 i
                'nr_valor = CStr(Round(CDbl(cta_1400) - CDbl(cta_1200), 2))
                nr_valor = CStr(CDbl(cta_2065))
                'fran 11/2022 f
            Else
                nr_valor = "0"
            End If
            'Fran 01/06/2012 chamado 1561 f Arrendondamento Consolidada SAP

            'fran 6/07/2012 i deve ser 72 posições
            'obs6 = ""
            obs6 = Space(72)
            'fran 6/07/2012 f deve ser 72 posições

            If CInt(nr_valor) > 0 Then
                obs6 = Left("Incentivo à produção e à industrialização do leite(2,5%): R$ " & nr_valor & Space(72 - 61 - Len(nr_valor)), 72)
            End If

            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = Trim(CStr(nr_valor)) & ",00"
            Else
                nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4, "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
            'valor_incentivo_25_24 = nr_valor
            valor_incentivo_25_24 = Left(StrDup(15 - Len(nr_valor), "0") + nr_valor, 15)
            'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)

            If CDbl(cta_0300) = 0 Then 'fran 11/2022 - só assume 2.4 se nao tem incentivo 2.5
                'Incentivo à produção e à industrialização do leite (2,4%)
                nr_valor = CStr(Round(CDbl(cta_2055), 2))

                If CInt(nr_valor) > 0 Then
                    'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                    'valor_incentivo_25_24 = nr_valor  ' Incentivo 2,4
                    valor_incentivo_25_24 = Left(StrDup(15 - Len(nr_valor), "0") + nr_valor, 15)
                    'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                    obs6 = Left("Incentivo à produção e à industrialização do leite(2,4%): R$ " & nr_valor & Space(72 - 61 - Len(nr_valor)), 72)
                End If

                lpos = InStr(1, nr_valor, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    nr_valor = Trim(CStr(nr_valor)) & ",00"
                Else
                    nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                    nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                    nr_valor_dec = Left(nr_valor_dec + StrDup(2, "0"), 2)
                    nr_valor = nr_valor_int & "," & nr_valor_dec
                End If
                'Fran 01/06/2012 - se tiver incentivo 2,4, atualiza variavel para mandar para o arquivo formatado - i 
                If CInt(nr_valor) > 0 Then
                    'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                    'valor_incentivo_25_24 = nr_valor  ' Incentivo 2,4
                    valor_incentivo_25_24 = Left(StrDup(15 - Len(nr_valor), "0") + nr_valor, 15)
                    'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                End If
                'Fran 01/06/2012 - se tiver incentivo 2,4, atualiza variavel para mandar para o arquivo formatado - f 

            End If


            ' Alíquota de ICMS (conta 1250 6 posições)
            nr_valor = CStr(cta_1250)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor = Left(StrDup(4 - Len(nr_valor), "0") + nr_valor, 4)
                nr_valor = Left(StrDup(3 - Len(nr_valor), "0") + nr_valor, 3)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor_int = Left(StrDup(4 - Len(nr_valor_int), "0") + nr_valor_int, 4)
                nr_valor_int = Left(StrDup(3 - Len(nr_valor_int), "0") + nr_valor_int, 3)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_aliquota_icms = nr_valor

            'Calcula ICMS (15 posições)
            nr_valor = cta_1300
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor = Left(StrDup(13 - Len(nr_valor), "0") + nr_valor, 13)
                nr_valor = Left(StrDup(12 - Len(nr_valor), "0") + nr_valor, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                ' = Left(StrDup(13 - Len(nr_valor_int), "0") + nr_valor_int, 13)
                nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), "0") + nr_valor_int, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_icms = nr_valor     ' ICMS

            ' Base ICMS 15 posições
            If cta_1200 = "" Then
                nr_valor = "0"
            Else
                nr_valor = CStr(cta_1200)
            End If
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor = Left(StrDup(13 - Len(nr_valor), "0") + nr_valor, 13)
                nr_valor = Left(StrDup(12 - Len(nr_valor), "0") + nr_valor, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor_int = Left(StrDup(13 - Len(nr_valor_int), "0") + nr_valor_int, 13)
                nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), "0") + nr_valor_int, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            base_calculo_icms = nr_valor     ' Preço Total (Base ICMS)

            ' Alíquota de PIS (conta 2350) 6 posiçoes
            'fran 31/08/2012 i - Pis COFINS não tem mais conforme Cristiano Almeida - enviar zerado
            nr_valor = CStr(cta_2350) 'fran 02/11/2015 i conforme emmail ricado francisco (30/10) deve mandar contas pis e cofins
            'nr_valor = "0" 'fran 02/11/2015 i conforme emmail ricado francisco (30/10) deve mandar contas pis e cofins
            'fran 31/08/2012 f - Pis COFINS não tem mais conforme Cristiano Almeida - enviar zerado
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor = Left(StrDup(4 - Len(nr_valor), "0") + nr_valor, 4)
                nr_valor = Left(StrDup(3 - Len(nr_valor), "0") + nr_valor, 3)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor_int = Left(StrDup(4 - Len(nr_valor_int), "0") + nr_valor_int, 4)
                nr_valor_int = Left(StrDup(3 - Len(nr_valor_int), "0") + nr_valor_int, 3)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_aliquota_pis = nr_valor

            ' Base PIS (conta 2300) 15 posicoes
            'fran 31/08/2012 i - Pis COFINS não tem mais conforme Cristiano Almeida - enviar zerado
            nr_valor = CStr(cta_2300) 'fran 02/11/2015 i conforme emmail ricado francisco (30/10) deve mandar contas pis e cofins
            'nr_valor = "0"'fran 02/11/2015 i conforme emmail ricado francisco (30/10) deve mandar contas pis e cofins
            'fran 31/08/2012 f - Pis COFINS não tem mais conforme Cristiano Almeida - enviar zerado
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor = Left(StrDup(13 - Len(nr_valor), "0") + nr_valor, 13)
                nr_valor = Left(StrDup(12 - Len(nr_valor), "0") + nr_valor, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor_int = Left(StrDup(13 - Len(nr_valor_int), "0") + nr_valor_int, 13)
                nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), "0") + nr_valor_int, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            base_calculo_pis = nr_valor

            ' Valor PIS (conta 2400) 15 posiçoes
            'fran 31/08/2012 i - Pis COFINS não tem mais conforme Cristiano Almeida - enviar zerado
            nr_valor = CStr(cta_2400) 'fran 02/11/2015 i conforme emmail ricado francisco (30/10) deve mandar contas pis e cofins
            ''fran 02/11/2015 i conforme emmail ricado francisco (30/10) deve mandar contas pis e cofins nr_valor = "0"
            'fran 31/08/2012 i - Pis COFINS não tem mais conforme Cristiano Almeida - enviar zerado
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor = Left(StrDup(13 - Len(nr_valor), "0") + nr_valor, 13)
                nr_valor = Left(StrDup(12 - Len(nr_valor), "0") + nr_valor, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor_int = Left(StrDup(13 - Len(nr_valor_int), "0") + nr_valor_int, 13)
                nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), "0") + nr_valor_int, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_pis = nr_valor

            ' Alíquota de COFINS (conta 2150)6 posiçoes
            'fran 31/08/2012 i - Pis COFINS não tem mais conforme Cristiano Almeida - enviar zerado
            nr_valor = CStr(cta_2150) 'fran 02/11/2015 i conforme emmail ricado francisco (30/10) deve mandar contas pis e cofins
            'nr_valor = "0" 'fran 02/11/2015 i conforme emmail ricado francisco (30/10) deve mandar contas pis e cofins
            'fran 31/08/2012 f - Pis COFINS não tem mais conforme Cristiano Almeida - enviar zerado
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor = Left(StrDup(4 - Len(nr_valor), "0") + nr_valor, 4)
                nr_valor = Left(StrDup(3 - Len(nr_valor), "0") + nr_valor, 3)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                ' nr_valor_int = Left(StrDup(4 - Len(nr_valor_int), "0") + nr_valor_int, 4)
                nr_valor_int = Left(StrDup(3 - Len(nr_valor_int), "0") + nr_valor_int, 3)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_aliquota_cofins = nr_valor

            ' Base COFINS (conta 2100) 15 posicoes
            'fran 31/08/2012 i - Pis COFINS não tem mais conforme Cristiano Almeida - enviar zerado
            nr_valor = CStr(cta_2100) 'fran 02/11/2015 i conforme emmail ricado francisco (30/10) deve mandar contas pis e cofins
            'nr_valor = "0" 'fran 02/11/2015 i conforme emmail ricado francisco (30/10) deve mandar contas pis e cofins
            'fran 31/08/2012 f - Pis COFINS não tem mais conforme Cristiano Almeida - enviar zerado
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor = Left(StrDup(13 - Len(nr_valor), "0") + nr_valor, 13)
                nr_valor = Left(StrDup(12 - Len(nr_valor), "0") + nr_valor, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor_int = Left(StrDup(13 - Len(nr_valor_int), "0") + nr_valor_int, 13)
                nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), "0") + nr_valor_int, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            base_calculo_cofins = nr_valor

            ' Valor COFINS (conta 2200) 15 posiçoes
            'fran 31/08/2012 i - Pis COFINS não tem mais conforme Cristiano Almeida - enviar zerado
            nr_valor = CStr(cta_2200) 'fran 02/11/2015 i conforme emmail ricado francisco (30/10) deve mandar contas pis e cofins
            'nr_valor = "0"  'fran 02/11/2015 i conforme emmail ricado francisco (30/10) deve mandar contas pis e cofins
            'fran 31/08/2012 f - Pis COFINS não tem mais conforme Cristiano Almeida - enviar zerado
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor = Left(StrDup(13 - Len(nr_valor), "0") + nr_valor, 13)
                nr_valor = Left(StrDup(12 - Len(nr_valor), "0") + nr_valor, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'Fran 02/07/2012 i Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                'nr_valor_int = Left(StrDup(13 - Len(nr_valor_int), "0") + nr_valor_int, 13)
                nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), "0") + nr_valor_int, 12)
                'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_cofins = nr_valor

            'INSS Produtor Rural
            nr_valor = CStr(cta_1500)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = Trim(CStr(nr_valor)) & ",00"
            Else
                nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4, "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If

            'Fran 14/07/2012 I deve mandar para obs valor sem zeros a esquerda
            valor_funrural = nr_valor
            'Fran 14/07/2012 f deve mandar para obs valor sem zeros a esquerda

            'Fran 31/01/2019 FUNRURAL 2019 i
            'fran 6/07/2012 i deve ser 72 posições
            'obs7 = "INSS Produtor Rural: R$ " & valor_funrural & Space(72 - 25 - Len(valor_funrural))
            'obs7 = Left("INSS Produtor Rural: R$ " & valor_funrural & Space(72 - 24 - Len(valor_funrural)), 72)
            'fran 6/07/2012 f deve ser 72 posições

            If lbFunRuralProdutor = True Then 'se o produtor recolhe o funrural
                obs7 = Left("SENAR/RAT: R$ " & valor_funrural & Space(72 - 14 - Len(valor_funrural)), 72)
            Else
                obs7 = Left("INSS Produtor Rural: R$ " & valor_funrural & Space(72 - 24 - Len(valor_funrural)), 72)
            End If
            'Fran 31/01/2019 FUNRURAL 2019 f

            'Fran 02/07/2012 I Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
            'valor_funrural = nr_valor
            valor_funrural = Left(StrDup(15 - Len(nr_valor), "0") + nr_valor, 15)
            'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)

            'fran 11/2022 i 
            'NOVO LAYOUT PARA 2.4 junto com 2.5
            'PRECO LIQUIDO  15 posicoes com 4 casas decimais
            'se tem incentivo 2.5 os campos preco inc
            'enviar arquivo com 20 posicoes com 12 casas decimais
            If CDbl(cta_0300) > 0 Then
                nr_valor = CStr(cta_0055) 'preco liquido para produtor com icms
            Else
                nr_valor = CStr(cta_0060) 'preco liq para produtor sem icms
            End If

            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'nr_valor = Left(StrDup(10 - Len(nr_valor), "0") + nr_valor, 10)
                'nr_valor = nr_valor & ",0000"
                nr_valor = Left(StrDup(7 - Len(nr_valor), "0") + nr_valor, 7)
                nr_valor = nr_valor & ",000000000000"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), "0") + nr_valor_int, 10)
                nr_valor_int = Left(StrDup(7 - Len(nr_valor_int), "0") + nr_valor_int, 7)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                'nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                nr_valor_dec = Left(nr_valor_dec + StrDup(12 - Len(nr_valor_dec), "0"), 12)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            preco_liq_incentivo1 = nr_valor

            'VALOR LIQUIDO INCENTIVO 15 posicoes com 2 casas decimais
            'se tem incentivo 2.5 assume as contas de 2.5
            If CDbl(cta_0300) > 0 Then
                nr_valor = CStr(cta_2070)
            Else
                nr_valor = CStr(cta_2060) 'se nao tem 2.5 assume 2.4
            End If

            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'nr_valor = Left(StrDup(12 - Len(nr_valor), "0") + nr_valor, 12)
                'nr_valor = nr_valor & ",00"
                nr_valor = Left(StrDup(7 - Len(nr_valor), "0") + nr_valor, 7)
                nr_valor = nr_valor & ",000000000000"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), "0") + nr_valor_int, 12)
                nr_valor_int = Left(StrDup(7 - Len(nr_valor_int), "0") + nr_valor_int, 7)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                'nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor_dec = Left(nr_valor_dec + StrDup(12 - Len(nr_valor_dec), "0"), 12)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_liq_incentivo1 = nr_valor


            'PRECO LIQUIDO INCENTIVO 2 15 posicoes com 4 casas decimais
            'este campo ´e para o caso de ter 2.4 junto com 2.5
            'se tem incentivo 2.5 e tbm incentivo 2.4
            If CDbl(cta_0300) > 0 AndAlso CDbl(cta_2055) > 0 Then
                nr_valor = CStr(cta_0060)
            Else
                nr_valor = "0" 'se nao é essa situacao manda campos zerados
            End If

            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'nr_valor = Left(StrDup(10 - Len(nr_valor), "0") + nr_valor, 10)
                'nr_valor = nr_valor & ",0000"
                nr_valor = Left(StrDup(7 - Len(nr_valor), "0") + nr_valor, 7)
                nr_valor = nr_valor & ",000000000000"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), "0") + nr_valor_int, 10)
                nr_valor_int = Left(StrDup(7 - Len(nr_valor_int), "0") + nr_valor_int, 7)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                'nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                nr_valor_dec = Left(nr_valor_dec + StrDup(12 - Len(nr_valor_dec), "0"), 12)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            preco_liq_incentivo2 = nr_valor

            'VALOR LIQUIDO INCENTIVO 2  - 15 posicoes com 2 casas decimais
            'este campo ´e para o caso de ter 2.4 junto com 2.5
            'se tem incentivo 2.5 e tbm incentivo 2.4
            If CDbl(cta_0300) > 0 AndAlso CDbl(cta_2055) > 0 Then
                nr_valor = CStr(cta_2060)
            Else
                nr_valor = "0" 'se nao é essa situacao manda campos zerados
            End If

            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                'nr_valor = Left(StrDup(12 - Len(nr_valor), "0") + nr_valor, 12)
                'nr_valor = nr_valor & ",00"
                nr_valor = Left(StrDup(7 - Len(nr_valor), "0") + nr_valor, 7)
                nr_valor = nr_valor & ",000000000000"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                'nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), "0") + nr_valor_int, 12)
                nr_valor_int = Left(StrDup(7 - Len(nr_valor_int), "0") + nr_valor_int, 7)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                'nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor_dec = Left(nr_valor_dec + StrDup(12 - Len(nr_valor_dec), "0"), 12)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_liq_incentivo2 = nr_valor

            'PESO TOTAL 2 - 15 posicoes 2 decimais
            'este campo ´e para o caso de ter 2.4 junto com 2.5
            'se tem incentivo 2.5 e tbm incentivo 2.4
            If CDbl(cta_0300) > 0 AndAlso CDbl(cta_2055) > 0 Then
                nr_valor = CStr(cta_0017)
            Else
                nr_valor = "0" 'se nao é essa situacao manda campos zerados
            End If

            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(12 - Len(nr_valor), "0") + nr_valor, 12)
                nr_valor = nr_valor & ",00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), "0") + nr_valor_int, 12)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            pesototal2 = nr_valor

            'fran 11/2022 f


            'Preço do Leite recebido
            'nr_valor = CStr(Round(CDbl(cta_1400) / CDbl(cta_0010), 2)) 'FRAN 14/07/2012  I formata preço com 4 decimais para obs da nota
            nr_valor = CStr(Round(CDbl(cta_1400) / CDbl(cta_0010), 4)) 'FRAN 14/07/2012  I formata preço com 4 decimais para obs da nota
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                'nr_valor = Trim(CStr(nr_valor)) & ",00" 'FRAN 14/07/2012  I formata preço com 4 decimais para obs da nota
                nr_valor = Trim(CStr(nr_valor)) & ",0000" 'FRAN 14/07/2012  I formata preço com 4 decimais para obs da nota
            Else
                nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If

            'fran 6/07/2012 i deve ser 72 posições
            'obs2 = "Preço do Leite Recebido: R$ " & nr_valor & Space(72 - 28 - Len(nr_valor))
            obs2 = Left("Preço do Leite Recebido: R$ " & nr_valor & Space(72 - 28 - Len(nr_valor)), 72)
            'fran 6/07/2012 i deve ser 72 posições

            'Grau de acidez - será informado a media dos resultados de acidez
            nr_valor = CStr(pMedia_Acidez)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = Trim(CStr(nr_valor)) & ",0000"
            Else
                nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            'fran 6/07/2012 i deve ser 72 posições
            'obs3 = "Grau de Acidez: " & nr_valor & Space(72 - 16 - Len(nr_valor))
            obs3 = Left("Grau de Acidez: " & nr_valor & Space(72 - 16 - Len(nr_valor)), 72)
            'fran 6/07/2012 f deve ser 72 posições

            'Teor de Gordura
            nr_valor = CStr(cta_0152)
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = Trim(CStr(nr_valor)) & ",0000"
            Else
                nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 4)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            'fran 6/07/2012 i deve ser 72 posições
            'obs4 = "Teor de Gordura: " & nr_valor & Space(72 - 17 - Len(nr_valor))
            'obs5 = "Aplicabilidade: Leite Indústria" & Space(72 - 31)
            obs4 = Left("Teor de Gordura: " & nr_valor & Space(72 - 17 - Len(nr_valor)), 72)
            obs5 = Left("Aplicabilidade: Leite Indústria" & Space(72 - 31), 72)
            'fran 6/07/2012 i deve ser 72 posições

            'Mensagens CFOP
            'fran 6/07/2012 i deve ser 72 posições
            'obs8 = ""
            obs8 = Space(72)
            'fran 6/07/2012 i deve ser 72 posições

            Select Case Trim(pIncentivo)
                Case "Sem Incentivo"
                    obs8 = Left("Operação Isenta - art. 459 da Parte 1 do Anexo IX do RICMS" & Space(72 - 58), 72)
                Case "2.4%"
                    obs8 = Left("Ressarcimento ao Produtor - art. 75, XXXIII, do RICMS" & Space(72 - 53), 72)
                Case "2.5%"
                    obs8 = Left("Operação tributada nos termos do art. 461 Parte 1 do Anexo IX do RICMS" & Space(72 - 70), 72)
            End Select

            If pCd_UF.Trim.ToString <> "MG" Then
                obs1 = Space(72)
                'fran 17/08/2012 i descritivo do rodape da nota (informação enviada por Marildes
                If pCd_UF.Trim.ToString = "CE" Then 'se for maracanau
                    obs1 = Left("Nota Fiscal emitida Regime Esp. Tributação conf. Termo Acordo nr 13/2010", 72)
                End If
                If pCd_UF.Trim.ToString = "SP" Then 'se for Aguas da Prata
                    obs1 = Left("Operação Isenta de ICMS conforme artigo 103 do Anexo I do RICMS" & Space(72 - 63), 72)
                End If
                'fran 17/08/2012 f descritivo do rodape da nota

                obs2 = Space(72)
                obs3 = Space(72)
                obs4 = Space(72)
                obs5 = Space(72)
                obs6 = Space(72)
                obs7 = Space(72)
                obs8 = Space(72)
            End If

            ' adri 22/05/2012 chamado 1551 - i
            nr_nota_fiscal_formatado = CStr(pRegistro.Item("nr_nota_fiscal"))
            'fran 24/05/2012 i - O NEFNUMBER no SAP TEM 12 Posições
            'nr_nota_fiscal_formatado = Left(StrDup(16 - Len(nr_nota_fiscal_formatado), "0") + nr_nota_fiscal_formatado, 16)
            'nr_nota_fiscal_formatado = Right(StrDup(12 - Len(nr_nota_fiscal_formatado), "0") + nr_nota_fiscal_formatado, 12)
            nr_nota_fiscal_formatado = Right(StrDup(16 - Len(nr_nota_fiscal_formatado), "0") + nr_nota_fiscal_formatado, 16)  ' adri 04/07/2012 chamado 1569 - Cris enviou o lay-out e a NF deve ter 16 posições
            'fran 24/05/2012 f
            'nr_nota_fiscal_formatado = Left(nr_nota_fiscal_formatado + StrDup(16 - Len(nr_nota_fiscal_formatado), " "), 16)
            ' adri 22/05/2012 chamado 1551 - i


            '===========================================================
            'Monta a linha a ser inserida no arquivo texto - lay-out SAP
            '=================================================
            linhatexto = cd_emitente + ";"
            linhatexto = linhatexto + cd_estabelecimento + ";"
            linhatexto = linhatexto + dt_emissao + ";"
            linhatexto = linhatexto + "0003" + ";"
            linhatexto = linhatexto + "CIF" + ";"
            linhatexto = linhatexto + cd_item + ";"
            linhatexto = linhatexto + peso_total + ";"      ' Quantity 1
            'Fran 02/07/2012 I Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
            'linhatexto = linhatexto + "0,00" + ";"          ' Quantity 2
            linhatexto = linhatexto + "00000000000,00" + ";"          ' Quantity 2
            'Fran 02/07/2012 f Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
            linhatexto = linhatexto + valor_total_nota + ";"
            linhatexto = linhatexto + valor_incentivo_25_24 + ";"  ' Incentivo 2,5% ou 2,4%
            linhatexto = linhatexto + valor_aliquota_icms + ";"
            linhatexto = linhatexto + valor_icms + ";"
            linhatexto = linhatexto + base_calculo_icms + ";"
            linhatexto = linhatexto + valor_aliquota_pis + ";"
            linhatexto = linhatexto + valor_pis + ";"
            linhatexto = linhatexto + base_calculo_pis + ";"
            linhatexto = linhatexto + valor_aliquota_cofins + ";"
            linhatexto = linhatexto + valor_cofins + ";"
            linhatexto = linhatexto + base_calculo_cofins + ";"
            'Fran 02/07/2012 I Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
            'linhatexto = linhatexto + "0002,30" + ";"   ' FunRural
            'linhatexto = linhatexto + "002,30" + ";"   ' FunRural 'fran alteracao aliquota funrural

            'Fran 31/01/2019 FUNRURAL 2019 i
            ''fran 31/01/2018 i FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018 TROCA DE 2,3 para 1,5
            'fran 23/04/2017 i troca funrural para 2.3% linhatexto = linhatexto + "000,20" + ";"   ' FunRural 'fran alteracao aliquota funrural
            ''linhatexto = linhatexto + "002,30" + ";"   ' FunRural 'fran 23/04/2017 i troca funrural para 2.3%
            'linhatexto = linhatexto + "001,50" + ";"
            ''fran 31/01/2018 f FUNRURAL JAN/2018 Base Legal: Lei 13.606/2018 publicada em 10/01/2018 TROCA DE 2,3 para 1,5

            If lbFunRuralProdutor = True Then 'se o produtor recolhe o funrural
                'linhatexto = linhatexto + "000,30" + ";"
                linhatexto = linhatexto + "000,20" + ";"
            Else
                linhatexto = linhatexto + "001,50" + ";"
            End If
            'Fran 31/01/2019 FUNRURAL 2019 f


            'Fran 02/07/2012 F Alteração layout de acordo com email de 30/06/2012 do Cristiano (alterado documento escopo e enviado)
            linhatexto = linhatexto + valor_funrural + ";"   ' Valor FunRural
            'linhatexto = linhatexto + Space(16) + ";"   ' NF e-number
            linhatexto = linhatexto + nr_nota_fiscal_formatado + ";"   ' 22/05/2012 chamado 1551 - NF e-number
            'fran 11/2022 i
            linhatexto = linhatexto + preco_liq_incentivo1 + ";"
            linhatexto = linhatexto + valor_liq_incentivo1 + ";"
            linhatexto = linhatexto + preco_liq_incentivo2 + ";"
            linhatexto = linhatexto + valor_liq_incentivo2 + ";"
            linhatexto = linhatexto + pesototal2 + ";"      ' Quantity 3
            linhatexto = linhatexto + "000000000000,00" + ";" ' Quantity 4
            'fran 11/2022 f
            linhatexto = linhatexto + obs1 + ";"    ' "Quantidade Recebida: " & CTA0010 & " litros" 
            linhatexto = linhatexto + obs2 + ";"    ' "Preço do Leite Recebido: R$ " & CTA1400/0010 "
            linhatexto = linhatexto + obs3 + ";"    ' "Grau de Acidez: " & media acidez"
            linhatexto = linhatexto + obs4 + ";"
            linhatexto = linhatexto + obs5 + ";"
            linhatexto = linhatexto + obs6 + ";"
            linhatexto = linhatexto + obs7 + ";"
            linhatexto = linhatexto + obs8 + ";"



            NotaFiscalProdutor_Registro_SAP = linhatexto

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try

    End Function

    Public Function exportNotaFiscalCreditoICMS24SAP() As Boolean

        ' 14/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - i
        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo, False, utf8WithoutBom)
        ' 14/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - f

        Try

            Dim li As Int32
            Dim linhatexto As String
            Dim liexportada As Int32

            Dim idestabelecimento As Int32
            Dim dsrowfichaitem As DataRow
            Dim cta0010_valor As Decimal
            Dim cta1400_valor As Decimal
            Dim cta2055_valor As Decimal 'fran 26/05/2010 i chamado 805
            Dim cta0300_valor As Decimal 'fran 03/05/2010 i chamado 805

            Dim cta2065_valor As Decimal  ' INC 2.5 x Volume
            Dim cta2070_valor As Decimal  ' Valor Liq INC 2.5
            Dim cta0055_valor As Decimal  ' Preço Liq Inc 2.5
            Dim cta2060_valor As Decimal  ' Valor Liq Inc 2.4
            Dim cta0060_valor As Decimal  ' Preço Liq Inc 2.4
            Dim cta0016_valor As Decimal  ' Volume 2.5
            Dim cta0017_valor As Decimal  ' Volume 2.4

            Dim dsfichaitens As DataSet
            Dim naturezaoperacao As New NaturezaOperacao


            Dim usuario As New Usuario(id_modificador)  ' 29/10/2008

            Dim contas As String

            linhatexto = ""


            'BUSCA as propriedades que serao exportadas de acordo com o filtro
            Dim fichafinanceira As New FichaFinanceira
            fichafinanceira.dt_referencia = Me.dt_referencia
            fichafinanceira.st_pagamento = "D"
            fichafinanceira.id_estabelecimento = Me.id_estabelecimento
            fichafinanceira.st_exportacao_nota_24 = Me.st_exportacao
            fichafinanceira.id_grupo = 1
            fichafinanceira.st_emite_nota_fiscal = "N"

            Dim dsNotaFiscal As DataSet = fichafinanceira.getFichaFinanceiraCreditoICMS24SAP()
            Me.cd_erro = String.Empty

            'Para cada propriedade/produtor/unid producao
            For li = 0 To dsNotaFiscal.Tables(0).Rows.Count - 1
                'Buscando Dados

                'Estabelecimento da Propriedade
                idestabelecimento = dsNotaFiscal.Tables(0).Rows(li).Item("id_estabelecimento")

                'Busca dados da propriedade
                Dim propriedade As New Propriedade(dsNotaFiscal.Tables(0).Rows(li).Item("id_propriedade"))

                'assume que a propriedade cd_natureza_operacao está vazia
                Me.cd_natureza_operacao = String.Empty
                Me.cd_uf = propriedade.cd_uf

                'BUSCA DADOS DAS CONTAS
                fichafinanceira.id_ficha_financeira = dsNotaFiscal.Tables(0).Rows(li).Item("id_ficha_financeira")
                dsfichaitens = fichafinanceira.getFichaFinanceiraItens

                cta0010_valor = 0
                cta1400_valor = 0
                cta2055_valor = 0 'fran 26/05/2010 i chamado 805
                cta0300_valor = 0 'fran 03/05/2010 i chamado 805
                cta2065_valor = 0 'fran 11/2022 i  ' INC 2.5 x Volume
                cta2070_valor = 0 'fran 11/2022 i ' Valor Liq INC 2.5
                cta0055_valor = 0 'fran 11/2022 i  ' Preço Liq Inc 2.5
                cta2060_valor = 0 'fran 11/2022 i  ' Valor Liq Inc 2.4
                cta0060_valor = 0 'fran 11/2022 i ' Preço Liq Inc 2.4
                cta0016_valor = 0 'fran 11/2022 i  ' Volume 2.5
                cta0017_valor = 0 'fran 11/2022 i ' Volume 2.4

                If dsfichaitens.Tables(0).Rows.Count > 0 Then
                    For Each dsrowfichaitem In dsfichaitens.Tables(0).Rows
                        Select Case UCase(Trim(dsrowfichaitem.Item("cd_conta")))
                            Case "0010" 'Volume Leite
                                cta0010_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "1400" 'Total Nota Fiscal
                                cta1400_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "0300" 'incentivo fiscal 2.5 fran 03/05/2010 i chamado 805
                                cta0300_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2055" 'incentivo 2.4 fran 26/05/2010 i chamado 805
                                cta2055_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "0016" ' volume 2.5
                                cta0016_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "0017" ' volume 2.4
                                cta0017_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2065" ' incentivo 2.5 x volume
                                cta2065_valor = dsrowfichaitem.Item("nr_valor_conta")
                            Case "2070" ' Valor liq INCENTIVO 2,5
                                cta2070_valor = dsrowfichaitem.Item("nr_valor_12")
                            Case "0055" ' preço liq incentivo 2.5
                                cta0055_valor = dsrowfichaitem.Item("nr_valor_12")
                            Case "2060" ' liq incent 2,4
                                cta2060_valor = dsrowfichaitem.Item("nr_valor_12")
                            Case "0060" ' preço liq inc 2,4
                                cta0060_valor = dsrowfichaitem.Item("nr_valor_12")


                        End Select

                    Next
                End If

                'Busca media de acidez (cd_analise=3) dos romaneios para a referencia e propriedade
                fichafinanceira.id_propriedade = Convert.ToInt32(dsNotaFiscal.Tables(0).Rows(li).Item("id_propriedade"))
                fichafinanceira.id_unid_producao = Convert.ToInt32(dsNotaFiscal.Tables(0).Rows(li).Item("id_unid_producao"))

                '====================================================================================
                ' Registro SAP
                '====================================================================================
                contas = "0010=" + Round(cta0010_valor, 4).ToString + "&1400=" + Round(cta1400_valor, 2).ToString + "&0300=" + Round(cta0300_valor, 4).ToString + "&2055=" + Round(cta2055_valor, 4).ToString + "&2065=" + Round(cta2065_valor, 2).ToString + "&2070=" + Round(cta2070_valor, 12).ToString + "&0055=" + Round(cta0055_valor, 12).ToString + "&2060=" + Round(cta2060_valor, 12).ToString + "&0060=" + Round(cta0060_valor, 12).ToString + "&0016=" + Round(cta0016_valor, 4).ToString + "&0017=" + Round(cta0017_valor, 4).ToString + "&"
                linhatexto = NotaFiscalCreditoICMS24_Registro_SAP(dsNotaFiscal.Tables(0).Rows(li), contas, propriedade.cd_uf, propriedade.id_item)
                ArquivoTexto.WriteLine(linhatexto)
                linhatexto = ""

                liexportada = liexportada + 1

            Next

            Me.nr_linhaslidas = li
            Me.nr_linhasexportadas = liexportada
            If liexportada > 0 Then
                exportNotaFiscalCreditoICMS24SAP = True 'fran 07/06/2010 
                fichafinanceira.id_modificador = Me.id_modificador
                fichafinanceira.updateFichaFinanceiraExportacaoNF_CreditoICMS24()   ' Atualiza Status=S e data de exportacao
            Else
                exportNotaFiscalCreditoICMS24SAP = False
                Me.cd_erro = "SEM LINHAS"
                Me.nm_erro = "Nenhum registro foi encontrado para geração do arquivo de nota fiscal do produtor."
            End If
            ArquivoTexto.Close()


        Catch ex As Exception
            exportNotaFiscalCreditoICMS24SAP = False
            Me.cd_erro = "EXCEPTION"
            Me.nm_erro = ex.Message.ToString

            ' 01/12/2008 - i
            Dim calculoexecucao As New CalculoExecucao
            calculoexecucao.nm_erro = ex.Message
            calculoexecucao.insertCalculoExecucaoErro()
            ' 01/12/2008 - f
            ArquivoTexto.Close()

        End Try

    End Function
    Private Function NotaFiscalCreditoICMS24_Registro_SAP(ByVal pRegistro As DataRow, ByVal pContas As String, ByVal pCd_UF As String, ByVal pId_Item_Propriedade As Integer) As String

        Try

            Dim linhatexto As String
            Dim lpos As Int16

            ' Registro SAP
            Dim cd_emitente As String
            Dim cd_estabelecimento As String
            Dim dt_emissao As String
            Dim nr_valor As String
            Dim peso_total As String
            Dim valor_total_nota As String
            Dim nr_valor_int As String
            Dim nr_valor_dec As String
            Dim cta_0010 As String
            Dim cta_1400 As String
            Dim cta_2055 As String
            Dim cta_0300 As String
            Dim lposfim As Integer

            Dim cd_item As String
            Dim valor_incentivo_25_24 As String
            Dim valor_aliquota_icms As String
            Dim base_calculo_icms As String
            Dim valor_aliquota_pis As String
            Dim valor_pis As String
            Dim base_calculo_pis As String
            Dim valor_aliquota_cofins As String
            Dim valor_cofins As String
            Dim base_calculo_cofins As String
            Dim obs8 As String
            Dim nr_nota_fiscal_formatado As String
            Dim cta_2065 As String  ' INC 2.5 x Volume
            Dim cta_2070 As String  ' Valor Liq INC 2.5
            Dim cta_0055 As String  ' Preço Liq Inc 2.5
            Dim cta_2060 As String  ' Valor Liq Inc 2.4
            Dim cta_0060 As String  ' Preço Liq Inc 2.4
            Dim cta_0016 As String  ' Volume 2.5
            Dim cta_0017 As String  ' Volume 2.4

            lpos = InStr(1, pContas, "0010=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0010 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "1400=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_1400 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0300=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0300 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2055=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2055 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2065=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2065 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2070=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2070 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0055=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0055 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "2060=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_2060 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0060=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0060 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0016=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0016 = Mid(pContas, lpos, lposfim - lpos)
            lpos = InStr(1, pContas, "0017=", 1) + 5
            lposfim = InStr(lpos, pContas, "&", 1)
            cta_0017 = Mid(pContas, lpos, lposfim - lpos)

            ' Projeto Themis - f

            linhatexto = ""

            '====================================================================================
            ' Registro SAP
            '====================================================================================

            cd_emitente = pRegistro.Item("cd_pessoa_sap").ToString
            cd_emitente = Left(StrDup(10 - Len(cd_emitente), "0") + cd_emitente, 10)

            cd_estabelecimento = Space(4)
            cd_estabelecimento = pRegistro.Item("cd_estabelecimento_sap").ToString
            cd_estabelecimento = Left(cd_estabelecimento + StrDup(4 - Len(cd_estabelecimento), " "), 4)

            'Data de emissão - ultimo dia do mês de referencia
            dt_emissao = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateTime.Parse(Me.dt_referencia.ToString))).ToString("ddMMyyyy")

            'Dim item As New Item(1)
            Dim item As New Item(pId_Item_Propriedade)
            cd_item = Left(item.cd_item_sap, 18)
            cd_item = Left(cd_item + StrDup(18 - Len(cd_item), "0"), 18)

            ' Quantity 1 Tamanho 13 posições 

            'se ja verificou que tem incentivo 2.5 e tambem tem a conta de volume 2.4, nota tem os dois incentivos... 
            If CDbl(cta_0017) > 0 Then
                'se tem os dois incentivos 
                nr_valor = cta_0017
            Else
                nr_valor = cta_0010
            End If

            nr_valor = "0"
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(10 - Len(nr_valor), "0") + nr_valor, 10)
                nr_valor = nr_valor & "," & "00"

            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(10 - Len(nr_valor_int), "0") + nr_valor_int, 10)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(4 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            peso_total = nr_valor

            ' 13 inteiros e 2 decimais (Valor Total da Nota 15 posicoes) 
            nr_valor = CStr(cta_1400)
            nr_valor = "0"
            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = CStr(nr_valor)
                nr_valor = Left(StrDup(12 - Len(nr_valor), "0") + nr_valor, 12)
                nr_valor = nr_valor & "," & "00"
            Else
                nr_valor_int = CStr(Left(nr_valor, lpos - 1))  ' Pegar somente o valor inteiro
                nr_valor_int = Left(StrDup(12 - Len(nr_valor_int), "0") + nr_valor_int, 12)
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2 - Len(nr_valor_dec), "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If
            valor_total_nota = nr_valor

            'Incentivo à produção e à industrialização do leite (2,4%)
            nr_valor = CStr(Round(CDbl(cta_2055), 2))

            lpos = InStr(1, nr_valor, ",", 1)
            If lpos = 0 Then   ' Se não tem casas decimais
                nr_valor = Trim(CStr(nr_valor)) & ",00"
            Else
                nr_valor_int = Trim(CStr(Left(nr_valor, lpos - 1)))  ' Pegar somente o valor inteiro
                nr_valor_dec = CStr(Mid(CStr(nr_valor), lpos + 1))  ' Pegar somente o valor decimal
                nr_valor_dec = Left(nr_valor_dec + StrDup(2, "0"), 2)
                nr_valor = nr_valor_int & "," & nr_valor_dec
            End If

            obs8 = Left("Ressarcimento Recebido Destinatário art 75 XXXIII do RICMS R$" & nr_valor & Space(72 - 53), 72)

            valor_incentivo_25_24 = nr_valor

            'se tiver incentivo 2,4, atualiza variavel para mandar para o arquivo formatado - i 
            If CInt(nr_valor) > 0 Then
                valor_incentivo_25_24 = Left(StrDup(15 - Len(nr_valor), "0") + nr_valor, 15)
            End If

            ' Alíquota de ICMS (conta 1250 6 posições)
            valor_aliquota_icms = "000,00"

            ' Base ICMS 15 posições
            base_calculo_icms = Left(StrDup(12, "0"), 12) & ",00"   ' Preço Total (Base ICMS)

            ' Alíquota de PIS (conta 2350) 6 posiçoes
            valor_aliquota_pis = "000,00"

            ' Base PIS (conta 2300) 15 posicoes
            base_calculo_pis = Left(StrDup(12, "0"), 12) & ",00"

            ' Valor PIS (conta 2400) 15 posiçoes
            valor_pis = Left(StrDup(12, "0"), 12) & ",00"

            ' Alíquota de COFINS (conta 2150)6 posiçoes
            valor_aliquota_cofins = "000,00"

            ' Base COFINS (conta 2100) 15 posicoes
            base_calculo_cofins = Left(StrDup(12, "0"), 12) & ",00"

            ' Valor COFINS (conta 2200) 15 posiçoes
            valor_cofins = Left(StrDup(12, "0"), 12) & ",00"

            If pCd_UF.Trim.ToString <> "MG" Then
                obs8 = Space(72)
            End If

            nr_nota_fiscal_formatado = CStr(pRegistro.Item("nr_nota_fiscal"))
            nr_nota_fiscal_formatado = Right(StrDup(16 - Len(nr_nota_fiscal_formatado), "0") + nr_nota_fiscal_formatado, 16)  ' adri 04/07/2012 chamado 1569 - Cris enviou o lay-out e a NF deve ter 16 posições

            '===========================================================
            'Monta a linha a ser inserida no arquivo texto - lay-out SAP
            '=================================================
            linhatexto = cd_emitente + ";"
            linhatexto = linhatexto + cd_estabelecimento + ";"
            linhatexto = linhatexto + dt_emissao + ";"
            linhatexto = linhatexto + "0003" + ";"
            linhatexto = linhatexto + "CIF" + ";"
            linhatexto = linhatexto + cd_item + ";" 'material code
            linhatexto = linhatexto + peso_total + ";"      ' Quantity 1
            linhatexto = linhatexto + valor_total_nota + ";"
            linhatexto = linhatexto + valor_aliquota_icms + ";"
            linhatexto = linhatexto + valor_incentivo_25_24 + ";"  ' Incentivo 2,5% ou 2,4%
            linhatexto = linhatexto + base_calculo_icms + ";"
            linhatexto = linhatexto + valor_aliquota_pis + ";"
            linhatexto = linhatexto + valor_pis + ";"
            linhatexto = linhatexto + base_calculo_pis + ";"
            linhatexto = linhatexto + valor_aliquota_cofins + ";"
            linhatexto = linhatexto + valor_cofins + ";"
            linhatexto = linhatexto + base_calculo_cofins + ";"
            linhatexto = linhatexto + nr_nota_fiscal_formatado + ";"
            linhatexto = linhatexto + obs8 + ";" 'observation
            linhatexto = linhatexto + "000000000000,00" + ";"      ' net price item 1
            linhatexto = linhatexto + "1949/AA" + ";"      ' fixo cfop
            linhatexto = linhatexto + "90" + ";"      ' fixo cst



            NotaFiscalCreditoICMS24_Registro_SAP = linhatexto

        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try

    End Function

End Class
