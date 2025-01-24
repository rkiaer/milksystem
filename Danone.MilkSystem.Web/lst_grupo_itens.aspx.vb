Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_grupo_itens
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("cd_grupo_itens") = txt_cd_grupo_itens.Text.Trim().ToString
        ViewState.Item("nm_grupo_itens") = txt_nm_grupo_itens.Text.Trim().ToString
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue.ToString
        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_grupo_itens.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_grupo_itens.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 91
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

            ViewState.Item("sortExpression") = "cd_grupo_itens asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

     
        If Not (customPage.getFilterValue("grupo_itens", txt_cd_grupo_itens.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_grupo_itens") = customPage.getFilterValue("grupo_itens", txt_cd_grupo_itens.ID)
            txt_cd_grupo_itens.Text = ViewState.Item("cd_grupo_itens").ToString()
        Else
            ViewState.Item("cd_grupo_itens") = String.Empty
        End If

        If Not (customPage.getFilterValue("grupo_itens", txt_nm_grupo_itens.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_grupo_itens") = customPage.getFilterValue("grupo_itens", txt_nm_grupo_itens.ID)
            txt_nm_grupo_itens.Text = ViewState.Item("nm_grupo_itens").ToString()
        Else
            ViewState.Item("nm_grupo_itens") = String.Empty
        End If

        If Not (customPage.getFilterValue("grupo_itens", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("grupo_itens", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("grupo_itens", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("grupo_itens", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("grupo_itens")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim grupo_itens As New GrupoItens

            grupo_itens.cd_grupo_itens = ViewState.Item("cd_grupo_itens").ToString()
            grupo_itens.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            grupo_itens.nm_grupo_itens = ViewState.Item("nm_grupo_itens").ToString

            Dim dsgrupo_itens As DataSet = grupo_itens.getGrupos_itensByFilters

            If (dsgrupo_itens.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsgrupo_itens.Tables(0), ViewState.Item("sortExpression"))
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


            Case "cd_grupo_itens"
                If (ViewState.Item("sortExpression")) = "cd_grupo_itens asc" Then
                    ViewState.Item("sortExpression") = "cd_grupo_itens desc"
                Else
                    ViewState.Item("sortExpression") = "cd_grupo_itens asc"
                End If


            Case "nm_grupo_itens"
                If (ViewState.Item("sortExpression")) = "nm_grupo_itens asc" Then
                    ViewState.Item("sortExpression") = "nm_grupo_itens desc"
                Else
                    ViewState.Item("sortExpression") = "nm_grupo_itens asc"
                End If

                ' 19/01/2010 - Chamado 596 - i
            Case "nm_situacao"
                If (ViewState.Item("sortExpression")) = "nm_situacao asc" Then
                    ViewState.Item("sortExpression") = "nm_situacao desc"
                Else
                    ViewState.Item("sortExpression") = "nm_situacao asc"
                End If
                ' 19/01/2010 - Chamado 596 - f



        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("grupo_itens", txt_cd_grupo_itens.ID, ViewState.Item("cd_grupo_itens").ToString)
            customPage.setFilter("grupo_itens", txt_nm_grupo_itens.ID, ViewState.Item("nm_grupo_itens").ToString)
            customPage.setFilter("grupo_itens", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("grupo_itens", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_grupo_itens.aspx?id_grupo_itens=" + e.CommandArgument.ToString())

            Case "delete"
                deletegrupo_itens(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deletegrupo_itens(ByVal id_grupo_itens As Int32)

        Try

            Dim grupo_itens As New GrupoItens
            grupo_itens.id_grupo_itens = id_grupo_itens
            grupo_itens.id_modificador = Convert.ToInt32(Session("id_login"))
            grupo_itens.deletegrupo_itens()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 91
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
        Response.Redirect("frm_grupo_itens.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
                  And e.Row.RowType <> DataControlRowType.Footer _
                  And e.Row.RowType <> DataControlRowType.Pager) Then

            If (e.Row.Cells(2).Text.Trim().Equals("1")) Then
                e.Row.Cells(2).Text = "Ativo"
            End If
            If (e.Row.Cells(2).Text.Trim().Equals("2")) Then
                e.Row.Cells(2).Text = "Inativo"
            End If

            'fran 07/03/2010 i
            'ao inativar um grupo de itens verificar se há itens ativos. Caso haja não deixar desativar.
            Dim lbl_id_grupo_itens As Label = CType(e.Row.FindControl("lbl_id_grupo_itens"), Label)
            Dim item As New Item
            item.id_grupo_itens = Convert.ToInt32(lbl_id_grupo_itens.Text)
            item.id_situacao = 1
            Dim dsitem As DataSet = item.getItensByGrupoItem
            Dim img_delete As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)

            If dsitem.Tables(0).Rows.Count > 0 Then 'se tem itens ativos
                img_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                img_delete.ToolTip = "Grupo de Itens não pode ser desativado pois possui itens ativos."
                img_delete.Enabled = False
            Else
                img_delete.ImageUrl = "~/img/icone_excluir.gif"
                img_delete.Enabled = True
                img_delete.ToolTip = String.Empty
            End If
            'fran 07/03/2010 f

        End If
    End Sub
End Class
