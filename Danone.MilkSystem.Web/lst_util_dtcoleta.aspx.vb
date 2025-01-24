Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail

Partial Class lst_util_dtcoleta


    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_util_dt_coleta.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 73
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

        End If

    End Sub



    Private Sub loadData()
        If Page.IsValid Then

            Try
                Dim utilitario As New Utilitario
                Dim lmsg As String

                utilitario.nr_caderneta = Convert.ToInt32(txt_nr_caderneta.Text.Trim)
                utilitario.dt_coleta_de = txt_dt_coleta_de.Text
                utilitario.dt_coleta_para = txt_dt_coleta_para.Text
                utilitario.dt_referencia = String.Concat("01/", Right(txt_dt_coleta_para.Text.Trim, 7))

                utilitario.alterarDtColeta()
                lmsg = "Execução da alteração da Data de Coleta " + txt_dt_coleta_de.Text + " para Data de Coleta " + txt_dt_coleta_para.Text + " da Caderneta informada realizada com sucesso!"
                messageControl.Alert(lmsg)

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub


    Protected Sub btn_executar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_executar.Click
        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 6 'processo
        usuariolog.id_menu_item = 73
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log

        loadData()
    End Sub
End Class
