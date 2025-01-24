Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_mensagem
    Inherits Page

    Private customPage As RK.PageTools.CustomPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub
    Private Sub loadDetails()

        Try

            If Not (Request("msg") Is Nothing) Then
                lbl_mensagem.Text = Request("msg")
            Else
                lbl_mensagem.Text = "MENSAGEM NÃO CADASTRADA"

            End If

            If Not Request("tela") Is Nothing Then
                ViewState.Item("proximatela") = Request("tela")
            End If



        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try
    End Sub


    Protected Sub btn_msgok_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_msgok.Click
        Response.Redirect(ViewState.Item("proximatela").ToString)
    End Sub
End Class
