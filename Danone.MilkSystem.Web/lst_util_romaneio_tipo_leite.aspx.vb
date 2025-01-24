Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail

Partial Class lst_util_romaneio_tipo_leite


    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_util_romaneio_tipo_leite.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 78
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try


            Dim item As New Item
            cbo_id_item.DataSource = item.getItensByFilters()
            cbo_id_item.DataTextField = "nm_item"
            cbo_id_item.DataValueField = "id_item"
            cbo_id_item.DataBind()
            cbo_id_item.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


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
                utilitario.id_item = Convert.ToInt32(cbo_id_item.SelectedValue)
                utilitario.id_modificador = Session("id_login")
                utilitario.alterarRomaneioTipoLeite()
                lmsg = "Execução da troca do tipo de leite do romaneio " + txt_nr_romaneio.Text + " realizada com sucesso!"
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
            usuariolog.id_menu_item = 78
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadData()
        End If
    End Sub
End Class
