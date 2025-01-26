Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class TipoAcesso

    Private _id_tipo_acesso As Int32
    Private _nm_tipo_acesso As String


    Public Property id_tipo_acesso() As Int32
        Get
            Return _id_tipo_acesso
        End Get
        Set(ByVal value As Int32)
            _id_tipo_acesso = value
        End Set
    End Property

    Public Property nm_tipo_acesso() As String
        Get
            Return _nm_tipo_acesso
        End Get
        Set(ByVal value As String)
            _nm_tipo_acesso = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_tipo_acesso = id
        loadTipoAcesso()

    End Sub

    Public Sub New()

    End Sub

    Public Function getTipoAcessosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getTipoAcessos", parameters, "msc_ztipo_acesso")
            Return dataSet

        End Using

    End Function

    Private Sub loadTipoAcesso()

        Dim dataSet As DataSet = getTipoAcessosByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
