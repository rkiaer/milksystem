Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class PrecoObjetivo

    Private _id_preco_objetivo As Int32
    Private _nr_preco_base(11) As Decimal
    Private _nr_adic_regiao(11) As Decimal
    Private _nr_adic_mercado(11) As Decimal
    '15/08/2008 - i
    'Private _nr_adic_volume(59) As Decimal
    'Private _id_faixa_volume(4) As Int32
    'Private _id_faixa_volume() As Int32
    Private _nr_adic_volume As New ArrayList
    Private _id_faixa_volume As New ArrayList
    Private _st_insert_adic_volume As Boolean
    '15/08/2008 - i
    Private _nr_faixas As Int32
    Private _nr_ano As String
    Private _nr_mes As String
    Private _id_tecnico As Int32
    Private _nm_tecnico As String
    Private _id_situacao As Int32
    Private _id_modificador As Int32
    Private _dt_modificacao As String

    Public Property id_preco_objetivo() As Int32
        Get
            Return _id_preco_objetivo
        End Get
        Set(ByVal value As Int32)
            _id_preco_objetivo = value
        End Set
    End Property

    Public Property nr_preco_base() As Decimal()
        Get
            Return _nr_preco_base
        End Get
        Set(ByVal value() As Decimal)
            _nr_preco_base = value
        End Set
    End Property

    Public Property nr_adic_regiao() As Decimal()
        Get
            Return _nr_adic_regiao
        End Get
        Set(ByVal value As Decimal())
            _nr_adic_regiao = value
        End Set
    End Property

    Public Property nr_adic_mercado() As Decimal()
        Get
            Return _nr_adic_mercado
        End Get
        Set(ByVal value As Decimal())
            _nr_adic_mercado = value
        End Set
    End Property

    'Public Property nr_adic_volume() As Decimal()
    '    Get
    '        Return _nr_adic_volume
    '    End Get
    '    Set(ByVal value As Decimal())
    '        _nr_adic_volume = value
    '    End Set
    'End Property
    Public Property nr_adic_volume() As ArrayList
        Get
            Return _nr_adic_volume
        End Get
        Set(ByVal value As ArrayList)
            _nr_adic_volume = value
        End Set
    End Property

    'Public Property id_faixa_volume() As Int32()
    '    Get
    '        Return _id_faixa_volume
    '    End Get
    '    Set(ByVal value As Int32())
    '        _id_faixa_volume = value
    '    End Set
    'End Property
    Public Property id_faixa_volume() As ArrayList
        Get
            Return _id_faixa_volume
        End Get
        Set(ByVal value As ArrayList)
            _id_faixa_volume = value
        End Set
    End Property

    Public Property nr_faixas() As Int32
        Get
            Return _nr_faixas
        End Get
        Set(ByVal value As Int32)
            _nr_faixas = value
        End Set
    End Property

    Public Property nr_ano() As String
        Get
            Return _nr_ano
        End Get
        Set(ByVal value As String)
            _nr_ano = value
        End Set
    End Property
    Public Property nr_mes() As String
        Get
            Return _nr_mes
        End Get
        Set(ByVal value As String)
            _nr_mes = value
        End Set
    End Property

    Public Property id_tecnico() As Int32
        Get
            Return _id_tecnico
        End Get
        Set(ByVal value As Int32)
            _id_tecnico = value
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
    Public Property st_insert_adic_volume() As Boolean
        Get
            Return _st_insert_adic_volume
        End Get
        Set(ByVal value As Boolean)
            _st_insert_adic_volume = value
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

        Me.id_preco_objetivo = id
        loadPrecoObjetivo()

    End Sub

    Public Function getPrecoObjetivoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPrecosObjetivos", parameters, "ms_preco_objetivo")
            Return dataSet

        End Using

    End Function

    Public Function getPrecoBase() As DataSet

        Using data As New DataAccess

            Dim precobase As New PrecoBase
            precobase.id_preco_objetivo = Me.id_preco_objetivo

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(precobase)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPrecosBase", parameters, "ms_preco_base")
            Return dataSet

        End Using

    End Function

    Public Function getAdicionalRegiao() As DataSet

        Using data As New DataAccess

            Dim adicregiao As New PrecoAdicionalRegiao
            adicregiao.id_preco_objetivo = Me.id_preco_objetivo

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(adicregiao)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAdicionaisRegiao", parameters, "ms_adicional_regiao")
            Return dataSet

        End Using

    End Function

    Public Function getAdicionalMercado() As DataSet

        Using data As New DataAccess

            Dim adicmercado As New PrecoAdicionalMercado
            adicmercado.id_preco_objetivo = Me.id_preco_objetivo

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(adicmercado)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAdicionaisMercado", parameters, "ms_adicional_mercado")
            Return dataSet

        End Using

    End Function

    Public Function getAdicionalVolume() As DataSet

        Using data As New DataAccess

            Dim adicvolume As New PrecoAdicionalVolume
            adicvolume.id_preco_objetivo = Me.id_preco_objetivo

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(adicvolume)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getAdicionaisVolume", parameters, "ms_adicional_volume")
            Return dataSet

        End Using

    End Function

    Private Sub loadPrecoObjetivo()

        'Carrega preco objetivo
        Dim dsPrecoObjetivo As DataSet = getPrecoObjetivoByFilters()
        ParametersEngine.persistObjectValues(dsPrecoObjetivo.Tables(0).Rows(0), Me)

        'Carrega preco base
        Dim dsPrecoBase As DataSet = getPrecoBase()
        Dim precobase As New PrecoBase()
        For i As Int32 = 0 To dsPrecoBase.Tables(0).Rows.Count - 1
            ParametersEngine.persistObjectValues(dsPrecoBase.Tables(0).Rows(i), precobase)
            nr_preco_base(i) = precobase.nr_preco_base
        Next

        'Carrega adicional regiao
        Dim dsAdicionalRegiao As DataSet = getAdicionalRegiao()
        Dim adicregiao As New PrecoAdicionalRegiao()
        For i As Int32 = 0 To dsAdicionalRegiao.Tables(0).Rows.Count - 1
            ParametersEngine.persistObjectValues(dsAdicionalRegiao.Tables(0).Rows(i), adicregiao)
            nr_adic_regiao(i) = adicregiao.nr_adic_regiao
        Next

        'Carrega adicional mercado
        Dim dsAdicionalMercado As DataSet = getAdicionalMercado()
        Dim adicmercado As New PrecoAdicionalMercado()
        For i As Int32 = 0 To dsAdicionalMercado.Tables(0).Rows.Count - 1
            ParametersEngine.persistObjectValues(dsAdicionalMercado.Tables(0).Rows(i), adicmercado)
            nr_adic_mercado(i) = adicmercado.nr_adic_mercado
        Next

        'Carrega adicional volume
        Dim dsAdicionalVolume As DataSet = getAdicionalVolume()
  
        ' 15/08/2008 - i 
        If dsAdicionalVolume.Tables(0).Rows.Count > 0 Then
            id_faixa_volume.Add(Convert.ToInt32(dsAdicionalVolume.Tables(0).Rows(0).Item("id_faixa_volume")))
        End If

        'Dim adicvolume As New PrecoAdicionalVolume()
        'For i As Int32 = 0 To dsAdicionalVolume.Tables(0).Rows.Count - 1
        '    ParametersEngine.persistObjectValues(dsAdicionalVolume.Tables(0).Rows(i), adicvolume)
        '    nr_adic_volume(i) = adicvolume.nr_adic_volume

        '    Select Case i
        '        Case 0
        '            id_faixa_volume(0) = adicvolume.id_faixa_volume
        '        Case 12
        '            id_faixa_volume(1) = adicvolume.id_faixa_volume
        '        Case 24
        '            id_faixa_volume(2) = adicvolume.id_faixa_volume
        '        Case 36
        '            id_faixa_volume(3) = adicvolume.id_faixa_volume
        '        Case 48
        '            id_faixa_volume(4) = adicvolume.id_faixa_volume
        '    End Select

        'Next

        'nr_faixas = (dsAdicionalVolume.Tables(0).Rows.Count / 12)
        ' 15/08/2008 - f


    End Sub


    Public Function insertPrecoObjetivo()

        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Try

            Dim parameters As List(Of Parameters)

            'Insere preco objetivo
            parameters = ParametersEngine.getParametersFromObject(Me)

            Me.id_preco_objetivo = CType(transacao.ExecuteScalar("ms_insertPrecosObjetivos", parameters, ExecuteType.Insert), Int32)

            'fran 07/2018 DANGO 2018 i - desabilitar deve ficar apenas adicional de mercado
            'Insere preco base
            'Dim precobase As New PrecoBase()
            'precobase.id_preco_objetivo = Me.id_preco_objetivo
            'precobase.id_modificador = Me.id_modificador
            'precobase.id_situacao = Me.id_situacao
            'For i As Int32 = 0 To 11
            '    precobase.nr_preco_base = nr_preco_base(i)
            '    precobase.nr_mes = Microsoft.VisualBasic.Right("0" & (i + 1).ToString(), 2)
            '    parameters = ParametersEngine.getParametersFromObject(precobase)
            '    transacao.Execute("ms_insertPrecosBase", parameters, ExecuteType.Insert)
            'Next

            ''Insere adicional região
            'Dim adicregiao As New PrecoAdicionalRegiao()
            'adicregiao.id_preco_objetivo = Me.id_preco_objetivo
            'adicregiao.id_modificador = Me.id_modificador
            'adicregiao.id_situacao = Me.id_situacao
            'For i As Int32 = 0 To 11
            '    adicregiao.nr_adic_regiao = nr_adic_regiao(i)
            '    adicregiao.nr_mes = Microsoft.VisualBasic.Right("0" & (i + 1).ToString(), 2)
            '    parameters = ParametersEngine.getParametersFromObject(adicregiao)
            '    transacao.Execute("ms_insertAdicionaisRegiao", parameters, ExecuteType.Insert)
            'Next
            'fran 07/2018 DANGO 2018 f - desabilitar deve ficar apenas adicional de mercado

            'Insere adicional mercado
            Dim adicmercado As New PrecoAdicionalMercado()
            adicmercado.id_preco_objetivo = Me.id_preco_objetivo
            adicmercado.id_modificador = Me.id_modificador
            adicmercado.id_situacao = Me.id_situacao
            For i As Int32 = 0 To 11
                adicmercado.nr_adic_mercado = nr_adic_mercado(i)
                adicmercado.nr_mes = Microsoft.VisualBasic.Right("0" & (i + 1).ToString(), 2)
                parameters = ParametersEngine.getParametersFromObject(adicmercado)
                transacao.Execute("ms_insertAdicionaisMercado", parameters, ExecuteType.Insert)
            Next

            'fran 07/2018 DANGO 2018 i - desabilitar deve ficar apenas adicional de mercado

            ''Insere adicional volume
            'Dim adicvolume As New PrecoAdicionalVolume()
            'adicvolume.id_preco_objetivo = Me.id_preco_objetivo
            'adicvolume.id_modificador = Me.id_modificador
            'adicvolume.id_situacao = Me.id_situacao

            'Dim index As Int32 = 0

            'For i As Int32 = 0 To nr_faixas - 1

            '    adicvolume.id_faixa_volume = Me.id_faixa_volume(i)
            '    adicvolume.nr_mes = Me.nr_mes
            '    adicvolume.nr_adic_volume = nr_adic_volume(i)
            '    parameters = ParametersEngine.getParametersFromObject(adicvolume)
            '    transacao.Execute("ms_insertAdicionaisVolume", parameters, ExecuteType.Insert)

            '    '    adicvolume.id_faixa_volume = id_faixa_volume(i)
            '    '    For j As Int32 = 0 To 11
            '    '        adicvolume.nr_adic_volume = nr_adic_volume(index)
            '    '        adicvolume.nr_mes = Microsoft.VisualBasic.Right("0" & (j + 1).ToString(), 2)
            '    '        parameters = ParametersEngine.getParametersFromObject(adicvolume)
            '    '        transacao.Execute("ms_insertAdicionaisVolume", parameters, ExecuteType.Insert)
            '    '        index += 1
            '    '    Next

            'Next
            'fran 07/2018 DANGO 2018 f - desabilitar deve ficar apenas adicional de mercado


            transacao.Commit()
            Return Me.id_preco_objetivo

        Catch ex As Exception
            transacao.RollBack()
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Sub updatePrecoObjetivo()

        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Try

            Dim parameters As List(Of Parameters)

            'Atualiza preço objetivo
            parameters = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_updatePrecosObjetivos", parameters, ExecuteType.Update)

            'fran 07/2018 DANGO 2018 i - desabilitar deve ficar apenas adicional de mercado
            'Atualiza preço base
            'Dim precobase As New PrecoBase()
            'precobase.id_preco_objetivo = Me.id_preco_objetivo
            'precobase.id_modificador = Me.id_modificador
            'precobase.id_situacao = Me.id_situacao
            'For i As Int32 = 0 To nr_preco_base.Length - 1
            '    precobase.nr_preco_base = nr_preco_base(i)
            '    precobase.nr_mes = Microsoft.VisualBasic.Right("0" & (i + 1).ToString(), 2)
            '    parameters = ParametersEngine.getParametersFromObject(precobase)
            '    transacao.Execute("ms_updatePrecosBase", parameters, ExecuteType.Update)
            'Next

            ''Atualiza adicional regiao
            'Dim adicregiao As New PrecoAdicionalRegiao()
            'adicregiao.id_preco_objetivo = Me.id_preco_objetivo
            'adicregiao.id_modificador = Me.id_modificador
            'adicregiao.id_situacao = Me.id_situacao
            'For i As Int32 = 0 To nr_adic_regiao.Length - 1
            '    adicregiao.nr_adic_regiao = nr_adic_regiao(i)
            '    adicregiao.nr_mes = Microsoft.VisualBasic.Right("0" & (i + 1).ToString(), 2)
            '    parameters = ParametersEngine.getParametersFromObject(adicregiao)
            '    transacao.Execute("ms_updateAdicionaisRegiao", parameters, ExecuteType.Update)
            'Next
            ''fran 07/2018 DANGO 2018 i - desabilitar deve ficar apenas adicional de mercado

            'Atualiza adicional mercado
            Dim adicmercado As New PrecoAdicionalMercado()
            adicmercado.id_preco_objetivo = Me.id_preco_objetivo
            adicmercado.id_modificador = Me.id_modificador
            adicmercado.id_situacao = Me.id_situacao
            For i As Int32 = 0 To nr_adic_mercado.Length - 1
                adicmercado.nr_adic_mercado = nr_adic_mercado(i)
                adicmercado.nr_mes = Microsoft.VisualBasic.Right("0" & (i + 1).ToString(), 2)
                parameters = ParametersEngine.getParametersFromObject(adicmercado)
                transacao.Execute("ms_updateAdicionaisMercado", parameters, ExecuteType.Update)
            Next

            'fran 07/2018 DANGO 2018 i - desabilitar deve ficar apenas adicional de mercado
            '' 15/08/2008 - Atualiza adicional volume
            'Dim adicvolume As New PrecoAdicionalVolume()
            'adicvolume.id_preco_objetivo = Me.id_preco_objetivo
            'adicvolume.id_modificador = Me.id_modificador
            'adicvolume.id_situacao = Me.id_situacao
            'adicvolume.nr_mes = Me.nr_mes

            '' 19/02/2009 - Rls16 (Chamado 106 - Duplicidade de volumes se dois usuários alterando ao mesmo tempo) - i
            'parameters = ParametersEngine.getParametersFromObject(adicvolume)
            'transacao.Execute("ms_deleteAdicionaisVolumeTodos", parameters, ExecuteType.Insert)  ' Deleta todas as linhas do mes
            '' 19/02/2009 - Rls16 (Chamado 106 - Duplicidade de volumes se dois usuários alterando ao mesmo tempo) - f

            'Dim index As Int32 = 0
            'For i As Int32 = 0 To nr_faixas - 1

            '    adicvolume.id_faixa_volume = Me.id_faixa_volume(i)
            '    adicvolume.nr_adic_volume = nr_adic_volume(i)
            '    parameters = ParametersEngine.getParametersFromObject(adicvolume)
            '    ' 19/02/2009 - Rls16 (Chamado 106 - Duplicidade de volumes se dois usuários alterando ao mesmo tempo) - i
            '    'If Me.st_insert_adic_volume = True Then  ' Se é um novo mes/Grupo Faixas
            '    '    transacao.Execute("ms_insertAdicionaisVolume", parameters, ExecuteType.Insert)
            '    'Else
            '    '    transacao.Execute("ms_updateAdicionaisVolume", parameters, ExecuteType.Update)
            '    'End If
            '    transacao.Execute("ms_insertAdicionaisVolume", parameters, ExecuteType.Insert)
            '    ' 19/02/2009 - Rls16 (Chamado 106 - Duplicidade de volumes se dois usuários alterando ao mesmo tempo) - f

            'Next
            'fran 07/2018 DANGO 2018 f - desabilitar deve ficar apenas adicional de mercado

            transacao.Commit()
        Catch ex As Exception
            transacao.RollBack()
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub deletePrecoObjetivo()

        Dim transacao As New DataAccess

        transacao.StartTransaction()

        Try

            Dim parameters As List(Of Parameters)

            'Desativa preco objetivo
            parameters = ParametersEngine.getParametersFromObject(Me)
            transacao.Execute("ms_deletePrecosObjetivos", parameters, ExecuteType.Delete)

            'Desativa preco base
            Dim precobase As New PrecoBase()
            precobase.id_preco_objetivo = Me.id_preco_objetivo
            precobase.id_modificador = Me.id_modificador
            parameters = ParametersEngine.getParametersFromObject(precobase)
            transacao.Execute("ms_deletePrecosBase", parameters, ExecuteType.Delete)

            'Desativa adicional regiao
            Dim adicregiao As New PrecoAdicionalRegiao()
            adicregiao.id_preco_objetivo = Me.id_preco_objetivo
            adicregiao.id_modificador = Me.id_modificador
            parameters = ParametersEngine.getParametersFromObject(adicregiao)
            transacao.Execute("ms_deleteAdicionaisRegiao", parameters, ExecuteType.Delete)

            'Desativa adicional mercado
            Dim adicmercado As New PrecoAdicionalMercado()
            adicmercado.id_preco_objetivo = Me.id_preco_objetivo
            adicmercado.id_modificador = Me.id_modificador
            parameters = ParametersEngine.getParametersFromObject(adicmercado)
            transacao.Execute("ms_deleteAdicionaisMercado", parameters, ExecuteType.Delete)

            'Desativa adicional volume
            Dim adicvolume As New PrecoAdicionalVolume()
            adicvolume.id_preco_objetivo = Me.id_preco_objetivo
            adicvolume.id_modificador = Me.id_modificador
            parameters = ParametersEngine.getParametersFromObject(adicvolume)
            transacao.Execute("ms_deleteAdicionaisVolume", parameters, ExecuteType.Delete)

            transacao.Commit()
        Catch ex As Exception
            transacao.RollBack()
            Throw New Exception(ex.Message)
        End Try

    End Sub

End Class