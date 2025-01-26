Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GoldCustoProdutor

    Private _id_gold_custo_produtor As Int32
    Private _id_estabelecimento As Int32
    Private _ds_estabelecimento As String
    Private _id_propriedade As Int32
    Private _cd_pessoa As String
    Private _ds_produtor As String
    Private _nm_propriedade As String
    Private _ds_propriedade As String
    Private _dt_referencia_inicial As String
    Private _dt_referencia_final As String
    Private _st_aprovado As String
    Private _st_selecao As String
    Private _ds_anotacao_aprovador As String
    Private _nr_volume_planejado As Decimal
    Private _nr_taxa_crescimento_ano As Decimal
    Private _nr_taxa_vacas_lactacao As Decimal
    Private _nr_quantidade_total As Decimal  ' Vem da view ms_view_gold_custo_produtor_dieta
    Private _nr_custo_dieta_total As Decimal ' Vem da view ms_view_gold_custo_produtor_dieta  

    Private _nr_custo_operacional As New ArrayList   ' Arraylist porque não é definido a quantidade de itens do array (se fosse fixo, exemplo 12, poderia ser array de decimal)
    Private _id_gold_custo_produtor_operacional_item As New ArrayList
    Private _id_gold_custo_produtor_operacional As New ArrayList  ' Para o Update
    'Private __nr_custo_operacional(11) As Decimal

    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_gold_custo_produtor() As Int32
        Get
            Return _id_gold_custo_produtor
        End Get
        Set(ByVal value As Int32)
            _id_gold_custo_produtor = value
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
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
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
    Public Property nm_propriedade() As String
        Get
            Return _nm_propriedade
        End Get
        Set(ByVal value As String)
            _nm_propriedade = value
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
    Public Property nr_custo_operacional() As ArrayList
        Get
            Return _nr_custo_operacional
        End Get
        Set(ByVal value As ArrayList)
            _nr_custo_operacional = value
        End Set
    End Property
    Public Property id_gold_custo_produtor_operacional_item() As ArrayList
        Get
            Return _id_gold_custo_produtor_operacional_item
        End Get
        Set(ByVal value As ArrayList)
            _id_gold_custo_produtor_operacional_item = value
        End Set
    End Property
    Public Property id_gold_custo_produtor_operacional() As ArrayList
        Get
            Return _id_gold_custo_produtor_operacional
        End Get
        Set(ByVal value As ArrayList)
            _id_gold_custo_produtor_operacional = value
        End Set
    End Property
    Public Property nr_volume_planejado() As Decimal
        Get
            Return _nr_volume_planejado
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_planejado = value
        End Set
    End Property
    Public Property nr_taxa_crescimento_ano() As Decimal
        Get
            Return _nr_taxa_crescimento_ano
        End Get
        Set(ByVal value As Decimal)
            _nr_taxa_crescimento_ano = value
        End Set
    End Property
    Public Property nr_taxa_vacas_lactacao() As Decimal
        Get
            Return _nr_taxa_vacas_lactacao
        End Get
        Set(ByVal value As Decimal)
            _nr_taxa_vacas_lactacao = value
        End Set
    End Property
    Public Property nr_quantidade_total() As Decimal
        Get
            Return _nr_quantidade_total
        End Get
        Set(ByVal value As Decimal)
            _nr_quantidade_total = value
        End Set
    End Property
    Public Property nr_custo_dieta_total() As Decimal
        Get
            Return _nr_custo_dieta_total
        End Get
        Set(ByVal value As Decimal)
            _nr_custo_dieta_total = value
        End Set
    End Property

    'Public Property nr_custo_operacional() As Decimal()
    '    Get
    '        Return _nr_custo_operacional
    '    End Get
    '    Set(ByVal value() As Decimal)
    '        _nr_custo_operacional = value
    '    End Set
    'End Property



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

        Me.id_gold_custo_produtor = id
        loadGoldCustoProdutor()

    End Sub

    Public Function getGoldCustoProdutorByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCustoProdutor", parameters, "ms_gold_custo_produtor")
            Return dataSet

        End Using

    End Function
    Public Function getGoldCustoProdutorByPeriodo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCustoProdutorByPeriodo", parameters, "ms_gold_custo_produtor")
            Return dataSet

        End Using

    End Function


    Private Sub loadGoldCustoProdutor()

        'Carrega Custos Gold
        Dim dsPrecoObjetivo As DataSet = getGoldCustoProdutorByFilters()
        ParametersEngine.persistObjectValues(dsPrecoObjetivo.Tables(0).Rows(0), Me)


    End Sub


    Public Function insertGoldCustoProdutor()

        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Try

            Dim parameters As List(Of Parameters)

            'Insere preco objetivo
            parameters = ParametersEngine.getParametersFromObject(Me)
            Me.id_gold_custo_produtor = CType(transacao.ExecuteScalar("ms_insertGoldCustoProdutor", parameters, ExecuteType.Insert), Int32)

            'Insere Gold Custo Produtor Operacional (todos os custos)
            Dim goldcustoprodutoroperacional As New GoldCustoProdutorOperacional()
            goldcustoprodutoroperacional.id_gold_custo_produtor = Me.id_gold_custo_produtor
            goldcustoprodutoroperacional.id_modificador = Me.id_modificador
            goldcustoprodutoroperacional.id_situacao = Me.id_situacao

            For i As Int32 = 0 To nr_custo_operacional.Count - 1
                goldcustoprodutoroperacional.id_gold_custo_produtor_operacional_item = id_gold_custo_produtor_operacional_item(i)
                goldcustoprodutoroperacional.nr_custo_operacional = nr_custo_operacional(i)
                parameters = ParametersEngine.getParametersFromObject(goldcustoprodutoroperacional)
                transacao.Execute("ms_insertGoldCustoProdutorOperacional", parameters, ExecuteType.Insert)
            Next


            transacao.Commit()

            Return Me.id_gold_custo_produtor

        Catch ex As Exception
            transacao.RollBack()
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Sub updateGoldCustoProdutor()

        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Try

            Dim parameters As List(Of Parameters)

            'Atualiza Gold Custo Produtor
            parameters = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_updateGoldCustoProdutor", parameters, ExecuteType.Update)

            'Atualiza Gold Custo Produtor Operacional (todos os custos)
            Dim goldcustoprodutoroperacional As New GoldCustoProdutorOperacional()
            goldcustoprodutoroperacional.id_gold_custo_produtor = Me.id_gold_custo_produtor
            goldcustoprodutoroperacional.id_modificador = Me.id_modificador
            goldcustoprodutoroperacional.id_situacao = Me.id_situacao

            For i As Int32 = 0 To nr_custo_operacional.Count - 1
                goldcustoprodutoroperacional.id_gold_custo_produtor_operacional = id_gold_custo_produtor_operacional(i)
                goldcustoprodutoroperacional.nr_custo_operacional = nr_custo_operacional(i)
                parameters = ParametersEngine.getParametersFromObject(goldcustoprodutoroperacional)
                transacao.Execute("ms_updateGoldCustoProdutorOperacional", parameters, ExecuteType.Insert)
            Next

            transacao.Commit()
        Catch ex As Exception
            transacao.RollBack()
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub deleteGoldCustoProdutor()    

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteGoldCustoProdutor", parameters, ExecuteType.Delete)

        End Using


    End Sub


    Public Function getGoldCustoProdutor1NByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCustoProdutor1N", parameters, "ms_gold_custo_produtor")
            Return dataSet

        End Using

    End Function
    Public Function getGoldCustoProdutor2NByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCustoProdutor2N", parameters, "ms_gold_custo")
            Return dataSet

        End Using

    End Function
    Public Sub updateGoldCustoProdutorAprovarSelecionados()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldCustoProdutorAprovarSelecionados", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGoldCustoProdutorAprovador()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldCustoProdutorAprovador", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGoldCustoProdutorSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldCustoProdutorSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGoldCustoProdutorTodos1N()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldCustoProdutorTodos1N", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGoldCustoProdutorTodos2N()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldCustoProdutorTodos2N", parameters, ExecuteType.Update)

        End Using

    End Sub

End Class