Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class FretePeriodo
    Private _id_frete_periodo As Int32
    Private _id_estabelecimento As Int32
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _dt_referencia As String
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _st_calculo_definitivo As String
    Public Property id_frete_periodo() As Int32
        Get
            Return _id_frete_periodo
        End Get
        Set(ByVal value As Int32)
            _id_frete_periodo = value
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
    Public Property dt_inicio() As String
        Get
            Return _dt_inicio
        End Get
        Set(ByVal value As String)
            _dt_inicio = value
        End Set
    End Property
    Public Property dt_fim() As String
        Get
            Return _dt_fim
        End Get
        Set(ByVal value As String)
            _dt_fim = value
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
    Public Property st_calculo_definitivo() As String
        Get
            Return _st_calculo_definitivo
        End Get
        Set(ByVal value As String)
            _st_calculo_definitivo = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)
        Me.id_frete_periodo = id
        loadFretePeriodo()
    End Sub

    Public Sub New()

    End Sub

    Public Function getFretePeriodo() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getFretePeriodo", parameters, "ms_frete_periodo")
            Return dataSet

        End Using

    End Function
    Private Sub loadFretePeriodo()

        Dim dataSet As DataSet = getFretePeriodo()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertFretePeriodo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertFretePeriodo", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub deleteFretePeriodo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteFretePeriodo", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
