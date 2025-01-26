Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class LinhaAtividades

    ' adri 21/08/2016 - chamado 2474 - importação Axiodis
    Private _id_Linha As Int32
    Private _id_Linhaatividades As Int32

    Private _atividade As String
    Private _sitio As String
    Private _litros As String
    Private _tecnico As String
    Private _inicio As String
    Private _fim As String
    Private _duracao As String
    Private _tempo As String
    Private _kmtotal As String
    Private _rota As String
    Private _veiculo As String
    Private _kmcumul As String
    Private _coordenaday As String
    Private _coordenadax As String
    Private _descricaositio As String
    Private _descricaolongasitio As String

    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _nr_seq_coleta As Int32


    Public Property id_linha() As Int32
        Get
            Return _id_Linha
        End Get
        Set(ByVal value As Int32)
            _id_Linha = value
        End Set
    End Property
    Public Property id_Linhaatividades() As Int32
        Get
            Return _id_Linhaatividades
        End Get
        Set(ByVal value As Int32)
            _id_Linhaatividades = value
        End Set
    End Property
    Public Property atividade() As String
        Get
            Return _atividade
        End Get
        Set(ByVal value As String)
            _atividade = value
        End Set
    End Property
    Public Property sitio() As String
        Get
            Return _sitio
        End Get
        Set(ByVal value As String)
            _sitio = value
        End Set
    End Property
    Public Property litros() As String
        Get
            Return _litros
        End Get
        Set(ByVal value As String)
            _litros = value
        End Set
    End Property

    Public Property tecnico() As String
        Get
            Return _tecnico
        End Get
        Set(ByVal value As String)
            _tecnico = value
        End Set
    End Property

    Public Property inicio() As String
        Get
            Return _inicio
        End Get
        Set(ByVal value As String)
            _inicio = value
        End Set
    End Property
    Public Property fim() As String
        Get
            Return _fim
        End Get
        Set(ByVal value As String)
            _fim = value
        End Set
    End Property
    Public Property duracao() As String
        Get
            Return _duracao
        End Get
        Set(ByVal value As String)
            _duracao = value
        End Set
    End Property
    Public Property tempo() As String
        Get
            Return _tempo
        End Get
        Set(ByVal value As String)
            _tempo = value
        End Set
    End Property
    Public Property kmtotal() As String
        Get
            Return _kmtotal
        End Get
        Set(ByVal value As String)
            _kmtotal = value
        End Set
    End Property
    Public Property rota() As String
        Get
            Return _rota
        End Get
        Set(ByVal value As String)
            _rota = value
        End Set
    End Property
    Public Property veiculo() As String
        Get
            Return _veiculo
        End Get
        Set(ByVal value As String)
            _veiculo = value
        End Set
    End Property
    Public Property kmcumul() As String
        Get
            Return _kmcumul
        End Get
        Set(ByVal value As String)
            _kmcumul = value
        End Set
    End Property
    Public Property coordenaday() As String
        Get
            Return _coordenaday
        End Get
        Set(ByVal value As String)
            _coordenaday = value
        End Set
    End Property
    Public Property coordenadax() As String
        Get
            Return _coordenadax
        End Get
        Set(ByVal value As String)
            _coordenadax = value
        End Set
    End Property
    Public Property descricaositio() As String
        Get
            Return _descricaositio
        End Get
        Set(ByVal value As String)
            _descricaositio = value
        End Set
    End Property
    Public Property descricaolongasitio() As String
        Get
            Return _descricaolongasitio
        End Get
        Set(ByVal value As String)
            _descricaolongasitio = value
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

    Public Sub New()

    End Sub


    Public Function getLinhaAtividadesByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getLinhasAtividades", parameters, "ms_linha_atividades")
            Return dataSet

        End Using

    End Function

    Public Function insertLinhaAtividades() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertLinhasAtividades", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub deleteLinhaAtividades()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteLinhasAtividades", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class