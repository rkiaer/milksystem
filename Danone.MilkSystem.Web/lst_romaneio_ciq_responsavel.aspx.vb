Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class lst_romaneio_ciq_responsavel


    Inherits Page
    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click


        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("txt_dt_hora_entrada_ini") = txt_dt_hora_entrada_ini.Text
        ViewState.Item("txt_dt_hora_entrada_fim") = txt_dt_hora_entrada_fim.Text
        ViewState.Item("id_romaneio") = txt_id_romaneio.Text
        ViewState.Item("nm_linha") = txt_rota.Text
        ViewState.Item("id_romaneio_compartimento") = txt_nr_ciq.Text
        ViewState.Item("emitente") = cbo_emitente.SelectedValue


        ViewState.Item("sortExpression") = "id_romaneio desc"

        Me.pnl_romaneio.Visible = False  ' Tira painel de consultas anteriores
        'limpa detalhe
        ViewState.Item("id_romaneio_detalhe") = 0
        ViewState.Item("id_romaneio_compartimento_detalhe") = 0
        ViewState.Item("id_st_romaneio_detalhe") = 0
        ViewState.Item("transportador_detalhe") = String.Empty

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_ciq_responsavel.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_ciq_responsavel.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 219
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim romaneio As New Romaneio

            estabelecimento.id_situacao = 1
            estabelecimento.st_recepcao_leite = "S"
            Dim dsestabel As DataSet = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataSource = Helper.getDataView(dsestabel.Tables(0), "nm_estabelecimento")
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_estabelecimento.Items.Insert(cbo_estabelecimento.Items.Count, New ListItem("Boa Esperança", "77"))

            Dim motivociq As New MotivoResponsavelCIQ
            Dim dsmotivociq As DataSet = motivociq.getMotivoResponsavelCIQByFilters
            cbo_motivo.DataSource = Helper.getDataView(dsmotivociq.Tables(0), "nm_motivo_responsavel_ciq")
            cbo_motivo.DataTextField = "nm_motivo_responsavel_ciq"
            cbo_motivo.DataValueField = "id_motivo_responsavel_ciq"
            cbo_motivo.DataBind()
            cbo_motivo.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ViewState.Item("txt_dt_hora_entrada_fim") = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            ViewState.Item("txt_dt_hora_entrada_ini") = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(ViewState.Item("txt_dt_hora_entrada_fim")))

            txt_dt_hora_entrada_ini.Text = DateTime.Parse(ViewState.Item("txt_dt_hora_entrada_ini").ToString).ToString("dd/MM/yyyy")
            txt_dt_hora_entrada_fim.Text = DateTime.Parse(ViewState.Item("txt_dt_hora_entrada_fim").ToString).ToString("dd/MM/yyyy")

            ViewState.Item("sortExpression") = "id_romaneio desc, id_romaneio_compartimento"
            ViewState.Item("sortExpressionDet") = "nm_pessoa"
            ViewState.Item("caminho_servidor") = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean

    '    If Not (customPage.getFilterValue("linha_conciliacao", cbo_estabelecimento.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_estabelecimento") = customPage.getFilterValue("linha_conciliacao", cbo_estabelecimento.ID)
    '        Me.cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
    '    Else
    '        ViewState.Item("id_estabelecimento") = String.Empty
    '    End If


    '    If Not (customPage.getFilterValue("linha_conciliacao", txt_dt_hora_entrada_ini.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("txt_dt_hora_entrada_ini") = customPage.getFilterValue("linha_conciliacao", txt_dt_hora_entrada_ini.ID)
    '        txt_dt_hora_entrada_ini.Text = ViewState.Item("txt_dt_hora_entrada_ini").ToString()
    '    Else
    '        ViewState.Item("txt_dt_hora_entrada_ini") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("linha_conciliacao", txt_dt_hora_entrada_ini.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("txt_dt_hora_entrada_fim") = customPage.getFilterValue("linha_conciliacao", txt_dt_hora_entrada_fim.ID)
    '        txt_dt_hora_entrada_fim.Text = ViewState.Item("txt_dt_hora_entrada_fim").ToString()
    '    Else
    '        ViewState.Item("txt_dt_hora_entrada_fim") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("linha_conciliacao", txt_id_romaneio.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_romaneio") = customPage.getFilterValue("linha_conciliacao", txt_id_romaneio.ID)
    '        txt_id_romaneio.Text = ViewState.Item("id_romaneio").ToString()
    '    Else
    '        ViewState.Item("id_romaneio") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("linha_conciliacao", txt_rota.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("txt_rota") = customPage.getFilterValue("linha_conciliacao", txt_rota.ID)
    '        txt_rota.Text = ViewState.Item("txt_rota").ToString()
    '    Else
    '        ViewState.Item("txt_rota") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("linha_conciliacao", cbo_tipo_romaneio.ID).Equals(String.Empty)) Then
    '        'hasFilters = True
    '        ViewState.Item("cbo_tipo_romaneio") = customPage.getFilterValue("linha_conciliacao", cbo_tipo_romaneio.ID)
    '        cbo_tipo_romaneio.SelectedValue = ViewState.Item("cbo_tipo_romaneio").ToString()
    '        If CInt(cbo_tipo_romaneio.SelectedValue) <> 1 Then 'se nao for romaneio
    '            If Not (customPage.getFilterValue("linha_conciliacao", txt_id_transit_point.ID).Equals(String.Empty)) Then
    '                ViewState.Item("id_romaneio_tp_transb") = customPage.getFilterValue("linha_conciliacao", txt_id_transit_point.ID)
    '            Else
    '                ViewState.Item("id_romaneio_tp_transb") = String.Empty
    '            End If

    '            txt_id_transit_point.Visible = True
    '            txt_id_transit_point.Text = ViewState.Item("id_romaneio_tp_transb").ToString()

    '            If CInt(cbo_tipo_romaneio.SelectedValue) >= 4 Then 'se  for romaneio transit
    '                lbl_romaneio_tp_transb.Text = "Romaneio Transit"
    '            Else
    '                lbl_romaneio_tp_transb.Text = "Romaneio Transb."
    '            End If
    '        Else
    '            ViewState.Item("id_romaneio_tp_transb") = String.Empty
    '            lbl_romaneio_tp_transb.Text = String.Empty
    '            txt_id_transit_point.Text = String.Empty
    '            txt_id_transit_point.Visible = False
    '        End If

    '    Else
    '        ViewState.Item("cbo_tipo_romaneio") = String.Empty
    '        ViewState.Item("id_romaneio_tp_transb") = String.Empty
    '    End If


    '    If Not (customPage.getFilterValue("linha_conciliacao", cbo_divergencias.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_divergencia_km_frete") = customPage.getFilterValue("linha_conciliacao", cbo_divergencias.ID)
    '        cbo_divergencias.SelectedValue = ViewState.Item("id_divergencia_km_frete").ToString()
    '    Else
    '        ViewState.Item("id_divergencia_km_frete") = 0
    '    End If

    '    If Not (customPage.getFilterValue("linha_conciliacao", cbo_aprovacao_km_frete.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_aprovacao_km_frete") = customPage.getFilterValue("linha_conciliacao", cbo_aprovacao_km_frete.ID)
    '        cbo_aprovacao_km_frete.SelectedValue = ViewState.Item("id_aprovacao_km_frete").ToString()
    '    Else
    '        ViewState.Item("id_aprovacao_km_frete") = 0
    '    End If

    '    If Not (customPage.getFilterValue("linha_conciliacao", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("linha_conciliacao", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("linha_conciliacao")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio

            romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            romaneio.data_inicio = ViewState.Item("txt_dt_hora_entrada_ini").ToString
            romaneio.data_fim = ViewState.Item("txt_dt_hora_entrada_fim").ToString

            If Trim(ViewState.Item("id_romaneio")) <> "" Then
                romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            End If

            romaneio.nm_linha = ViewState.Item("nm_linha").ToString

            If Trim(ViewState.Item("id_romaneio_compartimento")) <> "" Then
                romaneio.id_romaneio_compartimento = ViewState.Item("id_romaneio_compartimento").ToString
            End If

            Dim dsromaneiociq As DataSet
            If ViewState.Item("emitente") = "P" Then
                dsromaneiociq = romaneio.getRomaneioCIQP
            Else
                dsromaneiociq = romaneio.getRomaneioCIQ

            End If

            If (dsromaneiociq.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsromaneiociq.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

                If ViewState.Item("emitente") = "P" Then
                    gridResults.HeaderRow.Cells(2).Text = "Rota"
                Else
                    gridResults.HeaderRow.Cells(2).Text = "Cooperativa"

                End If

            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
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


            Case "id_romaneio"
                If (ViewState.Item("sortExpression")) = "id_romaneio asc" Then
                    ViewState.Item("sortExpression") = "id_romaneio desc"
                Else
                    ViewState.Item("sortExpression") = "id_romaneio asc"
                End If


            Case "dt_hora_entrada"
                If (ViewState.Item("sortExpression")) = "dt_hora_entrada asc" Then
                    ViewState.Item("sortExpression") = "dt_hora_entrada desc"
                Else
                    ViewState.Item("sortExpression") = "dt_hora_entrada asc"
                End If

            Case "nm_linha"
                If (ViewState.Item("sortExpression")) = "nm_linha asc" Then
                    ViewState.Item("sortExpression") = "nm_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nm_linha asc"
                End If



        End Select

        loadData()

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "viewdetalheromaneio"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
                Dim lbl_id_transit_point As Label = CType(row.FindControl("lbl_id_transit_point"), Label) '
                Dim lbl_id_transvase As Label = CType(row.FindControl("lbl_id_transvase"), Label) '
                Dim lbl_st_romaneio_transbordo As Label = CType(row.FindControl("lbl_st_romaneio_transbordo"), Label)
                Dim lbl_nr_caderneta As Label = CType(row.FindControl("lbl_nr_caderneta"), Label)
                Dim lbl_id_romaneio As Label = CType(row.FindControl("lbl_id_romaneio"), Label) '
                Dim lbl_id_cooperativa As Label = CType(row.FindControl("lbl_id_cooperativa"), Label) '
                Dim lbl_id_transportador As Label = CType(row.FindControl("lbl_id_transportador"), Label) '
                Dim lbl_peso_liquido As Label = CType(row.FindControl("lbl_peso_liquido"), Label)
                Dim lbl_situacao As Label = CType(row.FindControl("lbl_situacao"), Label)
                Dim lbl_transportador As Label = CType(row.FindControl("lbl_transportador"), Label)
                Dim lbl_id_st_romaneio As Label = CType(row.FindControl("lbl_id_st_romaneio"), Label)
                Dim lbl_st_responsavel_ciq As Label = CType(row.FindControl("lbl_st_responsavel_ciq"), Label)
                ViewState.Item("id_romaneio_compartimento_detalhe") = Convert.ToInt32(e.CommandArgument.ToString())
                ViewState.Item("id_romaneio_detalhe") = Convert.ToInt32(lbl_id_romaneio.Text)
                ViewState.Item("id_st_romaneio_detalhe") = lbl_id_st_romaneio.Text
                ViewState.Item("transportador_detalhe") = lbl_transportador.Text
                ViewState.Item("st_responsavel_ciq_detalhe") = lbl_st_responsavel_ciq.Text
                ViewState.Item("id_cooperativa_detalhe") = Convert.ToInt32(lbl_id_cooperativa.Text)
                ViewState.Item("id_transportador_detalhe") = Convert.ToInt32(lbl_id_transportador.Text)

                Dim ltransitpoint As Integer = 0
                Dim ltransvase As Integer = 0
                Dim lcaderneta As Integer = 0
                If Not lbl_id_transit_point.Text.Equals(String.Empty) Then
                    ltransitpoint = CInt(lbl_id_transit_point.Text)
                End If
                If Not lbl_id_transvase.Text.Equals(String.Empty) Then
                    ltransvase = CInt(lbl_id_transvase.Text)
                End If

                If Not lbl_nr_caderneta.Text.Equals(String.Empty) Then
                    lcaderneta = CInt(lbl_nr_caderneta.Text)
                End If

                loadDetalheRomaneio(lbl_transportador.Text, ltransitpoint, ltransvase, lbl_st_romaneio_transbordo.Text, lcaderneta, CDec(lbl_peso_liquido.Text), lbl_situacao.Text, row.Cells(17).Text, row.Cells(4).Text)
                loadData()
        End Select

    End Sub
    Private Sub loadDetalheRomaneio(ByVal ptransportador As String, ByVal pid_transit_point As Int32, ByVal pid_transvase As Int32, ByVal pst_romaneio_transbordo As String, ByVal pnr_caderneta As Int32, ByVal pnr_peso_liquido_romaneio As Decimal, ByVal psituacao_romaneio As String, ByVal pnr_nota As String, ByVal pdtentrada As String)

        Try
            Dim romaneiocomp As New Romaneio_Compartimento
            romaneiocomp.id_romaneio_compartimento = ViewState.Item("id_romaneio_compartimento_detalhe")

            Dim dsRomaneioCompDetalhes As DataSet = romaneiocomp.getRomaneio_CompartimentoByFilters

            ViewState.Item("produtorrejeitado") = "N"

            'se fot boa esperanca é pre romaneio
            If cbo_estabelecimento.SelectedValue = 77 Then
                lbl_romaneio.Text = "Pré Romaneio:"
            Else
                lbl_romaneio.Text = "Romaneio:"
            End If

            lbl_id_romaneio.Text = ViewState.Item("id_romaneio_detalhe").ToString
            lbl_caderneta.Text = String.Concat("Caderneta: ", pnr_caderneta.ToString)
            lbl_nr_peso_liquido.Text = String.Concat("Peso Líquido: ", pnr_peso_liquido_romaneio.ToString)
            lbl_situacao.Text = psituacao_romaneio.ToString

            'Se romaneio de transit point
            If pid_transit_point > 0 Then
                lbl_transit.Text = String.Concat("Transit Point: ", pid_transit_point.ToString)
                lbl_caderneta.Text = String.Empty
            Else
                If pid_transvase > 0 Then
                    lbl_transit.Text = String.Concat("Transvase: ", pid_transvase.ToString)
                    lbl_caderneta.Text = String.Empty
                Else
                    lbl_transit.Text = String.Empty
                End If
            End If
            'Se romaneio transbordo
            If pst_romaneio_transbordo = "S" Then
                lbl_transbordo.Text = "Transbordo: SIM"
                lbl_caderneta.Text = String.Empty
            Else
                lbl_transbordo.Text = "Transbordo: NÃO"
            End If

            lbl_transportador.Text = ptransportador.ToString
            lbl_nr_ciq.Text = String.Concat("Nr CIQ: ", ViewState.Item("id_romaneio_compartimento_detalhe").ToString)
            pnl_romaneio.Visible = True
            btn_atualizar_resp.Visible = True
            lbl_resp.Visible = True
            lbl_motivo.Visible = True
            lbl_obs.Visible = True
            cbo_responsavel.Visible = True
            cbo_motivo.Visible = True
            txt_obs_resp.Visible = True

            If ViewState.Item("emitente").Equals("P") Then
                cbo_responsavel.Items.FindByValue("P").Enabled = True
                cbo_responsavel.Items.FindByValue("C").Enabled = False
                cbo_responsavel.Items.FindByValue("N").Enabled = True

                If dsRomaneioCompDetalhes.Tables(0).Rows(0).Item("st_responsavel_ciq").ToString.Equals(String.Empty) Then
                    cbo_responsavel.SelectedValue = "N"
                Else
                    cbo_responsavel.SelectedValue = dsRomaneioCompDetalhes.Tables(0).Rows(0).Item("st_responsavel_ciq").ToString

                End If

            Else
                cbo_responsavel.Items.FindByValue("P").Enabled = False
                cbo_responsavel.Items.FindByValue("C").Enabled = True
                cbo_responsavel.Items.FindByValue("N").Enabled = False 'se cooperativa não tem opçao sem responsavel

                If dsRomaneioCompDetalhes.Tables(0).Rows(0).Item("st_responsavel_ciq").ToString.Equals(String.Empty) Then
                    cbo_responsavel.SelectedValue = "C"
                Else
                    cbo_responsavel.SelectedValue = dsRomaneioCompDetalhes.Tables(0).Rows(0).Item("st_responsavel_ciq").ToString

                End If

            End If

            lbl_placa_compartimento.Text = dsRomaneioCompDetalhes.Tables(0).Rows(0).Item("ds_placa_compartimento")
            cbo_motivo.SelectedValue = dsRomaneioCompDetalhes.Tables(0).Rows(0).Item("id_motivo_responsavel_ciq")
            txt_obs_resp.Text = dsRomaneioCompDetalhes.Tables(0).Rows(0).Item("ds_motivo_responsavel_ciq")
            'ViewState.Item("st_primeiro_responsavel_ciq_detalhe") = dsRomaneioCompDetalhes.Tables(0).Rows(0).Item("st_primeiro_responsavel_ciq")

            If Not cbo_responsavel.SelectedValue.Equals("N") Then
                cbo_responsavel.Items.FindByValue("N").Enabled = False 'nao deixa selecionar sem responsavel se ja tem responsavel
            End If

            'atualizar botao imprimir e email do CIQ
            Me.hl_imprimir_ciq.NavigateUrl = String.Format("frm_relatorio_CIQ.aspx?id_romaneio_compartimento={0}", ViewState.Item("id_romaneio_compartimento_detalhe").ToString)

            Select Case ViewState.Item("st_responsavel_ciq_detalhe").ToString

                'Case "P"
                '    hl_imprimir_ciqt.ImageUrl = "~/img/ic_impressao_desabilitado.gif"
                '    hl_imprimir_ciqt.Enabled = False
                '    hl_imprimir_ciqt.Visible = False
                '    btn_email_ciqt.ImageUrl = "~/img/ico_email_desabilitado.gif"
                '    btn_email_ciqt.Enabled = False
                '    btn_email_ciqt.Visible = False
                '    hl_imprimir_ciqr.ImageUrl = "~/img/ic_impressao_desabilitado.gif"
                '    hl_imprimir_ciqr.Enabled = False
                '    hl_imprimir_ciqr.Visible = False
                '    btn_email_ciqr.ImageUrl = "~/img/ico_email_desabilitado.gif"
                '    btn_email_ciqr.Enabled = False
                '    btn_email_ciqr.Visible = False
                Case "R" 'recepção
                    hl_imprimir_ciqt.ImageUrl = "~/img/ic_impressao_desabilitado.gif"
                    hl_imprimir_ciqt.Enabled = False
                    hl_imprimir_ciqt.Visible = False
                    btn_email_ciqt.ImageUrl = "~/img/ico_email_desabilitado.gif"
                    btn_email_ciqt.Enabled = False
                    btn_email_ciqt.Visible = False
                    hl_imprimir_ciqr.ImageUrl = "~/img/ic_impressao.gif"
                    hl_imprimir_ciqr.Enabled = True
                    hl_imprimir_ciqr.Visible = True
                    btn_email_ciqr.ImageUrl = "~/img/ico_email.gif"
                    btn_email_ciqr.Enabled = True
                    btn_email_ciqr.Visible = True

                    Me.hl_imprimir_ciqr.NavigateUrl = String.Format("frm_relatorio_CIQR.aspx?id_romaneio_compartimento={0}", ViewState.Item("id_romaneio_compartimento_detalhe").ToString)
                    'Case "C" 'cooperativa
                    '    hl_imprimir_resp.Enabled = False
                    '    hl_imprimir_resp.Visible = True
                    '    hl_imprimir_resp.ImageUrl = "~/img/ic_impressao_desabilitado.gif"
                    '    Me.hl_imprimir_resp.NavigateUrl = String.Format("frm_relatorio_CIQC.aspx?id_romaneio_compartimento={0}", ViewState.Item("id_romaneio_compartimento_detalhe").ToString)
                    '    hl_imprimir_resp.ToolTip = "Relatório CIQC:  Versão para Imprimir."
                    '    lbl_ciqresp.Text = "CIQC "
                    '    btn_email_resp.ImageUrl = "~/img/ico_email.gif"
                    '    btn_email_resp.Enabled = True
                    '    btn_email_resp.Visible = True
                    '    hl_imprimir_resp.ToolTip = "Relatório CIQC: Enviar E-mail."
                Case "T" 'transportador
                    hl_imprimir_ciqr.ImageUrl = "~/img/ic_impressao_desabilitado.gif"
                    hl_imprimir_ciqr.Enabled = False
                    hl_imprimir_ciqr.Visible = False
                    btn_email_ciqr.ImageUrl = "~/img/ico_email_desabilitado.gif"
                    btn_email_ciqr.Enabled = False
                    btn_email_ciqr.Visible = False
                    hl_imprimir_ciqt.ImageUrl = "~/img/ic_impressao.gif"
                    hl_imprimir_ciqt.Enabled = True
                    hl_imprimir_ciqt.Visible = True
                    btn_email_ciqt.ImageUrl = "~/img/ico_email.gif"
                    btn_email_ciqt.Enabled = True
                    btn_email_ciqt.Visible = True

                    Me.hl_imprimir_ciqt.NavigateUrl = String.Format("frm_relatorio_CIQT.aspx?id_romaneio_compartimento={0}", ViewState.Item("id_romaneio_compartimento_detalhe").ToString)

                Case Else
                    hl_imprimir_ciqt.ImageUrl = "~/img/ic_impressao_desabilitado.gif"
                    hl_imprimir_ciqt.Enabled = False
                    hl_imprimir_ciqt.Visible = False
                    btn_email_ciqt.ImageUrl = "~/img/ico_email_desabilitado.gif"
                    btn_email_ciqt.Enabled = False
                    btn_email_ciqt.Visible = False
                    hl_imprimir_ciqr.ImageUrl = "~/img/ic_impressao_desabilitado.gif"
                    hl_imprimir_ciqr.Enabled = False
                    hl_imprimir_ciqr.Visible = False
                    btn_email_ciqr.ImageUrl = "~/img/ico_email_desabilitado.gif"
                    btn_email_ciqr.Enabled = False
                    btn_email_ciqr.Visible = False

            End Select


            ViewState.Item("calculado_detalhe") = ""
            lbl_calculado.Text = String.Empty
            If ViewState.Item("emitente").Equals("P") Then
                gridProdutor.Visible = True

                If cbo_estabelecimento.SelectedValue = 77 Then
                    Dim romaneio As New Romaneio
                    romaneio.id_romaneio = ViewState.Item("id_romaneio_detalhe").ToString
                    Dim dsromaneiocalculado As DataSet = romaneio.getPreRomaneioRejeitadoCalculado
                    If dsromaneiocalculado.Tables(0).Rows.Count > 0 Then
                        'se leite pago na referencia
                        If dsromaneiocalculado.Tables(0).Rows(0).Item("st_leite_pago_referencia").ToString = "S" Then
                            ViewState.Item("calculado_detalhe") = "S"
                            lbl_calculado.Text = "Pré Romaneio Calculado"

                        Else
                            'se esta como leite nao pago verifica a referencia
                            If CDate(DateTime.Parse(dsromaneiocalculado.Tables(0).Rows(0).Item("dt_referencia")).ToString("dd/MM/yyyy")) < CDate(DateTime.Parse(dsromaneiocalculado.Tables(0).Rows(0).Item("ultima_referencia")).ToString("dd/MM/yyyy")) Then
                                ViewState.Item("calculado_detalhe") = "S"
                                lbl_calculado.Text = "Pré Romaneio Calculado"
                            Else
                                ViewState.Item("calculado_detalhe") = "N"
                                lbl_calculado.Text = "Pré Romaneio Não Calculado"
                            End If

                        End If
                    Else
                        ViewState.Item("calculado_detalhe") = "N"
                        lbl_calculado.Text = "Pré Romaneio Não Calculado"
                    End If
                Else
                    'se romaneio fechado
                    If ViewState.Item("id_st_romaneio_detalhe").ToString.Equals("4") Then
                        Dim romaneio As New Romaneio
                        romaneio.id_romaneio = ViewState.Item("id_romaneio_detalhe").ToString
                        Dim dsromaneiocalculado As DataSet = romaneio.getRomaneioCalculado
                        If dsromaneiocalculado.Tables(0).Rows.Count > 0 Then
                            'se leite pago na referencia
                            If dsromaneiocalculado.Tables(0).Rows(0).Item("st_leite_pago_referencia").ToString = "S" Then
                                ViewState.Item("calculado_detalhe") = "S"
                                lbl_calculado.Text = "Romaneio Calculado"

                            Else
                                'se esta como leite nao pago verifica a referencia
                                If CDate(DateTime.Parse(dsromaneiocalculado.Tables(0).Rows(0).Item("dt_referencia")).ToString("dd/MM/yyyy")) < CDate(DateTime.Parse(dsromaneiocalculado.Tables(0).Rows(0).Item("ultima_referencia")).ToString("dd/MM/yyyy")) Then
                                    ViewState.Item("calculado_detalhe") = "S"
                                    lbl_calculado.Text = "Romaneio Calculado"
                                Else
                                    ViewState.Item("calculado_detalhe") = "N"
                                    lbl_calculado.Text = "Romaneio Não Calculado"
                                End If

                            End If
                        Else
                            ViewState.Item("calculado_detalhe") = "N"
                            lbl_calculado.Text = "Romaneio Não Calculado"
                        End If
                    Else
                        'se outra situacao romaneio
                        ViewState.Item("calculado_detalhe") = "N"
                        lbl_calculado.Text = "Romaneio Não Calculado"
                    End If
                End If

                Dim romaneiouproducao As New Romaneio_Comp_UProducao

                romaneiouproducao.id_romaneio_compartimento = romaneiocomp.id_romaneio_compartimento
                Dim dsuproducao As DataSet = romaneiouproducao.getRomaneio_Comp_UProducaoByFilters

                If dsuproducao.Tables(0).Rows.Count > 0 Then
                    ViewState.Item("produtorrejeitado") = "N"
                    gridProdutor.DataSource = Helper.getDataView(dsuproducao.Tables(0), ViewState.Item("sortExpressionDet"))
                    gridProdutor.DataBind()

                End If
                If ViewState.Item("calculado_detalhe") = "S" Then
                    cbo_responsavel.Enabled = False
                    cbo_motivo.Enabled = False
                    txt_obs_resp.Enabled = False
                    btn_atualizar_resp.Enabled = False
                    btn_atualizar_resp.ToolTip = "Não é possível atualizar responsável CIQ. Romaneio já foi calculado em definitivo."

                End If
            Else
                'se é cooperativa
                gridProdutor.Visible = False
                lbl_calculado.Text = String.Empty


                lbl_id_romaneio.Text = ViewState.Item("id_romaneio_detalhe").ToString
                lbl_caderneta.Text = String.Concat("Nr. Nota: ", pnr_nota.ToString)
                lbl_nr_peso_liquido.Text = String.Concat("Peso Líquido Nota: ", pnr_peso_liquido_romaneio.ToString)
                lbl_situacao.Text = psituacao_romaneio.ToString
                lbl_transit.Text = String.Empty
                lbl_transbordo.Text = String.Empty

                If Month(CDate(pdtentrada)) = Month(CDate(DateTime.Parse(Now).ToString("dd/MM/yyyy"))) Then
                    ViewState.Item("calculado_detalhe") = "N"
                Else
                    ViewState.Item("calculado_detalhe") = "S"
                    cbo_responsavel.Enabled = False
                    cbo_motivo.Enabled = False
                    txt_obs_resp.Enabled = False
                    btn_atualizar_resp.Enabled = False
                    btn_atualizar_resp.ToolTip = "Não é possível atualizar responsável CIQ. A referência da nota é diferente da referência atual."

                End If

            End If

            If ViewState.Item("calculado_detalhe") = "N" Then
                cbo_responsavel.Enabled = True
                cbo_motivo.Enabled = True
                txt_obs_resp.Enabled = True
                btn_atualizar_resp.Enabled = True
                btn_atualizar_resp.ToolTip = "Atualizar Responsável CIQ"

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            'se o romaneio clicado para consistencia é igual ao montado, troca cor de fi=undo
            If ViewState.Item("id_romaneio_compartimento_detalhe") > 0 AndAlso ViewState.Item("id_romaneio_compartimento_detalhe").ToString = (gridResults.DataKeys.Item(e.Row.RowIndex).Value).ToString Then
                e.Row.ForeColor = Drawing.Color.Red
                e.Row.Font.Size = FontUnit.XSmall

            End If

            Select Case e.Row.Cells(9).Text.Trim
                Case "P"
                    e.Row.Cells(9).Text = "Produtor"
                Case "C"
                    e.Row.Cells(9).Text = "Cooperativa"

                Case "T"
                    e.Row.Cells(9).Text = "Transportador"

                Case "R"
                    e.Row.Cells(9).Text = "Recepção"

                Case "N"
                    e.Row.Cells(9).Text = "Sem Responsável"
                    e.Row.Cells(9).BackColor = Drawing.Color.Yellow

                Case Else
                    e.Row.Cells(9).Text = "Sem Responsável"
                    e.Row.Cells(9).BackColor = Drawing.Color.Yellow

            End Select
        End If
    End Sub




    'Protected Sub btn_consistir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_consistir.Click
    '    Try

    '        Dim romaneio As New Romaneio

    '        romaneio.id_estabelecimento = cbo_estabelecimento.SelectedValue
    '        romaneio.dt_hora_entrada_ini = ViewState.Item("txt_dt_hora_entrada_ini").ToString
    '        romaneio.dt_hora_entrada_fim = ViewState.Item("txt_dt_hora_entrada_fim").ToString
    '        romaneio.id_modificador = Session("id_login")
    '        romaneio.ConsistirRomaneioRotas()

    '        messageControl.Alert("Consistências efetuadas com sucesso!")

    '        loadData()


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub btn_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aprovar.Click
    '    Try

    '        Dim romaneio As New Romaneio

    '        If saveCheckBox() = True Then
    '            'Filtro
    '            romaneio.id_estabelecimento = cbo_estabelecimento.SelectedValue
    '            romaneio.dt_hora_entrada_ini = txt_dt_hora_entrada_ini.Text
    '            romaneio.dt_hora_entrada_fim = txt_dt_hora_entrada_fim.Text
    '            romaneio.nm_linha = txt_rota.Text
    '            If Trim(Me.txt_id_romaneio.Text.Trim()) <> "" Then
    '                romaneio.id_romaneio = Convert.ToInt32(Me.txt_id_romaneio.Text.Trim())
    '            End If
    '            romaneio.id_divergencia_km_frete = Me.cbo_divergencias.SelectedValue

    '            'Dados para o Update
    '            romaneio.id_modificador = Session("id_login")

    '            romaneio.updateRomaneioAprovarSelecionados()

    '            'FRAN 08/12/2020 i incluir log 
    '            Dim usuariolog As New UsuarioLog
    '            usuariolog.id_usuario = Session("id_login")
    '            usuariolog.ds_id_session = Session.SessionID.ToString()
    '            usuariolog.id_tipo_log = 6 'processo
    '            usuariolog.id_menu_item = 175
    '            usuariolog.ds_nm_processo = "Conciliação Rotas X Romaneio - Aprovação"
    '            usuariolog.insertUsuarioLog()
    '            'FRAN 08/12/2020  incluir log 

    '            loadData()

    '            messageControl.Alert("Romaneios Aprovados com sucesso.")
    '        Else
    '            messageControl.Alert("Nenhum item foi selecionado para ser aprovado. Por favor selecione algum romaneio.")

    '        End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub



    Protected Sub btn_fechar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_fechar.Click
        Me.pnl_romaneio.Visible = False


        ViewState.Item("id_romaneio_compartimento_detalhe") = 0
        ViewState.Item("id_romaneio_detalhe") = 0
        ViewState.Item("id_st_romaneio_detalhe") = 0
        ViewState.Item("transportador_detalhe") = String.Empty
        ViewState.Item("st_responsavel_ciq_detalhe") = String.Empty
        ViewState.Item("id_cooperativa_detalhe") = 0
        ViewState.Item("id_transportador_detalhe") = 0

        pnl_romaneio.Visible = False
        gridProdutor.Visible = False


        'btn_atualizar_resp.Visible = True
        'lbl_resp.Visible = True
        'lbl_motivo.Visible = True
        'lbl_obs.Visible = True
        'cbo_responsavel.Visible = True
        'cbo_motivo.Visible = True
        'txt_obs_resp.Visible = True

        loadData()
    End Sub

    Protected Sub gridProdutor_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridProdutor.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "EmailCIQP"
                If Page.IsValid = True Then
                    Try

                        Dim wc As WebControl = CType(e.CommandSource, WebControl)
                        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
                        Dim lbl_id_tecnico As Label = CType(row.FindControl("lbl_id_tecnico"), Label) '

                        Dim notificacao As New Notificacao
                        Dim lAssunto As String = "RELATÓRIO CIQP " & e.CommandArgument.ToString
                        Dim lCorpo As String = "Existe uma ocorrência ao produtor relatada através do Relatório CIQP, que pode ser visualizado pelo link " & ViewState.Item("caminho_servidor") & "/frm_relatorio_CIQP.aspx?id_romaneio_uproducao=" & e.CommandArgument.ToString & " ."

                        Dim email_tecnico As String
                        email_tecnico = ""


                        If Not lbl_id_tecnico.Text.Trim.Equals(String.Empty) AndAlso CInt(lbl_id_tecnico.Text.Trim) > 0 Then
                            Dim tecnico As New Tecnico(Convert.ToInt32(lbl_id_tecnico.Text.Trim))
                            email_tecnico = tecnico.ds_email
                        End If

                        If notificacao.enviaMensagemEmail(2, lAssunto, lCorpo, MailPriority.High, email_tecnico, , 1) = True Then
                            messageControl.Alert("O Relatório CIQP foi enviado aos destinatários cadastrados com sucesso!")
                        Else

                            messageControl.Alert("O Relatório CIQP não pode ser enviado pois não há emails cadastrados para este relatório.")

                        End If
                    Catch ex As Exception
                        messageControl.Alert(ex.Message)
                    End Try


                End If

        End Select

    End Sub

    'Protected Sub btn_nao_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nao_aprovar.Click
    '    Try
    '        Dim romaneio As New Romaneio

    '        If saveCheckBox() = True Then
    '            'Filtro
    '            romaneio.id_estabelecimento = cbo_estabelecimento.SelectedValue
    '            romaneio.dt_hora_entrada_ini = txt_dt_hora_entrada_ini.Text
    '            romaneio.dt_hora_entrada_fim = txt_dt_hora_entrada_fim.Text
    '            romaneio.nm_linha = txt_rota.Text
    '            If Trim(Me.txt_id_romaneio.Text.Trim()) <> "" Then
    '                romaneio.id_romaneio = Convert.ToInt32(Me.txt_id_romaneio.Text.Trim())
    '            End If
    '            'romaneio.id_divergencia_km_frete = Me.cbo_divergencias.SelectedValue

    '            'Dados para o Update
    '            romaneio.id_modificador = Session("id_login")

    '            romaneio.updateRomaneioNaoAprovarSelecionados()
    '            'FRAN 08/12/2020 i incluir log 
    '            Dim usuariolog As New UsuarioLog
    '            usuariolog.id_usuario = Session("id_login")
    '            usuariolog.ds_id_session = Session.SessionID.ToString()
    '            usuariolog.id_tipo_log = 6 'processo
    '            usuariolog.id_menu_item = 175
    '            usuariolog.ds_nm_processo = "Conciliação Rotas X Romaneio - Reprovação"
    '            usuariolog.insertUsuarioLog()
    '            'FRAN 08/12/2020  incluir log 

    '            loadData()

    '            messageControl.Alert("Romaneios Não Aprovados com sucesso.")
    '        Else
    '            messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione algum romaneio.")

    '        End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub btn_Cancelar_aprovacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Cancelar_aprovacao.Click
    '    Try
    '        Dim analiseesalq As New AnaliseEsalq


    '        Dim romaneio As New Romaneio

    '        If saveCheckBox() = True Then
    '            'Filtro
    '            romaneio.id_estabelecimento = cbo_estabelecimento.SelectedValue
    '            romaneio.dt_hora_entrada_ini = txt_dt_hora_entrada_ini.Text
    '            romaneio.dt_hora_entrada_fim = txt_dt_hora_entrada_fim.Text
    '            romaneio.nm_linha = txt_rota.Text
    '            If Trim(Me.txt_id_romaneio.Text.Trim()) <> "" Then
    '                romaneio.id_romaneio = Convert.ToInt32(Me.txt_id_romaneio.Text.Trim())
    '            End If
    '            'romaneio.id_divergencia_km_frete = Me.cbo_divergencias.SelectedValue

    '            'Dados para o Update
    '            romaneio.id_modificador = Session("id_login")

    '            romaneio.updateRomaneioAprovacaoCancelarSelecionados()
    '            'FRAN 08/12/2020 i incluir log 
    '            Dim usuariolog As New UsuarioLog
    '            usuariolog.id_usuario = Session("id_login")
    '            usuariolog.ds_id_session = Session.SessionID.ToString()
    '            usuariolog.id_tipo_log = 6 'processo
    '            usuariolog.id_menu_item = 175
    '            usuariolog.ds_nm_processo = "Conciliação Rotas X Romaneio - Cancelar Aprovação"
    '            usuariolog.insertUsuarioLog()
    '            'FRAN 08/12/2020  incluir log 

    '            loadData()

    '            messageControl.Alert("Romaneios Aprovados/Não Aprovados cancelados com sucesso.")
    '        Else
    '            messageControl.Alert("Nenhum item foi selecionado para ser cancelar aprovação/não aprovação. Por favor selecione algum romaneio.")

    '        End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub



    Protected Sub gridProdutor_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridProdutor.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_id_status_analise_uproducao As Label = CType(e.Row.FindControl("lbl_id_status_analise_uproducao"), Label)
            Dim lbl_nr_unid_producao As Label = CType(e.Row.FindControl("lbl_nr_unid_producao"), Label)
            Dim hl_imprimir_ciqp As Anthem.HyperLink = CType(e.Row.FindControl("hl_imprimir_ciqp"), Anthem.HyperLink)
            Dim btn_email As ImageButton = CType(e.Row.FindControl("btn_email"), ImageButton)

            e.Row.Cells(1).Text = String.Concat(e.Row.Cells(1).Text.Trim, "-", lbl_nr_unid_producao.Text)

            'se a situação da analise u producao rejeitada
            If lbl_id_status_analise_uproducao.Text.Trim.Equals("3") Then

                e.Row.ForeColor = Drawing.Color.Red
                ViewState.Item("produtorrejeitado") = "S"

                If ViewState.Item("st_responsavel_ciq_detalhe") = "P" Then
                    hl_imprimir_ciqp.Enabled = True
                    hl_imprimir_ciqp.ImageUrl = "~/img/ic_impressao.gif"
                    hl_imprimir_ciqp.NavigateUrl = String.Format("frm_relatorio_CIQP.aspx?id_romaneio_uproducao={0}", gridProdutor.DataKeys.Item(e.Row.RowIndex).Value)
                    btn_email.Enabled = True
                    btn_email.ImageUrl = "~/img/ico_email.gif"
                End If
            Else
                hl_imprimir_ciqp.Visible = False
                btn_email.Visible = False

            End If


        End If

    End Sub



    Protected Sub btn_atualizar_resp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_atualizar_resp.Click
        If Page.IsValid = True Then
            Try

                Dim romcompciq As New Romaneio_Compartimento

                romcompciq.st_responsavel_ciq = cbo_responsavel.SelectedValue
                romcompciq.id_motivo_responsavel_ciq = cbo_motivo.SelectedValue
                romcompciq.ds_motivo_responsavel_ciq = txt_obs_resp.Text
                romcompciq.id_modificador = Session("id_login")
                romcompciq.id_romaneio_compartimento = ViewState.Item("id_romaneio_compartimento_detalhe")
                romcompciq.id_romaneio = ViewState.Item("id_romaneio_detalhe")
                romcompciq.st_emitente = ViewState.Item("emitente").ToString
                romcompciq.st_atualizar_produtor = "N" 'assume que não vai atualizar dados do produtor (mapa de leite e contas parceladas)

                'se emitente é produtor
                If romcompciq.st_emitente = "P" Then
                    'se responsavel pelo ciq é o Produtor
                    If romcompciq.st_responsavel_ciq = "P" Then
                        'se o responsavel no banco é PRODUTOR, não precisa atualizar mapa de leite e contas parceladas
                        If ViewState.Item("st_responsavel_ciq_detalhe").ToString = "P" Then
                            romcompciq.st_atualizar_produtor = "N"
                        Else
                            'se esta reapontando o produtor como responsavel e o ultimo responsavel (o do banco) não era o produtor
                            romcompciq.st_atualizar_produtor = "S"
                            romcompciq.st_mudanca_responsavel_ciq = "N" 'indica que a mudanca de responsavel retornara para o default sistema PRODUTOR
                        End If
                    Else 'se foi apontado na tela responsavel pelo ciq dieferente de produtor

                        'se o responsavel no banco é Produtor entao deve atualizar os dados de produtor para retirar a responsabilidade do PRODUTOR
                        If ViewState.Item("st_responsavel_ciq_detalhe").ToString = "P" Then
                            romcompciq.st_atualizar_produtor = "S"
                            romcompciq.st_mudanca_responsavel_ciq = "S" 'indica que esta mudando responsavel default do sistema (produtor)
                        Else
                            'se esta reapontando o produtor como responsavel e o ultimo responsavel (o do banco) não era o produtor
                            romcompciq.st_atualizar_produtor = "N"
                        End If

                    End If
                End If

                romcompciq.AtualizarResponsavelCIQ()
                ViewState.Item("st_responsavel_ciq_detalhe") = romcompciq.st_responsavel_ciq 'atualiza a variavel que indica o responsavel que esta no banco
                loadData()

                If romcompciq.st_emitente = "P" Then

                    Dim romaneiouproducao As New Romaneio_Comp_UProducao

                    romaneiouproducao.id_romaneio_compartimento = romcompciq.id_romaneio_compartimento
                    Dim dsuproducao As DataSet = romaneiouproducao.getRomaneio_Comp_UProducaoByFilters

                    If dsuproducao.Tables(0).Rows.Count > 0 Then
                        ViewState.Item("produtorrejeitado") = "N"
                        gridProdutor.DataSource = Helper.getDataView(dsuproducao.Tables(0), ViewState.Item("sortExpressionDet"))
                        gridProdutor.DataBind()

                    End If
                End If

                messageControl.Alert("Atualização do Responsável pelo Incidente de Qualidade realizada com sucesso.")

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If



    End Sub

    Protected Sub cv_responsavel_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_responsavel.ServerValidate
        Try
            Dim lmsg As String
            args.IsValid = True

            If ViewState.Item("emitente") = "P" Then

                'se indicou responsavel produtor
                If cbo_responsavel.SelectedValue.Equals("P") Then
                    'se não existe indicação de produtor
                    If ViewState.Item("produtorrejeitado") = "N" Then
                        lmsg = "Para responsabilizar Produtor pelo CIQ, algum produtor deve ter análise registrada como rejeitada."
                        args.IsValid = False
                    End If

                End If


            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cbo_responsavel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_responsavel.SelectedIndexChanged
        cbo_motivo.SelectedValue = 0
        txt_obs_resp.Text = String.Empty
    End Sub

    Protected Sub btn_email_ciq_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_email_ciq.Click
        If Page.IsValid = True Then
            Try
                Dim notificacao As New Notificacao
                Dim lAssunto As String = "RELATÓRIO CIQ " & ViewState.Item("id_romaneio_compartimento_detalhe").ToString
                Dim lCorpo As String = "Existe uma ocorrência relatada através do Relatório CIQ, que pode ser visualizado pelo link " & ViewState.Item("caminho_servidor") & "/frm_relatorio_CIQ.aspx?id_romaneio_compartimento=" & ViewState.Item("id_romaneio_compartimento_detalhe").ToString & " ."

                If notificacao.enviaMensagemEmail(1, lAssunto, lCorpo, MailPriority.High, , , 1) = True Then
                    messageControl.Alert("O Relatório CIQ foi enviado aos destinatários cadastrados com sucesso!")
                Else
                    messageControl.Alert("O Relatório CIQ não pode ser enviado pois não há emails cadastrados para este relatório.")
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub


    Protected Sub btn_email_ciqt_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_email_ciqt.Click
        If Page.IsValid = True Then
            Try

                Dim notificacao As New Notificacao
                Dim lAssunto As String = "RELATÓRIO CIQT " & ViewState.Item("id_romaneio_compartimento_detalhe").ToString & ViewState.Item("id_transportador_detalhe").ToString
                Dim lCorpo As String = "Existe uma ocorrência ao transportador relatada através do Relatório CIQT, que pode ser visualizado pelo link " & ViewState.Item("caminho_servidor") & "/frm_relatorio_CIQT.aspx?id_romaneio_compartimento=" & ViewState.Item("id_romaneio_compartimento_detalhe").ToString & " ."


                If notificacao.enviaMensagemEmail(23, lAssunto, lCorpo, MailPriority.High, , , 1) = True Then
                    messageControl.Alert("O Relatório CIQT foi enviado aos destinatários cadastrados com sucesso!")
                Else

                    messageControl.Alert("O Relatório CIQT não pode ser enviado pois não há emails cadastrados para este relatório.")

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub btn_email_ciqr_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_email_ciqr.Click
        If Page.IsValid = True Then
            Try

                Dim notificacao As New Notificacao
                Dim lAssunto As String = "RELATÓRIO CIQR " & ViewState.Item("id_romaneio_compartimento_detalhe").ToString
                Dim lCorpo As String = "Existe uma ocorrência relatada através do Relatório CIQR, que pode ser visualizado pelo link " & ViewState.Item("caminho_servidor") & "/frm_relatorio_CIQ.aspx?id_romaneio_compartimento=" & ViewState.Item("id_romaneio_compartimento_detalhe").ToString & " ."

                If notificacao.enviaMensagemEmail(24, lAssunto, lCorpo, MailPriority.High, , , 1) = True Then
                    messageControl.Alert("O Relatório CIQR foi enviado aos destinatários cadastrados com sucesso!")
                Else
                    messageControl.Alert("O Relatório CIQR não pode ser enviado pois não há emails cadastrados para este relatório.")
                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub
End Class
