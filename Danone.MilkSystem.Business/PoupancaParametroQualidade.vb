Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PoupancaParametroQualidade

    Private _id_poupanca_parametro_qualidade As Int32
    Private _id_poupanca_parametro As Int32
    Private _dt_referencia_ini As String
    Private _dt_referencia_fim As String
    Private _st_rejeicao_antibiotico As String
    Private _st_analises_romaneio As String
    Private _id_categoria As Int32
    Private _nr_faixa_inicio As Decimal
    Private _nr_faixa_fim As Decimal
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Public Property id_poupanca_parametro_qualidade() As Int32
        Get
            Return _id_poupanca_parametro_qualidade
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_parametro_qualidade = value
        End Set
    End Property
    Public Property id_poupanca_parametro() As Int32
        Get
            Return _id_poupanca_parametro
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_parametro = value
        End Set
    End Property
    Public Property dt_referencia_ini() As String
        Get
            Return _dt_referencia_ini
        End Get
        Set(ByVal value As String)
            _dt_referencia_ini = value
        End Set
    End Property

    Public Property dt_referencia_fim() As String
        Get
            Return _dt_referencia_fim
        End Get
        Set(ByVal value As String)
            _dt_referencia_fim = value
        End Set
    End Property
    Public Property st_rejeicao_antibiotico() As String
        Get
            Return _st_rejeicao_antibiotico
        End Get
        Set(ByVal value As String)
            _st_rejeicao_antibiotico = value
        End Set
    End Property
    Public Property st_analises_romaneio() As String
        Get
            Return _st_analises_romaneio
        End Get
        Set(ByVal value As String)
            _st_analises_romaneio = value
        End Set
    End Property
    Public Property id_categoria() As Int32
        Get
            Return _id_categoria
        End Get
        Set(ByVal value As Int32)
            _id_categoria = value
        End Set
    End Property

    Public Property nr_faixa_inicio() As Decimal
        Get
            Return _nr_faixa_inicio
        End Get
        Set(ByVal value As Decimal)
            _nr_faixa_inicio = value
        End Set
    End Property
    Public Property nr_faixa_fim() As Decimal
        Get
            Return _nr_faixa_fim
        End Get
        Set(ByVal value As Decimal)
            _nr_faixa_fim = value
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

    Public Sub New(ByVal id As Int32)
        Me.id_poupanca_parametro_qualidade = id
        loadPoupancaParametroQualidade()
    End Sub

    Public Sub New()
  
    End Sub


    Public Function getPoupancaParametroQualidade() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaParametroQualidade", parameters, "ms_poupanca_parametro_qualidade")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaParametroQualidadeConsInclusao() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaParametroQualidadeConsInclusao", parameters, "ms_poupanca_parametro_qualidade")
            Return dataSet

        End Using

    End Function
   
    Private Sub loadPoupancaParametroQualidade()

        Dim dataSet As DataSet = getPoupancaParametroQualidade()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updatePoupancaParametroQualidade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaParametroQualidade", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function insertPoupancaParametroQualidade() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPoupancaParametroQualidade", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub deletePoupancaParametroQualidade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deletePoupancaParametroQualidade", parameters, ExecuteType.Delete)

        End Using


    End Sub
End Class
