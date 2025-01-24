Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PoupancaCalculoExecucao

    Private _id_poupanca_calculo_execucao As Int32
    Private _id_poupanca_calculo_execucao_itens As Int32
    Private _id_poupanca_parametro As Int32
    Private _id_estabelecimento As Int32
    Private _id_pessoa As Int32
    Private _id_conta As Int32
    Private _id_categoria As Int32
    Private _id_propriedade As Int32
    Private _id_unid_producao As Int32
    Private _nr_unid_producao As Int32
    Private _id_selecao As Int32
    Private _cd_pessoa As String
    Private _ds_produtor As String
    Private _ds_propriedade As String
    Private _dt_referencia As String
    Private _st_tipo_calculo As String
    Private _st_poupanca_calculo_execucao_itens As String
    Private _st_poupanca_calculo_execucao As String
    Private _id_modificador As Int32
    Private _cd_erro As String
    Private _nm_erro As String
    Private _st_rejeicao_antibiotico As String
    Private _st_analises_romaneio As String

    Public Property id_selecao() As Int32
        Get
            Return _id_selecao
        End Get
        Set(ByVal value As Int32)
            _id_selecao = value
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
    Public Property nr_unid_producao() As Int32
        Get
            Return _nr_unid_producao
        End Get
        Set(ByVal value As Int32)
            _nr_unid_producao = value
        End Set
    End Property
    Public Property cd_pessoa() As String
        Get
            Return _cd_pessoa
        End Get
        Set(ByVal value As String)
            _cd_pessoa = value
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


    Public Property ds_propriedade() As String
        Get
            Return _ds_propriedade
        End Get
        Set(ByVal value As String)
            _ds_propriedade = value
        End Set
    End Property
    Public Property st_rejeicao_antibiotico() As String
        Get
            Return _st_rejeicao_antibiotico
        End Get
        Set(ByVal value As String)
            _st_rejeicao_antibiotico = value
        End Set
    End Property
    Public Property st_analises_romaneio() As String
        Get
            Return _st_analises_romaneio
        End Get
        Set(ByVal value As String)
            _st_analises_romaneio = value
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
    Public Property st_tipo_calculo() As String
        Get
            Return _st_tipo_calculo
        End Get
        Set(ByVal value As String)
            _st_tipo_calculo = value
        End Set
    End Property

    Public Property id_poupanca_calculo_execucao() As Int32
        Get
            Return _id_poupanca_calculo_execucao
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_calculo_execucao = value
        End Set
    End Property
    Public Property id_poupanca_parametro() As Int32
        Get
            Return _id_poupanca_parametro
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_parametro = value
        End Set
    End Property
    Public Property id_poupanca_calculo_execucao_itens() As Int32
        Get
            Return _id_poupanca_calculo_execucao_itens
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_calculo_execucao_itens = value
        End Set
    End Property
    Public Property st_poupanca_calculo_execucao_itens() As String
        Get
            Return _st_poupanca_calculo_execucao_itens
        End Get
        Set(ByVal value As String)
            _st_poupanca_calculo_execucao_itens = value
        End Set
    End Property
    Public Property st_poupanca_calculo_execucao() As String
        Get
            Return _st_poupanca_calculo_execucao
        End Get
        Set(ByVal value As String)
            _st_poupanca_calculo_execucao = value
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
    Public Property id_categoria() As Int32
        Get
            Return _id_categoria
        End Get
        Set(ByVal value As Int32)
            _id_categoria = value
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
    Public Property cd_erro() As String
        Get
            Return _cd_erro
        End Get
        Set(ByVal value As String)
            _cd_erro = value
        End Set
    End Property
    Public Property nm_erro() As String
        Get
            Return _nm_erro
        End Get
        Set(ByVal value As String)
            _nm_erro = value
        End Set
    End Property

    Public Sub New(ByVal id As String)

        Me.id_poupanca_calculo_execucao = id
        loadCalculoExecucao()

    End Sub
    Public Function getCalculoStatusExecucao() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCalculoStatusExecucao", parameters, ExecuteType.Select), String)

        End Using
    End Function



    Public Sub New()

    End Sub


    Public Function getCalculoExecucaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoExecucao", parameters, "ms_calculo_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getCalculoExecucaoHistoricoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCalculoExecucaoHistorico", parameters, "ms_calculo_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaCalculoExecucaoItensByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPoupancaCalculoExecucaoItens", parameters, "ms_poupanca_calculo_execucao_itens")
            Return dataSet

        End Using

    End Function

    Private Sub loadCalculoExecucao()

        Dim dataSet As DataSet = getCalculoExecucaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updatePoupancaCalculoExecucao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updatePoupancaCalculoExecucao", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub updatePoupancaCalculoExecucaoItens()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updatePoupancaCalculoExecucaoItens", parameters, ExecuteType.Update)

        End Using


    End Sub

    Public Sub insertPoupancaCalculoExecucaoErro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_insertPoupancaCalculoExecucaoErro", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Function insertPoupancaCalculoExecucao() As Int64


        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Try
            insertPoupancaCalculoExecucao = 0

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Me.id_poupanca_calculo_execucao = CType(transacao.ExecuteScalar("ms_insertPoupancaCalculoExecucao", parameters, ExecuteType.Insert), Int32)

            parameters = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_insertPoupancaCalculoExecucaoItens", parameters, ExecuteType.Insert)
            'Atualiza o status da itens para 3, se já tiver calculo de poupanca mensal ou 4, caso não tenha adesao à poupança
            transacao.Execute("ms_updatePoupancaCalculoExecucaoItensNaoCalcular", parameters, ExecuteType.Update)

            transacao.Commit()

            insertPoupancaCalculoExecucao = Me.id_poupanca_calculo_execucao

        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try


    End Function
    Public Sub updatePoupancaCalculoSelecaoTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaCalculoSelecaoTodos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePoupancaCalculoSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaCalculoSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub PrepararProdutoresCalculoMensal()

        Dim transacao As New DataAccess
        Dim lrow As DataRow

        'Inicia Transação
        'transacao.StartTransaction(IsolationLevel.RepeatableRead)
        transacao.StartTransaction()
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Me.st_analises_romaneio = String.Empty
            Me.st_rejeicao_antibiotico = "S"
            parameters = ParametersEngine.getParametersFromObject(Me)

            'Busca se há Paramatros Qualidade tipo ANTIBIOTICO
            Dim dataSet As New DataSet
            transacao.Fill(dataSet, "ms_getPoupancaCalculoParametroQualidade", parameters, "ms_poupanca_parametro_qualidade")
            If (dataSet.Tables(0).Rows.Count > 0) Then
                'se tem para metro de antibiotico, atualiza todos os produtores que tiveram problemas com antibiotico no mes de referencia
                transacao.Execute("ms_updatePoupancaCalculoExecucaoItensAntibiotico", parameters, ExecuteType.Update)
            End If

            'Busca se há Paramatros Qualidade tipo ANALISES ROMANEIO (se qualquer analise de romaneio nao estiver no padrao, perde bonus poupanca mes
            dataSet.Clear()
            Me.st_rejeicao_antibiotico = String.Empty
            Me.st_analises_romaneio = "S"
            parameters = ParametersEngine.getParametersFromObject(Me)

            transacao.Fill(dataSet, "ms_getPoupancaCalculoParametroQualidade", parameters, "ms_poupanca_parametro_qualidade")
            If (dataSet.Tables(0).Rows.Count > 0) Then
                'se tem parametro de analises de romaneio, atualiza todos os produtores que tiveram problemas com analises dos romaneios no mes de referencia
                transacao.Execute("ms_updatePoupancaCalculoExecucaoItensAnalisesRomaneio", parameters, ExecuteType.Update)
            End If

            'Busca Parametros de qualidade
            Dim dsparametrosqualidade As New DataSet
            Me.st_rejeicao_antibiotico = "N"
            Me.st_analises_romaneio = "N"
            parameters = ParametersEngine.getParametersFromObject(Me)

            transacao.Fill(dsparametrosqualidade, "ms_getPoupancaCalculoParametroQualidade", parameters, "ms_poupanca_parametro_qualidade")
            'Para cada linha do sql que traz os parametros de qualidade
            For Each lrow In dsparametrosqualidade.Tables(0).Rows
                'Verifica qual categoria de qualidade e associa à conta de teor realizada no calculo da referencia
                Select Case lrow.Item("id_categoria")
                    Case 1, 5 'Categoria CCS e CCS GOLD
                        'fran 09/2016 i após referencia julho/2016 a conta de teor é de geometrico mensal
                        If CDate(Me.dt_referencia) >= CDate("01/07/2016") Then
                            Me.id_conta = 265
                        Else
                            'fran 09/2016 f após referencia julho/2016 a conta de teor é de geometrico mensal
                            Me.id_conta = 253
                        End If
                        Me.st_poupanca_calculo_execucao_itens = "9"
                    Case 2, 6 'Categoria CTM e CTM GOLD
                        'fran 09/2016 i após referencia julho/2016 a conta de teor é de geometrico mensal
                        If CDate(Me.dt_referencia) >= CDate("01/07/2016") Then
                            Me.id_conta = 264
                        Else
                            'fran 09/2016 f após referencia julho/2016 a conta de teor é de geometrico mensal
                            Me.id_conta = 252
                        End If
                        Me.st_poupanca_calculo_execucao_itens = "11"
                    Case 3, 7 'Categoria Proteina e Proteina GOLD
                        Me.id_conta = 251
                        Me.st_poupanca_calculo_execucao_itens = "8"
                    Case 4, 8 'Categoria Gordura e Gordura GOLD
                        Me.id_conta = 156
                        Me.st_poupanca_calculo_execucao_itens = "10"
                End Select
                Me.id_categoria = lrow.Item("id_categoria")

                'Atualiza ytens de calculo campo st_calculo_execucao_itens
                parameters = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_updatePoupancaCalculoExecucaoItensParamQualidade", parameters, ExecuteType.Update)
            Next

            'atualiza bonus da poupanca na execucao_itens
            transacao.Execute("ms_updatePoupancaCalculoExecucaoItensBonus1Ano", parameters, ExecuteType.Update)
            transacao.Execute("ms_updatePoupancaCalculoExecucaoItensBonus2Ano", parameters, ExecuteType.Update)
            transacao.Execute("ms_updatePoupancaCalculoExecucaoItensBonus3Ano", parameters, ExecuteType.Update)


            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Sub

    Public Sub CalcularProdutorPoupancaMensal()

        Dim transacao As New DataAccess

        'Inicia Transação
        'transacao.StartTransaction(IsolationLevel.RepeatableRead)
        transacao.StartTransaction()
        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inserir em ficha todos os produtores selecionados (3) e com status 0, a conta 2500 com volume multiplicado pelo bonus 
            transacao.Execute("ms_insertPoupancaCalculoMensalFichaFinanceira", parameters, ExecuteType.Insert)
            transacao.Execute("ms_updatePoupancaCalculoMensalFichaFinanceira", parameters, ExecuteType.Update)
            transacao.Execute("ms_updatePoupancaCalculoExecucaoItensFim", parameters, ExecuteType.Update)
            transacao.Execute("ms_updatePoupancaCalculoExecucaoFim ", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            'Retorna ao id da propriedade
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Sub
End Class
