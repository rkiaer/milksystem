Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class SituacaoCotacaoItem

    Private _id_central_status_aprovacao As Int32
    Private _id_situacao As Int32
    Private _nm_central_status_aprovacao As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_central_status_aprovacao() As Int32
        Get
            Return _id_central_status_aprovacao
        End Get
        Set(ByVal value As Int32)
            _id_central_status_aprovacao = value
        End Set
    End Property

    Public Property nm_central_status_aprovacao() As String
        Get
            Return _nm_central_status_aprovacao
        End Get
        Set(ByVal value As String)
            _nm_central_status_aprovacao = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_central_status_aprovacao = id
        loadSituacaoCotacaoItem()

    End Sub

    Public Sub New()

    End Sub

    Public Function getSituacoesCotacoesItemByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSituacaoCotacaoItem", parameters, "ms_zcentral_status_aprovacao")
            Return dataSet

        End Using

    End Function

    Private Sub loadSituacaoCotacaoItem()

        Dim dataSet As DataSet = getSituacoesCotacoesItemByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
