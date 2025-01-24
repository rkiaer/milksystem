Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class StatusRomaneio

    Private _id_situacao As Int32
    Private _id_st_romaneio As Int32
    Private _nm_st_romaneio As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_st_romaneio() As Int32
        Get
            Return _id_st_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_st_romaneio = value
        End Set
    End Property

    Public Property nm_st_romaneio() As String
        Get
            Return _nm_st_romaneio
        End Get
        Set(ByVal value As String)
            _nm_st_romaneio = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_st_romaneio = id
        loadStatusRomaneio()

    End Sub

    Public Sub New()

    End Sub

    Public Function getStatusRomaneioByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getStatusRomaneio", parameters, "ms_zstatus_romaneio")
            Return dataSet

        End Using

    End Function

    Private Sub loadStatusRomaneio()

        Dim dataSet As DataSet = getStatusRomaneioByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
