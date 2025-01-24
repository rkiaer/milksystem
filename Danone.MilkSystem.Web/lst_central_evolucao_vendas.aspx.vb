Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_central_evolucao_vendas
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        btn_exportar.Visible = True
        ViewState.Item("gridtable") = String.Empty

        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia") = txt_dt_referencia.Text
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_evolucao_vendas.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_evolucao_vendas.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 106
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 


            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim pedido As New Pedido
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("dt_referencia").ToString().Equals(String.Empty)) Then
                pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/01/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
                pedido.dt_fim = Convert.ToDateTime(String.Concat("01/12/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            End If

            Dim dsevolucaovendas As DataSet = pedido.getEvolucaoVendas

            Dim dstable As New DataTable
            Dim ilinha As Integer

            dstable.Columns.Add("nm_fornecedor")
            dstable.Columns.Add("nr_valor_jan")
            dstable.Columns.Add("nr_valor_fev")
            dstable.Columns.Add("nr_valor_mar")
            dstable.Columns.Add("nr_valor_abr")
            dstable.Columns.Add("nr_valor_mai")
            dstable.Columns.Add("nr_valor_jun")
            dstable.Columns.Add("nr_valor_jul")
            dstable.Columns.Add("nr_valor_ago")
            dstable.Columns.Add("nr_valor_set")
            dstable.Columns.Add("nr_valor_out")
            dstable.Columns.Add("nr_valor_nov")
            dstable.Columns.Add("nr_valor_dez")
            dstable.Columns.Add("nr_valor_total")
            dstable.Columns.Add("data_descredenciamento")
            dstable.Columns.Add("id_fornecedor")

            Dim row As DataRow
            Dim lidfornecedorant As Int32 = 0
            Dim lvalortotalanual As Decimal = 0
            ilinha = 0
            'Insere na table
            dstable.Rows.InsertAt(dstable.NewRow(), ilinha) 'insere primeira linha


            For Each row In dsevolucaovendas.Tables(0).Rows
                'se fornecedor anterior igual a fornecedor
                If lidfornecedorant <> CInt(row.Item("id_fornecedor")) Then
                    'se primeira vez fornecedor
                    If lidfornecedorant > 0 Then 'se for outro fornecedor e não é o primeiro
                        With dstable.Rows.Item(ilinha)
                            'atualiza totalizador da linha anterior
                            .Item(13) = FormatNumber(Convert.ToDecimal(lvalortotalanual), 2, , , TriState.True)
                        End With
                        'Insere na table
                        ilinha = ilinha + 1
                        dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
                        lvalortotalanual = 0

                    End If
                End If
                'busca dados 
                With dstable.Rows.Item(ilinha)

                    .Item(0) = row.Item("nm_fornecedor").ToString
                    If row.Item("data_descredenciamento").ToString = String.Empty Then
                        .Item(14) = String.Empty
                    Else
                        .Item(14) = row.Item("data_descredenciamento").ToString("dd/MM/yyyy")
                    End If

                    .Item(15) = row.Item("id_fornecedor").ToString

                    Select Case Month(CDate(row.Item("dt_referencia").ToString))
                        Case 1
                            lvalortotalanual = lvalortotalanual + Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString)
                            .Item(1) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString), 2, , , TriState.True)
                        Case 2
                            lvalortotalanual = lvalortotalanual + Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString)
                            .Item(2) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString), 2, , , TriState.True)
                        Case 3
                            lvalortotalanual = lvalortotalanual + Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString)
                            .Item(3) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString), 2, , , TriState.True)
                        Case 4
                            lvalortotalanual = lvalortotalanual + Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString)
                            .Item(4) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString), 2, , , TriState.True)
                        Case 5
                            lvalortotalanual = lvalortotalanual + Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString)
                            .Item(5) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString), 2, , , TriState.True)
                        Case 6
                            lvalortotalanual = lvalortotalanual + Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString)
                            .Item(6) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString), 2, , , TriState.True)
                        Case 7
                            lvalortotalanual = lvalortotalanual + Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString)
                            .Item(7) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString), 2, , , TriState.True)
                        Case 8
                            lvalortotalanual = lvalortotalanual + Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString)
                            .Item(8) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString), 2, , , TriState.True)
                        Case 9
                            lvalortotalanual = lvalortotalanual + Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString)
                            .Item(9) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString), 2, , , TriState.True)
                        Case 10
                            lvalortotalanual = lvalortotalanual + Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString)
                            .Item(10) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString), 2, , , TriState.True)
                        Case 11
                            lvalortotalanual = lvalortotalanual + Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString)
                            .Item(11) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString), 2, , , TriState.True)
                        Case 12
                            lvalortotalanual = lvalortotalanual + Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString)
                            .Item(12) = FormatNumber(Convert.ToDecimal(row.Item("nr_valor_nota_fiscal").ToString), 2, , , TriState.True)
                    End Select
                End With
                lidfornecedorant = row.Item("id_fornecedor").ToString
            Next

            'se primeira vez fornecedor
            If lidfornecedorant > 0 Then 'se for outro fornecedor e não é o primeiro
                'atualiza totalizador da linha anterior
                With dstable.Rows.Item(ilinha)
                    .Item(13) = FormatNumber(Convert.ToDecimal(lvalortotalanual), 2, , , TriState.True)
                End With
            End If

            ViewState.Item("gridtable") = dstable

            If (dsevolucaovendas.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dstable, ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_central_evolucao_vendas.aspx?id_estabelecimento={0}", ViewState.Item("id_estabelecimento").ToString) & String.Format("&dt_referencia={0}", ViewState.Item("dt_referencia").ToString)
            Me.hl_imprimir.Enabled = True


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "cd_parceiro"
                'If (ViewState.Item("sortExpression")) = "cd_parceiro asc" Then
                '    ViewState.Item("sortExpression") = "cd_parceiro desc"
                'Else
                '    ViewState.Item("sortExpression") = "cd_parceiro asc"
                'End If

        End Select

        loadData()

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        ViewState.Item("gridtable") = String.Empty

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia") = txt_dt_referencia.Text
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        loadData()

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 106
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        Response.Redirect("frm_central_evolucao_vendas_excel.aspx?&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString)


    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
                   And e.Row.RowType <> DataControlRowType.Footer _
                   And e.Row.RowType <> DataControlRowType.Pager) Then

            'fran chamado 1079 28/11/2010 i
            Dim id_fornecedor As Label = CType(e.Row.FindControl("id_fornecedor"), Label)

            'Dim pedido As New Pedido
            'pedido.ano = Convert.ToInt32(ViewState.Item("dt_referencia"))
            'pedido.id_estabelecimento = ViewState.Item("id_estabelecimento")
            'pedido.id_fornecedor = Convert.ToInt32(id_fornecedor.Text)

            'e.Row.Cells(1).Text = pedido.getValorJan
            'e.Row.Cells(2).Text = pedido.getValorFev
            'e.Row.Cells(3).Text = pedido.getValorMar
            'e.Row.Cells(4).Text = pedido.getValorAbr
            'e.Row.Cells(5).Text = pedido.getValorMai
            'e.Row.Cells(6).Text = pedido.getValorJun
            'e.Row.Cells(7).Text = pedido.getValorJul
            'e.Row.Cells(8).Text = pedido.getValorAgo
            'e.Row.Cells(9).Text = pedido.getValorSet
            'e.Row.Cells(10).Text = pedido.getValorOut
            'e.Row.Cells(11).Text = pedido.getValorNov
            'e.Row.Cells(12).Text = pedido.getValorDez

            e.Row.Cells(1).Text = CStr(IIf(e.Row.Cells(1).Text.Trim = "0,00", String.Empty, e.Row.Cells(1).Text))
            e.Row.Cells(2).Text = CStr(IIf(e.Row.Cells(2).Text.Trim = "0,00", String.Empty, e.Row.Cells(2).Text))
            e.Row.Cells(3).Text = CStr(IIf(e.Row.Cells(3).Text.Trim = "0,00", String.Empty, e.Row.Cells(3).Text))
            e.Row.Cells(4).Text = CStr(IIf(e.Row.Cells(4).Text.Trim = "0,00", String.Empty, e.Row.Cells(4).Text))
            e.Row.Cells(5).Text = CStr(IIf(e.Row.Cells(5).Text.Trim = "0,00", String.Empty, e.Row.Cells(5).Text))
            e.Row.Cells(6).Text = CStr(IIf(e.Row.Cells(6).Text.Trim = "0,00", String.Empty, e.Row.Cells(6).Text))
            e.Row.Cells(7).Text = CStr(IIf(e.Row.Cells(7).Text.Trim = "0,00", String.Empty, e.Row.Cells(7).Text))
            e.Row.Cells(8).Text = CStr(IIf(e.Row.Cells(8).Text.Trim = "0,00", String.Empty, e.Row.Cells(8).Text))
            e.Row.Cells(9).Text = CStr(IIf(e.Row.Cells(9).Text.Trim = "0,00", String.Empty, e.Row.Cells(9).Text))
            e.Row.Cells(10).Text = CStr(IIf(e.Row.Cells(10).Text.Trim = "0,00", String.Empty, e.Row.Cells(10).Text))
            e.Row.Cells(11).Text = CStr(IIf(e.Row.Cells(11).Text.Trim = "0,00", String.Empty, e.Row.Cells(11).Text))
            e.Row.Cells(12).Text = CStr(IIf(e.Row.Cells(12).Text.Trim = "0,00", String.Empty, e.Row.Cells(12).Text))


            'If (e.Row.Cells(1).Text.Trim().Equals("&nbsp;")) Then 
            If (e.Row.Cells(1).Text.Trim().Equals(String.Empty)) Then  ' Adriana 01/12/2010
                e.Row.Cells(1).Text = " - "
                'Else
                '    nr_total_fornecedor = nr_total_fornecedor + Convert.ToDecimal(e.Row.Cells(1).Text) ' Adri 19/11/2009
            End If

            If (e.Row.Cells(2).Text.Trim().Equals(String.Empty)) Then
                e.Row.Cells(2).Text = " - "
                'Else
                '    nr_total_fornecedor = nr_total_fornecedor + Convert.ToDecimal(e.Row.Cells(2).Text) ' Adri 19/11/2009
            End If
            If (e.Row.Cells(3).Text.Trim().Equals(String.Empty)) Then
                e.Row.Cells(3).Text = " - "
                'Else
                '    nr_total_fornecedor = nr_total_fornecedor + Convert.ToDecimal(e.Row.Cells(3).Text) ' Adri 19/11/2009
            End If
            If (e.Row.Cells(4).Text.Trim().Equals(String.Empty)) Then
                e.Row.Cells(4).Text = " - "
                'Else
                '    nr_total_fornecedor = nr_total_fornecedor + Convert.ToDecimal(e.Row.Cells(4).Text) ' Adri 19/11/2009
            End If
            If (e.Row.Cells(5).Text.Trim().Equals(String.Empty)) Then
                e.Row.Cells(5).Text = " - "
                'Else
                '    nr_total_fornecedor = nr_total_fornecedor + Convert.ToDecimal(e.Row.Cells(5).Text) ' Adri 19/11/2009
            End If
            If (e.Row.Cells(6).Text.Trim().Equals(String.Empty)) Then
                e.Row.Cells(6).Text = " - "
                'Else
                '    nr_total_fornecedor = nr_total_fornecedor + Convert.ToDecimal(e.Row.Cells(6).Text) ' Adri 19/11/2009
            End If
            If (e.Row.Cells(7).Text.Trim().Equals(String.Empty)) Then
                e.Row.Cells(7).Text = " - "
                'Else
                '    nr_total_fornecedor = nr_total_fornecedor + Convert.ToDecimal(e.Row.Cells(7).Text) ' Adri 19/11/2009
            End If
            If (e.Row.Cells(8).Text.Trim().Equals(String.Empty)) Then
                e.Row.Cells(8).Text = " - "
                'Else
                '    nr_total_fornecedor = nr_total_fornecedor + Convert.ToDecimal(e.Row.Cells(8).Text) ' Adri 19/11/2009
            End If
            If (e.Row.Cells(9).Text.Trim().Equals(String.Empty)) Then
                e.Row.Cells(9).Text = " - "
                'Else
                '    nr_total_fornecedor = nr_total_fornecedor + Convert.ToDecimal(e.Row.Cells(9).Text) ' Adri 19/11/2009
            End If
            If (e.Row.Cells(10).Text.Trim().Equals(String.Empty)) Then
                e.Row.Cells(10).Text = " - "
                'Else
                '    nr_total_fornecedor = nr_total_fornecedor + Convert.ToDecimal(e.Row.Cells(10).Text) ' Adri 19/11/2009
            End If
            If (e.Row.Cells(11).Text.Trim().Equals(String.Empty)) Then
                e.Row.Cells(11).Text = " - "
                'Else
                '    nr_total_fornecedor = nr_total_fornecedor + Convert.ToDecimal(e.Row.Cells(11).Text) ' Adri 19/11/2009
            End If
            If (e.Row.Cells(12).Text.Trim().Equals(String.Empty)) Then
                e.Row.Cells(12).Text = " - "
                'Else
                '    nr_total_fornecedor = nr_total_fornecedor + Convert.ToDecimal(e.Row.Cells(12).Text) ' Adri 19/11/2009
            End If

            If (e.Row.Cells(13).Text.Trim().Equals(String.Empty)) Then

                e.Row.Cells(13).Text = " - "
            End If

        End If
        If (e.Row.RowType = DataControlRowType.Footer) Then

            Dim pedido As New Pedido

            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
 
            e.Row.Cells(0).Text = "Total"
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/01/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = pedido.dt_inicio
            e.Row.Cells(1).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/02/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = pedido.dt_inicio
            e.Row.Cells(2).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/03/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = pedido.dt_inicio
            e.Row.Cells(3).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/04/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = pedido.dt_inicio
            e.Row.Cells(4).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/05/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = pedido.dt_inicio
            e.Row.Cells(5).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/06/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = pedido.dt_inicio
            e.Row.Cells(6).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/07/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = pedido.dt_inicio
            e.Row.Cells(7).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/08/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = pedido.dt_inicio
            e.Row.Cells(8).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/09/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = pedido.dt_inicio
            e.Row.Cells(9).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/10/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = pedido.dt_inicio
            e.Row.Cells(10).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/11/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = pedido.dt_inicio
            e.Row.Cells(11).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/12/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = pedido.dt_inicio
            e.Row.Cells(12).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
            ' Adri 19/11/2009 - i
            'e.Row.Cells(13).Text = pedido.getValorTotalGeral
            pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/01/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            pedido.dt_fim = Convert.ToDateTime(String.Concat("01/12/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
            'e.Row.Cells(13).Text = Convert.ToDecimal(e.Row.Cells(1).Text) + Convert.ToDecimal(e.Row.Cells(2).Text) + Convert.ToDecimal(e.Row.Cells(3).Text) + Convert.ToDecimal(e.Row.Cells(4).Text) + Convert.ToDecimal(e.Row.Cells(5).Text) + Convert.ToDecimal(e.Row.Cells(6).Text) + Convert.ToDecimal(e.Row.Cells(7).Text) + Convert.ToDecimal(e.Row.Cells(8).Text) + Convert.ToDecimal(e.Row.Cells(9).Text) + Convert.ToDecimal(e.Row.Cells(10).Text) + Convert.ToDecimal(e.Row.Cells(11).Text) + Convert.ToDecimal(e.Row.Cells(12).Text)
            e.Row.Cells(13).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2, , , TriState.True)
        End If

    End Sub
End Class

