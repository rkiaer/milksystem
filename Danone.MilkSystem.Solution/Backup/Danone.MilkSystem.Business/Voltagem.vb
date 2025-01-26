Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class Voltagem

    Private _id_voltagem As Int32
    Private _nm_voltagem As String

    Public Property id_voltagem() As Int32
        Get
            Return _id_voltagem
        End Get
        Set(ByVal value As Int32)
            _id_voltagem = value
        End Set
    End Property

    Public Property nm_voltagem() As String
        Get
            Return _nm_voltagem
        End Get
        Set(ByVal value As String)
            _nm_voltagem = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_voltagem = id
        loadVoltagem()

    End Sub

    Public Sub New()

    End Sub

    Public Function getVoltagensByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getVoltagens", parameters, "ms_zvoltagem")
            Return dataSet

        End Using

    End Function

    Private Sub loadVoltagem()

        Dim dataSet As DataSet = getVoltagensByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
