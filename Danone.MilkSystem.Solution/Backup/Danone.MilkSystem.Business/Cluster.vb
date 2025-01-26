Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class Cluster


    Private _id_cluster As Int32
    Private _id_situacao As Int32
    Private _nm_cluster As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_cluster() As Int32
        Get
            Return _id_cluster
        End Get
        Set(ByVal value As Int32)
            _id_cluster = value
        End Set
    End Property

    Public Property nm_cluster() As String
        Get
            Return _nm_cluster
        End Get
        Set(ByVal value As String)
            _nm_cluster = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_cluster = id
        loadCluster()

    End Sub

    Public Sub New()

    End Sub

    Public Function getClusterByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCluster", parameters, "ms_zcluster")
            Return dataSet

        End Using

    End Function

    Private Sub loadCluster()

        Dim dataSet As DataSet = getClusterByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
