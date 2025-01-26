Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class TabelaFreteVeiculos

    Private _id_central_tabela_frete As Int32
    Private _id_central_tabela_frete_veiculos As Int32
    Private _id_veiculocentralcompras As Int32
    Private _nm_veiculocentralcompras As String
    Private _nr_valor_frete As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Public Property id_central_tabela_frete() As Int32
        Get
            Return _id_central_tabela_frete
        End Get
        Set(ByVal value As Int32)
            _id_central_tabela_frete = value
        End Set
    End Property

    Public Property id_central_tabela_frete_veiculos() As Int32
        Get
            Return _id_central_tabela_frete_veiculos
        End Get
        Set(ByVal value As Integer)
            _id_central_tabela_frete_veiculos = value
        End Set
    End Property

    Public Property id_veiculocentralcompras() As Int32
        Get
            Return _id_veiculocentralcompras
        End Get
        Set(ByVal value As Int32)
            _id_veiculocentralcompras = value
        End Set
    End Property
    Public Property nm_veiculocentralcompras() As String
        Get
            Return _nm_veiculocentralcompras
        End Get
        Set(ByVal value As String)
            _nm_veiculocentralcompras = value
        End Set
    End Property

    Public Property nr_valor_frete() As Decimal
        Get
            Return _nr_valor_frete
        End Get
        Set(ByVal value As Decimal)
            _nr_valor_frete = value
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

        Me._id_central_tabela_frete_veiculos = id
        loadTabelaFreteVeiculos()

    End Sub
    Public Sub New()

    End Sub
    Public Function getCentralTabelaFreteVeiculos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getCentralTabelaFreteVeiculos", parameters, "ms_central_tabela_frete_veiculos")
            Return dataSet

        End Using

    End Function
    Private Sub loadTabelaFreteVeiculos()

        Dim dataSet As DataSet = getCentralTabelaFreteVeiculos()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertCentralTabelaFreteVeiculos() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCentralTabelaFreteVeiculos", parameters, ExecuteType.Insert), Int32)

        End Using

    End Function
    Public Sub updateCentralTabelaFreteVeiculos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateCentralTabelaFreteVeiculos", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub deleteCentralTabelaFreteVeiculos()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCentralTabelaFreteVeiculos", parameters, ExecuteType.Delete)

        End Using

    End Sub

End Class
