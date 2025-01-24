Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class lst_central_interrupcao_fornecimento

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid = True Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

            ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()

            If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            Else
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            End If
            lbl_liquido_aprox.Text = String.Empty
            lbl_liquido_provisorio.Text = String.Empty
            lbl_total_calculo.Text = String.Empty
            lbl_total_deposito.Text = String.Empty
            lbl_total_exportacao.Text = String.Empty
            lbl_pagto_forn_byprodutor.Text = String.Empty
            lbl_pedido_reaberto.Visible = False
            btn_desligar.Enabled = False
            btn_desligar.ToolTip = String.Empty
            ViewState.Item("btn_desligar") = False
            gridPropriedades.SelectedIndex = -1

            gridpedidos.Visible = False
            'If Not (Me.txt_id_propriedade.Text.Trim().Equals(String.Empty)) Then
            '    ViewState.Item("id_propriedade") = Me.txt_id_propriedade.Text.Trim()
            'Else
            '    ViewState.Item("id_propriedade") = String.Empty
            'End If


            loadData()
        End If
    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_interrupcao_fornecimento.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_interrupcao_fornecimento.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 113
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
            '.Style("cursor") = "hand"
        End With


    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            txt_MesAno.Text = DateTime.Parse(Now()).ToString("MM/yyyy")
            ViewState.Item("dt_referencia") = "01/" & txt_MesAno.Text

            ViewState.Item("sortExpression") = "id_propriedade asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("centraldeslig", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("centraldeslig", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = "0"
        End If

        If Not (customPage.getFilterValue("centraldeslig", txt_MesAno.ID).Equals(String.Empty)) Then
            hasFilters = True
            txt_MesAno.Text = customPage.getFilterValue("centraldeslig", txt_MesAno.ID)
            ViewState.Item("dt_referencia") = txt_MesAno.Text
        Else
            txt_MesAno.Text = DateTime.Parse(Now()).ToString("MM/yyyy")
            ViewState.Item("dt_referencia") = "01/" & txt_MesAno.Text
        End If

        If Not (customPage.getFilterValue("centraldeslig", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("centraldeslig", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("centraldeslig", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("centraldeslig", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("centraldeslig", txt_id_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("centraldeslig", txt_id_propriedade.ID)
            txt_id_propriedade.Text = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("centraldeslig", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("centraldeslig", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("centraldeslig", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("centraldeslig", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("centraldeslig")
        End If

    End Sub

    Private Sub loadData()


        Try


            'Dim intfornec As New InterrupcaoFornecimento

            ''preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            'intfornec.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            'If Not (ViewState.Item("id_propriedade").Equals(String.Empty)) Then
            '    intfornec.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            'Else
            '    intfornec.id_propriedade = 0
            'End If

            'intfornec.cd_produtor = ViewState.Item("cd_pessoa").ToString

            'If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
            '    intfornec.id_produtor = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            'Else
            '    intfornec.id_produtor = 0
            'End If

            'Dim dsPropriedade As DataSet = intfornec.getProdutoreseSuasUnidProducoes()

            'If (dsPropriedade.Tables(0).Rows.Count > 0) Then
            '    Me.lk_desligar.Enabled = True
            '    tr_rendimento.Visible = True
            '    gridResults.Visible = True
            '    gridResults.DataSource = Helper.getDataView(dsPropriedade.Tables(0), ViewState.Item("sortExpression"))
            '    gridResults.DataBind()
            'Else
            '    Me.lk_desligar.Enabled = False
            '    tr_rendimento.Visible = False

            '    gridResults.Visible = False
            '    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            'End If

            loadGridPropriedades()
            If Me.ViewState("gridpropriedadeslinhas") = 0 Then
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                'Else
                '    btn_desligar.Enabled = True
                '    btn_desligar.ToolTip = String.Empty

            End If




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("centraldeslig", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("centraldeslig", txt_MesAno.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("centraldeslig", "PageIndex", gridResults.PageIndex.ToString())
            customPage.setFilter("centraldeslig", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("centraldeslig", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("centraldeslig", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("centraldeslig", txt_id_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("centraldeslig", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub lk_desligar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_desligar.Click
        If Page.IsValid Then

            Try
                Dim interrupcao As New InterrupcaoFornecimento
                Dim li As Integer
                Dim bDeveDesligar As Boolean = False
                Dim dsInterrupcaoExecucao As DataSet
                Dim dsPropDesligadas As DataSet
                Dim row As DataRow

                'Varre o grid e inclui propriedades na tabela interrupcaofornecimento antes de inicializar processo (como um og)
                interrupcao.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                interrupcao.id_execucao = interrupcao.getExecucaoInterrupcaoFornecimento
                ViewState.Item("id_execucao") = interrupcao.id_execucao
                interrupcao.dt_referencia = String.Concat("01/", ViewState.Item("dt_referencia").ToString)
                interrupcao.id_modificador = Session("id_login")
                For li = 0 To gridResults.Rows.Count - 1
                    If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                        interrupcao.id_produtor = gridResults.DataKeys(li).Values.Item(0).ToString
                        interrupcao.id_propriedade = gridResults.DataKeys(li).Values.Item(1).ToString
                        interrupcao.id_unid_producao = gridResults.DataKeys(li).Values.Item(2).ToString
                        interrupcao.insertInterrupcaoFornecimento()
                    End If
                Next

                'atualiza propriedades para buscar corretamente dataset
                interrupcao.dt_referencia = String.Empty
                interrupcao.id_unid_producao = 0
                dsInterrupcaoExecucao = interrupcao.getInterrupcaoFornecimentoByFilters

                interrupcao.id_execucao = 0
                'atuliza novamente propriedade de referencia
                interrupcao.dt_referencia = String.Concat("01/", ViewState.Item("dt_referencia").ToString)

                'Verifica quem deve ser desligado...
                If dsInterrupcaoExecucao.Tables(0).Rows.Count > 0 Then
                    For Each row In dsInterrupcaoExecucao.Tables(0).Rows
                        interrupcao.id_produtor = Convert.ToInt32(row.Item("id_produtor").ToString)
                        interrupcao.id_propriedade = Convert.ToInt32(row.Item("id_propriedade").ToString)
                        interrupcao.id_unid_producao = Convert.ToInt32(row.Item("id_unid_producao").ToString)
                        interrupcao.nr_unid_producao = Convert.ToInt32(row.Item("nr_unid_producao").ToString)

                        interrupcao.id_central_interrupcao_fornecimento = 0 'não tem id, busca se já realizou desligamento para a referencia e unid producao anteriormente
                        interrupcao.id_central_interrupcao_resultado = 3 'Desligado com sucesso
                        interrupcao.id_execucao = 0
                        dsPropDesligadas = interrupcao.getInterrupcaoFornecimentoByFilters
                        If dsPropDesligadas.Tables(0).Rows.Count > 0 Then 'se já desligou anteriormente na referencia
                            interrupcao.id_central_interrupcao_fornecimento = Convert.ToInt32(row.Item("id_central_interrupcao_fornecimento").ToString)
                            interrupcao.id_central_interrupcao_resultado = 4 'Propriedade já desativada
                            interrupcao.updateInterrupcaoFornecimentoResultado()
                        Else
                            'se tem movimento abertos, atualiza resultado
                            If interrupcao.getMovimentosAbertosByPropriedade.Tables(0).Rows.Count > 0 Then
                                interrupcao.id_central_interrupcao_fornecimento = Convert.ToInt32(row.Item("id_central_interrupcao_fornecimento").ToString)
                                interrupcao.id_central_interrupcao_resultado = 2 'movimentos abertos
                                interrupcao.updateInterrupcaoFornecimentoResultado()
                            Else
                                'se tem calculo definitivo no mes, atualiza resultado
                                If interrupcao.getCalculoDefinitivoByPropriedade > 0 Then
                                    interrupcao.id_central_interrupcao_fornecimento = Convert.ToInt32(row.Item("id_central_interrupcao_fornecimento").ToString)
                                    interrupcao.id_central_interrupcao_resultado = 1 'cálculo definitivo
                                    interrupcao.updateInterrupcaoFornecimentoResultado()
                                Else
                                    interrupcao.id_execucao = ViewState.Item("id_execucao").ToString
                                    interrupcao.id_central_interrupcao_fornecimento = Convert.ToInt32(row.Item("id_central_interrupcao_fornecimento").ToString)
                                    interrupcao.id_central_interrupcao_resultado = 3 'desligado com sucesso
                                    interrupcao.interrupcaoFornecimentoLeite()

                                End If
                            End If
                        End If
                    Next
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'processo
                    usuariolog.id_menu_item = 113
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 


                End If

        saveFilters()
        Response.Redirect("lst_central_interrupcao_fornecimento_resultado.aspx?id_execucao=" & ViewState.Item("id_execucao").ToString)

            Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        End If

    End Sub

    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                ch.Checked = ck_header.Checked
            Next

            '' 30/11/2008  -  Seleciona tudo o que o botão Pesquisar trouxe - i
            'Dim preconegociado As New PrecoNegociado
            'preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            'If ck_header.Checked = True Then
            '    preconegociado.st_selecao = "1"
            'Else
            '    preconegociado.st_selecao = "0"
            'End If
            'preconegociado.updatePrecoNegociadoTodos1N()
            '' 30/11/2008  -  Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        'lbl_nm_pessoa.Text = String.Empty
        'lbl_nm_pessoa.Visible = False
        'hf_id_pessoa.Value = String.Empty

        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty
        'fran chamado 684 i 
        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 'fran 05/05/2010
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
        End If

    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_desligar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_desligar.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True
            Dim row As GridViewRow


            'verifica se propriedade foi selecionada
            If gridPropriedades.SelectedIndex = -1 Then
                'se nao tem nenhuma propriedade selecionada
                lmsg = "Selecione uma propriedade para continuar!"
                args.IsValid = False
            Else
                loadTotalizadores()

                'se o valor rend liquido aproximado 'e negativo 
                If CDec(lbl_liquido_aprox.Text) < 0 Then
                    lmsg = "Verifique os descontos informados para cálculo. O rendimento líquido aproximado está negativo."
                    args.IsValid = False
                End If

                If args.IsValid = True Then
                    For Each row In gridpedidos.Rows
                        'se linha visivel
                        If row.Visible = True Then
                            Dim lbl_id_situacao_pedido As Label = CType(row.FindControl("lbl_id_situacao_pedido"), Label)
                            Dim lbl_situacao As Label = CType(row.FindControl("lbl_situacao"), Label)
                            Dim lbl_saldo_pagto_fornecedor As Label = CType(row.FindControl("lbl_saldo_pagto_fornecedor"), Label)
                            Dim lbl_saldo_desconto_produtor As Label = CType(row.FindControl("lbl_saldo_desconto_produtor"), Label)

                            Dim lbl_propriedade As Label = CType(row.FindControl("lbl_propriedade"), Label)
                            Dim lbl_id_central_pedido As Label = CType(row.FindControl("lbl_id_central_pedido"), Label)
                            Dim lbl_id_central_pedido_notas As Label = CType(row.FindControl("lbl_id_central_pedido_notas"), Label)
                            Dim cbo_pagto As Anthem.DropDownList = CType(row.FindControl("cbo_pagto"), Anthem.DropDownList)
                            Dim txt_nr_valor_calculo As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_calculo"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                            Dim txt_nr_valor_deposito As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_deposito"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                            Dim lbl_valor_exportacao As Anthem.Label = CType(row.FindControl("lbl_valor_exportacao"), Anthem.Label)
                            Dim lbl_valor_produtor As Anthem.Label = CType(row.FindControl("lbl_valor_produtor"), Anthem.Label)
                            Dim lbl_propriedade_matriz As Label = CType(row.FindControl("lbl_propriedade_matriz"), Label)
                            Dim lbl_produtor As Label = CType(row.FindControl("lbl_produtor"), Label)
                            Dim lbl_id_fornecedor As Label = CType(row.FindControl("lbl_id_fornecedor"), Label)

                            Dim ldec_rendimentoliquidototal As Decimal = CDec(ViewState.Item("rendimentoliquidototal"))
                            Dim ldec_saldofornecedor As Decimal = 0
                            Dim ldec_saldoprodutor As Decimal = 0


                            If cbo_pagto.SelectedValue <> "P" AndAlso CDec(lbl_saldo_desconto_produtor.Text) > 0 Then

                                If (CDec(txt_nr_valor_calculo.Text) + CDec(txt_nr_valor_deposito.Text)) <> CDec(lbl_saldo_desconto_produtor.Text) Then
                                    lmsg = String.Concat("Pedido ", lbl_id_central_pedido.Text, ": ", "A soma do desconto ao produtor por cálculo ou depósito, deve ser igual ao Saldo do Desconto ao Produtor.")
                                    args.IsValid = False

                                End If
                            End If
                            If cbo_pagto.SelectedValue = "P" Then
                                'se descontou mais do produtor e pagou menos ao fornecedor ou se valores forem iguais
                                If CDec(lbl_saldo_desconto_produtor.Text) < CDec(lbl_saldo_pagto_fornecedor.Text) Then

                                    If (CDec(txt_nr_valor_calculo.Text) + CDec(txt_nr_valor_deposito.Text)) <> 0 Then
                                        lmsg = String.Concat("Pedido ", lbl_id_central_pedido.Text, ": ", "O valor do desconto ao produtor, por cálculo ou depósito, deve ser 0. Para o tipo de pagto por Produtor, não deve haver mais decontos ao produtor, considerando que o valor já descontado pela Danone é maior que o valor pago ao Fornecedor.")
                                        args.IsValid = False
                                    End If


                                End If

                                If CDec(lbl_saldo_desconto_produtor.Text) = CDec(lbl_saldo_pagto_fornecedor.Text) Then

                                    If (CDec(txt_nr_valor_calculo.Text) + CDec(txt_nr_valor_deposito.Text)) <> 0 Then
                                        lmsg = String.Concat("Pedido ", lbl_id_central_pedido.Text, ": ", "O valor do desconto ao produtor, por cálculo ou depósito, deve ser 0. Para o tipo de pagto por Produtor, não deve haver mais decontos ao produtor, considerando que o valor já descontado pela Danone e o valor pago ao Fornecedor são iguais.")
                                        args.IsValid = False
                                    End If

                                End If

                                If CDec(lbl_saldo_desconto_produtor.Text) > CDec(lbl_saldo_pagto_fornecedor.Text) Then
                                    If (CDec(txt_nr_valor_calculo.Text) + CDec(txt_nr_valor_deposito.Text)) = 0 Then
                                        lmsg = String.Concat("Pedido ", lbl_id_central_pedido.Text, ": ", "O valor do desconto ao produtor, por cálculo ou depósito, deve ser informado.")
                                        args.IsValid = False
                                    Else

                                        If (CDec(txt_nr_valor_calculo.Text) + CDec(txt_nr_valor_deposito.Text)) <> CDec(lbl_saldo_desconto_produtor.Text) - CDec(lbl_saldo_pagto_fornecedor.Text) Then
                                            lmsg = String.Concat("Pedido ", lbl_id_central_pedido.Text, ": ", "A soma do valor do desconto ao produtor, por cálculo ou depósito, deve ser de ", CDec(lbl_saldo_desconto_produtor.Text) - CDec(lbl_saldo_pagto_fornecedor.Text), ". Para o tipo de pagto por Produtor e considerando que o valor já descontado pela Danone é menor que o valor pago ao Fornecedor, deve .")
                                            args.IsValid = False
                                        End If

                                    End If
                                End If
                            End If

                        End If

                    Next
                End If


            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridPropriedades_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridPropriedades.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_central_interrupcao_fornec_resumo.aspx?id_central_interrupcao_fornecimento=" + e.CommandArgument.ToString() )


        End Select


    End Sub

    Protected Sub gridPropriedades_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridPropriedades.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow AndAlso Me.ViewState("gridpropriedadeslinhas") > 0) Then
                If (e.Row.RowState <> (DataControlRowState.Alternate Or DataControlRowState.Edit) AndAlso e.Row.RowState <> DataControlRowState.Edit) Then
                    Dim lbl_nr_valor_disponivel As Anthem.Label = CType(e.Row.FindControl("lbl_nr_valor_disponivel"), Anthem.Label)
                    Dim lbl_id_propriedade As Label = CType(e.Row.FindControl("lbl_id_propriedade"), Label)
                    Dim lbl_nr_valor_mensal_estimado As Anthem.Label = CType(e.Row.FindControl("lbl_nr_valor_mensal_estimado"), Anthem.Label)
                    Dim lbl_nr_total_pedidos_abertos As Anthem.Label = CType(e.Row.FindControl("lbl_nr_total_pedidos_abertos"), Anthem.Label)
                    Dim hl_nr_total_pedidos_abertos As Anthem.HyperLink = CType(e.Row.FindControl("hl_nr_total_pedidos_abertos"), Anthem.HyperLink)
                    Dim lbl_id_propriedade_matriz As Label = CType(e.Row.FindControl("lbl_id_propriedade_matriz"), Label)
                    Dim row_num As Label = CType(e.Row.FindControl("lbl_row_num"), Label)
                    'Dim celcomand As DataControlFieldCell = CType(e.Row.Cells.Item(0), DataControlFieldCell)
                    Dim imgselecionar As Anthem.ImageButton = CType(e.Row.FindControl("imgselecionar"), Anthem.ImageButton)
                    Dim lbl_nr_limite_mes_bruto As Anthem.Label = CType(e.Row.FindControl("lbl_nr_limite_mes_bruto"), Anthem.Label)
                    Dim lbl_nr_valor_desconto As Anthem.Label = CType(e.Row.FindControl("lbl_nr_valor_desconto"), Anthem.Label)
                    Dim lbl_volumenomes As Label = CType(e.Row.FindControl("lbl_volumenomes"), Label)
                    Dim lbl_indexgridmatriz As Anthem.Label = CType(e.Row.FindControl("lbl_indexgridmatriz"), Anthem.Label)
                    Dim lbl_rendimento_liquido As Label = CType(e.Row.FindControl("lbl_rendimento_liquido"), Label)
                    Dim lbl_ult_pagto As Label = CType(e.Row.FindControl("lbl_ult_pagto"), Label)
                    Dim btn_editar As Anthem.ImageButton = CType(e.Row.FindControl("img_editar"), Anthem.ImageButton)


                    Dim calculo As New CalculoProdutor
                    calculo.id_propriedade = lbl_id_propriedade.Text
                    calculo.st_tipo_pagamento = "M"
                    Dim dscalculo As DataSet = calculo.getCalculoStatusPagamentoReferencia

                    If dscalculo.Tables(0).Rows.Count > 0 Then
                        lbl_ult_pagto.Text = String.Concat(dscalculo.Tables(0).Rows(0).Item("st_pagamento").ToString, " - ", DateTime.Parse(dscalculo.Tables(0).Rows(0).Item("dt_referencia").ToString).ToString("MM/yyyy"), "(", DateTime.Parse(dscalculo.Tables(0).Rows(0).Item("dt_criacao").ToString).ToString("dd/MM/yyyy"), ")")

                    Else
                        lbl_ult_pagto.Text = ""
                    End If


                    calculo.dt_referencia = ViewState.Item("dt_referencia").ToString
                    calculo.dt_referencia_start = calculo.dt_referencia
                    calculo.dt_referencia_end = calculo.dt_referencia

                    lbl_nr_valor_mensal_estimado.Text = calculo.getCalculoVolumeLeite()

                    If Not lbl_nr_valor_mensal_estimado.Text.Equals(String.Empty) Then
                        lbl_nr_valor_mensal_estimado.Text = FormatNumber(lbl_nr_valor_mensal_estimado.Text, 0).ToString

                        If CInt(lbl_nr_valor_mensal_estimado.Text) > 0 Then
                            Dim ficha As New FichaFinanceira
                            ficha.dt_referencia_ficha_start = calculo.dt_referencia
                            ficha.dt_referencia_ficha_end = calculo.dt_referencia
                            ficha.id_propriedade = lbl_id_propriedade.Text
                            ficha.cd_conta = "1000"
                            ficha.st_tipo_pagamento = "M"
                            lbl_rendimento_liquido.Text = ficha.getFichaFinanceiraValorConta()
                        Else
                            lbl_rendimento_liquido.Text = String.Empty
                        End If
                    Else

                        lbl_nr_valor_mensal_estimado.Text = String.Empty
                    End If

                    If Not lbl_rendimento_liquido.Text.Equals(String.Empty) Then
                        lbl_rendimento_liquido.Text = FormatNumber(lbl_rendimento_liquido.Text, 2).ToString
                    End If

                    'If lbl_volumenomes.Text.Equals("S") Then
                    '    lbl_nr_valor_mensal_estimado.BackColor = Drawing.Color.Aquamarine
                    'Else
                    '    lbl_nr_valor_mensal_estimado.BackColor = Drawing.Color.White
                    'End If
                    'SaldoDisponivel.id_propriedade = lbl_id_propriedade.Text
                    'lbl_nr_valor_disponivel.Text = FormatNumber(saldoDisponivel.getSaldoDisponivel(True), 2).ToString
                    'If saldoDisponivel.st_saldo_romaneio_aberto = True Then
                    '    Me.lbl_informativo.Visible = True
                    'Else
                    '    Me.lbl_informativo.Visible = False
                    'End If
                    'lbl_nr_valor_mensal_estimado.Text = saldoDisponivel.nr_valor_faturamento.ToString
                    If Not lbl_id_propriedade_matriz.Text.Equals(String.Empty) AndAlso CInt(row_num.Text) > 1 Then
                        'CType(celcomand.ContainingField, CommandField).ShowSelectButton = False
                        imgselecionar.Visible = False

                        'guarda o index da linha da prop matriz no grid
                        lbl_indexgridmatriz.Text = ViewState.Item("lbl_indexgridmatriz").ToString

                        hl_nr_total_pedidos_abertos.Visible = True
                        hl_nr_total_pedidos_abertos.Text = String.Empty
                        hl_nr_total_pedidos_abertos.NavigateUrl = String.Empty
                        lbl_nr_total_pedidos_abertos.Visible = False

                    Else
                        'CType(celcomand.ContainingField, CommandField).ShowSelectButton = True
                        imgselecionar.Visible = True

                        'atualiza o index da propriedade matriz ou da propriedade
                        ViewState.Item("lbl_indexgridmatriz") = e.Row.RowIndex.ToString
                        'guarda o index da linha da prop matriz no grid
                        lbl_indexgridmatriz.Text = e.Row.RowIndex.ToString

                        Dim pedido As New Pedido
                        Dim interrupcao As New InterrupcaoFornecimento

                        If Not lbl_id_propriedade_matriz.Text.Equals(String.Empty) Then
                            pedido.id_propriedade_matriz = lbl_id_propriedade_matriz.Text
                            interrupcao.id_propriedade = lbl_id_propriedade_matriz.Text
                        Else
                            pedido.id_propriedade = lbl_id_propriedade.Text
                            interrupcao.id_propriedade = lbl_id_propriedade.Text
                        End If

                        lbl_nr_total_pedidos_abertos.Text = pedido.getInterrupcaoTotalPedidosAbertos().ToString()


                        Dim dsinterrupcao As DataSet = interrupcao.getInterrupcaoFornecimentoByFilters()
                        If dsinterrupcao.Tables(0).Rows.Count > 0 Then
                            btn_editar.Visible = True
                            btn_editar.CommandArgument = dsinterrupcao.Tables(0).Rows(0).Item("id_central_interrupcao_fornecimento").ToString
                            imgselecionar.Enabled = False
                            imgselecionar.ToolTip = "Propriedade já realizou interrupção de fornecimento."

                        Else
                            btn_editar.Visible = False
                            btn_editar.CommandArgument = String.Empty
                            imgselecionar.Enabled = True
                            imgselecionar.ToolTip = String.Empty

                        End If
                        'Dim saldoDisponivel As New SaldoDisponivel()
                        'saldoDisponivel.dt_referencia = String.Concat("01/", DateTime.Now.ToString("MM/yyyy")).ToString
                        'If Not lbl_id_propriedade_matriz.Text.Equals(String.Empty) Then
                        '    saldoDisponivel.id_propriedade = lbl_id_propriedade_matriz.Text
                        'Else
                        '    saldoDisponivel.id_propriedade = lbl_id_propriedade.Text
                        'End If

                        'Dim dslimite As DataSet = saldoDisponivel.getSaldoDisponivelPropriedadeEMatriz
                        'If dslimite.Tables(0).Rows.Count > 0 Then
                        '    With dslimite.Tables(0).Rows(0)
                        '        lbl_nr_valor_disponivel.Text = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                        '        lbl_nr_limite_mes_bruto.Text = FormatNumber(.Item("nr_limite_mes_bruto").ToString, 2).ToString
                        '        lbl_nr_valor_desconto.Text = FormatNumber(.Item("desconto_sem_abertos").ToString, 2).ToString

                        '        lbl_nr_total_pedidos_abertos.Text = .Item("desconto_abertos").ToString

                        '    End With

                        'Else
                        '    'se nao tem faturamento na ficha do mes anterior, busca do projetado na ficha custo financeiro
                        '    Dim dslimitecusto As DataSet = saldoDisponivel.getSaldoDisponivelFichaCustoPropriedadeEMatriz
                        '    If dslimitecusto.Tables(0).Rows.Count > 0 Then
                        '        With dslimitecusto.Tables(0).Rows(0)
                        '            lbl_nr_valor_disponivel.Text = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                        '            lbl_nr_limite_mes_bruto.Text = FormatNumber(.Item("nr_limite_mes_bruto").ToString, 2).ToString
                        '            lbl_nr_valor_desconto.Text = FormatNumber(.Item("desconto_sem_abertos").ToString, 2).ToString
                        '            lbl_nr_total_pedidos_abertos.Text = .Item("desconto_abertos").ToString
                        '        End With
                        '        Me.lbl_informativo_1.Visible = True
                        '        lbl_nr_valor_disponivel.ForeColor = Drawing.Color.Blue
                        '        lbl_nr_limite_mes_bruto.ForeColor = Drawing.Color.Blue
                        '    Else
                        '        'se nao encontrou valor projetado e nem faturamento mes anterior
                        '        Me.lbl_informativo_2.Visible = True
                        '        lbl_nr_valor_disponivel.Text = String.Empty
                        '        lbl_nr_limite_mes_bruto.Text = String.Empty
                        '        lbl_nr_valor_desconto.Text = String.Empty
                        '        lbl_nr_total_pedidos_abertos.Text = "0"

                        '    End If

                        '    'lbl_nr_total_pedidos_abertos.Text = pedido.getTotalPedidosAbertos().ToString()

                        'End If
                        If (CDec(lbl_nr_total_pedidos_abertos.Text) <= 0) Then
                            lbl_nr_total_pedidos_abertos.Text = FormatCurrency(0, 2).ToString
                            hl_nr_total_pedidos_abertos.Visible = False
                            lbl_nr_total_pedidos_abertos.Visible = True
                        Else
                            hl_nr_total_pedidos_abertos.Visible = True
                            hl_nr_total_pedidos_abertos.Text = FormatCurrency(lbl_nr_total_pedidos_abertos.Text, 2).ToString
                            hl_nr_total_pedidos_abertos.NavigateUrl = String.Format("frm_central_pedidos_abertos.aspx?id_propriedade={0}", lbl_id_propriedade.Text)
                            lbl_nr_total_pedidos_abertos.Visible = False
                        End If

                    End If

                End If
            End If
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridPropriedades_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridPropriedades.SelectedIndexChanged

        Dim rowselected As GridViewRow = Me.gridPropriedades.SelectedRow
        Dim row As GridViewRow

        Dim lbl_id_propriedade As Label = CType(rowselected.FindControl("lbl_id_propriedade"), Label)
        Dim lbl_id_propriedade_matriz As Label = CType(rowselected.FindControl("lbl_id_propriedade_matriz"), Label)
        Dim lbl_id_produtor As Label = CType(rowselected.FindControl("lbl_id_produtor"), Label)
        Dim lbl_id_estado As Label = CType(rowselected.FindControl("lbl_id_estado"), Label)
        Dim lbl_id_cidade As Label = CType(rowselected.FindControl("lbl_id_cidade"), Label)
        Dim lbl_indexgridmatriz As Anthem.Label = CType(rowselected.FindControl("lbl_indexgridmatriz"), Anthem.Label)
        'Dim lbl_nr_valor_disponivel As Label = CType(rowselected.FindControl("lbl_nr_valor_disponivel"), Label)
        'pega o valor duisponivel da propriedade matriz ou da propria propriedade
        Dim lbl_nr_valor_disponivel As Label = CType(gridPropriedades.Rows(lbl_indexgridmatriz.Text).FindControl("lbl_nr_valor_disponivel"), Anthem.Label)
        Dim lbl_rendimento_liquido As Label = CType(rowselected.FindControl("lbl_rendimento_liquido"), Label)
        Dim lnrrendimentototal As Decimal = 0
        Me.ViewState.Item("id_propriedade") = lbl_id_propriedade.Text
        If lbl_id_propriedade_matriz.Text.Equals(String.Empty) Then
            Me.ViewState.Item("id_propriedade_matriz") = "0"

            If lbl_rendimento_liquido.Text = String.Empty Then
                ViewState.Item("rendimentoliquidocalculadototal") = 0
            Else
                ViewState.Item("rendimentoliquidocalculadototal") = CDec(lbl_rendimento_liquido.Text)
            End If

        Else
            Me.ViewState.Item("id_propriedade_matriz") = lbl_id_propriedade_matriz.Text

            For Each row In gridPropriedades.Rows
                If row.RowIndex >= CInt(lbl_indexgridmatriz.Text) Then
                    Dim lblrendimentoliquido As Label = CType(row.FindControl("lbl_rendimento_liquido"), Label)
                    Dim lblpropriedadematriz As Label = CType(row.FindControl("lbl_id_propriedade_matriz"), Label)

                    If lblpropriedadematriz.Text = lbl_id_propriedade_matriz.Text Then

                        If Not lblrendimentoliquido.Text = String.Empty Then
                            lnrrendimentototal = lnrrendimentototal + CDec(lblrendimentoliquido.Text)
                        End If

                    End If
                End If
            Next

            ViewState.Item("rendimentoliquidocalculadototal") = lnrrendimentototal
        End If
        ViewState.Item("rendimentoliquidototal") = ViewState.Item("rendimentoliquidocalculadototal")

        Me.ViewState.Item("id_produtor") = lbl_id_produtor.Text
        'Me.ViewState.Item("id_estado_destino") = lbl_id_estado.Text
        'Me.ViewState.Item("id_cidade_destino") = lbl_id_cidade.Text
        'If lbl_nr_valor_disponivel.Text = String.Empty Then
        '    ViewState.Item("limitedisponivel") = 0
        'Else
        '    ViewState.Item("limitedisponivel") = CDec(lbl_nr_valor_disponivel.Text)
        'End If
        ViewState.Item("indexgridpropriedadeprincipal") = lbl_indexgridmatriz.Text
        ' tr_rendimento.Visible = True
        ViewState.Item("btn_desligar") = False

        loadGridPedidos()
        loadTotalizadores()

        Dim pedido As New Pedido
        pedido.id_propriedade = lbl_id_propriedade.Text
        pedido.id_situacao_pedido = 4
        'se trouxe linhas tem pedido reaberto
        If pedido.getPedidoByFilters.Tables(0).Rows.Count > 0 Then
            btn_desligar.Enabled = False
            btn_desligar.ToolTip = "Não pode prosseguir com desligamento porque há pedidos reabertos."
            lbl_pedido_reaberto.Visible = True
        Else
            btn_desligar.Enabled = True
            btn_desligar.ToolTip = "Desliga a propriedade por interrupção de fornecimento de leite"
            lbl_pedido_reaberto.Visible = False

        End If

    End Sub

    'Protected Sub imgselecionar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    Dim wc As WebControl = CType(sender, WebControl)
    '    Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
    '    Dim lbl_id_propriedade As Label = CType(row.FindControl("lbl_id_propriedade"), System.Web.UI.WebControls.Label)
    '    Dim lbl_id_propriedade_matriz As Label = CType(row.FindControl("lbl_id_propriedade_matriz"), System.Web.UI.WebControls.Label)

    '    tr_rendimento.Visible = True

    'End Sub

    Private Sub loadGridPropriedades()
        Try
            ViewState.Item("lbl_indexgridmatriz") = Nothing
            If (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then

                Me.ViewState("gridpropriedadeslinhas") = 0
                gridPropriedades.Visible = False
                lbl_props.Visible = False
                'Dim pessoa As New Pessoa
                'pessoa.id_pessoa = -1

                'Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()

                'Dim dr As DataRow = dspropriedades.Tables(0).NewRow()
                'dspropriedades.Tables(0).Rows.InsertAt(dr, 0)
                'Me.ViewState("gridpropriedadeslinhas") = 0
                'Me.gridPropriedades.Visible = True
                'Me.gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
                'Me.gridPropriedades.DataBind()
                'Me.gridPropriedades.Rows(0).Cells.Clear()
                'Me.gridPropriedades.Rows(0).Cells.Add(New TableCell())
                'Me.gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                'Me.gridPropriedades.Rows(0).Cells(0).Text = "Selecione um produtor ativo."
                'Me.gridPropriedades.Rows(0).Cells(0).ColumnSpan = 20
            Else

                Dim pessoa As New Pessoa
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)

                Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()
                If (dspropriedades.Tables(0).Rows.Count <= 0) Then
                    lbl_props.Visible = False
                    Me.ViewState("gridpropriedadeslinhas") = 0
                    gridPropriedades.Visible = False

                    'Dim dr As DataRow = dspropriedades.Tables(0).NewRow()
                    'dspropriedades.Tables(0).Rows.InsertAt(dr, 0)
                    'gridPropriedades.Visible = True
                    'gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
                    'gridPropriedades.DataBind()
                    'gridPropriedades.Rows(0).Cells.Clear()
                    'gridPropriedades.Rows(0).Cells.Add(New TableCell())
                    'gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    'gridPropriedades.Rows(0).Cells(0).ColumnSpan = 20
                    'gridPropriedades.Rows(0).Cells(0).Text = "Não foram encontradas propriedades ativas para o produtor selecionado!"
                Else
                    lbl_props.Visible = True

                    ViewState("gridpropriedadeslinhas") = 1
                    gridPropriedades.Visible = True
                    gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
                    gridPropriedades.DataBind()
                End If

            End If
            ViewState.Item("lbl_indexgridmatriz") = Nothing

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub loadGridPedidos()
        Try
            Dim interrupcao As New InterrupcaoFornecimento

            If Not ViewState.Item("id_propriedade_matriz").ToString.Equals("0") Then
                interrupcao.id_propriedade_matriz = ViewState.Item("id_propriedade_matriz").ToString
            Else
                interrupcao.id_propriedade = ViewState.Item("id_propriedade").ToString
            End If

            Dim dspedidos As DataSet = interrupcao.getCentralInterrupcaoPedidos()
            If (dspedidos.Tables(0).Rows.Count <= 0) Then
                Me.ViewState("gridpedidoslinhas") = 0
                Dim dr As DataRow = dspedidos.Tables(0).NewRow()
                dspedidos.Tables(0).Rows.InsertAt(dr, 0)
                gridpedidos.Visible = True
                gridpedidos.DataSource = Helper.getDataView(dspedidos.Tables(0), "")
                gridpedidos.DataBind()
                gridpedidos.Rows(0).Cells.Clear()
                gridpedidos.Rows(0).Cells.Add(New TableCell())
                gridpedidos.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridpedidos.Rows(0).Cells(0).ColumnSpan = 20
                gridpedidos.Rows(0).Cells(0).Text = "Não foram encontrados pedidos pendentes para a propriedade selecionada!"
            Else
                ViewState("gridpedidoslinhas") = 1
                ViewState.Item("rendimentoliquidototal") = ViewState.Item("rendimentoliquidocalculadototal")

                gridpedidos.Visible = True
                gridpedidos.DataSource = Helper.getDataView(dspedidos.Tables(0), "")
                gridpedidos.DataBind()
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    'Private Sub loadGridPropriedades()
    '    Try
    '        ViewState.Item("lbl_indexgridmatriz") = Nothing
    '        If (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then

    '            Dim pessoa As New Pessoa
    '            pessoa.id_pessoa = -1

    '            Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()

    '            Dim dr As DataRow = dspropriedades.Tables(0).NewRow()
    '            dspropriedades.Tables(0).Rows.InsertAt(dr, 0)
    '            Me.ViewState("gridpropriedadeslinhas") = 0
    '            Me.gridPropriedades.Visible = True
    '            Me.gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
    '            Me.gridPropriedades.DataBind()
    '            Me.gridPropriedades.Rows(0).Cells.Clear()
    '            Me.gridPropriedades.Rows(0).Cells.Add(New TableCell())
    '            Me.gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
    '            Me.gridPropriedades.Rows(0).Cells(0).Text = "Selecione um produtor ativo."
    '            Me.gridPropriedades.Rows(0).Cells(0).ColumnSpan = 20
    '        Else

    '            Dim pessoa As New Pessoa
    '            pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)

    '            Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()
    '            If (dspropriedades.Tables(0).Rows.Count <= 0) Then
    '                Me.ViewState("gridpropriedadeslinhas") = 0
    '                Dim dr As DataRow = dspropriedades.Tables(0).NewRow()
    '                dspropriedades.Tables(0).Rows.InsertAt(dr, 0)
    '                gridPropriedades.Visible = True
    '                gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
    '                gridPropriedades.DataBind()
    '                gridPropriedades.Rows(0).Cells.Clear()
    '                gridPropriedades.Rows(0).Cells.Add(New TableCell())
    '                gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
    '                gridPropriedades.Rows(0).Cells(0).ColumnSpan = 20
    '                gridPropriedades.Rows(0).Cells(0).Text = "Não foram encontradas propriedades ativas para o produtor selecionado!"
    '            Else
    '                ViewState("gridpropriedadeslinhas") = 1
    '                gridPropriedades.Visible = True
    '                gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
    '                gridPropriedades.DataBind()
    '            End If

    '        End If
    '        ViewState.Item("lbl_indexgridmatriz") = Nothing

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try
    'End Sub

    Protected Sub gridpedidos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridpedidos.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow AndAlso Me.ViewState("gridpedidoslinhas") > 0) Then
                If (e.Row.RowState <> (DataControlRowState.Alternate Or DataControlRowState.Edit) AndAlso e.Row.RowState <> DataControlRowState.Edit) Then
                    Dim lbl_id_situacao_pedido As Label = CType(e.Row.FindControl("lbl_id_situacao_pedido"), Label)
                    Dim lbl_situacao As Label = CType(e.Row.FindControl("lbl_situacao"), Label)
                    Dim lbl_saldo_pagto_fornecedor As Label = CType(e.Row.FindControl("lbl_saldo_pagto_fornecedor"), Label)
                    Dim lbl_saldo_desconto_produtor As Label = CType(e.Row.FindControl("lbl_saldo_desconto_produtor"), Label)

                    Dim lbl_propriedade As Label = CType(e.Row.FindControl("lbl_propriedade"), Label)
                    Dim lbl_id_central_pedido As Label = CType(e.Row.FindControl("lbl_id_central_pedido"), Label)
                    Dim lbl_id_central_pedido_notas As Label = CType(e.Row.FindControl("lbl_id_central_pedido_notas"), Label)
                    Dim cbo_pagto As Anthem.DropDownList = CType(e.Row.FindControl("cbo_pagto"), Anthem.DropDownList)
                    Dim lbl_valor_exportacao As Anthem.Label = CType(e.Row.FindControl("lbl_valor_exportacao"), Anthem.Label)
                    Dim lbl_valor_produtor As Anthem.Label = CType(e.Row.FindControl("lbl_valor_produtor"), Anthem.Label)
                    Dim txt_nr_valor_calculo As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_valor_calculo"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_nr_valor_deposito As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_valor_deposito"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim chk_cancelar As Anthem.CheckBox = CType(e.Row.FindControl("chk_cancelar"), Anthem.CheckBox)
                    Dim lbl_propriedade_matriz As Label = CType(e.Row.FindControl("lbl_propriedade_matriz"), Label)
                    Dim lbl_produtor As Label = CType(e.Row.FindControl("lbl_produtor"), Label)
                    Dim lbl_id_fornecedor As Label = CType(e.Row.FindControl("lbl_id_fornecedor"), Label)

                    Dim ldec_rendimentoliquidototal As Decimal = CDec(ViewState.Item("rendimentoliquidototal"))
                    Dim ldec_saldofornecedor As Decimal = 0
                    Dim ldec_saldoprodutor As Decimal = 0

                    If Not lbl_saldo_pagto_fornecedor.Text.Equals(String.Empty) Then
                        ldec_saldofornecedor = CDec(lbl_saldo_pagto_fornecedor.Text)
                    End If
                    If Not lbl_saldo_desconto_produtor.Text.Equals(String.Empty) Then
                        ldec_saldoprodutor = CDec(lbl_saldo_desconto_produtor.Text)
                    End If

                    If ldec_saldofornecedor = 0 Then
                        cbo_pagto.Items(0).Enabled = False
                        cbo_pagto.Items(1).Enabled = False
                        cbo_pagto.Items(2).Enabled = True
                        cbo_pagto.SelectedValue = "F"
                        lbl_valor_exportacao.Text = FormatNumber(0, 2).ToString
                        lbl_valor_produtor.Text = FormatNumber(0, 2).ToString
                    Else
                        cbo_pagto.Items(0).Enabled = True
                        cbo_pagto.Items(1).Enabled = True
                        cbo_pagto.Items(2).Enabled = False
                        lbl_valor_exportacao.Text = FormatNumber(ldec_saldofornecedor, 2).ToString
                        lbl_valor_produtor.Text = FormatNumber(0, 2).ToString

                        If ldec_saldoprodutor = 0 Then 'se nao tem saldo do desconto produtor, se ja descontou tudo, deve fazer a exportacao pro sap antecipada nao pode colocar´pra o produtor pagar
                            cbo_pagto.Items(1).Enabled = False
                            txt_nr_valor_deposito.Text = FormatNumber(0, 2).ToString
                            txt_nr_valor_calculo.Text = FormatNumber(0, 2).ToString
                            txt_nr_valor_calculo.Enabled = False
                            txt_nr_valor_deposito.Enabled = False
                        End If
                    End If

                    If ldec_rendimentoliquidototal >= ldec_saldoprodutor Then

                        txt_nr_valor_calculo.Text = ldec_saldoprodutor
                        txt_nr_valor_deposito.Text = FormatNumber(0, 2).ToString
                        ldec_rendimentoliquidototal = ldec_rendimentoliquidototal - ldec_saldoprodutor
                    Else

                        txt_nr_valor_calculo.Text = ldec_rendimentoliquidototal
                        txt_nr_valor_deposito.Text = ldec_saldoprodutor - ldec_rendimentoliquidototal
                        ldec_rendimentoliquidototal = FormatNumber(0, 2).ToString
                    End If

                    If lbl_id_situacao_pedido.Text = "3" Then
                        lbl_situacao.Text = "Finalizado"
                    End If
                    If lbl_id_situacao_pedido.Text = "8" Then
                        lbl_situacao.Text = "Fin.Parcial"
                    End If

                    ViewState.Item("rendimentoliquidototal") = ldec_rendimentoliquidototal
                End If
            End If
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadTotalizadores()
        Dim row As GridViewRow

        Dim ldec_rendimentoliquidototal As Decimal = CDec(ViewState.Item("rendimentoliquidocalculadototal"))
        Dim ldec_saldofornecedor As Decimal = 0
        Dim ldec_saldoprodutor As Decimal = 0
        Dim ldec_saldofornecedorexportar As Decimal = 0
        Dim ldec_saldofornecedorprodutor As Decimal = 0
        Dim ldec_saldoprodutorcalculo As Decimal = 0
        Dim ldec_saldoprodutordeposito As Decimal = 0

        If ViewState("gridpedidoslinhas") = 1 Then
            For Each row In gridpedidos.Rows
                Dim lbl_saldo_pagto_fornecedor As Label = CType(row.FindControl("lbl_saldo_pagto_fornecedor"), Label)
                Dim lbl_saldo_desconto_produtor As Label = CType(row.FindControl("lbl_saldo_desconto_produtor"), Label)
                Dim cbo_pagto As Anthem.DropDownList = CType(row.FindControl("cbo_pagto"), Anthem.DropDownList)
                Dim txt_nr_valor_calculo As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_calculo"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_nr_valor_deposito As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_deposito"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim chk_cancelar As Anthem.CheckBox = CType(row.FindControl("chk_cancelar"), Anthem.CheckBox)
                Dim lbl_valor_exportacao As Anthem.Label = CType(row.FindControl("lbl_valor_exportacao"), Anthem.Label)
                Dim lbl_valor_produtor As Anthem.Label = CType(row.FindControl("lbl_valor_produtor"), Anthem.Label)


                ldec_saldofornecedorexportar = ldec_saldofornecedorexportar + CDec(lbl_valor_exportacao.Text)
                ldec_saldofornecedorprodutor = ldec_saldofornecedorprodutor + CDec(lbl_valor_produtor.Text)
                ldec_saldoprodutorcalculo = ldec_saldoprodutorcalculo + CDec(txt_nr_valor_calculo.Text)
                ldec_saldoprodutordeposito = ldec_saldoprodutordeposito + CDec(txt_nr_valor_deposito.Text)

                'If Not lbl_saldo_pagto_fornecedor.Text.Equals(String.Empty) Then
                '    If cbo_pagto.SelectedValue = "D" Then
                '        ldec_saldofornecedorexportar = ldec_saldofornecedorexportar + CDec(lbl_saldo_pagto_fornecedor.Text)
                '    End If
                '    If cbo_pagto.SelectedValue = "P" Then
                '        'se descontou mais do produtor e pagou menos ao fornecedor
                '        If CDec(lbl_saldo_desconto_produtor.Text) < CDec(lbl_saldo_pagto_fornecedor.Text) Then
                '            ldec_saldofornecedorexportar = ldec_saldofornecedorexportar + (CDec(lbl_saldo_pagto_fornecedor.Text) - CDec(lbl_saldo_desconto_produtor.Text))
                '            ldec_saldofornecedorprodutor = ldec_saldofornecedorprodutor + CDec(lbl_saldo_desconto_produtor.Text)
                '        Else 'se pagou mais ao fornecedor e descontou menos do produtor
                '            ldec_saldofornecedorprodutor = ldec_saldofornecedorprodutor + CDec(lbl_saldo_pagto_fornecedor.Text)

                '        End If
                '    End If
                'End If
                'If Not lbl_saldo_desconto_produtor.Text.Equals(String.Empty) Then
                '    If Not txt_nr_valor_calculo.Text.Equals(String.Empty) Then
                '        ldec_saldoprodutorcalculo = ldec_saldoprodutorcalculo + CDec(txt_nr_valor_calculo.Text)
                '    End If
                '    If Not txt_nr_valor_deposito.Text.Equals(String.Empty) Then
                '        ldec_saldoprodutordeposito = ldec_saldoprodutordeposito + CDec(txt_nr_valor_deposito.Text)
                '    End If
                'End If

            Next
        End If
        ViewState.Item("rendimentoliquidototal") = ldec_rendimentoliquidototal - ldec_saldoprodutorcalculo

        lbl_liquido_provisorio.Text = FormatNumber(ViewState.Item("rendimentoliquidocalculadototal"), 2)
        lbl_total_calculo.Text = FormatNumber(ldec_saldoprodutorcalculo, 2)
        lbl_liquido_aprox.Text = FormatNumber(ldec_rendimentoliquidototal - ldec_saldoprodutorcalculo, 2)
        lbl_total_deposito.Text = FormatNumber(ldec_saldoprodutordeposito, 2)
        lbl_total_exportacao.Text = FormatNumber(ldec_saldofornecedorexportar, 2)
        lbl_pagto_forn_byprodutor.Text = FormatNumber(ldec_saldofornecedorprodutor, 2)

    End Sub

    Protected Sub btn_atualizar_totais_pedidos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_atualizar_totais_pedidos.Click
        loadTotalizadores()
    End Sub

    Protected Sub btn_desligar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_desligar.Click
        If Page.IsValid AndAlso ViewState.Item("btn_desligar") = False Then

            Try
                Dim interrupcao As New InterrupcaoFornecimento
                Dim interrupcaopedidos As New InterrupcaoFornecimentoPedidos
                Dim li As Integer
                Dim bDeveDesligar As Boolean = False
                Dim dsInterrupcaoExecucao As DataSet
                Dim dsPropDesligadas As DataSet
                Dim row As DataRow

                'inclui propriedades na tabela interrupcaofornecimento antes de inicializar processo (como um og)
                interrupcao.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                interrupcao.id_execucao = interrupcao.getExecucaoInterrupcaoFornecimento
                ViewState.Item("id_execucao") = interrupcao.id_execucao
                interrupcao.dt_referencia = ViewState.Item("dt_referencia").ToString
                interrupcao.id_modificador = Session("id_login")
                interrupcao.id_produtor = ViewState.Item("id_produtor").ToString
                interrupcao.id_propriedade = ViewState.Item("id_propriedade").ToString
                interrupcao.id_propriedade_matriz = ViewState.Item("id_propriedade_matriz").ToString
                interrupcao.id_central_interrupcao_fornecimento = interrupcao.insertInterrupcaoFornecimento()

                If Not ViewState.Item("id_propriedade_matriz").ToString = "0" Then
                    interrupcaopedidos.id_propriedade = 0
                    interrupcaopedidos.id_propriedade_matriz = interrupcao.id_propriedade_matriz
                Else
                    interrupcaopedidos.id_propriedade = interrupcao.id_propriedade
                    interrupcaopedidos.id_propriedade_matriz = 0
                End If
                interrupcaopedidos.id_central_interrupcao_fornecimento = interrupcao.id_central_interrupcao_fornecimento
                interrupcaopedidos.id_modificador = Session("id_login")
                'inclui pedidos na interrupcao
                interrupcaopedidos.insertInterrupcaoFornecimentoPedidos()

                ViewState.Item("btn_desligar") = True

                For li = 0 To gridpedidos.Rows.Count - 1

                    'If CType(gridpedidos.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    interrupcaopedidos.id_central_pedido_notas = gridpedidos.DataKeys(li).Value.ToString
                    interrupcaopedidos.st_pagto_fornecedor = CType(gridpedidos.Rows(li).FindControl("cbo_pagto"), Anthem.DropDownList).SelectedValue
                    interrupcaopedidos.nr_desconto_calculo = CDec(CType(gridpedidos.Rows(li).FindControl("txt_nr_valor_calculo"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text)
                    interrupcaopedidos.nr_desconto_deposito = CDec(CType(gridpedidos.Rows(li).FindControl("txt_nr_valor_deposito"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text)
                    interrupcaopedidos.nr_pagto_produtor = CDec(CType(gridpedidos.Rows(li).FindControl("lbl_valor_produtor"), Anthem.Label).Text)
                    interrupcaopedidos.nr_pagto_exportacao = CDec(CType(gridpedidos.Rows(li).FindControl("lbl_valor_exportacao"), Anthem.Label).Text)
                    interrupcaopedidos.updateInterrupcaoFornecimentoPedidosNota()
                    'End If
                Next

                'atualiza propriedades para buscar corretamente dataset
                interrupcao.dt_referencia = String.Empty
                interrupcao.id_unid_producao = 0
                dsInterrupcaoExecucao = interrupcao.getInterrupcaoFornecimentoByFilters

                interrupcao.id_execucao = 0
                'atuliza novamente propriedade de referencia
                interrupcao.dt_referencia = ViewState.Item("dt_referencia").ToString

                'Verifica quem deve ser desligado...
                'If dsInterrupcaoExecucao.Tables(0).Rows.Count > 0 Then
                'For Each row In dsInterrupcaoExecucao.Tables(0).Rows
                '    interrupcao.id_produtor = Convert.ToInt32(row.Item("id_produtor").ToString)
                '    interrupcao.id_propriedade = Convert.ToInt32(row.Item("id_propriedade").ToString)
                '    interrupcao.id_unid_producao = Convert.ToInt32(row.Item("id_unid_producao").ToString)
                '    interrupcao.nr_unid_producao = Convert.ToInt32(row.Item("nr_unid_producao").ToString)

                '    interrupcao.id_central_interrupcao_fornecimento = 0 'não tem id, busca se já realizou desligamento para a referencia e unid producao anteriormente
                '    interrupcao.id_central_interrupcao_resultado = 3 'Desligado com sucesso
                '    interrupcao.id_execucao = 0
                '    dsPropDesligadas = interrupcao.getInterrupcaoFornecimentoByFilters
                '    If dsPropDesligadas.Tables(0).Rows.Count > 0 Then 'se já desligou anteriormente na referencia
                '        interrupcao.id_central_interrupcao_fornecimento = Convert.ToInt32(row.Item("id_central_interrupcao_fornecimento").ToString)
                '        interrupcao.id_central_interrupcao_resultado = 4 'Propriedade já desativada
                '        interrupcao.updateInterrupcaoFornecimentoResultado()
                '    Else
                '        'se tem movimento abertos, atualiza resultado
                '        If interrupcao.getMovimentosAbertosByPropriedade.Tables(0).Rows.Count > 0 Then
                '            interrupcao.id_central_interrupcao_fornecimento = Convert.ToInt32(row.Item("id_central_interrupcao_fornecimento").ToString)
                '            interrupcao.id_central_interrupcao_resultado = 2 'movimentos abertos
                '            interrupcao.updateInterrupcaoFornecimentoResultado()
                '        Else
                '            'se tem calculo definitivo no mes, atualiza resultado
                '            If interrupcao.getCalculoDefinitivoByPropriedade > 0 Then
                '                interrupcao.id_central_interrupcao_fornecimento = Convert.ToInt32(row.Item("id_central_interrupcao_fornecimento").ToString)
                '                interrupcao.id_central_interrupcao_resultado = 1 'cálculo definitivo
                '                interrupcao.updateInterrupcaoFornecimentoResultado()
                '            Else
                '                interrupcao.id_execucao = ViewState.Item("id_execucao").ToString
                '                interrupcao.id_central_interrupcao_fornecimento = Convert.ToInt32(row.Item("id_central_interrupcao_fornecimento").ToString)
                '                interrupcao.id_central_interrupcao_resultado = 3 'desligado com sucesso
                '                interrupcao.interrupcaoFornecimentoLeite()

                '            End If
                '        End If
                '    End If
                'Next

                interrupcao.id_execucao = ViewState.Item("id_execucao").ToString
                interrupcao.id_central_interrupcao_resultado = 3 'desligado com sucesso
                interrupcao.interrupcaoFornecimentoLeite()


                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 113
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 


                'End If

                saveFilters()
                Response.Redirect("frm_central_interrupcao_fornec_resumo.aspx?id_central_interrupcao_fornecimento=" & ViewState.Item("id_central_interrupcao_fornecimento").ToString)

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub cbo_pagto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim lbl_saldo_pagto_fornecedor As Label = CType(row.FindControl("lbl_saldo_pagto_fornecedor"), Label)
        Dim lbl_saldo_desconto_produtor As Label = CType(row.FindControl("lbl_saldo_desconto_produtor"), Label)
        Dim cbo_pagto As Anthem.DropDownList = CType(row.FindControl("cbo_pagto"), Anthem.DropDownList)
        Dim txt_nr_valor_calculo As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_calculo"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        Dim txt_nr_valor_deposito As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_deposito"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        Dim lbl_valor_exportacao As Anthem.Label = CType(row.FindControl("lbl_valor_exportacao"), Anthem.Label)
        Dim lbl_valor_produtor As Anthem.Label = CType(row.FindControl("lbl_valor_produtor"), Anthem.Label)

        If cbo_pagto.SelectedValue = "P" Then
            'se descontou mais do produtor e pagou menos ao formenecdor
            If CDec(lbl_saldo_desconto_produtor.Text) < CDec(lbl_saldo_pagto_fornecedor.Text) Then
                txt_nr_valor_calculo.Text = CDec("0.00")
                txt_nr_valor_deposito.Text = CDec("0.00")
                lbl_valor_produtor.Text = CDec(lbl_saldo_desconto_produtor.Text)
                lbl_valor_exportacao.Text = CDec(lbl_saldo_pagto_fornecedor.Text) - CDec(lbl_saldo_desconto_produtor.Text)
            Else
                If CDec(lbl_saldo_desconto_produtor.Text) = CDec(lbl_saldo_pagto_fornecedor.Text) Then
                    txt_nr_valor_calculo.Text = CDec("0.00")
                    txt_nr_valor_deposito.Text = CDec("0.00")
                    lbl_valor_produtor.Text = CDec(lbl_saldo_pagto_fornecedor.Text)
                    lbl_valor_exportacao.Text = CDec("0.00")
                Else ' se descontou menos do produtor e pagou mais para o fornecedor
                    If CDec(txt_nr_valor_calculo.Text) = 0 Then
                        txt_nr_valor_deposito.Text = CDec(lbl_saldo_desconto_produtor.Text) - CDec(lbl_saldo_pagto_fornecedor.Text)
                        lbl_valor_produtor.Text = CDec(lbl_saldo_pagto_fornecedor.Text)
                        lbl_valor_exportacao.Text = CDec("0.00")
                    Else
                        txt_nr_valor_calculo.Text = CDec(lbl_saldo_desconto_produtor.Text) - CDec(lbl_saldo_pagto_fornecedor.Text)
                        lbl_valor_produtor.Text = CDec(lbl_saldo_pagto_fornecedor.Text)
                        lbl_valor_exportacao.Text = CDec("0.00")
                        txt_nr_valor_deposito.Text = CDec("0.00")
                    End If
                End If
            End If
        End If

        If cbo_pagto.SelectedValue = "D" Then

            lbl_valor_exportacao.Text = CDec(lbl_saldo_pagto_fornecedor.Text)
            lbl_valor_produtor.Text = CDec("0.00")
            If CDec(txt_nr_valor_calculo.Text) = 0 Then
                txt_nr_valor_deposito.Text = CDec(lbl_saldo_desconto_produtor.Text)
                txt_nr_valor_calculo.Text = CDec("0.00")
            Else
                txt_nr_valor_calculo.Text = CDec(lbl_saldo_desconto_produtor.Text)
                txt_nr_valor_deposito.Text = CDec("0.00")
            End If

        End If

        loadTotalizadores()
    End Sub
End Class
