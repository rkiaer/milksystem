Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_analise_esalq_conciliacao_excel
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


                If (Not Request("txt_dt_coleta_fim") Is Nothing) Then
                    ViewState.Item("txt_dt_coleta_fim") = Request("txt_dt_coleta_fim")
                Else
                    ViewState.Item("txt_dt_coleta_fim") = String.Empty
                End If

                If (Not Request("cd_analise_esalq") Is Nothing) Then
                    ViewState.Item("cd_analise_esalq") = Request("cd_analise_esalq")
                Else
                    ViewState.Item("cd_analise_esalq") = String.Empty
                End If

                If (Not Request("id_situacao") Is Nothing) Then
                    ViewState.Item("id_situacao") = Request("id_situacao")
                Else
                    ViewState.Item("id_situacao") = String.Empty
                End If

                If (Not Request("id_situacao_analise_esalq") Is Nothing) Then
                    ViewState.Item("id_situacao_analise_esalq") = Request("id_situacao_analise_esalq")
                Else
                    ViewState.Item("id_situacao_analise_esalq") = String.Empty
                End If

                If (Not Request("txt_dt_coleta") Is Nothing) Then
                    ViewState.Item("txt_dt_coleta") = Request("txt_dt_coleta")
                Else
                    ViewState.Item("txt_dt_coleta") = String.Empty
                End If

                If (Not Request("id_tipo_coleta_analise_esalq") Is Nothing) Then
                    ViewState.Item("id_tipo_coleta_analise_esalq") = Request("id_tipo_coleta_analise_esalq")
                Else
                    ViewState.Item("id_tipo_coleta_analise_esalq") = String.Empty
                End If

                If (Not Request("id_aprovacao_analise_esalq") Is Nothing) Then
                    ViewState.Item("id_aprovacao_analise_esalq") = Request("id_aprovacao_analise_esalq")
                Else
                    ViewState.Item("id_aprovacao_analise_esalq") = String.Empty
                End If


                Dim analiseesalq As New AnaliseEsalq

                If Trim(ViewState.Item("id_propriedade")) <> "" Then
                    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
                End If
                analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
                If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
                End If

                If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then
                    analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta_ini").ToString
                    analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta_fim").ToString
                Else
                    analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString
                    analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString
                End If

                analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq").ToString)

                analiseesalq.cd_analise_esalq = Convert.ToInt32(ViewState.Item("cd_analise_esalq").ToString())
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

                analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq").ToString)
               
                analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq").ToString) 'fran 26/07/2016

                Dim dsAnaliseEsalc As DataSet = analiseesalq.getAnaliseEsalqByFilters()

                gridResults.DataSource = Helper.getDataView(dsAnaliseEsalc.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()
                
                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "AnaliseEsalqConciliacao" & ".xls")
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
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_consistencias As Label = CType(e.Row.FindControl("lbl_consistencias"), Label)
            Dim lbl_detalhes As Label = CType(e.Row.FindControl("lbl_detalhes"), Label)
            Dim lbl_id_analise_esalq As Label = CType(e.Row.FindControl("lbl_id_analise_esalq"), Label)

            Dim analiseesalq As New AnaliseEsalq
            Dim dsAnaliseEsalqConsistencias As DataSet
            analiseesalq.id_analise_esalq = lbl_id_analise_esalq.Text
            dsAnaliseEsalqConsistencias = analiseesalq.getAnalisesEsalqConsistencias()
            If dsAnaliseEsalqConsistencias.Tables(0).Rows.Count > 1 Then
                lbl_consistencias.Visible = False
                lbl_detalhes.Visible = True
            End If


        End If
    End Sub

End Class
