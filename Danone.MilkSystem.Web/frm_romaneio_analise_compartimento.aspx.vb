Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_romaneio_analise_compartimento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneios_analise_selecao.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio_compartimento") Is Nothing) Then
                ViewState.Item("id_romaneio_compartimento") = Request("id_romaneio_compartimento")

                Dim resultadoanalise As New StatusResultadoAnalise
                cbo_registro_analise.DataSource = resultadoanalise.getStatusResultadoAnaliseByFilters()
                cbo_registro_analise.DataTextField = "nm_status_resultado_analise"
                cbo_registro_analise.DataValueField = "id_status_resultado_analise"
                cbo_registro_analise.DataBind()
                cbo_registro_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

                loadData()

                ' 18/09/2008 
                ViewState.Item("caminho_servidor") = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()

            Else
                messageControl.Alert("H� problemas na passagem de par�metros. A tela n�o pode ser montada!")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadData()

        Try
            Dim dsanalisecompartimento As DataSet
            Dim id_romaneio_compartimento As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento"))
            Dim romaneio_compartimento As New Romaneio_Compartimento(id_romaneio_compartimento)
            ViewState.Item("id_romaneio") = romaneio_compartimento.id_romaneio
            Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

            If romaneio_compartimento.id_st_analise = 3 Then 'Se rejeiad
                Me.hl_imprimir_ciq.NavigateUrl = String.Format("frm_relatorio_CIQ.aspx?id_romaneio_compartimento={0}", romaneio_compartimento.id_romaneio_compartimento.ToString)
                Me.hl_imprimir_ciq.Enabled = True
                Me.btn_email.Enabled = True
            End If
            If romaneio_compartimento.st_reanalise = "S" Then 'Se rejeiad
                Me.hl_imprimir_ciq.Visible = False
                Me.img_novo.Visible = False
                Me.btn_email.Visible = False
                Me.img_email.Visible = False
            End If

            lbl_romaneio.Text = romaneio.id_romaneio.ToString
            lbl_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            lbl_ds_compartimento.Text = romaneio_compartimento.ds_compartimento.ToString
            lbl_ds_placa_compartimento.Text = romaneio_compartimento.ds_placa.ToString
            lbl_nm_st_compartimento.Text = romaneio_compartimento.nm_st_analise.ToString

            txt_nm_analista.Text = romaneio_compartimento.nm_analista
            If Not romaneio_compartimento.dt_inicio_analise Is Nothing Then
                txt_hr_analise.Text = Format(DateTime.Parse(romaneio_compartimento.dt_inicio_analise), "HH")
                txt_mm_analise.Text = DatePart(DateInterval.Minute, DateTime.Parse(romaneio_compartimento.dt_inicio_analise)).ToString
                txt_dt_analise.Text = Format(DateTime.Parse(romaneio_compartimento.dt_inicio_analise), "dd/MM/yyyy").ToString
            Else
                txt_hr_analise.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_analise.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now)).ToString
                txt_dt_analise.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy").ToString
            End If

            If romaneio_compartimento.id_st_analise > 0 Then
                cbo_registro_analise.SelectedValue = romaneio_compartimento.id_st_analise
                cbo_registro_analise.Enabled = False
                If romaneio_compartimento.id_st_analise = 2 Then
                    lbl_labelmotivo.Visible = True
                    txt_ds_motivo_aprovado_sob_concessao.Visible = True
                    txt_ds_motivo_aprovado_sob_concessao.Text = romaneio_compartimento.ds_motivo_aprovado_sob_concessao
                    txt_ds_motivo_aprovado_sob_concessao.Enabled = False
                End If
                btn_registrar.Enabled = False
                btn_registrar.ImageUrl = "~/img/bnt_registrar2_desabilitado.gif"
                Dim comand As CommandField = CType(gridResults.Columns.Item(8), CommandField)
                comand.ShowEditButton = False
            End If

            If romaneio_compartimento.st_reanalise = "S" Then
                Dim comand As CommandField = CType(gridResults.Columns.Item(8), CommandField)
                comand.ShowEditButton = False
                tr_reanalise.Visible = True


                'Carrega os dados do Grid
                Dim romaneio_analisecompartimento As New RomaneioAnaliseCompartimento
                romaneio_analisecompartimento.id_romaneio = romaneio_compartimento.id_romaneio
                romaneio_analisecompartimento.id_romaneio_compartimento = id_romaneio_compartimento
                romaneio_analisecompartimento.st_reanalise = "N"
                romaneio_analisecompartimento.st_analise_tipo_reanalise = "S"

                Dim dsreanalisecomp As DataSet = romaneio_analisecompartimento.getRomaneioAnalisesCompartimentoReanalise()

                If (dsreanalisecomp.Tables(0).Rows.Count > 0) Then
                    ViewState.Item("rejeitado") = "N"
                    gridreanalise.Visible = True
                    gridreanalise.DataSource = Helper.getDataView(dsreanalisecomp.Tables(0), ViewState.Item("sortExpression"))
                    gridreanalise.DataBind()

                    If romaneio_compartimento.id_st_analise > 0 Then
                        cbo_registro_analise.SelectedValue = romaneio_compartimento.id_st_analise
                    Else
                        If ViewState.Item("rejeitado") = "S" Then
                            cbo_registro_analise.SelectedValue = 3
                        Else
                            cbo_registro_analise.SelectedValue = 1
                        End If
                    End If

                Else
                    gridreanalise.Visible = False
                End If

                romaneio_analisecompartimento.st_reanalise = "S"
                romaneio_analisecompartimento.st_analise_tipo_reanalise = String.Empty
                dsanalisecompartimento = romaneio_analisecompartimento.getRomaneioAnalisesCompartimentoReanalise
            Else

                'Carrega os dados do Grid
                Dim romaneio_analisecompartimento As New RomaneioAnaliseCompartimento
                romaneio_analisecompartimento.id_romaneio = romaneio_compartimento.id_romaneio
                romaneio_analisecompartimento.id_romaneio_compartimento = id_romaneio_compartimento

                dsanalisecompartimento = romaneio_analisecompartimento.getRomaneioAnalisesCompartimentosByFilters()

                ViewState.Item("rejeitado") = "N"

            End If

            If (dsanalisecompartimento.Tables(0).Rows.Count > 0) Then

                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsanalisecompartimento.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                If romaneio_compartimento.st_reanalise <> "S" Then
                    If romaneio_compartimento.id_st_analise > 0 Then
                        cbo_registro_analise.SelectedValue = romaneio_compartimento.id_st_analise
                    Else
                        If ViewState.Item("rejeitado") = "S" Then
                            cbo_registro_analise.SelectedValue = 3
                        Else
                            cbo_registro_analise.SelectedValue = 1
                        End If
                    End If

                End If
            Else
                gridResults.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadGridView()

        Try
            'Carrega os dados do Grid
            Dim romaneio_analisecompartimento As New RomaneioAnaliseCompartimento
            romaneio_analisecompartimento.id_romaneio_compartimento = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento"))
            romaneio_analisecompartimento.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

            Dim dsanalisecompartimento As DataSet = romaneio_analisecompartimento.getRomaneioAnalisesCompartimentosByFilters()

            If (dsanalisecompartimento.Tables(0).Rows.Count > 0) Then
                ViewState.Item("rejeitado") = "N"
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsanalisecompartimento.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                If ViewState.Item("rejeitado") = "S" Then
                    cbo_registro_analise.SelectedValue = 3
                End If

            Else
                gridResults.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadGridView()

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()



            Case "cd_analise"
                If (ViewState.Item("sortExpression")) = "cd_analise asc" Then
                    ViewState.Item("sortExpression") = "cd_analise desc"
                Else
                    ViewState.Item("sortExpression") = "cd_analise asc"
                End If


            Case "nm_sigla"
                If (ViewState.Item("sortExpression")) = "nm_sigla asc" Then
                    ViewState.Item("sortExpression") = "nm_sigla desc"
                Else
                    ViewState.Item("sortExpression") = "nm_sigla asc"
                End If

            Case "ds_faixa"
                If (ViewState.Item("sortExpression")) = "ds_faixa asc" Then
                    ViewState.Item("sortExpression") = "ds_faixa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_faixa asc"
                End If


        End Select

        'loadData()

    End Sub

    Protected Sub gridResults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridResults.RowCancelingEdit
        Try

            gridResults.EditIndex = -1
            'loadData()
            loadGridView()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridResults.RowEditing
        Try

            Dim lbl_nr_valor As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_nr_valor"), Label)
            ViewState.Item("lbl_nr_valor") = Trim(lbl_nr_valor.Text)
            gridResults.EditIndex = e.NewEditIndex
            loadGridView()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridResults.RowUpdating
        'Capturar valores
        Dim row As GridViewRow = gridResults.Rows(e.RowIndex)
        Try
            Dim romaneio As New Romaneio(ViewState.Item("id_romaneio"))
            If romaneio.id_st_romaneio < 3 Then
                romaneio.id_st_romaneio = 3
                romaneio.id_modificador = Session("id_login")
                romaneio.updateRomaneioSituacao()
            End If

            If (Not (row) Is Nothing) Then

                Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento
                Dim id_formato_analise As Label = CType(row.FindControl("id_formato_analise"), Label)
                Dim txt_ds_comentario As TextBox = CType(row.FindControl("txt_ds_comentario"), TextBox)
                Dim nr_faixa_inicial As Label = CType(row.FindControl("lbl_nr_faixa_inicial"), Label)
                Dim nr_faixa_final As Label = CType(row.FindControl("lbl_nr_faixa_final"), Label)
                Dim id_faixa_referencia_logica As Label = CType(row.FindControl("lbl_faixa_logica"), Label)
                Dim st_gera_CIQ As Label = CType(row.FindControl("st_gera_ciq"), Label)
                Dim lviewstaterejeitado As String = ViewState.Item("rejeitado").ToString

                romaneioanalisecompartimento.id_analise_compartimento = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)
                romaneioanalisecompartimento.ds_comentario = txt_ds_comentario.Text.ToString
                romaneioanalisecompartimento.id_modificador = Session("id_login")

                Select Case Convert.ToInt32(id_formato_analise.Text.Trim.ToString)
                    Case 1 'Descimal
                        Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        If Not (txt_dec_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                            romaneioanalisecompartimento.nr_valor = Convert.ToDecimal(txt_dec_nr_valor.Text.Trim.ToString)
                            If romaneioanalisecompartimento.nr_valor >= CDec(nr_faixa_inicial.Text) And romaneioanalisecompartimento.nr_valor <= CDec(nr_faixa_final.Text) Then
                                romaneioanalisecompartimento.id_st_analise = 1 'Aprovado
                            Else
                                romaneioanalisecompartimento.id_st_analise = 2 'Reprovado
                                ViewState.Item("rejeitado") = "S"
                            End If
                        End If

                    Case 2 'Inteiro
                        Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                        If Not (txt_int_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                            romaneioanalisecompartimento.nr_valor = Convert.ToDecimal(Convert.ToInt32(txt_int_nr_valor.Text))
                            If CLng(romaneioanalisecompartimento.nr_valor) >= CLng(nr_faixa_inicial.Text) And romaneioanalisecompartimento.nr_valor <= CLng(nr_faixa_final.Text) Then
                                romaneioanalisecompartimento.id_st_analise = 1 'Aprovado
                            Else
                                romaneioanalisecompartimento.id_st_analise = 2 'Reprovado
                                ViewState.Item("rejeitado") = "S"
                            End If
                        End If

                    Case 3 'Logico
                        Dim cbo_nr_valor As DropDownList = CType(row.FindControl("cbo_nr_valor"), DropDownList)
                        If Not (cbo_nr_valor.SelectedValue.Trim().Equals(String.Empty)) Then
                            romaneioanalisecompartimento.nr_valor = Convert.ToDecimal(Convert.ToInt32(cbo_nr_valor.SelectedValue))
                            If CLng(romaneioanalisecompartimento.nr_valor) = CLng(id_faixa_referencia_logica.Text) Then
                                romaneioanalisecompartimento.id_st_analise = 1 'Aprovado
                            Else
                                romaneioanalisecompartimento.id_st_analise = 2 'Reprovado
                                ViewState.Item("rejeitado") = "S"
                            End If

                        End If

                End Select
                If st_gera_CIQ.Text = "N" Then
                    If romaneioanalisecompartimento.id_st_analise = 2 Then 'Rejeitado
                        romaneioanalisecompartimento.id_st_original = 2
                        romaneioanalisecompartimento.id_st_analise = 1
                        'volta o status do incio da rotina
                        ViewState.Item("rejeitado") = lviewstaterejeitado
                    Else
                        romaneioanalisecompartimento.id_st_original = 0
                        romaneioanalisecompartimento.id_st_analise = 1
                    End If

                End If

                'romaneioanaliseglobal.id_st_analise = Convert.ToInt32(txt_id_st_alnalise.Text.ToString)
                romaneioanalisecompartimento.updateRomaneioAnaliseCompartimento()
                If ViewState.Item("rejeitado") = "S" Then
                    cbo_registro_analise.SelectedValue = 3
                Else
                    cbo_registro_analise.SelectedValue = 1
                End If

                gridResults.EditIndex = -1
                loadGridView()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated

        'If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

        '    Try
        '        If Not (ViewState.Item("label_nm_st_analise") Is Nothing) Then
        '            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '            'COMBO STATUS ANALISE NO MODO EDI��O
        '            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '            Dim cbo_id_st_analise As DropDownList = CType(e.Row.FindControl("cbo_id_st_analise"), DropDownList)

        '            Dim statusanalise As New StatusAnalise

        '            cbo_id_st_analise.DataSource = statusanalise.getStatusAnaliseByFilters()
        '            cbo_id_st_analise.DataTextField = "nm_st_analise"
        '            cbo_id_st_analise.DataValueField = "id_st_analise"
        '            cbo_id_st_analise.DataBind()

        '            If (ViewState.Item("label_nm_st_analise").ToString.Equals(String.Empty)) Then
        '                cbo_id_st_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        '                'cbo_id_st_analise.SelectedValue = -1
        '                ViewState.Item("label_nm_st_analise") = "SEM_VALOR" 'Assume que o nm_st_analise esta sem valor
        '            Else
        '                cbo_id_st_analise.SelectedValue = cbo_id_st_analise.Items.FindByText(ViewState.Item("label_nm_st_analise").Trim.ToString).Value
        '                ViewState.Item("label_nm_st_analise") = Nothing 'Assume que o nm_st_analise tem valor
        '            End If
        '            'ViewState("label_nm_st_analise") = String.Empty





        '        End If

        '    Catch ex As Exception
        '        messageControl.Alert(ex.Message)
        '    End Try

        'End If
    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Edit", "Editar", "Cancel", "Cancelar", "Update"
                Return
        End Select
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                'If ViewState.Item("label_nm_st_analise") = "SEM_VALOR" Then 'Assume que o nm_st_analise esta sem valor
                '    'Se j� fez a cria��o  da linha e esta sem valor no combo situacao, for�a o 'Selecione'
                '    Dim cbo_id_st_analise As DropDownList = CType(e.Row.FindControl("cbo_id_st_analise"), DropDownList)
                '    If Not (cbo_id_st_analise Is Nothing) Then
                '        cbo_id_st_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                '    End If
                '    ViewState.Item("label_nm_st_analise") = Nothing 'Assume que o nm_st_analise tem valor
                'End If
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'CAMPO VALOR
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'Verifica qual o formato da analise para montar o campo correto
                Dim id_formato_analise As Label = CType(e.Row.FindControl("id_formato_analise"), Label)
                Dim lbl_faixa_referencial As Label = CType(e.Row.FindControl("lbl_faixa_referencial"), Label)
                Dim lbl_faixa_referencia_logica As Label = CType(e.Row.FindControl("lbl_faixa_referencia_logica"), Label)
                Dim nr_faixa_inicial As Label = CType(e.Row.FindControl("lbl_nr_faixa_inicial"), Label)
                Dim nr_faixa_final As Label = CType(e.Row.FindControl("lbl_nr_faixa_final"), Label)


                Select Case Convert.ToInt32(id_formato_analise.Text.Trim)
                    Case 1 'Decimal
                        Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim rfv_txt_dec_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_txt_dec_nr_valor"), RequiredFieldValidator)
                        rfv_txt_dec_nr_valor.Visible = True
                        txt_dec_nr_valor.Visible = True
                        If Not (ViewState.Item("lbl_nr_valor").ToString.Equals(String.Empty)) Then
                            txt_dec_nr_valor.Text = CStr(CDec(ViewState.Item("lbl_nr_valor")))
                        End If
                        lbl_faixa_referencial.Text = CStr(CDec(nr_faixa_inicial.Text)) & "  -  " & CStr(CDec(nr_faixa_final.Text))
                        lbl_faixa_referencial.Visible = True
                        lbl_faixa_referencia_logica.Visible = False
                    Case 2 'Inteiro
                        Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                        Dim rfv_txt_int_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_txt_int_nr_valor"), RequiredFieldValidator)
                        txt_int_nr_valor.Visible = True
                        rfv_txt_int_nr_valor.Visible = True
                        If Not (ViewState.Item("lbl_nr_valor").ToString.Equals(String.Empty)) Then
                            txt_int_nr_valor.Text = CStr(CLng(ViewState.Item("lbl_nr_valor")))
                        End If
                        lbl_faixa_referencial.Text = CStr(CLng(nr_faixa_inicial.Text)) & "  -  " & CStr(CLng(nr_faixa_final.Text))
                        lbl_faixa_referencial.Visible = True
                        lbl_faixa_referencia_logica.Visible = False
                    Case 3 ' L�gico
                        Dim cbo_nr_valor As DropDownList = CType(e.Row.FindControl("cbo_nr_valor"), DropDownList)
                        Dim rfv_cbo_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_cbo_nr_valor"), RequiredFieldValidator)
                        rfv_cbo_nr_valor.Visible = True
                        cbo_nr_valor.Visible = True
                        Dim analiselogica As New AnaliseLogica
                        cbo_nr_valor.DataSource = analiselogica.getAnalisesLogicasByFilters
                        cbo_nr_valor.DataTextField = "nm_analise_logica"
                        cbo_nr_valor.DataValueField = "id_analise_logica"
                        cbo_nr_valor.DataBind()

                        If (ViewState.Item("lbl_nr_valor").ToString.Equals(String.Empty)) Then
                            cbo_nr_valor.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                            '                            ViewState("label_nr_valor") = "SEM_VALOR" 'Assume que o nm_st_analise esta sem valor
                        Else
                            'cbo_nr_valor.SelectedValue = cbo_nr_valor.Items.FindByText(CInt(ViewState.Item("lbl_nr_valor").Trim.ToString)).Value
                            cbo_nr_valor.SelectedValue = ViewState.Item("lbl_nr_valor").Trim.ToString
                            'ViewState("label_nr_valor") = Nothing 'Assume que o nm_st_analise tem valor
                        End If
                        lbl_faixa_referencia_logica.Visible = True
                        lbl_faixa_referencial.Visible = False
                End Select

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Normal) Or (e.Row.RowState = DataControlRowState.Alternate)) Then
            Try
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'CAMPO VALOR
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'Verifica qual o formato da analise para montar o campo correto
                Dim id_formato_analise As Label = CType(e.Row.FindControl("id_formato_analise"), Label)
                Dim st_gera_ciq As Label = CType(e.Row.FindControl("st_gera_ciq"), Label)
                Dim id_st_original As Label = CType(e.Row.FindControl("id_st_original"), Label)
                Dim lbl_nr_valor As Label = CType(e.Row.FindControl("lbl_nr_valor"), Label)
                Dim lbl_nm_valor As Label = CType(e.Row.FindControl("lbl_nm_valor"), Label)
                Dim lbl_faixa_referencial As Label = CType(e.Row.FindControl("lbl_faixa_referencial"), Label)
                Dim lbl_faixa_referencia_logica As Label = CType(e.Row.FindControl("lbl_faixa_referencia_logica"), Label)
                Dim nr_faixa_inicial As Label = CType(e.Row.FindControl("lbl_nr_faixa_inicial"), Label)
                Dim nr_faixa_final As Label = CType(e.Row.FindControl("lbl_nr_faixa_final"), Label)
                Dim nm_st_analise As Label = CType(e.Row.FindControl("lbl_nm_st_analise"), Label)

                If Not nm_st_analise Is Nothing Then
                    If st_gera_ciq.Text = "N" Then
                        If Not id_st_original.Text.Equals(String.Empty) Then
                            If id_st_original.Text = "2" Then
                                nm_st_analise.Text = "Rejeitado*"
                            End If
                        End If
                    Else
                        If nm_st_analise.Text = "Rejeitado" Then
                            ViewState.Item("rejeitado") = "S"
                        End If
                    End If
                End If

                Select Case Convert.ToInt32(id_formato_analise.Text.Trim)
                    Case 1 'Decimal
                        lbl_faixa_referencial.Visible = True
                        lbl_faixa_referencia_logica.Visible = False
                        lbl_faixa_referencial.Text = CStr(CDec(nr_faixa_inicial.Text)) & "  -  " & CStr(CDec(nr_faixa_final.Text))
                    Case 2 'Inteiro
                        lbl_faixa_referencial.Visible = True
                        lbl_faixa_referencia_logica.Visible = False
                        lbl_faixa_referencial.Text = CStr(CLng(nr_faixa_inicial.Text)) & "  -  " & CStr(CLng(nr_faixa_final.Text))
                    Case 3 ' L�gico
                        lbl_faixa_referencia_logica.Visible = True
                        lbl_faixa_referencial.Visible = False
                End Select

                Dim lsaux As String
                lsaux = lbl_nr_valor.Text
                If Not (lbl_nr_valor.Text.ToString.Equals(String.Empty)) Then
                    Select Case Convert.ToInt32(id_formato_analise.Text.Trim)
                        Case 1 'Decimal
                            lbl_nr_valor.Text = CStr(CDec(lbl_nr_valor.Text))
                        Case 2 'Inteiro
                            lsaux = Convert.ToString(CLng(lsaux))
                            lbl_nr_valor.Text = CStr(CLng(lbl_nr_valor.Text))
                        Case 3 ' L�gico
                            lbl_nr_valor.Visible = False
                            lbl_nm_valor.Visible = True
                    End Select
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_romaneio_analises.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString)

    End Sub
    Private Sub RegistrarAnaliseCompartimentoRejeitada()
        If Page.IsValid = True Then

            Try

                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                romaneio.id_st_analise_compartimento = 2 'Rejeitada 
                romaneio.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento = New Romaneio_Compartimento(Convert.ToInt32(ViewState.Item("id_romaneio_compartimento")))
                'romaneio.romaneio_compartimento.id_st_analise = id_st_analise_compartimento 'Rejeitada ou Aprovada sob concessao
                romaneio.romaneio_compartimento.id_st_analise = 3 'Rejeitada 
                romaneio.romaneio_compartimento.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento.dt_inicio_analise = txt_dt_analise.Text & " " & txt_hr_analise.Text & ":" & txt_mm_analise.Text & ":00"
                romaneio.romaneio_compartimento.nm_analista = txt_nm_analista.Text.ToString

                romaneio.registrarAnaliseCompartimentoRejeitada()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
    Private Sub RegistrarAnaliseCompartimentoAprovada()
        If Page.IsValid = True Then

            Try
                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))
                Dim id_st_analise_compartimento As Int32 = CInt(Me.cbo_registro_analise.SelectedValue)
                romaneio.id_st_analise_compartimento = 1 'Aprovada 
                romaneio.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento = New Romaneio_Compartimento(Convert.ToInt32(ViewState.Item("id_romaneio_compartimento")))
                'romaneio.romaneio_compartimento.id_st_analise = 1 'Aprovada
                romaneio.romaneio_compartimento.id_st_analise = id_st_analise_compartimento 'Aprovada ou Aprovada sob concessao
                romaneio.romaneio_compartimento.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento.dt_inicio_analise = txt_dt_analise.Text & " " & txt_hr_analise.Text & ":" & txt_mm_analise.Text & ":00"
                romaneio.romaneio_compartimento.nm_analista = txt_nm_analista.Text.ToString
                If id_st_analise_compartimento = 2 Then 'aprovado sob concessao
                    romaneio.romaneio_compartimento.ds_motivo_aprovado_sob_concessao = txt_ds_motivo_aprovado_sob_concessao.Text.ToString
                End If
                romaneio.registrarAnaliseCompartimentoAprovada()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If


    End Sub

    'Protected Sub lk_registrar_analise_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_registrar_analise.Click
    '    Try
    '        If lbl_status_botao.Text.Trim = "Positivo" Then

    '            'Vai passar o bot�o para negativo, s� muda a imagem pois os cadastros j� est�o incluidos
    '            lk_registrar_analise.Text = "Registrar An�lise de Compartimento Negativa"
    '            lbl_status_botao.Text = "Negativo"
    '            Me.RegistrarAnaliseCompartimentoPositiva()
    '            loadData()
    '        Else
    '            'Vai passar o bot�o para positivo, s� muda a imagem pois os cadastros j� est�o incluidos
    '            lk_registrar_analise.Text = "Registrar An�lise de Compartimento Positiva"
    '            lbl_status_botao.Text = "Positivo"
    '            Me.RegistrarAnaliseCompartimentoNegativa()
    '            loadData()
    '        End If
    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub


    Protected Sub lk_concluirBody_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirBody.Click
        updateData()
    End Sub


    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_analises.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString)

    End Sub

    Protected Sub btn_registrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_registrar.Click
        If Page.IsValid Then

            Try

                If CInt(Me.cbo_registro_analise.SelectedValue) = 3 Then
                    RegistrarAnaliseCompartimentoRejeitada()
                Else
                    RegistrarAnaliseCompartimentoAprovada()
                End If
                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub


    Private Sub updateData()
        If Page.IsValid Then

            Try

                Dim rc As New Romaneio_Compartimento(Convert.ToInt32(ViewState.Item("id_romaneio_compartimento")))

                rc.dt_inicio_analise = txt_dt_analise.Text & " " & txt_hr_analise.Text & ":" & txt_mm_analise.Text & ":00"
                rc.nm_analista = txt_nm_analista.Text.ToString
                rc.id_modificador = Session("id_login")

                rc.updateRomaneio_Compartimento()

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub cv_st_analises_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_st_analises.ServerValidate

        Dim analisecomp As New RomaneioAnaliseCompartimento
        analisecomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
        analisecomp.id_romaneio_compartimento = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento"))
        'Busaca as analise obrigatorias, reanalise <> S e statuscompartimento vazio
        If analisecomp.getRomaneioAnaliseCompartimentoSemResultado() > 0 Then
            args.IsValid = False
        Else
            args.IsValid = True
        End If

        If args.IsValid = False Then
            messageControl.Alert("Para registrar o resultado desta an�lise de compartimento, todas as an�lises obrigat�rias devem ser informadas.")
        End If
    End Sub

    Protected Sub cv_analista_dt_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_analista_dt.ServerValidate
        Dim rc As New Romaneio_Compartimento(Convert.ToInt32(ViewState.Item("id_romaneio_compartimento")))
        args.IsValid = True
        If rc.nm_analista Is Nothing Then
            args.IsValid = False
        Else
            If rc.nm_analista.ToString.Equals(String.Empty) Then
                args.IsValid = False
            End If
        End If

        If rc.dt_inicio_analise Is Nothing Then
            args.IsValid = False
        Else
            If rc.dt_inicio_analise.ToString.Equals(String.Empty) Then
                args.IsValid = False
            End If
        End If

        If args.IsValid = False Then
            messageControl.Alert("Para registrar o resultado desta an�lise de compartimento, o nome do analista e a data de in�cio da an�lise devem ser salvos.")
        End If


    End Sub

    Protected Sub cv_verificarrejeitadas_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_verificarrejeitadas.ServerValidate
        Dim analisecomp As New RomaneioAnaliseCompartimento
        Dim liresult As Int32
        Dim lsvaluecbo As Integer
        Dim lmsg As String

        args.IsValid = True
        If Not cbo_registro_analise.SelectedValue.Equals(String.Empty) Then
            lsvaluecbo = CInt(cbo_registro_analise.SelectedValue)
            analisecomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            analisecomp.id_romaneio_compartimento = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento"))
            'Se tem alguma analise rejeitada, o cbo n�o pode ser registro de aprovada
            liresult = analisecomp.getRomaneioAnaliseCompartimentoRejeitada()

            'Se tem rejeitadas....
            If liresult > 0 Then
                If lsvaluecbo = 1 Then
                    args.IsValid = False
                    lmsg = "Voc� n�o pode registrar a an�lise do compartimento como 'APROVADA' porque h� an�lises com situa��o 'REJEITADA'"
                End If
            Else 'se n�o tem rejeitadas
                If lsvaluecbo <> 1 Then
                    args.IsValid = False
                    lmsg = "A an�lise deste compartimento s� pode ser registrada como 'APROVADA' pois n�o h� registro de an�lises com situa��o 'REJEITADA'"
                End If
            End If
            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        End If
    End Sub
    Private Sub loadGridreanalise()

        Try
            'Carrega os dados do Grid
            Dim romaneio_analisecompartimento As New RomaneioAnaliseCompartimento
            romaneio_analisecompartimento.id_romaneio_compartimento = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento"))
            romaneio_analisecompartimento.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            romaneio_analisecompartimento.st_reanalise = "N"
            romaneio_analisecompartimento.st_analise_tipo_reanalise = "S"

            Dim dsanalisecompartimento As DataSet = romaneio_analisecompartimento.getRomaneioAnalisesCompartimentoReanalise()

            If (dsanalisecompartimento.Tables(0).Rows.Count > 0) Then
                ViewState.Item("rejeitado") = "N"
                gridreanalise.Visible = True
                gridreanalise.DataSource = Helper.getDataView(dsanalisecompartimento.Tables(0), ViewState.Item("sortExpression"))
                gridreanalise.DataBind()
                If ViewState.Item("rejeitado") = "S" Then
                    cbo_registro_analise.SelectedValue = 3
                End If

            Else
                gridreanalise.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridreanalise_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridreanalise.PageIndexChanging
        gridreanalise.PageIndex = e.NewPageIndex
        loadGridreanalise()

    End Sub

    Protected Sub gridreanalise_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridreanalise.Sorting

        Select Case e.SortExpression.ToLower()



            Case "cd_analise"
                If (ViewState.Item("sortExpression")) = "cd_analise asc" Then
                    ViewState.Item("sortExpression") = "cd_analise desc"
                Else
                    ViewState.Item("sortExpression") = "cd_analise asc"
                End If


            Case "nm_sigla"
                If (ViewState.Item("sortExpression")) = "nm_sigla asc" Then
                    ViewState.Item("sortExpression") = "nm_sigla desc"
                Else
                    ViewState.Item("sortExpression") = "nm_sigla asc"
                End If

            Case "ds_faixa"
                If (ViewState.Item("sortExpression")) = "ds_faixa asc" Then
                    ViewState.Item("sortExpression") = "ds_faixa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_faixa asc"
                End If


        End Select

        'loadData()

    End Sub

    Protected Sub gridreanalise_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridreanalise.RowCancelingEdit
        Try

            gridreanalise.EditIndex = -1
            'loadData()
            loadGridreanalise()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridreanalise_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridreanalise.RowEditing
        Try

            Dim lbl_nr_valor As Label = CType(gridreanalise.Rows(e.NewEditIndex).FindControl("lbl_nr_valor"), Label)
            ViewState.Item("lbl_nr_valor") = Trim(lbl_nr_valor.Text)
            gridreanalise.EditIndex = e.NewEditIndex
            loadGridreanalise()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridreanalise_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridreanalise.RowUpdating
        'Capturar valores
        Dim row As GridViewRow = gridreanalise.Rows(e.RowIndex)
        Try
            Dim romaneio As New Romaneio(ViewState.Item("id_romaneio"))
            If romaneio.id_st_romaneio < 3 Then
                romaneio.id_st_romaneio = 3
                romaneio.id_modificador = Session("id_login")
                romaneio.updateRomaneioSituacao()
            End If

            If (Not (row) Is Nothing) Then

                Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento
                Dim id_formato_analise As Label = CType(row.FindControl("id_formato_analise"), Label)
                Dim st_gera_CIQ As Label = CType(row.FindControl("st_gera_ciq"), Label)
                Dim txt_ds_comentario As TextBox = CType(row.FindControl("txt_ds_comentario"), TextBox)
                Dim nr_faixa_inicial As Label = CType(row.FindControl("lbl_nr_faixa_inicial"), Label)
                Dim nr_faixa_final As Label = CType(row.FindControl("lbl_nr_faixa_final"), Label)
                Dim id_faixa_referencia_logica As Label = CType(row.FindControl("lbl_faixa_logica"), Label)
                Dim lviewstaterejeitado As String = ViewState.Item("rejeitado").ToString
                romaneioanalisecompartimento.id_analise_compartimento = Convert.ToInt32(gridreanalise.DataKeys.Item(e.RowIndex).Value)
                romaneioanalisecompartimento.ds_comentario = txt_ds_comentario.Text.ToString
                romaneioanalisecompartimento.id_modificador = Session("id_login")

                Select Case Convert.ToInt32(id_formato_analise.Text.Trim.ToString)
                    Case 1 'Descimal
                        Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        If Not (txt_dec_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                            romaneioanalisecompartimento.nr_valor = Convert.ToDecimal(txt_dec_nr_valor.Text.Trim.ToString)
                            If romaneioanalisecompartimento.nr_valor >= CDec(nr_faixa_inicial.Text) And romaneioanalisecompartimento.nr_valor < CDec(nr_faixa_final.Text) Then
                                romaneioanalisecompartimento.id_st_analise = 1 'Aprovado
                            Else
                                romaneioanalisecompartimento.id_st_analise = 2 'Reprovado
                                ViewState.Item("rejeitado") = "S"
                            End If
                        End If

                    Case 2 'Inteiro
                        Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                        If Not (txt_int_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                            romaneioanalisecompartimento.nr_valor = Convert.ToDecimal(Convert.ToInt32(txt_int_nr_valor.Text))
                            If CLng(romaneioanalisecompartimento.nr_valor) >= CLng(nr_faixa_inicial.Text) And romaneioanalisecompartimento.nr_valor < CLng(nr_faixa_final.Text) Then
                                romaneioanalisecompartimento.id_st_analise = 1 'Aprovado
                            Else
                                romaneioanalisecompartimento.id_st_analise = 2 'Reprovado
                                ViewState.Item("rejeitado") = "S"
                            End If
                        End If

                    Case 3 'Logico
                        Dim cbo_nr_valor As DropDownList = CType(row.FindControl("cbo_nr_valor"), DropDownList)
                        If Not (cbo_nr_valor.SelectedValue.Trim().Equals(String.Empty)) Then
                            romaneioanalisecompartimento.nr_valor = Convert.ToDecimal(Convert.ToInt32(cbo_nr_valor.SelectedValue))
                            If CLng(romaneioanalisecompartimento.nr_valor) = CLng(id_faixa_referencia_logica.Text) Then
                                romaneioanalisecompartimento.id_st_analise = 1 'Aprovado
                            Else
                                romaneioanalisecompartimento.id_st_analise = 2 'Reprovado
                                ViewState.Item("rejeitado") = "S"
                            End If

                        End If

                End Select

                If st_gera_CIQ.Text = "N" Then
                    If romaneioanalisecompartimento.id_st_analise = 2 Then 'Rejeitado
                        romaneioanalisecompartimento.id_st_original = 2
                        romaneioanalisecompartimento.id_st_analise = 1
                        'volta o status do incio da rotina
                        ViewState.Item("rejeitado") = lviewstaterejeitado
                    Else
                        romaneioanalisecompartimento.id_st_original = 0
                        romaneioanalisecompartimento.id_st_analise = 1
                    End If

                End If
                'romaneioanaliseglobal.id_st_analise = Convert.ToInt32(txt_id_st_alnalise.Text.ToString)
                romaneioanalisecompartimento.updateRomaneioAnaliseCompartimento()
                If ViewState.Item("rejeitado") = "S" Then
                    cbo_registro_analise.SelectedValue = 3
                Else
                    cbo_registro_analise.SelectedValue = 1
                End If

                gridreanalise.EditIndex = -1
                loadGridreanalise()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridreanalise_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridreanalise.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                'If ViewState.Item("label_nm_st_analise") = "SEM_VALOR" Then 'Assume que o nm_st_analise esta sem valor
                '    'Se j� fez a cria��o  da linha e esta sem valor no combo situacao, for�a o 'Selecione'
                '    Dim cbo_id_st_analise As DropDownList = CType(e.Row.FindControl("cbo_id_st_analise"), DropDownList)
                '    If Not (cbo_id_st_analise Is Nothing) Then
                '        cbo_id_st_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                '    End If
                '    ViewState.Item("label_nm_st_analise") = Nothing 'Assume que o nm_st_analise tem valor
                'End If
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'CAMPO VALOR
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'Verifica qual o formato da analise para montar o campo correto
                Dim id_formato_analise As Label = CType(e.Row.FindControl("id_formato_analise"), Label)
                Dim lbl_faixa_referencial As Label = CType(e.Row.FindControl("lbl_faixa_referencial"), Label)
                Dim lbl_faixa_referencia_logica As Label = CType(e.Row.FindControl("lbl_faixa_referencia_logica"), Label)
                Dim nr_faixa_inicial As Label = CType(e.Row.FindControl("lbl_nr_faixa_inicial"), Label)
                Dim nr_faixa_final As Label = CType(e.Row.FindControl("lbl_nr_faixa_final"), Label)


                Select Case Convert.ToInt32(id_formato_analise.Text.Trim)
                    Case 1 'Decimal
                        Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim rfv_txt_dec_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_txt_dec_nr_valor"), RequiredFieldValidator)
                        rfv_txt_dec_nr_valor.Visible = True
                        txt_dec_nr_valor.Visible = True
                        If Not (ViewState.Item("lbl_nr_valor").ToString.Equals(String.Empty)) Then
                            txt_dec_nr_valor.Text = CStr(CDec(ViewState.Item("lbl_nr_valor")))
                        End If
                        lbl_faixa_referencial.Text = CStr(CDec(nr_faixa_inicial.Text)) & "  -  " & CStr(CDec(nr_faixa_final.Text))
                        lbl_faixa_referencial.Visible = True
                        lbl_faixa_referencia_logica.Visible = False
                    Case 2 'Inteiro
                        Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                        Dim rfv_txt_int_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_txt_int_nr_valor"), RequiredFieldValidator)
                        txt_int_nr_valor.Visible = True
                        rfv_txt_int_nr_valor.Visible = True
                        If Not (ViewState.Item("lbl_nr_valor").ToString.Equals(String.Empty)) Then
                            txt_int_nr_valor.Text = CStr(CLng(ViewState.Item("lbl_nr_valor")))
                        End If
                        lbl_faixa_referencial.Text = CStr(CLng(nr_faixa_inicial.Text)) & "  -  " & CStr(CLng(nr_faixa_final.Text))
                        lbl_faixa_referencial.Visible = True
                        lbl_faixa_referencia_logica.Visible = False
                    Case 3 ' L�gico
                        Dim cbo_nr_valor As DropDownList = CType(e.Row.FindControl("cbo_nr_valor"), DropDownList)
                        Dim rfv_cbo_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_cbo_nr_valor"), RequiredFieldValidator)
                        rfv_cbo_nr_valor.Visible = True
                        cbo_nr_valor.Visible = True
                        Dim analiselogica As New AnaliseLogica
                        cbo_nr_valor.DataSource = analiselogica.getAnalisesLogicasByFilters
                        cbo_nr_valor.DataTextField = "nm_analise_logica"
                        cbo_nr_valor.DataValueField = "id_analise_logica"
                        cbo_nr_valor.DataBind()

                        If (ViewState.Item("lbl_nr_valor").ToString.Equals(String.Empty)) Then
                            cbo_nr_valor.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                            '                            ViewState("label_nr_valor") = "SEM_VALOR" 'Assume que o nm_st_analise esta sem valor
                        Else
                            'cbo_nr_valor.SelectedValue = cbo_nr_valor.Items.FindByText(CInt(ViewState.Item("lbl_nr_valor").Trim.ToString)).Value
                            cbo_nr_valor.SelectedValue = ViewState.Item("lbl_nr_valor").Trim.ToString
                            'ViewState("label_nr_valor") = Nothing 'Assume que o nm_st_analise tem valor
                        End If
                        lbl_faixa_referencia_logica.Visible = True
                        lbl_faixa_referencial.Visible = False
                End Select

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Normal) Or (e.Row.RowState = DataControlRowState.Alternate)) Then
            Try
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'CAMPO VALOR
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'Verifica qual o formato da analise para montar o campo correto
                Dim id_formato_analise As Label = CType(e.Row.FindControl("id_formato_analise"), Label)
                Dim st_gera_ciq As Label = CType(e.Row.FindControl("st_gera_ciq"), Label)
                Dim lbl_nr_valor As Label = CType(e.Row.FindControl("lbl_nr_valor"), Label)
                Dim lbl_nm_valor As Label = CType(e.Row.FindControl("lbl_nm_valor"), Label)
                Dim lbl_faixa_referencial As Label = CType(e.Row.FindControl("lbl_faixa_referencial"), Label)
                Dim lbl_faixa_referencia_logica As Label = CType(e.Row.FindControl("lbl_faixa_referencia_logica"), Label)
                Dim nr_faixa_inicial As Label = CType(e.Row.FindControl("lbl_nr_faixa_inicial"), Label)
                Dim nr_faixa_final As Label = CType(e.Row.FindControl("lbl_nr_faixa_final"), Label)
                Dim nm_st_analise As Label = CType(e.Row.FindControl("lbl_nm_st_analise"), Label)
                Dim id_st_original As Label = CType(e.Row.FindControl("id_st_original"), Label)


                If Not nm_st_analise Is Nothing Then
                    If st_gera_ciq.Text = "N" Then
                        If Not id_st_original.Text.Equals(String.Empty) Then
                            If id_st_original.Text = "2" Then
                                nm_st_analise.Text = "Rejeitado*"
                            End If
                        End If
                    Else
                        If nm_st_analise.Text = "Rejeitado" Then
                            ViewState.Item("rejeitado") = "S"
                        End If
                    End If
                End If

                Select Case Convert.ToInt32(id_formato_analise.Text.Trim)
                    Case 1 'Decimal
                        lbl_faixa_referencial.Visible = True
                        lbl_faixa_referencia_logica.Visible = False
                        lbl_faixa_referencial.Text = CStr(CDec(nr_faixa_inicial.Text)) & "  -  " & CStr(CDec(nr_faixa_final.Text))
                    Case 2 'Inteiro
                        lbl_faixa_referencial.Visible = True
                        lbl_faixa_referencia_logica.Visible = False
                        lbl_faixa_referencial.Text = CStr(CLng(nr_faixa_inicial.Text)) & "  -  " & CStr(CLng(nr_faixa_final.Text))
                    Case 3 ' L�gico
                        lbl_faixa_referencia_logica.Visible = True
                        lbl_faixa_referencial.Visible = False
                End Select

                Dim lsaux As String
                lsaux = lbl_nr_valor.Text
                If Not (lbl_nr_valor.Text.ToString.Equals(String.Empty)) Then
                    Select Case Convert.ToInt32(id_formato_analise.Text.Trim)
                        Case 1 'Decimal
                            lbl_nr_valor.Text = CStr(CDec(lbl_nr_valor.Text))
                        Case 2 'Inteiro
                            lsaux = Convert.ToString(CLng(lsaux))
                            lbl_nr_valor.Text = CStr(CLng(lbl_nr_valor.Text))
                        Case 3 ' L�gico
                            lbl_nr_valor.Visible = False
                            lbl_nm_valor.Visible = True
                    End Select
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub cbo_registro_analise_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_registro_analise.SelectedIndexChanged
        If cbo_registro_analise.SelectedValue = 2 Then
            lbl_labelmotivo.Visible = True
            txt_ds_motivo_aprovado_sob_concessao.Visible = True
            rfv_motivo.Visible = True
        Else
            lbl_labelmotivo.Visible = False
            txt_ds_motivo_aprovado_sob_concessao.Visible = False
            rfv_motivo.Visible = False

        End If
    End Sub

    Protected Sub btn_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_email.Click
        If Page.IsValid = True Then
            Try



                Dim notificacao As New Notificacao
                Dim lAssunto As String = "RELAT�RIO CIQ " & ViewState.Item("id_romaneio_compartimento").ToString
                'Dim lCorpo As String = "Existe uma ocorr�ncia relatada atrav�s do Relat�rio CIQ, que pode ser visualizado pelo link http://localhost:56946/Danone.MilkSystem.Web/frm_relatorio_CIQ.aspx?id_romaneio_compartimento=" & ViewState.Item("id_romaneio_compartimento").ToString & " ."
                Dim lCorpo As String = "Existe uma ocorr�ncia relatada atrav�s do Relat�rio CIQ, que pode ser visualizado pelo link " & ViewState.Item("caminho_servidor") & "/frm_relatorio_CIQ.aspx?id_romaneio_compartimento=" & ViewState.Item("id_romaneio_compartimento").ToString & " ."

                If notificacao.enviaMensagemEmail(1, lAssunto, lCorpo, MailPriority.High) = True Then

                    messageControl.Alert("O Relat�rio CIQ foi enviado aos destinat�rios cadastrados com sucesso!")
                Else

                    messageControl.Alert("O Relat�rio CIQ n�o pode ser enviado pois n�o h� emails cadastrados para este relat�rio.")

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        End If
    End Sub
End Class
