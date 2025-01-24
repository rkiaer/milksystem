Imports Danone.MilkSystem.Business
Imports System.Data



Partial Class lupa_propriedade
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        'Se for leitura já tem na viewstate o idestabelecimento
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim
        ViewState.Item("id_pessoa") = hf_id_pessoa.Value
        ViewState.Item("nm_propriedade") = txt_nm_propriedade.Text.Trim
        ViewState.Item("id_propriedade") = txt_id_propriedade.Text.Trim
        'ViewState.Item("st_categoria") = cbo_categoria.SelectedValue


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        'fran 20/03/2012
        'Response.Redirect("lupa_propriedade.aspx?id_propriedade='6'")
        Response.Redirect("lupa_propriedade.aspx?id_estabelecimento=" + ViewState.Item("param_id_estabelecimento") + "&cd_pessoa=" + ViewState.Item("param_cd_pessoa"))

        'Response.Redirect("suapagina.asp?id=" & suavariavel & "&id2=" & suavariavel2)


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
            If Not (Request("id_estabelecimento") Is Nothing) Then
                'PEga o valor do estabelecimento que veio da lista de propriedade
                ViewState.Item("param_id_estabelecimento") = Request("id_estabelecimento")
            Else
                ViewState.Item("param_id_estabelecimento") = "0"
            End If
            If Not (Request("cd_pessoa") Is Nothing) Then
                ViewState.Item("param_cd_pessoa") = Request("cd_pessoa")
            Else
                ViewState.Item("param_cd_pessoa") = String.Empty
            End If
            'fran 18/07/2016 i 
            If Not (Request("transf") Is Nothing) Then
                ViewState.Item("param_transf") = Request("transf")
            Else
                ViewState.Item("param_transf") = String.Empty
            End If
            'fran 18/07/2016 f

            loadDetails()
        End If
        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogDadosProdutor()")
            .ToolTip = "Filtrar Produtores"
        End With

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
                cbo_estabelecimento.Enabled = False
            Else
                cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
                cbo_estabelecimento.Enabled = True
            End If

            Me.txt_cd_pessoa.Text = ViewState.Item("param_cd_pessoa").ToString

            ViewState.Item("sortExpression") = "nm_pessoa asc"

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim propriedade As New Propriedade

            propriedade.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString()
            propriedade.cd_pessoa = ViewState.Item("cd_pessoa").ToString()
            If Not (ViewState.Item("id_pessoa").ToString.Equals(String.Empty)) Then
                propriedade.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString())
            End If
            If Not (ViewState.Item("id_propriedade").ToString.Equals(String.Empty)) Then
                propriedade.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString())
            End If
            propriedade.nm_propriedade = ViewState.Item("nm_propriedade").ToString()
            Dim dsPropriedade As DataSet

            'fran 07/2016 i
            If ViewState.Item("param_transf").ToString.Equals("S") Then
                propriedade.id_situacao = 0
                lbl_situacao.Text = String.Empty
                dsPropriedade = propriedade.getPropriedadeAtivaseTransferidas

            Else
                'fran 07/2016 f
                propriedade.id_situacao = Convert.ToInt32("1") 'ativo
                lbl_situacao.Text = "Ativo"
                dsPropriedade = propriedade.getPropriedadeByFilters

            End If


            If (dsPropriedade.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPropriedade.Tables(0), ViewState.Item("sortExpression"))
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

            Case "id_propriedade"
                If ViewState.Item("sortExpression") = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If


            Case "nm_propriedade"
                If ViewState.Item("sortExpression") = "nm_propriedade asc" Then
                    ViewState.Item("sortExpression") = "nm_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "nm_propriedade asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub salvarLinhaSelecionada(ByVal pid_propriedade As String)

        Try

            Dim propriedade As New Propriedade(Convert.ToInt32(pid_propriedade))

            '            gridResults.Rows(gridResults.SelectedIndex).Cells(0).Text

            customPage.setFilter("lupa_propriedade", "pessoa", propriedade.cd_pessoa & " - " & propriedade.nm_pessoa)
            customPage.setFilter("lupa_propriedade", "estabelecimento", propriedade.cd_estabelecimento & " - " & propriedade.nm_estabelecimento)
            customPage.setFilter("lupa_propriedade", "nm_propriedade", propriedade.nm_propriedade)
            customPage.setFilter("lupa_propriedade", "cd_pessoa", propriedade.cd_pessoa)
            customPage.setFilter("lupa_propriedade", "nm_pessoa", propriedade.nm_pessoa)
            customPage.setFilter("lupa_propriedade", "id_pessoa", propriedade.id_pessoa)

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
                'Dim produtor As New Pessoa(Convert.ToInt32(lidpessoa))
                'Page.ClientScript.RegisterHiddenField("txtDataHidden", TextBox1.Text.ToString)
                'Definindo valor para retornar! 

        End Select

    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()

    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        Me.lbl_nm_pessoa.Text = ""
        Me.txt_cd_pessoa.Text = ""
        Me.hf_id_pessoa.Value = ""
        Me.lbl_nm_pessoa.Visible = False
    End Sub
End Class
