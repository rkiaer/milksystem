Imports Danone.MilkSystem.Business

Partial Class frm_veiculo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_veiculo.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportadores"
        End With

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

            'Fran 11/09/2009 i GKO
            Dim tipoequipamento As New TipoEquipamento
            tipoequipamento.id_situacao = 1
            cbo_tipo_equipamento.DataSource = tipoequipamento.getTiposEquipamentosByFilters()
            'cbo_tipo_equipamento.DataTextField = "ds_tipo_equipamento" 'fran 17/11/2009
            cbo_tipo_equipamento.DataTextField = "cd_tipo_equipamento" 
            cbo_tipo_equipamento.DataValueField = "id_tipo_equipamento"
            cbo_tipo_equipamento.DataBind()
            cbo_tipo_equipamento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            'Fran 11/09/2009 f GKO

            If Not (Request("id_veiculo") Is Nothing) Then
                ViewState.Item("id_veiculo") = Request("id_veiculo")

                loadData()
            Else
                lbl_cd_veiculo.Visible = False
                txt_cd_veiculo.Visible = False
                'Fran 15/02/2009 i Rls16
                lk_compartimento.Enabled = False
                'Fran 15/02/2009 f Rls16
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

            Dim id_veiculo As Int32 = Convert.ToInt32(ViewState.Item("id_veiculo"))
            Dim veiculo As New Veiculo(id_veiculo)

            lbl_cd_veiculo.Visible = True
            txt_cd_veiculo.Visible = True
            txt_cd_veiculo.Text = veiculo.id_veiculo

            txt_placa.Text = veiculo.ds_placa
            txt_placa.Enabled = False

            txt_modelo.Text = veiculo.ds_modelo
            txt_marca.Text = veiculo.ds_marca
            txt_chassi.Text = veiculo.ds_chassi
            txt_renavam.Text = veiculo.ds_renavam

            If (veiculo.nr_ano_fabricacao > 0) Then
                txt_ano_fabricacao.Text = veiculo.nr_ano_fabricacao.ToString()
            End If

            If (veiculo.nr_ano_modelo > 0) Then
                txt_ano_modelo.Text = veiculo.nr_ano_modelo.ToString()
            End If

            If (veiculo.nr_tara > 0) Then
                txt_tara.Text = veiculo.nr_tara.ToString()
            End If

            If (veiculo.nr_qtd_compartimentos > 0) Then
                txt_qtd_compartimentos.Text = veiculo.nr_qtd_compartimentos.ToString()
            End If

            If (veiculo.id_pessoa > 0) Then
                txt_cd_transportador.Text = veiculo.cd_pessoa.ToString()
                lbl_nm_transportador.Visible = True
                lbl_nm_transportador.Text = veiculo.nm_pessoa.ToString
                hf_id_pessoa.Value = veiculo.id_pessoa.ToString
            Else
                txt_cd_transportador.Text = String.Empty
                lbl_nm_transportador.Visible = False
                lbl_nm_transportador.Text = String.Empty
                hf_id_pessoa.Value = String.Empty
            End If

            If (veiculo.id_cidade > 0) Then
                loadCidadesByEstado(veiculo.id_estado)
                cbo_estado.SelectedValue = veiculo.id_estado.ToString()
                cbo_cidade.SelectedValue = veiculo.id_cidade.ToString()
            End If


            If (veiculo.id_situacao > 0) Then
                cbo_situacao.SelectedValue = veiculo.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            'Fran 11/09/2009 i GKO
            If (veiculo.id_tipo_equipamento > 0) Then
                cbo_tipo_equipamento.SelectedValue = veiculo.id_tipo_equipamento.ToString()
                'Fran 17/11/2009 i
                Dim tipo As New TipoEquipamento(Convert.ToInt32(cbo_tipo_equipamento.SelectedValue))
                lbl_nm_tipo_equipamento.Text = tipo.nm_tipo_equipamento
                'Fran 17/11/2009 f
            End If
            'Fran 11/09/2009 f GKO
            'fran chamado 477 09/10/2009  i
            If Not veiculo.ds_proprietario_tanque Is Nothing Then
                cbo_proprietario_tanque.SelectedValue = veiculo.ds_proprietario_tanque.ToString.Trim
            Else
                cbo_proprietario_tanque.SelectedValue = "0"
            End If



            lbl_modificador.Text = veiculo.id_modificador.ToString()
            lbl_dt_modificacao.Text = veiculo.dt_modificacao.ToString()
            'Fran 15/02/2009 i Rls16
            lk_compartimento.Enabled = True
            'Fran 15/02/2009 f Rls16


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid Then

            Try

                Dim veiculo As New Veiculo()


                veiculo.ds_placa = txt_placa.Text
                veiculo.ds_modelo = txt_modelo.Text
                veiculo.ds_marca = txt_marca.Text
                veiculo.ds_chassi = txt_chassi.Text
                veiculo.ds_renavam = txt_renavam.Text

                'fran 9/10/2009 i chamado 477
                veiculo.ds_proprietario_tanque = cbo_proprietario_tanque.SelectedValue.ToString.Trim 'fran chamado 477 09/10/2009 

                If Not (txt_ano_fabricacao.Text.Trim().Equals(String.Empty)) Then
                    veiculo.nr_ano_fabricacao = Convert.ToInt32(txt_ano_fabricacao.Text)
                End If

                If Not (txt_ano_modelo.Text.Trim().Equals(String.Empty)) Then
                    veiculo.nr_ano_modelo = Convert.ToInt32(txt_ano_modelo.Text)
                End If

                If Not (txt_tara.Text.Trim().Equals(String.Empty)) Then
                    veiculo.nr_tara = Convert.ToDecimal(txt_tara.Text)
                End If

                If Not (txt_qtd_compartimentos.Text.Trim().Equals(String.Empty)) Then
                    veiculo.nr_qtd_compartimentos = Convert.ToInt32(txt_qtd_compartimentos.Text)
                End If

                If Not (txt_cd_transportador.Text.Trim().Equals(String.Empty)) Then
                    veiculo.id_pessoa = Convert.ToInt32(hf_id_pessoa.Value)
                End If

                If Not (cbo_cidade.SelectedValue.Trim().Equals(String.Empty)) Then
                    veiculo.id_cidade = Convert.ToInt32(cbo_cidade.SelectedValue)
                End If

                'Fran 11/09/2009 i GKO
                If Not (cbo_tipo_equipamento.SelectedValue.Trim().Equals(String.Empty)) Then
                    veiculo.id_tipo_equipamento = Convert.ToInt32(cbo_tipo_equipamento.SelectedValue)
                End If
                'Fran 11/09/2009 f GKO

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    veiculo.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                veiculo.id_modificador = Session("id_login")

                If Not (ViewState.Item("id_veiculo") Is Nothing) Then

                    veiculo.id_veiculo = Convert.ToInt32(ViewState.Item("id_veiculo"))
                    veiculo.updateVeiculo()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteração
                    usuariolog.id_menu_item = 8
                    usuariolog.id_nr_processo = ViewState.Item("id_veiculo").ToString
                    usuariolog.nm_nr_processo = veiculo.ds_placa

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_veiculo") = veiculo.insertVeiculo()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 8
                    usuariolog.id_nr_processo = ViewState.Item("id_veiculo").ToString
                    usuariolog.nm_nr_processo = veiculo.ds_placa

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
    Private Sub carregarCamposTransportador()

        Try



            If Not (customPage.getFilterValue("lupa_transportador", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transportador", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transportador", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transportador", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_transportador")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_veiculo.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_veiculo.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Sub txt_placa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_placa.TextChanged

    End Sub

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
        Else
            txt_cd_transportador.Text = String.Empty
            hf_id_pessoa.Value = String.Empty
            lbl_nm_transportador.Text = String.Empty
            lbl_nm_transportador.Visible = False
        End If

    End Sub

    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidpessoa As Int32
            If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
            lidpessoa = pessoa.validarTransportador

            If lidpessoa > 0 Then
                args.IsValid = True
                hf_id_pessoa.Value = lidpessoa
            Else
                hf_id_pessoa.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Transportador não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        lbl_nm_transportador.Text = String.Empty
        lbl_nm_transportador.Visible = False
        hf_id_pessoa.Value = String.Empty
    End Sub
    'Fran 16/02/2008 i RLS16
    Protected Sub lk_compartimento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_compartimento.Click
        Response.Redirect("lst_compartimento.aspx?id_veiculo=" + ViewState.Item("id_veiculo").ToString)

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'Fran 02/03/2009 i
        Response.Redirect("frm_veiculo.aspx")
    End Sub
    'Fran 14/09/2009 i - GKO 
    Protected Sub cv_tipo_equipamento_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_tipo_equipamento.ServerValidate
        Try
            'Consistencia para verificação de tipo de equipamento inativo.
            'Esta situação pode ocorrer apenas quando um veiculo estiver sendo reativado.
            Dim tipoequipamento As New TipoEquipamento(Convert.ToInt32(cbo_tipo_equipamento.SelectedValue))
            If tipoequipamento.id_situacao = 1 Then
                args.IsValid = True
            Else
                args.IsValid = False
                messageControl.Alert("O Tipo de Veículo selecionado está desativado!")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    'Fran 14/09/2009 f - GKO 

    Protected Sub cbo_tipo_equipamento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_equipamento.SelectedIndexChanged
        Dim tipo As New TipoEquipamento(Convert.ToInt32(cbo_tipo_equipamento.SelectedValue))
        lbl_nm_tipo_equipamento.Text = tipo.nm_tipo_equipamento
    End Sub
End Class
