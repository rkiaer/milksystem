Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ColetaAmostraPeriodo
    Private _id_coleta_amostra_periodo As Int32
    Private _id_estabelecimento As Int32
    Private _dt_referencia As String
    Private _id_tipo_coleta_analise_esalq As Int32
    Private _dt_ini_amostra As String
    Private _dt_fim_amostra As String
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String

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
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)
        Me.id_coleta_amostra_periodo = id
        loadColetaAmostraPeriodo()
    End Sub

    Public Sub New()

    End Sub


    Public Function getColetaAmostraPeriodo() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostraPeriodo", parameters, "ms_coleta_amostra_periodo")
            Return dataSet

        End Using

    End Function
    Private Sub loadColetaAmostraPeriodo()

        Dim dataSet As DataSet = getColetaAmostraPeriodo()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updateColetaAmostraPeriodo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetaAmostraPeriodo", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function insertColetaAmostraPeriodo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertColetaAmostraPeriodo", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function insertColetaAmostraPeriodoCopiarReferencia() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertColetaAmostraPeriodoCopiarReferencia", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    'Public Function getColetaUltimaRotaCarregada() As DataSet

    '    Using data As New DataAccess
    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

    '        Dim dataSet As New DataSet
    '        data.Fill(dataSet, "ms_getColetaUltimaRotaCarregada", parameters, "ms_coletas")
    '        Return dataSet

    '    End Using

    'End Function

    Public Sub deleteColetaAmostraPeriodo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteColetaAmostraPeriodo", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub deleteColetaAmostraPeriodoTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteColetaAmostraPeriodoTodos", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Function getColetaAmostraPeriodoFiltro() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostraPeriodoFiltro", parameters, "ms_coleta_amostra_periodo")
            Return dataSet

        End Using

    End Function
    Public Function getColetaAmostraPeriodobyPeriodo() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostraPeriodobyPeriodo", parameters, "ms_coleta_amostra_periodo")
            Return dataSet

        End Using

    End Function
    Public Function getColetaAmostraPeriodoMaiorReferencia() As String
        Using data As New DataAccess

            'Busca da ficha o ultimo calco de poupanca mensal realizado
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getColetaAmostraPeriodoMaiorReferencia", parameters, ExecuteType.Select), String)

        End Using

    End Function
End Class
