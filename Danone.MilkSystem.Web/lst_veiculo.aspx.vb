Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_veiculo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Not (txt_cd_veiculo.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_veiculo") = txt_cd_veiculo.Text.Trim()
        Else
            ViewState.Item("id_veiculo") = "0"
        End If
        ViewState.Item("ds_placa") = txt_placa.Text.Trim()
        ViewState.Item("ds_modelo") = txt_modelo.Text.Trim()
        ViewState.Item("nr_ano_fabricacao") = txt_ano_fabricacao.Text.Trim()
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_veiculo.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_veiculo.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 8
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


            ViewState.Item("sortExpression") = "ds_placa asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("veiculo", txt_cd_veiculo.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_veiculo") = customPage.getFilterValue("veiculo", txt_cd_veiculo.ID)
            txt_cd_veiculo.Text = ViewState.Item("id_veiculo").ToString()
        Else
            ViewState.Item("id_veiculo") = "0"
        End If

        If Not (customPage.getFilterValue("veiculo", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("veiculo", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If

        If Not (customPage.getFilterValue("veiculo", txt_modelo.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_modelo") = customPage.getFilterValue("veiculo", txt_modelo.ID)
            txt_modelo.Text = ViewState.Item("ds_modelo").ToString()
        Else
            ViewState.Item("ds_modelo") = String.Empty
        End If

        If Not (customPage.getFilterValue("veiculo", txt_ano_fabricacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_ano_fabricacao") = customPage.getFilterValue("veiculo", txt_ano_fabricacao.ID)
            txt_ano_fabricacao.Text = ViewState.Item("nr_ano_fabricacao").ToString()
        Else
            ViewState.Item("nr_ano_fabricacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("veiculo", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("veiculo", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("veiculo", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("veiculo", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("veiculo")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim veiculo As New Veiculo

            veiculo.id_veiculo = Convert.ToInt32(ViewState.Item("id_veiculo"))
            veiculo.ds_placa = ViewState.Item("ds_placa").ToString
            veiculo.ds_modelo = ViewState.Item("ds_modelo").ToString
            If ViewState.Item("nr_ano_fabricacao") <> "" Then
                veiculo.nr_ano_fabricacao = Convert.ToInt32(ViewState.Item("nr_ano_fabricacao"))
            End If
            veiculo.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

            Dim dsVeiculo As DataSet = veiculo.getVeiculoByFilters()

            If (dsVeiculo.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsVeiculo.Tables(0), ViewState.Item("sortExpression"))
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


            Case "id_veiculo"
                If (ViewState.Item("sortExpression")) = "id_veiculo asc" Then
                    ViewState.Item("sortExpression") = "id_veiculo desc"
                Else
                    ViewState.Item("sortExpression") = "id_veiculo asc"
                End If


            Case "ds_placa"
                If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
                End If


            Case "ds_modelo"
                If (ViewState.Item("sortExpression")) = "ds_modelo asc" Then
                    ViewState.Item("sortExpression") = "ds_modelo desc"
                Else
                    ViewState.Item("sortExpression") = "ds_modelo asc"
                End If

            Case "nr_ano_fabricacao"
                If (ViewState.Item("sortExpression")) = "nr_ano_fabricacao asc" Then
                    ViewState.Item("sortExpression") = "nr_ano_fabricacao desc"
                Else
                    ViewState.Item("sortExpression") = "nr_ano_fabricacao asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            'Se não informou o id_veiculo para pesquisar, assume que o retorno do campo será VAZIO
            If ViewState.Item("id_veiculo").ToString = "0" Then
                customPage.setFilter("veiculo", txt_cd_veiculo.ID, "")
            Else
                customPage.setFilter("veiculo", txt_cd_veiculo.ID, ViewState.Item("id_veiculo").ToString)
            End If
            customPage.setFilter("veiculo", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            customPage.setFilter("veiculo", txt_modelo.ID, ViewState.Item("ds_modelo").ToString)
            customPage.setFilter("veiculo", txt_ano_fabricacao.ID, ViewState.Item("nr_ano_fabricacao").ToString)
            customPage.setFilter("veiculo", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("veiculo", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_veiculo.aspx?id_veiculo=" + e.CommandArgument.ToString())

            Case "delete"
                deleteVeiculo(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteVeiculo(ByVal id_veiculo As Integer)

        Try

            Dim veiculo As New veiculo()
            veiculo.id_veiculo = id_veiculo
            veiculo.id_modificador = Convert.ToInt32(Session("id_login"))
            veiculo.deleteVeiculo()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 8
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
        Response.Redirect("frm_veiculo.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()
    End Sub
End Class
