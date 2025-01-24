Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_propriedade

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_propriedade.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
        End With
        With btn_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialogTecnico()")
            .ToolTip = "Filtrar Técnicos"
        End With
        With btn_lupa_tecnico_educampo
            .Attributes.Add("onclick", "javascript:ShowDialogTecnicoEducampo()")
            .ToolTip = "Filtrar Técnicos EDUCAMPO"
        End With
        '07/12/2016 - Mirella i
        With btn_lupa_tecnico_comquali
            .Attributes.Add("onclick", "javascript:ShowDialogTecnicoComquali()")
            .ToolTip = "Filtrar Técnicos COMQUALI"
        End With
        '07/12/2016 - Mirella f
        'With btn_lupa_linha
        '    .Attributes.Add("onclick", "javascript:ShowDialogLinha()")
        '    .ToolTip = "Filtrar Rotas"
        'End With

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabel As New Estabelecimento

            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'fran 12/02/2012 icombo estabelecimento do frete
            cbo_estabel_frete.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabel_frete.DataTextField = "nm_estabelecimento"
            cbo_estabel_frete.DataValueField = "id_estabelecimento"
            cbo_estabel_frete.DataBind()
            cbo_estabel_frete.Items.Insert(0, New ListItem("[Selecione]", "0"))
            'fran 12/02/2012 f

            Dim item As New Item
            cbo_id_item.DataSource = item.getItensByFilters()
            cbo_id_item.DataTextField = "nm_item"
            cbo_id_item.DataValueField = "id_item"
            cbo_id_item.DataBind()
            cbo_id_item.Items.FindByValue("1").Selected = True

            Dim estado As New Estado

            cbo_estado.DataSource = estado.getEstadosByFilters()
            cbo_estado.DataTextField = "nm_estado"
            cbo_estado.DataValueField = "id_estado"
            cbo_estado.DataBind()
            cbo_estado.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            Dim situacao As New Situacao

            cbo_situacao.DataSource = situacao.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True


            If Not (Request("id_propriedade") Is Nothing) Then
                ViewState.Item("id_propriedade") = Request("id_propriedade")
                If Not (Request("id_pessoa") Is Nothing) Then   ' Rls1 - Se veio do link de Propriedades em Pessoa
                    ViewState.Item("id_pessoa") = Request("id_pessoa")
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                End If
                loadData()
            Else
                'Fran 02/03/2009 i rls17
                'Se não trouxe id_propriedade é uma nova propriedade a ser montada
                'fran 01/03/2010 i
                txt_dt_inicio.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
                'fran 01/03/2010 f

                If Not (Request("id_pessoa") Is Nothing) Then   ' Rls17 - Se veio do link de Propriedades em Pessoa e está tentando adicionar uma nova propriedade

                    ViewState.Item("id_pessoa") = Request("id_pessoa")
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                    lbl_id_propriedade.Visible = False
                    txt_id_propriedade.Visible = False
                    cbo_situacao.Enabled = False
                    lk_unidade_producao.Enabled = False
                    lk_propriedade_treinamento.Enabled = False

                    loadDataNova_PessoaPropriedade()
                    'Fran 02/03/2009 f rls17
                Else
                    lbl_id_propriedade.Visible = False
                    txt_id_propriedade.Visible = False
                    btn_lupa_produtor.Visible = True
                    cbo_situacao.Enabled = False
                    lk_unidade_producao.Enabled = False
                    lk_propriedade_treinamento.Enabled = False
                End If

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
            'cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_cidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))  ' 01/04/2009 - Rls17

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            Dim id_propriedade As Int32 = Convert.ToInt32(ViewState.Item("id_propriedade"))
            Dim propriedade As New Propriedade(id_propriedade)

            lbl_id_propriedade.Visible = True
            txt_id_propriedade.Visible = True
            txt_id_propriedade.Text = propriedade.id_propriedade
            txt_nm_propriedade.Text = propriedade.nm_propriedade

            If (propriedade.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = propriedade.id_estabelecimento.ToString()
                cbo_estabelecimento.Enabled = False
            End If

            If (propriedade.id_pessoa > 0) Then
                hf_id_pessoa.Value = propriedade.id_pessoa.ToString
            End If

            txt_cd_pessoa.Text = propriedade.cd_pessoa
            txt_cd_pessoa.Enabled = False
            lbl_nm_pessoa.Visible = True
            lbl_nm_pessoa.Text = propriedade.nm_pessoa
            btn_lupa_produtor.Visible = False

            txt_inscricao_estadual.Text = propriedade.cd_inscricao_estadual.ToString
            txt_nr_qtde_animais.Text = propriedade.nr_qtde_animais.ToString
            txt_nr_capac_granel.Text = propriedade.nr_capac_granel.ToString
            txt_nr_capac_ensacado.Text = propriedade.nr_capac_ensacado.ToString
            'txt_nr_vol_leite_dia.Text = propriedade.nr_vol_leite_dia.ToString
            txt_nr_vol_leite_dia.Text = FormatNumber(propriedade.nr_vol_leite_dia.ToString, 0)  ' 12/02/2009 - Rls16

            cbo_id_item.SelectedValue = propriedade.id_item.ToString

            If Not (propriedade.dt_inicio Is Nothing) Then
                txt_dt_inicio.Text = DateTime.Parse(propriedade.dt_inicio).ToString("dd/MM/yyyy")
            Else
                txt_dt_inicio.Text = ""
            End If

            If (propriedade.id_tecnico > 0) Then
                hf_id_tecnico.Value = propriedade.id_tecnico.ToString
                txt_id_tecnico.Text = propriedade.id_tecnico.ToString
                lbl_nm_tecnico.Visible = True
                lbl_nm_tecnico.Text = propriedade.nm_tecnico
            Else
                lbl_nm_tecnico.Text = ""
                lbl_nm_tecnico.Visible = False
            End If
            If (propriedade.id_tecnico_educampo > 0) Then
                hf_id_tecnico_educampo.Value = propriedade.id_tecnico_educampo.ToString
                txt_id_tecnico_educampo.Text = propriedade.id_tecnico_educampo.ToString
                lbl_nm_tecnico_educampo.Visible = True
                lbl_nm_tecnico_educampo.Text = propriedade.nm_tecnico_educampo
            Else
                lbl_nm_tecnico_educampo.Text = ""
                lbl_nm_tecnico_educampo.Visible = False
            End If
            'fran 07/2016 i

            '07/12/2016 - Mirella i
            If (propriedade.id_tecnico_comquali > 0) Then
                hf_id_tecnico_comquali.Value = propriedade.id_tecnico_comquali.ToString
                txt_id_tecnico_comquali.Text = propriedade.id_tecnico_comquali.ToString
                lbl_nm_tecnico_comquali.Visible = True
                lbl_nm_tecnico_comquali.Text = propriedade.nm_tecnico_comquali
            Else
                lbl_nm_tecnico_comquali.Text = ""
                lbl_nm_tecnico_comquali.Visible = False
            End If
            '07/12/2016 - Mirella f

            If propriedade.st_transferencia.Equals("S") Then
                lbl_st_transferencia.text = "Sim"
            Else
                lbl_st_transferencia.text = "Não"
            End If
            'fran 07/2016 f
            ' 10/09/2008
            'If (propriedade.id_linha > 0) Then
            '    hf_id_linha.Value = propriedade.id_linha.ToString
            '    txt_id_linha.Text = propriedade.id_linha.ToString
            '    lbl_nm_linha.Visible = True
            '    lbl_nm_linha.Text = propriedade.nm_linha
            'Else
            '    lbl_nm_linha.Text = ""
            '    lbl_nm_linha.Visible = False
            'End If

            txt_endereco.Text = propriedade.ds_endereco
            If propriedade.nr_endereco > 0 Then
                txt_numero.Text = propriedade.nr_endereco.ToString()
            End If
            'fran 01/03/2010 i  
            txt_cep.Text = propriedade.cd_cep
            'fran 01/03/2010 f
            txt_complemento.Text = propriedade.ds_complemento
            txt_bairro.Text = propriedade.ds_bairro

            If (propriedade.id_cidade > 0) Then
                loadCidadesByEstado(propriedade.id_estado)
                cbo_estado.SelectedValue = propriedade.id_estado.ToString()
                cbo_cidade.SelectedValue = propriedade.id_cidade.ToString()
                cbo_cidade.Enabled = False 'fran 01/03/2010
            End If

            txt_latitude.Text = propriedade.nr_latitude.ToString()
            txt_longitude.Text = propriedade.nr_longitude.ToString()
            If Not (propriedade.st_considera_qualidade.Trim().Equals(String.Empty)) Then
                cbo_considera_qualidade.SelectedValue = propriedade.st_considera_qualidade
            End If

            'fran gold fase 3 11/2014 i
            If Not (propriedade.st_gold.Trim().Equals(String.Empty)) Then
                cbo_gold.SelectedValue = propriedade.st_gold
            End If
            'fran gold fase 3 11/2014 f


            If Not (propriedade.st_incentivo_fiscal.Trim().Equals(String.Empty)) Then
                cbo_incentivo_fiscal.SelectedValue = propriedade.st_incentivo_fiscal
            End If

            If Not (propriedade.st_transferencia_credito.Trim().Equals(String.Empty)) Then
                cbo_transferencia_credito.SelectedValue = propriedade.st_transferencia_credito
            End If

            If Not (propriedade.st_incentivo_21.Trim().Equals(String.Empty)) Then
                cbo_incentivo_21.SelectedValue = propriedade.st_incentivo_21
            End If
            'Fran 13/10/2009 i
            txt_ds_email.Text = propriedade.ds_email
            txt_ds_email2.Text = propriedade.ds_email2
            txt_celular.Text = propriedade.ds_celular
            txt_telefone1.Text = propriedade.ds_telefone
            txt_ds_contato.Text = propriedade.ds_contato
            'Fran 13/10/2009 f

            ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5 - i
            If Not (propriedade.st_incentivo_24.Trim().Equals(String.Empty)) Then
                cbo_incentivo_24.SelectedValue = propriedade.st_incentivo_24
            End If
            ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5 - f

            'fran 01/10/2020 i 
            Select Case propriedade.st_tipo_propriedade
                Case "U"
                    lbl_tipo_propriedade.Text = "Única"
                Case "M"
                    lbl_tipo_propriedade.Text = "Matriz"
                Case "F"
                    lbl_tipo_propriedade.Text = "Filial"
            End Select


            'fran 01/10/2020 f

            If (propriedade.id_situacao > 0) Then
                cbo_situacao.SelectedValue = propriedade.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            If (propriedade.id_motivo_inativacao > 0) Then
                Me.loadMotivoInativacao()
            End If

            lbl_modificador.Text = propriedade.id_modificador.ToString()
            lbl_dt_modificacao.Text = propriedade.dt_modificacao.ToString()

            cbo_calculo_juros.SelectedValue = propriedade.st_calculo_com_juros

            'fran dango 2018 i
            txt_ds_car.Text = propriedade.ds_car
            txt_nirf.Text = propriedade.cd_nirf
            txt_nrp.Text = propriedade.cd_nrp
            txt_farms.Text = propriedade.cd_farms
            If Not (propriedade.dt_expiracao_dqse Is Nothing) Then
                txt_dt_expiracao_dqse.Text = DateTime.Parse(propriedade.dt_expiracao_dqse).ToString("dd/MM/yyyy")
            Else
                txt_dt_expiracao_dqse.Text = ""
            End If
            'fran 10/10/2015 i Poupança
            Dim poupancaadesao As New PoupancaAdesao
            Dim dsAux As DataSet

            'busca o ultimo periodo da tabela de adesao que seja finalizado
            poupancaadesao.id_propriedade = propriedade.id_propriedade
            poupancaadesao.id_situacao_poupanca = 2 'finalizado
            poupancaadesao.id_situacao = 1 'ativo
            dsAux = poupancaadesao.getPoupancaAdesaoComOrderBy()
            If dsAux.Tables(0).Rows.Count <> 0 Then
                With dsAux.Tables(0).Rows(0)
                    lbl_poupanca_ultimo_periodo.Text = String.Concat(DateTime.Parse(.Item("dt_referencia_ini").ToString).ToString("MM/yyyy"), " à ", DateTime.Parse(.Item("dt_referencia_fim").ToString).ToString("MM/yyyy"))
                    lbl_poupanca_adesao_ultimo.Text = DateTime.Parse(.Item("dt_adesao").ToString).ToString("dd/MM/yyyy")
                End With
            Else
                lbl_poupanca_ultimo_periodo.Text = String.Empty
                lbl_poupanca_adesao_ultimo.Text = String.Empty
            End If

            'busca o periodo aberto
            poupancaadesao.id_propriedade = propriedade.id_propriedade
            poupancaadesao.id_situacao_poupanca = 1 'aberto
            poupancaadesao.id_situacao = 1 'ativo
            dsAux = poupancaadesao.getPoupancaAdesao()
            If dsAux.Tables(0).Rows.Count <> 0 Then
                With dsAux.Tables(0).Rows(0)
                    lbl_poupanca_periodo_aberto.Text = String.Concat(DateTime.Parse(.Item("dt_referencia_ini").ToString).ToString("MM/yyyy"), " à ", DateTime.Parse(.Item("dt_referencia_fim").ToString).ToString("MM/yyyy"))
                    lbl_poupanca_adesao.Text = DateTime.Parse(.Item("dt_adesao").ToString).ToString("dd/MM/yyyy")
                End With
            Else
                lbl_poupanca_periodo_aberto.Text = String.Empty
                lbl_poupanca_adesao.Text = String.Empty
            End If

            'fran 10/10/2015 f Poupança


            ' 04/08/2008 - Saldo Disponível - i
            Dim saldodisponivel As New SaldoDisponivel
            saldodisponivel.id_propriedade = propriedade.id_propriedade
            saldodisponivel.dt_referencia = "01/" & DateTime.Parse(Now).ToString("MM/yyyy")
            Me.txt_valor_disponivel.Text = FormatCurrency(saldodisponivel.getSaldoDisponivel())  ' 13/02/2009 Rls 16
            ' 04/08/2008 - Saldo Disponível - f

            ' 26/08/2008 - V2 da Roteirização - i 
            If Not (propriedade.st_periodicidade_coleta.Trim().Equals(String.Empty)) Then
                cbo_periodicidade_coleta.SelectedValue = propriedade.st_periodicidade_coleta
            End If

            If Not (propriedade.st_tipo_coleta.Trim().Equals(String.Empty)) Then
                cbo_tipo_coleta.SelectedValue = propriedade.st_tipo_coleta
            End If
            ' 26/08/2008 - V2 da Roteirização - f 

            '10/09/2008 - V3 da Roteirização - i
            If propriedade.id_linha_par > 0 Then
                lbl_rota_par.Text = Convert.ToString(propriedade.id_linha_par) & " - " & Convert.ToString(propriedade.nm_linha_par)
            End If

            If propriedade.id_linha_impar > 0 Then
                lbl_rota_impar.Text = Convert.ToString(propriedade.id_linha_impar) & " - " & Convert.ToString(propriedade.nm_linha_impar)
            End If
            '10/09/2008 - V3 da Roteirização - f

            txt_codigo_SAP.Text = propriedade.cd_codigo_SAP ' 02/2012 - Projeto Themis Rls 31

            'fran 12/02/2012 i estabelecimento de frete
            If (propriedade.id_estabelecimento_frete > 0) Then
                cbo_estabel_frete.SelectedValue = propriedade.id_estabelecimento_frete.ToString()
            End If
            'fran 12/02/2012 f estabelecimento de frete

            'fran 07/2016 i
            'se propriedade inativa
            If propriedade.id_situacao.Equals(2) Then
                'se porpriedade transferida
                If propriedade.st_transferencia.Equals("S") Then
                    'se estiver em transferencia não pode ativar ou fazer alterações
                    lk_concluir.Enabled = False
                    lk_concluirFooter.Enabled = False
                End If
            End If
            'fran 07/2016 f

            'If propriedade.st_coleta_domingo = "S" Then
            '    Me.ck_coleta_domingo.Checked = True
            'Else
            '    Me.ck_coleta_domingo.Checked = False
            'End If

            'If propriedade.st_coleta_segunda = "S" Then
            '    Me.ck_coleta_segunda.Checked = True
            'Else
            '    Me.ck_coleta_segunda.Checked = False
            'End If

            'If propriedade.st_coleta_terca = "S" Then
            '    Me.ck_coleta_terca.Checked = True
            'Else
            '    Me.ck_coleta_terca.Checked = False
            'End If

            'If propriedade.st_coleta_quarta = "S" Then
            '    Me.ck_coleta_quarta.Checked = True
            'Else
            '    Me.ck_coleta_quarta.Checked = False
            'End If

            'If propriedade.st_coleta_quinta = "S" Then
            '    Me.ck_coleta_quinta.Checked = True
            'Else
            '    Me.ck_coleta_quinta.Checked = False
            'End If

            'If propriedade.st_coleta_sexta = "S" Then
            '    Me.ck_coleta_sexta.Checked = True
            'Else
            '    Me.ck_coleta_sexta.Checked = False
            'End If

            'If propriedade.st_coleta_sabado = "S" Then
            '    Me.ck_coleta_sabado.Checked = True
            'Else
            '    Me.ck_coleta_sabado.Checked = False
            'End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    'Fran 02/03/2009 i
    Private Sub loadDataNova_PessoaPropriedade()

        Try

            Dim id_pessoa As Int32 = Convert.ToInt32(ViewState.Item("id_pessoa"))
            'Dim id_estabelecimento As Int32 = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            Dim pessoa As New Pessoa(id_pessoa)

            cbo_estabelecimento.SelectedValue = pessoa.id_estabelecimento.ToString()
            cbo_estabelecimento.Enabled = False
            hf_id_pessoa.Value = pessoa.id_pessoa.ToString
            txt_cd_pessoa.Text = pessoa.cd_pessoa
            txt_cd_pessoa.Enabled = False
            lbl_nm_pessoa.Visible = True
            lbl_nm_pessoa.Text = pessoa.nm_pessoa
            btn_lupa_produtor.Visible = False

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub updateData()
        If Page.IsValid = True Then

            Try

                Dim propriedade As New Propriedade()


                propriedade.nm_propriedade = txt_nm_propriedade.Text

                If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then
                    propriedade.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                End If

                If Not (hf_id_pessoa.Value.Equals(String.Empty)) Then
                    propriedade.id_pessoa = Convert.ToInt32(hf_id_pessoa.Value)
                End If
                propriedade.cd_inscricao_estadual = (txt_inscricao_estadual.Text)

                If Not (txt_nr_capac_granel.Text.Trim().Equals(String.Empty)) Then
                    propriedade.nr_capac_granel = Convert.ToDouble(txt_nr_capac_granel.Text)
                End If
                If Not (txt_nr_capac_ensacado.Text.Trim().Equals(String.Empty)) Then
                    propriedade.nr_capac_ensacado = Convert.ToDouble(txt_nr_capac_ensacado.Text)
                End If
                If Not (txt_nr_vol_leite_dia.Text.Trim().Equals(String.Empty)) Then
                    propriedade.nr_vol_leite_dia = Convert.ToDouble(txt_nr_vol_leite_dia.Text)
                End If
                If Not (txt_nr_qtde_animais.Text.Trim().Equals(String.Empty)) Then
                    propriedade.nr_qtde_animais = Convert.ToInt32(txt_nr_qtde_animais.Text)
                End If
                If Not (txt_dt_inicio.Text.Trim.Equals(String.Empty)) Then
                    propriedade.dt_inicio = txt_dt_inicio.Text.ToString
                End If

                If Not (txt_id_tecnico.Text.Trim.Equals(String.Empty)) Then
                    propriedade.id_tecnico = Convert.ToInt32(txt_id_tecnico.Text)
                End If
                If Not (txt_id_tecnico_educampo.Text.Trim.Equals(String.Empty)) Then
                    propriedade.id_tecnico_educampo = Convert.ToInt32(txt_id_tecnico_educampo.Text)
                End If
                If Not (txt_id_tecnico_comquali.Text.Trim.Equals(String.Empty)) Then   ' adri 19/12/2016 - Curva ABC
                    propriedade.id_tecnico_comquali = Convert.ToInt32(txt_id_tecnico_comquali.Text)
                End If

                'If Not (txt_id_linha.Text.Trim.Equals(String.Empty)) Then
                '    propriedade.id_linha = Convert.ToInt32(txt_id_linha.Text)
                'End If

                propriedade.ds_endereco = txt_endereco.Text
                If Not (txt_numero.Text.Trim().Equals(String.Empty)) Then
                    propriedade.nr_endereco = Convert.ToInt32(txt_numero.Text)
                End If
                propriedade.ds_complemento = txt_complemento.Text
                propriedade.ds_bairro = txt_bairro.Text

                If Not (cbo_cidade.SelectedValue.Trim().Equals(String.Empty)) Then
                    propriedade.id_cidade = Convert.ToInt32(cbo_cidade.SelectedValue)
                End If

                propriedade.cd_cep = txt_cep.Text

                If Not (txt_latitude.Text.Trim().Equals(String.Empty)) Then
                    propriedade.nr_latitude = Convert.ToDouble(txt_latitude.Text)
                End If

                If Not (txt_longitude.Text.Trim().Equals(String.Empty)) Then
                    propriedade.nr_longitude = Convert.ToDouble(txt_longitude.Text)
                End If

                If Not (cbo_considera_qualidade.SelectedValue.Trim().Equals(String.Empty)) Then
                    propriedade.st_considera_qualidade = cbo_considera_qualidade.SelectedValue
                End If

                'fran gold fase 3 11/2014 i
                If Not (cbo_gold.SelectedValue.Trim().Equals(String.Empty)) Then
                    propriedade.st_gold = cbo_gold.SelectedValue
                End If
                'fran gold fase 3 11/2014 f

                If Not (cbo_incentivo_fiscal.SelectedValue.Trim().Equals(String.Empty)) Then
                    propriedade.st_incentivo_fiscal = cbo_incentivo_fiscal.SelectedValue
                End If

                If Not (cbo_transferencia_credito.SelectedValue.Trim().Equals(String.Empty)) Then
                    propriedade.st_transferencia_credito = cbo_transferencia_credito.SelectedValue
                End If

                If Not (cbo_incentivo_21.SelectedValue.Trim().Equals(String.Empty)) Then   ' 22/10/2008
                    propriedade.st_incentivo_21 = cbo_incentivo_21.SelectedValue
                End If

                ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5 - i
                If Not (cbo_incentivo_24.SelectedValue.Trim().Equals(String.Empty)) Then   ' 22/10/2008
                    propriedade.st_incentivo_24 = cbo_incentivo_24.SelectedValue
                End If
                ' 18/05/2009 - Chamado 263 - Incentivo 2,4 - Rls 17.5 - f

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    propriedade.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If
                If Not (cbo_id_motivo_inativacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    propriedade.id_motivo_inativacao = Convert.ToInt32(cbo_id_motivo_inativacao.SelectedValue)
                End If

                ' 26/08/2008 - V2 da Roteirização - i 
                If Not (cbo_periodicidade_coleta.SelectedValue.Trim().Equals(String.Empty)) Then
                    propriedade.st_periodicidade_coleta = cbo_periodicidade_coleta.SelectedValue
                End If

                If Not (cbo_tipo_coleta.SelectedValue.Trim().Equals(String.Empty)) Then
                    propriedade.st_tipo_coleta = cbo_tipo_coleta.SelectedValue
                End If
                ' 26/08/2008 - V2 da Roteirização - f 

                propriedade.st_calculo_com_juros = cbo_calculo_juros.SelectedValue
                'If Me.ck_coleta_domingo.Checked = True Then
                '    propriedade.st_coleta_domingo = "S"
                'Else
                '    propriedade.st_coleta_domingo = "N"
                'End If

                'If Me.ck_coleta_segunda.Checked = True Then
                '    propriedade.st_coleta_segunda = "S"
                'Else
                '    propriedade.st_coleta_segunda = "N"
                'End If

                'If Me.ck_coleta_terca.Checked = True Then
                '    propriedade.st_coleta_terca = "S"
                'Else
                '    propriedade.st_coleta_terca = "N"
                'End If

                'If Me.ck_coleta_quarta.Checked = True Then
                '    propriedade.st_coleta_quarta = "S"
                'Else
                '    propriedade.st_coleta_quarta = "N"
                'End If

                'If Me.ck_coleta_quinta.Checked = True Then
                '    propriedade.st_coleta_quinta = "S"
                'Else
                '    propriedade.st_coleta_quinta = "N"
                'End If

                'If Me.ck_coleta_sexta.Checked = True Then
                '    propriedade.st_coleta_sexta = "S"
                'Else
                '    propriedade.st_coleta_sexta = "N"
                'End If

                'If Me.ck_coleta_sabado.Checked = True Then
                '    propriedade.st_coleta_sabado = "S"
                'Else
                '    propriedade.st_coleta_sabado = "N"
                'End If

                'Fran 13/10/2009 i
                propriedade.ds_email = txt_ds_email.Text.Trim
                propriedade.ds_email2 = txt_ds_email2.Text.Trim
                propriedade.ds_celular = txt_celular.Text.Trim
                propriedade.ds_telefone = txt_telefone1.Text.Trim
                propriedade.ds_contato = txt_ds_contato.Text.Trim
                'Fran 13/10/2009 f

                ' 27/02/2012 - Projeto Themis - i
                propriedade.cd_codigo_SAP = txt_codigo_SAP.Text
                ' 27/02/2012 - Projeto Themis - f

                'fran 12/02/2012 i 
                If Not (cbo_estabel_frete.SelectedValue.Trim().Equals(String.Empty)) Then
                    propriedade.id_estabelecimento_frete = Convert.ToInt32(cbo_estabel_frete.SelectedValue)
                End If
                'fran 12/02/2012 f

                'fran 07/2018 dango
                propriedade.ds_car = txt_ds_car.Text
                propriedade.cd_nirf = txt_nirf.Text
                propriedade.cd_nrp = txt_nrp.Text
                propriedade.cd_farms = txt_farms.Text
                propriedade.dt_expiracao_dqse = txt_dt_expiracao_dqse.Text
                'fran 07/2018 dango f

                propriedade.id_item = Convert.ToInt32(cbo_id_item.SelectedValue)

                propriedade.id_modificador = Session("id_login")
                propriedade.id_criacao = Session("id_login")
                If Not (ViewState.Item("id_propriedade") Is Nothing) Then

                    propriedade.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                    propriedade.updatePropriedade()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 5
                    usuariolog.id_nr_processo = ViewState.Item("id_propriedade").ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_propriedade").ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else


                    'Carrega unidade de produção para inserir o primeiro cadastro 
                    With propriedade.unidadeproducao
                        .nm_unid_producao = "Não Cadastrado"
                        .id_modificador = Session("id_login")
                        .id_situacao = "1"
                    End With

                    ViewState.Item("id_propriedade") = propriedade.insertPropriedade_UP()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inserir
                    usuariolog.id_menu_item = 5
                    usuariolog.id_nr_processo = ViewState.Item("id_propriedade").ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_propriedade").ToString

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
        If Trim(ViewState.Item("id_pessoa")) <> "" Then  ' Rls1 - Se veio de lst_pessoa_propriedade
            Response.Redirect("lst_pessoa_propriedade.aspx?id_pessoa=" & ViewState.Item("id_pessoa").ToString & "&id_estabelecimento=" & ViewState.Item("id_estabelecimento").ToString)
        Else
            Response.Redirect("lst_propriedade.aspx")
        End If
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        If Trim(ViewState.Item("id_pessoa")) <> "" Then  ' Rls1 - Se veio de lst_pessoa_propriedade
            Response.Redirect("lst_pessoa_propriedade.aspx?id_pessoa=" & ViewState.Item("id_pessoa").ToString & "&id_estabelecimento=" & ViewState.Item("id_estabelecimento").ToString)
        Else
            Response.Redirect("lst_propriedade.aspx")
        End If
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Private Sub carregarCamposProdutor()

        Try



            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposTecnico()

        Try

            Me.txt_id_tecnico.Text = hf_id_tecnico.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposTecnicoEducampo()

        Try

            Me.txt_id_tecnico_educampo.Text = hf_id_tecnico_educampo.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico_educampo.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    '07/12/2016 - Mirella i
    Private Sub carregarCamposTecnicoComquali()

        Try

            Me.txt_id_tecnico_comquali.Text = hf_id_tecnico_comquali.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico_comquali.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    '07/12/2016 - Mirella f
    'Private Sub carregarCamposLinha()

    '    Try

    '        Me.txt_id_linha.Text = hf_id_linha.Value

    '        If Not (customPage.getFilterValue("lupa_linha", "nm_linha").Equals(String.Empty)) Then
    '            Me.lbl_nm_linha.Text = customPage.getFilterValue("lupa_linha", "nm_linha").ToString
    '        End If


    '        'loadData()
    '        customPage.clearFilters("lupa_linha")


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            'A´pós retornar da modal, carrega os campos
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
        End If
    End Sub

    Protected Sub btn_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_tecnico.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            'A´pós retornar da modal, carrega os campos
            Me.lbl_nm_tecnico.Visible = True
            carregarCamposTecnico()
        End If
    End Sub
    'Protected Sub btn_lupa_linha_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_linha.Click
    '    If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
    '        'A´pós retornar da modal, carrega os campos
    '        Me.lbl_nm_linha.Visible = True
    '        'carregarCamposLinha()
    '    End If
    'End Sub
    Protected Sub btn_lupa_tecnico_educampo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_tecnico_educampo.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            'A´pós retornar da modal, carrega os campos
            Me.lbl_nm_tecnico_educampo.Visible = True
            carregarCamposTecnicoEducampo()
        End If
    End Sub
    '07/12/2016 - Mirella i
    Protected Sub btn_lupa_tecnico_comquali_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_tecnico_comquali.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            'A´pós retornar da modal, carrega os campos
            Me.lbl_nm_tecnico_comquali.Visible = True
            carregarCamposTecnicoComquali()
        End If
    End Sub    '07/12/2016 - Mirella f

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        'If cbo_estabelecimento.Text <> ViewState.Item("cboestabelecimentoanterior") Then
        ViewState.Item("cboestabelecimentoanterior") = cbo_estabelecimento.SelectedValue.ToString
        Me.lbl_nm_pessoa.Text = ""
        Me.txt_cd_pessoa.Text = ""
        Me.lbl_nm_pessoa.Visible = False
        Me.hf_id_pessoa.Value = ""
        'End If
    End Sub

    Protected Sub lk_unidade_producao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_unidade_producao.Click

        Response.Redirect("lst_unidade_producao.aspx?id_propriedade=" + ViewState.Item("id_propriedade").ToString)
    End Sub


    Protected Sub cv_produtor_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_produtor.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidpessoa As Int32

            pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
            End If
            pessoa.cd_pessoa = Me.txt_cd_pessoa.Text.Trim

            lidpessoa = pessoa.validarProdutor()

            If lidpessoa > 0 Then
                args.IsValid = True
                hf_id_pessoa.Value = lidpessoa
            Else
                hf_id_pessoa.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Produtor não cadastrado.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub cv_tecnico_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_tecnico.ServerValidate
        Try
            Dim tecnico As New Tecnico()

            tecnico.id_tecnico = Me.txt_id_tecnico.Text.Trim

            args.IsValid = tecnico.validarTecnico()

            If Not args.IsValid Then
                messageControl.Alert("Técnico não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_tecnico_educampo_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_tecnico_educampo.ServerValidate
        Try
            Dim tecnico As New Tecnico()

            tecnico.id_tecnico = Me.txt_id_tecnico_educampo.Text.Trim

            args.IsValid = tecnico.validarTecnico()

            If Not args.IsValid Then
                messageControl.Alert("Técnico não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    'Protected Sub cv_linha_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_linha.ServerValidate
    '    Try
    '        Dim linha As New Linha()

    '        linha.id_linha = Me.txt_id_linha.Text.Trim

    '        args.IsValid = linha.validarLinha()

    '        If Not args.IsValid Then
    '            messageControl.Alert("Rota não cadastrada.")
    '        End If
    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

 
    Protected Sub lk_propriedade_treinamento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_propriedade_treinamento.Click
        Response.Redirect("lst_propriedade_treinamento.aspx?id_propriedade=" + ViewState.Item("id_propriedade").ToString)

    End Sub

    Protected Sub txt_id_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_tecnico.TextChanged
        hf_id_tecnico.Value = String.Empty
        lbl_nm_tecnico.Text = String.Empty
        lbl_nm_tecnico.Visible = False
    End Sub
    Protected Sub txt_id_tecnico_educampo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_tecnico_educampo.TextChanged
        hf_id_tecnico_educampo.Value = String.Empty
        lbl_nm_tecnico_educampo.Text = String.Empty
        lbl_nm_tecnico_educampo.Visible = False
    End Sub
    '07/12/2016 - Mirella i
    Protected Sub txt_id_tecnico_comquali_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_tecnico_comquali.TextChanged
        hf_id_tecnico_comquali.Value = String.Empty
        lbl_nm_tecnico_comquali.Text = String.Empty
        lbl_nm_tecnico_comquali.Visible = False
    End Sub '07/12/2016 - Mirella f

    Protected Sub cbo_situacao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_situacao.SelectedIndexChanged
        If cbo_situacao.SelectedValue.Trim.Equals("2") Then 'se desativado
            loadMotivoInativacao()
            rfv_motivoinativacao.Visible = True
        Else
            cbo_id_motivo_inativacao.Items.Clear()
            cbo_id_motivo_inativacao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_id_motivo_inativacao.Enabled = False
            rfv_motivoinativacao.Visible = False
        End If

    End Sub
    Private Sub loadMotivoInativacao()

        Try

            cbo_id_motivo_inativacao.Enabled = True

            Dim motivoinativacao As New PropriedadeMotivoInativacao

            cbo_id_motivo_inativacao.DataSource = motivoinativacao.getMotivosInativacaoByFilters()
            cbo_id_motivo_inativacao.DataTextField = "nm_motivo_inativacao"
            cbo_id_motivo_inativacao.DataValueField = "id_motivo_inativacao"
            cbo_id_motivo_inativacao.DataBind()
            cbo_id_motivo_inativacao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    'Protected Sub txt_id_linha_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_linha.TextChanged
    '    hf_id_linha.Value = String.Empty
    '    lbl_nm_linha.Text = String.Empty
    '    lbl_nm_linha.Visible = False

    'End Sub

    Protected Sub ck__CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ck_coleta_sexta.CheckedChanged

    End Sub

    Protected Sub cbo_periodicidade_coleta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_periodicidade_coleta.SelectedIndexChanged
        If cbo_periodicidade_coleta.SelectedValue = "4" Then  ' Se 48 horas
            cbo_tipo_coleta.Enabled = True
        Else
            cbo_tipo_coleta.Enabled = False
        End If
    End Sub

    Protected Sub cv_situacao_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_situacao.ServerValidate
        ' 17/02/2009 Rls16 - i
        Try
            If cbo_situacao.SelectedValue = 2 Then  ' se está desativando a propriedade
                Dim saldodisponivel As New SaldoDisponivel
                Dim nr_volume_leite As Decimal

                nr_volume_leite = 0
                saldodisponivel.dt_referencia = "01/" & DateTime.Parse(Now).ToString("MM/yyyy")
                saldodisponivel.id_propriedade = Me.txt_id_propriedade.Text.Trim
                nr_volume_leite = saldodisponivel.getVolumeLeiteMes

                If nr_volume_leite <= 0 Then
                    args.IsValid = True
                Else
                    args.IsValid = False
                    messageControl.Alert("Propriedade não pode ser desativada pois possui volume de leite no mês.")
                End If

            Else
                args.IsValid = True
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' 17/02/2009 Rls16 - f
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'Fran 02/03/2009 i RLS 17
        If Not ViewState.Item("id_pessoa") Is Nothing Then  ' Rls17 - Se veio de lst_pessoa_propriedade
            Response.Redirect("frm_propriedade.aspx?id_pessoa=" & ViewState.Item("id_pessoa").ToString & "&id_estabelecimento=" & ViewState.Item("id_estabelecimento").ToString)
        Else
            Response.Redirect("frm_propriedade.aspx")
        End If

    End Sub

    Protected Sub cv_incentivo24_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_incentivo24.ServerValidate
        ' 18/05/2009 Chamado 263 - Incemtivo 2,4% - i
        Try
            If cbo_incentivo_24.SelectedValue = "S" Then  ' se selecionou SIM

                'fran 22/07/2016 i calculo geometrico Nao pode ter mais de um programa de incentivo junto
                'If cbo_incentivo_21.SelectedValue = "N" Then  'Se incentivo 21 está desligado
                '    args.IsValid = True
                'Else
                '    args.IsValid = False
                '    messageControl.Alert("O Incentivo 2,1% e 2,4% não podem estar com a opção SIM simultaneamente.")
                'End If

                If cbo_incentivo_21.SelectedValue.Equals("N") AndAlso cbo_transferencia_credito.SelectedValue.Equals("N") AndAlso cbo_incentivo_fiscal.SelectedValue.Equals("N") Then  'Se incentivo 21 está desligado
                    args.IsValid = True
                Else
                    args.IsValid = False
                    messageControl.Alert("O Programa de Incentivo Fiscal, a Transferência de Crédito, o Incentivo 2,1% e 2,4% não podem estar com a opção SIM simultaneamente.")
                End If
                'fran 22/07/2016 f calculo geometrico Nao pode ter mais de um programa de incentivo junto


            Else
                args.IsValid = True
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' 18/05/2009 Chamado 263 - Incemtivo 2,4% - i

    End Sub

    Protected Sub txt_cep_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cep.TextChanged
        'fran 01/03/2010 i
        Try

            If txt_cep.Text = String.Empty Then
                cbo_estado.SelectedValue = String.Empty
                cbo_cidade.SelectedValue = String.Empty
                cbo_cidade.Enabled = False
            Else
                Dim cidade As New Cidade
                Dim lcep As String
                Dim lpos As Integer

                lcep = txt_cep.Text
                lpos = InStr(lcep, "-")
                If lpos > 0 Then
                    lcep = String.Concat(Mid(lcep, 1, lpos - 1), Mid(lcep, lpos + 1))
                End If
                cidade.cd_cep = lcep
                Dim dscepcidade As DataSet = cidade.getCidadeByCEP()
                If dscepcidade.Tables(0).Rows.Count > 0 Then
                    cbo_estado.SelectedValue = dscepcidade.Tables(0).Rows(0).Item("id_estado")
                    loadCidadesByEstado(Convert.ToInt32(cbo_estado.SelectedValue))
                    cbo_cidade.SelectedValue = dscepcidade.Tables(0).Rows(0).Item("id_cidade")
                    cbo_cidade.Enabled = False
                    txt_endereco.Focus()

                Else
                    cbo_estado.SelectedValue = String.Empty
                    cbo_cidade.SelectedValue = String.Empty
                    cbo_cidade.Enabled = False
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_cep_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_cep.ServerValidate
        Try
            Dim cidade As New Cidade
            Dim lcep As String
            Dim lpos As Integer
            Dim lmsg As String
            lcep = txt_cep.Text
            lpos = InStr(lcep, "-")
            If lpos > 0 Then
                lcep = String.Concat(Mid(lcep, 1, lpos - 1), Mid(lcep, lpos + 1))
            End If
            cidade.cd_cep = lcep
            Dim dscepcidade As DataSet = cidade.getCidadeByCEP()
            If dscepcidade.Tables(0).Rows.Count > 0 Then
                If dscepcidade.Tables(0).Rows(0).Item("id_cidade") <> cbo_cidade.SelectedValue Then
                    lmsg = "A Cidade selecionada não pertence ao CEP informado!"
                    args.IsValid = False
                Else
                    args.IsValid = True
                End If

            Else
                cbo_estado.SelectedValue = String.Empty
                cbo_cidade.SelectedValue = String.Empty
                cbo_cidade.Enabled = False
                args.IsValid = False
            End If
            If args.IsValid = False Then
                messageControl.Alert("O CEP informado não está cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_incentivofiscal_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_incentivofiscal.ServerValidate
        Try
            If cbo_incentivo_fiscal.SelectedValue = "S" Then  ' se selecionou programa de incentivo SIM

                If cbo_incentivo_21.SelectedValue.Equals("N") AndAlso cbo_incentivo_24.SelectedValue.Equals("N") AndAlso cbo_transferencia_credito.SelectedValue.Equals("N") Then  'Se incentivo 21 está desligado
                    args.IsValid = True
                Else
                    args.IsValid = False
                    messageControl.Alert("O Programa de Incentivo Fiscal, a Transferência de Crédito, o Incentivo 2,1% e 2,4% não podem estar com a opção SIM simultaneamente.")
                End If

            Else
                args.IsValid = True
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cv_transferencia_credito_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transferencia_credito.ServerValidate
        Try
            If cbo_transferencia_credito.SelectedValue = "S" Then  ' se selecionou programa de incentivo SIM

                If cbo_incentivo_21.SelectedValue.Equals("N") AndAlso cbo_incentivo_24.SelectedValue.Equals("N") AndAlso cbo_incentivo_fiscal.SelectedValue.Equals("N") Then  'Se incentivo 21 está desligado
                    args.IsValid = True
                Else
                    args.IsValid = False
                    messageControl.Alert("O Programa de Incentivo Fiscal, a Transferência de Crédito, o Incentivo 2,1% e 2,4% não podem estar com a opção SIM simultaneamente.")
                End If

            Else
                args.IsValid = True
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub


    Protected Sub cv_incentivo21_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_incentivo21.ServerValidate
        Try
            If cbo_incentivo_21.SelectedValue = "S" Then  ' se selecionou programa de incentivo SIM

                If cbo_transferencia_credito.SelectedValue.Equals("N") AndAlso cbo_incentivo_24.SelectedValue.Equals("N") AndAlso cbo_incentivo_fiscal.SelectedValue.Equals("N") Then  'Se incentivo 21 está desligado
                    args.IsValid = True
                Else
                    args.IsValid = False
                    messageControl.Alert("O Programa de Incentivo Fiscal, a Transferência de Crédito, o Incentivo 2,1% e 2,4% não podem estar com a opção SIM simultaneamente.")
                End If

            Else
                args.IsValid = True
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub btn_lupa_tecnico_flora_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_tecnico_flora.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            'A´pós retornar da modal, carrega os campos
            Me.lbl_nm_tecnico_flora.Visible = True
            carregarCamposTecnicoFlora()
        End If

    End Sub

    Protected Sub btn_lupa_tecnico_bea_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_tecnico_bea.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            'A´pós retornar da modal, carrega os campos
            Me.lbl_nm_tecnico_bea.Visible = True
            carregarCamposTecnicoBea()
        End If

    End Sub
    Private Sub carregarCamposTecnicoFlora()

        Try

            Me.txt_tecnico_flora.Text = hf_id_tecnico_flora.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico_flora.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposTecnicoBea()

        Try

            Me.txt_tecnico_bea.Text = hf_id_tecnico_bea.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico_bea.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_tecnico_flora_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_tecnico_flora.ServerValidate
        Try
            Dim tecnico As New Tecnico()

            tecnico.id_tecnico = Me.txt_tecnico_flora.Text.Trim

            args.IsValid = tecnico.validarTecnico()

            If Not args.IsValid Then
                messageControl.Alert("Técnico não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_tecnico_bea_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_tecnico_bea.ServerValidate
        Try
            Dim tecnico As New Tecnico()

            tecnico.id_tecnico = Me.txt_tecnico_bea.Text.Trim

            args.IsValid = tecnico.validarTecnico()

            If Not args.IsValid Then
                messageControl.Alert("Técnico não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class

