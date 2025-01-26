Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class AnaliseEsalqTipoColeta

    Private _id_tipo_coleta_analise_esalq As Int32
    Private _nm_tipo_coleta_analise_esalq As String


    Public Property id_tipo_coleta_analise_esalq() As Int32
        Get
            Return _id_tipo_coleta_analise_esalq
        End Get
        Set(ByVal value As Int32)
            _id_tipo_coleta_analise_esalq = value
        End Set
    End Property
    Public Property nm_tipo_coleta_analise_esalq() As String
        Get
            Return _nm_tipo_coleta_analise_esalq
        End Get
        Set(ByVal value As String)
            _nm_tipo_coleta_analise_esalq = value
        End Set
    End Property

    Public Sub New()

    End Sub


    Public Function getAnaliseEsalqTipoColetaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnaliseEsalqTipoColeta", parameters, "ms_ztipo_coleta_analise_esalq")
            Return dataSet

        End Using

    End Function



End Class
