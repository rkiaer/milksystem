Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_curvaabc_produtores_pagto_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            Try

                If (Not Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                Else
                    ViewState.Item("id_estabelecimento") = String.Empty
                End If

                If (Not Request("id_pessoa") Is Nothing) Then
                    ViewState.Item("id_pessoa") = Request("id_pessoa")
                Else
                    ViewState.Item("id_pessoa") = String.Empty
                End If

                If (Not Request("id_propriedade") Is Nothing) Then
                    ViewState.Item("id_propriedade") = Request("id_propriedade")
                Else
                    ViewState.Item("id_propriedade") = String.Empty
                End If

                If (Not Request("id_tecnico") Is Nothing) Then
                    ViewState.Item("id_tecnico") = Request("id_tecnico")
                Else
                    ViewState.Item("id_tecnico") = String.Empty
                End If

                If (Not Request("st_categoria_tecnico") Is Nothing) Then
                    ViewState.Item("st_categoria_tecnico") = Request("st_categoria_tecnico")
                Else
                    ViewState.Item("st_categoria_tecnico") = String.Empty
                End If

                If (Not Request("txt_dt_coleta_ini") Is Nothing) Then
                    ViewState.Item("txt_dt_coleta_ini") = Request("txt_dt_coleta_ini")
                Else
                    ViewState.Item("txt_dt_coleta_ini") = String.Empty
                End If


                If (Not Request("id_categoria") Is Nothing) Then
                    ViewState.Item("id_categoria") = Request("id_categoria")
                Else
                    ViewState.Item("id_categoria") = String.Empty
                End If

                '10/02/2017 - chamado 2501 - Mirella i
                If (Not Request("id_grupo") Is Nothing) Then
                    ViewState.Item("id_grupo") = Request("id_grupo")
                Else
                    ViewState.Item("id_grupo") = String.Empty
                End If
                '10/02/2017 - chamado 2501 - Mirella f

                ' 14/02/2017 - chamado 2501 - Mirella i
                If (Not Request("st_pagamento") Is Nothing) Then
                    ViewState.Item("st_pagamento") = Request("st_pagamento")
                Else
                    ViewState.Item("st_pagamento") = String.Empty
                End If
                ' 14/02/2017 - chamado 2501 - Mirella f

                Dim analiseesalq As New AnaliseEsalq
                Dim dsAnaliseEsalc As DataSet 'fran 26/10/2020 i

                If Trim(ViewState.Item("id_propriedade")) <> "" Then
                    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
                End If
                If Trim(ViewState.Item("id_pessoa")) <> "" Then
                    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
                End If
                analiseesalq.dt_coleta_start = DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))
                analiseesalq.dt_coleta_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
                analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_coleta_ini")
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

                '10/02/2017 - chamado 2501 - Mirella i
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                End If

                analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                '10/02/2017 - chamado 2501 - Mirella f

                If Trim(ViewState.Item("id_tecnico")) <> "" Then
                    analiseesalq.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)
                End If

                analiseesalq.st_pagamento = ViewState.Item("st_pagamento") ' 14/02/2017 - chamado 2501 - Mirella 

                Select Case ViewState.Item("id_categoria")
                    Case ViewState.Item("id_categoria") = "1" 'CCS
                        ViewState.Item("cd_analise_esalq") = "53"
                        analiseesalq.cd_analise_esalq = 53
                        analiseesalq.id_conta_teor = "253"
                        analiseesalq.id_conta_bonus = "10"
                        analiseesalq.id_conta_desconto = "11"
                        analiseesalq.id_conta_teor_complience = "274"
                        dsAnaliseEsalc = analiseesalq.getCurvaAbcProdutoresPagamento_Cat1() 'fran 26/10/2020 i

                    Case ViewState.Item("id_categoria") = "2" 'CTM
                        ViewState.Item("cd_analise_esalq") = "52"
                        analiseesalq.cd_analise_esalq = 52
                        analiseesalq.id_conta_teor = "252"
                        analiseesalq.id_conta_bonus = "8"
                        analiseesalq.id_conta_desconto = "9"
                        analiseesalq.id_conta_teor_complience = "273"
                        dsAnaliseEsalc = analiseesalq.getCurvaAbcProdutoresPagamento_Cat2() 'fran 26/10/2020 i

                    Case ViewState.Item("id_categoria") = "3" 'Proteina
                        ViewState.Item("cd_analise_esalq") = "11"
                        analiseesalq.cd_analise_esalq = 11
                        analiseesalq.id_conta_teor = "251"
                        analiseesalq.id_conta_bonus = "6"
                        analiseesalq.id_conta_desconto = "7"
                        analiseesalq.id_conta_teor_complience = "272"
                        dsAnaliseEsalc = analiseesalq.getCurvaAbcProdutoresPagamento_Cat3() 'fran 26/10/2020 i

                    Case ViewState.Item("id_categoria") = "4" 'MG
                        ViewState.Item("cd_analise_esalq") = "8"
                        analiseesalq.cd_analise_esalq = 8
                        analiseesalq.id_conta_teor = "156"
                        analiseesalq.id_conta_bonus = "224"
                        analiseesalq.id_conta_desconto = "225"
                        analiseesalq.id_conta_teor_complience = "275"
                        dsAnaliseEsalc = analiseesalq.getCurvaAbcProdutoresPagamento_Cat4() 'fran 26/10/2020 i
                End Select

                'Dim dsAnaliseEsalc As DataSet = analiseesalq.getCurvaAbcProdutoresPagamento() 'fran 26/10/2020 i

                gridResults.DataSource = Helper.getDataView(dsAnaliseEsalc.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "CurvaABCPagtoProdutores" & ".xls")
                        Response.Charset = ""
                        EnableViewState = False
                        Controls.Add(frm)
                        frm.Controls.Add(gridResults)
                        frm.RenderControl(hw)
                        Response.Write(tw.ToString())
                        Response.End()
                        gridResults.AllowPaging = "True"
                        gridResults.DataBind()
                    Else

                        messageControl.Alert("Não há linhas a serem exportadas!")
                    End If


                Else

                    messageControl.Alert(" Planilha possui muitas linhas, não é possível exportar para o Excel")

                End If

            Catch ex As Exception

                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType = DataControlRowType.Header) Then

            Dim lbl_mes1_coleta1 As Label = CType(e.Row.FindControl("lbl_mes1_coleta1"), Label)
            Dim lbl_mes1_coleta2 As Label = CType(e.Row.FindControl("lbl_mes1_coleta2"), Label)
            Dim lbl_mes1_coleta3 As Label = CType(e.Row.FindControl("lbl_mes1_coleta3"), Label)
            Dim lbl_mes1_coleta4 As Label = CType(e.Row.FindControl("lbl_mes1_coleta4"), Label)
            Dim lbl_mes1_recoleta As Label = CType(e.Row.FindControl("lbl_mes1_recoleta"), Label)


            Dim lbl_mes2_coleta1 As Label = CType(e.Row.FindControl("lbl_mes2_coleta1"), Label)
            Dim lbl_mes2_coleta2 As Label = CType(e.Row.FindControl("lbl_mes2_coleta2"), Label)
            Dim lbl_mes2_coleta3 As Label = CType(e.Row.FindControl("lbl_mes2_coleta3"), Label)
            Dim lbl_mes2_coleta4 As Label = CType(e.Row.FindControl("lbl_mes2_coleta4"), Label)
            Dim lbl_mes2_recoleta As Label = CType(e.Row.FindControl("lbl_mes2_recoleta"), Label)


            Dim lbl_mes3_coleta1 As Label = CType(e.Row.FindControl("lbl_mes3_coleta1"), Label)
            Dim lbl_mes3_coleta2 As Label = CType(e.Row.FindControl("lbl_mes3_coleta2"), Label)
            Dim lbl_mes3_coleta3 As Label = CType(e.Row.FindControl("lbl_mes3_coleta3"), Label)
            Dim lbl_mes3_coleta4 As Label = CType(e.Row.FindControl("lbl_mes3_coleta4"), Label)
            Dim lbl_mes3_recoleta As Label = CType(e.Row.FindControl("lbl_mes3_recoleta"), Label)


            Dim mes1, mes2, mes3 As String
            mes3 = DateTime.Parse(ViewState.Item("txt_dt_coleta_ini")).ToString("MMM").ToUpper
            mes2 = DateTime.Parse(DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper
            mes1 = DateTime.Parse(DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper

            lbl_mes3_coleta1.Text = mes3
            lbl_mes3_coleta2.Text = mes3
            lbl_mes3_coleta3.Text = mes3
            lbl_mes3_coleta4.Text = mes3
            lbl_mes3_recoleta.Text = mes3

            lbl_mes2_coleta1.Text = mes2
            lbl_mes2_coleta2.Text = mes2
            lbl_mes2_coleta3.Text = mes2
            lbl_mes2_coleta4.Text = mes2
            lbl_mes2_recoleta.Text = mes2

            lbl_mes1_coleta1.Text = mes1
            lbl_mes1_coleta2.Text = mes1
            lbl_mes1_coleta3.Text = mes1
            lbl_mes1_coleta4.Text = mes1
            lbl_mes1_recoleta.Text = mes1

        End If

        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            Dim lbl_id_propriedade As Label = CType(e.Row.FindControl("lbl_id_propriedade"), Label)
            Dim lbl_nr_m1_coleta1 As Label = CType(e.Row.FindControl("lbl_nr_m1_coleta1"), Label)
            Dim lbl_nr_m1_coleta2 As Label = CType(e.Row.FindControl("lbl_nr_m1_coleta2"), Label)
            Dim lbl_nr_m1_coleta3 As Label = CType(e.Row.FindControl("lbl_nr_m1_coleta3"), Label)
            Dim lbl_nr_m1_coleta4 As Label = CType(e.Row.FindControl("lbl_nr_m1_coleta4"), Label)

            Dim lbl_nr_m2_coleta1 As Label = CType(e.Row.FindControl("lbl_nr_m2_coleta1"), Label)
            Dim lbl_nr_m2_coleta2 As Label = CType(e.Row.FindControl("lbl_nr_m2_coleta2"), Label)
            Dim lbl_nr_m2_coleta3 As Label = CType(e.Row.FindControl("lbl_nr_m2_coleta3"), Label)
            Dim lbl_nr_m2_coleta4 As Label = CType(e.Row.FindControl("lbl_nr_m2_coleta4"), Label)

            Dim lbl_nr_m3_coleta1 As Label = CType(e.Row.FindControl("lbl_nr_m3_coleta1"), Label)
            Dim lbl_nr_m3_coleta2 As Label = CType(e.Row.FindControl("lbl_nr_m3_coleta2"), Label)
            Dim lbl_nr_m3_coleta3 As Label = CType(e.Row.FindControl("lbl_nr_m3_coleta3"), Label)
            Dim lbl_nr_m3_coleta4 As Label = CType(e.Row.FindControl("lbl_nr_m3_coleta4"), Label)

            Dim lbl_nr_m1_recoleta1 As Label = CType(e.Row.FindControl("lbl_nr_m1_recoleta1"), Label)
            Dim lbl_nr_m1_recoleta2 As Label = CType(e.Row.FindControl("lbl_nr_m1_recoleta2"), Label)
            Dim lbl_nr_m1_recoleta3 As Label = CType(e.Row.FindControl("lbl_nr_m1_recoleta3"), Label)
            Dim lbl_nr_m1_recoleta4 As Label = CType(e.Row.FindControl("lbl_nr_m1_recoleta4"), Label)

            Dim lbl_nr_m2_recoleta1 As Label = CType(e.Row.FindControl("lbl_nr_m2_recoleta1"), Label)
            Dim lbl_nr_m2_recoleta2 As Label = CType(e.Row.FindControl("lbl_nr_m2_recoleta2"), Label)
            Dim lbl_nr_m2_recoleta3 As Label = CType(e.Row.FindControl("lbl_nr_m2_recoleta3"), Label)
            Dim lbl_nr_m2_recoleta4 As Label = CType(e.Row.FindControl("lbl_nr_m2_recoleta4"), Label)

            Dim lbl_nr_m3_recoleta1 As Label = CType(e.Row.FindControl("lbl_nr_m3_recoleta1"), Label)
            Dim lbl_nr_m3_recoleta2 As Label = CType(e.Row.FindControl("lbl_nr_m3_recoleta2"), Label)
            Dim lbl_nr_m3_recoleta3 As Label = CType(e.Row.FindControl("lbl_nr_m3_recoleta3"), Label)
            Dim lbl_nr_m3_recoleta4 As Label = CType(e.Row.FindControl("lbl_nr_m3_recoleta4"), Label)

            Dim lbl_m1_st_recoleta_S As Label = CType(e.Row.FindControl("lbl_m1_st_recoleta_S"), Label)
            Dim lbl_m2_st_recoleta_S As Label = CType(e.Row.FindControl("lbl_m2_st_recoleta_S"), Label)
            Dim lbl_m3_st_recoleta_S As Label = CType(e.Row.FindControl("lbl_m3_st_recoleta_S"), Label)

            Dim lbl_nr_bonus As Label = CType(e.Row.FindControl("lbl_nr_bonus"), Label)
            Dim lbl_nr_teor As Label = CType(e.Row.FindControl("lbl_nr_teor"), Label)

            Dim lbl_nr_volume As Label = CType(e.Row.FindControl("lbl_nr_volume"), Label)

            lbl_nr_volume.Text = FormatNumber(lbl_nr_volume.Text, 0)
            If Not lbl_nr_bonus.Text.Equals(String.Empty) Then
                lbl_nr_bonus.Text = FormatNumber(lbl_nr_bonus.Text, 2)
            End If

            Dim ldecimal As Integer
            'se categoria 1 ou 2 ccs ou cbt
            If ViewState.Item("id_categoria") = 1 OrElse ViewState.Item("id_categoria") = 2 Then
                ldecimal = 0
            Else
                ldecimal = 4
            End If

            If Not lbl_nr_teor.Text.Equals(String.Empty) Then
                lbl_nr_teor.Text = FormatNumber(lbl_nr_teor.Text, ldecimal)
            End If


            'CAMPOS DA REFERENCIA MENOS 2 MESes 
            If lbl_nr_m1_coleta1.Text.Equals(String.Empty) Then
                lbl_nr_m1_coleta1.Text = "---"
            Else
                lbl_nr_m1_coleta1.Text = FormatNumber(lbl_nr_m1_coleta1.Text, ldecimal).ToString
            End If
            If lbl_nr_m1_coleta2.Text.Equals(String.Empty) Then
                lbl_nr_m1_coleta2.Text = "---"
            Else
                lbl_nr_m1_coleta2.Text = FormatNumber(lbl_nr_m1_coleta2.Text, ldecimal).ToString
            End If
            If lbl_nr_m1_coleta3.Text.Equals(String.Empty) Then
                lbl_nr_m1_coleta3.Text = "---"
            Else
                lbl_nr_m1_coleta3.Text = FormatNumber(lbl_nr_m1_coleta3.Text, ldecimal).ToString
            End If
            If lbl_nr_m1_coleta4.Text.Equals(String.Empty) Then
                lbl_nr_m1_coleta4.Text = "---"
            Else
                lbl_nr_m1_coleta4.Text = FormatNumber(lbl_nr_m1_coleta4.Text, ldecimal).ToString
            End If

            'se todas as recoletas sao vazias
            If lbl_nr_m1_recoleta1.Text = "" AndAlso lbl_nr_m1_recoleta2.Text = "" AndAlso lbl_nr_m1_recoleta3.Text = "" AndAlso lbl_nr_m1_recoleta4.Text = "" Then
                lbl_m1_st_recoleta_S.Visible = False
            Else
                lbl_m1_st_recoleta_S.Visible = True
                lbl_nr_m1_recoleta1.Visible = True
                lbl_nr_m1_recoleta2.Visible = True
                lbl_nr_m1_recoleta3.Visible = True
                lbl_nr_m1_recoleta4.Visible = True

                If lbl_nr_m1_recoleta1.Text.Equals(String.Empty) Then
                    lbl_nr_m1_recoleta1.Text = "---"
                Else
                    lbl_nr_m1_recoleta1.Text = FormatNumber(lbl_nr_m1_recoleta1.Text, ldecimal).ToString
                End If
                If lbl_nr_m1_recoleta2.Text.Equals(String.Empty) Then
                    lbl_nr_m1_recoleta2.Text = "---"
                Else
                    lbl_nr_m1_recoleta2.Text = FormatNumber(lbl_nr_m1_recoleta2.Text, ldecimal).ToString
                End If
                If lbl_nr_m1_recoleta3.Text.Equals(String.Empty) Then
                    lbl_nr_m1_recoleta3.Text = "---"
                Else
                    lbl_nr_m1_recoleta3.Text = FormatNumber(lbl_nr_m1_recoleta3.Text, ldecimal).ToString
                End If
                If lbl_nr_m1_recoleta4.Text.Equals(String.Empty) Then
                    lbl_nr_m1_recoleta4.Text = "---"
                Else
                    lbl_nr_m1_recoleta4.Text = FormatNumber(lbl_nr_m1_recoleta4.Text, ldecimal).ToString
                End If

            End If

            'CAMPOS DA REFERENCIA MENOS 1 MES
            If lbl_nr_m2_coleta1.Text.Equals(String.Empty) Then
                lbl_nr_m2_coleta1.Text = "---"
            Else
                lbl_nr_m2_coleta1.Text = FormatNumber(lbl_nr_m2_coleta1.Text, ldecimal).ToString
            End If
            If lbl_nr_m2_coleta2.Text.Equals(String.Empty) Then
                lbl_nr_m2_coleta2.Text = "---"
            Else
                lbl_nr_m2_coleta2.Text = FormatNumber(lbl_nr_m2_coleta2.Text, ldecimal).ToString
            End If
            If lbl_nr_m2_coleta3.Text.Equals(String.Empty) Then
                lbl_nr_m2_coleta3.Text = "---"
            Else
                lbl_nr_m2_coleta3.Text = FormatNumber(lbl_nr_m2_coleta3.Text, ldecimal).ToString
            End If
            If lbl_nr_m2_coleta4.Text.Equals(String.Empty) Then
                lbl_nr_m2_coleta4.Text = "---"
            Else
                lbl_nr_m2_coleta4.Text = FormatNumber(lbl_nr_m2_coleta4.Text, ldecimal).ToString
            End If

            'se todas as recoletas sao vazias
            If lbl_nr_m2_recoleta1.Text = "" AndAlso lbl_nr_m2_recoleta2.Text = "" AndAlso lbl_nr_m2_recoleta3.Text = "" AndAlso lbl_nr_m2_recoleta4.Text = "" Then
                lbl_m2_st_recoleta_S.Visible = False
            Else
                lbl_m2_st_recoleta_S.Visible = True
                lbl_nr_m2_recoleta1.Visible = True
                lbl_nr_m2_recoleta2.Visible = True
                lbl_nr_m2_recoleta3.Visible = True
                lbl_nr_m2_recoleta4.Visible = True

                If lbl_nr_m2_recoleta1.Text.Equals(String.Empty) Then
                    lbl_nr_m2_recoleta1.Text = "---"
                Else
                    lbl_nr_m2_recoleta1.Text = FormatNumber(lbl_nr_m2_recoleta1.Text, ldecimal).ToString
                End If
                If lbl_nr_m2_recoleta2.Text.Equals(String.Empty) Then
                    lbl_nr_m2_recoleta2.Text = "---"
                Else
                    lbl_nr_m2_recoleta2.Text = FormatNumber(lbl_nr_m2_recoleta2.Text, ldecimal).ToString
                End If
                If lbl_nr_m2_recoleta3.Text.Equals(String.Empty) Then
                    lbl_nr_m2_recoleta3.Text = "---"
                Else
                    lbl_nr_m2_recoleta3.Text = FormatNumber(lbl_nr_m2_recoleta3.Text, ldecimal).ToString
                End If
                If lbl_nr_m2_recoleta4.Text.Equals(String.Empty) Then
                    lbl_nr_m2_recoleta4.Text = "---"
                Else
                    lbl_nr_m2_recoleta4.Text = FormatNumber(lbl_nr_m2_recoleta4.Text, ldecimal).ToString
                End If

            End If

            'CAMPOS DA REFERENCIA 
            If lbl_nr_m3_coleta1.Text.Equals(String.Empty) Then
                lbl_nr_m3_coleta1.Text = "---"
            Else
                lbl_nr_m3_coleta1.Text = FormatNumber(lbl_nr_m3_coleta1.Text, ldecimal).ToString
            End If
            If lbl_nr_m3_coleta2.Text.Equals(String.Empty) Then
                lbl_nr_m3_coleta2.Text = "---"
            Else
                lbl_nr_m3_coleta2.Text = FormatNumber(lbl_nr_m3_coleta2.Text, ldecimal).ToString
            End If
            If lbl_nr_m3_coleta3.Text.Equals(String.Empty) Then
                lbl_nr_m3_coleta3.Text = "---"
            Else
                lbl_nr_m3_coleta3.Text = FormatNumber(lbl_nr_m3_coleta3.Text, ldecimal).ToString
            End If
            If lbl_nr_m3_coleta4.Text.Equals(String.Empty) Then
                lbl_nr_m3_coleta4.Text = "---"
            Else
                lbl_nr_m3_coleta4.Text = FormatNumber(lbl_nr_m3_coleta4.Text, ldecimal).ToString
            End If

            'se todas as recoletas sao vazias
            If lbl_nr_m3_recoleta1.Text = "" AndAlso lbl_nr_m3_recoleta2.Text = "" AndAlso lbl_nr_m3_recoleta3.Text = "" AndAlso lbl_nr_m3_recoleta4.Text = "" Then
                lbl_m3_st_recoleta_S.Visible = False
            Else
                lbl_m3_st_recoleta_S.Visible = True
                lbl_nr_m3_recoleta1.Visible = True
                lbl_nr_m3_recoleta2.Visible = True
                lbl_nr_m3_recoleta3.Visible = True
                lbl_nr_m3_recoleta4.Visible = True

                If lbl_nr_m3_recoleta1.Text.Equals(String.Empty) Then
                    lbl_nr_m3_recoleta1.Text = "---"
                Else
                    lbl_nr_m3_recoleta1.Text = FormatNumber(lbl_nr_m3_recoleta1.Text, ldecimal).ToString
                End If
                If lbl_nr_m3_recoleta2.Text.Equals(String.Empty) Then
                    lbl_nr_m3_recoleta2.Text = "---"
                Else
                    lbl_nr_m3_recoleta2.Text = FormatNumber(lbl_nr_m3_recoleta2.Text, ldecimal).ToString
                End If
                If lbl_nr_m3_recoleta3.Text.Equals(String.Empty) Then
                    lbl_nr_m3_recoleta3.Text = "---"
                Else
                    lbl_nr_m3_recoleta3.Text = FormatNumber(lbl_nr_m3_recoleta3.Text, ldecimal).ToString
                End If
                If lbl_nr_m3_recoleta4.Text.Equals(String.Empty) Then
                    lbl_nr_m3_recoleta4.Text = "---"
                Else
                    lbl_nr_m3_recoleta4.Text = FormatNumber(lbl_nr_m3_recoleta4.Text, ldecimal).ToString
                End If

            End If

            Dim lbl_complience As Label = CType(e.Row.FindControl("lbl_complience"), Label)
            If lbl_complience.Text = "COMPL" Then
                lbl_complience.ForeColor = Drawing.Color.Blue
            Else
                lbl_complience.ForeColor = Drawing.Color.Red
            End If
            Dim lbl_complience_geral As Label = CType(e.Row.FindControl("lbl_complience_geral"), Label)
            If lbl_complience_geral.Text = "COMPL" Then
                lbl_complience_geral.ForeColor = Drawing.Color.Blue
            Else
                lbl_complience_geral.ForeColor = Drawing.Color.Red
            End If

            'Dim analiseesalq As New AnaliseEsalq
            'analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
            'analiseesalq.dt_coleta_start = DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))
            'analiseesalq.dt_coleta_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
            'analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_coleta_ini")
            'analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'analiseesalq.id_propriedade = lbl_id_propriedade.Text
            'Dim dsCurvaAbcAnalises As DataSet = analiseesalq.getCurvaAbcProdutoresAnalises()

            'Dim li As Int32
            'li = 0
            'For li = 0 To dsCurvaAbcAnalises.Tables(0).Rows.Count - 1

            '    If DateTime.Parse(dsCurvaAbcAnalises.Tables(0).Rows(li).Item("dt_coleta").ToString).ToString("MM/yyyy") = ViewState.Item("txt_dt_coleta_ini") Then

            '        If ViewState.Item("id_categoria") = 1 Or ViewState.Item("id_categoria") = 2 Then
            '            ViewState.Item("nr_valor_esalq") = FormatNumber(dsCurvaAbcAnalises.Tables(0).Rows(li).Item("nr_valor_esalq").ToString, 0)
            '        Else
            '            ViewState.Item("nr_valor_esalq") = dsCurvaAbcAnalises.Tables(0).Rows(li).Item("nr_valor_esalq").ToString
            '        End If


            '        Select Case dsCurvaAbcAnalises.Tables(0).Rows(li).Item("id_tipo_coleta_analise_esalq").ToString

            '            Case "1"
            '                lbl_nr_m3_coleta1.Text = ViewState.Item("nr_valor_esalq")
            '            Case "2"
            '                lbl_nr_m3_coleta2.Text = ViewState.Item("nr_valor_esalq")
            '            Case "3"
            '                lbl_nr_m3_coleta3.Text = ViewState.Item("nr_valor_esalq")
            '            Case "4"
            '                lbl_nr_m3_coleta4.Text = ViewState.Item("nr_valor_esalq")
            '            Case "11"
            '                lbl_nr_m3_recoleta1.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m3_st_recoleta_S.Visible = True
            '            Case "12"
            '                lbl_nr_m3_recoleta2.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m3_st_recoleta_S.Visible = True
            '            Case "13"
            '                lbl_nr_m3_recoleta3.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m3_st_recoleta_S.Visible = True
            '            Case "14"
            '                lbl_nr_m3_recoleta4.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m3_st_recoleta_S.Visible = True

            '        End Select

            '        If lbl_m3_st_recoleta_S.Visible = True Then
            '            lbl_nr_m3_recoleta1.Visible = True
            '            lbl_nr_m3_recoleta2.Visible = True
            '            lbl_nr_m3_recoleta3.Visible = True
            '            lbl_nr_m3_recoleta4.Visible = True
            '        End If

            '    End If
            '    If DateTime.Parse(dsCurvaAbcAnalises.Tables(0).Rows(li).Item("dt_coleta").ToString).ToString("MM/yyyy") = DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))) Then
            '        If ViewState.Item("id_categoria") = 1 Or ViewState.Item("id_categoria") = 2 Then
            '            ViewState.Item("nr_valor_esalq") = FormatNumber(dsCurvaAbcAnalises.Tables(0).Rows(li).Item("nr_valor_esalq").ToString, 0)
            '        Else
            '            ViewState.Item("nr_valor_esalq") = dsCurvaAbcAnalises.Tables(0).Rows(li).Item("nr_valor_esalq").ToString
            '        End If
            '        Select Case dsCurvaAbcAnalises.Tables(0).Rows(li).Item("id_tipo_coleta_analise_esalq").ToString

            '            Case "1"
            '                lbl_nr_m2_coleta1.Text = ViewState.Item("nr_valor_esalq")
            '            Case "2"
            '                lbl_nr_m2_coleta2.Text = ViewState.Item("nr_valor_esalq")
            '            Case "3"
            '                lbl_nr_m2_coleta3.Text = ViewState.Item("nr_valor_esalq")
            '            Case "4"
            '                lbl_nr_m2_coleta4.Text = ViewState.Item("nr_valor_esalq")
            '            Case "11"
            '                lbl_nr_m2_recoleta1.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m2_st_recoleta_S.Visible = True
            '            Case "12"
            '                lbl_nr_m2_recoleta2.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m2_st_recoleta_S.Visible = True
            '            Case "13"
            '                lbl_nr_m2_recoleta3.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m2_st_recoleta_S.Visible = True
            '            Case "14"
            '                lbl_nr_m2_recoleta4.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m2_st_recoleta_S.Visible = True

            '        End Select

            '        If lbl_m2_st_recoleta_S.Visible = True Then
            '            lbl_nr_m2_recoleta1.Visible = True
            '            lbl_nr_m2_recoleta2.Visible = True
            '            lbl_nr_m2_recoleta3.Visible = True
            '            lbl_nr_m2_recoleta4.Visible = True
            '        End If

            '    End If
            '    If DateTime.Parse(dsCurvaAbcAnalises.Tables(0).Rows(li).Item("dt_coleta").ToString).ToString("MM/yyyy") = DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))) Then
            '        If ViewState.Item("id_categoria") = 1 Or ViewState.Item("id_categoria") = 2 Then
            '            ViewState.Item("nr_valor_esalq") = FormatNumber(dsCurvaAbcAnalises.Tables(0).Rows(li).Item("nr_valor_esalq").ToString, 0)
            '        Else
            '            ViewState.Item("nr_valor_esalq") = dsCurvaAbcAnalises.Tables(0).Rows(li).Item("nr_valor_esalq").ToString
            '        End If

            '        Select Case dsCurvaAbcAnalises.Tables(0).Rows(li).Item("id_tipo_coleta_analise_esalq").ToString

            '            Case "1"
            '                lbl_nr_m1_coleta1.Text = ViewState.Item("nr_valor_esalq")
            '            Case "2"
            '                lbl_nr_m1_coleta2.Text = ViewState.Item("nr_valor_esalq")
            '            Case "3"
            '                lbl_nr_m1_coleta3.Text = ViewState.Item("nr_valor_esalq")
            '            Case "4"
            '                lbl_nr_m1_coleta4.Text = ViewState.Item("nr_valor_esalq")
            '            Case "11"
            '                lbl_nr_m1_recoleta1.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m1_st_recoleta_S.Visible = True
            '            Case "12"
            '                lbl_nr_m1_recoleta2.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m1_st_recoleta_S.Visible = True
            '            Case "13"
            '                lbl_nr_m1_recoleta3.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m1_st_recoleta_S.Visible = True
            '            Case "14"
            '                lbl_nr_m1_recoleta4.Text = ViewState.Item("nr_valor_esalq")
            '                lbl_m1_st_recoleta_S.Visible = True
            '        End Select

            '        If lbl_m1_st_recoleta_S.Visible = True Then
            '            lbl_nr_m1_recoleta1.Visible = True
            '            lbl_nr_m1_recoleta2.Visible = True
            '            lbl_nr_m1_recoleta3.Visible = True
            '            lbl_nr_m1_recoleta4.Visible = True
            '        End If
            '        ' adri 23/12/2016
            '        Dim lbl_complience As Label = CType(e.Row.FindControl("lbl_complience"), Label)
            '        If lbl_complience.Text = "COMPL" Then
            '            lbl_complience.ForeColor = Drawing.Color.Blue
            '        Else
            '            lbl_complience.ForeColor = Drawing.Color.Red
            '        End If
            '        Dim lbl_complience_geral As Label = CType(e.Row.FindControl("lbl_complience_geral"), Label)
            '        If lbl_complience_geral.Text = "COMPL" Then
            '            lbl_complience_geral.ForeColor = Drawing.Color.Blue
            '        Else
            '            lbl_complience_geral.ForeColor = Drawing.Color.Red
            '        End If


            '    End If

            'Next



        End If
    End Sub

End Class
