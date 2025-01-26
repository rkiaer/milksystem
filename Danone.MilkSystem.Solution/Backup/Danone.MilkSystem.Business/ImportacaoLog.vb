Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ImportacaoLog

    Private _id_importacao_log As Int32
    Private _nr_linha As String
    Private _st_importacao As Int32
    Private _cd_erro As String
    Private _nm_erro As String
    Private _id_importacao As Int32



    Public Property id_importacao_log() As Int32
        Get
            Return _id_importacao_log
        End Get
        Set(ByVal value As Int32)
            _id_importacao_log = value
        End Set
    End Property

    Public Property nr_linha() As String
        Get
            Return _nr_linha
        End Get
        Set(ByVal value As String)
            _nr_linha = value
        End Set
    End Property


    Public Property st_importacao() As Int32
        Get
            Return _st_importacao
        End Get
        Set(ByVal value As Integer)
            _st_importacao = value
        End Set
    End Property


    Public Property cd_erro() As String
        Get
            Return _cd_erro
        End Get
        Set(ByVal value As String)
            _cd_erro = value
        End Set
    End Property

    Public Property nm_erro() As String
        Get
            Return _nm_erro
        End Get
        Set(ByVal value As String)
            _nm_erro = value
        End Set
    End Property
    Public Property id_importacao() As Int32
        Get
            Return _id_importacao
        End Get
        Set(ByVal value As Int32)
            _id_importacao = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me._id_importacao_log = id
        loadImportacaoLog()

    End Sub



    Public Sub New()

    End Sub


    Public Function getImportacaoLogByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getImportacoesLog", parameters, "ms_importacao_log")
            Return dataSet

        End Using

    End Function

    Private Sub loadImportacaoLog()

        Dim dataSet As DataSet = getImportacaoLogByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertImportacaoLog() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertImportacoesLog", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

End Class
