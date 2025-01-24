Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_central_tabela_precos
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()

        If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
            ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        Else
            ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        End If

        ' 06/11/2009 - i
        If Not (Me.hf_id_item.Value.Equals(String.Empty)) Then
            ViewState.Item("id_item") = Me.hf_id_item.Value
        Else
            ViewState.Item("id_item") = Me.hf_id_item.Value
        End If

        If Not (Me.txt_cd_item.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_item") = Me.txt_cd_item.Text.Trim()
        Else
            ViewState.Item("cd_item") = String.Empty
        End If
        ' 06/11/2009 - f

        ViewState.Item("dt_inicio") = Me.txt_dt_inicio.Text.Trim
        If txt_dt_fim.Text.Trim.Equals(String.Empty) Then
            txt_dt_fim.Text = ViewState.Item("dt_inicio")
        End If
        ViewState.Item("dt_fim") = Me.txt_dt_fim.Text.Trim

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_tabela_precos.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_tabela_precos.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 88
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With img_lupa_fornecedor
            .Attributes.Add("onclick", "javascript:ShowDialogFornecedor()")
            .ToolTip = "Filtrar Fornecedores"
        End With

        With img_lupa_item
            .Attributes.Add("onclick", "javascript:ShowDialogItem()")
            .ToolTip = "Filtrar Itens"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = "cd_fornecedor desc ,  dt_cotacao desc"  ' 25/01/2010 - chamado 556

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("tabelaprecos", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("tabelaprecos", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("tabelaprecos", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("tabelaprecos", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("tabelaprecos", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("tabelaprecos", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        ' 06/11/2009 - i
        If Not (customPage.getFilterValue("tabelaprecos", txt_cd_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_item") = customPage.getFilterValue("tabelaprecos", txt_cd_item.ID)
            txt_cd_item.Text = ViewState.Item("cd_item").ToString()
        Else
            ViewState.Item("cd_item") = String.Empty
        End If

        If Not (customPage.getFilterValue("tabelaprecos", hf_id_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_item") = customPage.getFilterValue("tabelaprecos", hf_id_item.ID)
            hf_id_item.Value = ViewState.Item("id_item").ToString()
        Else
            ViewState.Item("id_item") = String.Empty
            hf_id_item.Value = String.Empty
        End If
        ' 06/11/2009 - f

        If Not (customPage.getFilterValue("tabelaprecos", lbl_nm_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_item") = customPage.getFilterValue("tabelaprecos", lbl_nm_item.ID)
            lbl_nm_item.Text = ViewState.Item("nm_item").ToString()
            lbl_nm_item.Visible = True ' 06/11/2009
        Else
            ViewState.Item("nm_item") = String.Empty
        End If

        If Not (customPage.getFilterValue("tabelaprecos", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("tabelaprecos", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("tabelaprecos", txt_dt_inicio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_inicio") = customPage.getFilterValue("tabelaprecos", txt_dt_inicio.ID)
            txt_dt_inicio.Text = ViewState.Item("dt_inicio").ToString()
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If

        If Not (customPage.getFilterValue("tabelaprecos", txt_dt_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_fim") = customPage.getFilterValue("tabelaprecos", txt_dt_fim.ID)
            txt_dt_fim.Text = ViewState.Item("dt_fim").ToString()
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If


        If Not (customPage.getFilterValue("tabelaprecos", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("tabelaprecos", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("tabelaprecos")
        End If

    End Sub

    Private Sub loadData()

        Try

            '' Monta dados de contato do Parceiro Central
            'If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then  ' Se informou o Parceiro Central
            '    Dim pessoa As New Pessoa(Convert.ToInt32(ViewState.Item("id_pessoa").ToString))
            '    lbl_telefone.Text = "Telefone " & pessoa.ds_telefone_1
            '    lbl_fax.Text = "FAX " & pessoa.ds_telefone_3
            '    lbl_email.Text = "Email " & pessoa.ds_email

            '    lbl_telefone.Visible = True
            '    lbl_fax.Visible = True
            '    lbl_email.Visible = True
            'End If


            Dim tabelaprecos As New TabelaPrecos

            If Not (ViewState.Item("id_estabelecimento").Equals(String.Empty)) Then
                tabelaprecos.id_estabelecimento = ViewState.Item("id_estabelecimento")
            End If

            If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                tabelaprecos.id_fornecedor = ViewState.Item("id_pessoa")
            End If

            If Not (ViewState.Item("id_item").Equals(String.Empty)) Then
                tabelaprecos.id_item = ViewState.Item("id_item")
            End If

            If Not (ViewState.Item("dt_inicio").Equals(String.Empty)) Then
                tabelaprecos.dt_inicio = ViewState.Item("dt_inicio")
            End If

            If Not (ViewState.Item("dt_fim").Equals(String.Empty)) Then
                tabelaprecos.dt_fim = ViewState.Item("dt_fim")
            End If

            ' adri 26/01/2010 - chamado 556 - i
            tabelaprecos.cd_item = ViewState.Item("cd_item")
            tabelaprecos.cd_fornecedor = ViewState.Item("cd_pessoa")
            ' adri 26/01/2010 - chamado 556 - f

            tabelaprecos.id_situacao = 1 'listar ativos

            Dim dsTabelaPrecos As DataSet = tabelaprecos.getCentralTabelaPrecosByFilters()

            If (dsTabelaPrecos.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsTabelaPrecos.Tables(0), ViewState.Item("sortExpression"))
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


            Case "cd_fornecedor"
                If (ViewState.Item("sortExpression")) = "cd_fornecedor asc" Then
                    ViewState.Item("sortExpression") = "cd_fornecedor desc"
                Else
                    ViewState.Item("sortExpression") = "cd_fornecedor asc"
                End If

            Case "nm_fornecedor"
                If (ViewState.Item("sortExpression")) = "nm_fornecedor asc" Then
                    ViewState.Item("sortExpression") = "nm_fornecedor desc"
                Else
                    ViewState.Item("sortExpression") = "nm_fornecedor asc"
                End If
                'Modificado 06/11/2009 - Denise i. 

                'Case "id_item"
                '    If (ViewState.Item("sortExpression")) = "id_item asc" Then
                '        ViewState.Item("sortExpression") = "id_item desc"
                '    Else
                '        ViewState.Item("sortExpression") = "id_item asc"
                '    End If

            Case "cd_item"
                If (ViewState.Item("sortExpression")) = "cd_item asc" Then
                    ViewState.Item("sortExpression") = "cd_item desc"
                Else
                    ViewState.Item("sortExpression") = "cd_item asc"
                End If
                'Modificado 06/11/2009 - Denise f. 

            Case "nm_item"
                If (ViewState.Item("sortExpression")) = "nm_item asc" Then
                    ViewState.Item("sortExpression") = "nm_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_item asc"
                End If

            Case "dt_cotacao"
                If (ViewState.Item("sortExpression")) = "dt_cotacao asc" Then
                    ViewState.Item("sortExpression") = "dt_cotacao desc"
                Else
                    ViewState.Item("sortExpression") = "dt_cotacao asc"
                End If

            Case "nr_volume_ate"    ' Adri - 25/01/2010 - chamdo 556
                If (ViewState.Item("sortExpression")) = "nr_volume_ate asc" Then
                    ViewState.Item("sortExpression") = "nr_volume_ate desc"
                Else
                    ViewState.Item("sortExpression") = "nr_volume_ate asc"
                End If

        End Select

        loadData()

    End Sub
    Private Sub carregarCamposFornecedor()

        Try

            If Not (customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_fornecedor", "ds_telefone_1").Equals(String.Empty)) Then
                Me.lbl_telefone.Text = customPage.getFilterValue("lupa_fornecedor", "ds_telefone_1").ToString
            End If

            If Not (customPage.getFilterValue("lupa_fornecedor", "ds_telefone_3").Equals(String.Empty)) Then
                Me.lbl_fax.Text = customPage.getFilterValue("lupa_fornecedor", "ds_telefone_3").ToString
            End If

            If Not (customPage.getFilterValue("lupa_fornecedor", "ds_email").Equals(String.Empty)) Then
                Me.lbl_email.Text = customPage.getFilterValue("lupa_fornecedor", "ds_email").ToString
            End If

            If Not (customPage.getFilterValue("lupa_fornecedor", "ds_contato").Equals(String.Empty)) Then
                Me.lbl_contato.Text = customPage.getFilterValue("lupa_fornecedor", "ds_contato").ToString
            End If

            customPage.clearFilters("lupa_fornecedor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposItem()

        Try

            'Me.txt_cd_item.Text = hf_id_item.Value  ' 06/12/2009

            If Not (customPage.getFilterValue("lupa_item", "nm_item").Equals(String.Empty)) Then
                Me.lbl_nm_item.Text = customPage.getFilterValue("lupa_item", "nm_item").ToString
            End If

            If Not (customPage.getFilterValue("lupa_item", "cd_item").Equals(String.Empty)) Then  ' 06/12/2009
                'Me.txt_cd_item.Text = customPage.getFilterValue("lupa_item", "id_item").ToString
                Me.txt_cd_item.Text = customPage.getFilterValue("lupa_item", "cd_item").ToString ' 06/12/2009
            End If

 
            customPage.clearFilters("lupa_item")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("tabelaprecos", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("tabelaprecos", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("tabelaprecos", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("tabelaprecos", txt_cd_item.ID, ViewState.Item("cd_item").ToString) ' 06/11/2009
            customPage.setFilter("tabelaprecos", hf_id_item.ID, ViewState.Item("id_item").ToString)  ' 06/11/2009
            customPage.setFilter("tabelaprecos", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("tabelaprecos", lbl_nm_item.ID, lbl_nm_item.Text) ' 06/11/2009
            customPage.setFilter("tabelaprecos", txt_dt_inicio.ID, ViewState.Item("dt_inicio").ToString)
            customPage.setFilter("tabelaprecos", txt_dt_fim.ID, ViewState.Item("dt_fim").ToString)
            customPage.setFilter("tabelaprecos", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_central_tabela_precos.aspx?id_central_tabela_precos=" + e.CommandArgument.ToString())

            Case "delete"
                deleteTabelaPrecos(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteTabelaPrecos(ByVal id_central_tabela_precos As Integer)

        Try
            Dim tabelaprecos As New TabelaPrecos()
            tabelaprecos.id_central_tabela_precos = id_central_tabela_precos
            tabelaprecos.id_modificador = Convert.ToInt32(Session("id_login"))
            tabelaprecos.deleteCentralTabelaPrecos()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 88
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro excluído com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then


            e.Row.Cells(12).Text = FormatNumber(e.Row.Cells(12).Text, 2)

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        Me.lbl_nm_pessoa.Text = ""
        Me.txt_cd_pessoa.Text = ""
        Me.hf_id_pessoa.Value = ""
        Me.lbl_nm_pessoa.Visible = False

        lbl_telefone.Text = ""
        lbl_fax.Text = ""
        lbl_email.Text = ""
        lbl_telefone.Visible = False
        lbl_fax.Visible = False
        lbl_email.Visible = False

    End Sub

    Protected Sub img_lupa_fornecedor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_fornecedor.Click
        'If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposFornecedor()
        'End If
    End Sub
    Protected Sub img_lupa_item_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_item.Click
        Me.lbl_nm_item.Visible = True
        carregarCamposItem()
    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        'lbl_nm_pessoa.Text = String.Empty
        'lbl_nm_pessoa.Visible = False
        'hf_id_pessoa.Value = String.Empty

        'lbl_telefone.Text = ""
        'lbl_fax.Text = ""
        'lbl_email.Text = ""
        'lbl_telefone.Visible = False
        'lbl_fax.Visible = False
        'lbl_email.Visible = False

        ' Adri 04/05/2010 - i
        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty
        lbl_contato.Text = String.Empty
        lbl_telefone.Text = String.Empty
        lbl_email.Text = String.Empty
        lbl_fax.Text = String.Empty
        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then

                Dim fornecedor As New Pessoa
                fornecedor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                fornecedor.id_situacao = 1
                Dim dsfornecedor As DataSet = fornecedor.getFornecedorByFilters
                'se encontrou produtor
                If dsfornecedor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsfornecedor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsfornecedor.Tables(0).Rows(0).Item("id_pessoa")
                    lbl_contato.Text = dsfornecedor.Tables(0).Rows(0).Item("ds_contato")
                    lbl_telefone.Text = dsfornecedor.Tables(0).Rows(0).Item("ds_telefone_1")
                    lbl_email.Text = dsfornecedor.Tables(0).Rows(0).Item("ds_email")
                    lbl_fax.Text = dsfornecedor.Tables(0).Rows(0).Item("ds_telefone_3")

                Else
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = String.Empty

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' Adri 04/05/2010 - f


    End Sub

    Protected Sub cmv_parceiro_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)

    End Sub



    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_central_tabela_precos.aspx")
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

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()

        If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
            ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        Else
            ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        End If

        If Not (Me.hf_id_item.Value.Equals(String.Empty)) Then
            ViewState.Item("id_item") = Me.hf_id_item.Value
        Else
            ViewState.Item("id_item") = Me.hf_id_item.Value
        End If

        If Not (Me.txt_cd_item.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_item") = Me.txt_cd_item.Text.Trim()
        Else
            ViewState.Item("cd_item") = String.Empty
        End If

        ViewState.Item("dt_inicio") = Me.txt_dt_inicio.Text.Trim
        If txt_dt_fim.Text.Trim.Equals(String.Empty) Then
            txt_dt_fim.Text = ViewState.Item("dt_inicio")
        End If
        ViewState.Item("dt_fim") = Me.txt_dt_fim.Text.Trim

        loadData()

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 88
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        Response.Redirect("frm_central_tabela_precos_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&cd_pessoa=" + ViewState.Item("cd_pessoa").ToString + "&id_item=" + ViewState.Item("id_item").ToString + "&cd_item=" + ViewState.Item("cd_item").ToString)


    End Sub
End Class
