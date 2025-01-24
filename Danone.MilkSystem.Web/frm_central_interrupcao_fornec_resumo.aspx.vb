Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_central_interrupcao_fornec_resumo

    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_central_interrupcao_fornec_resumo.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub
    Private Sub loadDetails()

        Try


            ViewState.Item("sortExpression") = ""

            If Not (Request("id_central_interrupcao_fornecimento") Is Nothing) Then
                ViewState.Item("id_central_interrupcao_fornecimento") = Request("id_central_interrupcao_fornecimento")
                'ViewState.Item("id_execucao") = Request("id_execucao")
                loadData()
            Else
                messageControl.Alert("Há problemas na passagem de parametros. A tela não pode ser montada!")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim intfornec As New InterrupcaoFornecimento
            Dim row As DataRow
            Dim lnr_total_pagto_fornec As Decimal = 0
            Dim lnr_total_pagto_fornec_efetivado As Decimal = 0
            Dim lnr_total_desc_prod As Decimal = 0
            Dim lnr_total_desc_prod_efetivado As Decimal = 0

            intfornec.id_central_interrupcao_fornecimento = Convert.ToInt32(ViewState.Item("id_central_interrupcao_fornecimento").ToString)

            Dim dsDetalhesTela As DataSet = intfornec.getInterrupcaoFornecimentoByFilters

            If dsDetalhesTela.Tables(0).Rows.Count > 0 Then
                With dsDetalhesTela.Tables(0).Rows(0)
                    lbl_dt_referencia.Text = DateTime.Parse(.Item("dt_referencia").ToString).ToString("MM/yyyy")
                    lbl_produtor.Text = .Item("nm_abreviado_produtor").ToString
                    lbl_propriedade_up.Text = .Item("ds_propriedade").ToString
                    lbl_id_propriedade_matriz.Text = .Item("id_propriedade_matriz").ToString
                    If lbl_id_propriedade_matriz.Text = "0" Then
                        lbl_id_propriedade_matriz.Text = String.Empty
                    End If
                    lbl_id_execucao.Text = .Item("id_execucao").ToString
                    ViewState.Item("id_execucao") = .Item("id_execucao").ToString
                    lbl_tecnico.Text = String.Concat(.Item("id_tecnico").ToString, " - ", .Item("nm_tecnico").ToString)
                    intfornec.id_propriedade = Convert.ToInt32(.Item("id_propriedade").ToString)
                    'intfornec.id_unid_producao = Convert.ToInt32(.Item("id_unid_producao").ToString)
                    intfornec.dt_referencia = DateTime.Parse(.Item("dt_referencia").ToString).ToString("dd/MM/yyyy")

                End With
            End If

            Dim dsTelaTotais As DataSet = intfornec.getCentralInterrupcaoFornecTotais

            If dsTelaTotais.Tables(0).Rows.Count > 0 Then
                With dsTelaTotais.Tables(0).Rows(0)
                    lbl_total_pagto_fornecedor.Text = FormatCurrency(.Item("nr_total_pagto_fornecedor").ToString, 2).ToString
                    lbl_total_pagto_exportacao.Text = FormatCurrency(.Item("nr_total_pagto_exportacao").ToString, 2).ToString
                    lbl_total_pagto_produtor.Text = FormatCurrency(.Item("nr_total_pagto_produtor").ToString, 2).ToString
                    lbl_total_desconto_produtor.Text = FormatCurrency(.Item("nr_total_desconto_produtor").ToString, 2).ToString
                    lbl_total_desconto_calculo.Text = FormatCurrency(.Item("nr_total_desconto_calculo").ToString, 2).ToString
                    lbl_total_desconto_deposito.Text = FormatCurrency(.Item("nr_total_desconto_deposito").ToString, 2).ToString
                End With
            Else
                lbl_total_pagto_fornecedor.Text = FormatCurrency(0, 2).ToString
                lbl_total_pagto_exportacao.Text = FormatCurrency(0, 2).ToString
                lbl_total_pagto_produtor.Text = FormatCurrency(0, 2).ToString
                lbl_total_desconto_produtor.Text = FormatCurrency(0, 2).ToString
                lbl_total_desconto_calculo.Text = FormatCurrency(0, 2).ToString
                lbl_total_desconto_deposito.Text = FormatCurrency(0, 2).ToString

            End If

            Dim dspagtofornec As DataSet = intfornec.getPagtoFornecedorbyPropriedade

            If (dspagtofornec.Tables(0).Rows.Count > 0) Then
                gridPagtoFornec.Visible = True
                gridPagtoFornec.DataSource = Helper.getDataView(dspagtofornec.Tables(0), "")
                gridPagtoFornec.DataBind()
            Else
                gridPagtoFornec.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado.")
            End If

            For Each row In dspagtofornec.Tables(0).Rows
                If row.Item("efetivado").ToString.Trim = "S" Then
                    lnr_total_pagto_fornec_efetivado = lnr_total_pagto_fornec_efetivado + Convert.ToDecimal(row.Item("nr_valor_parcela").ToString)
                End If
                lnr_total_pagto_fornec = lnr_total_pagto_fornec + Convert.ToDecimal(row.Item("nr_valor_parcela").ToString)
            Next

            Dim dsdescprodutor As DataSet = intfornec.getDescontoProdutorbyPropriedade

            If (dspagtofornec.Tables(0).Rows.Count > 0) Then
                gridDescProdutor.Visible = True
                gridDescProdutor.DataSource = Helper.getDataView(dsdescprodutor.Tables(0), "")
                gridDescProdutor.DataBind()
            Else
                gridDescProdutor.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado.")
            End If
            For Each row In dsdescprodutor.Tables(0).Rows
                If row.Item("efetivado").ToString.Trim = "S" Then
                    lnr_total_desc_prod_efetivado = lnr_total_desc_prod_efetivado + Convert.ToDecimal(row.Item("nr_valor_parcela").ToString)
                End If
                lnr_total_desc_prod = lnr_total_desc_prod + Convert.ToDecimal(row.Item("nr_valor_parcela").ToString)
            Next

            lbl_total_pagto_fornec.Text = lnr_total_pagto_fornec.ToString
            lbl_total_pagto_fornec_efetivado.Text = lnr_total_pagto_fornec_efetivado.ToString
            lbl_total_desc_prod.Text = lnr_total_desc_prod.ToString
            lbl_total_desc_prod_efetivado.Text = lnr_total_desc_prod_efetivado.ToString
            lbl_saldo.Text = ((lnr_total_desc_prod - lnr_total_desc_prod_efetivado) - (lnr_total_pagto_fornec - lnr_total_pagto_fornec_efetivado)).ToString

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridPagtoFornec_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridPagtoFornec.PageIndexChanging
        gridPagtoFornec.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridPagtoFornec_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridPagtoFornec.Sorting

        Select Case e.SortExpression.ToLower()

            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If


        End Select

        loadData()

    End Sub

    Protected Sub gridPagtoFornec_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridPagtoFornec.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_st_tipo_pagto As Label = CType(e.Row.FindControl("lbl_st_tipo_pagto"), Label)

            Dim efetivado As Label = CType(e.Row.FindControl("efetivado"), Label)
            Dim img_efetivado As Image = CType(e.Row.FindControl("img_efetivado"), Image)
            Dim btn_editar As Anthem.ImageButton = CType(e.Row.FindControl("btn_editar"), Anthem.ImageButton)

            If efetivado.Text.Trim.Equals("S") Then 'se pagamento já efetivado no calculo
                img_efetivado.ImageUrl = "~/img/ico_chk_true.gif"
            Else
                img_efetivado.ImageUrl = "~/img/ico_chk_false.gif"
            End If

            If lbl_st_tipo_pagto.Text.Equals("P") Then
                lbl_st_tipo_pagto.Text = "Produtor"
                btn_editar.Visible = True
                btn_editar.ToolTip = "Anexar Documento Acerto"
            Else
                lbl_st_tipo_pagto.Text = "Export."
                btn_editar.Visible = False
            End If

        End If
    End Sub

    Protected Sub gridDescProdutor_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridDescProdutor.PageIndexChanging
        gridDescProdutor.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridDescProdutor_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridDescProdutor.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "editar"
                Response.Redirect("frm_central_pedido_anexos.aspx?id=" + e.CommandArgument.ToString() + "&tipo=intdp&tela=frm_central_interrupcao_fornec_resumo.aspx?id_central_interrupcao_fornecimento=" + ViewState.Item("id_central_interrupcao_fornecimento").ToString)


        End Select


    End Sub

    Protected Sub gridDescProdutor_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridDescProdutor.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim efetivado As Label = CType(e.Row.FindControl("efetivado"), Label)
            Dim img_efetivado As Image = CType(e.Row.FindControl("img_efetivado"), Image)
            Dim lbl_st_tipo_desconto As Label = CType(e.Row.FindControl("lbl_st_tipo_desconto"), Label)
            Dim btn_editar As Anthem.ImageButton = CType(e.Row.FindControl("btn_editar"), Anthem.ImageButton)

            If efetivado.Text.Trim.Equals("S") Then 'se pagamento já efetivado no calculo
                img_efetivado.ImageUrl = "~/img/ico_chk_true.gif"
            Else
                img_efetivado.ImageUrl = "~/img/ico_chk_false.gif"
            End If
            If lbl_st_tipo_desconto.Text.Equals("L") Then
                lbl_st_tipo_desconto.Text = "Cálculo"
                btn_editar.Visible = False
            Else
                btn_editar.Visible = True
                btn_editar.ToolTip = "Anexar Documento Acerto"

                If lbl_st_tipo_desconto.Text.Equals("D") Then
                    lbl_st_tipo_desconto.Text = "Depósito"
                Else
                    lbl_st_tipo_desconto.Text = "Produtor"
                End If
            End If
        End If

    End Sub

    Protected Sub gridDescProdutor_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridDescProdutor.Sorting

    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_central_interrupcao_fornecimento.aspx")
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_central_interrupcao_fornecimento.aspx")
    End Sub

    Protected Sub gridPagtoFornec_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridPagtoFornec.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "editar"
                Response.Redirect("frm_central_pedido_anexos.aspx?id=" + e.CommandArgument.ToString() + "&tipo=intpf&tela=frm_central_interrupcao_fornec_resumo.aspx?id_central_interrupcao_fornecimento=" + ViewState.Item("id_central_interrupcao_fornecimento").ToString)


        End Select

    End Sub
End Class
