Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class RomaneioAnaliseUProducao
    Private _id_analise_uproducao As Int32
    Private _id_romaneio_uproducao As Int32
    Private _id_romaneio_compartimento As Int32
    Private _id_romaneio As Int32
    Private _nr_compartimento As Int32
    Private _id_analise As Int32
    Private _nr_valor As Decimal
    Private _id_st_analise As Int32
    Private _ds_comentario As String
    Private _st_reanalise As String
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String
    Private _nm_st_analise As String
    Private _nm_analise_logica As String


    Public Property id_analise_uproducao() As Int32
        Get
            Return _id_analise_uproducao
        End Get
        Set(ByVal value As Int32)
            _id_analise_uproducao = value
        End Set
    End Property
    Public Property id_romaneio_uproducao() As Int32
        Get
            Return _id_romaneio_uproducao
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_uproducao = value
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

    Public Property id_romaneio() As Int32
        Get
            Return _id_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_romaneio = value
        End Set
    End Property

    Public Property nr_compartimento() As Int32
        Get
            Return _nr_compartimento
        End Get
        Set(ByVal value As Int32)
            _nr_compartimento = value
        End Set
    End Property

    Public Property id_analise() As Int32
        Get
            Return _id_analise
        End Get
        Set(ByVal value As Int32)
            _id_analise = value
        End Set
    End Property

    Public Property id_st_analise() As Int32
        Get
            Return _id_st_analise
        End Get
        Set(ByVal value As Int32)
            _id_st_analise = value
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


    Public Property nm_st_analise() As String
        Get
            Return _nm_st_analise
        End Get
        Set(ByVal value As String)
            _nm_st_analise = value
        End Set
    End Property

    Public Property nm_analise_logica() As String
        Get
            Return _nm_analise_logica
        End Get
        Set(ByVal value As String)
            _nm_analise_logica = value
        End Set
    End Property
    Public Property ds_comentario() As String
        Get
            Return _ds_comentario
        End Get
        Set(ByVal value As String)
            _ds_comentario = value
        End Set
    End Property
    Public Property st_reanalise() As String
        Get
            Return _st_reanalise
        End Get
        Set(ByVal value As String)
            _st_reanalise = value
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

        Me._id_analise_uproducao = id
        loadRomaneioAnaliseUProducao()

    End Sub

    Public Function getRomaneioAnalisesUProducaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAnalisesUProducao", parameters, "ms_romaneio_analise_uproducao")
            Return dataSet

        End Using

    End Function

    Private Sub loadRomaneioAnaliseUProducao()

        Dim dataSet As DataSet = getRomaneioAnalisesUProducaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertRomaneioAnaliseUProducao() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioAnaliseUProducao", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function

    Public Sub updateRomaneioAnaliseUProducao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioAnaliseUProducao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getRomaneioAnaliseUProducaoSemResultado() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioAnaliseUProducaoSemResultado", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Function getRomaneioAnaliseUProducaoObrigatoriaRejeitada() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioAnaliseUProducaoObrigatoriaRejeitada", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Function getRomaneioAnaliseUProducaoRejeitada() As Int32
        Using data As New DataAccess
            'Busca as analises rejeitadas do romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioAnaliseUProducaoRejeitada", parameters, ExecuteType.Select), Int32)

        End Using

    End Function

End Class
