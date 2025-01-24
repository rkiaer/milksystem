Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail
Imports System.IO


Partial Class frm_central_pedido_abertura_grupo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Private Sub carregarCamposProdutor()
        Try
            Me.lbl_nm_pessoa.Text = String.Empty
            Me.lbl_ds_telefone.Text = String.Empty
            Me.lbl_acordo_aquisicao_insumos.Text = String.Empty
            Me.lbl_cluster.Text = String.Empty
            Me.lbl_ds_email.Text = String.Empty
            Me.lbl_contrato.Text = String.Empty
            Me.lbl_dt_ini_contrato.Text = String.Empty
            Me.lbl_dt_fim_contrato_sel.Text = String.Empty
            Me.lbl_dt_rescisao_contrato.Text = String.Empty
            'Me.lk_gerar_pedido.Enabled = False
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
                gridPropriedades.Rows(0).Cells(0).ColumnSpan = 11
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
    Private Sub deleteItem(ByVal id_index_row As Integer)
        Try
            Dim contratoprop As New CentralContratoPropriedade

            contratoprop.id_central_contrato = ViewState.Item("id_central_contrato").ToString
            contratoprop.id_central_contrato_propriedade = id_index_row
            contratoprop.id_modificador = Convert.ToInt32(Session("id_login"))
            contratoprop.deleteCentralContratoPropriedadeGrupo()

            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 233 'central contrato abertura
            usuariolog.ds_nm_processo = "Central Contrato Grupo - Propriedade"
            usuariolog.id_nr_processo = ViewState.Item("id_central_contrato").ToString
            usuariolog.insertUsuarioLog()

            'atualiza qtde incluida
            updateTotalizadores()
            loadGridPropriedadesInf()

            messageControl.Alert("Registro excluído com sucesso!")

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
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
                        lbl_nr_valor_mensal_estimado.Text = FormatNumber(lbl_nr_valor_mensal_estimado.Text, 0).ToString
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

                        'lbl_nr_total_pedidos_abertos.Text = pedido.getTotalPedidosAbertos().ToString()

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
                                lbl_nr_valor_desconto.Text = FormatNumber(.Item("desconto_sem_abertos").ToString, 2).ToString
                                lbl_nr_total_pedidos_abertos.Text = .Item("desconto_abertos").ToString
                            End With

                        Else
                            'se nao tem faturamento na ficha do mes anterior, busca do projetado na ficha custo financeiro
                            Dim dslimitecusto As DataSet = saldoDisponivel.getSaldoDisponivelFichaCustoPropriedadeEMatriz
                            If dslimitecusto.Tables(0).Rows.Count > 0 Then
                                With dslimitecusto.Tables(0).Rows(0)
                                    lbl_nr_valor_disponivel.Text = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                                    lbl_nr_limite_mes_bruto.Text = FormatNumber(.Item("nr_limite_mes_bruto").ToString, 2).ToString
                                    'lbl_nr_valor_desconto.Text = FormatNumber(.Item("nr_valor_desconto").ToString, 2).ToString
                                    lbl_nr_valor_desconto.Text = FormatNumber(.Item("desconto_sem_abertos").ToString, 2).ToString
                                    lbl_nr_total_pedidos_abertos.Text = .Item("desconto_abertos").ToString
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
                                lbl_nr_total_pedidos_abertos.Text = "0"

                            End If
                        End If
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
            Me.ViewState.Item("id_propriedade_matriz") = 0
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
    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "delete"
                deleteItem(Convert.ToInt32(e.CommandArgument.ToString()))

                'Case "lupa"
                '    'Me.txt_placa.Text = ""

                '    carregarCamposFreteValor(Convert.ToInt32(e.CommandArgument.ToString()))
        End Select
    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles gridResults.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btnexcluir As ImageButton = CType(e.Row.FindControl("btn_delete"), ImageButton)
                Dim btnlupafrete As ImageButton = CType(e.Row.FindControl("btn_lupa_frete_valor"), ImageButton)
                Dim btn_atualizar_totais As ImageButton = CType(e.Row.FindControl("btn_atualizar_totais"), ImageButton)
                'Dim trfrete As HtmlTableRow = CType(e.Row.FindControl("tr_frete"), HtmlTableRow)
                Dim cbo_transportador As DropDownList = CType(e.Row.FindControl("cbo_transportador"), DropDownList)
                'Dim label As System.Web.UI.WebControls.Label = DirectCast(e.Row.FindControl("linhanova"), System.Web.UI.WebControls.Label)

                Dim pessoa As New Pessoa()

                'btnexcluir.CommandArgument = e.Row.RowIndex.ToString
                btnlupafrete.CommandArgument = e.Row.RowIndex.ToString
                btn_atualizar_totais.CommandArgument = e.Row.RowIndex.ToString

                'se pedido normal ou frete fob d
                'If cbo_pedido_indireto.SelectedValue.Equals("N") AndAlso cbo_tipo_frete.SelectedValue.Equals("D") Then
                '    trfrete.Visible = True
                'Else
                'trfrete.Visible = False
                If cbo_transportador.Items.Count > 0 Then

                Else
                    'transportador central
                    pessoa.id_situacao = 1
                    pessoa.st_transportador_central = "S"
                    cbo_transportador.DataSource = pessoa.getTransportadorCentralByFilters()
                    cbo_transportador.DataTextField = "nm_pessoa"
                    cbo_transportador.DataValueField = "id_pessoa"
                    cbo_transportador.DataBind()
                    cbo_transportador.Items.Insert(0, New ListItem("[Selecione]", 0))

                End If


            Catch ex As Exception
                Me.messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) AndAlso ViewState.Item("gridresults") = 1 Then
            Dim lbl_descricao As Label = CType(e.Row.FindControl("lbl_descricao"), Label)
            Dim lbl_limite As Anthem.Label = CType(e.Row.FindControl("lbl_limite"), Anthem.Label)
            Dim cbo_tipo_frete As Anthem.DropDownList = CType(e.Row.FindControl("cbo_tipo_frete"), Anthem.DropDownList)
            Dim cbo_tipo_medida As Anthem.DropDownList = CType(e.Row.FindControl("cbo_tipo_medida"), Anthem.DropDownList)
            Dim txt_nr_qtde As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_qtde"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim cbo_vai_parcelar As Anthem.DropDownList = CType(e.Row.FindControl("cbo_vai_parcelar"), Anthem.DropDownList)
            Dim txt_nr_parcelas As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_parcelas"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
            Dim cbo_transportador As Anthem.DropDownList = CType(e.Row.FindControl("cbo_transportador"), Anthem.DropDownList)
            Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim lbl_tipo_caminhao As Anthem.Label = CType(e.Row.FindControl("lbl_tipo_caminhao"), Anthem.Label)
            Dim lbl_total_item As Anthem.Label = CType(e.Row.FindControl("lbl_total_item"), Anthem.Label)
            Dim lbl_total_frete As Anthem.Label = CType(e.Row.FindControl("lbl_total_frete"), Anthem.Label)
            Dim lbl_valor_total As Anthem.Label = CType(e.Row.FindControl("lbl_valor_total"), Anthem.Label)
            Dim lbl_id_central_tabela_frete_veiculos As Label = CType(e.Row.FindControl("lbl_id_central_tabela_frete_veiculos"), System.Web.UI.WebControls.Label)
            Dim lbl_id_veiculo_central_compras As Label = CType(e.Row.FindControl("lbl_id_veiculo_central_compras"), System.Web.UI.WebControls.Label)
            Dim lbl_inf_frete As Label = CType(e.Row.FindControl("lbl_inf_frete"), Label)
            Dim lbl_ds_tipo_medida As Label = CType(e.Row.FindControl("lbl_ds_tipo_medida"), Label)
            Dim lbl_st_parcelamento As Label = CType(e.Row.FindControl("lbl_st_parcelamento"), Label)
            Dim lbl_ds_tipo_frete As Label = CType(e.Row.FindControl("lbl_ds_tipo_frete"), Label)
            Dim lbl_id_transportador As Label = CType(e.Row.FindControl("lbl_id_transportador"), Label)
            Dim btnexcluir As ImageButton = CType(e.Row.FindControl("btn_delete"), ImageButton)
            Dim btn_atualizar_totais As ImageButton = CType(e.Row.FindControl("btn_atualizar_totais"), ImageButton)


            'Dim item As DataRow = CType(Me.ViewState("gridtable"), DataTable).Rows(e.Row.RowIndex)
            Dim btn_lupa_frete As Anthem.ImageButton = CType(e.Row.FindControl("btn_lupa_frete_valor"), Anthem.ImageButton)
            Dim rf_transportador As RequiredFieldValidator = CType(e.Row.FindControl("rf_transportador"), RequiredFieldValidator)
            Dim rf_frete As RequiredFieldValidator = CType(e.Row.FindControl("rf_frete"), RequiredFieldValidator)
            Dim rfv_sacaria As RequiredFieldValidator = CType(e.Row.FindControl("rfv_sacaria"), RequiredFieldValidator)

            'Dim lbl_dt_cotacao_frete As Anthem.Label = CType(e.Row.FindControl("lbl_dt_cotacao_frete"), Anthem.Label)
            Dim lbl_id_cidade_destino As Label = CType(e.Row.FindControl("lbl_id_cidade_destino"), Label)
            Dim lbl_id_estado_destino As Label = CType(e.Row.FindControl("lbl_id_estado_destino"), Label)
            Dim lbl_id_propriedade_grid As Label = CType(e.Row.FindControl("lbl_id_propriedade_grid"), Label)
            Dim lbl_id_propriedade_matriz_grid As Label = CType(e.Row.FindControl("lbl_id_propriedade_matriz_grid"), Label)
            Dim lbl_id_produtor_grid As Label = CType(e.Row.FindControl("lbl_id_produtor_grid"), Label)
            Dim lsacaria As Decimal
            If txt_nr_sacaria.Text = String.Empty Then
                lsacaria = 0
            Else
                lsacaria = CDec(txt_nr_sacaria.Text)
            End If
            'totalizador
            If txt_nr_qtde.Text <> String.Empty And txt_nr_valor_unitario.Text <> String.Empty Then
                If IsNumeric(txt_nr_qtde.Text) AndAlso IsNumeric(txt_nr_valor_unitario.Text) AndAlso Convert.ToDecimal(txt_nr_qtde.Text) > 0 Then

                    lbl_total_item.Text = String.Concat("Total Item: ", FormatCurrency((Convert.ToDecimal(txt_nr_valor_unitario.Text) + lsacaria) * Convert.ToDecimal(txt_nr_qtde.Text), 2))
                    lbl_valor_total.Text = FormatNumber((Convert.ToDecimal(txt_nr_valor_unitario.Text) + lsacaria) * Convert.ToDecimal(txt_nr_qtde.Text), 2)
                Else
                    lbl_total_item.Text = "Total Item: R$ 0,00"
                    lbl_valor_total.Text = "0"
                End If
            Else
                lbl_total_item.Text = "Total Item: R$ 0,00"
                lbl_valor_total.Text = "0"

            End If
            If (IsNumeric(txt_nr_qtde.Text) AndAlso IsNumeric(txt_nr_frete.Text) AndAlso Convert.ToDecimal(txt_nr_qtde.Text) > 0) Then
                lbl_total_frete.Text = FormatNumber(Convert.ToDecimal(txt_nr_frete.Text) * Convert.ToDecimal(txt_nr_qtde.Text), 2)
                lbl_valor_total.Text = FormatNumber(Convert.ToDecimal(lbl_valor_total.Text) + Convert.ToDecimal(lbl_total_frete.Text), 2)
                lbl_total_frete.Text = String.Concat("Total Frete: ", FormatCurrency(lbl_total_frete.Text, 2))
            Else
                lbl_total_frete.Text = "Total Frete: R$ 0,00"
            End If

            lbl_valor_total.Text = String.Concat("Total: ", FormatCurrency(lbl_valor_total.Text, 2))

            If cbo_transportador.Items(0).Text <> "[Selecione]" Then
                cbo_transportador.Items.Insert(0, New ListItem("[Selecione]", 0))

            End If

            cbo_tipo_medida.SelectedValue = lbl_ds_tipo_medida.Text
            If Not lbl_st_parcelamento.Text.Equals(String.Empty) Then

                cbo_vai_parcelar.SelectedValue = lbl_st_parcelamento.Text
            End If
            cbo_tipo_frete.SelectedValue = lbl_ds_tipo_frete.Text
            If lbl_id_transportador.Text.Equals(String.Empty) OrElse lbl_id_transportador.Text.Equals("0") Then
                cbo_transportador.SelectedValue = 0
            Else
                cbo_transportador.SelectedValue = lbl_id_transportador.Text
            End If

            If cbo_tipo_frete.SelectedValue = "D" Then
                txt_nr_frete.Enabled = True
                cbo_transportador.Enabled = True
                btn_lupa_frete.Enabled = True
                btn_lupa_frete.ImageUrl = "~/img/lupa.gif"
                rf_transportador.Enabled = True
                rf_frete.Enabled = True

                If Not lbl_id_central_tabela_frete_veiculos.Text.Equals(String.Empty) Then
                    If Not lbl_id_central_tabela_frete_veiculos.Text.Equals("0") Then
                        Dim tabelafrete As New TabelaFreteVeiculos
                        tabelafrete.id_central_tabela_frete_veiculos = lbl_id_central_tabela_frete_veiculos.Text
                        Dim dsfrete As DataSet = tabelafrete.getCentralTabelaFreteVeiculos
                        With dsfrete.Tables(0).Rows(0)
                            lbl_inf_frete.Text = String.Concat("(Cotação: ", DateTime.Parse(.Item("dt_modificacao").ToString).ToString("dd/MM/yyyy"), ")")
                        End With

                    End If
                End If

            Else
                txt_nr_frete.Enabled = False
                cbo_transportador.Enabled = False
                btn_lupa_frete.Enabled = False
                btn_lupa_frete.ImageUrl = "~/img/lupa_desabilitada.gif"
                rf_frete.Enabled = False
                rf_transportador.Enabled = False
            End If
            If lbl_situacao.Text = "Finalizado" Then
                btnexcluir.Enabled = False
                btnexcluir.Visible = False
                btn_atualizar_totais.Enabled = False
                btn_atualizar_totais.Visible = False
                cbo_tipo_frete.Enabled = False
                cbo_tipo_medida.Enabled = False
                cbo_vai_parcelar.Enabled = False
                txt_nr_parcelas.Enabled = False
                cbo_fornecedor.Enabled = False
                txt_nr_frete.Enabled = False
                btn_lupa_frete.Enabled = False
                btn_lupa_frete.ImageUrl = "~/img/lupa_desabilitada.gif"

            End If


        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub lk_gerar_pedido_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lk_gerar_pedido.Click
        If (Me.Page.IsValid) Then
            Try
                If ViewState.Item("id_central_pedido_matriz") = 0 Then

                    'preparar dados do grid de itens
                    Dim dstable As New DataTable
                    Dim ilinha As Integer

                    dstable.Columns.Add("nr_valor_limite") '0
                    dstable.Columns.Add("ds_tipo_medida") '1
                    dstable.Columns.Add("nr_qtde") '2
                    dstable.Columns.Add("st_parcelamento") '3
                    dstable.Columns.Add("nr_parcelas") '4
                    dstable.Columns.Add("id_transportador") '5
                    dstable.Columns.Add("nr_frete") '6
                    dstable.Columns.Add("nr_valor_total_item") '7
                    dstable.Columns.Add("nr_valor_total_frete") '8
                    dstable.Columns.Add("id_central_tabela_frete_veiculos") '9
                    dstable.Columns.Add("id_cidade_destino") '10
                    dstable.Columns.Add("id_estado_destino") '11
                    dstable.Columns.Add("id_propriedade") '12
                    dstable.Columns.Add("id_propriedade_matriz") '13
                    dstable.Columns.Add("id_produtor") '14
                    dstable.Columns.Add("dt_fim_contrato") '15
                    dstable.Columns.Add("id_central_contrato_propriedade") '16
                    dstable.Columns.Add("ds_tipo_frete") '17

                    Dim row As GridViewRow
                    Dim lvaloritem As Decimal = 0
                    Dim lvalorfrete As Decimal = 0
                    Dim lvalortotalpedidofornecedor As Decimal = 0
                    Dim lvalortotalpedidotransortador As Decimal = 0
                    Dim lvalordisponivel As Decimal = 0
                    Dim produtor As New Pessoa
                    Dim lidpessoacontrato As Integer = 0
                    Dim dspessoa As DataSet
                    Dim ldtfimcontrato As String = String.Empty
                    Dim saldoDisponivel As New SaldoDisponivel()
                    saldoDisponivel.dt_referencia = String.Concat("01/", DateTime.Now.ToString("MM/yyyy")).ToString

                    ilinha = 0
                    For Each row In gridResults.Rows
                        Dim cbo_tipo_medida As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_medida"), Anthem.DropDownList)
                        Dim cbo_tipo_frete As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_frete"), Anthem.DropDownList)
                        Dim txt_nr_qtde As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_qtde"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim cbo_transportador As Anthem.DropDownList = CType(row.FindControl("cbo_transportador"), Anthem.DropDownList)
                        Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim lbl_id_central_tabela_frete_veiculos As Label = CType(row.FindControl("lbl_id_central_tabela_frete_veiculos"), Label)
                        Dim lbl_id_veiculo_central_compras As Label = CType(row.FindControl("lbl_id_veiculo_central_compras"), Label)
                        Dim lbl_limite As Anthem.Label = CType(row.FindControl("lbl_limite"), Anthem.Label)
                        Dim cbo_vai_parcelar As Anthem.DropDownList = CType(row.FindControl("cbo_vai_parcelar"), Anthem.DropDownList)
                        Dim txt_nr_parcelas As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_parcelas"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                        Dim lbl_id_cidade_destino As Label = CType(row.FindControl("lbl_id_cidade_destino"), Label)
                        Dim lbl_id_estado_destino As Label = CType(row.FindControl("lbl_id_estado_destino"), Label)
                        Dim lbl_id_propriedade_grid As Label = CType(row.FindControl("lbl_id_propriedade_grid"), Label)
                        Dim lbl_id_propriedade_matriz_grid As Label = CType(row.FindControl("lbl_id_propriedade_matriz_grid"), Label)
                        Dim lbl_id_produtor_grid As Label = CType(row.FindControl("lbl_id_produtor_grid"), Label)
                        Dim lbl_dt_fim_contrato_grid As Label = CType(row.FindControl("lbl_dt_fim_contrato_grid"), Label)

                        dstable.Rows.InsertAt(dstable.NewRow(), ilinha)

                        lvalordisponivel = 0
                        If Not lbl_id_propriedade_matriz_grid.Text.Equals(String.Empty) Then
                            saldoDisponivel.id_propriedade = lbl_id_propriedade_matriz_grid.Text
                        Else
                            saldoDisponivel.id_propriedade = lbl_id_propriedade_grid.Text
                        End If

                        Dim dslimite As DataSet = saldoDisponivel.getSaldoDisponivelPropriedadeEMatriz
                        If dslimite.Tables(0).Rows.Count > 0 Then
                            With dslimite.Tables(0).Rows(0)
                                lvalordisponivel = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                            End With
                        Else
                            'se nao tem faturamento na ficha do mes anterior, busca do projetado na ficha custo financeiro
                            Dim dslimitecusto As DataSet = saldoDisponivel.getSaldoDisponivelFichaCustoPropriedadeEMatriz
                            If dslimitecusto.Tables(0).Rows.Count > 0 Then
                                With dslimitecusto.Tables(0).Rows(0)
                                    lvalordisponivel = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                                End With
                            Else
                                'se nao encontrou valor projetado e nem faturamento mes anterior
                                lvalordisponivel = 0
                            End If
                        End If

                        produtor.id_pessoa = lbl_id_produtor_grid.Text
                        lidpessoacontrato = 0
                        dspessoa = produtor.getPessoaByFilters
                        ldtfimcontrato = String.Empty
                        If (dspessoa.Tables(0).Rows.Count > 0) Then
                            With dspessoa.Tables(0).Rows(0)
                                If Not IsDBNull(.Item("id_pessoa_contrato")) Then
                                    lidpessoacontrato = .Item("id_pessoa_contrato")
                                End If
                            End With

                            If lidpessoacontrato > 0 Then
                                Dim contrato As New PessoaContrato()
                                contrato.id_pessoa_contrato = Convert.ToInt32(lidpessoacontrato)
                                Dim dscontrato As DataSet = contrato.getPessoaContratoByFilters()
                                If (dscontrato.Tables(0).Rows.Count <= 0) Then
                                    ldtfimcontrato = String.Empty
                                Else
                                    With dscontrato.Tables(0).Rows(0)
                                        If Not IsDBNull(.Item("dt_fim_contrato")) Then
                                            ldtfimcontrato = DateTime.Parse(.Item("dt_fim_contrato")).ToString("dd/MM/yyyy")
                                        Else
                                            ldtfimcontrato = String.Empty
                                        End If
                                    End With
                                End If
                            End If
                        End If
                        lvaloritem = 0
                        lvalorfrete = 0
                        With dstable.Rows.Item(ilinha)
                            .Item(0) = Round(lvalordisponivel, 2)
                            .Item(1) = cbo_tipo_medida.SelectedValue
                            .Item(2) = CDec(txt_nr_qtde.Text)
                            .Item(3) = cbo_vai_parcelar.SelectedValue
                            .Item(4) = txt_nr_parcelas.Text

                            If cbo_tipo_medida.SelectedValue = "S" Then
                                lvaloritem = (CDec(txt_nr_valor_unitario.Text) + CDec(txt_nr_sacaria.Text)) * CDec(txt_nr_qtde.Text)
                                .Item(7) = lvaloritem.ToString
                            Else
                                lvaloritem = CDec(txt_nr_valor_unitario.Text) * CDec(txt_nr_qtde.Text)
                                .Item(7) = lvaloritem.ToString
                            End If

                            'se tipo de frete é fob d
                            If cbo_tipo_frete.SelectedValue = "D" Then
                                .Item(5) = cbo_transportador.SelectedValue
                                .Item(6) = CDec(txt_nr_frete.Text)
                                lvalorfrete = CDec(txt_nr_frete.Text) * CDec(txt_nr_qtde.Text)
                                .Item(8) = lvalorfrete.ToString
                                'se informação sobre tabela de frete for vazia, significa que nao uilizou tabela de frete do cadastro
                                If lbl_id_central_tabela_frete_veiculos.Text.Equals(String.Empty) Then
                                    .Item(9) = "0"
                                Else
                                    .Item(9) = lbl_id_central_tabela_frete_veiculos.Text
                                    '.Item(10) = lbl_id_veiculo_central_compras.Text
                                End If
                            Else
                                .Item(5) = "0"
                                .Item(6) = "0"
                                .Item(8) = "0"
                                .Item(9) = "0"
                                '.Item(10) = "0"
                                lvalorfrete = 0
                            End If

                            .Item(10) = lbl_id_cidade_destino.Text
                            .Item(11) = lbl_id_estado_destino.Text
                            .Item(12) = lbl_id_propriedade_grid.Text
                            .Item(13) = lbl_id_propriedade_matriz_grid.Text
                            .Item(14) = lbl_id_produtor_grid.Text
                            .Item(15) = ldtfimcontrato
                            .Item(16) = gridResults.DataKeys(row.RowIndex).Value
                            .Item(17) = cbo_tipo_frete.SelectedValue

                        End With

                        ilinha = ilinha + 1
                    Next

                    Dim pedido As New Pedido

                    pedido.id_central_contrato = CInt(ViewState.Item("id_central_contrato").ToString)
                    pedido.id_estabelecimento = cbo_estabelecimento.SelectedValue
                    pedido.id_fornecedor = ViewState.Item("id_fornecedor").ToString
                    pedido.id_item = ViewState.Item("id_item").ToString
                    pedido.ds_inclusao_pedido = "M"
                    pedido.st_pedido_indireto = "N"
                    pedido.st_evento_compras = "N"
                    If txt_nr_qtde_total.Text = String.Empty Then
                        pedido.nr_quantidade_total = 0
                    Else
                        pedido.nr_quantidade_total = CDec(txt_nr_qtde_total.Text)
                    End If
                    pedido.nr_valor_unitario = Convert.ToDecimal(txt_nr_valor_unitario.Text)
                    If txt_nr_sacaria.Text = String.Empty Then
                        pedido.nr_sacaria = 0
                    Else
                        pedido.nr_sacaria = Convert.ToDecimal(txt_nr_sacaria.Text)
                    End If
                    pedido.id_modificador = Session("id_login")

                    pedido.pedidoitens = dstable

                    ViewState.Item("id_central_pedido_matriz") = pedido.gerarPedidoGrupo

                    If ViewState.Item("id_central_pedido_matriz") = 0 Then
                        Me.messageControl.Alert("Ocorreram problemas na geração do Pedido. Contate o administrador do sistema.")
                    Else
                        Me.messageControl.Alert("Pedidos gerados com sucesso!")
                        lk_gerar_pedido.Enabled = False
                        lk_gerar_pedido.ToolTip = "Pedido gerado."

                        loadData()
                    End If

                End If
            Catch ex As Exception
                Me.messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lk_novo.Click
        Me.Response.Redirect("frm_central_pedido_abertura_grupo.aspx")
    End Sub

    Private Sub loadDadosProdutor(ByVal pid_produtor As Integer)
        Me.lbl_nm_pessoa.Text = String.Empty
        Me.lbl_ds_telefone.Text = String.Empty
        Me.lbl_acordo_aquisicao_insumos.Text = String.Empty
        Me.lbl_cluster.Text = String.Empty
        Me.lbl_ds_email.Text = String.Empty
        Me.lbl_contrato.Text = String.Empty
        Me.lbl_dt_ini_contrato.Text = String.Empty
        Me.lbl_dt_fim_contrato_sel.Text = String.Empty
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
                    Me.lbl_dt_fim_contrato_sel.Text = String.Empty
                    Me.lbl_dt_rescisao_contrato.Text = String.Empty
                Else
                    Dim contrato As New PessoaContrato()
                    contrato.id_pessoa_contrato = Convert.ToInt32(lidpessoacontrato)

                    Dim dscontrato As DataSet = contrato.getPessoaContratoByFilters()
                    If (dscontrato.Tables(0).Rows.Count <= 0) Then
                        Me.lbl_contrato.Text = String.Empty
                        Me.lbl_dt_ini_contrato.Text = String.Empty
                        Me.lbl_dt_fim_contrato_sel.Text = String.Empty
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
                                lbl_dt_fim_contrato_sel.Text = DateTime.Parse(.Item("dt_fim_contrato")).ToString("dd/MM/yyyy")
                            Else
                                lbl_dt_fim_contrato_sel.Text = String.Empty
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
    Private Sub loadData()

        Try

            Dim centralcontrato As New CentralContrato

            centralcontrato.id_central_contrato = Convert.ToInt32(ViewState.Item("id_central_contrato"))

            Dim dscontrato As DataSet = centralcontrato.getCentralContratoByFilters

            With dscontrato.Tables(0).Rows(0)

                ViewState.Item("id_estabelecimento") = .Item("id_estabelecimento").ToString
                ViewState.Item("id_fornecedor") = .Item("id_fornecedor").ToString
                ViewState.Item("id_item") = .Item("id_item").ToString

                cbo_estabelecimento.SelectedValue = .Item("id_estabelecimento")
                cbo_estabelecimento.Enabled = False

                lbl_nr_contrato.Text = ViewState.Item("id_central_contrato").ToString
                txt_descricao.Text = .Item("ds_descricao_contrato").ToString
                txt_dt_inicio.Text = DateTime.Parse(.Item("dt_inicio_contrato")).ToString("MM/yyyy")
                txt_dt_inicio.Enabled = False
                Select Case .Item("id_situacao_central_contrato").ToString
                    Case "1"
                        lbl_situacao.Text = "Aberto"
                    Case "2"
                        lbl_situacao.Text = "Finalizado"

                End Select

                'Parceiro
                txt_nm_fornecedor.Visible = False
                lbl_selecione1.Visible = False
                cbo_fornecedor.SelectedValue = .Item("id_fornecedor").ToString
                cbo_fornecedor.Visible = False
                lbl_dsfornecedor.Text = String.Concat(.Item("cd_fornecedor").ToString, " - ", .Item("nm_abreviado_fornecedor").ToString)
                If .Item("st_fornecedor_cif") = "S" Then
                    lbl_frete_parceiro.Text = "Sim"
                Else
                    lbl_frete_parceiro.Text = "Não"
                End If
                If .Item("st_excecao_prazo_pagto") = "S" Then
                    lbl_excecao.Text = "Sim"
                Else
                    lbl_excecao.Text = "Não"
                End If

                txt_nr_qtde_total.Text = CDec(.Item("nr_quantidade_total").ToString)

                'ITEM
                txt_nm_item.Visible = False
                lbl_selecione2.Visible = False
                cbo_item.SelectedValue = .Item("id_item").ToString
                cbo_item.Visible = False
                lbl_dsitem.Text = String.Concat(.Item("cd_item").ToString, " - ", .Item("nm_item").ToString)
                lbl_nm_categoria.Text = .Item("nm_categoria_item").ToString

                txt_nr_valor_unitario.Text = FormatNumber(.Item("nr_valor_unitario").ToString, 2)
                txt_nr_sacaria.Text = FormatNumber(.Item("nr_sacaria").ToString, 2)


            End With

            lbl_qtde_incluida.Text = FormatNumber(centralcontrato.getCentralContratoTotalQtde, 4)
            lbl_politica_parcelamento.Text = String.Concat("*Política de Parcelamento DANONE: máximo de ", ViewState("nr_politica_parcelas").ToString, " parcelas.")

            If lbl_situacao.Text = "Finalizado" Then
                txt_descricao.Enabled = False
                txt_nr_qtde_total.Enabled = False
                txt_nr_valor_unitario.Enabled = False
                txt_nr_sacaria.Enabled = False
                tr_produtor_selecione.Visible = False
                tr_produtor_dados.Visible = False
                tr_produtor_propriedades.Visible = False
                tr_produtor_incluir.Visible = False
                btn_salvar_infpedidos.Enabled = False
                btn_salvar_infpedidos.Visible = False
                lk_concluir.Enabled = False
                lk_concluir.Visible = False
                lk_gerar_pedido.Enabled = False
                gridResults.Visible = False
                loadGridPedidos()
                lk_email_parceiro.Visible = True
                lk_email_parceiro.Enabled = True
                lk_email_produtor.Visible = True
                lk_email_produtor.Enabled = True
                lk_email_parceiro_frete.Visible = True
                lk_email_parceiro_frete.Enabled = True
                img_parceiro.Visible = True
                img_parceiro_frete.Visible = True
                img_notificacao.Visible = True
                ViewState.Item("TemPropriedade") = True 'se esta finalizado assume que tem propriedades
            Else
                'Carrega o grid prop x qtdes
                loadGridPropriedadesInf()
                lk_email_parceiro.Visible = False
                lk_email_produtor.Visible = False
                lk_email_parceiro_frete.Visible = False
                img_parceiro.Visible = False
                img_notificacao.Visible = False
                img_parceiro_frete.Visible = False

            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
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
            ViewState.Item("id_fornecedor") = "0"
            ViewState.Item("id_item") = "0"
            ViewState.Item("TemPropriedade") = False

            Me.ViewState.Item("id_propriedade") = 0
            Me.ViewState.Item("id_estado_destino") = 0
            Me.ViewState.Item("id_cidade_destino") = 0
            Me.ViewState.Item("id_produtor") = 0
            ViewState.Item("id_central_pedido_matriz") = 0

            Dim parametro As New Parametro
            ViewState("nr_politica_parcelas") = parametro.nr_politica_parcelas

            If Not (Request("tela") Is Nothing) Then
                ViewState.Item("tela") = Request("tela").ToString
            Else
                ViewState.Item("tela") = String.Empty
            End If
            If Not (Request("id_central_contrato") Is Nothing) Then

                ViewState.Item("id_central_contrato") = Request("id_central_contrato")

                tr_dados_produtores.Visible = True
                tr_incluir_novo_contrato.Visible = False

                Dim pessoa As New Pessoa
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
                gridPropriedades.Rows(0).Cells(0).ColumnSpan = 20
                gridPropriedades.Rows(0).Cells(0).Text = "Informe um produtor para visualizar suas propriedades!"

                'carrega 
                loadData()
            Else
                tr_dados_produtores.Visible = False
                tr_incluir_novo_contrato.Visible = True

                ViewState.Item("id_central_contrato") = "0"

                'estabelecimento
                cbo_estabelecimento.SelectedValue = 1 'default poços
                ViewState.Item("id_estabelecimento") = "1"

                ViewState.Item("id_fornecedor") = "0"
                txt_nm_fornecedor.Enabled = True
                loadComboParceiro(String.Empty)

                'combo fornecedor
                cbo_fornecedor.SelectedValue = 0

                'combo item
                cbo_item.Items.Insert(0, New ListItem("[Selecione um Parceiro]", "0"))
                cbo_item.SelectedValue = 0
                gridResults.Visible = False
                lbl_detalhe_item_frete.Text = String.Empty
                gridfrete.Visible = False
                ViewState.Item("id_item") = "0"

                'grid produtores/propriedades
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
                gridPropriedades.Rows(0).Cells(0).ColumnSpan = 11
                gridPropriedades.Rows(0).Cells(0).Text = "Informe um produtor para visualizar suas propriedades!"

                ViewState.Item("id_central_contrato") = "0"

            End If


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
    Private Sub loadGridPropriedades()
        Try
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
                        'lk_gerar_pedido.Enabled = True
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
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_central_pedido_abertura_grupo.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 233
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        Else
            If ViewState.Item("id_central_contrato") <> 0 AndAlso (Me.txt_cd_pessoa.Text.Equals(String.Empty)) Then
                Me.gridPropriedades.Rows(0).Cells.Clear()
                Me.gridPropriedades.Rows(0).Cells.Add(New TableCell())
                Me.gridPropriedades.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                Me.gridPropriedades.Rows(0).Cells(0).Text = "Informe um produtor para visualizar suas propriedades!"
                Me.gridPropriedades.Rows(0).Cells(0).ColumnSpan = 20
            End If
            If ViewState.Item("id_central_contrato") <> 0 AndAlso ViewState.Item("TemPropriedade") = False Then
                loadGridPropriedadesInf()
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
        Me.lbl_dt_fim_contrato_sel.Text = String.Empty
        Me.lbl_dt_rescisao_contrato.Text = String.Empty
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
                gridPropriedades.Rows(0).Cells(0).ColumnSpan = 11
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
                    Me.gridPropriedades.Rows(0).Cells(0).ColumnSpan = 11
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
            txt_nm_fornecedor.Text = String.Empty
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

            'lbl_detalhe_item_frete.Text = String.Empty
            'gridfrete.Visible = False
            'ViewState.Item("id_item") = "0"
            'se mudar fornecedor deve limpar dados
            'limpar dados do item
            limpaTelaItem()
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
                        'lbl_parcelas_parceiro.Text = .Item("nr_fornecedor_parcelas_central").ToString
                    End With
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


            'se ja tinha selecionado fornecedor antes
            If CInt(ViewState.Item("id_fornecedor").ToString) > 0 Then
                'se a nova montagem de fornecedores não tem o fornecedor selecionado anteriormente
                If cbo_fornecedor.Items.FindByValue(ViewState.Item("id_fornecedor").ToString) Is Nothing Then
                    'se nao encontrou fornecedor  limpa tudo

                    'se mudar fornecedor deve limpar dados
                    'limpar dados do item
                    limpaTelaItem()

                    'dados fornecedeor
                    ViewState.Item("id_fornecedor") = 0
                    ViewState.Item("fornecedor_excecao_prazo") = String.Empty
                    ViewState.Item("fornecedor_cif") = String.Empty
                    ViewState.Item("fornecedor_parcelas") = String.Empty
                    lbl_frete_parceiro.Text = String.Empty

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
                    End With
                End If

                'If ViewState.Item("fornecedor_cif").ToString = "S" Then
                '    cbo_tipo_frete.Items(1).Enabled = False
                '    cbo_tipo_frete.Items(2).Enabled = False
                '    cbo_tipo_frete.SelectedValue = String.Empty
                'Else
                '    cbo_tipo_frete.Items(1).Enabled = True
                '    cbo_tipo_frete.Items(2).Enabled = True
                '    cbo_tipo_frete.SelectedValue = String.Empty
                'End If
                txt_nm_item.Text = "[Filtre Nome]"
                lbl_nm_categoria.Text = String.Empty

                loadComboItens(String.Empty)

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub
    Private Sub limpaTelaItem()

        'limpar dados do item
        'txt_nr_qtde.Text = String.Empty
        txt_nr_valor_unitario.Text = String.Empty
        txt_nr_sacaria.Text = String.Empty
        'lbl_total_item.Text = String.Empty
        'lbl_inf_preco.Text = String.Empty

        'cbo_tipo_medida.Enabled = False
        'txt_nr_qtde.Enabled = False
        txt_nr_valor_unitario.Enabled = False
        txt_nr_sacaria.Enabled = False

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

            'If cbo_tipo_frete.SelectedValue = "D" Then
            '    limpaTelaTransportador()
            '    If cbo_pedido_indireto.SelectedValue = "N" Then
            '        cbo_transportador.Enabled = True
            '        cbo_transportador.Items.FindByValue("0").Text = "[Selecione]"

            '    End If
            'End If

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

                'cbo_tipo_medida.Enabled = True
                'txt_nr_qtde.Enabled = True
                txt_nr_valor_unitario.Enabled = True
                txt_nr_sacaria.Enabled = True

                'If cbo_tipo_frete.SelectedValue = "D" AndAlso cbo_pedido_indireto.SelectedValue = "N" Then
                '    cbo_transportador.Enabled = True
                '    cbo_transportador.Items.FindByValue("0").Text = "[Selecione]"

                'End If

                'para item novo busca valor tabela de preço, ultimo ativo
                'atualizarTabelaPrecos()
            Else
                lbl_nm_categoria.Text = String.Empty
                lbl_nm_categoria_tit.Visible = False
                ViewState.Item("id_categoria_item") = "0"
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub cbo_tipo_medida_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txt_nr_qtde As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_qtde"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        Dim lbl_total_item As Anthem.Label = CType(row.FindControl("lbl_total_item"), Anthem.Label)
        Dim lbl_total_frete As Anthem.Label = CType(row.FindControl("lbl_total_frete"), Anthem.Label)
        Dim lbl_valor_total As Anthem.Label = CType(row.FindControl("lbl_valor_total"), Anthem.Label)

        Dim cbo_tipo_medida As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_medida"), Anthem.DropDownList)

        'se tem tipo de medida
        'se selecione
        If cbo_tipo_medida.SelectedValue.Equals(String.Empty) Then
            'se tem tabela de precos
            lbl_total_item.Text = String.Empty
            lbl_total_frete.Text = String.Empty
            lbl_valor_total.Text = String.Empty
        Else
            'se tem informaçao de valor unitario e qtde 
            If Not txt_nr_valor_unitario.Text.Equals(String.Empty) AndAlso Not txt_nr_qtde.Text.Equals(String.Empty) Then

                atualizarGridRowTotalizadores(row.RowIndex)

            End If

        End If

        txt_nr_qtde.Focus()
    End Sub
    Private Sub atualizarGridRowTotalizadores(ByVal id_index_row As Int32)

        Try

            Dim row As GridViewRow = gridResults.Rows.Item(id_index_row)


            Dim cbo_tipo_medida As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_medida"), Anthem.DropDownList)
            Dim cbo_tipo_frete As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_frete"), Anthem.DropDownList)
            Dim txt_nr_qtde As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_qtde"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim lbl_total_item As Anthem.Label = CType(row.FindControl("lbl_total_item"), Anthem.Label)
            Dim lbl_total_frete As Anthem.Label = CType(row.FindControl("lbl_total_frete"), Anthem.Label)
            Dim lbl_valor_total As Anthem.Label = CType(row.FindControl("lbl_valor_total"), Anthem.Label)
            Dim laux As Decimal

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
                    lbl_total_frete.Text = FormatCurrency("0", 2).ToString
                End If

                lbl_valor_total.Text = (CDec(lbl_valor_total.Text) + CDec(lbl_total_frete.Text)).ToString
            End If
            lbl_valor_total.Text = FormatCurrency(CDec(lbl_valor_total.Text), 2).ToString

            lbl_total_item.Text = String.Concat("Total Item: ", lbl_total_item.Text)
            lbl_total_frete.Text = String.Concat("Total Frete: ", lbl_total_frete.Text)
            lbl_valor_total.Text = String.Concat("Total: ", lbl_valor_total.Text)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub atualizarGridTotalizadores()
        Dim row As GridViewRow

        Dim lnrqtdegrid As Decimal = 0
        Dim lnrvlunitario As Decimal = 0
        Dim lnrsacaria As Decimal = 0
        Dim lnrfretegrid As Decimal = 0
        Dim lnrfretegeral As Decimal = 0
        Dim lnrtotalitem As Decimal = 0
        Dim lnrtotalfrete As Decimal = 0
        Dim lnrtotal As Decimal = 0
        Dim lnrqtdeincluida As Decimal = 0
        Dim lnr_qtde_total As Decimal = 0

        If txt_nr_valor_unitario.Text.Equals(String.Empty) Then
            lnrvlunitario = 0
        Else
            lnrvlunitario = CDec(txt_nr_valor_unitario.Text)
        End If
        If txt_nr_sacaria.Text.Equals(String.Empty) Then
            lnrsacaria = 0
        Else
            lnrsacaria = CDec(txt_nr_sacaria.Text)
        End If
        If txt_nr_qtde_total.Text.Equals(String.Empty) Then
            lnr_qtde_total = 0
        Else
            lnr_qtde_total = CDec(txt_nr_qtde_total.Text)
        End If

        For Each row In gridResults.Rows
            If row.Visible = True Then
                Dim cbo_tipo_medida As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_medida"), Anthem.DropDownList)
                Dim cbo_tipo_frete As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_frete"), Anthem.DropDownList)
                Dim txt_nr_qtde As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_qtde"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim lbl_total_item As Anthem.Label = CType(row.FindControl("lbl_total_item"), Anthem.Label)
                Dim cbo_transportador As Anthem.DropDownList = CType(row.FindControl("cbo_transportador"), Anthem.DropDownList)
                Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim lbl_total_frete As Anthem.Label = CType(row.FindControl("lbl_total_frete"), Anthem.Label)
                Dim lbl_valor_total As Anthem.Label = CType(row.FindControl("lbl_valor_total"), Anthem.Label)

                'inicializa valores do grid
                If txt_nr_qtde.Text.Equals(String.Empty) Then
                    lnrqtdegrid = 0
                Else
                    lnrqtdegrid = CDec(txt_nr_qtde.Text)
                End If

                'se for fob-d tem frete
                If cbo_tipo_frete.SelectedValue = "D" Then
                    If txt_nr_frete.Text.Equals(String.Empty) Then
                        lnrfretegrid = 0
                    Else
                        lnrfretegrid = CDec(txt_nr_frete.Text)
                    End If
                Else
                    lnrfretegrid = 0
                End If

                'Faz somatorio linha a linha da qtde incluida
                lnrqtdeincluida = lnrqtdeincluida + lnrqtdegrid

                If lnrqtdegrid = 0 Then
                    lnrtotalitem = 0
                    lnrtotalfrete = 0
                    lnrtotal = 0
                Else
                    If cbo_tipo_medida.SelectedValue = "S" Then
                        lnrtotalitem = (lnrvlunitario + lnrsacaria) * lnrqtdegrid
                    Else
                        lnrtotalitem = lnrvlunitario * lnrqtdegrid
                    End If

                    'se for fob-d tem frete
                    If cbo_tipo_frete.SelectedValue = "D" Then
                        lnrtotalfrete = lnrvlunitario * lnrqtdegrid
                    Else
                        lnrtotalfrete = 0
                    End If

                    lnrtotal = lnrtotalitem + lnrtotalfrete

                    'atualiza campos da tela
                    lbl_total_item.Text = FormatCurrency(lnrtotalitem, 2).ToString
                    If cbo_tipo_frete.SelectedValue = "D" Then 'se for fob d
                        lbl_total_frete.Text = FormatCurrency(lnrtotalfrete, 2).ToString
                    End If
                    lbl_valor_total.Text = FormatCurrency(lnrtotal, 2).ToString

                End If
            End If
        Next
        'atualiza quantidade incluida da tela
        If lnrqtdeincluida = 0 Then
            lbl_qtde_incluida.Text = String.Empty
        Else
            lbl_qtde_incluida.Text = FormatNumber(lnrqtdeincluida, 4).ToString
            If lnr_qtde_total > lnrqtdeincluida Then
                lbl_qtde_incluida.ForeColor = Drawing.Color.Blue
            End If
            If lnrqtdeincluida > lnr_qtde_total Then
                lbl_qtde_incluida.ForeColor = Drawing.Color.Red
            End If
        End If



    End Sub

    Protected Sub btn_lupa_frete_valor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim cbo_transportador As Anthem.DropDownList = CType(row.FindControl("cbo_transportador"), Anthem.DropDownList)
        Dim lbl_id_propriedade As Label = CType(row.FindControl("lbl_id_propriedade_grid"), System.Web.UI.WebControls.Label)
        Dim lbl_id_estado_destino As Label = CType(row.FindControl("lbl_id_estado_destino"), System.Web.UI.WebControls.Label)
        Dim lbl_id_cidade_destino As Label = CType(row.FindControl("lbl_id_cidade_destino"), System.Web.UI.WebControls.Label)

        pnl_frete.Visible = False

        If cbo_transportador.SelectedValue = "0" Then
            Me.messageControl.Alert("Transportador deve ser selecionado para a busca da tabela de fretes.")
        Else
            'If cbo_item.SelectedValue = "0" Then
            '    Me.messageControl.Alert("Item deve ser selecionado para a busca da tabela de fretes.")
            'Else
            pnl_frete.Visible = True
            lbl_detalhe_item_frete.Text = String.Concat("Frete para o ITEM ", lbl_dsitem.Text, ", Transportador: ", cbo_transportador.SelectedItem.Text.ToUpper, " e Propriedade ", lbl_id_propriedade.Text)

            Dim tabfrete As New TabelaFrete
            tabfrete.id_estabelecimento = ViewState.Item("id_estabelecimento")
            tabfrete.id_fornecedor = cbo_transportador.SelectedValue
            tabfrete.id_item = CInt(ViewState.Item("id_item"))
            tabfrete.id_estado_propriedade = lbl_id_estado_destino.Text
            tabfrete.id_cidade_propriedade = lbl_id_cidade_destino.Text

            Dim dsfrete As DataSet = tabfrete.getCentralTabelaFreteMax()
            If (dsfrete.Tables(0).Rows.Count <= 0) Then
                Me.messageControl.Alert("Não foram encontrados valores de frete ativos para o Transportador, item e cidade destino da propriedade!")

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
                pnl_frete.Visible = True
                lbl_detalhe_item_frete.Text = String.Concat("Frete para o ITEM ", lbl_dsitem.Text, ", Transportador: ", cbo_transportador.SelectedItem.Text.ToUpper, " e Propriedade ", lbl_id_propriedade.Text)

                ViewState.Item("id_index_item_frete") = row.RowIndex

                gridfrete.Visible = True
                gridfrete.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                gridfrete.DataBind()
            End If


        End If
    End Sub
    Protected Sub txt_nr_valor_unitario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nr_valor_unitario.TextChanged
        If (Me.ViewState("gridLinhasAdicionadas") IsNot Nothing) Then
            atualizarGridTotalizadores()
        End If
    End Sub


    Protected Sub cbo_vai_parcelar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim cbo_vai_parcelar As Anthem.DropDownList = CType(row.FindControl("cbo_vai_parcelar"), Anthem.DropDownList)
        Dim rfv_nr_parcelas As Anthem.RequiredFieldValidator = CType(row.FindControl("rfv_nr_parcelas"), Anthem.RequiredFieldValidator)
        Dim rv_parcelas As Anthem.RangeValidator = CType(row.FindControl("rv_parcelas"), Anthem.RangeValidator)
        Dim cv_nr_parcelas As Anthem.CompareValidator = CType(row.FindControl("cv_nr_parcelas"), Anthem.CompareValidator)
        Dim txt_nr_parcelas As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_parcelas"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

        Select Case cbo_vai_parcelar.SelectedValue

            Case "N"
                txt_nr_parcelas.Enabled = False
                txt_nr_parcelas.Text = 1
                rfv_nr_parcelas.Enabled = False
                rv_parcelas.Enabled = False
                cv_nr_parcelas.Enabled = False

            Case "P"
                txt_nr_parcelas.Text = String.Empty
                txt_nr_parcelas.Enabled = True
                rfv_nr_parcelas.Enabled = True
                cv_nr_parcelas.Enabled = True
                rv_parcelas.Enabled = False

            Case "D"
                txt_nr_parcelas.Enabled = True
                rfv_nr_parcelas.Enabled = True
                cv_nr_parcelas.Enabled = True
                txt_nr_parcelas.Text = String.Empty
                rv_parcelas.Enabled = True
                rv_parcelas.MaximumValue = Me.ViewState("nr_politica_parcelas").ToString()
                rv_parcelas.ErrorMessage = String.Concat("Para tipo de Pagamento 'Danone' o parcelamento deve ser no máximo de ", Me.ViewState("nr_politica_parcelas").ToString(), " parcelas, de acordo com a Política de Parcelas.")
                rv_parcelas.ToolTip = String.Concat("Para tipo de Pagamento 'Danone' o parcelamento deve ser no máximo de ", Me.ViewState("nr_politica_parcelas").ToString(), " parcelas, de acordo com a Política de Parcelas.")

        End Select

    End Sub

    Protected Sub btn_atualizar_totais_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)


        atualizarGridRowTotalizadores(row.RowIndex)


    End Sub

    Protected Sub img_selecionar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim rowitem As GridViewRow = gridResults.Rows.Item(ViewState.Item("id_index_item_frete"))
        Dim cbo_transportador As Anthem.DropDownList = CType(rowitem.FindControl("cbo_transportador"), Anthem.DropDownList)
        Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(rowitem.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        'Dim lbl_tipo_caminhao As Anthem.Label = CType(rowitem.FindControl("lbl_tipo_caminhao"), Anthem.Label)
        Dim lbl_total_item As Anthem.Label = CType(rowitem.FindControl("lbl_total_item"), Anthem.Label)
        Dim lbl_total_frete As Anthem.Label = CType(rowitem.FindControl("lbl_total_frete"), Anthem.Label)
        Dim lbl_valor_total As Anthem.Label = CType(rowitem.FindControl("lbl_valor_total"), Anthem.Label)
        Dim lbl_id_central_tabela_frete_veiculos As Label = CType(rowitem.FindControl("lbl_id_central_tabela_frete_veiculos"), System.Web.UI.WebControls.Label)
        Dim lbl_id_central_tabela_precos As Label = CType(rowitem.FindControl("lbl_id_central_tabela_precos"), System.Web.UI.WebControls.Label)
        Dim lbl_id_veiculo_central_compras As Label = CType(rowitem.FindControl("lbl_id_veiculo_central_compras"), System.Web.UI.WebControls.Label)
        Dim lbl_inf_frete As Label = CType(rowitem.FindControl("lbl_inf_frete"), Label)

        Dim tabelafrete As New TabelaFreteVeiculos
        tabelafrete.id_central_tabela_frete_veiculos = gridfrete.DataKeys(row.RowIndex).Value.ToString()

        Dim dsfrete As DataSet = tabelafrete.getCentralTabelaFreteVeiculos
        With dsfrete.Tables(0).Rows(0)
            txt_nr_frete.Text = .Item("nr_valor_frete").ToString
            lbl_inf_frete.Text = String.Concat("(Data cotação: ", DateTime.Parse(.Item("dt_modificacao").ToString).ToString("dd/MM/yyyy"), ")")
            'lbl_tipo_caminhao.Text = .Item("nm_veiculocentralcompras").ToString
            lbl_id_central_tabela_frete_veiculos.Text = .Item("id_central_tabela_frete_veiculos").ToString
            'lbl_id_veiculo_central_compras.Text = .Item("id_veiculocentralcompras").ToString
        End With

        gridfrete.Visible = False
        pnl_frete.Visible = False

    End Sub

    Protected Sub btn_fechar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_fechar.Click
        Me.pnl_frete.Visible = False

        ViewState.Item("id_index_item_frete") = String.Empty

    End Sub

    Protected Sub cv_pedido_itens_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pedido_itens.ServerValidate
        Try
            args.IsValid = True

            Dim lmsg As String
            Dim row As GridViewRow

            updateTotalizadores()


            If args.IsValid Then

                If txt_nr_valor_unitario.Text.Equals(String.Empty) OrElse CDec(txt_nr_valor_unitario.Text) = 0 Then
                    lmsg = "O valor unitário deve ser informado e maior que zero (0)."
                    args.IsValid = False
                End If

            End If
            If lbl_qtde_incluida.Text.Equals(String.Empty) Then
                lmsg = "Para finalizar contrato deve haver quantidade informada para as propriedades."
                args.IsValid = False
            Else
                If CDec(lbl_qtde_incluida.Text) = 0 Then
                    lmsg = "Para finalizar contrato deve haver quantidade informada para as propriedades."
                    args.IsValid = False
                Else
                    If CDec(lbl_qtde_incluida.Text) > CDec(txt_nr_qtde_total.Text) Then
                        lmsg = "A quantidade incluida é maior que o total proposto para o Fornecedor de Insumos."
                        args.IsValid = False
                    End If
                End If
            End If



            If args.IsValid = True Then
                Dim bitemincluido As Boolean = False

                For Each row In gridResults.Rows
                    'se linha visivel
                    If row.Visible = True Then
                        Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_nr_qtde As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_qtde"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim lbl_id_propriedade As Label = CType(row.FindControl("lbl_id_propriedade_grid"), System.Web.UI.WebControls.Label)
                        Dim cbo_vai_parcelar As Anthem.DropDownList = CType(row.FindControl("cbo_vai_parcelar"), Anthem.DropDownList)
                        Dim cbo_tipo_frete As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_frete"), Anthem.DropDownList)
                        Dim txt_nr_parcelas As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_parcelas"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                        'If cbo_vai_parcelar.SelectedValue = "D" AndAlso CInt(ViewState.Item("nr_politica_parcelas")) < txt_nr_parcelas.Text Then
                        '    lmsg = String.Concat("O número de parcelas informado para a Propriedade ", lbl_id_propriedade.Text, " execede o limite cadastrado para Política de Parcelas em Parâmetros do Sistema.")
                        '    args.IsValid = False
                        'End If

                        If cbo_tipo_frete.SelectedValue = "D" Then 'se for fob-d tem frete
                            If CInt(CType(row.FindControl("cbo_transportador"), Anthem.DropDownList).SelectedValue) = 0 Then
                                lmsg = "O Transportador deve ser informado para o tipo de frete FOB-D " + " da Propriedade " + lbl_id_propriedade.Text + "."
                                args.IsValid = False
                            End If

                            If txt_nr_frete.Text.Equals(String.Empty) OrElse CDec(txt_nr_frete.Text) = 0 Then
                                lmsg = "O Valor do Frete deve ser informado para o tipo de frete FOB-D " + " da Propriedade " + lbl_id_propriedade.Text + "."
                                args.IsValid = False
                            End If
                        End If
                        If CType(row.FindControl("cbo_tipo_medida"), Anthem.DropDownList).SelectedValue = "S" Then
                            If txt_nr_sacaria.Text.Equals(String.Empty) Then
                                lmsg = "O valor da Sacaria deve ser informado para Embalagem Sacaria " + " da Propriedade " + lbl_id_propriedade.Text + "."
                                args.IsValid = False
                            End If

                        End If
                        If txt_nr_qtde.Text.Equals(String.Empty) OrElse CDec(txt_nr_qtde.Text) = 0 Then
                            lmsg = "A quantidade deve ser informada para a Propriedade " + lbl_id_propriedade.Text + "."
                            args.IsValid = False
                        End If
                        bitemincluido = True


                    End If

                Next
                If bitemincluido = False Then
                    lmsg = "Adicione propriedade para prosseguir com a inclusão do pedido."
                    args.IsValid = False

                End If

            End If



            If args.IsValid = False Then
                Me.messageControl.Alert(lmsg)


            End If

        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_nr_frete_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim cbo_transportador As Anthem.DropDownList = CType(row.FindControl("cbo_transportador"), Anthem.DropDownList)
        Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        Dim lbl_tipo_caminhao As Anthem.Label = CType(row.FindControl("lbl_tipo_caminhao"), Anthem.Label)
        Dim lbl_total_item As Anthem.Label = CType(row.FindControl("lbl_total_item"), Anthem.Label)
        Dim lbl_total_frete As Anthem.Label = CType(row.FindControl("lbl_total_frete"), Anthem.Label)
        Dim lbl_valor_total As Anthem.Label = CType(row.FindControl("lbl_valor_total"), Anthem.Label)
        Dim lbl_id_central_tabela_frete_veiculos As Label = CType(row.FindControl("lbl_id_central_tabela_frete_veiculos"), System.Web.UI.WebControls.Label)
        Dim lbl_id_veiculo_central_compras As Label = CType(row.FindControl("lbl_id_veiculo_central_compras"), System.Web.UI.WebControls.Label)
        Dim lbl_inf_frete As Label = CType(row.FindControl("lbl_inf_frete"), Label)
        Dim btn_lupa_frete As Anthem.ImageButton = CType(row.FindControl("btn_lupa_frete_valor"), Anthem.ImageButton)

        'limpa o que veio da lupa
        lbl_inf_frete.Text = String.Empty
        'lbl_tipo_caminhao.Text = String.Empty
        lbl_id_central_tabela_frete_veiculos.Text = String.Empty
        'lbl_id_veiculo_central_compras.Text = String.Empty
        atualizarGridRowTotalizadores(row.RowIndex)
    End Sub

    Protected Sub cbo_tipo_frete_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim cbo_transportador As Anthem.DropDownList = CType(row.FindControl("cbo_transportador"), Anthem.DropDownList)
        Dim cbo_tipo_frete As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_frete"), Anthem.DropDownList)
        Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        Dim lbl_total_item As Anthem.Label = CType(row.FindControl("lbl_total_item"), Anthem.Label)
        Dim lbl_total_frete As Anthem.Label = CType(row.FindControl("lbl_total_frete"), Anthem.Label)
        Dim lbl_valor_total As Anthem.Label = CType(row.FindControl("lbl_valor_total"), Anthem.Label)
        Dim lbl_id_central_tabela_frete_veiculos As Label = CType(row.FindControl("lbl_id_central_tabela_frete_veiculos"), System.Web.UI.WebControls.Label)
        Dim lbl_inf_frete As Label = CType(row.FindControl("lbl_inf_frete"), Label)
        Dim btn_lupa_frete As Anthem.ImageButton = CType(row.FindControl("btn_lupa_frete_valor"), Anthem.ImageButton)
        Dim rf_transportador As Anthem.RequiredFieldValidator = CType(row.FindControl("rf_transportador"), Anthem.RequiredFieldValidator)
        Dim rf_frete As Anthem.RequiredFieldValidator = CType(row.FindControl("rf_frete"), Anthem.RequiredFieldValidator)

        txt_nr_frete.Text = String.Empty
        lbl_inf_frete.Text = String.Empty
        lbl_id_central_tabela_frete_veiculos.Text = String.Empty
        cbo_transportador.SelectedValue = 0

        If cbo_tipo_frete.SelectedValue = "D" Then
            txt_nr_frete.Enabled = True
            cbo_transportador.Enabled = True
            btn_lupa_frete.Enabled = True
            btn_lupa_frete.ImageUrl = "~/img/lupa.gif"
            rf_frete.Enabled = True
            rf_transportador.Enabled = True
        Else
            txt_nr_frete.Enabled = False
            cbo_transportador.Enabled = False
            btn_lupa_frete.Enabled = False
            btn_lupa_frete.ImageUrl = "~/img/lupa_desabilitada.gif"
            rf_frete.Enabled = False
            rf_transportador.Enabled = False
        End If

        'If (Me.ViewState("gridLinhasAdicionadas") IsNot Nothing) Then

        '    Dim pessoa As New Pessoa
        '    pessoa.id_situacao = 1
        '    pessoa.st_transportador_central = "S"
        '    Dim dstransportador As DataSet = pessoa.getTransportadorCentralByFilters()

        '    Dim row As GridViewRow
        '    For Each row In gridResults.Rows
        '        If row.Visible = True Then
        '            Dim lbl_total_item As Anthem.Label = CType(row.FindControl("lbl_total_item"), Anthem.Label)
        '            Dim cbo_transportador As Anthem.DropDownList = CType(row.FindControl("cbo_transportador"), Anthem.DropDownList)
        '            Dim id_transportador As Anthem.Label = CType(row.FindControl("id_transportador"), Anthem.Label)
        '            Dim lbl_tipo_caminhao As Anthem.Label = CType(row.FindControl("lbl_tipo_caminhao"), Anthem.Label)
        '            Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        '            Dim lbl_total_frete As Anthem.Label = CType(row.FindControl("lbl_total_frete"), Anthem.Label)
        '            Dim lbl_valor_total As Anthem.Label = CType(row.FindControl("lbl_valor_total"), Anthem.Label)
        '            Dim lbl_id_central_tabela_frete_veiculos As Anthem.Label = CType(row.FindControl("lbl_id_central_tabela_frete_veiculos"), Anthem.Label)
        '            Dim lbl_id_veiculo_central_compras As Anthem.Label = CType(row.FindControl("lbl_id_veiculo_central_compras"), Anthem.Label)
        '            Dim lbl_inf_frete As Anthem.Label = CType(row.FindControl("lbl_inf_frete"), Anthem.Label)
        '            Dim trfrete As HtmlTableRow = CType(row.FindControl("tr_frete"), HtmlTableRow)

        '            txt_nr_frete.Text = String.Empty
        '            lbl_inf_frete.Text = String.Empty
        '            lbl_tipo_caminhao.Text = String.Empty
        '            lbl_id_central_tabela_frete_veiculos.Text = String.Empty
        '            lbl_id_veiculo_central_compras.Text = String.Empty
        '            lbl_valor_total.Text = lbl_total_item.Text
        '            lbl_total_frete.Text = String.Empty
        '            id_transportador.Text = String.Empty

        '            If cbo_pedido_indireto.SelectedValue.Equals("N") AndAlso cbo_tipo_frete.SelectedValue.Equals("D") Then
        '                trfrete.Visible = True

        '                'transportador central
        '                cbo_transportador.DataSource = dstransportador
        '                cbo_transportador.DataTextField = "nm_pessoa"
        '                cbo_transportador.DataValueField = "id_pessoa"
        '                cbo_transportador.DataBind()
        '                cbo_transportador.Items.Insert(0, New ListItem("[Selecione]", 0))
        '                cbo_transportador.SelectedValue = "0"

        '            Else
        '                trfrete.Visible = False
        '            End If

        '        End If
        '    Next

        'End If


    End Sub

    Protected Sub txt_nr_qtde_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txt_nr_qtde As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_qtde"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        Dim lbl_qtde As Label = CType(row.FindControl("lbl_qtde"), Label)

        'pega a quantidade anteior
        Dim lnr_qtde_ant As Decimal = 0
        Dim lnr_qtde_incluida As Decimal = 0
        Dim lnr_qtde_total As Decimal = 0
        If lbl_qtde.Text.Equals(String.Empty) Then
            lnr_qtde_ant = 0
        Else
            lnr_qtde_ant = CDec(lbl_qtde.Text)
        End If
        If txt_nr_qtde_total.Text = String.Empty Then
            lnr_qtde_total = 0
        Else
            lnr_qtde_total = CDec(txt_nr_qtde_total.Text)
        End If

        If lbl_qtde_incluida.Text = String.Empty Then
            lnr_qtde_incluida = 0
        Else
            lnr_qtde_incluida = CDec(lbl_qtde_incluida.Text)
        End If

        'se esta mudando qtde para zero ou vazio, não precio somar valor à qtde incluidas apenas subtrair
        If txt_nr_qtde.Text.Equals(String.Empty) OrElse CDec(txt_nr_qtde.Text).Equals(0) Then
            lnr_qtde_incluida = lnr_qtde_incluida - lnr_qtde_ant
            lbl_qtde.Text = "0"
        Else
            lnr_qtde_incluida = lnr_qtde_incluida - lnr_qtde_ant + CDec(txt_nr_qtde.Text)
            lbl_qtde.Text = txt_nr_qtde.Text 'atualiza a quatidade do grid escondida para o novo valor da qtde
        End If
        If lnr_qtde_incluida = 0 Then
            lbl_qtde_incluida.Text = String.Empty
        Else
            lbl_qtde_incluida.Text = FormatNumber(lnr_qtde_incluida, 4).ToString

            If lnr_qtde_total > lnr_qtde_incluida Then
                lbl_qtde_incluida.ForeColor = Drawing.Color.Blue
            End If
            If lnr_qtde_incluida > lnr_qtde_total Then
                lbl_qtde_incluida.ForeColor = Drawing.Color.Red
            End If

        End If

        atualizarGridRowTotalizadores(row.RowIndex)

    End Sub


    Protected Sub cv_validar_inclusao_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_validar_inclusao.ServerValidate
        If Page.IsValid Then
            Try
                args.IsValid = True

                Dim lmsg As String
                Dim row As GridViewRow

                If ViewState.Item("id_fornecedor").ToString.Trim = "0" Then
                    args.IsValid = False
                    lmsg = "O parceiro deve ser informado para prosseguir com a inclusão do item."
                End If

                'verifica se o item esta associado ao parceiro
                Dim itemparceiro As New ItemParceiro
                itemparceiro.id_item = cbo_item.SelectedValue
                itemparceiro.id_fornecedor = ViewState.Item("id_fornecedor")

                If itemparceiro.getCentralItemParceiro.Tables(0).Rows.Count = 0 Then
                    lmsg = "O Fornecedor informado não está associado ao Item " + cbo_item.SelectedItem.Text + "."
                    args.IsValid = False
                End If

                If args.IsValid Then

                    If txt_nr_valor_unitario.Text.Equals(String.Empty) OrElse CDec(txt_nr_valor_unitario.Text) = 0 Then
                        lmsg = "O valor unitário deve ser informado e maior que zero (0)."
                        args.IsValid = False
                    End If

                End If

                If args.IsValid = True AndAlso CDate(String.Concat("01/", txt_dt_inicio.Text)) < CDate(String.Concat("01/", DateTime.Now.ToString("MM/yyyy"))) Then
                    args.IsValid = False
                    lmsg = "A data de referência de início do período deve ser maior ou igual a referência atual."
                End If



                If args.IsValid = False Then
                    Me.messageControl.Alert(lmsg)
                End If

            Catch ex As Exception
                Me.messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub cv_incluirpropriedade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_incluirpropriedade.ServerValidate
        If Page.IsValid Then
            Try

                args.IsValid = True

                Dim lmsg As String

                If gridPropriedades.SelectedIndex = -1 Then
                    'se nao tem nenhuma propriedade selecionada
                    lmsg = "Selecione uma propriedade para continuar!"
                    args.IsValid = False
                End If

                'If cbo_ip_vai_parcelar.SelectedValue = "D" AndAlso CInt(ViewState.Item("nr_politica_parcelas")) < CInt(txt_ip_nr_parcelas.Text) Then
                '    lmsg = String.Concat("O número de parcelas informado para a Propriedade execede o limite cadastrado para Política de Parcelas em Parâmetros do Sistema.")
                '    args.IsValid = False
                'End If
                If cbo_ip_vai_parcelar.SelectedValue = "N" AndAlso CInt(txt_ip_nr_parcelas.Text) > 1 Then
                    lmsg = String.Concat("Para tipo de parcelamento à vista o número de parcela de ser 1.")
                    args.IsValid = False
                End If
                If cbo_ip_tipo_medida.SelectedValue = "S" Then
                    If txt_nr_sacaria.Text.Equals(String.Empty) Then
                        lmsg = "Para seleção de embalagem 'SACARIA', o valor da Sacaria deve ser informado para o Prdido em Grupo."
                        args.IsValid = False
                    End If

                End If
                'If txt_nr_qtde.Text.Equals(String.Empty) OrElse CDec(txt_nr_qtde.Text) = 0 Then
                '    lmsg = "A quantidade deve ser informada para a Propriedade " + lbl_id_propriedade.Text + "."
                '    args.IsValid = False
                'End If

                If args.IsValid Then
                    Dim contrato As New CentralContratoPropriedade
                    contrato.id_central_contrato = ViewState.Item("id_central_contrato")
                    contrato.id_propriedade = ViewState.Item("id_propriedade")
                    If contrato.getCentralContratoPropriedadeGridInfGrupo.Tables(0).Rows.Count > 0 Then
                        lmsg = "A propriedade selecionada já está incluida ao Grupo de Pedido."
                        args.IsValid = False
                    End If

                End If
                If args.IsValid = False Then
                    Me.messageControl.Alert(lmsg)
                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub cv_salvar_inf_pedidos_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_salvar_inf_pedidos.ServerValidate
        Try
            args.IsValid = True

            Dim lmsg As String
            Dim row As GridViewRow

            Dim bTemLinhas As Boolean = False

            For Each row In gridResults.Rows
                'se linha visivel
                Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_nr_qtde As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_qtde"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim lbl_id_propriedade As Label = CType(row.FindControl("lbl_id_propriedade_grid"), System.Web.UI.WebControls.Label)
                Dim cbo_vai_parcelar As Anthem.DropDownList = CType(row.FindControl("cbo_vai_parcelar"), Anthem.DropDownList)
                Dim cbo_tipo_frete As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_frete"), Anthem.DropDownList)
                Dim txt_nr_parcelas As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_parcelas"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                'If cbo_vai_parcelar.SelectedValue = "D" AndAlso CInt(ViewState.Item("nr_politica_parcelas")) < txt_nr_parcelas.Text Then
                '    lmsg = String.Concat("O número de parcelas informado para a Propriedade ", lbl_id_propriedade.Text, " execede o limite cadastrado para Política de Parcelas em Parâmetros do Sistema.")
                '    args.IsValid = False
                'End If

                If cbo_tipo_frete.SelectedValue = "D" Then 'se for fob-d tem frete
                    If CInt(CType(row.FindControl("cbo_transportador"), Anthem.DropDownList).SelectedValue) = 0 Then
                        lmsg = "O Transportador deve ser informado para o tipo de frete FOB-D " + " da Propriedade " + lbl_id_propriedade.Text + "."
                        args.IsValid = False
                    End If

                    If txt_nr_frete.Text.Equals(String.Empty) OrElse CDec(txt_nr_frete.Text) = 0 Then
                        lmsg = "O Valor do Frete deve ser informado para o tipo de frete FOB-D " + " da Propriedade " + lbl_id_propriedade.Text + "."
                        args.IsValid = False
                    End If

                End If
                If CType(row.FindControl("cbo_tipo_medida"), Anthem.DropDownList).SelectedValue = "S" Then
                    If txt_nr_sacaria.Text.Equals(String.Empty) Then
                        lmsg = "O valor da Sacaria deve ser informado para o Grupo de Pedido. Foi selecionada Embalagem Sacaria " + " para Propriedade " + lbl_id_propriedade.Text + "."
                        args.IsValid = False
                    End If

                End If
                If txt_nr_qtde.Text.Equals(String.Empty) OrElse CDec(txt_nr_qtde.Text) = 0 Then
                    lmsg = "A quantidade deve ser informada para a Propriedade " + lbl_id_propriedade.Text + "."
                    args.IsValid = False
                End If

                bTemLinhas = True
            Next

            If args.IsValid = True AndAlso bTemLinhas = False Then
                args.IsValid = False
                lmsg = "Não há propriedades incluidas."
            End If

            If args.IsValid = False Then
                Me.messageControl.Alert(lmsg)


            End If

        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub btn_abrirpedidocontrato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_abrirpedidocontrato.Click
        If Page.IsValid Then
            Try

                Dim centralcontrato As New CentralContrato

                centralcontrato.id_estabelecimento = cbo_estabelecimento.SelectedValue
                centralcontrato.ds_descricao_contrato = txt_descricao.Text
                centralcontrato.dt_inicio_contrato = String.Concat("01/", txt_dt_inicio.Text)
                centralcontrato.dt_fim_contrato = centralcontrato.dt_inicio_contrato
                centralcontrato.id_fornecedor = cbo_fornecedor.SelectedValue
                centralcontrato.id_item = cbo_item.SelectedValue
                centralcontrato.nr_quantidade_total = CDec(txt_nr_qtde_total.Text)
                centralcontrato.nr_valor_unitario = CDec(txt_nr_valor_unitario.Text)
                centralcontrato.nr_sacaria = CDec(txt_nr_sacaria.Text)
                centralcontrato.id_situacao = 1
                centralcontrato.id_situacao_central_contrato = 1 'aberto
                centralcontrato.st_tipo_central_contrato = "P"
                centralcontrato.id_modificador = Session("id_login")

                ViewState.Item("id_central_contrato") = centralcontrato.insertCentralContrato()

                Response.Redirect("frm_central_pedido_abertura_grupo.aspx?id_central_contrato=" + ViewState.Item("id_central_contrato").ToString())


            Catch ex As Exception
                Me.messageControl.Alert(ex.Message)

            End Try
        End If

    End Sub

    Protected Sub btn_incluirpropriedade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluirpropriedade.Click
        If Page.IsValid Then
            Try
                If ViewState.Item("id_propriedade") <> 0 Then

                    Dim lnAuxDiferenca As Decimal
                    Dim lnAux As Int16
                    Dim lvalorqtde As Decimal
                    Dim lvalorqtdetotal As Decimal
                    Dim lround As Int32
                    Dim contratoprop As New CentralContratoPropriedade

                    contratoprop.id_central_contrato = ViewState.Item("id_central_contrato")
                    contratoprop.id_propriedade = ViewState.Item("id_propriedade")
                    contratoprop.id_propriedade_matriz = ViewState.Item("id_propriedade_matriz")
                    contratoprop.id_produtor = ViewState.Item("id_produtor")
                    contratoprop.st_tipo_medida = cbo_ip_tipo_medida.SelectedValue
                    contratoprop.ds_tipo_frete = cbo_ip_tipofrete.SelectedValue
                    If cbo_ip_vai_parcelar.SelectedValue = "N" Then
                        contratoprop.st_tipo_parcelamento = "N"
                        contratoprop.nr_parcelas = 1
                    Else
                        contratoprop.st_tipo_parcelamento = cbo_ip_vai_parcelar.SelectedValue
                        contratoprop.nr_parcelas = txt_ip_nr_parcelas.Text
                    End If

                    contratoprop.nr_qtde = CDec(txt_ip_qtde_total_propriedade.Text)
                    contratoprop.dt_inicio = String.Concat("01/", txt_dt_inicio.Text)

                    contratoprop.id_situacao = 1
                    contratoprop.id_modificador = Session("id_login")

                    ViewState.Item("id_central_contrato_propriedade") = contratoprop.insertCentralContratoPropriedadeGrupo()

                    'limpa campos inclusao
                    txt_ip_qtde_total_propriedade.Text = String.Empty
                    cbo_ip_tipo_medida.SelectedValue = String.Empty
                    cbo_ip_vai_parcelar.SelectedValue = "N"
                    txt_ip_nr_parcelas.Text = 1
                    cbo_ip_tipofrete.SelectedValue = String.Empty

                    gridPropriedades.SelectedIndex = -1
                    Me.ViewState.Item("id_propriedade") = 0
                    Me.ViewState.Item("id_propriedade_matriz") = 0
                    Me.ViewState.Item("id_produtor") = 0
                    Me.ViewState.Item("id_estado_destino") = 0
                    Me.ViewState.Item("id_cidade_destino") = 0
                    ViewState.Item("limitedisponivel") = 0
                    ViewState.Item("indexgridpropriedadeprincipal") = 0
                    Me.lbl_nm_pessoa.Text = String.Empty
                    Me.hf_id_produtor.Value = String.Empty
                    Me.lbl_ds_telefone.Text = String.Empty
                    Me.lbl_acordo_aquisicao_insumos.Text = String.Empty
                    Me.lbl_cluster.Text = String.Empty
                    Me.lbl_ds_email.Text = String.Empty
                    Me.lbl_contrato.Text = String.Empty
                    Me.lbl_dt_ini_contrato.Text = String.Empty
                    Me.lbl_dt_fim_contrato_sel.Text = String.Empty
                    Me.lbl_dt_rescisao_contrato.Text = String.Empty

                    updateTotalizadores()
                    loadGridPropriedades()
                    'loadGridQtdes()
                    loadGridPropriedadesInf()
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If
    End Sub
    Private Sub updateTotalizadores()

        Dim centralcontrato As New CentralContrato
        centralcontrato.id_central_contrato = CInt(ViewState.Item("id_central_contrato"))
        lbl_qtde_incluida.Text = FormatNumber(centralcontrato.getCentralContratoTotalQtde, 4)

        If Not lbl_qtde_incluida.Text.Equals(String.Empty) Then
            If Not txt_nr_qtde_total.Text.Equals(String.Empty) Then
                If CDec(lbl_qtde_incluida.Text) > CDec(txt_nr_qtde_total.Text) Then
                    lbl_qtde_incluida.ForeColor = Drawing.Color.Red
                End If
            End If
        End If

    End Sub
    Private Sub loadGridPropriedadesInf()
        Try

            Dim contratopropriedade As New CentralContratoPropriedade

            contratopropriedade.id_central_contrato = CInt(ViewState.Item("id_central_contrato").ToString)
            Dim dscontratoprop As DataSet = contratopropriedade.getCentralContratoPropriedadeGridInfGrupo

            If dscontratoprop.Tables(0).Rows.Count = 0 Then
                'btn_salvar_infpedidos.Enabled = False
                Dim dr As DataRow = dscontratoprop.Tables(0).NewRow()
                dscontratoprop.Tables(0).Rows.InsertAt(dr, 0)
                Me.ViewState.Item("gridresults") = 0
                ViewState.Item("TemPropriedade") = False
                Me.gridResults.Visible = True
                Me.gridResults.DataSource = Helper.getDataView(dscontratoprop.Tables(0), "")
                Me.gridResults.DataBind()
                Me.gridResults.Rows(0).Cells.Clear()
                Me.gridResults.Rows(0).Cells.Add(New TableCell())
                Me.gridResults.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                Me.gridResults.Rows(0).Cells(0).Text = "Inclua uma propriedade ao contrato para continuar."
                Me.gridResults.Rows(0).Cells(0).ColumnSpan = 2
            Else
                ViewState.Item("gridresults") = 1
                'btn_salvar_infpedidos.Enabled = True
                ViewState.Item("TemPropriedade") = True

                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscontratoprop.Tables(0), "")
                gridResults.DataBind()

                ''Calculate Sum and display in Footer Row
                'Dim total As Decimal = dscontratoprop.Tables(0).AsEnumerable().Sum(Function(row) row.Field(Of Decimal)("Price"))
                'gridqtdes.FooterRow.Cells(1).Text = "Total"
                'gridqtdes.FooterRow.Cells(1).HorizontalAlign = HorizontalAlign.Right
                'gridqtdes.FooterRow.Cells(2).Text = total.ToString("N2")

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub btn_salvar_infpedidos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salvar_infpedidos.Click
        If Page.IsValid Then
            Try

                salvarInformacaoPedidos()
                updateTotalizadores()
                loadGridPropriedadesInf()


            Catch ex As Exception
                Me.messageControl.Alert(ex.Message)

            End Try
        End If
    End Sub
    Private Sub updateData()

        Try

            Dim contrato As New CentralContrato

            contrato.id_central_contrato = ViewState.Item("id_central_contrato")
            contrato.ds_descricao_contrato = txt_descricao.Text
            contrato.nr_quantidade_total = CDec(txt_nr_qtde_total.Text)
            contrato.nr_valor_unitario = CDec(txt_nr_valor_unitario.Text)
            contrato.nr_sacaria = CDec(txt_nr_sacaria.Text)
            contrato.id_modificador = Session("id_login")
            contrato.updateCentralContrato()

            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 3 'alteracao
            usuariolog.id_menu_item = 233
            usuariolog.ds_nm_processo = "Central Pedido Grupo - Grupo"
            usuariolog.id_nr_processo = ViewState.Item("id_central_contrato")

            usuariolog.insertUsuarioLog()
            'fran 08/12/2020 f dango

            messageControl.Alert("Registro alterado com sucesso.")

            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub salvarInformacaoPedidos()
        If Page.IsValid Then
            Try

                Dim row As GridViewRow
                Dim lvaloritem As Decimal = 0
                Dim lvalorfrete As Decimal = 0
                Dim lvalortotalpedidofornecedor As Decimal = 0
                Dim lvalortotalpedidotransortador As Decimal = 0

                Dim contratoprop As New CentralContratoPropriedade
                contratoprop.id_modificador = Session("id_login")
                contratoprop.id_central_contrato = ViewState.Item("id_central_contrato")

                For Each row In gridResults.Rows
                    Dim cbo_tipo_medida As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_medida"), Anthem.DropDownList)
                    Dim txt_nr_qtde As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_qtde"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim cbo_tipo_frete As Anthem.DropDownList = CType(row.FindControl("cbo_tipo_frete"), Anthem.DropDownList)
                    Dim cbo_transportador As Anthem.DropDownList = CType(row.FindControl("cbo_transportador"), Anthem.DropDownList)
                    Dim txt_nr_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim lbl_id_central_tabela_frete_veiculos As Label = CType(row.FindControl("lbl_id_central_tabela_frete_veiculos"), Label)
                    Dim cbo_vai_parcelar As Anthem.DropDownList = CType(row.FindControl("cbo_vai_parcelar"), Anthem.DropDownList)
                    Dim txt_nr_parcelas As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_parcelas"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                    Dim lbl_id_propriedade_grid As Label = CType(row.FindControl("lbl_id_propriedade_grid"), Label)

                    contratoprop.id_central_contrato_propriedade = gridResults.DataKeys(row.RowIndex).Value
                    contratoprop.id_propriedade = lbl_id_propriedade_grid.Text

                    contratoprop.st_tipo_medida = cbo_tipo_medida.SelectedValue
                    contratoprop.st_tipo_parcelamento = cbo_vai_parcelar.SelectedValue
                    contratoprop.nr_parcelas = txt_nr_parcelas.Text
                    contratoprop.ds_tipo_frete = cbo_tipo_frete.SelectedValue
                    contratoprop.nr_qtde = CDec(txt_nr_qtde.Text)

                    If cbo_tipo_frete.SelectedValue = "D" Then
                        contratoprop.id_transportador = cbo_transportador.SelectedValue
                        contratoprop.nr_valor_frete = CDec(txt_nr_frete.Text)
                        'se informação sobre tabela de frete for vazia, significa que nao uilizou tabela de frete do cadastro
                        If lbl_id_central_tabela_frete_veiculos.Text.Equals(String.Empty) Then
                            contratoprop.id_central_tabela_frete_veiculos = "0"
                        Else
                            contratoprop.id_central_tabela_frete_veiculos = lbl_id_central_tabela_frete_veiculos.Text
                        End If
                    Else
                        contratoprop.id_transportador = 0
                        contratoprop.nr_valor_frete = 0
                        contratoprop.id_central_tabela_frete_veiculos = "0"
                    End If

                    contratoprop.updateCentralContratoPropriedadeGrupo()
                Next


            Catch ex As Exception
                Me.messageControl.Alert(ex.Message)

            End Try
        End If

    End Sub
    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        Try
            updateData()

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Select Case ViewState.Item("tela").ToString
            Case String.Empty
                Response.Redirect("lst_central_contrato.aspx")

            Case "lst_central_pedido_reabrir.aspx"
                Response.Redirect("lst_central_pedido_reabrir.aspx")
            Case Else
                Response.Redirect(ViewState.Item("tela").ToString)
        End Select

    End Sub
    Private Sub loadGridPedidos()
        Try

            Dim contratopropriedade As New CentralContratoPropriedade

            contratopropriedade.id_central_contrato = CInt(ViewState.Item("id_central_contrato").ToString)
            Dim dscontratoprop As DataSet = contratopropriedade.getCentralContratoPropriedadePedidos

            If dscontratoprop.Tables(0).Rows.Count = 0 Then
                gridpedidos.Visible = False
                messageControl.Alert("Não existem pedidos para propriedade selecionada!")
            Else
                gridpedidos.Visible = True

                gridpedidos.Visible = True
                gridpedidos.DataSource = Helper.getDataView(dscontratoprop.Tables(0), "")
                gridpedidos.DataBind()


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridpedidos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridpedidos.RowDataBound

        Try
            If (e.Row.RowType = DataControlRowType.DataRow) Then
                If (e.Row.RowState <> (DataControlRowState.Alternate Or DataControlRowState.Edit) AndAlso e.Row.RowState <> DataControlRowState.Edit) Then
                    Dim hl_id_pedido As Anthem.HyperLink = CType(e.Row.FindControl("hl_id_pedido"), Anthem.HyperLink)
                    Dim hl_id_pedido_frete As Anthem.HyperLink = CType(e.Row.FindControl("hl_id_pedido_frete"), Anthem.HyperLink)
                    'lbl_nr_valor_mensal_estimado.Text = saldoDisponivel.nr_valor_faturamento.ToString
                    If Not hl_id_pedido.Text = String.Empty Then

                        hl_id_pedido.Visible = True
                        hl_id_pedido.NavigateUrl = String.Format("frm_central_pedido.aspx?id_central_pedido={0}", hl_id_pedido.Text)

                        If Not hl_id_pedido_frete.Text = String.Empty Then

                            hl_id_pedido_frete.Visible = True
                            hl_id_pedido_frete.NavigateUrl = String.Format("frm_central_pedido.aspx?id_central_pedido={0}", hl_id_pedido_frete.Text)
                        Else
                            hl_id_pedido_frete.Visible = False
                        End If

                    Else
                        hl_id_pedido.Visible = False
                    End If

                    Dim situacao As DataControlFieldCell = CType(e.Row.Cells(7), DataControlFieldCell)

                    ' If (Not situacao.Text.Equals(String.Empty) And Not situacao.Text = "&nbsp;") Then
                    If situacao.Text.Trim.Equals("Em Aprovação") Then
                        situacao.BackColor = Drawing.Color.Yellow
                        'situacao.ForeColor = Drawing.Color.Red
                    End If

                End If
            End If
        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_email_produtor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email_produtor.Click
        Dim lassunto As String
        Dim lcorpo As String
        Dim arqTemp As StreamReader
        Dim lcaminhoservidor As String = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString()  ' Na Danone os relatórios ficam aonde estãqo as páginas
        'Dim lcaminhoservidor As String = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()
        Dim lemail_parceiro As String
        Dim ldatahj As Date = DateTime.Parse(Now).ToString("dd/MM/yyyy")
        Dim lemail_parceiro2 As String = String.Empty


        Dim contratoprop As New CentralContratoPropriedade
        contratoprop.id_central_contrato = ViewState.Item("id_central_contrato")

        Dim dscontratoprop As DataSet = contratoprop.getCentralContratoPropriedadeQtde
        Dim rowprop As DataRow

        Try

            'para cada propriedade do contrato
            For Each rowprop In dscontratoprop.Tables(0).Rows

                Dim propriedade As New Propriedade(Convert.ToInt32(rowprop.Item("id_propriedade").ToString))
                Dim produtor As New Pessoa(Convert.ToInt32(rowprop.Item("id_pessoa").ToString))
                Dim fornecedor As New Pessoa(Convert.ToInt32(rowprop.Item("id_fornecedor").ToString))

                lemail_parceiro = produtor.ds_email
                If lemail_parceiro.Equals(String.Empty) Then
                    If Not produtor.ds_email2 Is Nothing Then
                        lemail_parceiro = produtor.ds_email2
                    Else
                        lemail_parceiro = String.Empty
                    End If
                Else
                    If Not produtor.ds_email2 Is Nothing Then 'se nao for nothing, joga o valor no para2
                        lemail_parceiro2 = produtor.ds_email2
                    End If
                End If

                If Not lemail_parceiro.Equals(String.Empty) Then
                    lassunto = String.Concat("DANONE - Negociação em Grupo ", "Nr ", ViewState.Item("id_central_contrato").ToString)
                    arqTemp = New StreamReader(lcaminhoservidor & "\central_pedido_email_produtor_contrato.HTML", Encoding.UTF7)
                    lcorpo = ""
                    Do While Not arqTemp.EndOfStream
                        lcorpo = lcorpo & arqTemp.ReadLine
                    Loop

                    lcorpo = Replace(lcorpo, "NEGOCIAÇÃO DE CONTRATO", "Negociação em Grupo")

                    'lcorpo = Replace(lcorpo, "$nm_estabelecimento", ViewState.Item("nm_estabelecimento").ToString)
                    lcorpo = Replace(lcorpo, "$dt_hoje", String.Concat(Format(ldatahj, "dd").ToString, " de ", Format(ldatahj, "MMMM").ToString, " de ", Format(ldatahj, "yyyy").ToString & "."))
                    lcorpo = Replace(lcorpo, "$nm_parceiro", fornecedor.nm_pessoa)
                    lcorpo = Replace(lcorpo, "$nm_produtor", produtor.nm_pessoa)
                    lcorpo = Replace(lcorpo, "$cd_produtor", produtor.cd_pessoa)
                    lcorpo = Replace(lcorpo, "$nm_propriedade", propriedade.nm_propriedade)
                    lcorpo = Replace(lcorpo, "$id_propriedade", propriedade.id_propriedade)
                    lcorpo = Replace(lcorpo, "$prodfone3", produtor.ds_telefone_1)
                    lcorpo = Replace(lcorpo, "$prodfone4", produtor.ds_telefone_2)

                    'Dim pedido As New Pedido
                    'pedido.id_central_pedido = Convert.ToInt32(rowprop.Item("id_central_pedido"))
                    'Dim dsgrid As DataSet = pedido.getCentralPedidoEmailParceiroItens()
                    'With dsgrid.Tables(0).Rows(0)
                    '    lcorpo = Replace(lcorpo, "$nm_item", .Item("nm_item").ToString)
                    '    lcorpo = Replace(lcorpo, "$nr_preco_unitario", FormatCurrency(.Item("nr_valor_unitario"), 2).ToString)
                    '    lcorpo = Replace(lcorpo, "$nr_preco_sacaria", FormatCurrency(.Item("nr_sacaria"), 2).ToString)
                    '    If .Item("ds_tipo_frete").ToString = "C" Then
                    '        lcorpo = Replace(lcorpo, "$ds_tipo_frete", "CIF - Entregue na fazenda")
                    '    Else
                    '        If .Item("ds_tipo_frete").ToString = "D" Then
                    '            lcorpo = Replace(lcorpo, "$ds_tipo_frete", "FOB-D - A retirar (transporte Danone)")
                    '        Else
                    '            lcorpo = Replace(lcorpo, "$ds_tipo_frete", "FOB-I - A retirar (transporte Produtor)")
                    '        End If

                    '    End If
                    '    lcorpo = Replace(lcorpo, "$ds_tipo_medida", .Item("ds_tipo_medida").ToString)

                    'End With
                    Dim lassuntoaux As String = String.Empty
                    Dim lnmmedida As String = String.Empty
                    Dim ccontrato As New CentralContratoPropriedade
                    ccontrato.id_central_contrato = Convert.ToInt32(ViewState.Item("id_central_contrato"))
                    ccontrato.id_propriedade = Convert.ToInt32(rowprop.Item("id_propriedade"))
                    Dim dscontrato As DataSet = ccontrato.getCentralContratoPropriedadePedidos()
                    With dscontrato.Tables(0).Rows(0)
                        lcorpo = Replace(lcorpo, "$nm_item", .Item("nm_item").ToString)
                        lassuntoaux = String.Concat(.Item("nm_item").ToString, " - ", Left(fornecedor.nm_abreviado.ToString, 20))
                        lnmmedida = .Item("nm_unidade_medida").ToString

                        lcorpo = Replace(lcorpo, "$nr_preco_unitario", FormatCurrency(.Item("nr_valor_unitario"), 2).ToString)
                        lcorpo = Replace(lcorpo, "$nr_preco_sacaria", FormatCurrency(.Item("nr_sacaria"), 2).ToString)
                        If .Item("ds_tipofrete").ToString = "C" Then
                            lcorpo = Replace(lcorpo, "$ds_tipo_frete", "CIF - Entregue na fazenda")
                        Else
                            If .Item("ds_tipofrete").ToString = "D" Then
                                lcorpo = Replace(lcorpo, "$ds_tipo_frete", "FOB-D - A retirar (transporte Danone)")
                            Else
                                lcorpo = Replace(lcorpo, "$ds_tipo_frete", "FOB-I - A retirar (transporte Produtor)")
                            End If

                        End If
                        lcorpo = Replace(lcorpo, "$ds_tipo_medida", .Item("ds_nm_tipo_medida").ToString)

                    End With


                    Dim row As DataRow
                    Dim ltable As String = String.Empty
                    Dim i As Integer = 1
                    Dim lcor As String = String.Empty
                    Dim lnrqtde As Decimal = 0
                    For Each row In dscontrato.Tables(0).Rows
                        If i Mod 2 = 0 Then
                            'se linha par
                            lcor = "white"
                        Else
                            lcor = "#EFF3FB"
                        End If
                        ltable = ltable & "<tr><td style='border-top: 1px solid;  text-align: center; background-color:" & lcor & ";'>" & UCase(DateTime.Parse(row.Item("dt_pedido")).ToString("MMM/yyyy")) & "</td>"
                        ltable = ltable & "<td style='border-top: 1px solid;  border-left: 1px solid; text-align: right; background-color:" & lcor & ";'>" & FormatNumber(row.Item("nr_quantidade"), 2).ToString & "</td>"
                        ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: center; background-color:" & lcor & ";'>" & row.Item("id_central_pedido").ToString & "</td>"
                        ltable = ltable & "</tr>"
                        lnrqtde = lnrqtde + CDec(row.Item("nr_quantidade"))
                        i = i + 1
                    Next

                    lcorpo = Replace(lcorpo, "$ds_qtde_total", FormatNumber(lnrqtde, 2).ToString & " " & lnmmedida.ToString)

                    lcorpo = Replace(lcorpo, "$dsgridpedido", ltable.ToString)
                    lcorpo = Replace(lcorpo, "ecxtextosmall", "textosmall")

                    lassunto = lassunto & " - " & lassuntoaux

                    Dim notificacao As New Notificacao
                    arqTemp.Close()

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 9 'ENVIO EMAIL
                    usuariolog.id_menu_item = 233

                    usuariolog.id_nr_processo = ViewState.Item("id_central_contrato").ToString
                    'usuariolog.nm_nr_processo = lbl_id_central_pedido.Text
                    usuariolog.ds_nm_processo = "Pedidos - E-mail Grupo Produtor (propriedade " & rowprop.Item("id_propriedade").ToString & ")"
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f

                    notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, , MailPriority.High, True, lemail_parceiro2, False)

                    '    If notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, , MailPriority.High, True, , False) = True Then
                    '        'fran 24/08/2010 f chamado 931

                    '        messageControl.Alert("E-mail enviado ao produtor com sucesso!")
                    '    Else

                    '        messageControl.Alert("Email ao produtor não foi enviado com sucesso!")

                    '    End If
                    'Else
                    '    messageControl.Alert("O email não pode ser enviado pois não há nenhum email informado no cadastra do Produtor!")
                End If

            Next
            messageControl.Alert("E-mail enviado aos produtores!")

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub lk_email_parceiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email_parceiro.Click

        Dim lassunto As String
        Dim lcorpo As String
        Dim arqTemp As StreamReader
        Dim lcaminhoservidor As String = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString()  ' Na Danone os relatórios ficam aonde estãqo as páginas
        Dim lemail_parceiro As String
        Dim lemail_parceiro2 As String = String.Empty
        Dim ldatahj As Date = DateTime.Parse(Now).ToString("dd/MM/yyyy")

        Try
            'Dim propriedade As New Propriedade(Convert.ToInt32(.Item("id_propriedade").ToString))
            'Dim produtor As New Pessoa(Convert.ToInt32(.Item("id_pessoa").ToString))

            Dim contrato As New CentralContrato
            contrato.id_central_contrato = ViewState.Item("id_central_contrato")

            Dim fornecedor As New Pessoa(Convert.ToInt32(ViewState.Item("id_fornecedor").ToString))

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

            If Not lemail_parceiro.Equals(String.Empty) Then
                Dim dscontrato As DataSet = contrato.getCentralContratoByFilters

                lassunto = String.Concat("DANONE - Negociação em Grupo ", "Nr ", ViewState.Item("id_central_contrato").ToString, " - ", dscontrato.Tables(0).Rows(0).Item("nm_item").ToString)
                arqTemp = New StreamReader(lcaminhoservidor & "\central_pedido_email_fornecedor_contrato.HTML", Encoding.UTF7)
                lcorpo = ""
                Do While Not arqTemp.EndOfStream
                    lcorpo = lcorpo & arqTemp.ReadLine
                Loop

                lcorpo = Replace(lcorpo, "NEGOCIAÇÃO DE CONTRATO", "Negociação em Grupo")
                lcorpo = Replace(lcorpo, "faturamento e cadência mensal", "faturamento")

                'lcorpo = Replace(lcorpo, "$nm_estabelecimento", ViewState.Item("nm_estabelecimento").ToString)
                lcorpo = Replace(lcorpo, "$id_central_contrato", ViewState.Item("id_central_contrato").ToString)
                lcorpo = Replace(lcorpo, "$dt_hoje", String.Concat(Format(ldatahj, "dd").ToString, " de ", Format(ldatahj, "MMMM").ToString, " de ", Format(ldatahj, "yyyy").ToString & "."))
                lcorpo = Replace(lcorpo, "$nm_fornecedor", fornecedor.nm_pessoa)
                lcorpo = Replace(lcorpo, "$fone1", fornecedor.ds_telefone_1)
                lcorpo = Replace(lcorpo, "$fone2", fornecedor.ds_telefone_2)
                lcorpo = Replace(lcorpo, "$email", lemail_parceiro)
                lcorpo = Replace(lcorpo, "$ds_fornec_contato", fornecedor.ds_contato)

                With dscontrato.Tables(0).Rows(0)
                    lcorpo = Replace(lcorpo, "$nm_item", .Item("nm_item").ToString)
                    lcorpo = Replace(lcorpo, "$nr_preco_unitario", FormatCurrency(.Item("nr_valor_unitario"), 2).ToString)
                    lcorpo = Replace(lcorpo, "$nr_preco_sacaria", FormatCurrency(.Item("nr_sacaria"), 2).ToString)
                    lcorpo = Replace(lcorpo, "$ds_qtde_total", FormatNumber(.Item("nr_quantidade_total"), 2).ToString & " " & .Item("nm_unidade_medida").ToString)

                End With

                Dim ccontrato As New CentralContratoPropriedade
                ccontrato.id_central_contrato = Convert.ToInt32(ViewState.Item("id_central_contrato"))
                Dim dscontratopedido As DataSet = ccontrato.getCentralContratoPropriedadePedidos()
                Dim row As DataRow
                Dim ltable As String = String.Empty
                Dim i As Integer = 1
                Dim lcor As String = String.Empty
                For Each row In dscontratopedido.Tables(0).Rows

                    If i Mod 2 = 0 Then
                        'se linha par
                        lcor = "white"
                    Else
                        lcor = "#EFF3FB"
                    End If

                    ltable = ltable & "<tr><td style='border-top: 1px solid;  text-align: left; background-color:" & lcor & ";'>" & Left(row.Item("nm_pessoa").ToString, 30).Trim & "</td>"
                    ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: center; background-color:" & lcor & ";'>" & row.Item("cnpj_cpf_pessoa").ToString & "</td>"
                    ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: center; background-color:" & lcor & ";'>" & row.Item("cd_inscricao_estadual").ToString & "</td>"
                    ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: center; background-color:" & lcor & ";'>" & row.Item("nm_cidade_propriedade").ToString & "/" & row.Item("cd_uf_propriedade").ToString & " </td>"
                    ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: center; background-color:" & lcor & ";'>" & row.Item("ds_telefone_produtor").ToString & "</td>"
                    ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: center; background-color:" & lcor & ";'>" & UCase(DateTime.Parse(row.Item("dt_pedido")).ToString("MMM/yyyy")) & "</td>"
                    ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: right; background-color:" & lcor & ";'>" & FormatNumber(row.Item("nr_quantidade"), 2).ToString & "</td>"
                    ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: right; background-color:" & lcor & ";'>" & (row.Item("id_central_pedido")).ToString & "</td>"
                    ltable = ltable & "</tr>"
                    i = i + 1
                Next

                lcorpo = Replace(lcorpo, "$dsgridpedido", ltable.ToString)
                lcorpo = Replace(lcorpo, "ecxtextosmall", "textosmall")

                Dim notificacao As New Notificacao
                arqTemp.Close()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 9 'ENVIO EMAIL
                usuariolog.id_menu_item = 233

                usuariolog.id_nr_processo = ViewState.Item("id_central_contrato").ToString
                'usuariolog.nm_nr_processo = lbl_id_central_pedido.Text
                usuariolog.ds_nm_processo = "Pedidos - E-mail Grupo Parceiro "
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f

                'notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, , MailPriority.High, True, , False)

                If notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, "central.compras@danone.com", MailPriority.High, True, lemail_parceiro2, False) = True Then
                    'fran 24/08/2010 f chamado 931

                    messageControl.Alert("E-mail enviado ao Parceiro com sucesso!")
                Else

                    messageControl.Alert("E-mail ao Parceiro não foi enviado com sucesso!")

                End If
            Else
                messageControl.Alert("O email não pode ser enviado pois não há nenhum email informado no cadastra do Fornecedor!")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub lk_email_parceiro_frete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email_parceiro_frete.Click
        Dim lassunto As String
        Dim lcorpo As String
        Dim lcorpomodelo As String
        Dim arqTemp As StreamReader
        Dim lcaminhoservidor As String = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString()  ' Na Danone os relatórios ficam aonde estãqo as páginas
        Dim lemail_parceiro As String = String.Empty
        Dim lemail_parceiro2 As String = String.Empty
        Dim ldatahj As Date = DateTime.Parse(Now).ToString("dd/MM/yyyy")
        Dim lidtransp_ant As Integer = 0
        Dim lidtransp_atual As Integer = 0
        Dim lnmunidademedida As String
        Dim usuariolog As New UsuarioLog
        Dim notificacao As New Notificacao

        Try
            'Dim propriedade As New Propriedade(Convert.ToInt32(.Item("id_propriedade").ToString))
            'Dim produtor As New Pessoa(Convert.ToInt32(.Item("id_pessoa").ToString))


            Dim contrato As New CentralContrato
            contrato.id_central_contrato = ViewState.Item("id_central_contrato")
            Dim dscontrato As DataSet = contrato.getCentralContratoByFilters

            lassunto = String.Concat("DANONE - Negociação em Grupo ", "Nr ", ViewState.Item("id_central_contrato").ToString, " - ", dscontrato.Tables(0).Rows(0).Item("nm_item").ToString)
            arqTemp = New StreamReader(lcaminhoservidor & "\central_pedido_email_transportador_contrato.HTML", Encoding.UTF7)
            lcorpo = ""
            lcorpomodelo = ""

            Do While Not arqTemp.EndOfStream
                lcorpomodelo = lcorpomodelo & arqTemp.ReadLine
            Loop

            lcorpomodelo = Replace(lcorpomodelo, "NEGOCIAÇÃO DE CONTRATO", "Negociação em Grupo")
            lcorpomodelo = Replace(lcorpomodelo, "faturamento e cadência mensal", "faturamento")

            lcorpomodelo = Replace(lcorpomodelo, "$id_central_contrato", ViewState.Item("id_central_contrato").ToString)
            lcorpomodelo = Replace(lcorpomodelo, "$dt_hoje", String.Concat(Format(ldatahj, "dd").ToString, " de ", Format(ldatahj, "MMMM").ToString, " de ", Format(ldatahj, "yyyy").ToString & "."))
            With dscontrato.Tables(0).Rows(0)
                lcorpomodelo = Replace(lcorpomodelo, "$nm_parceiro", .Item("nm_fornecedor").ToString)
                lcorpomodelo = Replace(lcorpomodelo, "$nm_item", .Item("nm_item").ToString)
                lcorpomodelo = Replace(lcorpomodelo, "$nr_preco_unitario", FormatCurrency(.Item("nr_valor_unitario"), 2).ToString)
                lcorpomodelo = Replace(lcorpomodelo, "$nr_preco_sacaria", FormatCurrency(.Item("nr_sacaria"), 2).ToString)
                lnmunidademedida = .Item("nm_unidade_medida").ToString
            End With

            lcorpo = lcorpomodelo

            Dim ccontrato As New CentralContratoPropriedade
            ccontrato.id_central_contrato = Convert.ToInt32(ViewState.Item("id_central_contrato"))

            Dim dscontratopedido As DataSet = ccontrato.getCentralContratoPropriedadePedidosTransportador()
            If dscontratopedido.Tables(0).Rows.Count > 0 Then
                Dim row As DataRow
                lidtransp_ant = 0

                Dim ltable As String = String.Empty
                Dim i As Integer = 1
                Dim lcor As String = String.Empty
                For Each row In dscontratopedido.Tables(0).Rows

                    lidtransp_atual = row.Item("id_transportador").ToString
                    'se transportador anterior é diferente do atual inicia novo email
                    If lidtransp_ant <> lidtransp_atual Then
                        'se transp anterior ~e maior que zero deve enviar email do anterior
                        If lidtransp_ant > 0 AndAlso Not lemail_parceiro.Equals(String.Empty) Then
                            lcorpo = Replace(lcorpo, "$dsgridpedido", ltable.ToString)
                            lcorpo = Replace(lcorpo, "ecxtextosmall", "textosmall")

                            'FRAN 08/12/2020 i incluir log 
                            usuariolog.id_usuario = Session("id_login")
                            usuariolog.ds_id_session = Session.SessionID.ToString()
                            usuariolog.id_tipo_log = 9 'ENVIO EMAIL
                            usuariolog.id_menu_item = 233

                            'usuariolog.id_nr_processo = ViewState.Item("id_central_contrato").ToString
                            usuariolog.ds_nm_processo = "Pedidos - E-mail Grupo Parceiro Frete"
                            usuariolog.nm_nr_processo = String.Concat("Contrato ", ViewState.Item("id_central_contrato").ToString, " - ", lemail_parceiro)
                            usuariolog.insertUsuarioLog()
                            'fran 08/12/2020 f

                            If notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, "central.compras@danone.com", MailPriority.High, True, lemail_parceiro2, False) = True Then

                                'messageControl.Alert("E-mail enviado ao Parceiro com sucesso!")
                            Else

                                'messageControl.Alert("E-mail ao Parceiro não foi enviado com sucesso!")

                            End If

                        End If

                        i = 1
                        lcor = String.Empty
                        ltable = String.Empty
                        lcorpo = lcorpomodelo
                        lidtransp_ant = lidtransp_atual

                        lemail_parceiro = row.Item("ds_email").ToString
                        If lemail_parceiro.Equals(String.Empty) Then
                            If Not row.Item("ds_email2").ToString.Equals(String.Empty) Then
                                lemail_parceiro = row.Item("ds_email2").ToString
                            Else
                                lemail_parceiro = String.Empty
                            End If
                            'fran fase 2 melhorias i se existe o primeiro email, busca o 2
                        Else
                            If Not row.Item("ds_email2").ToString.Equals(String.Empty) Then 'se nao for nothing, joga o valor no para2
                                lemail_parceiro2 = row.Item("ds_email2").ToString
                            Else
                                lemail_parceiro2 = String.Empty
                            End If
                        End If
                        If Not lemail_parceiro.Equals(String.Empty) Then
                            lcorpo = Replace(lcorpo, "$nm_fornecedor", row.Item("nm_transportador").ToString)
                            lcorpo = Replace(lcorpo, "$fone1", row.Item("ds_telefone_1").ToString)
                            lcorpo = Replace(lcorpo, "$fone2", row.Item("ds_telefone_2").ToString)
                            lcorpo = Replace(lcorpo, "$email", lemail_parceiro)
                            lcorpo = Replace(lcorpo, "$ds_fornec_contato", row.Item("ds_contato").ToString)
                            lcorpo = Replace(lcorpo, "$ds_qtde_total", FormatNumber(row.Item("nr_qtde_bytransportador"), 2).ToString & " " & lnmunidademedida)

                        End If
                    End If
                    If Not lemail_parceiro.Equals(String.Empty) Then
                        If i Mod 2 = 0 Then
                            'se linha par
                            lcor = "white"
                        Else
                            lcor = "#EFF3FB"
                        End If

                        ltable = ltable & "<tr><td style='border-top: 1px solid;  text-align: left; background-color:" & lcor & ";'>" & Left(row.Item("nm_pessoa").ToString, 30).Trim & "</td>"
                        ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: center; background-color:" & lcor & ";'>" & row.Item("cnpj_cpf_pessoa").ToString & "</td>"
                        ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: center; background-color:" & lcor & ";'>" & row.Item("cd_inscricao_estadual").ToString & "</td>"
                        ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: center; background-color:" & lcor & ";'>" & row.Item("nm_cidade_propriedade").ToString & "/" & row.Item("cd_uf_propriedade").ToString & " </td>"
                        ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: center; background-color:" & lcor & ";'>" & row.Item("ds_telefone_produtor").ToString & "</td>"
                        ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: center; background-color:" & lcor & ";'>" & UCase(DateTime.Parse(row.Item("dt_pedido")).ToString("MMM/yyyy")) & "</td>"
                        ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: right; background-color:" & lcor & ";'>" & FormatNumber(row.Item("nr_quantidade"), 2).ToString & "</td>"
                        ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: right; background-color:" & lcor & ";'>" & FormatNumber(row.Item("nr_frete"), 2).ToString & "</td>"
                        ltable = ltable & "<td style='border-top: 1px solid; border-left: 1px solid; text-align: right; background-color:" & lcor & ";'>" & (row.Item("id_central_pedido_frete")).ToString & "</td>"
                        ltable = ltable & "</tr>"
                        i = i + 1
                    End If
                Next
                If Not lemail_parceiro.Equals(String.Empty) Then

                    lcorpo = Replace(lcorpo, "$dsgridpedido", ltable.ToString)
                    lcorpo = Replace(lcorpo, "ecxtextosmall", "textosmall")

                    arqTemp.Close()

                    'FRAN 08/12/2020 i incluir log 
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 9 'ENVIO EMAIL
                    usuariolog.id_menu_item = 233

                    'usuariolog.id_nr_processo = ViewState.Item("id_central_contrato").ToString
                    'usuariolog.nm_nr_processo = lbl_id_central_pedido.Text
                    usuariolog.ds_nm_processo = "Pedidos - E-mail Grupo Parceiro Frete"
                    usuariolog.nm_nr_processo = String.Concat("Contrato ", ViewState.Item("id_central_contrato").ToString, " - ", lemail_parceiro)
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f

                    'notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, , MailPriority.High, True, , False)

                    If notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, "central.compras@danone.com", MailPriority.High, True, lemail_parceiro2, False) = True Then
                        'fran 24/08/2010 f chamado 931

                        'messageControl.Alert("E-mail enviado ao Parceiro de Frete com sucesso!")
                        messageControl.Alert("E-mail Grupo enviado aos Parceiros de Frete.")
                    Else

                        messageControl.Alert("E-mail Grupo aos Parceiros de Frete enviados!")

                    End If
                Else
                    'messageControl.Alert("O email não pode ser enviado pois não há nenhum email informado no cadastro do Transportador!")
                    messageControl.Alert("O email não pode ser enviado pois não há nenhum email informado no cadastro do Transportador!")
                End If
            Else
                arqTemp.Close()
                messageControl.Alert("Não há pedidos para Perceiro de Frete. Nenhum e-mail foi enviado.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub
End Class