Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_estabelecimento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("cd_estabelecimento") = txt_cd_estabelecimento.Text.Trim()
        ViewState.Item("nm_estabelecimento") = txt_nm_estabelecimento.Text.Trim()
        ViewState.Item("st_categoria") = cbo_categoria.SelectedValue
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_estabelecimento.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_estabelecimento.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 1
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
            cbo_categoria.Items.Add(New ListItem("Matriz", "M"))
            cbo_categoria.Items.Add(New ListItem("Filial", "F"))

            ViewState.Item("sortExpression") = "nm_estabelecimento asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("estabelecimento", txt_cd_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_estabelecimento") = customPage.getFilterValue("estabelecimento", txt_cd_estabelecimento.ID)
            txt_cd_estabelecimento.Text = ViewState.Item("cd_estabelecimento").ToString()
        Else
            ViewState.Item("cd_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("estabelecimento", txt_nm_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_estabelecimento") = customPage.getFilterValue("estabelecimento", txt_nm_estabelecimento.ID)
            txt_nm_estabelecimento.Text = ViewState.Item("nm_estabelecimento").ToString()
        Else
            ViewState.Item("nm_estabelecimento") = String.Empty
        End If


        If Not (customPage.getFilterValue("estabelecimento", cbo_categoria.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("st_categoria") = customPage.getFilterValue("estabelecimento", cbo_categoria.ID)
            cbo_categoria.Text = ViewState.Item("st_categoria").ToString()
        Else
            ViewState.Item("st_categoria") = String.Empty
        End If


        If Not (customPage.getFilterValue("estabelecimento", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("estabelecimento", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("estabelecimento", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("estabelecimento", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("estabelecimento")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim estabelecimento As New Estabelecimento

            estabelecimento.cd_estabelecimento = ViewState.Item("cd_estabelecimento").ToString()
            estabelecimento.nm_estabelecimento = ViewState.Item("nm_estabelecimento").ToString()
            estabelecimento.st_categoria = ViewState.Item("st_categoria").ToString()
            estabelecimento.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

            Dim dsEstabelecimento As DataSet = estabelecimento.getEstabelecimentoByFilters()

            If (dsEstabelecimento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsEstabelecimento.Tables(0), ViewState.Item("sortExpression"))
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


            Case "cd_estabelecimento"
                If (ViewState.Item("sortExpression")) = "cd_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "cd_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "cd_estabelecimento asc"
                End If


            Case "nm_estabelecimento"
                If (ViewState.Item("sortExpression")) = "nm_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "nm_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_estabelecimento asc"
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

            customPage.setFilter("estabelecimento", txt_cd_estabelecimento.ID, ViewState.Item("cd_estabelecimento").ToString)
            customPage.setFilter("estabelecimento", txt_nm_estabelecimento.ID, ViewState.Item("nm_estabelecimento").ToString)
            customPage.setFilter("estabelecimento", cbo_categoria.ID, ViewState.Item("st_categoria").ToString)
            customPage.setFilter("estabelecimento", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("estabelecimento", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_estabelecimento.aspx?id_estabelecimento=" + e.CommandArgument.ToString())


            Case "delete"
                deleteEstabelecimento(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteEstabelecimento(ByVal id_estabelecimento As Integer)

        Try

            Dim estabelecimento As New Estabelecimento()
            estabelecimento.id_estabelecimento = id_estabelecimento
            estabelecimento.id_modificador = Convert.ToInt32(Session("id_login"))
            estabelecimento.deleteEstabelecimento()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 1
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
        Response.Redirect("frm_estabelecimento.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            If (e.Row.Cells(2).Text.Trim().Equals("M")) Then
                e.Row.Cells(2).Text = "Matriz"
            Else
                e.Row.Cells(2).Text = "Filial"
            End If

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub txt_cd_estabelecimento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_estabelecimento.TextChanged

    End Sub
End Class
