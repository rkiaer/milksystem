Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class RomaneioAnaliseCompartimento
    Private _id_analise_compartimento As Int32
    Private _id_romaneio_compartimento As Int32
    Private _nr_compartimento As Int32
    Private _id_compartimento As Int32
    Private _id_romaneio As Int32
    Private _id_analise As Int32
    Private _ds_comentario As String
    Private _st_reanalise As String
    Private _st_analise_tipo_reanalise As String
    Private _nr_valor As Decimal
    Private _id_st_analise As Int32
    Private _id_st_original As Int32
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String
    Private _nm_st_analise As String
    Private _nm_analise_logica As String
    Private _nm_sigla As String
    'Fran 23/10/2009 i chamado 519 Maracanau
    Private _id_estabelecimento As Int32
    'Fran 23/10/2009 f 
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property


    Public Property id_analise_compartimento() As Int32
        Get
            Return _id_analise_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_analise_compartimento = value
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
    Public Property ds_comentario() As String
        Get
            Return _ds_comentario
        End Get
        Set(ByVal value As String)
            _ds_comentario = value
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
    Public Property id_compartimento() As Int32
        Get
            Return _id_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_compartimento = value
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
    Public Property id_st_original() As Int32
        Get
            Return _id_st_original
        End Get
        Set(ByVal value As Int32)
            _id_st_original = value
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
    Public Property st_reanalise() As String
        Get
            Return _st_reanalise
        End Get
        Set(ByVal value As String)
            _st_reanalise = value
        End Set
    End Property

    Public Property st_analise_tipo_reanalise() As String
        Get
            Return _st_analise_tipo_reanalise
        End Get
        Set(ByVal value As String)
            _st_analise_tipo_reanalise = value
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

    Public Property nm_sigla() As String
        Get
            Return _nm_sigla
        End Get
        Set(ByVal value As String)
            _nm_sigla = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Int32)

        Me._id_analise_compartimento = id
        loadRomaneioAnaliseCompartimento()

    End Sub

    Public Function getRomaneioAnalisesCompartimentosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAnalisesCompartimentos", parameters, "ms_romaneio_analise_compartimento")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioAnalisesCompartimentoReanalise() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAnalisesCompartimentoReanalise", parameters, "ms_romaneio_analise_compartimento")
            Return dataSet

        End Using

    End Function

    Private Sub loadRomaneioAnaliseCompartimento()

        Dim dataSet As DataSet = getRomaneioAnalisesCompartimentosByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertRomaneioAnaliseCompartimento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioAnaliseCompartimento", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function

    Public Sub updateRomaneioAnaliseCompartimento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioAnaliseCompartimento", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getRomaneioAnaliseValorAnalise() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioAnaliseValorAnalise", parameters, ExecuteType.Select), Decimal)

        End Using
    End Function
    Public Function getRomaneioAnaliseCompartimentoSemResultado() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioAnaliseCompartimentoSemResultado", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Function getRomaneioAnaliseCompartimentoExigeAnexoSemResultado() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioAnaliseCompartimentoExigeAnexoSemResultado", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Function getRomaneioAnaliseCompartimentoObrigatoriaRejeitada() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioAnaliseCompartimentoObrigatoriaRejeitada", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Function getRomaneioAnaliseCompartimentoRejeitada() As Int32
        Using data As New DataAccess
            'Busca as analises rejeitadas do romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioAnaliseCompartimentoRejeitada", parameters, ExecuteType.Select), Int32)

        End Using

    End Function

End Class
