Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class Adiantamento

    Private _id_adiantamento As Int32
    Private _dt_referencia As String
    Private _id_propriedade As Int32
    Private _id_tecnico As Int32
    Private _nr_percentual_adto As Decimal
    Private _nr_valor_adto As Decimal
    Private _st_aprovado As String
    Private _id_adiantamento_justificativa As Int32
    Private _id_portador As Int32
    Private _nr_volume_mensal As Decimal
    Private _nr_valor_disponivel As Decimal
    Private _nr_valor_descontos As Decimal
    Private _nr_valor_pedidos_abertos As Decimal 'fran fase 2 melhoria
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _st_selecao As String
    Private _dt_processamento As String   ' 11/11/2008 - Exportar Adto
    Private _dt_vencimento As String      ' 11/11/2008 - Exportar Adto
    Private _st_exportacao As String      ' 19/11/2008
    Private _nm_arquivo As String
    Private _nr_linhaslidas As Int32
    Private _nr_linhasexportadas As Int32
    Private _nr_valor_mensal As Decimal             ' 25/11/2009 - Chamado 499
    Private _nr_valor_descontos_sem_adto As Decimal ' 25/11/2009 - Chamado 499
    Private _ds_produtor As String                  ' 01/12/2009 - Adri chamado 522 Maracanau
    Private _ds_propriedade As String               ' 01/12/2009 - Adri chamado 522 Maracanau
    Private _ds_tecnico As String                   ' 01/12/2009 - Adri chamado 522 Maracanau
    Private _st_adiantamento As String              '08/2017 i Fran indica se é adiantamento ou antecipacao (conta 0700)
    Private _id_ficha_financeira As Int32 '08/2017 i Fran indica se é adiantamento ou antecipacao (conta 0700)


    Public Property id_adiantamento() As Int32
        Get
            Return _id_adiantamento
        End Get
        Set(ByVal value As Int32)
            _id_adiantamento = value
        End Set
    End Property
    Public Property id_ficha_financeira() As Int32
        Get
            Return _id_ficha_financeira
        End Get
        Set(ByVal value As Int32)
            _id_ficha_financeira = value
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

    Public Property st_adiantamento() As String
        Get
            Return _st_adiantamento
        End Get
        Set(ByVal value As String)
            _st_adiantamento = value
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
    Public Property id_tecnico() As Int32
        Get
            Return _id_tecnico
        End Get
        Set(ByVal value As Int32)
            _id_tecnico = value
        End Set
    End Property

    Public Property nr_percentual_adto() As Decimal
        Get
            Return _nr_percentual_adto
        End Get
        Set(ByVal value As Decimal)
            _nr_percentual_adto = value
        End Set
    End Property
    Public Property nr_valor_pedidos_abertos() As Decimal
        Get
            Return _nr_valor_pedidos_abertos
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_pedidos_abertos = value
        End Set
    End Property
    Public Property nr_valor_adto() As Decimal
        Get
            Return _nr_valor_adto
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_adto = value
        End Set
    End Property

    Public Property st_aprovado() As String
        Get
            Return _st_aprovado
        End Get
        Set(ByVal value As String)
            _st_aprovado = value
        End Set
    End Property

    Public Property id_adiantamento_justificativa() As Int32
        Get
            Return _id_adiantamento_justificativa
        End Get
        Set(ByVal value As Int32)
            _id_adiantamento_justificativa = value
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
    Public Property nr_volume_mensal() As Decimal
        Get
            Return _nr_volume_mensal
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_mensal = value
        End Set
    End Property
    Public Property nr_valor_disponivel() As Decimal
        Get
            Return _nr_valor_disponivel
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_disponivel = value
        End Set
    End Property
    Public Property nr_valor_descontos() As Decimal
        Get
            Return _nr_valor_descontos
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_descontos = value
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


    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
        End Set
    End Property
    Public Property st_selecao() As String
        Get
            Return _st_selecao
        End Get
        Set(ByVal value As String)
            _st_selecao = value
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
    Public Property st_exportacao() As String
        Get
            Return _st_exportacao
        End Get
        Set(ByVal value As String)
            _st_exportacao = value
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
    Public Property nr_linhasexportadas() As Int32
        Get
            Return _nr_linhasexportadas
        End Get
        Set(ByVal value As Int32)
            _nr_linhasexportadas = value
        End Set
    End Property
    Public Property nr_valor_descontos_sem_adto() As Decimal
        Get
            Return _nr_valor_descontos_sem_adto
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_descontos_sem_adto = value
        End Set
    End Property
    Public Property nr_valor_mensal() As Decimal
        Get
            Return _nr_valor_mensal
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_mensal = value
        End Set
    End Property
    ' 01/12/2009 - Adri chamado 522 Maracanau - i
    Public Property ds_produtor() As String
        Get
            Return _ds_produtor
        End Get
        Set(ByVal value As String)
            _ds_produtor = value
        End Set
    End Property
    Public Property ds_tecnico() As String
        Get
            Return _ds_tecnico
        End Get
        Set(ByVal value As String)
            _ds_tecnico = value
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
    ' 01/12/2009 - Adri chamado 522 Maracanau - f
    Public Sub New(ByVal id As Int32)

        Me.id_adiantamento = id
        loadAdiantamento()

    End Sub



    Public Sub New()

    End Sub


    Public Function getAdiantamentoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAdiantamentos", parameters, "ms_adiantamento")
            Return dataSet

        End Using

    End Function

    Private Sub loadAdiantamento()

        'Dim dataSet As DataSet = getAdiantamentoByFilters()
        Dim dataSet As DataSet = getAdiantamentoNovo()  ' 01/12/2009 Chamado 522
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    ' Adri 01/12/2009 - CHamado 522 - i
    Public Function getAdiantamentoNovo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAdiantamentoNovo", parameters, "ms_adiantamento")
            Return dataSet

        End Using

    End Function
    Public Function insertAdiantamentoNovo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAdiantamentoNovo", parameters, ExecuteType.Insert), Int32)

        End Using
        ' Adri 01/12/2009 - CHamado 522 - f


    End Function

    Public Function insertAdiantamento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAdiantamentos", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateAdiantamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAdiantamentos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAdiantamentoAprovarTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAdiantamentosAprovarTodos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAdiantamentoStatus()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAdiantamentosStatus", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateAdiantamentoVolumeLeite()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAdiantamentosVolumeLeite", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAdiantamentoDescontos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAdiantamentosDescontos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAdiantamentoValorDisponivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAdiantamentosValorDisponivel", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateAdiantamentoValorDisponivelAnalitico()
        ' 25/11/2009 - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAdiantamentosValorDisponivelAnalitico", parameters, ExecuteType.Update)

        End Using
        ' 25/11/2009 - f

    End Sub

    Public Sub deleteAdiantamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteAdiantamento", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function getAdiantamentoValorTotal() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getAdiantamentosValorTotal", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Sub updateAdiantamentoSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAdiantamentoSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAdiantamentoAprovarSelecionados()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAdiantamentoAprovarSelecionados", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAdiantamentoTodos1N()
        Using data As DataAccess = New DataAccess()
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAdiantamentoTodos1N", parameters, ExecuteType.Update)
        End Using
    End Sub

    Public Sub updateAdiantamentoTodos2N()
        Using data As DataAccess = New DataAccess()
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAdiantamentoTodos2N", parameters, ExecuteType.Update)
        End Using
    End Sub
    Public Sub exportAdiantamento()

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

            Dim dsFichaFinanceira As DataSet = Me.getExportacaoAdtoByFilters()


            For li = 0 To dsFichaFinanceira.Tables(0).Rows.Count - 1
                linhatexto = "100"
                linhatexto = linhatexto + "001"
                linhatexto = linhatexto + dsFichaFinanceira.Tables(0).Rows(li).Item("cd_estabelecimento")     ' Confirmar Código do Estabelecimento EMS
                linhatexto = linhatexto + "AE"      ' 11/11/2008
                linhatexto = linhatexto + "     "   ' 11/11/2008 

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
    Public Function getExportacaoAdtoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoAdto", parameters, "ms_adiantamento")
            Return dataSet

        End Using

    End Function
    Public Function getExportacaoAntecipacao() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoAntecipacao", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function

    Public Function getAdiantamentoSequencia() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getAdiantamentoSequencia", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Function getAdiantamentosSelecionados() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAdiantamentosSelecionados", parameters, "ms_adiantamento")
            Return dataSet

        End Using

    End Function
    Public Sub updateAdiantamentoExportacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAdiantamentoExportacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateAntecipacaoExportacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAntecipacaoExportacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getAdiantamentoTodos() As DataSet

        ' 17/02/2009 Rls16 - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAdiantamentosTodos", parameters, "ms_adiantamento")
            Return dataSet

        End Using
        ' 17/02/2009 Rls16 - f

    End Function
    '08/03/2012 - Projeto Themis - i
    Public Sub exportAdiantamentoSAP()

        ' 14/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - i
        'Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo)

        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        Dim ArquivoTexto As New StreamWriter(Me.nm_arquivo, False, utf8WithoutBom)
        ' 14/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - f

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
            Dim dsFichaFinanceira As DataSet
            'fran 08/2017   i
            'Dim dsFichaFinanceira As DataSet = Me.getExportacaoAdtoByFilters()
            If Me.st_adiantamento = "S" Then
                dsFichaFinanceira = Me.getExportacaoAdtoByFilters()
            Else
                dsFichaFinanceira = Me.getExportacaoAntecipacao
            End If
            'fran 08/2017 f

            For li = 0 To dsFichaFinanceira.Tables(0).Rows.Count - 1
                linhatexto = "100"
                linhatexto = linhatexto + "001"
                'linhatexto = linhatexto + dsFichaFinanceira.Tables(0).Rows(li).Item("cd_estabelecimento")     ' Confirmar Código do Estabelecimento EMS

                ' 30/03/2012 - Chamado 1526 - Se não tiver a planta, deixar 0000 - i
                If Trim(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_estabelecimento_sap").ToString) = "" Then
                    linhatexto = linhatexto + "0000"
                Else
                    linhatexto = linhatexto + Trim(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_estabelecimento_sap").ToString)     ' Projeto Themis
                End If
                ' 30/03/2012 - Chamado 1526 - Se não tiver a planta, deixar 0000 - f

                'linhatexto = linhatexto + "AE"      ' 11/11/2008
                'linhatexto = linhatexto + "     "   ' 11/11/2008 

                'nr_sequencial = CStr(Me.getAdiantamentoSequencia())  ' Pega próxima sequencia para exportação
                'nr_sequencial = Left(nr_sequencial + StrDup(16 - Len(nr_sequencial), " "), 16)
                'linhatexto = linhatexto + nr_sequencial

                'linhatexto = linhatexto + "01"

                'cd_pessoa = dsFichaFinanceira.Tables(0).Rows(li).Item("cd_pessoa")
                cd_pessoa = dsFichaFinanceira.Tables(0).Rows(li).Item("cd_pessoa_sap").ToString  ' Projeto Themis
                'cd_pessoa = Left(StrDup(9 - Len(cd_pessoa), "0") + cd_pessoa, 9)
                cd_pessoa = Left(StrDup(10 - Len(cd_pessoa), "0") + cd_pessoa, 10)
                linhatexto = linhatexto + cd_pessoa

                'linhatexto = linhatexto + "01"

                'linhatexto = linhatexto + "CPAG" + DateTime.Parse(Me.dt_referencia.ToString).ToString("yyyyMM") ' 11/11/2008

                linhatexto = linhatexto + DateTime.Parse(Me.dt_processamento.ToString).ToString("ddMMyyyy") ' 11/11/2008
                linhatexto = linhatexto + DateTime.Parse(Me.dt_processamento.ToString).ToString("ddMMyyyy") ' 11/11/2008
                linhatexto = linhatexto + DateTime.Parse(Me.dt_vencimento.ToString).ToString("ddMMyyyy") ' 11/11/2008

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

                'linhatexto = linhatexto + Space(8)
                'linhatexto = linhatexto + Space(8)
                'linhatexto = linhatexto + Space(8)
                'linhatexto = linhatexto + StrDup(12, "0") ' Valor do Desconto

                'valor_adto = CStr(Round(dsFichaFinanceira.Tables(0).Rows(li).Item("valor_adto"), 2))
                'lpos = InStr(1, valor_adto, ",", 1)
                'If lpos = 0 Then   ' Se não tem casas decimais
                '    valor_adto = CStr(valor_adto)
                '    valor_adto = Left(StrDup(10 - Len(valor_adto), "0") + valor_adto, 10)
                '    valor_adto = valor_adto & "00"
                'Else
                '    valor_adto_int = CStr(Left(valor_adto, lpos - 1))  ' Pegar somente o valor inteiro
                '    valor_adto_int = Left(StrDup(10 - Len(valor_adto_int), "0") + valor_adto_int, 10)
                '    valor_adto_dec = CStr(Mid(CStr(valor_adto), lpos + 1))  ' Pegar somente o valor decimal
                '    valor_adto_dec = Left(valor_adto_dec + StrDup(2 - Len(valor_adto_dec), "0"), 2)
                '    valor_adto = valor_adto_int & valor_adto_dec
                'End If
                'linhatexto = linhatexto + valor_adto ' Valor do Adiantamento
                'linhatexto = linhatexto + Space(8)
                'linhatexto = linhatexto + "11406001"
                'linhatexto = linhatexto + StrDup(8, "0")
                'linhatexto = linhatexto + "01"

                'linhatexto = linhatexto + DateTime.Parse(Me.dt_vencimento.ToString).ToString("ddMMyyyy") ' 11/11/2008

                'linhatexto = linhatexto + Space(12)
                'linhatexto = linhatexto + "5"
                'linhatexto = linhatexto + Space(80)

                ''linhatexto = linhatexto + "88888"   
                'linhatexto = linhatexto + dsFichaFinanceira.Tables(0).Rows(li).Item("nm_portador")   ' 11/11/2008

                'linhatexto = linhatexto + "00"
                'linhatexto = linhatexto + "01"
                'linhatexto = linhatexto + "02"
                'linhatexto = linhatexto + StrDup(9, "0")
                'linhatexto = linhatexto + StrDup(8, "0")
                'linhatexto = linhatexto + "N"
                'linhatexto = linhatexto + "N"
                'linhatexto = linhatexto + "1"       ' 11/11/2008
                'linhatexto = linhatexto + Space(2)
                'linhatexto = linhatexto + Space(5)
                'linhatexto = linhatexto + Space(16)
                'linhatexto = linhatexto + Space(2)
                'linhatexto = linhatexto + StrDup(4, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(14, "0")
                'linhatexto = linhatexto + StrDup(13, "0")
                'linhatexto = linhatexto + Space(60)
                'linhatexto = linhatexto + Space(12)
                'linhatexto = linhatexto + Space(40)
                'linhatexto = linhatexto + Space(8)
                'linhatexto = linhatexto + StrDup(5, "0")
                'linhatexto = linhatexto + StrDup(9, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(3, "0")
                'linhatexto = linhatexto + StrDup(8, "0")
                'linhatexto = linhatexto + StrDup(8, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + "N"
                'linhatexto = linhatexto + "N"
                'linhatexto = linhatexto + StrDup(13, "0")
                'linhatexto = linhatexto + StrDup(13, "0")
                'linhatexto = linhatexto + StrDup(17, "0")

                ''CNPJ
                'cd_cnpj = Trim(dsFichaFinanceira.Tables(0).Rows(li).Item("cd_cnpj"))
                'cd_cnpj = Left(cd_cnpj + StrDup(19 - Len(cd_cnpj), " "), 19)
                'linhatexto = linhatexto + cd_cnpj

                'linhatexto = linhatexto + StrDup(14, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + "201"
                'linhatexto = linhatexto + DateTime.Parse(Me.dt_vencimento.ToString).ToString("ddMMyyyy") ' 11/11/2008
                'linhatexto = linhatexto + StrDup(3, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + Space(8)
                'linhatexto = linhatexto + StrDup(2, "0")
                'linhatexto = linhatexto + "N"
                'linhatexto = linhatexto + Space(20)
                'linhatexto = linhatexto + StrDup(3, "0")
                'linhatexto = linhatexto + StrDup(5, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + DateTime.Parse(Me.dt_vencimento.ToString).ToString("ddMMyyyy") ' 11/11/2008
                'linhatexto = linhatexto + StrDup(7, "0")
                'linhatexto = linhatexto + StrDup(5, "0")
                'linhatexto = linhatexto + Space(20)
                'linhatexto = linhatexto + StrDup(3, "0")
                'linhatexto = linhatexto + "N"
                'linhatexto = linhatexto + StrDup(13, "0")
                'linhatexto = linhatexto + Space(8)
                'linhatexto = linhatexto + "N"
                'linhatexto = linhatexto + StrDup(6, "0")
                'linhatexto = linhatexto + "08"          ' 11/11/2008
                'linhatexto = linhatexto + Space(17)     ' 11/11/2008
                'linhatexto = linhatexto + Space(17)
                'linhatexto = linhatexto + StrDup(4, "0")
                'linhatexto = linhatexto + StrDup(13, "0")
                'linhatexto = linhatexto + StrDup(14, "0")
                'linhatexto = linhatexto + StrDup(8, "0")
                'linhatexto = linhatexto + StrDup(14, "0")
                'linhatexto = linhatexto + Space(6)  ' Seq 96
                'linhatexto = linhatexto + "N"
                'linhatexto = linhatexto + StrDup(1, "0")
                'linhatexto = linhatexto + StrDup(10, "0")
                'linhatexto = linhatexto + StrDup(15, "0")
                'linhatexto = linhatexto + StrDup(11, "0")
                'linhatexto = linhatexto + StrDup(11, "0")

                '' 11/11/2008 - i 
                ''linhatexto = linhatexto + StrDup(15, "0")   ' Valor do desconto correspondente à espécie
                'valor_adto = CStr(Round(dsFichaFinanceira.Tables(0).Rows(li).Item("valor_adto"), 2))
                'lpos = InStr(1, valor_adto, ",", 1)
                'If lpos = 0 Then   ' Se não tem casas decimais
                '    valor_adto = CStr(valor_adto)
                '    valor_adto = Left(StrDup(13 - Len(valor_adto), "0") + valor_adto, 13)
                '    valor_adto = valor_adto & "00"
                'Else
                '    valor_adto_int = CStr(Left(valor_adto, lpos - 1))  ' Pegar somente o valor inteiro
                '    valor_adto_int = Left(StrDup(13 - Len(valor_adto_int), "0") + valor_adto_int, 13)
                '    valor_adto_dec = CStr(Mid(CStr(valor_adto), lpos + 1))  ' Pegar somente o valor decimal
                '    valor_adto_dec = Left(valor_adto_dec + StrDup(2 - Len(valor_adto_dec), "0"), 2)
                '    valor_adto = valor_adto_int & valor_adto_dec
                'End If
                'linhatexto = linhatexto + valor_adto ' Valor do Adiantamento
                '' 11/11/2008 - f 

                'linhatexto = linhatexto + StrDup(14, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(14, "0")
                'linhatexto = linhatexto + StrDup(15, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(14, "0")
                'linhatexto = linhatexto + StrDup(14, "0")
                'linhatexto = linhatexto + StrDup(2, "0")    ' Seq 112
                'linhatexto = linhatexto + Space(16)
                'linhatexto = linhatexto + Space(2)
                'linhatexto = linhatexto + StrDup(9, "0")
                'linhatexto = linhatexto + Space(2)
                'linhatexto = linhatexto + Space(5)
                'linhatexto = linhatexto + StrDup(3, "0")
                'linhatexto = linhatexto + Space(100)
                'linhatexto = linhatexto + Space(100)
                'linhatexto = linhatexto + StrDup(21, "0")
                'linhatexto = linhatexto + StrDup(21, "0")
                'linhatexto = linhatexto + StrDup(11, "0")
                'linhatexto = linhatexto + StrDup(11, "0")
                'linhatexto = linhatexto + "N"
                'linhatexto = linhatexto + "N"
                'linhatexto = linhatexto + Space(8)
                'linhatexto = linhatexto + Space(8)
                'linhatexto = linhatexto + StrDup(3, "0")
                'linhatexto = linhatexto + "N"
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + Space(20)
                'linhatexto = linhatexto + StrDup(3, "0")   ' Seq 133
                'linhatexto = linhatexto + Space(8)
                'linhatexto = linhatexto + Space(20)
                'linhatexto = linhatexto + Space(50)
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + "N"
                'linhatexto = linhatexto + Space(12)
                'linhatexto = linhatexto + StrDup(5, "0")
                'linhatexto = linhatexto + StrDup(3, "0")
                'linhatexto = linhatexto + Space(2)
                'linhatexto = linhatexto + Space(5)
                'linhatexto = linhatexto + Space(16)
                'linhatexto = linhatexto + Space(2)
                'linhatexto = linhatexto + Space(8)
                'linhatexto = linhatexto + StrDup(3, "0")
                'linhatexto = linhatexto + Space(12)
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(3, "0")
                'linhatexto = linhatexto + Space(80)
                'linhatexto = linhatexto + StrDup(3, "0")
                'linhatexto = linhatexto + "N"               'Seq 162
                'linhatexto = linhatexto + StrDup(3, "0")
                'linhatexto = linhatexto + Space(80)
                'linhatexto = linhatexto + StrDup(2, "0")
                'linhatexto = linhatexto + Space(50)
                'linhatexto = linhatexto + "02"              ' 12/11/2008
                'linhatexto = linhatexto + StrDup(6, "0")
                'linhatexto = linhatexto + StrDup(8, "0")
                'linhatexto = linhatexto + StrDup(7, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + StrDup(12, "0")
                'linhatexto = linhatexto + Space(16)         ' 11/11/2008


                ArquivoTexto.WriteLine(linhatexto)

                'fran 08/2017   i
                'Me.id_adiantamento = dsFichaFinanceira.Tables(0).Rows(li).Item("id_adiantamento")
                'Me.updateAdiantamentoExportacao()   ' Atualiza Status=S e data de exportacao
                If Me.st_adiantamento = "S" Then
                    Me.id_adiantamento = dsFichaFinanceira.Tables(0).Rows(li).Item("id_adiantamento")
                    Me.updateAdiantamentoExportacao()   ' Atualiza Status=S e data de exportacao
                Else
                    Me.id_ficha_financeira = dsFichaFinanceira.Tables(0).Rows(li).Item("id_ficha_financeira")
                    Me.updateAntecipacaoExportacao()   ' Atualiza Status=S e data de exportacao
                End If
                'fran 08/2017 f


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
    ' 08/03/2012 - Projeto Themis - f
End Class
