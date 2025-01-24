Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail
Imports System.IO


Partial Class frm_central_pedido
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_central_pedido.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try
 
            If Not (Request("id_central_pedido") Is Nothing) Then
                Dim parametroMilk As New Parametro
                ViewState.Item("nr_politica_parcelas") = parametroMilk.nr_politica_parcelas 'fase 3

                ViewState.Item("id_central_pedido") = Request("id_central_pedido")
                'fran 08/2014 fase 3 i
                ViewState.Item("ReabrirPedido") = "N"
                If Not (Request("tela") Is Nothing) Then
                    ViewState.Item("tela") = Request("tela").ToString
                    If ViewState.Item("tela").ToString.Equals("lst_central_pedido_reabrir.aspx") Then
                        ViewState.Item("ReabrirPedido") = "S"
                        btn_adicionar_pagto_fornecedor.Visible = True

                    End If
                Else
                    ViewState.Item("tela") = String.Empty
                End If
                'fran 08/2014 fase 3 f

                'carrega cotações
                loadData()
            Else
                ViewState.Item("id_central_pedido") = "0"
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()


        Try

            Dim liestabelecimento As Integer
            Dim pedido As New Pedido()
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
            Dim dspedido As DataSet = pedido.getPedidoByFilters
            With dspedido.Tables(0).Rows(0)

                'DADOS PEDIDO &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                lbl_id_central_pedido.Text = .Item("id_central_pedido")
                lbl_dt_pedido.Text = DateTime.Parse(.Item("dt_pedido")).ToString("dd/MM/yyyy")
                lbl_situacao_pedido.Text = .Item("nm_situacao_pedido").ToString
                lbl_estabelecimento.Text = .Item("ds_estabelecimento")
                lbl_total_pedido.Text = FormatCurrency(.Item("nr_total_pedido").ToString, 2)

                pedido.id_propriedade = Convert.ToInt32(.Item("id_propriedade").ToString)
                lbl_total_pedidos_em_aberto.Text = FormatCurrency(pedido.getTotalPedidosAbertos, 2)
                pedido.id_propriedade = 0 'limpa pedido para sqls futuros

                lbl_total_notas.Text = FormatCurrency(pedido.getCentralPedidoValorTotalNotas, 2).ToString

                cbo_parcelamento.SelectedValue = .Item("st_tipo_parcelamento").ToString
                lbl_nr_parcelas.Text = .Item("nr_qtde_parcelas").ToString
                txt_nrparcelas.Text = .Item("nr_qtde_parcelas").ToString
                ViewState.Item("nr_parcelas") = .Item("nr_qtde_parcelas").ToString

                If .Item("st_evento_compras").Equals("S") Then
                    chk_compras_evento.Checked = True
                    img_compras_evento.ImageUrl = "~/img/ico_chk_true.gif"
                Else
                    chk_compras_evento.Checked = False
                    img_compras_evento.ImageUrl = "~/img/ico_chk_false.gif"

                End If
                If .Item("st_pedido_indireto").Equals("S") Then
                    ViewState.Item("pedidoindireto") = "S"
                    img_pedido_indireto.ImageUrl = "~/img/ico_chk_true.gif"
                Else
                    ViewState.Item("pedidoindireto") = "N"
                    img_pedido_indireto.ImageUrl = "~/img/ico_chk_false.gif"
                End If

                If Not IsDBNull(.Item("id_central_interrupcao_fornecimento")) Then
                    lbl_interrupcao.Text = "Sim"
                Else
                    lbl_interrupcao.Text = "Não"
                End If

                Select Case .Item("ds_tipofrete")
                    Case "C"
                        lbl_tipo_frete.Text = "CIF"
                    Case "I"
                        lbl_tipo_frete.Text = "FOB-I"

                    Case "D"
                        lbl_tipo_frete.Text = "FOB-D"
                End Select

                'DADOS PRODUTOR PROPRIEDADE &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                lbl_nm_produtor.Text = String.Concat(.Item("cd_produtor"), " - ", .Item("nm_produtor"))
                If .Item("st_acordo_aquisicao_insumos").Equals("S") Then
                    lbl_acordo_aquisicao_insumos.Text = "SIM"
                Else
                    lbl_acordo_aquisicao_insumos.Text = "NÃO"
                End If
                lbl_ds_email.Text = .Item("ds_email")
                lbl_ds_telefone.Text = .Item("ds_telefone_1")

                'contrato
                Dim lidpessoacontrato As Integer
                If Not IsDBNull(.Item("id_pessoa_contrato")) Then
                    lidpessoacontrato = .Item("id_pessoa_contrato")
                End If

                If lidpessoacontrato = 0 Then
                    Me.lbl_contrato.Text = String.Empty
                    Me.lbl_dt_ini_contrato.Text = String.Empty
                    Me.lbl_dt_fim_contrato.Text = String.Empty
                    Me.lbl_dt_rescisao_contrato.Text = String.Empty
                Else
                    Dim contrato As New PessoaContrato()
                    contrato.id_pessoa_contrato = Convert.ToInt32(lidpessoacontrato)

                    Dim dscontrato As DataSet = contrato.getPessoaContratoByFilters()
                    If (dscontrato.Tables(0).Rows.Count <= 0) Then
                        Me.lbl_contrato.Text = String.Empty
                        Me.lbl_dt_ini_contrato.Text = String.Empty
                        Me.lbl_dt_fim_contrato.Text = String.Empty
                        Me.lbl_dt_rescisao_contrato.Text = String.Empty
                        Me.lbl_cluster.Text = String.Empty
                    Else
                        With dscontrato.Tables(0).Rows(0)
                            Me.lbl_contrato.Text = String.Concat(.Item("cd_contrato").ToString, " - ", .Item("nm_contrato").ToString)
                            If Not IsDBNull(.Item("dt_inicio_contrato")) Then
                                lbl_dt_ini_contrato.Text = DateTime.Parse(.Item("dt_inicio_contrato")).ToString("dd/MM/yyyy")
                            Else
                                lbl_dt_ini_contrato.Text = String.Empty
                            End If

                            If Not IsDBNull(.Item("dt_fim_contrato")) Then
                                lbl_dt_fim_contrato.Text = DateTime.Parse(.Item("dt_fim_contrato")).ToString("dd/MM/yyyy")
                            Else
                                lbl_dt_fim_contrato.Text = String.Empty
                            End If

                            If Not IsDBNull(.Item("dt_rescisao")) Then
                                lbl_dt_rescisao_contrato.Text = DateTime.Parse(.Item("dt_rescisao")).ToString("dd/MM/yyyy")
                            Else
                                lbl_dt_rescisao_contrato.Text = String.Empty
                            End If

                            Me.lbl_cluster.Text = .Item("nm_cluster").ToString()

                        End With

                    End If

                End If

                lbl_propriedade.Text = .Item("id_propriedade").ToString
                lbl_propriedade_matriz.Text = .Item("id_propriedade_matriz").ToString
                lbl_uf_cidade.Text = String.Concat(.Item("cd_uf").ToString, " - ", .Item("nm_cidade").ToString)


                'PARCEIRO DE INSUMOS ou TRANSPORTADOR &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                If .Item("id_grupo").ToString = "2" Then 'se o pedido é de fornecedor insumos
                    trpedidoinsumos.Visible = False

                    If .Item("nm_abreviado_fornecedor").ToString.Equals(String.Empty) Then
                        lbl_parceiro.Text = .Item("ds_fornecedor")
                    Else
                        lbl_parceiro.Text = .Item("ds_abreviado_fornecedor")
                    End If
                    If .Item("cd_cnpj_fornecedor").ToString.Equals(String.Empty) Then
                        lbl_cnpj_cpf_fornecedor.Text = .Item("cd_cpf_fornecedor").ToString
                    Else
                        lbl_cnpj_cpf_fornecedor.Text = .Item("cd_cnpj_fornecedor").ToString
                    End If
                    If .Item("st_fornecedor_cif").ToString.Equals("S") Then
                        lbl_cif_parceiro.Text = "SIM"
                    Else
                        lbl_cif_parceiro.Text = "NÃO"
                    End If
                    If .Item("st_excecao_prazo_pagto").ToString.Equals("S") Then
                        lbl_excecao_prazo_fornecedor.Text = "SIM"
                    Else
                        lbl_excecao_prazo_fornecedor.Text = "NÃO"
                    End If
                    lbl_parcelamento_parceiro.Text = String.Concat(.Item("nr_fornecedor_parcelas_central").ToString, " parcelas")

                    'se é um pedido casado (fobd) e é mais recente, mostra os dados do parceiro do frete no pedido se nao tiver pedido matriz, pedido antigo(nao mostra dados do pedido casado)
                    If .Item("ds_tipofrete") <> "D" OrElse CInt(.Item("id_central_pedido_matriz")) = 0 Then
                        tr_transportador_dados.Visible = False
                        tr_transportador_titulo.Visible = False
                        tr_transportador_pedido.Visible = False
                        ViewState.Item("id_fornecedor_frete") = 0
                        ViewState.Item("id_central_pedido_frete") = 0
                    Else
                        tr_transportador_dados.Visible = True
                        tr_transportador_titulo.Visible = True
                        tr_transportador_pedido.Visible = True

                        pedido.st_tipo_fornecedor = "T"
                        Dim dspedidofrete As DataSet = pedido.getCentralPedidoMatriz

                        If dspedidofrete.Tables(0).Rows.Count > 0 Then
                            With dspedidofrete.Tables(0).Rows(0)
                                If .Item("nm_abreviado_parceiro").ToString.Equals(String.Empty) Then
                                    lbl_trasportador.Text = .Item("ds_nm_parceiro")
                                Else
                                    lbl_trasportador.Text = .Item("ds_abreviado_parceiro")
                                End If
                                If .Item("cd_cnpj").ToString.Equals(String.Empty) Then
                                    lbl_cnpj_cpf_transportador.Text = .Item("cd_cpf").ToString
                                Else
                                    lbl_cnpj_cpf_transportador.Text = .Item("cd_cnpj").ToString
                                End If
                                If .Item("st_excecao_prazo_pagto").ToString.Equals("S") Then
                                    lbl_excecao_prazo_transp.Text = "SIM"
                                Else
                                    lbl_excecao_prazo_transp.Text = "NÃO"
                                End If

                                lbl_pedido_frete.Text = .Item("id_central_pedido").ToString
                                hl_pedidofrete.Visible = True
                                hl_pedidofrete.Text = lbl_pedido_frete.Text
                                hl_pedidofrete.NavigateUrl = String.Format("frm_central_pedido.aspx?id_central_pedido={0}", lbl_pedido_frete.Text)
                                lbl_pedido_frete.Visible = False

                                ViewState.Item("id_fornecedor_frete") = .Item("id_fornecedor")
                                ViewState.Item("id_central_pedido_frete") = .Item("id_central_pedido").ToString
                                lbl_valor_frete.Text = FormatCurrency(.Item("nr_total_pedido").ToString, 2)
                                lbl_total_notas_frete.Text = FormatCurrency(.Item("totalnotafiscal").ToString, 2)

                            End With
                        Else
                            ViewState.Item("id_fornecedor_frete") = 0
                            ViewState.Item("id_central_pedido_frete") = 0
                        End If
                    End If


                Else
                    'PEDIDO È DE FORNECEDOR TRANSPORTADOR
                    tr_transportador_pedido.Visible = False

                    If .Item("nm_abreviado_fornecedor").ToString.Equals(String.Empty) Then
                        lbl_trasportador.Text = .Item("ds_fornecedor")
                    Else
                        lbl_trasportador.Text = .Item("ds_abreviado_fornecedor")
                    End If
                    If .Item("cd_cnpj_fornecedor").ToString.Equals(String.Empty) Then
                        lbl_cnpj_cpf_transportador.Text = .Item("cd_cpf_fornecedor").ToString
                    Else
                        lbl_cnpj_cpf_transportador.Text = .Item("cd_cnpj_fornecedor").ToString
                    End If
                    If .Item("st_excecao_prazo_pagto").ToString.Equals("S") Then
                        lbl_excecao_prazo_transp.Text = "SIM"
                    Else
                        lbl_excecao_prazo_transp.Text = "NÃO"
                    End If

                    ViewState.Item("id_fornecedor_frete") = .Item("id_fornecedor")
                    ViewState.Item("id_central_pedido_frete") = ViewState.Item("id_central_pedido")

                    'se é um pedido casado (fobd) e é mais recente, mostra os dados do parceiro de insumo no pedido se nao tiver pedido matriz, pedido antigo(nao mostra dados do pedido casado)
                    If CInt(.Item("id_central_pedido_matriz")) = 0 Then
                        tr_fornec_titulo.Visible = False
                        tr_fornec_dados1.Visible = False
                        tr_fornec_dados2.Visible = False
                        trpedidoinsumos.Visible = False
                    Else
                        tr_fornec_titulo.Visible = True
                        tr_fornec_dados1.Visible = True
                        tr_fornec_dados2.Visible = True
                        trpedidoinsumos.Visible = True

                        pedido.st_tipo_fornecedor = "F"
                        Dim dspedidoinsumo As DataSet = pedido.getCentralPedidoMatriz

                        If dspedidoinsumo.Tables(0).Rows.Count > 0 Then
                            With dspedidoinsumo.Tables(0).Rows(0)
                                If .Item("nm_abreviado_parceiro").ToString.Equals(String.Empty) Then
                                    lbl_parceiro.Text = .Item("ds_nm_parceiro")
                                Else
                                    lbl_parceiro.Text = .Item("ds_abreviado_parceiro")
                                End If
                                If .Item("cd_cnpj").ToString.Equals(String.Empty) Then
                                    lbl_cnpj_cpf_fornecedor.Text = .Item("cd_cpf").ToString
                                Else
                                    lbl_cnpj_cpf_fornecedor.Text = .Item("cd_cnpj").ToString
                                End If
                                If .Item("st_fornecedor_cif").ToString.Equals("S") Then
                                    lbl_cif_parceiro.Text = "SIM"
                                Else
                                    lbl_cif_parceiro.Text = "NÃO"
                                End If
                                If .Item("st_excecao_prazo_pagto").ToString.Equals("S") Then
                                    lbl_excecao_prazo_fornecedor.Text = "SIM"
                                Else
                                    lbl_excecao_prazo_fornecedor.Text = "NÃO"
                                End If
                                lbl_parcelamento_parceiro.Text = String.Concat(.Item("nr_fornecedor_parcelas_central").ToString, " parcelas")

                                lbl_pedido_insumos.Text = .Item("id_central_pedido").ToString
                                lbl_total_pedido_insumos.Text = FormatCurrency(.Item("nr_total_pedido").ToString, 2)
                                lbl_total_notas_insumos.Text = FormatCurrency(.Item("totalnotafiscal").ToString, 2)

                            End With
                        End If
                    End If
                End If


                'se for traansportador atualiza emails e grids que podem ser visualizados
                If .Item("id_grupo") = "3" Then 'se transportador
                    lbl_titulo.Visible = True
                    tr_entregas.Visible = False
                    tr_entregas_grid.Visible = False
                    lk_email_produtor.Visible = False
                    img_notificacao.Visible = False
                    lk_email_parceiro.Visible = False
                    img_parceiro.Visible = False
                    lk_email_parceiro_frete.Visible = True
                    img_parceiro_frete.Visible = True
                Else
                    lk_email_produtor.Visible = True
                    img_notificacao.Visible = True
                    lk_email_parceiro.Visible = True
                    img_parceiro.Visible = True
                    If .Item("ds_tipofrete").ToString = "D" Then
                        lk_email_parceiro_frete.Visible = True
                        img_parceiro_frete.Visible = True
                    Else
                        lk_email_parceiro_frete.Visible = False
                        img_parceiro_frete.Visible = False

                    End If
                End If

                'ATAUALIZA VARIAVEIS PARA PROCESSO
                ViewState.Item("id_central_pedido_matriz") = .Item("id_central_pedido_matriz")
                ViewState.Item("id_situacao_pedido") = .Item("id_situacao_pedido") 'fran 01/05/2005 chamado 812
                ViewState.Item("id_fornecedor") = .Item("id_fornecedor")
                ViewState.Item("id_produtor") = .Item("id_pessoa")
                ViewState.Item("id_propriedade") = .Item("id_propriedade")
                ViewState.Item("id_propriedade_matriz") = .Item("id_propriedade_matriz")
                ViewState.Item("nm_estabelecimento") = .Item("nm_estabelecimento") 'fran 14/05/2010 chamado 816
                liestabelecimento = .Item("id_estabelecimento") 'fran 10/2018 
                ViewState.Item("id_grupo") = .Item("id_grupo")
                If IsDBNull(.Item("id_situacao_pedido_ant")) Then
                    ViewState.Item("id_situacao_pedido_ant") = 0
                Else
                    ViewState.Item("id_situacao_pedido_ant") = CInt(.Item("id_situacao_pedido_ant").ToString)
                End If

            End With

            'limpa campo utilizado acima
            pedido.st_tipo_fornecedor = String.Empty


            'DADOS DO ITEM &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            Dim itens As New PedidoItem
            itens.id_central_pedido = ViewState.Item("id_central_pedido").ToString
            Dim dsItens As DataSet = itens.getPedidoItensByFilters()
            With dsItens.Tables(0).Rows(0)

                lbl_cd_item.Text = .Item("cd_item").ToString
                lbl_item_nm.Text = .Item("nm_item").ToString
                lbl_item_un.Text = .Item("nm_unidade_medida").ToString
                lbl_item_categoria.Text = .Item("nm_categoria_item").ToString
                Select Case .Item("ds_tipo_medida").ToString
                    Case "G"
                        lbl_tipo_embalagem.Text = "Granel"
                    Case "S"
                        lbl_tipo_embalagem.Text = "Sacaria"
                    Case "O"
                        lbl_tipo_embalagem.Text = "Outros"
                End Select
                lbl_nr_qtde.Text = FormatNumber(.Item("nr_quantidade").ToString, 4)
                lbl_vl_unitario.Text = FormatNumber(.Item("nr_valor_unitario").ToString, 2)
                lbl_sacaria.Text = FormatNumber(.Item("nr_sacaria").ToString, 2)
                lbl_frete.Text = FormatNumber(.Item("nr_frete").ToString, 2)
                txt_nrqtdeitem.Text = lbl_nr_qtde.Text

                'atualiza variaveis item
                ViewState.Item("id_central_pedido_item") = .Item("id_central_pedido_item").ToString
                ViewState.Item("id_item") = .Item("id_item").ToString
                ViewState.Item("nr_quantidade_item") = CDec(.Item("nr_quantidade").ToString)
                ViewState.Item("st_parcelamento") = .Item("st_parcelamento")

            End With

            'ANTES DO CONTROLE VISUAL CARREGA GRID DE NOTAS PARA APURAR SE ALGUMA NOTA PODERA SER EXCLUIDA
            loadGridNotas()

            loadComboNotas()

            'CONTROLE VISUAL
            Dim lqtdeparcelascomexportacaopedido As Int16 = 0
            Dim lqtdeparcelaspedidoforn As Int16 = 0
            Dim lqtdeparcelascomcalculopedido As Int16 = 0
            Dim lqtdeparcelaspedidoprod As Int16 = 0


            Dim lnrtotalpedidominimo As Decimal = CDec(lbl_total_pedido.Text) - (CDec(lbl_total_pedido.Text) * 0.03)
            Dim lnrtotalnotaspedido As Decimal = CDec(lbl_total_notas.Text)

            'Tudo da tela entra como enable false, com se fosse so consulta mesmo
            Select Case CInt(ViewState.Item("id_situacao_pedido").ToString)
                Case 1, 6 'em aberto ou aprovado

                    'EDICAO DE PEDIDO
                    'Nao pode ter habilitado botao salvar e editar porque salva a primeira vez por finalizar pedido(tela ja entra visible false)
                    btn_pedidoeditar.Enabled = False
                    btn_pedidosalvar.Enabled = False
                    btn_pedidoeditar.Visible = False
                    img_pedidoeditar.Visible = False
                    btn_pedidosalvar.Visible = False
                    img_pedidosalvar.Visible = False

                    'INCLUSAO DE NOTAS
                    'deve poder ver inclusao de notas 
                    btn_incluirnota.Enabled = True

                    'GRIDS ADICIONAR PARCELAS
                    'botoes dos grid para adicionar  devem estar habilitados
                    btn_adicionar_entrega.Enabled = True

                    If ViewState.Item("bTemNotas") = True Then 'se tem linhas no grid de notas
                        btn_adicionar_pagto_fornecedor.Enabled = True
                        btn_adicionar_desconto_prod.Enabled = True
                        'If ViewState.Item("st_parcelamento").ToString.Equals("N") Then 'Se parcelamento é a vista
                        '    btn_adicionar_desconto_prod.Enabled = False 'Não deve informar mais parcelas se o parcelamento é a vista. Deve atualizar combo
                        'Else
                        '    btn_adicionar_desconto_prod.Enabled = True
                        'End If
                        'Carrega parcelas se pedido nao estiver finalizado nem estiver reabrindo pedido
                        loadParcelasProdutorFornecedor()
                    End If

                    'COLUNAS ALTERACAO GRIDS
                    'deve ficar visivel (tela ja entra visivel)

                    'CAMPO PARCELAMENTO VISIVEL 
                    cbo_parcelamento.Enabled = True

                    lbl_nr_qtde.Visible = False
                    txt_nrqtdeitem.Enabled = True
                    txt_nrqtdeitem.Visible = True
                    btn_atualizar_qtdeitem.Enabled = True
                    btn_atualizar_qtdeitem.Visible = True

                    lbl_nr_parcelas.Visible = False
                    txt_nrparcelas.Enabled = True
                    txt_nrparcelas.Visible = True
                    btn_atualizar_parcela.Enabled = True
                    btn_atualizar_parcela.Visible = True

                    'CAMPO EVENTO COMPRAS fica habilitado 
                    img_compras_evento.Visible = False
                    chk_compras_evento.Visible = True


                    If ViewState.Item("id_grupo").ToString.Equals("2") AndAlso Left(lbl_cif_parceiro.Text, 1) = "N" Then
                        lk_atualizar_frete.Visible = True
                        lk_atualizar_frete.Enabled = True
                    End If
                    'botao gerar pedido
                    lk_gerar_pedido.Enabled = True

                    If ViewState.Item("id_fornecedor_frete").ToString = "0" Then
                        lk_email_parceiro_frete.Enabled = False
                    Else
                        lk_email_parceiro_frete.Enabled = True
                    End If
                    lk_email_produtor.Enabled = True
                    lk_email_parceiro.Enabled = True

                    'deixa tudo aberto
                Case 2, 5, 7, 11, 12 'cancelado, em aprovacao, recusado, em aprovacao fornecedor, recusado fornecedor
                    'Não pode fazer nenhuma alteração

                    'EDICAO DE PEDIDO
                    'Nao pode ter habilitado botao salvar e editar (tela ja entra visible false)
                    btn_pedidoeditar.Enabled = False
                    btn_pedidosalvar.Enabled = False
                    btn_pedidoeditar.Visible = False
                    img_pedidoeditar.Visible = False
                    btn_pedidosalvar.Visible = False
                    img_pedidosalvar.Visible = False

                    'INCLUSAO DE NOTAS
                    'nao deve poder ver inclusao de notas (tela ja entra visible false)

                    'GRIDS ADICIONAR PARCELAS
                    'botoes dos grid para adicionar  devem estar desabilitados tela ja entra desabilitado

                    'COLUNAS ALTERACAO GRIDS
                    gridNotas.Columns.Item(7).Visible = False
                    gridEntrega.Columns.Item(5).Visible = False
                    gridPagtoForn.Columns.Item(12).Visible = False
                    grdDescProdutor.Columns.Item(11).Visible = False

                    'CAMPO PARCELAMENTO NAO ALTERAVEL (tela ja entra desabilitado)

                    'CAMPO EVENTO COMPRAS fica habilitado (ja entra desabilitado)

                    lk_email_parceiro_frete.Enabled = False
                    lk_email_produtor.Enabled = False
                    lk_email_parceiro.Enabled = False

                    'fran dezembro/2018 i mais solidos
                    'se estiver finalizado so visualiza
                    chk_compras_evento.Visible = False
                    img_compras_evento.Visible = True
                    'fran dezembro/2018 f

                    lk_gerar_pedido.Enabled = False
                Case 3, 8 'finalizado ou finalizado parcial


                    'botao de finalizar pedido deve ficar desabilitado situacao de finalizado nao finaliza novamente (tela inicia desabilitado)

                    If ViewState.Item("pedidoindireto").ToString.Equals("S") Then
                        'deixa tudo desabilitado, como ja vem na tela

                        lk_email_parceiro_frete.Enabled = False
                        lk_email_produtor.Enabled = False
                        lk_email_parceiro.Enabled = True

                        If ViewState.Item("id_situacao_pedido") = 3 Then
                            'COLUNAS ALTERACAO GRIDS
                            gridNotas.Columns.Item(7).Visible = False
                            gridEntrega.Columns.Item(5).Visible = False
                            gridPagtoForn.Columns.Item(12).Visible = False
                            grdDescProdutor.Columns.Item(11).Visible = False
                            lk_gerar_pedido.Enabled = False
                        Else
                            'COLUNAS ALTERACAO GRIDS
                            gridNotas.Columns.Item(7).Visible = True
                            gridEntrega.Columns.Item(5).Visible = True
                            gridPagtoForn.Columns.Item(12).Visible = True
                            lk_gerar_pedido.Enabled = True
                        End If
                        'COLUNAS ALTERACAO GRIDS

                    Else
                        Dim pedidonota As New PedidoNotas
                        pedidonota.id_central_pedido = CInt(ViewState.Item("id_central_pedido").ToString)
                        Dim dspedidonota As DataSet

                        'APURA EXPORTACAO E CALCULO dos grids de pagamento
                        dspedidonota = pedidonota.getPedidoNotasByFilters
                        'pega so a primeira nota que vier porque so vai utilizar totalizado do pedido
                        With dspedidonota.Tables(0).Rows(0)
                            lqtdeparcelaspedidoforn = CInt(.Item("nr_qtde_parcelas_pedido_forn").ToString)
                            lqtdeparcelaspedidoprod = CInt(.Item("nr_qtde_parcelas_pedido_prod").ToString)

                            'se é zero nao tem inclusao de grid fornecedor
                            If lqtdeparcelaspedidoforn > 0 Then
                                lqtdeparcelascomexportacaopedido = CInt(.Item("nr_qtde_parcelas_com_exportacao_pedido").ToString)
                            Else
                                lqtdeparcelascomexportacaopedido = 0
                            End If

                            If lqtdeparcelaspedidoprod > 0 Then
                                lqtdeparcelascomcalculopedido = CInt(.Item("nr_qtde_parcelas_com_calculo_pedido").ToString)
                            Else
                                lqtdeparcelascomcalculopedido = 0
                            End If
                        End With

                        If ViewState.Item("id_grupo") = "3" Then
                            lk_email_parceiro.Enabled = False
                            lk_email_produtor.Enabled = False
                            lk_email_parceiro_frete.Enabled = True
                        Else
                            lk_email_parceiro.Enabled = True
                            lk_email_produtor.Enabled = True
                            If ViewState.Item("id_fornecedor_frete").ToString = "0" Then
                                lk_email_parceiro_frete.Enabled = False
                            Else
                                lk_email_parceiro_frete.Enabled = True
                            End If
                        End If

                        If ViewState.Item("id_situacao_pedido") = 3 Then
                            lk_gerar_pedido.Enabled = False

                            'se tem cadastro de desconto produtor e pagto fornecedor, e ja pagou tudo e exportou tudo
                            If lqtdeparcelaspedidoforn > 0 AndAlso lqtdeparcelaspedidoprod > 0 AndAlso lqtdeparcelaspedidoforn = lqtdeparcelascomexportacaopedido AndAlso lqtdeparcelaspedidoprod = lqtdeparcelascomcalculopedido Then
                                'EDICAO DE PEDIDO
                                btn_pedidoeditar.Visible = False
                                img_pedidoeditar.Visible = False
                                btn_pedidosalvar.Visible = False
                                img_pedidosalvar.Visible = False
                                btn_pedidoeditar.Enabled = False
                                btn_pedidosalvar.Enabled = False
                                gridEntrega.Columns.Item(5).Visible = False
                                lk_email_parceiro.Enabled = False
                                lk_email_produtor.Enabled = False
                                lk_email_parceiro_frete.Enabled = False

                            Else
                                'EDICAO DE PEDIDO
                                btn_pedidoeditar.Visible = True
                                img_pedidoeditar.Visible = True
                                btn_pedidosalvar.Visible = True
                                img_pedidosalvar.Visible = True
                                btn_pedidoeditar.Enabled = True
                                btn_pedidosalvar.Enabled = False

                            End If
                        Else
                            ' se for finalizado parcial

                            'habilita finalizar para poder findar o finalizado parcial
                            lk_gerar_pedido.Enabled = True

                            'EDICAO DE PEDIDO
                            btn_pedidoeditar.Visible = True
                            img_pedidoeditar.Visible = True
                            btn_pedidosalvar.Visible = True
                            img_pedidosalvar.Visible = True
                            btn_pedidoeditar.Enabled = True
                            btn_pedidosalvar.Enabled = False

                        End If

                        gridNotas.Columns.Item(7).Visible = False
                        gridPagtoForn.Columns.Item(12).Visible = False
                        grdDescProdutor.Columns.Item(11).Visible = False

                        If ViewState.Item("id_grupo").ToString.Equals("2") AndAlso Left(lbl_cif_parceiro.Text, 1) = "N" Then
                            lk_atualizar_frete.Visible = True
                            lk_atualizar_frete.Enabled = True
                        End If

                        If lbl_interrupcao.Text = "Sim" AndAlso btn_pedidoeditar.Enabled = True Then
                            btn_pedidoeditar.Visible = False
                            img_pedidoeditar.Visible = False
                            btn_pedidosalvar.Visible = False
                            img_pedidosalvar.Visible = False
                            btn_pedidoeditar.Enabled = False
                            btn_pedidosalvar.Enabled = False

                        End If

                    End If

                Case 4 'reaberto / edicao

                    ViewState.Item("ReabrirPedido") = "S"

                    'EDICAO DE PEDIDO
                    btn_pedidoeditar.Visible = True
                    img_pedidoeditar.Visible = True
                    btn_pedidosalvar.Visible = True
                    img_pedidosalvar.Visible = True

                    btn_pedidoeditar.Enabled = False
                    btn_pedidosalvar.Enabled = True

                    Dim pedidonota As New PedidoNotas
                    pedidonota.id_central_pedido = CInt(ViewState.Item("id_central_pedido").ToString)
                    Dim dspedidonota As DataSet

                    'APURA EXPORTACAO E CALCULO dos grids de pagamento
                    dspedidonota = pedidonota.getPedidoNotasByFilters
                    'pega so a primeira nota que vier porque so vai utilizar totalizado do pedido
                    With dspedidonota.Tables(0).Rows(0)
                        lqtdeparcelaspedidoforn = CInt(.Item("nr_qtde_parcelas_pedido_forn").ToString)
                        lqtdeparcelaspedidoprod = CInt(.Item("nr_qtde_parcelas_pedido_prod").ToString)

                        'se é zero nao tem inclusao de grid fornecedor
                        If lqtdeparcelaspedidoforn > 0 Then
                            lqtdeparcelascomexportacaopedido = CInt(.Item("nr_qtde_parcelas_com_exportacao_pedido").ToString)
                        Else
                            lqtdeparcelascomexportacaopedido = 0
                        End If

                        If lqtdeparcelaspedidoprod > 0 Then
                            lqtdeparcelascomcalculopedido = CInt(.Item("nr_qtde_parcelas_com_calculo_pedido").ToString)
                        Else
                            lqtdeparcelascomcalculopedido = 0
                        End If
                    End With

                    'se antes de reabrir o pedido era finalizado parcial
                    If CInt(ViewState.Item("id_situacao_pedido_ant")).Equals(8) Then
                        'INCLUSAO DE NOTAS
                        btn_incluirnota.Enabled = True
                        gridNotas.Columns.Item(7).Visible = True
                    Else 'se era finalizado
                        'pedido ja finalizado manualmente ou automatico nao entra mais notas e nao exclui as que tem


                        'se tem cadastro de desconto produtor e pagto fornecedor, e ja pagou tudo e exportou tudo
                        If lqtdeparcelaspedidoforn > 0 AndAlso lqtdeparcelaspedidoprod > 0 AndAlso lqtdeparcelaspedidoforn = lqtdeparcelascomexportacaopedido AndAlso lqtdeparcelaspedidoprod = lqtdeparcelascomcalculopedido Then
                            btn_incluirnota.Enabled = False
                            gridNotas.Columns.Item(7).Visible = False

                        Else
                            btn_incluirnota.Enabled = True
                            gridNotas.Columns.Item(7).Visible = True

                        End If


                    End If

                    'GRIDS ADICIONAR PARCELAS
                    'botoes dos grid para adicionar  devem estar desabilitados
                    btn_adicionar_entrega.Enabled = True
                    btn_adicionar_pagto_fornecedor.Enabled = True
                    btn_incluir_parcelas_fornecedor.Enabled = True

                    'If ViewState.Item("st_parcelamento").ToString.Equals("N") AndAlso lqtdeparcelaspedidoprod > 0 Then 'Se parcelamento é a vista
                    '    btn_adicionar_desconto_prod.Enabled = False 'Não deve informar mais parcelas se o parcelamento é a vista. Deve atualizar combo
                    '    btn_incluir_parcelas_produtor.Enabled = False
                    'Else
                    '    btn_adicionar_desconto_prod.Enabled = True
                    '    btn_incluir_parcelas_produtor.Enabled = True
                    'End If

                    btn_adicionar_desconto_prod.Enabled = True
                    btn_incluir_parcelas_produtor.Enabled = True

                    'COLUNAS ALTERACAO GRIDS
                    gridEntrega.Columns.Item(5).Visible = True
                    gridPagtoForn.Columns.Item(12).Visible = True
                    grdDescProdutor.Columns.Item(11).Visible = True

                    'CAMPO PARCELAMENTO VISIVEL (tela ja entra visible)
                    cbo_parcelamento.Enabled = True

                    'CAMPO EVENTO COMPRAS fica habilitado 
                    chk_compras_evento.Visible = True
                    img_compras_evento.Visible = False

                    'se for transportador EMAIL VAI ENVIAR CANCELAMENTO???
                    'If ViewState.Item("id_grupo") = "3" Then
                    lk_email_parceiro.Enabled = False
                    lk_email_parceiro_frete.Enabled = False
                    lk_email_produtor.Enabled = False
                    'Else
                    'lk_email_parceiro.Enabled = True
                    'lk_email_produtor.Enabled = True
                    'End If

                    lk_gerar_pedido.Enabled = False



            End Select

            loadGridEntrega()
            loadGridPagtoFornecedor()
            If ViewState.Item("pedidoindireto").ToString.Equals("N") Then
                loadGridDescontoProdutor()
            Else
                gridPagtoForn.Columns.Item(7).Visible = False 'Exportação

                tr_desc_produtor.Visible = False
                tr_desc_produtor_grid.Visible = False
                lk_email_parceiro_frete.Enabled = False
                lk_email_produtor.Enabled = False
                lk_email_parceiro.Enabled = True
                tr_desc_produtor_incluir.Visible = False
            End If

            loadGridObservacao() 'fran 08/2014 i
            'se nao tem nota informada
            If ViewState.Item("bTemNotas") = False Then
                btn_adicionar_desconto_prod.Enabled = False
                btn_adicionar_pagto_fornecedor.Enabled = False
                btn_incluir_parcelas_fornecedor.Enabled = False
                btn_incluir_parcelas_produtor.Enabled = False
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click

        'fran 08/2014 fase 3 i
        'Response.Redirect("lst_central_pedido.aspx")

        Select Case ViewState.Item("tela").ToString
            Case String.Empty
                Response.Redirect("lst_central_pedido.aspx")

            Case "lst_central_pedido_reabrir.aspx"
                Response.Redirect("lst_central_pedido_reabrir.aspx")
        End Select
        'fran 08/2014 fase 3 f


    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private Sub loadGridNotas()
        Try

            'Carrega os dados do Grid
            Dim notas As New PedidoNotas

            ViewState.Item("bNotasPodeExcluir") = False
            ViewState.Item("bTemNotas") = False

            notas.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
            Dim dspedidonota As DataSet = notas.getPedidoNotasByFilters()

            If (dspedidonota.Tables(0).Rows.Count > 0) Then
                ViewState.Item("bTemNotas") = True
                gridNotas.Visible = True
                gridNotas.DataSource = Helper.getDataView(dspedidonota.Tables(0), "dt_emissao")
                gridNotas.DataBind()
            Else
                Dim dr As DataRow = dspedidonota.Tables(0).NewRow()
                dspedidonota.Tables(0).Rows.InsertAt(dr, 0)
                gridNotas.Visible = True
                gridNotas.DataSource = Helper.getDataView(dspedidonota.Tables(0), "")
                gridNotas.DataBind()
                gridNotas.Rows(0).Cells.Clear()
                gridNotas.Rows(0).Cells.Add(New TableCell())
                gridNotas.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridNotas.Rows(0).Cells(0).Text = "Não existe ainda nenhuma nota fiscal associada ao Pedido!"
                gridNotas.Rows(0).Cells(0).ColumnSpan = 8

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadGridEntrega()
        Try

            If ViewState.Item("id_central_pedido_item") Is Nothing Then
                ViewState.Item("id_central_pedido_item") = 0
            End If
            'Carrega os dados do Grid
            Dim entrega As New PedidoEntrega
            If CLng(ViewState.Item("id_central_pedido_item")) > 0 Then
                entrega.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item"))

                Dim dsCotFornecedor As DataSet = entrega.getPedidoEntregaByFilters()

                If (dsCotFornecedor.Tables(0).Rows.Count > 0) Then
                    gridEntrega.Visible = True
                    gridEntrega.DataSource = Helper.getDataView(dsCotFornecedor.Tables(0), "nr_parcela")
                    gridEntrega.DataBind()
                Else
                    Dim dr As DataRow = dsCotFornecedor.Tables(0).NewRow()
                    dsCotFornecedor.Tables(0).Rows.InsertAt(dr, 0)
                    gridEntrega.Visible = True
                    gridEntrega.DataSource = Helper.getDataView(dsCotFornecedor.Tables(0), "")
                    gridEntrega.DataBind()
                    gridEntrega.Rows(0).Cells.Clear()
                    gridEntrega.Rows(0).Cells.Add(New TableCell())
                    gridEntrega.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridEntrega.Rows(0).Cells(0).Text = "Não existe ainda nenhuma entrega informada para o Item selecionado!"
                    gridEntrega.Rows(0).Cells(0).ColumnSpan = 11

                End If
            Else
                entrega.id_central_pedido_item = -1
                Dim dsentrega As DataSet = entrega.getPedidoEntregaByFilters()
                Dim dr As DataRow = dsentrega.Tables(0).NewRow()
                dsentrega.Tables(0).Rows.InsertAt(dr, 0)
                gridEntrega.Visible = True
                gridEntrega.DataSource = Helper.getDataView(dsentrega.Tables(0), "")
                gridEntrega.DataBind()
                gridEntrega.Rows(0).Cells.Clear()
                gridEntrega.Rows(0).Cells.Add(New TableCell())
                gridEntrega.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridEntrega.Rows(0).Cells(0).Text = "Selecione o detalhe do item para visualizar suas entregas."
                gridEntrega.Rows(0).Cells(0).ColumnSpan = 11
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadGridObservacao() 'fran 08/2014 fase 3


        Try

            If ViewState.Item("id_central_pedido") Is Nothing Then
                ViewState.Item("id_central_pedido") = 0
            End If
            'Carrega os dados do Grid
            Dim obs As New PedidoObservacao
            If CLng(ViewState.Item("id_central_pedido")) > 0 Then
                obs.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))

                Dim dsObs As DataSet = obs.getPedidoObservacaoByFilters()

                If (dsObs.Tables(0).Rows.Count > 0) Then
                    gridObs.Visible = True
                    gridObs.DataSource = Helper.getDataView(dsObs.Tables(0), "dt_criacao")
                    gridObs.DataBind()
                Else
                    Dim dr As DataRow = dsObs.Tables(0).NewRow()
                    dsObs.Tables(0).Rows.InsertAt(dr, 0)
                    gridObs.Visible = True
                    gridObs.DataSource = Helper.getDataView(dsObs.Tables(0), "")
                    gridObs.DataBind()
                    gridObs.Rows(0).Cells.Clear()
                    gridObs.Rows(0).Cells.Add(New TableCell())
                    gridObs.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridObs.Rows(0).Cells(0).Text = "Não existe ainda nenhuma observação informada para o Pedido!"
                    gridObs.Rows(0).Cells(0).ColumnSpan = 4

                End If
            Else
                obs.id_central_pedido = -1
                Dim dsobs As DataSet = obs.getPedidoObservacaoByFilters()
                Dim dr As DataRow = dsobs.Tables(0).NewRow()
                dsobs.Tables(0).Rows.InsertAt(dr, 0)
                gridObs.Visible = True
                gridObs.DataSource = Helper.getDataView(dsobs.Tables(0), "")
                gridObs.DataBind()
                gridObs.Rows(0).Cells.Clear()
                gridObs.Rows(0).Cells.Add(New TableCell())
                gridObs.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridObs.Rows(0).Cells(0).Text = "Não existe ainda nenhuma observação informada para o Pedido!"
                gridObs.Rows(0).Cells(0).ColumnSpan = 4
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadGridPagtoFornecedor()
        Try

            If ViewState.Item("id_central_pedido") Is Nothing Then
                ViewState.Item("id_central_pedido") = 0
            End If
            'Carrega os dados do Grid
            Dim pagto As New PedidoPagtoFornecedor
            If CLng(ViewState.Item("id_central_pedido")) > 0 Then
                pagto.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
                pagto.id_situacao = 1 'chamado 860 item 7 fran 19/10/2010
                Dim dsPagFornecedor As DataSet = pagto.getPedidoPagtoFornecedorByFilters()

                If (dsPagFornecedor.Tables(0).Rows.Count > 0) Then
                    gridPagtoForn.Visible = True
                    gridPagtoForn.DataSource = Helper.getDataView(dsPagFornecedor.Tables(0), "nr_nota_fiscal,dt_pagto,nr_parcela")
                    gridPagtoForn.DataBind()
                Else
                    Dim dr As DataRow = dsPagFornecedor.Tables(0).NewRow()
                    dsPagFornecedor.Tables(0).Rows.InsertAt(dr, 0)
                    gridPagtoForn.Visible = True
                    gridPagtoForn.DataSource = Helper.getDataView(dsPagFornecedor.Tables(0), "")
                    gridPagtoForn.DataBind()
                    gridPagtoForn.Rows(0).Cells.Clear()
                    gridPagtoForn.Rows(0).Cells.Add(New TableCell())
                    gridPagtoForn.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridPagtoForn.Rows(0).Cells(0).Text = "Não existe ainda nenhum pagamento ao fornecedor informado para o Pedido"
                    gridPagtoForn.Rows(0).Cells(0).ColumnSpan = 8

                End If
            Else
                pagto.id_central_pedido_item = -1
                Dim dspagto As DataSet = pagto.getPedidoPagtoFornecedorByFilters()
                Dim dr As DataRow = dspagto.Tables(0).NewRow()
                dspagto.Tables(0).Rows.InsertAt(dr, 0)
                gridPagtoForn.Visible = True
                gridPagtoForn.DataSource = Helper.getDataView(dspagto.Tables(0), "")
                gridPagtoForn.DataBind()
                gridPagtoForn.Rows(0).Cells.Clear()
                gridPagtoForn.Rows(0).Cells.Add(New TableCell())
                gridPagtoForn.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridPagtoForn.Rows(0).Cells(0).Text = "Selecione o detalhe do item para visualizar suas entregas."
                gridPagtoForn.Rows(0).Cells(0).ColumnSpan = 8
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadGridDescontoProdutor()


        Try
            If ViewState.Item("pedidoindireto") = "N" Then 'fran fase 3

                If ViewState.Item("id_central_pedido") Is Nothing Then
                    ViewState.Item("id_central_pedido") = 0
                End If
                'Carrega os dados do Grid
                Dim desconto As New PedidoDescontoProdutor
                If CLng(ViewState.Item("id_central_pedido")) > 0 Then
                    desconto.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))

                    Dim dsDescProdutor As DataSet = desconto.getPedidoDescontoProdutorByFilters

                    If (dsDescProdutor.Tables(0).Rows.Count > 0) Then
                        grdDescProdutor.Visible = True
                        grdDescProdutor.DataSource = Helper.getDataView(dsDescProdutor.Tables(0), "nr_nota_fiscal, nr_parcela")
                        grdDescProdutor.DataBind()
                    Else
                        Dim dr As DataRow = dsDescProdutor.Tables(0).NewRow()
                        dsDescProdutor.Tables(0).Rows.InsertAt(dr, 0)
                        grdDescProdutor.Visible = True
                        grdDescProdutor.DataSource = Helper.getDataView(dsDescProdutor.Tables(0), "")
                        grdDescProdutor.DataBind()
                        grdDescProdutor.Rows(0).Cells.Clear()
                        grdDescProdutor.Rows(0).Cells.Add(New TableCell())
                        grdDescProdutor.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                        grdDescProdutor.Rows(0).Cells(0).Text = "Não existe ainda nenhum desconto ao produtor informado para o Pedido!"
                        grdDescProdutor.Rows(0).Cells(0).ColumnSpan = 6
                    End If
                Else
                    desconto.id_central_pedido_item = -1
                    Dim dsentrega As DataSet = desconto.getPedidoDescontoProdutorByFilters()
                    Dim dr As DataRow = dsentrega.Tables(0).NewRow()
                    dsentrega.Tables(0).Rows.InsertAt(dr, 0)
                    grdDescProdutor.Visible = True
                    grdDescProdutor.DataSource = Helper.getDataView(dsentrega.Tables(0), "")
                    grdDescProdutor.DataBind()
                    grdDescProdutor.Rows(0).Cells.Clear()
                    grdDescProdutor.Rows(0).Cells.Add(New TableCell())
                    grdDescProdutor.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    grdDescProdutor.Rows(0).Cells(0).Text = "Selecione o detalhe do item para visualizar suas entregas."
                    grdDescProdutor.Rows(0).Cells(0).ColumnSpan = 11
                End If
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub btn_adicionar_cotacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar_entrega.Click
        ViewState.Item("incluirlinha") = "S"
        Dim entrega As New PedidoEntrega
        entrega.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item"))
        Dim dsentrega As DataSet = entrega.getPedidoEntregaByFilters()
        Dim dr As DataRow = dsentrega.Tables(0).NewRow()
        dsentrega.Tables(0).Rows.InsertAt(dr, 0)
        ViewState.Item("incluirlinhaentrega") = "S"
        gridEntrega.Visible = True
        gridEntrega.DataSource = Helper.getDataView(dsentrega.Tables(0), "nr_parcela")
        gridEntrega.EditIndex = 0
        gridEntrega.DataBind()
        ViewState.Item("incluirlinha") = Nothing

    End Sub
    Private Sub deletePedidoEntrega(ByVal id_central_pedido_entrega As Integer)
        If Page.IsValid Then


            Try
                'Deleta a cotacao fornecedor
                Dim entrega As New PedidoEntrega

                entrega.id_central_pedido_entrega = id_central_pedido_entrega
                entrega.deletePedidoEntrega()
                messageControl.Alert("Registro excluído com sucesso!")
                loadGridEntrega()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Private Sub loadParcelasProdutorFornecedor(Optional ByVal pdt_emissaonf As String = "", Optional ByVal pidcentralpedidonotas As Integer = 0)

        Try


            'FORNECDEOR
            btn_incluir_parcelas_fornecedor.Enabled = True
            btn_incluir_parcelas_produtor.Enabled = True

            'Busca os pedidos com item selecionado
            Dim pedidoitem As New PedidoItem(Convert.ToInt32(ViewState.Item("id_central_pedido_item")))
            Dim pedido As New Pedido
            Dim ldtaux As String


            'se ainda nao tem nota cadastrada, sugere valor
            If pidcentralpedidonotas > 0 Then

                Dim pedidofornecedor As New PedidoPagtoFornecedor
                pedidofornecedor.id_central_pedido = CLng(ViewState.Item("id_central_pedido"))
                pedidofornecedor.id_central_pedido_notas = pidcentralpedidonotas

                Dim dspedidofornecedor As DataSet = pedidofornecedor.getPedidoPagtoFornecedorByFilters

                Dim pedidoprodutor As New PedidoDescontoProdutor
                pedidoprodutor.id_central_pedido = CLng(ViewState.Item("id_central_pedido"))
                pedidoprodutor.id_central_pedido_notas = pidcentralpedidonotas

                Dim dspedidoprodutor As DataSet = pedidoprodutor.getPedidoDescontoProdutorByFilters

                If dspedidofornecedor.Tables(0).Rows.Count = 0 Then 'se nao tem linhas informadas em pagamento fornecedor, sugere 
                    'txt_valor_nota_fiscal_forn.Text = pedidoitem.nr_valor_total
                    If CInt(pedidoitem.nr_parcelas) > 1 Then 'se é Parcelado
                        txt_total_parcelas_forn.Text = pedidoitem.nr_parcelas
                    Else
                        txt_total_parcelas_forn.Text = 1
                    End If

                    If Not pedidoitem.st_parcelamento Is Nothing Then
                        If pedidoitem.st_parcelamento.Equals("D") Then 'SEfor parcelamento DANONE assume 1 parcela para fornecedor
                            txt_total_parcelas_forn.Text = 1
                        End If
                    End If


                    'se for fornecedor de insumos
                    If ViewState.Item("id_grupo") = "2" Then
                        pedido.calcularDataPagtoFornecedor(pdt_emissaonf, Left(lbl_excecao_prazo_fornecedor.Text, 1), pedidoitem.st_parcelamento.ToString, pedidoitem.nr_parcelas, txt_dt_primeiro_pagto_forn.Text, ldtaux)
                    Else
                        pedido.calcularDataPagtoTransportador(pdt_emissaonf, Left(lbl_excecao_prazo_fornecedor.Text, 1), pedidoitem.st_parcelamento.ToString, pedidoitem.nr_parcelas, txt_dt_primeiro_pagto_forn.Text, ldtaux)
                    End If

                    txt_dt_primeiro_pagto_forn.Text = DateTime.Parse(txt_dt_primeiro_pagto_forn.Text).ToString("dd/MM/yyyy") 'Fran 05/08/2015 i 
                Else

                    txt_total_parcelas_forn.Text = String.Empty
                    txt_dt_primeiro_pagto_forn.Text = String.Empty

                End If

                If ViewState.Item("pedidoindireto").ToString.Equals("N") Then 'se nao é pedido indireto
                    'Se for pedido indireto não tem o grid de desconto ao produtor
                    If dspedidoprodutor.Tables(0).Rows.Count = 0 Then 'se nao tem linhas informadas em desconto produtor, sugere 
                        'txt_valor_nota_fiscal_prod.Text = pedidoitem.nr_valor_total
                        If CInt(pedidoitem.nr_parcelas) > 1 Then 'se é Parcelado
                            txt_total_parcelas_prod.Text = pedidoitem.nr_parcelas
                        Else
                            txt_total_parcelas_prod.Text = 1
                        End If

                        pedido.calcularDataDescontoProdutor(pdt_emissaonf, pedidoitem.nr_parcelas, txt_dt_primeiro_pagto_prod.Text, ldtaux)

                        'txt_dt_primeiro_pagto_prod.Text = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("01/", Format(DateTime.Parse(Now), "MM/yyyy").ToString)))))

                        txt_dt_primeiro_pagto_prod.Text = DateTime.Parse(txt_dt_primeiro_pagto_prod.Text).ToString("dd/MM/yyyy") 'Fran 05/08/2015 i 

                    Else
                        'txt_nota_fiscal_prod.Text = String.Empty
                        'txt_serie_forn.Text = String.Empty
                        'txt_valor_nota_fiscal_prod.Text = String.Empty
                        txt_total_parcelas_prod.Text = String.Empty
                        txt_dt_primeiro_pagto_prod.Text = String.Empty

                    End If
                End If
            Else
                txt_total_parcelas_forn.Text = String.Empty
                txt_dt_primeiro_pagto_forn.Text = String.Empty
                txt_total_parcelas_prod.Text = String.Empty
                txt_dt_primeiro_pagto_prod.Text = String.Empty

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadComboNotas()

        Try
            If ViewState.Item("id_central_pedido") Is Nothing Then
                ViewState.Item("id_central_pedido") = 0
            End If

            cbo_nota_fiscal_forn.Items.Clear()
            cbo_nota_fiscal_prod.Items.Clear()

            If CLng(ViewState.Item("id_central_pedido")) > 0 Then

                cbo_nota_fiscal_forn.Visible = True
                rf_cbo_nota_fiscal_forn.Visible = True

                Dim notaspedido As New PedidoNotas
                notaspedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido").ToString)
                Dim dsnotas As DataSet = notaspedido.getCentralPedidoNotasCombo

                If dsnotas.Tables(0).Rows.Count > 0 Then

                    cbo_nota_fiscal_forn.DataSource = dsnotas
                    cbo_nota_fiscal_forn.DataTextField = "ds_nota"
                    cbo_nota_fiscal_forn.DataValueField = "id_central_pedido_notas"
                    cbo_nota_fiscal_forn.DataBind()
                    cbo_nota_fiscal_forn.Items.Insert(0, New ListItem("[Selecione]", 0))
                    'cbo_nota_fiscal_forn.SelectedValue = 0

                    If ViewState.Item("pedidoindireto").ToString.Equals("N") Then 'se nao é pedido indireto
                        cbo_nota_fiscal_prod.Visible = True
                        rf_cbo_nota_fiscal_prod.Visible = True

                        cbo_nota_fiscal_prod.DataSource = dsnotas
                        cbo_nota_fiscal_prod.DataTextField = "ds_nota"
                        cbo_nota_fiscal_prod.DataValueField = "id_central_pedido_notas"
                        cbo_nota_fiscal_prod.DataBind()
                        cbo_nota_fiscal_prod.Items.Insert(0, New ListItem("[Selecione]", 0))
                        ' cbo_nota_fiscal_prod.SelectedValue = 0
                    End If

                Else
                    cbo_nota_fiscal_forn.Items.Insert(0, New ListItem("[Inclua Nota Fiscal]", 0))
                    cbo_nota_fiscal_forn.SelectedValue = 0
                    If ViewState.Item("pedidoindireto").ToString.Equals("N") Then 'se nao é pedido indireto
                        cbo_nota_fiscal_prod.Visible = True
                        rf_cbo_nota_fiscal_prod.Visible = True

                        cbo_nota_fiscal_prod.Items.Insert(0, New ListItem("[Inclua Nota Fiscal]", 0))
                        cbo_nota_fiscal_prod.SelectedValue = 0
                    End If

                End If


            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadParcelasProdutorFornecedorPedidoReaberto()

    '    Try
    '        If ViewState.Item("id_central_pedido_item") Is Nothing Then
    '            ViewState.Item("id_central_pedido_item") = 0
    '        End If

    '        If CLng(ViewState.Item("id_central_pedido_item")) > 0 Then

    '            txt_nota_fiscal_forn.Visible = False
    '            rf_nr_nota_forn.Visible = False
    '            cbo_nota_fiscal_forn.Visible = True
    '            rf_cbo_nota_fiscal_forn.Visible = True
    '            txt_serie_forn.Enabled = False
    '            txt_dt_emissao_nota.Enabled = False 'fran 05/2016
    '            txt_valor_nota_fiscal_forn.Enabled = False

    '            Dim nrnotaforn As New PedidoPagtoFornecedor
    '            nrnotaforn.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item").ToString)
    '            cbo_nota_fiscal_forn.DataSource = nrnotaforn.getCentralPedidoPagtoFornecedorNotas()
    '            cbo_nota_fiscal_forn.DataTextField = "nr_nota_fiscal"
    '            cbo_nota_fiscal_forn.DataValueField = "ds_serie_valor"
    '            cbo_nota_fiscal_forn.DataBind()
    '            cbo_nota_fiscal_forn.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

    '            If ViewState.Item("pedidoindireto").ToString.Equals("N") Then 'se nao é pedido indireto

    '                Dim nrnotaprod As New PedidoDescontoProdutor
    '                nrnotaprod.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item").ToString)
    '                cbo_nota_fiscal_prod.DataSource = nrnotaprod.getCentralPedidoDescontoProdutorNotas()
    '                cbo_nota_fiscal_prod.DataTextField = "nr_nota_fiscal"
    '                'cbo_nota_fiscal_prod.DataValueField = "nr_valor_nota_fiscal"
    '                cbo_nota_fiscal_prod.DataValueField = "ds_nr_nota_valor"
    '                cbo_nota_fiscal_prod.DataBind()
    '                cbo_nota_fiscal_prod.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

    '                cbo_nota_fiscal_prod.Enabled = True
    '                btn_incluir_parcelas_produtor.Enabled = True
    '                txt_nota_fiscal_prod.Visible = False
    '                rf_nr_nota_prod.Visible = False
    '                cbo_nota_fiscal_prod.Visible = True
    '                rf_cbo_nota_fiscal_prod.Visible = True
    '                txt_valor_nota_fiscal_prod.Enabled = False
    '            End If
    '            btn_incluir_parcelas_fornecedor.Enabled = True
    '            cbo_nota_fiscal_forn.Enabled = True
    '            txt_nota_fiscal_forn.Text = String.Empty
    '            txt_serie_forn.Text = String.Empty
    '            txt_dt_emissao_nota.Text = String.Empty 'fran 05/2016
    '            txt_valor_nota_fiscal_forn.Text = String.Empty
    '            txt_total_parcelas_forn.Text = String.Empty
    '            txt_dt_primeiro_pagto_forn.Text = String.Empty

    '        Else
    '            txt_nota_fiscal_forn.Visible = False
    '            rf_nr_nota_forn.Visible = False
    '            cbo_nota_fiscal_forn.Visible = True
    '            rf_cbo_nota_fiscal_forn.Visible = True
    '            txt_serie_forn.Enabled = False
    '            txt_dt_emissao_nota.Enabled = False 'fran 05/2016
    '            rf_dtemissao.Visible = False 'fran 05/2016
    '            txt_valor_nota_fiscal_forn.Enabled = False
    '            txt_nota_fiscal_prod.Visible = False
    '            rf_nr_nota_prod.Visible = False
    '            cbo_nota_fiscal_prod.Visible = True
    '            rf_cbo_nota_fiscal_prod.Visible = True
    '            txt_valor_nota_fiscal_prod.Enabled = False

    '            txt_nota_fiscal_forn.Text = String.Empty
    '            txt_serie_forn.Text = String.Empty
    '            txt_valor_nota_fiscal_forn.Text = String.Empty
    '            txt_dt_emissao_nota.Text = String.Empty 'fran 05/2016
    '            txt_total_parcelas_forn.Text = String.Empty
    '            txt_dt_primeiro_pagto_forn.Text = String.Empty
    '            cbo_nota_fiscal_forn.Enabled = False
    '            cbo_nota_fiscal_prod.Enabled = False
    '            btn_incluir_parcelas_fornecedor.Enabled = False
    '            btn_incluir_parcelas_produtor.Enabled = False

    '        End If
    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub
    Private Sub EnviarEmailTecnicoAprovacao()
        Try
            If Page.IsValid = True Then
                Try

                    Dim notificacao As New Notificacao
                    'Dim lAssunto As String = String.Concat("Aprovação de Cotações Central de Compras para Propriedade ", , " - ", lbl_nm_propriedade.Text.Trim & ".")
                    Dim lCorpo As String

                    lCorpo = "Existem cotações realizadas pela Central de Compras do Produtor "
                    lCorpo = lCorpo & "'" & lbl_nm_produtor.Text.Trim & "' para a Propriedade "
                    'lCorpo = lCorpo & "'" & String.Concat(txt_id_propriedade.Text.Trim, " - ", lbl_nm_propriedade.Text.Trim) & "', "
                    lCorpo = lCorpo & " pendentes para serem aprovadas por você, técnico responsável."

                    ' Parametro 7 - Central Cotacao 1.o Nível Gestor (enviar aos Tecnicos) 
                    'If notificacao.enviaMensagemEmail(7, lAssunto, lCorpo, MailPriority.High) = True Then

                    'messageControl.Alert("A mensagem de solicitação de aprovação para o Técnico Responsável pela propriedade foi enviada aos destinatários com sucesso!")
                    'Else

                    'messageControl.Alert("A mensagem de solicitação de aprovação para o Técnico Responsável pela propriedade não pode ser enviada. Verifique se há destinatários cadastrados para este tipo de notificação.")
                    'img_notificacao.Visible = True
                    'lk_email_produtor.Visible = True

                    'End If


                Catch ex As Exception
                    messageControl.Alert(ex.Message)
                End Try


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Function VerificarCotacao() As Boolean

    '    Try

    '        Dim cotacaoitem As New CotacaoItem()
    '        Dim cotacaofornc As New CotacaoFornecedor()
    '        Dim dscotitem As DataSet = cotacaoitem.getCotacaoItensByFilters
    '        Dim dscotforn As DataSet
    '        Dim row As DataRow
    '        Dim rowfornec As DataRow
    '        Dim lmsg As String
    '        Dim isvalid As Boolean = True

    '        For Each row In dscotitem.Tables(0).Rows
    '            If row.Item("st_ver_mercado") = "N" Then
    '                If CDbl(row.Item("nr_quantidade")) = 0 Then
    '                    isvalid = False
    '                    lmsg = "Há itens da cotação cujo cadastro está incompleto!"
    '                    Exit For
    '                End If
    '                cotacaofornc.id_central_cotacao_item = Convert.ToInt32(row.Item("id_central_cotacao_item"))
    '                dscotforn = cotacaofornc.getCotacaoFornecedorByFilters()
    '                For Each rowfornec In dscotforn.Tables(0).Rows
    '                    If Not CDbl(rowfornec.Item("nr_valor_unitario")) > 0 Then
    '                        isvalid = False
    '                        lmsg = "Há cotações para o item " + row.Item("nm_item").ToString + " cujo cadastro está incompleto!"
    '                        Exit For
    '                    End If
    '                Next
    '                If isvalid = False Then
    '                    Exit For
    '                End If

    '                cotacaofornc.st_selecionado = "S"
    '                cotacaofornc.st_ver_mercado = "N"
    '                If cotacaofornc.getCotacaoFornecedorByFilters.Tables(0).Rows.Count = 0 Then
    '                    isvalid = False
    '                    lmsg = "Não há cotação selecionada para o item " + row.Item("nm_item").ToString + "."
    '                    Exit For
    '                End If
    '            End If
    '        Next

    '        If isvalid = False Then
    '            VerificarCotacao = False
    '            messageControl.Alert(lmsg)
    '        Else
    '            VerificarCotacao = True
    '        End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try


    'End Function

    'Protected Sub lk_notificar_aprovadores_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        EnviarEmailTecnicoAprovacao()
    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try
    'End Sub
    Protected Sub lk_gerar_pedido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_gerar_pedido.Click
        If Page.IsValid Then
            Try
                If CInt(ViewState.Item("id_situacao_pedido")) = 1 OrElse CInt(ViewState.Item("id_situacao_pedido")) = 6 OrElse CInt(ViewState.Item("id_situacao_pedido")) = 8 Then

                    Dim pedido As New Pedido
                    Dim lmsg As String = String.Empty

                    pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
                    pedido.id_modificador = Session("id_login")


                    Dim lnrtotalpedidominimo As Decimal = CDec(lbl_total_pedido.Text) - (CDec(lbl_total_pedido.Text) * 0.03)
                    Dim lnrtotalpedidomaximo As Decimal = CDec(lbl_total_pedido.Text) + (CDec(lbl_total_pedido.Text) * 0.1)
                    Dim lnrtotalnotaspedido As Decimal = pedido.getCentralPedidoValorTotalNotas
                    lbl_total_notas.Text = FormatCurrency(lnrtotalnotaspedido, 2).ToString

                    'total nota do pedido for MAIOR que o valor do pedido - 3% ,finaliza o pedido em definitivo
                    If lnrtotalnotaspedido >= lnrtotalpedidominimo Then
                        pedido.id_situacao_pedido = 3
                        lmsg = "Pedido finalizado com sucesso!"
                    Else
                        pedido.id_situacao_pedido = 8
                        lmsg = "Pedido finalizado parcialmente com sucesso!"

                    End If


                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'processo
                    usuariolog.id_menu_item = 97
                    usuariolog.ds_nm_processo = "Pedido - Finalizar Pedido"
                    usuariolog.id_nr_processo = pedido.id_central_pedido
                    usuariolog.nm_nr_processo = pedido.id_central_pedido

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    'se finalizado parcial e esta clicando bnotao finalizar , nao verifica valores fecha opedido definitivamente
                    If CInt(ViewState.Item("id_situacao_pedido")) = 8 Then
                        pedido.id_situacao_pedido = 3
                        lmsg = "Pedido finalizado com sucesso!"
                        pedido.updateCentralPedidoSituacao() 'se pedido veio do banco como finalizado parcial, ja tem as parcelas de desconto salvas em lancamento
                    Else
                        If pedido.finalizarPedido() = True Then
                            messageControl.Alert(lmsg)
                        Else
                            messageControl.Alert("Ocorreram problemas na finalização do Pedido. Contate o administrador do sistema.")
                        End If
                    End If
                End If
                loadData()
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Protected Sub btn_adicionar_pagto_fornecedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar_pagto_fornecedor.Click

        ViewState.Item("incluirlinha") = "S"
        Dim pagto As New PedidoPagtoFornecedor
        pagto.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
        pagto.id_situacao = 1 'chamado 860 item 7 fran 19/10/2010
        Dim dspagto As DataSet = pagto.getPedidoPagtoFornecedorByFilters()
        Dim dr As DataRow = dspagto.Tables(0).NewRow()
        dspagto.Tables(0).Rows.InsertAt(dr, 0)
        ViewState.Item("incluirlinhapagto") = "S"
        gridPagtoForn.Visible = True
        gridPagtoForn.DataSource = Helper.getDataView(dspagto.Tables(0), "nr_nota_fiscal,nr_parcela")
        gridPagtoForn.EditIndex = 0
        gridPagtoForn.DataBind()
        ViewState.Item("incluirlinha") = Nothing
        ViewState.Item("label_nr_nota_forn") = Nothing 'fase 3 fran dez/2014

    End Sub
    Protected Sub gridPagtoForn_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridPagtoForn.PageIndexChanging
        gridPagtoForn.PageIndex = e.NewPageIndex
        loadData()

    End Sub
    Protected Sub gridPagtoForn_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridPagtoForn.RowCancelingEdit
        Try

            gridPagtoForn.EditIndex = -1
            ViewState.Item("incluirlinhapagto") = "N"
            ViewState.Item("incluirlinhapagto") = Nothing
            loadGridPagtoFornecedor()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridPagtoForn_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridPagtoForn.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "anexar"
                If lbl_interrupcao.Text = "Sim" Then
                    Response.Redirect("frm_central_pedido_anexos.aspx?id=" + e.CommandArgument.ToString() + "&tipo=intpf&tela=frm_central_pedido.aspx?id_central_pedido=" + ViewState.Item("id_central_pedido").ToString)
                Else
                    Response.Redirect("frm_central_pedido_anexos.aspx?id=" + e.CommandArgument.ToString() + "&tipo=pedpf&tela=frm_central_pedido.aspx?id_central_pedido=" + ViewState.Item("id_central_pedido").ToString)

                End If
            Case "delete"
                deletePedidoPagtoFornecedor(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Protected Sub gridPagtoForn_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridPagtoForn.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                'se esta reabrindo pedido e incluindo nova linha de desconto ao produtor
                'fran fase 3 dez/2014 i
                '' If ViewState.Item("ReabrirPedido") = "S" Then
                Dim cbo_nr_nota As DropDownList = CType(e.Row.FindControl("cbo_nr_nota"), DropDownList)
                'Dim txt_nr_nota_fiscal As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_nota_fiscal"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                'Dim txt_nr_serie As TextBox = CType(e.Row.FindControl("txt_nr_serie"), TextBox)
                Dim rf_cbo_nota_fiscal As RequiredFieldValidator = CType(e.Row.FindControl("rf_cbo_nota_fiscal"), RequiredFieldValidator)
                'Dim rqf_nr_nota As RequiredFieldValidator = CType(e.Row.FindControl("rqf_nr_nota"), RequiredFieldValidator)

                rf_cbo_nota_fiscal.Visible = True
                'rqf_nr_nota.Visible = False
                'txt_nr_nota_fiscal.Visible = False
                cbo_nr_nota.Visible = True

                If ViewState.Item("incluirlinhapagto") = "S" Then
                    ViewState.Item("label_nr_nota_forn") = "0"
                End If

                If Not (ViewState.Item("label_nr_nota_forn") Is Nothing) Then
                    Dim nrnotapedido As New PedidoNotas
                    nrnotapedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido").ToString)
                    cbo_nr_nota.DataSource = nrnotapedido.getCentralPedidoNotasCombo()
                    cbo_nr_nota.DataTextField = "nr_nota_fiscal"
                    cbo_nr_nota.DataValueField = "id_central_pedido_notas"
                    cbo_nr_nota.DataBind()

                    If (ViewState.Item("label_nr_nota_forn").ToString.Equals("0")) Then
                        cbo_nr_nota.Items.Insert(0, New ListItem("[Selecione]", "0"))
                        ViewState.Item("label_nr_nota_forn") = "SEM_VALOR"
                    Else
                        cbo_nr_nota.SelectedValue = ViewState.Item("label_nr_nota_forn").Trim.ToString
                        ViewState.Item("label_nr_nota_forn") = Nothing
                    End If

                End If

                '' End If
                'fran fase 3 dez/2014 f

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If


    End Sub

    Protected Sub gridPagtoForn_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridPagtoForn.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            Dim lbl_dt_emissao As Label = CType(e.Row.FindControl("lbl_dt_emissao"), Label)

            Dim cbo_nr_nota As DropDownList = CType(e.Row.FindControl("cbo_nr_nota"), DropDownList)
            Dim rf_cbo_nota_fiscal As RequiredFieldValidator = CType(e.Row.FindControl("rf_cbo_nota_fiscal"), RequiredFieldValidator)
            Dim chk_st_tipo_pagto As Anthem.CheckBox = CType(e.Row.FindControl("chk_st_tipo_pagto"), Anthem.CheckBox)
            Dim lbl_st_tipo_pagto As Label = CType(e.Row.FindControl("lbl_st_tipo_pagto"), Label)

            rf_cbo_nota_fiscal.Visible = True

            cbo_nr_nota.Visible = True

            If ViewState.Item("label_nr_nota_forn") = "SEM_VALOR" Then
                'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                If Not (cbo_nr_nota Is Nothing) Then
                    cbo_nr_nota.Items.Insert(0, New ListItem("[Selecione]", "0"))
                End If
                ViewState.Item("label_nr_nota_forn") = Nothing
            End If

            Dim dt_pagto As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(e.Row.FindControl("txt_dt_pagto"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)

            If Not dt_pagto.Text.Equals(String.Empty) Then
                dt_pagto.Text = DateTime.Parse(dt_pagto.Text.Trim).ToString("dd/MM/yyyy")
            End If
            If Not lbl_dt_emissao.Text.Equals(String.Empty) Then
                lbl_dt_emissao.Text = DateTime.Parse(lbl_dt_emissao.Text.Trim).ToString("dd/MM/yyyy")
            End If

            If lbl_st_tipo_pagto.Text = "P" Then
                chk_st_tipo_pagto.Checked = True
            Else
                chk_st_tipo_pagto.Checked = False

            End If

        Else
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim img_st_tipo_pagto As Anthem.Image = CType(e.Row.FindControl("img_st_tipo_pagto"), Anthem.Image)
                Dim lbl_st_tipo_pagto As Label = CType(e.Row.FindControl("lbl_st_tipo_pagto"), Label)
                Dim lbl_dt_acerto As Label = CType(e.Row.FindControl("lbl_dt_acerto"), Label)
                Dim lbl_acerto As Anthem.Label = CType(e.Row.FindControl("lbl_acerto"), Anthem.Label)
                Dim bacertoefetivado As Boolean = False

                'fran set/2014 fase 3 i
                'se nao tem nr nota veio de cotacao e acessa pedido pela primeira vez
                Dim lbl_nr_nota_fiscal As Label = CType(e.Row.FindControl("lbl_nr_nota_fiscal"), Label)
                If lbl_nr_nota_fiscal.Text.Equals(String.Empty) Then
                    ViewState.Item("PagtoForn1avez") = "S"
                Else
                    ViewState.Item("PagtoForn1avez") = "N"
                End If
                'fran set/2014 fase 3 f

                Dim dt_pagto As Label = CType(e.Row.FindControl("lbl_dt_pagto"), Label)
                If Not dt_pagto.Text.Equals(String.Empty) Then
                    dt_pagto.Text = DateTime.Parse(dt_pagto.Text.Trim).ToString("dd/MM/yyyy")
                End If
                Dim lbl_dt_emissao As Label = CType(e.Row.FindControl("lbl_dt_emissao"), Label)
                If Not lbl_dt_emissao.Text.Equals(String.Empty) Then
                    lbl_dt_emissao.Text = DateTime.Parse(lbl_dt_emissao.Text.Trim).ToString("dd/MM/yyyy")
                End If

                Dim btn_editar As Anthem.ImageButton = CType(e.Row.FindControl("btn_editar"), Anthem.ImageButton)
                Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("btn_delete"), Anthem.ImageButton)
                Dim bexportado As Boolean = False
                Dim lbl_st_exportacao As Label = CType(e.Row.FindControl("lbl_st_exportacao"), Label)
                Dim img_st_calculado As Anthem.Image = CType(e.Row.FindControl("img_st_exportado"), Anthem.Image)
                Dim btn_anexar As Anthem.ImageButton = CType(e.Row.FindControl("btn_anexar"), Anthem.ImageButton)

                If lbl_st_exportacao.Text.Trim.Equals("S") Then
                    img_st_calculado.ImageUrl = "~/img/ico_chk_true.gif"
                    img_st_calculado.ToolTip = "Exportação já realizada."
                    bexportado = True 'fran 12/2014 fase 3
                    btn_anexar.Visible = False
                End If
                'se ja tem exportacao nao pode alterar 
                'If ViewState.Item("ReabrirPedido") = "S" Then
                If lbl_st_tipo_pagto.Text = "P" Then
                    img_st_tipo_pagto.ImageUrl = "~/img/ico_chk_true.gif"
                    If lbl_dt_acerto.Text.Equals(String.Empty) Then
                        lbl_acerto.Text = String.Empty
                        lbl_acerto.Visible = False
                        bacertoefetivado = False
                    Else
                        lbl_acerto.Visible = True
                        lbl_acerto.Text = String.Concat("Acerto em", DateTime.Parse(lbl_dt_acerto.Text).ToString("dd/MM/yyyy"))
                        bacertoefetivado = True
                    End If
                    btn_anexar.Visible = True

                Else
                    img_st_tipo_pagto.ImageUrl = "~/img/ico_chk_false.gif"
                    btn_anexar.Visible = False

                End If

                If bexportado = True OrElse bacertoefetivado = True Then
                    btn_editar.Enabled = False
                    btn_delete.Enabled = False
                    btn_editar.ImageUrl = "~/img/icone_editar_grid_desabilitado.gif"
                    btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                End If
                'End If
                'fran fase 3 8/2014 f

            End If
        End If

    End Sub

    Protected Sub gridPagtoForn_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridPagtoForn.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub gridPagtoForn_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridPagtoForn.RowEditing
        Try
            If ViewState.Item("incluirlinha") = "S" And e.NewEditIndex = 0 Then
                ViewState.Item("incluirlinha") = "S"
                loadGridPagtoFornecedor()
            Else
                Dim lbl_id_central_pedido_notas As Label = CType(gridPagtoForn.Rows(e.NewEditIndex).FindControl("lbl_id_central_pedido_notas"), Label)
                ViewState.Item("label_nr_nota_forn") = Trim(lbl_id_central_pedido_notas.Text) 'fase 3 fran dez/2014

                gridPagtoForn.EditIndex = e.NewEditIndex
                loadGridPagtoFornecedor()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridPagtoForn_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridPagtoForn.RowUpdating
        Dim row As GridViewRow = gridPagtoForn.Rows(e.RowIndex)
        Try
            If Page.IsValid Then


                If (Not (row) Is Nothing) Then

                    Dim pagto As New PedidoPagtoFornecedor

                    Dim lbl_id_central_pedido_item As Label = CType(row.FindControl("lbl_id_central_pedido_item"), Label)
                    Dim lbl_id_central_pedido_pagto_fornecedor As Label = CType(row.FindControl("lbl_id_central_pedido_pagto_fornecedor"), Label)
                    Dim lbl_id_central_pedido_notas As Label = CType(row.FindControl("lbl_id_central_pedido_notas"), Label)
                    Dim nr_parcela As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_parcela"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                    'Dim nr_valor_nota_fiscal As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_nota_fiscal"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    'Dim nr_nota_fiscal As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_nota_fiscal"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                    'Dim nr_serie As Anthem.TextBox = CType(row.FindControl("txt_nr_serie"), Anthem.TextBox)
                    Dim nr_valor_parcela As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_parcela"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim dt_pagto As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_pagto"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
                    'Dim dt_emissao As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_emissao"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
                    Dim cbo_nr_nota As DropDownList = CType(row.FindControl("cbo_nr_nota"), DropDownList)
                    Dim chk_st_tipo_pagto As Anthem.CheckBox = CType(row.FindControl("chk_st_tipo_pagto"), Anthem.CheckBox)

                    'pagto.nr_serie_nota_fiscal = nr_serie.Text
                    'pagto.dt_emissao_nota_fiscal = dt_emissao.Text 'fran 05/2016
                    'If ViewState.Item("ReabrirPedido") = "S" Then
                    '    pagto.nr_nota_fiscal = cbo_nr_nota.SelectedItem.Text
                    'Else
                    '    pagto.nr_nota_fiscal = nr_nota_fiscal.Text
                    'End If
                    'If Not nr_valor_nota_fiscal.Text.ToString.Equals(String.Empty) Then
                    '    pagto.nr_valor_nota_fiscal = Convert.ToDecimal(nr_valor_nota_fiscal.Text)
                    'End If

                    pagto.id_central_pedido_notas = cbo_nr_nota.SelectedValue

                    pagto.nr_parcela = nr_parcela.Text
                    pagto.dt_pagto = dt_pagto.Text
                    If Not nr_valor_parcela.Text.ToString.Equals(String.Empty) Then
                        pagto.nr_valor_parcela = Convert.ToDecimal(nr_valor_parcela.Text)
                    End If

                    pagto.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item"))
                    pagto.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
                    If chk_st_tipo_pagto.Checked = True Then
                        pagto.st_tipo_pagto = "P" 'produtor
                        'Else
                        'pagto.st_tipo_pagto = "E" 'exportacao (calculo)
                    End If

                    'fran 14/02/2011 chamado 1170 i só deixa atualizar ou inserir se algum campo for diferente do banco
                    If pagto.getPedidoPagtoFornecedorByFilters.Tables(0).Rows.Count = 0 Then
                        pagto.id_modificador = Session("id_login")

                        'fran 14/02/2011 chamado 1170 f
                        'Se é um novo item
                        If Not ViewState.Item("incluirlinhapagto") Is Nothing Then
                            If ViewState.Item("incluirlinhapagto") = "S" Then
                                pagto.insertPedidoCentralPagtoFornecedor()
                                ViewState.Item("incluirlinhapagto") = Nothing
                            Else
                                pagto.id_central_pedido_pagto_fornecedor = Convert.ToInt32(lbl_id_central_pedido_pagto_fornecedor.Text)
                                pagto.updatePedidoPagtoFornecedor()
                            End If
                        Else
                            pagto.id_central_pedido_pagto_fornecedor = Convert.ToInt32(lbl_id_central_pedido_pagto_fornecedor.Text)
                            pagto.updatePedidoPagtoFornecedor()
                        End If
                        'fran 14/02/2011 chamado 1170 i
                    Else
                        If Not ViewState.Item("incluirlinhapagto") Is Nothing Then
                            If ViewState.Item("incluirlinhapagto") = "S" Then
                                ViewState.Item("incluirlinhapagto") = Nothing
                            End If
                        End If
                    End If
                    'fran 14/02/2011 chamado 1170 f

                    gridPagtoForn.EditIndex = -1

                    loadGridPagtoFornecedor()

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub deletePedidoPagtoFornecedor(ByVal id_central_pedido_pagto_fornecedor As Integer)
        If Page.IsValid Then


            Try
                'Deleta a cotacao fornecedor
                Dim pagto As New PedidoPagtoFornecedor

                pagto.id_central_pedido_pagto_fornecedor = id_central_pedido_pagto_fornecedor
                pagto.deletePedidoPagtoFornecedor()
                messageControl.Alert("Registro excluído com sucesso!")
                loadGridPagtoFornecedor()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Private Sub deletePedidoObservacao(ByVal id_central_pedido_observacao As Integer)
        If Page.IsValid Then


            Try
                'Deleta a cotacao fornecedor
                Dim observacao As New PedidoObservacao

                observacao.id_central_pedido_observacao = id_central_pedido_observacao
                observacao.deletePedidoObservacao()
                messageControl.Alert("Registro excluído com sucesso!")
                loadGridObservacao()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Private Sub deletePedidoDescontoProd(ByVal id_central_pedido_desconto_produtor As Integer)
        If Page.IsValid Then


            Try
                'Deleta a cotacao fornecedor
                Dim desconto As New PedidoDescontoProdutor(id_central_pedido_desconto_produtor)
                'Dim maissolidos As New Poupanca
                'Dim lnrmssaldodisponivel As Decimal

                'If ViewState.Item("pedidoindireto").ToString.Equals("N") Then
                '    If ViewState.Item("maissolidospremiado") = True Then
                '        'se o desconto ao produtor deletado tem mais solidos
                '        If desconto.st_mais_solidos = "S" Then
                '            If CInt(ViewState.Item("id_propriedade_titular")) > 0 Then
                '                maissolidos.id_propriedade_titular = ViewState.Item("id_propriedade_titular")
                '                maissolidos.id_pessoa = 0
                '            Else
                '                maissolidos.id_pessoa = Convert.ToInt32(ViewState.Item("id_produtor"))
                '                maissolidos.id_propriedade_titular = 0
                '            End If
                '            maissolidos.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
                '            maissolidos.dt_referencia = String.Concat("01", Right(DateTime.Parse(desconto.dt_pagto).ToString("dd/MM/yyyy"), 8))
                '            maissolidos.nr_valor_central = -desconto.nr_mais_solidos_valor_utilizado
                '            maissolidos.id_modificador = Session("id_login")

                '            maissolidos.updateMaisSolidosPremio()
                '            'atualiza saldo disponivel
                '            lnrmssaldodisponivel = maissolidos.getMaisSolidosProdutorSaldoDisponivel
                '            lbl_ms_valor_disponivel.Text = FormatCurrency(lnrmssaldodisponivel, 2)
                '            ViewState.Item("maissolidossaldodisponivel") = lnrmssaldodisponivel


                '        End If
                '    End If

                'End If

                desconto.id_central_pedido_desconto_produtor = id_central_pedido_desconto_produtor
                desconto.deletePedidoDescontoProdutor()
                messageControl.Alert("Registro excluído com sucesso!")
                loadGridDescontoProdutor()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    'fran chamado 816 - 14/05/2010
    'Protected Sub lk_email_parceiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email_parceiro.Click
    '    Dim lassunto As String
    '    Dim lcorpo As String
    '    Dim arqTemp As StreamReader
    '    Dim lcaminhoservidor As String = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString()
    '    Dim propriedade As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade").ToString))
    '    Dim produtor As New Pessoa(Convert.ToInt32(ViewState.Item("id_produtor").ToString))
    '    Dim fornecedor As New Pessoa(Convert.ToInt32(ViewState.Item("id_fornecedor").ToString))
    '    Dim lemail_parceiro As String

    '    lemail_parceiro = fornecedor.ds_email
    '    If lemail_parceiro.Equals(String.Empty) Then
    '        If Not fornecedor.ds_email2 Is Nothing Then
    '            lemail_parceiro = fornecedor.ds_email2
    '        Else
    '            lemail_parceiro = String.Empty

    '        End If
    '        'lemail_parceiro = "franoliveira@hotmail.com"
    '    End If
    '    If Not lemail_parceiro.Equals(String.Empty) Then
    '        lassunto = String.Concat("DANONE - Pedido de Compra ", "Nr ", lbl_id_central_pedido.Text)
    '        arqTemp = New StreamReader(lcaminhoservidor & "\email_fornecedor.HTML", Encoding.UTF7)
    '        lcorpo = ""
    '        Do While Not arqTemp.EndOfStream
    '            lcorpo = lcorpo & arqTemp.ReadLine
    '        Loop

    '        lcorpo = Replace(lcorpo, "$dt_pedido", DateTime.Parse(lbl_dt_pedido.Text.ToString).ToString("dd/MM/yyyy"))
    '        lcorpo = Replace(lcorpo, "$id_pedido", ViewState.Item("id_central_pedido").ToString)
    '        lcorpo = Replace(lcorpo, "$nr_contrato", fornecedor.nr_contrato.ToString)
    '        If fornecedor.nm_abreviado.Equals(String.Empty) Then
    '            lcorpo = Replace(lcorpo, "$ds_fornecedor", String.Concat(fornecedor.cd_pessoa.ToString, " - ", fornecedor.nm_pessoa))
    '        Else
    '            lcorpo = Replace(lcorpo, "$ds_fornecedor", String.Concat(fornecedor.cd_pessoa.ToString, " - ", fornecedor.nm_abreviado))
    '        End If
    '        lcorpo = Replace(lcorpo, "$end_fornecedor", String.Concat(fornecedor.ds_endereco, " ", fornecedor.nr_endereco))
    '        lcorpo = Replace(lcorpo, "$bairro_fornecedor", fornecedor.ds_bairro)
    '        lcorpo = Replace(lcorpo, "$cidade_fornecedor", fornecedor.nm_cidade)
    '        lcorpo = Replace(lcorpo, "$uf_fornecedor", fornecedor.cd_uf)
    '        lcorpo = Replace(lcorpo, "$cepfornecedor", fornecedor.cd_cep)
    '        If fornecedor.st_categoria = "F" Then
    '            lcorpo = Replace(lcorpo, "$cnpjfornecedor", fornecedor.cd_cpf)
    '        Else
    '            lcorpo = Replace(lcorpo, "$cnpjfornecedor", fornecedor.cd_cnpj)
    '        End If
    '        lcorpo = Replace(lcorpo, "$inscrestadualfornecedor", fornecedor.cd_inscricao_estadual)
    '        lcorpo = Replace(lcorpo, "$ds_contato", fornecedor.ds_contato)
    '        lcorpo = Replace(lcorpo, "$email", fornecedor.ds_email)
    '        lcorpo = Replace(lcorpo, "$fone1", fornecedor.ds_telefone_1)
    '        lcorpo = Replace(lcorpo, "$fone2", fornecedor.ds_telefone_2)

    '        lcorpo = Replace(lcorpo, "$ds_produtor", String.Concat(produtor.nm_pessoa.ToString + " - ", produtor.cd_pessoa + " - ", propriedade.id_propriedade.ToString + "-", lbl_up.Text.ToString))
    '        lcorpo = Replace(lcorpo, "$end_produtor", String.Concat(produtor.ds_endereco, " ", produtor.nr_endereco))
    '        lcorpo = Replace(lcorpo, "$bairro_produtor", produtor.ds_bairro)
    '        lcorpo = Replace(lcorpo, "$cidade_produtor", produtor.nm_cidade)
    '        lcorpo = Replace(lcorpo, "$uf_produtor", produtor.cd_uf)
    '        lcorpo = Replace(lcorpo, "$cepprodutor", produtor.cd_cep)
    '        If fornecedor.st_categoria = "F" Then
    '            lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cpf)
    '        Else
    '            lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cnpj)
    '        End If
    '        lcorpo = Replace(lcorpo, "$inscrestadualprodutor", produtor.cd_inscricao_estadual)
    '        lcorpo = Replace(lcorpo, "$ds_contato", produtor.ds_contato)
    '        lcorpo = Replace(lcorpo, "$email", produtor.ds_email)
    '        lcorpo = Replace(lcorpo, "$fone1", produtor.ds_telefone_1)
    '        lcorpo = Replace(lcorpo, "$fone2", produtor.ds_telefone_2)


    '        lcorpo = Replace(lcorpo, "$nm_produtor", produtor.nm_pessoa)
    '        lcorpo = Replace(lcorpo, "$end_propriedade", String.Concat(propriedade.ds_endereco, " ", propriedade.nr_endereco))
    '        lcorpo = Replace(lcorpo, "$bairro_propriedade", propriedade.ds_bairro)
    '        lcorpo = Replace(lcorpo, "$cidade_propriedade", propriedade.nm_cidade)
    '        lcorpo = Replace(lcorpo, "$uf_propriedade", propriedade.cd_uf)
    '        lcorpo = Replace(lcorpo, "$ceppropriedade", propriedade.cd_cep)
    '        If fornecedor.st_categoria = "F" Then
    '            lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cpf)
    '        Else
    '            lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cnpj)
    '        End If
    '        lcorpo = Replace(lcorpo, "$increstadualprodutor", produtor.cd_inscricao_estadual)
    '        lcorpo = Replace(lcorpo, "$nr_total_pedido", lbl_total_pedido.Text)

    '        Dim pedido As New Pedido
    '        pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
    '        Dim dsgrid As DataSet = pedido.getCentralPedidoEmailParceiro()
    '        Dim row As DataRow
    '        Dim ltable As String = String.Empty
    '        For Each row In dsgrid.Tables(0).Rows
    '            ltable = "<tr><td style=' border-left: gray 1px solid;'>"
    '            ltable = ltable & row.Item("cd_item").ToString & "</td>"
    '            ltable = ltable & "<td style='border-left: gray 1px solid;'> </td>"
    '            ltable = ltable & "<td style='border-left: gray 1px solid;'>" & row.Item("nm_item").ToString & "</td>"
    '            ltable = ltable & "<td style='border-left: gray 1px solid;'>" & row.Item("cd_unidade_medida").ToString & "</td>"
    '            ltable = ltable & "<td style='border-left: gray 1px solid;'>" & row.Item("nr_quantidade_prevista").ToString & "</td>"
    '            ltable = ltable & "<td style='border-left: gray 1px solid;'>R$</td>"
    '            ltable = ltable & "<td style='border-left: gray 1px solid;'>" & Round(CDbl(row.Item("nr_valor_unitario").ToString), 2).ToString & "</td>"
    '            ltable = ltable & "<td style='border-left: gray 1px solid;'>0,00</td>"
    '            ltable = ltable & "<td style='border-left: gray 1px solid;'>0,00</td>"
    '            ltable = ltable & "<td style='border-left: gray 1px solid;'>" & row.Item("nr_perc_icms").ToString & "</td>"
    '            ltable = ltable & "<td style='border-left: gray 1px solid;'>" & row.Item("nr_valor_total_item").ToString & "</td>"
    '            ltable = ltable & "<td style='border-left: gray 1px solid;'>" & Left(row.Item("dt_entrega_prevista").ToString, 10) & "</td></tr>"
    '        Next
    '        lcorpo = Replace(lcorpo, "$dsgrid", ltable.ToString)

    '        Dim notificacao As New Notificacao
    '        arqTemp.Close()
    '        If notificacao.enviaMensagemEmail(lassunto, lcorpo, "recepcao.de.leite-pocos@danone.com", lemail_parceiro, , MailPriority.High, True) = True Then

    '            messageControl.Alert("Email enviado ao parceiro com sucesso!")
    '        Else

    '            messageControl.Alert("Email ao parceiro não foi enviado com sucesso!")

    '        End If
    '    Else
    '        messageControl.Alert("O email não pode ser enviado pois não há nenhum email informado no cadastrado do Parceiro!")
    '    End If

    'End Sub

    Protected Sub lk_email_parceiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email_parceiro.Click
        Dim lassunto As String
        Dim lcorpo As String
        Dim arqTemp As StreamReader
        Dim lcaminhoservidor As String = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString()
        'Dim lcaminhoservidor As String = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()
        Dim propriedade As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade").ToString))
        Dim produtor As New Pessoa(Convert.ToInt32(ViewState.Item("id_produtor").ToString))
        Dim fornecedor As New Pessoa(Convert.ToInt32(ViewState.Item("id_fornecedor").ToString))
        Dim lemail_parceiro As String
        Dim lemail_parceiro2 As String = String.Empty 'fran fase 2 melhorias
        Dim ldatahj As Date = DateTime.Parse(Now).ToString("dd/MM/yyyy")
        Dim lstipofrete As String = String.Empty

        lemail_parceiro = fornecedor.ds_email
        If lemail_parceiro.Equals(String.Empty) Then
            If Not fornecedor.ds_email2 Is Nothing Then
                lemail_parceiro = fornecedor.ds_email2
            Else
                lemail_parceiro = String.Empty
            End If
            'fran fase 2 melhorias i se existe o primeiro email, busca o 2
        Else
            If Not fornecedor.ds_email2 Is Nothing Then 'se nao for nothing, joga o valor no para2
                lemail_parceiro2 = fornecedor.ds_email2
            End If
        End If
        'fran fase 2 melhorias f

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 9 'ENVIO EMAIL
        usuariolog.id_menu_item = 97
        usuariolog.id_nr_processo = lbl_id_central_pedido.Text
        usuariolog.nm_nr_processo = lbl_id_central_pedido.Text
        usuariolog.ds_nm_processo = "Pedidos - E-mail Parceiro"
        usuariolog.insertUsuarioLog()
        'fran 08/12/2020 f

        'lemail_parceiro = "franoliveira@hotmail.com"
        If Not lemail_parceiro.Equals(String.Empty) Then
            lassunto = String.Concat("DANONE - Pedido de Compra ", "Nr ", lbl_id_central_pedido.Text, " - Produtor ", produtor.nm_abreviado)
            arqTemp = New StreamReader(lcaminhoservidor & "\central_pedido_email_fornecedor.HTML", Encoding.UTF7)
            lcorpo = ""
            Do While Not arqTemp.EndOfStream
                lcorpo = lcorpo & arqTemp.ReadLine
            Loop

            lcorpo = Replace(lcorpo, "$nm_estabelecimento", ViewState.Item("nm_estabelecimento").ToString)
            lcorpo = Replace(lcorpo, "$dt_hoje", String.Concat(Format(ldatahj, "dd").ToString, " de ", Format(ldatahj, "MMMM").ToString, " de ", Format(ldatahj, "yyyy").ToString & "."))
            lcorpo = Replace(lcorpo, "$id_pedido", ViewState.Item("id_central_pedido").ToString)
            lcorpo = Replace(lcorpo, "$nm_fornecedor", fornecedor.nm_pessoa)
            lcorpo = Replace(lcorpo, "$ds_fornec_contato", fornecedor.ds_contato)
            lcorpo = Replace(lcorpo, "$email", fornecedor.ds_email)
            lcorpo = Replace(lcorpo, "$fone1", fornecedor.ds_telefone_1)
            lcorpo = Replace(lcorpo, "$fone2", fornecedor.ds_telefone_2)

            lcorpo = Replace(lcorpo, "$nm_produtor", produtor.nm_pessoa)
            lcorpo = Replace(lcorpo, "$cd_produtor", produtor.cd_pessoa)
            lcorpo = Replace(lcorpo, "$nm_propriedade", propriedade.nm_propriedade)
            lcorpo = Replace(lcorpo, "$id_propriedade", propriedade.id_propriedade)
            'lcorpo = Replace(lcorpo, "$nr_unid_producao", lbl_limite_disponivel.Text.ToString)
            'fran fase 2 melhorias i
            'lcorpo = Replace(lcorpo, "$bairro_produtor", produtor.ds_bairro)
            'lcorpo = Replace(lcorpo, "$cidade_produtor", produtor.nm_cidade)
            'lcorpo = Replace(lcorpo, "$nm_estado_produtor", produtor.nm_estado)
            lcorpo = Replace(lcorpo, "$bairro_produtor", propriedade.ds_bairro)
            lcorpo = Replace(lcorpo, "$cidade_produtor", propriedade.nm_cidade)
            lcorpo = Replace(lcorpo, "$nm_estado_produtor", propriedade.nm_estado)
            'fran fase 2 melhorias 2

            If produtor.st_categoria = "F" Then
                lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cpf)
            Else
                lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cnpj)
            End If
            'fran fase 2 melhorias i
            'lcorpo = Replace(lcorpo, "$inscrestadualprodutor", produtor.cd_inscricao_estadual)
            'lcorpo = Replace(lcorpo, "$ds_contato", produtor.ds_contato)
            lcorpo = Replace(lcorpo, "$inscrestadualprodutor", propriedade.cd_inscricao_estadual)
            lcorpo = Replace(lcorpo, "$ds_contato", propriedade.ds_contato)
            'fran fase 2 melhorias f
            lcorpo = Replace(lcorpo, "$prodfone3", produtor.ds_telefone_1)
            lcorpo = Replace(lcorpo, "$prodfone4", produtor.ds_telefone_2)


            If ViewState.Item("st_parcelamento") = "N" OrElse ViewState.Item("st_parcelamento") = "D" OrElse ViewState.Item("nr_parcelas").ToString = "0" OrElse ViewState.Item("nr_parcelas").ToString = "1" Then
                lcorpo = Replace(lcorpo, "$tipopagamento", "À Vista.")
            Else
                If ViewState.Item("st_parcelamento") = "P" Then
                    lcorpo = Replace(lcorpo, "$tipopagamento", String.Concat("Parcelado em ", ViewState.Item("nr_parcelas").ToString, " X pelo Parceiro."))
                End If
            End If

            Dim pedido As New Pedido
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
            Dim dsgrid As DataSet = pedido.getCentralPedidoEmailParceiroItens()
            Dim row As DataRow
            Dim ltable As String = String.Empty
            Dim i As Integer = 1
            For Each row In dsgrid.Tables(0).Rows
                If i > 1 Then
                    ltable = ltable & "<tr><td style='width: 20px; height: 15px;'>&nbsp;</td><td style='width: 27px; height: 15px;'>&nbsp;</td><td colspan='2' style='height: 15px'>&nbsp;</td><td colspan='4' style='height: 15px'>&nbsp;</td></tr>"
                End If
                ltable = "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td style='width: 27px; font-weight: bold; height: 17px;'>2." & i.ToString & ".</td>"
                ltable = ltable & "<td colspan='6' style='font-weight: bold; height: 17px'>" & row.Item("nm_item").ToString & "</td>"
                ltable = ltable & "</tr>"

                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style=' height: 17px;'>Quantidade:</td>"
                'fran 09/11/2011 chamado 1132 i
                'ltable = ltable & "<td colspan='4' style='height: 17px'>" & CInt(row.Item("nr_quantidade")).ToString & " " & row.Item("nm_unidade_medida").ToString & "</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatNumber(row.Item("nr_quantidade"), 2).ToString & " " & row.Item("nm_unidade_medida").ToString & "</td>"
                'fran 09/11/2011 chamado 1132 f
                ltable = ltable & "</tr>"
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Embalagem:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & row.Item("ds_tipo_medida").ToString & "</td>"
                ltable = ltable & "</tr>"
                'fran 30/07/2010 i chamado 682 -
                If CInt(ViewState.Item("id_grupo")) <> 3 Then 'se o fornecedor for transportador de frete não exibe valor unitario e sacaria
                    ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                    ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Unitário:</td>"
                    ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_valor_unitario"), 2).ToString & "</td>"
                    ltable = ltable & "</tr>"
                    ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                    ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Sacaria:</td>"
                    ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_sacaria"), 2).ToString & "</td>"
                    ltable = ltable & "</tr>"
                End If

                If CInt(ViewState.Item("id_grupo")) <> 3 Then 'se nao é transportador
                    ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                    ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Frete:</td>"
                    ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_frete"), 2).ToString & "</td>"
                    ltable = ltable & "</tr>"

                Else
                    ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                    ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Frete:</td>"
                    ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_frete"), 2).ToString & "</td>"
                    ltable = ltable & "</tr>"
                End If
                'fran 07/12/2010 f chamado 1080
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Valor Total:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_valor_total"), 2).ToString & "</td>"
                ltable = ltable & "</tr>"

                'fran 08/2015 i melhorias relatorios
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Tipo Frete:</td>"
                lstipofrete = row.Item("ds_tipo_frete").ToString
                Select Case row.Item("ds_tipo_frete").ToString
                    Case "D"
                        lstipofrete = "FOB-D"
                    Case "C"
                        lstipofrete = "CIF"
                    Case "I"
                        lstipofrete = "FOB-I"

                End Select
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & lstipofrete & "</td>"
                ltable = ltable & "</tr>"

                If CInt(ViewState.Item("id_grupo")) = 3 Then 'se o fornecedor for transportador de frete exibe o nome do parceiro de compra 
                    ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                    ltable = ltable & "<td colspan='2' style='height: 17px'>Parceiro:</td>"
                    ltable = ltable & "<td colspan='4' style='height: 17px'>" & row.Item("nm_parceiro_compra").ToString & "</td>"
                    ltable = ltable & "</tr>"
                End If
                'fran 08/2015 f melhorias relatorios


                'lcorpo = Replace(lcorpo, "$itens", i.ToString)
                i = i + 1
            Next
            ''Dim lentrega As String = String.Empty
            ' ''fran 30/07/2010 i chamado 682 -
            ''If CInt(ViewState.Item("id_grupo")) <> 3 Then 'se o fornecedor for transportador de frete não existe grid de entregas
            ''    'fran 30/07/2010 f chamado 682 -
            ''    pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
            ''    Dim dsentrega As DataSet = pedido.getCentralPedidoEmailParceiroEntrega

            ''    Dim rows As DataRow
            ''    Dim j As Integer = 1
            ''    For Each rows In dsentrega.Tables(0).Rows
            ''        lentrega = lentrega & "<tr><td style='width: 20px; height: 17px'>&nbsp;</td><td style='width: 27px; height: 17px'>&nbsp;</td>"
            ''        lentrega = lentrega & "<td style='width: 35px; height: 17px'>3.1." & j.ToString & "</td>"
            ''        lentrega = lentrega & "<td colspan='2' >Entrega " & j.ToString & ":</td>"
            ''        lentrega = lentrega & "<td colspan='3' style='height: 17px'>"
            ''        lentrega = lentrega & DateTime.Parse(rows.Item("dt_entrega").ToString).ToString("dd/MM/yyyy") & "</td>"
            ''        lentrega = lentrega & "</tr>"
            ''        j = j + 1
            ''    Next
            ''End If

            'fran 01/2014 fase 2 melhorias i
            'Dim dspagto As DataSet = pedido.getCentralPedidoEmailParceiroPagto
            'Dim lpagtofornec As String = String.Empty
            'i = 1
            'For Each row In dspagto.Tables(0).Rows
            '    lpagtofornec = lpagtofornec & "<tr><td style='width: 20px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
            '    'fran 30/07/2010 i chamado 682 -
            '    If CInt(ViewState.Item("id_grupo")) = 3 Then 'se o fornecedor for transportador de frete o item é 3.1 pois não há entrega
            '        lpagtofornec = lpagtofornec & "<td style='width: 35px; '>3.1." & i.ToString & "</td>"
            '    Else
            '        'fran 30/07/2010 f chamado 682 -
            '        lpagtofornec = lpagtofornec & "<td style='width: 35px; '>3.2." & i.ToString & "</td>"
            '    End If
            '    lpagtofornec = lpagtofornec & "<td colspan='2' >Parcela " & i.ToString & ":</td>"
            '    lpagtofornec = lpagtofornec & "<td colspan='3' >" & row.Item("dt_pagto").ToString & "</td>"
            '    lpagtofornec = lpagtofornec & "</tr>"
            '    i = i + 1
            'Next
            'Foi implementado um combo em cotação, no grid de itens, prazo de pagto. Vamos substituir as datas de pagamento pelo texto do combo
            ''Dim lpagtofornec As String = String.Empty
            ''i = 1
            ''For Each row In dsgrid.Tables(0).Rows
            ''    lpagtofornec = lpagtofornec & "<tr><td style='width: 20px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
            ''    If CInt(ViewState.Item("id_grupo")) = 3 Then 'se o fornecedor for transportador de frete o item é 3.1 pois não há entrega
            ''        lpagtofornec = lpagtofornec & "<td style='width: 35px; '>3.1." & i.ToString & "</td>"
            ''    Else
            ''        lpagtofornec = lpagtofornec & "<td style='width: 35px; '>3.2." & i.ToString & "</td>"
            ''    End If
            ''    lpagtofornec = lpagtofornec & "<td colspan='2' >Item " & row.Item("nm_item").ToString & ":</td>"
            ''    'fran 06/2019 - se parcelamento parceuiro deve informar as parcelas
            ''    If CInt(ViewState.Item("id_grupo")) <> 3 AndAlso row.Item("st_parcelamento").ToString.Equals("P") AndAlso CInt(row.Item("nr_parcelas").ToString) > 1 Then
            ''        lpagtofornec = lpagtofornec & "<td colspan='3' >" & row.Item("nm_central_prazo_pagto").ToString & " em " & row.Item("nr_parcelas").ToString & " Parcelas</td>"
            ''    Else
            ''        lpagtofornec = lpagtofornec & "<td colspan='3' >" & row.Item("nm_central_prazo_pagto").ToString & "</td>"
            ''    End If
            ''    lpagtofornec = lpagtofornec & "</tr>"
            ''    i = i + 1
            ''Next
            'fran 01/2014 fase 2 melhorias f

            lcorpo = Replace(lcorpo, "$dsgriditens", ltable.ToString)
            ''lcorpo = Replace(lcorpo, "$dspagtofornec", lpagtofornec.ToString)
            ''lcorpo = Replace(lcorpo, "$dsentrega", lentrega.ToString)
            lcorpo = Replace(lcorpo, "ecxtextosmall", "textosmall")
            'lcorpo = Replace(lcorpo, "$itemcondgerais", i)
            'lcorpo = Replace(lcorpo, "$itemaprov", i + 1)

            'fran envio email datas i
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
            pedido.id_modificador = Session("id_login")
            'fran envio email datas f


            Dim notificacao As New Notificacao
            arqTemp.Close()
            'fran 24/08/2010 i chamado 931
            'If notificacao.enviaMensagemEmail(lassunto, lcorpo, "recepcao.de.leite-pocos@danone.com", lemail_parceiro, , MailPriority.High, True) = True Then
            'fran 14/01/2014 i fase 2 melhoria
            'If notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, , MailPriority.High, True) = True Then
            If notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, "central.compras@danone.com", MailPriority.High, True, lemail_parceiro2, False) = True Then
                'fran 14/01/2014 f fase 2 melhoria
                pedido.st_envio_email = "S"  'fran envio email datas i
                pedido.updateCentralPedidoDataEnvioEmail() 'fran envio email datas i

                'fran 24/08/2010 f chamado 931
                messageControl.Alert("Email enviado ao parceiro com sucesso!")
            Else

                pedido.st_envio_email = "N"  'fran envio email datas i
                pedido.updateCentralPedidoDataEnvioEmail() 'fran envio email datas i

                messageControl.Alert("Email ao parceiro não foi enviado com sucesso!")

            End If
        Else
            Dim pedido As New Pedido
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
            pedido.st_envio_email = "E"  'indica que Nao tem email no cadstro fran envio email datas i
            pedido.id_modificador = Session("id_login")
            pedido.updateCentralPedidoDataEnvioEmail() 'fran envio email datas i

            messageControl.Alert("O email não pode ser enviado pois não há nenhum email informado no cadastrado do Parceiro!")
        End If

    End Sub
    Protected Sub btn_adicionar_desconto_prod_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar_desconto_prod.Click
        If Page.IsValid Then

            ViewState.Item("incluirlinha") = "S"
            Dim desc As New PedidoDescontoProdutor
            desc.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item"))
            Dim dsdesc As DataSet = desc.getPedidoDescontoProdutorByFilters()
            Dim dr As DataRow = dsdesc.Tables(0).NewRow()
            dsdesc.Tables(0).Rows.InsertAt(dr, 0)
            ViewState.Item("incluirlinhadesc") = "S"
            grdDescProdutor.Visible = True
            grdDescProdutor.DataSource = Helper.getDataView(dsdesc.Tables(0), "nr_parcela")
            grdDescProdutor.EditIndex = 0
            grdDescProdutor.DataBind()
            ViewState.Item("incluirlinha") = Nothing
            ViewState.Item("label_nr_nota_prod") = Nothing

        End If

    End Sub
    Protected Sub grdDescProdutor_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdDescProdutor.PageIndexChanging
        grdDescProdutor.PageIndex = e.NewPageIndex
        loadData()

    End Sub
    Protected Sub grdDescProdutor_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdDescProdutor.RowCancelingEdit
        Try

            grdDescProdutor.EditIndex = -1
            ViewState.Item("incluirlinhadesc") = "N"
            ViewState.Item("incluirlinhadesc") = Nothing
            loadGridDescontoProdutor()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub grdDescProdutor_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdDescProdutor.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "delete"
                deletePedidoDescontoProd(Convert.ToInt32(e.CommandArgument.ToString()))
            Case "anexar"
                If lbl_interrupcao.Text = "Sim" Then
                    Response.Redirect("frm_central_pedido_anexos.aspx?id=" + e.CommandArgument.ToString() + "&tipo=intdp&tela=frm_central_pedido.aspx?id_central_pedido=" + ViewState.Item("id_central_pedido").ToString)
                Else
                    Response.Redirect("frm_central_pedido_anexos.aspx?id=" + e.CommandArgument.ToString() + "&tipo=peddp&tela=frm_central_pedido.aspx?id_central_pedido=" + ViewState.Item("id_central_pedido").ToString)

                End If


        End Select

    End Sub
    Protected Sub grdDescProdutor_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDescProdutor.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                'se esta reabrindo pedido desconto ao produtor
                'fran fase 3 dez/2014 i
                'If ViewState.Item("ReabrirPedido") = "S" Then
                Dim cbo_nr_nota As DropDownList = CType(e.Row.FindControl("cbo_nr_nota"), DropDownList)
                'Dim txt_nr_nota_fiscal As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_nota_fiscal"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                Dim rf_cbo_nota_fiscal As RequiredFieldValidator = CType(e.Row.FindControl("rf_cbo_nota_fiscal"), RequiredFieldValidator)
                'Dim rqf_nr_nota As RequiredFieldValidator = CType(e.Row.FindControl("rqf_nr_nota"), RequiredFieldValidator)
                rf_cbo_nota_fiscal.Visible = True
                'rqf_nr_nota.Visible = False
                'txt_nr_nota_fiscal.Visible = False
                cbo_nr_nota.Visible = True

                If ViewState.Item("incluirlinhadesc") = "S" Then
                    ViewState.Item("label_nr_nota_prod") = "0"
                End If

                If Not (ViewState.Item("label_nr_nota_prod") Is Nothing) Then

                    Dim nrnotapedido As New PedidoNotas
                    nrnotapedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido").ToString)
                    cbo_nr_nota.DataSource = nrnotapedido.getCentralPedidoNotasCombo()
                    cbo_nr_nota.DataTextField = "nr_nota_fiscal"
                    'cbo_nr_nota.DataValueField = "nr_valor_nota_fiscal"
                    cbo_nr_nota.DataValueField = "id_central_pedido_notas"
                    cbo_nr_nota.DataBind()

                    If (ViewState.Item("label_nr_nota_prod").ToString.Equals("0")) Then
                        cbo_nr_nota.Items.Insert(0, New ListItem("[Selecione]", 0))
                        ViewState.Item("label_nr_nota_prod") = "SEM_VALOR"
                    Else
                        'cbo_nr_nota.SelectedValue = cbo_nr_nota.Items.FindByText(ViewState.Item("label_nr_nota_prod").Trim.ToString).Value
                        cbo_nr_nota.SelectedValue = ViewState.Item("label_nr_nota_prod").Trim.ToString
                        ViewState.Item("label_nr_nota_prod") = Nothing
                    End If
                End If


                'End If

                'fran fase 3 dez/2014 f

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub
    Protected Sub grdDescProdutor_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDescProdutor.RowDataBound
        Dim lbl_st_mais_solidos As Label = CType(e.Row.FindControl("lbl_st_mais_solidos"), Label)
        Dim lbl_st_mais_solidos_valor_utilizado As Label = CType(e.Row.FindControl("lbl_st_mais_solidos_valor_utilizado"), Label)
        Dim lbl_saldo_mais_solidos As Label = CType(e.Row.FindControl("lbl_saldo_mais_solidos"), Label)
        Dim lnr_saldo_disponivel_referencia As Decimal = 0

        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Dim dt_pagto As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(e.Row.FindControl("txt_dt_pagto"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
            'Dim chk_mais_solidos As CheckBox = CType(e.Row.FindControl("chk_mais_solidos"), CheckBox)

            'fran fase 3 set/2014 i 
            ' If ViewState.Item("ReabrirPedido") = "S" Then

            Dim cbo_nr_nota As DropDownList = CType(e.Row.FindControl("cbo_nr_nota"), DropDownList)
            'Dim txt_nr_nota_fiscal As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_nota_fiscal"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
            'Dim txt_nr_valor_nota_fiscal As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_valor_nota_fiscal"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim rf_cbo_nota_fiscal As RequiredFieldValidator = CType(e.Row.FindControl("rf_cbo_nota_fiscal"), RequiredFieldValidator)
            'Dim rqf_nr_nota As RequiredFieldValidator = CType(e.Row.FindControl("rqf_nr_nota"), RequiredFieldValidator)
            Dim chk_st_tipo_desconto As Anthem.CheckBox = CType(e.Row.FindControl("chk_st_tipo_desconto"), Anthem.CheckBox)
            Dim lbl_st_tipo_desconto As Label = CType(e.Row.FindControl("lbl_st_tipo_desconto"), Label)
            Dim lbl_dt_acerto As Label = CType(e.Row.FindControl("lbl_dt_acerto"), Label)
            Dim lbl_acerto As Anthem.Label = CType(e.Row.FindControl("lbl_acerto"), Anthem.Label)
            Dim bacertoefetivado As Boolean = False

            rf_cbo_nota_fiscal.Visible = True
            'rqf_nr_nota.Visible = False

            cbo_nr_nota.Visible = True
            'txt_nr_nota_fiscal.Visible = False
            'txt_nr_valor_nota_fiscal.Enabled = False

            If ViewState.Item("label_nr_nota_prod") = "SEM_VALOR" Then
                'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                If Not (cbo_nr_nota Is Nothing) Then
                    cbo_nr_nota.Items.Insert(0, New ListItem("[Selecione]", 0))
                End If
                ViewState.Item("label_nr_nota_prod") = Nothing

            End If
            'End If


            'fran fase 3 set/2014 f 

            If Not dt_pagto.Text.Equals(String.Empty) Then
                'fran 16/03/2010 i
                'dt_pagto.Text = Left(dt_pagto.Text.Trim, 10)
                dt_pagto.Text = DateTime.Parse(dt_pagto.Text.Trim).ToString("dd/MM/yyyy")
                'fran 16/03/2010 f
            End If

            If lbl_st_tipo_desconto.Text = "D" Then
                chk_st_tipo_desconto.Checked = True
            Else
                chk_st_tipo_desconto.Checked = False

            End If

            'Fran 10/2018 i
            'se produtor faz parte mais solidos
            'If ViewState.Item("maissolidospremiado") = True Then
            '    If CDec(ViewState.Item("maissolidossaldodisponivel")) > 0 Then
            '        If lbl_st_mais_solidos.Text = "S" Then
            '            chk_mais_solidos.Checked = True
            '            chk_mais_solidos.ToolTip = "Programa Mais Sólidos utilizado."
            '        Else
            '            chk_mais_solidos.Checked = False
            '            If Not dt_pagto.Text.Equals(String.Empty) Then
            '                BuscarMaisSolidosValorPremio(String.Concat("01", Right(dt_pagto.Text, 8)), 1, True, , , , lnr_saldo_disponivel_referencia)
            '                If lnr_saldo_disponivel_referencia = 0 Then
            '                    chk_mais_solidos.Enabled = False
            '                    chk_mais_solidos.ToolTip = "O Saldo da REFERÊNCIA para o Programa Mais Sólidos está zerado."
            '                    lbl_saldo_mais_solidos.Visible = True
            '                    lbl_saldo_mais_solidos.Text = "Saldo: R$ 0,00"
            '                Else
            '                    chk_mais_solidos.Enabled = True
            '                    chk_mais_solidos.ToolTip = String.Empty
            '                    lbl_saldo_mais_solidos.Visible = True
            '                    lbl_saldo_mais_solidos.Text = String.Concat("Saldo: ", FormatCurrency(lnr_saldo_disponivel_referencia, 2))
            '                End If
            '            Else
            '                chk_mais_solidos.Enabled = False
            '                lbl_saldo_mais_solidos.Visible = False
            '            End If

            '        End If

            '    Else 'saldo disponivel do programa zerado
            '        'se o desconto está utilizando programa
            '        If lbl_st_mais_solidos.Text = "S" Then
            '            chk_mais_solidos.Checked = True
            '        Else
            '            chk_mais_solidos.Checked = False
            '            chk_mais_solidos.Enabled = False
            '            chk_mais_solidos.ToolTip = "O Saldo do Programa Mais Sólidos está zerado!"
            '        End If

            '    End If
            'End If
        Else
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim dt_pagto As Label = CType(e.Row.FindControl("lbl_dt_pagto"), Label)
                Dim img_st_utilizar_mais_solidos As Anthem.Image = CType(e.Row.FindControl("img_st_utilizar_mais_solidos"), Anthem.Image)
                Dim img_st_tipo_desconto As Anthem.Image = CType(e.Row.FindControl("img_st_tipo_desconto"), Anthem.Image)
                Dim lbl_st_tipo_desconto As Label = CType(e.Row.FindControl("lbl_st_tipo_desconto"), Label)
                Dim lbl_dt_acerto As Label = CType(e.Row.FindControl("lbl_dt_acerto"), Label)
                Dim lbl_acerto As Anthem.Label = CType(e.Row.FindControl("lbl_acerto"), Anthem.Label)
                Dim bacertoefetivado As Boolean = False

                'fran set/2014 fase 3 i
                'se nao tem nr nota veio de cotacao e acessa pedido pela primeira vez
                Dim lbl_nr_nota_fiscal As Label = CType(e.Row.FindControl("lbl_nr_nota_fiscal"), Label)
                If lbl_nr_nota_fiscal.Text.Equals(String.Empty) Then
                    ViewState.Item("DescProd1avez") = "S"
                Else
                    ViewState.Item("DescProd1avez") = "N"
                End If
                'fran set/2014 fase 3 f

                If Not dt_pagto.Text.Equals(String.Empty) Then
                    'fran 16/03/2010 i
                    'dt_pagto.Text = Left(dt_pagto.Text.Trim, 10)
                    dt_pagto.Text = DateTime.Parse(dt_pagto.Text.Trim).ToString("dd/MM/yyyy")
                    'fran 16/03/2010 f
                End If
                'fran 26/03/2012 i 
                Dim lbl_st_transf As Label = CType(e.Row.FindControl("lbl_st_transf"), Label)
                Dim lbl_pedidoorigem As Label = CType(e.Row.FindControl("lbl_pedido_ori"), Label)
                Dim lbl_proporigem As Label = CType(e.Row.FindControl("lbl_prop_ori"), Label)
                Dim btn_editar As Anthem.ImageButton = CType(e.Row.FindControl("btn_editar"), Anthem.ImageButton)
                Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("btn_delete"), Anthem.ImageButton)
                Dim bcalculado As Boolean = False 'fran 08/2014 fase 3
                Dim lbl_id_central_pedido_desconto_produtor As Label = CType(e.Row.FindControl("lbl_id_central_pedido_desconto_produtor"), Label)
                Dim lbl_id_ficha_financeira_calc As Label = CType(e.Row.FindControl("lbl_id_ficha_financeira_calc"), Label)
                Dim lbl_nr_valor_parcela As Label = CType(e.Row.FindControl("lbl_nr_valor_parcela"), Label)
                Dim btn_anexar As Anthem.ImageButton = CType(e.Row.FindControl("btn_anexar"), Anthem.ImageButton)

                If lbl_id_central_pedido_desconto_produtor.Text.Equals(String.Empty) Then
                    Dim img_st_calculado As Anthem.Image = CType(e.Row.FindControl("img_st_calculado"), Anthem.Image)
                    img_st_calculado.ImageUrl = "~/img/ico_chk_false.gif"
                    bcalculado = False 'fran 08/2014 fase 3
                    img_st_tipo_desconto.ImageUrl = "~/img/ico_chk_false.gif"
                    btn_anexar.Visible = False
                Else
                    'fran 01/06/2012 chamado 1560 f

                    If Not lbl_id_ficha_financeira_calc.Text.Equals(String.Empty) AndAlso CInt(lbl_id_ficha_financeira_calc.Text) > 0 Then
                        Dim img_st_calculado As Anthem.Image = CType(e.Row.FindControl("img_st_calculado"), Anthem.Image)
                        img_st_calculado.ImageUrl = "~/img/ico_chk_true.gif"
                        img_st_calculado.ToolTip = "Cálculo definitivo executado."
                        bcalculado = True 'fran 08/2014 fase 3
                        btn_anexar.Visible = False
                    Else
                        Dim img_st_calculado As Anthem.Image = CType(e.Row.FindControl("img_st_calculado"), Anthem.Image)
                        img_st_calculado.ImageUrl = "~/img/ico_chk_false.gif"
                        bcalculado = False 'fran 08/2014 fase 3

                    End If
                    'fran 26/03/2012 f 
                    If lbl_st_tipo_desconto.Text = "D" OrElse lbl_st_tipo_desconto.Text = "P" Then
                        img_st_tipo_desconto.ImageUrl = "~/img/ico_chk_true.gif"
                        btn_anexar.Visible = True
                        If lbl_dt_acerto.Text.Equals(String.Empty) Then
                            lbl_acerto.Text = String.Empty
                            lbl_acerto.Visible = False
                            bacertoefetivado = False
                        Else
                            lbl_acerto.Visible = True
                            lbl_acerto.Text = String.Concat("Acerto em", DateTime.Parse(lbl_dt_acerto.Text).ToString("dd/MM/yyyy"))
                            bacertoefetivado = True
                        End If
                    Else
                        img_st_tipo_desconto.ImageUrl = "~/img/ico_chk_false.gif"
                        lbl_acerto.Text = String.Empty
                        lbl_acerto.Visible = False
                        btn_anexar.Visible = False
                    End If

                End If
                'fran fase 3 8/2014 i
                ''se ja tem calculo nao pode alterar 
                'If ViewState.Item("ReabrirPedido") = "S" Then

                If bcalculado = True OrElse bacertoefetivado = True Then
                    btn_editar.Enabled = False
                    btn_delete.Enabled = False
                    btn_editar.ImageUrl = "~/img/icone_editar_grid_desabilitado.gif"
                    btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                End If
                'End If

                'If lbl_st_transf.Text = "S" Then 'se veio calculado de pedido anterior (transf volume)
                '    Dim img_st_calculado As Anthem.Image = CType(e.Row.FindControl("img_st_calculado"), Anthem.Image)
                '    img_st_calculado.ImageUrl = "~/img/ico_chk_true.gif"
                '    img_st_calculado.ToolTip = "Cálculo efetivado no Pedido Origem, antes da transferência de volume."
                '    'pedido
                '    lbl_pedidoorigem.Text = lbl_pedido_origem.Text
                '    'propriedade origem
                '    lbl_proporigem.Text = lbl_propriedadeup_origem.Text
                '    bcalculado = True 'fran 08/2014 fase 3
                'Else
                '    'fran 15/05/2012 Themis
                '    Dim desctoprodutor As New PedidoDescontoProdutor
                '    'fran 01/06/2012 chamado 1560 i
                '    If lbl_id_central_pedido_desconto_produtor.Text.Equals(String.Empty) Then
                '        Dim img_st_calculado As Anthem.Image = CType(e.Row.FindControl("img_st_calculado"), Anthem.Image)
                '        img_st_calculado.ImageUrl = "~/img/ico_chk_false.gif"
                '        bcalculado = False 'fran 08/2014 fase 3

                '    Else
                '        'fran 01/06/2012 chamado 1560 f

                '        desctoprodutor.id_central_pedido_desconto_produtor = Convert.ToInt32(lbl_id_central_pedido_desconto_produtor.Text)
                '        If desctoprodutor.getPedidoDescontoProdutorCalculado > 0 Then
                '            Dim img_st_calculado As Anthem.Image = CType(e.Row.FindControl("img_st_calculado"), Anthem.Image)
                '            img_st_calculado.ImageUrl = "~/img/ico_chk_true.gif"
                '            img_st_calculado.ToolTip = "Cálculo definitivo executado."
                '            bcalculado = True 'fran 08/2014 fase 3
                '        Else
                '            Dim img_st_calculado As Anthem.Image = CType(e.Row.FindControl("img_st_calculado"), Anthem.Image)
                '            img_st_calculado.ImageUrl = "~/img/ico_chk_false.gif"
                '            bcalculado = False 'fran 08/2014 fase 3

                '        End If
                '        'fran 26/03/2012 f 
                '    End If
                '    'fran fase 3 8/2014 i
                '    'se ja tem calculo nao pode alterar 
                '    If ViewState.Item("ReabrirPedido") = "S" Then

                '        If bcalculado = True Then
                '            btn_editar.Enabled = False
                '            btn_delete.Enabled = False
                '            btn_editar.ImageUrl = "~/img/icone_editar_grid_desabilitado.gif"
                '            btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                '        Else
                '            'Dim txt_nr_nota_fiscal As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_nota_fiscal"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                '            'Dim txt_nr_valor_nota_fiscal As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_valor_nota_fiscal"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                '            'txt_nr_nota_fiscal.Enabled = False
                '            'txt_nr_valor_nota_fiscal.Enabled = False
                '        End If
                '    End If
                '    'fran fase 3 8/2014 f

                'End If

                ''Fran 10/2018 i
                'If lbl_id_central_pedido_desconto_produtor.Text.Equals(String.Empty) Then
                '    img_st_utilizar_mais_solidos.ImageUrl = "~/img/ico_chk_false.gif"
                'Else
                '    'se produtor faz parte mais solidos
                '    If ViewState.Item("maissolidospremiado") = True Then
                '        If CDec(ViewState.Item("maissolidossaldodisponivel")) > 0 Then
                '            If lbl_st_mais_solidos.Text = "S" Then
                '                img_st_utilizar_mais_solidos.ImageUrl = "~/img/ico_chk_true.gif"
                '                img_st_utilizar_mais_solidos.ToolTip = "Programa Mais Sólidos utilizado."
                '                lbl_saldo_mais_solidos.Text = String.Empty
                '            Else
                '                BuscarMaisSolidosValorPremio(String.Concat("01", Right(dt_pagto.Text, 8)), CDec(lbl_nr_valor_parcela.Text), True, , , , lnr_saldo_disponivel_referencia)
                '                img_st_utilizar_mais_solidos.ImageUrl = "~/img/ico_chk_false.gif"
                '                If lnr_saldo_disponivel_referencia = 0 Then
                '                    lbl_saldo_mais_solidos.Text = "Saldo: R$ 0,00"
                '                Else
                '                    lbl_saldo_mais_solidos.Text = String.Concat("Saldo: ", FormatCurrency(lnr_saldo_disponivel_referencia, 2))

                '                End If

                '            End If

                '        Else 'saldo disponivel do programa zerado
                '            'se o desconto está utilizando programa
                '            If lbl_st_mais_solidos.Text = "S" Then
                '                img_st_utilizar_mais_solidos.ImageUrl = "~/img/ico_chk_true.gif"
                '                img_st_utilizar_mais_solidos.ToolTip = "Programa Mais Sólidos utilizado."
                '                lbl_saldo_mais_solidos.Text = String.Empty
                '            Else
                '                img_st_utilizar_mais_solidos.ImageUrl = "~/img/ico_chk_false.gif"
                '                lbl_saldo_mais_solidos.Text = "Saldo: R$ 0,00"
                '            End If

                '        End If
                '        'se ainda nao gravou

                '    End If


                'End If
            End If
        End If
    End Sub
    Protected Sub grdDescProdutor_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdDescProdutor.RowDeleting
        e.Cancel = True

    End Sub
    Protected Sub grdDescProdutor_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdDescProdutor.RowEditing
        Try
            If ViewState.Item("incluirlinha") = "S" And e.NewEditIndex = 0 Then
                ViewState.Item("incluirlinha") = "S"
                loadGridDescontoProdutor()
            Else
                'Dim lbl_nr_nota_fiscal As Label = CType(grdDescProdutor.Rows(e.NewEditIndex).FindControl("lbl_nr_nota_fiscal"), Label)
                Dim lbl_id_central_pedido_notas As Label = CType(grdDescProdutor.Rows(e.NewEditIndex).FindControl("lbl_id_central_pedido_notas"), Label)
                ViewState.Item("label_nr_nota_prod") = Trim(lbl_id_central_pedido_notas.Text) 'fran fase 3 dez/2014
                grdDescProdutor.EditIndex = e.NewEditIndex
                loadGridDescontoProdutor()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdDescProdutor_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdDescProdutor.RowUpdating
        Dim row As GridViewRow = grdDescProdutor.Rows(e.RowIndex)
        Try
            If Page.IsValid Then


                If (Not (row) Is Nothing) Then

                    Dim desconto As New PedidoDescontoProdutor
                    Dim dsdesconto As DataSet

                    Dim lbl_id_central_pedido_item As Label = CType(row.FindControl("lbl_id_central_pedido_item"), Label)
                    Dim lbl_id_central_pedido_desconto_produtor As Label = CType(row.FindControl("lbl_id_central_pedido_desconto_produtor"), Label)
                    Dim lbl_id_central_pedido_notas As Label = CType(row.FindControl("lbl_id_central_pedido_notas"), Label)

                    'Dim nr_valor_nota_fiscal As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_nota_fiscal"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim nr_parcela As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_parcela"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                    'Dim nr_nota_fiscal As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_nota_fiscal"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                    Dim nr_valor_parcela As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_parcela"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim dt_pagto As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_pagto"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
                    Dim cbo_nr_nota As DropDownList = CType(row.FindControl("cbo_nr_nota"), DropDownList) 'fran fase 3 set/2014
                    'Dim chk_mais_solidos As CheckBox = CType(row.FindControl("chk_mais_solidos"), CheckBox)
                    'Dim lbl_st_mais_solidos As Label = CType(row.FindControl("lbl_st_mais_solidos"), Label)
                    'Dim lbl_st_mais_solidos_valor_utilizado As Label = CType(row.FindControl("lbl_st_mais_solidos_valor_utilizado"), Label)
                    Dim bmaissolidosincluir As Boolean = False
                    Dim bmaissolidosretirar As Boolean = False
                    Dim chk_st_tipo_desconto As Anthem.CheckBox = CType(row.FindControl("chk_st_tipo_desconto"), Anthem.CheckBox)


                    ''fran fase 3 set/2014 i
                    'If ViewState.Item("ReabrirPedido") = "S" Then
                    '    desconto.nr_nota_fiscal = Convert.ToInt32(cbo_nr_nota.SelectedItem.Text)
                    'Else
                    '    'fran fase 3 set/2014 f

                    '    If Not nr_nota_fiscal.Text.ToString.Equals(String.Empty) Then
                    '        desconto.nr_nota_fiscal = Convert.ToInt32(nr_nota_fiscal.Text)
                    '    End If
                    'End If


                    'If Not nr_valor_nota_fiscal.Text.ToString.Equals(String.Empty) Then
                    '    desconto.nr_valor_nota_fiscal = Convert.ToDecimal(nr_valor_nota_fiscal.Text)
                    'End If

                    desconto.id_central_pedido_notas = cbo_nr_nota.SelectedValue

                    desconto.nr_parcela = nr_parcela.Text
                    desconto.dt_pagto = dt_pagto.Text
                    If Not nr_valor_parcela.Text.ToString.Equals(String.Empty) Then
                        desconto.nr_valor_parcela = Convert.ToDecimal(nr_valor_parcela.Text)
                    End If
                    desconto.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item"))
                    desconto.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))

                    'se esta querendo atualizar no mais solidos
                    'If chk_mais_solidos.Checked = True Then
                    '    desconto.st_mais_solidos = "S"
                    'Else
                    '    desconto.st_mais_solidos = "N"
                    'End If
                    If chk_st_tipo_desconto.Checked = True Then
                        desconto.st_tipo_desconto = "D" 'deposito
                        'Else
                        '    desconto.st_tipo_desconto = "L" 'lancamwnto (calculo)
                    End If
                    'fran 14/02/2011 chamado 1170 i só deixa atualizar ou inserir se algum campo for diferente do banco
                    dsdesconto = desconto.getPedidoDescontoProdutorByFilters 'fran 10/2018i
                    'If desconto.getPedidoDescontoProdutorByFilters.Tables(0).Rows.Count = 0 Then 'fran 10/2018i
                    desconto.id_modificador = Session("id_login")

                    If dsdesconto.Tables(0).Rows.Count = 0 Then
                        'fran 14/02/2011 chamado 1170 f
                        'Se é um novo item
                        If Not ViewState.Item("incluirlinhadesc") Is Nothing Then
                            If ViewState.Item("incluirlinhadesc") = "S" Then
                                desconto.id_central_pedido_desconto_produtor = desconto.insertPedidoCentralDescontoProdutor()
                                ViewState.Item("incluirlinhadesc") = Nothing

                                'If ViewState.Item("maissolidospremiado") = True AndAlso desconto.st_mais_solidos = "S" Then
                                '    bmaissolidosincluir = True
                                'Else
                                '    bmaissolidosincluir = False
                                'End If
                            Else
                                desconto.id_central_pedido_desconto_produtor = Convert.ToInt32(lbl_id_central_pedido_desconto_produtor.Text)
                                desconto.updatePedidoDescontoProdutor()
                                'If ViewState.Item("maissolidospremiado") = True AndAlso desconto.st_mais_solidos = "S" AndAlso Not lbl_st_mais_solidos.Text = "S" Then
                                '    bmaissolidosincluir = True
                                'End If
                                'If ViewState.Item("maissolidospremiado") = True AndAlso desconto.st_mais_solidos = "N" AndAlso lbl_st_mais_solidos.Text = "S" Then
                                '    bmaissolidosretirar = True
                                'End If
                            End If
                        Else
                            desconto.id_central_pedido_desconto_produtor = Convert.ToInt32(lbl_id_central_pedido_desconto_produtor.Text)
                            desconto.updatePedidoDescontoProdutor()
                            'If ViewState.Item("maissolidospremiado") = True AndAlso desconto.st_mais_solidos = "S" AndAlso Not lbl_st_mais_solidos.Text = "S" Then
                            '    bmaissolidosincluir = True
                            'End If
                            'If ViewState.Item("maissolidospremiado") = True AndAlso desconto.st_mais_solidos = "N" AndAlso lbl_st_mais_solidos.Text = "S" Then
                            '    bmaissolidosretirar = True
                            'End If
                        End If
                        'fran 14/02/2011 chamado 1170 i

                        If ViewState.Item("DescProd1avez") = "S" Then
                            desconto.updatePedidoDescontoProdutorNotaData()
                        End If
                    Else
                        'fran 10/2018 i
                        ''se é produtor premiado
                        'If ViewState.Item("maissolidospremiado") = True AndAlso desconto.st_mais_solidos = "S" AndAlso Not lbl_st_mais_solidos.Text = "S" Then
                        '    bmaissolidosincluir = True
                        'End If
                        'If ViewState.Item("maissolidospremiado") = True AndAlso desconto.st_mais_solidos = "N" AndAlso lbl_st_mais_solidos.Text = "S" Then
                        '    bmaissolidosretirar = True
                        'End If

                        If Not ViewState.Item("incluirlinhadesc") Is Nothing Then
                            If ViewState.Item("incluirlinhadesc") = "S" Then
                                ViewState.Item("incluirlinhadesc") = Nothing
                            End If
                        End If
                    End If
                    'fran 14/02/2011 chamado 1170 f
                    '**********************************************************************************************
                    'MAIS SOLIDOS
                    '***********************************************************************************************
                    ''fran 10/2018 i MAIS SOLIDOS
                    'Dim lnr_maissolidos_valor_premio As Decimal = 0
                    'Dim lnrmssaldodisponivel As Decimal
                    'Dim maissolidos As New Poupanca

                    'If CInt(ViewState.Item("id_propriedade_titular")) > 0 Then
                    '    maissolidos.id_propriedade_titular = ViewState.Item("id_propriedade_titular")
                    '    maissolidos.id_pessoa = 0
                    'Else
                    '    maissolidos.id_pessoa = Convert.ToInt32(ViewState.Item("id_produtor"))
                    '    maissolidos.id_propriedade_titular = 0
                    'End If
                    'maissolidos.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
                    'maissolidos.id_modificador = desconto.id_modificador
                    'maissolidos.dt_referencia = String.Concat("01", Right(DateTime.Parse(desconto.dt_pagto).ToString("dd/MM/yyyy"), 8))

                    'If Not lbl_id_central_pedido_desconto_produtor.Text.Equals(String.Empty) And Not desconto.id_central_pedido_desconto_produtor > 0 Then
                    '    desconto.id_central_pedido_desconto_produtor = Convert.ToInt32(lbl_id_central_pedido_desconto_produtor.Text)
                    'End If

                    'If bmaissolidosincluir = True Then
                    '    'busca o valor do premio, e se tiver premio devolve o valor do total da central atualizado
                    '    lnr_maissolidos_valor_premio = Me.BuscarMaisSolidosValorPremio(maissolidos.dt_referencia.ToString, desconto.nr_valor_parcela, True, , , , )

                    '    'se nao tem saldo para a referencia pagto
                    '    If lnr_maissolidos_valor_premio = 0 Then
                    '        'atualiza o desconto do produtor para nao pode utilizar saldo mais solidos
                    '        desconto.st_mais_solidos = "N"
                    '        desconto.nr_mais_solidos_valor_utilizado = 0
                    '        desconto.updatePedidoDescontoProdutorMaisSolidos()
                    '    Else
                    '        'se tema saldo, atualiza desconto ao produtor e poupanca premio
                    '        desconto.st_mais_solidos = "S"
                    '        desconto.nr_mais_solidos_valor_utilizado = lnr_maissolidos_valor_premio
                    '        desconto.updatePedidoDescontoProdutorMaisSolidos()

                    '        maissolidos.nr_valor_central = lnr_maissolidos_valor_premio
                    '        maissolidos.updateMaisSolidosPremio()

                    '        'atualiza saldo disponivel
                    '        lnrmssaldodisponivel = maissolidos.getMaisSolidosProdutorSaldoDisponivel
                    '        lbl_ms_valor_disponivel.Text = FormatCurrency(lnrmssaldodisponivel, 2)
                    '        ViewState.Item("maissolidossaldodisponivel") = lnrmssaldodisponivel

                    '    End If

                    'End If

                    'If bmaissolidosretirar Then
                    '    'atualiza o desconto do produtor para nao pode utilizar saldo mais solidos
                    '    desconto.st_mais_solidos = "N"
                    '    desconto.nr_mais_solidos_valor_utilizado = 0
                    '    desconto.updatePedidoDescontoProdutorMaisSolidos()

                    '    'se o desconto ao produtor deletado tem mais solidos
                    '    If Not lbl_st_mais_solidos_valor_utilizado.Text.Equals(String.Empty) Then
                    '        maissolidos.nr_valor_central = -CDec(lbl_st_mais_solidos_valor_utilizado.Text)
                    '        maissolidos.id_modificador = Session("id_login")
                    '        maissolidos.updateMaisSolidosPremio()
                    '    End If

                    '    'atualiza saldo disponivel
                    '    lnrmssaldodisponivel = maissolidos.getMaisSolidosProdutorSaldoDisponivel
                    '    lbl_ms_valor_disponivel.Text = FormatCurrency(lnrmssaldodisponivel, 2)
                    '    ViewState.Item("maissolidossaldodisponivel") = lnrmssaldodisponivel

                    'End If
                    'fran 10/2018 f MAIS SOLIDOS

                    grdDescProdutor.EditIndex = -1

                    loadGridDescontoProdutor()

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridEntrega_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridEntrega.PageIndexChanging
        gridEntrega.PageIndex = e.NewPageIndex
        loadData()

    End Sub
    Protected Sub gridEntrega_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridEntrega.RowCancelingEdit
        Try

            gridEntrega.EditIndex = -1
            ViewState.Item("incluirlinhaentrega") = "N"
            ViewState.Item("incluirlinhaentrega") = Nothing
            loadGridEntrega()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridEntrega_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridEntrega.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "delete"
                deletePedidoEntrega(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Protected Sub gridEntrega_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridEntrega.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                Dim cvparceiro As CustomValidator = CType(e.Row.FindControl("cv_parceiro"), CustomValidator)
                Dim dt_entrega_prevista As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(e.Row.FindControl("txt_dt_entrega_prevista"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
                Dim nr_quantidade_prevista As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_quantidade_prevista"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim nr_parcela As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_parcela"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                If ViewState.Item("incluirlinha") = "S" Then
                    If e.Row.RowIndex = 0 Then
                        ViewState.Item("label_parceiro") = ""
                        ViewState.Item("label_tipo") = ""
                    End If
                End If
                If ViewState.Item("incluirlinhaentrega") = "S" Then
                    'cvparceiro.Enabled = True
                    nr_parcela.Enabled = True
                    'nr_quantidade_prevista.Enabled = True
                    'dt_entrega_prevista.Enabled = True
                Else
                    'cvparceiro.Enabled = False
                    nr_parcela.Enabled = False
                    'nr_quantidade_prevista.Enabled = False
                    'dt_entrega_prevista.Enabled = False
                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub
    Protected Sub gridEntrega_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridEntrega.RowDataBound
        Dim lbl_st_selecionado As Label = CType(e.Row.FindControl("lbl_st_selecionado"), Label)
        Dim chk_st_selecionado As CheckBox = CType(e.Row.FindControl("chk_st_selecionado"), CheckBox)
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try

                Dim dt_entrega_prevista As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(e.Row.FindControl("txt_dt_entrega_prevista"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
                Dim dt_entrega_real As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(e.Row.FindControl("txt_dt_entrega_real"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
                Dim nr_quantidade_real As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_quantidade_real"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                If Not dt_entrega_prevista.Text.Equals(String.Empty) Then
                    dt_entrega_prevista.Text = DateTime.Parse(dt_entrega_prevista.Text).ToString("dd/MM/yyyy")
                Else
                    dt_entrega_prevista.Text = String.Empty
                End If
                If Not dt_entrega_real.Text.Equals(String.Empty) Then
                    'fran 23/11/2010 chamado 1070 i
                    'dt_entrega_real.Text = DateTime.Parse(dt_entrega_prevista.Text).ToString("dd/MM/yyyy")
                    dt_entrega_real.Text = DateTime.Parse(dt_entrega_real.Text).ToString("dd/MM/yyyy")
                    'fran 23/11/2010 chamado 1070 f
                Else
                    dt_entrega_real.Text = String.Empty
                End If
                'fran fase 2 melhorias i
                If Not nr_quantidade_real.Text.Trim.Equals(String.Empty) Then
                    If CDec(nr_quantidade_real.Text) = 0 Then
                        nr_quantidade_real.Text = String.Empty
                    End If
                End If
                'fran fase 2 melhorias f

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        Else
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim dt_entrega_prevista As Label = CType(e.Row.FindControl("lbl_dt_entrega_prevista"), Label)
                Dim dt_entrega_real As Label = CType(e.Row.FindControl("lbl_dt_entrega_real"), Label)
                If Not dt_entrega_prevista.Text.Equals(String.Empty) Then
                    dt_entrega_prevista.Text = DateTime.Parse(dt_entrega_prevista.Text).ToString("dd/MM/yyyy")
                End If

                If Not dt_entrega_real.Text.Equals(String.Empty) Then
                    'fran 23/11/2010 chamado 1070 i
                    'dt_entrega_real.Text = DateTime.Parse(dt_entrega_prevista.Text).ToString("dd/MM/yyyy")
                    dt_entrega_real.Text = DateTime.Parse(dt_entrega_real.Text).ToString("dd/MM/yyyy")
                    'fran 23/11/2010 chamado 1070 f
                End If
                'se finalizado
                'fran 05/05/2010 i chamado 812
                'fran chamado 998 i 
                'If ViewState.Item("id_situacao_pedido").ToString = "3" Then
                If ViewState.Item("id_situacao_pedido").ToString <> "1" Then
                    'fran chamado 998 f

                    Dim btn_delete As ImageButton = CType(e.Row.FindControl("btn_delete"), ImageButton)
                    btn_delete.Visible = False
                End If
                'fran 05/05/2010 i chamado 812

            End If
        End If

    End Sub
    Protected Sub gridEntrega_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridEntrega.RowDeleting
        e.Cancel = True

    End Sub
    Protected Sub gridEntrega_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridEntrega.RowEditing
        Try
            If ViewState.Item("incluirlinha") = "S" And e.NewEditIndex = 0 Then
                ViewState.Item("incluirlinha") = "S"
                loadGridEntrega()
            Else
                gridEntrega.EditIndex = e.NewEditIndex
                loadGridEntrega()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridEntrega_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridEntrega.RowUpdating
        Dim row As GridViewRow = gridEntrega.Rows(e.RowIndex)
        Try
            If Page.IsValid Then


                If (Not (row) Is Nothing) Then

                    Dim entrega As New PedidoEntrega

                    Dim lbl_id_central_pedido_item As Label = CType(row.FindControl("lbl_id_central_pedido_item"), Label)
                    Dim lbl_id_central_pedido_entrega As Label = CType(row.FindControl("lbl_id_central_pedido_entrega"), Label)

                    Dim lvalor_total As Decimal
                    Dim lqtdeitem As Decimal

                    Dim dt_entrega_prevista As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_entrega_prevista"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
                    Dim nr_quantidade_prevista As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_quantidade_prevista"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim nr_parcela As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_parcela"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                    Dim nr_quantidade_real As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_quantidade_real"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim dt_entrega_real As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_entrega_real"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)

                    entrega.dt_entrega_prevista = DateTime.Parse(dt_entrega_prevista.Text).ToString("dd/MM/yyyy")
                    entrega.nr_quantidade_prevista = Convert.ToDecimal(nr_quantidade_prevista.Text)
                    'fran chamado 608 i
                    'entrega.nr_parcela = Convert.ToDecimal(nr_parcela.Text)
                    If nr_parcela.Text.Equals(String.Empty) Then
                        entrega.nr_parcela = 0
                    Else
                        entrega.nr_parcela = Convert.ToInt32(nr_parcela.Text)
                    End If
                    'fran chamado 608 f

                    If Not dt_entrega_real.Text.Equals(String.Empty) Then
                        entrega.dt_entrega_real = DateTime.Parse(dt_entrega_real.Text).ToString("dd/MM/yyyy")
                    End If
                    If Not nr_quantidade_real.Text.Equals(String.Empty) Then
                        entrega.nr_quantidade_real = Convert.ToDecimal(nr_quantidade_real.Text)
                    End If


                    entrega.id_modificador = Session("id_login")
                    entrega.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item"))

                    'fran 14/02/2011 chamado 1170 i só deixa atualizar ou inserir se algum campo for diferente do banco
                    If entrega.getPedidoEntregaByFilters.Tables(0).Rows.Count = 0 Then
                        'fran 14/02/2011 chamado 1170 f
                        'Se é um novo item
                        If Not ViewState.Item("incluirlinhaentrega") Is Nothing Then
                            If ViewState.Item("incluirlinhaentrega") = "S" Then
                                entrega.insertPedidoCentralEntrega()
                                ViewState.Item("incluirlinhaentrega") = Nothing
                            Else
                                entrega.id_central_pedido_entrega = Convert.ToInt32(lbl_id_central_pedido_entrega.Text)
                                entrega.updatePedidoEntrega()
                            End If
                        Else
                            entrega.id_central_pedido_entrega = Convert.ToInt32(lbl_id_central_pedido_entrega.Text)
                            entrega.updatePedidoEntrega()
                        End If
                        'fran 14/02/2011 chamado 1170 i
                    Else
                        If Not ViewState.Item("incluirlinhaentrega") Is Nothing Then
                            If ViewState.Item("incluirlinhaentrega") = "S" Then
                                ViewState.Item("incluirlinhaentrega") = Nothing
                            End If
                        End If
                    End If
                    'fran 14/02/2011 chamado 1170 f

                    gridEntrega.EditIndex = -1

                    loadGridEntrega()

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub cv_pedido_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pedido.ServerValidate

        Try
            Dim lmsg As String
            Dim lvalid As Boolean
            Dim pedido As New Pedido
            Dim dspedido As DataSet
            Dim row As DataRow
            args.IsValid = True
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))


            If CInt(ViewState.Item("id_grupo")) <> 3 Then 'fran 30/07/2010 i chamado 682
                'Busca a somatoria das qtde previstas de ntrega de cada item do pedido
                dspedido = pedido.getCentralPedidoConsSomaQtdePrevista
                If dspedido.Tables(0).Rows.Count > 0 Then
                    For Each row In dspedido.Tables(0).Rows
                        'se a qtde do pedido subtraindo a soma da qtde prevista para o item for diferente de zero
                        If Convert.ToDecimal(row.Item("qtde")) <> 0 Then
                            args.IsValid = False
                            lmsg = "O somatório da 'Qtde Prevista' está diferente da quantidade informada para o item " & row.Item("nm_item").ToString & "."
                            Exit For
                        End If
                    Next
                Else
                    args.IsValid = False
                    lmsg = "A quantidade prevista para Entregas deve ser informada!"
                End If
            End If
            'fran chamado 945 i 25/08/2010 - não deve consistir o somatorio das prcelas com o valor total do item nem para fornecedor nem para produtor
            'If args.IsValid = True Then

            '    'Busca a somatoria do valor das parcelas  e subtrai peo valor total do item
            '    dspedido = pedido.getCentralPedidoConsSomaValorFornecedor
            '    If dspedido.Tables(0).Rows.Count > 0 Then
            '        For Each row In dspedido.Tables(0).Rows
            '            'se o valor total do item do pedido subtraindo a soma do valor da parcelas para o item for diferente de zero
            '            If Convert.ToDecimal(row.Item("valor")) <> 0 Then
            '                args.IsValid = False
            '                lmsg = "Para o item " & row.Item("nm_item").ToString & ", o somatório do valor das parcelas do 'Pagamento ao Fonecedor' está diferente do valor total informado no pedido."
            '                Exit For
            '            End If
            '        Next
            '    Else
            '        args.IsValid = False
            '        lmsg = "O valor das parcelas do Pagamento ao Fornecedor deve ser informado!"
            '    End If
            'End If
            'If CInt(ViewState.Item("id_grupo")) <> 3 Then 'se diferente de transportador 'fran 30/07/2010 i chamado 682

            '    If args.IsValid = True Then
            '        'Busca a somatoria do valor das parcelas  e subtrai peo valor total do item
            '        dspedido = pedido.getCentralPedidoConsSomaValorProdutor
            '        If dspedido.Tables(0).Rows.Count > 0 Then
            '            For Each row In dspedido.Tables(0).Rows
            '                'se o valor total do item do pedido subtraindo a soma do valor da parcelas para o item for diferente de zero
            '                If Convert.ToDecimal(row.Item("valor")) <> 0 Then
            '                    args.IsValid = False
            '                    lmsg = "Para o item " & row.Item("nm_item").ToString & ", o somatório do valor das parcelas do 'Desconto ao Produtor' está diferente do valor total informado no pedido."
            '                    Exit For
            '                End If
            '            Next
            '        Else
            '            args.IsValid = False
            '            lmsg = "O valor das parcelas do Desconto ao Produtor deve ser informado!"
            '        End If
            '    End If
            'End If
            'fran chamado 945 f
            If args.IsValid = True Then
                'Busca se existe data de pagamento repetidas 
                dspedido = pedido.getCentralPedidoConsDataFornecedor
                If dspedido.Tables(0).Rows.Count > 0 Then
                    'se tem linhas, tem datas repetias
                    For Each row In dspedido.Tables(0).Rows
                        args.IsValid = False
                        'lmsg = "As datas de pagamento para o 'Pagamento ao Fornecedor' do item " & row.Item("nm_item").ToString & " não podem ser repetidas." 'fran fase 3 set/2014
                        lmsg = "As datas de pagamento para o 'Pagamento ao Fornecedor' do item " & row.Item("nm_item").ToString & ", nr de nota " & row.Item("nr_nota_fiscal").ToString & " não podem ser repetidas." 'fran fase 3 set/2014
                        Exit For
                    Next
                End If
            End If
            'fran 25/08/2010 i chamado 946 - o pedido de transportador tb terá desconto ao produtor
            'If CInt(ViewState.Item("id_grupo")) <> 3 Then 'fran 30/07/2010 i chamado 682
            'fran 25/08/2010 f chamado 946 - o pedido de transportador tb terá desconto ao produtor

            'fran 10/03/2010 i chamado 686
            'fran fase 3 i 
            'If args.IsValid = True  Then
            If args.IsValid = True Then
                If ViewState.Item("ReabrirPedido") = "N" Then
                    If ViewState.Item("pedidoindireto") = "N" Then

                        'fran fase 3 f
                        'Busca a quantidade de  parcelas informadas em cotação e o count das parcelas informadas para pedido
                        dspedido = pedido.getCentralPedidoConsParcelas
                        If dspedido.Tables(0).Rows.Count > 0 Then
                            Dim lqtde_parcelas As Integer
                            Dim lnr_parcelas As Integer
                            Dim lnr_nota_fiscal As Int64
                            For Each row In dspedido.Tables(0).Rows
                                lqtde_parcelas = row.Item("qtde_parcelas")
                                lnr_parcelas = row.Item("nr_parcelas")
                                lnr_nota_fiscal = row.Item("nr_nota_fiscal")
                                'se parcela informada em cotacao é 0 (a vista) ou 1 parcela (á vista) e a qtde parcelas incluidas no grid for maior que 1
                                If (lnr_parcelas = 0 Or lnr_parcelas = 1) And lqtde_parcelas > 1 Then
                                    args.IsValid = False
                                    lmsg = "Para o item " & row.Item("nm_item").ToString & ", nota fiscal " & row.Item("nr_nota_fiscal").ToString & ", o parcelamento do Desconto ao Produtor deve ser feito em apenas 1 vez, conforme informado na Cotação."
                                    Exit For
                                End If
                                'assume que se veio parcelas = 0 significa que aomenos tem 1 parcela
                                If lnr_parcelas = 0 Then
                                    lnr_parcelas = 1
                                End If
                                'se a atde parcelas incluidas for maior que as parcelas informadas na cotação
                                If lqtde_parcelas > lnr_parcelas Then
                                    args.IsValid = False
                                    lmsg = "Para o item " & row.Item("nm_item").ToString & ", nota fiscal " & row.Item("nr_nota_fiscal").ToString & ", o parcelamento do Desconto ao Produtor deve ser no máximo de " & lnr_parcelas & " parcelas, conforme informado na Cotação."
                                    Exit For
                                End If
                            Next
                        Else

                            args.IsValid = False
                            lmsg = "Parcelas de desconto ao produtor devem ser informadas!"
                        End If
                    End If
                Else

                    'fran 08/2015 i
                    'Busca a quantidade de  parcelas informadas em cotação e o count das parcelas informadas para pedido
                    dspedido = pedido.getCentralPedidoConsParcelasbyItem
                    If dspedido.Tables(0).Rows.Count > 0 Then
                        Dim lqtde_parcelas As Integer
                        Dim lnr_parcelas As Integer
                        For Each row In dspedido.Tables(0).Rows
                            lqtde_parcelas = row.Item("qtde_parcelas")
                            lnr_parcelas = row.Item("nr_parcelas")
                            'se parcela informada em parcelamento é 0 (a vista) ou 1 parcela (á vista) e a qtde parcelas incluidas no grid for maior que 1
                            If (row.Item("st_parcelamento").Equals("N")) And lqtde_parcelas > 1 Then
                                args.IsValid = False
                                lmsg = "Para o item " & row.Item("nm_item").ToString & ", nota fiscal " & row.Item("nr_nota_fiscal").ToString & ", o parcelamento do Desconto ao Produtor deve ser feito em apenas 1 vez, conforme informado no campo Parcelamento. Caso necessário, altere o campo parcelamento e clique em 'Atualizar Parcelamento'."
                                Exit For
                            End If
                        Next
                    Else

                        args.IsValid = False
                        lmsg = "Parcelas de desconto ao produtor devem ser informadas!"
                    End If


                    'fase 3 09/2014 i 
                    'Se esta reabrindo pedido.... Deixa aumentar ou retirar parcelas.... contanto que o valor da nota bata com total
                    'Porém se parcelamento for DANONE, deve respoeitar total de parcelas informada no parametro 
                    dspedido = pedido.getCentralPedidoTotalParcelasByPedido 'Busca da VIEWTOTALPARCELAS o total de parcelas por ITEM
                    If dspedido.Tables(0).Rows.Count > 0 Then
                        'rever fran 2023
                        ' ''For Each row In dspedido.Tables(0).Rows
                        ' ''    'se o parcelamento do item é DANONE, deve respeitar o limite de parcelas do parametro
                        ' ''    If row.Item("st_parcelamento").ToString.Equals("D") Then
                        ' ''        If CInt(row.Item("nr_total_parcela").ToString) > CInt(ViewState.Item("nr_politica_parcelas").ToString) Then
                        ' ''            args.IsValid = False
                        ' ''            lmsg = "Para o item " & row.Item("nm_item").ToString & ", nota fiscal " & row.Item("nr_nota_fiscal").ToString & ", o parcelamento do Desconto ao Produtor deve ser no máximo de " & ViewState.Item("nr_politica_parcelas").ToString & " parcelas, de acordo com a Política de Parcelas para Danone."
                        ' ''            Exit For
                        ' ''        End If
                        ' ''    End If
                        ' ''Next
                    Else
                        args.IsValid = False
                        lmsg = "Parcelas de desconto ao produtor devem ser informadas!"
                    End If
                    'fase 3 09/2014 f 
                End If
            End If
            'fran 10/03/2010 f
            If args.IsValid = True And ViewState.Item("pedidoindireto") = "N" Then 'fase 3
                'Busca se existe data de pagamento repetidas 
                dspedido = pedido.getCentralPedidoConsDataProdutor
                If dspedido.Tables(0).Rows.Count > 0 Then
                    'se tem linhas, tem datas repetias
                    For Each row In dspedido.Tables(0).Rows
                        args.IsValid = False
                        'lmsg = "As datas de pagamento para o 'Desconto ao Produtor' do item " & row.Item("nm_item").ToString & " não podem ser repetidas." 'fran fase 3 set/2014
                        lmsg = "As datas de pagamento para o 'Desconto ao Produtor' do item " & row.Item("nm_item").ToString & ", nr de nota " & row.Item("nr_nota_fiscal").ToString & " não podem ser repetidas." 'fran fase 3 set/2014
                        Exit For
                    Next
                End If
            End If
            'End If 'fran 25/08/2010 i chamado 946 - o pedido de transportador tb terá desconto ao produtor
            'fran 10/05/2010 i chamado 817
            If args.IsValid = True Then
                'Verifica se há o mesmo nr nota com valores diferentes
                dspedido = pedido.getCentralPedidoConsNotaVlDiferenteFornec
                If dspedido.Tables(0).Rows.Count > 0 Then
                    'se tem linhas, tem notas com valores diferentes
                    For Each row In dspedido.Tables(0).Rows
                        args.IsValid = False
                        'lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " a nota de número ", row.Item("nr_nota_fiscal").ToString, " não pode ter o campo 'Vl Nota' com valores diferentes.")
                        lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " do Pagamento ao Fornecedor, a nota de número ", row.Item("nr_nota_fiscal").ToString, " não pode ter o campo 'Vl Nota' com valores diferentes.")
                        Exit For
                    Next
                End If
            End If
            If args.IsValid = True Then
                'Verifica se há o mesmo nr nota com valores diferentes
                dspedido = pedido.getCentralPedidoConsNotaSerieEmissaoFornec
                If dspedido.Tables(0).Rows.Count > 0 Then
                    'se tem linhas, tem notas com valores diferentes
                    For Each row In dspedido.Tables(0).Rows
                        If CInt(row.Item("count_serie")) > 1 Then
                            args.IsValid = False
                            lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " do Pagamento ao Fornecedor, a nota de número ", row.Item("nr_nota_fiscal").ToString, " não pode ter o campo 'Série' com valores diferentes.")
                            Exit For
                        End If
                        If CInt(row.Item("count_data")) > 1 Then
                            args.IsValid = False
                            lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " do Pagamento ao Fornecedor, a nota de número ", row.Item("nr_nota_fiscal").ToString, " não pode ter o campo 'Emissão' com valores diferentes.")
                            Exit For
                        End If
                    Next
                End If
            End If
            If args.IsValid = True Then
                'Verifica se a soma das parcelas para um nr nota é igual ao vl da nota
                dspedido = pedido.getCentralPedidoConsSomaParcComVlNotaFornec
                If dspedido.Tables(0).Rows.Count > 0 Then
                    For Each row In dspedido.Tables(0).Rows
                        If row.Item("valor_nota_fiscal") > 0 Then
                            If row.Item("valor") <> 0 Then 'se tem diferença
                                args.IsValid = False
                                'lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " o somatório das parcelas da nota ", row.Item("nr_nota_fiscal").ToString, " está diferente do Valor da Nota Fiscal informado.")
                                lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " do Pagamento ao Fornecedor, o somatório das parcelas da nota ", row.Item("nr_nota_fiscal").ToString, " está diferente do Valor da Nota Fiscal informado.")
                                Exit For

                            End If
                        End If
                    Next
                Else
                    'fran -8/2015i
                    'se não tem linhas de fornecedor
                    args.IsValid = False
                    lmsg = String.Concat("Para finalizar o pedido, Pagamento ao Fornecedor deve ser informado!")

                    'fran -8/2015f

                End If
            End If
            'fran 10/05/2010 f chamado 817

            'fran 25/08/2010 i chamado 945
            If args.IsValid = True And ViewState.Item("pedidoindireto") = "N" Then
                'Verifica se há o mesmo nr nota com valores diferentes
                dspedido = pedido.getCentralPedidoConsNotaVlDiferenteProdutor
                If dspedido.Tables(0).Rows.Count > 0 Then
                    'se tem linhas, tem notas com valores diferentes
                    For Each row In dspedido.Tables(0).Rows
                        args.IsValid = False
                        lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " do Desconto ao Produtor, a nota de número ", row.Item("nr_nota_fiscal").ToString, " não pode ter o campo 'Vl Nota' com valores diferentes.")
                        Exit For
                    Next
                End If
            End If
            If args.IsValid = True And ViewState.Item("pedidoindireto") = "N" Then
                'Verifica se a soma das parcelas para um nr nota é igual ao vl da nota
                dspedido = pedido.getCentralPedidoConsSomaParcComVlNotaProdutor
                If dspedido.Tables(0).Rows.Count > 0 Then
                    For Each row In dspedido.Tables(0).Rows
                        If row.Item("valor_nota_fiscal") > 0 Then
                            If row.Item("valor") <> 0 Then 'se tem diferença
                                args.IsValid = False
                                lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " do Desconto ao Produtor, o somatório das parcelas da nota ", row.Item("nr_nota_fiscal").ToString, " está diferente do Valor da Nota Fiscal informado.")
                                Exit For

                            End If
                        End If
                    Next
                End If
            End If
            'fran 25/08/2010 f chamado 945

            'fran 08/2015 i
            If args.IsValid = True And ViewState.Item("pedidoindireto") = "N" Then 'fase 3
                'Verifica se o nr nota existe nos dois grids fornecedor e produtor 
                dspedido = pedido.getCentralPedidoConsNrNotaFornecProd
                If dspedido.Tables(0).Rows.Count > 0 Then
                    For Each row In dspedido.Tables(0).Rows
                        args.IsValid = False
                        lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " os mesmos números de Nota Fiscal devem ser informados para Desconto ao Produtor e Pagamento ao Fornecedor.")
                        Exit For
                    Next
                End If
            End If

            If args.IsValid = True And ViewState.Item("pedidoindireto") = "N" Then 'fase 3
                'Verifica se o valor nota é o mesmo para dois grids fornecedor e produtor 
                dspedido = pedido.getCentralPedidoConsValorNotaFornecProd
                If dspedido.Tables(0).Rows.Count > 0 Then
                    For Each row In dspedido.Tables(0).Rows
                        args.IsValid = False
                        lmsg = String.Concat("Para o item " & row.Item("nm_item").ToString, " o valor da Nota Fiscal " & row.Item("nr_nota_fiscal").ToString, " está divergente entre Desconto ao Produtor e Pagamento ao Fornecedor.")
                        Exit For
                    Next
                End If
            End If

            'fran 08/2015 f


            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub lk_email_produtor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email_produtor.Click
        Dim lassunto As String
        Dim lcorpo As String
        Dim arqTemp As StreamReader
        Dim lcaminhoservidor As String = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString()  ' Na Danone os relatórios ficam aonde estãqo as páginas
        'Dim lcaminhoservidor As String = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()
        Dim propriedade As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade").ToString))
        Dim produtor As New Pessoa(Convert.ToInt32(ViewState.Item("id_produtor").ToString))
        Dim fornecedor As New Pessoa(Convert.ToInt32(ViewState.Item("id_fornecedor").ToString))
        Dim lemail_parceiro As String
        Dim ldatahj As Date = DateTime.Parse(Now).ToString("dd/MM/yyyy")

        lemail_parceiro = produtor.ds_email
        If lemail_parceiro.Equals(String.Empty) Then
            If Not produtor.ds_email2 Is Nothing Then
                lemail_parceiro = produtor.ds_email2
            Else
                lemail_parceiro = String.Empty

            End If
        End If
        'lemail_parceiro = "franoliveira@hotmail.com"
        If Not lemail_parceiro.Equals(String.Empty) Then
            lassunto = String.Concat("DANONE - Pedido de Compra ", "Nr ", lbl_id_central_pedido.Text)
            arqTemp = New StreamReader(lcaminhoservidor & "\central_pedido_email_produtor.HTML", Encoding.UTF7)
            lcorpo = ""
            Do While Not arqTemp.EndOfStream
                lcorpo = lcorpo & arqTemp.ReadLine
            Loop

            lcorpo = Replace(lcorpo, "$nm_estabelecimento", ViewState.Item("nm_estabelecimento").ToString)
            lcorpo = Replace(lcorpo, "$dt_hoje", String.Concat(Format(ldatahj, "dd").ToString, " de ", Format(ldatahj, "MMMM").ToString, " de ", Format(ldatahj, "yyyy").ToString & "."))
            lcorpo = Replace(lcorpo, "$id_pedido", ViewState.Item("id_central_pedido").ToString)
            lcorpo = Replace(lcorpo, "$datapedido", lbl_dt_pedido.Text)
            'fran 04/08/2010 i chamado 918
            lcorpo = Replace(lcorpo, "$nm_parceiro", fornecedor.nm_pessoa)
            'fran 04/08/2010 f chamado 918

            'lcorpo = Replace(lcorpo, "$nm_fornecedor", fornecedor.nm_pessoa)
            'lcorpo = Replace(lcorpo, "$ds_fornec_contato", fornecedor.ds_contato)
            'lcorpo = Replace(lcorpo, "$email", fornecedor.ds_email)
            'lcorpo = Replace(lcorpo, "$fone1", fornecedor.ds_telefone_1)
            'lcorpo = Replace(lcorpo, "$fone2", fornecedor.ds_telefone_2)

            lcorpo = Replace(lcorpo, "$nm_produtor", produtor.nm_pessoa)
            lcorpo = Replace(lcorpo, "$cd_produtor", produtor.cd_pessoa)
            lcorpo = Replace(lcorpo, "$nm_propriedade", propriedade.nm_propriedade)
            lcorpo = Replace(lcorpo, "$id_propriedade", propriedade.id_propriedade)
            'lcorpo = Replace(lcorpo, "$nr_unid_producao", lbl_limite_disponivel.Text.ToString)
            lcorpo = Replace(lcorpo, "$bairro_produtor", produtor.ds_bairro)
            lcorpo = Replace(lcorpo, "$cidade_produtor", produtor.nm_cidade)
            lcorpo = Replace(lcorpo, "$nm_estado_produtor", produtor.nm_estado)
            If produtor.st_categoria = "F" Then
                lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cpf)
            Else
                lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cnpj)
            End If
            lcorpo = Replace(lcorpo, "$inscrestadualprodutor", produtor.cd_inscricao_estadual)
            lcorpo = Replace(lcorpo, "$ds_contato", produtor.ds_contato)
            lcorpo = Replace(lcorpo, "$prodfone3", produtor.ds_telefone_1)
            lcorpo = Replace(lcorpo, "$prodfone4", produtor.ds_telefone_2)

            If lbl_tipo_frete.Text = "CIF" Then
                lcorpo = Replace(lcorpo, "$tipofrete", "CIF - Entregue na Fazenda")
            Else
                If lbl_tipo_frete.Text = "FOB-I" Then
                    lcorpo = Replace(lcorpo, "$tipofrete", "FOB - A Retirar (responsabilidade do produtor)")
                Else
                    lcorpo = Replace(lcorpo, "$tipofrete", "FOB - A Retirar (Transportador Danone)")
                End If
            End If

            If ViewState.Item("st_parcelamento") = "N" OrElse ViewState.Item("nr_parcelas").ToString = "0" OrElse ViewState.Item("nr_parcelas").ToString = "1" Then
                lcorpo = Replace(lcorpo, "$tipopagamento", "À Vista.")
            Else
                If ViewState.Item("st_parcelamento") = "P" Then
                    lcorpo = Replace(lcorpo, "$tipopagamento", String.Concat("Parcelado em ", ViewState.Item("nr_parcelas").ToString, " X pelo Parceiro."))
                Else
                    lcorpo = Replace(lcorpo, "$tipopagamento", String.Concat("Parcelado em ", ViewState.Item("nr_parcelas").ToString, " X pela Danone."))
                End If
            End If
            Dim pedido As New Pedido
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
            Dim dsgrid As DataSet = pedido.getCentralPedidoEmailParceiroItens()
            Dim row As DataRow
            Dim ltable As String = String.Empty
            Dim lassuntoaux As String = String.Empty
            Dim i As Integer = 1
            For Each row In dsgrid.Tables(0).Rows
                ltable = "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td style='width: 27px; font-weight: bold; height: 17px;'>2." & i.ToString & ".</td>"
                ltable = ltable & "<td colspan='6' style='font-weight: bold; height: 17px'>" & row.Item("nm_item").ToString & "</td>"
                ltable = ltable & "</tr>"

                lassuntoaux = String.Concat(row.Item("nm_item").ToString, " - ", Left(fornecedor.nm_abreviado.ToString, 20))

                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style=' height: 17px;'>Quantidade:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & CInt(row.Item("nr_quantidade")).ToString & " " & row.Item("nm_unidade_medida").ToString & "</td>"
                ltable = ltable & "</tr>"
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Embalagem:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & row.Item("ds_tipo_medida").ToString & "</td>"
                ltable = ltable & "</tr>"
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Unitário:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_valor_unitario"), 2).ToString & "</td>"
                ltable = ltable & "</tr>"
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Sacaria:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_sacaria"), 2).ToString & "</td>"
                ltable = ltable & "</tr>"
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Frete:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_frete"), 2).ToString & "</td>"
                ltable = ltable & "</tr>"
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Valor Total:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_valor_total_insumo_frete"), 2).ToString & "</td>"
                ltable = ltable & "</tr>"
                ltable = ltable & "<tr><td style='width: 20px; height: 15px;'>&nbsp;</td><td style='width: 27px; height: 15px;'>&nbsp;</td><td colspan='2' style='height: 15px'>&nbsp;</td><td colspan='4' style='height: 15px'>&nbsp;</td></tr>"
                'ltable = ltable & "<tr><td style='width: 20px; height: 17px'>&nbsp;</td><td style='width: 27px; height: 17px'>&nbsp;</td>"
                'ltable = ltable & "<td style='width: 32px; height: 17px; font-weight: bold;'>2." & i.ToString & ".1</td>"
                'ltable = ltable & "<td colspan='5' style='height: 17px; font-weight: bold;'>Entregas Programadas</td>"
                'ltable = ltable & "</tr>"

                'Dim pedidoentrega As New PedidoEntrega
                'pedidoentrega.id_central_pedido_item = Convert.ToInt32(row.Item("id_central_pedido_item"))
                'Dim dsentrega As DataSet = pedidoentrega.getPedidoEntregaByFilters
                'Dim rows As DataRow
                'Dim j As Integer = 1
                'For Each rows In dsentrega.Tables(0).Rows
                '    ltable = ltable & "<tr><td style='width: 20px; height: 17px'>&nbsp;</td><td style='width: 27px; height: 17px'>&nbsp;</td>"
                '    ltable = ltable & "<td style='width: 35px; height: 17px'>&nbsp;</td><td style='width: 42px; height: 17px'>2." & i.ToString & ".1." & j.ToString & "</td>"
                '    ltable = ltable & "<td colspan='2' style='width: 61px; height: 17px'>Entrega " & j.ToString & ":</td>"
                '    ltable = ltable & "<td colspan='2' style='height: 17px'>"
                '    ltable = ltable & DateTime.Parse(rows.Item("dt_entrega_prevista").ToString).ToString("dd/MM/yyyy") & " - " & rows.Item("nr_quantidade_prevista").ToString & " " & row.Item("nm_unidade_medida").ToString & "</td>"
                '    ltable = ltable & "</tr>"
                '    j = j + 1
                'Next
                'lcorpo = Replace(lcorpo, "$itens", i.ToString)
                i = i + 1
            Next

            'Dim dspagto As DataSet = pedido.getCentralPedidoEmailProdutorPagto
            'Dim lpagtoprod As String = String.Empty
            'i = 1
            'For Each row In dspagto.Tables(0).Rows
            '    lpagtoprod = lpagtoprod & "<tr><td style='width: 20px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
            '    lpagtoprod = lpagtoprod & "<td style='width: 35px; '>3.1." & i.ToString & "</td>"
            '    lpagtoprod = lpagtoprod & "<td colspan='2' >Parcela " & i.ToString & ":</td>"
            '    'fran 9/12/2010 i
            '    'lpagtoprod = lpagtoprod & "<td colspan='3' >" & row.Item("dt_pagto").ToString & " - Valor " & CStr(FormatCurrency(row.Item("nr_valor_parcela").ToString, 2, , TriState.False)) & "</td>"
            '    lpagtoprod = lpagtoprod & "<td colspan='3' >Pagto " & row.Item("dt_pagto").ToString & " - Valor " & CStr(FormatCurrency(row.Item("nr_valor_parcela").ToString, 2, , TriState.False)) & "</td>"
            '    'fran 9/12/2010 f
            '    lpagtoprod = lpagtoprod & "</tr>"
            '    i = i + 1
            'Next


            lcorpo = Replace(lcorpo, "$dsgriditens", ltable.ToString)
            'lcorpo = Replace(lcorpo, "$dspagtoprodutor", lpagtoprod.ToString)
            lcorpo = Replace(lcorpo, "ecxtextosmall", "textosmall")

            lassunto = lassunto & " - " & lassuntoaux

            Dim notificacao As New Notificacao
            arqTemp.Close()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 9 'ENVIO EMAIL
            usuariolog.id_menu_item = 97
            usuariolog.id_nr_processo = lbl_id_central_pedido.Text
            usuariolog.nm_nr_processo = lbl_id_central_pedido.Text
            usuariolog.ds_nm_processo = "Pedidos - E-mail Produtor"
            usuariolog.insertUsuarioLog()
            'fran 08/12/2020 f

            'fran 24/08/2010 i chamado 931
            'If notificacao.enviaMensagemEmail(lassunto, lcorpo, "recepcao.de.leite-pocos@danone.com", lemail_parceiro, , MailPriority.High, True) = True Then
            If notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, , MailPriority.High, True, , False) = True Then
                'fran 24/08/2010 f chamado 931

                messageControl.Alert("Email enviado ao produtor com sucesso!")
            Else

                messageControl.Alert("Email ao produtor não foi enviado com sucesso!")

            End If
        Else
            messageControl.Alert("O email não pode ser enviado pois não há nenhum email informado no cadastro do Produtor!")
        End If
    End Sub
    'Protected Sub lk_email_produtor_contrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email_produtor.Click
    '    Dim lassunto As String
    '    Dim lcorpo As String
    '    Dim arqTemp As StreamReader
    '    Dim lcaminhoservidor As String = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString()  ' Na Danone os relatórios ficam aonde estãqo as páginas
    '    'Dim lcaminhoservidor As String = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()
    '    Dim propriedade As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade").ToString))
    '    Dim produtor As New Pessoa(Convert.ToInt32(ViewState.Item("id_produtor").ToString))
    '    Dim fornecedor As New Pessoa(Convert.ToInt32(ViewState.Item("id_fornecedor").ToString))
    '    Dim lemail_parceiro As String
    '    Dim ldatahj As Date = DateTime.Parse(Now).ToString("dd/MM/yyyy")

    '    lemail_parceiro = produtor.ds_email
    '    If lemail_parceiro.Equals(String.Empty) Then
    '        If Not produtor.ds_email2 Is Nothing Then
    '            lemail_parceiro = produtor.ds_email2
    '        Else
    '            lemail_parceiro = String.Empty

    '        End If
    '    End If
    '    'lemail_parceiro = "franoliveira@hotmail.com"
    '    If Not lemail_parceiro.Equals(String.Empty) Then
    '        lassunto = String.Concat("DANONE - Pedido de Compra Contrato ")
    '        arqTemp = New StreamReader(lcaminhoservidor & "\central_pedido_email_produtor_contrato.HTML", Encoding.UTF7)
    '        lcorpo = ""
    '        Do While Not arqTemp.EndOfStream
    '            lcorpo = lcorpo & arqTemp.ReadLine
    '        Loop

    '        lcorpo = Replace(lcorpo, "$nm_estabelecimento", ViewState.Item("nm_estabelecimento").ToString)
    '        lcorpo = Replace(lcorpo, "$dt_hoje", String.Concat(Format(ldatahj, "dd").ToString, " de ", Format(ldatahj, "MMMM").ToString, " de ", Format(ldatahj, "yyyy").ToString & "."))
    '        lcorpo = Replace(lcorpo, "$id_pedido", ViewState.Item("id_central_pedido").ToString)
    '        lcorpo = Replace(lcorpo, "$datapedido", lbl_dt_pedido.Text)
    '        'fran 04/08/2010 i chamado 918
    '        lcorpo = Replace(lcorpo, "$nm_parceiro", fornecedor.nm_pessoa)
    '        'fran 04/08/2010 f chamado 918

    '        'lcorpo = Replace(lcorpo, "$nm_fornecedor", fornecedor.nm_pessoa)
    '        'lcorpo = Replace(lcorpo, "$ds_fornec_contato", fornecedor.ds_contato)
    '        'lcorpo = Replace(lcorpo, "$email", fornecedor.ds_email)
    '        'lcorpo = Replace(lcorpo, "$fone1", fornecedor.ds_telefone_1)
    '        'lcorpo = Replace(lcorpo, "$fone2", fornecedor.ds_telefone_2)

    '        lcorpo = Replace(lcorpo, "$nm_produtor", produtor.nm_pessoa)
    '        lcorpo = Replace(lcorpo, "$cd_produtor", produtor.cd_pessoa)
    '        lcorpo = Replace(lcorpo, "$nm_propriedade", propriedade.nm_propriedade)
    '        lcorpo = Replace(lcorpo, "$id_propriedade", propriedade.id_propriedade)
    '        lcorpo = Replace(lcorpo, "$nr_unid_producao", lbl_limite_disponivel.Text.ToString)
    '        lcorpo = Replace(lcorpo, "$bairro_produtor", produtor.ds_bairro)
    '        lcorpo = Replace(lcorpo, "$cidade_produtor", produtor.nm_cidade)
    '        lcorpo = Replace(lcorpo, "$nm_estado_produtor", produtor.nm_estado)
    '        If produtor.st_categoria = "F" Then
    '            lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cpf)
    '        Else
    '            lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cnpj)
    '        End If
    '        lcorpo = Replace(lcorpo, "$inscrestadualprodutor", produtor.cd_inscricao_estadual)
    '        lcorpo = Replace(lcorpo, "$ds_contato", produtor.ds_contato)
    '        lcorpo = Replace(lcorpo, "$prodfone3", produtor.ds_telefone_1)
    '        lcorpo = Replace(lcorpo, "$prodfone4", produtor.ds_telefone_2)


    '        Dim pedido As New Pedido
    '        pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
    '        Dim dsgrid As DataSet = pedido.getCentralPedidoEmailParceiroItens()
    '        Dim row As DataRow
    '        Dim ltable As String = String.Empty
    '        Dim i As Integer = 1
    '        For Each row In dsgrid.Tables(0).Rows
    '            ltable = "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td>"
    '            ltable = ltable & "<td style='width: 27px; font-weight: bold; height: 17px;'>2." & i.ToString & ".</td>"
    '            ltable = ltable & "<td colspan='6' style='font-weight: bold; height: 17px'>" & row.Item("nm_item").ToString & "</td>"
    '            ltable = ltable & "</tr>"

    '            ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
    '            ltable = ltable & "<td colspan='2' style=' height: 17px;'>Quantidade:</td>"
    '            ltable = ltable & "<td colspan='4' style='height: 17px'>" & CInt(row.Item("nr_quantidade")).ToString & " " & row.Item("nm_unidade_medida").ToString & "</td>"
    '            ltable = ltable & "</tr>"
    '            ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
    '            ltable = ltable & "<td colspan='2' style='height: 17px'>Embalagem:</td>"
    '            ltable = ltable & "<td colspan='4' style='height: 17px'>" & row.Item("ds_tipo_medida").ToString & "</td>"
    '            ltable = ltable & "</tr>"
    '            ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
    '            ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Unitário:</td>"
    '            ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_valor_unitario"), 2).ToString & "</td>"
    '            ltable = ltable & "</tr>"
    '            ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
    '            ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Sacaria:</td>"
    '            ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_sacaria"), 2).ToString & "</td>"
    '            ltable = ltable & "</tr>"
    '            ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
    '            ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Frete:</td>"
    '            ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_frete"), 2).ToString & "</td>"
    '            ltable = ltable & "</tr>"
    '            ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
    '            ltable = ltable & "<td colspan='2' style='height: 17px'>Valor Total:</td>"
    '            ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_valor_total"), 2).ToString & "</td>"
    '            ltable = ltable & "</tr>"
    '            ltable = ltable & "<tr><td style='width: 20px; height: 15px;'>&nbsp;</td><td style='width: 27px; height: 15px;'>&nbsp;</td><td colspan='2' style='height: 15px'>&nbsp;</td><td colspan='4' style='height: 15px'>&nbsp;</td></tr>"
    '            ltable = ltable & "<tr><td style='width: 20px; height: 17px'>&nbsp;</td><td style='width: 27px; height: 17px'>&nbsp;</td>"
    '            ltable = ltable & "<td style='width: 32px; height: 17px; font-weight: bold;'>2." & i.ToString & ".1</td>"
    '            ltable = ltable & "<td colspan='5' style='height: 17px; font-weight: bold;'>Entregas Programadas</td>"
    '            ltable = ltable & "</tr>"

    '            Dim pedidoentrega As New PedidoEntrega
    '            pedidoentrega.id_central_pedido_item = Convert.ToInt32(row.Item("id_central_pedido_item"))
    '            Dim dsentrega As DataSet = pedidoentrega.getPedidoEntregaByFilters
    '            Dim rows As DataRow
    '            Dim j As Integer = 1
    '            For Each rows In dsentrega.Tables(0).Rows
    '                ltable = ltable & "<tr><td style='width: 20px; height: 17px'>&nbsp;</td><td style='width: 27px; height: 17px'>&nbsp;</td>"
    '                ltable = ltable & "<td style='width: 35px; height: 17px'>&nbsp;</td><td style='width: 42px; height: 17px'>2." & i.ToString & ".1." & j.ToString & "</td>"
    '                ltable = ltable & "<td colspan='2' style='width: 61px; height: 17px'>Entrega " & j.ToString & ":</td>"
    '                ltable = ltable & "<td colspan='2' style='height: 17px'>"
    '                ltable = ltable & DateTime.Parse(rows.Item("dt_entrega_prevista").ToString).ToString("dd/MM/yyyy") & " - " & rows.Item("nr_quantidade_prevista").ToString & " " & row.Item("nm_unidade_medida").ToString & "</td>"
    '                ltable = ltable & "</tr>"
    '                j = j + 1
    '            Next
    '            'lcorpo = Replace(lcorpo, "$itens", i.ToString)
    '            i = i + 1
    '        Next




    '        Dim dspagto As DataSet = pedido.getCentralPedidoEmailProdutorPagto
    '        Dim lpagtoprod As String = String.Empty
    '        i = 1
    '        For Each row In dspagto.Tables(0).Rows
    '            lpagtoprod = lpagtoprod & "<tr><td style='width: 20px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
    '            lpagtoprod = lpagtoprod & "<td colspan='3' style=' text-align: center;'>dt_referencia" & i.ToString & "</td>"
    '            lpagtoprod = lpagtoprod & "<td colspan='5' >qtde " & i.ToString & ":</td>"
    '            'fran 9/12/2010 i
    '            'lpagtoprod = lpagtoprod & "<td colspan='3' >" & row.Item("dt_pagto").ToString & " - Valor " & CStr(FormatCurrency(row.Item("nr_valor_parcela").ToString, 2, , TriState.False)) & "</td>"
    '            lpagtoprod = lpagtoprod & "<td colspan='3' >Pagto " & row.Item("dt_pagto").ToString & " - Valor " & CStr(FormatCurrency(row.Item("nr_valor_parcela").ToString, 2, , TriState.False)) & "</td>"
    '            'fran 9/12/2010 f
    '            lpagtoprod = lpagtoprod & "</tr>"
    '            i = i + 1
    '        Next


    '        lcorpo = Replace(lcorpo, "$dsgriditens", ltable.ToString)
    '        lcorpo = Replace(lcorpo, "$dspagtoprodutor", lpagtoprod.ToString)
    '        lcorpo = Replace(lcorpo, "ecxtextosmall", "textosmall")

    '        Dim notificacao As New Notificacao
    '        arqTemp.Close()

    '        'FRAN 08/12/2020 i incluir log 
    '        Dim usuariolog As New UsuarioLog
    '        usuariolog.id_usuario = Session("id_login")
    '        usuariolog.ds_id_session = Session.SessionID.ToString()
    '        usuariolog.id_tipo_log = 9 'ENVIO EMAIL
    '        usuariolog.id_menu_item = 97
    '        usuariolog.id_nr_processo = lbl_id_central_pedido.Text
    '        usuariolog.nm_nr_processo = lbl_id_central_pedido.Text
    '        usuariolog.ds_nm_processo = "Pedidos - E-mail Produtor"
    '        usuariolog.insertUsuarioLog()
    '        'fran 08/12/2020 f

    '        'fran 24/08/2010 i chamado 931
    '        'If notificacao.enviaMensagemEmail(lassunto, lcorpo, "recepcao.de.leite-pocos@danone.com", lemail_parceiro, , MailPriority.High, True) = True Then
    '        If notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, , MailPriority.High, True, , False) = True Then
    '            'fran 24/08/2010 f chamado 931

    '            messageControl.Alert("Email enviado ao produtor com sucesso!")
    '        Else

    '            messageControl.Alert("Email ao produtor não foi enviado com sucesso!")

    '        End If
    '    Else
    '        messageControl.Alert("O email não pode ser enviado pois não há nenhum email informado no cadastra do Produtor!")
    '    End If
    'End Sub

    Protected Sub cv_datapagto_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try

            args.IsValid = True
            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim txt_dt_pagto As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_pagto"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)

            'se a data de pagamento for menor que a data do pedido menos 1 mes
            If Convert.ToDateTime(txt_dt_pagto.Text) < DateAdd(DateInterval.Month, -1, Convert.ToDateTime(lbl_dt_pedido.Text)) Then
                args.IsValid = False
            Else
                args.IsValid = True
            End If

            If Not args.IsValid Then
                messageControl.Alert("A data de pagamento do Pagamento ao Fornecedor não pode ser anterior à Data de Pedido menos 1 mês.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub cv_datapagtoprod_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try

            args.IsValid = True
            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim txt_dt_pagto As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_pagto"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)

            'se a data de pagamento for menor que a data do pedido menos 1 mes
            If Convert.ToDateTime(txt_dt_pagto.Text) < DateAdd(DateInterval.Month, -1, Convert.ToDateTime(lbl_dt_pedido.Text)) Then
                args.IsValid = False
            Else
                args.IsValid = True
            End If

            If Not args.IsValid Then
                messageControl.Alert("A data de pagamento do Desconto ao Produtor não pode ser anterior à Data de Pedido menos 1 mês.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub btn_adicionar_obs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar_obs.Click
        ViewState.Item("incluirlinha") = "S"
        Dim obs As New PedidoObservacao
        obs.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
        obs.id_situacao = 1
        Dim dsobs As DataSet = obs.getPedidoObservacaoByFilters()
        Dim dr As DataRow = dsobs.Tables(0).NewRow()
        dr.Item("dt_criacao") = DateTime.Parse(Now).ToString("dd/MM/yyyy")
        dsobs.Tables(0).Rows.InsertAt(dr, 0)
        ViewState.Item("incluirlinhaobs") = "S"
        gridObs.Visible = True
        gridObs.DataSource = Helper.getDataView(dsobs.Tables(0), "dt_criacao")
        gridObs.EditIndex = 0
        gridObs.DataBind()
        ViewState.Item("incluirlinha") = Nothing

    End Sub
    Protected Sub gridObs_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridObs.PageIndexChanging
        gridObs.PageIndex = e.NewPageIndex
        loadData()
    End Sub
    Protected Sub gridObs_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridObs.RowCancelingEdit
        Try

            gridObs.EditIndex = -1
            ViewState.Item("incluirlinhaobs") = "N"
            ViewState.Item("incluirlinhaobs") = Nothing
            loadGridObservacao()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub gridObs_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridObs.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "delete"
                deletePedidoObservacao(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select
    End Sub
    Protected Sub gridObs_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridObs.RowCreated

    End Sub
    Protected Sub gridObs_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridObs.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try

                Dim dt_criacao As Label = CType(e.Row.FindControl("lbl_dt_criacao"), Label)

                If Not dt_criacao.Text.Equals(String.Empty) Then
                    dt_criacao.Text = DateTime.Parse(dt_criacao.Text).ToString("dd/MM/yyyy")
                Else
                    dt_criacao.Text = String.Empty
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        Else
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim dt_criacao As Label = CType(e.Row.FindControl("lbl_dt_criacao"), Label)
                If Not dt_criacao.Text.Equals(String.Empty) Then
                    dt_criacao.Text = DateTime.Parse(dt_criacao.Text).ToString("dd/MM/yyyy")
                End If

            End If
        End If

    End Sub
    Protected Sub gridObs_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridObs.RowDeleting
        e.Cancel = True

    End Sub
    Protected Sub gridObs_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridObs.RowEditing
        Try
            If ViewState.Item("incluirlinha") = "S" And e.NewEditIndex = 0 Then
                ViewState.Item("incluirlinha") = "S"
                loadGridObservacao()
            Else
                gridObs.EditIndex = e.NewEditIndex
                loadGridObservacao()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub gridObs_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridObs.RowUpdating
        Dim row As GridViewRow = gridObs.Rows(e.RowIndex)
        Try
            If Page.IsValid Then


                If (Not (row) Is Nothing) Then

                    Dim obs As New PedidoObservacao

                    Dim lbl_id_central_pedido_observacao As Label = CType(row.FindControl("lbl_id_central_pedido_observacao"), Label)

                    Dim txt_ds_observacao As TextBox = CType(row.FindControl("txt_ds_observacao"), TextBox)

                    obs.id_modificador = Session("id_login")
                    obs.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
                    obs.ds_observacao = txt_ds_observacao.Text

                    ' só deixa atualizar ou inserir se algum campo for diferente do banco
                    If obs.getPedidoObservacaoByFilters.Tables(0).Rows.Count = 0 Then
                        'Se é um novo item
                        If Not ViewState.Item("incluirlinhaobs") Is Nothing Then
                            If ViewState.Item("incluirlinhaobs") = "S" Then
                                obs.insertPedidoCentralObservacao()
                                ViewState.Item("incluirlinhaobs") = Nothing
                            Else
                                obs.id_central_pedido_observacao = Convert.ToInt32(lbl_id_central_pedido_observacao.Text)
                                obs.updatePedidoObservacao()
                            End If
                        Else
                            obs.id_central_pedido_observacao = Convert.ToInt32(lbl_id_central_pedido_observacao.Text)
                            obs.updatePedidoObservacao()
                        End If

                    Else
                        If Not ViewState.Item("incluirlinhaobs") Is Nothing Then
                            If ViewState.Item("incluirlinhaobs") = "S" Then
                                ViewState.Item("incluirlinhaobs") = Nothing
                            End If
                        End If
                    End If


                    gridObs.EditIndex = -1

                    loadGridObservacao()

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Protected Sub btn_incluir_parcelas_fornecedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluir_parcelas_fornecedor.Click
        Try
            If Page.IsValid Then

                Dim pagto As New PedidoPagtoFornecedor
                Dim i As Int32
                Dim nr_maior_parcela_banco As Int32
                Dim lnAuxDiferenca As Decimal
                Dim lnAuxValorParcela As Decimal
                Dim lvalornota As Decimal

                Dim nota As New PedidoNotas(cbo_nota_fiscal_forn.SelectedValue)

                lvalornota = nota.nr_valor_nf

                pagto.id_modificador = Session("id_login")
                pagto.id_central_pedido_notas = cbo_nota_fiscal_forn.SelectedValue
                pagto.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item"))
                pagto.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
                pagto.dt_pagto = txt_dt_primeiro_pagto_forn.Text
                pagto.nr_valor_parcela = Round(lvalornota / Convert.ToInt32(txt_total_parcelas_forn.Text), 2)
                lnAuxValorParcela = pagto.nr_valor_parcela
                lnAuxDiferenca = lvalornota - (lnAuxValorParcela * Convert.ToInt32(txt_total_parcelas_forn.Text))

                nr_maior_parcela_banco = pagto.getPagtoFornecedorMaxParcela


                'só deixa atualizar ou inserir se algum campo for diferente do banco
                If pagto.getPedidoPagtoFornecedorByFilters.Tables(0).Rows.Count = 0 Then

                    'Se é um novo item
                    If CInt(txt_total_parcelas_forn.Text) > 1 Then 'se é Parcelado
                        For i = 1 To CInt(txt_total_parcelas_forn.Text)
                            pagto.nr_parcela = i + nr_maior_parcela_banco
                            If i = 1 Then
                                'assue que a primeira parcela vai ter a diferença de centavos do valor
                                pagto.nr_valor_parcela = pagto.nr_valor_parcela + lnAuxDiferenca
                            End If
                            If i > 1 Then
                                pagto.dt_pagto = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pagto.dt_pagto))
                                pagto.nr_valor_parcela = lnAuxValorParcela
                            End If

                            pagto.insertPedidoCentralPagtoFornecedor()
                        Next
                    Else
                        'fran 08/2015 i 
                        If nr_maior_parcela_banco = 0 Then
                            nr_maior_parcela_banco = 1 'assume que é a primeira parcela
                        End If
                        'fran 08/2015 f 

                        pagto.nr_parcela = i + nr_maior_parcela_banco

                        pagto.insertPedidoCentralPagtoFornecedor()
                    End If

                Else
                    messageControl.Alert("Os dados informados já existem no cadastro de Pagamento ao Fornecedor!")
                End If

                cbo_nota_fiscal_forn.SelectedValue = 0
                txt_total_parcelas_forn.Text = String.Empty
                txt_dt_primeiro_pagto_forn.Text = String.Empty

                loadGridPagtoFornecedor()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.id_menu_item = 97
                usuariolog.ds_nm_processo = "Pedido - Pagamento ao Fornecedor"
                usuariolog.id_nr_processo = lbl_id_central_pedido.Text
                usuariolog.nm_nr_processo = lbl_id_central_pedido.Text

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub cv_datapagtoforn_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_datapagtoforn.ServerValidate
        Try

            args.IsValid = True

            'se a data de pagamento for menor que a data do pedido menos 1 mes
            If Convert.ToDateTime(txt_dt_primeiro_pagto_forn.Text) < DateAdd(DateInterval.Month, -1, Convert.ToDateTime(lbl_dt_pedido.Text)) Then
                args.IsValid = False
            Else
                args.IsValid = True
            End If

            If Not args.IsValid Then
                messageControl.Alert("A data de primeiro pagamento do 'Pagamento ao Fornecedor' não pode ser anterior à Data de Pedido menos 1 mês.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    'Protected Sub cv_datapagtoprod_ServerValidate1(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_datapagtoprod.ServerValidate
    '    Try

    '        args.IsValid = True

    '        'se a data de pagamento for menor que a data do pedido menos 1 mes
    '        If Convert.ToDateTime(txt_dt_primeiro_pagto_prod.Text) < DateAdd(DateInterval.Month, -1, Convert.ToDateTime(lbl_dt_pedido.Text)) Then
    '            args.IsValid = False
    '        Else
    '            args.IsValid = True
    '        End If

    '        If Not args.IsValid Then
    '            messageControl.Alert("A data de pagamento do Desconto ao Produtor não pode ser anterior à Data de Pedido menos 1 mês.")
    '        End If
    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try
    'End Sub
    Protected Sub btn_incluir_parcelas_produtor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluir_parcelas_produtor.Click
        Try
            If Page.IsValid Then

                Dim pagto As New PedidoDescontoProdutor
                Dim i As Int32
                Dim nr_maior_parcela_banco As Int32
                Dim lnAuxDiferenca As Decimal
                Dim lnAuxValorParcela As Decimal
                Dim liiddescontoprodutor As Int32 = 0
                'fran 10/2018 mais solidos i
                Dim maissolidos As New Poupanca
                Dim dsmaissolidos As DataSet
                Dim lnr_tota_central As Decimal = 0
                Dim ldt_maiorreferenciacompedido As String = String.Empty
                Dim lnr_acumulado_maior_referencia As Decimal = 0
                Dim ldt_referencia_pagto As String
                'Dim lnr_saldo_disponivel_referencia As Decimal = 0
                Dim lnr_maissolidos_valor_premio As Decimal = 0
                Dim lnrmssaldodisponivel As Decimal
                Dim lbatualizarsaldodisponivel As Boolean = False
                'Dim lbmaissolidossaldozero As Boolean = False
                'fran 10/2018 mais solidos f
                Dim lvalornota As Decimal

                'If ViewState.Item("ReabrirPedido") = "S" Then
                '    pagto.nr_nota_fiscal = cbo_nota_fiscal_prod.SelectedItem.Text
                'Else
                '    pagto.nr_nota_fiscal = txt_nota_fiscal_prod.Text
                'End If

                'If Not txt_valor_nota_fiscal_prod.Text.ToString.Equals(String.Empty) Then
                '    pagto.nr_valor_nota_fiscal = Convert.ToDecimal(txt_valor_nota_fiscal_prod.Text)
                'End If

                Dim nota As New PedidoNotas(cbo_nota_fiscal_prod.SelectedValue)

                lvalornota = nota.nr_valor_nf

                pagto.id_central_pedido_notas = cbo_nota_fiscal_prod.SelectedValue
                pagto.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item"))
                pagto.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
                pagto.id_modificador = Session("id_login")
                pagto.dt_pagto = txt_dt_primeiro_pagto_prod.Text
                pagto.nr_valor_parcela = Round(lvalornota / Convert.ToInt32(txt_total_parcelas_prod.Text), 2)
                lnAuxValorParcela = pagto.nr_valor_parcela
                lnAuxDiferenca = lvalornota - (lnAuxValorParcela * Convert.ToInt32(txt_total_parcelas_prod.Text))

                nr_maior_parcela_banco = pagto.getDescontoProdutorMaxParcela

                'fran mais solidos 10/2018 i

                ldt_referencia_pagto = String.Concat("01", Right(pagto.dt_pagto.ToString, 8))

                'If chk_utilizarmaissolidos.Checked = True Then
                '    'GUARDA OS VALORES DA MAIOR REFERENCIA JA DESCONTADA DO PREMIO,ou seja, que já utilizou os pedidos para abater o mais solidos
                '    If CInt(ViewState.Item("id_propriedade_titular")) > 0 Then
                '        maissolidos.id_propriedade_titular = ViewState.Item("id_propriedade_titular")
                '        maissolidos.id_pessoa = 0
                '    Else
                '        maissolidos.id_pessoa = Convert.ToInt32(ViewState.Item("id_produtor"))
                '        maissolidos.id_propriedade_titular = 0
                '    End If
                '    maissolidos.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
                '    '***************************************
                '    'Buscar no PREMIO a mior referencia e o valor acumulado da maior referencia que tenha valor de pedido associado  
                '    dsmaissolidos = maissolidos.getMaisSolidosMaiorReferenciaComPedido
                '    If dsmaissolidos.Tables(0).Rows.Count > 0 Then
                '        With dsmaissolidos.Tables(0).Rows(0)
                '            lnr_acumulado_maior_referencia = .Item("nr_valor_acumulado")
                '            lnr_tota_central = .Item("nr_total_central")
                '            ldt_maiorreferenciacompedido = .Item("dt_maior_referencia")
                '        End With
                '    End If
                'End If
                'fran mais solidos 10/2018 2

                'só deixa atualizar ou inserir se algum campo for diferente do banco
                If pagto.getPedidoDescontoProdutorByFilters.Tables(0).Rows.Count = 0 Then
                    'Se é um novo item
                    If CInt(txt_total_parcelas_prod.Text) > 1 Then 'se é Parcelado
                        For i = 1 To CInt(txt_total_parcelas_prod.Text)
                            pagto.nr_parcela = i + nr_maior_parcela_banco
                            If i = 1 Then
                                'assue que a primeira parcela vai ter a diferença de centavos do valor
                                pagto.nr_valor_parcela = pagto.nr_valor_parcela + lnAuxDiferenca
                            End If
                            If i > 1 Then
                                pagto.dt_pagto = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pagto.dt_pagto))
                                pagto.nr_valor_parcela = lnAuxValorParcela
                                ldt_referencia_pagto = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ldt_referencia_pagto.ToString)) 'fran 10/2018
                            End If
                            'fran 10/2018 i
                            'pagto.insertPedidoCentralDescontoProdutor()
                            liiddescontoprodutor = pagto.insertPedidoCentralDescontoProdutor

                            ''se deve descontar o pedido no programa mais solidos
                            'If chk_utilizarmaissolidos.Checked = True Then
                            '    'busca o valor do premio, e se tiver premio devolve o valor do total da central atualizado
                            '    lnr_maissolidos_valor_premio = Me.BuscarMaisSolidosValorPremio(ldt_referencia_pagto, pagto.nr_valor_parcela, False, ldt_maiorreferenciacompedido, lnr_acumulado_maior_referencia, lnr_tota_central)

                            '    'se nao tem saldo para a referencia pagto
                            '    If lnr_maissolidos_valor_premio = 0 Then
                            '        'atualiza o desconto do produtor para nao pode utilizar saldo mais solidos
                            '        pagto.st_mais_solidos = "N"
                            '        pagto.nr_mais_solidos_valor_utilizado = 0
                            '        pagto.id_central_pedido_desconto_produtor = liiddescontoprodutor
                            '        pagto.updatePedidoDescontoProdutorMaisSolidos()
                            '    Else
                            '        'se tema saldo, atualiza desconto ao produtor e poupanca premio
                            '        pagto.st_mais_solidos = "S"
                            '        pagto.nr_mais_solidos_valor_utilizado = lnr_maissolidos_valor_premio
                            '        pagto.id_central_pedido_desconto_produtor = liiddescontoprodutor
                            '        pagto.updatePedidoDescontoProdutorMaisSolidos()

                            '        maissolidos.id_modificador = pagto.id_modificador
                            '        maissolidos.dt_referencia = ldt_referencia_pagto.ToString
                            '        maissolidos.nr_valor_central = lnr_maissolidos_valor_premio
                            '        maissolidos.updateMaisSolidosPremio()

                            '        lbatualizarsaldodisponivel = True
                            '    End If
                            'End If
                            'fran 10/2018 f

                        Next
                        'If lbatualizarsaldodisponivel = True Then
                        '    'atualiza saldo disponivel
                        '    lnrmssaldodisponivel = maissolidos.getMaisSolidosProdutorSaldoDisponivel
                        '    lbl_ms_valor_disponivel.Text = FormatCurrency(lnrmssaldodisponivel, 2)
                        '    ViewState.Item("maissolidossaldodisponivel") = lnrmssaldodisponivel

                        'End If
                    Else
                        'fran 08/2015 i 
                        If nr_maior_parcela_banco = 0 Then
                            nr_maior_parcela_banco = 1 'assume que é a primeira parcela
                        End If
                        'fran 08/2015 f 
                        pagto.nr_parcela = i + nr_maior_parcela_banco

                        'fran 10/2018 i
                        'pagto.insertPedidoCentralDescontoProdutor()
                        liiddescontoprodutor = pagto.insertPedidoCentralDescontoProdutor

                        'se deve descontar o pedido no programa mais solidos
                        'If chk_utilizarmaissolidos.Checked = True Then
                        '    'busca o valor do premio, e se tiver premio devolve o valor do total da central atualizado
                        '    lnr_maissolidos_valor_premio = Me.BuscarMaisSolidosValorPremio(ldt_referencia_pagto, pagto.nr_valor_parcela, False, ldt_maiorreferenciacompedido, lnr_acumulado_maior_referencia, lnr_tota_central)

                        '    'se nao tem saldo para a referencia pagto
                        '    If lnr_maissolidos_valor_premio = 0 Then
                        '        'atualiza o desconto do produtor para nao pode utilizar saldo mais solidos
                        '        pagto.st_mais_solidos = "N"
                        '        pagto.nr_mais_solidos_valor_utilizado = 0
                        '        pagto.id_central_pedido_desconto_produtor = liiddescontoprodutor
                        '        pagto.updatePedidoDescontoProdutorMaisSolidos()
                        '    Else
                        '        'se tema saldo, atualiza desconto ao produtor e poupanca premio
                        '        pagto.st_mais_solidos = "S"
                        '        pagto.nr_mais_solidos_valor_utilizado = lnr_maissolidos_valor_premio
                        '        pagto.id_central_pedido_desconto_produtor = liiddescontoprodutor
                        '        pagto.updatePedidoDescontoProdutorMaisSolidos()

                        '        maissolidos.id_modificador = pagto.id_modificador
                        '        maissolidos.dt_referencia = ldt_referencia_pagto.ToString
                        '        maissolidos.nr_valor_central = lnr_maissolidos_valor_premio
                        '        maissolidos.updateMaisSolidosPremio()

                        '        'atualiza saldo disponivel
                        '        lnrmssaldodisponivel = maissolidos.getMaisSolidosProdutorSaldoDisponivel
                        '        lbl_ms_valor_disponivel.Text = FormatCurrency(lnrmssaldodisponivel, 2)
                        '        ViewState.Item("maissolidossaldodisponivel") = lnrmssaldodisponivel

                        '    End If
                        'End If
                        'fran 10/2018 f

                    End If

                Else
                    messageControl.Alert("Os dados informados já existem no cadastro de Desconto ao Produtor!")
                End If

                loadGridDescontoProdutor()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub cbo_nr_nota_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

            Dim lsaux As String
            Dim lpos As Integer

            Dim cbo_nr_nota As DropDownList = CType(row.FindControl("cbo_nr_nota"), DropDownList)
            'Dim txt_nr_valor_nota_fiscal As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_nota_fiscal"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim lbl_id_central_pedido_pagto_fornecedor As Label = CType(row.FindControl("lbl_id_central_pedido_pagto_fornecedor"), Label)
            Dim lbl_nr_valor_nota_fical As Label = CType(row.FindControl("lbl_nr_valor_nota_fical"), Label)

            'txt_nr_valor_nota_fiscal.Text = FormatNumber(CDec(cbo_nr_nota.SelectedValue), 2, , , TriState.True)
            'txt_nr_valor_nota_fiscal.Text = CDec(cbo_nr_nota.SelectedValue) 'atribui o valor da nota
            If Not cbo_nr_nota.SelectedValue.Equals("0") Then 'se selecionou alguma nota
                Dim notas As New PedidoNotas(cbo_nr_nota.SelectedValue)

                lbl_nr_valor_nota_fical.Text = FormatNumber(notas.nr_valor_nf, 2, , , TriState.True)
                'lsaux = cbo_nr_nota.SelectedValue.ToString.Trim
                'lsaux = Replace(lsaux, ".", ",")
                'lsaux = Replace(lsaux, " ", "")
                'lpos = InStr(1, lsaux, "*")
                'If lpos > 0 Then
                '    If lpos = 1 Then ' se encontrou * na 1a posição não valor
                '        txt_nr_valor_nota_fiscal.Text = String.Empty
                '    Else 'se encontrou * 
                '        txt_nr_valor_nota_fiscal.Text = FormatNumber(CDec(Mid(lsaux, 1, lpos - 1).ToString), 2, , , TriState.True)
                '    End If

                'Else
                '    txt_nr_valor_nota_fiscal.Text = String.Empty
                'End If

            Else
                lbl_nr_valor_nota_fical.Text = String.Empty
                'txt_nr_valor_nota_fiscal.Text = String.Empty
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub cbo_nr_nota_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            'Dim lsaux As String
            'Dim lpos As Integer
            'Dim lposdata As Integer


            Dim cbo_nr_nota As DropDownList = CType(row.FindControl("cbo_nr_nota"), DropDownList)
            'Dim txt_nr_valor_nota_fiscal As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_nota_fiscal"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            'Dim txt_dt_emissao As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_emissao"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
            'Dim txt_nr_serie As Anthem.TextBox = CType(row.FindControl("txt_nr_serie"), Anthem.TextBox)
            Dim lbl_id_central_pedido_pagto_fornecedor As Label = CType(row.FindControl("lbl_id_central_pedido_pagto_fornecedor"), Label)
            Dim lbl_nr_valor_nota_fiscal As Label = CType(row.FindControl("lbl_nr_valor_nota_fiscal"), Label)
            Dim lbl_dt_emissao As Label = CType(row.FindControl("lbl_dt_emissao"), Label)
            Dim lbl_nr_serie As Label = CType(row.FindControl("lbl_nr_serie"), Label)

            Try
                If Not cbo_nr_nota.SelectedValue.Equals("0") Then 'se selecionou alguma nota
                    Dim notas As New PedidoNotas(cbo_nr_nota.SelectedValue)

                    lbl_nr_serie.Text = notas.nr_serie.ToString
                    lbl_nr_valor_nota_fiscal.Text = FormatNumber(notas.nr_valor_nf, 2, , , TriState.True)
                    lbl_dt_emissao.Text = DateTime.Parse(notas.dt_emissao.ToString).ToString("dd/MM/yyyy")

                    'lsaux = cbo_nr_nota.SelectedValue.ToString.Trim
                    'lsaux = Replace(lsaux, ".", ",")
                    'lsaux = Replace(lsaux, " ", "")
                    'lpos = InStr(1, lsaux, "*")
                    'lposdata = InStr(lpos + 1, lsaux, "*")
                    'If lpos > 0 Then
                    '    If lpos = 1 Then ' se encontrou * na 1a posição não tem serie
                    '        txt_nr_serie.Text = String.Empty
                    '    Else 'se encontrou * 
                    '        txt_nr_serie.Text = Mid(lsaux, 1, lpos - 1)
                    '    End If

                    '    'se na promeira posição apos * tiver outro * ou vazio, nao tem valor de nota
                    '    If Mid(lsaux, lpos + 1, 1).ToString.Equals("*") OrElse Mid(lsaux, lpos + 1, 1).ToString.Equals(String.Empty) Then
                    '        txt_nr_valor_nota_fiscal.Text = String.Empty
                    '    Else
                    '        txt_nr_valor_nota_fiscal.Text = FormatNumber(Convert.ToDecimal(Mid(lsaux, lpos + 1, lposdata - lpos - 1).ToString), 2, , , TriState.True)
                    '    End If
                    '    'se na primeira posição apos * for vazio nao tem data emissao
                    '    If Mid(lsaux, lposdata + 1, 1).ToString.Equals("*") OrElse Mid(lsaux, lposdata + 1, 1).ToString.Equals(String.Empty) Then
                    '        txt_dt_emissao.Text = String.Empty
                    '    Else
                    '        txt_dt_emissao.Text = DateTime.Parse(Mid(lsaux, lposdata + 1)).ToString("dd/MM/yyyy")
                    '    End If
                    'Else
                    '    txt_nr_serie.Text = String.Empty
                    '    txt_nr_valor_nota_fiscal.Text = String.Empty
                    '    txt_dt_emissao.Text = String.Empty
                    'End If

                Else
                    lbl_nr_valor_nota_fiscal.Text = String.Empty
                    lbl_nr_serie.Text = String.Empty
                    lbl_dt_emissao.Text = String.Empty

                End If
                'txt_nr_valor_nota_fiscal.Enabled = False
                'txt_nr_serie.Enabled = False
                'txt_dt_emissao.Enabled = False


            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    'Protected Sub cbo_nota_fiscal_prod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_nota_fiscal_prod.SelectedIndexChanged
    '    Try

    '        Dim lsaux As String
    '        Dim lpos As Integer

    '        If Not cbo_nota_fiscal_prod.SelectedValue.Equals(String.Empty) Then 'se selecionou alguma nota
    '            lsaux = cbo_nota_fiscal_prod.SelectedValue.ToString.Trim
    '            lsaux = Replace(lsaux, ".", ",")
    '            lsaux = Replace(lsaux, " ", "")
    '            lpos = InStr(1, lsaux, "*")
    '            If lpos > 0 Then
    '                If lpos = 1 Then ' se encontrou * na 1a posição não tem valor
    '                    txt_valor_nota_fiscal_prod.Text = String.Empty
    '                Else 'se encontrou * 
    '                    txt_valor_nota_fiscal_prod.Text = FormatNumber(Convert.ToDecimal(Mid(lsaux, 1, lpos - 1).ToString), 2, , , TriState.True)
    '                End If
    '            Else
    '                txt_valor_nota_fiscal_prod.Text = String.Empty
    '            End If
    '            'txt_valor_nota_fiscal_prod.Text = FormatNumber(Convert.ToDecimal(cbo_nota_fiscal_prod.SelectedValue.ToString), 2, , , TriState.True)
    '        Else
    '            txt_valor_nota_fiscal_prod.Text = String.Empty

    '        End If

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)

    '    End Try
    'End Sub

 
    Protected Sub cv_parcelamento_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_parcelamento.ServerValidate
        Try
            Dim lmsg As String
            Dim pedido As New Pedido
            Dim dspedido As DataSet

            args.IsValid = True
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
            pedido.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item"))

            If cbo_parcelamento.SelectedValue.Equals("N") Then
                'Se parcelamento do banco é DANONE OU PARCEIRO deve verificar a qtde de parcelas já inclusas. 
                'Se existir apenas 1, nao deixa mais incluir e atualiza para N
                'Se existir mmais que 1 parcela, exibe mensagem avisando que nao pode atualizar para a vista 
                If Not ViewState.Item("st_parcelamento").ToString.Equals("N") Then
                    dspedido = pedido.getCentralPedidoConsParcelasbyItem
                    If dspedido.Tables(0).Rows.Count > 0 Then
                        Dim lqtde_parcelas As Integer
                        Dim lnr_parcelas As Integer
                        With dspedido.Tables(0).Rows(0)
                            lqtde_parcelas = .Item("qtde_parcelas")
                            lnr_parcelas = .Item("nr_parcelas")
                            'se a atde parcelas já existentes é maior que 1, 
                            If lqtde_parcelas > 1 Then
                                args.IsValid = False
                                lmsg = "Para o item " & .Item("nm_item").ToString & ", o tipo de parcelamento não poderá ser atualizado para não parcelado. Mais de uma parcela estão cadastradas em Desconto ao Produtor."
                            Else
                                'se quatde de parcelas ja cadastradas no desconto produtor for 1 apenas ataulizar 
                            End If
                        End With

                    End If
                End If
            End If


            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub btn_atualizar_parcelamento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_atualizar_parcelamento.Click
        Try
            If Page.IsValid Then

                Dim pedidoitem As New PedidoItem

                pedidoitem.st_parcelamento = cbo_parcelamento.SelectedValue.ToString
                pedidoitem.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item"))
                pedidoitem.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))

                pedidoitem.updatePedidoItemParcelamento()
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.id_menu_item = 97
                usuariolog.ds_nm_processo = "Pedido - Parcelamento"
                usuariolog.id_nr_processo = lbl_id_central_pedido.Text
                usuariolog.nm_nr_processo = lbl_id_central_pedido.Text

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f

                'loadGridItens()
                ViewState.Item("st_parcelamento") = pedidoitem.st_parcelamento.ToString
                cbo_parcelamento.ForeColor = System.Drawing.Color.FromName("#000000")

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_dataemissao_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try

            args.IsValid = True
            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim txt_dt_emissao As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_emissao"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
            Dim lmsg As String
            'se a data de emissao for menor que a data do pedido menos 1 mes
            If Convert.ToDateTime(txt_dt_emissao.Text) < DateAdd(DateInterval.Month, -1, Convert.ToDateTime(lbl_dt_pedido.Text)) Then
                lmsg = "A data de pagamento do Pagamento ao Fornecedor não pode ser anterior à Data de Pedido menos 1 mês."
                args.IsValid = False
            Else
                args.IsValid = True
            End If



            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
        Try

            args.IsValid = True

            'se a data de pagamento for menor que a data do pedido menos 1 mes
            If Convert.ToDateTime(txt_nf_dt_emissao.Text) < DateAdd(DateInterval.Month, -2, Convert.ToDateTime(lbl_dt_pedido.Text)) Then
                args.IsValid = False
            Else
                args.IsValid = True
            End If

            If Not args.IsValid Then
                messageControl.Alert("A data de emissão da nota fiscal não pode ser anterior à Data de Pedido menos 2 mês.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)

            '   
        End Try

    End Sub
    'Protected Sub cv_emissao_nota_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_emissao_nota.ServerValidate
    '    Try

    '        args.IsValid = True

    '        'se a data de pagamento for menor que a data do pedido menos 1 mes
    '        If Convert.ToDateTime(txt_dt_emissao_nota.Text) < DateAdd(DateInterval.Month, -2, Convert.ToDateTime(lbl_dt_pedido.Text)) Then
    '            args.IsValid = False
    '        Else
    '            args.IsValid = True
    '        End If

    '        If Not args.IsValid Then
    '            messageControl.Alert("A data de emissão da nota fiscal do 'Pagamento ao Fornecedor' não pode ser anterior à Data de Pedido menos 2 mês.")
    '        End If
    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)

    '        '   
    '    End Try
    'End Sub
    Private Function BuscarMaisSolidosValorPremio(ByVal pdt_referencia_pagto As String, ByVal pnr_valor_parcela_pagto As Decimal, ByVal pbBuscarMaiorReferencia As Boolean, Optional ByVal pdtMaiorReferencia As String = "", Optional ByVal pnrAcumuladoMaiorReferencia As Decimal = 0, Optional ByRef pnr_valor_central As Decimal = 0, Optional ByRef pnrSaldoDisponivelReferencia As Decimal = 0) As Decimal

        Try

            'fran 10/2018 mais solidos i
            Dim maissolidos As New Poupanca
            Dim dsmaissolidos As DataSet
            Dim lnr_tota_central As Decimal = 0
            Dim ldt_maiorreferenciacompedido As String = String.Empty
            Dim lnr_acumulado_maior_referencia As Decimal = 0
            Dim lnr_saldo_disponivel_referencia As Decimal = 0
            Dim lnr_maissolidos_valor_premio As Decimal = 0
            Dim lbmaissolidossaldozero As Boolean = False
            'fran 10/2018 mais solidos f

            '*********************************************************************************
            'BUSCAR MAIOR REFERENCIA JA UTIÇLIZADA NO RESGATE MAIS SOLIDOS
            '**********************************************************************************
            If CInt(ViewState.Item("id_propriedade_titular")) > 0 Then
                maissolidos.id_propriedade_titular = ViewState.Item("id_propriedade_titular")
                maissolidos.id_pessoa = 0
            Else
                maissolidos.id_pessoa = Convert.ToInt32(ViewState.Item("id_produtor"))
                maissolidos.id_propriedade_titular = 0
            End If
            maissolidos.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")

            'se n ao foi passado o parametro da maior referencia do mais solidos, então busca
            If pbBuscarMaiorReferencia = True Then
                'GUARDA OS VALORES DA MAIOR REFERENCIA JA DESCONTADA DO PREMIO,ou seja, que já utilizou os pedidos para abater o mais solidos
                'Buscar no PREMIO a mior referencia e o valor acumulado da maior referencia que tenha valor de pedido associado  
                dsmaissolidos = maissolidos.getMaisSolidosMaiorReferenciaComPedido
                If dsmaissolidos.Tables(0).Rows.Count > 0 Then
                    With dsmaissolidos.Tables(0).Rows(0)
                        lnr_acumulado_maior_referencia = .Item("nr_valor_acumulado")
                        lnr_tota_central = .Item("nr_total_central")
                        ldt_maiorreferenciacompedido = .Item("dt_maior_referencia")
                    End With
                End If
            Else
                'se foi passado como parametro, ja fez a busca emoutra rotina, assume o que veio do parametro
                lnr_acumulado_maior_referencia = pnrAcumuladoMaiorReferencia
                lnr_tota_central = pnr_valor_central
                ldt_maiorreferenciacompedido = pdtMaiorReferencia
            End If
            '***************************************************************
            'PEGA O SALDO DISPONIVEL DA REFERENCIA
            '**************************************************************
            'busca o saldo ainda disponivel na referencia do pagamento (valor acumulado na referencia subtraindo o total gasto na central ate a referenmcia e subtraindo depois o valor_excedido do mes posterior (para o caso de no mes posterior ter utilizado o saldo da ref atual) 
            maissolidos.dt_referencia = pdt_referencia_pagto.ToString
            lnr_saldo_disponivel_referencia = maissolidos.getMaisSolidosSaldoDisponivelReferencia


            '***********************************************************
            'BUSCAR O VALOR DO PREMIO 
            '**********************************************************
            'se tem maior referencia com pediddo e REF PAGTO DO DESCONTO for menor que a MAIOR REFERENCIA (significa que deve verificadar o saldo anterior para verificar se ainda tem desconto)
            If Not ldt_maiorreferenciacompedido.ToString.Equals(String.Empty) AndAlso CDate(pdt_referencia_pagto) < CDate(ldt_maiorreferenciacompedido) Then
                'se ainda tem saldo para os meses anteriores ao ultimo pedido que utilizou mais solidos
                If lnr_acumulado_maior_referencia - lnr_tota_central > 0 Then
                    'se o saldo sdisponivel na referencia tambem é maior que zero
                    If lnr_saldo_disponivel_referencia > 0 Then
                        'se o saldo disponivel na referencia de pagto for maior que o saldo disponivel para a maior referencia utilizada, nao posso utilizar como base o valor do saldo da referencia devo utilizar o valor do saldo do programa
                        If lnr_saldo_disponivel_referencia > (lnr_acumulado_maior_referencia - lnr_tota_central) Then
                            'se o valor da parcela do desconto ao produtor for menor ou igual ao saldo disponivel da maior referencia
                            If pnr_valor_parcela_pagto <= (lnr_acumulado_maior_referencia - lnr_tota_central) Then
                                'o valor do premio a ser utilizado será o valor da parcela 
                                lnr_maissolidos_valor_premio = pnr_valor_parcela_pagto
                            Else
                                'o valor do premio a ser utilizado será o valor do saldo da referencia 
                                lnr_maissolidos_valor_premio = (lnr_acumulado_maior_referencia - lnr_tota_central)
                            End If
                            'retorna que o saldo disponivel da referencia
                            pnrSaldoDisponivelReferencia = (lnr_acumulado_maior_referencia - lnr_tota_central)
                        Else 'se saldo da referencia é menor ou igual ao saldo da maior referencia, pode utilizar como base o saldo da propria referencia
                            'se o valor da parcela do desconto ao produtor for menor ou igual ao saldo disponivel na referencia
                            If pnr_valor_parcela_pagto <= lnr_saldo_disponivel_referencia Then
                                'o valor do premio a ser utilizado será o valor da parcela 
                                lnr_maissolidos_valor_premio = pnr_valor_parcela_pagto
                            Else
                                'o valor do premio a ser utilizado será o valor do saldo da referencia 
                                lnr_maissolidos_valor_premio = lnr_saldo_disponivel_referencia
                            End If
                            'retorna que o saldo disponivel da referencia
                            pnrSaldoDisponivelReferencia = lnr_saldo_disponivel_referencia

                        End If
                        'atualiza o valor total da central da referencia maior para nao precisar refazer busca no banco
                        lnr_tota_central = lnr_tota_central + lnr_maissolidos_valor_premio
                    Else
                        'saldo zero
                        lbmaissolidossaldozero = True
                    End If

                Else 'se o saldo da maior referencia utilizada é 0... nao pode mais haver descontos nos meses anteriores à maior referencia
                    'atualiza o desconto do produtor para nao pode utilizar saldo mais solidos
                    lbmaissolidossaldozero = True
                End If
            Else 'se nao utilizou referencias para frente 
                'se tem saldo sdisponivel na referencia
                If lnr_saldo_disponivel_referencia > 0 Then
                    'se o valor da parcela do desconto ao produtor for menor ou igual ao saldo disponivel na referencia
                    If pnr_valor_parcela_pagto <= lnr_saldo_disponivel_referencia Then
                        'o valor do premio a ser utilizado será o valor da parcela 
                        lnr_maissolidos_valor_premio = pnr_valor_parcela_pagto
                    Else
                        'o valor do premio a ser utilizado será o valor do saldo da referencia 
                        lnr_maissolidos_valor_premio = lnr_saldo_disponivel_referencia
                    End If
                    'retorna que o saldo disponivel da referencia
                    pnrSaldoDisponivelReferencia = lnr_saldo_disponivel_referencia

                Else
                    'saldo zero
                    lbmaissolidossaldozero = True
                End If
            End If

            If lbmaissolidossaldozero = True Then
                pnrSaldoDisponivelReferencia = 0
                lnr_maissolidos_valor_premio = 0
            End If

            'RETORNA O TOTAL DA CENTRAL
            pnr_valor_central = lnr_tota_central
            'RETORNA O VALOR DO PREMIO, se for saldo zero, retorna 0
            BuscarMaisSolidosValorPremio = lnr_maissolidos_valor_premio



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Function

    Protected Sub chk_compras_evento_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_compras_evento.CheckedChanged
        Try

            Dim pedido As New Pedido

            pedido.id_modificador = Session("id_login")
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
            If chk_compras_evento.Checked = True Then
                pedido.st_evento_compras = "S"
            Else
                pedido.st_evento_compras = "N"
            End If

            pedido.updateCentralPedidoEventoCompras()



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub hf_sel_id_item_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hf_sel_id_item.ValueChanged

    End Sub

    Protected Sub gridNotas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridNotas.RowCommand
        Select Case e.CommandName.ToString().ToLower()
            Case "anexar"

                Response.Redirect("frm_central_pedido_anexos.aspx?id=" + e.CommandArgument.ToString() + "&tipo=pednf&tela=frm_central_pedido.aspx?id_central_pedido=" + ViewState.Item("id_central_pedido").ToString)


            Case "delete"
                deletePedidoNotas(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deletePedidoNotas(ByVal id_central_pedido_notas As Integer)

        Try
            Dim pedidonota As New PedidoNotas()
            pedidonota.id_central_pedido_notas = id_central_pedido_notas
            pedidonota.id_modificador = Convert.ToInt32(Session("id_login"))
            pedidonota.id_central_pedido = ViewState.Item("id_central_pedido").ToString
            pedidonota.deleteCentralPedidoNotas()

            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 97 'pedido
            usuariolog.ds_nm_processo = "Pedidos - Notas"
            usuariolog.id_nr_processo = ViewState.Item("id_central_pedido").ToString
            usuariolog.insertUsuarioLog()

            Dim pedido As New Pedido()
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
            lbl_total_notas.Text = FormatCurrency(pedido.getCentralPedidoValorTotalNotas, 2).ToString

            'loadData()

            messageControl.Alert("Registro excluído com sucesso!")
            Response.Redirect("frm_central_pedido.aspx?id_central_pedido=" + ViewState.Item("id_central_pedido").ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridNotas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridNotas.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) And ViewState.Item("bTemNotas") = True Then

            Dim hl_download As Anthem.HyperLink = CType(e.Row.FindControl("hl_download"), Anthem.HyperLink)
            Dim lbl_parcela_com_exportacao_nota As Label = CType(e.Row.FindControl("lbl_parcela_com_exportacao_nota"), Label)
            Dim lbl_parcela_com_calculo_nota As Label = CType(e.Row.FindControl("lbl_parcela_com_calculo_nota"), Label)
            Dim lbl_id_central_notas_importacao As Anthem.Label = CType(e.Row.FindControl("lbl_id_central_notas_importacao"), Anthem.Label)
            Dim lbl_nrnotafiscal As Anthem.Label = CType(e.Row.FindControl("lbl_nrnotafiscal"), Anthem.Label)
            Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
            Dim btn_anexar As Anthem.ImageButton = CType(e.Row.FindControl("btn_anexar"), Anthem.ImageButton)

            If lbl_id_central_notas_importacao.Text.Equals(String.Empty) OrElse lbl_id_central_notas_importacao.Text.Equals("0") Then
                Dim pedidoanexo As New PedidoAnexos
                pedidoanexo.id_central_pedido_notas = Me.gridNotas.DataKeys(e.Row.RowIndex).Value.ToString
                Dim dspedidoanexo As DataSet = pedidoanexo.getPedidoAnexos

                btn_anexar.Visible = True

                If dspedidoanexo.Tables(0).Rows.Count > 0 Then
                    hl_download.Visible = True
                    lbl_nrnotafiscal.Visible = False
                    If (Not hl_download.Text.ToString().Equals(String.Empty)) Then
                        hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", pedidoanexo.id_central_pedido_notas.ToString) + String.Format("&id_processo={0}", "7")
                    End If
                Else
                    hl_download.Visible = False
                    lbl_nrnotafiscal.Visible = True

                End If
            Else
                btn_anexar.Visible = False
                hl_download.Visible = True
                lbl_nrnotafiscal.Visible = False
                If (Not hl_download.Text.ToString().Equals(String.Empty)) Then
                    hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", lbl_id_central_notas_importacao.Text) + String.Format("&id_processo={0}", "3")
                End If

            End If
            If ViewState.Item("pedidoindireto") = "S" Then
                If lbl_parcela_com_exportacao_nota.Text = "S" Then 'se for incluida manual ou incluida milk nao pode deletar
                    btn_delete.Enabled = False
                    btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                    btn_delete.ToolTip = "Não é possível excluir a Nota do Pedido. Já foi efetuado para nota a exportação e/ou cálculo."
                Else
                    btn_delete.Enabled = True
                    btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                    If lbl_id_central_notas_importacao.Text.Equals(String.Empty) OrElse lbl_id_central_notas_importacao.Text.Equals("0") Then
                        btn_delete.ToolTip = "Excluir Nota Pedido."
                    Else
                        btn_delete.ToolTip = "Excluir Nota Pedido. Esta nota retornará para o Gerenciamento de Notas Importadas como pendente."
                    End If
                    ViewState.Item("bNotasPodeExcluir") = True
                End If
            Else
                If lbl_parcela_com_exportacao_nota.Text = "S" OrElse lbl_parcela_com_calculo_nota.Text = "S" Then 'se tem alguma parcela paga ou exportada
                    btn_delete.Enabled = False
                    btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                    btn_delete.ToolTip = "Não é possível excluir a Nota do Pedido. Já foi efetuado para nota a exportação e/ou cálculo."
                Else
                    btn_delete.Enabled = True
                    btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                    If lbl_id_central_notas_importacao.Text.Equals(String.Empty) OrElse lbl_id_central_notas_importacao.Text.Equals("0") Then
                        btn_delete.ToolTip = "Excluir Nota Pedido."
                    Else
                        btn_delete.ToolTip = "Excluir Nota Pedido. Esta nota retornará para o Gerenciamento de Notas Importadas como pendente."
                    End If
                    ViewState.Item("bNotasPodeExcluir") = True

                End If

            End If

        End If


    End Sub

    Protected Sub gridNotas_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridNotas.RowDeleting
        e.Cancel = True

    End Sub


    Protected Sub btn_pedidoeditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pedidoeditar.Click
        Try

            'Dim lqtdeparcelascomexportacaopedido As Int16 = 0
            'Dim lqtdeparcelaspedidoforn As Int16 = 0
            'Dim lqtdeparcelascomcalculopedido As Int16 = 0
            'Dim lqtdeparcelaspedidoprod As Int16 = 0
            'Dim pedidonota As New PedidoNotas
            'pedidonota.id_central_pedido = CInt(ViewState.Item("id_central_pedido").ToString)
            'Dim dspedidonota As DataSet

            ''APURA EXPORTACAO E CALCULO dos grids de pagamento
            'dspedidonota = pedidonota.getPedidoNotasByFilters
            ''pega so a primeira nota que vier porque so vai utilizar totalizado do pedido
            'With dspedidonota.Tables(0).Rows(0)
            '    lqtdeparcelaspedidoforn = CInt(.Item("nr_qtde_parcelas_pedido_forn").ToString)
            '    lqtdeparcelaspedidoprod = CInt(.Item("nr_qtde_parcelas_pedido_prod").ToString)

            '    'se é zero nao tem inclusao de grid fornecedor
            '    If lqtdeparcelaspedidoforn > 0 Then
            '        lqtdeparcelascomexportacaopedido = CInt(.Item("nr_qtde_parcelas_com_exportacao_pedido").ToString)
            '    Else
            '        lqtdeparcelascomexportacaopedido = 0
            '    End If

            '    If lqtdeparcelaspedidoprod > 0 Then
            '        lqtdeparcelascomcalculopedido = CInt(.Item("nr_qtde_parcelas_com_calculo_pedido").ToString)
            '    Else
            '        lqtdeparcelascomcalculopedido = 0
            '    End If
            'End With

            'so deixa entrar neste modo quando pedido é finalizado ou finalizado parcial
            ViewState.Item("modoedicao") = True

            ViewState.Item("ReabrirPedido") = "S"
            btn_pedidoeditar.Enabled = False
            btn_pedidosalvar.Enabled = True
            lk_gerar_pedido.Enabled = False
            lk_email_parceiro.Enabled = False
            lk_email_produtor.Enabled = False
            lk_email_parceiro_frete.Enabled = False

            'INCLUSAO DE NOTAS
            If CInt(ViewState.Item("id_situacao_pedido")).Equals(8) Then
                'se era finalizado parcial pode deixar incluir nota
                btn_incluirnota.Enabled = True
                gridNotas.Columns.Item(7).Visible = True
                ViewState.Item("id_situacao_pedido_ant") = 8

            Else
                'se era finalizado so pode fazer alteracao nos pagamentos e nao em notas
                ViewState.Item("id_situacao_pedido_ant") = 3

                If ViewState.Item("bTemNotas") = True Then
                    If ViewState.Item("bNotasPodeExcluir") = True Then
                        btn_incluirnota.Enabled = True
                        btn_incluirnota.ToolTip = String.Empty
                        gridNotas.Columns.Item(7).Visible = True
                    Else
                        'se todas as parcelas foram exportadas e calculadas, nao prcisa editar pedido finalizado
                        btn_incluirnota.Enabled = False
                        btn_incluirnota.ToolTip = "O pedido estava Finalizado, por isso não pode incluir notas apenas realizar alterações nos pagamentos."
                        gridNotas.Columns.Item(7).Visible = False
                    End If
                Else
                    btn_incluirnota.Enabled = True
                    btn_incluirnota.ToolTip = String.Empty
                    gridNotas.Columns.Item(7).Visible = True
                End If


                'If lqtdeparcelaspedidoforn = lqtdeparcelascomexportacaopedido AndAlso lqtdeparcelaspedidoprod = lqtdeparcelascomcalculopedido Then
                '    btn_incluirnota.Enabled = False
                '    btn_incluirnota.ToolTip = "O pedido estava Finalizado, por isso não pode incluir notas apenas realizar alterações nos pagamentos."
                '    gridNotas.Columns.Item(6).Visible = False
                'Else
                '    btn_incluirnota.Enabled = False
                '    btn_incluirnota.ToolTip = String.Empty
                '    gridNotas.Columns.Item(6).Visible = True

                'End If
            End If
            ViewState.Item("id_situacao_pedido") = 4

            btn_adicionar_entrega.Enabled = True
            btn_adicionar_pagto_fornecedor.Enabled = True
            'If ViewState.Item("st_parcelamento").ToString.Equals("N") Then 'Se parcelamento é a vista
            '    btn_adicionar_desconto_prod.Enabled = False 'Não deve informar mais parcelas se o parcelamento é a vista. Deve atualizar combo
            'Else
            '    btn_adicionar_desconto_prod.Enabled = True
            'End If
            btn_adicionar_desconto_prod.Enabled = True
            btn_incluir_parcelas_fornecedor.Enabled = True
            btn_incluir_parcelas_produtor.Enabled = True
            'COLUNAS ALTERACAO GRIDS
            gridEntrega.Columns.Item(5).Visible = True
            gridPagtoForn.Columns.Item(12).Visible = True
            grdDescProdutor.Columns.Item(11).Visible = True

            'CAMPO PARCELAMENTO VISIVEL (tela ja entra visible)
            cbo_parcelamento.Enabled = True

            'CAMPO EVENTO COMPRAS fica habilitado 
            chk_compras_evento.Visible = True
            img_compras_evento.Visible = False

            If ViewState.Item("id_grupo").ToString.Equals("2") AndAlso Left(lbl_cif_parceiro.Text, 1) = "N" Then
                lk_atualizar_frete.Enabled = False
            Else
                lk_atualizar_frete.Visible = False
                lk_atualizar_frete.Enabled = False

            End If

            Dim pedido As New Pedido
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
            pedido.id_modificador = Session("id_login")
            pedido.reabrirPedido()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 6 'PROCESSO
            usuariolog.id_menu_item = 97
            usuariolog.ds_nm_processo = "Pedido - Editar/Reabrir"
            usuariolog.id_nr_processo = ViewState.Item("id_central_pedido").ToString

            usuariolog.insertUsuarioLog()
            'fran 08/12/2020 f



        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub btn_incluirnota_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluirnota.Click
        If Page.IsValid Then
            Try

                Dim lnrtotalnotaspedido As Decimal = CDec(lbl_total_notas.Text)
                Dim lidcentralpedidonota As Integer = 0

                Dim nota As New PedidoNotas
                nota.id_central_pedido = CLng(ViewState.Item("id_central_pedido").ToString)
                nota.nr_nota_fiscal = txt_nf_nr_nota.Text
                nota.nr_serie = txt_nf_serie.Text
                nota.dt_emissao = txt_nf_dt_emissao.Text
                nota.nr_valor_nf = CDec(txt_nf_totalnota.Text)
                nota.id_modificador = Session("id_login")
                lidcentralpedidonota = nota.insertCentralPedidoNotas()

                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 97 'pedido
                usuariolog.ds_nm_processo = "Pedidos - Notas"
                usuariolog.nm_nr_processo = String.Concat("Pedido ", ViewState.Item("id_central_pedido").ToString, " Nr Nota ", txt_nf_nr_nota.Text)
                usuariolog.insertUsuarioLog()

                txt_nf_nr_nota.Text = String.Empty
                txt_nf_serie.Text = String.Empty
                txt_nf_dt_emissao.Text = String.Empty
                txt_nf_totalnota.Text = String.Empty

                'atualiza total da nota da tela
                lbl_total_notas.Text = FormatCurrency(CDec(lbl_total_notas.Text) + nota.nr_valor_nf, 2).ToString

                'carrega combo
                loadComboNotas()
                cbo_nota_fiscal_forn.SelectedValue = lidcentralpedidonota
                btn_adicionar_pagto_fornecedor.Enabled = True
                btn_incluir_parcelas_fornecedor.Enabled = True
                If ViewState.Item("pedidoindireto") = "N" Then
                    cbo_nota_fiscal_prod.SelectedValue = lidcentralpedidonota
                    btn_adicionar_desconto_prod.Enabled = True
                    btn_incluir_parcelas_produtor.Enabled = True
                End If

                loadGridNotas()
                loadParcelasProdutorFornecedor(nota.dt_emissao.ToString)


            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If
    End Sub

    Protected Sub cv_incluirnota_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_incluirnota.ServerValidate
        Try
            Dim lmsg As String

            Dim lnrtotalpedidominimo As Decimal = CDec(lbl_total_pedido.Text) - (CDec(lbl_total_pedido.Text) * 0.03)
            Dim lnrtotalpedidomaximo As Decimal = CDec(lbl_total_pedido.Text) + (CDec(lbl_total_pedido.Text) * 0.2)
            Dim lnrtotalnotaspedido As Decimal = CDec(lbl_total_notas.Text)

            args.IsValid = True

            'total nota do pedido somado a nota nova for MAIOR que o valor do pedido + 10% ,não deixa incluir nota 
            If lnrtotalnotaspedido + CDec(txt_nf_totalnota.Text) >= lnrtotalpedidomaximo Then
                args.IsValid = False
                lmsg = "A nota não pode ser incluida porque ultrapassa 20% do valor total do pedido!"
            End If

            Dim notas As New PedidoNotas
            notas.id_central_pedido = CLng(ViewState.Item("id_central_pedido").ToString)
            notas.nr_nota_fiscal = txt_nf_nr_nota.Text
            notas.id_situacao = 1

            Dim dsnota As DataSet = notas.getPedidoNotasByFilters
            'se nao tem erros e encontrou a nota nos pedido
            If args.IsValid AndAlso dsnota.Tables(0).Rows.Count > 0 Then
                args.IsValid = False
                lmsg = "A Nota Fiscal já esta associada ao pedido!"
            End If


            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_atualizarparcelamento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_atualizarparcelamento.Click
        Try
            If Page.IsValid Then

                Dim pedidoitem As New PedidoItem

                pedidoitem.st_parcelamento = cbo_parcelamento.SelectedValue.ToString
                pedidoitem.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item"))
                pedidoitem.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))

                pedidoitem.updatePedidoItemParcelamento()
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.id_menu_item = 97
                usuariolog.ds_nm_processo = "Pedido - Parcelamento"
                usuariolog.id_nr_processo = lbl_id_central_pedido.Text
                usuariolog.nm_nr_processo = lbl_id_central_pedido.Text

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f

                'loadGridItens()
                ViewState.Item("st_parcelamento") = pedidoitem.st_parcelamento.ToString
                cbo_parcelamento.ForeColor = System.Drawing.Color.FromName("#000000")


            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_pedidosalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_pedidosalvar.Click
        If Page.IsValid Then
            Try
                If CInt(ViewState.Item("id_situacao_pedido")) = 4 Then

                    Dim pedido As New Pedido
                    Dim lmsg As String = String.Empty

                    pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))
                    pedido.id_modificador = Session("id_login")

                    Dim lnrtotalpedidominimo As Decimal = CDec(lbl_total_pedido.Text) - (CDec(lbl_total_pedido.Text) * 0.03)
                    Dim lnrtotalpedidomaximo As Decimal = CDec(lbl_total_pedido.Text) + (CDec(lbl_total_pedido.Text) * 0.1)
                    Dim lnrtotalnotaspedido As Decimal = pedido.getCentralPedidoValorTotalNotas

                    'total nota do pedido for MAIOR que o valor do pedido - 3% ,finaliza o pedido em definitivo
                    If lnrtotalnotaspedido >= lnrtotalpedidominimo Then
                        pedido.id_situacao_pedido = 3
                        ViewState.Item("id_situacao_pedido") = 3
                        lmsg = "Pedido salvo e FINALIZADO com sucesso!"
                    Else
                        pedido.id_situacao_pedido = 8
                        ViewState.Item("id_situacao_pedido") = 8

                        lmsg = "Pedido salvo e FINALIZADO PARCIAL com sucesso!"

                    End If
                    lk_email_parceiro.Enabled = True
                    lk_email_produtor.Enabled = True
                    If ViewState.Item("id_fornecedor_frete").ToString = "0" Then
                        lk_email_parceiro_frete.Enabled = False
                    Else
                        lk_email_parceiro_frete.Enabled = True

                    End If


                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'processo
                    usuariolog.id_menu_item = 97
                    usuariolog.ds_nm_processo = "Pedido - Salvar/Finalizar Pedido"
                    usuariolog.id_nr_processo = pedido.id_central_pedido
                    usuariolog.nm_nr_processo = pedido.id_central_pedido

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    If pedido.finalizarPedido() = True Then
                        messageControl.Alert(lmsg)
                    Else
                        messageControl.Alert("Ocorreram problemas na finalização do Pedido. Contate o administrador do sistema.")
                    End If
                End If

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub btn_atualizar_qtdeitem_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_atualizar_qtdeitem.Click
        Try
            If Page.IsValid Then

                Dim pedido As New Pedido

                Dim lqtde As Decimal = CDec(txt_nrqtdeitem.Text)
                Dim lvl_unitario As Decimal = CDec(lbl_vl_unitario.Text)
                Dim lsacaria As Decimal = CDec(lbl_sacaria.Text)
                Dim lfrete As Decimal = CDec(lbl_frete.Text)

                pedido.nr_quantidade_total = CDec(txt_nrqtdeitem.Text)
                pedido.id_central_pedido_matriz = Convert.ToInt32(ViewState.Item("id_central_pedido_matriz"))
                pedido.id_modificador = Session("id_login")
                pedido.updatePedidoItemQtde()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.id_menu_item = 97
                usuariolog.ds_nm_processo = "Pedido - Quantidade"
                usuariolog.id_nr_processo = lbl_id_central_pedido.Text
                usuariolog.nm_nr_processo = lbl_id_central_pedido.Text

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f

                'loadGridItens()
                ViewState.Item("nr_quantidade_item") = CDec(txt_nrqtdeitem.Text)
                If ViewState.Item("id_grupo") = "2" Then
                    lbl_total_pedido.Text = FormatCurrency((lsacaria + lvl_unitario) * lqtde, 2)
                    If lbl_tipo_frete.Text = "FOB-D" Then
                        lbl_valor_frete.Text = FormatCurrency(lfrete * lqtde, 2)
                    End If
                Else
                    lbl_total_pedido_insumos.Text = FormatCurrency((lsacaria + lvl_unitario) * lqtde, 2)
                    lbl_total_pedido.Text = FormatCurrency(lfrete * lqtde, 2)
                End If
                txt_nrqtdeitem.ForeColor = System.Drawing.Color.FromName("#000000")

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_atualizar_frete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_atualizar_frete.Click
        Response.Redirect("frm_central_pedido_frete.aspx?id_central_pedido=" + ViewState.Item("id_central_pedido").ToString())

    End Sub

    Protected Sub btn_atualizar_parcela_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_atualizar_parcela.Click
        Try

            If Page.IsValid Then
                Dim lmsg As String = String.Empty
                Dim lbvalid As Boolean = True

                If ViewState.Item("st_parcelamento").ToString = "N" And CInt(txt_nrparcelas.Text) > 1 Then
                    lmsg = "Para o tipo de parcelamento 'N' o nr. de parcelas deve ser 1."
                    lbvalid = False
                End If

                If ViewState.Item("st_parcelamento").ToString = "D" And CInt(txt_nrparcelas.Text) > CInt(ViewState.Item("nr_politica_parcelas").ToString) Then
                    lmsg = String.Concat("Para o tipo de parcelamento 'D' o nr. de parcelas não pode ultrapassar ", ViewState.Item("nr_politica_parcelas").ToString, ", de acordo com a política de parcelamento Danone")
                    lbvalid = False
                End If

                If CInt(txt_nrparcelas.Text) = 1 And ViewState.Item("st_parcelamento").ToString <> "N" Then
                    lmsg = "Para 1 parcela o parcelamento deve ser 'N'"
                    lbvalid = False
                End If

                If lbvalid = True Then

                    Dim pedidoitem As New PedidoItem

                    pedidoitem.nr_parcelas = txt_nrparcelas.Text
                    pedidoitem.id_central_pedido_item = Convert.ToInt32(ViewState.Item("id_central_pedido_item"))
                    pedidoitem.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido"))

                    pedidoitem.updatePedidoItemParcelas()
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 97
                    usuariolog.ds_nm_processo = "Pedido - Parcelas"
                    usuariolog.id_nr_processo = lbl_id_central_pedido.Text
                    usuariolog.nm_nr_processo = lbl_id_central_pedido.Text

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f

                    txt_nrparcelas.ForeColor = System.Drawing.Color.FromName("#000000")
                    ViewState.Item("nr_parcelas") = txt_nrparcelas.Text
                Else
                    messageControl.Alert(lmsg)


                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cbo_parcelamento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_parcelamento.SelectedIndexChanged
        cbo_parcelamento.ForeColor = Drawing.Color.Red

    End Sub

    Protected Sub txt_nrparcelas_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nrparcelas.TextChanged
        txt_nrparcelas.ForeColor = Drawing.Color.Red
    End Sub

    Protected Sub txt_nrqtdeitem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nrqtdeitem.TextChanged
        txt_nrqtdeitem.ForeColor = Drawing.Color.Red
    End Sub

    Protected Sub lk_email_parceiro_frete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email_parceiro_frete.Click
        Dim lassunto As String
        Dim lcorpo As String
        Dim arqTemp As StreamReader
        Dim lcaminhoservidor As String = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString()
        'Dim lcaminhoservidor As String = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()
        Dim propriedade As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade").ToString))
        Dim produtor As New Pessoa(Convert.ToInt32(ViewState.Item("id_produtor").ToString))
        Dim fornecedor As New Pessoa(Convert.ToInt32(ViewState.Item("id_fornecedor_frete").ToString))
        Dim lemail_parceiro As String
        Dim lemail_parceiro2 As String = String.Empty 'fran fase 2 melhorias
        Dim ldatahj As Date = DateTime.Parse(Now).ToString("dd/MM/yyyy")
        Dim lstipofrete As String = String.Empty

        lemail_parceiro = fornecedor.ds_email
        If lemail_parceiro.Equals(String.Empty) Then
            If Not fornecedor.ds_email2 Is Nothing Then
                lemail_parceiro = fornecedor.ds_email2
            Else
                lemail_parceiro = String.Empty
            End If
            'fran fase 2 melhorias i se existe o primeiro email, busca o 2
        Else
            If Not fornecedor.ds_email2 Is Nothing Then 'se nao for nothing, joga o valor no para2
                lemail_parceiro2 = fornecedor.ds_email2
            End If
        End If
        'fran fase 2 melhorias f

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 9 'ENVIO EMAIL
        usuariolog.id_menu_item = 97
        usuariolog.id_nr_processo = ViewState.Item("id_central_pedido_frete").ToString
        usuariolog.nm_nr_processo = ViewState.Item("id_central_pedido_frete").ToString
        usuariolog.ds_nm_processo = "Pedidos - E-mail Parceiro Frete"
        usuariolog.insertUsuarioLog()
        'fran 08/12/2020 f

        'lemail_parceiro = "franoliveira@hotmail.com"
        If Not lemail_parceiro.Equals(String.Empty) Then
            lassunto = String.Concat("DANONE - Pedido de Compra ", "Nr ", ViewState.Item("id_central_pedido_frete").ToString, " - Produtor ", produtor.nm_abreviado)
            arqTemp = New StreamReader(lcaminhoservidor & "\central_pedido_email_fornecedor.HTML", Encoding.UTF7)
            lcorpo = ""
            Do While Not arqTemp.EndOfStream
                lcorpo = lcorpo & arqTemp.ReadLine
            Loop

            lcorpo = Replace(lcorpo, "$nm_estabelecimento", ViewState.Item("nm_estabelecimento").ToString)
            lcorpo = Replace(lcorpo, "$dt_hoje", String.Concat(Format(ldatahj, "dd").ToString, " de ", Format(ldatahj, "MMMM").ToString, " de ", Format(ldatahj, "yyyy").ToString & "."))
            lcorpo = Replace(lcorpo, "$id_pedido", ViewState.Item("id_central_pedido_frete").ToString)
            lcorpo = Replace(lcorpo, "$nm_fornecedor", fornecedor.nm_pessoa)
            lcorpo = Replace(lcorpo, "$ds_fornec_contato", fornecedor.ds_contato)
            lcorpo = Replace(lcorpo, "$email", fornecedor.ds_email)
            lcorpo = Replace(lcorpo, "$fone1", fornecedor.ds_telefone_1)
            lcorpo = Replace(lcorpo, "$fone2", fornecedor.ds_telefone_2)

            lcorpo = Replace(lcorpo, "$nm_produtor", produtor.nm_pessoa)
            lcorpo = Replace(lcorpo, "$cd_produtor", produtor.cd_pessoa)
            lcorpo = Replace(lcorpo, "$nm_propriedade", propriedade.nm_propriedade)
            lcorpo = Replace(lcorpo, "$id_propriedade", propriedade.id_propriedade)
            'lcorpo = Replace(lcorpo, "$nr_unid_producao", lbl_limite_disponivel.Text.ToString)
            'fran fase 2 melhorias i
            'lcorpo = Replace(lcorpo, "$bairro_produtor", produtor.ds_bairro)
            'lcorpo = Replace(lcorpo, "$cidade_produtor", produtor.nm_cidade)
            'lcorpo = Replace(lcorpo, "$nm_estado_produtor", produtor.nm_estado)
            lcorpo = Replace(lcorpo, "$bairro_produtor", propriedade.ds_bairro)
            lcorpo = Replace(lcorpo, "$cidade_produtor", propriedade.nm_cidade)
            lcorpo = Replace(lcorpo, "$nm_estado_produtor", propriedade.nm_estado)
            'fran fase 2 melhorias 2

            If produtor.st_categoria = "F" Then
                lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cpf)
            Else
                lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cnpj)
            End If
            'fran fase 2 melhorias i
            'lcorpo = Replace(lcorpo, "$inscrestadualprodutor", produtor.cd_inscricao_estadual)
            'lcorpo = Replace(lcorpo, "$ds_contato", produtor.ds_contato)
            lcorpo = Replace(lcorpo, "$inscrestadualprodutor", propriedade.cd_inscricao_estadual)
            lcorpo = Replace(lcorpo, "$ds_contato", propriedade.ds_contato)
            'fran fase 2 melhorias f
            lcorpo = Replace(lcorpo, "$prodfone3", produtor.ds_telefone_1)
            lcorpo = Replace(lcorpo, "$prodfone4", produtor.ds_telefone_2)

            lcorpo = Replace(lcorpo, "$tipopagamento", "À Vista.")

            'If ViewState.Item("st_parcelamento") = "N" OrElse ViewState.Item("nr_parcelas").ToString = "0" OrElse ViewState.Item("nr_parcelas").ToString = "1" OrElse ViewState.Item("st_parcelamento") = "D" Then
            '    lcorpo = Replace(lcorpo, "$tipopagamento", "À Vista.")
            'Else
            '    If ViewState.Item("st_parcelamento") = "P" Then
            '        lcorpo = Replace(lcorpo, "$tipopagamento", String.Concat("Parcelado em ", ViewState.Item("nr_parcelas").ToString, " X."))
            '    End If
            'End If

            Dim pedido As New Pedido
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido_frete"))
            Dim dsgrid As DataSet = pedido.getCentralPedidoEmailParceiroItens()
            Dim row As DataRow
            Dim ltable As String = String.Empty
            Dim i As Integer = 1
            For Each row In dsgrid.Tables(0).Rows
                If i > 1 Then
                    ltable = ltable & "<tr><td style='width: 20px; height: 15px;'>&nbsp;</td><td style='width: 27px; height: 15px;'>&nbsp;</td><td colspan='2' style='height: 15px'>&nbsp;</td><td colspan='4' style='height: 15px'>&nbsp;</td></tr>"
                End If
                ltable = "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td style='width: 27px; font-weight: bold; height: 17px;'>2." & i.ToString & ".</td>"
                ltable = ltable & "<td colspan='6' style='font-weight: bold; height: 17px'>" & row.Item("nm_item").ToString & "</td>"
                ltable = ltable & "</tr>"

                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style=' height: 17px;'>Quantidade:</td>"
                'fran 09/11/2011 chamado 1132 i
                'ltable = ltable & "<td colspan='4' style='height: 17px'>" & CInt(row.Item("nr_quantidade")).ToString & " " & row.Item("nm_unidade_medida").ToString & "</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatNumber(row.Item("nr_quantidade"), 2).ToString & " " & row.Item("nm_unidade_medida").ToString & "</td>"
                'fran 09/11/2011 chamado 1132 f
                ltable = ltable & "</tr>"
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Embalagem:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & row.Item("ds_tipo_medida").ToString & "</td>"
                ltable = ltable & "</tr>"

                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Frete:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_frete"), 2).ToString & "</td>"
                ltable = ltable & "</tr>"

                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Valor Total:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_valor_total"), 2).ToString & "</td>"
                ltable = ltable & "</tr>"

                'fran 08/2015 i melhorias relatorios
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Tipo Frete:</td>"
                lstipofrete = row.Item("ds_tipo_frete").ToString
                Select Case row.Item("ds_tipo_frete").ToString
                    Case "D"
                        lstipofrete = "FOB-D"
                    Case "C"
                        lstipofrete = "CIF"
                    Case "I"
                        lstipofrete = "FOB-I"

                End Select
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & lstipofrete & "</td>"
                ltable = ltable & "</tr>"

                'If CInt(ViewState.Item("id_grupo")) = 3 Then 'se o fornecedor for transportador de frete exibe o nome do parceiro de compra 
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Parceiro:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & row.Item("nm_parceiro_compra").ToString & "</td>"
                ltable = ltable & "</tr>"
                'End If
                'fran 08/2015 f melhorias relatorios


                'lcorpo = Replace(lcorpo, "$itens", i.ToString)
                i = i + 1
            Next
            Dim lentrega As String = String.Empty
            'Foi implementado um combo em cotação, no grid de itens, prazo de pagto. Vamos substituir as datas de pagamento pelo texto do combo
            'Dim lpagtofornec As String = String.Empty
            'i = 1
            'For Each row In dsgrid.Tables(0).Rows
            '    lpagtofornec = lpagtofornec & "<tr><td style='width: 20px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
            '    If CInt(ViewState.Item("id_grupo")) = 3 Then 'se o fornecedor for transportador de frete o item é 3.1 pois não há entrega
            '        lpagtofornec = lpagtofornec & "<td style='width: 35px; '>3.1." & i.ToString & "</td>"
            '    Else
            '        lpagtofornec = lpagtofornec & "<td style='width: 35px; '>3.2." & i.ToString & "</td>"
            '    End If
            '    lpagtofornec = lpagtofornec & "<td colspan='2' >Item " & row.Item("nm_item").ToString & ":</td>"
            '    'fran 06/2019 - se parcelamento parceuiro deve informar as parcelas
            '    If CInt(ViewState.Item("id_grupo")) <> 3 AndAlso row.Item("st_parcelamento").ToString.Equals("P") AndAlso CInt(row.Item("nr_parcelas").ToString) > 1 Then
            '        lpagtofornec = lpagtofornec & "<td colspan='3' >" & row.Item("nm_central_prazo_pagto").ToString & " em " & row.Item("nr_parcelas").ToString & " Parcelas</td>"
            '    Else
            '        lpagtofornec = lpagtofornec & "<td colspan='3' >" & row.Item("nm_central_prazo_pagto").ToString & "</td>"
            '    End If
            '    lpagtofornec = lpagtofornec & "</tr>"
            '    i = i + 1
            'Next
            'fran 01/2014 fase 2 melhorias f

            lcorpo = Replace(lcorpo, "$dsgriditens", ltable.ToString)
            'lcorpo = Replace(lcorpo, "$dspagtofornec", lpagtofornec.ToString)
            'lcorpo = Replace(lcorpo, "$dsentrega", lentrega.ToString)
            lcorpo = Replace(lcorpo, "ecxtextosmall", "textosmall")
            'lcorpo = Replace(lcorpo, "$itemcondgerais", i)
            'lcorpo = Replace(lcorpo, "$itemaprov", i + 1)

            'fran envio email datas i
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido_frete"))
            pedido.id_modificador = Session("id_login")
            'fran envio email datas f


            Dim notificacao As New Notificacao
            arqTemp.Close()
            'fran 24/08/2010 i chamado 931
            'If notificacao.enviaMensagemEmail(lassunto, lcorpo, "recepcao.de.leite-pocos@danone.com", lemail_parceiro, , MailPriority.High, True) = True Then
            'fran 14/01/2014 i fase 2 melhoria
            'If notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, , MailPriority.High, True) = True Then
            If notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, "central.compras@danone.com", MailPriority.High, True, lemail_parceiro2, False) = True Then
                'fran 14/01/2014 f fase 2 melhoria
                pedido.st_envio_email = "S"  'fran envio email datas i
                pedido.updateCentralPedidoDataEnvioEmail() 'fran envio email datas i

                'fran 24/08/2010 f chamado 931
                messageControl.Alert("Email ao parceiro de frete enviado com sucesso!")
            Else

                pedido.st_envio_email = "N"  'fran envio email datas i
                pedido.updateCentralPedidoDataEnvioEmail() 'fran envio email datas i

                messageControl.Alert("Email ao parceiro de frete não foi enviado com sucesso!")

            End If
        Else
            Dim pedido As New Pedido
            pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido_frete"))
            pedido.st_envio_email = "E"  'indica que Nao tem email no cadstro fran envio email datas i
            pedido.id_modificador = Session("id_login")
            pedido.updateCentralPedidoDataEnvioEmail() 'fran envio email datas i

            messageControl.Alert("O email não pode ser enviado pois não há nenhum email informado no cadastrado do Parceiro de Frete!")
        End If

    End Sub
End Class