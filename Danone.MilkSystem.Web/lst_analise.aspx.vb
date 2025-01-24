Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_analise
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        If Not (txt_cd_analise.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_analise") = txt_cd_analise.Text.Trim()
        Else
            ViewState.Item("cd_analise") = String.Empty
        End If
        ViewState.Item("nm_analise") = txt_nm_analise.Text.Trim()
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_analise.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_analise.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 12
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ViewState.Item("sortExpression") = "cd_analise asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("analise", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("analise", cbo_estabelecimento.ID)
            cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise", txt_cd_analise.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_analise") = customPage.getFilterValue("analise", txt_cd_analise.ID)
            txt_cd_analise.Text = ViewState.Item("cd_analise").ToString()
        Else
            ViewState.Item("id_analise") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise", txt_nm_analise.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_analise") = customPage.getFilterValue("analise", txt_nm_analise.ID)
            txt_nm_analise.Text = ViewState.Item("nm_analise").ToString()
        Else
            ViewState.Item("nm_analise") = String.Empty
        End If


        If Not (customPage.getFilterValue("analise", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("analise", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("analise", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("analise", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("analise")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim analise As New Analise

            analise.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

            If Not (ViewState("id_analise").ToString().Equals(String.Empty)) Then
                analise.cd_analise = Convert.ToInt32(ViewState.Item("cd_analise"))
            End If
            analise.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            analise.nm_analise = ViewState.Item("nm_analise").ToString()

            Dim dsAnalise As DataSet = analise.getAnaliseByFilters()

            If (dsAnalise.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsAnalise.Tables(0), ViewState.Item("sortExpression"))
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


            Case "cd_analise"
                If ViewState.Item("sortExpression") = "cd_analise asc" Then
                    ViewState.Item("sortExpression") = "cd_analise desc"
                Else
                    ViewState.Item("sortExpression") = "cd_analise asc"
                End If


            Case "nm_analise"
                If ViewState.Item("sortExpression") = "nm_analise asc" Then
                    ViewState.Item("sortExpression") = "nm_analise desc"
                Else
                    ViewState.Item("sortExpression") = "nm_analise asc"
                End If
            Case "nm_sigla"
                If ViewState.Item("sortExpression") = "nm_sigla asc" Then
                    ViewState.Item("sortExpression") = "nm_sigla desc"
                Else
                    ViewState.Item("sortExpression") = "nm_sigla asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("analise", cbo_estabelecimento.ID, cbo_estabelecimento.SelectedValue)
            customPage.setFilter("analise", txt_cd_analise.ID, txt_cd_analise.Text)
            customPage.setFilter("analise", txt_nm_analise.ID, txt_nm_analise.Text)
            customPage.setFilter("analise", cbo_situacao.ID, cbo_situacao.SelectedValue)
            customPage.setFilter("analise", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_analise.aspx?id_analise=" + e.CommandArgument.ToString())

            Case "delete"
                deleteAnalise(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteAnalise(ByVal id_analise As Integer)

        Try

            Dim analise As New Analise()
            analise.id_analise = id_analise
            analise.id_modificador = Convert.ToInt32(Session("id_login"))
            analise.deleteAnalise()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 12
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
        Response.Redirect("frm_analise.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
End Class
