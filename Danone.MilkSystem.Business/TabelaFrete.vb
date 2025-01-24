Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class TabelaFrete

    Private _id_estabelecimento As Int32
    Private _id_central_tabela_frete As Int32
    Private _id_fornecedor As Int32
    Private _nm_fornecedor As String
    Private _cd_fornecedor As String
    Private _cd_item As String ' Modificado 06/11/2009 - Denise. 
    Private _id_item As Int32
    Private _nm_item As String
    Private _cd_unidade_medida As String
    Private _dt_cotacao As String
    Private _id_cidade_origem As Int32
    Private _id_cidade_destino As Int32
    Private _id_estado_origem As Int32
    Private _id_estado_destino As Int32
    Private _nr_valor_truck_graneleiro As Decimal
    Private _nr_valor_truck_rosca As Decimal
    Private _nr_valor_truck_4eixo As Decimal
    Private _nr_valor_carreta_graneleiro As Decimal
    Private _nr_valor_carreta_rosca As Decimal
    Private _nr_valor_bitrem As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _nm_modificador As String
    Private _id_cidade_propriedade As Int32 'fran chamado 556
    Private _id_estado_propriedade As Int32 'fran chamado 556
    Private _tfv_id_veiculocentral As ArrayList
    Private _tfv_nr_valor_frete As ArrayList
    Private _tabela_frete_veiculos As TabelaFreteVeiculos


    Public Property cd_unidade_medida() As String
        Get
            Return _cd_unidade_medida
        End Get
        Set(ByVal value As String)
            _cd_unidade_medida = value
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

    Public Property id_central_tabela_frete() As Int32
        Get
            Return _id_central_tabela_frete
        End Get
        Set(ByVal value As Int32)
            _id_central_tabela_frete = value
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
    Public Property nm_fornecedor() As String
        Get
            Return _nm_fornecedor
        End Get
        Set(ByVal value As String)
            _nm_fornecedor = value
        End Set
    End Property
    Public Property cd_fornecedor() As String
        Get
            Return _cd_fornecedor
        End Get
        Set(ByVal value As String)
            _cd_fornecedor = value
        End Set
    End Property
    'Modificado 06/11/2009 - Denise i. 
    Public Property cd_item() As String
        Get
            Return _cd_item
        End Get
        Set(ByVal value As String)
            _cd_item = value
        End Set
    End Property
    'Modificado 06/11/2009 - Denise f.

    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
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

    Public Property dt_cotacao() As String
        Get
            Return _dt_cotacao
        End Get
        Set(ByVal value As String)
            _dt_cotacao = value
        End Set
    End Property
    Public Property nr_valor_truck_graneleiro() As Decimal
        Get
            Return _nr_valor_truck_graneleiro
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_truck_graneleiro = value
        End Set
    End Property

    Public Property nr_valor_truck_rosca() As Decimal
        Get
            Return _nr_valor_truck_rosca
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_truck_rosca = value
        End Set
    End Property

    Public Property nr_valor_truck_4eixo() As Decimal
        Get
            Return _nr_valor_truck_4eixo
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_truck_4eixo = value
        End Set
    End Property

    Public Property nr_valor_carreta_graneleiro() As Decimal
        Get
            Return _nr_valor_carreta_graneleiro
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_carreta_graneleiro = value
        End Set
    End Property

    Public Property nr_valor_carreta_rosca() As Decimal
        Get
            Return _nr_valor_carreta_rosca
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_carreta_rosca = value
        End Set
    End Property

    Public Property nr_valor_bitrem() As Decimal
        Get
            Return _nr_valor_bitrem
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_bitrem = value
        End Set
    End Property


 
    Public Property id_cidade_origem() As Int32
        Get
            Return _id_cidade_origem
        End Get
        Set(ByVal value As Int32)
            _id_cidade_origem = value
        End Set
    End Property
    Public Property id_estado_origem() As Int32
        Get
            Return _id_estado_origem
        End Get
        Set(ByVal value As Int32)
            _id_estado_origem = value
        End Set
    End Property
    Public Property id_cidade_destino() As Int32
        Get
            Return _id_cidade_destino
        End Get
        Set(ByVal value As Int32)
            _id_cidade_destino = value
        End Set
    End Property
    Public Property id_estado_destino() As Int32
        Get
            Return _id_estado_destino
        End Get
        Set(ByVal value As Int32)
            _id_estado_destino = value
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
    Public Property nm_modificador() As String
        Get
            Return _nm_modificador
        End Get
        Set(ByVal value As String)
            _nm_modificador = value
        End Set
    End Property
    Public Property id_cidade_propriedade() As Int32
        Get
            Return _id_cidade_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_cidade_propriedade = value
        End Set
    End Property
    Public Property id_estado_propriedade() As Int32
        Get
            Return _id_estado_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_estado_propriedade = value
        End Set
    End Property
    Public Property tabela_frete_veiculos() As TabelaFreteVeiculos
        Get
            Return Me._tabela_frete_veiculos
        End Get
        Set(ByVal value As TabelaFreteVeiculos)
            Me._tabela_frete_veiculos = value
        End Set
    End Property

    Public Property tfv_id_veiculocentral() As ArrayList
        Get
            Return Me._tfv_id_veiculocentral
        End Get
        Set(ByVal value As ArrayList)
            Me._tfv_id_veiculocentral = value
        End Set
    End Property

    Public Property tfv_nr_valor_frete() As ArrayList
        Get
            Return Me._tfv_nr_valor_frete
        End Get
        Set(ByVal value As ArrayList)
            Me._tfv_nr_valor_frete = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me._tfv_id_veiculocentral = New ArrayList()
        Me._tfv_nr_valor_frete = New ArrayList()
        Me._id_central_tabela_frete = id
        loadTabelaPrecos()

    End Sub

    Public Sub New()
        Me._tfv_id_veiculocentral = New ArrayList()
        Me._tfv_nr_valor_frete = New ArrayList()

    End Sub

    Public Function getCentralTabelaFreteByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralTabelaFrete", parameters, "ms_central_tabela_frete")
            Return dataSet

        End Using

    End Function
    'fran 08/11/2009 i
    Public Function getCentralTabelaFreteMax() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralTabelaFreteMax", parameters, "ms_central_tabela_frete")
            Return dataSet

        End Using

    End Function
    Public Function getCentralTabelaFreteVeiculos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralTabelaFreteVeiculos", parameters, "ms_central_tabela_frete_veiculos")
            Return dataSet

        End Using

    End Function
    Private Sub loadTabelaPrecos()

        Dim dataSet As DataSet = getCentralTabelaFreteByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertCentralTabelaFrete() As Int32

        Dim transacao As New DataAccess
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Me.id_central_tabela_frete = CType(transacao.ExecuteScalar("ms_insertCentralTabelaFrete", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)
            Me.tabela_frete_veiculos = New TabelaFreteVeiculos
            Me.tabela_frete_veiculos.id_central_tabela_frete = Me.id_central_tabela_frete
            Me.tabela_frete_veiculos.id_modificador = Me.id_modificador

            For i As Integer = 0 To Me.tfv_id_veiculocentral.Count - 1
                Me.tabela_frete_veiculos.id_veiculocentralcompras = Convert.ToInt32(Me.tfv_id_veiculocentral(i))
                Me.tabela_frete_veiculos.nr_valor_frete = Me.tfv_nr_valor_frete(i)
                'Pega os parametros 
                Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me.tabela_frete_veiculos)
                transacao.Execute("ms_insertCentralTabelaFreteVeiculos", param_comp, ExecuteType.Insert)
            Next

            transacao.Commit()
            Return Me.id_central_tabela_frete

        Catch err As System.Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try

    End Function
    Public Sub updateCentralTabelaFrete()
        Dim transacao As New DataAccess
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try

            transacao.Execute("ms_updateCentralTabelaFrete", ParametersEngine.getParametersFromObject(Me), ExecuteType.Update)

            ParametersEngine.getParametersFromObject(Me)

            Me.tabela_frete_veiculos = New TabelaFreteVeiculos
            Me.tabela_frete_veiculos.id_central_tabela_frete = Me.id_central_tabela_frete
            Me.tabela_frete_veiculos.id_modificador = Me.id_modificador

            For i As Integer = 0 To Me.tfv_id_veiculocentral.Count - 1
                Me.tabela_frete_veiculos.id_veiculocentralcompras = Convert.ToInt32(Me.tfv_id_veiculocentral(i))
                Me.tabela_frete_veiculos.nr_valor_frete = Me.tfv_nr_valor_frete(i)
                'Pega os parametros 
                Dim param_comp As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me.tabela_frete_veiculos)
                transacao.Execute("ms_updateCentralTabelaFreteVeiculos", param_comp, ExecuteType.Update)
            Next

            transacao.Commit()

        Catch err As System.Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try

    End Sub
    Public Sub deleteCentralTabelaFrete()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralTabelaFrete", parameters, ExecuteType.Delete)

        End Using


    End Sub
End Class
