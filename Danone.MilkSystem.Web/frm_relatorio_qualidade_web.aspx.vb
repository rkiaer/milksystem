Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_relatorio_qualidade_web
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_relatorio_qualidade_web.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 152
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("dt_referencia") Is Nothing) Then
                ViewState.Item("dt_referencia") = Request("dt_referencia")
                ViewState.Item("id_propriedade") = Request("id_propriedade")
                ViewState.Item("id_unid_producao") = Request("id_unid_producao")

                ' Calcula referencia final para buscar conta na ficha financeira
                ViewState.Item("dt_referencia_end") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_referencia"))))

                ' 06/09/2016 - Unificação das UP's (somente pode unificar se após ref. 07/2016 - i
                If CDate(DateTime.Parse(ViewState.Item("dt_referencia")).ToString("dd/MM/yyyy")) >= CDate("01/07/2016") Then

                    Dim extratoqualidadeweb As New ExtratoQualidadeWeb
                    extratoqualidadeweb.dt_referencia = ViewState.Item("dt_referencia").ToString
                    extratoqualidadeweb.id_propriedade = ViewState.Item("id_propriedade")
                    extratoqualidadeweb.st_tipo_pagamento = "C"  ' Traz Unidade de Produção do Cálculo Consolidade se existir
                    ViewState.Item("id_unid_producao") = 0
                    Dim dsPropriedadeConsolidada As DataSet = extratoqualidadeweb.getExtratoQualidadePropriedadesUnidadeProducaoWeb()
                    If (dsPropriedadeConsolidada.Tables(0).Rows.Count > 0) Then
                        ViewState.Item("PropriedadeConsolidada") = "S"
                        ViewState.Item("id_unid_producao") = dsPropriedadeConsolidada.Tables(0).Rows(0).Item("id_unid_producao")
                    Else
                        ViewState.Item("PropriedadeConsolidada") = "N"
                        extratoqualidadeweb.st_tipo_pagamento = "M"  ' Traz Unidade de Produção do Cálculo Consolidade se existir
                        Dim dsPropriedade As DataSet = extratoqualidadeweb.getExtratoQualidadePropriedadesUnidadeProducaoWeb()
                        If (dsPropriedade.Tables(0).Rows.Count > 0) Then
                            ViewState.Item("id_unid_producao") = dsPropriedade.Tables(0).Rows(0).Item("id_unid_producao")
                        End If
                    End If

                Else  ' se ref. < 07/2016

                    ViewState.Item("PropriedadeConsolidada") = "N"  ' Assume que não é consolidada
                End If

                ' 06/09/2016 - Unificação das UP's - f

                loadData()
            Else
                messagecontrol.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
            End If
        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try
            Dim extratoqualidadeweb As New ExtratoQualidadeWeb
            Dim st_emite_nota_fiscal As String = "N" 'fran 02/06/2016

            'nao tem linhas no grid
            ViewState.Item("gridsemlinhas") = False

            extratoqualidadeweb.dt_referencia = ViewState.Item("dt_referencia").ToString
            extratoqualidadeweb.id_propriedade = ViewState.Item("id_propriedade")
            'extratoqualidadeweb.id_unid_producao = ViewState.Item("id_unid_producao").ToString
            If ViewState.Item("PropriedadeConsolidada") = "N" Then  ' 06/09/2016 - Unificação das UP's
                extratoqualidadeweb.id_unid_producao = ViewState.Item("id_unid_producao").ToString
            End If

            Dim dsMovimento As DataSet = extratoqualidadeweb.getExtratoQualidadeWebbyFilters()
            If (dsMovimento.Tables(0).Rows.Count > 0) Then
                Me.lbl_dsprodutor.Text = dsMovimento.Tables(0).Rows(0).Item("cd_pessoa").ToString & " - " & dsMovimento.Tables(0).Rows(0).Item("nm_pessoa").ToString
                Me.lbl_dspropriedade.Text = dsMovimento.Tables(0).Rows(0).Item("ds_propriedade").ToString
                Me.lbl_dsrota.Text = dsMovimento.Tables(0).Rows(0).Item("linha_par").ToString
                st_emite_nota_fiscal = dsMovimento.Tables(0).Rows(0).Item("st_emite_nota_fiscal").ToString 'fran 02/06/2016
            End If

            '=================================================================================
            ' Monta Grid de Movimento de Leite
            '================================================================================
            If (dsMovimento.Tables(0).Rows.Count > 0) Then
                gridMovimento.Visible = True
                gridMovimento.DataSource = Helper.getDataView(dsMovimento.Tables(0), ViewState.Item("sortExpression"))
                gridMovimento.DataBind()
            Else
                Dim dr As DataRow = dsMovimento.Tables(0).NewRow()
                dsMovimento.Tables(0).Rows.InsertAt(dr, 0)
                gridMovimento.Visible = True
                gridMovimento.DataSource = Helper.getDataView(dsMovimento.Tables(0), "")
                gridMovimento.DataBind()
                gridMovimento.Rows(0).Cells.Clear()
                gridMovimento.Rows(0).Cells.Add(New TableCell())
                gridMovimento.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridMovimento.Rows(0).Cells(0).Text = "Não existem coletas!"
                gridMovimento.Rows(0).Cells(0).ColumnSpan = 2

            End If

            '=================================================================================
            ' Monta Grid de Análise de Leite
            '================================================================================
            extratoqualidadeweb.dt_referencia = ViewState.Item("dt_referencia").ToString
            extratoqualidadeweb.id_propriedade = ViewState.Item("id_propriedade")
            If ViewState.Item("PropriedadeConsolidada") = "N" Then  ' 06/09/2016 - Unificação das UP's
                extratoqualidadeweb.id_unid_producao = ViewState.Item("id_unid_producao").ToString  ' 08/09/2016 - adri - Unificação de UP's
            End If

            Dim dsAnalise As DataSet
            'chamado 2478 - 02/09/2016 -  i
            If CDate(ViewState.Item("dt_referencia")) < CDate("01/07/2016") Then
                extratoqualidadeweb.dt_referencia = ViewState.Item("dt_referencia").ToString
                extratoqualidadeweb.id_propriedade = ViewState.Item("id_propriedade")
                extratoqualidadeweb.id_unid_producao = ViewState.Item("id_unid_producao").ToString
                dsAnalise = extratoqualidadeweb.getExtratoQualidade_analise_web()
            Else
                lbl_media_linear.Visible = True
                lbl_media_geometrica.Visible = True
                extratoqualidadeweb.dt_referencia_calculogeometrico_start = DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("dt_referencia")))
                extratoqualidadeweb.dt_referencia_calculogeometrico_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_referencia"))))
                extratoqualidadeweb.id_propriedade = ViewState.Item("id_propriedade")
                'extratoqualidadeweb.id_unid_producao = ViewState.Item("id_unid_producao").ToString  ' 08/09/2016 - adri - Unificação de UP's
                dsAnalise = extratoqualidadeweb.getExtratoQualidade_analise_web_calculogeometrico()
            End If
            'chamado 2478 - 02/09/2016 -  f

            'Dim dsAnalise As DataSet = extratoqualidadeweb.getExtratoQualidade_analise_web()

            If (dsAnalise.Tables(0).Rows.Count > 0) Then
                gridAnalise.Visible = True
                gridAnalise.DataSource = Helper.getDataView(dsAnalise.Tables(0), ViewState.Item("sortExpression"))
                gridAnalise.DataBind()
            Else
                ViewState.Item("gridsemlinhas") = True
                Dim dr As DataRow = dsAnalise.Tables(0).NewRow()
                dsAnalise.Tables(0).Rows.InsertAt(dr, 0)
                gridAnalise.Visible = True
                gridAnalise.DataSource = Helper.getDataView(dsAnalise.Tables(0), "")
                gridAnalise.DataBind()
                ViewState.Item("gridsemlinhas") = False
                gridAnalise.Rows(0).Cells.Clear()
                gridAnalise.Rows(0).Cells.Add(New TableCell())
                gridAnalise.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridAnalise.Rows(0).Cells(0).Text = "Não existem dados de análise!"
                gridAnalise.Rows(0).Cells(0).ColumnSpan = 5

            End If


            '=================================================================================
            ' Monta Grid Financeiro
            '================================================================================
            extratoqualidadeweb.dt_referencia_pagto = ViewState.Item("dt_referencia").ToString   ' a procedure do Motor já utilizava esta variável
            extratoqualidadeweb.id_propriedade = ViewState.Item("id_propriedade")
            extratoqualidadeweb.id_unid_producao = ViewState.Item("id_unid_producao").ToString

            ' 08/09/2016 - adri - Unificação de UP's - i
            If ViewState.Item("PropriedadeConsolidada") = "S" Then  ' Se a Propriedade foi Consolidada (mais de uma UP)
                extratoqualidadeweb.st_tipo_pagamento = "C"
            Else
                extratoqualidadeweb.st_tipo_pagamento = "M"
            End If
            ' 08/09/2016 - adri - Unificação de UP's - f

            Dim dsFinanceiro As DataSet = extratoqualidadeweb.getExtratoQualidade_pagto_web()

            If (dsFinanceiro.Tables(0).Rows.Count > 0) Then

                'fran 02/06/2016 se for agropecuaria (emite nota = S) deve retirar algumas contas do extrato i
                If st_emite_nota_fiscal.Equals("S") Then
                    If CDate(ViewState.Item("dt_referencia")) < CDate("01/09/2017") Then 'fran 09/2017 

                        Dim row As DataRow
                        Dim lidconta As Int32
                        For Each row In dsFinanceiro.Tables(0).Rows
                            If row.Item("id_conta").Equals("0") OrElse row.Item("id_conta").Equals("") Then
                                lidconta = 0
                            Else
                                lidconta = CInt(row.Item("id_conta").ToString)
                            End If
                            Select Case lidconta
                                'caso seja alguma das contas de calculo, não deve exibir para propriedade que emitem nota fiscam (agropeciaria)
                                'CONTAS em ordem no case:
                                '0030,0041,0080,0081,0090,0091,0100,0101,0110,0111,0150,0151,0200,0300,1000,1400,1500,1700,2000,2040,2050,2055,5000,5058
                                Case 3, 5, 6, 7, 8, 9, 10, 11, 224, 225, 62, 64, 14, 12, 16, 19, 20, 37, 40, 67, 68, 76, 250, 146
                                    row.Delete()
                            End Select
                        Next
                    End If
                End If
                'fran 02/06/2016 se for agropecuaria (emite nota = S) deve retirar algumas contas do extrato i


                GridFinanceiro.Visible = True
                GridFinanceiro.DataSource = Helper.getDataView(dsFinanceiro.Tables(0), ViewState.Item("sortExpression"))
                GridFinanceiro.DataBind()
            Else
                Dim dr As DataRow = dsFinanceiro.Tables(0).NewRow()
                dsFinanceiro.Tables(0).Rows.InsertAt(dr, 0)
                GridFinanceiro.Visible = True
                GridFinanceiro.DataSource = Helper.getDataView(dsFinanceiro.Tables(0), "")
                GridFinanceiro.DataBind()
                GridFinanceiro.Rows(0).Cells.Clear()
                GridFinanceiro.Rows(0).Cells.Add(New TableCell())
                GridFinanceiro.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                GridFinanceiro.Rows(0).Cells(0).Text = "Não existem dados financeiros!"
                GridFinanceiro.Rows(0).Cells(0).ColumnSpan = 4

            End If

        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridAnalise_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridAnalise.RowDataBound

        If (e.Row.RowType = DataControlRowType.Header) Then 'chamado 2478 - 02/09/2016 -  i

            ' 06/09/2016 - Unificação das UP's - i
            If ViewState.Item("PropriedadeConsolidada") = "N" Then  ' Se não tem mais de uma UP
                e.Row.Cells(0).Visible = False
            End If
            ' 06/09/2016 - Unificação das UP's - f

            If CDate(ViewState.Item("dt_referencia")) >= CDate("01/07/2016") Then
                Dim lbl_MG_header As Label = CType(e.Row.FindControl("lbl_MG_header"), Label)
                Dim lbl_Prot_header = CType(e.Row.FindControl("lbl_Prot_header"), Label)
                Dim lbl_CCS_header As Label = CType(e.Row.FindControl("lbl_CCS_header"), Label)
                Dim lbl_CBT_header As Label = CType(e.Row.FindControl("lbl_CBT_header"), Label)

                'e.Row.Cells(1).Text = "MG¹"
                'e.Row.Cells(2).Text = "Prot¹"
                'e.Row.Cells(3).Text = "CCS²"
                'e.Row.Cells(4).Text = "CBT²"

                lbl_MG_header.Text = "MG¹"
                lbl_Prot_header.Text = "Prot¹"
                lbl_CCS_header.Text = "CCS²"
                lbl_CBT_header.Text = "CBT²"

            End If
        End If 'chamado 2478 - 02/09/2016 -  f
        If (e.Row.RowType <> DataControlRowType.Header _
        And e.Row.RowType <> DataControlRowType.Footer _
        And e.Row.RowType <> DataControlRowType.Pager) And ViewState.Item("gridsemlinhas") = False Then

            ' 06/09/2016 - Unificação das UP's - i
            If ViewState.Item("PropriedadeConsolidada") = "N" Then  ' Se não tem mais de uma UP
                e.Row.Cells(0).Visible = False
            End If
            ' 06/09/2016 - Unificação das UP's - f


            Dim lbl_dt_analise As Label = CType(e.Row.FindControl("lbl_dt_analise"), Label)
            Dim lbl_MG As Label = CType(e.Row.FindControl("lbl_MG"), Label)
            Dim lbl_Prot = CType(e.Row.FindControl("lbl_Prot"), Label)
            Dim lbl_CCS As Label = CType(e.Row.FindControl("lbl_CCS"), Label)
            Dim lbl_CBT As Label = CType(e.Row.FindControl("lbl_CBT"), Label)
            Dim lbl_id_unid_producao As Label = CType(e.Row.FindControl("lbl_id_unid_producao"), Label)  ' adri 05/09/2016 - Unificar UP's

            Dim lbl_nm_sigla As Label = CType(e.Row.FindControl("lbl_nm_sigla"), Label)
            Dim lbl_nr_valor_esalq As Label = CType(e.Row.FindControl("lbl_nr_valor_esalq"), Label)

            Dim extratoqualidadeweb As New ExtratoQualidadeWeb
            extratoqualidadeweb.id_propriedade = ViewState.Item("id_propriedade")
            'extratoqualidadeweb.id_unid_producao = ViewState.Item("id_unid_producao").ToString
            extratoqualidadeweb.id_unid_producao = lbl_id_unid_producao.Text  ' adri 05/09/2016 - Unificar UP's

            If IsDate(lbl_dt_analise.Text) Then

                ' Busca Análises
                'extratoqualidadeweb.dt_referencia = ViewState.Item("dt_referencia").ToString
                extratoqualidadeweb.dt_referencia = "01/" + DateTime.Parse(lbl_dt_analise.Text).ToString("MM/yyyy")  'chamado 2478 - 02/09/2016 -  i
                extratoqualidadeweb.dt_analise = lbl_dt_analise.Text

                If (CDate(ViewState.Item("dt_referencia")) >= CDate("01/07/2016")) And (CDate(ViewState.Item("dt_referencia").ToString) > CDate("01/" + DateTime.Parse(lbl_dt_analise.Text).ToString("MM/yyyy"))) Then  'chamado 2478 - 02/09/2016 -  i
                    lbl_MG.Enabled = False
                    lbl_Prot.Enabled = False

                End If  'chamado 2478 - 02/09/2016 -  f


                Dim dsAnalisesValores As DataSet = extratoqualidadeweb.getExtratoQualidade_analise_valor_web()

                Dim li As Int32
                li = 0
                For li = 0 To dsAnalisesValores.Tables(0).Rows.Count - 1

                    Select Case dsAnalisesValores.Tables(0).Rows(li).Item("nm_sigla").ToString

                        Case "MG"
                            lbl_MG.Text = dsAnalisesValores.Tables(0).Rows(li).Item("nr_valor_esalq").ToString

                        Case "Prot"
                            lbl_Prot.Text = dsAnalisesValores.Tables(0).Rows(li).Item("nr_valor_esalq").ToString

                        Case "CCS"
                            'lbl_CCS.Text = dsAnalisesValores.Tables(0).Rows(li).Item("nr_valor_esalq").ToString
                            If dsAnalisesValores.Tables(0).Rows(li).Item("nr_valor_esalq").ToString <> "" Then  ' 23/11/2015 - adri - Solicitação do DAL
                                lbl_CCS.Text = FormatNumber(dsAnalisesValores.Tables(0).Rows(li).Item("nr_valor_esalq"), 0)
                            End If

                        Case "CTM"  ' mesmo que CBT
                            'lbl_CBT.Text = dsAnalisesValores.Tables(0).Rows(li).Item("nr_valor_esalq").ToString
                            If dsAnalisesValores.Tables(0).Rows(li).Item("nr_valor_esalq").ToString <> "" Then  ' 23/11/2015 - adri - Solicitação do DAL
                                lbl_CBT.Text = FormatNumber(dsAnalisesValores.Tables(0).Rows(li).Item("nr_valor_esalq"), 0)
                            End If

                    End Select

                Next

            Else

                If lbl_dt_analise.Text = "LinhaBranco" Then
                    lbl_dt_analise.Text = "           "
                    lbl_MG.Text = ""
                    lbl_Prot.Text = ""
                    lbl_CCS.Text = ""
                    lbl_CBT.Text = ""

                Else

                    '========================================
                    ' Buscar o Teor de qualidade
                    ' 06/09/2016 - Unificação das UP's - i
                    e.Row.Cells(0).Text = ""
                    extratoqualidadeweb.id_unid_producao = ViewState.Item("id_unid_producao")
                    If ViewState.Item("PropriedadeConsolidada") = "S" Then  ' Se tem mais de uma UP, busca Médias do pagamento Consolidado
                        extratoqualidadeweb.st_tipo_pagamento = "C"
                        extratoqualidadeweb.id_unid_producao = 0 'fran 11/10/2016 se for consolidade, não deve buscar por UP
                    Else
                        extratoqualidadeweb.st_tipo_pagamento = "M"
                    End If
                    ' 06/09/2016 - Unificação das UP's - f

                    ' Se é a média do pagamento, busca média das anáises na Ficha Financeira
                    extratoqualidadeweb.dt_referencia_start = ViewState.Item("dt_referencia").ToString
                    extratoqualidadeweb.dt_referencia_end = ViewState.Item("dt_referencia_end").ToString
                    extratoqualidadeweb.cd_conta = "0152"  ' Média Analise de MG
                    'extratoqualidadeweb.st_tipo_pagamento = "M" 'fran 11/10/2016 desabilitado pois já setou tipo pagamento acima
                    extratoqualidadeweb.st_pagamento = "D"  ' 23/11/2015 - Para conseguir imprimir mesmo se cálculo provisório

                    ' Média de Análise de MG
                    Dim dsMediaAnalise As DataSet = extratoqualidadeweb.getExtratoQualidadeValorConta()
                    If dsMediaAnalise.Tables(0).Rows.Count > 0 Then
                        lbl_MG.Text = dsMediaAnalise.Tables(0).Rows(0).Item("nr_valor_conta").ToString
                    Else
                        lbl_MG.Text = "0,0000"
                    End If

                    ' Média de Análise de Prot (por enquanto não tem no cálculo)
                    ' 23/11/2015 - adri - Solicitado pelo DAL - i
                    'lbl_Prot.Text = "0,0000"
                    extratoqualidadeweb.cd_conta = "0082"  ' Média Analise de Proteína (nova - incluída em 10/2015 para poupança)
                    'extratoqualidadeweb.st_tipo_pagamento = "M" 'fran 11/10/2016 desabilitado pois já setou tipo pagamento acima
                    extratoqualidadeweb.st_pagamento = "D"

                    ' Média de Análise de Proteína
                    dsMediaAnalise = extratoqualidadeweb.getExtratoQualidadeValorConta()
                    If dsMediaAnalise.Tables(0).Rows.Count > 0 Then
                        lbl_Prot.Text = dsMediaAnalise.Tables(0).Rows(0).Item("nr_valor_conta").ToString
                    Else
                        lbl_Prot.Text = "0,0000"
                    End If
                    ' 23/11/2015 - adri - Solicitado pelo DAL - f

                    ' Média de Análise de CCS (por enquanto não tem no cálculo)
                    ' 23/11/2015 - adri - Solicitado pelo DAL - i
                    'lbl_CCS.Text = "0,0000"
                    extratoqualidadeweb.cd_conta = "0105"  ' Média Analise de CCS (nova - incluída em 10/2015 para poupança)
                    'extratoqualidadeweb.st_tipo_pagamento = "M" 'fran 11/10/2016 desabilitado pois já setou tipo pagamento acima
                    extratoqualidadeweb.st_pagamento = "D"

                    ' Média de Análise de CCS
                    dsMediaAnalise = extratoqualidadeweb.getExtratoQualidadeValorConta()
                    If dsMediaAnalise.Tables(0).Rows.Count > 0 Then
                        'lbl_CCS.Text = dsMediaAnalise.Tables(0).Rows(0).Item("nr_valor_conta").ToString
                        If dsMediaAnalise.Tables(0).Rows(0).Item("nr_valor_conta").ToString <> "" Then  ' 23/11/2015 - adri - Solicitação do DAL
                            lbl_CCS.Text = FormatNumber(dsMediaAnalise.Tables(0).Rows(0).Item("nr_valor_conta"), 0)
                        Else
                            lbl_CCS.Text = "0"
                        End If
                    Else
                        lbl_CCS.Text = "0"
                    End If
                    ' 23/11/2015 - adri - Solicitado pelo DAL - f

                    ' Média de Análise de CTM (por enquanto não tem no cálculo)
                    ' 23/11/2015 - adri - Solicitado pelo DAL - i
                    'lbl_CBT.Text = "0,0000"
                    extratoqualidadeweb.cd_conta = "0092"  ' Média Analise de CBT (nova - incluída em 10/2015 para poupança como CTM)
                    'extratoqualidadeweb.st_tipo_pagamento = "M" 'fran 11/10/2016 desabilitado pois já setou tipo pagamento acima
                    extratoqualidadeweb.st_pagamento = "D"

                    ' Média de Análise de CCS
                    dsMediaAnalise = extratoqualidadeweb.getExtratoQualidadeValorConta()
                    If dsMediaAnalise.Tables(0).Rows.Count > 0 Then
                        'lbl_CBT.Text = dsMediaAnalise.Tables(0).Rows(0).Item("nr_valor_conta").ToString
                        If dsMediaAnalise.Tables(0).Rows(0).Item("nr_valor_conta").ToString <> "" Then  ' 23/11/2015 - adri - Solicitação do DAL
                            lbl_CBT.Text = FormatNumber(dsMediaAnalise.Tables(0).Rows(0).Item("nr_valor_conta"), 0)
                        Else
                            lbl_CBT.Text = "0"
                        End If
                    Else
                        lbl_CBT.Text = "0"
                    End If
                    ' 23/11/2015 - adri - Solicitado pelo DAL - f

                End If

            End If





        End If

    End Sub

    Protected Sub GridFinanceiro_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridFinanceiro.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            ' 24/11/2015 - Solicitações da Ana (campo quantidade de leite in natura )- i
            Dim lbl_descricao As Label = CType(e.Row.FindControl("lbl_descricao"), Label)
            Dim lbl_qtde As Label = CType(e.Row.FindControl("lbl_qtde"), Label)

            If lbl_descricao.Text = "Leite in Natura" And IsNumeric(lbl_qtde.Text) Then
                lbl_qtde.Text = FormatNumber(lbl_qtde.Text, 0)
            End If
            ' 24/11/2015 - Solicitações da Ana (campo quantidade de leite in natura ) - i 
            If lbl_descricao.Text = "Antecipação Leite in Natura" And IsNumeric(lbl_qtde.Text) Then 'fran 08/2017
                lbl_qtde.Text = FormatNumber(lbl_qtde.Text, 0)
            End If

        End If


    End Sub

    Protected Sub gridMovimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridMovimento.RowDataBound

        If (e.Row.RowType = DataControlRowType.Header) Then

            ' 06/09/2016 - Unificação das UP's - i
            If ViewState.Item("PropriedadeConsolidada") = "N" Then  ' Se não tem mais de uma UP
                e.Row.Cells(0).Visible = False
            End If
            ' 06/09/2016 - Unificação das UP's - f

        End If

        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            ' 06/09/2016 - Unificação das UP's - i
            If ViewState.Item("PropriedadeConsolidada") = "N" Then  ' Se não tem mais de uma UP
                e.Row.Cells(0).Visible = False
            End If
            ' 06/09/2016 - Unificação das UP's - f


            ' 26/07/2016 - adri chamado 2451 - Leite não pago na referência - i
            Dim lbl_seq As Label = CType(e.Row.FindControl("lbl_seq"), Label)

            If lbl_seq.Text = "3" Then  ' Se tem volume que não foi pago na referência (linhas na mapa de leite com st_leite_pago_referencia null)
                lbl_volumenaopago.Visible = True
            End If
            ' 26/07/2016 - adri chamado 2451 - Leite não pago na referência - i 

        End If

    End Sub
End Class
