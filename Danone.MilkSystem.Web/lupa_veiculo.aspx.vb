Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lupa_veiculo
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
        ' ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        If ViewState.Item("param_id_transportador") = "0" Then
            Response.Redirect("lupa_veiculo.aspx")
        Else
            Response.Redirect("lupa_veiculo.aspx?id=" + ViewState.Item("param_id_transportador").ToString)
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
                'PEga o valor do transportador 
                ViewState.Item("param_id_transportador") = Request("id")
                If Not ViewState.Item("param_id_transportador").ToString.Equals("0") Then
                    tr_transportador.Visible = True
                    Dim pessoa As New Pessoa(ViewState.Item("param_id_transportador"))
                    lbl_transportador.Text = String.Concat(pessoa.cd_pessoa.ToString, " - ", pessoa.nm_pessoa.ToString)
                End If
            Else
                ViewState.Item("param_id_transportador") = 0
                tr_transportador.Visible = False

            End If

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try


            ViewState.Item("sortExpression") = "ds_placa asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("lupa_veiculo", txt_cd_veiculo.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_veiculo") = customPage.getFilterValue("lupa_veiculo", txt_cd_veiculo.ID)
            txt_cd_veiculo.Text = ViewState.Item("id_veiculo").ToString()
        Else
            ViewState.Item("id_veiculo") = "0"
        End If

        If Not (customPage.getFilterValue("lupa_veiculo", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("lupa_veiculo", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If

        If Not (customPage.getFilterValue("lupa_veiculo", txt_modelo.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_modelo") = customPage.getFilterValue("lupa_veiculo", txt_modelo.ID)
            txt_modelo.Text = ViewState.Item("ds_modelo").ToString()
        Else
            ViewState.Item("ds_modelo") = String.Empty
        End If

        If Not (customPage.getFilterValue("lupa_veiculo", txt_ano_fabricacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_ano_fabricacao") = customPage.getFilterValue("lupa_veiculo", txt_ano_fabricacao.ID)
            txt_ano_fabricacao.Text = ViewState.Item("nr_ano_fabricacao").ToString()
        Else
            ViewState.Item("nr_ano_fabricacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("lupa_veiculo", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("lupa_veiculo", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("lupa_veiculo")
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
            veiculo.id_situacao = Convert.ToInt32("1")

            If Not ViewState.Item("param_id_transportador").ToString.Equals("0") Then
                veiculo.id_pessoa = ViewState.Item("param_id_transportador")
            End If

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

    Private Sub salvarLinhaSelecionada(ByVal pid_veiculo As String)

        Try

            Dim veiculo As New Veiculo(Convert.ToInt32(pid_veiculo))

            customPage.setFilter("lupa_veiculo", "ds_placa", veiculo.ds_placa)
            customPage.setFilter("lupa_veiculo", "id_veiculo", veiculo.id_veiculo) 'fran 27/12/2016
            customPage.setFilter("lupa_veiculo", "id_transportador", veiculo.id_pessoa) 'fran 27/12/2016

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()

            Case "selecionar"
                Dim lidveiculo As String = e.CommandArgument.ToString
                Dim js As New System.Text.StringBuilder
                js.Append("<script>")
                js.Append("window.onload=FechaPagina();")
                js.Append("</script>")

                If (Not Page.ClientScript.IsClientScriptBlockRegistered("Wclose")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Wclose", js.ToString)
                End If

                Page.ClientScript.RegisterHiddenField("txtDataHidden", lidveiculo)

                salvarLinhaSelecionada(lidveiculo)
        End Select

    End Sub

End Class
