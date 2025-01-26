Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ColetaAmostraManual
    Private _id_coleta_amostra_manual As Int32
    Private _id_estabelecimento As Int32
    Private _dt_referencia As String
    Private _id_tipo_coleta_analise_esalq As Int32
    Private _dt_ini_amostra As String
    Private _dt_fim_amostra As String
    Private _id_pessoa As Int32
    Private _id_propriedade As Int32
    Private _id_unid_producao As Int32
    Private _id_propriedade_matriz As Int32
    Private _nm_propriedade As String
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _ds_login As String
    Private _id_situacao_coleta_amostra_manual As Int32

    Public Property id_coleta_amostra_manual() As Int32
        Get
            Return _id_coleta_amostra_manual
        End Get
        Set(ByVal value As Int32)
            _id_coleta_amostra_manual = value
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

    Public Property id_tipo_coleta_analise_esalq() As Int32
        Get
            Return _id_tipo_coleta_analise_esalq
        End Get
        Set(ByVal value As Int32)
            _id_tipo_coleta_analise_esalq = value
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
  
    Public Property id_propriedade_matriz() As Int32
        Get
            Return _id_propriedade_matriz
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_matriz = value
        End Set
    End Property
    Public Property nm_propriedade() As String
        Get
            Return _nm_propriedade
        End Get
        Set(ByVal value As String)
            _nm_propriedade = value
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
    Public Property id_situacao_coleta_amostra_manual() As Int32
        Get
            Return _id_situacao_coleta_amostra_manual
        End Get
        Set(ByVal value As Int32)
            _id_situacao_coleta_amostra_manual = value
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
    Public Property ds_login() As String
        Get
            Return _ds_login
        End Get
        Set(ByVal value As String)
            _ds_login = value
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
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)
        Me.id_coleta_amostra_manual = id
        loadColetaAmostraManual()
    End Sub

    Public Sub New()

    End Sub


    Public Function getColetaAmostraManual() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostraManual", parameters, "ms_coleta_amostra_manual")
            Return dataSet

        End Using

    End Function


    Public Function getColetaAmostraManualbyPeriodo() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostraManualbyPeriodo", parameters, "ms_coleta_amostra_manual")
            Return dataSet

        End Using

    End Function
    Public Function getColetaAmostraManualDados() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostraManualDados", parameters, "ms_coleta_amostra_manual")
            Return dataSet

        End Using

    End Function
    Private Sub loadColetaAmostraManual()

        Dim dataSet As DataSet = getColetaAmostraManual()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updateColetaAmostraManual()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetaAmostraManual", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub updateColetaAmostraManualCancelar()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetaAmostraManualCancelar", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Function insertColetaAmostraManual() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertColetaAmostraManual", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub deleteColetaAmostraManual()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteColetaAmostraManual", parameters, ExecuteType.Delete)

        End Using


    End Sub
End Class
