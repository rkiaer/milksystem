Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class GoldCustoProdutorOperacionalItem

    Private _id_gold_custo_produtor_operacional_item As Int32
    Private _id_estabelecimento As Int32
    Private _nm_gold_custo_produtor_operacional_item As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nm_modificador As String

    
    Public Property id_gold_custo_produtor_operacional_item() As Int32
        Get
            Return _id_gold_custo_produtor_operacional_item
        End Get
        Set(ByVal value As Int32)
            _id_gold_custo_produtor_operacional_item = value
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
    Public Property nm_gold_custo_produtor_operacional_item() As String
        Get
            Return _nm_gold_custo_produtor_operacional_item
        End Get
        Set(ByVal value As String)
            _nm_gold_custo_produtor_operacional_item = value
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

    Public Property nm_modificador() As String
        Get
            Return _nm_modificador
        End Get
        Set(ByVal value As String)
            _nm_modificador = value
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


    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_gold_custo_produtor_operacional_item = id
        loadCustoProdutorOperacionalItem()

    End Sub

    Public Sub New()

    End Sub
    Private Sub loadCustoProdutorOperacionalItem()

        Dim dataSet As DataSet = getGoldCustoProdutorOperacionalItemByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function getGoldCustoProdutorOperacionalItemByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldCustoProdutorOperacionalItem", parameters, "ms_gold_custo_produtor_operacional_item")
            Return dataSet

        End Using

    End Function

    Public Sub deleteGoldCustoProdutorOperacionalItem()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteGoldCustoProdutorOperacionalItem", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Function insertGoldCustoProdutorOperacionalItem() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertGoldCustoProdutorOperacionalItem", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateGoldCustoProdutorOperacionalItem()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldCustoProdutorOperacionalItem", parameters, ExecuteType.Update)

        End Using

    End Sub

End Class
