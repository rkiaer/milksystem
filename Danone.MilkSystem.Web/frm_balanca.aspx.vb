Imports Danone.MilkSystem.Business

Partial Class frm_balanca
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_balanca.aspx")
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


            Dim tipoPesagem As New TipoPesagem

            cbo_tipo_pesagem.DataSource = tipoPesagem.getTipoPesagemByFilters
            cbo_tipo_pesagem.DataTextField = "nm_tipo_pesagem"
            cbo_tipo_pesagem.DataValueField = "id_tipo_pesagem"
            cbo_tipo_pesagem.DataBind()
            cbo_tipo_pesagem.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            If Not (Request("id_balanca") Is Nothing) Then
                ViewState.Item("id_balanca") = Request("id_balanca")

                loadData()
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_balanca As Int32 = Convert.ToInt32(ViewState.Item("id_balanca"))
            Dim balanca As New Balanca(id_balanca)


            txt_nm_balanca.Text = balanca.nm_balanca
            txt_end_ip.Text = balanca.ds_end_ip
            txt_porta.Text = balanca.ds_porta
            cbo_estabelecimento.SelectedValue = balanca.id_estabelecimento
            cbo_tipo_pesagem.SelectedValue = balanca.id_tipo_pesagem
            lbl_modificador.Text = balanca.id_modificador.ToString()
            lbl_dt_modificacao.Text = balanca.dt_modificacao.ToString()

            If (balanca.id_situacao > 0) Then
                cbo_situacao.SelectedValue = balanca.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim balanca As New Balanca()

            balanca.id_estabelecimento = cbo_estabelecimento.SelectedValue
            balanca.nm_balanca = txt_nm_balanca.Text
            balanca.ds_end_ip = txt_end_ip.Text
            balanca.ds_porta = txt_porta.Text
            balanca.id_tipo_pesagem = cbo_tipo_pesagem.SelectedValue
            balanca.id_situacao = cbo_situacao.SelectedValue
            

            balanca.id_modificador = Session("id_login")

            If Not (ViewState.Item("id_balanca") Is Nothing) Then

                balanca.id_balanca = Convert.ToInt32(ViewState.Item("id_balanca"))
                balanca.updateBalanca()

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteração
                usuariolog.id_menu_item = 126
                usuariolog.nm_nr_processo = balanca.nm_balanca
                usuariolog.id_nr_processo = ViewState.Item("id_balanca").ToString

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro alterado com sucesso.")

            Else

                ViewState.Item("id_balanca") = balanca.insertBalanca()

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 126
                usuariolog.nm_nr_processo = balanca.nm_balanca
                usuariolog.id_nr_processo = ViewState.Item("id_balanca").ToString

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
        Response.Redirect("lst_balanca.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_balanca.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_balanca.aspx")

    End Sub
End Class
