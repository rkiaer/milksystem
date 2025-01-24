Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_central_solicitar_cotacao
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
        ViewState.Item("nm_pessoa") = Me.lbl_nm_pessoa.Text.Trim()
        ViewState.Item("ds_contato") = Me.lbl_contato.Text.Trim
        ViewState.Item("ds_email") = Me.lbl_email.Text.Trim
        ViewState.Item("ds_telefone") = Me.lbl_telefone.Text.Trim
        ViewState.Item("ds_fax") = Me.lbl_fax.Text.Trim

        If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
            ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If

        If Not (Me.txt_id_propriedade.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_propriedade") = Me.txt_id_propriedade.Text.Trim()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If
        ViewState.Item("nm_propriedade") = Me.lbl_nm_propriedade.Text.Trim
        If Not (Me.txt_id_cotacao.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_central_cotacao") = Me.txt_id_cotacao.Text.Trim()
        Else
            ViewState.Item("id_central_cotacao") = String.Empty
        End If
        If Not (Me.hf_id_item.Value.Equals(String.Empty)) Then
            ViewState.Item("id_item") = Me.hf_id_item.Value
        Else
            ViewState.Item("id_item") = String.Empty
        End If
        ViewState.Item("cd_item") = Me.txt_cd_item.Text.Trim()
        ViewState.Item("nm_item") = Me.lbl_nm_item.Text.Trim()

        ViewState.Item("dt_cotacao") = Me.txt_dt_cotacao.Text.Trim
        ViewState.Item("id_situacao_cotacao") = Me.cbo_situacao.SelectedValue
        If chk_ver_mercado.Checked = True Then
            ViewState.Item("st_ver_mercado") = "S"
        Else
            ViewState.Item("st_ver_mercado") = "N"
        End If
        If chk_prod_informado.Checked = True Then
            ViewState.Item("st_produtor_informado") = "S"
        Else
            ViewState.Item("st_produtor_informado") = "N"
        End If

        'fran i chamado 717/860 rls 24.10 
        ViewState.Item("id_situacao_cotacao_item") = Me.cbo_situacao_item.SelectedValue
        'fran f chamado 717/860 rls 24.10 


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_solicitar_cotacao.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_solicitar_cotacao.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 92
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Produtores"
            '.Style("cursor") = "hand"
        End With
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
            '.Style("cursor") = "hand"
        End With
        With btn_lupa_item
            .Attributes.Add("onclick", "javascript:ShowDialogItem()")
            .ToolTip = "Filtrar Itens"
            '.Style("cursor") = "hand"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New SituacaoCotacao
            Dim estabelecimento As New Estabelecimento
            Dim statusitem As New SituacaoCotacaoItem

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao.DataSource = status.getSituacoesCotacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao_cotacao"
            cbo_situacao.DataValueField = "id_situacao_cotacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))
            'fran chamado 717/860 i
            cbo_situacao_item.DataSource = statusitem.getSituacoesCotacoesItemByFilters()
            cbo_situacao_item.DataTextField = "nm_central_status_aprovacao"
            cbo_situacao_item.DataValueField = "id_central_status_aprovacao"
            cbo_situacao_item.DataBind()
            cbo_situacao_item.Items.Insert(0, New ListItem("[Selecione]", "0"))
            'fran chamado 717/860 f

            ViewState.Item("sortExpression") = "id_central_cotacao asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("solcotacao", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("solcotacao", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("solcotacao", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("solcotacao", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("solcotacao", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("solcotacao", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("solcotacao", txt_id_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("solcotacao", txt_id_propriedade.ID)
            txt_id_propriedade.Text = ViewState.Item("id_propriedade").ToString()
            hf_id_propriedade.Value = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("solcotacao", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("solcotacao", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("solcotacao", lbl_nm_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_propriedade") = customPage.getFilterValue("solcotacao", lbl_nm_propriedade.ID)
            lbl_nm_propriedade.Text = ViewState.Item("nm_propriedade").ToString()
        Else
            ViewState.Item("nm_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("solcotacao", txt_id_cotacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_central_cotacao") = customPage.getFilterValue("solcotacao", txt_id_cotacao.ID)
            txt_id_cotacao.Text = ViewState.Item("id_central_cotacao").ToString()
        Else
            ViewState.Item("id_central_cotacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("solcotacao", txt_cd_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_item") = customPage.getFilterValue("solcotacao", txt_cd_item.ID)
            txt_cd_item.Text = ViewState.Item("cd_item").ToString()
        Else
            ViewState.Item("cd_item") = String.Empty
        End If

        If Not (customPage.getFilterValue("solcotacao", lbl_nm_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_item") = customPage.getFilterValue("solcotacao", lbl_nm_item.ID)
            lbl_nm_item.Text = ViewState.Item("nm_item").ToString()
        Else
            ViewState.Item("nm_item") = String.Empty
        End If

        If Not (customPage.getFilterValue("solcotacao", hf_id_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_item") = customPage.getFilterValue("solcotacao", hf_id_item.ID)
            hf_id_item.Value = ViewState.Item("id_item").ToString()
        Else
            ViewState.Item("id_item") = String.Empty
            hf_id_item.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("solcotacao", txt_dt_cotacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_cotacao") = customPage.getFilterValue("solcotacao", txt_dt_cotacao.ID)
            txt_dt_cotacao.Text = ViewState.Item("dt_cotacao").ToString()
        Else
            ViewState.Item("dt_cotacao") = String.Empty
            txt_dt_cotacao.Text = String.Empty
        End If


        If Not (customPage.getFilterValue("solcotacao", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao_cotacao") = customPage.getFilterValue("solcotacao", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao_cotacao").ToString()
        Else
            ViewState.Item("id_situacao_cotacao") = String.Empty
        End If
        'fran 23/07/2010 i chamado 717/860 rls 24.10 
        If Not (customPage.getFilterValue("solcotacao", cbo_situacao_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao_cotacao_item") = customPage.getFilterValue("solcotacao", cbo_situacao_item.ID)
            cbo_situacao_item.Text = ViewState.Item("id_situacao_cotacao_item").ToString()
        Else
            ViewState.Item("id_situacao_cotacao_item") = String.Empty
        End If
        'fran 23/07/2010 i chamado 717/860 rls 24.10 f

        If (customPage.getFilterValue("solcotacao", chk_ver_mercado.ID).ToString.Trim = "S") Then
            hasFilters = True
            ViewState.Item("st_ver_mercado") = "S"
            chk_ver_mercado.Checked = True
        Else
            ViewState.Item("st_ver_mercado") = "N"
            chk_ver_mercado.Checked = False
        End If
        If (customPage.getFilterValue("solcotacao", chk_prod_informado.ID).ToString.Trim = "S") Then
            hasFilters = True
            ViewState.Item("st_produtor_informado") = "S"
            chk_prod_informado.Checked = True
        Else
            ViewState.Item("st_produtor_informado") = "N"
            chk_prod_informado.Checked = False
        End If


        If Not (customPage.getFilterValue("solcotacao", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("solcotacao", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("solcotacao")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim cotacao As New Cotacao

            If Not (ViewState.Item("id_propriedade").Equals(String.Empty)) Then
                cotacao.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            Else
                cotacao.id_propriedade = 0
            End If
            If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                cotacao.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            Else
                cotacao.id_pessoa = 0
            End If
            'fRAN CHAMado 559 i
            If Not (ViewState.Item("cd_pessoa").Equals(String.Empty)) Then
                cotacao.cd_pessoa = ViewState.Item("cd_pessoa").ToString
            Else
                cotacao.cd_pessoa = String.Empty
            End If
            If Not (ViewState.Item("cd_item").Equals(String.Empty)) Then
                cotacao.cd_item = ViewState.Item("cd_item").ToString
            Else
                cotacao.cd_item = String.Empty
            End If
            'fran chamado 559 f
            If Not (ViewState.Item("id_central_cotacao").Equals(String.Empty)) Then
                cotacao.id_central_cotacao = Convert.ToInt32(ViewState.Item("id_central_cotacao").ToString)
            Else
                cotacao.id_central_cotacao = 0
            End If
            If Not (ViewState.Item("id_item").Equals(String.Empty)) Then
                cotacao.id_item = Convert.ToInt32(ViewState.Item("id_item").ToString)
            Else
                cotacao.id_item = 0
            End If
            If Not (ViewState.Item("id_estabelecimento").Equals(String.Empty)) Then
                cotacao.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            Else
                cotacao.id_estabelecimento = 0
            End If

            cotacao.dt_cotacao = txt_dt_cotacao.Text.ToString

            If Not (ViewState.Item("id_situacao_cotacao").Equals(String.Empty)) Then
                cotacao.id_situacao_cotacao = Convert.ToInt32(ViewState.Item("id_situacao_cotacao").ToString)
            Else
                cotacao.id_situacao_cotacao = 0
            End If
            'fran i chamado 717/860 rls 24.10 
            If Not (ViewState.Item("id_situacao_cotacao_item").Equals(String.Empty)) Then
                cotacao.id_central_status_aprovacao = Convert.ToInt32(ViewState.Item("id_situacao_cotacao_item").ToString)
                Select Case cotacao.id_central_status_aprovacao
                    Case 1, 2, 3, 4, 7 'se aprovado tecnico, aprovado gestor, reprovado tecnico, reprovado gestor, em aprovacao
                        cotacao.st_selecionado = "S"
                End Select
            Else
                cotacao.id_central_status_aprovacao = 0
            End If
            'fran f chamado 717/860 rls 24.10 

            If ViewState.Item("st_ver_mercado") = "S" Then
                cotacao.st_ver_mercado = "S"
            Else
                cotacao.st_ver_mercado = String.Empty
            End If
            If ViewState.Item("st_produtor_informado") = "S" Then
                cotacao.st_produtor_informado = "S"
            Else
                cotacao.st_produtor_informado = String.Empty
            End If

            Dim dsCotacoesItens As DataSet = cotacao.getCentralCotacoeseSeusItensbyFilter()

            If (dsCotacoesItens.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsCotacoesItens.Tables(0), ViewState.Item("sortExpression"))
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


            Case "cd_pessoa"
                If (ViewState.Item("sortExpression")) = "cd_pessoa asc" Then
                    ViewState.Item("sortExpression") = "cd_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "cd_pessoa asc"
                End If

            Case "nm_abreviado_pessoa"
                If (ViewState.Item("sortExpression")) = "nm_abreviado_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_abreviado_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_abreviado_pessoa asc"
                End If

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If

            Case "nr_unid_producao"
                If (ViewState.Item("sortExpression")) = "nr_unid_producao asc" Then
                    ViewState.Item("sortExpression") = "nr_unid_producao desc"
                Else
                    ViewState.Item("sortExpression") = "nr_unid_producao asc"
                End If

            Case "id_central_cotacao"
                If (ViewState.Item("sortExpression")) = "id_central_cotacao asc" Then
                    ViewState.Item("sortExpression") = "id_central_cotacao desc"
                Else
                    ViewState.Item("sortExpression") = "id_central_cotacao asc"
                End If
            Case "dt_cotacao"
                If (ViewState.Item("sortExpression")) = "dt_cotacao asc" Then
                    ViewState.Item("sortExpression") = "dt_cotacao desc"
                Else
                    ViewState.Item("sortExpression") = "dt_cotacao asc"
                End If
            Case "ds_tipo_medida"
                If (ViewState.Item("sortExpression")) = "ds_tipo_medida asc" Then
                    ViewState.Item("sortExpression") = "ds_tipo_medida desc"
                Else
                    ViewState.Item("sortExpression") = "ds_tipo_medida asc"
                End If
            Case "nr_quantidade"
                If (ViewState.Item("sortExpression")) = "nr_quantidade asc" Then
                    ViewState.Item("sortExpression") = "nr_quantidade desc"
                Else
                    ViewState.Item("sortExpression") = "nr_quantidade asc"
                End If
            Case "nm_situacao_cotacao"
                If (ViewState.Item("sortExpression")) = "nm_situacao_cotacao asc" Then
                    ViewState.Item("sortExpression") = "nm_situacao_cotacao desc"
                Else
                    ViewState.Item("sortExpression") = "nm_situacao_cotacao asc"
                End If
                'fran i chamado 717/860 rls 24.10 
            Case "nm_central_status_aprovacao"
                If (ViewState.Item("sortExpression")) = "nm_central_status_aprovacao asc" Then
                    ViewState.Item("sortExpression") = "nm_central_status_aprovacao desc"
                Else
                    ViewState.Item("sortExpression") = "nm_central_status_aprovacao asc"
                End If
            Case "cd_item"
                If (ViewState.Item("sortExpression")) = "cd_item asc" Then
                    ViewState.Item("sortExpression") = "cd_item desc"
                Else
                    ViewState.Item("sortExpression") = "cd_item asc"
                End If

                'fran f chamado 717/860 rls 24.10 


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
                Dim produtor As New Pessoa(hf_id_pessoa.Value.ToString)
                lbl_contato.Text = produtor.ds_contato
                lbl_telefone.Text = produtor.ds_telefone_1
                lbl_email.Text = produtor.ds_email
                lbl_fax.Text = produtor.ds_telefone_3

            End If



            'loadData()
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("solcotacao", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("solcotacao", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("solcotacao", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("solcotacao", txt_id_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("solcotacao", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("solcotacao", lbl_nm_propriedade.ID, ViewState.Item("nm_propriedade").ToString)
            customPage.setFilter("solcotacao", cbo_situacao.ID, ViewState.Item("id_situacao_cotacao").ToString)
            customPage.setFilter("solcotacao", cbo_situacao_item.ID, ViewState.Item("id_situacao_cotacao_item").ToString) 'fran f chamado 717/860 rls 24.10 
            customPage.setFilter("solcotacao", txt_cd_item.ID, ViewState.Item("cd_item").ToString)
            customPage.setFilter("solcotacao", lbl_nm_item.ID, ViewState.Item("nm_item").ToString)
            customPage.setFilter("solcotacao", hf_id_item.ID, ViewState.Item("id_item").ToString)
            customPage.setFilter("solcotacao", txt_id_cotacao.ID, ViewState.Item("id_central_cotacao").ToString)
            customPage.setFilter("solcotacao", txt_dt_cotacao.ID, ViewState.Item("dt_cotacao").ToString)
            customPage.setFilter("solcotacao", chk_ver_mercado.ID, ViewState.Item("st_ver_mercado").ToString)
            customPage.setFilter("solcotacao", chk_prod_informado.ID, ViewState.Item("ds_produtor_informado").ToString)
            customPage.setFilter("solcotacao", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    'Private Sub salvarParametrosLupa()

    '    Try
    '        customPage.clearFilters("lupa_estabel")
    '        customPage.setFilter("lupa_estabel", "id_estabelecimento.lupa", cbo_estabelecimento.SelectedValue)

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub
    'Private Sub adicionarAtributoLupa()

    '    Try
    '        With bt_lupa_produtor
    '            .Attributes.Add("onclick", "javascript:ShowDialog()")
    '            .ToolTip = "Filtrar Produtores"
    '        End With

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub


    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_central_solicitar_cotacao.aspx?id_central_cotacao=" + e.CommandArgument.ToString())

            Case "delete"
                deleteCentralCotacao(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteCentralCotacao(ByVal id_central_cotacao As Integer)

        Try
            Dim cotacao As New Cotacao()
            cotacao.id_central_cotacao = id_central_cotacao
            cotacao.id_modificador = Convert.ToInt32(Session("id_login"))
            cotacao.deleteCotacao()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 92
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_central_solicitar_cotacao.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then


        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()
        hl_grupo_pool_compras.Visible = True
        hl_grupo_pool_compras.Enabled = True
        hl_grupo_pool_compras.NavigateUrl = String.Format("lst_grupo_pool_compras_produtor.aspx?id_pessoa={0}", hf_id_pessoa.Value.ToString)

    End Sub


    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        'lbl_nm_pessoa.Visible = False   ' 04/05/2010
        hf_id_pessoa.Value = String.Empty
        'fran chamado 559 i
        lbl_contato.Text = String.Empty
        lbl_telefone.Text = String.Empty
        lbl_email.Text = String.Empty
        lbl_fax.Text = String.Empty
        'fran chamado 559 f
        hl_grupo_pool_compras.Visible = False 'fran 05/05/2010

        'fran chamado 684 i 
        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then

                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'grupo de produtores 'fran 05/05/2010
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                    lbl_contato.Text = dsprodutor.Tables(0).Rows(0).Item("ds_contato")
                    lbl_telefone.Text = dsprodutor.Tables(0).Rows(0).Item("ds_telefone_1")
                    lbl_email.Text = dsprodutor.Tables(0).Rows(0).Item("ds_email")
                    lbl_fax.Text = dsprodutor.Tables(0).Rows(0).Item("ds_telefone_3")
                    hl_grupo_pool_compras.Visible = True

                    ' Adri 04/05/2010 - i
                    hl_grupo_pool_compras.Enabled = True
                    hl_grupo_pool_compras.NavigateUrl = String.Format("lst_grupo_pool_compras_produtor.aspx?id_pessoa={0}", hf_id_pessoa.Value.ToString)
                    ' Adri 04/05/2010 - f

                Else
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = String.Empty
                    hl_grupo_pool_compras.Visible = False

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub txt_cd_item_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_item.TextChanged
        ' Adri 04/05/2010 - i
        lbl_nm_item.Text = String.Empty
        hf_id_item.Value = String.Empty
        Try
            If Not txt_cd_item.Text.ToString.Equals(String.Empty) Then 'fran 05/05/2010
                Dim item As New Item
                item.cd_item = txt_cd_item.Text.Trim
                Dim dsitem As DataSet = item.getItensCentralByFilters
                If dsitem.Tables(0).Rows.Count > 0 Then
                    lbl_nm_item.Enabled = True
                    lbl_nm_item.Text = dsitem.Tables(0).Rows(0).Item("nm_item")
                    hf_id_item.Value = dsitem.Tables(0).Rows(0).Item("id_item").ToString

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' Adri 04/05/2010 - i

    End Sub

    Protected Sub txt_id_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_propriedade.TextChanged
        lbl_nm_propriedade.Text = String.Empty
        hf_id_propriedade.Value = String.Empty
        'Fran 11/03/2010 chamado 684
        Try
            If Not txt_id_propriedade.Text.Equals(String.Empty) Then
                Dim propriedade As New Propriedade
                propriedade.id_propriedade = Convert.ToInt32(txt_id_propriedade.Text.Trim)
                Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters
                If dspropriedade.Tables(0).Rows.Count > 0 Then
                    lbl_nm_propriedade.Enabled = True
                    lbl_nm_propriedade.Text = dspropriedade.Tables(0).Rows(0).Item("nm_propriedade")
                    hf_id_propriedade.Value = dspropriedade.Tables(0).Rows(0).Item("id_propriedade").ToString

                    ' Adri 14/06/2010 - chamado 867 - i
                    hl_grupo_pool_compras.Visible = True
                    hl_grupo_pool_compras.Enabled = True
                    hl_grupo_pool_compras.NavigateUrl = String.Format("lst_grupo_pool_compras_produtor.aspx?id_propriedade={0}", hf_id_propriedade.Value.ToString)
                    ' Adri 14/06/2010 - chamado 867 - f

                Else

                    ' Adri 14/06/2010 - chamado 867 - i
                    hl_grupo_pool_compras.Visible = False
                    ' Adri 14/06/2010 - chamado 867 - f

                End If

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        'Fran 11/03/2010 chamado 684

    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        Me.lbl_nm_propriedade.Visible = True
        carregarCamposPropriedade()

        ' Adriana 14/06/2010 - chamado 867 - i
        hl_grupo_pool_compras.Visible = True
        hl_grupo_pool_compras.Enabled = True
        hl_grupo_pool_compras.NavigateUrl = String.Format("lst_grupo_pool_compras_produtor.aspx?id_propriedade={0}", hf_id_propriedade.Value.ToString)
        ' Adriana 14/06/2010 - chamado 867 - f

    End Sub

    Protected Sub btn_lupa_item_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_item.Click
        Me.lbl_nm_item.Visible = True
        carregarCamposItem()

    End Sub
    Private Sub carregarCamposPropriedade()

        Try



            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                ViewState.Item("id_propriedade") = Me.hf_id_propriedade.Value.ToString
                Me.txt_id_propriedade.Text = ViewState.Item("id_propriedade")
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString

            End If


            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarcampositem()
        Try

            If Not (customPage.getFilterValue("lupa_item", "id_item").Equals(String.Empty)) Then
                ViewState.Item("id_item") = customPage.getFilterValue("lupa_item", "id_item").ToString
            End If
            If Not (customPage.getFilterValue("lupa_item", "cd_item").Equals(String.Empty)) Then
                Me.txt_cd_item.Text = customPage.getFilterValue("lupa_item", "cd_item").ToString
            End If

            If Not (customPage.getFilterValue("lupa_item", "nm_item").Equals(String.Empty)) Then

                Me.lbl_nm_item.Visible = True
                Me.lbl_nm_item.Text = customPage.getFilterValue("lupa_item", "nm_item").ToString
            End If
            customPage.clearFilters("lupa_item")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
