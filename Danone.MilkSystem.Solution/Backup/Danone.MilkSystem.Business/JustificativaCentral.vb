Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class JustificativaCentral

    Private _id_central_justificativa_aprovacao As Int32
    Private _nm_central_justificativa_aprovacao As String

    Public Property id_central_justificativa_aprovacao() As Int32
        Get
            Return _id_central_justificativa_aprovacao
        End Get
        Set(ByVal value As Int32)
            _id_central_justificativa_aprovacao = value
        End Set
    End Property

    Public Property nm_central_justificativa_aprovacao() As String
        Get
            Return _nm_central_justificativa_aprovacao
        End Get
        Set(ByVal value As String)
            _nm_central_justificativa_aprovacao = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_central_justificativa_aprovacao = id
        loadCentralJustificativa()

    End Sub

    Public Sub New()

    End Sub

    Public Function getCentralJustificativaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralJustificativa", parameters, "ms_zcentral_justificativa_aprovacao")
            Return dataSet

        End Using

    End Function

    Private Sub loadCentralJustificativa()

        Dim dataSet As DataSet = getCentralJustificativaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
