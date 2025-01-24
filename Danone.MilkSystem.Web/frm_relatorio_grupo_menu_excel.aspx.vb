Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_relatorio_grupo_menu_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            Try


                If (Not Request("id_grupo") Is Nothing) Then
                    ViewState.Item("id_grupo") = Request("id_grupo")
                Else
                    ViewState.Item("id_grupo") = "0"
                End If
                If (Not Request("id_menu") Is Nothing) Then
                    ViewState.Item("id_menu") = Request("id_menu")
                Else
                    ViewState.Item("id_menu") = "0"
                End If
                If (Not Request("id_menu_item") Is Nothing) Then
                    ViewState.Item("id_menu_item") = Request("id_menu_item")
                Else
                    ViewState.Item("id_menu_item") = "0"
                End If

                Dim grupomenu As New GrupoAcesso

                grupomenu.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString())
                grupomenu.id_menu = Convert.ToInt32(ViewState.Item("id_menu").ToString())
                grupomenu.id_menu_item = Convert.ToInt32(ViewState.Item("id_menu_item").ToString())

                Dim dsgrupo As DataSet = grupomenu.getRelatorioGruposMenus


                gridResults.DataSource = Helper.getDataView(dsgrupo.Tables(0), "")
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_GruposMenus" & ".xls")
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

End Class
