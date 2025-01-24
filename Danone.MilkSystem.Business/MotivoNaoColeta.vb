Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class MotivoNaoColeta

    Private _id_motivo_nao_coleta As Int32
    Private _nm_motivo_nao_coleta As String


    Public Property id_motivo_nao_coleta() As Int32
        Get
            Return _id_motivo_nao_coleta
        End Get
        Set(ByVal value As Int32)
            _id_motivo_nao_coleta = value
        End Set
    End Property

    Public Property nm_motivo_nao_coleta() As String
        Get
            Return _nm_motivo_nao_coleta
        End Get
        Set(ByVal value As String)
            _nm_motivo_nao_coleta = value
        End Set
    End Property


    Public Sub New()

    End Sub

    Public Function getMotivoNaoColetaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMotivoNaoColeta", parameters, "ms_motivo_nao_coleta")
            Return dataSet

        End Using

    End Function


End Class
