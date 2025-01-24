Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class CategoriaQualidade

    Private _id_categoria As Int32
    Private _nm_categoria As String

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


    Public Sub New(ByVal id As Int32)

        Me.id_categoria = id
        loadCategoria()

    End Sub

    Public Sub New()

    End Sub

    Public Function getCategoriaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCategoriasQualidade", parameters, "ms_zcategoria_qualidade")
            Return dataSet

        End Using

    End Function

    Public Function getCategoriaComplience() As DataSet '05/12/2016 - Mirella 

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCategoriasQualidadeComplience", parameters, "ms_zcategoria_qualidade")
            Return dataSet

        End Using

    End Function
    Private Sub loadCategoria()

        Dim dataSet As DataSet = getCategoriaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
