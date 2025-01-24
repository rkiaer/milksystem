Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Math


Partial Class lst_relatorio_central_KPI
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        btn_exportar.Visible = True

        If Not (txt_data_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = "01/" + txt_data_inicio.Text.Trim()
            ViewState.Item("dt_fim") = "01/" + txt_data_fim.Text.Trim()
        Else
            ViewState.Item("dt_inicio") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        End If

        If Not (Me.hf_id_item.Value.Equals(String.Empty)) Then
            ViewState.Item("id_item") = Me.hf_id_item.Value
        Else
            ViewState.Item("id_item") = String.Empty
        End If
        ViewState.Item("cd_item") = Me.txt_cd_item.Text.Trim()
        ViewState.Item("nm_item") = Me.lbl_nm_item.Text.Trim()

        ViewState.Item("id_categoria") = cbo_categoria.SelectedValue.ToString
        ViewState.Item("id_canal") = cbo_canal.SelectedValue.ToString

        If Not (Me.hf_id_produtor.Value.Equals(String.Empty)) Then
            ViewState.Item("id_produtor") = Me.hf_id_produtor.Value
        Else
            ViewState.Item("id_produtor") = String.Empty
        End If
        ViewState.Item("cd_produtor") = Me.txt_cd_produtor.Text.Trim()
        ViewState.Item("nm_produtor") = Me.lbl_nm_produtor.Text.Trim()

        If Not (Me.hf_id_fornecedor.Value.Equals(String.Empty)) Then
            ViewState.Item("id_fornecedor") = Me.hf_id_fornecedor.Value
        Else
            ViewState.Item("id_fornecedor") = String.Empty
        End If
        ViewState.Item("cd_fornecedor") = Me.txt_cd_fornecedor.Text.Trim()
        ViewState.Item("nm_fornecedor") = Me.lbl_nm_fornecedor.Text.Trim()

        ViewState.Item("cbo_referencia") = cbo_referencia.SelectedValue.ToString
        ViewState.Item("cbo_exibir_kpi_tipo") = cbo_exibir_kpi_tipo.SelectedValue.ToString


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_relatorio_central_KPI.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_central_KPI.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 153
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If

        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtor"
        End With

        With btn_lupa_item
            .Attributes.Add("onclick", "javascript:ShowDialogItem()")
            .ToolTip = "Filtrar Itens"
            '.Style("cursor") = "hand"
        End With

        With img_lupa_fornecedor
            .Attributes.Add("onclick", "javascript:ShowDialogFornecedor()")
            .ToolTip = "Filtrar Parceiros"
            '.Style("cursor") = "hand"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim canal As New Canal
            cbo_canal.DataSource = canal.getCanalByFilters
            cbo_canal.DataTextField = "nm_canal"
            cbo_canal.DataValueField = "id_canal"
            cbo_canal.DataBind()
            cbo_canal.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim categoria As New CategoriaItem()
            cbo_categoria.DataSource = categoria.getCategoriaItemByFilters
            cbo_categoria.DataTextField = "nm_categoria_item"
            cbo_categoria.DataValueField = "id_categoria_item"
            cbo_categoria.DataBind()
            cbo_categoria.Items.Insert(0, New ListItem("[Selecione]", String.Empty))



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim pedido As New Pedido
            Dim dscentralKPI As DataSet

            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                pedido.dt_inicio = ViewState.Item("dt_inicio")
                pedido.dt_fim = ViewState.Item("dt_fim")
            End If
            If Not (ViewState("id_item").ToString().Equals(String.Empty)) Then
                pedido.id_item = Convert.ToInt32(ViewState.Item("id_item"))
            End If
            If Not (ViewState("id_categoria").ToString().Equals(String.Empty)) Then
                pedido.id_categoria_item = Convert.ToInt32(ViewState.Item("id_categoria"))
            End If
            If Not (ViewState("id_canal").ToString().Equals(String.Empty)) Then
                pedido.id_canal = Convert.ToInt32(ViewState.Item("id_canal"))
            End If
            If Not (ViewState("id_produtor").ToString().Equals(String.Empty)) Then
                pedido.id_produtor = Convert.ToInt32(ViewState.Item("id_produtor"))
            End If
            If Not (ViewState("id_fornecedor").ToString().Equals(String.Empty)) Then
                pedido.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor"))
            End If

            If ViewState.Item("cbo_referencia").ToString.Equals("P") Then 'se deve exibir por periodo

                Select Case ViewState.Item("cbo_exibir_kpi_tipo").ToString
                    Case "I" 'Exibir apenas itens
                        dscentralKPI = pedido.getRelatorioKPI_ItensPeriodo
                    Case "F" 'Exibir por parceiro
                        dscentralKPI = pedido.getRelatorioKPI_FornecedorItensPeriodo
                    Case "P" 'Exibir por produtor
                        dscentralKPI = pedido.getRelatorioKPI_ProdutorItensPeriodo
                End Select
            Else 'se por referencia
                Select Case ViewState.Item("cbo_exibir_kpi_tipo").ToString
                    Case "I" 'Exibir apenas itens
                        dscentralKPI = pedido.getRelatorioKPI_ItensReferencia
                    Case "F" 'Exibir por parceiro
                        dscentralKPI = pedido.getRelatorioKPI_FornecedorItensReferencia
                    Case "P" 'Exibir por produtor
                        dscentralKPI = pedido.getRelatorioKPI_ProdutorItensReferencia
                End Select
            End If

            If (dscentralKPI.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                Select Case ViewState.Item("cbo_exibir_kpi_tipo").ToString
                    Case "I" 'Exibir apenas itens
                        gridResults.Columns.Item(1).Visible = False 'produtor
                        'gridResults.Columns.Item(13).Visible = False 'idprodutor
                        gridResults.Columns.Item(2).Visible = False 'parceiro
                        'gridResults.Columns.Item(12).Visible = False 'idparceiro
                    Case "F" 'Exibir por parceiro
                        gridResults.Columns.Item(1).Visible = False 'produtor
                        'gridResults.Columns.Item(13).Visible = False 'idprodutor
                        gridResults.Columns.Item(2).Visible = True 'parceiro
                        'gridResults.Columns.Item(12).Visible = True 'idparceiro
                    Case "P" 'Exibir por produtor
                        gridResults.Columns.Item(1).Visible = True 'produtor
                        'gridResults.Columns.Item(13).Visible = True 'idprodutor
                        gridResults.Columns.Item(2).Visible = True 'parceiro
                        'gridResults.Columns.Item(12).Visible = True 'idparceiro
                End Select

                gridResults.DataSource = Helper.getDataView(dscentralKPI.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            'Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_central_relacao_produtores.aspx?dt_inicio={0}", ViewState.Item("dt_inicio").ToString) & String.Format("&dt_fim={0}", ViewState.Item("dt_fim").ToString) & String.Format("&id_estabelecimento={0}", ViewState.Item("id_estabelecimento").ToString) & String.Format("&id_pessoa={0}", ViewState.Item("id_pessoa").ToString) & String.Format("&cbo_tipo={0}", ViewState.Item("cbo_tipo").ToString)

            'Me.hl_imprimir.Enabled = True

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
         And e.Row.RowType <> DataControlRowType.Footer _
         And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_id_item As Label = CType(e.Row.FindControl("lbl_id_item"), Label)
            Dim lbl_id_fornecedor As Label = CType(e.Row.FindControl("lbl_id_fornecedor"), Label)
            Dim lbl_id_produtor As Label = CType(e.Row.FindControl("lbl_id_produtor"), Label)
            Dim lbl_nr_quantidade As Label = CType(e.Row.FindControl("lbl_nr_quantidade"), Label)
            Dim lbl_nr_valor_nf As Label = CType(e.Row.FindControl("lbl_nr_valor_nf"), Label)
            Dim lbl_nr_frete As Label = CType(e.Row.FindControl("lbl_nr_frete"), Label)
            Dim lbl_nr_valor_cif As Label = CType(e.Row.FindControl("lbl_nr_valor_cif"), Label)

            If ViewState.Item("cbo_referencia").Equals("R") Then 'Se for referencia
                e.Row.Cells(0).Text = Mid(e.Row.Cells(0).Text, 4, 7) 'referencia
            End If

            Dim relatorioKPI As New Pedido

            relatorioKPI.dt_inicio = ViewState.Item("dt_inicio").ToString
            relatorioKPI.dt_fim = ViewState.Item("dt_fim").ToString
            relatorioKPI.id_item = lbl_id_item.Text

            If ViewState.Item("cbo_exibir_kpi_tipo").ToString.Equals("F") Then
                relatorioKPI.id_fornecedor = lbl_id_fornecedor.Text
            End If
            If ViewState.Item("cbo_exibir_kpi_tipo").ToString.Equals("P") Then
                relatorioKPI.id_fornecedor = lbl_id_fornecedor.Text
                relatorioKPI.id_produtor = lbl_id_produtor.Text
            End If

            'total quantidade
            lbl_nr_quantidade.Text = Round(relatorioKPI.getRelatorioKPI_ValorQtde, 2).ToString

            'valor frete 
            lbl_nr_frete.Text = Round(relatorioKPI.getRelatorioKPI_ValorFrete, 2).ToString

            'valor cif
            lbl_nr_valor_cif.Text = CDec(lbl_nr_valor_nf.Text) + CDec(lbl_nr_frete.Text)

        End If
        If (e.Row.RowType = DataControlRowType.Footer) Then

            Dim pedido As New Pedido

            pedido.dt_inicio = ViewState.Item("dt_inicio")
            pedido.dt_fim = ViewState.Item("dt_fim")

            If Not (ViewState("id_item").ToString().Equals(String.Empty)) Then
                pedido.id_item = Convert.ToInt32(ViewState.Item("id_item"))
            End If
            If Not (ViewState("id_categoria").ToString().Equals(String.Empty)) Then
                pedido.id_categoria_item = Convert.ToInt32(ViewState.Item("id_categoria"))
            End If
            If Not (ViewState("id_canal").ToString().Equals(String.Empty)) Then
                pedido.id_canal = Convert.ToInt32(ViewState.Item("id_canal"))
            End If
            If Not (ViewState("id_produtor").ToString().Equals(String.Empty)) Then
                pedido.id_produtor = Convert.ToInt32(ViewState.Item("id_produtor"))
            End If
            If Not (ViewState("id_fornecedor").ToString().Equals(String.Empty)) Then
                pedido.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor"))
            End If

            e.Row.Cells(5).Text = "Total"
            e.Row.Cells(6).Text = Round(pedido.getRelatorioKPI_ValorQtde, 2).ToString
            e.Row.Cells(8).Text = Round(pedido.getRelatorioKPI_ValorNota, 2).ToString
            e.Row.Cells(9).Text = Round(pedido.getRelatorioKPI_ValorFrete, 2).ToString
            e.Row.Cells(10).Text = CDec(e.Row.Cells(8).Text) + CDec(e.Row.Cells(9).Text)
        End If
    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "cd_pessoa"
                If (ViewState.Item("sortExpression")) = "cd_pessoa asc" Then
                    ViewState.Item("sortExpression") = "cd_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "cd_pessoa asc"
                End If
            Case "nm_pessoa"
                If (ViewState.Item("sortExpression")) = "nm_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_pessoa asc"
                End If
            Case "nm_abreviado"
                If (ViewState.Item("sortExpression")) = "nm_abreviado asc" Then
                    ViewState.Item("sortExpression") = "nm_abreviado desc"
                Else
                    ViewState.Item("sortExpression") = "nm_abreviado asc"
                End If
            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If
            Case "dt_referencia"
                If (ViewState.Item("sortExpression")) = "dt_referencia asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia asc"
                End If

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
        Dim data_fim As String
        If Not (txt_data_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = "01/" + txt_data_inicio.Text.Trim()
            ViewState.Item("dt_fim") = "01/" + txt_data_fim.Text.Trim()
        Else
            ViewState.Item("dt_inicio") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        End If

        If Not (Me.hf_id_item.Value.Equals(String.Empty)) Then
            ViewState.Item("id_item") = Me.hf_id_item.Value
        Else
            ViewState.Item("id_item") = String.Empty
        End If
        ViewState.Item("cd_item") = Me.txt_cd_item.Text.Trim()
        ViewState.Item("nm_item") = Me.lbl_nm_item.Text.Trim()

        ViewState.Item("id_categoria") = cbo_categoria.SelectedValue.ToString
        ViewState.Item("id_canal") = cbo_canal.SelectedValue.ToString

        If Not (Me.hf_id_produtor.Value.Equals(String.Empty)) Then
            ViewState.Item("id_produtor") = Me.hf_id_produtor.Value
        Else
            ViewState.Item("id_produtor") = String.Empty
        End If
        ViewState.Item("cd_produtor") = Me.txt_cd_produtor.Text.Trim()
        ViewState.Item("nm_produtor") = Me.lbl_nm_produtor.Text.Trim()

        If Not (Me.hf_id_fornecedor.Value.Equals(String.Empty)) Then
            ViewState.Item("id_fornecedor") = Me.hf_id_fornecedor.Value
        Else
            ViewState.Item("id_fornecedor") = String.Empty
        End If
        ViewState.Item("cd_fornecedor") = Me.txt_cd_fornecedor.Text.Trim()
        ViewState.Item("nm_fornecedor") = Me.lbl_nm_fornecedor.Text.Trim()

        ViewState.Item("cbo_referencia") = cbo_referencia.SelectedValue.ToString
        ViewState.Item("cbo_exibir_kpi_tipo") = cbo_exibir_kpi_tipo.SelectedValue.ToString

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 153
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        loadData()

        Response.Redirect("frm_relatorio_central_KPI_excel.aspx?id_item=" + ViewState.Item("id_item").ToString + "&id_produtor=" + ViewState.Item("id_produtor").ToString + "&id_fornecedor=" + ViewState.Item("id_fornecedor").ToString + "&id_categoria=" + ViewState.Item("id_categoria").ToString + "&id_canal=" + ViewState.Item("id_canal").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&cbo_referencia=" + ViewState.Item("cbo_referencia").ToString + "&cbo_exibir_kpi_tipo=" + ViewState.Item("cbo_exibir_kpi_tipo").ToString)


    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        carregarCamposprodutor()
    End Sub
    Private Sub carregarCamposprodutor()
        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                lbl_nm_produtor.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                txt_cd_produtor.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If
            Me.ViewState.Item("id_pessoa") = hf_id_produtor.Value
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub txt_cd_produtor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_produtor.TextChanged

        ' Fran 05/05/2010 - i
        lbl_nm_produtor.Text = String.Empty
        hf_id_produtor.Value = String.Empty
        Try
            If Not txt_cd_produtor.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.id_grupo = 1  ' Somente produtores
                produtor.cd_pessoa = Me.txt_cd_produtor.Text.Trim
                produtor.id_situacao = 1
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_produtor.Enabled = True
                    lbl_nm_produtor.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_produtor.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' Fran 05/05/2010 - f

    End Sub

   

    Protected Sub txt_cd_fornecedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_fornecedor.TextChanged
        lbl_nm_fornecedor.Text = String.Empty
        hf_id_fornecedor.Value = String.Empty
        Try
            If Not txt_cd_fornecedor.Text.Equals(String.Empty) Then
                Dim fornecedor As New Pessoa
                fornecedor.cd_pessoa = Me.txt_cd_fornecedor.Text.Trim
                fornecedor.id_situacao = 1
                Dim dsfornecedor As DataSet = fornecedor.getFornecedorByFilters
                'se encontrou 
                If dsfornecedor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_fornecedor.Enabled = True
                    lbl_nm_fornecedor.Text = dsfornecedor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_fornecedor.Value = dsfornecedor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub img_lupa_fornecedor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_fornecedor.Click
        carregarCamposfornecedor()

    End Sub
    Private Sub carregarCamposfornecedor()
        Try

            If Not (customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").Equals(String.Empty)) Then
                lbl_nm_fornecedor.Text = customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").Equals(String.Empty)) Then
                txt_cd_fornecedor.Text = customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").ToString
            End If
            Me.ViewState.Item("id_fornecedor") = hf_id_fornecedor.Value
            customPage.clearFilters("lupa_fornecedor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub txt_cd_item_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_item.TextChanged
        lbl_nm_item.Text = String.Empty
        hf_id_item.Value = String.Empty
        Try
            If Not txt_cd_item.Text.ToString.Equals(String.Empty) Then 'fran 05/05/2010
                Dim item As New Item
                item.cd_item = txt_cd_item.Text.Trim
                Dim dsitem As DataSet = item.getItensCentralByFilters
                If dsitem.Tables(0).Rows.Count > 0 Then
                    lbl_nm_item.Enabled = True
                    lbl_nm_item.Text = dsitem.Tables(0).Rows(0).Item("nm_item")
                    hf_id_item.Value = dsitem.Tables(0).Rows(0).Item("id_item").ToString

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub btn_lupa_item_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_item.Click
        Me.lbl_nm_item.Visible = True
        carregarCamposItem()
    End Sub
    Private Sub carregarcampositem()
        Try

            If Not (customPage.getFilterValue("lupa_item", "id_item").Equals(String.Empty)) Then
                ViewState.Item("id_item") = customPage.getFilterValue("lupa_item", "id_item").ToString
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

    Protected Sub cbo_exibir_kpi_tipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_exibir_kpi_tipo.SelectedIndexChanged
        Select Case cbo_exibir_kpi_tipo.SelectedValue
            Case "I"
                txt_cd_produtor.Text = String.Empty
                lbl_nm_produtor.Text = String.Empty
                txt_cd_produtor.Enabled = False
                img_lupa_produtor.Enabled = False

                txt_cd_fornecedor.Text = String.Empty
                lbl_nm_fornecedor.Text = String.Empty
                txt_cd_fornecedor.Enabled = False
                img_lupa_fornecedor.Enabled = False

            Case "F"
                txt_cd_produtor.Text = String.Empty
                lbl_nm_produtor.Text = String.Empty
                txt_cd_produtor.Enabled = False
                img_lupa_produtor.Enabled = False

                txt_cd_fornecedor.Text = String.Empty
                lbl_nm_fornecedor.Text = String.Empty
                txt_cd_fornecedor.Enabled = True
                img_lupa_fornecedor.Enabled = True

            Case "P"
                txt_cd_produtor.Text = String.Empty
                lbl_nm_produtor.Text = String.Empty
                txt_cd_produtor.Enabled = True
                img_lupa_produtor.Enabled = True

                txt_cd_fornecedor.Text = String.Empty
                lbl_nm_fornecedor.Text = String.Empty
                txt_cd_fornecedor.Enabled = False
                img_lupa_fornecedor.Enabled = False


        End Select

    End Sub

    Protected Sub cv_dtini_fim_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_dtini_fim.ServerValidate
        Try
            Dim lmsg As String

            args.IsValid = True
            If (CDate("01/" & Me.txt_data_inicio.Text) > CDate("01/" & txt_data_fim.Text)) Then
                args.IsValid = False
                lmsg = "A Data Inicial do Período não pode ser maior que a Data Fim."
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class

