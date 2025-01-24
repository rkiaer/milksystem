Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail
Imports System.IO


Partial Class frm_central_pedido_abertura_old
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    'Private Sub AtualizarLinkEnviarAprovacao()
    '    Try
    '        Dim cotacao As Danone.MilkSystem.Business.Cotacao = New Danone.MilkSystem.Business.Cotacao(Convert.ToInt32(Me.ViewState("id_central_cotacao").ToString()))
    '        If (cotacao.getCotacaoItensParcelados() > 0) Then
    '            Me.lk_enviar_aprovacao.Enabled = True
    '        End If
    '        If (cotacao.st_pedido_indireto.Equals("S")) Then
    '            Me.lk_enviar_aprovacao.Enabled = False
    '        End If
    '    Catch exception As System.Exception
    '        ProjectData.SetProjectError(exception)
    '        Me.messageControl.Alert(exception.Message)
    '        ProjectData.ClearProjectError()
    '    End Try
    'End Sub

    ' Private Sub AtualizarTotalizadores()
    '     Try
    'Dim cotacao As Danone.MilkSystem.Business.Cotacao = New Danone.MilkSystem.Business.Cotacao() With
    '{
    '         .id_central_cotacao = Convert.ToInt32(Me.ViewState("id_central_cotacao").ToString())
    '}
    '         If (Not Me.lbl_informativo.get_Visible()) Then
    '             Cotacao.st_saldo_romaneio_aberto = "N"
    '         Else
    '             Cotacao.st_saldo_romaneio_aberto = "S"
    '         End If
    '         Cotacao.updateCentralCotacaoTotal()
    '     Catch exception As System.Exception
    '         ProjectData.SetProjectError(exception)
    '         Me.messageControl.Alert(exception.Message)
    '         ProjectData.ClearProjectError()
    '     End Try
    ' End Sub

    'Protected Sub btn_novo_item_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_item.Click

    '    Dim dstable As New DataTable
    '    Dim ilinha As Integer

    '    If (Me.Page.IsValid) Then
    '        Try
    '            dstable.Columns.Add("lbl_descricao_item")
    '            dstable.Columns.Add("ds_tipo_medida")
    '            dstable.Columns.Add("nr_qtde")
    '            dstable.Columns.Add("nr_valor_unitario")
    '            dstable.Columns.Add("nr_sacaria")
    '            dstable.Columns.Add("id_transportador")
    '            dstable.Columns.Add("nr_frete")
    '            dstable.Columns.Add("nm_veiculo_central_compras")
    '            dstable.Columns.Add("nr_valor_total_item")
    '            dstable.Columns.Add("nr_valor_total_frete")
    '            dstable.Columns.Add("nr_valor_total")
    '            dstable.Columns.Add("id_item")
    '            dstable.Columns.Add("st_item_parcelado_danone")
    '            dstable.Columns.Add("id_central_tabela_frete_veiculos")
    '            dstable.Columns.Add("id_central_tabela_precos")
    '            dstable.Columns.Add("id_veiculo_central_compras")
    '            dstable.Columns.Add("inf_preco")
    '            dstable.Columns.Add("inf_frete")
    '            dstable.Columns.Add("nr_valor_tab_preco")
    '            dstable.Columns.Add("nr_sacaria_tab_preco")
    '            dstable.Columns.Add("dt_cotacao_preco")
    '            dstable.Columns.Add("dt_cotacao_frete")
    '            dstable.Columns.Add("linhanova")
    '            dstable.Columns.Add("ds_item")
    '            dstable.Columns.Add("id_categoria")

    '            If (Me.ViewState("gridLinhasAdicionadas") IsNot Nothing) Then
    '                Me.ViewState("incluirlinha") = "S"

    '                Dim row As GridViewRow
    '                Dim lvaloritem As Decimal = 0
    '                Dim lvalorfrete As Decimal = 0

    '                ilinha = 0
    '                For Each row In gridResults.Rows
    '                    If row.Visible = True Then
    '                        Dim lbl_descricao_item As Label = CType(row.FindControl("lbl_descricao_item"), Label)
    '                        Dim lbl_id_item As Anthem.Label = CType(row.FindControl("lbl_id_item"), Anthem.Label)
    '                        Dim lbl_st_item_parcelado_danone As Anthem.Label = CType(row.FindControl("lbl_st_item_parcelado_danone"), Anthem.Label)
    '                        Dim cbo_tipo_medida As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_medida"), Anthem.DropDownList)
    '                        Dim ds_tipo_medida As Anthem.Label = CType(row.FindControl("ds_tipo_medida"), Anthem.Label)
    '                        Dim txt_nr_qtde As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_qtde"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
    '                        Dim txt_nr_valor_unitario As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_unitario"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
    '                        Dim txt_nr_sacaria As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_sacaria"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
    '                        Dim lbl_valor_tab_preco As Anthem.Label = CType(row.FindControl("lbl_valor_tab_preco"), Anthem.Label)
    '                        Dim lbl_sacaria_tab_preco As Anthem.Label = CType(row.FindControl("lbl_sacaria_tab_preco"), Anthem.Label)
    '                        Dim lbl_id_central_tabela_precos As Anthem.Label = CType(row.FindControl("lbl_id_central_tabela_precos"), Anthem.Label)
    '                        Dim lbl_total_item As Anthem.Label = CType(row.FindControl("lbl_total_item"), Anthem.Label)
    '                        Dim cbo_transportador As Anthem.DropDownList = CType(row.FindControl("cbo_transportador"), Anthem.DropDownList)
    '                        Dim id_transportador As Anthem.Label = CType(row.FindControl("id_transportador"), Anthem.Label)
    '                        Dim lbl_tipo_caminhao As Anthem.Label = CType(row.FindControl("lbl_tipo_caminhao"), Anthem.Label)
    '                        Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
    '                        Dim lbl_total_frete As Anthem.Label = CType(row.FindControl("lbl_total_frete"), Anthem.Label)
    '                        Dim lbl_valor_total As Anthem.Label = CType(row.FindControl("lbl_valor_total"), Anthem.Label)
    '                        Dim lbl_id_central_tabela_frete_veiculos As Anthem.Label = CType(row.FindControl("lbl_id_central_tabela_frete_veiculos"), Anthem.Label)
    '                        Dim lbl_id_veiculo_central_compras As Anthem.Label = CType(row.FindControl("lbl_id_veiculo_central_compras"), Anthem.Label)
    '                        Dim lbl_inf_preco As Anthem.Label = CType(row.FindControl("lbl_inf_preco"), Anthem.Label)
    '                        Dim lbl_inf_frete As Anthem.Label = CType(row.FindControl("lbl_inf_frete"), Anthem.Label)
    '                        Dim lbl_dt_cotacao_preco As Anthem.Label = CType(row.FindControl("lbl_dt_cotacao_preco"), Anthem.Label)
    '                        Dim lbl_dt_cotacao_frete As Anthem.Label = CType(row.FindControl("lbl_dt_cotacao_frete"), Anthem.Label)
    '                        Dim lbl_ds_item As Anthem.Label = CType(row.FindControl("lbl_ds_item"), Anthem.Label)
    '                        Dim lbl_id_categoria As Anthem.Label = CType(row.FindControl("lbl_id_categoria"), Anthem.Label)


    '                        dstable.Rows.InsertAt(dstable.NewRow(), ilinha)

    '                        lvaloritem = 0
    '                        lvalorfrete = 0
    '                        With dstable.Rows.Item(ilinha)

    '                            .Item(0) = lbl_descricao_item.Text
    '                            .Item(1) = cbo_tipo_medida.SelectedValue
    '                            .Item(2) = txt_nr_qtde.Text
    '                            .Item(3) = txt_nr_valor_unitario.Text
    '                            .Item(4) = txt_nr_sacaria.Text

    '                            If IsNumeric(txt_nr_qtde.Text) AndAlso IsNumeric(txt_nr_valor_unitario.Text) Then
    '                                If cbo_tipo_medida.SelectedValue.Equals("S") AndAlso IsNumeric(txt_nr_sacaria.Text) Then
    '                                    lvaloritem = (CDec(txt_nr_valor_unitario.Text) + CDec(txt_nr_sacaria.Text)) * CDec(txt_nr_qtde.Text)
    '                                Else
    '                                    lvaloritem = CDec(txt_nr_valor_unitario.Text) * CDec(txt_nr_qtde.Text)
    '                                End If
    '                                .Item(8) = lvaloritem.ToString
    '                            Else
    '                                .Item(8) = "0"
    '                            End If

    '                            'se tipo de frete é fob d
    '                            If cbo_tipo_frete.SelectedValue = "D" Then
    '                                .Item(5) = cbo_transportador.SelectedValue
    '                                .Item(6) = txt_nr_frete.Text
    '                                .Item(7) = lbl_tipo_caminhao.Text
    '                                .Item(9) = lbl_total_frete.Text

    '                                If IsNumeric(txt_nr_qtde.Text) AndAlso IsNumeric(txt_nr_frete.Text) Then
    '                                    lvalorfrete = CDec(txt_nr_frete.Text) * CDec(txt_nr_qtde.Text)
    '                                    .Item(9) = lvalorfrete.ToString
    '                                Else
    '                                    .Item(9) = "0"
    '                                End If

    '                            Else
    '                                .Item(5) = String.Empty
    '                                .Item(6) = String.Empty
    '                                .Item(7) = String.Empty
    '                                .Item(9) = String.Empty
    '                            End If


    '                            .Item(10) = (lvaloritem + lvalorfrete).ToString
    '                            .Item(11) = lbl_id_item.Text
    '                            .Item(12) = lbl_st_item_parcelado_danone.Text
    '                            .Item(13) = lbl_id_central_tabela_frete_veiculos.Text
    '                            .Item(14) = lbl_id_central_tabela_precos.Text
    '                            .Item(15) = lbl_id_veiculo_central_compras.Text
    '                            .Item(16) = lbl_inf_preco.Text
    '                            .Item(17) = lbl_inf_frete.Text
    '                            .Item(18) = lbl_valor_tab_preco.Text
    '                            .Item(19) = lbl_sacaria_tab_preco.Text
    '                            .Item(20) = lbl_dt_cotacao_preco.Text
    '                            .Item(21) = lbl_dt_cotacao_frete.Text
    '                            .Item(22) = "N"
    '                            .Item(23) = lbl_ds_item.Text
    '                            .Item(24) = lbl_id_categoria.Text
    '                        End With

    '                        ilinha = ilinha + 1
    '                    End If
    '                Next

    '                ViewState.Item("gridtable") = dstable

    '            Else
    '                Me.ViewState("gridLinhasAdicionadas") = "S"
    '                ilinha = 0
    '            End If

    '            'busca parcelamento danone do item
    '            Dim pedido As New Pedido()
    '            pedido.id_pessoa = ViewState.Item("id_produtor")
    '            pedido.id_item = cbo_item.SelectedValue

    '            Dim dsparcelamento As DataSet = pedido.getCentralParcelamentoDanoneByItem()
    '            Dim lparcelamentoitem As String = "N"
    '            If (dsparcelamento.Tables(0).Rows.Count > 0) Then
    '                lparcelamentoitem = "S"
    '            End If

    '            dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
    '            Dim rownova As DataRow = dstable.Rows(ilinha)

    '            'para item novo busca valor tabela de preço, ultimo ativo
    '            Dim preco As New TabelaPrecos
    '            preco.id_estabelecimento = Convert.ToInt32(Me.cbo_estabelecimento.SelectedValue)
    '            preco.id_fornecedor = cbo_fornecedor.SelectedValue
    '            preco.id_item = cbo_item.SelectedValue
    '            preco.id_estado_propriedade = Me.ViewState.Item("id_estado_destino")
    '            preco.id_cidade_propriedade = Me.ViewState.Item("id_cidade_destino")

    '            Dim dsprecomax As DataSet = preco.getCentralTabelaPrecosMax()
    '            If (dsprecomax.Tables(0).Rows.Count > 0) Then
    '                With dsprecomax.Tables(0).Rows(0)
    '                    rownova(3) = .Item("nr_valor")
    '                    rownova(4) = .Item("nr_valor_sacaria")
    '                    rownova(14) = .Item("id_central_tabela_precos")
    '                    rownova(16) = String.Concat("(Data cotação: ", DateTime.Parse(.Item("dt_cotacao").ToString).ToString("dd/MM/yyyy"), ")")
    '                    rownova(18) = .Item("nr_valor")
    '                    rownova(19) = .Item("nr_valor_sacaria")
    '                    rownova(20) = DateTime.Parse(.Item("dt_cotacao").ToString).ToString("dd/MM/yyyy")
    '                End With
    '            End If

    '            rownova(0) = String.Concat(cbo_item.SelectedItem.Text, "    Categoria: ", lbl_nm_categoria.Text)
    '            rownova(11) = cbo_item.SelectedValue
    '            rownova(12) = lparcelamentoitem
    '            rownova(22) = "S"
    '            rownova(23) = cbo_item.SelectedItem.Text
    '            rownova(24) = ViewState.Item("id_categoria_item").ToString

    '            Me.ViewState("gridtable") = dstable
    '            Me.gridResults.Visible = True
    '            Me.gridResults.DataSource = Helper.getDataView(dstable, Me.ViewState.Item("sortExpression"))
    '            Me.gridResults.DataBind()

    '            Me.ViewState("incluirlinha") = "N"

    '            btn_novo_item.Visible = False
    '        Catch ex As Exception
    '            Me.messageControl.Alert(ex.Message)
    '        End Try
    '    End If
    'End Sub

    Private Sub carregarCamposProdutor()
        Try
            Me.lbl_nm_pessoa.Text = String.Empty
            Me.lbl_ds_telefone.Text = String.Empty
            Me.lbl_acordo_aquisicao_insumos.Text = String.Empty
            Me.lbl_cluster.Text = String.Empty
            Me.lbl_ds_email.Text = String.Empty
            Me.lbl_contrato.Text = String.Empty
            Me.lbl_dt_ini_contrato.Text = String.Empty
            Me.lbl_dt_fim_contrato.Text = String.Empty
            Me.lbl_dt_rescisao_contrato.Text = String.Empty
            'se cbo forn maior que zero e id_central_tabelpreco > 0 limpa infot, sacaria e vl unitario faz o mesmo com transportador
            If CInt(ViewState.Item("id_central_tabela_precos")) <> 0 Then
                lbl_inf_preco.Text = String.Empty
                txt_nr_valor_unitario.Text = String.Empty
                txt_nr_sacaria.Text = String.Empty
                lbl_total_item.Text = "R$ 0,00"
                lbl_valor_total.Text = String.Empty
            End If

            If CInt(ViewState.Item("id_central_tabela_frete_veiculos")) <> 0 Then
                lbl_inf_frete.Text = String.Empty
                txt_nr_frete.Text = String.Empty
                lbl_total_frete.Text = "R$ 0,00"
                lbl_valor_total.Text = String.Empty

            End If
            Me.lk_gerar_pedido.Enabled = False
            If (Not Me.customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = Me.customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString()
            End If
            If (Me.customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Dim pessoa As New Pessoa
                pessoa.id_pessoa = -1
                Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()
                Dim dr As DataRow = dspropriedades.Tables(0).NewRow()
                dspropriedades.Tables(0).Rows.InsertAt(dr, 0)
                gridPropriedades.Visible = True
                gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
                gridPropriedades.DataBind()
                gridPropriedades.Rows(0).Cells.Clear()
                gridPropriedades.Rows(0).Cells.Add(New TableCell())
                gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridPropriedades.Rows(0).Cells(0).ColumnSpan = 10
                gridPropriedades.Rows(0).Cells(0).Text = "Informe um produtor para visualizar suas propriedades!"

                Me.ViewState("gridpropriedadeslinhas") = 0
            Else
                Me.txt_cd_pessoa.Text = Me.customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString()
                If (Convert.ToInt32(Me.hf_id_produtor.Value.ToString()) > 0) Then
                    Me.loadDadosProdutor(Convert.ToInt32(Me.hf_id_produtor.Value))
                End If
            End If
            Me.customPage.clearFilters("lupa_produtor")
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try
    End Sub


    'Protected Sub cv_cotacao_ServerValidate(ByVal source As Object, ByVal args As ServerValidateEventArgs)
    '    Try
    '        args.IsValid = True
    '        Dim namingContainer As GridViewRow = DirectCast(DirectCast(source, WebControl).NamingContainer, GridViewRow)
    '        Dim label As System.Web.UI.WebControls.Label = DirectCast(namingContainer.FindControl("lbl_id_central_cotacao_fornecedor"), System.Web.UI.WebControls.Label)
    '        If (DirectCast(namingContainer.FindControl("chk_st_selecionado"), System.Web.UI.WebControls.CheckBox).Checked) Then
    'Dim cotacaoFornecedor As Danone.MilkSystem.Business.CotacaoFornecedor = New Danone.MilkSystem.Business.CotacaoFornecedor() With
    '{
    '	.id_central_cotacao_item = Convert.ToInt32(Me.ViewState("id_central_cotacao_item").ToString()),
    '            .st_selecionado = "S"
    '}
    '            If (CotacaoFornecedor.getCotacaoFornecedorByFilters().Tables(0).Rows.Count > 0) Then
    '                If (Not Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(Me.ViewState("incluirlinhacotacao"), "S", False)) Then
    '                    CotacaoFornecedor.id_central_cotacao_fornecedor = Convert.ToInt32(label.Text)
    '                    If (CotacaoFornecedor.getCotacaoFornecedorByFilters().Tables(0).Rows.Count <= 0) Then
    '                        args.IsValid = False
    '                    Else
    '                        args.IsValid = True
    '                    End If
    '                Else
    '                    args.IsValid = False
    '                End If
    '            End If
    '        End If
    '        If (Not args.IsValid) Then
    '            Me.messageControl.Alert("Já existe Parceiro selecionado para este item de cotação.")
    '        End If
    '    Catch exception As System.Exception
    '        ProjectData.SetProjectError(exception)
    '        Me.messageControl.Alert(exception.Message)
    '        ProjectData.ClearProjectError()
    '    End Try
    'End Sub

    Protected Sub cv_itens_ServerValidate(ByVal source As Object, ByVal args As ServerValidateEventArgs)
        Dim str As String = Nothing
        Try
            args.IsValid = True
            'If (Me.ValidarItensFornecedores(str)) Then
            '    args.IsValid = True
            'Else
            '    args.IsValid = False
            '    Me.messageControl.Alert(str)
            'End If
        Catch exception As System.Exception
            Me.messageControl.Alert(exception.Message)
        End Try
    End Sub


    Protected Sub cv_pedido_aprovacao_ServerValidate(ByVal source As Object, ByVal args As ServerValidateEventArgs) Handles cv_pedido_aprovacao.ServerValidate
        Dim str As String = Nothing
        Try
            args.IsValid = True
            Select Case (New Cotacao(Convert.ToInt32(Me.ViewState("id_central_cotacao").ToString()))).id_situacao_cotacao
                Case 1
                Case 2
                    If (Not Me.lk_enviar_aprovacao.Enabled) Then
                        Dim saldoDisponivel As Danone.MilkSystem.Business.SaldoDisponivel = New Danone.MilkSystem.Business.SaldoDisponivel()
                        Dim strArrays() As String = {String.Concat("01/", Strings.Format(DateTime.Parse(Convert.ToString(DateAndTime.Now)), "MM/yyyy").ToString())}
                        saldoDisponivel.dt_referencia = String.Concat(strArrays)
                        'saldoDisponivel.id_propriedade = Convert.ToInt32(Me.txt_id_propriedade.Text)
                        'Me.AtualizarTotalizadores()
                        'Me.AtualizarLinkEnviarAprovacao()
                        If (Not Me.lk_enviar_aprovacao.Enabled) Then
                            args.IsValid = True
                            Exit Select
                        Else
                            args.IsValid = False
                            str = "O pedido só poderá ser gerado após 'Enviar Aprovação'."
                            Exit Select
                        End If
                    Else
                        args.IsValid = False
                        str = "O pedido só poderá ser gerado após 'Enviar Aprovação'."
                        Exit Select
                    End If
                Case 3
                    args.IsValid = False
                    str = "O pedido não pode ser gerado no momento pois a cotação está 'Em Aprovação'."
                    Exit Select
                Case 4
                    args.IsValid = False
                    str = "O pedido não pode ser gerado pois todos os itens da cotação foram 'Recusados' pelos aprovadores."
                    Exit Select
                Case 5
                    args.IsValid = True
                    Exit Select
            End Select
            If (Not args.IsValid) Then
                Me.messageControl.Alert(str)
            End If
        Catch exception As System.Exception
            Me.messageControl.Alert(exception.Message)
        End Try
    End Sub


    Protected Sub cv_validar_item_ServerValidate(ByVal source As Object, ByVal args As ServerValidateEventArgs) Handles cv_validar_item.ServerValidate
        Try
            args.IsValid = True

            Dim lmsg As String = String.Empty

            If ViewState.Item("id_fornecedor").ToString.Trim = "0" Then
                args.IsValid = False
                lmsg = "O parceiro deve ser informado para prosseguir com a inclusão do item."
            Else
                If cbo_tipo_frete.SelectedValue.Equals(String.Empty) Then
                    args.IsValid = False
                    lmsg = "O Tipo do Frete deve ser informado para prosseguir com a inclusão do item."
                Else

                    If ViewState.Item("id_propriedade").ToString = "0" Then
                        args.IsValid = False
                        lmsg = "A propriedade deve ser informada para prosseguir com a inclusão do item."

                        'Else
                        '    For Each row In gridResults.Rows
                        '        If row.Visible = True Then
                        '            If CInt(CType(row.FindControl("lbl_id_item"), Anthem.Label).Text) = CInt(cbo_item.SelectedValue) Then
                        '                args.IsValid = False
                        '                lmsg = "O item informado já foi incluído ao Pedido."
                        '                Exit For
                        '            End If
                        '            If CInt(CType(row.FindControl("lbl_id_categoria"), Label).Text) <> CInt(ViewState.Item("id_categoria_item")) Then
                        '                args.IsValid = False
                        '                lmsg = "Todos os itens de um pedido devem ser da mesma categoria."
                        '                Exit For
                        '            End If

                        '        End If
                        '    Next
                    End If
                End If
            End If

            If args.IsValid = False Then
                Me.messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try
    End Sub


    'Private Sub deleteItem(ByVal id_index_row As Integer)
    '    Try
    '        gridResults.Rows(id_index_row).Visible = False
    '        Me.btn_novo_item.Visible = True

    '        gridResults.DataSource = Nothing
    '        gridResults.Visible = False
    '        lbl_detalhe_item_frete.Text = String.Empty
    '        gridfrete.Visible = False
    '        ViewState.Item("id_index_item_frete") = String.Empty
    '        pnl_frete.Visible = False
    '        ViewState("gridLinhasAdicionadas") = Nothing

    '    Catch ex As Exception
    '        Me.messageControl.Alert(ex.Message)
    '    End Try
    'End Sub

    'Private Sub EnviarEmailTecnicoAprovacao()
    '    Try
    '        If (Me.Page.IsValid) Then
    '            Try
    '                Dim notificacao As Danone.MilkSystem.Business.Notificacao = New Danone.MilkSystem.Business.Notificacao()
    '                Dim str As String = String.Concat("Aprovação de Cotações Central de Compras para Propriedade ", Me.txt_id_propriedade.Text.Trim(), " - ", String.Concat(Me.lbl_nm_propriedade.Text.Trim(), "."))
    '                Dim str1 As String = "Existem cotações realizadas pela Central de Compras do Produtor "
    '                str1 = String.Concat(str1, "'", String.Concat(Me.txt_id_propriedade.Text.Trim(), " - ", Me.lbl_nm_propriedade.Text.Trim()), "', ")
    '                str1 = String.Concat(str1, " pendentes para serem aprovadas por você, técnico responsável.")
    '                Dim propriedade As Danone.MilkSystem.Business.Propriedade = New Danone.MilkSystem.Business.Propriedade(Convert.ToInt32(Me.txt_id_propriedade.Text))
    '                Dim dsEmail As String = ""
    '                If (propriedade.id_tecnico > 0) Then
    '                    Dim tecnico As Danone.MilkSystem.Business.Tecnico = New Danone.MilkSystem.Business.Tecnico(Convert.ToInt32(propriedade.id_tecnico))
    '                    dsEmail = tecnico.ds_email
    '                End If
    '                If (dsEmail.Equals(String.Empty)) Then
    '                    Me.messageControl.Alert("A mensagem de solicitação de aprovação para o Técnico Responsável pela propriedade não pode ser enviada. Não há informação de email no cadastro do Técnico desta propriedade.")
    '                    Me.img_notificacao.Visible = True
    '                    Me.lk_notificar_aprovadores.set_Visible(True)
    '                ElseIf (Not notificacao.enviaMensagemEmail(str, str1, "central.compras@danone.com", dsEmail, "", MailPriority.High, False, "", True)) Then
    '                    Me.messageControl.Alert("A mensagem de solicitação de aprovação para o Técnico Responsável pela propriedade não pode ser enviada. Verifique se há destinatários cadastrados para este tipo de notificação.")
    '                    Me.img_notificacao.Visible = True
    '                    Me.lk_notificar_aprovadores.set_Visible(True)
    '                Else
    '                    Me.messageControl.Alert("A mensagem de solicitação de aprovação para o Técnico Responsável pela propriedade foi enviada aos destinatários com sucesso!")
    '                End If
    '            Catch exception As System.Exception
    '                Me.messageControl.Alert(exception.Message)
    '            End Try
    '        End If
    '    Catch exception1 As System.Exception
    '        Me.messageControl.Alert(exception1.Message)
    '    End Try
    'End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Protected Sub gridPropriedades_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles gridPropriedades.RowDataBound
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
                    Dim lbl_indexgridmatriz As Anthem.Label = CType(e.Row.FindControl("lbl_indexgridmatriz"), Anthem.Label)


                    If Not lbl_nr_valor_mensal_estimado.Text.Equals(String.Empty) Then
                        lbl_nr_valor_mensal_estimado.Text = FormatNumber(lbl_nr_valor_mensal_estimado.Text, 2).ToString
                    End If

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
                        imgselecionar.Visible = True

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

                        If Not lbl_id_propriedade_matriz.Text.Equals(String.Empty) Then
                            pedido.id_propriedade_matriz = lbl_id_propriedade_matriz.Text
                        Else
                            pedido.id_propriedade = lbl_id_propriedade.Text
                        End If

                        lbl_nr_total_pedidos_abertos.Text = pedido.getTotalPedidosAbertos().ToString()
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

                        Dim saldoDisponivel As New SaldoDisponivel()
                        saldoDisponivel.dt_referencia = String.Concat("01/", DateTime.Now.ToString("MM/yyyy")).ToString
                        If Not lbl_id_propriedade_matriz.Text.Equals(String.Empty) Then
                            saldoDisponivel.id_propriedade = lbl_id_propriedade_matriz.Text
                        Else
                            saldoDisponivel.id_propriedade = lbl_id_propriedade.Text
                        End If

                        Dim dslimite As DataSet = saldoDisponivel.getSaldoDisponivelPropriedadeEMatriz
                        If dslimite.Tables(0).Rows.Count > 0 Then
                            With dslimite.Tables(0).Rows(0)
                                lbl_nr_valor_disponivel.Text = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                                lbl_nr_limite_mes_bruto.Text = FormatNumber(.Item("nr_limite_mes_bruto").ToString, 2).ToString
                                lbl_nr_valor_desconto.Text = FormatNumber(.Item("nr_valor_desconto").ToString, 2).ToString
                            End With

                        Else
                            'se nao tem faturamento na ficha do mes anterior, busca do projetado na ficha custo financeiro
                            Dim dslimitecusto As DataSet = saldoDisponivel.getSaldoDisponivelFichaCustoPropriedadeEMatriz
                            If dslimitecusto.Tables(0).Rows.Count > 0 Then
                                With dslimitecusto.Tables(0).Rows(0)
                                    lbl_nr_valor_disponivel.Text = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                                    lbl_nr_limite_mes_bruto.Text = FormatNumber(.Item("nr_limite_mes_bruto").ToString, 2).ToString
                                    lbl_nr_valor_desconto.Text = FormatNumber(.Item("nr_valor_desconto").ToString, 2).ToString
                                End With
                                Me.lbl_informativo_1.Visible = True
                                lbl_nr_valor_disponivel.ForeColor = Drawing.Color.Blue
                                lbl_nr_limite_mes_bruto.ForeColor = Drawing.Color.Blue
                            Else
                                'se nao encontrou valor projetado e nem faturamento mes anterior
                                Me.lbl_informativo_2.Visible = True
                                lbl_nr_valor_disponivel.Text = String.Empty
                                lbl_nr_limite_mes_bruto.Text = String.Empty
                                lbl_nr_valor_desconto.Text = String.Empty

                            End If
                        End If

                    End If

                End If
            End If
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridPropriedades_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gridPropriedades.SelectedIndexChanged


        Dim rowselected As GridViewRow = Me.gridPropriedades.SelectedRow
        Dim lbl_id_propriedade As Label = CType(rowselected.FindControl("lbl_id_propriedade"), Label)
        Dim lbl_id_propriedade_matriz As Label = CType(rowselected.FindControl("lbl_id_propriedade_matriz"), Label)
        Dim lbl_id_produtor As Label = CType(rowselected.FindControl("lbl_id_produtor"), Label)
        Dim lbl_id_estado As Label = CType(rowselected.FindControl("lbl_id_estado"), Label)
        Dim lbl_id_cidade As Label = CType(rowselected.FindControl("lbl_id_cidade"), Label)
        Dim lbl_indexgridmatriz As Anthem.Label = CType(rowselected.FindControl("lbl_indexgridmatriz"), Anthem.Label)
        'Dim lbl_nr_valor_disponivel As Label = CType(rowselected.FindControl("lbl_nr_valor_disponivel"), Label)
        'pega o valor duisponivel da propriedade matriz ou da propria propriedade
        Dim lbl_nr_valor_disponivel As Label = CType(gridPropriedades.Rows(lbl_indexgridmatriz.Text).FindControl("lbl_nr_valor_disponivel"), Anthem.Label)

        Me.ViewState.Item("id_propriedade") = lbl_id_propriedade.Text
        If lbl_id_propriedade_matriz.Text.Equals(String.Empty) Then
            Me.ViewState.Item("id_propriedade_matriz") = "0"
        Else
            Me.ViewState.Item("id_propriedade_matriz") = lbl_id_propriedade_matriz.Text

        End If
        Me.ViewState.Item("id_produtor") = lbl_id_produtor.Text
        Me.ViewState.Item("id_estado_destino") = lbl_id_estado.Text
        Me.ViewState.Item("id_cidade_destino") = lbl_id_cidade.Text
        If lbl_nr_valor_disponivel.Text = String.Empty Then
            ViewState.Item("limitedisponivel") = 0
        Else
            ViewState.Item("limitedisponivel") = CDec(lbl_nr_valor_disponivel.Text)
        End If
        ViewState.Item("indexgridpropriedadeprincipal") = lbl_indexgridmatriz.Text
    End Sub


    Private Sub LimparSelecaoGridItens()
        'Try
        '    Me.ViewState("id_central_cotacao_item") = 0
        '    Me.btn_adicionar_cotacao.Enabled = False
        'Catch exception As System.Exception
        '    ProjectData.SetProjectError(exception)
        '    Me.messageControl.Alert(exception.Message)
        '    ProjectData.ClearProjectError()
        'End Try
    End Sub

    Protected Sub lk_enviar_aprovacao_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lk_enviar_aprovacao.Click
        If (Me.Page.IsValid) Then
            '        Try
            'Dim cotacao As Danone.MilkSystem.Business.Cotacao = New Danone.MilkSystem.Business.Cotacao() With
            '{
            '            .id_central_cotacao = Convert.ToInt32(Me.ViewState("id_central_cotacao").ToString())
            '}
            '            Cotacao.updateCotacaoQtdeItensAprovacao()
            '            Cotacao.id_situacao_cotacao = 3
            '            Cotacao.updateCentralCotacaoSituacao()
            'Dim cotacaoItem As Danone.MilkSystem.Business.CotacaoItem = New Danone.MilkSystem.Business.CotacaoItem() With
            '{
            '	.id_central_status_aprovacao = Conversions.ToString(7),
            '            .id_central_cotacao = Cotacao.id_central_cotacao
            '}
            '            CotacaoItem.updateCentralCotacaoItemSituacaobyCotacao()
            '            Me.EnviarEmailTecnicoAprovacao()
            '        Catch exception As System.Exception
            '            ProjectData.SetProjectError(exception)
            '            Me.messageControl.Alert(exception.Message)
            '            ProjectData.ClearProjectError()
            '        End Try
        End If
    End Sub

    Protected Sub lk_gerar_pedido_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lk_gerar_pedido.Click
        If (Me.Page.IsValid) Then
            Try

                If ViewState.Item("id_central_pedido_matriz") Is Nothing OrElse ViewState.Item("id_central_pedido_matriz") = "0" Then
                    'preparar dados do grid de itens
                    Dim dstable As New DataTable
                    Dim ilinha As Integer

                    dstable.Columns.Add("id_item")
                    dstable.Columns.Add("id_categoria")
                    dstable.Columns.Add("ds_tipo_medida")
                    dstable.Columns.Add("nr_qtde")
                    dstable.Columns.Add("nr_valor_unitario")
                    dstable.Columns.Add("nr_sacaria")
                    dstable.Columns.Add("id_central_tabela_precos")
                    dstable.Columns.Add("nr_valor_total_item")
                    dstable.Columns.Add("id_transportador")
                    dstable.Columns.Add("nr_frete")
                    dstable.Columns.Add("nr_valor_total_frete")
                    dstable.Columns.Add("id_central_tabela_frete_veiculos")
                    dstable.Columns.Add("id_veiculo_central_compras")
                    dstable.Columns.Add("ds_motivo_aprovacao")


                    Dim lvaloritem As Decimal = 0
                    Dim lvalorfrete As Decimal = 0
                    Dim lvalortotalpedidofornecedor As Decimal = 0
                    Dim lvalortotalpedidotransortador As Decimal = 0

                    ilinha = 0

                    dstable.Rows.InsertAt(dstable.NewRow(), ilinha)

                    lvaloritem = 0
                    lvalorfrete = 0
                    With dstable.Rows.Item(ilinha)

                        .Item(0) = cbo_item.SelectedValue
                        .Item(1) = ViewState.Item("id_categoria_item")
                        .Item(2) = cbo_tipo_medida.SelectedValue
                        .Item(3) = CDec(txt_nr_qtde.Text)
                        .Item(4) = CDec(txt_nr_valor_unitario.Text)
                        'se sacaria
                        If cbo_tipo_medida.SelectedValue = "S" Then
                            .Item(5) = CDec(txt_nr_sacaria.Text)
                        Else
                            .Item(5) = "0"
                        End If
                        'se a informação sobre tabela preço esta vazia significa que não utilizou tabela de preços do cadastro
                        If lbl_inf_preco.Text.Equals(String.Empty) Then
                            .Item(6) = "0"
                        Else
                            .Item(6) = ViewState.Item("id_central_tabela_precos")
                        End If

                        If cbo_tipo_medida.SelectedValue.Equals("S") Then
                            lvaloritem = (CDec(txt_nr_valor_unitario.Text) + CDec(txt_nr_sacaria.Text)) * CDec(txt_nr_qtde.Text)
                        Else
                            lvaloritem = CDec(txt_nr_valor_unitario.Text) * CDec(txt_nr_qtde.Text)
                        End If
                        .Item(7) = lvaloritem.ToString

                        'se tipo de frete é fob d
                        If cbo_tipo_frete.SelectedValue = "D" Then
                            .Item(8) = cbo_transportador.SelectedValue
                            .Item(9) = CDec(txt_nr_frete.Text)
                            lvalorfrete = CDec(txt_nr_frete.Text) * CDec(txt_nr_qtde.Text)
                            .Item(10) = lvalorfrete.ToString
                            'se informação sobre tabela de frete for vazia, significa que nao uilizou tabela de frete do cadastro
                            If lbl_inf_frete.Text.Equals(String.Empty) Then
                                .Item(11) = "0"
                                .Item(12) = "0"
                            Else
                                .Item(11) = ViewState.Item("id_central_tabela_frete_veiculos")
                                .Item(12) = ViewState.Item("id_veiculo_central_compras")
                            End If
                        Else
                            .Item(8) = "0"
                            .Item(9) = "0"
                            .Item(10) = "0"
                            .Item(11) = "0"
                            .Item(12) = "0"
                            lvalorfrete = 0
                        End If


                        lvalortotalpedidofornecedor = lvalortotalpedidofornecedor + lvaloritem
                        lvalortotalpedidotransortador = lvalortotalpedidotransortador + lvalorfrete

                    End With

                    'ilinha = ilinha + 1
                    Dim pedido As New Pedido

                    Dim ldtprimparcelaprodutor As String = String.Empty
                    Dim ldtultparcelaprodutor As String = String.Empty


                    pedido.id_estabelecimento = cbo_estabelecimento.SelectedValue
                    pedido.id_propriedade = ViewState.Item("id_propriedade").ToString
                    pedido.id_propriedade_matriz = ViewState.Item("id_propriedade_matriz").ToString
                    pedido.id_fornecedor = ViewState.Item("id_fornecedor").ToString
                    pedido.st_tipo_parcelamento = cbo_vai_parcelar.SelectedValue
                    If cbo_vai_parcelar.SelectedValue = "N" Then
                        pedido.nr_qtde_parcelas = 1
                    Else
                        pedido.nr_qtde_parcelas = txt_nr_parcelas.Text
                    End If
                    pedido.ds_tipofrete = cbo_tipo_frete.SelectedValue
                    pedido.ds_inclusao_pedido = "M"
                    pedido.st_pedido_indireto = cbo_pedido_indireto.SelectedValue
                    If chk_compras_evento.Checked = True Then
                        pedido.st_evento_compras = "S"
                    Else
                        pedido.st_evento_compras = "N"
                    End If
                    pedido.nr_total_pedido = lvalortotalpedidofornecedor
                    pedido.nr_total_pedido_frete = lvalortotalpedidotransortador
                    pedido.nr_valor_limite_disponivel = Convert.ToDecimal(ViewState.Item("limitedisponivel").ToString)
                    pedido.id_transportador = dstable.Rows(0).Item(8)
                    pedido.id_veiculo_central_compras_propriedade = cbo_tipo_caminhao.SelectedValue

                    pedido.calcularDataDescontoProdutor(DateTime.Now.ToString("dd/MM/yyyy"), pedido.nr_qtde_parcelas, ldtprimparcelaprodutor, ldtultparcelaprodutor)

                    pedido.id_situacao_pedido = pedido.apurarSituacaoAprovacao(lvalortotalpedidofornecedor + lvalortotalpedidotransortador, pedido.nr_valor_limite_disponivel, pedido.st_tipo_parcelamento, pedido.nr_qtde_parcelas, lbl_dt_fim_contrato.Text, ldtultparcelaprodutor, pedido.ds_motivo_aprovacao)

                    dstable.Rows.Item(0).Item(13) = pedido.ds_motivo_aprovacao.ToString
                    pedido.pedidoitens = dstable

                    pedido.id_modificador = Session("id_login")

                    ViewState.Item("id_central_pedido_matriz") = pedido.gerarPedidoPropriedade()

                    Dim lnmsituacao As String = String.Empty
                    If pedido.id_situacao_pedido = 6 Then
                        lnmsituacao = " (Situação do Pedido APROVADO)"
                    End If
                    If pedido.id_situacao_pedido = 5 Then
                        lnmsituacao = " (Situação do Pedido PENDENTE EM APROVAÇÃO)"
                    End If

                    Dim lpedidofrete As Integer = 0
                    Dim lmsg As String = String.Empty
                    If pedido.ds_tipofrete = "D" Then
                        pedido.id_central_pedido = ViewState.Item("id_central_pedido_matriz")
                        pedido.st_tipo_fornecedor = "T"
                        Dim dspedidofrete As DataSet = pedido.getCentralPedidoMatriz
                        If dspedidofrete.Tables(0).Rows.Count > 0 Then
                            lpedidofrete = dspedidofrete.Tables(0).Rows(0).Item("id_central_pedido")
                        End If
                    End If

                    If ViewState.Item("id_central_pedido_matriz") = 0 Then
                        Me.messageControl.Alert("Ocorreram problemas na geração do Pedido. Contate o administrador do sistema.")
                    Else
                        Me.messageControl.Alert("Pedidos gerados com sucesso!")
                        lk_gerar_pedido.Enabled = False
                        lk_gerar_pedido.ToolTip = "Pedido gerado."


                        If lpedidofrete = 0 Then
                            lmsg = String.Concat("O Pedido ", ViewState.Item("id_central_pedido_matriz").ToString, " para o Parceiro de Insumos foi gerado com sucesso!", lnmsituacao)
                        Else
                            lmsg = String.Concat("O Pedido ", ViewState.Item("id_central_pedido_matriz").ToString, " para o Parceiro de Insumos e o Pedido ", lpedidofrete.ToString, " para o Parceiro de Frete, foram gerados com sucesso!", lnmsituacao)
                        End If
                        Response.Redirect("frm_mensagem.aspx?msg=" + lmsg + "&tela=frm_central_pedido.aspx?id_central_pedido=" + ViewState.Item("id_central_pedido_matriz").ToString)

                    End If
                End If

            Catch ex As Exception
                Me.messageControl.Alert(ex.Message)
            End Try
            'Else
            '    Me.messageControl.Alert("Consistencias na Tela")
        End If
    End Sub

    Protected Sub lk_notificar_aprovadores_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lk_notificar_aprovadores.Click
        'Try
        '    Me.EnviarEmailTecnicoAprovacao()
        'Catch exception As System.Exception
        '    ProjectData.SetProjectError(exception)
        '    Me.messageControl.Alert(exception.Message)
        '    ProjectData.ClearProjectError()
        'End Try
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lk_novo.Click
        Me.Response.Redirect("frm_central_pedido_abertura.aspx")
    End Sub

    Private Sub loadDadosProdutor(ByVal pid_produtor As Integer)
        Me.lbl_nm_pessoa.Text = String.Empty
        Me.lbl_ds_telefone.Text = String.Empty
        Me.lbl_acordo_aquisicao_insumos.Text = String.Empty
        Me.lbl_cluster.Text = String.Empty
        Me.lbl_ds_email.Text = String.Empty
        Me.lbl_contrato.Text = String.Empty
        Me.lbl_dt_ini_contrato.Text = String.Empty
        Me.lbl_dt_fim_contrato.Text = String.Empty
        Me.lbl_dt_rescisao_contrato.Text = String.Empty

        Try
            Dim lidpessoacontrato As Integer = 0
            Dim produtor As New Pessoa
            produtor.id_pessoa = pid_produtor

            Dim dspessoa As DataSet = produtor.getPessoaByFilters

            If (dspessoa.Tables(0).Rows.Count <= 0) Then
                Me.lk_gerar_pedido.Enabled = False
            Else
                With dspessoa.Tables(0).Rows(0)
                    Me.lbl_nm_pessoa.Enabled = True
                    Me.lbl_nm_pessoa.Text = .Item("nm_pessoa").ToString
                    Me.hf_id_produtor.Value = .Item("id_pessoa").ToString
                    Me.lbl_ds_telefone.Text = .Item("ds_celular").ToString
                    Me.lbl_ds_email.Text = .Item("ds_email").ToString
                    If .Item("st_acordo_aquisicao_insumos").ToString.Equals("S") Then
                        Me.lbl_acordo_aquisicao_insumos.Text = "Sim"
                    Else
                        Me.lbl_acordo_aquisicao_insumos.Text = "Não"
                    End If

                    If Not IsDBNull(.Item("id_pessoa_contrato")) Then
                        lidpessoacontrato = .Item("id_pessoa_contrato")
                    End If
                End With

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


                Me.loadGridPropriedades()
            End If
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try
    End Sub

    Private Sub loadDetails()
        Try
            Dim estabel As New Estabelecimento
            estabel.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
            ViewState.Item("id_estabelecimento") = "0"
            Me.ViewState.Item("id_propriedade") = 0
            Me.ViewState.Item("id_estado_destino") = 0
            Me.ViewState.Item("id_cidade_destino") = 0
            Me.ViewState.Item("id_produtor") = 0
            Me.ViewState.Item("id_central_pedido_matriz") = 0
            ViewState.Item("id_central_tabela_precos") = 0
            ViewState.Item("id_central_pedido_matriz") = 0
            ViewState.Item("id_central_tabela_frete_veiculos") = 0

            Dim parametro As New Parametro
            ViewState("nr_politica_parcelas") = parametro.nr_politica_parcelas

            Dim veiculo As New VeiculoCentralCompras
            veiculo.id_situacao = 1
            cbo_tipo_caminhao.DataSource = veiculo.getVeiculoCentralComprasByFilters()
            cbo_tipo_caminhao.DataTextField = "ds_veiculo"
            cbo_tipo_caminhao.DataValueField = "id_veiculocentralcompras"
            cbo_tipo_caminhao.DataBind()
            cbo_tipo_caminhao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'combo fornecedor
            'cbo_fornecedor.Items.Insert(0, New ListItem("[Selecione um Estabelecimento]", "0"))
            'cbo_fornecedor.SelectedValue = 0
            'ViewState.Item("id_fornecedor") = "0"

            'combo item
            cbo_item.Items.Insert(0, New ListItem("[Selecione um Parceiro]", "0"))
            cbo_item.SelectedValue = 0
            lbl_detalhe_item_frete.Text = String.Empty
            gridfrete.Visible = False
            ViewState.Item("id_item") = "0"

            'combo transportador
            'transportador central
            Dim pessoa As New Pessoa
            pessoa.id_situacao = 1
            pessoa.st_transportador_central = "S"
            pessoa.st_acordo_aquisicao_insumos = "S"
            cbo_transportador.DataSource = pessoa.getTransportadorCentralByFilters()
            cbo_transportador.DataTextField = "nm_pessoa"
            cbo_transportador.DataValueField = "id_pessoa"
            cbo_transportador.DataBind()
            cbo_transportador.Items.Insert(0, New ListItem("[Tipo de Frete sem Transportador]", 0))
            cbo_transportador.Enabled = False

            'grid produtores/propriedades
            pessoa.id_pessoa = -1
            Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()
            Dim dr As DataRow = dspropriedades.Tables(0).NewRow()
            dspropriedades.Tables(0).Rows.InsertAt(dr, 0)
            gridPropriedades.Visible = True
            gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
            gridPropriedades.DataBind()
            gridPropriedades.Rows(0).Cells.Clear()
            gridPropriedades.Rows(0).Cells.Add(New TableCell())
            gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            gridPropriedades.Rows(0).Cells(0).ColumnSpan = 10
            gridPropriedades.Rows(0).Cells(0).Text = "Informe um produtor para visualizar suas propriedades!"

            'Carrega valores default (solicitação central)

            'Simula change do combo estabelecimento
            cbo_estabelecimento.SelectedValue = 1 'Poços
            txt_nm_fornecedor.Text = "[Filtre Nome]"
            ViewState.Item("id_fornecedor") = "0"
            txt_nm_fornecedor.Enabled = True
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

            loadComboParceiro(String.Empty)



        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub
    Private Sub loadComboItens(ByVal pFiltroNome As String)
        Try


            Dim lcboitem As String = cbo_item.SelectedValue

            cbo_item.DataSource = Nothing
            cbo_item.Items.Clear()

            Dim itemparceiro As New ItemParceiro
            itemparceiro.id_fornecedor = ViewState.Item("id_fornecedor").ToString
            itemparceiro.nm_item = pFiltroNome

            cbo_item.DataSource = itemparceiro.getCentralItemParceiro
            cbo_item.DataTextField = "ds_item"
            cbo_item.DataValueField = "id_item"
            cbo_item.DataBind()
            cbo_item.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'se nao tem filtro
            If pFiltroNome.Equals(String.Empty) Then
                If cbo_item.Items.FindByValue(lcboitem) Is Nothing Then
                    cbo_item.SelectedValue = 0
                    lbl_nm_categoria.Text = String.Empty
                    cbo_item.Focus()

                Else
                    cbo_item.SelectedValue = lcboitem

                End If
            Else
                lbl_nm_categoria.Text = String.Empty
                cbo_item.Focus()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Private Sub loadComboParceiro(ByVal pFiltroNome As String)
        Try

            Dim lbsimulaselectedcombo As Boolean = False

            Dim parceiroitem As New ItemParceiro
            parceiroitem.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
            parceiroitem.nm_pessoa = pFiltroNome
            parceiroitem.st_acordo_aquisicao_insumos = "S"

            cbo_fornecedor.DataSource = parceiroitem.getCentralParceiroComItens()
            cbo_fornecedor.DataTextField = "ds_abreviado"
            cbo_fornecedor.DataValueField = "id_fornecedor"
            cbo_fornecedor.DataBind()
            cbo_fornecedor.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ''se nao tem filtro
            'If pFiltroNome.Equals(String.Empty) Then
            '    txt_nm_fornecedor.Text = "[Filtre Nome Parceiro]"
            '    If CInt(ViewState.Item("id_fornecedor").ToString) > 0 Then
            '        cbo_fornecedor.SelectedValue = ViewState.Item("id_fornecedor").ToString
            '    Else
            '        'cbo_fornecedor.Items.Insert(0, New ListItem("[Selecione]", "0"))
            '        cbo_fornecedor.SelectedValue = "0"
            '    End If
            'Else
            '    cbo_fornecedor.Focus()
            'End If

            'se ja tinha selecionado fornecedor antes
            If CInt(ViewState.Item("id_fornecedor").ToString) > 0 Then
                'se a nova montagem de fornecedores não tem o fornecedor selecionado anteriormente
                If cbo_fornecedor.Items.FindByValue(ViewState.Item("id_fornecedor").ToString) Is Nothing Then
                    'se nao encontrou fornecedor  limpa tudo

                    'se mudar fornecedor deve limpar dados
                    'limpar dados do item
                    limpaTelaItem()

                    'limpar dados transportador
                    limpaTelaTransportador()

                    'dados fornecedeor
                    ViewState.Item("id_fornecedor") = 0
                    ViewState.Item("fornecedor_excecao_prazo") = String.Empty
                    ViewState.Item("fornecedor_cif") = String.Empty
                    ViewState.Item("fornecedor_parcelas") = String.Empty
                    lbl_frete_parceiro.Text = String.Empty
                    lbl_parcelas_parceiro.Text = String.Empty

                    'se nao tem filtro
                    If pFiltroNome.Equals(String.Empty) Then
                        'nao tem filtro de fornecedor nome assume selecione
                        cbo_fornecedor.SelectedValue = "0"
                    Else
                        'tem filtro em nome fornecedor
                        If cbo_fornecedor.Items.Count = 1 Then
                            'se so tem selecione nao encontrou nada com filtro
                            cbo_fornecedor.Items(0).Text = "[Filtro Não Encontrado]"
                        Else
                            cbo_fornecedor.Items(1).Selected = True 'assume o priemiro item apos selecione
                            lbsimulaselectedcombo = True
                        End If
                    End If

                    If lbsimulaselectedcombo = False Then
                        'limpa combo itens
                        cbo_item.Items.Clear()
                        cbo_item.Items.Insert(0, New ListItem("[Selecione um Parceiro]", "0"))
                        cbo_item.SelectedValue = 0
                        txt_nm_item.Text = "[Filtre Nome]"
                        lbl_nm_categoria.Text = String.Empty
                        txt_nm_item.Enabled = False

                    End If

                Else
                    cbo_fornecedor.SelectedValue = ViewState.Item("id_fornecedor").ToString
                End If
            Else 'nao selecionou nenhum parceiro ainda
                lbl_frete_parceiro.Text = String.Empty
                lbl_parcelas_parceiro.Text = String.Empty
                'se nao tem filtro
                If pFiltroNome.Equals(String.Empty) Then
                    'nao tem filtro de fornecedor nome assume selecione
                    cbo_fornecedor.SelectedValue = "0"
                Else
                    'tem filtro em nome fornecedor
                    If cbo_fornecedor.Items.Count = 1 Then
                        'se so tem selecione nao encontrou nada com filtro
                        cbo_fornecedor.Items(0).Text = "[Filtro Não Encontrado]"
                    Else
                        cbo_fornecedor.Items(1).Selected = True 'assume o priemiro item apos selecione
                        lbsimulaselectedcombo = True
                    End If

                End If

            End If

            If lbsimulaselectedcombo = True Then
                'simula chamada do combo

                ViewState.Item("id_fornecedor") = cbo_fornecedor.SelectedValue

                Dim parceiroitemcbo As New ItemParceiro
                parceiroitemcbo.id_fornecedor = cbo_fornecedor.SelectedValue
                parceiroitem.st_acordo_aquisicao_insumos = "S"

                Dim dsparceiro As DataSet = parceiroitemcbo.getCentralParceiroComItens

                If (dsparceiro.Tables(0).Rows.Count > 0) Then
                    With dsparceiro.Tables(0).Rows(0)
                        ViewState.Item("fornecedor_excecao_prazo") = .Item("st_excecao_prazo_pagto").ToString
                        ViewState.Item("fornecedor_cif") = .Item("st_fornecedor_cif").ToString
                        ViewState.Item("fornecedor_parcelas") = .Item("nr_fornecedor_parcelas_central").ToString
                        If .Item("st_fornecedor_cif").ToString.Equals("S") Then
                            lbl_frete_parceiro.Text = "SIM"
                        Else
                            lbl_frete_parceiro.Text = "NÃO"
                        End If
                        lbl_parcelas_parceiro.Text = .Item("nr_fornecedor_parcelas_central").ToString
                    End With
                End If

                If ViewState.Item("fornecedor_cif").ToString = "S" Then
                    cbo_tipo_frete.Items(1).Enabled = False
                    cbo_tipo_frete.Items(2).Enabled = False
                    cbo_tipo_frete.SelectedValue = String.Empty
                Else
                    cbo_tipo_frete.Items(1).Enabled = True
                    cbo_tipo_frete.Items(2).Enabled = True
                    cbo_tipo_frete.SelectedValue = String.Empty
                End If
                txt_nm_item.Text = "[Filtre Nome]"
                lbl_nm_categoria.Text = String.Empty

                loadComboItens(String.Empty)

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub
    Private Sub loadGridPropriedades()
        Try
            ViewState.Item("lbl_indexgridmatriz") = Nothing
            If (Me.hf_id_produtor.Value.Equals(String.Empty)) Then

                Dim pessoa As New Pessoa
                pessoa.id_pessoa = -1

                Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()

                Dim dr As DataRow = dspropriedades.Tables(0).NewRow()
                dspropriedades.Tables(0).Rows.InsertAt(dr, 0)
                Me.ViewState("gridpropriedadeslinhas") = 0
                Me.gridPropriedades.Visible = True
                Me.gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
                Me.gridPropriedades.DataBind()
                Me.gridPropriedades.Rows(0).Cells.Clear()
                Me.gridPropriedades.Rows(0).Cells.Add(New TableCell())
                Me.gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                Me.gridPropriedades.Rows(0).Cells(0).Text = "Selecione um produtor ativo."
                Me.gridPropriedades.Rows(0).Cells(0).ColumnSpan = 20
            Else

                If Me.lbl_acordo_aquisicao_insumos.Text = "Sim" Then

                    Dim pessoa As New Pessoa
                    pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_produtor.Value)

                    Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()
                    If (dspropriedades.Tables(0).Rows.Count <= 0) Then
                        Me.ViewState("gridpropriedadeslinhas") = 0
                        Dim dr As DataRow = dspropriedades.Tables(0).NewRow()
                        dspropriedades.Tables(0).Rows.InsertAt(dr, 0)
                        gridPropriedades.Visible = True
                        gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
                        gridPropriedades.DataBind()
                        gridPropriedades.Rows(0).Cells.Clear()
                        gridPropriedades.Rows(0).Cells.Add(New TableCell())
                        gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                        gridPropriedades.Rows(0).Cells(0).ColumnSpan = 20
                        gridPropriedades.Rows(0).Cells(0).Text = "Não foram encontradas propriedades ativas para o produtor selecionado!"
                    Else
                        lk_gerar_pedido.Enabled = True
                        'If (Not Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(DataSet.Tables(0).Rows(0)("id_propriedade_titular"), 0, False)) Then
                        '    Me.lbl_gruporelacionamento.set_Visible(True)
                        'Else
                        '    Me.lbl_gruporelacionamento.set_Visible(False)
                        'End If
                        ViewState("gridpropriedadeslinhas") = 1
                        gridPropriedades.Visible = True
                        gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
                        gridPropriedades.DataBind()
                    End If
                Else
                    'se nao tem acordo de aquisição de insumos
                    Dim pessoa As New Pessoa
                    pessoa.id_pessoa = -1

                    Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()

                    Dim dr As DataRow = dspropriedades.Tables(0).NewRow()
                    dspropriedades.Tables(0).Rows.InsertAt(dr, 0)
                    Me.ViewState("gridpropriedadeslinhas") = 0
                    Me.gridPropriedades.Visible = True
                    Me.gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
                    Me.gridPropriedades.DataBind()
                    Me.gridPropriedades.Rows(0).Cells.Clear()
                    Me.gridPropriedades.Rows(0).Cells.Add(New TableCell())
                    Me.gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    Me.gridPropriedades.Rows(0).Cells(0).Text = "Selecione um produtor que possua Acordo de Aquisição de Insumos."
                    Me.gridPropriedades.Rows(0).Cells(0).ColumnSpan = 20
                    messageControl.Alert("Selecione um produtor que possua Acordo de Aquisição de Insumos.")

                End If

            End If
            ViewState.Item("lbl_indexgridmatriz") = Nothing

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_central_pedido_abertura.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 232
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        Else
            If (Me.txt_cd_pessoa.Text.Equals(String.Empty)) Then
                Me.gridPropriedades.Rows(0).Cells.Clear()
                Me.gridPropriedades.Rows(0).Cells.Add(New TableCell())
                Me.gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                Me.gridPropriedades.Rows(0).Cells(0).Text = "Informe um produtor para visualizar suas propriedades!"
                Me.gridPropriedades.Rows(0).Cells(0).ColumnSpan = 20
            End If

            'If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
            '    gridRomaneioCompartimento.Rows(0).Cells.Clear()
            '    gridRomaneioCompartimento.Rows(0).Cells.Add(New TableCell())
            '    gridRomaneioCompartimento.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            '    gridRomaneioCompartimento.Rows(0).Cells(0).Text = "Não existe nenhuma Placa/Compartimento cadastrados!"
            '    gridRomaneioCompartimento.Rows(0).Cells(0).ColumnSpan = 7
            'End If
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
        End With

    End Sub


    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txt_cd_pessoa.TextChanged
        Me.lbl_nm_pessoa.Text = String.Empty
        Me.hf_id_produtor.Value = String.Empty
        Me.lbl_ds_telefone.Text = String.Empty
        Me.lbl_acordo_aquisicao_insumos.Text = String.Empty
        Me.lbl_cluster.Text = String.Empty
        Me.lbl_ds_email.Text = String.Empty
        Me.lbl_contrato.Text = String.Empty
        Me.lbl_dt_ini_contrato.Text = String.Empty
        Me.lbl_dt_fim_contrato.Text = String.Empty
        Me.lbl_dt_rescisao_contrato.Text = String.Empty
        gridPropriedades.SelectedIndex = -1

        'se cbo forn maior que zero e id_central_tabelpreco > 0 limpa infot, sacaria e vl unitario faz o mesmo com transportador
        If CInt(ViewState.Item("id_central_tabela_precos")) <> 0 Then
            lbl_inf_preco.Text = String.Empty
            txt_nr_valor_unitario.Text = String.Empty
            txt_nr_sacaria.Text = String.Empty
            lbl_total_item.Text = "R$ 0,00"
            lbl_valor_total.Text = String.Empty
        End If

        If CInt(ViewState.Item("id_central_tabela_frete_veiculos")) <> 0 Then
            lbl_inf_frete.Text = String.Empty
            txt_nr_frete.Text = String.Empty
            lbl_total_frete.Text = "R$ 0,00"
            lbl_valor_total.Text = String.Empty

        End If
        Try
            If (Me.txt_cd_pessoa.Text.Equals(String.Empty)) Then
                'Me.lk_gerar_pedido.Enabled = False

                Dim pessoa As New Pessoa
                pessoa.id_pessoa = -1
                Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()
                Dim dr As DataRow = dspropriedades.Tables(0).NewRow()
                dspropriedades.Tables(0).Rows.InsertAt(dr, 0)
                gridPropriedades.Visible = True
                gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
                gridPropriedades.DataBind()
                gridPropriedades.Rows(0).Cells.Clear()
                gridPropriedades.Rows(0).Cells.Add(New TableCell())
                gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridPropriedades.Rows(0).Cells(0).ColumnSpan = 10
                gridPropriedades.Rows(0).Cells(0).Text = "Informe um produtor para visualizar suas propriedades!"
            Else
                Dim pessoa As New Pessoa
                pessoa.cd_pessoa = Me.txt_cd_pessoa.Text.Trim()
                pessoa.id_situacao = 1
                pessoa.id_grupo = 1

                Dim dspessoa As DataSet = pessoa.getPessoaByFilters()
                If (dspessoa.Tables(0).Rows.Count <= 0) Then
                    Me.lbl_nm_pessoa.Enabled = True
                    Me.lbl_nm_pessoa.Text = "Produtor não encontrado!"
                    Me.lk_gerar_pedido.Enabled = False

                    pessoa.id_pessoa = -1
                    Dim dspropriedades As DataSet = pessoa.getPropriedadesProdutoresEGrupo()
                    Dim dr As DataRow = dspropriedades.Tables(0).NewRow()
                    dspropriedades.Tables(0).Rows.InsertAt(dr, 0)
                    gridPropriedades.DataSource = Helper.getDataView(dspropriedades.Tables(0), "")
                    gridPropriedades.DataBind()
                    Me.gridPropriedades.Rows(0).Cells.Clear()
                    Me.gridPropriedades.Rows(0).Cells.Add(New TableCell())
                    Me.gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    Me.gridPropriedades.Rows(0).Cells(0).Text = "Informe um produtor para visualizar suas propriedades!"
                    Me.gridPropriedades.Rows(0).Cells(0).ColumnSpan = 10
                Else
                    Me.lbl_nm_pessoa.Enabled = True
                    Me.lbl_nm_pessoa.Text = dspessoa.Tables(0).Rows(0)("nm_pessoa").ToString
                    Me.hf_id_produtor.Value = dspessoa.Tables(0).Rows(0)("id_pessoa").ToString
                    Me.loadDadosProdutor(Convert.ToInt32(Me.hf_id_produtor.Value))
                End If
            End If
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try
    End Sub


    ' Private Function ValidarItensFornecedores(ByRef lmsg As String) As Boolean
    '     Dim flag As Boolean = False
    '     Dim enumerator As IEnumerator = Nothing
    '     Dim enumerator1 As IEnumerator = Nothing
    '     Try
    '         Dim cotacaoItem As Danone.MilkSystem.Business.CotacaoItem = New Danone.MilkSystem.Business.CotacaoItem()
    '         Dim cotacaoFornecedor As Danone.MilkSystem.Business.CotacaoFornecedor = New Danone.MilkSystem.Business.CotacaoFornecedor()
    '         cotacaoItem.id_central_cotacao = Convert.ToInt32(Me.ViewState("id_central_cotacao").ToString())
    '         Dim cotacaoItensByFilters As DataSet = cotacaoItem.getCotacaoItensByFilters()
    '         Dim flag1 As Boolean = False
    '         Dim parametro As Danone.MilkSystem.Business.Parametro = New Danone.MilkSystem.Business.Parametro()
    '         Dim flag2 As Boolean = True
    '         Try
    '             enumerator = cotacaoItensByFilters.Tables(0).Rows.GetEnumerator()
    '             While enumerator.MoveNext()
    '                 Dim current As System.Data.DataRow = DirectCast(enumerator.Current, System.Data.DataRow)
    '                 If (Not Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current("st_ver_mercado"), "N", False)) Then
    '                     Continue While
    '                 End If
    '                 flag1 = True
    '                 If (Conversions.ToDouble(current("nr_quantidade")) <> 0) Then
    '                     cotacaoFornecedor.id_central_cotacao_item = Convert.ToInt32(RuntimeHelpers.GetObjectValue(current("id_central_cotacao_item")))
    '                     Dim cotacaoFornecedorByFilters As DataSet = cotacaoFornecedor.getCotacaoFornecedorByFilters()
    '                     Try
    '                         enumerator1 = cotacaoFornecedorByFilters.Tables(0).Rows.GetEnumerator()
    '                         While enumerator1.MoveNext()
    '                             Dim dataRow As System.Data.DataRow = DirectCast(enumerator1.Current, System.Data.DataRow)
    '                             If (Conversions.ToDouble(dataRow("nr_valor_unitario")) > 0) Then
    '                                 Continue While
    '                             End If
    '                             flag2 = False
    '                             lmsg = String.Concat("Há cotações para o item ", current("nm_item").ToString(), " cujo cadastro está incompleto!")
    '                             Exit While
    '                         End While
    '                     Finally
    '                         If (TypeOf enumerator1 Is IDisposable) Then
    '                             TryCast(enumerator1, IDisposable).Dispose()
    '                         End If
    '                     End Try
    '                     If (flag2) Then
    '                         If (Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current("st_parcelamento"), "D", False) AndAlso parametro.nr_politica_parcelas < Conversions.ToInteger(current("nr_parcelas").ToString())) Then
    '                             flag2 = False
    '                             lmsg = String.Concat("O número de parcelas informado para o item ", current("nm_item").ToString(), ", execede o limite cadastrado para Política de Parcelas em Parâmetros do Sistema.")
    '                         End If
    '                         cotacaoFornecedor.st_selecionado = "S"
    '                         cotacaoFornecedor.st_ver_mercado = "N"
    '                         If (cotacaoFornecedor.getCotacaoFornecedorByFilters().Tables(0).Rows.Count <> 0) Then
    '                             Continue While
    '                         End If
    '                         flag2 = False
    '                         lmsg = String.Concat("Não há cotação selecionada para o item ", current("nm_item").ToString(), ".")
    '                         Exit While
    '                     Else
    '                         Exit While
    '                     End If
    '                 Else
    '                     flag2 = False
    '                     lmsg = "Há itens da cotação cujo cadastro está incompleto!"
    '                     Exit While
    '                 End If
    '             End While
    '         Finally
    '             If (TypeOf enumerator Is IDisposable) Then
    '                 TryCast(enumerator, IDisposable).Dispose()
    '             End If
    '         End Try
    '         If (Not flag1) Then
    '             flag2 = False
    '             lmsg = "Todos os itens desta cotação são do tipo 'Ver Mercado'. Este tipo de cotação não pode gerar aprovação ou pedido."
    '         End If
    'flag = If(Not flag2, False, True)
    '     Catch exception As System.Exception
    '         ProjectData.SetProjectError(exception)
    '         Me.messageControl.Alert(exception.Message)
    '         ProjectData.ClearProjectError()
    '     End Try
    '     Return flag
    ' End Function

    Private Function VerificarCotacao() As Boolean
        Dim flag As Boolean = False
        Dim str As String = Nothing
        Dim enumerator As IEnumerator = Nothing
        Dim enumerator1 As IEnumerator = Nothing
        Try
            Dim cotacaoItem As Danone.MilkSystem.Business.CotacaoItem = New Danone.MilkSystem.Business.CotacaoItem()
            Dim cotacaoFornecedor As Danone.MilkSystem.Business.CotacaoFornecedor = New Danone.MilkSystem.Business.CotacaoFornecedor()
            Dim cotacaoItensByFilters As DataSet = cotacaoItem.getCotacaoItensByFilters()
            Dim flag1 As Boolean = True
            Try
                enumerator = cotacaoItensByFilters.Tables(0).Rows.GetEnumerator()
                While enumerator.MoveNext()
                    Dim current As System.Data.DataRow = DirectCast(enumerator.Current, System.Data.DataRow)
                    If (Not Microsoft.VisualBasic.CompilerServices.Operators.ConditionalCompareObjectEqual(current("st_ver_mercado"), "N", False)) Then
                        Continue While
                    End If
                    If (Convert.ToDouble(current("nr_quantidade")) <> 0) Then
                        cotacaoFornecedor.id_central_cotacao_item = Convert.ToInt32((current("id_central_cotacao_item")))
                        Dim cotacaoFornecedorByFilters As DataSet = cotacaoFornecedor.getCotacaoFornecedorByFilters()
                        Try
                            enumerator1 = cotacaoFornecedorByFilters.Tables(0).Rows.GetEnumerator()
                            While enumerator1.MoveNext()
                                Dim dataRow As System.Data.DataRow = DirectCast(enumerator1.Current, System.Data.DataRow)
                                If (Convert.ToDouble(dataRow("nr_valor_unitario")) > 0) Then
                                    Continue While
                                End If
                                flag1 = False
                                str = String.Concat("Há cotações para o item ", current("nm_item").ToString(), " cujo cadastro está incompleto!")
                                Exit While
                            End While
                        Finally
                            If (TypeOf enumerator1 Is IDisposable) Then
                                TryCast(enumerator1, IDisposable).Dispose()
                            End If
                        End Try
                        If (flag1) Then
                            cotacaoFornecedor.st_selecionado = "S"
                            cotacaoFornecedor.st_ver_mercado = "N"
                            If (cotacaoFornecedor.getCotacaoFornecedorByFilters().Tables(0).Rows.Count <> 0) Then
                                Continue While
                            End If
                            flag1 = False
                            str = String.Concat("Não há cotação selecionada para o item ", current("nm_item").ToString(), ".")
                            Exit While
                        Else
                            Exit While
                        End If
                    Else
                        flag1 = False
                        str = "Há itens da cotação cujo cadastro está incompleto!"
                        Exit While
                    End If
                End While
            Finally
                If (TypeOf enumerator Is IDisposable) Then
                    TryCast(enumerator, IDisposable).Dispose()
                End If
            End Try
            If (flag1) Then
                flag = True
            Else
                flag = False
                Me.messageControl.Alert(str)
            End If
        Catch exception As System.Exception
            Me.messageControl.Alert(exception.Message)
        End Try
        Return flag
    End Function
    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs) Handles btn_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        Me.carregarCamposProdutor()
    End Sub


    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        Try
            txt_nm_fornecedor.Text = "[Filtre Nome]"
            ViewState.Item("id_fornecedor") = "0"

            If cbo_estabelecimento.SelectedValue > 0 Then
                txt_nm_fornecedor.Enabled = True
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                loadComboParceiro(String.Empty)
            Else
                ViewState.Item("id_estabelecimento") = "0"
                cbo_fornecedor.Items.Clear()
                cbo_fornecedor.Items.Insert(0, New ListItem("[Selecione um Estabelecimento]", "0"))
                cbo_fornecedor.SelectedValue = 0
                txt_nm_fornecedor.Enabled = False

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub cbo_fornecedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_fornecedor.SelectedIndexChanged
        Try

            'se mudar fornecedor deve limpar dados
            'limpar dados do item
            limpaTelaItem()

            'limpar dados transportador
            limpaTelaTransportador()

            ViewState.Item("id_fornecedor") = "0"

            If cbo_fornecedor.SelectedValue > 0 Then

                'txt_nm_fornecedor.Text = String.Empty
                'loadComboParceiro(String.Empty, cbo_fornecedor.SelectedValue)

                ViewState.Item("id_fornecedor") = cbo_fornecedor.SelectedValue

                Dim parceiroitem As New ItemParceiro
                parceiroitem.id_fornecedor = cbo_fornecedor.SelectedValue
                parceiroitem.st_acordo_aquisicao_insumos = "S"

                Dim dsparceiro As DataSet = parceiroitem.getCentralParceiroComItens

                If (dsparceiro.Tables(0).Rows.Count > 0) Then
                    With dsparceiro.Tables(0).Rows(0)
                        ViewState.Item("fornecedor_excecao_prazo") = .Item("st_excecao_prazo_pagto").ToString
                        ViewState.Item("fornecedor_cif") = .Item("st_fornecedor_cif").ToString
                        ViewState.Item("fornecedor_parcelas") = .Item("nr_fornecedor_parcelas_central").ToString
                        If .Item("st_fornecedor_cif").ToString.Equals("S") Then
                            lbl_frete_parceiro.Text = "SIM"
                        Else
                            lbl_frete_parceiro.Text = "NÃO"
                        End If
                        lbl_parcelas_parceiro.Text = .Item("nr_fornecedor_parcelas_central").ToString
                    End With
                End If

                If ViewState.Item("fornecedor_cif").ToString = "S" Then
                    cbo_tipo_frete.Items(1).Enabled = False
                    cbo_tipo_frete.Items(2).Enabled = False
                    cbo_tipo_frete.SelectedValue = "C"
                    cbo_tipo_frete.Enabled = False
                Else
                    cbo_tipo_frete.Enabled = True
                    cbo_tipo_frete.Items(1).Enabled = True
                    cbo_tipo_frete.Items(2).Enabled = True
                    cbo_tipo_frete.SelectedValue = String.Empty
                End If

                txt_nm_item.Text = "[Filtre Nome]"
                lbl_nm_categoria.Text = String.Empty
                txt_nm_item.Enabled = True

                loadComboItens(String.Empty)
            Else
                ViewState.Item("fornecedor_excecao_prazo") = String.Empty
                ViewState.Item("fornecedor_cif") = String.Empty
                ViewState.Item("fornecedor_parcelas") = String.Empty
                lbl_frete_parceiro.Text = String.Empty
                lbl_parcelas_parceiro.Text = String.Empty

                cbo_item.Items.Clear()
                cbo_item.Items.Insert(0, New ListItem("[Selecione um Parceiro]", "0"))
                cbo_item.SelectedValue = 0
                txt_nm_item.Text = "[Filtre Nome]"
                lbl_nm_categoria.Text = String.Empty
                txt_nm_item.Enabled = False

                'loadComboParceiro(String.Empty)
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub txt_nm_fornecedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nm_fornecedor.TextChanged
        Try
            'If cbo_estabelecimento.SelectedValue > 0 Then
            '    loadComboParceiro(txt_nm_fornecedor.Text)
            'Else
            '    txt_nm_fornecedor.Text = "[Filtre Nome Parceiro]"
            'End If
            If cbo_estabelecimento.SelectedValue = 0 Then
                txt_nm_fornecedor.Text = "[Filtre Nome]"
            Else
                If txt_nm_fornecedor.Text.Trim = String.Empty Then
                    txt_nm_fornecedor.Text = "[Filtre Nome]"
                    loadComboParceiro(String.Empty)
                Else
                    loadComboParceiro(txt_nm_fornecedor.Text)

                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub txt_nm_item_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nm_item.TextChanged
        Try
            If ViewState.Item("id_fornecedor") > 0 Then
                If txt_nm_item.Text.Trim = String.Empty Then
                    txt_nm_item.Text = "[Filtre Nome]"
                    loadComboItens(String.Empty)
                Else
                    loadComboItens(txt_nm_item.Text)
                End If
            Else
                txt_nm_item.Text = "[Filtre Nome]"
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub cbo_item_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_item.SelectedIndexChanged


        Try
            limpaTelaItem()

            If cbo_tipo_frete.SelectedValue = "D" And CInt(ViewState.Item("id_central_tabela_frete_veiculos")) > 0 Then
                'limpaTelaTransportador()
                'If cbo_pedido_indireto.SelectedValue = "N" Then
                '    cbo_transportador.Enabled = True
                '    cbo_transportador.Items.FindByValue("0").Text = "[Selecione]"

                'End If
                txt_nr_frete.Text = String.Empty
                lbl_inf_frete.Text = String.Empty
                lbl_total_frete.Text = "R$ 0,00"
                ViewState.Item("id_central_tabela_frete_veiculos") = 0
                ViewState.Item("id_veiculo_central_compras") = 0

                lbl_detalhe_item_frete.Text = String.Empty
                gridfrete.Visible = False
                ViewState.Item("id_index_item_frete") = String.Empty
                pnl_frete.Visible = False

            End If

            If CInt(cbo_item.SelectedValue) > 0 Then

                Dim item As New Item
                item.id_item = cbo_item.SelectedValue

                Dim dsitem As DataSet = item.getItensCentralByFilters

                If (dsitem.Tables(0).Rows.Count > 0) Then
                    With dsitem.Tables(0).Rows(0)
                        lbl_nm_categoria.Text = .Item("nm_categoria_item").ToString
                        lbl_nm_categoria_tit.Visible = True
                        ViewState.Item("id_categoria_item") = .Item("id_categoria_item").ToString
                    End With
                End If

                cbo_tipo_medida.Enabled = True
                txt_nr_qtde.Enabled = True
                txt_nr_valor_unitario.Enabled = True
                txt_nr_sacaria.Enabled = True

                'If cbo_tipo_frete.SelectedValue = "D" AndAlso cbo_pedido_indireto.SelectedValue = "N" Then
                '    cbo_transportador.Enabled = True
                '    cbo_transportador.Items.FindByValue("0").Text = "[Selecione]"

                'End If

                If cbo_fornecedor.SelectedValue > 0 AndAlso CInt(ViewState.Item("id_propriedade")) > 0 Then
                    'para item novo busca valor tabela de preço, ultimo ativo
                    atualizarTabelaPrecos()

                End If
            Else
                lbl_nm_categoria.Text = String.Empty
                lbl_nm_categoria_tit.Visible = False
                ViewState.Item("id_categoria_item") = "0"
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub



    Private Sub atualizarTabelaPrecos()

        'para item novo busca valor tabela de preço, ultimo ativo
        Dim preco As New TabelaPrecos
        preco.id_estabelecimento = Convert.ToInt32(Me.cbo_estabelecimento.SelectedValue)
        preco.id_fornecedor = cbo_fornecedor.SelectedValue
        preco.id_item = cbo_item.SelectedValue
        preco.id_estado_propriedade = Me.ViewState.Item("id_estado_destino")
        preco.id_cidade_propriedade = Me.ViewState.Item("id_cidade_destino")

        Dim dsprecomax As DataSet = preco.getCentralTabelaPrecosMax()
        If (dsprecomax.Tables(0).Rows.Count > 0) Then
            With dsprecomax.Tables(0).Rows(0)
                txt_nr_valor_unitario.Text = .Item("nr_valor")
                txt_nr_sacaria.Text = .Item("nr_valor_sacaria")
                ViewState.Item("id_central_tabela_precos") = .Item("id_central_tabela_precos")
                lbl_inf_preco.Text = String.Concat("Informativo: Tabela de Preço encontrada com Data de cotação em ", DateTime.Parse(.Item("dt_cotacao").ToString).ToString("dd/MM/yyyy"), ".")
                'rownova(18) = .Item("nr_valor")
                'rownova(19) = .Item("nr_valor_sacaria")
                'rownova(20) = DateTime.Parse(.Item("dt_cotacao").ToString).ToString("dd/MM/yyyy")
            End With

        Else
            txt_nr_valor_unitario.Text = String.Empty
            txt_nr_sacaria.Text = String.Empty
            ViewState.Item("id_central_tabela_precos") = 0
            lbl_inf_preco.Text = String.Empty

        End If

        atualizarTotalizadores()


    End Sub
    Private Sub atualizarTotalizadores()

        Try
            Dim laux As Decimal = 0

            If cbo_tipo_medida.SelectedValue = "S" Then
                If txt_nr_sacaria.Text = String.Empty Then
                    laux = 0
                Else
                    laux = CDec(txt_nr_sacaria.Text)
                End If
            Else
                laux = 0
            End If

            'se tem quantidade e valor unitario
            If Not txt_nr_qtde.Text.Equals(String.Empty) AndAlso Not txt_nr_valor_unitario.Text.Equals(String.Empty) Then
                lbl_total_item.Text = FormatCurrency(((CDec(txt_nr_valor_unitario.Text) + laux) * CDec(txt_nr_qtde.Text)).ToString, 2).ToString()
            Else
                lbl_total_item.Text = FormatCurrency("0", 2)
            End If
            lbl_valor_total.Text = lbl_total_item.Text

            If cbo_tipo_frete.SelectedValue = "D" Then 'se for fob d
                'se tem quantidade e valor frete
                If Not txt_nr_qtde.Text.Equals(String.Empty) AndAlso Not txt_nr_frete.Text.Equals(String.Empty) Then
                    lbl_total_frete.Text = FormatCurrency((CDec(txt_nr_frete.Text) * CDec(txt_nr_qtde.Text)).ToString, 2).ToString()
                Else
                    lbl_total_frete.Text = FormatCurrency("0", 2)
                End If

                lbl_valor_total.Text = FormatCurrency((CDec(lbl_valor_total.Text) + CDec(lbl_total_frete.Text)).ToString, 2).ToString
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_frete_valor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_frete_valor.Click

        pnl_frete.Visible = False

        If cbo_transportador.SelectedValue = "0" Then
            Me.messageControl.Alert("Transportador deve ser selecionado para a busca da tabela de fretes.")
        Else
            If ViewState.Item("id_propriedade").ToString.Equals("0") Then
                Me.messageControl.Alert("A propriedade deve ser informada para a busca da tabela de fretes.")
            Else

                Dim tabfrete As New TabelaFrete
                tabfrete.id_estabelecimento = ViewState.Item("id_estabelecimento")
                tabfrete.id_fornecedor = cbo_transportador.SelectedValue
                tabfrete.id_item = cbo_item.SelectedValue
                tabfrete.id_estado_propriedade = ViewState.Item("id_estado_destino")
                tabfrete.id_cidade_propriedade = ViewState.Item("id_cidade_destino")

                Dim dsfrete As DataSet = tabfrete.getCentralTabelaFreteMax()
                If (dsfrete.Tables(0).Rows.Count <= 0) Then
                    Me.messageControl.Alert("Não foram encontrados valores de frete ativos para o Transportador, item e cidade destino da propriedade!")
                    'ViewState.Item("id_index_item_frete") = Nothing
                    gridfrete.Visible = False
                    'Dim dr As DataRow = dsfrete.Tables(0).NewRow()
                    'dsfrete.Tables(0).Rows.InsertAt(dr, 0)
                    'gridfrete.Visible = True
                    'gridfrete.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                    'gridfrete.DataBind()
                    'gridfrete.Rows(0).Cells.Clear()
                    'gridfrete.Rows(0).Cells.Add(New TableCell())
                    'gridfrete.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    'gridfrete.Rows(0).Cells(0).ColumnSpan = 10
                    'gridfrete.Rows(0).Cells(0).Text = "Não foram encontrados valores de frete ativos para o Transportador, item e cidade destino da propriedade!"
                Else
                    'ViewState.Item("id_index_item_frete") = row.RowIndex
                    pnl_frete.Visible = True
                    lbl_detalhe_item_frete.Text = String.Concat("Frete para o ITEM ", cbo_item.SelectedItem.Text)

                    gridfrete.Visible = True
                    gridfrete.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                    gridfrete.DataBind()
                End If

            End If

        End If
    End Sub

    Protected Sub txt_nr_valor_unitario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nr_valor_unitario.TextChanged

        lbl_inf_preco.Text = String.Empty
        ViewState.Item("id_central_tabela_precos") = 0
        atualizarTotalizadores()
    End Sub


    Protected Sub cbo_vai_parcelar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_vai_parcelar.SelectedIndexChanged

        'Select Case cbo_vai_parcelar.SelectedValue

        '    Case "N"
        '        txt_nr_parcelas.Enabled = False
        '        txt_nr_parcelas.Text = 1
        '        rfv_nr_parcelas.Enabled = False
        '        rv_parcelas.Enabled = False
        '        cv_nr_parcelas.Enabled = False

        '    Case "P"
        '        txt_nr_parcelas.Text = String.Empty
        '        txt_nr_parcelas.Enabled = True
        '        rfv_nr_parcelas.Enabled = True
        '        cv_nr_parcelas.Enabled = True
        '        rv_parcelas.Enabled = False

        '    Case "D"
        '        txt_nr_parcelas.Enabled = True
        '        rfv_nr_parcelas.Enabled = True
        '        cv_nr_parcelas.Enabled = True
        '        txt_nr_parcelas.Text = String.Empty
        '        rv_parcelas.Enabled = True
        '        rv_parcelas.MaximumValue = Me.ViewState("nr_politica_parcelas").ToString()
        '        rv_parcelas.ErrorMessage = String.Concat("Para tipo de Pagamento 'Danone' o parcelamento deve ser no máximo de ", Me.ViewState("nr_politica_parcelas").ToString(), " parcelas, de acordo com a Política de Parcelas.")
        '        rv_parcelas.ToolTip = String.Concat("Para tipo de Pagamento 'Danone' o parcelamento deve ser no máximo de ", Me.ViewState("nr_politica_parcelas").ToString(), " parcelas, de acordo com a Política de Parcelas.")

        'End Select

        Select Case cbo_vai_parcelar.SelectedValue

            Case "N"
                txt_nr_parcelas.Enabled = False
                txt_nr_parcelas.Text = 1
                lbl_informativo_3.Text = String.Empty

            Case "P"
                txt_nr_parcelas.Text = String.Empty
                txt_nr_parcelas.Enabled = True
                lbl_informativo_3.Text = String.Empty
                'cv_nr_parcelas.ValueToCompare = 1
                'cv_nr_parcelas.Text = "O número de parcelas deve ser maior que um (1)!"
                'cv_nr_parcelas.ToolTip = "O número de parcelas deve ser maior que um (1)!"


            Case "D"
                txt_nr_parcelas.Enabled = True
                txt_nr_parcelas.Text = String.Empty
                'cv_nr_parcelas.ValueToCompare = 1
                'cv_nr_parcelas.Text = "O número de parcelas deve ser maior que um (1)!"
                'cv_nr_parcelas.ToolTip = "O número de parcelas deve ser maior que um (1)!"
                lbl_informativo_3.Text = String.Concat("Informativo: Política de Parcelamento Danone: máximo de ", Me.ViewState("nr_politica_parcelas").ToString(), " parcelas.")

        End Select

    End Sub



    Protected Sub img_selecionar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)


        Dim tabelafrete As New TabelaFreteVeiculos
        tabelafrete.id_central_tabela_frete_veiculos = gridfrete.DataKeys(row.RowIndex).Value.ToString()

        Dim dsfrete As DataSet = tabelafrete.getCentralTabelaFreteVeiculos
        With dsfrete.Tables(0).Rows(0)
            txt_nr_frete.Text = .Item("nr_valor_frete").ToString
            'lbl_inf_frete.Text = String.Concat("(Data cotação: ", DateTime.Parse(.Item("dt_modificacao").ToString).ToString("dd/MM/yyyy"), ")")
            lbl_inf_frete.Text = String.Concat("Cotação em ", DateTime.Parse(.Item("dt_modificacao").ToString).ToString("dd/MM/yyyy"), ".")
            ViewState.Item("id_central_tabela_frete_veiculos") = .Item("id_central_tabela_frete_veiculos").ToString
            ViewState.Item("id_veiculo_central_compras") = .Item("id_veiculocentralcompras").ToString
        End With

        gridfrete.Visible = False
        pnl_frete.Visible = False

    End Sub

    Protected Sub btn_fechar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_fechar.Click
        gridfrete.Visible = False
        Me.pnl_frete.Visible = False


    End Sub

    Protected Sub cv_pedido_itens_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pedido_itens.ServerValidate
        Try
            args.IsValid = True

            Dim lmsg As String
            Dim row As GridViewRow

            'If cbo_vai_parcelar.SelectedValue = "D" AndAlso CInt(ViewState.Item("nr_politica_parcelas")) < txt_nr_parcelas.Text Then
            '    lmsg = String.Concat("O número de parcelas informado para o pedido execede o limite cadastrado para Política de Parcelas em Parâmetros do Sistema.")
            '    args.IsValid = False
            'End If

            If ViewState.Item("id_fornecedor").ToString.Trim = "0" Then
                args.IsValid = False
                lmsg = "O parceiro deve ser informado para prosseguir com a inclusão do pedido."
            Else
                If cbo_tipo_frete.SelectedValue.Equals(String.Empty) Then
                    args.IsValid = False
                    lmsg = "O Tipo do Frete deve ser informado para prosseguir com a inclusão do pedido."
                Else

                    If ViewState.Item("id_produtor").ToString = "0" Then
                        args.IsValid = False
                        lmsg = "O Produtor deve ser informado para prosseguir com a inclusão do pedido."
                    End If
                End If
            End If

            If ViewState.Item("id_propriedade").ToString.Trim = "0" Then
                args.IsValid = False
                lmsg = "A propriedade deve ser selecionada para prosseguir com a inclusão do pedido."
            End If


            If cbo_item.SelectedValue = 0 Then
                lmsg = "Selecione item ao pedido para prosseguir com a inclusão do pedido."
                args.IsValid = False
            End If

            If args.IsValid = True Then

                'verifica se o item esta associado ao parceiro
                Dim itemparceiro As New ItemParceiro
                itemparceiro.id_item = cbo_item.SelectedValue
                itemparceiro.id_fornecedor = ViewState.Item("id_fornecedor")

                If itemparceiro.getCentralItemParceiro.Tables(0).Rows.Count = 0 Then
                    lmsg = "O Fornecedor informado não está associado ao Item " + cbo_item.SelectedItem.Text + "."
                    args.IsValid = False
                End If

                If cbo_tipo_frete.SelectedValue = "D" Then 'se for fob-d tem frete
                    If cbo_transportador.SelectedValue = 0 Then
                        lmsg = "O Transportador deve ser informado para o tipo de frete FOB-D " + " do Item " + cbo_item.SelectedItem.Text + "."
                        args.IsValid = False
                    End If

                    If txt_nr_frete.Text.Equals(String.Empty) OrElse CDec(txt_nr_frete.Text) = 0 Then
                        lmsg = "O Valor do Frete deve ser informado para o tipo de frete FOB-D " + " do Item " + cbo_item.SelectedItem.Text + "."
                        args.IsValid = False
                    End If
                End If
                If cbo_tipo_medida.SelectedValue = "S" Then
                    If txt_nr_sacaria.Text.Equals(String.Empty) Then
                        lmsg = "O valor da Sacaria deve ser informado para Embalagem Sacaria " + " do Item " + cbo_item.SelectedItem.Text + "."
                        args.IsValid = False
                    End If

                End If
                If txt_nr_qtde.Text.Equals(String.Empty) OrElse CDec(txt_nr_qtde.Text) = 0 Then
                    lmsg = "A quantidade deve ser informada para o Item " + cbo_item.SelectedItem.Text + "."
                    args.IsValid = False
                End If
                If txt_nr_valor_unitario.Text.Equals(String.Empty) OrElse CDec(txt_nr_valor_unitario.Text) = 0 Then
                    lmsg = "O valor unitário deve ser informado para o Item " + cbo_item.SelectedItem.Text + "."
                    args.IsValid = False
                End If


            End If
            If args.IsValid = False Then
                Me.messageControl.Alert(lmsg)
            Else

                'se nao tem erro atuliza limite
                Dim saldoDisponivel As New SaldoDisponivel()
                saldoDisponivel.dt_referencia = String.Concat("01/", DateTime.Now.ToString("MM/yyyy")).ToString
                If Not ViewState.Item("id_propriedade_matriz").ToString.Equals(String.Empty) AndAlso Not ViewState.Item("id_propriedade_matriz").ToString.Equals("0") Then
                    saldoDisponivel.id_propriedade = ViewState.Item("id_propriedade_matriz").ToString
                Else
                    saldoDisponivel.id_propriedade = ViewState.Item("id_propriedade").ToString
                End If

                Dim dslimite As DataSet = saldoDisponivel.getSaldoDisponivelPropriedadeEMatriz
                If dslimite.Tables(0).Rows.Count > 0 Then
                    With dslimite.Tables(0).Rows(0)
                        CType(gridPropriedades.Rows(ViewState.Item("indexgridpropriedadeprincipal").ToString).FindControl("lbl_nr_valor_disponivel"), Anthem.Label).Text = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                        CType(gridPropriedades.Rows(ViewState.Item("indexgridpropriedadeprincipal").ToString).FindControl("lbl_nr_limite_mes_bruto"), Anthem.Label).Text = FormatNumber(.Item("nr_limite_mes_bruto").ToString, 2).ToString
                        CType(gridPropriedades.Rows(ViewState.Item("indexgridpropriedadeprincipal").ToString).FindControl("lbl_nr_valor_desconto"), Anthem.Label).Text = FormatNumber(.Item("nr_valor_desconto").ToString, 2).ToString
                    End With
                Else
                    'se nao tem faturamento na ficha do mes anterior, busca do projetado na ficha custo financeiro
                    Dim dslimitecusto As DataSet = saldoDisponivel.getSaldoDisponivelFichaCustoPropriedadeEMatriz
                    If dslimitecusto.Tables(0).Rows.Count > 0 Then
                        With dslimitecusto.Tables(0).Rows(0)
                            CType(gridPropriedades.Rows(ViewState.Item("indexgridpropriedadeprincipal").ToString).FindControl("lbl_nr_valor_disponivel"), Anthem.Label).Text = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                            CType(gridPropriedades.Rows(ViewState.Item("indexgridpropriedadeprincipal").ToString).FindControl("lbl_nr_limite_mes_bruto"), Anthem.Label).Text = FormatNumber(.Item("nr_limite_mes_bruto").ToString, 2).ToString
                            CType(gridPropriedades.Rows(ViewState.Item("indexgridpropriedadeprincipal").ToString).FindControl("lbl_nr_valor_desconto"), Anthem.Label).Text = FormatNumber(.Item("nr_valor_desconto").ToString, 2).ToString
                        End With
                    End If
                End If
                ViewState.Item("limitedisponivel") = CType(gridPropriedades.Rows(ViewState.Item("indexgridpropriedadeprincipal").ToString).FindControl("lbl_nr_valor_disponivel"), Anthem.Label).Text
                If ViewState.Item("limitedisponivel").ToString.Equals(String.Empty) Then
                    ViewState.Item("limitedisponivel") = "0"
                Else
                    ViewState.Item("limitedisponivel") = CDec(ViewState.Item("limitedisponivel").ToString)
                End If

            End If
            'Dim pedido As New Pedido
            'Dim ldtprimparcelaprodutor As String = String.Empty
            'Dim ldtultparcelaprodutor As String = String.Empty
            'Dim lmotivo As String
            'pedido.calcularDataDescontoProdutor(DateTime.Now.ToString("dd/MM/yyyy"), 3, ldtprimparcelaprodutor, ldtultparcelaprodutor)
            'pedido.id_situacao_pedido = pedido.apurarSituacaoAprovacao(1, Convert.ToDecimal(ViewState.Item("limitedisponivel").ToString), cbo_vai_parcelar.SelectedValue, 3, lbl_dt_fim_contrato.Text, ldtultparcelaprodutor, lmotivo)

            'Label1.Text = String.Concat("pedidomatriz ", ViewState.Item("id_central_pedido_matriz"), "*", cbo_tipo_caminhao.SelectedValue, "*", cbo_estabelecimento.SelectedValue, "*item ", cbo_item.SelectedValue, "*categoria ", ViewState.Item("id_categoria_item").ToString, "*tipomedida ", cbo_tipo_medida.SelectedValue, "*qtde ", CDec(txt_nr_qtde.Text))
            'Label1.Text = String.Concat(Label1.Text, "*valorunit ", CDec(txt_nr_valor_unitario.Text), "*labelpreco ", lbl_inf_preco.Text, "*transp ", cbo_transportador.SelectedValue)
            'Label1.Text = String.Concat(Label1.Text, "*datetime ", DateTime.Now.ToString("dd/MM/yyyy"), "*dt1parc ", ldtprimparcelaprodutor, "*dtultparc ", ldtultparcelaprodutor, "*situacao", pedido.id_situacao_pedido, "*", lmotivo)
            'Label1.Text = String.Concat(Label1.Text, "*prop*matriz*forn*parc*limite* ", ViewState.Item("id_propriedade").ToString, "*", ViewState.Item("id_propriedade_matriz").ToString, "*", ViewState.Item("id_fornecedor").ToString, "*", txt_nr_parcelas.Text, "*", Convert.ToDecimal(ViewState.Item("limitedisponivel").ToString))
            'args.IsValid = False
            'lmsg = "teste"

            'If args.IsValid = False Then
            '    Me.messageControl.Alert(lmsg)
            'End If

            'pedido.id_estabelecimento = cbo_estabelecimento.SelectedValue
            'pedido.id_propriedade = ViewState.Item("id_propriedade").ToString
            'pedido.id_propriedade_matriz = ViewState.Item("id_propriedade_matriz").ToString
            'pedido.id_fornecedor = ViewState.Item("id_fornecedor").ToString
            'pedido.st_tipo_parcelamento = cbo_vai_parcelar.SelectedValue
            'If cbo_vai_parcelar.SelectedValue = "N" Then
            '    pedido.nr_qtde_parcelas = 1
            'Else
            '    pedido.nr_qtde_parcelas = txt_nr_parcelas.Text
            'End If
            'pedido.ds_tipofrete = cbo_tipo_frete.SelectedValue
            'pedido.ds_inclusao_pedido = "M"
            'pedido.st_pedido_indireto = cbo_pedido_indireto.SelectedValue
            'If chk_compras_evento.Checked = True Then
            '    pedido.st_evento_compras = "S"
            'Else
            '    pedido.st_evento_compras = "N"
            'End If
            'pedido.nr_total_pedido = lvalortotalpedidofornecedor
            'pedido.nr_total_pedido_frete = lvalortotalpedidotransortador
            'pedido.nr_valor_limite_disponivel = Convert.ToDecimal(ViewState.Item("limitedisponivel").ToString)
            'pedido.id_transportador = dstable.Rows(0).Item(8)
            'pedido.id_veiculo_central_compras_propriedade = cbo_tipo_caminhao.SelectedValue

            'pedido.calcularDataDescontoProdutor(DateTime.Now.ToString("dd/MM/yyyy"), pedido.nr_qtde_parcelas, ldtprimparcelaprodutor, ldtultparcelaprodutor)


            'dstable.Rows.Item(0).Item(13) = pedido.ds_motivo_aprovacao.ToString
            'pedido.pedidoitens = dstable


        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_nr_frete_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nr_frete.TextChanged

        'limpa o que veio da lupa
        lbl_inf_frete.Text = String.Empty
        ViewState.Item("id_central_tabela_frete_veiculos") = 0
        ViewState.Item("id_veiculo_central_compras") = 0

        atualizarTotalizadores()

    End Sub

    Protected Sub cbo_transportador_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_transportador.SelectedIndexChanged

        Dim lcbo As Int16 = cbo_transportador.SelectedValue

        limpaTelaTransportador()
        cbo_transportador.Enabled = True
        txt_nr_frete.Enabled = True
        cbo_transportador.SelectedValue = lcbo
        lbl_valor_total.Text = lbl_total_item.Text
        lbl_total_frete.Text = String.Empty
        If CInt(cbo_transportador.SelectedValue) > 0 Then
            btn_lupa_frete_valor.Enabled = True
            btn_lupa_frete_valor.ImageUrl = "~/img/lupa.gif"
        Else
            btn_lupa_frete_valor.Enabled = False
            btn_lupa_frete_valor.ImageUrl = "~/img/lupa_desabilitada.gif"

        End If
    End Sub

    Protected Sub cbo_tipo_frete_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_frete.SelectedIndexChanged

        limpaTelaTransportador()

        If cbo_pedido_indireto.SelectedValue.Equals("N") AndAlso cbo_tipo_frete.SelectedValue.Equals("D") Then
            cbo_transportador.Enabled = True
            cbo_transportador.Items.FindByValue("0").Text = "[Selecione]"
            cbo_transportador.SelectedValue = 0
            rf_transportador.Enabled = True
            rf_frete.Enabled = True

        Else
            cbo_transportador.Enabled = False
            cbo_transportador.Items.FindByValue("0").Text = "[Tipo de Frete Sem Transportador]"
            cbo_transportador.SelectedValue = 0
            rf_transportador.Enabled = False
            rf_frete.Enabled = False
        End If
        atualizarTotalizadores()



    End Sub

    Private Sub limpaTelaItem()

        'limpar dados do item
        txt_nr_qtde.Text = String.Empty
        txt_nr_valor_unitario.Text = String.Empty
        txt_nr_sacaria.Text = String.Empty
        lbl_total_item.Text = String.Empty
        lbl_inf_preco.Text = String.Empty

        cbo_tipo_medida.Enabled = False
        txt_nr_qtde.Enabled = False
        txt_nr_valor_unitario.Enabled = False
        txt_nr_sacaria.Enabled = False

    End Sub

    Private Sub limpaTelaTransportador()

        'limpar dados transportador
        txt_nr_frete.Text = String.Empty
        lbl_inf_frete.Text = String.Empty
        lbl_total_frete.Text = String.Empty
        ViewState.Item("id_central_tabela_frete_veiculos") = 0

        lbl_detalhe_item_frete.Text = String.Empty
        gridfrete.Visible = False
        ViewState.Item("id_index_item_frete") = String.Empty
        pnl_frete.Visible = False

    End Sub


    Protected Sub btn_lupa_preco_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_preco.Click
        'se  tem tabela de preço 
        If cbo_item.SelectedValue > 0 AndAlso (ViewState.Item("id_propriedade")) > 0 Then
            atualizarTabelaPrecos()
        End If

    End Sub

    Protected Sub btn_atualizar_totais_pedidos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_atualizar_totais_pedidos.Click
        'se selecionou item
        If cbo_item.SelectedValue > 0 Then
            atualizarTotalizadores()
        End If
    End Sub

    Protected Sub btn_atualizar_totais_transporte_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_atualizar_totais_transporte.Click
        If cbo_transportador.SelectedValue > 0 Then
            atualizarTotalizadores()
        End If
    End Sub

    Protected Sub txt_nr_sacaria_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nr_sacaria.TextChanged
        lbl_inf_preco.Text = String.Empty
        ViewState.Item("id_central_tabela_precos") = 0

        atualizarTotalizadores()
    End Sub

    Protected Sub btn_atualizar_totais_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_atualizar_totais.Click
        If cbo_item.SelectedValue > 0 Then
            atualizarTotalizadores()
        End If

    End Sub

    Protected Sub cbo_tipo_medida_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_medida.SelectedIndexChanged
        If cbo_tipo_medida.SelectedValue = "S" Then
            rfv_sacaria.Enabled = True
        Else
            rfv_sacaria.Enabled = False
        End If
    End Sub
End Class