Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_romaneio_saida_abertura
    Inherits Page
    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_saida_abertura.aspx")

        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportador"
        End With
        With btn_lupa_cooperativa
            .Attributes.Add("onclick", "javascript:ShowDialogCooperativa()")
            .ToolTip = "Filtrar Destino"
        End With

        If Not Page.IsPostBack Then
            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                If ViewState.Item("id_romaneio").ToString.Equals(String.Empty) Then
                    ViewState.Item("id_romaneio") = 0
                    lk_concluir.Enabled = False
                    lk_concluirFooter.Enabled = False
                    btn_novo_compartimento.Enabled = False
                    messageControl.Alert("Há problemas na passagem de parametros. A tela não pode ser montada!")
                Else
                    loadDetails()
                End If
            Else
                ViewState.Item("id_romaneio") = 0
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
                btn_novo_compartimento.Enabled = False
                messageControl.Alert("Há problemas na passagem de parametros. A tela não pode ser montada!")

            End If
        Else
            If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
                gridRomaneioCompartimento.Rows(0).Cells.Clear()
                gridRomaneioCompartimento.Rows(0).Cells.Add(New TableCell())
                gridRomaneioCompartimento.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridRomaneioCompartimento.Rows(0).Cells(0).Text = "Não existe nenhuma Placa/Compartimento cadastrados!"
                gridRomaneioCompartimento.Rows(0).Cells(0).ColumnSpan = 7
            End If

        End If

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabel As New Estabelecimento

            estabel.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_estabelecimento.SelectedIndex = 1

            'tipo de leite 
            Dim item As New Item
            cbo_id_item.DataSource = item.getItensByFilters()
            cbo_id_item.DataTextField = "nm_item"
            cbo_id_item.DataValueField = "id_item"
            cbo_id_item.DataBind()
            cbo_id_item.Items.Insert(0, New ListItem("[Selecione]", 0))
            cbo_id_item.SelectedValue = 1 'assumir leite in natura

            Dim motivo As New MotivoSaida
            cbo_motivo_saida.DataSource = motivo.getMotivoSaidaByFilters()
            cbo_motivo_saida.DataTextField = "nm_motivo_saida"
            cbo_motivo_saida.DataValueField = "id_motivo_saida"
            cbo_motivo_saida.DataBind()
            cbo_motivo_saida.Items.Insert(0, New ListItem("[Selecione]", 0))

            Dim frete As New FreteNotaFiscal
            frete.id_situacao = 1
            cbo_tipo_frete.DataSource = frete.getFretesNotasFiscaisByFilters()
            cbo_tipo_frete.DataTextField = "nm_frete_nf"
            cbo_tipo_frete.DataValueField = "id_frete_nf"
            cbo_tipo_frete.DataBind()
            cbo_tipo_frete.Items.Insert(0, New ListItem("[Selecione]", 0))
            cbo_tipo_frete.Items(1).Text = "Danone"
            cbo_tipo_frete.Items(2).Text = "Destinatário"

            Dim tipooperacao As New TipoOperacao
            tipooperacao.id_situacao = 1
            cbo_tipo_operacao.DataSource = tipooperacao.getTipoOperacaoByFilters()
            cbo_tipo_operacao.DataTextField = "nm_tipo_operacao"
            cbo_tipo_operacao.DataValueField = "id_tipo_operacao"
            cbo_tipo_operacao.DataBind()
            cbo_tipo_operacao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim dsgrid As New DataTable
            dsgrid.Rows.InsertAt(dsgrid.NewRow(), 0)

            gridRomaneioCompartimento.Visible = True
            gridRomaneioCompartimento.DataSource = Helper.getDataView(dsgrid, ViewState.Item("sortExpression"))
            gridRomaneioCompartimento.DataBind()
            gridRomaneioCompartimento.Rows(0).Cells.Clear()
            gridRomaneioCompartimento.Rows(0).Cells.Add(New TableCell())
            gridRomaneioCompartimento.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            gridRomaneioCompartimento.Rows(0).Cells(0).Text = "Não existe nenhuma Placa/Compartimento cadastrados!"
            gridRomaneioCompartimento.Rows(0).Cells(0).ColumnSpan = 7

            'dados do pesagem
            If txt_dt_pesagem_inicial.Text.Equals(String.Empty) Then
                txt_hr_ini.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_ini.Text = Format(DateTime.Parse(Now), "mm")
                txt_dt_pesagem_inicial.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            End If

            ViewState.Item("nr_peso_leiturabalanca_inicial") = 0
            ViewState.Item("dt_leiturabalanca_inicial") = ""

            If CInt(ViewState.Item("id_romaneio")) > 0 Then
                'se entrou na tela com arametro de romaneio , veio da abertura por nota e precisa complementar os dados
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()

        Try

            Dim romaneio As New Romaneio
            romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)

            Dim dsromaneio As DataSet = romaneio.getRomaneioByFilters
            Dim lnrpesoint As Decimal = 0
            Dim lnrpesoini As Decimal = 0

            'tr_romaneio.Visible = True
            'lbl_romaneio_saida.Text = ViewState.Item("id_romaneio_saida").ToString

            With dsromaneio.Tables(0).Rows(0)

                'Romaneio de entrada
                lbl_id_romaneio.Text = ViewState.Item("id_romaneio").ToString
                lbl_romaneio_situacao.Text = .Item("nm_st_romaneio").ToString
                lbl_romaneio_dt_entrada.Text = Format(DateTime.Parse(.Item("dt_hora_entrada").ToString), "dd/MM/yyyy hh:mm").ToString
                lbl_romaneio_dt_saida.Text = Format(DateTime.Parse(.Item("dt_hora_saida").ToString), "dd/MM/yyyy hh:mm").ToString
                lbl_romaneio_nm_item.Text = .Item("nm_item").ToString

                lbl_romaneio_tipo.Text = "Produtor"
                If Not IsDBNull(.Item("id_cooperativa")) Then
                    lbl_romaneio_tipo.Text = "Cooperativa"
                    tr_cooperativa.Visible = True
                    lbl_romaneio_cooperativa.Text = .Item("nm_cooperativa").ToString
                    lbl_romaneio_volume.Text = (CDec(.Item("nr_peso_liquido_nota"))).ToString("######")
                Else
                    tr_cooperativa.Visible = False
                    lbl_romaneio_volume.Text = (CDec(.Item("nr_peso_liquido_caderneta"))).ToString("######")
                End If
                If Not IsDBNull(.Item("id_transit_point")) Then
                    lbl_romaneio_tipo.Text = String.Concat("Transit Point", " - ", .Item("id_transit_point").ToString)
                End If
                If Not IsDBNull(.Item("id_transvase")) Then
                    lbl_romaneio_tipo.Text = String.Concat("Transvase", " - ", .Item("id_transvase").ToString)
                End If

                lbl_romaneio_transportador.Text = .Item("ds_transportador").ToString
                lbl_romaneio_placa.Text = .Item("ds_placa").ToString
                lbl_romaneio_peso_ini.Text = (CDec(.Item("nr_pesagem_inicial"))).ToString("######")
                lnrpesoini = CDec(.Item("nr_pesagem_inicial"))
                If Not IsDBNull(.Item("nr_pesagem_intermediaria")) Then
                    lbl_romaneio_peso_int.Text = (CDec(.Item("nr_pesagem_intermediaria"))).ToString("######")
                    lnrpesoint = CDec(.Item("nr_pesagem_intermediaria"))
                End If
                lbl_romaneio_peso_final.Text = (CDec(.Item("nr_pesagem_final"))).ToString("######")
                lbl_romaneio_peso.Text = (CDec(.Item("nr_peso_liquido"))).ToString("######")

                Dim rplaca As New RomaneioPlaca
                Dim bdestinoDescarte As Boolean = False
                Dim bdestinoVenda As Boolean = False
                Dim lnrvolumerejeitado As Decimal = 0

                rplaca.id_romaneio = ViewState.Item("id_romaneio")
                Dim dsrplaca As DataSet = rplaca.getRomaneioPlacasByFilters
                Dim row As DataRow
                If dsrplaca.Tables(0).Rows.Count > 0 Then
                    For Each row In dsrplaca.Tables(0).Rows
                        If Not IsDBNull(row.Item("st_destino_leite_rejeitado")) Then
                            If row.Item("st_destino_leite_rejeitado").Equals("D") Then
                                bdestinoDescarte = True
                            End If
                            If row.Item("st_destino_leite_rejeitado").Equals("V") Then
                                bdestinoVenda = True
                            End If
                        End If
                        If Not IsDBNull(row.Item("nr_total_volume_rejeitado")) Then

                            lnrvolumerejeitado = lnrvolumerejeitado + CDec(row.Item("nr_total_volume_rejeitado"))
                        End If
                    Next
                End If

                lbl_romaneio_peso_disponivel.Text = lbl_romaneio_peso.Text

                If bdestinoDescarte = True Then
                    lbl_romaneio_destino_rejeitado.Text = "Descarte"
                    lbl_romaneio_peso_disponivel.Text = (lnrpesoini - lnrpesoint).ToString("######")
                End If
                If bdestinoVenda = True Then
                    lbl_romaneio_destino_rejeitado.Text = "Venda"
                    lbl_romaneio_peso_disponivel.Text = (lnrpesoini).ToString("######")
                End If

                If lnrvolumerejeitado > 0 Then
                    lbl_romaneio_volume_descartado.Text = (lnrvolumerejeitado).ToString("######")
                End If

                cbo_estabelecimento.SelectedValue = .Item("id_estabelecimento").ToString
                cbo_id_item.SelectedValue = .Item("id_item").ToString

                Dim mediadensidade As Decimal = romaneio.getRomaneioCompartimentoMediaDens()
                lbl_media_densidade.Text = CDec(mediadensidade).ToString
                lbl_romaneio_litros_reais.Text = Round(CDec(lbl_romaneio_peso_disponivel.Text) / mediadensidade, 0)

                txt_nr_peso_liquido_estimado.Text = lbl_romaneio_litros_reais.Text
                txt_pesagem_inicial.Text = lbl_romaneio_peso_final.Text

            End With



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub updateData()
        If Page.IsValid Then

            Try

                Dim romaneio As New RomaneioSaida()
                Dim usuariolog As New UsuarioLog
                Dim lmsg As String = String.Empty
                Dim row As GridViewRow

                romaneio.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                romaneio.id_item = Convert.ToInt32(cbo_id_item.SelectedValue)
                If Not (cbo_tipo_operacao.SelectedValue.Equals(String.Empty)) Then
                    romaneio.id_tipo_operacao = cbo_tipo_operacao.SelectedValue
                Else
                    romaneio.id_tipo_operacao = 0
                End If
                romaneio.id_motivo_saida = cbo_motivo_saida.SelectedValue
                romaneio.id_frete_nf = cbo_tipo_frete.SelectedValue
                romaneio.id_cooperativa = Convert.ToInt32(hf_id_cooperativa.Value)
                romaneio.id_transportador = Convert.ToInt32(hf_id_transportador.Value)

                If cbo_motorista.SelectedValue.Equals(String.Empty) Then
                    romaneio.nm_motorista = txt_nm_motorista.Text
                    romaneio.cd_cnh = txt_cnh_motorista.Text
                Else
                    romaneio.id_motorista = Left(cbo_motorista.SelectedValue.ToString.Trim, InStr(cbo_motorista.SelectedValue.ToString.Trim, "&") - 1).Trim
                End If

                If Not (txt_nr_peso_liquido_estimado.Text.Trim.Equals(String.Empty)) Then
                    romaneio.nr_volume_estimado = Convert.ToDecimal(txt_nr_peso_liquido_estimado.Text)
                End If
                If Not (txt_nr_valor_nota_fiscal.Text.Trim.Equals(String.Empty)) Then
                    romaneio.nr_valor_nota_fiscal = Convert.ToDecimal(txt_nr_valor_nota_fiscal.Text)
                End If
                If Not (txt_preco_unitario.Text.Trim.Equals(String.Empty)) Then
                    romaneio.nr_preco_unitario_estimado = Convert.ToDecimal(txt_preco_unitario.Text)
                End If
                If Not (txt_valor_frete.Text.Trim.Equals(String.Empty)) Then
                    romaneio.nr_valor_frete_estimado = Convert.ToDecimal(txt_valor_frete.Text)
                End If

                distribuirVolumeCompartimento()

                For Each row In gridRomaneioCompartimento.Rows
                    If row.Visible = True Then
                        Dim txt_placa As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
                        Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_id_compartimento As DataControlFieldCell = CType(row.Cells(7), DataControlFieldCell)
                        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                        Dim chk As Anthem.CheckBox = CType(row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)

                        If chk.Checked = True Then
                            romaneio.ds_placa = txt_placa.Text.ToString
                        End If

                        romaneio.rc_ds_placa.Add(txt_placa.Text.ToString)
                        romaneio.rc_id_compartimento.Add(Convert.ToInt32(cbo_compartimento.SelectedValue))
                        If Not (txt_nr_total_litros.Text.ToString.Equals(String.Empty)) Then
                            romaneio.rc_nr_total_volume.Add(Convert.ToDecimal(txt_nr_total_litros.Text))
                        Else
                            romaneio.rc_nr_total_volume.Add(Convert.ToDecimal(0))
                        End If

                    End If
                Next

                If Not (txt_pesagem_inicial.Text.Trim.Equals(String.Empty)) Then
                    romaneio.nr_pesagem_inicial = Convert.ToDecimal(txt_pesagem_inicial.Text)
                Else
                    romaneio.nr_pesagem_inicial = 0
                End If
                romaneio.dt_pesagem_inicial = txt_dt_pesagem_inicial.Text & " " & txt_hr_ini.Text & ":" & txt_mm_ini.Text & ":00"
                'assume que status esta aberto pois ja informou dados pesagem

                romaneio.nr_peso_leiturabalanca_inicial = ViewState.Item("nr_peso_leiturabalanca_inicial")
                romaneio.dt_leiturabalanca_inicial = ViewState.Item("dt_leiturabalanca_inicial")

                romaneio.nr_volume_disponivel = Convert.ToDecimal(lbl_romaneio_litros_reais.Text)
                romaneio.id_romaneio_entrada = ViewState.Item("id_romaneio").ToString
                romaneio.id_modificador = Session("id_login")
                romaneio.id_situacao_romaneio_saida = 4 'carregado (caminhao carregdo)
                romaneio.id_situacao = 4 'log de situacao
                romaneio.id_romaneio_saida = romaneio.abrirRomaneioSaidabyRomaneio()
                ViewState.Item("id_romaneio_saida") = romaneio.id_romaneio_saida

                'log
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 246
                usuariolog.id_nr_processo = romaneio.id_romaneio_saida.ToString
                usuariolog.nm_nr_processo = romaneio.id_romaneio_saida.ToString
                usuariolog.insertUsuarioLog()

                lmsg = "O Romaneio Saída foi aberto com sucesso! O número que é a identificação necessária para acompanhamento deste processo é " & romaneio.id_romaneio_saida.ToString & "."
                Response.Redirect("frm_mensagem.aspx?msg=" + lmsg + "&tela=frm_romaneio_saida_consulta.aspx?id_romaneio_saida=" + Convert.ToString(romaneio.id_romaneio_saida))

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Private Sub distribuirVolumeCompartimento()
        If Page.IsValid Then


            Try

                Dim row As GridViewRow


                Dim lqtdecomp As Int32 = 0 'qtde compartimentos a realizar a distribuição
                Dim lvolrestantecomp As Decimal 'volume restante de cada compartimento apos retirar o valor de distribuição
                Dim lcompNCheio As New ArrayList 'guarda a linha dos compartimento que ainda não estão cheios para participarem da redistribuição
                Dim lvoldistribuido As Decimal
                Dim lresto As Decimal

                'Na priomeira vez busco qtos compartimentos foram inseridos
                For Each row In gridRomaneioCompartimento.Rows
                    If row.Visible = True Then
                        Dim lbl_comp_cheio As Label = CType(row.FindControl("lbl_comp_cheio"), Label)
                        'Guarda o somatório dos compartimenros
                        lqtdecomp = lqtdecomp + 1
                        lcompNCheio.Add(row.RowIndex)
                        lbl_comp_cheio.Text = "N" 'seta que cada compratimento não esta cheio ainda
                    End If
                Next

                'Esta operação '\' divide devolvendo a parte inteira apenas
                lvoldistribuido = CDec(Me.txt_nr_peso_liquido_estimado.Text) \ lqtdecomp
                'Devolve o resto da divisão
                lresto = Decimal.Remainder(CDec(Me.txt_nr_peso_liquido_estimado.Text), lqtdecomp)
                lqtdecomp = 0

                Do While lresto >= 0

                    If lqtdecomp > 0 Then 'Se é a 2a vez
                        'Esta operação '\' divide devolvendo a parte inteira apenas
                        lvoldistribuido = CDec(lresto) \ lqtdecomp
                        'Devolve o resto da divisão
                        lresto = Decimal.Remainder(CDec(lresto), lqtdecomp)
                    End If
                    lqtdecomp = 0
                    For Each row In gridRomaneioCompartimento.Rows
                        Dim lbl_comp_cheio As Label = CType(row.FindControl("lbl_comp_cheio"), Label)

                        If row.Visible = True Then
                            'Se o compartimento ainda não esta cheio
                            If lbl_comp_cheio.Text = "N" Then

                                Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                                Dim lbl_max_compartimento As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)

                                If txt_nr_total_litros.Text.Equals(String.Empty) Then
                                    txt_nr_total_litros.Text = "0"
                                End If

                                'Se a parte inteira da divisao deu 0 tenta colocar o resto no primeiro compartimento que der
                                If lvoldistribuido > 0 Then
                                    lvolrestantecomp = (CDec(lbl_max_compartimento.Text) - CDec(txt_nr_total_litros.Text)) - lvoldistribuido

                                    'SE o vol restante for maior que zero
                                    If lvolrestantecomp >= 0 Then
                                        'Guarda a linha do compartimento
                                        lcompNCheio.Add(row.RowIndex)
                                        txt_nr_total_litros.Text = CDec(txt_nr_total_litros.Text) + lvoldistribuido
                                        lbl_comp_cheio.Text = "N"
                                        lqtdecomp = lqtdecomp + 1
                                    Else
                                        'Soma o resto
                                        lresto = lresto + Math.Abs(lvolrestantecomp)
                                        txt_nr_total_litros.Text = CDec(txt_nr_total_litros.Text) + (lvoldistribuido - Math.Abs(lvolrestantecomp))
                                        lbl_comp_cheio.Text = "S"

                                    End If
                                Else
                                    lvolrestantecomp = (CDec(lbl_max_compartimento.Text) - CDec(txt_nr_total_litros.Text)) - lresto
                                    'SE o vol restante for maior que zero
                                    If lvolrestantecomp >= 0 Then
                                        txt_nr_total_litros.Text = CDec(txt_nr_total_litros.Text) + lresto
                                        lbl_comp_cheio.Text = "N"
                                        If lvolrestantecomp = 0 Then
                                            lbl_comp_cheio.Text = "S"
                                        End If
                                        lresto = -1 'força sair do laço
                                        Exit For
                                    Else
                                        txt_nr_total_litros.Text = CDec(txt_nr_total_litros.Text) + (lresto - Math.Abs(lvolrestantecomp))
                                        lbl_comp_cheio.Text = "S"
                                        'Soma o resto
                                        lresto = Math.Abs(lvolrestantecomp)

                                    End If

                                End If
                            End If
                        End If
                    Next
                    If lresto = 0 Then
                        lresto = -1
                    End If
                Loop


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Private Sub carregarCamposTransportador()

        Try

            If Not (customPage.getFilterValue("lupa_transcoop", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transcoop", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transcoop", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transcoop", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_transcoop")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposCooperativa()

        Try

            If Not (customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").Equals(String.Empty)) Then
                Me.lbl_nm_cooperativa.Visible = True
                Me.lbl_nm_cooperativa.Text = customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").Equals(String.Empty)) Then
                Me.txt_cd_cooperativa.Text = customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").Equals(String.Empty)) Then
                Me.lbl_cd_cnpj.Visible = True
                Me.lbl_cd_cnpj.Text = customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").ToString
                Me.lbl_nm_cnpj.Visible = True
            End If

            'loadData()
            customPage.clearFilters("lupa_cooperativa")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidtransportador As Int32
            If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_transportador.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
            lidtransportador = pessoa.validarTransportadorCooperativa

            If lidtransportador > 0 Then
                args.IsValid = True
                hf_id_transportador.Value = lidtransportador
            Else
                hf_id_transportador.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Transportador não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        lbl_nm_transportador.Text = String.Empty
        lbl_nm_transportador.Visible = False
        hf_id_transportador.Value = String.Empty
        loadMotoristaByTransportador(, txt_cd_transportador.Text.Trim)


    End Sub

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        'If Not (Me.cbo_estabelecimento.SelectedValue.ToString.Equals(String.Empty)) Then
        If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
            loadMotoristaByTransportador(Convert.ToInt32(hf_id_transportador.Value))
        Else
            txt_cd_transportador.Text = String.Empty
            hf_id_transportador.Value = String.Empty
            lbl_nm_transportador.Text = String.Empty
            lbl_nm_transportador.Visible = False
        End If
        'End If

    End Sub
    Private Sub loadMotoristaByTransportador(Optional ByVal id_transportador As Int32 = 0, Optional ByVal cd_transportador As String = "")

        Try

            cbo_motorista.Enabled = True

            Dim motorista As New Motorista
            If id_transportador > 0 Then
                motorista.id_pessoa = id_transportador
            End If
            If Not (cd_transportador.Equals(String.Empty)) Then
                motorista.cd_pessoa = cd_transportador
            End If
            motorista.id_situacao = 1 'fran 03/2017
            cbo_motorista.DataSource = motorista.getMotoristasByFilters()
            cbo_motorista.DataTextField = "nm_motorista"
            cbo_motorista.DataValueField = "ds_id_cdcnh"
            cbo_motorista.DataBind()
            cbo_motorista.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadCooperativaByCodigo()

        Try


            Dim cooperativa As New Pessoa
            cooperativa.cd_pessoa = txt_cd_cooperativa.Text
            Dim dscooperativa As DataSet = cooperativa.getCooperativasByCodigo()
            If dscooperativa.Tables(0).Rows.Count > 0 Then
                lbl_nm_cooperativa.Visible = True
                lbl_cd_cnpj.Visible = True
                Me.lbl_nm_cnpj.Visible = True
                lbl_nm_cooperativa.Text = dscooperativa.Tables(0).Rows(0).Item("nm_pessoa")
                lbl_cd_cnpj.Text = dscooperativa.Tables(0).Rows(0).Item("cd_cnpj")
                hf_id_cooperativa.Value = dscooperativa.Tables(0).Rows(0).Item("id_pessoa")
                ViewState.Item("id_estado_cooperativa") = dscooperativa.Tables(0).Rows(0).Item("id_estado")
            Else
                lbl_nm_cooperativa.Visible = False
                lbl_cd_cnpj.Visible = False
                Me.lbl_nm_cnpj.Visible = False
                hf_id_cooperativa.Value = String.Empty
                ViewState.Item("id_estado_cooperativa") = 0
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub cv_cooperativa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_cooperativa.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidcooperativa As Int32

            'If Not cbo_estabelecimento.SelectedValue.Equals(String.Empty) Then
            'pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            'End If
            If Not (Me.hf_id_cooperativa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_cooperativa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_cooperativa.Text.Trim
            lidcooperativa = pessoa.validarCooperativa

            If lidcooperativa > 0 Then
                args.IsValid = True
                hf_id_cooperativa.Value = lidcooperativa
            Else
                hf_id_cooperativa.Value = String.Empty
                args.IsValid = False
                'messageControl.Alert("Cooperativa não cadastrada.")
                messageControl.Alert("Cooperativa não cadastrada para o Estabelecimento do Romaneio!")  ' 19/08/2010 Adriana Chamado 932
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click

        Response.Redirect("lst_romaneio_saida_abertura.aspx")

    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_saida_abertura.aspx")

    End Sub

    Protected Sub btn_lupa_cooperativa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_cooperativa.Click
        If Not (Me.hf_id_cooperativa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposCooperativa()
        Else
            txt_cd_cooperativa.Text = String.Empty
            hf_id_cooperativa.Value = String.Empty
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            lbl_cd_cnpj.Text = String.Empty
            lbl_cd_cnpj.Visible = False
            Me.lbl_nm_cnpj.Visible = False
        End If

    End Sub

    Protected Sub txt_cd_cooperativa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_cooperativa.TextChanged

        If Not txt_cd_cooperativa.Text.Equals(String.Empty) Then
            loadCooperativaByCodigo()
        Else
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            hf_id_cooperativa.Value = String.Empty
            lbl_cd_cnpj.Text = String.Empty
            lbl_cd_cnpj.Visible = False
            Me.lbl_nm_cnpj.Visible = False
        End If
    End Sub

    Protected Sub cbo_motorista_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_motorista.SelectedIndexChanged
        Dim lpos As Integer

        'Guarda no value do compartimento o id e o volume max do compartimento
        lpos = InStr(cbo_motorista.SelectedValue, "&")
        lbl_cd_cnh.Visible = True
        lbl_cnh.Visible = True
        lbl_cd_cnh.Text = Mid(cbo_motorista.SelectedValue, lpos + 1).Trim

    End Sub

    Protected Sub btn_novo_compartimento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_compartimento.Click

        Try

            Dim dstable As New DataTable
            Dim ilinha As Integer
            If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
                Dim rc As New Romaneio_Compartimento
                Dim ds As New DataSet
                rc.id_romaneio = -1
                ds = rc.getRomaneio_CompartimentoByFilters
                ViewState.Item("gridLinhasAdicionadas") = "S"
                ilinha = 0
            Else
                ViewState.Item("incluirlinha") = "S"
                'dstable.Rows.InsertAt(dstable.NewRow(), dstable.Rows.Count + 1)
                dstable.Columns.Add("ds_placa")
                dstable.Columns.Add("st_placa_principal")
                dstable.Columns.Add("ds_id_nrvolume")
                dstable.Columns.Add("nr_volume")
                dstable.Columns.Add("nr_total_litros")
                dstable.Columns.Add("id_index")
                dstable.Columns.Add("id_compartimento")

                Dim row As GridViewRow
                ilinha = 0
                For Each row In gridRomaneioCompartimento.Rows
                    If row.Visible = True Then
                        Dim txt_placa As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
                        Dim check As Anthem.CheckBox = CType(row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)
                        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                        Dim txt_volcomp As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)
                        Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_id_index As DataControlFieldCell = CType(row.Cells(6), DataControlFieldCell)
                        Dim txt_id_compartimento As DataControlFieldCell = CType(row.Cells(7), DataControlFieldCell)

                        dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
                        With dstable.Rows.Item(ilinha)
                            .Item(0) = txt_placa.Text
                            If check.Checked = True Then
                                .Item(1) = "S"
                            Else
                                .Item(1) = "N"
                            End If

                            .Item(2) = cbo_compartimento.SelectedValue
                            .Item(3) = txt_volcomp.Text
                            .Item(4) = txt_nr_total_litros.Text
                            .Item(5) = txt_id_index.Text
                            .Item(6) = txt_id_compartimento.Text
                        End With
                        ilinha = ilinha + 1
                    End If
                Next

                ViewState.Item("gridtable") = dstable

            End If

            dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
            gridRomaneioCompartimento.Visible = True
            gridRomaneioCompartimento.DataSource = Helper.getDataView(dstable, ViewState.Item("sortExpression"))

            gridRomaneioCompartimento.DataBind()

            ViewState.Item("incluirlinha") = "N"
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub cv_verificarvolume_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_verificarvolume.ServerValidate
        Try
            Dim row As GridViewRow
            Dim ltotalvolumescompartimento As Decimal
            For Each row In gridRomaneioCompartimento.Rows
                If row.Visible = True Then
                    Dim lbl_max_compartimento As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)
                    'Guarda o somatório dos volumes maximos permitidos para cada compartimento
                    ltotalvolumescompartimento = ltotalvolumescompartimento + CDec(lbl_max_compartimento.Text)
                End If
            Next

            If ltotalvolumescompartimento < CDec(txt_nr_peso_liquido_estimado.Text) Then
                args.IsValid = False
            Else
                args.IsValid = True
            End If

            If args.IsValid = False Then
                messageControl.Alert("'Litros da Nota Fiscal' não pode ser maior que a somatória do 'Volume Máximo' dos compartimentos informados.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_placa_principal_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_placa_principal.ServerValidate
        Try
            Dim i As Integer = 0
            Dim row As GridViewRow
            Dim iprincipal As Integer = 0
            Dim placasid As New ArrayList
            args.IsValid = True
            For Each row In gridRomaneioCompartimento.Rows
                If row.Visible = True Then
                    Dim txt_placa As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
                    Dim chk_placa_principal As Anthem.CheckBox = CType(row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)
                    Dim txt_id_compartimento As DataControlFieldCell = CType(row.Cells(7), DataControlFieldCell)
                    Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)

                    If chk_placa_principal.Checked = True Then
                        iprincipal = iprincipal + 1
                    End If
                    placasid.Add(String.Concat(UCase(txt_placa.Text), cbo_compartimento.SelectedValue))
                    i = i + 1
                End If
            Next
            If iprincipal = 1 Then 'Se não há erros, se selecionou uma placa
                Dim lsplacaid_ant As String
                Dim lbMesmaPlacaId As Boolean
                lbMesmaPlacaId = False
                placasid.Sort()
                lsplacaid_ant = ""
                For i = 0 To placasid.Count - 1
                    If placasid.Item(i).ToString <> lsplacaid_ant.ToString Then
                        lsplacaid_ant = placasid.Item(i).ToString
                    Else
                        lbMesmaPlacaId = True
                        Exit For
                    End If
                Next
                If lbMesmaPlacaId = True Then
                    args.IsValid = False
                    messageControl.Alert("O mesmo compartimento não deve ser informado mais de uma vez para a mesma placa.")

                End If
            Else
                If iprincipal = 0 Then
                    args.IsValid = False
                    messageControl.Alert("Informe uma placa como principal para continuar.")
                End If
                If iprincipal > 1 Then
                    args.IsValid = False
                    messageControl.Alert("Apenas uma placa deve ser informada como principal.")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cv_grid_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_grid.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True

            If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
                args.IsValid = False
                lmsg = "Uma placa deve ser informada para continuar."
            End If

            If cbo_motorista.SelectedValue = String.Empty Then
                'se nao selecionou motorista verifica se informou o nm motorista
                If txt_nm_motorista.Text.Equals(String.Empty) Then
                    args.IsValid = False
                    lmsg = "O nome do motorista deve ser informado ou selecionado um já cadastrado."
                Else
                    If txt_cnh_motorista.Text.Equals(String.Empty) Then
                        args.IsValid = False
                        lmsg = "A CNH do motorista deve ser informada."
                    End If
                End If
            Else
                If Not txt_nm_motorista.Text.Equals(String.Empty) Then
                    args.IsValid = False
                    lmsg = "O motorista deve ser informado na lista de cadastrados ou informado seu nome no campo. Deve ser escolhido apenas uma forma."
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridRomaneioCompartimento_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridRomaneioCompartimento.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "delete"
                deleteRomaneioCompartimento(Convert.ToInt32(e.CommandArgument.ToString()))

            Case "Lupa"
                'Me.txt_placa.Text = ""

                carregarCamposVeiculo(Convert.ToInt32(e.CommandArgument.ToString()))


        End Select
    End Sub
    Private Sub deleteRomaneioCompartimento(ByVal id_index_row As Integer)

        Try

            gridRomaneioCompartimento.Rows(id_index_row).Visible = False
            'loadGridEscolaridade()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridRomaneioCompartimento_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridRomaneioCompartimento.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btnexcluir As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)
                Dim bt_lupa_veiculo As Anthem.ImageButton = CType(e.Row.FindControl("bt_lupa_veiculo"), Anthem.ImageButton)
                btnexcluir.CommandArgument = e.Row.RowIndex.ToString
                bt_lupa_veiculo.CommandArgument = e.Row.RowIndex.ToString
                With bt_lupa_veiculo
                    .Attributes.Add("onclick", "javascript:ShowDialog()")
                    .ToolTip = "Filtrar Veículos"
                    '.Style("cursor") = "hand"
                End With
                If ViewState.Item("incluirlinha") = "S" Then
                    Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
                    If Not (dr Is Nothing) Then
                        If Not (dr.Item(0).ToString.Equals(String.Empty)) Then
                            Dim cbo_compartimento As Anthem.DropDownList = CType(e.Row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                            cbo_compartimento.Enabled = True
                            Dim compartimento As New Compartimento
                            compartimento.id_situacao = 1
                            compartimento.ds_placa = dr.Item(0).ToString
                            cbo_compartimento.DataSource = compartimento.getCompartimentoByFilters()
                            cbo_compartimento.DataTextField = "ds_compartimento"
                            cbo_compartimento.DataValueField = "id_compartimento"
                            cbo_compartimento.DataBind()
                            cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        End If
                    End If
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If


    End Sub
    Protected Sub gridRomaneioCompartimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridRomaneioCompartimento.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) And ViewState.Item("incluirlinha") = "S" Then
            Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
            If Not (dr Is Nothing) Then
                Dim txt_placa As Anthem.TextBox = CType(e.Row.FindControl("txt_placa"), Anthem.TextBox)
                Dim check As Anthem.CheckBox = CType(e.Row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)
                Dim cbo_compartimento As Anthem.DropDownList = CType(e.Row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                Dim txt_volcomp As DataControlFieldCell = CType(e.Row.Cells(3), DataControlFieldCell)
                Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_id_index As DataControlFieldCell = CType(e.Row.Cells(6), DataControlFieldCell)
                Dim txt_id_compartimento As DataControlFieldCell = CType(e.Row.Cells(7), DataControlFieldCell)

                txt_placa.Text = dr.Item(0).ToString
                If dr.Item(2).ToString.Equals(String.Empty) Then
                    If Not (dr.Item(0).ToString.Equals(String.Empty)) Then
                        cbo_compartimento.Enabled = True
                        cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    Else
                        cbo_compartimento.Enabled = False
                    End If
                Else
                    cbo_compartimento.Enabled = True
                    cbo_compartimento.SelectedValue = dr.Item(2).ToString
                End If
                If dr.Item(1).ToString = "S" Then
                    check.Checked = True
                Else
                    check.Checked = False
                End If

                txt_volcomp.Text = dr.Item(3).ToString
                txt_nr_total_litros.Text = dr.Item(4).ToString
                txt_id_index.Text = dr.Item(5).ToString
                txt_id_compartimento.Text = dr.Item(6).ToString

            End If
        End If
    End Sub

    Protected Sub gridRomaneioCompartimento_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridRomaneioCompartimento.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub cmv_placa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try
            Dim veiculo As New Veiculo()

            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim txt_placa As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)

            veiculo.ds_placa = txt_placa.Text
            args.IsValid = veiculo.validarPlaca()
            If Not args.IsValid Then
                messageControl.Alert("Placa não cadastrada.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposVeiculo(ByVal id_index_row As Integer)

        Try
            Dim txt_ds_placa As Anthem.TextBox = CType(gridRomaneioCompartimento.Rows.Item(id_index_row).FindControl("txt_placa"), Anthem.TextBox)
            txt_ds_placa.Text = ""
            If Not (customPage.getFilterValue("lupa_veiculo", "ds_placa").Equals(String.Empty)) Then
                txt_ds_placa.Text = customPage.getFilterValue("lupa_veiculo", "ds_placa").ToString
                loadCompartimentosByPlaca(id_index_row, txt_ds_placa.Text)
            End If

            'loadData()
            customPage.clearFilters("lupa_veiculo")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub cbo_compartimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
        Dim txtvolmaxcomp As DataControlFieldCell = CType(row.Cells.Item(3), DataControlFieldCell)

        Dim compartimento As New Compartimento(Convert.ToInt32(cbo_compartimento.SelectedValue))
        Dim ds As DataSet = compartimento.getCompartimentoByFilters()

        txtvolmaxcomp.Text = ds.Tables(0).Rows(0).Item("nr_volume")

    End Sub

    Private Sub loadCompartimentosByPlaca(ByVal id_index_row As Int32, ByVal ds_placa As String)

        Try

            Dim cbo_compartimento As Anthem.DropDownList = CType(gridRomaneioCompartimento.Rows.Item(id_index_row).FindControl("cbo_compartimento"), Anthem.DropDownList)

            Dim txt_id_index As DataControlFieldCell = CType(gridRomaneioCompartimento.Rows.Item(id_index_row).Cells(6), DataControlFieldCell)

            txt_id_index.Text = id_index_row.ToString
            cbo_compartimento.Enabled = True
            Dim compartimento As New Compartimento
            compartimento.ds_placa = ds_placa.Trim.ToString
            compartimento.id_situacao = 1
            cbo_compartimento.DataSource = compartimento.getCompartimentoByFilters()
            cbo_compartimento.DataTextField = "ds_compartimento"
            cbo_compartimento.DataValueField = "id_compartimento"
            cbo_compartimento.DataBind()
            cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_placa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        'Dim NomeControle As String = CType(sender, TextBox).ClientID
        '        Dim teste As TextBox = CType(sender, TextBox)
        '       Dim row As GridViewRow = CType(gridRomaneioCompartimento.SelectedRow, GridViewRow)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtplaca As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
        Dim txtvolmaxcomp As DataControlFieldCell = CType(row.Cells.Item(3), DataControlFieldCell)

        txtvolmaxcomp.Text = String.Empty
        cbo_compartimento.Items.Clear()
        cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        cbo_compartimento.Enabled = False

        loadCompartimentosByPlaca(row.RowIndex, txtplaca.Text.Trim.ToString)


    End Sub

End Class
