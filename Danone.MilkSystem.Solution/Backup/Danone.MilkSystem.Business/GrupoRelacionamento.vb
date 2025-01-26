Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GrupoRelacionamento
    Private _id_grupo_relacionamento As Int32
    Private _id_propriedade_titular As Int32
    Private _id_propriedade As Int32
    Private _id_pessoa As Int32
    Private _id_estabelecimento As Int32
    Private _id_propriedade_responsavel_bonus As Int32
    Private _id_situacao As Int32
    Private _id_situacao_propriedade As Int32
    Private _st_relacionamento As String
    Private _st_participa_poupanca As String
    Private _st_compartilha_qualidade As String
    Private _st_compartilha_volume As String
    Private _id_criacao As Int32
    Private _id_modificador As Int32
   
    Public Property id_propriedade_titular() As Int32
        Get
            Return _id_propriedade_titular
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_titular = value
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
    Public Property id_propriedade_responsavel_bonus() As Int32
        Get
            Return _id_propriedade_responsavel_bonus
        End Get
        Set(ByVal value As Int32)
            _id_propriedade_responsavel_bonus = value
        End Set
    End Property

    Public Property id_grupo_relacionamento() As Int32
        Get
            Return _id_grupo_relacionamento
        End Get
        Set(ByVal value As Int32)
            _id_grupo_relacionamento = value
        End Set
    End Property
    Public Property st_compartilha_qualidade() As String
        Get
            Return _st_compartilha_qualidade
        End Get
        Set(ByVal value As String)
            _st_compartilha_qualidade = value
        End Set
    End Property
    Public Property st_compartilha_volume() As String
        Get
            Return _st_compartilha_volume
        End Get
        Set(ByVal value As String)
            _st_compartilha_volume = value
        End Set
    End Property
    Public Property st_relacionamento() As String
        Get
            Return _st_relacionamento
        End Get
        Set(ByVal value As String)
            _st_relacionamento = value
        End Set
    End Property
    Public Property st_participa_poupanca() As String
        Get
            Return _st_participa_poupanca
        End Get
        Set(ByVal value As String)
            _st_participa_poupanca = value
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

        Me._id_grupo_relacionamento = id
        loadGrupoRelacionamento()

    End Sub

    Public Function getGrupoRelacionamento() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGrupoRelacionamento", parameters, "ms_grupo_relacionamento")
            Return dataSet

        End Using

    End Function


    Public Sub loadGrupoRelacionamento()

        Dim dataSet As DataSet = getGrupoRelacionamento()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertGrupoRelacionamento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertGrupoRelacionamento", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function

    Public Sub updateGrupoRelacionamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGrupoRelacionamento", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateGrupoRelacionamentoParametroPoupanca()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGrupoRelacionamentoParametroPoupanca", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deleteGrupoRelacionamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteGrupoRelacionamento", parameters, ExecuteType.Delete)

        End Using


    End Sub
End Class
