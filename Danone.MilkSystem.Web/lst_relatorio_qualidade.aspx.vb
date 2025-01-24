Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data


Partial Class lst_relatorio_qualidade

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_qualidade.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub




    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        Try


            ViewState.Item("dt_referencia") = "01/" + dt_referencia.Text
            Response.Redirect("frm_relatorio_qualidade.aspx?dt_referencia=" + ViewState.Item("dt_referencia").ToString())


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
 End Class
