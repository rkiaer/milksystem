Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO

<Serializable()> Public Class ImportacaoPedido

    Private _id_importacao_pedido As Int32
    Private _id_importacao As Int32
    Private _ds_propriedade As String
    Private _ds_produtor As String
    Private _ds_unidade As String
    Private _ds_embalagem As String
    Private _nr_qtde As Int32
    Private _dt_pedido As String
    Private _ds_parcelar As String
    Private _ds_produtorinf As String
    Private _dt_pagto As String
    Private _cd_fornecedor As String
    Private _nm_fornecedor As String
    Private _cd_item As String
    Private _dt_emissao As String
    Private _nr_nota As Int32
    Private _nr_serie As String
    Private _nr_valor_nota As Decimal
    Private _dt_pagto_fornecedor As String
    Private _dt_desconto_produtor As String
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _id_propriedade As Int32
    Private _st_tipo_embalagem As String
    Private _id_fornecedor As Int32
    Private _id_produtor As Int32
    Private _id_item As Int32
    Private _id_unidproducao As Int32
    Private _id_central_pedido As Int32
    Private _st_execucao As String
    Private _dt_fim_execucao As String
    Private _nm_arquivo As String
    Private _nr_linhaslidas As Int32
    Private _nr_linhasimportadas As Int32
    Private _id_modificador As Int32
    Private _nr_unid_producao As Int32
    Private _dt_pagto_ini As String
    Private _dt_pagto_fim As String


    Public Property id_importacao_pedido() As Int32
        Get
            Return _id_importacao_pedido
        End Get
        Set(ByVal value As Int32)
            _id_importacao_pedido = value
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
    Public Property ds_produtor() As String
        Get
            Return _ds_produtor
        End Get
        Set(ByVal value As String)
            _ds_produtor = value
        End Set
    End Property
    Public Property ds_unidade() As String
        Get
            Return _ds_unidade
        End Get
        Set(ByVal value As String)
            _ds_unidade = value
        End Set
    End Property
    Public Property ds_embalagem() As String
        Get
            Return _ds_embalagem
        End Get
        Set(ByVal value As String)
            _ds_embalagem = value
        End Set
    End Property
    Public Property nr_qtde() As Int32
        Get
            Return _nr_qtde
        End Get
        Set(ByVal value As Int32)
            _nr_qtde = value
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
    Public Property ds_parcelar() As String
        Get
            Return _ds_parcelar
        End Get
        Set(ByVal value As String)
            _ds_parcelar = value
        End Set
    End Property
    Public Property ds_produtorinf() As String
        Get
            Return _ds_produtorinf
        End Get
        Set(ByVal value As String)
            _ds_produtorinf = value
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
    Public Property cd_fornecedor() As String
        Get
            Return _cd_fornecedor
        End Get
        Set(ByVal value As String)
            _cd_fornecedor = value
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
    Public Property cd_item() As String
        Get
            Return _cd_item
        End Get
        Set(ByVal value As String)
            _cd_item = value
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
    Public Property nr_nota() As Int32
        Get
            Return _nr_nota
        End Get
        Set(ByVal value As Int32)
            _nr_nota = value
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
    Public Property nr_valor_nota() As Decimal
        Get
            Return _nr_valor_nota
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nota = value
        End Set
    End Property
    Public Property dt_pagto_fornecedor() As String
        Get
            Return _dt_pagto_fornecedor
        End Get
        Set(ByVal value As String)
            _dt_pagto_fornecedor = value
        End Set
    End Property
    Public Property dt_desconto_produtor() As String
        Get
            Return _dt_desconto_produtor
        End Get
        Set(ByVal value As String)
            _dt_desconto_produtor = value
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
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
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
    Public Property st_tipo_embalagem() As String
        Get
            Return _st_tipo_embalagem
        End Get
        Set(ByVal value As String)
            _st_tipo_embalagem = value
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
    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
        End Set
    End Property
    Public Property id_unidproducao() As Int32
        Get
            Return _id_unidproducao
        End Get
        Set(ByVal value As Int32)
            _id_unidproducao = value
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
    Public Property nr_unid_producao() As Int32
        Get
            Return _nr_unid_producao
        End Get
        Set(ByVal value As Int32)
            _nr_unid_producao = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me._id_importacao_pedido = id
        loadImportacaoPedido()

    End Sub
    Public Sub New()

    End Sub
    Public Function getImportacaoPedidoConsDuplicidade() As Int32


        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getImportacaoPedidoConsDuplicidade", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Function getImportacaoPedidoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getImportacaoPedido", parameters, "ms_importacao_pedido")
            Return dataSet

        End Using

    End Function
    Public Function getImportacaoPedidoIncluidosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getImportacaoPedidoIncluidos", parameters, "ms_importacao_pedido")
            Return dataSet

        End Using

    End Function
    Private Sub loadImportacaoPedido()

        Dim dataSet As DataSet = getImportacaoPedidoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertImportacaoPedidoLinha() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertImportacaoPedidoLinha", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Function insertImportacaoPedido() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertImportacaoPedido", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub updateImportacaoPedido()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateImportacaoPedido", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePagtoTransportadorImportacaoFrete()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePagtoTransportadorImportFrete", parameters, ExecuteType.Update)

        End Using

    End Sub
    Function importPedido() As Int32

        Dim arqTemp As StreamReader
        arqTemp = File.OpenText(Me.nm_arquivo)

        Try

            Dim linhaarquivo As String

            Dim li As Int16
            Dim erro As Boolean


            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim ImportacaoPedidoErro As New ImportacaoPedidoErro
            Dim fornecedor As New Pessoa
            Dim up As New UnidadeProducao
            Dim item As New Item
            Dim dspedido As DataSet
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32

            Dim lmes As String
            Dim lano As String
            Dim ldia As String

            Dim lpos_ini As Int32
            Dim lpos_fim As Int32

            Dim ds_id_propriedade As String
            Dim ds_unid_producao As String
            Dim ds_nr_qtde As String
            Dim ds_nr_nota As String
            Dim ds_valor_total As String

            importacao.st_tipo_importacao = 7
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

                    ' Codigo propriedade
                    lpos_ini = 1
                    Me.ds_propriedade = String.Empty
                    ds_id_propriedade = String.Empty
                    ds_unid_producao = String.Empty
                    id_propriedade = 0
                    id_unidproducao = 0
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        ds_propriedade = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                        lpos_ini = InStr(1, ds_propriedade, "-")
                        If lpos_ini > 0 Then
                            ds_id_propriedade = Trim(Left(ds_propriedade, lpos_ini - 1))
                            ds_unid_producao = Mid(ds_propriedade, lpos_ini + 1)
                        End If
                    End If
                    If IsNumeric(ds_id_propriedade) Then
                        Me.id_propriedade = ds_id_propriedade
                    End If
                    If IsNumeric(ds_unid_producao) Then
                        Me.nr_unid_producao = ds_unid_producao
                    End If

                    ' Produtor
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    ds_produtor = String.Empty
                    If lpos_fim > 0 Then
                        ds_produtor = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' Unidade
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    ds_unidade = String.Empty
                    If lpos_fim > 0 Then
                        ds_unidade = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' embalagem
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    ds_embalagem = String.Empty
                    If lpos_fim > 0 Then
                        ds_embalagem = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' qtde
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.nr_qtde = 0
                    ds_nr_qtde = String.Empty
                    If lpos_fim > 0 Then
                        ds_nr_qtde = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    If IsNumeric(ds_nr_qtde) Then
                        Me.nr_qtde = ds_nr_qtde
                    End If

                    ' data produtor 
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.dt_pedido = ""
                    If lpos_fim > 0 Then
                        dt_pedido = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' parcelar 
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.ds_parcelar = ""
                    If lpos_fim > 0 Then
                        ds_parcelar = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' prod inf 
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.ds_produtorinf = ""
                    If lpos_fim > 0 Then
                        ds_produtorinf = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' prazo de pagto
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.dt_pagto = ""
                    If lpos_fim > 0 Then
                        dt_pagto = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' cd fornecedor
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.cd_fornecedor = ""
                    Me.id_fornecedor = 0
                    If lpos_fim > 0 Then
                        cd_fornecedor = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' nm fornecedor
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.nm_fornecedor = ""
                    If lpos_fim > 0 Then
                        nm_fornecedor = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' cd item
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.cd_item = ""
                    Me.id_item = 0
                    If lpos_fim > 0 Then
                        cd_item = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    'dt emissao
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.dt_emissao = String.Empty

                    If lpos_fim > 0 Then
                        dt_emissao = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    'BUSCA nota
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.nr_nota = 0
                    ds_nr_nota = String.Empty
                    If lpos_fim > 0 Then
                        ds_nr_nota = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    If IsNumeric(ds_nr_nota) Then
                        Me.nr_nota = ds_nr_nota
                    End If

                    'BUSCA serie
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.nr_serie = String.Empty
                    If lpos_fim > 0 Then
                        nr_serie = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    'valor total
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.nr_valor_nota = 0
                    ds_valor_total = String.Empty
                    If lpos_fim > 0 Then
                        ds_valor_total = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    If Not ds_valor_total.ToString.Equals(String.Empty) Then
                        Me.nr_valor_nota = ds_valor_total
                    End If

                    'dt pagto fornecedor
                    lpos_ini = lpos_fim + 1
                    'Delimitador deve ser virgula
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    Me.dt_pagto_fornecedor = String.Empty

                    If lpos_fim > 0 Then
                        dt_pagto_fornecedor = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' dt descto produtor
                    lpos_ini = lpos_fim + 1
                    lpos_fim = Len(linhaarquivo) + 1 ' Não tem ; no final
                    Me.dt_desconto_produtor = String.Empty
                    If lpos_fim > 0 Then
                        dt_desconto_produtor = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If


                    'TRATA DATAs
                    lpos_ini = 1
                    lpos_fim = InStr(lpos_ini, dt_emissao, "/")
                    If lpos_fim > 0 Then 'se achou a barra
                        ldia = Trim(Mid(dt_emissao, lpos_ini, (lpos_fim - lpos_ini)))
                        If Len(ldia) = 1 Then 'se o dia so tem 1 posição
                            ldia = String.Concat("0", ldia)
                        End If

                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, dt_emissao, "/")

                        If lpos_fim > 0 Then
                            lmes = Trim(Mid(dt_emissao, lpos_ini, (lpos_fim - lpos_ini)))
                            If Len(lmes) = 1 Then 'se o mes so tem1 posição
                                lmes = String.Concat("0", lmes)
                            End If

                            lano = Trim(Mid(dt_emissao, lpos_fim + 1))
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

                    'tratar data produtor
                    lpos_ini = 1
                    lpos_fim = InStr(lpos_ini, dt_pedido, "/")
                    If lpos_fim > 0 Then 'se achou a barra

                        ldia = Trim(Mid(dt_pedido, lpos_ini, (lpos_fim - lpos_ini)))
                        If Len(ldia) = 1 Then 'se o dia so tem 1 posição
                            ldia = String.Concat("0", ldia)
                        End If

                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, dt_pedido, "/")

                        If lpos_fim > 0 Then
                            lmes = Trim(Mid(dt_pedido, lpos_ini, (lpos_fim - lpos_ini)))
                            If Len(lmes) = 1 Then 'se o mes so tem1 posição
                                lmes = String.Concat("0", lmes)
                            End If

                            lano = Left(Trim(Mid(dt_pedido, lpos_fim + 1)), 4)
                            If Len(lano) < 4 Then
                                lano = Left(String.Concat("20", lano), 4)
                            End If

                            Me.dt_pedido = String.Concat(ldia, "/", lmes, "/", lano)
                        Else
                            'se não tem barra, data esta errada
                            Me.dt_pedido = String.Empty

                        End If
                    Else
                        'se não tem barra, data esta errada
                        Me.dt_pedido = String.Empty
                    End If

                    'tratar prazo pagto
                    lpos_ini = 1
                    lpos_fim = InStr(lpos_ini, dt_pagto, "/")
                    If lpos_fim > 0 Then 'se achou a barra

                        ldia = Trim(Mid(dt_pagto, lpos_ini, (lpos_fim - lpos_ini)))
                        If Len(ldia) = 1 Then 'se o dia so tem 1 posição
                            ldia = String.Concat("0", ldia)
                        End If

                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, dt_pagto, "/")

                        If lpos_fim > 0 Then
                            lmes = Trim(Mid(dt_pagto, lpos_ini, (lpos_fim - lpos_ini)))
                            If Len(lmes) = 1 Then 'se o mes so tem1 posição
                                lmes = String.Concat("0", lmes)
                            End If

                            lano = Left(Trim(Mid(dt_pagto, lpos_fim + 1)), 4)
                            If Len(lano) < 4 Then
                                lano = Left(String.Concat("20", lano), 4)
                            End If

                            Me.dt_pagto = String.Concat(ldia, "/", lmes, "/", lano)
                        Else
                            'se não tem barra, data esta errada
                            Me.dt_pagto = String.Empty

                        End If
                    Else
                        'se não tem barra, data esta errada
                        Me.dt_pagto = String.Empty
                    End If

                    'pagto fornecedor
                    lpos_ini = 1
                    lpos_fim = InStr(lpos_ini, dt_pagto_fornecedor, "/")
                    If lpos_fim > 0 Then 'se achou a barra

                        ldia = Trim(Mid(dt_pagto_fornecedor, lpos_ini, (lpos_fim - lpos_ini)))
                        If Len(ldia) = 1 Then 'se o dia so tem 1 posição
                            ldia = String.Concat("0", ldia)
                        End If

                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, dt_pagto_fornecedor, "/")

                        If lpos_fim > 0 Then
                            lmes = Trim(Mid(dt_pagto_fornecedor, lpos_ini, (lpos_fim - lpos_ini)))
                            If Len(lmes) = 1 Then 'se o mes so tem1 posição
                                lmes = String.Concat("0", lmes)
                            End If

                            lano = Left(Trim(Mid(dt_pagto_fornecedor, lpos_fim + 1)), 4)
                            If Len(lano) < 4 Then
                                lano = Left(String.Concat("20", lano), 4)
                            End If

                            Me.dt_pagto_fornecedor = String.Concat(ldia, "/", lmes, "/", lano)
                        Else
                            'se não tem barra, data esta errada
                            Me.dt_pagto_fornecedor = String.Empty

                        End If
                    Else
                        'se não tem barra, data esta errada
                        Me.dt_pagto_fornecedor = String.Empty
                    End If

                    'descto produtor
                    lpos_ini = 1
                    lpos_fim = InStr(lpos_ini, dt_desconto_produtor, "/")
                    If lpos_fim > 0 Then 'se achou a barra

                        ldia = Trim(Mid(dt_desconto_produtor, lpos_ini, (lpos_fim - lpos_ini)))
                        If Len(ldia) = 1 Then 'se o dia so tem 1 posição
                            ldia = String.Concat("0", ldia)
                        End If

                        lpos_ini = lpos_fim + 1
                        lpos_fim = InStr(lpos_ini, dt_desconto_produtor, "/")

                        If lpos_fim > 0 Then
                            lmes = Trim(Mid(dt_desconto_produtor, lpos_ini, (lpos_fim - lpos_ini)))
                            If Len(lmes) = 1 Then 'se o mes so tem1 posição
                                lmes = String.Concat("0", lmes)
                            End If

                            lano = Left(Trim(Mid(dt_desconto_produtor, lpos_fim + 1)), 4)
                            If Len(lano) < 4 Then
                                lano = Left(String.Concat("20", lano), 4)
                            End If

                            Me.dt_desconto_produtor = String.Concat(ldia, "/", lmes, "/", lano)
                        Else
                            'se não tem barra, data esta errada
                            Me.dt_desconto_produtor = String.Empty

                        End If
                    Else
                        'se não tem barra, data esta errada
                        Me.dt_desconto_produtor = String.Empty
                    End If


                    '=========================================
                    ' Insere linha importada na importacaon frete
                    '=========================================
                    Me.id_importacao_pedido = Me.insertImportacaoPedidoLinha
                    '=========================================
                    ' Consistencias
                    '=========================================
                    erro = False
                    ImportacaoPedidoErro.id_criacao = Me.id_modificador
                    ImportacaoPedidoErro.id_importacao_pedido = Me.id_importacao_pedido

                    If IsNumeric(ds_valor_total) = False Then

                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "7"
                        importacaolog.cd_erro = "70001"
                        importacaolog.nm_erro = "Valor Total da Nota não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                        ImportacaoPedidoErro.insertImportacaoPedidoErro()
                        erro = True
                        Me.nr_valor_nota = 0

                    Else
                        Me.nr_valor_nota = Convert.ToDecimal(ds_valor_total)
                    End If

                    If IsNumeric(cd_fornecedor) = False Then
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "7"
                        importacaolog.cd_erro = "70002"
                        importacaolog.nm_erro = "Código do Fornecedor não é numérico"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                        ImportacaoPedidoErro.insertImportacaoPedidoErro()

                        erro = True
                        Me.id_fornecedor = 0
                    Else

                        fornecedor.cd_pessoa = cd_fornecedor
                        Dim dsfornecedor As DataSet = fornecedor.getPessoaByFilters()

                        If Not (dsfornecedor.Tables(0).Rows.Count > 0) Then  '  Se o transportador nao existe 

                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "7"
                            importacaolog.cd_erro = "70003"
                            importacaolog.nm_erro = "Código Fornecedor não cadastrado ou não ativo."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                            ImportacaoPedidoErro.insertImportacaoPedidoErro()
                            erro = True

                            Me.id_fornecedor = 0

                        Else
                            If Not (dsfornecedor.Tables(0).Rows(0).Item("id_grupo").ToString = "2") Then
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "7"
                                importacaolog.cd_erro = "70004"
                                importacaolog.nm_erro = "O código informado deve deve ser de um Fornecedor de Insumos."
                                importacaolog.id_importacao = id_importacao

                                id_importacao_log = importacaolog.insertImportacaoLog()

                                ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                                ImportacaoPedidoErro.insertImportacaoPedidoErro()
                                erro = True

                            Else
                                If dsfornecedor.Tables(0).Rows(0).Item("id_situacao").ToString = "2" Then
                                    importacaolog.nr_linha = li
                                    importacaolog.st_importacao = "7"
                                    importacaolog.cd_erro = "70005"
                                    importacaolog.nm_erro = "O fornecedor informado está desativado."
                                    importacaolog.id_importacao = id_importacao

                                    id_importacao_log = importacaolog.insertImportacaoLog()

                                    ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                                    ImportacaoPedidoErro.insertImportacaoPedidoErro()
                                    erro = True
                                End If

                            End If
                            Me.id_fornecedor = dsfornecedor.Tables(0).Rows(0).Item("id_pessoa")

                        End If
                    End If
                    'Consiste datas

                    If IsDate(Me.dt_emissao) = False Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "7"
                        importacaolog.cd_erro = "70009"
                        importacaolog.nm_erro = "Data de emissão inválida."
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                        ImportacaoPedidoErro.insertImportacaoPedidoErro()

                        erro = True
                        Me.dt_emissao = String.Empty

                    End If


                    If IsDate(Me.dt_pagto_fornecedor) = False Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "7"
                        importacaolog.cd_erro = "70015"
                        importacaolog.nm_erro = "Data de Pagamento Fornecedor inválida."
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                        ImportacaoPedidoErro.insertImportacaoPedidoErro()

                        erro = True
                        Me.dt_pagto_fornecedor = String.Empty

                    Else
                        If CDate(Me.dt_pagto_fornecedor) <= CDate(DateTime.Now.ToString("dd/MM/yyyy")) Then
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "7"
                            importacaolog.cd_erro = "70016"
                            importacaolog.nm_erro = "Data de Pagamento ao Fornecedor deve ser maior que a data de hoje."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                            ImportacaoPedidoErro.insertImportacaoPedidoErro()

                            erro = True
                            Me.dt_pagto_fornecedor = String.Empty

                        End If
                    End If

                    If IsDate(Me.dt_desconto_produtor) = False Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "7"
                        importacaolog.cd_erro = "70017"
                        importacaolog.nm_erro = "Data de Desconto ao Produtor é inválida."
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                        ImportacaoPedidoErro.insertImportacaoPedidoErro()

                        erro = True
                        Me.dt_desconto_produtor = String.Empty

                    Else
                        If CDate(Me.dt_desconto_produtor) <= CDate(DateTime.Now.ToString("dd/MM/yyyy")) Then
                            ' Logar
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "7"
                            importacaolog.cd_erro = "70018"
                            importacaolog.nm_erro = "Data de Desconto ao Produtor deve ser maior que a data de hoje."
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                            ImportacaoPedidoErro.insertImportacaoPedidoErro()

                            erro = True
                            Me.dt_desconto_produtor = String.Empty

                        End If
                    End If


                    item.cd_item = Me.cd_item
                    item.id_situacao = 1
                    Dim dsitem As DataSet = item.getItensCentralByFilters()

                    If Not (dsitem.Tables(0).Rows.Count > 0) Then  '   

                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "7"
                        importacaolog.cd_erro = "70019"
                        importacaolog.nm_erro = "Código Item não cadastrado ou não ativo."
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                        ImportacaoPedidoErro.insertImportacaoPedidoErro()
                        erro = True

                        Me.id_item = 0

                    Else
                        If Not (dsitem.Tables(0).Rows(0).Item("st_importacao_pedido").ToString = "S") Then
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "7"
                            importacaolog.cd_erro = "70020"
                            importacaolog.nm_erro = "O código de item informado deve ser ITEM que permite importação de pedido de fomentos."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                            ImportacaoPedidoErro.insertImportacaoPedidoErro()
                            erro = True

                        End If
                        Me.id_item = dsitem.Tables(0).Rows(0).Item("id_item")

                    End If

                    If erro = False Then
                        If id_propriedade > 0 AndAlso nr_unid_producao > 0 Then
                            up.id_propriedade = Me.id_propriedade
                            up.nr_unid_producao = Me.nr_unid_producao
                            up.id_situacao = 1
                            Dim dsup As DataSet = up.getUnidadeProducaoByFilters()

                            If Not (dsup.Tables(0).Rows.Count > 0) Then  '   

                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "7"
                                importacaolog.cd_erro = "70022"
                                importacaolog.nm_erro = "UP não cadastrada ou não ativo."
                                importacaolog.id_importacao = id_importacao

                                id_importacao_log = importacaolog.insertImportacaoLog()

                                ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                                ImportacaoPedidoErro.insertImportacaoPedidoErro()
                                erro = True

                                Me.id_unidproducao = 0
                            Else
                                Me.id_unidproducao = dsup.Tables(0).Rows(0).Item("id_unid_producao")
                            End If
                        Else
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "7"
                            importacaolog.cd_erro = "70023"
                            importacaolog.nm_erro = "UP ou Propriedade não numérico."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()

                            ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                            ImportacaoPedidoErro.insertImportacaoPedidoErro()
                            erro = True
                        End If
                    End If
                    '=========================================
                    ' Atualiza linha importada na importacaon pedido
                    '=========================================
                    Me.updateImportacaoPedido()

                    'verifica a duplicidade da nota
                    If erro = False AndAlso Me.getImportacaoPedidoConsDuplicidade > 0 Then

                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "7"
                        importacaolog.cd_erro = "70021"
                        importacaolog.nm_erro = "O nr nota já existe em pedido cadastrado no sistema, para esta propriedade e fornecedor."
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog()

                        ImportacaoPedidoErro.id_importacao_log = id_importacao_log
                        ImportacaoPedidoErro.insertImportacaoPedidoErro()
                        erro = True

                    End If

                    '=========================================
                    ' Inclui pedido
                    '=========================================
                    If erro = False Then
                        Me.insertImportacaoPedido()

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

