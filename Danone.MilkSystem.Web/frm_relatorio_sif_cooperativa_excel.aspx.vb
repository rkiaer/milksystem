Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_relatorio_sif_cooperativa_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResultsCoop.Rows.Count.ToString + 1 < 65536 Then

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

                Dim dsmapa As DataSet = mapasif.getRelatorioSIFbyDiaCooperativa

                If dsmapa.Tables.Count > 0 Then
                    If (dsmapa.Tables(0).Rows.Count > 0) Then
                        Dim dr As DataRow = dsmapa.Tables(0).NewRow()
                        Dim i As Int16 = 0

                        dsmapa.Tables(0).Rows.InsertAt(dr, 0)

                        gridResultsCoop.Visible = True
                        gridResultsCoop.DataSource = Helper.getDataView(dsmapa.Tables(0), ViewState.Item("sortExpression"))
                        gridResultsCoop.AllowPaging = False
                        gridResultsCoop.DataBind()

                    End If

                End If

                If gridResultsCoop.Rows.Count.ToString + 1 < 65536 Then
                    If gridResultsCoop.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "ReportSIF_Analitico_Cooperativa" & ".xls")
                        Response.Charset = ""
                        EnableViewState = False
                        Controls.Add(frm)
                        frm.Controls.Add(gridResultsCoop)
                        frm.RenderControl(hw)
                        Response.Write(tw.ToString())
                        Response.End()
                        gridResultsCoop.AllowPaging = "True"
                        gridResultsCoop.DataBind()
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

    Protected Sub gridResultsCoop_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsCoop.RowCreated
        Dim i As Int16 = 2
        Dim laux As String

        If (e.Row.RowType = DataControlRowType.Header) Then


            e.Row.Cells(0).RowSpan = 2
            e.Row.Cells(1).RowSpan = 2
            e.Row.Cells(2).RowSpan = 2
            e.Row.Cells(3).RowSpan = 2
            e.Row.Cells(4).RowSpan = 2
            e.Row.Cells(0).Text = "UF"
            e.Row.Cells(1).Text = "Cidade"
            e.Row.Cells(2).Text = "Código"
            e.Row.Cells(3).Text = "Cooperativa"
            e.Row.Cells(4).Text = "Cód.SIF"

            'varre a partir da 5 coluna
            For i = 5 To e.Row.Cells.Count - 1
                laux = e.Row.Cells(i).Text.ToString.Trim 'pega o valor da coluna (que é o dia do mes)
                e.Row.Cells(i).Text = Right(String.Concat("0", laux.ToString, Right(DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("dd/MM/yy"), 6)), 8).ToString
            Next i


        End If
    End Sub

    Protected Sub gridResultsCoop_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsCoop.RowDataBound

        Dim i As Int16 = 2
        Dim laux As String

        If (e.Row.RowType = DataControlRowType.Header) Then

        End If
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            If e.Row.RowIndex = 0 Then
                For i = 5 To e.Row.Cells.Count - 1

                    e.Row.Cells(i).BackColor = System.Drawing.Color.FromName("#006699")
                    e.Row.Cells(i).ForeColor = Drawing.Color.White
                    e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Center
                    e.Row.Cells(i).Text = "Volume"
                Next i

                e.Row.Cells.RemoveAt(0) ' remove uf
                e.Row.Cells.RemoveAt(0) 'remove cidade
                e.Row.Cells.RemoveAt(0) ' remove cdo cooperativa
                e.Row.Cells.RemoveAt(0) 'remove nome cooperativa
                e.Row.Cells.RemoveAt(0) ' remove cd sif

            Else
                'se linha 1
                e.Row.Cells(0).HorizontalAlign = HorizontalAlign.Center
                e.Row.Cells(1).HorizontalAlign = HorizontalAlign.Left
                e.Row.Cells(1).Wrap = False
                e.Row.Cells(2).HorizontalAlign = HorizontalAlign.Center
                e.Row.Cells(3).HorizontalAlign = HorizontalAlign.Left
                e.Row.Cells(3).Wrap = False
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Center


                'varre a partir da 5 coluna
                For i = 5 To e.Row.Cells.Count - 1
                    e.Row.Cells(i).HorizontalAlign = HorizontalAlign.Right

                    If (Not e.Row.Cells(i).Text.Equals(String.Empty) And Not e.Row.Cells(i).Text = "&nbsp;") Then
                        e.Row.Cells(i).Text = FormatNumber(e.Row.Cells(i).Text, 0).ToString()
                    End If
                Next i
            End If
        End If


    End Sub


End Class
