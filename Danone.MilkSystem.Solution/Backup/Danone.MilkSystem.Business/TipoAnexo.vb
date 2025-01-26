Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class TipoAnexo

    Private _id_tipo_anexo As Int32
    Private _nm_tipo_anexo As String

    Public Property id_tipo_anexo() As Int32
        Get
            Return _id_tipo_anexo
        End Get
        Set(ByVal value As Int32)
            _id_tipo_anexo = value
        End Set
    End Property

    Public Property nm_tipo_anexo() As String
        Get
            Return _nm_tipo_anexo
        End Get
        Set(ByVal value As String)
            _nm_tipo_anexo = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_tipo_anexo = id
        loadTipoAnexo()

    End Sub

    Public Sub New()

    End Sub

    Public Function getTipoAnexoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTipoAnexo", parameters, "ms_ztipo_anexo")
            Return dataSet

        End Using

    End Function

    Private Sub loadTipoAnexo()

        Dim dataSet As DataSet = getTipoAnexoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
