Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GoldPrecoLeite

    Private _id_gold_preco_leite As Int32
    Private _id_gold_custo As Int32
    Private _id_gold_custo_produtor As Int32
    Private _id_estabelecimento As Int32
    Private _ds_estabelecimento As String
    Private _id_propriedade As Int32
    Private _ds_produtor As String
    Private _nm_propriedade As String
    Private _ds_propriedade As String
    Private _dt_referencia_inicial As String
    Private _dt_referencia_final As String
    Private _st_aprovado As String
    Private _st_selecao As String
    Private _ds_anotacao_aprovador As String
    Private _nr_custo_operacional_efetivo As Decimal
    Private _nr_margem_custo_efetivo As Decimal
    Private _nr_margem_volume As Decimal
    Private _nr_margem_crescimento As Decimal
    Private _nr_custo_dieta As Decimal
    Private _nr_eficiencia_dieta As Decimal
    Private _nr_preco_leite As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_gold_preco_leite() As Int32
        Get
            Return _id_gold_preco_leite
        End Get
        Set(ByVal value As Int32)
            _id_gold_preco_leite = value
        End Set
    End Property
    Public Property id_gold_custo() As Int32
        Get
            Return _id_gold_custo
        End Get
        Set(ByVal value As Int32)
            _id_gold_custo = value
        End Set
    End Property
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
    Public Property nr_custo_operacional_efetivo() As Decimal
        Get
            Return _nr_custo_operacional_efetivo
        End Get
        Set(ByVal value As Decimal)
            _nr_custo_operacional_efetivo = value
        End Set
    End Property
    Public Property nr_margem_custo_efetivo() As Decimal
        Get
            Return _nr_margem_custo_efetivo
        End Get
        Set(ByVal value As Decimal)
            _nr_margem_custo_efetivo = value
        End Set
    End Property
    Public Property nr_margem_volume() As Decimal
        Get
            Return _nr_margem_volume
        End Get
        Set(ByVal value As Decimal)
            _nr_margem_volume = value
        End Set
    End Property
    Public Property nr_margem_crescimento() As Decimal
        Get
            Return _nr_margem_crescimento
        End Get
        Set(ByVal value As Decimal)
            _nr_margem_crescimento = value
        End Set
    End Property

    Public Property nr_custo_dieta() As Decimal
        Get
            Return _nr_custo_dieta
        End Get
        Set(ByVal value As Decimal)
            _nr_custo_dieta = value
        End Set
    End Property
    Public Property nr_eficiencia_dieta() As Decimal
        Get
            Return _nr_eficiencia_dieta
        End Get
        Set(ByVal value As Decimal)
            _nr_eficiencia_dieta = value
        End Set
    End Property
    Public Property nr_preco_leite() As Decimal
        Get
            Return _nr_preco_leite
        End Get
        Set(ByVal value As Decimal)
            _nr_preco_leite = value
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

        Me.id_gold_preco_leite = id

    End Sub

    Public Function getGoldPrecoLeiteByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldPrecoLeite", parameters, "ms_gold_preco_leite")
            Return dataSet

        End Using

    End Function
    Public Function insertGoldPrecoLeite() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertGoldPrecoLeite", parameters, ExecuteType.Insert), Int32)

        End Using

    End Function


    Public Sub updateGoldPrecoLeite()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldPrecoLeite", parameters, ExecuteType.Update)

        End Using

    End Sub

 
    Public Function getGoldPrecoLeite1NByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldPrecoLeite1N", parameters, "ms_gold_preco_leite")
            Return dataSet

        End Using

    End Function
    Public Function getGoldPrecoLeite2NByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldPrecoLeite2N", parameters, "ms_gold_preco_leite")
            Return dataSet

        End Using

    End Function
    Public Sub updateGoldPrecoLeiteAprovarSelecionados()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldPrecoLeiteAprovarSelecionados", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGoldPrecoLeiteAprovador()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldPrecoLeiteAprovador", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGoldPrecoLeiteSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldPrecoLeiteSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGoldPrecoLeiteTodos1N()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldPrecoLeiteTodos1N", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGoldPrecoLeiteTodos2N()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldPrecoLeiteTodos2N", parameters, ExecuteType.Update)

        End Using

    End Sub

End Class