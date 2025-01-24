Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class CategoriaItem


    Private _id_categoria_item As Int32
    Private _id_situacao As Int32
    Private _nm_categoria_item As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_categoria_item() As Int32
        Get
            Return _id_categoria_item
        End Get
        Set(ByVal value As Int32)
            _id_categoria_item = value
        End Set
    End Property

    Public Property nm_categoria_item() As String
        Get
            Return _nm_categoria_item
        End Get
        Set(ByVal value As String)
            _nm_categoria_item = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_categoria_item = id
        loadCategoriaItem()

    End Sub

    Public Sub New()

    End Sub

    Public Function getCategoriaItemByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCategoriaItem", parameters, "ms_zcategoria_item")
            Return dataSet

        End Using

    End Function

    Private Sub loadCategoriaItem()

        Dim dataSet As DataSet = getCategoriaItemByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
