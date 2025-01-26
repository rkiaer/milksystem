Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class AnaliseLogica

    Private _id_analise_logica As Int32
    Private _nm_analise_logica As String
    Private _id_grupo_descricao As Int32 'Fran 21/08/2009 chamado rls 18

    Public Property id_grupo_descricao() As Int32
        Get
            Return _id_grupo_descricao
        End Get
        Set(ByVal value As Int32)
            _id_grupo_descricao = value
        End Set
    End Property

    Public Property id_analise_logica() As Int32
        Get
            Return _id_analise_logica
        End Get
        Set(ByVal value As Int32)
            _id_analise_logica = value
        End Set
    End Property

    Public Property nm_analise_logica() As String
        Get
            Return _nm_analise_logica
        End Get
        Set(ByVal value As String)
            _nm_analise_logica = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_analise_logica = id
        loadAnaliseLogica()

    End Sub

    Public Sub New()

    End Sub

    Public Function getAnalisesLogicasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesLogicas", parameters, "ms_zanalise_logica")
            Return dataSet

        End Using

    End Function

    Private Sub loadAnaliseLogica()

        Dim dataSet As DataSet = getAnalisesLogicasByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
