Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class TransvaseVeiculo

    Private _id_transvase_veiculo As Int32
    Private _id_transvase As Int32
    Private _id_veiculo As Int32
    Private _ds_placa As String
    Private _st_principal As String
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String

    Public Property id_transvase() As Int32
        Get
            Return _id_transvase
        End Get
        Set(ByVal value As Int32)
            _id_transvase = value
        End Set
    End Property
    Public Property id_transvase_veiculo() As Int32
        Get
            Return _id_transvase_veiculo
        End Get
        Set(ByVal value As Int32)
            _id_transvase_veiculo = value
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

        Me._id_transvase_veiculo = id
        loadTransvaseVeiculo()

    End Sub

    Public Function getTransvaseVeiculoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransvaseVeiculo", parameters, "ms_transvase_veiculo")
            Return dataSet

        End Using

    End Function
    Public Sub deleteTransvaseVeiculo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteTransvaseVeiculo", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Private Sub loadTransvaseVeiculo()

        Dim dataSet As DataSet = getTransvaseVeiculoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertTransvaseVeiculo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertTransvaseVeiculo", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Sub updateTransvaseVeiculo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateTransvaseVeiculo", parameters, ExecuteType.Update)

        End Using

    End Sub

End Class
