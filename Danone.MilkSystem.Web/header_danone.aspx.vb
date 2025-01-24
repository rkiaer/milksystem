Imports Danone.MilkSystem.Business

Partial Class header_danone
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' 25/10/2008 - Controle de Acessos - i
            Dim usuario As New Usuario(Convert.ToInt32(Session("id_login")))

            lbl_usuario.Text = usuario.nm_usuario + ", bem vindo ao sistema Evolution!"
            ' 25/10/2008 - Controle de Acessos - f
        End If
    End Sub

End Class
