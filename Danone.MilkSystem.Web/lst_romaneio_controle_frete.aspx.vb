Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_romaneio_controle_frete
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        btn_exportar.Visible = True


        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = String.Concat(Me.txt_dt_inicio.Text.Trim, " 00:00:00")
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If

        If Not (txt_dt_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = String.Concat(Me.txt_dt_fim.Text.Trim, " 23:59:59")
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        ViewState.Item("id_grupo") = cbo_grupo.SelectedValue
        ViewState.Item("id_romaneio") = txt_id_romaneio.Text
        ViewState.Item("id_transit_point") = txt_id_transit_point.Text
        ViewState.Item("id_pre_romaneio") = txt_id_pre_romaneio.Text
        ViewState.Item("nm_linha") = txt_nm_linha.Text
        ViewState.Item("id_cooperativa") = Me.hf_id_cooperativa.Value
        ViewState.Item("cd_cooperativa") = txt_cd_cooperativa.Text.Trim()

        ViewState.Item("id_transvase") = txt_transvase.Text

        If Me.hf_id_cooperativa.Value.Equals(String.Empty) Then
            txt_cd_cooperativa.Text = String.Empty
        End If


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_controle_frete.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_controle_frete.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 194
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With btn_lupa_cooperativa
            .Attributes.Add("onclick", "javascript:ShowDialogCooperativa()")
            .ToolTip = "Filtrar Cooperativas"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            'fran dez/2018 i cooperativa
            Dim grupo As New Grupo
            cbo_grupo.DataSource = grupo.getGruposByFilters()
            cbo_grupo.DataTextField = "nm_grupo"
            cbo_grupo.DataValueField = "id_grupo"
            cbo_grupo.DataBind()
            cbo_grupo.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_grupo.Items.RemoveAt(2)   ' Remove item 2-Fornecedor de Insumos
            cbo_grupo.Items.RemoveAt(2)   ' Remove item 3-Transportador
            cbo_grupo.SelectedValue = 1   ' Assume como default na consulta o Produtor
            'fran dez/2018 f cooperativa

            ViewState.Item("sortExpression") = ""


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean


    '    If Not (customPage.getFilterValue("exportar3", dt_inicio.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("dt_fim") = customPage.getFilterValue("exportar", dt_inicio.ID)
    '        dt_inicio.Text = ViewState.Item("dt_fim").ToString()
    '    Else
    '        ViewState.Item("dt_fim") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("exportar3", dt_inicio.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("dt_inicio") = customPage.getFilterValue("exportar", dt_inicio.ID)
    '        dt_inicio.Text = ViewState.Item("dt_inicio").ToString()
    '    Else
    '        ViewState.Item("dt_inicio") = String.Empty
    '    End If
    '    'fran 27/11/2009 i chamado 527 Maracanau
    '    If Not (customPage.getFilterValue("exportar3", cbo_estabelecimento.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_estabelecimento") = customPage.getFilterValue("exportar", dt_inicio.ID)
    '        dt_inicio.Text = ViewState.Item("dt_inicio").ToString()
    '    Else
    '        ViewState.Item("dt_inicio") = String.Empty
    '    End If
    '    'fran 27/11/2009 f chamado 527 Maracanau

    '    If Not (customPage.getFilterValue("exportar3", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("exportar3", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("exportar")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio
            Dim dsromaneio As DataSet

            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                romaneio.dt_hora_entrada_ini = Convert.ToString(ViewState.Item("dt_inicio"))
            End If
            If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                romaneio.dt_hora_entrada_fim = Convert.ToString(ViewState.Item("dt_fim"))
            End If

            romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

            If Not ViewState.Item("id_romaneio").ToString.Equals(String.Empty) Then
                romaneio.id_romaneio = ViewState.Item("id_romaneio")
            End If

            'se cooperativa
            If ViewState.Item("id_grupo").ToString.Equals("4") Then
                txt_id_pre_romaneio.Text = String.Empty
                txt_id_transit_point.Text = String.Empty
                txt_nm_linha.Text = String.Empty
                ViewState.Item("id_transit_point") = String.Empty
                ViewState.Item("id_pre_romaneio") = String.Empty
                ViewState.Item("nm_linha") = String.Empty

                ViewState.Item("id_transvase") = String.Empty
                txt_transvase.Text = String.Empty

                If Trim(ViewState.Item("id_cooperativa")) <> "" Then
                    romaneio.id_cooperativa = Convert.ToInt32(ViewState.Item("id_cooperativa").ToString)
                End If

                dsromaneio = romaneio.getRomaneioControleFreteCooperativa
            Else
                txt_cd_cooperativa.Text = String.Empty
                hf_id_cooperativa.Value = String.Empty
                lbl_nm_cooperativa.Text = String.Empty
                ViewState.Item("id_cooperativa") = String.Empty
                ViewState.Item("cd_cooperativa") = String.Empty

                If Not ViewState.Item("id_transit_point").ToString.Equals(String.Empty) Then
                    romaneio.id_transit_point = ViewState.Item("id_transit_point")
                End If
                If Not ViewState.Item("id_transvase").ToString.Equals(String.Empty) Then
                    romaneio.id_transvase = ViewState.Item("id_transvase")
                End If
                If Not ViewState.Item("id_pre_romaneio").ToString.Equals(String.Empty) Then
                    romaneio.id_pre_romaneio_transit_point = ViewState.Item("id_pre_romaneio")
                End If
                romaneio.nm_linha = ViewState.Item("nm_linha").ToString

                dsromaneio = romaneio.getRomaneioControleFrete
            End If

            If (dsromaneio.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsromaneio.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then
            Try

                'romaneio
                If e.Row.Cells(2).Text = "0" Then
                    e.Row.Cells(2).Text = String.Empty
                End If
                'transit
                If e.Row.Cells(3).Text = "0" Then
                    e.Row.Cells(3).Text = String.Empty
                End If
                'transvase
                If e.Row.Cells(4).Text = "0" Then
                    e.Row.Cells(4).Text = String.Empty
                End If
                'pre romaneio
                If e.Row.Cells(5).Text = "0" Then
                    e.Row.Cells(5).Text = String.Empty
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If

    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = String.Concat(Me.txt_dt_inicio.Text.Trim, " 00:00:00")
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If

        If Not (txt_dt_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = String.Concat(Me.txt_dt_fim.Text.Trim, " 23:59:59")
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        ViewState.Item("id_grupo") = cbo_grupo.SelectedValue
        ViewState.Item("id_romaneio") = txt_id_romaneio.Text
        ViewState.Item("id_transit_point") = txt_id_transit_point.Text
        ViewState.Item("id_pre_romaneio") = txt_id_pre_romaneio.Text
        ViewState.Item("nm_linha") = txt_nm_linha.Text
        ViewState.Item("id_cooperativa") = Me.hf_id_cooperativa.Value
        ViewState.Item("cd_cooperativa") = txt_cd_cooperativa.Text.Trim()
        ViewState.Item("id_transvase") = txt_transvase.Text


        If Me.hf_id_cooperativa.Value.Equals(String.Empty) Then
            txt_cd_cooperativa.Text = String.Empty
        End If

        loadData()

        If gridResults.Rows.Count.ToString + 1 < 65536 Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 194
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            Response.Redirect("frm_romaneio_controle_frete_excel.aspx?dt_fim=" + ViewState.Item("dt_fim").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_grupo=" + ViewState.Item("id_grupo").ToString + "&id_transit_point=" + ViewState.Item("id_transit_point").ToString + "&id_transvase=" + ViewState.Item("id_transvase").ToString + "&id_pre_romaneio=" + ViewState.Item("id_pre_romaneio").ToString + "&id_romaneio=" + ViewState.Item("id_romaneio").ToString + "&nm_linha=" + ViewState.Item("nm_linha").ToString + "&id_cooperativa=" + ViewState.Item("id_cooperativa").ToString)
        Else
            messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
        End If
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
            'lbl_cd_cnpj.Text = String.Empty
            'lbl_cd_cnpj.Visible = False
            'Me.lbl_nm_cnpj.Visible = False
        End If

    End Sub

    Protected Sub txt_cd_cooperativa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_cooperativa.TextChanged
        If Not txt_cd_cooperativa.Text.Equals(String.Empty) Then
            loadCooperativaByCodigo()
        Else
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            hf_id_cooperativa.Value = String.Empty
            'lbl_cd_cnpj.Text = String.Empty
            'lbl_cd_cnpj.Visible = False
            'Me.lbl_nm_cnpj.Visible = False
        End If

    End Sub
    Private Sub loadCooperativaByCodigo()

        Try


            Dim cooperativa As New Pessoa
            cooperativa.cd_pessoa = txt_cd_cooperativa.Text
            Dim dscooperativa As DataSet = cooperativa.getCooperativasByCodigo()
            If dscooperativa.Tables(0).Rows.Count > 0 Then
                lbl_nm_cooperativa.Visible = True
                'lbl_cd_cnpj.Visible = True
                'Me.lbl_nm_cnpj.Visible = True
                lbl_nm_cooperativa.Text = dscooperativa.Tables(0).Rows(0).Item("nm_pessoa")
                'lbl_cd_cnpj.Text = dscooperativa.Tables(0).Rows(0).Item("cd_cnpj")
                hf_id_cooperativa.Value = dscooperativa.Tables(0).Rows(0).Item("id_pessoa")
            Else
                lbl_nm_cooperativa.Visible = False
                'lbl_cd_cnpj.Visible = False
                'Me.lbl_nm_cnpj.Visible = False
                hf_id_cooperativa.Value = String.Empty
            End If

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

            'If Not (customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").Equals(String.Empty)) Then
            '    Me.lbl_cd_cnpj.Visible = True
            '    Me.lbl_cd_cnpj.Text = customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").ToString
            '    Me.lbl_nm_cnpj.Visible = True
            'End If

            'loadData()
            customPage.clearFilters("lupa_cooperativa")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub





End Class

