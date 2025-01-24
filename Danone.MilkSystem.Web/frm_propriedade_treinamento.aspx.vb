Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_propriedade_treinamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_propriedade_treinamento.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_treinamento
            .Attributes.Add("onclick", "javascript:ShowDialogTreinamento()")
            .ToolTip = "Filtrar Treinamentos"
        End With

    End Sub

    Private Sub carregarCamposTreinamento()

        Try

            If Not (customPage.getFilterValue("lupa_treinamento", "nm_treinamento").Equals(String.Empty)) Then
                Me.lbl_treinamento.Text = customPage.getFilterValue("lupa_treinamento", "nm_treinamento").ToString
            End If

            Me.txt_cd_treinamento.Text = Me.hf_id_treinamento.Value.ToString

            customPage.clearFilters("lupa_treinamento")


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

            If Not (Request("id_propriedadetreinamento") Is Nothing) Then
                ViewState.Item("id_propriedadetreinamento") = Request("id_propriedadetreinamento")
                txt_cd_treinamento.Enabled = False
                loadData()
            Else
                ViewState.Item("id_propriedade") = Request("id_propriedade")
                txt_cd_treinamento.Enabled = True
                'carrefar dados para uma nova propriedade treinamento
                loadDadosNova()

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_propriedadetreinamento As Int32 = Convert.ToInt32(ViewState.Item("id_propriedadetreinamento"))
            Dim propriedadetreinamento As New PropriedadeTreinamento(id_propriedadetreinamento)

            ViewState.Item("id_propriedade") = propriedadetreinamento.id_propriedade
            lbl_estabelecimento.Text = propriedadetreinamento.cd_estabelecimento.ToString + " - " + propriedadetreinamento.nm_estabelecimento.ToString
            lbl_produtor.Text = propriedadetreinamento.cd_pessoa.ToString + " - " + propriedadetreinamento.nm_pessoa.ToString
            lbl_propriedade.Text = propriedadetreinamento.id_propriedade.ToString + " - " + propriedadetreinamento.nm_propriedade.ToString
            txt_cd_treinamento.Text = propriedadetreinamento.id_treinamento.ToString
            txt_cd_treinamento.Enabled = False
            lbl_treinamento.Visible = True
            lbl_treinamento.Text = propriedadetreinamento.nm_treinamento.ToString
            btn_lupa_treinamento.Visible = False
            hf_id_treinamento.Value = propriedadetreinamento.id_treinamento.ToString

            If Not (propriedadetreinamento.dt_inicio Is Nothing) Then
                txt_dt_inicio.Text = DateTime.Parse(propriedadetreinamento.dt_inicio).ToString("dd/MM/yyyy")
            End If


            If (propriedadetreinamento.id_situacao > 0) Then
                cbo_situacao.SelectedValue = propriedadetreinamento.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = propriedadetreinamento.id_modificador.ToString()
            lbl_dt_modificacao.Text = propriedadetreinamento.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadDadosNova()

        Try


            Dim id_propriedade As Int32 = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            Dim propriedade As New Propriedade(id_propriedade)

            lbl_estabelecimento.Text = propriedade.cd_estabelecimento.ToString + " - " + propriedade.nm_estabelecimento.ToString
            lbl_produtor.Text = propriedade.cd_pessoa.ToString + " - " + propriedade.nm_pessoa.ToString
            lbl_propriedade.Text = propriedade.id_propriedade.ToString + " - " + propriedade.nm_propriedade.ToString
            txt_cd_treinamento.Enabled = True
            txt_cd_treinamento.Text = ""
            lbl_treinamento.Visible = False
            lbl_treinamento.Text = ""
            btn_lupa_treinamento.Visible = True
            hf_id_treinamento.Value = ""


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid Then


            Try

                Dim propriedadetreinamento As New PropriedadeTreinamento()


                propriedadetreinamento.id_treinamento = Convert.ToString(txt_cd_treinamento.Text)

                'Alexandre 08/07/2010 Chamado 892  i.
                ' propriedadetreinamento.dt_inicio = txt_dt_inicio.Text
                If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
                    propriedadetreinamento.dt_inicio = txt_dt_inicio.Text
                End If
                'Alexandre 08/07/2010 Chamado 892  f. 

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    propriedadetreinamento.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                propriedadetreinamento.id_modificador = Session("id_login")

                If Page.IsValid Then
                    If Not (ViewState.Item("id_propriedadetreinamento") Is Nothing) Then

                        propriedadetreinamento.id_propriedadetreinamento = Convert.ToInt32(ViewState.Item("id_propriedadetreinamento"))
                        propriedadetreinamento.updatePropriedadeTreinamento()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alteracao
                        usuariolog.id_menu_item = 5
                        usuariolog.ds_nm_processo = "Propriedade - Treinamento"
                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro alterado com sucesso.")

                    Else
                        propriedadetreinamento.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))

                        'ViewState.Item("id_treinamento") = propriedadetreinamento.insertPropriedadeTreinamento()
                        ViewState.Item("id_propriedadetreinamento") = propriedadetreinamento.insertPropriedadeTreinamento()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 4 'inserir
                        usuariolog.id_menu_item = 5
                        usuariolog.ds_nm_processo = "Propriedade - Treinamento"
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
        Response.Redirect("lst_propriedade_treinamento.aspx?id_propriedade=" + ViewState.Item("id_propriedade").ToString)
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_propriedade_treinamento.aspx?id_propriedade=" + ViewState.Item("id_propriedade").ToString)
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Public Sub New()

    End Sub


    Protected Sub btn_lupa_treinamento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_treinamento.Click
        Me.lbl_treinamento.Visible = True
        carregarCamposTreinamento()

    End Sub



    Protected Sub txt_cd_treinamento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_treinamento.TextChanged
        lbl_treinamento.Text = String.Empty
        lbl_treinamento.Visible = False
        hf_id_treinamento.Value = String.Empty
    End Sub

    Protected Sub cv_treinamento_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_treinamento.ServerValidate
        Try
            Dim treinamento As New Treinamento()

            treinamento.id_treinamento = Trim(txt_cd_treinamento.Text)
            Dim dsTreinamento As DataSet = treinamento.getTreinamentoByFilters()

            args.IsValid = dsTreinamento.Tables(0).Rows.Count > 0
            If Not args.IsValid Then
                messageControl.Alert("Treinamento não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_propriedade_treinamento.aspx?id_propriedade=" + ViewState.Item("id_propriedade").ToString())

    End Sub
End Class
