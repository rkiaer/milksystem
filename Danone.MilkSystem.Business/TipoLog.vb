Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class TipoLog

    Private _id_tipo_log As Int32
    Private _nm_tipo_log As String


    Public Property id_tipo_log() As Int32
        Get
            Return _id_tipo_log
        End Get
        Set(ByVal value As Int32)
            _id_tipo_log = value
        End Set
    End Property

    Public Property nm_tipo_log() As String
        Get
            Return _nm_tipo_log
        End Get
        Set(ByVal value As String)
            _nm_tipo_log = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_tipo_log = id
        loadTipoLog()

    End Sub

    Public Sub New()

    End Sub

    Public Function getTipoLogByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getTipoLog", parameters, "msc_ztipo_log")
            Return dataSet

        End Using

    End Function

    Private Sub loadTipoLog()

        Dim dataSet As DataSet = getTipoLogByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
