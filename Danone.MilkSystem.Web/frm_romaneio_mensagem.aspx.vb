Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_romaneio_mensagem
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        If ViewState.Item("id_transvase") = 0 Then
            If ViewState.Item("id_transit_point") = 0 Then
                Response.Redirect("frm_romaneio.aspx?id_romaneio=" + ViewState.Item("id_romaneio"))
            Else
                Response.Redirect("frm_romaneio_consulta.aspx?id_romaneio=" + ViewState.Item("id_romaneio"))

            End If
        Else
            Response.Redirect("frm_romaneio_consulta.aspx?id_romaneio=" + ViewState.Item("id_romaneio"))

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                'fran transit pont 
                If Not (Request("id_transit_point") Is Nothing) Then
                    ViewState.Item("id_transit_point") = Request("id_transit_point")
                Else
                    ViewState.Item("id_transit_point") = 0
                End If
                If Not (Request("nr_caderneta") Is Nothing) Then
                    ViewState.Item("nr_caderneta") = Request("nr_caderneta")

                End If
                If Not (Request("id_transvase") Is Nothing) Then
                    ViewState.Item("id_transvase") = Request("id_transvase")
                Else
                    ViewState.Item("id_transvase") = 0
                End If

                If ViewState.Item("id_transvase") = 0 Then
                    If ViewState.Item("id_transit_point") = 0 Then
                        Label1.Text = "O Romaneio para a caderneta " + ViewState.Item("nr_caderneta") + " foi aberto com o número " + ViewState.Item("id_romaneio") + ". Este número assegura o processo de abertura do romaneio. O cadastro do romaneio deve ser completado."
                    Else
                        Label1.Text = "O Romaneio para o TRANSIT POINT " + ViewState.Item("id_transit_point") + " foi aberto com o número " + ViewState.Item("id_romaneio") + ". Este número assegura o processo de abertura do romaneio."
                    End If
                Else
                    Label1.Text = "O Romaneio para o TRANSVASE " + ViewState.Item("id_transvase") + " foi aberto com o número " + ViewState.Item("id_romaneio") + ". Este número assegura o processo de abertura do romaneio."

                End If

            End If
        End If
    End Sub


End Class
