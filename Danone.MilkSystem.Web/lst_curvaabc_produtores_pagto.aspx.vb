Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_curvaabc_produtores_pagto

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("txt_dt_coleta_ini") = Me.txt_dt_coleta_ini.Text.Trim
        ViewState.Item("id_categoria") = Me.cbo_categoria_qualidade.SelectedValue
        ViewState.Item("id_grupo") = Me.cbo_grupo.SelectedValue  '10/02/2017 - chamado 2501 - Mirella
        If rb_st_tipo_pagto_d.Checked = True Then
            ViewState.Item("st_pagamento") = "D"
        Else
            ViewState.Item("st_pagamento") = "P"
        End If
        If txt_cd_tecnico.Text.Equals(String.Empty) Then
            ViewState.Item("id_tecnico") = "0"
        Else
            ViewState.Item("id_tecnico") = Me.hf_id_tecnico.Value
        End If
        ViewState.Item("st_categoria_tecnico") = cbo_categoria.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_curvaabc_produtores_pagto.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_curvaabc_produtores_pagto.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 173
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
        End With
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With
        With img_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialogTecnico()")
            .ToolTip = "Filtrar Técnicos"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim codigoesalq As New CodigoEsalq

            'fran 05/2017
            'cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            'cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            'cbo_estabelecimento.DataValueField = "id_estabelecimento"
            'cbo_estabelecimento.DataBind()
            'cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim categoria As New CategoriaQualidade
            cbo_categoria_qualidade.DataSource = categoria.getCategoriaComplience()
            cbo_categoria_qualidade.DataTextField = "nm_categoria"
            cbo_categoria_qualidade.DataValueField = "id_categoria"
            cbo_categoria_qualidade.DataBind()
            cbo_categoria_qualidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            estabelecimento.id_situacao = 1 '10/02/2017 - chamado 2501 - Mirella i
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_estabelecimento.Items.RemoveAt(2)


            Dim grupo As New Grupo
            cbo_Grupo.DataSource = grupo.getGruposByFilters()
            cbo_Grupo.DataTextField = "nm_grupo"
            cbo_Grupo.DataValueField = "id_grupo"
            cbo_Grupo.DataBind()
            cbo_Grupo.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_Grupo.Items.RemoveAt(2)   ' Remove item 2-Fornecedor de Insumos
            cbo_Grupo.Items.RemoveAt(2)   ' Remove item 3-Transportador
            cbo_Grupo.SelectedValue = 1   ' Assume como default na consulta o Produtor

            '10/02/2017 - chamado 2501 - Mirella f


            txt_dt_coleta_ini.Text = DateTime.Parse(Now).ToString("MM/yyyy")

            ViewState.Item("sortExpression") = "id_propriedade asc, id_unid_producao"

            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean

    '    If Not (customPage.getFilterValue("farmerspayment", cbo_estabelecimento.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_estabelecimento") = customPage.getFilterValue("farmerspayment", cbo_estabelecimento.ID)
    '        Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
    '    Else
    '        ViewState.Item("id_estabelecimento") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("farmerspayment", txt_cd_pessoa.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("cd_pessoa") = customPage.getFilterValue("farmerspayment", txt_cd_pessoa.ID)
    '        txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
    '    Else
    '        ViewState.Item("cd_pessoa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("farmerspayment", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("nm_pessoa") = customPage.getFilterValue("farmerspayment", lbl_nm_pessoa.ID)
    '        lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
    '    Else
    '        ViewState.Item("nm_pessoa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("farmerspayment", txt_cd_propriedade.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_propriedade") = customPage.getFilterValue("farmerspayment", txt_cd_propriedade.ID)
    '        txt_cd_propriedade.Text = ViewState.Item("id_propriedade").ToString()

    '    Else
    '        ViewState.Item("id_propriedade") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("farmerspayment(", lbl_nm_propriedade.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("nm_propriedade") = customPage.getFilterValue("farmerspayment", lbl_nm_propriedade.ID)
    '        lbl_nm_propriedade.Text = ViewState.Item("nm_propriedade").ToString()
    '        hf_id_propriedade.Value = ViewState.Item("id_propriedade")
    '    Else
    '        ViewState.Item("nm_propriedade") = String.Empty
    '        hf_id_propriedade.Value = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("farmerspayment", hf_id_pessoa.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_pessoa") = customPage.getFilterValue("farmerspayment", hf_id_pessoa.ID)
    '        hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
    '    Else
    '        ViewState.Item("id_pessoa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("farmerspayment", txt_dt_coleta_ini.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("txt_dt_coleta_ini") = customPage.getFilterValue("farmerspayment", txt_dt_coleta_ini.ID)
    '        txt_dt_coleta_ini.Text = ViewState.Item("txt_dt_coleta_ini").ToString()
    '    Else
    '        ViewState.Item("txt_dt_coleta_ini") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("farmerspayment", cbo_categoria_qualidade.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_categoria") = customPage.getFilterValue("farmerspayment", cbo_categoria_qualidade.ID)
    '        cbo_categoria_qualidade.Text = ViewState.Item("id_categoria").ToString()
    '    Else
    '        ViewState.Item("id_categoria") = String.Empty
    '    End If


    '    '10/02/2017 - chamado 2501 - Mirella i
    '    If Not (customPage.getFilterValue("farmerspayment", cbo_Grupo.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_grupo") = customPage.getFilterValue("farmerspayment", cbo_Grupo.ID)
    '        Me.cbo_Grupo.Text = ViewState.Item("id_grupo").ToString()
    '    Else
    '        ViewState.Item("id_grupo") = String.Empty
    '    End If
    '    '10/02/2017 - chamado 2501 - Mirella f

    '    '14/02/2017 - chamado 2501 - Mirella i
    '    If (customPage.getFilterValue("farmerspayment", rb_st_tipo_pagto_d.ID).Equals(String.Empty)) Then
    '        ViewState.Item("st_pagamento") = "D"
    '        rb_st_tipo_pagto_d.Checked = True
    '    Else
    '        If (customPage.getFilterValue("farmerspayment", rb_st_tipo_pagto_d.ID).ToString.Trim = "D") Then
    '            hasFilters = True
    '            ViewState.Item("st_pagamento") = "D"
    '            rb_st_tipo_pagto_p.Checked = True
    '        Else
    '            hasFilters = True
    '            ViewState.Item("st_pagamento") = "P"
    '            rb_st_tipo_pagto_p.Checked = True
    '        End If

    '    End If
    '    '14/02/2017 - chamado 2501 - Mirella f


    '    If Not (customPage.getFilterValue("farmerspayment", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("farmerspayment", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("farmerspayment")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim analiseesalq As New AnaliseEsalq
            Dim dsAnaliseEsalc As DataSet
           
            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            If Trim(ViewState.Item("id_pessoa")) <> "" Then
                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            End If
            analiseesalq.dt_coleta_start = DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))
            analiseesalq.dt_coleta_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
            analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_coleta_ini")
            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            '10/02/2017 - chamado 2501 - Mirella i
            If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            Else
                analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            End If
            analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
            '10/02/2017 - chamado 2501 - Mirella f

            analiseesalq.st_pagamento = ViewState.Item("st_pagamento") '10/02/2017 - chamado 2501 - Mirella 
            analiseesalq.st_categoria_tecnico = ViewState.Item("st_categoria_tecnico").ToString

            If Trim(ViewState.Item("id_tecnico").ToString) <> "0" Then
                analiseesalq.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)
            End If

            Select Case ViewState.Item("id_categoria")
                Case ViewState.Item("id_categoria") = "1" 'CCS
                    ViewState.Item("cd_analise_esalq") = "53"

                    analiseesalq.cd_analise_esalq = 53
                    analiseesalq.id_conta_teor = "253"
                    analiseesalq.id_conta_bonus = "10"
                    analiseesalq.id_conta_desconto = "11"
                    analiseesalq.id_conta_teor_complience = "274"
                    dsAnaliseEsalc = analiseesalq.getCurvaAbcProdutoresPagamento_Cat1() 'fran 26/10/2020 i

                Case ViewState.Item("id_categoria") = "2" 'CTM
                    ViewState.Item("cd_analise_esalq") = "52"
                    analiseesalq.cd_analise_esalq = 52
                    analiseesalq.id_conta_teor = "252"
                    analiseesalq.id_conta_bonus = "8"
                    analiseesalq.id_conta_desconto = "9"
                    analiseesalq.id_conta_teor_complience = "273"
                    dsAnaliseEsalc = analiseesalq.getCurvaAbcProdutoresPagamento_Cat2() 'fran 26/10/2020 i

                Case ViewState.Item("id_categoria") = "3" 'Proteina
                    ViewState.Item("cd_analise_esalq") = "11"
                    analiseesalq.cd_analise_esalq = 11
                    analiseesalq.id_conta_teor = "251"
                    analiseesalq.id_conta_bonus = "6"
                    analiseesalq.id_conta_desconto = "7"
                    analiseesalq.id_conta_teor_complience = "272"
                    dsAnaliseEsalc = analiseesalq.getCurvaAbcProdutoresPagamento_Cat3() 'fran 26/10/2020 i

                Case ViewState.Item("id_categoria") = "4" 'MG
                    ViewState.Item("cd_analise_esalq") = "8"
                    analiseesalq.cd_analise_esalq = 8
                    analiseesalq.id_conta_teor = "156"
                    analiseesalq.id_conta_bonus = "224"
                    analiseesalq.id_conta_desconto = "225"
                    analiseesalq.id_conta_teor_complience = "275"
                    dsAnaliseEsalc = analiseesalq.getCurvaAbcProdutoresPagamento_Cat4() 'fran 26/10/2020 i

            End Select


            'Dim dsAnaliseEsalc As DataSet = analiseesalq.getCurvaAbcProdutoresPagamento()

            If (dsAnaliseEsalc.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsAnaliseEsalc.Tables(0), ViewState.Item("sortExpression"))
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

        'Select Case e.SortExpression.ToLower()


        'End Select

        'loadData()

    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            Else
                lbl_nm_pessoa.Text = String.Empty
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            Else
                txt_cd_pessoa.Text = String.Empty
                hf_id_pessoa.Value = String.Empty
            End If


            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposPropriedade()

        Try

            Me.lbl_nm_propriedade.Text = String.Empty
            Me.txt_cd_propriedade.Text = String.Empty

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If

            If Not hf_id_propriedade.Value.Equals(String.Empty) AndAlso CInt(hf_id_propriedade.Value.ToString) > 0 Then
                Me.txt_cd_propriedade.Text = Me.hf_id_propriedade.Value.ToString
            Else
                hf_id_propriedade.Value = String.Empty
            End If

            'If Not (customPage.getFilterValue("lupa_propriedade", "cd_pessoa").Equals(String.Empty)) Then
            '    Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "cd_pessoa").ToString
            'End If

            'If Not (customPage.getFilterValue("lupa_propriedade", "nm_pessoa").Equals(String.Empty)) Then
            '    Me.lbl_nm_pessoa.Visible = True
            '    Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "nm_pessoa").ToString
            'End If

            'If Not (customPage.getFilterValue("lupa_propriedade", "id_pessoa").Equals(String.Empty)) Then
            '    Me.hf_id_pessoa.Value = customPage.getFilterValue("lupa_propriedade", "id_pessoa").ToString
            'End If

            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposTecnico()

        Try

            Me.txt_cd_tecnico.Text = hf_id_tecnico.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    'Private Sub saveFilters()

    '    Try


    '        customPage.setFilter("analise_esaq", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
    '        customPage.setFilter("analise_esaq", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
    '        customPage.setFilter("analise_esaq", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
    '        customPage.setFilter("analise_esaq", txt_cd_propriedade.ID, ViewState.Item("id_propriedade").ToString)
    '        customPage.setFilter("analise_esaq", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
    '        customPage.setFilter("analise_esaq", lbl_nm_propriedade.ID, ViewState.Item("nm_propriedade").ToString)
    '        customPage.setFilter("analise_esaq", txt_dt_coleta_ini.ID, ViewState.Item("txt_dt_coleta_ini").ToString)
    '        customPage.setFilter("analise_esaq", cbo_categoria_qualidade.ID, ViewState.Item("id_categoria").ToString)
    '        customPage.setFilter("analise_esaq", cbo_grupo.ID, ViewState.Item("id_grupo").ToString)  '10/02/2017 - chamado 2501 - Mirella
    '        customPage.setFilter("analise_esaq", rb_st_tipo_pagto_d.ID, ViewState.Item("st_pagamento").ToString)  '14/02/2017 - chamado 2501 - Mirella
    '        customPage.setFilter("analise_esaq", rb_st_tipo_pagto_p.ID, ViewState.Item("st_pagamento").ToString)  '14/02/2017 - chamado 2501 - Mirella


    '        customPage.setFilter("analise_esaq", "PageIndex", gridResults.PageIndex.ToString())

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType = DataControlRowType.Header) Then

            Dim lbl_mes1_coleta1 As Label = CType(e.Row.FindControl("lbl_mes1_coleta1"), Label)
            Dim lbl_mes1_coleta2 As Label = CType(e.Row.FindControl("lbl_mes1_coleta2"), Label)
            Dim lbl_mes1_coleta3 As Label = CType(e.Row.FindControl("lbl_mes1_coleta3"), Label)
            Dim lbl_mes1_coleta4 As Label = CType(e.Row.FindControl("lbl_mes1_coleta4"), Label)
            Dim lbl_mes1_recoleta As Label = CType(e.Row.FindControl("lbl_mes1_recoleta"), Label)


            Dim lbl_mes2_coleta1 As Label = CType(e.Row.FindControl("lbl_mes2_coleta1"), Label)
            Dim lbl_mes2_coleta2 As Label = CType(e.Row.FindControl("lbl_mes2_coleta2"), Label)
            Dim lbl_mes2_coleta3 As Label = CType(e.Row.FindControl("lbl_mes2_coleta3"), Label)
            Dim lbl_mes2_coleta4 As Label = CType(e.Row.FindControl("lbl_mes2_coleta4"), Label)
            Dim lbl_mes2_recoleta As Label = CType(e.Row.FindControl("lbl_mes2_recoleta"), Label)


            Dim lbl_mes3_coleta1 As Label = CType(e.Row.FindControl("lbl_mes3_coleta1"), Label)
            Dim lbl_mes3_coleta2 As Label = CType(e.Row.FindControl("lbl_mes3_coleta2"), Label)
            Dim lbl_mes3_coleta3 As Label = CType(e.Row.FindControl("lbl_mes3_coleta3"), Label)
            Dim lbl_mes3_coleta4 As Label = CType(e.Row.FindControl("lbl_mes3_coleta4"), Label)
            Dim lbl_mes3_recoleta As Label = CType(e.Row.FindControl("lbl_mes3_recoleta"), Label)


            Dim mes1, mes2, mes3 As String
            mes3 = DateTime.Parse(ViewState.Item("txt_dt_coleta_ini")).ToString("MMM").ToUpper
            mes2 = DateTime.Parse(DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper
            mes1 = DateTime.Parse(DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper

            lbl_mes3_coleta1.Text = mes3
            lbl_mes3_coleta2.Text = mes3
            lbl_mes3_coleta3.Text = mes3
            lbl_mes3_coleta4.Text = mes3
            lbl_mes3_recoleta.Text = mes3

            lbl_mes2_coleta1.Text = mes2
            lbl_mes2_coleta2.Text = mes2
            lbl_mes2_coleta3.Text = mes2
            lbl_mes2_coleta4.Text = mes2
            lbl_mes2_recoleta.Text = mes2

            lbl_mes1_coleta1.Text = mes1
            lbl_mes1_coleta2.Text = mes1
            lbl_mes1_coleta3.Text = mes1
            lbl_mes1_coleta4.Text = mes1
            lbl_mes1_recoleta.Text = mes1

        End If

        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            Dim lbl_id_propriedade As Label = CType(e.Row.FindControl("lbl_id_propriedade"), Label)
            Dim lbl_nr_m1_coleta1 As Label = CType(e.Row.FindControl("lbl_nr_m1_coleta1"), Label)
            Dim lbl_nr_m1_coleta2 As Label = CType(e.Row.FindControl("lbl_nr_m1_coleta2"), Label)
            Dim lbl_nr_m1_coleta3 As Label = CType(e.Row.FindControl("lbl_nr_m1_coleta3"), Label)
            Dim lbl_nr_m1_coleta4 As Label = CType(e.Row.FindControl("lbl_nr_m1_coleta4"), Label)

            Dim lbl_nr_m2_coleta1 As Label = CType(e.Row.FindControl("lbl_nr_m2_coleta1"), Label)
            Dim lbl_nr_m2_coleta2 As Label = CType(e.Row.FindControl("lbl_nr_m2_coleta2"), Label)
            Dim lbl_nr_m2_coleta3 As Label = CType(e.Row.FindControl("lbl_nr_m2_coleta3"), Label)
            Dim lbl_nr_m2_coleta4 As Label = CType(e.Row.FindControl("lbl_nr_m2_coleta4"), Label)

            Dim lbl_nr_m3_coleta1 As Label = CType(e.Row.FindControl("lbl_nr_m3_coleta1"), Label)
            Dim lbl_nr_m3_coleta2 As Label = CType(e.Row.FindControl("lbl_nr_m3_coleta2"), Label)
            Dim lbl_nr_m3_coleta3 As Label = CType(e.Row.FindControl("lbl_nr_m3_coleta3"), Label)
            Dim lbl_nr_m3_coleta4 As Label = CType(e.Row.FindControl("lbl_nr_m3_coleta4"), Label)

            Dim lbl_nr_m1_recoleta1 As Label = CType(e.Row.FindControl("lbl_nr_m1_recoleta1"), Label)
            Dim lbl_nr_m1_recoleta2 As Label = CType(e.Row.FindControl("lbl_nr_m1_recoleta2"), Label)
            Dim lbl_nr_m1_recoleta3 As Label = CType(e.Row.FindControl("lbl_nr_m1_recoleta3"), Label)
            Dim lbl_nr_m1_recoleta4 As Label = CType(e.Row.FindControl("lbl_nr_m1_recoleta4"), Label)

            Dim lbl_nr_m2_recoleta1 As Label = CType(e.Row.FindControl("lbl_nr_m2_recoleta1"), Label)
            Dim lbl_nr_m2_recoleta2 As Label = CType(e.Row.FindControl("lbl_nr_m2_recoleta2"), Label)
            Dim lbl_nr_m2_recoleta3 As Label = CType(e.Row.FindControl("lbl_nr_m2_recoleta3"), Label)
            Dim lbl_nr_m2_recoleta4 As Label = CType(e.Row.FindControl("lbl_nr_m2_recoleta4"), Label)

            Dim lbl_nr_m3_recoleta1 As Label = CType(e.Row.FindControl("lbl_nr_m3_recoleta1"), Label)
            Dim lbl_nr_m3_recoleta2 As Label = CType(e.Row.FindControl("lbl_nr_m3_recoleta2"), Label)
            Dim lbl_nr_m3_recoleta3 As Label = CType(e.Row.FindControl("lbl_nr_m3_recoleta3"), Label)
            Dim lbl_nr_m3_recoleta4 As Label = CType(e.Row.FindControl("lbl_nr_m3_recoleta4"), Label)

            Dim lbl_m1_st_recoleta_S As Label = CType(e.Row.FindControl("lbl_m1_st_recoleta_S"), Label)
            Dim lbl_m2_st_recoleta_S As Label = CType(e.Row.FindControl("lbl_m2_st_recoleta_S"), Label)
            Dim lbl_m3_st_recoleta_S As Label = CType(e.Row.FindControl("lbl_m3_st_recoleta_S"), Label)

            Dim lbl_nr_bonus As Label = CType(e.Row.FindControl("lbl_nr_bonus"), Label)
            Dim lbl_nr_teor As Label = CType(e.Row.FindControl("lbl_nr_teor"), Label)

            Dim lbl_nr_volume As Label = CType(e.Row.FindControl("lbl_nr_volume"), Label)

            lbl_nr_volume.Text = FormatNumber(lbl_nr_volume.Text, 0)
            If Not lbl_nr_bonus.Text.Equals(String.Empty) Then
                lbl_nr_bonus.Text = FormatNumber(lbl_nr_bonus.Text, 2)
            End If

            Dim ldecimal As Integer
            'se categoria 1 ou 2 ccs ou cbt
            If ViewState.Item("id_categoria") = 1 OrElse ViewState.Item("id_categoria") = 2 Then
                ldecimal = 0
            Else
                ldecimal = 4
            End If

            If Not lbl_nr_teor.Text.Equals(String.Empty) Then
                lbl_nr_teor.Text = FormatNumber(lbl_nr_teor.Text, ldecimal)
            End If

            'CAMPOS DA REFERENCIA MENOS 2 MESes 
            If lbl_nr_m1_coleta1.Text.Equals(String.Empty) Then
                lbl_nr_m1_coleta1.Text = "---"
            Else
                lbl_nr_m1_coleta1.Text = FormatNumber(lbl_nr_m1_coleta1.Text, ldecimal).ToString
            End If
            If lbl_nr_m1_coleta2.Text.Equals(String.Empty) Then
                lbl_nr_m1_coleta2.Text = "---"
            Else
                lbl_nr_m1_coleta2.Text = FormatNumber(lbl_nr_m1_coleta2.Text, ldecimal).ToString
            End If
            If lbl_nr_m1_coleta3.Text.Equals(String.Empty) Then
                lbl_nr_m1_coleta3.Text = "---"
            Else
                lbl_nr_m1_coleta3.Text = FormatNumber(lbl_nr_m1_coleta3.Text, ldecimal).ToString
            End If
            If lbl_nr_m1_coleta4.Text.Equals(String.Empty) Then
                lbl_nr_m1_coleta4.Text = "---"
            Else
                lbl_nr_m1_coleta4.Text = FormatNumber(lbl_nr_m1_coleta4.Text, ldecimal).ToString
            End If

            'se todas as recoletas sao vazias
            If lbl_nr_m1_recoleta1.Text = "" AndAlso lbl_nr_m1_recoleta2.Text = "" AndAlso lbl_nr_m1_recoleta3.Text = "" AndAlso lbl_nr_m1_recoleta4.Text = "" Then
                lbl_m1_st_recoleta_S.Visible = False
            Else
                lbl_m1_st_recoleta_S.Visible = True
                lbl_nr_m1_recoleta1.Visible = True
                lbl_nr_m1_recoleta2.Visible = True
                lbl_nr_m1_recoleta3.Visible = True
                lbl_nr_m1_recoleta4.Visible = True

                If lbl_nr_m1_recoleta1.Text.Equals(String.Empty) Then
                    lbl_nr_m1_recoleta1.Text = "---"
                Else
                    lbl_nr_m1_recoleta1.Text = FormatNumber(lbl_nr_m1_recoleta1.Text, ldecimal).ToString
                End If
                If lbl_nr_m1_recoleta2.Text.Equals(String.Empty) Then
                    lbl_nr_m1_recoleta2.Text = "---"
                Else
                    lbl_nr_m1_recoleta2.Text = FormatNumber(lbl_nr_m1_recoleta2.Text, ldecimal).ToString
                End If
                If lbl_nr_m1_recoleta3.Text.Equals(String.Empty) Then
                    lbl_nr_m1_recoleta3.Text = "---"
                Else
                    lbl_nr_m1_recoleta3.Text = FormatNumber(lbl_nr_m1_recoleta3.Text, ldecimal).ToString
                End If
                If lbl_nr_m1_recoleta4.Text.Equals(String.Empty) Then
                    lbl_nr_m1_recoleta4.Text = "---"
                Else
                    lbl_nr_m1_recoleta4.Text = FormatNumber(lbl_nr_m1_recoleta4.Text, ldecimal).ToString
                End If

            End If

            'CAMPOS DA REFERENCIA MENOS 1 MES
            If lbl_nr_m2_coleta1.Text.Equals(String.Empty) Then
                lbl_nr_m2_coleta1.Text = "---"
            Else
                lbl_nr_m2_coleta1.Text = FormatNumber(lbl_nr_m2_coleta1.Text, ldecimal).ToString
            End If
            If lbl_nr_m2_coleta2.Text.Equals(String.Empty) Then
                lbl_nr_m2_coleta2.Text = "---"
            Else
                lbl_nr_m2_coleta2.Text = FormatNumber(lbl_nr_m2_coleta2.Text, ldecimal).ToString
            End If
            If lbl_nr_m2_coleta3.Text.Equals(String.Empty) Then
                lbl_nr_m2_coleta3.Text = "---"
            Else
                lbl_nr_m2_coleta3.Text = FormatNumber(lbl_nr_m2_coleta3.Text, ldecimal).ToString
            End If
            If lbl_nr_m2_coleta4.Text.Equals(String.Empty) Then
                lbl_nr_m2_coleta4.Text = "---"
            Else
                lbl_nr_m2_coleta4.Text = FormatNumber(lbl_nr_m2_coleta4.Text, ldecimal).ToString
            End If

            'se todas as recoletas sao vazias
            If lbl_nr_m2_recoleta1.Text = "" AndAlso lbl_nr_m2_recoleta2.Text = "" AndAlso lbl_nr_m2_recoleta3.Text = "" AndAlso lbl_nr_m2_recoleta4.Text = "" Then
                lbl_m2_st_recoleta_S.Visible = False
            Else
                lbl_m2_st_recoleta_S.Visible = True
                lbl_nr_m2_recoleta1.Visible = True
                lbl_nr_m2_recoleta2.Visible = True
                lbl_nr_m2_recoleta3.Visible = True
                lbl_nr_m2_recoleta4.Visible = True

                If lbl_nr_m2_recoleta1.Text.Equals(String.Empty) Then
                    lbl_nr_m2_recoleta1.Text = "---"
                Else
                    lbl_nr_m2_recoleta1.Text = FormatNumber(lbl_nr_m2_recoleta1.Text, ldecimal).ToString
                End If
                If lbl_nr_m2_recoleta2.Text.Equals(String.Empty) Then
                    lbl_nr_m2_recoleta2.Text = "---"
                Else
                    lbl_nr_m2_recoleta2.Text = FormatNumber(lbl_nr_m2_recoleta2.Text, ldecimal).ToString
                End If
                If lbl_nr_m2_recoleta3.Text.Equals(String.Empty) Then
                    lbl_nr_m2_recoleta3.Text = "---"
                Else
                    lbl_nr_m2_recoleta3.Text = FormatNumber(lbl_nr_m2_recoleta3.Text, ldecimal).ToString
                End If
                If lbl_nr_m2_recoleta4.Text.Equals(String.Empty) Then
                    lbl_nr_m2_recoleta4.Text = "---"
                Else
                    lbl_nr_m2_recoleta4.Text = FormatNumber(lbl_nr_m2_recoleta4.Text, ldecimal).ToString
                End If

            End If

            'CAMPOS DA REFERENCIA 
            If lbl_nr_m3_coleta1.Text.Equals(String.Empty) Then
                lbl_nr_m3_coleta1.Text = "---"
            Else
                lbl_nr_m3_coleta1.Text = FormatNumber(lbl_nr_m3_coleta1.Text, ldecimal).ToString
            End If
            If lbl_nr_m3_coleta2.Text.Equals(String.Empty) Then
                lbl_nr_m3_coleta2.Text = "---"
            Else
                lbl_nr_m3_coleta2.Text = FormatNumber(lbl_nr_m3_coleta2.Text, ldecimal).ToString
            End If
            If lbl_nr_m3_coleta3.Text.Equals(String.Empty) Then
                lbl_nr_m3_coleta3.Text = "---"
            Else
                lbl_nr_m3_coleta3.Text = FormatNumber(lbl_nr_m3_coleta3.Text, ldecimal).ToString
            End If
            If lbl_nr_m3_coleta4.Text.Equals(String.Empty) Then
                lbl_nr_m3_coleta4.Text = "---"
            Else
                lbl_nr_m3_coleta4.Text = FormatNumber(lbl_nr_m3_coleta4.Text, ldecimal).ToString
            End If

            'se todas as recoletas sao vazias
            If lbl_nr_m3_recoleta1.Text = "" AndAlso lbl_nr_m3_recoleta2.Text = "" AndAlso lbl_nr_m3_recoleta3.Text = "" AndAlso lbl_nr_m3_recoleta4.Text = "" Then
                lbl_m3_st_recoleta_S.Visible = False
            Else
                lbl_m3_st_recoleta_S.Visible = True
                lbl_nr_m3_recoleta1.Visible = True
                lbl_nr_m3_recoleta2.Visible = True
                lbl_nr_m3_recoleta3.Visible = True
                lbl_nr_m3_recoleta4.Visible = True

                If lbl_nr_m3_recoleta1.Text.Equals(String.Empty) Then
                    lbl_nr_m3_recoleta1.Text = "---"
                Else
                    lbl_nr_m3_recoleta1.Text = FormatNumber(lbl_nr_m3_recoleta1.Text, ldecimal).ToString
                End If
                If lbl_nr_m3_recoleta2.Text.Equals(String.Empty) Then
                    lbl_nr_m3_recoleta2.Text = "---"
                Else
                    lbl_nr_m3_recoleta2.Text = FormatNumber(lbl_nr_m3_recoleta2.Text, ldecimal).ToString
                End If
                If lbl_nr_m3_recoleta3.Text.Equals(String.Empty) Then
                    lbl_nr_m3_recoleta3.Text = "---"
                Else
                    lbl_nr_m3_recoleta3.Text = FormatNumber(lbl_nr_m3_recoleta3.Text, ldecimal).ToString
                End If
                If lbl_nr_m3_recoleta4.Text.Equals(String.Empty) Then
                    lbl_nr_m3_recoleta4.Text = "---"
                Else
                    lbl_nr_m3_recoleta4.Text = FormatNumber(lbl_nr_m3_recoleta4.Text, ldecimal).ToString
                End If

            End If


            'Dim analiseesalq As New AnaliseEsalq
            'analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
            'analiseesalq.dt_coleta_start = DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))
            'analiseesalq.dt_coleta_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
            'analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_coleta_ini")
            'analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'analiseesalq.id_propriedade = lbl_id_propriedade.Text
            'Dim dsCurvaAbcAnalises As DataSet = analiseesalq.getCurvaAbcProdutoresAnalises()

            'Dim li As Int32
            'li = 0
            'For li = 0 To dsCurvaAbcAnalises.Tables(0).Rows.Count - 1

            '    If DateTime.Parse(dsCurvaAbcAnalises.Tables(0).Rows(li).Item("dt_coleta").ToString).ToString("MM/yyyy") = ViewState.Item("txt_dt_coleta_ini") Then
            '        If ViewState.Item("id_categoria") = 1 Or ViewState.Item("id_categoria") = 2 Then
            '            ViewState.Item("nr_valor_esalq") = FormatNumber(dsCurvaAbcAnalises.Tables(0).Rows(li).Item("nr_valor_esalq").ToString, 0)
            '        Else
            '            ViewState.Item("nr_valor_esalq") = dsCurvaAbcAnalises.Tables(0).Rows(li).Item("nr_valor_esalq").ToString
            '        End If

            '        Select Case dsCurvaAbcAnalises.Tables(0).Rows(li).Item("id_tipo_coleta_analise_esalq").ToString
            '            Case "1"
            '                lbl_nr_m3_coleta1.Text = ViewState.Item("nr_valor_esalq")
            '            Case "2"
            '                lbl_nr_m3_coleta2.Text = ViewState.Item("nr_valor_esalq")
            '            Case "3"
            '                lbl_nr_m3_coleta3.Text = ViewState.Item("nr_valor_esalq")
            '            Case "4"
            '                lbl_nr_m3_coleta4.Text = ViewState.Item("nr_valor_esalq")
            '            Case "11"
            '                lbl_nr_m3_recoleta1.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m3_st_recoleta_S.Visible = True
            '            Case "12"
            '                lbl_nr_m3_recoleta2.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m3_st_recoleta_S.Visible = True
            '            Case "13"
            '                lbl_nr_m3_recoleta3.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m3_st_recoleta_S.Visible = True
            '            Case "14"
            '                lbl_nr_m3_recoleta4.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m3_st_recoleta_S.Visible = True

            '        End Select

            '        If lbl_m3_st_recoleta_S.Visible = True Then
            '            lbl_nr_m3_recoleta1.Visible = True
            '            lbl_nr_m3_recoleta2.Visible = True
            '            lbl_nr_m3_recoleta3.Visible = True
            '            lbl_nr_m3_recoleta4.Visible = True
            '        End If

            '    End If
            '    If DateTime.Parse(dsCurvaAbcAnalises.Tables(0).Rows(li).Item("dt_coleta").ToString).ToString("MM/yyyy") = DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))) Then

            '        If ViewState.Item("id_categoria") = 1 Or ViewState.Item("id_categoria") = 2 Then
            '            ViewState.Item("nr_valor_esalq") = FormatNumber(dsCurvaAbcAnalises.Tables(0).Rows(li).Item("nr_valor_esalq").ToString, 0)
            '        Else
            '            ViewState.Item("nr_valor_esalq") = dsCurvaAbcAnalises.Tables(0).Rows(li).Item("nr_valor_esalq").ToString
            '        End If

            '        Select Case dsCurvaAbcAnalises.Tables(0).Rows(li).Item("id_tipo_coleta_analise_esalq").ToString

            '            Case "1"
            '                lbl_nr_m2_coleta1.Text = ViewState.Item("nr_valor_esalq")
            '            Case "2"
            '                lbl_nr_m2_coleta2.Text = ViewState.Item("nr_valor_esalq")
            '            Case "3"
            '                lbl_nr_m2_coleta3.Text = ViewState.Item("nr_valor_esalq")
            '            Case "4"
            '                lbl_nr_m2_coleta4.Text = ViewState.Item("nr_valor_esalq")
            '            Case "11"
            '                lbl_nr_m2_recoleta1.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m2_st_recoleta_S.Visible = True
            '            Case "12"
            '                lbl_nr_m2_recoleta2.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m2_st_recoleta_S.Visible = True
            '            Case "13"
            '                lbl_nr_m2_recoleta3.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m2_st_recoleta_S.Visible = True
            '            Case "14"
            '                lbl_nr_m2_recoleta4.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m2_st_recoleta_S.Visible = True
            '        End Select

            '        If lbl_m2_st_recoleta_S.Visible = True Then
            '            lbl_nr_m2_recoleta1.Visible = True
            '            lbl_nr_m2_recoleta2.Visible = True
            '            lbl_nr_m2_recoleta3.Visible = True
            '            lbl_nr_m2_recoleta4.Visible = True
            '        End If

            '    End If
            '    If DateTime.Parse(dsCurvaAbcAnalises.Tables(0).Rows(li).Item("dt_coleta").ToString).ToString("MM/yyyy") = DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))) Then

            '        If ViewState.Item("id_categoria") = 1 Or ViewState.Item("id_categoria") = 2 Then
            '            ViewState.Item("nr_valor_esalq") = FormatNumber(dsCurvaAbcAnalises.Tables(0).Rows(li).Item("nr_valor_esalq").ToString, 0)
            '        Else
            '            ViewState.Item("nr_valor_esalq") = dsCurvaAbcAnalises.Tables(0).Rows(li).Item("nr_valor_esalq").ToString
            '        End If

            '        Select Case dsCurvaAbcAnalises.Tables(0).Rows(li).Item("id_tipo_coleta_analise_esalq").ToString

            '            Case "1"
            '                lbl_nr_m1_coleta1.Text = ViewState.Item("nr_valor_esalq")
            '            Case "2"
            '                lbl_nr_m1_coleta2.Text = ViewState.Item("nr_valor_esalq")
            '            Case "3"
            '                lbl_nr_m1_coleta3.Text = ViewState.Item("nr_valor_esalq")
            '            Case "4"
            '                lbl_nr_m1_coleta4.Text = ViewState.Item("nr_valor_esalq")
            '            Case "11"
            '                lbl_nr_m1_recoleta1.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m1_st_recoleta_S.Visible = True
            '            Case "12"
            '                lbl_nr_m1_recoleta2.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m1_st_recoleta_S.Visible = True
            '            Case "13"
            '                lbl_nr_m1_recoleta3.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m1_st_recoleta_S.Visible = True
            '            Case "14"
            '                lbl_nr_m1_recoleta4.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m1_st_recoleta_S.Visible = True
            '        End Select

            '        If lbl_m1_st_recoleta_S.Visible = True Then
            '            lbl_nr_m1_recoleta1.Visible = True
            '            lbl_nr_m1_recoleta2.Visible = True
            '            lbl_nr_m1_recoleta3.Visible = True
            '            lbl_nr_m1_recoleta4.Visible = True
            '        End If

            '        ' adri 23/12/2016
            '        Dim lbl_complience As Label = CType(e.Row.FindControl("lbl_complience"), Label)
            '        If lbl_complience.Text = "COMPL" Then
            '            lbl_complience.ForeColor = Drawing.Color.Blue
            '        Else
            '            lbl_complience.ForeColor = Drawing.Color.Red
            '        End If
            '        Dim lbl_complience_geral As Label = CType(e.Row.FindControl("lbl_complience_geral"), Label)
            '        If lbl_complience_geral.Text = "COMPL" Then
            '            lbl_complience_geral.ForeColor = Drawing.Color.Blue
            '        Else
            '            lbl_complience_geral.ForeColor = Drawing.Color.Red
            '        End If


            '    End If

            'Next

            ' adri 23/12/2016
            Dim lbl_complience As Label = CType(e.Row.FindControl("lbl_complience"), Label)
            If lbl_complience.Text = "COMPL" Then
                lbl_complience.ForeColor = Drawing.Color.Blue
            Else
                lbl_complience.ForeColor = Drawing.Color.Red
            End If
            Dim lbl_complience_geral As Label = CType(e.Row.FindControl("lbl_complience_geral"), Label)
            If lbl_complience_geral.Text = "COMPL" Then
                lbl_complience_geral.ForeColor = Drawing.Color.Blue
            Else
                lbl_complience_geral.ForeColor = Drawing.Color.Red
            End If


        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged

        'lbl_nm_pessoa.Text = ""
        'lbl_nm_pessoa.Visible = False

        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty
        'fran 04/2017 i 
        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                'produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 'fran 05/05/2010
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        'If Me.cbo_estabelecimento.SelectedValue <> "0" Then
        'Me.lbl_nm_propriedade.Visible = True
        carregarCamposPropriedade()
        ' End If
    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
        'lbl_nm_propriedade.Text = ""
        'lbl_nm_propriedade.Visible = False
        lbl_nm_propriedade.Text = String.Empty
        hf_id_propriedade.Value = String.Empty
        'Fran 04/2017
        Try
            If Not txt_cd_propriedade.Text.Equals(String.Empty) Then
                Dim propriedade As New Propriedade
                propriedade.id_propriedade = Convert.ToInt32(txt_cd_propriedade.Text.Trim)

                Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters
                If dspropriedade.Tables(0).Rows.Count > 0 Then
                    lbl_nm_propriedade.Enabled = True
                    lbl_nm_propriedade.Text = dspropriedade.Tables(0).Rows(0).Item("nm_propriedade")
                    hf_id_propriedade.Value = dspropriedade.Tables(0).Rows(0).Item("id_propriedade").ToString
                End If

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        'Fran 11/03/2010 chamado 684

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("txt_dt_coleta_ini") = Me.txt_dt_coleta_ini.Text.Trim
        ViewState.Item("id_categoria") = Me.cbo_categoria_qualidade.SelectedValue
        ViewState.Item("id_grupo") = Me.cbo_grupo.SelectedValue  '10/02/2017 - chamado 2501 - Mirella
        If rb_st_tipo_pagto_d.Checked = True Then  ' 14/02/2017 - chamado 2501 - Mirella i
            ViewState.Item("st_pagamento") = "D"
        Else
            ViewState.Item("st_pagamento") = "P"
        End If ' 14/02/2017 - chamado 2501 - Mirella f
        If txt_cd_tecnico.Text.Equals(String.Empty) Then
            ViewState.Item("id_tecnico") = "0"
        Else
            ViewState.Item("id_tecnico") = hf_id_tecnico.Value
        End If
        ViewState.Item("st_categoria_tecnico") = cbo_categoria.SelectedValue

        'customPage.clearFilters("farmerspayment")

        'saveFilters()
        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 173
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        If chk_exportar_todas.Checked = True Then
            Response.Redirect("frm_curvaabc_produtores_pagto_todas_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&id_tecnico=" + ViewState.Item("id_tecnico").ToString() + "&st_categoria_tecnico=" + ViewState.Item("st_categoria_tecnico").ToString() + "&txt_dt_coleta_ini=" + ViewState.Item("txt_dt_coleta_ini").ToString() + "&id_categoria=" + ViewState.Item("id_categoria").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString() + "&st_pagamento=" + ViewState.Item("st_pagamento").ToString())

        Else
            Response.Redirect("frm_curvaabc_produtores_pagto_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&id_tecnico=" + ViewState.Item("id_tecnico").ToString() + "&st_categoria_tecnico=" + ViewState.Item("st_categoria_tecnico").ToString() + "&txt_dt_coleta_ini=" + ViewState.Item("txt_dt_coleta_ini").ToString() + "&id_categoria=" + ViewState.Item("id_categoria").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString() + "&st_pagamento=" + ViewState.Item("st_pagamento").ToString())

        End If



    End Sub
 

    Protected Sub img_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_tecnico.Click
        If Not (hf_id_tecnico.Value.Trim.Equals(String.Empty)) Then
            Me.lbl_nm_tecnico.Visible = True
            carregarCamposTecnico()

        End If
    End Sub

    Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
        lbl_nm_tecnico.Text = String.Empty
        hf_id_tecnico.Value = String.Empty

        Try
            If Not txt_cd_tecnico.Text.Equals(String.Empty) Then
                Dim tecnico As New Tecnico
                tecnico.id_tecnico = Convert.ToInt32(txt_cd_tecnico.Text.Trim)

                Dim dstecnico As DataSet = tecnico.getTecnicoByFilters
                If dstecnico.Tables(0).Rows.Count > 0 Then
                    lbl_nm_tecnico.Enabled = True
                    lbl_nm_tecnico.Text = dstecnico.Tables(0).Rows(0).Item("nm_tecnico")
                    hf_id_tecnico.Value = dstecnico.Tables(0).Rows(0).Item("id_tecnico").ToString
                End If

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
