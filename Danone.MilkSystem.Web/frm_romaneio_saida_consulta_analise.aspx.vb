Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_romaneio_saida_consulta_analise
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_saida_consulta_analise.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio_saida_compartimento") Is Nothing) Then
                ViewState.Item("id_romaneio_saida_compartimento") = Request("id_romaneio_saida_compartimento")

                ''Verifica se deve mudar titulo da pagina, caso a tela chamadora (consulta romaneio placa) tiver trocado titulo
                'If Not (customPage.getFilterValue("frm_rconsplaca", "titulo").Equals(String.Empty)) Then
                '    lbl_titulo.Text = customPage.getFilterValue("frm_rconsplaca", "titulo") & " - Consulta das Análises do Compartimento"
                'End If


                loadData()

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
            Dim dsanalisecompartimento As DataSet
            Dim id_romaneiosaidacompartimento As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_saida_compartimento"))
            Dim romaneio_compartimento As New RomaneioSaidaCompartimento(id_romaneiosaidacompartimento)
            ViewState.Item("id_romaneio_saida") = romaneio_compartimento.id_romaneio_saida
            Dim romaneio As New RomaneioSaida(Convert.ToInt32(ViewState.Item("id_romaneio_saida")))

            If romaneio_compartimento.id_st_analise = 3 Then 'Se rejeiad
            End If

            lbl_romaneio.Text = romaneio.id_romaneio_saida.ToString
            lbl_st_romaneio.Text = romaneio.nm_situacao_romaneio_saida.ToString
            lbl_ds_compartimento.Text = romaneio_compartimento.ds_compartimento.ToString
            lbl_ds_placa_compartimento.Text = romaneio_compartimento.ds_placa.ToString
            lbl_nm_st_compartimento.Text = romaneio_compartimento.nm_st_analise.ToString

            lbl_nm_analista.Text = romaneio_compartimento.nm_analista
            If Not romaneio_compartimento.dt_inicio_analise Is Nothing Then
                lbl_dt_inicio_analise.Text = Format(DateTime.Parse(romaneio_compartimento.dt_inicio_analise), "dd/MM/yyyy HH:mm")
            End If

            If romaneio_compartimento.id_st_analise > 0 Then
                If romaneio_compartimento.id_st_analise = 2 Then
                    lbl_labelmotivo.Visible = True
                    txt_ds_motivo_aprovado_sob_concessao.Visible = True
                    txt_ds_motivo_aprovado_sob_concessao.Text = romaneio_compartimento.ds_motivo_aprovado_sob_concessao
                    txt_ds_motivo_aprovado_sob_concessao.Enabled = False
                End If
                '                btn_registrar.Enabled = False
            End If

            'Carrega os dados do Grid
            Dim romaneio_analisecompartimento As New RomaneioSaidaAnaliseCompartimento
            romaneio_analisecompartimento.id_romaneio_saida = romaneio_compartimento.id_romaneio_saida
            romaneio_analisecompartimento.id_romaneio_saida_compartimento = id_romaneiosaidacompartimento

            dsanalisecompartimento = romaneio_analisecompartimento.getRomaneioSaidaAnaliseCompartimentoByFilters()

            ViewState.Item("rejeitado") = "N"

            If (dsanalisecompartimento.Tables(0).Rows.Count > 0) Then

                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsanalisecompartimento.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
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
            Dim romaneio_analisecompartimento As New RomaneioSaidaAnaliseCompartimento
            romaneio_analisecompartimento.id_romaneio_saida_compartimento = Convert.ToInt32(ViewState.Item("id_romaneio_saida_compartimento"))
            romaneio_analisecompartimento.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))

            Dim dsanalisecompartimento As DataSet = romaneio_analisecompartimento.getRomaneioSaidaAnaliseCompartimentoByFilters()

            If (dsanalisecompartimento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsanalisecompartimento.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

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





    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                'If ViewState.Item("label_nm_st_analise") = "SEM_VALOR" Then 'Assume que o nm_st_analise esta sem valor
                '    'Se já fez a criação  da linha e esta sem valor no combo situacao, força o 'Selecione'
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
        Response.Redirect("frm_romaneio_saida_consulta.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida").ToString)

    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("frm_romaneio_saida_consulta.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida").ToString)

    End Sub

 
End Class
