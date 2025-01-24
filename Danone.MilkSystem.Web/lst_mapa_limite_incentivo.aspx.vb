Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class lst_mapa_limite_incentivo

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("dt_referencia_ini") = String.Concat("01/01/", txt_ano_referencia.Text)
            ViewState.Item("dt_referencia_fim") = String.Concat("01/12/", txt_ano_referencia.Text)
            ViewState.Item("ano") = txt_ano_referencia.Text
            ViewState.Item("st_limite_excedido") = chk_limite_excedido.Checked
            'If txt_cd_tecnico.Text.Equals(String.Empty) Then
            '    ViewState.Item("id_tecnico") = "0"
            'Else
            '    ViewState.Item("id_tecnico") = Me.hf_id_tecnico.Value
            'End If

            loadData()
        End If
    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_mapa_incentivo_limite.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_mapa_limite_incentivo.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 217
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
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            txt_ano_referencia.Text = DateTime.Parse(Now).ToString("yyyy")

            Dim custo As New CustoFinanceiro

            Dim dscalculo As DataSet = custo.getDataUltimoCalculoProjetado

            If dscalculo.Tables(0).Rows.Count > 0 Then
                With dscalculo.Tables(0).Rows(0)
                    lbl_calculoprojetado.Text = String.Concat("Execução ", .Item("id_custo_financeiro_calculo_execucao").ToString, " - Ano ", .Item("nr_ano").ToString, " - Data ", Left(.Item("dt_termino_execucao").ToString, 16), " (", .Item("ds_login").ToString, ")")
                    ViewState.Item("id_calculo_execucao_ultima") = .Item("id_custo_financeiro_calculo_execucao")
                    ViewState.Item("nr_ano_ultima_execucao") = .Item("nr_ano")
                End With
            Else
                ViewState.Item("id_calculo_execucao_ultima") = 0
                ViewState.Item("nr_ano_ultima_execucao") = 0
                lbl_calculoprojetado.Text = "Nenhum cálculo projetado foi realizado."
            End If

            custo.nr_ano = txt_ano_referencia.Text
            Dim dscalculoexec As DataSet = custo.getDataUltimoCalculoProjetado

            If dscalculoexec.Tables(0).Rows.Count > 0 Then
                With dscalculoexec.Tables(0).Rows(0)
                    lbl_execucao.Text = String.Concat(.Item("id_custo_financeiro_calculo_execucao").ToString, " - Data ", Left(.Item("dt_termino_execucao").ToString, 16))
                    ViewState.Item("id_calculo_execucao") = .Item("id_custo_financeiro_calculo_execucao")
                End With
            Else
                ViewState.Item("id_calculo_execucao") = 0
                lbl_execucao.Text = String.Empty
            End If

            ViewState.Item("sortExpression") = ""



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim mapa As New CustoFinanceiro

            mapa.dt_referencia_ini = ViewState.Item("dt_referencia_ini")
            mapa.dt_referencia_fim = ViewState.Item("dt_referencia_fim")
            mapa.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            If ViewState.Item("st_limite_excedido") = True Then
                mapa.st_limite_incentivo = "S"
            Else
                mapa.st_limite_incentivo = "N"

            End If

            mapa.id_custo_financeiro_calculo_execucao = ViewState.Item("id_calculo_execucao_ultima")
            Dim dsmapa As DataSet = mapa.getMapaLimiteIncentivo()

            mapa.nr_ano = txt_ano_referencia.Text

            Dim lmesprovisorio As Integer = mapa.getCustoFinanceiroFichaMesProvisorio().ToString
            ViewState.Item("mesprovisorio") = lmesprovisorio.ToString

            If (dsmapa.Tables(0).Rows.Count > 0) Then
                'If CInt(ViewState.Item("ano").ToString) < CInt(DateTime.Parse(Now).ToString("yyyy").ToString) Then
                '    ViewState.Item("mesprovisorio") = 0
                'Else
                '    ViewState.Item("mesprovisorio") = CInt(DateTime.Parse(Now).ToString("MM").ToString)
                'End If

                lbl_flash.Visible = True
                lbl_flash.Text = String.Concat("MAPA LIMITE INCENTIVO ", DateTime.Parse(ViewState.Item("dt_referencia_ini")).ToString("yyyy"))
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsmapa.Tables(0), ViewState.Item("sortExpression"))
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

            Dim mes1 As DataControlFieldCell = CType(e.Row.Cells.Item(5), DataControlFieldCell)
            Dim mes2 As DataControlFieldCell = CType(e.Row.Cells.Item(6), DataControlFieldCell)
            Dim mes3 As DataControlFieldCell = CType(e.Row.Cells.Item(7), DataControlFieldCell)
            Dim mes4 As DataControlFieldCell = CType(e.Row.Cells.Item(8), DataControlFieldCell)
            Dim mes5 As DataControlFieldCell = CType(e.Row.Cells.Item(9), DataControlFieldCell)
            Dim mes6 As DataControlFieldCell = CType(e.Row.Cells.Item(10), DataControlFieldCell)
            Dim mes7 As DataControlFieldCell = CType(e.Row.Cells.Item(11), DataControlFieldCell)
            Dim mes8 As DataControlFieldCell = CType(e.Row.Cells.Item(12), DataControlFieldCell)
            Dim mes9 As DataControlFieldCell = CType(e.Row.Cells.Item(13), DataControlFieldCell)
            Dim mes10 As DataControlFieldCell = CType(e.Row.Cells.Item(14), DataControlFieldCell)
            Dim mes11 As DataControlFieldCell = CType(e.Row.Cells.Item(15), DataControlFieldCell)
            Dim mes12 As DataControlFieldCell = CType(e.Row.Cells.Item(16), DataControlFieldCell)
            Dim lbl_id_propriedade_matriz As Label = CType(e.Row.FindControl("lbl_id_propriedade_matriz"), Label)
            Dim lbl_volumeprojetado As Label = CType(e.Row.FindControl("lbl_volumeprojetado"), Label)
            Dim lbl_propordenacao As Label = CType(e.Row.FindControl("lbl_propordenacao"), Label)
            Dim lbl_volumetotal As Label = CType(e.Row.FindControl("lbl_volumetotal"), Label)
            Dim lbl_nr_saldo_limite As Label = CType(e.Row.FindControl("lbl_nr_saldo_limite"), Label)


            'No mes provisorio colocar volume em azul
            If CInt(ViewState.Item("mesprovisorio")) > 0 Then

                lbl_informativo.Visible = True

                Select Case CInt(ViewState.Item("mesprovisorio").ToString)
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

            Dim lsomavolume As Integer = 0
            Dim lcor As System.Drawing.Color
            Dim lnrvolumetotal As Integer = 0
            If (Not lbl_volumetotal.Text.Equals(String.Empty) And Not lbl_volumetotal.Text = "&nbsp;") Then
                If lbl_volumetotal.Text = "0" Then
                    lnrvolumetotal = 0
                Else
                    If CDec(lbl_volumetotal.Text) >= 637000 Then 'se falta 20000 para estourar
                        lcor = Drawing.Color.Yellow
                        If CDec(lbl_volumetotal.Text) >= 657000 Then
                            lcor = Drawing.Color.MistyRose
                        End If
                    End If
                    lnrvolumetotal = CInt(lbl_volumetotal.Text)
                End If
            End If
            If (Not lbl_volumeprojetado.Text.Equals(String.Empty) And Not lbl_volumetotal.Text = "&nbsp;") Then
                If Not lbl_volumeprojetado.Text = "0" Then
                    If CInt(lbl_volumeprojetado.Text) >= 657000 AndAlso lnrvolumetotal < 637000 Then
                        e.Row.BackColor = Drawing.Color.PaleTurquoise
                    End If

                End If

            End If

            If (Not mes1.Text.Equals(String.Empty) And Not mes1.Text = "&nbsp;") Then
                If mes1.Text = 0 Then
                    mes1.Text = "-"
                Else
                    mes1.Text = FormatNumber(Abs(CDec(mes1.Text)), 0).ToString
                    lsomavolume = lsomavolume + CInt(mes1.Text)
                    If lsomavolume >= 637000 Then
                        mes1.BackColor = lcor
                        mes1.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes1.Text = "-"
            End If
            If (Not mes2.Text.Equals(String.Empty) And Not mes2.Text = "&nbsp;") Then
                If mes2.Text = 0 Then
                    mes2.Text = "-"
                Else
                    mes2.Text = FormatNumber(Abs(CDec(mes2.Text)), 0).ToString()
                    lsomavolume = lsomavolume + CInt(mes2.Text)
                    If lsomavolume >= 637000 Then
                        mes2.BackColor = lcor
                        mes2.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes2.Text = "-"
            End If

            If (Not mes3.Text.Equals(String.Empty) And Not mes3.Text = "&nbsp;") Then
                If mes3.Text = 0 Then
                    mes3.Text = "-"
                Else
                    mes3.Text = FormatNumber(Abs(CDec(mes3.Text)), 0).ToString()
                    lsomavolume = lsomavolume + CInt(mes3.Text)
                    If lsomavolume >= 637000 Then
                        mes3.BackColor = lcor
                        mes3.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes3.Text = "-"
            End If

            If (Not mes4.Text.Equals(String.Empty) And Not mes4.Text = "&nbsp;") Then
                If mes4.Text = 0 Then
                    mes4.Text = "-"
                Else
                    mes4.Text = FormatNumber(Abs(CDec(mes4.Text)), 0).ToString()
                    lsomavolume = lsomavolume + CInt(mes4.Text)
                    If lsomavolume >= 637000 Then
                        mes4.BackColor = lcor
                        mes4.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes4.Text = "-"
            End If

            If (Not mes5.Text.Equals(String.Empty) And Not mes5.Text = "&nbsp;") Then
                If mes5.Text = 0 Then
                    mes5.Text = "-"
                Else
                    mes5.Text = FormatNumber(Abs(CDec(mes5.Text)), 0).ToString()
                    lsomavolume = lsomavolume + CInt(mes5.Text)
                    If lsomavolume >= 637000 Then
                        mes5.BackColor = lcor
                        mes5.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes5.Text = "-"
            End If
            If (Not mes6.Text.Equals(String.Empty) And Not mes6.Text = "&nbsp;") Then
                If mes6.Text = 0 Then
                    mes6.Text = "-"
                Else
                    mes6.Text = FormatNumber(Abs(CDec(mes6.Text)), 0).ToString()
                    lsomavolume = lsomavolume + CInt(mes6.Text)
                    If lsomavolume >= 637000 Then
                        mes6.BackColor = lcor
                        mes6.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes6.Text = "-"
            End If

            If (Not mes7.Text.Equals(String.Empty) And Not mes7.Text = "&nbsp;") Then
                If mes7.Text = 0 Then
                    mes7.Text = "-"
                Else
                    mes7.Text = FormatNumber(Abs(CDec(mes7.Text)), 0).ToString()
                    lsomavolume = lsomavolume + CInt(mes7.Text)
                    If lsomavolume >= 637000 Then
                        mes7.BackColor = lcor
                        mes7.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes7.Text = "-"
            End If

            If (Not mes8.Text.Equals(String.Empty) And Not mes8.Text = "&nbsp;") Then
                If mes8.Text = 0 Then
                    mes8.Text = "-"
                Else
                    mes8.Text = FormatNumber(Abs(CDec(mes8.Text)), 0).ToString()
                    lsomavolume = lsomavolume + CInt(mes8.Text)
                    If lsomavolume >= 637000 Then
                        mes8.BackColor = lcor
                        mes8.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes8.Text = "-"
            End If

            If (Not mes9.Text.Equals(String.Empty) And Not mes9.Text = "&nbsp;") Then
                If mes9.Text = 0 Then
                    mes9.Text = "-"
                Else
                    mes9.Text = FormatNumber(Abs(CDec(mes9.Text)), 0).ToString()
                    lsomavolume = lsomavolume + CInt(mes9.Text)
                    If lsomavolume >= 637000 Then
                        mes9.BackColor = lcor
                        mes9.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes9.Text = "-"
            End If

            If (Not mes10.Text.Equals(String.Empty) And Not mes10.Text = "&nbsp;") Then
                If mes10.Text = 0 Then
                    mes10.Text = "-"
                Else
                    mes10.Text = FormatNumber(Abs(CDec(mes10.Text)), 0).ToString()
                    lsomavolume = lsomavolume + CInt(mes10.Text)
                    If lsomavolume >= 637000 Then
                        mes10.BackColor = lcor
                        mes10.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes10.Text = "-"
            End If

            If (Not mes11.Text.Equals(String.Empty) And Not mes11.Text = "&nbsp;") Then
                If mes11.Text = 0 Then
                    mes11.Text = "-"
                Else
                    mes11.Text = FormatNumber(Abs(CDec(mes11.Text)), 0).ToString()
                    lsomavolume = lsomavolume + CInt(mes11.Text)
                    If lsomavolume >= 637000 Then
                        mes11.BackColor = lcor
                        mes11.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes11.Text = "-"
            End If

            If (Not mes12.Text.Equals(String.Empty) And Not mes12.Text = "&nbsp;") Then
                If mes12.Text = 0 Then
                    mes12.Text = "-"
                Else
                    mes12.Text = FormatNumber(Abs(CDec(mes12.Text)), 0).ToString()
                    lsomavolume = lsomavolume + CInt(mes12.Text)
                    If lsomavolume >= 637000 Then
                        mes12.BackColor = lcor
                        mes12.ForeColor = Drawing.Color.Red
                    End If
                End If
            Else
                mes12.Text = "-"
            End If


        End If


    End Sub



    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Page.IsValid Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("dt_referencia_ini") = String.Concat("01/01/", txt_ano_referencia.Text)
            ViewState.Item("dt_referencia_fim") = String.Concat("01/12/", txt_ano_referencia.Text)
            ViewState.Item("ano") = txt_ano_referencia.Text
            ViewState.Item("st_limite_excedido") = chk_limite_excedido.Checked
            'If txt_cd_tecnico.Text.Equals(String.Empty) Then
            '    ViewState.Item("id_tecnico") = "0"
            'Else
            '    ViewState.Item("id_tecnico") = Me.hf_id_tecnico.Value
            'End If

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 217
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            'If CInt(ViewState.Item("ano").ToString) < CInt(DateTime.Parse(Now).ToString("yyyy").ToString) Then
            '    ViewState.Item("mesprovisorio") = 0
            'Else
            '    ViewState.Item("mesprovisorio") = CInt(DateTime.Parse(Now).ToString("MM").ToString)
            'End If
            Dim mapa As New CustoFinanceiro

            mapa.dt_referencia_ini = ViewState.Item("dt_referencia_ini")
            mapa.dt_referencia_fim = ViewState.Item("dt_referencia_fim")
            mapa.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            mapa.id_custo_financeiro_calculo_execucao = ViewState.Item("id_calculo_execucao_ultima")
            mapa.nr_ano = txt_ano_referencia.Text

            Dim lmesprovisorio As Integer = mapa.getCustoFinanceiroFichaMesProvisorio().ToString
            ViewState.Item("mesprovisorio") = lmesprovisorio.ToString

            Response.Redirect("frm_mapa_limite_incentivo_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&dt_referencia_ini=" + ViewState.Item("dt_referencia_ini").ToString() + "&dt_referencia_fim=" + ViewState.Item("dt_referencia_fim").ToString() + "&mesprovisorio=" + ViewState.Item("mesprovisorio").ToString() + "&st_limite_excedido=" + ViewState.Item("st_limite_excedido").ToString + "&id_execucao=" + ViewState.Item("id_calculo_execucao_ultima").ToString)

            loadData()
        End If
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

    Protected Sub txt_ano_referencia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_ano_referencia.TextChanged
        Try

            gridResults.Visible = False

            If txt_ano_referencia.Text = String.Empty Then
                ViewState.Item("id_calculo_execucao") = 0
                lbl_execucao.Text = String.Empty
            Else
                Dim custo As New CustoFinanceiro
                custo.nr_ano = txt_ano_referencia.Text

                Dim dscalculo As DataSet = custo.getDataUltimoCalculoProjetado

                If dscalculo.Tables(0).Rows.Count > 0 Then
                    With dscalculo.Tables(0).Rows(0)
                        lbl_execucao.Text = String.Concat(.Item("id_custo_financeiro_calculo_execucao").ToString, " - Data ", Left(.Item("dt_termino_execucao").ToString, 16))
                        ViewState.Item("id_calculo_execucao") = .Item("id_custo_financeiro_calculo_execucao")
                    End With
                Else
                    ViewState.Item("id_calculo_execucao") = 0
                    lbl_execucao.Text = String.Empty
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_custo_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_custo.ServerValidate
        Try

            Dim lmsg As String = String.Empty
            args.IsValid = True


            'se nao existe execuç~~ao de calculo projetado
            If ViewState.Item("nr_ano_ultima_execucao").ToString = "0" Then
                args.IsValid = False
                lmsg = "Não foi realizada nenhuma execução de cálculo projetado. O relatório não pode ser emitido."
            Else
                'tem calculo projetado mas verifica se para o ano selecionado nao tem calculo execução
                If CInt(ViewState.Item("id_calculo_execucao").ToString) = 0 Then
                    args.IsValid = False
                    lmsg = "O Ano informado não tem cálculo projetado executado. O relatório não pode ser emitido."
                End If

            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)

                gridResults.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
