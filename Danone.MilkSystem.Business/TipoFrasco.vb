Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class TipoFrasco

    Private _id_tipo_frasco As Int32
    Private _nm_tipo_frasco As String
    Private _nm_imagem_frasco As String
    Private _id_situacao As Int32


    Public Property id_tipo_frasco() As Int32
        Get
            Return _id_tipo_frasco
        End Get
        Set(ByVal value As Int32)
            _id_tipo_frasco = value
        End Set
    End Property

    Public Property nm_tipo_frasco() As String
        Get
            Return _nm_tipo_frasco
        End Get
        Set(ByVal value As String)
            _nm_tipo_frasco = value
        End Set
    End Property

    Public Property nm_imagem_frasco() As String
        Get
            Return _nm_imagem_frasco
        End Get
        Set(ByVal value As String)
            _nm_imagem_frasco = value
        End Set
    End Property

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_tipo_frasco = id
        loadTipoFrasco()

    End Sub

    Public Sub New()

    End Sub

    Public Function getTipoFrascosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTipoFrasco", parameters, "ms_ztipo_frasco")
            Return dataSet

        End Using

    End Function

    Private Sub loadTipoFrasco()

        Dim dataSet As DataSet = getTipoFrascosByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
