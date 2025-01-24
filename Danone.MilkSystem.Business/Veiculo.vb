Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class Veiculo

    Private _id_veiculo As Int32
    Private _nr_ano_fabricacao As Int32
    Private _nr_ano_modelo As Int32
    Private _id_cidade As Int32
    Private _id_estado As Int32
    Private _nm_cidade As String
    Private _nm_estado As String
    Private _cd_uf As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _ds_placa As String
    Private _ds_modelo As String
    Private _ds_marca As String
    Private _ds_chassi As String
    Private _ds_renavam As String
    Private _nr_tara As Decimal
    Private _nr_qtd_compartimentos As Int32
    Private _id_pessoa As Int32
    Private _nm_pessoa As String
    Private _cd_pessoa As String
    Private _dt_modificacao As String
    Private _id_tipo_equipamento As Int32 'Fran 11/09/2009 GKO
    Private _ds_proprietario_tanque As String 'Fran 09/10/2009 GKO


    Public Property id_veiculo() As Int32
        Get
            Return _id_veiculo
        End Get
        Set(ByVal value As Int32)
            _id_veiculo = value
        End Set
    End Property



    Public Property nr_ano_fabricacao() As Int32
        Get
            Return _nr_ano_fabricacao
        End Get
        Set(ByVal value As Int32)
            _nr_ano_fabricacao = value
        End Set
    End Property

    Public Property nr_ano_modelo() As Int32
        Get
            Return _nr_ano_modelo
        End Get
        Set(ByVal value As Int32)
            _nr_ano_modelo = value
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
    Public Property id_estado() As Int32
        Get
            Return _id_estado
        End Get
        Set(ByVal value As Int32)
            _id_estado = value
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


    Public Property ds_placa() As String
        Get
            Return _ds_placa
        End Get
        Set(ByVal value As String)
            _ds_placa = value
        End Set
    End Property

    Public Property ds_marca() As String
        Get
            Return _ds_marca
        End Get
        Set(ByVal value As String)
            _ds_marca = value
        End Set
    End Property


    Public Property ds_modelo() As String
        Get
            Return _ds_modelo
        End Get
        Set(ByVal value As String)
            _ds_modelo = value
        End Set
    End Property
    Public Property ds_chassi() As String
        Get
            Return _ds_chassi
        End Get
        Set(ByVal value As String)
            _ds_chassi = value
        End Set
    End Property
    Public Property ds_renavam() As String
        Get
            Return _ds_renavam
        End Get
        Set(ByVal value As String)
            _ds_renavam = value
        End Set
    End Property


    Public Property nr_tara() As Decimal
        Get
            Return _nr_tara
        End Get
        Set(ByVal value As Decimal)
            _nr_tara = value
        End Set
    End Property

    Public Property nr_qtd_compartimentos() As Int32
        Get
            Return _nr_qtd_compartimentos
        End Get
        Set(ByVal value As Int32)
            _nr_qtd_compartimentos = value
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

    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
        End Set
    End Property
    'Fran 11/09/2009 GKO
    Public Property id_tipo_equipamento() As Int32
        Get
            Return _id_tipo_equipamento
        End Get
        Set(ByVal value As Int32)
            _id_tipo_equipamento = value
        End Set
    End Property
    Public Property ds_proprietario_tanque() As String
        Get
            Return _ds_proprietario_tanque
        End Get
        Set(ByVal value As String)
            _ds_proprietario_tanque = value
        End Set
    End Property
    Public Sub New(ByVal id As Int32)

        Me._id_veiculo = id
        loadVeiculo()

    End Sub



    Public Sub New()

    End Sub


    Public Function getVeiculoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getVeiculos", parameters, "ms_veiculo")
            Return dataSet

        End Using

    End Function
    Public Sub getVeiculoByPlaca()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getVeiculosByPlaca", parameters, "ms_veiculo")
            ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

        End Using

    End Sub
    Public Function getVeiculoByTipoEquipamento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_getVeiculosByTipoEquipamento", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Private Sub loadVeiculo()

        Dim dataSet As DataSet = getVeiculoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertVeiculo() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertVeiculos", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function


    Public Sub updateVeiculo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateVeiculos", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteVeiculo()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteVeiculos", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function validarPlaca() As Boolean

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getVeiculos", parameters, "ms_veiculo")
            If dataSet.Tables(0).Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If

        End Using


    End Function

End Class
