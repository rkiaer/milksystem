Imports Danone.MilkSystem.Business
Imports System.Data
Imports RK.GlobalTools.Tools


Partial Class frm_usuario_senha
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_usuario.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_usuario") Is Nothing) Then
                ViewState.Item("id_usuario") = Request("id_usuario")
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_usuario As Int32 = Convert.ToInt32(ViewState.Item("id_usuario").ToString)
            Dim usuario As New Usuario(id_usuario)

            lbl_login.Text = usuario.ds_login
            lbl_usuario.Text = usuario.nm_usuario
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_usuario.aspx?id_usuario=" + ViewState.Item("id_usuario").ToString)


    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("frm_usuario.aspx?id_usuario=" + ViewState.Item("id_usuario").ToString)

    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub
    Private Sub updateData()

        Try

            Dim usuario As New Usuario()

            usuario.pw_senha = EncryptString(Trim(txt_nova_senha.Text))

            If Page.IsValid Then

                usuario.id_usuario = Convert.ToInt32(ViewState.Item("id_usuario"))
                usuario.updateUsuarioSenha()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'açlterar
                usuariolog.id_menu_item = 60
                usuariolog.ds_nm_processo = "Usuário - Senha Tipo Banco"
                usuariolog.id_nr_processo = usuario.id_usuario
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango


                messageControl.Alert("Senha alterada com sucesso.")
                'Response.Redirect("frm_usuario.aspx?id_usuario=" + ViewState.Item("id_usuario").ToString)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_confirma_senha_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_confirma_senha.ServerValidate
        If Trim(txt_nova_senha.Text) <> Trim(txt_confirma_senha.Text) Then
            args.IsValid = False
            messageControl.Alert("O campo Confirma Senha deve ter o mesmo conteúdo do campo Nova Senha.")
        Else
            args.IsValid = True
        End If
    End Sub
End Class
