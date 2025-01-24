Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class lst_gold_preco_leite_aprovar_2N

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia_inicial") = Me.txt_dt_referencia_inicial.Text()
        ViewState.Item("dt_referencia_final") = Me.txt_dt_referencia_final.Text()

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_gold_preco_leite_aprovar_2N.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_gold_preco_leite_aprovar_2N.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = "ds_produtor asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("gold_preco_aprovar_2N", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("gold_preco_aprovar_2N", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If



        If Not (customPage.getFilterValue("gold_preco_aprovar_2N", txt_dt_referencia_inicial.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia_inicial") = customPage.getFilterValue("gold_preco_aprovar_2N", txt_dt_referencia_inicial.ID)
            txt_dt_referencia_inicial.Text = ViewState.Item("dt_referencia_inicial").ToString()
        Else
            ViewState.Item("dt_referencia_inicial") = String.Empty
        End If

        If Not (customPage.getFilterValue("gold_preco_aprovar_2N", txt_dt_referencia_final.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia_final") = customPage.getFilterValue("gold_preco_aprovar_2N", txt_dt_referencia_final.ID)
            txt_dt_referencia_final.Text = ViewState.Item("dt_referencia_final").ToString()
        Else
            ViewState.Item("dt_referencia_final") = String.Empty
        End If

        If Not (customPage.getFilterValue("gold_preco_aprovar_2N", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("gold_preco_aprovar_2N", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("preco_negociado_aprovar")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim goldprecoleite As New GoldPrecoLeite

            goldprecoleite.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            If ViewState("dt_referencia_inicial").ToString <> "" Then
                goldprecoleite.dt_referencia_inicial = String.Concat("01/" & ViewState("dt_referencia_inicial").ToString)
            End If
            If ViewState("dt_referencia_final").ToString <> "" Then
                goldprecoleite.dt_referencia_final = String.Concat("01/" & ViewState("dt_referencia_final").ToString)
            End If

            Me.lk_aprovar.Enabled = True
            Me.lk_reprovar.Enabled = True

            Dim dsGoldPrecoLeite As DataSet = goldprecoleite.getGoldPrecoLeite2NByFilters()

            If (dsGoldPrecoLeite.Tables(0).Rows.Count > 0) Then
                ViewState("id_gold_custo_produtor") = dsGoldPrecoLeite.Tables(0).Rows(0).Item("id_gold_custo_produtor").ToString
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsGoldPrecoLeite.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                ViewState("id_gold_custo_produtor") = ""
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        saveCheckBox()
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

            Case "nm_aprovado"
                If (ViewState.Item("sortExpression")) = "nm_aprovado asc" Then
                    ViewState.Item("sortExpression") = "nm_aprovado desc"
                Else
                    ViewState.Item("sortExpression") = "nm_aprovado asc"
                End If

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("gold_preco_aprovar_2N", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("gold_preco_aprovar_2N", txt_dt_referencia_inicial.ID, ViewState.Item("dt_referencia_inicial").ToString)
            customPage.setFilter("gold_preco_aprovar_2N", txt_dt_referencia_final.ID, ViewState.Item("dt_referencia_final").ToString)
            customPage.setFilter("gold_preco_aprovar_2N", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.Trim.ToString
            Case "Edit", "Editar", "Cancel", "Cancelar", "Update"
                Return
        End Select

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim hl_nr_custo_operacional_efetivo As HyperLink = CType(e.Row.FindControl("hl_nr_custo_operacional_efetivo"), HyperLink)
            Dim hl_nr_custo_dieta As HyperLink = CType(e.Row.FindControl("hl_nr_custo_dieta"), HyperLink)
            Dim hl_nr_margem_custo_efetivo As HyperLink = CType(e.Row.FindControl("hl_nr_margem_custo_efetivo"), HyperLink)
            Dim lbl_id_gold_custo_produtor As Label = CType(e.Row.FindControl("lbl_id_gold_custo_produtor"), Label)
            Dim lbl_id_gold_custo As Label = CType(e.Row.FindControl("lbl_id_gold_custo"), Label)

            hl_nr_custo_operacional_efetivo.NavigateUrl = String.Format("frm_gold_custo_produtor.aspx?id_gold_custo_produtor={0}", lbl_id_gold_custo_produtor.Text) & String.Format("&acao={0}", "C")
            hl_nr_custo_dieta.NavigateUrl = String.Format("frm_gold_custo_produtor_dieta.aspx?id_gold_custo_produtor={0}", lbl_id_gold_custo_produtor.Text) & String.Format("&acao={0}", "C")
            hl_nr_margem_custo_efetivo.NavigateUrl = String.Format("frm_gold_custo.aspx?id_gold_custo={0}", lbl_id_gold_custo.Text) & String.Format("&acao={0}", "C")

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub lk_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_aprovar.Click
        Try
            Dim goldprecoleite As New GoldPrecoLeite

            If saveCheckBox() = True Then

                'Filtro
                goldprecoleite.id_gold_custo_produtor = Convert.ToInt32(ViewState("id_gold_custo_produtor"))

                'Dados para o Update
                goldprecoleite.st_aprovado = "2"   '  Aprovado 2.o Nível
                goldprecoleite.id_modificador = Session("id_login")

                goldprecoleite.updateGoldPrecoLeiteAprovarSelecionados()

                loadData()

                messageControl.Alert("Aprovação 2.o Nível concluída com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para a aprovação. Por favor selecione alguma propriedade.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridResults.RowCancelingEdit
        Try

            gridResults.EditIndex = -1
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridResults.RowEditing
        Try

            gridResults.EditIndex = e.NewEditIndex
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridResults.RowUpdating
        'Capturar valores
        Dim row As GridViewRow = gridResults.Rows(e.RowIndex)
        Try

            If (Not (row) Is Nothing) Then

                Dim goldprecoleite As New GoldPrecoLeite
                Dim erro As Boolean


                goldprecoleite.id_gold_preco_leite = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)

                Dim txt_ds_anotacao_aprovador As Anthem.TextBox = CType(row.FindControl("txt_ds_anotacao_aprovador"), Anthem.TextBox)
                If Not (txt_ds_anotacao_aprovador.Text.Trim.ToString.Equals(String.Empty)) Then
                    goldprecoleite.ds_anotacao_aprovador = txt_ds_anotacao_aprovador.Text
                Else
                    goldprecoleite.ds_anotacao_aprovador = ""
                End If
                goldprecoleite.id_modificador = Session("id_login")


                erro = False

                If erro = False Then
                    goldprecoleite.updateGoldPrecoLeiteAprovador()
                    gridResults.EditIndex = -1
                    loadData()
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                ch.Checked = ck_header.Checked
            Next

            ' Seleciona tudo o que o botão Pesquisar trouxe - i
            Dim goldprecoleite As New GoldPrecoLeite
            goldprecoleite.id_gold_custo_produtor = Convert.ToInt32(ViewState.Item("id_gold_custo_produtor").ToString)

            If ck_header.Checked = True Then
                goldprecoleite.st_selecao = "1"
            Else
                goldprecoleite.st_selecao = "0"
            End If
            goldprecoleite.updateGoldPrecoLeiteTodos2N()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function saveCheckBox() As Boolean

        Try

            Dim li As Integer
            Dim goldprecoleite As New GoldPrecoLeite

            For li = 0 To gridResults.Rows.Count - 1
                goldprecoleite.id_gold_preco_leite = gridResults.DataKeys(li).Value.ToString
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    goldprecoleite.st_selecao = "1"
                    saveCheckBox = True     ' Indica que tem item selecionado
                Else
                    goldprecoleite.st_selecao = "0"
                End If
                goldprecoleite.updateGoldPrecoLeiteSelecao()
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub lk_reprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_reprovar.Click
        Try
            Dim goldprecoleite As New GoldPrecoLeite

            If saveCheckBox() = True Then

                ' Dados do filtro
                goldprecoleite.id_gold_custo_produtor = Convert.ToInt32(ViewState("id_gold_custo_produtor"))

                'Dados para o update
                goldprecoleite.st_aprovado = "3"   '  Reprovado
                goldprecoleite.id_modificador = Session("id_login")

                goldprecoleite.updateGoldPrecoLeiteAprovarSelecionados()


                loadData()

                messageControl.Alert("Itens reprovados com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione alguma propriedade.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

End Class
