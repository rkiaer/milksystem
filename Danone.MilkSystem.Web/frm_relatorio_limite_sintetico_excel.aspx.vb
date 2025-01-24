Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_relatorio_limite_sintetico_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try

            'BUSCA OS PARAMETROS
            ViewState.Item("dt_referencia") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
            ViewState.Item("id_tecnico") = String.Empty
            ViewState.Item("id_propriedade") = String.Empty
            ViewState.Item("cd_pessoa") = String.Empty
            ViewState.Item("id_pessoa") = String.Empty
            ViewState.Item("id_estabelecimento") = String.Empty

            If Not (Request("dt_referencia") Is Nothing) Then
                If Not (Request("dt_referencia") Is Nothing) Then
                    ViewState.Item("dt_referencia") = Request("dt_referencia")
                End If
                If Not (Request("dt_fim") Is Nothing) Then
                    ViewState.Item("dt_fim") = Request("dt_fim")
                End If
                If Not (Request("id_tecnico") Is Nothing) Then
                    ViewState.Item("id_tecnico") = Request("id_tecnico")
                End If
                If Not (Request("id_propriedade") Is Nothing) Then
                    ViewState.Item("id_propriedade") = Request("id_propriedade")
                End If
                If Not (Request("id_pessoa") Is Nothing) Then
                    ViewState.Item("id_pessoa") = Request("id_pessoa")
                End If
                If Not (Request("cd_pessoa") Is Nothing) Then
                    ViewState.Item("cd_pessoa") = Request("cd_pessoa")
                End If
                If Not (Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                End If


                'ASSOCIA OS PARAMETROS AO OBJETO PEDIDO
                Dim relsaldodisponivel As New SaldoDisponivel

                If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                    relsaldodisponivel.id_tecnico = Convert.ToString(ViewState.Item("id_tecnico"))
                End If
                If Not (ViewState("id_pessoa").ToString().Equals(String.Empty)) Then
                    relsaldodisponivel.id_pessoa = Convert.ToString(ViewState.Item("id_pessoa"))
                End If

                If Not (ViewState("dt_referencia").ToString().Equals(String.Empty)) Then
                    relsaldodisponivel.dt_referencia = Convert.ToString(ViewState.Item("dt_referencia"))
                    relsaldodisponivel.dt_referencia_end = Convert.ToString(ViewState.Item("dt_fim"))
                End If
                If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                    relsaldodisponivel.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
                End If
                If Not (ViewState("id_propriedade").ToString().Equals(String.Empty)) Then
                    relsaldodisponivel.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                End If

                Dim dsRelSaldoDisponivel As DataSet = relsaldodisponivel.getRelatorioSaldoDisponivelSintetico
                If (dsRelSaldoDisponivel.Tables(0).Rows.Count > 0) Then
                    Dim row As DataRow
                    Dim rowprop As DataRow
                    Dim dspropriedades As DataSet
                    Dim saldoanalitico As New SaldoDisponivel
                    Dim lvolumedia As Decimal = 0
                    Dim lvolumemensal As Decimal = 0

                    'quando fizer rel sintetico, os produtores que tenhamm mais de uma propriedade, devemm ser demonstrado o somatorio.
                    'ocorre que cada propriedade tem um saldo disponivel diferente inclusive por ter parametros diferentes como por exemplo ultimo dia de coleta que influenciara o volume total mensal
                    'por isso nao basta agrupar por propriedade, o valor sintetico é a soma do agrupamento por proriedade, isto para o volume mensal e volume diario

                    ''Encontra no dataset produtores que tenham mais de uma propriedade
                    'For Each row In dsRelSaldoDisponivel.Tables(0).Select("nr_propriedades > 1")
                    '    'abre nova instancia de saldodisponivel para buscar saldo apenas propriedades do produtor
                    '    saldoanalitico.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
                    '    saldoanalitico.dt_referencia = Convert.ToString(ViewState.Item("dt_referencia"))
                    '    saldoanalitico.dt_referencia_end = Convert.ToString(ViewState.Item("dt_fim"))
                    '    saldoanalitico.id_pessoa = row.Item("id_pessoa")

                    '    dspropriedades = saldoanalitico.getRelatorioSaldoDisponivelAnalitico
                    '    For Each rowprop In dspropriedades.Tables(0).Rows
                    '        'pega os somatorios de volumes para cada propriedade
                    '        lvolumedia = lvolumedia + CDec(rowprop.Item("nr_volume_dia").ToString)
                    '        lvolumemensal = lvolumemensal + CDec(rowprop.Item("nr_volume_mensal").ToString)
                    '    Next

                    '    'atualiza dataset que vai montar grid com somatoria correta
                    '    row.Item("nr_volume_dia") = lvolumedia
                    '    row.Item("nr_volume_mensal") = lvolumemensal
                    '    lvolumedia = 0
                    '    lvolumemensal = 0
                    'Next

                End If

                If (dsRelSaldoDisponivel.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsRelSaldoDisponivel.Tables(0), "")
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
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_RelatorioLimiteSintetico" & ".xls")
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
                'If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
                'End If

                'If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
                'End If

                'Dim lbl_nr_preco_negociado As Decimal = CType(e.Row.FindControl("nr_preco_negociado"), Label).Text
                'Dim lbl_nr_perc_limite1q_cc As Decimal = CType(e.Row.FindControl("nr_perc_limite1q_cc"), Label).Text
                'Dim lbl_nr_perc_limite2q_cc As Decimal = CType(e.Row.FindControl("nr_perc_limite2q_cc"), Label).Text
                'Dim lbl_nr_descontos As Decimal = CType(e.Row.FindControl("nr_descontos"), Label).Text
                'Dim lbl_nr_contas_parceladas As Decimal = CType(e.Row.FindControl("nr_contas_parceladas"), Label).Text
                'Dim lnr_volume_mensal As Decimal = CType(e.Row.FindControl("lbl_nr_volume_mensal"), Label).Text
                'Dim lbl_volume_mensal As Label = CType(e.Row.FindControl("lbl_nr_volume_mensal"), Label)

                ''Atualiza Coluna Valor Mensal estimado
                'e.Row.Cells(4).Text = Round(lnr_volume_mensal * lbl_nr_preco_negociado, 2)

                'If lbl_nr_preco_negociado > 0 Then
                '    'Atualiza limite calculado
                '    If Day(Now) <= 15 Then   ' Se 1.a quinzena
                '        e.Row.Cells(5).Text = Round((Round(lnr_volume_mensal * lbl_nr_preco_negociado, 2)) * (lbl_nr_perc_limite1q_cc / 100), 2)
                '    Else
                '        e.Row.Cells(5).Text = Round((Round(lnr_volume_mensal * lbl_nr_preco_negociado, 2)) * (lbl_nr_perc_limite2q_cc / 100), 2)
                '    End If
                'Else
                '    e.Row.Cells(5).Text = "Sem Preço"
                'End If
                ''Atualiza Descontos
                'e.Row.Cells(6).Text = lbl_nr_descontos + lbl_nr_contas_parceladas

                ''Atualiza Total descontos + adto + ped abertos + pedidos finalizados contas parceladas proximo s meses
                'e.Row.Cells(10).Text = (Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) + Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) + Convert.ToDecimal(e.Row.Cells(8).Text.Trim()) + Convert.ToDecimal(e.Row.Cells(9).Text.Trim()))

                'If lbl_nr_preco_negociado > 0 Then

                '    'Atualiza % sobre limite calculado
                '    'e.Row.Cells(11).Text = FormatPercent(Round(((Convert.ToDecimal(e.Row.Cells(10).Text.Trim())) / Convert.ToDecimal(e.Row.Cells(5).Text.Trim())), 2), 2)

                '    'Atualiza % sobre mensal estimado
                '    e.Row.Cells(12).Text = FormatPercent(Round(((Convert.ToDecimal(e.Row.Cells(10).Text.Trim())) / Convert.ToDecimal(e.Row.Cells(4).Text.Trim())), 2), 2)

                '    'Atualiza Saldo Disponível
                '    e.Row.Cells(13).Text = (Convert.ToDecimal(e.Row.Cells(5).Text.Trim()) - Convert.ToDecimal(e.Row.Cells(10).Text.Trim()))
                'Else
                '    'e.Row.Cells(11).Text = "0,00%"
                '    e.Row.Cells(12).Text = "0,00%"

                '    'Atualiza Saldo Disponível
                '    e.Row.Cells(13).Text = (-Convert.ToDecimal(e.Row.Cells(9).Text.Trim()))
                'End If

                ''Atualiza Saldo Disponível
                'e.Row.Cells(13).Text = (Convert.ToDecimal(e.Row.Cells(5).Text.Trim()) - Convert.ToDecimal(e.Row.Cells(10).Text.Trim()))

                ''Formatações
                'If IsNumeric(lbl_volume_mensal.Text.Trim()) Then  ' volume
                '    If CLng(lbl_volume_mensal.Text) > 0 Then  ' Se o valor é maior que zero
                '        lbl_volume_mensal.Text = FormatNumber(CLng(lbl_volume_mensal.Text), 0)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(4).Text.Trim()) Then  ' valor mensal
                '    If Convert.ToDecimal(e.Row.Cells(4).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(4).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(4).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(5).Text.Trim()) Then  ' limite calculado
                '    If Convert.ToDecimal(e.Row.Cells(5).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(5).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(5).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(6).Text.Trim()) Then 'descontos
                '    If Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(6).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(6).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(7).Text.Trim()) Then  ' adiantamento
                '    If Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(7).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(7).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(8).Text.Trim()) Then  ' central parcelamento
                '    If Convert.ToDecimal(e.Row.Cells(8).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(8).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(8).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(9).Text.Trim()) Then  ' Pedido abertos
                '    If Convert.ToDecimal(e.Row.Cells(9).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(9).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(9).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(10).Text.Trim()) Then  ' valor total desc + ped+ adian/o
                '    If Convert.ToDecimal(e.Row.Cells(10).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(10).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(10).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If

                'If IsNumeric(e.Row.Cells(13).Text.Trim()) Then  ' valor Saldo Disponivel
                '    If Convert.ToDecimal(e.Row.Cells(13).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(13).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(13).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

End Class
