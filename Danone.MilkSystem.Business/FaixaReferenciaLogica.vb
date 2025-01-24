Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class FaixaReferenciaLogica

    Private _id_faixa_referencia_logica As Int32
    Private _nm_faixa_referencia_logica As String
    Private _id_situacao As Int32
    Private _id_grupo_descricao As Int32 'Fran 21/08/2009 chamado rls 18

    Public Property id_faixa_referencia_logica() As Int32
        Get
            Return _id_faixa_referencia_logica
        End Get
        Set(ByVal value As Int32)
            _id_faixa_referencia_logica = value
        End Set
    End Property
    Public Property id_grupo_descricao() As Int32
        Get
            Return _id_grupo_descricao
        End Get
        Set(ByVal value As Int32)
            _id_grupo_descricao = value
        End Set
    End Property

    Public Property nm_faixa_referencia_logica() As String
        Get
            Return _nm_faixa_referencia_logica
        End Get
        Set(ByVal value As String)
            _nm_faixa_referencia_logica = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me.id_faixa_referencia_logica = id
        loadFaixaReferenciaLogica()

    End Sub

    Public Sub New()

    End Sub

    Public Function getFaixasReferenciaLogicaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFaixasReferenciaLogica", parameters, "ms_zfaixa_referencia_logica")
            Return dataSet

        End Using

    End Function

    Private Sub loadFaixaReferenciaLogica()

        Dim dataSet As DataSet = getFaixasReferenciaLogicaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
