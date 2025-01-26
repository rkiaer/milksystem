Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class RomaneioNotas
    Private _id_romaneio_notas As Int32
    Private _id_romaneio As Int32
    Private _id_cooperativa As Int32
    Private _id_transportador As Int32
    Private _id_romaneio_tipo_nota As Int32
    Private _ds_chave As String
    Private _nr_po_cooperativa As String
    Private _nr_nota_fiscal As String
    Private _nr_serie As String
    Private _dt_emissao As String
    Private _cd_cnpj_emitente As String
    Private _cd_cnpj_transportador As String
    Private _nr_modelo_frete As Int32
    Private _ds_chave_nfe_leite As String
    Private _nr_valor_nf As Decimal
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nr_valor_icms As Decimal
    Private _cd_cst As String
    Private _cd_cfop As String
    Private _dt_emissao_completa As String
    Private _nr_base_icms As Decimal
    Private _cd_uf_origem As String
    Private _cd_uf_destino As String
    Private _cd_ibge_origem As String
    Private _cd_ibge_destino As String
    Private _ds_protocolo As String

    'Private _dt_ini As String
    'Private _dt_fim As String
    'Private _nm_emitente As String
    'Private _cd_cpf_dest As String
    'Private _nm_destino As String
    'Private _cd_cnpj_dest As String
    'Private _cd_cnpj_rem As String
    'Private _nm_remetente As String
    'Private _st_selecao As String
    'Private _id_central_pedido As Int32
    'Private _id_situacao_central_notas As Int32
    'Private _id_cd_divergencia As Int32
    'Private _id_tipo_divergencia As Int32

    Public Property id_romaneio_notas() As Int32
        Get
            Return _id_romaneio_notas
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_notas = value
        End Set
    End Property
    Public Property id_romaneio() As Int32
        Get
            Return _id_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_romaneio = value
        End Set
    End Property
    Public Property id_romaneio_tipo_nota() As Integer
        Get
            Return _id_romaneio_tipo_nota
        End Get
        Set(ByVal value As Integer)
            _id_romaneio_tipo_nota = value
        End Set
    End Property
    Public Property id_cooperativa() As Integer
        Get
            Return _id_cooperativa
        End Get
        Set(ByVal value As Integer)
            _id_cooperativa = value
        End Set
    End Property
    Public Property id_transportador() As Integer
        Get
            Return _id_transportador
        End Get
        Set(ByVal value As Integer)
            _id_transportador = value
        End Set
    End Property
    Public Property ds_chave() As String
        Get
            Return _ds_chave
        End Get
        Set(ByVal value As String)
            _ds_chave = value
        End Set
    End Property
    Public Property nr_po_cooperativa() As String
        Get
            Return _nr_po_cooperativa
        End Get
        Set(ByVal value As String)
            _nr_po_cooperativa = value
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
    Public Property nr_serie() As String
        Get
            Return _nr_serie
        End Get
        Set(ByVal value As String)
            _nr_serie = value
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
    Public Property cd_cnpj_emitente() As String
        Get
            Return _cd_cnpj_emitente
        End Get
        Set(ByVal value As String)
            _cd_cnpj_emitente = value
        End Set
    End Property
    Public Property cd_cnpj_transportador() As String
        Get
            Return _cd_cnpj_transportador
        End Get
        Set(ByVal value As String)
            _cd_cnpj_transportador = value
        End Set
    End Property
    Public Property nr_modelo_frete() As Integer
        Get
            Return _nr_modelo_frete
        End Get
        Set(ByVal value As Integer)
            _nr_modelo_frete = value
        End Set
    End Property
    Public Property ds_chave_nfe_leite() As String
        Get
            Return _ds_chave_nfe_leite
        End Get
        Set(ByVal value As String)
            _ds_chave_nfe_leite = value
        End Set
    End Property
    'Public Property id_cd_divergencia() As Integer
    '    Get
    '        Return _id_cd_divergencia
    '    End Get
    '    Set(ByVal value As Integer)
    '        _id_cd_divergencia = value
    '    End Set
    'End Property
    'Public Property id_tipo_divergencia() As Integer
    '    Get
    '        Return _id_tipo_divergencia
    '    End Get
    '    Set(ByVal value As Integer)
    '        _id_tipo_divergencia = value
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
    'Public Property id_situacao_central_notas() As Int32
    '    Get
    '        Return _id_situacao_central_notas
    '    End Get
    '    Set(ByVal value As Int32)
    '        _id_situacao_central_notas = value
    '    End Set
    'End Property

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

    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
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
    Public Property nr_valor_icms() As Decimal
        Get
            Return _nr_valor_icms
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_icms = value
        End Set
    End Property
    Public Property cd_cst() As String
        Get
            Return _cd_cst
        End Get
        Set(ByVal value As String)
            _cd_cst = value
        End Set
    End Property
    Public Property cd_cfop() As String
        Get
            Return _cd_cfop
        End Get
        Set(ByVal value As String)
            _cd_cfop = value
        End Set
    End Property
    Public Property dt_emissao_completa() As String
        Get
            Return _dt_emissao_completa
        End Get
        Set(ByVal value As String)
            _dt_emissao_completa = value
        End Set
    End Property
    Public Property nr_base_icms() As Decimal
        Get
            Return _nr_base_icms
        End Get
        Set(ByVal value As Decimal)
            _nr_base_icms = value
        End Set
    End Property
    Public Property cd_uf_origem() As String
        Get
            Return _cd_uf_origem
        End Get
        Set(ByVal value As String)
            _cd_uf_origem = value
        End Set
    End Property
    Public Property cd_uf_destino() As String
        Get
            Return _cd_uf_destino
        End Get
        Set(ByVal value As String)
            _cd_uf_destino = value
        End Set
    End Property
    Public Property cd_ibge_origem() As String
        Get
            Return _cd_ibge_origem
        End Get
        Set(ByVal value As String)
            _cd_ibge_origem = value
        End Set
    End Property
    Public Property cd_ibge_destino() As String
        Get
            Return _cd_ibge_destino
        End Get
        Set(ByVal value As String)
            _cd_ibge_destino = value
        End Set
    End Property
    Public Property ds_protocolo() As String
        Get
            Return _ds_protocolo
        End Get
        Set(ByVal value As String)
            _ds_protocolo = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)
        Me.id_romaneio_notas = id
        loadRomaneioNotas()
    End Sub

    Public Sub New()

    End Sub

    'Public Sub atulizarDivergencias()

    '    Dim transacao As New DataAccess
    '    'Inicia Transa��o
    '    transacao.StartTransaction(IsolationLevel.RepeatableRead)
    '    Try
    '        'Pega os parametros para inclus�o romaneio
    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '        'atualizar as divergencias
    '        transacao.Execute("ms_updateCentralNotasImportacaoDivergencias", parameters, ExecuteType.Update)

    '        'Comita
    '        transacao.Commit()
    '        transacao.Dispose()
    '    Catch err As Exception
    '        transacao.RollBack()
    '        transacao.Dispose()
    '        Throw New Exception(err.Message)
    '    End Try
    'End Sub
    'Public Sub reavaliarDivergencias()

    '    Dim transacao As New DataAccess
    '    'Inicia Transa��o
    '    transacao.StartTransaction(IsolationLevel.RepeatableRead)
    '    Try
    '        'Pega os parametros para inclus�o romaneio
    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '        'atualizar as divergencias
    '        transacao.Execute("ms_updateCentralNotasImportacaoDivergenciasReavaliar", parameters, ExecuteType.Update)

    '        'Comita
    '        transacao.Commit()
    '        transacao.Dispose()
    '    Catch err As Exception
    '        transacao.RollBack()
    '        transacao.Dispose()
    '        Throw New Exception(err.Message)
    '    End Try
    'End Sub
    'Public Sub atulizarPedidosNotasValidas()

    '    Dim transacao As New DataAccess
    '    'Inicia Transa��o
    '    transacao.StartTransaction(IsolationLevel.RepeatableRead)
    '    Try
    '        'Pega os parametros para inclus�o 
    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '        'inclusao de desconto ao produtor e pagamento ao fornecedor das notas com situacao 6 (notas validas)
    '        transacao.Execute("ms_insertCentralPedidoPagtosbyNotas", parameters, ExecuteType.Insert)

    '        'atualizar as notas validas com situacao de incluidas e atualizar a situa�ao dos pedidos para finalizado
    '        transacao.Execute("ms_updateCentralPedidoFinalizacaobyNotas", parameters, ExecuteType.Update)

    '        'Comita
    '        transacao.Commit()
    '        transacao.Dispose()
    '    Catch err As Exception
    '        transacao.RollBack()
    '        transacao.Dispose()
    '        Throw New Exception(err.Message)
    '    End Try
    'End Sub
    'Public Sub atulizarPedidosNotasManual()

    '    Dim transacao As New DataAccess
    '    'Inicia Transa��o
    '    transacao.StartTransaction(IsolationLevel.RepeatableRead)
    '    Try
    '        'Pega os parametros para inclus�o 
    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '        'inclusao de desconto ao produtor e pagamento ao fornecedor 
    '        transacao.Execute("ms_insertCentralPedidoPagtosbyNotasManual", parameters, ExecuteType.Insert)

    '        'atualizar as notas com situacao de incluidas e atualizar a situa�ao dos pedidos para finalizado
    '        transacao.Execute("ms_updateCentralPedidoFinalizacaobyNotasManual", parameters, ExecuteType.Update)

    '        'Comita
    '        transacao.Commit()
    '        transacao.Dispose()
    '    Catch err As Exception
    '        transacao.RollBack()
    '        transacao.Dispose()
    '        Throw New Exception(err.Message)
    '    End Try
    'End Sub

    Public Function getRomaneioNotas() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getRomaneioNotas", parameters, "ms_romaneio_notas")
            Return dataSet

        End Using

    End Function
    'Public Function getCentralNotasImportacaoByTipoDivergencia() As DataSet

    '    Using data As New DataAccess
    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '        Dim dataSet As New DataSet
    '        data.Fill(dataSet, "ms_getCentralNotasImportacaoByTipoDivergencia", parameters, "ms_central_notas_importacao")
    '        Return dataSet

    '    End Using

    'End Function
    'Public Function getCentralNotasImportacaoDivergencia() As DataSet

    '    Using data As New DataAccess
    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '        Dim dataSet As New DataSet
    '        data.Fill(dataSet, "ms_getCentralNotasImportacaoDivergencia", parameters, "ms_central_notas_importacao_divergencia")
    '        Return dataSet

    '    End Using

    'End Function

    Private Sub loadRomaneioNotas()

        Dim dataSet As DataSet = getRomaneioNotas()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub



    Public Function insertRomaneioNotas() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioNotas", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub updateRomaneioNotasEAnexos()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioNotasEAnexos", parameters, ExecuteType.Update)

        End Using
    End Sub
    Public Sub updateRomaneioNotasSelecao()
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioNotasSelecao", parameters, ExecuteType.Update)

        End Using
    End Sub
    'Public Sub deleteCentralNotasImportacao()

    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        data.Execute("ms_deleteCentralNotasImportacao", parameters, ExecuteType.Delete)

    '    End Using

    'End Sub
End Class
