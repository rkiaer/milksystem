Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math


Partial Class frm_duplicata
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_nota_fiscal.aspx")
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
            ViewState.Item("nr_nota_fiscal") = notafiscal.nr_nota_fiscal
            ViewState.Item("dt_emissao") = notafiscal.dt_emissao
            ViewState.Item("ds_tipo_especie") = notafiscal.ds_tipo_especie


            loadgridduplicata()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadgridduplicata()

        Try

            Dim id_nota_fiscal As Int32 = Convert.ToInt32(ViewState.Item("id_nota_fiscal").ToString)
            Dim duplicata As New DuplicataNotaFiscal

            duplicata.id_nota_fiscal = id_nota_fiscal

            Dim dsduplicata As DataSet = duplicata.getDuplicatasNotasByFilters()

            If (dsduplicata.Tables(0).Rows.Count > 0) Then
                grdresults.Visible = True
                grdresults.DataSource = Helper.getDataView(dsduplicata.Tables(0), "nr_parcela asc")
                grdresults.DataBind()
            Else
                Dim dr As DataRow = dsduplicata.Tables(0).NewRow()
                'dr("id_candidato_idioma") = -1
                dsduplicata.Tables(0).Rows.InsertAt(dr, 0)
                grdresults.Visible = True
                grdresults.DataSource = Helper.getDataView(dsduplicata.Tables(0), ViewState.Item("sortExpression"))
                grdresults.DataBind()
                grdresults.Rows(0).Cells.Clear()
                grdresults.Rows(0).Cells.Add(New TableCell())
                grdresults.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdresults.Rows(0).Cells(0).Text = "Não existe nenhuma duplicata cadastrada!"
                grdresults.Rows(0).Cells(0).ColumnSpan = 5
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
        ViewState.Item("incluirlinhalacre") = "S"
        Dim duplicata As New DuplicataNotaFiscal
        duplicata.id_nota_fiscal = Convert.ToInt32(ViewState.Item("id_nota_fiscal"))
        Dim dslacre As DataSet = duplicata.getDuplicatasNotasByFilters()
        Dim dr As DataRow = dslacre.Tables(0).NewRow()
        dslacre.Tables(0).Rows.InsertAt(dr, 0)
        grdresults.Visible = True
        grdresults.DataSource = Helper.getDataView(dslacre.Tables(0), "nr_parcela asc")
        grdresults.EditIndex = 0
        grdresults.DataBind()
        ViewState.Item("incluirlinhalacre") = Nothing
        'loadgridcompartimento()

    End Sub



    Private Sub deleteDuplicata(ByVal id_duplicata_nota As Integer)

        Try

            Dim duplicata As New DuplicataNotaFiscal()
            duplicata.id_duplicata_nota = id_duplicata_nota
            duplicata.deleteDuplicataNota()
            messageControl.Alert("Registro excluído com sucesso!")
            '            loadGridIdiomas()
            loadgridduplicata()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdresults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdresults.PageIndexChanging
        grdresults.PageIndex = e.NewPageIndex

    End Sub

    Protected Sub grdresults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdresults.RowCancelingEdit
        Try

            grdresults.EditIndex = -1
            loadgridduplicata()
            'loadgridcompartimento()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdresults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdresults.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Delete"
                deleteDuplicata(Convert.ToInt32(e.CommandArgument.ToString()))
        End Select

    End Sub

    Protected Sub grdresults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdresults.RowCreated
        'If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
        '    If ViewState.Item("incluirlinhalacre") = "S" Then
        '        If e.Row.RowIndex = 0 Then
        '            ViewState.Item("label_ds_placa") = ""
        '        End If
        '    End If

        '    Try
        '        If Not (ViewState.Item("label_ds_placa") Is Nothing) Then
        '            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '            'COMBO IDIOMA NO MODO EDIÇÂO
        '            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '            Dim cbo_ds_placa As DropDownList = CType(e.Row.FindControl("cbo_ds_placa"), DropDownList)
        '            Dim romaneio_placa As New RomaneioPlaca

        '            romaneio_placa.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

        '            cbo_ds_placa.DataSource = romaneio_placa.getRomaneioPlacasByFilters()
        '            cbo_ds_placa.DataTextField = "ds_placa"
        '            cbo_ds_placa.DataValueField = "id_romaneio_placa"
        '            cbo_ds_placa.DataBind()

        '            If (ViewState.Item("label_ds_placa").ToString.Equals(String.Empty)) Then
        '                cbo_ds_placa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        '                ViewState.Item("label_ds_placa") = "SEM_VALOR" 'Assume que o nm esta sem valor
        '            Else
        '                cbo_ds_placa.SelectedValue = cbo_ds_placa.Items.FindByText(ViewState.Item("label_ds_placa").Trim.ToString).Value
        '                ViewState.Item("label_ds_placa") = Nothing 'Assume que tem valor
        '            End If

        '        End If

        '    Catch ex As Exception
        '        messageControl.Alert(ex.Message)
        '    End Try

        'End If

    End Sub

    Protected Sub grdresults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdresults.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
                Dim txt_ds_tipo_especie As DataControlFieldCell = CType(e.Row.Cells(2), DataControlFieldCell)
                Dim txt_dt_vencimento As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(e.Row.FindControl("txt_dt_vencimento"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
                Dim txt_nr_duplicata As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_duplicata"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                If ViewState.Item("incluirlinhalacre") = "S" Then
                    If ViewState.Item("ds_tipo_especie").Equals(String.Empty) Then
                        txt_ds_tipo_especie.Text = "Não Cadastrado"
                    Else
                        txt_ds_tipo_especie.Text = ViewState.Item("ds_tipo_especie")
                    End If
                    txt_dt_vencimento.Text = Format(DateTime.Parse(ViewState.Item("dt_emissao")), "dd/MM/yyyy").ToString
                    txt_nr_duplicata.Text = ViewState.Item("nr_nota_fiscal")
                Else
                    txt_dt_vencimento.Text = Format(DateTime.Parse(txt_dt_vencimento.Text), "dd/MM/yyyy").ToString
                    If txt_ds_tipo_especie.Text.Equals(String.Empty) Then
                        txt_ds_tipo_especie.Text = "Não Cadastrado"
                    End If

                End If
            End If
            If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Normal) Or (e.Row.RowState = DataControlRowState.Alternate)) Then
                Dim lbl_ds_tipo_especie As DataControlFieldCell = CType(e.Row.Cells(2), DataControlFieldCell)
                Dim lbl_dt_vencimento As Label = CType(e.Row.FindControl("lbl_dt_vencimento"), Label)
                Dim lbl_nr_duplicata As Label = CType(e.Row.FindControl("lbl_nr_duplicata"), Label)
                If Not lbl_dt_vencimento.Text.Equals(String.Empty) Then
                    lbl_dt_vencimento.Text = Format(DateTime.Parse(lbl_dt_vencimento.Text), "dd/MM/yyyy").ToString
                End If
                If lbl_ds_tipo_especie.Text.Equals(String.Empty) Then
                    lbl_ds_tipo_especie.Text = "Não Cadastrado"
                End If

            End If
            If e.Row.RowType = DataControlRowType.DataRow Then
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try



    End Sub

    Protected Sub grdresults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdresults.RowEditing
        Try

            If ViewState.Item("incluirlinhalacre") = "S" And e.NewEditIndex = 0 Then
                ViewState.Item("incluirlinhalacre") = "S"
                loadgridduplicata()
                'loadgridcompartimento()
            Else
                'Dim lbl_ds_placa As Label = CType(grdlacres.Rows(e.NewEditIndex).FindControl("lbl_ds_placa"), Label)
                'ViewState.Item("label_ds_placa") = Trim(lbl_ds_placa.Text)
                grdresults.EditIndex = e.NewEditIndex
                loadgridduplicata()
                'loadgridcompartimento()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdresults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdresults.RowUpdating
        'Capturar valores
        Dim row As GridViewRow = grdresults.Rows(e.RowIndex)
        Try
            Dim duplicata As New DuplicataNotaFiscal

            If (Not (row) Is Nothing) Then

                Dim cbo_ds_placa As DropDownList = CType(row.FindControl("cbo_ds_placa"), DropDownList)
                Dim txt_nr_duplicata As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_duplicata"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                Dim txt_dt_vencimento As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_vencimento"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
                Dim txt_valor_duplicata As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_valor_duplicata"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                duplicata.id_nota_fiscal = Convert.ToInt32(ViewState.Item("id_nota_fiscal"))
                duplicata.nr_duplicata = txt_nr_duplicata.Text.Trim.ToString
                duplicata.nr_valor_duplicata = Convert.ToDecimal(txt_valor_duplicata.Text)
                duplicata.dt_vencimento = txt_dt_vencimento.Text


            End If
            duplicata.id_modificador = Session("id_login")

            'Se é um novo idioma
            If IsDBNull(grdresults.DataKeys.Item(e.RowIndex).Value) Then
                duplicata.id_duplicata_nota = duplicata.insertDuplicataNota
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.ds_nm_processo = "Nota Fiscal - Duplicata"
                usuariolog.id_menu_item = 25
                usuariolog.id_nr_processo = duplicata.id_duplicata_nota

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

            Else
                duplicata.id_duplicata_nota = grdresults.DataKeys.Item(e.RowIndex).Value
                duplicata.updateDuplicataNota()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.ds_nm_processo = "Nota Fiscal - Duplicata"
                usuariolog.id_menu_item = 25
                usuariolog.id_nr_processo = duplicata.id_duplicata_nota

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango
            End If

            grdresults.EditIndex = -1
            loadgridduplicata()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdresults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdresults.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub cmv_valor_duplicata_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try

            ' 30/10/2008 - i
            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim txt_valor_duplicata As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_valor_duplicata"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim lbl_valor_duplicata As System.Web.UI.WebControls.Label = CType(row.FindControl("lbl_valor_duplicata"), System.Web.UI.WebControls.Label)
            Dim notafiscal As New NotaFiscal(Convert.ToInt32(ViewState.Item("id_nota_fiscal")))

            Dim nr_total_duplicata As Decimal
            Dim nr_valor_duplicata_banco As Decimal
            nr_valor_duplicata_banco = 0
            nr_total_duplicata = notafiscal.getNotasFiscaisTotalDuplicata()
            If IsNumeric(txt_valor_duplicata.Text) Then
                If Not IsNumeric(lbl_valor_duplicata.Text) Then
                    nr_valor_duplicata_banco = 0
                Else
                    nr_valor_duplicata_banco = lbl_valor_duplicata.Text
                End If
                nr_total_duplicata = (nr_total_duplicata - nr_valor_duplicata_banco) + Convert.ToDecimal(txt_valor_duplicata.Text)
                If notafiscal.nr_preco_total <> nr_total_duplicata Then
                    args.IsValid = False
                End If

                If Not args.IsValid Then
                    messageControl.Alert("O total das duplicatas deve ser igual ao total da nota.")
                End If
            End If

            ' 30/10/2008 - f

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class
