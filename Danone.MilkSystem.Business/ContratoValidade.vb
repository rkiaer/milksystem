Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ContratoValidade

    Private _id_contrato_validade As Int32
    Private _id_contrato_validade_origem As Int32
    Private _id_contrato As Int32
    Private _id_estabelecimento As Int32
    Private _dt_referencia As String
    Private _st_referencia_vigente As String
    Private _id_contrato_justificativa As Int32
    Private _st_aprovado As String
    Private _nm_aprovado As String
    Private _id_situacao As Int32
    Private _id_situacao_contrato As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _st_selecao As String

    Public Property id_contrato_validade() As Int32
        Get
            Return _id_contrato_validade
        End Get
        Set(ByVal value As Int32)
            _id_contrato_validade = value
        End Set
    End Property
    Public Property id_contrato_validade_origem() As Int32
        Get
            Return _id_contrato_validade_origem
        End Get
        Set(ByVal value As Int32)
            _id_contrato_validade_origem = value
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
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
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
    Public Property id_contrato_justificativa() As Int32
        Get
            Return _id_contrato_justificativa
        End Get
        Set(ByVal value As Int32)
            _id_contrato_justificativa = value
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
    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
        End Set
    End Property
    Public Property id_situacao_contrato() As Int32
        Get
            Return _id_situacao_contrato
        End Get
        Set(ByVal value As Int32)
            _id_situacao_contrato = value
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

        Me._id_contrato_validade = id
        loadContratoValidade()

    End Sub

    Public Sub New()

    End Sub

    Public Function getContratoValidadeByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContratoValidade", parameters, "ms_contrato_validade")
            Return dataSet

        End Using

    End Function
    
    Public Function getContratoValidade1NByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContratoValidade1N", parameters, "ms_contrato_validade")
            Return dataSet

        End Using

    End Function
    Public Function getContratoValidade2NByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContratoValidade2N", parameters, "ms_contrato_validade")
            Return dataSet

        End Using

    End Function

    Private Sub loadContratoValidade()

        Dim dataSet As DataSet = getContratoValidadeByFilters()
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

    Public Function insertContratoValidade() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertContratoValidade", parameters, ExecuteType.Insert), Int32)

        End Using

    End Function
    Public Sub updateContratoSelecao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateContratoSelecao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateContratoSelecaoTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateContratoSelecaoTodos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateContratoValidadeSituacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateContratoValidadeSituacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateContratoValidade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateContratoValidade", parameters, ExecuteType.Update)

        End Using

    End Sub
    

    Public Sub deleteContratoValidade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteContratoValidade", parameters, ExecuteType.Delete)

        End Using

    End Sub
    Public Sub updateContratoAprovarSelecionados1Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateContratoAprovarSelecionados1Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateContratoAprovarSelecionados2Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateContratoAprovarSelecionados2Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateContratoNaoAprovarSelecionados1Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateContratoNaoAprovarSelecionados1Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateContratoNaoAprovarSelecionados2Nivel()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateContratoNaoAprovarSelecionados2Nivel", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getContratoValidadeTodos() As DataSet
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContratoValidadeTodos", parameters, "ms_contrato_validade")
            Return dataSet

        End Using
    End Function
 

    Public Sub updateContratoValidadeDefault()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateContratoValidadeDefault", parameters, ExecuteType.Update)

        End Using
    End Sub

End Class
