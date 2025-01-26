Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools


<Serializable()> Public Class FaixaVolume

    Private _id_faixa_volume As Int32
    Private _nm_faixa_volume As String
    Private _nr_faixa_inicio As Decimal
    Private _nr_faixa_fim As Decimal
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _nr_grupo_faixas As Int32
    Private _nm_grupo_faixas As String
    Private _fxs_nm_faixa As ArrayList
    Private _fxs_nr_inicio As ArrayList
    Private _fxs_nr_fim As ArrayList


    Public Property id_modificador() As Int32
        Get
            Return _id_modificador
        End Get
        Set(ByVal value As Int32)
            _id_modificador = value
        End Set
    End Property
    Public Property id_faixa_volume() As Int32
        Get
            Return _id_faixa_volume
        End Get
        Set(ByVal value As Int32)
            _id_faixa_volume = value
        End Set
    End Property

    Public Property fxs_nm_faixa() As ArrayList
        Get
            Return _fxs_nm_faixa
        End Get
        Set(ByVal value As ArrayList)
            _fxs_nm_faixa = value
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
    Public Property nm_faixa_volume() As String
        Get
            Return _nm_faixa_volume
        End Get
        Set(ByVal value As String)
            _nm_faixa_volume = value
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
    Public Property nr_grupo_faixas() As Int32
        Get
            Return _nr_grupo_faixas
        End Get
        Set(ByVal value As Int32)
            _nr_grupo_faixas = value
        End Set
    End Property
    Public Property nm_grupo_faixas() As String
        Get
            Return _nm_grupo_faixas
        End Get
        Set(ByVal value As String)
            _nm_grupo_faixas = value
        End Set
    End Property

    Public Sub New(ByVal id As Int32)

        Me.id_faixa_volume = id
        loadFaixaVolume()

    End Sub

    Public Sub New()

    End Sub

    Public Function getFaixaVolumeByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFaixasVolume", parameters, "ms_zfaixa_volume")
            Return dataSet

        End Using

    End Function
    Public Function getFaixaVolumeGrupos() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFaixasVolumeGrupos", parameters, "ms_zfaixa_volume")
            Return dataSet

        End Using

    End Function

    Public Function getFaixaVolumeByRange() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getFaixasVolumeByRange", parameters, "ms_zfaixa_volume")
            Return dataSet

        End Using

    End Function

    Private Sub loadFaixaVolume()

        Dim dataSet As DataSet = getFaixaVolumeByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub
    Function insertGrupoFaixasVolume()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction(IsolationLevel.RepeatableRead)
        Try
            'Pega os parametros para inclusão faixas
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Pega o nr grupo
            Me.nr_grupo_faixas = CType(transacao.ExecuteScalar("ms_getFaixaVolumeMaxNrGrupo", parameters, ExecuteType.Select), Int32)


            For i As Integer = 0 To fxs_nm_faixa.Count - 1
                Me.nm_faixa_volume = Me.fxs_nm_faixa(i).ToString
                Me.nr_faixa_inicio = Me.fxs_nr_inicio(i)
                Me.nr_faixa_fim = Me.fxs_nr_fim(i)
                'Pega os parametros 
                Dim param As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
                transacao.Execute("ms_insertGrupoFaixaVolume", param, ExecuteType.Insert)
            Next

            'Comita
            transacao.Commit()
            Return Me.nr_grupo_faixas
        Catch err As Exception
            transacao.RollBack()
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Sub deleteGrupoFaixaVolume()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_deleteFaixaVolume", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub updateFaixaVolume()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateGrupoFaixaVolume", parameters, ExecuteType.Update)

        End Using

    End Sub
End Class
