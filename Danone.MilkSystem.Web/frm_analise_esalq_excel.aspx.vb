Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_analise_esalq_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try

            'BUSCA OS PARAMETROS
            ViewState.Item("dt_inicio") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
            ViewState.Item("id_estabelecimento") = String.Empty

            If Not (Request("txt_dt_coleta_ini") Is Nothing) Then
                If Not (Request("txt_dt_coleta_ini") Is Nothing) Then
                    ViewState.Item("txt_dt_coleta_ini") = Request("txt_dt_coleta_ini")
                End If
                If Not (Request("txt_dt_coleta_fim") Is Nothing) Then
                    ViewState.Item("txt_dt_coleta_fim") = Request("txt_dt_coleta_fim")
                End If
                If Not (Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                End If
                If Not (Request("id_pessoa") Is Nothing) Then
                    ViewState.Item("id_pessoa") = Request("id_pessoa")  '  
                End If
                If Not (Request("id_propriedade") Is Nothing) Then
                    ViewState.Item("id_propriedade") = Request("id_propriedade")  '  
                End If
                If Not (Request("cd_analise_esalq") Is Nothing) Then
                    ViewState.Item("cd_analise_esalq") = Request("cd_analise_esalq")  '  
                End If
                If Not (Request("id_situacao") Is Nothing) Then
                    ViewState.Item("id_situacao") = Request("id_situacao")  '  
                End If
                If Not (Request("id_cooperativa") Is Nothing) Then
                    ViewState.Item("id_cooperativa") = Request("id_cooperativa")  '  
                End If
                If Not (Request("id_grupo") Is Nothing) Then
                    ViewState.Item("id_grupo") = Request("id_grupo")  '  
                End If

                Dim analiseesalq As New AnaliseEsalq

                If Trim(ViewState.Item("id_propriedade")) <> "" Then
                    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
                End If
                analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
                analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta_ini").ToString
                analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta_fim").ToString
                analiseesalq.cd_analise_esalq = Convert.ToInt32(ViewState.Item("cd_analise_esalq").ToString())
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

                If Trim(ViewState.Item("id_pessoa")) <> "" Then
                    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
                End If
                If Trim(ViewState.Item("id_cooperativa")) <> "" Then
                    analiseesalq.id_cooperativa = Convert.ToInt32(ViewState.Item("id_cooperativa").ToString)
                End If

                Dim dsAnaliseEsalc As DataSet = analiseesalq.getAnaliseEsalqByFilters()
                If Trim(ViewState.Item("id_grupo").ToString) = "4" Then 'cooperativa
                    dsAnaliseEsalc = analiseesalq.getAnaliseEsalqCoopByFilters()
                End If

                If (dsAnaliseEsalc.Tables(0).Rows.Count > 0) Then
                    If Trim(ViewState.Item("id_grupo").ToString) = "4" Then 'cooperativa
                        gridResultsCoop.Visible = True
                        gridResultsCoop.DataSource = Helper.getDataView(dsAnaliseEsalc.Tables(0), ViewState.Item("sortExpression"))
                        gridResultsCoop.DataBind()

                    Else
                        gridResults.Visible = True
                        gridResults.DataSource = Helper.getDataView(dsAnaliseEsalc.Tables(0), ViewState.Item("sortExpression"))
                        gridResults.DataBind()

                    End If
                End If

                If Trim(ViewState.Item("id_grupo").ToString) = "4" Then 'cooperativa

                    gridResultsCoop.AllowPaging = False

                    If gridResultsCoop.Rows.Count.ToString + 1 < 65536 Then
                        If gridResultsCoop.Rows.Count > 0 Then
                            Dim tw As New StringWriter()
                            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                            Dim frm As HtmlForm = New HtmlForm()
                            Response.ContentType = "application/vnd.ms-excel"
                            'se cooperativa
                            Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_DadosAnalisesExternasCooperativa" & ".xls")
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

                        messageControl.Alert("Planilha possui muitas linhas (mais de 65000), não é possível exportar para o Excel")

                    End If


                Else
                    gridResults.AllowPaging = False

                    If gridResults.Rows.Count.ToString + 1 < 65536 Then
                        If gridResults.Rows.Count > 0 Then
                            Dim tw As New StringWriter()
                            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                            Dim frm As HtmlForm = New HtmlForm()
                            Response.ContentType = "application/vnd.ms-excel"
                            Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_DadosAnalisesExternasProdutor" & ".xls")
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

                        messageControl.Alert("Planilha possui muitas linhas (mais de 65000), não é possível exportar para o Excel")

                    End If
                End If
            Else 'sem parametros
                messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub




















End Class
