Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class LinhaItens

    Private _id_Linha As Int32
    Private _id_linhaitens As Int32   ' adri 19/08/2016 - chamado 2474 - importação Axiodis
    Private _id_estabelecimento As Int32
    Private _dia_impar_par As String
    Private _dt_rota As String
    Private _nr_seq_coleta As Int32
    Private _cd_produtor As String
    Private _id_propriedade As Int32
    Private _id_unid_producao As Int32
    Private _nr_unid_producao As Int32
    Private _nr_dist_prim_produtor As Decimal
    Private _nr_dist_produtores As Decimal
    Private _nr_dist_ult_produtor As Decimal
    Private _nr_volume_leite As Decimal
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String


    Public Property id_linha() As Int32
        Get
            Return _id_Linha
        End Get
        Set(ByVal value As Int32)
            _id_Linha = value
        End Set
    End Property
    Public Property id_linhaitens() As Int32
        Get
            Return _id_linhaitens
        End Get
        Set(ByVal value As Int32)
            _id_linhaitens = value
        End Set
    End Property
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
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

    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
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

    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
        End Set
    End Property

    Public Property dia_impar_par() As String
        Get
            Return _dia_impar_par
        End Get
        Set(ByVal value As String)
            _dia_impar_par = value
        End Set
    End Property
    Public Property cd_produtor() As String
        Get
            Return _cd_produtor
        End Get
        Set(ByVal value As String)
            _cd_produtor = value
        End Set
    End Property
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
        End Set
    End Property
    Public Property id_unid_producao() As Int32
        Get
            Return _id_unid_producao
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao = value
        End Set
    End Property
    Public Property nr_unid_producao() As Int32
        Get
            Return _nr_unid_producao
        End Get
        Set(ByVal value As Int32)
            _nr_unid_producao = value
        End Set
    End Property

    Public Property nr_dist_prim_produtor() As Decimal
        Get
            Return _nr_dist_prim_produtor
        End Get
        Set(ByVal value As Decimal)
            _nr_dist_prim_produtor = value
        End Set
    End Property
    Public Property nr_dist_produtores() As Decimal
        Get
            Return _nr_dist_produtores
        End Get
        Set(ByVal value As Decimal)
            _nr_dist_produtores = value
        End Set
    End Property

    Public Property nr_dist_ult_produtor() As Decimal
        Get
            Return _nr_dist_ult_produtor
        End Get
        Set(ByVal value As Decimal)
            _nr_dist_ult_produtor = value
        End Set
    End Property

    Public Property nr_volume_leite() As Decimal
        Get
            Return _nr_volume_leite
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_leite = value
        End Set
    End Property

    Public Property nr_seq_coleta() As Int32
        Get
            Return _nr_seq_coleta
        End Get
        Set(ByVal value As Int32)
            _nr_seq_coleta = value
        End Set
    End Property
    Public Property dt_rota() As String
        Get
            Return _dt_rota
        End Get
        Set(ByVal value As String)
            _dt_rota = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_linha = id
        loadLinhaItens()

    End Sub



    Public Sub New()

    End Sub


    Public Function getLinhaItensByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhaItens", parameters, "ms_linha_itens")
            Return dataSet

        End Using

    End Function

    Private Sub loadLinhaItens()

        Dim dataSet As DataSet = getLinhaItensByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertLinhaItens() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertLinhasItens", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub deleteLinhaItens()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteLinhasItens", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class