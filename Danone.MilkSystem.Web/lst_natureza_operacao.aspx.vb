Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_natureza_operacao
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("cd_natureza_operacao") = Me.txt_cd_natureza_operacao.Text.Trim()
        ViewState.Item("nm_natureza_operacao") = Me.txt_nm_naturezao_operacao.Text.Trim
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_natureza_operacao.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_natureza_operacao.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 10
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


            ViewState.Item("sortExpression") = "cd_natureza_operacao asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("natoperacao", txt_cd_natureza_operacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_natureza_operacao") = customPage.getFilterValue("natoperacao", txt_cd_natureza_operacao.ID)
            txt_cd_natureza_operacao.Text = ViewState.Item("cd_natureza_operacao").ToString()
        Else
            ViewState.Item("cd_natureza_operacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("natoperacao", txt_nm_naturezao_operacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_natureza_operacao") = customPage.getFilterValue("natoperacao", txt_nm_naturezao_operacao.ID)
            txt_nm_naturezao_operacao.Text = ViewState.Item("nm_natureza_operacao").ToString()
        Else
            ViewState.Item("nm_natureza_operacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("natoperacao", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("natoperacao", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("natoperacao", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("natoperacao", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("natoperacao")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim naturezaoperacao As New NaturezaOperacao

            naturezaoperacao.nm_natureza_operacao = ViewState.Item("nm_natureza_operacao").ToString()
            naturezaoperacao.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            naturezaoperacao.cd_natureza_operacao = ViewState.Item("cd_natureza_operacao").ToString

            Dim dsnaturezaoperacao As DataSet = naturezaoperacao.getNaturezaOperacoesByFilters()

            If (dsnaturezaoperacao.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsnaturezaoperacao.Tables(0), ViewState.Item("sortExpression"))
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


            Case "cd_natureza_operacao"
                If (ViewState.Item("sortExpression")) = "cd_natureza_operacao asc" Then
                    ViewState.Item("sortExpression") = "cd_natureza_operacao desc"
                Else
                    ViewState.Item("sortExpression") = "cd_natureza_operacao asc"
                End If

            Case "nm_natureza_operacao"
                If (ViewState.Item("sortExpression")) = "nm_natureza_operacao asc" Then
                    ViewState.Item("sortExpression") = "nm_natureza_operacao desc"
                Else
                    ViewState.Item("sortExpression") = "nm_natureza_operacao asc"
                End If

            Case "nm_especie_nf"
                If (ViewState.Item("sortExpression")) = "nm_especie_nf asc" Then
                    ViewState.Item("sortExpression") = "nm_especie_nf desc"
                Else
                    ViewState.Item("sortExpression") = "nm_especie_nf asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try


            customPage.setFilter("natoperacao", txt_cd_natureza_operacao.ID, ViewState.Item("cd_natureza_operacao").ToString)
            customPage.setFilter("natoperacao", txt_nm_naturezao_operacao.ID, ViewState.Item("nm_natureza_operacao").ToString)
            customPage.setFilter("natoperacao", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("natoperacao", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_natureza_operacao.aspx?id_natureza_operacao=" + e.CommandArgument.ToString())


        End Select

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_natureza_operacao.aspx")
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


End Class
