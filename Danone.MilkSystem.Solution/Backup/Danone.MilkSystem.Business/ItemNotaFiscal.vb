Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ItemNotaFiscal

    Private _id_nota_fiscal As Int32
    Private _id_item_nota As Int32
    Private _nr_sequencia As Int32
    Private _id_item As Int32
    Private _nm_item As String
    Private _cd_unidade_medida As String
    Private _nr_quantidade As Decimal
    Private _nr_preco_unitario As Decimal
    Private _nr_preco_total As Decimal
    Private _nr_peso_liquido As Decimal
    Private _dt_modificacao As String
    Private _id_modificador As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _ds_narrativa As String

    Public Property id_item_nota() As Int32
        Get
            Return _id_item_nota
        End Get
        Set(ByVal value As Int32)
            _id_item_nota = value
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
    Public Property nr_sequencia() As Int32
        Get
            Return _nr_sequencia
        End Get
        Set(ByVal value As Int32)
            _nr_sequencia = value
        End Set
    End Property
    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
        End Set
    End Property
    Public Property nm_item() As String
        Get
            Return _nm_item
        End Get
        Set(ByVal value As String)
            _nm_item = value
        End Set
    End Property
    Public Property cd_unidade_medida() As String
        Get
            Return _cd_unidade_medida
        End Get
        Set(ByVal value As String)
            _cd_unidade_medida = value
        End Set
    End Property
    Public Property nr_quantidade() As Decimal
        Get
            Return _nr_quantidade
        End Get
        Set(ByVal value As Decimal)
            _nr_quantidade = value
        End Set
    End Property
    Public Property nr_preco_unitario() As Decimal
        Get
            Return _nr_preco_unitario
        End Get
        Set(ByVal value As Decimal)
            _nr_preco_unitario = value
        End Set
    End Property
    Public Property nr_preco_total() As Decimal
        Get
            Return _nr_preco_total
        End Get
        Set(ByVal value As Decimal)
            _nr_preco_total = value
        End Set
    End Property
    Public Property nr_peso_liquido() As Decimal
        Get
            Return _nr_peso_liquido
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_liquido = value
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
    Public Property ds_narrativa() As String
        Get
            Return _ds_narrativa
        End Get
        Set(ByVal value As String)
            _ds_narrativa = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_item_nota = id
        loaditemNota()

    End Sub



    Public Sub New()

    End Sub


    Public Function getItensNotasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getItensNotas", parameters, "ms_item_nota")
            Return dataSet

        End Using

    End Function

    Private Sub loadItemNota()

        Dim dataSet As DataSet = getItensNotasByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertItemNota() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertItemNota", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateItemNota()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateItemNota", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateItemNotaNarrativa()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateItemNotaNarrativa", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteItemNota()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteItemNota", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
