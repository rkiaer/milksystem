Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_grupo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_grupo.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_grupo") Is Nothing) Then

                ViewState.Item("id_grupo") = Request("id_grupo")
                loadData()
            Else
                lk_grupo_acesso.Enabled = False  ' 29/10/2008 Só permite acesso depois de incluir o Grupo

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub




    Private Sub loadData()

        Try


            Dim id_grupo As Int32 = Convert.ToInt32(ViewState.Item("id_grupo"))
            Dim grupo As New GrupoCadastro(id_grupo)


            txt_nm_grupo.Text = grupo.nm_grupo


            If (grupo.id_situacao > 0) Then
                cbo_situacao.SelectedValue = grupo.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = grupo.id_modificador.ToString()
            lbl_dt_modificacao.Text = grupo.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim grupo As New GrupoCadastro

            grupo.nm_grupo = txt_nm_grupo.Text

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                grupo.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If
            grupo.id_modificador = Session("id_login")

            If Page.IsValid Then
                If Not (ViewState.Item("id_grupo") Is Nothing) Then

                    grupo.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo"))
                    grupo.updateGrupo()

                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 59
                    usuariolog.id_nr_processo = ViewState.Item("id_grupo")
                    usuariolog.nm_nr_processo = grupo.nm_grupo

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_grupo") = grupo.insertGrupo()

                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 59
                    usuariolog.id_nr_processo = ViewState.Item("id_grupo")
                    usuariolog.nm_nr_processo = grupo.nm_grupo

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro inserido com sucesso.")
                    lk_grupo_acesso.Enabled = True

                End If

                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_grupo.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_grupo.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Public Sub New()

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_grupo.aspx")
    End Sub


    Protected Sub lk_grupo_acesso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_grupo_acesso.Click
        Response.Redirect("frm_grupo_acessos.aspx?id_grupo=" + ViewState.Item("id_grupo").ToString)
    End Sub

End Class
