Imports Danone.MilkSystem.Business

Partial Class frm_treinamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_treinamento.aspx")
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

            If Not (Request("id_treinamento") Is Nothing) Then
                ViewState.Item("id_treinamento") = Request("id_treinamento")
                lbl_cd_treinamento.Visible = True
                txt_cd_treinamento.Visible = True

                loadData()
            Else
                lbl_cd_treinamento.Visible = False
                txt_cd_treinamento.Visible = False
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_treinamento As Int32 = Convert.ToInt32(ViewState.Item("id_treinamento"))
            Dim treinamento As New Treinamento(id_treinamento)

            txt_cd_treinamento.Text = treinamento.id_treinamento

            txt_nm_treinamento.Text = treinamento.nm_treinamento

            txt_carga_horaria.Text = treinamento.nr_carga_horaria
            txt_pre_requisitos.Text = treinamento.ds_pre_requisitos
            txt_descricao.Text = treinamento.ds_descricao


            If (treinamento.id_situacao > 0) Then
                cbo_situacao.SelectedValue = treinamento.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = treinamento.id_modificador.ToString()
            lbl_dt_modificacao.Text = treinamento.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim treinamento As New Treinamento()


            treinamento.nm_treinamento = txt_nm_treinamento.Text


            If Not (txt_carga_horaria.Text.Trim.Equals(String.Empty)) Then
                treinamento.nr_carga_horaria = txt_carga_horaria.Text
            End If

            treinamento.ds_pre_requisitos = txt_pre_requisitos.Text
            treinamento.ds_descricao = txt_descricao.Text


            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                treinamento.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If

            treinamento.id_modificador = Session("id_login")

            If Not (ViewState.Item("id_treinamento") Is Nothing) Then

                treinamento.id_treinamento = Convert.ToInt32(ViewState.Item("id_treinamento"))
                treinamento.updateTreinamento()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.id_menu_item = 6
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro alterado com sucesso.")

            Else

                ViewState.Item("id_treinamento") = treinamento.insertTreinamento()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'alteracao
                usuariolog.id_menu_item = 6
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro inserido com sucesso.")

            End If

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_treinamento.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_treinamento.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'fran 02/03/2009 i rls17
        Response.Redirect("frm_treinamento.aspx")
    End Sub
End Class
