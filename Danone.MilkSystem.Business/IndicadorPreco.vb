Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class IndicadorPreco

    Private _id_indicador_preco As Int32
    Private _id_indicador_tipo As Int32
    Private _cd_indicador_tipo As String
    Private _nm_indicador_tipo As String
    Private _ds_indicador_tipo As String
    Private _dt_referencia As String
    Private _nr_valor As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _id_criacao As Int32
    Private _dt_modificacao As String
    Private _dt_criacao As String
    Private _id_situacao_indicador_preco As Int32
    Private _nm_situacao_indicador_preco As String
    Private _st_selecao As String


    Public Property id_indicador_preco() As Int32
        Get
            Return _id_indicador_preco
        End Get
        Set(ByVal value As Int32)
            _id_indicador_preco = value
        End Set
    End Property
    Public Property id_indicador_tipo() As Int32
        Get
            Return _id_indicador_tipo
        End Get
        Set(ByVal value As Int32)
            _id_indicador_tipo = value
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
    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
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
    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
        End Set
    End Property
    Public Property nm_indicador_tipo() As String
        Get
            Return _nm_indicador_tipo
        End Get
        Set(ByVal value As String)
            _nm_indicador_tipo = value
        End Set
    End Property

    Public Property cd_indicador_tipo() As String
        Get
            Return _cd_indicador_tipo
        End Get
        Set(ByVal value As String)
            _cd_indicador_tipo = value
        End Set
    End Property
    Public Property ds_indicador_tipo() As String
        Get
            Return _ds_indicador_tipo
        End Get
        Set(ByVal value As String)
            _ds_indicador_tipo = value
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
    Public Property nr_valor() As Decimal
        Get
            Return _nr_valor
        End Get
        Set(ByVal value As Decimal)
            _nr_valor = value
        End Set
    End Property
    Public Property id_situacao_indicador_preco() As Int32
        Get
            Return _id_situacao_indicador_preco
        End Get
        Set(ByVal value As Int32)
            _id_situacao_indicador_preco = value
        End Set
    End Property
    Public Property nm_situacao_indicador_preco() As String
        Get
            Return _nm_situacao_indicador_preco
        End Get
        Set(ByVal value As String)
            _nm_situacao_indicador_preco = value
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

        Me.id_indicador_preco = id
        loadIndicadorPreco()

    End Sub

    Public Sub New()

    End Sub

    Public Function getIndicadorPrecoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getIndicadorPreco", parameters, "ms_indicador_preco")
            Return dataSet

        End Using

    End Function

    Private Sub loadIndicadorPreco()

        Dim dataSet As DataSet = getIndicadorPrecoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertIndicadorPreco() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertIndicadorPreco", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Sub updateIndicadorPreco()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateIndicadorPreco", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateIndicadorPrecoSituacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateIndicadorPrecoSituacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getIndicadorPrecoMaiorReferencia() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getIndicadorPrecoMaiorReferencia", parameters, ExecuteType.Select), String)

        End Using

    End Function
    Public Function getSituacaoIndicadorPrecoAprovacao() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSituacaoIndicadorPrecoAprovacao", parameters, "ms_indicador_preco")
            Return dataSet

        End Using

    End Function
    Public Sub updateIndicadorPrecoAprovarSelecionados1Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateIndicadorPrecoAprovarSelecionados1Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateIndicadorPrecoAprovarSelecionados2Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateIndicadorPrecoAprovarSelecionados2Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateIndicadorPrecoNaoAprovarSelecionados1Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateIndicadorPrecoNaoAprovarSelecionados1Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateIndicadorPrecoNaoAprovarSelecionados2Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateIndicadorPrecoNaoAprovarSelecionados2Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateIndicadorPrecoSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateIndicadorPrecoSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateIndicadorPrecoSelecaoTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateIndicadorPrecoSelecaoTodos", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
