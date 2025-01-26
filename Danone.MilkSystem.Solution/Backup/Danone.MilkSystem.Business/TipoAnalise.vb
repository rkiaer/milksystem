Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class TipoAnalise

    Private _id_tipo_analise As Int32
    Private _nm_tipo_analise As String

    Public Property id_tipo_analise() As Int32
        Get
            Return _id_tipo_analise
        End Get
        Set(ByVal value As Int32)
            _id_tipo_analise = value
        End Set
    End Property

    Public Property nm_tipo_analise() As String
        Get
            Return _nm_tipo_analise
        End Get
        Set(ByVal value As String)
            _nm_tipo_analise = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_tipo_analise = id
        loadTipoAnalise()

    End Sub

    Public Sub New()

    End Sub

    Public Function getTipoAnalisesByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTipoAnalises", parameters, "ms_ztipo_analise")
            Return dataSet

        End Using

    End Function

    Private Sub loadTipoAnalise()

        Dim dataSet As DataSet = getTipoAnalisesByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
