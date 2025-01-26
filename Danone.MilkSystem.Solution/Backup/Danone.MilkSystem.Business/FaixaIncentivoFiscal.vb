Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class FaixaIncentivoFiscal

    Private _id_faixa_incentivo_fiscal As Int32
    Private _nr_faixa_inicio As Decimal
    Private _nr_faixa_fim As Decimal
    Private _nr_incentivo_fiscal As Decimal
    Private _ds_validade As String
    Private _dt_validade As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_estabelecimento As Int32 'fran 27/11/2009 Maracanau i
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property

    Public Property id_faixa_incentivo_fiscal() As Int32
        Get
            Return _id_faixa_incentivo_fiscal
        End Get
        Set(ByVal value As Int32)
            _id_faixa_incentivo_fiscal = value
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

    Public Property nr_incentivo_fiscal() As Decimal
        Get
            Return _nr_incentivo_fiscal
        End Get
        Set(ByVal value As Decimal)
            _nr_incentivo_fiscal = value
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

        Me._id_faixa_incentivo_fiscal = id
        loadFaixaIncentivoFiscal()

    End Sub

    Public Sub New()

    End Sub

    Public Function getFaixaIncentivoFiscalByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFaixasIncentivoFiscal", parameters, "ms_faixa_incentivo_fiscal")
            Return dataSet

        End Using

    End Function

    Private Sub loadFaixaIncentivoFiscal()

        Dim dataSet As DataSet = getFaixaIncentivoFiscalByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertFaixaIncentivoFiscal() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertFaixasIncentivoFiscal", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateFaixaIncentivoFiscal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFaixasIncentivoFiscal", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deleteFaixaIncentivoFiscal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteFaixasIncentivoFiscal", parameters, ExecuteType.Delete)

        End Using

    End Sub

End Class
