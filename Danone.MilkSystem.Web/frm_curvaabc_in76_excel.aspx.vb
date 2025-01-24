Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_curvaabc_in76_excel
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

                If (Not Request("txt_dt_coleta_ini") Is Nothing) Then
                    ViewState.Item("txt_dt_coleta_ini") = Request("txt_dt_coleta_ini")
                Else
                    ViewState.Item("txt_dt_coleta_ini") = String.Empty
                End If

                If (Not Request("id_grupo") Is Nothing) Then
                    ViewState.Item("id_grupo") = Request("id_grupo")
                Else
                    ViewState.Item("id_grupo") = String.Empty
                End If

                If (Not Request("tipopropriedade") Is Nothing) Then
                    ViewState.Item("tipopropriedade") = Request("tipopropriedade")
                Else
                    ViewState.Item("tipopropriedade") = String.Empty
                End If
                If (Not Request("categoriatecnico") Is Nothing) Then
                    ViewState.Item("categoriatecnico") = Request("categoriatecnico")
                Else
                    ViewState.Item("categoriatecnico") = String.Empty
                End If
                If (Not Request("situacaorelatorio") Is Nothing) Then
                    ViewState.Item("situacaorelatorio") = Request("situacaorelatorio")
                Else
                    ViewState.Item("situacaorelatorio") = String.Empty
                End If
                If (Not Request("id_tecnico") Is Nothing) Then
                    ViewState.Item("id_tecnico") = Request("id_tecnico")
                Else
                    ViewState.Item("situacaorelatorio") = String.Empty
                End If


                Dim analiseesalq As New AnaliseEsalq

                If Trim(ViewState.Item("id_propriedade")) <> "" Then
                    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
                End If
                If Trim(ViewState.Item("id_pessoa")) <> "" Then
                    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
                End If
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                End If
                analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)

                analiseesalq.dt_coleta_start = DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))
                analiseesalq.dt_coleta_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
                analiseesalq.dt_referencia = ViewState.Item("txt_dt_coleta_ini")

                analiseesalq.st_categoria_tecnico = ViewState.Item("categoriatecnico").ToString
                If Trim(ViewState.Item("id_tecnico")) <> "" Then
                    analiseesalq.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)
                End If
                analiseesalq.st_tipo_propriedade = ViewState.Item("tipopropriedade").ToString

                Select Case ViewState.Item("situacaorelatorio").ToString
                    Case "SA" 'trazer quem esta sem teor de cbt em qualquer dos ultimos 3 meses
                        analiseesalq.ds_compl = "---"

                    Case "C" 'Crítico - trazer todas as analises que tem 2 ou mais analises NCOMPL CBT
                        analiseesalq.nr_compl = -1

                    Case "D" 'Dispensar
                        analiseesalq.nr_compl = 3
                End Select

                Dim dsAnaliseEsalc As DataSet = analiseesalq.getCurvaAbcIN76()

                gridResults.DataSource = Helper.getDataView(dsAnaliseEsalc.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "CurvaABCIN76" & ".xls")
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
            Dim lbl_teor_ctm_mensal As Label = CType(e.Row.FindControl("lbl_teor_ctm_mensal"), Label)
            Dim lbl_teor_ctm_mensal1 As Label = CType(e.Row.FindControl("lbl_teor_ctm_mensal1"), Label)
            Dim lbl_teor_ctm_mensal2 As Label = CType(e.Row.FindControl("lbl_teor_ctm_mensal2"), Label)

            Dim lbl_menor_amostra_mes As Label = CType(e.Row.FindControl("lbl_menor_amostra_mes"), Label)

            lbl_teor_ctm_mensal.Text = DateTime.Parse(ViewState.Item("txt_dt_coleta_ini")).ToString("MMM").ToUpper
            lbl_teor_ctm_mensal1.Text = DateTime.Parse(DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper
            lbl_teor_ctm_mensal2.Text = DateTime.Parse(DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper
            lbl_menor_amostra_mes.Text = lbl_teor_ctm_mensal.Text

        End If

        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            'fran 17/02/2017 i fran
            Dim lbl_nr_teor_ctm As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm"), Label)
            Dim lbl_nr_teor_ctm1 As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm1"), Label)
            Dim lbl_nr_teor_ctm2 As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm2"), Label)
            Dim lbl_menoresalq As Label = CType(e.Row.FindControl("lbl_menoresalq"), Label)
            Dim nrcomplcbt As Label = CType(e.Row.FindControl("nrcomplcbt"), Label)
            Dim nrcomplcbt1 As Label = CType(e.Row.FindControl("nrcomplcbt1"), Label)
            Dim nrcomplcbt2 As Label = CType(e.Row.FindControl("nrcomplcbt2"), Label)
            Dim nranalisecomplcbt As Label = CType(e.Row.FindControl("nranalisecomplcbt"), Label)
            Dim nrnaocompl As Integer = 0
            Dim nr1 As Integer = 0
            Dim nr2 As Integer = 0

            If nrcomplcbt.Text = "0" Then
                nrnaocompl = nrnaocompl + 1
            End If
            If nrcomplcbt1.Text = "0" Then
                nrnaocompl = nrnaocompl + 1
            End If
            If nrcomplcbt2.Text = "0" Then
                nrnaocompl = nrnaocompl + 1
            End If

            If (nrnaocompl = 3 And nranalisecomplcbt.Text = "-1") OrElse nrnaocompl = 2 Then
                e.Row.BackColor = Drawing.Color.Yellow
                e.Row.Cells(15).BackColor = Drawing.Color.Yellow
                e.Row.Cells(16).BackColor = Drawing.Color.Yellow
                e.Row.Cells(17).BackColor = Drawing.Color.Yellow
                e.Row.Cells(18).BackColor = Drawing.Color.Yellow
                e.Row.Cells(19).BackColor = Drawing.Color.Yellow
                e.Row.Cells(20).BackColor = Drawing.Color.Yellow
                e.Row.Cells(21).BackColor = Drawing.Color.Yellow
                e.Row.Cells(22).BackColor = Drawing.Color.Yellow
            End If

            If Not lbl_nr_teor_ctm.Text.Equals(String.Empty) Then
                lbl_nr_teor_ctm.Text = FormatNumber(lbl_nr_teor_ctm.Text, 0).ToString
                If nrcomplcbt.Text = "0" Then
                    e.Row.Cells(20).BackColor = Drawing.Color.Red
                End If
            End If
            If Not lbl_nr_teor_ctm1.Text.Equals(String.Empty) Then
                lbl_nr_teor_ctm1.Text = FormatNumber(lbl_nr_teor_ctm1.Text, 0).ToString
                If nrcomplcbt1.Text = "0" Then
                    e.Row.Cells(18).BackColor = Drawing.Color.Red
                End If
            End If
            If Not lbl_nr_teor_ctm2.Text.Equals(String.Empty) Then
                lbl_nr_teor_ctm2.Text = FormatNumber(lbl_nr_teor_ctm2.Text, 0).ToString
                If nrcomplcbt2.Text = "0" Then
                    e.Row.Cells(16).BackColor = Drawing.Color.Red
                End If

            End If

            If Not lbl_menoresalq.Text.Equals(String.Empty) Then
                lbl_menoresalq.Text = FormatNumber(lbl_menoresalq.Text, 0).ToString
                If nranalisecomplcbt.Text = "0" Then
                    e.Row.Cells(22).BackColor = Drawing.Color.Red
                    'se tem 3 nao compl e menor analise tbm nao complience
                    If nrnaocompl = 3 Then
                        e.Row.BackColor = Drawing.Color.Red
                        e.Row.ForeColor = Drawing.Color.White
                        e.Row.Cells(15).BackColor = Drawing.Color.Red
                        e.Row.Cells(16).BackColor = Drawing.Color.Red
                        e.Row.Cells(17).BackColor = Drawing.Color.Red
                        e.Row.Cells(18).BackColor = Drawing.Color.Red
                        e.Row.Cells(19).BackColor = Drawing.Color.Red
                        e.Row.Cells(20).BackColor = Drawing.Color.Red
                        e.Row.Cells(21).BackColor = Drawing.Color.Red
                        e.Row.Cells(22).BackColor = Drawing.Color.Red
                        e.Row.Cells(15).ForeColor = Drawing.Color.White
                        e.Row.Cells(16).ForeColor = Drawing.Color.White
                        e.Row.Cells(17).ForeColor = Drawing.Color.White
                        e.Row.Cells(18).ForeColor = Drawing.Color.White
                        e.Row.Cells(19).ForeColor = Drawing.Color.White
                        e.Row.Cells(20).ForeColor = Drawing.Color.White
                        e.Row.Cells(21).ForeColor = Drawing.Color.White
                        e.Row.Cells(22).ForeColor = Drawing.Color.White

                    End If
                End If
            End If

        End If
    End Sub

End Class
