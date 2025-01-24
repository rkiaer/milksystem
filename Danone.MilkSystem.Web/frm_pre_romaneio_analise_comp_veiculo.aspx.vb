Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_pre_romaneio_analise_comp_veiculo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_pre_romaneio_analise_comp_veiculo.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                ViewState.Item("caminho_servidor") = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()

                Dim companalise As New Romaneio
                companalise.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

                cbo_cd_analise.DataSource = companalise.getRomaneioAnalisesCompartimentosDistinct()
                cbo_cd_analise.DataTextField = "ds_cd_analise"
                cbo_cd_analise.DataValueField = "id_analise"
                cbo_cd_analise.DataBind()
                cbo_cd_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

                grdAnalises.Visible = False
                loadData()
            Else
                messageControl.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim romaneio As New Romaneio
            romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            Dim dsromaneio As DataSet = romaneio.getPreRomaneioTransitPointByFilters
            'Se ha linhas na romaneio 
            If (dsromaneio.Tables(0).Rows.Count > 0) Then
                With dsromaneio.Tables(0).Rows(0)
                    If Not IsDBNull(.Item("id_cooperativa")) AndAlso .Item("id_cooperativa") > 0 Then
                        lbl_romaneio.Text = "Cooperativa"
                        grdCompartimentos.Columns(5).Visible = False
                    End If
                    If Not IsDBNull(.Item("nr_caderneta")) AndAlso .Item("nr_caderneta") > 0 Then
                        lbl_romaneio.Text = "Coletas Produtores"
                    End If

                    Me.lbl_id_romaneio.Text = .Item("id_romaneio").ToString
                    Me.lbl_nm_linha.Text = .Item("nm_linha")
                    Me.lbl_nm_st_romaneio.Text = .Item("nm_st_romaneio").ToString
                    Me.lbl_estabelecimento.Text = .Item("ds_estabelecimento")
                    Me.lbl_nm_item.Text = .Item("nm_item")
                    Me.lbl_nm_transit_point_unidade.Text = .Item("ds_transit_point_unidade")

                    ViewState.Item("id_estabelecimento") = .Item("id_estabelecimento")
                    ViewState.Item("id_transit_point_unidade") = .Item("id_transit_point_unidade")
                    ViewState.Item("cd_transit_point_unidade") = .Item("cd_transit_point_unidade")

                    If CInt(.Item("id_st_romaneio").ToString) > 8 Then 'se situacao do pre romaneio 8 (DDISPONIVEL) 9 (INDISPONIVEL) já liberou os registros
                        btn_registrar.Enabled = False
                        btn_registrar.ImageUrl = "~/img/bnt_registrar2_desabilitado.gif"
                        lk_liberar.Enabled = False
                    End If
                End With

                'FRan 03/12/2018 i 
                Dim lnr_tempo_rota As Decimal
                If lbl_romaneio.Text <> "Cooperativa" Then
                    tr_temporota.Visible = True
                    Dim dstemporota As DataSet = romaneio.getRomaneioTempoRotabyRomaneio
                    If dstemporota.Tables(0).Rows.Count > 0 Then
                        lnr_tempo_rota = dstemporota.Tables(0).Rows(0).Item("ds_tempo_rota_minutos")

                        Select Case lnr_tempo_rota

                            Case Is <= 720 ' Até 12 horas (720 minutos)

                                lbl_green.CssClass = "text temporotagreen"
                                img_green.ImageUrl = "~/img/icon_status_verde.gif"

                                lbl_red.CssClass = "text temporotadesabilitado"
                                img_red.ImageUrl = "~/img/icon_status_cinza.gif"

                                lbl_yellow.CssClass = "text temporotadesabilitado"
                                img_yellow.ImageUrl = "~/img/icon_status_cinza.gif"

                            Case Is <= 1200
                                lbl_green.CssClass = "text temporotadesabilitado"
                                img_green.ImageUrl = "~/img/icon_status_cinza.gif"

                                lbl_red.CssClass = "text temporotadesabilitado"
                                img_red.ImageUrl = "~/img/icon_status_cinza.gif"

                                lbl_yellow.CssClass = "text temporotayellow"
                                img_yellow.ImageUrl = "~/img/icon_status_amarelo.gif"

                            Case Is > 1200
                                lbl_green.CssClass = "text temporotadesabilitado"
                                img_green.ImageUrl = "~/img/icon_status_cinza.gif"

                                lbl_yellow.CssClass = "text temporotadesabilitado"
                                img_yellow.ImageUrl = "~/img/icon_status_cinza.gif"

                                lbl_red.CssClass = "text temporotared"
                                img_red.ImageUrl = "~/img/icon_status_vermelho.gif"

                        End Select
                    Else 'se nao trouxe tempo de rota é porque esta com diferenca negativa (data coleta maior que data romaneio)
                        lbl_green.CssClass = "text temporotadesabilitado"
                        img_green.ImageUrl = "~/img/icon_status_cinza.gif"

                        lbl_yellow.CssClass = "text temporotadesabilitado"
                        img_yellow.ImageUrl = "~/img/icon_status_cinza.gif"

                        lbl_red.CssClass = "text temporotadesabilitado"
                        img_red.ImageUrl = "~/img/icon_status_cinza.gif"

                    End If
                Else
                    tr_temporota.Visible = False

                End If
                'Fran 03/12/2018 f

            End If

            Dim romaneiocompartimento As New Romaneio_Compartimento

            romaneiocompartimento.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

            Dim dsromaneiocomp As DataSet = romaneiocompartimento.getRomaneio_CompartimentoByFilters

            'Se ha linhas na romaneio compartimento
            If (dsromaneiocomp.Tables(0).Rows.Count > 0) Then

                If Not IsDBNull(dsromaneiocomp.Tables(0).Rows(0).Item("nm_analista")) Then
                    txt_nm_analista.Text = dsromaneiocomp.Tables(0).Rows(0).Item("nm_analista")
                Else
                    txt_nm_analista.Text = Session("ds_login")   ' Adri 24/11/2008
                End If

                If Not IsDBNull(dsromaneiocomp.Tables(0).Rows(0).Item("dt_inicio_analise")) Then
                    txt_hr_analise.Text = Format(DateTime.Parse(dsromaneiocomp.Tables(0).Rows(0).Item("dt_inicio_analise")), "HH")
                    txt_mm_analise.Text = Format(DateTime.Parse(dsromaneiocomp.Tables(0).Rows(0).Item("dt_inicio_analise")), "mm")
                    txt_dt_analise.Text = Format(DateTime.Parse(dsromaneiocomp.Tables(0).Rows(0).Item("dt_inicio_analise")), "dd/MM/yyyy").ToString
                    txt_hr_analise.Enabled = False
                    txt_mm_analise.Enabled = False
                    txt_dt_analise.Enabled = False
                Else
                    txt_hr_analise.Text = Format(DateTime.Parse(Now), "HH")
                    txt_mm_analise.Text = Format(DateTime.Parse(Now), "mm")
                    txt_dt_analise.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy").ToString
                End If

                If (dsromaneiocomp.Tables(0).Rows.Count > 0) Then
                    grdCompartimentos.Visible = True
                    ViewState.Item("loaddata") = "S"
                    grdCompartimentos.DataSource = Helper.getDataView(dsromaneiocomp.Tables(0), ViewState.Item("sortExpression"))
                    grdCompartimentos.DataBind()
                    ViewState.Item("loaddata") = "N"
                Else
                    grdCompartimentos.Visible = False
                    messageControl.Alert("Há problemas na passagem de parâmetros. Por favor tente novamente.")
                End If
            End If

            cbo_cd_analise.Focus()      ' 21/01/2009 - Rls15
            navegacaoGrdAnalise()

            'se já registrou analises do compartimento ou seja se status analise compartimento do romaneio é diferente de nulo
            If Not IsDBNull(dsromaneio.Tables(0).Rows(0).Item("id_st_analise_compartimento")) AndAlso CInt(dsromaneio.Tables(0).Rows(0).Item("id_st_analise_compartimento").ToString) <> 0 Then
                btn_registrar.Enabled = False
                btn_registrar.ImageUrl = "~/img/bnt_registrar2_desabilitado.gif"
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
                If CInt(dsromaneio.Tables(0).Rows(0).Item("id_st_romaneio")) = 8 Then 'se status do romaneio é pre romaneio em analise
                    lk_liberar.Enabled = True
                    lk_liberar.ToolTip = "Liberar o pré-romaneio registrado para que fique disponível no Transit Point."
                Else
                    lk_liberar.Enabled = False
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_pre_romaneio_analise_selecao.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_pre_romaneio_analise_selecao.aspx")

    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub
    Private Sub updateData()

        If Page.IsValid Then

            Try

                Dim rc As New Romaneio_Compartimento()
                rc.dt_inicio_analise = txt_dt_analise.Text & " " & txt_hr_analise.Text & ":" & txt_mm_analise.Text & ":00"
                rc.nm_analista = txt_nm_analista.Text.ToString
                rc.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                rc.id_modificador = Session("id_login")

                rc.updateRomaneio_CompartimentosAnalista()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.id_menu_item = 165
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 


                'atualiza romaneio para em analise
                Dim romaneio As New Romaneio(ViewState.Item("id_romaneio"))
                If romaneio.id_st_romaneio = 7 Then
                    romaneio.id_st_romaneio = 8
                    romaneio.id_modificador = Session("id_login")
                    romaneio.updateRomaneioSituacao()

                End If

                Dim row As GridViewRow
                Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento
                For Each row In grdAnalises.Rows

                    If (Not (row) Is Nothing) Then

                        Dim txt_ds_comentario As TextBox = CType(row.FindControl("txt_ds_comentario"), TextBox)
                        Dim lbl_id_romaneio_compartimento As Label = CType(row.FindControl("lbl_id_romaneio_compartimento"), Label)
                        Dim lbl_ds_comentario As Label = CType(row.FindControl("lbl_ds_comentario"), Label)

                        romaneioanalisecompartimento.id_analise_compartimento = Convert.ToInt32(grdAnalises.DataKeys.Item(row.RowIndex).Value)
                        If grdAnalises.Columns(3).Visible = True Then
                            romaneioanalisecompartimento.ds_comentario = txt_ds_comentario.Text
                        Else
                            If ViewState.Item(String.Concat("txt_ds_comentario", row.RowIndex.ToString)) Is Nothing Then
                                romaneioanalisecompartimento.ds_comentario = lbl_ds_comentario.Text
                            Else
                                romaneioanalisecompartimento.ds_comentario = ViewState.Item(String.Concat("txt_ds_comentario", row.RowIndex.ToString)).ToString
                            End If
                        End If
                        romaneioanalisecompartimento.id_modificador = Session("id_login")

                        Select Case Convert.ToInt32(ViewState.Item("id_formato_analise"))
                            Case 1 'Descimal
                                Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                                If Not (txt_dec_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                                    romaneioanalisecompartimento.nr_valor = Convert.ToDecimal(txt_dec_nr_valor.Text.Trim.ToString)
                                    If romaneioanalisecompartimento.nr_valor >= CDec(ViewState.Item("nr_faixa_inicial")) And romaneioanalisecompartimento.nr_valor <= CDec(ViewState.Item("nr_faixa_final")) Then
                                        romaneioanalisecompartimento.id_st_analise = 1 'Aprovado
                                    Else
                                        romaneioanalisecompartimento.id_st_analise = 2 'Reprovado
                                    End If
                                End If

                            Case 2 'Inteiro
                                Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                                If Not (txt_int_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                                    romaneioanalisecompartimento.nr_valor = Convert.ToDecimal(Convert.ToInt32(txt_int_nr_valor.Text))
                                    If CLng(romaneioanalisecompartimento.nr_valor) >= CLng(ViewState.Item("nr_faixa_inicial")) And romaneioanalisecompartimento.nr_valor <= CLng(ViewState.Item("nr_faixa_final")) Then
                                        romaneioanalisecompartimento.id_st_analise = 1 'Aprovado
                                    Else
                                        romaneioanalisecompartimento.id_st_analise = 2 'Reprovado
                                    End If
                                End If

                            Case 3 'Logico
                                Dim cbo_nr_valor As DropDownList = CType(row.FindControl("cbo_nr_valor"), DropDownList)
                                If Not (cbo_nr_valor.SelectedValue.Trim().Equals(String.Empty)) Then
                                    romaneioanalisecompartimento.nr_valor = Convert.ToDecimal(Convert.ToInt32(cbo_nr_valor.SelectedValue))
                                    If CLng(romaneioanalisecompartimento.nr_valor) = CLng(ViewState.Item("id_faixa_referencia_logica")) Then
                                        romaneioanalisecompartimento.id_st_analise = 1 'Aprovado
                                    Else
                                        romaneioanalisecompartimento.id_st_analise = 2 'Reprovado
                                    End If

                                End If

                        End Select
                        If ViewState.Item("st_gera_ciq") = "N" Then
                            If romaneioanalisecompartimento.id_st_analise = 2 Then 'Rejeitado
                                romaneioanalisecompartimento.id_st_original = 2
                                romaneioanalisecompartimento.id_st_analise = 1
                            Else
                                romaneioanalisecompartimento.id_st_original = 0
                                romaneioanalisecompartimento.id_st_analise = 1
                            End If

                        End If

                        romaneioanalisecompartimento.updateRomaneioAnaliseCompartimento()
                        'se tem analises rejeitadas para o compartimento
                        atualizarCboRegistroAnalise(Convert.ToInt32(ViewState.Item("id_romaneio")), Convert.ToInt32(lbl_id_romaneio_compartimento.Text))
                        'loadGridAnalise()
                    End If
                Next
                loadData()
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub




    Protected Sub grdCompartimentos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdCompartimentos.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "EmailCIQ"
                If Page.IsValid = True Then
                    Try
                        Dim notificacao As New Notificacao
                        Dim lAssunto As String = "RELATÓRIO CIQ " & e.CommandArgument.ToString & " - UNIDADE DE TRANSIT POINT " & ViewState.Item("cd_transit_point_unidade").ToString
                        Dim lCorpo As String = "Existe uma ocorrência relatada através do Relatório CIQ, de um pré-romaneio da unidade de transit point, que pode ser visualizado pelo link " & ViewState.Item("caminho_servidor") & "/frm_relatorio_CIQ.aspx?id_romaneio_compartimento=" & e.CommandArgument.ToString & " ."

                        'fran 25/11/2009 i Maracanau - chamado 518
                        'If notificacao.enviaMensagemEmail(1, lAssunto, lCorpo, MailPriority.High) = True Then
                        If notificacao.enviaMensagemEmail(1, lAssunto, lCorpo, MailPriority.High, , , Convert.ToInt32(ViewState.Item("id_estabelecimento"))) = True Then
                            'fran 25/11/2009 f Maracanau - chamado 518
                            messageControl.Alert("O Relatório CIQ foi enviado aos destinatários cadastrados com sucesso!")
                        Else
                            messageControl.Alert("O Relatório CIQ não pode ser enviado pois não há emails cadastrados para este relatório.")
                        End If
                    Catch ex As Exception
                        messageControl.Alert(ex.Message)
                    End Try
                End If
            Case "Registrar_Analise_UProducao"
                Response.Redirect("lst_romaneio_analises_uproducao.aspx?id_romaneio=" + ViewState.Item("id_romaneio") + "&id_romaneio_compartimento=" + e.CommandArgument.ToString + "&nm_tela=frm_pre_romaneio_analise_comp_veiculo.aspx")

        End Select

    End Sub

    Protected Sub grdCompartimentos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCompartimentos.RowCreated
    End Sub

    Protected Sub grdCompartimentos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCompartimentos.RowDataBound

        If (e.Row.RowType = DataControlRowType.DataRow) And ViewState.Item("loaddata") = "S" Then
            Try

                Dim cbo_registrar_id_st_analise As Anthem.DropDownList = CType(e.Row.FindControl("cbo_registrar_id_st_analise"), Anthem.DropDownList)
                Dim lbl_id_st_analise As Label = CType(e.Row.FindControl("lbl_id_st_analise"), Label)
                Dim lbl_nm_st_analise As Label = CType(e.Row.FindControl("lbl_nm_st_analise"), Label)
                Dim hl_imprimir_ciq As Anthem.HyperLink = CType(e.Row.FindControl("hl_imprimir_ciq"), Anthem.HyperLink)
                Dim btn_email As ImageButton = CType(e.Row.FindControl("btn_email"), ImageButton)
                Dim btn_registrar_analise_uproducao As ImageButton = CType(e.Row.FindControl("btn_registrar_analise_uproducao"), ImageButton)
                Dim img_reanalise As Image = CType(e.Row.FindControl("img_reanalise"), Image)
                Dim lbl_st_registro As Label = CType(e.Row.FindControl("lbl_st_registro"), Label)

                Dim resultadoanalise As New StatusResultadoAnalise
                cbo_registrar_id_st_analise.DataSource = resultadoanalise.getStatusResultadoAnaliseByFilters()
                cbo_registrar_id_st_analise.DataTextField = "nm_status_resultado_analise"
                cbo_registrar_id_st_analise.DataValueField = "id_status_resultado_analise"
                cbo_registrar_id_st_analise.DataBind()

                'Se o compartimento ja esta registrado
                If Not lbl_nm_st_analise.Text.Equals(String.Empty) Then
                    Dim lbl_labelmotivo As Anthem.Label = CType(e.Row.FindControl("lbl_labelmotivo"), Anthem.Label)
                    Dim txt_ds_motivo_aprovado_sob_concessao As Anthem.TextBox = CType(e.Row.FindControl("txt_ds_motivo_aprovado_sob_concessao"), Anthem.TextBox)

                    'pega o valor que ja registrou
                    lbl_st_registro.Visible = True
                    cbo_registrar_id_st_analise.SelectedValue = lbl_id_st_analise.Text
                    cbo_registrar_id_st_analise.Visible = False

                    'Se for aprovado sob concessao
                    If CInt(lbl_id_st_analise.Text) = 2 Then
                        lbl_labelmotivo.Visible = True
                        txt_ds_motivo_aprovado_sob_concessao.Visible = True
                        txt_ds_motivo_aprovado_sob_concessao.Enabled = True
                    End If
                    'Se for analise rejeitada 
                    If CInt(lbl_id_st_analise.Text) = 3 Then
                        hl_imprimir_ciq.Enabled = True
                        hl_imprimir_ciq.ImageUrl = "~/img/ic_impressao.gif"
                        hl_imprimir_ciq.NavigateUrl = String.Format("frm_relatorio_CIQ.aspx?id_romaneio_compartimento={0}", grdCompartimentos.DataKeys.Item(e.Row.RowIndex).Value)
                        btn_email.Enabled = True
                        btn_email.ImageUrl = "~/img/ico_email.gif"
                    End If
                    If CInt(lbl_id_st_analise.Text) = 3 Then
                        btn_registrar_analise_uproducao.Enabled = True
                        btn_registrar_analise_uproducao.ImageUrl = "~/img/icon_registrar2.gif"
                    End If
                Else
                    'pega o valor que ja registrou
                    lbl_st_registro.Visible = False
                    cbo_registrar_id_st_analise.Visible = True

                    Dim romaneioanalisecomp As New RomaneioAnaliseCompartimento
                    'se tem analises rejeitadas para o compartimento
                    romaneioanalisecomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                    romaneioanalisecomp.id_romaneio_compartimento = Convert.ToInt32(grdCompartimentos.DataKeys.Item(e.Row.RowIndex).Value)

                    If romaneioanalisecomp.getRomaneioAnaliseCompartimentoRejeitada() > 0 Then
                        cbo_registrar_id_st_analise.SelectedValue = 3
                    Else
                        cbo_registrar_id_st_analise.SelectedValue = 1
                    End If
                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
    Private Sub loadAnalise()

        Try

            Dim analisecomp As New RomaneioAnaliseCompartimento

            analisecomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            analisecomp.id_analise = Convert.ToInt32(ViewState.Item("id_analise"))

            Dim dsromaneiocomp As DataSet = analisecomp.getRomaneioAnalisesCompartimentosByFilters

            'Se ha linhas na romaneio compartimento
            If (dsromaneiocomp.Tables(0).Rows.Count > 0) Then

                'Pega os dados da analise escolhida e guarda
                With dsromaneiocomp.Tables(0).Rows(0)
                    ViewState.Item("nr_faixa_inicial") = .Item("nr_faixa_inicial")
                    ViewState.Item("nr_faixa_final") = .Item("nr_faixa_final")
                    ViewState.Item("id_faixa_referencia_logica") = .Item("id_faixa_referencia_logica")
                    ViewState.Item("id_grupo_descricao_logica") = .Item("id_grupo_descricao") ''Fran 21/08/2009 i rls18
                    ViewState.Item("id_formato_analise") = .Item("id_formato_analise")
                    ViewState.Item("st_gera_ciq") = .Item("st_gera_ciq")
                    ViewState.Item("nm_sigla") = .Item("nm_sigla")
                    ViewState.Item("st_obrigatoria") = .Item("st_obrigatoria")
                End With
                'Carregar dados da analise na tela
                If ViewState.Item("st_obrigatoria") = "S" Then
                    img_chk_obrigatorio.ImageUrl = "~/img/ico_chk_true.gif"
                Else
                    img_chk_obrigatorio.ImageUrl = "~/img/ico_chk_false.gif"
                End If

                grdAnalises.Visible = True
                'Coluna com os campos para incluir valores da analise
                'Verifica o formato da análise
                Select Case Convert.ToInt32(ViewState.Item("id_formato_analise"))
                    Case 1 'Decimal
                        lbl_faixa_referencial.Text = CStr(CDec(ViewState.Item("nr_faixa_inicial"))) & "  -  " & CStr(CDec(ViewState.Item("nr_faixa_final")))
                    Case 2 'Inteiro
                        lbl_faixa_referencial.Text = CStr(CLng(ViewState.Item("nr_faixa_inicial"))) & "  -  " & CStr(CLng(ViewState.Item("nr_faixa_final")))
                    Case 3 ' Lógico
                        lbl_faixa_referencial.Text = dsromaneiocomp.Tables(0).Rows(0).Item("nm_faixa_referencia_logica")
                End Select

                Dim i As Int32 = 0
                For i = 0 To grdAnalises.Rows.Count - 1
                    ViewState.Item(String.Concat("txt_nr_valor", i.ToString)) = Nothing
                    ViewState.Item(String.Concat("txt_ds_comentario", i.ToString)) = Nothing
                Next
                chk_exibir_comentario.Checked = False


                grdAnalises.Visible = True
                lbl_analiseinformativa.Visible = True
                grdAnalises.DataSource = Helper.getDataView(dsromaneiocomp.Tables(0), ViewState.Item("sortExpression"))
                grdAnalises.DataBind()
            Else
                grdAnalises.Visible = False
                lbl_analiseinformativa.Visible = False
                messageControl.Alert("Há problemas na passagem de parâmetros. Por favor tente novamente.")
            End If
            'grdAnalises.Focus()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub limparAnalise()

        Try

            Dim analisecomp As New RomaneioAnaliseCompartimento

            analisecomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            analisecomp.id_analise = Convert.ToInt32(ViewState.Item("id_analise"))

            Dim dsromaneiocomp As DataSet = analisecomp.getRomaneioAnalisesCompartimentosByFilters

            'Se ha linhas na romaneio compartimento
            If (dsromaneiocomp.Tables(0).Rows.Count > 0) Then
                'Pega os dados da analise escolhida e guarda
                With dsromaneiocomp.Tables(0).Rows(0)
                    ViewState.Item("nr_faixa_inicial") = .Item("nr_faixa_inicial")
                    ViewState.Item("nr_faixa_final") = .Item("nr_faixa_final")
                    ViewState.Item("id_faixa_referencia_logica") = .Item("id_faixa_referencia_logica")
                    ViewState.Item("id_formato_analise") = .Item("id_formato_analise")
                    ViewState.Item("st_gera_ciq") = .Item("st_gera_ciq")
                    ViewState.Item("nm_sigla") = .Item("nm_sigla")
                    ViewState.Item("st_obrigatoria") = .Item("st_obrigatoria")

                End With

                grdAnalises.Visible = True
                grdAnalises.DataSource = Helper.getDataView(dsromaneiocomp.Tables(0), ViewState.Item("sortExpression"))
                grdAnalises.DataBind()
            Else
                grdAnalises.Visible = False
                messageControl.Alert("Há problemas na passagem de parâmetros. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Protected Sub cbo_cd_analise_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_cd_analise.SelectedIndexChanged
        If cbo_cd_analise.SelectedValue > 0 Then
            ViewState.Item("id_analise") = cbo_cd_analise.SelectedValue
            loadAnalise()
            Me.lk_concluirFooter.Focus()
        Else
            ViewState.Item("id_analise") = 0
        End If
    End Sub



    Protected Sub cbo_sigla_analise_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_sigla_analise.SelectedIndexChanged
        If cbo_sigla_analise.SelectedValue > 0 Then
            ViewState.Item("id_analise") = cbo_sigla_analise.SelectedValue
            cbo_cd_analise.SelectedValue = cbo_sigla_analise.SelectedValue
            loadAnalise()
        Else
            ViewState.Item("id_analise") = 0
        End If

    End Sub


    Protected Sub grdAnalises_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdAnalises.RowCancelingEdit
        Try

            grdAnalises.EditIndex = -1
            loadGridAnalise()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdAnalises_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdAnalises.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Edit", "Editar", "Cancel", "Cancelar", "Update"
                Return
        End Select

    End Sub

    Protected Sub grdAnalises_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAnalises.RowCreated

        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Normal) Or (e.Row.RowState = DataControlRowState.Alternate)) Then
            Try
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'CAMPO VALOR
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                Select Case Convert.ToInt32(ViewState.Item("id_formato_analise"))
                    Case 1 'Decimal
                        Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        'Fran 15/06/2009 i chamado 276
                        'If Left(UCase(Me.cbo_sigla_analise.SelectedItem.Text.Trim), 4) = "TEMP" Then
                        If Right(UCase(Me.cbo_cd_analise.SelectedItem.Text.Trim), 11) = "TEMPERATURA" Then
                            'Fran 15/06/2009 f chamado 276
                            txt_dec_nr_valor.MaxMantissa = 1
                        Else
                            txt_dec_nr_valor.MaxMantissa = 4
                        End If

                End Select

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub grdAnalises_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAnalises.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Normal) Or (e.Row.RowState = DataControlRowState.Alternate)) Then
            Try
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'CAMPO VALOR
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'Verifica qual o formato da analise para montar o campo correto
                Dim id_st_original As Label = CType(e.Row.FindControl("lbl_id_st_original"), Label)
                Dim lbl_nr_valor As Label = CType(e.Row.FindControl("lbl_nr_valor"), Label)
                Dim lbl_nm_valor As Label = CType(e.Row.FindControl("lbl_nm_valor"), Label)
                Dim nm_st_analise As Label = CType(e.Row.FindControl("lbl_nm_st_analise"), Label)
                Dim lbl_id_st_analise_compartimento As Label = CType(e.Row.FindControl("lbl_id_st_analise_compartimento"), Label)
                Dim btn_editar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)
                Dim lbl_ds_comentario As Label = CType(e.Row.FindControl("lbl_ds_comentario"), Label)
                Dim txt_ds_comentario As TextBox = CType(e.Row.FindControl("txt_ds_comentario"), TextBox)
                Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim cbo_nr_valor As DropDownList = CType(e.Row.FindControl("cbo_nr_valor"), DropDownList)
                Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                'Se já registrou cpompartimento, não deixa mais fazer edição
                If Not lbl_id_st_analise_compartimento.Text.Equals(String.Empty) Then
                    lbl_nr_valor.Visible = True
                    txt_dec_nr_valor.Visible = False
                    txt_int_nr_valor.Visible = False
                    cbo_nr_valor.Visible = False

                    lbl_nr_valor.ToolTip = "A edição da análise não pode ser realizada para compartimentos já registrados."
                    If Not (lbl_nr_valor.Text.ToString.Equals(String.Empty)) Then
                        Select Case Convert.ToInt32(ViewState.Item("id_formato_analise"))
                            Case 1 'Decimal
                                'fran chamado 464 - 05/10/2009 i
                                'lbl_nr_valor.Text = CStr(CDec(lbl_nr_valor.Text))
                                lbl_nr_valor.Text = CStr(FormatNumber(CDec(lbl_nr_valor.Text), 4))
                                'fran 05/10/2009 f
                                If Right(UCase(Me.cbo_cd_analise.SelectedItem.Text.Trim), 11) = "TEMPERATURA" Then
                                    lbl_nr_valor.Text = CStr(FormatNumber(CDec(lbl_nr_valor.Text), 1))
                                End If
                            Case 2 'Inteiro
                                lbl_nr_valor.Text = CStr(CLng(lbl_nr_valor.Text))
                            Case 3 ' Lógico
                                lbl_nr_valor.Visible = False
                                lbl_nm_valor.Visible = True
                                lbl_nm_valor.ToolTip = "A edição da análise não pode ser realizada para compartimentos já registrados."
                        End Select
                    End If

                    If Me.chk_exibir_comentario.Checked = True Then
                        txt_ds_comentario.Visible = False
                        lbl_ds_comentario.Visible = True
                    End If
                Else 'se nao registrou compartimento

                    Select Case Convert.ToInt32(ViewState.Item("id_formato_analise"))
                        Case 1 'Decimal
                            Dim rfv_txt_dec_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_txt_dec_nr_valor"), RequiredFieldValidator)
                            rfv_txt_dec_nr_valor.Visible = True
                            txt_dec_nr_valor.Visible = True

                            If ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString)) Is Nothing Then
                                If lbl_nr_valor.Text.Trim.Equals(String.Empty) Then
                                    txt_dec_nr_valor.Text = String.Empty
                                Else
                                    'fran chamado 464 - 05/10/2009 i
                                    'txt_dec_nr_valor.Text = CStr(CDec(lbl_nr_valor.Text))
                                    If Right(UCase(Me.cbo_cd_analise.SelectedItem.Text.Trim), 11) = "TEMPERATURA" Then
                                        txt_dec_nr_valor.Text = CStr(FormatNumber(CDec(lbl_nr_valor.Text), 1))
                                    Else
                                        txt_dec_nr_valor.Text = CStr(FormatNumber(CDec(lbl_nr_valor.Text), 4))
                                    End If
                                    'fran 05/10/2009 f

                                End If

                                ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString)) = txt_dec_nr_valor.Text
                            End If
                            If Not (ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString)).ToString.Equals(String.Empty)) Then
                                'fran chamado 464 - 05/10/2009 i
                                'txt_dec_nr_valor.Text = CStr(CDec(ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString))))
                                If Right(UCase(Me.cbo_cd_analise.SelectedItem.Text.Trim), 11) = "TEMPERATURA" Then
                                    txt_dec_nr_valor.Text = CStr(FormatNumber(CDec(ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString))), 1))
                                Else
                                    txt_dec_nr_valor.Text = CStr(FormatNumber(CDec(ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString))), 4))
                                End If
                                'fran 05/10/2009 f
                            Else
                                txt_dec_nr_valor.Text = String.Empty
                            End If

                        Case 2 'Inteiro

                            Dim rfv_txt_int_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_txt_int_nr_valor"), RequiredFieldValidator)
                            txt_int_nr_valor.Visible = True
                            txt_dec_nr_valor.Visible = False
                            rfv_txt_int_nr_valor.Visible = True
                            If ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString)) Is Nothing Then
                                If lbl_nr_valor.Text.Trim.Equals(String.Empty) Then
                                    txt_int_nr_valor.Text = String.Empty
                                Else
                                    txt_int_nr_valor.Text = CStr(CDec(lbl_nr_valor.Text))
                                End If

                                ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString)) = txt_int_nr_valor.Text
                            End If
                            If Not (ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString)).ToString.Equals(String.Empty)) Then
                                txt_int_nr_valor.Text = CStr(CLng(ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString))))
                            Else
                                txt_int_nr_valor.Text = String.Empty
                            End If
                        Case 3 ' Lógico

                            Dim rfv_cbo_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_cbo_nr_valor"), RequiredFieldValidator)
                            rfv_cbo_nr_valor.Visible = True
                            cbo_nr_valor.Visible = True
                            txt_dec_nr_valor.Visible = False
                            Dim analiselogica As New AnaliseLogica
                            analiselogica.id_grupo_descricao = ViewState.Item("id_grupo_descricao_logica") 'Fran 21/08/2009 i rls 18
                            cbo_nr_valor.DataSource = analiselogica.getAnalisesLogicasByFilters
                            cbo_nr_valor.DataTextField = "nm_analise_logica"
                            cbo_nr_valor.DataValueField = "id_analise_logica"
                            cbo_nr_valor.DataBind()

                            If ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString)) Is Nothing Then
                                cbo_nr_valor.SelectedValue = ViewState.Item("id_faixa_referencia_logica")
                                ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString)) = cbo_nr_valor.SelectedValue
                            End If

                            If Not (ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString)).ToString.Equals(String.Empty)) Then
                                cbo_nr_valor.SelectedValue = CInt(ViewState.Item(String.Concat("txt_nr_valor", e.Row.RowIndex.ToString)))
                            Else
                                cbo_nr_valor.SelectedValue = ViewState.Item("id_faixa_referencia_logica")
                            End If
                    End Select
                    lbl_nr_valor.Visible = False
                    lbl_nm_valor.Visible = False

                    If Me.chk_exibir_comentario.Checked = True Then
                        txt_ds_comentario.Visible = True
                        lbl_ds_comentario.Visible = False
                        If ViewState.Item(String.Concat("txt_ds_comentario", e.Row.RowIndex.ToString)) Is Nothing Then
                            txt_ds_comentario.Text = lbl_ds_comentario.Text
                            ViewState.Item(String.Concat("txt_ds_comentario", e.Row.RowIndex.ToString)) = txt_ds_comentario.Text
                        End If

                        If Not (ViewState.Item(String.Concat("txt_ds_comentario", e.Row.RowIndex.ToString)).ToString.Equals(String.Empty)) Then
                            txt_ds_comentario.Text = (ViewState.Item(String.Concat("txt_ds_comentario", e.Row.RowIndex.ToString))).ToString
                        Else
                            txt_ds_comentario.Text = String.Empty
                        End If
                    End If

                End If

                If Not nm_st_analise Is Nothing Then
                    If ViewState.Item("st_gera_ciq") = "N" Then
                        If Not id_st_original.Text.Equals(String.Empty) Then
                            If id_st_original.Text = "2" Then
                                nm_st_analise.Text = "Rejeitado*"
                            End If
                        End If
                    Else
                        If nm_st_analise.Text = "Rejeitado" Then
                            ViewState.Item("rejeitado") = "S"
                        End If
                    End If
                End If
                'grdAnalises.Focus()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If



    End Sub

    Protected Sub grdAnalises_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdAnalises.RowEditing
        Try

            Dim lbl_nr_valor As Label = CType(grdAnalises.Rows(e.NewEditIndex).FindControl("lbl_nr_valor"), Label)
            ViewState.Item("lbl_nr_valor") = Trim(lbl_nr_valor.Text)
            grdAnalises.EditIndex = e.NewEditIndex
            loadGridAnalise()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdAnalises_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdAnalises.RowUpdating
        'Capturar valores
        Dim row As GridViewRow = grdAnalises.Rows(e.RowIndex)
        Try
            Dim romaneio As New Romaneio(ViewState.Item("id_romaneio"))
            If romaneio.id_st_romaneio < 3 Then
                romaneio.id_st_romaneio = 3
                romaneio.id_modificador = Session("id_login")
                romaneio.updateRomaneioSituacao()
            End If

            If (Not (row) Is Nothing) Then

                Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento
                Dim txt_ds_comentario As TextBox = CType(row.FindControl("txt_ds_comentario"), TextBox)
                Dim lbl_id_romaneio_compartimento As Label = CType(row.FindControl("lbl_id_romaneio_compartimento"), Label)
                'Dim lviewstaterejeitado As String = ViewState.Item("rejeitado").ToString

                romaneioanalisecompartimento.id_analise_compartimento = Convert.ToInt32(grdAnalises.DataKeys.Item(e.RowIndex).Value)
                romaneioanalisecompartimento.ds_comentario = txt_ds_comentario.Text.ToString
                romaneioanalisecompartimento.id_modificador = Session("id_login")

                Select Case Convert.ToInt32(ViewState.Item("id_formato_analise"))
                    Case 1 'Descimal
                        Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        If Not (txt_dec_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                            romaneioanalisecompartimento.nr_valor = Convert.ToDecimal(txt_dec_nr_valor.Text.Trim.ToString)
                            If romaneioanalisecompartimento.nr_valor >= CDec(ViewState.Item("nr_faixa_inicial")) And romaneioanalisecompartimento.nr_valor <= CDec(ViewState.Item("nr_faixa_final")) Then
                                romaneioanalisecompartimento.id_st_analise = 1 'Aprovado
                            Else
                                romaneioanalisecompartimento.id_st_analise = 2 'Reprovado
                                'ViewState.Item("rejeitado") = "S"
                            End If
                        End If

                    Case 2 'Inteiro
                        Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                        If Not (txt_int_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                            romaneioanalisecompartimento.nr_valor = Convert.ToDecimal(Convert.ToInt32(txt_int_nr_valor.Text))
                            If CLng(romaneioanalisecompartimento.nr_valor) >= CLng(ViewState.Item("nr_faixa_inicial")) And romaneioanalisecompartimento.nr_valor <= CLng(ViewState.Item("nr_faixa_final")) Then
                                romaneioanalisecompartimento.id_st_analise = 1 'Aprovado
                            Else
                                romaneioanalisecompartimento.id_st_analise = 2 'Reprovado
                                'ViewState.Item("rejeitado") = "S"
                            End If
                        End If

                    Case 3 'Logico
                        Dim cbo_nr_valor As DropDownList = CType(row.FindControl("cbo_nr_valor"), DropDownList)
                        If Not (cbo_nr_valor.SelectedValue.Trim().Equals(String.Empty)) Then
                            romaneioanalisecompartimento.nr_valor = Convert.ToDecimal(Convert.ToInt32(cbo_nr_valor.SelectedValue))
                            If CLng(romaneioanalisecompartimento.nr_valor) = CLng(ViewState.Item("id_faixa_referencia_logica")) Then
                                romaneioanalisecompartimento.id_st_analise = 1 'Aprovado
                            Else
                                romaneioanalisecompartimento.id_st_analise = 2 'Reprovado
                                'ViewState.Item("rejeitado") = "S"
                            End If

                        End If

                End Select
                If ViewState.Item("st_gera_ciq") = "N" Then
                    If romaneioanalisecompartimento.id_st_analise = 2 Then 'Rejeitado
                        romaneioanalisecompartimento.id_st_original = 2
                        romaneioanalisecompartimento.id_st_analise = 1
                        'volta o status do incio da rotina
                        'ViewState.Item("rejeitado") = lviewstaterejeitado
                    Else
                        romaneioanalisecompartimento.id_st_original = 0
                        romaneioanalisecompartimento.id_st_analise = 1
                    End If

                End If

                'romaneioanaliseglobal.id_st_analise = Convert.ToInt32(txt_id_st_alnalise.Text.ToString)
                romaneioanalisecompartimento.updateRomaneioAnaliseCompartimento()
                'se tem analises rejeitadas para o compartimento
                atualizarCboRegistroAnalise(Convert.ToInt32(ViewState.Item("id_romaneio")), Convert.ToInt32(lbl_id_romaneio_compartimento.Text))
                grdAnalises.EditIndex = -1
                loadGridAnalise()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub loadGridAnalise()

        Try
            Dim analisecomp As New RomaneioAnaliseCompartimento

            analisecomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            analisecomp.id_analise = Convert.ToInt32(ViewState.Item("id_analise"))

            Dim dsromaneiocomp As DataSet = analisecomp.getRomaneioAnalisesCompartimentosByFilters

            'Se ha linhas na romaneio compartimento
            If (dsromaneiocomp.Tables(0).Rows.Count > 0) Then
                grdAnalises.DataSource = Helper.getDataView(dsromaneiocomp.Tables(0), ViewState.Item("sortExpression"))
                grdAnalises.DataBind()
            Else
                grdAnalises.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub atualizarCboRegistroAnalise(Optional ByVal id_romaneio As Int32 = 0, Optional ByVal id_romaneio_compartimento As Int32 = 0)
        Try
            Dim romaneioanalisecomp As New RomaneioAnaliseCompartimento

            'se tem analises rejeitadas para o compartimento
            romaneioanalisecomp.id_romaneio = id_romaneio
            romaneioanalisecomp.id_romaneio_compartimento = id_romaneio_compartimento

            If romaneioanalisecomp.getRomaneioAnaliseCompartimentoRejeitada() > 0 Then
                'Percorre o grid de compartimento e encontra a linha do romaneio_compartimento para a analise em alteração
                Dim lrow As GridViewRow
                For Each lrow In grdCompartimentos.Rows
                    If CLng(grdCompartimentos.DataKeys.Item(lrow.RowIndex).Value) = romaneioanalisecomp.id_romaneio_compartimento Then
                        Dim cbo_registrar_id_st_analise As Anthem.DropDownList = CType(lrow.FindControl("cbo_registrar_id_st_analise"), Anthem.DropDownList)
                        Dim txt_ds_motivo_aprovado_sob_concessao As Anthem.TextBox = CType(lrow.FindControl("txt_ds_motivo_aprovado_sob_concessao"), Anthem.TextBox)
                        Dim lbl_labelmotivo As Anthem.Label = CType(lrow.FindControl("lbl_labelmotivo"), Anthem.Label)

                        cbo_registrar_id_st_analise.SelectedValue = 3
                        txt_ds_motivo_aprovado_sob_concessao.Visible = False
                        lbl_labelmotivo.Visible = False
                        Exit For
                    End If
                Next
            Else
                'Percorre o grid de compartimento e encontra a linha do romaneio_compartimento para a analise em alteração
                Dim lrow As GridViewRow
                For Each lrow In grdCompartimentos.Rows
                    If CLng(grdCompartimentos.DataKeys.Item(lrow.RowIndex).Value) = romaneioanalisecomp.id_romaneio_compartimento Then
                        Dim cbo_registrar_id_st_analise As Anthem.DropDownList = CType(lrow.FindControl("cbo_registrar_id_st_analise"), Anthem.DropDownList)
                        Dim txt_ds_motivo_aprovado_sob_concessao As Anthem.TextBox = CType(lrow.FindControl("txt_ds_motivo_aprovado_sob_concessao"), Anthem.TextBox)
                        Dim lbl_labelmotivo As Anthem.Label = CType(lrow.FindControl("lbl_labelmotivo"), Anthem.Label)
                        cbo_registrar_id_st_analise.SelectedValue = 1
                        txt_ds_motivo_aprovado_sob_concessao.Visible = False
                        lbl_labelmotivo.Visible = False
                        Exit For
                    End If
                Next
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub registrarAnaliseCompartimento(ByVal indexrow As Int32)
        If Page.IsValid Then

            Try
                Dim cbo_registrar_id_st_analise As DropDownList = CType(grdCompartimentos.Rows.Item(indexrow).FindControl("cbo_registrar_id_st_analise"), DropDownList)
                Dim id_romaneio_compartimento As Int32 = Convert.ToInt32(grdCompartimentos.DataKeys(indexrow).Value)

                If CInt(cbo_registrar_id_st_analise.SelectedValue) = 3 Then
                    RegistrarAnaliseCompartimentoRejeitada(id_romaneio_compartimento)
                Else
                    RegistrarAnaliseCompartimentoAprovada(CInt(cbo_registrar_id_st_analise.SelectedValue), id_romaneio_compartimento)
                End If
                'loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
    Private Function consistirRegistroAnalise(ByVal indexrow As Int32) As Boolean
        If Page.IsValid Then

            Try
                Dim cbo_registrar_id_st_analise As DropDownList = CType(grdCompartimentos.Rows.Item(indexrow).FindControl("cbo_registrar_id_st_analise"), DropDownList)
                Dim id_romaneio_compartimento As Int32 = Convert.ToInt32(grdCompartimentos.DataKeys(indexrow).Value)
                Dim txt_ds_motivo_aprovado_sob_concessao As Anthem.TextBox = CType(grdCompartimentos.Rows.Item(indexrow).FindControl("txt_ds_motivo_aprovado_sob_concessao"), Anthem.TextBox)
                Dim txtplaca As DataControlFieldCell = CType(grdCompartimentos.Rows.Item(indexrow).Cells.Item(0), DataControlFieldCell)
                Dim txtcompartimento As System.Web.UI.WebControls.HyperLink = CType(grdCompartimentos.Rows(indexrow).Cells(1).Controls(0), System.Web.UI.WebControls.HyperLink)

                Dim bIsValid As Boolean

                bIsValid = True
                consistirRegistroAnalise = True
                'Consistir analista
                If Me.txt_nm_analista.Text.Trim.Equals(String.Empty) Then
                    bIsValid = False
                End If
                If Me.txt_dt_analise.Text.Trim.Equals(String.Empty) Then
                    bIsValid = False
                End If
                If Me.txt_hr_analise.Text.Trim.Equals(String.Empty) Then
                    bIsValid = False
                End If
                If Me.txt_mm_analise.Text.Trim.Equals(String.Empty) Then
                    bIsValid = False
                End If
                If bIsValid = False Then
                    consistirRegistroAnalise = False
                    messageControl.Alert("Para registrar o resultado das análises de compartimento, o nome do analista e a data de início da análise devem ser informados.")
                    Exit Try
                End If

                'Consistir anslises obrigatorias
                Dim analisecomp As New RomaneioAnaliseCompartimento
                analisecomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                analisecomp.id_romaneio_compartimento = id_romaneio_compartimento
                'Busaca as analise obrigatorias, reanalise <> S e statuscompartimento vazio
                If analisecomp.getRomaneioAnaliseCompartimentoSemResultado() > 0 Then
                    bIsValid = False
                End If

                If bIsValid = False Then
                    consistirRegistroAnalise = False
                    messageControl.Alert("Para registrar o resultado das análises da placa " & txtplaca.Text & " e compartimento " & txtcompartimento.Text & ", todas as análises obrigatórias devem ser informadas.")
                    Exit Try
                End If

                'Consistir cbo registrat
                Dim liresult As Int32
                Dim lsvaluecbo As Integer
                Dim lmsg As String

                If Not cbo_registrar_id_st_analise.SelectedValue.Equals(String.Empty) Then
                    lsvaluecbo = CInt(cbo_registrar_id_st_analise.SelectedValue)
                    'Se tem alguma analise rejeitada, o cbo não pode ser registro de aprovada
                    liresult = analisecomp.getRomaneioAnaliseCompartimentoRejeitada()

                    'Se tem rejeitadas....
                    If liresult > 0 Then
                        If lsvaluecbo = 1 Then
                            bIsValid = False
                            lmsg = "Você não pode registrar a análise da placa " & txtplaca.Text & " e compartimento " & txtcompartimento.Text & " como 'APROVADA' porque há análises com situação 'REJEITADA'"
                        End If
                    Else 'se não tem rejeitadas
                        If lsvaluecbo <> 1 Then
                            bIsValid = False
                            lmsg = "A análise da placa " & txtplaca.Text & " e compartimento " & txtcompartimento.Text & " só pode ser registrada como 'APROVADA' pois não há registro de análises com situação 'REJEITADA'"
                        End If
                    End If
                    If bIsValid = False Then
                        consistirRegistroAnalise = False
                        messageControl.Alert(lmsg)
                        Exit Try
                    End If
                End If
                'Consistir aprovado sob concessao
                If txt_ds_motivo_aprovado_sob_concessao.Visible = True Then
                    If txt_ds_motivo_aprovado_sob_concessao.Text.Trim.Equals(String.Empty) Then
                        bIsValid = False
                        consistirRegistroAnalise = False
                        messageControl.Alert("A justificativa da Aprovação Sob Concessão da placa " & txtplaca.Text & " e compartimento " & txtcompartimento.Text & " deve ser preenchida.")
                    End If
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If


    End Function
    Private Sub RegistrarAnaliseCompartimentoRejeitada(ByVal id_romaneio_compartimento As Int32)
        If Page.IsValid = True Then

            Try

                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                romaneio.id_st_analise_compartimento = 2 'Rejeitada 
                romaneio.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento = New Romaneio_Compartimento(id_romaneio_compartimento)
                'romaneio.romaneio_compartimento.id_st_analise = id_st_analise_compartimento 'Rejeitada ou Aprovada sob concessao
                romaneio.romaneio_compartimento.id_st_analise = 3 'Rejeitada 
                romaneio.romaneio_compartimento.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento.dt_inicio_analise = txt_dt_analise.Text & " " & txt_hr_analise.Text & ":" & txt_mm_analise.Text & ":00"
                romaneio.romaneio_compartimento.nm_analista = txt_nm_analista.Text.ToString

                romaneio.registrarAnaliseCompartimentoRejeitada()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
    Private Sub RegistrarAnaliseCompartimentoAprovada(ByVal id_st_analise_compartimento As Int32, ByVal id_romaneio_compartimento As Int32)
        If Page.IsValid = True Then

            Try
                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))
                'Dim id_st_analise_compartimento As Int32 = CInt(Me.cbo_registro_analise.SelectedValue)
                romaneio.id_st_analise_compartimento = 1 'Aprovada 
                romaneio.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento = New Romaneio_Compartimento(id_romaneio_compartimento)
                'romaneio.romaneio_compartimento.id_st_analise = 1 'Aprovada
                romaneio.romaneio_compartimento.id_st_analise = id_st_analise_compartimento 'Aprovada ou Aprovada sob concessao
                romaneio.romaneio_compartimento.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento.dt_inicio_analise = txt_dt_analise.Text & " " & txt_hr_analise.Text & ":" & txt_mm_analise.Text & ":00"
                romaneio.romaneio_compartimento.nm_analista = txt_nm_analista.Text.ToString
                'If id_st_analise_compartimento = 2 Then 'aprovado sob concessao
                'romaneio.romaneio_compartimento.ds_motivo_aprovado_sob_concessao = txt_ds_motivo_aprovado_sob_concessao.Text.ToString
                'End If
                romaneio.registrarAnaliseCompartimentoAprovada()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If


    End Sub


    Protected Sub cbo_registrar_id_st_analise_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim cbo_registrar_id_st_analise As Anthem.DropDownList = CType(row.FindControl("cbo_registrar_id_st_analise"), Anthem.DropDownList)
        Dim lbl_labelmotivo As Anthem.Label = CType(row.FindControl("lbl_labelmotivo"), Anthem.Label)
        Dim txt_ds_motivo_aprovado_sob_concessao As Anthem.TextBox = CType(row.FindControl("txt_ds_motivo_aprovado_sob_concessao"), Anthem.TextBox)
        'Dim rfv_motivo As Anthem.RequiredFieldValidator = CType(row.FindControl("rfv_motivo"), Anthem.RequiredFieldValidator)
        If cbo_registrar_id_st_analise.SelectedValue = 2 Then
            lbl_labelmotivo.Visible = True
            txt_ds_motivo_aprovado_sob_concessao.Visible = True
            'rfv_motivo.Visible = True
        Else
            lbl_labelmotivo.Visible = False
            txt_ds_motivo_aprovado_sob_concessao.Visible = False
            'rfv_motivo.Visible = False
        End If

    End Sub

    Protected Sub cv_st_analises_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim wc As WebControl = CType(source, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim analisecomp As New RomaneioAnaliseCompartimento
        analisecomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
        analisecomp.id_romaneio_compartimento = Convert.ToInt32(grdCompartimentos.DataKeys(row.RowIndex).Value)
        'Busaca as analise obrigatorias, reanalise <> S e statuscompartimento vazio
        If analisecomp.getRomaneioAnaliseCompartimentoSemResultado() > 0 Then
            args.IsValid = False
        Else
            args.IsValid = True
        End If

        If args.IsValid = False Then
            messageControl.Alert("Para registrar o resultado desta análise de compartimento, todas as análises obrigatórias devem ser informadas.")
        End If

    End Sub

    Protected Sub cv_verificarrejeitadas_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim wc As WebControl = CType(source, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim cbo_registrar_id_st_analise As Anthem.DropDownList = CType(row.FindControl("cbo_registrar_id_st_analise"), Anthem.DropDownList)

        Dim analisecomp As New RomaneioAnaliseCompartimento
        Dim liresult As Int32
        Dim lsvaluecbo As Integer
        Dim lmsg As String

        args.IsValid = True
        If Not cbo_registrar_id_st_analise.SelectedValue.Equals(String.Empty) Then
            lsvaluecbo = CInt(cbo_registrar_id_st_analise.SelectedValue)
            analisecomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            analisecomp.id_romaneio_compartimento = Convert.ToInt32(grdCompartimentos.DataKeys(row.RowIndex).Value)
            'Se tem alguma analise rejeitada, o cbo não pode ser registro de aprovada
            liresult = analisecomp.getRomaneioAnaliseCompartimentoRejeitada()

            'Se tem rejeitadas....
            If liresult > 0 Then
                If lsvaluecbo = 1 Then
                    args.IsValid = False
                    lmsg = "Você não pode registrar a análise do compartimento como 'APROVADA' porque há análises com situação 'REJEITADA'"
                End If
            Else 'se não tem rejeitadas
                If lsvaluecbo <> 1 Then
                    args.IsValid = False
                    lmsg = "A análise deste compartimento só pode ser registrada como 'APROVADA' pois não há registro de análises com situação 'REJEITADA'"
                End If
            End If
            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        End If

    End Sub

    Protected Sub cv_analista_dt_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim wc As WebControl = CType(source, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        'Dim rc As New Romaneio_Compartimento(Convert.ToInt32(grdCompartimentos.DataKeys(row.RowIndex).Value))
        'args.IsValid = True
        'If rc.nm_analista Is Nothing Then
        '    args.IsValid = False
        'Else
        '    If rc.nm_analista.ToString.Equals(String.Empty) Then
        '        args.IsValid = False
        '    End If
        'End If

        'If rc.dt_inicio_analise Is Nothing Then
        '    args.IsValid = False
        'Else
        '    If rc.dt_inicio_analise.ToString.Equals(String.Empty) Then
        '        args.IsValid = False
        '    End If
        'End If

        'If args.IsValid = False Then
        '    messageControl.Alert("Para registrar o resultado desta análise de compartimento, o nome do analista e a data de início da análise devem ser salvos.")
        'End If
        args.IsValid = True
        If Me.txt_nm_analista.Text.Trim.Equals(String.Empty) Then
            args.IsValid = False
        End If

        If Me.txt_dt_analise.Text.Trim.Equals(String.Empty) Then
            args.IsValid = False
        End If

        If Me.txt_hr_analise.Text.Trim.Equals(String.Empty) Then
            args.IsValid = False
        End If
        If Me.txt_mm_analise.Text.Trim.Equals(String.Empty) Then
            args.IsValid = False
        End If

        If args.IsValid = False Then
            messageControl.Alert("Para registrar o resultado desta análise de compartimento, o nome do analista e a data de início da análise devem ser informados.")
        End If

    End Sub

    Protected Sub btn_registrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_registrar.Click

        Dim row As GridViewRow
        Dim bErros = True
        Try
            If Page.IsValid Then

                For Each row In grdCompartimentos.Rows
                    Dim lbl_id_st_analise As Label = CType(row.FindControl("lbl_id_st_analise"), Label)
                    Dim txtplaca As DataControlFieldCell = CType(row.Cells.Item(1), DataControlFieldCell)
                    Dim txtcompartimento As DataControlFieldCell = CType(row.Cells.Item(2), DataControlFieldCell)

                    'se nao registrou
                    If lbl_id_st_analise.Text.Equals(String.Empty) Then
                        If consistirRegistroAnalise(row.RowIndex) = True Then
                            bErros = False
                        Else
                            bErros = True
                        End If
                    End If
                Next

                If bErros = False Then
                    For Each row In grdCompartimentos.Rows
                        Dim lbl_id_st_analise As Label = CType(row.FindControl("lbl_id_st_analise"), Label)
                        'se nao registrou
                        If lbl_id_st_analise.Text.Equals(String.Empty) Then
                            registrarAnaliseCompartimento(row.RowIndex)
                        End If
                    Next
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'processo
                    usuariolog.id_menu_item = 165
                    usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    messageControl.Alert("O registro das análises dos compartimentos do romaneio " & lbl_id_romaneio.Text & " foram registradas com sucesso!")
                End If

                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub txt_nm_analista_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nm_analista.TextChanged

    End Sub


    Protected Sub chk_exibir_comentario_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_exibir_comentario.CheckedChanged
        If chk_exibir_comentario.Checked = True Then
            guardarDadosAnalise()
            grdAnalises.Columns(3).Visible = True
            loadGridAnalise()
        Else
            guardarDadosAnalise()
            grdAnalises.Columns(3).Visible = False
            loadGridAnalise()
        End If
    End Sub

    Private Sub guardarDadosAnalise()

        Try
            'fran 16/06/2009 i
            Dim i As Int32 = 0
            For i = 0 To grdAnalises.Rows.Count - 1

                Select Case Convert.ToInt32(ViewState.Item("id_formato_analise"))
                    Case 1 'Decimal
                        Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(grdAnalises.Rows(i).FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_ds_comentario As TextBox = CType(grdAnalises.Rows(i).FindControl("txt_ds_comentario"), TextBox)

                        ViewState.Item(String.Concat("txt_nr_valor", i.ToString)) = txt_dec_nr_valor.Text
                        If grdAnalises.Columns(3).Visible = True Then
                            ViewState.Item(String.Concat("txt_ds_comentario", i.ToString)) = txt_ds_comentario.Text
                        End If
                    Case 2 'Inteiro
                        Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(grdAnalises.Rows(i).FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                        Dim txt_ds_comentario As TextBox = CType(grdAnalises.Rows(i).FindControl("txt_ds_comentario"), TextBox)

                        ViewState.Item(String.Concat("txt_nr_valor", i.ToString)) = txt_int_nr_valor.Text
                        If grdAnalises.Columns(3).Visible = True Then
                            ViewState.Item(String.Concat("txt_ds_comentario", i.ToString)) = txt_ds_comentario.Text
                        End If
                    Case 3 ' Lógico
                        Dim cbo_nr_valor As DropDownList = CType(grdAnalises.Rows(i).FindControl("cbo_nr_valor"), DropDownList)
                        Dim txt_ds_comentario As TextBox = CType(grdAnalises.Rows(i).FindControl("txt_ds_comentario"), TextBox)

                        ViewState.Item(String.Concat("txt_nr_valor", i.ToString)) = cbo_nr_valor.SelectedValue
                        If grdAnalises.Columns(3).Visible = True Then
                            ViewState.Item(String.Concat("txt_ds_comentario", i.ToString)) = txt_ds_comentario.Text
                        End If
                End Select

            Next
            'fran 16/06/2009 f



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cbo_cd_analise_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_cd_analise.TextChanged
        Me.lk_concluirFooter.Focus()
    End Sub
    Private Sub navegacaoGrdAnalise()

        Try
            'fran 16/06/2009 i chamado 276

            Dim row As GridViewRow
            Dim lbtodoscompregistrados As Boolean = True
            For Each row In grdCompartimentos.Rows
                Dim lbl_st_registro As Label = CType(grdCompartimentos.Rows(row.RowIndex).FindControl("lbl_st_registro"), Label)
                If lbl_st_registro.Visible = False Then
                    lbtodoscompregistrados = False
                End If
            Next

            If lbtodoscompregistrados = False Then


                Dim romanalcomp As New Romaneio

                romanalcomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

                Dim dsanalisenavegacao As DataSet = romanalcomp.getRomaneioAnalisesNullNavegacao

                'Se ha linhas na navegação
                If (dsanalisenavegacao.Tables(0).Rows.Count > 0) Then

                    ViewState.Item("id_analise") = dsanalisenavegacao.Tables(0).Rows(0).Item("id_analise")
                Else
                    'Se o combo esta posicionado no ultimo item
                    If cbo_cd_analise.SelectedIndex = cbo_cd_analise.Items.Count - 1 Then
                        ViewState.Item("id_analise") = cbo_cd_analise.Items(1).Value
                    Else
                        ViewState.Item("id_analise") = cbo_cd_analise.Items(cbo_cd_analise.SelectedIndex + 1).Value
                    End If
                End If
            Else
                'Se todos os compartimentos estão registrados, visualiza analise pela ordem do combo pois não pode mais alterar
                If cbo_cd_analise.SelectedIndex = cbo_cd_analise.Items.Count - 1 Then
                    ViewState.Item("id_analise") = cbo_cd_analise.Items(1).Value
                Else
                    ViewState.Item("id_analise") = cbo_cd_analise.Items(cbo_cd_analise.SelectedIndex + 1).Value
                End If

            End If

            'fran 16/06/2009 f

            cbo_cd_analise.SelectedValue = ViewState.Item("id_analise")
            'carrega análise
            loadAnalise()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_liberar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_liberar.Click
        liberarPreRomaneio()
    End Sub
    Private Sub liberarPreRomaneio()
        If Page.IsValid Then
            Try

                Dim romaneio As New Romaneio
                romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                Dim dsromaneio As DataSet = romaneio.getPreRomaneioTransitPointByFilters
                Dim romaneiocomp As New Romaneio_Compartimento
                Dim nr_comp_aprovado As Integer = 0
                Dim nr_comp_rejeitado As Integer = 0
                Dim id_romaneio_rejeitado As Int64 = 0

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 165
                usuariolog.ds_nm_processo = "Registrar Análises - Liberar Pré-Romaneio"
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                'Se ha linhas na romaneio 
                If (dsromaneio.Tables(0).Rows.Count > 0) Then
                    With dsromaneio.Tables(0).Rows(0)
                        If .Item("id_st_romaneio") = 8 Then 'se esta em analise
                            romaneio.id_modificador = Session("id_login")
                            'faz a consistencia do fechar romaneio para poder prosseguir 
                            If romaneio.FecharRomaneioConsistir = True Then
                                'buscar a qyde de compartimento do pre romaneio aprovados e rejeitados
                                romaneiocomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                                nr_comp_aprovado = romaneiocomp.getPreRomaneioCompQtdeAprovado
                                nr_comp_rejeitado = romaneiocomp.getPreRomaneioCompQtdeRejeitado
                                
                                'se nenhum compartimento foi registrado
                                If nr_comp_aprovado = 0 And nr_comp_rejeitado = 0 Then
                                    messageControl.Alert("Este pré-romaneio deve ter seus compartimentos registrados antes de inicializar a Liberação para Transit Point.")
                                End If
                                'se nenhm compartimento foi aprovado e apenas compartimento rejeitados
                                If nr_comp_aprovado = 0 And nr_comp_rejeitado > 0 Then
                                    romaneio.id_pre_romaneio_transit_point = romaneio.id_romaneio
                                    romaneio.id_romaneio = 0
                                    romaneio.id_estabelecimento = ViewState.Item("id_estabelecimento")
                                    'Abre e fecha automaticamente o romaneio do Pre Remaneio rejeitado
                                    id_romaneio_rejeitado = romaneio.abrirRomaneioPreRomaneioRejeitado()

                                    'se caminhao todo rejeitado, atualiza pre-romaneio para indisponivel
                                    romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio")) 'assume o id romaneio como pre romaneio
                                    romaneio.id_st_romaneio = 10 'Pré-Romaneio TP Indisponível'
                                    romaneio.updateRomaneioSituacao()

                                    'fran 02/2021 insere as amostras do pre romaneios se tiver
                                    romaneio.st_leite_total_rejeitado = "S"
                                    romaneio.insertPreRomaneioTransitPointAmostra()
                                End If
                                'se ha compartimentos aprovados
                                If nr_comp_aprovado > 0 Then

                                    'se tambem há compartimentos rejeitados, abre o romaneio para os compartimentos rejeitados
                                    If nr_comp_rejeitado > 0 Then
                                        romaneio.id_pre_romaneio_transit_point = romaneio.id_romaneio
                                        romaneio.id_romaneio = 0
                                        romaneio.id_estabelecimento = ViewState.Item("id_estabelecimento")
                                        'Abre e fecha automaticamente o romaneio do Pre Remaneio rejeitado, disponibizando caminhao para participar calculo e frete
                                        id_romaneio_rejeitado = romaneio.abrirRomaneioPreRomaneioRejeitado()
                                    End If

                                    'Atualiza status do pre romaneio para DISPONIVEL e soma os litros de compartimentos aprovados para disponibilizar a soma para transit point
                                    romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio")) 'assume o id romaneio como pre romaneio
                                    romaneio.updatePreRomaneioDisponivel()

                                    'fran 02/2021 insere as amostras do pre romaneios se tiver
                                    romaneio.st_leite_total_rejeitado = "N"
                                    romaneio.insertPreRomaneioTransitPointAmostra()

                                End If
                                messageControl.Alert("Este pré-romaneio já está disponível para o processo de Transit Point.")

                            End If

                        Else
                            If .Item("id_st_romaneio") = 7 Then 'se for aberto
                                messageControl.Alert("As análises do pré-romaneio devem ser informadas e registradas.")
                            Else
                                messageControl.Alert("Este pré-romaneio já está liberado.")
                            End If
                        End If
                    End With
                End If
                'Se houve criação de 
                If id_romaneio_rejeitado > 0 Then
                    Dim lmsg As String
                    lmsg = "Caso existam compartimentos aprovados, eles já estão disponíveis para o uso no processo de Transit Point. Para os compartimentos rejeitados, foi aberto um Romaneio com sucesso! O número que é a identificação necessária para acompanhamento deste processo é " & id_romaneio_rejeitado.ToString & "."
                    Response.Redirect("frm_mensagem.aspx?msg=" + lmsg + "&tela=lst_pre_romaneio_analise_selecao.aspx=")

                End If

                loadData()


            Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        End If
    End Sub

End Class
