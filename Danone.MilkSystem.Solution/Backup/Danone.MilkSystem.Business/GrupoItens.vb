Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GrupoItens

    Private _id_grupo_itens As Int32
    Private _cd_grupo_itens As String
    Private _nm_grupo_itens As String
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nm_modificador As String  ' 04/11/2009 - Adri


    Public Property id_grupo_itens() As Int32
        Get
            Return _id_grupo_itens
        End Get
        Set(ByVal value As Int32)
            _id_grupo_itens = value
        End Set
    End Property
    Public Property cd_grupo_itens() As String
        Get
            Return _cd_grupo_itens
        End Get
        Set(ByVal value As String)
            _cd_grupo_itens = value
        End Set
    End Property
    Public Property nm_grupo_itens() As String
        Get
            Return _nm_grupo_itens
        End Get
        Set(ByVal value As String)
            _nm_grupo_itens = value
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
    Public Property nm_modificador() As String
        Get
            Return _nm_modificador
        End Get
        Set(ByVal value As String)
            _nm_modificador = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me._id_grupo_itens = id
        loadGrupo()

    End Sub
    Public Sub New()

    End Sub

    Public Function getGrupos_itensByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGrupo_itens", parameters, "ms_grupo_itens")
            Return dataSet

        End Using

    End Function

    Private Sub loadGrupo()

        Dim dataSet As DataSet = getGrupos_itensByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updategrupo_itens()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGrupo_itens", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function insertgrupo_itens() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertGrupo_itens", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub deletegrupo_itens()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteGrupo_itens", parameters, ExecuteType.Delete)

        End Using


    End Sub
End Class

