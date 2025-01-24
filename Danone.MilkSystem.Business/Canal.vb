Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class Canal


    Private _id_canal As Int32
    Private _id_situacao As Int32
    Private _nm_canal As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_canal() As Int32
        Get
            Return _id_canal
        End Get
        Set(ByVal value As Int32)
            _id_canal = value
        End Set
    End Property

    Public Property nm_canal() As String
        Get
            Return _nm_canal
        End Get
        Set(ByVal value As String)
            _nm_canal = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_canal = id
        loadCanal()

    End Sub

    Public Sub New()

    End Sub

    Public Function getCanalByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCanal", parameters, "ms_zcanal")
            Return dataSet

        End Using

    End Function

    Private Sub loadCanal()

        Dim dataSet As DataSet = getCanalByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
