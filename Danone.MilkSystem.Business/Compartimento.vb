Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Compartimento

    Private _id_compartimento As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _id_veiculo As Int32
    Private _dt_modificacao As String
    Private _nm_compartimento As String
    Private _nr_compartimento As Int32
    Private _nr_volume As Decimal
    Private _ds_placa As String


    Public Property id_compartimento() As Int32
        Get
            Return _id_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_compartimento = value
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

    Public Property id_veiculo() As Int32
        Get
            Return _id_veiculo
        End Get
        Set(ByVal value As Int32)
            _id_veiculo = value
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

    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
        End Set
    End Property


    Public Property nm_compartimento() As String
        Get
            Return _nm_compartimento
        End Get
        Set(ByVal value As String)
            _nm_compartimento = value
        End Set
    End Property
    Public Property nr_compartimento() As Int32
        Get
            Return _nr_compartimento
        End Get
        Set(ByVal value As Int32)
            _nr_compartimento = value
        End Set
    End Property
    Public Property ds_placa() As String
        Get
            Return _ds_placa
        End Get
        Set(ByVal value As String)
            _ds_placa = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_compartimento = id
        loadCompartimento()

    End Sub



    Public Sub New()

    End Sub


    Public Function getCompartimentoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCompartimentos", parameters, "ms_compartimento")
            Return dataSet

        End Using

    End Function

    Private Sub loadCompartimento()

        Dim dataSet As DataSet = getCompartimentoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertCompartimento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCompartimentos", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateCompartimento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCompartimentos", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteCompartimento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCompartimentos", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function getCompartimentosSomaVolumeByPlaca() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCompartimentosSomaVolumeByPlaca", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
End Class
