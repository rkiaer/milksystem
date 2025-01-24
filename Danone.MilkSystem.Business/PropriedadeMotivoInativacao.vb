Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class PropriedadeMotivoInativacao

    Private _id_situacao As Int32
    Private _nm_motivo_inativacao As String
    Private _id_motivo_inativacao As Int32

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_motivo_inativacao() As Int32
        Get
            Return _id_motivo_inativacao
        End Get
        Set(ByVal value As Int32)
            _id_motivo_inativacao = value
        End Set
    End Property

    Public Property nm_motivo_inativacao() As String
        Get
            Return _nm_motivo_inativacao
        End Get
        Set(ByVal value As String)
            _nm_motivo_inativacao = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_motivo_inativacao = id
        loadMotivoInativacao()

    End Sub

    Public Sub New()

    End Sub

    Public Function getMotivosInativacaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMotivosInativacao", parameters, "ms_zmotivo_inativacao")
            Return dataSet

        End Using

    End Function

    Private Sub loadMotivoInativacao()

        Dim dataSet As DataSet = getMotivosInativacaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
