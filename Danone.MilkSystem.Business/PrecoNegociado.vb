Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PrecoNegociado

    Private _id_preco_negociado As Int32
    Private _id_estabelecimento As Int32
    Private _ds_estabelecimento As String
    Private _cd_pessoa As String
    Private _ds_produtor As String
    Private _id_propriedade As Int32
    Private _nm_propriedade As String
    Private _dt_referencia As String
    Private _ds_referencia As String
    Private _nr_ano As String
    Private _id_tecnico As Int32
    Private _nm_tecnico As String
    Private _nr_preco_negociado As Decimal
    Private _nr_preco_aprovado As Decimal
    Private _id_preco_justificativa As Int32
    Private _nr_total_volume As Decimal
    Private _nr_preco_base As Decimal
    Private _nr_adic_regiao As Decimal
    Private _nr_adic_mercado As Decimal
    Private _nr_adic_volume As Decimal
    Private _subtotal As Decimal
    Private _variacao As Decimal
    Private _st_aprovado As String
    Private _nm_aprovado As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _st_selecao As String
    Private _nr_volume_mensal As Decimal   ' 17/02/2009 Rls16
    Private _id_cluster As Int32 'fran fase 3
    Private _nm_cluster As String 'fran fase 3


    Public Property id_preco_negociado() As Int32
        Get
            Return _id_preco_negociado
        End Get
        Set(ByVal value As Int32)
            _id_preco_negociado = value
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

    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
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

    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property

    Public Property ds_referencia() As String
        Get
            Return _ds_referencia
        End Get
        Set(ByVal value As String)
            _ds_referencia = value
        End Set
    End Property

    Public Property nr_ano() As String
        Get
            Return _nr_ano
        End Get
        Set(ByVal value As String)
            _nr_ano = value
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

    Public Property nm_tecnico() As String
        Get
            Return _nm_tecnico
        End Get
        Set(ByVal value As String)
            _nm_tecnico = value
        End Set
    End Property

    Public Property nr_preco_negociado() As Decimal
        Get
            Return _nr_preco_negociado
        End Get
        Set(ByVal value As Decimal)
            _nr_preco_negociado = value
        End Set
    End Property

    Public Property nr_preco_aprovado() As Decimal
        Get
            Return _nr_preco_aprovado
        End Get
        Set(ByVal value As Decimal)
            _nr_preco_aprovado = value
        End Set
    End Property

    Public Property nr_preco_base() As Decimal
        Get
            Return _nr_preco_base
        End Get
        Set(ByVal value As Decimal)
            _nr_preco_base = value
        End Set
    End Property

    Public Property nr_adic_regiao() As Decimal
        Get
            Return _nr_adic_regiao
        End Get
        Set(ByVal value As Decimal)
            _nr_adic_regiao = value
        End Set
    End Property

    Public Property nr_adic_mercado() As Decimal
        Get
            Return _nr_adic_mercado
        End Get
        Set(ByVal value As Decimal)
            _nr_adic_mercado = value
        End Set
    End Property

    Public Property nr_adic_volume() As Decimal
        Get
            Return _nr_adic_volume
        End Get
        Set(ByVal value As Decimal)
            _nr_adic_volume = value
        End Set
    End Property

    Public Property subtotal() As Decimal
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Decimal)
            _subtotal = value
        End Set
    End Property

    Public Property variacao() As Decimal
        Get
            Return _variacao
        End Get
        Set(ByVal value As Decimal)
            _variacao = value
        End Set
    End Property

    Public Property id_preco_justificativa() As Int32
        Get
            Return _id_preco_justificativa
        End Get
        Set(ByVal value As Int32)
            _id_preco_justificativa = value
        End Set
    End Property

    Public Property nr_total_volume() As Decimal
        Get
            Return _nr_total_volume
        End Get
        Set(ByVal value As Decimal)
            _nr_total_volume = value
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
    Public Property nm_aprovado() As String
        Get
            Return _nm_aprovado
        End Get
        Set(ByVal value As String)
            _nm_aprovado = value
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
    Public Property id_cluster() As Int32
        Get
            Return _id_cluster
        End Get
        Set(ByVal value As Int32)
            _id_cluster = value
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
    Public Property st_selecao() As String
        Get
            Return _st_selecao
        End Get
        Set(ByVal value As String)
            _st_selecao = value
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
    Public Property nm_cluster() As String
        Get
            Return _nm_cluster
        End Get
        Set(ByVal value As String)
            _nm_cluster = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me._id_preco_negociado = id
        loadPrecoNegociado()

    End Sub

    Public Sub New()

    End Sub

    Public Function getPrecoNegociadoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPrecosNegociados", parameters, "ms_preco_negociado")
            Return dataSet

        End Using

    End Function
    Public Function getPrecoNegociadoMedioCluster() As DataSet 'fran fase 3 set/2014

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPrecosNegociadosMedioCluster", parameters, "ms_preco_negociado")
            Return dataSet

        End Using

    End Function
    Public Function getPrecoNegociado1NByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPrecosNegociados1N", parameters, "ms_preco_negociado")
            Return dataSet

        End Using

    End Function
    Public Function getPrecoNegociado2NByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPrecosNegociados2N", parameters, "ms_preco_negociado")
            Return dataSet

        End Using

    End Function

    Private Sub loadPrecoNegociado()

        Dim dataSet As DataSet = getPrecoNegociadoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertPrecoNegociado() As Int32
        'fran dango 2018 julho/2018 i
        'Using data As New DataAccess

        '    Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
        '    Return CType(data.ExecuteScalar("ms_insertPrecosNegociados", parameters, ExecuteType.Insert), Int32)

        'End Using

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'inclui preços negociados
            Me.id_preco_negociado = CType(transacao.ExecuteScalar("ms_insertPrecosNegociados", parameters, ExecuteType.Insert), Int32)

            'atualiza valor preco negociado do mes anterior
            transacao.Execute("ms_updatePrecoNegociadoValorMesAnterior", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()

            Return Me.id_preco_negociado

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
        'fran dango 2018 julho/2018 f

    End Function
    Public Sub updatePrecoNegociadoSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePrecosNegociadosSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updatePrecoNegociado()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePrecosNegociados", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePrecoNegociadoAprovador()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePrecosNegociadosAprovador", parameters, ExecuteType.Update)

        End Using

    End Sub

    'Public Sub updatePrecoNegociadoAprovarTodos_1N()

    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        data.Execute("ms_updatePrecoNegociadoAprovarTodos1N", parameters, ExecuteType.Update)

    '    End Using

    'End Sub
    Public Sub updatePrecoNegociadoAprovarSelecionados()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePrecoNegociadoAprovarSelecionados", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deletePrecoNegociado()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deletePrecosNegociados", parameters, ExecuteType.Delete)

        End Using

    End Sub
    Public Sub updatePrecoNegociadoTodos1N()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePrecosNegociadosTodos1N", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePrecoNegociadoTodos2N()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePrecosNegociadosTodos2N", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePrecoNegociadoVolumeLeite()
        ' 17/02/2009 Rls16 - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePrecoNegociadoVolumeLeite", parameters, ExecuteType.Update)

        End Using
        ' 17/02/2009 Rls16 - f
    End Sub
    Public Function getPrecoNegociadoTodos() As DataSet

        ' 17/02/2009 Rls16 - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPrecosNegociadosTodos", parameters, "ms_preco_negociado")
            Return dataSet

        End Using
        ' 17/02/2009 Rls16 - f

    End Function
    Public Function getPrecoNegociadoMix() As DataSet

        ' 17/02/2009 Rls16 - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPrecosNegociadosMix", parameters, "ms_preco_negociado")
            Return dataSet

        End Using
        ' 17/02/2009 Rls16 - f

    End Function
    Public Function getPrecoNegociadoAdicionalVolume() As Decimal
        ' 19/02/2009 Rls16 - i

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getPrecosNegociadosAdicionalVolume", parameters, ExecuteType.Select), Decimal)

        End Using

        ' 19/02/2009 Rls16 - f

    End Function
    Public Sub updatePrecoNegociadoDefault()
        ' 18/02/2009 Rls16 - i
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePrecoNegociadoDefault", parameters, ExecuteType.Update)

        End Using
        ' 18/02/2009 Rls16 - f
    End Sub

End Class
