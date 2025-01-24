Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class IndicadorTipo

    Private _id_indicador_tipo As Int32
    Private _cd_indicador_tipo As String
    Private _nm_indicador_tipo As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Public Property id_indicador_tipo() As Int32
        Get
            Return _id_indicador_tipo
        End Get
        Set(ByVal value As Int32)
            _id_indicador_tipo = value
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
    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
        End Set
    End Property

    Public Property nm_indicador_tipo() As String
        Get
            Return _nm_indicador_tipo
        End Get
        Set(ByVal value As String)
            _nm_indicador_tipo = value
        End Set
    End Property

    Public Property cd_indicador_tipo() As String
        Get
            Return _cd_indicador_tipo
        End Get
        Set(ByVal value As String)
            _cd_indicador_tipo = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_indicador_tipo = id
        loadIndicadorTipo()

    End Sub

    Public Sub New()

    End Sub

    Public Function getIndicadorTipoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getIndicadorTipo", parameters, "ms_zindicador_tipo")
            Return dataSet

        End Using

    End Function

    Private Sub loadIndicadorTipo()

        Dim dataSet As DataSet = getIndicadorTipoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
