Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class TipoEquipamento

    Private _id_tipo_equipamento As Int32
    Private _nr_eixo As Int32
    Private _nr_custo_fixo_km_min_t2 As Decimal
    Private _cd_tipo_equipamento As String
    Private _nm_tipo_equipamento As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_tipo_equipamento() As Int32
        Get
            Return _id_tipo_equipamento
        End Get
        Set(ByVal value As Int32)
            _id_tipo_equipamento = value
        End Set
    End Property
    Public Property nr_eixo() As Int32
        Get
            Return _nr_eixo
        End Get
        Set(ByVal value As Int32)
            _nr_eixo = value
        End Set
    End Property
    Public Property nr_custo_fixo_km_min_t2() As Decimal
        Get
            Return _nr_custo_fixo_km_min_t2
        End Get
        Set(ByVal value As Decimal)
            _nr_custo_fixo_km_min_t2 = value
        End Set
    End Property
    Public Property nm_tipo_equipamento() As String
        Get
            Return _nm_tipo_equipamento
        End Get
        Set(ByVal value As String)
            _nm_tipo_equipamento = value
        End Set
    End Property
    Public Property cd_tipo_equipamento() As String
        Get
            Return _cd_tipo_equipamento
        End Get
        Set(ByVal value As String)
            _cd_tipo_equipamento = value
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


    Public Sub New(ByVal id As Int32)

        Me.id_tipo_equipamento = id
        loadTipoEquipamento()

    End Sub

    Public Sub New()

    End Sub

    Public Function getTiposEquipamentosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTiposEquipamentos", parameters, "ms_tipo_equipamento")
            Return dataSet

        End Using

    End Function

    Private Sub loadTipoEquipamento()

        Dim dataSet As DataSet = getTiposEquipamentosByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Public Function insertTipoEquipamento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertTipoEquipamento", parameters, ExecuteType.Insert), Int32)

        End Using

    End Function

    Public Sub updateTipoEquipamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateTipoEquipamento", parameters, ExecuteType.Update)

        End Using

    End Sub


    Public Sub deleteTipoEquipamento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteTipoEquipamento", parameters, ExecuteType.Delete)

        End Using

    End Sub

End Class
