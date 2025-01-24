Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Motorista

    Private _id_motorista As Int32
    Private _nm_motorista As String
    Private _cd_cnh As String
    Private _dt_validade_cnh As String
    Private _dt_nascimento As String
    Private _st_sexo As String
    Private _id_grau_instrucao As Int32
    Private _nm_grau_instrucao As String
    Private _nr_dependentes As Int32
    Private _cd_cpf As String
    Private _cd_rg As String
    Private _cd_orgao_emissor As String
    Private _dt_expedicao_rg As String
    Private _ds_endereco As String
    Private _nr_endereco As Int32
    Private _ds_complemento As String
    Private _ds_bairro As String
    Private _id_cidade As Int32
    Private _id_estado As Int32
    Private _nm_cidade As String
    Private _nm_estado As String
    Private _cd_uf As String
    Private _cd_cep As String
    Private _ds_telefone_1 As String
    Private _ds_telefone_2 As String
    Private _ds_telefone_3 As String
    Private _ds_email As String
    Private _id_pessoa As Int32
    Private _nm_pessoa As String
    Private _cd_pessoa As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _st_categoria_cnh As String 'fase 3 
    Private _ds_treinamento_esalq As String 'fase 3


    Public Property id_motorista() As Int32
        Get
            Return _id_motorista
        End Get
        Set(ByVal value As Int32)
            _id_motorista = value
        End Set
    End Property
    Public Property nm_motorista() As String
        Get
            Return _nm_motorista
        End Get
        Set(ByVal value As String)
            _nm_motorista = value
        End Set
    End Property

    Public Property cd_cnh() As String
        Get
            Return _cd_cnh
        End Get
        Set(ByVal value As String)
            _cd_cnh = value
        End Set
    End Property
    Public Property dt_validade_cnh() As String
        Get
            Return _dt_validade_cnh
        End Get
        Set(ByVal value As String)
            _dt_validade_cnh = value
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
    Public Property st_sexo() As String
        Get
            Return _st_sexo
        End Get
        Set(ByVal value As String)
            _st_sexo = value
        End Set
    End Property

    Public Property id_grau_instrucao() As Int32
        Get
            Return _id_grau_instrucao
        End Get
        Set(ByVal value As Int32)
            _id_grau_instrucao = value
        End Set
    End Property

    Public Property nm_grau_instrucao() As String
        Get
            Return _nm_grau_instrucao
        End Get
        Set(ByVal value As String)
            _nm_grau_instrucao = value
        End Set
    End Property

    Public Property nr_dependentes() As Int32
        Get
            Return _nr_dependentes
        End Get
        Set(ByVal value As Int32)
            _nr_dependentes = value
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
    Public Property cd_orgao_emissor() As String
        Get
            Return _cd_orgao_emissor
        End Get
        Set(ByVal value As String)
            _cd_orgao_emissor = value
        End Set
    End Property
    Public Property dt_expedicao_rg() As String
        Get
            Return _dt_expedicao_rg
        End Get
        Set(ByVal value As String)
            _dt_expedicao_rg = value
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
    Public Property nr_endereco() As Int32
        Get
            Return _nr_endereco
        End Get
        Set(ByVal value As Int32)
            _nr_endereco = value
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

    Public Property ds_telefone_3() As String
        Get
            Return _ds_telefone_3
        End Get
        Set(ByVal value As String)
            _ds_telefone_3 = value
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
    Public Property id_pessoa() As Int32
        Get
            Return _id_pessoa
        End Get
        Set(ByVal value As Int32)
            _id_pessoa = value
        End Set
    End Property


    Public Property nm_pessoa() As String
        Get
            Return _nm_pessoa
        End Get
        Set(ByVal value As String)
            _nm_pessoa = value
        End Set
    End Property

    Public Property cd_pessoa() As String
        Get
            Return _cd_pessoa
        End Get
        Set(ByVal value As String)
            _cd_pessoa = value
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
    Public Property st_categoria_cnh() As String
        Get
            Return _st_categoria_cnh
        End Get
        Set(ByVal value As String)
            _st_categoria_cnh = value
        End Set
    End Property
    Public Property ds_treinamento_esalq() As String
        Get
            Return _ds_treinamento_esalq
        End Get
        Set(ByVal value As String)
            _ds_treinamento_esalq = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me._id_motorista = id
        loadMotorista()

    End Sub



    Public Sub New()

    End Sub


    Public Function getMotoristasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getMotoristas", parameters, "ms_motorista")
            Return dataSet

        End Using

    End Function


    Private Sub loadMotorista()

        Dim dataSet As DataSet = getMotoristasByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertMotorista() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertMotorista", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateMotorista()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateMotorista", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Function getMotoristaID() As Int32
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getMotoristaID", parameters, ExecuteType.Select), Int32)

        End Using
    End Function
    Public Function getMotoristaCNH() As String
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getMotoristaCNH", parameters, ExecuteType.Select), String)

        End Using
    End Function

    Public Sub deleteMotorista()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteMotorista", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
