Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PoupancaParametro
    Private _id_poupanca_parametro As Int32
    Private _id_estabelecimento As Int32
    Private _dt_referencia_ini As String
    Private _dt_referencia_fim As String
    Private _nr_bonus_1ano As Decimal
    Private _nr_bonus_2ano As Decimal
    Private _nr_bonus_3ano As Decimal
    Private _nr_spend_periodo As Decimal
    Private _nr_bonus_extra_1ano As Decimal
    Private _nr_bonus_extra_2ano As Decimal
    Private _nr_bonus_extra_3ano As Decimal
    Private _id_situacao_poupanca As Int32
    Private _nm_situacao_poupanca As String
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _situacao As String
    Private _dt_adesao_limite As String
    Private _dt_referencia As String
    Private _cd_produtor As String
    Private _id_propriedade_titular As Int32
    Private _nr_categoria As Int32



    Public Property id_poupanca_parametro() As Int32
        Get
            Return _id_poupanca_parametro
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_parametro = value
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

    Public Property nr_bonus_1ano() As Decimal
        Get
            Return _nr_bonus_1ano
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_1ano = value
        End Set
    End Property
    Public Property nr_bonus_2ano() As Decimal
        Get
            Return _nr_bonus_2ano
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_2ano = value
        End Set
    End Property
    Public Property nr_bonus_3ano() As Decimal
        Get
            Return _nr_bonus_3ano
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_3ano = value
        End Set
    End Property
    Public Property nr_spend_periodo() As Decimal
        Get
            Return _nr_spend_periodo
        End Get
        Set(ByVal value As Decimal)
            _nr_spend_periodo = value
        End Set
    End Property
    Public Property nr_bonus_extra_1ano() As Decimal
        Get
            Return _nr_bonus_extra_1ano
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_extra_1ano = value
        End Set
    End Property
    Public Property nr_bonus_extra_2ano() As Decimal
        Get
            Return _nr_bonus_extra_2ano
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_extra_2ano = value
        End Set
    End Property
    Public Property nr_bonus_extra_3ano() As Decimal
        Get
            Return _nr_bonus_extra_3ano
        End Get
        Set(ByVal value As Decimal)
            _nr_bonus_extra_3ano = value
        End Set
    End Property
    Public Property id_situacao_poupanca() As Int32
        Get
            Return _id_situacao_poupanca
        End Get
        Set(ByVal value As Int32)
            _id_situacao_poupanca = value
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
    Public Property dt_adesao_limite() As String
        Get
            Return _dt_adesao_limite
        End Get
        Set(ByVal value As String)
            _dt_adesao_limite = value
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
    Public Property nm_situacao_poupanca() As String
        Get
            Return _nm_situacao_poupanca
        End Get
        Set(ByVal value As String)
            _nm_situacao_poupanca = value
        End Set
    End Property
    Public Property situacao() As String
        Get
            Return _situacao
        End Get
        Set(ByVal value As String)
            _situacao = value
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
    Public Property id_propriedade_titular() As Int32
        Get
            Return _id_propriedade_titular
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_titular = value
        End Set
    End Property
    Public Property nr_categoria() As Int32
        Get
            Return _nr_categoria
        End Get
        Set(ByVal value As Int32)
            _nr_categoria = value
        End Set
    End Property
    Public Property cd_produtor() As String
        Get
            Return _cd_produtor
        End Get
        Set(ByVal value As String)
            _cd_produtor = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)
        Me.id_poupanca_parametro = id
        loadPoupancaParametro()
    End Sub

    Public Sub New()

    End Sub


    Public Function getPoupancaParametrobySituacao() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaParametrobySituacao", parameters, "ms_poupanca_parametro")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaParametro() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaParametro", parameters, "ms_poupanca_parametro")
            Return dataSet

        End Using

    End Function
    Private Sub loadPoupancaParametro()

        Dim dataSet As DataSet = getPoupancaParametro()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updatePoupancaParametro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaParametro", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updatePoupancaParametroBonusCentral()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePoupancaParametroBonusCentral", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function insertPoupancaParametro() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPoupancaParametro", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Function getPoupancaParametroConsInclusao() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaParametroConsInclusao", parameters, "ms_poupanca_parametro")
            Return dataSet

        End Using

    End Function

    Public Function getPoupancaMaisSolidosElegiveis() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaMaisSolidosElegiveis", parameters, "ms_poupanca_ficha")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaRelatorioMaisSolidos() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaRelatorioMaisSolidos", parameters, "ms_poupanca_ficha")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaCalculoMensalbyParametro() As Int64
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getPoupancaCalculoMensalbyParametro", parameters, ExecuteType.Select), Int64)

        End Using

    End Function
    Public Function getPoupancaParametroReferencia() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaParametroReferencia", parameters, "ms_poupanca_parametro_referencia")
            Return dataSet

        End Using

    End Function

    Public Sub deletePoupancaParametro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deletePoupancaParametro", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function getPoupancaManutencaoSite() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaManutencaoSite", parameters, "ms_poupanca_parametro")
            Return dataSet

        End Using

    End Function
    Public Function getPoupancaParametroAnexo() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaParametroAnexo", parameters, "ms_poupanca_parametro_anexo")
            Return dataSet
        End Using
    End Function

End Class
