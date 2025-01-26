Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class FormatoAnalise

    Private _id_formato_analise As Int32
    Private _nm_formato_analise As String

    Public Property id_formato_analise() As Int32
        Get
            Return _id_formato_analise
        End Get
        Set(ByVal value As Int32)
            _id_formato_analise = value
        End Set
    End Property

    Public Property nm_formato_analise() As String
        Get
            Return _nm_formato_analise
        End Get
        Set(ByVal value As String)
            _nm_formato_analise = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_formato_analise = id
        loadFormatoAnalise()

    End Sub

    Public Sub New()

    End Sub

    Public Function getFormatoAnalisesByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFormatoAnalises", parameters, "ms_zformato_analise")
            Return dataSet

        End Using

    End Function

    Private Sub loadFormatoAnalise()

        Dim dataSet As DataSet = getFormatoAnalisesByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
