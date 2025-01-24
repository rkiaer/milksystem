Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class StatusPrecoNegociado

    Private _st_aprovado As Int32
    Private _nm_aprovado As String

    Public Property st_aprovado() As Int32
        Get
            Return _st_aprovado
        End Get
        Set(ByVal value As Int32)
            _st_aprovado = value
        End Set
    End Property

    Public Property nm_aprovado() As String
        Get
            Return _nm_aprovado
        End Get
        Set(ByVal value As String)
            _nm_aprovado = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.st_aprovado = id
        loadStatusPrecoNegociado()

    End Sub

    Public Sub New()

    End Sub

    Public Function getStatusPrecoNegociadoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getStatusPrecoNegociado", parameters, "ms_zstatus_preconegociado")
            Return dataSet

        End Using

    End Function

    Private Sub loadStatusPrecoNegociado()

        Dim dataSet As DataSet = getStatusPrecoNegociadoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
