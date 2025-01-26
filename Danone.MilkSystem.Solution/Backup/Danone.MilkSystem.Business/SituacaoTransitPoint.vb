Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class SituacaoTransitPoint


    Private _id_situacao_transit_point As Int32
    Private _id_modificador As Int32
    Private _nm_situacao_transit_point As String

    Public Property id_situacao_transit_point() As Int32
        Get
            Return _id_situacao_transit_point
        End Get
        Set(ByVal value As Int32)
            _id_situacao_transit_point = value
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

    Public Property nm_situacao_transit_point() As String
        Get
            Return _nm_situacao_transit_point
        End Get
        Set(ByVal value As String)
            _nm_situacao_transit_point = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_situacao_transit_point = id
        loadSituacaoTransitPoint()

    End Sub

    Public Sub New()

    End Sub

    Public Function getSituacoesTransitPointByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSituacaoTransitPoint", parameters, "ms_zsituacao_transit_point")
            Return dataSet

        End Using

    End Function

    Private Sub loadSituacaoTransitPoint()

        Dim dataSet As DataSet = getSituacoesTransitPointByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
