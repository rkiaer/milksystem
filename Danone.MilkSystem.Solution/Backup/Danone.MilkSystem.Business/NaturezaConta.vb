Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class NaturezaConta

    Private _id_natureza As Int32
    Private _nm_natureza As String

    Public Property id_natureza() As Int32
        Get
            Return _id_natureza
        End Get
        Set(ByVal value As Int32)
            _id_natureza = value
        End Set
    End Property

    Public Property nm_natureza() As String
        Get
            Return _nm_natureza
        End Get
        Set(ByVal value As String)
            _nm_natureza = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_natureza = id
        loadNatureza()

    End Sub

    Public Sub New()

    End Sub

    Public Function getNaturezaContasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getNaturezaContas", parameters, "ms_znatureza_conta")
            Return dataSet

        End Using

    End Function

    Private Sub loadNatureza()

        Dim dataSet As DataSet = getNaturezaContasByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
