Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_po_cooperativa
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_po_cooperativa.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With bt_lupa_cooperativa
            .Attributes.Add("onclick", "javascript:ShowDialogCooperativa()")
            .ToolTip = "Filtrar Cooperativas"
        End With

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim item As New Item
            cbo_id_item.DataSource = item.getItensByFilters()
            cbo_id_item.DataTextField = "nm_item"
            cbo_id_item.DataValueField = "id_item"
            cbo_id_item.DataBind()
            cbo_id_item.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_po_cooperativa") Is Nothing) Then
                ViewState.Item("id_po_cooperativa") = Request("id_po_cooperativa")
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim po As New POCooperativa(Convert.ToInt32(ViewState.Item("id_po_cooperativa")))

            lbl_nm_pessoa.Visible = True
            lbl_nm_pessoa.Text = po.nm_cooperativa
            txt_cd_pessoa.Text = po.cd_cooperativa
            bt_lupa_cooperativa.Visible = False
            If (po.id_cooperativa > 0) Then
                hf_id_pessoa.Value = po.id_cooperativa.ToString
            Else
                lbl_nm_pessoa.Text = ""
                lbl_nm_pessoa.Visible = False
                hf_id_pessoa.Value = String.Empty
            End If

            txt_cd_pessoa.Enabled = False


            txt_dt_inicio.Enabled = False
            txt_dt_inicio.Text = DateTime.Parse(po.dt_inicio).ToString("dd/MM/yyyy")

            txt_dt_fim.Enabled = False
            txt_dt_fim.Text = DateTime.Parse(po.dt_fim).ToString("dd/MM/yyyy")


            txt_nr_po.Text = po.nr_po

            If (po.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = po.id_estabelecimento.ToString
                cbo_estabelecimento.Enabled = False
            End If

            If (po.id_item > 0) Then
                cbo_id_item.SelectedValue = po.id_item.ToString
                cbo_id_item.Enabled = False
            End If

            If (po.id_situacao > 0) Then
                cbo_situacao.SelectedValue = po.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            Dim usuario As New Usuario(po.id_modificador)

            lbl_modificador.Text = usuario.ds_login
            lbl_dt_modificacao.Text = po.dt_modificacao.ToString()



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        If Page.IsValid Then
            Try

                Dim po As New POCooperativa()

                po.id_cooperativa = Convert.ToInt32(hf_id_pessoa.Value)
                po.dt_inicio = txt_dt_inicio.Text
                po.dt_fim = txt_dt_fim.Text
                po.nr_po = txt_nr_po.Text

                po.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                po.id_modificador = Session("id_login")

                po.id_estabelecimento = cbo_estabelecimento.SelectedValue
                po.id_item = cbo_id_item.SelectedValue

                If Not (ViewState.Item("id_po_cooperativa") Is Nothing) Then
                    po.id_po_cooperativa = Convert.ToInt32(ViewState.Item("id_po_cooperativa"))
                    po.updatePOCooperativa()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 123
                    usuariolog.ds_nm_processo = "PO Cooperativa"
                    usuariolog.id_nr_processo = ViewState.Item("id_po_cooperativa").ToString
                    usuariolog.nm_nr_processo = po.nr_po.ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")
                Else
                    ViewState.Item("id_po_cooperativa") = po.insertPOCooperativa()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inserir
                    usuariolog.id_menu_item = 123
                    usuariolog.ds_nm_processo = "PO Cooperativa"
                    usuariolog.id_nr_processo = ViewState.Item("id_po_cooperativa").ToString
                    usuariolog.nm_nr_processo = po.nr_po.ToString

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
        Response.Redirect("lst_po_ordem_compra.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_po_ordem_compra.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub cmv_cooperativa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_cooperativa.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidpessoa As Int32

            'pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)

            If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
            lidpessoa = pessoa.validarCooperativa

            If lidpessoa > 0 Then
                args.IsValid = True
                hf_id_pessoa.Value = lidpessoa
            Else
                hf_id_pessoa.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Cooperativa não cadastrada.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        lbl_nm_pessoa.Visible = False
        hf_id_pessoa.Value = String.Empty
    End Sub


    Protected Sub bt_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_cooperativa.Click
        If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposCooperativa()
        Else
            txt_cd_pessoa.Text = String.Empty
            hf_id_pessoa.Value = String.Empty
            lbl_nm_pessoa.Text = String.Empty
            lbl_nm_pessoa.Visible = False
        End If
    End Sub
    Private Sub carregarCamposCooperativa()

        Try



            If Not (customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Visible = True
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_cooperativa")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

 
    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_po_cooperativa.aspx")

    End Sub
End Class
