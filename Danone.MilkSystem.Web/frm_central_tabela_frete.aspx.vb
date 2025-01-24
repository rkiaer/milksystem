Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.IO

Partial Class frm_central_tabela_frete

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_central_tabela_frete.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        'With btn_lupa_fornecedor
        '    .Attributes.Add("onclick", "javascript:ShowDialogFornecedor()")
        '    .ToolTip = "Filtrar Parceiros"
        'End With
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

            Dim pessoa As New Pessoa
            cbo_transportador.DataSource = pessoa.getTransportadorCentralByFilters()
            cbo_transportador.DataTextField = "ds_transportador"
            cbo_transportador.DataValueField = "id_pessoa"
            cbo_transportador.DataBind()
            cbo_transportador.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim situacao As New Situacao
            cbo_situacao.DataSource = situacao.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True

            If Not (Request("id_central_tabela_frete") Is Nothing) Then
                ViewState.Item("id_central_tabela_frete") = Request("id_central_tabela_frete")
                loadData()
            Else
                Me.loadGridNovaTabelaFrete()
                txt_dt_cotacao.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy").ToString
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub loadGridNovaTabelaFrete()

        Try

            Dim veiculocentralcompras As New VeiculoCentralCompras

            veiculocentralcompras.id_situacao = 1

            Dim dsveiculocentral As DataSet = veiculocentralcompras.getVeiculoCentralComprasByFilters

            If (dsveiculocentral.Tables(0).Rows.Count > 0) Then
                gridVeiculos.Visible = True
                gridVeiculos.DataSource = Helper.getDataView(dsveiculocentral.Tables(0), "nm_veiculocentralcompras")
                gridVeiculos.DataBind()
            Else
                gridVeiculos.Visible = False
            End If

        Catch ex As System.Exception
            Me.messageControl.Alert(ex.Message)
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

            Dim id_central_tabela_frete As Int32 = Convert.ToInt32(ViewState.Item("id_central_tabela_frete"))
            Dim tabelafrete As New TabelaFrete(id_central_tabela_frete)

            If (tabelafrete.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = tabelafrete.id_estabelecimento.ToString()
                'cbo_estabelecimento.Enabled = False
            End If

            If (tabelafrete.id_fornecedor > 0) Then
                'hf_id_pessoa.Value = tabelafrete.id_fornecedor.ToString
                Me.cbo_transportador.SelectedValue = tabelafrete.id_fornecedor.ToString
            End If

            'txt_cd_pessoa.Text = tabelafrete.cd_fornecedor
            'lbl_nm_pessoa.Visible = True
            'lbl_nm_pessoa.Text = tabelafrete.nm_fornecedor
            'btn_lupa_fornecedor.Visible = False

            ' 06/11/2009 - i
            If (tabelafrete.id_item > 0) Then
                hf_id_item.Value = tabelafrete.id_item.ToString
            End If

            'If (tabelafrete.id_item > 0) Then
            '    txt_cd_item.Text = tabelafrete.id_item.ToString
            '    lbl_nm_item.Visible = True
            '    lbl_nm_item.Text = tabelafrete.nm_item
            'Else
            '    lbl_nm_item.Text = ""
            '    lbl_nm_item.Visible = False
            'End If

            txt_cd_item.Text = tabelafrete.cd_item.ToString
            lbl_nm_item.Visible = True
            lbl_nm_item.Text = tabelafrete.nm_item
            ' 06/11/2009 - f

            Me.lbl_unidade_medida.Text = tabelafrete.cd_unidade_medida

            If (tabelafrete.id_cidade_origem > 0) Then
                loadCidadesOrigemByEstado(tabelafrete.id_estado_origem)
                cbo_estado_origem.SelectedValue = tabelafrete.id_estado_origem.ToString()
                cbo_cidade_origem.SelectedValue = tabelafrete.id_cidade_origem.ToString()
            End If

            If (tabelafrete.id_cidade_destino > 0) Then
                loadCidadesDestinoByEstado(tabelafrete.id_estado_destino)
                cbo_estado_destino.SelectedValue = tabelafrete.id_estado_destino.ToString()
                cbo_cidade_destino.SelectedValue = tabelafrete.id_cidade_destino.ToString()
            End If

            'txt_nr_valor_truck_graneleiro.Text = tabelafrete.nr_valor_truck_graneleiro.ToString
            'txt_nr_valor_truck_rosca.Text = tabelafrete.nr_valor_truck_rosca.ToString
            'txt_nr_valor_truck_4eixo.Text = tabelafrete.nr_valor_truck_4eixo.ToString
            'txt_nr_valor_carreta_graneleiro.Text = tabelafrete.nr_valor_carreta_graneleiro.ToString
            'txt_nr_valor_carreta_rosca.Text = tabelafrete.nr_valor_carreta_rosca.ToString
            'txt_nr_valor_bitrem.Text = tabelafrete.nr_valor_bitrem

            'If Not (tabelafrete.dt_cotacao Is Nothing) Then
            '    lbl_dt_cotacao.Text = DateTime.Parse(tabelafrete.dt_cotacao).ToString("dd/MM/yyyy hh:mm")
            'Else
            '    lbl_dt_cotacao.Text = ""
            'End If
            If Not (tabelafrete.dt_cotacao Is Nothing) Then
                txt_dt_cotacao.Text = DateTime.Parse(tabelafrete.dt_cotacao).ToString("dd/MM/yyyy HH:mm")
            Else
                txt_dt_cotacao.Text = ""
            End If

            If Not (tabelafrete.nm_modificador Is Nothing) Then
                lbl_modificador.Text = tabelafrete.nm_modificador.ToString()
            Else
                lbl_modificador.Text = ""
            End If

            If Not (tabelafrete.dt_modificacao Is Nothing) Then
                lbl_dt_modificacao.Text = tabelafrete.dt_modificacao.ToString()
            Else
                lbl_dt_modificacao.Text = ""
            End If

            Dim centralTabelaFreteVeiculos As New TabelaFreteVeiculos

            centralTabelaFreteVeiculos.id_central_tabela_frete = id_central_tabela_frete

            Dim dscentraltabelafreteceiculos As DataSet = centralTabelaFreteVeiculos.getCentralTabelaFreteVeiculos

            If (dscentraltabelafreteceiculos.Tables(0).Rows.Count > 0) Then
                Me.gridVeiculos.Visible = True
                gridVeiculos.DataSource = Helper.getDataView(dscentraltabelafreteceiculos.Tables(0), "nm_veiculocentralcompras")
                gridVeiculos.DataBind()
            Else
                Me.gridVeiculos.Visible = False
            End If

            If (Not Me.txt_dt_cotacao.Text.Equals(String.Empty) AndAlso DateTime.Compare(DateTime.Parse(Now).ToString("dd/MM/yyyy"), Convert.ToDateTime(Me.txt_dt_cotacao.Text)) > 0) Then
                Me.cbo_estabelecimento.Enabled = False
                Me.cbo_transportador.Enabled = False
                Me.txt_cd_item.Enabled = False
                Me.btn_lupa_item.Visible = False
                Me.cbo_estado_origem.Enabled = False
                Me.cbo_cidade_origem.Enabled = False
                Me.cbo_estado_destino.Enabled = False
                Me.cbo_cidade_destino.Enabled = False
                Me.txt_dt_cotacao.Enabled = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub updateData()
        If Page.IsValid = True Then

            Try

                Dim tabelafrete As New TabelaFrete()

                If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then
                    tabelafrete.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                End If
                tabelafrete.id_fornecedor = Convert.ToInt32(cbo_transportador.SelectedValue)

                'If Not (hf_id_pessoa.Value.Equals(String.Empty)) Then
                '    tabelafrete.id_fornecedor = Convert.ToInt32(hf_id_pessoa.Value)
                'End If
                ' Modificado 06/11/2009 - Denise i. 
                If Not (hf_id_item.Value.Equals(String.Empty)) Then  ' 06/11/2009
                    tabelafrete.id_item = Convert.ToInt32(hf_id_item.Value)  ' 06/11/2009
                End If

                'If Not (txt_cd_item.Text.Trim.Equals(String.Empty)) Then
                '    tabelafrete.id_item = Convert.ToInt32(txt_cd_item.Text)
                'End If

                ' Modificado 06/11/2009 - Denise f. 

                If Not (cbo_cidade_origem.SelectedValue.Trim().Equals(String.Empty)) Then
                    tabelafrete.id_cidade_origem = Convert.ToInt32(cbo_cidade_origem.SelectedValue)
                End If

                If Not (cbo_cidade_destino.SelectedValue.Trim().Equals(String.Empty)) Then
                    tabelafrete.id_cidade_destino = Convert.ToInt32(cbo_cidade_destino.SelectedValue)
                End If

                'If Not (txt_nr_valor_truck_graneleiro.Text.Trim().Equals(String.Empty)) Then
                '    tabelafrete.nr_valor_truck_graneleiro = Convert.ToDouble(txt_nr_valor_truck_graneleiro.Text)
                'End If

                'If Not (txt_nr_valor_truck_rosca.Text.Trim().Equals(String.Empty)) Then
                '    tabelafrete.nr_valor_truck_rosca = Convert.ToDouble(txt_nr_valor_truck_rosca.Text)
                'End If

                'If Not (txt_nr_valor_truck_4eixo.Text.Trim().Equals(String.Empty)) Then
                '    tabelafrete.nr_valor_truck_4eixo = Convert.ToDouble(txt_nr_valor_truck_4eixo.Text)
                'End If

                'If Not (txt_nr_valor_carreta_graneleiro.Text.Trim().Equals(String.Empty)) Then
                '    tabelafrete.nr_valor_carreta_graneleiro = Convert.ToDouble(txt_nr_valor_carreta_graneleiro.Text)
                'End If

                'If Not (txt_nr_valor_carreta_rosca.Text.Trim().Equals(String.Empty)) Then
                '    tabelafrete.nr_valor_carreta_rosca = Convert.ToDouble(txt_nr_valor_carreta_rosca.Text)
                'End If

                'If Not (txt_nr_valor_bitrem.Text.Trim().Equals(String.Empty)) Then
                '    tabelafrete.nr_valor_bitrem = Convert.ToDouble(txt_nr_valor_bitrem.Text)
                'End If

                tabelafrete.id_modificador = Session("id_login")

                Dim row As GridViewRow
                For Each row In gridVeiculos.Rows
                    If (Not row Is Nothing) Then
                        Dim txt_valor_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_valor_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        tabelafrete.tfv_id_veiculocentral.Add(Convert.ToInt32(gridVeiculos.DataKeys(row.RowIndex).Value.ToString))
                        If txt_valor_frete.Text.ToString.Equals(String.Empty) Then
                            tabelafrete.tfv_nr_valor_frete.Add(0)
                        Else
                            tabelafrete.tfv_nr_valor_frete.Add(Convert.ToDecimal(txt_valor_frete.Text))
                        End If
                    End If
                Next
                tabelafrete.id_situacao = cbo_situacao.SelectedValue

                If Not (ViewState.Item("id_central_tabela_frete") Is Nothing) Then

                    tabelafrete.id_central_tabela_frete = Convert.ToInt32(ViewState.Item("id_central_tabela_frete"))
                    tabelafrete.updateCentralTabelaFrete()

                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteração
                    usuariolog.id_menu_item = 89
                    usuariolog.id_nr_processo = ViewState.Item("id_central_tabela_frete").ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_central_tabela_frete") = tabelafrete.insertCentralTabelaFrete()

                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 89
                    usuariolog.id_nr_processo = ViewState.Item("id_central_tabela_frete").ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro inserido com sucesso.")

                End If

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_central_tabela_frete.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_central_tabela_frete.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        If Page.IsValid Then
            updateData()
        End If
    End Sub


    'Private Sub carregarCamposFornecedor()

    '    Try
    '        If Not (customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").Equals(String.Empty)) Then
    '            Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").ToString
    '        End If

    '        If Not (customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").Equals(String.Empty)) Then
    '            Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").ToString
    '        End If

    '        customPage.clearFilters("lupa_fornecedor")


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub
    Private Sub carregarCamposItem()

        Try

            '  Modificado 06/11/2009 - Denise i. 

            'Me.txt_cd_item.Text = hf_id_item.Value

            If Not (customPage.getFilterValue("lupa_item", "cd_item").Equals(String.Empty)) Then
                Me.txt_cd_item.Text = customPage.getFilterValue("lupa_item", "cd_item").ToString
            End If

            'If Not (customPage.getFilterValue("lupa_item", "id_item").Equals(String.Empty)) Then
            '    Me.txt_cd_item.Text = customPage.getFilterValue("lupa_item", "id_item").ToString
            'End If
            '  Modificado 06/11/2009 - Denise f. 

            If Not (customPage.getFilterValue("lupa_item", "nm_item").Equals(String.Empty)) Then
                Me.lbl_nm_item.Text = customPage.getFilterValue("lupa_item", "nm_item").ToString
            Else
                'fran 16/03/2010 i
                Me.lbl_nm_item.Text = String.Empty
                'fran 16/03/2010 f
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
    'Protected Sub btn_lupa_fornecedor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_fornecedor.Click
    '    'If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
    '    Me.lbl_nm_pessoa.Visible = True
    '    carregarCamposFornecedor()
    '    carregarEstadoCidadeFornecedor() 'fran 17/03/2010
    '    'End If
    'End Sub

    Protected Sub btn_lupa_item_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_item.Click
        'If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
        Me.lbl_nm_item.Visible = True
        carregarCamposItem()
        'End If
    End Sub
    'Protected Sub cv_fornecedor_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_fornecedor.ServerValidate
    '    Try
    '        Dim pessoa As New Pessoa()
    '        Dim lidpessoa As Int32

    '        'pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
    '        If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
    '            pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
    '        End If
    '        pessoa.cd_pessoa = Me.txt_cd_pessoa.Text.Trim

    '        lidpessoa = pessoa.validarFornecedor()

    '        If lidpessoa > 0 Then
    '            args.IsValid = True
    '            hf_id_pessoa.Value = lidpessoa
    '        Else
    '            hf_id_pessoa.Value = String.Empty
    '            args.IsValid = False
    '            messageControl.Alert("Fornecedor não cadastrado.")
    '        End If

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub


    Protected Sub cv_item_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_item.ServerValidate
        Try
            Dim item As New Item()
            'adri 20/01/2010 i chamdo 556  (copiado da alteração na tabela preço)
            item.cd_item = Me.txt_cd_item.Text.Trim

            ''args.IsValid = item.validarItem()
            'args.IsValid = item.validarItemCentral()   ' Adri - 20/01/2010 

            'If Not args.IsValid Then
            '    messageControl.Alert("Item não cadastrado.")
            'End If

            Dim liditem As Int32 'fran 30/12/2009 chamdo 556
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
            'adri 20/01/2010 f chamdo 556  (copiado da alteração na tabela preço)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub txt_cd_item_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_item.TextChanged
        hf_id_item.Value = String.Empty
        'adri 26/01/2010 i não deve limpar o codigo do item
        'txt_cd_item.Text = String.Empty  ' Modificado 06/11/2009 - Denise. 
        'adri 26/01/2010 f não deve limpar o codigo do item
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
                    Me.lbl_unidade_medida.Text = String.Empty
                    lbl_nm_item.Text = String.Empty

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        'Fran 16/03/2010 chamado 684

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_central_tabela_frete.aspx")

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

            'adri 26/01/2010 chamado 557 i
            'cbo_cidade_destino.DataSource = cidade.getCidadeByFilters()
            cbo_cidade_destino.DataSource = cidade.getCidadeCentralByFilters()
            'adri 26/01/2010 chamado 557 f

            cbo_cidade_destino.DataTextField = "nm_cidade"
            cbo_cidade_destino.DataValueField = "id_cidade"
            cbo_cidade_destino.DataBind()
            cbo_cidade_destino.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

  
    'fran 17/03/2010 i 
    'Private Sub carregarEstadoCidadeFornecedor()

    '    Try
    '        Dim pessoa As New Pessoa
    '        pessoa.cd_pessoa = txt_cd_pessoa.Text
    '        pessoa.id_grupo = 2   ' Adri 04/05/2010 
    '        Dim dspessoa As DataSet = pessoa.getPessoaByFilters
    '        'Dim dspessoa As DataSet = pessoa.getFornecedorByFilters ' Adri 04/05/2010 (ocorre erro no id_estado)
    '        If dspessoa.Tables(0).Rows.Count > 0 Then
    '            With dspessoa.Tables(0).Rows(0)
    '                hf_id_pessoa.Value = .Item("id_pessoa").ToString
    '                lbl_nm_pessoa.Visible = True
    '                lbl_nm_pessoa.Text = .Item("nm_pessoa").ToString
    '                If Not IsDBNull(.Item("id_estado")) Then
    '                    cbo_estado_origem.SelectedValue = .Item("id_estado")
    '                    cbo_cidade_origem.Items.Clear()
    '                    loadCidadesOrigemByEstado(.Item("id_estado"))
    '                    cbo_cidade_origem.SelectedValue = .Item("id_cidade")
    '                    cbo_estado_origem.Enabled = True
    '                    cbo_cidade_origem.Enabled = True
    '                Else
    '                    'fran 16/03/2010 i
    '                    cbo_estado_origem.SelectedValue = String.Empty
    '                    cbo_cidade_origem.Items.Clear()
    '                    cbo_cidade_origem.Enabled = False
    '                    'fran 16/03/2010 f
    '                End If
    '            End With
    '        Else
    '            'fran 16/03/2010 i
    '            cbo_estado_origem.SelectedValue = String.Empty
    '            cbo_cidade_origem.Items.Clear()
    '            cbo_cidade_origem.Enabled = False
    '            'fran 16/03/2010 f

    '        End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    Protected Sub gridVeiculos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridVeiculos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try

                Dim txt_valor_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_valor_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                If txt_valor_frete.Text = "0" Then
                    txt_valor_frete.Text = String.Empty
                End If
                If CDec(txt_valor_frete.Text) > 0 Then
                    txt_valor_frete.Text = FormatNumber(txt_valor_frete.Text, 2).ToString
                End If
                If (Not Me.txt_dt_cotacao.Text.Equals(String.Empty) AndAlso DateTime.Compare(DateTime.Parse(Now).ToString("dd/MM/yyyy"), Convert.ToDateTime(Me.txt_dt_cotacao.Text)) > 0) Then
                    txt_valor_frete.Enabled = False
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub lk_concluir_footer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir_footer.Click
        If Page.IsValid Then
            updateData()
        End If
    End Sub

    Protected Sub cv_veiculos_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_veiculos.ServerValidate
        Try

            args.IsValid = True
            Dim row As GridViewRow
            Dim bTemValor As Boolean = False
            For Each row In gridVeiculos.Rows
                If (Not row Is Nothing) Then
                    Dim txt_valor_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_valor_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    If txt_valor_frete.Text.ToString.Equals(String.Empty) OrElse CDec(txt_valor_frete.Text.ToString) > 0 Then
                        bTemValor = True
                    End If
                End If
            Next


            If bTemValor = False Then
                args.IsValid = False
                messageControl.Alert("Para incluisão da tabela de frete algum valor de frete deve ser maior que zero.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub cbo_transportador_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_transportador.SelectedIndexChanged

    End Sub
End Class

