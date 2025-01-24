Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class TabelaPrecos

    Private _id_estabelecimento As Int32
    Private _id_central_tabela_precos As Int32
    Private _id_fornecedor As Int32
    Private _nm_fornecedor As String
    Private _cd_fornecedor As String
    Private _cd_item As String  ' 06/11/2009
    Private _id_item As Int32
    Private _nm_item As String
    Private _cd_unidade_medida As String
    Private _dt_cotacao As String
    Private _nr_volume_ate As Decimal
    Private _nr_valor As Decimal
    Private _nr_valor_sacaria As Decimal
    Private _nr_valor_padrao As Decimal
    Private _nr_valor_icms As Decimal
    Private _id_cidade_origem As Int32
    Private _id_cidade_destino As Int32
    Private _id_estado_origem As Int32
    Private _id_estado_destino As Int32
    Private _nr_percentual_icms As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _nm_modificador As String
    Private _nr_parcelas As Int32   ' Adri 25/01/2010 - Chamado 556
    Private _id_cidade_propriedade As Int32 'fran chamado 556
    Private _id_estado_propriedade As Int32 'fran chamado 556



    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property

    Public Property id_central_tabela_precos() As Int32
        Get
            Return _id_central_tabela_precos
        End Get
        Set(ByVal value As Int32)
            _id_central_tabela_precos = value
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
    Public Property cd_item() As String
        Get
            Return _cd_item
        End Get
        Set(ByVal value As String)
            _cd_item = value
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
    Public Property nm_item() As String
        Get
            Return _nm_item
        End Get
        Set(ByVal value As String)
            _nm_item = value
        End Set
    End Property
    Public Property cd_unidade_medida() As String
        Get
            Return _cd_unidade_medida
        End Get
        Set(ByVal value As String)
            _cd_unidade_medida = value
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
    Public Property nr_volume_ate() As Decimal
        Get
            Return _nr_volume_ate
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_ate = value
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
    Public Property nr_valor_sacaria() As Decimal
        Get
            Return _nr_valor_sacaria
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_sacaria = value
        End Set
    End Property
    Public Property nr_valor_padrao() As Decimal
        Get
            Return _nr_valor_padrao
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_padrao = value
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
    Public Property nr_percentual_icms() As Decimal
        Get
            Return _nr_percentual_icms
        End Get
        Set(ByVal value As Decimal)
            _nr_percentual_icms = value
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
    Public Property nr_parcelas() As Int32
        Get
            Return _nr_parcelas
        End Get
        Set(ByVal value As Int32)
            _nr_parcelas = value
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

    Public Sub New(ByVal id As Int32)

        Me._id_central_tabela_precos = id
        loadTabelaPrecos()

    End Sub



    Public Sub New()

    End Sub


    Public Function getCentralTabelaPrecosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralTabelaPrecos", parameters, "ms_central_tabela_precos")
            Return dataSet

        End Using

    End Function

    Private Sub loadTabelaPrecos()

        Dim dataSet As DataSet = getCentralTabelaPrecosByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertCentralTabelaPrecos() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralTabelaPrecos", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateCentralTabelaPrecos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralTabelaPrecos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCentralTabelaPrecosSituacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralTabelaPrecosSituacao", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deleteCentralTabelaPrecos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralTabelaPrecos", parameters, ExecuteType.Delete)

        End Using


    End Sub
    'fran 08/11/2009
    Public Function getCentralTabelaPrecosMax() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralTabelaPrecosMax", parameters, "ms_central_tabela_precos")
            Return dataSet

        End Using

    End Function
    Public Function getCentralTabelaPrecosEmUso() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralTabelaPrecosEmUso", parameters, "ms_central_pedido")
            Return dataSet

        End Using

    End Function
End Class
