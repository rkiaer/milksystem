Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class GrupoCadastro

    Private _id_grupo As Int32
    Private _nm_grupo As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String


    Public Property id_grupo() As Int32
        Get
            Return _id_grupo
        End Get
        Set(ByVal value As Int32)
            _id_grupo = value
        End Set
    End Property
    Public Property nm_grupo() As String
        Get
            Return _nm_grupo
        End Get
        Set(ByVal value As String)
            _nm_grupo = value
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



    Public Sub New(ByVal id As Int32)

        Me.id_grupo = id
        loadGrupo()

    End Sub



    Public Sub New()

    End Sub


    Public Function getGrupoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "msc_getGrupos", parameters, "msc_grupo")
            Return dataSet

        End Using

    End Function

    Private Sub loadGrupo()

        Dim dataSet As DataSet = getGrupoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertGrupo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("msc_insertGrupos", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateGrupo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("msc_updateGrupos", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteGrupo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("msc_deleteGrupos", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
