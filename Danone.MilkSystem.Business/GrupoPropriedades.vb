Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GrupoPropriedades
    Private _id_grupo_propriedades As Int32
    Private _id_propriedade_matriz As Int32
    Private _id_propriedade As Int32
    Private _id_pessoa As Int32
    Private _id_estabelecimento As Int32
    Private _id_situacao As Int32
    Private _id_situacao_propriedade As Int32
    Private _st_tipo_propriedade As String
    Private _id_criacao As Int32
    Private _id_modificador As Int32

    Public Property id_propriedade_matriz() As Int32
        Get
            Return _id_propriedade_matriz
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_matriz = value
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
    Public Property id_pessoa() As Int32
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
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

    Public Property id_grupo_propriedades() As Int32
        Get
            Return _id_grupo_propriedades
        End Get
        Set(ByVal value As Int32)
            _id_grupo_propriedades = value
        End Set
    End Property
    Public Property st_tipo_propriedade() As String
        Get
            Return _st_tipo_propriedade
        End Get
        Set(ByVal value As String)
            _st_tipo_propriedade = value
        End Set
    End Property
    Public Property id_situacao_propriedade() As Int32
        Get
            Return _id_situacao_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_situacao_propriedade = value
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
    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
        End Set
    End Property


    Public Sub New()

    End Sub


    Public Sub New(ByVal id As Int32)

        Me._id_grupo_propriedades = id
        loadGrupoPropriedades()

    End Sub

    Public Function getGrupoPropriedades() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGrupoPropriedades", parameters, "ms_grupo_propriedades")
            Return dataSet

        End Using

    End Function


    Public Sub loadGrupoPropriedades()

        Dim dataSet As DataSet = getGrupoPropriedades()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertGrupoPropriedades() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertGrupoPropriedades", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function

    Public Sub updateGrupoPropriedades()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGrupoPropriedades", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteGrupoPropriedades()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteGrupoPropriedades", parameters, ExecuteType.Delete)

        End Using


    End Sub
End Class
