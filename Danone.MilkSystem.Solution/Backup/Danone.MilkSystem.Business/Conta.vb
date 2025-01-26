Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Conta

    Private _id_conta As Int32
    Private _cd_conta As String
    Private _nm_conta As String
    Private _id_natureza As Int32
    Private _st_qtd_valor As String
    Private _st_sistema As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _st_visualizar As String
    Private _nr_ordem As Int32
    Private _st_clube_compra As String  ' 27/05/2009 - Chamado 275 -  Emitir Nota Fiscal (ctas da Central e Educampo) - Rls 17.7
    Private _cd_conta_contabil As String    ' 15/09/2009 - Rls 20


    Public Property id_conta() As Int32
        Get
            Return _id_conta
        End Get
        Set(ByVal value As Int32)
            _id_conta = value
        End Set
    End Property

    Public Property cd_conta() As String
        Get
            Return _cd_conta
        End Get
        Set(ByVal value As String)
            _cd_conta = value
        End Set
    End Property


    Public Property nm_conta() As String
        Get
            Return _nm_conta
        End Get
        Set(ByVal value As String)
            _nm_conta = value
        End Set
    End Property


    Public Property id_natureza() As Int32
        Get
            Return _id_natureza
        End Get
        Set(ByVal value As Int32)
            _id_natureza = value
        End Set
    End Property

    Public Property st_qtd_valor() As String
        Get
            Return _st_qtd_valor
        End Get
        Set(ByVal value As String)
            _st_qtd_valor = value
        End Set
    End Property
    Public Property st_sistema() As String
        Get
            Return _st_sistema
        End Get
        Set(ByVal value As String)
            _st_sistema = value
        End Set
    End Property

    Public Property st_visualizar() As String
        Get
            Return _st_visualizar
        End Get
        Set(ByVal value As String)
            _st_visualizar = value
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

    Public Property nr_ordem() As Int32
        Get
            Return _nr_ordem
        End Get
        Set(ByVal value As Int32)
            _nr_ordem = value
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
    Public Property st_clube_compra() As String
        Get
            Return _st_clube_compra
        End Get
        Set(ByVal value As String)
            _st_clube_compra = value
        End Set
    End Property
    Public Property cd_conta_contabil() As String
        Get
            Return _cd_conta_contabil
        End Get
        Set(ByVal value As String)
            _cd_conta_contabil = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me._id_conta = id
        loadConta()

    End Sub



    Public Sub New()

    End Sub


    Public Function getContaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContas", parameters, "ms_conta")
            Return dataSet

        End Using

    End Function
    Public Function getContaLancamentoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContasLancamentos", parameters, "ms_conta")
            Return dataSet

        End Using

    End Function

    Private Sub loadConta()

        Dim dataSet As DataSet = getContaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertConta() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertContas", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateConta()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateContas", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteConta()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteContas", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
