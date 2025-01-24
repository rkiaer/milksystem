Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail

Partial Class lst_util_romaneio_reabrir_analise


    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_util_romaneio_reabrir_analise.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 79
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

        End If

    End Sub



    Private Sub loadData()
        If Page.IsValid Then

            Try
                Dim romaneio As New Romaneio
                Dim lmsg As String

                romaneio.id_romaneio = Convert.ToInt32(txt_nr_romaneio.Text.Trim)
                Dim dsromaneio As DataSet = romaneio.getRomaneioByFilters
                'Se exiate romaneio
                If dsromaneio.Tables(0).Rows.Count > 0 Then
                    'se já está fechado
                    If dsromaneio.Tables(0).Rows(0).Item("id_st_romaneio") = 4 Then
                        lmsg = "O romaneio " + romaneio.id_romaneio.ToString + " já foi fechado! Os registros de análise não podem ser reabertos!"
                    Else
                        'se pode reabrir romaneio
                        Dim utilitario As New Utilitario
                        utilitario.id_romaneio = Convert.ToInt32(txt_nr_romaneio.Text.Trim)
                        utilitario.id_modificador = Session("id_login")
                        utilitario.reabrirRegistroAnaliseRomaneio()
                        lmsg = "Execução da reabertura dos registros de análise do romaneio " + txt_nr_romaneio.Text + " realizada com sucesso!"
                    End If
                Else
                    lmsg = "O romaneio de número " + romaneio.id_romaneio.ToString + " não existe nos cadastros!"
                End If

                messageControl.Alert(lmsg)

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub


    Protected Sub btn_executar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_executar.Click
        If Page.IsValid Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 6 'processo
            usuariolog.id_menu_item = 79
            usuariolog.id_nr_processo = txt_nr_romaneio.Text
            usuariolog.nm_nr_processo = txt_nr_romaneio.Text
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadData()
        End If
    End Sub
End Class
