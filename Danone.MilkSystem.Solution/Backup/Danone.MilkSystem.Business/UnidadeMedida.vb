
Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class UnidadeMedida

    Private _id_unidade_medida As Int32
    Private _ds_unidade_medida As String
    Private _nm_unidade_medida As String
    Private _cd_unidade_medida As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    
    Public Property id_unidade_medida() As Int32
        Get
            Return _id_unidade_medida
        End Get
        Set(ByVal value As Int32)
            _id_unidade_medida = value
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

    Public Property nm_unidade_medida() As String
        Get
            Return _nm_unidade_medida
        End Get
        Set(ByVal value As String)
            _nm_unidade_medida = value
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
    Public Property ds_unidade_medida() As String
        Get
            Return _ds_unidade_medida
        End Get
        Set(ByVal value As String)
            _ds_unidade_medida = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Int32)

        Me.id_unidade_medida = id
        loadunidade_medida()

    End Sub

    Public Function getunidade_medidaByfilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getunidade_medida", parameters, "ms_zunidade_medida")

            Return dataSet

        End Using

    End Function

    Private Sub loadunidade_medida()

        Dim dataSet As DataSet = getunidade_medidaByfilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class



