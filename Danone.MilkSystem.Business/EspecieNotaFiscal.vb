Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class EspecieNotaFiscal

    Private _id_situacao As Int32
    Private _id_especie_nf As Int32
    Private _nm_especie_nf As String

    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_especie_nf() As Int32
        Get
            Return _id_especie_nf
        End Get
        Set(ByVal value As Int32)
            _id_especie_nf = value
        End Set
    End Property

    Public Property nm_especie_nf() As String
        Get
            Return _nm_especie_nf
        End Get
        Set(ByVal value As String)
            _nm_especie_nf = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_especie_nf = id
        loadEspecieNF()

    End Sub

    Public Sub New()

    End Sub

    Public Function getEspeciesNotasFiscaisByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getEspeciesNotasFiscais", parameters, "ms_zespecie_nf")
            Return dataSet

        End Using

    End Function

    Private Sub loadEspecieNF()

        Dim dataSet As DataSet = getEspeciesNotasFiscaisByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
