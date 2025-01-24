Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_itens
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("cd_item") = txt_cd_item.Text.Trim().ToString
        ViewState.Item("nm_item") = txt_nm_item.Text.Trim().ToString
        ViewState.Item("id_grupo") = cbo_cd_grupo.SelectedValue.ToString
        'Alexandre 01/12/2009 Chamado 553 - i.
        'ViewState.Item("id_unidade_medida") = cbo_unidade_medida.SelectedValue.ToString 
        ViewState.Item("id_categoria_item") = cbo_categoria.SelectedValue.ToString 'fran fase 3

        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue.ToString
        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        Response.Redirect("lst_itens.aspx?st_incluirlog=N")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_itens.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 90
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
			cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'Alexandre 01/12/2009 Chamado 553 - i.
            'Dim unidadeMedida As New UnidadeMedida

            'cbo_unidade_medida.DataSource = unidadeMedida.getunidade_medidaByfilters
            'cbo_unidade_medida.DataTextField = "ds_unidade_medida"
            'cbo_unidade_medida.DataValueField = "id_unidade_medida"
            'cbo_unidade_medida.DataBind()
            'cbo_unidade_medida.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'Alexandre 01/12/2009 Chamado 553 - f.
            Dim grupo_itens As New GrupoItens()
            cbo_cd_grupo.DataSource = grupo_itens.getGrupos_itensByFilters
            cbo_cd_grupo.DataTextField = "ds_grupo_itens"
            cbo_cd_grupo.DataValueField = "id_grupo_itens"
            cbo_cd_grupo.DataBind()
            cbo_cd_grupo.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            'fran fase 3
            Dim categoria As New CategoriaItem()
            cbo_categoria.DataSource = categoria.getCategoriaItemByFilters
            cbo_categoria.DataTextField = "nm_categoria_item"
            cbo_categoria.DataValueField = "id_categoria_item"
            cbo_categoria.DataBind()
            cbo_categoria.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            ViewState.Item("sortExpression") = "cd_item asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("lst_itens", txt_cd_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_item") = customPage.getFilterValue("lst_itens", txt_cd_item.ID)
            txt_cd_item.Text = ViewState.Item("cd_item").ToString()
        Else
            ViewState.Item("cd_item") = String.Empty
        End If

        If Not (customPage.getFilterValue("lst_itens", txt_nm_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_item") = customPage.getFilterValue("lst_itens", txt_nm_item.ID)
            txt_nm_item.Text = ViewState.Item("nm_item").ToString()
        Else
            ViewState.Item("nm_item") = String.Empty
        End If
        If Not (customPage.getFilterValue("lst_itens", cbo_cd_grupo.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_grupo") = customPage.getFilterValue("lst_itens", cbo_cd_grupo.ID)
            cbo_cd_grupo.Text = ViewState.Item("id_grupo").ToString()
        Else
            ViewState.Item("id_grupo") = String.Empty
        End If

        'fran fase 3 melhoria i
        If Not (customPage.getFilterValue("lst_itens", cbo_categoria.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_categoria_item") = customPage.getFilterValue("lst_itens", cbo_categoria.ID)
            cbo_categoria.Text = ViewState.Item("id_categoria_item").ToString()
        Else
            ViewState.Item("id_categoria_item") = String.Empty
        End If
        'fran fase 3 melhoria f

        'Alexandre 01/12/2009 Chamado 553 - i.
        'If Not (customPage.getFilterValue("lst_itens", cbo_unidade_medida.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("id_unidade_medida") = customPage.getFilterValue("lst_itens", cbo_unidade_medida.ID)
        '    cbo_unidade_medida.Text = ViewState.Item("id_unidade_medida").ToString()
        'Else
        '    ViewState.Item("id_unidade_medida") = String.Empty
        'End If
        'Alexandre 01/12/2009 Chamado 553 - f.

        If Not (customPage.getFilterValue("lst_itens", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("lst_itens", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("lst_itens", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("lst_itens", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("lst_itens")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim item As New Item

            item.cd_item = ViewState.Item("cd_item").ToString()
            item.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            item.nm_item = ViewState.Item("nm_item").ToString

            If Not ViewState.Item("id_categoria_item") = String.Empty Then
                item.id_categoria_item = ViewState.Item("id_categoria_item")
            End If
            'Alexandre 01/12/2009 Chamado 553 - i.
            'If Not ViewState.Item("id_unidade_medida") = String.Empty Then
            '    item.id_unidade_medida = Convert.ToInt32(ViewState.Item("id_unidade_medida"))
            'End If
            'Alexandre 01/12/2009 Chamado 553 - f.

            If Not ViewState.Item("id_grupo") = String.Empty Then
                item.id_grupo_itens = Convert.ToInt32(ViewState.Item("id_grupo"))
            End If

            'Dim dsitem As DataSet = item.getItensByFilters
            Dim dsitem As DataSet = item.getItensCentralByFilters()  ' Adri 18/11/2009 (não enviar o parametro @st_central_compras para trazer itens de leite e central)

            If (dsitem.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsitem.Tables(0), ViewState.Item("sortExpression"))
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
        Me.loadData()

    End Sub


    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "cd_item"
                If (ViewState.Item("sortExpression")) = "cd_item asc" Then
                    ViewState.Item("sortExpression") = "cd_item desc"
                Else
                    ViewState.Item("sortExpression") = "cd_item asc"
                End If

            Case "nm_item"
                If (ViewState.Item("sortExpression")) = "nm_item asc" Then
                    ViewState.Item("sortExpression") = "nm_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_item asc"
                End If

            Case "cd_deposito"
                If (ViewState.Item("sortExpression")) = "cd_deposito asc" Then
                    ViewState.Item("sortExpression") = "cd_deposito desc"
                Else
                    ViewState.Item("sortExpression") = "cd_deposito asc"
                End If

            Case "cd_classificacao_fiscal"
                If (ViewState.Item("sortExpression")) = "cd_classificacao_fiscal asc" Then
                    ViewState.Item("sortExpression") = "cd_classificacao_fiscal desc"
                Else
                    ViewState.Item("sortExpression") = "cd_classificacao_fiscal asc"
                End If

            Case "ds_unidade_medida"
                If (ViewState.Item("sortExpression")) = "ds_unidade_medida asc" Then
                    ViewState.Item("sortExpression") = "ds_unidade_medida desc"
                Else
                    ViewState.Item("sortExpression") = "ds_unidade_medida asc"
                End If

            Case "ds_grupo_itens"
                If (ViewState.Item("sortExpression")) = "ds_grupo_itens asc" Then
                    ViewState.Item("sortExpression") = "ds_grupo_itens desc"
                Else
                    ViewState.Item("sortExpression") = "ds_grupo_itens asc"
                End If

            Case "ds_conta"
                If (ViewState.Item("sortExpression")) = "ds_conta asc" Then
                    ViewState.Item("sortExpression") = "ds_conta desc"
                Else
                    ViewState.Item("sortExpression") = "ds_conta asc"
                End If
            Case "nm_categoria_item" 'fase 3
                If (ViewState.Item("sortExpression")) = "nm_categoria_item asc" Then
                    ViewState.Item("sortExpression") = "nm_categoria_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_categoria_item asc"
                End If

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("lst_itens", txt_cd_item.ID, ViewState.Item("cd_item").ToString)
            customPage.setFilter("lst_itens", txt_nm_item.ID, ViewState.Item("nm_item").ToString)
            customPage.setFilter("lst_itens", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("lst_itens", cbo_cd_grupo.ID, ViewState.Item("id_grupo").ToString)
            customPage.setFilter("lst_itens", cbo_categoria.ID, ViewState.Item("id_categoria_item").ToString) 'fran fase 3
            ' customPage.setFilter("lst_itens", cbo_unidade_medida.ID, ViewState.Item("id_unidade_medida").ToString) 'Alexandre 01/12/2009 Chamado 553 - i.
            customPage.setFilter("lst_itens", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_itens.aspx?id_itens=" + e.CommandArgument.ToString())

            Case "delete"
                deleteitens(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteitens(ByVal id_itens As Integer)

        Try

            Dim item As New Item

            item.id_item = id_itens
            item.id_modificador = Convert.ToInt32(Session("id_login"))
            item.deleteitem()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 90
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_itens.aspx")
    End Sub
End Class
