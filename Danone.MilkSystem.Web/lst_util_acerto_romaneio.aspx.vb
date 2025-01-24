Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail

Partial Class lst_util_acerto_romaneio


    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_util_excluir_caderneta.aspx")

    End Sub



    Private Sub loadData()
        If Page.IsValid Then

            Try
                Dim utilitario As New Utilitario
                Dim lmsg As String

                utilitario.util_MontandoAdriCadernetasErradas()
                utilitario.util_AnaliseAcertoRomaneiosErrados()

                lmsg = "Análises e acertos finalizada com exito!"
                messageControl.Alert(lmsg)

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub


    Protected Sub btn_executar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_executar.Click
        loadData()
    End Sub
End Class
