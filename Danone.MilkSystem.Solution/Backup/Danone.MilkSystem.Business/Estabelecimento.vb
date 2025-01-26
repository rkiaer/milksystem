Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class Estabelecimento

    Private _id_estabelecimento As Int32
    Private _cd_estabelecimento As String
    Private _nm_estabelecimento As String
    Private _cd_cnpj As String
    Private _st_categoria As String
    Private _cd_inscricao_estadual As String
    Private _cd_inscricao_municipal As String
    Private _ds_endereco As String
    Private _nr_endereco As Int32
    Private _ds_complemento As String
    Private _ds_bairro As String
    Private _id_cidade As Int32
    Private _nm_cidade As String
    Private _id_estado As Int32
    Private _cd_uf As String
    Private _cd_cep As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nr_mapa_leite As Int32
    Private _nr_nota_fiscal As Int32
    Private _nr_serie As String
    Private _ds_aidf As String
    Private _ds_aidf_nf_produtor As String
    Private _dt_validade_formulario As String 'Fran 11/03/2009 rls 17
    Private _cd_codigo_sap As String  ' adri 08/03/2012 projeto Themis
    Private _nr_analiseesalq_percvariacaoMG As Decimal  'adri 26/07/2016 - chamado 2441 - Conciliacao 
    Private _nr_km_minima As Decimal  'fran 07/2017 
    Private _st_recepcao_leite As String  'fran 03/20121



    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property cd_estabelecimento() As String
        Get
            Return _cd_estabelecimento
        End Get
        Set(ByVal value As String)
            _cd_estabelecimento = value
        End Set
    End Property
    Public Property st_categoria() As String
        Get
            Return _st_categoria
        End Get
        Set(ByVal value As String)
            _st_categoria = value
        End Set
    End Property
    Public Property st_recepcao_leite() As String
        Get
            Return _st_recepcao_leite
        End Get
        Set(ByVal value As String)
            _st_recepcao_leite = value
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
    Public Property cd_inscricao_estadual() As String
        Get
            Return _cd_inscricao_estadual
        End Get
        Set(ByVal value As String)
            _cd_inscricao_estadual = value
        End Set
    End Property
    Public Property cd_inscricao_municipal() As String
        Get
            Return _cd_inscricao_municipal
        End Get
        Set(ByVal value As String)
            _cd_inscricao_municipal = value
        End Set
    End Property
    Public Property ds_endereco() As String
        Get
            Return _ds_endereco
        End Get
        Set(ByVal value As String)
            _ds_endereco = value
        End Set
    End Property

    Public Property nr_endereco() As Int32
        Get
            Return _nr_endereco
        End Get
        Set(ByVal value As Int32)
            _nr_endereco = value
        End Set
    End Property

    Public Property ds_complemento() As String
        Get
            Return _ds_complemento
        End Get
        Set(ByVal value As String)
            _ds_complemento = value
        End Set
    End Property
    Public Property ds_bairro() As String
        Get
            Return _ds_bairro
        End Get
        Set(ByVal value As String)
            _ds_bairro = value
        End Set
    End Property
    Public Property id_cidade() As Int32
        Get
            Return _id_cidade
        End Get
        Set(ByVal value As Int32)
            _id_cidade = value
        End Set
    End Property
    Public Property id_estado() As Int32
        Get
            Return _id_estado
        End Get
        Set(ByVal value As Int32)
            _id_estado = value
        End Set
    End Property

    Public Property cd_cep() As String
        Get
            Return _cd_cep
        End Get
        Set(ByVal value As String)
            _cd_cep = value
        End Set
    End Property
    Public Property cd_uf() As String
        Get
            Return _cd_uf
        End Get
        Set(ByVal value As String)
            _cd_uf = value
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

    Public Property nm_estabelecimento() As String
        Get
            Return _nm_estabelecimento
        End Get
        Set(ByVal value As String)
            _nm_estabelecimento = value
        End Set
    End Property

    Public Property nm_cidade() As String
        Get
            Return _nm_cidade
        End Get
        Set(ByVal value As String)
            _nm_cidade = value
        End Set
    End Property
    Public Property nr_mapa_leite() As Int32
        Get
            Return _nr_mapa_leite
        End Get
        Set(ByVal value As Int32)
            _nr_mapa_leite = value
        End Set
    End Property
    Public Property nr_nota_fiscal() As Int32
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As Int32)
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

    Public Property ds_aidf() As String
        Get
            Return _ds_aidf
        End Get
        Set(ByVal value As String)
            _ds_aidf = value
        End Set
    End Property
    'Fran 30/11/2008 i 
    Public Property ds_aidf_nf_produtor() As String
        Get
            Return _ds_aidf_nf_produtor
        End Get
        Set(ByVal value As String)
            _ds_aidf_nf_produtor = value
        End Set
    End Property
    'Fran 11/03/2009 i rls17
    Public Property dt_validade_formulario() As String
        Get
            Return _dt_validade_formulario
        End Get
        Set(ByVal value As String)
            _dt_validade_formulario = value
        End Set
    End Property
    ' 02/02/2012 - Projeto Themis - i
    Public Property cd_codigo_sap() As String
        Get
            Return _cd_codigo_SAP
        End Get
        Set(ByVal value As String)
            _cd_codigo_SAP = value
        End Set
    End Property
    ' 02/02/2012 - Projeto Themis - i

    Public Property nr_analiseesalq_percvariacaoMG() As Decimal
        Get
            Return _nr_analiseesalq_percvariacaoMG
        End Get
        Set(ByVal value As Decimal)
            _nr_analiseesalq_percvariacaoMG = value
        End Set
    End Property
    Public Property nr_km_minima() As Decimal
        Get
            Return _nr_km_minima
        End Get
        Set(ByVal value As Decimal)
            _nr_km_minima = value
        End Set
    End Property
    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Int32)

        Me._id_estabelecimento = id
        loadEstabelecimento()

    End Sub

    Public Function getEstabelecimentosByFilters()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getEstabelecimentos", parameters, "ms_estabelecimento")

            Return dataSet

        End Using

    End Function

    Private Sub loadEstabelecimento()

        Dim dataSet As DataSet = getEstabelecimentosByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertEstabelecimento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertEstabelecimentos", parameters, ExecuteType.Insert), Int32)

        End Using

    End Function

    Public Sub updateEstabelecimento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateEstabelecimentos", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteEstabelecimento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteEstabelecimentos", parameters, ExecuteType.Delete)

        End Using

    End Sub
    Public Function getEstabelecimentoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getEstabelecimentos", parameters, "ms_estabelecimento")
            Return dataSet

        End Using

    End Function
    Public Function getEstabelecimentoByCodigo() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEstabelecimentosCodigo", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Function getEstabelecimentoNumeroMapa() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getEstabelecimentoNumeroMapa", parameters, ExecuteType.Select), Int32)

        End Using
    End Function

    Public Function getEstabelecimentoPessoaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getEstabelecimentosPessoa", parameters, "ms_estabelecimento")
            Return dataSet

        End Using

    End Function



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
