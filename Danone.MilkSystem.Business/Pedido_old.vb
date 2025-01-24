Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
<Serializable()> Public Class Pedido
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _dt_processamento As String
    Private _dt_vencimento As String
    Private _id_portador As Int32
    Private _nm_arquivo As String
    Private _st_exportacao As String
    Private _nr_linhaslidas As Int32
    Private _nr_linhasexportadas As Int32


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

    Public Property id_portador() As Int32
        Get
            Return _id_portador
        End Get
        Set(ByVal value As Int32)
            _id_portador = value
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


    Public Sub New()

    End Sub


    Public Sub exportPagtoFornecedor()

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

            Dim dsCentralPedidoPagtoFornecedor As DataSet = Me.getCentralPedidoPagtoFornecedorByFilters()


            For li = 0 To dsCentralPedidoPagtoFornecedor.Tables(0).Rows.Count - 1
                linhatexto = "100"
                linhatexto = linhatexto + "001"
                linhatexto = linhatexto + dsCentralPedidoPagtoFornecedor.Tables(0).Rows(li).Item("cd_estabelecimento")     ' Confirmar Código do Estabelecimento EMS
                linhatexto = linhatexto + "AE"
                linhatexto = linhatexto + "     "

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

                ' 19/11/2008 - Atualiza Data e Status de Exportação
                Me.id_adiantamento = dsFichaFinanceira.Tables(0).Rows(li).Item("id_adiantamento")
                Me.updateAdiantamentoExportacao()   ' Atualiza Status=S e data de exportacao

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
    Public Function getCentralPedidoPagtoFornecedorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralPedidoPagtoFornecedor", parameters, "ms_central_pagto_fornecedor")
            Return dataSet

        End Using

    End Function

End Class
