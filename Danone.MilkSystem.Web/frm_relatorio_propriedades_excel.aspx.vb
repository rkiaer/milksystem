Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_relatorio_propriedades_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            Try

                If (Not Request("id_pessoa") Is Nothing) Then
                    ViewState.Item("id_pessoa") = Request("id_pessoa")
                Else
                    ViewState.Item("id_pessoa") = String.Empty
                End If
                If (Not Request("cd_pessoa") Is Nothing) Then
                    ViewState.Item("cd_pessoa") = Request("cd_pessoa")
                Else
                    ViewState.Item("cd_pessoa") = String.Empty
                End If
                If (Not Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                Else
                    ViewState.Item("id_estabelecimento") = String.Empty
                End If
                If (Not Request("id_propriedade") Is Nothing) Then
                    ViewState.Item("id_propriedade") = Request("id_propriedade")
                Else
                    ViewState.Item("id_propriedade") = String.Empty
                End If
                If (Not Request("id_grupo") Is Nothing) Then
                    ViewState.Item("id_grupo") = Request("id_grupo")
                Else
                    ViewState.Item("id_grupo") = String.Empty
                End If
                If (Not Request("id_situacao") Is Nothing) Then
                    ViewState.Item("id_situacao") = Request("id_situacao")
                Else
                    ViewState.Item("id_situacao") = String.Empty
                End If



                'chamado 1576 - 02/08/2012 - Mirella i
                If Not (Request("cd_codigo_sap") Is Nothing) Then

                    ViewState.Item("cd_codigo_sap") = Request("cd_codigo_sap")
                Else
                    ViewState.Item("cd_codigo_sap") = String.Empty
                End If
                'chamado 1576 - 02/08/2012 - Mirella f

                Dim propriedade As New Propriedade
                If Not (ViewState.Item("id_propriedade").Equals(String.Empty)) Then
                    propriedade.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
                Else
                    propriedade.id_propriedade = 0
                End If
                If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                    propriedade.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
                Else
                    propriedade.id_pessoa = 0
                End If
                propriedade.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                propriedade.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo"))
                propriedade.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
                propriedade.cd_pessoa = ViewState.Item("cd_pessoa").ToString

                'chamado 1576 - 01/08/2012 - Mirella i
                If Not (ViewState("cd_codigo_sap").ToString().Equals(String.Empty)) Then
                    propriedade.cd_codigo_SAP = Convert.ToString(ViewState.Item("cd_codigo_sap"))
                End If
                'chamado 1576 - 01/08/2012 - Mirella f

                If (ViewState.Item("grupo") = 1) Then

                    Dim dsPropriedade As DataSet = propriedade.getRelatorioPropriedade()
                    If (dsPropriedade.Tables(0).Rows.Count > 0) Then
                        gridResults.Columns(3).HeaderText = "Cód. Produtor"
                        gridResults.Columns(4).HeaderText = "Nome Produtor"
                        gridResults.Visible = True
                        gridResults.DataSource = Helper.getDataView(dsPropriedade.Tables(0), ViewState.Item("sortExpression"))
                        gridResults.DataBind()
                    Else
                        gridResults.Visible = False

                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

                    End If
                ElseIf (ViewState.Item("emitente") = 4) Then

                    Dim dsPropriedade As DataSet = propriedade.getRelatorioPropriedade()
                    If (dsPropriedade.Tables(0).Rows.Count > 0) Then
                        gridResults.Columns(3).HeaderText = "Cód. Cooperativa"
                        gridResults.Columns(4).HeaderText = "Nome Cooperativa"
                        gridResults.Visible = True
                        gridResults.DataSource = Helper.getDataView(dsPropriedade.Tables(0), ViewState.Item("sortExpression"))
                        gridResults.DataBind()
                    End If
                Else
                    Dim dsPropriedade As DataSet = propriedade.getRelatorioPropriedade()
                    If (dsPropriedade.Tables(0).Rows.Count > 0) Then
                        gridResults.Visible = True
                        gridResults.DataSource = Helper.getDataView(dsPropriedade.Tables(0), ViewState.Item("sortExpression"))
                        gridResults.DataBind()
                    Else
                        gridResults.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If
                End If

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "Relatorio de Proriedades" & ".xls")
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
                    messageControl.Alert("A planilha possui muitas linhas, não é possível exportar para o Excel")

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

End Class
