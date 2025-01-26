Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math

<Serializable()> Public Class CentralContratoPropriedade

    Private _id_central_contrato_propriedade As Int32
    Private _id_central_contrato As Int32
    Private _st_pedido_indireto As String

    Private _id_propriedade As Int32
    Private _id_propriedade_matriz As Int32
    Private _id_produtor As Int32
    Private _dt_referencia As String
    Private _nr_qtde As Decimal
    Private _st_tipo_parcelamento As String
    Private _nr_parcelas As Int32
    Private _ds_tipo_frete As String
    Private _id_transportador As Int32
    Private _st_tipo_pedido As String 'se é F fornecedor ou T transportador
    Private _id_central_pedido As Int32
    Private _id_central_pedido_frete As Int32
    Private _id_situacao As Int32
    Private _st_tipo_medida As String
    Private _id_central_tabela_frete_veiculos As Int32
    Private _nr_valor_frete As Decimal
    Private _nr_1a_qtde As Decimal
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _periodossementrega As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_central_pedido_matriz As Int32
    Private _propriedadescontrato As DataTable
    Private _nr_valor_01 As Decimal
    Private _nr_valor_02 As Decimal
    Private _nr_valor_03 As Decimal
    Private _nr_valor_04 As Decimal
    Private _nr_valor_05 As Decimal
    Private _nr_valor_06 As Decimal
    Private _nr_valor_07 As Decimal
    Private _nr_valor_08 As Decimal
    Private _nr_valor_09 As Decimal
    Private _nr_valor_10 As Decimal
    Private _nr_valor_11 As Decimal
    Private _nr_valor_12 As Decimal

    Public Property id_central_contrato() As Int32
        Get
            Return _id_central_contrato
        End Get
        Set(ByVal value As Int32)
            _id_central_contrato = value
        End Set
    End Property
    Public Property id_central_contrato_propriedade() As Int32
        Get
            Return _id_central_contrato_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_central_contrato_propriedade = value
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
    Public Property id_propriedade_matriz() As Int32
        Get
            Return _id_propriedade_matriz
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_matriz = value
        End Set
    End Property
    Public Property id_produtor() As Int32
        Get
            Return _id_produtor
        End Get
        Set(ByVal value As Int32)
            _id_produtor = value
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
    Public Property nr_qtde() As Decimal
        Get
            Return _nr_qtde
        End Get
        Set(ByVal value As Decimal)
            _nr_qtde = value
        End Set
    End Property
    Public Property st_tipo_parcelamento() As String
        Get
            Return _st_tipo_parcelamento
        End Get
        Set(ByVal value As String)
            _st_tipo_parcelamento = value
        End Set
    End Property
    Public Property nr_parcelas() As Int32
        Get
            Return _nr_parcelas
        End Get
        Set(ByVal value As Int32)
            _nr_parcelas = value
        End Set
    End Property
    Public Property ds_tipo_frete() As String
        Get
            Return _ds_tipo_frete
        End Get
        Set(ByVal value As String)
            _ds_tipo_frete = value
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
    Public Property st_tipo_pedido() As String
        Get
            Return _st_tipo_pedido
        End Get
        Set(ByVal value As String)
            _st_tipo_pedido = value
        End Set
    End Property
    Public Property id_central_pedido_matriz() As Int32
        Get
            Return _id_central_pedido_matriz
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_matriz = value
        End Set
    End Property
    Public Property id_central_pedido() As Int32
        Get
            Return _id_central_pedido
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido = value
        End Set
    End Property
    Public Property id_central_pedido_frete() As Int32
        Get
            Return _id_central_pedido_frete
        End Get
        Set(ByVal value As Int32)
            _id_central_pedido_frete = value
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
    Public Property nr_1a_qtde() As Decimal
        Get
            Return _nr_1a_qtde
        End Get
        Set(ByVal value As Decimal)
            _nr_1a_qtde = value
        End Set
    End Property
    Public Property periodossementrega() As String
        Get
            Return _periodossementrega
        End Get
        Set(ByVal value As String)
            _periodossementrega = value
        End Set
    End Property

    Public Property nr_valor_frete() As Decimal
        Get
            Return _nr_valor_frete
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_frete = value
        End Set
    End Property
    Public Property st_tipo_medida() As String
        Get
            Return _st_tipo_medida
        End Get
        Set(ByVal value As String)
            _st_tipo_medida = value
        End Set
    End Property
    Public Property id_central_tabela_frete_veiculos() As Int32
        Get
            Return _id_central_tabela_frete_veiculos
        End Get
        Set(ByVal value As Int32)
            _id_central_tabela_frete_veiculos = value
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
    Public Property st_pedido_indireto() As String
        Get
            Return _st_pedido_indireto
        End Get
        Set(ByVal value As String)
            _st_pedido_indireto = value
        End Set
    End Property
    Public Property nr_valor_01() As Decimal
        Get
            Return _nr_valor_01
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_01 = value
        End Set
    End Property
    Public Property nr_valor_02() As Decimal
        Get
            Return _nr_valor_02
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_02 = value
        End Set
    End Property

    Public Property nr_valor_03() As Decimal
        Get
            Return _nr_valor_03
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_03 = value
        End Set
    End Property

    Public Property nr_valor_04() As Decimal
        Get
            Return _nr_valor_04
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_04 = value
        End Set
    End Property

    Public Property nr_valor_05() As Decimal
        Get
            Return _nr_valor_05
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_05 = value
        End Set
    End Property

    Public Property nr_valor_06() As Decimal
        Get
            Return _nr_valor_06
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_06 = value
        End Set
    End Property

    Public Property nr_valor_07() As Decimal
        Get
            Return _nr_valor_07
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_07 = value
        End Set
    End Property

    Public Property nr_valor_08() As Decimal
        Get
            Return _nr_valor_08
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_08 = value
        End Set
    End Property

    Public Property nr_valor_09() As Decimal
        Get
            Return _nr_valor_09
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_09 = value
        End Set
    End Property

    Public Property nr_valor_10() As Decimal
        Get
            Return _nr_valor_10
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_10 = value
        End Set
    End Property

    Public Property nr_valor_11() As Decimal
        Get
            Return _nr_valor_11
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_11 = value
        End Set
    End Property

    Public Property nr_valor_12() As Decimal
        Get
            Return _nr_valor_12
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_12 = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_central_contrato_propriedade = id
        loadCentralContratoPropriedade()

    End Sub

    Public Sub New()

    End Sub
    Public Function getCentralContratoPropriedadeByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralContratoPropriedade", parameters, "ms_central_contrato")
            Return dataSet

        End Using

    End Function
    Public Function getCentralContratoPropriedadeQtde() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralContratoPropriedadeQtde", parameters, "ms_central_contrato_propriedade")
            Return dataSet

        End Using

    End Function

    Public Function getCentralContratoPropriedadeProdutores() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralContratoPropriedadeProdutores", parameters, "ms_central_contrato_propriedade")
            Return dataSet

        End Using

    End Function
    Public Function getCentralContratoPropriedadePedidos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralContratoPropriedadePedidos", parameters, "ms_central_contrato_propriedade")
            Return dataSet

        End Using

    End Function
    Public Function getCentralContratoPropriedadePedidosTransportador() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralContratoPropriedadePedidosTransportador", parameters, "ms_central_contrato_propriedade")
            Return dataSet

        End Using

    End Function
    Public Function getCentralContratoAbertoPropriedadePedidos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralContratoAbertoPropriedadePedidos", parameters, "ms_central_contrato_propriedade")
            Return dataSet

        End Using

    End Function
    Public Function getCentralContratoPropriedadeGridInf() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralContratoPropriedadeGridInf", parameters, "ms_central_contrato_propriedade")
            Return dataSet

        End Using

    End Function
    Public Function getCentralContratoPropriedadeGridInfGrupo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralContratoPropriedadeGridInfGrupo", parameters, "ms_central_contrato_propriedade")
            Return dataSet

        End Using

    End Function
    Private Sub loadCentralContratoPropriedade()

        Dim dataSet As DataSet = getCentralContratoPropriedadeByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertCentralContratoPropriedadeGrupo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralContratoPropriedadeGrupo", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Function insertCentralContratoPropriedade() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralContratoPropriedade", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub updateCentralContratoPropriedade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralContratoPropriedade", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralContratoPropriedadeGrupo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralContratoPropriedadeGrupo", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralContratoPropriedadeQtde()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralContratoPropriedadeQtde", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub deleteCentralContratoPropriedade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralContratoPropriedade", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub deleteCentralContratoPropriedadeGrupo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralContratoPropriedadeGrupo", parameters, ExecuteType.Delete)

        End Using


    End Sub

    Public Function incluirCentralContratoPropriedade() As Boolean

        Dim transacao As New DataAccess
        'Dim transacao2 As New DataAccess

        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        incluirCentralContratoPropriedade = False
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

End Class
