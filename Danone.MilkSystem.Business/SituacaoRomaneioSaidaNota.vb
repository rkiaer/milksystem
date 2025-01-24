Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class SituacaoRomaneioSaidaNota


    Private _id_situacao_romaneio_saida_nota As Int32
    Private _id_situacao As Int32
    Private _nm_situacao_romaneio_saida_nota As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_situacao_romaneio_saida_nota() As Int32
        Get
            Return _id_situacao_romaneio_saida_nota
        End Get
        Set(ByVal value As Int32)
            _id_situacao_romaneio_saida_nota = value
        End Set
    End Property

    Public Property nm_situacao_romaneio_saida_nota() As String
        Get
            Return _nm_situacao_romaneio_saida_nota
        End Get
        Set(ByVal value As String)
            _nm_situacao_romaneio_saida_nota = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_situacao_romaneio_saida_nota = id
        loadSituacaoRomaneioSaidaNota()

    End Sub

    Public Sub New()

    End Sub

    Public Function getSituacaoRomaneioSaidaNotaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSituacaoRomaneioSaidaNota", parameters, "ms_zsituacao_romaneio_saida_nota")
            Return dataSet

        End Using

    End Function

    Private Sub loadSituacaoRomaneioSaidaNota()

        Dim dataSet As DataSet = getSituacaoRomaneioSaidaNotaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
