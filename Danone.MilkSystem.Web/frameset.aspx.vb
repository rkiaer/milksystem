
Partial Class frameset
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("id_login") = "" Then
            Response.Redirect("AcessoNegado.htm")
        End If

    End Sub


End Class
