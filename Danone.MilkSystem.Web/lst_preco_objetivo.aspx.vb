Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_preco_objetivo

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            ViewState.Item("cd_tecnico") = txt_cd_tecnico.Text.Trim()
            ViewState.Item("nr_ano") = Me.txt_ano.Text.Trim
            ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

            loadData()
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_preco_objetivo.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_preco_objetivo.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 34
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With img_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Técnicos"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()

            ViewState.Item("sortExpression") = "nr_ano asc"

            loadFilters()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("preco_objetivo", txt_cd_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_tecnico") = customPage.getFilterValue("preco_objetivo", txt_cd_tecnico.ID)
            txt_cd_tecnico.Text = ViewState.Item("cd_tecnico").ToString()
        Else
            ViewState.Item("cd_tecnico") = String.Empty
        End If
        If Not (customPage.getFilterValue("preco_objetivo", hf_id_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("hf_id_tecnico") = customPage.getFilterValue("preco_objetivo", hf_id_tecnico.ID)
            hf_id_tecnico.Value = ViewState.Item("hf_id_tecnico").ToString()
        Else
            ViewState.Item("hf_id_tecnico") = String.Empty
        End If

        If Not (customPage.getFilterValue("preco_objetivo", lbl_nm_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_tecnico") = customPage.getFilterValue("preco_objetivo", lbl_nm_tecnico.ID)
            lbl_nm_tecnico.Text = ViewState.Item("nm_tecnico").ToString()
        Else
            ViewState.Item("nm_tecnico") = String.Empty
        End If

        If Not (customPage.getFilterValue("preco_objetivo", txt_ano.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_ano") = customPage.getFilterValue("preco_objetivo", txt_ano.ID)
            txt_ano.Text = ViewState.Item("nr_ano").ToString()
        Else
            ViewState.Item("nr_ano") = String.Empty
        End If


        If Not (customPage.getFilterValue("preco_objetivo", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("preco_objetivo", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("preco_objetivo", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("preco_objetivo", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("preco_objetivo")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim precoobjetivo As New PrecoObjetivo

            precoobjetivo.nr_ano = ViewState.Item("nr_ano").ToString()
            If Trim(ViewState.Item("cd_tecnico")) <> "" Then
                precoobjetivo.id_tecnico = Convert.ToInt32(ViewState.Item("cd_tecnico").ToString())
            End If
            If Trim(ViewState.Item("id_situacao")) <> "" Then
                precoobjetivo.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            End If

            Dim dsPrecoObjetivo As DataSet = precoobjetivo.getPrecoObjetivoByFilters()

            If (dsPrecoObjetivo.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPrecoObjetivo.Tables(0), ViewState.Item("sortExpression"))
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


            Case "nr_ano"
                If (ViewState.Item("sortExpression")) = "nr_ano asc" Then
                    ViewState.Item("sortExpression") = "nr_ano desc"
                Else
                    ViewState.Item("sortExpression") = "nr_ano asc"
                End If


            Case "ds_tecnico"
                If (ViewState.Item("sortExpression")) = "ds_tecnico asc" Then
                    ViewState.Item("sortExpression") = "ds_tecnico desc"
                Else
                    ViewState.Item("sortExpression") = "ds_tecnico asc"
                End If

        End Select

        loadData()

    End Sub
    Private Sub carregarCamposTecnico()

        Try

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If
            Me.txt_cd_tecnico.Text = hf_id_tecnico.Value.ToString
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("preco_objetivo", txt_cd_tecnico.ID, ViewState.Item("cd_tecnico").ToString)
            customPage.setFilter("preco_objetivo", hf_id_tecnico.ID, ViewState.Item("hf_id_tecnico").ToString)
            customPage.setFilter("preco_objetivo", lbl_nm_tecnico.ID, lbl_nm_tecnico.Text)
            customPage.setFilter("preco_objetivo", txt_ano.ID, ViewState.Item("nr_ano").ToString)
            customPage.setFilter("preco_objetivo", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("preco_objetivo", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_preco_objetivo.aspx?id_preco_objetivo=" + e.CommandArgument.ToString())
            Case "delete"
                deletePrecoObjetivo(e.CommandArgument.ToString())

        End Select

    End Sub

    Private Sub deletePrecoObjetivo(ByVal id_preco_objetivo As String)

        Try

            Dim precoobjetivo As New PrecoObjetivo()
            precoobjetivo.id_preco_objetivo = Convert.ToInt32(id_preco_objetivo)
            precoobjetivo.id_modificador = Convert.ToInt32(Session("id_login"))
            precoobjetivo.deletePrecoObjetivo()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 34
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
        Response.Redirect("frm_preco_objetivo.aspx")
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_tecnico.Click
        If Not (hf_id_tecnico.Value.Equals(String.Empty)) Then
            Me.lbl_nm_tecnico.Visible = True
            carregarCamposTecnico()
        End If
    End Sub

    Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
        lbl_nm_tecnico.Text = String.Empty
        lbl_nm_tecnico.Visible = False
        hf_id_tecnico.Value = String.Empty
    End Sub
    Protected Sub cv_tecnico_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_tecnico.ServerValidate
        Try
            Dim tecnico As New Tecnico()

            tecnico.id_tecnico = Trim(txt_cd_tecnico.Text)
            Dim dstecnico As DataSet = tecnico.getTecnicoByFilters()

            args.IsValid = dstecnico.Tables(0).Rows.Count > 0
            If Not args.IsValid Then
                messageControl.Alert("Técnico não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

End Class
