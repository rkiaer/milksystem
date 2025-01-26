Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class FreteNotaFiscal

    Private _id_situacao As Int32
    Private _id_frete_nf As Int32
    Private _nm_frete_nf As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_frete_nf() As Int32
        Get
            Return _id_frete_nf
        End Get
        Set(ByVal value As Int32)
            _id_frete_nf = value
        End Set
    End Property

    Public Property nm_frete_nf() As String
        Get
            Return _nm_frete_nf
        End Get
        Set(ByVal value As String)
            _nm_frete_nf = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_frete_nf = id
        loadFreteNF()

    End Sub

    Public Sub New()

    End Sub

    Public Function getFretesNotasFiscaisByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFretesNotasFiscais", parameters, "ms_zfrete_nf")
            Return dataSet

        End Using

    End Function

    Private Sub loadFreteNF()

        Dim dataSet As DataSet = getFretesNotasFiscaisByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
