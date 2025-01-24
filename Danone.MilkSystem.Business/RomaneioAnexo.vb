Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class RomaneioAnexo
    Private _id_romaneio_anexo As Int32
    Private _id_romaneio As Int32
    Private _id_tipo_anexo As Int32
    Private _nr_nota_fiscal As String
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _nm_documento As String
    Private _ds_descricao As String
    Private _nm_extensao As String
    Private _nm_arquivo As String
    Private _st_obrigatorio As String
    Private _nr_tamanho As Integer
    Private _varbin_documento As Byte
    Private _dt_modificacao As String

    Public Property id_romaneio_anexo() As Int32
        Get
            Return _id_romaneio_anexo
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_anexo = value
        End Set
    End Property
    Public Property id_romaneio() As Int32
        Get
            Return _id_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_romaneio = value
        End Set
    End Property
    Public Property id_tipo_anexo() As Int32
        Get
            Return _id_tipo_anexo
        End Get
        Set(ByVal value As Int32)
            _id_tipo_anexo = value
        End Set
    End Property
    Public Property nr_nota_fiscal() As String
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As String)
            _nr_nota_fiscal = value
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
    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
        End Set
    End Property
    Public Property nm_documento() As String
        Get
            Return _nm_documento
        End Get
        Set(ByVal value As String)
            _nm_documento = value
        End Set
    End Property
    Public Property ds_descricao() As String
        Get
            Return _ds_descricao
        End Get
        Set(ByVal value As String)
            _ds_descricao = value
        End Set
    End Property
    Public Property nm_extensao() As String
        Get
            Return _nm_extensao
        End Get
        Set(ByVal value As String)
            _nm_extensao = value
        End Set
    End Property
    Public Property nm_arquivo() As String
        Get
            Return _nm_arquivo
        End Get
        Set(ByVal value As String)
            _nm_arquivo = value
        End Set
    End Property
    Public Property st_obrigatorio() As String
        Get
            Return _st_obrigatorio
        End Get
        Set(ByVal value As String)
            _st_obrigatorio = value
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
    Public Property varbin_documento() As Byte
        Get
            Return _varbin_documento
        End Get
        Set(ByVal value As Byte)
            _varbin_documento = value
        End Set
    End Property
    Public Property nr_tamanho() As Int32
        Get
            Return _nr_tamanho
        End Get
        Set(ByVal value As Int32)
            _nr_tamanho = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)
        Me.id_romaneio_anexo = id
        loadRomaneioAnexo()
    End Sub

    Public Sub New()

    End Sub


    Public Function getRomaneioAnexo() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getRomaneioAnexo", parameters, "ms_romaneio_anexo")
            Return dataSet

        End Using

    End Function
    Private Sub loadRomaneioAnexo()

        Dim dataSet As DataSet = getRomaneioAnexo()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Sub deleteRomaneioAnexo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteRomaneioAnexo", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function insertRomaneioAnexo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioAnexo", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
End Class
