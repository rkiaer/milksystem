Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math


<Serializable()> Public Class MapaLeite

    Private _id_mapa_leite As Int32
    Private _dt_referencia As String
    Private _id_pessoa As Int32
    Private _id_propriedade As Int32
    Private _id_unid_producao As Int32
    Private _nr_dia As String
    Private _nr_volume As Decimal
    Private _st_leite As String
    Private _id_romaneio As Int32
    Private _id_estabelecimento As Int32
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _nr_linhaslidas As Int32
    Private _nr_linhasexportadas As Int32
    Private _nm_arquivo As String
    ' 07/04/2009 - Rls17.3 - i
    'Private _id_linha_ini As Int32
    'Private _id_linha_fim As Int32
    Private _nm_linha_ini As String
    Private _nm_linha_fim As String
    ' 07/04/2009 - Rls17.3 - f
    Private _imprime_semmovto As Boolean
    ' Dados para o Mapa
    Private _ds_municipio_prod As String
    Private _nm_transportador As String
    Private _cd_insc_transportador As String
    Private _cd_produtor(10) As String
    Private _nm_produtor(10) As String
    Private _cd_insc_produtor(10) As String
    Private _cd_propriedade(10) As String
    Private _linhatexto As String
    'Private _nr_volume_dia(10, 37) As Int32
    'Private _nr_volume_dia_formatado(10, 37) As String
    Private _id_estado As Int32
    Private _nm_cidade As String
    Private _id_grupo As Int32
    Private _st_limite_incentivo As String
    Private _ds_placa As String

    Public Property id_mapa_leite() As Int32
        Get
            Return _id_mapa_leite
        End Get
        Set(ByVal value As Int32)
            _id_mapa_leite = value
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
    Public Property id_unid_producao() As Int32
        Get
            Return _id_unid_producao
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao = value
        End Set
    End Property
    Public Property nr_dia() As String
        Get
            Return _nr_dia
        End Get
        Set(ByVal value As String)
            _nr_dia = value
        End Set
    End Property
    Public Property st_limite_incentivo() As String
        Get
            Return _st_limite_incentivo
        End Get
        Set(ByVal value As String)
            _st_limite_incentivo = value
        End Set
    End Property
    Public Property nr_volume() As Decimal
        Get
            Return _nr_volume
        End Get
        Set(ByVal value As Decimal)
            _nr_volume = value
        End Set
    End Property
    Public Property st_leite() As String
        Get
            Return _st_leite
        End Get
        Set(ByVal value As String)
            _st_leite = value
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
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property id_pessoa() As Int32 'fran extranet 03/2016
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
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
    Public Property nm_linha_ini() As String
        Get
            Return _nm_linha_ini
        End Get
        Set(ByVal value As String)
            _nm_linha_ini = value
        End Set
    End Property
    Public Property nm_linha_fim() As String
        Get
            Return _nm_linha_fim
        End Get
        Set(ByVal value As String)
            _nm_linha_fim = value
        End Set
    End Property
    Public Property imprime_semmovto() As Boolean
        Get
            Return _imprime_semmovto
        End Get
        Set(ByVal value As Boolean)
            _imprime_semmovto = value
        End Set
    End Property
    Public Property nm_produtor() As String()
        Get
            Return _nm_produtor
        End Get
        Set(ByVal value As String())
            _nm_produtor = value
        End Set
    End Property
    Public Property cd_produtor() As String()
        Get
            Return _cd_produtor
        End Get
        Set(ByVal value As String())
            _cd_produtor = value
        End Set
    End Property
    Public Property cd_propriedade() As String()
        Get
            Return _cd_propriedade
        End Get
        Set(ByVal value As String())
            _cd_propriedade = value
        End Set
    End Property
    Public Property cd_insc_produtor() As String()
        Get
            Return _cd_insc_produtor
        End Get
        Set(ByVal value As String())
            _cd_insc_produtor = value
        End Set
    End Property
    Public Property ds_municipio_prod() As String
        Get
            Return _ds_municipio_prod
        End Get
        Set(ByVal value As String)
            _ds_municipio_prod = value
        End Set
    End Property
    Public Property nm_transportador() As String
        Get
            Return _nm_transportador
        End Get
        Set(ByVal value As String)
            _nm_transportador = value
        End Set
    End Property
    Public Property cd_insc_transportador() As String
        Get
            Return _cd_insc_transportador
        End Get
        Set(ByVal value As String)
            _cd_insc_transportador = value
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
    Public Property id_estado() As Int32
        Get
            Return _id_estado
        End Get
        Set(ByVal value As Int32)
            _id_estado = value
        End Set
    End Property
    Public Property nm_cidade() As String
        Get
            Return _nm_cidade
        End Get
        Set(ByVal value As String)
            _nm_cidade = value
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
    Public Property ds_placa() As String
        Get
            Return _ds_placa
        End Get
        Set(ByVal value As String)
            _ds_placa = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_mapa_leite = id
        loadMapaLeite()

    End Sub

    Public Sub New()

    End Sub

    Public Function getMapaLeiteReferencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMapaLeiteReferencia", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    Public Function getMapaLeiteByFilters() As DataSet 'fran 19/03/2016 i extranet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMapaLeite", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    Public Function getMapaLeiteNotaFiscalProdutor() As DataSet
        ' Adri - 16/01/2009 - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMapaLeiteNotaFiscalProdutor", parameters, "ms_mapa_leite")
            Return dataSet

        End Using
        ' Adri - 16/01/2009 - f

    End Function
    Public Function getMapaLeiteEstoque() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMapaLeiteEstoque", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    Public Function getMapaLeiteEstoqueMensal() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMapaLeiteEstoqueMensal", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    Public Function getMapaLeiteEstoqueTotalCentavos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMapaLeiteEstoqueTotalCentavos", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function


    Private Sub loadMapaLeite()

        Dim dataSet As DataSet = getMapaLeiteByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Sub exportEstoque()

        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim li As Int32
            Dim linhatexto As String
            Dim liexportada As Int32
            Dim lpos As Int16

            Dim cd_item As String
            Dim cd_deposito As String
            Dim cd_unidade_medida As String
            Dim nr_volume As String
            Dim nr_volume_int As String
            Dim nr_volume_dec As String

            Dim estabelecimento As New Estabelecimento(Me.id_estabelecimento)

            Dim dsMapaLeite As DataSet = Me.getMapaLeiteEstoque()

            For li = 0 To dsMapaLeite.Tables(0).Rows.Count - 1

                linhatexto = ""

                Dim item As New Item(dsMapaLeite.Tables(0).Rows(li).Item("id_item"))  ' 24/10/2008

                cd_item = item.cd_item
                cd_item = Left(cd_item + StrDup(16 - Len(cd_item), " "), 16)
                linhatexto = linhatexto + cd_item

                linhatexto = linhatexto + Left(estabelecimento.cd_estabelecimento, 3)

                'Dim item As New Item(dsMapaLeite.Tables(0).Rows(li).Item("id_item"))
                cd_deposito = Left(item.cd_deposito, 3)
                cd_deposito = Left(cd_deposito + StrDup(3 - Len(cd_deposito), " "), 3)
                linhatexto = linhatexto + cd_deposito

                linhatexto = linhatexto + Space(10)
                linhatexto = linhatexto + Space(10)
                linhatexto = linhatexto + "12/31/2999"
                linhatexto = linhatexto + Space(10)
                linhatexto = linhatexto + StrDup(11, "0")
                linhatexto = linhatexto + "1990102500000000"
                linhatexto = linhatexto + Space(5)
                linhatexto = linhatexto + Space(16)
                linhatexto = linhatexto + "01"

                nr_volume = CStr(Round(dsMapaLeite.Tables(0).Rows(li).Item("nr_volume"), 4))
                lpos = InStr(1, nr_volume, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    nr_volume = CStr(nr_volume)
                    nr_volume = Left(StrDup(10 - Len(nr_volume), "0") + nr_volume, 10)
                    nr_volume = nr_volume & "0000"
                Else
                    nr_volume_int = CStr(Left(nr_volume, lpos - 1))  ' Pegar somente o valor inteiro
                    nr_volume_int = Left(StrDup(10 - Len(nr_volume_int), "0") + nr_volume_int, 10)
                    nr_volume_dec = CStr(Mid(CStr(nr_volume), lpos + 1))  ' Pegar somente o valor decimal
                    nr_volume_dec = Left(nr_volume_dec + StrDup(4 - Len(nr_volume_dec), "0"), 4)
                    nr_volume = nr_volume_int & nr_volume_dec
                End If
                linhatexto = linhatexto + nr_volume     ' Qtde da caderneta

                cd_unidade_medida = Left(item.cd_unidade_medida, 2)
                cd_unidade_medida = Left(cd_unidade_medida + StrDup(2 - Len(cd_unidade_medida), " "), 2)
                linhatexto = linhatexto + cd_unidade_medida

                linhatexto = linhatexto + "00000000000001"

                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + "1140400300000000"
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + StrDup(9, "0")
                linhatexto = linhatexto + DateTime.Parse(dsMapaLeite.Tables(0).Rows(li).Item("dt_movimento").ToString).ToString("MM/dd/yyyy")

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
    Public Sub exportEstoqueMensal()

        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim li As Int32
            Dim linhatexto As String
            Dim liexportada As Int32
            Dim lpos As Int16

            Dim cd_item As String
            Dim cd_deposito As String
            Dim cd_unidade_medida As String
            Dim nr_volume As String
            Dim nr_volume_int As String
            Dim nr_volume_dec As String
            Dim nr_total_centavos As String     ' 28/11/2008

            Dim estabelecimento As New Estabelecimento(Me.id_estabelecimento)

            Dim dsMapaLeite As DataSet = Me.getMapaLeiteEstoqueMensal()

            For li = 0 To dsMapaLeite.Tables(0).Rows.Count - 1

                linhatexto = ""

                Dim item As New Item(dsMapaLeite.Tables(0).Rows(li).Item("id_item"))  ' 29/10/2008

                'cd_item = dsMapaLeite.Tables(0).Rows(li).Item("id_item")   ' 29/10/2008
                cd_item = item.cd_item
                cd_item = Left(cd_item + StrDup(16 - Len(cd_item), " "), 16)
                linhatexto = linhatexto + cd_item

                linhatexto = linhatexto + Left(estabelecimento.cd_estabelecimento, 3)

                'Dim item As New Item(dsMapaLeite.Tables(0).Rows(li).Item("id_item"))
                cd_deposito = Left(item.cd_deposito, 3)
                cd_deposito = Left(cd_deposito + StrDup(3 - Len(cd_deposito), " "), 3)
                linhatexto = linhatexto + cd_deposito

                linhatexto = linhatexto + Space(10)
                linhatexto = linhatexto + Space(10)
                linhatexto = linhatexto + "12/31/2999"   ' 29/10/2008
                linhatexto = linhatexto + Space(10)
                linhatexto = linhatexto + StrDup(11, "0")
                linhatexto = linhatexto + "1990102500000000"
                linhatexto = linhatexto + Space(5)
                linhatexto = linhatexto + Space(16)
                'linhatexto = linhatexto + "01"
                linhatexto = linhatexto + "02"  ' 05/11/2008 - Tipo Transação 02 - Saída

                nr_volume = CStr(Round(dsMapaLeite.Tables(0).Rows(li).Item("nr_volume"), 4))
                lpos = InStr(1, nr_volume, ",", 1)
                If lpos = 0 Then   ' Se não tem casas decimais
                    nr_volume = CStr(nr_volume)
                    nr_volume = Left(StrDup(10 - Len(nr_volume), "0") + nr_volume, 10)
                    nr_volume = nr_volume & "0000"
                Else
                    nr_volume_int = CStr(Left(nr_volume, lpos - 1))  ' Pegar somente o valor inteiro
                    'nr_volume_int = Left(StrDup(9 - Len(nr_volume_int), "0") + nr_volume_int, 9)
                    nr_volume_int = Left(StrDup(10 - Len(nr_volume_int), "0") + nr_volume_int, 10)  ' 12/11/2008
                    nr_volume_dec = CStr(Mid(CStr(nr_volume), lpos + 1))  ' Pegar somente o valor decimal
                    nr_volume_dec = Left(nr_volume_dec + StrDup(4 - Len(nr_volume_dec), "0"), 4)
                    nr_volume = nr_volume_int & nr_volume_dec
                End If
                'linhatexto = linhatexto + "-" + nr_volume     ' Somatório do período só dos Produtores (negativo para zerar o estoque)
                linhatexto = linhatexto + nr_volume     ' 05/11/2008 (semo sinal de negativo) - Somatório do período só dos Produtores (negativo para zerar o estoque)

                cd_unidade_medida = Left(item.cd_unidade_medida, 2)
                cd_unidade_medida = Left(cd_unidade_medida + StrDup(2 - Len(cd_unidade_medida), " "), 2)
                linhatexto = linhatexto + cd_unidade_medida

                ' 28/11/2008 Campo 15 - Total de centavos enviados no estoque diário (1 centavo para cada data moviemnto do período) - i
                'linhatexto = linhatexto + "00000000000001"
                Dim dsMapaLeiteTotalCentavos As DataSet = Me.getMapaLeiteEstoqueTotalCentavos()
                nr_total_centavos = CStr(dsMapaLeiteTotalCentavos.Tables(0).Rows.Count)
                nr_total_centavos = Left(StrDup(14 - Len(nr_total_centavos), "0") + nr_total_centavos, 14)
                linhatexto = linhatexto + nr_total_centavos
                ' 28/11/2008 Campo 15 - Total de centavos enviados no estoque diário (1 centavo para cada data moviemnto do período) - f

                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + StrDup(14, "0")
                linhatexto = linhatexto + Space(8)
                linhatexto = linhatexto + "1140400300000000"
                linhatexto = linhatexto + "N"
                linhatexto = linhatexto + StrDup(9, "0")
                linhatexto = linhatexto + DateTime.Parse(Me.dt_fim.ToString).ToString("MM/dd/yyyy")  ' 05/11/2008 - Último dia do período escolhido
                'linhatexto = linhatexto + Space(10)

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

    Public Function exportMapaLeite() As Boolean

        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try

            Dim li As Int32
            Dim liexportada As Int32

            Dim nr_volume_dia(10, 37) As Int64  ' Fran 15/02/2012 chamado 1496 
            Dim nr_volume_dia_formatado(10, 37) As String
            Dim nr_volume As Int64 'fran 15/07/2012 i


            Dim li_dia As Int16
            Dim id_propriedade_anterior As Int32
            Dim nr_dia As Int16
            Dim nr_produtor As Int16

            ' 21112008 - i
            Dim id_transportador As Int32
            Dim id_cidade As Int32
            Dim id_transportador_anterior As Int32
            Dim id_cidade_anterior As Int32
            ' 21112008 - f


            Dim dsMapaLeite As DataSet = Me.getMapaLeiteByFilters()


            ' Formata Campos do Relatorio
            Me.linhatexto = ""
            ds_municipio_prod = ""
            nm_transportador = ""
            cd_insc_transportador = ""
            nr_produtor = 1
            For nr_produtor = 0 To 10
                cd_produtor(nr_produtor) = Space(15)
                nm_produtor(nr_produtor) = Space(30)
                cd_insc_produtor(nr_produtor) = Space(20)
                cd_propriedade(nr_produtor) = Space(10)
                For li_dia = 1 To 37
                    Select Case li_dia
                        Case 32, 33, 34
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Space(9)
                        Case 35
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Space(9)
                        Case 36
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Space(5)
                        Case 37
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Space(4)
                        Case Else
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Space(6)
                    End Select
                Next
            Next

            ' 21112008 - i
            id_transportador = 0
            id_cidade = 0
            id_transportador_anterior = 0
            id_cidade_anterior = 0
            ' 21112008 - f

            nr_produtor = 1

            ' 21112008 - i
            If dsMapaLeite.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("id_transportador")) Then
                    id_transportador_anterior = dsMapaLeite.Tables(0).Rows(li).Item("id_transportador")
                End If
                If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("id_cidade")) Then
                    id_cidade_anterior = dsMapaLeite.Tables(0).Rows(li).Item("id_cidade")
                End If

            End If
            ' 21112008 - f

            For li = 0 To dsMapaLeite.Tables(0).Rows.Count - 1

                ' 21112008 - i
                If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("id_transportador")) Then
                    id_transportador = dsMapaLeite.Tables(0).Rows(li).Item("id_transportador")
                Else
                    id_transportador = 0
                End If
                If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("id_cidade")) Then
                    id_cidade = dsMapaLeite.Tables(0).Rows(li).Item("id_cidade")
                Else
                    id_cidade = 0
                End If
                ' 21112008 - f

                ' 21112008 - l
                'If nr_produtor > 9  Then
                If nr_produtor > 9 Or id_transportador <> id_transportador_anterior Or id_cidade <> id_cidade_anterior Then


                    ' 21112008 - i
                    id_transportador_anterior = id_transportador
                    id_cidade_anterior = id_cidade
                    ' 21112008 - f

                    geraMapa(nr_volume_dia_formatado)

                    ArquivoTexto.WriteLine(linhatexto)  ' 07/04/2009 - Rls17.3 (só gerava o último mapa)

                    ' 19/09/2008 - i
                    nr_produtor = 1
                    ' Formata Campos do Relatorio
                    Me.linhatexto = ""
                    ds_municipio_prod = ""
                    nm_transportador = ""
                    cd_insc_transportador = ""
                    nr_produtor = 1
                    For nr_produtor = 0 To 10
                        cd_produtor(nr_produtor) = Space(15)
                        nm_produtor(nr_produtor) = Space(30)
                        cd_insc_produtor(nr_produtor) = Space(20)
                        cd_propriedade(nr_produtor) = Space(10)
                        For li_dia = 1 To 37
                            Select Case li_dia
                                Case 32, 33, 34
                                    nr_volume_dia_formatado(nr_produtor, li_dia) = Space(9)
                                Case 35
                                    nr_volume_dia_formatado(nr_produtor, li_dia) = Space(9)
                                Case 36
                                    nr_volume_dia_formatado(nr_produtor, li_dia) = Space(5)
                                Case 37
                                    nr_volume_dia_formatado(nr_produtor, li_dia) = Space(4)
                                Case Else
                                    nr_volume_dia_formatado(nr_produtor, li_dia) = Space(6)
                            End Select
                            'Fran 10/12/2008 i - Zera o somatorio da pagina
                            nr_volume_dia(10, li_dia) = 0
                            'Fran 10/12/2008 f
                        Next
                    Next
                    nr_produtor = 1   ' 21112008

                    'Exit For
                End If
                '===============================================================
                ' Cabeçalho - Formata Dados do Produtor (Município)
                '===============================================================

                ds_municipio_prod = dsMapaLeite.Tables(0).Rows(li).Item("nm_cidade")
                ds_municipio_prod = Left(ds_municipio_prod + StrDup(34 - Len(ds_municipio_prod), " "), 34)

                '===============================================================
                ' Cabeçalho - Formata Dados do Transportador
                '===============================================================
                nm_transportador = Left(dsMapaLeite.Tables(0).Rows(li).Item("nm_transportador"), 36)  ' 16/01/2009
                nm_transportador = Left(nm_transportador + StrDup(36 - Len(nm_transportador), " "), 36)

                'cd_insc_transportador = dsMapaLeite.Tables(0).Rows(li).Item("cd_insc_transportador")
                ' 07/04/2009 - Rls17.3 - i
                'cd_insc_transportador = CStr(dsMapaLeite.Tables(0).Rows(li).Item("id_linha"))
                cd_insc_transportador = Left(CStr(dsMapaLeite.Tables(0).Rows(li).Item("nm_linha")), 20)
                ' 07/04/2009 - Rls17.3 - f
                cd_insc_transportador = Left(cd_insc_transportador + StrDup(20 - Len(cd_insc_transportador), " "), 20)

                '===============================================================
                ' Linhas - Formata Dados do Produtor e Propriedade
                '===============================================================
                cd_produtor(nr_produtor) = dsMapaLeite.Tables(0).Rows(li).Item("cd_pessoa")
                cd_produtor(nr_produtor) = Left(cd_produtor(nr_produtor) + StrDup(15 - Len(cd_produtor(nr_produtor)), " "), 15)

                nm_produtor(nr_produtor) = Left(dsMapaLeite.Tables(0).Rows(li).Item("nm_pessoa"), 30)   ' 30/10/2008
                nm_produtor(nr_produtor) = Left(nm_produtor(nr_produtor) + StrDup(30 - Len(nm_produtor(nr_produtor)), " "), 30)

                cd_insc_produtor(nr_produtor) = dsMapaLeite.Tables(0).Rows(li).Item("cd_inscricao_estadual")
                cd_insc_produtor(nr_produtor) = Left(cd_insc_produtor(nr_produtor) + StrDup(20 - Len(cd_insc_produtor(nr_produtor)), " "), 20)

                cd_propriedade(nr_produtor) = CStr(dsMapaLeite.Tables(0).Rows(li).Item("id_propriedade"))
                cd_propriedade(nr_produtor) = Left(cd_propriedade(nr_produtor) + StrDup(10 - Len(cd_propriedade(nr_produtor)), " "), 10)


                '===============================================================
                ' Linhas - Formata Volumes
                '===============================================================

                ' Formata volumes
                For li_dia = 1 To 37
                    nr_volume_dia(nr_produtor, li_dia) = 0
                    Select Case li_dia
                        Case 32, 33, 34  ' Total 1.aq, 2.a Q e Mes - Tamnho de 9 alinhados à direita
                            nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 0)
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Left(StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, li_dia)), " ") + nr_volume_dia_formatado(nr_produtor, li_dia), 9)
                        Case 35  ' Cota - Tamnho de 9 alinhado à esquerda
                            nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 0)
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Left(nr_volume_dia_formatado(nr_produtor, li_dia) + StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, li_dia)), " "), 9)
                        Case 36  ' Extra Cota - Tamnho de 5 Brancos
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Space(5)
                        Case 37  ' Teor de Gordura - Tamnho 4 alinhado à direita
                            nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 1)
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Left(StrDup(4 - Len(nr_volume_dia_formatado(nr_produtor, li_dia)), " ") + nr_volume_dia_formatado(nr_produtor, li_dia), 4)
                        Case Else ' Dia 01 a 31 - Tamnho de 6 alinhados à direita
                            nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 0)
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(nr_produtor, li_dia)), " ") + nr_volume_dia_formatado(nr_produtor, li_dia), 6)
                    End Select

                Next

                li_dia = li
                id_propriedade_anterior = dsMapaLeite.Tables(0).Rows(li).Item("id_propriedade")
                'For li_dia = 0 To dsMapaLeite.Tables(0).Rows.Count - 1   ' Le os dias da Propriedade
                For li_dia = li To dsMapaLeite.Tables(0).Rows.Count - 1   ' 19/09/2008 - Le os dias da Propriedade
                    If dsMapaLeite.Tables(0).Rows(li_dia).Item("id_propriedade") = id_propriedade_anterior Then

                        nr_dia = dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia")
                        nr_volume_dia(nr_produtor, nr_dia) = dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_volume")
                        nr_volume_dia(10, nr_dia) = nr_volume_dia(10, nr_dia) + nr_volume_dia(nr_produtor, nr_dia)  ' Totalizador 10 (dia)

                        nr_volume_dia_formatado(nr_produtor, nr_dia) = FormatNumber(dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_volume"), 0)
                        If Len(nr_volume_dia_formatado(nr_produtor, nr_dia)) > 6 Then  ' Fran 15/02/2012 chamado 1496 
                            nr_volume_dia_formatado(nr_produtor, nr_dia) = Left(Mid(nr_volume_dia_formatado(nr_produtor, nr_dia), 1, 3) + Mid(nr_volume_dia_formatado(nr_produtor, nr_dia), 5, 3), 6)
                        End If
                        If Len(nr_volume_dia_formatado(nr_produtor, nr_dia)) > 6 Then   ' Fran 15/02/2012 chamado 1496 
                            nr_volume_dia_formatado(nr_produtor, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(nr_produtor, nr_dia)), " ") + nr_volume_dia_formatado(nr_produtor, nr_dia), 6)
                        End If

                        nr_volume_dia_formatado(nr_produtor, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(nr_produtor, nr_dia)), " ") + nr_volume_dia_formatado(nr_produtor, nr_dia), 6)

                        ' 20081124 - i
                        nr_volume_dia_formatado(10, nr_dia) = FormatNumber(nr_volume_dia(10, nr_dia), 0)
                        If Len(nr_volume_dia_formatado(10, nr_dia)) > 6 Then    ' Fran 15/02/2012 chamado 1496 
                            nr_volume_dia_formatado(10, nr_dia) = Left(Mid(nr_volume_dia_formatado(10, nr_dia), 1, 3) + Mid(nr_volume_dia_formatado(10, nr_dia), 5, 3), 6)
                        End If
                        If Len(nr_volume_dia_formatado(10, nr_dia)) > 6 Then    ' Fran 15/02/2012 chamado 1496 
                            nr_volume_dia_formatado(10, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(10, nr_dia)), " ") + nr_volume_dia_formatado(10, nr_dia), 6)
                        End If
                        nr_volume_dia_formatado(10, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(10, nr_dia)), " ") + nr_volume_dia_formatado(10, nr_dia), 6)
                        ' 20081124 - f

                        If dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia") <= 15 Then
                            nr_volume_dia(nr_produtor, 32) = nr_volume_dia(nr_produtor, 32) + nr_volume_dia(nr_produtor, dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia"))   ' Volume do Mes
                            nr_volume_dia(10, 32) = nr_volume_dia(10, 32) + nr_volume_dia(nr_produtor, 32) ' Totalizador 10 (1.a Q)
                        Else
                            nr_volume_dia(nr_produtor, 33) = nr_volume_dia(nr_produtor, 33) + nr_volume_dia(nr_produtor, dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia"))   ' Volume do Mes
                            nr_volume_dia(10, 33) = nr_volume_dia(10, 33) + nr_volume_dia(nr_produtor, 33) ' Totalizador 10 (2.a Q)
                        End If
                        nr_volume_dia(nr_produtor, 34) = nr_volume_dia(nr_produtor, 34) + nr_volume_dia(nr_produtor, dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia"))   ' Volume do Mes
                        nr_volume_dia(10, 34) = nr_volume_dia(10, 34) + nr_volume_dia(nr_produtor, 34) ' Totalizador 10 (Mes)
                    Else
                        Exit For
                    End If
                Next

                'Formata Total 1.a Quinzena
                nr_volume_dia_formatado(nr_produtor, 32) = Right(FormatNumber(nr_volume_dia(nr_produtor, 32), 0), 9)
                nr_volume_dia_formatado(nr_produtor, 32) = Left(StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, 32)), " ") + nr_volume_dia_formatado(nr_produtor, 32), 9)

                ' 20081124 - i
                'nr_volume_dia_formatado(10, 32) = Left(StrDup(9 - Len(nr_volume_dia_formatado(10, 32)), " ") + nr_volume_dia_formatado(10, 32), 9)
                nr_volume_dia_formatado(10, 32) = Right(FormatNumber(nr_volume_dia(10, 32), 0), 9)
                nr_volume_dia_formatado(10, 32) = Left(StrDup(9 - Len(nr_volume_dia_formatado(10, 32)), " ") + nr_volume_dia_formatado(10, 32), 9)
                ' 20081124 - f

                'Formata Total 2.a Quinzena
                nr_volume_dia_formatado(nr_produtor, 33) = Right(FormatNumber(nr_volume_dia(nr_produtor, 33), 0), 9)
                nr_volume_dia_formatado(nr_produtor, 33) = Left(StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, 33)), " ") + nr_volume_dia_formatado(nr_produtor, 33), 9)
                nr_volume_dia_formatado(10, 33) = Right(FormatNumber(nr_volume_dia(10, 33), 0), 9)
                nr_volume_dia_formatado(10, 33) = Left(StrDup(9 - Len(nr_volume_dia_formatado(10, 33)), " ") + nr_volume_dia_formatado(10, 33), 9)

                'Formata Total Mes
                nr_volume_dia_formatado(nr_produtor, 34) = Right(FormatNumber(nr_volume_dia(nr_produtor, 34), 0), 9)
                nr_volume_dia_formatado(nr_produtor, 34) = Left(StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, 34)), " ") + nr_volume_dia_formatado(nr_produtor, 34), 9)
                nr_volume_dia_formatado(10, 34) = Right(FormatNumber(nr_volume_dia(10, 34), 0), 9)
                nr_volume_dia_formatado(10, 34) = Left(StrDup(9 - Len(nr_volume_dia_formatado(10, 34)), " ") + nr_volume_dia_formatado(10, 34), 9)

                'Formata Cota igual ao valor do Mes
                nr_volume_dia_formatado(nr_produtor, 35) = Right(FormatNumber(nr_volume_dia(nr_produtor, 34), 0), 9)
                nr_volume_dia_formatado(nr_produtor, 35) = Left(nr_volume_dia_formatado(nr_produtor, 35) + StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, 35)), " "), 9)
                nr_volume_dia_formatado(10, 35) = Right(FormatNumber(nr_volume_dia(10, 35), 0), 9)
                nr_volume_dia_formatado(10, 35) = Left(nr_volume_dia_formatado(10, 35) + StrDup(9 - Len(nr_volume_dia_formatado(10, 35)), " "), 9)

                nr_produtor = nr_produtor + 1  ' Quantidade de Produtor/Propriedade por página 

                li = li_dia - 1     ' 19/09/2008
            Next

            If nr_produtor <= 10 Then
                geraMapa(nr_volume_dia_formatado)
            End If

            ArquivoTexto.WriteLine(linhatexto)

            liexportada = liexportada + 1

            Me.nr_linhaslidas = li
            Me.nr_linhasexportadas = liexportada


            ArquivoTexto.Close()

            exportMapaLeite = True

        Catch ex As Exception
            exportMapaLeite = False
            ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    Private Sub geraMapa(ByVal nr_volume_dia_formatado(,) As String)


        Try
            Dim i As Int16

            Dim ds_endereco_dan As String
            Dim ds_municipio_dan As String
            Dim ds_inscricao_dan As String
            Dim ds_cnpj_dan As String
            Dim nr_mapa_leite As String
            Dim nr_mes As String
            Dim nr_ano As String
            Dim nr_produtor As Int16

            '===============================================================
            ' Formata Dados do Estabelecimento
            '===============================================================
            Dim estabelecimento As New Estabelecimento(Me.id_estabelecimento)


            ds_endereco_dan = estabelecimento.ds_endereco + ", " + CStr(estabelecimento.nr_endereco)
            ds_endereco_dan = Left(ds_endereco_dan + StrDup(55 - Len(ds_endereco_dan), " "), 55)

            ds_municipio_dan = estabelecimento.nm_cidade
            ds_municipio_dan = Left(ds_municipio_dan + StrDup(30 - Len(ds_municipio_dan), " "), 30)

            ds_inscricao_dan = estabelecimento.cd_inscricao_estadual
            ds_inscricao_dan = Left(ds_inscricao_dan + StrDup(30 - Len(ds_inscricao_dan), " "), 30)

            ds_cnpj_dan = estabelecimento.cd_cnpj
            ds_cnpj_dan = Left(ds_cnpj_dan + StrDup(18 - Len(ds_cnpj_dan), " "), 18)

            nr_mapa_leite = FormatNumber(estabelecimento.getEstabelecimentoNumeroMapa, 0)  ' Próximo Número
            nr_mapa_leite = Left(nr_mapa_leite + StrDup(9 - Len(nr_mapa_leite), " "), 9)

            nr_mes = DateTime.Parse(Me.dt_referencia).ToString("MM")
            nr_ano = DateTime.Parse(Me.dt_referencia).ToString("yyyy")

            For i = 1 To 2
                'Fran 12/03/2009 i rls17 - Estas linhas estão desabilitadas no esre0027rp.p (fonte)
                'linhatexto = linhatexto + Chr(27) + "&l0O" + Chr(27) + "&l26A" + Chr(27) + "&l1H" + Chr(27) + "&a0P" + Chr(27) + "&f59Y" + Chr(27) + "&n7W" + Chr(5) + "LEITE1" + Chr(27) + "&f2xS" + Chr(27) + "&u300D"
                'linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p8v4s3b4148T"
                'Fran 12/03/2009 f rls17

                If i = 1 Then
                    linhatexto = linhatexto + Chr(27) + "&l0O" + Chr(27) + "&l26A" + Chr(27) + "&l8H" + Chr(27) + "&a0P" + Chr(27) + "&f59Y" + Chr(27) + "&n7W" + Chr(5) + "LEITE1" + Chr(27) + "&f2xS" + Chr(27) + "&u300D"
                    linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p8v4s3b4148T"
                    linhatexto = linhatexto + Chr(27) + "*p2188x155Y" + "1a VIA - EMITENTE"
                Else
                    linhatexto = linhatexto + Chr(27) + "&l0O" + Chr(27) + "&l26A" + Chr(27) + "&l1H" + Chr(27) + "&a0P" + Chr(27) + "&f59Y" + Chr(27) + "&n7W" + Chr(5) + "LEITE1" + Chr(27) + "&f2xS" + Chr(27) + "&u300D"
                    linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p8v4s3b4148T"
                    linhatexto = linhatexto + Chr(27) + "*p2188x155Y" + "2a VIA - CONTROLE"
                End If

                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p6v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p210x212Y" + ds_endereco_dan
                linhatexto = linhatexto + Chr(27) + "*p1400x212Y" + ds_municipio_dan
                linhatexto = linhatexto + Chr(27) + "*p210x252Y" + ds_inscricao_dan
                linhatexto = linhatexto + Chr(27) + "*p1400x252Y" + ds_cnpj_dan

                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p7v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p2000x202Y" + nr_mapa_leite
                linhatexto = linhatexto + Chr(27) + "*p1890x280Y" + ds_municipio_prod
                linhatexto = linhatexto + Chr(27) + "*p1950x322Y" + nr_mes
                linhatexto = linhatexto + Chr(27) + "*p2280x322Y" + nr_ano

                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p6v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p300x330Y" + nm_transportador
                linhatexto = linhatexto + Chr(27) + "*p1560x330Y" + cd_insc_transportador

                '===============================================================
                ' LINHA 1*
                '===============================================================
                nr_produtor = 1
                linhatexto = linhatexto + Chr(27) + "*p100x412Y" + nm_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1170x412Y" + cd_insc_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1800x412Y" + cd_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p2270x412Y" + cd_propriedade(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"

                linhatexto = linhatexto + Chr(27) + "*p75x510Y" + nr_volume_dia_formatado(nr_produtor, 1)
                linhatexto = linhatexto + Chr(27) + "*p180x510Y" + nr_volume_dia_formatado(nr_produtor, 2)
                linhatexto = linhatexto + Chr(27) + "*p285x510Y" + nr_volume_dia_formatado(nr_produtor, 3)
                linhatexto = linhatexto + Chr(27) + "*p390x510Y" + nr_volume_dia_formatado(nr_produtor, 4)
                linhatexto = linhatexto + Chr(27) + "*p495x510Y" + nr_volume_dia_formatado(nr_produtor, 5)
                linhatexto = linhatexto + Chr(27) + "*p605x510Y" + nr_volume_dia_formatado(nr_produtor, 6)
                linhatexto = linhatexto + Chr(27) + "*p710x510Y" + nr_volume_dia_formatado(nr_produtor, 7)
                linhatexto = linhatexto + Chr(27) + "*p815x510Y" + nr_volume_dia_formatado(nr_produtor, 8)
                linhatexto = linhatexto + Chr(27) + "*p920x510Y" + nr_volume_dia_formatado(nr_produtor, 9)
                linhatexto = linhatexto + Chr(27) + "*p1025x510Y" + nr_volume_dia_formatado(nr_produtor, 10)
                linhatexto = linhatexto + Chr(27) + "*p1135x510Y" + nr_volume_dia_formatado(nr_produtor, 11)
                linhatexto = linhatexto + Chr(27) + "*p1245x510Y" + nr_volume_dia_formatado(nr_produtor, 12)
                linhatexto = linhatexto + Chr(27) + "*p1345x510Y" + nr_volume_dia_formatado(nr_produtor, 13)
                linhatexto = linhatexto + Chr(27) + "*p1450x510Y" + nr_volume_dia_formatado(nr_produtor, 14)
                linhatexto = linhatexto + Chr(27) + "*p1560x510Y" + nr_volume_dia_formatado(nr_produtor, 15)
                linhatexto = linhatexto + Chr(27) + "*p75x615Y" + nr_volume_dia_formatado(nr_produtor, 16)
                linhatexto = linhatexto + Chr(27) + "*p180x615Y" + nr_volume_dia_formatado(nr_produtor, 17)
                linhatexto = linhatexto + Chr(27) + "*p285x615Y" + nr_volume_dia_formatado(nr_produtor, 18)
                linhatexto = linhatexto + Chr(27) + "*p390x615Y" + nr_volume_dia_formatado(nr_produtor, 19)
                linhatexto = linhatexto + Chr(27) + "*p495x615Y" + nr_volume_dia_formatado(nr_produtor, 20)
                linhatexto = linhatexto + Chr(27) + "*p605x615Y" + nr_volume_dia_formatado(nr_produtor, 21)
                linhatexto = linhatexto + Chr(27) + "*p710x615Y" + nr_volume_dia_formatado(nr_produtor, 22)
                linhatexto = linhatexto + Chr(27) + "*p815x615Y" + nr_volume_dia_formatado(nr_produtor, 23)
                linhatexto = linhatexto + Chr(27) + "*p920x615Y" + nr_volume_dia_formatado(nr_produtor, 24)
                linhatexto = linhatexto + Chr(27) + "*p1025x615Y" + nr_volume_dia_formatado(nr_produtor, 25)
                linhatexto = linhatexto + Chr(27) + "*p1135x615Y" + nr_volume_dia_formatado(nr_produtor, 26)
                linhatexto = linhatexto + Chr(27) + "*p1245x615Y" + nr_volume_dia_formatado(nr_produtor, 27)
                linhatexto = linhatexto + Chr(27) + "*p1345x615Y" + nr_volume_dia_formatado(nr_produtor, 28)
                linhatexto = linhatexto + Chr(27) + "*p1450x615Y" + nr_volume_dia_formatado(nr_produtor, 29)
                linhatexto = linhatexto + Chr(27) + "*p1560x615Y" + nr_volume_dia_formatado(nr_produtor, 30)
                linhatexto = linhatexto + Chr(27) + "*p1665x615Y" + nr_volume_dia_formatado(nr_produtor, 31)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p6v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p1780x510Y" + nr_volume_dia_formatado(nr_produtor, 32)
                linhatexto = linhatexto + Chr(27) + "*p1780x615Y" + nr_volume_dia_formatado(nr_produtor, 33)
                linhatexto = linhatexto + Chr(27) + "*p1920x615Y" + nr_volume_dia_formatado(nr_produtor, 34)
                linhatexto = linhatexto + Chr(27) + "*p2060x615Y" + nr_volume_dia_formatado(nr_produtor, 35)
                linhatexto = linhatexto + Chr(27) + "*p2180x615Y" + nr_volume_dia_formatado(nr_produtor, 36)
                linhatexto = linhatexto + Chr(27) + "*p2320x615Y" + nr_volume_dia_formatado(nr_produtor, 37)

                '/* LINHA 2*/
                nr_produtor = 2
                linhatexto = linhatexto + Chr(27) + "*p100x705Y" + nm_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1170x705Y" + cd_insc_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1800x705Y" + cd_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p2270x705Y" + cd_propriedade(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"
                linhatexto = linhatexto + Chr(27) + "*p75x803Y" + nr_volume_dia_formatado(nr_produtor, 1)
                linhatexto = linhatexto + Chr(27) + "*p180x803Y" + nr_volume_dia_formatado(nr_produtor, 2)
                linhatexto = linhatexto + Chr(27) + "*p285x803Y" + nr_volume_dia_formatado(nr_produtor, 3)
                linhatexto = linhatexto + Chr(27) + "*p390x803Y" + nr_volume_dia_formatado(nr_produtor, 4)
                linhatexto = linhatexto + Chr(27) + "*p495x803Y" + nr_volume_dia_formatado(nr_produtor, 5)
                linhatexto = linhatexto + Chr(27) + "*p605x803Y" + nr_volume_dia_formatado(nr_produtor, 6)
                linhatexto = linhatexto + Chr(27) + "*p710x803Y" + nr_volume_dia_formatado(nr_produtor, 7)
                linhatexto = linhatexto + Chr(27) + "*p815x803Y" + nr_volume_dia_formatado(nr_produtor, 8)
                linhatexto = linhatexto + Chr(27) + "*p920x803Y" + nr_volume_dia_formatado(nr_produtor, 9)
                linhatexto = linhatexto + Chr(27) + "*p1025x803Y" + nr_volume_dia_formatado(nr_produtor, 10)
                linhatexto = linhatexto + Chr(27) + "*p1135x803Y" + nr_volume_dia_formatado(nr_produtor, 11)
                linhatexto = linhatexto + Chr(27) + "*p1245x803Y" + nr_volume_dia_formatado(nr_produtor, 12)
                linhatexto = linhatexto + Chr(27) + "*p1345x803Y" + nr_volume_dia_formatado(nr_produtor, 13)
                linhatexto = linhatexto + Chr(27) + "*p1450x803Y" + nr_volume_dia_formatado(nr_produtor, 14)
                linhatexto = linhatexto + Chr(27) + "*p1560x803Y" + nr_volume_dia_formatado(nr_produtor, 15)
                linhatexto = linhatexto + Chr(27) + "*p75x908Y" + nr_volume_dia_formatado(nr_produtor, 16)
                linhatexto = linhatexto + Chr(27) + "*p180x908Y" + nr_volume_dia_formatado(nr_produtor, 17)
                linhatexto = linhatexto + Chr(27) + "*p285x908Y" + nr_volume_dia_formatado(nr_produtor, 18)
                linhatexto = linhatexto + Chr(27) + "*p390x908Y" + nr_volume_dia_formatado(nr_produtor, 19)
                linhatexto = linhatexto + Chr(27) + "*p495x908Y" + nr_volume_dia_formatado(nr_produtor, 20)
                linhatexto = linhatexto + Chr(27) + "*p605x908Y" + nr_volume_dia_formatado(nr_produtor, 21)
                linhatexto = linhatexto + Chr(27) + "*p710x908Y" + nr_volume_dia_formatado(nr_produtor, 22)
                linhatexto = linhatexto + Chr(27) + "*p815x908Y" + nr_volume_dia_formatado(nr_produtor, 23)
                linhatexto = linhatexto + Chr(27) + "*p920x908Y" + nr_volume_dia_formatado(nr_produtor, 24)
                linhatexto = linhatexto + Chr(27) + "*p1025x908Y" + nr_volume_dia_formatado(nr_produtor, 25)
                linhatexto = linhatexto + Chr(27) + "*p1135x908Y" + nr_volume_dia_formatado(nr_produtor, 26)
                linhatexto = linhatexto + Chr(27) + "*p1245x908Y" + nr_volume_dia_formatado(nr_produtor, 27)
                linhatexto = linhatexto + Chr(27) + "*p1345x908Y" + nr_volume_dia_formatado(nr_produtor, 28)
                linhatexto = linhatexto + Chr(27) + "*p1450x908Y" + nr_volume_dia_formatado(nr_produtor, 29)
                linhatexto = linhatexto + Chr(27) + "*p1560x908Y" + nr_volume_dia_formatado(nr_produtor, 30)
                linhatexto = linhatexto + Chr(27) + "*p1665x908Y" + nr_volume_dia_formatado(nr_produtor, 31)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p6v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p1780x803Y" + nr_volume_dia_formatado(nr_produtor, 32)
                linhatexto = linhatexto + Chr(27) + "*p1780x908Y" + nr_volume_dia_formatado(nr_produtor, 33)
                linhatexto = linhatexto + Chr(27) + "*p1920x908Y" + nr_volume_dia_formatado(nr_produtor, 34)
                linhatexto = linhatexto + Chr(27) + "*p2060x908Y" + nr_volume_dia_formatado(nr_produtor, 35)
                linhatexto = linhatexto + Chr(27) + "*p2180x908Y" + nr_volume_dia_formatado(nr_produtor, 36)
                linhatexto = linhatexto + Chr(27) + "*p2320x908Y" + nr_volume_dia_formatado(nr_produtor, 37)

                '/* LINHA 3*/
                nr_produtor = 3
                linhatexto = linhatexto + Chr(27) + "*p100x998Y" + nm_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1170x998Y" + cd_insc_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1800x998Y" + cd_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p2270x998Y" + cd_propriedade(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"
                linhatexto = linhatexto + Chr(27) + "*p75x1101Y" + nr_volume_dia_formatado(nr_produtor, 1)
                linhatexto = linhatexto + Chr(27) + "*p180x1101Y" + nr_volume_dia_formatado(nr_produtor, 2)
                linhatexto = linhatexto + Chr(27) + "*p285x1101Y" + nr_volume_dia_formatado(nr_produtor, 3)
                linhatexto = linhatexto + Chr(27) + "*p390x1101Y" + nr_volume_dia_formatado(nr_produtor, 4)
                linhatexto = linhatexto + Chr(27) + "*p495x1101Y" + nr_volume_dia_formatado(nr_produtor, 5)
                linhatexto = linhatexto + Chr(27) + "*p605x1101Y" + nr_volume_dia_formatado(nr_produtor, 6)
                linhatexto = linhatexto + Chr(27) + "*p710x1101Y" + nr_volume_dia_formatado(nr_produtor, 7)
                linhatexto = linhatexto + Chr(27) + "*p815x1101Y" + nr_volume_dia_formatado(nr_produtor, 8)
                linhatexto = linhatexto + Chr(27) + "*p920x1101Y" + nr_volume_dia_formatado(nr_produtor, 9)
                linhatexto = linhatexto + Chr(27) + "*p1025x1101Y" + nr_volume_dia_formatado(nr_produtor, 10)
                linhatexto = linhatexto + Chr(27) + "*p1135x1101Y" + nr_volume_dia_formatado(nr_produtor, 11)
                linhatexto = linhatexto + Chr(27) + "*p1245x1101Y" + nr_volume_dia_formatado(nr_produtor, 12)
                linhatexto = linhatexto + Chr(27) + "*p1345x1101Y" + nr_volume_dia_formatado(nr_produtor, 13)
                linhatexto = linhatexto + Chr(27) + "*p1450x1101Y" + nr_volume_dia_formatado(nr_produtor, 14)
                linhatexto = linhatexto + Chr(27) + "*p1560x1101Y" + nr_volume_dia_formatado(nr_produtor, 15)
                linhatexto = linhatexto + Chr(27) + "*p75x1206Y" + nr_volume_dia_formatado(nr_produtor, 16)
                linhatexto = linhatexto + Chr(27) + "*p180x1206Y" + nr_volume_dia_formatado(nr_produtor, 17)
                linhatexto = linhatexto + Chr(27) + "*p285x1206Y" + nr_volume_dia_formatado(nr_produtor, 18)
                linhatexto = linhatexto + Chr(27) + "*p390x1206Y" + nr_volume_dia_formatado(nr_produtor, 19)
                linhatexto = linhatexto + Chr(27) + "*p495x1206Y" + nr_volume_dia_formatado(nr_produtor, 20)
                linhatexto = linhatexto + Chr(27) + "*p605x1206Y" + nr_volume_dia_formatado(nr_produtor, 21)
                linhatexto = linhatexto + Chr(27) + "*p710x1206Y" + nr_volume_dia_formatado(nr_produtor, 22)
                linhatexto = linhatexto + Chr(27) + "*p815x1206Y" + nr_volume_dia_formatado(nr_produtor, 23)
                linhatexto = linhatexto + Chr(27) + "*p920x1206Y" + nr_volume_dia_formatado(nr_produtor, 24)
                linhatexto = linhatexto + Chr(27) + "*p1025x1206Y" + nr_volume_dia_formatado(nr_produtor, 25)
                linhatexto = linhatexto + Chr(27) + "*p1135x1206Y" + nr_volume_dia_formatado(nr_produtor, 26)
                linhatexto = linhatexto + Chr(27) + "*p1245x1206Y" + nr_volume_dia_formatado(nr_produtor, 27)
                linhatexto = linhatexto + Chr(27) + "*p1345x1206Y" + nr_volume_dia_formatado(nr_produtor, 28)
                linhatexto = linhatexto + Chr(27) + "*p1450x1206Y" + nr_volume_dia_formatado(nr_produtor, 29)
                linhatexto = linhatexto + Chr(27) + "*p1560x1206Y" + nr_volume_dia_formatado(nr_produtor, 30)
                linhatexto = linhatexto + Chr(27) + "*p1665x1206Y" + nr_volume_dia_formatado(nr_produtor, 31)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p6v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p1780x1101Y" + nr_volume_dia_formatado(nr_produtor, 32)
                linhatexto = linhatexto + Chr(27) + "*p1780x1206Y" + nr_volume_dia_formatado(nr_produtor, 33)
                linhatexto = linhatexto + Chr(27) + "*p1920x1206Y" + nr_volume_dia_formatado(nr_produtor, 34)
                linhatexto = linhatexto + Chr(27) + "*p2060x1206Y" + nr_volume_dia_formatado(nr_produtor, 35)
                linhatexto = linhatexto + Chr(27) + "*p2180x1206Y" + nr_volume_dia_formatado(nr_produtor, 36)
                linhatexto = linhatexto + Chr(27) + "*p2320x1206Y" + nr_volume_dia_formatado(nr_produtor, 37)

                '/* LINHA 4*/
                nr_produtor = 4
                linhatexto = linhatexto + Chr(27) + "*p100x1294Y" + nm_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1170x1294Y" + cd_insc_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1800x1294Y" + cd_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p2270x1294Y" + cd_propriedade(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"
                linhatexto = linhatexto + Chr(27) + "*p75x1395Y" + nr_volume_dia_formatado(nr_produtor, 1)
                linhatexto = linhatexto + Chr(27) + "*p180x1395Y" + nr_volume_dia_formatado(nr_produtor, 2)
                linhatexto = linhatexto + Chr(27) + "*p285x1395Y" + nr_volume_dia_formatado(nr_produtor, 3)
                linhatexto = linhatexto + Chr(27) + "*p390x1395Y" + nr_volume_dia_formatado(nr_produtor, 4)
                linhatexto = linhatexto + Chr(27) + "*p495x1395Y" + nr_volume_dia_formatado(nr_produtor, 5)
                linhatexto = linhatexto + Chr(27) + "*p605x1395Y" + nr_volume_dia_formatado(nr_produtor, 6)
                linhatexto = linhatexto + Chr(27) + "*p710x1395Y" + nr_volume_dia_formatado(nr_produtor, 7)
                linhatexto = linhatexto + Chr(27) + "*p815x1395Y" + nr_volume_dia_formatado(nr_produtor, 8)
                linhatexto = linhatexto + Chr(27) + "*p920x1395Y" + nr_volume_dia_formatado(nr_produtor, 9)
                linhatexto = linhatexto + Chr(27) + "*p1025x1395Y" + nr_volume_dia_formatado(nr_produtor, 10)
                linhatexto = linhatexto + Chr(27) + "*p1135x1395Y" + nr_volume_dia_formatado(nr_produtor, 11)
                linhatexto = linhatexto + Chr(27) + "*p1245x1395Y" + nr_volume_dia_formatado(nr_produtor, 12)
                linhatexto = linhatexto + Chr(27) + "*p1345x1395Y" + nr_volume_dia_formatado(nr_produtor, 13)
                linhatexto = linhatexto + Chr(27) + "*p1450x1395Y" + nr_volume_dia_formatado(nr_produtor, 14)
                linhatexto = linhatexto + Chr(27) + "*p1560x1395Y" + nr_volume_dia_formatado(nr_produtor, 15)
                linhatexto = linhatexto + Chr(27) + "*p75x1500Y" + nr_volume_dia_formatado(nr_produtor, 16)
                linhatexto = linhatexto + Chr(27) + "*p180x1500Y" + nr_volume_dia_formatado(nr_produtor, 17)
                linhatexto = linhatexto + Chr(27) + "*p285x1500Y" + nr_volume_dia_formatado(nr_produtor, 18)
                linhatexto = linhatexto + Chr(27) + "*p390x1500Y" + nr_volume_dia_formatado(nr_produtor, 19)
                linhatexto = linhatexto + Chr(27) + "*p495x1500Y" + nr_volume_dia_formatado(nr_produtor, 20)
                linhatexto = linhatexto + Chr(27) + "*p605x1500Y" + nr_volume_dia_formatado(nr_produtor, 21)
                linhatexto = linhatexto + Chr(27) + "*p710x1500Y" + nr_volume_dia_formatado(nr_produtor, 22)
                linhatexto = linhatexto + Chr(27) + "*p815x1500Y" + nr_volume_dia_formatado(nr_produtor, 23)
                linhatexto = linhatexto + Chr(27) + "*p920x1500Y" + nr_volume_dia_formatado(nr_produtor, 24)
                linhatexto = linhatexto + Chr(27) + "*p1025x1500Y" + nr_volume_dia_formatado(nr_produtor, 25)
                linhatexto = linhatexto + Chr(27) + "*p1135x1500Y" + nr_volume_dia_formatado(nr_produtor, 26)
                linhatexto = linhatexto + Chr(27) + "*p1245x1500Y" + nr_volume_dia_formatado(nr_produtor, 27)
                linhatexto = linhatexto + Chr(27) + "*p1345x1500Y" + nr_volume_dia_formatado(nr_produtor, 28)
                linhatexto = linhatexto + Chr(27) + "*p1450x1500Y" + nr_volume_dia_formatado(nr_produtor, 29)
                linhatexto = linhatexto + Chr(27) + "*p1560x1500Y" + nr_volume_dia_formatado(nr_produtor, 30)
                linhatexto = linhatexto + Chr(27) + "*p1665x1500Y" + nr_volume_dia_formatado(nr_produtor, 31)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p6v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p1780x1395Y" + nr_volume_dia_formatado(nr_produtor, 32)
                linhatexto = linhatexto + Chr(27) + "*p1780x1500Y" + nr_volume_dia_formatado(nr_produtor, 33)
                linhatexto = linhatexto + Chr(27) + "*p1920x1500Y" + nr_volume_dia_formatado(nr_produtor, 34)
                linhatexto = linhatexto + Chr(27) + "*p2060x1500Y" + nr_volume_dia_formatado(nr_produtor, 35)
                linhatexto = linhatexto + Chr(27) + "*p2180x1500Y" + nr_volume_dia_formatado(nr_produtor, 36)
                linhatexto = linhatexto + Chr(27) + "*p2320x1500Y" + nr_volume_dia_formatado(nr_produtor, 37)

                '/* LINHA 5*/
                nr_produtor = 5
                linhatexto = linhatexto + Chr(27) + "*p100x1593Y" + nm_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1170x1593Y" + cd_insc_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1800x1593Y" + cd_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p2270x1593Y" + cd_propriedade(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"
                linhatexto = linhatexto + Chr(27) + "*p75x1694Y" + nr_volume_dia_formatado(nr_produtor, 1)
                linhatexto = linhatexto + Chr(27) + "*p180x1694Y" + nr_volume_dia_formatado(nr_produtor, 2)
                linhatexto = linhatexto + Chr(27) + "*p285x1694Y" + nr_volume_dia_formatado(nr_produtor, 3)
                linhatexto = linhatexto + Chr(27) + "*p390x1694Y" + nr_volume_dia_formatado(nr_produtor, 4)
                linhatexto = linhatexto + Chr(27) + "*p495x1694Y" + nr_volume_dia_formatado(nr_produtor, 5)
                linhatexto = linhatexto + Chr(27) + "*p605x1694Y" + nr_volume_dia_formatado(nr_produtor, 6)
                linhatexto = linhatexto + Chr(27) + "*p710x1694Y" + nr_volume_dia_formatado(nr_produtor, 7)
                linhatexto = linhatexto + Chr(27) + "*p815x1694Y" + nr_volume_dia_formatado(nr_produtor, 8)
                linhatexto = linhatexto + Chr(27) + "*p920x1694Y" + nr_volume_dia_formatado(nr_produtor, 9)
                linhatexto = linhatexto + Chr(27) + "*p1025x1694Y" + nr_volume_dia_formatado(nr_produtor, 10)
                linhatexto = linhatexto + Chr(27) + "*p1135x1694Y" + nr_volume_dia_formatado(nr_produtor, 11)
                linhatexto = linhatexto + Chr(27) + "*p1245x1694Y" + nr_volume_dia_formatado(nr_produtor, 12)
                linhatexto = linhatexto + Chr(27) + "*p1345x1694Y" + nr_volume_dia_formatado(nr_produtor, 13)
                linhatexto = linhatexto + Chr(27) + "*p1450x1694Y" + nr_volume_dia_formatado(nr_produtor, 14)
                linhatexto = linhatexto + Chr(27) + "*p1560x1694Y" + nr_volume_dia_formatado(nr_produtor, 15)
                linhatexto = linhatexto + Chr(27) + "*p75x1799Y" + nr_volume_dia_formatado(nr_produtor, 16)
                linhatexto = linhatexto + Chr(27) + "*p180x1799Y" + nr_volume_dia_formatado(nr_produtor, 17)
                linhatexto = linhatexto + Chr(27) + "*p285x1799Y" + nr_volume_dia_formatado(nr_produtor, 18)
                linhatexto = linhatexto + Chr(27) + "*p390x1799Y" + nr_volume_dia_formatado(nr_produtor, 19)
                linhatexto = linhatexto + Chr(27) + "*p495x1799Y" + nr_volume_dia_formatado(nr_produtor, 20)
                linhatexto = linhatexto + Chr(27) + "*p605x1799Y" + nr_volume_dia_formatado(nr_produtor, 21)
                linhatexto = linhatexto + Chr(27) + "*p710x1799Y" + nr_volume_dia_formatado(nr_produtor, 22)
                linhatexto = linhatexto + Chr(27) + "*p815x1799Y" + nr_volume_dia_formatado(nr_produtor, 23)
                linhatexto = linhatexto + Chr(27) + "*p920x1799Y" + nr_volume_dia_formatado(nr_produtor, 24)
                linhatexto = linhatexto + Chr(27) + "*p1025x1799Y" + nr_volume_dia_formatado(nr_produtor, 25)
                linhatexto = linhatexto + Chr(27) + "*p1135x1799Y" + nr_volume_dia_formatado(nr_produtor, 26)
                linhatexto = linhatexto + Chr(27) + "*p1245x1799Y" + nr_volume_dia_formatado(nr_produtor, 27)
                linhatexto = linhatexto + Chr(27) + "*p1345x1799Y" + nr_volume_dia_formatado(nr_produtor, 28)
                linhatexto = linhatexto + Chr(27) + "*p1450x1799Y" + nr_volume_dia_formatado(nr_produtor, 29)
                linhatexto = linhatexto + Chr(27) + "*p1560x1799Y" + nr_volume_dia_formatado(nr_produtor, 30)
                linhatexto = linhatexto + Chr(27) + "*p1665x1799Y" + nr_volume_dia_formatado(nr_produtor, 31)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p6v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p1780x1694Y" + nr_volume_dia_formatado(nr_produtor, 32)
                linhatexto = linhatexto + Chr(27) + "*p1780x1799Y" + nr_volume_dia_formatado(nr_produtor, 33)
                linhatexto = linhatexto + Chr(27) + "*p1920x1799Y" + nr_volume_dia_formatado(nr_produtor, 34)
                linhatexto = linhatexto + Chr(27) + "*p2060x1799Y" + nr_volume_dia_formatado(nr_produtor, 35)
                linhatexto = linhatexto + Chr(27) + "*p2180x1799Y" + nr_volume_dia_formatado(nr_produtor, 36)
                linhatexto = linhatexto + Chr(27) + "*p2320x1799Y" + nr_volume_dia_formatado(nr_produtor, 37)

                '/* LINHA 6*/
                nr_produtor = 6
                linhatexto = linhatexto + Chr(27) + "*p100x1887Y" + nm_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1170x1887Y" + cd_insc_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1800x1887Y" + cd_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p2270x1887Y" + cd_propriedade(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"
                linhatexto = linhatexto + Chr(27) + "*p75x1988Y" + nr_volume_dia_formatado(nr_produtor, 1)
                linhatexto = linhatexto + Chr(27) + "*p180x1988Y" + nr_volume_dia_formatado(nr_produtor, 2)
                linhatexto = linhatexto + Chr(27) + "*p285x1988Y" + nr_volume_dia_formatado(nr_produtor, 3)
                linhatexto = linhatexto + Chr(27) + "*p390x1988Y" + nr_volume_dia_formatado(nr_produtor, 4)
                linhatexto = linhatexto + Chr(27) + "*p495x1988Y" + nr_volume_dia_formatado(nr_produtor, 5)
                linhatexto = linhatexto + Chr(27) + "*p605x1988Y" + nr_volume_dia_formatado(nr_produtor, 6)
                linhatexto = linhatexto + Chr(27) + "*p710x1988Y" + nr_volume_dia_formatado(nr_produtor, 7)
                linhatexto = linhatexto + Chr(27) + "*p815x1988Y" + nr_volume_dia_formatado(nr_produtor, 8)
                linhatexto = linhatexto + Chr(27) + "*p920x1988Y" + nr_volume_dia_formatado(nr_produtor, 9)
                linhatexto = linhatexto + Chr(27) + "*p1025x1988Y" + nr_volume_dia_formatado(nr_produtor, 10)
                linhatexto = linhatexto + Chr(27) + "*p1135x1988Y" + nr_volume_dia_formatado(nr_produtor, 11)
                linhatexto = linhatexto + Chr(27) + "*p1245x1988Y" + nr_volume_dia_formatado(nr_produtor, 12)
                linhatexto = linhatexto + Chr(27) + "*p1345x1988Y" + nr_volume_dia_formatado(nr_produtor, 13)
                linhatexto = linhatexto + Chr(27) + "*p1450x1988Y" + nr_volume_dia_formatado(nr_produtor, 14)
                linhatexto = linhatexto + Chr(27) + "*p1560x1988Y" + nr_volume_dia_formatado(nr_produtor, 15)
                linhatexto = linhatexto + Chr(27) + "*p75x2093Y" + nr_volume_dia_formatado(nr_produtor, 16)
                linhatexto = linhatexto + Chr(27) + "*p180x2093Y" + nr_volume_dia_formatado(nr_produtor, 17)
                linhatexto = linhatexto + Chr(27) + "*p285x2093Y" + nr_volume_dia_formatado(nr_produtor, 18)
                linhatexto = linhatexto + Chr(27) + "*p390x2093Y" + nr_volume_dia_formatado(nr_produtor, 19)
                linhatexto = linhatexto + Chr(27) + "*p495x2093Y" + nr_volume_dia_formatado(nr_produtor, 20)
                linhatexto = linhatexto + Chr(27) + "*p605x2093Y" + nr_volume_dia_formatado(nr_produtor, 21)
                linhatexto = linhatexto + Chr(27) + "*p710x2093Y" + nr_volume_dia_formatado(nr_produtor, 22)
                linhatexto = linhatexto + Chr(27) + "*p815x2093Y" + nr_volume_dia_formatado(nr_produtor, 23)
                linhatexto = linhatexto + Chr(27) + "*p920x2093Y" + nr_volume_dia_formatado(nr_produtor, 24)
                linhatexto = linhatexto + Chr(27) + "*p1025x2093Y" + nr_volume_dia_formatado(nr_produtor, 25)
                linhatexto = linhatexto + Chr(27) + "*p1135x2093Y" + nr_volume_dia_formatado(nr_produtor, 26)
                linhatexto = linhatexto + Chr(27) + "*p1245x2093Y" + nr_volume_dia_formatado(nr_produtor, 27)
                linhatexto = linhatexto + Chr(27) + "*p1345x2093Y" + nr_volume_dia_formatado(nr_produtor, 28)
                linhatexto = linhatexto + Chr(27) + "*p1450x2093Y" + nr_volume_dia_formatado(nr_produtor, 29)
                linhatexto = linhatexto + Chr(27) + "*p1560x2093Y" + nr_volume_dia_formatado(nr_produtor, 30)
                linhatexto = linhatexto + Chr(27) + "*p1665x2093Y" + nr_volume_dia_formatado(nr_produtor, 31)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p6v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p1780x1988Y" + nr_volume_dia_formatado(nr_produtor, 32)
                linhatexto = linhatexto + Chr(27) + "*p1780x2093Y" + nr_volume_dia_formatado(nr_produtor, 33)
                linhatexto = linhatexto + Chr(27) + "*p1920x2093Y" + nr_volume_dia_formatado(nr_produtor, 34)
                linhatexto = linhatexto + Chr(27) + "*p2060x2093Y" + nr_volume_dia_formatado(nr_produtor, 35)
                linhatexto = linhatexto + Chr(27) + "*p2180x2093Y" + nr_volume_dia_formatado(nr_produtor, 36)
                linhatexto = linhatexto + Chr(27) + "*p2320x2093Y" + nr_volume_dia_formatado(nr_produtor, 37)

                '/* LINHA 7*/
                nr_produtor = 7
                linhatexto = linhatexto + Chr(27) + "*p100x2181Y" + nm_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1170x2181Y" + cd_insc_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1800x2181Y" + cd_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p2270x2181Y" + cd_propriedade(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"
                linhatexto = linhatexto + Chr(27) + "*p75x2283Y" + nr_volume_dia_formatado(nr_produtor, 1)
                linhatexto = linhatexto + Chr(27) + "*p180x2283Y" + nr_volume_dia_formatado(nr_produtor, 2)
                linhatexto = linhatexto + Chr(27) + "*p285x2283Y" + nr_volume_dia_formatado(nr_produtor, 3)
                linhatexto = linhatexto + Chr(27) + "*p390x2283Y" + nr_volume_dia_formatado(nr_produtor, 4)
                linhatexto = linhatexto + Chr(27) + "*p495x2283Y" + nr_volume_dia_formatado(nr_produtor, 5)
                linhatexto = linhatexto + Chr(27) + "*p605x2283Y" + nr_volume_dia_formatado(nr_produtor, 6)
                linhatexto = linhatexto + Chr(27) + "*p710x2283Y" + nr_volume_dia_formatado(nr_produtor, 7)
                linhatexto = linhatexto + Chr(27) + "*p815x2283Y" + nr_volume_dia_formatado(nr_produtor, 8)
                linhatexto = linhatexto + Chr(27) + "*p920x2283Y" + nr_volume_dia_formatado(nr_produtor, 9)
                linhatexto = linhatexto + Chr(27) + "*p1025x2283Y" + nr_volume_dia_formatado(nr_produtor, 10)
                linhatexto = linhatexto + Chr(27) + "*p1135x2283Y" + nr_volume_dia_formatado(nr_produtor, 11)
                linhatexto = linhatexto + Chr(27) + "*p1245x2283Y" + nr_volume_dia_formatado(nr_produtor, 12)
                linhatexto = linhatexto + Chr(27) + "*p1345x2283Y" + nr_volume_dia_formatado(nr_produtor, 13)
                linhatexto = linhatexto + Chr(27) + "*p1450x2283Y" + nr_volume_dia_formatado(nr_produtor, 14)
                linhatexto = linhatexto + Chr(27) + "*p1560x2283Y" + nr_volume_dia_formatado(nr_produtor, 15)
                linhatexto = linhatexto + Chr(27) + "*p75x2388Y" + nr_volume_dia_formatado(nr_produtor, 16)
                linhatexto = linhatexto + Chr(27) + "*p180x2388Y" + nr_volume_dia_formatado(nr_produtor, 17)
                linhatexto = linhatexto + Chr(27) + "*p285x2388Y" + nr_volume_dia_formatado(nr_produtor, 18)
                linhatexto = linhatexto + Chr(27) + "*p390x2388Y" + nr_volume_dia_formatado(nr_produtor, 19)
                linhatexto = linhatexto + Chr(27) + "*p495x2388Y" + nr_volume_dia_formatado(nr_produtor, 20)
                linhatexto = linhatexto + Chr(27) + "*p605x2388Y" + nr_volume_dia_formatado(nr_produtor, 21)
                linhatexto = linhatexto + Chr(27) + "*p710x2388Y" + nr_volume_dia_formatado(nr_produtor, 22)
                linhatexto = linhatexto + Chr(27) + "*p815x2388Y" + nr_volume_dia_formatado(nr_produtor, 23)
                linhatexto = linhatexto + Chr(27) + "*p920x2388Y" + nr_volume_dia_formatado(nr_produtor, 24)
                linhatexto = linhatexto + Chr(27) + "*p1025x2388Y" + nr_volume_dia_formatado(nr_produtor, 25)
                linhatexto = linhatexto + Chr(27) + "*p1135x2388Y" + nr_volume_dia_formatado(nr_produtor, 26)
                linhatexto = linhatexto + Chr(27) + "*p1245x2388Y" + nr_volume_dia_formatado(nr_produtor, 27)
                linhatexto = linhatexto + Chr(27) + "*p1345x2388Y" + nr_volume_dia_formatado(nr_produtor, 28)
                linhatexto = linhatexto + Chr(27) + "*p1450x2388Y" + nr_volume_dia_formatado(nr_produtor, 29)
                linhatexto = linhatexto + Chr(27) + "*p1560x2388Y" + nr_volume_dia_formatado(nr_produtor, 30)
                linhatexto = linhatexto + Chr(27) + "*p1665x2388Y" + nr_volume_dia_formatado(nr_produtor, 31)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p6v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p1780x2283Y" + nr_volume_dia_formatado(nr_produtor, 32)
                linhatexto = linhatexto + Chr(27) + "*p1780x2388Y" + nr_volume_dia_formatado(nr_produtor, 33)
                linhatexto = linhatexto + Chr(27) + "*p1920x2388Y" + nr_volume_dia_formatado(nr_produtor, 34)
                linhatexto = linhatexto + Chr(27) + "*p2060x2388Y" + nr_volume_dia_formatado(nr_produtor, 35)
                linhatexto = linhatexto + Chr(27) + "*p2180x2388Y" + nr_volume_dia_formatado(nr_produtor, 36)
                linhatexto = linhatexto + Chr(27) + "*p2320x2388Y" + nr_volume_dia_formatado(nr_produtor, 37)

                '/* LINHA 8*/
                nr_produtor = 8
                linhatexto = linhatexto + Chr(27) + "*p100x2478Y" + nm_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1170x2478Y" + cd_insc_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1800x2478Y" + cd_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p2270x2478Y" + cd_propriedade(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"
                linhatexto = linhatexto + Chr(27) + "*p75x2581Y" + nr_volume_dia_formatado(nr_produtor, 1)
                linhatexto = linhatexto + Chr(27) + "*p180x2581Y" + nr_volume_dia_formatado(nr_produtor, 2)
                linhatexto = linhatexto + Chr(27) + "*p285x2581Y" + nr_volume_dia_formatado(nr_produtor, 3)
                linhatexto = linhatexto + Chr(27) + "*p390x2581Y" + nr_volume_dia_formatado(nr_produtor, 4)
                linhatexto = linhatexto + Chr(27) + "*p495x2581Y" + nr_volume_dia_formatado(nr_produtor, 5)
                linhatexto = linhatexto + Chr(27) + "*p605x2581Y" + nr_volume_dia_formatado(nr_produtor, 6)
                linhatexto = linhatexto + Chr(27) + "*p710x2581Y" + nr_volume_dia_formatado(nr_produtor, 7)
                linhatexto = linhatexto + Chr(27) + "*p815x2581Y" + nr_volume_dia_formatado(nr_produtor, 8)
                linhatexto = linhatexto + Chr(27) + "*p920x2581Y" + nr_volume_dia_formatado(nr_produtor, 9)
                linhatexto = linhatexto + Chr(27) + "*p1025x2581Y" + nr_volume_dia_formatado(nr_produtor, 10)
                linhatexto = linhatexto + Chr(27) + "*p1135x2581Y" + nr_volume_dia_formatado(nr_produtor, 11)
                linhatexto = linhatexto + Chr(27) + "*p1245x2581Y" + nr_volume_dia_formatado(nr_produtor, 12)
                linhatexto = linhatexto + Chr(27) + "*p1345x2581Y" + nr_volume_dia_formatado(nr_produtor, 13)
                linhatexto = linhatexto + Chr(27) + "*p1450x2581Y" + nr_volume_dia_formatado(nr_produtor, 14)
                linhatexto = linhatexto + Chr(27) + "*p1560x2581Y" + nr_volume_dia_formatado(nr_produtor, 15)
                linhatexto = linhatexto + Chr(27) + "*p75x2686Y" + nr_volume_dia_formatado(nr_produtor, 16)
                linhatexto = linhatexto + Chr(27) + "*p180x2686Y" + nr_volume_dia_formatado(nr_produtor, 17)
                linhatexto = linhatexto + Chr(27) + "*p285x2686Y" + nr_volume_dia_formatado(nr_produtor, 18)
                linhatexto = linhatexto + Chr(27) + "*p390x2686Y" + nr_volume_dia_formatado(nr_produtor, 19)
                linhatexto = linhatexto + Chr(27) + "*p495x2686Y" + nr_volume_dia_formatado(nr_produtor, 20)
                linhatexto = linhatexto + Chr(27) + "*p605x2686Y" + nr_volume_dia_formatado(nr_produtor, 21)
                linhatexto = linhatexto + Chr(27) + "*p710x2686Y" + nr_volume_dia_formatado(nr_produtor, 22)
                linhatexto = linhatexto + Chr(27) + "*p815x2686Y" + nr_volume_dia_formatado(nr_produtor, 23)
                linhatexto = linhatexto + Chr(27) + "*p920x2686Y" + nr_volume_dia_formatado(nr_produtor, 24)
                linhatexto = linhatexto + Chr(27) + "*p1025x2686Y" + nr_volume_dia_formatado(nr_produtor, 25)
                linhatexto = linhatexto + Chr(27) + "*p1135x2686Y" + nr_volume_dia_formatado(nr_produtor, 26)
                linhatexto = linhatexto + Chr(27) + "*p1245x2686Y" + nr_volume_dia_formatado(nr_produtor, 27)
                linhatexto = linhatexto + Chr(27) + "*p1345x2686Y" + nr_volume_dia_formatado(nr_produtor, 28)
                linhatexto = linhatexto + Chr(27) + "*p1450x2686Y" + nr_volume_dia_formatado(nr_produtor, 29)
                linhatexto = linhatexto + Chr(27) + "*p1560x2686Y" + nr_volume_dia_formatado(nr_produtor, 30)
                linhatexto = linhatexto + Chr(27) + "*p1665x2686Y" + nr_volume_dia_formatado(nr_produtor, 31)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p6v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p1780x2581Y" + nr_volume_dia_formatado(nr_produtor, 32)
                linhatexto = linhatexto + Chr(27) + "*p1780x2686Y" + nr_volume_dia_formatado(nr_produtor, 33)
                linhatexto = linhatexto + Chr(27) + "*p1920x2686Y" + nr_volume_dia_formatado(nr_produtor, 34)
                linhatexto = linhatexto + Chr(27) + "*p2060x2686Y" + nr_volume_dia_formatado(nr_produtor, 35)
                linhatexto = linhatexto + Chr(27) + "*p2180x2686Y" + nr_volume_dia_formatado(nr_produtor, 36)
                linhatexto = linhatexto + Chr(27) + "*p2320x2686Y" + nr_volume_dia_formatado(nr_produtor, 37)

                '/* LINHA 9*/
                nr_produtor = 9
                linhatexto = linhatexto + Chr(27) + "*p100x2776Y" + nm_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1170x2776Y" + cd_insc_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p1800x2776Y" + cd_produtor(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "*p2270x2776Y" + cd_propriedade(nr_produtor)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"
                linhatexto = linhatexto + Chr(27) + "*p75x2877Y" + nr_volume_dia_formatado(nr_produtor, 1)
                linhatexto = linhatexto + Chr(27) + "*p180x2877Y" + nr_volume_dia_formatado(nr_produtor, 2)
                linhatexto = linhatexto + Chr(27) + "*p285x2877Y" + nr_volume_dia_formatado(nr_produtor, 3)
                linhatexto = linhatexto + Chr(27) + "*p390x2877Y" + nr_volume_dia_formatado(nr_produtor, 4)
                linhatexto = linhatexto + Chr(27) + "*p495x2877Y" + nr_volume_dia_formatado(nr_produtor, 5)
                linhatexto = linhatexto + Chr(27) + "*p605x2877Y" + nr_volume_dia_formatado(nr_produtor, 6)
                linhatexto = linhatexto + Chr(27) + "*p710x2877Y" + nr_volume_dia_formatado(nr_produtor, 7)
                linhatexto = linhatexto + Chr(27) + "*p815x2877Y" + nr_volume_dia_formatado(nr_produtor, 8)
                linhatexto = linhatexto + Chr(27) + "*p920x2877Y" + nr_volume_dia_formatado(nr_produtor, 9)
                linhatexto = linhatexto + Chr(27) + "*p1025x2877Y" + nr_volume_dia_formatado(nr_produtor, 10)
                linhatexto = linhatexto + Chr(27) + "*p1135x2877Y" + nr_volume_dia_formatado(nr_produtor, 11)
                linhatexto = linhatexto + Chr(27) + "*p1245x2877Y" + nr_volume_dia_formatado(nr_produtor, 12)
                linhatexto = linhatexto + Chr(27) + "*p1345x2877Y" + nr_volume_dia_formatado(nr_produtor, 13)
                linhatexto = linhatexto + Chr(27) + "*p1450x2877Y" + nr_volume_dia_formatado(nr_produtor, 14)
                linhatexto = linhatexto + Chr(27) + "*p1560x2877Y" + nr_volume_dia_formatado(nr_produtor, 15)
                linhatexto = linhatexto + Chr(27) + "*p75x2982Y" + nr_volume_dia_formatado(nr_produtor, 16)
                linhatexto = linhatexto + Chr(27) + "*p180x2982Y" + nr_volume_dia_formatado(nr_produtor, 17)
                linhatexto = linhatexto + Chr(27) + "*p285x2982Y" + nr_volume_dia_formatado(nr_produtor, 18)
                linhatexto = linhatexto + Chr(27) + "*p390x2982Y" + nr_volume_dia_formatado(nr_produtor, 19)
                linhatexto = linhatexto + Chr(27) + "*p495x2982Y" + nr_volume_dia_formatado(nr_produtor, 20)
                linhatexto = linhatexto + Chr(27) + "*p605x2982Y" + nr_volume_dia_formatado(nr_produtor, 21)
                linhatexto = linhatexto + Chr(27) + "*p710x2982Y" + nr_volume_dia_formatado(nr_produtor, 22)
                linhatexto = linhatexto + Chr(27) + "*p815x2982Y" + nr_volume_dia_formatado(nr_produtor, 23)
                linhatexto = linhatexto + Chr(27) + "*p920x2982Y" + nr_volume_dia_formatado(nr_produtor, 24)
                linhatexto = linhatexto + Chr(27) + "*p1025x2982Y" + nr_volume_dia_formatado(nr_produtor, 25)
                linhatexto = linhatexto + Chr(27) + "*p1135x2982Y" + nr_volume_dia_formatado(nr_produtor, 26)
                linhatexto = linhatexto + Chr(27) + "*p1245x2982Y" + nr_volume_dia_formatado(nr_produtor, 27)
                linhatexto = linhatexto + Chr(27) + "*p1345x2982Y" + nr_volume_dia_formatado(nr_produtor, 28)
                linhatexto = linhatexto + Chr(27) + "*p1450x2982Y" + nr_volume_dia_formatado(nr_produtor, 29)
                linhatexto = linhatexto + Chr(27) + "*p1560x2982Y" + nr_volume_dia_formatado(nr_produtor, 30)
                linhatexto = linhatexto + Chr(27) + "*p1665x2982Y" + nr_volume_dia_formatado(nr_produtor, 31)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p6v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p1780x2877Y" + nr_volume_dia_formatado(nr_produtor, 32)
                linhatexto = linhatexto + Chr(27) + "*p1780x2982Y" + nr_volume_dia_formatado(nr_produtor, 33)
                linhatexto = linhatexto + Chr(27) + "*p1920x2982Y" + nr_volume_dia_formatado(nr_produtor, 34)
                linhatexto = linhatexto + Chr(27) + "*p2060x2982Y" + nr_volume_dia_formatado(nr_produtor, 35)
                linhatexto = linhatexto + Chr(27) + "*p2180x2982Y" + nr_volume_dia_formatado(nr_produtor, 36)
                linhatexto = linhatexto + Chr(27) + "*p2320x2982Y" + nr_volume_dia_formatado(nr_produtor, 37)

                '/* LINHA 10*/
                nr_produtor = 10
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"
                linhatexto = linhatexto + Chr(27) + "*p75x3110Y" + nr_volume_dia_formatado(nr_produtor, 1)
                linhatexto = linhatexto + Chr(27) + "*p180x3110Y" + nr_volume_dia_formatado(nr_produtor, 2)
                linhatexto = linhatexto + Chr(27) + "*p285x3110Y" + nr_volume_dia_formatado(nr_produtor, 3)
                linhatexto = linhatexto + Chr(27) + "*p390x3110Y" + nr_volume_dia_formatado(nr_produtor, 4)
                linhatexto = linhatexto + Chr(27) + "*p495x3110Y" + nr_volume_dia_formatado(nr_produtor, 5)
                linhatexto = linhatexto + Chr(27) + "*p605x3110Y" + nr_volume_dia_formatado(nr_produtor, 6)
                linhatexto = linhatexto + Chr(27) + "*p710x3110Y" + nr_volume_dia_formatado(nr_produtor, 7)
                linhatexto = linhatexto + Chr(27) + "*p815x3110Y" + nr_volume_dia_formatado(nr_produtor, 8)

                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"
                linhatexto = linhatexto + Chr(27) + "*p75x3214Y" + nr_volume_dia_formatado(nr_produtor, 9)
                linhatexto = linhatexto + Chr(27) + "*p180x3214Y" + nr_volume_dia_formatado(nr_produtor, 10)
                linhatexto = linhatexto + Chr(27) + "*p285x3214Y" + nr_volume_dia_formatado(nr_produtor, 11)
                linhatexto = linhatexto + Chr(27) + "*p390x3214Y" + nr_volume_dia_formatado(nr_produtor, 12)
                linhatexto = linhatexto + Chr(27) + "*p495x3214Y" + nr_volume_dia_formatado(nr_produtor, 13)
                linhatexto = linhatexto + Chr(27) + "*p605x3214Y" + nr_volume_dia_formatado(nr_produtor, 14)
                linhatexto = linhatexto + Chr(27) + "*p710x3214Y" + nr_volume_dia_formatado(nr_produtor, 15)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p7v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p950x3214Y" + nr_volume_dia_formatado(nr_produtor, 32)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"
                linhatexto = linhatexto + Chr(27) + "*p75x3323Y" + nr_volume_dia_formatado(nr_produtor, 16)
                linhatexto = linhatexto + Chr(27) + "*p180x3323Y" + nr_volume_dia_formatado(nr_produtor, 17)
                linhatexto = linhatexto + Chr(27) + "*p285x3323Y" + nr_volume_dia_formatado(nr_produtor, 18)
                linhatexto = linhatexto + Chr(27) + "*p390x3323Y" + nr_volume_dia_formatado(nr_produtor, 19)
                linhatexto = linhatexto + Chr(27) + "*p495x3323Y" + nr_volume_dia_formatado(nr_produtor, 20)
                linhatexto = linhatexto + Chr(27) + "*p605x3323Y" + nr_volume_dia_formatado(nr_produtor, 21)
                linhatexto = linhatexto + Chr(27) + "*p710x3323Y" + nr_volume_dia_formatado(nr_produtor, 22)
                linhatexto = linhatexto + Chr(27) + "*p815x3323Y" + nr_volume_dia_formatado(nr_produtor, 23)

                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s0p23h0s3b4102T"
                linhatexto = linhatexto + Chr(27) + "*p75x3430Y" + nr_volume_dia_formatado(nr_produtor, 24)
                linhatexto = linhatexto + Chr(27) + "*p180x3430Y" + nr_volume_dia_formatado(nr_produtor, 25)
                linhatexto = linhatexto + Chr(27) + "*p285x3430Y" + nr_volume_dia_formatado(nr_produtor, 26)
                linhatexto = linhatexto + Chr(27) + "*p390x3430Y" + nr_volume_dia_formatado(nr_produtor, 27)
                linhatexto = linhatexto + Chr(27) + "*p495x3430Y" + nr_volume_dia_formatado(nr_produtor, 28)
                linhatexto = linhatexto + Chr(27) + "*p605x3430Y" + nr_volume_dia_formatado(nr_produtor, 29)
                linhatexto = linhatexto + Chr(27) + "*p710x3430Y" + nr_volume_dia_formatado(nr_produtor, 30)
                linhatexto = linhatexto + Chr(27) + "*p815x3430Y" + nr_volume_dia_formatado(nr_produtor, 31)
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p7v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "*p950x3430Y" + nr_volume_dia_formatado(nr_produtor, 33)
                linhatexto = linhatexto + Chr(27) + "*p1120x3430Y" + nr_volume_dia_formatado(nr_produtor, 34)
                linhatexto = linhatexto + Chr(27) + "*p1310x3430Y" + nr_volume_dia_formatado(nr_produtor, 35)
                linhatexto = linhatexto + Chr(27) + "*p1480x3430Y" + nr_volume_dia_formatado(nr_produtor, 36)
                linhatexto = linhatexto + Chr(27) + "*p1670x3430Y" + nr_volume_dia_formatado(nr_produtor, 37)

                linhatexto = linhatexto + Chr(27) + "(8U" + Chr(27) + "(s1p21.12v0s0b5T" + Chr(27) + "*p60x130YA"
                linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p5.5v4s3b4148T"
                linhatexto = linhatexto + Chr(27) + "&a90P" + Chr(27) + "*p700x2440Y" + CStr(estabelecimento.ds_aidf)

                linhatexto = linhatexto + Chr(27)

            Next

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Function exportMapaLeiteSAP() As Boolean

        ' 01/02/2012 - Projeto Themis - i

        ' 02/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - i
        'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo, False, utf8WithoutBom)
        ' 02/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - f

        Try

            Dim li As Int32
            Dim liexportada As Int32

            Dim nr_volume_dia(10, 37) As Int64 '1494 mirella 09/03/2012
            Dim nr_volume_dia_formatado(10, 37) As String


            Dim li_dia As Int16
            Dim id_propriedade_anterior As Int32
            Dim nr_dia As Int16
            Dim nr_produtor As Int16

            ' 21112008 - i
            Dim id_transportador As Int32
            Dim id_cidade As Int32
            Dim id_transportador_anterior As Int32
            Dim id_cidade_anterior As Int32
            Dim lds_placa_anterior As String
            Dim lds_placa As String
            ' 21112008 - f


            Dim dsMapaLeite As DataSet = Me.getMapaLeiteByFilters()


            ' Formata Campos do Relatorio
            Me.linhatexto = ""
            ds_municipio_prod = ""
            nm_transportador = ""
            cd_insc_transportador = ""
            nr_produtor = 1
            For nr_produtor = 0 To 10
                cd_produtor(nr_produtor) = Space(15)
                nm_produtor(nr_produtor) = Space(30)
                cd_insc_produtor(nr_produtor) = Space(20)
                cd_propriedade(nr_produtor) = Space(10)
                For li_dia = 1 To 37
                    Select Case li_dia
                        Case 32, 33, 34
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Space(9)
                        Case 35
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Space(9)
                        Case 36
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Space(5)
                        Case 37
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Space(4)
                        Case Else
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Space(6)
                    End Select
                Next
            Next

            ' 21112008 - i
            id_transportador = 0
            id_cidade = 0
            lds_placa = ""
            lds_placa_anterior = ""
            id_transportador_anterior = 0
            id_cidade_anterior = 0
            ' 21112008 - f

            nr_produtor = 1

            ' 21112008 - i
            If dsMapaLeite.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("id_transportador")) Then
                    id_transportador_anterior = dsMapaLeite.Tables(0).Rows(li).Item("id_transportador")
                End If
                If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("id_cidade")) Then
                    id_cidade_anterior = dsMapaLeite.Tables(0).Rows(li).Item("id_cidade")
                End If
                If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("ds_placa")) Then
                    lds_placa_anterior = dsMapaLeite.Tables(0).Rows(li).Item("ds_placa")
                End If

            End If
            ' 21112008 - f

            For li = 0 To dsMapaLeite.Tables(0).Rows.Count - 1

                If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("id_transportador")) Then
                    id_transportador = dsMapaLeite.Tables(0).Rows(li).Item("id_transportador")
                Else
                    id_transportador = 0
                End If
                If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("id_cidade")) Then
                    id_cidade = dsMapaLeite.Tables(0).Rows(li).Item("id_cidade")
                Else
                    id_cidade = 0
                End If
                If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("ds_placa")) Then
                    lds_placa = dsMapaLeite.Tables(0).Rows(li).Item("ds_placa")
                Else
                    lds_placa = ""
                End If

                If nr_produtor > 9 Or id_transportador <> id_transportador_anterior Or id_cidade <> id_cidade_anterior Or lds_placa <> lds_placa_anterior Then


                    id_transportador_anterior = id_transportador
                    id_cidade_anterior = id_cidade
                    lds_placa_anterior = lds_placa


                    geraMapaSAP(nr_volume_dia_formatado, ArquivoTexto)   ' 06/02/2012 Projetos Themis

                    'ArquivoTexto.WriteLine(linhatexto)   '  Para o Themis, gravar linha a linha

                    nr_produtor = 1
                    ' Formata Campos do Relatorio
                    Me.linhatexto = ""
                    ds_municipio_prod = ""
                    nm_transportador = ""
                    cd_insc_transportador = ""
                    nr_produtor = 1
                    For nr_produtor = 0 To 10
                        cd_produtor(nr_produtor) = Space(15)
                        nm_produtor(nr_produtor) = Space(30)
                        cd_insc_produtor(nr_produtor) = Space(20)
                        cd_propriedade(nr_produtor) = Space(10)
                        For li_dia = 1 To 37
                            Select Case li_dia
                                Case 32, 33, 34
                                    nr_volume_dia_formatado(nr_produtor, li_dia) = Space(9)
                                Case 35
                                    nr_volume_dia_formatado(nr_produtor, li_dia) = Space(9)
                                Case 36
                                    nr_volume_dia_formatado(nr_produtor, li_dia) = Space(5)
                                Case 37
                                    nr_volume_dia_formatado(nr_produtor, li_dia) = Space(4)
                                Case Else
                                    nr_volume_dia_formatado(nr_produtor, li_dia) = Space(6)
                            End Select
                            nr_volume_dia(10, li_dia) = 0
                        Next
                    Next
                    nr_produtor = 1   ' 21112008

                    'Exit For
                End If
                '===============================================================
                ' Cabeçalho - Formata Dados do Produtor (Município)
                '===============================================================

                ds_municipio_prod = dsMapaLeite.Tables(0).Rows(li).Item("nm_cidade")
                ds_municipio_prod = Left(ds_municipio_prod + StrDup(34 - Len(ds_municipio_prod), " "), 34)

                '===============================================================
                ' Cabeçalho - Formata Dados do Transportador
                '===============================================================
                nm_transportador = Left(dsMapaLeite.Tables(0).Rows(li).Item("nm_transportador"), 36)  ' 16/01/2009
                nm_transportador = Left(nm_transportador + StrDup(36 - Len(nm_transportador), " "), 36)

                cd_insc_transportador = Left(CStr(dsMapaLeite.Tables(0).Rows(li).Item("nm_linha")), 20)
                cd_insc_transportador = Left(cd_insc_transportador + StrDup(20 - Len(cd_insc_transportador), " "), 20)

                Me.ds_placa = lds_placa
                '===============================================================
                ' Linhas - Formata Dados do Produtor e Propriedade
                '===============================================================
                'cd_produtor(nr_produtor) = dsMapaLeite.Tables(0).Rows(li).Item("cd_pessoa")
                'Fran 15/07/2012 i O codigo do produtor sap esta na propriedade
                'cd_produtor(nr_produtor) = dsMapaLeite.Tables(0).Rows(li).Item("cd_codigo_SAP").ToString   ' 15/03/2012 - Corrigido pelo retorno da França
                cd_produtor(nr_produtor) = dsMapaLeite.Tables(0).Rows(li).Item("cd_propriedade_SAP").ToString
                'Fran 15/07/2012 f O codigo do produtor sap esta na propriedade
                cd_produtor(nr_produtor) = Left(cd_produtor(nr_produtor) + StrDup(15 - Len(cd_produtor(nr_produtor)), " "), 15)

                nm_produtor(nr_produtor) = Left(dsMapaLeite.Tables(0).Rows(li).Item("nm_pessoa"), 30)   ' 30/10/2008
                nm_produtor(nr_produtor) = Left(nm_produtor(nr_produtor) + StrDup(30 - Len(nm_produtor(nr_produtor)), " "), 30)

                cd_insc_produtor(nr_produtor) = dsMapaLeite.Tables(0).Rows(li).Item("cd_inscricao_estadual")
                'fran 17/07/2013 i
                If cd_insc_produtor(nr_produtor).ToString.Trim.Equals(String.Empty) Then
                    cd_insc_produtor(nr_produtor) = "ISENTO"
                End If
                'fran 17/07/2013 f

                cd_insc_produtor(nr_produtor) = Left(cd_insc_produtor(nr_produtor) + StrDup(20 - Len(cd_insc_produtor(nr_produtor)), " "), 20)


                'cd_propriedade(nr_produtor) = CStr(dsMapaLeite.Tables(0).Rows(li).Item("id_propriedade"))
                'Fran 15/07/2012 i O codigo da propriedade deve ser o proprio codigo de propriedade
                'cd_propriedade(nr_produtor) = CStr(dsMapaLeite.Tables(0).Rows(li).Item("cd_propriedade_SAP").ToString)   ' chamado 1529 - 04/04/2012 projeto themis
                cd_propriedade(nr_produtor) = CStr(dsMapaLeite.Tables(0).Rows(li).Item("id_propriedade"))
                'Fran 15/07/2012 f O codigo do produtor sap esta na propriedade
                cd_propriedade(nr_produtor) = Left(cd_propriedade(nr_produtor) + StrDup(10 - Len(cd_propriedade(nr_produtor)), " "), 10)


                '===============================================================
                ' Linhas - Formata Volumes
                '===============================================================

                ' Formata volumes
                For li_dia = 1 To 37
                    nr_volume_dia(nr_produtor, li_dia) = 0
                    Select Case li_dia
                        Case 32, 33, 34  ' Total 1.aq, 2.a Q e Mes - Tamnho de 9 alinhados à direita
                            nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 0)
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Left(StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, li_dia)), " ") + nr_volume_dia_formatado(nr_produtor, li_dia), 9)
                        Case 35  ' Cota - Tamnho de 9 alinhado à esquerda
                            nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 0)
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Left(nr_volume_dia_formatado(nr_produtor, li_dia) + StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, li_dia)), " "), 9)
                        Case 36  ' Extra Cota - Tamnho de 5 Brancos
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Space(5)
                        Case 37  ' Teor de Gordura - Tamnho 4 alinhado à direita
                            ' 30/03/2012 - chamado 1527 - Formatar teor de gordura com duas casas decimais - i
                            'nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 1)
                            nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 2)
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Left(StrDup(4 - Len(nr_volume_dia_formatado(nr_produtor, li_dia)), " ") + nr_volume_dia_formatado(nr_produtor, li_dia), 4)
                            ' 30/03/2012 - chamado 1527 - Formatar teor de gordura com duas casas decimais - f
                        Case Else ' Dia 01 a 31 - Tamnho de 6 alinhados à direita
                            nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 0)
                            nr_volume_dia_formatado(nr_produtor, li_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(nr_produtor, li_dia)), " ") + nr_volume_dia_formatado(nr_produtor, li_dia), 6)
                    End Select

                Next

                li_dia = li
                id_propriedade_anterior = dsMapaLeite.Tables(0).Rows(li).Item("id_propriedade")

                'For li_dia = 0 To dsMapaLeite.Tables(0).Rows.Count - 1   ' Le os dias da Propriedade
                For li_dia = li To dsMapaLeite.Tables(0).Rows.Count - 1   ' 19/09/2008 - Le os dias da Propriedade
                    'fran 12/08/2023 - correcao de erro- quando a consulta traz o mesmo propriedade que  muda de transportador ou placa, estava incluindo tudo no 1o tranbsportador placa
                    'If dsMapaLeite.Tables(0).Rows(li_dia).Item("id_propriedade") = id_propriedade_anterior Then
                    If dsMapaLeite.Tables(0).Rows(li_dia).Item("id_propriedade") = id_propriedade_anterior AndAlso dsMapaLeite.Tables(0).Rows(li_dia).Item("id_transportador") = id_transportador AndAlso dsMapaLeite.Tables(0).Rows(li_dia).Item("ds_placa") = lds_placa Then
                        'fran 15/07/2012 i 'soma volume dia
                        If nr_dia = dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia") Then
                            nr_volume = nr_volume + dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_volume")
                        Else
                            nr_volume = dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_volume")
                        End If
                        'fran 15/07/2012 f
                        nr_dia = dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia")

                        nr_volume_dia(nr_produtor, nr_dia) = dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_volume")
                        nr_volume_dia(10, nr_dia) = nr_volume_dia(10, nr_dia) + nr_volume_dia(nr_produtor, nr_dia)  ' Totalizador 10 (dia)

                        ' Fran 15/02/2012 chamado 1496  - i
                        'nr_volume_dia_formatado(nr_produtor, nr_dia) = FormatNumber(dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_volume"), 0)
                        'nr_volume_dia_formatado(nr_produtor, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(nr_produtor, nr_dia)), " ") + nr_volume_dia_formatado(nr_produtor, nr_dia), 6)

                        '' 20081124 - i
                        'nr_volume_dia_formatado(10, nr_dia) = FormatNumber(nr_volume_dia(10, nr_dia), 0)
                        'nr_volume_dia_formatado(10, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(10, nr_dia)), " ") + nr_volume_dia_formatado(10, nr_dia), 6)
                        '' 20081124 - f
                        'fran 15/07/2012 i 'soma volume dia
                        'nr_volume_dia_formatado(nr_produtor, nr_dia) = FormatNumber(dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_volume"), 0)
                        nr_volume_dia_formatado(nr_produtor, nr_dia) = FormatNumber(nr_volume, 0)
                        'fran 15/07/2012 f 'soma volume dia
                        If Len(nr_volume_dia_formatado(nr_produtor, nr_dia)) > 6 Then  ' Fran 15/02/2012 chamado 1496 
                            nr_volume_dia_formatado(nr_produtor, nr_dia) = Left(Mid(nr_volume_dia_formatado(nr_produtor, nr_dia), 1, 3) + Mid(nr_volume_dia_formatado(nr_produtor, nr_dia), 5, 3), 6)
                        End If
                        If Len(nr_volume_dia_formatado(nr_produtor, nr_dia)) > 6 Then   ' Fran 15/02/2012 chamado 1496 
                            nr_volume_dia_formatado(nr_produtor, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(nr_produtor, nr_dia)), " ") + nr_volume_dia_formatado(nr_produtor, nr_dia), 6)
                        End If

                        nr_volume_dia_formatado(nr_produtor, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(nr_produtor, nr_dia)), " ") + nr_volume_dia_formatado(nr_produtor, nr_dia), 6)

                        ' 20081124 - i
                        nr_volume_dia_formatado(10, nr_dia) = FormatNumber(nr_volume_dia(10, nr_dia), 0)
                        If Len(nr_volume_dia_formatado(10, nr_dia)) > 6 Then    ' Fran 15/02/2012 chamado 1496 
                            nr_volume_dia_formatado(10, nr_dia) = Left(Mid(nr_volume_dia_formatado(10, nr_dia), 1, 3) + Mid(nr_volume_dia_formatado(10, nr_dia), 5, 3), 6)
                        End If
                        If Len(nr_volume_dia_formatado(10, nr_dia)) > 6 Then    ' Fran 15/02/2012 chamado 1496 
                            nr_volume_dia_formatado(10, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(10, nr_dia)), " ") + nr_volume_dia_formatado(10, nr_dia), 6)
                        End If
                        nr_volume_dia_formatado(10, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(10, nr_dia)), " ") + nr_volume_dia_formatado(10, nr_dia), 6)
                        ' 20081124 - f
                        ' Fran 15/02/2012 chamado 1496  - i

                        If dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia") <= 15 Then
                            nr_volume_dia(nr_produtor, 32) = nr_volume_dia(nr_produtor, 32) + nr_volume_dia(nr_produtor, dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia"))   ' Volume do Mes
                            'Fran 24/09/2012 i a somatoria das 1as quinzenas dos produtores deve ser a soma já guardada das quinzenas mais o valor do DIA do produtor
                            'nr_volume_dia(10, 32) = nr_volume_dia(10, 32) + nr_volume_dia(nr_produtor, 32) ' Totalizador 10 (1.a Q)
                            nr_volume_dia(10, 32) = nr_volume_dia(10, 32) + nr_volume_dia(nr_produtor, nr_dia) ' Totalizador 10 (1.a Q)
                            'Fran 24/09/2012 f
                        Else
                            nr_volume_dia(nr_produtor, 33) = nr_volume_dia(nr_produtor, 33) + nr_volume_dia(nr_produtor, dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia"))   ' Volume do Mes
                            'Fran 24/09/2012 i a somatoria das 2as quinzenas dos produtores deve ser a soma já guardada das quinzenas mais o valor do DIA do produtor
                            'nr_volume_dia(10, 33) = nr_volume_dia(10, 33) + nr_volume_dia(nr_produtor, 33) ' Totalizador 10 (2.a Q)
                            nr_volume_dia(10, 33) = nr_volume_dia(10, 33) + nr_volume_dia(nr_produtor, nr_dia) ' Totalizador 10 (2.a Q)
                            'Fran 24/09/2012 f
                        End If
                        nr_volume_dia(nr_produtor, 34) = nr_volume_dia(nr_produtor, 34) + nr_volume_dia(nr_produtor, dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia"))   ' Volume do Mes
                        'Fran 24/09/2012 i a somatoria mensal dos produtores deve ser a soma já guardada dos produtores mais o valor do DIA do produtor
                        'nr_volume_dia(10, 34) = nr_volume_dia(10, 34) + nr_volume_dia(nr_produtor, 34) ' Totalizador 10 (Mes)
                        nr_volume_dia(10, 34) = nr_volume_dia(10, 34) + nr_volume_dia(nr_produtor, nr_dia) ' Totalizador 10 (Mes)
                        'Fran 24/09/2012 f
                    Else
                        nr_volume = 0
                        Exit For

                    End If
                Next

                'Formata Total 1.a Quinzena
                nr_volume_dia_formatado(nr_produtor, 32) = Right(FormatNumber(nr_volume_dia(nr_produtor, 32), 0), 9)
                nr_volume_dia_formatado(nr_produtor, 32) = Left(StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, 32)), " ") + nr_volume_dia_formatado(nr_produtor, 32), 9)

                ' 20081124 - i
                'nr_volume_dia_formatado(10, 32) = Left(StrDup(9 - Len(nr_volume_dia_formatado(10, 32)), " ") + nr_volume_dia_formatado(10, 32), 9)
                nr_volume_dia_formatado(10, 32) = Right(FormatNumber(nr_volume_dia(10, 32), 0), 9)
                nr_volume_dia_formatado(10, 32) = Left(StrDup(9 - Len(nr_volume_dia_formatado(10, 32)), " ") + nr_volume_dia_formatado(10, 32), 9)
                ' 20081124 - f

                'Formata Total 2.a Quinzena
                nr_volume_dia_formatado(nr_produtor, 33) = Right(FormatNumber(nr_volume_dia(nr_produtor, 33), 0), 9)
                nr_volume_dia_formatado(nr_produtor, 33) = Left(StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, 33)), " ") + nr_volume_dia_formatado(nr_produtor, 33), 9)
                nr_volume_dia_formatado(10, 33) = Right(FormatNumber(nr_volume_dia(10, 33), 0), 9)
                nr_volume_dia_formatado(10, 33) = Left(StrDup(9 - Len(nr_volume_dia_formatado(10, 33)), " ") + nr_volume_dia_formatado(10, 33), 9)

                'Formata Total Mes
                nr_volume_dia_formatado(nr_produtor, 34) = Right(FormatNumber(nr_volume_dia(nr_produtor, 34), 0), 9)
                nr_volume_dia_formatado(nr_produtor, 34) = Left(StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, 34)), " ") + nr_volume_dia_formatado(nr_produtor, 34), 9)
                nr_volume_dia_formatado(10, 34) = Right(FormatNumber(nr_volume_dia(10, 34), 0), 9)
                nr_volume_dia_formatado(10, 34) = Left(StrDup(9 - Len(nr_volume_dia_formatado(10, 34)), " ") + nr_volume_dia_formatado(10, 34), 9)

                'Formata Cota igual ao valor do Mes
                nr_volume_dia_formatado(nr_produtor, 35) = Right(FormatNumber(nr_volume_dia(nr_produtor, 34), 0), 9)
                nr_volume_dia_formatado(nr_produtor, 35) = Left(nr_volume_dia_formatado(nr_produtor, 35) + StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, 35)), " "), 9)
                'Fran 24/09/2012 formata cota igual ao mes
                'nr_volume_dia_formatado(10, 35) = Right(FormatNumber(nr_volume_dia(10, 35), 0), 9)
                nr_volume_dia_formatado(10, 35) = Right(FormatNumber(nr_volume_dia(10, 34), 0), 9)
                nr_volume_dia_formatado(10, 35) = Left(nr_volume_dia_formatado(10, 35) + StrDup(9 - Len(nr_volume_dia_formatado(10, 35)), " "), 9)
                'Fran 24/09/2012 f formata cota igual ao mes

                nr_produtor = nr_produtor + 1  ' Quantidade de Produtor/Propriedade por página 

                li = li_dia - 1     ' 19/09/2008
            Next

            If nr_produtor <= 10 Then
                geraMapaSAP(nr_volume_dia_formatado, ArquivoTexto)
            End If

            liexportada = liexportada + 1

            Me.nr_linhaslidas = li
            Me.nr_linhasexportadas = liexportada

            ArquivoTexto.Close()
            exportMapaLeiteSAP = True

        Catch ex As Exception
            exportMapaLeiteSAP = False
            ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try
        ' 01/02/2012 - Projeto Themis - i

    End Function
    Private Sub geraMapaSAP(ByVal nr_volume_dia_formatado(,) As String, ByVal ArquivoTexto As StreamWriter)

        ' 06/02/2012 - Projeto Themis - i

        'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Try
            Dim i As Int16

            Dim ds_endereco_dan As String
            Dim ds_municipio_dan As String
            Dim ds_inscricao_dan As String
            Dim ds_cnpj_dan As String
            Dim nr_mapa_leite As String
            Dim nr_mes As String
            Dim nr_ano As String
            Dim nr_produtor As Int16


            '===============================================================
            ' Formata Dados do Estabelecimento
            '===============================================================
            Dim estabelecimento As New Estabelecimento(Me.id_estabelecimento)


            ds_endereco_dan = estabelecimento.ds_endereco + ", " + CStr(estabelecimento.nr_endereco)
            ds_endereco_dan = Left(ds_endereco_dan + StrDup(55 - Len(ds_endereco_dan), " "), 55)

            ds_municipio_dan = estabelecimento.nm_cidade
            ds_municipio_dan = Left(ds_municipio_dan + StrDup(30 - Len(ds_municipio_dan), " "), 30)

            ds_inscricao_dan = estabelecimento.cd_inscricao_estadual
            ds_inscricao_dan = Left(ds_inscricao_dan + StrDup(30 - Len(ds_inscricao_dan), " "), 30)

            ds_cnpj_dan = estabelecimento.cd_cnpj
            ds_cnpj_dan = Left(ds_cnpj_dan + StrDup(18 - Len(ds_cnpj_dan), " "), 18)

            nr_mapa_leite = FormatNumber(estabelecimento.getEstabelecimentoNumeroMapa, 0)  ' Próximo Número
            nr_mapa_leite = Left(nr_mapa_leite + StrDup(9 - Len(nr_mapa_leite), " "), 9)

            ' 12/03/2012 - Mirella - retira espaços em branco da esquerda dos campos de valores - i
            nr_mapa_leite = Trim(nr_mapa_leite)

            nr_mes = DateTime.Parse(Me.dt_referencia).ToString("MM")
            nr_ano = DateTime.Parse(Me.dt_referencia).ToString("yyyy")

            'For i = 1 To 2
            'Fran 12/03/2009 i rls17 - Estas linhas estão desabilitadas no esre0027rp.p (fonte)
            'linhatexto = linhatexto + Chr(27) + "&l0O" + Chr(27) + "&l26A" + Chr(27) + "&l1H" + Chr(27) + "&a0P" + Chr(27) + "&f59Y" + Chr(27) + "&n7W" + Chr(5) + "LEITE1" + Chr(27) + "&f2xS" + Chr(27) + "&u300D"
            'linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p8v4s3b4148T"
            'Fran 12/03/2009 f rls17

            'If i = 1 Then
            '    linhatexto = linhatexto + Chr(27) + "&l0O" + Chr(27) + "&l26A" + Chr(27) + "&l8H" + Chr(27) + "&a0P" + Chr(27) + "&f59Y" + Chr(27) + "&n7W" + Chr(5) + "LEITE1" + Chr(27) + "&f2xS" + Chr(27) + "&u300D"
            '    linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p8v4s3b4148T"
            '    linhatexto = linhatexto + Chr(27) + "*p2188x155Y" + "1a VIA - EMITENTE"
            'Else
            '    linhatexto = linhatexto + Chr(27) + "&l0O" + Chr(27) + "&l26A" + Chr(27) + "&l1H" + Chr(27) + "&a0P" + Chr(27) + "&f59Y" + Chr(27) + "&n7W" + Chr(5) + "LEITE1" + Chr(27) + "&f2xS" + Chr(27) + "&u300D"
            '    linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p8v4s3b4148T"
            '    linhatexto = linhatexto + Chr(27) + "*p2188x155Y" + "2a VIA - CONTROLE"
            'End If

            '===============================================
            ' REGISTRO TIPO 1
            '===============================================

            linhatexto = linhatexto + "1" + ";" '1 - Registro Tipo (fixo) 

            linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 

            linhatexto = linhatexto + nr_mapa_leite + ";" '3 - numero do mapa de leite
            linhatexto = linhatexto + "001" + ";" '4 - Sequencia (Fixo)
            linhatexto = linhatexto + ds_municipio_dan + ";" ' 5 - Municipio Estabelecimento
            linhatexto = linhatexto + ds_endereco_dan + ";"  ' 6 - Entdereço do Estabelecimento 

            linhatexto = linhatexto + ds_inscricao_dan + ";"  ' 7- Inscrição Estadual Estabelecimento 
            linhatexto = linhatexto + ds_cnpj_dan + ";" ' 8 - CNPJ do Estabelecimento


            linhatexto = linhatexto + ds_municipio_prod + ";" ' 9 - Municipio Produtor 
            linhatexto = linhatexto + nr_mes + ";" ' 10 - Mes Refêrencia
            linhatexto = linhatexto + nr_ano + ";" ' 11 - Ano Refêrencia
            linhatexto = linhatexto + CStr(estabelecimento.ds_aidf) + ";" '12 AIDF Mapa Leite 
            linhatexto = linhatexto + "MAPA DE RECEBIMENTO DE LEITE" + ";" '13 Tipo do Formulário 

            'linhatexto = linhatexto + nm_transportador + ";" '?
            'linhatexto = linhatexto + cd_insc_transportador + ";" ' ?

            ArquivoTexto.WriteLine(linhatexto)
            linhatexto = ""

            '===============================================
            ' REGISTRO TIPO 2
            '===============================================

            linhatexto = linhatexto + "2" + ";" '1 - Registro Tipo (fixo)
            linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 

            linhatexto = linhatexto + nr_mapa_leite + ";" '3 - Numero do Mapa Leite

            linhatexto = linhatexto + "001" + ";" '4 - Sequencia (fixo)
            'fran 15/07/2012 i deve enviar nm transportadora
            'linhatexto = linhatexto + estabelecimento.cd_codigo_sap + ";" '5 - Transportadora (codigo da transportadora SAP)
            linhatexto = linhatexto + nm_transportador + ";" '5 - Transportadora (codigo da transportadora SAP)
            'fran 15/07/2012 f deve enviar nm transportadora

            linhatexto = linhatexto + ";" '6 numero da rota
            'fran 15/07/2012 i deve enviar rota
            linhatexto = linhatexto + cd_insc_transportador + ";"  '7 descricao da rota
            'fran 15/07/2012 f deve enviar rota
            linhatexto = linhatexto + ds_placa + ";"  '8 mapa de leite

            ArquivoTexto.WriteLine(linhatexto)
            linhatexto = ""
            '===============================================
            ' REGISTRO TIPO 3
            '===============================================

            '===============================================================
            ' LINHA 1*
            '===============================================================

            nr_produtor = 1

            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
            For li_dia As Int16 = 1 To 37
                nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
            Next
            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

            linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
            linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
            linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

            linhatexto = linhatexto + "001" + ";" '4 - Sequencia
            linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
            linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
            'linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" '7 - Codigo do Produtor
            linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
            linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

            ArquivoTexto.WriteLine(linhatexto)
            linhatexto = ""
            '/* LINHA 2*/
            nr_produtor = 2

            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
            For li_dia As Int16 = 1 To 37
                nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
            Next
            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

            linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
            linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
            linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

            linhatexto = linhatexto + "002" + ";" '4 - Sequencia
            linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
            linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
            linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
            linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

            ' 15/03/2012 -Corrigido pelo retorno da França - i 
            'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
            ' 15/03/2012 -Corrigido pelo retorno da França - f 
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

            ArquivoTexto.WriteLine(linhatexto)
            linhatexto = ""

            '/* LINHA 3*/
            nr_produtor = 3

            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
            For li_dia As Int16 = 1 To 37
                nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
            Next
            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

            linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
            linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
            linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

            linhatexto = linhatexto + "003" + ";" '4 - Sequencia
            linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
            linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
            linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
            linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

            ' 15/03/2012 -Corrigido pelo retorno da França - i 
            'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
            ' 15/03/2012 -Corrigido pelo retorno da França - i 
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

            ArquivoTexto.WriteLine(linhatexto)
            linhatexto = ""

            '/* LINHA 4*/
            nr_produtor = 4

            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
            For li_dia As Int16 = 1 To 37
                nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
            Next
            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

            linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
            linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
            linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

            linhatexto = linhatexto + "004" + ";" '4 - Sequencia
            linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
            linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
            linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
            linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

            ' 15/03/2012 -Corrigido pelo retorno da França - i 
            'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
            ' 15/03/2012 -Corrigido pelo retorno da França - f 
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

            ArquivoTexto.WriteLine(linhatexto)
            linhatexto = ""

            '/* LINHA 5*/
            nr_produtor = 5

            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
            For li_dia As Int16 = 1 To 37
                nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
            Next
            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

            linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
            linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
            linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

            linhatexto = linhatexto + "005" + ";" '4 - Sequencia
            linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
            linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
            linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
            linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

            ' 15/03/2012 -Corrigido pelo retorno da França - i 
            'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
            ' 15/03/2012 -Corrigido pelo retorno da França - f 
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

            ArquivoTexto.WriteLine(linhatexto)
            linhatexto = ""

            '/* LINHA 6*/
            nr_produtor = 6

            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
            For li_dia As Int16 = 1 To 37
                nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
            Next
            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

            linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
            linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
            linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

            linhatexto = linhatexto + "006" + ";" '4 - Sequencia
            linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
            linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
            linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
            linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

            ' 15/03/2012 -Corrigido pelo retorno da França - i 
            'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
            ' 15/03/2012 -Corrigido pelo retorno da França - f 
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

            ArquivoTexto.WriteLine(linhatexto)
            linhatexto = ""

            '/* LINHA 7*/
            nr_produtor = 7

            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
            For li_dia As Int16 = 1 To 37
                nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
            Next
            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

            linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
            linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
            linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

            linhatexto = linhatexto + "007" + ";" '4 - Sequencia
            linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
            linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
            linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
            linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

            ' 15/03/2012 -Corrigido pelo retorno da França - i 
            'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
            ' 15/03/2012 -Corrigido pelo retorno da França - f 
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

            ArquivoTexto.WriteLine(linhatexto)
            linhatexto = ""
            '/* LINHA 8*/
            nr_produtor = 8

            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
            For li_dia As Int16 = 1 To 37
                nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
            Next
            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

            linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
            linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
            linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

            linhatexto = linhatexto + "008" + ";" '4 - Sequencia
            linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
            linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
            linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
            linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

            ' 15/03/2012 -Corrigido pelo retorno da França - i 
            'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
            ' 15/03/2012 -Corrigido pelo retorno da França - f 
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

            ArquivoTexto.WriteLine(linhatexto)
            linhatexto = ""

            '/* LINHA 9*/
            nr_produtor = 9

            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
            For li_dia As Int16 = 1 To 37
                nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
            Next
            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

            linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
            linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
            linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

            linhatexto = linhatexto + "009" + ";" '4 - Sequencia
            linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
            linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
            linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
            linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

            ' 15/03/2012 -Corrigido pelo retorno da França - i 
            'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
            'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
            ' 15/03/2012 -Corrigido pelo retorno da França - f 
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

            ArquivoTexto.WriteLine(linhatexto)
            linhatexto = ""


            '==================================================
            ' Registro tipo 4
            '==================================================
            '/* LINHA 10*/
            nr_produtor = 10

            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
            For li_dia As Int16 = 1 To 37
                nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
            Next
            ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

            linhatexto = linhatexto + "4" + ";" '1 - Registro Tipo (fixo)
            linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
            linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite
            linhatexto = linhatexto + "001" + ";" '4 - Sequencia

            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"

            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"

            'linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";" fran 24/09/2012 i o totalizador da quinzena fica no fim como layout

            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"

            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"

            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";" 'fran 24/09/2012 i o totalizador da quinzena fica no fim como layout

            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
            linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

            ArquivoTexto.WriteLine(linhatexto)
            linhatexto = ""
            'linhatexto = linhatexto + CStr(estabelecimento.ds_aidf)


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    ' 06/02/2012 - Projeto Themis - i

    'Public Function exportMapaLeiteSAP() As Boolean

    '    ' 01/02/2012 - Projeto Themis - i

    '    ' 02/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - i
    '    'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

    '    Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
    '    Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo, False, utf8WithoutBom)
    '    ' 02/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - f

    '    Try

    '        Dim li As Int32
    '        Dim liexportada As Int32

    '        Dim nr_volume_dia(10, 37) As Int64 '1494 mirella 09/03/2012
    '        Dim nr_volume_dia_formatado(10, 37) As String


    '        Dim li_dia As Int16
    '        Dim id_propriedade_anterior As Int32
    '        Dim nr_dia As Int16
    '        Dim nr_produtor As Int16

    '        ' 21112008 - i
    '        Dim id_transportador As Int32
    '        Dim id_cidade As Int32
    '        Dim id_transportador_anterior As Int32
    '        Dim id_cidade_anterior As Int32
    '        ' 21112008 - f


    '        Dim dsMapaLeite As DataSet = Me.getMapaLeiteByFilters()


    '        ' Formata Campos do Relatorio
    '        Me.linhatexto = ""
    '        ds_municipio_prod = ""
    '        nm_transportador = ""
    '        cd_insc_transportador = ""
    '        nr_produtor = 1
    '        For nr_produtor = 0 To 10
    '            cd_produtor(nr_produtor) = Space(15)
    '            nm_produtor(nr_produtor) = Space(30)
    '            cd_insc_produtor(nr_produtor) = Space(20)
    '            cd_propriedade(nr_produtor) = Space(10)
    '            For li_dia = 1 To 37
    '                Select Case li_dia
    '                    Case 32, 33, 34
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = Space(9)
    '                    Case 35
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = Space(9)
    '                    Case 36
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = Space(5)
    '                    Case 37
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = Space(4)
    '                    Case Else
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = Space(6)
    '                End Select
    '            Next
    '        Next

    '        ' 21112008 - i
    '        id_transportador = 0
    '        id_cidade = 0
    '        id_transportador_anterior = 0
    '        id_cidade_anterior = 0
    '        ' 21112008 - f

    '        nr_produtor = 1

    '        ' 21112008 - i
    '        If dsMapaLeite.Tables(0).Rows.Count > 0 Then
    '            If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("id_transportador")) Then
    '                id_transportador_anterior = dsMapaLeite.Tables(0).Rows(li).Item("id_transportador")
    '            End If
    '            If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("id_cidade")) Then
    '                id_cidade_anterior = dsMapaLeite.Tables(0).Rows(li).Item("id_cidade")
    '            End If

    '        End If
    '        ' 21112008 - f

    '        For li = 0 To dsMapaLeite.Tables(0).Rows.Count - 1

    '            If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("id_transportador")) Then
    '                id_transportador = dsMapaLeite.Tables(0).Rows(li).Item("id_transportador")
    '            Else
    '                id_transportador = 0
    '            End If
    '            If Not IsDBNull(dsMapaLeite.Tables(0).Rows(li).Item("id_cidade")) Then
    '                id_cidade = dsMapaLeite.Tables(0).Rows(li).Item("id_cidade")
    '            Else
    '                id_cidade = 0
    '            End If

    '            If nr_produtor > 9 Or id_transportador <> id_transportador_anterior Or id_cidade <> id_cidade_anterior Then


    '                id_transportador_anterior = id_transportador
    '                id_cidade_anterior = id_cidade

    '                geraMapaSAP(nr_volume_dia_formatado, ArquivoTexto)   ' 06/02/2012 Projetos Themis

    '                'ArquivoTexto.WriteLine(linhatexto)   '  Para o Themis, gravar linha a linha

    '                nr_produtor = 1
    '                ' Formata Campos do Relatorio
    '                Me.linhatexto = ""
    '                ds_municipio_prod = ""
    '                nm_transportador = ""
    '                cd_insc_transportador = ""
    '                nr_produtor = 1
    '                For nr_produtor = 0 To 10
    '                    cd_produtor(nr_produtor) = Space(15)
    '                    nm_produtor(nr_produtor) = Space(30)
    '                    cd_insc_produtor(nr_produtor) = Space(20)
    '                    cd_propriedade(nr_produtor) = Space(10)
    '                    For li_dia = 1 To 37
    '                        Select Case li_dia
    '                            Case 32, 33, 34
    '                                nr_volume_dia_formatado(nr_produtor, li_dia) = Space(9)
    '                            Case 35
    '                                nr_volume_dia_formatado(nr_produtor, li_dia) = Space(9)
    '                            Case 36
    '                                nr_volume_dia_formatado(nr_produtor, li_dia) = Space(5)
    '                            Case 37
    '                                nr_volume_dia_formatado(nr_produtor, li_dia) = Space(4)
    '                            Case Else
    '                                nr_volume_dia_formatado(nr_produtor, li_dia) = Space(6)
    '                        End Select
    '                        nr_volume_dia(10, li_dia) = 0
    '                    Next
    '                Next
    '                nr_produtor = 1   ' 21112008

    '                'Exit For
    '            End If
    '            '===============================================================
    '            ' Cabeçalho - Formata Dados do Produtor (Município)
    '            '===============================================================

    '            ds_municipio_prod = dsMapaLeite.Tables(0).Rows(li).Item("nm_cidade")
    '            ds_municipio_prod = Left(ds_municipio_prod + StrDup(34 - Len(ds_municipio_prod), " "), 34)

    '            '===============================================================
    '            ' Cabeçalho - Formata Dados do Transportador
    '            '===============================================================
    '            nm_transportador = Left(dsMapaLeite.Tables(0).Rows(li).Item("nm_transportador"), 36)  ' 16/01/2009
    '            nm_transportador = Left(nm_transportador + StrDup(36 - Len(nm_transportador), " "), 36)

    '            cd_insc_transportador = Left(CStr(dsMapaLeite.Tables(0).Rows(li).Item("nm_linha")), 20)
    '            cd_insc_transportador = Left(cd_insc_transportador + StrDup(20 - Len(cd_insc_transportador), " "), 20)

    '            '===============================================================
    '            ' Linhas - Formata Dados do Produtor e Propriedade
    '            '===============================================================
    '            'cd_produtor(nr_produtor) = dsMapaLeite.Tables(0).Rows(li).Item("cd_pessoa")
    '            'Fran 15/07/2012 i O codigo do produtor sap esta na propriedade
    '            'cd_produtor(nr_produtor) = dsMapaLeite.Tables(0).Rows(li).Item("cd_codigo_SAP").ToString   ' 15/03/2012 - Corrigido pelo retorno da França
    '            cd_produtor(nr_produtor) = dsMapaLeite.Tables(0).Rows(li).Item("cd_propriedade_SAP").ToString
    '            'Fran 15/07/2012 f O codigo do produtor sap esta na propriedade
    '            cd_produtor(nr_produtor) = Left(cd_produtor(nr_produtor) + StrDup(15 - Len(cd_produtor(nr_produtor)), " "), 15)

    '            nm_produtor(nr_produtor) = Left(dsMapaLeite.Tables(0).Rows(li).Item("nm_pessoa"), 30)   ' 30/10/2008
    '            nm_produtor(nr_produtor) = Left(nm_produtor(nr_produtor) + StrDup(30 - Len(nm_produtor(nr_produtor)), " "), 30)

    '            cd_insc_produtor(nr_produtor) = dsMapaLeite.Tables(0).Rows(li).Item("cd_inscricao_estadual")
    '            'fran 17/07/2013 i
    '            If cd_insc_produtor(nr_produtor).ToString.Trim.Equals(String.Empty) Then
    '                cd_insc_produtor(nr_produtor) = "ISENTO"
    '            End If
    '            'fran 17/07/2013 f

    '            cd_insc_produtor(nr_produtor) = Left(cd_insc_produtor(nr_produtor) + StrDup(20 - Len(cd_insc_produtor(nr_produtor)), " "), 20)


    '            'cd_propriedade(nr_produtor) = CStr(dsMapaLeite.Tables(0).Rows(li).Item("id_propriedade"))
    '            'Fran 15/07/2012 i O codigo da propriedade deve ser o proprio codigo de propriedade
    '            'cd_propriedade(nr_produtor) = CStr(dsMapaLeite.Tables(0).Rows(li).Item("cd_propriedade_SAP").ToString)   ' chamado 1529 - 04/04/2012 projeto themis
    '            cd_propriedade(nr_produtor) = CStr(dsMapaLeite.Tables(0).Rows(li).Item("id_propriedade"))
    '            'Fran 15/07/2012 f O codigo do produtor sap esta na propriedade
    '            cd_propriedade(nr_produtor) = Left(cd_propriedade(nr_produtor) + StrDup(10 - Len(cd_propriedade(nr_produtor)), " "), 10)


    '            '===============================================================
    '            ' Linhas - Formata Volumes
    '            '===============================================================

    '            ' Formata volumes
    '            For li_dia = 1 To 37
    '                nr_volume_dia(nr_produtor, li_dia) = 0
    '                Select Case li_dia
    '                    Case 32, 33, 34  ' Total 1.aq, 2.a Q e Mes - Tamnho de 9 alinhados à direita
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 0)
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = Left(StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, li_dia)), " ") + nr_volume_dia_formatado(nr_produtor, li_dia), 9)
    '                    Case 35  ' Cota - Tamnho de 9 alinhado à esquerda
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 0)
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = Left(nr_volume_dia_formatado(nr_produtor, li_dia) + StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, li_dia)), " "), 9)
    '                    Case 36  ' Extra Cota - Tamnho de 5 Brancos
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = Space(5)
    '                    Case 37  ' Teor de Gordura - Tamnho 4 alinhado à direita
    '                        ' 30/03/2012 - chamado 1527 - Formatar teor de gordura com duas casas decimais - i
    '                        'nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 1)
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 2)
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = Left(StrDup(4 - Len(nr_volume_dia_formatado(nr_produtor, li_dia)), " ") + nr_volume_dia_formatado(nr_produtor, li_dia), 4)
    '                        ' 30/03/2012 - chamado 1527 - Formatar teor de gordura com duas casas decimais - f
    '                    Case Else ' Dia 01 a 31 - Tamnho de 6 alinhados à direita
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = FormatNumber(0, 0)
    '                        nr_volume_dia_formatado(nr_produtor, li_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(nr_produtor, li_dia)), " ") + nr_volume_dia_formatado(nr_produtor, li_dia), 6)
    '                End Select

    '            Next

    '            li_dia = li
    '            id_propriedade_anterior = dsMapaLeite.Tables(0).Rows(li).Item("id_propriedade")

    '            'For li_dia = 0 To dsMapaLeite.Tables(0).Rows.Count - 1   ' Le os dias da Propriedade
    '            For li_dia = li To dsMapaLeite.Tables(0).Rows.Count - 1   ' 19/09/2008 - Le os dias da Propriedade
    '                If dsMapaLeite.Tables(0).Rows(li_dia).Item("id_propriedade") = id_propriedade_anterior Then

    '                    'fran 15/07/2012 i 'soma volume dia
    '                    If nr_dia = dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia") Then
    '                        nr_volume = nr_volume + dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_volume")
    '                    Else
    '                        nr_volume = dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_volume")
    '                    End If
    '                    'fran 15/07/2012 f
    '                    nr_dia = dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia")

    '                    nr_volume_dia(nr_produtor, nr_dia) = dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_volume")
    '                    nr_volume_dia(10, nr_dia) = nr_volume_dia(10, nr_dia) + nr_volume_dia(nr_produtor, nr_dia)  ' Totalizador 10 (dia)

    '                    ' Fran 15/02/2012 chamado 1496  - i
    '                    'nr_volume_dia_formatado(nr_produtor, nr_dia) = FormatNumber(dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_volume"), 0)
    '                    'nr_volume_dia_formatado(nr_produtor, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(nr_produtor, nr_dia)), " ") + nr_volume_dia_formatado(nr_produtor, nr_dia), 6)

    '                    '' 20081124 - i
    '                    'nr_volume_dia_formatado(10, nr_dia) = FormatNumber(nr_volume_dia(10, nr_dia), 0)
    '                    'nr_volume_dia_formatado(10, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(10, nr_dia)), " ") + nr_volume_dia_formatado(10, nr_dia), 6)
    '                    '' 20081124 - f
    '                    'fran 15/07/2012 i 'soma volume dia
    '                    'nr_volume_dia_formatado(nr_produtor, nr_dia) = FormatNumber(dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_volume"), 0)
    '                    nr_volume_dia_formatado(nr_produtor, nr_dia) = FormatNumber(nr_volume, 0)
    '                    'fran 15/07/2012 f 'soma volume dia
    '                    If Len(nr_volume_dia_formatado(nr_produtor, nr_dia)) > 6 Then  ' Fran 15/02/2012 chamado 1496 
    '                        nr_volume_dia_formatado(nr_produtor, nr_dia) = Left(Mid(nr_volume_dia_formatado(nr_produtor, nr_dia), 1, 3) + Mid(nr_volume_dia_formatado(nr_produtor, nr_dia), 5, 3), 6)
    '                    End If
    '                    If Len(nr_volume_dia_formatado(nr_produtor, nr_dia)) > 6 Then   ' Fran 15/02/2012 chamado 1496 
    '                        nr_volume_dia_formatado(nr_produtor, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(nr_produtor, nr_dia)), " ") + nr_volume_dia_formatado(nr_produtor, nr_dia), 6)
    '                    End If

    '                    nr_volume_dia_formatado(nr_produtor, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(nr_produtor, nr_dia)), " ") + nr_volume_dia_formatado(nr_produtor, nr_dia), 6)

    '                    ' 20081124 - i
    '                    nr_volume_dia_formatado(10, nr_dia) = FormatNumber(nr_volume_dia(10, nr_dia), 0)
    '                    If Len(nr_volume_dia_formatado(10, nr_dia)) > 6 Then    ' Fran 15/02/2012 chamado 1496 
    '                        nr_volume_dia_formatado(10, nr_dia) = Left(Mid(nr_volume_dia_formatado(10, nr_dia), 1, 3) + Mid(nr_volume_dia_formatado(10, nr_dia), 5, 3), 6)
    '                    End If
    '                    If Len(nr_volume_dia_formatado(10, nr_dia)) > 6 Then    ' Fran 15/02/2012 chamado 1496 
    '                        nr_volume_dia_formatado(10, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(10, nr_dia)), " ") + nr_volume_dia_formatado(10, nr_dia), 6)
    '                    End If
    '                    nr_volume_dia_formatado(10, nr_dia) = Left(StrDup(6 - Len(nr_volume_dia_formatado(10, nr_dia)), " ") + nr_volume_dia_formatado(10, nr_dia), 6)
    '                    ' 20081124 - f
    '                    ' Fran 15/02/2012 chamado 1496  - i

    '                    If dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia") <= 15 Then
    '                        nr_volume_dia(nr_produtor, 32) = nr_volume_dia(nr_produtor, 32) + nr_volume_dia(nr_produtor, dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia"))   ' Volume do Mes
    '                        'Fran 24/09/2012 i a somatoria das 1as quinzenas dos produtores deve ser a soma já guardada das quinzenas mais o valor do DIA do produtor
    '                        'nr_volume_dia(10, 32) = nr_volume_dia(10, 32) + nr_volume_dia(nr_produtor, 32) ' Totalizador 10 (1.a Q)
    '                        nr_volume_dia(10, 32) = nr_volume_dia(10, 32) + nr_volume_dia(nr_produtor, nr_dia) ' Totalizador 10 (1.a Q)
    '                        'Fran 24/09/2012 f
    '                    Else
    '                        nr_volume_dia(nr_produtor, 33) = nr_volume_dia(nr_produtor, 33) + nr_volume_dia(nr_produtor, dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia"))   ' Volume do Mes
    '                        'Fran 24/09/2012 i a somatoria das 2as quinzenas dos produtores deve ser a soma já guardada das quinzenas mais o valor do DIA do produtor
    '                        'nr_volume_dia(10, 33) = nr_volume_dia(10, 33) + nr_volume_dia(nr_produtor, 33) ' Totalizador 10 (2.a Q)
    '                        nr_volume_dia(10, 33) = nr_volume_dia(10, 33) + nr_volume_dia(nr_produtor, nr_dia) ' Totalizador 10 (2.a Q)
    '                        'Fran 24/09/2012 f
    '                    End If
    '                    nr_volume_dia(nr_produtor, 34) = nr_volume_dia(nr_produtor, 34) + nr_volume_dia(nr_produtor, dsMapaLeite.Tables(0).Rows(li_dia).Item("nr_dia"))   ' Volume do Mes
    '                    'Fran 24/09/2012 i a somatoria mensal dos produtores deve ser a soma já guardada dos produtores mais o valor do DIA do produtor
    '                    'nr_volume_dia(10, 34) = nr_volume_dia(10, 34) + nr_volume_dia(nr_produtor, 34) ' Totalizador 10 (Mes)
    '                    nr_volume_dia(10, 34) = nr_volume_dia(10, 34) + nr_volume_dia(nr_produtor, nr_dia) ' Totalizador 10 (Mes)
    '                    'Fran 24/09/2012 f
    '                Else
    '                    nr_volume = 0
    '                    Exit For

    '                End If
    '            Next

    '            'Formata Total 1.a Quinzena
    '            nr_volume_dia_formatado(nr_produtor, 32) = Right(FormatNumber(nr_volume_dia(nr_produtor, 32), 0), 9)
    '            nr_volume_dia_formatado(nr_produtor, 32) = Left(StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, 32)), " ") + nr_volume_dia_formatado(nr_produtor, 32), 9)

    '            ' 20081124 - i
    '            'nr_volume_dia_formatado(10, 32) = Left(StrDup(9 - Len(nr_volume_dia_formatado(10, 32)), " ") + nr_volume_dia_formatado(10, 32), 9)
    '            nr_volume_dia_formatado(10, 32) = Right(FormatNumber(nr_volume_dia(10, 32), 0), 9)
    '            nr_volume_dia_formatado(10, 32) = Left(StrDup(9 - Len(nr_volume_dia_formatado(10, 32)), " ") + nr_volume_dia_formatado(10, 32), 9)
    '            ' 20081124 - f

    '            'Formata Total 2.a Quinzena
    '            nr_volume_dia_formatado(nr_produtor, 33) = Right(FormatNumber(nr_volume_dia(nr_produtor, 33), 0), 9)
    '            nr_volume_dia_formatado(nr_produtor, 33) = Left(StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, 33)), " ") + nr_volume_dia_formatado(nr_produtor, 33), 9)
    '            nr_volume_dia_formatado(10, 33) = Right(FormatNumber(nr_volume_dia(10, 33), 0), 9)
    '            nr_volume_dia_formatado(10, 33) = Left(StrDup(9 - Len(nr_volume_dia_formatado(10, 33)), " ") + nr_volume_dia_formatado(10, 33), 9)

    '            'Formata Total Mes
    '            nr_volume_dia_formatado(nr_produtor, 34) = Right(FormatNumber(nr_volume_dia(nr_produtor, 34), 0), 9)
    '            nr_volume_dia_formatado(nr_produtor, 34) = Left(StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, 34)), " ") + nr_volume_dia_formatado(nr_produtor, 34), 9)
    '            nr_volume_dia_formatado(10, 34) = Right(FormatNumber(nr_volume_dia(10, 34), 0), 9)
    '            nr_volume_dia_formatado(10, 34) = Left(StrDup(9 - Len(nr_volume_dia_formatado(10, 34)), " ") + nr_volume_dia_formatado(10, 34), 9)

    '            'Formata Cota igual ao valor do Mes
    '            nr_volume_dia_formatado(nr_produtor, 35) = Right(FormatNumber(nr_volume_dia(nr_produtor, 34), 0), 9)
    '            nr_volume_dia_formatado(nr_produtor, 35) = Left(nr_volume_dia_formatado(nr_produtor, 35) + StrDup(9 - Len(nr_volume_dia_formatado(nr_produtor, 35)), " "), 9)
    '            'Fran 24/09/2012 formata cota igual ao mes
    '            'nr_volume_dia_formatado(10, 35) = Right(FormatNumber(nr_volume_dia(10, 35), 0), 9)
    '            nr_volume_dia_formatado(10, 35) = Right(FormatNumber(nr_volume_dia(10, 34), 0), 9)
    '            nr_volume_dia_formatado(10, 35) = Left(nr_volume_dia_formatado(10, 35) + StrDup(9 - Len(nr_volume_dia_formatado(10, 35)), " "), 9)
    '            'Fran 24/09/2012 f formata cota igual ao mes

    '            nr_produtor = nr_produtor + 1  ' Quantidade de Produtor/Propriedade por página 

    '            li = li_dia - 1     ' 19/09/2008
    '        Next

    '        If nr_produtor <= 10 Then
    '            geraMapaSAP(nr_volume_dia_formatado, ArquivoTexto)
    '        End If

    '        liexportada = liexportada + 1

    '        Me.nr_linhaslidas = li
    '        Me.nr_linhasexportadas = liexportada

    '        ArquivoTexto.Close()
    '        exportMapaLeiteSAP = True

    '    Catch ex As Exception
    '        exportMapaLeiteSAP = False
    '        ArquivoTexto.Close()
    '        Throw New Exception(ex.Message)

    '    End Try
    '    ' 01/02/2012 - Projeto Themis - i

    'End Function
    'Private Sub geraMapaSAP(ByVal nr_volume_dia_formatado(,) As String, ByVal ArquivoTexto As StreamWriter)

    '    ' 06/02/2012 - Projeto Themis - i

    '    'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

    '    Try
    '        Dim i As Int16

    '        Dim ds_endereco_dan As String
    '        Dim ds_municipio_dan As String
    '        Dim ds_inscricao_dan As String
    '        Dim ds_cnpj_dan As String
    '        Dim nr_mapa_leite As String
    '        Dim nr_mes As String
    '        Dim nr_ano As String
    '        Dim nr_produtor As Int16


    '        '===============================================================
    '        ' Formata Dados do Estabelecimento
    '        '===============================================================
    '        Dim estabelecimento As New Estabelecimento(Me.id_estabelecimento)


    '        ds_endereco_dan = estabelecimento.ds_endereco + ", " + CStr(estabelecimento.nr_endereco)
    '        ds_endereco_dan = Left(ds_endereco_dan + StrDup(55 - Len(ds_endereco_dan), " "), 55)

    '        ds_municipio_dan = estabelecimento.nm_cidade
    '        ds_municipio_dan = Left(ds_municipio_dan + StrDup(30 - Len(ds_municipio_dan), " "), 30)

    '        ds_inscricao_dan = estabelecimento.cd_inscricao_estadual
    '        ds_inscricao_dan = Left(ds_inscricao_dan + StrDup(30 - Len(ds_inscricao_dan), " "), 30)

    '        ds_cnpj_dan = estabelecimento.cd_cnpj
    '        ds_cnpj_dan = Left(ds_cnpj_dan + StrDup(18 - Len(ds_cnpj_dan), " "), 18)

    '        nr_mapa_leite = FormatNumber(estabelecimento.getEstabelecimentoNumeroMapa, 0)  ' Próximo Número
    '        nr_mapa_leite = Left(nr_mapa_leite + StrDup(9 - Len(nr_mapa_leite), " "), 9)

    '        ' 12/03/2012 - Mirella - retira espaços em branco da esquerda dos campos de valores - i
    '        nr_mapa_leite = Trim(nr_mapa_leite)

    '        nr_mes = DateTime.Parse(Me.dt_referencia).ToString("MM")
    '        nr_ano = DateTime.Parse(Me.dt_referencia).ToString("yyyy")

    '        'For i = 1 To 2
    '        'Fran 12/03/2009 i rls17 - Estas linhas estão desabilitadas no esre0027rp.p (fonte)
    '        'linhatexto = linhatexto + Chr(27) + "&l0O" + Chr(27) + "&l26A" + Chr(27) + "&l1H" + Chr(27) + "&a0P" + Chr(27) + "&f59Y" + Chr(27) + "&n7W" + Chr(5) + "LEITE1" + Chr(27) + "&f2xS" + Chr(27) + "&u300D"
    '        'linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p8v4s3b4148T"
    '        'Fran 12/03/2009 f rls17

    '        'If i = 1 Then
    '        '    linhatexto = linhatexto + Chr(27) + "&l0O" + Chr(27) + "&l26A" + Chr(27) + "&l8H" + Chr(27) + "&a0P" + Chr(27) + "&f59Y" + Chr(27) + "&n7W" + Chr(5) + "LEITE1" + Chr(27) + "&f2xS" + Chr(27) + "&u300D"
    '        '    linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p8v4s3b4148T"
    '        '    linhatexto = linhatexto + Chr(27) + "*p2188x155Y" + "1a VIA - EMITENTE"
    '        'Else
    '        '    linhatexto = linhatexto + Chr(27) + "&l0O" + Chr(27) + "&l26A" + Chr(27) + "&l1H" + Chr(27) + "&a0P" + Chr(27) + "&f59Y" + Chr(27) + "&n7W" + Chr(5) + "LEITE1" + Chr(27) + "&f2xS" + Chr(27) + "&u300D"
    '        '    linhatexto = linhatexto + Chr(27) + "(19U" + Chr(27) + "(s1p8v4s3b4148T"
    '        '    linhatexto = linhatexto + Chr(27) + "*p2188x155Y" + "2a VIA - CONTROLE"
    '        'End If

    '        '===============================================
    '        ' REGISTRO TIPO 1
    '        '===============================================

    '        linhatexto = linhatexto + "1" + ";" '1 - Registro Tipo (fixo) 

    '        linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 

    '        linhatexto = linhatexto + nr_mapa_leite + ";" '3 - numero do mapa de leite
    '        linhatexto = linhatexto + "001" + ";" '4 - Sequencia (Fixo)
    '        linhatexto = linhatexto + ds_municipio_dan + ";" ' 5 - Municipio Estabelecimento
    '        linhatexto = linhatexto + ds_endereco_dan + ";"  ' 6 - Entdereço do Estabelecimento 

    '        linhatexto = linhatexto + ds_inscricao_dan + ";"  ' 7- Inscrição Estadual Estabelecimento 
    '        linhatexto = linhatexto + ds_cnpj_dan + ";" ' 8 - CNPJ do Estabelecimento


    '        linhatexto = linhatexto + ds_municipio_prod + ";" ' 9 - Municipio Produtor 
    '        linhatexto = linhatexto + nr_mes + ";" ' 10 - Mes Refêrencia
    '        linhatexto = linhatexto + nr_ano + ";" ' 11 - Ano Refêrencia
    '        linhatexto = linhatexto + CStr(estabelecimento.ds_aidf) + ";" '12 AIDF Mapa Leite 
    '        linhatexto = linhatexto + "MAPA DE RECEBIMENTO DE LEITE" + ";" '13 Tipo do Formulário 

    '        'linhatexto = linhatexto + nm_transportador + ";" '?
    '        'linhatexto = linhatexto + cd_insc_transportador + ";" ' ?

    '        ArquivoTexto.WriteLine(linhatexto)
    '        linhatexto = ""

    '        '===============================================
    '        ' REGISTRO TIPO 2
    '        '===============================================

    '        linhatexto = linhatexto + "2" + ";" '1 - Registro Tipo (fixo)
    '        linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 

    '        linhatexto = linhatexto + nr_mapa_leite + ";" '3 - Numero do Mapa Leite

    '        linhatexto = linhatexto + "001" + ";" '4 - Sequencia (fixo)
    '        'fran 15/07/2012 i deve enviar nm transportadora
    '        'linhatexto = linhatexto + estabelecimento.cd_codigo_sap + ";" '5 - Transportadora (codigo da transportadora SAP)
    '        linhatexto = linhatexto + nm_transportador + ";" '5 - Transportadora (codigo da transportadora SAP)
    '        'fran 15/07/2012 f deve enviar nm transportadora

    '        linhatexto = linhatexto + ";" '6 numero da rota
    '        'fran 15/07/2012 i deve enviar rota
    '        linhatexto = linhatexto + cd_insc_transportador + ";"  '7 descricao da rota
    '        'fran 15/07/2012 f deve enviar rota

    '        ArquivoTexto.WriteLine(linhatexto)
    '        linhatexto = ""
    '        '===============================================
    '        ' REGISTRO TIPO 3
    '        '===============================================

    '        '===============================================================
    '        ' LINHA 1*
    '        '===============================================================

    '        nr_produtor = 1

    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
    '        For li_dia As Int16 = 1 To 37
    '            nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
    '        Next
    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

    '        linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
    '        linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
    '        linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

    '        linhatexto = linhatexto + "001" + ";" '4 - Sequencia
    '        linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
    '        linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
    '        'linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" '7 - Codigo do Produtor
    '        linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
    '        linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

    '        ArquivoTexto.WriteLine(linhatexto)
    '        linhatexto = ""
    '        '/* LINHA 2*/
    '        nr_produtor = 2

    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
    '        For li_dia As Int16 = 1 To 37
    '            nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
    '        Next
    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

    '        linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
    '        linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
    '        linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

    '        linhatexto = linhatexto + "002" + ";" '4 - Sequencia
    '        linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
    '        linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
    '        linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
    '        linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

    '        ' 15/03/2012 -Corrigido pelo retorno da França - i 
    '        'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
    '        ' 15/03/2012 -Corrigido pelo retorno da França - f 
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

    '        ArquivoTexto.WriteLine(linhatexto)
    '        linhatexto = ""

    '        '/* LINHA 3*/
    '        nr_produtor = 3

    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
    '        For li_dia As Int16 = 1 To 37
    '            nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
    '        Next
    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

    '        linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
    '        linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
    '        linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

    '        linhatexto = linhatexto + "003" + ";" '4 - Sequencia
    '        linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
    '        linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
    '        linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
    '        linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

    '        ' 15/03/2012 -Corrigido pelo retorno da França - i 
    '        'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
    '        ' 15/03/2012 -Corrigido pelo retorno da França - i 
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

    '        ArquivoTexto.WriteLine(linhatexto)
    '        linhatexto = ""

    '        '/* LINHA 4*/
    '        nr_produtor = 4

    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
    '        For li_dia As Int16 = 1 To 37
    '            nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
    '        Next
    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

    '        linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
    '        linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
    '        linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

    '        linhatexto = linhatexto + "004" + ";" '4 - Sequencia
    '        linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
    '        linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
    '        linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
    '        linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

    '        ' 15/03/2012 -Corrigido pelo retorno da França - i 
    '        'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
    '        ' 15/03/2012 -Corrigido pelo retorno da França - f 
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

    '        ArquivoTexto.WriteLine(linhatexto)
    '        linhatexto = ""

    '        '/* LINHA 5*/
    '        nr_produtor = 5

    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
    '        For li_dia As Int16 = 1 To 37
    '            nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
    '        Next
    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

    '        linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
    '        linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
    '        linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

    '        linhatexto = linhatexto + "005" + ";" '4 - Sequencia
    '        linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
    '        linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
    '        linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
    '        linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

    '        ' 15/03/2012 -Corrigido pelo retorno da França - i 
    '        'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
    '        ' 15/03/2012 -Corrigido pelo retorno da França - f 
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

    '        ArquivoTexto.WriteLine(linhatexto)
    '        linhatexto = ""

    '        '/* LINHA 6*/
    '        nr_produtor = 6

    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
    '        For li_dia As Int16 = 1 To 37
    '            nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
    '        Next
    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

    '        linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
    '        linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
    '        linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

    '        linhatexto = linhatexto + "006" + ";" '4 - Sequencia
    '        linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
    '        linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
    '        linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
    '        linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

    '        ' 15/03/2012 -Corrigido pelo retorno da França - i 
    '        'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
    '        ' 15/03/2012 -Corrigido pelo retorno da França - f 
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

    '        ArquivoTexto.WriteLine(linhatexto)
    '        linhatexto = ""

    '        '/* LINHA 7*/
    '        nr_produtor = 7

    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
    '        For li_dia As Int16 = 1 To 37
    '            nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
    '        Next
    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

    '        linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
    '        linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
    '        linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

    '        linhatexto = linhatexto + "007" + ";" '4 - Sequencia
    '        linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
    '        linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
    '        linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
    '        linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

    '        ' 15/03/2012 -Corrigido pelo retorno da França - i 
    '        'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
    '        ' 15/03/2012 -Corrigido pelo retorno da França - f 
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

    '        ArquivoTexto.WriteLine(linhatexto)
    '        linhatexto = ""
    '        '/* LINHA 8*/
    '        nr_produtor = 8

    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
    '        For li_dia As Int16 = 1 To 37
    '            nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
    '        Next
    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

    '        linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
    '        linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
    '        linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

    '        linhatexto = linhatexto + "008" + ";" '4 - Sequencia
    '        linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
    '        linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
    '        linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
    '        linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

    '        ' 15/03/2012 -Corrigido pelo retorno da França - i 
    '        'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
    '        ' 15/03/2012 -Corrigido pelo retorno da França - f 
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

    '        ArquivoTexto.WriteLine(linhatexto)
    '        linhatexto = ""

    '        '/* LINHA 9*/
    '        nr_produtor = 9

    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
    '        For li_dia As Int16 = 1 To 37
    '            nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
    '        Next
    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

    '        linhatexto = linhatexto + "3" + ";" '1 - Registro Tipo (fixo)
    '        linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
    '        linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite

    '        linhatexto = linhatexto + "009" + ";" '4 - Sequencia
    '        linhatexto = linhatexto + nm_produtor(nr_produtor) + ";" '5 - Nome do Produtor
    '        linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";" '6 - Inscricao do Produtor
    '        linhatexto = linhatexto + cd_produtor(nr_produtor) + ";" '15/03/2012 - corrigido pelo retorno da França - 7 - Codigo do Produtor SAP 
    '        linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";" '8 - Codigo da Propriedade

    '        ' 15/03/2012 -Corrigido pelo retorno da França - i 
    '        'linhatexto = linhatexto + nm_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_insc_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_produtor(nr_produtor) + ";"
    '        'linhatexto = linhatexto + cd_propriedade(nr_produtor) + ";"
    '        ' 15/03/2012 -Corrigido pelo retorno da França - f 
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

    '        ArquivoTexto.WriteLine(linhatexto)
    '        linhatexto = ""


    '        '==================================================
    '        ' Registro tipo 4
    '        '==================================================
    '        '/* LINHA 10*/
    '        nr_produtor = 10

    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - i
    '        For li_dia As Int16 = 1 To 37
    '            nr_volume_dia_formatado(nr_produtor, li_dia) = Trim(nr_volume_dia_formatado(nr_produtor, li_dia))
    '        Next
    '        ' 12/03/2012 - adri - retira espaços em branco da esquerda dos campos de valores - f

    '        linhatexto = linhatexto + "4" + ";" '1 - Registro Tipo (fixo)
    '        linhatexto = linhatexto + estabelecimento.cd_codigo_SAP + ";" ' 2 - Estabelecimento 
    '        linhatexto = linhatexto + nr_mapa_leite + ";"     ' 3 - numero do mapa de leite
    '        linhatexto = linhatexto + "001" + ";" '4 - Sequencia

    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 1) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 2) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 3) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 4) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 5) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 6) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 7) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 8) + ";"

    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 9) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 10) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 11) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 12) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 13) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 14) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 15) + ";"

    '        'linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";" fran 24/09/2012 i o totalizador da quinzena fica no fim como layout

    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 16) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 17) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 18) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 19) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 20) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 21) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 22) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 23) + ";"

    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 24) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 25) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 26) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 27) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 28) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 29) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 30) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 31) + ";"

    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 32) + ";" 'fran 24/09/2012 i o totalizador da quinzena fica no fim como layout

    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 33) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 34) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 35) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 36) + ";"
    '        linhatexto = linhatexto + nr_volume_dia_formatado(nr_produtor, 37) + ";"

    '        ArquivoTexto.WriteLine(linhatexto)
    '        linhatexto = ""
    '        'linhatexto = linhatexto + CStr(estabelecimento.ds_aidf)


    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Sub


    ' adri 03/05/2016 - Extrato Anual Web - i
    Public Function getMapaLeiteAnoReferencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMapaLeiteAnoReferencia", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    ' adri 03/05/2016 - Extrato Anual Web - f
    Public Function getRelatorioSIF() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioSif", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    Public Function getRelatorioSIFbyDia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioSifbyDia", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    Public Function getRelatorioSIFbyDiaCooperativa() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRelatorioSifbyDiaCooperativa", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
End Class
