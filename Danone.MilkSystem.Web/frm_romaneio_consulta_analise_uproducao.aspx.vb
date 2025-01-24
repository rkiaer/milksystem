Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_romaneio_consulta_analise_uproducao
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
                'Verifica se deve mudar titulo da pagina, caso a tela chamadora (consulta romaneio placa) tiver trocado titulo
                If Not (customPage.getFilterValue("frm_rconsplaca", "titulo").Equals(String.Empty)) Then
                    lbl_titulo.Text = customPage.getFilterValue("frm_rconsplaca", "titulo") & " - Consulta das Análises das Unid.Produção/Produtores por Compartimento"
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

            Dim id_romaneio_compartimento As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento"))
            'Dim id_romaneio_uproducao As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_uproducao"))
            'Dim romaneio_uproducao As New Romaneio_Comp_UProducao(Convert.ToInt32(ViewState.Item("id_romaneio_uproducao")))


            'Carrega os dados do Grid
            Dim romaneio_uproducao As New Romaneio_Comp_UProducao
            romaneio_uproducao.id_romaneio_compartimento = id_romaneio_compartimento
            Dim dsuproducao As DataSet = romaneio_uproducao.getRomaneio_Comp_UProducaoByFilters
            ViewState.Item("sortExpression") = "nr_compartimento ASC, id_propriedade ASC, nr_unid_producao ASC,cd_pessoa ASC"
            If (dsuproducao.Tables(0).Rows.Count > 0) Then
                ViewState.Item("id_romaneio_uproducao") = dsuproducao.Tables(0).Rows(0).Item("id_romaneio_uproducao")
                ViewState.Item("id_romaneio") = dsuproducao.Tables(0).Rows(0).Item("id_romaneio")
                gridCompartimento.Visible = True
                gridCompartimento.DataSource = Helper.getDataView(dsuproducao.Tables(0), ViewState.Item("sortExpression"))
                gridCompartimento.DataBind()
            Else
                gridCompartimento.Visible = False
            End If


            '            If romaneio_uproducao.id_status_analise_uproducao = 3 Then 'Se rejeiad
            'Me.hl_imprimir_ciqp.NavigateUrl = String.Format("frm_relatorio_CIQP.aspx?id_romaneio_uproducao={0}", romaneio_uproducao.id_romaneio_uproducao.ToString)
            'Me.hl_imprimir_ciqp.Enabled = True
            ''                Me.btn_email.Enabled = True'

            'End If
            'Dim romaneio_compartimento As New Romaneio_Compartimento(romaneio_uproducao.id_romaneio_compartimento)
            'If romaneio_compartimento.st_reanalise = "S" Then 'Se rejeiad
            ' Me.hl_imprimir_ciqp.Visible = False
            ' Me.img_novo.Visible = False
            '               Me.btn_email.Visible = False
            '              Me.img_email.Visible = False
            'End If

            Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))
            lbl_romaneio.Text = romaneio.id_romaneio.ToString
            ViewState.Item("id_romaneio") = romaneio.id_romaneio
            lbl_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            'fran 20/02/2017 i se é um pre-romaneio de transit point i
            If romaneio.id_transit_point_unidade > 0 Then
                lbl_titulo.Text = "Consulta do Pré-Romaneio para Transit Point - Análises das Unidades de Produção/Produtores por Compartimento "
                pnl_romaneio.GroupingText = "Dados Pré-Romaneio"
                lbl_titulo_romaneio.Text = "Nr. Pré-Romaneio"
                lbl_titulo_situacao.Text = "Situação Pré-Romaneio"
            End If
            'fran 20/02/2017 i se é um pre-romaneio de transit point f

            'If Not (romaneio_uproducao.nm_status_analise_uproducao Is Nothing) Then
            '    lbl_nm_st_uproducao.Text = romaneio_uproducao.nm_status_analise_uproducao.ToString
            'Else
            '    lbl_nm_st_uproducao.Text = "Não Cadastrado"
            'End If

            'Carrega os dados do Grid
            Dim romaneio_analiseuproducao As New RomaneioAnaliseUProducao
            romaneio_analiseuproducao.id_romaneio_uproducao = Convert.ToInt32(ViewState.Item("id_romaneio_uproducao"))
            romaneio_analiseuproducao.id_romaneio = romaneio.id_romaneio
            Dim dsanaliseuproducao As DataSet = romaneio_analiseuproducao.getRomaneioAnalisesUProducaoByFilters
            ViewState.Item("sortExpression") = ""
            If (dsanaliseuproducao.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsanaliseuproducao.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    'Private Sub loadData()

    '    Try

    '        Dim id_romaneio_uproducao As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_uproducao"))
    '        Dim romaneio_uproducao As New Romaneio_Comp_UProducao(Convert.ToInt32(ViewState.Item("id_romaneio_uproducao")))
    '        Dim romaneio As New Romaneio(romaneio_uproducao.id_romaneio)

    '        ViewState.Item("id_tecnico") = romaneio_uproducao.id_tecnico   ' 29/09/2008 - Guarda id_tecnico para envio de email CIQP

    '        If romaneio_uproducao.id_status_analise_uproducao = 3 Then 'Se rejeiad
    '            Me.hl_imprimir_ciqp.NavigateUrl = String.Format("frm_relatorio_CIQP.aspx?id_romaneio_uproducao={0}", romaneio_uproducao.id_romaneio_uproducao.ToString)
    '            Me.hl_imprimir_ciqp.Enabled = True
    '            '                Me.btn_email.Enabled = True

    '        End If
    '        Dim romaneio_compartimento As New Romaneio_Compartimento(romaneio_uproducao.id_romaneio_compartimento)
    '        If romaneio_compartimento.st_reanalise = "S" Then 'Se rejeiad
    '            Me.hl_imprimir_ciqp.Visible = False
    '            Me.img_novo.Visible = False
    '            '               Me.btn_email.Visible = False
    '            '              Me.img_email.Visible = False
    '        End If


    '        lbl_romaneio.Text = romaneio.id_romaneio.ToString
    '        ViewState.Item("id_romaneio") = romaneio.id_romaneio
    '        lbl_st_romaneio.Text = romaneio.nm_st_romaneio.ToString

    '        lbl_ds_compartimento.Text = romaneio_uproducao.ds_compartimento.ToString
    '        lbl_ds_placa_compartimento.Text = romaneio_uproducao.ds_placa.ToString
    '        lbl_ds_propriedade.Text = romaneio_uproducao.ds_propriedade
    '        lbl_ds_uproducao.Text = romaneio_uproducao.ds_uproducao
    '        lbl_dsprodutor.Text = romaneio_uproducao.ds_pessoa
    '        If Not (romaneio_uproducao.nm_status_analise_uproducao Is Nothing) Then
    '            lbl_nm_st_uproducao.Text = romaneio_uproducao.nm_status_analise_uproducao.ToString
    '        Else
    '            lbl_nm_st_uproducao.Text = "Não Cadastrado"
    '        End If

    '        'Carrega os dados do Grid
    '        Dim romaneio_analiseuproducao As New RomaneioAnaliseUProducao
    '        romaneio_analiseuproducao.id_romaneio_uproducao = romaneio_uproducao.id_romaneio_uproducao
    '        romaneio_analiseuproducao.id_romaneio = romaneio.id_romaneio
    '        Dim dsanaliseuproducao As DataSet = romaneio_analiseuproducao.getRomaneioAnalisesUProducaoByFilters

    '        If (dsanaliseuproducao.Tables(0).Rows.Count > 0) Then
    '            gridResults.Visible = True
    '            gridResults.DataSource = Helper.getDataView(dsanaliseuproducao.Tables(0), ViewState.Item("sortExpression"))
    '            gridResults.DataBind()
    '        Else
    '            gridResults.Visible = False
    '        End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    Private Sub loadGridView()

        Try
            'Carrega os dados do Grid
            Dim romaneio_analiseuproducao As New RomaneioAnaliseUProducao
            romaneio_analiseuproducao.id_romaneio_uproducao = Convert.ToInt32(ViewState.Item("id_romaneio_uproducao"))
            romaneio_analiseuproducao.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

            Dim dsanaliseuproducao As DataSet = romaneio_analiseuproducao.getRomaneioAnalisesUProducaoByFilters

            If (dsanaliseuproducao.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsanaliseuproducao.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

            Else
                gridResults.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadGridProdutores()

        Try
            Dim romaneio_uproducao As New Romaneio_Comp_UProducao
            romaneio_uproducao.id_romaneio_compartimento = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento"))
            Dim dsuproducao As DataSet = romaneio_uproducao.getRomaneio_Comp_UProducaoByFilters
            ViewState.Item("sortExpression") = "nr_compartimento ASC, id_propriedade ASC, nr_unid_producao ASC,cd_pessoa ASC"
            If (dsuproducao.Tables(0).Rows.Count > 0) Then
                'ViewState.Item("id_romaneio_uproducao") = dsuproducao.Tables(0).Rows(0).Item("id_romaneio_uproducao")
                'ViewState.Item("id_romaneio") = dsuproducao.Tables(0).Rows(0).Item("id_romaneio")
                gridCompartimento.Visible = True
                gridCompartimento.DataSource = Helper.getDataView(dsuproducao.Tables(0), ViewState.Item("sortExpression"))
                gridCompartimento.DataBind()
            Else
                gridCompartimento.Visible = False
            End If
            ViewState.Item("sortExpression") = ""
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
        Response.Redirect("frm_romaneio_consulta_analise.aspx?id_romaneio_compartimento=" + ViewState.Item("id_romaneio_compartimento").ToString)

    End Sub

    Protected Sub gridCompartimento_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridCompartimento.PageIndexChanging
        gridCompartimento.PageIndex = e.NewPageIndex
        loadGridProdutores()

    End Sub

    Protected Sub gridCompartimento_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridCompartimento.RowCommand
        Select Case e.CommandName.ToString().ToLower()
            Case "analises"
                '                saveFilters()
                ViewState.Item("id_romaneio_uproducao") = e.CommandArgument.ToString
                loadGridView()
                loadGridProdutores()
        End Select

    End Sub
    Protected Sub gridCompartimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCompartimento.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try

                'Dim lbl_st_reanalise As Label = CType(e.Row.FindControl("lbl_st_reanalise"), Label)
                'Dim img_reanalise As Image = CType(e.Row.FindControl("img_reanalise"), Image)
                'Dim lbl_st_registro As Label = CType(e.Row.FindControl("lbl_st_registro"), Label)


                ''Se o romaneio compartimento é reanalise
                'If lbl_st_reanalise.Text.Trim = "S" Then
                '    img_reanalise.ImageUrl = "~/img/ico_chk_true.gif"
                'Else
                '    img_reanalise.ImageUrl = "~/img/ico_chk_false.gif"
                'End If
                If CLng(gridCompartimento.DataKeys.Item(e.Row.RowIndex).Value) = CLng(ViewState.Item("id_romaneio_uproducao")) Then

                    e.Row.ForeColor = Drawing.Color.Red
                Else

                    e.Row.ForeColor = System.Drawing.Color.FromName("#333333")
                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

End Class
