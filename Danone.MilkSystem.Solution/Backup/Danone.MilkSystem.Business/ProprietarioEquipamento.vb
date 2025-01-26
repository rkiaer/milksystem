Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class ProprietarioEquipamento

    Private _id_proprietario As Int32
    Private _nm_proprietario As String

    Public Property id_proprietario() As Int32
        Get
            Return _id_proprietario
        End Get
        Set(ByVal value As Int32)
            _id_proprietario = value
        End Set
    End Property

    Public Property nm_proprietario() As String
        Get
            Return _nm_proprietario
        End Get
        Set(ByVal value As String)
            _nm_proprietario = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_proprietario = id
        loadProprietarioEquipamento()

    End Sub

    Public Sub New()

    End Sub

    Public Function getProprietariosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getProprietarios", parameters, "ms_zProprietario")
            Return dataSet

        End Using

    End Function

    Private Sub loadProprietarioEquipamento()

        Dim dataSet As DataSet = getProprietariosByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
