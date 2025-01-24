Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class Utilitario

    Private _nr_caderneta As Int32
    Private _id_romaneio As Int32
    Private _id_estabelecimento As Int32
    Private _id_item As Int32
    Private _id_pessoa As Int32
    Private _id_propriedade As Int32
    Private _id_modificador As Int32
    Private _dt_coleta_de As String
    Private _dt_coleta_para As String
    Private _dt_referencia As String
    Private _currentidentity As Int32
    Private _id_coleta_max As Int32
    Private _id_compartimento As Int32
    Private _coleta_de As Int32
    Private _caderneta_afetada As Int32
    Private _nr_unid_producao As Int32
    Private _acao As String
    Private _st_situacao As String
    Public Property st_situacao() As String
        Get
            Return _st_situacao
        End Get
        Set(ByVal value As String)
            _st_situacao = value
        End Set
    End Property
    Public Property currentidentity() As Int32
        Get
            Return _currentidentity
        End Get
        Set(ByVal value As Int32)
            _currentidentity = value
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
    Public Property id_compartimento() As Int32
        Get
            Return _id_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_compartimento = value
        End Set
    End Property
    Public Property id_coleta_max() As Int32
        Get
            Return _id_coleta_max
        End Get
        Set(ByVal value As Int32)
            _id_coleta_max = value
        End Set
    End Property
    Public Property coleta_de() As Int32
        Get
            Return _coleta_de
        End Get
        Set(ByVal value As Int32)
            _coleta_de = value
        End Set
    End Property
    Public Property caderneta_afetada() As Int32
        Get
            Return _caderneta_afetada
        End Get
        Set(ByVal value As Int32)
            _caderneta_afetada = value
        End Set
    End Property
    Public Property acao() As String
        Get
            Return _acao
        End Get
        Set(ByVal value As String)
            _acao = value
        End Set
    End Property


    Public Property nr_caderneta() As Int32
        Get
            Return _nr_caderneta
        End Get
        Set(ByVal value As Int32)
            _nr_caderneta = value
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
    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
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
    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
        End Set
    End Property

    Public Property dt_coleta_de() As String
        Get
            Return _dt_coleta_de
        End Get
        Set(ByVal value As String)
            _dt_coleta_de = value
        End Set
    End Property
    Public Property dt_coleta_para() As String
        Get
            Return _dt_coleta_para
        End Get
        Set(ByVal value As String)
            _dt_coleta_para = value
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


    Public Sub New()

    End Sub

    Public Sub corrigirTemperatura()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para acerto temperatura
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza Temperatura
            transacao.Execute("ms_updateUtilitarioTemperatura", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub alterarDtColeta()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para acerto temperatura
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Alterar Data Coleta
            transacao.Execute("ms_updateUtilitarioDtColeta", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub alterarEstabelecimentoProdutor()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para acerto temperatura
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza Temperatura
            transacao.Execute("ms_updateUtilitarioEstabelecimentoProdutor", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub reabrirRegistroAnaliseRomaneio()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para acerto temperatura
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza Temperatura
            transacao.Execute("ms_updateUtilitarioRomaneioReabrirRegistroAnalise", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub excluirRomaneio()
        Dim transacao As New DataAccess
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza Temperatura
            transacao.Execute("ms_deleteUtilitarioRomaneioExcluir", parameters, ExecuteType.Delete)
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub reabrirRomaneio()
        Dim transacao As New DataAccess
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza Temperatura
            transacao.Execute("ms_updateUtilitarioRomaneioReabrir", parameters, ExecuteType.Update)
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub alterarRomaneioTipoLeite()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para acerto temperatura
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza Temperatura
            transacao.Execute("ms_updateUtilitarioRomaneioTipoLeite", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub alterarRomaneioEstabelecimento()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para acerto temperatura
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza Temperatura
            transacao.Execute("ms_updateUtilitarioRomaneioEstabelecimento", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub

    Public Sub deleteCadernetaRomaneio()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para acerto temperatura
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza Temperatura
            transacao.Execute("ms_deleteUtilitarioCadernetaRomaneio", parameters, ExecuteType.Delete)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub AcertoRomaneio()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para acerto temperatura
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Atualiza Temperatura
            transacao.Execute("ms_deleteUtilitarioCadernetaRomaneio", parameters, ExecuteType.Delete)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Function util_getCadernetasErradas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_util_getCadernetasErradas", parameters, "adri_cadernetas_erradas")
            Return dataSet

        End Using

    End Function
    Public Sub util_insertCadernetaErrada()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_util_insertAdriCadernetaErrada", parameters, ExecuteType.Insert)

        End Using


    End Sub


    Public Sub util_updateAcaoCadernetaErrada()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_util_updateAcaoCadernetaErrada", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub util_updateCadernetasErradasbyColeta()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_util_updateAdriCadernetaErradasbyColeta", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub util_updateCadernetasErradas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_util_updateAdriCadernetasErradas", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub util_updateAcaoSituacaoAdriCadernetaErradas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_util_updateAcaoSituacaoAdriCadernetaErradas", parameters, ExecuteType.Update)

        End Using
        
    End Sub
    Public Function util_getColetasNProgramadas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_util_getColetasNProgramadas", parameters, "ms_coletas")
            Return dataSet

        End Using

    End Function

    Public Function util_getRomaneioUProducaobyPropriedade() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_util_getRomaneioUProducaobyPropriedade", parameters, "ms_romaneio_uproducao")
            Return dataSet

        End Using

    End Function
    Public Function util_getCompartimentoLitrosColetaAfetada() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_util_getCompartimentoLitrosColetaAfetada", parameters, "ms_romaneio_uproducao")
            Return dataSet

        End Using

    End Function
    Public Function util_getCadernetaAfetadabyColeta() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_util_getCadernetaAfetadabyColeta", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Function util_getRomaneioCadernetaAfetada() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_util_getRomaneioCadernetaAfetada", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Function util_getVeiculoCadernetaAfetada() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_util_getVeiculoCadernetaAfetada", parameters, ExecuteType.Select), Int32)

        End Using

    End Function


    Public Sub util_MontandoAdriCadernetasErradas()

        Try

            Dim dsCadernetasErradas As DataSet = Me.util_getCadernetasErradas
            Dim Row As DataRow
            Dim lRow As DataRow
            Dim dsColetaNProgr As DataSet
            Dim lNao1aLinha As Boolean
            Dim lauxid_propriedade As Int32
            For Each Row In dsCadernetasErradas.Tables(0).Rows
                If IsDBNull(Row.Item("id_propriedade")) Then
                    lauxid_propriedade = 0
                Else
                    If Row.Item("id_propriedade").ToString.Equals(String.Empty) Then
                        lauxid_propriedade = 0
                    Else
                        lauxid_propriedade = 1
                    End If
                End If
                'Se já tem propriedade nao faz a rotina novamente
                If lauxid_propriedade = 0 Then


                    Me.currentidentity = Row.Item("currentidentity")
                    Me.id_coleta_max = Row.Item("id_coleta_max")
                    Me.caderneta_afetada = Row.Item("caderneta_afetada")
                    Me.id_romaneio = Row.Item("id_romaneio")
                    Me.coleta_de = Row.Item("coleta_de")

                    Me.util_updateCadernetasErradasbyColeta()

                    'So insere coletas nao programada para a linha original (para evitar duplicação)
                    If Row.Item("linhaoriginal") = 1 Then

                        dsColetaNProgr = Me.util_getColetasNProgramadas
                        lNao1aLinha = False
                        If dsColetaNProgr.Tables(0).Rows.Count > 1 Then
                            For Each lRow In dsColetaNProgr.Tables(0).Rows
                                If lNao1aLinha = True Then
                                    Me.id_coleta_max = Me.id_coleta_max + 1
                                    Me.coleta_de = lRow.Item("id_coleta")
                                    Me.caderneta_afetada = Me.util_getCadernetaAfetadabyColeta
                                    Me.id_romaneio = Me.util_getRomaneioCadernetaAfetada

                                    Me.util_insertCadernetaErrada()
                                    Me.util_updateCadernetasErradasbyColeta()
                                Else
                                    lNao1aLinha = True
                                End If
                            Next
                        End If
                    End If
                End If
            Next

            Me.util_updateCadernetasErradas()

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub util_AnaliseAcertoRomaneiosErrados()

        Try

            Me.currentidentity = 0
            Me.caderneta_afetada = 0
            Dim dsCadernetasErradas As DataSet = Me.util_getCadernetasErradas
            Dim Row As DataRow
            Dim RowComp As DataRow
            Dim dt_transmissao As String
            Dim dt_criacao_romaneio_afetado As String
            Dim coleta_nao_programada_afetada As String
            Dim id_coleta_veiculo As Int32
            Dim nr_volume As Decimal
            Dim lerro As Boolean
            Dim lMesmoVeiculo As Boolean
            Dim status As String
            Dim id_st_romaneio As Integer
            Dim st_romaneio_transbordo As String
            Dim lbexit As Boolean
            'Para  cada linha 
            For Each Row In dsCadernetasErradas.Tables(0).Rows
                'Faz para todos que ainda não foram atualizados
                If IsDBNull(Row.Item("st_situacao")) Then
                    status = "N"
                Else
                    If Row.Item("st_situacao") <> "S" Then
                        status = "N"
                    Else
                        status = "S"
                    End If
                End If
                If status <> "S" Then
                    lerro = False
                    lMesmoVeiculo = False

                    Me.currentidentity = Row.Item("currentidentity")
                    Me.coleta_de = Row.Item("coleta_de")
                    Me.caderneta_afetada = Row.Item("caderneta_afetada")
                    Me.id_coleta_max = Row.Item("id_coleta_max")
                    Me.id_romaneio = Row.Item("id_romaneio")
                    coleta_nao_programada_afetada = Row.Item("coleta_nao_programada_afetada")

                    If Not IsDBNull(Row.Item("dt_transmissao")) Then
                        dt_transmissao = Row.Item("dt_transmissao")
                        If Not dt_transmissao.Equals(String.Empty) Then
                            dt_transmissao = DateTime.Parse(Row.Item("dt_transmissao")).ToString("dd/MM/yyyy HH:mm")
                        End If
                    End If

                    If Me.caderneta_afetada = 0 Then
                        Me.acao = "Romaneio não afetado. A coleta não efetou nenhuma caderneta."
                        Me.st_situacao = "N"
                        Me.util_updateAcaoSituacaoAdriCadernetaErradas()
                        lerro = True
                    Else
                        Me.id_propriedade = Row.Item("id_propriedade")
                        'id_coleta_veiculo = Row.Item("id_coleta_veiculo")
                        Me.id_compartimento = Row.Item("id_compartimento")
                        Me.nr_unid_producao = Row.Item("id_unid_producao")
                        nr_volume = Row.Item("nr_litros")

                        'se não existe romaneio
                        If Me.id_romaneio = 0 Then
                            Me.acao = "Não existe Romaneio para caderneta afetada."
                            Me.st_situacao = "N"
                            Me.util_updateAcaoSituacaoAdriCadernetaErradas()
                            lerro = True
                        Else
                            If Not IsDBNull(Row.Item("dt_abertura_romaneio")) Then
                                dt_criacao_romaneio_afetado = Row.Item("dt_abertura_romaneio")
                                If Not dt_criacao_romaneio_afetado.Equals(String.Empty) Then
                                    dt_criacao_romaneio_afetado = DateTime.Parse(Row.Item("dt_abertura_romaneio")).ToString("dd/MM/yyyy HH:mm")
                                End If
                            End If

                            'se a data de transmissao é maior que a data de criacao do romaneio
                            If DateTime.Compare(dt_transmissao, dt_criacao_romaneio_afetado) >= 0 Then
                                Me.acao = "Romaneio não afetado. Data de transmissão da caderneta é maior que a Data de Abertura do Romaneio."
                                Me.st_situacao = "N"
                                Me.util_updateAcaoSituacaoAdriCadernetaErradas()
                                lerro = True
                            Else
                                If coleta_nao_programada_afetada = "S" Then
                                    Me.acao = "A caderneta afetada tem Coletas Não Programadas. Deve ser avaliada pontualmente."
                                    Me.st_situacao = "N"
                                    Me.util_updateAcaoSituacaoAdriCadernetaErradas()
                                    lerro = True
                                End If
                            End If
                        End If
                    End If
                    If lerro = False Then
                        lbexit = False
                        'Verificar romaneio da caderneta afetada
                        'Se a caderneta afetado não possui a placa da coleta anterioie
                        'If Me.util_getVeiculoCadernetaAfetada = 0 Then
                        'lMesmoVeiculo = False
                        'Els() 'e
                        'lMesmoVeiculo = True
                        'End If
                        'Pegas os dados compartimento
                        Dim dscomp As DataSet = Me.util_getCompartimentoLitrosColetaAfetada

                        If dscomp.Tables(0).Rows.Count = 0 Then
                            Me.acao = "Não foi encontrada litragem da coleta no romaneio atual."
                            Me.st_situacao = "N"
                            Me.util_updateAcaoSituacaoAdriCadernetaErradas()
                            lbexit = True

                        End If
                        For Each RowComp In dscomp.Tables(0).Rows
                            Me.id_compartimento = RowComp.Item("id_compartimento")
                            id_coleta_veiculo = RowComp.Item("id_coleta_veiculo")
                            nr_volume = RowComp.Item("nr_volume")
                            Dim dsuproducao As DataSet = Me.util_getRomaneioUProducaobyPropriedade

                            'pega os dados da unidade producao

                            lbexit = False
                            If dsuproducao.Tables(0).Rows.Count = 0 Then
                                Me.acao = "Romaneio não afetado. Não existe registro na romaneio uproducao para a propriedade e compartimento procurados."
                                Me.st_situacao = "N"
                                Me.util_updateAcaoSituacaoAdriCadernetaErradas()
                                lbexit = True
                            End If
                            If lbexit = False Then
                                If Not IsDBNull(dsuproducao.Tables(0).Rows(0).Item("id_status_analise_uproducao")) Then
                                    If dsuproducao.Tables(0).Rows(0).Item("id_status_analise_uproducao") = 3 Then
                                        lbexit = True
                                        'está rejeitado... nao entrou no mapa de leite
                                        Me.acao = "Mapa de leite não afetada. Análise está rejeitada."
                                        Me.st_situacao = "N"
                                        Me.util_updateAcaoSituacaoAdriCadernetaErradas()
                                    End If
                                End If
                            End If
                            If lbexit = False Then
                                If Not IsDBNull(dsuproducao.Tables(0).Rows(0).Item("nr_litros_sem_reajuste")) Then
                                    Me.acao = "No romaneio, há reajuste de valores para a propriedade deste compartimento. Volume do romaneio deve ser verificado."
                                    Me.st_situacao = "N"
                                    Me.util_updateAcaoSituacaoAdriCadernetaErradas()
                                    lbexit = True
                                Else
                                    If Convert.ToDecimal(dsuproducao.Tables(0).Rows(0).Item("nr_litros")) <> Convert.ToDecimal(nr_volume) Then
                                        Me.acao = "No romaneio, o volume encontrado para propriedade não confere com o volume da coleta não programada."
                                        Me.st_situacao = "N"
                                        Me.util_updateAcaoSituacaoAdriCadernetaErradas()
                                        lbexit = True
                                    End If
                                End If
                            End If

                            If lbexit = False Then
                                If IsDBNull(dsuproducao.Tables(0).Rows(0).Item("st_romaneio_transbordo")) Then
                                    st_romaneio_transbordo = "N"
                                Else
                                    If dsuproducao.Tables(0).Rows(0).Item("st_romaneio_transbordo").ToString.Equals(String.Empty) Then
                                        st_romaneio_transbordo = "N"
                                    Else
                                        st_romaneio_transbordo = dsuproducao.Tables(0).Rows(0).Item("st_romaneio_transbordo").ToString.Trim
                                    End If
                                End If

                                id_st_romaneio = dsuproducao.Tables(0).Rows(0).Item("id_st_romaneio").ToString.Trim

                                'Se mesma listagem e não tem reajuste
                                Dim rp As New Romaneio_Comp_UProducao
                                rp.id_romaneio_compartimento = Convert.ToInt32(dsuproducao.Tables(0).Rows(0).Item("id_romaneio_compartimento"))
                                rp.id_romaneio_uproducao = Convert.ToInt32(dsuproducao.Tables(0).Rows(0).Item("id_romaneio_uproducao"))
                                rp.id_romaneio = Convert.ToInt32(Me.id_romaneio)

                                'Se não tem valor de reajuste o valor real esta em nr_total_litros
                                'atualiza valores para unid producao
                                rp.nr_litros = 0
                                rp.nr_litros_sem_reajuste = Convert.ToDecimal(nr_volume)
                                'atualiza valores compartimento
                                If IsDBNull(dsuproducao.Tables(0).Rows(0).Item("nr_total_litros_sem_reajuste")) Then
                                    'O compartimento tb nao foi alterado
                                    'Pega o valor total do compartimento - o valor do coletor 
                                    rp.nr_total_litros = Convert.ToDecimal(dsuproducao.Tables(0).Rows(0).Item("nr_total_litros")) - Convert.ToDecimal(nr_volume)
                                    rp.nr_total_litros_sem_reajuste = Convert.ToDecimal(dsuproducao.Tables(0).Rows(0).Item("nr_total_litros"))
                                Else
                                    rp.nr_total_litros = Convert.ToDecimal(dsuproducao.Tables(0).Rows(0).Item("nr_total_litros")) - Convert.ToDecimal(nr_volume)
                                    'rp.nr_litros = Convert.ToDecimal(txt_volume_ajustado.Text)
                                    rp.nr_total_litros_sem_reajuste = Convert.ToDecimal(dsuproducao.Tables(0).Rows(0).Item("nr_total_litros_sem_reajuste"))
                                End If

                                rp.id_modificador = 1

                                rp.updateRomaneioUProducaoReajuste()
                            End If
                        Next
                        'se o romaneio já está fechado
                        If lbexit = False And id_st_romaneio = "4" Then
                            Dim transacao As New DataAccess
                            'Inicia Transação
                            transacao.StartTransaction(IsolationLevel.RepeatableRead)

                            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
                            'delete romaneio mapa de leite
                            transacao.Execute("ms_util_deleteRomaneioMapaLeite", parameters, ExecuteType.Delete)

                            'Insere romaneio mapa de leite
                            transacao.Execute("ms_insertRomaneioMapaLeite", parameters, ExecuteType.Insert)

                            'Insere romaneio mapa de leite
                            transacao.Execute("ms_insertRomaneioMapaLeiteDescartado", parameters, ExecuteType.Insert)


                            If st_romaneio_transbordo = "S" Then
                                transacao.Execute("ms_updateRomaneioMapaLeiteTransbordo", parameters, ExecuteType.Update)
                            End If

                            'Fran 30/11/2008 i - Atualiza a coluna Rejeicao_antibiotico para 'S' para as analises de produtores rejeitadas por antibitorico
                            transacao.Execute("ms_updateRomaneioMapaLeiteRejeicaoAntibiotico", parameters, ExecuteType.Update)
                            'Comita
                            transacao.Commit()

                            Me.acao = "Foi realizado reajuste de valores para o Romaneio. O mapa de leite foi reajustado conforme o romaneio."
                        Else
                            If lbexit = False Then
                                Me.acao = "Foi realizado reajuste de valores para o Romaneio. Não há mapa de leite pois romaneio não está fechado."
                            End If

                        End If
                        If lbexit = False Then
                            Me.st_situacao = "S"
                            Me.util_updateAcaoSituacaoAdriCadernetaErradas()
                        End If

                    End If

                End If 'fim status <> S

            Next


        Catch err As Exception
            Throw New Exception(err.Message)
        End Try
    End Sub

End Class
