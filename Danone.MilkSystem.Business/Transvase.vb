Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math
Imports System.Data


<Serializable()> Public Class Transvase

    Private _id_transvase As Int32
    Private _id_transvase_compartimento As Int32
    Private _id_transvase_veiculo As Int32
    Private _id_estabelecimento As Int32
    Private _ds_estabelecimento As String
    Private _nm_estabelecimento As String
    Private _id_transportador As Int32
    Private _cd_transportador As String
    Private _nm_transportador As String
    Private _ds_transportador As String
    Private _id_motorista As Int32
    Private _cd_cnh As String
    Private _nm_motorista As String
    Private _id_linha As Int32
    Private _nm_linha As String
    Private _ds_placa As String
    Private _dt_abertura As String
    Private _dt_ini As String
    Private _dt_fim As String
    Private _dt_fechamento As String
    Private _nr_tara As Decimal
    Private _nr_total_litros As Decimal
    Private _id_item As Int32
    Private _nm_item As String
    Private _id_situacao_transvase As Int32
    Private _nm_situacao_transvase As String
    Private _id_situacao As Int32
    Private _nm_situacao As String
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _id_usuario_fechamento As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String
    Private _data_inicio As String
    Private _data_fim As String
    Private _id_pre_romaneio As Int32
    Private _tpc_id_veiculo As New ArrayList
    Private _tpc_id_compartimento As New ArrayList
    Private _tpc_st_placa_principal As New ArrayList
    Private _romaneio_compartimento As Romaneio_Compartimento


    Public Property id_transvase() As Int32
        Get
            Return _id_transvase
        End Get
        Set(ByVal value As Int32)
            _id_transvase = value
        End Set
    End Property
    Public Property id_transvase_compartimento() As Int32
        Get
            Return _id_transvase_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_transvase_compartimento = value
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
    Public Property ds_estabelecimento() As String
        Get
            Return _ds_estabelecimento
        End Get
        Set(ByVal value As String)
            _ds_estabelecimento = value
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
    Public Property id_transportador() As Int32
        Get
            Return _id_transportador
        End Get
        Set(ByVal value As Int32)
            _id_transportador = value
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

    Public Property nm_transportador() As String
        Get
            Return _nm_transportador
        End Get
        Set(ByVal value As String)
            _nm_transportador = value
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
    Public Property cd_cnh() As String
        Get
            Return _cd_cnh
        End Get
        Set(ByVal value As String)
            _cd_cnh = value
        End Set
    End Property
    Public Property nm_motorista() As String
        Get
            Return _nm_motorista
        End Get
        Set(ByVal value As String)
            _nm_motorista = value
        End Set
    End Property
    Public Property id_motorista() As Int32
        Get
            Return _id_motorista
        End Get
        Set(ByVal value As Int32)
            _id_motorista = value
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

    Public Property id_linha() As Int32
        Get
            Return _id_linha
        End Get
        Set(ByVal value As Int32)
            _id_linha = value
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

    Public Property dt_ini() As String
        Get
            Return _dt_ini
        End Get
        Set(ByVal value As String)
            _dt_ini = value
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
    Public Property dt_abertura() As String
        Get
            Return _dt_abertura
        End Get
        Set(ByVal value As String)
            _dt_abertura = value
        End Set
    End Property
    Public Property dt_fechamento() As String
        Get
            Return _dt_fechamento
        End Get
        Set(ByVal value As String)
            _dt_fechamento = value
        End Set
    End Property
    Public Property id_usuario_fechamento() As Int32
        Get
            Return _id_usuario_fechamento
        End Get
        Set(ByVal value As Int32)
            _id_usuario_fechamento = value
        End Set
    End Property
    Public Property data_fim() As String
        Get
            Return _data_fim
        End Get
        Set(ByVal value As String)
            _data_fim = value
        End Set
    End Property
    Public Property data_inicio() As String
        Get
            Return _data_inicio
        End Get
        Set(ByVal value As String)
            _data_inicio = value
        End Set
    End Property
    Public Property nr_tara() As Decimal
        Get
            Return _nr_tara
        End Get
        Set(ByVal value As Decimal)
            _nr_tara = value
        End Set
    End Property

    Public Property nr_total_litros() As Decimal
        Get
            Return _nr_total_litros
        End Get
        Set(ByVal value As Decimal)
            _nr_total_litros = value
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
    Public Property nm_item() As String
        Get
            Return _nm_item
        End Get
        Set(ByVal value As String)
            _nm_item = value
        End Set
    End Property

    Public Property nm_situacao_transvase() As String
        Get
            Return _nm_situacao_transvase
        End Get
        Set(ByVal value As String)
            _nm_situacao_transvase = value
        End Set
    End Property
    Public Property nm_situacao() As String
        Get
            Return _nm_situacao
        End Get
        Set(ByVal value As String)
            _nm_situacao = value
        End Set
    End Property
    Public Property id_situacao_transvase() As Int32
        Get
            Return _id_situacao_transvase
        End Get
        Set(ByVal value As Int32)
            _id_situacao_transvase = value
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

    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
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
    Public Property id_pre_romaneio() As Int32
        Get
            Return _id_pre_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_pre_romaneio = value
        End Set
    End Property
    Public Property tpc_id_compartimento() As ArrayList
        Get
            Return _tpc_id_compartimento
        End Get
        Set(ByVal value As ArrayList)
            _tpc_id_compartimento = value
        End Set
    End Property
    Public Property tpc_id_veiculo() As ArrayList
        Get
            Return _tpc_id_veiculo
        End Get
        Set(ByVal value As ArrayList)
            _tpc_id_veiculo = value
        End Set
    End Property
    Public Property tpc_st_placa_principal() As ArrayList
        Get
            Return _tpc_st_placa_principal
        End Get
        Set(ByVal value As ArrayList)
            _tpc_st_placa_principal = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Int32)

        Me._id_transvase = id
        loadTransvase()

    End Sub

    Public Function getTransvaseAberturaRomaneio() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransvaseAberturaRomaneio", parameters, "ms_transvase")
            Return dataSet

        End Using

    End Function
    Public Function getTransvaseByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransvase", parameters, "ms_transvase")
            Return dataSet

        End Using

    End Function
    Public Function getTransvasePreRomaneio() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransvasePreRomaneio", parameters, "ms_transvase")
            Return dataSet

        End Using

    End Function
    Public Function getTransvaseSelecionar() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransvaseSelecionar", parameters, "ms_transvase")
            Return dataSet

        End Using

    End Function
    Public Function getTransvase() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransvase", parameters, "ms_transvase")
            Return dataSet

        End Using

    End Function
    Public Function getTransvaseCompartimentoProdutores() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransvaseCompartimentoProdutores", parameters, "ms_transvase")
            Return dataSet

        End Using

    End Function
    Public Function getTransvasePreRomaneioAmostrasNaoEnviadas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransvasePreRomaneioAmostrasNaoEnviadas", parameters, "ms_transvase")
            Return dataSet

        End Using

    End Function
    Public Function getTransvasePreRomaneioAmostras() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransvasePreRomaneioAmostras", parameters, "ms_transvase")
            Return dataSet

        End Using

    End Function
    Public Function getTransvaseAmostras() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransvaseAmostras", parameters, "ms_transvase")
            Return dataSet

        End Using

    End Function
    Public Function getTransvaseAmostrasSemRegistro() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransvaseAmostrasSemRegistro", parameters, "ms_transvase")
            Return dataSet

        End Using

    End Function
    Private Sub loadTransvase()

        Dim dataSet As DataSet = getTransvase()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertTransvase() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertTransvase", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Function abrirRomaneio()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui romaneio
            Me.id_transvase = CType(transacao.ExecuteScalar("ms_insertRomaneio", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)
            'Pega os parametros para romaneio_compartimento
            Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Insere romaneio compartimento
            transacao.Execute("ms_insertRomaneioCompartimento", param_comp, ExecuteType.Insert)

            'Insere romaneio compartimento unidade producao
            transacao.Execute("ms_insertRomaneioUProducao", param_comp, ExecuteType.Insert)

            'Insere romaneio placas
            transacao.Execute("ms_insertRomaneioPlacas", parameters, ExecuteType.Insert)
            'Atualiza a Placa Principal
            transacao.Execute("ms_updateAbrirRomaneioPlacaStPrincipal", parameters, ExecuteType.Update)
            'fran 26/11/2009 - Maracanau chamado 519 desabilitado pois faz insert da analie qdo tiver o estabelecimento informado
            'Insere Analise Compartimento
            'transacao.Execute("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert)
            'fran 26/11/2009 f- Maracanau chamado 519 desabilitado pois faz insert da analie qdo tiver o estabelecimento informado

            'Atualiza as propriedades do romaneio que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioUProducaoPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i
            'Atualiza as propriedades das coletas que foram transferidas mas estão com propriedade antiga, simulando alteração de propriedade
            transacao.Execute("ms_updateRomaneioColetaPropriedadeTransferida", parameters, ExecuteType.Update) 'fran 07/2016 i

            'Insere romaneio mapa de leite
            'transacao.Execute("ms_insertRomaneioMapaLeite", param_comp, ExecuteType.Insert)

            'Insere romaneio analise global
            'transacao.Execute("ms_insertRomaneioAnaliseGlobal", param_comp, ExecuteType.Insert)

            'Comita
            transacao.Commit()
            transacao.Dispose()     ' 14/11/2008
            'Retorna ao id da propriedade
            Return Me.id_transvase
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()     ' 14/11/2008
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function abrirTransvase()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui transit point com situacao aberto
            Me.id_transvase = CType(transacao.ExecuteScalar("ms_insertTransvase", parameters, ExecuteType.Insert), Int32)

            parameters = ParametersEngine.getParametersFromObject(Me)
            Dim tpcomp As New TransvaseCompartimento
            Dim tpveiculo As New TransvaseVeiculo
            'Pega os parametros para romaneio_compartimento
            tpveiculo.id_transvase = Me.id_transvase
            tpveiculo.id_modificador = Me.id_modificador
            tpcomp.id_transvase = Me.id_transvase
            tpcomp.id_modificador = Me.id_modificador
            For i As Integer = 0 To tpc_id_veiculo.Count - 1
                tpveiculo.id_veiculo = Convert.ToInt32(tpc_id_veiculo(i))
                tpveiculo.st_principal = tpc_st_placa_principal(i).ToString
                'Inclui cadastro de transit point veiculo
                Dim param_veiculo As List(Of Parameters) = ParametersEngine.getParametersFromObject(tpveiculo)

                tpcomp.id_transvase_veiculo = CType(transacao.ExecuteScalar("ms_insertTransvaseVeiculo", param_veiculo, ExecuteType.Insert), Int32)

                tpcomp.id_compartimento = Convert.ToInt32(tpc_id_compartimento(i))
                'Pega os parametros para transit compartimento
                Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(tpcomp)
                transacao.Execute("ms_insertTransvaseCompartimento", param_comp, ExecuteType.Insert)

            Next

            'Comita
            transacao.Commit()

            Return Me.id_transvase
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function TransvaseAbrir() As Int32

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try

            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            'Inclui transit point com situacao aberto
            Me.id_transvase = CType(transacao.ExecuteScalar("ms_insertTransvase", parameters, ExecuteType.Insert), Int32)

            parameters = ParametersEngine.getParametersFromObject(Me)
            Dim tpcomp As New TransvaseCompartimento
            Dim tpveiculo As New TransvaseVeiculo
            Dim i As Integer
            Dim lsaux As Int32 = 0
            'Pega os parametros para romaneio_compartimento
            tpveiculo.id_transvase = Me.id_transvase
            tpveiculo.id_modificador = Me.id_modificador
            tpcomp.id_transvase = Me.id_transvase
            tpcomp.id_modificador = Me.id_modificador
            For i = 0 To Me.tpc_id_veiculo.Count - 1
                tpveiculo.id_veiculo = Convert.ToInt32(tpc_id_veiculo(i))
                tpveiculo.st_principal = tpc_st_placa_principal(i).ToString
                'Inclui cadastro de transit point veiculo
                Dim param_veiculo As List(Of Parameters) = ParametersEngine.getParametersFromObject(tpveiculo)

                tpcomp.id_transvase_veiculo = CType(transacao.ExecuteScalar("ms_insertTransvaseVeiculo", param_veiculo, ExecuteType.Insert), Int32)

                tpcomp.id_compartimento = Convert.ToInt32(tpc_id_compartimento(i))
                'Pega os parametros para transit compartimento
                'Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(tpcomp)
                'lsaux = CType(transacao.ExecuteScalar("ms_insertTransvaseCompartimento", param_comp, ExecuteType.Insert), Int32)

                tpcomp.insertTransvaseCompartimento()

            Next

            'Comita
            transacao.Commit()

            Return Me.id_transvase

        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)

        End Try
    End Function
    'Public Sub FecharTransvase()

    '    Dim transacao As New DataAccess
    '    Dim dsromcomprejeitado As New DataSet
    '    Dim dsrow As DataRow
    '    Dim dsrowprop As DataRow
    '    Dim inr_count_propriedades As Integer
    '    Dim nr_saldo_litros As Decimal
    '    Dim nr_desconto_primprop As Decimal
    '    Dim nr_desconto_propriedade As Decimal
    '    Dim laux As Decimal
    '    Dim dsruppropriedades As New DataSet

    '    'Inicia Transação
    '    transacao.StartTransaction(IsolationLevel.RepeatableRead)
    '    Try
    '        'Pega os parametros para inclusão romaneio
    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '        'Atualizar romaneio
    '        transacao.Execute("ms_updateRomaneioFechar", parameters, ExecuteType.Update)
    '        'Atualizar pesagens
    '        transacao.Execute("ms_updateRomaneioPesagens", parameters, ExecuteType.Update)

    '        If Me.id_cooperativa > 0 Then
    '            'Insere romaneio mapa de leite
    '            transacao.Execute("ms_insertRomaneioMapaLeiteCooperativa", parameters, ExecuteType.Insert)

    '            'Insere romaneio mapa de leite
    '            transacao.Execute("ms_insertRomaneioMapaLeiteDescartadoCooperativa", parameters, ExecuteType.Insert)
    '        Else
    '            'Insere romaneio mapa de leite
    '            transacao.Execute("ms_insertRomaneioMapaLeite", parameters, ExecuteType.Insert)

    '            'Insere romaneio mapa de leite
    '            transacao.Execute("ms_insertRomaneioMapaLeiteDescartado", parameters, ExecuteType.Insert)
    '        End If

    '        If Me.st_romaneio_transbordo = "S" Then
    '            transacao.Execute("ms_updateRomaneioMapaLeiteTransbordo", parameters, ExecuteType.Update)
    '        End If

    '        'Fran 30/11/2008 i - Atualiza a coluna Rejeicao_antibiotico para 'S' para as analises de produtores rejeitadas por antibitorico
    '        transacao.Execute("ms_updateRomaneioMapaLeiteRejeicaoAntibiotico", parameters, ExecuteType.Update)
    '        Dim li As Integer = 0
    '        'fran i 06/2016- apurar rejeicao antibiotico para geração da conta 0114 em conta parcelada do saldo do leite bom que foi misturado com antibiotico
    '        'maracanau nao tem a mesma regra... so cria conta antibiotico para poços
    '        If (Me.nr_caderneta > 0) And (Me.id_estabelecimento <> 9) Then 'romaneio de produtor
    '            'Buscar os compartimentos e diferença do volume rejeitado da propriedade para o volume total do compartimento, ou seja deve buscar o valor de leite bom que foi misturado ao de antibiotico para que o produtor possa paga-lo
    '            transacao.Fill(dsromcomprejeitado, "ms_getRomaneioCompartimentoRejeicaoAntibiotico", parameters, "ms_romaneio_compartimento")
    '            For Each dsrow In dsromcomprejeitado.Tables(0).Rows
    '                Me.id_transvase_compartimento = dsrow.Item("id_transvase_compartimento")
    '                'quantas propriedades vao ratear o volume
    '                inr_count_propriedades = dsrow.Item("nr_count_propriedades")
    '                Me.nr_litros_rejeitado = dsrow.Item("nr_litros_rejeitados_compartimento")
    '                'o total a ser rateado (litros de leite bom)
    '                nr_saldo_litros = dsrow.Item("nr_saldo_litros")
    '                'o valor de cada propriedade
    '                nr_desconto_propriedade = dsrow.Item("nr_desconto_propriedade")
    '                If inr_count_propriedades = 1 Then
    '                    'se ttem apenas uma propriedade, arredonda sem deciamis pois volume leite deve ser inteiro
    '                    nr_desconto_primprop = Round(nr_desconto_propriedade, 0)
    '                Else
    '                    'se o valor deve ser dividido entre mais de umma propriedade, joga os litros perdidos para a primeira
    '                    laux = Round((nr_desconto_propriedade - Truncate(nr_desconto_propriedade)) * inr_count_propriedades, 0)
    '                    nr_desconto_primprop = Truncate(nr_desconto_propriedade) + laux
    '                    nr_desconto_propriedade = Truncate(nr_desconto_propriedade)
    '                End If

    '                'Busca quais sao as propriedades que devem pagar o leite, as que tiveram rejeicao antibiotico
    '                li = 0
    '                parameters = ParametersEngine.getParametersFromObject(Me)
    '                transacao.Fill(dsruppropriedades, "ms_getRomaneioUProducaoPropriedadesRejeicaoAntibiotico", parameters, "ms_romaneio_uproducao")
    '                For Each dsrowprop In dsruppropriedades.Tables(0).Rows
    '                    li = li + 1
    '                    Me.id_propriedade = dsrowprop.Item("id_propriedade")
    '                    Me.dt_referencia = DateTime.Parse(dsrowprop.Item("dt_referencia")).ToString("dd/MM/yyyy")
    '                    'se for a primeira propriedade joga o volume dividido + o decimal
    '                    If li = 1 Then
    '                        Me.nr_litros_desconto = nr_desconto_primprop
    '                    Else
    '                        Me.nr_litros_desconto = nr_desconto_propriedade
    '                    End If
    '                    parameters = ParametersEngine.getParametersFromObject(Me)
    '                    transacao.Execute("ms_insertRomaneioContaParcelada", parameters, ExecuteType.Update)

    '                Next 'proxima propriedade
    '            Next 'proximo romaneio compartimento

    '        End If
    '        'fran f 06/2016
    '        'Comita
    '        transacao.Commit()
    '        'Retorna ao id da propriedade
    '        'Return Me.id_transvase
    '    Catch err As Exception
    '        transacao.RollBack()
    '        Throw New Exception(err.Message)
    '    End Try
    'End Sub
    Public Sub updateTransvase()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateTransvase", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateTransvaseFechar()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateTransvaseFechar", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateTransvaseSituacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateTransvaseSituacao", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Function getRomaneioCompartimentoMediaDens() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentoMediaDens", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getTransvaseConsVolumeCompartimento() As Integer
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getTransvaseConsVolumeCompartimento", parameters, ExecuteType.Select), Integer)

        End Using

    End Function
    Public Function getTransvaseConsPlacas() As Integer
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getTransvaseConsPlacas", parameters, ExecuteType.Select), Integer)

        End Using

    End Function
    Public Function getTransvaseConsPlacasPrincipal() As Int64
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getTransvaseConsPlacasPrincipal", parameters, ExecuteType.Select), Int64)

        End Using

    End Function
    Public Function getTransvaseConsPlacasTransportador() As Int64
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getTransvaseConsPlacasTransportador", parameters, ExecuteType.Select), Int64)

        End Using

    End Function

End Class
