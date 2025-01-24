Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_central_item_parceiro
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_central_itens_parceiro.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_parceiro
            .Attributes.Add("onclick", "javascript:ShowDialogFornecedor()")
            .ToolTip = "Filtrar Parceiros"
            '.Style("cursor") = "hand"
        End With

        ' Adri 05/11/2009 - i
        'With img_lupa_item
        '    .Attributes.Add("onclick", "javascript:ShowDialogItem()")
        '    .ToolTip = "Filtrar Item"
        'End With
        ' Adri 05/11/2009 - f
    End Sub

    Private Sub loadDetails()

        Try

            ' 05/11/2009 Adri - i
            If Not (Request("id_item") Is Nothing) Then
                ViewState.Item("id_item") = Request("id_item")
            End If
            ' 05/11/2009 Adri - f

            ViewState.Item("sortExpression") = "nm_abreviado asc"  ' 19/01/2010 - Chamado 598

            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            ' Adri 05/11/2009 - Carrega dados do item - i
            Dim item As New Item(Convert.ToInt32(ViewState.Item("id_item")))
            Me.lbl_cd_item.Text = item.cd_item
            Me.lbl_ds_item.Text = item.nm_item
            Me.lbl_unidade_medida.Text = item.cd_unidade_medida
            ' Adri 05/11/2009 - Carrega dados do item - f

            'Fran chamado 903 - não há mais grid de parceiro i
            ''Carrega grid das propriedades
            'Dim pessoa As New Pessoa
            'Dim dspessoa As DataSet = pessoa.getFornecedorByFilters

            'If (dspessoa.Tables(0).Rows.Count > 0) Then
            '    gridparceiro.Visible = True
            '    gridparceiro.DataSource = Helper.getDataView(dspessoa.Tables(0), ViewState.Item("sortExpression"))
            '    gridparceiro.DataBind()

            '    ' Adri 05/11/2009 - i
            '    'btn_adicionar.Enabled = True
            '    loadParceiro()
            '    ' Adri 05/11/2009 - f

            'Else
            '    gridparceiro.Visible = False
            '    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            'End If
            loadParceiro()
            'Fran chamado 903 - não há mais grid de parceiro f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    'Fran chamado 903 - não há mais grid de parceiro
    'Protected Sub gridpropriedade_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridparceiro.PageIndexChanging
    '    gridparceiro.PageIndex = e.NewPageIndex
    '    Me.loadData()
    'End Sub

    'Protected Sub gridparceiro_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridparceiro.PageIndexChanging
    '    gridparceiro.PageIndex = e.NewPageIndex
    '    Me.loadParceiro()
    'End Sub
    'Fran chamado 903 - não há mais grid de parceiro f

    Protected Sub gridparceiro_item_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridparceiro_item.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Delete"

                Dim itemparceiro As New ItemParceiro(Convert.ToInt32(e.CommandArgument.ToString()))
                ' Adri 05/11/2009 - i
                'itemparceiro.id_situacao = 2
                'itemparceiro.updateparceiro_itens()
                itemparceiro.deleteparceiro_itens()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 5 'delete
                usuariolog.ds_nm_processo = "Item x Parceiros"
                usuariolog.id_nr_processo = e.CommandArgument.ToString

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                ' Adri 05/11/2009 - f
                loadParceiro()

        End Select
    End Sub
    Protected Sub gridparceiro_item_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridparceiro_item.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            Dim cbo_unidade_medida As DropDownList = CType(e.Row.FindControl("cbo_unidade_medida"), DropDownList)
            Dim unidademedida As New UnidadeMedida

            cbo_unidade_medida.DataSource = unidademedida.getunidade_medidaByfilters
            cbo_unidade_medida.DataTextField = "ds_unidade_medida"
            cbo_unidade_medida.DataValueField = "id_unidade_medida"
            cbo_unidade_medida.DataBind()

        End If

    End Sub

    Protected Sub gridparceiro_item_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridparceiro_item.PageIndexChanging
        gridparceiro_item.PageIndex = e.NewPageIndex
        loadData()
    End Sub


    Protected Sub gridparceiro_item_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridparceiro_item.RowCancelingEdit
        Try

            gridparceiro_item.EditIndex = -1
            loadParceiro()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridparceiro_item_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridparceiro_item.RowEditing
        Try
            gridparceiro_item.EditIndex = e.NewEditIndex
            loadParceiro()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    ' Adri 05/11/2009 - i
    'Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

    '    ViewState.Item("cd_item") = txt_cd_item.Text
    '    btn_adicionar.Enabled = True
    '    loadParceiro()

    'End Sub
    ' Adri 05/11/2009 - f
    Private Sub loadParceiro()
        Try
            Dim itemparceiro As New ItemParceiro

            'itemparceiro.id_item = Convert.ToInt32(ViewState.Item("cd_item").ToString)
            itemparceiro.id_item = Convert.ToInt32(ViewState.Item("id_item").ToString)
            itemparceiro.id_situacao = 1


            Dim dsitemparceiro As DataSet = itemparceiro.getParceiroByFilters


            If (dsitemparceiro.Tables(0).Rows.Count > 0) Then
                gridparceiro_item.Visible = True
                gridparceiro_item.DataSource = Helper.getDataView(dsitemparceiro.Tables(0), ViewState.Item("sortExpressionParceiro"))
                gridparceiro_item.DataBind()
            Else
                gridparceiro_item.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridparceiro_item_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridparceiro_item.RowUpdating
        Dim row As GridViewRow = gridparceiro_item.Rows(e.RowIndex)
        Try

            If (Not (row) Is Nothing) Then

                Dim itemparceiro As New ItemParceiro
                Dim cbo_unidade_medida As DropDownList = CType(row.FindControl("cbo_unidade_medida"), DropDownList)
                Dim txt_lote_minimo As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_lote_minimo"), TextBox)
                Dim txt_lote_multiplo As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_lote_multiplo"), TextBox)
                Dim txt_fator_conversao As TextBox = CType(row.FindControl("txt_fator_conversao"), TextBox)
                Dim txt_decimal As TextBox = CType(row.FindControl("txt_decimal"), TextBox)

                itemparceiro.id_unidade_medida_fornecedor = cbo_unidade_medida.SelectedValue
                itemparceiro.id_central_item_parceiro = gridparceiro_item.DataKeys.Item(e.RowIndex).Value
                itemparceiro.nr_lote_minimo = txt_lote_minimo.Text
                itemparceiro.nr_lote_multiplo = txt_lote_multiplo.Text
                ' Adri 09/02/2010 - i
                'itemparceiro.nr_fator_conversao = txt_fator_conversao.Text
                If txt_fator_conversao.Text = "" Then
                    itemparceiro.nr_fator_conversao = 0
                Else
                    itemparceiro.nr_fator_conversao = txt_fator_conversao.Text
                End If
                'itemparceiro.nr_casas_decimais_conversao = txt_decimal.Text
                If txt_decimal.Text = "" Then
                    itemparceiro.nr_casas_decimais_conversao = 0
                Else
                    itemparceiro.nr_casas_decimais_conversao = txt_decimal.Text
                End If
                ' Adri 09/02/2010 - f
                'itemparceiro.id_item = Convert.ToInt32(ViewState.Item("cd_item"))
                itemparceiro.id_item = Convert.ToInt32(ViewState.Item("id_item"))  ' Adri 05/11/2009
                itemparceiro.id_situacao = 1
                itemparceiro.updateparceiro_itens()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.ds_nm_processo = "Item x Parceiros"
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

            End If

            gridparceiro_item.EditIndex = -1
            loadParceiro()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridparceiro_item_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridparceiro_item.RowDeleting
        e.Cancel = True
    End Sub

    ' Adri 05/11/2009 - i
    'Protected Sub img_lupa_item_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_item.Click
    '    carregarcampositem()
    'End Sub
    'Private Sub carregarcampositem()
    '    Try

    '        If Not (customPage.getFilterValue("lupa_item", "id_item").Equals(String.Empty)) Then
    '            Me.txt_cd_item.Text = customPage.getFilterValue("lupa_item", "id_item").ToString
    '        End If
    '        If Not (customPage.getFilterValue("lupa_item", "nm_item").Equals(String.Empty)) Then
    '            Me.lbl_ds_item.Text = customPage.getFilterValue("lupa_item", "nm_item").ToString
    '        End If
    '        If Not (customPage.getFilterValue("lupa_item", "cd_unidade_medida").Equals(String.Empty)) Then
    '            Me.lbl_unidade_medida.Text = customPage.getFilterValue("lupa_item", "cd_unidade_medida").ToString
    '        End If
    '        customPage.clearFilters("lupa_item")

    '        btn_adicionar.Enabled = False
    '        gridparceiro_item.Visible = False

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
    '    Response.Redirect("frm_central_item_parceiro.aspx")
    'End Sub
    ' Adri 05/11/2009 - f
    'Fran chamado 903 - não há mais grid de parceiro i
    'Private Sub checkitens()
    '    Dim li As Integer
    '    For li = 0 To gridparceiro.Rows.Count - 1
    '        If CType(gridparceiro.HeaderRow.FindControl("chk_todos"), CheckBox).Checked = True Then
    '            CType(gridparceiro.Rows(li).FindControl("chk_parceiro"), CheckBox).Checked = True
    '        Else
    '            CType(gridparceiro.Rows(li).FindControl("chk_parceiro"), CheckBox).Checked = False

    '        End If
    '    Next

    'End Sub
    'Protected Sub chk_todos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    checkitens()
    'End Sub
    'Fran chamado 903 - não há mais grid de parceiro f


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_itens.aspx?id_itens=" + ViewState.Item("id_item").ToString())  ' Adri 05/11/2009 
    End Sub
    'Fran chamado 903 - não há mais grid de parceiro
    'Protected Sub gridparceiro_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridparceiro.RowCommand
    '    Select Case e.CommandName.Trim.ToString
    '        Case "Insert"
    '            Dim item_parceiro As New ItemParceiro
    '            Dim li As Integer = Convert.ToInt32(e.CommandArgument.ToString())
    '            Dim ds_item_parceiro As DataSet

    '            Dim lbl_id_fornecedor As Label = CType(gridparceiro.Rows.Item(li).FindControl("lbl_id_fornecedor"), Label)

    '            'item_parceiro.id_item = Convert.ToInt32(ViewState.Item("cd_item").ToString)
    '            item_parceiro.id_item = Convert.ToInt32(ViewState.Item("id_item").ToString)  ' Adri 05/11/2009
    '            item_parceiro.id_fornecedor = Convert.ToInt32(lbl_id_fornecedor.Text)

    '            ds_item_parceiro = item_parceiro.getParceiroByFilters()

    '            ' Adri 05/11/2009 - Desabilitado (não reaproveitar item excluído) - i
    '            'If ds_item_parceiro.Tables(0).Rows.Count > 0 Then  ' Se fornecedor já foi incluído
    '            '    ViewState.Item("id_central_item_parceiro") = ds_item_parceiro.Tables(0).Rows(0).Item("id_central_item_parceiro")
    '            'End If

    '            'If ViewState.Item("id_central_item_parceiro") <> 0 Then
    '            '    Dim item_parceiros As New ItemParceiro(Convert.ToInt32(ViewState.Item("id_central_item_parceiro")))
    '            '    item_parceiros.id_unidade_medida_fornecedor = 0
    '            '    item_parceiros.nr_lote_minimo = 0
    '            '    item_parceiros.nr_lote_multiplo = 0
    '            '    item_parceiros.nr_fator_conversao = 0
    '            '    item_parceiros.nr_casas_decimais_conversao = 0
    '            '    item_parceiros.id_situacao = 1
    '            '    item_parceiros.updateparceiro_itens()
    '            'Else
    '            '    ViewState.Item("id_central_item_parceiro") = item_parceiro.insertparceiro_itens
    '            'End If
    '            ' Adri 05/11/2009 - Desabilitado (não reaproveitar item excluído) - f


    '            If ds_item_parceiro.Tables(0).Rows.Count <= 0 Then  ' Se fornecedor ainda não foi incluído
    '                ViewState.Item("id_central_item_parceiro") = item_parceiro.insertparceiro_itens
    '            End If

    '            ds_item_parceiro = Nothing
    '            ViewState.Item("id_central_item_parceiro") = Nothing

    '            loadParceiro()
    '    End Select
    'End Sub

    'Protected Sub gridparceiro_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridparceiro.RowCreated
    '    If (e.Row.RowType = DataControlRowType.DataRow) Then
    '        Dim btn_adicionar As ImageButton = CType(e.Row.FindControl("btn_adicionar"), ImageButton)
    '        btn_adicionar.CommandArgument = e.Row.RowIndex
    '    End If
    'End Sub
    'Protected Sub gridparceiro_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridparceiro.Sorting
    '    Select Case e.SortExpression.ToLower()

    '        ' 19/01/2010 - Chamado 598
    '        Case "nm_abreviado"
    '            If (ViewState.Item("sortExpression")) = "nm_abreviado asc" Then
    '                ViewState.Item("sortExpression") = "nm_abreviado desc"
    '            Else
    '                ViewState.Item("sortExpression") = "nm_abreviado asc"
    '            End If



    '    End Select

    '    loadData()

    'End Sub
    'Fran chamado 903 - não há mais grid de parceiro f

    Protected Sub btn_lupa_parceiro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_parceiro.Click
        Me.lbl_nm_fornecedor.Visible = True
        carregarCamposFornecedor()

    End Sub
    Private Sub carregarCamposFornecedor()

        Try
            If Not (customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_fornecedor.Text = customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_fornecedor.Text = customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_fornecedor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_fornecedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_fornecedor.TextChanged
        lbl_nm_fornecedor.Text = String.Empty
        hf_id_fornecedor.Value = String.Empty
        Try
            If Not txt_cd_fornecedor.Text.Equals(String.Empty) Then
                Dim fornecedor As New Pessoa
                fornecedor.cd_pessoa = Me.txt_cd_fornecedor.Text.Trim  ' Adri 04/05/2010
                fornecedor.id_situacao = 1
                Dim dsfornecedor As DataSet = fornecedor.getFornecedorByFilters
                'se encontrou produtor
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

    Protected Sub cv_validar_item_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_validar_item.ServerValidate
        Try
            Dim lmsg As String

            args.IsValid = True
            If Not hf_id_fornecedor.Value.Equals(String.Empty) Then
                args.IsValid = True
            Else
                args.IsValid = False
                lmsg = "O código do parceiro deve ser válido para adicioná-lo."
            End If
            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_novo_parceiro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_parceiro.Click
        'fran chamado 903
        If Page.IsValid = True Then

            Try
                Dim item_parceiro As New ItemParceiro
                Dim ds_item_parceiro As DataSet

                item_parceiro.id_item = Convert.ToInt32(ViewState.Item("id_item").ToString)
                item_parceiro.id_fornecedor = Convert.ToInt32(hf_id_fornecedor.Value)
                ds_item_parceiro = item_parceiro.getParceiroByFilters()
                If ds_item_parceiro.Tables(0).Rows.Count <= 0 Then  ' Se fornecedor ainda não foi incluído
                    item_parceiro.insertparceiro_itens()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'insert
                    usuariolog.ds_nm_processo = "Item x Parceiros"
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango
                End If

                ds_item_parceiro = Nothing
                loadParceiro()
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
End Class
