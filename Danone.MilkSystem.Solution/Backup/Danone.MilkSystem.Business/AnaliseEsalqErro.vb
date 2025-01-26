Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class AnaliseEsalqErro

    Private _id_analise_esalq_erro As Int32
    Private _id_propriedade As String
    Private _nr_unidade_producao As String
    Private _id_linha As String
    Private _nm_produtor As String
    Private _dt_coleta As String
    Private _dt_processamento As String
    Private _dt_analise As String
    Private _cd_analise_esalq As String
    Private _nr_valor_esalq As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_importacao_log As Int32
    Private _id_importacao As Int32
    Private _id_romaneio As String
    Private _cd_estabelecimento As String
    Private _cd_silo As String
    Private _nr_silo As Int32   ' 10/12/2008
    Private _cd_cooperativa As String
    Private _cd_protocolo As String
    Private _nr_nota_fiscal As String

    Public Property id_analise_esalq_erro() As Int32
        Get
            Return _id_analise_esalq_erro
        End Get
        Set(ByVal value As Int32)
            _id_analise_esalq_erro = value
        End Set
    End Property
    Public Property id_propriedade() As String
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As String)
            _id_propriedade = value
        End Set
    End Property
    Public Property cd_cooperativa() As String
        Get
            Return _cd_cooperativa
        End Get
        Set(ByVal value As String)
            _cd_cooperativa = value
        End Set
    End Property
    Public Property nr_nota_fiscal() As String
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As String)
            _nr_nota_fiscal = value
        End Set
    End Property
    Public Property nr_unidade_producao() As String
        Get
            Return _nr_unidade_producao
        End Get
        Set(ByVal value As String)
            _nr_unidade_producao = value
        End Set
    End Property
    Public Property id_linha() As String
        Get
            Return _id_linha
        End Get
        Set(ByVal value As String)
            _id_linha = value
        End Set
    End Property
    Public Property nm_produtor() As String
        Get
            Return _nm_produtor
        End Get
        Set(ByVal value As String)
            _nm_produtor = value
        End Set
    End Property
    Public Property dt_coleta() As String
        Get
            Return _dt_coleta
        End Get
        Set(ByVal value As String)
            _dt_coleta = value
        End Set
    End Property
    Public Property dt_processamento() As String
        Get
            Return _dt_processamento
        End Get
        Set(ByVal value As String)
            _dt_processamento = value
        End Set
    End Property
    Public Property dt_analise() As String
        Get
            Return _dt_analise
        End Get
        Set(ByVal value As String)
            _dt_analise = value
        End Set
    End Property
    Public Property cd_analise_esalq() As String
        Get
            Return _cd_analise_esalq
        End Get
        Set(ByVal value As String)
            _cd_analise_esalq = value
        End Set
    End Property
    Public Property nr_valor_esalq() As String
        Get
            Return _nr_valor_esalq
        End Get
        Set(ByVal value As String)
            _nr_valor_esalq = value
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
    Public Property id_importacao_log() As Int32
        Get
            Return _id_importacao_log
        End Get
        Set(ByVal value As Int32)
            _id_importacao_log = value
        End Set
    End Property
    Public Property id_importacao() As Int32
        Get
            Return _id_importacao
        End Get
        Set(ByVal value As Int32)
            _id_importacao = value
        End Set
    End Property
    Public Property id_romaneio() As String
        Get
            Return _id_romaneio
        End Get
        Set(ByVal value As String)
            _id_romaneio = value
        End Set
    End Property
    Public Property cd_estabelecimento() As String
        Get
            Return _cd_estabelecimento
        End Get
        Set(ByVal value As String)
            _cd_estabelecimento = value
        End Set
    End Property
    Public Property cd_protocolo() As String
        Get
            Return _cd_protocolo
        End Get
        Set(ByVal value As String)
            _cd_protocolo = value
        End Set
    End Property
    Public Property cd_silo() As String
        Get
            Return _cd_silo
        End Get
        Set(ByVal value As String)
            _cd_silo = value
        End Set
    End Property
    Public Property nr_silo() As Int32
        Get
            Return _nr_silo
        End Get
        Set(ByVal value As Int32)
            _nr_silo = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_analise_esalq_erro = id
        loadAnaliseEsalqErro()

    End Sub



    Public Sub New()

    End Sub


    Public Function getAnalisesEsalqErroByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalisesEsalqErro", parameters, "ms_analise_esalq_erro")
            Return dataSet

        End Using

    End Function

    Private Sub loadAnaliseEsalqErro()

        Dim dataSet As DataSet = getAnalisesEsalqErroByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertAnaliseEsalqErro() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAnalisesEsalqErro", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateAnaliseEsalqErro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalisesEsalqErro", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteAnaliseEsalqErro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteAnalisesEsalqErro", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
