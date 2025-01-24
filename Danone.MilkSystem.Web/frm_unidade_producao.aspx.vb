Imports Danone.MilkSystem.Business

Partial Class frm_unidade_producao
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_propriedade.aspx")
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

            If Not (Request("id_unid_producao") Is Nothing) Then
                ViewState.Item("id_unid_producao") = Request("id_unid_producao")
                loadData()
            Else
                If Not (Request("id_propriedade") Is Nothing) Then
                    ViewState.Item("id_propriedade") = Request("id_propriedade")
                    Dim propriedade As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade").ToString.Trim))
                    lbl_estabelecimento.Text = propriedade.cd_estabelecimento & " - " & propriedade.nm_estabelecimento
                    lbl_produtor.Text = propriedade.cd_pessoa & " - " & propriedade.nm_pessoa
                    lbl_propriedade.Text = propriedade.id_propriedade & " - " & propriedade.nm_propriedade
                    lbl_id_unid_producao.Visible = False
                    txt_id_unid_producao.Visible = False
                End If
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_unid_producao As Int32 = Convert.ToInt32(ViewState.Item("id_unid_producao"))
            Dim unidproducao As New UnidadeProducao(id_unid_producao)

            lbl_id_unid_producao.Visible = True
            txt_id_unid_producao.Visible = True
            txt_id_unid_producao.Text = unidproducao.nr_unid_producao.ToString
            txt_nm_unid_producao.Text = unidproducao.nm_unid_producao
            lbl_estabelecimento.Text = unidproducao.cd_estabelecimento & " - " & unidproducao.nm_estabelecimento
            lbl_produtor.Text = unidproducao.cd_pessoa & " - " & unidproducao.nm_pessoa
            lbl_propriedade.Text = unidproducao.id_propriedade.ToString & " - " & unidproducao.nm_propriedade
            ViewState.Item("id_propriedade") = unidproducao.id_propriedade
            If (unidproducao.id_situacao > 0) Then
                cbo_situacao.SelectedValue = unidproducao.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If
            txt_latitude.Text = unidproducao.nr_latitude.ToString()
            txt_longitude.Text = unidproducao.nr_longitude.ToString()

            lbl_modificador.Text = unidproducao.id_modificador.ToString()
            lbl_dt_modificacao.Text = unidproducao.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            Dim unidadeproducao As New UnidadeProducao()

            unidadeproducao.nm_unid_producao = txt_nm_unid_producao.Text

            unidadeproducao.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                unidadeproducao.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If

            If Not (txt_latitude.Text.Trim().Equals(String.Empty)) Then
                unidadeproducao.nr_latitude = Convert.ToDouble(txt_latitude.Text)
            End If

            If Not (txt_longitude.Text.Trim().Equals(String.Empty)) Then
                unidadeproducao.nr_longitude = Convert.ToDouble(txt_longitude.Text)
            End If


            unidadeproducao.id_modificador = Session("id_login")

            If Not (ViewState.Item("id_unid_producao") Is Nothing) Then

                unidadeproducao.id_unid_producao = Convert.ToInt32(ViewState.Item("id_unid_producao"))
                unidadeproducao.updateUnidadeProducao()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.ds_nm_processo = "Propriedade - Unidade de Produção"
                usuariolog.id_menu_item = 5
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro alterado com sucesso.")

            Else

                ViewState.Item("id_unid_producao") = unidadeproducao.insertUnidadeProducao().ToString
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inserir
                usuariolog.ds_nm_processo = "Propriedade - Unidade de Produção"
                usuariolog.id_menu_item = 5
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
        Response.Redirect("lst_unidade_producao.aspx?id_propriedade=" + ViewState.Item("id_propriedade").ToString)
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_unidade_producao.aspx?id_propriedade=" + ViewState.Item("id_propriedade").ToString)
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_uproducao_comodato_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_uproducao_comodato.Click
        Response.Redirect("lst_unidade_producao_comodato.aspx?id_unid_producao=" + ViewState.Item("id_unid_producao").ToString)

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'Fran 02/03/2009 i rls 17
        Response.Redirect("frm_unidade_producao.aspx?id_propriedade=" + ViewState.Item("id_propriedade").ToString)
    End Sub
End Class
