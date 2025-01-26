Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GoldCusto

    Private _id_gold_custo As Int32
    Private _id_estabelecimento As Int32
    Private _dt_referencia_inicial As String
    Private _dt_referencia_final As String
    Private _st_aprovado As String
    Private _st_selecao As String
    Private _ds_anotacao_aprovador As String
    Private _nr_valor As Decimal ' Valor para pesquisar nas Faixas de Custo, Volume, Crescimento e Efic. dieta

    ' Arrays de Margem
    Private _nr_margem As New ArrayList
    Private _id_gold_faixa_custo As New ArrayList
    Private _id_gold_custo_margem As New ArrayList  ' Para o Update

    ' Arrays de Volume
    Private _nr_adicional_volume As New ArrayList
    Private _id_gold_faixa_volume As New ArrayList
    Private _id_gold_custo_volume As New ArrayList  ' Para o Update

    ' Arrays de Crescimento
    Private _nr_adicional_crescimento As New ArrayList
    Private _id_gold_faixa_crescimento As New ArrayList
    Private _id_gold_custo_crescimento As New ArrayList  ' Para o Update

    ' Arrays de Eficiencia
    Private _nr_adicional_eficiencia As New ArrayList
    Private _id_gold_faixa_eficiencia As New ArrayList
    Private _id_gold_custo_eficiencia As New ArrayList  ' Para o Update

    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_gold_custo() As Int32
        Get
            Return _id_gold_custo
        End Get
        Set(ByVal value As Int32)
            _id_gold_custo = value
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
    Public Property dt_referencia_inicial() As String
        Get
            Return _dt_referencia_inicial
        End Get
        Set(ByVal value As String)
            _dt_referencia_inicial = value
        End Set
    End Property
    Public Property dt_referencia_final() As String
        Get
            Return _dt_referencia_final
        End Get
        Set(ByVal value As String)
            _dt_referencia_final = value
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
    Public Property st_selecao() As String
        Get
            Return _st_selecao
        End Get
        Set(ByVal value As String)
            _st_selecao = value
        End Set
    End Property
    Public Property ds_anotacao_aprovador() As String
        Get
            Return _ds_anotacao_aprovador
        End Get
        Set(ByVal value As String)
            _ds_anotacao_aprovador = value
        End Set
    End Property
    Public Property nr_valor() As Decimal
        Get
            Return _nr_valor
        End Get
        Set(ByVal value As Decimal)
            _nr_valor = value
        End Set
    End Property
    Public Property nr_margem() As ArrayList
        Get
            Return _nr_margem
        End Get
        Set(ByVal value As ArrayList)
            _nr_margem = value
        End Set
    End Property
    Public Property id_gold_faixa_custo() As ArrayList
        Get
            Return _id_gold_faixa_custo
        End Get
        Set(ByVal value As ArrayList)
            _id_gold_faixa_custo = value
        End Set
    End Property
    Public Property id_gold_custo_margem() As ArrayList
        Get
            Return _id_gold_custo_margem
        End Get
        Set(ByVal value As ArrayList)
            _id_gold_custo_margem = value
        End Set
    End Property
    Public Property nr_adicional_volume() As ArrayList
        Get
            Return _nr_adicional_volume
        End Get
        Set(ByVal value As ArrayList)
            _nr_adicional_volume = value
        End Set
    End Property
    Public Property id_gold_faixa_volume() As ArrayList
        Get
            Return _id_gold_faixa_volume
        End Get
        Set(ByVal value As ArrayList)
            _id_gold_faixa_volume = value
        End Set
    End Property
    Public Property id_gold_custo_volume() As ArrayList
        Get
            Return _id_gold_custo_volume
        End Get
        Set(ByVal value As ArrayList)
            _id_gold_custo_volume = value
        End Set
    End Property
    Public Property nr_adicional_crescimento() As ArrayList
        Get
            Return _nr_adicional_crescimento
        End Get
        Set(ByVal value As ArrayList)
            _nr_adicional_crescimento = value
        End Set
    End Property
    Public Property id_gold_faixa_crescimento() As ArrayList
        Get
            Return _id_gold_faixa_crescimento
        End Get
        Set(ByVal value As ArrayList)
            _id_gold_faixa_crescimento = value
        End Set
    End Property
    Public Property id_gold_custo_crescimento() As ArrayList
        Get
            Return _id_gold_custo_crescimento
        End Get
        Set(ByVal value As ArrayList)
            _id_gold_custo_crescimento = value
        End Set
    End Property
    Public Property nr_adicional_eficiencia() As ArrayList
        Get
            Return _nr_adicional_eficiencia
        End Get
        Set(ByVal value As ArrayList)
            _nr_adicional_eficiencia = value
        End Set
    End Property
    Public Property id_gold_faixa_eficiencia() As ArrayList
        Get
            Return _id_gold_faixa_eficiencia
        End Get
        Set(ByVal value As ArrayList)
            _id_gold_faixa_eficiencia = value
        End Set
    End Property
    Public Property id_gold_custo_eficiencia() As ArrayList
        Get
            Return _id_gold_custo_eficiencia
        End Get
        Set(ByVal value As ArrayList)
            _id_gold_custo_eficiencia = value
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

    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Int32)

        Me.id_gold_custo = id
        loadGoldCusto()

    End Sub

    Public Function getGoldCustoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCusto", parameters, "ms_gold_custo")
            Return dataSet

        End Using

    End Function
    Public Function getGoldCustoByPeriodo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCustoByPeriodo", parameters, "ms_gold_custo")
            Return dataSet

        End Using

    End Function
    Public Function getGoldCustoMargemByRange() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getGoldCustoMargemByRange", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getGoldCustoVolumeByRange() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getGoldCustoVolumeByRange", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getGoldCustoCrescimentoByRange() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getGoldCustoCrescimentoByRange", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getGoldCustoEficienciaByRange() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getGoldCustoEficienciaByRange", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function

    'Public Function getPrecoBase() As DataSet

    '    Using data As New DataAccess

    '        Dim precobase As New PrecoBase
    '        precobase.id_preco_objetivo = Me.id_preco_objetivo

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(precobase)
    '        Dim dataSet As New DataSet

    '        data.Fill(dataSet, "ms_getPrecosBase", parameters, "ms_preco_base")
    '        Return dataSet

    '    End Using

    'End Function

    'Public Function getAdicionalRegiao() As DataSet

    '    Using data As New DataAccess

    '        Dim adicregiao As New PrecoAdicionalRegiao
    '        adicregiao.id_preco_objetivo = Me.id_preco_objetivo

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(adicregiao)
    '        Dim dataSet As New DataSet

    '        data.Fill(dataSet, "ms_getAdicionaisRegiao", parameters, "ms_adicional_regiao")
    '        Return dataSet

    '    End Using

    'End Function

    'Public Function getAdicionalMercado() As DataSet

    '    Using data As New DataAccess

    '        Dim adicmercado As New PrecoAdicionalMercado
    '        adicmercado.id_preco_objetivo = Me.id_preco_objetivo

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(adicmercado)
    '        Dim dataSet As New DataSet

    '        data.Fill(dataSet, "ms_getAdicionaisMercado", parameters, "ms_adicional_mercado")
    '        Return dataSet

    '    End Using

    'End Function

    'Public Function getAdicionalVolume() As DataSet

    '    Using data As New DataAccess

    '        Dim adicvolume As New PrecoAdicionalVolume
    '        adicvolume.id_preco_objetivo = Me.id_preco_objetivo

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(adicvolume)
    '        Dim dataSet As New DataSet

    '        data.Fill(dataSet, "ms_getAdicionaisVolume", parameters, "ms_adicional_volume")
    '        Return dataSet

    '    End Using

    'End Function

    Private Sub loadGoldCusto()

        'Carrega Custos Gold
        Dim dsPrecoObjetivo As DataSet = getGoldCustoByFilters()
        ParametersEngine.persistObjectValues(dsPrecoObjetivo.Tables(0).Rows(0), Me)

        ''Carrega Margem
        'Dim dsCustoMargem As DataSet = getGoldCustoMargem()
        'Dim goldcustomargem As New GoldCustoMargem()
        'For i As Int32 = 0 To dsCustoMargem.Tables(0).Rows.Count - 1
        '    ParametersEngine.persistObjectValues(dsCustoMargem.Tables(0).Rows(i), goldcustomargem)
        '    nr_custo_margem(i) = goldcustomargem.nr_margem
        'Next

        ''Carrega Crescimento
        'Dim dsAdicionalRegiao As DataSet = getAdicionalRegiao()
        'Dim adicregiao As New PrecoAdicionalRegiao()
        'For i As Int32 = 0 To dsAdicionalRegiao.Tables(0).Rows.Count - 1
        '    ParametersEngine.persistObjectValues(dsAdicionalRegiao.Tables(0).Rows(i), adicregiao)
        '    nr_adic_regiao(i) = adicregiao.nr_adic_regiao
        'Next

        ''Carrega eficiencia dieta
        'Dim dsAdicionalMercado As DataSet = getAdicionalMercado()
        'Dim adicmercado As New PrecoAdicionalMercado()
        'For i As Int32 = 0 To dsAdicionalMercado.Tables(0).Rows.Count - 1
        '    ParametersEngine.persistObjectValues(dsAdicionalMercado.Tables(0).Rows(i), adicmercado)
        '    nr_adic_mercado(i) = adicmercado.nr_adic_mercado
        'Next

        ''Carrega adicional volume
        'Dim dsAdicionalVolume As DataSet = getAdicionalVolume()

        '' 15/08/2008 - i 
        'If dsAdicionalVolume.Tables(0).Rows.Count > 0 Then
        '    id_faixa_volume.Add(Convert.ToInt32(dsAdicionalVolume.Tables(0).Rows(0).Item("id_faixa_volume")))
        'End If



    End Sub


    Public Function insertGoldCusto()

        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Try

            Dim parameters As List(Of Parameters)

            'Insere Gold Custo
            parameters = ParametersEngine.getParametersFromObject(Me)
            Me.id_gold_custo = CType(transacao.ExecuteScalar("ms_insertGoldCusto", parameters, ExecuteType.Insert), Int32)

            '====================================================================
            'Atualiza Gold Custo Margem (todas as margens de custos operacionais)
            '====================================================================
            Dim goldcustomargem As New GoldCustoMargem()
            goldcustomargem.id_gold_custo = Me.id_gold_custo
            goldcustomargem.id_modificador = Me.id_modificador
            goldcustomargem.id_situacao = Me.id_situacao

            For i As Int32 = 0 To nr_margem.Count - 1
                goldcustomargem.id_gold_faixa_custo = id_gold_faixa_custo(i)
                goldcustomargem.nr_margem = nr_margem(i)
                parameters = ParametersEngine.getParametersFromObject(goldcustomargem)
                transacao.Execute("ms_insertGoldCustoMargem", parameters, ExecuteType.Insert)
            Next

            '====================================================================
            'Atualiza Gold Custo Volume 
            '====================================================================
            Dim goldcustovolume As New GoldCustoVolume()
            goldcustovolume.id_gold_custo = Me.id_gold_custo
            goldcustovolume.id_modificador = Me.id_modificador
            goldcustovolume.id_situacao = Me.id_situacao

            For i As Int32 = 0 To nr_adicional_volume.Count - 1
                goldcustovolume.id_gold_faixa_volume = id_gold_faixa_volume(i)
                goldcustovolume.nr_adicional_volume = nr_adicional_volume(i)
                parameters = ParametersEngine.getParametersFromObject(goldcustovolume)
                transacao.Execute("ms_insertGoldCustoVolume", parameters, ExecuteType.Insert)
            Next

            '====================================================================
            'Atualiza Gold Custo Crescimento 
            '====================================================================
            Dim goldcustocrescimento As New GoldCustoCrescimento()
            goldcustocrescimento.id_gold_custo = Me.id_gold_custo
            goldcustocrescimento.id_modificador = Me.id_modificador
            goldcustocrescimento.id_situacao = Me.id_situacao

            For i As Int32 = 0 To nr_adicional_crescimento.Count - 1
                goldcustocrescimento.id_gold_faixa_crescimento = id_gold_faixa_crescimento(i)
                goldcustocrescimento.nr_adicional_crescimento = nr_adicional_crescimento(i)
                parameters = ParametersEngine.getParametersFromObject(goldcustocrescimento)
                transacao.Execute("ms_insertGoldCustoCrescimento", parameters, ExecuteType.Insert)
            Next

            '====================================================================
            'Atualiza Gold Custo Eficiencia
            '====================================================================
            Dim goldcustoeficiencia As New GoldCustoEficiencia()
            goldcustoeficiencia.id_gold_custo = Me.id_gold_custo
            goldcustoeficiencia.id_modificador = Me.id_modificador
            goldcustoeficiencia.id_situacao = Me.id_situacao

            For i As Int32 = 0 To nr_adicional_eficiencia.Count - 1
                goldcustoeficiencia.id_gold_faixa_eficiencia = id_gold_faixa_eficiencia(i)
                goldcustoeficiencia.nr_adicional_eficiencia = nr_adicional_eficiencia(i)
                parameters = ParametersEngine.getParametersFromObject(goldcustoeficiencia)
                transacao.Execute("ms_insertGoldCustoEficiencia", parameters, ExecuteType.Insert)
            Next

            transacao.Commit()

            Return Me.id_gold_custo

        Catch ex As Exception
            transacao.RollBack()
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Sub updateGoldCusto()

        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Try

            Dim parameters As List(Of Parameters)

            'Atualiza Gold Custo 
            parameters = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_updateGoldCusto", parameters, ExecuteType.Update)

            '====================================================================
            'Atualiza Gold Custo Margem (todas as margens de custos operacionais)
            '====================================================================
            Dim goldcustomargem As New GoldCustoMargem()
            goldcustomargem.id_gold_custo = Me.id_gold_custo
            goldcustomargem.id_modificador = Me.id_modificador
            goldcustomargem.id_situacao = Me.id_situacao

            For i As Int32 = 0 To nr_margem.Count - 1
                goldcustomargem.id_gold_custo_margem = id_gold_custo_margem(i)
                goldcustomargem.nr_margem = nr_margem(i)
                parameters = ParametersEngine.getParametersFromObject(goldcustomargem)
                transacao.Execute("ms_updateGoldCustoMargem", parameters, ExecuteType.Insert)
            Next

            '====================================================================
            'Atualiza Gold Custo Volume
            '====================================================================
            Dim goldcustovolume As New GoldCustoVolume()
            goldcustovolume.id_gold_custo = Me.id_gold_custo
            goldcustovolume.id_modificador = Me.id_modificador
            goldcustovolume.id_situacao = Me.id_situacao

            For i As Int32 = 0 To nr_adicional_volume.Count - 1
                goldcustovolume.id_gold_custo_volume = id_gold_custo_volume(i)
                goldcustovolume.nr_adicional_volume = nr_adicional_volume(i)
                parameters = ParametersEngine.getParametersFromObject(goldcustovolume)
                transacao.Execute("ms_updateGoldCustoVolume", parameters, ExecuteType.Insert)
            Next

            '====================================================================
            'Atualiza Gold Custo Crescimento
            '====================================================================
            Dim goldcustocrescimento As New GoldCustoCrescimento()
            goldcustocrescimento.id_gold_custo = Me.id_gold_custo
            goldcustocrescimento.id_modificador = Me.id_modificador
            goldcustocrescimento.id_situacao = Me.id_situacao

            For i As Int32 = 0 To nr_adicional_crescimento.Count - 1
                goldcustocrescimento.id_gold_custo_crescimento = id_gold_custo_crescimento(i)
                goldcustocrescimento.nr_adicional_crescimento = nr_adicional_crescimento(i)
                parameters = ParametersEngine.getParametersFromObject(goldcustocrescimento)
                transacao.Execute("ms_updateGoldCustoCrescimento", parameters, ExecuteType.Insert)
            Next

            '====================================================================
            'Atualiza Gold Custo Eficiencia
            '====================================================================
            Dim goldcustoeficiencia As New GoldCustoEficiencia()
            goldcustoeficiencia.id_gold_custo = Me.id_gold_custo
            goldcustoeficiencia.id_modificador = Me.id_modificador
            goldcustoeficiencia.id_situacao = Me.id_situacao

            For i As Int32 = 0 To nr_adicional_eficiencia.Count - 1
                goldcustoeficiencia.id_gold_custo_eficiencia = id_gold_custo_eficiencia(i)
                goldcustoeficiencia.nr_adicional_eficiencia = nr_adicional_eficiencia(i)
                parameters = ParametersEngine.getParametersFromObject(goldcustoeficiencia)
                transacao.Execute("ms_updateGoldCustoEficiencia", parameters, ExecuteType.Insert)
            Next

            transacao.Commit()
        Catch ex As Exception
            transacao.RollBack()
            Throw New Exception(ex.Message)
        End Try


    End Sub

    Public Sub deleteGoldCusto()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteGoldCusto", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function getGoldCusto1NByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCusto1N", parameters, "ms_gold_custo")
            Return dataSet

        End Using

    End Function
    Public Function getGoldCusto2NByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCusto2N", parameters, "ms_gold_custo")
            Return dataSet

        End Using

    End Function
    Public Sub updateGoldCustoAprovarSelecionados()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldCustoAprovarSelecionados", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGoldCustoAprovador()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldCustoAprovador", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGoldCustoSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldCustoSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGoldCustoTodos1N()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldCustoTodos1N", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGoldCustoTodos2N()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldCustoTodos2N", parameters, ExecuteType.Update)

        End Using

    End Sub

End Class