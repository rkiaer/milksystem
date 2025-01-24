Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_tecnico
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Not (txt_cd_tecnico.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_tecnico") = txt_cd_tecnico.Text.Trim()
        Else
            ViewState.Item("id_tecnico") = String.Empty
        End If
        ViewState.Item("nm_tecnico") = txt_nm_tecnico.Text.Trim()
        ViewState.Item("st_categoria") = cbo_categoria.SelectedValue
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_tecnico.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_tecnico.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 3
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


            cbo_categoria.Items.Add(New ListItem("[Selecione]", String.Empty))
            cbo_categoria.Items.Add(New ListItem("Danone", "D"))
            cbo_categoria.Items.Add(New ListItem("Educampo", "E"))
            cbo_categoria.Items.Add(New ListItem("Comquali", "Q"))   ' adri 19/12/2016 - Curva ABC

            ViewState.Item("sortExpression") = "nm_tecnico asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("tecnico", txt_cd_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_tecnico") = customPage.getFilterValue("tecnico", txt_cd_tecnico.ID)
            txt_cd_tecnico.Text = ViewState.Item("id_tecnico").ToString()
        Else
            ViewState.Item("id_tecnico") = String.Empty
        End If

        If Not (customPage.getFilterValue("tecnico", txt_nm_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_tecnico") = customPage.getFilterValue("tecnico", txt_nm_tecnico.ID)
            txt_nm_tecnico.Text = ViewState.Item("nm_tecnico").ToString()
        Else
            ViewState.Item("nm_tecnico") = String.Empty
        End If


        If Not (customPage.getFilterValue("tecnico", cbo_categoria.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("st_categoria") = customPage.getFilterValue("tecnico", cbo_categoria.ID)
            cbo_categoria.Text = ViewState.Item("st_categoria").ToString()
        Else
            ViewState.Item("st_categoria") = String.Empty
        End If


        If Not (customPage.getFilterValue("tecnico", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("tecnico", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("tecnico", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("tecnico", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("tecnico")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim tecnico As New Tecnico

            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                tecnico.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico"))
            End If
            tecnico.st_categoria = ViewState.Item("st_categoria").ToString()
            tecnico.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            tecnico.nm_tecnico = ViewState.Item("nm_tecnico").ToString()

            Dim dsTecnico As DataSet = tecnico.getTecnicoByFilters()

            If (dsTecnico.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsTecnico.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "id_tecnico"
                If (ViewState.Item("sortExpression")) = "id_tecnico asc" Then
                    ViewState.Item("sortExpression") = "id_tecnico desc"
                Else
                    ViewState.Item("sortExpression") = "id_tecnico asc"
                End If


            Case "nm_tecnico"
                If (ViewState.Item("sortExpression")) = "nm_tecnico asc" Then
                    ViewState.Item("sortExpression") = "nm_tecnico desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tecnico asc"
                End If


            Case "st_categoria"
                If (ViewState.Item("sortExpression")) = "st_categoria asc" Then
                    ViewState.Item("sortExpression") = "st_categoria desc"
                Else
                    ViewState.Item("sortExpression") = "st_categoria asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("tecnico", txt_cd_tecnico.ID, ViewState.Item("id_tecnico").ToString)
            customPage.setFilter("tecnico", txt_nm_tecnico.ID, ViewState.Item("nm_tecnico").ToString)
            customPage.setFilter("tecnico", cbo_categoria.ID, ViewState.Item("st_categoria").ToString)
            customPage.setFilter("tecnico", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("tecnico", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_tecnico.aspx?id_tecnico=" + e.CommandArgument.ToString())

            Case "delete"
                deleteTecnico(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteTecnico(ByVal id_tecnico As Integer)

        Try

            Dim tecnico As New Tecnico()
            tecnico.id_tecnico = id_tecnico
            tecnico.id_modificador = Convert.ToInt32(Session("id_login"))
            tecnico.deleteTecnico()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 3
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
        Response.Redirect("frm_tecnico.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            If (e.Row.Cells(2).Text.Trim().Equals("D")) Then
                e.Row.Cells(2).Text = "Danone"
            Else
                If (e.Row.Cells(2).Text.Trim().Equals("E")) Then
                    e.Row.Cells(2).Text = "Educampo"
                Else
                    e.Row.Cells(2).Text = "Comquali"  ' adri 19/12/2016 - curva ABC
                End If
            End If

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub
End Class
