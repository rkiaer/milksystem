Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_analise_esalq_conciliacao

    ' chamado 2441 - Acertos e melhorias em Análises ESALQ para Cálculo Geométrico (nova tela de conciliação e liberação das análises para o Cálculo)

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        'ViewState.Item("id_pessoa") = String.Empty
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("txt_dt_coleta_ini") = "01/" + Me.txt_dt_referencia.Text.Trim
        ViewState.Item("txt_dt_coleta_fim") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
        ViewState.Item("cd_analise_esalq") = Me.cbo_codigo_esalq.SelectedValue()
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue
        ViewState.Item("id_situacao_analise_esalq") = Me.cbo_situacao_analise_esalq.SelectedValue
        ViewState.Item("id_aprovacao_analise_esalq") = Me.cbo_aprovacao_analise_esalq.SelectedValue
        ViewState.Item("txt_dt_coleta") = Me.txt_dt_coleta.Text 'fran 26/07
        ViewState.Item("id_tipo_coleta_analise_esalq") = Me.cbo_tipo_coleta.SelectedValue 'fran 26/07
        'Fran 31/07/2016 i
        ViewState.Item("sortExpression") = "id_propriedade, id_tipo_coleta_analise_esalq, ds_analise_esalq, dt_coleta"
        'Fran 31/07/2016 f

        ' adri 02/09/2016 - chamado 2480 - Sempre limpar todas as seleções do estabelecimento e referencia quando efetuar novo filtro - i
        Dim analiseesalq As New AnaliseEsalq
        analiseesalq.id_estabelecimento = cbo_estabelecimento.SelectedValue
        analiseesalq.dt_coleta_start = "01/" + Me.txt_dt_referencia.Text.Trim
        analiseesalq.dt_coleta_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(analiseesalq.dt_coleta_start)))
        analiseesalq.st_selecao = "0"
        analiseesalq.updateAnalisesEsalqSelecaoTodas()
        ' adri 02/09/2016 - chamado 2480 - Sempre limpar todas as seleções do estabelecimento e referencia quando efetuar novo filtro - f

        'fran 09/2016 i
        If gridResults.Rows.Count > 0 Then
            gridResults.DataSource = String.Empty
            gridResults.Visible = False
        End If
        'fran 09/2016 2

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_analise_esalq_conciliacao.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_analise_esalq_conciliacao.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 159
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

    End Sub

    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim codigoesalq As New CodigoEsalq
            Dim analiseesalqaprovacao As New AnaliseEsalqAprovacao
            Dim analiseesalqsituacao As New AnaliseEsalqSituacao
            Dim analiseesalqtipocoleta As New AnaliseEsalqTipoColeta 'fran 26/07/2016

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_codigo_esalq.DataSource = codigoesalq.getCodigosEsalqByFilters()
            cbo_codigo_esalq.DataTextField = "ds_analise_esalq"
            cbo_codigo_esalq.DataValueField = "cd_analise_esalq"
            cbo_codigo_esalq.DataBind()
            cbo_codigo_esalq.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao_analise_esalq.DataSource = analiseesalqsituacao.getAnaliseEsalqSituacaoByFilters()
            cbo_situacao_analise_esalq.DataTextField = "nm_situacao_analise_esalq"
            cbo_situacao_analise_esalq.DataValueField = "id_situacao_analise_esalq"
            cbo_situacao_analise_esalq.DataBind()
            cbo_situacao_analise_esalq.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_aprovacao_analise_esalq.DataSource = analiseesalqaprovacao.getAnaliseEsalqAprovacaoByFilters()
            cbo_aprovacao_analise_esalq.DataTextField = "nm_aprovacao_analise_esalq"
            cbo_aprovacao_analise_esalq.DataValueField = "id_aprovacao_analise_esalq"
            cbo_aprovacao_analise_esalq.DataBind()
            cbo_aprovacao_analise_esalq.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'fran 26/07/2016 i 
            cbo_tipo_coleta.DataSource = analiseesalqtipocoleta.getAnaliseEsalqTipoColetaByFilters()
            cbo_tipo_coleta.DataTextField = "nm_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataValueField = "id_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataBind()
            cbo_tipo_coleta.Items.Insert(0, New ListItem("[Selecione]", "0"))
            'fran 26/07/2016 f


            txt_dt_referencia.Text = DateTime.Parse(Now).ToString("MM/yyyy")
            ViewState.Item("txt_dt_coleta_ini") = "01/" + Me.txt_dt_referencia.Text.Trim
            ViewState.Item("txt_dt_coleta_fim") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))

            'Fran 31/07/2016 i
            ViewState.Item("sortExpression") = "id_propriedade, id_tipo_coleta_analise_esalq, ds_analise_esalq, dt_coleta"
            'Fran 31/07/2016 f

            loadFilters()


            ' Provisório (em desenvolvimento)
            'Me.btn_consistir.Enabled = False
            'Me.btn_aprovar.Enabled = False


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("analise_esalq_conciliacao", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("analise_esalq_conciliacao", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq_conciliacao", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("analise_esalq_conciliacao", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq_conciliacao", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("analise_esalq_conciliacao", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq_conciliacao", txt_cd_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("analise_esalq_conciliacao", txt_cd_propriedade.ID)
            txt_cd_propriedade.Text = ViewState.Item("id_propriedade").ToString()

        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq_conciliacao(", lbl_nm_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_propriedade") = customPage.getFilterValue("analise_esalq_conciliacao", lbl_nm_propriedade.ID)
            lbl_nm_propriedade.Text = ViewState.Item("nm_propriedade").ToString()
            hf_id_propriedade.Value = ViewState.Item("id_propriedade")
        Else
            ViewState.Item("nm_propriedade") = String.Empty
            hf_id_propriedade.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq_conciliacao", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("analise_esalq_conciliacao", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq_conciliacao", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_coleta_ini") = customPage.getFilterValue("analise_esalq_conciliacao", txt_dt_referencia.ID)
            txt_dt_referencia.Text = ViewState.Item("txt_dt_coleta_ini").ToString()
        Else
            ViewState.Item("txt_dt_coleta_ini") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq_conciliacao", txt_dt_coleta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_coleta") = customPage.getFilterValue("analise_esalq_conciliacao", txt_dt_coleta.ID)
            txt_dt_coleta.Text = ViewState.Item("txt_dt_coleta").ToString()
        Else
            ViewState.Item("txt_dt_coleta") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq_conciliacao", cbo_codigo_esalq.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_analise_esalq") = customPage.getFilterValue("analise_esalq_conciliacao", cbo_codigo_esalq.ID)
            cbo_codigo_esalq.SelectedValue = ViewState.Item("cd_analise_esalq").ToString()
        Else
            ViewState.Item("cd_analise_esalq") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq_conciliacao", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("analise_esalq_conciliacao", cbo_situacao.ID)
            cbo_situacao.SelectedValue = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If
        If Not (customPage.getFilterValue("analise_esalq_conciliacao", cbo_tipo_coleta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_tipo_coleta_analise_esalq") = customPage.getFilterValue("analise_esalq_conciliacao", cbo_tipo_coleta.ID)
            cbo_tipo_coleta.SelectedValue = ViewState.Item("id_tipo_coleta_analise_esalq").ToString()
        Else
            ViewState.Item("id_tipo_coleta_analise_esalq") = 0
        End If

        If Not (customPage.getFilterValue("analise_esalq_conciliacao", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("analise_esalq_conciliacao", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("analise_esalq_conciliacao")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim analiseesalq As New AnaliseEsalq

            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If

            If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then
                analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta_ini").ToString
                analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta_fim").ToString
            Else
                analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
            End If

            analiseesalq.cd_analise_esalq = Convert.ToInt32(ViewState.Item("cd_analise_esalq").ToString())
            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq").ToString)
            analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq").ToString)

            analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq").ToString) 'fran 26/07/2016

            Dim dsAnaliseEsalc As DataSet = analiseesalq.getAnaliseEsalqByFilters()

            If (dsAnaliseEsalc.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsAnaliseEsalc.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            ' 06/07/2016 - Verifica se a referência já foi liberada para o cálculo, não permite mais nenhuma ação
            Dim calculoprodutor As New CalculoProdutor
            calculoprodutor.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            calculoprodutor.dt_referencia = ViewState.Item("txt_dt_coleta_ini").ToString
            Dim dsCalculoAnaliseEsalqLiberada As DataSet = calculoprodutor.getCalculoAnaliseEsalqLiberada()
            If dsCalculoAnaliseEsalqLiberada.Tables(0).Rows.Count > 0 Then
                If dsCalculoAnaliseEsalqLiberada.Tables(0).Rows(0).Item("st_liberado_calculo").ToString() = "S" Then
                    btn_ativar.Enabled = False
                    btn_desativar.Enabled = False
                    btn_consistir.Enabled = False
                    btn_aprovar.Enabled = False
                    btn_nao_aprovar.Enabled = False
                    btn_Cancelar_aprovacao.Enabled = False
                Else 'fran 09/2019 caso tenha selecionado referencia ja liberada e depois selecionar referencia em uso deve deixar botoes habilitados
                    btn_ativar.Enabled = True
                    btn_desativar.Enabled = True
                    btn_consistir.Enabled = True
                    btn_aprovar.Enabled = True
                    btn_nao_aprovar.Enabled = True
                    btn_Cancelar_aprovacao.Enabled = True

                End If

            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        'saveCheckBox()
        loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "id_unid_producao"
                If (ViewState.Item("sortExpression")) = "id_unid_producao asc" Then
                    ViewState.Item("sortExpression") = "id_unid_producao desc"
                Else
                    ViewState.Item("sortExpression") = "id_unid_producao asc"
                End If


            Case "dt_coleta"
                If (ViewState.Item("sortExpression")) = "dt_coleta asc" Then
                    ViewState.Item("sortExpression") = "dt_coleta desc"
                Else
                    ViewState.Item("sortExpression") = "dt_coleta asc"
                End If


            Case "dt_processamento"
                If (ViewState.Item("sortExpression")) = "dt_processamento asc" Then
                    ViewState.Item("sortExpression") = "dt_processamento desc"
                Else
                    ViewState.Item("sortExpression") = "dt_processamento asc"
                End If

            Case "dt_analise"
                If (ViewState.Item("sortExpression")) = "dt_analise asc" Then
                    ViewState.Item("sortExpression") = "dt_analise desc"
                Else
                    ViewState.Item("sortExpression") = "dt_analise asc"
                End If

            Case "ds_analise_esalq"
                If (ViewState.Item("sortExpression")) = "ds_analise_esalq asc" Then
                    ViewState.Item("sortExpression") = "ds_analise_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "ds_analise_esalq asc"
                End If

            Case "nr_valor_esalq"
                If (ViewState.Item("sortExpression")) = "nr_valor_esalq asc" Then
                    ViewState.Item("sortExpression") = "nr_valor_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "nr_valor_esalq asc"
                End If

            Case "nr_media_mg"
                If (ViewState.Item("sortExpression")) = "nr_media_mg asc" Then
                    ViewState.Item("sortExpression") = "nr_media_mg desc"
                Else
                    ViewState.Item("sortExpression") = "nr_media_mg asc"
                End If

            Case "nr_variacao_mg"
                If (ViewState.Item("sortExpression")) = "nr_variacao_mg asc" Then
                    ViewState.Item("sortExpression") = "nr_variacao_mg desc"
                Else
                    ViewState.Item("sortExpression") = "nr_variacao_mg asc"
                End If


            Case "nm_aprovacao_analise_esalq"
                If (ViewState.Item("sortExpression")) = "nm_aprovacao_analise_esalq asc" Then
                    ViewState.Item("sortExpression") = "nm_aprovacao_analise_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "nm_aprovacao_analise_esalq asc"
                End If

            Case "id_tipo_coleta_analise_esalq"
                If (ViewState.Item("sortExpression")) = "id_tipo_coleta_analise_esalq asc" Then
                    ViewState.Item("sortExpression") = "id_tipo_coleta_analise_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "id_tipo_coleta_analise_esalq asc"
                End If
            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If
            Case "nm_abreviado"
                If (ViewState.Item("sortExpression")) = "nm_abreviado asc" Then
                    ViewState.Item("sortExpression") = "nm_abreviado desc"
                Else
                    ViewState.Item("sortExpression") = "nm_abreviado asc"
                End If

        End Select

        loadData()

    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_produtor")



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposPropriedade()

        Try

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If

            Me.txt_cd_propriedade.Text = Me.hf_id_propriedade.Value.ToString

            If Not (customPage.getFilterValue("lupa_propriedade", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "cd_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Visible = True
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_propriedade", "id_pessoa").Equals(String.Empty)) Then
                Me.hf_id_pessoa.Value = customPage.getFilterValue("lupa_propriedade", "id_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("analise_esaq_conciliacao", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("analise_esaq_conciliacao", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("analise_esaq_conciliacao", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("analise_esaq_conciliacao", txt_cd_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("analise_esaq_conciliacao", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("analise_esaq_conciliacao", lbl_nm_propriedade.ID, ViewState.Item("nm_propriedade").ToString)
            customPage.setFilter("analise_esaq_conciliacao", txt_dt_referencia.ID, ViewState.Item("txt_dt_coleta_ini").ToString)
            customPage.setFilter("analise_esaq_conciliacao", txt_dt_coleta.ID, ViewState.Item("txt_dt_coleta").ToString)
            customPage.setFilter("analise_esaq_conciliacao", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("analise_esaq_conciliacao", cbo_codigo_esalq.ID, ViewState.Item("cd_analise_esalq").ToString)
            customPage.setFilter("analise_esaq_conciliacao", cbo_tipo_coleta.ID, ViewState.Item("id_tipo_coleta_analise_esalq").ToString)
            customPage.setFilter("analise_esaq_conciliacao", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "consistencias"
                loadConsistencias(Convert.ToInt32(e.CommandArgument.ToString()))

            Case "delete"
                deleteAnaliseEsalq(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub loadConsistencias(ByVal pbl_id_analise_esalq As Int32)



        Dim analiseesalq As New AnaliseEsalq
        analiseesalq.id_analise_esalq = pbl_id_analise_esalq
        Dim dsAnaliseEsalqConsistencias As DataSet = analiseesalq.getAnalisesEsalqConsistencias()
        If (dsAnaliseEsalqConsistencias.Tables(0).Rows.Count > 0) Then
            pnl_consistencias.Visible = True
            gridConsistencias.Visible = True
            gridConsistencias.DataSource = Helper.getDataView(dsAnaliseEsalqConsistencias.Tables(0), ViewState.Item("sortExpression"))
            gridConsistencias.DataBind()
        Else
            gridConsistencias.Visible = False
        End If

    End Sub

    Private Sub deleteAnaliseEsalq(ByVal id_analise_esalq As Integer)

        Try
            Dim analiseesalq As New AnaliseEsalq()
            analiseesalq.id_analise_esalq = id_analise_esalq
            analiseesalq.id_modificador = Convert.ToInt32(Session("id_login"))
            analiseesalq.deleteAnaliseEsalq()


            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 159
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

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
            Dim lbl_id_situacao_analise_esalq As Label = CType(e.Row.FindControl("lbl_id_situacao_analise_esalq"), Label)
            Dim lbl_id_analise_esalq As Label = CType(e.Row.FindControl("lbl_id_analise_esalq"), Label)
            Dim lbl_id_propriedade_matriz As Label = CType(e.Row.FindControl("lbl_id_propriedade_matriz"), Label)
            Dim lbl_matriz As Label = CType(e.Row.FindControl("lbl_matriz"), Label)

            '' Acertar abaixo: verificar a tabela ms_analise_esalq_consistencias (se tiver mais de uma linha, habilitar o link Erro(s)
            'If lbl_id_situacao_analise_esalq.Text <> "1" And lbl_id_situacao_analise_esalq.Text <> "2" Then
            '    lbl_consistencias.Visible = False
            '    hl_consistencias.Visible = True
            '    hl_consistencias.Text = "Erro(s)"
            '    'hl_consistencias.NavigateUrl = String.Format("lst_analises_esalq_consistencias.aspx?id_analise_esalq={0}", lbl_id_analise_esalq.Text) & String.Format("&cd_funcionario={0}", lbl_cod_funcionario.Text)
            '    hl_consistencias.NavigateUrl = String.Format("lst_analises_esalq_consistencias.aspx?id_analise_esalq={0}", lbl_id_analise_esalq.Text)
            'End If
            If Not lbl_id_propriedade_matriz.Text.Equals(String.Empty) AndAlso CInt(lbl_id_propriedade_matriz.Text) > 0 Then
                lbl_matriz.Text = "S"
            End If

            Dim lbl_id_aprovacao_esalq As Label = CType(e.Row.FindControl("lbl_id_aprovacao_analise_esalq"), Label)
            Dim chk_item As CheckBox = CType(e.Row.FindControl("ck_item"), CheckBox)
            If lbl_id_aprovacao_esalq.Text = "3" Then  ' Se 3-Não Aprovado pelo Sistema (caso de Romaneios), não permite selecionar  (mas e a seleção para ativar/desativar? Melhor tratar na aprovação) Tratar aqui pois esta situacao nao pode fazer nada
                chk_item.Enabled = False
                chk_item.ToolTip = "Não pode ser selecionado. Registro não aprovado pelo sistema."
            Else
                chk_item.Enabled = True
                chk_item.ToolTip = String.Empty

            End If

            Dim analiseesalq As New AnaliseEsalq
            Dim dsAnaliseEsalqConsistencias As DataSet
            analiseesalq.id_analise_esalq = lbl_id_analise_esalq.Text
            dsAnaliseEsalqConsistencias = analiseesalq.getAnalisesEsalqConsistencias()
            If dsAnaliseEsalqConsistencias.Tables(0).Rows.Count > 1 Then
                lbl_consistencias.Visible = False
                lbl_detalhes.Visible = True
                btn_detalhes.Visible = True
            End If


        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        'fran 28/11/2009 i chamado 523 - o estabelecimento é para saber para qual estabel é o arquivo a ser importado
        'Me.lbl_nm_pessoa.Text = ""
        'Me.txt_cd_pessoa.Text = ""
        'Me.hf_id_pessoa.Value = ""
        'Me.lbl_nm_pessoa.Visible = False
        'Me.lbl_nm_propriedade.Text = ""
        'Me.txt_cd_propriedade.Text = ""
        'Me.hf_id_propriedade.Value = ""
        'Me.lbl_nm_propriedade.Visible = False
        'fran 28/11/2009 f chamado 523
    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()



    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged

        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
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
        If Me.cbo_estabelecimento.SelectedValue <> "0" Then
            Me.lbl_nm_propriedade.Visible = True
            carregarCamposPropriedade()
        End If
    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
        lbl_nm_propriedade.Text = ""
        lbl_nm_propriedade.Visible = False

    End Sub


    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                'se aprovacao <> 3- nao aprovado pelo sistema
                If Not CType(gridResults.Rows(li).FindControl("lbl_id_aprovacao_analise_esalq"), Label).Text.Equals(3) Then
                    ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                    ch.Checked = ck_header.Checked
                End If
            Next

            ' Seleciona tudo o que o botão Pesquisar trouxer - i

            Dim analiseesalq As New AnaliseEsalq
            analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")

            If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
                analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
                analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
            Else
                analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
            End If

            If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If
            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
            analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
            analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
            analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
            analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))  ' adri 02/09/2016 - chamado 2480 

            If ck_header.Checked = True Then
                analiseesalq.st_selecao = "1"
            Else
                analiseesalq.st_selecao = "0"
            End If
            analiseesalq.updateAnalisesEsalqSelecaoTodas()
            ' Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_ativar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ativar.Click
        Try
            Dim analiseesalq As New AnaliseEsalq

            'If saveCheckBox() = True Then
            If Page.IsValid Then
                'Filtro
                analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
                If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
                    analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
                    analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
                Else
                    analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                    analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                End If

                If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
                    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                End If

                If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
                End If
                analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
                analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
                analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
                analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
                analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))

                'Dados para o Update
                analiseesalq.id_situacao = 1  '  Ativo
                analiseesalq.id_modificador = Session("id_login")
                analiseesalq.updateAnalisesEsalqSituacaoSelecionadasAtivar()

                loadData()

                messageControl.Alert("Análises Ativadas com sucesso.")
            End If
            'Else
            'messageControl.Alert("Nenhum item foi selecionado para ser ativado. Por favor selecione alguma análise.")
            'End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_inativar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_desativar.Click
        Try
            Dim analiseesalq As New AnaliseEsalq

            'If saveCheckBox() = True Then
            If Page.IsValid Then
                'Filtro
                analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
                If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
                    analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
                    analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
                Else
                    analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                    analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                End If

                If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
                    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                End If
                If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
                End If
                analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
                analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
                analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
                analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
                analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))


                'Dados para o Update
                analiseesalq.id_situacao = 2  '  Inativo
                analiseesalq.id_modificador = Session("id_login")
                analiseesalq.updateAnalisesEsalqSituacaoSelecionadas()

                loadData()

                messageControl.Alert("Análises Desativadas com sucesso.")
            End If
            'Else
            'messageControl.Alert("Nenhum item foi selecionado para ser desativado. Por favor selecione alguma análise.")
            'End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function saveCheckBox() As Boolean

        Try

            Dim li As Integer

            Dim analiseesalq As New AnaliseEsalq
            For li = 0 To gridResults.Rows.Count - 1
                analiseesalq.id_analise_esalq = gridResults.DataKeys(li).Value.ToString
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    analiseesalq.st_selecao = "1"
                    saveCheckBox = True     ' Indica que tem item selecionado
                Else
                    analiseesalq.st_selecao = "0"
                End If
                analiseesalq.updateAnalisesEsalqSelecao()
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub lk_liberar_calculo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_liberar_calculo.Click
        Try
            If Page.IsValid Then
                Dim li As Integer

                ' Verifica se selecionou linhas, pois mão pode haver seleção, a liberação é para toda a referencia/estabelecimento
                Dim analiseesalq As New AnaliseEsalq
                For li = 0 To gridResults.Rows.Count - 1
                    analiseesalq.id_analise_esalq = gridResults.DataKeys(li).Value.ToString
                    If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                        messageControl.Alert("Nenhum item deve estar selecionado pois todas as análises aprovadas do estabelecimento e referência serão liberadas para o Cálculo.")
                        Exit Sub
                    End If
                Next

                ' Verifica se informou outros filtros
                If Me.txt_cd_propriedade.Text.Trim() <> "" Or cbo_codigo_esalq.SelectedIndex <> 0 Then
                    messageControl.Alert("Nenhum filtro deve ser informado para a liberação das análises para o Cálculo, exceto o estabelecimento e referência.")
                    Exit Sub
                End If

                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
                'ViewState.Item("id_pessoa") = String.Empty
                ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
                ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
                ViewState.Item("txt_dt_coleta_ini") = "01/" + Me.txt_dt_referencia.Text.Trim
                ViewState.Item("txt_dt_coleta_fim") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
                ViewState.Item("cd_analise_esalq") = Me.cbo_codigo_esalq.SelectedValue()
                ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue
                ViewState.Item("id_situacao_analise_esalq") = Me.cbo_situacao_analise_esalq.SelectedValue
                ViewState.Item("id_aprovacao_analise_esalq") = Me.cbo_aprovacao_analise_esalq.SelectedValue
                ViewState.Item("txt_dt_coleta") = Me.txt_dt_coleta.Text 'fran 26/07
                ViewState.Item("id_tipo_coleta_analise_esalq") = Me.cbo_tipo_coleta.SelectedValue 'fran 26/07

                'Filtro
                analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
                analiseesalq.dt_referencia = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
                analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
                analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
                analiseesalq.id_modificador = Session("id_login")
                analiseesalq.updateAnalisesEsalqHeader() ' Atualiza a coluna st_liberado_calculo para "S"

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 159
                usuariolog.ds_nm_processo = "Conciliação Análises Esalq - Liberar para Cálculo"
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 



                Me.lk_liberar_calculo.Enabled = False
                Me.btn_ativar.Enabled = False
                Me.btn_desativar.Enabled = False
                messageControl.Alert("As análises aprovadas do Estabelecimento/Referência foram liberadas para o Cálculo com sucesso!")

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_consistir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_consistir.Click
        Try

            If Page.IsValid Then
                Dim analiseesalq As New AnaliseEsalq


                analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
                analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
                analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
                analiseesalq.id_modificador = Session("id_login")
                analiseesalq.ConsistirAnalises()

                messageControl.Alert("Consistências efetuadas com sucesso!")

                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aprovar.Click
        Try
            If Page.IsValid Then

                Dim analiseesalq As New AnaliseEsalq

                'If saveCheckBox() = True Then

                'Filtro - deve sempre assumir as viewstates que vem do pesquisar
                analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
                If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
                    analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
                    analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
                Else
                    analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                    analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                End If

                If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
                    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                End If
                If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
                End If
                analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
                analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
                analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
                analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
                analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))

                'Dados para o Update
                analiseesalq.id_situacao = 1  '  Ativo
                analiseesalq.id_modificador = Session("id_login")

                analiseesalq.updateAnalisesEsalqAprovarSelecionadas()

                loadData()

                messageControl.Alert("Análises Aprovadas com sucesso.")
                'Else
                'messageControl.Alert("Nenhum item foi selecionado para ser aprovado. Por favor selecione alguma análise.")
                'End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub




    Protected Sub btn_fechar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_fechar.Click
        Me.pnl_consistencias.Visible = False
    End Sub

    Protected Sub btn_nao_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nao_aprovar.Click
        Try
            Dim analiseesalq As New AnaliseEsalq

            'If saveCheckBox() = True Then
            If Page.IsValid Then
                'Filtro
                analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
                If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
                    analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
                    analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
                Else
                    analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                    analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                End If

                If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
                    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                End If
                If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
                End If
                analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
                analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
                analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
                analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
                analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))


                'Dados para o Update
                analiseesalq.id_situacao = 1  '  Ativo
                analiseesalq.id_modificador = Session("id_login")
                analiseesalq.updateAnalisesEsalqNaoAprovarSelecionadas()

                loadData()

                messageControl.Alert("Análises Não Aprovadas com sucesso.")
            End If
            'Else
            'messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione alguma análise.")
            'End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_Cancelar_aprovacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Cancelar_aprovacao.Click
        Try
            Dim analiseesalq As New AnaliseEsalq

            'If saveCheckBox() = True Then
            If Page.IsValid Then
                'Filtro
                analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
                If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
                    analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
                    analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
                Else
                    analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                    analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                End If

                If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
                    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                End If
                If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
                End If
                analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
                analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
                analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
                analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
                analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))


                'Dados para o Update
                analiseesalq.id_situacao = 1  '  Ativo
                analiseesalq.id_modificador = Session("id_login")
                analiseesalq.updateAnalisesEsalqAprovacaoCancelarSelecionadas()

                loadData()

                messageControl.Alert("Análises Aprovadas/Não Aprovadas canceladas com sucesso.")
            End If
            'Else
            'messageControl.Alert("Nenhum item foi selecionado para ser carcelada aprovação/não aprovação. Por favor selecione alguma análise.")
            'End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_filtros_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_filtros.ServerValidate
        Dim lberro As Boolean = False
        Dim lmsg As String = String.Empty
        args.IsValid = True

        Try
            If Not (ViewState.Item("id_estabelecimento").ToString = cbo_estabelecimento.SelectedValue.ToString) Then
                lberro = True
            End If
            If Not (ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value) Then
                lberro = True
            End If
            If Not (ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()) Then
                lberro = True
            End If
            If Not (ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()) Then
                lberro = True
            End If
            If Not (ViewState.Item("txt_dt_coleta_ini") = "01/" + Me.txt_dt_referencia.Text.Trim) Then
                lberro = True
            End If
            If Not (ViewState.Item("cd_analise_esalq") = Me.cbo_codigo_esalq.SelectedValue()) Then
                lberro = True
            End If
            If Not (ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue) Then
                lberro = True
            End If
            If Not (ViewState.Item("id_situacao_analise_esalq") = Me.cbo_situacao_analise_esalq.SelectedValue) Then
                lberro = True
            End If
            If Not (ViewState.Item("id_aprovacao_analise_esalq") = Me.cbo_aprovacao_analise_esalq.SelectedValue) Then
                lberro = True
            End If
            If Not (ViewState.Item("txt_dt_coleta") = Me.txt_dt_coleta.Text) Then
                lberro = True
            End If
            If Not (ViewState.Item("id_tipo_coleta_analise_esalq") = Me.cbo_tipo_coleta.SelectedValue) Then
                lberro = True
            End If

            If lberro = True Then
                args.IsValid = False
                lmsg = "Os filtros selecionados estão divergentes dos resultados da pesquisa realizada. Por favor, selecione o botão 'Pesquisar' antes de prosseguir com qualquer ação."
            Else 'se não tem erro
                'assume que não selecionou nenhum item
                lmsg = "Nenhum item foi selecionado. Por favor, selecione alguma análise e prossiga com a ação desejada."
                lberro = True

                'verifica se tem item selecionado
                Dim li As Integer
                For li = 0 To gridResults.Rows.Count - 1
                    If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                        lberro = False 'não tem erro, selecionou item
                        Exit For
                    End If
                Next
            End If
            If lberro = True Then
                args.IsValid = False
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cbo_situacao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_situacao.SelectedIndexChanged
        Try

            Select Case cbo_situacao.SelectedValue
                Case "1" 'ativo
                    btn_ativar.Enabled = True
                    btn_desativar.Enabled = True
                    If cbo_aprovacao_analise_esalq.SelectedValue.Equals("0") Then 'se nao selecionou aprovacao
                        btn_aprovar.Enabled = True
                        btn_Cancelar_aprovacao.Enabled = True
                        btn_nao_aprovar.Enabled = True
                    End If

                Case "2" 'inativo
                    'se inativo
                    btn_ativar.Enabled = True
                    btn_aprovar.Enabled = False
                    btn_Cancelar_aprovacao.Enabled = False
                    btn_desativar.Enabled = False
                    btn_nao_aprovar.Enabled = False

                Case "0" 'Selecione
                    btn_ativar.Enabled = True
                    btn_desativar.Enabled = True
                    If cbo_aprovacao_analise_esalq.SelectedValue.Equals("0") Then 'se nao selecionou aprovacao
                        btn_aprovar.Enabled = True
                        btn_Cancelar_aprovacao.Enabled = True
                        btn_nao_aprovar.Enabled = True
                    End If
            End Select


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub cbo_aprovacao_analise_esalq_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_aprovacao_analise_esalq.SelectedIndexChanged
        Try

            Select Case cbo_aprovacao_analise_esalq.SelectedValue
                Case "1" 'aprovada
                    btn_aprovar.Enabled = False
                    btn_Cancelar_aprovacao.Enabled = True
                    btn_nao_aprovar.Enabled = False
                Case "2" 'nçao aprovada
                    btn_aprovar.Enabled = False
                    btn_Cancelar_aprovacao.Enabled = True
                    btn_nao_aprovar.Enabled = False
                Case "3" ' não aprovada sistema
                    btn_aprovar.Enabled = False
                    btn_Cancelar_aprovacao.Enabled = False
                    btn_nao_aprovar.Enabled = False
                Case "4" 'agradandoaprovacao
                    btn_aprovar.Enabled = True
                    btn_Cancelar_aprovacao.Enabled = True
                    btn_nao_aprovar.Enabled = True
                Case "0" 'selecionar
                    btn_aprovar.Enabled = True
                    btn_Cancelar_aprovacao.Enabled = True
                    btn_nao_aprovar.Enabled = True

            End Select

            If cbo_situacao.SelectedValue.Equals("2") Then
                'se inativo
                btn_aprovar.Enabled = False
                btn_ativar.Enabled = True
                btn_Cancelar_aprovacao.Enabled = False
                btn_desativar.Enabled = False
                btn_nao_aprovar.Enabled = False

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub ck_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim chk_selec As CheckBox

            chk_selec = CType(sender, CheckBox)

            '' Seleciona o item selecionado
            Dim analiseesalq As New AnaliseEsalq

            analiseesalq.id_analise_esalq = Convert.ToInt32(gridResults.DataKeys.Item(row.RowIndex).Value)
            If chk_selec.Checked = True Then
                analiseesalq.st_selecao = "1"
            Else
                analiseesalq.st_selecao = "0"
            End If
            analiseesalq.updateAnalisesEsalqSelecao()

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try


    End Sub
    '21/12/2016 - Mirella i 
    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click


        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("txt_dt_coleta_ini") = "01/" + Me.txt_dt_referencia.Text.Trim
        ViewState.Item("txt_dt_coleta_fim") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
        ViewState.Item("cd_analise_esalq") = Me.cbo_codigo_esalq.SelectedValue()
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue
        ViewState.Item("id_situacao_analise_esalq") = Me.cbo_situacao_analise_esalq.SelectedValue
        ViewState.Item("txt_dt_coleta") = Me.txt_dt_coleta.Text
        ViewState.Item("id_tipo_coleta_analise_esalq") = Me.cbo_tipo_coleta.SelectedValue 
        ViewState.Item("id_aprovacao_analise_esalq") = Me.cbo_aprovacao_analise_esalq.SelectedValue

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 159
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 



        customPage.clearFilters("analise_esalq_conciliacao")

        saveFilters()
        Response.Redirect("frm_analise_esalq_conciliacao_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&txt_dt_coleta_ini=" + ViewState.Item("txt_dt_coleta_ini").ToString() + "&txt_dt_coleta_fim=" + ViewState.Item("txt_dt_coleta_fim").ToString() + "&cd_analise_esalq=" + ViewState.Item("cd_analise_esalq").ToString() + "&id_situacao=" + ViewState.Item("id_situacao").ToString() + "&id_situacao_analise_esalq=" + ViewState.Item("id_situacao_analise_esalq").ToString() + "&txt_dt_coleta=" + ViewState.Item("txt_dt_coleta").ToString() + "&id_tipo_coleta_analise_esalq=" + ViewState.Item("id_tipo_coleta_analise_esalq").ToString() + "&id_aprovacao_analise_esalq=" + ViewState.Item("id_aprovacao_analise_esalq"))

    End Sub   '21/12/2016 - Mirella f
End Class
