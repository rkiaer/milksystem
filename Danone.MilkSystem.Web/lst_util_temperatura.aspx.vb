Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_util_temperatura
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_executar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_executar.Click
        If Page.IsValid Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 6 'processo
            usuariolog.id_menu_item = 75
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadData()
        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_util_temperatura.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 75
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

        End If

    End Sub
    Private Sub loadData()

        Try
            Dim utilitario As New Utilitario

            utilitario.corrigirTemperatura()

            messageControl.Alert("Execução da correção da Temperatura realizada com sucesso!")

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

End Class
