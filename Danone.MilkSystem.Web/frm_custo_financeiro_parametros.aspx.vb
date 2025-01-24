Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_custo_financeiro_parametros
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_custo_financeiro_parametros.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If


    End Sub

    Private Sub loadDetails()

        Try


            Dim custo As New CustoFinanceiro
            ViewState.Item("ultimoano") = custo.getCustoFinanceiroParametroUltimoAno()

            If Not (Request("nr_ano") Is Nothing) Then 'Alteração
                btn_incluirperiodo.Visible = False
                lk_concluir.Enabled = True
                lk_concluirFooter.Enabled = True
                ViewState.Item("nr_ano") = Convert.ToInt32(Request("nr_ano"))
                'se ultimo ano = 0
                If CInt(ViewState.Item("ultimoano").ToString) = 0 Then
                    lbl_ultimo_ano.Text = String.Empty
                Else
                    lbl_ultimo_ano.Text = String.Concat("Último Ano Referência cadastrada: ", ViewState.Item("ultimoano").ToString)
                End If

                txt_ano.Text = ViewState.Item("nr_ano").ToString
                loadData()
            Else 'Novo

                txt_ano.Enabled = True
                tr_valores.Visible = False
                gridcusto.Visible = False
                btn_incluirperiodo.Visible = True
                ViewState.Item("nr_ano") = Nothing
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False

                'se ultimo ano = 0
                If CInt(ViewState.Item("ultimoano").ToString) = 0 Then
                    lbl_ultimo_ano.Text = String.Empty
                    txt_ano.Text = DateTime.Parse(Now).ToString("yyyy")

                Else
                    lbl_ultimo_ano.Text = String.Concat("Último Ano Referência cadastrada: ", ViewState.Item("ultimoano").ToString)
                    txt_ano.Text = CInt(ViewState.Item("ultimoano").ToString) + 1 'sugere o proximo ano do ultimo cadastro
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try

            Dim custo As New CustoFinanceiro

            txt_ano.Enabled = False
            txt_ano.Text = ViewState.Item("nr_ano").ToString
            tr_valores.Visible = True

            custo.nr_ano = ViewState.Item("nr_ano")

            Dim dscusto As DataSet = custo.getCustoFinanceiroByFilters()

            If (dscusto.Tables(0).Rows.Count > 0) Then
                gridcusto.Visible = True
                gridcusto.DataSource = Helper.getDataView(dscusto.Tables(0), "")
                gridcusto.DataBind()
            Else
                gridcusto.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub updateData()
        If Page.IsValid = True Then

            Try

                Dim custo As New CustoFinanceiro
                Dim row As GridViewRow

                custo.nr_ano = Convert.ToInt32(txt_ano.Text)
                custo.id_modificador = Session("id_login")

                For Each row In gridcusto.Rows
                    If row.Visible = True Then
                        Dim txt_mes1 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes1"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_mes2 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes2"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_mes3 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes3"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_mes4 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes4"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_mes5 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes5"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_mes6 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes6"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_mes7 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes7"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_mes8 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes8"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_mes9 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes9"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_mes10 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes10"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_mes11 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes11"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_mes12 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes12"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim lbl_id_custo_financeiro As Label = CType(row.FindControl("lbl_id_custo_financeiro"), Label)
                        Dim lbl_id_tipo_custo_financeiro As Label = CType(row.FindControl("lbl_id_tipo_custo_financeiro"), Label)

                        If Not txt_mes1.Text.Equals(String.Empty) Then
                            custo.nr_valor_01 = Convert.ToDecimal(txt_mes1.Text)
                        Else
                            custo.nr_valor_01 = 0
                        End If
                        If Not txt_mes2.Text.Equals(String.Empty) Then
                            custo.nr_valor_02 = Convert.ToDecimal(txt_mes2.Text)
                        Else
                            custo.nr_valor_02 = 0
                        End If

                        If Not txt_mes3.Text.Equals(String.Empty) Then
                            custo.nr_valor_03 = Convert.ToDecimal(txt_mes3.Text)
                        Else
                            custo.nr_valor_03 = 0
                        End If

                        If Not txt_mes4.Text.Equals(String.Empty) Then
                            custo.nr_valor_04 = Convert.ToDecimal(txt_mes4.Text)
                        Else
                            custo.nr_valor_04 = 0
                        End If

                        If Not txt_mes5.Text.Equals(String.Empty) Then
                            custo.nr_valor_05 = Convert.ToDecimal(txt_mes5.Text)
                        Else
                            custo.nr_valor_05 = 0
                        End If

                        If Not txt_mes6.Text.Equals(String.Empty) Then
                            custo.nr_valor_06 = Convert.ToDecimal(txt_mes6.Text)
                        Else
                            custo.nr_valor_06 = 0
                        End If

                        If Not txt_mes7.Text.Equals(String.Empty) Then
                            custo.nr_valor_07 = Convert.ToDecimal(txt_mes7.Text)
                        Else
                            custo.nr_valor_07 = 0
                        End If

                        If Not txt_mes8.Text.Equals(String.Empty) Then
                            custo.nr_valor_08 = Convert.ToDecimal(txt_mes8.Text)
                        Else
                            custo.nr_valor_08 = 0
                        End If

                        If Not txt_mes9.Text.Equals(String.Empty) Then
                            custo.nr_valor_09 = Convert.ToDecimal(txt_mes9.Text)
                        Else
                            custo.nr_valor_09 = 0
                        End If

                        If Not txt_mes10.Text.Equals(String.Empty) Then
                            custo.nr_valor_10 = Convert.ToDecimal(txt_mes10.Text)
                        Else
                            custo.nr_valor_10 = 0
                        End If

                        If Not txt_mes11.Text.Equals(String.Empty) Then
                            custo.nr_valor_11 = Convert.ToDecimal(txt_mes11.Text)
                        Else
                            custo.nr_valor_11 = 0
                        End If

                        If Not txt_mes12.Text.Equals(String.Empty) Then
                            custo.nr_valor_12 = Convert.ToDecimal(txt_mes12.Text)
                        Else
                            custo.nr_valor_12 = 0
                        End If
                        custo.id_tipo_custo_financeiro = lbl_id_tipo_custo_financeiro.Text

                        custo.id_custo_financeiro = Convert.ToInt32(lbl_id_custo_financeiro.Text)
                        custo.updateCustoFinanceiro()

                    End If
                Next


                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'alteracao
                usuariolog.id_menu_item = 223
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro alterado com sucesso.")

                loadData()

                Response.Redirect("frm_custo_financeiro_parametros.aspx?nr_ano=" + ViewState.Item("nr_ano").ToString())



            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_custo_financeiro_parametros.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_custo_financeiro_parametros.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        If Page.IsValid Then
            updateData()

        End If
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        If Page.IsValid Then
            updateData()

        End If
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_custo_financeiro_parametros.aspx")

    End Sub

    Protected Sub txt_mes1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtmes As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes1"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

        txtmes.ForeColor = Drawing.Color.Red

    End Sub

    Protected Sub txt_mes2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtmes As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes2"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

        txtmes.ForeColor = Drawing.Color.Red


    End Sub

    Protected Sub txt_mes3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtmes As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes3"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

        txtmes.ForeColor = Drawing.Color.Red


    End Sub

    Protected Sub txt_mes4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtmes As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes4"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

        txtmes.ForeColor = Drawing.Color.Red


    End Sub

    Protected Sub txt_mes5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtmes As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes5"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

        txtmes.ForeColor = Drawing.Color.Red


    End Sub

    Protected Sub txt_mes6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtmes As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes6"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

        txtmes.ForeColor = Drawing.Color.Red


    End Sub

    Protected Sub txt_mes7_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtmes As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes7"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

        txtmes.ForeColor = Drawing.Color.Red


    End Sub

    Protected Sub txt_mes8_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtmes As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes8"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

        txtmes.ForeColor = Drawing.Color.Red


    End Sub

    Protected Sub txt_mes9_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtmes As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes9"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

        txtmes.ForeColor = Drawing.Color.Red


    End Sub

    Protected Sub txt_mes10_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtmes As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes10"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

        txtmes.ForeColor = Drawing.Color.Red


    End Sub

    Protected Sub txt_mes11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtmes As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes11"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

        txtmes.ForeColor = Drawing.Color.Red


    End Sub

    Protected Sub txt_mes12_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtmes As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_mes12"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

        txtmes.ForeColor = Drawing.Color.Red


    End Sub

    Protected Sub gridcusto_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridcusto.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim mes1 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_mes1"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim mes2 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_mes2"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim mes3 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_mes3"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim mes4 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_mes4"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim mes5 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_mes5"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim mes6 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_mes6"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim mes7 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_mes7"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim mes8 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_mes8"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim mes9 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_mes9"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim mes10 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_mes10"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim mes11 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_mes11"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
            Dim mes12 As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_mes12"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

            Dim lbl_id_tipo_custo_financeiro As Label = CType(e.Row.FindControl("lbl_id_tipo_custo_financeiro"), Label)

            Select Case CInt(lbl_id_tipo_custo_financeiro.Text)

                Case 4, 19 ' necessidade de leite e volume de coop e
                    mes1.MaxMantissa = 0
                    mes2.MaxMantissa = 0
                    mes3.MaxMantissa = 0
                    mes4.MaxMantissa = 0
                    mes5.MaxMantissa = 0
                    mes6.MaxMantissa = 0
                    mes7.MaxMantissa = 0
                    mes8.MaxMantissa = 0
                    mes9.MaxMantissa = 0
                    mes10.MaxMantissa = 0
                    mes11.MaxMantissa = 0
                    mes12.MaxMantissa = 0

                    If (Not mes1.Text.Equals(String.Empty) And Not mes1.Text = "&nbsp;") Then
                        mes1.Text = CInt(mes1.Text).ToString()
                    End If
                    If (Not mes2.Text.Equals(String.Empty) And Not mes2.Text = "&nbsp;") Then
                        mes2.Text = CInt(mes2.Text).ToString()
                    End If
                    If (Not mes3.Text.Equals(String.Empty) And Not mes3.Text = "&nbsp;") Then
                        mes3.Text = CInt(mes3.Text).ToString()
                    End If
                    If (Not mes4.Text.Equals(String.Empty) And Not mes4.Text = "&nbsp;") Then
                        mes4.Text = CInt(mes4.Text).ToString()
                    End If
                    If (Not mes5.Text.Equals(String.Empty) And Not mes5.Text = "&nbsp;") Then
                        mes5.Text = CInt(mes5.Text).ToString()
                    End If
                    If (Not mes6.Text.Equals(String.Empty) And Not mes6.Text = "&nbsp;") Then
                        mes6.Text = CInt(mes6.Text).ToString()
                    End If
                    If (Not mes7.Text.Equals(String.Empty) And Not mes7.Text = "&nbsp;") Then
                        mes7.Text = CInt(mes7.Text).ToString()
                    End If
                    If (Not mes8.Text.Equals(String.Empty) And Not mes8.Text = "&nbsp;") Then
                        mes8.Text = CInt(mes8.Text).ToString()
                    End If
                    If (Not mes9.Text.Equals(String.Empty) And Not mes9.Text = "&nbsp;") Then
                        mes9.Text = CInt(mes9.Text).ToString()
                    End If
                    If (Not mes10.Text.Equals(String.Empty) And Not mes10.Text = "&nbsp;") Then
                        mes10.Text = CInt(mes10.Text).ToString()
                    End If
                    If (Not mes11.Text.Equals(String.Empty) And Not mes11.Text = "&nbsp;") Then
                        mes11.Text = CInt(mes11.Text).ToString()
                    End If
                    If (Not mes12.Text.Equals(String.Empty) And Not mes12.Text = "&nbsp;") Then
                        mes12.Text = CInt(mes12.Text).ToString()
                    End If


            End Select

            If e.Row.Cells(1).Text = "N" OrElse CInt(lbl_id_tipo_custo_financeiro.Text) = 20 Then
                mes1.MaxMantissa = 2
                mes2.MaxMantissa = 2
                mes3.MaxMantissa = 2
                mes4.MaxMantissa = 2
                mes5.MaxMantissa = 2
                mes6.MaxMantissa = 2
                mes7.MaxMantissa = 2
                mes8.MaxMantissa = 2
                mes9.MaxMantissa = 2
                mes10.MaxMantissa = 2
                mes11.MaxMantissa = 2
                mes12.MaxMantissa = 2
                If (Not mes1.Text.Equals(String.Empty)) Then
                    mes1.Text = FormatNumber(mes1.Text, 2, , , TriState.False).ToString()
                End If
                If (Not mes2.Text.Equals(String.Empty)) Then
                    mes2.Text = FormatNumber(mes2.Text, 2, , , TriState.False).ToString()
                End If
                If (Not mes3.Text.Equals(String.Empty)) Then
                    mes3.Text = FormatNumber(mes3.Text, 2, , , TriState.False).ToString()
                End If
                If (Not mes4.Text.Equals(String.Empty)) Then
                    mes4.Text = FormatNumber(mes4.Text, 2, , , TriState.False).ToString()
                End If
                If (Not mes5.Text.Equals(String.Empty)) Then
                    mes5.Text = FormatNumber(mes5.Text, 2, , , TriState.False).ToString()
                End If
                If (Not mes6.Text.Equals(String.Empty)) Then
                    mes6.Text = FormatNumber(mes6.Text, 2, , , TriState.False).ToString()
                End If
                If (Not mes7.Text.Equals(String.Empty)) Then
                    mes7.Text = FormatNumber(mes7.Text, 2, , , TriState.False).ToString()
                End If
                If (Not mes8.Text.Equals(String.Empty)) Then
                    mes8.Text = FormatNumber(mes8.Text, 2, , , TriState.False).ToString()
                End If
                If (Not mes9.Text.Equals(String.Empty)) Then
                    mes9.Text = FormatNumber(mes9.Text, 2, , , TriState.False).ToString()
                End If
                If (Not mes10.Text.Equals(String.Empty)) Then
                    mes10.Text = FormatNumber(mes10.Text, 2, , , TriState.False).ToString()
                End If
                If (Not mes11.Text.Equals(String.Empty)) Then
                    mes11.Text = FormatNumber(mes11.Text, 2, , , TriState.False).ToString()
                End If
                If (Not mes12.Text.Equals(String.Empty)) Then
                    mes12.Text = FormatNumber(mes12.Text, 2, , , TriState.False).ToString()
                End If

            End If
        End If

    End Sub

    Protected Sub btn_incluirperiodo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluirperiodo.Click
        If Page.IsValid = True Then
            Try

                Dim custo As New CustoFinanceiro

                custo.nr_ano = txt_ano.Text
                custo.id_modificador = Session("id_login")
                custo.insertCustoFinanceiro()

                tr_valores.Visible = True
                btn_incluirperiodo.Visible = False
                ViewState.Item("nr_ano") = txt_ano.Text
                lk_concluir.Enabled = True
                lk_concluirFooter.Enabled = True

                loadData()


            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If

    End Sub

    Protected Sub cv_custo_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_custo.ServerValidate
        Try
            args.IsValid = True
            Dim lmsg As String = String.Empty

            Dim custo As New CustoFinanceiro
            custo.nr_ano = txt_ano.Text

            've rifica se ja existe o ano para inclusão
            If custo.getCustoFinanceiroByFilters().Tables(0).Rows.Count > 0 Then
                args.IsValid = False
                lmsg = String.Concat("Já existe cadastro de custos financeiros para o ano ", txt_ano.Text, " informado!")
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
