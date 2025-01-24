Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class NaturezaOperacao

    Private _id_natureza_operacao As Int32
    Private _nr_conta_transitoria As String     ' Adri 26/11/2008
    Private _cd_natureza_operacao As String
    Private _nm_natureza_operacao As String
    Private _id_especie_nf As Int32
    Private _nm_especie_nf As String
    Private _ds_tipo_especie As String
    Private _nr_aliquota_cofins As Decimal
    Private _nr_aliquota_icms As Decimal
    Private _nr_aliquota_ipi As Decimal
    Private _nr_aliquota_pis As Decimal
    Private _id_tributacao_cofins As Int32
    Private _id_tributacao_icms As Int32
    Private _id_tributacao_ipi As Int32
    Private _id_tributacao_pis As Int32
    Private _nm_tributacao_cofins As String
    Private _nm_tributacao_icms As String
    Private _nm_tributacao_ipi As String
    Private _nm_tributacao_pis As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_criacao As Int32
    Private _dt_criacao As String

    Public Property id_natureza_operacao() As Int32
        Get
            Return _id_natureza_operacao
        End Get
        Set(ByVal value As Int32)
            _id_natureza_operacao = value
        End Set
    End Property
    Public Property nr_conta_transitoria() As String
        Get
            Return _nr_conta_transitoria
        End Get
        Set(ByVal value As String)
            _nr_conta_transitoria = value
        End Set
    End Property
    Public Property nm_natureza_operacao() As String
        Get
            Return _nm_natureza_operacao
        End Get
        Set(ByVal value As String)
            _nm_natureza_operacao = value
        End Set
    End Property
    Public Property cd_natureza_operacao() As String
        Get
            Return _cd_natureza_operacao
        End Get
        Set(ByVal value As String)
            _cd_natureza_operacao = value
        End Set
    End Property
    Public Property id_especie_nf() As Int32
        Get
            Return _id_especie_nf
        End Get
        Set(ByVal value As Int32)
            _id_especie_nf = value
        End Set
    End Property
    Public Property nm_especie_nf() As String
        Get
            Return _nm_especie_nf
        End Get
        Set(ByVal value As String)
            _nm_especie_nf = value
        End Set
    End Property
    Public Property ds_tipo_especie() As String
        Get
            Return _ds_tipo_especie
        End Get
        Set(ByVal value As String)
            _ds_tipo_especie = value
        End Set
    End Property
    Public Property nr_aliquota_cofins() As Decimal
        Get
            Return _nr_aliquota_cofins
        End Get
        Set(ByVal value As Decimal)
            _nr_aliquota_cofins = value
        End Set
    End Property
    Public Property nr_aliquota_icms() As Decimal
        Get
            Return _nr_aliquota_icms
        End Get
        Set(ByVal value As Decimal)
            _nr_aliquota_icms = value
        End Set
    End Property
    Public Property nr_aliquota_ipi() As Decimal
        Get
            Return _nr_aliquota_ipi
        End Get
        Set(ByVal value As Decimal)
            _nr_aliquota_ipi = value
        End Set
    End Property
    Public Property nr_aliquota_pis() As Decimal
        Get
            Return _nr_aliquota_pis
        End Get
        Set(ByVal value As Decimal)
            _nr_aliquota_pis = value
        End Set
    End Property
    Public Property id_tributacao_cofins() As Int32
        Get
            Return _id_tributacao_cofins
        End Get
        Set(ByVal value As Int32)
            _id_tributacao_cofins = value
        End Set
    End Property
    Public Property id_tributacao_icms() As Int32
        Get
            Return _id_tributacao_icms
        End Get
        Set(ByVal value As Int32)
            _id_tributacao_icms = value
        End Set
    End Property
    Public Property id_tributacao_ipi() As Int32
        Get
            Return _id_tributacao_ipi
        End Get
        Set(ByVal value As Int32)
            _id_tributacao_ipi = value
        End Set
    End Property
    Public Property id_tributacao_pis() As Int32
        Get
            Return _id_tributacao_pis
        End Get
        Set(ByVal value As Int32)
            _id_tributacao_pis = value
        End Set
    End Property
    Public Property nm_tributacao_cofins() As String
        Get
            Return _nm_tributacao_cofins
        End Get
        Set(ByVal value As String)
            _nm_tributacao_cofins = value
        End Set
    End Property
    Public Property nm_tributacao_icms() As String
        Get
            Return _nm_tributacao_icms
        End Get
        Set(ByVal value As String)
            _nm_tributacao_icms = value
        End Set
    End Property
    Public Property nm_tributacao_ipi() As String
        Get
            Return _nm_tributacao_ipi
        End Get
        Set(ByVal value As String)
            _nm_tributacao_ipi = value
        End Set
    End Property
    Public Property nm_tributacao_pis() As String
        Get
            Return _nm_tributacao_pis
        End Get
        Set(ByVal value As String)
            _nm_tributacao_pis = value
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

    Public Sub New(ByVal id As Int32)

        Me.id_natureza_operacao = id
        loadNaturezaOperacao()

    End Sub



    Public Sub New()

    End Sub


    Public Function getNaturezaOperacoesByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getNaturezaOperacoes", parameters, "ms_natureza_operacao")
            Return dataSet

        End Using

    End Function

    Public Sub loadNaturezaOperacao()

        Dim dataSet As DataSet = getNaturezaOperacoesByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertNaturezaOperecao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertNaturezaOperacao", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateNaturezaOperacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateNaturezaOperacao", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteNaturezaOperacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteNaturezaOperacao", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
