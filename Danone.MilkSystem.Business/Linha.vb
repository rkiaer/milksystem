Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class Linha

    Private _id_Linha As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _id_criacao As Int32
    Private _id_estabelecimento As Int32
    Private _cd_estabelecimento As String
    Private _dt_modificacao As String
    Private _dt_criacao As String
    Private _nm_linha As String
    Private _ds_placa As String
    Private _nm_estabelecimento As String
    Private _nm_arquivo As String
    Private _nr_linhaslidas As Int32
    Private _nr_linhasimportadas As Int32
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _ds_placa_ini As String
    Private _ds_placa_fim As String
    Private _st_tipo_coleta As String
    Private _nr_dias_calculo As Int32 'Fran 29/06/2009 - chamado 286 
    Private _st_periodicidade_coleta As String 'chamado chamado 2474 - 23/08/2016 - Mirella
    Private _st_rota_transbordo As String 'Transit Point - 12/09/2016 - Adri
    Private _st_rota_transit_point As String 'Transit Point - 12/2016 - fran
    Private _st_rota_transvase As String 'Transvase - 07/2022 - fran

    Public Property id_linha() As Int32
        Get
            Return _id_Linha
        End Get
        Set(ByVal value As Int32)
            _id_Linha = value
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

    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
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

    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
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

    Public Property nm_linha() As String
        Get
            Return _nm_linha
        End Get
        Set(ByVal value As String)
            _nm_linha = value
        End Set
    End Property
    Public Property ds_placa() As String
        Get
            Return _ds_placa
        End Get
        Set(ByVal value As String)
            _ds_placa = value
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
    Public Property nr_linhasimportadas() As Int32
        Get
            Return _nr_linhasimportadas
        End Get
        Set(ByVal value As Int32)
            _nr_linhasimportadas = value
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
    Public Property ds_placa_ini() As String
        Get
            Return _ds_placa_ini
        End Get
        Set(ByVal value As String)
            _ds_placa_ini = value
        End Set
    End Property
    Public Property ds_placa_fim() As String
        Get
            Return _ds_placa_fim
        End Get
        Set(ByVal value As String)
            _ds_placa_fim = value
        End Set
    End Property
    Public Property st_tipo_coleta() As String
        Get
            Return _st_tipo_coleta
        End Get
        Set(ByVal value As String)
            _st_tipo_coleta = value
        End Set
    End Property
    Public Property nr_dias_calculo() As Int32
        Get
            Return _nr_dias_calculo
        End Get
        Set(ByVal value As Int32)
            _nr_dias_calculo = value
        End Set
    End Property
    Public Property st_periodicidade_coleta() As String 'chamado chamado 2474 - 23/08/2016 - Mirella i
        Get
            Return _st_periodicidade_coleta
        End Get
        Set(ByVal value As String)
            _st_periodicidade_coleta = value
        End Set
    End Property 'chamado chamado 2474 - 23/08/2016 - Mirella f
    Public Property st_rota_transbordo() As String
        Get
            Return _st_rota_transbordo
        End Get
        Set(ByVal value As String)
            _st_rota_transbordo = value
        End Set
    End Property
    Public Property st_rota_transit_point() As String
        Get
            Return _st_rota_transit_point
        End Get
        Set(ByVal value As String)
            _st_rota_transit_point = value
        End Set
    End Property
    Public Property st_rota_transvase() As String
        Get
            Return _st_rota_transvase
        End Get
        Set(ByVal value As String)
            _st_rota_transvase = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_linha = id
        loadLinha()

    End Sub

    Public Sub New()

    End Sub


    Public Function getLinhaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhas", parameters, "ms_linha")
            Return dataSet

        End Using

    End Function

    Private Sub loadLinha()

        Dim dataSet As DataSet = getLinhaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertLinha() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertLinhas", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateLinha()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateLinhas", parameters, ExecuteType.Update)

        End Using

    End Sub
    ' adri 21/08/2016 - chamado 2474 - Pela importação somente atualiza campos id_importacao e dt_importacao - i
    Public Sub updateLinhaImportacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateLinhasImportacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateLinhaSituacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateLinhasSituacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    ' adri 21/08/2016 - chamado 2474 - Pela importação somente atualiza campos id_importacao e dt_importacao - f

    Public Sub deleteLinha()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteLinhas", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Function exportLinha() As Int32

        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim linhaitens As New LinhaItens
            Dim li As Int32
            Dim li_unidade As Int16
            Dim linhatexto As String
            Dim liexportada As Int32

            Dim ldia As Int16
            Dim lpar_impar As String
            Dim ldt_ini_selvolume As String 'Fran 01/07/2009 i chamado 286
            Dim ldt_fim_selvolume As String 'Fran 01/07/2009 i chamado 286

            ' Campos de saída
            Dim ltipo_operacao As String
            Dim lpropriedade As String
            Dim lnum_pedido As String
            Dim ltipo_emb As String
            Dim lvol_leite_semana As String
            Dim lvol_leite As String
            Dim lclasse As String
            Dim ldata_captacao As String


            Dim data_rota As Date

            data_rota = Convert.ToDateTime(Me.dt_inicio)

            'Fran 01/07/2009 i chamado 286
            'Calcular período para seleção do calculo de média de volume
            'Pega a data de cálculo informada na tela e subtrai da data inicial do periodo informado para geração dos dias da rota
            ldt_ini_selvolume = DateAdd(DateInterval.Day, Convert.ToDouble(Me.nr_dias_calculo * -1), Convert.ToDateTime(Me.dt_inicio)).ToString("dd/MM/yyyy")
            ldt_fim_selvolume = DateAdd(DateInterval.Day, Convert.ToDouble(Me.nr_dias_calculo) - 1, Convert.ToDateTime(ldt_ini_selvolume)).ToString("dd/MM/yyyy 23:59:00")
            Dim romaneiouproducao As New Romaneio_Comp_UProducao
            romaneiouproducao.dt_inicio = ldt_ini_selvolume
            romaneiouproducao.dt_fim = ldt_fim_selvolume
            'Fran 01/07/2009 f chamado 286

            While data_rota <= Convert.ToDateTime(Me.dt_fim)
                ldia = Day(Convert.ToDateTime(data_rota))
                If ldia Mod 2 = 0 Then   ' Se dia Par
                    'Fran 18/12/2008 st_tipo_coleta grava valor 1 para Impar e 2 para Par
                    'lpar_impar = "P"
                    lpar_impar = "2"
                Else
                    'lpar_impar = "I"
                    lpar_impar = "1"
                End If


                ' Busca todas as propriedades que possuem periodicidade 24hs OU (periodicidade 48 hs e tipo coleta Impar/Par)
                Me.st_tipo_coleta = lpar_impar
                Dim dsPropriedadeColetas As DataSet = Me.getLinhaPropriedades()

                For li = 0 To dsPropriedadeColetas.Tables(0).Rows.Count - 1

                    ' Lê as Unidades de Produção da Propriedade
                    Dim unidadeproducao As New UnidadeProducao
                    unidadeproducao.id_propriedade = dsPropriedadeColetas.Tables(0).Rows(li).Item("id_propriedade")
                    unidadeproducao.id_situacao = 1     ' 03/06/2009 Chamado 286 - Somente trazer Unidades de Produção Ativas
                    Dim dsUnidadeProducao As DataSet = unidadeproducao.getUnidadeProducaoByFilters()

                    ' Gera uma linha para cada Unidade de Produção
                    For li_unidade = 0 To dsUnidadeProducao.Tables(0).Rows.Count - 1
                        ltipo_operacao = "E"   ' Fixo

                        lpropriedade = Left(CStr(dsPropriedadeColetas.Tables(0).Rows(li).Item("id_propriedade")) + "-" + CStr(dsUnidadeProducao.Tables(0).Rows(li_unidade).Item("nr_unid_producao")), 8)
                        lpropriedade = Left(lpropriedade + StrDup(8 - Len(lpropriedade), " "), 8)

                        lnum_pedido = CStr(Me.getLinhaSequence())
                        lnum_pedido = Left(StrDup(10 - Len(lnum_pedido), "0") + lnum_pedido, 10)

                        ltipo_emb = "R"
                        'Fran 01/07/2009 i chamado 286 
                        'Volume de leite: soma dos vols entregues num determinado período / pela qtde coletas no mesmo periodo
                        'Fran 18/12/2008 i se volume leite for nulo assume 0
                        'If IsDBNull(dsPropriedadeColetas.Tables(0).Rows(li).Item("nr_vol_leite_dia")) Then
                        '    lvol_leite_semana = 0
                        'Else
                        '    'Fran 18/12/2008 f
                        '    If dsPropriedadeColetas.Tables(0).Rows(li).Item("st_periodicidade_coleta") = "2" Then 'Se periodicidade for 24 hs
                        '        lvol_leite_semana = Round(dsPropriedadeColetas.Tables(0).Rows(li).Item("nr_vol_leite_dia") * 7, 0)
                        '    Else
                        '        lvol_leite_semana = Round(dsPropriedadeColetas.Tables(0).Rows(li).Item("nr_vol_leite_dia") * 4, 0)
                        '    End If
                        'End If
                        romaneiouproducao.id_propriedade = unidadeproducao.id_propriedade
                        romaneiouproducao.nr_unid_producao = dsUnidadeProducao.Tables(0).Rows(li_unidade).Item("nr_unid_producao")
                        lvol_leite_semana = Decimal.Truncate(romaneiouproducao.getRomaneioUProducaoSomaVolumeByPropriedade()).ToString
                        'Fran 01/07/2009 f

                        lvol_leite = Right(CStr(lvol_leite_semana), 9)
                        lvol_leite = Left(StrDup(9 - Len(lvol_leite), "0") + lvol_leite, 9)

                        lclasse = "1"

                        ldata_captacao = Left(Date.Parse(data_rota).ToString("dd/MM/yyyy"), 2) & Mid(Date.Parse(data_rota).ToString("dd/MM/yyyy"), 4, 2) & Right(Date.Parse(data_rota).ToString("dd/MM/yyyy"), 2)

                        linhatexto = ltipo_operacao & lpropriedade & lnum_pedido & ltipo_emb & lvol_leite & lclasse & ldata_captacao

                        ArquivoTexto.WriteLine(linhatexto)

                        liexportada = liexportada + 1

                    Next

                Next

                data_rota = DateAdd(DateInterval.Day, 1, Convert.ToDateTime(data_rota))
            End While


            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liexportada


            ArquivoTexto.Close()

        Catch ex As Exception
            ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    Function importLinha() As Int32
        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Dim arqTemp As StreamReader  ' Adriana 18/05/2010 - chamado 844

        Try

            Dim linhaitens As New LinhaItens
            Dim linhaarquivo As String
            'Dim arqTemp As StreamReader

            Dim nome_linha As String
            Dim cd_placa As String
            Dim li As Int16
            Dim id_linha As Int32
            Dim id_estabelecimento As Int32
            Dim erro As Boolean
            Dim cd_placa_anterior As String

            Dim id_linha_itens As Int32
            Dim dia_impar_par As String
            Dim cd_produtor As String
            Dim id_propriedade As String
            Dim id_unid_producao As String
            Dim nr_dist_prim_produtor As String
            Dim nr_dist_produtores As String
            Dim nr_dist_ult_produtor As String
            Dim nr_seq_coleta As String
            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32

            Dim parameters As List(Of Parameters)

            importacao.st_tipo_importacao = 1
            importacao.dt_inicio_importacao = Now
            importacao.id_estabelecimento = Me.id_estabelecimento
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo

            id_importacao = importacao.insertImportacao()


            arqTemp = File.OpenText(Me.nm_arquivo)

            li = 0
            cd_placa_anterior = ""
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                li = li + 1

                ' Guarda variáveis para ms_linha
                nome_linha = "Rota " & li
                cd_placa = Mid(linhaarquivo, 1, 8)
                id_estabelecimento = Me.id_estabelecimento

                If cd_placa <> cd_placa_anterior Then
                    cd_placa_anterior = cd_placa

                    '=========================================
                    ' Consistencias
                    '=========================================
                    erro = False

                    ' Consiste se placa válida
                    Dim veiculo As New Veiculo
                    veiculo.ds_placa = Trim(cd_placa)
                    If veiculo.validarPlaca = False Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "10001"
                        importacaolog.nm_erro = "Placa não cadastrada"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        erro = True
                    End If

                    If erro = False Then


                        Me.ds_placa = cd_placa
                        '==============================================
                        ' Transação - Get Linha
                        '==============================================
                        'Dim dsLinha As DataSet = Me.getLinhaByFilters()
                        parameters = ParametersEngine.getParametersFromObject(Me)
                        Dim dsLinha As New DataSet
                        transacao.Fill(dsLinha, "ms_getLinhas", parameters, "ms_linha")


                        If (dsLinha.Tables(0).Rows.Count > 0) Then  '  Se a rota  existe para a placa
                            id_linha = dsLinha.Tables(0).Rows(0).Item("id_linha")
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "3"
                            importacaolog.cd_erro = "10007"
                            importacaolog.nm_erro = "Aviso: Esta rota já existe para essa placa"
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()

                            '==============================================
                            ' Transação - Delete Linha Itens
                            '==============================================
                            'linhaitens.deleteLinhaItens()
                            linhaitens.id_linha = id_linha
                            parameters = ParametersEngine.getParametersFromObject(linhaitens)
                            transacao.Execute("ms_deleteLinhasItens", parameters, ExecuteType.Delete)

                        Else
                            ' Gerar as tabelas
                            Me.nm_linha = nome_linha
                            Me.ds_placa = Trim(cd_placa)
                            Me.id_estabelecimento = id_estabelecimento
                            Me.id_criacao = Me.id_criacao
                            Me.id_modificador = Me.id_criacao

                            '==============================================
                            ' Transação - Insert Linha
                            '==============================================
                            'id_linha = Me.insertLinha()
                            'Insere(ms_linha)
                            parameters = ParametersEngine.getParametersFromObject(Me)
                            id_linha = CType(transacao.ExecuteScalar("ms_insertLinhas", parameters, ExecuteType.Insert), Int32)

                        End If

                    End If
                End If

                ' Guarda variáveis para ms_linha_itens
                dia_impar_par = Trim(Mid(linhaarquivo, 9, 10))
                id_propriedade = Trim(Mid(linhaarquivo, 19, 8))
                nr_dist_prim_produtor = Trim(Mid(linhaarquivo, 27, 7))
                nr_dist_produtores = Trim(Mid(linhaarquivo, 34, 7))
                nr_dist_ult_produtor = Trim(Mid(linhaarquivo, 41, 7))
                nr_seq_coleta = Trim(Mid(linhaarquivo, 48, 3))

                '=========================================
                ' Consistencias
                '=========================================
                erro = False

                ' Dia Impar ou Par
                If dia_impar_par = "d1" Then
                    dia_impar_par = "1"
                Else
                    If dia_impar_par = "d2" Then
                        dia_impar_par = "2"
                    Else
                        ' Logar Erro
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "10002"
                        importacaolog.nm_erro = "Erro: Dia incorreto"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()
                        erro = True
                    End If
                End If

                ' Consite Propriedade
                Dim propriedade As New Propriedade
                cd_produtor = ""
                If IsNumeric(id_propriedade) = False Then

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "10008"
                    importacaolog.nm_erro = "Erro: Código da propriedade não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()
                    erro = True
                End If
                If erro = False Then
                    propriedade.id_propriedade = Convert.ToInt32(id_propriedade)
                    Dim dsPropriedade As DataSet = propriedade.getPropriedadeByFilters()

                    If (dsPropriedade.Tables(0).Rows.Count > 0) Then  '  Se a propriedade existe 
                        cd_produtor = dsPropriedade.Tables(0).Rows(0).Item("id_pessoa")
                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "10003"
                        importacaolog.nm_erro = "Erro: Propriedade não cadastrada"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog


                        erro = True
                    End If
                End If

                ' 20/08/2008 - i
                ' Consite Unidade Producao
                id_unid_producao = 0
                Dim unidadeproducao As New UnidadeProducao
                If erro = False Then
                    unidadeproducao.id_propriedade = Convert.ToInt32(id_propriedade)
                    unidadeproducao.nr_unid_producao = 1  ' Assume 1
                    Dim dsUnidadeProducao As DataSet = unidadeproducao.getUnidadeProducaoByFilters()

                    If (dsUnidadeProducao.Tables(0).Rows.Count > 0) Then  '  Se a UP existe 
                        id_unid_producao = dsUnidadeProducao.Tables(0).Rows(0).Item("id_unid_producao")
                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "10010"
                        importacaolog.nm_erro = "Erro: Unidade de Producao não existe para a Propriedade"
                        importacaolog.id_importacao = id_importacao
                        id_importacao_log = importacaolog.insertImportacaoLog
                        erro = True
                    End If
                End If
                ' 20/08/2008 - f

                ' Consiste distâncias
                If IsNumeric(nr_dist_prim_produtor) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "10004"
                    importacaolog.nm_erro = "Erro: Distância não é numérica"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    erro = True
                End If

                If IsNumeric(nr_dist_produtores) = False Then
                    ' Logar

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "10005"
                    importacaolog.nm_erro = "Erro: Distância não é numérica"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    erro = True
                End If

                If IsNumeric(nr_dist_ult_produtor) = False Then
                    ' Logar

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "10005"
                    importacaolog.nm_erro = "Erro: Distância não é numérica"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    erro = True
                End If

                ' Consiste Sequencia
                If IsNumeric(nr_seq_coleta) = False Then
                    ' Logar

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "10006"
                    importacaolog.nm_erro = "Erro: Sequência da coleta não é numérica"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    erro = True
                End If


                If erro = False Then
                    ' Delete das linhas da ms_linha_itens
                    linhaitens.id_linha = id_linha
                    ' 05/08/2008 - O delete neste ponto exclui sempre a última ms_linha_itens incluída
                    ''==============================================
                    '' Transação - Delete Linha Itens
                    ''==============================================
                    ''linhaitens.deleteLinhaItens()
                    'parameters = ParametersEngine.getParametersFromObject(linhaitens)
                    'transacao.Execute("ms_deleteLinhasItens", parameters, ExecuteType.Delete)

                    ' Gerar as tabelas


                    linhaitens.dia_impar_par = dia_impar_par
                    linhaitens.id_propriedade = Convert.ToInt32(id_propriedade)
                    linhaitens.cd_produtor = Convert.ToInt32(cd_produtor)
                    linhaitens.nr_unid_producao = 1  ' 20/08/2008 - Fixo por enquanto
                    linhaitens.id_unid_producao = id_unid_producao
                    linhaitens.nr_dist_prim_produtor = Convert.ToDecimal(Replace(nr_dist_prim_produtor, ".", ","))
                    linhaitens.nr_dist_produtores = Convert.ToDecimal(Replace(nr_dist_produtores, ".", ","))
                    linhaitens.nr_dist_ult_produtor = Convert.ToDecimal(Replace(nr_dist_ult_produtor, ".", ","))
                    linhaitens.nr_seq_coleta = Convert.ToInt32(nr_seq_coleta)

                    '==============================================
                    ' Transação - Insert Linha Itens
                    '==============================================
                    'id_linha_itens = linhaitens.insertLinhaItens()
                    parameters = ParametersEngine.getParametersFromObject(linhaitens)
                    id_linha_itens = CType(transacao.ExecuteScalar("ms_insertLinhasItens", parameters, ExecuteType.Insert), Int32)
                    liimportada = liimportada + 1

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "1"
                    importacaolog.cd_erro = ""
                    importacaolog.nm_erro = ""
                    importacaolog.id_importacao = id_importacao
                    id_importacao_log = importacaolog.insertImportacaoLog


                End If
            Loop
            arqTemp.Close()

            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liimportada

            transacao.Commit()

            Return id_importacao

        Catch ex As Exception
            arqTemp.Close()   ' 18/05/2010 - chamado 844
            transacao.RollBack()
            Throw New Exception(ex.Message)

        End Try

    End Function
    Public Function validarLinha() As Boolean

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhas", parameters, "ms_linha")
            If dataSet.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        End Using


    End Function
    Function importLinha_axiodis() As Int32  ' 19/08/2016 - chamado 2474 - Novo rotina de importação de Rotas AXIODIS


        Dim arqTemp As StreamReader
        arqTemp = File.OpenText(Me.nm_arquivo)

        Try

            Dim linhaitens As New LinhaItens
            Dim linhaatividades As New LinhaAtividades
            Dim linhaarquivo As String
            Dim propriedade As New Propriedade
            Dim unidadeproducao As New UnidadeProducao
            Dim li As Int16
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32
            Dim lpos_ini As Int32
            Dim lpos_fim As Int32
            Dim lpos As Int32
            Dim erro As Boolean
            'Dim dslinha As DataSet
            Dim dsLinha As New DataSet
            Dim cd_rota_anterior As String
            Dim nr_seq_coleta As Int32

            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog
            Dim dsPropriedade As New DataSet
            Dim dsUnidadeProducao As New DataSet

            importacao.st_tipo_importacao = 1
            importacao.dt_inicio_importacao = Now
            importacao.id_estabelecimento = Me.id_estabelecimento
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo

            id_importacao = importacao.insertImportacao()

            ' campos ds ms_linha_itens
            Dim id_propriedade As String
            Dim id_unid_producao As String
            Dim nr_unid_producao As String
            Dim cd_produtor As String

            ' campos da ms_linha_atividades
            Dim atividade As String
            Dim sitio As String
            Dim litros As String
            Dim tecnico As String
            Dim inicio As String
            Dim fim As String
            Dim duracao As String
            Dim tempo As String
            Dim kmtotal As String
            Dim rota As String
            Dim veiculo As String
            Dim kmcumul As String
            Dim coordenaday As String
            Dim coordenadax As String
            Dim descricaositio As String
            Dim descricaolongasitio As String



            li = 0
            cd_rota_anterior = ""
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                li = li + 1

                If li > 1 Then 'Despreza a primeira linha de header

                    id_estabelecimento = Me.id_estabelecimento

                    '==========================================================================================================
                    ' Adri - Lay-out AXIODIS - i
                    '==========================================================================================================
                    ' Atividade
                    lpos_ini = 1
                    atividade = ""
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    If lpos_fim > 0 Then
                        atividade = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' sitio
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    sitio = ""
                    If lpos_fim > 0 Then
                        sitio = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' litros
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    litros = ""
                    If lpos_fim > 0 Then
                        litros = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' tecnico
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    tecnico = ""
                    If lpos_fim > 0 Then
                        tecnico = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' inicio
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    inicio = ""
                    If lpos_fim > 0 Then
                        inicio = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' fim
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    fim = ""
                    If lpos_fim > 0 Then
                        fim = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' duracao
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    duracao = ""
                    If lpos_fim > 0 Then
                        duracao = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' tempo
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    tempo = ""
                    If lpos_fim > 0 Then
                        tempo = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' kmtotal
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    kmtotal = ""
                    If lpos_fim > 0 Then
                        kmtotal = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If


                    ' rota
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    rota = ""
                    If lpos_fim > 0 Then
                        rota = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' veiculo
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    veiculo = ""
                    If lpos_fim > 0 Then
                        veiculo = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' kmcumul
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    kmcumul = ""
                    If lpos_fim > 0 Then
                        kmcumul = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' coordenaday
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    coordenaday = ""
                    If lpos_fim > 0 Then
                        coordenaday = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' coordenadax
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    coordenadax = ""
                    If lpos_fim > 0 Then
                        coordenadax = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' descricaositio
                    lpos_ini = lpos_fim + 1
                    lpos_fim = InStr(lpos_ini, linhaarquivo, ";")
                    descricaositio = ""
                    If lpos_fim > 0 Then
                        descricaositio = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    ' descricaolongasitio
                    lpos_ini = lpos_fim + 1
                    lpos_fim = Len(linhaarquivo) + 1 ' Não tem ; no final
                    descricaolongasitio = ""
                    If lpos_fim > 0 Then
                        descricaolongasitio = Trim(Mid(linhaarquivo, lpos_ini, (lpos_fim - lpos_ini)))
                    End If

                    '=========================================
                    ' Consistencias 
                    '=========================================
                    id_propriedade = ""
                    id_unid_producao = ""
                    nr_unid_producao = ""
                    cd_produtor = ""
                    erro = False
                    'se não há valor informado para o campo obrigatório
                    If UCase(atividade) = "COLETA" Then  ' Só precisa consistir se atividade de coleta

                        If sitio = "" Then  ' Propriedade
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "10000"
                            importacaolog.nm_erro = "Erro: Coluna Sítio Logístico vazia."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        Else
                            ' Propriedade
                            lpos = InStr(1, sitio, "-")
                            If lpos > 0 Then  ' Se encontrou o hifen
                                lpos = lpos - 1
                                id_propriedade = Left(sitio, lpos)
                            End If

                            ' Codigo da Unidade de Producao
                            lpos = InStr(1, sitio, "-")
                            If lpos > 0 Then  ' Se encontrou o hifen
                                lpos = lpos + 1
                                nr_unid_producao = Mid(sitio, lpos, 1)
                            End If

                            If Not IsNumeric(id_propriedade) Then
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                importacaolog.cd_erro = "10005"
                                importacaolog.nm_erro = "Erro: Código da Propriedade não é numérico."
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog
                                erro = True
                            End If
                            If Not IsNumeric(nr_unid_producao) Then
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                importacaolog.cd_erro = "10006"
                                importacaolog.nm_erro = "Erro: Código da UP não é numérico."
                                importacaolog.id_importacao = id_importacao
                                id_importacao_log = importacaolog.insertImportacaoLog
                                erro = True
                            End If

                            If erro = False Then  ' Se a Propriedade e UP são numéricas

                                ' Verifica se Propriedade e UP existem no cadastro de ms_propriedade e ms_unid_producao
                                propriedade.id_propriedade = Convert.ToInt32(id_propriedade)
                                dsPropriedade = propriedade.getPropriedadeByFilters()
                                If (dsPropriedade.Tables(0).Rows.Count > 0) Then  '  Se a propriedade existe 
                                    cd_produtor = dsPropriedade.Tables(0).Rows(0).Item("id_pessoa").ToString

                                    id_unid_producao = 0
                                    unidadeproducao.id_propriedade = Convert.ToInt32(id_propriedade)
                                    unidadeproducao.nr_unid_producao = Convert.ToInt32(nr_unid_producao)
                                    dsUnidadeProducao = unidadeproducao.getUnidadeProducaoByFilters()
                                    If (dsUnidadeProducao.Tables(0).Rows.Count > 0) Then  '  Se a UP existe 
                                        id_unid_producao = dsUnidadeProducao.Tables(0).Rows(0).Item("id_unid_producao")
                                    Else
                                        importacaolog.nr_linha = li
                                        importacaolog.st_importacao = "2"
                                        importacaolog.cd_erro = "10010"
                                        importacaolog.nm_erro = "Erro: Unidade de Producao não existe para a Propriedade"
                                        importacaolog.id_importacao = id_importacao
                                        id_importacao_log = importacaolog.insertImportacaoLog
                                        erro = True
                                    End If

                                Else
                                    importacaolog.nr_linha = li
                                    importacaolog.st_importacao = "2"
                                    importacaolog.cd_erro = "10004"
                                    importacaolog.nm_erro = "Erro: Propriedade não cadastrada."
                                    importacaolog.id_importacao = id_importacao
                                    id_importacao_log = importacaolog.insertImportacaoLog
                                    erro = True
                                End If
                            End If

                        End If

                        If kmtotal = "" Then
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "10001"
                            importacaolog.nm_erro = "Erro: Coluna KM TOTAL vazia."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        End If

                        If rota = "" Then
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "2"
                            importacaolog.cd_erro = "10002"
                            importacaolog.nm_erro = "Erro: Coluna Rota vazia."
                            importacaolog.id_importacao = id_importacao

                            id_importacao_log = importacaolog.insertImportacaoLog()
                            erro = True
                        Else

                            If Len(rota) < 4 Then
                                importacaolog.nr_linha = li
                                importacaolog.st_importacao = "2"
                                importacaolog.cd_erro = "10003"
                                importacaolog.nm_erro = "Erro: O conteúdo da coluna Rota deve ter no mínimo 4 posições."
                                importacaolog.id_importacao = id_importacao

                                id_importacao_log = importacaolog.insertImportacaoLog()
                                erro = True
                            End If
                        End If
                    End If  ' Fim se atividade <> "coleta"

                    If erro = False Then  ' Gerar as tabelas

                        '================
                        ' Tabela ms_linha
                        '================
                        'If Left(rota, 4) <> cd_rota_anterior Then 'fran 30/11/2016 nao precisa left
                        If rota <> cd_rota_anterior Then

                            ' Atualiza a Rota anterior para situacao 1-Ativo, para o coletor passar a enxergar a rota completa
                            If Me.id_linha <> 0 Then  ' Se não é a primeira rota
                                Me.updateLinhaSituacao()  ' atualiza campo id_situacao para 1-Ativo (não permitir que a aplicação altere este status, somente a importacao)
                            End If

                            'cd_rota_anterior = Left(rota, 4) 'fran 30/11/2016 nao precisa left
                            cd_rota_anterior = rota
                            nr_seq_coleta = 0 ' zera a sequencia toda vez que trocar a placa

                            'Me.nm_linha = Left(rota, 4) 'fran 30/11/2016 nao precisa left
                            Me.nm_linha = rota
                            Me.ds_placa = "XXXXXXX"  ' Assume uma placa qualquer porque não é mais utilizada
                            Me.id_estabelecimento = id_estabelecimento
                            Me.id_modificador = Me.id_criacao

                            dsLinha = Me.getLinhaByNome()
                            'parameters = ParametersEngine.getParametersFromObject(Me)
                            'transacao.Fill(dsLinha, "ms_getLinhaByNome", parameters, "ms_linha")

                            If dsLinha.Tables(0).Rows.Count() > 0 Then  'Se a Rota já existe no cadastro e está ativa

                                Me.id_linha = dsLinha.Tables(0).Rows(0).Item("id_linha")

                                Me.updateLinhaImportacao()  ' atualiza os campos id_importacao e dt_importacao na ms_linha
                                'parameters = ParametersEngine.getParametersFromObject(Me)
                                'transacao.Execute("ms_updateLinhasImportacao", parameters, ExecuteType.Update)  ' atualiza os campos id_importacao e dt_importacao na ms_linha

                                linhaitens.id_linha = id_linha
                                linhaitens.deleteLinhaItens()
                                'parameters = ParametersEngine.getParametersFromObject(linhaitens)
                                'transacao.Execute("ms_deleteLinhasItens", parameters, ExecuteType.Delete)

                                linhaatividades.id_linha = id_linha
                                linhaatividades.deleteLinhaAtividades()
                                'parameters = ParametersEngine.getParametersFromObject(linhaatividades)
                                'transacao.Execute("ms_deleteLinhasAtividades", parameters, ExecuteType.Delete)

                            Else
                                Me.id_linha = Me.insertLinha()
                                'parameters = ParametersEngine.getParametersFromObject(Me)
                                'Me.id_linha = CType(transacao.ExecuteScalar("ms_insertLinhas", parameters, ExecuteType.Insert), Int32)
                            End If
                        End If

                        If UCase(atividade) = "COLETA" Then
                            '======================
                            ' Tabela ms_linha_itens
                            '======================
                            nr_seq_coleta = nr_seq_coleta + 1
                            linhaitens.id_linha = Me.id_linha
                            linhaitens.dia_impar_par = "1" ' Assume sempre 1
                            linhaitens.dt_rota = Now
                            linhaitens.id_propriedade = Convert.ToInt32(id_propriedade)
                            linhaitens.cd_produtor = Convert.ToInt32(cd_produtor)
                            linhaitens.nr_unid_producao = Convert.ToInt32(nr_unid_producao)
                            linhaitens.id_unid_producao = Convert.ToInt32(id_unid_producao)
                            linhaitens.nr_dist_prim_produtor = "0"
                            linhaitens.nr_dist_produtores = "0"
                            linhaitens.nr_dist_ult_produtor = "0"
                            linhaitens.nr_seq_coleta = Convert.ToInt32(nr_seq_coleta)
                            linhaitens.id_linhaitens = linhaitens.insertLinhaItens
                            'parameters = ParametersEngine.getParametersFromObject(linhaitens)
                            'linhaitens.id_linhaitens = CType(transacao.ExecuteScalar("ms_insertLinhasItens", parameters, ExecuteType.Insert), Int32)

                        End If
                    End If  ' Fim Se erro = False

                    '===========================
                    ' Tabela ms_linha_atividades
                    '===========================
                    linhaatividades.id_linha = Me.id_linha
                    linhaatividades.atividade = atividade
                    linhaatividades.sitio = sitio
                    linhaatividades.litros = litros
                    linhaatividades.tecnico = tecnico
                    linhaatividades.inicio = inicio
                    linhaatividades.fim = fim
                    linhaatividades.duracao = duracao
                    linhaatividades.tempo = tempo
                    linhaatividades.kmtotal = kmtotal
                    linhaatividades.rota = rota
                    linhaatividades.veiculo = veiculo
                    linhaatividades.kmcumul = kmcumul
                    linhaatividades.coordenaday = coordenaday
                    linhaatividades.coordenadax = coordenadax
                    linhaatividades.descricaositio = descricaositio
                    linhaatividades.descricaolongasitio = descricaolongasitio
                    linhaatividades.id_Linhaatividades = linhaatividades.insertLinhaAtividades()
                    'parameters = ParametersEngine.getParametersFromObject(linhaatividades)
                    'linhaatividades.id_Linhaatividades = CType(transacao.ExecuteScalar("ms_insertLinhasAtividades", parameters, ExecuteType.Insert), Int32)

                    liimportada = liimportada + 1

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "1"
                    importacaolog.cd_erro = ""
                    importacaolog.nm_erro = ""
                    importacaolog.id_importacao = id_importacao
                    id_importacao_log = importacaolog.insertImportacaoLog

                End If  ' Fim Se 'Despreza a primeira linha de header

            Loop

            ' Atualiza a Rota anterior para situacao 1-Ativo, para o coletor passar a enxergar a rota completa
            If Me.id_linha <> 0 Then  ' Atualiza a ULTIMA rota tratada
                Me.updateLinhaSituacao()  ' atualiza campo id_situacao para 1-Ativo (não permitir que a aplicação altere este status, somente a importacao)
            End If

            arqTemp.Close()

            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            Me.nr_linhaslidas = li - 1  ' Tira 1 linha do cabeçalho
            Me.nr_linhasimportadas = liimportada

            ' Exclui o arquivo do servidor
            Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(Me.nm_arquivo)
            If Arquivo.Exists Then
                Arquivo.Delete()
            End If

            Return id_importacao


        Catch ex As Exception
            Throw New Exception(ex.Message)

        Finally
            arqTemp.Close()
        End Try



    End Function

    Function importLinha_novo() As Int32

        Dim transacao As New DataAccess

        Dim arqTemp As StreamReader
        arqTemp = File.OpenText(Me.nm_arquivo)

        transacao.StartTransaction()

        Try

            Dim linhaitens As New LinhaItens
            Dim linhaarquivo As String

            Dim nome_linha As String
            Dim cd_placa As String
            Dim li As Int16
            Dim id_linha As Int32
            Dim id_estabelecimento As Int32
            Dim erro As Boolean
            Dim cd_placa_anterior As String

            Dim id_linha_itens As Int32
            Dim dia_impar_par As String
            Dim ldia As Int16
            Dim dt_rota As String
            Dim cd_produtor As String
            Dim id_propriedade As String
            Dim id_propriedade_up As String
            Dim nr_unid_producao As String
            Dim id_unid_producao As String
            Dim nr_dist_prim_produtor As String
            Dim nr_dist_produtores As String
            Dim nr_dist_ult_produtor As String
            Dim nr_seq_coleta As String
            Dim id_importacao_log As Int32
            Dim liimportada As Int16
            Dim id_importacao As Int32
            Dim lpos_ini As Int16
            Dim lpos_fim As Int16

            Dim importacao As New Importacao
            Dim importacaolog As New ImportacaoLog

            Dim parameters As List(Of Parameters)

            importacao.st_tipo_importacao = 1
            importacao.dt_inicio_importacao = Now
            importacao.id_estabelecimento = Me.id_estabelecimento
            importacao.id_criacao = Me.id_criacao
            importacao.nm_arquivo = Me.nm_arquivo

            id_importacao = importacao.insertImportacao()



            li = 0
            cd_placa_anterior = ""
            Do While Not arqTemp.EndOfStream
                linhaarquivo = arqTemp.ReadLine
                li = li + 1

                'id_linha = 0        ' 10/11/2008 Não pode deixar aqui, pois para a mesma placa o id_linha não é reapurado (Se a placa não existe no cadastro, estava inserindo com último id_linha)

                ' Guarda variáveis para ms_linha
                nome_linha = "Rota " & li
                cd_placa = Mid(linhaarquivo, 1, 8)
                id_estabelecimento = Me.id_estabelecimento

                If cd_placa <> cd_placa_anterior Then
                    cd_placa_anterior = cd_placa

                    '=========================================
                    ' Consistencias
                    '=========================================
                    erro = False

                    ' Consiste se placa válida
                    Dim veiculo As New Veiculo
                    veiculo.ds_placa = Trim(cd_placa)
                    If veiculo.validarPlaca = False Then
                        ' Logar
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "10001"
                        importacaolog.nm_erro = "Placa não cadastrada"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog()

                        erro = True
                    End If

                    If erro = False Then


                        Me.ds_placa = cd_placa
                        'Me.id_situacao = 1  ' Verifica se linha Ativa  ' 28/10/2008
                        '==============================================
                        ' Transação - Get Linha
                        '==============================================
                        'Dim dsLinha As DataSet = Me.getLinhaByFilters()
                        parameters = ParametersEngine.getParametersFromObject(Me)
                        Dim dsLinha As New DataSet
                        'transacao.Fill(dsLinha, "ms_getLinhas", parameters, "ms_linha")
                        transacao.Fill(dsLinha, "ms_getLinhaByPlaca", parameters, "ms_linha")  ' 28/10/2008  (só pode existir uma única vez a placa no cadastro de rotas)


                        If (dsLinha.Tables(0).Rows.Count > 0) Then  '  Se a rota  existe para a placa
                            id_linha = dsLinha.Tables(0).Rows(0).Item("id_linha")
                            importacaolog.nr_linha = li
                            importacaolog.st_importacao = "3"
                            importacaolog.cd_erro = "10007"
                            importacaolog.nm_erro = "Aviso: Esta rota já existe para essa placa"
                            importacaolog.id_importacao = id_importacao
                            id_importacao_log = importacaolog.insertImportacaoLog()

                            '==============================================
                            ' Transação - Delete Linha Itens
                            '==============================================
                            'linhaitens.deleteLinhaItens()
                            linhaitens.id_linha = id_linha
                            parameters = ParametersEngine.getParametersFromObject(linhaitens)
                            transacao.Execute("ms_deleteLinhasItens", parameters, ExecuteType.Delete)

                        Else
                            ' Gerar as tabelas
                            Me.nm_linha = nome_linha
                            Me.ds_placa = Trim(cd_placa)
                            Me.id_estabelecimento = id_estabelecimento
                            Me.id_criacao = Me.id_criacao
                            Me.id_modificador = Me.id_criacao

                            '==============================================
                            ' Transação - Insert Linha
                            '==============================================
                            'id_linha = Me.insertLinha()
                            'Insere(ms_linha)
                            parameters = ParametersEngine.getParametersFromObject(Me)
                            id_linha = CType(transacao.ExecuteScalar("ms_insertLinhas", parameters, ExecuteType.Insert), Int32)

                        End If

                    End If
                End If

                ' Guarda variáveis para ms_linha_itens
                '20/08/2008 - i 
                'dia_impar_par = Trim(Mid(linhaarquivo, 9, 10))  ' Não precisa mais
                id_propriedade_up = Trim(Mid(linhaarquivo, 19, 8))
                ' Codigo da Propriedade
                lpos_ini = 1
                lpos_fim = InStr(1, id_propriedade_up, "-")
                id_propriedade = "0"
                If lpos_fim > 0 Then
                    id_propriedade = Mid(id_propriedade_up, 1, (lpos_fim - lpos_ini))
                End If

                ' Codigo da Unidade de Producao
                nr_unid_producao = "0"
                If lpos_fim < 8 Then
                    lpos_ini = lpos_fim + 1
                    nr_unid_producao = Mid(id_propriedade_up, lpos_ini, 8 - lpos_fim)
                End If

                dt_rota = Trim(Mid(linhaarquivo, 27, 2)) + "/" + Trim(Mid(linhaarquivo, 29, 2)) + "/20" + Trim(Mid(linhaarquivo, 31, 2))
                dia_impar_par = ""
                If IsDate(dt_rota) = True Then  'Se é uma data válida
                    ldia = Day(Convert.ToDateTime(dt_rota))
                    If ldia Mod 2 = 0 Then   ' Se dia Par
                        dia_impar_par = "2"
                    Else
                        dia_impar_par = "1"
                    End If
                Else
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "10010"
                    importacaolog.nm_erro = "Erro: A data da rota não é uma data válida."
                    importacaolog.id_importacao = id_importacao
                    id_importacao_log = importacaolog.insertImportacaoLog
                    erro = True
                End If

                '20/08/2008 - f
                nr_dist_prim_produtor = Trim(Mid(linhaarquivo, 33, 7))
                nr_dist_produtores = Trim(Mid(linhaarquivo, 40, 7))
                nr_dist_ult_produtor = Trim(Mid(linhaarquivo, 47, 7))
                nr_seq_coleta = Trim(Mid(linhaarquivo, 54, 3))

                '=========================================
                ' Consistencias
                '=========================================
                'erro = False   ' 01/11/2008

                ' Dia Impar ou Par
                'If dia_impar_par = "d1" Then
                '    dia_impar_par = "1"
                'Else
                '    If dia_impar_par = "d2" Then
                '        dia_impar_par = "2"
                '    Else
                '        ' Logar Erro
                '        importacaolog.nr_linha = li
                '        importacaolog.st_importacao = "2"
                '        importacaolog.cd_erro = "10002"
                '        importacaolog.nm_erro = "Erro: Dia incorreto"
                '        importacaolog.id_importacao = id_importacao

                '        id_importacao_log = importacaolog.insertImportacaoLog()
                '        erro = True
                '    End If
                'End If


                ' Consite Propriedade
                Dim propriedade As New Propriedade
                cd_produtor = ""
                If IsNumeric(id_propriedade) = False Then

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "10008"
                    importacaolog.nm_erro = "Erro: Código da propriedade não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()
                    erro = True
                End If
                If erro = False Then
                    'propriedade.id_estabelecimento = id_estabelecimento
                    propriedade.id_propriedade = Convert.ToInt32(id_propriedade)
                    'Dim dsPropriedade As DataSet = propriedade.getPropriedadeByFilters()
                    Dim dsPropriedade As New DataSet
                    parameters = ParametersEngine.getParametersFromObject(propriedade)
                    transacao.Fill(dsPropriedade, "ms_getPropriedade", parameters, "ms_propriedade")

                    If (dsPropriedade.Tables(0).Rows.Count > 0) Then  '  Se a propriedade existe 
                        cd_produtor = dsPropriedade.Tables(0).Rows(0).Item("id_pessoa")
                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "10003"
                        importacaolog.nm_erro = "Erro: Propriedade não cadastrada."
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog


                        erro = True
                    End If
                End If

                ' 20/08/2008
                ' Consite Unidade Producao
                id_unid_producao = 0
                Dim unidadeproducao As New UnidadeProducao
                If IsNumeric(nr_unid_producao) = False Then

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "10009"
                    importacaolog.nm_erro = "Erro: Código da Unidade de Producao não é numérico"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()
                    erro = True
                End If
                If erro = False Then
                    unidadeproducao.id_propriedade = Convert.ToInt32(id_propriedade)
                    unidadeproducao.nr_unid_producao = Convert.ToInt32(nr_unid_producao)
                    ' 01/09/2008 (estava travando quando a mesma unidade de producao aparecia mais de uma vez no arquivo - dia par e dia impar)
                    'Dim dsUnidadeProducao As DataSet = unidadeproducao.getUnidadeProducaoByFilters()

                    Dim dsUnidadeProducao As New DataSet
                    parameters = ParametersEngine.getParametersFromObject(unidadeproducao)
                    transacao.Fill(dsUnidadeProducao, "ms_getunidadesproducao", parameters, "ms_unidade_producao")

                    If (dsUnidadeProducao.Tables(0).Rows.Count > 0) Then  '  Se a UP existe 
                        id_unid_producao = dsUnidadeProducao.Tables(0).Rows(0).Item("id_unid_producao")
                    Else
                        importacaolog.nr_linha = li
                        importacaolog.st_importacao = "2"
                        importacaolog.cd_erro = "10010"
                        importacaolog.nm_erro = "Erro: Unidade de Producao não existe para a Propriedade"
                        importacaolog.id_importacao = id_importacao

                        id_importacao_log = importacaolog.insertImportacaoLog


                        erro = True
                    End If
                End If


                ' Consiste distâncias
                If IsNumeric(nr_dist_prim_produtor) = False Then

                    ' Logar
                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "10004"
                    importacaolog.nm_erro = "Erro: Distância não é numérica"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    erro = True
                End If

                If IsNumeric(nr_dist_produtores) = False Then
                    ' Logar

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "10005"
                    importacaolog.nm_erro = "Erro: Distância não é numérica"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    erro = True
                End If

                If IsNumeric(nr_dist_ult_produtor) = False Then
                    ' Logar

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "10005"
                    importacaolog.nm_erro = "Erro: Distância não é numérica"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    erro = True
                End If

                ' Consiste Sequencia
                If IsNumeric(nr_seq_coleta) = False Then
                    ' Logar

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "2"
                    importacaolog.cd_erro = "10006"
                    importacaolog.nm_erro = "Erro: Sequência da coleta não é numérica"
                    importacaolog.id_importacao = id_importacao

                    id_importacao_log = importacaolog.insertImportacaoLog()

                    erro = True
                End If


                If erro = False Then
                    ' Delete das linhas da ms_linha_itens
                    linhaitens.id_linha = id_linha
                    ' 05/08/2008 - O delete neste ponto exclui sempre a última ms_linha_itens incluída
                    ''==============================================
                    '' Transação - Delete Linha Itens
                    ''==============================================
                    ''linhaitens.deleteLinhaItens()
                    'parameters = ParametersEngine.getParametersFromObject(linhaitens)
                    'transacao.Execute("ms_deleteLinhasItens", parameters, ExecuteType.Delete)

                    ' Gerar as tabelas

                    linhaitens.dia_impar_par = dia_impar_par
                    linhaitens.dt_rota = dt_rota
                    linhaitens.id_propriedade = Convert.ToInt32(id_propriedade)
                    linhaitens.cd_produtor = Convert.ToInt32(cd_produtor)
                    linhaitens.nr_unid_producao = Convert.ToInt32(nr_unid_producao)
                    linhaitens.id_unid_producao = Convert.ToInt32(id_unid_producao)
                    linhaitens.nr_dist_prim_produtor = Convert.ToDecimal(Replace(nr_dist_prim_produtor, ".", ","))
                    linhaitens.nr_dist_produtores = Convert.ToDecimal(Replace(nr_dist_produtores, ".", ","))
                    linhaitens.nr_dist_ult_produtor = Convert.ToDecimal(Replace(nr_dist_ult_produtor, ".", ","))
                    linhaitens.nr_seq_coleta = Convert.ToInt32(nr_seq_coleta)

                    '==============================================
                    ' Transação - Insert Linha Itens
                    '==============================================
                    'id_linha_itens = linhaitens.insertLinhaItens()
                    parameters = ParametersEngine.getParametersFromObject(linhaitens)
                    id_linha_itens = CType(transacao.ExecuteScalar("ms_insertLinhasItens", parameters, ExecuteType.Insert), Int32)

                    ' Atualiza a rota na propriedade (20/08/2008)
                    propriedade.id_propriedade = Convert.ToInt32(id_propriedade)
                    ' 10/09/2008 - Nova alteração em Roteirização - i
                    'propriedade.id_linha = Convert.ToInt32(id_linha)
                    If dia_impar_par = "1" Then  ' Se rota do dia Impar
                        propriedade.id_linha_impar = Convert.ToInt32(id_linha)
                    Else
                        propriedade.id_linha_par = Convert.ToInt32(id_linha)
                    End If
                    ' 10/09/2008 - Nova alteração em Roteirização - f
                    parameters = ParametersEngine.getParametersFromObject(propriedade)
                    transacao.Execute("ms_updatePropriedadeRota", parameters, ExecuteType.Update)

                    liimportada = liimportada + 1

                    importacaolog.nr_linha = li
                    importacaolog.st_importacao = "1"
                    importacaolog.cd_erro = ""
                    importacaolog.nm_erro = ""
                    importacaolog.id_importacao = id_importacao
                    id_importacao_log = importacaolog.insertImportacaoLog


                End If
            Loop
            arqTemp.Close()

            importacao.dt_termino_importacao = Now
            importacao.updateImportacao()

            Me.nr_linhaslidas = li
            Me.nr_linhasimportadas = liimportada

            transacao.Commit()

            Return id_importacao


        Catch ex As Exception
            transacao.RollBack()
            Throw New Exception(ex.Message)

        Finally
            arqTemp.Close()

        End Try

    End Function
    Public Function getLinhaSequence() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getLinhaSequence", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Function getLinhaPropriedades() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhaPropriedades", parameters, "ms_propriedade")
            Return dataSet

        End Using

    End Function

    ' adri 19/08/2016 - chamado 2474 - Importação de Rotas AXIODIS -i
    Public Function getLinhaByNome() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhaByNome", parameters, "ms_linha")
            Return dataSet

        End Using

    End Function

    ' adri 19/08/2016 - chamado 2474 - Importação de Rotas AXIODIS - 
    ' fran 14/09/2016 i
    Public Function getLinhaByTransbordo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhaByTransbordo", parameters, "ms_linha")
            Return dataSet

        End Using

    End Function
    Public Function getLinhaByTransitPoint() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhaByTransitPoint", parameters, "ms_linha")
            Return dataSet

        End Using

    End Function
    Public Function getLinhaByTransvase() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhaByTransvase", parameters, "ms_linha")
            Return dataSet

        End Using

    End Function

End Class
