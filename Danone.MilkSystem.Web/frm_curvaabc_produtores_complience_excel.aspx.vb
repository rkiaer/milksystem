Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_curvaabc_produtores_complience_excel
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

                ' adri 08/02/2017 - chamado 2500 - acertos - filtrar Produtores / Cooperativas - i
                If (Not Request("id_grupo") Is Nothing) Then
                    ViewState.Item("id_grupo") = Request("id_grupo")
                Else
                    ViewState.Item("id_grupo") = String.Empty
                End If
                ' adri 08/02/2017 - chamado 2500 - acertos - filtrar Produtores / Cooperativas - f

                Dim analiseesalq As New AnaliseEsalq

                If Trim(ViewState.Item("id_propriedade")) <> "" Then
                    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
                End If
                If Trim(ViewState.Item("id_pessoa")) <> "" Then
                    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
                End If
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                ' adri 08/02/2017 - chamado 2500 - acertos - Trazer Poços e Aguas Juntos - i
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                End If
                analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                ' adri 08/02/2017 - chamado 2500 - acertos - Trazer Poços e Aguas Juntos - f

                analiseesalq.dt_coleta_start = DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))
                analiseesalq.dt_coleta_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
                analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_coleta_ini")


                Dim dsAnaliseEsalc As DataSet = analiseesalq.getCurvaAbcProdutoresComplience()

                gridResults.DataSource = Helper.getDataView(dsAnaliseEsalc.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "CurvaABCProdutoresCompliance" & ".xls")
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

            Dim lbl_teor_ccs_mensal As Label = CType(e.Row.FindControl("lbl_teor_ccs_mensal"), Label)
            Dim lbl_teor_ccs_mensal1 As Label = CType(e.Row.FindControl("lbl_teor_ccs_mensal1"), Label)
            Dim lbl_teor_ccs_mensal2 As Label = CType(e.Row.FindControl("lbl_teor_ccs_mensal2"), Label)

            lbl_teor_ctm_mensal.Text = DateTime.Parse(ViewState.Item("txt_dt_coleta_ini")).ToString("MMM").ToUpper
            lbl_teor_ctm_mensal1.Text = DateTime.Parse(DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper
            lbl_teor_ctm_mensal2.Text = DateTime.Parse(DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper

            lbl_teor_ccs_mensal.Text = DateTime.Parse(ViewState.Item("txt_dt_coleta_ini")).ToString("MMM").ToUpper
            lbl_teor_ccs_mensal1.Text = DateTime.Parse(DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper
            lbl_teor_ccs_mensal2.Text = DateTime.Parse(DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper

        End If

        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            'fran 17/02/2017 i fran
            Dim lbl_nr_teor_ctm_mensal As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm_mensal"), Label)
            Dim lbl_nr_teor_ctm_mensal1 As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm_mensal1"), Label)
            Dim lbl_nr_teor_ctm_mensal2 As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm_mensal2"), Label)
            Dim lbl_nr_teor_ctm_tri As DataControlFieldCell = CType(e.Row.Cells(15), DataControlFieldCell)
            Dim lbl_nr_teor_ccs_mensal As Label = CType(e.Row.FindControl("lbl_nr_teor_ccs_mensal"), Label)
            Dim lbl_nr_teor_ccs_mensal1 As Label = CType(e.Row.FindControl("lbl_nr_teor_ccs_mensal1"), Label)
            Dim lbl_nr_teor_ccs_mensal2 As Label = CType(e.Row.FindControl("lbl_nr_teor_ccs_mensal2"), Label)
            Dim lbl_nr_teor_ccs_tri As DataControlFieldCell = CType(e.Row.Cells(20), DataControlFieldCell)

            lbl_nr_teor_ctm_mensal.Text = IIf(lbl_nr_teor_ctm_mensal.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ctm_mensal.Text, 0).ToString)
            lbl_nr_teor_ctm_mensal1.Text = IIf(lbl_nr_teor_ctm_mensal1.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ctm_mensal1.Text, 0).ToString)
            lbl_nr_teor_ctm_mensal2.Text = IIf(lbl_nr_teor_ctm_mensal2.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ctm_mensal2.Text, 0).ToString)
            lbl_nr_teor_ctm_tri.Text = IIf(lbl_nr_teor_ctm_tri.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ctm_tri.Text, 0).ToString)

            lbl_nr_teor_ccs_mensal.Text = IIf(lbl_nr_teor_ccs_mensal.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ccs_mensal.Text, 0).ToString)
            lbl_nr_teor_ccs_mensal1.Text = IIf(lbl_nr_teor_ccs_mensal1.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ccs_mensal1.Text, 0).ToString)
            lbl_nr_teor_ccs_mensal2.Text = IIf(lbl_nr_teor_ccs_mensal2.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ccs_mensal2.Text, 0).ToString)
            lbl_nr_teor_ccs_tri.Text = IIf(lbl_nr_teor_ccs_tri.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ccs_tri.Text, 0).ToString)
            'fran 17/02/2017 f fran 


        End If
    End Sub

End Class
