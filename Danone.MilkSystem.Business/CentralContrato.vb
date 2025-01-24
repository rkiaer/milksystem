Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class CentralContrato

    Private _id_central_contrato As Int32
    Private _id_estabelecimento As Int32
    Private _dt_inicio_contrato As String
    Private _dt_fim_contrato As String
    Private _id_fornecedor As Int32
    Private _id_item As Int32
    Private _nr_quantidade_total As Decimal
    Private _nr_valor_unitario As Decimal
    Private _nr_sacaria As Decimal
    Private _st_tipo_central_contrato As String 'se é P pool ou C contrato
    Private _id_situacao As Int32
    Private _id_situacao_central_contrato As Int32
    Private _ds_descricao_contrato As String

    Private _id_modificador As Int32
    Private _dt_modificacao As String
    'Private _id_central_pedido_matriz As Int32
    Private _propriedadescontrato As DataTable
    Private _nm_fornecedor As String
    Private _nm_item As String


    Public Property id_central_contrato() As Int32
        Get
            Return _id_central_contrato
        End Get
        Set(ByVal value As Int32)
            _id_central_contrato = value
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
    Public Property id_fornecedor() As Int32
        Get
            Return _id_fornecedor
        End Get
        Set(ByVal value As Int32)
            _id_fornecedor = value
        End Set
    End Property
    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
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
    Public Property nr_valor_unitario() As Decimal
        Get
            Return _nr_valor_unitario
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_unitario = value
        End Set
    End Property
    Public Property nr_sacaria() As Decimal
        Get
            Return _nr_sacaria
        End Get
        Set(ByVal value As Decimal)
            _nr_sacaria = value
        End Set
    End Property
    Public Property st_tipo_central_contrato() As String
        Get
            Return _st_tipo_central_contrato
        End Get
        Set(ByVal value As String)
            _st_tipo_central_contrato = value
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
    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
        End Set
    End Property
    Public Property propriedadescontrato() As DataTable
        Get
            Return _propriedadescontrato
        End Get
        Set(ByVal value As DataTable)
            _propriedadescontrato = value
        End Set
    End Property
    Public Property ds_descricao_contrato() As String
        Get
            Return _ds_descricao_contrato
        End Get
        Set(ByVal value As String)
            _ds_descricao_contrato = value
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
    Public Property id_situacao_central_contrato() As Int32
        Get
            Return _id_situacao_central_contrato
        End Get
        Set(ByVal value As Int32)
            _id_situacao_central_contrato = value
        End Set
    End Property
    Public Property nm_fornecedor() As String
        Get
            Return _nm_fornecedor
        End Get
        Set(ByVal value As String)
            _nm_fornecedor = value
        End Set
    End Property
    Public Property nm_item() As String
        Get
            Return _nm_item
        End Get
        Set(ByVal value As String)
            _nm_item = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_central_contrato = id
        loadCentralContrato()

    End Sub

    Public Sub New()

    End Sub
    Public Function getCentralContratoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralContrato", parameters, "ms_central_contrato")
            Return dataSet

        End Using

    End Function
    Private Sub loadCentralContrato()

        Dim dataSet As DataSet = getCentralContratoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertCentralContrato() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralContrato", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertCentralContratoPropriedade() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralContratoPropriedade", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub updateCentralContrato()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralContrato", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralContratoPropriedade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralContratoPropriedade", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub deleteCentralContrato()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralcontrato", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub deleteCentralContratoPropriedade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralcontratoPropriedade", parameters, ExecuteType.Delete)

        End Using


    End Sub

  
    Public Function incluirCentralContrato() As Boolean

        Dim transacao As New DataAccess
        'Dim transacao2 As New DataAccess

        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        incluirCentralContrato = False
        'Try
        '    'Pega os parametros para inclusão 
        '    Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
        '    Dim row As DataRow

        '    'Insere entral contrato
        '    Me.id_central_contrato = CType(transacao.ExecuteScalar("ms_insertCentralContrato", parameters, ExecuteType.Insert), Int32)

        '    parameters = ParametersEngine.getParametersFromObject(Me)

        '    If Me.ds_tipofrete = "D" Then 'se for fob-d inclui transportador
        '        'Insere pedido transportador
        '        PedidoItem.id_central_pedido_transportador = CType(transacao.ExecuteScalar("ms_insertCentralPedidoTransportador", parameters, ExecuteType.Insert), Int32)
        '    Else
        '        PedidoItem.id_central_pedido_transportador = 0
        '    End If
        '    'para cada propriedade insere propriedade contrato
        '    For Each row In propriedadescontrato.Rows




        '    Next

        '    With Me.propriedadescontrato.Rows(0)
        '        PedidoItem.id_central_pedido = Me.id_central_pedido_matriz
        '        PedidoItem.id_item = .Item(0)
        '        PedidoItem.nr_parcelas = Me.nr_qtde_parcelas
        '        PedidoItem.ds_tipo_medida = .Item(2)
        '        PedidoItem.nr_quantidade = .Item(3)
        '        PedidoItem.nr_valor_unitario = .Item(4)
        '        PedidoItem.nr_sacaria = .Item(5)
        '        PedidoItem.nr_frete = .Item(9)
        '        PedidoItem.nr_valor_total = .Item(7)
        '        PedidoItem.st_parcelamento = Me.st_tipo_parcelamento
        '        PedidoItem.id_modificador = Me.id_modificador
        '        PedidoItem.id_central_tabela_preco = .Item(6)
        '        PedidoItem.id_central_tabela_frete_veiculos = .Item(11)
        '        PedidoItem.ds_tipo_frete = Me.ds_tipofrete
        '        PedidoItem.id_situacao_pedido = Me.id_situacao_pedido
        '    End With

        '    'Pega os parametros para inclusão pedido
        '    Dim parametersitem As List(Of Parameters) = ParametersEngine.getParametersFromObject(PedidoItem)

        '    'finaliza inclusao de itens do fornecedor e transportador, coloca para aprovação de situacao pedido = 5, e se for pedido aprovado (6) 
        '    'envia email fornecedor de insumos
        '    transacao.Execute("ms_insertCentralPedidoItens", parametersitem, ExecuteType.Insert)


        '    'Comita
        '    transacao.Commit()
        '    transacao.Dispose()

        '    gerarPedidoPropriedade = True

        'Catch err As Exception
        '    transacao.RollBack()
        '    transacao.Dispose()
        '    gerarPedidoPropriedade = False
        '    Throw New Exception(err.Message)
        'End Try
    End Function
    Public Function getCentralContratoTotalQtde() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCentralContratoTotalQtde", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
End Class
