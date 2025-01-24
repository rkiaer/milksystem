Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.Math

Partial Class lst_gold_preco_leite

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("dt_referencia_inicial") = Me.txt_dt_referencia_inicial.Text()
            ViewState.Item("dt_referencia_final") = Me.txt_dt_referencia_final.Text()
            'ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

            insertData()    ' Carrega dados a partir da ms_gold_custo e ms_gold_custo_produtor, para depois calcular o preço final

        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_gold_preco_leite.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_gold_preco_leite.aspx")
        If Not Page.IsPostBack Then
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
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'Dim status As New Situacao

            'cbo_situacao.DataSource = status.getSituacoesByFilters()
            'cbo_situacao.DataTextField = "nm_situacao"
            'cbo_situacao.DataValueField = "id_situacao"
            'cbo_situacao.DataBind()

            ViewState.Item("sortExpression") = "dt_referencia_inicial desc"

            loadFilters()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("gold_preco", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("gold_preco", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("gold_preco", txt_dt_referencia_inicial.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_referencia_inicial") = customPage.getFilterValue("gold_preco", txt_dt_referencia_inicial.ID)
            txt_dt_referencia_inicial.Text = ViewState.Item("txt_dt_referencia_inicial").ToString()
        Else
            ViewState.Item("txt_dt_referencia_inicial") = String.Empty
        End If


        If Not (customPage.getFilterValue("gold_preco", txt_dt_referencia_final.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_referencia_final") = customPage.getFilterValue("gold_preco", txt_dt_referencia_final.ID)
            txt_dt_referencia_final.Text = ViewState.Item("txt_dt_referencia_final").ToString()
        Else
            ViewState.Item("txt_dt_referencia_final") = String.Empty
        End If


        'If Not (customPage.getFilterValue("gold_preco", cbo_situacao.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("id_situacao") = customPage.getFilterValue("gold_preco", cbo_situacao.ID)
        '    cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        'Else
        '    ViewState.Item("id_situacao") = String.Empty
        'End If


        If Not (customPage.getFilterValue("gold_preco", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("gold_preco", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("gold_preco")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim goldprecoleite As New GoldPrecoLeite

            goldprecoleite.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            goldprecoleite.dt_referencia_inicial = String.Concat("01/" & ViewState("dt_referencia_inicial").ToString)
            goldprecoleite.dt_referencia_final = String.Concat("01/" & ViewState("dt_referencia_final").ToString)
            If Trim(ViewState.Item("id_situacao")) <> "" Then
                goldprecoleite.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            End If

            Dim dsGoldPrecoLeite As DataSet = goldprecoleite.getGoldPrecoLeiteByFilters

            If (dsGoldPrecoLeite.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsGoldPrecoLeite.Tables(0), ViewState.Item("sortExpression"))
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
        loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "ds_produtor"
                If (ViewState.Item("sortExpression")) = "ds_produtor asc" Then
                    ViewState.Item("sortExpression") = "ds_produtor desc"
                Else
                    ViewState.Item("sortExpression") = "ds_produtor asc"
                End If

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If


        End Select

        loadData()

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("gold_preco", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("gold_preco", txt_dt_referencia_inicial.ID, ViewState.Item("dt_referencia_inicial").ToString)
            customPage.setFilter("gold_preco", txt_dt_referencia_final.ID, ViewState.Item("dt_referencia_final").ToString)
            'customPage.setFilter("gold_preco", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("gold_preco", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        ' Não vai para nenhuma tela consultar os detalhes dos custos que geraram o Preco Leite (ver a necessidade com a Ana)
        'Select Case e.CommandName.ToString().ToLower()

        '    Case "edit"
        '        saveFilters()
        '        Response.Redirect("frm_gold_preco_leite.aspx?id_gold_preco_leite=" + e.CommandArgument.ToString())

        'End Select

    End Sub



    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub



    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged

    End Sub



    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        If Page.IsValid = True Then
            Try


                Dim notificacao As New Notificacao
                Dim lAssunto As String = "Aprovação 1.o Nível de Preços Leite para Produtores GOLD "
                Dim lCorpo As String = "Existem preços para Produtores GOLD pendentes para aprovação 1.o Nível para o Período de " & txt_dt_referencia_inicial.Text & " à " & txt_dt_referencia_final.Text & "."

                If notificacao.enviaMensagemEmail(14, lAssunto, lCorpo, MailPriority.High, , , Convert.ToInt32(ViewState.Item("id_estabelecimento"))) = True Then
                    messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível foi enviada aos destinatários com sucesso!")
                Else

                    messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        End If

    End Sub
    Private Sub insertData()
        Try


            '=================================================================================================
            ' Verifica se existe Custos (Margens e Bonificacoes) já aprovados para o Cálculo do Preço do Leite
            '==================================================================================================
            Dim goldcusto As New GoldCusto
            goldcusto.id_estabelecimento = ViewState.Item("id_estabelecimento")
            goldcusto.dt_referencia_inicial = "01/" & ViewState.Item("dt_referencia_inicial")
            goldcusto.dt_referencia_final = "01/" & ViewState.Item("dt_referencia_final")
            goldcusto.id_situacao = 1 ' Ativo
            goldcusto.st_aprovado = 2 ' Aprovado
            Dim dsGoldCusto As DataSet = goldcusto.getGoldCustoByFilters()

            If (dsGoldCusto.Tables(0).Rows.Count > 0) Then
                goldcusto.id_gold_custo = dsGoldCusto.Tables(0).Rows(0).Item("id_gold_custo")
            Else
                messageControl.Alert("Os Custos GOLD (margens e bonificações) para o Estabelecimento/Período não foram informados ou não foram aprovados em 2.o Nível")
                Exit Sub
            End If


            '==================================================================================================================
            ' Verifica se existe Custos de Produtor (custos operacionais e dieta) já aprovados para o Cálculo do Preço do Leite
            '==================================================================================================================

            Dim goldcustoprodutor As New GoldCustoProdutor
            goldcustoprodutor.id_estabelecimento = ViewState.Item("id_estabelecimento")
            goldcustoprodutor.dt_referencia_inicial = "01/" & ViewState.Item("dt_referencia_inicial")
            goldcustoprodutor.dt_referencia_final = "01/" & ViewState.Item("dt_referencia_final")
            goldcustoprodutor.id_situacao = 1 ' Ativo
            goldcustoprodutor.st_aprovado = 2 ' Aprovado
            Dim dsGoldCustoProdutor As DataSet = goldcustoprodutor.getGoldCustoProdutorByFilters()

            If (dsGoldCustoProdutor.Tables(0).Rows.Count <= 0) Then
                messageControl.Alert("Os Custos do Produtor GOLD para o Estabelecimento/Período não foram informados ou não foram aprovados em 2.o Nível")
                Exit Sub
            End If

            '==================================================================================================================
            ' Se tudo ok, insere itens na tabela de preço 
            '==================================================================================================================
            Dim goldprecoleite As New GoldPrecoLeite
            goldprecoleite.id_gold_custo = goldcusto.id_gold_custo
            goldprecoleite.id_estabelecimento = ViewState.Item("id_estabelecimento")
            goldprecoleite.dt_referencia_inicial = "01/" & ViewState.Item("dt_referencia_inicial")
            goldprecoleite.dt_referencia_final = "01/" & ViewState.Item("dt_referencia_final")
            goldprecoleite.id_modificador = Session("id_login")
            goldprecoleite.insertGoldPrecoLeite()

            '==================================================================================================================
            ' Atualiza Atualiza  M Coef, M Vol, M Cresc, Custo Dieta, Efic. Dieta e Preço Final
            '==================================================================================================================
            Dim li As Int32
            Dim dsPrecoLeite As DataSet = goldprecoleite.getGoldPrecoLeiteByFilters()

            ' Para cada Propriedade, atualiza os dados
            For li = 0 To dsPrecoLeite.Tables(0).Rows.Count - 1

                ' 1 - Apura Custo Operacional Efetivo
                goldprecoleite.nr_custo_operacional_efetivo = dsPrecoLeite.Tables(0).Rows(li).Item("nr_custo_operacional_efetivo")

                ' 2 - Calcula Margem Custo Efetivo (M. Coe)
                goldcusto.nr_valor = dsPrecoLeite.Tables(0).Rows(li).Item("nr_custo_operacional_efetivo")  ' Busca Somatória dos custos operacionais na tabela ms_gold_custo_margem
                goldprecoleite.nr_margem_custo_efetivo = goldcusto.getGoldCustoMargemByRange()

                ' 3 - Calcula Margem Volume (M. Vol)
                goldcusto.nr_valor = dsPrecoLeite.Tables(0).Rows(li).Item("nr_volume_planejado")  ' Busca o vol. planejado na tabela ms_gold_custo_volume
                goldprecoleite.nr_margem_volume = goldcusto.getGoldCustoVolumeByRange()

                ' 4 - Calcula Margem Crescimento (M. Cresc)
                goldcusto.nr_valor = dsPrecoLeite.Tables(0).Rows(li).Item("nr_taxa_crescimento_ano")  ' Busca a taxa de crescimento na tabela ms_gold_custo_crescimento
                goldprecoleite.nr_margem_crescimento = goldcusto.getGoldCustoCrescimentoByRange()

                ' 5 - Calcula Custo Dieta em reais por litro (Racional)
                If dsPrecoLeite.Tables(0).Rows(li).Item("nr_volume_planejado") > 0 Then  ' Se tem volume litros por dia informado
                    'fran 18/11/2014 i
                    'goldprecoleite.nr_custo_dieta = Round(dsPrecoLeite.Tables(0).Rows(li).Item("nr_custo_dieta_total") / (dsPrecoLeite.Tables(0).Rows(li).Item("nr_volume_planejado") * 31), 4)
                    goldprecoleite.nr_custo_dieta = Round(dsPrecoLeite.Tables(0).Rows(li).Item("nr_custo_dieta_total") / (dsPrecoLeite.Tables(0).Rows(li).Item("nr_volume_planejado")), 4)
                    'fran 18/11/2014 f
                Else
                    goldprecoleite.nr_custo_dieta = 0
                End If

                ' 6 - Calcula Eficiencia Dieta 
                If Convert.ToDecimal(dsPrecoLeite.Tables(0).Rows(li).Item("nr_quantidade_total")) > 0 Then
                    'fran 18/11/2014 i
                    'goldcusto.nr_valor = Round((dsPrecoLeite.Tables(0).Rows(li).Item("nr_volume_planejado") * 31) / (Round(dsPrecoLeite.Tables(0).Rows(li).Item("nr_quantidade_total") * (dsPrecoLeite.Tables(0).Rows(li).Item("nr_taxa_vacas_lactacao") / 100), 4)), 2)
                    goldcusto.nr_valor = Round((dsPrecoLeite.Tables(0).Rows(li).Item("nr_volume_planejado")) / (Round(dsPrecoLeite.Tables(0).Rows(li).Item("nr_quantidade_total") * (dsPrecoLeite.Tables(0).Rows(li).Item("nr_taxa_vacas_lactacao") / 100), 4)), 2)
                    'fran 18/11/2014 f
                    goldprecoleite.nr_eficiencia_dieta = goldcusto.getGoldCustoEficienciaByRange()
                End If

                goldprecoleite.nr_preco_leite = goldprecoleite.nr_custo_operacional_efetivo + goldprecoleite.nr_margem_custo_efetivo + goldprecoleite.nr_margem_volume + goldprecoleite.nr_margem_crescimento + goldprecoleite.nr_custo_dieta + goldprecoleite.nr_eficiencia_dieta
                goldprecoleite.id_gold_preco_leite = dsPrecoLeite.Tables(0).Rows(li).Item("id_gold_preco_leite")
                goldprecoleite.updateGoldPrecoLeite()
            Next

            loadData()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim hl_nr_custo_operacional_efetivo As HyperLink = CType(e.Row.FindControl("hl_nr_custo_operacional_efetivo"), HyperLink)
            Dim hl_nr_custo_dieta As HyperLink = CType(e.Row.FindControl("hl_nr_custo_dieta"), HyperLink)
            Dim hl_nr_margem_custo_efetivo As HyperLink = CType(e.Row.FindControl("hl_nr_margem_custo_efetivo"), HyperLink)
            Dim lbl_id_gold_custo As Label = CType(e.Row.FindControl("lbl_id_gold_custo"), Label)

            hl_nr_custo_operacional_efetivo.NavigateUrl = String.Format("frm_gold_custo_produtor.aspx?id_gold_custo_produtor={0}", gridResults.DataKeys.Item(e.Row.RowIndex).Value()) & String.Format("&acao={0}", "C")
            hl_nr_custo_dieta.NavigateUrl = String.Format("frm_gold_custo_produtor_dieta.aspx?id_gold_custo_produtor={0}", gridResults.DataKeys.Item(e.Row.RowIndex).Value()) & String.Format("&acao={0}", "C")
            hl_nr_margem_custo_efetivo.NavigateUrl = String.Format("frm_gold_custo.aspx?id_gold_custo={0}", lbl_id_gold_custo.Text) & String.Format("&acao={0}", "C")

        End If

    End Sub
End Class
