Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_central_tabela_precos_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then


            If Not (Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            End If

            If Not (Request("id_pessoa") Is Nothing) Then
                ViewState.Item("id_pessoa") = Request("id_pessoa")
            End If

            If Not (Request("dt_inicio") Is Nothing) Then
                ViewState.Item("dt_inicio") = Request("dt_inicio")
            End If
            If Not (Request("dt_fim") Is Nothing) Then
                ViewState.Item("dt_fim") = Request("dt_fim")
            End If

            If Not (Request("cd_pessoa") Is Nothing) Then
                ViewState.Item("cd_pessoa") = Request("cd_pessoa")
            End If
            If Not (Request("id_item") Is Nothing) Then
                ViewState.Item("id_item") = Request("id_item")
            End If
            If Not (Request("cd_item") Is Nothing) Then
                ViewState.Item("cd_item") = Request("cd_item")
            End If

            Dim tabelaprecos As New TabelaPrecos

            If Not (ViewState.Item("id_estabelecimento").Equals(String.Empty)) Then
                tabelaprecos.id_estabelecimento = ViewState.Item("id_estabelecimento")
            End If

            If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                tabelaprecos.id_fornecedor = ViewState.Item("id_pessoa")
            End If

            If Not (ViewState.Item("id_item").Equals(String.Empty)) Then
                tabelaprecos.id_item = ViewState.Item("id_item")
            End If

            If Not (ViewState.Item("dt_inicio").Equals(String.Empty)) Then
                tabelaprecos.dt_inicio = ViewState.Item("dt_inicio")
            End If

            If Not (ViewState.Item("dt_fim").Equals(String.Empty)) Then
                tabelaprecos.dt_fim = ViewState.Item("dt_fim")
            End If

            If Not (ViewState.Item("cd_item").Equals(String.Empty)) Then
                tabelaprecos.cd_item = ViewState.Item("cd_item")
            End If

            If Not (ViewState.Item("cd_pessoa").Equals(String.Empty)) Then
                tabelaprecos.cd_fornecedor = ViewState.Item("cd_pessoa")
            End If
            tabelaprecos.id_situacao = 1
            Dim dsTabelaPrecos As DataSet = tabelaprecos.getCentralTabelaPrecosByFilters()
            ViewState.Item("sortExpression") = "cd_fornecedor desc ,  dt_cotacao desc"
            Try
                gridResults.DataSource = Helper.getDataView(dsTabelaPrecos.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_TabelaPrecos" & ".xls")
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
       
    End Sub
End Class
