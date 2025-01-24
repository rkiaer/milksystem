Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class SituacaoColetaAmostraManual


    Private _id_situacao_coleta_amostra_manual As Int32
    Private _id_situacao As Int32
    Private _nm_situacao_coleta_amostra_manual As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_situacao_coleta_amostra_manual() As Int32
        Get
            Return _id_situacao_coleta_amostra_manual
        End Get
        Set(ByVal value As Int32)
            _id_situacao_coleta_amostra_manual = value
        End Set
    End Property

    Public Property nm_situacao_coleta_amostra_manual() As String
        Get
            Return _nm_situacao_coleta_amostra_manual
        End Get
        Set(ByVal value As String)
            _nm_situacao_coleta_amostra_manual = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_situacao_coleta_amostra_manual = id
        loadSituacaoColetaAmostraManual()

    End Sub

    Public Sub New()

    End Sub

    Public Function getSituacoesColetaAmostraManualByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSituacaoColetaAmostraManual", parameters, "ms_zsituacao_coleta_amostra_manual")
            Return dataSet

        End Using

    End Function

    Private Sub loadSituacaoColetaAmostraManual()

        Dim dataSet As DataSet = getSituacoesColetaAmostraManualByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
