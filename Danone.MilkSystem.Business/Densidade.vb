Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Densidade


    Private _id_densidade As Int32
    Private _nr_valor_densidade As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _dt_referencia As String


    Public Property id_densidade() As Int32
        Get
            Return _id_densidade
        End Get
        Set(ByVal value As Int32)
            _id_densidade = value
        End Set
    End Property
    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property

    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
        End Set
    End Property

    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
        End Set
    End Property
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property
    Public Property nr_valor_densidade() As Decimal
        Get
            Return _nr_valor_densidade
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_densidade = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me._id_densidade = id
        loadDensidade()

    End Sub


    Public Sub New()

    End Sub

    Public Function getDensidadebyFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getDensidade", parameters, "ms_densidade")
            Return dataSet

        End Using

    End Function

    Private Sub loadDensidade()

        Dim dataSet As DataSet = getDensidadebyFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Sub deleteDensidade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteDensidade", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function insertDensidade() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertDensidade", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateDensidade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateDensidade", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
