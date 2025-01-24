Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Silo

    Private _id_silo As Int32
    Private _nr_silo As Int32
    Private _nr_volume As Decimal
    Private _id_item_leite As Int32
    Private _nm_item_leite As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _id_estabelecimento As Int32
    Private _dt_modificacao As String
    Private _nm_silo As String
    Private _nm_estabelecimento As String


    Public Property id_silo() As Int32
        Get
            Return _id_silo
        End Get
        Set(ByVal value As Int32)
            _id_silo = value
        End Set
    End Property
    Public Property nr_silo() As Int32
        Get
            Return _nr_silo
        End Get
        Set(ByVal value As Int32)
            _nr_silo = value
        End Set
    End Property
    Public Property nr_volume() As Decimal
        Get
            Return _nr_volume
        End Get
        Set(ByVal value As Decimal)
            _nr_volume = value
        End Set
    End Property
    Public Property id_item_leite() As Int32
        Get
            Return _id_item_leite
        End Get
        Set(ByVal value As Int32)
            _id_item_leite = value
        End Set
    End Property
    Public Property nm_item_leite() As String
        Get
            Return _nm_item_leite
        End Get
        Set(ByVal value As String)
            _nm_item_leite = value
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

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
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


    Public Property nm_silo() As String
        Get
            Return _nm_silo
        End Get
        Set(ByVal value As String)
            _nm_silo = value
        End Set
    End Property
    Public Property nm_estabelecimento() As String
        Get
            Return _nm_estabelecimento
        End Get
        Set(ByVal value As String)
            _nm_estabelecimento = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_silo = id
        loadSilo()

    End Sub



    Public Sub New()

    End Sub


    Public Function getSiloByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getSilos", parameters, "ms_silo")
            Return dataSet

        End Using

    End Function

    Private Sub loadSilo()

        Dim dataSet As DataSet = getSiloByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertSilo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertSilos", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateSilo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateSilos", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteSilo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteSilos", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
