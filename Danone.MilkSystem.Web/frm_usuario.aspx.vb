Imports Danone.MilkSystem.Business
Imports System.Data
Imports RK.GlobalTools.Tools

Partial Class frm_usuario
    Inherits Page

    Private customPage As RK.PageTools.CustomPage
    'Private acesso As RK.GlobalTools

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_usuario.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try



            Dim tipousuario As New TipoUsuario

            cbo_tipo_usuario.DataSource = tipousuario.getTipoUsuariosByFilters()
            cbo_tipo_usuario.DataTextField = "nm_tipo_usuario"
            cbo_tipo_usuario.DataValueField = "id_tipo_usuario"
            cbo_tipo_usuario.DataBind()
            cbo_tipo_usuario.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_usuario") Is Nothing) Then

                ViewState.Item("id_usuario") = Request("id_usuario")
                loadData()
            Else
                txt_senha.Visible = True
                txt_confirma_senha.Visible = True
                rqf_senha.Visible = True
                rqf_confirma_senha.Visible = True
                cv_confirma_senha.Visible = True
                lk_usuario_grupo.Visible = False
                lk_usuario_senha.Visible = False
                senha.Visible = True
                confirma_senha.Visible = True

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub




    Private Sub loadData()

        Try
            txt_senha.Visible = False
            txt_confirma_senha.Visible = False
            rqf_senha.Visible = False
            rqf_confirma_senha.Visible = False
            cv_confirma_senha.Visible = False
            lk_usuario_grupo.Visible = True
            lk_usuario_senha.Visible = True
            senha.Visible = False
            confirma_senha.Visible = False


            Dim id_usuario As Int32 = Convert.ToInt32(ViewState.Item("id_usuario"))
            Dim usuario As New Usuario(id_usuario)

            txt_login.Text = usuario.ds_login
            txt_nm_usuario.Text = usuario.nm_usuario

            ViewState.Item("idsituacaobanco") = usuario.id_situacao 'fran 17/12/2020 (grava a situação do carregamento para verificar se ativou ou desativou usuario)

            If (usuario.id_tipo_usuario > 0) Then
                cbo_tipo_usuario.SelectedValue = usuario.id_tipo_usuario.ToString()
            End If

            'txt_senha.Text = usuario.pw_senha
            'txt_confirma_senha.Text = usuario.pw_senha
            txt_dominio.Text = usuario.ds_dominio
            txt_email.Text = usuario.ds_email
            txt_depto.Text = usuario.ds_depto
            txt_telefone.Text = usuario.ds_telefone
            txt_cpf.Text = usuario.cd_cpf

            If (usuario.id_situacao > 0) Then
                cbo_situacao.SelectedValue = usuario.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = usuario.id_modificador.ToString()
            lbl_dt_modificacao.Text = usuario.dt_modificacao.ToString()




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim usuario As New Usuario()

            usuario.ds_login = txt_login.Text
            usuario.nm_usuario = txt_nm_usuario.Text

            If Not (cbo_tipo_usuario.SelectedValue.Trim().Equals(String.Empty)) Then
                usuario.id_tipo_usuario = Convert.ToInt32(cbo_tipo_usuario.SelectedValue)
            End If

            usuario.pw_senha = EncryptString(Trim(txt_senha.Text))
            usuario.ds_dominio = txt_dominio.Text
            usuario.ds_email = txt_email.Text
            usuario.ds_depto = txt_depto.Text
            usuario.ds_telefone = txt_telefone.Text
            usuario.cd_cpf = txt_cpf.Text

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                usuario.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If
            usuario.id_modificador = Session("id_login")

            If Page.IsValid Then
                If Not (ViewState.Item("id_usuario") Is Nothing) Then

                    usuario.id_usuario = Convert.ToInt32(ViewState.Item("id_usuario"))
                    usuario.updateUsuario()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 60
                    usuariolog.id_nr_processo = usuario.id_usuario
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_usuario") = usuario.insertUsuario()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inserir
                    usuariolog.id_menu_item = 60
                    usuariolog.id_nr_processo = ViewState.Item("id_usuario").ToString
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro inserido com sucesso.")

                End If

                loadData()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_usuario.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_usuario.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Public Sub New()

    End Sub

    Protected Sub RequiredFieldValidator1_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles RequiredFieldValidator1.DataBinding

    End Sub

    Protected Sub RequiredFieldValidator1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles RequiredFieldValidator1.Load
    End Sub




    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_usuario.aspx")
    End Sub


    Protected Sub lk_usuario_grupo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_usuario_grupo.Click
        Response.Redirect("frm_usuario_grupo.aspx?id_usuario=" + ViewState.Item("id_usuario").ToString())
    End Sub

    Protected Sub cv_confirma_senha_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_confirma_senha.ServerValidate
        If Trim(txt_senha.Text) <> Trim(txt_confirma_senha.Text) Then
            args.IsValid = False
            messageControl.Alert("O campo Confirma Senha deve ter o mesmo conteúdo do campo Senha.")
        Else
            args.IsValid = True
        End If

    End Sub

    Protected Sub lk_usuario_senha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_usuario_senha.Click
        Response.Redirect("frm_usuario_senha.aspx?id_usuario=" + ViewState.Item("id_usuario").ToString())
    End Sub

    Protected Sub cbo_tipo_usuario_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_usuario.TextChanged
        If cbo_tipo_usuario.SelectedValue = "1" Then  ' Se usuário LDAP  (27/10/2008)
            txt_senha.Enabled = False
            txt_confirma_senha.Enabled = False
            rqf_senha.Visible = False
            rqf_confirma_senha.Visible = False
            cv_confirma_senha.Visible = False
        Else
            txt_senha.Enabled = True
            txt_confirma_senha.Enabled = True
            rqf_senha.Visible = True
            rqf_confirma_senha.Visible = True
            cv_confirma_senha.Visible = True
        End If
    End Sub
End Class
