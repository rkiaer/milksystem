Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_romaneio_analise_uproducao
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

            If Not (Request("id_romaneio_uproducao") Is Nothing) Then
                ViewState.Item("id_romaneio_uproducao") = Request("id_romaneio_uproducao")

                Dim resultadoanalise As New StatusResultadoAnalise
                cbo_registro_analise.DataSource = resultadoanalise.getStatusResultadoAnaliseByFilters()
                cbo_registro_analise.DataTextField = "nm_status_resultado_analise"
                cbo_registro_analise.DataValueField = "id_status_resultado_analise"
                cbo_registro_analise.DataBind()
                cbo_registro_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

                If Not (Request("nm_tela") Is Nothing) Then
                    ViewState.Item("nm_tela") = Request("nm_tela")
                Else
                    ViewState.Item("nm_tela") = String.Empty
                End If
                'fran 12/2016
                If ViewState.Item("nm_tela").ToString = "frm_pre_romaneio_analise_comp_veiculo.aspx" Then
                    img_novo.Visible = False
                    img_email.Visible = False
                    hl_imprimir_ciqp.Visible = False
                    btn_email.Visible = False
                End If

                loadData()

                ' 18/09/2008 
                ViewState.Item("caminho_servidor") = "http://" & System.Configuration.ConfigurationManager.AppSettings("ApplicationServer").ToString()

            Else
                messageControl.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadData()

        Try

            Dim id_romaneio_uproducao As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_uproducao"))
            Dim romaneio_uproducao As New Romaneio_Comp_UProducao(Convert.ToInt32(ViewState.Item("id_romaneio_uproducao")))
            Dim romaneio As New Romaneio(romaneio_uproducao.id_romaneio)

            ViewState.Item("id_tecnico") = romaneio_uproducao.id_tecnico   ' 29/09/2008 - Guarda id_tecnico para envio de email CIQP

            If romaneio_uproducao.id_status_analise_uproducao = 3 Then 'Se rejeiad
                Me.hl_imprimir_ciqp.NavigateUrl = String.Format("frm_relatorio_CIQP.aspx?id_romaneio_uproducao={0}", romaneio_uproducao.id_romaneio_uproducao.ToString)
                Me.hl_imprimir_ciqp.Enabled = True
                Me.btn_email.Enabled = True

            End If
            Dim romaneio_compartimento As New Romaneio_Compartimento(romaneio_uproducao.id_romaneio_compartimento)
            If romaneio_compartimento.st_reanalise = "S" Then 'Se rejeiad
                Me.hl_imprimir_ciqp.Visible = False
                Me.img_novo.Visible = False
                Me.btn_email.Visible = False
                Me.img_email.Visible = False
            End If

            If romaneio_uproducao.id_status_analise_uproducao > 0 Then
                cbo_registro_analise.SelectedValue = romaneio_uproducao.id_status_analise_uproducao
                cbo_registro_analise.Enabled = False
                btn_registrar.Enabled = False
                btn_registrar.ImageUrl = "~/img/bnt_registrar2_desabilitado.gif"
                Dim comand As CommandField = CType(gridResults.Columns.Item(8), CommandField)
                comand.ShowEditButton = False
            End If

            lbl_romaneio.Text = romaneio.id_romaneio.ToString
            ViewState.Item("id_romaneio") = romaneio.id_romaneio
            lbl_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            'Fran 23/11/2009 i Maracanau chamado 519
            Me.lbl_estabelecimento.Text = romaneio.ds_estabelecimento
            Me.lbl_nm_item.Text = romaneio.nm_item
            ViewState.Item("id_estabelecimento") = romaneio.id_estabelecimento
            'Fran 23/11/2009 f

            lbl_ds_compartimento.Text = romaneio_uproducao.ds_compartimento.ToString
            lbl_ds_placa_compartimento.Text = romaneio_uproducao.ds_placa.ToString
            lbl_ds_propriedade.Text = romaneio_uproducao.ds_propriedade
            lbl_ds_uproducao.Text = romaneio_uproducao.ds_uproducao
            lbl_dsprodutor.Text = romaneio_uproducao.ds_pessoa
            If Not (romaneio_uproducao.nm_status_analise_uproducao Is Nothing) Then
                lbl_nm_st_uproducao.Text = romaneio_uproducao.nm_status_analise_uproducao.ToString
            Else
                lbl_nm_st_uproducao.Text = "Não Cadastrado"
            End If
            If romaneio_uproducao.id_status_analise_uproducao > 0 Then
                cbo_registro_analise.SelectedValue = romaneio_uproducao.id_status_analise_uproducao
            End If

            'Carrega os dados do Grid
            Dim romaneio_analiseuproducao As New RomaneioAnaliseUProducao
            romaneio_analiseuproducao.id_romaneio_uproducao = romaneio_uproducao.id_romaneio_uproducao
            romaneio_analiseuproducao.id_romaneio = romaneio.id_romaneio
            Dim dsanaliseuproducao As DataSet = romaneio_analiseuproducao.getRomaneioAnalisesUProducaoByFilters

            If (dsanaliseuproducao.Tables(0).Rows.Count > 0) Then
                ViewState.Item("rejeitado") = "N"
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsanaliseuproducao.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                If romaneio_uproducao.id_status_analise_uproducao > 0 Then
                    cbo_registro_analise.SelectedValue = romaneio_uproducao.id_status_analise_uproducao
                    cbo_registro_analise.Enabled = False
                Else
                    If ViewState.Item("rejeitado") = "S" Then
                        cbo_registro_analise.SelectedValue = 3
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
            Dim romaneio_analiseuproducao As New RomaneioAnaliseUProducao
            romaneio_analiseuproducao.id_romaneio_uproducao = Convert.ToInt32(ViewState.Item("id_romaneio_uproducao"))
            romaneio_analiseuproducao.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

            Dim dsanaliseuproducao As DataSet = romaneio_analiseuproducao.getRomaneioAnalisesUProducaoByFilters

            If (dsanaliseuproducao.Tables(0).Rows.Count > 0) Then
                ViewState.Item("rejeitado") = "N"
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsanaliseuproducao.Tables(0), ViewState.Item("sortExpression"))
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

        loadData()

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

            If (Not (row) Is Nothing) Then

                Dim romaneioanaliseuproducao As New RomaneioAnaliseUProducao
                Dim id_formato_analise As Label = CType(row.FindControl("id_formato_analise"), Label)
                Dim txt_ds_comentario As TextBox = CType(row.FindControl("txt_ds_comentario"), TextBox)
                Dim nr_faixa_inicial As Label = CType(row.FindControl("lbl_nr_faixa_inicial"), Label)
                Dim nr_faixa_final As Label = CType(row.FindControl("lbl_nr_faixa_final"), Label)
                Dim id_faixa_referencia_logica As Label = CType(row.FindControl("lbl_faixa_logica"), Label)

                romaneioanaliseuproducao.id_analise_uproducao = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)
                romaneioanaliseuproducao.ds_comentario = txt_ds_comentario.Text.ToString
                romaneioanaliseuproducao.id_modificador = Session("id_login")

                Select Case Convert.ToInt32(id_formato_analise.Text.Trim.ToString)
                    Case 1 'Decimzl
                        Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        If Not (txt_dec_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                            romaneioanaliseuproducao.nr_valor = Convert.ToDecimal(txt_dec_nr_valor.Text.Trim)
                            If romaneioanaliseuproducao.nr_valor >= CDec(nr_faixa_inicial.Text) And romaneioanaliseuproducao.nr_valor <= CDec(nr_faixa_final.Text) Then
                                romaneioanaliseuproducao.id_st_analise = 1 'Aprovado
                            Else
                                romaneioanaliseuproducao.id_st_analise = 2 'Reprovado
                                ViewState.Item("rejeitado") = "S"
                            End If

                        End If

                    Case 2 'Inteiro
                        Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                        If Not (txt_int_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                            romaneioanaliseuproducao.nr_valor = Convert.ToDecimal(Convert.ToInt32(txt_int_nr_valor.Text))
                            If CLng(romaneioanaliseuproducao.nr_valor) >= CLng(nr_faixa_inicial.Text) And romaneioanaliseuproducao.nr_valor <= CLng(nr_faixa_final.Text) Then
                                romaneioanaliseuproducao.id_st_analise = 1 'Aprovado
                            Else
                                romaneioanaliseuproducao.id_st_analise = 2 'Reprovado
                                ViewState.Item("rejeitado") = "S"
                            End If

                        End If

                    Case 3 'Logico
                        Dim cbo_nr_valor As DropDownList = CType(row.FindControl("cbo_nr_valor"), DropDownList)
                        If Not (cbo_nr_valor.SelectedValue.Trim().Equals(String.Empty)) Then
                            romaneioanaliseuproducao.nr_valor = Convert.ToDecimal(Convert.ToInt32(cbo_nr_valor.SelectedValue))
                            If CLng(romaneioanaliseuproducao.nr_valor) = CLng(id_faixa_referencia_logica.Text) Then
                                romaneioanaliseuproducao.id_st_analise = 1 'Aprovado
                            Else
                                romaneioanaliseuproducao.id_st_analise = 2 'Reprovado
                                ViewState.Item("rejeitado") = "S"
                            End If

                        End If

                End Select
                'romaneioanaliseglobal.id_st_analise = Convert.ToInt32(txt_id_st_alnalise.Text.ToString)
                romaneioanaliseuproducao.updateRomaneioAnaliseUProducao()
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

    'Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated

    '    If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

    '        Try
    '            If Not (ViewState("label_nm_st_analise") Is Nothing) Then
    '                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    '                'COMBO STATUS ANALISE NO MODO EDIÇÂO
    '                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
    '                Dim cbo_id_st_analise As DropDownList = CType(e.Row.FindControl("cbo_id_st_analise"), DropDownList)

    '                Dim statusanalise As New StatusAnalise

    '                cbo_id_st_analise.DataSource = statusanalise.getStatusAnaliseByFilters()
    '                cbo_id_st_analise.DataTextField = "nm_st_analise"
    '                cbo_id_st_analise.DataValueField = "id_st_analise"
    '                cbo_id_st_analise.DataBind()

    '                If (ViewState("label_nm_st_analise").ToString.Equals(String.Empty)) Then
    '                    cbo_id_st_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
    '                    'cbo_id_st_analise.SelectedValue = -1
    '                    ViewState("label_nm_st_analise") = "SEM_VALOR" 'Assume que o nm_st_analise esta sem valor
    '                Else
    '                    cbo_id_st_analise.SelectedValue = cbo_id_st_analise.Items.FindByText(ViewState("label_nm_st_analise").Trim.ToString).Value
    '                    ViewState("label_nm_st_analise") = Nothing 'Assume que o nm_st_analise tem valor
    '                End If
    '                'ViewState("label_nm_st_analise") = String.Empty





    '            End If

    '        Catch ex As Exception
    '            messageControl.Alert(ex.Message)
    '        End Try

    '    End If
    'End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Edit", "Editar", "Cancel", "Cancelar", "Update"
                Return
        End Select
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                'If ViewState("label_nm_st_analise") = "SEM_VALOR" Then 'Assume que o nm_st_analise esta sem valor
                '    'Se já fez a criação  da linha e esta sem valor no combo situacao, força o 'Selecione'
                '    Dim cbo_id_st_analise As DropDownList = CType(e.Row.FindControl("cbo_id_st_analise"), DropDownList)
                '    If Not (cbo_id_st_analise Is Nothing) Then
                '        cbo_id_st_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                '    End If
                '    ViewState("label_nm_st_analise") = Nothing 'Assume que o nm_st_analise tem valor
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
                Dim lbl_id_grupo_descricao As Label = CType(e.Row.FindControl("lbl_id_grupo_descricao"), Label)

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
                    Case 3 ' Lógico
                        Dim cbo_nr_valor As DropDownList = CType(e.Row.FindControl("cbo_nr_valor"), DropDownList)
                        Dim rfv_cbo_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_cbo_nr_valor"), RequiredFieldValidator)
                        rfv_cbo_nr_valor.Visible = True
                        cbo_nr_valor.Visible = True
                        Dim analiselogica As New AnaliseLogica
                        analiselogica.id_grupo_descricao = lbl_id_grupo_descricao.Text.Trim 'fran 21/08/2009 i 
                        cbo_nr_valor.DataSource = analiselogica.getAnalisesLogicasByFilters
                        cbo_nr_valor.DataTextField = "nm_analise_logica"
                        cbo_nr_valor.DataValueField = "id_analise_logica"
                        cbo_nr_valor.DataBind()

                        If (ViewState.Item("lbl_nr_valor").ToString.Equals(String.Empty)) Then
                            cbo_nr_valor.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                            '                            ViewState("label_nr_valor") = "SEM_VALOR" 'Assume que o nm_st_analise esta sem valor
                        Else
                            'cbo_nr_valor.SelectedValue = cbo_nr_valor.Items.FindByText(ViewState.Item("lbl_nr_valor").Trim.ToString).Value
                            cbo_nr_valor.SelectedValue = ViewState.Item("lbl_nr_valor")
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
                Dim lbl_nr_valor As Label = CType(e.Row.FindControl("lbl_nr_valor"), Label)
                Dim lbl_nm_valor As Label = CType(e.Row.FindControl("lbl_nm_valor"), Label)
                Dim lbl_faixa_referencial As Label = CType(e.Row.FindControl("lbl_faixa_referencial"), Label)
                Dim lbl_faixa_referencia_logica As Label = CType(e.Row.FindControl("lbl_faixa_referencia_logica"), Label)
                Dim nr_faixa_inicial As Label = CType(e.Row.FindControl("lbl_nr_faixa_inicial"), Label)
                Dim nr_faixa_final As Label = CType(e.Row.FindControl("lbl_nr_faixa_final"), Label)
                Dim nm_st_analise As Label = CType(e.Row.FindControl("lbl_nm_st_analise"), Label)

                If Not nm_st_analise Is Nothing Then
                    If nm_st_analise.Text = "Rejeitado" Then
                        ViewState.Item("rejeitado") = "S"
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
                    Case 3 ' Lógico
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

                        Case 3 ' Lógico
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
        If ViewState.Item("nm_tela").Equals(String.Empty) Then
            Response.Redirect("lst_romaneio_analises_uproducao.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString)
        Else
            Response.Redirect("lst_romaneio_analises_uproducao.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString + "&nm_tela=" + ViewState.Item("nm_tela").ToString)
        End If


    End Sub


    Protected Sub btn_registrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_registrar.Click
        If Page.IsValid Then

            Try

                If CInt(Me.cbo_registro_analise.SelectedValue) = 1 Then
                    RegistrarAnaliseUProducaoAprovada()
                Else
                    RegistrarAnaliseUProducaoRejeitada(CInt(Me.cbo_registro_analise.SelectedValue))
                End If
                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
    Private Sub RegistrarAnaliseUProducaoRejeitada(ByVal id_st_analise_uproducao As Int32)
        If Page.IsValid = True Then

            Try

                Dim romaneiouproducao As New Romaneio_Comp_UProducao(Convert.ToInt32(ViewState.Item("id_romaneio_uproducao")))

                romaneiouproducao.id_status_analise_uproducao = id_st_analise_uproducao 'Aprovado sob Concessao ou Rejeitado
                romaneiouproducao.id_modificador = Session("id_login")

                romaneiouproducao.registrarStatusAnaliseUProducao()
                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
    Private Sub RegistrarAnaliseUProducaoAprovada()
        If Page.IsValid = True Then

            Try
                Dim romaneiouproducao As New Romaneio_Comp_UProducao(Convert.ToInt32(ViewState.Item("id_romaneio_uproducao")))

                romaneiouproducao.id_status_analise_uproducao = 1 'Aprovada
                romaneiouproducao.id_modificador = Session("id_login")

                romaneiouproducao.registrarStatusAnaliseUProducao()
                loadData()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If


    End Sub
    Protected Sub cv_verificarrejeitadas_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_verificarrejeitadas.ServerValidate
        Dim analise As New RomaneioAnaliseUProducao
        Dim liresult As Int32
        Dim lsvaluecbo As Integer
        Dim lmsg As String

        args.IsValid = True
        If Not cbo_registro_analise.SelectedValue.Equals(String.Empty) Then
            lsvaluecbo = CInt(cbo_registro_analise.SelectedValue)
            analise.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            analise.id_romaneio_uproducao = Convert.ToInt32(ViewState.Item("id_romaneio_uproducao"))
            'Se tem alguma obrigatoria rejeitada, o cbo não pode ser registro de aprovada
            liresult = analise.getRomaneioAnaliseUProducaoRejeitada()

            'Se tem rejeitadas....
            If liresult > 0 Then
                If lsvaluecbo = 1 Then
                    args.IsValid = False
                    lmsg = "Você não pode registrar a análise da Unid Produção/Produtor como 'APROVADA' porque, há análises obrigatórias com situação 'REJEITADA'"
                End If
            Else 'se não tem rejeitadas
                If lsvaluecbo <> 1 Then
                    args.IsValid = False
                    lmsg = "A análise desta Unid Produção/Produtor só pode ser registrada como 'APROVADA' pois não há registro de análises obrigatórias com situação 'REJEITADA'"
                End If
            End If
            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        End If
    End Sub
    Protected Sub cv_st_analises_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_st_analises.ServerValidate

        Dim analisecomp As New RomaneioAnaliseUProducao
        analisecomp.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
        analisecomp.id_romaneio_uproducao = Convert.ToInt32(ViewState.Item("id_romaneio_uproducao"))
        'Busaca as analise obrigatorias, reanalise <> S e statuscompartimento vazio
        If analisecomp.getRomaneioAnaliseUProducaoSemResultado() > 0 Then
            args.IsValid = False
        Else
            args.IsValid = True
        End If

        If args.IsValid = False Then
            messageControl.Alert("Para registrar o resultado desta análise de unid. produção/produtor, todas as análises obrigatórias devem ser informadas.")
        End If
    End Sub

    Protected Sub btn_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_email.Click
        If Page.IsValid = True Then
            Try


                Dim notificacao As New Notificacao
                Dim lAssunto As String = "RELATÓRIO CIQP " & ViewState.Item("id_romaneio_uproducao").ToString
                'Dim lCorpo As String = "Existe uma ocorrência ao produtor relatada através do Relatório CIQP, que pode ser visualizado pelo link http://localhost:56946/Danone.MilkSystem.Web/frm_relatorio_CIQP.aspx?id_romaneio_uproducao=" & ViewState.Item("id_romaneio_uproducao").ToString & " ."
                Dim lCorpo As String = "Existe uma ocorrência ao produtor relatada através do Relatório CIQP, que pode ser visualizado pelo link " & ViewState.Item("caminho_servidor") & "/frm_relatorio_CIQP.aspx?id_romaneio_uproducao=" & ViewState.Item("id_romaneio_uproducao").ToString & " ."

                ' 29/09/2008 - i
                Dim email_tecnico As String
                email_tecnico = ""
                If ViewState.Item("id_tecnico") > 0 Then
                    Dim tecnico As New Tecnico(Convert.ToInt32(ViewState.Item("id_tecnico")))
                    email_tecnico = tecnico.ds_email
                End If
                ' 29/09/2008 - f

                'fran 25/11/2009 i  maracanau chamado 518
                ' 29/09/2008 (incluido o email_tecnico)
                'If notificacao.enviaMensagemEmail(2, lAssunto, lCorpo, MailPriority.High, email_tecnico ) = True Then
                If notificacao.enviaMensagemEmail(2, lAssunto, lCorpo, MailPriority.High, email_tecnico, , Convert.ToInt32(ViewState.Item("id_estabelecimento"))) = True Then
                    'fran 25/11/2009 f
                    messageControl.Alert("O Relatório CIQP foi enviado aos destinatários cadastrados com sucesso!")
                Else

                    messageControl.Alert("O Relatório CIQP não pode ser enviado pois não há emails cadastrados para este relatório.")

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        End If

    End Sub
End Class
