Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class JustificativAadiantamento

    Private _id_adiantamento_justificativa As Int32
    Private _nm_adiantamento_justificativa As String

    Public Property id_adiantamento_justificativa() As Int32
        Get
            Return _id_adiantamento_justificativa
        End Get
        Set(ByVal value As Int32)
            _id_adiantamento_justificativa = value
        End Set
    End Property

    Public Property nm_adiantamento_justificativa() As String
        Get
            Return _nm_adiantamento_justificativa
        End Get
        Set(ByVal value As String)
            _nm_adiantamento_justificativa = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_adiantamento_justificativa = id
        loadAdiantamentoJustificativa()

    End Sub

    Public Sub New()

    End Sub

    Public Function getAdiantamentoJustificativaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAdiantamentoJustificativas", parameters, "ms_zadiantamento_justificativa")
            Return dataSet

        End Using

    End Function

    Private Sub loadAdiantamentoJustificativa()

        Dim dataSet As DataSet = getAdiantamentoJustificativaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
