Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class RegistroExportacaoBatch


    Private _id_registro_exportacao_batch As Int32
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _nm_registro_exportacao_batch As String

    Public Property id_registro_exportacao_batch() As Int32
        Get
            Return _id_registro_exportacao_batch
        End Get
        Set(ByVal value As Int32)
            _id_registro_exportacao_batch = value
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

    Public Property nm_registro_exportacao_batch() As String
        Get
            Return _nm_registro_exportacao_batch
        End Get
        Set(ByVal value As String)
            _nm_registro_exportacao_batch = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)

        Me._id_registro_exportacao_batch = id
        loadRegistroExportacaoBatch()

    End Sub


    Public Sub New()

    End Sub

    Public Function getRegistroExportacaoBatch() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRegistroExportacaoBatch", parameters, "ms_zregistro_exportacao_batch")
            Return dataSet

        End Using

    End Function

    Private Sub loadRegistroExportacaoBatch()

        Dim dataSet As DataSet = getRegistroExportacaoBatch()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

End Class
