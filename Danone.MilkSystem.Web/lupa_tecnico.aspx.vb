Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lupa_tecnico
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Not (txt_cd_tecnico.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_tecnico") = txt_cd_tecnico.Text.Trim()
        Else
            ViewState.Item("id_tecnico") = "0"
        End If
        ViewState.Item("nm_tecnico") = txt_nm_tecnico.Text.Trim()
        ViewState.Item("st_categoria") = cbo_categoria.SelectedValue


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        If Not ViewState.Item("categoria") Is Nothing Then
            Response.Redirect("lupa_tecnico.aspx?categoria=" + ViewState.Item("categoria").ToString)
        Else
            Response.Redirect("lupa_tecnico.aspx")
        End If
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

            Dim status As New Situacao


            cbo_categoria.Items.Add(New ListItem("[Selecione]", String.Empty))
            cbo_categoria.Items.Add(New ListItem("Danone", "D"))
            cbo_categoria.Items.Add(New ListItem("Educampo", "E"))
            cbo_categoria.Items.Add(New ListItem("Comquali", "Q"))  '07/12/2016 - Mirella 

            ViewState.Item("sortExpression") = "nm_tecnico asc"

            'se passou parametro de cateoria
            If Not (Request("categoria") Is Nothing) Then
                ViewState.Item("categoria") = Request("categoria")
                cbo_categoria.SelectedValue = Request("categoria")
                cbo_categoria.Enabled = False
            End If

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("tecnico", txt_cd_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_tecnico") = customPage.getFilterValue("tecnico", txt_cd_tecnico.ID)
            txt_cd_tecnico.Text = ViewState.Item("id_tecnico").ToString()
        Else
            ViewState.Item("id_tecnico") = "0"
        End If

        If Not (customPage.getFilterValue("tecnico", txt_nm_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_tecnico") = customPage.getFilterValue("tecnico", txt_nm_tecnico.ID)
            txt_nm_tecnico.Text = ViewState.Item("nm_tecnico").ToString()
        Else
            ViewState.Item("nm_tecnico") = String.Empty
        End If


        If Not (customPage.getFilterValue("tecnico", cbo_categoria.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("st_categoria") = customPage.getFilterValue("tecnico", cbo_categoria.ID)
            cbo_categoria.Text = ViewState.Item("st_categoria").ToString()
        Else
            ViewState.Item("st_categoria") = String.Empty
        End If


        If Not (customPage.getFilterValue("tecnico", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("tecnico", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("tecnico")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim tecnico As New Tecnico

            tecnico.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico"))
            tecnico.nm_tecnico = ViewState.Item("nm_tecnico").ToString   ' Adri 06/05/2010 - Chamado 827  - i
            tecnico.st_categoria = ViewState.Item("st_categoria").ToString()
            tecnico.id_situacao = Convert.ToInt32("1")

            Dim dsTecnico As DataSet = tecnico.getTecnicoByFilters()

            If (dsTecnico.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsTecnico.Tables(0), ViewState.Item("sortExpression"))
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


            Case "id_tecnico"
                If ViewState.Item("sortExpression") = "id_tecnico asc" Then
                    ViewState.Item("sortExpression") = "id_tecnico desc"
                Else
                    ViewState.Item("sortExpression") = "id_tecnico asc"
                End If


            Case "nm_tecnico"
                If ViewState.Item("sortExpression") = "nm_tecnico asc" Then
                    ViewState.Item("sortExpression") = "nm_tecnico desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tecnico asc"
                End If


            Case "st_categoria"
                If ViewState.Item("sortExpression") = "st_categoria asc" Then
                    ViewState.Item("sortExpression") = "st_categoria desc"
                Else
                    ViewState.Item("sortExpression") = "st_categoria asc"
                End If


        End Select

        loadData()

    End Sub


    Private Sub salvarLinhaSelecionada(ByVal pid_tecnico As String)

        Try

            Dim tecnico As New Tecnico(Convert.ToInt32(pid_tecnico))

            'customPage.setFilter("lupa_tecnico", "cd_pessoa", produtor.cd_pessoa)

            customPage.setFilter("lupa_tecnico", "nm_tecnico", tecnico.nm_tecnico)

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
                Dim lidtecnico As String = e.CommandArgument.ToString
                Dim js As New System.Text.StringBuilder
                js.Append("<script>")
                js.Append("window.onload=FechaPagina();")
                js.Append("</script>")

                If (Not Page.ClientScript.IsClientScriptBlockRegistered("Wclose")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Wclose", js.ToString)
                End If

                Page.ClientScript.RegisterHiddenField("txtDataHidden", lidtecnico)

                salvarLinhaSelecionada(lidtecnico)


        End Select

    End Sub




    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            If (e.Row.Cells(2).Text.Trim().Equals("D")) Then
                e.Row.Cells(2).Text = "Danone"
            Else
                If (e.Row.Cells(2).Text.Trim().Equals("E")) Then
                    e.Row.Cells(2).Text = "Educampo"
                Else
                    e.Row.Cells(2).Text = "Comquali"  ' adri 19/12/2016 - Curva ABC
                End If
            End If

        End If
    End Sub

End Class
