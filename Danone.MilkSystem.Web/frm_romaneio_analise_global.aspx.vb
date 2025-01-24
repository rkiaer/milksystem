Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_romaneio_analise_global
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

            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                loadData()
            Else
                messageControl.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
            End If


            'ViewState.Item("sortExpression") = "ds_produtor asc"


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadData()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio"))
            Dim romaneio As New Romaneio(id_romaneio)

            lbl_romaneio.Text = romaneio.id_romaneio.ToString
            lbl_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            lbl_estabelecimento.Text = romaneio.ds_estabelecimento.ToString
            lbl_transportador.Text = romaneio.ds_transportador.ToString

            lbl_dt_entrada.Text = FormatDateTime(romaneio.dt_hora_entrada, DateFormat.GeneralDate).ToString
            If Not (romaneio.dt_hora_saida Is Nothing) Then
                lbl_saida.Text = FormatDateTime(romaneio.dt_hora_saida, DateFormat.GeneralDate).ToString
            Else
                lbl_saida.Text = ""
            End If
            'lbl_nm_st_analise_global.Text = romaneio.nm_st_analise_global.ToString
            lbl_nm_st_analise_compartimento.Text = romaneio.nm_st_analise_compartimento.ToString
            lbl_nm_st_analise_uproducao.Text = romaneio.nm_st_analise_uproducao.ToString

            If romaneio.id_st_analise_global = 1 Then 'Nagativa
                lk_registrar_analise.Text = "Registrar Análise Global Positiva"
                lbl_status_botao.Text = "Positivo"
            Else
                lk_registrar_analise.Text = "Registrar Análise Global Negativa"
                lbl_status_botao.Text = "Negativo"
            End If

            'Carrega os dados do Grid
            Dim romaneio_analiseglobal As New RomaneioAnaliseGlobal
            romaneio_analiseglobal.id_romaneio = id_romaneio

            Dim dsanaliseglobal As DataSet = romaneio_analiseglobal.getRomaneioAnaliseGlobalByFilters()

            If (dsanaliseglobal.Tables(0).Rows.Count > 0) Then

                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsanaliseglobal.Tables(0), ViewState.Item("sortExpression"))
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
            Dim romaneio_analiseglobal As New RomaneioAnaliseGlobal
            romaneio_analiseglobal.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

            Dim dsanaliseglobal As DataSet = romaneio_analiseglobal.getRomaneioAnaliseGlobalByFilters()

            If (dsanaliseglobal.Tables(0).Rows.Count > 0) Then

                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsanaliseglobal.Tables(0), ViewState.Item("sortExpression"))
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
        loadData()

    End Sub


    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()



            Case "id_analise"
                If (ViewState.Item("sortExpression")) = "id_analise asc" Then
                    ViewState.Item("sortExpression") = "id_analise desc"
                Else
                    ViewState.Item("sortExpression") = "id_analise asc"
                End If


            Case "nm_analise"
                If (ViewState.Item("sortExpression")) = "nm_analise asc" Then
                    ViewState.Item("sortExpression") = "nm_analise desc"
                Else
                    ViewState.Item("sortExpression") = "nm_analise asc"
                End If

            Case "ds_faixa"
                If (ViewState.Item("sortExpression")) = "ds_faixa asc" Then
                    ViewState.Item("sortExpression") = "ds_faixa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_faixa asc"
                End If

            Case "nm_tipo_analise"
                If (ViewState.Item("sortExpression")) = "nm_tipo_analise asc" Then
                    ViewState.Item("sortExpression") = "nm_tipo_analise desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tipo_analise asc"
                End If

        End Select

        loadData()

    End Sub

    'Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    '      If (e.Row.RowType <> DataControlRowType.Header _
    '         And e.Row.RowType <> DataControlRowType.Footer _
    '        And e.Row.RowType <> DataControlRowType.Pager) Then

    ' ''    'If (e.Row.Cells(4).Text.Trim().Equals("1")) Then
    ' ''    '    e.Row.Cells(4).Text = "Calculado com Erro"
    ' ''    'Else
    ' ''    '    If (e.Row.Cells(4).Text.Trim().Equals("2")) Then
    ' ''    '        e.Row.Cells(4).Text = "Calculado com Sucesso"
    ' ''    '    Else
    ' ''    '        e.Row.Cells(4).Text = "Já calculado"
    ' ''    '    End If
    ' ''    'End If
    ' ''    'If e.Row.RowState.ToString <> "Normal" And e.Row.RowState.ToString <> "Alternate" Then
    ' ''    '    'Dim lblteste As Label = DirectCast(FindControl(lblsituacao.id), Label)
    ' ''    '    e.Row.Cells(5).Text = "OK"
    ' ''    '    '                e.Row.Cells(5).r()
    ' ''    '    If e.Row.RowType = DataControlRowType.DataRow Then
    ' ''    '        Dim ddl As TextBox = DirectCast(e.Row.FindControl("lblsituacao"), TextBox)
    ' ''    '        ddl.Text = "texto"
    ' ''    '    End If



    ' ''    'End If
    ' ''    'condicao IF que exibe os dados no GridView (estado: não-editável)
    ' ''    'dados que vem de um relacionamento, e que vc queira exibir a descricao 
    ' ''    'e não o código. 
    ' ''    'If (e.Row.RowState.ToString = "Normal") Or (e.Row.RowState.ToString = "Alternate") Then
    ' ''    '    Dim lbl_nm_st_analise As Label = CType(e.Row.FindControl("lbl_nm_st_analise"), Label)

    ' ''    'End If
    ' ''    If Not (e.Row.RowState And DataControlRowState.Edit) <> DataControlRowState.Edit Then
    '' ''Dim cbo_id_st_analise As DropDownList = CType(e.Row.FindControl("cbo_id_st_analise"), DropDownList)
    '' ''If Not (cbo_id_st_analise Is Nothing) Then
    '' ''    Dim lista As ListControl = cbo_id_st_analise
    '' ''    'If (lista.GetType.Name = "DropDownList") Then
    '' ''    '    If (Not (lista.Items.FindByValue(valor)) <> NULL) Then
    '' ''    '        lista.SelectedValue = valor

    '' ''    '    Else
    '' ''    '        Dim listaItemAtual As ListItem = lista.Items.FindByValue(valor)
    '' ''    '        If (Not (listaItemAtual) Is Nothing) Then
    '' ''    '            listaItemAtual.Selected = True
    '' ''    '        End If
    '' ''    '    End If
    '' ''    'End If
    '' ''    Dim teste As VariantType = DataBinder.Eval(e.Row.DataItem, "id_st_analise").ToString()
    '' ''End If
    'If cbo_id_st_analise.Then Then
    ' ''        Dim statusanalise As New StatusAnalise
    ' ''        cbo_id_st_analise.DataSource = statusanalise.getStatusAnaliseByFilters()
    ' ''        cbo_id_st_analise.DataTextField = "nm_st_analise"
    ' ''        cbo_id_st_analise.DataValueField = "id_st_analise"
    ' ''        cbo_id_st_analise.DataBind()

    ' ''        If (cbo_id_st_analise.SelectedValue.ToString.Equals(String.Empty)) Then
    ' ''            cbo_id_st_analise.Items.Insert(0, New ListItem("[Selecione]", "0"))
    ' ''        End If

    ' ''    End If
    ' ''    If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then


    ' ''        Dim cbo_id_st_analise As DropDownList = CType(e.Row.FindControl("cbo_id_st_analise"), DropDownList)
    ' ''        'busca o seu controle e define a mensagem.
    ' ''    End If

    '        End If

    '   End Sub



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

            Dim romaneio As New Romaneio(ViewState.Item("id_romaneio"))
            If romaneio.id_st_romaneio < 3 Then
                romaneio.id_st_romaneio = 3
                romaneio.id_modificador = Session("id_login")
                romaneio.updateRomaneioSituacao()
            End If

            Dim lbl_nm_st_analise As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_nm_st_analise"), Label)
            ViewState.Item("label_nm_st_analise") = Trim(lbl_nm_st_analise.Text)
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

                Dim romaneioanaliseglobal As New RomaneioAnaliseGlobal
                Dim id_formato_analise As Label = CType(row.FindControl("id_formato_analise"), Label)
                Dim cbo_id_st_analise As DropDownList = CType(row.FindControl("cbo_id_st_analise"), DropDownList)

                romaneioanaliseglobal.id_analise_global = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)

                If Not (cbo_id_st_analise.SelectedValue.Trim().Equals(String.Empty)) Then
                    romaneioanaliseglobal.id_st_analise = Convert.ToInt32(cbo_id_st_analise.SelectedValue)
                End If
                romaneioanaliseglobal.id_modificador = Session("id_login")

                Select Case Convert.ToInt32(id_formato_analise.Text.Trim.ToString)
                    Case 1 'Descimal
                        Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        If Not (txt_dec_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                            romaneioanaliseglobal.nr_valor = Convert.ToDecimal(txt_dec_nr_valor.Text.Trim)
                        End If

                    Case 2 'Inteiro
                        Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                        If Not (txt_int_nr_valor.Text.Trim.ToString.Equals(String.Empty)) Then
                            romaneioanaliseglobal.nr_valor = Convert.ToDecimal(Convert.ToInt32(txt_int_nr_valor.Text))
                        End If

                    Case 3 'Logico
                        Dim cbo_nr_valor As DropDownList = CType(row.FindControl("cbo_nr_valor"), DropDownList)
                        If Not (cbo_nr_valor.SelectedValue.Trim().Equals(String.Empty)) Then
                            romaneioanaliseglobal.nr_valor = Convert.ToDecimal(Convert.ToInt32(cbo_nr_valor.SelectedValue))
                        End If

                End Select
                'romaneioanaliseglobal.id_st_analise = Convert.ToInt32(txt_id_st_alnalise.Text.ToString)
                romaneioanaliseglobal.updateRomaneioAnaliseGlobal()


                gridResults.EditIndex = -1
                loadGridView()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated

        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            Try
                If Not (ViewState.Item("label_nm_st_analise") Is Nothing) Then
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    'COMBO STATUS ANALISE NO MODO EDIÇÂO
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    Dim cbo_id_st_analise As DropDownList = CType(e.Row.FindControl("cbo_id_st_analise"), DropDownList)

                    Dim statusanalise As New StatusAnalise

                    cbo_id_st_analise.DataSource = statusanalise.getStatusAnaliseByFilters()
                    cbo_id_st_analise.DataTextField = "nm_st_analise"
                    cbo_id_st_analise.DataValueField = "id_st_analise"
                    cbo_id_st_analise.DataBind()

                    If (ViewState.Item("label_nm_st_analise").ToString.Equals(String.Empty)) Then
                        cbo_id_st_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        'cbo_id_st_analise.SelectedValue = -1
                        ViewState.Item("label_nm_st_analise") = "SEM_VALOR" 'Assume que o nm_st_analise esta sem valor
                    Else
                        cbo_id_st_analise.SelectedValue = cbo_id_st_analise.Items.FindByText(ViewState.Item("label_nm_st_analise").Trim.ToString).Value
                        ViewState.Item("label_nm_st_analise") = Nothing 'Assume que o nm_st_analise tem valor
                    End If
                    'ViewState("label_nm_st_analise") = String.Empty


                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
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
                If ViewState.Item("label_nm_st_analise") = "SEM_VALOR" Then 'Assume que o nm_st_analise esta sem valor
                    'Se já fez a criação  da linha e esta sem valor no combo situacao, força o 'Selecione'
                    Dim cbo_id_st_analise As DropDownList = CType(e.Row.FindControl("cbo_id_st_analise"), DropDownList)
                    If Not (cbo_id_st_analise Is Nothing) Then
                        cbo_id_st_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    End If
                    ViewState.Item("label_nm_st_analise") = Nothing 'Assume que o nm_st_analise tem valor
                End If
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'CAMPO VALOR
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'Verifica qual o formato da analise para montar o campo correto
                Dim id_formato_analise As Label = CType(e.Row.FindControl("id_formato_analise"), Label)
                Select Case Convert.ToInt32(id_formato_analise.Text.Trim)
                    Case 1 'Decimal
                        Dim txt_dec_nr_valor As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_dec_nr_valor"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim rfv_txt_dec_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_txt_dec_nr_valor"), RequiredFieldValidator)
                        rfv_txt_dec_nr_valor.Visible = True
                        txt_dec_nr_valor.Visible = True
                        If Not (ViewState.Item("lbl_nr_valor").ToString.Equals(String.Empty)) Then
                            txt_dec_nr_valor.Text = CStr(CDec(ViewState.Item("lbl_nr_valor").ToString))
                        End If
                    Case 2 'Inteiro
                        Dim txt_int_nr_valor As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_int_nr_valor"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                        Dim rfv_txt_int_nr_valor As RequiredFieldValidator = CType(e.Row.FindControl("rfv_txt_int_nr_valor"), RequiredFieldValidator)
                        txt_int_nr_valor.Visible = True
                        rfv_txt_int_nr_valor.Visible = True
                        If Not (ViewState.Item("lbl_nr_valor").ToString.Equals(String.Empty)) Then
                            txt_int_nr_valor.Text = CStr(CLng(ViewState.Item("lbl_nr_valor")))
                        End If
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
                            cbo_nr_valor.SelectedValue = CInt(ViewState.Item("lbl_nr_valor").Trim)
                            'ViewState("label_nr_valor") = Nothing 'Assume que o nm_st_analise tem valor
                        End If
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
                Dim lsaux As String
                lsaux = lbl_nr_valor.Text
                If Not (lbl_nr_valor.Text.ToString.Equals(String.Empty)) Then
                    Select Case Convert.ToInt32(id_formato_analise.Text.Trim)
                        Case 1 'Decimal
                            lbl_nr_valor.Text = CStr(CDec(lbl_nr_valor.Text))
                        Case 2 'Inteiro
                            lsaux = Convert.ToString(CInt(lsaux))
                            lbl_nr_valor.Text = CStr(CInt(lbl_nr_valor.Text))
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
        Response.Redirect("lst_romaneio_analises.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString)


    End Sub

    Private Sub RegistrarAnaliseGlobalPositiva()
        If Page.IsValid = True Then

            Try

                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                romaneio.id_st_analise_global = 2 'Positiva
                romaneio.id_modificador = Session("id_login")

                Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento
                romaneioanalisecompartimento.id_romaneio = romaneio.id_romaneio

                Dim dsanalisecompartimento As DataSet = romaneioanalisecompartimento.getRomaneioAnalisesCompartimentosByFilters()

                If (dsanalisecompartimento.Tables(0).Rows.Count > 0) Then
                    'se ja tem linhas apenas atualiza o status do romaneio
                    romaneio.updateRomaneioStatusAnaliseGlobal()
                Else
                    'Se não tem linhas cria as analises compartiemtno
                    romaneio.registrarAnaliseGlobalPositiva()
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
    Private Sub RegistrarAnaliseGlobalNegativa()
        If Page.IsValid = True Then

            Try

                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                romaneio.id_st_analise_global = 1 'Negativa
                romaneio.id_modificador = Session("id_login")
                romaneio.updateRomaneioStatusAnaliseGlobal()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub lk_registrar_analise_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_registrar_analise.Click
        Try
            If lbl_status_botao.Text.Trim = "Positivo" Then
                'Vai passar o botão para negativo, só muda a imagem pois os cadastros já estão incluidos
                lk_registrar_analise.Text = "Registrar Análise Global Negativa"
                lbl_status_botao.Text = "Negativo"
                Me.RegistrarAnaliseGlobalPositiva()
                loadData()
            Else
                'Vai passar o botão para positivo, só muda a imagem pois os cadastros já estão incluidos
                lk_registrar_analise.Text = "Registrar Análise Global Positiva"
                lbl_status_botao.Text = "Positivo"
                Me.RegistrarAnaliseGlobalNegativa()
                loadData()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub
End Class
