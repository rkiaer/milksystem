Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PessoaContrato

    Private _id_pessoa_contrato As Int32
    Private _id_pessoa As Int32
    Private _id_estabelecimento As Int32
    Private _id_contrato As Int32
    Private _dt_inicio_contrato As String
    Private _dt_fim_contrato As String
    Private _dt_rescisao As String
    Private _id_cluster As Int32
    Private _nr_adicional_volume As Int32
    Private _id_situacao As Int32
    Private _id_situacao_pessoa_contrato As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _st_selecao As String

    Public Property id_pessoa_contrato() As Int32
        Get
            Return _id_pessoa_contrato
        End Get
        Set(ByVal value As Int32)
            _id_pessoa_contrato = value
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
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property id_contrato() As Int32
        Get
            Return _id_contrato
        End Get
        Set(ByVal value As Int32)
            _id_contrato = value
        End Set
    End Property
    Public Property dt_inicio_contrato() As String
        Get
            Return _dt_inicio_contrato
        End Get
        Set(ByVal value As String)
            _dt_inicio_contrato = value
        End Set
    End Property
    Public Property dt_fim_contrato() As String
        Get
            Return _dt_fim_contrato
        End Get
        Set(ByVal value As String)
            _dt_fim_contrato = value
        End Set
    End Property
    Public Property dt_rescisao() As String
        Get
            Return _dt_rescisao
        End Get
        Set(ByVal value As String)
            _dt_rescisao = value
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
    Public Property nr_adicional_volume() As Int32
        Get
            Return _nr_adicional_volume
        End Get
        Set(ByVal value As Int32)
            _nr_adicional_volume = value
        End Set
    End Property
    Public Property id_situacao_pessoa_contrato() As Int32
        Get
            Return _id_situacao_pessoa_contrato
        End Get
        Set(ByVal value As Int32)
            _id_situacao_pessoa_contrato = value
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
    Public Property st_selecao() As String
        Get
            Return _st_selecao
        End Get
        Set(ByVal value As String)
            _st_selecao = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me._id_pessoa_contrato = id
        loadPessoaContrato()

    End Sub

    Public Sub New()

    End Sub

    Public Function getPessoaContratoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPessoaContrato", parameters, "ms_pessoa_contrato")
            Return dataSet

        End Using

    End Function
    Public Function getPessoaContratoAprovacao() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPessoaContratoAprovacao", parameters, "ms_pessoa_contrato")
            Return dataSet

        End Using

    End Function
    Public Function getPessoaContrato1NByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPessoaContrato1N", parameters, "ms_pessoa_contrato")
            Return dataSet

        End Using

    End Function
    Public Function getPessoaContrato2NByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPessoaContrato2N", parameters, "ms_pessoa_contrato")
            Return dataSet

        End Using

    End Function

    Private Sub loadPessoaContrato()

        Dim dataSet As DataSet = getPessoaContratoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Sub incluirQualidadeAdicionalVolumebyContratoValidade(Optional ByVal bincluiradicionlvolume As Boolean = True)

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão 
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'se nao é para incluir adicional volume
            If bincluiradicionlvolume = True Then
                'copia e insere o adicional de volume
                transacao.Execute("ms_insertContratoAdicionalVolumebyContratoValidade", parameters, ExecuteType.Insert)

            End If
            'copia e einsere as faixas de qualidade
            transacao.Execute("ms_insertContratoFaixaQualidadebyContratoValidade", parameters, ExecuteType.Insert)

            'Comita
            transacao.Commit()
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub

    'Public Function insertPessoaContrato() As Int32

    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Return CType(data.ExecuteScalar("ms_insertPessoaContrato", parameters, ExecuteType.Insert), Int32)

    '    End Using

    'End Function
    Public Sub atualizarPessoaContrato()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão 
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'incluir pessoa contrato 
            transacao.Execute("ms_updatePessoaContrato", parameters, ExecuteType.Update)

            'atualiza MS_PESSOA com novo contrato adional de volume e cluster
            transacao.Execute("ms_updatePessoaModeloContrato", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub


    Public Sub incluirPessoaContrato()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão 
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'incluir pessoa contrato 
            Me.id_pessoa_contrato = CType(transacao.ExecuteScalar("ms_insertPessoaContrato", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)

            'atualiza MS_PESSOA com novo contrato adional de volume e cluster
            transacao.Execute("ms_updatePessoaModeloContrato", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub updatePessoaContratoSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePessoaContratoSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePessoaContratoSelecaoTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePessoaContratoSelecaoTodos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePessoaContratoSituacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePessoaContratoSituacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePessoaContratoDatas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePessoaContratoDatas", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deletePessoaContrato()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deletePessoaContrato", parameters, ExecuteType.Delete)

        End Using

    End Sub
    Public Sub updatePessoaContratoAprovarSelecionados1Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePessoaContratoAprovarSelecionados1Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePessoaContratoAprovarSelecionados2Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePessoaContratoAprovarSelecionados2Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePessoaContratoNaoAprovarSelecionados1Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePessoaContratoNaoAprovarSelecionados1Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePessoaContratoNaoAprovarSelecionados2Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePessoaContratoNaoAprovarSelecionados2Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getPessoaContratoTodos() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPessoaContratoTodos", parameters, "ms_pessoa_contrato")
            Return dataSet

        End Using
    End Function


    Public Sub updatePessoaContratoDefault()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePessoaContratoDefault", parameters, ExecuteType.Update)

        End Using
    End Sub

End Class
