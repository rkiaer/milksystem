Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.IO

Partial Class frm_central_tabela_precos

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_propriedade.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_fornecedor
            .Attributes.Add("onclick", "javascript:ShowDialogFornecedor()")
            .ToolTip = "Filtrar Parceiros"
        End With
        With btn_lupa_item
            .Attributes.Add("onclick", "javascript:ShowDialogItem()")
            .ToolTip = "Filtrar Itens"
        End With

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabel As New Estabelecimento

            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim estado As New Estado

            cbo_estado_origem.DataSource = estado.getEstadosByFilters()
            cbo_estado_origem.DataTextField = "nm_estado"
            cbo_estado_origem.DataValueField = "id_estado"
            cbo_estado_origem.DataBind()
            cbo_estado_origem.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'cbo_estado_origem.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            cbo_estado_destino.DataSource = estado.getEstadosByFilters()
            cbo_estado_destino.DataTextField = "nm_estado"
            cbo_estado_destino.DataValueField = "id_estado"
            cbo_estado_destino.DataBind()
            cbo_estado_destino.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'cbo_estado_destino.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            If Not (Request("id_central_tabela_precos") Is Nothing) Then
                ViewState.Item("id_central_tabela_precos") = Request("id_central_tabela_precos")
                'fran fase 2 melhorias i
                lbl_dt_cotacao.Visible = True
                txt_dt_cotacao.Visible = False
                txt_hr_cotacao.Visible = False
                txt_min_cotacao.Visible = False
                lbl_labelhr.Visible = False
                lbl_pontos.Visible = False
                rv_hr.Enabled = False
                rv_min.Enabled = False
                rf_dt.Enabled = False
                rf_hr.Enabled = False
                rf_min.Enabled = False
                'fran fase 2 melhorias f
                loadData()
            Else
                'fran fase 2 melhorias i
                lbl_dt_cotacao.Visible = False
                txt_dt_cotacao.Visible = True
                txt_hr_cotacao.Visible = True
                txt_min_cotacao.Visible = True
                lbl_labelhr.Visible = True
                lbl_pontos.Visible = True
                rv_hr.Enabled = True
                rv_min.Enabled = True
                rf_dt.Enabled = True
                rf_hr.Enabled = True
                rf_min.Enabled = True
                txt_dt_cotacao.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
                txt_hr_cotacao.Text = DateTime.Parse(Now).ToString("HH")
                txt_min_cotacao.Text = DateTime.Parse(Now).ToString("mm")
                'fran fase 2 melhorias f

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub cbo_estado_origem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estado_origem.SelectedIndexChanged

        If Not (cbo_estado_origem.SelectedValue.Trim().Equals(String.Empty)) Then
            loadCidadesOrigemByEstado(Convert.ToInt32(cbo_estado_origem.SelectedValue))
        Else
            cbo_cidade_origem.Items.Clear()
            cbo_cidade_origem.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_cidade_origem.Enabled = False
        End If

    End Sub

    Private Sub loadCidadesOrigemByEstado(ByVal id_estado As Int32)

        Try

            cbo_cidade_origem.Enabled = True

            Dim cidade As New Cidade
            cidade.id_estado = id_estado

            cbo_cidade_origem.DataSource = cidade.getCidadeByFilters()
            cbo_cidade_origem.DataTextField = "nm_cidade"
            cbo_cidade_origem.DataValueField = "id_cidade"
            cbo_cidade_origem.DataBind()
            cbo_cidade_origem.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim id_central_tabela_precos As Int32 = Convert.ToInt32(ViewState.Item("id_central_tabela_precos"))
            Dim tabelapreco As New TabelaPrecos(id_central_tabela_precos)


            If (tabelapreco.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = tabelapreco.id_estabelecimento.ToString()
                'cbo_estabelecimento.Enabled = False
            End If

            If (tabelapreco.id_fornecedor > 0) Then
                hf_id_pessoa.Value = tabelapreco.id_fornecedor.ToString
            End If

            txt_cd_pessoa.Text = tabelapreco.cd_fornecedor
            lbl_nm_pessoa.Visible = True
            lbl_nm_pessoa.Text = tabelapreco.nm_fornecedor
            'btn_lupa_fornecedor.Visible = False

            ' 06/11/2009 - i
            If (tabelapreco.id_item > 0) Then
                hf_id_item.Value = tabelapreco.id_item.ToString
            End If

            'If (tabelapreco.id_item > 0) Then
            '    txt_cd_item.Text = tabelapreco.id_item.ToString
            '    lbl_nm_item.Visible = True
            '    lbl_nm_item.Text = tabelapreco.nm_item
            'Else
            '    lbl_nm_item.Text = ""
            '    lbl_nm_item.Visible = False
            'End If
            txt_cd_item.Text = tabelapreco.cd_item.ToString
            lbl_nm_item.Visible = True
            lbl_nm_item.Text = tabelapreco.nm_item
            ' 06/11/2009 - f

            Me.lbl_unidade_medida.Text = tabelapreco.cd_unidade_medida


            If (tabelapreco.id_cidade_origem > 0) Then
                loadCidadesOrigemByEstado(tabelapreco.id_estado_origem)
                cbo_estado_origem.SelectedValue = tabelapreco.id_estado_origem.ToString()
                cbo_cidade_origem.SelectedValue = tabelapreco.id_cidade_origem.ToString()
                cbo_estado_origem.Enabled = False
                cbo_cidade_origem.Enabled = False
            End If

            If (tabelapreco.id_cidade_destino > 0) Then
                loadCidadesDestinoByEstado(tabelapreco.id_estado_destino)
                cbo_estado_destino.SelectedValue = tabelapreco.id_estado_destino.ToString()
                cbo_cidade_destino.SelectedValue = tabelapreco.id_cidade_destino.ToString()
            End If

            'txt_nr_volume_ate.Text = tabelapreco.nr_volume_ate.ToString
            txt_nr_valor.Text = tabelapreco.nr_valor.ToString
            txt_nr_valor_sacaria.Text = tabelapreco.nr_valor_sacaria.ToString
            txt_nr_valor_padrao.Text = FormatNumber(tabelapreco.nr_valor_padrao.ToString, 2)
            'txt_nr_valor_icms.Text = tabelapreco.nr_valor_icms.ToString
            'txt_nr_parcelas.Text = tabelapreco.nr_parcelas.ToString  ' Adri 25/01/2010 - Chamado 556

            If Not (tabelapreco.dt_cotacao Is Nothing) Then
                lbl_dt_cotacao.Text = DateTime.Parse(tabelapreco.dt_cotacao).ToString("dd/MM/yyyy HH:mm")
            Else
                lbl_dt_cotacao.Text = ""
            End If

            If Not (tabelapreco.nm_modificador Is Nothing) Then
                lbl_modificador.Text = tabelapreco.nm_modificador.ToString()
            Else
                lbl_modificador.Text = ""
            End If

            If Not (tabelapreco.dt_modificacao Is Nothing) Then
                lbl_dt_modificacao.Text = tabelapreco.dt_modificacao.ToString()
            Else
                lbl_dt_modificacao.Text = ""
            End If

            Dim dstabelaprecoemuso As DataSet = tabelapreco.getCentralTabelaPrecosEmUso
            'se tem pedido em uso com a  tabela preco
            If dstabelaprecoemuso.Tables(0).Rows.Count > 0 Then
                ViewState.Item("novatabelapreco") = "S"
                cbo_estabelecimento.Enabled = False
                txt_cd_item.Enabled = False
                btn_lupa_item.Visible = False
                txt_cd_pessoa.Enabled = False
                btn_lupa_fornecedor.Visible = False

            Else
                ViewState.Item("novatabelapreco") = "N"
                cbo_estabelecimento.Enabled = True
                txt_cd_item.Enabled = True
                btn_lupa_item.Visible = True
                txt_cd_pessoa.Enabled = True
                btn_lupa_fornecedor.Visible = True
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub updateData()
        If Page.IsValid = True Then

            Try

                Dim tabelapreco As New TabelaPrecos()


                If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then
                    tabelapreco.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                End If

                If Not (hf_id_pessoa.Value.Equals(String.Empty)) Then
                    tabelapreco.id_fornecedor = Convert.ToInt32(hf_id_pessoa.Value)
                End If

                If Not (hf_id_item.Value.Equals(String.Empty)) Then  ' 06/11/2009
                    tabelapreco.id_item = Convert.ToInt32(hf_id_item.Value)  ' 06/11/2009
                End If

                If Not (cbo_cidade_origem.SelectedValue.Trim().Equals(String.Empty)) Then
                    tabelapreco.id_cidade_origem = Convert.ToInt32(cbo_cidade_origem.SelectedValue)
                End If

                If Not (cbo_cidade_destino.SelectedValue.Trim().Equals(String.Empty)) Then
                    tabelapreco.id_cidade_destino = Convert.ToInt32(cbo_cidade_destino.SelectedValue)
                End If

                'If Not (txt_nr_volume_ate.Text.Trim().Equals(String.Empty)) Then
                '    tabelapreco.nr_volume_ate = Convert.ToDouble(txt_nr_volume_ate.Text)
                'End If
                If Not (txt_nr_valor_padrao.Text.Trim().Equals(String.Empty)) Then
                    tabelapreco.nr_valor_padrao = Convert.ToDouble(txt_nr_valor_padrao.Text)
                End If
                If Not (txt_nr_valor_sacaria.Text.Trim().Equals(String.Empty)) Then
                    tabelapreco.nr_valor_sacaria = Convert.ToDouble(txt_nr_valor_sacaria.Text)
                End If
                If Not (txt_nr_valor.Text.Trim().Equals(String.Empty)) Then
                    tabelapreco.nr_valor = Convert.ToDouble(txt_nr_valor.Text)
                End If
                'If Not (txt_nr_valor_icms.Text.Trim().Equals(String.Empty)) Then
                '    tabelapreco.nr_valor_icms = Convert.ToDouble(txt_nr_valor_icms.Text)
                'End If

                '' Adri 25/01/2010 - Chamado 556 - i
                'If Not (txt_nr_parcelas.Text.Trim().Equals(String.Empty)) Then
                '    tabelapreco.nr_parcelas = Convert.ToInt32(txt_nr_parcelas.Text)
                'End If
                '' Adri 25/01/2010 - Chamado 556 - f

                tabelapreco.id_modificador = Session("id_login")

                If Not (ViewState.Item("id_central_tabela_precos") Is Nothing) Then
                    'se ja tem pedido com a tabela de preco
                    If ViewState.Item("novatabelapreco") = "S" Then
                        'VERIFICA SE HOUVE ALTERACAO NO CADASTRO (PEGA OS DADOS DO BANCO)
                        Dim lbvaloralterado As Boolean = False
                        Dim tabpreco As New TabelaPrecos
                        tabpreco.id_central_tabela_precos = Convert.ToInt32(ViewState.Item("id_central_tabela_precos"))
                        Dim dstabpreco As DataSet = tabpreco.getCentralTabelaPrecosByFilters
                        If dstabpreco.Tables(0).Rows.Count > 0 Then
                            Dim lnr_valor As Decimal = dstabpreco.Tables(0).Rows(0).Item("nr_valor")
                            Dim lnr_valor_sacaria As Decimal = dstabpreco.Tables(0).Rows(0).Item("nr_valor_sacaria")
                            Dim lnr_valor_padrao As Decimal = dstabpreco.Tables(0).Rows(0).Item("nr_valor_padrao")
                            If CDec(lnr_valor) <> tabelapreco.nr_valor Then
                                lbvaloralterado = True
                            End If
                            If CDec(lnr_valor_sacaria) <> tabelapreco.nr_valor_sacaria Then
                                lbvaloralterado = True
                            End If
                            If CDec(lnr_valor_padrao) <> tabelapreco.nr_valor_padrao Then
                                lbvaloralterado = True
                            End If
                        End If

                        'Se hou ve alteração nos valores, deve incluir nova tabela preco com nova data de cotação
                        If lbvaloralterado = True Then
                            'inativa a tabela anterior
                            tabelapreco.id_central_tabela_precos = Convert.ToInt32(ViewState.Item("id_central_tabela_precos"))
                            tabelapreco.id_situacao = 2 'inativo
                            tabelapreco.updateCentralTabelaPrecosSituacao()

                            'inclui nova tabela
                            tabelapreco.dt_cotacao = DateTime.Parse(Now()).ToString("dd/MM/yyyy HH:mm")
                            tabelapreco.id_situacao = 1 'inativo
                            ViewState.Item("id_central_tabela_precos") = tabelapreco.insertCentralTabelaPrecos()

                            'fran 08/12/2020 i dango
                            Dim usuariolog As New UsuarioLog
                            usuariolog.id_usuario = Session("id_login")
                            usuariolog.ds_id_session = Session.SessionID.ToString()
                            usuariolog.id_tipo_log = 4 'incluir
                            usuariolog.id_menu_item = 88
                            usuariolog.insertUsuarioLog()
                            'fran 08/12/2020 f dango

                            messageControl.Alert("Registro inserido com sucesso.")
                        End If
                    Else
                        tabelapreco.id_central_tabela_precos = Convert.ToInt32(ViewState.Item("id_central_tabela_precos"))
                        tabelapreco.updateCentralTabelaPrecos()

                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alteração
                        usuariolog.id_menu_item = 88
                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro alterado com sucesso.")

                    End If

                Else
                    'fran 04/02/2009 i Se não tiver o item cadastrado para o parceiro... deve incluir no cadastro item_parceiro
                    Dim item_parceiro As New ItemParceiro
                    item_parceiro.id_item = Convert.ToInt32(hf_id_item.Value)
                    item_parceiro.id_fornecedor = Convert.ToInt32(hf_id_pessoa.Value)
                    Dim ds_item_parceiro As DataSet = item_parceiro.getParceiroByFilters()
                    'fran 04/02/2009 f

                    'fran fase 2 melhorias i
                    tabelapreco.dt_cotacao = DateTime.Parse(String.Concat(txt_dt_cotacao.Text, " ", txt_hr_cotacao.Text, ":", txt_min_cotacao.Text)).ToString("dd/MM/yyyy HH:mm")
                    'fran fase 2 melhorias f

                    ViewState.Item("id_central_tabela_precos") = tabelapreco.insertCentralTabelaPrecos()

                    'fran 04/02/2009 i 
                    If ds_item_parceiro.Tables(0).Rows.Count <= 0 Then  ' Se fornecedor ainda não foi incluído
                        messageControl.Alert("Registro inserido com sucesso. O dados do item devem ser complementados no cadastro de Itens x Parceiros.")
                    Else 'fran 04/02/2009 f
                        messageControl.Alert("Registro inserido com sucesso.")
                    End If


                End If

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_central_tabela_precos.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_central_tabela_precos.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Private Sub carregarCamposFornecedor()

        Try
            If Not (customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_fornecedor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarEstadoCidadeFornecedor()

        Try
            Dim pessoa As New Pessoa
            pessoa.cd_pessoa = txt_cd_pessoa.Text
            pessoa.id_grupo = 2   ' Adri 04/05/2010 
            Dim dspessoa As DataSet = pessoa.getPessoaByFilters
            'Dim dspessoa As DataSet = pessoa.getFornecedorByFilters ' Adri 04/05/2010 (ocorre erro no id_estado)
            If dspessoa.Tables(0).Rows.Count > 0 Then
                With dspessoa.Tables(0).Rows(0)
                    hf_id_pessoa.Value = .Item("id_pessoa").ToString
                    lbl_nm_pessoa.Visible = True
                    lbl_nm_pessoa.Text = .Item("nm_pessoa").ToString
                    If Not IsDBNull(.Item("id_estado")) Then
                        cbo_estado_origem.SelectedValue = .Item("id_estado")
                        cbo_cidade_origem.Items.Clear()
                        loadCidadesOrigemByEstado(.Item("id_estado"))
                        cbo_cidade_origem.SelectedValue = .Item("id_cidade")
                        cbo_estado_origem.Enabled = False
                        cbo_cidade_origem.Enabled = False
                    Else
                        'fran 16/03/2010 i
                        cbo_estado_origem.SelectedValue = String.Empty
                        cbo_cidade_origem.Items.Clear()
                        cbo_cidade_origem.Enabled = False
                        'fran 16/03/2010 f

                    End If
                End With
            Else
                'fran 16/03/2010 i
                cbo_estado_origem.SelectedValue = String.Empty
                cbo_cidade_origem.Items.Clear()
                cbo_cidade_origem.Enabled = False
                'fran 16/03/2010 f

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposItem()

        Try

            ' 06/11/2009 - i
            'Me.txt_cd_item.Text = hf_id_item.Value

            If Not (customPage.getFilterValue("lupa_item", "cd_item").Equals(String.Empty)) Then
                Me.txt_cd_item.Text = customPage.getFilterValue("lupa_item", "cd_item").ToString
            End If
            ' 06/11/2009 - f

            If Not (customPage.getFilterValue("lupa_item", "nm_item").Equals(String.Empty)) Then
                Me.lbl_nm_item.Text = customPage.getFilterValue("lupa_item", "nm_item").ToString
            Else
                Me.lbl_nm_item.Text = String.Empty
            End If

            If Not (customPage.getFilterValue("lupa_item", "cd_unidade_medida").Equals(String.Empty)) Then
                Me.lbl_unidade_medida.Text = customPage.getFilterValue("lupa_item", "cd_unidade_medida").ToString
            Else
                'fran 16/03/2010 i
                Me.lbl_unidade_medida.Text = String.Empty

                'fran 16/03/2010 f

            End If

            customPage.clearFilters("lupa_item")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub btn_lupa_fornecedor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_fornecedor.Click
        'If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposFornecedor()
        carregarEstadoCidadeFornecedor() 'fran 04/02/2010 i
        'End If
    End Sub

    Protected Sub btn_lupa_item_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_item.Click
        'If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
        Me.lbl_nm_item.Visible = True
        carregarCamposItem()
        'End If
    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        'ViewState.Item("cboestabelecimentoanterior") = cbo_estabelecimento.SelectedValue.ToString
        'Me.lbl_nm_pessoa.Text = ""
        'Me.txt_cd_pessoa.Text = ""
        'Me.lbl_nm_pessoa.Visible = False
        'Me.hf_id_pessoa.Value = ""
    End Sub



    Protected Sub cv_fornecedor_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_fornecedor.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidpessoa As Int32

            'pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
            End If
            pessoa.cd_pessoa = Me.txt_cd_pessoa.Text.Trim

            lidpessoa = pessoa.validarFornecedor()

            If lidpessoa > 0 Then
                args.IsValid = True
                hf_id_pessoa.Value = lidpessoa
            Else
                hf_id_pessoa.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Fornecedor não cadastrado.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub cv_item_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_item.ServerValidate
        Try
            Dim item As New Item()
            Dim liditem As Int32 'fran 30/12/2009 chamdo 556
            item.cd_item = Me.txt_cd_item.Text.Trim  ' 06/11/2009

            'fran 30/12/2009 i chamdo 556
            If Not (Me.hf_id_item.Value.Trim.Equals(String.Empty)) Then
                item.id_item = Convert.ToInt32(Me.hf_id_item.Value)
            End If

            'args.IsValid = item.validarItem()

            'If Not args.IsValid Then
            'messageControl.Alert("Item não cadastrado.")
            'End If

            liditem = item.validarItemCentral

            If liditem > 0 Then
                args.IsValid = True
                hf_id_item.Value = liditem
            Else
                hf_id_item.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Item não cadastrado.")
            End If
            'fran 30/12/2009 f chamdo 556
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub txt_cd_item_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_item.TextChanged
        hf_id_item.Value = String.Empty
        'fran 30/12/2009 i não deve limpar o codigo do item
        'txt_cd_item.Text = String.Empty  ' 06/11/2009
        'fran 30/12/2009 f
        lbl_nm_item.Text = String.Empty
        'lbl_nm_item.Visible = False  ' Adri 04/05/2010
        'Fran 16/03/2010 chamado 684
        lbl_unidade_medida.Text = String.Empty 'fran 05/05/2010

        Try
            If Not txt_cd_item.Text.ToString.Equals(String.Empty) Then
                Dim item As New Item
                item.cd_item = txt_cd_item.Text.Trim
                Dim dsitem As DataSet = item.getItensCentralByFilters
                If dsitem.Tables(0).Rows.Count > 0 Then
                    lbl_nm_item.Enabled = True
                    lbl_nm_item.Text = dsitem.Tables(0).Rows(0).Item("nm_item")
                    hf_id_item.Value = dsitem.Tables(0).Rows(0).Item("id_item").ToString
                    lbl_unidade_medida.Text = dsitem.Tables(0).Rows(0).Item("cd_unidade_medida").ToString
                Else
                    lbl_nm_item.Text = String.Empty
                    lbl_unidade_medida.Text = String.Empty
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        'Fran 16/03/2010 chamado 684
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_central_tabela_precos.aspx")

    End Sub


    Protected Sub cbo_estado_destino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estado_destino.SelectedIndexChanged
        If Not (cbo_estado_destino.SelectedValue.Trim().Equals(String.Empty)) Then
            loadCidadesDestinoByEstado(Convert.ToInt32(cbo_estado_destino.SelectedValue))
        Else
            cbo_estado_destino.Items.Clear()
            cbo_estado_destino.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_estado_destino.Enabled = False
        End If

    End Sub
    Private Sub loadCidadesDestinoByEstado(ByVal id_estado As Int32)

        Try

            cbo_cidade_destino.Enabled = True

            Dim cidade As New Cidade
            cidade.id_estado = id_estado
            'fran 30/12/2009 chamado 556 i
            'cbo_cidade_destino.DataSource = cidade.getCidadeByFilters()
            cbo_cidade_destino.DataSource = cidade.getCidadeCentralByFilters()
            'fran 30/12/2009 chamado 556 f

            cbo_cidade_destino.DataTextField = "nm_cidade"
            cbo_cidade_destino.DataValueField = "id_cidade"
            cbo_cidade_destino.DataBind()
            cbo_cidade_destino.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        Try
            'fran 30/12/2009 i 
            hf_id_pessoa.Value = String.Empty
            lbl_nm_pessoa.Text = String.Empty
            lbl_nm_pessoa.Visible = False
            'fran 30/12/2009 f
            'fran 04/02/2010 i - qdo fornecedor for selecionado deve assumir a cidade e estado origem do fornecedor
            'If cbo_cidade_origem.Items.Count > 0 Then
            '    cbo_cidade_origem.SelectedValue = String.Empty
            'End If
            If Not txt_cd_pessoa.Text.ToString.Equals(String.Empty) Then 'fran 05/05/2010
                carregarEstadoCidadeFornecedor()
            Else
                'fran 05/05/2010 i
                cbo_estado_origem.SelectedValue = String.Empty
                cbo_cidade_origem.Items.Clear()
                cbo_cidade_origem.Enabled = False
                'fran 05/05/2010 f
            End If
            'fran 04/02/2010 f
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class

