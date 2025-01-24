Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail
Imports System.IO


Partial Class frm_central_solicitar_cotacao
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_central_solicitar_cotacao.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With
        With btn_lupa_item
            .Attributes.Add("onclick", "javascript:ShowDialogItem()")
            .ToolTip = "Filtrar Item"
        End With

    End Sub

    Private Sub loadDetails()

        Try
            Dim estabel As New Estabelecimento

            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim parametroMilk As New Parametro
            ViewState.Item("nr_politica_parcelas") = parametroMilk.nr_politica_parcelas 'fase 3


            If Not (Request("id_central_cotacao") Is Nothing) Then
                ViewState.Item("id_central_cotacao") = Request("id_central_cotacao")
                'carrega cotações
                table_body.Visible = True
                tr_header1.Visible = True
                tr_header2.Visible = True
                tr_header3.Visible = True 'fran fase 2 melhorias
                tr_headercontrato.Visible = True 'DANGO 2018
                tr_abrir_cot.Visible = False
                btn_abrir_cotacao.Visible = False
                loadData()
            Else
                ViewState.Item("id_central_cotacao") = "0"
                table_body.Visible = False
                tr_header1.Visible = False
                tr_header2.Visible = False
                tr_header3.Visible = False 'fran fase 2 melhorias
                tr_headercontrato.Visible = False 'DANGO 2018
                tr_abrir_cot.Visible = True
                btn_abrir_cotacao.Visible = True
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()

        Try
            Dim cotacao As New Cotacao()
            cotacao.id_central_cotacao = Convert.ToInt32(ViewState.Item("id_central_cotacao"))
            Dim dscotacao As DataSet = cotacao.getCotacaoByFilters
            With dscotacao.Tables(0).Rows(0)
                lbl_id_central_cotacao.Text = .Item("id_central_cotacao")
                lbl_dt_cotacao.Text = .Item("dt_cotacao")
                cbo_estabelecimento.SelectedValue = .Item("id_estabelecimento")
                cbo_estabelecimento.Enabled = False
                'fran fase 3 i
                cbo_pedido_indireto.SelectedValue = .Item("st_pedido_indireto")
                cbo_pedido_indireto.Enabled = False
                'fran fase 3 f
                txt_id_propriedade.Text = .Item("id_propriedade")
                txt_id_propriedade.Enabled = False
                ViewState.Item("id_propriedade") = .Item("id_propriedade").ToString
                'fran chamado 556 i
                ViewState.Item("id_cidade_propriedade") = .Item("id_cidade").ToString
                ViewState.Item("id_estado_propriedade") = .Item("id_estado").ToString
                hf_id_propriedade.Value = ViewState.Item("id_propriedade").ToString
                'fran chamado 556 f
                loadUnidProducaobyPropriedade()
                btn_lupa_propriedade.Visible = False
                lbl_nm_propriedade.Text = .Item("nm_propriedade")
                cbo_unid_producao.SelectedValue = .Item("id_unid_producao")
                cbo_unid_producao.Enabled = False
                lbl_nm_cidade.Text = .Item("nm_cidade")
                lbl_cd_uf.Text = .Item("cd_uf")
                lbl_ds_contato.Text = .Item("ds_contato")
                lbl_ds_email.Text = .Item("ds_email")
                lbl_ds_telefone.Text = .Item("ds_telefone_1")
                lbl_ds_fax.Text = .Item("ds_telefone_fax")
                lbl_nm_produtor.Text = String.Concat(.Item("cd_pessoa"), " - ", .Item("nm_pessoa"))
                lbl_cluster.Text = .Item("nm_cluster") 'fase 3 melhoria
                lbl_acordo_aquisicao_insumos.Text = .Item("ds_acordo_aquisicao_insumos") 'fase 3 melhoria
                lbl_situacao_cotacao.Text = .Item("nm_situacao_cotacao").ToString
                ViewState.Item("id_situacao_cotacao") = .Item("id_situacao_cotacao")
                lbl_nr_valor_total_cotacao.Text = FormatCurrency(.Item("nr_total_cotacao"), 2)
                lbl_nr_valor_disponivel.Text = FormatCurrency(.Item("nr_limite_disponivel"), 2)
                'fran fase 2 melhorias i
                If Not IsDBNull(.Item("nr_valor_mensal_estimado")) Then
                    lbl_nr_valor_mensal_estimado.Text = FormatCurrency(.Item("nr_valor_mensal_estimado"), 2)
                Else
                    lbl_nr_valor_mensal_estimado.Text = FormatCurrency(0, 2)
                End If
                If .Item("st_saldo_romaneio_aberto").ToString = "S" Then
                    lbl_informativo.Visible = True
                Else
                    lbl_informativo.Visible = False
                End If

                'Calcula % mensal
                If CDec(lbl_nr_valor_mensal_estimado.Text) > 0 Then
                    lbl_nr_perc_valor_estimado.Text = FormatPercent((CDec(lbl_nr_valor_total_cotacao.Text) / CDec(lbl_nr_valor_mensal_estimado.Text)), 2)
                End If
                'fran fase 2 melhorias i

                'Calcula %
                If CDec(lbl_nr_valor_disponivel.Text) > 0 Then
                    lbl_nr_perc.Text = FormatPercent((CDec(lbl_nr_valor_total_cotacao.Text) / CDec(lbl_nr_valor_disponivel.Text)), 2)
                End If

            End With

            'fran i fase 2 melhorias
            Dim propriedade As New Propriedade(Convert.ToInt32(txt_id_propriedade.Text))
            lbl_nm_tecnico_danone.Text = String.Concat(Propriedade.id_tecnico.ToString, " - ", Propriedade.nm_tecnico)
            lbl_nm_tecnico_educampo.Text = String.Concat(Propriedade.id_tecnico_educampo.ToString, " - ", Propriedade.nm_tecnico_educampo)

            'Pedidos em aberto
            Dim pedido As New Pedido
            pedido.id_propriedade = txt_id_propriedade.Text
            lbl_nr_total_pedidos_abertos.Text = pedido.getTotalPedidosAbertos.ToString
            If CInt(lbl_nr_total_pedidos_abertos.Text) > 0 Then
                hl_nr_total_pedidos_abertos.Visible = True
                hl_nr_total_pedidos_abertos.Text = FormatCurrency(lbl_nr_total_pedidos_abertos.Text, 2)
                hl_nr_total_pedidos_abertos.NavigateUrl = String.Format("frm_central_pedidos_abertos.aspx?id_propriedade={0}", pedido.id_propriedade)
                lbl_nr_total_pedidos_abertos.Visible = False
            Else
                lbl_nr_total_pedidos_abertos.Text = FormatCurrency(0, 2)
                hl_nr_total_pedidos_abertos.Visible = False
                lbl_nr_total_pedidos_abertos.Visible = True
            End If

            'fran f fase 2 melhorias
            'fran dango 2018 i
            Dim pessoacontrato As New PessoaContrato
            pessoacontrato.id_pessoa = Convert.ToInt32(propriedade.id_pessoa)
            Dim dspessoacontrato As DataSet = PessoaContrato.getPessoaContratoByFilters()

            If (dspessoacontrato.Tables(0).Rows.Count > 0) Then
                With dspessoacontrato.Tables(0).Rows(0)

                    lbl_contrato.Text = String.Concat(.Item("cd_contrato").ToString, " - ", .Item("nm_contrato").ToString)
                    If Not IsDBNull(.Item("dt_inicio_contrato")) Then
                        lbl_dt_ini_contrato.Text = DateTime.Parse(.Item("dt_inicio_contrato").ToString).ToString("dd/MM/yyyy")
                    End If

                    If Not IsDBNull(dspessoacontrato.Tables(0).Rows(0).Item("dt_fim_contrato")) Then
                        lbl_dt_fim_contrato.Text = DateTime.Parse(.Item("dt_fim_contrato").ToString).ToString("dd/MM/yyyy")
                    End If

                    If Not IsDBNull(dspessoacontrato.Tables(0).Rows(0).Item("dt_rescisao")) Then
                        lbl_dt_rescisao_contrato.Text = DateTime.Parse(.Item("dt_rescisao").ToString).ToString("dd/MM/yyyy")
                    End If

                End With
            Else
                lbl_contrato.Text = String.Empty
                lbl_dt_ini_contrato.Text = String.Empty
                lbl_dt_fim_contrato.Text = String.Empty
                lbl_dt_rescisao_contrato.Text = String.Empty
            End If
            'fran dango 2018 f

            'se situcao for 3 (em aprovacao), 4(recusado), 5(aprovado), 6(finaloizado) ou 7 Cancelado
            'não deixa mais atualizar dados da cotação
            If CInt(dscotacao.Tables(0).Rows(0).Item("id_situacao_cotacao").ToString) >= 3 And CInt(dscotacao.Tables(0).Rows(0).Item("id_situacao_cotacao").ToString) <= 7 Then
                gridItens.Columns.Item(15).Visible = False
                gridCotacoes.Columns.Item(14).Visible = False 'edição
                gridCotacoes.Columns.Item(13).Visible = True 'situacao fornecedor
                btn_adicionar_cotacao.Enabled = False
                btn_novo_item.Enabled = False
                lk_enviar_aprovacao.Enabled = False

                If CInt(dscotacao.Tables(0).Rows(0).Item("id_situacao_cotacao").ToString) = 3 Then
                    lk_notificar_aprovadores.Visible = True
                    img_notificacao.Visible = True
                    lk_notificar_aprovadores.Enabled = True
                End If

                If CInt(dscotacao.Tables(0).Rows(0).Item("id_situacao_cotacao").ToString) = 6 Or CInt(dscotacao.Tables(0).Rows(0).Item("id_situacao_cotacao").ToString) = 7 Then
                    lk_gerar_pedido.Enabled = False
                    'fran fase 3 08/2014  i 
                    gridItens.Columns.Item(13).Visible = True 'id_pedido
                    'fran fase 3 08/2014  f
                    gridItens.Columns.Item(14).Visible = True 'id_pedido frete fran 08/2015 i

                End If


            Else
                'Cálcula saldo
                Dim saldodisponivel As New SaldoDisponivel
                saldodisponivel.dt_referencia = String.Concat("01/" & Format(DateTime.Parse(Now), "MM/yyyy").ToString)
                saldodisponivel.id_propriedade = Convert.ToInt32(txt_id_propriedade.Text)
                'fran i fase 2 melhorias
                'lbl_nr_valor_disponivel.Text = FormatNumber(saldodisponivel.getSaldoDisponivel(), 2)
                lbl_nr_valor_disponivel.Text = FormatNumber(saldodisponivel.getSaldoDisponivel(True), 2)
                If saldodisponivel.st_saldo_romaneio_aberto = True Then
                    lbl_informativo.Visible = True
                Else
                    lbl_informativo.Visible = False

                End If
                lbl_nr_valor_mensal_estimado.Text = saldodisponivel.nr_valor_faturamento  ' NOVO

                'fran f fase 2 melhorias

                'Atualiza totalizadores da cotação
                AtualizarTotalizadores()
                'Atualiza link aprovacao
                AtualizarLinkEnviarAprovacao()

            End If

            loadGridItens()
            loadGridCotacoes()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub



    Private Sub updateDataCotacao()
        If Page.IsValid Then

            Try

                Dim Cotacao As New Cotacao()
                Cotacao.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                Cotacao.st_pedido_indireto = cbo_pedido_indireto.SelectedValue.ToString 'fran fase 3
                Cotacao.id_propriedade = Convert.ToInt32(txt_id_propriedade.Text)
                Cotacao.id_unid_producao = Convert.ToInt32(cbo_unid_producao.SelectedValue)
                Cotacao.id_modificador = Session("id_login")
                Cotacao.id_central_cotacao = Cotacao.insertCotacao()

                ViewState.Item("id_central_cotacao") = Cotacao.id_central_cotacao


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_central_solicitar_cotacao.aspx")



    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_central_solicitar_cotacao.aspx")


    End Sub




    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_central_solicitar_cotacao.aspx")


    End Sub

    Private Sub carregarCamposPropriedade()

        Try



            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                carregarCamposPropriedadeProdutor(Convert.ToInt32(Me.hf_id_propriedade.Value.ToString))
                ViewState.Item("id_propriedade") = Me.hf_id_propriedade.Value.ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click

        carregarCamposPropriedade()
        'carrega combo unid produção
        loadUnidProducaobyPropriedade()
        carregarCamposPropriedadeProdutor(Convert.ToInt32(ViewState.Item("id_propriedade").ToString))

    End Sub
    Private Sub loadUnidProducaobyPropriedade()

        Try

            Dim up As New UnidadeProducao
            up.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            cbo_unid_producao.DataSource = up.getUnidadeProducaoByFilters
            cbo_unid_producao.DataTextField = "nr_unid_producao"
            cbo_unid_producao.DataValueField = "id_unid_producao"
            cbo_unid_producao.DataBind()
            cbo_unid_producao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            If cbo_unid_producao.Items.Count > 1 Then
                cbo_unid_producao.SelectedIndex = 1 'fran fase 2 melhoria
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_id_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_propriedade.TextChanged
        lbl_nm_propriedade.Text = String.Empty
        lbl_nm_propriedade.Visible = False
        hf_id_propriedade.Value = String.Empty
        ViewState.Item("id_propriedade") = 0
        'se propriedade é valida
        If Not txt_id_propriedade.Text.ToString.Equals(String.Empty) Then
            If validarPropriedade.Tables(0).Rows.Count > 0 Then
                ViewState.Item("id_propriedade") = txt_id_propriedade.Text.Trim
                hf_id_propriedade.Value = txt_id_propriedade.Text.Trim
                carregarCamposPropriedadeProdutor(Convert.ToInt32(txt_id_propriedade.Text.Trim))
                loadUnidProducaobyPropriedade()
            End If
        Else
            'fran 05/05/2010 i
            lbl_cd_uf.Text = String.Empty
            lbl_nm_cidade.Text = String.Empty
            lbl_nm_produtor.Text = String.Empty
            lbl_ds_contato.Text = String.Empty
            lbl_ds_telefone.Text = String.Empty
            lbl_ds_email.Text = String.Empty
            lbl_ds_fax.Text = String.Empty
            'cbo_unid_producao.SelectedValue = String.Empty
            cbo_unid_producao.Items.Clear()
            'fran 05/05/2010 f

        End If

    End Sub
    Private Function validarPropriedade() As DataSet

        Try

            Dim propriedade As New Propriedade()

            propriedade.id_propriedade = Trim(txt_id_propriedade.Text)

            validarPropriedade = propriedade.getPropriedadeByFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function
    Private Sub carregarCamposPropriedadeProdutor(ByVal id_propriedade As Int32)
        Try
            Dim propriedade As New Propriedade(id_propriedade)
            Dim produtor As New Pessoa(propriedade.id_pessoa)

            Me.txt_id_propriedade.Text = id_propriedade
            Me.lbl_nm_propriedade.Visible = True
            Me.lbl_nm_propriedade.Text = propriedade.nm_propriedade
            lbl_cd_uf.Text = propriedade.cd_uf
            lbl_nm_cidade.Text = propriedade.nm_cidade
            lbl_nm_produtor.Text = String.Concat(produtor.cd_pessoa, " - ", produtor.nm_pessoa)
            lbl_ds_contato.Text = produtor.ds_contato
            lbl_ds_telefone.Text = produtor.ds_telefone_1
            lbl_ds_email.Text = produtor.ds_email
            lbl_ds_fax.Text = produtor.ds_telefone_3
            'fran 12/2013 - fase 2 I
            lbl_nm_tecnico_danone.Text = String.Concat(propriedade.id_tecnico.ToString, " - ", propriedade.nm_tecnico)
            lbl_nm_tecnico_educampo.Text = String.Concat(propriedade.id_tecnico_educampo.ToString, " - ", propriedade.nm_tecnico_educampo)
            'fran 12/2013 - fase 2 F

            'fran 08/2014  fase 3 i
            cbo_estabelecimento.SelectedValue = propriedade.id_estabelecimento
            'fran 08/2014  fase 3 f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub btn_lupa_item_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_item.Click
        carregarcampositem()
        loadGridCotacoes()
    End Sub
    Private Sub carregarcampositem()
        Try

            If Not (customPage.getFilterValue("lupa_item", "id_item").Equals(String.Empty)) Then
                ViewState.Item("id_item_adicionar") = customPage.getFilterValue("lupa_item", "id_item").ToString
            End If
            If Not (customPage.getFilterValue("lupa_item", "cd_item").Equals(String.Empty)) Then
                Me.txt_cd_item.Text = customPage.getFilterValue("lupa_item", "cd_item").ToString
            End If

            If Not (customPage.getFilterValue("lupa_item", "nm_item").Equals(String.Empty)) Then

                Me.lbl_nm_item.Visible = True
                Me.lbl_nm_item.Text = customPage.getFilterValue("lupa_item", "nm_item").ToString
            End If
            'If Not (customPage.getFilterValue("lupa_item", "cd_unidade_medida").Equals(String.Empty)) Then
            'Me.lbl_unidade_medida.Text = customPage.getFilterValue("lupa_item", "cd_unidade_medida").ToString
            'End If
            customPage.clearFilters("lupa_item")

            'btn_novo_item.Enabled = False
            'gridparceiro_item.Visible = False

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_abrir_cotacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_abrir_cotacao.Click
        If Page.IsValid Then
            Try
                updateDataCotacao()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 92
                usuariolog.id_nr_processo = ViewState.Item("id_central_cotacao").ToString
                usuariolog.nm_nr_processo = ViewState.Item("id_central_cotacao").ToString

                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Response.Redirect("frm_central_solicitar_cotacao.aspx?id_central_cotacao=" + ViewState.Item("id_central_cotacao").ToString)

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub btn_novo_item_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_item.Click
        If Page.IsValid Then

            ViewState.Item("btnnovoitem") = "S"
            Dim itens As New CotacaoItem
            itens.id_central_cotacao = Convert.ToInt32(ViewState.Item("id_central_cotacao").ToString)
            itens.id_item = Convert.ToInt32(ViewState.Item("id_item_adicionar"))
            itens.id_modificador = Session("id_login")
            itens.insertCotacaoItem()
            LimparSelecaoGridItens()

            'Dim lbl_ds_tipo_medida As Label = CType(gridItens.Rows(e.NewEditIndex).FindControl("lbl_ds_tipo_medida"), Label)
            'ViewState.Item("label_tipo_medida") = Trim(lbl_ds_tipo_medida.Text)

            'Dim lbl_vai_parcelar As Label = CType(gridItens.Rows(e.NewEditIndex).FindControl("lbl_vai_parcelar"), Label)
            'ViewState.Item("label_vai_parcelar") = Trim(lbl_vai_parcelar.Text)
            'Dim st_ver_mercado As Label = CType(gridItens.Rows(e.NewEditIndex).FindControl("st_ver_mercado"), Label)
            'ViewState.Item("label_st_ver_mercado") = Trim(st_ver_mercado.Text)
            'Dim st_produtor_informado As Label = CType(gridItens.Rows(e.NewEditIndex).FindControl("st_produtor_informado"), Label)
            'ViewState.Item("label_st_produtor_informado") = Trim(st_produtor_informado.Text)


            gridItens.EditIndex = gridItens.Rows.Count
            ViewState.Item("label_prazo_pagto") = String.Empty

            loadGridItens()
            loadGridCotacoes()
            ViewState.Item("incluirlinha") = Nothing
            ViewState.Item("id_item_adicionar") = Nothing
            ViewState.Item("label_prazo_pagto") = Nothing

            txt_cd_item.Text = String.Empty
            lbl_nm_item.Text = String.Empty
        End If
    End Sub

    Protected Sub gridItens_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridItens.PageIndexChanging
        gridItens.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridItens_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridItens.RowCancelingEdit

        Try

            gridItens.EditIndex = -1
            loadGridItens()
            loadGridCotacoes()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridItens_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridItens.RowCommand
        Select Case e.CommandName.ToString().ToLower()
            Case "cotacoes"

                If gridItens.EditIndex = -1 Then

                    Dim lbl_id_central_cotacao_item As Label = CType(gridItens.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_central_cotacao_item"), Label)
                    Dim lbl_item As Label = CType(gridItens.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_item"), Label)
                    Dim lbl_nr_quantidade As Label = CType(gridItens.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_nr_quantidade"), Label)
                    Dim cd_item As DataControlFieldCell = CType(gridItens.Rows.Item(e.CommandArgument.ToString).Cells(1), DataControlFieldCell)
                    Dim nm_item As DataControlFieldCell = CType(gridItens.Rows.Item(e.CommandArgument.ToString).Cells(2), DataControlFieldCell)
                    Dim st_ver_mercado As Label = CType(gridItens.Rows.Item(e.CommandArgument.ToString).FindControl("st_ver_mercado"), Label)
                    Dim lbl_ds_tipo_medida As Label = CType(gridItens.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_ds_tipo_medida"), Label)   ' Adriana 16/06/2010 - chamado 870
                    ViewState.Item("id_central_cotacao_item") = lbl_id_central_cotacao_item.Text
                    ViewState.Item("lbl_detalhe_item") = String.Concat(cd_item.Text, " - ", nm_item.Text)
                    ViewState.Item("id_item") = lbl_item.Text
                    ViewState.Item("nr_quantidade_item") = lbl_nr_quantidade.Text
                    ViewState.Item("st_ver_mercado") = st_ver_mercado.Text
                    ViewState.Item("ds_tipo_medida") = lbl_ds_tipo_medida.Text   ' Adriana 16/06/2010 - chamado 870
                    If ViewState.Item("id_situacao_cotacao") < 3 Then
                        btn_adicionar_cotacao.Enabled = True
                    End If
                    loadGridItens()
                End If
                loadGridCotacoes()

            Case "delete"
                    deleteItemCotacao(Convert.ToInt32(e.CommandArgument.ToString()))


        End Select



    End Sub

    Protected Sub gridItens_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridItens.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btn_detalhe_item As ImageButton = CType(e.Row.FindControl("btn_detalhe_item"), ImageButton)
                btn_detalhe_item.CommandArgument = e.Row.RowIndex.ToString
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            Try
                If Not (ViewState.Item("label_tipo_medida") Is Nothing) Then
                    Dim cbo_tipo_medida As DropDownList = CType(e.Row.FindControl("cbo_tipo_medida"), DropDownList)

                    If Not (ViewState.Item("label_tipo_medida").ToString.Equals(String.Empty)) Then
                        cbo_tipo_medida.SelectedValue = cbo_tipo_medida.Items.FindByText(ViewState.Item("label_tipo_medida").Trim.ToString).Value
                        ViewState.Item("label_tipo_medida") = Nothing

                    End If
                End If
                If Not (ViewState.Item("label_vai_parcelar") Is Nothing) Then
                    Dim cbo_vai_parcelar As DropDownList = CType(e.Row.FindControl("cbo_vai_parcelar"), DropDownList)
                    If Not (ViewState.Item("label_vai_parcelar").ToString.Equals(String.Empty)) Then
                        cbo_vai_parcelar.SelectedValue = cbo_vai_parcelar.Items.FindByText(ViewState.Item("label_vai_parcelar").Trim.ToString).Value
                        ViewState.Item("label_vai_parcelar") = Nothing
                    End If

                End If
                If Not (ViewState.Item("label_st_ver_mercado") Is Nothing) Then
                    Dim chk_ver_mercado As CheckBox = CType(e.Row.FindControl("chk_ver_mercado"), CheckBox)
                    If Not (ViewState.Item("label_st_ver_mercado").ToString.Equals(String.Empty)) Then
                        If ViewState.Item("label_st_ver_mercado").ToString = "S" Then
                            chk_ver_mercado.Checked = True
                        Else
                            chk_ver_mercado.Checked = False
                        End If
                        ViewState.Item("label_st_ver_mercado") = Nothing
                    End If

                End If

                If Not (ViewState.Item("label_st_produtor_informado") Is Nothing) Then
                    Dim chk_produtor_informado As CheckBox = CType(e.Row.FindControl("chk_produtor_informado"), CheckBox)
                    If Not (ViewState.Item("label_st_produtor_informado").ToString.Equals(String.Empty)) Then
                        If ViewState.Item("label_st_produtor_informado").ToString = "S" Then
                            chk_produtor_informado.Checked = True
                        Else
                            chk_produtor_informado.Checked = False
                        End If
                        ViewState.Item("label_st_produtor_informado") = Nothing
                    End If

                End If
                'fran fase 2 melhorias i
                If Not (ViewState.Item("label_prazo_pagto") Is Nothing) Then

                    Dim prazopagto As New PrazoPagto
                    Dim cbo_prazo_pagto As DropDownList = CType(e.Row.FindControl("cbo_prazo_pagto"), DropDownList)

                    prazopagto.id_central_prazo_pagto = ViewState.Item("id_central_prazo_pagto")
                    cbo_prazo_pagto.DataSource = prazopagto.getPrazoPagtoByFilters()
                    cbo_prazo_pagto.DataTextField = "nm_central_prazo_pagto"
                    cbo_prazo_pagto.DataValueField = "id_central_prazo_pagto"
                    cbo_prazo_pagto.DataBind()

                    If (ViewState.Item("label_prazo_pagto").ToString.Equals(String.Empty)) Then
                        cbo_prazo_pagto.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState.Item("label_prazo_pagto") = "SEM_VALOR"
                    Else
                        cbo_prazo_pagto.SelectedValue = cbo_prazo_pagto.Items.FindByText(ViewState.Item("label_prazo_pagto").Trim.ToString).Value
                        ViewState.Item("label_prazo_pagto") = Nothing
                    End If
                End If
                'fran fase 2 melhorias 2

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub gridItens_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridItens.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then

                If (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
                    Dim txt_nr_quantidade As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_quantidade"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim cbo_prazo_pagto As DropDownList = CType(e.Row.FindControl("cbo_prazo_pagto"), DropDownList)

                    If CDbl(txt_nr_quantidade.Text) = 0 Then
                        txt_nr_quantidade.Text = String.Empty
                    End If
                    'fran 08/02/2010 i
                    Dim lbl_dt_entrega As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(e.Row.FindControl("txt_dt_entrega"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox) 'fran 08/02/2010 i
                    If Not lbl_dt_entrega.Text = String.Empty Then
                        'lbl_dt_entrega.Text = Left(lbl_dt_entrega.Text.Trim, 10)
                        lbl_dt_entrega.Text = DateTime.Parse(lbl_dt_entrega.Text.Trim).ToString("dd/MM/yyyy")
                    End If
                    'fran 08/02/2010 f
                   
                    If ViewState.Item("label_prazo_pagto") = "SEM_VALOR" Then
                        'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                        If Not (cbo_prazo_pagto Is Nothing) Then
                            cbo_prazo_pagto.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        End If
                        ViewState.Item("label_prazo_pagto") = Nothing

                    End If
                Else
                    Dim st_ver_mercado As Label = CType(e.Row.FindControl("st_ver_mercado"), Label)
                    Dim lbl_st_parcelamento As Label = CType(e.Row.FindControl("lbl_st_parcelamento"), Label) 'fran 08/2014 melhorias fase 3
                    Dim st_produtor_informado As Label = CType(e.Row.FindControl("st_produtor_informado"), Label)
                    Dim chk_ver_mercado As CheckBox = CType(e.Row.FindControl("chk_ver_mercado"), CheckBox)
                    Dim chk_produtor_informado As CheckBox = CType(e.Row.FindControl("chk_produtor_informado"), CheckBox)
                    Dim lbl_nr_parcelas As Label = CType(e.Row.FindControl("lbl_nr_parcelas"), Label)
                    Dim lbl_ds_tipo_medida As Label = CType(e.Row.FindControl("lbl_ds_tipo_medida"), Label)
                    Dim lbl_vai_parcelar As Label = CType(e.Row.FindControl("lbl_vai_parcelar"), Label)
                    Dim lbl_dt_entrega As Label = CType(e.Row.FindControl("lbl_dt_entrega"), Label) 'fran 08/02/2010 i
                    Dim lbl_id_central_cotacao_item As Label = CType(e.Row.FindControl("lbl_id_central_cotacao_item"), Label)
                    Dim lbl_nr_quantidade As Label = CType(e.Row.FindControl("lbl_nr_quantidade"), Label) 'fran 08/02/2010 i
                    If CInt(lbl_nr_parcelas.Text.Trim) > 0 Then
                        'fran 08/2014 Melhorias fase 3 i
                        'lbl_vai_parcelar.Text = "Sim"
                        If lbl_st_parcelamento.Text.Equals("D") Then
                            lbl_vai_parcelar.Text = "Danone"
                        End If
                        If lbl_st_parcelamento.Text.Equals("P") Then
                            lbl_vai_parcelar.Text = "Parceiro"
                        End If
                        'fran 08/2014 Melhorias fase 3 f

                    Else
                        lbl_vai_parcelar.Text = "Não"
                    End If
                    If lbl_ds_tipo_medida.Text = "G" Then
                        lbl_ds_tipo_medida.Text = "Granel"
                    End If
                    If lbl_ds_tipo_medida.Text = "S" Then
                        lbl_ds_tipo_medida.Text = "Sacaria"
                    End If
                    If lbl_ds_tipo_medida.Text = "O" Then
                        lbl_ds_tipo_medida.Text = "Outros"
                    End If

                    If st_ver_mercado.Text = "S" Then
                        chk_ver_mercado.Checked = True
                    Else
                        chk_ver_mercado.Checked = False
                    End If
                    If st_produtor_informado.Text = "S" Then
                        chk_produtor_informado.Checked = True
                    Else
                        chk_produtor_informado.Checked = False
                    End If
                    'fran 08/02/2010 i
                    If Not lbl_dt_entrega.Text = String.Empty Then
                        'lbl_dt_entrega.Text = Left(lbl_dt_entrega.Text.Trim, 10)
                        lbl_dt_entrega.Text = DateTime.Parse(lbl_dt_entrega.Text.Trim).ToString("dd/MM/yyyy")
                    End If
                    'fran 08/02/2010 f

                    If CLng(lbl_id_central_cotacao_item.Text) = CLng(ViewState.Item("id_central_cotacao_item")) Then
                        e.Row.ForeColor = Drawing.Color.Red
                        'fran 08/02/2010 i
                        lbl_ds_tipo_medida.ForeColor = Drawing.Color.Red
                        lbl_dt_entrega.ForeColor = Drawing.Color.Red
                        lbl_vai_parcelar.ForeColor = Drawing.Color.Red
                        lbl_nr_quantidade.ForeColor = Drawing.Color.Red
                        'fran 08/02/2010 f
                    Else
                        e.Row.ForeColor = System.Drawing.Color.FromName("#333333")
                        'fran 08/02/2010 i
                        lbl_ds_tipo_medida.ForeColor = System.Drawing.Color.FromName("#333333")
                        lbl_dt_entrega.ForeColor = System.Drawing.Color.FromName("#333333")
                        lbl_vai_parcelar.ForeColor = System.Drawing.Color.FromName("#333333")
                        lbl_nr_quantidade.ForeColor = System.Drawing.Color.FromName("#333333")
                        'fran 08/02/2010 f
                    End If

                End If
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadGridItens()



        Dim itens As New CotacaoItem
        itens.id_central_cotacao = ViewState.Item("id_central_cotacao").ToString
        'Dim dsItens As DataSet = itens.getCotacaoItensByFilters()
        Dim dsItens As DataSet = itens.getCotacaoItensGrid() 'fran fase 3

        If (dsItens.Tables(0).Rows.Count > 0) Then
            gridItens.Visible = True
            gridItens.DataSource = Helper.getDataView(dsItens.Tables(0), ViewState.Item("sortExpression"))
            gridItens.DataBind()
        Else
            'Dim dr As DataRow = dsItens.Tables(0).NewRow()
            'dsItens.Tables(0).Rows.InsertAt(dr, 0)
            'gridItens.Visible = True
            'gridItens.DataSource = Helper.getDataView(dsItens.Tables(0), ViewState.Item("sortExpression"))
            'gridItens.DataBind()

            'gridItens.Rows(0).Cells.Clear()
            'gridItens.Rows(0).Cells.Add(New TableCell())
            'gridItens.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            'gridItens.Rows(0).Cells(0).Text = "Não existe nenhum Item cadastrado para esta cotação ainda!"
            'gridItens.Rows(0).Cells(0).ColumnSpan = 10
            gridItens.Visible = False
        End If

    End Sub
    Private Sub loadGridCotacoes()


        Try

            If ViewState.Item("id_central_cotacao_item") Is Nothing Then
                ViewState.Item("id_central_cotacao_item") = 0
            End If
            'Carrega os dados do Grid
            Dim cotfornecedor As New CotacaoFornecedor
            If CLng(ViewState.Item("id_central_cotacao_item")) > 0 Then
                cotfornecedor.id_central_cotacao_item = Convert.ToInt32(ViewState.Item("id_central_cotacao_item"))
                lbl_detalhe_item.Text = ViewState.Item("lbl_detalhe_item").ToString

                Dim dsCotFornecedor As DataSet = cotfornecedor.getCotacaoFornecedorByFilters()

                If (dsCotFornecedor.Tables(0).Rows.Count > 0) Then
                    gridCotacoes.Visible = True
                    gridCotacoes.DataSource = Helper.getDataView(dsCotFornecedor.Tables(0), ViewState.Item("sortExpression"))
                    gridCotacoes.DataBind()
                Else
                    Dim dr As DataRow = dsCotFornecedor.Tables(0).NewRow()
                    dsCotFornecedor.Tables(0).Rows.InsertAt(dr, 0)
                    gridCotacoes.Visible = True
                    gridCotacoes.DataSource = Helper.getDataView(dsCotFornecedor.Tables(0), ViewState.Item("sortExpression"))
                    gridCotacoes.DataBind()
                    gridCotacoes.Rows(0).Cells.Clear()
                    gridCotacoes.Rows(0).Cells.Add(New TableCell())
                    gridCotacoes.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridCotacoes.Rows(0).Cells(0).Text = "Não existe ainda nenhuma cotação informada para o Item selecionado!"
                    gridCotacoes.Rows(0).Cells(0).ColumnSpan = 15

                End If
            Else
                cotfornecedor.id_central_cotacao_item = -1
                Dim dsCotFornecedor As DataSet = cotfornecedor.getCotacaoFornecedorByFilters()
                Dim dr As DataRow = dsCotFornecedor.Tables(0).NewRow()
                dsCotFornecedor.Tables(0).Rows.InsertAt(dr, 0)
                gridCotacoes.Visible = True
                gridCotacoes.DataSource = Helper.getDataView(dsCotFornecedor.Tables(0), ViewState.Item("sortExpression"))
                gridCotacoes.DataBind()
                gridCotacoes.Rows(0).Cells.Clear()
                gridCotacoes.Rows(0).Cells.Add(New TableCell())
                gridCotacoes.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridCotacoes.Rows(0).Cells(0).Text = "Selecione o detalhe do item para visualizar suas cotações."
                gridCotacoes.Rows(0).Cells(0).ColumnSpan = 11
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridItens_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridItens.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub gridItens_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridItens.RowEditing
        Try

            Dim lbl_ds_tipo_medida As Label = CType(gridItens.Rows(e.NewEditIndex).FindControl("lbl_ds_tipo_medida"), Label)
            ViewState.Item("label_tipo_medida") = Trim(lbl_ds_tipo_medida.Text)

            Dim lbl_vai_parcelar As Label = CType(gridItens.Rows(e.NewEditIndex).FindControl("lbl_vai_parcelar"), Label)
            ViewState.Item("label_vai_parcelar") = Trim(lbl_vai_parcelar.Text)
            Dim st_ver_mercado As Label = CType(gridItens.Rows(e.NewEditIndex).FindControl("st_ver_mercado"), Label)
            ViewState.Item("label_st_ver_mercado") = Trim(st_ver_mercado.Text)
            Dim st_produtor_informado As Label = CType(gridItens.Rows(e.NewEditIndex).FindControl("st_produtor_informado"), Label)
            ViewState.Item("label_st_produtor_informado") = Trim(st_produtor_informado.Text)

            'fram fase 2 melhorias i 
            Dim lbl_nm_prazo_pagto As Label = CType(gridItens.Rows(e.NewEditIndex).FindControl("lbl_nm_prazo_pagto"), Label)
            ViewState.Item("label_prazo_pagto") = Trim(lbl_nm_prazo_pagto.Text)
            'fram fase 2 melhorias f 

            'Dim lbl_alizarol As Label = CType(gridColetas.Rows(e.NewEditIndex).FindControl("lbl_alizarol"), Label)
            'ViewState.Item("label_alizarol") = Trim(lbl_alizarol.Text)
            LimparSelecaoGridItens()
            gridItens.EditIndex = e.NewEditIndex
            loadGridItens()
            loadGridCotacoes()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridItens_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridItens.RowUpdating
        Dim row As GridViewRow = gridItens.Rows(e.RowIndex)
        If Page.IsValid Then


            Try

                If (Not (row) Is Nothing) Then

                    Dim cotitem As New CotacaoItem
                    Dim cbo_tipo_medida As DropDownList = CType(row.FindControl("cbo_tipo_medida"), DropDownList)
                    Dim txt_nr_quantidade As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_quantidade"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_nr_parcelas As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_parcelas"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                    Dim chk_ver_mercado As CheckBox = CType(row.FindControl("chk_ver_mercado"), CheckBox)
                    Dim chk_produtor_informado As CheckBox = CType(row.FindControl("chk_produtor_informado"), CheckBox)
                    Dim lbl_id_central_cotacao_item As Label = CType(row.FindControl("lbl_id_central_cotacao_item"), Label)
                    Dim txt_dt_entrega As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_entrega"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox) 'fran chamado 602
                    Dim cbo_prazo_pagto As DropDownList = CType(row.FindControl("cbo_prazo_pagto"), DropDownList)
                    Dim cbo_vai_parcelar As DropDownList = CType(row.FindControl("cbo_vai_parcelar"), DropDownList) 'Fran fase 3 21/08/2014

                    'If Not (cbo_placa.SelectedValue.Trim().Equals(String.Empty)) Then
                    '    caderneta.ds_placa = cbo_placa.SelectedValue
                    'End If

                    cotitem.ds_tipo_medida = cbo_tipo_medida.SelectedValue
                    cotitem.nr_quantidade = Convert.ToDecimal(txt_nr_quantidade.Text)
                    If txt_nr_parcelas.Text.Equals(String.Empty) Then
                        cotitem.nr_parcelas = 0
                    Else
                        cotitem.nr_parcelas = Convert.ToInt32(txt_nr_parcelas.Text)
                    End If

                    cotitem.st_parcelamento = cbo_vai_parcelar.SelectedValue 'Fran fase 3 21/08/2014

                    If chk_ver_mercado.Checked = True Then
                        cotitem.st_ver_mercado = "S"
                    Else
                        cotitem.st_ver_mercado = "N"
                    End If
                    If chk_produtor_informado.Checked = True Then
                        cotitem.st_produtor_informado = "S"
                    Else
                        cotitem.st_produtor_informado = "N"
                    End If
                    cotitem.dt_entrega = txt_dt_entrega.Text 'fran chamado 602
                    cotitem.id_central_prazo_pagto = Convert.ToInt32(cbo_prazo_pagto.SelectedValue) 'fran fase 2 melhoria 
                    cotitem.id_central_cotacao_item = lbl_id_central_cotacao_item.Text
                    cotitem.id_modificador = Session("id_login")
                    cotitem.updateCotacaoItem()

                    If cotitem.st_ver_mercado = "S" Then
                        Dim cotfornecedor As New CotacaoFornecedor
                        cotfornecedor.id_central_cotacao_item = cotitem.id_central_cotacao_item
                        cotfornecedor.st_selecionado = "N"
                        cotfornecedor.updateCotacaoFornecedorSelecionado()
                    End If

                    'Atualiza somatorio do total da cotação por causa da coluna 'VerMercado' 
                    'Se ver mercado for = S nao entra mais no somatorio do valor total
                    'se ver mercado for = 'N" participa do somatorio 
                    Dim cotacao As New Cotacao
                    cotacao.id_central_cotacao = Convert.ToInt32(Me.lbl_id_central_cotacao.Text)
                    'fran 01/12/2010 i chamado 1069
                    If Not lbl_nr_valor_disponivel.Text.Equals(String.Empty) Then
                        If CDec(lbl_nr_valor_disponivel.Text) <> 0 Then
                            cotacao.nr_limite_disponivel = Convert.ToDecimal(lbl_nr_valor_disponivel.Text)
                        End If
                    End If
                    'fran 01/12/2010 f chamado 1069
                    'fran fase 2 melhorias i
                    If Not lbl_nr_valor_mensal_estimado.Text.Equals(String.Empty) Then
                        If CDec(lbl_nr_valor_mensal_estimado.Text) <> 0 Then
                            cotacao.nr_valor_mensal_estimado = Convert.ToDecimal(lbl_nr_valor_mensal_estimado.Text)
                        End If
                    End If
                    If lbl_informativo.Visible = True Then
                        cotacao.st_saldo_romaneio_aberto = "S"
                    Else
                        cotacao.st_saldo_romaneio_aberto = "N"
                    End If
                    'fran fase 2 melhorias f

                    cotacao.updateCentralCotacaoTotal()
                    'atualiza tela
                    Dim ds_cotacao As DataSet = cotacao.getCotacaoByFilters
                    If ds_cotacao.Tables(0).Rows.Count > 0 Then
                        Me.lbl_nr_valor_total_cotacao.Text = ds_cotacao.Tables(0).Rows(0).Item("nr_total_cotacao")
                    End If
                    'Verifica se pode habilitar link para aprovação 
                    'fran 13/10/2010 rls 26.04
                    'If cotitem.nr_parcelas > 0 And cotitem.st_ver_mercado = "N" Then
                    '    lk_enviar_aprovacao.Enabled = True
                    'Else
                    '    lk_enviar_aprovacao.Enabled = False
                    '    If CDbl(Me.lbl_nr_valor_disponivel.Text) < CDbl(Me.lbl_nr_valor_total_cotacao.Text) Then
                    '        lk_enviar_aprovacao.Enabled = True
                    '    End If
                    'End If
                    AtualizarLinkEnviarAprovacao()
                    'fran 13/10/2010 rls 26.04

                    gridItens.EditIndex = -1

                    loadGridItens()
                    loadGridCotacoes()
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub cbo_vai_parcelar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim cbo_vai_parcelar As DropDownList = CType(row.FindControl("cbo_vai_parcelar"), DropDownList)
        Dim rfv_nr_parcelas As RequiredFieldValidator = CType(row.FindControl("rfv_nr_parcelas"), RequiredFieldValidator)
        Dim rv_parcelas As Anthem.RangeValidator = CType(row.FindControl("rv_parcelas"), Anthem.RangeValidator) 'fran fase 3 
        Dim cv_nr_parcelas As CompareValidator = CType(row.FindControl("cv_nr_parcelas"), CompareValidator)
        Dim txt_nr_parcelas As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_parcelas"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
        'fran 08/2014 fase 3 i
        'If cbo_vai_parcelar.SelectedValue = "S" Then
        '    txt_nr_parcelas.Enabled = True
        '    rfv_nr_parcelas.Visible = True
        '    cv_nr_parcelas.Visible = True
        'Else
        '    txt_nr_parcelas.Enabled = False
        '    txt_nr_parcelas.Text = String.Empty
        '    rfv_nr_parcelas.Visible = False
        '    cv_nr_parcelas.Visible = False
        'End If

        Select Case cbo_vai_parcelar.SelectedValue
            Case "N"
                txt_nr_parcelas.Enabled = False
                txt_nr_parcelas.Text = String.Empty
                rfv_nr_parcelas.Visible = False
                rv_parcelas.Visible = False
                cv_nr_parcelas.Visible = False
                rv_parcelas.Enabled = False

            Case "P"
                txt_nr_parcelas.Enabled = True
                rfv_nr_parcelas.Visible = True
                cv_nr_parcelas.Visible = True
                rv_parcelas.Visible = False 'Não há limite para parcelamento quando parcela nao é pela DANONE
                rv_parcelas.Enabled = False
            Case "D"
                txt_nr_parcelas.Enabled = True
                rfv_nr_parcelas.Visible = True
                cv_nr_parcelas.Visible = True
                rv_parcelas.Enabled = True
                rv_parcelas.Visible = True
                rv_parcelas.MaximumValue = CInt(ViewState.Item("nr_politica_parcelas").ToString)
                rv_parcelas.ErrorMessage = "Para tipo de Pagamento 'Danone' o parcelamento deve ser no máximo de " & ViewState.Item("nr_politica_parcelas").ToString & " parcelas, de acordo com a Política de Parcelas."
                rv_parcelas.ToolTip = "Para tipo de Pagamento 'Danone' o parcelamento deve ser no máximo de " & ViewState.Item("nr_politica_parcelas").ToString & " parcelas, de acordo com a Política de Parcelas."

        End Select
        If cbo_vai_parcelar.SelectedValue = "N" Then
            txt_nr_parcelas.Enabled = False
            txt_nr_parcelas.Text = String.Empty
            rfv_nr_parcelas.Visible = False
            rv_parcelas.Visible = False
            cv_nr_parcelas.Visible = False
        Else
            txt_nr_parcelas.Enabled = True
            rfv_nr_parcelas.Visible = True
            cv_nr_parcelas.Visible = True
            rv_parcelas.Visible = True
            rv_parcelas.MaximumValue = CInt(ViewState.Item("nr_politica_parcelas").ToString)
        End If

        'fran 08/2014 fase 3 f

    End Sub

    Protected Sub btn_adicionar_cotacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar_cotacao.Click
        ViewState.Item("incluirlinha") = "S"
        Dim cotfornecedor As New CotacaoFornecedor
        cotfornecedor.id_central_cotacao_item = Convert.ToInt32(ViewState.Item("id_central_cotacao_item"))
        Dim dscotfornecedor As DataSet = cotfornecedor.getCotacaoFornecedorByFilters()
        Dim dr As DataRow = dscotfornecedor.Tables(0).NewRow()
        dscotfornecedor.Tables(0).Rows.InsertAt(dr, 0)
        ViewState.Item("incluirlinhacotacao") = "S"
        gridCotacoes.Visible = True
        gridCotacoes.DataSource = Helper.getDataView(dscotfornecedor.Tables(0), ViewState.Item("sortExpression"))
        gridCotacoes.EditIndex = 0
        gridCotacoes.DataBind()
        ViewState.Item("incluirlinha") = Nothing

    End Sub

    Protected Sub gridCotacaoes_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridCotacoes.PageIndexChanging
        gridCotacoes.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridCotacaoes_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridCotacoes.RowCancelingEdit
        Try

            gridCotacoes.EditIndex = -1
            ViewState.Item("incluirlinhacotacao") = "N"
            ViewState.Item("incluirlinhacotacao") = Nothing
            loadGridCotacoes()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridCotacaoes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridCotacoes.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Insert"
                ViewState.Item("incluirlinha") = "S"

                Dim cotfornecedor As New CotacaoFornecedor
                cotfornecedor.id_central_cotacao_item = Convert.ToInt32(ViewState.Item("id_central_cotacao_item"))

                Dim dscotfornec As DataSet = cotfornecedor.getCotacaoFornecedorByFilters()
                Dim dr As DataRow = dscotfornec.Tables(0).NewRow()
                dscotfornec.Tables(0).Rows.InsertAt(dr, 0)
                gridCotacoes.Visible = True
                gridCotacoes.DataSource = Helper.getDataView(dscotfornec.Tables(0), ViewState.Item("sortExpression"))
                gridCotacoes.EditIndex = 0
                gridCotacoes.DataBind()
            Case "delete"
                deleteCotacaoFornecedor(Convert.ToInt32(e.CommandArgument.ToString()))
            Case "Lupa"
                carregarCamposfretevalor(Convert.ToInt32(e.CommandArgument.ToString()))
                'fran 27/07/2010 i chamado 682
            Case "LupaTransportador"
                carregarCamposTransportador(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Protected Sub gridCotacaoes_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCotacoes.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                Dim bt_lupa_frete_valor As Anthem.ImageButton = CType(e.Row.FindControl("btn_lupa_frete_valor"), Anthem.ImageButton)
                Dim bt_lupa_transportador As Anthem.ImageButton = CType(e.Row.FindControl("btn_lupa_transportador"), Anthem.ImageButton)
                Dim cbo_parceiro As DropDownList = CType(e.Row.FindControl("cbo_parceiro_central"), DropDownList)
                Dim chk_st_selecionado As CheckBox = CType(e.Row.FindControl("chk_st_selecionado"), CheckBox)
                Dim cbo_tipo_frete As DropDownList = CType(e.Row.FindControl("cbo_tipo_frete"), DropDownList)

                Dim cvparceiro As CustomValidator = CType(e.Row.FindControl("cv_parceiro"), CustomValidator)

                If ViewState.Item("incluirlinha") = "S" Then
                    If e.Row.RowIndex = 0 Then
                        ViewState.Item("label_parceiro") = ""
                        ViewState.Item("label_tipo") = ""
                        ViewState.Item("label_tipo_frete") = ""
                    End If
                End If
                If ViewState.Item("incluirlinhacotacao") = "S" Then
                    cbo_parceiro.Enabled = True
                    cvparceiro.Enabled = True
                    bt_lupa_frete_valor.Visible = True
                    bt_lupa_frete_valor.CommandArgument = e.Row.RowIndex.ToString
                    With bt_lupa_frete_valor
                        .Attributes.Add("onclick", "javascript:ShowDialogFreteValor()")
                        .ToolTip = "Filtrar Valores Frete"
                    End With
                Else
                    bt_lupa_frete_valor.Visible = False
                    cbo_parceiro.Enabled = False
                    cvparceiro.Enabled = False
                End If

                'fran 27/07/2010 i 
                bt_lupa_transportador.Visible = True
                bt_lupa_transportador.CommandArgument = e.Row.RowIndex.ToString
                With bt_lupa_transportador
                    .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
                    .ToolTip = "Filtrar Transportador"
                End With
                'fran 27/07/2010 f


                If ViewState.Item("st_ver_mercado").ToString = "S" Then
                    chk_st_selecionado.Enabled = False
                    chk_st_selecionado.ToolTip = "Cotação não pode ser selecionada pois este item é 'Ver Mercado'."
                Else
                    chk_st_selecionado.Enabled = True
                    chk_st_selecionado.ToolTip = "Selecionar Cotação."
                End If

                If Not (ViewState.Item("label_parceiro") Is Nothing) Then

                    Dim itemparceiro As New ItemParceiro

                    itemparceiro.id_item = ViewState.Item("id_item")
                    cbo_parceiro.DataSource = itemparceiro.getParceiroByFilters()
                    cbo_parceiro.DataTextField = "nm_pessoa"
                    cbo_parceiro.DataValueField = "id_fornecedor"
                    cbo_parceiro.DataBind()

                    If (ViewState.Item("label_parceiro").ToString.Equals(String.Empty)) Then
                        cbo_parceiro.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState.Item("label_parceiro") = "SEM_VALOR"
                    Else
                        cbo_parceiro.SelectedValue = cbo_parceiro.Items.FindByText(ViewState.Item("label_parceiro").Trim.ToString).Value
                        ViewState.Item("label_parceiro") = Nothing
                    End If
                End If
                'fran fase 3 i
                If cbo_pedido_indireto.SelectedValue.Equals("S") Then
                    cbo_tipo_frete.Items.Remove(1) 'Remove FOB D
                    cbo_tipo_frete.Items.Remove(2) 'Remove FOB I
                    cbo_tipo_frete.Items.Remove(3) 'Remove Selecione
                    ViewState.Item("label_tipo_frete") = "CIF"
                    Dim rfv_transportador As RequiredFieldValidator = CType(e.Row.FindControl("rfv_transportador"), RequiredFieldValidator)
                    rfv_transportador.Visible = False
                End If
                'fran fase 3 f

                If Not (ViewState.Item("label_tipo_frete") Is Nothing) Then

                    If (ViewState.Item("label_tipo_frete").ToString.Equals(String.Empty)) Then

                        ViewState.Item("label_tipo_frete") = "SEM_VALOR"
                    Else
                        cbo_tipo_frete.SelectedValue = cbo_tipo_frete.Items.FindByText(ViewState.Item("label_tipo_frete").Trim.ToString).Value
                        ViewState.Item("label_tipo_frete") = Nothing
                    End If
                End If

                ' Adriana 16/06/2010 - chamado 870 - i
                Dim rqf_litros As RequiredFieldValidator = CType(e.Row.FindControl("rqf_litros"), RequiredFieldValidator)
                If ViewState.Item("ds_tipo_medida") = "Granel" Then   ' Se embalagem a Granel, não obriga sacaria
                    rqf_litros.Enabled = False
                Else
                    rqf_litros.Enabled = True
                End If
                ' Adriana 16/06/2010 - chamado 870 - f

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If


    End Sub

    Protected Sub gridCotacaoes_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCotacoes.RowDataBound
        Dim lbl_st_selecionado As Label = CType(e.Row.FindControl("lbl_st_selecionado"), Label)
        Dim chk_st_selecionado As CheckBox = CType(e.Row.FindControl("chk_st_selecionado"), CheckBox)
        Dim lbl_data_entrega As Label = CType(e.Row.FindControl("lbl_data_entrega"), Label) 'fran 08/02/2010 i
        Dim lbl_nm_central_status_aprovacao As Label = CType(e.Row.FindControl("lbl_nm_central_status_aprovacao"), Label) 'fran 08/02/2010 i
        Dim lbl_nr_valor_total As Label = CType(e.Row.FindControl("lbl_nr_valor_total"), Label)
        Dim lbl_id_transportador As Label = CType(e.Row.FindControl("lbl_id_transportador"), Label)
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                Dim cbo_parceiro As DropDownList = CType(e.Row.FindControl("cbo_parceiro_central"), DropDownList)
                Dim txt_nr_valor_unitario As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_valor_unitario"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_nr_sacaria As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_sacaria"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_nr_perc_icms As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_perc_icms"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim cbo_tipo_frete As Anthem.DropDownList = CType(e.Row.FindControl("cbo_tipo_frete"), Anthem.DropDownList)
                Dim btn_lupa_frete_valor As ImageButton = CType(e.Row.FindControl("btn_lupa_frete_valor"), ImageButton)

                'fran 27/07/2010 i chamado 682
                If Not lbl_id_transportador.Text.Equals(String.Empty) Then
                    hf_id_pessoa.Value = lbl_id_transportador.Text
                End If
                If ViewState.Item("label_tipo_frete") = "SEM_VALOR" Then
                    'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                    If Not (cbo_tipo_frete Is Nothing) Then
                        cbo_tipo_frete.SelectedValue = String.Empty
                    End If
                    ViewState.Item("label_tipo_frete") = Nothing

                End If

                'fran 27/07/2010 f chamado 682\
                If ViewState.Item("label_parceiro") = "SEM_VALOR" Then
                    'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                    If Not (cbo_parceiro Is Nothing) Then
                        cbo_parceiro.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    End If
                    ViewState.Item("label_parceiro") = Nothing

                End If

                If ViewState.Item("incluirlinha") = "S" Then
                    txt_nr_valor_unitario.Enabled = False
                    txt_nr_sacaria.Enabled = False
                    txt_nr_frete.Enabled = False
                    txt_nr_perc_icms.Enabled = False
                    cbo_tipo_frete.Enabled = False
                    'btn_lupa_frete_valor.Enabled = False
                    chk_st_selecionado.Checked = False
                Else
                    cbo_parceiro.Enabled = False
                    If cbo_parceiro.SelectedValue <> "" Then
                        Dim cotfornecedor As New CotacaoFornecedor
                        cotfornecedor.id_central_cotacao_item = Convert.ToInt32(ViewState.Item("id_central_cotacao_item"))
                        cotfornecedor.id_fornecedor = Convert.ToInt32(cbo_parceiro.SelectedValue.ToString)
                        Dim dsfornecedor As DataSet = cotfornecedor.getCotacaoFornecedorByFilters
                        If dsfornecedor.Tables(0).Rows.Count > 0 Then
                            With dsfornecedor.Tables(0).Rows(0)
                                txt_nr_valor_unitario.Text = .Item("nr_valor_unitario")
                                txt_nr_sacaria.Text = .Item("nr_sacaria")
                                txt_nr_frete.Text = .Item("nr_frete")
                                cbo_tipo_frete.SelectedValue = .Item("ds_tipo_frete")
                                txt_nr_perc_icms.Text = .Item("nr_perc_icms")
                                If .Item("st_selecionado") = "N" Then
                                    chk_st_selecionado.Checked = False
                                Else
                                    chk_st_selecionado.Checked = True
                                End If
                            End With

                        End If

                    End If
                    'fran 08/02/2010 i
                    Dim lbl_dt_entrega As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(e.Row.FindControl("txt_data_entrega"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox) 'fran 08/02/2010 i
                    If Not lbl_dt_entrega.Text = String.Empty Then
                        'lbl_dt_entrega.Text = Left(lbl_dt_entrega.Text.Trim, 10)
                        lbl_dt_entrega.Text = DateTime.Parse(lbl_dt_entrega.Text.Trim).ToString("dd/MM/yyyy")
                    End If
                    'fran 08/02/2010 f

                    'Adriana 15/06/2010 chamado 868 i
                    Dim lbl_nr_quantidade As Label = CType(e.Row.FindControl("lbl_nr_quantidade"), Label)
                    Dim nr_valor_por_medida As Decimal
                    If Not lbl_nr_quantidade.Text = String.Empty Then
                        If IsNumeric(lbl_nr_quantidade.Text) And IsNumeric(lbl_nr_valor_total.Text) Then
                            If Convert.ToDecimal(lbl_nr_quantidade.Text) > 0 Then
                                nr_valor_por_medida = lbl_nr_valor_total.Text / lbl_nr_quantidade.Text
                                Dim lbl_nr_valor_medida As Label = CType(e.Row.FindControl("lbl_nr_valor_medida"), Label)
                                lbl_nr_valor_medida.Text = FormatNumber(nr_valor_por_medida, 2)
                            End If
                        End If
                    End If
                    'Adriana 15/06/2010 chamado 868 f
                    'fran  chamado 958 01/09/2010 i
                    Dim rfv_transportador As RequiredFieldValidator = CType(e.Row.FindControl("rfv_transportador"), RequiredFieldValidator)

                    If cbo_tipo_frete.SelectedValue = "D" Then
                        rfv_transportador.Visible = True
                    Else 'se FOB-I ou CIF
                        rfv_transportador.Visible = False
                    End If
                    'fran  chamado 958 01/09/2010 f

                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        Else
            If e.Row.RowType = DataControlRowType.DataRow Then
                If lbl_st_selecionado.Text = "N" Then
                    chk_st_selecionado.Checked = False
                Else
                    chk_st_selecionado.Checked = True
                    'Fran 10/09/2010 i 
                    If CInt(ViewState.Item("id_situacao_cotacao").ToString) >= 4 And CInt(ViewState.Item("id_situacao_cotacao").ToString) <= 7 Then
                        If Not ViewState.Item("id_central_cotacao_item") Is Nothing Then
                            If Not ViewState.Item("id_central_cotacao_item").ToString.Equals(String.Empty) Then
                                If CLng(ViewState.Item("id_central_cotacao_item")) > 0 Then
                                    Dim id_cotacao_item As Int32 = CLng(ViewState.Item("id_central_cotacao_item").ToString)
                                    Dim cotacaoitem As New CotacaoItem
                                    cotacaoitem.id_central_cotacao_item = id_cotacao_item
                                    Dim dscotacaoitem As DataSet = cotacaoitem.getCotacaoItensByFilters
                                    If dscotacaoitem.Tables(0).Rows.Count > 0 Then
                                        With dscotacaoitem.Tables(0).Rows(0)
                                            If Not IsDBNull(.Item("nm_central_status_aprovacao")) Then
                                                lbl_nm_central_status_aprovacao.Text = .Item("nm_central_status_aprovacao")
                                            End If
                                        End With
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                'fran 08/02/2010 i
                If Not lbl_data_entrega.Text = String.Empty Then
                    'lbl_dt_entrega.Text = Left(lbl_dt_entrega.Text.Trim, 10)
                    lbl_data_entrega.Text = DateTime.Parse(lbl_data_entrega.Text.Trim).ToString("dd/MM/yyyy")

                End If
                'fran 08/02/2010 f
                'fran 27/07/2010 i chamado 682
                Dim lbl_ds_tipo_frete As Label = CType(e.Row.FindControl("lbl_ds_tipo_frete"), Label)
                Select Case lbl_ds_tipo_frete.Text
                    Case "C"
                        lbl_ds_tipo_frete.Text = "CIF"
                    Case "D"
                        lbl_ds_tipo_frete.Text = "FOB-D"
                    Case "I"
                        lbl_ds_tipo_frete.Text = "FOB-I"
                End Select

                'Adriana 15/06/2010 chamado 868 i
                Dim lbl_nr_quantidade As Label = CType(e.Row.FindControl("lbl_nr_quantidade"), Label)
                Dim nr_valor_por_medida As Decimal
                If Not lbl_nr_quantidade.Text = String.Empty Then
                    If IsNumeric(lbl_nr_quantidade.Text) And IsNumeric(lbl_nr_valor_total.Text) Then
                        If Convert.ToDecimal(lbl_nr_quantidade.Text) > 0 Then
                            nr_valor_por_medida = lbl_nr_valor_total.Text / lbl_nr_quantidade.Text
                            Dim lbl_nr_valor_medida As Label = CType(e.Row.FindControl("lbl_nr_valor_medida"), Label)
                            lbl_nr_valor_medida.Text = FormatNumber(nr_valor_por_medida, 2)
                        End If
                    End If
                End If
                'Adriana 15/06/2010 chamado 868 f

            End If
        End If

    End Sub

    Protected Sub gridCotacaoes_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridCotacoes.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub gridCotacaoes_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridCotacoes.RowEditing
        Try
            If ViewState.Item("incluirlinha") = "S" And e.NewEditIndex = 0 Then
                ViewState.Item("incluirlinha") = "S"
                loadGridCotacoes()
            Else
                Dim lbl_ds_parceiro_central As Label = CType(gridCotacoes.Rows(e.NewEditIndex).FindControl("lbl_ds_parceiro_central"), Label)
                Dim lbl_ds_tipo_frete As Label = CType(gridCotacoes.Rows(e.NewEditIndex).FindControl("lbl_ds_tipo_frete"), Label)
                ViewState.Item("label_parceiro") = Trim(lbl_ds_parceiro_central.Text)
                ViewState.Item("label_tipo_frete") = Trim(lbl_ds_tipo_frete.Text)
                gridCotacoes.EditIndex = e.NewEditIndex
                loadGridCotacoes()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridCotacaoes_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridCotacoes.RowUpdating
        Dim row As GridViewRow = gridCotacoes.Rows(e.RowIndex)
        Try
            If Page.IsValid Then


                If (Not (row) Is Nothing) Then

                    Dim cotfornecedor As New CotacaoFornecedor

                    Dim cbo_parceiro As DropDownList = CType(row.FindControl("cbo_parceiro_central"), DropDownList)
                    Dim txt_nr_valor_unitario As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_unitario"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_nr_sacaria As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_sacaria"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_nr_perc_icms As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_perc_icms"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim lbl_nr_valor_total As Label = CType(row.FindControl("lbl_nr_valor_total"), Label)
                    Dim lbl_id_central_cotacao_fornecedor As Label = CType(row.FindControl("lbl_id_central_cotacao_fornecedor"), Label)
                    Dim cbo_tipo_frete As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_frete"), Anthem.DropDownList)
                    Dim lvalor_total As Decimal
                    Dim lqtdeitem As Decimal
                    Dim chk_st_selecionado As CheckBox = CType(row.FindControl("chk_st_selecionado"), CheckBox)
                    Dim txt_data_entrega As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_data_entrega"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox) 'fran chamado 602

                    cotfornecedor.nr_valor_unitario = Convert.ToDecimal(txt_nr_valor_unitario.Text)


                    ' Adriana 15/05/2010 - chamado 870 - i
                    'cotfornecedor.nr_sacaria = Convert.ToDecimal(txt_nr_sacaria.Text)
                    If Not txt_nr_sacaria.Text = String.Empty Then
                        cotfornecedor.nr_sacaria = Convert.ToDecimal(txt_nr_sacaria.Text)
                    Else
                        cotfornecedor.nr_sacaria = 0
                    End If
                    ' Adriana 15/05/2010 - chamado 870 - f

                    ' Adriana 15/05/2010 - chamado 869 - i
                    'cotfornecedor.nr_frete = Convert.ToDecimal(txt_nr_frete.Text)
                    If Not txt_nr_frete.Text = String.Empty Then
                        cotfornecedor.nr_frete = Convert.ToDecimal(txt_nr_frete.Text)
                    Else
                        cotfornecedor.nr_frete = 0
                    End If
                    ' Adriana 15/05/2010 - chamado 869 - f

                    cotfornecedor.ds_tipo_frete = cbo_tipo_frete.SelectedValue
                    cotfornecedor.nr_perc_icms = Convert.ToDecimal(txt_nr_perc_icms.Text)

                    'Valor Total = qtde item * (valor unitario + sacaria + frete se tipo indireto)
                    lqtdeitem = Convert.ToDecimal(ViewState.Item("nr_quantidade_item").ToString)
                    'Fran chamado 682 - 27/08/2010 i
                    'lvalor_total = cotfornecedor.nr_valor_unitario + cotfornecedor.nr_sacaria
                    ''If cbo_tipo_frete.SelectedValue = "I" Then 'fran 02/06/2010 i chamado 
                    'If cbo_tipo_frete.SelectedValue = "D" Then
                    '    lvalor_total = lvalor_total + cotfornecedor.nr_frete
                    'End If
                    'lvalor_total = Convert.ToDecimal(Round(lqtdeitem * lvalor_total, 2))
                    Select Case cbo_tipo_frete.SelectedValue
                        Case "C" 'SE CIF
                            lvalor_total = (cotfornecedor.nr_valor_unitario + cotfornecedor.nr_sacaria + cotfornecedor.nr_frete)
                        Case "D" 'Se FOB-D
                            'Fran 7/12/2010 - 1071 se fot fob d o valor do frete não deve participar do totalizador
                            'lvalor_total = (cotfornecedor.nr_valor_unitario + cotfornecedor.nr_sacaria + cotfornecedor.nr_frete)
                            'fran 04/09/2015 i deve voltar a considerar valor frete
                            'lvalor_total = (cotfornecedor.nr_valor_unitario + cotfornecedor.nr_sacaria)
                            lvalor_total = (cotfornecedor.nr_valor_unitario + cotfornecedor.nr_sacaria + cotfornecedor.nr_frete)
                            'fran 04/09/2015 f deve voltar a considerar valor frete

                            'Fran 7/12/2010 - 1071 se fot fob d o valor do frete não deve participar do totalizador
                        Case "I" 'SE FOB-I
                            lvalor_total = cotfornecedor.nr_valor_unitario + cotfornecedor.nr_sacaria

                    End Select

                    lvalor_total = Convert.ToDecimal(Round(lqtdeitem * lvalor_total, 2))
                    'Fran chamado 682 - 27/08/2010 f

                    cotfornecedor.nr_valor_total = lvalor_total
                    If chk_st_selecionado.Checked = True Then
                        cotfornecedor.st_selecionado = "S"
                    Else
                        cotfornecedor.st_selecionado = "N"
                    End If
                    cotfornecedor.id_modificador = Session("id_login")
                    cotfornecedor.id_central_cotacao_item = Convert.ToInt32(ViewState.Item("id_central_cotacao_item"))
                    cotfornecedor.dt_entrega = txt_data_entrega.Text 'fran chamado 602
                    'fran 27/07/2010 chamado 682
                    If Not hf_id_pessoa.Value.Equals(String.Empty) Then
                        cotfornecedor.id_transportador = hf_id_pessoa.Value
                    End If
                    'fran 27/07/2010 f chamado 682

                    'Se é um novo item
                    If Not ViewState.Item("incluirlinhacotacao") Is Nothing Then
                        If ViewState.Item("incluirlinhacotacao") = "S" Then
                            cotfornecedor.id_fornecedor = Convert.ToInt32(cbo_parceiro.SelectedValue)
                            cotfornecedor.insertCotacaoFornecedor()
                            'fran chamado 717/860 rls 24.10 i
                            'se está incluindo cotação de fornecedor, atualiza status do item da cotação para cotado (tem preço)
                            Dim cotacaoitem As New CotacaoItem
                            cotacaoitem.id_central_cotacao_item = cotfornecedor.id_central_cotacao_item
                            cotacaoitem.id_central_status_aprovacao = 6 'Cotados
                            cotacaoitem.id_modificador = cotfornecedor.id_modificador
                            cotacaoitem.updateCotacaoItemSituacao()
                            'fran chamado 717/860 rls 24.10 f
                            ViewState.Item("incluirlinhacotacao") = Nothing
                        Else
                            cotfornecedor.id_central_cotacao_fornecedor = Convert.ToInt32(lbl_id_central_cotacao_fornecedor.Text)
                            cotfornecedor.updateCotacaoFornecedor()
                        End If


                    Else
                        cotfornecedor.id_central_cotacao_fornecedor = Convert.ToInt32(lbl_id_central_cotacao_fornecedor.Text)
                        cotfornecedor.updateCotacaoFornecedor()
                    End If
                    hf_id_pessoa.Value = String.Empty 'fran 27/07/2010 i
                    AtualizarTotalizadores()
                    AtualizarLinkEnviarAprovacao()
                    gridCotacoes.EditIndex = -1

                    loadGridCotacoes()
                    loadGridItens()
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cbo_parceiro_central_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim cbo_parceiro As DropDownList = CType(row.FindControl("cbo_parceiro_central"), DropDownList)
        Dim lbl_st_selecionado As Label = CType(row.FindControl("lbl_st_selecionado"), Label)
        Dim chk_st_selecionado As CheckBox = CType(row.FindControl("chk_st_selecionado"), CheckBox)
        Dim txt_nr_valor_unitario As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_unitario"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        Dim txt_nr_sacaria As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_sacaria"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        Dim txt_nr_perc_icms As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_perc_icms"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        Dim lbl_nr_valor_total As Label = CType(row.FindControl("lbl_nr_valor_total"), Label)
        Dim cbo_tipo_frete As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_frete"), Anthem.DropDownList)
        Dim btn_lupa_frete_valor As ImageButton = CType(row.FindControl("btn_lupa_frete_valor"), ImageButton)
        Dim fornecedor As New Pessoa(Convert.ToInt32(cbo_parceiro.SelectedValue))
        Dim contato As DataControlFieldCell = CType(row.Cells(1), DataControlFieldCell)
        Dim telefone As DataControlFieldCell = CType(row.Cells(2), DataControlFieldCell)

        contato.Text = fornecedor.ds_contato
        telefone.Text = fornecedor.ds_telefone_1
        txt_nr_valor_unitario.Enabled = True
        txt_nr_sacaria.Enabled = True
        txt_nr_frete.Enabled = True
        txt_nr_perc_icms.Enabled = True
        cbo_tipo_frete.Enabled = True
        btn_lupa_frete_valor.Enabled = True
        chk_st_selecionado.Enabled = True

        'fran 10/02/2010 - para não ocorrer problemas com a carga da lupa de frete
        If cbo_parceiro.Items(0).Text = "[Selecione]" Then
            cbo_parceiro.Items.RemoveAt(0)
        End If


        Dim tabelaprecos As New TabelaPrecos
        tabelaprecos.id_estabelecimento = Convert.ToInt32(Me.cbo_estabelecimento.SelectedValue)
        tabelaprecos.id_fornecedor = fornecedor.id_pessoa
        tabelaprecos.id_item = Convert.ToInt32(ViewState.Item("id_item"))
        'fran chamado 556 i
        tabelaprecos.id_estado_propriedade = Convert.ToInt32(ViewState.Item("id_estado_propriedade"))
        tabelaprecos.id_cidade_propriedade = Convert.ToInt32(ViewState.Item("id_cidade_propriedade"))
        'fran chamado 556 f
        Dim dsprecos As DataSet = tabelaprecos.getCentralTabelaPrecosMax
        If dsprecos.Tables(0).Rows.Count > 0 Then
            With (dsprecos.Tables(0).Rows(0))
                txt_nr_valor_unitario.Text = .Item("nr_valor")
                txt_nr_sacaria.Text = .Item("nr_valor_sacaria")
                txt_nr_perc_icms.Text = .Item("nr_valor_icms")
            End With
        End If

        'fran fase 2 melhorias i
        If ViewState.Item("ds_tipo_medida") = "Granel" Or ViewState.Item("ds_tipo_medida") = "Outros" Then   ' Se embalagem a Granel, não obriga sacaria
            txt_nr_sacaria.Text = "0,00"
        End If
        'fran fase 2 melhorias f

        'atualiza valores dos campos escondidos para lupa
        hf_sel_id_fornecedor.Value = tabelaprecos.id_fornecedor
        hf_sel_id_item.Value = tabelaprecos.id_item


    End Sub
    Private Sub carregarCamposfretevalor(ByVal id_index_row As Integer)

        Try
            Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(gridCotacoes.Rows.Item(id_index_row).FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            txt_nr_frete.Text = ""
            If Not (customPage.getFilterValue("lupa_fretevl", "nr_frete").Equals(String.Empty)) Then
                txt_nr_frete.Text = customPage.getFilterValue("lupa_fretevl", "nr_frete").ToString

            Else
                txt_nr_frete.Text = "0,00" 'chamado 559
            End If


            customPage.clearFilters("lupa_fretevl")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub deleteItemCotacao(ByVal id_central_cotacao_item As Integer)

        Try
            'Delleta o item
            Dim cotacaoitem As New CotacaoItem

            cotacaoitem.id_central_cotacao_item = id_central_cotacao_item
            cotacaoitem.deleteCotacaoItemESeusFornecedores()
            messageControl.Alert("Registro excluído com sucesso!")
            'Limpa possével seleção grid itens
            LimparSelecaoGridItens()
            loadData()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub deleteCotacaoFornecedor(ByVal id_central_cotacao_fornecedor As Integer)

        Try
            'Deleta a cotacao fornecedor
            Dim cotacaofornecedor As New CotacaoFornecedor

            cotacaofornecedor.id_central_cotacao_fornecedor = id_central_cotacao_fornecedor
            cotacaofornecedor.deleteCotacaoFornecedor()

            'fran chamado 717/860 i
            If ViewState.Item("id_central_cotacao_item") Is Nothing Then
                ViewState.Item("id_central_cotacao_item") = 0
            End If
            'verifica se tem linhas na cotacaofornecedor
            Dim cotfornecedor As New CotacaoFornecedor
            If CLng(ViewState.Item("id_central_cotacao_item")) > 0 Then
                cotfornecedor.id_central_cotacao_item = Convert.ToInt32(ViewState.Item("id_central_cotacao_item"))
                Dim dsCotFornecedor As DataSet = cotfornecedor.getCotacaoFornecedorByFilters()
                If (dsCotFornecedor.Tables(0).Rows.Count = 0) Then
                    'se não há mais fornecedores para cotação atualiza status do item da cotação para Solic.Cotação (não tem preço cotado)
                    Dim cotacaoitem As New CotacaoItem
                    cotacaoitem.id_central_cotacao_item = cotfornecedor.id_central_cotacao_item
                    cotacaoitem.id_central_status_aprovacao = 5 'Solic. Cotação
                    cotacaoitem.id_modificador = cotfornecedor.id_modificador
                    cotacaoitem.updateCotacaoItemSituacao()
                    'fran chamado 717/860 rls 24.10 f

                End If
            End If

            loadGridCotacoes()
            messageControl.Alert("Registro excluído com sucesso!")



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub LimparSelecaoGridItens()

        Try
            'seta zero para limpar seleção e o grid de cotações
            ViewState.Item("id_central_cotacao_item") = 0
            btn_adicionar_cotacao.Enabled = False

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub AtualizarLinkEnviarAprovacao()

        Try
            'Verifica se pode habilitar link para aprovação 
            Dim cotacao As New Cotacao(Convert.ToInt32(ViewState.Item("id_central_cotacao").ToString))
            'cotacao.id_central_cotacao = Convert.ToInt32(ViewState.Item("id_central_cotacao").ToString)

            'Verifica se há algum item com parcelas e ver_mercado = N
            If cotacao.getCotacaoItensParcelados > 0 Then
                lk_enviar_aprovacao.Enabled = True
                'fran 08/2014 fase 3 i
                'se tem cotacao parcelada e todos os itens sao st_parcelamento = P (parcelamento parceiro), e há limite, nao vai para aprovação
                If CDec(Me.lbl_nr_valor_total_cotacao.Text) < CDec(Me.lbl_nr_valor_disponivel.Text) Then
                    If cotacao.getCentralCotacaoItensParcelaSemParceiro = 0 Then
                        lk_enviar_aprovacao.Enabled = False
                    End If
                End If
                'fran 08/2014 fase 3 f


            Else
                'Verifica se excedeu limite de compra
                If CDec(Me.lbl_nr_valor_total_cotacao.Text) > CDec(Me.lbl_nr_valor_disponivel.Text) Then
                    lk_enviar_aprovacao.Enabled = True
                Else
                    lk_enviar_aprovacao.Enabled = False
                End If
            End If

            'Fran fase 3 12/2014 i
            If cotacao.st_pedido_indireto.Equals("S") Then
                lk_enviar_aprovacao.Enabled = False
            End If
            'Fran fase 3 12/2014 f

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub AtualizarTotalizadores()

        Try
            'Atualiza somatorio do total da cotação
            Dim cotacao As New Cotacao
            cotacao.id_central_cotacao = Convert.ToInt32(ViewState.Item("id_central_cotacao").ToString)
            'fran 01/12/2010 i chamado 1069
            If Not lbl_nr_valor_disponivel.Text.Equals(String.Empty) Then
                If CDec(lbl_nr_valor_disponivel.Text) <> 0 Then
                    cotacao.nr_limite_disponivel = Convert.ToDecimal(lbl_nr_valor_disponivel.Text)
                End If
            End If
            'fran 01/12/2010 f chamado 1069
            'fran 01/2014 i fase 2 melhorias
            If Not lbl_nr_valor_mensal_estimado.Text.Equals(String.Empty) Then
                If CDec(lbl_nr_valor_mensal_estimado.Text) <> 0 Then
                    cotacao.nr_valor_mensal_estimado = Convert.ToDecimal(lbl_nr_valor_mensal_estimado.Text)
                End If
            End If

            If lbl_informativo.Visible = True Then
                cotacao.st_saldo_romaneio_aberto = "S"
            Else
                cotacao.st_saldo_romaneio_aberto = "N"
            End If

            'fran 01/2014 f fase 2 melhorias

            cotacao.updateCentralCotacaoTotal()
            'atualiza tela
            Dim ds_cotacao As DataSet = cotacao.getCotacaoByFilters
            If ds_cotacao.Tables(0).Rows.Count > 0 Then
                Me.lbl_nr_valor_total_cotacao.Text = FormatCurrency(ds_cotacao.Tables(0).Rows(0).Item("nr_total_cotacao"), 2)
            End If
            'Calcula %
            If CDec(lbl_nr_valor_disponivel.Text) = 0 Then
                lbl_nr_perc.Text = "00.00%"
            Else
                lbl_nr_perc.Text = FormatPercent((CDec(lbl_nr_valor_total_cotacao.Text) / CDec(lbl_nr_valor_disponivel.Text)), 2)

            End If

            'fran i fase 2 melhorias
            'Calcula % valor mensal estimado
            If CDec(lbl_nr_valor_mensal_estimado.Text) = 0 Then
                lbl_nr_perc_valor_estimado.Text = "00.00%"
            Else
                lbl_nr_perc_valor_estimado.Text = FormatPercent((CDec(lbl_nr_valor_total_cotacao.Text) / CDec(lbl_nr_valor_mensal_estimado.Text)), 2)
            End If
            'fran f fase 2 melhorias

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_cotacao_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try

            args.IsValid = True
            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim lbl_id_central_cotacao_fornecedor As Label = CType(row.FindControl("lbl_id_central_cotacao_fornecedor"), Label)
            Dim chk_st_selecionado As CheckBox = CType(row.FindControl("chk_st_selecionado"), CheckBox)
            If chk_st_selecionado.Checked = True Then
                Dim cotfornec As New CotacaoFornecedor
                cotfornec.id_central_cotacao_item = Convert.ToInt32(ViewState.Item("id_central_cotacao_item").ToString)
                cotfornec.st_selecionado = "S"
                Dim dsfornec As DataSet = cotfornec.getCotacaoFornecedorByFilters
                'se já tem selecionado
                If dsfornec.Tables(0).Rows.Count > 0 Then
                    If ViewState.Item("incluirlinhacotacao") = "S" Then 'Se esta incluindo linha, ainda não está no banco
                        args.IsValid = False
                    Else
                        'verifica se o que esta selecionado é o proprio
                        cotfornec.id_central_cotacao_fornecedor = Convert.ToInt32(lbl_id_central_cotacao_fornecedor.Text)
                        dsfornec = cotfornec.getCotacaoFornecedorByFilters
                        If dsfornec.Tables(0).Rows.Count > 0 Then
                            args.IsValid = True 'se é sua propria seleção
                        Else
                            args.IsValid = False
                        End If

                    End If

                End If
            End If
            If Not args.IsValid Then
                messageControl.Alert("Já existe Parceiro selecionado para este item de cotação.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub EnviarEmailTecnicoAprovacao()
        Try
            If Page.IsValid = True Then
                Try

                    Dim notificacao As New Notificacao
                    Dim lAssunto As String = String.Concat("Aprovação de Cotações Central de Compras para Propriedade ", txt_id_propriedade.Text.Trim, " - ", lbl_nm_propriedade.Text.Trim & ".")
                    Dim lCorpo As String

                    lCorpo = "Existem cotações realizadas pela Central de Compras do Produtor "
                    lCorpo = lCorpo & "'" & lbl_nm_produtor.Text.Trim & "' para a Propriedade "
                    lCorpo = lCorpo & "'" & String.Concat(txt_id_propriedade.Text.Trim, " - ", lbl_nm_propriedade.Text.Trim) & "', "
                    lCorpo = lCorpo & " pendentes para serem aprovadas por você, técnico responsável."

                    ' 25/11/2009 - i Fran 
                    Dim propriedade As New Propriedade(Convert.ToInt32(txt_id_propriedade.Text))
                    Dim email_tecnico As String
                    email_tecnico = ""
                    If propriedade.id_tecnico > 0 Then
                        Dim tecnico As New Tecnico(Convert.ToInt32(propriedade.id_tecnico))
                        email_tecnico = tecnico.ds_email
                    End If
                    If Not email_tecnico.Equals(String.Empty) Then

                        ' 25/11/2009 - f

                        ' Parametro 7 - Central Cotacao 1.o Nível Gestor (enviar aos Tecnicos) - não precisa pois enviará ao tecnico responsavel éla propriedade
                        'fran 24/08/2010 i chamado 931
                        'If notificacao.enviaMensagemEmail( lAssunto, lCorpo,"recepcao.de.leite-pocos@danone.com", email_tecnico, , MailPriority.High) = True Then
                        If notificacao.enviaMensagemEmail(lAssunto, lCorpo, "central.compras@danone.com", email_tecnico, , MailPriority.High) = True Then
                            'fran 24/08/2010 i chamado 931
                            'If notificacao.enviaMensagemEmail(lAssunto,   lCorpo,"rece MailPriority.High, email_tecnico) = True Then

                            messageControl.Alert("A mensagem de solicitação de aprovação para o Técnico Responsável pela propriedade foi enviada aos destinatários com sucesso!")
                        Else

                            messageControl.Alert("A mensagem de solicitação de aprovação para o Técnico Responsável pela propriedade não pode ser enviada. Verifique se há destinatários cadastrados para este tipo de notificação.")
                            img_notificacao.Visible = True
                            lk_notificar_aprovadores.Visible = True

                        End If
                    Else
                        messageControl.Alert("A mensagem de solicitação de aprovação para o Técnico Responsável pela propriedade não pode ser enviada. Não há informação de email no cadastro do Técnico desta propriedade.")
                        img_notificacao.Visible = True
                        lk_notificar_aprovadores.Visible = True

                    End If

                Catch ex As Exception
                    messageControl.Alert(ex.Message)
                End Try


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Function VerificarCotacao() As Boolean

        Try

            Dim cotacaoitem As New CotacaoItem()
            Dim cotacaofornc As New CotacaoFornecedor()
            Dim dscotitem As DataSet = cotacaoitem.getCotacaoItensByFilters
            Dim dscotforn As DataSet
            Dim row As DataRow
            Dim rowfornec As DataRow
            Dim lmsg As String
            Dim isvalid As Boolean = True

            For Each row In dscotitem.Tables(0).Rows
                If row.Item("st_ver_mercado") = "N" Then
                    If CDbl(row.Item("nr_quantidade")) = 0 Then
                        isvalid = False
                        lmsg = "Há itens da cotação cujo cadastro está incompleto!"
                        Exit For
                    End If
                    cotacaofornc.id_central_cotacao_item = Convert.ToInt32(row.Item("id_central_cotacao_item"))
                    dscotforn = cotacaofornc.getCotacaoFornecedorByFilters()
                    For Each rowfornec In dscotforn.Tables(0).Rows
                        If Not CDbl(rowfornec.Item("nr_valor_unitario")) > 0 Then
                            isvalid = False
                            lmsg = "Há cotações para o item " + row.Item("nm_item").ToString + " cujo cadastro está incompleto!"
                            Exit For
                        End If
                    Next
                    If isvalid = False Then
                        Exit For
                    End If

                    cotacaofornc.st_selecionado = "S"
                    cotacaofornc.st_ver_mercado = "N"
                    If cotacaofornc.getCotacaoFornecedorByFilters.Tables(0).Rows.Count = 0 Then
                        isvalid = False
                        lmsg = "Não há cotação selecionada para o item " + row.Item("nm_item").ToString + "."
                        Exit For
                    End If
                End If
            Next

            If isvalid = False Then
                VerificarCotacao = False
                messageControl.Alert(lmsg)
            Else
                VerificarCotacao = True
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Function

    Protected Sub lk_enviar_aprovacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_enviar_aprovacao.Click
        If Page.IsValid Then


            Try
                Dim cotacao As New Cotacao
                cotacao.id_central_cotacao = Convert.ToInt32(ViewState.Item("id_central_cotacao").ToString)
                cotacao.updateCotacaoQtdeItensAprovacao()

                cotacao.id_situacao_cotacao = 3
                cotacao.updateCentralCotacaoSituacao()

                'fran chamado 717/860 i
                Dim cotacaoitem As New CotacaoItem
                cotacaoitem.id_central_status_aprovacao = 7 'Em Aprovação
                cotacaoitem.id_central_cotacao = cotacao.id_central_cotacao
                cotacaoitem.updateCentralCotacaoItemSituacaobyCotacao()
                'fran chamado 717/860 f

                EnviarEmailTecnicoAprovacao()

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If
    End Sub

    Protected Sub cv_itens_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_itens_fornecedores.ServerValidate
        Try
            'Dim cotacaoitem As New CotacaoItem()
            'Dim cotacaofornc As New CotacaoFornecedor()

            'cotacaoitem.id_central_cotacao = Convert.ToInt32(ViewState.Item("id_central_cotacao").ToString)
            'Dim dscotitem As DataSet = cotacaoitem.getCotacaoItensByFilters
            'Dim dscotforn As DataSet
            'Dim row As DataRow
            'Dim rowfornec As DataRow
            Dim lmsg As String

            args.IsValid = True

            'For Each row In dscotitem.Tables(0).Rows
            '    If row.Item("st_ver_mercado") = "N" Then
            '        If CDbl(row.Item("nr_quantidade")) = 0 Then
            '            args.IsValid = False
            '            lmsg = "Há itens da cotação cujo cadastro está incompleto!"
            '            Exit For
            '        End If
            '        cotacaofornc.id_central_cotacao_item = Convert.ToInt32(row.Item("id_central_cotacao_item"))
            '        dscotforn = cotacaofornc.getCotacaoFornecedorByFilters()
            '        For Each rowfornec In dscotforn.Tables(0).Rows
            '            If Not CDbl(rowfornec.Item("nr_valor_unitario")) > 0 Then
            '                args.IsValid = False
            '                lmsg = "Há cotações para o item " + row.Item("nm_item").ToString + " cujo cadastro está incompleto!"
            '                Exit For
            '            End If
            '        Next
            '        If args.IsValid = False Then
            '            Exit For
            '        End If

            '        cotacaofornc.st_selecionado = "S"
            '        cotacaofornc.st_ver_mercado = "N"
            '        If cotacaofornc.getCotacaoFornecedorByFilters.Tables(0).Rows.Count = 0 Then
            '            args.IsValid = False
            '            lmsg = "Não há cotação selecionada para o item " + row.Item("nm_item").ToString + "."
            '            Exit For
            '        End If
            '    End If
            'Next

            If ValidarItensFornecedores(lmsg) = False Then
                args.IsValid = False
                messageControl.Alert(lmsg)
            Else
                args.IsValid = True
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_notificar_aprovadores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_notificar_aprovadores.Click
        Try
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 9 'e-mail
            usuariolog.id_menu_item = 92
            usuariolog.id_nr_processo = ViewState.Item("id_central_cotacao").ToString
            usuariolog.nm_nr_processo = ViewState.Item("id_central_cotacao").ToString

            usuariolog.insertUsuarioLog()


            'FRAN 08/12/2020  incluir log 
            EnviarEmailTecnicoAprovacao()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cv_parceiro_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try

            args.IsValid = True
            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim cboparceiro As DropDownList = CType(row.FindControl("cbo_parceiro_central"), DropDownList)

            Dim cotfornec As New CotacaoFornecedor
            cotfornec.id_central_cotacao_item = Convert.ToInt32(ViewState.Item("id_central_cotacao_item").ToString)
            cotfornec.id_fornecedor = Convert.ToInt32(cboparceiro.SelectedValue.ToString)
            Dim dsfornec As DataSet = cotfornec.getCotacaoFornecedorByFilters
            'se já tem o fornecedor
            If dsfornec.Tables(0).Rows.Count > 0 Then
                args.IsValid = False
            Else
                args.IsValid = True
            End If

            If Not args.IsValid Then
                messageControl.Alert("Já existe este Parceiro para este item de cotação.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_gerar_pedido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_gerar_pedido.Click
        If Page.IsValid Then
            Try
                Dim cotacao As New Cotacao(Convert.ToInt32(ViewState.Item("id_central_cotacao")))
                If cotacao.id_situacao_cotacao = 5 Then 'se veio de aprovação
                    cotacao.id_central_status_aprovacao = 4
                End If
                cotacao.id_modificador = Session("id_login") 'fran set 2014 fase 3
                If cotacao.gerarPedido() = True Then

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'Incluir
                    usuariolog.id_menu_item = 92
                    usuariolog.ds_nm_processo = "Solicitar Cotação - Geração Pedido"
                    usuariolog.id_nr_processo = ViewState.Item("id_central_cotacao").ToString

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    messageControl.Alert("Pedidos gerados com sucesso!")

                Else
                    messageControl.Alert("Ocorreram problemas na geração do Pedido. Contate o administrador do sistema.")
                End If
                loadData()
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub cv_pedido_itens_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pedido_itens.ServerValidate
        Try
            Dim lmsg As String
            args.IsValid = True

            If ValidarItensFornecedores(lmsg) = False Then
                args.IsValid = False
                messageControl.Alert(lmsg)
            Else
                args.IsValid = True
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_pedido_aprovacao_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pedido_aprovacao.ServerValidate
        Try

            Dim lmsg As String

            args.IsValid = True

            Dim cotacao As New Cotacao(Convert.ToInt32(ViewState.Item("id_central_cotacao").ToString))
            Select Case cotacao.id_situacao_cotacao
                Case 3
                    args.IsValid = False
                    lmsg = "O pedido não pode ser gerado no momento pois a cotação está 'Em Aprovação'."
                Case 4
                    args.IsValid = False
                    lmsg = "O pedido não pode ser gerado pois todos os itens da cotação foram 'Recusados' pelos aprovadores."
                Case 5 'itens aprovados
                    args.IsValid = True
                Case 1, 2
                    'Se o link enviar aprovacao estiver habilitado
                    If lk_enviar_aprovacao.Enabled = True Then
                        args.IsValid = False
                        lmsg = "O pedido só poderá ser gerado após 'Enviar Aprovação'."
                    Else
                        'Cálcula saldo novamente
                        Dim saldodisponivel As New SaldoDisponivel
                        saldodisponivel.dt_referencia = String.Concat("01/" & Format(DateTime.Parse(Now), "MM/yyyy").ToString)
                        saldodisponivel.id_propriedade = Convert.ToInt32(txt_id_propriedade.Text)
                        'fran fase 2 melhoria i
                        ' lbl_nr_valor_disponivel.Text = FormatNumber(saldodisponivel.getSaldoDisponivel(), 2)
                        lbl_nr_valor_disponivel.Text = FormatNumber(saldodisponivel.getSaldoDisponivel(True), 2)
                        'fran fase 2 melhoria f
                        'Atualiza totalizadores da cotação
                        AtualizarTotalizadores()
                        'Atualiza link aprovacao
                        AtualizarLinkEnviarAprovacao()
                        'se após atualização devalores o link ficar em aprovacao
                        If lk_enviar_aprovacao.Enabled = True Then
                            args.IsValid = False
                            lmsg = "O pedido só poderá ser gerado após 'Enviar Aprovação'."
                        Else
                            args.IsValid = True
                        End If
                    End If
            End Select
            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cv_validar_item_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_validar_item.ServerValidate
        Try
            Dim lmsg As String

            args.IsValid = True
            Dim item As New Item
            If Not ViewState.Item("id_item_adicionar") Is Nothing Then
                If ViewState.Item("id_item_adicionar").ToString.Equals(String.Empty) Then
                    item.cd_item = txt_cd_item.Text.Trim
                Else
                    item.id_item = ViewState.Item("id_item_adicionar")
                End If
            Else
                item.cd_item = txt_cd_item.Text.Trim
            End If
            item.st_central_compras = "S"  ' Adri 18/11/2009 para trazer itens somente da Central
            Dim dsitem As DataSet = item.getItensCentralByFilters
            If dsitem.Tables(0).Rows.Count > 0 Then
                ViewState.Item("id_item_adicionar") = dsitem.Tables(0).Rows(0).Item("id_item")
                args.IsValid = True
            Else
                args.IsValid = False
                lmsg = "O item informado não existe no cadastro."
            End If
            If args.IsValid = True Then
                Dim cotacaoitem As New CotacaoItem
                cotacaoitem.id_central_cotacao = Convert.ToInt32(ViewState.Item("id_central_cotacao").ToString)
                cotacaoitem.id_item = Convert.ToInt32(ViewState.Item("id_item_adicionar").ToString)
                Dim dsci As DataSet = cotacaoitem.getCotacaoItensByFilters
                If dsci.Tables(0).Rows.Count > 0 Then
                    args.IsValid = False
                    lmsg = "O item informado já foi incluído na cotação!"
                End If
            End If
            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Private Function ValidarItensFornecedores(ByRef lmsg As String) As Boolean
        Try
            Dim cotacaoitem As New CotacaoItem()
            Dim cotacaofornc As New CotacaoFornecedor()
            cotacaoitem.id_central_cotacao = Convert.ToInt32(ViewState.Item("id_central_cotacao").ToString)
            Dim dscotitem As DataSet = cotacaoitem.getCotacaoItensByFilters
            Dim dscotforn As DataSet
            Dim row As DataRow
            Dim rowfornec As DataRow
            Dim lvalid As Boolean
            Dim lexisteitens As Boolean = False 'fran chamado 602 05/02/2010i 
            Dim parametroMilk As New Parametro
            lvalid = True

            For Each row In dscotitem.Tables(0).Rows
                If row.Item("st_ver_mercado") = "N" Then
                    lexisteitens = True 'fran chamado 602 - sinaliza que há itens com VerMercado = N, ou seja,itens que exigem seleção de fornecedor e geração pedido
                    If CDbl(row.Item("nr_quantidade")) = 0 Then
                        lvalid = False
                        lmsg = "Há itens da cotação cujo cadastro está incompleto!"
                        Exit For
                    End If
                    cotacaofornc.id_central_cotacao_item = Convert.ToInt32(row.Item("id_central_cotacao_item"))
                    dscotforn = cotacaofornc.getCotacaoFornecedorByFilters()
                    For Each rowfornec In dscotforn.Tables(0).Rows
                        If Not CDbl(rowfornec.Item("nr_valor_unitario")) > 0 Then
                            lvalid = False
                            lmsg = "Há cotações para o item " + row.Item("nm_item").ToString + " cujo cadastro está incompleto!"
                            Exit For
                        End If
                    Next
                    If lvalid = False Then
                        Exit For
                    End If

                    'fran 08/2014 fase 3 i
                    If row.Item("st_parcelamento") = "D" Then 'Se for parcelamento Danone
                        'O parametro de Politica de Parcelas da Central do cadastro de parametros mostra o nr maximo de parcelas que pode ser feita para parcelamento Danone,
                        'se este parametro for menor que o nr de parcelas, ou seja se o nr de parcelas informado for maior que o parametro consiste
                        If parametroMilk.nr_politica_parcelas < CInt(row.Item("nr_parcelas").ToString) Then
                            lvalid = False
                            lmsg = String.Concat("O número de parcelas informado para o item ", row.Item("nm_item").ToString, ", execede o limite cadastrado para Política de Parcelas em Parâmetros do Sistema.")

                        End If
                    End If
                    'fran 08/2014 fase 3 f

                    cotacaofornc.st_selecionado = "S"
                    cotacaofornc.st_ver_mercado = "N"
                    If cotacaofornc.getCotacaoFornecedorByFilters.Tables(0).Rows.Count = 0 Then
                        lvalid = False
                        lmsg = "Não há cotação selecionada para o item " + row.Item("nm_item").ToString + "."
                        Exit For
                    End If
                End If

            Next
            'fran chamdo 602 i
            'se só há itens com flag Ver Mercado
            If lexisteitens = False Then
                lvalid = False
                lmsg = "Todos os itens desta cotação são do tipo 'Ver Mercado'. Este tipo de cotação não pode gerar aprovação ou pedido."
            End If
            If lvalid = True Then
                ValidarItensFornecedores = True
            Else
                ValidarItensFornecedores = False
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Function

    Protected Sub txt_cd_item_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_item.TextChanged
        ' Fran 05/05/2010 - i
        lbl_nm_item.Text = String.Empty
        Try
            If Not txt_cd_item.Text.ToString.Equals(String.Empty) Then 'fran 05/05/2010
                Dim item As New Item
                item.cd_item = txt_cd_item.Text.Trim
                Dim dsitem As DataSet = item.getItensCentralByFilters
                If dsitem.Tables(0).Rows.Count > 0 Then
                    lbl_nm_item.Visible = True
                    lbl_nm_item.Enabled = True
                    lbl_nm_item.Text = dsitem.Tables(0).Rows(0).Item("nm_item")
                    ViewState.Item("id_item_adicionar") = dsitem.Tables(0).Rows(0).Item("id_item").ToString
                End If
            Else
                ViewState.Item("id_item_adicionar") = String.Empty
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' Fran 05/05/2010 - i

    End Sub
    Private Sub carregarCamposTransportador(ByVal id_index_row As Integer)

        Try

            Dim txt_cd_transportador As Anthem.TextBox = CType(gridCotacoes.Rows.Item(id_index_row).FindControl("txt_cd_transportador"), Anthem.TextBox)
            Dim lbl_nm_transportador As Label = CType(gridCotacoes.Rows.Item(id_index_row).FindControl("lbl_nm_transportador"), Label)

            If Not (customPage.getFilterValue("lupa_transportador", "nm_abreviado").Equals(String.Empty)) Then
                lbl_nm_transportador.Visible = True
                lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transportador", "nm_abreviado").ToString
            Else
                If Not (customPage.getFilterValue("lupa_transportador", "nm_pessoa").Equals(String.Empty)) Then
                    lbl_nm_transportador.Visible = True
                    lbl_nm_transportador.Text = Left(customPage.getFilterValue("lupa_transportador", "nm_pessoa").ToString, 12).ToString
                End If

            End If

            If Not (customPage.getFilterValue("lupa_transportador", "cd_pessoa").Equals(String.Empty)) Then
                txt_cd_transportador.Text = customPage.getFilterValue("lupa_transportador", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_transportador")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim txt_cd_transportador As Anthem.TextBox = CType(row.FindControl("txt_cd_transportador"), Anthem.TextBox)
            Dim lbl_nm_transportador As Label = CType(row.FindControl("lbl_nm_transportador"), Label)

            lbl_nm_transportador.Text = String.Empty
            hf_id_pessoa.Value = String.Empty

            If Not txt_cd_transportador.Text.ToString.Equals(String.Empty) Then
                Dim transp As New Pessoa
                transp.cd_pessoa = txt_cd_transportador.Text
                Dim dstransp As DataSet = transp.getTransportadorByFilters

                If dstransp.Tables(0).Rows.Count > 0 Then
                    hf_id_pessoa.Value = dstransp.Tables(0).Rows(0).Item("id_pessoa")
                    If Not dstransp.Tables(0).Rows(0).Item("nm_abreviado").Equals(String.Empty) Then
                        lbl_nm_transportador.Text = dstransp.Tables(0).Rows(0).Item("nm_abreviado")
                    Else
                        lbl_nm_transportador.Text = Left(dstransp.Tables(0).Rows(0).Item("nm_pessoa"), 12)
                    End If
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try

            args.IsValid = True
            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            'se já tem o fornecedor
            If Not hf_id_pessoa.Value.Equals(String.Empty) Then
                If hf_id_pessoa.Value > 0 Then
                    args.IsValid = True
                Else
                    args.IsValid = False
                End If
            Else
                args.IsValid = False
            End If

            If Not args.IsValid Then
                messageControl.Alert("Transportador não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cbo_tipo_frete_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'fran 25/08/2010 chamado 947 - obrigatoriedade de transportador
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim cbo_tipo_frete As DropDownList = CType(row.FindControl("cbo_tipo_frete"), DropDownList)
        Dim rfv_transportador As RequiredFieldValidator = CType(row.FindControl("rfv_transportador"), RequiredFieldValidator)

        If cbo_tipo_frete.SelectedValue = "D" Then
            rfv_transportador.Visible = True
        Else 'se FOB-I ou CIF
            rfv_transportador.Visible = False
        End If

    End Sub
End Class
