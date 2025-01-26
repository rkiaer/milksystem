Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class TransitPointCompartimento

    Private _id_transit_point_compartimento As Int32
    Private _id_transit_point As Int32
    Private _id_transit_point_veiculo As Int32
    Private _ds_placa As String
    Private _id_veiculo As Int32
    Private _id_compartimento As Int32
    Private _nr_compartimento As Int32
    Private _nm_compartimento As String
    Private _ds_compartimento As String
    Private _nr_total_litros As Decimal
    Private _nr_volume_maximo As Decimal
    Private _id_situacao As Int32
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String
    Public Property id_transit_point_compartimento() As Int32
        Get
            Return _id_transit_point_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_transit_point_compartimento = value
        End Set
    End Property
    Public Property id_transit_point() As Int32
        Get
            Return _id_transit_point
        End Get
        Set(ByVal value As Int32)
            _id_transit_point = value
        End Set
    End Property
    Public Property id_transit_point_veiculo() As Int32
        Get
            Return _id_transit_point_veiculo
        End Get
        Set(ByVal value As Int32)
            _id_transit_point_veiculo = value
        End Set
    End Property
    Public Property id_compartimento() As Int32
        Get
            Return _id_compartimento
        End Get
        Set(ByVal value As Int32)
            _id_compartimento = value
        End Set
    End Property
    Public Property id_veiculo() As Int32
        Get
            Return _id_veiculo
        End Get
        Set(ByVal value As Int32)
            _id_veiculo = value
        End Set
    End Property

    Public Property nr_compartimento() As Int32
        Get
            Return _nr_compartimento
        End Get
        Set(ByVal value As Int32)
            _nr_compartimento = value
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

    Public Property nr_total_litros() As Decimal
        Get
            Return _nr_total_litros
        End Get
        Set(ByVal value As Decimal)
            _nr_total_litros = value
        End Set
    End Property
    Public Property nr_volume_maximo() As Decimal
        Get
            Return _nr_volume_maximo
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_maximo = value
        End Set
    End Property
    Public Property ds_compartimento() As String
        Get
            Return _ds_compartimento
        End Get
        Set(ByVal value As String)
            _ds_compartimento = value
        End Set
    End Property
    Public Property nm_compartimento() As String
        Get
            Return _nm_compartimento
        End Get
        Set(ByVal value As String)
            _nm_compartimento = value
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
  

    Public Sub New()

    End Sub


    Public Sub New(ByVal id As Int32)

        Me._id_transit_point_compartimento = id
        loadTransitPointCompartimento()

    End Sub

    Public Function getTransitPointCompartimentoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getTransitPointCompartimento", parameters, "ms_transit_point_compartimento")
            Return dataSet

        End Using

    End Function
    Public Function getTransitPointConsQtdeCompartimentobyVeiculo() As Int64
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getTransitPointConsQtdeCompartimentobyVeiculo", parameters, ExecuteType.Select), Int64)

        End Using

    End Function
    Private Sub loadTransitPointCompartimento()

        Dim dataSet As DataSet = getTransitPointCompartimentoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Sub updateRomaneioCompartimentoReajuste()

        Using data As New DataAccess

            'Fran 30/09/2008 i - Transação
            Dim transacao As New DataAccess
            'Inicia Transação
            transacao.StartTransaction(IsolationLevel.RepeatableRead)
            Try
                'Pega os parametros para atualização romaneio
                Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

                transacao.Execute("ms_updateRomaneioCompartimentoReajuste", parameters, ExecuteType.Update)
                transacao.Execute("ms_updateRomaneioSomaVolumeCompartimentosbyRomaneio", parameters, ExecuteType.Update)

                'Comita
                transacao.Commit()
            Catch err As Exception
                transacao.RollBack()
                Throw New Exception(err.Message)
            End Try

        End Using

    End Sub
    Public Function insertTransitPointCompartimento() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertTransitPointCompartimento", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Sub deleteTransitPointCompartimento()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteTransitPointCompartimento", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Function getAjusteExcedeuVolume() As Integer

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioCompAjusteExcedeuVolume", parameters, ExecuteType.Select), Integer)

        End Using
    End Function
End Class
