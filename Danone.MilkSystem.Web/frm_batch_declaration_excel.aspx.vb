Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_batch_declaration_excel
    Inherits System.Web.UI.Page

    ' adri - 07/08/2012 - chamado 1577

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.ContentType = "application/vnd.ms-excel"


        If Not (Request("id_romaneio") Is Nothing) Then
            ViewState.Item("id_romaneio") = Request("id_romaneio")
        End If
        If Not (Request("id_execucao") Is Nothing) Then
            ViewState.Item("id_execucao") = Request("id_execucao")
        End If
        If Not (Request("st_exportacao_batch_itens") Is Nothing) Then
            ViewState.Item("st_exportacao_batch_itens") = Request("st_exportacao_batch_itens")
        End If
        If Not (Request("dt_ini") Is Nothing) Then
            ViewState.Item("dt_ini") = Request("dt_ini")
        End If
        If Not (Request("dt_fim") Is Nothing) Then
            ViewState.Item("dt_fim") = Request("dt_fim")
        End If
        If Not (Request("aba_ativa") Is Nothing) Then
            ViewState.Item("aba_ativa") = Request("aba_ativa")
        End If

        ViewState.Item("sortExpression") = "id_exportacao_batch_execucao desc, id_exportacao_batch_itens asc"
        ViewState.Item("sortExpression_romaneios") = "id_romaneio asc"

        Try
            Dim tw As New System.IO.StringWriter
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)

            If (ViewState.Item("aba_ativa") = 0) Then

                '=========================
                ' Se exportar Resultados
                '=========================


                Dim export As New ExportacaoBatch
                Dim dsbatch As DataSet

                If Not (ViewState.Item("id_romaneio").ToString.Equals(String.Empty)) Then
                    export.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString())
                End If
                export.st_exportacao_batch_itens = ViewState.Item("st_exportacao_batch_itens").ToString()
                If Not ViewState.Item("id_execucao").ToString.Equals(String.Empty) Then
                    export.id_exportacao_batch_execucao = ViewState.Item("id_execucao").ToString()
                End If
                export.dt_ini_filtro = ViewState.Item("dt_ini").ToString
                export.dt_fim_filtro = ViewState.Item("dt_fim").ToString
                dsbatch = export.getExportacaoBatchExecucaoByFilters()

                'gridRomaneios.Visible = False

                'If (dsbatch.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsbatch.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                Response.AddHeader("content-disposition", "attachment;filename=" & "ExportacaoBatch_Resultados" & ".xls")
                Response.Charset = ""
                EnableViewState = False

                gridResults.RenderControl(hw)
                HttpContext.Current.Response.Write(tw.ToString())
                HttpContext.Current.Response.End()
                gridResults.DataBind()

                'Else
                'gridResults.Visible = False
                'End If

            Else

                '=========================
                ' Se exportar Romaneios
                '=========================

                Dim romaneio As New Romaneio
                Dim dsbatch As DataSet

                If Not (ViewState.Item("id_romaneio").ToString.Equals(String.Empty)) Then
                    romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString())
                End If

                'romaneio.id_st_romaneio = 4   ' Somente Romaneios Fechados
                romaneio.data_inicio = ViewState.Item("dt_ini").ToString
                romaneio.data_fim = ViewState.Item("dt_fim").ToString
                dsbatch = romaneio.getExportacaoBatchRomaneio()

                'gridResults.Visible = False

                'If (dsbatch.Tables(0).Rows.Count > 0) Then
                gridRomaneios.Visible = True
                gridRomaneios.DataSource = Helper.getDataView(dsbatch.Tables(0), ViewState.Item("sortExpression_romaneios"))
                gridRomaneios.AllowPaging = False
                gridRomaneios.DataBind()


                Response.AddHeader("content-disposition", "attachment;filename=" & "ExportacaoBatch_Romaneios" & ".xls")
                Response.Charset = ""
                EnableViewState = False

                gridRomaneios.RenderControl(hw)
                HttpContext.Current.Response.Write(tw.ToString())
                HttpContext.Current.Response.End()
                gridRomaneios.DataBind()

                'Else
                'gridRomaneios.Visible = False
                'End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            ' Dim lbl_situacao As System.Web.UI.WebControls.Label = CType(e.Row.FindControl("lbl_situacao"), System.Web.UI.WebControls.Label)
            'Dim lk_erros As System.Web.UI.WebControls.Label = CType(e.Row.FindControl("lbl_erro"), System.Web.UI.WebControls.Label)

            If e.Row.Cells(14).Text = "F" Then
                e.Row.Cells(14).Text = "Finalizada"
            End If
            If e.Row.Cells(14).Text = "I" Then
                e.Row.Cells(14).Text = "Inicializada"
            End If
            If e.Row.Cells(14).Text = "E" Then
                e.Row.Cells(14).Text = "Erro"
            End If
            e.Row.Cells(3).Text = DateTime.Parse(e.Row.Cells(3).Text).ToString("dd/MM/yyyy")
            e.Row.Cells(4).Text = DateTime.Parse(e.Row.Cells(4).Text).ToString("dd/MM/yyyy")

            e.Row.Cells(5).Text = CInt(e.Row.Cells(5).Text).ToString
            If Not e.Row.Cells(6).Text.Equals("0") Then
                e.Row.Cells(6).Text = CInt(e.Row.Cells(6).Text).ToString

            End If

            e.Row.Cells(13).Text = Mid(e.Row.Cells(13).Text, InStr(e.Row.Cells(13).Text, "\") + 1)

            'If (e.Row.RowType = DataControlRowType.DataRow) Then
            '    Try
            '        If CLng(gridResults.DataKeys.Item(e.Row.RowIndex).Value) = CLng(ViewState.Item("id_exportacao_batch_itens")) Then
            '            e.Row.ForeColor = Drawing.Color.Red
            '        Else
            '            e.Row.ForeColor = System.Drawing.Color.FromName("#333333")
            '        End If
            '    Catch ex As Exception
            '    End Try
            'End If
        End If
    End Sub

    Protected Sub gridRomaneios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridRomaneios.RowDataBound
        'Fran 9/08/2012
        If (e.Row.RowType <> DataControlRowType.Header _
     And e.Row.RowType <> DataControlRowType.Footer _
     And e.Row.RowType <> DataControlRowType.Pager) Then
                Dim lvalor_volume As Decimal
            Dim lvariacao_volume_real As Decimal

            'coluna de volume em litros (litros reais)
            e.Row.Cells(5).Text = 0

            lvalor_volume = 0

            ' Busca Densidade e MG
            Dim lvalor_densidade As Decimal

            Dim romaneio As New Romaneio
            romaneio.id_romaneio = CLng(gridRomaneios.DataKeys.Item(e.Row.RowIndex).Value)
            lvalor_densidade = romaneio.getRomaneioCompartimentoMediaDens()

            'densidade
            e.Row.Cells(4).Text = FormatNumber(lvalor_densidade, 4)

            'Peso Liquido Balanca
            Dim lpeso As Decimal
            If Trim(e.Row.Cells(3).Text) <> "" Then
                lpeso = Decimal.Truncate(Convert.ToDecimal(e.Row.Cells(3).Text))
                e.Row.Cells(3).Text = lpeso.ToString
            Else
                lpeso = 0
            End If
            If lvalor_densidade <> 0 Then
                lvalor_volume = Decimal.Truncate(CDec(lpeso / lvalor_densidade))
            Else
                lvalor_volume = 0
            End If

            e.Row.Cells(5).Text = lvalor_volume.ToString

            'variacao do volume
            'Peso liquido balança em litros - volume caderneta/nf em litros
            lvariacao_volume_real = Decimal.Truncate(lvalor_volume - CDec(e.Row.Cells(6).Text))
            If CLng(lvalor_volume) = 0 Then
                e.Row.Cells(7).Text = String.Empty
            Else
                e.Row.Cells(7).Text = lvariacao_volume_real.ToString
            End If

            If Not e.Row.Cells(6).Text.Equals(String.Empty) Then
                e.Row.Cells(6).Text = Decimal.Truncate(e.Row.Cells(6).Text)
            End If

        End If
    End Sub
End Class
