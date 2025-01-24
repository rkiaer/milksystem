Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_linha_exportar
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try

            If gridResults.Rows.Count.ToString + 1 < 65536 Then

                If Not (Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                End If

                If Not (Request("id_situacao") Is Nothing) Then
                    ViewState.Item("id_situacao") = Request("id_situacao")
                End If
                
                Dim propriedade As New Propriedade

                If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                    propriedade.id_estabelecimento = Convert.ToString(ViewState.Item("id_estabelecimento").ToString)
                End If
                If Not (ViewState("id_situacao").ToString().Equals(String.Empty)) Then
                    propriedade.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString)
                End If


                Dim dspropriedadeexportar As DataSet = propriedade.getPropriedadeRotasExportarExcel


                gridResults.DataSource = Helper.getDataView(dspropriedadeexportar.Tables(0), ViewState.Item("sortExpression"))
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "CREATION" & ".xls")
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


            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

End Class
