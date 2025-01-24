Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ContaParcelada

    Private _id_conta_parcelada As Int32
    Private _id_conta As Int32
    Private _cd_conta As String
    Private _nm_conta As String
    Private _ds_produtor As String
    Private _id_propriedade As Int32
    Private _nr_valor_total As Decimal
    Private _dt_inicio_desconto As String
    Private _nr_qtd_parcela As Int32
    Private _nr_valor_parcela As Decimal
    Private _nr_taxa As Decimal
    Private _id_pessoa As Int32
    Private _cd_pessoa As String
    Private _nm_pessoa As String
    Private _ds_estabelecimento As String
    Private _nm_propriedade As String
    Private _id_estabelecimento As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _dt_referencia_desconto_end As String
    Private _dt_referencia_desconto As String
    Private _nr_qtd_parcela_descontada As Int32
    Private _id_romaneio As Int32
    Private _id_romaneio_compartimento As Int32

    Public Property id_conta_parcelada() As Int32
        Get
            Return _id_conta_parcelada
        End Get
        Set(ByVal value As Int32)
            _id_conta_parcelada = value
        End Set
    End Property


    Public Property id_conta() As Int32
        Get
            Return _id_conta
        End Get
        Set(ByVal value As Int32)
            _id_conta = value
        End Set
    End Property
    Public Property ds_produtor() As String
        Get
            Return _ds_produtor
        End Get
        Set(ByVal value As String)
            _ds_produtor = value
        End Set
    End Property
    Public Property ds_estabelecimento() As String
        Get
            Return _ds_estabelecimento
        End Get
        Set(ByVal value As String)
            _ds_estabelecimento = value
        End Set
    End Property

    Public Property cd_conta() As String
        Get
            Return _cd_conta
        End Get
        Set(ByVal value As String)
            _cd_conta = value
        End Set
    End Property


    Public Property nm_conta() As String
        Get
            Return _nm_conta
        End Get
        Set(ByVal value As String)
            _nm_conta = value
        End Set
    End Property


    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
        End Set
    End Property

    Public Property dt_inicio_desconto() As String
        Get
            Return _dt_inicio_desconto
        End Get
        Set(ByVal value As String)
            _dt_inicio_desconto = value
        End Set
    End Property

    Public Property nr_valor_total() As Decimal
        Get
            Return _nr_valor_total
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_total = value
        End Set
    End Property
    Public Property nr_qtd_parcela() As Int32
        Get
            Return _nr_qtd_parcela
        End Get
        Set(ByVal value As Int32)
            _nr_qtd_parcela = value
        End Set
    End Property
    Public Property nr_valor_parcela() As Decimal
        Get
            Return _nr_valor_parcela
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_parcela = value
        End Set
    End Property
    Public Property nr_taxa() As Decimal
        Get
            Return _nr_taxa
        End Get
        Set(ByVal value As Decimal)
            _nr_taxa = value
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
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property

    Public Property cd_pessoa() As String
        Get
            Return _cd_pessoa
        End Get
        Set(ByVal value As String)
            _cd_pessoa = value
        End Set
    End Property
    Public Property nm_pessoa() As String
        Get
            Return _nm_pessoa
        End Get
        Set(ByVal value As String)
            _nm_pessoa = value
        End Set
    End Property
    Public Property nm_propriedade() As String
        Get
            Return _nm_propriedade
        End Get
        Set(ByVal value As String)
            _nm_propriedade = value
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
    Public Property dt_referencia_desconto_end() As String
        Get
            Return _dt_referencia_desconto_end
        End Get
        Set(ByVal value As String)
            _dt_referencia_desconto_end = value
        End Set
    End Property
    Public Property dt_referencia_desconto() As String
        Get
            Return _dt_referencia_desconto
        End Get
        Set(ByVal value As String)
            _dt_referencia_desconto = value
        End Set
    End Property
    Public Property nr_qtd_parcela_descontada() As Int32
        Get
            Return _nr_qtd_parcela_descontada
        End Get
        Set(ByVal value As Int32)
            _nr_qtd_parcela_descontada = value
        End Set
    End Property
    Public Property id_romaneio() As Int32
        Get
            Return _id_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_romaneio = value
        End Set
    End Property
    Public Property id_romaneio_compartimento() As Int32
        Get
            Return _id_romaneio_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_compartimento = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me._id_conta_parcelada = id
        loadContaParcelada()

    End Sub



    Public Sub New()

    End Sub


    Public Function getContaParceladaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContasParceladas", parameters, "ms_conta_parcelada")
            Return dataSet

        End Using

    End Function
    Public Function getContaParceladaRomaneio() As DataSet 'fran 06/2016

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContasParceladasRomaneio", parameters, "ms_conta_parcelada")
            Return dataSet

        End Using

    End Function
    Private Sub loadContaParcelada()

        Dim dataSet As DataSet = getContaParceladaByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertContaParcelada() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertContasParceladas", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateContaParcelada()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateContasParceladas", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateCalculoContaParcelada()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCalculoContasParceladas", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteContaParcelada()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteContasParceladas", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
