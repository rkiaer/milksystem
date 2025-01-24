Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ColetaAmostraFrasco
    Private _id_coleta_amostra_frasco As Int32
    Private _id_estabelecimento As Int32
    Private _dt_validade As String
    Private _id_tipo_frasco As Int32
    Private _ds_descricao_frasco As String
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_coleta_amostra_frasco() As Int32
        Get
            Return _id_coleta_amostra_frasco
        End Get
        Set(ByVal value As Int32)
            _id_coleta_amostra_frasco = value
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
    Public Property ds_descricao_frasco() As String
        Get
            Return _ds_descricao_frasco
        End Get
        Set(ByVal value As String)
            _ds_descricao_frasco = value
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
    Public Property dt_validade() As String
        Get
            Return _dt_validade
        End Get
        Set(ByVal value As String)
            _dt_validade = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)
        Me.id_coleta_amostra_frasco = id
        loadColetaAmostraFrasco()
    End Sub

    Public Sub New()

    End Sub


    Public Function getColetaAmostraFrasco() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostraFrasco", parameters, "ms_coleta_amostra_frasco")
            Return dataSet

        End Using

    End Function
    Private Sub loadColetaAmostraFrasco()

        Dim dataSet As DataSet = getColetaAmostraFrasco()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updateColetaAmostraFrasco()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateColetaAmostraFrasco", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Function insertColetaAmostraFrasco() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertColetaAmostraFrasco", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
 

    Public Sub deleteColetaAmostraFrasco()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteColetaAmostraFrasco", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub deleteColetaAmostraFrascoTodos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteColetaAmostraFrascoTodos", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Function getColetaAmostraFrascoMaiorReferencia() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getColetaAmostraFrascoMaiorReferencia", parameters, ExecuteType.Select), String)

        End Using

    End Function
    Public Function getColetaAmostraFrascoCadastro() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostraFrascoCadastro", parameters, "ms_coleta_amostra_frasco")
            Return dataSet

        End Using

    End Function
    Public Function getColetaAmostraFrascoFiltro() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getColetaAmostraFrascoFiltro", parameters, "ms_coleta_amostra_frasco")
            Return dataSet

        End Using

    End Function
End Class
