Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_unidade_producao_comodato
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_propriedade.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_comodato
            .Attributes.Add("onclick", "javascript:ShowDialogComodato()")
            .ToolTip = "Filtrar Comodatos"
        End With

    End Sub

    Private Sub carregarCamposComodato()

        Try

            If Not (customPage.getFilterValue("lupa_comodato", "nm_comodato").Equals(String.Empty)) Then
                Me.lbl_nm_comodato.Text = customPage.getFilterValue("lupa_comodato", "nm_comodato").ToString
            End If

            If Not (customPage.getFilterValue("lupa_comodato", "id_comodato").Equals(String.Empty)) Then
                Me.txt_cd_comodato.Text = customPage.getFilterValue("lupa_comodato", "id_comodato").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_comodato")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

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

            If Not (Request("id_unidproducaocomodato") Is Nothing) Then
                ViewState.Item("id_unidproducaocomodato") = Request("id_unidproducaocomodato")
                txt_cd_comodato.Enabled = False
                loadData()
            Else
                ViewState.Item("id_unid_producao") = Request("id_unid_producao")
                txt_cd_comodato.Enabled = True
                'carrefar dados para uma nova unid producao equipamento
                loadDadosNova()

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_unidproducaocomodato As Int32 = Convert.ToInt32(ViewState.Item("id_unidproducaocomodato"))
            Dim unidproducaocomodato As New UnidadeProducaoComodato(id_unidproducaocomodato)
            ViewState.Item("id_unid_producao") = unidproducaocomodato.id_unid_producao
            lbl_estabelecimento.Text = unidproducaocomodato.cd_estabelecimento.ToString + " - " + unidproducaocomodato.nm_estabelecimento.ToString
            lbl_produtor.Text = unidproducaocomodato.cd_pessoa.ToString + " - " + unidproducaocomodato.nm_pessoa.ToString
            lbl_propriedade.Text = unidproducaocomodato.id_propriedade.ToString + " - " + unidproducaocomodato.nm_propriedade.ToString
            lbl_unidade_producao.Text = unidproducaocomodato.nr_unid_producao.ToString + " - " + unidproducaocomodato.nm_unid_producao.ToString
            txt_cd_comodato.Text = unidproducaocomodato.id_comodato.ToString
            txt_cd_comodato.Enabled = False
            lbl_nm_comodato.Visible = True
            lbl_nm_comodato.Text = unidproducaocomodato.nm_comodato.ToString
            btn_lupa_comodato.Visible = False
            hf_id_comodato.Value = unidproducaocomodato.id_comodato.ToString
            ViewState.Item("id_propriedade") = unidproducaocomodato.id_propriedade
            ViewState.Item("id_unidade_producao") = unidproducaocomodato.id_unid_producao
            If Not (unidproducaocomodato.dt_inicio Is Nothing) Then
                txt_dt_inicio.Text = DateTime.Parse(unidproducaocomodato.dt_inicio).ToString("dd/MM/yyyy")
            End If
            If Not (unidproducaocomodato.dt_fim Is Nothing) Then
                txt_dt_termino.Text = DateTime.Parse(unidproducaocomodato.dt_fim).ToString("dd/MM/yyyy")
            End If

            txt_nr_nota_fiscal.Text = unidproducaocomodato.nr_nota_fiscal_comodato
            txt_nr_serie_nota_fiscal.Text = unidproducaocomodato.nr_serie_nota_fiscal_comodato
            If Not (unidproducaocomodato.dt_emissao_nota_fiscal_comodato Is Nothing) Then
                txt_dt_emissao_nota_fiscal.Text = DateTime.Parse(unidproducaocomodato.dt_emissao_nota_fiscal_comodato).ToString("dd/MM/yyyy")
            End If
            txt_nr_contrato.Text = unidproducaocomodato.nr_contrato_comodato
            txt_nr_nota_fiscal_devolucao.Text = unidproducaocomodato.nr_nota_fiscal_devolucao
            If Not (unidproducaocomodato.dt_nota_fiscal_devolucao Is Nothing) Then
                txt_dt_nota_fiscal_devolucao.Text = DateTime.Parse(unidproducaocomodato.dt_nota_fiscal_devolucao).ToString("dd/MM/yyyy")
            End If
            txt_serie_nota_fiscal_devolucao.Text = unidproducaocomodato.nr_serie_nota_fiscal_devolucao
            If (unidproducaocomodato.id_situacao > 0) Then
                cbo_situacao.SelectedValue = unidproducaocomodato.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If



            lbl_modificador.Text = unidproducaocomodato.id_modificador.ToString()
            lbl_dt_modificacao.Text = unidproducaocomodato.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadDadosNova()

        Try


            Dim id_unidade_producao As Int32 = Convert.ToInt32(ViewState.Item("id_unid_producao"))
            Dim unidadeproducao As New UnidadeProducao(id_unidade_producao)

            lbl_estabelecimento.Text = unidadeproducao.cd_estabelecimento.ToString + " - " + unidadeproducao.nm_estabelecimento.ToString
            lbl_produtor.Text = unidadeproducao.cd_pessoa.ToString + " - " + unidadeproducao.nm_pessoa.ToString
            lbl_propriedade.Text = unidadeproducao.id_propriedade.ToString + " - " + unidadeproducao.nm_propriedade.ToString
            lbl_unidade_producao.Text = unidadeproducao.nr_unid_producao.ToString + " - " + unidadeproducao.nm_unid_producao.ToString
            txt_cd_comodato.Enabled = True
            txt_cd_comodato.Text = ""
            lbl_nm_comodato.Visible = False
            lbl_nm_comodato.Text = ""
            btn_lupa_comodato.Visible = True
            hf_id_comodato.Value = ""

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid Then
            Try

                Dim unidproducaocomodato As New UnidadeProducaoComodato()

                If Not (txt_cd_comodato.Text.Equals(String.Empty)) Then
                    unidproducaocomodato.id_comodato = Convert.ToInt32(txt_cd_comodato.Text)
                End If

                unidproducaocomodato.dt_inicio = txt_dt_inicio.Text
                unidproducaocomodato.dt_fim = txt_dt_termino.Text
                unidproducaocomodato.nr_nota_fiscal_comodato = txt_nr_nota_fiscal.Text
                unidproducaocomodato.nr_serie_nota_fiscal_comodato = txt_nr_serie_nota_fiscal.Text
                unidproducaocomodato.dt_emissao_nota_fiscal_comodato = txt_dt_emissao_nota_fiscal.Text
                unidproducaocomodato.nr_contrato_comodato = txt_nr_contrato.Text
                unidproducaocomodato.nr_nota_fiscal_devolucao = txt_nr_nota_fiscal_devolucao.Text
                unidproducaocomodato.dt_nota_fiscal_devolucao = txt_dt_nota_fiscal_devolucao.Text
                unidproducaocomodato.nr_serie_nota_fiscal_devolucao = txt_serie_nota_fiscal_devolucao.Text

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    unidproducaocomodato.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                unidproducaocomodato.id_modificador = Session("id_login")

                If Page.IsValid Then
                    If Not (ViewState.Item("id_unidproducaocomodato") Is Nothing) Then

                        unidproducaocomodato.id_unidproducaocomodato = Convert.ToInt32(ViewState.Item("id_unidproducaocomodato"))
                        unidproducaocomodato.updateUnidProducaoComodato()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alteracao
                        usuariolog.ds_nm_processo = "Propriedade - Unidade de Produção - Comodato"
                        usuariolog.id_menu_item = 5
                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro alterado com sucesso.")

                    Else
                        unidproducaocomodato.id_unid_producao = Convert.ToInt32(ViewState.Item("id_unid_producao"))
                        ViewState.Item("id_unidproducaocomodato") = unidproducaocomodato.insertUnidProducaoComodato()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 4 'inserir
                        usuariolog.ds_nm_processo = "Propriedade - Unidade de Produção - Comodato"
                        usuariolog.id_menu_item = 5
                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro inserido com sucesso.")

                    End If

                    loadData()
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_unidade_producao_comodato.aspx?id_unid_producao=" + ViewState.Item("id_unid_producao").ToString)
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_unidade_producao_comodato.aspx?id_unid_producao=" + ViewState.Item("id_unid_producao").ToString)
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub btn_lupa_comodato_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_comodato.Click
        Me.lbl_nm_comodato.Visible = True
        carregarCamposComodato()

    End Sub


    Protected Sub txt_cd_comodato_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_comodato.TextChanged
        lbl_nm_comodato.Text = String.Empty
        lbl_nm_comodato.Visible = False
        hf_id_comodato.Value = String.Empty
    End Sub

    Protected Sub cv_comodato_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_comodato.ServerValidate
        Try
            Dim comodato As New Comodato()

            comodato.id_comodato = Convert.ToInt32(Me.txt_cd_comodato.Text.Trim)

            args.IsValid = comodato.validarComodato()
            If Not args.IsValid Then
                messageControl.Alert("Comodato não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
