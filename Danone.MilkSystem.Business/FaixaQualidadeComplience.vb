Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class FaixaQualidadeComplience

    Private _id_faixa_qualidade_complience As Int32
    Private _cd_gold_faixa_custo As Int32
    Private _id_estabelecimento As Int32
    Private _ds_faixa_qualidade_complience As String
    Private _dt_validade As String
    Private _ds_validade As String
    Private _nr_valor As Decimal
    Private _id_situacao As Int32
    Private _id_operador As Int32
    Private _id_categoria As Int32
    Private _id_modificador As Int32

    Public Property id_faixa_qualidade_complience() As Int32
        Get
            Return _id_faixa_qualidade_complience
        End Get
        Set(ByVal value As Int32)
            _id_faixa_qualidade_complience = value
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
    Public Property dt_validade() As String
        Get
            Return _dt_validade
        End Get
        Set(ByVal value As String)
            _dt_validade = value
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
    Public Property ds_faixa_qualidade_complience() As String
        Get
            Return _ds_faixa_qualidade_complience
        End Get
        Set(ByVal value As String)
            _ds_faixa_qualidade_complience = value
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

    Public Property nr_valor() As Decimal
        Get
            Return _nr_valor
        End Get
        Set(ByVal value As Decimal)
            _nr_valor = value
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
    Public Property id_categoria() As Int32
        Get
            Return _id_categoria
        End Get
        Set(ByVal value As Int32)
            _id_categoria = value
        End Set
    End Property
    Public Property id_operador() As Int32
        Get
            Return _id_operador
        End Get
        Set(ByVal value As Int32)
            _id_operador = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Int32)

        Me._id_faixa_qualidade_complience = id
        loadFaixaQualidadeComplience()

    End Sub

    Public Function getFaixaQualidadeComplienceByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFaixasQualidadeComplience", parameters, "ms_faixa_qualidade_complience")
            Return dataSet

        End Using

    End Function

    Private Sub loadFaixaQualidadeComplience()

        Dim dataSet As DataSet = getFaixaQualidadeComplienceByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertFaixaQualidadeComplience() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertFaixasQualidadeComplience", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateFaixaQualidadeComplience()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateFaixasQualidadeComplience", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deleteConta()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteFaixasQualidadeComplience", parameters, ExecuteType.Delete)

        End Using


    End Sub
End Class
