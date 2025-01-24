Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class TipoOperacao

    Private _id_tipo_operacao As Int32
    Private _nm_tipo_operacao As String
    Private _id_situacao As Int32


    Public Property id_tipo_operacao() As Int32
        Get
            Return _id_tipo_operacao
        End Get
        Set(ByVal value As Int32)
            _id_tipo_operacao = value
        End Set
    End Property

    Public Property nm_tipo_operacao() As String
        Get
            Return _nm_tipo_operacao
        End Get
        Set(ByVal value As String)
            _nm_tipo_operacao = value
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

        Me.id_tipo_operacao = id
        loadTipoOperacao()

    End Sub

    Public Sub New()

    End Sub

    Public Function getTipoOperacaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTipoOperacao", parameters, "ms_ztipo_operacao")
            Return dataSet

        End Using

    End Function

    Private Sub loadTipoOperacao()

        Dim dataSet As DataSet = getTipoOperacaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
