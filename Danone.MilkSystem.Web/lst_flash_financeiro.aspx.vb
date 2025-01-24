Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_flash_financeiro

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia_ini") = String.Concat("01/01/", txt_ano_referencia.Text)
        ViewState.Item("dt_referencia_fim") = String.Concat("01/12/", txt_ano_referencia.Text)
        If txt_cd_tecnico.Text.Equals(String.Empty) Then
            ViewState.Item("id_tecnico") = "0"
        Else
            ViewState.Item("id_tecnico") = Me.hf_id_tecnico.Value
        End If

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_flash_financeiro.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_flash_financeiro.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 201
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With img_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialogTecnico()")
            .ToolTip = "Filtrar Técnicos"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento

            estabelecimento.id_situacao = 1 '   Para trazer somente os ativos
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_estabelecimento.Items.RemoveAt(2)   ' Remove Aguas da Prata  -  acertos chamado 2500 


            txt_ano_referencia.Text = DateTime.Parse(Now).ToString("yyyy")

            ViewState.Item("sortExpression") = ""



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim ficha As New FichaFinanceira

            ficha.dt_referencia_ficha_start = ViewState.Item("dt_referencia_ini")
            ficha.dt_referencia_ficha_end = ViewState.Item("dt_referencia_fim")
            ficha.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            ' Trazer Poços e Aguas Juntos - i
            If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                ficha.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            Else
                ficha.estabelecimentos = ficha.id_estabelecimento
            End If
            'ficha.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
            ' Trazer Poços e Aguas Juntos - f

            If Trim(ViewState.Item("id_tecnico")) <> "" Then
                ficha.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)
            End If
            Dim dsficha As DataSet = ficha.getFlashFinanceiro()

            If (dsficha.Tables(0).Rows.Count > 0) Then
                lbl_flash.Visible = True
                lbl_flash.Text = String.Concat("FLASH FINANCEIRO ", DateTime.Parse(ViewState.Item("dt_referencia_ini")).ToString("yyyy"))
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsficha.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                lbl_flash.Visible = False
                lbl_informativo.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim mes1 As DataControlFieldCell = CType(e.Row.Cells.Item(1), DataControlFieldCell)
            Dim mes2 As DataControlFieldCell = CType(e.Row.Cells.Item(2), DataControlFieldCell)
            Dim mes3 As DataControlFieldCell = CType(e.Row.Cells.Item(3), DataControlFieldCell)
            Dim mes4 As DataControlFieldCell = CType(e.Row.Cells.Item(4), DataControlFieldCell)
            Dim mes5 As DataControlFieldCell = CType(e.Row.Cells.Item(5), DataControlFieldCell)
            Dim mes6 As DataControlFieldCell = CType(e.Row.Cells.Item(6), DataControlFieldCell)
            Dim mes7 As DataControlFieldCell = CType(e.Row.Cells.Item(7), DataControlFieldCell)
            Dim mes8 As DataControlFieldCell = CType(e.Row.Cells.Item(8), DataControlFieldCell)
            Dim mes9 As DataControlFieldCell = CType(e.Row.Cells.Item(9), DataControlFieldCell)
            Dim mes10 As DataControlFieldCell = CType(e.Row.Cells.Item(10), DataControlFieldCell)
            Dim mes11 As DataControlFieldCell = CType(e.Row.Cells.Item(11), DataControlFieldCell)
            Dim mes12 As DataControlFieldCell = CType(e.Row.Cells.Item(12), DataControlFieldCell)
            Dim lbl_id_conta As Label = CType(e.Row.FindControl("lbl_id_conta"), Label)

            Dim lbl_nr_mes_provisorio As Label = CType(e.Row.FindControl("lbl_nr_mes_provisorio"), Label)

            If CInt(lbl_nr_mes_provisorio.Text) > 0 Then

                lbl_informativo.Visible = True

                Select Case CInt(lbl_nr_mes_provisorio.Text)
                    Case 1
                        mes1.Font.Italic = True
                        mes1.ForeColor = Drawing.Color.Blue
                    Case 2
                        mes2.Font.Italic = True
                        mes2.ForeColor = Drawing.Color.Blue
                    Case 3
                        mes3.Font.Italic = True
                        mes3.ForeColor = Drawing.Color.Blue
                    Case 4
                        mes4.Font.Italic = True
                        mes4.ForeColor = Drawing.Color.Blue
                    Case 5
                        mes5.Font.Italic = True
                        mes5.ForeColor = Drawing.Color.Blue
                    Case 6
                        mes6.Font.Italic = True
                        mes6.ForeColor = Drawing.Color.Blue
                    Case 7
                        mes7.Font.Italic = True
                        mes7.ForeColor = Drawing.Color.Blue
                    Case 8
                        mes8.Font.Italic = True
                        mes8.ForeColor = Drawing.Color.Blue
                    Case 9
                        mes9.Font.Italic = True
                        mes9.ForeColor = Drawing.Color.Blue
                    Case 10
                        mes10.Font.Italic = True
                        mes10.ForeColor = Drawing.Color.Blue
                    Case 11
                        mes11.Font.Italic = True
                        mes11.ForeColor = Drawing.Color.Blue
                    Case 12
                        mes12.Font.Italic = True
                        mes12.ForeColor = Drawing.Color.Blue
                End Select
            Else
                lbl_informativo.Visible = False
            End If

            If lbl_id_conta.Text = "1" Then 'COnta 0010 Volume
                If (Not mes1.Text.Equals(String.Empty) And Not mes1.Text = "&nbsp;") Then
                    mes1.Text = FormatNumber(mes1.Text, 0).ToString()
                End If
                If (Not mes2.Text.Equals(String.Empty) And Not mes2.Text = "&nbsp;") Then
                    mes2.Text = FormatNumber(mes2.Text, 0).ToString()
                End If
                If (Not mes3.Text.Equals(String.Empty) And Not mes3.Text = "&nbsp;") Then
                    mes3.Text = FormatNumber(mes3.Text, 0).ToString()
                End If
                If (Not mes4.Text.Equals(String.Empty) And Not mes4.Text = "&nbsp;") Then
                    mes4.Text = FormatNumber(mes4.Text, 0).ToString()
                End If
                If (Not mes5.Text.Equals(String.Empty) And Not mes5.Text = "&nbsp;") Then
                    mes5.Text = FormatNumber(mes5.Text, 0).ToString()
                End If
                If (Not mes6.Text.Equals(String.Empty) And Not mes6.Text = "&nbsp;") Then
                    mes6.Text = FormatNumber(mes6.Text, 0).ToString()
                End If
                If (Not mes7.Text.Equals(String.Empty) And Not mes7.Text = "&nbsp;") Then
                    mes7.Text = FormatNumber(mes7.Text, 0).ToString()
                End If
                If (Not mes8.Text.Equals(String.Empty) And Not mes8.Text = "&nbsp;") Then
                    mes8.Text = FormatNumber(mes8.Text, 0).ToString()
                End If
                If (Not mes9.Text.Equals(String.Empty) And Not mes9.Text = "&nbsp;") Then
                    mes9.Text = FormatNumber(mes9.Text, 0).ToString()
                End If
                If (Not mes10.Text.Equals(String.Empty) And Not mes10.Text = "&nbsp;") Then
                    mes10.Text = FormatNumber(mes10.Text, 0).ToString()
                End If
                If (Not mes11.Text.Equals(String.Empty) And Not mes11.Text = "&nbsp;") Then
                    mes11.Text = FormatNumber(mes11.Text, 0).ToString()
                End If
                If (Not mes12.Text.Equals(String.Empty) And Not mes12.Text = "&nbsp;") Then
                    mes12.Text = FormatNumber(mes12.Text, 0).ToString()
                End If
            End If


            If lbl_id_conta.Text = "64" Then 'COnta total de qualidade X volume
                If (Not mes1.Text.Equals(String.Empty) And Not mes1.Text = "&nbsp;") Then
                    mes1.Text = FormatCurrency(mes1.Text, 2).ToString()
                End If
                If (Not mes2.Text.Equals(String.Empty) And Not mes2.Text = "&nbsp;") Then
                    mes2.Text = FormatCurrency(mes2.Text, 2).ToString()
                End If
                If (Not mes3.Text.Equals(String.Empty) And Not mes3.Text = "&nbsp;") Then
                    mes3.Text = FormatCurrency(mes3.Text, 2).ToString()
                End If
                If (Not mes4.Text.Equals(String.Empty) And Not mes4.Text = "&nbsp;") Then
                    mes4.Text = FormatCurrency(mes4.Text, 2).ToString()
                End If
                If (Not mes5.Text.Equals(String.Empty) And Not mes5.Text = "&nbsp;") Then
                    mes5.Text = FormatCurrency(mes5.Text, 2).ToString()
                End If
                If (Not mes6.Text.Equals(String.Empty) And Not mes6.Text = "&nbsp;") Then
                    mes6.Text = FormatCurrency(mes6.Text, 2).ToString()
                End If
                If (Not mes7.Text.Equals(String.Empty) And Not mes7.Text = "&nbsp;") Then
                    mes7.Text = FormatCurrency(mes7.Text, 2).ToString()
                End If
                If (Not mes8.Text.Equals(String.Empty) And Not mes8.Text = "&nbsp;") Then
                    mes8.Text = FormatCurrency(mes8.Text, 2).ToString()
                End If
                If (Not mes9.Text.Equals(String.Empty) And Not mes9.Text = "&nbsp;") Then
                    mes9.Text = FormatCurrency(mes9.Text, 2).ToString()
                End If
                If (Not mes10.Text.Equals(String.Empty) And Not mes10.Text = "&nbsp;") Then
                    mes10.Text = FormatCurrency(mes10.Text, 2).ToString()
                End If
                If (Not mes11.Text.Equals(String.Empty) And Not mes11.Text = "&nbsp;") Then
                    mes11.Text = FormatCurrency(mes11.Text, 2).ToString()
                End If
                If (Not mes12.Text.Equals(String.Empty) And Not mes12.Text = "&nbsp;") Then
                    mes12.Text = FormatCurrency(mes12.Text, 2).ToString()
                End If
            End If
        End If


    End Sub

 

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia_ini") = String.Concat("01/01/", txt_ano_referencia.Text)
        ViewState.Item("dt_referencia_fim") = String.Concat("01/12/", txt_ano_referencia.Text)
        If txt_cd_tecnico.Text.Equals(String.Empty) Then
            ViewState.Item("id_tecnico") = "0"
        Else
            ViewState.Item("id_tecnico") = Me.hf_id_tecnico.Value
        End If
        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 201
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        Response.Redirect("frm_flash_financeiro_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&dt_referencia_ini=" + ViewState.Item("dt_referencia_ini").ToString() + "&dt_referencia_fim=" + ViewState.Item("dt_referencia_fim").ToString())

    End Sub


    Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
        lbl_nm_tecnico.Text = String.Empty
        hf_id_tecnico.Value = String.Empty

        Try
            If Not txt_cd_tecnico.Text.Equals(String.Empty) Then
                Dim tecnico As New Tecnico
                tecnico.id_tecnico = Convert.ToInt32(txt_cd_tecnico.Text.Trim)

                Dim dstecnico As DataSet = tecnico.getTecnicoByFilters
                If dstecnico.Tables(0).Rows.Count > 0 Then
                    lbl_nm_tecnico.Enabled = True
                    lbl_nm_tecnico.Text = dstecnico.Tables(0).Rows(0).Item("nm_tecnico")
                    hf_id_tecnico.Value = dstecnico.Tables(0).Rows(0).Item("id_tecnico").ToString
                End If

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub img_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_tecnico.Click
        If Not (hf_id_tecnico.Value.Trim.Equals(String.Empty)) Then
            Me.lbl_nm_tecnico.Visible = True
            carregarCamposTecnico()

        End If
    End Sub
    Private Sub carregarCamposTecnico()

        Try

            Me.txt_cd_tecnico.Text = hf_id_tecnico.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
