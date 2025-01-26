Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class Cidade

    Private _id_cidade As Int32
    Private _id_estado As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nm_cidade As String
    Private _cd_cep As String 'fran 01/03/2010  
    Private _cd_uf As String
    Public Property id_cidade() As Int32
        Get
            Return _id_cidade
        End Get
        Set(ByVal value As Int32)
            _id_cidade = value
        End Set
    End Property

    Public Property id_estado() As Int32
        Get
            Return _id_estado
        End Get
        Set(ByVal value As Int32)
            _id_estado = value
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

    Public Property nm_cidade() As String
        Get
            Return _nm_cidade
        End Get
        Set(ByVal value As String)
            _nm_cidade = value
        End Set
    End Property
    Public Property cd_cep() As String
        Get
            Return _cd_cep
        End Get
        Set(ByVal value As String)
            _cd_cep = value
        End Set
    End Property
    Public Property cd_uf() As String
        Get
            Return _cd_uf
        End Get
        Set(ByVal value As String)
            _cd_uf = value
        End Set
    End Property
    Public Sub New()

    End Sub

    Public Sub New(ByVal id As Int32)

        _id_cidade = id
        loadCidade()

    End Sub

    Public Function getCidadeByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCidades", parameters, "ms_cidade")

            Return dataSet


        End Using

    End Function
    Public Function getCidadeByCEP() As DataSet 'fran 01/03/2010

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCidadesByCEP", parameters, "ms_zcidade")

            Return dataSet


        End Using

    End Function
    Public Function getCidadeCentralByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCidadesCentral", parameters, "ms_cidade")

            Return dataSet


        End Using

    End Function
    Public Function getCidadesByNome() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getCidadesNome", parameters, ExecuteType.Select), Int32)

        End Using
    End Function

    Private Sub loadCidade()

        Dim dataSet As DataSet = getCidadeByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertCidade() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCidades", parameters, ExecuteType.Insert), Int32)

        End Using

    End Function

    Public Sub updateCidade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCidades", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteCidade()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCidades", parameters, ExecuteType.Delete)

        End Using

    End Sub

End Class
