Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.Math

Partial Class frm_gold_custo_produtor_dieta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_gold_custo_produtor_dieta.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_item
            .Attributes.Add("onclick", "javascript:ShowDialogItem()")
            .ToolTip = "Filtrar Item"
        End With


    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_gold_custo_produtor") Is Nothing) Then 'Alteração
                Dim id_gold_custo_produtor As String = Request("id_gold_custo_produtor")
                ViewState.Item("id_gold_custo_produtor") = Convert.ToInt32(id_gold_custo_produtor)

                If Not (Request("acao") Is Nothing) Then
                    ViewState.Item("acao") = Request("acao")
                Else
                    ViewState.Item("acao") = ""
                End If

                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try



            Dim id_gold_custo_produtor As Int32 = Convert.ToInt32(ViewState.Item("id_gold_custo_produtor"))
            Dim goldcustoprodutor As New GoldCustoProdutor(id_gold_custo_produtor)

            lbl_produtor.Text = goldcustoprodutor.ds_produtor
            lbl_estabelecimento.Visible = True
            lbl_estabelecimento.Text = goldcustoprodutor.ds_estabelecimento
            lbl_nm_propriedade.Visible = True
            lbl_nm_propriedade.Text = goldcustoprodutor.ds_propriedade

            lbl_dt_referencia_inicial.Text = DateTime.Parse(goldcustoprodutor.dt_referencia_inicial.ToString).ToString("MM/yyyy")
            lbl_dt_referencia_final.Text = DateTime.Parse(goldcustoprodutor.dt_referencia_final.ToString).ToString("MM/yyyy")

            lbl_nr_volume_planejado.Text = goldcustoprodutor.nr_volume_planejado
            lbl_nr_taxa_crescimento_ano.Text = goldcustoprodutor.nr_taxa_crescimento_ano
            lbl_nr_taxa_vacas_lactacao.Text = goldcustoprodutor.nr_taxa_vacas_lactacao

            'ViewState.Item("nr_quantidade_total") = goldcustoprodutor.nr_quantidade_total
            'ViewState.Item("nr_custo_dieta_total") = goldcustoprodutor.nr_custo_dieta_total

            loadGridItens()

            If goldcustoprodutor.st_aprovado = "2" Then  ' Se já foi aprovado 2.o Nível, não pode mais alterar
                btn_novo_item.Enabled = False
                gridItens.Enabled = False
            End If


            If ViewState.Item("acao") = "C" Then  ' Se ação for Consulta (se veio das telas dos aprovadores)
                img_voltar.Visible = False
                img_voltarfooter.Visible = False
                lk_voltar.Visible = False
                lk_voltarFooter.Visible = False
                btn_novo_item.Enabled = False
                gridItens.Enabled = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_gold_custo_produtor.aspx?id_gold_custo_produtor=" & ViewState("id_gold_custo_produtor").ToString)
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("frm_gold_custo_produtor.aspx?id_gold_custo_produtor=" & ViewState("id_gold_custo_produtor").ToString)
    End Sub


    Protected Sub btn_lupa_item_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_item.Click
        carregarcampositem()

    End Sub
    Private Sub carregarcampositem()
        Try

            If Not (customPage.getFilterValue("lupa_item", "id_item").Equals(String.Empty)) Then
                ViewState.Item("id_item_adicionar") = customPage.getFilterValue("lupa_item", "id_item").ToString
            End If
            If Not (customPage.getFilterValue("lupa_item", "cd_item").Equals(String.Empty)) Then
                Me.txt_cd_item.Text = customPage.getFilterValue("lupa_item", "cd_item").ToString
            End If

            If Not (customPage.getFilterValue("lupa_item", "nm_item").Equals(String.Empty)) Then

                Me.lbl_nm_item.Visible = True
                Me.lbl_nm_item.Text = customPage.getFilterValue("lupa_item", "nm_item").ToString
            End If
            customPage.clearFilters("lupa_item")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_novo_item_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_item.Click
        If Page.IsValid Then

            ViewState.Item("btnnovoitem") = "S"
            Dim goldcustoprodutordieta As New GoldCustoProdutorDieta
            goldcustoprodutordieta.id_gold_custo_produtor = Convert.ToInt32(ViewState.Item("id_gold_custo_produtor").ToString)
            goldcustoprodutordieta.id_item = Convert.ToInt32(ViewState.Item("id_item_adicionar"))
            goldcustoprodutordieta.id_modificador = Session("id_login")
            goldcustoprodutordieta.insertGoldCustoProdutorDieta()
            'LimparSelecaoGridItens()


            gridItens.EditIndex = gridItens.Rows.Count
            ViewState.Item("label_prazo_pagto") = String.Empty

            loadGridItens()
            ViewState.Item("incluirlinha") = Nothing
            ViewState.Item("id_item_adicionar") = Nothing
            ViewState.Item("label_prazo_pagto") = Nothing
            txt_cd_item.Text = String.Empty
            lbl_nm_item.Text = String.Empty
        End If

    End Sub
    Private Sub loadGridItens()



        Dim goldcustoprodutordieta As New GoldCustoProdutorDieta
        goldcustoprodutordieta.id_gold_custo_produtor = ViewState.Item("id_gold_custo_produtor").ToString
        goldcustoprodutordieta.id_situacao = 1
        Dim dsItens As DataSet = goldcustoprodutordieta.getGoldCustoProdutorDietaByFilters()

        If (dsItens.Tables(0).Rows.Count > 0) Then
            gridItens.Visible = True
            gridItens.DataSource = Helper.getDataView(dsItens.Tables(0), ViewState.Item("sortExpression"))
            gridItens.DataBind()
        Else
            gridItens.Visible = False
        End If

    End Sub


    Protected Sub gridItens_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridItens.PageIndexChanging
        gridItens.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridItens_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridItens.RowCancelingEdit
        Try

            gridItens.EditIndex = -1
            loadGridItens()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridItens_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridItens.RowCommand
        Select Case e.CommandName.ToString().ToLower()
            Case "delete"
                deleteGoldCustoProdutorDieta(Convert.ToInt32(e.CommandArgument.ToString()))
        End Select

    End Sub
    Private Sub deleteGoldCustoProdutorDieta(ByVal id_gold_custo_produtor_dieta As Integer)

        Try
            'Delleta o item
            Dim goldcustoprodutordieta As New GoldCustoProdutorDieta

            goldcustoprodutordieta.id_gold_custo_produtor_dieta = id_gold_custo_produtor_dieta
            goldcustoprodutordieta.deleteGoldCustoProdutorDieta()
            messageControl.Alert("Registro excluído com sucesso!")
            loadGridItens()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridItens_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridItens.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            Try
                If Not (ViewState.Item("label_compra_central") Is Nothing) Then
                    Dim chk_compra_central As CheckBox = CType(e.Row.FindControl("chk_compra_central"), CheckBox)
                    If Not (ViewState.Item("label_compra_central").ToString.Equals(String.Empty)) Then
                        If ViewState.Item("label_compra_central").ToString = "S" Then
                            chk_compra_central.Checked = True
                        Else
                            chk_compra_central.Checked = False
                        End If
                        ViewState.Item("label_compra_central") = Nothing
                    End If

                End If

                If Not (ViewState.Item("label_compra_produtor") Is Nothing) Then
                    Dim chk_compra_produtor As CheckBox = CType(e.Row.FindControl("chk_compra_produtor"), CheckBox)
                    If Not (ViewState.Item("label_compra_produtor").ToString.Equals(String.Empty)) Then
                        If ViewState.Item("label_compra_produtor").ToString = "S" Then
                            chk_compra_produtor.Checked = True
                        Else
                            chk_compra_produtor.Checked = False
                        End If
                        ViewState.Item("label_compra_produtor") = Nothing
                    End If

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub gridItens_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridItens.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then

                If (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
                    Dim txt_nr_quantidade As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_quantidade"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_nr_valor_unitario As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_valor_unitario"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                    If CDbl(txt_nr_quantidade.Text) = 0 Then
                        txt_nr_quantidade.Text = String.Empty
                    End If

                    If CDbl(txt_nr_valor_unitario.Text) = 0 Then
                        txt_nr_valor_unitario.Text = String.Empty
                    End If

                Else
                    Dim lbl_id_gold_custo_produtor_dieta As Label = CType(e.Row.FindControl("lbl_id_gold_custo_produtor_dieta"), Label)
                    Dim lbl_st_tipo_compra As Label = CType(e.Row.FindControl("lbl_st_tipo_compra"), Label)
                    Dim chk_compra_central As CheckBox = CType(e.Row.FindControl("chk_compra_central"), CheckBox)
                    Dim chk_compra_produtor As CheckBox = CType(e.Row.FindControl("chk_compra_produtor"), CheckBox)
                    Dim lbl_nr_quantidade As Label = CType(e.Row.FindControl("lbl_nr_quantidade"), Label)
                    Dim lbl_nr_valor_unitario As Label = CType(e.Row.FindControl("lbl_nr_valor_unitario"), Label)

                    If lbl_st_tipo_compra.Text = "C" Then
                        chk_compra_central.Checked = True
                    Else
                        chk_compra_central.Checked = False
                    End If
                    If lbl_st_tipo_compra.Text = "P" Then
                        chk_compra_produtor.Checked = True
                    Else
                        chk_compra_produtor.Checked = False
                    End If

                    'If CLng(lbl_id_gold_custo_produtor_dieta.Text) = CLng(ViewState.Item("lbl_id_gold_custo_produtor_dieta")) Then
                    '    e.Row.ForeColor = Drawing.Color.Red
                    '    lbl_nr_quantidade.ForeColor = Drawing.Color.Red
                    '    lbl_nr_valor_unitario.ForeColor = Drawing.Color.Red
                    'Else
                    '    e.Row.ForeColor = System.Drawing.Color.FromName("#333333")
                    '    lbl_nr_quantidade.ForeColor = System.Drawing.Color.FromName("#333333")
                    '    lbl_nr_valor_unitario.ForeColor = Drawing.Color.Red
                    'End If


                End If
            End If

            If e.Row.RowType = DataControlRowType.Footer Then

                Dim goldcustoprodutor As New GoldCustoProdutor(Convert.ToInt32(ViewState.Item("id_gold_custo_produtor")))

                e.Row.Cells(4).Text = Round(goldcustoprodutor.nr_quantidade_total, 0)
                'e.Row.Cells(5).Text = FormatNumber((goldcustoprodutor.nr_custo_dieta_total / (Convert.ToDecimal(lbl_nr_volume_planejado.Text) * 31)), 4)
                e.Row.Cells(6).Text = goldcustoprodutor.nr_custo_dieta_total

                'fran 18/11/2014 i
                'lbl_nr_custo_dieta.Text = Round((goldcustoprodutor.nr_custo_dieta_total / (Convert.ToDecimal(lbl_nr_volume_planejado.Text) * 31)), 4)
                lbl_nr_custo_dieta.Text = Round((goldcustoprodutor.nr_custo_dieta_total / (Convert.ToDecimal(lbl_nr_volume_planejado.Text))), 4)
                'fran 18/11/2014 f

                If goldcustoprodutor.nr_quantidade_total > 0 Then
                    'fran 18/11/2014 i
                    'lbl_nr_eficiencia_dieta.Text = Round((Convert.ToDecimal(lbl_nr_volume_planejado.Text) * 31) / (Round(goldcustoprodutor.nr_quantidade_total * (Convert.ToDecimal(lbl_nr_taxa_vacas_lactacao.Text) / 100), 4)), 2)
                    lbl_nr_eficiencia_dieta.Text = Round((Convert.ToDecimal(lbl_nr_volume_planejado.Text)) / (Round(goldcustoprodutor.nr_quantidade_total * (Convert.ToDecimal(lbl_nr_taxa_vacas_lactacao.Text) / 100), 4)), 2)
                    'fran 18/11/2014 f
                End If


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridItens_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridItens.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub gridItens_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridItens.RowEditing
        Try

            Dim lbl_st_tipo_compra As Label = CType(gridItens.Rows(e.NewEditIndex).FindControl("lbl_st_tipo_compra"), Label)
            ViewState.Item("label_st_tipo_compra") = Trim(lbl_st_tipo_compra.Text)

            gridItens.EditIndex = e.NewEditIndex
            loadGridItens()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridItens_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridItens.RowUpdating
        Dim row As GridViewRow = gridItens.Rows(e.RowIndex)
        If Page.IsValid Then


            Try

                If (Not (row) Is Nothing) Then

                    Dim goldcustoprodutordieta As New GoldCustoProdutorDieta
                    Dim txt_nr_quantidade As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_quantidade"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_nr_valor_unitario As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_unitario"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim chk_compra_central As CheckBox = CType(row.FindControl("chk_compra_central"), CheckBox)
                    Dim chk_compra_produtor As CheckBox = CType(row.FindControl("chk_compra_produtor"), CheckBox)
                    Dim lbl_id_gold_custo_produtor_dieta As Label = CType(row.FindControl("lbl_id_gold_custo_produtor_dieta"), Label)

                    goldcustoprodutordieta.nr_quantidade = Convert.ToDecimal(txt_nr_quantidade.Text)
                    goldcustoprodutordieta.nr_valor_unitario = Convert.ToDecimal(txt_nr_valor_unitario.Text)
                    If chk_compra_central.Checked = True Then
                        goldcustoprodutordieta.st_tipo_compra = "C"
                    End If
                    If chk_compra_produtor.Checked = True Then
                        goldcustoprodutordieta.st_tipo_compra = "P"
                    End If
                    goldcustoprodutordieta.id_gold_custo_produtor_dieta = lbl_id_gold_custo_produtor_dieta.Text
                    goldcustoprodutordieta.id_modificador = Session("id_login")
                    goldcustoprodutordieta.updateGoldCustoProdutorDieta()

                    gridItens.EditIndex = -1

                    loadGridItens()
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
End Class
