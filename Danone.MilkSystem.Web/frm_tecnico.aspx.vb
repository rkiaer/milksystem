Imports Danone.MilkSystem.Business

Partial Class frm_tecnico
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_tecnico.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

           

            Dim estado As New Estado

            cbo_estado.DataSource = estado.getEstadosByFilters()
            cbo_estado.DataTextField = "nm_estado"
            cbo_estado.DataValueField = "id_estado"
            cbo_estado.DataBind()
            cbo_estado.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_tecnico") Is Nothing) Then
                ViewState.Item("id_tecnico") = Request("id_tecnico")
                lbl_cd_tecnico.Visible = True
                txt_cd_tecnico.Visible = True

                loadData()
            Else
                lbl_cd_tecnico.Visible = False
                txt_cd_tecnico.Visible = False
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub cbo_estado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estado.SelectedIndexChanged

        If Not (cbo_estado.SelectedValue.Trim().Equals(String.Empty)) Then
            loadCidadesByEstado(Convert.ToInt32(cbo_estado.SelectedValue))
        Else
            cbo_cidade.Items.Clear()
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_cidade.Enabled = False
        End If

    End Sub

    Private Sub loadCidadesByEstado(ByVal id_estado As Int32)

        Try

            cbo_cidade.Enabled = True

            Dim cidade As New Cidade
            cidade.id_estado = id_estado

            cbo_cidade.DataSource = cidade.getCidadeByFilters()
            cbo_cidade.DataTextField = "nm_cidade"
            cbo_cidade.DataValueField = "id_cidade"
            cbo_cidade.DataBind()
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", "0"))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim id_tecnico As Int32 = Convert.ToInt32(ViewState.Item("id_tecnico"))
            Dim tecnico As New Tecnico(id_tecnico)

            txt_cd_tecnico.Text = tecnico.id_tecnico


            If Not (tecnico.st_categoria.Trim().Equals(String.Empty)) Then
                cbo_categoria.SelectedValue = tecnico.st_categoria
            End If

            txt_nm_tecnico.text = tecnico.nm_tecnico
            'fran 9/10/2009 i chamado 477
            txt_nm_abreviado.Text = tecnico.nm_abreviado

            txt_rg.Text = tecnico.cd_rg
            txt_orgao_emissor.Text = tecnico.cd_orgao_emissor
            txt_cpf.Text = tecnico.cd_cpf
            txt_cpf.Enabled = False

            If Not (tecnico.dt_nascimento Is Nothing) Then
                txt_dt_nascimento.Text = DateTime.Parse(tecnico.dt_nascimento).ToString("dd/MM/yyyy")
            End If

            txt_endereco.Text = tecnico.ds_endereco
            txt_numero.Text = tecnico.nr_endereco.ToString()
            txt_complemento.Text = tecnico.ds_complemento
            txt_bairro.Text = tecnico.ds_bairro

            If (tecnico.id_cidade > 0) Then
                loadCidadesByEstado(tecnico.id_estado)
                cbo_estado.SelectedValue = tecnico.id_estado.ToString()
                cbo_cidade.SelectedValue = tecnico.id_cidade.ToString()
            End If

            txt_cep.Text = tecnico.cd_cep
            txt_telefone1.Text = tecnico.ds_telefone_1
            txt_telefone2.Text = tecnico.ds_telefone_2
            txt_email.Text = tecnico.ds_email


            If (tecnico.id_situacao > 0) Then
                cbo_situacao.SelectedValue = tecnico.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = tecnico.id_modificador.ToString()
            lbl_dt_modificacao.Text = tecnico.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim tecnico As New Tecnico()

            'tecnico.id_tecnico = txt_cd_tecnico.Text

            If Not (cbo_categoria.SelectedValue.Trim().Equals(String.Empty)) Then
                tecnico.st_categoria = cbo_categoria.SelectedValue
            End If

            tecnico.nm_tecnico = txt_nm_tecnico.Text

            tecnico.cd_rg = txt_rg.Text
            tecnico.cd_orgao_emissor = txt_orgao_emissor.Text
            tecnico.cd_cpf = txt_cpf.Text
            tecnico.dt_nascimento = txt_dt_nascimento.Text

            tecnico.ds_endereco = txt_endereco.Text
            If Not (txt_numero.Text.Trim().Equals(String.Empty)) Then
                tecnico.nr_endereco = Convert.ToInt32(txt_numero.Text)
            End If
            tecnico.ds_complemento = txt_complemento.Text
            tecnico.ds_bairro = txt_bairro.Text

            If Not (cbo_cidade.SelectedValue.Trim().Equals(String.Empty)) Then
                tecnico.id_cidade = Convert.ToInt32(cbo_cidade.SelectedValue)
            End If

            tecnico.cd_cep = txt_cep.Text
            tecnico.ds_telefone_1 = txt_telefone1.Text
            tecnico.ds_telefone_2 = txt_telefone2.Text
            tecnico.ds_email = txt_email.Text

            'Fran 09/10/2009 i  chamado 477
            tecnico.nm_abreviado = txt_nm_abreviado.Text.Trim

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                tecnico.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If

            tecnico.id_modificador = Session("id_login")

            If Not (ViewState.Item("id_tecnico") Is Nothing) Then

                tecnico.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico"))
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.id_menu_item = 3
                usuariolog.id_nr_processo = ViewState.Item("id_tecnico").ToString
                usuariolog.nm_nr_processo = ViewState.Item("id_tecnico").ToString

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                tecnico.updateTecnico()
                messageControl.Alert("Registro alterado com sucesso.")

            Else

                ViewState.Item("id_tecnico") = tecnico.insertTecnico()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 3
                usuariolog.id_nr_processo = ViewState.Item("id_tecnico").ToString
                usuariolog.nm_nr_processo = ViewState.Item("id_tecnico").ToString

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
        Response.Redirect("lst_tecnico.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_tecnico.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub cbo_categoria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_categoria.Load

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_tecnico.aspx")
    End Sub
End Class
