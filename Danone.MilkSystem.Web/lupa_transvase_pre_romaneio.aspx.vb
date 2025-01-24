Imports Danone.MilkSystem.Business
Imports System.Data



Partial Class lupa_transvase_pre_romaneio
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_pre_romaneio") = txt_id_pre_romaneio.Text.Trim
        ViewState.Item("nr_caderneta") = txt_nr_caderneta.Text.Trim
        ViewState.Item("ds_placa") = txt_placa.Text.Trim
        ViewState.Item("nm_linha") = txt_nm_linha.Text.Trim


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        If ViewState.Item("param_id_transvase") = "0" Then
            Response.Redirect("lupa_transvase_pre_romaneio.aspx")
        Else
            Response.Redirect("lupa_transvase_pre_romaneio.aspx?id=" + ViewState.Item("param_id_transvase").ToString)
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
                ViewState.Item("param_id_transvase") = Request("id")
                loadDetails()

            End If


        End If

        'If Not Page.IsPostBack Then

        '    'PEga o valor do estabelecimento que veio da lista de propriedade
        '    ViewState.Item("id_estabelecimento") = Request("id")

        '    loadDetails()

        'End If
    End Sub


    Private Sub loadDetails()

        Try
            Dim transitpoint As New Transvase(ViewState.Item("param_id_transvase"))

            lbl_ds_estabelecimento.Text = transitpoint.ds_estabelecimento.ToString
            ViewState.Item("id_estabelecimento") = transitpoint.id_estabelecimento


            ViewState.Item("sortExpression") = "id_romaneio asc"

            'loadFilters()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean


    '    If Not (customPage.getFilterValue("lupa_pessoa", txt_cd_pessoa.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("cd_pessoa") = customPage.getFilterValue("lupa_pessoa", txt_cd_pessoa.ID)
    '        txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
    '    Else
    '        ViewState.Item("cd_pessoa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("lupa_pessoa", txt_nm_pessoa.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("nm_pessoa") = customPage.getFilterValue("lupa_pessoa", txt_nm_pessoa.ID)
    '        txt_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
    '    Else
    '        ViewState.Item("nm_pessoa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("lupa_pessoa", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("lupa_pessoa", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("lupa_pessoa")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio

            romaneio.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString()
            romaneio.nm_linha = ViewState.Item("nm_linha").ToString
            romaneio.ds_placa = ViewState.Item("ds_placa").ToString
            If Not ViewState.Item("nr_caderneta").ToString.Equals(String.Empty) Then
                romaneio.nr_caderneta = ViewState.Item("nr_caderneta").ToString
            End If
            If Not ViewState.Item("id_pre_romaneio").ToString.Equals(String.Empty) Then
                romaneio.id_romaneio = ViewState.Item("id_pre_romaneio").ToString
            End If

            Dim dsromaneio As DataSet = romaneio.getPreRomaneioDisponivelTransvase

            If (dsromaneio.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsromaneio.Tables(0), ViewState.Item("sortExpression"))
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


            Case "id_romaneio"
                If ViewState.Item("sortExpression") = "id_romaneio asc" Then
                    ViewState.Item("sortExpression") = "id_romaneio desc"
                Else
                    ViewState.Item("sortExpression") = "id_romaneio asc"
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
            Case "nr_caderneta"
                If ViewState.Item("sortExpression") = "nr_caderneta asc" Then
                    ViewState.Item("sortExpression") = "nr_caderneta desc"
                Else
                    ViewState.Item("sortExpression") = "nr_caderneta asc"
                End If
            Case "nr_peso_liquido_caderneta"
                If ViewState.Item("sortExpression") = "nr_peso_liquido_caderneta asc" Then
                    ViewState.Item("sortExpression") = "nr_peso_liquido_caderneta desc"
                Else
                    ViewState.Item("sortExpression") = "nr_peso_liquido_caderneta asc"
                End If
            Case "nr_total_litros_tp_disponivel"
                If ViewState.Item("sortExpression") = "nr_total_litros_tp_disponivel asc" Then
                    ViewState.Item("sortExpression") = "nr_total_litros_tp_disponivel desc"
                Else
                    ViewState.Item("sortExpression") = "nr_total_litros_tp_disponivel asc"
                End If
            Case "nr_total_litros_tp_transferidos"
                If ViewState.Item("sortExpression") = "nr_total_litros_tp_transferidos asc" Then
                    ViewState.Item("sortExpression") = "nr_total_litros_tp_transferidos desc"
                Else
                    ViewState.Item("sortExpression") = "nr_total_litros_tp_transferidos asc"
                End If
            Case "nr_total_litros_tp_transferidos"
                If ViewState.Item("sortExpression") = "nr_total_saldo asc" Then
                    ViewState.Item("sortExpression") = "nr_total_saldo desc"
                Else
                    ViewState.Item("sortExpression") = "nr_total_saldo asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub salvarLinhaSelecionada(ByVal pid_romaneio As String)

        Try


            customPage.setFilter("lupa_transv_preromaneio", "id_romaneio", pid_romaneio.ToString)


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()

            Case "selecionar"
                Dim lidromaneio As String = e.CommandArgument.ToString
                Dim js As New System.Text.StringBuilder
                js.Append("<script>")
                js.Append("window.onload=FechaPagina();")
                js.Append("</script>")

                If (Not Page.ClientScript.IsClientScriptBlockRegistered("Wclose")) Then
                    Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Wclose", js.ToString)
                End If

                Page.ClientScript.RegisterHiddenField("txtDataHidden", lidromaneio)

                salvarLinhaSelecionada(lidromaneio)
                'Dim produtor As New Pessoa(Convert.ToInt32(lidpessoa))
                'Page.ClientScript.RegisterHiddenField("txtDataHidden", TextBox1.Text.ToString)
                'Definindo valor para retornar! 

        End Select

    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then


        End If
    End Sub


End Class
