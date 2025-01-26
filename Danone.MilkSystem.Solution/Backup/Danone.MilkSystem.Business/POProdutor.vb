Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class POProdutor


    Private _id_po_produtor As Int32
    Private _id_estado As Int32
    Private _nr_po As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _dt_referencia As String
    Private _id_estabelecimento As Int32
    Private _id_item As Int32


    Public Property id_po_produtor() As Int32
        Get
            Return _id_po_produtor
        End Get
        Set(ByVal value As Int32)
            _id_po_produtor = value
        End Set
    End Property
    Public Property id_estado() As Int32
        Get
            Return _id_estado
        End Get
        Set(ByVal value As Int32)
            _id_estado = value
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
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
        End Set
    End Property
    Public Property nr_po() As String
        Get
            Return _nr_po
        End Get
        Set(ByVal value As String)
            _nr_po = value
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
    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me._id_po_produtor = id
        loadPOProdutor()

    End Sub


    Public Sub New()

    End Sub

    Public Function getPOProdutorbyFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPoProdutor", parameters, "ms_po_produtor")
            Return dataSet

        End Using

    End Function

    Private Sub loadPOProdutor()

        Dim dataSet As DataSet = getPOProdutorbyFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Sub deletePOProdutor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deletePOProdutor", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function insertPOProdutor() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPOProdutor", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updatePOProdutor()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePOProdutor", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
