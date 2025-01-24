Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PoupancaParametroCategoria

    Private _id_poupanca_parametro_categoria As Int32
    Private _id_poupanca_parametro As Int32
    Private _nr_categoria As Int32
    Private _nr_elegiveis As Int32
    Private _nr_volume_ini As Decimal
    Private _nr_volume_fim As Decimal
    Private _id_modificador As Int32
    Private _ds_descricao As String
    Public Property id_poupanca_parametro_categoria() As Int32
        Get
            Return _id_poupanca_parametro_categoria
        End Get
        Set(ByVal value As Int32)
            _id_poupanca_parametro_categoria = value
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
    Public Property nr_categoria() As Int32
        Get
            Return _nr_categoria
        End Get
        Set(ByVal value As Int32)
            _nr_categoria = value
        End Set
    End Property
    Public Property nr_elegiveis() As Int32
        Get
            Return _nr_elegiveis
        End Get
        Set(ByVal value As Int32)
            _nr_elegiveis = value
        End Set
    End Property
 
    Public Property nr_volume_ini() As Decimal
        Get
            Return _nr_volume_ini
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_ini = value
        End Set
    End Property
    Public Property nr_volume_fim() As Decimal
        Get
            Return _nr_volume_fim
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_fim = value
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

    Public Property ds_descricao() As String
        Get
            Return _ds_descricao
        End Get
        Set(ByVal value As String)
            _ds_descricao = value
        End Set
    End Property
 
    Public Sub New(ByVal id As Int32)
        Me.id_poupanca_parametro_categoria = id
        loadPoupancaParametroCategoria()
    End Sub

    Public Sub New()

    End Sub


    Public Function getPoupancaParametroCategoria() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getPoupancaParametroCategoria", parameters, "ms_poupanca_parametro_categoria")
            Return dataSet

        End Using

    End Function

    Private Sub loadPoupancaParametroCategoria()

        Dim dataSet As DataSet = getPoupancaParametroCategoria()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

 
End Class
