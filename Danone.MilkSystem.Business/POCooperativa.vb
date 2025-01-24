Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class POCooperativa


    Private _id_po_cooperativa As Int32
    Private _id_cooperativa As Int32
    Private _dt_inicio As String
    Private _dt_fim As String
    Private _dt_inicio_start As String
    Private _dt_inicio_end As String
    Private _nr_po As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _cd_cooperativa As String
    Private _nm_cooperativa As String
    Private _id_estabelecimento As Int32
    Private _id_item As Int32
    Public Property id_po_cooperativa() As Int32
        Get
            Return _id_po_cooperativa
        End Get
        Set(ByVal value As Int32)
            _id_po_cooperativa = value
        End Set
    End Property
    Public Property id_cooperativa() As Int32
        Get
            Return _id_cooperativa
        End Get
        Set(ByVal value As Int32)
            _id_cooperativa = value
        End Set
    End Property
    Public Property dt_inicio() As String
        Get
            Return _dt_inicio
        End Get
        Set(ByVal value As String)
            _dt_inicio = value
        End Set
    End Property
    Public Property dt_fim() As String
        Get
            Return _dt_fim
        End Get
        Set(ByVal value As String)
            _dt_fim = value
        End Set
    End Property
    Public Property dt_inicio_start() As String
        Get
            Return _dt_inicio_start
        End Get
        Set(ByVal value As String)
            _dt_inicio_start = value
        End Set
    End Property
    Public Property dt_inicio_end() As String
        Get
            Return _dt_inicio_end
        End Get
        Set(ByVal value As String)
            _dt_inicio_end = value
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

    Public Property nr_po() As String
        Get
            Return _nr_po
        End Get
        Set(ByVal value As String)
            _nr_po = value
        End Set
    End Property

    Public Property cd_cooperativa() As String
        Get
            Return _cd_cooperativa
        End Get
        Set(ByVal value As String)
            _cd_cooperativa = value
        End Set
    End Property
    Public Property nm_cooperativa() As String
        Get
            Return _nm_cooperativa
        End Get
        Set(ByVal value As String)
            _nm_cooperativa = value
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

        Me._id_po_cooperativa = id
        loadPOCooperativa()

    End Sub


    Public Sub New()

    End Sub

    Public Function getPOCooperativabyFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPoCooperativa", parameters, "ms_po_cooperativa")
            Return dataSet

        End Using

    End Function

    Private Sub loadPOCooperativa()

        Dim dataSet As DataSet = getPOCooperativabyFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Sub deletePOCooperativa()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deletePOCooperativa", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function insertPOCooperativa() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPOCooperativa", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updatePOCooperativa()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePOCooperativa", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
