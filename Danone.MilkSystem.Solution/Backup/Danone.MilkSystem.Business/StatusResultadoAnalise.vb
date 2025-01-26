Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class StatusResultadoAnalise

    Private _id_status_resultado_analise As Int32
    Private _nm_status_resultado_analise As String

    Public Property id_status_resultado_analise() As Int32
        Get
            Return _id_status_resultado_analise
        End Get
        Set(ByVal value As Int32)
            _id_status_resultado_analise = value
        End Set
    End Property

    Public Property nm_status_resultado_analise() As String
        Get
            Return _nm_status_resultado_analise
        End Get
        Set(ByVal value As String)
            _nm_status_resultado_analise = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_status_resultado_analise = id
        loadStatusResultadoAnalise()

    End Sub

    Public Sub New()

    End Sub

    Public Function getStatusResultadoAnaliseByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getStatusResultadoAnalise", parameters, "ms_zstatus_analise")
            Return dataSet

        End Using

    End Function

    Private Sub loadStatusResultadoAnalise()

        Dim dataSet As DataSet = getStatusResultadoAnaliseByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
