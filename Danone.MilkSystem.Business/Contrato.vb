Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Contrato

    Private _id_contrato As Int32
    Private _id_estabelecimento As Int32
    Private _cd_contrato As String
    Private _nm_contrato As String
    Private _st_contrato_comercial As String
    Private _st_contrato_mercado As String
    Private _id_cluster As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_contrato_validade As Int32
    Private _id_situacao_contrato_validade As Int32
    Private _id_situacao_contrato As Int32
    Private _st_referencia_vigente As String
    Private _dt_referencia As String
    Private _dt_referencia_inicio As String

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property id_contrato() As Int32
        Get
            Return _id_contrato
        End Get
        Set(ByVal value As Int32)
            _id_contrato = value
        End Set
    End Property
    Public Property nm_contrato() As String
        Get
            Return _nm_contrato
        End Get
        Set(ByVal value As String)
            _nm_contrato = value
        End Set
    End Property
    Public Property cd_contrato() As String
        Get
            Return _cd_contrato
        End Get
        Set(ByVal value As String)
            _cd_contrato = value
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
    Public Property st_contrato_comercial() As String
        Get
            Return _st_contrato_comercial
        End Get
        Set(ByVal value As String)
            _st_contrato_comercial = value
        End Set
    End Property
    Public Property id_contrato_validade() As Int32
        Get
            Return _id_contrato_validade
        End Get
        Set(ByVal value As Int32)
            _id_contrato_validade = value
        End Set
    End Property
    Public Property id_situacao_contrato_validade() As Int32
        Get
            Return _id_situacao_contrato_validade
        End Get
        Set(ByVal value As Int32)
            _id_situacao_contrato_validade = value
        End Set
    End Property
    Public Property id_cluster() As Int32
        Get
            Return _id_cluster
        End Get
        Set(ByVal value As Int32)
            _id_cluster = value
        End Set
    End Property
    Public Property id_situacao_contrato() As Int32
        Get
            Return _id_situacao_contrato
        End Get
        Set(ByVal value As Int32)
            _id_situacao_contrato = value
        End Set
    End Property
    Public Property st_referencia_vigente() As String
        Get
            Return _st_referencia_vigente
        End Get
        Set(ByVal value As String)
            _st_referencia_vigente = value
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
    Public Property dt_referencia_inicio() As String
        Get
            Return _dt_referencia_inicio
        End Get
        Set(ByVal value As String)
            _dt_referencia_inicio = value
        End Set
    End Property
    Public Property st_contrato_mercado() As String
        Get
            Return _st_contrato_mercado
        End Get
        Set(ByVal value As String)
            _st_contrato_mercado = value
        End Set
    End Property



    Public Sub New(ByVal id As Int32)

        Me._id_contrato = id
        loadContrato()

    End Sub

    Public Sub New()

    End Sub

    Public Function getContratoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContrato", parameters, "ms_contrato")
            Return dataSet

        End Using

    End Function

    Public Function getContratoSuasValidades() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContratoSuasValidades", parameters, "ms_contrato")
            Return dataSet

        End Using

    End Function
    Public Function getContratoConsValidade() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContratoConsValidade", parameters, "ms_contrato_validade")
            Return dataSet

        End Using

    End Function
    Private Sub loadContrato()

        Dim dataSet As DataSet = getContratoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertContrato() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertContrato", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateContrato()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para atualizacao 
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            transacao.Execute("ms_updateContrato", parameters, ExecuteType.Update)

            'se contrato tipo mercado, desativa tudo de adicional de volume se tinha antes
            If Me.st_contrato_mercado.Equals("S") Then
                transacao.Execute("ms_updateContratoAdicionalVolumeDesativar", parameters, ExecuteType.Insert)
            End If

            'Comita
            transacao.Commit()
            transacao.Dispose()

        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try

    End Sub

    Public Sub deleteContrato()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteContrato", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
