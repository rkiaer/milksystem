Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_conta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ' 14/05/2008
        'If Not (txt_cd_conta.Text.Trim().Equals(String.Empty)) Then
        'ViewState.Item("id_conta") = txt_cd_conta.Text.Trim()
        'Else
        'ViewState.Item("id_conta") = "0"
        'End If
        ViewState.Item("cd_conta") = txt_cd_conta.Text.Trim()
        ViewState.Item("nm_conta") = txt_nm_conta.Text.Trim()
        ViewState.Item("id_natureza") = cbo_natureza_conta.SelectedValue
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_conta.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_conta.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 28
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim natureza As New NaturezaConta

            cbo_natureza_conta.DataSource = natureza.getNaturezaContasByFilters()
            cbo_natureza_conta.DataTextField = "nm_natureza"
            cbo_natureza_conta.DataValueField = "id_natureza"
            cbo_natureza_conta.DataBind()
            cbo_natureza_conta.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim status As New Situacao

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = "cd_conta asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        ' 14/05/2008
        'If Not (customPage.getFilterValue("conta", txt_cd_conta.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("id_conta") = customPage.getFilterValue("conta", txt_cd_conta.ID)
        '    txt_cd_conta.Text = ViewState.Item("id_conta").ToString()
        'Else
        '    ViewState.Item("id_conta") = "0"
        'End If

        If Not (customPage.getFilterValue("conta", txt_cd_conta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_conta") = customPage.getFilterValue("conta", txt_cd_conta.ID)
            txt_cd_conta.Text = ViewState.Item("cd_conta").ToString()
        Else
            ViewState.Item("cd_conta") = String.Empty
        End If

        If Not (customPage.getFilterValue("conta", txt_nm_conta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_conta") = customPage.getFilterValue("conta", txt_nm_conta.ID)
            txt_nm_conta.Text = ViewState.Item("nm_conta").ToString()
        Else
            ViewState.Item("nm_conta") = String.Empty
        End If

        If Not (customPage.getFilterValue("conta", cbo_natureza_conta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_natureza") = customPage.getFilterValue("conta", cbo_natureza_conta.ID)
            cbo_natureza_conta.Text = ViewState.Item("id_natureza").ToString()
        Else
            ViewState.Item("id_natureza") = String.Empty
        End If


        If Not (customPage.getFilterValue("conta", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("conta", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("conta", "PageIndex").Equals(String.Empty)) Then
            'hasFilters = True
            ViewState.Item("PageIndex") = customPage.getFilterValue("conta", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("conta")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim conta As New Conta

            ' 14/05/2008
            'conta.id_conta = Convert.ToInt32(ViewState.Item("id_conta"))
            conta.cd_conta = ViewState.Item("cd_conta").ToString
            conta.nm_conta = ViewState.Item("nm_conta").ToString
            conta.id_natureza = ViewState.Item("id_natureza").ToString()
            conta.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

            Dim dsconta As DataSet = conta.getContaByFilters()

            If (dsconta.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsconta.Tables(0), ViewState.Item("sortExpression"))
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


    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()



            Case "cd_conta"
                If (ViewState.Item("sortExpression")) = "cd_conta asc" Then
                    ViewState.Item("sortExpression") = "cd_conta desc"
                Else
                    ViewState.Item("sortExpression") = "cd_conta asc"
                End If


            Case "nm_conta"
                If (ViewState.Item("sortExpression")) = "nm_conta asc" Then
                    ViewState.Item("sortExpression") = "nm_conta desc"
                Else
                    ViewState.Item("sortExpression") = "nm_conta asc"
                End If

            Case "nm_natureza"
                If (ViewState.Item("sortExpression")) = "nm_natureza asc" Then
                    ViewState.Item("sortExpression") = "nm_natureza desc"
                Else
                    ViewState.Item("sortExpression") = "nm_natureza asc"
                End If

            Case "st_qtd_valor"
                If (ViewState.Item("sortExpression")) = "st_qtd_valor asc" Then
                    ViewState.Item("sortExpression") = "st_qtd_valor desc"
                Else
                    ViewState.Item("sortExpression") = "st_qtd_valor asc"
                End If

                ' 20/05/2009 - Rls 17.5 - Chamado 244 - i
            Case "nr_ordem"
                If (ViewState.Item("sortExpression")) = "nr_ordem asc" Then
                    ViewState.Item("sortExpression") = "nr_ordem desc"
                Else
                    ViewState.Item("sortExpression") = "nr_ordem asc"
                End If
                ' 20/05/2009 - Rls 17.5 - Chamado 244 - f


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            ' 14/05/2008 Se não informou o id_conta para pesquisar, assume que o retorno do campo será VAZIO
            'If ViewState.Item("id_conta").ToString = "0" Then
            'customPage.setFilter("conta", txt_cd_conta.ID, "")
            'Else
            'customPage.setFilter("conta", txt_cd_conta.ID, ViewState.Item("id_conta").ToString)
            'End If
            customPage.setFilter("conta", txt_cd_conta.ID, ViewState.Item("cd_conta").ToString)
            customPage.setFilter("conta", txt_nm_conta.ID, ViewState.Item("nm_conta").ToString)
            customPage.setFilter("conta", cbo_natureza_conta.ID, ViewState.Item("id_natureza").ToString)
            customPage.setFilter("conta", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("conta", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_conta.aspx?id_conta=" + e.CommandArgument.ToString())

            Case "delete"
                deleteConta(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteConta(ByVal id_conta As Integer)

        Try

            Dim conta As New Conta()
            conta.id_conta = id_conta
            conta.id_modificador = Convert.ToInt32(Session("id_login"))
            conta.deleteConta()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 28
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
        Response.Redirect("frm_conta.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
           And e.Row.RowType <> DataControlRowType.Footer _
           And e.Row.RowType <> DataControlRowType.Pager) Then

            If (e.Row.Cells(3).Text.Trim().Equals("Q")) Then
                e.Row.Cells(3).Text = "Quantidade"
            Else
                e.Row.Cells(3).Text = "Valor"
            End If

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
End Class
