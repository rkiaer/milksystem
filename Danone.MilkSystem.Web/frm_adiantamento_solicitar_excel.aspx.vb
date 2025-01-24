Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_adiantamento_solicitar_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try

            'BUSCA OS PARAMETROS
            ViewState.Item("dt_referencia") = String.Empty
            ViewState.Item("st_aprovado") = String.Empty

            If Not (Request("dt_referencia") Is Nothing) Then
                If Not (Request("dt_referencia") Is Nothing) Then
                    ViewState.Item("dt_referencia") = Request("dt_referencia")
                End If
                If Not (Request("id_tecnico") Is Nothing) Then
                    ViewState.Item("id_tecnico") = Request("id_tecnico")
                End If
                If Not (Request("st_aprovado") Is Nothing) Then
                    ViewState.Item("st_aprovado") = Request("st_aprovado")
                End If
               

                'ASSOCIA OS PARAMETROS AO OBJETO PEDIDO
                Dim adiantamento As New Adiantamento

                If Trim(ViewState.Item("id_tecnico")) <> "" Then
                    adiantamento.id_tecnico = ViewState("id_tecnico").ToString
                End If
                If Trim(ViewState.Item("st_aprovado")) <> "0" Then
                    adiantamento.st_aprovado = ViewState.Item("st_aprovado").ToString
                End If
                adiantamento.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)

                ViewState.Item("sortExpression") = "ds_produtor asc"

                Dim dsAdiantamento As DataSet = adiantamento.getAdiantamentoByFilters()

                If (dsAdiantamento.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsAdiantamento.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                    'messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If


                gridResults.AllowPaging = False

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_SolicitarAdiantamento" & ".xls")
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

                    messageControl.Alert(" Planilha possui muitas linhas (mais de 65000), não é possível exportar para o Excel")

                End If
            Else
                messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            Else  ' Se não está editando
                Dim lvalor_adto As Decimal
                Dim listaprovado As Integer = 0

                Dim lbl_st_aprovado As Label = CType(e.Row.FindControl("lbl_st_aprovado"), Label)


                Select Case lbl_st_aprovado.Text
                    Case "1" 'Pre-aprovado ou aprovado 1o nivel deixa excluir
                        listaprovado = 1
                    Case "4" 'aprovado 1o nivel deixa excluir
                        listaprovado = 4

                    Case "2" 'Aprovado 2o nivel
                        listaprovado = 2

                    Case "3" 'Reprovado
                        listaprovado = 3

                End Select

                If e.Row.Cells(5).Text.Equals(String.Empty) Then
                    lvalor_adto = 0
                Else
                    lvalor_adto = e.Row.Cells(5).Text
                End If

                If (e.Row.Cells(14).Text.Trim().Equals("1")) Then
                    e.Row.Cells(14).Text = "Pré-aprovado"
                Else
                    If (e.Row.Cells(14).Text.Trim().Equals("2")) Then
                        e.Row.Cells(14).Text = "Aprovado"
                    Else
                        If (e.Row.Cells(14).Text.Trim().Equals("3")) Then
                            e.Row.Cells(14).Text = "Reprovado"
                        Else
                            'If (e.Row.Cells(9).Text.Trim().Equals("4")) Then
                            '    e.Row.Cells(9).Text = "Ultrapassou"
                            'End If
                        End If
                    End If
                End If

                ' Calcular % Comprometido (Total Desc + Adtos) / Valor Mensal Estimado
                If IsNumeric(e.Row.Cells(3).Text.Trim()) Then  ' Se tem Valor Mensal Estimado
                    If Convert.ToDecimal(e.Row.Cells(3).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                        If listaprovado = 2 Then 'se for aprovado 2 nivel, a rotina de saldo disponivel já traz o adiantamento como descontos + adiantamewntos
                            e.Row.Cells(7).Text = FormatPercent(Round(((Convert.ToDecimal(e.Row.Cells(6).Text.Trim())) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim())), 2), 2)
                        Else
                            e.Row.Cells(7).Text = FormatPercent(Round((Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) + Convert.ToDecimal(lvalor_adto)) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim()), 2), 2)
                        End If
                    End If
                End If

                Dim laux As Decimal
                If e.Row.Cells(6).Text.Trim.Equals(String.Empty) Then 'Pega o total dos desc + adto
                    laux = 0
                Else
                    laux = e.Row.Cells(6).Text.Trim
                End If
                If Not e.Row.Cells(8).Text.Trim.Equals(String.Empty) Then 'Pega o total pedidos abertos
                    laux = laux + e.Row.Cells(8).Text.Trim
                End If
                e.Row.Cells(9).Text = Convert.ToDecimal(laux)   'Total Desc + aadto + pedidos abertos


                ' Calcular % Comprometido  (Total Desc + Adtos + Ped em Aberto) / Valor Mensal Estimado
                If IsNumeric(e.Row.Cells(3).Text.Trim()) Then  ' Se tem Valor Mensal Estimado
                    If Convert.ToDecimal(e.Row.Cells(3).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                        If listaprovado = 2 Then 'se for aprovado 2 nivel, a rotina de saldo disponivel já traz o adiantamento como descontos + adiantamewntos
                            e.Row.Cells(10).Text = FormatPercent(Round(((Convert.ToDecimal(e.Row.Cells(9).Text.Trim())) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim())), 2), 2)
                        Else
                            e.Row.Cells(10).Text = FormatPercent(Round(((Convert.ToDecimal(e.Row.Cells(9).Text.Trim()) + Convert.ToDecimal(lvalor_adto)) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim())), 2), 2)
                        End If
                    End If
                End If

                'Total descontos + adto deve ser somado ao novo adto
                If IsNumeric(lvalor_adto) And listaprovado <> 2 Then  ' Se tem valor adto e nao é aprovado 2o nivel
                    e.Row.Cells(6).Text = (Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) + Convert.ToDecimal(lvalor_adto))

                    'Total descontos + adto + ped abertos deve ser somado ao novo adto
                    e.Row.Cells(9).Text = (Convert.ToDecimal(e.Row.Cells(9).Text.Trim()) + Convert.ToDecimal(lvalor_adto))
                End If

                If IsNumeric(e.Row.Cells(13).Text.Trim()) Then  ' Se tem Saldo x Polit Adto
                    If Convert.ToDecimal(e.Row.Cells(13).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                        ' e.Row.Cells(13).Text = (Convert.ToDecimal(e.Row.Cells(13).Text.Trim()) - Convert.ToDecimal(lvalor_adto)) 'este campo deve considerar o adto que esta tentando fazer
                        e.Row.Cells(13).Text = (Convert.ToDecimal(e.Row.Cells(13).Text.Trim()) - Convert.ToDecimal(e.Row.Cells(9).Text.Trim()))
                    End If
                End If


                'Formatações
                If IsNumeric(e.Row.Cells(2).Text.Trim()) Then  ' volume
                    If Convert.ToInt64(e.Row.Cells(2).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                        e.Row.Cells(2).Text = FormatNumber(Convert.ToInt64(e.Row.Cells(2).Text.Trim()))
                    End If
                End If
                If IsNumeric(e.Row.Cells(3).Text.Trim()) Then  ' valor mensal
                    If Convert.ToDecimal(e.Row.Cells(3).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                        e.Row.Cells(3).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(3).Text.Trim()), 2, , , TriState.True)
                    End If
                End If
                If IsNumeric(e.Row.Cells(4).Text.Trim()) Then  ' descontos
                    If Convert.ToDecimal(e.Row.Cells(4).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                        e.Row.Cells(4).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(4).Text.Trim()), 2, , , TriState.True)
                    End If
                End If
                If IsNumeric(lvalor_adto) Then  ' valor adto
                    If Convert.ToDecimal(lvalor_adto) > 0 Then  ' Se o valor é maior que zero
                        e.Row.Cells(5).Text = FormatNumber(Convert.ToDecimal(lvalor_adto), 2, , , TriState.True)
                    End If
                End If
                If IsNumeric(e.Row.Cells(6).Text.Trim()) Then  ' total desc + adto
                    If Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                        e.Row.Cells(6).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(6).Text.Trim()), 2, , , TriState.True)
                    End If
                End If

                If IsNumeric(e.Row.Cells(8).Text.Trim()) Then  ' valor pedidos abertos
                    If Convert.ToDecimal(e.Row.Cells(8).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                        e.Row.Cells(8).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(8).Text.Trim()), 2, , , TriState.True)
                    End If
                End If
                If IsNumeric(e.Row.Cells(9).Text.Trim()) Then  ' valor total desc + ped+ adian/o
                    If Convert.ToDecimal(e.Row.Cells(9).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                        e.Row.Cells(9).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(9).Text.Trim()), 2, , , TriState.True)
                    End If
                End If

                If IsNumeric(e.Row.Cells(13).Text.Trim()) Then  ' valor Saldo Politica
                    If Convert.ToDecimal(e.Row.Cells(13).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                        e.Row.Cells(13).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(13).Text.Trim()), 2, , , TriState.True)
                    End If
                End If
                'fran fase 3 f
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
 
 End Class
