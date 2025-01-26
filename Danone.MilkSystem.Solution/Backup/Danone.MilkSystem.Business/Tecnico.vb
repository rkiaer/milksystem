Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Tecnico

    Private _id_tecnico As Int32
    Private _nr_endereco As Int32
    Private _id_cidade As Int32
    Private _id_estado As Int32
    Private _nm_cidade As String
    Private _nm_estado As String
    Private _cd_uf As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _id_estabelecimento As Int32
    Private _dt_nascimento As String
    Private _dt_nascimento_start As String
    Private _dt_nascimento_end As String
    Private _dt_modificacao As String
    Private _nm_tecnico As String
    Private _cd_cpf As String
    Private _cd_rg As String
    Private _ds_email As String
    Private _cd_cep As String
    Private _ds_telefone_1 As String
    Private _ds_telefone_2 As String
    Private _cd_orgao_emissor As String
    Private _ds_endereco As String
    Private _ds_complemento As String
    Private _ds_bairro As String
    Private _st_categoria As String
    Private _nm_abreviado As String 'fran 9/10/2009 i chamado 477 r rls 22


    Public Property id_tecnico() As Int32
        Get
            Return _id_tecnico
        End Get
        Set(ByVal value As Int32)
            _id_tecnico = value
        End Set
    End Property



    Public Property nr_endereco() As Int32
        Get
            Return _nr_endereco
        End Get
        Set(ByVal value As Int32)
            _nr_endereco = value
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

    Public Property nm_estado() As String
        Get
            Return _nm_estado
        End Get
        Set(ByVal value As String)
            _nm_estado = value
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


    Public Property id_cidade() As Int32
        Get
            Return _id_cidade
        End Get
        Set(ByVal value As Int32)
            _id_cidade = value
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


    Public Property dt_nascimento() As String
        Get
            Return _dt_nascimento
        End Get
        Set(ByVal value As String)
            _dt_nascimento = value
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


    Public Property nm_tecnico() As String
        Get
            Return _nm_tecnico
        End Get
        Set(ByVal value As String)
            _nm_tecnico = value
        End Set
    End Property



    Public Property cd_cpf() As String
        Get
            Return _cd_cpf
        End Get
        Set(ByVal value As String)
            _cd_cpf = value
        End Set
    End Property


    Public Property cd_rg() As String
        Get
            Return _cd_rg
        End Get
        Set(ByVal value As String)
            _cd_rg = value
        End Set
    End Property

    Public Property ds_email() As String
        Get
            Return _ds_email
        End Get
        Set(ByVal value As String)
            _ds_email = value
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


    Public Property ds_telefone_1() As String
        Get
            Return _ds_telefone_1
        End Get
        Set(ByVal value As String)
            _ds_telefone_1 = value
        End Set
    End Property

    Public Property ds_telefone_2() As String
        Get
            Return _ds_telefone_2
        End Get
        Set(ByVal value As String)
            _ds_telefone_2 = value
        End Set
    End Property


    Public Property cd_orgao_emissor() As String
        Get
            Return _cd_orgao_emissor
        End Get
        Set(ByVal value As String)
            _cd_orgao_emissor = value
        End Set
    End Property


    Public Property ds_endereco() As String
        Get
            Return _ds_endereco
        End Get
        Set(ByVal value As String)
            _ds_endereco = value
        End Set
    End Property

    Public Property ds_complemento() As String
        Get
            Return _ds_complemento
        End Get
        Set(ByVal value As String)
            _ds_complemento = value
        End Set
    End Property

    Public Property ds_bairro() As String
        Get
            Return _ds_bairro
        End Get
        Set(ByVal value As String)
            _ds_bairro = value
        End Set
    End Property

    Public Property st_categoria() As String
        Get
            Return _st_categoria
        End Get
        Set(ByVal value As String)
            _st_categoria = value
        End Set
    End Property
    Public Property nm_abreviado() As String
        Get
            Return _nm_abreviado
        End Get
        Set(ByVal value As String)
            _nm_abreviado = value
        End Set
    End Property



    Public Sub New(ByVal id As Int32)

        Me._id_tecnico = id
        loadTecnico()

    End Sub



    Public Sub New()

    End Sub


    Public Function getTecnicoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTecnicos", parameters, "ms_tecnico")
            Return dataSet

        End Using

    End Function

    Private Sub loadTecnico()

        Dim dataSet As DataSet = getTecnicoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertTecnico() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertTecnicos", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateTecnico()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateTecnicos", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteTecnico()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteTecnicos", parameters, ExecuteType.Delete)

        End Using


    End Sub

    Public Function validarTecnico() As Boolean

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTecnicos", parameters, "ms_tecnico")
            If dataSet.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        End Using


    End Function

End Class
