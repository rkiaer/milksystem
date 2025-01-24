
Partial Class header
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Page.IsPostBack) Then

            Dim customPage As New RK.PageTools.CustomPage(HttpContext.Current, False)
            lbl_usuario.Text = MenuTools.getUserFullName(customPage.userId)

        End If

    End Sub

End Class
