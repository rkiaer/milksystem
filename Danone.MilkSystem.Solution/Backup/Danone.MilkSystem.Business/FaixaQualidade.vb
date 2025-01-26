Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class FaixaQualidade

    Private _id_faixa_qualidade As Int32
    Private _id_categoria As Int32
    Private _nm_categoria As String
    Private _nr_faixa_inicio As Decimal
    Private _nr_faixa_fim As Decimal
    Private _nr_bonus_desconto As Decimal
    Private _ds_validade As String
    Private _dt_validade As String
    Private _un_medida As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    'fran 27/11/2009 i Maracanau chamado 521
    Private _id_estabelecimento As Int32
    Private _id_contrato_validade As Int32 'fran 07/2017 i
    Public Property id_contrato_validade() As Int32
        Get
            Return _id_contrato_validade
        End Get
        Set(ByVal value As Int32)
            _id_contrato_validade = value
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
    'fran 27/11/2009 f Maracanau chamado 521
    Public Property id_faixa_qualidade() As Int32
        Get
            Return _id_faixa_qualidade
        End Get
        Set(ByVal value As Int32)
            _id_faixa_qualidade = value
        End Set
    End Property

    Public Property id_categoria() As Int32
        Get
            Return _id_categoria
        End Get
        Set(ByVal value As Int32)
            _id_categoria = value
        End Set
    End Property

    Public Property nm_categoria() As String
        Get
            Return _nm_categoria
        End Get
        Set(ByVal value As String)
            _nm_categoria = value
        End Set
    End Property

    Public Property nr_faixa_inicio() As Decimal
        Get
            Return _nr_faixa_inicio
        End Get
        Set(ByVal value As Decimal)
            _nr_faixa_inicio = value
        End Set
    End Property

    Public Property nr_faixa_fim() As Decimal
        Get
            Return _nr_faixa_fim
        End Get
        Set(ByVal value As Decimal)
            _nr_faixa_fim = value
        End Set
    End Property

    Public Property nr_bonus_desconto() As Decimal
        Get
            Return _nr_bonus_desconto
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_desconto = value
        End Set
    End Property

    Public Property ds_validade() As String
        Get
            Return _ds_validade
        End Get
        Set(ByVal value As String)
            _ds_validade = value
        End Set
    End Property

    Public Property dt_validade() As String
        Get
            Return _dt_validade
        End Get
        Set(ByVal value As String)
            _dt_validade = value
        End Set
    End Property

    Public Property un_medida() As String
        Get
            Return _un_medida
        End Get
        Set(ByVal value As String)
            _un_medida = value
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

    Public Sub New(ByVal id As Int32)

        Me._id_faixa_qualidade = id
        loadFaixaQualidade()

    End Sub

    Public Sub New()

    End Sub

    Public Function getFaixaQualidadeByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFaixasQualidade", parameters, "ms_faixa_qualidade")
            Return dataSet

        End Using

    End Function

    Public Function getContratoFaixasQualidadeConsFaixas() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContratoFaixasQualidadeConsFaixas", parameters, "ms_faixa_qualidade")
            Return dataSet

        End Using

    End Function
    Private Sub loadFaixaQualidade()

        Dim dataSet As DataSet = getFaixaQualidadeByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertFaixaQualidade() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertFaixasQualidade", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateFaixaQualidade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFaixasQualidade", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deleteConta()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteFaixasQualidade", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
