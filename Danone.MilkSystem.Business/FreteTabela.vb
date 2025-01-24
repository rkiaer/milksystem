Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class FreteTabela

    Private _id_estabelecimento As Int32
    Private _id_frete_tabela As Int32
    Private _id_frete_tabela_excecao As Int32
    Private _id_transportador As Int32
    Private _id_cooperativa As Int32
    Private _id_linha As Int32
    Private _dt_validade As String
    Private _id_tipo_frete As Int32
    Private _id_tipo_equipamento As Int32
    Private _nr_custo_km As Decimal
    Private _nr_custo_fixo_diaria As Decimal
    Private _nr_custo_fixo_mes As Decimal
    Private _nr_perc_seguro_carga As Decimal
    Private _id_custo_fixo_mes_tipo As Int32
    Private _nr_custo_fixo_mes_veiculos As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _st_referencia_vigente As String
    Private _id_situacao_aprovacao As Int32
    Private _nm_situacao_aprovacao As String
    Private _st_selecao As String

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property id_custo_fixo_mes_tipo() As Int32
        Get
            Return _id_custo_fixo_mes_tipo
        End Get
        Set(ByVal value As Int32)
            _id_custo_fixo_mes_tipo = value
        End Set
    End Property
    Public Property nr_custo_fixo_mes_veiculos() As Int32
        Get
            Return _nr_custo_fixo_mes_veiculos
        End Get
        Set(ByVal value As Int32)
            _nr_custo_fixo_mes_veiculos = value
        End Set
    End Property
    Public Property id_frete_tabela() As Int32
        Get
            Return _id_frete_tabela
        End Get
        Set(ByVal value As Int32)
            _id_frete_tabela = value
        End Set
    End Property
    Public Property id_frete_tabela_excecao() As Int32
        Get
            Return _id_frete_tabela_excecao
        End Get
        Set(ByVal value As Int32)
            _id_frete_tabela_excecao = value
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
    Public Property id_linha() As Int32
        Get
            Return _id_linha
        End Get
        Set(ByVal value As Int32)
            _id_linha = value
        End Set
    End Property
    Public Property id_cooperativa() As Int32
        Get
            Return _id_cooperativa
        End Get
        Set(ByVal value As Int32)
            _id_cooperativa = value
        End Set
    End Property
    Public Property st_referencia_vigente() As String
        Get
            Return _st_referencia_vigente
        End Get
        Set(ByVal value As String)
            _st_referencia_vigente = value
        End Set
    End Property

    Public Property dt_validade() As String
        Get
            Return _dt_validade
        End Get
        Set(ByVal value As String)
            _dt_validade = value
        End Set
    End Property
    Public Property nr_custo_km() As Decimal
        Get
            Return _nr_custo_km
        End Get
        Set(ByVal value As Decimal)
            _nr_custo_km = value
        End Set
    End Property

    Public Property nr_custo_fixo_diaria() As Decimal
        Get
            Return _nr_custo_fixo_diaria
        End Get
        Set(ByVal value As Decimal)
            _nr_custo_fixo_diaria = value
        End Set
    End Property
    Public Property nr_custo_fixo_mes() As Decimal
        Get
            Return _nr_custo_fixo_mes
        End Get
        Set(ByVal value As Decimal)
            _nr_custo_fixo_mes = value
        End Set
    End Property

    Public Property nr_perc_seguro_carga() As Decimal
        Get
            Return _nr_perc_seguro_carga
        End Get
        Set(ByVal value As Decimal)
            _nr_perc_seguro_carga = value
        End Set
    End Property

    Public Property id_tipo_equipamento() As Int32
        Get
            Return _id_tipo_equipamento
        End Get
        Set(ByVal value As Int32)
            _id_tipo_equipamento = value
        End Set
    End Property
    Public Property id_tipo_frete() As Int32
        Get
            Return _id_tipo_frete
        End Get
        Set(ByVal value As Int32)
            _id_tipo_frete = value
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
    Public Property id_situacao_aprovacao() As Int32
        Get
            Return _id_situacao_aprovacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao_aprovacao = value
        End Set
    End Property
    Public Property nm_situacao_aprovacao() As String
        Get
            Return _nm_situacao_aprovacao
        End Get
        Set(ByVal value As String)
            _nm_situacao_aprovacao = value
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

    Public Sub New(ByVal id As Int32)

        Me._id_frete_tabela = id
        loadFreteTabela()

    End Sub

    Public Sub New()

    End Sub

    Public Function getFreteTabelaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFreteTabela", parameters, "ms_frete_tabela")
            Return dataSet

        End Using

    End Function
    Public Function getFreteTabelaExcecao() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFreteTabelaExcecao", parameters, "ms_frete_tabela_excecao")
            Return dataSet

        End Using

    End Function
    Public Function getFreteTabelaConsValidade() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFreteTabelaConsValidade", parameters, "ms_frete_tabela")
            Return dataSet

        End Using

    End Function
    Public Function getFreteTabelaHeader() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFreteTabelaHeader", parameters, "ms_frete_tabela")
            Return dataSet

        End Using

    End Function
    Private Sub loadFreteTabela()

        Dim dataSet As DataSet = getFreteTabelaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertFreteTabelaExcecao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertFreteTabelaExcecao", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertFreteTabela() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertFreteTabela", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
     Public Sub deleteFreteTabela()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteFreteTabela", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub deleteFreteTabelaExcecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteFreteTabelaExcecao", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub updateFreteTabelaAprovarSelecionados1Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFreteTabelaAprovarSelecionados1Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateFreteTabelaAprovarSelecionados2Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFreteTabelaAprovarSelecionados2Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateFreteTabelaNaoAprovarSelecionados1Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFreteTabelaNaoAprovarSelecionados1Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateFreteTabelaNaoAprovarSelecionados2Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFreteTabelaNaoAprovarSelecionados2Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateFreteTabelaSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFreteTabelaSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateFreteTabelaSelecaoTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFreteTabelaSelecaoTodos", parameters, ExecuteType.Update)

        End Using

    End Sub

End Class
