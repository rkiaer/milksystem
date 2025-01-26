Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class GoldFaixaVolume

    Private _id_gold_faixa_volume As Int32
    Private _cd_gold_faixa_volume As Int32
    Private _id_estabelecimento As Int32
    Private _nm_gold_faixa_volume As String
    Private _ds_gold_faixa_volume As String
    Private _dt_referencia_inicial As String
    Private _dt_referencia_final As String
    Private _nr_faixa_inicio As Decimal
    Private _nr_faixa_fim As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _fxs_ds_faixa As ArrayList
    Private _fxs_nr_inicio As ArrayList
    Private _fxs_nr_fim As ArrayList
   
    Public Property cd_gold_faixa_volume() As Int32
        Get
            Return _cd_gold_faixa_volume
        End Get
        Set(ByVal value As Int32)
            _cd_gold_faixa_volume = value
        End Set
    End Property
    Public Property id_gold_faixa_volume() As Int32
        Get
            Return _id_gold_faixa_volume
        End Get
        Set(ByVal value As Int32)
            _id_gold_faixa_volume = value
        End Set
    End Property
    Public Property id_estabelecimento() As Int32
        Get
            Return _id_estabelecimento
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento = value
        End Set
    End Property
    Public Property dt_referencia_inicial() As String
        Get
            Return _dt_referencia_inicial
        End Get
        Set(ByVal value As String)
            _dt_referencia_inicial = value
        End Set
    End Property
    Public Property dt_referencia_final() As String
        Get
            Return _dt_referencia_final
        End Get
        Set(ByVal value As String)
            _dt_referencia_final = value
        End Set
    End Property
    Public Property nm_gold_faixa_volume() As String
        Get
            Return _nm_gold_faixa_volume
        End Get
        Set(ByVal value As String)
            _nm_gold_faixa_volume = value
        End Set
    End Property
    Public Property ds_gold_faixa_volume() As String
        Get
            Return _ds_gold_faixa_volume
        End Get
        Set(ByVal value As String)
            _ds_gold_faixa_volume = value
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

    Public Property fxs_ds_faixa() As ArrayList
        Get
            Return _fxs_ds_faixa
        End Get
        Set(ByVal value As ArrayList)
            _fxs_ds_faixa = value
        End Set
    End Property
    Public Property fxs_nr_inicio() As ArrayList
        Get
            Return _fxs_nr_inicio
        End Get
        Set(ByVal value As ArrayList)
            _fxs_nr_inicio = value
        End Set
    End Property
    Public Property fxs_nr_fim() As ArrayList
        Get
            Return _fxs_nr_fim
        End Get
        Set(ByVal value As ArrayList)
            _fxs_nr_fim = value
        End Set
    End Property

    Public Property nr_faixa_inicio() As Decimal
        Get
            Return _nr_faixa_inicio
        End Get
        Set(ByVal value As Decimal)
            _nr_faixa_inicio = value
        End Set
    End Property

    Public Property nr_faixa_fim() As Decimal
        Get
            Return _nr_faixa_fim
        End Get
        Set(ByVal value As Decimal)
            _nr_faixa_fim = value
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

    Public Sub New()

    End Sub
    Public Function getGoldFaixaVolumeGrupos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldFaixaVolumeGrupos", parameters, "ms_gold_faixa_volume")
            Return dataSet

        End Using

    End Function

    Public Function getGoldFaixaVolumeByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldFaixaVolume", parameters, "ms_gold_faixa_volume")
            Return dataSet

        End Using

    End Function
    Public Function getGoldFaixaVolumeByCodigo() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getGoldFaixaVolumebyCodigo", parameters, "ms_gold_faixa_volume")
            Return dataSet

        End Using

    End Function

    Function insertGrupoGoldFaixasVolume()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão faixas
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Pega o nr grupo
            Me.cd_gold_faixa_volume = CType(transacao.ExecuteScalar("ms_getGoldFaixaVolumeMaxNrGrupo", parameters, ExecuteType.Select), Int32)


            For i As Integer = 0 To fxs_ds_faixa.Count - 1
                Me.ds_gold_faixa_volume = Me.fxs_ds_faixa(i).ToString
                Me.nr_faixa_inicio = Me.fxs_nr_inicio(i)
                Me.nr_faixa_fim = Me.fxs_nr_fim(i)
                'Pega os parametros 
                Dim param As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_insertGoldFaixaVolume", param, ExecuteType.Insert)
            Next

            'Comita
            transacao.Commit()
            Return Me.cd_gold_faixa_volume
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Sub deleteGoldFaixaVolume()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteGoldFaixaVolume", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub updateGoldFaixaVolume()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGoldFaixaVolume", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
