Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ImportacaoFreteErro

    Private _id_importacao_frete_erro As Int32
    Private _id_importacao_frete As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_importacao_log As Int32


    Public Property id_importacao_frete_erro() As Int32
        Get
            Return _id_importacao_frete_erro
        End Get
        Set(ByVal value As Int32)
            _id_importacao_frete_erro = value
        End Set
    End Property
    Public Property id_importacao_frete() As Int32
        Get
            Return _id_importacao_frete
        End Get
        Set(ByVal value As Int32)
            _id_importacao_frete = value
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
    Public Property id_importacao_log() As Int32
        Get
            Return _id_importacao_log
        End Get
        Set(ByVal value As Int32)
            _id_importacao_log = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_importacao_frete_erro = id
        loadImportacaoFreteErro()

    End Sub



    Public Sub New()

    End Sub


    Public Function getImportacaoFreteErroByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getImportacaoFreteErro", parameters, "ms_importacao_frete_erro")
            Return dataSet

        End Using

    End Function

    Private Sub loadImportacaoFreteErro()

        Dim dataSet As DataSet = getImportacaoFreteErroByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertImportacaoFreteErro() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertImportacaoFreteErro", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateImportacaoFreteErro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateImportacaoFreteErro", parameters, ExecuteType.Update)

        End Using

    End Sub


End Class
