Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class AnaliseEsalqSituacao

    Private _id_situacao_analise_esalq As Int32
    Private _nm_situacao_analise_esalq As String


    Public Property id_situacao_analise_esalq() As Int32
        Get
            Return _id_situacao_analise_esalq
        End Get
        Set(ByVal value As Int32)
            _id_situacao_analise_esalq = value
        End Set
    End Property
    Public Property nm_situacao_analise_esalq() As String
        Get
            Return _nm_situacao_analise_esalq
        End Get
        Set(ByVal value As String)
            _nm_situacao_analise_esalq = value
        End Set
    End Property

    Public Sub New()

    End Sub


    Public Function getAnaliseEsalqSituacaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnaliseEsalqSituacao", parameters, "ms_zsituacao_analise_esalq")
            Return dataSet

        End Using

    End Function



End Class
