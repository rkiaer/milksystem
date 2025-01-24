Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ItemParceiro

    Private _id_central_item_parceiro As Int32
    Private _id_item As Int32
    Private _id_fornecedor As Int32
    Private _nr_lote_minimo As Decimal
    Private _nr_lote_multiplo As Decimal
    Private _id_unidade_medida_fornecedor As Int32
    Private _nr_fator_conversao As Int32
    Private _nr_casas_decimais_conversao As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nm_pessoa As String
    Private _nm_item As String
    Private _id_estabelecimento As Int32
    Private _st_acordo_aquisicao_insumos As String
    Private _cd_cnpj As String


    Public Property id_central_item_parceiro() As Int32
        Get
            Return _id_central_item_parceiro
        End Get
        Set(ByVal value As Int32)
            _id_central_item_parceiro = value
        End Set
    End Property
    Public Property nr_lote_minimo() As Decimal
        Get
            Return _nr_lote_minimo
        End Get
        Set(ByVal value As Decimal)
            _nr_lote_minimo = value
        End Set
    End Property
    Public Property nr_lote_multiplo() As Decimal
        Get
            Return _nr_lote_multiplo
        End Get
        Set(ByVal value As Decimal)
            _nr_lote_multiplo = value
        End Set
    End Property
    Public Property id_unidade_medida_fornecedor() As Int32
        Get
            Return _id_unidade_medida_fornecedor
        End Get
        Set(ByVal value As Int32)
            _id_unidade_medida_fornecedor = value
        End Set
    End Property
    Public Property nr_fator_conversao() As Int32
        Get
            Return _nr_fator_conversao
        End Get
        Set(ByVal value As Int32)
            _nr_fator_conversao = value
        End Set
    End Property
    Public Property nr_casas_decimais_conversao() As Int32
        Get
            Return _nr_casas_decimais_conversao
        End Get
        Set(ByVal value As Int32)
            _nr_casas_decimais_conversao = value
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
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
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
    Public Property nm_pessoa() As String
        Get
            Return _nm_pessoa
        End Get
        Set(ByVal value As String)
            _nm_pessoa = value
        End Set
    End Property
    Public Property cd_cnpj() As String
        Get
            Return _cd_cnpj
        End Get
        Set(ByVal value As String)
            _cd_cnpj = value
        End Set
    End Property
    Public Property st_acordo_aquisicao_insumos() As String
        Get
            Return _st_acordo_aquisicao_insumos
        End Get
        Set(ByVal value As String)
            _st_acordo_aquisicao_insumos = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me._id_central_item_parceiro = id
        loadParceiro()

    End Sub


    Public Sub New()

    End Sub

    Public Function getParceiroByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getcentral_item_parceiro", parameters, "ms_central_item_parceiro")
            Return dataSet

        End Using

    End Function
    Public Function getCentralParceiroComItens() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralParceiroComItens", parameters, "ms_central_item_parceiro")
            Return dataSet

        End Using

    End Function

    Public Function getCentralItemParceiro() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralItemParceiro", parameters, "ms_central_item_parceiro")
            Return dataSet

        End Using

    End Function
    Private Sub loadParceiro()

        Dim dataSet As DataSet = getParceiroByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
   

    Public Sub updateparceiro_itens()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentral_item_parceiro", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function insertparceiro_itens() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentral_item_parceiro", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub deleteparceiro_itens()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentral_item_parceiro", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
