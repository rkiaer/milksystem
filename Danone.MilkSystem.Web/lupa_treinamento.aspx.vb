Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lupa_treinamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Not (txt_cd_treinamento.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_treinamento") = txt_cd_treinamento.Text.Trim()
        Else
            ViewState.Item("id_treinamento") = "0"
        End If
        ViewState.Item("nm_treinamento") = txt_nm_treinamento.Text.Trim()

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lupa_treinamento.aspx")

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


            ViewState.Item("sortExpression") = "nm_treinamento asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("lupa_treinamento", txt_cd_treinamento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_treinamento") = customPage.getFilterValue("lupa_treinamento", txt_cd_treinamento.ID)
            txt_cd_treinamento.Text = ViewState.Item("id_treinamento").ToString()
        Else
            ViewState.Item("id_treinamento") = "0"
        End If

        If Not (customPage.getFilterValue("lupa_treinamento", txt_nm_treinamento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_treinamento") = customPage.getFilterValue("lupa_treinamento", txt_nm_treinamento.ID)
            txt_nm_treinamento.Text = ViewState.Item("nm_treinamento").ToString()
        Else
            ViewState.Item("nm_treinamento") = String.Empty
        End If

        If Not (customPage.getFilterValue("lupa_treinamento", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("lupa_treinamento", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("treinamento")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim treinamento As New Treinamento

            treinamento.id_treinamento = Convert.ToInt32(ViewState.Item("id_treinamento"))
            treinamento.id_situacao = Convert.ToInt32("1")

            Dim dsLupaTreinamento As DataSet = treinamento.getTreinamentoByFilters()

            If (dsLupaTreinamento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsLupaTreinamento.Tables(0), ViewState.Item("sortExpression"))
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


            Case "id_treinamento"
                If ViewState.Item("sortExpression") = "id_treinamento asc" Then
                    ViewState.Item("sortExpression") = "id_treinamento desc"
                Else
                    ViewState.Item("sortExpression") = "id_treinamento asc"
                End If


            Case "nm_treinamento"
                If ViewState.Item("sortExpression") = "nm_treinamento asc" Then
                    ViewState.Item("sortExpression") = "nm_treinamento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_treinamento asc"
                End If

        End Select

        loadData()

    End Sub


    Private Sub salvarLinhaSelecionada(ByVal pid_treinamento As String)

        Try

            Dim treinamento As New Treinamento(Convert.ToInt32(pid_treinamento))

            customPage.setFilter("lupa_treinamento", "nm_treinamento", treinamento.nm_treinamento)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()

            Case "selecionar"
                Dim lidtreinamento As String = e.CommandArgument.ToString
                Dim js As New System.Text.StringBuilder
                js.Append("<script>")
                js.Append("window.onload=FechaPagina();")
                js.Append("</script>")

                If (Not Page.ClientScript.IsClientScriptBlockRegistered("Wclose")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Wclose", js.ToString)
                End If

                Page.ClientScript.RegisterHiddenField("txtDataHidden", lidtreinamento)

                salvarLinhaSelecionada(lidtreinamento)

        End Select

    End Sub






End Class
