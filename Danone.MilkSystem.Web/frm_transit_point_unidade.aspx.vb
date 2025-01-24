Imports Danone.MilkSystem.Business

Partial Class frm_transit_point_unidade
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_transit_point_unidade.aspx")

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


            Dim estabel As New Estabelecimento

            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_transit_point_unidade") Is Nothing) Then
                ViewState.Item("id_transit_point_unidade") = Request("id_transit_point_unidade")
                txt_nm_transit_point.Enabled = False
                txt_nm_sigla.Enabled = False

                loadData()
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_transit_point_unidade As Int32 = Convert.ToInt32(ViewState.Item("id_transit_point_unidade"))
            Dim transit As New TransitPointUnidade(id_transit_point_unidade)

            txt_nm_transit_point.Text = transit.nm_transit_point_unidade
            txt_nm_sigla.Text = transit.cd_transit_point_unidade

            If (transit.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = transit.id_estabelecimento.ToString()
                cbo_estabelecimento.Enabled = False
            End If

            txt_endereco.Text = transit.ds_endereco
            txt_numero.Text = transit.nr_endereco.ToString()
            txt_complemento.Text = transit.ds_complemento
            txt_bairro.Text = transit.ds_bairro

            If (transit.id_cidade > 0) Then
                loadCidadesByEstado(transit.id_estado)
                cbo_estado.SelectedValue = transit.id_estado.ToString()
                cbo_cidade.SelectedValue = transit.id_cidade.ToString()
            End If

            txt_cep.Text = transit.cd_cep

            If (transit.id_situacao > 0) Then
                cbo_situacao.SelectedValue = transit.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = transit.id_modificador.ToString()
            lbl_dt_modificacao.Text = transit.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid Then
            Try

                Dim transit As New TransitPointUnidade()

                transit.nm_transit_point_unidade = txt_nm_transit_point.Text
                transit.cd_transit_point_unidade = txt_nm_sigla.Text

                If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then
                    transit.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                End If

                transit.ds_endereco = txt_endereco.Text

                If Not (txt_numero.Text.Trim.Equals(String.Empty)) Then
                    transit.nr_endereco = txt_numero.Text
                End If

                transit.ds_complemento = txt_complemento.Text
                transit.ds_bairro = txt_bairro.Text
                If Not (cbo_cidade.SelectedValue.Trim().Equals(String.Empty)) Then
                    transit.id_cidade = Convert.ToInt32(cbo_cidade.SelectedValue)
                End If
                transit.cd_cep = txt_cep.Text

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    transit.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                transit.id_modificador = Session("id_login")

                If Not (ViewState.Item("id_transit_point") Is Nothing) Then

                    transit.id_transit_point_unidade = Convert.ToInt32(ViewState.Item("id_transit_point_unidade"))
                    transit.updateTransitPointUnidade()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 171
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_transit_point_unidade") = transit.insertTransitPointUnidade()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inserir
                    usuariolog.id_menu_item = 171
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro inserido com sucesso.")

                End If

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_transit_point_unidade.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_transit_point_unidade.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_transit_point_unidade.aspx")

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

End Class
