Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_gestao_qualidade_curvaabc_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            Try


                If (Not Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                Else
                    ViewState.Item("id_estabelecimento") = String.Empty
                End If

                If (Not Request("dt_referencia") Is Nothing) Then
                    ViewState.Item("dt_referencia") = Request("dt_referencia")
                Else
                    ViewState.Item("dt_referencia") = String.Empty
                End If

                If (Not Request("ano") Is Nothing) Then
                    ViewState.Item("ano") = Request("ano")
                Else
                    ViewState.Item("ano") = String.Empty
                End If

                Dim analiseesalq As New AnaliseEsalq

                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                End If

                analiseesalq.dt_referencia_ini = String.Concat("01/01/", (CInt(ViewState.Item("ano").ToString) - 1).ToString)
                analiseesalq.dt_referencia_fim = String.Concat("01/12/", ViewState.Item("ano").ToString)

                Dim dsAnaliseEsalc As DataSet = analiseesalq.getGestaoCurvaAbc()

                gridResults.DataSource = Helper.getDataView(dsAnaliseEsalc.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "GestaoQualidade_CurvaABC_" & Replace(Right(ViewState.Item("dt_referencia").ToString, 7), "/", "") & ".xls")
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

        End If

        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_nr_volume_1_ant As Label = CType(e.Row.FindControl("lbl_nr_volume_1_ant"), Label)
            Dim lbl_nr_volume_2_ant As Label = CType(e.Row.FindControl("lbl_nr_volume_2_ant"), Label)
            Dim lbl_nr_volume_3_ant As Label = CType(e.Row.FindControl("lbl_nr_volume_3_ant"), Label)
            Dim lbl_nr_volume_4_ant As Label = CType(e.Row.FindControl("lbl_nr_volume_4_ant"), Label)
            Dim lbl_nr_volume_5_ant As Label = CType(e.Row.FindControl("lbl_nr_volume_5_ant"), Label)
            Dim lbl_nr_volume_6_ant As Label = CType(e.Row.FindControl("lbl_nr_volume_6_ant"), Label)
            Dim lbl_nr_volume_7_ant As Label = CType(e.Row.FindControl("lbl_nr_volume_7_ant"), Label)
            Dim lbl_nr_volume_8_ant As Label = CType(e.Row.FindControl("lbl_nr_volume_8_ant"), Label)
            Dim lbl_nr_volume_9_ant As Label = CType(e.Row.FindControl("lbl_nr_volume_9_ant"), Label)
            Dim lbl_nr_volume_10_ant As Label = CType(e.Row.FindControl("lbl_nr_volume_10_ant"), Label)
            Dim lbl_nr_volume_11_ant As Label = CType(e.Row.FindControl("lbl_nr_volume_11_ant"), Label)
            Dim lbl_nr_volume_12_ant As Label = CType(e.Row.FindControl("lbl_nr_volume_12_ant"), Label)
            Dim lbl_nr_volume_1 As Label = CType(e.Row.FindControl("lbl_nr_volume_1"), Label)
            Dim lbl_nr_volume_2 As Label = CType(e.Row.FindControl("lbl_nr_volume_2"), Label)
            Dim lbl_nr_volume_3 As Label = CType(e.Row.FindControl("lbl_nr_volume_3"), Label)
            Dim lbl_nr_volume_4 As Label = CType(e.Row.FindControl("lbl_nr_volume_4"), Label)
            Dim lbl_nr_volume_5 As Label = CType(e.Row.FindControl("lbl_nr_volume_5"), Label)
            Dim lbl_nr_volume_6 As Label = CType(e.Row.FindControl("lbl_nr_volume_6"), Label)
            Dim lbl_nr_volume_7 As Label = CType(e.Row.FindControl("lbl_nr_volume_7"), Label)
            Dim lbl_nr_volume_8 As Label = CType(e.Row.FindControl("lbl_nr_volume_8"), Label)
            Dim lbl_nr_volume_9 As Label = CType(e.Row.FindControl("lbl_nr_volume_9"), Label)
            Dim lbl_nr_volume_10 As Label = CType(e.Row.FindControl("lbl_nr_volume_10"), Label)
            Dim lbl_nr_volume_11 As Label = CType(e.Row.FindControl("lbl_nr_volume_11"), Label)
            Dim lbl_nr_volume_12 As Label = CType(e.Row.FindControl("lbl_nr_volume_12"), Label)
            Dim lbl_nr_cbt_1_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_1_ant"), Label)
            Dim lbl_nr_cbt_2_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_2_ant"), Label)
            Dim lbl_nr_cbt_3_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_3_ant"), Label)
            Dim lbl_nr_cbt_4_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_4_ant"), Label)
            Dim lbl_nr_cbt_5_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_5_ant"), Label)
            Dim lbl_nr_cbt_6_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_6_ant"), Label)
            Dim lbl_nr_cbt_7_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_7_ant"), Label)
            Dim lbl_nr_cbt_8_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_8_ant"), Label)
            Dim lbl_nr_cbt_9_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_9_ant"), Label)
            Dim lbl_nr_cbt_10_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_10_ant"), Label)
            Dim lbl_nr_cbt_11_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_11_ant"), Label)
            Dim lbl_nr_cbt_12_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_12_ant"), Label)
            Dim lbl_nr_cbt_1 As Label = CType(e.Row.FindControl("lbl_nr_cbt_1"), Label)
            Dim lbl_nr_cbt_2 As Label = CType(e.Row.FindControl("lbl_nr_cbt_2"), Label)
            Dim lbl_nr_cbt_3 As Label = CType(e.Row.FindControl("lbl_nr_cbt_3"), Label)
            Dim lbl_nr_cbt_4 As Label = CType(e.Row.FindControl("lbl_nr_cbt_4"), Label)
            Dim lbl_nr_cbt_5 As Label = CType(e.Row.FindControl("lbl_nr_cbt_5"), Label)
            Dim lbl_nr_cbt_6 As Label = CType(e.Row.FindControl("lbl_nr_cbt_6"), Label)
            Dim lbl_nr_cbt_7 As Label = CType(e.Row.FindControl("lbl_nr_cbt_7"), Label)
            Dim lbl_nr_cbt_8 As Label = CType(e.Row.FindControl("lbl_nr_cbt_8"), Label)
            Dim lbl_nr_cbt_9 As Label = CType(e.Row.FindControl("lbl_nr_cbt_9"), Label)
            Dim lbl_nr_cbt_10 As Label = CType(e.Row.FindControl("lbl_nr_cbt_10"), Label)
            Dim lbl_nr_cbt_11 As Label = CType(e.Row.FindControl("lbl_nr_cbt_11"), Label)
            Dim lbl_nr_cbt_12 As Label = CType(e.Row.FindControl("lbl_nr_cbt_12"), Label)
            Dim lbl_nr_ccs_1_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_1_ant"), Label)
            Dim lbl_nr_ccs_2_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_2_ant"), Label)
            Dim lbl_nr_ccs_3_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_3_ant"), Label)
            Dim lbl_nr_ccs_4_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_4_ant"), Label)
            Dim lbl_nr_ccs_5_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_5_ant"), Label)
            Dim lbl_nr_ccs_6_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_6_ant"), Label)
            Dim lbl_nr_ccs_7_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_7_ant"), Label)
            Dim lbl_nr_ccs_8_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_8_ant"), Label)
            Dim lbl_nr_ccs_9_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_9_ant"), Label)
            Dim lbl_nr_ccs_10_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_10_ant"), Label)
            Dim lbl_nr_ccs_11_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_11_ant"), Label)
            Dim lbl_nr_ccs_12_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_12_ant"), Label)
            Dim lbl_nr_ccs_1 As Label = CType(e.Row.FindControl("lbl_nr_ccs_1"), Label)
            Dim lbl_nr_ccs_2 As Label = CType(e.Row.FindControl("lbl_nr_ccs_2"), Label)
            Dim lbl_nr_ccs_3 As Label = CType(e.Row.FindControl("lbl_nr_ccs_3"), Label)
            Dim lbl_nr_ccs_4 As Label = CType(e.Row.FindControl("lbl_nr_ccs_4"), Label)
            Dim lbl_nr_ccs_5 As Label = CType(e.Row.FindControl("lbl_nr_ccs_5"), Label)
            Dim lbl_nr_ccs_6 As Label = CType(e.Row.FindControl("lbl_nr_ccs_6"), Label)
            Dim lbl_nr_ccs_7 As Label = CType(e.Row.FindControl("lbl_nr_ccs_7"), Label)
            Dim lbl_nr_ccs_8 As Label = CType(e.Row.FindControl("lbl_nr_ccs_8"), Label)
            Dim lbl_nr_ccs_9 As Label = CType(e.Row.FindControl("lbl_nr_ccs_9"), Label)
            Dim lbl_nr_ccs_10 As Label = CType(e.Row.FindControl("lbl_nr_ccs_10"), Label)
            Dim lbl_nr_ccs_11 As Label = CType(e.Row.FindControl("lbl_nr_ccs_11"), Label)
            Dim lbl_nr_ccs_12 As Label = CType(e.Row.FindControl("lbl_nr_ccs_12"), Label)
            Dim lbl_nr_prot_1_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_1_ant"), Label)
            Dim lbl_nr_prot_2_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_2_ant"), Label)
            Dim lbl_nr_prot_3_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_3_ant"), Label)
            Dim lbl_nr_prot_4_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_4_ant"), Label)
            Dim lbl_nr_prot_5_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_5_ant"), Label)
            Dim lbl_nr_prot_6_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_6_ant"), Label)
            Dim lbl_nr_prot_7_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_7_ant"), Label)
            Dim lbl_nr_prot_8_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_8_ant"), Label)
            Dim lbl_nr_prot_9_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_9_ant"), Label)
            Dim lbl_nr_prot_10_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_10_ant"), Label)
            Dim lbl_nr_prot_11_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_11_ant"), Label)
            Dim lbl_nr_prot_12_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_12_ant"), Label)
            Dim lbl_nr_prot_1 As Label = CType(e.Row.FindControl("lbl_nr_prot_1"), Label)
            Dim lbl_nr_prot_2 As Label = CType(e.Row.FindControl("lbl_nr_prot_2"), Label)
            Dim lbl_nr_prot_3 As Label = CType(e.Row.FindControl("lbl_nr_prot_3"), Label)
            Dim lbl_nr_prot_4 As Label = CType(e.Row.FindControl("lbl_nr_prot_4"), Label)
            Dim lbl_nr_prot_5 As Label = CType(e.Row.FindControl("lbl_nr_prot_5"), Label)
            Dim lbl_nr_prot_6 As Label = CType(e.Row.FindControl("lbl_nr_prot_6"), Label)
            Dim lbl_nr_prot_7 As Label = CType(e.Row.FindControl("lbl_nr_prot_7"), Label)
            Dim lbl_nr_prot_8 As Label = CType(e.Row.FindControl("lbl_nr_prot_8"), Label)
            Dim lbl_nr_prot_9 As Label = CType(e.Row.FindControl("lbl_nr_prot_9"), Label)
            Dim lbl_nr_prot_10 As Label = CType(e.Row.FindControl("lbl_nr_prot_10"), Label)
            Dim lbl_nr_prot_11 As Label = CType(e.Row.FindControl("lbl_nr_prot_11"), Label)
            Dim lbl_nr_prot_12 As Label = CType(e.Row.FindControl("lbl_nr_prot_12"), Label)
            Dim lbl_nr_mg_1_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_1_ant"), Label)
            Dim lbl_nr_mg_2_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_2_ant"), Label)
            Dim lbl_nr_mg_3_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_3_ant"), Label)
            Dim lbl_nr_mg_4_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_4_ant"), Label)
            Dim lbl_nr_mg_5_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_5_ant"), Label)
            Dim lbl_nr_mg_6_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_6_ant"), Label)
            Dim lbl_nr_mg_7_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_7_ant"), Label)
            Dim lbl_nr_mg_8_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_8_ant"), Label)
            Dim lbl_nr_mg_9_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_9_ant"), Label)
            Dim lbl_nr_mg_10_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_10_ant"), Label)
            Dim lbl_nr_mg_11_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_11_ant"), Label)
            Dim lbl_nr_mg_12_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_12_ant"), Label)
            Dim lbl_nr_mg_1 As Label = CType(e.Row.FindControl("lbl_nr_mg_1"), Label)
            Dim lbl_nr_mg_2 As Label = CType(e.Row.FindControl("lbl_nr_mg_2"), Label)
            Dim lbl_nr_mg_3 As Label = CType(e.Row.FindControl("lbl_nr_mg_3"), Label)
            Dim lbl_nr_mg_4 As Label = CType(e.Row.FindControl("lbl_nr_mg_4"), Label)
            Dim lbl_nr_mg_5 As Label = CType(e.Row.FindControl("lbl_nr_mg_5"), Label)
            Dim lbl_nr_mg_6 As Label = CType(e.Row.FindControl("lbl_nr_mg_6"), Label)
            Dim lbl_nr_mg_7 As Label = CType(e.Row.FindControl("lbl_nr_mg_7"), Label)
            Dim lbl_nr_mg_8 As Label = CType(e.Row.FindControl("lbl_nr_mg_8"), Label)
            Dim lbl_nr_mg_9 As Label = CType(e.Row.FindControl("lbl_nr_mg_9"), Label)
            Dim lbl_nr_mg_10 As Label = CType(e.Row.FindControl("lbl_nr_mg_10"), Label)
            Dim lbl_nr_mg_11 As Label = CType(e.Row.FindControl("lbl_nr_mg_11"), Label)
            Dim lbl_nr_mg_12 As Label = CType(e.Row.FindControl("lbl_nr_mg_12"), Label)

            'Dim lbl_nr_cbt_ponderado_1_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_1_ant"), Label)
            'Dim lbl_nr_cbt_ponderado_2_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_2_ant"), Label)
            'Dim lbl_nr_cbt_ponderado_3_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_3_ant"), Label)
            'Dim lbl_nr_cbt_ponderado_4_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_4_ant"), Label)
            'Dim lbl_nr_cbt_ponderado_5_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_5_ant"), Label)
            'Dim lbl_nr_cbt_ponderado_6_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_6_ant"), Label)
            'Dim lbl_nr_cbt_ponderado_7_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_7_ant"), Label)
            'Dim lbl_nr_cbt_ponderado_8_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_8_ant"), Label)
            'Dim lbl_nr_cbt_ponderado_9_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_9_ant"), Label)
            'Dim lbl_nr_cbt_ponderado_10_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_10_ant"), Label)
            'Dim lbl_nr_cbt_ponderado_11_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_11_ant"), Label)
            'Dim lbl_nr_cbt_ponderado_12_ant As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_12_ant"), Label)
            'Dim lbl_nr_cbt_ponderado_1 As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_1"), Label)
            'Dim lbl_nr_cbt_ponderado_2 As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_2"), Label)
            'Dim lbl_nr_cbt_ponderado_3 As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_3"), Label)
            'Dim lbl_nr_cbt_ponderado_4 As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_4"), Label)
            'Dim lbl_nr_cbt_ponderado_5 As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_5"), Label)
            'Dim lbl_nr_cbt_ponderado_6 As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_6"), Label)
            'Dim lbl_nr_cbt_ponderado_7 As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_7"), Label)
            'Dim lbl_nr_cbt_ponderado_8 As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_8"), Label)
            'Dim lbl_nr_cbt_ponderado_9 As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_9"), Label)
            'Dim lbl_nr_cbt_ponderado_10 As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_10"), Label)
            'Dim lbl_nr_cbt_ponderado_11 As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_11"), Label)
            'Dim lbl_nr_cbt_ponderado_12 As Label = CType(e.Row.FindControl("lbl_nr_cbt_ponderado_12"), Label)
            'Dim lbl_nr_ccs_ponderado_1_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_1_ant"), Label)
            'Dim lbl_nr_ccs_ponderado_2_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_2_ant"), Label)
            'Dim lbl_nr_ccs_ponderado_3_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_3_ant"), Label)
            'Dim lbl_nr_ccs_ponderado_4_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_4_ant"), Label)
            'Dim lbl_nr_ccs_ponderado_5_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_5_ant"), Label)
            'Dim lbl_nr_ccs_ponderado_6_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_6_ant"), Label)
            'Dim lbl_nr_ccs_ponderado_7_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_7_ant"), Label)
            'Dim lbl_nr_ccs_ponderado_8_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_8_ant"), Label)
            'Dim lbl_nr_ccs_ponderado_9_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_9_ant"), Label)
            'Dim lbl_nr_ccs_ponderado_10_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_10_ant"), Label)
            'Dim lbl_nr_ccs_ponderado_11_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_11_ant"), Label)
            'Dim lbl_nr_ccs_ponderado_12_ant As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_12_ant"), Label)
            'Dim lbl_nr_ccs_ponderado_1 As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_1"), Label)
            'Dim lbl_nr_ccs_ponderado_2 As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_2"), Label)
            'Dim lbl_nr_ccs_ponderado_3 As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_3"), Label)
            'Dim lbl_nr_ccs_ponderado_4 As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_4"), Label)
            'Dim lbl_nr_ccs_ponderado_5 As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_5"), Label)
            'Dim lbl_nr_ccs_ponderado_6 As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_6"), Label)
            'Dim lbl_nr_ccs_ponderado_7 As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_7"), Label)
            'Dim lbl_nr_ccs_ponderado_8 As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_8"), Label)
            'Dim lbl_nr_ccs_ponderado_9 As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_9"), Label)
            'Dim lbl_nr_ccs_ponderado_10 As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_10"), Label)
            'Dim lbl_nr_ccs_ponderado_11 As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_11"), Label)
            'Dim lbl_nr_ccs_ponderado_12 As Label = CType(e.Row.FindControl("lbl_nr_ccs_ponderado_12"), Label)
            'Dim lbl_nr_prot_ponderado_1_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_1_ant"), Label)
            'Dim lbl_nr_prot_ponderado_2_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_2_ant"), Label)
            'Dim lbl_nr_prot_ponderado_3_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_3_ant"), Label)
            'Dim lbl_nr_prot_ponderado_4_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_4_ant"), Label)
            'Dim lbl_nr_prot_ponderado_5_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_5_ant"), Label)
            'Dim lbl_nr_prot_ponderado_6_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_6_ant"), Label)
            'Dim lbl_nr_prot_ponderado_7_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_7_ant"), Label)
            'Dim lbl_nr_prot_ponderado_8_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_8_ant"), Label)
            'Dim lbl_nr_prot_ponderado_9_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_9_ant"), Label)
            'Dim lbl_nr_prot_ponderado_10_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_10_ant"), Label)
            'Dim lbl_nr_prot_ponderado_11_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_11_ant"), Label)
            'Dim lbl_nr_prot_ponderado_12_ant As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_12_ant"), Label)
            'Dim lbl_nr_prot_ponderado_1 As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_1"), Label)
            'Dim lbl_nr_prot_ponderado_2 As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_2"), Label)
            'Dim lbl_nr_prot_ponderado_3 As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_3"), Label)
            'Dim lbl_nr_prot_ponderado_4 As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_4"), Label)
            'Dim lbl_nr_prot_ponderado_5 As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_5"), Label)
            'Dim lbl_nr_prot_ponderado_6 As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_6"), Label)
            'Dim lbl_nr_prot_ponderado_7 As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_7"), Label)
            'Dim lbl_nr_prot_ponderado_8 As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_8"), Label)
            'Dim lbl_nr_prot_ponderado_9 As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_9"), Label)
            'Dim lbl_nr_prot_ponderado_10 As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_10"), Label)
            'Dim lbl_nr_prot_ponderado_11 As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_11"), Label)
            'Dim lbl_nr_prot_ponderado_12 As Label = CType(e.Row.FindControl("lbl_nr_prot_ponderado_12"), Label)
            'Dim lbl_nr_mg_ponderado_1_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_1_ant"), Label)
            'Dim lbl_nr_mg_ponderado_2_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_2_ant"), Label)
            'Dim lbl_nr_mg_ponderado_3_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_3_ant"), Label)
            'Dim lbl_nr_mg_ponderado_4_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_4_ant"), Label)
            'Dim lbl_nr_mg_ponderado_5_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_5_ant"), Label)
            'Dim lbl_nr_mg_ponderado_6_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_6_ant"), Label)
            'Dim lbl_nr_mg_ponderado_7_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_7_ant"), Label)
            'Dim lbl_nr_mg_ponderado_8_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_8_ant"), Label)
            'Dim lbl_nr_mg_ponderado_9_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_9_ant"), Label)
            'Dim lbl_nr_mg_ponderado_10_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_10_ant"), Label)
            'Dim lbl_nr_mg_ponderado_11_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_11_ant"), Label)
            'Dim lbl_nr_mg_ponderado_12_ant As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_12_ant"), Label)
            'Dim lbl_nr_mg_ponderado_1 As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_1"), Label)
            'Dim lbl_nr_mg_ponderado_2 As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_2"), Label)
            'Dim lbl_nr_mg_ponderado_3 As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_3"), Label)
            'Dim lbl_nr_mg_ponderado_4 As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_4"), Label)
            'Dim lbl_nr_mg_ponderado_5 As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_5"), Label)
            'Dim lbl_nr_mg_ponderado_6 As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_6"), Label)
            'Dim lbl_nr_mg_ponderado_7 As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_7"), Label)
            'Dim lbl_nr_mg_ponderado_8 As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_8"), Label)
            'Dim lbl_nr_mg_ponderado_9 As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_9"), Label)
            'Dim lbl_nr_mg_ponderado_10 As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_10"), Label)
            'Dim lbl_nr_mg_ponderado_11 As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_11"), Label)
            'Dim lbl_nr_mg_ponderado_12 As Label = CType(e.Row.FindControl("lbl_nr_mg_ponderado_12"), Label)

            'VOLUME
            If Not (lbl_nr_volume_1_ant.Text.Equals(String.Empty)) Then
                lbl_nr_volume_1_ant.Text = FormatNumber(lbl_nr_volume_1_ant.Text, 0).ToString
            End If

            If Not (lbl_nr_volume_2_ant.Text.Equals(String.Empty)) Then
                lbl_nr_volume_2_ant.Text = FormatNumber(lbl_nr_volume_2_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_3_ant.Text.Equals(String.Empty)) Then
                lbl_nr_volume_3_ant.Text = FormatNumber(lbl_nr_volume_3_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_4_ant.Text.Equals(String.Empty)) Then
                lbl_nr_volume_4_ant.Text = FormatNumber(lbl_nr_volume_4_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_5_ant.Text.Equals(String.Empty)) Then
                lbl_nr_volume_5_ant.Text = FormatNumber(lbl_nr_volume_5_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_6_ant.Text.Equals(String.Empty)) Then
                lbl_nr_volume_6_ant.Text = FormatNumber(lbl_nr_volume_6_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_7_ant.Text.Equals(String.Empty)) Then
                lbl_nr_volume_7_ant.Text = FormatNumber(lbl_nr_volume_7_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_8_ant.Text.Equals(String.Empty)) Then
                lbl_nr_volume_8_ant.Text = FormatNumber(lbl_nr_volume_8_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_9_ant.Text.Equals(String.Empty)) Then
                lbl_nr_volume_9_ant.Text = FormatNumber(lbl_nr_volume_9_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_10_ant.Text.Equals(String.Empty)) Then
                lbl_nr_volume_10_ant.Text = FormatNumber(lbl_nr_volume_10_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_11_ant.Text.Equals(String.Empty)) Then
                lbl_nr_volume_11_ant.Text = FormatNumber(lbl_nr_volume_11_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_12_ant.Text.Equals(String.Empty)) Then
                lbl_nr_volume_12_ant.Text = FormatNumber(lbl_nr_volume_12_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_1.Text.Equals(String.Empty)) Then
                lbl_nr_volume_1.Text = FormatNumber(lbl_nr_volume_1.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_2.Text.Equals(String.Empty)) Then
                lbl_nr_volume_2.Text = FormatNumber(lbl_nr_volume_2.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_3.Text.Equals(String.Empty)) Then
                lbl_nr_volume_3.Text = FormatNumber(lbl_nr_volume_3.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_4.Text.Equals(String.Empty)) Then
                lbl_nr_volume_4.Text = FormatNumber(lbl_nr_volume_4.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_5.Text.Equals(String.Empty)) Then
                lbl_nr_volume_5.Text = FormatNumber(lbl_nr_volume_5.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_6.Text.Equals(String.Empty)) Then
                lbl_nr_volume_6.Text = FormatNumber(lbl_nr_volume_6.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_7.Text.Equals(String.Empty)) Then
                lbl_nr_volume_7.Text = FormatNumber(lbl_nr_volume_7.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_8.Text.Equals(String.Empty)) Then
                lbl_nr_volume_8.Text = FormatNumber(lbl_nr_volume_8.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_9.Text.Equals(String.Empty)) Then
                lbl_nr_volume_9.Text = FormatNumber(lbl_nr_volume_9.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_10.Text.Equals(String.Empty)) Then
                lbl_nr_volume_10.Text = FormatNumber(lbl_nr_volume_10.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_11.Text.Equals(String.Empty)) Then
                lbl_nr_volume_11.Text = FormatNumber(lbl_nr_volume_11.Text, 0).ToString
            End If
            If Not (lbl_nr_volume_12.Text.Equals(String.Empty)) Then
                lbl_nr_volume_12.Text = FormatNumber(lbl_nr_volume_12.Text, 0).ToString
            End If

            'cbt
            If Not (lbl_nr_cbt_1_ant.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_1_ant.Text = FormatNumber(lbl_nr_cbt_1_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_2_ant.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_2_ant.Text = FormatNumber(lbl_nr_cbt_2_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_3_ant.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_3_ant.Text = FormatNumber(lbl_nr_cbt_3_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_4_ant.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_4_ant.Text = FormatNumber(lbl_nr_cbt_4_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_5_ant.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_5_ant.Text = FormatNumber(lbl_nr_cbt_5_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_6_ant.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_6_ant.Text = FormatNumber(lbl_nr_cbt_6_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_7_ant.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_7_ant.Text = FormatNumber(lbl_nr_cbt_7_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_8_ant.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_8_ant.Text = FormatNumber(lbl_nr_cbt_8_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_9_ant.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_9_ant.Text = FormatNumber(lbl_nr_cbt_9_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_10_ant.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_10_ant.Text = FormatNumber(lbl_nr_cbt_10_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_11_ant.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_11_ant.Text = FormatNumber(lbl_nr_cbt_11_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_12_ant.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_12_ant.Text = FormatNumber(lbl_nr_cbt_12_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_1.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_1.Text = FormatNumber(lbl_nr_cbt_1.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_2.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_2.Text = FormatNumber(lbl_nr_cbt_2.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_3.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_3.Text = FormatNumber(lbl_nr_cbt_3.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_4.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_4.Text = FormatNumber(lbl_nr_cbt_4.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_5.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_5.Text = FormatNumber(lbl_nr_cbt_5.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_6.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_6.Text = FormatNumber(lbl_nr_cbt_6.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_7.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_7.Text = FormatNumber(lbl_nr_cbt_7.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_8.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_8.Text = FormatNumber(lbl_nr_cbt_8.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_9.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_9.Text = FormatNumber(lbl_nr_cbt_9.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_10.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_10.Text = FormatNumber(lbl_nr_cbt_10.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_11.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_11.Text = FormatNumber(lbl_nr_cbt_11.Text, 0).ToString
            End If
            If Not (lbl_nr_cbt_12.Text.Equals(String.Empty)) Then
                lbl_nr_cbt_12.Text = FormatNumber(lbl_nr_cbt_12.Text, 0).ToString
            End If

            'ccs
            If Not (lbl_nr_ccs_1_ant.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_1_ant.Text = FormatNumber(lbl_nr_ccs_1_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_2_ant.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_2_ant.Text = FormatNumber(lbl_nr_ccs_2_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_3_ant.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_3_ant.Text = FormatNumber(lbl_nr_ccs_3_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_4_ant.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_4_ant.Text = FormatNumber(lbl_nr_ccs_4_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_5_ant.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_5_ant.Text = FormatNumber(lbl_nr_ccs_5_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_6_ant.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_6_ant.Text = FormatNumber(lbl_nr_ccs_6_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_7_ant.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_7_ant.Text = FormatNumber(lbl_nr_ccs_7_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_8_ant.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_8_ant.Text = FormatNumber(lbl_nr_ccs_8_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_9_ant.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_9_ant.Text = FormatNumber(lbl_nr_ccs_9_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_10_ant.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_10_ant.Text = FormatNumber(lbl_nr_ccs_10_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_11_ant.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_11_ant.Text = FormatNumber(lbl_nr_ccs_11_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_12_ant.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_12_ant.Text = FormatNumber(lbl_nr_ccs_12_ant.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_1.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_1.Text = FormatNumber(lbl_nr_ccs_1.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_2.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_2.Text = FormatNumber(lbl_nr_ccs_2.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_3.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_3.Text = FormatNumber(lbl_nr_ccs_3.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_4.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_4.Text = FormatNumber(lbl_nr_ccs_4.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_5.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_5.Text = FormatNumber(lbl_nr_ccs_5.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_6.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_6.Text = FormatNumber(lbl_nr_ccs_6.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_7.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_7.Text = FormatNumber(lbl_nr_ccs_7.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_8.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_8.Text = FormatNumber(lbl_nr_ccs_8.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_9.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_9.Text = FormatNumber(lbl_nr_ccs_9.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_10.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_10.Text = FormatNumber(lbl_nr_ccs_10.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_11.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_11.Text = FormatNumber(lbl_nr_ccs_11.Text, 0).ToString
            End If
            If Not (lbl_nr_ccs_12.Text.Equals(String.Empty)) Then
                lbl_nr_ccs_12.Text = FormatNumber(lbl_nr_ccs_12.Text, 0).ToString
            End If

            ''proteina
            If Not (lbl_nr_prot_1_ant.Text.Equals(String.Empty)) Then
                lbl_nr_prot_1_ant.Text = FormatNumber(lbl_nr_prot_1_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_2_ant.Text.Equals(String.Empty)) Then
                lbl_nr_prot_2_ant.Text = FormatNumber(lbl_nr_prot_2_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_3_ant.Text.Equals(String.Empty)) Then
                lbl_nr_prot_3_ant.Text = FormatNumber(lbl_nr_prot_3_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_4_ant.Text.Equals(String.Empty)) Then
                lbl_nr_prot_4_ant.Text = FormatNumber(lbl_nr_prot_4_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_5_ant.Text.Equals(String.Empty)) Then
                lbl_nr_prot_5_ant.Text = FormatNumber(lbl_nr_prot_5_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_6_ant.Text.Equals(String.Empty)) Then
                lbl_nr_prot_6_ant.Text = FormatNumber(lbl_nr_prot_6_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_7_ant.Text.Equals(String.Empty)) Then
                lbl_nr_prot_7_ant.Text = FormatNumber(lbl_nr_prot_7_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_8_ant.Text.Equals(String.Empty)) Then
                lbl_nr_prot_8_ant.Text = FormatNumber(lbl_nr_prot_8_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_9_ant.Text.Equals(String.Empty)) Then
                lbl_nr_prot_9_ant.Text = FormatNumber(lbl_nr_prot_9_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_10_ant.Text.Equals(String.Empty)) Then
                lbl_nr_prot_10_ant.Text = FormatNumber(lbl_nr_prot_10_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_11_ant.Text.Equals(String.Empty)) Then
                lbl_nr_prot_11_ant.Text = FormatNumber(lbl_nr_prot_11_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_12_ant.Text.Equals(String.Empty)) Then
                lbl_nr_prot_12_ant.Text = FormatNumber(lbl_nr_prot_12_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_1.Text.Equals(String.Empty)) Then
                lbl_nr_prot_1.Text = FormatNumber(lbl_nr_prot_1.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_2.Text.Equals(String.Empty)) Then
                lbl_nr_prot_2.Text = FormatNumber(lbl_nr_prot_2.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_3.Text.Equals(String.Empty)) Then
                lbl_nr_prot_3.Text = FormatNumber(lbl_nr_prot_3.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_4.Text.Equals(String.Empty)) Then
                lbl_nr_prot_4.Text = FormatNumber(lbl_nr_prot_4.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_5.Text.Equals(String.Empty)) Then
                lbl_nr_prot_5.Text = FormatNumber(lbl_nr_prot_5.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_6.Text.Equals(String.Empty)) Then
                lbl_nr_prot_6.Text = FormatNumber(lbl_nr_prot_6.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_7.Text.Equals(String.Empty)) Then
                lbl_nr_prot_7.Text = FormatNumber(lbl_nr_prot_7.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_8.Text.Equals(String.Empty)) Then
                lbl_nr_prot_8.Text = FormatNumber(lbl_nr_prot_8.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_9.Text.Equals(String.Empty)) Then
                lbl_nr_prot_9.Text = FormatNumber(lbl_nr_prot_9.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_10.Text.Equals(String.Empty)) Then
                lbl_nr_prot_10.Text = FormatNumber(lbl_nr_prot_10.Text, 2).ToString
            End If
            If Not (lbl_nr_prot_11.Text.Equals(String.Empty)) Then
                lbl_nr_prot_11.Text = FormatNumber(lbl_nr_prot_11.Text, 2).ToString

            End If
            If Not (lbl_nr_prot_12.Text.Equals(String.Empty)) Then
                lbl_nr_prot_12.Text = FormatNumber(lbl_nr_prot_12.Text, 2).ToString
            End If

            'mg
            If Not (lbl_nr_mg_1_ant.Text.Equals(String.Empty)) Then
                lbl_nr_mg_1_ant.Text = FormatNumber(lbl_nr_mg_1_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_2_ant.Text.Equals(String.Empty)) Then
                lbl_nr_mg_2_ant.Text = FormatNumber(lbl_nr_mg_2_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_3_ant.Text.Equals(String.Empty)) Then
                lbl_nr_mg_3_ant.Text = FormatNumber(lbl_nr_mg_3_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_4_ant.Text.Equals(String.Empty)) Then
                lbl_nr_mg_4_ant.Text = FormatNumber(lbl_nr_mg_4_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_5_ant.Text.Equals(String.Empty)) Then
                lbl_nr_mg_5_ant.Text = FormatNumber(lbl_nr_mg_5_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_6_ant.Text.Equals(String.Empty)) Then
                lbl_nr_mg_6_ant.Text = FormatNumber(lbl_nr_mg_6_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_7_ant.Text.Equals(String.Empty)) Then
                lbl_nr_mg_7_ant.Text = FormatNumber(lbl_nr_mg_7_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_8_ant.Text.Equals(String.Empty)) Then
                lbl_nr_mg_8_ant.Text = FormatNumber(lbl_nr_mg_8_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_9_ant.Text.Equals(String.Empty)) Then
                lbl_nr_mg_9_ant.Text = FormatNumber(lbl_nr_mg_9_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_10_ant.Text.Equals(String.Empty)) Then
                lbl_nr_mg_10_ant.Text = FormatNumber(lbl_nr_mg_10_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_11_ant.Text.Equals(String.Empty)) Then
                lbl_nr_mg_11_ant.Text = FormatNumber(lbl_nr_mg_11_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_12_ant.Text.Equals(String.Empty)) Then
                lbl_nr_mg_12_ant.Text = FormatNumber(lbl_nr_mg_12_ant.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_1.Text.Equals(String.Empty)) Then
                lbl_nr_mg_1.Text = FormatNumber(lbl_nr_mg_1.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_2.Text.Equals(String.Empty)) Then
                lbl_nr_mg_2.Text = FormatNumber(lbl_nr_mg_2.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_3.Text.Equals(String.Empty)) Then
                lbl_nr_mg_3.Text = FormatNumber(lbl_nr_mg_3.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_4.Text.Equals(String.Empty)) Then
                lbl_nr_mg_4.Text = FormatNumber(lbl_nr_mg_4.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_5.Text.Equals(String.Empty)) Then
                lbl_nr_mg_5.Text = FormatNumber(lbl_nr_mg_5.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_6.Text.Equals(String.Empty)) Then
                lbl_nr_mg_6.Text = FormatNumber(lbl_nr_mg_6.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_7.Text.Equals(String.Empty)) Then
                lbl_nr_mg_7.Text = FormatNumber(lbl_nr_mg_7.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_8.Text.Equals(String.Empty)) Then
                lbl_nr_mg_8.Text = FormatNumber(lbl_nr_mg_8.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_9.Text.Equals(String.Empty)) Then
                lbl_nr_mg_9.Text = FormatNumber(lbl_nr_mg_9.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_10.Text.Equals(String.Empty)) Then
                lbl_nr_mg_10.Text = FormatNumber(lbl_nr_mg_10.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_11.Text.Equals(String.Empty)) Then
                lbl_nr_mg_11.Text = FormatNumber(lbl_nr_mg_11.Text, 2).ToString
            End If
            If Not (lbl_nr_mg_12.Text.Equals(String.Empty)) Then
                lbl_nr_mg_12.Text = FormatNumber(lbl_nr_mg_12.Text, 2).ToString
            End If

            ''cbt
            'lbl_nr_cbt_ponderado_1_ant.Text = IIf(lbl_nr_cbt_ponderado_1_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_1_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_2_ant.Text = IIf(lbl_nr_cbt_ponderado_2_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_2_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_3_ant.Text = IIf(lbl_nr_cbt_ponderado_3_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_3_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_4_ant.Text = IIf(lbl_nr_cbt_ponderado_4_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_4_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_5_ant.Text = IIf(lbl_nr_cbt_ponderado_5_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_5_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_6_ant.Text = IIf(lbl_nr_cbt_ponderado_6_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_6_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_7_ant.Text = IIf(lbl_nr_cbt_ponderado_7_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_7_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_8_ant.Text = IIf(lbl_nr_cbt_ponderado_8_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_8_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_9_ant.Text = IIf(lbl_nr_cbt_ponderado_9_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_9_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_10_ant.Text = IIf(lbl_nr_cbt_ponderado_10_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_10_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_11_ant.Text = IIf(lbl_nr_cbt_ponderado_11_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_11_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_12_ant.Text = IIf(lbl_nr_cbt_ponderado_12_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_12_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_1.Text = IIf(lbl_nr_cbt_ponderado_1.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_1_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_2.Text = IIf(lbl_nr_cbt_ponderado_2.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_2_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_3.Text = IIf(lbl_nr_cbt_ponderado_3.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_3_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_4.Text = IIf(lbl_nr_cbt_ponderado_4.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_4_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_5.Text = IIf(lbl_nr_cbt_ponderado_5.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_5_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_6.Text = IIf(lbl_nr_cbt_ponderado_6.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_6_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_7.Text = IIf(lbl_nr_cbt_ponderado_7.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_7_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_8.Text = IIf(lbl_nr_cbt_ponderado_8.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_8_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_9.Text = IIf(lbl_nr_cbt_ponderado_9.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_9_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_10.Text = IIf(lbl_nr_cbt_ponderado_10.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_10_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_11.Text = IIf(lbl_nr_cbt_ponderado_11.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_11_ant.Text, 0).ToString)
            'lbl_nr_cbt_ponderado_12.Text = IIf(lbl_nr_cbt_ponderado_12.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_cbt_ponderado_12_ant.Text, 0).ToString)

            ''ccs
            'lbl_nr_ccs_ponderado_1_ant.Text = IIf(lbl_nr_ccs_ponderado_1_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_1_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_2_ant.Text = IIf(lbl_nr_ccs_ponderado_2_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_2_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_3_ant.Text = IIf(lbl_nr_ccs_ponderado_3_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_3_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_4_ant.Text = IIf(lbl_nr_ccs_ponderado_4_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_4_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_5_ant.Text = IIf(lbl_nr_ccs_ponderado_5_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_5_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_6_ant.Text = IIf(lbl_nr_ccs_ponderado_6_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_6_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_7_ant.Text = IIf(lbl_nr_ccs_ponderado_7_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_7_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_8_ant.Text = IIf(lbl_nr_ccs_ponderado_8_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_8_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_9_ant.Text = IIf(lbl_nr_ccs_ponderado_9_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_9_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_10_ant.Text = IIf(lbl_nr_ccs_ponderado_10_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_10_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_11_ant.Text = IIf(lbl_nr_ccs_ponderado_11_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_11_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_12_ant.Text = IIf(lbl_nr_ccs_ponderado_12_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_12_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_1.Text = IIf(lbl_nr_ccs_ponderado_1.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_1_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_2.Text = IIf(lbl_nr_ccs_ponderado_2.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_2_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_3.Text = IIf(lbl_nr_ccs_ponderado_3.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_3_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_4.Text = IIf(lbl_nr_ccs_ponderado_4.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_4_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_5.Text = IIf(lbl_nr_ccs_ponderado_5.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_5_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_6.Text = IIf(lbl_nr_ccs_ponderado_6.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_6_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_7.Text = IIf(lbl_nr_ccs_ponderado_7.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_7_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_8.Text = IIf(lbl_nr_ccs_ponderado_8.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_8_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_9.Text = IIf(lbl_nr_ccs_ponderado_9.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_9_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_10.Text = IIf(lbl_nr_ccs_ponderado_10.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_10_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_11.Text = IIf(lbl_nr_ccs_ponderado_11.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_11_ant.Text, 0).ToString)
            'lbl_nr_ccs_ponderado_12.Text = IIf(lbl_nr_ccs_ponderado_12.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_ccs_ponderado_12_ant.Text, 0).ToString)

            ' ''proteina
            'lbl_nr_prot_ponderado_1_ant.Text = IIf(lbl_nr_prot_ponderado_1_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_1_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_2_ant.Text = IIf(lbl_nr_prot_ponderado_2_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_2_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_3_ant.Text = IIf(lbl_nr_prot_ponderado_3_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_3_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_4_ant.Text = IIf(lbl_nr_prot_ponderado_4_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_4_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_5_ant.Text = IIf(lbl_nr_prot_ponderado_5_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_5_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_6_ant.Text = IIf(lbl_nr_prot_ponderado_6_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_6_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_7_ant.Text = IIf(lbl_nr_prot_ponderado_7_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_7_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_8_ant.Text = IIf(lbl_nr_prot_ponderado_8_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_8_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_9_ant.Text = IIf(lbl_nr_prot_ponderado_9_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_9_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_12_ant.Text = IIf(lbl_nr_prot_ponderado_12_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_12_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_11_ant.Text = IIf(lbl_nr_prot_ponderado_11_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_11_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_12_ant.Text = IIf(lbl_nr_prot_ponderado_12_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_12_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_1.Text = IIf(lbl_nr_prot_ponderado_1.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_1_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_2.Text = IIf(lbl_nr_prot_ponderado_2.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_2_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_3.Text = IIf(lbl_nr_prot_ponderado_3.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_3_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_4.Text = IIf(lbl_nr_prot_ponderado_4.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_4_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_5.Text = IIf(lbl_nr_prot_ponderado_5.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_5_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_6.Text = IIf(lbl_nr_prot_ponderado_6.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_6_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_7.Text = IIf(lbl_nr_prot_ponderado_7.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_7_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_8.Text = IIf(lbl_nr_prot_ponderado_8.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_8_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_9.Text = IIf(lbl_nr_prot_ponderado_9.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_9_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_12.Text = IIf(lbl_nr_prot_ponderado_12.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_12_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_11.Text = IIf(lbl_nr_prot_ponderado_11.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_11_ant.Text, 2).ToString)
            'lbl_nr_prot_ponderado_12.Text = IIf(lbl_nr_prot_ponderado_12.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_prot_ponderado_12_ant.Text, 2).ToString)

            ''mg
            'lbl_nr_mg_ponderado_1_ant.Text = IIf(lbl_nr_mg_ponderado_1_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_1_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_2_ant.Text = IIf(lbl_nr_mg_ponderado_2_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_2_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_3_ant.Text = IIf(lbl_nr_mg_ponderado_3_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_3_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_4_ant.Text = IIf(lbl_nr_mg_ponderado_4_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_4_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_5_ant.Text = IIf(lbl_nr_mg_ponderado_5_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_5_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_6_ant.Text = IIf(lbl_nr_mg_ponderado_6_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_6_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_7_ant.Text = IIf(lbl_nr_mg_ponderado_7_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_7_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_8_ant.Text = IIf(lbl_nr_mg_ponderado_8_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_8_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_9_ant.Text = IIf(lbl_nr_mg_ponderado_9_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_9_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_12_ant.Text = IIf(lbl_nr_mg_ponderado_12_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_12_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_11_ant.Text = IIf(lbl_nr_mg_ponderado_11_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_11_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_12_ant.Text = IIf(lbl_nr_mg_ponderado_12_ant.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_12_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_1.Text = IIf(lbl_nr_mg_ponderado_1.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_1_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_2.Text = IIf(lbl_nr_mg_ponderado_2.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_2_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_3.Text = IIf(lbl_nr_mg_ponderado_3.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_3_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_4.Text = IIf(lbl_nr_mg_ponderado_4.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_4_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_5.Text = IIf(lbl_nr_mg_ponderado_5.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_5_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_6.Text = IIf(lbl_nr_mg_ponderado_6.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_6_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_7.Text = IIf(lbl_nr_mg_ponderado_7.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_7_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_8.Text = IIf(lbl_nr_mg_ponderado_8.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_8_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_9.Text = IIf(lbl_nr_mg_ponderado_9.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_9_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_12.Text = IIf(lbl_nr_mg_ponderado_12.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_12_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_11.Text = IIf(lbl_nr_mg_ponderado_11.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_11_ant.Text, 2).ToString)
            'lbl_nr_mg_ponderado_12.Text = IIf(lbl_nr_mg_ponderado_12.Text.Equals(String.Empty), String.Empty, FormatNumber(lbl_nr_mg_ponderado_12_ant.Text, 2).ToString)


        End If
    End Sub

End Class
