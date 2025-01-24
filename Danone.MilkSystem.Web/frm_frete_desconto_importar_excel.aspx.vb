Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_frete_desconto_importar_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            If Not (Request("id_importacao_frete") Is Nothing) Then
                ViewState.Item("id_importacao") = Request("id_importacao_frete")
            End If


            Dim importacaofrete As New ImportacaoFrete
            importacaofrete.id_importacao = ViewState.Item("id_importacao")

            If Not (ViewState("id_importacao").ToString().Equals(String.Empty)) Then
                importacaofrete.id_importacao = Convert.ToInt32(ViewState.Item("id_importacao"))
                Dim dsimportacaolog As DataSet = importacaofrete.getImportacaoFreteByFilters()
                Try

                    gridResults.DataSource = Helper.getDataView(dsimportacaolog.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.AllowPaging = False
                    gridResults.DataBind()

                    If gridResults.Rows.Count.ToString + 1 < 65536 Then
                        If gridResults.Rows.Count > 0 Then
                            Dim tw As New StringWriter()
                            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                            Dim frm As HtmlForm = New HtmlForm()
                            Response.ContentType = "application/vnd.ms-excel"
                            Response.AddHeader("content-disposition", "attachment;filename=" & "LogImportarDescontosFrete" & ".xls")
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
            Else
                messageControl.Alert("Problemas na passagem de parâmetros: o número de execução da importação não existe!")

            End If
        End If
    End Sub

End Class
