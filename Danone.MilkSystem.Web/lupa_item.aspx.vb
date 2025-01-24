Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lupa_item
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        'If Not (txt_cd_item.Text.Trim().Equals(String.Empty)) Then
        '    ViewState.Item("id_item") = txt_cd_item.Text.Trim()
        'Else
        '    ViewState.Item("id_item") = "0"
        'End If
        ViewState.Item("cd_item") = txt_cd_item.Text.Trim
        ViewState.Item("nm_item") = txt_nm_item.Text.Trim()
        ViewState.Item("id_unidade_medida") = cbo_unidade_medida.SelectedValue
        ViewState.Item("id_categoria_item") = cbo_categoria_item.SelectedValue


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        Response.Redirect("lupa_item.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim js As New System.Text.StringBuilder

        js.Append("<script>")
        js.Append(vbCrLf)
        js.Append("function FechaPagina()")
        js.Append(vbCrLf)
        js.Append("{")
        js.Append(vbCrLf)
        js.Append("window.returnValue=document.getElementById(""txtDataHidden"").value;")
        js.Append(vbCrLf)
        js.Append("window.close();")
        js.Append(vbCrLf)
        js.Append("}")
        js.Append(vbCrLf)
        js.Append("</script>")
        js.Append(vbCrLf)



        If (Not ClientScript.IsClientScriptBlockRegistered("fechar")) Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "fechar", js.ToString)

        End If
        customPage = MenuTools.getInitialContext(HttpContext.Current, "")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim unidademedida As New UnidadeMedida

            cbo_unidade_medida.DataSource = unidademedida.getunidade_medidaByfilters
            cbo_unidade_medida.DataTextField = "ds_unidade_medida"
            cbo_unidade_medida.DataValueField = "id_unidade_medida"
            cbo_unidade_medida.DataBind()
            cbo_unidade_medida.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim categoriaItem As New CategoriaItem

            cbo_categoria_item.DataSource = categoriaItem.getCategoriaItemByFilters
            cbo_categoria_item.DataTextField = "nm_categoria_item"
            cbo_categoria_item.DataValueField = "id_categoria_item"
            cbo_categoria_item.DataBind()
            cbo_categoria_item.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = "nm_item asc"


            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        'If Not (customPage.getFilterValue("lupa_item", txt_cd_item.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("id_item") = customPage.getFilterValue("lupa_item", txt_cd_item.ID)
        '    txt_cd_item.Text = ViewState.Item("id_item").ToString()
        'Else
        '    ViewState.Item("id_item") = "0"
        'End If

        If Not (customPage.getFilterValue("lupa_item", txt_cd_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_item") = customPage.getFilterValue("lupa_item", txt_cd_item.ID)
            txt_cd_item.Text = ViewState.Item("cd_item").ToString()
        Else
            ViewState.Item("cd_item") = "0"
        End If

        If Not (customPage.getFilterValue("lupa_item", txt_nm_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_item") = customPage.getFilterValue("lupa_item", txt_nm_item.ID)
            txt_nm_item.Text = ViewState.Item("nm_item").ToString()
        Else
            ViewState.Item("nm_item") = String.Empty
        End If


        If Not (customPage.getFilterValue("lupa_item", cbo_unidade_medida.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_unidade_medida") = customPage.getFilterValue("lupa_item", cbo_unidade_medida.ID)
            cbo_unidade_medida.Text = ViewState.Item("id_unidade_medida").ToString()
        Else
            ViewState.Item("id_unidade_medida") = "0"
        End If

        If Not (customPage.getFilterValue("lupa_item", cbo_categoria_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_categoria_item") = customPage.getFilterValue("lupa_item", cbo_categoria_item.ID)
            cbo_categoria_item.Text = ViewState.Item("id_categoria_item").ToString()
        Else
            ViewState.Item("id_categoria_item") = "0"
        End If

        If Not (customPage.getFilterValue("lupa_item", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("lupa_item", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("lupa_item")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim item As New Item

            'item.id_item = Convert.ToInt32(ViewState.Item("id_tecnico"))
            item.cd_item = ViewState.Item("cd_item").ToString
            item.nm_item = ViewState.Item("nm_item").ToString   ' Adri 06/05/2010 - Chamado 826  - i
            item.id_unidade_medida = ViewState.Item("id_unidade_medida").ToString()
            item.id_situacao = Convert.ToInt32("1")
            item.id_categoria_item = ViewState.Item("id_categoria_item").ToString()

            'Dim dsItem As DataSet = item.getItensByFilters()
            item.st_central_compras = "S"  ' Adri 18/11/2009 para trazer itens somente da Central
            Dim dsItem As DataSet = item.getItensCentralByFilters()  ' Adri 12/11/2009

            If (dsItem.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsItem.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            'Case "id_item"
            '    If ViewState.Item("sortExpression") = "id_item asc" Then
            '        ViewState.Item("sortExpression") = "id_item desc"
            '    Else
            '        ViewState.Item("sortExpression") = "id_item asc"
            '    End If
            Case "cd_unidade_medida"
                If ViewState.Item("sortExpression") = "cd_unidade_medida asc" Then
                    ViewState.Item("sortExpression") = "cd_unidade_medida desc"
                Else
                    ViewState.Item("sortExpression") = "cd_unidade_medida asc"
                End If

            Case "cd_item"
                If ViewState.Item("sortExpression") = "cd_item asc" Then
                    ViewState.Item("sortExpression") = "cd_item desc"
                Else
                    ViewState.Item("sortExpression") = "cd_item asc"
                End If


            Case "nm_item"
                If ViewState.Item("sortExpression") = "nm_item asc" Then
                    ViewState.Item("sortExpression") = "nm_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_item asc"
                End If

            Case "nm_categoria_item"
                If ViewState.Item("sortExpression") = "nm_categoria_item asc" Then
                    ViewState.Item("sortExpression") = "nm_categoria_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_categoria_item asc"
                End If



        End Select

        loadData()

    End Sub


    Private Sub salvarLinhaSelecionada(ByVal pid_item As String)

        Try

            Dim item As New Item(Convert.ToInt32(pid_item))

            customPage.setFilter("lupa_item", "id_item", item.id_item)

            customPage.setFilter("lupa_item", "cd_item", item.cd_item)

            customPage.setFilter("lupa_item", "nm_item", item.nm_item)

            customPage.setFilter("lupa_item", "cd_unidade_medida", item.cd_unidade_medida)
            customPage.setFilter("lupa_item", "id_categoria_item", item.id_categoria_item)
            customPage.setFilter("lupa_item", "nm_categoria_item", item.nm_categoria_item)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()

            Case "selecionar"
                Dim liditem As String = e.CommandArgument.ToString
                Dim js As New System.Text.StringBuilder
                js.Append("<script>")
                js.Append("window.onload=FechaPagina();")
                js.Append("</script>")

                If (Not Page.ClientScript.IsClientScriptBlockRegistered("Wclose")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Wclose", js.ToString)
                End If

                Page.ClientScript.RegisterHiddenField("txtDataHidden", liditem)

                salvarLinhaSelecionada(liditem)


        End Select

    End Sub




    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then


        End If
    End Sub

End Class
