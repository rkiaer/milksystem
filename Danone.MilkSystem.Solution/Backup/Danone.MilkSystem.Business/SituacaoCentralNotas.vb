Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class SituacaoCentralNotas


    Private _id_situacao_central_notas As Int32
    Private _id_situacao As Int32
    Private _nm_situacao_central_notas As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_situacao_central_notas() As Int32
        Get
            Return _id_situacao_central_notas
        End Get
        Set(ByVal value As Int32)
            _id_situacao_central_notas = value
        End Set
    End Property

    Public Property nm_situacao_central_notas() As String
        Get
            Return _nm_situacao_central_notas
        End Get
        Set(ByVal value As String)
            _nm_situacao_central_notas = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_situacao_central_notas = id
        loadSituacaoCentralNotas()

    End Sub

    Public Sub New()

    End Sub

    Public Function getSituacoesCentralNotasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSituacaoCentralNotas", parameters, "ms_zsituacao_central_notas")
            Return dataSet

        End Using

    End Function

    Private Sub loadSituacaoCentralNotas()

        Dim dataSet As DataSet = getSituacoesCentralNotasByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
