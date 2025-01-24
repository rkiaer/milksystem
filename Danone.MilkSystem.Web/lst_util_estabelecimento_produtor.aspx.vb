Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail

Partial Class lst_util_estabelecimento_produtor


    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_util_estabelecimento_produtor.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 74
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
            If Convert.ToInt32(ViewState.Item("id_produtor")) <> 0 Then
                Try
                    Dim utilitario As New Utilitario
                    Dim lmsg As String

                    utilitario.id_pessoa = Convert.ToInt32(ViewState.Item("id_produtor"))
                    utilitario.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                    utilitario.id_modificador = Session("id_login")
                    utilitario.alterarEstabelecimentoProdutor()
                    lmsg = "Execução da alteração do estabelecimento do produtor " + txt_cd_produtor.Text + " e suas propriedades realizada com sucesso!"
                    messageControl.Alert(lmsg)

                Catch ex As Exception
                    messageControl.Alert(ex.Message)
                End Try
            End If
        End If
    End Sub


    Protected Sub btn_executar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_executar.Click
        If Page.IsValid Then

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 6 'processo
            usuariolog.id_menu_item = 74
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadData()
        End If

    End Sub
    Protected Sub cv_produtor_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_produtor.ServerValidate
        Try
            Dim lidpessoa As Int32 = Convert.ToInt32(ViewState.Item("id_produtor"))
            If lidpessoa > 0 Then
                args.IsValid = True
            Else
                args.IsValid = False
                messageControl.Alert("Produtor não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_produtor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_produtor.TextChanged
        Dim lid_produtor As Int32
        If Not txt_cd_produtor.Text.Equals(String.Empty) Then
            lid_produtor = validarProdutor()

            If lid_produtor > 0 Then
                Dim produtor As New Pessoa(lid_produtor)
                Dim estabel As New Estabelecimento(produtor.id_estabelecimento)
                lbl_estabelecimento_atual.Visible = True
                lbl_estabelecimento_atual.Text = estabel.cd_estabelecimento + " - " + estabel.nm_estabelecimento
                lbl_produtor.Visible = True
                lbl_produtor.Text = produtor.nm_pessoa
            Else
                lbl_produtor.Visible = True
                lbl_produtor.Text = "Produtor não cadastrado."
                lbl_estabelecimento_atual.Text = String.Empty
                lbl_estabelecimento_atual.Visible = False
            End If
        Else
            lid_produtor = 0
            lbl_produtor.Visible = True
            lbl_produtor.Text = "Produtor não cadastrado."
            lbl_estabelecimento_atual.Text = String.Empty
            lbl_estabelecimento_atual.Visible = False
        End If

        ViewState.Item("id_produtor") = lid_produtor.ToString


    End Sub
    Private Function validarProdutor() As Int32

        Try
            Dim pessoa As New Pessoa()

            pessoa.cd_pessoa = Me.txt_cd_produtor.Text.Trim

            validarProdutor = pessoa.validarProdutor()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

End Class
