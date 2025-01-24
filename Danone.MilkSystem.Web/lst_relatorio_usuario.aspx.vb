Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_relatorio_usuario
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then

            ViewState.Item("ds_login") = txt_login.Text.Trim()
            ViewState.Item("nm_usuario") = txt_nm_usuario.Text.Trim()
            ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
            ViewState.Item("id_tipo_usuario") = cbo_tipo_usuario.SelectedValue
            ViewState.Item("tipo_relatorio") = cbo_relatorio.SelectedValue
            ViewState.Item("id_grupo") = cbo_grupo.SelectedValue
            ViewState.Item("id_menu") = cbo_menu.SelectedValue
            ViewState.Item("id_menu_item") = cbo_menu_item.SelectedValue

            loadData()
        End If
    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_relatorio_usuario.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_usuario.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 205
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim tipousuario As New TipoUsuario

            cbo_tipo_usuario.DataSource = tipousuario.getTipoUsuariosByFilters()
            cbo_tipo_usuario.DataTextField = "nm_tipo_usuario"
            cbo_tipo_usuario.DataValueField = "id_tipo_usuario"
            cbo_tipo_usuario.DataBind()
            cbo_tipo_usuario.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim grupo As New GrupoCadastro
            grupo.id_situacao = 1
            Dim dsgrupo As DataSet = grupo.getGrupoByFilters()
            cbo_grupo.DataSource = Helper.getDataView(dsgrupo.Tables(0), "nm_grupo")
            cbo_grupo.DataTextField = "nm_grupo"
            cbo_grupo.DataValueField = "id_grupo"
            cbo_grupo.DataBind()
            cbo_grupo.Items.Insert(0, New ListItem("[Selecione]", 0))
            cbo_grupo.Enabled = False

            Dim menu As New Menu
            menu.id_situacao = 1
            Dim dsmenu As DataSet = menu.getMenuByFilters()
            cbo_menu.DataSource = Helper.getDataView(dsmenu.Tables(0), "nm_menu")
            cbo_menu.DataTextField = "nm_menu"
            cbo_menu.DataValueField = "id_menu"
            cbo_menu.DataBind()
            cbo_menu.Items.Insert(0, New ListItem("[Selecione]", 0))
            cbo_menu.Enabled = False

            cbo_menu_item.Items.Insert(0, New ListItem("[Selecione]", 0))
            cbo_menu_item.Enabled = False

            ViewState.Item("sortExpression") = "nm_usuario asc"



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

 
    Private Sub loadData()

        Try

            Dim usugrupo As New UsuarioGrupo
            Dim usuario As New Usuario

            Select Case ViewState.Item("tipo_relatorio").ToString

                Case "U" 'relatorio usuario
                    gridUsuGrupo.Visible = False
                    gridUsuMenus.Visible = False
                    gridGrupoMenu.Visible = False

                    usuario.ds_login = ViewState.Item("ds_login").ToString()
                    usuario.nm_usuario = ViewState.Item("nm_usuario").ToString()
                    usuario.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
                    If Not (ViewState.Item("id_tipo_usuario").ToString.Equals(String.Empty)) Then
                        usuario.id_tipo_usuario = Convert.ToInt32(ViewState.Item("id_tipo_usuario"))
                    End If

                    Dim dsUsuario As DataSet = usuario.getUsuarioByFilters()

                    If (dsUsuario.Tables(0).Rows.Count > 0) Then
                        gridResults.Visible = True
                        gridResults.DataSource = Helper.getDataView(dsUsuario.Tables(0), ViewState.Item("sortExpression"))
                        gridResults.DataBind()
                    Else
                        gridResults.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If

                Case "UG"
                    gridResults.Visible = False
                    gridUsuMenus.Visible = False
                    gridGrupoMenu.Visible = False

                    usugrupo.ds_login = ViewState.Item("ds_login").ToString()
                    usugrupo.nm_usuario = ViewState.Item("nm_usuario").ToString()
                    usugrupo.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
                    If Not (ViewState.Item("id_tipo_usuario").ToString.Equals(String.Empty)) Then
                        usugrupo.id_tipo_usuario = Convert.ToInt32(ViewState.Item("id_tipo_usuario"))
                    End If
                    usugrupo.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString())

                    Dim dsusugrupo As DataSet = usugrupo.getRelatorioUsuarioGrupos

                    If (dsusugrupo.Tables(0).Rows.Count > 0) Then
                        gridUsuGrupo.Visible = True
                        gridUsuGrupo.DataSource = Helper.getDataView(dsusugrupo.Tables(0), ViewState.Item("sortExpression"))
                        gridUsuGrupo.DataBind()
                    Else
                        gridUsuGrupo.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If

                Case "UM"
                    gridResults.Visible = False
                    gridUsuGrupo.Visible = False
                    gridGrupoMenu.Visible = False

                    usugrupo.ds_login = ViewState.Item("ds_login").ToString()
                    usugrupo.nm_usuario = ViewState.Item("nm_usuario").ToString()
                    usugrupo.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
                    If Not (ViewState.Item("id_tipo_usuario").ToString.Equals(String.Empty)) Then
                        usugrupo.id_tipo_usuario = Convert.ToInt32(ViewState.Item("id_tipo_usuario"))
                    End If
                    usugrupo.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString())
                    usugrupo.id_menu = Convert.ToInt32(ViewState.Item("id_menu").ToString())
                    usugrupo.id_menu_item = Convert.ToInt32(ViewState.Item("id_menu_item").ToString())

                    Dim dsusugrupo As DataSet = usugrupo.getRelatorioUsuarioGruposMenus

                    If (dsusugrupo.Tables(0).Rows.Count > 0) Then
                        gridUsuMenus.Visible = True
                        gridUsuMenus.DataSource = Helper.getDataView(dsusugrupo.Tables(0), ViewState.Item("sortExpression"))
                        gridUsuMenus.DataBind()
                    Else
                        gridUsuMenus.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If

                Case "GM"
                    gridResults.Visible = False
                    gridUsuGrupo.Visible = False
                    gridUsuMenus.Visible = False

                    Dim grupomenu As New GrupoAcesso

                    grupomenu.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString())
                    grupomenu.id_menu = Convert.ToInt32(ViewState.Item("id_menu").ToString())
                    grupomenu.id_menu_item = Convert.ToInt32(ViewState.Item("id_menu_item").ToString())

                    Dim dsgrupo As DataSet = grupomenu.getRelatorioGruposMenus

                    If (dsgrupo.Tables(0).Rows.Count > 0) Then
                        gridGrupoMenu.Visible = True
                        gridGrupoMenu.DataSource = Helper.getDataView(dsgrupo.Tables(0), ViewState.Item("sortExpression"))
                        gridGrupoMenu.DataBind()
                    Else
                        gridGrupoMenu.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If


            End Select


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "ds_login"
                If (ViewState.Item("sortExpression")) = "ds_login asc" Then
                    ViewState.Item("sortExpression") = "ds_login desc"
                Else
                    ViewState.Item("sortExpression") = "ds_login asc"
                End If


            Case "nm_usuario"
                If (ViewState.Item("sortExpression")) = "nm_usuario asc" Then
                    ViewState.Item("sortExpression") = "nm_usuario desc"
                Else
                    ViewState.Item("sortExpression") = "nm_usuario asc"
                End If

        End Select

        loadData()

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Page.IsValid Then

            ViewState.Item("ds_login") = txt_login.Text.Trim()
            ViewState.Item("nm_usuario") = txt_nm_usuario.Text.Trim()
            ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
            ViewState.Item("id_tipo_usuario") = cbo_tipo_usuario.SelectedValue
            ViewState.Item("tipo_relatorio") = cbo_relatorio.SelectedValue
            ViewState.Item("id_grupo") = cbo_grupo.SelectedValue
            ViewState.Item("id_menu") = cbo_menu.SelectedValue
            ViewState.Item("id_menu_item") = cbo_menu_item.SelectedValue

            loadData()

            Select Case ViewState.Item("tipo_relatorio").ToString

                Case "U"
                    If gridResults.Rows.Count > 0 Then
                        'FRAN 08/12/2020 i incluir log 
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 8 'exporta~ção
                        usuariolog.id_menu_item = 205
                        usuariolog.ds_nm_processo = "Usuários"
                        usuariolog.insertUsuarioLog()
                        'FRAN 08/12/2020  incluir log 

                        Response.Redirect("frm_usuario_excel.aspx?id_situacao=" + ViewState.Item("id_situacao").ToString() + "&nm_usuario=" + ViewState.Item("nm_usuario").ToString() + "&id_tipo_usuario=" + ViewState.Item("id_tipo_usuario").ToString() + "&ds_login=" + ViewState.Item("ds_login").ToString())

                    End If

                Case "UG"
                    If gridUsuGrupo.Rows.Count > 0 Then
                        'FRAN 08/12/2020 i incluir log 
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 8 'exporta~ção
                        usuariolog.id_menu_item = 205
                        usuariolog.ds_nm_processo = "Usuários X Grupos"
                        usuariolog.insertUsuarioLog()
                        'FRAN 08/12/2020  incluir log 

                        Response.Redirect("frm_relatorio_usuario_grupo_excel.aspx?id_situacao=" + ViewState.Item("id_situacao").ToString() + "&nm_usuario=" + ViewState.Item("nm_usuario").ToString() + "&id_tipo_usuario=" + ViewState.Item("id_tipo_usuario").ToString() + "&ds_login=" + ViewState.Item("ds_login").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString())

                    End If

                Case "UM"
                    If gridUsuMenus.Rows.Count > 0 Then
                        'FRAN 08/12/2020 i incluir log 
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 8 'exporta~ção
                        usuariolog.id_menu_item = 205
                        usuariolog.ds_nm_processo = "Usuários X Grupos"
                        usuariolog.insertUsuarioLog()
                        'FRAN 08/12/2020  incluir log 

                        Response.Redirect("frm_relatorio_usuario_menu_excel.aspx?id_situacao=" + ViewState.Item("id_situacao").ToString() + "&nm_usuario=" + ViewState.Item("nm_usuario").ToString() + "&id_tipo_usuario=" + ViewState.Item("id_tipo_usuario").ToString() + "&ds_login=" + ViewState.Item("ds_login").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString() + "&id_menu=" + ViewState.Item("id_menu").ToString() + "&id_menu_item=" + ViewState.Item("id_menu_item").ToString())

                    End If

                Case "GM"
                    If gridGrupoMenu.Rows.Count > 0 Then
                        'FRAN 08/12/2020 i incluir log 
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 8 'exporta~ção
                        usuariolog.id_menu_item = 205
                        usuariolog.ds_nm_processo = "Grupos X Menus"
                        usuariolog.insertUsuarioLog()
                        'FRAN 08/12/2020  incluir log 

                        Response.Redirect("frm_relatorio_grupo_menu_excel.aspx?id_grupo=" + ViewState.Item("id_grupo").ToString() + "&id_menu=" + ViewState.Item("id_menu").ToString() + "&id_menu_item=" + ViewState.Item("id_menu_item").ToString())

                    End If


            End Select
        End If
    End Sub

    Protected Sub cbo_relatorio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_relatorio.SelectedIndexChanged

        Select Case cbo_relatorio.SelectedValue
            Case "U"
                cbo_grupo.SelectedValue = 0
                cbo_grupo.Enabled = False
                cbo_menu.SelectedValue = 0
                cbo_menu.Enabled = False
                cbo_menu_item.SelectedValue = 0
                cbo_menu_item.Enabled = False
                ViewState.Item("sortExpression") = "nm_usuario asc"

            Case "UG"
                cbo_grupo.SelectedValue = 0
                cbo_grupo.Enabled = True
                cbo_menu.SelectedValue = 0
                cbo_menu.Enabled = False
                cbo_menu_item.SelectedValue = 0
                cbo_menu_item.Enabled = False
                ViewState.Item("sortExpression") = "nm_usuario asc, nm_grupo"


            Case "UM"
                cbo_grupo.SelectedValue = 0
                cbo_grupo.Enabled = True
                cbo_menu.SelectedValue = 0
                cbo_menu.Enabled = True
                cbo_menu_item.SelectedValue = 0
                cbo_menu_item.Enabled = True
                ViewState.Item("sortExpression") = "nm_usuario asc"

            Case "GM"
                cbo_grupo.SelectedValue = 0
                cbo_grupo.Enabled = True
                cbo_menu.SelectedValue = 0
                cbo_menu.Enabled = True
                cbo_menu_item.SelectedValue = 0
                cbo_menu_item.Enabled = True
                ViewState.Item("sortExpression") = "nm_grupo, nm_menu, nm_menu_item"

        End Select

    End Sub

    Protected Sub cbo_menu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_menu.SelectedIndexChanged
        cbo_menu_item.Items.Clear()

        If cbo_menu.SelectedValue <> "0" Then
            cbo_menu_item.Enabled = True

            Dim menuitem As New MenuItem
            menuitem.id_menu = cbo_menu.SelectedValue
            menuitem.id_situacao = 1
            Dim dsmenuitem As DataSet = menuitem.getMenuItem
            cbo_menu_item.DataSource = Helper.getDataView(dsmenuitem.Tables(0), "nm_menu_item")
            cbo_menu_item.DataTextField = "nm_menu_item"
            cbo_menu_item.DataValueField = "id_menu_item"
            cbo_menu_item.DataBind()
            cbo_menu_item.Items.Insert(0, New ListItem("[Selecione]", 0))
            cbo_menu_item.SelectedValue = "0"

        Else
            cbo_menu_item.Items.Insert(0, New ListItem("[Selecione]", 0))
            cbo_menu_item.SelectedValue = "0"
            cbo_menu_item.Enabled = False
        End If

    End Sub

    Protected Sub gridGrupoMenu_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridGrupoMenu.PageIndexChanging
        gridGrupoMenu.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub

    Protected Sub gridUsuGrupo_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridUsuGrupo.PageIndexChanging
        gridUsuGrupo.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub

    Protected Sub gridUsuMenus_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridUsuMenus.PageIndexChanging
        gridUsuMenus.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub

    Protected Sub gridUsuGrupo_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridUsuGrupo.Sorting
        Select Case e.SortExpression.ToLower()


            Case "ds_login"
                If (ViewState.Item("sortExpression")) = "ds_login asc" Then
                    ViewState.Item("sortExpression") = "ds_login desc"
                Else
                    ViewState.Item("sortExpression") = "ds_login asc"
                End If


            Case "nm_usuario"
                If (ViewState.Item("sortExpression")) = "nm_usuario asc" Then
                    ViewState.Item("sortExpression") = "nm_usuario desc"
                Else
                    ViewState.Item("sortExpression") = "nm_usuario asc"
                End If

            Case "nm_grupo"
                If (ViewState.Item("sortExpression")) = "nm_grupo asc" Then
                    ViewState.Item("sortExpression") = "nm_grupo desc"
                Else
                    ViewState.Item("sortExpression") = "nm_grupo asc"
                End If
        End Select

        loadData()

    End Sub

    Protected Sub gridUsuMenus_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridUsuMenus.Sorting
        Select Case e.SortExpression.ToLower()


            Case "ds_login"
                If (ViewState.Item("sortExpression")) = "ds_login asc" Then
                    ViewState.Item("sortExpression") = "ds_login desc"
                Else
                    ViewState.Item("sortExpression") = "ds_login asc"
                End If


            Case "nm_usuario"
                If (ViewState.Item("sortExpression")) = "nm_usuario asc" Then
                    ViewState.Item("sortExpression") = "nm_usuario desc"
                Else
                    ViewState.Item("sortExpression") = "nm_usuario asc"
                End If

            Case "nm_grupo"
                If (ViewState.Item("sortExpression")) = "nm_grupo asc" Then
                    ViewState.Item("sortExpression") = "nm_grupo desc"
                Else
                    ViewState.Item("sortExpression") = "nm_grupo asc"
                End If

            Case "nm_menu"
                If (ViewState.Item("sortExpression")) = "nm_menu asc" Then
                    ViewState.Item("sortExpression") = "nm_menu desc"
                Else
                    ViewState.Item("sortExpression") = "nm_menu asc"
                End If

            Case "nm_menu_item"
                If (ViewState.Item("sortExpression")) = "nm_menu_item asc" Then
                    ViewState.Item("sortExpression") = "nm_menu_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_menu_item asc"
                End If


        End Select

        loadData()
    End Sub

    Protected Sub gridGrupoMenu_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridGrupoMenu.Sorting
        Select Case e.SortExpression.ToLower()

            Case "nm_grupo"
                If (ViewState.Item("sortExpression")) = "nm_grupo asc" Then
                    ViewState.Item("sortExpression") = "nm_grupo desc"
                Else
                    ViewState.Item("sortExpression") = "nm_grupo asc"
                End If

            Case "nm_menu"
                If (ViewState.Item("sortExpression")) = "nm_menu asc" Then
                    ViewState.Item("sortExpression") = "nm_menu desc"
                Else
                    ViewState.Item("sortExpression") = "nm_menu asc"
                End If

            Case "nm_menu_item"
                If (ViewState.Item("sortExpression")) = "nm_menu_item asc" Then
                    ViewState.Item("sortExpression") = "nm_menu_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_menu_item asc"
                End If

            Case "nm_menu_item_processo"
                If (ViewState.Item("sortExpression")) = "nm_menu_item_processo asc" Then
                    ViewState.Item("sortExpression") = "nm_menu_item_processo desc"
                Else
                    ViewState.Item("sortExpression") = "nm_menu_item_processo asc"
                End If


        End Select

        loadData()
    End Sub
End Class
