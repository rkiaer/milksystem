Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_preco_negociado
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_preco_negociado.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With bt_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialogTecnico()")
            .ToolTip = "Filtrar Técnicos"
        End With

    End Sub

    Private Sub loadDetails()

        Try


            Dim justificativa As New PrecoJustificativa

            cbo_justificativa.DataSource = justificativa.getPrecoJustificativaByFilters()
            cbo_justificativa.DataTextField = "nm_preco_justificativa"
            cbo_justificativa.DataValueField = "id_preco_justificativa"
            cbo_justificativa.DataBind()
            cbo_justificativa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            If Not (Request("id_preco_negociado") Is Nothing) Then
                ViewState.Item("id_preco_negociado") = Request("id_preco_negociado")
                'txt_cd_propriedade.Enabled = False
                lbl_produtor.Visible = True
                lbl_estabelecimento.Visible = True
                loadData()
            Else
                'txt_cd_propriedade.Enabled = True
                lbl_estabelecimento.Visible = False
                lbl_produtor.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim id_preco_negociado As Int32 = Convert.ToInt32(ViewState.Item("id_preco_negociado"))
            Dim preconegociado As New PrecoNegociado(id_preco_negociado)

            lbl_nm_tecnico.Visible = True
            lbl_nm_tecnico.Text = preconegociado.nm_tecnico
            txt_cd_tecnico.Text = preconegociado.id_tecnico.ToString()
            bt_lupa_tecnico.Visible = False
            If (preconegociado.id_tecnico > 0) Then
                hf_id_tecnico.Value = preconegociado.id_tecnico.ToString
            Else
                lbl_nm_tecnico.Text = ""
                lbl_nm_tecnico.Visible = False
                hf_id_tecnico.Value = String.Empty
            End If

            lbl_produtor.Visible = True
            lbl_nm_produtor.Visible = True
            lbl_nm_produtor.Text = preconegociado.ds_produtor

            lbl_estabelecimento.Visible = True
            lbl_nm_estabelecimento.Visible = True
            lbl_nm_estabelecimento.Text = preconegociado.ds_estabelecimento

            txt_cd_tecnico.Text = preconegociado.id_tecnico.ToString()
            txt_cd_tecnico.Enabled = False

            If (preconegociado.id_propriedade > 0) Then
                cbo_propriedade.Items.Add(New ListItem(preconegociado.nm_propriedade, preconegociado.id_propriedade.ToString))
                cbo_propriedade.Text = preconegociado.id_propriedade.ToString()
                cbo_propriedade.Enabled = False
            End If

            If (preconegociado.id_preco_justificativa > 0) Then
                cbo_justificativa.SelectedValue = preconegociado.id_preco_justificativa.ToString()
            End If

            txt_MesAno.Enabled = False
            txt_MesAno.Text = preconegociado.ds_referencia

            txt_valor_negociado.Text = preconegociado.nr_preco_negociado.ToString()
            'preconegociado.nr_preco_aprovado = preconegociado.nr_preco_negociado

            lbl_volume.Text = preconegociado.nr_total_volume.ToString()
            lbl_preco_base.Text = preconegociado.nr_preco_base.ToString()
            lbl_adic_regiao.Text = preconegociado.nr_adic_regiao.ToString()
            lbl_adic_mercado.Text = preconegociado.nr_adic_mercado.ToString()
            lbl_adic_volume.Text = preconegociado.nr_adic_volume.ToString()
            lbl_subtotal.Text = preconegociado.subtotal.ToString()
            lbl_nr_variacao.Text = preconegociado.variacao.ToString()

            If (preconegociado.id_situacao > 0) Then
                cbo_situacao.SelectedValue = preconegociado.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            'lbl_preco_aprovado.Visible = True
            'lbl_nr_preco_aprovado.Visible = True
            'If preconegociado.nr_preco_aprovado <> 0 Then
            '    lbl_nr_preco_aprovado.Text = preconegociado.nr_preco_aprovado.ToString()
            'End If

            lbl_status.Visible = True
            lbl_nm_status.Visible = True
            lbl_nm_status.Text = preconegociado.nm_aprovado
            'With lbl_nm_status
            '    Select Case preconegociado.st_aprovado
            '        Case "1"
            '            .Text = "Aprovado"
            '        Case "2"
            '            .Text = "Reprovado"
            '        Case "3"
            '            .Text = "Em Análise"
            '    End Select
            'End With

            lbl_modificador.Text = preconegociado.id_modificador.ToString()
            lbl_dt_modificacao.Text = preconegociado.dt_modificacao.ToString()

            'fran fase 3 set/2014
            lbl_cluster.Text = preconegociado.nm_cluster.ToString

            'If (preconegociado.st_aprovado = "1") Then
            If (preconegociado.st_aprovado = "2") Then
                txt_valor_negociado.Enabled = False
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        If Page.IsValid Then
            Try

                Dim preconegociado As New PrecoNegociado()

                preconegociado.id_propriedade = Convert.ToInt32(cbo_propriedade.SelectedValue)
                preconegociado.dt_referencia = String.Concat("01/" & txt_MesAno.Text)
                preconegociado.nr_ano = Right(txt_MesAno.Text, 4)
                preconegociado.id_tecnico = txt_cd_tecnico.Text
                preconegociado.nr_preco_negociado = Convert.ToDouble(txt_valor_negociado.Text)
                'preconegociado.nr_preco_aprovado = preconegociado.nr_preco_negociado

                If Not (cbo_justificativa.SelectedValue.Trim().Equals(String.Empty)) Then
                    preconegociado.id_preco_justificativa = Convert.ToInt32(cbo_justificativa.SelectedValue)
                End If

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    preconegociado.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                preconegociado.id_modificador = Session("id_login")
                preconegociado.st_aprovado = "1"   ' Pré-Aprovado

                If Page.IsValid Then
                    If Not (ViewState.Item("id_preco_negociado") Is Nothing) Then
                        preconegociado.id_preco_negociado = Convert.ToInt32(ViewState.Item("id_preco_negociado"))
                        preconegociado.updatePrecoNegociado()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alteracao
                        usuariolog.id_menu_item = 35
                        usuariolog.id_nr_processo = ViewState.Item("id_preco_negociado").ToString
                        usuariolog.nm_nr_processo = preconegociado.id_propriedade.ToString

                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro alterado com sucesso.")
                    Else
                        ViewState.Item("id_preco_negociado") = preconegociado.insertPrecoNegociado()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 4 'inserir
                        usuariolog.id_menu_item = 35
                        usuariolog.id_nr_processo = ViewState.Item("id_preco_negociado").ToString
                        usuariolog.nm_nr_processo = preconegociado.id_propriedade.ToString

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
        Response.Redirect("lst_preco_negociado.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_preco_negociado.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub
    Private Sub carregarCamposTecnico()

        Try

            Me.txt_cd_tecnico.Text = hf_id_tecnico.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub cmv_tecnico_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_tecnico.ServerValidate
        Try
            Dim tecnico As New Tecnico()

            tecnico.id_tecnico = Me.txt_cd_tecnico.Text.Trim

            args.IsValid = tecnico.validarTecnico()

            If Not args.IsValid Then
                messageControl.Alert("Técnico não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Public Sub TrazDados()

        lbl_volume.Text = String.Empty
        lbl_preco_base.Text = String.Empty
        lbl_adic_regiao.Text = String.Empty
        lbl_adic_mercado.Text = String.Empty
        lbl_adic_volume.Text = String.Empty
        lbl_subtotal.Text = String.Empty
        lbl_nr_variacao.Text = String.Empty

        If (Not (cbo_propriedade.SelectedValue.Equals(String.Empty))) And _
            (Not (txt_MesAno.Text.Trim.Equals(String.Empty))) And _
            (Not (txt_cd_tecnico.Text.Trim.Equals(String.Empty))) Then

            Dim propriedade As New Propriedade()
            propriedade.id_propriedade = Convert.ToInt32(Convert.ToInt32(cbo_propriedade.SelectedValue))
            Dim dsPropriedade As DataSet = propriedade.getPropriedadeByFilters()

            If dsPropriedade.Tables(0).Rows.Count > 0 Then

                RK.GenericParameters.ParametersEngine.persistObjectValues(dsPropriedade.Tables(0).Rows(0), propriedade)
                lbl_volume.Text = (propriedade.nr_vol_leite_dia * 30).ToString()

                Dim precoobjetivo As New PrecoObjetivo()
                precoobjetivo.id_tecnico = Convert.ToInt32(txt_cd_tecnico.Text)
                precoobjetivo.nr_ano = Right(txt_MesAno.Text, 4)
                Dim dsPrecoObjetivo As DataSet = precoobjetivo.getPrecoObjetivoByFilters()

                If dsPrecoObjetivo.Tables(0).Rows.Count > 0 Then

                    RK.GenericParameters.ParametersEngine.persistObjectValues(dsPrecoObjetivo.Tables(0).Rows(0), precoobjetivo)

                    Dim precobase As New PrecoBase(precoobjetivo.id_preco_objetivo, Left(txt_MesAno.Text, 2))
                    lbl_preco_base.Text = precobase.nr_preco_base.ToString

                    Dim adicionalregiao As New PrecoAdicionalRegiao(precoobjetivo.id_preco_objetivo, Left(txt_MesAno.Text, 2))
                    lbl_adic_regiao.Text = adicionalregiao.nr_adic_regiao.ToString

                    Dim adicionalmercado As New PrecoAdicionalMercado(precoobjetivo.id_preco_objetivo, Left(txt_MesAno.Text, 2))
                    lbl_adic_mercado.Text = adicionalmercado.nr_adic_mercado.ToString

                    Dim faixa As New FaixaVolume()
                    faixa.nr_faixa_inicio = Convert.ToDouble(lbl_volume.Text)
                    faixa.nr_faixa_fim = Convert.ToDouble(lbl_volume.Text)
                    Dim dsFaixa As DataSet = faixa.getFaixaVolumeByRange()
                    RK.GenericParameters.ParametersEngine.persistObjectValues(dsFaixa.Tables(0).Rows(0), faixa)

                    Dim adicionalvolume As New PrecoAdicionalVolume(precoobjetivo.id_preco_objetivo, faixa.id_faixa_volume, Left(txt_MesAno.Text, 2))
                    lbl_adic_volume.Text = adicionalvolume.nr_adic_volume.ToString

                    lbl_subtotal.Text = (precobase.nr_preco_base + adicionalregiao.nr_adic_regiao + _
                                      adicionalmercado.nr_adic_mercado + adicionalvolume.nr_adic_volume).ToString

                    If Not (txt_valor_negociado.Text.Trim.Equals(String.Empty)) Then
                        lbl_nr_variacao.Text = (Convert.ToDecimal(lbl_subtotal.Text) - Convert.ToDecimal(txt_valor_negociado.Text)).ToString
                    End If

                End If
            End If
        End If
    End Sub

    Public Sub TrazPropriedade()
        cbo_propriedade.Items.Clear()

        If Not (txt_cd_tecnico.Text.Trim.Equals(String.Empty)) Then

            Dim propriedade As New Propriedade()
            propriedade.id_tecnico = Convert.ToInt32(txt_cd_tecnico.Text)

            cbo_propriedade.DataSource = propriedade.getPropriedadeByFilters()
            cbo_propriedade.DataTextField = "ds_propriedade"
            cbo_propriedade.DataValueField = "id_propriedade"
            cbo_propriedade.DataBind()

        End If

        TrazEstabelecimento()
    End Sub

    Public Sub TrazEstabelecimento()
        lbl_nm_estabelecimento.Text = String.Empty
        lbl_nm_produtor.Text = String.Empty
        lbl_estabelecimento.Visible = False
        lbl_produtor.Visible = False

        If Not (cbo_propriedade.SelectedValue.Trim().Equals(String.Empty)) Then
            Dim propriedade As New Propriedade(Convert.ToInt32(cbo_propriedade.SelectedValue))
            Dim estabelecimento As New Estabelecimento(propriedade.id_estabelecimento)
            lbl_estabelecimento.Visible = True
            lbl_nm_estabelecimento.Text = estabelecimento.nm_estabelecimento
            Dim produtor As New Pessoa(propriedade.id_pessoa)
            lbl_produtor.Visible = True
            lbl_nm_produtor.Text = produtor.nm_pessoa
        End If


    End Sub

    Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
        hf_id_tecnico.Value = String.Empty
        lbl_nm_tecnico.Text = String.Empty
        lbl_nm_tecnico.Visible = False
        TrazPropriedade()
        TrazDados()
    End Sub

    Protected Sub txt_MesAno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MesAno.TextChanged
        TrazDados()
    End Sub

    Protected Sub bt_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_tecnico.Click
        If Not (Me.hf_id_tecnico.Value.ToString.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            Me.lbl_nm_tecnico.Visible = True
            carregarCamposTecnico()
        End If
        TrazPropriedade()
        TrazDados()
    End Sub

    Protected Sub txt_valor_negociado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_valor_negociado.TextChanged
        lbl_nr_variacao.Text = String.Empty
        If Not (lbl_subtotal.Text.Trim.Equals(String.Empty)) And Not (txt_valor_negociado.Text.Trim.Equals(String.Empty)) Then
            lbl_nr_variacao.Text = (Convert.ToDecimal(lbl_subtotal.Text) - Convert.ToDecimal(txt_valor_negociado.Text)).ToString
        End If
    End Sub

    Protected Sub cbo_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_propriedade.TextChanged
        TrazDados()
    End Sub
End Class
