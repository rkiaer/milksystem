Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class MotivoNaoColetaAmostra

    Private _id_motivo_nao_coleta_amostra As Int32
    Private _nm_motivo_nao_coleta_amostra As String


    Public Property id_motivo_nao_coleta_amostra() As Int32
        Get
            Return _id_motivo_nao_coleta_amostra
        End Get
        Set(ByVal value As Int32)
            _id_motivo_nao_coleta_amostra = value
        End Set
    End Property

    Public Property nm_motivo_nao_coleta_amostra() As String
        Get
            Return _nm_motivo_nao_coleta_amostra
        End Get
        Set(ByVal value As String)
            _nm_motivo_nao_coleta_amostra = value
        End Set
    End Property


    Public Sub New()

    End Sub

    Public Function getMotivoNaoColetaAmostraByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMotivoNaoColetaAmostraTodos", parameters, "ms_motivo_nao_coleta_amostra")
            Return dataSet

        End Using

    End Function

    Public Function getMotivoNaoColetaAmostra() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMotivoNaoColetaAmostra", parameters, "ms_motivo_nao_coleta_amostra")
            Return dataSet

        End Using

    End Function
End Class
