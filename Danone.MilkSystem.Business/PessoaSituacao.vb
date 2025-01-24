Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PessoaSituacao


    Private _id_pessoa_situacao As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nm_pessoa_situacao As String

    Public Property id_pessoa_situacao() As Int32
        Get
            Return _id_pessoa_situacao
        End Get
        Set(ByVal value As Int32)
            _id_pessoa_situacao = value
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

    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
        End Set
    End Property

    Public Property nm_pessoa_situacao() As String
        Get
            Return _nm_pessoa_situacao
        End Get
        Set(ByVal value As String)
            _nm_pessoa_situacao = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_pessoa_situacao = id
        loadPessoaSituacao()

    End Sub


    Public Sub New()

    End Sub

    Public Function getPessoaSituacoesByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPessoaSituacoes", parameters, "ms_pessoa_situacao")
            Return dataSet

        End Using

    End Function

    Private Sub loadPessoaSituacao()

        Dim dataSet As DataSet = getPessoaSituacoesByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
