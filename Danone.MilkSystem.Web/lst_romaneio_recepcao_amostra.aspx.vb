Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_romaneio_recepcao_amostra


    Inherits Page
    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_romaneio_amostras") = 0 'limpar romaneio detalhe

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("txt_dt_hora_entrada_ini") = txt_dt_hora_entrada_ini.Text
        ViewState.Item("txt_dt_hora_entrada_fim") = txt_dt_hora_entrada_fim.Text
        ViewState.Item("id_romaneio") = txt_id_romaneio.Text
        ViewState.Item("nm_linha") = txt_rota.Text
        ViewState.Item("id_transit_point") = txt_id_transit_point.Text
        ViewState.Item("id_transvase") = txt_id_transvase.Text
        ViewState.Item("ds_placa") = txt_ds_placa.Text
        ViewState.Item("id_tipo_coleta") = cbo_tipo_coleta.SelectedValue
        ViewState.Item("cd_protocolo_filtro") = txt_protocolo.Text


        ViewState.Item("sortExpression") = "id_romaneio desc"
        ViewState.Item("sortExpressionDet") = "nr_caderneta"

        Me.pnl_amostras.Visible = False  ' Tira painel de consultas anteriores
        'limpa detalhe
        ViewState.Item("id_romaneio_detalhe") = 0
        ViewState.Item("id_transit_point_detalhe") = 0
        ViewState.Item("id_transvase_detalhe") = 0
        ViewState.Item("st_romaneio_transbordo_detalhe") = String.Empty
        ViewState.Item("nr_caderneta_detalhe") = 0
        ViewState.Item("cd_protocolo_detalhe") = String.Empty

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_recepcao_amostra.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_recepcao_amostra.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 211
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
            Dim tipocoleta As New AnaliseEsalqTipoColeta

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            cbo_tipo_coleta.DataSource = tipocoleta.getAnaliseEsalqTipoColetaByFilters()
            cbo_tipo_coleta.DataTextField = "nm_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataValueField = "id_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataBind()
            cbo_tipo_coleta.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("txt_dt_hora_entrada_fim") = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            ViewState.Item("txt_dt_hora_entrada_ini") = DateAdd(DateInterval.Day, -1, Convert.ToDateTime(ViewState.Item("txt_dt_hora_entrada_fim")))

            txt_dt_hora_entrada_ini.Text = DateTime.Parse(ViewState.Item("txt_dt_hora_entrada_ini").ToString).ToString("dd/MM/yyyy")
            txt_dt_hora_entrada_fim.Text = DateTime.Parse(ViewState.Item("txt_dt_hora_entrada_fim").ToString).ToString("dd/MM/yyyy")

            ViewState.Item("sortExpression") = "id_romaneio desc"
            ViewState.Item("sortExpressionDet") = "nr_caderneta"
            ViewState.Item("cd_protocolo_detalhe") = String.Empty


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

            romaneio.dt_hora_entrada_ini = ViewState.Item("txt_dt_hora_entrada_ini").ToString
            romaneio.dt_hora_entrada_fim = ViewState.Item("txt_dt_hora_entrada_fim").ToString

            If Trim(ViewState.Item("id_romaneio")) <> "" Then
                romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            End If
            If Trim(ViewState.Item("id_transit_point")) <> "" Then
                romaneio.id_transit_point = Convert.ToInt32(ViewState.Item("id_transit_point").ToString)
            End If
            If Trim(ViewState.Item("id_transvase")) <> "" Then
                romaneio.id_transvase = Convert.ToInt32(ViewState.Item("id_transvase").ToString)
            End If

            romaneio.nm_linha = ViewState.Item("nm_linha").ToString
            romaneio.ds_placa = ViewState.Item("ds_placa").ToString

            romaneio.id_tipo_coleta = ViewState.Item("id_tipo_coleta")
            romaneio.ds_cd_protocolo_esalq = ViewState.Item("cd_protocolo_filtro")

            Dim dsromaneioamostras As DataSet = romaneio.getRomaneioAmostrasbyFilters

            If (dsromaneioamostras.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsromaneioamostras.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
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


            Case "ds_placa"
                If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
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
                Dim lbl_st_romaneio_transbordo As Label = CType(row.FindControl("lbl_st_romaneio_transbordo"), Label)
                Dim lbl_nr_caderneta As Label = CType(row.FindControl("lbl_nr_caderneta"), Label)
                Dim lbl_id_transvase As Label = CType(row.FindControl("lbl_id_transvase"), Label) '
                ViewState.Item("id_romaneio_detalhe") = Convert.ToInt32(e.CommandArgument.ToString())
                ViewState.Item("id_transit_point_detalhe") = Convert.ToInt32(lbl_id_transit_point.Text)
                ViewState.Item("id_transvase_detalhe") = Convert.ToInt32(lbl_id_transvase.Text)
                ViewState.Item("st_romaneio_transbordo_detalhe") = lbl_st_romaneio_transbordo.Text
                ViewState.Item("nr_caderneta_detalhe") = lbl_nr_caderneta.Text

                loadDetalheRomaneio(Convert.ToInt32(e.CommandArgument.ToString()), CInt(lbl_id_transit_point.Text), CInt(lbl_id_transvase.Text), lbl_st_romaneio_transbordo.Text, lbl_nr_caderneta.Text)
                loadData()
        End Select

    End Sub
    Private Sub loadDetalheRomaneio(ByVal pid_romaneio As Int32, ByVal pid_transit_point As Int32, ByVal pid_transvase As Int32, ByVal pst_romaneio_transbordo As String, ByVal pnr_caderneta As Int32)

        Try
            Dim romaneio As New Romaneio
            romaneio.id_romaneio = pid_romaneio

            Dim dsRomaneioRotaDetalhes As DataSet

            If Not ViewState.Item("cd_protocolo_detalhe").ToString.Equals(String.Empty) Then
                romaneio.ds_cd_protocolo_esalq = ViewState.Item("cd_protocolo_detalhe").ToString
            End If


            'Se romaneio de transit point
            If pid_transit_point > 0 Then
                lbl_transit.Text = String.Concat("Transit Point: ", pid_transit_point.ToString)
                romaneio.id_transit_point = pid_transit_point

                dsRomaneioRotaDetalhes = romaneio.getRomaneioAmostraTransitPoint()
            Else
                lbl_transit.Text = String.Empty
            End If
            'Se romaneio de transvase
            If pid_transvase > 0 Then
                lbl_transit.Text = String.Concat("Transvase: ", pid_transvase.ToString)
                romaneio.id_transvase = pid_transvase

                dsRomaneioRotaDetalhes = romaneio.getRomaneioAmostraTransvase()
            Else
                If pid_transit_point = 0 Then
                    lbl_transit.Text = String.Empty
                End If
            End If


            'Se romaneio transbordo
            If pst_romaneio_transbordo = "S" Then
                lbl_transbordo.Text = "Transbordo: SIM"
                dsRomaneioRotaDetalhes = romaneio.getRomaneioAmostraTransbordo()
            Else
                lbl_transbordo.Text = "Transbordo: NÃO"
            End If

            'se romaneio normal
            If pid_transit_point = 0 And pid_transvase = 0 And pst_romaneio_transbordo = "N" Then
                romaneio.nr_caderneta = pnr_caderneta
                dsRomaneioRotaDetalhes = romaneio.getRomaneioAmostra()
            End If


            If (dsRomaneioRotaDetalhes.Tables(0).Rows.Count > 0) Then
                pnl_amostras.Visible = True
                gridAmostras.Visible = True
                btn_receber.Visible = True
                lbl_descarte.Visible = True
                cbo_motivo_descarte.Visible = True
                btn_Descartar.Visible = True

                lbl_novoprotocolo.Visible = True
                txt_novo_protocolo.Visible = True
                btn_alterarprotocolo.Visible = True

                If pid_transit_point > 0 OrElse pid_transvase > 0 OrElse pst_romaneio_transbordo = "S" Then
                    gridAmostras.Columns.Item(1).Visible = True 'pre romaneio
                Else
                    gridAmostras.Columns.Item(1).Visible = False 'pre romaneio
                End If

                'If dsRomaneioRotaDetalhes.Tables(0).Rows(0).Item("id_tipo_frasco1") = 0 Then
                '    gridAmostras.Columns.Item(6).Visible = False 'frasco amarelo
                'Else
                '    gridAmostras.Columns.Item(6).Visible = True 'frasco amarelo
                'End If
                'If dsRomaneioRotaDetalhes.Tables(0).Rows(0).Item("id_tipo_frasco2") = 0 Then
                '    gridAmostras.Columns.Item(7).Visible = False 'frasco azul
                'Else
                '    gridAmostras.Columns.Item(7).Visible = True 'frasco azul
                'End If
                If dsRomaneioRotaDetalhes.Tables(0).Rows(0).Item("id_tipo_frasco3") = 0 Then
                    gridAmostras.Columns.Item(8).Visible = False 'frasco branco
                Else
                    gridAmostras.Columns.Item(8).Visible = True 'frasco branco
                End If
                If dsRomaneioRotaDetalhes.Tables(0).Rows(0).Item("id_tipo_frasco4") = 0 Then
                    gridAmostras.Columns.Item(9).Visible = False 'frasco vermelho
                Else
                    gridAmostras.Columns.Item(9).Visible = True 'frasco verelho
                End If

                gridAmostras.DataSource = Helper.getDataView(dsRomaneioRotaDetalhes.Tables(0), ViewState.Item("sortExpressionDet"))
                gridAmostras.DataBind()

                Me.cbo_motivo_descarte.SelectedValue = 0

            Else
                pnl_amostras.Visible = True
                gridAmostras.Visible = False
                btn_receber.Visible = False
                lbl_descarte.Visible = False
                cbo_motivo_descarte.Visible = False
                btn_Descartar.Visible = False
                lbl_novoprotocolo.Visible = False
                txt_novo_protocolo.Visible = False
                btn_alterarprotocolo.Visible = False


            End If

            lbl_id_romaneio.Text = pid_romaneio


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            'se o romaneio clicado para consistencia é igual ao montado, troca cor de fi=undo
            If ViewState.Item("id_romaneio_detalhe") > 0 AndAlso ViewState.Item("id_romaneio_detalhe").ToString = e.Row.Cells(1).Text Then
                e.Row.ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub


    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridAmostras.Rows.Count - 1
                ch = CType(gridAmostras.Rows(li).FindControl("ck_item"), CheckBox)
                If ch.Enabled = True Then
                    ch.Checked = ck_header.Checked
                    If ch.Checked = True Then
                        gridAmostras.Rows(li).ForeColor = Drawing.Color.Red
                    Else
                        gridAmostras.Rows(li).ForeColor = System.Drawing.Color.FromName("#333333")
                    End If

                Else
                    ch.Checked = False
                End If
            Next



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

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
        Me.pnl_amostras.Visible = False

        ViewState.Item("id_romaneio_detalhe") = 0
        ViewState.Item("id_transit_point_detalhe") = 0
        ViewState.Item("id_transvase_detalhe") = 0
        ViewState.Item("st_romaneio_transbordo_detalhe") = String.Empty
        ViewState.Item("nr_caderneta_detalhe") = 0

        loadData()
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

    Private Function verificarSelecionados(Optional ByRef pidcoletaamostra As Integer = 0) As Boolean

        Try

            verificarSelecionados = False
            Dim i As Integer = 0
            Dim row As GridViewRow

            For Each row In gridAmostras.Rows
                Dim chk_selecionar As CheckBox = CType(row.FindControl("ck_item"), CheckBox)

                'se está selecionado
                If chk_selecionar.Checked = True Then
                    pidcoletaamostra = gridAmostras.DataKeys(row.RowIndex).Value.ToString

                    verificarSelecionados = True
                    i = i + 1
                    'Exit For
                End If
            Next

            ViewState.Item("itensselecionados") = i

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub cv_receber_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_receber.ServerValidate
        Try
            args.IsValid = verificarSelecionados()

            If args.IsValid = False Then
                messageControl.Alert("Para receber as amostras alguma coleta/frascos deve ser selecionado.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_Descartar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Descartar.Click
        If Page.IsValid = True Then
            Try

                Dim row As GridViewRow
                Dim coletaamostra As New ColetaAmostra
                Dim lbdescarte As Boolean = False

                For Each row In gridAmostras.Rows
                    Dim chk_selec As CheckBox = CType(row.FindControl("ck_item"), CheckBox)

                    'se foi selecionado
                    If chk_selec.Checked = True Then
                        If Not chk_selec.ToolTip = "Coleta já recepcionada." Then
                            'coletaamostra.id_coleta = gridAmostras.DataKeys(row.RowIndex).Value.ToString
                            coletaamostra.id_coleta_amostra = gridAmostras.DataKeys(row.RowIndex).Value.ToString
                            coletaamostra.id_motivo_descarte_romaneio_amostra = cbo_motivo_descarte.SelectedValue
                            coletaamostra.id_modificador = Session("id_login")
                            coletaamostra.id_currentidentity = row.Cells(2).Text

                            coletaamostra.updateColetaAmostraDescarteRomaneio()
                            lbdescarte = True

                        End If

                    End If
                Next
                If lbdescarte = True Then
                    loadDetalheRomaneio(CInt(ViewState.Item("id_romaneio_detalhe")), CInt(ViewState.Item("id_transit_point_detalhe")), CInt(ViewState.Item("id_transvase_detalhe")), ViewState.Item("st_romaneio_transbordo_detalhe"), CInt(ViewState.Item("nr_caderneta_detalhe")))
                    messageControl.Alert("Coletas descartadas com sucesso! Lembre de descartar os frascos coletados!")
                Else
                    messageControl.Alert("Coletas não foram descartadas porque já foram recepcionadas!")

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub gridAmostras_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridAmostras.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_id_situacao_coleta_amostra As Label = CType(e.Row.FindControl("lbl_id_situacao_coleta_amostra"), Label)
            Dim lbl_situacao_coleta_amostra As Label = CType(e.Row.FindControl("lbl_situacao_coleta_amostra"), Label)
            Dim lbl_id_situacao_romaneio_amostra As Label = CType(e.Row.FindControl("lbl_id_situacao_romaneio_amostra"), Label)
            Dim chk_item As CheckBox = CType(e.Row.FindControl("ck_item"), CheckBox)
            Dim btn_detalhes As Anthem.ImageButton = CType(e.Row.FindControl("btn_detalhes"), Anthem.ImageButton)

            'se a situação da coleta amostra é realizada
            If lbl_id_situacao_coleta_amostra.Text.Trim.Equals("2") Then
                lbl_situacao_coleta_amostra.Text = "Realizada"
                'se aq situacao do romaneio amostra é pendente
                If lbl_id_situacao_romaneio_amostra.Text.Trim.Equals("1") Then
                    chk_item.Enabled = True

                Else

                    If lbl_id_situacao_romaneio_amostra.Text.Trim.Equals("2") Then ' recebida
                        chk_item.Enabled = True 'deixa fazer a selecao para troca de protocolo

                        chk_item.ToolTip = "Coleta já recepcionada."
                        e.Row.Cells(11).BackColor = Drawing.Color.Aquamarine
                        e.Row.Cells(6).BackColor = Drawing.Color.Aquamarine
                        e.Row.Cells(7).BackColor = Drawing.Color.Aquamarine
                        e.Row.Cells(8).BackColor = Drawing.Color.Aquamarine
                        e.Row.Cells(9).BackColor = Drawing.Color.Aquamarine

                    Else
                        chk_item.Enabled = False
                        chk_item.ToolTip = "Coleta já descartada."
                        e.Row.Cells(10).BackColor = Drawing.Color.Yellow
                        e.Row.Cells(6).BackColor = Drawing.Color.Yellow
                        e.Row.Cells(7).BackColor = Drawing.Color.Yellow
                        e.Row.Cells(8).BackColor = Drawing.Color.Yellow
                        e.Row.Cells(9).BackColor = Drawing.Color.Yellow

                    End If
                End If

            Else
                'se a situação da coleta amostra é DESCARTADA e a situação do romaneio e pendente (significa que a amostra foi descartada no coletor)
                If lbl_id_situacao_romaneio_amostra.Text.Trim.Equals("1") Then 'pendente
                    lbl_situacao_coleta_amostra.Text = "Descartar"
                    e.Row.Cells(10).BackColor = Drawing.Color.Yellow
                    e.Row.Cells(11).Text = String.Empty 'situação da recepcao
                    e.Row.Cells(6).BackColor = Drawing.Color.Yellow
                    e.Row.Cells(7).BackColor = Drawing.Color.Yellow
                    e.Row.Cells(8).BackColor = Drawing.Color.Yellow
                    e.Row.Cells(9).BackColor = Drawing.Color.Yellow
                Else
                    lbl_situacao_coleta_amostra.Text = "Descartar"
                    e.Row.Cells(10).BackColor = Drawing.Color.Yellow
                    e.Row.Cells(11).BackColor = System.Drawing.Color.FromName("#FF5050")
                    e.Row.Cells(6).BackColor = Drawing.Color.Yellow
                    e.Row.Cells(7).BackColor = Drawing.Color.Yellow
                    e.Row.Cells(8).BackColor = Drawing.Color.Yellow
                    e.Row.Cells(9).BackColor = Drawing.Color.Yellow
                End If


                chk_item.Enabled = False
                chk_item.ToolTip = "Os frascos desta coleta devem ser descartados porque os protocolos não serão exportados para ESALQ!"
            End If


        End If

    End Sub

    Protected Sub ck_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim chk_selec As CheckBox

            chk_selec = CType(sender, CheckBox)


            If chk_selec.Checked = True Then
                row.ForeColor = Drawing.Color.Red
            Else
                row.ForeColor = System.Drawing.Color.FromName("#333333")
            End If




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub cv_descartar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_descartar.ServerValidate
        Try
            args.IsValid = verificarSelecionados()

            If args.IsValid = False Then
                messageControl.Alert("Para descartar as amostras alguma coleta/frascos deve ser selecionado.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_receber_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_receber.Click
        If Page.IsValid = True Then
            Try

                Dim row As GridViewRow
                Dim coletaamostra As New ColetaAmostra
                Dim protocolo As New AnaliseEsalqProtocolo
                Dim lbrecebido As Boolean = False

                protocolo.id_estabelecimento = ViewState.Item("id_estabelecimento")
                protocolo.id_romaneio = ViewState.Item("id_romaneio_detalhe")

                For Each row In gridAmostras.Rows
                    Dim chk_selec As CheckBox = CType(row.FindControl("ck_item"), CheckBox)

                    'se foi selecionado
                    If chk_selec.Checked = True Then

                        If Not chk_selec.ToolTip = "Coleta já recepcionada." Then
                            'coletaamostra.id_coleta = gridAmostras.DataKeys(row.RowIndex).Value.ToString
                            coletaamostra.id_coleta_amostra = gridAmostras.DataKeys(row.RowIndex).Value.ToString
                            coletaamostra.id_modificador = Session("id_login")
                            coletaamostra.id_currentidentity = row.Cells(2).Text
                            coletaamostra.updateColetaAmostraRecepcaoRomaneio()

                            'protocolo.id_coleta = coletaamostra.id_coleta
                            protocolo.id_coleta_amostra = coletaamostra.id_coleta_amostra
                            protocolo.nr_caderneta = coletaamostra.id_currentidentity
                            protocolo.id_modificador = coletaamostra.id_modificador
                            protocolo.insertAnaliseEsalqProtocolobyColeta()

                            lbrecebido = True
                        End If
                    End If
                Next

                If lbrecebido = True Then
                    loadDetalheRomaneio(CInt(ViewState.Item("id_romaneio_detalhe")), CInt(ViewState.Item("id_transit_point_detalhe")), CInt(ViewState.Item("id_transvase_detalhe")), ViewState.Item("st_romaneio_transbordo_detalhe"), CInt(ViewState.Item("nr_caderneta_detalhe")))
                    messageControl.Alert("Coletas recebidas com sucesso! Protocolos disponíveis para exportação.")
                Else
                    messageControl.Alert("Coletas já foram recepcionadas anteriormente.")

                End If




            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub optprotocolo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optprotocolo.CheckedChanged

        If optprotocolo.Checked = True Then

            optfiltro.Checked = False
            cbo_estabelecimento.SelectedValue = String.Empty
            txt_dt_hora_entrada_ini.Text = String.Empty
            txt_dt_hora_entrada_fim.Text = String.Empty
            txt_rota.Text = String.Empty
            txt_id_romaneio.Text = String.Empty
            txt_id_transit_point.Text = String.Empty
            txt_id_transvase.Text = String.Empty
            txt_protocolo.Text = String.Empty
            txt_ds_placa.Text = String.Empty
            cbo_tipo_coleta.SelectedValue = 0
            btn_pesquisa.Enabled = False
            btn_limparFiltros.Enabled = False
            gridResults.Visible = False
            gridAmostras.Visible = False
            ViewState.Item("cd_protocolo_detalhe") = String.Empty
            ViewState.Item("id_romaneio_detalhe") = 0
            ViewState.Item("id_transit_point_detalhe") = 0
            ViewState.Item("id_transvase_detalhe") = 0
            ViewState.Item("st_romaneio_transbordo_detalhe") = String.Empty
            ViewState.Item("nr_caderneta_detalhe") = 0

            txt_cd_protocolo.Enabled = True
            txt_cd_protocolo.Focus()
        Else
            txt_cd_protocolo.Text = String.Empty
            txt_cd_protocolo.Enabled = False
            optprotocolo.Checked = False
            btn_pesquisa.Enabled = True
            btn_limparFiltros.Enabled = True
            cbo_estabelecimento.SelectedValue = 1
            txt_dt_hora_entrada_ini.Text = "01/" + DateTime.Parse(Now).ToString("MM/yyyy").ToString
            txt_dt_hora_entrada_fim.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")

            gridResults.Visible = False
            gridAmostras.Visible = False
            ViewState.Item("cd_protocolo_detalhe") = String.Empty
            ViewState.Item("id_romaneio_detalhe") = 0
            ViewState.Item("id_transit_point_detalhe") = 0
            ViewState.Item("id_transvase_detalhe") = 0
            ViewState.Item("st_romaneio_transbordo_detalhe") = String.Empty
            ViewState.Item("nr_caderneta_detalhe") = 0

            btn_pesquisa.Focus()

        End If

    End Sub

    Protected Sub txt_cd_protocolo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_protocolo.TextChanged
        Try
            If Not txt_cd_protocolo.Text.Equals(String.Empty) Then

                Dim coletaamostra As New ColetaAmostra
                Dim protocolo As New AnaliseEsalqProtocolo
                Dim lbrecebido As Boolean = False
                Dim lidprotocolo As Integer = 0
                ViewState.Item("cd_protocolo_detalhe") = txt_cd_protocolo.Text

                Dim romaneio As New Romaneio

                romaneio.ds_cd_protocolo_esalq = txt_cd_protocolo.Text
                Dim dsromaneioamostras As DataSet = romaneio.getRomaneioAmostrasbyProtocolo

                If (dsromaneioamostras.Tables(0).Rows.Count > 0) Then
                    'atualiza coleta amostra para recepcionada
                    coletaamostra.ds_cd_protocolo_esalq = txt_cd_protocolo.Text
                    coletaamostra.id_modificador = Session("id_login")
                    coletaamostra.updateColetaAmostraRecepcaoRomaneiobyProtocolo()

                    'insere protocolo para exportacao
                    protocolo.cd_protocolo_esalq = ViewState.Item("cd_protocolo_detalhe").ToString
                    protocolo.id_romaneio = dsromaneioamostras.Tables(0).Rows(0).Item("id_romaneio")
                    protocolo.id_estabelecimento = dsromaneioamostras.Tables(0).Rows(0).Item("id_estabelecimento")
                    protocolo.id_modificador = coletaamostra.id_modificador
                    lidprotocolo = protocolo.insertAnaliseEsalqProtocolobyProtocolo()

                    ViewState.Item("id_romaneio_detalhe") = protocolo.id_romaneio
                    ViewState.Item("id_transit_point_detalhe") = Convert.ToInt32(dsromaneioamostras.Tables(0).Rows(0).Item("id_transit_point"))
                    ViewState.Item("id_transvase_detalhe") = Convert.ToInt32(dsromaneioamostras.Tables(0).Rows(0).Item("id_transvase"))
                    ViewState.Item("st_romaneio_transbordo_detalhe") = dsromaneioamostras.Tables(0).Rows(0).Item("st_romaneio_transbordo")
                    ViewState.Item("nr_caderneta_detalhe") = dsromaneioamostras.Tables(0).Rows(0).Item("nr_caderneta")

                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsromaneioamostras.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()

                    loadDetalheRomaneio(Convert.ToInt32(ViewState.Item("id_romaneio_detalhe").ToString()), CInt(ViewState.Item("id_transit_point_detalhe")), CInt(ViewState.Item("id_transvase_detalhe")), ViewState.Item("st_romaneio_transbordo_detalhe"), ViewState.Item("nr_caderneta_detalhe"))

                    If lidprotocolo > 0 Then
                        lbrecebido = True
                        messageControl.Alert("Coleta recebida com sucesso! Protocolo disponível para exportação.")
                    Else
                        messageControl.Alert("Coleta já foi recepcionada anteriormente.")

                    End If
                    txt_cd_protocolo.Text = String.Empty
                    txt_cd_protocolo.Focus()
                Else
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If

            Else
                ViewState.Item("cd_protocolo_detalhe") = String.Empty


            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub optfiltro_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optfiltro.CheckedChanged
        If optfiltro.Checked = True Then

            txt_cd_protocolo.Text = String.Empty
            txt_cd_protocolo.Enabled = False
            optprotocolo.Checked = False
            btn_pesquisa.Enabled = True
            btn_limparFiltros.Enabled = True
            cbo_estabelecimento.SelectedValue = 1
            txt_dt_hora_entrada_ini.Text = "01/" + DateTime.Parse(Now).ToString("MM/yyyy").ToString
            txt_dt_hora_entrada_fim.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")

            gridResults.Visible = False
            gridAmostras.Visible = False
            ViewState.Item("cd_protocolo_detalhe") = String.Empty
            ViewState.Item("id_romaneio_detalhe") = 0
            ViewState.Item("id_transit_point_detalhe") = 0
            ViewState.Item("id_transvase_detalhe") = 0
            ViewState.Item("st_romaneio_transbordo_detalhe") = String.Empty
            ViewState.Item("nr_caderneta_detalhe") = 0


            btn_pesquisa.Focus()

        End If

    End Sub

    Protected Sub cv_protocolo_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_protocolo.ServerValidate
        Try
            Dim lidcoletaamostra As Integer = 0
            args.IsValid = verificarSelecionados(lidcoletaamostra)

            If args.IsValid = False Then
                messageControl.Alert("Para alterar o protocolo uma coleta/frasco deve ser selecionado.")
            Else
                If CInt(ViewState.Item("itensselecionados").ToString) > 1 Then
                    messageControl.Alert("Para alterar o protocolo APENAS uma amostra deve ser selecionada.")
                    args.IsValid = False
                Else
                    Dim protocolo As New AnaliseEsalqProtocolo
                    protocolo.id_coleta_amostra = lidcoletaamostra
                    protocolo.id_situacao = 1

                    Dim dsprotocolo As DataSet = protocolo.getAnaliseEsalqProtocoloByFilters
                    If dsprotocolo.Tables(0).Rows.Count > 0 Then
                        If Not IsDBNull(dsprotocolo.Tables(0).Rows(0).Item("st_exportacao")) AndAlso dsprotocolo.Tables(0).Rows(0).Item("st_exportacao").ToString().Equals("S") Then

                            Dim analise As New AnaliseEsalq
                            analise.id_analise_esalq_protocolo = dsprotocolo.Tables(0).Rows(0).Item("id_analise_esalq_protocolo")
                            analise.id_situacao = 1
                            'se ja foi esportado pra clinica e ja retornou com os dados da analise nao deixa alterar protocolo
                            If analise.getAnaliseEsalqByFilters.Tables(0).Rows.Count > 0 Then
                                messageControl.Alert("O protocolo não pode ser alterado porque já foi exportado e os dados da análise já foram importados da Clínica do Leite.")
                                args.IsValid = False

                            End If

                        End If
                    End If

                    If args.IsValid = True Then
                        If txt_novo_protocolo.Text = "0" Then
                            messageControl.Alert("O novo protocolo deve ser informado com valor válido.")
                            args.IsValid = False
                        Else
                            If Len(txt_novo_protocolo.Text) <> 20 Then
                                messageControl.Alert("O novo protocolo deve ser informado com 20 caracteres.")
                                args.IsValid = False
                            End If
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_alterarprotocolo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_alterarprotocolo.Click
        If Page.IsValid = True Then
            Try

                Dim row As GridViewRow
                Dim coletaamostra As New ColetaAmostra
                Dim protocolo As New AnaliseEsalqProtocolo
                Dim lbrecebido As Boolean = False


                For Each row In gridAmostras.Rows
                    Dim chk_selec As CheckBox = CType(row.FindControl("ck_item"), CheckBox)

                    'se foi selecionado
                    If chk_selec.Checked = True Then

                        coletaamostra.id_coleta_amostra = gridAmostras.DataKeys(row.RowIndex).Value.ToString
                        coletaamostra.id_modificador = Session("id_login")
                        coletaamostra.ds_cd_protocolo_esalq = txt_novo_protocolo.Text
                        coletaamostra.updateColetaAmostraProtocolo()

                        lbrecebido = True
                    End If
                Next

                txt_novo_protocolo.Text = String.Empty

                If lbrecebido = True Then
                    loadDetalheRomaneio(CInt(ViewState.Item("id_romaneio_detalhe")), CInt(ViewState.Item("id_transit_point_detalhe")), CInt(ViewState.Item("id_transvase_detalhe")), ViewState.Item("st_romaneio_transbordo_detalhe"), CInt(ViewState.Item("nr_caderneta_detalhe")))
                    messageControl.Alert("Protocolo da coleta alterado com sucesso.")

                End If




            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If


    End Sub
End Class
