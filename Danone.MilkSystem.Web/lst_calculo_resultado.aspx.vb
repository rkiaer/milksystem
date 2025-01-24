Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_calculo_resultado
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

            If Not (Request("id_calculo_execucao_itens") Is Nothing) Then
                ViewState.Item("id_calculo_execucao") = Request("id_calculo_execucao")
                ViewState.Item("id_calculo_execucao_itens") = Request("id_calculo_execucao_itens")
                ' 17/02/2009 Rls16 -i
                ViewState.Item("historico") = Request("historico")
                If Not (Request("historico") Is Nothing) Then
                    ViewState.Item("id_propriedade") = Request("id_propriedade")
                End If
                ' 17/02/2009 Rls16 - f
            End If
            loadFilters()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        ViewState.Item("tabera") = 1
        loadData()

    End Sub

    Private Sub loadData()

        Try

            Dim id_calculo_execucao_itens As Int32 = Convert.ToInt32(ViewState.Item("id_calculo_execucao_itens"))
            Dim calculoexecucao As New CalculoExecucao

            calculoexecucao.id_calculo_execucao_itens = id_calculo_execucao_itens
            Dim dscalculoexecucaoitens As DataSet = calculoexecucao.getCalculoExecucaoItensByFilters()
            ViewState.Item("id_calculo_execucao") = dscalculoexecucaoitens.Tables(0).Rows(0).Item("id_calculo_execucao")

            Dim fichafinanceira As New FichaFinanceira
            fichafinanceira.id_calculo_execucao = dscalculoexecucaoitens.Tables(0).Rows(0).Item("id_calculo_execucao")
            fichafinanceira.id_propriedade = dscalculoexecucaoitens.Tables(0).Rows(0).Item("id_propriedade")
            fichafinanceira.id_unid_producao = dscalculoexecucaoitens.Tables(0).Rows(0).Item("id_unid_producao")

            lbl_dt_referencia.Text = DateTime.Parse(dscalculoexecucaoitens.Tables(0).Rows(0).Item("dt_referencia")).ToString("MM/yyyy")
            If dscalculoexecucaoitens.Tables(0).Rows(0).Item("st_tipo_pagamento") = "M" Then
                lbl_tp_pagamento.Text = "M - Mensal"
            Else
                lbl_tp_pagamento.Text = "Q - Quinzenal"
                btn_sintetico.Visible = False
                btn_custos.Visible = False
            End If
            lbl_produtor.Text = dscalculoexecucaoitens.Tables(0).Rows(0).Item("ds_produtor")
            lbl_propriedade.Text = dscalculoexecucaoitens.Tables(0).Rows(0).Item("ds_propriedade")
            lbl_unid_producao.Text = dscalculoexecucaoitens.Tables(0).Rows(0).Item("nr_unid_producao")

            ' 07/03/2012 Projeto Tehmis - Mostra apenas o resultado do Mensal - i
            fichafinanceira.st_tipo_pagamento = dscalculoexecucaoitens.Tables(0).Rows(0).Item("st_tipo_pagamento").ToString
            ' 07/03/2012 Projeto Tehmis - Mostra apenas o resultado do Mensal - f

            Dim dsfichafinanceiraitens As DataSet = fichafinanceira.getFichaFinanceiraByFilters()


            If (dsfichafinanceiraitens.Tables(0).Rows.Count > 0) Then


                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsfichafinanceiraitens.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loaddata_sintetico()
        Try


            Dim id_calculo_execucao_itens As Int32 = Convert.ToInt32(ViewState.Item("id_calculo_execucao_itens"))
            Dim calculoexecucao As New CalculoExecucao

            calculoexecucao.id_calculo_execucao_itens = id_calculo_execucao_itens
            Dim dscalculoexecucaoitens As DataSet = calculoexecucao.getCalculoExecucaoItensByFilters()
            ViewState.Item("id_calculo_execucao") = dscalculoexecucaoitens.Tables(0).Rows(0).Item("id_calculo_execucao")

            Dim fichafinanceira As New FichaFinanceira
            fichafinanceira.id_calculo_execucao = dscalculoexecucaoitens.Tables(0).Rows(0).Item("id_calculo_execucao")
            fichafinanceira.id_propriedade = dscalculoexecucaoitens.Tables(0).Rows(0).Item("id_propriedade")
            fichafinanceira.id_unid_producao = dscalculoexecucaoitens.Tables(0).Rows(0).Item("id_unid_producao")
            fichafinanceira.st_visualizar = "S"

            Dim dsfichafinanceiraitens As DataSet = fichafinanceira.getFichaFinanceiraByFilters()


            If (dsfichafinanceiraitens.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsfichafinanceiraitens.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loaddata_custos()
        Try


            Dim id_calculo_execucao_itens As Int32 = Convert.ToInt32(ViewState.Item("id_calculo_execucao_itens"))
            Dim calculoexecucao As New CalculoExecucao

            calculoexecucao.id_calculo_execucao_itens = id_calculo_execucao_itens
            Dim dscalculoexecucaoitens As DataSet = calculoexecucao.getCalculoExecucaoItensByFilters()
            ViewState.Item("id_calculo_execucao") = dscalculoexecucaoitens.Tables(0).Rows(0).Item("id_calculo_execucao")

            Dim fichafinanceira As New FichaFinanceira
            fichafinanceira.id_calculo_execucao = dscalculoexecucaoitens.Tables(0).Rows(0).Item("id_calculo_execucao")
            fichafinanceira.id_propriedade = dscalculoexecucaoitens.Tables(0).Rows(0).Item("id_propriedade")
            fichafinanceira.id_unid_producao = dscalculoexecucaoitens.Tables(0).Rows(0).Item("id_unid_producao")
            fichafinanceira.id_natureza = 4  ' Custos

            Dim dsfichafinanceiraitens As DataSet = fichafinanceira.getFichaFinanceiraByFilters()


            If (dsfichafinanceiraitens.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsfichafinanceiraitens.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Função não implementado.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex

        Select Case ViewState.Item("tabera")
            Case 1
                loadData()
            Case 2
                loaddata_sintetico()
            Case 3
                loaddata_custos()
        End Select


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

                ' 20/05/2009 - Rls 17.5 - Chamado 244 - i
            Case "nr_ordem"
                If (ViewState.Item("sortExpression")) = "nr_ordem asc" Then
                    ViewState.Item("sortExpression") = "nr_ordem desc"
                Else
                    ViewState.Item("sortExpression") = "nr_ordem asc"
                End If
                ' 20/05/2009 - Rls 17.5 - Chamado 244 - f


        End Select

        Select Case ViewState.Item("tabera")
            Case 1
                loadData()
            Case 2
                loaddata_sintetico()
            Case 3
                loaddata_custos()
        End Select

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

            'Case "resultado"
            '    Response.Redirect("lst_calculo_resultado.aspx?id_calculo_execucao_itens=" + e.CommandArgument.ToString())

            '    Case "delete"
            '        deleteConta(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
           And e.Row.RowType <> DataControlRowType.Footer _
           And e.Row.RowType <> DataControlRowType.Pager) Then

            If (e.Row.Cells(2).Text.Trim().Equals("Q")) Then
                e.Row.Cells(2).Text = "Quantidade"
            Else
                e.Row.Cells(2).Text = "Valor"
            End If

            If (e.Row.Cells(4).Text.Trim().Equals("C")) Then
                e.Row.Cells(4).Text = "Calculado"
            Else
                If (e.Row.Cells(4).Text.Trim().Equals("S")) Then
                    e.Row.Cells(4).Text = "Central de Compras"   ' 03/11/2009 - Rl22 Central de Compras
                Else
                    e.Row.Cells(4).Text = "Informado"
                End If
            End If

            'fran 22/01/2011 gko fase 2
            If (e.Row.Cells(7).Text.Trim().Equals("-")) Then
                e.Row.Cells(7).Text = String.Empty
            End If
            'fran 22/01/2011 gko fase 2

        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        'Response.Redirect("lst_calculo_acompanhamento.aspx?id_calculo_execucao=" + ViewState.Item("id_calculo_execucao").ToString())
        ' 17/02/2009 Rls16 - i
        If ViewState.Item("historico") <> "" Then  ' Se veio do histórico
            Response.Redirect("lst_calculo_acompanhamento.aspx?id_calculo_execucao=" + ViewState.Item("id_calculo_execucao").ToString() + "&historico=S" + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString())
        Else
            Response.Redirect("lst_calculo_acompanhamento.aspx?id_calculo_execucao=" + ViewState.Item("id_calculo_execucao").ToString())
        End If
        ' 17/02/2009 Rls16 - f

    End Sub

 
    Protected Sub btn_analitico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_analitico.Click
        ViewState.Item("tabera") = 1

        btn_analitico.ImageUrl = "img/aba_calculo_ativa.gif"
        btn_sintetico.ImageUrl = "img/aba_demonstrativo.gif"
        btn_custos.ImageUrl = "img/aba_custos.gif"

        loadData()

    End Sub

    Protected Sub btn_custos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_custos.Click
        ViewState.Item("tabera") = 3

        btn_analitico.ImageUrl = "img/aba_calculo.gif"
        btn_sintetico.ImageUrl = "img/aba_demonstrativo.gif"
        btn_custos.ImageUrl = "img/aba_custos_ativa.gif"

        loaddata_custos()
    End Sub

    Protected Sub btn_sintetico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_sintetico.Click
        ViewState.Item("tabera") = 2

        btn_analitico.ImageUrl = "img/aba_calculo.gif"
        btn_sintetico.ImageUrl = "img/aba_demonstrativo_ativa.gif"
        btn_custos.ImageUrl = "img/aba_custos.gif"

        loaddata_sintetico()
    End Sub
End Class
