Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_romaneio_saida_analise_comp_veiculo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_saida_analise_comp_veiculo.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio_saida") Is Nothing) Then
                ViewState.Item("id_romaneio_saida") = Request("id_romaneio_saida")
                ViewState.Item("caminho_servidor") = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()

                Dim companalise As New RomaneioSaida
                companalise.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))

                cbo_cd_analise.DataSource = companalise.getRomaneioSaidaAnaliseCompartimentoDistinct()
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

            Dim romaneio As New RomaneioSaida(Convert.ToInt32(ViewState.Item("id_romaneio_saida")))

            ViewState.Item("id_cooperativa") = romaneio.id_cooperativa

            Me.lbl_id_romaneio.Text = romaneio.id_romaneio_saida.ToString
            Me.lbl_nm_st_romaneio.Text = romaneio.nm_situacao_romaneio_saida.ToString
            Me.lbl_estabelecimento.Text = romaneio.ds_estabelecimento
            Me.lbl_nm_item.Text = romaneio.nm_item
            Me.lbl_transportador.Text = romaneio.nm_transportador
            Me.lbl_destino.Text = romaneio.nm_cooperativa

            ViewState.Item("id_estabelecimento") = romaneio.id_estabelecimento

            Dim romaneiocompartimento As New RomaneioSaidaCompartimento

            romaneiocompartimento.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))

            Dim dsromaneiocomp As DataSet = romaneiocompartimento.getRomaneioSaidaCompartimentoByFilters

            'Se ha linhas na romaneio compartimento
            If (dsromaneiocomp.Tables(0).Rows.Count > 0) Then

                If Not IsDBNull(dsromaneiocomp.Tables(0).Rows(0).Item("nm_analista")) Then
                    txt_nm_analista.Text = dsromaneiocomp.Tables(0).Rows(0).Item("nm_analista")
                Else
                    txt_nm_analista.Text = Session("ds_login")
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
            'fran 16/06/2009 i
            navegacaoGrdAnalise()
            'fran 16/06/2009 f

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        'Response.Redirect("frm_usuario.aspx?id_usuario=" + ViewState.Item("id_usuario").ToString)
        Response.Redirect("lst_romaneio_saida_analise_selecao.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_saida_analise_selecao.aspx")

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

                Dim rc As New RomaneioSaidaCompartimento()
                rc.dt_inicio_analise = txt_dt_analise.Text & " " & txt_hr_analise.Text & ":" & txt_mm_analise.Text & ":00"
                rc.nm_analista = txt_nm_analista.Text.ToString
                rc.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
                rc.id_modificador = Session("id_login")

                rc.updateRomaneioSaidaCompartimentosAnalista()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteração
                usuariolog.id_menu_item = 248
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio_saida").ToString
                usuariolog.nm_nr_processo = ViewState.Item("id_romaneio_saida").ToString

                usuariolog.insertUsuarioLog()

                'atualiza romaneio para em analise
                Dim romaneio As New RomaneioSaida(ViewState.Item("id_romaneio_saida"))
                If romaneio.id_situacao_romaneio_saida < 5 Then
                    romaneio.id_situacao_romaneio_saida = 5
                    romaneio.id_situacao = 5
                    romaneio.id_modificador = Session("id_login")
                    romaneio.updateRomaneioSaidaSituacao()
                    romaneio.insertRomaneioSaidaSituacaoLog()
                End If

                Dim row As GridViewRow
                Dim romaneioanalisecompartimento As New RomaneioSaidaAnaliseCompartimento
                For Each row In grdAnalises.Rows

                    If (Not (row) Is Nothing) Then

                        Dim txt_ds_comentario As TextBox = CType(row.FindControl("txt_ds_comentario"), TextBox)
                        Dim lbl_id_romaneio_compartimento As Label = CType(row.FindControl("lbl_id_romaneio_compartimento"), Label)
                        Dim lbl_ds_comentario As Label = CType(row.FindControl("lbl_ds_comentario"), Label)

                        romaneioanalisecompartimento.id_romaneio_saida_analise_compartimento = Convert.ToInt32(grdAnalises.DataKeys.Item(row.RowIndex).Value)
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
                        'If ViewState.Item("st_gera_ciq") = "N" Then
                        '    If romaneioanalisecompartimento.id_st_analise = 2 Then 'Rejeitado
                        '        romaneioanalisecompartimento.id_st_original = 2
                        '        romaneioanalisecompartimento.id_st_analise = 1
                        '        'volta o status do incio da rotina
                        '        'ViewState.Item("rejeitado") = lviewstaterejeitado
                        '    Else
                        '        romaneioanalisecompartimento.id_st_original = 0
                        '        romaneioanalisecompartimento.id_st_analise = 1
                        '    End If

                        'End If

                        romaneioanalisecompartimento.updateRomaneioSaidaAnaliseCompartimento()
                        'se tem analises rejeitadas para o compartimento
                        atualizarCboRegistroAnalise(Convert.ToInt32(ViewState.Item("id_romaneio_saida")), Convert.ToInt32(lbl_id_romaneio_compartimento.Text))
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
                        Dim lAssunto As String = "RELATÓRIO CIQ " & e.CommandArgument.ToString
                        Dim lCorpo As String = "Existe uma ocorrência relatada através do Relatório CIQ, que pode ser visualizado pelo link " & ViewState.Item("caminho_servidor") & "/frm_relatorio_CIQ.aspx?id_romaneio_compartimento=" & e.CommandArgument.ToString & " ."

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
                'Case "Registrar"
                '    If consistirRegistroAnalise(Convert.ToInt32(e.CommandArgument.ToString())) = True Then
                '        registrarAnaliseCompartimento(Convert.ToInt32(e.CommandArgument.ToString()))
                '    End If

            Case "Registrar_Analise_UProducao"
                'Response.Redirect("lst_romaneio_analises_uproducao.aspx?id_romaneio=" + ViewState.Item("id_romaneio") + "&id_romaneio_compartimento=" + e.CommandArgument.ToString)

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
                'Dim btn_registrar_analise_uproducao As ImageButton = CType(e.Row.FindControl("btn_registrar_analise_uproducao"), ImageButton)
                Dim img_reanalise As Image = CType(e.Row.FindControl("img_reanalise"), Image)
                Dim lbl_st_registro As Label = CType(e.Row.FindControl("lbl_st_registro"), Label)

                Dim resultadoanalise As New StatusResultadoAnalise
                cbo_registrar_id_st_analise.DataSource = resultadoanalise.getStatusResultadoAnaliseByFilters()
                cbo_registrar_id_st_analise.DataTextField = "nm_status_resultado_analise"
                cbo_registrar_id_st_analise.DataValueField = "id_status_resultado_analise"
                cbo_registrar_id_st_analise.DataBind()

                'Se o romaneio compartimento é reanalise
                If lbl_st_reanalise.Text.Trim = "S" Then
                    'Não  tem ciq Força enabled
                    hl_imprimir_ciq.Enabled = False
                    btn_email.Enabled = False
                    img_reanalise.ImageUrl = "~/img/ico_chk_true.gif"
                Else
                    img_reanalise.ImageUrl = "~/img/ico_chk_false.gif"
                End If

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
                    'Se for analise rejeitada e reanalise <> S
                    'If CInt(lbl_id_st_analise.Text) = 3 And lbl_st_reanalise.Text.Trim <> "S" Then
                    If CInt(lbl_id_st_analise.Text) = 5 Then
                        hl_imprimir_ciq.Enabled = True
                        hl_imprimir_ciq.ImageUrl = "~/img/ic_impressao.gif"
                        hl_imprimir_ciq.NavigateUrl = String.Format("frm_relatorio_CIQ.aspx?id_romaneio_saida_compartimento={0}", grdCompartimentos.DataKeys.Item(e.Row.RowIndex).Value)
                        btn_email.Enabled = True
                        btn_email.ImageUrl = "~/img/ico_email.gif"
                    End If
                    'If CInt(lbl_id_st_analise.Text) = 3 Then
                    '    btn_registrar_analise_uproducao.Enabled = True
                    '    btn_registrar_analise_uproducao.ImageUrl = "~/img/icon_registrar2.gif"
                    'End If
                Else
                    'pega o valor que ja registrou
                    lbl_st_registro.Visible = False
                    cbo_registrar_id_st_analise.Visible = True

                    Dim romaneioanalisecomp As New RomaneioSaidaAnaliseCompartimento
                    'se tem analises rejeitadas para o compartimento
                    romaneioanalisecomp.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
                    romaneioanalisecomp.id_romaneio_saida_compartimento = Convert.ToInt32(grdCompartimentos.DataKeys.Item(e.Row.RowIndex).Value)

                    If romaneioanalisecomp.getRomaneioSaidaAnaliseCompartimentoRejeitada() > 0 Then
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

            Dim analisecomp As New RomaneioSaidaAnaliseCompartimento

            analisecomp.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
            analisecomp.id_analise = Convert.ToInt32(ViewState.Item("id_analise"))

            Dim dsromaneiocomp As DataSet = analisecomp.getRomaneioSaidaAnaliseCompartimentoByFilters

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
                    'fran 03/2024 i se é cooperativa e analise e 102 (analise que obriga anexo)
                    'If lbl_romaneio.Text = "Cooperativa" AndAlso .Item("cd_analise").ToString.Equals("102") Then
                    If .Item("cd_analise").ToString.Equals("102") Then
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

            Dim analisecomp As New RomaneioSaidaAnaliseCompartimento

            analisecomp.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
            analisecomp.id_analise = Convert.ToInt32(ViewState.Item("id_analise"))

            Dim dsromaneiocomp As DataSet = analisecomp.getRomaneioSaidaAnaliseCompartimentoByFilters

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
        '            Case 3 ' Lógico
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
        '            btn_editar.ToolTip = "A edição da análise não pode ser realizada para compartimentos já registrados."
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
        '                Case 3 ' Lógico
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
            Dim romaneio As New RomaneioSaida(ViewState.Item("id_romaneio_saida"))
            If romaneio.id_situacao_romaneio_saida < 5 Then
                romaneio.id_situacao_romaneio_saida = 5
                romaneio.id_modificador = Session("id_login")
                romaneio.updateRomaneioSaidaSituacao()
                romaneio.insertRomaneioSaidaSituacaoLog()
            End If

            If (Not (row) Is Nothing) Then

                Dim romaneioanalisecompartimento As New RomaneioSaidaAnaliseCompartimento
                Dim txt_ds_comentario As TextBox = CType(row.FindControl("txt_ds_comentario"), TextBox)
                Dim lbl_id_romaneio_compartimento As Label = CType(row.FindControl("lbl_id_romaneio_compartimento"), Label)
                'Dim lviewstaterejeitado As String = ViewState.Item("rejeitado").ToString

                romaneioanalisecompartimento.id_romaneio_saida_analise_compartimento = Convert.ToInt32(grdAnalises.DataKeys.Item(e.RowIndex).Value)
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
                romaneioanalisecompartimento.updateRomaneioSaidaAnaliseCompartimento()
                'se tem analises rejeitadas para o compartimento
                atualizarCboRegistroAnalise(Convert.ToInt32(ViewState.Item("id_romaneio_saida")), Convert.ToInt32(lbl_id_romaneio_compartimento.Text))
                grdAnalises.EditIndex = -1
                loadGridAnalise()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub loadGridAnalise()

        Try
            Dim analisecomp As New RomaneioSaidaAnaliseCompartimento

            analisecomp.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
            analisecomp.id_analise = Convert.ToInt32(ViewState.Item("id_analise"))

            Dim dsromaneiocomp As DataSet = analisecomp.getRomaneioSaidaAnaliseCompartimentoByFilters

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
            Dim romaneioanalisecomp As New RomaneioSaidaAnaliseCompartimento

            'se tem analises rejeitadas para o compartimento
            romaneioanalisecomp.id_romaneio_saida = id_romaneio
            romaneioanalisecomp.id_romaneio_saida_compartimento = id_romaneio_compartimento

            If romaneioanalisecomp.getRomaneioSaidaAnaliseCompartimentoRejeitada() > 0 Then
                'Percorre o grid de compartimento e encontra a linha do romaneio_compartimento para a analise em alteração
                Dim lrow As GridViewRow
                For Each lrow In grdCompartimentos.Rows
                    If CLng(grdCompartimentos.DataKeys.Item(lrow.RowIndex).Value) = romaneioanalisecomp.id_romaneio_saida_compartimento Then
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
                    If CLng(grdCompartimentos.DataKeys.Item(lrow.RowIndex).Value) = romaneioanalisecomp.id_romaneio_saida_compartimento Then
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

                Dim romaneiocomp As New RomaneioSaidaCompartimento
                romaneiocomp.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
                'se todos os compartimentos do romaneio saida ja foram registrados
                If romaneiocomp.getRomaneioSaidaCompartimentoSemRegistroAnalise = 0 Then
                    Dim romaneio As New RomaneioSaida
                    romaneio.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
                    romaneio.id_situacao_romaneio_saida = 6 'Analise finalizada
                    romaneio.id_modificador = Session("id_login")
                    romaneio.updateRomaneioSaidaSituacao()
                    romaneio.id_situacao = 6
                    romaneio.insertRomaneioSaidaSituacaoLog()
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
                    messageControl.Alert("Para registrar o resultado desta análise de compartimento, o nome do analista e a data de início da análise devem ser informados.")
                    Exit Try
                End If

                'Consistir anslises obrigatorias
                Dim analisecomp As New RomaneioSaidaAnaliseCompartimento
                analisecomp.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
                analisecomp.id_romaneio_saida_compartimento = id_romaneio_compartimento
                'Busaca as analise obrigatorias, reanalise <> S e statuscompartimento vazio
                If analisecomp.getRomaneioSaidaAnaliseCompartimentoSemResultado() > 0 Then
                    bIsValid = False
                End If

                If bIsValid = False Then
                    consistirRegistroAnalise = False
                    messageControl.Alert("Para registrar o resultado desta análise de compartimento, todas as análises obrigatórias devem ser informadas.")
                    Exit Try
                End If

                If CLng(ViewState.Item("id_cooperativa")) > 0 Then
                    'verifica se tem analise 102 para o romaneio compartimento
                    Dim romaneio As New RomaneioSaida
                    romaneio.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
                    romaneio.cd_analise = 102
                    If romaneio.getRomaneioSaidaAnaliseCompartimentoDistinct.Tables(0).Rows.Count > 0 Then
                        'Busaca as analises que sao obrigatorias anexo de documentos de cooperativa reanalise <> S e statuscompartimento vazio
                        If analisecomp.getRomaneioSaidaAnaliseCompartimentoExigeAnexoSemResultado() > 0 Then
                            bIsValid = False
                            consistirRegistroAnalise = False
                            messageControl.Alert("Para registrar o resultado desta análise de compartimento, a análise 102 deve ser informada.")
                            Exit Try
                        End If

                        Dim anexo As New RomaneioSaidaAnaliseAnexo
                        anexo.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
                        anexo.cd_analise = 102
                        Dim dsanexo As DataSet = anexo.getRomaneioSaidaAnaliseAnexo
                        If dsanexo.Tables(0).Rows.Count = 0 Then 'se não tem aanexo da analise
                            bIsValid = False
                            consistirRegistroAnalise = False
                            messageControl.Alert("Para registrar o resultado desta análise de compartimento, o documento referente a análise 102 deve ser anexado.")
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
                    'Se tem alguma analise rejeitada, o cbo não pode ser registro de aprovada
                    liresult = analisecomp.getRomaneioSaidaAnaliseCompartimentoRejeitada()

                    'Se tem rejeitadas....
                    If liresult > 0 Then
                        If lsvaluecbo = 1 Then
                            bIsValid = False
                            lmsg = "Você não pode registrar a análise do compartimento como 'APROVADA' porque há análises com situação 'REJEITADA'"
                        End If
                    Else 'se não tem rejeitadas
                        If lsvaluecbo <> 1 Then
                            bIsValid = False
                            lmsg = "A análise deste compartimento só pode ser registrada como 'APROVADA' pois não há registro de análises com situação 'REJEITADA'"
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
                        messageControl.Alert("A justificativa da Aprovação Sob Concessão deve ser preenchida.")
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

                Dim romaneio As New RomaneioSaida(Convert.ToInt32(ViewState.Item("id_romaneio_saida")))

                romaneio.id_st_analise_compartimento = 2 'Rejeitada 
                romaneio.id_modificador = Session("id_login")
                romaneio.romaneiosaidacompartimento = New RomaneioSaidaCompartimento(id_romaneio_compartimento)
                'romaneio.romaneio_compartimento.id_st_analise = id_st_analise_compartimento 'Rejeitada ou Aprovada sob concessao
                romaneio.romaneiosaidacompartimento.id_st_analise = 3 'Rejeitada 
                romaneio.romaneiosaidacompartimento.id_modificador = Session("id_login")
                romaneio.romaneiosaidacompartimento.dt_inicio_analise = txt_dt_analise.Text & " " & txt_hr_analise.Text & ":" & txt_mm_analise.Text & ":00"
                romaneio.romaneiosaidacompartimento.nm_analista = txt_nm_analista.Text.ToString

                romaneio.registrarRomSaidaAnaliseCompartimentoRejeitada()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
    Private Sub RegistrarAnaliseCompartimentoAprovada(ByVal id_st_analise_compartimento As Int32, ByVal id_romaneio_compartimento As Int32)
        If Page.IsValid = True Then

            Try
                Dim romaneio As New RomaneioSaida(Convert.ToInt32(ViewState.Item("id_romaneio_saida")))
                'Dim id_st_analise_compartimento As Int32 = CInt(Me.cbo_registro_analise.SelectedValue)
                romaneio.id_st_analise_compartimento = 1 'Aprovada 
                romaneio.id_modificador = Session("id_login")
                romaneio.romaneiosaidacompartimento = New RomaneioSaidaCompartimento(id_romaneio_compartimento)
                'romaneio.romaneio_compartimento.id_st_analise = 1 'Aprovada
                romaneio.romaneiosaidacompartimento.id_st_analise = id_st_analise_compartimento 'Aprovada ou Aprovada sob concessao
                romaneio.romaneiosaidacompartimento.id_modificador = Session("id_login")
                romaneio.romaneiosaidacompartimento.dt_inicio_analise = txt_dt_analise.Text & " " & txt_hr_analise.Text & ":" & txt_mm_analise.Text & ":00"
                romaneio.romaneiosaidacompartimento.nm_analista = txt_nm_analista.Text.ToString
                'If id_st_analise_compartimento = 2 Then 'aprovado sob concessao
                'romaneio.romaneio_compartimento.ds_motivo_aprovado_sob_concessao = txt_ds_motivo_aprovado_sob_concessao.Text.ToString
                'End If
                romaneio.registrarRomSaidaAnaliseCompartimentoAprovada()

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

        Dim analisecomp As New RomaneioSaidaAnaliseCompartimento
        analisecomp.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
        analisecomp.id_romaneio_saida_compartimento = Convert.ToInt32(grdCompartimentos.DataKeys(row.RowIndex).Value)
        'Busaca as analise obrigatorias, reanalise <> S e statuscompartimento vazio
        If analisecomp.getRomaneioSaidaAnaliseCompartimentoSemResultado() > 0 Then
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

        Dim analisecomp As New RomaneioSaidaAnaliseCompartimento
        Dim liresult As Int32
        Dim lsvaluecbo As Integer
        Dim lmsg As String

        args.IsValid = True
        If Not cbo_registrar_id_st_analise.SelectedValue.Equals(String.Empty) Then
            lsvaluecbo = CInt(cbo_registrar_id_st_analise.SelectedValue)
            analisecomp.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
            analisecomp.id_romaneio_saida_compartimento = Convert.ToInt32(grdCompartimentos.DataKeys(row.RowIndex).Value)
            'Se tem alguma analise rejeitada, o cbo não pode ser registro de aprovada
            liresult = analisecomp.getRomaneioSaidaAnaliseCompartimentoRejeitada()

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
                usuariolog.id_menu_item = 248
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio_saida").ToString
                usuariolog.nm_nr_processo = ViewState.Item("id_romaneio_saida").ToString

                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    'Protected Sub btn_reanalise_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_reanalise.Click
    '    If Page.IsValid Then

    '        Try
    '            Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio_saida")))

    '            romaneio.gerarRomaneioReanalises()

    '            'FRAN 08/12/2020 i incluir log 
    '            Dim usuariolog As New UsuarioLog
    '            usuariolog.id_usuario = Session("id_login")
    '            usuariolog.ds_id_session = Session.SessionID.ToString()
    '            usuariolog.id_tipo_log = 6 'processo
    '            usuariolog.id_menu_item = 22
    '            usuariolog.ds_nm_processo = "Registrar Análises - Re-análise"
    '            usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
    '            usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

    '            usuariolog.insertUsuarioLog()
    '            'FRAN 08/12/2020  incluir log 


    '            loadData()

    '        Catch ex As Exception
    '            messageControl.Alert(ex.Message)
    '        End Try
    '    End If

    'End Sub

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


                Dim romanalcomp As New RomaneioSaida

                romanalcomp.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))

                Dim dsanalisenavegacao As DataSet = romanalcomp.getRomaneioSaidaAnaliseNullNavegacao

                'Se ha linhas na navegação
                If (dsanalisenavegacao.Tables(0).Rows.Count > 0) Then
                    'se não tem analise selecionada
                    'Dim row As DataRow
                    'Dim bproxima As Boolean = False
                    ''descobre qual a próxima
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

                    'posiciona na primeira analise sem informação de resultado

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

    Protected Sub lk_AnexarDocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_AnexarDocumento.Click

        Response.Redirect("frm_romaneio_saida_analise_comp_anexos.aspx?id=" + ViewState.Item("id_romaneio_saida").ToString() + "&tela=frm_romaneio_saida_analise_comp_veiculo.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida").ToString)

    End Sub
End Class
