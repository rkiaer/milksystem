Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.Math


<Serializable()> Public Class SaldoDisponivel

    Private _id_propriedade As Int32
    Private _id_estabelecimento As Int32
    Private _id_pessoa As Int32
    Private _id_tecnico As Int32
    Private _dt_referencia As String
    Private _dt_referencia_start As String
    Private _dt_referencia_end As String
    Private _nr_volume_mensal As Decimal
    Private _nr_valor_descontos As Decimal
    Private _nr_limite_bruto As Decimal
    Private _nr_limite_credito_crm As Decimal       ' 05/03/2009 - CRM
    Private _nr_limite_utilizado_crm As Decimal     ' 05/03/2009 - CRM
    Private _nr_limite_disponivel_crm As Decimal    ' 05/03/2009 - CRM
    Private _nr_valor_faturamento As Decimal        ' 08/11/2009 - Rls22 Central de Compras
    Private _nr_valor_descontos_sem_adto As Decimal ' 25/11/2009 - Chamado 499
    Private _st_saldo_romaneio_aberto As Boolean 'fran 12/2013 fase 2 melhorias
    Private _st_saldo_custo_financeiro As Boolean


    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
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
    Public Property id_pessoa() As Int32
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
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
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property
    Public Property dt_referencia_start() As String
        Get
            Return _dt_referencia_start
        End Get
        Set(ByVal value As String)
            _dt_referencia_start = value
        End Set
    End Property

    Public Property dt_referencia_end() As String
        Get
            Return _dt_referencia_end
        End Get
        Set(ByVal value As String)
            _dt_referencia_end = value
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
    Public Property nr_valor_descontos() As Decimal
        Get
            Return _nr_valor_descontos
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_descontos = value
        End Set
    End Property
    Public Property nr_limite_bruto() As Decimal
        Get
            Return _nr_limite_bruto
        End Get
        Set(ByVal value As Decimal)
            _nr_limite_bruto = value
        End Set
    End Property
    Public Property nr_limite_credito_crm() As Decimal
        Get
            Return _nr_limite_credito_crm
        End Get
        Set(ByVal value As Decimal)
            _nr_limite_credito_crm = value
        End Set
    End Property
    Public Property nr_limite_utilizado_crm() As Decimal
        Get
            Return _nr_limite_utilizado_crm
        End Get
        Set(ByVal value As Decimal)
            _nr_limite_utilizado_crm = value
        End Set
    End Property
    Public Property nr_limite_disponivel_crm() As Decimal
        Get
            Return _nr_limite_disponivel_crm
        End Get
        Set(ByVal value As Decimal)
            _nr_limite_disponivel_crm = value
        End Set
    End Property
    ' 08/11/2009 - Rls22 Central de Compras - i
    Public Property nr_valor_faturamento() As Decimal
        Get
            Return _nr_valor_faturamento
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_faturamento = value
        End Set
    End Property
    ' 08/11/2009 - Rls22 Central de Compras -f
    Public Property nr_valor_descontos_sem_adto() As Decimal
        Get
            Return _nr_valor_descontos_sem_adto
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_descontos_sem_adto = value
        End Set
    End Property
    Public Property st_saldo_romaneio_aberto() As Boolean
        Get
            Return _st_saldo_romaneio_aberto
        End Get
        Set(ByVal value As Boolean)
            _st_saldo_romaneio_aberto = value
        End Set
    End Property
    Public Property st_saldo_custo_financeiro() As Boolean
        Get
            Return _st_saldo_custo_financeiro
        End Get
        Set(ByVal value As Boolean)
            _st_saldo_custo_financeiro = value
        End Set
    End Property
    Public Sub New()

    End Sub
    Public Function getUltimoDiaColeta() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getSaldoDisponivelUltimoDiaColeta", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Function getRomaneioAbertoUltimoDiaColeta() As Int32 'fran 12/2013 melhorias fase 2
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioAbertoUltimoDiaColeta", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Function getDescontos() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getSaldoDisponivelDescontos", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function

    Public Function getContasParceladas() As Decimal

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getSaldoDisponivelContasParceladas", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getSaldoDisponivelCentralParcelamento() As Decimal 'fran dez/2014 fase 3

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getSaldoDisponivelCentralParcelamento", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getSaldoDisponivelPropriedadeEMatriz() As DataSet 'Fran 10/2022
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSaldoDisponivelbyPropriedadeEMatriz", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getSaldoDisponivelFichaCustoPropriedadeEMatriz() As DataSet 'Fran 10/2022
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSaldoDisponivelFichaCustobyPropriedadeEMatriz", parameters, "ms_ficha_financeira")
            Return dataSet

        End Using

    End Function
    Public Function getSaldoDisponivelCentral() As Decimal

        Try


            Dim lsaldo_disponivel_liquido As Decimal

            Me.st_saldo_custo_financeiro = False 'seta que o saldo disponivel nao vem de custo financeiro projetado

            Dim dslimite As DataSet = Me.getSaldoDisponivelPropriedadeEMatriz
            If dslimite.Tables(0).Rows.Count > 0 Then
                With dslimite.Tables(0).Rows(0)
                    lsaldo_disponivel_liquido = Round(.Item("nr_limite_mes_liquido"), 2)
                    Me.nr_limite_bruto = Round(.Item("nr_limite_mes_bruto"), 2)
                    Me.nr_valor_descontos = Round(.Item("nr_valor_desconto"), 2)
                End With

            Else
                'se nao tem faturamento na ficha do mes anterior, busca do projetado na ficha custo financeiro
                Dim dslimitecusto As DataSet = Me.getSaldoDisponivelFichaCustoPropriedadeEMatriz
                If dslimitecusto.Tables(0).Rows.Count > 0 Then
                    With dslimitecusto.Tables(0).Rows(0)
                        lsaldo_disponivel_liquido = Round(.Item("nr_limite_mes_liquido"), 2)
                        Me.nr_limite_bruto = Round(.Item("nr_limite_mes_bruto"), 2)
                        Me.nr_valor_descontos = Round(.Item("nr_valor_desconto"), 2)
                    End With
                    Me.st_saldo_custo_financeiro = True
                Else
                    'se nao encontrou valor projetado e nem faturamento mes anterior
                    lsaldo_disponivel_liquido = 0
                    Me.nr_limite_bruto = 0
                    Me.nr_valor_descontos = 0

                End If
            End If

            Return lsaldo_disponivel_liquido



        Catch err As Exception
            Throw New Exception(err.Message)

        End Try

    End Function

    Public Function getRelatorioSaldoDisponivelAnalitico() As DataSet 'Fran relatorio limite 05/2015
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSaldoDisponivelAnalitico", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    Public Function getRelatorioSaldoDisponivelSintetico() As DataSet 'Fran relatorio limite 05/2015
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSaldoDisponivelSintetico", parameters, "ms_mapa_leite")
            Return dataSet

        End Using

    End Function
    'Public Function getSaldoDisponivel() As Decimal 'fran 12/2013 fase 2
    Public Function getSaldoDisponivel(Optional ByVal pCentral As Boolean = False) As Decimal

        Try

            Dim calculo As New CalculoProdutor
            Dim parametro As New Parametro

            Dim lvolume_leite As Decimal
            Dim lvolume_leite_mes As Decimal
            Dim lqtd_dias As Int32
            Dim lpreco_negociado As Decimal
            Dim lsaldo_disponivel_bruto As Decimal
            Dim ldescontos As Decimal
            Dim lcontasparceladas As Decimal
            Dim lsaldo_disponivel_liquido As Decimal
            Dim nr_perc_limite2q_calculada As Decimal   ' 13/02/2009 - Rls16
            Dim lvalor_adiantamento As Decimal  ' 05/03/2009 - CRM
            Dim lvalorparceladopedido As Decimal  ' fran fase 3 dez/2014

            Me.st_saldo_romaneio_aberto = False 'seta que o saldo disponivel nao vem de romaneio aberto
            ' Passo 1 - Apura Volume de Leite do Mapa
            calculo.dt_referencia = Me.dt_referencia
            ' 22/10/2008 - i
            calculo.dt_referencia_start = Me.dt_referencia
            calculo.dt_referencia_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))
            ' 22/10/2008 - f
            calculo.id_propriedade = Me.id_propriedade
            lvolume_leite = calculo.getCalculoVolumeLeite()

            'fran 12/2013 i  - Melhoria Fase 2
            If Not (lvolume_leite > 0) And pCentral = True Then 'se o volume dos romaneios fechados for zerado e vem da cotacao ou da aprovacao de cotacao
                Me.dt_referencia_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))
                lvolume_leite = Me.getRomaneioAbertoVolumeLeite() 'Busca o volume de leite dos romaneios com status 1 , 2 ou 3
                Me.st_saldo_romaneio_aberto = True 'seta que o saldo esta sendo buscado de romaneios abertos
            End If
            'fran 12/2013 f  - Melhoria Fase 2

            ' Inicializa propriedades da classe
            ' 05/03/2009 - i
            Me.nr_volume_mensal = 0
            Me.nr_valor_descontos = 0
            Me.nr_limite_disponivel_crm = 0
            Me.nr_limite_credito_crm = 0
            Me.nr_limite_utilizado_crm = 0
            Me.nr_valor_faturamento = 0  ' 08/11/2009 - Rls22
            ' 05/03/2009 - f

            If lvolume_leite > 0 Then
                ' Passo 2 - Proporcionaliza Leite para o Mes
                ' Obter o último dia de leite coletado
                'fran 12/2013 - melhorias fase 2 i
                If st_saldo_romaneio_aberto = True Then 'se nao tem volume na mapa e veio da central e dos romaneios abertos
                    lqtd_dias = Me.getRomaneioAbertoUltimoDiaColeta()
                Else
                    'fran 12/2013 - melhorias fase 2 f
                    lqtd_dias = Me.getUltimoDiaColeta()
                End If

                If lqtd_dias > 0 Then
                    lvolume_leite_mes = Round(30 * (lvolume_leite / lqtd_dias), 2)
                Else
                    lvolume_leite_mes = lvolume_leite
                End If
                Me.nr_volume_mensal = lvolume_leite_mes

                ' Passo 3 - Apura Preço Negociado
                ' 24/09/2009 - Sempre utilizar o Preço Negociado do mes anterior - i
                'lpreco_negociado = calculo.getCalculoPrecoNegociado()
                'If lpreco_negociado = 0 Then  ' Se não tem ainda aprovado preço, utiliza o do mes anterior aplicado um deflator 
                '    calculo.dt_referencia = DateAdd(DateInterval.Month, -1, Convert.ToDateTime(Me.dt_referencia))
                '    lpreco_negociado = calculo.getCalculoPrecoNegociado()  '  Preço do mes anterior
                '    If lpreco_negociado > 0 Then  ' Aplica deflator
                '        lpreco_negociado = lpreco_negociado - parametro.nr_deflator
                '    End If
                'End If

                calculo.dt_referencia = DateAdd(DateInterval.Month, -1, Convert.ToDateTime(Me.dt_referencia))
                'fran 12/2017 i 
                'lpreco_negociado = calculo.getCalculoPrecoNegociado()  '  Preço do mes anterior
                lpreco_negociado = calculo.getFichaFinanceiraPrecoNegociado()  '  Preço do mes anterior
                'fran 12/2017 f 

                If lpreco_negociado > 0 Then  ' Aplica deflator
                    lpreco_negociado = lpreco_negociado - parametro.nr_deflator
                End If
                ' 24/09/2009 - Sempre utilizar o Preço Negociado do mes anterior - f

                ' Passo 4 - Apura Saldo Disponível sem descontos
                lsaldo_disponivel_bruto = Round(lvolume_leite_mes * lpreco_negociado, 2)
                Me.nr_valor_faturamento = Round(lvolume_leite_mes * lpreco_negociado, 2)  '  08/11/2009 - Rls22

                ' 13/02/2009 - Rls16 - aplica % da quinzena - i
                'lsaldo_disponivel_bruto = Round(lsaldo_disponivel_bruto * (parametro.nr_perc_adto / 100), 2)
                If Day(Now) <= 15 Then   ' Se 1.a quinzena
                    lsaldo_disponivel_bruto = Round(lsaldo_disponivel_bruto * (parametro.nr_perc_limite1q_cc / 100), 2)
                Else
                    'nr_perc_limite2q_calculada = parametro.nr_perc_limite2q_cc - parametro.nr_perc_limite1q_cc  ' Aplica o que falta para a 2.a Quinzena
                    nr_perc_limite2q_calculada = parametro.nr_perc_limite2q_cc  ' 25/11/2009 - Chamado 499 Simplesmente aplica o % da 2.a Quinzena
                    lsaldo_disponivel_bruto = Round(lsaldo_disponivel_bruto * (nr_perc_limite2q_calculada / 100), 2)
                End If
                ' 13/02/2009 - Rls16 - aplica % da quinzena - f

                Me.nr_limite_credito_crm = lsaldo_disponivel_bruto     ' 05/03/2009 - CRM

                ' Passo 5 - Apura descontos 
                'ldescontos = Me.getDescontos()      ' 05/03/2009 Traz somente as contas de lancamentos com natureza desconto e st_clube_compra = S
                ldescontos = Math.Abs(Me.getDescontos())      ' 22/09/2009 Traz valor absoluto pois eles lançam com valor negativo

                ' Passo 6 - Apura Contas Parceladas
                Me.dt_referencia_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))
                'lcontasparceladas = Me.getContasParceladas()
                lcontasparceladas = Math.Abs(Me.getContasParceladas())  ' 22/09/2009 Traz valor absoluto pois eles lançam com valor negativo

                ' 05/03/2008 CRM - i
                ' Passo 7 - Busca adiantamento
                '20/08/2009 i Fran - chamado 404 - deve pegar o adintamento da refererencia atual
                calculo.dt_referencia = Me.dt_referencia
                '20/08/2009 f
                lvalor_adiantamento = calculo.getCalculoValorAdiantamento()  'Busca diretamente da tabela ms_adiantamento se aprovado
                ' 05/03/2008 CRM - f

                'fase 3 dezembro/2014 Fran No limmite disponivel deve atuar as contas parceladas de lanacamento cujo parcelamento da central é DANONE 
                lvalorparceladopedido = Me.getSaldoDisponivelCentralParcelamento


                Me.nr_limite_utilizado_crm = ldescontos + lcontasparceladas + lvalor_adiantamento   ' 05/03/2009 - CRM

                ' Passo 8 - Apura Saldo Disponível Líquido
                'lsaldo_disponivel_liquido = lsaldo_disponivel_bruto - ldescontos - lcontasparceladas 
                'fran dez/2014 fase 3 i
                'lsaldo_disponivel_liquido = lsaldo_disponivel_bruto - ldescontos - lcontasparceladas - lvalor_adiantamento   ' 05/03/2009 - CRM
                lsaldo_disponivel_liquido = lsaldo_disponivel_bruto - ldescontos - lcontasparceladas - lvalor_adiantamento - lvalorparceladopedido
                'fran dez/2014 fase 3 f

                Me.nr_valor_descontos = ldescontos + lcontasparceladas + lvalor_adiantamento
                Me.nr_valor_descontos_sem_adto = ldescontos + lcontasparceladas  ' 25/11/2009 - Chamado 499

                Me.nr_limite_disponivel_crm = lsaldo_disponivel_liquido

                Return lsaldo_disponivel_liquido
            Else
                Return 0
            End If


        Catch err As Exception
            Throw New Exception(err.Message)

        End Try

    End Function
    Public Function getVolumeLeiteMes() As Decimal

        Try

            ' 17/02/2009 - Rls16 - i

            Dim calculo As New CalculoProdutor
            Dim parametro As New Parametro

            Dim lvolume_leite As Decimal
            Dim lvolume_leite_mes As Decimal
            Dim lqtd_dias As Int32


            ' Passo 1 - Apura Volume de Leite do Mapa
            calculo.dt_referencia = Me.dt_referencia
            ' 22/10/2008 - i
            calculo.dt_referencia_start = Me.dt_referencia
            calculo.dt_referencia_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))
            ' 22/10/2008 - f
            calculo.id_propriedade = Me.id_propriedade
            lvolume_leite = calculo.getCalculoVolumeLeite()

            If lvolume_leite > 0 Then
                ' Passo 2 - Proporcionaliza Leite para o Mes
                ' Obter o último dia de leite coletado
                lqtd_dias = Me.getUltimoDiaColeta()
                If lqtd_dias > 0 Then
                    lvolume_leite_mes = Round(30 * (lvolume_leite / lqtd_dias), 0)
                Else
                    lvolume_leite_mes = lvolume_leite
                End If
                Me.nr_volume_mensal = FormatNumber(lvolume_leite_mes, 0)


                Return FormatNumber(lvolume_leite_mes, 0)
            Else
                Return 0
            End If

            ' 17/02/2009 - Rls16 - f

        Catch err As Exception
            Throw New Exception(err.Message)

        End Try

    End Function
    'fran 12/2013 fase 2 i
    Public Function getRomaneioAbertoVolumeLeite() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioAbertoVolumeLeite", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
End Class
