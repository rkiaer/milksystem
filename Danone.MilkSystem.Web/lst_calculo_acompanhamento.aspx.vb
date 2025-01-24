Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_calculo_acompanhamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_calculo_produtor.aspx")

        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            If Not (Request("id_calculo_execucao") Is Nothing) Then
                ViewState.Item("id_calculo_execucao") = Request("id_calculo_execucao")
                ViewState.Item("historico") = Request("historico")
                If Not (Request("historico") Is Nothing) Then
                    ViewState.Item("id_propriedade") = Request("id_propriedade")   ' 17/02/2009 Rls16
                    lk_voltar.Visible = True
                    img_voltar.Visible = True
                Else
                    lk_voltar.Visible = False
                    img_voltar.Visible = False
                End If
            End If

            'Dim id_calculo_execucao As Int32 = Convert.ToInt32(ViewState.Item("id_calculo_execucao"))
            'Dim calculoexecucao As New CalculoExecucao(id_calculo_execucao)

            'lbl_dt_referencia.Text = DateTime.Parse(calculoexecucao.dt_referencia).ToString("MM/yyyy")
            'If calculoexecucao.st_tipo_pagamento = "M" Then
            '    lbl_tp_pagamento.Text = "M - Mensal"
            'Else
            '    lbl_tp_pagamento.Text = "Q - Quinzenal"
            'End If
            'lbl_nr_execucao.Text = id_calculo_execucao
            'lbl_total_propriedade.Text = 


            'ViewState.Item("sortExpression") = "ds_produtor asc"

            loadFilters()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        'Dim hasFilters As Boolean

        'If Not (customPage.getFilterValue("conta", txt_cd_conta.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("cd_conta") = customPage.getFilterValue("conta", txt_cd_conta.ID)
        '    txt_cd_conta.Text = ViewState.Item("cd_conta").ToString()
        'Else
        '    ViewState.Item("cd_conta") = String.Empty
        'End If

        'If Not (customPage.getFilterValue("conta", txt_nm_conta.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("nm_conta") = customPage.getFilterValue("conta", txt_nm_conta.ID)
        '    txt_nm_conta.Text = ViewState.Item("nm_conta").ToString()
        'Else
        '    ViewState.Item("nm_conta") = String.Empty
        'End If

        'If Not (customPage.getFilterValue("conta", cbo_natureza_conta.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("id_natureza") = customPage.getFilterValue("conta", cbo_natureza_conta.ID)
        '    cbo_natureza_conta.Text = ViewState.Item("id_natureza").ToString()
        'Else
        '    ViewState.Item("id_natureza") = String.Empty
        'End If


        'If Not (customPage.getFilterValue("conta", cbo_situacao.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("id_situacao") = customPage.getFilterValue("conta", cbo_situacao.ID)
        '    cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        'Else
        '    ViewState.Item("id_situacao") = String.Empty
        'End If


        'If Not (customPage.getFilterValue("conta", "PageIndex").Equals(String.Empty)) Then
        '    'hasFilters = True
        '    ViewState.Item("PageIndex") = customPage.getFilterValue("conta", "PageIndex").ToString()
        '    gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        'End If

        'If (hasFilters) Then
        loadData()
        '    customPage.clearFilters("conta")
        'End If

    End Sub

    Private Sub loadData()

        Try

            Dim id_calculo_execucao As Int32 = Convert.ToInt32(ViewState.Item("id_calculo_execucao"))
            Dim calculoexecucao As New CalculoExecucao(id_calculo_execucao)

            lbl_dt_referencia.Text = DateTime.Parse(calculoexecucao.dt_referencia).ToString("MM/yyyy")
            If calculoexecucao.st_tipo_pagamento = "M" Then
                lbl_tp_pagamento.Text = "M - Mensal"
            Else
                lbl_tp_pagamento.Text = "Q - Quinzenal"
            End If
            lbl_nr_execucao.Text = id_calculo_execucao

            '  17/02/2009 Rls16 - i
            If ViewState.Item("id_propriedade") <> "" Then
                calculoexecucao.id_propriedade = ViewState.Item("id_propriedade")
            End If
            '  17/02/2009 Rls16 - f

            Dim dscalculoexecucaoitens As DataSet = calculoexecucao.getCalculoExecucaoItensByFilters()
            lbl_total_propriedade.Text = dscalculoexecucaoitens.Tables(0).Rows.Count

            If (dscalculoexecucaoitens.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscalculoexecucaoitens.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
            End If

            ' 21/01/2009 - Rls15 - i
            calculoexecucao.st_calculo_execucao_itens = "4"  ' Total sem Volume Leite
            Dim dscalculoexecucaoitens_volume As DataSet = calculoexecucao.getCalculoExecucaoItensByFilters()
            lbl_total_sem_volume.Text = dscalculoexecucaoitens_volume.Tables(0).Rows.Count

            calculoexecucao.st_calculo_execucao_itens = "5"  ' Total sem Preço Aprovado
            Dim dscalculoexecucaoitens_preco As DataSet = calculoexecucao.getCalculoExecucaoItensByFilters()
            lbl_total_sem_preco.Text = dscalculoexecucaoitens_preco.Tables(0).Rows.Count
            ' 21/01/2009 - Rls15 - f

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub


    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()



            Case "cd_conta"
                If (ViewState.Item("sortExpression")) = "cd_conta asc" Then
                    ViewState.Item("sortExpression") = "cd_conta desc"
                Else
                    ViewState.Item("sortExpression") = "cd_conta asc"
                End If


            Case "nm_conta"
                If (ViewState.Item("sortExpression")) = "nm_conta asc" Then
                    ViewState.Item("sortExpression") = "nm_conta desc"
                Else
                    ViewState.Item("sortExpression") = "nm_conta asc"
                End If

            Case "id_natureza"
                If (ViewState.Item("sortExpression")) = "id_natureza asc" Then
                    ViewState.Item("sortExpression") = "id_natureza desc"
                Else
                    ViewState.Item("sortExpression") = "id_natureza asc"
                End If

            Case "st_calculo_execucao_itens"
                ' 20/01/2009 - Rls15 - i
                If (ViewState.Item("sortExpression")) = "st_calculo_execucao_itens asc" Then
                    ViewState.Item("sortExpression") = "st_calculo_execucao_itens desc"
                Else
                    ViewState.Item("sortExpression") = "st_calculo_execucao_itens asc"
                End If
                ' 20/01/2009 - Rls15 - f

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            'customPage.setFilter("conta", txt_cd_conta.ID, ViewState.Item("cd_conta").ToString)
            'customPage.setFilter("conta", txt_nm_conta.ID, ViewState.Item("nm_conta").ToString)
            'customPage.setFilter("conta", cbo_natureza_conta.ID, ViewState.Item("id_natureza").ToString)
            'customPage.setFilter("conta", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            'customPage.setFilter("conta", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "resultado"
                ' 17/02/2009 Rls16 - i
                'Response.Redirect("lst_calculo_resultado.aspx?id_calculo_execucao_itens=" + e.CommandArgument.ToString() + "&id_calculo_execucao=" + ViewState.Item("id_calculo_execucao").ToString)
                If ViewState.Item("historico") <> "S" Then
                    Response.Redirect("lst_calculo_resultado.aspx?id_calculo_execucao_itens=" + e.CommandArgument.ToString() + "&id_calculo_execucao=" + ViewState.Item("id_calculo_execucao").ToString)
                Else
                    Response.Redirect("lst_calculo_resultado.aspx?id_calculo_execucao_itens=" + e.CommandArgument.ToString() + "&id_calculo_execucao=" + ViewState.Item("id_calculo_execucao").ToString + "&historico=S" + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString())  ' 17/02/2009 Rls16
                End If
                ' 17/02/2009 Rls16 - f

                '    Case "delete"
                '        deleteConta(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            'fran 29/05/2018 i
            'If (e.Row.Cells(4).Text.Trim().Equals("1")) Then
            '    e.Row.Cells(4).Text = "Calculado com Erro"
            'Else
            '    If (e.Row.Cells(4).Text.Trim().Equals("2")) Then
            '        e.Row.Cells(4).Text = "Calculado com Sucesso"
            '    Else
            '        If (e.Row.Cells(4).Text.Trim().Equals("3")) Then
            '            e.Row.Cells(4).Text = "Cálculo Definitivo"
            '        Else
            '            ' 20/01/2009 - Rls15 - Seta erro também quando não tem Preço Negociado - i
            '            'e.Row.Cells(4).Text = "Não Calculado"  ' Quando não tem volume de leite (por ex.)
            '            If (e.Row.Cells(4).Text.Trim().Equals("4")) Then
            '                e.Row.Cells(4).Text = "Não Calculado - Sem Volume"  ' Quando não tem volume de leite 
            '            Else
            '                ' Adri 16/06/2016 - chamado 2448 - Cálculo Geométrico - i
            '                'e.Row.Cells(4).Text = "Não Calculado - Sem Preço"  ' Quando não tem Preço Aprovado
            '                If (e.Row.Cells(4).Text.Trim().Equals("5")) Then
            '                    e.Row.Cells(4).Text = "Não Calculado - Sem Preço"  ' Quando não tem Preço Aprovado
            '                Else  ' Se tipo 6
            '                    e.Row.Cells(4).Text = "Não Calculado - Sem Qualidade Liberada"  ' Quando não tem Qualidade da ESALQ liberada para cálculo
            '                End If
            '                ' Adri 16/06/2016 - chamado 2448 - Cálculo Geométrico - f
            '            End If
            '            ' 20/01/2009 - Rls15 - Seta erro também quando não tem Preço Negociado - f
            '        End If
            '    End If
            'End If
            Select Case e.Row.Cells(4).Text.Trim()
                Case "1"
                    e.Row.Cells(4).Text = "Calculado com Erro"
                Case "2"
                    e.Row.Cells(4).Text = "Calculado com Sucesso"
                Case "3"
                    e.Row.Cells(4).Text = "Cálculo Definitivo"
                Case "4"
                    e.Row.Cells(4).Text = "Não Calculado - Sem Volume"  ' Quando não tem volume de leite 
                Case "5"
                    e.Row.Cells(4).Text = "Não Calculado - Sem Preço"  ' Quando não tem Preço Aprovado
                Case "6"
                    e.Row.Cells(4).Text = "Não Calculado - Sem Qualidade Liberada"  ' Quando não tem Qualidade da ESALQ liberada para cálculo
                Case "7"
                    e.Row.Cells(4).Text = "Não Calculado - Sem Faixa Adicional de Volume"  ' Quando não tem Qualidade da ESALQ liberada para cálculo

                Case "8"
                    e.Row.Cells(4).Text = "Não Calculado - Indicador Preço não aprovado em 2o Nível"  '

                Case "9"
                    e.Row.Cells(4).Text = "Não Calculado - Modelo Contrato Produtor não aprovado em 2o Nível"  ' 

                Case "0"
                    e.Row.Cells(4).Text = "Não Calculado - Taxa de Juros não cadastrada"  ' 

            End Select
            'fran 29/05/2018 f




        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        saveFilters()
        If ViewState.Item("historico") = "S" Then
            Response.Redirect("lst_calculo_historico.aspx")
        Else
            Response.Redirect("frm_calculo_produtor.aspx")
        End If

    End Sub
End Class
