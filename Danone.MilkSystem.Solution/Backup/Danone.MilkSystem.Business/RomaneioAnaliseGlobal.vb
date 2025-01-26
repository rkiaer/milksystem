Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class RomaneioAnaliseGlobal
    Private _id_analise_global As Int32
    Private _id_romaneio As Int32
    Private _id_analise As Int32
    Private _nr_valor As Decimal
    Private _id_st_analise As Int32
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String
    Private _nm_st_analise As String
    Private _nm_analise_logica As String


    Public Property id_analise_global() As Int32
        Get
            Return _id_analise_global
        End Get
        Set(ByVal value As Int32)
            _id_analise_global = value
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

        Me._id_analise_global = id
        loadRomaneioAnaliseGlobal()

    End Sub

    Public Function getRomaneioAnaliseGlobalByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioAnaliseGlobal", parameters, "ms_romaneio_analise_global")
            Return dataSet

        End Using

    End Function

    Private Sub loadRomaneioAnaliseGlobal()

        Dim dataSet As DataSet = getRomaneioAnaliseGlobalByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertRomaneioAnaliseGlobal() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioAnaliseGlobal", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function

    Public Sub updateRomaneioAnaliseGlobal()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioAnaliseGlobal", parameters, ExecuteType.Update)

        End Using

    End Sub

End Class
