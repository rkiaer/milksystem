Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class MotivoSaida

    Private _id_motivo_saida As Int32
    Private _nm_motivo_saida As String


    Public Property id_motivo_saida() As Int32
        Get
            Return _id_motivo_saida
        End Get
        Set(ByVal value As Int32)
            _id_motivo_saida = value
        End Set
    End Property

    Public Property nm_motivo_saida() As String
        Get
            Return _nm_motivo_saida
        End Get
        Set(ByVal value As String)
            _nm_motivo_saida = value
        End Set
    End Property


    Public Sub New()

    End Sub

    Public Function getMotivoSaidaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMotivoSaida", parameters, "ms_zmotivo_saida")
            Return dataSet

        End Using

    End Function


End Class
