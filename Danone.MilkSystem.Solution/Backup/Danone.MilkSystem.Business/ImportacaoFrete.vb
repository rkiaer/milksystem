Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO

<Serializable()> Public Class ImportacaoFrete

    Private _id_importacao_frete As Int32
    Private _id_importacao As Int32
    Private _id_propriedade As Int32
    Private _id_transportador As Int32
    Private _id_criacao As Int32
    Private _id_conta As Int32
    Private _id_lancamento As Int32
    Private _dt_referencia As String
    Private _ds_propriedade As String
    Private _ds_transportador As String
    Private _ds_cnpj_transportador As String
    Private _ds_mes_ano_pagamento As String
    Private _ds_valor_desconto As String
    Private _nr_valor_desconto As Decimal
    Private _nm_arquivo As String
    Private _nr_linhaslidas As Int32
    Private _nr_linhasimportadas As Int32
    Private _id_modificador As Int32


    Public Property id_importacao_frete() As Int32
        Get
            Return _id_importacao_frete
        End Get
        Set(ByVal value As Int32)
            _id_importacao_frete = value
        End Set
    End Property
    Public Property id_importacao() As Int32
        Get
            Return _id_importacao
        End Get
        Set(ByVal value As Int32)
            _id_importacao = value
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

    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
        End Set
    End Property
    Public Property id_conta() As Int32
        Get
            Return _id_conta
        End Get
        Set(ByVal value As Int32)
            _id_conta = value
        End Set
    End Property
    Public Property id_lancamento() As Int32
        Get
            Return _id_lancamento
        End Get
        Set(ByVal value As Int32)
            _id_lancamento = value
        End Set
    End Property
    Public Property nr_linhasimportadas() As Int32
        Get
            Return _nr_linhasimportadas
        End Get
        Set(ByVal value As Int32)
            _nr_linhasimportadas = value
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
    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
        End Set
    End Property

    Public Property nr_valor_desconto() As Decimal
        Get
            Return _nr_valor_desconto
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_desconto = value
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
    Public Property ds_propriedade() As String
        Get
            Return _ds_propriedade
        End Get
        Set(ByVal value As String)
            _ds_propriedade = value
        End Set
    End Property

    Public Property ds_transportador() As String
        Get
            Return _ds_transportador
        End Get
        Set(ByVal value As String)
            _ds_transportador = value
        End Set
    End Property
    Public Property ds_cnpj_transportador() As String
        Get
            Return _ds_cnpj_transportador
        End Get
        Set(ByVal value As String)
            _ds_cnpj_transportador = value
        End Set
    End Property
    Public Property ds_valor_desconto() As String
        Get
            Return _ds_valor_desconto
        End Get
        Set(ByVal value As String)
            _ds_valor_desconto = value
        End Set
    End Property

    Public Property ds_mes_ano_pagamento() As String
        Get
            Return _ds_mes_ano_pagamento
        End Get
        Set(ByVal value As String)
            _ds_mes_ano_pagamento = value
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
    Public Property nm_arquivo() As String
        Get
            Return _nm_arquivo
        End Get
        Set(ByVal value As String)
            _nm_arquivo = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me._id_importacao_frete = id
        loadImportacaoFrete()

    End Sub
    Public Sub New()

    End Sub
    Public Function getImportacaoFreteByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getImportacaoFrete", parameters, "ms_getImportacaoFrete")
            Return dataSet

        End Using

    End Function


    Private Sub loadImportacaoFrete()

        Dim dataSet As DataSet = getImportacaoFreteByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertImportacaoFrete() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertImportacaoFrete", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertLancamentoImportacaoFrete() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertLancamentoImportFrete", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub updateImportacaoFrete()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateImportacaoFrete", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateLancamentoImportacaoFrete()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateLancamentoImportFrete", parameters, ExecuteType.Update)

        End Using

    End Sub
    Function importFrete() As Int32

        Dim arqTemp As StreamReader
        arqTemp = File.OpenText(Me.nm_arquivo)

        Try

            Dim linhaarquivo As String

            Dim li As Int16
            Dim erro As Boolean

            Dim cd_propriedade As String
            Dim cnpj_transportador As String
            Dim cnpj_posbarra As String
            Dim cnpj_antbarra As String
            Dim cnpj_sem_formatacao As String
            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim importacaofreteErro As New ImportacaoFreteErro
            Dim transportador As New Pessoa
            Dim lancamento As New Lancamento
            Dim dslancamento As DataSet
            Dim id_conta_5000 As Int32
            Dim id_conta_8000 As Int32
            Dim conta As New Conta
            Dim dsconta As DataSet
            Dim id_lancamento_5000 As Int32
            Dim id_lancamento_8000 As Int32
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32

            Dim lmes As String 'fran 12/02/2012
            Dim lano As String 'fran 12/02/2012

            Dim lpos_ini As Int32
            Dim lpos_fim As Int32


            'descobre os id das contas
            conta.cd_conta = "5000"
            conta.id_situacao = 1
            dsconta = conta.getContaByFilters
            id_conta_5000 = dsconta.Tables(0).Rows(0).Item("id_conta")
            conta.cd_conta = "8000"
            dsconta = conta.getContaByFilters
            id_conta_8000 = dsconta.Tables(0).Rows(0).Item("id_conta")


            importacao.st_tipo_importacao = 3
            importacao.dt_inicio_importacao = Now
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo

            id_importacao = importacao.insertImportacao()

            Me.id_importacao = id_importacao

            li = 0
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                'Fran 02/02/2012 i release frete
                'Tetxos vem entre aspas duplas ("). Retirar as aspas duplas para importação dos dados
                linhaarquivo = Replace(linhaarquivo, """", "")
                'Fran 02/02/2012 f release frete

                li = li + 1

                'Fran 02/02/2012 i - Release Frete chamado 1807?
                'Descarta a primeira linha doi arquivo pois são colunas
                If li > 1 Then
                    'Fran 02/02/2012 f

                    ' Codigo da Propriedade - ds_propriedade
                    lpos_ini = 1
                    cd_propriedade = ""
                    Me.ds_propriedade = String.Empty
                    Me.id_propriedade = 0
                    'Fran 02/02/2012 i release frete
                    'Delimitador deve ser virgula
                    'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ",")
                    'Fran 02/02/2012 f release frete
                    If lpos_fim > 0 Then
                        ds_propriedade = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                        lpos_ini = InStr(1, ds_propriedade, "-")
                        If lpos_ini > 0 Then
                            cd_propriedade = Trim(Left(ds_propriedade, lpos_ini - 1))
                        End If
                    End If

                    ' Valor Desconto
                    lpos_ini = lpos_fim + 1

                    'Fran 02/02/2012 i release frete
                    'Delimitador deve ser virgula
                    'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ",")
                    'Fran 02/02/2012 f release frete
                    ds_valor_desconto = ""
                    Me.nr_valor_desconto = 0
                    If lpos_fim > 0 Then
                        ds_valor_desconto = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                        ds_valor_desconto = Replace(ds_valor_desconto, ".", ",") 'Fran 02/02/2012 
                    End If


                    ' Codigo da Transportador - ds_transportador
                    lpos_ini = lpos_fim + 1
                    'Fran 02/02/2012 i release frete
                    'Delimitador deve ser virgula
                    'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ",")
                    'Fran 02/02/2012 f release frete
                    cnpj_transportador = ""
                    cnpj_sem_formatacao = ""
                    ds_transportador = String.Empty
                    ds_cnpj_transportador = String.Empty
                    Me.id_transportador = 0
                    If lpos_fim > 0 Then
                        ds_transportador = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                        lpos_ini = InStr(1, ds_transportador, "-")
                        If lpos_ini > 0 Then
                            cnpj_sem_formatacao = Trim(Left(ds_transportador, lpos_ini - 1))
                            cnpj_transportador = Trim(Left(ds_transportador, lpos_ini - 1))
                            cnpj_posbarra = Right(cnpj_transportador, 6)
                            cnpj_posbarra = String.Concat("/", Left(cnpj_posbarra, 4), "-", Right(cnpj_posbarra, 2))
                            cnpj_antbarra = Left(cnpj_transportador, Len(cnpj_transportador) - 6)
                            cnpj_antbarra = Right(StrDup(8, "0") + cnpj_antbarra, 8)
                            cnpj_antbarra = String.Concat(Left(cnpj_antbarra, 2) & ".", Mid(cnpj_antbarra, 3, 3), ".", Right(cnpj_antbarra, 3))
                            cnpj_transportador = String.Concat(cnpj_antbarra, cnpj_posbarra)
                            ds_cnpj_transportador = cnpj_transportador
                        End If
                    End If

                    ' Mes Ano de pagamento
                    lpos_ini = lpos_fim + 1
                    'Fran 02/02/2012 i release frete não tem ultimo delimitador
                    'Delimitador deve ser virgula
                    'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    'lpos_fim = InStr(lpos_ini, linhaarquivo, ",")
                    'Fran 02/02/2012 f release frete
                    ds_mes_ano_pagamento = ""
                    Me.dt_referencia = String.Empty
                    'If lpos_fim > 0 Then 'fran 02/02/2012

                    'fran 12/02/2012 i
                    'ds_mes_ano_pagamento = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    ds_mes_ano_pagamento = Trim(Mid(linhaarquivo, lpos_ini))
                    'Me.dt_referencia = String.Concat("01/", ds_mes_ano_pagamento)

                    lpos_ini = 1
                    lpos_fim = InStr(lpos_ini, ds_mes_ano_pagamento, "/")
                    If lpos_fim > 0 Then 'se achou a barra
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, ds_mes_ano_pagamento, "/")

                        If lpos_fim > 0 Then
                            lmes = Trim(Mid(ds_mes_ano_pagamento, lpos_ini, (lpos_fim - lpos_ini)))
                            If Len(lmes) = 1 Then 'se o mes so tem1 posição
                                lmes = String.Concat("0", lmes)
                            End If

                            lano = Trim(Mid(ds_mes_ano_pagamento, lpos_fim + 1))
                            If Len(lano) < 4 Then
                                lano = String.Concat("20", lano)
                            End If

                            Me.dt_referencia = String.Concat("01/", lmes, "/", lano)
                        Else
                            'se não tem barra, data esta errada
                            Me.dt_referencia = String.Empty
                        End If
                    Else
                        'se não tem barra, data esta errada
                        Me.dt_referencia = String.Empty
                    End If

                    'fran 12/02/2012 f



                    '=========================================
                    ' Insere linha importada na importacaon frete
                    '=========================================
                    Me.id_importacao_frete = Me.insertImportacaoFrete
                    '=========================================
                    ' Consistencias
                    '=========================================
                    erro = False
                    importacaofreteErro.id_criacao = Me.id_criacao
                    importacaofreteErro.id_importacao_frete = Me.id_importacao_frete

                    Dim propriedade As New Propriedade
                    If IsNumeric(cd_propriedade) = False Then
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "3"
                        importacaolog.cd_erro = "30001"
                        importacaolog.nm_erro = "Código da propriedade não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        importacaofreteErro.id_importacao_log = id_importacao_log
                        importacaofreteErro.insertImportacaoFreteErro()

                        erro = True
                        Me.id_propriedade = 0
                    Else
                        propriedade.id_propriedade = Convert.ToInt32(cd_propriedade)
                        Dim dsPropriedade As DataSet = propriedade.getPropriedadeByFilters()

                        If Not (dsPropriedade.Tables(0).Rows.Count > 0) Then  '  Se a propriedade nao existe 

                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "3"
                            importacaolog.cd_erro = "30002"
                            importacaolog.nm_erro = "Propriedade não cadastrada"
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()

                            importacaofreteErro.id_importacao_log = id_importacao_log
                            importacaofreteErro.insertImportacaoFreteErro()
                            erro = True

                            Me.id_propriedade = 0

                        Else
                            Me.id_propriedade = propriedade.id_propriedade
                        End If
                    End If

                    If IsNumeric(ds_valor_desconto) = False Then

                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "3"
                        importacaolog.cd_erro = "30003"
                        importacaolog.nm_erro = "Valor do Desconto não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        importacaofreteErro.id_importacao_log = id_importacao_log
                        importacaofreteErro.insertImportacaoFreteErro()
                        erro = True
                        Me.nr_valor_desconto = 0

                    Else
                        Me.nr_valor_desconto = Convert.ToDecimal(ds_valor_desconto)
                    End If

                    If IsNumeric(cnpj_sem_formatacao) = False Then
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "3"
                        importacaolog.cd_erro = "30004"
                        importacaolog.nm_erro = "CNPJ do Transportador não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        importacaofreteErro.id_importacao_log = id_importacao_log
                        importacaofreteErro.insertImportacaoFreteErro()

                        erro = True
                        Me.id_transportador = 0
                    Else
                        transportador.cd_cnpj = cnpj_transportador
                        Dim dstransportador As DataSet = transportador.getPessoaByFilters()

                        If Not (dstransportador.Tables(0).Rows.Count > 0) Then  '  Se o transportador nao existe 

                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "3"
                            importacaolog.cd_erro = "30005"
                            importacaolog.nm_erro = "CNPJ não cadastrado para nenhum Transportador."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()

                            importacaofreteErro.id_importacao_log = id_importacao_log
                            importacaofreteErro.insertImportacaoFreteErro()
                            erro = True

                            Me.id_transportador = 0

                        Else
                            If Not (dstransportador.Tables(0).Rows(0).Item("id_grupo").ToString = "3" Or dstransportador.Tables(0).Rows(0).Item("id_grupo").ToString = "4") Then
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "3"
                                importacaolog.cd_erro = "30006"
                                importacaolog.nm_erro = "O CNPJ informado deve deve ser de uma Cooperativa ou Transportador."
                                importacaolog.id_importacao = id_importacao

                                id_importacao_log = importacaolog.insertImportacaoLog()

                                importacaofreteErro.id_importacao_log = id_importacao_log
                                importacaofreteErro.insertImportacaoFreteErro()
                                erro = True

                            Else
                                If dstransportador.Tables(0).Rows(0).Item("id_situacao").ToString = "2" Then
                                    importacaolog.nr_linha = li
                                    importacaolog.st_importacao = "3"
                                    importacaolog.cd_erro = "30007"
                                    importacaolog.nm_erro = "O transportador informado está desativado."
                                    importacaolog.id_importacao = id_importacao

                                    id_importacao_log = importacaolog.insertImportacaoLog()

                                    importacaofreteErro.id_importacao_log = id_importacao_log
                                    importacaofreteErro.insertImportacaoFreteErro()
                                    erro = True
                                End If

                            End If
                            Me.id_transportador = dstransportador.Tables(0).Rows(0).Item("id_pessoa")

                        End If
                    End If
                    'Consiste datas
                    If IsDate(Me.dt_referencia) = False Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "3"
                        importacaolog.cd_erro = "30008"
                        importacaolog.nm_erro = "Mês e Ano de pagamento inválido."
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()

                        importacaofreteErro.id_importacao_log = id_importacao_log
                        importacaofreteErro.insertImportacaoFreteErro()

                        erro = True
                        Me.dt_referencia = String.Empty

                    End If

                    '=========================================
                    ' Atualiza linha importada na importacaon frete
                    '=========================================
                    Me.updateImportacaoFrete()


                    '=========================================
                    ' Inclui linhas em lancamento
                    '=========================================

                    If erro = False Then
                        id_lancamento_5000 = 0
                        id_lancamento_8000 = 0
                        lancamento.id_propriedade = Me.id_propriedade
                        lancamento.dt_referencia = Me.dt_referencia
                        lancamento.id_transportador = Me.id_transportador
                        lancamento.cd_conta = "5000"
                        lancamento.id_lancamento = 0
                        'dslancamento = lancamento.getLancamentoByFilters
                        'If dslancamento.Tables(0).Rows.Count > 0 Then
                        '    ' Logar
                        '    importacaolog.nr_linha = li
                        '    importacaolog.st_importacao = "3"
                        '    importacaolog.cd_erro = "30009"
                        '    importacaolog.nm_erro = "A conta 5000, existente em lançamentos, foi atualizada com o valor informado na importação."
                        '    importacaolog.id_importacao = id_importacao
                        '    id_importacao_log = importacaolog.insertImportacaoLog()

                        '    importacaofreteErro.id_importacao_log = id_importacao_log
                        '    importacaofreteErro.insertImportacaoFreteErro()
                        '    id_lancamento_5000 = dslancamento.Tables(0).Rows(0).Item("id_lancamento")

                        'End If

                        lancamento.cd_conta = "8000"
                        'dslancamento = lancamento.getLancamentoByFilters
                        'If dslancamento.Tables(0).Rows.Count > 0 Then
                        '    ' Logar
                        '    importacaolog.nr_linha = li
                        '    importacaolog.st_importacao = "3"
                        '    importacaolog.cd_erro = "30010"
                        '    importacaolog.nm_erro = "A conta 8000, existente em lançamentos, foi atualizada com o valor informado na importação."
                        '    importacaolog.id_importacao = id_importacao
                        '    id_importacao_log = importacaolog.insertImportacaoLog()

                        '    importacaofreteErro.id_importacao_log = id_importacao_log
                        '    importacaofreteErro.insertImportacaoFreteErro()
                        '    id_lancamento_8000 = dslancamento.Tables(0).Rows(0).Item("id_lancamento")
                        'End If

                        If id_lancamento_5000 <> 0 Then
                            Me.id_conta = id_conta_5000
                            Me.id_lancamento = id_lancamento_5000
                            Me.updateLancamentoImportacaoFrete()
                        Else
                            Me.id_conta = id_conta_5000
                            Me.insertLancamentoImportacaoFrete()

                        End If
                        If id_lancamento_8000 <> 0 Then
                            Me.id_lancamento = id_lancamento_8000
                            Me.id_conta = id_conta_8000
                            Me.nr_valor_desconto = -Me.nr_valor_desconto
                            Me.updateLancamentoImportacaoFrete()
                        Else
                            Me.id_conta = id_conta_8000
                            Me.nr_valor_desconto = -Me.nr_valor_desconto
                            Me.insertLancamentoImportacaoFrete()
                        End If

                        If id_lancamento_5000 = 0 And id_lancamento_8000 = 0 Then
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "3"
                            importacaolog.cd_erro = ""
                            importacaolog.nm_erro = ""
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog

                            importacaofreteErro.id_importacao_log = id_importacao_log
                            importacaofreteErro.insertImportacaoFreteErro()
                        End If
                        liimportada = liimportada + 1

                    End If
                End If
            Loop
            arqTemp.Close()

            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liimportada

            Return id_importacao

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            arqTemp.Close()

        End Try

    End Function

End Class

