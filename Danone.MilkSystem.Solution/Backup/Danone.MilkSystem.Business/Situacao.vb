Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class Situacao

    Private _id_situacao As Int32
    Private _nm_situacao As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property

    Public Property nm_situacao() As String
        Get
            Return _nm_situacao
        End Get
        Set(ByVal value As String)
            _nm_situacao = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_situacao = id
        loadSituacao()

    End Sub

    Public Sub New()

    End Sub

    Public Function getSituacoesByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSituacoes", parameters, "ms_situacao")
            Return dataSet

        End Using

    End Function

    Private Sub loadSituacao()

        Dim dataSet As DataSet = getSituacoesByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
