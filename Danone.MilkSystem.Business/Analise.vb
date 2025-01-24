Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Analise

    Private _id_analise As Int32
    Private _cd_analise As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _id_estabelecimento As Int32
    Private _dt_modificacao As String
    Private _nm_analise As String
    Private _nm_sigla As String
    Private _id_item As Int32
    Private _id_tipo_analise As Int32
    Private _id_formato_analise As Int32
    Private _nr_faixa_inicial As Decimal
    Private _nr_faixa_final As Decimal
    Private _st_laboratorio_interno As String
    Private _st_laboratorio_externo As String
    Private _st_re_analise As String
    Private _st_obrigatoria As String
    Private _st_gera_ciq As String
    Private _id_faixa_referencia_analise As Int32
    Private _st_inibidor As String 'Fran 22/07/2011
    Private _st_exige_anexo As String 'Fran 03/2024
    Private _id_participa_romaneio As Int32


    Public Property id_analise() As Int32
        Get
            Return _id_analise
        End Get
        Set(ByVal value As Int32)
            _id_analise = value
        End Set
    End Property
    Public Property id_participa_romaneio() As Int32
        Get
            Return _id_participa_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_participa_romaneio = value
        End Set
    End Property
    Public Property cd_analise() As Int32
        Get
            Return _cd_analise
        End Get
        Set(ByVal value As Int32)
            _cd_analise = value
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

    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property id_tipo_analise() As Int32
        Get
            Return _id_tipo_analise
        End Get
        Set(ByVal value As Int32)
            _id_tipo_analise = value
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

    Public Property id_formato_analise() As Int32
        Get
            Return _id_formato_analise
        End Get
        Set(ByVal value As Int32)
            _id_formato_analise = value
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


    Public Property nm_analise() As String
        Get
            Return _nm_analise
        End Get
        Set(ByVal value As String)
            _nm_analise = value
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

    Public Property nr_faixa_inicial() As Decimal
        Get
            Return _nr_faixa_inicial
        End Get
        Set(ByVal value As Decimal)
            _nr_faixa_inicial = value
        End Set
    End Property
    Public Property nr_faixa_final() As Decimal
        Get
            Return _nr_faixa_final
        End Get
        Set(ByVal value As Decimal)
            _nr_faixa_final = value
        End Set
    End Property
    Public Property st_laboratorio_interno() As String
        Get
            Return _st_laboratorio_interno
        End Get
        Set(ByVal value As String)
            _st_laboratorio_interno = value
        End Set
    End Property
    Public Property st_laboratorio_externo() As String
        Get
            Return _st_laboratorio_externo
        End Get
        Set(ByVal value As String)
            _st_laboratorio_externo = value
        End Set
    End Property
    Public Property st_re_analise() As String
        Get
            Return _st_re_analise
        End Get
        Set(ByVal value As String)
            _st_re_analise = value
        End Set
    End Property
    Public Property st_obrigatoria() As String
        Get
            Return _st_obrigatoria
        End Get
        Set(ByVal value As String)
            _st_obrigatoria = value
        End Set
    End Property
    Public Property st_gera_ciq() As String
        Get
            Return _st_gera_ciq
        End Get
        Set(ByVal value As String)
            _st_gera_ciq = value
        End Set
    End Property
    Public Property id_faixa_referencia_logica() As Int32
        Get
            Return _id_faixa_referencia_analise
        End Get
        Set(ByVal value As Int32)
            _id_faixa_referencia_analise = value
        End Set
    End Property
    Public Property st_inibidor() As String
        Get
            Return _st_inibidor
        End Get
        Set(ByVal value As String)
            _st_inibidor = value
        End Set
    End Property
    Public Property st_exige_anexo() As String
        Get
            Return _st_exige_anexo
        End Get
        Set(ByVal value As String)
            _st_exige_anexo = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me.id_analise = id
        loadAnalise()

    End Sub



    Public Sub New()

    End Sub


    Public Function getAnaliseByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAnalises", parameters, "ms_analise")
            Return dataSet

        End Using

    End Function

    Private Sub loadAnalise()

        Dim dataSet As DataSet = getAnaliseByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertAnalise() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertAnalises", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateAnalise()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateAnalises", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteAnalise()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteAnalises", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
