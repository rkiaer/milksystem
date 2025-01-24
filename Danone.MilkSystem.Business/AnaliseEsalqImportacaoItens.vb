Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

' Adri 06/06/2016 - chamado 2441 - Classe para tabelas espelho dos arquivos

<Serializable()> Public Class AnaliseEsalqImportacaoItens

    Public Sub New()

    End Sub

    Private _id_importacao As Int32

    Private _cd_cooperativa As String
    Private _id_propriedade As String
    Private _id_unid_producao As String
    Private _cd_rota As String
    Private _nm_rota As String
    Private _dt_coleta As String
    Private _dt_processamento As String
    Private _dt_analise As String
    Private _cd_analise_esalq As String
    Private _nr_valor_esalq As String
    Private _cd_protocolo As String
    Private _id_modificador As Int32


    Public Property id_importacao() As Int32
        Get
            Return _id_importacao
        End Get
        Set(ByVal value As Int32)
            _id_importacao = value
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
    Public Property id_propriedade() As String
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As String)
            _id_propriedade = value
        End Set
    End Property
    Public Property id_unid_producao() As String
        Get
            Return _id_unid_producao
        End Get
        Set(ByVal value As String)
            _id_unid_producao = value
        End Set
    End Property
    Public Property cd_rota() As String
        Get
            Return _cd_rota
        End Get
        Set(ByVal value As String)
            _cd_rota = value
        End Set
    End Property
    Public Property nm_rota() As String
        Get
            Return _nm_rota
        End Get
        Set(ByVal value As String)
            _nm_rota = value
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
    Public Property cd_protocolo() As String
        Get
            Return _cd_protocolo
        End Get
        Set(ByVal value As String)
            _cd_protocolo = value
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


    Public Function insertAnaliseEsalqImportacaoItens() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAnaliseEsalqImportacaoItens", parameters, ExecuteType.Insert), Int32)

        End Using

    End Function

End Class
