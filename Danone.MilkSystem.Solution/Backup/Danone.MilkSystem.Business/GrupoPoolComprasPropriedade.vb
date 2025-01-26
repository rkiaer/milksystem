Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GrupoPoolComprasPropriedade

    Private _id_grupo_pool_compras_propriedade As Int32
    Private _id_grupo_pool_compras As Int32
    Private _id_propriedade As Int32
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Public Property id_grupo_pool_compras() As Int32
        Get
            Return _id_grupo_pool_compras
        End Get
        Set(ByVal value As Int32)
            _id_grupo_pool_compras = value
        End Set
    End Property

    Public Property id_grupo_pool_compras_propriedade() As Int32
        Get
            Return _id_grupo_pool_compras_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_grupo_pool_compras_propriedade = value
        End Set
    End Property
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
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

    Public Sub New(ByVal id As Int32)

        Me._id_grupo_pool_compras_propriedade = id
        loadGrupo()

    End Sub
    Public Sub New()

    End Sub

    Public Function getGrupos_pool_comprasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGrupo_pool_compras_propriedade", parameters, "ms_grupo_pool_compras_propriedade")
            Return dataSet

        End Using

    End Function

    Private Sub loadGrupo()

        Dim dataSet As DataSet = getGrupos_pool_comprasByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updategrupo_pool_compras()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGrupo_pool_compras_propriedade", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function insertgrupo_pool_compras() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertGrupo_pool_compras_propriedade", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
    Public Sub deletegrupo_pool_compras()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteGrupo_pool_compras_propriedade", parameters, ExecuteType.Delete)

        End Using


    End Sub
End Class



