Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_romaneio_analise_comp_veiculo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneios_analise_selecao.aspx")
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

                'Fran 15/06/2009 i chamado 276
                'cbo_sigla_analise.DataSource = cbo_cd_analise.DataSource
                'cbo_sigla_analise.DataTextField = "ds_sigla_analise"
                'cbo_sigla_analise.DataValueField = "id_analise"
                'cbo_sigla_analise.DataBind()
                'cbo_sigla_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                'fran 15/06/2009 f
                grdAnalises.Visible = False
                loadData()
            Else
                messageControl.Alert("H� problemas na passagem de par�metros. A tela n�o pode ser montada!")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            ViewState.Item("confirmarsalvar") = False
            lbl_analise_fora.Visible = False
            Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

            Dim lnr_tempo_rota As Decimal
            lbl_reanalise.Text = "N�o Realizada"
            If romaneio.st_reanalise = "S" Then
                btn_reanalise.Enabled = False
                btn_reanalise.ToolTip = "Fun��o desabilitada para este Romaneio. Re-An�lise j� foi gerada."
                lbl_reanalise.Text = "Realizada"
            End If
            If romaneio.id_cooperativa > 0 Then
                lbl_romaneio.Text = "Cooperativa"
                grdCompartimentos.Columns(6).Visible = False
            End If
            ViewState.Item("id_cooperativa") = romaneio.id_cooperativa

            If romaneio.nr_caderneta > 0 Then
                lbl_romaneio.Text = "Coletas Produtores"
            End If
            If romaneio.st_romaneio_transbordo = "S" Then
                lbl_romaneio.Text = "Transbordo"
            End If

            Me.lbl_id_romaneio.Text = romaneio.id_romaneio.ToString
            Me.lbl_nm_linha.Text = romaneio.nm_linha     ' 21/01/2009 - Rls15
            Me.lbl_nm_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            'Fran 23/11/2009 i Maracanau chamado 519
            Me.lbl_estabelecimento.Text = romaneio.ds_estabelecimento
            Me.lbl_nm_item.Text = romaneio.nm_item
            ViewState.Item("id_estabelecimento") = romaneio.id_estabelecimento
            'Fran 23/11/2009 f

            'FRan 03/12/2018 i 
            If Not romaneio.id_cooperativa > 0 Then
                tr_temporota.Visible = True

                Dim dstemporota As DataSet = romaneio.getRomaneioTempoRotabyRomaneio
                If dstemporota.Tables(0).Rows.Count > 0 Then
                    lnr_tempo_rota = dstemporota.Tables(0).Rows(0).Item("ds_tempo_rota_minutos")

                    Select Case lnr_tempo_rota

                        Case Is <= 720 ' At� 12 horas (720 minutos)

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
                Else 'se nao encontrou, tempo rota esta com valor negativo, ou sej adata coleta � maior que data entrada romaneio
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
                    'fran 16/06/2009 i chamado 276
                    txt_hr_analise.Enabled = False
                    txt_mm_analise.Enabled = False
                    txt_dt_analise.Enabled = False
                    'fran 16/06/2009 f
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
                    messageControl.Alert("H� problemas na passagem de par�metros. Por favor tente novamente.")
                End If
            End If

            cbo_cd_analise.Focus()      ' 21/01/2009 - Rls15
            'fran 16/06/2009 i
            navegacaoGrdAnalise()
            'fran 16/06/2009 f

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        'Response.Redirect("frm_usuario.aspx?id_usuario=" + ViewState.Item("id_usuario").ToString)
        Response.Redirect("lst_romaneios_analise_selecao.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneios_analise_selecao.aspx")

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
                usuariolog.id_tipo_log = 3 'altera��o
                usuariolog.id_menu_item = 22
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                'fran 16/06/2009 i chamado 276
                'atualiza romaneio para em analise
                Dim romaneio As New Romaneio(ViewState.Item("id_romaneio"))
                If romaneio.id_st_romaneio < 3 Then
                    romaneio.id_st_romaneio = 3
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
                        'loadGridAnalise()
                    End If
                Next
                loadData()
                'Fran 17/06/2009 i
                'messageControl.Alert("Registro alterado com sucesso!")
                'Fran 17/06/2009 f
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
                        Dim lAssunto As String = "RELAT�RIO CIQ " & e.CommandArgument.ToString
                        Dim lCorpo As String = "Existe uma ocorr�ncia relatada atrav�s do Relat�rio CIQ, que pode ser visualizado pelo link " & ViewState.Item("caminho_servidor") & "/frm_relatorio_CIQ.aspx?id_romaneio_compartimento=" & e.CommandArgument.ToString & " ."

                        'fran 25/11/2009 i Maracanau - chamado 518
                        'If notificacao.enviaMensagemEmail(1, lAssunto, lCorpo, MailPriority.High) = True Then
                        If notificacao.enviaMensagemEmail(1, lAssunto, lCorpo, MailPriority.High, , , Convert.ToInt32(ViewState.Item("id_estabelecimento"))) = True Then
                            'fran 25/11/2009 f Maracanau - chamado 518
                            messageControl.Alert("O Relat�rio CIQ foi enviado aos destinat�rios cadastrados com sucesso!")
                        Else
                            messageControl.Alert("O Relat�rio CIQ n�o pode ser enviado pois n�o h� emails cadastrados para este relat�rio.")
                        End If
                    Catch ex As Exception
                        messageControl.Alert(ex.Message)
                    End Try
                End If
                'Case "Registrar"
                '    If consistirRegistroAnalise(Convert.ToInt32(e.CommandArgument.ToString())) = True Then
                '        registrarAnaliseCompartimento(Convert.ToInt32(e.CommandArgument.ToString()))
                '    End If

            Case "Registrar_Analise_UProducao"
                Response.Redirect("lst_romaneio_analises_uproducao.aspx?id_romaneio=" + ViewState.Item("id_romaneio") + "&id_romaneio_compartimento=" + e.CommandArgument.ToString)

        End Select

    End Sub

    Protected Sub grdCompartimentos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCompartimentos.RowCreated
        'Fran 15/06/2009 chamado 276
        'If (e.Row.RowType = DataControlRowType.DataRow) Then
        '    Try
        '        Dim btn_registrar As ImageButton = CType(e.Row.FindControl("btn_registrar"), ImageButton)
        '        btn_registrar.CommandArgument = e.Row.RowIndex.ToString
        '    Catch ex As Exception
        '        messageControl.Alert(ex.Message)
        '    End Try

        'End If
        'Fran 15/06/2009 f chamado 276
    End Sub

    Protected Sub grdCompartimentos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCompartimentos.RowDataBound

        If (e.Row.RowType = DataControlRowType.DataRow) And ViewState.Item("loaddata") = "S" Then
            Try

                Dim cbo_registrar_id_st_analise As Anthem.DropDownList = CType(e.Row.FindControl("cbo_registrar_id_st_analise"), Anthem.DropDownList)
                Dim lbl_id_st_analise As Label = CType(e.Row.FindControl("lbl_id_st_analise"), Label)
                Dim lbl_nm_st_analise As Label = CType(e.Row.FindControl("lbl_nm_st_analise"), Label)
                Dim lbl_st_reanalise As Label = CType(e.Row.FindControl("lbl_st_reanalise"), Label)
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

                'Se o romaneio compartimento � reanalise
                If lbl_st_reanalise.Text.Trim = "S" Then
                    'N�o  tem ciq For�a enabled
                    hl_imprimir_ciq.Enabled = False
                    btn_email.Enabled = False
                    img_reanalise.ImageUrl = "~/img/ico_chk_true.gif"
                Else
                    img_reanalise.ImageUrl = "~/img/ico_chk_false.gif"
                End If

                'Se o compartimento ja esta registrado
                If Not lbl_nm_st_analise.Text.Equals(String.Empty) Then
                    'Fran 15/06/2009 i - chamado 276
                    'Dim btn_registrar As ImageButton = CType(e.Row.FindControl("btn_registrar"), ImageButton)
                    'Fran 15/06/2009 f - chamado 276
                    Dim lbl_labelmotivo As Anthem.Label = CType(e.Row.FindControl("lbl_labelmotivo"), Anthem.Label)
                    Dim txt_ds_motivo_aprovado_sob_concessao As Anthem.TextBox = CType(e.Row.FindControl("txt_ds_motivo_aprovado_sob_concessao"), Anthem.TextBox)

                    'pega o valor que ja registrou
                    lbl_st_registro.Visible = True
                    cbo_registrar_id_st_analise.SelectedValue = lbl_id_st_analise.Text
                    cbo_registrar_id_st_analise.Visible = False
                    'Fran 15/06/2009 i - chamado 276
                    'btn_registrar.Visible = False
                    'Fran 15/06/2009 f - chamado 276
                    'Se for aprovado sob concessao
                    If CInt(lbl_id_st_analise.Text) = 2 Then
                        lbl_labelmotivo.Visible = True
                        txt_ds_motivo_aprovado_sob_concessao.Visible = True
                        txt_ds_motivo_aprovado_sob_concessao.Enabled = True
                        'motivo.visible = true
                        'motivo.enabled = false
                    End If
                    'Se for analise rejeitada e reanalise <> S
                    If CInt(lbl_id_st_analise.Text) = 3 And lbl_st_reanalise.Text.Trim <> "S" Then
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
                    'cv_analista_dt.Visible = True
                    'cv_verificarrejeitadas.Visible = True
                    'cv_st_analises.Visible = True

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
                    'fran 03/2024 i se � cooperativa e analise e 102 (analise que obriga anexo)
                    If lbl_romaneio.Text = "Cooperativa" AndAlso .Item("cd_analise").ToString.Equals("102") Then
                        lbl_analise_anexo.Visible = True
                    Else
                        lbl_analise_anexo.Visible = False

                    End If
                End With
                'Carregar dados da analise na tela
                If ViewState.Item("st_obrigatoria") = "S" Then
                    img_chk_obrigatorio.ImageUrl = "~/img/ico_chk_true.gif"
                Else
                    img_chk_obrigatorio.ImageUrl = "~/img/ico_chk_false.gif"
                End If

                grdAnalises.Visible = True
                'Coluna com os campos para incluir valores da analise
                'Verifica o formato da an�lise
                Select Case Convert.ToInt32(ViewState.Item("id_formato_analise"))
                    Case 1 'Decimal
                        lbl_faixa_referencial.Text = CStr(CDec(ViewState.Item("nr_faixa_inicial"))) & "  -  " & CStr(CDec(ViewState.Item("nr_faixa_final")))
                    Case 2 'Inteiro
                        lbl_faixa_referencial.Text = CStr(CLng(ViewState.Item("nr_faixa_inicial"))) & "  -  " & CStr(CLng(ViewState.Item("nr_faixa_final")))
                    Case 3 ' L�gico
                        lbl_faixa_referencial.Text = dsromaneiocomp.Tables(0).Rows(0).Item("nm_faixa_referencia_logica")
                End Select

                'Fran 15/06/2009 i chamado 276
                Dim i As Int32 = 0
                For i = 0 To grdAnalises.Rows.Count - 1
                    ViewState.Item(String.Concat("txt_nr_valor", i.ToString)) = Nothing
                    ViewState.Item(String.Concat("txt_ds_comentario", i.ToString)) = Nothing
                Next
                chk_exibir_comentario.Checked = False
                'Fran 15/06/2009 f chamado 276


                grdAnalises.Visible = True
                lbl_analiseinformativa.Visible = True
                grdAnalises.DataSource = Helper.getDataView(dsromaneiocomp.Tables(0), ViewState.Item("sortExpression"))
                grdAnalises.DataBind()
            Else
                grdAnalises.Visible = False
                lbl_analiseinformativa.Visible = False
                messageControl.Alert("H� problemas na passagem de par�metros. Por favor tente novamente.")
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
                messageControl.Alert("H� problemas na passagem de par�metros. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Protected Sub cbo_cd_analise_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_cd_analise.SelectedIndexChanged
        If cbo_cd_analise.SelectedValue > 0 Then
            ViewState.Item("id_analise") = cbo_cd_analise.SelectedValue
            'Fran 10/06/2009 i rls 18
            'cbo_sigla_analise.SelectedValue = cbo_cd_analise.SelectedValue
            'Fran 10/06/2009 f
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
        'Fran 25/03/2009 i 

        'If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
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

        'Fran 25/03/2009 f
    End Sub

    Protected Sub grdAnalises_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAnalises.RowDataBound
        'Fran 15/06/2009 i - chamado 276

        'If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
        '    Try
        '        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '        'CAMPO VALOR
        '        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '        Select Case Convert.ToInt32(ViewState.Item("id_formato_analise"))
        '            Case 1 'Decimal
        '                Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
        '                Dim rfv_txt_dec_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_txt_dec_nr_valor"), RequiredFieldValidator)
        '                rfv_txt_dec_nr_valor.Visible = True
        '                txt_dec_nr_valor.Visible = True
        '                If Not (ViewState.Item("lbl_nr_valor").ToString.Equals(String.Empty)) Then
        '                    txt_dec_nr_valor.Text = CStr(CDec(ViewState.Item("lbl_nr_valor")))
        '                End If

        '            Case 2 'Inteiro
        '                Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
        '                Dim rfv_txt_int_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_txt_int_nr_valor"), RequiredFieldValidator)
        '                txt_int_nr_valor.Visible = True
        '                rfv_txt_int_nr_valor.Visible = True
        '                If Not (ViewState.Item("lbl_nr_valor").ToString.Equals(String.Empty)) Then
        '                    txt_int_nr_valor.Text = CStr(CLng(ViewState.Item("lbl_nr_valor")))
        '                End If
        '            Case 3 ' L�gico
        '                Dim cbo_nr_valor As DropDownList = CType(e.Row.FindControl("cbo_nr_valor"), DropDownList)
        '                Dim rfv_cbo_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_cbo_nr_valor"), RequiredFieldValidator)
        '                rfv_cbo_nr_valor.Visible = True
        '                cbo_nr_valor.Visible = True
        '                Dim analiselogica As New AnaliseLogica
        '                cbo_nr_valor.DataSource = analiselogica.getAnalisesLogicasByFilters
        '                cbo_nr_valor.DataTextField = "nm_analise_logica"
        '                cbo_nr_valor.DataValueField = "id_analise_logica"
        '                cbo_nr_valor.DataBind()

        '                If (ViewState.Item("lbl_nr_valor").ToString.Equals(String.Empty)) Then
        '                    'Fran 24/11/2008 i
        '                    'cbo_nr_valor.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        '                    cbo_nr_valor.SelectedValue = ViewState.Item("id_faixa_referencia_logica")
        '                    'Fran 24/11/2008
        '                Else
        '                    cbo_nr_valor.SelectedValue = CInt(ViewState.Item("lbl_nr_valor").Trim.ToString)
        '                End If
        '        End Select

        '    Catch ex As Exception
        '        messageControl.Alert(ex.Message)
        '    End Try
        'End If
        'If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Normal) Or (e.Row.RowState = DataControlRowState.Alternate)) Then
        '    Try
        '        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '        'CAMPO VALOR
        '        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '        'Verifica qual o formato da analise para montar o campo correto
        '        Dim id_st_original As Label = CType(e.Row.FindControl("lbl_id_st_original"), Label)
        '        Dim lbl_nr_valor As Label = CType(e.Row.FindControl("lbl_nr_valor"), Label)
        '        Dim lbl_nm_valor As Label = CType(e.Row.FindControl("lbl_nm_valor"), Label)
        '        Dim nm_st_analise As Label = CType(e.Row.FindControl("lbl_nm_st_analise"), Label)
        '        Dim lbl_id_st_analise_compartimento As Label = CType(e.Row.FindControl("lbl_id_st_analise_compartimento"), Label)
        '        Dim btn_editar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)

        '        If Not lbl_id_st_analise_compartimento.Text.Equals(String.Empty) Then
        '            btn_editar.ImageUrl = "~/img/icone_editar_grid_desabilitado.gif"
        '            btn_editar.Enabled = False
        '            btn_editar.ToolTip = "A edi��o da an�lise n�o pode ser realizada para compartimentos j� registrados."
        '        End If
        '        If Not nm_st_analise Is Nothing Then
        '            If ViewState.Item("st_gera_ciq") = "N" Then
        '                If Not id_st_original.Text.Equals(String.Empty) Then
        '                    If id_st_original.Text = "2" Then
        '                        nm_st_analise.Text = "Rejeitado*"
        '                    End If
        '                End If
        '            Else
        '                If nm_st_analise.Text = "Rejeitado" Then
        '                    ViewState.Item("rejeitado") = "S"
        '                End If
        '            End If
        '        End If

        '        If Not (lbl_nr_valor.Text.ToString.Equals(String.Empty)) Then
        '            Select Case Convert.ToInt32(ViewState.Item("id_formato_analise"))
        '                Case 1 'Decimal
        '                    lbl_nr_valor.Text = CStr(CDec(lbl_nr_valor.Text))
        '                    'Fran 25/03/2009 i 
        '                    If Left(UCase(Me.cbo_sigla_analise.SelectedItem.Text.Trim), 4) = "TEMP" Then
        '                        lbl_nr_valor.Text = CStr(FormatNumber(CDec(lbl_nr_valor.Text), 1))
        '                    End If
        '                    'Fran 25/03/2009 f
        '                Case 2 'Inteiro
        '                    lbl_nr_valor.Text = CStr(CLng(lbl_nr_valor.Text))
        '                Case 3 ' L�gico
        '                    lbl_nr_valor.Visible = False
        '                    lbl_nm_valor.Visible = True
        '            End Select
        '        End If

        '    Catch ex As Exception
        '        messageControl.Alert(ex.Message)
        '    End Try
        'End If
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

                'Se j� registrou cpompartimento, n�o deixa mais fazer edi��o
                If Not lbl_id_st_analise_compartimento.Text.Equals(String.Empty) Then
                    lbl_nr_valor.Visible = True
                    txt_dec_nr_valor.Visible = False
                    txt_int_nr_valor.Visible = False
                    cbo_nr_valor.Visible = False

                    lbl_nr_valor.ToolTip = "A edi��o da an�lise n�o pode ser realizada para compartimentos j� registrados."
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
                            Case 3 ' L�gico
                                lbl_nr_valor.Visible = False
                                lbl_nm_valor.Visible = True
                                lbl_nm_valor.ToolTip = "A edi��o da an�lise n�o pode ser realizada para compartimentos j� registrados."
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
                        Case 3 ' L�gico

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
                'Percorre o grid de compartimento e encontra a linha do romaneio_compartimento para a analise em altera��o
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
                'Percorre o grid de compartimento e encontra a linha do romaneio_compartimento para a analise em altera��o
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
                loadData()

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
                    messageControl.Alert("Para registrar o resultado desta an�lise de compartimento, o nome do analista e a data de in�cio da an�lise devem ser informados.")
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
                    messageControl.Alert("Para registrar o resultado desta an�lise de compartimento, todas as an�lises obrigat�rias devem ser informadas.")
                    Exit Try
                End If

                If CLng(ViewState.Item("id_cooperativa")) > 0 Then
                    'verifica se tem analise 102 para o romaneio compartimento
                    Dim romaneio As New Romaneio
                    romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                    romaneio.cd_analise = 102
                    If romaneio.getRomaneioAnalisesCompartimentosDistinct.Tables(0).Rows.Count > 0 Then
                        'Busaca as analises que sao obrigatorias anexo de documentos de cooperativa reanalise <> S e statuscompartimento vazio
                        If analisecomp.getRomaneioAnaliseCompartimentoExigeAnexoSemResultado() > 0 Then
                            bIsValid = False
                            consistirRegistroAnalise = False
                            messageControl.Alert("Para registrar o resultado desta an�lise de compartimento, a an�lise 102 deve ser informada.")
                            Exit Try
                        End If

                        Dim anexo As New RomaneioAnaliseAnexo
                        anexo.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                        anexo.cd_analise = 102
                        Dim dsanexo As DataSet = anexo.getRomaneioAnaliseAnexo
                        If dsanexo.Tables(0).Rows.Count = 0 Then 'se n�o tem aanexo da analise
                            bIsValid = False
                            consistirRegistroAnalise = False
                            messageControl.Alert("Para registrar o resultado desta an�lise de compartimento, o documento referente a an�lise 102 deve ser anexado.")
                            Exit Try
                        End If

                    End If
                End If
                'Consistir cbo registrat
                Dim liresult As Int32
                Dim lsvaluecbo As Integer
                Dim lmsg As String

                If Not cbo_registrar_id_st_analise.SelectedValue.Equals(String.Empty) Then
                    lsvaluecbo = CInt(cbo_registrar_id_st_analise.SelectedValue)
                    'Se tem alguma analise rejeitada, o cbo n�o pode ser registro de aprovada
                    liresult = analisecomp.getRomaneioAnaliseCompartimentoRejeitada()

                    'Se tem rejeitadas....
                    If liresult > 0 Then
                        If lsvaluecbo = 1 Then
                            bIsValid = False
                            lmsg = "Voc� n�o pode registrar a an�lise do compartimento como 'APROVADA' porque h� an�lises com situa��o 'REJEITADA'"
                        End If
                    Else 'se n�o tem rejeitadas
                        If lsvaluecbo <> 1 Then
                            bIsValid = False
                            lmsg = "A an�lise deste compartimento s� pode ser registrada como 'APROVADA' pois n�o h� registro de an�lises com situa��o 'REJEITADA'"
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
                        messageControl.Alert("A justificativa da Aprova��o Sob Concess�o deve ser preenchida.")
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
    Protected Sub cv_reanalise_obrigatorias_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_reanalise_obrigatorias.ServerValidate
        Try
            args.IsValid = True
            Dim analisesaprovadas As New Romaneio_Compartimento
            Dim lmsg As String
            analisesaprovadas.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            'Verifica se h� compartimentos registrados aprovados ou sem registro
            If analisesaprovadas.getRomaneioCompartimentosAprovados > 0 Then
                'se existe
                'Verifica se h� alguma analise sem valor
                If analisesaprovadas.getRomaneioAnaliseCompartimentoAprovadoNuloObrigatoriaSemValor > 0 Then
                    args.IsValid = False
                    lmsg = "A re-an�lise n�o pode ser gerada pois h� Compartimentos com an�lises obrigat�rias sem preenchimento de resultado."
                Else
                    'Busca todas as compartimento sem registro com analises rejeitafdas
                    If analisesaprovadas.getRomaneioCompartimentosSemRegistroAnaliseRejeitada > 0 Then
                        args.IsValid = False
                        lmsg = "A re-an�lise n�o pode ser gerada pois h� Compartimentos n�o registrados com an�lises rejeitadas."
                    End If
                End If
            Else
                args.IsValid = False
                lmsg = "A re-an�lise n�o pode ser gerada pois todos os compartimentos j� est�o registrados como 'Rejeitado' ou 'Aprovado sob Concess�o'."
            End If
            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

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
            messageControl.Alert("Para registrar o resultado desta an�lise de compartimento, todas as an�lises obrigat�rias devem ser informadas.")
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
            'Se tem alguma analise rejeitada, o cbo n�o pode ser registro de aprovada
            liresult = analisecomp.getRomaneioAnaliseCompartimentoRejeitada()

            'Se tem rejeitadas....
            If liresult > 0 Then
                If lsvaluecbo = 1 Then
                    args.IsValid = False
                    lmsg = "Voc� n�o pode registrar a an�lise do compartimento como 'APROVADA' porque h� an�lises com situa��o 'REJEITADA'"
                End If
            Else 'se n�o tem rejeitadas
                If lsvaluecbo <> 1 Then
                    args.IsValid = False
                    lmsg = "A an�lise deste compartimento s� pode ser registrada como 'APROVADA' pois n�o h� registro de an�lises com situa��o 'REJEITADA'"
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
        '    messageControl.Alert("Para registrar o resultado desta an�lise de compartimento, o nome do analista e a data de in�cio da an�lise devem ser salvos.")
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
            messageControl.Alert("Para registrar o resultado desta an�lise de compartimento, o nome do analista e a data de in�cio da an�lise devem ser informados.")
        End If

    End Sub

    Protected Sub btn_registrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_registrar.Click
        If Page.IsValid Then
            Dim row As GridViewRow
            Try
                For Each row In grdCompartimentos.Rows
                    If consistirRegistroAnalise(row.RowIndex) = True Then
                        registrarAnaliseCompartimento(row.RowIndex)
                    End If
                Next
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 22
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub btn_reanalise_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_reanalise.Click
        If Page.IsValid Then

            Try
                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                romaneio.gerarRomaneioReanalises()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 22
                usuariolog.ds_nm_processo = "Registrar An�lises - Re-an�lise"
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 


                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

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
                    Case 3 ' L�gico
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

                'Se ha linhas na navega��o
                If (dsanalisenavegacao.Tables(0).Rows.Count > 0) Then
                    'se n�o tem analise selecionada
                    'Dim row As DataRow
                    'Dim bproxima As Boolean = False
                    ''descobre qual a pr�xima
                    'For Each row In dsanalisenavegacao.Tables(0).Rows
                    '    If bproxima = True And pid_analise <> row.Item("id_analise") Then
                    '        'posiciona na analise
                    '        ViewState.Item("id_analise") = row.Item("id_analise")
                    '        Exit For
                    '    End If
                    '    If pid_analise = row.Item("id_analise") Then
                    '        bproxima = True
                    '    End If
                    'Next

                    'posiciona na primeira analise sem informa��o de resultado

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
                'Se todos os compartimentos est�o registrados, visualiza analise pela ordem do combo pois n�o pode mais alterar
                If cbo_cd_analise.SelectedIndex = cbo_cd_analise.Items.Count - 1 Then
                    ViewState.Item("id_analise") = cbo_cd_analise.Items(1).Value
                Else
                    ViewState.Item("id_analise") = cbo_cd_analise.Items(cbo_cd_analise.SelectedIndex + 1).Value
                End If

            End If

            'fran 16/06/2009 f

            cbo_cd_analise.SelectedValue = ViewState.Item("id_analise")
            'carrega an�lise
            loadAnalise()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_AnexarDocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_AnexarDocumento.Click

        Response.Redirect("frm_romaneio_analise_comp_anexos.aspx?id=" + ViewState.Item("id_romaneio").ToString() + "&tela=frm_romaneio_analise_comp_veiculo.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString)

    End Sub

    Protected Sub cv_verificar_resultado_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_verificar_resultado.ServerValidate
        Try
            args.IsValid = True

            Dim lmsg As String
            Dim row As GridViewRow

            Dim bresultadoforafaixa As Boolean = False

            If ViewState.Item("confirmarsalvar") = False Then

                For Each row In grdAnalises.Rows

                    If (Not (row) Is Nothing) Then

                        Select Case Convert.ToInt32(ViewState.Item("id_formato_analise"))
                            Case 1 'Descimal
                                Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                                If Not (txt_dec_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                                    If Convert.ToDecimal(txt_dec_nr_valor.Text.Trim.ToString) >= CDec(ViewState.Item("nr_faixa_inicial")) And Convert.ToDecimal(txt_dec_nr_valor.Text.Trim.ToString) <= CDec(ViewState.Item("nr_faixa_final")) Then
                                        'Aprovado
                                    Else
                                        bresultadoforafaixa = True
                                        txt_dec_nr_valor.BackColor = Drawing.Color.Yellow
                                    End If
                                End If

                            Case 2 'Inteiro
                                Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                                If Not (txt_int_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                                    If CLng(Convert.ToInt32(txt_int_nr_valor.Text)) >= CLng(ViewState.Item("nr_faixa_inicial")) And CLng(Convert.ToInt32(txt_int_nr_valor.Text)) <= CLng(ViewState.Item("nr_faixa_final")) Then
                                        'Aprovado
                                    Else
                                        bresultadoforafaixa = True
                                        txt_int_nr_valor.BackColor = Drawing.Color.Yellow
                                    End If
                                End If

                            Case 3 'Logico
                                Dim cbo_nr_valor As DropDownList = CType(row.FindControl("cbo_nr_valor"), DropDownList)
                                If Not (cbo_nr_valor.SelectedValue.Trim().Equals(String.Empty)) Then
                                    If CLng(Convert.ToInt32(cbo_nr_valor.SelectedValue)) = CLng(ViewState.Item("id_faixa_referencia_logica")) Then
                                        'Aprovado
                                    Else
                                        bresultadoforafaixa = True
                                        cbo_nr_valor.BackColor = Drawing.Color.YellowGreen
                                    End If

                                End If

                        End Select
                    End If
                Next

            End If

            If bresultadoforafaixa = True Then
                args.IsValid = False
                lbl_analise_fora.Visible = True
                lmsg = "AN�LISE DIGITADA FORA DA FAIXA REFERENCIAL. SE DIGITA��O CORRETA PROSSIGA COM SALVAR."
                Me.messageControl.Alert(lmsg)
                ViewState.Item("confirmarsalvar") = True
            End If

        Catch ex As Exception
            Me.messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
