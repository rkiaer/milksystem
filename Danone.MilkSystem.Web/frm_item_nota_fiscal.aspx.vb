Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math


Partial Class frm_item_nota_fiscal
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_item_nota_fiscal.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_nota_fiscal") Is Nothing) Then
                ViewState.Item("id_nota_fiscal") = Request("id_nota_fiscal")
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_nota_fiscal As Int32 = Convert.ToInt32(ViewState.Item("id_nota_fiscal").ToString)
            Dim notafiscal As New NotaFiscal(id_nota_fiscal)

            lbl_estabelecimento.Text = String.Concat(notafiscal.cd_estabelecimento.ToString, " - ", notafiscal.nm_estabelecimento.ToString)
            lbl_cd_cnpj.Text = notafiscal.cd_cnpj.ToString
            lbl_cooperativa.Text = String.Concat(notafiscal.cd_pessoa.ToString, " - ", notafiscal.nm_pessoa.ToString)
            lbl_nr_nota_fiscal.Text = notafiscal.nr_nota_fiscal.ToString
            lbl_serie.Text = notafiscal.nr_serie.ToString
            lbl_nm_frete.Text = notafiscal.nm_frete_nf.ToString
            If Not (notafiscal.dt_emissao Is Nothing) Then
                If Not (notafiscal.dt_emissao.ToString.Equals(String.Empty)) Then
                    lbl_dt_emissao.Text = Format(DateTime.Parse(notafiscal.dt_emissao.ToString), "dd/MM/yyyy")
                End If
            End If
            If Not (notafiscal.dt_transacao Is Nothing) Then
                If Not (notafiscal.dt_transacao.ToString.Equals(String.Empty)) Then
                    lbl_dt_transacao.Text = Format(DateTime.Parse(notafiscal.dt_transacao.ToString), "dd/MM/yyyy")
                End If
            End If
            lbl_natureza_operacao.Text = String.Concat(notafiscal.cd_natureza_operacao.ToString, " - ", notafiscal.nm_natureza_operacao.ToString)

            'fran 05/11/2010 i gko item 2
            If notafiscal.id_romaneio > 0 Then
                tr_romaneio.Visible = True
                lbl_id_romaneio.Text = notafiscal.id_romaneio.ToString
            Else
                lbl_id_romaneio.Text = String.Empty
                tr_romaneio.Visible = False
            End If
            'fran 05/11/2010 f gko item 2
            loadgrid()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadgrid()

        Try

            Dim id_nota_fiscal As Int32 = Convert.ToInt32(ViewState.Item("id_nota_fiscal").ToString)
            Dim item As New ItemNotaFiscal

            item.id_nota_fiscal = id_nota_fiscal

            Dim dsitem As DataSet = item.getItensNotasByFilters()

            If (dsitem.Tables(0).Rows.Count > 0) Then
                grditem.Visible = True
                grditem.DataSource = Helper.getDataView(dsitem.Tables(0), "nr_sequencia asc")
                grditem.DataBind()
            Else
                Dim dr As DataRow = dsitem.Tables(0).NewRow()
                'dr("id_candidato_idioma") = -1
                dsitem.Tables(0).Rows.InsertAt(dr, 0)
                grditem.Visible = True
                grditem.DataSource = Helper.getDataView(dsitem.Tables(0), ViewState.Item("sortExpression"))
                grditem.DataBind()
                grditem.Rows(0).Cells.Clear()
                grditem.Rows(0).Cells.Add(New TableCell())
                grditem.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grditem.Rows(0).Cells(0).Text = "Não existe nenhum item de nota cadastrado!"
                grditem.Rows(0).Cells(0).ColumnSpan = 8
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_nota_fiscal.aspx?id_nota_fiscal=" + ViewState.Item("id_nota_fiscal").ToString)


    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("frm_nota_fiscal.aspx?id_nota_fiscal=" + ViewState.Item("id_nota_fiscal").ToString)

    End Sub



    Protected Sub btn_novo_lacre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_lacre.Click
        ViewState.Item("incluirlinha") = "S"
        Dim item As New ItemNotaFiscal
        item.id_nota_fiscal = Convert.ToInt32(ViewState.Item("id_nota_fiscal"))
        Dim dsitem As DataSet = item.getItensNotasByFilters()
        Dim dr As DataRow = dsitem.Tables(0).NewRow()
        dsitem.Tables(0).Rows.InsertAt(dr, 0)
        grditem.Visible = True
        grditem.DataSource = Helper.getDataView(dsitem.Tables(0), "nr_sequencia asc")
        grditem.EditIndex = 0
        grditem.DataBind()
        ViewState.Item("incluirlinha") = Nothing
        'loadgridcompartimento()

    End Sub

    Protected Sub grditem_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grditem.PageIndexChanging
        grditem.PageIndex = e.NewPageIndex
        'loadData()

    End Sub

    Protected Sub grditem_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grditem.RowCancelingEdit
        Try

            grditem.EditIndex = -1
            loadgrid()
            'loadgridcompartimento()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grditem_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grditem.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Insert"
                ViewState.Item("incluirlinha") = "S"
                Dim item As New ItemNotaFiscal
                item.id_nota_fiscal = Convert.ToInt32(ViewState.Item("id_nota_fiscal"))
                Dim dsitem As DataSet = item.getItensNotasByFilters()
                Dim dr As DataRow = dsitem.Tables(0).NewRow()
                'dr("id_candidato_idioma") = -1
                dsitem.Tables(0).Rows.InsertAt(dr, 0)
                grditem.Visible = True
                grditem.DataSource = Helper.getDataView(dsitem.Tables(0), ViewState.Item("sortExpression"))
                grditem.EditIndex = 0
                grditem.DataBind()
            Case "Delete"
                deleteItemNota(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteItemNota(ByVal id_item_nota As Integer)

        Try

            Dim item As New ItemNotaFiscal()
            item.id_item_nota = id_item_nota
            item.deleteItemNota()
            'fran 08/12/2020 i dango
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 25
            usuariolog.ds_nm_processo = "Nota Fiscal - Item NF"
            usuariolog.id_nr_processo = id_item_nota.ToString

            usuariolog.insertUsuarioLog()
            'fran 08/12/2020 f dango

            messageControl.Alert("Registro excluído com sucesso!")
            '            loadGridIdiomas()
            loadgrid()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grditem_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grditem.RowCreated

        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            If ViewState.Item("incluirlinha") = "S" Then

                'Dim hl_narrativa As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_narrativa"), System.Web.UI.WebControls.HyperLink)
                'hl_narrativa.Enabled = False
                e.Row.Cells(7).Enabled = False

                If e.Row.RowIndex = 0 Then
                    ViewState.Item("label_item") = ""
                End If
            End If

            Try
                If Not (ViewState.Item("label_item") Is Nothing) Then


                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    'COMBO IDIOMA NO MODO EDIÇÂO
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    Dim cbo_id_item As DropDownList = CType(e.Row.FindControl("cbo_id_item"), DropDownList)
                    Dim item As New Item

                    cbo_id_item.DataSource = item.getItensByFilters()
                    cbo_id_item.DataTextField = "nm_item"
                    cbo_id_item.DataValueField = "id_item"
                    cbo_id_item.DataBind()

                    If (ViewState.Item("label_item").ToString.Equals(String.Empty)) Then
                        cbo_id_item.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState.Item("label_item") = "SEM_VALOR" 'Assume que o nm esta sem valor
                    Else
                        cbo_id_item.SelectedValue = cbo_id_item.Items.FindByText(ViewState.Item("label_item").Trim.ToString).Value
                        ViewState.Item("label_item") = Nothing 'Assume que tem valor
                    End If

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub grditem_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grditem.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try

                If ViewState.Item("label_item") = "SEM_VALOR" Then 'Assume que o nm_st_analise esta sem valor
                    'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                    Dim cbo_id_item As DropDownList = CType(e.Row.FindControl("cbo_id_item"), DropDownList)
                    If Not (cbo_id_item Is Nothing) Then
                        cbo_id_item.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    End If
                    ViewState.Item("label_item") = Nothing 'Assume que o nm_st_analise tem valor
                End If
                'fran 05/11/2010 i gko item 2
                'se tem romaneio, é uma cooperativa
                Dim cv_nr_preco_total As Anthem.CustomValidator = CType(e.Row.FindControl("cv_nr_preco_total"), Anthem.CustomValidator)
                If tr_romaneio.Visible = True Then
                    cv_nr_preco_total.Visible = False
                Else
                    cv_nr_preco_total.Visible = True
                End If
                'fran 05/11/2010 i gko item 2

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub grditem_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grditem.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub grditem_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grditem.RowEditing
        Try

            If ViewState.Item("incluirlinha") = "S" And e.NewEditIndex = 0 Then
                ViewState.Item("incluirlinha") = "S"
                loadgrid()
                'loadgridcompartimento()
            Else

                Dim lbl_item As Label = CType(grditem.Rows(e.NewEditIndex).FindControl("lbl_nm_item"), Label)
                ViewState.Item("label_item") = Trim(lbl_item.Text)
                grditem.EditIndex = e.NewEditIndex
                loadgrid()
                'loadgridcompartimento()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grditem_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grditem.RowUpdating
        'Capturar valores
        Dim row As GridViewRow = grditem.Rows(e.RowIndex)
        Try
            Dim item As New ItemNotaFiscal

            If (Not (row) Is Nothing) Then

                Dim cbo_item As DropDownList = CType(row.FindControl("cbo_id_item"), DropDownList)
                Dim txt_nr_quantidade As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_quantidade"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_nr_preco_unitario As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_preco_unitario"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_nr_preco_total As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_preco_total"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_nr_peso_liquido As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_peso_liquido"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                'romaneioanaliseglobal.id_analise_global = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)
                If Not (cbo_item.SelectedValue.Trim().Equals(String.Empty)) Then
                    item.id_item = Convert.ToInt32(Convert.ToInt32(cbo_item.SelectedValue))
                End If
                If Trim(txt_nr_quantidade.Text) = "" Then
                    item.nr_quantidade = 0
                Else
                    item.nr_quantidade = txt_nr_quantidade.Text
                End If
                If Trim(txt_nr_preco_unitario.Text) = "" Then
                    item.nr_preco_unitario = 0
                Else
                    item.nr_preco_unitario = txt_nr_preco_unitario.Text
                End If
                If Trim(txt_nr_preco_total.Text) = "" Then
                    item.nr_preco_total = 0
                Else
                    item.nr_preco_total = txt_nr_preco_total.Text
                End If
                If Trim(txt_nr_peso_liquido.Text) = "" Then
                    item.nr_peso_liquido = 0
                Else
                    item.nr_peso_liquido = txt_nr_peso_liquido.Text
                End If
                item.id_nota_fiscal = ViewState.Item("id_nota_fiscal")

                item.id_modificador = Session("id_login")

                'Se é um novo idioma
                If IsDBNull(grditem.DataKeys.Item(e.RowIndex).Value) Then
                    item.id_item_nota = item.insertItemNota
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'insert
                    usuariolog.id_menu_item = 25
                    usuariolog.ds_nm_processo = "Nota Fiscal - Item NF"
                    usuariolog.id_nr_processo = item.id_item_nota

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango
                Else
                    item.id_item_nota = grditem.DataKeys.Item(e.RowIndex).Value
                    item.updateItemNota()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 25
                    usuariolog.ds_nm_processo = "Nota Fiscal - Item NF"
                    usuariolog.id_nr_processo = item.id_item_nota

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango
                End If
            End If
            grditem.EditIndex = -1
            loadgrid()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub cbo_id_item_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

            Dim cbo_id_item As Anthem.DropDownList = CType(row.FindControl("cbo_id_item"), Anthem.DropDownList)
            Dim lbl_cd_unidade_medida As Label = CType(row.FindControl("lbl_cd_unidade_medida"), Label)

            Dim item As New Item(Convert.ToInt32(cbo_id_item.SelectedValue))
            Dim ds As DataSet = item.getItensByFilters()

            lbl_cd_unidade_medida.Text = ds.Tables(0).Rows(0).Item("cd_unidade_medida")

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

   
    Protected Sub cv_nr_preco_total_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try
            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim txt_nr_preco_total As Anthem.TextBox = CType(row.FindControl("txt_nr_preco_total"), Anthem.TextBox)
            Dim txt_nr_quantidade As Anthem.TextBox = CType(row.FindControl("txt_nr_quantidade"), Anthem.TextBox)
            Dim txt_nr_preco_unitario As Anthem.TextBox = CType(row.FindControl("txt_nr_preco_unitario"), Anthem.TextBox)

            If Trim(txt_nr_preco_total.Text) <> "" Then
                If txt_nr_quantidade.Text > 0 And txt_nr_preco_unitario.Text > 0 Then
                    If (Convert.ToDecimal(txt_nr_quantidade.Text) * Convert.ToDecimal(txt_nr_preco_unitario.Text)) <> Convert.ToDecimal(txt_nr_preco_total.Text) Then
                        args.IsValid = False
                        messageControl.Alert("O Preço Total está incorreto.")
                    End If
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub


End Class
