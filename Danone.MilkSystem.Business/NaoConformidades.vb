Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class NaoConformidades

    Private _id_nao_conformidade As Int32
    Private _nm_nao_conformidade As String


    Public Property id_nao_conformidade() As Int32
        Get
            Return _id_nao_conformidade
        End Get
        Set(ByVal value As Int32)
            _id_nao_conformidade = value
        End Set
    End Property

    Public Property nm_nao_conformidade() As String
        Get
            Return _nm_nao_conformidade
        End Get
        Set(ByVal value As String)
            _nm_nao_conformidade = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Function getNaoConformidadesByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getNaoConformidades", parameters, "ms_znao_conformidades")
            Return dataSet

        End Using

    End Function


End Class
