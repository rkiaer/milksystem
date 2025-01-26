Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class TipoNotificacao

    Private _id_tipo_notificacao As Int32
    Private _nm_tipo_notificacao As String

    Public Property id_tipo_notificacao() As Int32
        Get
            Return _id_tipo_notificacao
        End Get
        Set(ByVal value As Int32)
            _id_tipo_notificacao = value
        End Set
    End Property

    Public Property nm_tipo_notificacao() As String
        Get
            Return _nm_tipo_notificacao
        End Get
        Set(ByVal value As String)
            _nm_tipo_notificacao = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_tipo_notificacao = id
        loadTipoNotificacao()

    End Sub

    Public Sub New()

    End Sub

    Public Function getTiposNotificacaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTiposNotificacao", parameters, "ms_ztipo_notificacao")
            Return dataSet

        End Using

    End Function

    Private Sub loadTipoNotificacao()

        Dim dataSet As DataSet = getTiposNotificacaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
