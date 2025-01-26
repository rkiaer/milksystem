Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class DuplicataNotaFiscal

    Private _id_nota_fiscal As Int32
    Private _id_duplicata_nota As Int32
    Private _id_natureza_operacao As Int32
    Private _cd_natureza_operacao As String
    Private _nm_natureza_operacao As String
    Private _id_especie_nf As Int32
    Private _nm_especie_nf As String
    Private _ds_tipo_especie As String
    Private _nr_parcela As Int32
    Private _nr_duplicata As String
    Private _dt_emissao As String
    Private _dt_transacao As String
    Private _dt_vencimento As String
    Private _nr_valor_duplicata As Decimal
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Public Property id_duplicata_nota() As Int32
        Get
            Return _id_duplicata_nota
        End Get
        Set(ByVal value As Int32)
            _id_duplicata_nota = value
        End Set
    End Property

    Public Property id_nota_fiscal() As Int32
        Get
            Return _id_nota_fiscal
        End Get
        Set(ByVal value As Int32)
            _id_nota_fiscal = value
        End Set
    End Property
    Public Property id_natureza_operacao() As Int32
        Get
            Return _id_natureza_operacao
        End Get
        Set(ByVal value As Int32)
            _id_natureza_operacao = value
        End Set
    End Property
    Public Property nm_natureza_operacao() As String
        Get
            Return _nm_natureza_operacao
        End Get
        Set(ByVal value As String)
            _nm_natureza_operacao = value
        End Set
    End Property
    Public Property cd_natureza_operacao() As String
        Get
            Return _cd_natureza_operacao
        End Get
        Set(ByVal value As String)
            _cd_natureza_operacao = value
        End Set
    End Property
    Public Property ds_tipo_especie() As String
        Get
            Return _ds_tipo_especie
        End Get
        Set(ByVal value As String)
            _ds_tipo_especie = value
        End Set
    End Property
    Public Property nm_especie_nf() As String
        Get
            Return _nm_especie_nf
        End Get
        Set(ByVal value As String)
            _nm_especie_nf = value
        End Set
    End Property
    Public Property id_especie_nf() As Int32
        Get
            Return _id_especie_nf
        End Get
        Set(ByVal value As Int32)
            _id_especie_nf = value
        End Set
    End Property
    Public Property nr_parcela() As Int32
        Get
            Return _nr_parcela
        End Get
        Set(ByVal value As Int32)
            _nr_parcela = value
        End Set
    End Property
    Public Property nr_duplicata() As String
        Get
            Return _nr_duplicata
        End Get
        Set(ByVal value As String)
            _nr_duplicata = value
        End Set
    End Property
    Public Property dt_emissao() As String
        Get
            Return _dt_emissao
        End Get
        Set(ByVal value As String)
            _dt_emissao = value
        End Set
    End Property
    Public Property dt_transacao() As String
        Get
            Return _dt_transacao
        End Get
        Set(ByVal value As String)
            _dt_transacao = value
        End Set
    End Property
    Public Property dt_vencimento() As String
        Get
            Return _dt_vencimento
        End Get
        Set(ByVal value As String)
            _dt_vencimento = value
        End Set
    End Property
    Public Property nr_valor_duplicata() As Decimal
        Get
            Return _nr_valor_duplicata
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_duplicata = value
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

        Me.id_duplicata_nota = id
        loadDuplicataNota()

    End Sub



    Public Sub New()

    End Sub


    Public Function getDuplicatasNotasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getDuplicatasNotas", parameters, "ms_duplicata_nota")
            Return dataSet

        End Using

    End Function

    Private Sub loadDuplicataNota()

        Dim dataSet As DataSet = getDuplicatasNotasByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertDuplicataNota() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertDuplicataNota", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateDuplicataNota()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateDuplicataNota", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteDuplicataNota()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteDuplicataNota", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
