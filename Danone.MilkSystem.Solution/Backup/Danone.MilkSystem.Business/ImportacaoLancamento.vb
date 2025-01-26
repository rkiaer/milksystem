Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO

<Serializable()> Public Class ImportacaoLancamento

    Private _id_importacao_lancamento As Int32
    Private _id_importacao As Int32
    Private _ds_propriedade As String
    Private _ds_referencia As String
    Private _ds_conta As String
    Private _ds_valor As String
    Private _cd_conta As String
    Private _id_conta As Int32
    Private _dt_referencia As String
    Private _id_propriedade As Int32
    Private _nr_valor As Decimal
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _id_produtor As Int32
    Private _st_execucao As String
    Private _dt_fim_execucao As String
    Private _nm_arquivo As String
    Private _nr_linhaslidas As Int32
    Private _nr_linhasimportadas As Int32
    Private _id_modificador As Int32
    Private _dt_pagto_ini As String
    Private _dt_pagto_fim As String


    Public Property id_importacao_lancamento() As Int32
        Get
            Return _id_importacao_lancamento
        End Get
        Set(ByVal value As Int32)
            _id_importacao_lancamento = value
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
    Public Property ds_propriedade() As String
        Get
            Return _ds_propriedade
        End Get
        Set(ByVal value As String)
            _ds_propriedade = value
        End Set
    End Property
    Public Property ds_referencia() As String
        Get
            Return _ds_referencia
        End Get
        Set(ByVal value As String)
            _ds_referencia = value
        End Set
    End Property
    Public Property ds_conta() As String
        Get
            Return _ds_conta
        End Get
        Set(ByVal value As String)
            _ds_conta = value
        End Set
    End Property
    Public Property ds_valor() As String
        Get
            Return _ds_valor
        End Get
        Set(ByVal value As String)
            _ds_valor = value
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
    Public Property cd_conta() As String
        Get
            Return _cd_conta
        End Get
        Set(ByVal value As String)
            _cd_conta = value
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
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
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
    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
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
    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
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
    Public Property dt_pagto_ini() As String
        Get
            Return _dt_pagto_ini
        End Get
        Set(ByVal value As String)
            _dt_pagto_ini = value
        End Set
    End Property
    Public Property dt_pagto_fim() As String
        Get
            Return _dt_pagto_fim
        End Get
        Set(ByVal value As String)
            _dt_pagto_fim = value
        End Set
    End Property
    Public Property st_execucao() As String
        Get
            Return _st_execucao
        End Get
        Set(ByVal value As String)
            _st_execucao = value
        End Set
    End Property
    Public Property dt_fim_execucao() As String
        Get
            Return _dt_fim_execucao
        End Get
        Set(ByVal value As String)
            _dt_fim_execucao = value
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

        Me._id_importacao_lancamento = id
        loadImportacaoLancamento()

    End Sub
    Public Sub New()

    End Sub
    Public Function getImportacaoLancamentoConsDuplicidade() As Int32


        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getImportacaoLancamentoConsDuplicidade", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Function getImportacaoLancamentoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getImportacaoLancamento", parameters, "ms_importacao_lancamento")
            Return dataSet

        End Using

    End Function
    Public Function getImportacaoLancamentoIncluidosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getImportacaoPedidoIncluidos", parameters, "ms_importacao_pedido")
            Return dataSet

        End Using

    End Function
    Private Sub loadImportacaoLancamento()

        Dim dataSet As DataSet = getImportacaoLancamentoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertImportacaoLancamentoLinha() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertImportacaoLancamentoLinha", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateImportacaoLancamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateImportacaoLancamento", parameters, ExecuteType.Update)

        End Using

    End Sub

    Function importLancamento() As Int32

        Dim arqTemp As StreamReader
        arqTemp = File.OpenText(Me.nm_arquivo)

        Try

            Dim linhaarquivo As String

            Dim li As Int16
            Dim erro As Boolean


            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim ImportacaoLancamentoErro As New ImportacaoLancamentoErro
            Dim propriedade As New Propriedade
            Dim conta As New Conta
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32
            Dim lancamento As New Lancamento

            Dim lmes As String
            Dim lano As String
            Dim ldia As String

            Dim lpos_ini As Int32
            Dim lpos_fim As Int32

            importacao.st_tipo_importacao = 8
            importacao.dt_inicio_importacao = Now
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo

            id_importacao = importacao.insertImportacao()
            Me.id_importacao = id_importacao

            li = 0
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                linhaarquivo = Replace(linhaarquivo, """", "")

                li = li + 1

                'Descarta a primeira linha doi arquivo pois são colunas
                If li > 1 Then

                    Me.ds_propriedade = String.Empty
                    Me.ds_referencia = String.Empty
                    Me.ds_conta = String.Empty
                    Me.ds_valor = String.Empty
                    Me.id_propriedade = 0
                    Me.id_conta = 0
                    Me.cd_conta = String.Empty
                    Me.nr_valor = 0

                    ' Codigo propriedade
                    lpos_ini = 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        ds_propriedade = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' Data de referencia
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        ds_referencia = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' Conta
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        ds_conta = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    'valor total
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    'se tem o ; no ultimo ano
                    If lpos_fim > 0 Then
                        ds_valor = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    Else
                        ds_valor = Trim(Mid(linhaarquivo, lpos_ini))
                    End If

                    If Not (ds_valor.ToString.Equals(String.Empty) AndAlso ds_conta.ToString.Equals(String.Empty) AndAlso ds_referencia.ToString.Equals(String.Empty) AndAlso ds_valor.ToString.Equals(String.Empty)) Then

                        '=========================================
                        ' Insere linha importada lançamento
                        '=========================================
                        Me.id_importacao_lancamento = Me.insertImportacaoLancamentoLinha


                        'TRATA data referencia
                        lpos_ini = 1
                        lpos_fim = InStr(lpos_ini, ds_referencia, "/")
                        'If lpos_fim > 0 Then 'se achou a barra
                        '    ldia = "01"

                        '    lmes = Trim(Mid(ds_referencia, lpos_ini, (lpos_fim - lpos_ini)))
                        '    If Len(lmes) = 1 Then 'se o mes so tem1 posição
                        '        lmes = String.Concat("0", lmes)
                        '    End If

                        '    lano = Trim(Mid(ds_referencia, lpos_fim + 1))
                        '    If Len(lano) < 4 Then
                        '        lano = String.Concat("20", lano)
                        '    End If

                        '    Me.dt_referencia = String.Concat(ldia, "/", lmes, "/", lano)

                        'Else
                        '    'se não tem barra, data esta errada
                        '    Me.dt_referencia = String.Empty
                        'End If

                        'tratar valor


                        '=========================================
                        ' Consistencias
                        '=========================================
                        erro = False
                        ImportacaoLancamentoErro.id_criacao = Me.id_modificador
                        ImportacaoLancamentoErro.id_importacao_lancamento = Me.id_importacao_lancamento

                        If IsNumeric(ds_valor) = False Then

                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "8"
                            importacaolog.cd_erro = "80001"
                            importacaolog.nm_erro = "Valor do lançamento não é numérico"
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ImportacaoLancamentoErro.id_importacao_log = id_importacao_log
                            ImportacaoLancamentoErro.insertImportacaolancamentoErro()
                            erro = True
                            Me.nr_valor = 0

                        Else
                            Me.nr_valor = CDec(ds_valor)
                        End If

                        'propriedade
                        If IsNumeric(ds_propriedade) = False Then
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "8"
                            importacaolog.cd_erro = "80002"
                            importacaolog.nm_erro = "Código da Propriedade não é numérico"
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ImportacaoLancamentoErro.id_importacao_log = id_importacao_log
                            ImportacaoLancamentoErro.insertImportacaolancamentoErro()

                            erro = True
                            Me.id_propriedade = 0
                        Else

                            propriedade.id_propriedade = ds_propriedade
                            Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters()

                            If Not (dspropriedade.Tables(0).Rows.Count > 0) Then  '  Se o propriedade nao existe 

                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "8"
                                importacaolog.cd_erro = "80003"
                                importacaolog.nm_erro = "Código Propriedade não cadastrado."
                                importacaolog.id_importacao = id_importacao

                                id_importacao_log = importacaolog.insertImportacaoLog()

                                ImportacaoLancamentoErro.id_importacao_log = id_importacao_log
                                ImportacaoLancamentoErro.insertImportacaolancamentoErro()
                                erro = True

                                Me.id_propriedade = 0

                            Else
                                If (dspropriedade.Tables(0).Rows(0).Item("id_situacao").ToString = "2") Then
                                    importacaolog.nr_linha = li
                                    importacaolog.st_importacao = "8"
                                    importacaolog.cd_erro = "80004"
                                    importacaolog.nm_erro = "A propriedade informada está desativada."
                                    importacaolog.id_importacao = id_importacao

                                    id_importacao_log = importacaolog.insertImportacaoLog()

                                    ImportacaoLancamentoErro.id_importacao_log = id_importacao_log
                                    ImportacaoLancamentoErro.insertImportacaolancamentoErro()
                                    erro = True
                                    Me.id_propriedade = ds_propriedade
                                End If
                                Me.id_propriedade = ds_propriedade

                            End If
                        End If
                        'Consiste datas

                        If IsDate(Me.dt_referencia) = False Then
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "8"
                            importacaolog.cd_erro = "80005"
                            importacaolog.nm_erro = "Data de referência inválida."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ImportacaoLancamentoErro.id_importacao_log = id_importacao_log
                            ImportacaoLancamentoErro.insertImportacaolancamentoErro()

                            erro = True
                        Else
                            If CDate(Me.dt_referencia) < CDate("01/" & DateTime.Now.ToString("MM/yyyy")) Then
                                ' Logar
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "8"
                                importacaolog.cd_erro = "80006"
                                importacaolog.nm_erro = "Data de Referencia deve ser maior ou igual a referência atual."
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()

                                ImportacaoLancamentoErro.id_importacao_log = id_importacao_log
                                ImportacaoLancamentoErro.insertImportacaolancamentoErro()

                                erro = True
                            End If

                        End If


                        conta.cd_conta = Me.ds_conta.Trim
                        conta.id_situacao = 1
                        Dim dsconta As DataSet = conta.getContaByFilters

                        If Not (dsconta.Tables(0).Rows.Count > 0) Then  '   

                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "8"
                            importacaolog.cd_erro = "80007"
                            importacaolog.nm_erro = "Código Conta não cadastrado ou não ativo."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ImportacaoLancamentoErro.id_importacao_log = id_importacao_log
                            ImportacaoLancamentoErro.insertImportacaolancamentoErro()

                            erro = True

                            Me.id_conta = 0

                        Else
                            Me.id_conta = dsconta.Tables(0).Rows(0).Item("id_conta")

                        End If

                        '=========================================
                        ' Atualiza linha importada na importacaon lancmento
                        '=========================================
                        Me.updateImportacaoLancamento()

                        'verifica a duplicidade da nota
                        If erro = False AndAlso Me.getImportacaoLancamentoConsDuplicidade > 0 Then

                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "8"
                            importacaolog.cd_erro = "80008"
                            importacaolog.nm_erro = "O lancamento desta conta, valor e referência para a propriedade já existe em cadastro no sistema."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ImportacaoLancamentoErro.id_importacao_log = id_importacao_log
                            ImportacaoLancamentoErro.insertImportacaolancamentoErro()
                            erro = True

                        End If

                        '=========================================
                        ' Inclui lancamento
                        '=========================================
                        If erro = False Then
                            lancamento.id_conta = Me.id_conta
                            lancamento.dt_referencia = Me.dt_referencia
                            lancamento.id_propriedade = Me.id_propriedade
                            lancamento.nr_valor = Me.nr_valor
                            lancamento.id_importacao = id_importacao
                            lancamento.id_modificador = Me.id_modificador
                            lancamento.insertLancamento()

                            liimportada = liimportada + 1

                        End If
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

