Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class SituacaoContrato


    Private _id_situacao_contrato As Int32
    Private _id_modificador As Int32
    Private _nm_situacao_contrato As String

    Public Property id_situacao_contrato() As Int32
        Get
            Return _id_situacao_contrato
        End Get
        Set(ByVal value As Int32)
            _id_situacao_contrato = value
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

    Public Property nm_situacao_contrato() As String
        Get
            Return _nm_situacao_contrato
        End Get
        Set(ByVal value As String)
            _nm_situacao_contrato = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_situacao_contrato = id
        loadSituacaoContrato()

    End Sub

    Public Sub New()

    End Sub

    Public Function getSituacoesContratoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSituacaoContrato", parameters, "ms_zsituacao_Contrato")
            Return dataSet

        End Using

    End Function

    Private Sub loadSituacaoContrato()

        Dim dataSet As DataSet = getSituacoesContratoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
