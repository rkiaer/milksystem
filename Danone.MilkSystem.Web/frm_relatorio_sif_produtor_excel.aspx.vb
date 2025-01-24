Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_relatorio_sif_produtor_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            Try


                If (Not Request("dt_referencia") Is Nothing) Then
                    ViewState.Item("dt_referencia") = Request("dt_referencia")
                Else
                    ViewState.Item("dt_referencia") = String.Empty
                End If

                If (Not Request("dt_referencia_ini") Is Nothing) Then
                    ViewState.Item("dt_referencia_ini") = Request("dt_referencia_ini")
                Else
                    ViewState.Item("dt_referencia_ini") = String.Empty
                End If

                If (Not Request("dt_referencia_fim") Is Nothing) Then
                    ViewState.Item("dt_referencia_fim") = Request("dt_referencia_fim")
                Else
                    ViewState.Item("dt_referencia_fim") = String.Empty
                End If

                If (Not Request("id_grupo") Is Nothing) Then
                    ViewState.Item("id_grupo") = Request("id_grupo")
                Else
                    ViewState.Item("id_grupo") = "0"
                End If

                If (Not Request("id_estado") Is Nothing) Then
                    ViewState.Item("id_estado") = Request("id_estado")
                Else
                    ViewState.Item("id_estado") = "0"
                End If

                If (Not Request("nm_cidade") Is Nothing) Then
                    ViewState.Item("nm_cidade") = Request("nm_cidade")
                Else
                    ViewState.Item("nm_cidade") = String.Empty
                End If

                If (Not Request("tiporelatorio") Is Nothing) Then
                    ViewState.Item("tiporelatorio") = Request("tiporelatorio")
                Else
                    ViewState.Item("tiporelatorio") = String.Empty
                End If

                Dim mapasif As New MapaLeite

                mapasif.dt_referencia = ViewState.Item("dt_referencia")
                mapasif.id_estado = ViewState.Item("id_estado")
                mapasif.nm_cidade = ViewState.Item("nm_cidade")
                mapasif.dt_inicio = ViewState.Item("dt_referencia_ini")
                mapasif.dt_fim = ViewState.Item("dt_referencia_fim")
                mapasif.id_grupo = ViewState.Item("id_grupo")

                Dim dsmapa As DataSet = mapasif.getRelatorioSIFbyDia

                If dsmapa.Tables.Count > 0 Then
                    If (dsmapa.Tables(0).Rows.Count > 0) Then
                        Dim dr As DataRow = dsmapa.Tables(0).NewRow()
                        Dim i As Int16 = 0

                        dsmapa.Tables(0).Rows.InsertAt(dr, 0)

                        gridResults.DataSource = Helper.getDataView(dsmapa.Tables(0), ViewState.Item("sortExpression"))
                        gridResults.AllowPaging = False
                        gridResults.DataBind()

                    End If

                End If

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "ReportSIF_Analitico_Produtor" & ".xls")
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



    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated
        Dim i As Int16 = 2
        Dim laux As String

        If (e.Row.RowType = DataControlRowType.Header) Then


            e.Row.Cells(0).RowSpan = 2
            e.Row.Cells(1).RowSpan = 2
            e.Row.Cells(0).Text = "UF"
            e.Row.Cells(1).Text = "Cidade"

            'varre a partir da 3 coluna
            For i = 2 To e.Row.Cells.Count - 1
                If i Mod 2 = 0 Then 'coluna par (produtor)
                    laux = e.Row.Cells(i + 1).Text.ToString.Trim 'pega o valor da coluna impar (que é o dia do mes)
                    e.Row.Cells(i).ColumnSpan = 2
                    e.Row.Cells(i).Text = Right(String.Concat("0", laux.ToString, Right(ViewState.Item("dt_referencia").ToString, 8)), 10).ToString
                End If
            Next i

            'varre a partir da 3 coluna
            For i = 2 To e.Row.Cells.Count - 1
                If i <= e.Row.Cells.Count - 1 Then
                    If Len(e.Row.Cells(i).Text.Trim) <= 2 Then 'coluna par (produtor)
                        e.Row.Cells.RemoveAt(i)
                    End If
                Else
                    Exit For
                End If
            Next i


        End If

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        Dim i As Int16 = 2
        Dim laux As String

        If (e.Row.RowType = DataControlRowType.Header) Then

        End If
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            If e.Row.RowIndex = 0 Then
                For i = 2 To e.Row.Cells.Count - 1

                    e.Row.Cells(i).BackColor = System.Drawing.Color.FromName("#006699")
                    e.Row.Cells(i).ForeColor = Drawing.Color.White
                    e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Center

                    If i Mod 2 = 0 Then 'coluna par
                        e.Row.Cells(i).Text = "Prod."
                    Else
                        e.Row.Cells(i).Text = "Vol."
                    End If
                Next i

                e.Row.Cells.RemoveAt(0) ' remove uf
                e.Row.Cells.RemoveAt(0) 'remove cidade

            Else
                'se linha 1
                e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Left
                e.Row.Cells(1).Wrap = False


                'varre a partir da 3 coluna
                For i = 2 To e.Row.Cells.Count - 1
                    If i Mod 2 > 0 Then 'coluna impar (volume leite)
                        e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Right

                        If (Not e.Row.Cells(i).Text.Equals(String.Empty) And Not e.Row.Cells(i).Text = "&nbsp;") Then
                            e.Row.Cells(i).Text = FormatNumber(e.Row.Cells(i).Text, 0).ToString()
                        End If
                    Else
                        e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Center

                    End If
                Next i
            End If
        End If

    End Sub
End Class
