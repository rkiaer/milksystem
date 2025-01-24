Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_usuario_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridResults.Rows.Count.ToString + 1 < 65536 Then

            Try


                If (Not Request("id_tipo_usuario") Is Nothing) Then
                    ViewState.Item("id_tipo_usuario") = Request("id_tipo_usuario")
                Else
                    ViewState.Item("id_tipo_usuario") = String.Empty
                End If

                If (Not Request("ds_login") Is Nothing) Then
                    ViewState.Item("ds_login") = Request("ds_login")
                Else
                    ViewState.Item("ds_login") = String.Empty
                End If

                If (Not Request("nm_usuario") Is Nothing) Then
                    ViewState.Item("nm_usuario") = Request("nm_usuario")
                Else
                    ViewState.Item("nm_usuario") = String.Empty
                End If

                If (Not Request("id_situacao") Is Nothing) Then
                    ViewState.Item("id_situacao") = Request("id_situacao")
                Else
                    ViewState.Item("id_situacao") = "0"
                End If

                Dim usuario As New Usuario

                usuario.ds_login = ViewState.Item("ds_login").ToString()
                usuario.nm_usuario = ViewState.Item("nm_usuario").ToString()
                usuario.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

                If Not (ViewState.Item("id_tipo_usuario").ToString.Equals(String.Empty)) Then
                    usuario.id_tipo_usuario = Convert.ToInt32(ViewState.Item("id_tipo_usuario"))
                End If


                Dim dsUsuario As DataSet = usuario.getUsuarioByFilters()


                gridResults.DataSource = Helper.getDataView(dsUsuario.Tables(0), "")
                gridResults.AllowPaging = False
                gridResults.DataBind()

                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    If gridResults.Rows.Count > 0 Then
                        Dim tw As New StringWriter()
                        Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                        Dim frm As HtmlForm = New HtmlForm()
                        Response.ContentType = "application/vnd.ms-excel"
                        Response.AddHeader("content-disposition", "attachment;filename=" & "MilkSystem_Usuarios" & ".xls")
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
