Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ColetaAmostra

    Private _id_coleta_amostra As Int32
    Private _id_coleta As Int32
    Private _id_estabelecimento As Int32
    Private _id_propriedade As Int32
    Private _id_unid_producao As Int32
    Private _id_propriedade_matriz As Int32
    Private _id_coleta_amostra_periodo As Int32
    Private _id_coleta_amostra_manual As Int32
    Private _id_coleta_amostra_frasco As Int32
    Private _ds_descricao_frasco As String
    Private _ds_cd_protocolo_esalq As String
    Private _id_tipo_coleta_analise_esalq As Int32
    Private _id_currentidentity As Int32
    Private _id_situacao_coleta_amostra As Int32
    Private _id_motivo_nao_coleta_amostra As Int32
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_tipo_frasco As Int32
    Private _id_situacao_romaneio_amostra As Int32
    Private _id_motivo_descarte_romaneio_amostra As Int32

    'filtros
    Private _id_pessoa As Int32
    Private _dt_referencia As String
    Private _dt_ini_amostra As String
    Private _dt_fim_amostra As String
    Private _nm_linha As String
    Private _id_situacao_coleta As Int32
    Private _st_coleta_amostra_manual As String

    Public Property id_coleta_amostra() As Int32
        Get
            Return _id_coleta_amostra
        End Get
        Set(ByVal value As Int32)
            _id_coleta_amostra = value
        End Set
    End Property
    Public Property id_coleta() As Int32
        Get
            Return _id_coleta
        End Get
        Set(ByVal value As Int32)
            _id_coleta = value
        End Set
    End Property
    Public Property id_coleta_amostra_periodo() As Int32
        Get
            Return _id_coleta_amostra_periodo
        End Get
        Set(ByVal value As Int32)
            _id_coleta_amostra_periodo = value
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
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
        End Set
    End Property
    Public Property id_propriedade_matriz() As Int32
        Get
            Return _id_propriedade_matriz
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_matriz = value
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
    Public Property id_coleta_amostra_manual() As Int32
        Get
            Return _id_coleta_amostra_manual
        End Get
        Set(ByVal value As Int32)
            _id_coleta_amostra_manual = value
        End Set
    End Property
    Public Property id_coleta_amostra_frasco() As Int32
        Get
            Return _id_coleta_amostra_frasco
        End Get
        Set(ByVal value As Int32)
            _id_coleta_amostra_frasco = value
        End Set
    End Property
    Public Property ds_descricao_frasco() As String
        Get
            Return _ds_descricao_frasco
        End Get
        Set(ByVal value As String)
            _ds_descricao_frasco = value
        End Set
    End Property
    Public Property ds_cd_protocolo_esalq() As String
        Get
            Return _ds_cd_protocolo_esalq
        End Get
        Set(ByVal value As String)
            _ds_cd_protocolo_esalq = value
        End Set
    End Property
    Public Property id_tipo_coleta_analise_esalq() As Int32
        Get
            Return _id_tipo_coleta_analise_esalq
        End Get
        Set(ByVal value As Int32)
            _id_tipo_coleta_analise_esalq = value
        End Set
    End Property
    Public Property id_currentidentity() As Int32
        Get
            Return _id_currentidentity
        End Get
        Set(ByVal value As Int32)
            _id_currentidentity = value
        End Set
    End Property
    Public Property id_situacao_coleta_amostra() As Int32
        Get
            Return _id_situacao_coleta_amostra
        End Get
        Set(ByVal value As Int32)
            _id_situacao_coleta_amostra = value
        End Set
    End Property
    Public Property id_motivo_nao_coleta_amostra() As Int32
        Get
            Return _id_motivo_nao_coleta_amostra
        End Get
        Set(ByVal value As Int32)
            _id_motivo_nao_coleta_amostra = value
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
    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
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
    Public Property dt_criacao() As String
        Get
            Return _dt_criacao
        End Get
        Set(ByVal value As String)
            _dt_criacao = value
        End Set
    End Property

    Public Property id_pessoa() As Int32
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
        End Set
    End Property
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property
    Public Property dt_ini_amostra() As String
        Get
            Return _dt_ini_amostra
        End Get
        Set(ByVal value As String)
            _dt_ini_amostra = value
        End Set
    End Property
    Public Property dt_fim_amostra() As String
        Get
            Return _dt_fim_amostra
        End Get
        Set(ByVal value As String)
            _dt_fim_amostra = value
        End Set
    End Property
    Public Property nm_linha() As String
        Get
            Return _nm_linha
        End Get
        Set(ByVal value As String)
            _nm_linha = value
        End Set
    End Property
    Public Property id_situacao_coleta() As Int32
        Get
            Return _id_situacao_coleta
        End Get
        Set(ByVal value As Int32)
            _id_situacao_coleta = value
        End Set
    End Property
    Public Property st_coleta_amostra_manual() As String
        Get
            Return _st_coleta_amostra_manual
        End Get
        Set(ByVal value As String)
            _st_coleta_amostra_manual = value
        End Set
    End Property
    Public Property id_tipo_frasco() As Int32
        Get
            Return _id_tipo_frasco
        End Get
        Set(ByVal value As Int32)
            _id_tipo_frasco = value
        End Set
    End Property
    Public Property id_situacao_romaneio_amostra() As Int32
        Get
            Return _id_situacao_romaneio_amostra
        End Get
        Set(ByVal value As Int32)
            _id_situacao_romaneio_amostra = value
        End Set
    End Property
    Public Property id_motivo_descarte_romaneio_amostra() As Int32
        Get
            Return _id_motivo_descarte_romaneio_amostra
        End Get
        Set(ByVal value As Int32)
            _id_motivo_descarte_romaneio_amostra = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)
        Me.id_coleta_amostra = id
        loadColetaAmostra()
    End Sub

    Public Sub New()

    End Sub
    Public Function getColetaAmostrabyFilters() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostrabyFilters", parameters, "ms_coleta_amostra")
            Return dataSet

        End Using

    End Function
    Public Function getColetaAmostraProdutores() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostraProdutores", parameters, "ms_coleta_amostra")
            Return dataSet

        End Using

    End Function
    Public Function getColetaAmostra() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostra", parameters, "ms_coleta_amostra")
            Return dataSet

        End Using

    End Function
    Private Sub loadColetaAmostra()

        Dim dataSet As DataSet = getColetaAmostrabyFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function getColetaUltimaRotaCarregada() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaUltimaRotaCarregada", parameters, "ms_coletas")
            Return dataSet

        End Using

    End Function
    Public Function getColetaUltimaRotaCarregadaPropriedade() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaUltimaRotaCarregadaPropriedade", parameters, "ms_coletas")
            Return dataSet

        End Using

    End Function
    Public Function getColetaAmostraDadosbyColetaManual() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostraDadosbyColetaManual", parameters, "ms_coleta_amostra")
            Return dataSet

        End Using

    End Function
    Public Sub updateColetaAmostraDescarteRomaneio()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetaAmostraDescarteRomaneio", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateColetaAmostraDescarteTransitPoint()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetaAmostraDescarteTransitPoint", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateColetaAmostraDescarteTransvase()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetaAmostraDescarteTransvase", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateColetaAmostraRecepcaoRomaneio()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetaAmostraRecepcaoRomaneio", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateColetaAmostraRecepcaoRomaneiobyProtocolo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetaAmostraRecepcaoRomaneiobyProtocolo", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateColetaAmostraProtocolo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetaAmostraProtocolo", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
