Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class ParametroAntecipacao

    Private _id_parametro_antecipacao As Int32
    Private _nr_dias_antecipacao As Int32
    Private _ds_referencia As String
    Private _dt_referencia As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _id_criacao As Int32
    Private _dt_modificacao As String
    Private _dt_criacao As String
    Public Property id_parametro_antecipacao() As Int32
        Get
            Return _id_parametro_antecipacao
        End Get
        Set(ByVal value As Int32)
            _id_parametro_antecipacao = value
        End Set
    End Property
    Public Property nr_dias_antecipacao() As Int32
        Get
            Return _nr_dias_antecipacao
        End Get
        Set(ByVal value As Int32)
            _nr_dias_antecipacao = value
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
    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
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
    Public Property ds_referencia() As String
        Get
            Return _ds_referencia
        End Get
        Set(ByVal value As String)
            _ds_referencia = value
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

        Me.id_parametro_antecipacao = id
        loadParametroAntecipacao()

    End Sub

    Public Sub New()

    End Sub

    Public Function getParametroAntecipacaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getParametroAntecipacao", parameters, "ms_parametro_antecipacao")
            Return dataSet

        End Using

    End Function

    Private Sub loadParametroAntecipacao()

        Dim dataSet As DataSet = getParametroAntecipacaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertParametroAntecipacao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertParametroAntecipacao", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Sub updateParametroAntecipacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateParametroAntecipacao", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Function getParametroAntecipacaoConsReferencia() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getParametroAntecipacaoConsReferencia", parameters, "ms_parametro_antecipacao")
            Return dataSet

        End Using
    End Function

End Class
