Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_silo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        If Not (txt_cd_silo.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_silo") = txt_cd_silo.Text.Trim()
        Else
            ViewState.Item("id_silo") = String.Empty
        End If
        ViewState.Item("nm_silo") = txt_nm_silo.Text.Trim()
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_silo.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_silo.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 2
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

            ViewState.Item("sortExpression") = "nm_silo asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("silo", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("silo", cbo_estabelecimento.ID)
            cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("silo", txt_cd_silo.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_silo") = customPage.getFilterValue("silo", txt_cd_silo.ID)
            txt_cd_silo.Text = ViewState.Item("id_silo").ToString()
        Else
            ViewState.Item("id_silo") = String.Empty
        End If

        If Not (customPage.getFilterValue("silo", txt_nm_silo.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_silo") = customPage.getFilterValue("silo", txt_nm_silo.ID)
            txt_nm_silo.Text = ViewState.Item("nm_silo").ToString()
        Else
            ViewState.Item("nm_silo") = String.Empty
        End If



        If Not (customPage.getFilterValue("silo", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("silo", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("silo", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("silo", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("silo")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim silo As New Silo

            silo.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString()
            If Not (ViewState("id_silo").ToString().Equals(String.Empty)) Then
                silo.id_Silo = Convert.ToInt32(ViewState.Item("id_silo"))
            End If
            silo.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            silo.nm_silo = ViewState.Item("nm_silo").ToString()

            Dim dsSilo As DataSet = silo.getSiloByFilters()

            If (dsSilo.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsSilo.Tables(0), ViewState.Item("sortExpression"))
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


            Case "id_silo"
                If (ViewState.Item("sortExpression")) = "id_silo asc" Then
                    ViewState.Item("sortExpression") = "id_silo desc"
                Else
                    ViewState.Item("sortExpression") = "id_silo asc"
                End If


            Case "nm_silo"
                If (ViewState.Item("sortExpression")) = "nm_silo asc" Then
                    ViewState.Item("sortExpression") = "nm_silo desc"
                Else
                    ViewState.Item("sortExpression") = "nm_silo asc"
                End If

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("silo", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("silo", txt_cd_silo.ID, ViewState.Item("id_silo").ToString)
            customPage.setFilter("silo", txt_nm_silo.ID, ViewState.Item("nm_silo").ToString)
            customPage.setFilter("silo", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("silo", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_silo.aspx?id_silo=" + e.CommandArgument.ToString())

            Case "delete"
                deleteSilo(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteSilo(ByVal id_silo As Integer)

        Try

            Dim silo As New Silo()
            silo.id_silo = id_silo
            silo.id_modificador = Convert.ToInt32(Session("id_login"))
            silo.deleteSilo()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 2
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
        Response.Redirect("frm_silo.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
End Class
