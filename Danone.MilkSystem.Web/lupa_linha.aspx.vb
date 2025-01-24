Imports Danone.MilkSystem.Business
Imports System.Data



Partial Class lupa_linha
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("lbl_estabelecimento") = lbl_estabelecimento.Text.Trim
        ViewState.Item("id_linha") = txt_id_linha.Text.Trim
        ViewState.Item("nm_linha") = txt_nm_linha.Text.Trim
        'ViewState.Item("st_categoria") = cbo_categoria.SelectedValue


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lupa_linha.aspx?id=" + ViewState.Item("id_estabelecimento"))

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
            If Not Request("id") Is Nothing Then
                'PEga o valor do estabelecimento que veio da lista de propriedade
                ViewState.Item("id_estabelecimento") = Request("id")

                loadDetails()

            End If
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento(Convert.ToInt32(ViewState.Item("id_estabelecimento")))

            Me.lbl_estabelecimento.Text = Convert.ToString(ViewState.Item("id_estabelecimento")) & " - " & Convert.ToString(estabelecimento.nm_estabelecimento)

            ViewState.Item("sortExpression") = "id_linha asc"


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim linha As New Linha

            linha.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            If Not ViewState.Item("id_linha").Equals(String.Empty) Then
                linha.id_linha = ViewState.Item("id_linha").ToString()
            End If

            'pessoa.st_categoria = ViewState.Item("st_categoria").ToString()
            linha.id_situacao = Convert.ToInt32("1") 'ativo
            If Not ViewState.Item("nm_linha").Equals(String.Empty) Then
                linha.nm_linha = ViewState.Item("nm_linha").ToString()
            End If

            Dim dslinha As DataSet = linha.getLinhaByFilters()

            If (dslinha.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dslinha.Tables(0), ViewState.Item("sortExpression"))
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


            Case "id_linha"
                If ViewState.Item("sortExpression") = "id_linha asc" Then
                    ViewState.Item("sortExpression") = "id_linha desc"
                Else
                    ViewState.Item("sortExpression") = "id_linha asc"
                End If

            Case "nm_linha"
                If ViewState.Item("sortExpression") = "nm_linha asc" Then
                    ViewState.Item("sortExpression") = "nm_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nm_linha asc"
                End If
            Case "ds_placa"
                If ViewState.Item("sortExpression") = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
                End If



        End Select

        loadData()

    End Sub

    Private Sub salvarLinhaSelecionada(ByVal pid_linha As String)

        Try

            Dim linha As New Linha(Convert.ToInt32(pid_linha))

            customPage.setFilter("lupa_linha", "id_linha", linha.id_linha)
            customPage.setFilter("lupa_linha", "nm_linha", linha.nm_linha)
            customPage.setFilter("lupa_linha", "ds_placa", linha.ds_placa)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()

            Case "selecionar"
                Dim lidlinha As String = e.CommandArgument.ToString
                Dim js As New System.Text.StringBuilder
                js.Append("<script>")
                js.Append("window.onload=FechaPagina();")
                js.Append("</script>")

                If (Not Page.ClientScript.IsClientScriptBlockRegistered("Wclose")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Wclose", js.ToString)
                End If

                Page.ClientScript.RegisterHiddenField("txtDataHidden", lidlinha)

                salvarLinhaSelecionada(lidlinha)
                'Dim produtor As New Pessoa(Convert.ToInt32(lidpessoa))
                'Page.ClientScript.RegisterHiddenField("txtDataHidden", TextBox1.Text.ToString)
                'Definindo valor para retornar! 

        End Select

    End Sub




End Class
