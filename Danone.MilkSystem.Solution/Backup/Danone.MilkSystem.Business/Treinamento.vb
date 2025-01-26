Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Treinamento

    Private _id_treinamento As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nm_treinamento As String
    Private _nr_carga_horaria As Decimal
    Private _ds_pre_requisitos As String
    Private _ds_descricao As String

    Public Property id_treinamento() As Int32
        Get
            Return _id_treinamento
        End Get
        Set(ByVal value As Int32)
            _id_treinamento = value
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


    Public Property nm_treinamento() As String
        Get
            Return _nm_treinamento
        End Get
        Set(ByVal value As String)
            _nm_treinamento = value
        End Set
    End Property

    Public Property nr_carga_horaria() As Decimal
        Get
            Return _nr_carga_horaria
        End Get
        Set(ByVal value As Decimal)
            _nr_carga_horaria = value
        End Set
    End Property
    Public Property ds_pre_requisitos() As String
        Get
            Return _ds_pre_requisitos
        End Get
        Set(ByVal value As String)
            _ds_pre_requisitos = value
        End Set
    End Property
    Public Property ds_descricao() As String
        Get
            Return _ds_descricao
        End Get
        Set(ByVal value As String)
            _ds_descricao = value
        End Set
    End Property



    Public Sub New(ByVal id As Int32)

        Me.id_treinamento = id
        loadTreinamento()

    End Sub



    Public Sub New()

    End Sub


    Public Function getTreinamentoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTreinamentos", parameters, "ms_treinamento")
            Return dataSet

        End Using

    End Function

    Private Sub loadTreinamento()

        Dim dataSet As DataSet = getTreinamentoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertTreinamento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertTreinamentos", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateTreinamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateTreinamentos", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteTreinamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteTreinamentos", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
