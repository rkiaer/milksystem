Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class CalculoFreteTransportadorAnexo
    Private _id_calculo_frete_transportador_anexo As Int32
    Private _id_calculo_frete_transportador As Int32
    Private _id_transportador As Int32
    Private _id_frete_periodo As Int32
    Private _id_tipo_frete As Int32
    Private _id_tipo_anexo As Int32
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
    Public Property id_calculo_frete_transportador_anexo() As Int32
        Get
            Return _id_calculo_frete_transportador_anexo
        End Get
        Set(ByVal value As Int32)
            _id_calculo_frete_transportador_anexo = value
        End Set
    End Property
    Public Property id_calculo_frete_transportador() As Int32
        Get
            Return _id_calculo_frete_transportador
        End Get
        Set(ByVal value As Int32)
            _id_calculo_frete_transportador = value
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
    Public Property id_tipo_frete() As Int32
        Get
            Return _id_tipo_frete
        End Get
        Set(ByVal value As Int32)
            _id_tipo_frete = value
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
    Public Property id_transportador() As Int32
        Get
            Return _id_transportador
        End Get
        Set(ByVal value As Int32)
            _id_transportador = value
        End Set
    End Property
    Public Property id_frete_periodo() As Int32
        Get
            Return _id_frete_periodo
        End Get
        Set(ByVal value As Int32)
            _id_frete_periodo = value
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
        Me.id_calculo_frete_transportador_anexo = id
        loadCalculoFreteTransportadorAnexo()
    End Sub

    Public Sub New()

    End Sub


    Public Function getCalculoFreteTransportadorAnexo() As DataSet

        Using data As New DataAccess
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Dim dataSet As New DataSet
            data.Fill(dataSet, "ms_getCalculoFreteTransportadorAnexo", parameters, "ms_calculo_frete_transportador_anexo")
            Return dataSet

        End Using

    End Function
    Private Sub loadCalculoFreteTransportadorAnexo()

        Dim dataSet As DataSet = getCalculoFreteTransportadorAnexo()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Sub deleteCalculoFreteTransportadorAnexo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteCalculoFreteTransportadorAnexo", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function insertCalculoFreteTransportadorAnexo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertCalculoFreteTransportadorAnexo", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function
End Class
