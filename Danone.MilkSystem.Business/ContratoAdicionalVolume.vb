Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ContratoAdicionalVolume

    Private _id_contrato_adicional_volume As Int32
    Private _id_contrato_validade As Int32
    Private _nr_litros As Int32
    Private _nr_litros_ini As Int32
    Private _nr_litros_fim As Int32
    Private _nr_indicador_percentual As Decimal
    Private _id_indicador_tipo As Int32
    Private _nr_mes_indicador As Int32
    Private _nr_adicional_24hrs As Decimal
    Private _st_formato_24hrs As String
    Private _nr_adicional_48hrs As Decimal
    Private _st_formato_48hrs As String
    Private _ds_validade As String
    Private _dt_referencia As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String
    Private _id_estabelecimento As Int32
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property id_contrato_adicional_volume() As Int32
        Get
            Return _id_contrato_adicional_volume
        End Get
        Set(ByVal value As Int32)
            _id_contrato_adicional_volume = value
        End Set
    End Property
    Public Property id_contrato_validade() As Int32
        Get
            Return _id_contrato_validade
        End Get
        Set(ByVal value As Int32)
            _id_contrato_validade = value
        End Set
    End Property
    Public Property nr_litros_ini() As Int32
        Get
            Return _nr_litros_ini
        End Get
        Set(ByVal value As Int32)
            _nr_litros_ini = value
        End Set
    End Property
    Public Property nr_litros_fim() As Int32
        Get
            Return _nr_litros_fim
        End Get
        Set(ByVal value As Int32)
            _nr_litros_fim = value
        End Set
    End Property
    Public Property id_indicador_tipo() As Int32
        Get
            Return _id_indicador_tipo
        End Get
        Set(ByVal value As Int32)
            _id_indicador_tipo = value
        End Set
    End Property
    Public Property nr_mes_indicador() As Int32
        Get
            Return _nr_mes_indicador
        End Get
        Set(ByVal value As Int32)
            _nr_mes_indicador = value
        End Set
    End Property
    Public Property nr_indicador_percentual() As Decimal
        Get
            Return _nr_indicador_percentual
        End Get
        Set(ByVal value As Decimal)
            _nr_indicador_percentual = value
        End Set
    End Property
    Public Property nr_adicional_24hrs() As Decimal
        Get
            Return _nr_adicional_24hrs
        End Get
        Set(ByVal value As Decimal)
            _nr_adicional_24hrs = value
        End Set
    End Property
    Public Property nr_adicional_48hrs() As Decimal
        Get
            Return _nr_adicional_48hrs
        End Get
        Set(ByVal value As Decimal)
            _nr_adicional_48hrs = value
        End Set
    End Property
    Public Property st_formato_24hrs() As String
        Get
            Return _st_formato_24hrs
        End Get
        Set(ByVal value As String)
            _st_formato_24hrs = value
        End Set
    End Property
    Public Property st_formato_48hrs() As String
        Get
            Return _st_formato_48hrs
        End Get
        Set(ByVal value As String)
            _st_formato_48hrs = value
        End Set
    End Property
    Public Property ds_validade() As String
        Get
            Return _ds_validade
        End Get
        Set(ByVal value As String)
            _ds_validade = value
        End Set
    End Property
    Public Property dt_referencia() As String
        Get
            Return _dt_referencia
        End Get
        Set(ByVal value As String)
            _dt_referencia = value
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
    Public Property nr_litros() As Int32
        Get
            Return _nr_litros
        End Get
        Set(ByVal value As Int32)
            _nr_litros = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me._id_contrato_adicional_volume = id
        loadContratoAdicionalVolume()

    End Sub

    Public Sub New()

    End Sub

    Public Function getContratoAdicionalVolumeByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getContratoAdicionalVolume", parameters, "ms_contrato_adicional_volume")
            Return dataSet

        End Using

    End Function

    Private Sub loadContratoAdicionalVolume()

        Dim dataSet As DataSet = getContratoAdicionalVolumeByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertContratoAdicionalVolume() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_insertContratoAdicionalVolume", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateContratoAdicionalVolume()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateContratoAdicionalVolume", parameters, ExecuteType.Update)

        End Using

    End Sub

    Public Sub deleteContratoAdicionalVolume()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteContratoAdicionalVolume", parameters, ExecuteType.Delete)

        End Using


    End Sub

End Class
