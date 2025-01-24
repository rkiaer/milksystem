Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_grupo_pool_compras
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("cd_grupo_pool_compras") = txt_cd_grupo_pool_compras.Text.Trim().ToString
        ViewState.Item("nm_grupo_pool_compras") = txt_nm_grupo_pool_compras.Text.Trim().ToString
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue.ToString
        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_grupo_pool_compras.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_pessoa.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 99
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
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ViewState.Item("sortExpression") = "cd_grupo_pool_compras asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("grupo_pool_compras", txt_cd_grupo_pool_compras.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_grupo_pool_compras") = customPage.getFilterValue("grupo_pool_compras", txt_cd_grupo_pool_compras.ID)
            txt_cd_grupo_pool_compras.Text = ViewState.Item("cd_grupo_pool_compras").ToString()
        Else
            ViewState.Item("cd_grupo_pool_compras") = String.Empty
        End If

        If Not (customPage.getFilterValue("grupo_pool_compras", txt_nm_grupo_pool_compras.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_grupo_pool_compras") = customPage.getFilterValue("grupo_pool_compras", txt_nm_grupo_pool_compras.ID)
            txt_nm_grupo_pool_compras.Text = ViewState.Item("nm_grupo_pool_compras").ToString()
        Else
            ViewState.Item("nm_grupo_pool_compras") = String.Empty
        End If

        If Not (customPage.getFilterValue("grupo_pool_compras", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("grupo_pool_compras", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("grupo_pool_compras", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("grupo_pool_compras", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("grupo_pool_compras")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim grupo_pool_compras As New GrupoPoolCompras

            grupo_pool_compras.cd_grupo_pool_compras = ViewState.Item("cd_grupo_pool_compras").ToString()
            grupo_pool_compras.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            grupo_pool_compras.nm_grupo_pool_compras = ViewState.Item("nm_grupo_pool_compras").ToString

            Dim dsgrupo_pool_compras As DataSet = grupo_pool_compras.getGrupos_pool_comprasByFilters

            If (dsgrupo_pool_compras.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsgrupo_pool_compras.Tables(0), ViewState.Item("sortExpression"))
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


            Case "cd_grupo_pool_compras"
                If (ViewState.Item("sortExpression")) = "cd_grupo_pool_compras asc" Then
                    ViewState.Item("sortExpression") = "cd_grupo_pool_compras desc"
                Else
                    ViewState.Item("sortExpression") = "cd_grupo_pool_compras asc"
                End If


            Case "nm_grupo_pool_compras"
                If (ViewState.Item("sortExpression")) = "nm_grupo_pool_compras asc" Then
                    ViewState.Item("sortExpression") = "nm_grupo_pool_compras desc"
                Else
                    ViewState.Item("sortExpression") = "nm_grupo_pool_compras asc"
                End If




        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("grupo_pool_compras", txt_cd_grupo_pool_compras.ID, ViewState.Item("cd_grupo_pool_compras").ToString)
            customPage.setFilter("grupo_pool_compras", txt_nm_grupo_pool_compras.ID, ViewState.Item("nm_grupo_pool_compras").ToString)
            customPage.setFilter("grupo_pool_compras", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("grupo_pool_compras", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_grupo_pool_compras.aspx?id_grupo_pool_compras=" + e.CommandArgument.ToString())

            Case "delete"
                deletegrupo_pool_compras(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deletegrupo_pool_compras(ByVal id_grupo_pool_compras As Integer)

        Try

            Dim grupo_pool_compras As New GrupoPoolCompras

            grupo_pool_compras.id_grupo_pool_compras = id_grupo_pool_compras
            grupo_pool_compras.id_modificador = Convert.ToInt32(Session("id_login"))
            grupo_pool_compras.deletegrupo_pool_compras()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 99
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
        Response.Redirect("frm_grupo_pool_compras.aspx")
    End Sub
End Class
