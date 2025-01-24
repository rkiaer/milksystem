Imports Danone.MilkSystem.Business
Imports System.Data



Partial Class lupa_transportador_cooperativa
    Inherits Page


    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim
        ViewState.Item("nm_pessoa") = txt_nm_pessoa.Text.Trim
        ViewState.Item("cd_cnpj") = txt_cd_cnpj.Text.Trim 'fran 08/08/2012



        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        If ViewState.Item("param_id_estabelecimento") = "0" Then
            Response.Redirect("lupa_transportador_cooperativa.aspx")
        Else
            Response.Redirect("lupa_transportador_cooperativa.aspx?id_estabelecimento=" + ViewState.Item("param_id_estabelecimento").ToString)
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
            If Not (Request("id_estabelecimento") Is Nothing) Then
                'PEga o valor do estabelecimento que veio da lista de propriedade
                ViewState.Item("param_id_estabelecimento") = Request("id_estabelecimento")
            Else
                ViewState.Item("param_id_estabelecimento") = "0"
            End If

            loadDetails()

        End If
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

            ViewState.Item("sortExpression") = "nm_pessoa asc"

            'loadFilters()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean


    '    If Not (customPage.getFilterValue("lupa_transportador", txt_cd_pessoa.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("cd_pessoa") = customPage.getFilterValue("lupa_transportador", txt_cd_pessoa.ID)
    '        txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
    '    Else
    '        ViewState.Item("cd_pessoa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("lupa_transportador", txt_nm_pessoa.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("nm_pessoa") = customPage.getFilterValue("lupa_transportador", txt_nm_pessoa.ID)
    '        txt_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
    '    Else
    '        ViewState.Item("nm_pessoa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("lupa_transportador", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("lupa_transportador", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("lupa_transportador")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim produtor As New Pessoa

            produtor.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString()
            produtor.cd_pessoa = ViewState.Item("cd_pessoa").ToString()
            produtor.id_situacao = Convert.ToInt32("1") 'ativo
            produtor.nm_pessoa = ViewState.Item("nm_pessoa").ToString()
            produtor.cd_cnpj = ViewState.Item("cd_cnpj").ToString 'fran 08/08/2012

            Dim dsTransportador As DataSet = produtor.getTransportadorCooperativaByFilters()

            If (dsTransportador.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsTransportador.Tables(0), ViewState.Item("sortExpression"))
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


            Case "st_categoria"
                If ViewState.Item("sortExpression") = "st_categoria asc" Then
                    ViewState.Item("sortExpression") = "st_categoria desc"
                Else
                    ViewState.Item("sortExpression") = "st_categoria asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub salvarLinhaSelecionada(ByVal pid_produtor As String)

        Try

            Dim transportador As New Pessoa(Convert.ToInt32(pid_produtor))

            customPage.setFilter("lupa_transcoop", "cd_pessoa", transportador.cd_pessoa)

            customPage.setFilter("lupa_transcoop", "nm_pessoa", transportador.nm_pessoa)

            customPage.setFilter("lupa_transcoop", "nm_abreviado", transportador.nm_abreviado)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()

            Case "selecionar"
                Dim lidpessoa As Int32 = e.CommandArgument.ToString
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


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            If (e.Row.Cells(2).Text.Trim().Equals("J")) Then
                e.Row.Cells(2).Text = "Jurídica"
            Else
                e.Row.Cells(2).Text = "Física"
            End If

        End If
    End Sub


End Class
