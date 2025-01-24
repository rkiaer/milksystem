Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_romaneio_saida_consulta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_saida_consulta.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio_saida") Is Nothing) Then
                ViewState.Item("id_romaneio_saida") = Request("id_romaneio_saida")
                ViewState.Item("placa_ativa") = 0 'Assume que a placa ativa é a da 1a aba

                Dim romaneio As New RomaneioSaida(ViewState.Item("id_romaneio_saida"))

                loadData()
            Else
                loadFilters()
                If ViewState.Item("id_romaneio_saida").Equals(String.Empty) Then
                    messageControl.Alert("Há problemas na passagem de parametros. A tela não pode ser montada!")
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_romaneio_saida As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_saida").ToString)
            Dim romaneio As New RomaneioSaida()
            romaneio.id_romaneio_saida = id_romaneio_saida

            Dim dsromaneio As DataSet = romaneio.getRomaneioSaidaByFilters

            With dsromaneio.Tables(0).Rows(0)

                'DADOS GERAIS
                lbl_romaneio.Text = romaneio.id_romaneio_saida.ToString
                lbl_st_romaneio.Text = .Item("nm_situacao_romaneio_saida").ToString
                lbl_estabelecimento.Text = .Item("ds_estabelecimento").ToString
                lbl_tipoleite.Text = .Item("nm_item").ToString
                lbl_tipo_operacao.Text = .Item("nm_tipo_operacao").ToString
                lbl_motivo_saida.Text = .Item("nm_motivo_saida").ToString
                lbl_dt_entrada.Text = Format(DateTime.Parse(.Item("dt_hora_entrada").ToString), "dd/MM/yyyy hh:mm").ToString
                If Not IsDBNull(.Item("dt_hora_saida")) Then
                    lbl_dt_saida.Text = Format(DateTime.Parse(.Item("dt_hora_saida").ToString), "dd/MM/yyyy hh:mm").ToString
                End If

                'DESTINATARIO
                lbl_destino.Text = .Item("nm_cooperativa").ToString
                lbl_destino_cnpj.Text = .Item("cd_cnpj_cooperativa").ToString

                'Transportador
                lbl_transportador.Text = .Item("nm_transportador").ToString
                lbl_transportador_cnpj.Text = .Item("cd_cnpj_transportador").ToString

                If Not IsDBNull(.Item("id_motorista")) Then
                    lbl_motorista.Text = .Item("nm_motorista_cadastro").ToString
                    lbl_cd_cnh.Text = .Item("cd_cnh_cadastro").ToString
                Else
                    lbl_motorista.Text = .Item("nm_motorista").ToString
                    lbl_cd_cnh.Text = .Item("cd_cnh").ToString
                End If

                lbl_placa.Text = .Item("ds_placa").ToString

                If Not IsDBNull(.Item("nr_tara")) Then
                    lbl_tara.Text = .Item("nr_tara").ToString
                End If

                If Not IsDBNull(.Item("id_romaneio_entrada")) Then
                    lbl_romaneio_entrada.Text = .Item("id_romaneio_entrada").ToString
                End If

                If Not IsDBNull(.Item("dt_pesagem_inicial")) Then
                    lbl_dt_pesagem_inicial.Text = Format(DateTime.Parse(.Item("dt_pesagem_inicial")), "dd/MM/yyyy HH:mm")
                    lbl_nr_pesagem_inicial.Text = FormatNumber(.Item("nr_pesagem_inicial"), 0).ToString
                End If

                If Not IsDBNull(.Item("dt_pesagem_final")) Then
                    lbl_dt_pesagem_final.Text = Format(DateTime.Parse(.Item("dt_pesagem_final")), "dd/MM/yyyy HH:mm")
                    lbl_nr_pesagem_final.Text = FormatNumber(.Item("nr_pesagem_final"), 0).ToString
                    lbl_nr_peso_liquido_balanca.Text = (CDec(.Item("nr_peso_liquido"))).ToString("######")
                End If

                If Not IsDBNull(.Item("id_frete_nf")) Then
                    'se frete CIF quem paga é o emitente, nesta caso a Danone
                    If .Item("id_frete_nf").ToString.Equals("1") Then
                        lbl_ds_frete.Text = "Danone"
                    End If
                    'se frete FOB quem paga é o destinatario, nesta caso a COOP
                    If .Item("id_frete_nf").ToString.Equals("2") Then
                        lbl_ds_frete.Text = "Destinatário"
                    End If
                End If
            End With

            Dim romaneionota As New RomaneioSaidaNota

            romaneionota.id_romaneio_saida = id_romaneio_saida
            Dim dsnota As DataSet = romaneionota.getRomaneioSaidaNota

            If dsnota.Tables(0).Rows.Count > 0 Then
                With dsnota.Tables(0).Rows(0)
                    '***********SOLICITACAO NOTA
                    If Not IsDBNull(.Item("dt_solicitacao_nf")) Then
                        lbl_dt_solicitacao_nf.Text = Format(DateTime.Parse(.Item("dt_solicitacao_nf").ToString), "dd/MM/yyyy hh:mm").ToString
                        lbl_nm_situacao_romaneio_saida_nota.Text = .Item("nm_situacao_romaneio_saida_nota").ToString
                    End If
                    If Not IsDBNull(.Item("nr_peso_liquido_nota")) Then
                        lbl_nr_peso_liquido_nota.Text = FormatNumber(CDec(.Item("nr_peso_liquido_nota").ToString), 0)
                    End If
                    If Not IsDBNull(.Item("nr_valor_nota_fiscal")) Then
                        lbl_nr_valor_nota.Text = FormatNumber(CDec(.Item("nr_valor_nota_fiscal").ToString), 2)
                    End If
                    If Not IsDBNull(.Item("nr_quantidade")) Then
                        lbl_quantidade.Text = FormatNumber(CDec(.Item("nr_quantidade").ToString), 0)
                    End If
                    If Not IsDBNull(.Item("nr_valor_unitario")) Then
                        lbl_preco_unitario.Text = FormatNumber(CDec(.Item("nr_valor_unitario").ToString), 2)
                    End If

                    If Not IsDBNull(.Item("nr_valor_frete_acordado")) Then
                        lbl_valor_combinado_frete.Text = FormatNumber(CDec(.Item("nr_valor_frete_acordado").ToString), 2)
                    End If

                    If Not IsDBNull(.Item("nm_usuario_solicitante")) Then
                        lbl_resp_solicitacao_nf.Text = .Item("nm_usuario_solicitante").ToString
                    End If

                    'DADOS NOTA ANEXADA
                    'se tem nf anexa
                    If Not IsDBNull(.Item("id_romaneio_saida_nota_anexo_nf")) Then
                        lbl_nr_nota_fiscal.Text = .Item("nr_nota_fiscal")
                        lbl_dt_saida_nota.Text = Format(DateTime.Parse(.Item("dt_emissao_nota").ToString), "dd/MM/yyyy").ToString
                        If Not IsDBNull(.Item("nr_qtde_nf_anexo")) Then
                            lbl_peso_nf.Text = FormatNumber(CDec(.Item("nr_qtde_nf_anexo").ToString), 0)
                        End If
                        If Not IsDBNull(.Item("nr_valor_nf_anexo")) Then
                            lbl_valor_total_nota.Text = FormatNumber(CDec(.Item("nr_valor_nf_anexo").ToString), 2)
                        End If
                        'se a nf anexada esta registrada como liberada
                        If CInt(.Item("id_situacao_romaneio_saida_nota")) >= 4 Then
                            lbl_nm_usuario_anexo_nf.Text = .Item("nm_usuario_resp_nf")
                            lbl_dt_liberacao_nf.Text = Format(DateTime.Parse(.Item("dt_usuario_anexo_nf").ToString), "dd/MM/yyyy hh:mm").ToString
                            lbl_nr_nota_fiscal.Visible = False
                            hl_nrnota.Visible = True
                            hl_nrnota.Text = lbl_nr_nota_fiscal.Text
                            hl_nrnota.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", .Item("id_romaneio_saida_nota_anexo_nf").ToString) + String.Format("&id_processo={0}", 11) + String.Format("&txt={0}", ".pdf")
                        End If
                    End If
                    'se tem cte anexa
                    If Not IsDBNull(.Item("id_romaneio_saida_nota_anexo_cte")) Then
                        lbl_nr_cte.Text = .Item("nr_nota_fiscal_cte")
                        lbl_dt_emissao_cte.Text = Format(DateTime.Parse(.Item("dt_emissao_cte").ToString), "dd/MM/yyyy").ToString
                        If Not IsDBNull(.Item("nr_valor_nota_fiscal_cte")) Then
                            lbl_valor_cte.Text = FormatNumber(CDec(.Item("nr_valor_nota_fiscal_cte").ToString), 2)
                        End If
                        'se a cte anexada esta registrada como liberada
                        If CInt(.Item("id_situacao_romaneio_saida_nota")) = 5 Then
                            lbl_nm_liberacao_cte.Text = .Item("nm_usuario_resp_cte")
                            lbl_dt_liberacao_cte.Text = Format(DateTime.Parse(.Item("dt_usuario_anexo_cte").ToString), "dd/MM/yyyy hh:mm").ToString
                            lbl_nr_cte.Visible = False
                            hl_nrnotacte.Visible = True
                            hl_nrnotacte.Text = .Item("nr_nota_fiscal_cte")
                            hl_nrnotacte.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", .Item("id_romaneio_saida_nota_anexo_cte").ToString) + String.Format("&id_processo={0}", 11) + String.Format("&txt={0}", ".pdf")
                        End If
                    End If

                End With
            End If

            'placas
            loadplacas()


            'documentos anexados
            'grid
            Dim anexo As New RomaneioSaida
            anexo.id_romaneio_saida = ViewState.Item("id_romaneio_saida")

            Dim dsdocumentos As DataSet = anexo.getRomaneioSaidaTodosAnexos()
            If (dsdocumentos.Tables(0).Rows.Count > 0) Then
                gridAnexos.Visible = True
                gridAnexos.DataSource = Helper.getDataView(dsdocumentos.Tables(0), ViewState.Item("sortExpression"))
                gridAnexos.DataBind()
            Else

                Dim dataRow As System.Data.DataRow = dsdocumentos.Tables(0).NewRow()
                dsdocumentos.Tables(0).Rows.InsertAt(dataRow, 0)
                gridAnexos.Visible = True
                gridAnexos.DataSource = Helper.getDataView(dsdocumentos.Tables(0), "")
                gridAnexos.DataBind()
                gridAnexos.Rows(0).Cells.Clear()
                gridAnexos.Rows(0).Cells.Add(New TableCell())
                gridAnexos.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridAnexos.Rows(0).Cells(0).Text = "Não existem documentos anexados!"
                gridAnexos.Rows(0).Cells(0).ColumnSpan = 7
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

 
    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_romaneio_saida_consulta.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_saida_consulta.aspx")


    End Sub


    Private Sub saveFilters()

        Try

            customPage.setFilter("frm_rs_consulta", "id_romaneio_saida", ViewState.Item("id_romaneio_saida").ToString)
            customPage.setFilter("frm_rs_consulta", "placa_ativa", ViewState.Item("placa_ativa").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("frm_rs_consulta", "id_romaneio_saida").Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio_saida") = customPage.getFilterValue("frm_rs_consulta", "id_romaneio_saida")
        Else
            ViewState.Item("id_romaneio_saida") = String.Empty
        End If

        'If Not (customPage.getFilterValue("frm_rs_consulta", "placa_ativa").Equals(String.Empty)) Then
        'hasFilters = True
        'ViewState.Item("placa_ativa") = customPage.getFilterValue("frm_rs_consulta", "placa_ativa")
        'Else
        ViewState.Item("placa_ativa") = 0
        'End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("frm_rs_consulta")
        End If

    End Sub

    Protected Sub lk_AnexarDocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_AnexarDocumento.Click

        Response.Redirect("frm_romaneio_saida_anexo.aspx?id=" + ViewState.Item("id_romaneio_saida").ToString() + "&tela=frm_romaneio_saida_consulta.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida").ToString)

    End Sub
    Private Sub loadplacas()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_saida").ToString)
            Dim rplaca As New RomaneioSaidaPlaca
            Dim placa As Integer

            rplaca.id_romaneio_saida = id_romaneio

            Dim dsplacas As DataSet = rplaca.getRomaneioSaidaPlacasByRomaneio()

            If (dsplacas.Tables(0).Rows.Count > 0) Then
                For placa = 0 To dsplacas.Tables(0).Rows.Count - 1
                    With dsplacas.Tables(0).Rows(placa)
                        Select Case placa
                            Case 0
                                Me.btn_placa1.Text = .Item("ds_placa")
                                Me.btn_placa1.CommandArgument = .Item("id_romaneio_saida_placa")
                            Case 1
                                Me.pnl_placa2.Visible = True
                                Me.btn_placa2.Visible = True
                                Me.btn_placa2.Text = .Item("ds_placa")
                                Me.btn_placa2.CommandArgument = .Item("id_romaneio_saida_placa")
                            Case 2
                                Me.pnl_placa3.Visible = True
                                Me.btn_placa3.Visible = True
                                Me.btn_placa3.Text = .Item("ds_placa")
                                Me.btn_placa3.CommandArgument = .Item("id_romaneio_saida_placa")
                            Case 3
                                Me.pnl_placa4.Visible = True
                                Me.btn_placa4.Visible = True
                                Me.btn_placa4.Text = .Item("ds_placa")
                                Me.btn_placa4.CommandArgument = .Item("id_romaneio_saida_placa")
                            Case 4
                                Me.pnl_placa4.Visible = True
                                Me.btn_placa5.Visible = True
                                Me.btn_placa5.Text = .Item("ds_placa")
                                Me.btn_placa5.CommandArgument = .Item("id_romaneio_saida_placa")
                        End Select
                    End With
                Next
                loadabasplacas()
            Else
                messageControl.Alert("Não há placas cadastradas para este romaneio. Há problemas na passagem de parametros.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadabasplacas()

        Try

            Dim lid_romaneio_placa_ativa As Int32
            td_placa1.Attributes.Remove("class")
            If ViewState("placa_ativa") = 0 Then
                'td_placa1.Attributes.Add("class", "aba_ativa")
                pnl_placa1.BackImageUrl = "~/img/aba_ativa.gif"
                pnl_placa1.ForeColor = System.Drawing.Color.FromName("#0000F5")
                btn_placa1.ForeColor = System.Drawing.Color.FromName("#0000F5")
                'btn_placa1.Attributes.Add("forecolor", "#0000F5")
                lid_romaneio_placa_ativa = btn_placa1.CommandArgument
            Else
                pnl_placa1.BackImageUrl = "~/img/aba_nao_ativa.gif"
                pnl_placa1.ForeColor = System.Drawing.Color.FromName("#6767CC")
                btn_placa1.ForeColor = System.Drawing.Color.FromName("#6767CC")
            End If
            If btn_placa2.Visible = True Then
                'td_placa2.Attributes.Remove("class")
                If ViewState("placa_ativa") = 1 Then
                    'td_placa2.Attributes.Add("class", "aba_ativa")
                    pnl_placa2.BackImageUrl = "~/img/aba_ativa.gif"
                    pnl_placa2.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    btn_placa2.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    lid_romaneio_placa_ativa = btn_placa2.CommandArgument
                Else
                    'td_placa2.Attributes.Add("class", "aba_nao_ativa")
                    pnl_placa2.BackImageUrl = "~/img/aba_nao_ativa.gif"
                    pnl_placa2.ForeColor = System.Drawing.Color.FromName("#6767CC")
                    btn_placa2.ForeColor = System.Drawing.Color.FromName("#6767CC")
                End If
            End If
            If btn_placa3.Visible = True Then
                'td_placa3.Attributes.Remove("class")
                If ViewState("placa_ativa") = 2 Then
                    pnl_placa3.BackImageUrl = "~/img/aba_ativa.gif"
                    pnl_placa3.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    btn_placa3.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    lid_romaneio_placa_ativa = btn_placa3.CommandArgument
                Else
                    pnl_placa3.BackImageUrl = "~/img/aba_nao_ativa.gif"
                    pnl_placa3.ForeColor = System.Drawing.Color.FromName("#6767CC")
                    btn_placa3.ForeColor = System.Drawing.Color.FromName("#6767CC")
                End If
            End If
            If btn_placa4.Visible = True Then
                'td_placa4.Attributes.Remove("class")
                If ViewState("placa_ativa") = 3 Then
                    pnl_placa4.BackImageUrl = "~/img/aba_ativa.gif"
                    pnl_placa4.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    btn_placa4.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    lid_romaneio_placa_ativa = btn_placa4.CommandArgument

                Else
                    pnl_placa4.BackImageUrl = "~/img/aba_nao_ativa.gif"
                    pnl_placa4.ForeColor = System.Drawing.Color.FromName("#6767CC")
                    btn_placa4.ForeColor = System.Drawing.Color.FromName("#6767CC")
                End If
            End If
            If btn_placa5.Visible = True Then
                'td_placa5.Attributes.Remove("class")
                If ViewState("placa_ativa") = 4 Then
                    pnl_placa5.BackImageUrl = "~/img/aba_ativa.gif"
                    pnl_placa5.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    btn_placa5.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    lid_romaneio_placa_ativa = btn_placa5.CommandArgument

                Else
                    pnl_placa5.BackImageUrl = "~/img/aba_nao_ativa.gif"
                    pnl_placa5.ForeColor = System.Drawing.Color.FromName("#6767CC")
                    btn_placa5.ForeColor = System.Drawing.Color.FromName("#6767CC")

                End If
            End If

            loadPlacaAtiva(lid_romaneio_placa_ativa)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadPlacaAtiva(ByVal id_romaneio_saida_placa As Int32)

        Try

            'Dim id_romaneio_placa As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_placa").ToString)
            Dim rplaca As New RomaneioSaidaPlaca(id_romaneio_saida_placa)

            'Alternativa para o 0 do framework pois o inteiro qdo sem valor sempre assume 0 porem 0 para este campo é um valor válido
            Dim dsrplaca As DataSet = rplaca.getRomaneioSaidaPlacasByFilters

            loadgridcompartimento(rplaca.ds_placa)
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadgridcompartimento(ByVal ds_placa As String)

        Try

            Dim rc As New RomaneioSaidaCompartimento

            rc.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
            rc.ds_placa = ds_placa

            Dim dsrc As DataSet = rc.getRomaneioSaidaCompartimentoByFilters()

            If (dsrc.Tables(0).Rows.Count > 0) Then
                gridCompartimento.Visible = True
                gridCompartimento.DataSource = Helper.getDataView(dsrc.Tables(0), "")
                gridCompartimento.DataBind()

            Else
                Dim dr As DataRow = dsrc.Tables(0).NewRow()
                'dr("id_candidato_idioma") = -1
                dsrc.Tables(0).Rows.InsertAt(dr, 0)
                gridCompartimento.Visible = True
                gridCompartimento.DataSource = Helper.getDataView(dsrc.Tables(0), ViewState.Item("sortExpression"))
                gridCompartimento.DataBind()
                gridCompartimento.Rows(0).Cells.Clear()
                gridCompartimento.Rows(0).Cells.Add(New TableCell())
                gridCompartimento.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridCompartimento.Rows(0).Cells(0).Text = "Não existe nenhum compartimento cadastrado!"
                gridCompartimento.Rows(0).Cells(0).ColumnSpan = 6
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Protected Sub btn_placa1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa1.Click
        ViewState("placa_ativa") = 0
        loadabasplacas()

    End Sub
    Protected Sub btn_placa2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa2.Click
        ViewState("placa_ativa") = 1
        loadabasplacas()

    End Sub
    Protected Sub btn_placa3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa3.Click
        ViewState("placa_ativa") = 2
        loadabasplacas()

    End Sub
    Protected Sub btn_placa4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa4.Click
        ViewState("placa_ativa") = 3
        loadabasplacas()

    End Sub
    Protected Sub btn_placa5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa5.Click
        ViewState("placa_ativa") = 4
        loadabasplacas()

    End Sub

    Protected Sub gridCompartimento_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridCompartimento.RowCommand
        Select Case e.CommandName.ToString().ToLower()
            Case "anexar"
                Response.Redirect("frm_romaneio_saida_analise_comp_anexos.aspx?id=" + ViewState.Item("id_romaneio_saida").ToString() + "&tela=frm_romaneio_saida_consulta.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida").ToString)

            Case "analises"
                'saveParams()


                Response.Redirect("frm_romaneio_saida_consulta_analise.aspx?id_romaneio_saida_compartimento=" + e.CommandArgument.ToString)
        End Select

    End Sub
    'Protected Sub gridCompartimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCompartimento.RowDataBound
    '    If (e.Row.RowType = DataControlRowType.DataRow) Then
    '        Try

    '            Dim lbl_st_reanalise As Label = CType(e.Row.FindControl("lbl_st_reanalise"), Label)
    '            Dim img_reanalise As Image = CType(e.Row.FindControl("img_reanalise"), Image)
    '            Dim lbl_st_registro As Label = CType(e.Row.FindControl("lbl_st_registro"), Label)


    '            'Se o romaneio compartimento é reanalise
    '            If lbl_st_reanalise.Text.Trim = "S" Then
    '                img_reanalise.ImageUrl = "~/img/ico_chk_true.gif"
    '            Else
    '                img_reanalise.ImageUrl = "~/img/ico_chk_false.gif"
    '            End If



    '        Catch ex As Exception
    '            messageControl.Alert(ex.Message)
    '        End Try
    '    End If

    'End Sub
    Protected Sub gridAnexos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridAnexos.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lid As String
            Dim hl_download As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_download"), System.Web.UI.WebControls.HyperLink)
            Dim lbl_id_tipo_anexo As Label = CType(e.Row.FindControl("lbl_id_tipo_anexo"), Label)
            Dim lbl_id_origem As Label = CType(e.Row.FindControl("lbl_id_origem"), Label)
            If (Not hl_download.Text.ToString().Equals(String.Empty)) Then
                lid = Me.gridAnexos.DataKeys(e.Row.RowIndex).Value.ToString
                If Not lbl_id_tipo_anexo.Text.Equals(String.Empty) Then
                    If CInt(lbl_id_tipo_anexo.Text) = 0 Then
                        'analise
                        hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", lid) + String.Format("&id_processo={0}", 9)

                    Else
                        hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", lid) + String.Format("&id_processo={0}", 11)

                    End If
                End If
            End If

        End If

    End Sub
End Class
