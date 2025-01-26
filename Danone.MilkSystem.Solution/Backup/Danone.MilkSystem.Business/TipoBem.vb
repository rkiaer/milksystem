Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class TipoBem

    Private _id_tipobem As Int32
    Private _nm_tipobem As String

    Public Property id_tipobem() As Int32
        Get
            Return _id_tipobem
        End Get
        Set(ByVal value As Int32)
            _id_tipobem = value
        End Set
    End Property

    Public Property nm_tipobem() As String
        Get
            Return _nm_tipobem
        End Get
        Set(ByVal value As String)
            _nm_tipobem = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_tipobem = id
        loadTipoBem()

    End Sub

    Public Sub New()

    End Sub

    Public Function getTipoBensByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTipoBens", parameters, "ms_ztipo_bem")
            Return dataSet

        End Using

    End Function

    Private Sub loadTipoBem()

        Dim dataSet As DataSet = getTipoBensByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
