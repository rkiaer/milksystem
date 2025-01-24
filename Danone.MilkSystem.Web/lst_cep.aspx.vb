Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_cep
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("cd_cep") = txt_cep.Text
        ViewState.Item("id_cidade") = cbo_cidade.SelectedValue
        ViewState.Item("id_estado") = cbo_estado.SelectedValue
        loadData()

    End Sub
    Protected Sub cbo_estado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estado.SelectedIndexChanged
        If Not (cbo_estado.SelectedValue.Trim().Equals(String.Empty)) Then
            loadCidadesByEstado(Convert.ToInt32(cbo_estado.SelectedValue))
            cbo_cidade.Enabled = True
        Else
            cbo_cidade.Items.Clear()
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_cidade.Enabled = False
        End If

    End Sub
    Private Sub loadCidadesByEstado(ByVal id_estado As Int32)

        Try

            cbo_cidade.Enabled = True

            Dim cidade As New Cidade
            cidade.id_estado = id_estado

            cbo_cidade.DataSource = cidade.getCidadeByFilters()
            cbo_cidade.DataTextField = "nm_cidade"
            cbo_cidade.DataValueField = "id_cidade"
            cbo_cidade.DataBind()
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", "0"))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_cep.aspx?st_incluirlog=N")

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_cep.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 218
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

    End Sub


    Private Sub loadDetails()

        Try


            Dim estado As New Estado

            cbo_estado.DataSource = estado.getEstadosByFilters()
            cbo_estado.DataTextField = "nm_estado"
            cbo_estado.DataValueField = "id_estado"
            cbo_estado.DataBind()
            cbo_estado.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))



            ViewState.Item("sortExpression") = ""

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("cep", cbo_estado.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estado") = customPage.getFilterValue("cep", cbo_estado.ID)
            Me.cbo_estado.Text = ViewState.Item("id_estado").ToString()
        Else
            ViewState.Item("id_estado") = String.Empty
        End If

        If Not (customPage.getFilterValue("cep", cbo_cidade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_cidade") = customPage.getFilterValue("cep", cbo_cidade.ID)
            Me.cbo_cidade.Text = ViewState.Item("id_cidade").ToString()
        Else
            ViewState.Item("id_cidade") = String.Empty
        End If

        If Not (customPage.getFilterValue("cep", txt_cep.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_cep") = customPage.getFilterValue("cep", txt_cep.ID)
            txt_cep.Text = ViewState.Item("cd_cep").ToString()
        Else
            ViewState.Item("cd_cep") = String.Empty
        End If

        If Not (customPage.getFilterValue("cep", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("cep", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("cep")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim dscep As DataSet

            Dim cep As New CEP
            If Not (ViewState.Item("id_estado").Equals(String.Empty)) Then
                cep.id_estado = ViewState.Item("id_estado")
            Else
                cep.id_estado = 0
            End If
            If Not (ViewState.Item("id_cidade").Equals(String.Empty)) Then
                cep.id_cidade = ViewState.Item("id_cidade")
            Else
                cep.id_cidade = 0
            End If
            cep.cd_cep = ViewState.Item("cd_cep").ToString
            cep.id_situacao = 1

            dscep = cep.getCEPByFilters()
            If (dscep.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscep.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

 
    Private Sub saveFilters()

        Try


            customPage.setFilter("cep", txt_cep.ID, ViewState.Item("cd_cep").ToString)
            customPage.setFilter("cep", cbo_cidade.ID, ViewState.Item("id_cidade").ToString)
            customPage.setFilter("cep", cbo_estado.ID, ViewState("id_estado").ToString())
            customPage.setFilter("cep", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

 


    Private Sub deleteCep(ByVal id_cep As Integer)

        Try

            Dim cep As New CEP
            cep.id_cep = id_cep
            cep.id_modificador = Convert.ToInt32(Session("id_login"))
            cep.deleteCEP()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 218
            usuariolog.ds_nm_processo = "CEP"
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro excluido com sucesso.")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

 
    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_cep.aspx?id_cep=" + e.CommandArgument.ToString())

            Case "delete"
                deleteCep(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select
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

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting
        Select Case e.SortExpression.ToLower()


            Case "ds_estado"
                If (ViewState.Item("sortExpression")) = "ds_estado asc" Then
                    ViewState.Item("sortExpression") = "ds_estado desc"
                Else
                    ViewState.Item("sortExpression") = "ds_estado asc"
                End If

            Case "nm_cidade"
                If (ViewState.Item("sortExpression")) = "nm_cidade asc" Then
                    ViewState.Item("sortExpression") = "nm_cidade desc"
                Else
                    ViewState.Item("sortExpression") = "nm_cidade asc"
                End If

            Case "cd_cep"
                If (ViewState.Item("sortExpression")) = "cd_cep asc" Then
                    ViewState.Item("sortExpression") = "cd_cep desc"
                Else
                    ViewState.Item("sortExpression") = "cd_cep asc"
                End If


        End Select

        loadData()

    End Sub


      Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        ViewState.Item("cd_cep") = txt_cep.Text
        ViewState.Item("id_cidade") = cbo_cidade.SelectedValue
        ViewState.Item("id_estado") = cbo_estado.SelectedValue

        saveFilters()
        Response.Redirect("frm_cep.aspx")

    End Sub
End Class
