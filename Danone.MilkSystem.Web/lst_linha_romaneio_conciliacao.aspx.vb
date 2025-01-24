Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_linha_romaneio_conciliacao

    ' chamado 2491 - Conciliação Rotas x Romaneios

    Inherits Page
    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_romaneio_consistencia") = 0 'limpar romaneio detalhe

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("txt_dt_hora_entrada_ini") = txt_dt_hora_entrada_ini.Text
        ViewState.Item("txt_dt_hora_entrada_fim") = txt_dt_hora_entrada_fim.Text
        ViewState.Item("id_romaneio") = txt_id_romaneio.Text
        ViewState.Item("txt_rota") = txt_rota.Text

        ViewState.Item("cbo_tipo_romaneio") = Me.cbo_tipo_romaneio.SelectedValue()
        If cbo_tipo_romaneio.SelectedValue <> "1" Then 'se for diferente de romaneio
            ViewState.Item("id_romaneio_tp_transb") = txt_id_romaneio_tp_transb.Text
        Else
            ViewState.Item("id_romaneio_tp_transb") = "0"

        End If

        ViewState.Item("id_divergencia_km_frete") = Me.cbo_divergencias.SelectedValue
        ViewState.Item("id_aprovacao_km_frete") = Me.cbo_aprovacao_km_frete.SelectedValue

        ViewState.Item("sortExpression") = "id_romaneio, dt_hora_entrada"

        ' Sempre limpar todas as seleções do estabelecimento e referencia quando efetuar novo filtro - i
        Dim romaneio As New Romaneio
        romaneio.id_estabelecimento = cbo_estabelecimento.SelectedValue
        romaneio.dt_hora_entrada_ini = txt_dt_hora_entrada_ini.Text
        romaneio.dt_hora_entrada_fim = txt_dt_hora_entrada_fim.Text
        romaneio.st_selecao = "0"
        romaneio.updateRomaneioSelecaoTodos()
        ' Sempre limpar todas as seleções do estabelecimento e referencia quando efetuar novo filtro - f

        Me.pnl_consistencias.Visible = False  ' Tira painel de consultas anteriores

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_linha_romaneio_conciliacao.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_linha_romaneio_conciliacao.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 175
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

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            cbo_aprovacao_km_frete.DataSource = romaneio.getRomaneioAprovacaoKmFrete()
            cbo_aprovacao_km_frete.DataTextField = "nm_aprovacao_km_frete"
            cbo_aprovacao_km_frete.DataValueField = "id_aprovacao_km_frete"
            cbo_aprovacao_km_frete.DataBind()
            cbo_aprovacao_km_frete.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_justificativa_km_frete.DataSource = romaneio.getRomaneioJustificativaKmFrete()
            cbo_justificativa_km_frete.DataTextField = "nm_justificativa_km_frete"
            cbo_justificativa_km_frete.DataValueField = "id_justificativa_km_frete"
            cbo_justificativa_km_frete.DataBind()
            cbo_justificativa_km_frete.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("txt_dt_hora_entrada_fim") = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            ViewState.Item("txt_dt_hora_entrada_ini") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_hora_entrada_fim"))))

            txt_dt_hora_entrada_ini.Text = DateTime.Parse(ViewState.Item("txt_dt_hora_entrada_ini").ToString).ToString("dd/MM/yyyy")
            txt_dt_hora_entrada_fim.Text = DateTime.Parse(ViewState.Item("txt_dt_hora_entrada_fim").ToString).ToString("dd/MM/yyyy")

            ViewState.Item("sortExpression") = "id_romaneio, dt_hora_entrada"

            loadFilters()



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("linha_conciliacao", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("linha_conciliacao", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If


        If Not (customPage.getFilterValue("linha_conciliacao", txt_dt_hora_entrada_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_hora_entrada_ini") = customPage.getFilterValue("linha_conciliacao", txt_dt_hora_entrada_ini.ID)
            txt_dt_hora_entrada_ini.Text = ViewState.Item("txt_dt_hora_entrada_ini").ToString()
        Else
            ViewState.Item("txt_dt_hora_entrada_ini") = String.Empty
        End If

        If Not (customPage.getFilterValue("linha_conciliacao", txt_dt_hora_entrada_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_hora_entrada_fim") = customPage.getFilterValue("linha_conciliacao", txt_dt_hora_entrada_fim.ID)
            txt_dt_hora_entrada_fim.Text = ViewState.Item("txt_dt_hora_entrada_fim").ToString()
        Else
            ViewState.Item("txt_dt_hora_entrada_fim") = String.Empty
        End If

        If Not (customPage.getFilterValue("linha_conciliacao", txt_id_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("linha_conciliacao", txt_id_romaneio.ID)
            txt_id_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If

        If Not (customPage.getFilterValue("linha_conciliacao", txt_rota.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_rota") = customPage.getFilterValue("linha_conciliacao", txt_rota.ID)
            txt_rota.Text = ViewState.Item("txt_rota").ToString()
        Else
            ViewState.Item("txt_rota") = String.Empty
        End If

        If Not (customPage.getFilterValue("linha_conciliacao", cbo_tipo_romaneio.ID).Equals(String.Empty)) Then
            'hasFilters = True
            ViewState.Item("cbo_tipo_romaneio") = customPage.getFilterValue("linha_conciliacao", cbo_tipo_romaneio.ID)
            cbo_tipo_romaneio.SelectedValue = ViewState.Item("cbo_tipo_romaneio").ToString()
            If CInt(cbo_tipo_romaneio.SelectedValue) <> 1 Then 'se nao for romaneio
                If Not (customPage.getFilterValue("linha_conciliacao", txt_id_romaneio_tp_transb.ID).Equals(String.Empty)) Then
                    ViewState.Item("id_romaneio_tp_transb") = customPage.getFilterValue("linha_conciliacao", txt_id_romaneio_tp_transb.ID)
                Else
                    ViewState.Item("id_romaneio_tp_transb") = String.Empty
                End If

                txt_id_romaneio_tp_transb.Visible = True
                txt_id_romaneio_tp_transb.Text = ViewState.Item("id_romaneio_tp_transb").ToString()

                If CInt(cbo_tipo_romaneio.SelectedValue) >= 4 Then 'se  for romaneio transit
                    lbl_romaneio_tp_transb.Text = "Romaneio Transit"
                    If CInt(cbo_tipo_romaneio.SelectedValue) >= 6 Then
                        lbl_romaneio_tp_transb.Text = "Romaneio Transvase"

                    End If
                Else
                    lbl_romaneio_tp_transb.Text = "Romaneio Transb."
                End If
            Else
                ViewState.Item("id_romaneio_tp_transb") = String.Empty
                lbl_romaneio_tp_transb.Text = String.Empty
                txt_id_romaneio_tp_transb.Text = String.Empty
                txt_id_romaneio_tp_transb.Visible = False
            End If

        Else
            ViewState.Item("cbo_tipo_romaneio") = String.Empty
            ViewState.Item("id_romaneio_tp_transb") = String.Empty
        End If


        If Not (customPage.getFilterValue("linha_conciliacao", cbo_divergencias.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_divergencia_km_frete") = customPage.getFilterValue("linha_conciliacao", cbo_divergencias.ID)
            cbo_divergencias.SelectedValue = ViewState.Item("id_divergencia_km_frete").ToString()
        Else
            ViewState.Item("id_divergencia_km_frete") = 0
        End If

        If Not (customPage.getFilterValue("linha_conciliacao", cbo_aprovacao_km_frete.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_aprovacao_km_frete") = customPage.getFilterValue("linha_conciliacao", cbo_aprovacao_km_frete.ID)
            cbo_aprovacao_km_frete.SelectedValue = ViewState.Item("id_aprovacao_km_frete").ToString()
        Else
            ViewState.Item("id_aprovacao_km_frete") = 0
        End If

        If Not (customPage.getFilterValue("linha_conciliacao", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("linha_conciliacao", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("linha_conciliacao")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio

            romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            romaneio.dt_hora_entrada_ini = ViewState.Item("txt_dt_hora_entrada_ini").ToString
            romaneio.dt_hora_entrada_fim = ViewState.Item("txt_dt_hora_entrada_fim").ToString

            If Trim(ViewState.Item("id_romaneio")) <> "" Then
                romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            End If

            romaneio.nm_linha = ViewState.Item("txt_rota").ToString

            romaneio.id_divergencia_km_frete = Convert.ToInt32(ViewState.Item("id_divergencia_km_frete").ToString)
            romaneio.id_aprovacao_km_frete = Convert.ToInt32(ViewState.Item("id_aprovacao_km_frete").ToString)

            If Trim(ViewState.Item("id_romaneio_tp_transb")) <> "" Then
                romaneio.id_romaneio_transbordo = Convert.ToInt32(ViewState.Item("id_romaneio_tp_transb").ToString)
            End If
            'fran 02/2017 i 
            Dim dsRomaneioConciliacaoRotas As DataSet

            Select Case ViewState.Item("cbo_tipo_romaneio").ToString
                Case "1" 'Romaneio
                    dsRomaneioConciliacaoRotas = romaneio.getRomaneioConciliacaoRotas()
                    gridResults.Columns.Item(11).Visible = False 'romaneio transit point
                    gridResults.Columns.Item(12).Visible = False 'romaneio transbordo    
                    gridResults.Columns.Item(13).Visible = False 'romaneio transvase   
                    gridResults.Columns.Item(1).HeaderText = "Romaneio"
                Case "2" 'Romaneio Transbordo
                    dsRomaneioConciliacaoRotas = romaneio.getRomaneioConciliacaoRotasTransbordo()
                    gridResults.Columns.Item(11).Visible = False 'romaneio transit point
                    gridResults.Columns.Item(12).Visible = False 'romaneio transbordo    
                    gridResults.Columns.Item(13).Visible = False 'romaneio transvase   
                    gridResults.Columns.Item(1).HeaderText = "Romaneio"
                Case "3" 'Pre-Romaneio Transbordo
                    dsRomaneioConciliacaoRotas = romaneio.getRomaneioConciliacaoRotasPreRomaneioTransbordo()
                    gridResults.Columns.Item(11).Visible = False 'romaneio transit point
                    gridResults.Columns.Item(12).Visible = True 'romaneio transbordo    
                    gridResults.Columns.Item(13).Visible = False 'romaneio transvase   
                    gridResults.Columns.Item(1).HeaderText = "Pré-Romaneio"
                Case "4" 'Romaneio Transit Point
                    dsRomaneioConciliacaoRotas = romaneio.getRomaneioConciliacaoRotasTransitPoint()
                    gridResults.Columns.Item(11).Visible = False 'romaneio transit point
                    gridResults.Columns.Item(12).Visible = False 'romaneio transbordo    
                    gridResults.Columns.Item(13).Visible = False 'romaneio transvase   
                    gridResults.Columns.Item(1).HeaderText = "Romaneio"
                Case "5" 'Pré-Romaneio Transit Point
                    dsRomaneioConciliacaoRotas = romaneio.getRomaneioConciliacaoRotasPreRomaneioTransitPoint()
                    gridResults.Columns.Item(11).Visible = True 'romaneio transit point
                    gridResults.Columns.Item(12).Visible = False 'romaneio transbordo   
                    gridResults.Columns.Item(13).Visible = False 'romaneio transvase   
                    gridResults.Columns.Item(1).HeaderText = "Pré-Romaneio"
                Case "6" 'Romaneio Transvase
                    dsRomaneioConciliacaoRotas = romaneio.getRomaneioConciliacaoRotasTransvase()
                    gridResults.Columns.Item(11).Visible = False 'romaneio transit point
                    gridResults.Columns.Item(12).Visible = False 'romaneio transbordo    
                    gridResults.Columns.Item(13).Visible = False 'romaneio transvase   
                    gridResults.Columns.Item(1).HeaderText = "Romaneio"
                Case "7" 'Pré-Romaneio Transvase
                    dsRomaneioConciliacaoRotas = romaneio.getRomaneioConciliacaoRotasPreRomaneioTransvase()
                    gridResults.Columns.Item(11).Visible = False 'romaneio transit point
                    gridResults.Columns.Item(12).Visible = False 'romaneio transbordo   
                    gridResults.Columns.Item(13).Visible = True 'romaneio transvase   
                    gridResults.Columns.Item(1).HeaderText = "Pré-Romaneio"

            End Select

            'fran 02/2017 f 

            If (dsRomaneioConciliacaoRotas.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsRomaneioConciliacaoRotas.Tables(0), ViewState.Item("sortExpression"))
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
        saveCheckBox()
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

            Case "nm_aprovacao_km_frete"
                If (ViewState.Item("sortExpression")) = "nm_aprovacao_km_frete asc" Then
                    ViewState.Item("sortExpression") = "nm_aprovacao_km_frete desc"
                Else
                    ViewState.Item("sortExpression") = "nm_aprovacao_km_frete asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try


            customPage.setFilter("linha_conciliacao", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("linha_conciliacao", txt_dt_hora_entrada_ini.ID, ViewState.Item("txt_dt_coleta_ini").ToString)
            customPage.setFilter("linha_conciliacao", txt_dt_hora_entrada_fim.ID, ViewState.Item("txt_dt_coleta_fim").ToString)
            customPage.setFilter("linha_conciliacao", txt_id_romaneio.ID, ViewState.Item("id_romaneio").ToString)
            customPage.setFilter("linha_conciliacao", txt_rota.ID, ViewState.Item("txt_rota").ToString)
            customPage.setFilter("linha_conciliacao", cbo_tipo_romaneio.ID, ViewState.Item("cbo_tipo_romaneio").ToString)
            customPage.setFilter("linha_conciliacao", txt_id_romaneio_tp_transb.ID, ViewState.Item("id_romaneio_tp_transb").ToString)
            customPage.setFilter("linha_conciliacao", cbo_divergencias.ID, ViewState.Item("id_divergencia_km_frete").ToString)
            customPage.setFilter("linha_conciliacao", cbo_aprovacao_km_frete.ID, ViewState.Item("id_aprovacao_km_frete").ToString)
            customPage.setFilter("linha_conciliacao", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "consistencias"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
                Dim lbl_id_linha As Label = CType(row.FindControl("lbl_id_linha"), Label)
                Dim lbl_id_aprovacao_km_frete As Label = CType(row.FindControl("lbl_id_aprovacao_km_frete"), Label)

                If lbl_id_aprovacao_km_frete.Text = "3" Then 'se for aguardando aprovação
                    btn_salvarkm.Enabled = True
                    btn_salvarkm.ToolTip = String.Empty
                Else
                    btn_salvarkm.Enabled = False
                    btn_salvarkm.ToolTip = "KM já aprovada."

                End If
                ViewState.Item("id_romaneio_consistencia") = Convert.ToInt32(e.CommandArgument.ToString())
                loadConsistencias(Convert.ToInt32(e.CommandArgument.ToString()), CInt(lbl_id_linha.Text))
                loadData()
        End Select

    End Sub
    Private Sub loadConsistencias(ByVal pid_romaneio As Int32, ByVal pid_linha As Int32)

        Try
            Dim romaneio As New Romaneio
            romaneio.id_romaneio = pid_romaneio
            romaneio.id_linha = pid_linha

            'Dim dsRomaneioRotaDetalhes As DataSet = romaneio.getRomaneioConciliacaoRotaDetalhes() ' Traz todas as propriedades coletadas e não coletadas da Rota
            Dim dsRomaneioRotaDetalhes As DataSet

            Select Case CInt(ViewState.Item("cbo_tipo_romaneio").ToString)
                Case 1 'romaneio
                    dsRomaneioRotaDetalhes = romaneio.getRomaneioConciliacaoRotaDetalhes()
                Case 2, 3, 4, 5, 6, 7 'pre romaneios transit point e transbordo
                    dsRomaneioRotaDetalhes = romaneio.getRomaneioConciliacaoRotaPreDetalhes()

            End Select


            If (dsRomaneioRotaDetalhes.Tables(0).Rows.Count > 0) Then
                pnl_consistencias.Visible = True
                gridConsistencias.Visible = True
                gridConsistencias.DataSource = Helper.getDataView(dsRomaneioRotaDetalhes.Tables(0), "")
                gridConsistencias.DataBind()
            Else
                pnl_consistencias.Visible = True
                gridConsistencias.Visible = False
            End If

            lbl_id_romaneio.Text = pid_romaneio

            Dim dsRomaneioConciliacaoRotasKm As DataSet = romaneio.getRomaneioConciliacaoRotasKm() ' Traz KM Original e Frete (alterado) do Romaneio
            If (dsRomaneioConciliacaoRotasKm.Tables(0).Rows.Count > 0) Then
                Me.lbl_km_original.Text = dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("kmtotal").ToString
                Me.txt_nr_km_frete.Text = dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("nr_km_frete").ToString
                'fran 03/2017 i
                Me.lbl_km_coletor.Text = dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("nr_km_original_coletor").ToString
                If Not IsDBNull(dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("dt_importacao")) Then
                    Me.lbl_dt_importacao.Text = DateTime.Parse(dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("dt_importacao").ToString).ToString("dd/MM/yyyy HH:mm:ss")
                Else
                    Me.lbl_dt_importacao.Text = String.Empty
                End If
                'fran 03/2017 f

                If IsDBNull(dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("id_justificativa_km_frete")) Then
                    Me.cbo_justificativa_km_frete.SelectedValue = 0
                Else
                    Me.cbo_justificativa_km_frete.SelectedValue = dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("id_justificativa_km_frete")
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_consistencias As Label = CType(e.Row.FindControl("lbl_consistencias"), Label)
            Dim lbl_detalhes As Label = CType(e.Row.FindControl("lbl_detalhes"), Label)
            Dim btn_detalhes As Anthem.ImageButton = CType(e.Row.FindControl("btn_detalhes"), Anthem.ImageButton)

            If lbl_consistencias.Text = "Com Divergências" Then
                lbl_consistencias.Visible = False
                lbl_detalhes.Visible = True
                btn_detalhes.Visible = True
            End If

            'fran 22/02/2017 i 
            Dim lbl_id_aprovacao_km_frete As Label = CType(e.Row.FindControl("lbl_id_aprovacao_km_frete"), Label)

            If lbl_id_aprovacao_km_frete.Text.Equals(String.Empty) OrElse lbl_id_aprovacao_km_frete.Text.Equals("3") Then 'se nao fez nada ou esta em aprovacao
                'se km coletor não é vazio e km original tb nao e vazio
                If Not e.Row.Cells(7).Text.Equals(String.Empty) AndAlso Not e.Row.Cells(8).Text.Equals(String.Empty) Then
                    'se km do coletor é difernte km da rota atual
                    If CDec(e.Row.Cells(7).Text) <> CDec(e.Row.Cells(8).Text) Then
                        e.Row.Cells(7).ForeColor = Drawing.Color.Red
                        e.Row.Cells(8).ForeColor = Drawing.Color.Red
                    End If
                End If

            End If
            'fran 22/02/2017 f
            'se o romaneio clicado para consistencia é igual ao montado, troca cor de fi=undo
            If ViewState.Item("id_romaneio_consistencia") > 0 AndAlso ViewState.Item("id_romaneio_consistencia").ToString = e.Row.Cells(1).Text Then
                e.Row.ForeColor = Drawing.Color.Red
            End If
        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
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

            ' Seleciona tudo o que o botão Pesquisar trouxer - i
            Dim romaneio As New Romaneio
            romaneio.id_estabelecimento = cbo_estabelecimento.SelectedValue
            romaneio.dt_hora_entrada_ini = txt_dt_hora_entrada_ini.Text
            romaneio.dt_hora_entrada_fim = txt_dt_hora_entrada_fim.Text
            romaneio.nm_linha = txt_rota.Text
            If Trim(Me.txt_id_romaneio.Text.Trim()) <> "" Then
                romaneio.id_romaneio = Convert.ToInt32(Me.txt_id_romaneio.Text.Trim())
            End If
            romaneio.id_divergencia_km_frete = Me.cbo_divergencias.SelectedValue
            romaneio.id_aprovacao_km_frete = Me.cbo_aprovacao_km_frete.SelectedValue

            If ck_header.Checked = True Then
                romaneio.st_selecao = "1"
            Else
                romaneio.st_selecao = "0"
            End If
            romaneio.updateRomaneioSelecaoTodos()
            ' Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Function saveCheckBox() As Boolean

        Try

            Dim li As Integer

            Dim romaneio As New Romaneio
            For li = 0 To gridResults.Rows.Count - 1
                romaneio.id_romaneio = gridResults.DataKeys(li).Value.ToString
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    romaneio.st_selecao = "1"
                    saveCheckBox = True     ' Indica que tem item selecionado
                Else
                    romaneio.st_selecao = "0"
                End If
                romaneio.updateRomaneioSelecao()
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function


    Protected Sub btn_consistir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_consistir.Click
        Try

            Dim romaneio As New Romaneio

            romaneio.id_estabelecimento = cbo_estabelecimento.SelectedValue
            romaneio.dt_hora_entrada_ini = ViewState.Item("txt_dt_hora_entrada_ini").ToString
            romaneio.dt_hora_entrada_fim = ViewState.Item("txt_dt_hora_entrada_fim").ToString
            romaneio.id_modificador = Session("id_login")
            romaneio.ConsistirRomaneioRotas()

            messageControl.Alert("Consistências efetuadas com sucesso!")

            loadData()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aprovar.Click
        Try

            Dim romaneio As New Romaneio

            If saveCheckBox() = True Then
                'Filtro
                romaneio.id_estabelecimento = cbo_estabelecimento.SelectedValue
                romaneio.dt_hora_entrada_ini = txt_dt_hora_entrada_ini.Text
                romaneio.dt_hora_entrada_fim = txt_dt_hora_entrada_fim.Text
                romaneio.nm_linha = txt_rota.Text
                If Trim(Me.txt_id_romaneio.Text.Trim()) <> "" Then
                    romaneio.id_romaneio = Convert.ToInt32(Me.txt_id_romaneio.Text.Trim())
                End If
                romaneio.id_divergencia_km_frete = Me.cbo_divergencias.SelectedValue

                'Dados para o Update
                romaneio.id_modificador = Session("id_login")

                romaneio.updateRomaneioAprovarSelecionados()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 175
                usuariolog.ds_nm_processo = "Conciliação Rotas X Romaneio - Aprovação"
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Me.pnl_consistencias.Visible = False
                ViewState.Item("id_romaneio_consistencia") = 0
                loadData()

                messageControl.Alert("Romaneios Aprovados com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser aprovado. Por favor selecione algum romaneio.")

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub btn_fechar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_fechar.Click
        Me.pnl_consistencias.Visible = False
        ViewState.Item("id_romaneio_consistencia") = 0
        loadData()
    End Sub

    Protected Sub btn_nao_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nao_aprovar.Click
        Try
            Dim romaneio As New Romaneio

            If saveCheckBox() = True Then
                'Filtro
                romaneio.id_estabelecimento = cbo_estabelecimento.SelectedValue
                romaneio.dt_hora_entrada_ini = txt_dt_hora_entrada_ini.Text
                romaneio.dt_hora_entrada_fim = txt_dt_hora_entrada_fim.Text
                romaneio.nm_linha = txt_rota.Text
                If Trim(Me.txt_id_romaneio.Text.Trim()) <> "" Then
                    romaneio.id_romaneio = Convert.ToInt32(Me.txt_id_romaneio.Text.Trim())
                End If
                romaneio.id_divergencia_km_frete = Me.cbo_divergencias.SelectedValue

                'Dados para o Update
                romaneio.id_modificador = Session("id_login")

                romaneio.updateRomaneioNaoAprovarSelecionados()
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 175
                usuariolog.ds_nm_processo = "Conciliação Rotas X Romaneio - Reprovação"
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                loadData()

                messageControl.Alert("Romaneios Não Aprovados com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione algum romaneio.")

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_Cancelar_aprovacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Cancelar_aprovacao.Click
        Try
            Dim analiseesalq As New AnaliseEsalq


            Dim romaneio As New Romaneio

            If saveCheckBox() = True Then
                'Filtro
                romaneio.id_estabelecimento = cbo_estabelecimento.SelectedValue
                romaneio.dt_hora_entrada_ini = txt_dt_hora_entrada_ini.Text
                romaneio.dt_hora_entrada_fim = txt_dt_hora_entrada_fim.Text
                romaneio.nm_linha = txt_rota.Text
                If Trim(Me.txt_id_romaneio.Text.Trim()) <> "" Then
                    romaneio.id_romaneio = Convert.ToInt32(Me.txt_id_romaneio.Text.Trim())
                End If
                romaneio.id_divergencia_km_frete = Me.cbo_divergencias.SelectedValue

                'Dados para o Update
                romaneio.id_modificador = Session("id_login")

                romaneio.updateRomaneioAprovacaoCancelarSelecionados()
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 175
                usuariolog.ds_nm_processo = "Conciliação Rotas X Romaneio - Cancelar Aprovação"
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Me.pnl_consistencias.Visible = False
                ViewState.Item("id_romaneio_consistencia") = 0
                loadData()

                messageControl.Alert("Romaneios Aprovados/Não Aprovados cancelados com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser cancelar aprovação/não aprovação. Por favor selecione algum romaneio.")

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated

    End Sub

    Protected Sub btn_salvarkm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salvarkm.Click
        Try
            If Page.IsValid Then

                Dim romaneio As New Romaneio
                romaneio.id_romaneio = lbl_id_romaneio.Text
                romaneio.nr_km_frete = txt_nr_km_frete.Text
                romaneio.id_justificativa_km_frete = cbo_justificativa_km_frete.SelectedValue
                romaneio.updateRomaneioKMFrete()

                loadData()
                messageControl.Alert("KM para Frete alterada com sucesso!")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cbo_tipo_romaneio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_romaneio.SelectedIndexChanged

        Select Case cbo_tipo_romaneio.SelectedValue.ToString
            Case "1", "2", "4", "6"
                lbl_romaneio_tp_transb.Text = String.Empty
                txt_id_romaneio_tp_transb.Text = String.Empty
                txt_id_romaneio_tp_transb.Visible = False
            Case "3"
                lbl_romaneio_tp_transb.Text = "Romaneio Transb."
                txt_id_romaneio_tp_transb.Visible = True
                txt_id_romaneio_tp_transb.Text = String.Empty

            Case "5"
                lbl_romaneio_tp_transb.Text = "Romaneio Transit"
                txt_id_romaneio_tp_transb.Visible = True
                txt_id_romaneio_tp_transb.Text = String.Empty
            Case "7"
                lbl_romaneio_tp_transb.Text = "Romaneio Transvase"
                txt_id_romaneio_tp_transb.Visible = True
                txt_id_romaneio_tp_transb.Text = String.Empty

        End Select
    End Sub
End Class
