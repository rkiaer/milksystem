Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PropriedadeTreinamento

    Private _id_propriedadetreinamento As Int32
    Private _id_pessoa As Int32
    Private _id_estabelecimento As Int32
    Private _cd_estabelecimento As String
    Private _nm_estabelecimento As String
    Private _id_propriedade As Int32
    Private _id_situacao As Int32
    Private _nm_propriedade As String
    Private _nm_pessoa As String
    Private _id_treinamento As Int32
    Private _nm_treinamento As String
    Private _dt_inicio As String
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String
    Private _id_modificador As Int32
    Private _cd_pessoa As String


    Public Property id_propriedadetreinamento() As Int32
        Get
            Return _id_propriedadetreinamento
        End Get
        Set(ByVal value As Int32)
            _id_propriedadetreinamento = value
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

    Public Property dt_inicio() As String
        Get
            Return _dt_inicio
        End Get
        Set(ByVal value As String)
            _dt_inicio = value
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


    Public Property nm_propriedade() As String
        Get
            Return _nm_propriedade
        End Get
        Set(ByVal value As String)
            _nm_propriedade = value
        End Set
    End Property
    Public Property nm_pessoa() As String
        Get
            Return _nm_pessoa
        End Get
        Set(ByVal value As String)
            _nm_pessoa = value
        End Set
    End Property
    Public Property cd_pessoa() As String
        Get
            Return _cd_pessoa
        End Get
        Set(ByVal value As String)
            _cd_pessoa = value
        End Set
    End Property
    Public Property cd_estabelecimento() As String
        Get
            Return _cd_estabelecimento
        End Get
        Set(ByVal value As String)
            _cd_estabelecimento = value
        End Set
    End Property
    Public Property nm_estabelecimento() As String
        Get
            Return _nm_estabelecimento
        End Get
        Set(ByVal value As String)
            _nm_estabelecimento = value
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
    Public Property id_treinamento() As Int32
        Get
            Return _id_treinamento
        End Get
        Set(ByVal value As Int32)
            _id_treinamento = value
        End Set
    End Property
    Public Property nm_treinamento() As String
        Get
            Return _nm_treinamento
        End Get
        Set(ByVal value As String)
            _nm_treinamento = value
        End Set
    End Property

    Public Sub New()

    End Sub


    Public Sub New(ByVal id As Int32)

        Me._id_propriedadetreinamento = id
        loadPropriedadeTreinamento()

    End Sub

    Public Function getPropriedadeTreinamentoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPropriedadeTreinamento", parameters, "ms_propriedade_treinamento")
            Return dataSet

        End Using

    End Function

    Private Sub loadPropriedadeTreinamento()

        Dim dataSet As DataSet = getPropriedadeTreinamentoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertPropriedadeTreinamento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertPropriedadeTreinamento", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updatePropriedadeTreinamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updatePropriedadeTreinamento", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deletePropriedadeTreinamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deletePropriedadeTreinamento", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
