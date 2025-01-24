Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class TributacaoNotaFiscal

    Private _id_situacao As Int32
    Private _id_tributacao_nf As Int32
    Private _nm_tributacao_nf As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_tributacao_nf() As Int32
        Get
            Return _id_tributacao_nf
        End Get
        Set(ByVal value As Int32)
            _id_tributacao_nf = value
        End Set
    End Property

    Public Property nm_tributacao_nf() As String
        Get
            Return _nm_tributacao_nf
        End Get
        Set(ByVal value As String)
            _nm_tributacao_nf = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_tributacao_nf = id
        loadTributacaoNF()

    End Sub

    Public Sub New()

    End Sub

    Public Function getTributacoesNotasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTributacoesNotas", parameters, "ms_ztributacao_nf")
            Return dataSet

        End Using

    End Function

    Private Sub loadTributacaoNF()

        Dim dataSet As DataSet = getTributacoesNotasByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
