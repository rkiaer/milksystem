Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_usuario
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then

            ViewState.Item("ds_login") = txt_login.Text.Trim()
            ViewState.Item("nm_usuario") = txt_nm_usuario.Text.Trim()
            ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
            ViewState.Item("id_tipo_usuario") = cbo_tipo_usuario.SelectedValue

            loadData()
        End If
    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_usuario.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_usuario.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 60
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

            Dim tipousuario As New TipoUsuario

            cbo_tipo_usuario.DataSource = tipousuario.getTipoUsuariosByFilters()
            cbo_tipo_usuario.DataTextField = "nm_tipo_usuario"
            cbo_tipo_usuario.DataValueField = "id_tipo_usuario"
            cbo_tipo_usuario.DataBind()
            cbo_tipo_usuario.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            ViewState.Item("sortExpression") = "ds_login asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("usuario", txt_login.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_login") = customPage.getFilterValue("usuario", txt_login.ID)
            txt_login.Text = ViewState.Item("ds_login").ToString()
        Else
            ViewState.Item("ds_login") = String.Empty
        End If

        If Not (customPage.getFilterValue("usuario", txt_nm_usuario.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_usuario") = customPage.getFilterValue("usuario", txt_nm_usuario.ID)
            txt_nm_usuario.Text = ViewState.Item("nm_usuario").ToString()
        Else
            ViewState.Item("nm_usuario") = String.Empty
        End If

        If Not (customPage.getFilterValue("usuario", cbo_tipo_usuario.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_tipo_usuario") = customPage.getFilterValue("usuario", cbo_tipo_usuario.ID)
            cbo_tipo_usuario.SelectedValue = ViewState.Item("id_tipo_usuario").ToString()
        Else
            ViewState.Item("id_tipo_usuario") = String.Empty
        End If

        If Not (customPage.getFilterValue("usuario", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("usuario", cbo_situacao.ID)
            cbo_situacao.SelectedValue = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("usuario", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("usuario", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("usuario")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim usuario As New Usuario

            usuario.ds_login = ViewState.Item("ds_login").ToString()
            usuario.nm_usuario = ViewState.Item("nm_usuario").ToString()
            usuario.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

            If Not (ViewState.Item("id_tipo_usuario").ToString.Equals(String.Empty)) Then
                usuario.id_tipo_usuario = Convert.ToInt32(ViewState.Item("id_tipo_usuario"))
            End If

            usuario.id_modificador = Session("id_login")

            Dim dsUsuario As DataSet = usuario.getUsuarioByFilters()

            If (dsUsuario.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsUsuario.Tables(0), ViewState.Item("sortExpression"))
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

    Private Sub saveFilters()

        Try

            customPage.setFilter("usuario", txt_login.ID, ViewState.Item("ds_login").ToString)
            customPage.setFilter("usuario", txt_nm_usuario.ID, ViewState.Item("nm_usuario").ToString)
            customPage.setFilter("usuario", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("usuario", cbo_tipo_usuario.ID, ViewState.Item("id_tipo_usuario").ToString)
            customPage.setFilter("usuario", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_usuario.aspx?id_usuario=" + e.CommandArgument.ToString())

            Case "delete"
                deleteUsuario(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteUsuario(ByVal id_usuario As Integer)

        Try

            Dim usuario As New Usuario()
            usuario.id_usuario = id_usuario
            usuario.id_modificador = Convert.ToInt32(Session("id_login"))
            usuario.deleteUsuario()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 60
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
        Response.Redirect("frm_usuario.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

 
End Class
