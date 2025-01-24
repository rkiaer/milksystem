Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.Math


<Serializable()> Public Class SaldoDisponivel

    Private _id_propriedade As Int32
    Private _dt_referencia As String
    Private _dt_referencia_start As String
    Private _dt_referencia_end As String
    Private _nr_volume_mensal As Decimal
    Private _nr_valor_descontos As Decimal

    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
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

    Public Sub New()

    End Sub
    Public Function getUltimoDiaColeta() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getSaldoDisponivelUltimoDiaColeta", parameters, ExecuteType.Select), Int32)

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

    Public Function getSaldoDisponivel() As Decimal

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
                    lvolume_leite_mes = Round(30 * (lvolume_leite / lqtd_dias), 2)
                Else
                    lvolume_leite_mes = lvolume_leite
                End If
                Me.nr_volume_mensal = lvolume_leite_mes

                ' Passo 3 - Apura Preço Negociado
                lpreco_negociado = calculo.getCalculoPrecoNegociado()
                If lpreco_negociado = 0 Then  ' Se não tem ainda aprovado preço, utiliza o do mes anterior aplicado um deflator 
                    calculo.dt_referencia = DateAdd(DateInterval.Month, -1, Convert.ToDateTime(Me.dt_referencia))
                    lpreco_negociado = calculo.getCalculoPrecoNegociado()  '  Preço do mes anterior
                    If lpreco_negociado > 0 Then  ' Aplica deflator
                        lpreco_negociado = lpreco_negociado - parametro.nr_deflator
                    End If
                End If

                ' Passo 4 - Apura Saldo Disponível sem descontos
                lsaldo_disponivel_bruto = Round(lvolume_leite_mes * lpreco_negociado, 2)

                ' 13/02/2009 - Rls16 - aplica % da quinzena - i
                'lsaldo_disponivel_bruto = Round(lsaldo_disponivel_bruto * (parametro.nr_perc_adto / 100), 2)
                If Day(Now) <= 15 Then   ' Se 1.a quinzena
                    lsaldo_disponivel_bruto = Round(lsaldo_disponivel_bruto * (parametro.nr_perc_limite1q_cc / 100), 2)
                Else
                    nr_perc_limite2q_calculada = parametro.nr_perc_limite2q_cc - parametro.nr_perc_limite1q_cc  ' Aplica o que falta para a 2.a Quinzena
                    lsaldo_disponivel_bruto = Round(lsaldo_disponivel_bruto * (nr_perc_limite2q_calculada / 100), 2)
                End If
                ' 13/02/2009 - Rls16 - aplica % da quinzena - f

                ' Passo 5 - Apura descontos
                ldescontos = Me.getDescontos()

                ' Passo 6 - Apura Contas Parceladas
                Me.dt_referencia_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(Me.dt_referencia)))
                lcontasparceladas = Me.getContasParceladas()

                ' Passo 7 - Apura Saldo Disponível Líquido
                lsaldo_disponivel_liquido = lsaldo_disponivel_bruto - ldescontos - lcontasparceladas

                Me.nr_valor_descontos = ldescontos + lcontasparceladas

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


End Class
