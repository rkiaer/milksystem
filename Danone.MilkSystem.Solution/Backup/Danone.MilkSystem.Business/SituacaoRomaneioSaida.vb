Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class SituacaoRomaneioSaida


    Private _id_situacao_romaneio_saida As Int32
    Private _id_situacao As Int32
    Private _nm_situacao_romaneio_saida As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_situacao_romaneio_saida() As Int32
        Get
            Return _id_situacao_romaneio_saida
        End Get
        Set(ByVal value As Int32)
            _id_situacao_romaneio_saida = value
        End Set
    End Property

    Public Property nm_situacao_romaneio_saida() As String
        Get
            Return _nm_situacao_romaneio_saida
        End Get
        Set(ByVal value As String)
            _nm_situacao_romaneio_saida = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_situacao_romaneio_saida = id
        loadSituacaoRomaneioSaida()

    End Sub

    Public Sub New()

    End Sub

    Public Function getSituacaoRomaneioSaidaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSituacaoRomaneioSaida", parameters, "ms_zsituacao_romaneio_saida")
            Return dataSet

        End Using

    End Function

    Private Sub loadSituacaoRomaneioSaida()

        Dim dataSet As DataSet = getSituacaoRomaneioSaidaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
