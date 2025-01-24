Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_preco_negociado_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try

            'BUSCA OS PARAMETROS
            ViewState.Item("id_estabelecimento") = String.Empty
            ViewState.Item("dt_referencia") = String.Empty
            ViewState.Item("id_tecnico") = String.Empty
            ViewState.Item("st_aprovado") = String.Empty
            ViewState.Item("id_cluster") = String.Empty

            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                If Not (Request("dt_referencia") Is Nothing) Then
                    ViewState.Item("dt_referencia") = Request("dt_referencia")
                End If
                If Not (Request("id_tecnico") Is Nothing) Then
                    ViewState.Item("id_tecnico") = Request("id_tecnico")
                End If
                If Not (Request("st_aprovado") Is Nothing) Then
                    ViewState.Item("st_aprovado") = Request("st_aprovado")
                End If
                If Not (Request("id_cluster") Is Nothing) Then
                    ViewState.Item("id_cluster") = Request("id_cluster")
                End If

                'ASSOCIA OS PARAMETROS AO OBJETO PEDIDO
                Dim preconegociado As New PrecoNegociado

                If Not (ViewState.Item("id_estabelecimento").Equals(String.Empty)) Then
                    preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                Else
                    preconegociado.id_estabelecimento = 0
                End If

                preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)

                If Not (ViewState.Item("id_tecnico").Equals(String.Empty)) Then
                    preconegociado.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)
                Else
                    preconegociado.id_tecnico = 0
                End If

                If Not (ViewState.Item("id_cluster").Equals(String.Empty)) Then
                    preconegociado.id_cluster = Convert.ToInt32(ViewState.Item("id_cluster").ToString)
                Else
                    preconegociado.id_cluster = 0
                End If
                If Trim(ViewState.Item("st_aprovado")) <> "0" Then
                    preconegociado.st_aprovado = ViewState.Item("st_aprovado").ToString
                Else
                    preconegociado.st_aprovado = String.Empty

                End If

                ViewState.Item("sortExpression") = "ds_produtor asc"

                ViewState.Item("mixobj") = 0
                ViewState.Item("mixneg") = 0

                Dim nr_somatorio_volume As Decimal

                Dim dsPrecoNegociadoMix As DataSet = preconegociado.getPrecoNegociadoMix()  ' Traz os somatórios para o cálculo dos Mix's
                nr_somatorio_volume = Convert.ToDecimal(dsPrecoNegociadoMix.Tables(0).Rows(0).Item("somatoriovolume"))
                If nr_somatorio_volume > 0 Then
                    ViewState.Item("mixobj") = Round(Convert.ToDecimal(dsPrecoNegociadoMix.Tables(0).Rows(0).Item("mixobj")) / nr_somatorio_volume, 2)
                    ViewState.Item("mixneg") = Round(Convert.ToInt32(dsPrecoNegociadoMix.Tables(0).Rows(0).Item("mixneg")) / nr_somatorio_volume, 2)
                End If

                'If Trim(ViewState.Item("st_aprovado")) <> "0" Then
                '    preconegociado.st_aprovado = ViewState.Item("st_aprovado").ToString
                'End If

                Dim dsPrecoNegociado As DataSet = preconegociado.getPrecoNegociadoByFilters()

                If (dsPrecoNegociado.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsPrecoNegociado.Tables(0), ViewState.Item("sortExpression"))
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
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_PrecoNegociado" & ".xls")
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

                If (e.Row.RowType <> DataControlRowType.Header _
                    And e.Row.RowType <> DataControlRowType.Footer _
                    And e.Row.RowType <> DataControlRowType.Pager) Then

                    Dim lsomatorio_volumeprecoobjetivo As Decimal
                    Dim lsomatorio_volumepreconegociado As Decimal
                    'Dim lbl_preco_negociado As Label = CType(e.Row.FindControl("lbl_preco_negociado"), Label)


                    ' Volume => Coluna 2
                    ' Subtotal => coluna 7
                    ' Preco Negociado => coluna 8 (template)

                    ' Coluna Volume * Subtotal (preço objetivo mais adicionais)
                    lsomatorio_volumeprecoobjetivo = Convert.ToDecimal(e.Row.Cells(3).Text) * Convert.ToDecimal(e.Row.Cells(6).Text)

                    ' Coluna Volume * Preço Negociado
                    If Not (e.Row.Cells(9).Text.ToString.Equals(String.Empty)) Then
                        lsomatorio_volumepreconegociado = Convert.ToDecimal(e.Row.Cells(3).Text) * Convert.ToDecimal(e.Row.Cells(7).Text)
                    Else
                        lsomatorio_volumepreconegociado = 0
                    End If

                End If

            End If

            If (e.Row.RowType = DataControlRowType.Footer) Then

                e.Row.Cells(5).Text = "Mix Obj "
                e.Row.Cells(6).Text = ViewState.Item("mixobj")  ' Calculado no loadData()
                e.Row.Cells(7).Text = "Mix Neg "
                e.Row.Cells(8).Text = ViewState.Item("mixneg")  ' Calculado no loadData()

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
End Class
