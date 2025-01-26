Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class TransitPointVeiculo

    Private _id_transit_point_veiculo As Int32
    Private _id_transit_point As Int32
    Private _id_veiculo As Int32
    Private _ds_placa As String
    Private _st_principal As String
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String

    Public Property id_transit_point() As Int32
        Get
            Return _id_transit_point
        End Get
        Set(ByVal value As Int32)
            _id_transit_point = value
        End Set
    End Property
    Public Property id_transit_point_veiculo() As Int32
        Get
            Return _id_transit_point_veiculo
        End Get
        Set(ByVal value As Int32)
            _id_transit_point_veiculo = value
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
    Public Property ds_placa() As String
        Get
            Return _ds_placa
        End Get
        Set(ByVal value As String)
            _ds_placa = value
        End Set
    End Property
    Public Property st_principal() As String
        Get
            Return _st_principal
        End Get
        Set(ByVal value As String)
            _st_principal = value
        End Set
    End Property

    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
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

    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
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
 
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Int32)

        Me._id_transit_point_veiculo = id
        loadTransitPointVeiculo()

    End Sub

    Public Function getTransitPointVeiculoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransitPointVeiculo", parameters, "ms_transit_point_veiculo")
            Return dataSet

        End Using

    End Function
    Public Sub deleteTransitPointVeiculo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteTransitPointVeiculo", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Private Sub loadTransitPointVeiculo()

        Dim dataSet As DataSet = getTransitPointVeiculoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertTransitPointVeiculo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertTransitPointVeiculo", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Sub updateTransitPointVeiculo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateTransitPointVeiculo", parameters, ExecuteType.Update)

        End Using

    End Sub

End Class
