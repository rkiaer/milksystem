Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_gestao_qualidade_home

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    'Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

    '    ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
    '    ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
    '    'ViewState.Item("id_pessoa") = String.Empty
    '    'ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
    '    'ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
    '    ViewState.Item("txt_dt_referencia") = Me.txt_dt_referencia.Text.Trim
    '    'ViewState.Item("id_grupo") = Me.cbo_Grupo.SelectedValue  ' adri 09/02/2017 - chamado 2500 acertos (filtro para Produtores / Cooperativas)

    '    loadData()

    'End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_gestao_qualidade_home.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_gestao_qualidade_home.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 212
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        'With img_lupa_produtor
        '    .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
        '    .ToolTip = "Filtrar Produtores"
        'End With
        'With btn_lupa_propriedade
        '    .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
        '    .ToolTip = "Filtrar Propriedades"
        'End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim codigoesalq As New CodigoEsalq

            estabelecimento.id_situacao = 1
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            'txt_dt_referencia.Text = DateTime.Parse(Now).ToString("MM/yyyy")
            'ViewState.Item("ano") = DateTime.Parse(Now).ToString("yyyy")
            'ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)
            'ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

            ViewState.Item("sortExpression") = ""

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("gestaoqualidade", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("gestaoqualidade", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = 1 'assume poços
        End If

        If Not (customPage.getFilterValue("gestaoqualidade", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("gestaoqualidade", txt_dt_referencia.ID)
            ViewState.Item("ano") = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("yyyy")
            txt_dt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("MM/yyyy")
        Else
            txt_dt_referencia.Text = DateTime.Parse(Now).ToString("MM/yyyy")
            ViewState.Item("ano") = DateTime.Parse(Now).ToString("yyyy")
            ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)

        End If

        If (hasFilters) Then
            'loadData()
            customPage.clearFilters("gestaoqualidade")
        End If

    End Sub

    'Private Sub loadData()

    '    Try
    '        Dim analiseesalq As New AnaliseEsalq

    '        If Trim(ViewState.Item("id_propriedade")) <> "" Then
    '            analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
    '        End If
    '        analiseesalq.dt_coleta_start = DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))
    '        analiseesalq.dt_coleta_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
    '        analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_coleta_ini")
    '        analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

    '        ' adri 08/02/2017 - chamado 2500 - acertos - Trazer Poços e Aguas Juntos - i
    '        If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
    '            analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
    '        Else
    '            analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
    '        End If
    '        analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
    '        ' adri 08/02/2017 - chamado 2500 - acertos - Trazer Poços e Aguas Juntos - f

    '        If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
    '            analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
    '        End If

    '        Dim dsAnaliseEsalc As DataSet = analiseesalq.getCurvaAbcProdutoresComplience()

    '        If (dsAnaliseEsalc.Tables(0).Rows.Count > 0) Then
    '            gridResults.Visible = True
    '            gridResults.DataSource = Helper.getDataView(dsAnaliseEsalc.Tables(0), ViewState.Item("sortExpression"))
    '            gridResults.DataBind()
    '        Else
    '            gridResults.Visible = False
    '            messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
    '        End If

    '        Dim dsComplienceVolumeTotal As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotal()

    '        ViewState.Item("nr_volume_total") = 0   ' Total do Volume da referencia (COMPL e NCOMPL)
    '        ViewState.Item("nr_produtores_total") = 0  ' Total de Produtores da referencia (COMPL e NCOMPL)
    '        If dsComplienceVolumeTotal.Tables(0).Rows.Count() > 0 Then
    '            ViewState.Item("nr_volume_total") = dsComplienceVolumeTotal.Tables(0).Rows(0).Item("nr_volume_total")   ' Total do Volume da referencia (COMPL e NCOMPL)
    '            ViewState.Item("nr_produtores_total") = dsComplienceVolumeTotal.Tables(0).Rows(0).Item("nr_produtores_total")   ' Total de Produtores da referencia (COMPL e NCOMPL)
    '        End If

    '        Dim dsComplienceSintetico As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceSintetico()

    '        If (dsComplienceSintetico.Tables(0).Rows.Count > 0) Then


    '            gridComplienceSintetico.Visible = True
    '            gridComplienceSintetico.DataSource = Helper.getDataView(dsComplienceSintetico.Tables(0), "")
    '            gridComplienceSintetico.DataBind()

    '            lbl_media_geometrica.Visible = True  ' adri 10/02/2017 - chamado 2500
    '            lbl_media_linear.Visible = True ' adri 10/02/2017 - chamado 2500
    '        End If




    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
    '    gridResults.PageIndex = e.NewPageIndex
    '    loadData()

    'End Sub


    'Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

    '    Select Case e.SortExpression.ToLower()

    '        Case "nm_estabelecimento"
    '            If (ViewState.Item("sortExpression")) = "nm_estabelecimento asc" Then
    '                ViewState.Item("sortExpression") = "nm_estabelecimento desc"
    '            Else
    '                ViewState.Item("sortExpression") = "nm_estabelecimento asc"
    '            End If
    '        Case "id_propriedade_matriz"
    '            If (ViewState.Item("sortExpression")) = "id_propriedade_matriz asc" Then
    '                ViewState.Item("sortExpression") = "id_propriedade_matriz desc"
    '            Else
    '                ViewState.Item("sortExpression") = "id_propriedade_matriz asc"
    '            End If


    '        Case "ds_propriedade"
    '            If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
    '                ViewState.Item("sortExpression") = "ds_propriedade desc"
    '            Else
    '                ViewState.Item("sortExpression") = "ds_propriedade asc"
    '            End If

    '        Case "nm_pessoa"
    '            If (ViewState.Item("sortExpression")) = "nm_pessoa asc" Then
    '                ViewState.Item("sortExpression") = "nm_pessoa desc"
    '            Else
    '                ViewState.Item("sortExpression") = "nm_pessoa asc"
    '            End If

    '    End Select

    '    loadData()

    'End Sub
    'Private Sub carregarCamposProdutor()

    '    Try

    '        If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
    '            Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
    '        Else
    '            lbl_nm_pessoa.Text = String.Empty
    '        End If

    '        If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
    '            Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
    '        Else
    '            txt_cd_pessoa.Text = String.Empty
    '            hf_id_pessoa.Value = String.Empty
    '        End If


    '        customPage.clearFilters("lupa_produtor")


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub
    'Private Sub carregarCamposPropriedade()

    '    Try

    '        Me.lbl_nm_propriedade.Text = String.Empty
    '        Me.txt_cd_propriedade.Text = String.Empty

    '        If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
    '            Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
    '        End If

    '        If Not hf_id_propriedade.Value.Equals(String.Empty) AndAlso CInt(hf_id_propriedade.Value.ToString) > 0 Then
    '            Me.txt_cd_propriedade.Text = Me.hf_id_propriedade.Value.ToString
    '        Else
    '            hf_id_propriedade.Value = String.Empty
    '        End If


    '        'If Not (customPage.getFilterValue("lupa_propriedade", "cd_pessoa").Equals(String.Empty)) Then
    '        '    Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "cd_pessoa").ToString
    '        'End If

    '        'If Not (customPage.getFilterValue("lupa_propriedade", "nm_pessoa").Equals(String.Empty)) Then
    '        '    Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "nm_pessoa").ToString
    '        'End If

    '        'If Not (customPage.getFilterValue("lupa_propriedade", "id_pessoa").Equals(String.Empty)) Then
    '        '    Me.hf_id_pessoa.Value = customPage.getFilterValue("lupa_propriedade", "id_pessoa").ToString
    '        'End If

    '        'loadData()
    '        customPage.clearFilters("lupa_propriedade")


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("gestaoqualidade", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("gestaoqualidade", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    '    If (e.Row.RowType = DataControlRowType.Header) Then
    '        Dim lbl_teor_ctm_mensal As Label = CType(e.Row.FindControl("lbl_teor_ctm_mensal"), Label)
    '        Dim lbl_teor_ctm_mensal1 As Label = CType(e.Row.FindControl("lbl_teor_ctm_mensal1"), Label)
    '        Dim lbl_teor_ctm_mensal2 As Label = CType(e.Row.FindControl("lbl_teor_ctm_mensal2"), Label)

    '        Dim lbl_teor_ccs_mensal As Label = CType(e.Row.FindControl("lbl_teor_ccs_mensal"), Label)
    '        Dim lbl_teor_ccs_mensal1 As Label = CType(e.Row.FindControl("lbl_teor_ccs_mensal1"), Label)
    '        Dim lbl_teor_ccs_mensal2 As Label = CType(e.Row.FindControl("lbl_teor_ccs_mensal2"), Label)

    '        lbl_teor_ctm_mensal.Text = DateTime.Parse(ViewState.Item("txt_dt_coleta_ini")).ToString("MMM").ToUpper
    '        lbl_teor_ctm_mensal1.Text = DateTime.Parse(DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper
    '        lbl_teor_ctm_mensal2.Text = DateTime.Parse(DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper

    '        lbl_teor_ccs_mensal.Text = DateTime.Parse(ViewState.Item("txt_dt_coleta_ini")).ToString("MMM").ToUpper
    '        lbl_teor_ccs_mensal1.Text = DateTime.Parse(DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper
    '        lbl_teor_ccs_mensal2.Text = DateTime.Parse(DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper

    '    End If

    '    If (e.Row.RowType <> DataControlRowType.Header _
    '        And e.Row.RowType <> DataControlRowType.Footer _
    '        And e.Row.RowType <> DataControlRowType.Pager) Then
    '        'fran 17/02/2017 i fran
    '        Dim lbl_nr_teor_ctm_mensal As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm_mensal"), Label)
    '        Dim lbl_nr_teor_ctm_mensal1 As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm_mensal1"), Label)
    '        Dim lbl_nr_teor_ctm_mensal2 As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm_mensal2"), Label)
    '        Dim lbl_nr_teor_ctm_tri As DataControlFieldCell = CType(e.Row.Cells(9), DataControlFieldCell)
    '        Dim lbl_nr_teor_ccs_mensal As Label = CType(e.Row.FindControl("lbl_nr_teor_ccs_mensal"), Label)
    '        Dim lbl_nr_teor_ccs_mensal1 As Label = CType(e.Row.FindControl("lbl_nr_teor_ccs_mensal1"), Label)
    '        Dim lbl_nr_teor_ccs_mensal2 As Label = CType(e.Row.FindControl("lbl_nr_teor_ccs_mensal2"), Label)
    '        Dim lbl_nr_teor_ccs_tri As DataControlFieldCell = CType(e.Row.Cells(14), DataControlFieldCell)

    '        lbl_nr_teor_ctm_mensal.Text = IIf(lbl_nr_teor_ctm_mensal.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ctm_mensal.Text, 0).ToString)
    '        lbl_nr_teor_ctm_mensal1.Text = IIf(lbl_nr_teor_ctm_mensal1.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ctm_mensal1.Text, 0).ToString)
    '        lbl_nr_teor_ctm_mensal2.Text = IIf(lbl_nr_teor_ctm_mensal2.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ctm_mensal2.Text, 0).ToString)
    '        lbl_nr_teor_ctm_tri.Text = IIf(lbl_nr_teor_ctm_tri.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ctm_tri.Text, 0).ToString)

    '        lbl_nr_teor_ccs_mensal.Text = IIf(lbl_nr_teor_ccs_mensal.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ccs_mensal.Text, 0).ToString)
    '        lbl_nr_teor_ccs_mensal1.Text = IIf(lbl_nr_teor_ccs_mensal1.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ccs_mensal1.Text, 0).ToString)
    '        lbl_nr_teor_ccs_mensal2.Text = IIf(lbl_nr_teor_ccs_mensal2.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ccs_mensal2.Text, 0).ToString)
    '        lbl_nr_teor_ccs_tri.Text = IIf(lbl_nr_teor_ccs_tri.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ccs_tri.Text, 0).ToString)
    '        'fran 17/02/2017 f fran 


    '    End If
    'End Sub

    'Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
    '    e.Cancel = True
    'End Sub

    'Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
    '    Me.lbl_nm_pessoa.Visible = True
    '    carregarCamposProdutor()

    'End Sub

    'Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged

    '    'lbl_nm_pessoa.Text = ""
    '    'lbl_nm_pessoa.Visible = False

    '    lbl_nm_pessoa.Text = String.Empty
    '    hf_id_pessoa.Value = String.Empty
    '    'fran 04/2017 i 
    '    Try
    '        If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
    '            Dim produtor As New Pessoa
    '            produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
    '            'produtor.id_situacao = 1
    '            produtor.id_grupo = 1 'produtores 'fran 05/05/2010
    '            Dim dsprodutor As DataSet = produtor.getPessoaByFilters
    '            'se encontrou produtor
    '            If dsprodutor.Tables(0).Rows.Count > 0 Then
    '                lbl_nm_pessoa.Enabled = True
    '                lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
    '                hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
    '            End If

    '        End If

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
    '    'If Me.cbo_estabelecimento.SelectedValue <> "0" Then
    '    'Me.lbl_nm_propriedade.Visible = True
    '    carregarCamposPropriedade()
    '    ' End If
    'End Sub

    'Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
    '    'lbl_nm_propriedade.Text = ""
    '    'lbl_nm_propriedade.Visible = False
    '    lbl_nm_propriedade.Text = String.Empty
    '    hf_id_propriedade.Value = String.Empty
    '    'Fran 04/2017
    '    Try
    '        If Not txt_cd_propriedade.Text.Equals(String.Empty) Then
    '            Dim propriedade As New Propriedade
    '            propriedade.id_propriedade = Convert.ToInt32(txt_cd_propriedade.Text.Trim)

    '            Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters
    '            If dspropriedade.Tables(0).Rows.Count > 0 Then
    '                lbl_nm_propriedade.Enabled = True
    '                lbl_nm_propriedade.Text = dspropriedade.Tables(0).Rows(0).Item("nm_propriedade")
    '                hf_id_propriedade.Value = dspropriedade.Tables(0).Rows(0).Item("id_propriedade").ToString
    '            End If

    '        End If
    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try
    '    'Fran 11/03/2010 chamado 684

    'End Sub


    'Protected Sub gridComplienceSintetico_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridComplienceSintetico.RowDataBound

    '    If (e.Row.RowType <> DataControlRowType.Header _
    'And e.Row.RowType <> DataControlRowType.Footer _
    'And e.Row.RowType <> DataControlRowType.Pager) Then

    '        Dim lbl_nr_volume_complience_perc As Label = CType(e.Row.FindControl("lbl_nr_volume_complience_perc"), Label)
    '        Dim lbl_nr_volume_complience As Label = CType(e.Row.FindControl("lbl_nr_volume_complience"), Label)

    '        Dim lbl_nr_volume_ncompl_perc As Label = CType(e.Row.FindControl("lbl_nr_volume_ncompl_perc"), Label)
    '        Dim lbl_nr_volume_ncompl As Label = CType(e.Row.FindControl("lbl_nr_volume_ncompl"), Label)

    '        If ViewState.Item("nr_volume_total") > 0 Then
    '            lbl_nr_volume_complience_perc.Text = (lbl_nr_volume_complience.Text / ViewState.Item("nr_volume_total")) * 100
    '            lbl_nr_volume_complience_perc.Text = FormatNumber(CDec(lbl_nr_volume_complience_perc.Text), 2)

    '            lbl_nr_volume_ncompl.Text = Convert.ToDouble(ViewState.Item("nr_volume_total")) - Convert.ToDouble(lbl_nr_volume_complience.Text)
    '            lbl_nr_volume_ncompl_perc.Text = (lbl_nr_volume_ncompl.Text / ViewState.Item("nr_volume_total")) * 100
    '            lbl_nr_volume_ncompl_perc.Text = FormatNumber(CDec(lbl_nr_volume_ncompl_perc.Text), 2)

    '        End If

    '        Dim lbl_nr_produtores_complience_perc As Label = CType(e.Row.FindControl("lbl_nr_produtores_complience_perc"), Label)
    '        Dim lbl_nr_produtores_complience As Label = CType(e.Row.FindControl("lbl_nr_produtores_complience"), Label)

    '        Dim lbl_nr_produtores_ncompl_perc As Label = CType(e.Row.FindControl("lbl_nr_produtores_ncompl_perc"), Label)
    '        Dim lbl_nr_produtores_ncompl As Label = CType(e.Row.FindControl("lbl_nr_produtores_ncompl"), Label)

    '        If ViewState.Item("nr_produtores_total") > 0 Then
    '            lbl_nr_produtores_complience_perc.Text = (lbl_nr_produtores_complience.Text / ViewState.Item("nr_produtores_total")) * 100
    '            lbl_nr_produtores_complience_perc.Text = FormatNumber(CDec(lbl_nr_produtores_complience_perc.Text), 2)

    '            lbl_nr_produtores_ncompl.Text = CInt(ViewState.Item("nr_produtores_total")) - CInt(lbl_nr_produtores_complience.Text)
    '            lbl_nr_produtores_ncompl_perc.Text = (lbl_nr_produtores_ncompl.Text / ViewState.Item("nr_produtores_total")) * 100
    '            lbl_nr_produtores_ncompl_perc.Text = FormatNumber(CDec(lbl_nr_produtores_ncompl_perc.Text), 2)
    '        End If

    '        ' Média Geometrica 
    '        Dim lbl_categoria As Label = CType(e.Row.FindControl("lbl_categoria"), Label)

    '        'If lbl_categoria.Text = "CBT" Or lbl_categoria.Text = "CCS" Then  ' adri 08/02/2017 - chamado 2500 - acertos (calcular para todas as categorias)

    '        Dim lbl_nr_media_geo_mensal As Label = CType(e.Row.FindControl("lbl_nr_media_geo_mensal"), Label)
    '        Dim lbl_nr_media_geo_trimestral As Label = CType(e.Row.FindControl("lbl_nr_media_geo_trimestral"), Label)
    '        Dim analiseesalq As New AnaliseEsalq

    '        analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_coleta_ini")
    '        analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
    '        ' adri 08/02/2017 - chamado 2500 - acertos - Trazer Poços e Aguas Juntos - i
    '        If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
    '            analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
    '        Else
    '            analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
    '        End If
    '        analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
    '        ' adri 08/02/2017 - chamado 2500 - acertos - Trazer Poços e Aguas Juntos - f


    '        If Left(lbl_categoria.Text, 3) = "CBT" Then  ' CBT/CTM
    '            analiseesalq.id_conta_teor_mensal = "264"   ' conta 0093
    '            analiseesalq.id_conta_teor_trimestral = "252"  ' conta 0092
    '        End If

    '        If Left(lbl_categoria.Text, 3) = "CCS" Then  ' CCS
    '            analiseesalq.id_conta_teor_mensal = "265"  ' conta 0106
    '            analiseesalq.id_conta_teor_trimestral = "253"  ' conta 0105
    '        End If

    '        ' adri 10/02/2017 - chamado 2500 acertos (calcular médias também para proteína e Gordura - i
    '        If Left(lbl_categoria.Text, 8) = "Proteína" Then  ' Proteína
    '            analiseesalq.id_conta_teor_mensal = "251"  ' conta 0082
    '            analiseesalq.id_conta_teor_trimestral = "251"  ' conta 0082 (repete porque não tem teor trimestral, no excel da Giovana os valores se repetem)
    '        End If

    '        If Left(lbl_categoria.Text, 7) = "Gordura" Then  ' Gordura
    '            analiseesalq.id_conta_teor_mensal = "156"  ' conta 0152
    '            analiseesalq.id_conta_teor_trimestral = "156"  ' conta 0152 (repete porque não tem teor trimestral, no excel da Giovana os valores se repetem)
    '        End If
    '        ' adri 10/02/2017 - chamado 2500 acertos (calcular médias também para proteína e Gordura - f

    '        If ViewState.Item("nr_volume_total") > 0 Then

    '            Dim dsMediaGeo As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeo()
    '            'fran 05/2017 i a procedure ja traz apenas os que devem participar do complieance
    '            'Dim dsVolumeDesprezadoTeorMensal As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalDesprezado()  ' adri 13/02/2017 - chamado 2500 - apurar volume total das propriedades sem teor ou teor zero
    '            'fran 05/2017 f
    '            Dim lvolumetotal As Decimal
    '            ' Definição da Giovana e Danone: Se não exisitr qualidade para o mes (teor igual a zero), o volume desta propriedade deve ser desprezado para o cálculo das duas médias ponderadas (mensal e trimestral)
    '            'fran 05/2017 i a procedure ja traz apenas os que devem participar do complieance
    '            'lvolumetotal = ViewState.Item("nr_volume_total") - dsVolumeDesprezadoTeorMensal.Tables(0).Rows(0).Item("nr_volume_teor_mensal_desprezado")
    '            lvolumetotal = ViewState.Item("nr_volume_total")
    '            'fran 05/2017 f

    '            If lvolumetotal > 0 Then

    '                ' adri 10/02/2017 - chamado 2500 acertos (calcular médias também para proteína e Gordura - i
    '                If Left(lbl_categoria.Text, 8) = "Proteína" Or Left(lbl_categoria.Text, 7) = "Gordura" Then
    '                    'lbl_nr_media_geo_mensal.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_mensal") / ViewState.Item("nr_volume_total"), 2) + "²"
    '                    'lbl_nr_media_geo_trimestral.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_trimestral") / ViewState.Item("nr_volume_total"), 4) + "²"
    '                    lbl_nr_media_geo_mensal.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_mensal") / lvolumetotal, 2)   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
    '                    'lbl_nr_media_geo_trimestral.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_trimestral") / lvolumetotal, 4)  ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal (mesmo que o trimestral) igual a zero ou null
    '                    lbl_nr_media_geo_trimestral.Text = String.Empty
    '                Else
    '                    ' adri 10/02/2017 - chamado 2500 acertos (calcular médias também para proteína e Gordura - f
    '                    'lbl_nr_media_geo_mensal.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_mensal") / ViewState.Item("nr_volume_total"), 0) + "¹"
    '                    'lbl_nr_media_geo_trimestral.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_trimestral") / ViewState.Item("nr_volume_total"), 0) + "¹"
    '                    lbl_nr_media_geo_mensal.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_mensal") / lvolumetotal, 0)   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
    '                    lbl_nr_media_geo_trimestral.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_trimestral") / lvolumetotal, 0)
    '                End If
    '            End If

    '        End If

    '        'End If ' Se CBT ou CCS


    '    End If


    'End Sub

    ''Mirella - 08/02/2017 - i
    'Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

    '    ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
    '    ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
    '    'ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
    '    ViewState.Item("dt_referencia") = Me.txt_dt_referencia.Text.Trim
    '    'ViewState.Item("id_grupo") = Me.cbo_Grupo.SelectedValue  ' adri 09/02/2017 - chamado 2500 acertos (filtro para Produtores / Cooperativas)


    '    'customPage.clearFilters("farmerspayment")

    '    'saveFilters()
    '    'FRAN 08/12/2020 i incluir log 
    '    Dim usuariolog As New UsuarioLog
    '    usuariolog.id_usuario = Session("id_login")
    '    usuariolog.ds_id_session = Session.SessionID.ToString()
    '    usuariolog.id_tipo_log = 8 'exporta~ção
    '    usuariolog.id_menu_item = 174
    '    usuariolog.insertUsuarioLog()
    '    'FRAN 08/12/2020  incluir log 

    '    Response.Redirect("frm_curvaabc_produtores_complience_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&txt_dt_coleta_ini=" + ViewState.Item("txt_dt_coleta_ini").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString())  ' adri 09/02/2017 - chamado 2500 acertos (incluir grupo no filtro)

    'End Sub
    ''Mirella - 08/02/2017 - f


    Protected Sub btn_danone_curvagestao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_danone_curvagestao.Click
        If Page.IsValid Then
            Try
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("dt_referencia") = "01/" & Me.txt_dt_referencia.Text.Trim
                ViewState.Item("ano") = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("yyyy")


                loadCurvaABCGestao()

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If
    End Sub
    Private Sub loadCurvaABCGestao()

        Try

            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 212
            usuariolog.ds_nm_processo = "Curva ABC Gestão"
            usuariolog.insertUsuarioLog()

            saveFilters()

            Response.Redirect("frm_gestao_qualidade_curvaabc_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString() + "&ano=" + ViewState.Item("ano").ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_educampo_curvagestao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_educampo_curvagestao.Click
        If Page.IsValid Then
            Try

                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("dt_referencia") = "01/" & Me.txt_dt_referencia.Text.Trim
                ViewState.Item("ano") = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("yyyy")

                loadCurvaABCGestao()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub btn_comquali_curvagestao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_comquali_curvagestao.Click
        If Page.IsValid Then
            Try
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("dt_referencia") = "01/" & Me.txt_dt_referencia.Text.Trim
                ViewState.Item("ano") = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("yyyy")

                loadCurvaABCGestao()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub btn_danone_base_epl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_danone_base_epl.Click
        If Page.IsValid Then


            Try
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("dt_referencia") = "01/" & Me.txt_dt_referencia.Text.Trim
                ViewState.Item("ano") = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("yyyy")

                saveFilters()

                Response.Redirect("lst_gestao_qualidade_dados_epl.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString() + "&ano=" + ViewState.Item("ano").ToString())


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub txt_dt_referencia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dt_referencia.TextChanged

    End Sub

    Protected Sub btn_danone_evolucao_bonus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_danone_evolucao_bonus.Click

    End Sub

    Protected Sub btn_danone_in76_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_danone_in76.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia") = "01/" & Me.txt_dt_referencia.Text.Trim
        ViewState.Item("ano") = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("yyyy")


        ViewState.Item("id_pessoa") = 0
        ViewState.Item("cd_pessoa") = String.Empty
        ViewState.Item("id_propriedade") = 0
        ViewState.Item("id_grupo") = 1
        ViewState.Item("tipopropriedade") = String.Empty
        ViewState.Item("categoriatecnico") = String.Empty
        ViewState.Item("situacaorelatorio") = String.Empty
        ViewState.Item("id_tecnico") = "0"

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 202
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        Response.Redirect("frm_curvaabc_in76_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&txt_dt_coleta_ini=" + ViewState.Item("dt_referencia").ToString() + "&id_tecnico=" + ViewState.Item("id_tecnico").ToString() + "&categoriatecnico=" + ViewState.Item("categoriatecnico").ToString() + "&tipopropriedade=" + ViewState.Item("tipopropriedade").ToString() + "&situacaorelatorio=" + ViewState.Item("situacaorelatorio").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString())

    End Sub

    Protected Sub btn_educampo_evolucao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_educampo_evolucao.Click

    End Sub

    Protected Sub btn_educampo_saving_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_educampo_saving.Click

    End Sub

    Protected Sub btn_educampo_base_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_educampo_base.Click

    End Sub

    Protected Sub btn_comquali_base_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_comquali_base.Click

    End Sub
End Class
