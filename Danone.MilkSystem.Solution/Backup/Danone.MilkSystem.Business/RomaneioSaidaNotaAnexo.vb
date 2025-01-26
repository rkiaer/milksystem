Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class RomaneioSaidaNotaAnexo
    Private _id_romaneio_saida_nota_anexo As Int32
    Private _id_romaneio_saida_nota As Int32
    Private _id_romaneio_saida As Int32
    Private _id_tipo_anexo As Int32
    Private _id_origem As Int32
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _dt_criacao As String
    Private _id_modificador As Int32
    Private _nm_documento_xml As String
    Private _nm_extensao_xml As String
    Private _nm_arquivo_xml As String
    Private _nr_tamanho_xml As Integer
    Private _nm_documento_pdf As String
    Private _nm_extensao_pdf As String
    Private _nm_arquivo_pdf As String
    Private _nr_tamanho_pdf As Integer
    Private _varb_notaxml As Byte
    Private _varb_notapdf As Byte
    Private _dt_modificacao As String
    Public Property id_romaneio_saida_nota_anexo() As Int32
        Get
            Return _id_romaneio_saida_nota_anexo
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_saida_nota_anexo = value
        End Set
    End Property
    Public Property id_romaneio_saida_nota() As Int32
        Get
            Return _id_romaneio_saida_nota
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_saida_nota = value
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
    Public Property id_situacao() As Int32
        Get
            Return _id_situacao
        End Get
        Set(ByVal value As Int32)
            _id_situacao = value
        End Set
    End Property
    Public Property id_romaneio_saida() As Int32
        Get
            Return _id_romaneio_saida
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_saida = value
        End Set
    End Property
    Public Property id_origem() As Int32
        Get
            Return _id_origem
        End Get
        Set(ByVal value As Int32)
            _id_origem = value
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
    Public Property nm_documento_xml() As String
        Get
            Return _nm_documento_xml
        End Get
        Set(ByVal value As String)
            _nm_documento_xml = value
        End Set
    End Property
    Public Property nm_extensao_xml() As String
        Get
            Return _nm_extensao_xml
        End Get
        Set(ByVal value As String)
            _nm_extensao_xml = value
        End Set
    End Property
    Public Property nm_arquivo_xml() As String
        Get
            Return _nm_arquivo_xml
        End Get
        Set(ByVal value As String)
            _nm_arquivo_xml = value
        End Set
    End Property
    Public Property nr_tamanho_xml() As Integer
        Get
            Return _nr_tamanho_xml
        End Get
        Set(ByVal value As Integer)
            _nr_tamanho_xml = value
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
    Public Property varb_notaxml() As Byte
        Get
            Return _varb_notaxml
        End Get
        Set(ByVal value As Byte)
            _varb_notaxml = value
        End Set
    End Property
    Public Property nm_documento_pdf() As String
        Get
            Return _nm_documento_pdf
        End Get
        Set(ByVal value As String)
            _nm_documento_pdf = value
        End Set
    End Property
    Public Property nm_extensao_pdf() As String
        Get
            Return _nm_extensao_pdf
        End Get
        Set(ByVal value As String)
            _nm_extensao_pdf = value
        End Set
    End Property
    Public Property nm_arquivo_pdf() As String
        Get
            Return _nm_arquivo_pdf
        End Get
        Set(ByVal value As String)
            _nm_arquivo_pdf = value
        End Set
    End Property
    Public Property nr_tamanho_pdf() As Integer
        Get
            Return _nr_tamanho_pdf
        End Get
        Set(ByVal value As Integer)
            _nr_tamanho_pdf = value
        End Set
    End Property
    Public Property varb_notapdf() As Byte
        Get
            Return _varb_notapdf
        End Get
        Set(ByVal value As Byte)
            _varb_notapdf = value
        End Set
    End Property


    Public Sub New(ByVal id As Int32)
        Me.id_romaneio_saida_nota_anexo = id
        loadRomaneioSaidaNotaAnexo()
    End Sub

    Public Sub New()

    End Sub


    Public Function getRomaneioSaidaNotaAnexo() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getRomaneioSaidaNotaAnexo", parameters, "ms_romaneio_saida_nota_anexo")
            Return dataSet

        End Using

    End Function
    Private Sub loadRomaneioSaidaNotaAnexo()

        Dim dataSet As DataSet = getRomaneioSaidaNotaAnexo()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Sub deleteRomaneioSaidaNotaAnexo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteRomaneioSaidaNotaAnexo", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function insertRomaneioNotasAnexo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioSaidaNotasAnexo", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
End Class
