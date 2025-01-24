Imports RK.DataEngine
Imports RK.GenericParameters
Imports RK.GlobalTools
Imports System.IO
Imports System.Math
Imports System.Data


<Serializable()> Public Class ExportacaoBatch

    Private _id_exportacao_batch_execucao As Int32
    Private _id_exportacao_batch_itens As Int32
    Private _id_estabelecimento_filtro As Int32
    Private _id_exportacao_batch_erro As Int32
    Private _dt_ini_filtro As String
    Private _dt_fim_filtro As String
    Private _id_romaneio_filtro As Int32
    Private _dt_ini_execucao As String
    Private _dt_fim_execucao As String
    Private _st_exportacao_batch_execucao As String
    Private _id_romaneio As Int32
    Private _id_estabelecimento As Int32
    Private _id_item As Int32
    Private _nm_arquivo As String
    Private _id_cooperativa As Int32
    Private _nr_caderneta As Int32
    Private _dt_ini_execucao_itens As String
    Private _dt_fim_execucao_itens As String
    Private _st_exportacao_batch_itens As String
    Private _id_modificador As Int32
    Private _id_modificador_batch As Int32
    Private _id_criacao As Int32
    Private _cd_erro As String
    Private _nm_erro As String
    Private _st_exportacao_batch As String
    Private _nr_media_materia_gorda As Decimal
    Private _nr_media_proteina As Decimal
    Private _nr_densidade As Decimal
    Private _id_po_cooperativa As Int32
    Private _id_po_produtor As Int32
    Private _id_po_agropecuaria As Int32
    Private _id_agropecuaria As Int32
    Private _nr_volume_caderneta As Decimal
    Private _nr_volume_estoque As Decimal 'fran themis 3546
    Private _nr_total_volume_rejeitado As Decimal
    Private _nr_po As String
    Private _id_registro_exportacao_batch As Int32 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _dt_registro_exportacao_batch As String 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _id_usuario_registro_exportacao_batch As Int32 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _dt_exportacao_batch As String 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _id_usuario_exportacao_batch As Int32 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _path_arquivobatch As String 'fran THEMIS BATCH DECLARATION 06/03/2012
    Private _dt_referencia As String 'fran themis
    Private _dt_hora_entrada_ini As String 'fran themis
    Private _dt_hora_entrada_fim As String 'fran themis
    Private _dt_hora_entrada As String 'fran themis
    Private _nr_nota_fiscal As String 'fran themis
    Private _nr_peso_liquido As Decimal
    Private _nr_peso_liquido_caderneta As Decimal
    Private _nr_peso_liquido_nota As Decimal
    Private _st_aplicativo_gerador As String 'fran 04/04/2012 themis
    Private _st_romaneio_com_agropecuaria As String
    Private _st_romaneio_somente_agropecuaria As String 'fran 04/10/2012
    Private _st_destino_leite_rejeitado As String  'fran 04/10/2012
    Private _nr_tara As Decimal
    Private _nr_pesagem_inicial As Decimal
    Private _nr_pesagem_final As Decimal
    Private _nr_pesagem_intermediaria As Decimal
    Private _nr_po_cooperativa As String


    Public Property id_exportacao_batch_erro() As Int32
        Get
            Return _id_exportacao_batch_erro
        End Get
        Set(ByVal value As Int32)
            _id_exportacao_batch_erro = value
        End Set
    End Property
    Public Property id_item() As Int32
        Get
            Return _id_item
        End Get
        Set(ByVal value As Int32)
            _id_item = value
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
    Public Property st_romaneio_com_agropecuaria() As String
        Get
            Return _st_romaneio_com_agropecuaria
        End Get
        Set(ByVal value As String)
            _st_romaneio_com_agropecuaria = value
        End Set
    End Property
    Public Property st_romaneio_somente_agropecuaria() As String
        Get
            Return _st_romaneio_somente_agropecuaria
        End Get
        Set(ByVal value As String)
            _st_romaneio_somente_agropecuaria = value
        End Set
    End Property

    Public Property st_destino_leite_rejeitado() As String
        Get
            Return _st_destino_leite_rejeitado
        End Get
        Set(ByVal value As String)
            _st_destino_leite_rejeitado = value
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
    Public Property st_exportacao_batch_execucao() As String
        Get
            Return _st_exportacao_batch_execucao
        End Get
        Set(ByVal value As String)
            _st_exportacao_batch_execucao = value
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
    Public Property nr_media_materia_gorda() As Decimal
        Get
            Return _nr_media_materia_gorda
        End Get
        Set(ByVal value As Decimal)
            _nr_media_materia_gorda = value
        End Set
    End Property
    Public Property nr_media_proteina() As Decimal
        Get
            Return _nr_media_proteina
        End Get
        Set(ByVal value As Decimal)
            _nr_media_proteina = value
        End Set
    End Property
    Public Property nr_densidade() As Decimal
        Get
            Return _nr_densidade
        End Get
        Set(ByVal value As Decimal)
            _nr_densidade = value
        End Set
    End Property
    Public Property nr_volume_estoque() As Decimal
        Get
            Return _nr_volume_estoque
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_estoque = value
        End Set
    End Property
    Public Property nr_volume_caderneta() As Decimal
        Get
            Return _nr_volume_caderneta
        End Get
        Set(ByVal value As Decimal)
            _nr_volume_caderneta = value
        End Set
    End Property
    Public Property nr_pesagem_final() As Decimal
        Get
            Return _nr_pesagem_final
        End Get
        Set(ByVal value As Decimal)
            _nr_pesagem_final = value
        End Set
    End Property
    Public Property nr_pesagem_intermediaria() As Decimal
        Get
            Return _nr_pesagem_intermediaria
        End Get
        Set(ByVal value As Decimal)
            _nr_pesagem_intermediaria = value
        End Set
    End Property
    Public Property nr_pesagem_inicial() As Decimal
        Get
            Return _nr_pesagem_inicial
        End Get
        Set(ByVal value As Decimal)
            _nr_pesagem_inicial = value
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
    Public Property nr_total_volume_rejeitado() As Decimal
        Get
            Return _nr_total_volume_rejeitado
        End Get
        Set(ByVal value As Decimal)
            _nr_total_volume_rejeitado = value
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
  
    Public Property st_exportacao_batch_itens() As String
        Get
            Return _st_exportacao_batch_itens
        End Get
        Set(ByVal value As String)
            _st_exportacao_batch_itens = value
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
    Public Property id_modificador_batch() As Int32
        Get
            Return _id_modificador_batch
        End Get
        Set(ByVal value As Int32)
            _id_modificador_batch = value
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
    Public Property id_po_produtor() As Int32
        Get
            Return _id_po_produtor
        End Get
        Set(ByVal value As Int32)
            _id_po_produtor = value
        End Set
    End Property
    Public Property id_po_cooperativa() As Int32
        Get
            Return _id_po_cooperativa
        End Get
        Set(ByVal value As Int32)
            _id_po_cooperativa = value
        End Set
    End Property
    Public Property id_po_agropecuaria() As Int32
        Get
            Return _id_po_agropecuaria
        End Get
        Set(ByVal value As Int32)
            _id_po_agropecuaria = value
        End Set
    End Property
    Public Property id_agropecuaria() As Int32
        Get
            Return _id_agropecuaria
        End Get
        Set(ByVal value As Int32)
            _id_agropecuaria = value
        End Set
    End Property
    Public Property nr_po() As String
        Get
            Return _nr_po
        End Get
        Set(ByVal value As String)
            _nr_po = value
        End Set
    End Property
    Public Property nr_po_cooperativa() As String
        Get
            Return _nr_po_cooperativa
        End Get
        Set(ByVal value As String)
            _nr_po_cooperativa = value
        End Set
    End Property
    Public Property id_registro_exportacao_batch() As Int32
        Get
            Return _id_registro_exportacao_batch
        End Get
        Set(ByVal value As Int32)
            _id_registro_exportacao_batch = value
        End Set
    End Property

    Public Property dt_registro_exportacao_batch() As String
        Get
            Return _dt_registro_exportacao_batch
        End Get
        Set(ByVal value As String)
            _dt_registro_exportacao_batch = value
        End Set
    End Property
    Public Property id_usuario_registro_exportacao_batch() As Int32
        Get
            Return _id_usuario_registro_exportacao_batch
        End Get
        Set(ByVal value As Int32)
            _id_usuario_registro_exportacao_batch = value
        End Set
    End Property

    Public Property st_exportacao_batch() As String
        Get
            Return _st_exportacao_batch
        End Get
        Set(ByVal value As String)
            _st_exportacao_batch = value
        End Set
    End Property
    Public Property st_aplicativo_gerador() As String
        Get
            Return _st_aplicativo_gerador
        End Get
        Set(ByVal value As String)
            _st_aplicativo_gerador = value
        End Set
    End Property
    Public Property id_usuario_exportacao_batch() As Int32
        Get
            Return _id_usuario_exportacao_batch
        End Get
        Set(ByVal value As Int32)
            _id_usuario_exportacao_batch = value
        End Set
    End Property

    Public Property dt_exportacao_batch() As String
        Get
            Return _dt_exportacao_batch
        End Get
        Set(ByVal value As String)
            _dt_exportacao_batch = value
        End Set
    End Property
    Public Property id_exportacao_batch_execucao() As Int32
        Get
            Return _id_exportacao_batch_execucao
        End Get
        Set(ByVal value As Int32)
            _id_exportacao_batch_execucao = value
        End Set
    End Property
    Public Property id_exportacao_batch_itens() As Int32
        Get
            Return _id_exportacao_batch_itens
        End Get
        Set(ByVal value As Int32)
            _id_exportacao_batch_itens = value
        End Set
    End Property
    Public Property path_arquivobatch() As String
        Get
            Return _path_arquivobatch
        End Get
        Set(ByVal value As String)
            _path_arquivobatch = value
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
    Public Property dt_hora_entrada_ini() As String
        Get
            Return _dt_hora_entrada_ini
        End Get
        Set(ByVal value As String)
            _dt_hora_entrada_ini = value
        End Set
    End Property
    Public Property dt_hora_entrada_fim() As String
        Get
            Return _dt_hora_entrada_fim
        End Get
        Set(ByVal value As String)
            _dt_hora_entrada_fim = value
        End Set
    End Property
    Public Property dt_hora_entrada() As String
        Get
            Return _dt_hora_entrada
        End Get
        Set(ByVal value As String)
            _dt_hora_entrada = value
        End Set
    End Property
    Public Property nr_nota_fiscal() As String
        Get
            Return _nr_nota_fiscal
        End Get
        Set(ByVal value As String)
            _nr_nota_fiscal = value
        End Set
    End Property
    Public Property nr_peso_liquido() As Decimal
        Get
            Return _nr_peso_liquido
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_liquido = value
        End Set
    End Property

    Public Property nr_peso_liquido_caderneta() As Decimal
        Get
            Return _nr_peso_liquido_caderneta
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_liquido_caderneta = value
        End Set
    End Property
    Public Property nr_peso_liquido_nota() As Decimal
        Get
            Return _nr_peso_liquido_nota
        End Get
        Set(ByVal value As Decimal)
            _nr_peso_liquido_nota = value
        End Set
    End Property

    Public Sub New(ByVal id As String)

        Me.id_exportacao_batch_execucao = id
        loadExportacaoBatchExecucao()

    End Sub
    'Public Function getCalculoStatusExecucao() As String
    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Return CType(data.ExecuteScalar("ms_getCalculoStatusExecucao", parameters, ExecuteType.Select), String)

    '    End Using
    'End Function
    Public Sub New()

    End Sub


    Public Function getExportacaoBatchExecucaoByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoBatchExecucao", parameters, "ms_exportacao_batch_execucao")
            Return dataSet

        End Using

    End Function
    Public Function getExportacaoBatchErrosByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoBatchErros", parameters, "ms_exportacao_batch_erro")
            Return dataSet

        End Using

    End Function
    Public Function getExportacaoBatchItensByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getExportacaoBatchItens", parameters, "ms_exportacao_batch_itens")
            Return dataSet

        End Using

    End Function

    Private Sub loadExportacaoBatchExecucao()

        Dim dataSet As DataSet = getExportacaoBatchExecucaoByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

    End Sub

    Public Function insertExportacaoBatchItens() As Int32

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            Return CType(data.ExecuteScalar("ms_insertExportacaoBatchItens", parameters, ExecuteType.Insert), Int32)

        End Using


    End Function

    Public Sub updateExportacaoBatchExecucao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateExportacaoBatchExecucao", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub updateExportacaoBatchItens()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateExportacaoBatchItens", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub updateExportacaoBatchItensMediasPO()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateExportacaoBatchItensMediasPO", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub updateExportacaoBatchItensVolumeEstoque()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateExportacaoBatchItensVolumeEstoque", parameters, ExecuteType.Update)

        End Using


    End Sub

    Public Sub updateBatchExportacaoStatusFinalizacao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_updateBatchExportacaoStatusFinalizacao", parameters, ExecuteType.Update)

        End Using


    End Sub
    Public Sub deleteExportacaoBatchItensRealizadas()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_deleteExportacaoBatchItensRealizadas", parameters, ExecuteType.Delete)

        End Using


    End Sub
    Public Sub deleteExportacaoBatchExecucao()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_deleteExportacaoBatchExecucao", parameters, ExecuteType.Delete)

        End Using


    End Sub

    Public Sub insertExportacaoBatchErro()

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            data.Execute("ms_insertExportacaoBatchErro", parameters, ExecuteType.Update)

        End Using


    End Sub

    Public Function insertExportacaoBatchExecucao()

        Dim transacao As New DataAccess
        'Inicia Transação
        transacao.StartTransaction()
        Try
            'Pega os parametros para inclusão execucao frete
            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)

            'Inclui frete execução
            Me.id_exportacao_batch_execucao = CType(transacao.ExecuteScalar("ms_insertExportacaoBatchExecucao", parameters, ExecuteType.Insert), Int32)
            parameters = ParametersEngine.getParametersFromObject(Me)

            'Insere frete itens
            transacao.Execute("ms_insertExportacaoBatchItens", parameters, ExecuteType.Insert)

            ' ''If Me.st_exportacao_batch = "N" Then 'fran 20/12/2009
            ' ''    'Deletar itens que já foram realizados
            ' ''    transacao.Execute("ms_deleteExportacaobatchItensRealizadas", parameters, ExecuteType.Delete)
            ' ''End If


            'Comita
            transacao.Commit()
            transacao.Dispose()
            If Me.id_exportacao_batch_execucao > 0 Then
                'se há itens a exportar
                If Me.getExportacaoBatchItensByFilters.Tables(0).Rows.Count <= 0 Then
                    Me.deleteExportacaoBatchExecucao() 'limpar execução
                    Me.id_exportacao_batch_execucao = 0
                End If
            End If

            'Retorna ao id da execucao
            Return Me.id_exportacao_batch_execucao
        Catch err As Exception
            transacao.RollBack()
            transacao.Dispose()
            Throw New Exception(err.Message)
        End Try
    End Function
    Public Function exportBatchDeclaration() As Boolean

        ' 02/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - i
        'Dim ArquivoTexto As StreamWriter

        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        Dim ArquivoTexto As StreamWriter
        ' 02/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - f

        Try

            Dim nomearquivo As String
            Dim filtro_estabel As Int32
            Dim filtro_id_romaneio As Int32
            Dim filtro_dt_ini As String
            Dim filtro_dt_fim As String
            Dim filtro_path_arquivobatch As String
            Dim id_batch_execucao As Int32
            Dim lrow As DataRow
            Dim lvaloraux As Decimal
            'Dim batchexecucao As New ExportacaoBatch
            Dim parametro As New Parametro
            Dim lmediaDensidade As Decimal
            Dim lbAbrirArquivo As Boolean = False
            Dim linhatexto As String
            Dim idromaneio_ant As Int32
            Dim lberro As Boolean = False

            ' Arquivo Batch
            Dim reg_documentdate As String      '8 posições Dt_abertura_romaneio
            Dim reg_postingdate As String       '8 posições Dt inicio descarga
            Dim reg_referencedocument As String 'alfnum 16 posições Cooperativa: NrNotaFiscal Produtor:NrRomaneio
            Dim reg_headertext As String        'alfnum 25 posições Nr Romaneio (zeroa a esquerda)
            Dim reg_transactioncode As String   'alfnum 20 posições FIXO :'MB01'
            Dim reg_materialnb As String        '18 posições Código do Item do SAP
            Dim reg_plant As String             '4 posições Cod estabelecimento SAP
            Dim reg_storagelocation As String   'alfnum 4 posições FIXO: '0200'
            Dim reg_batchnumber As String        'alfnum 10 posições Nr Romaneio (zeroa a esquerda)
            Dim reg_movtype As String           'alfnum 3 posições FIXO :'101'
            Dim reg_quantityinstock As String   '15 posições (zeros a esquerda) Produtores: Somatória do Campo Volume Descarregado Real por romaneio COOPERATIVA:Volume da Nota Fiscal
            Dim reg_unitofentry As String       '3 posições FIXO: 'L'
            Dim reg_quantityweighed As String   '15 posições (zeros a esquerda) Diferença Da Pesagem da Balança
            Dim reg_unitofentryweighed As String 'alfnum 3 posições FIXO: 'KG'
            Dim reg_purchdocnumber As String        'alfnum 10 posições Nr Romaneio (zeroa a esquerda)
            Dim reg_itemofpo As String          'alfnum 5 posições FIXO :'00010'
            Dim reg_dateofmanufacture As String  '8 posições Data Inicio Descarga
            Dim reg_fatcontent As String        '30 posições (zeros a esquerda) Media da analise Materia Gorda do caminhão
            Dim reg_proteincontent As String   '30 posições (zeros a esquerda) Media da analise proteina do caminhão
            Dim reg_supplymodeofthebatch As String   'alfnum 30  posições FIXO: 'C' para produtor 'P' cooperativa
            Dim reg_idtransport As String        'alfnum 30 posições (zeros a esquerda) código do transportador no SAP

            filtro_estabel = Me.id_estabelecimento_filtro
            filtro_id_romaneio = Me.id_romaneio_filtro
            filtro_dt_ini = Me.dt_ini_filtro
            filtro_dt_fim = Me.dt_fim_filtro
            filtro_path_arquivobatch = Me.path_arquivobatch
            id_batch_execucao = Me.id_exportacao_batch_execucao

            'batchexecucao.id_exportacao_batch_execucao = id_batch_execucao
            Dim dsbatchexecucao As DataSet = Me.getExportacaoBatchItensByFilters

            nomearquivo = String.Empty
            Dim dspo As DataSet
            lbAbrirArquivo = True
            'Para cada linha do sql que traz os romaneios fechados (4), com registro de exportacao batch liberado (2)
            For Each lrow In dsbatchexecucao.Tables(0).Rows

                'reinicializa romaneio
                Me.id_romaneio = lrow.Item("id_romaneio")
                Me.Finalize()
                Me.reload_Batch_Romaneio()

                'fran themis chamado 1548 16/05/2012 i 
                'lmediaDensidade = Me.getBatchRomaneioCompartimentoMediaDens
                Me.dt_referencia = String.Concat("01/", DateTime.Parse(lrow.Item("dt_ini_descarga")).ToString("MM/yyyy"))
                lmediaDensidade = Me.getBatchDensidade
                'fran themis chamado 1548 16/05/2012 f 
                Me.id_modificador = Me._id_modificador_batch

                Me.id_exportacao_batch_itens = lrow.Item("id_exportacao_batch_itens")
                Me.id_exportacao_batch_execucao = id_batch_execucao
                Me.id_item = lrow.Item("id_item")

                'busca o nr_po
                If Me.id_cooperativa > 0 Then
                    Me.dt_referencia = DateTime.Parse(lrow.Item("dt_ini_descarga")).ToString("dd/MM/yyyy")
                    'fran 07/02/2024 i
                    'dspo = Me.getBatchPOCooperativabyCooperativa
                    'If dspo.Tables(0).Rows.Count > 0 Then
                    '    Me.nr_po = dspo.Tables(0).Rows(0).Item("nr_po")
                    '    Me.id_po_cooperativa = dspo.Tables(0).Rows(0).Item("id_po")
                    '    Me.id_po_produtor = 0
                    '    Me.id_po_agropecuaria = 0
                    'Else
                    '    Me.nr_po = String.Empty
                    '    Me.id_po_produtor = 0
                    '    Me.id_po_cooperativa = 0
                    '    Me.id_po_agropecuaria = 0

                    'End If
                    If Me.nr_po_cooperativa.Equals(String.Empty) Then
                        Me.nr_po = String.Empty
                        Me.id_po_produtor = 0
                        Me.id_po_cooperativa = 0
                        Me.id_po_agropecuaria = 0
                    Else
                        Me.nr_po = nr_po_cooperativa
                        Me.id_po_cooperativa = 0
                        Me.id_po_produtor = 0
                        Me.id_po_agropecuaria = 0
                    End If
                    'fran 07/02/2024 f
                Else
                    Me.id_agropecuaria = lrow.Item("id_agropecuaria").ToString

                    If Me.id_agropecuaria > 0 Then
                        Me.dt_referencia = DateTime.Parse(lrow.Item("dt_ini_descarga")).ToString("dd/MM/yyyy")
                        dspo = Me.getBatchPOAgropecuariabyAgropecuaria
                        If dspo.Tables(0).Rows.Count > 0 Then
                            Me.nr_po = dspo.Tables(0).Rows(0).Item("nr_po")
                            Me.id_po_agropecuaria = dspo.Tables(0).Rows(0).Item("id_po")
                            Me.id_po_cooperativa = 0
                            Me.id_po_produtor = 0
                        Else
                            Me.nr_po = String.Empty
                            Me.id_po_produtor = 0
                            Me.id_po_cooperativa = 0
                            Me.id_po_agropecuaria = 0
                        End If
                    Else
                        Me.dt_referencia = String.Concat("01/", DateTime.Parse(lrow.Item("dt_ini_descarga")).ToString("MM/yyyy"))
                        dspo = Me.getBatchPOProdutorbyRomaneioEstabelecimento
                        If dspo.Tables(0).Rows.Count > 0 Then
                            Me.nr_po = dspo.Tables(0).Rows(0).Item("nr_po")
                            Me.id_po_produtor = dspo.Tables(0).Rows(0).Item("id_po")
                            Me.id_po_cooperativa = 0
                            Me.id_po_agropecuaria = 0
                        Else
                            Me.nr_po = String.Empty
                            Me.id_po_produtor = 0
                            Me.id_po_cooperativa = 0
                            Me.id_po_agropecuaria = 0
                        End If
                    End If

                End If

                'Grava medias e po
                Me.nr_densidade = lmediaDensidade
                Me.id_exportacao_batch_itens = lrow.Item("id_exportacao_batch_itens")
                Me.nr_media_materia_gorda = Me.getBatchRomaneioCompartimentoMediaMG
                Me.nr_media_proteina = Me.getBatchRomaneioCompartimentoMediaProt
                Me.updateExportacaoBatchItensMediasPO() 'atualiza status
                'fran 04/10/2012 i
                Me.st_romaneio_somente_agropecuaria = lrow.Item("st_romaneio_somente_agropecuaria").ToString
                Me.st_romaneio_com_agropecuaria = lrow.Item("st_romaneio_com_agropecuaria").ToString
                Me.st_destino_leite_rejeitado = lrow.Item("st_destino_leite_rejeitado").ToString
                'fran 04/10/2012 f

                'fran chamado 1548 - themis i
                'If ValidarBatch(lrow.Item("cd_estabelecimento_sap").ToString, lrow.Item("cd_transportador_sap").ToString, lrow.Item("cd_item_sap")) = True Then
                If ValidarBatch(lrow.Item("cd_estabelecimento_sap").ToString, lrow.Item("cd_transportador_sap").ToString, lrow.Item("cd_item_sap"), lmediaDensidade) = True Then
                    'fran chamado 1548 - themis f

                    If lbAbrirArquivo = True Then
                        lbAbrirArquivo = False
                        'Se ainda tem nome de arquivo fecha arquivo anterior
                        If Not nomearquivo.ToString.Trim.Equals(String.Empty) Then
                            'fecha arquivo anterior
                            ArquivoTexto.Close()
                            ArquivoTexto.Dispose()
                        End If
                        'abre novo arquivo ZBRXWMMBXY_YYYYMMDDHHMMSS 
                        nomearquivo = "\ZBRXWMMBXY_" + DateTime.Parse(Now()).ToString("yyyyMMddHHmmss") + ".txt"
                        nomearquivo = Replace(nomearquivo, ":", "")
                        nomearquivo = Replace(nomearquivo, " ", "")
                        nomearquivo = Replace(nomearquivo, "/", "")
                        nomearquivo = filtro_path_arquivobatch & nomearquivo
                        ' 02/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - i
                        'ArquivoTexto = New StreamWriter(nomearquivo)
                        ArquivoTexto = New StreamWriter(nomearquivo, False, utf8WithoutBom)
                        ' 02/05/2012 - Chamado 1545 - Gerar o arquivo em formato UTF8 mas sem o BOM (Byte Order Mark)  - f

                    End If

                    'Grava execucao itens
                    Me.id_exportacao_batch_itens = lrow.Item("id_exportacao_batch_itens")
                    Me.nm_arquivo = nomearquivo
                    Me.st_exportacao_batch_itens = "I" 'inicializada
                    Me.updateExportacaoBatchItens() 'atualiza status

                    reg_documentdate = String.Concat(DateTime.Parse(lrow.Item("dt_hora_entrada")).ToString("ddMMyyyy").ToString, ";")
                    reg_postingdate = String.Concat(DateTime.Parse(lrow.Item("dt_ini_descarga")).ToString("ddMMyyyy").ToString, ";")

                    If Me.id_cooperativa > 0 Then
                        reg_referencedocument = String.Concat(Me.nr_nota_fiscal, ";")
                    Else
                        'Formata numero do romaneio com 10 casas e zeroas a esquerda
                        reg_referencedocument = String.Concat(Right(StrDup(10 - Len(Me.id_romaneio.ToString), "0") + Me.id_romaneio.ToString, 10), ";")

                    End If
                    'reg_headertext = String.Concat(Me.id_romaneio.ToString, ";")  THEMIS FRAN MANDANDO ROMANEIO FORMATADO COM 10 POSIÇÔES
                    reg_headertext = String.Concat(Right(StrDup(10 - Len(Me.id_romaneio.ToString), "0") + Me.id_romaneio.ToString, 10), ";")
                    reg_transactioncode = "MB01;"
                    'fran themis 15/05/2012 i 
                    'reg_materialnb = String.Concat(lrow.Item("cd_item_sap"), ";")
                    reg_materialnb = String.Concat(Right(StrDup(18 - Len(lrow.Item("cd_item_sap")), "0") + lrow.Item("cd_item_sap").ToString, 18), ";")
                    'fran themis 15/05/2012 f 

                    reg_plant = String.Concat(lrow.Item("cd_estabelecimento_sap"), ";")
                    reg_storagelocation = "0200;"
                    'reg_batchnumber = String.Concat(Me.id_romaneio.ToString, ";")
                    reg_batchnumber = String.Concat(Right(StrDup(10 - Len(Me.id_romaneio.ToString), "0") + Me.id_romaneio.ToString, 10), ";")
                    reg_movtype = "101;"

                    If Me.id_cooperativa > 0 Then
                        reg_quantityinstock = String.Concat(CInt(Me.nr_peso_liquido_nota).ToString, ";")
                    Else
                        Dim lvalorauxProdutorOrganico As Decimal = Me.getBatchVolumeProdutorOrganicobyRomaneio()
                        Dim lvalorauxProdutorLeiteNormal As Integer = Me.getBatchProdutorNaoOrganicobyRomaneio()

                        'reg_quantityinstock = String.Concat(CInt(lrow.Item("nr_volume_descarregado")).ToString, ";")
                        If lrow.Item("st_romaneio_com_agropecuaria").ToString.Equals("S") Then 'se é um romaneio com mais de uma linha ou seja com agropecuarias

                            If Me.id_agropecuaria > 0 Then 'se é linha de agropecuaria
                                reg_quantityinstock = String.Concat(CInt(lrow.Item("nr_volume_caderneta")).ToString, ";") 'pega a somatoria da caderneta para a agropecuaria
                            Else 'se é a linha dos produtores
                                lvaloraux = Me.getBatchVolumeAgropecuariabyRomaneio

                                'Fran reconstrucao - 07/2020
                                'reg_quantityinstock = String.Concat(CLng((Me.nr_peso_liquido / lmediaDensidade) - lvaloraux).ToString, ";") 'pega a diferença da balança e divide pela dendiade para resultar valor em litros e retira o valor das agropecuarias

                                'Se não tem produtor in natura, apenas leite organico
                                If lvalorauxProdutorLeiteNormal = 0 Then
                                    reg_quantityinstock = String.Concat(CLng((Me.nr_peso_liquido / lmediaDensidade) - lvaloraux).ToString, ";") 'pega a diferença da balança e divide pela dendiade para resultar valor em litros e retira o valor das agropecuarias
                                Else 'se tem produtor com leite in natura
                                    If lrow.Item("id_item").ToString.Equals("264") Then 'se é item organico
                                        reg_quantityinstock = String.Concat(CInt(lrow.Item("nr_volume_caderneta")).ToString, ";") 'pega a somatoria da caderneta para a organico
                                    Else 'se item in natura
                                        reg_quantityinstock = String.Concat(CLng((Me.nr_peso_liquido / lmediaDensidade) - lvaloraux - lvalorauxProdutorOrganico).ToString, ";") 'pega a diferença da balança e divide pela dendiade para resultar valor em litros e retira o valor das agropecuarias e o valor do organico
                                    End If
                                End If

                            End If
                        Else 'se romaneio unico sem agropecuaria
                            'fran reconstrucao 07/2020
                            'reg_quantityinstock = String.Concat(CLng((Me.nr_peso_liquido / lmediaDensidade)).ToString, ";") 'pega a diferença da balança e divide pela dendiade para resultar valor em litros
                            'Se não tem produtor in natura, apenas leite organico
                            If lvalorauxProdutorLeiteNormal = 0 Then
                                reg_quantityinstock = String.Concat(CLng((Me.nr_peso_liquido / lmediaDensidade)).ToString, ";") 'pega a diferença da balança e divide pela dendiade para resultar valor em litros 
                            Else 'se tem produtor com leite in natura
                                If lrow.Item("id_item").ToString.Equals("264") Then 'se é item organico
                                    reg_quantityinstock = String.Concat(CInt(lrow.Item("nr_volume_caderneta")).ToString, ";") 'pega a somatoria da caderneta para a organico
                                Else 'se item in natura
                                    reg_quantityinstock = String.Concat(CLng((Me.nr_peso_liquido / lmediaDensidade) - lvalorauxProdutorOrganico).ToString, ";") 'pega a diferença da balança e divide pela dendiade para resultar valor em litros e retira o valor do organico
                                End If
                            End If

                        End If

                        If Not lrow.Item("st_destino_leite_rejeitado").ToString.Equals(String.Empty) Then 'tem dstino de rejeição de leite, oleite está rejeitado...
                            Select Case lrow.Item("st_destino_leite_rejeitado").ToString
                                Case "V" 'venda
                                    'Se romaneio de agropecuaria
                                    If lrow.Item("st_romaneio_com_agropecuaria").ToString.Equals("S") Then 'se é um romaneio com mais de uma linha ou seja com agropecuarias
                                        If Me.id_agropecuaria > 0 Then 'se é linha de agropecuaria
                                            reg_quantityinstock = String.Concat(CInt(lrow.Item("nr_volume_caderneta")).ToString, ";") 'pega a somatoria da caderneta para a agropecuaria
                                        Else 'se é a linha dos produtores
                                            'lvaloraux = Me.getBatchVolumeAgropecuariabyRomaneio fez em cima para quem não é agropecuaria mas o romaneio tem agroppecuaria
                                            'reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_tara) / lmediaDensidade) - lvaloraux).ToString, ";") 'pega a diferença da balança e divide pela dendiade para resultar valor em litros e retira o valor das agropecuarias
                                            If lvalorauxProdutorLeiteNormal = 0 Then
                                                reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_tara) / lmediaDensidade) - lvaloraux).ToString, ";")
                                            Else 'se tem produtor com leite in natura
                                                If lrow.Item("id_item").ToString.Equals("264") Then 'se é item organico
                                                    reg_quantityinstock = String.Concat(CInt(lrow.Item("nr_volume_caderneta")).ToString, ";") 'pega a somatoria da caderneta para a agropecuaria
                                                Else 'se item in natura
                                                    reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_tara) / lmediaDensidade) - lvaloraux - lvalorauxProdutorOrganico).ToString, ";") 'pega a diferença da balança e divide pela dendiade para resultar valor em litros e retira o valor das agropecuarias
                                                End If
                                            End If

                                        End If

                                    Else 'Se romaneio sem agropecuaria
                                        If lvalorauxProdutorLeiteNormal = 0 Then
                                            reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_tara) / lmediaDensidade)).ToString, ";") 'como é venda todo leite entra em estoque pois sera gerada nota do volume total
                                        Else
                                            If lrow.Item("id_item").ToString.Equals("264") Then 'se é item organico
                                                reg_quantityinstock = String.Concat(CInt(lrow.Item("nr_volume_caderneta")).ToString, ";") 'pega a somatoria da caderneta para a organico
                                            Else 'se item in natura
                                                reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_tara) / lmediaDensidade) - lvalorauxProdutorOrganico).ToString, ";") 'como é venda todo leite entra em estoque pois sera gerada nota do volume total
                                            End If

                                        End If
                                    End If
                                Case "D" 'descarte
                                    If lrow.Item("st_romaneio_com_agropecuaria").ToString.Equals("S") Then 'se é um romaneio com mais de uma linha ou seja com agropecuarias
                                        If Me.id_agropecuaria > 0 Then 'se é linha de agropecuaria
                                            Dim lpercentualAgropecuaria As Decimal

                                            'Busca o percentual do total de agropecuaria em cima do valor total do caminhão ou seja peso liquido da balanca em ltros
                                            'fran 30/05/2012 percentual deve / por 100 chamado 1555
                                            'lpercentualAgropecuaria = CDec((CDec(lrow.Item("nr_volume_caderneta")) * 100) / (Me.nr_peso_liquido / lmediaDensidade))
                                            lpercentualAgropecuaria = CDec(((CDec(lrow.Item("nr_volume_caderneta")) * 100) / (Me.nr_peso_liquido / lmediaDensidade)) / 100)
                                            'fran 30/05/2012
                                            'leite bom (peso inicial - intermediario) convertido em litros * o percentual devido a agropecuario
                                            reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_pesagem_intermediaria) / lmediaDensidade) * lpercentualAgropecuaria).ToString, ";")

                                        Else 'se é a linha dos produtores
                                            'lvaloraux = Me.getBatchVolumeAgropecuariabyRomaneio fez em cima para quem não é agropecuaria mas o romaneio tem agroppecuaria
                                            Dim lpercentualTotalAgropecuaria As Decimal
                                            Dim lpercentualProdutor As Decimal
                                            Dim lpercentualProdutorOrganico As Decimal

                                            'Busca o percentual do total de agropecuaria em cima do valor total do caminhão ou seja peso liquido da balanca em ltros
                                            'fran 30/12/2012 i / por 100 chamado 1555
                                            'lpercentualTotalAgropecuaria = CDec((lvaloraux * 100) / (Me.nr_peso_liquido / lmediaDensidade))
                                            'lpercentualProdutor = 100 - lpercentualTotalAgropecuaria
                                            lpercentualTotalAgropecuaria = CDec(((lvaloraux * 100) / (Me.nr_peso_liquido / lmediaDensidade)) / 100)
                                            lpercentualProdutor = 1 - lpercentualTotalAgropecuaria
                                            'fran 30/12/2012 i / por 100
                                            'leite bom (peso inicial - intermediario) convertido em litros * o percentual devido aos produtores
                                            'reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_pesagem_intermediaria) / lmediaDensidade) * lpercentualProdutor).ToString, ";")

                                            'fran recuperacao fonte 
                                            If lvalorauxProdutorLeiteNormal > 0 OrElse lvalorauxProdutorOrganico > 0 Then
                                                lpercentualProdutorOrganico = CDec(((lvalorauxProdutorOrganico * 100) / (Me.nr_peso_liquido / lmediaDensidade)) / 100)
                                                lpercentualProdutor = 1 - lpercentualTotalAgropecuaria - lpercentualProdutorOrganico
                                            Else
                                                lpercentualProdutorOrganico = 0
                                            End If
                                            'Se não tem produtor in natura, apenas leite organico
                                            If lvalorauxProdutorLeiteNormal = 0 Then
                                                reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_pesagem_intermediaria) / lmediaDensidade) * lpercentualProdutor).ToString, ";")
                                            Else 'se tem produtor com leite in natura
                                                If lrow.Item("id_item").ToString.Equals("264") Then 'se é item organico
                                                    reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_pesagem_intermediaria) / lmediaDensidade) * lpercentualProdutorOrganico).ToString, ";")
                                                Else 'se item in natura
                                                    reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_pesagem_intermediaria) / lmediaDensidade) * lpercentualProdutor).ToString, ";")
                                                End If
                                            End If

                                        End If

                                    Else
                                        'reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_pesagem_intermediaria) / lmediaDensidade)).ToString, ";") 'como é venda todo leite entra em estoque pois sera gerada nota do volume total
                                        Dim lpercentualProdutor As Decimal
                                        Dim lpercentualProdutorOrganico As Decimal

                                        If lvalorauxProdutorLeiteNormal = 0 Then
                                            reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_pesagem_intermediaria) / lmediaDensidade)).ToString, ";") 'como é venda todo leite entra em estoque pois sera gerada nota do volume total
                                        Else
                                            If lvalorauxProdutorOrganico > 0 Then
                                                lpercentualProdutorOrganico = CDec(((lvalorauxProdutorOrganico * 100) / (Me.nr_peso_liquido / lmediaDensidade)) / 100)
                                                lpercentualProdutor = 1 - lpercentualProdutorOrganico
                                                If lrow.Item("id_item").ToString.Equals("264") Then 'se é item organico
                                                    reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_pesagem_intermediaria) / lmediaDensidade) * lpercentualProdutorOrganico).ToString, ";")
                                                Else 'se item in natura
                                                    reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_pesagem_intermediaria) / lmediaDensidade) * lpercentualProdutor).ToString, ";")
                                                End If

                                            Else
                                                reg_quantityinstock = String.Concat(CLng(((Me.nr_pesagem_inicial - Me.nr_pesagem_intermediaria) / lmediaDensidade)).ToString, ";") 'como é venda todo leite entra em estoque pois sera gerada nota do volume total
                                            End If
                                        End If
                                    End If

                            End Select

                        End If
                    End If

                    'fran 1548 chamado themis
                    'atualiza volume_estoque na tabela
                    Me.id_exportacao_batch_itens = lrow.Item("id_exportacao_batch_itens")
                    Me.nr_volume_estoque = Convert.ToDecimal(Mid(reg_quantityinstock, 1, Len(reg_quantityinstock) - 1))
                    Me.updateExportacaoBatchItensVolumeEstoque() 'atualiza estoque

                    reg_unitofentry = "L;"
                    reg_quantityweighed = String.Concat(CInt(Me.nr_peso_liquido).ToString, ";")
                    reg_unitofentryweighed = "KG;"
                    reg_purchdocnumber = String.Concat(Me.nr_po, ";")
                    reg_itemofpo = "00010;"
                    reg_dateofmanufacture = String.Concat(DateTime.Parse(lrow.Item("dt_ini_descarga")).ToString("ddMMyyyy").ToString, ";")
                    'reg_fatcontent = String.Concat(Me.nr_media_materia_gorda.ToString, ";") THEMIS FRAN 10/05/12
                    'reg_proteincontent = String.Concat(Me.nr_media_proteina.ToString, ";")
                    'Fran 28/06/2012 i - Themis - conforme email em 22/06/2012 precisa enviar o valor (que esta em percentual) multiplicado por 10
                    'reg_fatcontent = String.Concat(Round(Me.nr_media_materia_gorda, 3, MidpointRounding.ToEven).ToString, ";")
                    'reg_proteincontent = String.Concat(Round(Me.nr_media_proteina, 3, MidpointRounding.ToEven).ToString, ";")
                    reg_fatcontent = String.Concat(Round(Me.nr_media_materia_gorda * 10, 3, MidpointRounding.ToEven).ToString, ";")
                    reg_proteincontent = String.Concat(Round(Me.nr_media_proteina * 10, 3, MidpointRounding.ToEven).ToString, ";")
                    'Fran 28/06/2012 f - Themis - conforme email em 22/06/2012 precisa enviar o valor (que esta em percentual) multiplicado por 10

                    If Me.id_cooperativa > 0 Then
                        reg_supplymodeofthebatch = "P;"
                    Else
                        If Me.id_agropecuaria > 0 Then
                            reg_supplymodeofthebatch = "P;"
                        Else
                            reg_supplymodeofthebatch = "C;"
                        End If
                    End If
                    reg_idtransport = String.Concat(lrow.Item("cd_transportador_sap").ToString, ";")

                    linhatexto = ""
                    'Monta a linha a ser inserida no arquivo texto
                    linhatexto = reg_documentdate + reg_postingdate + reg_referencedocument + reg_headertext
                    linhatexto = linhatexto + reg_transactioncode + reg_materialnb + reg_plant + reg_storagelocation
                    linhatexto = linhatexto + reg_batchnumber + reg_movtype + reg_quantityinstock + reg_unitofentry
                    linhatexto = linhatexto + reg_quantityweighed + reg_unitofentryweighed + reg_purchdocnumber + reg_itemofpo
                    linhatexto = linhatexto + reg_dateofmanufacture + reg_fatcontent + reg_proteincontent
                    linhatexto = linhatexto + reg_supplymodeofthebatch + reg_idtransport


                    ArquivoTexto.WriteLine(linhatexto)

                    'finaliza na item execucao e no romaneio se nao houver mais de um registro romaneio (transportadoreas diferentes)
                    Me.st_exportacao_batch_itens = "F"
                    Me.updateExportacaoBatchItens() 'atualiza status

                    If idromaneio_ant <> Me.id_romaneio And idromaneio_ant > 0 Then
                        If lberro = False Then 'se o romaneio anterior nao tem erro, pode atualizar o status do romaneio anterior
                            Me.st_exportacao_batch = "S" 'atualiza status exportacao frete do romaneio 
                            Me.id_romaneio = idromaneio_ant 'coloca o anterior para atualizar status
                            Me.updateBatchRomaneioExportacao()
                            Me.id_romaneio = lrow.Item("id_romaneio") 'volta o romaneio atual
                        Else
                            lberro = False ' assume que o novo romaneio nao tem erros, limpa variavel para o novo romaneio
                        End If
                    End If
                    idromaneio_ant = Me.id_romaneio
                Else
                    If idromaneio_ant <> Me.id_romaneio And idromaneio_ant > 0 Then
                        If lberro = False Then 'se o romaneio anterior nao tem erro, pode atualizar o status do romaneio anterior
                            Me.st_exportacao_batch = "S" 'atualiza status exportacao frete do romaneio 
                            Me.id_romaneio = idromaneio_ant 'coloca o anterior para atualizar status
                            Me.updateBatchRomaneioExportacao()
                            Me.id_romaneio = lrow.Item("id_romaneio") 'volta o romaneio atual
                        End If
                    End If

                    lberro = True 'indica q tem erro
                    idromaneio_ant = Me.id_romaneio

                End If
            Next

            If idromaneio_ant > 0 Then
                If lberro = False Then 'se o romaneio anterior nao tem erro, pode atualizar o status do romaneio anterior
                    Me.st_exportacao_batch = "S" 'atualiza status exportacao frete do romaneio 
                    Me.id_romaneio = idromaneio_ant 'coloca o anterior para atualizar status
                    Me.updateBatchRomaneioExportacao()
                End If
            End If

            If Not ArquivoTexto Is Nothing Then
                ArquivoTexto.Close()
            End If

            'Finaliza execução (romaneios e execucao)
            Me.id_exportacao_batch_execucao = id_batch_execucao
            Me.updateBatchExportacaoStatusFinalizacao()

            exportBatchDeclaration = True

        Catch ex As Exception
            exportBatchDeclaration = False   ' 01/12/2008
            Dim execucaoerro As New ExportacaoBatch
            execucaoerro.st_exportacao_batch_execucao = "E"
            execucaoerro.id_exportacao_batch_execucao = Me.id_exportacao_batch_execucao
            execucaoerro.id_exportacao_batch_itens = Me.id_exportacao_batch_itens
            execucaoerro.nm_erro = ex.Message
            execucaoerro.insertExportacaoBatchErro()
            execucaoerro.updateExportacaoBatchExecucao()
            If Not ArquivoTexto Is Nothing Then
                ArquivoTexto.Close()
            End If

            Throw New Exception(ex.Message)

        End Try

    End Function
    Private Sub reload_Batch_Romaneio()
        'limpar propriedades romaneio
        Me.id_estabelecimento = 0
        Me.id_cooperativa = 0
        Me.dt_hora_entrada = String.Empty
        Me.dt_hora_entrada_ini = String.Empty
        Me.dt_hora_entrada_fim = String.Empty
        Me.nr_peso_liquido = 0
        Me.nr_peso_liquido_caderneta = 0
        Me.nr_peso_liquido_nota = 0
        Me.nr_nota_fiscal = String.Empty
        Me.nr_caderneta = 0
        Me.id_criacao = 0
        Me.id_modificador = 0
        Me.id_exportacao_batch_execucao = 0
        Me.id_exportacao_batch_itens = 0
        Me.id_agropecuaria = 0
        Me.nr_pesagem_inicial = 0
        Me.nr_pesagem_intermediaria = 0
        Me.nr_pesagem_final = 0
        Me.nr_tara = 0
        Me.id_item = 0
        Me.nr_po_cooperativa = String.Empty 'fran 07/02/2024

        Dim dataSet As DataSet = getBatchRomaneioByFilters()
        ParametersEngine.persistObjectValues(dataSet.Tables(0).Rows(0), Me)

        'Me.id_romaneio_transbordo = 0
        'Me.cd_cooperativa = String.Empty
        'Me.nm_cooperativa = String.Empty
        'Me.id_transportador = 0
        'Me.cd_transportador = String.Empty
        'Me.nm_transportador = String.Empty
        'Me.cd_cnh = String.Empty
        'Me.nm_motorista = String.Empty
        'Me.id_motorista = 0
        'Me.ds_placa = String.Empty
        'Me.id_linha = 0
        'Me.ds_linha = String.Empty
        'Me.dt_hora_saida = String.Empty
        'Me.dt_pesagem_inicial = String.Empty
        'Me.dt_pesagem_final = String.Empty
        'Me.nr_tara = 0
        'Me.nr_pesagem_inicial = 0
        'Me.nr_pesagem_final = 0
        'Me.nr_serie_nota_fiscal = String.Empty
        'Me.nr_valor_nota_fiscal = 0
        'Me.dt_saida_nota = String.Empty
        'Me.id_item = 0
        'Me.nm_item = String.Empty
        'Me.id_st_romaneio = 0
        'Me.id_st_analise_global = 0
        'Me.id_st_analise_compartimento = 0
        'Me.id_st_analise_uproducao = 0
        'Me.id_coleta_transmissao = 0
        'Me.dt_criacao = String.Empty
        'Me.dt_modificacao = String.Empty
        'Me.ds_estabelecimento = String.Empty
        'Me.ds_transportador = String.Empty
        'Me.nm_st_romaneio = String.Empty
        'Me.st_reanalise = String.Empty
        'Me.nm_st_analise_compartimento = String.Empty
        'Me.nm_st_analise_uproducao = String.Empty
        'Me.data_inicio = String.Empty
        'Me.data_fim = String.Empty
        'Me.id_linha_ini = 0
        'Me.id_linha_fim = 0
        'Me.nr_peso_liquido_nota_transf = 0
        'Me.nr_nota_fiscal_transf = String.Empty
        'Me.nr_serie_nota_fiscal_transf = String.Empty
        'Me.dt_emissao_nota_transf = String.Empty
        'Me.st_romaneio_transbordo = String.Empty
        'Me.total_volume_max_compartimentos = 0
        'Me.dt_transmissao_ini = String.Empty
        'Me.dt_transmissao_fim = String.Empty
        'Me.dt_transmissao = String.Empty
        'Me.nm_linha = String.Empty
        'Me.ds_placa_frete = String.Empty
        'Me.path_arquivofrete = String.Empty
        'Me.st_exportacao_frete = String.Empty
        'Me.id_exportacao_frete_execucao = 0
        'Me.id_exportacao_frete_execucao_itens = 0
        'Me.id_estabelecimento_frete = 0

    End Sub
    'fran themis chamado 1548 17/05/2012 i
    'Public Function getBatchRomaneioCompartimentoMediaDens() As Decimal
    '    Using data As New DataAccess

    '        Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
    '        Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentoMediaDens", parameters, ExecuteType.Select), Decimal)

    '    End Using

    'End Function
    Public Function getBatchDensidade() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getDensidadeValorbyReferencia", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getBatchVolumeAgropecuariabyRomaneio() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getBatchVolumeAgropecuariabyRomaneio", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getBatchProdutorNaoOrganicobyRomaneio() As Integer
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getBatchProdutorNaoOrganicobyRomaneio", parameters, ExecuteType.Select), Integer)

        End Using

    End Function
    Public Function getBatchVolumeProdutorOrganicobyRomaneio() As Decimal
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getBatchVolumeProdutorOrganicobyRomaneio", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    'fran themis chamado 1548 17/05/2012 f

    Public Function getBatchRomaneioCompartimentoMediaProt() As Decimal 'THEMIS BATCH
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentoMediaProt", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getBatchRomaneioCompartimentoMediaMG() As Decimal 'THEMIS BATCH
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Return CType(data.ExecuteScalar("ms_getRomaneioCompartimentoMediaMG", parameters, ExecuteType.Select), Decimal)

        End Using

    End Function
    Public Function getBatchPOProdutorbyRomaneioEstabelecimento() As DataSet 'THEMIS BATCH
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPOProdutorbyRomaneioEstabelecimento", parameters, "ms_po_produtor")
            Return dataSet

        End Using

    End Function
    Public Function getBatchPOAgropecuariabyAgropecuaria() As DataSet 'THEMIS BATCH
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPOAgropecuariabyAgropecuaria", parameters, "ms_po_agropecuaria")
            Return dataSet

        End Using

    End Function
    Public Function getBatchPOCooperativabyCooperativa() As DataSet 'THEMIS BATCH
        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getPOCooperativabyCooperativa", parameters, "ms_po_cooperativa")
            Return dataSet

        End Using

    End Function
    Private Function ValidarBatch(ByVal pcd_estabelecimento_sap As String, ByVal pcd_transportador_sap As String, ByVal pcd_item_sap As String, ByVal pDensidade As String) As Boolean


        Try
            Dim execucaoerro As New ExportacaoBatch
            Dim lvaloraux As Decimal

            ValidarBatch = True

            execucaoerro.st_exportacao_batch_execucao = "E"
            execucaoerro.id_exportacao_batch_execucao = Me.id_exportacao_batch_execucao
            execucaoerro.id_exportacao_batch_itens = Me.id_exportacao_batch_itens
            execucaoerro.st_exportacao_batch_itens = "E"

            If pcd_estabelecimento_sap.ToString.Trim.Equals(String.Empty) Then
                execucaoerro.nm_erro = "Não há código de estabelecimento SAP cadastrado para este romaneio."
                execucaoerro.insertExportacaoBatchErro()
                execucaoerro.updateExportacaoBatchItens() 'atualiza status
                ValidarBatch = False
            End If

            If pcd_transportador_sap.ToString.Trim.Equals(String.Empty) Then
                execucaoerro.nm_erro = "Não há código de Transportador SAP cadastrado para este romaneio."
                execucaoerro.insertExportacaoBatchErro()
                execucaoerro.updateExportacaoBatchItens() 'atualiza status
                ValidarBatch = False
            End If

            If pcd_item_sap.ToString.Trim.Equals(String.Empty) Then
                execucaoerro.nm_erro = "Não há código de item SAP cadastrado para este romaneio."
                execucaoerro.insertExportacaoBatchErro()
                execucaoerro.updateExportacaoBatchItens() 'atualiza status
                ValidarBatch = False
            End If

            If Me.nr_po.ToString.Trim.Equals(String.Empty) Then
                execucaoerro.nm_erro = String.Concat("Não há número de PO cadastrado para este produtor/cooperativa/agropecuária para a data ", DateTime.Parse(Me.dt_referencia).ToString("dd/MM/yyyy"), ".")
                execucaoerro.insertExportacaoBatchErro()
                execucaoerro.updateExportacaoBatchItens() 'atualiza status
                ValidarBatch = False
            End If
            'fran themis chamado 1548 17/05/2102i
            If pDensidade.Equals("0") Then
                execucaoerro.nm_erro = String.Concat("Não há valor de densidade cadastrada para a referência ", DateTime.Parse(Me.dt_referencia).ToString("dd/MM/yyyy"), ".")
                execucaoerro.insertExportacaoBatchErro()
                execucaoerro.updateExportacaoBatchItens() 'atualiza status
                ValidarBatch = False
            Else
                'fran themis 04/10/2012 i verifica se o peso da balança em litros (peso/densidade) - o total das agropecuarias é negativo
                'Se tem a densidade

                'Se no romaneio tem agropecuaria mas também tem produtores, verifica se o volume das agropecuarias é maior que o peso liquido da balança. Se for gera estoque negativo para po de produtor
                If Me.st_romaneio_com_agropecuaria.ToString.Equals("S") And Me.st_romaneio_somente_agropecuaria.ToString.Equals("N") Then
                    lvaloraux = Me.getBatchVolumeAgropecuariabyRomaneio 'pega o valor total das agropeciarias do romaneio
                    lvaloraux = (Me.nr_peso_liquido / pDensidade) - lvaloraux 'pega o peso da balanca em litros e subtrais o volume total das agropecuarias
                    If Sign(CDec(lvaloraux)) = -1 Then 'se o valor da agropecuaria é maior que o total da balança (valor negativo) 
                        execucaoerro.nm_erro = "O volume de leite da(s) Agropecuária(s) informado neste romaneio é maior que o peso líquido da balança, gerando estoque negativo."
                        execucaoerro.insertExportacaoBatchErro()
                        execucaoerro.updateExportacaoBatchItens() 'atualiza status
                        ValidarBatch = False

                    End If
                End If
                'fran themis 04/10/2012 f
            End If
            'fran themis chamado 1548 17/05/2102 f
            'fran themis 04/10/2012 i se a média de proteina ou MG ultrapassar 100 gera erro no calculo, mesmo porque estes valores não podem estar refletindo a verdade da analise
            If Me.nr_media_proteina >= 100 Then
                execucaoerro.nm_erro = "A média da proteína registrada nas análises dos compartimentos do romaneio está ultrapassando os valores de referência."
                execucaoerro.insertExportacaoBatchErro()
                execucaoerro.updateExportacaoBatchItens() 'atualiza status
                ValidarBatch = False
            End If
            If Me.nr_media_materia_gorda >= 100 Then
                execucaoerro.nm_erro = "A média da matéria gorda registrada nas análises dos compartimentos do romaneio está ultrapassando os valores de referência."
                execucaoerro.insertExportacaoBatchErro()
                execucaoerro.updateExportacaoBatchItens() 'atualiza status
                ValidarBatch = False
            End If
            If Me.st_destino_leite_rejeitado = "D" Then 'se for descarte, tem que ter pesagem intermediaria
                If Not Me.nr_pesagem_intermediaria > 0 Then
                    execucaoerro.nm_erro = "Este romaneio tem descarte de leite rejeitado. A pesagem intermediária deve ser informada!"
                    execucaoerro.insertExportacaoBatchErro()
                    execucaoerro.updateExportacaoBatchItens() 'atualiza status
                    ValidarBatch = False

                End If
            End If
            'fran themis 04/10/2012 f


        Catch ex As Exception
            ' ArquivoTexto.Close()
            Throw New Exception(ex.Message)

        End Try

    End Function
    Public Sub updateBatchRomaneioExportacao() 'fran THEMIS - Batch Declaration

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            data.Execute("ms_updateRomaneioBatchExportacao", parameters, ExecuteType.Update)

        End Using

    End Sub
    Public Function getBatchRomaneioByFilters() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneio", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
    Public Function getRomaneioExportacaoBatch() As DataSet

        Using data As New DataAccess

            Dim parameters As List(Of Parameters) = ParametersEngine.getParametersFromObject(Me)
            Dim dataSet As New DataSet

            data.Fill(dataSet, "ms_getRomaneioExportacaoBatch", parameters, "ms_romaneio")
            Return dataSet

        End Using

    End Function
End Class
