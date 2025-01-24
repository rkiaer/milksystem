Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class TransvaseUProducao

    Private _id_transvase_up As Int32
    Private _id_transvase As Int32
    Private _id_transvase_compartimento As Int32
    Private _id_propriedade As Int32
    Private _id_unid_producao As Int32
    Private _nr_unid_producao As Int32
    Private _nr_litros As Decimal
    Private _id_pre_romaneio As Int32
    Private _id_romaneio_uproducao As Int32
    Private _ds_propriedade As String
    Private _ds_uproducao As String
    Private _nm_pessoa As String
    Private _ds_produtor As String
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_coleta As String
    Private _dt_criacao As String
    Private _dt_modificacao As String

    Public Property id_transvase_up() As Int32
        Get
            Return _id_transvase_up
        End Get
        Set(ByVal value As Int32)
            _id_transvase_up = value
        End Set
    End Property
    Public Property id_transvase() As Int32
        Get
            Return _id_transvase
        End Get
        Set(ByVal value As Int32)
            _id_transvase = value
        End Set
    End Property
    Public Property id_transvase_compartimento() As Int32
        Get
            Return _id_transvase_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_transvase_compartimento = value
        End Set
    End Property
    Public Property id_propriedade() As Int32
        Get
            Return _id_propriedade
        End Get
        Set(ByVal value As Int32)
            _id_propriedade = value
        End Set
    End Property
    Public Property id_unid_producao() As Int32
        Get
            Return _id_unid_producao
        End Get
        Set(ByVal value As Int32)
            _id_unid_producao = value
        End Set
    End Property
    Public Property nr_unid_producao() As Int32
        Get
            Return _nr_unid_producao
        End Get
        Set(ByVal value As Int32)
            _nr_unid_producao = value
        End Set
    End Property
    Public Property nr_litros() As Decimal
        Get
            Return _nr_litros
        End Get
        Set(ByVal value As Decimal)
            _nr_litros = value
        End Set
    End Property
    Public Property id_pre_romaneio() As Int32
        Get
            Return _id_pre_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_pre_romaneio = value
        End Set
    End Property
    Public Property id_romaneio_uproducao() As Int32
        Get
            Return _id_romaneio_uproducao
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_uproducao = value
        End Set
    End Property
    Public Property ds_propriedade() As String
        Get
            Return _ds_propriedade
        End Get
        Set(ByVal value As String)
            _ds_propriedade = value
        End Set
    End Property
    Public Property ds_uproducao() As String
        Get
            Return _ds_uproducao
        End Get
        Set(ByVal value As String)
            _ds_uproducao = value
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
    Public Property ds_produtor() As String
        Get
            Return _ds_produtor
        End Get
        Set(ByVal value As String)
            _ds_produtor = value
        End Set
    End Property
    Public Property dt_coleta() As String
        Get
            Return _dt_coleta
        End Get
        Set(ByVal value As String)
            _dt_coleta = value
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
    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
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
    Public Property dt_modificacao() As String
        Get
            Return _dt_modificacao
        End Get
        Set(ByVal value As String)
            _dt_modificacao = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Int32)

        Me.id_transvase_up = id
        loadTransvaseUP()

    End Sub
    Public Function getTransvaseUPByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransvaseUP", parameters, "ms_transvase_up")
            Return dataSet

        End Using

    End Function

    Private Sub loadTransvaseUP()

        Dim dataSet As DataSet = getTransvaseUPByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updateTransvaseUP()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateTransvaseUP", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Sub updateTransvasePreRomaneioVolumeRetirar()
        Try
            Using data As New DataAccess

                Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
                data.Execute("ms_updateTransvasePreRomaneioVolumeRetirar", parameters, ExecuteType.Update)

            End Using

        Catch err As Exception
            Throw New Exception(err.Message)
        End Try

    End Sub
    Public Sub updateTransvasePreRomaneioVolumeAdicionar()
        Try
            Using data As New DataAccess

                Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
                data.Execute("ms_updateTransvasePreRomaneioVolumeAdicionar", parameters, ExecuteType.Update)

            End Using
        Catch err As Exception
            Throw New Exception(err.Message)
        End Try

    End Sub
    Public Function getTransvaseUPSomaVolume() As Integer

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getTransvaseUPSomaVolume", parameters, ExecuteType.Select), Integer)

        End Using
    End Function
    Public Function insertTransvaseUP() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertTransvaseUP", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
End Class
