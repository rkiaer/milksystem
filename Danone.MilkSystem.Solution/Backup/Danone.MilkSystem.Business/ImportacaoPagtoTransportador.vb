Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO

<Serializable()> Public Class ImportacaoPagtoTransportador

    Private _id_importacao_pagto_transportador As Int32
    Private _id_importacao As Int32
    Private _id_transportador As Int32
    Private _id_criacao As Int32
    Private _id_pagto_transportador As Int32
    Private _dt_referencia As String
    Private _dt_pagto As String
    Private _dt_emissao As String
    Private _cd_transportador_sap As String
    Private _ds_transportador As String
    Private _cd_transportador As String
    Private _ds_data_emissao As String
    Private _ds_data_pagto As String
    Private _ds_fatura As String 'fran 03/2017
    Private _ds_valor_frete As String
    Private _nr_valor_frete As Decimal
    Private _nm_arquivo As String
    Private _nr_linhaslidas As Int32
    Private _nr_linhasimportadas As Int32
    Private _id_modificador As Int32


    Public Property id_importacao_pagto_transportador() As Int32
        Get
            Return _id_importacao_pagto_transportador
        End Get
        Set(ByVal value As Int32)
            _id_importacao_pagto_transportador = value
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

    
    Public Property id_pagto_transportador() As Int32
        Get
            Return _id_pagto_transportador
        End Get
        Set(ByVal value As Int32)
            _id_pagto_transportador = value
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

    Public Property nr_valor_frete() As Decimal
        Get
            Return _nr_valor_frete
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_frete = value
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
    Public Property dt_pagto() As String
        Get
            Return _dt_pagto
        End Get
        Set(ByVal value As String)
            _dt_pagto = value
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
    Public Property cd_transportador_sap() As String
        Get
            Return _cd_transportador_sap
        End Get
        Set(ByVal value As String)
            _cd_transportador_sap = value
        End Set
    End Property
    Public Property cd_transportador() As String
        Get
            Return _cd_transportador
        End Get
        Set(ByVal value As String)
            _cd_transportador = value
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
   
    Public Property ds_valor_frete() As String
        Get
            Return _ds_valor_frete
        End Get
        Set(ByVal value As String)
            _ds_valor_frete = value
        End Set
    End Property

    Public Property ds_data_emissao() As String
        Get
            Return _ds_data_emissao
        End Get
        Set(ByVal value As String)
            _ds_data_emissao = value
        End Set
    End Property
    Public Property ds_data_pagto() As String
        Get
            Return _ds_data_pagto
        End Get
        Set(ByVal value As String)
            _ds_data_pagto = value
        End Set
    End Property
    Public Property ds_fatura() As String
        Get
            Return _ds_fatura
        End Get
        Set(ByVal value As String)
            _ds_fatura = value
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

        Me._id_importacao_pagto_transportador = id
        loadImportacaoPagtoTransportador()

    End Sub
    Public Sub New()

    End Sub
    Public Function getImportacaoPagtoTransportadorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getImportacaoPagtoTransportador", parameters, "ms_importacao_pagto_transportador")
            Return dataSet

        End Using

    End Function


    Private Sub loadImportacaoPagtoTransportador()

        Dim dataSet As DataSet = getImportacaoPagtoTransportadorByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertImportacaoPagtoTransportador() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertImportacaoPagtoTransportador", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertPagtoTransportadorImportacaoFrete() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPagtoTransportadorImportFrete", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub updateImportacaoPagtoTransportador()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateImportacaoPagtoTransportador", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePagtoTransportadorImportacaoFrete()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePagtoTransportadorImportFrete", parameters, ExecuteType.Update)

        End Using

    End Sub
    Function importPagtoTransportador() As Int32

        Dim arqTemp As StreamReader
        arqTemp = File.OpenText(Me.nm_arquivo)

        Try

            Dim linhaarquivo As String

            Dim li As Int16
            Dim erro As Boolean


            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim ImportacaoPagtoTransportadorErro As New ImportacaoPagtoTransportadorErro
            Dim transportador As New Pessoa
            Dim pagtotransportador As New PagtoTransportador
            Dim dspagtotransportador As DataSet
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32

            Dim lmes As String
            Dim lano As String
            Dim ldia As String

            Dim lpos_ini As Int32
            Dim lpos_fim As Int32


            importacao.st_tipo_importacao = 4
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

                    ' Codigo Transportador SAP
                    lpos_ini = 1
                    Me.cd_transportador_sap = String.Empty
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ",")
                    If lpos_fim > 0 Then
                        cd_transportador_sap = Left(Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini))), 10)
                        If Len(cd_transportador_sap) < 10 Then 'cd sap tem 10 posições
                            cd_transportador_sap = Right(String.Concat(StrDup(10 - Len(cd_transportador_sap), "0"), cd_transportador_sap), 10)
                        End If
                    End If

                    ' Valor Pagto Frete
                    lpos_ini = lpos_fim + 1

                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ",")
                    ds_valor_frete = ""
                    Me.nr_valor_frete = 0
                    If lpos_fim > 0 Then
                        ds_valor_frete = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                        ds_valor_frete = Replace(ds_valor_frete, ".", ",")
                    End If


                    ' Codigo da Transportador - ds_transportador
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ",")
                    ds_transportador = String.Empty
                    cd_transportador = String.Empty
                    Me.id_transportador = 0
                    If lpos_fim > 0 Then
                        ds_transportador = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                        lpos_ini = InStr(1, ds_transportador, "-")
                        If lpos_ini > 0 Then
                            cd_transportador = Trim(Left(ds_transportador, lpos_ini - 1))
                        End If
                    End If

                    ' data emissao BUSCA A DATA DE EMISSAO
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ",")
                    Me.ds_data_emissao = ""
                    Me.dt_emissao = String.Empty
                    If lpos_fim > 0 Then
                        ds_data_emissao = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    'BUSCA DATA DE PAGTO
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ",") 'fran 03/2017 - inclusao de campo fatura
                    Me.ds_data_pagto = ""
                    Me.dt_referencia = String.Empty
                    Me.dt_pagto = String.Empty

                    'fran 03/2017 i inclusao do campo fatura
                    'ds_data_pagto = Trim(Mid(linhaarquivo, lpos_ini))
                    If lpos_fim > 0 Then
                        ds_data_pagto = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    'BUSCA FATURA
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    Me.ds_fatura = String.Empty
                    Me.ds_fatura = Trim(Mid(linhaarquivo, lpos_ini))
                    'fran 03/2017 f inclusao do campo fatura

                    'TRATA DATA DE EMISSAO
                    lpos_ini = 1
                    lpos_fim = InStr(lpos_ini, ds_data_emissao, "/")
                    If lpos_fim > 0 Then 'se achou a barra
                        ldia = Trim(Mid(ds_data_emissao, lpos_ini, (lpos_fim - lpos_ini)))
                        If Len(ldia) = 1 Then 'se o dia so tem 1 posição
                            ldia = String.Concat("0", ldia)
                        End If

                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, ds_data_emissao, "/")

                        If lpos_fim > 0 Then
                            lmes = Trim(Mid(ds_data_emissao, lpos_ini, (lpos_fim - lpos_ini)))
                            If Len(lmes) = 1 Then 'se o mes so tem1 posição
                                lmes = String.Concat("0", lmes)
                            End If

                            lano = Trim(Mid(ds_data_emissao, lpos_fim + 1))
                            If Len(lano) < 4 Then
                                lano = String.Concat("20", lano)
                            End If

                            Me.dt_emissao = String.Concat(ldia, "/", lmes, "/", lano)
                        Else
                            'se não tem barra, data esta errada
                            Me.dt_emissao = String.Empty
                        End If
                    Else
                        'se não tem barra, data esta errada
                        Me.dt_emissao = String.Empty
                    End If

                    'tratar data de pagto
                    lpos_ini = 1
                    lpos_fim = InStr(lpos_ini, ds_data_pagto, "/")
                    If lpos_fim > 0 Then 'se achou a barra

                        ldia = Trim(Mid(ds_data_pagto, lpos_ini, (lpos_fim - lpos_ini)))
                        If Len(ldia) = 1 Then 'se o dia so tem 1 posição
                            ldia = String.Concat("0", ldia)
                        End If

                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, ds_data_pagto, "/")

                        If lpos_fim > 0 Then
                            lmes = Trim(Mid(ds_data_pagto, lpos_ini, (lpos_fim - lpos_ini)))
                            If Len(lmes) = 1 Then 'se o mes so tem1 posição
                                lmes = String.Concat("0", lmes)
                            End If

                            lano = Left(Trim(Mid(ds_data_pagto, lpos_fim + 1)), 4)
                            If Len(lano) < 4 Then
                                lano = Left(String.Concat("20", lano), 4)
                            End If

                            Me.dt_referencia = String.Concat("01/", lmes, "/", lano)
                            Me.dt_pagto = String.Concat(ldia, "/", lmes, "/", lano)
                        Else
                            'se não tem barra, data esta errada
                            Me.dt_referencia = String.Empty
                            Me.dt_pagto = String.Empty

                        End If
                    Else
                        'se não tem barra, data esta errada
                        Me.dt_referencia = String.Empty
                        Me.dt_pagto = String.Empty
                    End If


                    '=========================================
                    ' Insere linha importada na importacaon frete
                    '=========================================
                    Me.id_importacao_pagto_transportador = Me.insertImportacaoPagtoTransportador
                    '=========================================
                    ' Consistencias
                    '=========================================
                    erro = False
                    importacaopagtotransportadorErro.id_criacao = Me.id_criacao
                    importacaopagtotransportadorErro.id_importacao_pagto_transportador = Me.id_importacao_pagto_transportador

                    If IsNumeric(ds_valor_frete) = False Then

                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "4"
                        importacaolog.cd_erro = "40001"
                        importacaolog.nm_erro = "Valor do Pagto de frete não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ImportacaoPagtoTransportadorErro.id_importacao_log = id_importacao_log
                        ImportacaoPagtoTransportadorErro.insertImportacaoPagtoTransportadorErro()
                        erro = True
                        Me.nr_valor_frete = 0

                    Else
                        Me.nr_valor_frete = Convert.ToDecimal(ds_valor_frete)
                    End If

                    If IsNumeric(cd_transportador) = False Then
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "4"
                        importacaolog.cd_erro = "40002"
                        importacaolog.nm_erro = "Código do Transportador não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        importacaopagtotransportadorErro.id_importacao_log = id_importacao_log
                        ImportacaoPagtoTransportadorErro.insertImportacaoPagtoTransportadorErro()

                        erro = True
                        Me.id_transportador = 0
                    Else

                        transportador.cd_pessoa = cd_transportador
                        Dim dstransportador As DataSet = transportador.getPessoaByFilters()

                        If Not (dstransportador.Tables(0).Rows.Count > 0) Then  '  Se o transportador nao existe 

                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "4"
                            importacaolog.cd_erro = "40003"
                            importacaolog.nm_erro = "Código Transportador não cadastrado ou não ativo."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ImportacaoPagtoTransportadorErro.id_importacao_log = id_importacao_log
                            ImportacaoPagtoTransportadorErro.insertImportacaoPagtoTransportadorErro()
                            erro = True

                            Me.id_transportador = 0

                        Else
                            If Not (dstransportador.Tables(0).Rows(0).Item("id_grupo").ToString = "3" Or dstransportador.Tables(0).Rows(0).Item("id_grupo").ToString = "4") Then
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "4"
                                importacaolog.cd_erro = "40004"
                                importacaolog.nm_erro = "O código informado deve deve ser de uma Cooperativa ou Transportador."
                                importacaolog.id_importacao = id_importacao

                                id_importacao_log = importacaolog.insertImportacaoLog()

                                ImportacaoPagtoTransportadorErro.id_importacao_log = id_importacao_log
                                ImportacaoPagtoTransportadorErro.insertImportacaoPagtoTransportadorErro()
                                erro = True

                            Else
                                If dstransportador.Tables(0).Rows(0).Item("id_situacao").ToString = "2" Then
                                    importacaolog.nr_linha = li
                                    importacaolog.st_importacao = "4"
                                    importacaolog.cd_erro = "40005"
                                    importacaolog.nm_erro = "O transportador informado está desativado."
                                    importacaolog.id_importacao = id_importacao

                                    id_importacao_log = importacaolog.insertImportacaoLog()

                                    ImportacaoPagtoTransportadorErro.id_importacao_log = id_importacao_log
                                    ImportacaoPagtoTransportadorErro.insertImportacaoPagtoTransportadorErro()
                                    erro = True
                                End If

                            End If
                            Me.id_transportador = dstransportador.Tables(0).Rows(0).Item("id_pessoa")

                            If IsNumeric(cd_transportador_sap) = False Then
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "4"
                                importacaolog.cd_erro = "40006"
                                importacaolog.nm_erro = "Código SAP do Transportador não é numérico"
                                importacaolog.id_importacao = id_importacao

                                id_importacao_log = importacaolog.insertImportacaoLog()

                                ImportacaoPagtoTransportadorErro.id_importacao_log = id_importacao_log
                                ImportacaoPagtoTransportadorErro.insertImportacaoPagtoTransportadorErro()

                                erro = True
                            Else
                                If dstransportador.Tables(0).Rows(0).Item("cd_codigo_sap").ToString <> cd_transportador_sap Then
                                    importacaolog.nr_linha = li
                                    importacaolog.st_importacao = "4"
                                    importacaolog.cd_erro = "40007"
                                    importacaolog.nm_erro = "Código SAP informado não está cadastrado para o transportador " + cd_transportador + "."
                                    importacaolog.id_importacao = id_importacao

                                    id_importacao_log = importacaolog.insertImportacaoLog()

                                    ImportacaoPagtoTransportadorErro.id_importacao_log = id_importacao_log
                                    ImportacaoPagtoTransportadorErro.insertImportacaoPagtoTransportadorErro()

                                    erro = True
                                End If
                            End If
                        End If
                    End If
                    'Consiste datas
                    If IsDate(Me.dt_referencia) = False Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "4"
                        importacaolog.cd_erro = "40008"
                        importacaolog.nm_erro = "Data de pagamento inválida."
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ImportacaoPagtoTransportadorErro.id_importacao_log = id_importacao_log
                        ImportacaoPagtoTransportadorErro.insertImportacaoPagtoTransportadorErro()

                        erro = True
                        Me.dt_referencia = String.Empty
                        Me.dt_pagto = String.Empty
                    End If
                    If IsDate(Me.dt_emissao) = False Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "4"
                        importacaolog.cd_erro = "40009"
                        importacaolog.nm_erro = "Data de emissão inválida."
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ImportacaoPagtoTransportadorErro.id_importacao_log = id_importacao_log
                        ImportacaoPagtoTransportadorErro.insertImportacaoPagtoTransportadorErro()

                        erro = True
                        Me.dt_emissao = String.Empty

                    End If

                    '=========================================
                    ' Atualiza linha importada na importacaon pagto transportador
                    '=========================================
                    Me.updateImportacaoPagtoTransportador()


                    '=========================================
                    ' Inclui linhas em lancamento
                    '=========================================
                    pagtotransportador.id_pagto_transportador = 0
                    If erro = False Then
                        pagtotransportador.dt_referencia = Me.dt_referencia
                        pagtotransportador.id_transportador = Me.id_transportador
                        dspagtotransportador = pagtotransportador.getPagtoTransportadorSemExportacao
                        If dspagtotransportador.Tables(0).Rows.Count > 0 Then
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "4"
                            importacaolog.cd_erro = "40010"
                            importacaolog.nm_erro = "O valor do frete,a fatura, as datas de emissão e pagamento, existentes em 'Pagto de Transportador', foram atualizadas com o conteúdo informado na importação."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ImportacaoPagtoTransportadorErro.id_importacao_log = id_importacao_log
                            ImportacaoPagtoTransportadorErro.insertImportacaoPagtoTransportadorErro()
                            pagtotransportador.id_pagto_transportador = dspagtotransportador.Tables(0).Rows(0).Item("id_pagto_transportador")
                        End If

                        If pagtotransportador.id_pagto_transportador <> 0 Then
                            Me.id_pagto_transportador = pagtotransportador.id_pagto_transportador
                            Me.updatePagtoTransportadorImportacaoFrete()
                        Else
                            Me.id_pagto_transportador = 0
                            Me.insertPagtoTransportadorImportacaoFrete()

                        End If
                        If pagtotransportador.id_pagto_transportador = 0 Then
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "4"
                            importacaolog.cd_erro = ""
                            importacaolog.nm_erro = ""
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog

                            ImportacaoPagtoTransportadorErro.id_importacao_log = id_importacao_log
                            ImportacaoPagtoTransportadorErro.insertImportacaoPagtoTransportadorErro()
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

