Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class Portador

    Private _id_portador As Int32
    Private _nm_portador As String

    Public Property id_portador() As Int32
        Get
            Return _id_portador
        End Get
        Set(ByVal value As Int32)
            _id_portador = value
        End Set
    End Property

    Public Property nm_portador() As String
        Get
            Return _nm_portador
        End Get
        Set(ByVal value As String)
            _nm_portador = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_portador = id
        loadPortador()

    End Sub

    Public Sub New()

    End Sub

    Public Function getPortadoresByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPortadores", parameters, "ms_zportador")
            Return dataSet

        End Using

    End Function

    Private Sub loadPortador()

        Dim dataSet As DataSet = getPortadoresByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
