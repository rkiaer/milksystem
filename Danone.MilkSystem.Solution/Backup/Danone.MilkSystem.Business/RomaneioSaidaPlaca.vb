Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class RomaneioSaidaPlaca
    Private _id_romaneio_saida_placa As Int32
    Private _id_romaneio_saida As Int32
    Private _ds_placa As String
    Private _st_placa_principal As String
    Private _nr_total_volume As Decimal
    Private _dt_ini_carga As String
    Private _dt_fim_carga As String
    Private _nr_silo1 As Int32
    Private _nr_silo2 As Int32
    Private _id_nr_silo1 As Int32
    Private _id_nr_silo2 As Int32
    Private _nm_silo1 As String
    Private _nm_silo2 As String
    Private _dt_ini_CIP As String
    Private _dt_fim_CIP As String
    Private _nr_ph_solucao As String
    Private _id_criacao As Int32
    Private _id_modificador As Int32
    Private _dt_criacao As String
    Private _dt_modificacao As String

    Public Property id_romaneio_saida() As Int32
        Get
            Return _id_romaneio_saida
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_saida = value
        End Set
    End Property
    Public Property id_romaneio_saida_placa() As Int32
        Get
            Return _id_romaneio_saida_placa
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_saida_placa = value
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
    Public Property st_placa_principal() As String
        Get
            Return _st_placa_principal
        End Get
        Set(ByVal value As String)
            _st_placa_principal = value
        End Set
    End Property

    Public Property nr_total_volume() As Decimal
        Get
            Return _nr_total_volume
        End Get
        Set(ByVal value As Decimal)
            _nr_total_volume = value
        End Set
    End Property
    Public Property dt_ini_carga() As String
        Get
            Return _dt_ini_carga
        End Get
        Set(ByVal value As String)
            _dt_ini_carga = value
        End Set
    End Property
    Public Property dt_fim_carga() As String
        Get
            Return _dt_fim_carga
        End Get
        Set(ByVal value As String)
            _dt_fim_carga = value
        End Set
    End Property
    Public Property id_nr_silo1() As Int32
        Get
            Return _id_nr_silo1
        End Get
        Set(ByVal value As Int32)
            _id_nr_silo1 = value
        End Set
    End Property
    Public Property id_nr_silo2() As Int32
        Get
            Return _id_nr_silo2
        End Get
        Set(ByVal value As Int32)
            _id_nr_silo2 = value
        End Set
    End Property
    Public Property nr_silo1() As Int32
        Get
            Return _nr_silo1
        End Get
        Set(ByVal value As Int32)
            _nr_silo1 = value
        End Set
    End Property
    Public Property nr_silo2() As Int32
        Get
            Return _nr_silo2
        End Get
        Set(ByVal value As Int32)
            _nr_silo2 = value
        End Set
    End Property
    Public Property nm_silo1() As String
        Get
            Return _nm_silo1
        End Get
        Set(ByVal value As String)
            _nm_silo1 = value
        End Set
    End Property
    Public Property nm_silo2() As String
        Get
            Return _nm_silo2
        End Get
        Set(ByVal value As String)
            _nm_silo2 = value
        End Set
    End Property
    Public Property dt_ini_CIP() As String
        Get
            Return _dt_ini_CIP
        End Get
        Set(ByVal value As String)
            _dt_ini_CIP = value
        End Set
    End Property
    Public Property dt_fim_CIP() As String
        Get
            Return _dt_fim_CIP
        End Get
        Set(ByVal value As String)
            _dt_fim_CIP = value
        End Set
    End Property
    Public Property nr_ph_solucao() As Decimal
        Get
            Return _nr_ph_solucao
        End Get
        Set(ByVal value As Decimal)
            _nr_ph_solucao = value
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

        Me._id_romaneio_saida_placa = id
        loadRomaneioSaidaPlaca()

    End Sub

    Public Function getRomaneioSaidaPlacasByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaPlacas", parameters, "ms_romaneio_saida_placa")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioSaidaPlacasByRomaneio() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioSaidaPlacasbyRomaneio", parameters, "ms_romaneio_saida_placa")
            Return dataSet

        End Using

    End Function
    Private Sub loadRomaneioSaidaPlaca()

        Dim dataSet As DataSet = getRomaneioSaidaPlacasByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub


    Public Function insertRomaneioPlaca() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertRomaneioPlaca", parameters, ExecuteType.Insert), Int32)

        End Using
    End Function
    Public Sub updateRomaneioPlaca()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioPlaca", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getRomaneioPlacasNulasByRomaneio() As Int32
        Using data As New DataAccess
            'Busca as placas do romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioPlacasNulasByRomaneio", parameters, ExecuteType.Select), Int32)

        End Using

    End Function
    Public Function getRomaneioCompartimentosSomaVolumeByPlaca() As Decimal
        Using data As New DataAccess
            'Busca as placas do romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentosSomaVolumeByPlaca", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getRomaneioCompartimentosSomaVolumeRejeitadoByPlaca() As Decimal
        Using data As New DataAccess
            'Busca as placas do romaneio
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentosSomaVolumeRejeitadoByPlaca", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function

End Class
