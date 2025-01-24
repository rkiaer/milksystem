Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail

Partial Class lst_util_romaneio_estabelecimento


    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_util_romaneio_estabelecimento.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 77
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try


            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()
        If Page.IsValid Then

            Try
                Dim utilitario As New Utilitario
                Dim lmsg As String

                utilitario.id_romaneio = Convert.ToInt32(txt_nr_romaneio.Text.Trim)
                utilitario.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                utilitario.id_modificador = Session("id_login")
                utilitario.alterarRomaneioEstabelecimento()
                lmsg = "Execução da troca do estabelecimento do romaneio " + txt_nr_romaneio.Text + " realizada com sucesso!"
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
            usuariolog.id_menu_item = 77
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 
            loadData()
        End If
    End Sub
End Class
