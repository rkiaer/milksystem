Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Text

<Serializable()> Public Class Importacao

    Private _id_importacao As Int32
    Private _st_tipo_importacao As Int32
    Private _nm_arquivo As String
    Private _nm_arquivo_destino As String 'fran 27/09/2013 i 
    Private _id_estabelecimento As Int32
    Private _dt_inicio_importacao As String
    Private _dt_termino_importacao As String
    Private _id_criacao As Int32
    Private _nr_linhaslidas As Int32
    Private _nr_linhasimportadas As Int32


    Public Property id_importacao() As Int32
        Get
            Return _id_importacao
        End Get
        Set(ByVal value As Int32)
            _id_importacao = value
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
    Public Property nm_arquivo_destino() As String
        Get
            Return _nm_arquivo_destino
        End Get
        Set(ByVal value As String)
            _nm_arquivo_destino = value
        End Set
    End Property

    Public Property dt_inicio_importacao() As String
        Get
            Return _dt_inicio_importacao
        End Get
        Set(ByVal value As String)
            _dt_inicio_importacao = value
        End Set
    End Property


    Public Property dt_termino_importacao() As String
        Get
            Return _dt_inicio_importacao
        End Get
        Set(ByVal value As String)
            _dt_inicio_importacao = value
        End Set
    End Property


    Public Property st_tipo_importacao() As Int32
        Get
            Return _st_tipo_importacao
        End Get
        Set(ByVal value As Int32)
            _st_tipo_importacao = value
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

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
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
    Public Property nr_linhasimportadas() As Int32
        Get
            Return _nr_linhasimportadas
        End Get
        Set(ByVal value As Int32)
            _nr_linhasimportadas = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_importacao() = id
        loadImportacao()

    End Sub



    Public Sub New()

    End Sub


    Public Function getImportacaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getImportacoes", parameters, "ms_importacao")
            Return dataSet

        End Using

    End Function

    Private Sub loadImportacao()

        Dim dataSet As DataSet = getImportacaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertImportacao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertImportacoes", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateImportacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateImportacoes", parameters, ExecuteType.Update)

        End Using

    End Sub
    Function importCoopera() As Int32

        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Dim arqTemp As StreamReader  ' Adriana 18/05/2010 - chamado 844

        Try

            Dim pessoa As New Pessoa
            Dim estado As New Estado
            Dim cidade As New Cidade
            Dim banco As New Banco
            Dim estabelecimento As New Estabelecimento
            Dim propriedade As New Propriedade
            Dim unidadeproducao As New UnidadeProducao

            Dim linhaarquivo As String
            'Dim arqTemp As StreamReader

            Dim li As Int16
            Dim erro As Boolean
            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32
            Dim lpos_ini As Int32
            Dim lpos_fim As Int32

            Dim ltipo_registro As String
            Dim endereco_numero As String
            Dim natureza As String
            Dim end_cidade As String
            Dim end_estado As String
            Dim id_estado As Int32
            Dim id_cidade As Int32
            Dim end_cep As String
            Dim cod_banco As String
            Dim id_banco As Int32
            Dim cd_nacionalidade As String
            Dim cd_grauinstrucao As String
            Dim cd_estabelecimento As String
            Dim id_estabelecimento As Int32
            Dim id_pessoa As Int32
            Dim grupo_fornecedor As String
            Dim cd_situacao_propriedade As String
            Dim cd_unidade_producao As String

            Dim id_propriedade As Int32
            Dim id_unidade_producao As Int32

            Dim parameters As List(Of Parameters)

            importacao.st_tipo_importacao = 1
            importacao.dt_inicio_importacao = Now
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo

            id_importacao = importacao.insertImportacao()


            arqTemp = File.OpenText(Me.nm_arquivo)

            li = 0
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                li = li + 1


                ltipo_registro = Mid(linhaarquivo, 1, 3)

                '=============================================================
                ' Cadastro de Pessoas
                '=============================================================
                If ltipo_registro = "100" Then  ' Se cadastro de fornecedor
                    erro = False

                    ' Inicializa Pessoa
                    id_estabelecimento = 0
                    id_pessoa = 0

                    ' Codigo do Produtor
                    lpos_ini = 5
                    lpos_fim = InStr(5, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.cd_pessoa = Mid(linhaarquivo, 5, (lpos_fim - lpos_ini))
                    End If

                    ' Nome do Produtor
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.nm_pessoa = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If

                    ' Nome abreviado
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                    ' Natureza (1 - Pessoa Física e 2 - Pessoa Jurídica)
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        natureza = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        If natureza = "1" Then
                            pessoa.st_categoria = "F"
                        Else
                            If natureza = "2" Then
                                pessoa.st_categoria = "J"
                            Else
                                ' Logar
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                importacaolog.cd_erro = "00002"
                                importacaolog.nm_erro = "Erro: Natureza diferente de 1 e 2."
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                erro = True
                            End If
                        End If
                    Else
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "00001"
                        importacaolog.nm_erro = "Erro: Natureza não informada."
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()
                        erro = True
                    End If

                    ' Grupo de Fornecedor
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        grupo_fornecedor = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If
                    pessoa.id_grupo = 1  ' Estou assumindo 1 - Produtor

                    ' Data de Implantacao
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.dt_inicio = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        If IsDate(pessoa.dt_inicio) = False Then
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00003"
                            importacaolog.nm_erro = "Erro: A data de implantacao não é uma data válida."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If

                    ' Endereço
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.ds_endereco = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If

                    ' Numero
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        endereco_numero = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        If IsNumeric(endereco_numero) = True Then
                            pessoa.nr_endereco = endereco_numero
                        Else
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            'importacaolog.cd_erro = "00004"
                            importacaolog.cd_erro = ""
                            importacaolog.nm_erro = "Aviso: O número so endereço não é numérico."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            'erro = True
                        End If
                    End If

                    ' Bairro
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.ds_bairro = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If

                    ' Municipio
                    end_cidade = ""
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        end_cidade = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If

                    ' Estado
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        end_estado = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        estado.cd_uf = end_estado
                        id_estado = estado.getEstadosByUF()
                        If id_estado > 0 Then
                            pessoa.id_estado = id_estado

                            ' Busca id_cidade
                            cidade.id_estado = pessoa.id_estado
                            cidade.nm_cidade = end_cidade
                            id_cidade = cidade.getCidadesByNome()
                            If id_cidade > 0 Then
                                pessoa.id_cidade = id_cidade
                            End If
                        Else
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            'importacaolog.cd_erro = "00005"
                            importacaolog.cd_erro = ""
                            importacaolog.nm_erro = "Aviso: UF inválida ou não encontrada."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            'erro = True
                        End If
                    End If

                    ' CEP
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        end_cep = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        If Len(end_cep) = 8 Then
                            pessoa.cd_cep = Left(end_cep, 5) & "-" & Right(end_cep, 3)
                        End If
                    End If

                    ' Caixa Postal
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                    ' Telefone 1  
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.ds_telefone_1 = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        'If Trim(pessoa.ds_telefone_1) <> "" Then
                        '    If Left(pessoa.ds_telefone_1, 1) <> "(" And Mid(pessoa.ds_telefone_1, 5, 1) <> ")" Then
                        '        ' Logar
                        '        importacaolog.nr_linha = li
                        '        importacaolog.st_importacao = "2"
                        '        'importacaolog.cd_erro = "00009"
                        '        importacaolog.cd_erro = ""
                        '        importacaolog.nm_erro = "Aviso: Telefone 1 no formato inválido."
                        '        importacaolog.id_importacao = id_importacao
                        '        id_importacao_log = importacaolog.insertImportacaoLog()
                        '        'erro = True
                        '    Else
                        '        pessoa.ds_telefone_1 = "(" & Mid(pessoa.ds_telefone_1, 3, 2) & ")" & Mid(pessoa.ds_telefone_1, 6, Len(pessoa.ds_telefone_1) - 5)
                        '    End If
                        'End If
                    End If

                    ' Telefone 2
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.ds_telefone_2 = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        'If Trim(pessoa.ds_telefone_2) <> "" Then
                        '    If Left(pessoa.ds_telefone_2, 1) <> "(" And Mid(pessoa.ds_telefone_2, 5, 1) <> ")" Then
                        '        ' Logar
                        '        importacaolog.nr_linha = li
                        '        importacaolog.st_importacao = "2"
                        '        'importacaolog.cd_erro = "00009"
                        '        importacaolog.cd_erro = ""
                        '        importacaolog.nm_erro = "Aviso: Telefone 2 no formato inválido."
                        '        importacaolog.id_importacao = id_importacao
                        '        id_importacao_log = importacaolog.insertImportacaoLog()
                        '        'erro = True
                        '    Else
                        '        pessoa.ds_telefone_2 = "(" & Mid(pessoa.ds_telefone_2, 3, 2) & ")" & Mid(pessoa.ds_telefone_2, 6, Len(pessoa.ds_telefone_2) - 5)
                        '    End If
                        'End If
                    End If

                    ' Telefone 3
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.ds_telefone_3 = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        'If Trim(pessoa.ds_telefone_3) <> "" Then
                        '    If Left(pessoa.ds_telefone_3, 1) <> "(" And Mid(pessoa.ds_telefone_3, 5, 1) <> ")" Then
                        '        ' Logar
                        '        importacaolog.nr_linha = li
                        '        importacaolog.st_importacao = "2"
                        '        'importacaolog.cd_erro = "00009"
                        '        importacaolog.cd_erro = ""
                        '        importacaolog.nm_erro = "Aviso: Telefone 3 no formato inválido."
                        '        importacaolog.id_importacao = id_importacao
                        '        id_importacao_log = importacaolog.insertImportacaoLog()
                        '        'erro = True
                        '    Else
                        '        pessoa.ds_telefone_3 = "(" & Mid(pessoa.ds_telefone_3, 3, 2) & ")" & Mid(pessoa.ds_telefone_3, 6, Len(pessoa.ds_telefone_3) - 5)
                        '    End If
                        'End If
                    End If

                    ' Email
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.ds_email = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If

                    ' Portador
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                    ' Codigo do Banco
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        cod_banco = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        If IsNumeric(cod_banco) = False Then
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            'importacaolog.cd_erro = "00009"
                            importacaolog.cd_erro = ""
                            importacaolog.nm_erro = "Aviso: Codigo do Banco não é válido."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            'erro = True
                        Else
                            banco.cd_banco = cod_banco
                            id_banco = banco.getBancosByCodigo()
                            If id_banco > 0 Then
                                pessoa.id_banco = id_banco
                            Else
                                ' Logar
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                'importacaolog.cd_erro = "00006"
                                importacaolog.cd_erro = ""
                                importacaolog.nm_erro = "Aviso: Codigo do Banco não encontrado."
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                'erro = True
                            End If

                        End If

                    End If

                    ' Agencia
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.cd_agencia = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If

                    ' Conta Corrente
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.cd_conta = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If

                    ' Tipo da Conta
                    pessoa.id_tipo_conta = 1  '  1 - Conta Corrente

                    ' Condicao de pagamento
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                    ' Inscrição estadual
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.cd_inscricao_estadual = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If

                    ' Inscrição Municiapl
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.cd_inscricao_municipal = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If

                    ' CNPJ
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.cd_cnpj = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        If Len(pessoa.cd_cnpj) = 14 Then
                            'pessoa.cd_cnpj = Left(pessoa.cd_cnpj, 2) & "." & Mid(pessoa.cd_cnpj, 3, 3) & "." & Mid(pessoa.cd_cnpj, 6, 3) & "\" & Mid(pessoa.cd_cnpj, 9, 4) & "-" & Mid(pessoa.cd_cnpj, 13, 2)
                            pessoa.cd_cnpj = Left(pessoa.cd_cnpj, 2) & "." & Mid(pessoa.cd_cnpj, 3, 3) & "." & Mid(pessoa.cd_cnpj, 6, 3) & "/" & Mid(pessoa.cd_cnpj, 9, 4) & "-" & Mid(pessoa.cd_cnpj, 13, 2)   ' Acerto da barra CNPJ
                        End If
                    End If

                    ' CPF
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.cd_cpf = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        If Trim(pessoa.cd_cpf) <> "" And Trim(pessoa.cd_cpf) <> "?" Then
                            pessoa.cd_cpf = Left(pessoa.cd_cpf, 3) & "." & Mid(pessoa.cd_cpf, 4, 3) & "." & Mid(pessoa.cd_cpf, 7, 3) & "-" & Mid(pessoa.cd_cpf, 10, 2)
                        End If
                    End If

                    ' Órgão Emissor RG
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.cd_orgao_emissor = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If

                    ' Data Nascimento
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.dt_nascimento = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        If IsDate(pessoa.dt_nascimento) = False Then
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            'importacaolog.cd_erro = "00007"
                            importacaolog.cd_erro = ""
                            importacaolog.nm_erro = "Aviso: A data de nascimento não é uma data válida."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            pessoa.dt_nascimento = ""
                            'erro = True
                        End If
                    End If

                    ' Sexo
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.st_sexo = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If

                    ' Nacionalidade
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If Trim(pessoa.st_categoria) = "F" Then   ' Se pessoa física
                        If lpos_fim > 0 Then
                            cd_nacionalidade = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                            pessoa.id_nacionalidade = 1  ' Brasileiro
                        End If
                    End If

                    ' Grau Instrucao
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If Trim(pessoa.st_categoria) = "F" Then   ' Se pessoa física
                        If lpos_fim > 0 Then
                            cd_grauinstrucao = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                            pessoa.id_grau_instrucao = 1  'Por enquanto
                        End If
                    End If

                    ' SIF
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.cd_sif = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If

                    ' Estabelecimento
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        cd_estabelecimento = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        Select Case cd_estabelecimento
                            Case "99900"
                                cd_estabelecimento = "005"
                            Case "99905"
                                cd_estabelecimento = "006"
                            Case "99906"
                                cd_estabelecimento = "002"
                            Case "99909"
                                cd_estabelecimento = "015"
                            Case "99910"
                                cd_estabelecimento = "004"
                            Case Else
                                cd_estabelecimento = ""
                                ' Logar
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                importacaolog.cd_erro = "00008"
                                importacaolog.nm_erro = "Erro: Codigo do Estabelecimento não encontrado." & " Código = " & cd_estabelecimento
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                erro = True
                        End Select
                        If cd_estabelecimento <> "" Then
                            estabelecimento.cd_estabelecimento = cd_estabelecimento
                            id_estabelecimento = estabelecimento.getEstabelecimentoByCodigo()
                            If id_estabelecimento > 0 Then
                                pessoa.id_estabelecimento = id_estabelecimento
                            Else
                                ' Logar
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                importacaolog.cd_erro = "00008"
                                importacaolog.nm_erro = "Erro: Codigo do Estabelecimento não encontrado." & " Código = " & cd_estabelecimento
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                erro = True
                            End If
                        End If
                    End If

                    ' Empresa Nacional
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        pessoa.st_empresa_nacional = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        If Trim(pessoa.st_empresa_nacional) = "" Or pessoa.st_empresa_nacional = "1" Then
                            pessoa.st_empresa_nacional = "S"
                        Else
                            pessoa.st_empresa_nacional = "N"
                        End If
                    End If

                    If erro = False Then
                        pessoa.id_pessoa_situacao = 1  ' 1 - Aprovado
                        pessoa.id_situacao = 1
                        pessoa.id_modificador = 1
                        pessoa.st_emite_nota_fiscal = "N"   ' 29/09/2008

                        parameters = ParametersEngine.getParametersFromObject(pessoa)
                        id_pessoa = CType(transacao.ExecuteScalar("ms_insertPessoas", parameters, ExecuteType.Insert), Int32)
                        liimportada = liimportada + 1

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "1"
                        importacaolog.cd_erro = ""
                        importacaolog.nm_erro = ""
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog
                    End If

                End If

                '=============================================================
                ' cadastro de propriedade
                '=============================================================
                If ltipo_registro = "200" Then  ' Se cadastro de propriedade
                    erro = False

                    If id_estabelecimento = 0 Or id_pessoa = 0 Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "20001"
                        importacaolog.nm_erro = "Erro: Registro 200 sem ter registro 100"
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()
                        erro = True
                    Else

                        ' Codigo do Produtor
                        lpos_ini = 5
                        lpos_fim = InStr(5, linhaarquivo, ";")
                        propriedade.id_pessoa = id_pessoa

                        ' Código da Propriedade
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            propriedade.id_propriedade = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        End If

                        ' Nome da Propriedade  11/08
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            propriedade.nm_propriedade = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        End If

                        ' Data de Implantacao
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            propriedade.dt_inicio = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                            If IsDate(propriedade.dt_inicio) = False Then
                                ' Logar
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                'importacaolog.cd_erro = "20002"
                                importacaolog.cd_erro = ""
                                importacaolog.nm_erro = "Aviso 200: A data de implantacao não é uma data válida."
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                'erro = True
                            End If
                        End If

                        ' Endereço
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            propriedade.ds_endereco = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        End If

                        ' Numero
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            endereco_numero = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                            If IsNumeric(endereco_numero) = True Then
                                propriedade.nr_endereco = endereco_numero
                            Else
                                ' Logar
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                'importacaolog.cd_erro = "20003"
                                importacaolog.cd_erro = ""
                                importacaolog.nm_erro = "Aviso: O número so endereço não é numérico."
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                'erro = True
                            End If
                        End If

                        ' Bairro
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            propriedade.ds_bairro = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        End If

                        ' Municipio
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            end_cidade = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        End If

                        ' Estado
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            end_estado = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                            estado.cd_uf = end_estado
                            id_estado = estado.getEstadosByUF()
                            If id_estado > 0 Then
                                propriedade.id_estado = id_estado

                                ' Busca id_cidade
                                cidade.id_estado = propriedade.id_estado
                                cidade.nm_cidade = end_cidade
                                id_cidade = cidade.getCidadesByNome()
                                If id_cidade > 0 Then
                                    propriedade.id_cidade = id_cidade
                                End If
                            Else
                                ' Logar
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                'importacaolog.cd_erro = "20004"
                                importacaolog.cd_erro = ""
                                importacaolog.nm_erro = "Aviso: UF inválida ou não encontrada."
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                'erro = True
                            End If
                        End If

                        ' CEP
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            end_cep = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                            If Len(end_cep) = 8 Then
                                propriedade.cd_cep = Left(end_cep, 5) & "-" & Right(end_cep, 3)
                            End If
                        End If

                        ' Telefone 1  
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                        ' Telefone 2
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                        ' Telefone 3 (FAX)
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                        ' Email
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                        ' Inscrição estadual
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            propriedade.cd_inscricao_estadual = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        End If

                        ' Inscrição Municiapl
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                        ' CNPJ
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                        ' Estabelecimento
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        propriedade.id_estabelecimento = id_estabelecimento

                        ' Código do Técnico
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                        ' Situação 1 - Ativa ou 2 - Inativa
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            cd_situacao_propriedade = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                            If Trim(cd_situacao_propriedade) = "2" Then  ' Se inativa, não inclui
                                ' Logar
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                'importacaolog.cd_erro = "20005"
                                importacaolog.cd_erro = ""
                                importacaolog.nm_erro = "Aviso: Propriedade INATIVA não importada."
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                erro = True
                            End If
                        End If

                        ' Inscrição INCRA
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                        ' Área Total
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                        If erro = False Then
                            propriedade.id_situacao = 1
                            propriedade.id_modificador = 1
                            propriedade.st_considera_qualidade = "S"
                            propriedade.st_incentivo_fiscal = "N"
                            propriedade.st_transferencia_credito = "N"
                            propriedade.st_incentivo_21 = "N"   ' 16/02/2009 - Rls16 

                            parameters = ParametersEngine.getParametersFromObject(propriedade)
                            'id_propriedade = CType(transacao.ExecuteScalar("ms_insertPropriedadeCoopera", parameters, ExecuteType.Insert), Int32)
                            transacao.Execute("ms_insertPropriedadeCoopera", parameters, ExecuteType.Insert)
                            id_propriedade = propriedade.id_propriedade  ' 11/08
                            liimportada = liimportada + 1

                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "1"
                            importacaolog.cd_erro = ""
                            importacaolog.nm_erro = ""
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog
                        End If

                    End If


                End If

                '=============================================================
                ' Cadastro de Unidade de Producao
                '=============================================================
                If ltipo_registro = "300" Then  ' Se cadastro de unidade de producao

                    If id_estabelecimento = 0 Or id_pessoa = 0 Or id_propriedade = 0 Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "30001"
                        importacaolog.nm_erro = "Erro: Registro 300 sem ter registro 200"
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()
                        erro = True
                    Else

                        ' Codigo do Produtor
                        lpos_ini = 5
                        lpos_fim = InStr(5, linhaarquivo, ";")
                        unidadeproducao.id_pessoa = id_pessoa

                        ' Código da Propriedade
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        unidadeproducao.id_propriedade = id_propriedade

                        ' Código da Unidade de Producao
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            cd_unidade_producao = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                            If IsNumeric(cd_unidade_producao) = True Then
                                unidadeproducao.nm_unid_producao = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                            Else
                                ' Logar
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                importacaolog.cd_erro = "30002"
                                importacaolog.nm_erro = "Erro: Código da Leiteria não numérico"
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                erro = True
                            End If

                        End If

                        ' Nome da Unidade de Producao
                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                        If lpos_fim > 0 Then
                            unidadeproducao.nm_unid_producao = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                        End If

                        If erro = False Then
                            unidadeproducao.id_situacao = 1
                            unidadeproducao.id_modificador = 1
                            parameters = ParametersEngine.getParametersFromObject(unidadeproducao)
                            id_unidade_producao = CType(transacao.ExecuteScalar("ms_insertUnidadesProducao", parameters, ExecuteType.Insert), Int32)
                            liimportada = liimportada + 1

                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "1"
                            importacaolog.cd_erro = ""
                            importacaolog.nm_erro = ""
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog
                        End If


                    End If

                End If

            Loop
            arqTemp.Close()

            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liimportada

            transacao.Commit()
            transacao.Dispose()

            ' Exclui o arquivo do servidor
            Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(Me.nm_arquivo)
            If Arquivo.Exists Then
                Arquivo.Delete()
            End If

            Return id_importacao

        Catch ex As Exception
            arqTemp.Close()   ' 18/05/2010 - chamado 844
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(ex.Message)

        End Try

    End Function
    Function importEMS() As Int32

        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Dim arqTemp As StreamReader  ' Adriana 18/05/2010 - chamado 844
        Try

            Dim estado As New Estado
            Dim cidade As New Cidade
            Dim banco As New Banco
            Dim estabelecimento As New Estabelecimento
            'Dim propriedade As New Propriedade
            'Dim unidadeproducao As New UnidadeProducao


            '=============
            'Dim srStreamReader As StreamReader

            'Dim sFile As String = "C:\temp\dados_ems2.txt"


            'srStreamReader = New StreamReader(sFile, Encoding.UTF7)

            'Do While srStreamReader.Peek() >= 0

            '    Console.WriteLine(srStreamReader.ReadLine())

            'Loop

            'srStreamReader.Close()
            '=============

            Dim linhaarquivo As String
            Dim li As Int16
            Dim erro As Boolean
            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32
            Dim lpos_ini As Int32
            Dim lpos_fim As Int32

            Dim ltipo_registro As String
            Dim endereco_numero As String
            Dim natureza As String
            Dim end_cidade As String
            Dim end_estado As String
            Dim id_estado As Int32
            Dim id_cidade As Int32
            Dim end_cep As String
            Dim cod_banco As String
            Dim id_banco As Int32
            'Dim cd_nacionalidade As String
            'Dim cd_grauinstrucao As String
            Dim cd_estabelecimento As String
            Dim id_estabelecimento As Int32
            Dim id_pessoa As Int32
            Dim grupo_fornecedor As String
            'Dim cd_situacao_propriedade As String
            'Dim cd_unidade_producao As String

            'Dim id_propriedade As Int32
            'Dim id_unidade_producao As Int32

            Dim parameters As List(Of Parameters)

            importacao.st_tipo_importacao = 1
            importacao.dt_inicio_importacao = Now
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo

            id_importacao = importacao.insertImportacao()


            'arqTemp = File.OpenText(Me.nm_arquivo)   ' 09/10
            arqTemp = New StreamReader(Me.nm_arquivo, Encoding.UTF7)  ' 09/10

            li = 0
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                li = li + 1


                ltipo_registro = Mid(linhaarquivo, 1, 3)

                '=============================================================
                ' Cadastro de Pessoas
                '=============================================================
                erro = False

                ' Inicializa Pessoa
                Dim pessoa As New Pessoa
                id_estabelecimento = 0
                id_pessoa = 0

                ' Codigo da Pessoa
                lpos_ini = 1
                lpos_fim = InStr(1, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.cd_pessoa = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                Else
                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "00000"
                    importacaolog.nm_erro = "Erro: Linha sem o código do Fornecedor."
                    importacaolog.id_importacao = id_importacao
                    id_importacao_log = importacaolog.insertImportacaoLog()
                    erro = True
                End If

                ' Verifica se a pessoa existe na base
                Dim dsPessoa As New DataSet
                parameters = ParametersEngine.getParametersFromObject(pessoa)
                transacao.Fill(dsPessoa, "ms_getPessoas", parameters, "ms_pessoa")

                If (dsPessoa.Tables(0).Rows.Count > 0) Then   ' Se existe a pessoa no cadastro
                    ParametersEngine.persistObjectValues(dsPessoa.Tables(0).Rows(0), pessoa)
                    id_pessoa = Convert.ToDecimal(dsPessoa.Tables(0).Rows(0).Item("id_pessoa"))
                Else
                    id_pessoa = 0
                End If
                'If id_pessoa > 0 Then
                '    pessoa.id_pessoa = id_pessoa
                '    parameters = ParametersEngine.getParametersFromObject(pessoa)
                '    transacao.Fill(dsPessoa, "ms_getPessoas", parameters, "ms_pessoa")
                'End If

                ' Nome 
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.nm_pessoa = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Nome abreviado
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'Fran 28/08/2009 i rls 19
                If lpos_fim > 0 Then
                    pessoa.nm_abreviado = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If
                'Fran 28/08/2009 f

                ' Natureza (1 - Pessoa Física e 2 - Pessoa Jurídica)
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    natureza = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    If natureza = "1" Then
                        pessoa.st_categoria = "F"
                    Else
                        If natureza = "2" Then
                            pessoa.st_categoria = "J"
                        Else
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00002"
                            'importacaolog.nm_erro = "Erro: Natureza diferente de 1 e 2."
                            importacaolog.nm_erro = "Erro: Natureza diferente de 1 e 2 para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If
                Else
                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "00001"
                    'importacaolog.nm_erro = "Erro: Natureza não informada."
                    importacaolog.nm_erro = "Erro: Natureza não informada para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                    importacaolog.id_importacao = id_importacao
                    id_importacao_log = importacaolog.insertImportacaoLog()
                    erro = True
                End If

                ' Grupo de Fornecedor
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If id_pessoa = 0 Then   ' Só pode formatar o Grupo se for inclusão de nova pessoa
                    grupo_fornecedor = ""
                    If lpos_fim > 0 Then
                        grupo_fornecedor = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    End If
                    Select Case grupo_fornecedor
                        Case "70"  ' Se produtor Rural
                            pessoa.id_grupo = 1
                        Case "80"  ' Se Cooperativas
                            pessoa.id_grupo = 4
                        Case "81"  ' Se Central de Compras
                            pessoa.id_grupo = 2
                        Case "90"  ' Transportador Leite
                            pessoa.id_grupo = 3
                        Case Else
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00003"
                            'importacaolog.nm_erro = "Erro: Grupo de Fornecedor inválido."
                            importacaolog.nm_erro = "Erro: Grupo de Fornecedor inválido para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                    End Select
                End If


                ' Data de Implantacao
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.dt_inicio = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    If IsDate(pessoa.dt_inicio) = False Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "00004"
                        'importacaolog.nm_erro = "Erro: A data de implantacao não é uma data válida."
                        importacaolog.nm_erro = "Erro: A data de implantacao não é uma data válida para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()
                        erro = True
                    End If
                End If

                ' Endereço
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.ds_endereco = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Numero
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    endereco_numero = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    If IsNumeric(endereco_numero) = True Then
                        pessoa.nr_endereco = endereco_numero
                    Else
                        ' 28/09/2008 - Desabilitei
                        'importacaolog.nr_linha = li
                        'importacaolog.st_importacao = "3"
                        ''importacaolog.cd_erro = "00004"
                        'importacaolog.cd_erro = ""
                        'importacaolog.nm_erro = "Aviso: O número so endereço não é numérico."
                        'importacaolog.id_importacao = id_importacao
                        'id_importacao_log = importacaolog.insertImportacaoLog()
                        ''erro = True
                    End If
                End If

                ' Bairro
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.ds_bairro = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Municipio
                end_cidade = ""
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    end_cidade = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Estado
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    end_estado = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    estado.cd_uf = end_estado
                    'fran 01/03/2010 - estado e cidade vem de cep 
                    'id_estado = estado.getEstadosByUF()
                    'If id_estado > 0 Then
                    '    pessoa.id_estado = id_estado

                    '    ' Busca id_cidade
                    '    cidade.id_estado = pessoa.id_estado
                    '    cidade.nm_cidade = end_cidade
                    '    id_cidade = cidade.getCidadesByNome()
                    '    If id_cidade > 0 Then
                    '        pessoa.id_cidade = id_cidade
                    '    End If
                    'Else
                    '    ' Logar
                    '    importacaolog.nr_linha = li
                    '    importacaolog.st_importacao = "3"
                    '    importacaolog.cd_erro = ""
                    '    importacaolog.nm_erro = "Aviso: UF inválida ou não encontrada."
                    '    importacaolog.id_importacao = id_importacao
                    '    id_importacao_log = importacaolog.insertImportacaoLog()
                    'End If
                    'fran 01/03/2010 - estado e cidade vem de cep f
                End If

                ' CEP
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    end_cep = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    If Len(end_cep) = 8 Then
                        pessoa.cd_cep = Left(end_cep, 5) & "-" & Right(end_cep, 3)
                    End If

                    'fran chamdo cep 01/03/2010 i
                    If Not end_cep.Equals(String.Empty) Then


                        Dim lipos As Integer
                        lipos = InStr(end_cep, "-")
                        If lipos > 0 Then
                            end_cep = String.Concat(Mid(end_cep, 1, lipos - 1), Mid(end_cep, lipos + 1))
                        End If

                        cidade.cd_cep = end_cep
                        Dim dscidadecep As DataSet = cidade.getCidadeByCEP()
                        If dscidadecep.Tables(0).Rows.Count > 0 Then
                            end_cidade = dscidadecep.Tables(0).Rows(0).Item("nm_cidade").ToString
                            end_estado = dscidadecep.Tables(0).Rows(0).Item("cd_uf").ToString
                            id_cidade = Convert.ToInt32(dscidadecep.Tables(0).Rows(0).Item("id_cidade"))
                            pessoa.id_cidade = id_cidade
                            id_estado = Convert.ToInt32(dscidadecep.Tables(0).Rows(0).Item("id_estado"))
                        Else
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00010"
                            'importacaolog.nm_erro = "Erro: CEP não cadastrado."
                            importacaolog.nm_erro = "Erro: CEP " & end_cep & " não encontrado para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Adri 03/03/2010 - chamado 702
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True

                        End If
                    Else
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "00009"
                        'importacaolog.nm_erro = "Erro: CEP não encontrado."
                        importacaolog.nm_erro = "Erro: CEP não informado no arquivo texto."  ' Adri 03/03/2010 - chamado 702
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()
                        erro = True

                    End If
                    'fran chamdo cep 01/03/2010 f
                Else
                    'fran chamdo cep 01/03/2010 i
                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "00009"
                    'importacaolog.nm_erro = "Erro: CEP não encontrado."
                    importacaolog.nm_erro = "Erro: CEP não informado no arquivo texto."  ' Adri 03/03/2010 - chamado 702
                    importacaolog.id_importacao = id_importacao
                    id_importacao_log = importacaolog.insertImportacaoLog()
                    erro = True
                    'fran chamdo cep 01/03/2010 f
                End If

                ' Caixa Postal
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                ' Telefone 1  
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.ds_telefone_1 = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    'If Trim(pessoa.ds_telefone_1) <> "" Then
                    '    If Left(pessoa.ds_telefone_1, 1) <> "(" And Mid(pessoa.ds_telefone_1, 5, 1) <> ")" Then
                    '        ' Logar
                    '        importacaolog.nr_linha = li
                    '        importacaolog.st_importacao = "2"
                    '        importacaolog.cd_erro = ""
                    '        importacaolog.nm_erro = "Aviso: Telefone 1 no formato inválido."
                    '        importacaolog.id_importacao = id_importacao
                    '        id_importacao_log = importacaolog.insertImportacaoLog()
                    '    Else
                    '        pessoa.ds_telefone_1 = "(" & Mid(pessoa.ds_telefone_1, 3, 2) & ")" & Mid(pessoa.ds_telefone_1, 6, Len(pessoa.ds_telefone_1) - 5)
                    '    End If
                    'End If
                End If

                ' Telefone 2
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.ds_telefone_2 = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    'If Trim(pessoa.ds_telefone_2) <> "" Then
                    '    If Left(pessoa.ds_telefone_2, 1) <> "(" And Mid(pessoa.ds_telefone_2, 5, 1) <> ")" Then
                    '        ' Logar
                    '        importacaolog.nr_linha = li
                    '        importacaolog.st_importacao = "2"
                    '        'importacaolog.cd_erro = "00009"
                    '        importacaolog.cd_erro = ""
                    '        importacaolog.nm_erro = "Aviso: Telefone 2 no formato inválido."
                    '        importacaolog.id_importacao = id_importacao
                    '        id_importacao_log = importacaolog.insertImportacaoLog()
                    '        'erro = True
                    '    Else
                    '        pessoa.ds_telefone_2 = "(" & Mid(pessoa.ds_telefone_2, 3, 2) & ")" & Mid(pessoa.ds_telefone_2, 6, Len(pessoa.ds_telefone_2) - 5)
                    '    End If
                    'End If
                End If

                ' Telefone 3
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.ds_telefone_3 = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    'If Trim(pessoa.ds_telefone_3) <> "" Then
                    '    If Left(pessoa.ds_telefone_3, 1) <> "(" And Mid(pessoa.ds_telefone_3, 5, 1) <> ")" Then
                    '        ' Logar
                    '        importacaolog.nr_linha = li
                    '        importacaolog.st_importacao = "2"
                    '        'importacaolog.cd_erro = "00009"
                    '        importacaolog.cd_erro = ""
                    '        importacaolog.nm_erro = "Aviso: Telefone 3 no formato inválido."
                    '        importacaolog.id_importacao = id_importacao
                    '        id_importacao_log = importacaolog.insertImportacaoLog()
                    '        'erro = True
                    '    Else
                    '        pessoa.ds_telefone_3 = "(" & Mid(pessoa.ds_telefone_3, 3, 2) & ")" & Mid(pessoa.ds_telefone_3, 6, Len(pessoa.ds_telefone_3) - 5)
                    '    End If
                    'End If
                End If

                ' Email
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.ds_email = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Portador
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                ' Codigo do Banco
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    cod_banco = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    If IsNumeric(cod_banco) = False Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "3"
                        importacaolog.cd_erro = ""
                        'importacaolog.nm_erro = "Aviso: Codigo do Banco não é válido."
                        importacaolog.nm_erro = "Aviso: Codigo do Banco não é válido para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()
                    Else
                        banco.cd_banco = cod_banco
                        id_banco = banco.getBancosByCodigo()
                        If id_banco > 0 Then
                            pessoa.id_banco = id_banco
                        Else
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "3"   ' Aviso
                            importacaolog.cd_erro = ""
                            'importacaolog.nm_erro = "Aviso: Codigo do Banco não encontrado."
                            importacaolog.nm_erro = "Aviso: Código do Banco não encontrado para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                        End If

                    End If

                End If

                ' Agencia
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.cd_agencia = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Conta Corrente
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.cd_conta = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Tipo da Conta
                pessoa.id_tipo_conta = 1  '  1 - Conta Corrente

                ' Condicao de pagamento
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                ' Inscrição estadual
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.cd_inscricao_estadual = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Inscrição Municiapl
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.cd_inscricao_municipal = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' CNPJ
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.cd_cnpj = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    If Len(pessoa.cd_cnpj) = 14 Then
                        'pessoa.cd_cnpj = Left(pessoa.cd_cnpj, 2) & "." & Mid(pessoa.cd_cnpj, 3, 3) & "." & Mid(pessoa.cd_cnpj, 6, 3) & "\" & Mid(pessoa.cd_cnpj, 9, 4) & "-" & Mid(pessoa.cd_cnpj, 13, 2)
                        pessoa.cd_cnpj = Left(pessoa.cd_cnpj, 2) & "." & Mid(pessoa.cd_cnpj, 3, 3) & "." & Mid(pessoa.cd_cnpj, 6, 3) & "/" & Mid(pessoa.cd_cnpj, 9, 4) & "-" & Mid(pessoa.cd_cnpj, 13, 2)
                    End If
                End If

                ' CPF
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.cd_cpf = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    If Trim(pessoa.cd_cpf) <> "" And Trim(pessoa.cd_cpf) <> "?" Then
                        pessoa.cd_cpf = Left(pessoa.cd_cpf, 3) & "." & Mid(pessoa.cd_cpf, 4, 3) & "." & Mid(pessoa.cd_cpf, 7, 3) & "-" & Mid(pessoa.cd_cpf, 10, 2)
                    End If
                End If


                '' Estabelecimento
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'If lpos_fim > 0 Then
                '    cd_estabelecimento = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                '    estabelecimento.cd_estabelecimento = cd_estabelecimento
                '    id_estabelecimento = estabelecimento.getEstabelecimentoByCodigo()
                '    If id_estabelecimento > 0 Then
                '        pessoa.id_estabelecimento = id_estabelecimento
                '    Else
                '        ' Logar
                '        importacaolog.nr_linha = li
                '        importacaolog.st_importacao = "2"
                '        importacaolog.cd_erro = "00008"
                '        importacaolog.nm_erro = "Erro: Codigo do Estabelecimento não encontrado." & " Código = " & cd_estabelecimento
                '        importacaolog.id_importacao = id_importacao
                '        id_importacao_log = importacaolog.insertImportacaoLog()
                '        erro = True
                '    End If

                'End If

                pessoa.st_empresa_nacional = "S"


                If erro = False Then
                    pessoa.id_modificador = 1

                    If id_pessoa = 0 Then   ' Se a pessoa não existe no cadastro

                        ' 29/09/2008 - Somente deixar default estes campos se nova Pessoa - i 
                        pessoa.id_pessoa_situacao = 1  ' 1 - Aprovado
                        pessoa.id_situacao = 1
                        pessoa.st_emite_nota_fiscal = "N"   ' 29/09/2008
                        ' 29/09/2008 - Somente deixar default estes campos se nova Pessoa - f 

                        ' EMS não tem Estabelecimento, assumir inclusão dos novos no codigo="999"
                        cd_estabelecimento = "999"
                        estabelecimento.cd_estabelecimento = cd_estabelecimento
                        id_estabelecimento = estabelecimento.getEstabelecimentoByCodigo()
                        If id_estabelecimento > 0 Then
                            pessoa.id_estabelecimento = id_estabelecimento
                        Else
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00008"
                            'importacaolog.nm_erro = "Erro: Codigo do Estabelecimento não encontrado." & " Código = " & cd_estabelecimento
                            importacaolog.nm_erro = "Erro: Codigo do Estabelecimento não encontrado para o Código Pessoa=" & pessoa.cd_pessoa & "." & " Código = " & cd_estabelecimento  ' Fran 15/03/2010 - chamado 702
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If

                        parameters = ParametersEngine.getParametersFromObject(pessoa)
                        id_pessoa = CType(transacao.ExecuteScalar("ms_insertPessoas", parameters, ExecuteType.Insert), Int32)
                    Else
                        pessoa.id_pessoa = id_pessoa

                        ' 28/09/2008 - Formata datas que vem do Framework com d/m/yyyy - i
                        If Not (pessoa.dt_nascimento Is Nothing) Then
                            pessoa.dt_nascimento = DateTime.Parse(pessoa.dt_nascimento).ToString("dd/MM/yyyy HH:mm")
                        End If
                        If Not (pessoa.dt_inicio Is Nothing) Then
                            pessoa.dt_inicio = DateTime.Parse(pessoa.dt_inicio).ToString("dd/MM/yyyy HH:mm")
                        End If
                        If Not (pessoa.dt_desligamento Is Nothing) Then
                            pessoa.dt_desligamento = DateTime.Parse(pessoa.dt_desligamento).ToString("dd/MM/yyyy HH:mm")
                        End If
                        If Not (pessoa.dt_reativacao Is Nothing) Then
                            pessoa.dt_reativacao = DateTime.Parse(pessoa.dt_reativacao).ToString("dd/MM/yyyy HH:mm")
                        End If
                        If Not (pessoa.dt_expiracao_dqse Is Nothing) Then
                            pessoa.dt_expiracao_dqse = DateTime.Parse(pessoa.dt_expiracao_dqse).ToString("dd/MM/yyyy HH:mm")
                        End If
                        If Not (pessoa.dt_modificacao Is Nothing) Then
                            pessoa.dt_modificacao = DateTime.Parse(pessoa.dt_modificacao).ToString("dd/MM/yyyy HH:mm")
                        End If
                        ' Adriana 03/08/2010 - chamado 915 - i
                        If Not (pessoa.dt_adesao_acordo_insumos Is Nothing) Then
                            pessoa.dt_adesao_acordo_insumos = DateTime.Parse(pessoa.dt_adesao_acordo_insumos).ToString("dd/MM/yyyy HH:mm")
                        End If
                        ' Adriana 03/08/2010 - chamado 915 - f
                        ' 28/09/2008 - Formata datas que vem do Framework com d/m/yyyy - f

                        parameters = ParametersEngine.getParametersFromObject(pessoa)
                        transacao.Execute("ms_updatePessoas", parameters, ExecuteType.Update)
                    End If

                    liimportada = liimportada + 1

                    ' 28/09/2008 (muito volume)
                    'importacaolog.nr_linha = li
                    'importacaolog.st_importacao = "1"
                    'importacaolog.cd_erro = ""
                    'importacaolog.nm_erro = ""
                    'importacaolog.id_importacao = id_importacao
                    'id_importacao_log = importacaolog.insertImportacaoLog
                End If


            Loop
            arqTemp.Close()

            importacaolog.nr_linha = li
            importacaolog.st_importacao = "1"
            importacaolog.cd_erro = ""
            importacaolog.nm_erro = ""
            importacaolog.id_importacao = id_importacao
            id_importacao_log = importacaolog.insertImportacaoLog

            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liimportada

            transacao.Commit()
            transacao.Dispose()     ' 24/10/2008

            ' Exclui o arquivo do servidor
            Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(Me.nm_arquivo)
            If Arquivo.Exists Then
                Arquivo.Delete()
            End If

            Return id_importacao


        Catch ex As Exception
            arqTemp.Close()   ' 18/05/2010 - chamado 844
            transacao.RollBack()
            transacao.Dispose()  ' 24/10/2008
            Throw New Exception(ex.Message)

        End Try

    End Function
    ' 03/02/2012 - Projeto Themis - i
    Function importSAP() As Int32

        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Dim arqTemp As StreamReader
        Try

            Dim estado As New Estado
            Dim cidade As New Cidade
            Dim banco As New Banco
            Dim estabelecimento As New Estabelecimento
            Dim propriedade As New Propriedade      '  27/02/2012 - Projeto Themis

            Dim linhaarquivo As String
            Dim li As Int16
            Dim erro As Boolean
            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32
            Dim lpos_ini As Int32
            Dim lpos_fim As Int32

            Dim ltipo_registro As String
            Dim endereco_numero As String
            Dim natureza As String
            Dim end_cidade As String
            Dim end_estado As String
            Dim id_estado As Int32
            Dim id_cidade As Int32
            Dim end_cep As String
            Dim cod_banco As String
            Dim id_banco As Int32
            Dim cd_estabelecimento As String
            Dim id_estabelecimento As Int32
            Dim id_pessoa As Int32
            Dim grupo_fornecedor As String
            '====================================================================
            ' Themis  - dados lidos em variáveis locais  - i
            '====================================================================
            Dim lnm_pessoa As String
            Dim lnm_abreviado As String
            Dim lst_categoria As String
            Dim ldt_inicio As String
            Dim lds_endereco As String
            Dim lnr_endereco As String
            Dim lds_bairro As String
            Dim lcd_cep As String
            Dim lid_cidade As String
            Dim lds_telefone As String
            Dim lds_telefone_2 As String
            Dim lds_telefone_3 As String
            Dim lds_email As String
            Dim lcd_inscricao_estadual As String
            Dim lcd_inscricao_municipal As String
            Dim lcd_codigo_SAP As String
            Dim lcd_cnpj As String
            Dim lcd_cpf As String
            Dim lst_empresa_nacional As String
            Dim lid_grupo As Int32
            Dim lid_cluster As Int32 'fran fase 3
            '========================================================
            ' Themis  - Salva os dados lidos em variáveis locais - f
            '========================================================
            
            Dim parameters As List(Of Parameters)

            importacao.st_tipo_importacao = 1
            importacao.dt_inicio_importacao = Now
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo

            id_importacao = importacao.insertImportacao()


            arqTemp = New StreamReader(Me.nm_arquivo, Encoding.UTF7)

            li = 0
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                li = li + 1


                ltipo_registro = Mid(linhaarquivo, 1, 3)

                '=============================================================
                ' Cadastro de Pessoas
                '=============================================================
                erro = False

                ' Inicializa Pessoa
                Dim pessoa As New Pessoa
                id_estabelecimento = 0
                id_pessoa = 0

                ' Codigo da Pessoa (no SAP)
                lpos_ini = 1
                lpos_fim = InStr(1, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    'pessoa.cd_pessoa = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    pessoa.cd_codigo_SAP = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                Else
                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "4"
                    importacaolog.cd_erro = "00011"
                    importacaolog.nm_erro = "Erro: Linha sem o código do Fornecedor."
                    importacaolog.id_importacao = id_importacao
                    id_importacao_log = importacaolog.insertImportacaoLog()
                    erro = True
                End If


                ' Nome 
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.nm_pessoa = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Nome abreviado
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'Fran 28/08/2009 i rls 19
                If lpos_fim > 0 Then
                    pessoa.nm_abreviado = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If
                'Fran 28/08/2009 f

                ' Natureza (1 - Pessoa Física e 2 - Pessoa Jurídica)
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    natureza = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    If natureza = "1" Then
                        pessoa.st_categoria = "F"
                    Else
                        If natureza = "2" Then
                            pessoa.st_categoria = "J"
                        Else
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "4"  ' Indica Importação Fornecedores para o SAP
                            importacaolog.cd_erro = "00002"
                            'importacaolog.nm_erro = "Erro: Natureza diferente de 1 e 2."
                            importacaolog.nm_erro = "Erro: Natureza diferente de 1 e 2 para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If
                Else
                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "4"
                    importacaolog.cd_erro = "00001"
                    'importacaolog.nm_erro = "Erro: Natureza não informada."
                    importacaolog.nm_erro = "Erro: Natureza não informada para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                    importacaolog.id_importacao = id_importacao
                    id_importacao_log = importacaolog.insertImportacaoLog()
                    erro = True
                End If

                ' Grupo de Fornecedor
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                ' 27/02/2012 - Projeto Themis (o campo id_pessoa agora é obtido depois de ler CPF e CNPJ )- i
                grupo_fornecedor = ""
                If lpos_fim > 0 Then
                    grupo_fornecedor = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If
                If grupo_fornecedor = "" Then
                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "4"
                    importacaolog.cd_erro = "00011"
                    importacaolog.nm_erro = "Erro: Grupo de Fornecedor não informado para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                    importacaolog.id_importacao = id_importacao
                    id_importacao_log = importacaolog.insertImportacaoLog()
                    erro = True
                End If

                'If id_pessoa = 0 Then   ' Só pode formatar o Grupo se for inclusão de nova pessoa
                '    grupo_fornecedor = ""
                '    If lpos_fim > 0 Then
                '        grupo_fornecedor = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                '    End If
                '    Select Case grupo_fornecedor
                '        Case "70"  ' Se produtor Rural
                '            pessoa.id_grupo = 1
                '        Case "80"  ' Se Cooperativas
                '            pessoa.id_grupo = 4
                '        Case "81"  ' Se Central de Compras
                '            pessoa.id_grupo = 2
                '        Case "90"  ' Transportador Leite
                '            pessoa.id_grupo = 3
                '        Case Else
                '            ' Logar
                '            importacaolog.nr_linha = li
                '            importacaolog.st_importacao = "4"
                '            importacaolog.cd_erro = "00003"
                '            importacaolog.nm_erro = "Erro: Grupo de Fornecedor inválido para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                '            importacaolog.id_importacao = id_importacao
                '            id_importacao_log = importacaolog.insertImportacaoLog()
                '            erro = True
                '    End Select
                'End If
                ' 27/02/2012 - Projeto Themis - i


                ' Data de Implantacao
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.dt_inicio = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    If IsDate(pessoa.dt_inicio) = False Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "4"
                        importacaolog.cd_erro = "00004"
                        'importacaolog.nm_erro = "Erro: A data de implantacao não é uma data válida."
                        importacaolog.nm_erro = "Erro: A data de implantacao não é uma data válida para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()
                        erro = True
                    End If
                End If

                ' Endereço
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.ds_endereco = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Numero
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    endereco_numero = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    If IsNumeric(endereco_numero) = True Then
                        pessoa.nr_endereco = endereco_numero
                    Else

                    End If
                End If

                ' Bairro
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.ds_bairro = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Municipio
                end_cidade = ""
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    end_cidade = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Estado
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    end_estado = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    estado.cd_uf = end_estado
                End If

                ' CEP
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    end_cep = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)).Trim

                    If Len(end_cep) = 8 Then
                        pessoa.cd_cep = Left(end_cep, 5) & "-" & Right(end_cep, 3)
                    End If
                    'Fran 12/12/2013 i Se o cep já vem com hifen tambem deve ser atribuido a variavel da pessoa, caso contrario grava vazio no cadastro de Pessoa
                    If Len(end_cep) = 9 Then
                        pessoa.cd_cep = end_cep
                    End If
                    'Fran 12/12/2013 i 
                    If Not end_cep.Equals(String.Empty) Then


                        Dim lipos As Integer
                        lipos = InStr(end_cep, "-")
                        If lipos > 0 Then
                            end_cep = String.Concat(Mid(end_cep, 1, lipos - 1), Mid(end_cep, lipos + 1))
                        End If

                        cidade.cd_cep = end_cep
                        Dim dscidadecep As DataSet = cidade.getCidadeByCEP()
                        If dscidadecep.Tables(0).Rows.Count > 0 Then
                            end_cidade = dscidadecep.Tables(0).Rows(0).Item("nm_cidade").ToString
                            end_estado = dscidadecep.Tables(0).Rows(0).Item("cd_uf").ToString
                            id_cidade = Convert.ToInt32(dscidadecep.Tables(0).Rows(0).Item("id_cidade"))
                            pessoa.id_cidade = id_cidade
                            id_estado = Convert.ToInt32(dscidadecep.Tables(0).Rows(0).Item("id_estado"))
                        Else
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "4"
                            importacaolog.cd_erro = "00010"
                            'importacaolog.nm_erro = "Erro: CEP não cadastrado."
                            importacaolog.nm_erro = "Erro: CEP " & end_cep & " não encontrado para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Adri 03/03/2010 - chamado 702
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True

                        End If
                    Else
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "4"
                        importacaolog.cd_erro = "00009"
                        importacaolog.nm_erro = "Erro: CEP não informado no arquivo texto."  ' Adri 03/03/2010 - chamado 702
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()
                        erro = True

                    End If
                Else
                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "4"
                    importacaolog.cd_erro = "00009"
                    'importacaolog.nm_erro = "Erro: CEP não encontrado."
                    importacaolog.nm_erro = "Erro: CEP não informado no arquivo texto."  ' Adri 03/03/2010 - chamado 702
                    importacaolog.id_importacao = id_importacao
                    id_importacao_log = importacaolog.insertImportacaoLog()
                    erro = True
                    'fran chamdo cep 01/03/2010 f
                End If

                ' 09/02/2012 - Projeto Themis - Inibir pois não vem no arquivo - i
                ' Caixa Postal
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                ' 09/02/2012 - Projeto Themis - Inibir - f

                ' Telefone 1  
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.ds_telefone_1 = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Telefone 2
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.ds_telefone_2 = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Telefone 3
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.ds_telefone_3 = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' Email
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.ds_email = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' 09/02/2012 - Projeto Themis - Inibir pois não vem no arquivo - i
                '' Portador
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                '' Codigo do Banco
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'If lpos_fim > 0 Then
                '    cod_banco = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                '    If IsNumeric(cod_banco) = False Then
                '        ' Logar
                '        importacaolog.nr_linha = li
                '        importacaolog.st_importacao = "3"
                '        importacaolog.cd_erro = ""
                '        'importacaolog.nm_erro = "Aviso: Codigo do Banco não é válido."
                '        importacaolog.nm_erro = "Aviso: Codigo do Banco não é válido para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                '        importacaolog.id_importacao = id_importacao
                '        id_importacao_log = importacaolog.insertImportacaoLog()
                '    Else
                '        banco.cd_banco = cod_banco
                '        id_banco = banco.getBancosByCodigo()
                '        If id_banco > 0 Then
                '            pessoa.id_banco = id_banco
                '        Else
                '            ' Logar
                '            importacaolog.nr_linha = li
                '            importacaolog.st_importacao = "3"   ' Aviso
                '            importacaolog.cd_erro = ""
                '            'importacaolog.nm_erro = "Aviso: Codigo do Banco não encontrado."
                '            importacaolog.nm_erro = "Aviso: Código do Banco não encontrado para o Código Pessoa=" & pessoa.cd_pessoa & "."  ' Fran 15/03/2010 - chamado 702
                '            importacaolog.id_importacao = id_importacao
                '            id_importacao_log = importacaolog.insertImportacaoLog()
                '        End If

                '    End If

                'End If

                '' Agencia
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'If lpos_fim > 0 Then
                '    pessoa.cd_agencia = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                'End If

                '' Conta Corrente
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                'If lpos_fim > 0 Then
                '    pessoa.cd_conta = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                'End If

                '' Tipo da Conta
                'pessoa.id_tipo_conta = 1  '  1 - Conta Corrente

                '' Condicao de pagamento
                'lpos_ini = lpos_fim + 1
                'lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                ' 09/02/2012 - Projeto Themis - Inibir - f

                ' Inscrição estadual
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                lcd_inscricao_estadual = ""
                If lpos_fim > 0 Then
                    pessoa.cd_inscricao_estadual = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If
                ' 22/03/2012 - Projeto Themis (Desabiltado consistência abaixo pois a nova definição da Danone será a busca por Código SAP, já que alguns produtores não possuem IE) - i
                'If grupo_fornecedor = 70 Then  ' Se for grupo=70 Produtor Rural
                '    If Trim(pessoa.cd_inscricao_estadual) = "" Or Trim(pessoa.cd_inscricao_estadual) = "ISENTO" Then  ' Se não recebeu Inscrição Estadual, gera erro pois a IE é chave de busca para encontrar a Propriedade
                '        ' Logar
                '        importacaolog.nr_linha = li
                '        importacaolog.st_importacao = "4"
                '        importacaolog.cd_erro = "00012"
                '        importacaolog.nm_erro = "Erro: Linha sem a Inscrição Estadual do Fornecedor."
                '        importacaolog.id_importacao = id_importacao
                '        id_importacao_log = importacaolog.insertImportacaoLog()
                '        erro = True
                '    End If
                'End If
                ' 22/03/2012 - Projeto Themis (Desabiltado consistência abaixo pois a nova definição da Danone será a busca por Código SAP, já que alguns produtores não possuem IE) - f

                ' Inscrição Municipal
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                If lpos_fim > 0 Then
                    pessoa.cd_inscricao_municipal = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                End If

                ' CNPJ
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                pessoa.cd_cnpj = ""
                If lpos_fim > 0 Then
                    pessoa.cd_cnpj = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    If Len(pessoa.cd_cnpj) = 14 Then
                        'pessoa.cd_cnpj = Left(pessoa.cd_cnpj, 2) & "." & Mid(pessoa.cd_cnpj, 3, 3) & "." & Mid(pessoa.cd_cnpj, 6, 3) & "\" & Mid(pessoa.cd_cnpj, 9, 4) & "-" & Mid(pessoa.cd_cnpj, 13, 2)
                        pessoa.cd_cnpj = Left(pessoa.cd_cnpj, 2) & "." & Mid(pessoa.cd_cnpj, 3, 3) & "." & Mid(pessoa.cd_cnpj, 6, 3) & "/" & Mid(pessoa.cd_cnpj, 9, 4) & "-" & Mid(pessoa.cd_cnpj, 13, 2)
                    End If
                End If

                ' CPF
                lpos_ini = lpos_fim + 1
                lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                pessoa.cd_cpf = ""
                If lpos_fim > 0 Then
                    pessoa.cd_cpf = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))
                    If Trim(pessoa.cd_cpf) <> "" And Trim(pessoa.cd_cpf) <> "?" And Len(pessoa.cd_cpf) = 11 Then
                        pessoa.cd_cpf = Left(pessoa.cd_cpf, 3) & "." & Mid(pessoa.cd_cpf, 4, 3) & "." & Mid(pessoa.cd_cpf, 7, 3) & "-" & Mid(pessoa.cd_cpf, 10, 2)
                    End If
                End If

                pessoa.st_empresa_nacional = "S"

                '=============================================================================
                ' Themis  - Salva os dados lidos em variáveis locais antes de ler a pessoa - i
                '=============================================================================
                lnm_pessoa = pessoa.nm_pessoa
                lnm_abreviado = pessoa.nm_abreviado
                lst_categoria = pessoa.st_categoria
                ldt_inicio = pessoa.dt_inicio
                lds_endereco = pessoa.ds_endereco
                lnr_endereco = pessoa.nr_endereco
                lds_bairro = pessoa.ds_bairro
                lcd_cep = pessoa.cd_cep
                lid_cidade = pessoa.id_cidade
                lds_telefone = pessoa.ds_telefone_1
                lds_telefone_2 = pessoa.ds_telefone_2
                lds_telefone_3 = pessoa.ds_telefone_3
                lds_email = pessoa.ds_email
                lcd_inscricao_estadual = pessoa.cd_inscricao_estadual
                lcd_inscricao_municipal = pessoa.cd_inscricao_municipal
                lcd_codigo_SAP = pessoa.cd_codigo_SAP
                lcd_cnpj = pessoa.cd_cnpj
                lcd_cpf = pessoa.cd_cpf
                lst_empresa_nacional = pessoa.st_empresa_nacional
                lid_cluster = 0 'assume que nao tem cluster fran fase 3

                '=============================================================================
                ' Themis  - Salva os dados lidos em variáveis locais antes de ler a pessoa - i
                '=============================================================================

                ' 09/02/2012 - Projeto Themis - i
                If Trim(pessoa.cd_cnpj) <> "" Or Trim(pessoa.cd_cpf) <> "" Then   ' Se CPF ou CNPJ estão no arquivo

                    ' 09/02/2012 - Projeto Themis - Buscar pessoa pelo CPF ou CNPJ - i
                    ' Verifica se a pessoa existe na base pelo CNPJ ou CPF (vindo do SAP)
                    parameters = ParametersEngine.getParametersFromObject(pessoa)
                    Dim dsPessoa As New DataSet                 '  10/02/2012 - Projeto Themis
                    If pessoa.cd_cpf.ToString <> "" Then
                        transacao.Fill(dsPessoa, "ms_getPessoaByCPF", parameters, "ms_pessoa")
                    Else
                        transacao.Fill(dsPessoa, "ms_getPessoaByCNPJ", parameters, "ms_pessoa")
                    End If

                    If (dsPessoa.Tables(0).Rows.Count > 0) Then   ' Se existe a pessoa no cadastro
                        ParametersEngine.persistObjectValues(dsPessoa.Tables(0).Rows(0), pessoa)
                        id_pessoa = Convert.ToDecimal(dsPessoa.Tables(0).Rows(0).Item("id_pessoa"))
                        'fran fase 3 i - se ja existe a pessoa pega o cluster ja cadastrado
                        If IsDBNull(dsPessoa.Tables(0).Rows(0).Item("id_cluster")) Then
                            lid_cluster = 0
                        Else
                            lid_cluster = dsPessoa.Tables(0).Rows(0).Item("id_cluster")
                        End If
                        'fran fase 3 f

                    Else
                        id_pessoa = 0
                    End If
                    If id_pessoa = 0 Then   ' Só pode formatar o Grupo se for inclusão de nova pessoa
                        Select Case grupo_fornecedor
                            Case "70"  ' Se produtor Rural
                                pessoa.id_grupo = 1
                                lid_cluster = 4 'fran fase 3 se a pessoa nao existe e é grupo de produtores, assume 4 (comercial) para o produtor
                            Case "80"  ' Se Cooperativas
                                pessoa.id_grupo = 4
                            Case "81"  ' Se Central de Compras
                                pessoa.id_grupo = 2
                            Case "90"  ' Transportador Leite
                                pessoa.id_grupo = 3
                            Case Else
                                ' Logar
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "4"
                                importacaolog.cd_erro = "00003"
                                importacaolog.nm_erro = "Erro: Grupo de Fornecedor inválido para o Código Pessoa=" & pessoa.cd_codigo_SAP & "."
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                erro = True
                        End Select
                    End If
                    lid_grupo = pessoa.id_grupo
                    ' 09/02/2012 - Projeto Themis - Buscar pessoa pelo CPF ou CNPJ - f
                Else
                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "4"
                    importacaolog.cd_erro = "00000"
                    importacaolog.nm_erro = "Erro: Linha sem o código do CPF ou CNPJ do Fornecedor."
                    importacaolog.id_importacao = id_importacao
                    id_importacao_log = importacaolog.insertImportacaoLog()
                    erro = True

                End If

                '=============================================================================
                ' Themis  - Restaura os dados salvos em variáveis locais na classe pessoa - i
                '=============================================================================
                pessoa.nm_pessoa = lnm_pessoa
                'fran - somente atualiza nome abreviado do arquivo na 1a vez (insert de pessoa) i 2020
                If erro = False AndAlso id_pessoa = 0 Then
                    pessoa.nm_abreviado = lnm_abreviado
                End If
                ' fran f
                pessoa.st_categoria = lst_categoria
                pessoa.dt_inicio = ldt_inicio
                pessoa.ds_endereco = lds_endereco
                pessoa.nr_endereco = lnr_endereco
                pessoa.ds_bairro = lds_bairro
                pessoa.cd_cep = lcd_cep
                pessoa.id_cidade = lid_cidade
                pessoa.ds_telefone_1 = lds_telefone
                pessoa.ds_telefone_2 = lds_telefone_2
                pessoa.ds_telefone_3 = lds_telefone_3
                pessoa.ds_email = lds_email
                pessoa.cd_inscricao_estadual = lcd_inscricao_estadual
                pessoa.cd_inscricao_municipal = lcd_inscricao_municipal
                pessoa.cd_codigo_SAP = lcd_codigo_SAP
                pessoa.cd_cnpj = lcd_cnpj
                pessoa.cd_cpf = lcd_cpf
                pessoa.st_empresa_nacional = lst_empresa_nacional
                pessoa.id_grupo = lid_grupo
                pessoa.id_cluster = lid_cluster ' fran fase 3
                '=============================================================================
                ' Themis  - Restaura os dados salvos em variáveis locais na classe pessoa - i
                '=============================================================================



                If erro = False Then
                    pessoa.id_modificador = 1

                    If id_pessoa = 0 Then   ' Se a pessoa não existe no cadastro

                        ' Somente deixar default estes campos se nova Pessoa - i 
                        pessoa.id_pessoa_situacao = 1  ' 1 - Aprovado
                        pessoa.id_situacao = 1
                        pessoa.st_emite_nota_fiscal = "N"   ' 29/09/2008
                        ' Somente deixar default estes campos se nova Pessoa - f 

                        ' SAP não tem Estabelecimento, assumir inclusão dos novos no codigo="999"
                        cd_estabelecimento = "999"
                        estabelecimento.cd_estabelecimento = cd_estabelecimento
                        id_estabelecimento = estabelecimento.getEstabelecimentoByCodigo()
                        If id_estabelecimento > 0 Then
                            pessoa.id_estabelecimento = id_estabelecimento
                        Else
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "4"
                            importacaolog.cd_erro = "00008"
                            importacaolog.nm_erro = "Erro: Codigo do Estabelecimento 999 não encontrado para o Código Pessoa=" & pessoa.cd_pessoa & "." & " Código = " & cd_estabelecimento
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If

                        ' 10/02/2012 - Projeto Themis - Assumir o max(cd_pessoa) + 1  para o código de pessoa do MilkSystem - i
                        Dim dsMaxPessoa As New DataSet              '  10/02/2012 - Projeto Themis
                        parameters = ParametersEngine.getParametersFromObject(pessoa)
                        transacao.Fill(dsMaxPessoa, "ms_getPessoaProximoCodigo", parameters, "ms_pessoa")
                        pessoa.cd_pessoa = dsMaxPessoa.Tables(0).Rows(0).Item("cd_pessoa_proximo").ToString
                        ' 10/02/2012 - Projeto Themis - Assumir o max(cd_pessoa) + 1  para o código de pessoa do MilkSystem - f

                        ' Formata data recebida com yyyy
                        If Not (pessoa.dt_inicio Is Nothing) Then
                            pessoa.dt_inicio = DateTime.Parse(pessoa.dt_inicio).ToString("dd/MM/yyyy HH:mm")
                        End If

                        parameters = ParametersEngine.getParametersFromObject(pessoa)
                        id_pessoa = CType(transacao.ExecuteScalar("ms_insertPessoas", parameters, ExecuteType.Insert), Int32)
                    Else
                        pessoa.id_pessoa = id_pessoa


                        ' Formata datas que vem do Framework com d/m/yyyy - i
                        If Not (pessoa.dt_nascimento Is Nothing) Then
                            pessoa.dt_nascimento = DateTime.Parse(pessoa.dt_nascimento).ToString("dd/MM/yyyy HH:mm")
                        End If
                        If Not (pessoa.dt_inicio Is Nothing) Then
                            pessoa.dt_inicio = DateTime.Parse(pessoa.dt_inicio).ToString("dd/MM/yyyy HH:mm")
                        End If
                        If Not (pessoa.dt_desligamento Is Nothing) Then
                            pessoa.dt_desligamento = DateTime.Parse(pessoa.dt_desligamento).ToString("dd/MM/yyyy HH:mm")
                        End If
                        If Not (pessoa.dt_reativacao Is Nothing) Then
                            pessoa.dt_reativacao = DateTime.Parse(pessoa.dt_reativacao).ToString("dd/MM/yyyy HH:mm")
                        End If
                        If Not (pessoa.dt_expiracao_dqse Is Nothing) Then
                            pessoa.dt_expiracao_dqse = DateTime.Parse(pessoa.dt_expiracao_dqse).ToString("dd/MM/yyyy HH:mm")
                        End If
                        pessoa.dt_modificacao = Now()  ' 02/03/2012 - Themis
                        If Not (pessoa.dt_modificacao Is Nothing) Then
                            pessoa.dt_modificacao = DateTime.Parse(pessoa.dt_modificacao).ToString("dd/MM/yyyy HH:mm")
                        End If
                        If Not (pessoa.dt_adesao_acordo_insumos Is Nothing) Then
                            pessoa.dt_adesao_acordo_insumos = DateTime.Parse(pessoa.dt_adesao_acordo_insumos).ToString("dd/MM/yyyy HH:mm")
                        End If
                        ' Formata datas que vem do Framework com d/m/yyyy - f

                        parameters = ParametersEngine.getParametersFromObject(pessoa)
                        transacao.Execute("ms_updatePessoas", parameters, ExecuteType.Update)
                    End If

                    ' 27/02/2012  - Projeto Themis - i
                    If pessoa.id_grupo = 1 Then  ' Se Produtor Rural, tratar a entidade Propriedade
                        'Fran 19/06/2012 i Projeto Themis
                        propriedade.cd_codigo_SAP = pessoa.cd_codigo_SAP
                        'Fran 19/06/2012 i Projeto Themis
                        propriedade.cd_inscricao_estadual = pessoa.cd_inscricao_estadual
                        'propriedade.cd_inscricao_estadual = lcd_inscricao_estadual  ' deve ser a lida no arquivo texto
                        parameters = ParametersEngine.getParametersFromObject(propriedade)
                        Dim dsPropriedade As New DataSet            '  27/02/2012 - Projeto Themis
                        'transacao.Fill(dsPropriedade, "ms_getPropriedadeByInscricaoEstadual", parameters, "ms_propriedade")
                        transacao.Fill(dsPropriedade, "ms_getPropriedadeByCodigoSAP", parameters, "ms_propriedade")  ' alteração solicitada pela Danone em 22/03/2012

                        If (dsPropriedade.Tables(0).Rows.Count > 0) Then   ' Se existe a propriedade no cadastro
                            ParametersEngine.persistObjectValues(dsPropriedade.Tables(0).Rows(0), propriedade)

                            ' Atualiza os dados do arquivo nas colunas da tabela Propriedade
                            propriedade.nm_propriedade = pessoa.nm_pessoa
                            propriedade.dt_inicio = pessoa.dt_inicio
                            propriedade.ds_endereco = pessoa.ds_endereco
                            propriedade.nr_endereco = pessoa.nr_endereco
                            propriedade.ds_bairro = pessoa.ds_bairro
                            propriedade.cd_cep = pessoa.cd_cep
                            propriedade.id_cidade = pessoa.id_cidade
                            propriedade.ds_telefone = pessoa.ds_telefone_1
                            propriedade.ds_email = pessoa.ds_email
                            propriedade.cd_codigo_SAP = pessoa.cd_codigo_SAP

                            ' Formata datas que vem do Framework com d/m/yyyy 
                            If Not (propriedade.dt_reativacao Is Nothing) Then
                                propriedade.dt_reativacao = DateTime.Parse(propriedade.dt_reativacao).ToString("dd/MM/yyyy HH:mm")
                            End If
                            If Not (propriedade.dt_criacao Is Nothing) Then
                                propriedade.dt_criacao = DateTime.Parse(propriedade.dt_criacao).ToString("dd/MM/yyyy HH:mm")
                            End If
                            propriedade.dt_modificacao = Now() ' 02/03/2012 - Themis
                            If Not (propriedade.dt_modificacao Is Nothing) Then
                                propriedade.dt_modificacao = DateTime.Parse(propriedade.dt_modificacao).ToString("dd/MM/yyyy HH:mm")
                            End If
                            parameters = ParametersEngine.getParametersFromObject(propriedade)
                            transacao.Execute("ms_updatePropriedade", parameters, ExecuteType.Update)


                        Else

                            '========================================================================================================================
                            ' Insere a Propriedade e UP no Produtor incluido ou alterado no processo
                            '========================================================================================================================

                            propriedade.id_estabelecimento = pessoa.id_estabelecimento
                            propriedade.id_pessoa = id_pessoa
                            propriedade.cd_inscricao_estadual = pessoa.cd_inscricao_estadual

                            propriedade.nm_propriedade = pessoa.nm_pessoa
                            propriedade.dt_inicio = pessoa.dt_inicio
                            propriedade.ds_endereco = pessoa.ds_endereco
                            propriedade.nr_endereco = pessoa.nr_endereco
                            propriedade.ds_bairro = pessoa.ds_bairro
                            propriedade.cd_cep = pessoa.cd_cep
                            propriedade.id_cidade = pessoa.id_cidade
                            propriedade.ds_telefone = pessoa.ds_telefone_1
                            propriedade.ds_email = pessoa.ds_email
                            propriedade.cd_codigo_SAP = pessoa.cd_codigo_SAP

                            propriedade.st_periodicidade_coleta = "2"  ' Assume 2 - 24 hs
                            propriedade.st_tipo_coleta = "1"  ' Assume 1 - Ímpar
                            'fran dango 2018 i
                            'propriedade.st_considera_qualidade = "N"
                            propriedade.st_considera_qualidade = "S"
                            propriedade.st_gold = "N"
                            'fran dango 2018 f
                            propriedade.st_incentivo_fiscal = "N"
                            propriedade.st_transferencia_credito = "N"
                            propriedade.st_incentivo_21 = "N"
                            propriedade.st_incentivo_24 = "N"
                            propriedade.id_situacao = 1
                            propriedade.id_item = 1
                            propriedade.unidadeproducao.nm_unid_producao = "Não Cadastrado"
                            propriedade.unidadeproducao.id_modificador = Me.id_criacao
                            propriedade.unidadeproducao.id_situacao = 1

                            parameters = ParametersEngine.getParametersFromObject(propriedade)
                            propriedade.unidadeproducao.id_propriedade = CType(transacao.ExecuteScalar("ms_insertPropriedade", parameters, ExecuteType.Insert), Int32)

                            parameters = ParametersEngine.getParametersFromObject(propriedade.unidadeproducao)
                            transacao.Execute("ms_insertUnidadesProducao", parameters, ExecuteType.Insert)

                        End If


                    End If
                    ' 27/02/2012  - Projeto Themis - f

                    liimportada = liimportada + 1

                End If


            Loop
            arqTemp.Close()

            importacaolog.nr_linha = li
            importacaolog.st_importacao = "1"
            importacaolog.cd_erro = ""
            importacaolog.nm_erro = ""
            importacaolog.id_importacao = id_importacao
            id_importacao_log = importacaolog.insertImportacaoLog

            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liimportada

            transacao.Commit()
            transacao.Dispose()     ' 24/10/2008

            ' Exclui o arquivo do servidor
            Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(Me.nm_arquivo)
            If Arquivo.Exists Then
                'fran 27/09/2013 i melhorias milk parte I - se arquivo existe no destino deleta e move da pasta origem para a temp
                'Arquivo.Delete()
                If System.IO.File.Exists(Me.nm_arquivo_destino) Then 'verifica se existe no TEMP
                    File.Delete(Me.nm_arquivo_destino) 'delete se existit
                End If
                File.Move(Me.nm_arquivo, Me.nm_arquivo_destino) 'move da pasta origem para TEMP
                'fran 27/09/2013 f melhorias milk parte I - se arquivo existe no destino deleta e move da pasta origem para a temp

            End If

            Return id_importacao


        Catch ex As Exception
            arqTemp.Close()   ' 18/05/2010 - chamado 844
            transacao.RollBack()
            transacao.Dispose()  ' 24/10/2008
            Throw New Exception(ex.Message)

        End Try

    End Function
    ' 03/02/2012 - Projeto Themis - f
    Public Function importCentralTabelaFrete() As Integer

        Dim arqTemp As StreamReader
        arqTemp = File.OpenText(Me.nm_arquivo)

        Try
            Dim id_importacao_log As Int32
            Dim liimportada As Int16 = 0

            Dim lpos_ini As Int32
            Dim lpos_fim As Int32
            Dim lipos As Int32
            Dim li As Int16

            Dim erro As Boolean = False
            Dim linhaarquivo As String
            Dim dscidadecep As DataSet
            Dim id_item As Int32 = 0
            Dim lcd_transportador As String
            Dim lcd_item As String
            Dim lbCepNaoInformado As Boolean = False
            Dim lcd_cep_origem As String
            Dim id_cidade_origem As Int32
            Dim id_estado_origem As Int32
            Dim lnm_cidade_origem As String
            Dim lcd_uf_origem As String
            Dim lcd_cep_destino As String
            Dim id_cidade_destino As Int32
            Dim id_estado_destino As Int32
            Dim lnm_cidade_destino As String
            Dim lcd_uf_destino As String
            Dim lvalor_frete_veiculo1 As String
            Dim lvalor_frete_veiculo2 As String
            Dim lvalor_frete_veiculo3 As String
            Dim lvalor_frete_veiculo4 As String
            Dim lvalor_frete_veiculo5 As String
            Dim lvalor_frete_veiculo6 As String
            Dim lvalor_frete_veiculo7 As String

            Dim nr_valor_frete_veiculo1 As Decimal
            Dim nr_valor_frete_veiculo2 As Decimal
            Dim nr_valor_frete_veiculo3 As Decimal
            Dim nr_valor_frete_veiculo4 As Decimal
            Dim nr_valor_frete_veiculo5 As Decimal
            Dim nr_valor_frete_veiculo6 As Decimal
            Dim nr_valor_frete_veiculo7 As Decimal
            Dim id_pessoa As Int32

            Dim estado As New Estado
            Dim cidade As New Cidade
            Dim item As New Item
            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim tabelafrete As New TabelaFrete
            Dim pessoa As New Pessoa

            importacao.st_tipo_importacao = 6
            importacao.dt_inicio_importacao = Now
            importacao.id_estabelecimento = Me.id_estabelecimento
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo

            Dim id_importacao As Int32 = importacao.insertImportacao()
            Me.id_importacao = id_importacao

            'declaracoes usadas no laço 
            Dim dsitem As DataSet
            Dim dstransportador As DataSet


            li = 0
            While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine

                li = li + 1

                'Descarta a primeira linha doi arquivo pois são colunas
                If li > 1 Then
                    erro = False

                    'cod transportador
                    lcd_transportador = String.Empty
                    lpos_ini = 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        lcd_transportador = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "00001"
                        importacaolog.nm_erro = "Erro: Linha sem o código do Transportador."
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()
                        erro = True
                    End If

                    'cd item
                    lcd_item = String.Empty
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")

                    If (lpos_fim > 0) Then
                        lcd_item = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    'data de validade
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If (lpos_fim > 0) Then
                        If IsDate(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))) = False Then
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00002"
                            importacaolog.nm_erro = "Erro: A data de validade não é uma data válida."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If

                    lbCepNaoInformado = False
                    cidade.cd_cep = String.Empty
                    cidade.id_situacao = 0
                    cidade.nm_cidade = String.Empty
                    cidade.cd_uf = String.Empty
                    lcd_cep_origem = String.Empty
                    id_cidade_origem = 0
                    id_estado_origem = 0
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If (lpos_fim > 0) Then
                        lcd_cep_origem = Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)).Trim
                        lipos = InStr(lcd_cep_origem, "-")
                        If (lipos > 0) Then
                            lcd_cep_origem = String.Concat(Mid(lcd_cep_origem, 1, lipos - 1), Mid(lcd_cep_origem, lipos + 1))
                        End If
                        If (lcd_cep_origem.Equals(String.Empty)) Then
                            lbCepNaoInformado = True
                        Else
                            cidade.cd_cep = lcd_cep_origem
                            dscidadecep = cidade.getCidadeByCEP()
                            If (dscidadecep.Tables(0).Rows.Count > 0) Then
                                id_cidade_origem = Convert.ToInt32(dscidadecep.Tables(0).Rows(0).Item("id_cidade"))
                                id_estado_origem = Convert.ToInt32(dscidadecep.Tables(0).Rows(0).Item("id_estado"))
                            Else
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                importacaolog.cd_erro = "00003"
                                importacaolog.nm_erro = String.Concat("Erro: CEP origem ", lcd_cep_origem, " não cadastrado.")
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                erro = True
                            End If
                        End If
                    Else
                        lbCepNaoInformado = True
                    End If

                    lnm_cidade_origem = ""
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If (lpos_fim > 0) Then
                        lnm_cidade_origem = Mid(linhaarquivo, lpos_ini, lpos_fim - lpos_ini)
                    End If

                    lcd_uf_origem = ""
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If (lpos_fim > 0) Then
                        lcd_uf_origem = Mid(linhaarquivo, lpos_ini, lpos_fim - lpos_ini)
                    End If

                    'se nao tem cep informado
                    If lbCepNaoInformado = True Then
                        If lnm_cidade_origem.ToUpper.Trim = "TODAS" Then
                            If lcd_uf_origem.Equals(String.Empty) Then
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                importacaolog.cd_erro = "00005"
                                importacaolog.nm_erro = "Erro: A sigla do Estado Origem deve ser informada para cidade 'Todas'."
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                erro = True
                            Else
                                cidade.cd_cep = String.Empty
                                cidade.id_situacao = 1
                                cidade.nm_cidade = "Todas"
                                cidade.cd_uf = lcd_uf_origem
                                dscidadecep = cidade.getCidadeCentralByFilters()
                                If (dscidadecep.Tables(0).Rows.Count > 0) Then
                                    id_cidade_origem = Convert.ToInt32(dscidadecep.Tables(0).Rows(0).Item("id_cidade"))
                                    id_estado_origem = Convert.ToInt32(dscidadecep.Tables(0).Rows(0).Item("id_estado"))
                                Else
                                    importacaolog.nr_linha = li
                                    importacaolog.st_importacao = "2"
                                    importacaolog.cd_erro = "00006"
                                    importacaolog.nm_erro = String.Concat("Erro: Não foi encontrada cidade TODAS para o estado origem ( UF ", lcd_uf_origem, " ) informado.")
                                    importacaolog.id_importacao = id_importacao
                                    id_importacao_log = importacaolog.insertImportacaoLog()
                                    erro = True
                                End If

                            End If

                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00004"
                            importacaolog.nm_erro = "Erro: CEP não informado no arquivo texto."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If
                    lbCepNaoInformado = False
                    cidade.cd_cep = String.Empty
                    cidade.id_situacao = 0
                    cidade.nm_cidade = String.Empty
                    cidade.cd_uf = String.Empty

                    lcd_cep_destino = String.Empty
                    id_cidade_destino = 0
                    id_estado_destino = 0
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If (lpos_fim > 0) Then
                        lcd_cep_destino = Mid(linhaarquivo, lpos_ini, lpos_fim - lpos_ini)
                        lipos = InStr(lcd_cep_destino, "-")
                        If (lipos > 0) Then
                            lcd_cep_destino = String.Concat(Mid(lcd_cep_destino, 1, lipos - 1), Mid(lcd_cep_destino, lipos + 1))
                        End If
                        If (lcd_cep_destino.Equals(String.Empty)) Then
                            lbCepNaoInformado = True
                        Else
                            cidade.cd_cep = lcd_cep_destino
                            dscidadecep = cidade.getCidadeByCEP()
                            If (dscidadecep.Tables(0).Rows.Count > 0) Then
                                id_cidade_destino = Convert.ToInt32(dscidadecep.Tables(0).Rows(0).Item("id_cidade"))
                                id_estado_destino = Convert.ToInt32(dscidadecep.Tables(0).Rows(0).Item("id_estado"))
                            Else
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                importacaolog.cd_erro = "00007"
                                importacaolog.nm_erro = String.Concat("Erro: CEP destino ", lcd_cep_destino, " não cadastrado.")
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                erro = True
                            End If
                        End If
                    Else
                        lbCepNaoInformado = True
                    End If

                    lnm_cidade_destino = ""
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If (lpos_fim > 0) Then
                        lnm_cidade_destino = Mid(linhaarquivo, lpos_ini, lpos_fim - lpos_ini)
                    End If

                    lcd_uf_destino = ""
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If (lpos_fim > 0) Then
                        lcd_uf_destino = Mid(linhaarquivo, lpos_ini, lpos_fim - lpos_ini)
                    End If
                    If lbCepNaoInformado = True Then
                        If lnm_cidade_destino.ToUpper().Trim() = "TODAS" Then
                            If lcd_uf_destino.Equals(String.Empty) Then
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                importacaolog.cd_erro = "00008"
                                importacaolog.nm_erro = "Erro: A sigla do Estado Destino deve ser informada para cidade 'Todas'."
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog()
                                erro = True
                            Else
                                cidade.cd_cep = String.Empty
                                cidade.id_situacao = 1
                                cidade.nm_cidade = "Todas"
                                cidade.cd_uf = lcd_uf_destino
                                dscidadecep = cidade.getCidadeCentralByFilters()
                                If (dscidadecep.Tables(0).Rows.Count > 0) Then
                                    id_cidade_destino = Convert.ToInt32(dscidadecep.Tables(0).Rows(0).Item("id_cidade"))
                                    id_estado_destino = Convert.ToInt32(dscidadecep.Tables(0).Rows(0).Item("id_estado"))
                                Else
                                    importacaolog.nr_linha = li
                                    importacaolog.st_importacao = "2"
                                    importacaolog.cd_erro = "00009"
                                    importacaolog.nm_erro = String.Concat("Erro: Não foi encontrada cidade TODAS para o estado destino ( UF ", lcd_uf_destino, " ) informado.")
                                    importacaolog.id_importacao = id_importacao
                                    id_importacao_log = importacaolog.insertImportacaoLog()
                                    erro = True
                                End If
                            End If
                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00010"
                            importacaolog.nm_erro = "Erro: CEP destino não informado no arquivo texto."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    lvalor_frete_veiculo1 = ""
                    If (lpos_fim > 0) Then
                        If (lpos_fim - lpos_ini <> 0) Then
                            lvalor_frete_veiculo1 = Mid(linhaarquivo, lpos_ini, lpos_fim - lpos_ini)
                            lvalor_frete_veiculo1 = Replace(lvalor_frete_veiculo1, ".", ",")
                        Else
                            lvalor_frete_veiculo1 = String.Empty
                        End If
                    End If

                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    lvalor_frete_veiculo2 = ""
                    If (lpos_fim > 0) Then
                        If (lpos_fim - lpos_ini <> 0) Then
                            lvalor_frete_veiculo2 = Mid(linhaarquivo, lpos_ini, lpos_fim - lpos_ini).Trim
                            lvalor_frete_veiculo2 = Replace(lvalor_frete_veiculo2, ".", ",")
                        Else
                            lvalor_frete_veiculo2 = String.Empty
                        End If
                    End If

                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    lvalor_frete_veiculo3 = ""
                    If (lpos_fim > 0) Then
                        If (lpos_fim - lpos_ini <> 0) Then
                            lvalor_frete_veiculo3 = Mid(linhaarquivo, lpos_ini, lpos_fim - lpos_ini).Trim
                            lvalor_frete_veiculo3 = Strings.Replace(lvalor_frete_veiculo3, ".", ",")
                        Else
                            lvalor_frete_veiculo3 = String.Empty
                        End If
                    End If

                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    lvalor_frete_veiculo4 = ""
                    If (lpos_fim > 0) Then
                        If (lpos_fim - lpos_ini <> 0) Then
                            lvalor_frete_veiculo4 = Mid(linhaarquivo, lpos_ini, lpos_fim - lpos_ini).Trim
                            lvalor_frete_veiculo4 = Replace(lvalor_frete_veiculo4, ".", ",")
                        Else
                            lvalor_frete_veiculo4 = String.Empty
                        End If
                    End If

                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    lvalor_frete_veiculo5 = ""
                    If (lpos_fim > 0) Then
                        If (lpos_fim - lpos_ini <> 0) Then
                            lvalor_frete_veiculo5 = Mid(linhaarquivo, lpos_ini, lpos_fim - lpos_ini).Trim
                            lvalor_frete_veiculo5 = Replace(lvalor_frete_veiculo5, ".", ",")
                        Else
                            lvalor_frete_veiculo5 = String.Empty
                        End If
                    End If

                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    lvalor_frete_veiculo6 = ""
                    If (lpos_fim > 0) Then
                        If (lpos_fim - lpos_ini <> 0) Then
                            lvalor_frete_veiculo6 = Mid(linhaarquivo, lpos_ini, lpos_fim - lpos_ini).Trim
                            lvalor_frete_veiculo6 = Strings.Replace(lvalor_frete_veiculo6, ".", ",")
                        Else
                            lvalor_frete_veiculo6 = String.Empty
                        End If
                    End If

                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    lvalor_frete_veiculo7 = ""
                    If (lpos_fim > 0) Then
                        If (lpos_fim - lpos_ini <> 0) Then
                            lvalor_frete_veiculo7 = Mid(linhaarquivo, lpos_ini, lpos_fim - lpos_ini).Trim
                            lvalor_frete_veiculo7 = Strings.Replace(lvalor_frete_veiculo7, ".", ",")
                        Else
                            lvalor_frete_veiculo7 = String.Empty
                        End If
                    Else
                        lvalor_frete_veiculo7 = Mid(linhaarquivo, lpos_ini).Trim
                        If Not lvalor_frete_veiculo7.ToString.Trim.Equals(String.Empty) Then
                            lvalor_frete_veiculo7 = Strings.Replace(lvalor_frete_veiculo7, ".", ",")
                        End If
                    End If

                    If lcd_item.Trim = String.Empty Then
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "00011"
                        importacaolog.nm_erro = "Erro: Código do item deve ser informado."
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()
                        erro = True
                    Else
                        item.id_situacao = 1
                        item.st_central_compras = "S"
                        item.cd_item = lcd_item
                        'Dim dsitem As DataSet = item.getItensCentralByFilters()
                        dsitem = item.getItensCentralByFilters()
                        If (dsitem.Tables(0).Rows.Count > 0) Then
                            id_item = Convert.ToInt32(dsitem.Tables(0).Rows(0).Item("id_item"))
                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00012"
                            importacaolog.nm_erro = "Erro: Código do item não cadastrado ou não ativo."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True

                        End If
                    End If
                    id_pessoa = 0
                    If (IsNumeric(lcd_transportador)) = True Then
                        pessoa.cd_pessoa = lcd_transportador
                        'Dim dstransportador As DataSet = pessoa.getTransportadorCentralByFilters()
                        dstransportador = pessoa.getTransportadorCentralByFilters()
                        If (dstransportador.Tables(0).Rows.Count > 0) Then
                            id_pessoa = dstransportador.Tables(0).Rows(0).Item("id_pessoa")
                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00014"
                            importacaolog.nm_erro = "Código Transportador não cadastrado ou não ativo para Central de Compras."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                            id_pessoa = 0
                        End If
                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "00013"
                        importacaolog.nm_erro = "Erro: Código do Transportador não é numérico"
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()
                        erro = True
                        id_pessoa = 0
                    End If

                    If (lvalor_frete_veiculo1.Equals(String.Empty)) Then
                        nr_valor_frete_veiculo1 = 0
                    Else
                        If (IsNumeric(lvalor_frete_veiculo1)) Then
                            nr_valor_frete_veiculo1 = Convert.ToDecimal(lvalor_frete_veiculo1)
                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00015"
                            importacaolog.nm_erro = "Valor do Frete para veículo '1 - TRUCK 14 T' não é numérico"
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If

                    If (lvalor_frete_veiculo2.Equals(String.Empty)) Then
                        nr_valor_frete_veiculo2 = 0
                    Else
                        If (IsNumeric(lvalor_frete_veiculo2)) Then
                            nr_valor_frete_veiculo2 = Convert.ToDecimal(lvalor_frete_veiculo2)
                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00016"
                            importacaolog.nm_erro = "Valor do Frete para veículo '2 - TRUCK ROSCA' não é numérico"
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If

                    If (lvalor_frete_veiculo3.Equals(String.Empty)) Then
                        nr_valor_frete_veiculo3 = 0
                    Else
                        If (IsNumeric(lvalor_frete_veiculo3)) Then
                            nr_valor_frete_veiculo3 = Convert.ToDecimal(lvalor_frete_veiculo3)
                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00017"
                            importacaolog.nm_erro = "Valor do Frete para veículo '3 - BITRUCK 18 T' não é numérico"
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If

                    If (lvalor_frete_veiculo4.Equals(String.Empty)) Then
                        nr_valor_frete_veiculo4 = 0
                    Else
                        If (IsNumeric(lvalor_frete_veiculo4)) Then
                            nr_valor_frete_veiculo4 = Convert.ToDecimal(lvalor_frete_veiculo4)
                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00018"
                            importacaolog.nm_erro = "Valor do Frete para veículo '4 - Carreta Graneleira 32 T' não é numérico"
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If

                    If (lvalor_frete_veiculo5.Equals(String.Empty)) Then
                        nr_valor_frete_veiculo5 = 0
                    Else
                        If (IsNumeric(lvalor_frete_veiculo5)) Then
                            nr_valor_frete_veiculo5 = Convert.ToDecimal(lvalor_frete_veiculo5)
                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00019"
                            importacaolog.nm_erro = "Valor do Frete para veículo '5 - Carreta Basculante 32 T' não é numérico"
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If

                    If (lvalor_frete_veiculo6.Equals(String.Empty)) Then
                        nr_valor_frete_veiculo6 = 0
                    Else
                        If (IsNumeric(lvalor_frete_veiculo6)) Then
                            nr_valor_frete_veiculo6 = Convert.ToDecimal(lvalor_frete_veiculo6)
                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00020"
                            importacaolog.nm_erro = "Valor do Frete para veículo '6 - BITREM 36 T' não é numérico"
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If

                    If (lvalor_frete_veiculo7.Equals(String.Empty)) Then
                        nr_valor_frete_veiculo7 = 0
                    Else
                        If (IsNumeric(lvalor_frete_veiculo7)) Then
                            nr_valor_frete_veiculo7 = Convert.ToDecimal(lvalor_frete_veiculo7)
                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "00021"
                            importacaolog.nm_erro = "Valor do Frete para veículo '7 - Rodotrem' não é numérico"
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If
                    End If

                    If nr_valor_frete_veiculo1 = 0 And nr_valor_frete_veiculo2 = 0 And nr_valor_frete_veiculo3 = 0 And nr_valor_frete_veiculo4 = 0 And nr_valor_frete_veiculo5 = 0 And nr_valor_frete_veiculo6 = 0 And nr_valor_frete_veiculo7 = 0 Then
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "00022"
                        importacaolog.nm_erro = "Para esta tabela de frete, o valor de frete deve ser maior que zero (O) para algum veículo."
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()
                        erro = True
                    End If

                    If erro = False Then
                        tabelafrete.id_modificador = Me.id_criacao
                        tabelafrete.id_estabelecimento = Me.id_estabelecimento
                        tabelafrete.id_fornecedor = id_pessoa
                        tabelafrete.id_item = id_item
                        tabelafrete.id_cidade_origem = id_cidade_origem
                        tabelafrete.id_cidade_destino = id_cidade_destino

                        tabelafrete.tfv_id_veiculocentral.Clear()
                        tabelafrete.tfv_nr_valor_frete.Clear()
                        tabelafrete.tfv_id_veiculocentral.Add(1)
                        tabelafrete.tfv_nr_valor_frete.Add(nr_valor_frete_veiculo1)
                        tabelafrete.tfv_id_veiculocentral.Add(2)
                        tabelafrete.tfv_nr_valor_frete.Add(nr_valor_frete_veiculo2)
                        tabelafrete.tfv_id_veiculocentral.Add(3)
                        tabelafrete.tfv_nr_valor_frete.Add(nr_valor_frete_veiculo3)
                        tabelafrete.tfv_id_veiculocentral.Add(4)
                        tabelafrete.tfv_nr_valor_frete.Add(nr_valor_frete_veiculo4)
                        tabelafrete.tfv_id_veiculocentral.Add(5)
                        tabelafrete.tfv_nr_valor_frete.Add(nr_valor_frete_veiculo5)
                        tabelafrete.tfv_id_veiculocentral.Add(6)
                        tabelafrete.tfv_nr_valor_frete.Add(nr_valor_frete_veiculo6)
                        tabelafrete.tfv_id_veiculocentral.Add(7)
                        tabelafrete.tfv_nr_valor_frete.Add(nr_valor_frete_veiculo7)
                        tabelafrete.insertCentralTabelaFrete()
                        liimportada = liimportada + 1
                    End If
                End If
            End While
            arqTemp.Close()
            importacaolog.nr_linha = li.ToString
            importacaolog.st_importacao = 1
            importacaolog.cd_erro = ""
            importacaolog.nm_erro = ""
            importacaolog.id_importacao = id_importacao
            id_importacao_log = importacaolog.insertImportacaoLog()
            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()
            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liimportada
            Return id_importacao

        Catch ex As System.Exception
            arqTemp.Close()   ' 18/05/2010 - chamado 844
            Throw New Exception(ex.Message)
        End Try

    End Function


End Class