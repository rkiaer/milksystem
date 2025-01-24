Imports Danone.MilkSystem.Business
Imports System.Data
Imports RK.GlobalTools.Tools


Partial Class frm_login
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_login.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            trNewPassword.Visible = False
            trConfirmPassword.Visible = False


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub lk_novoCadastro_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub btn_entrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_entrar.Click

        Dim pErrMsg As String = String.Empty
        Dim pErrDescr As String = String.Empty
        Dim senha As String
        senha = EncryptString(Trim(txt_senha.Text))
        'senha = DecryptString("YG6SsUug6Rzq39aaJpXjJFmy6++QLpK2")

        Dim usuario As New Usuario
        usuario.ds_login = Trim(txt_usuario.Text)

        'fran 07/12/2020 dango i
        Dim usuariolog As New UsuarioLog
        usuariolog.ds_login = usuario.ds_login
        usuariolog.ds_id_session = Session.SessionID.ToString()
        'fran 07/12/2020 dango f

        Dim dsUsuario As DataSet = usuario.getUsuarioByFilters()
        If dsUsuario.Tables(0).Rows.Count Then

            Session("id_login") = dsUsuario.Tables(0).Rows(0).Item("id_usuario").ToString
            Session("ds_login") = dsUsuario.Tables(0).Rows(0).Item("ds_login").ToString  ' 24/11/2008
            usuariolog.id_usuario = dsUsuario.Tables(0).Rows(0).Item("id_usuario").ToString 'usuario log fran 7/12/2020 

            If dsUsuario.Tables(0).Rows(0).Item("id_tipo_usuario") = 1 Then  'Se LDAP

                'If usuario.autentica("cluster", Trim(txt_usuario.Text), Trim(txt_senha.Text)) = False Then
                If usuario.autentica(Trim(txt_usuario.Text), Trim(txt_senha.Text), pErrMsg, pErrDescr) = False Then
                    'fran 07/12/2020 dango i
                    usuariolog.id_tipo_log = 7 ' tentativa de login
                    'fran 14/12/2024 i
                    usuariolog.nm_nr_processo = pErrDescr.ToString
                    usuariolog.ds_nm_processo = "LDAP " & pErrMsg.ToString
                    'fran 14/12/2024 f

                    usuariolog.insertUsuarioLog()
                    'fran 07/12/2020 dango f

                    messageControl.Alert("Usuário/senha inválido. " & usuariolog.ds_nm_processo)
                Else
                    'fran 07/12/2020 dango i
                    usuariolog.id_tipo_log = 1 'login
                    usuariolog.insertUsuarioLog()
                    'fran 07/12/2020 dango f

                    Response.Redirect("frameset.aspx")
                End If
            Else
                If senha = dsUsuario.Tables(0).Rows(0).Item("pw_senha") Then  'Se senha do Banco ok

                    ' Verifica se está alterando senha
                    If Trim(txt_newPassword.Text) <> "" Then
                        If Trim(txt_newPassword.Text) <> Trim(Me.txt_confirmPassword.Text) Then
                            'fran 07/12/2020 dango i
                            usuariolog.id_tipo_log = 7 ' tentativa de login
                            'fran 14/12/2024 i
                            usuariolog.ds_nm_processo = "BANCO Alteração Senha Não Confere"
                            'fran 14/12/2024 f
                            usuariolog.insertUsuarioLog()
                            'fran 07/12/2020 dango f

                            messageControl.Alert("Confirmação de senha não confere com a nova senha.")
                        Else
                            usuario.id_usuario = dsUsuario.Tables(0).Rows(0).Item("id_usuario")
                            usuario.pw_senha = EncryptString(Trim(txt_newPassword.Text))
                            usuario.updateUsuarioSenha()

                            'fran 08/12/2020 i dango
                            usuariolog.id_tipo_log = 3 'açlterar
                            usuariolog.ds_nm_processo = "LOGIN - Senha Tipo Banco"
                            usuariolog.id_nr_processo = usuario.id_usuario
                            usuariolog.insertUsuarioLog()
                            'fran 08/12/2020 f dango

                            'fran 07/12/2020 dango i
                            usuariolog.id_tipo_log = 1 '  login
                            usuariolog.ds_nm_processo = ""
                            usuariolog.id_nr_processo = 0
                            usuariolog.insertUsuarioLog()
                            'fran 07/12/2020 dango f

                            Response.Redirect("frameset.aspx")
                        End If
                    Else
                        'fran 07/12/2020 dango i
                        usuariolog.id_tipo_log = 1 ' login
                        usuariolog.insertUsuarioLog()
                        'fran 07/12/2020 dango f

                        Response.Redirect("frameset.aspx")
                    End If
                Else
                    'fran 07/12/2020 dango i
                    usuariolog.id_tipo_log = 7 ' tentativa de login
                    'fran 14/12/2024 i
                    usuariolog.ds_nm_processo = "BANCO Senha Não Confere"
                    'fran 14/12/2024 f
                    usuariolog.insertUsuarioLog()
                    'fran 07/12/2020 dango f

                    messageControl.Alert("Usuário/senha inválido.")
                End If

            End If
        Else
            'fran 07/12/2020 dango i
            usuariolog.id_tipo_log = 7 'tentantiva de login
            usuariolog.ds_nm_processo = "Sem cadastro."
            usuariolog.insertUsuarioLog()
            'fran 07/12/2020 dango f
            messageControl.Alert("Usuário/senha inválido.")
        End If
    End Sub

    Protected Sub lk_alterar_senha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_alterar_senha.Click
        trNewPassword.Visible = True
        trConfirmPassword.Visible = True
    End Sub
End Class
