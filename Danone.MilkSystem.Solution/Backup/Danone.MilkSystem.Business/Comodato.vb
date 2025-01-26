Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Comodato

    Private _id_comodato As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nm_comodato As String
    Private _nr_patrimonio As String
    Private _dt_aquisicao As String
    Private _dt_baixa As String
    Private _nm_fabricante As String
    Private _nm_modelo As String
    Private _nr_serie As String
    Private _nr_capacidade As Decimal
    Private _nr_qtde_ordenhas_dia As Int32
    Private _id_voltagem As Int32
    Private _nm_voltagem As String
    Private _id_proprietario As Int32
    Private _nm_proprietario As String
    Private _id_pessoa As Int32
    Private _st_alocado As String
    Private _nr_nota_fiscal As Int32
    Private _nr_serie_nota_fiscal As String
    Private _dt_emissao_nota_fiscal As String
    Private _nr_valor As Decimal
    Private _nr_contrato As String
    Private _nr_nota_fiscal_devolucao As Int32
    Private _dt_nota_fiscal_devolucao As String



    'Public Property id_tipobem() As Int32
    '    Get
    '        Return _id_tipobem
    '    End Get
    '    Set(ByVal value As Int32)
    '        _id_tipobem = value
    '    End Set
    'End Property

    'Public Property cd_comodato() As String
    '    Get
    '        Return _cd_comodato
    '    End Get
    '    Set(ByVal value As String)
    '        _cd_comodato = value
    '    End Set
    'End Property
    'Public Property dt_aquisicao() As String
    '    Get
    '        Return _dt_aquisicao
    '    End Get
    '    Set(ByVal value As String)
    '        _dt_aquisicao = value
    '    End Set
    'End Property
    'Public Property dt_baixa() As String
    '    Get
    '        Return _dt_baixa
    '    End Get
    '    Set(ByVal value As String)
    '        _dt_baixa = value
    '    End Set
    'End Property
    Public Property id_comodato() As Int32
        Get
            Return _id_comodato
        End Get
        Set(ByVal value As Int32)
            _id_comodato = value
        End Set
    End Property
    Public Property nm_comodato() As String
        Get
            Return _nm_comodato
        End Get
        Set(ByVal value As String)
            _nm_comodato = value
        End Set
    End Property
    Public Property nr_patrimonio() As String
        Get
            Return _nr_patrimonio
        End Get
        Set(ByVal value As String)
            _nr_patrimonio = value
        End Set
    End Property
    Public Property nm_fabricante() As String
        Get
            Return _nm_fabricante
        End Get
        Set(ByVal value As String)
            _nm_fabricante = value
        End Set
    End Property
    Public Property nm_modelo() As String
        Get
            Return _nm_modelo
        End Get
        Set(ByVal value As String)
            _nm_modelo = value
        End Set
    End Property
    Public Property nr_serie() As String
        Get
            Return _nr_serie
        End Get
        Set(ByVal value As String)
            _nr_serie = value
        End Set
    End Property
    Public Property nr_capacidade() As Decimal
        Get
            Return _nr_capacidade
        End Get
        Set(ByVal value As Decimal)
            _nr_capacidade = value
        End Set
    End Property
    Public Property nr_qtde_ordenhas_dia() As Int32
        Get
            Return _nr_qtde_ordenhas_dia
        End Get
        Set(ByVal value As Int32)
            _nr_qtde_ordenhas_dia = value
        End Set
    End Property
    Public Property id_voltagem() As Int32
        Get
            Return _id_voltagem
        End Get
        Set(ByVal value As Int32)
            _id_voltagem = value
        End Set
    End Property
    Public Property nm_voltagem() As String
        Get
            Return _nm_voltagem
        End Get
        Set(ByVal value As String)
            _nm_voltagem = value
        End Set
    End Property
    Public Property nr_nota_fiscal() As Int32
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As Int32)
            _nr_nota_fiscal = value
        End Set
    End Property
    Public Property nr_serie_nota_fiscal() As String
        Get
            Return _nr_serie_nota_fiscal
        End Get
        Set(ByVal value As String)
            _nr_serie_nota_fiscal = value
        End Set
    End Property
    Public Property dt_emissao_nota_fiscal() As String
        Get
            Return _dt_emissao_nota_fiscal
        End Get
        Set(ByVal value As String)
            _dt_emissao_nota_fiscal = value
        End Set
    End Property
    Public Property nr_valor() As Decimal
        Get
            Return _nr_valor
        End Get
        Set(ByVal value As Decimal)
            _nr_valor = value
        End Set
    End Property
    Public Property nr_nota_fiscal_devolucao() As Int32
        Get
            Return _nr_nota_fiscal_devolucao
        End Get
        Set(ByVal value As Int32)
            _nr_nota_fiscal_devolucao = value
        End Set
    End Property
    Public Property dt_nota_fiscal_devolucao() As String
        Get
            Return _dt_nota_fiscal_devolucao
        End Get
        Set(ByVal value As String)
            _dt_nota_fiscal_devolucao = value
        End Set
    End Property
    Public Property id_proprietario() As Int32
        Get
            Return _id_proprietario
        End Get
        Set(ByVal value As Int32)
            _id_proprietario = value
        End Set
    End Property
    Public Property nm_proprietario() As String
        Get
            Return _nm_proprietario
        End Get
        Set(ByVal value As String)
            _nm_proprietario = value
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
    Public Property nr_contrato() As String
        Get
            Return _nr_contrato
        End Get
        Set(ByVal value As String)
            _nr_contrato = value
        End Set
    End Property
    Public Property st_alocado() As String
        Get
            Return _st_alocado
        End Get
        Set(ByVal value As String)
            _st_alocado = value
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

    Public Sub New(ByVal id As Int32)

        Me.id_comodato = id
        loadComodato()

    End Sub



    Public Sub New()

    End Sub


    Public Function getComodatoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getComodatos", parameters, "ms_comodato")
            Return dataSet

        End Using

    End Function

    Private Sub loadComodato()

        Dim dataSet As DataSet = getComodatoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertComodato() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertComodatos", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateComodato()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateComodatos", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteComodato()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteComodatos", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function validarComodato() As Boolean

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getComodatobyCodigo", parameters, "ms_comodato")
            If dataSet.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        End Using


    End Function

End Class
