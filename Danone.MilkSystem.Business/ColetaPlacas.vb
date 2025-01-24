Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class ColetaPlacas

    Private _id_coleta_veiculo As Int32
    Private _ds_placa As String
    Private _id_coleta As Int32
    Private _id_veiculo As Int32


    Public Property id_coleta_veiculo() As Int32
        Get
            Return _id_coleta_veiculo
        End Get
        Set(ByVal value As Int32)
            _id_coleta_veiculo = value
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
    Public Property id_coleta() As Int32
        Get
            Return _id_coleta
        End Get
        Set(ByVal value As Int32)
            _id_coleta = value
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

    Public Sub New()

    End Sub

    Public Function getColetaPlacasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getColetaPlacas", parameters, "ms_coleta_veiculos")
            Return dataSet

        End Using

    End Function


End Class
