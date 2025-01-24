Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class StatusAnalise

    Private _id_st_analise As Int32
    Private _nm_st_analise As String

    Public Property id_st_analise() As Int32
        Get
            Return _id_st_analise
        End Get
        Set(ByVal value As Int32)
            _id_st_analise = value
        End Set
    End Property

    Public Property nm_st_analise() As String
        Get
            Return _nm_st_analise
        End Get
        Set(ByVal value As String)
            _nm_st_analise = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_st_analise = id
        loadStatusAnalise()

    End Sub

    Public Sub New()

    End Sub

    Public Function getStatusAnaliseByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getStatusAnalise", parameters, "ms_zstatus_analise")
            Return dataSet

        End Using

    End Function

    Private Sub loadStatusAnalise()

        Dim dataSet As DataSet = getStatusAnaliseByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
