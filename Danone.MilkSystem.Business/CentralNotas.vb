Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class CentralNotas
    Private _id_central_notas_importacao As Int32
    Private _id_importacao As Int32
    Private _nr_pedido As Int32
    Private _id_central_pedido As Int32
    Private _id_situacao_central_notas As Int32
    Private _id_cd_divergencia As Int32
    Private _id_tipo_divergencia As Int32
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _ds_chave_acesso As String
    Private _nr_nota_fiscal As String
    Private _dt_emissao As String
    Private _dt_ini As String
    Private _dt_fim As String
    Private _cd_cnpj_emit As String
    Private _nm_emitente As String
    Private _cd_cpf_dest As String
    Private _nm_destino As String
    Private _cd_cnpj_dest As String
    Private _nr_valor_nf As Decimal
    Private _dt_modificacao As String
    Private _cd_cnpj_rem As String
    Private _nm_remetente As String
    Private _st_selecao As String

    Public Property id_central_notas_importacao() As Int32
        Get
            Return _id_central_notas_importacao
        End Get
        Set(ByVal value As Int32)
            _id_central_notas_importacao = value
        End Set
    End Property
    Public Property id_importacao() As Int32
        Get
            Return _id_importacao
        End Get
        Set(ByVal value As Int32)
            _id_importacao = value
        End Set
    End Property
    Public Property id_central_pedido() As Integer
        Get
            Return _id_central_pedido
        End Get
        Set(ByVal value As Integer)
            _id_central_pedido = value
        End Set
    End Property
    Public Property nr_pedido() As Integer
        Get
            Return _nr_pedido
        End Get
        Set(ByVal value As Integer)
            _nr_pedido = value
        End Set
    End Property
    Public Property id_cd_divergencia() As Integer
        Get
            Return _id_cd_divergencia
        End Get
        Set(ByVal value As Integer)
            _id_cd_divergencia = value
        End Set
    End Property
    Public Property id_tipo_divergencia() As Integer
        Get
            Return _id_tipo_divergencia
        End Get
        Set(ByVal value As Integer)
            _id_tipo_divergencia = value
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
    Public Property id_situacao_central_notas() As Int32
        Get
            Return _id_situacao_central_notas
        End Get
        Set(ByVal value As Int32)
            _id_situacao_central_notas = value
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
    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
        End Set
    End Property
    Public Property ds_chave_acesso() As String
        Get
            Return _ds_chave_acesso
        End Get
        Set(ByVal value As String)
            _ds_chave_acesso = value
        End Set
    End Property
    Public Property nr_nota_fiscal() As String
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As String)
            _nr_nota_fiscal = value
        End Set
    End Property
    Public Property dt_emissao() As String
        Get
            Return _dt_emissao
        End Get
        Set(ByVal value As String)
            _dt_emissao = value
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
    Public Property cd_cnpj_emit() As String
        Get
            Return _cd_cnpj_emit
        End Get
        Set(ByVal value As String)
            _cd_cnpj_emit = value
        End Set
    End Property
    Public Property nm_emitente() As String
        Get
            Return _nm_emitente
        End Get
        Set(ByVal value As String)
            _nm_emitente = value
        End Set
    End Property
    Public Property cd_cnpj_rem() As String
        Get
            Return _cd_cnpj_rem
        End Get
        Set(ByVal value As String)
            _cd_cnpj_rem = value
        End Set
    End Property
    Public Property nm_remetente() As String
        Get
            Return _nm_remetente
        End Get
        Set(ByVal value As String)
            _nm_remetente = value
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
    Public Property cd_cnpj_dest() As String
        Get
            Return _cd_cnpj_dest
        End Get
        Set(ByVal value As String)
            _cd_cnpj_dest = value
        End Set
    End Property
    Public Property cd_cpf_dest() As String
        Get
            Return _cd_cpf_dest
        End Get
        Set(ByVal value As String)
            _cd_cpf_dest = value
        End Set
    End Property
    Public Property nm_destino() As String
        Get
            Return _nm_destino
        End Get
        Set(ByVal value As String)
            _nm_destino = value
        End Set
    End Property

    Public Property nr_valor_nf() As Decimal
        Get
            Return _nr_valor_nf
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_nf = value
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
        Me.id_central_notas_importacao = id
        loadCentralNotasImportacao()
    End Sub

    Public Sub New()

    End Sub

    Public Sub atulizarDivergencias()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'atualizar as divergencias
            transacao.Execute("ms_updateCentralNotasImportacaoDivergencias", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub reavaliarDivergencias()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'atualizar as divergencias
            transacao.Execute("ms_updateCentralNotasImportacaoDivergenciasReavaliar", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub atulizarPedidosNotasValidas()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão 
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'inclusao de desconto ao produtor e pagamento ao fornecedor das notas com situacao 6 (notas validas)
            transacao.Execute("ms_insertCentralPedidoPagtosbyNotas", parameters, ExecuteType.Insert)

            'atualizar as notas validas com situacao de incluidas e atualizar a situaçao dos pedidos para finalizado
            transacao.Execute("ms_updateCentralPedidoFinalizacaobyNotas", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub
    Public Sub atulizarPedidosNotasManual()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão 
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'inclusao de desconto ao produtor e pagamento ao fornecedor 
            transacao.Execute("ms_insertCentralPedidoPagtosbyNotasManual", parameters, ExecuteType.Insert)

            'atualizar as notas com situacao de incluidas e atualizar a situaçao dos pedidos para finalizado
            transacao.Execute("ms_updateCentralPedidoFinalizacaobyNotasManual", parameters, ExecuteType.Update)

            'Comita
            transacao.Commit()
            transacao.Dispose()
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Sub

    Public Function getCentralNotasImportacao() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getCentralNotasImportacao", parameters, "ms_central_notas_importacao")
            Return dataSet

        End Using

    End Function
    Public Function getCentralNotasImportacaoByTipoDivergencia() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getCentralNotasImportacaoByTipoDivergencia", parameters, "ms_central_notas_importacao")
            Return dataSet

        End Using

    End Function
    Public Function getCentralNotasImportacaoDivergencia() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getCentralNotasImportacaoDivergencia", parameters, "ms_central_notas_importacao_divergencia")
            Return dataSet

        End Using

    End Function

    Private Sub loadCentralNotasImportacao()

        Dim dataSet As DataSet = getCentralNotasImportacao()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub



    Public Function insertCentralNotasImportacao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralNotasImportacao", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub updateCentralNotasImportacaoSelecao()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralNotasImportacaoSelecao", parameters, ExecuteType.Update)

        End Using
    End Sub
    Public Sub deleteCentralNotasImportacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralNotasImportacao", parameters, ExecuteType.Delete)

        End Using

    End Sub
End Class
