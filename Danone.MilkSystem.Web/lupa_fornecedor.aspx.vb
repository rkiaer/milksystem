Imports Danone.MilkSystem.Business
Imports System.Data



Partial Class lupa_fornecedor
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim
        ViewState.Item("nm_pessoa") = txt_nm_pessoa.Text.Trim

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        If ViewState.Item("param_id_estabelecimento") = "0" Then
            Response.Redirect("lupa_fornecedor.aspx")
        Else
            Response.Redirect("lupa_fornecedor.aspx?id=" + ViewState.Item("param_id_estabelecimento").ToString)
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
            If Not (Request("id") Is Nothing) Then
                'PEga o valor do estabelecimento que veio da lista de propriedade
                ViewState.Item("param_id_estabelecimento") = Request("id")
            Else
                ViewState.Item("param_id_estabelecimento") = "0"
            End If

            loadDetails()

        End If

        'If Not Page.IsPostBack Then

        '    'PEga o valor do estabelecimento que veio da lista de propriedade
        '    ViewState.Item("id_estabelecimento") = Request("id")

        '    loadDetails()

        'End If
    End Sub


    Private Sub loadDetails()

        Try
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()

            If ViewState.Item("param_id_estabelecimento").ToString <> "0" Then
                cbo_estabelecimento.Items.FindByValue(ViewState.Item("param_id_estabelecimento").ToString).Selected = True
                'cbo_estabelecimento.Enabled = False
            Else
                cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
                'cbo_estabelecimento.Enabled = True
            End If

            'Dim estabelecimento As New Estabelecimento(Convert.ToInt32(ViewState.Item("id_estabelecimento")))

            'Me.lbl_estabelecimento.Text = Convert.ToString(ViewState.Item("id_estabelecimento")) & " - " & Convert.ToString(estabelecimento.nm_estabelecimento)

            ViewState.Item("sortExpression") = "nm_pessoa asc"

            'loadFilters()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim fornecedor As New Pessoa

            fornecedor.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString()
            fornecedor.cd_pessoa = ViewState.Item("cd_pessoa").ToString()
            fornecedor.id_situacao = Convert.ToInt32("1") 'ativo
            fornecedor.nm_pessoa = ViewState.Item("nm_pessoa").ToString()

            Dim dsFornecedor As DataSet = fornecedor.getFornecedorByFilters()

            If (dsFornecedor.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsFornecedor.Tables(0), ViewState.Item("sortExpression"))
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


    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "cd_pessoa"
                If ViewState.Item("sortExpression") = "cd_pessoa asc" Then
                    ViewState.Item("sortExpression") = "cd_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "cd_pessoa asc"
                End If

            Case "nm_pessoa"
                If ViewState.Item("sortExpression") = "nm_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_pessoa asc"
                End If


                'Case "st_categoria"
                '    If ViewState.Item("sortExpression") = "st_categoria asc" Then
                '        ViewState.Item("sortExpression") = "st_categoria desc"
                '    Else
                '        ViewState.Item("sortExpression") = "st_categoria asc"
                '    End If
                'Case "nm_grupo"
                '    If ViewState.Item("sortExpression") = "nm_grupo asc" Then
                '        ViewState.Item("sortExpression") = "nm_grupo desc"
                '    Else
                '        ViewState.Item("sortExpression") = "nm_grupo asc"
                '    End If


        End Select

        loadData()

    End Sub

    Private Sub salvarLinhaSelecionada(ByVal pid_fornecedor As String)

        Try

            Dim fornecedor As New Pessoa(Convert.ToInt32(pid_fornecedor))

            customPage.setFilter("lupa_fornecedor", "cd_pessoa", fornecedor.cd_pessoa)

            customPage.setFilter("lupa_fornecedor", "nm_pessoa", fornecedor.nm_pessoa)

            customPage.setFilter("lupa_fornecedor", "ds_telefone_1", fornecedor.ds_telefone_1)

            customPage.setFilter("lupa_fornecedor", "ds_telefone_3", fornecedor.ds_telefone_3)

            customPage.setFilter("lupa_fornecedor", "ds_email", fornecedor.ds_email)

            customPage.setFilter("lupa_fornecedor", "ds_contato", fornecedor.ds_contato)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()

            Case "selecionar"
                Dim lidpessoa As String = e.CommandArgument.ToString
                Dim js As New System.Text.StringBuilder
                js.Append("<script>")
                js.Append("window.onload=FechaPagina();")
                js.Append("</script>")

                If (Not Page.ClientScript.IsClientScriptBlockRegistered("Wclose")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Wclose", js.ToString)
                End If

                Page.ClientScript.RegisterHiddenField("txtDataHidden", lidpessoa)

                salvarLinhaSelecionada(lidpessoa)

        End Select

    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

        End If
    End Sub


End Class
