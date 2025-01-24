Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools

<Serializable()> Public Class ExportacaoFreteExecucao

    Private _id_exportacao_frete_execucao As Int32
    Private _id_exportacao_frete_execucao_itens As Int32
    Private _id_estabelecimento_filtro As Int32
    Private _dt_ini_filtro As String
    Private _dt_fim_filtro As String
    Private _id_romaneio_filtro As Int32
    Private _dt_ini_execucao As String
    Private _dt_fim_execucao As String
    Private _st_exportacao_frete_execucao As String
    Private _id_romaneio As Int32
    Private _id_estabelecimento As Int32
    Private _id_transportadora As Int32
    Private _ds_placa_frete As String
    Private _cd_tipo_equipamento As String
    Private _nm_arquivo As String
    Private _nm_arquivo2 As String
    Private _id_cooperativa As Int32
    Private _nr_caderneta As Int32
    Private _dt_ini_execucao_itens As String
    Private _dt_fim_execucao_itens As String
    Private _st_exportacao_frete_execucao_itens As String
    Private _id_modificador As Int32
    Private _id_criacao As Int32
    Private _cd_erro As String
    Private _nm_erro As String
    Private _st_exportacao_frete As String 'fran 20/12/2009
    Private _st_cooperativas As String 'fran 03/2017
    Public Property st_cooperativas() As String
        Get
            Return _st_cooperativas
        End Get
        Set(ByVal value As String)
            _st_cooperativas = value
        End Set
    End Property
    Public Property st_exportacao_frete() As String
        Get
            Return _st_exportacao_frete
        End Get
        Set(ByVal value As String)
            _st_exportacao_frete = value
        End Set
    End Property

    Public Property id_exportacao_frete_execucao() As Int32
        Get
            Return _id_exportacao_frete_execucao
        End Get
        Set(ByVal value As Int32)
            _id_exportacao_frete_execucao = value
        End Set
    End Property

    Public Property id_estabelecimento_filtro() As Int32
        Get
            Return _id_estabelecimento_filtro
        End Get
        Set(ByVal value As Int32)
            _id_estabelecimento_filtro = value
        End Set
    End Property
    Public Property dt_ini_filtro() As String
        Get
            Return _dt_ini_filtro
        End Get
        Set(ByVal value As String)
            _dt_ini_filtro = value
        End Set
    End Property
    Public Property dt_fim_filtro() As String
        Get
            Return _dt_fim_filtro
        End Get
        Set(ByVal value As String)
            _dt_fim_filtro = value
        End Set
    End Property

    Public Property id_romaneio_filtro() As Int32
        Get
            Return _id_romaneio_filtro
        End Get
        Set(ByVal value As Int32)
            _id_romaneio_filtro = value
        End Set
    End Property
    Public Property dt_ini_execucao() As String
        Get
            Return _dt_ini_execucao
        End Get
        Set(ByVal value As String)
            _dt_ini_execucao = value
        End Set
    End Property
    Public Property dt_fim_execucao() As String
        Get
            Return _dt_fim_execucao
        End Get
        Set(ByVal value As String)
            _dt_fim_execucao = value
        End Set
    End Property
    Public Property st_exportacao_frete_execucao() As String
        Get
            Return _st_exportacao_frete_execucao
        End Get
        Set(ByVal value As String)
            _st_exportacao_frete_execucao = value
        End Set
    End Property

    Public Property id_exportacao_frete_execucao_itens() As Int32
        Get
            Return _id_exportacao_frete_execucao_itens
        End Get
        Set(ByVal value As Int32)
            _id_exportacao_frete_execucao_itens = value
        End Set
    End Property
    Public Property id_romaneio() As Int32
        Get
            Return _id_romaneio
        End Get
        Set(ByVal value As Int32)
            _id_romaneio = value
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
    Public Property ds_placa_frete() As String
        Get
            Return _ds_placa_frete
        End Get
        Set(ByVal value As String)
            _ds_placa_frete = value
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
    Public Property id_transportadora() As Int32
        Get
            Return _id_transportadora
        End Get
        Set(ByVal value As Int32)
            _id_transportadora = value
        End Set
    End Property
    Public Property id_cooperativa() As Int32
        Get
            Return _id_cooperativa
        End Get
        Set(ByVal value As Int32)
            _id_cooperativa = value
        End Set
    End Property
    Public Property nr_caderneta() As Int32
        Get
            Return _nr_caderneta
        End Get
        Set(ByVal value As Int32)
            _nr_caderneta = value
        End Set
    End Property
    Public Property nm_arquivo() As String
        Get
            Return _nm_arquivo
        End Get
        Set(ByVal value As String)
            _nm_arquivo = value
        End Set
    End Property
    Public Property nm_arquivo2() As String
        Get
            Return _nm_arquivo2
        End Get
        Set(ByVal value As String)
            _nm_arquivo2 = value
        End Set
    End Property
    Public Property dt_ini_execucao_itens() As String
        Get
            Return _dt_ini_execucao_itens
        End Get
        Set(ByVal value As String)
            _dt_ini_execucao_itens = value
        End Set
    End Property
    Public Property dt_fim_execucao_itens() As String
        Get
            Return _dt_fim_execucao_itens
        End Get
        Set(ByVal value As String)
            _dt_fim_execucao_itens = value
        End Set
    End Property

    Public Property st_exportacao_frete_execucao_itens() As String
        Get
            Return _st_exportacao_frete_execucao_itens
        End Get
        Set(ByVal value As String)
            _st_exportacao_frete_execucao_itens = value
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
    Public Property id_criacao() As Int32
        Get
            Return _id_criacao
        End Get
        Set(ByVal value As Int32)
            _id_criacao = value
        End Set
    End Property
    Public Property cd_erro() As String
        Get
            Return _cd_erro
        End Get
        Set(ByVal value As String)
            _cd_erro = value
        End Set
    End Property
    Public Property nm_erro() As String
        Get
            Return _nm_erro
        End Get
        Set(ByVal value As String)
            _nm_erro = value
        End Set
    End Property

    Public Sub New(ByVal id As String)

        Me.id_exportacao_frete_execucao = id
        loadExportacaoFreteExecucao()

    End Sub
    'Public Function getCalculoStatusExecucao() As String
    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Return CType(data.ExecuteScalar("ms_getCalculoStatusExecucao", parameters, ExecuteType.Select), String)

    '    End Using
    'End Function
    Public Sub New()

    End Sub


    Public Function getExportacaoFreteExecucaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoFreteExecucao", parameters, "ms_exportacao_frete_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getExportacaoFreteExecucaoErrosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoFreteExecucaoErros", parameters, "ms_exportacao_frete_execucao_erro")
            Return dataSet

        End Using

    End Function
    Public Function getExportacaoFreteExecucaoItensByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoFreteExecucaoItens", parameters, "ms_exportacao_frete_execucao_itens")
            Return dataSet

        End Using

    End Function

    Private Sub loadExportacaoFreteExecucao()

        Dim dataSet As DataSet = getExportacaoFreteExecucaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertExportacaoFreteExecucaoItens() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertExportacaoFreteExecucaoItens", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateExportacaoFreteExecucao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateExportacaoFreteExecucao", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub updateExportacaoFreteExecucaoItens()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateExportacaoFreteExecucaoItens", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub updateFreteExportacaoStatusFinalizacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateFreteExportacaoStatusFinalizacao", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub deleteExportacaoFreteExecucaoItensRealizadas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_deleteExportacaoFreteExecucaoItensRealizadas", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub deleteExportacaoFreteExecucao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_deleteExportacaoFreteExecucao", parameters, ExecuteType.Delete)

        End Using


    End Sub

    Public Sub insertExportacaoFreteExecucaoErro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_insertExportacaoFreteExecucaoErro", parameters, ExecuteType.Update)

        End Using


    End Sub

    Public Function insertExportacaoFreteExecucao()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction()
        Try
            'Pega os parametros para inclusão execucao frete
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui frete execução
            Me.id_exportacao_frete_execucao = CType(transacao.ExecuteScalar("ms_insertExportacaoFreteExecucao", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)
            'fran 03/2017 i
            If Me.st_cooperativas = "S" Then
                'Insere frete itens
                transacao.Execute("ms_insertExportacaoFreteExecucaoItensCooperativa", parameters, ExecuteType.Insert)
            Else
                'Insere frete itens sem cooperativas
                transacao.Execute("ms_insertExportacaoFreteExecucaoItens", parameters, ExecuteType.Insert)
            End If
            'fran 03/2017 f

            'fran 03/2017 i
            'If Me.st_exportacao_frete = "N" Then 'fran 20/12/2009
            '    'Deletar itens que já foram realizados
            '    transacao.Execute("ms_deleteExportacaoFreteExecucaoItensRealizadas", parameters, ExecuteType.Delete)
            'End If
            'fran 03/2017 f

            'Comita
            transacao.Commit()
            transacao.Dispose()
            If Me.id_exportacao_frete_execucao > 0 Then
                'se há itens a exportar
                If Me.getExportacaoFreteExecucaoItensByFilters.Tables(0).Rows.Count <= 0 Then
                    Me.deleteExportacaoFreteExecucao() 'limpar execução
                    Me.id_exportacao_frete_execucao = 0
                End If
            End If

            'Retorna ao id da execucao
            Return Me.id_exportacao_frete_execucao
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Function
    ' adri 02/2024 - logistica exportacao frete cooperativa - i
    Public Function getExportacaoFreteExecucaoItensCooperativaByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoFreteExecucaoItensCooperativa", parameters, "ms_exportacao_frete_execucao_itens")
            Return dataSet

        End Using

    End Function
    ' adri 02/2024 - logistica exportacao frete cooperativa - f

End Class
