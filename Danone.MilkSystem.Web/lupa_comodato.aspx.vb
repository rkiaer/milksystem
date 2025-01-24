Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lupa_comodato
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("cd_comodato") = txt_cd_comodato.Text.Trim()
        ViewState.Item("nm_comodato") = txt_nm_comodato.Text.Trim()
        ViewState.Item("id_proprietario") = cbo_id_proprietario.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lupa_comodato.aspx")

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

            Dim proprietario As New ProprietarioEquipamento


            cbo_id_proprietario.DataSource = proprietario.getProprietariosByFilters()
            cbo_id_proprietario.DataTextField = "nm_proprietario"
            cbo_id_proprietario.DataValueField = "id_proprietario"
            cbo_id_proprietario.DataBind()
            cbo_id_proprietario.Items.Insert(0, New ListItem("[Selecione]", ""))

            ViewState.Item("sortExpression") = "id_comodato asc"

            'loadFilters()
            'loadData()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean


    '    If Not (customPage.getFilterValue("comodato", txt_cd_comodato.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("cd_comodato") = customPage.getFilterValue("comodato", txt_cd_comodato.ID)
    '        txt_cd_comodato.Text = ViewState.Item("cd_comodato").ToString()
    '    Else
    '        ViewState.Item("cd_comodato") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("comodato", txt_nm_comodato.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("nm_comodato") = customPage.getFilterValue("comodato", txt_nm_comodato.ID)
    '        txt_nm_comodato.Text = ViewState.Item("nm_comodato").ToString()
    '    Else
    '        ViewState.Item("nm_comodato") = String.Empty
    '    End If


    '    If Not (customPage.getFilterValue("comodato", cbo_tipo_bem.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_tipobem") = customPage.getFilterValue("comodato", cbo_tipo_bem.ID)
    '        cbo_tipo_bem.Text = ViewState.Item("id_tipobem").ToString()
    '    Else
    '        ViewState.Item("id_tipobem") = String.Empty
    '    End If


    '    If Not (customPage.getFilterValue("comodato", cbo_situacao.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_situacao") = customPage.getFilterValue("comodato", cbo_situacao.ID)
    '        cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
    '    Else
    '        ViewState.Item("id_situacao") = String.Empty
    '    End If


    '    If Not (customPage.getFilterValue("comodato", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("comodato", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("comodato")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim comodato As New Comodato

            If Not (ViewState.Item("cd_comodato").Equals(String.Empty)) Then
                comodato.id_comodato = Convert.ToInt32(ViewState.Item("cd_comodato"))
            End If
            comodato.nm_comodato = ViewState.Item("nm_comodato").ToString()
            If Not (ViewState.Item("id_proprietario").Equals(String.Empty)) Then
                comodato.id_proprietario = Convert.ToInt32(ViewState.Item("id_proprietario").ToString())
            End If
            comodato.id_situacao = Convert.ToInt32("1")

            Dim dsLupaComodato As DataSet = comodato.getComodatoByFilters()

            If (dsLupaComodato.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsLupaComodato.Tables(0), ViewState.Item("sortExpression"))
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


            Case "cd_comodato"
                If (ViewState.Item("sortExpression")) = "cd_comodato asc" Then
                    ViewState.Item("sortExpression") = "cd_comodato desc"
                Else
                    ViewState.Item("sortExpression") = "cd_comodato asc"
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

    Private Sub salvarLinhaSelecionada(ByVal pid_comodato As String)

        Try

            Dim comodato As New Comodato(Convert.ToInt32(pid_comodato))

            customPage.setFilter("lupa_comodato", "id_comodato", comodato.id_comodato)
            customPage.setFilter("lupa_comodato", "nm_comodato", comodato.nm_comodato)
            customPage.setFilter("lupa_comodato", "nm_proprietario", comodato.nm_proprietario)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()

            Case "selecionar"
                Dim lidcomodato As String = e.CommandArgument.ToString
                Dim js As New System.Text.StringBuilder
                js.Append("<script>")
                js.Append("window.onload=FechaPagina();")
                js.Append("</script>")

                If (Not Page.ClientScript.IsClientScriptBlockRegistered("Wclose")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Wclose", js.ToString)
                End If

                Page.ClientScript.RegisterHiddenField("txtDataHidden", lidcomodato)

                salvarLinhaSelecionada(lidcomodato)

        End Select

    End Sub

End Class
