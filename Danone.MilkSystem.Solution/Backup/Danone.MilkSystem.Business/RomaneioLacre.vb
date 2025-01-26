Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class RomaneioLacre
    Private _id_romaneio_lacre As Int32
    Private _id_romaneio_placa As Int32
    Private _id_romaneio As Int32
    Private _ds_placa As String
    Private _nr_lacre_entrada As String
    Private _nr_lacre_saida As String
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String
    Public Property id_romaneio_lacre() As Int32
        Get
            Return _id_romaneio_lacre
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_lacre = value
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
    Public Property ds_placa() As String
        Get
            Return _ds_placa
        End Get
        Set(ByVal value As String)
            _ds_placa = value
        End Set
    End Property
    Public Property id_romaneio_placa() As Int32
        Get
            Return _id_romaneio_placa
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_placa = value
        End Set
    End Property
    Public Property nr_lacre_entrada() As String
        Get
            Return _nr_lacre_entrada
        End Get
        Set(ByVal value As String)
            _nr_lacre_entrada = value
        End Set
    End Property
    Public Property nr_lacre_saida() As String
        Get
            Return _nr_lacre_saida
        End Get
        Set(ByVal value As String)
            _nr_lacre_saida = value
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

    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
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

    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Int32)

        Me._id_romaneio_lacre = id
        loadRomaneioLacre()

    End Sub

    Public Function getRomaneioLacresByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioLacres", parameters, "ms_romaneio_lacre")
            Return dataSet

        End Using

    End Function

    Private Sub loadRomaneioLacre()

        Dim dataSet As DataSet = getRomaneioLacresByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertRomaneioLacre() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioLacre", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Sub updateRomaneioLacre()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioLacre", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub deleteRomaneioLacre()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteRomaneioLacre", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function getRomaneioLacresSaidaNulosByRomaneio() As Int32
        Using data As New DataAccess
            'Busca as analises rejeitadas do romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioLacresSaidaNulosByRomaneio", parameters, ExecuteType.Select), Int32)

        End Using

    End Function

End Class
