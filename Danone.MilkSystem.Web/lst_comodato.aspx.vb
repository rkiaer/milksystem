Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_comodato
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_comodato") = txt_cd_comodato.Text
        ViewState.Item("nm_comodato") = txt_nm_comodato.Text
        ViewState.Item("id_proprietario") = cbo_id_proprietario.SelectedValue
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_comodato.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_comodato.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 13
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            'Dim tipobem As New TipoBem


            'cbo_id_proprietario.DataSource = tipobem.getTipoBensByFilters()
            'cbo_id_proprietario.DataTextField = "nm_tipobem"
            'cbo_id_proprietario.DataValueField = "id_tipobem"
            'cbo_id_proprietario.DataBind()
            'cbo_id_proprietario.Items.Insert(0, New ListItem("[Selecione]", "0"))
            Dim proprietario As New ProprietarioEquipamento


            cbo_id_proprietario.DataSource = proprietario.getProprietariosByFilters()
            cbo_id_proprietario.DataTextField = "nm_proprietario"
            cbo_id_proprietario.DataValueField = "id_proprietario"
            cbo_id_proprietario.DataBind()
            cbo_id_proprietario.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim status As New Situacao


            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ViewState.Item("sortExpression") = "id_comodato asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("comodato", txt_cd_comodato.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_comodato") = customPage.getFilterValue("comodato", txt_cd_comodato.ID)
            txt_cd_comodato.Text = ViewState.Item("id_comodato").ToString()
        Else
            ViewState.Item("id_comodato") = String.Empty
        End If

        If Not (customPage.getFilterValue("comodato", txt_nm_comodato.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_comodato") = customPage.getFilterValue("comodato", txt_nm_comodato.ID)
            txt_nm_comodato.Text = ViewState.Item("nm_comodato").ToString()
        Else
            ViewState.Item("nm_comodato") = String.Empty
        End If


        If Not (customPage.getFilterValue("comodato", cbo_id_proprietario.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_proprietario") = customPage.getFilterValue("comodato", cbo_id_proprietario.ID)
            cbo_id_proprietario.Text = ViewState.Item("id_proprietario").ToString()
        Else
            ViewState.Item("id_proprietario") = String.Empty
        End If


        If Not (customPage.getFilterValue("comodato", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("comodato", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("comodato", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("comodato", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("comodato")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim comodato As New Comodato

            If Not (ViewState.Item("id_comodato").Equals(String.Empty)) Then
                comodato.id_comodato = Convert.ToInt32(ViewState.Item("id_comodato"))
            End If
            comodato.nm_comodato = ViewState.Item("nm_comodato").ToString()
            If Not (ViewState.Item("id_proprietario").Equals(String.Empty)) Then
                comodato.id_proprietario = Convert.ToInt32(ViewState.Item("id_proprietario").ToString())
            End If
            comodato.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

            Dim dsComodato As DataSet = comodato.getComodatoByFilters()

            If (dsComodato.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsComodato.Tables(0), ViewState.Item("sortExpression"))
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


            Case "id_comodato"
                If (ViewState.Item("sortExpression")) = "id_comodato asc" Then
                    ViewState.Item("sortExpression") = "id_comodato desc"
                Else
                    ViewState.Item("sortExpression") = "id_comodato asc"
                End If


            Case "nm_comodato"
                If (ViewState.Item("sortExpression")) = "nm_comodato asc" Then
                    ViewState.Item("sortExpression") = "nm_comodato desc"
                Else
                    ViewState.Item("sortExpression") = "nm_comodato asc"
                End If

            Case "nm_proprietario"
                If (ViewState.Item("sortExpression")) = "nm_proprietario asc" Then
                    ViewState.Item("sortExpression") = "nm_proprietario desc"
                Else
                    ViewState.Item("sortExpression") = "nm_proprietario asc"
                End If

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("comodato", txt_cd_comodato.ID, ViewState.Item("id_comodato").ToString())
            customPage.setFilter("comodato", txt_nm_comodato.ID, ViewState.Item("nm_comodato").ToString())
            customPage.setFilter("comodato", cbo_id_proprietario.ID, ViewState.Item("id_proprietario").ToString())
            customPage.setFilter("comodato", cbo_situacao.ID, ViewState.Item("id_situacao").ToString())
            customPage.setFilter("comodato", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_comodato.aspx?id_comodato=" + e.CommandArgument.ToString())

            Case "delete"
                deleteComodato(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteComodato(ByVal id_comodato As Integer)

        Try

            Dim comodato As New Comodato()
            comodato.id_comodato = id_comodato
            comodato.id_modificador = Convert.ToInt32(Session("id_login"))
            comodato.deleteComodato()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 13
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
        Response.Redirect("frm_comodato.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
End Class
