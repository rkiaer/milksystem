Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class SituacaoPoupanca


    Private _id_situacao_poupanca As Int32
    Private _id_modificador As Int32
    Private _nm_situacao_poupanca As String

    Public Property id_situacao_poupanca() As Int32
        Get
            Return _id_situacao_poupanca
        End Get
        Set(ByVal value As Int32)
            _id_situacao_poupanca = value
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

    Public Property nm_situacao_poupanca() As String
        Get
            Return _nm_situacao_poupanca
        End Get
        Set(ByVal value As String)
            _nm_situacao_poupanca = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_situacao_poupanca = id
        loadSituacaoPoupanca()

    End Sub

    Public Sub New()

    End Sub

    Public Function getSituacoesPoupancaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSituacaoPoupanca", parameters, "ms_zsituacao_poupanca")
            Return dataSet

        End Using

    End Function

    Private Sub loadSituacaoPoupanca()

        Dim dataSet As DataSet = getSituacoesPoupancaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
