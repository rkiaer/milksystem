Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class SituacaoColetaAmostra


    Private _id_situacao_coleta_amostra As Int32
    Private _id_situacao As Int32
    Private _nm_situacao_coleta_amostra As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_situacao_coleta_amostra() As Int32
        Get
            Return _id_situacao_coleta_amostra
        End Get
        Set(ByVal value As Int32)
            _id_situacao_coleta_amostra = value
        End Set
    End Property

    Public Property nm_situacao_coleta_amostra() As String
        Get
            Return _nm_situacao_coleta_amostra
        End Get
        Set(ByVal value As String)
            _nm_situacao_coleta_amostra = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_situacao_coleta_amostra = id
        loadSituacaoColetaAmostra()

    End Sub

    Public Sub New()

    End Sub

    Public Function getSituacoesColetaAmostraByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSituacaoColetaAmostra", parameters, "ms_zsituacao_coleta_amostra")
            Return dataSet

        End Using

    End Function

    Private Sub loadSituacaoColetaAmostra()

        Dim dataSet As DataSet = getSituacoesColetaAmostraByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
