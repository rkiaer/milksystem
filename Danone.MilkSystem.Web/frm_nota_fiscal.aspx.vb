Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_nota_fiscal

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_nota_fiscal.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Emitente"
        End With

    End Sub

    Private Sub loadDetails()

        Try
            Dim estabel As New Estabelecimento

            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            Dim natoper As New NaturezaOperacao
            natoper.id_situacao = 1
            cbo_natureza_operacao.DataSource = natoper.getNaturezaOperacoesByFilters()
            cbo_natureza_operacao.DataTextField = "ds_natureza_operacao"
            cbo_natureza_operacao.DataValueField = "id_natureza_operacao"
            cbo_natureza_operacao.DataBind()
            cbo_natureza_operacao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim frete As New FreteNotaFiscal

            frete.id_situacao = 1
            cbo_id_frete.DataSource = frete.getFretesNotasFiscaisByFilters()
            cbo_id_frete.DataTextField = "nm_frete_nf"
            cbo_id_frete.DataValueField = "id_frete_nf"
            cbo_id_frete.DataBind()
            cbo_id_frete.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            'fran 21/10/2011 i
            Dim tiponotafiscal As New TipoNotaFiscal
            tiponotafiscal.id_situacao = 1
            cbo_tipo_nota_fiscal.DataSource = tiponotafiscal.getTipoNotaFiscalByFilters()
            cbo_tipo_nota_fiscal.DataTextField = "nm_tipo_nota_fiscal"
            cbo_tipo_nota_fiscal.DataValueField = "id_tipo_nota_fiscal"
            cbo_tipo_nota_fiscal.DataBind()
            cbo_tipo_nota_fiscal.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'fran 21/10/2011 f

            cbo_tipo_nota2.DataSource = cbo_tipo_nota_fiscal.DataSource
            cbo_tipo_nota2.DataTextField = "nm_tipo_nota_fiscal"
            cbo_tipo_nota2.DataValueField = "id_tipo_nota_fiscal"
            cbo_tipo_nota2.DataBind()
            cbo_tipo_nota2.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            If Not (Request("id_nota_fiscal") Is Nothing) Then
                ViewState.Item("id_nota_fiscal") = Request("id_nota_fiscal")

                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub




    Private Sub loadData()

        Try

            Dim id_nota_fiscal As Int32 = Convert.ToInt32(ViewState.Item("id_nota_fiscal"))
            Dim nfiscal As New NotaFiscal(id_nota_fiscal)

            lk_duplicata.Visible = True
            lk_itens_nota.Visible = True

            If (nfiscal.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = nfiscal.id_estabelecimento
                cbo_estabelecimento.Enabled = False
            End If

            If nfiscal.id_pessoa > 0 Then
                txt_cd_pessoa.Text = nfiscal.cd_pessoa
                hf_id_pessoa.Value = nfiscal.id_pessoa
                lbl_nm_pessoa.Visible = True
                lbl_nm_pessoa.Text = nfiscal.nm_pessoa
                txt_cd_pessoa.Enabled = False
                btn_lupa_produtor.Visible = False
                txt_cnpj.Text = nfiscal.cd_cnpj
                txt_cnpj.Enabled = False
            End If
            If (nfiscal.id_natureza_operacao > 0) Then
                cbo_natureza_operacao.SelectedValue = nfiscal.id_natureza_operacao
            End If

            If (nfiscal.id_frete_nf > 0) Then
                cbo_id_frete.SelectedValue = nfiscal.id_frete_nf

            End If

            'fran 03/2017 i
            'se for FOB
            If nfiscal.id_frete_nf.Equals(2) Then
                txt_nr_cte.Enabled = True
                txt_serie_cte.Enabled = True
                txt_nr_valor_cte.Enabled = True
                txt_ds_chave_cte.Enabled = True
                cbo_CST_cte.Enabled = True
                rf_nr_cte.Enabled = True
                rf_serie_cte.Enabled = True
                rf_nr_valor_cte.Enabled = True
                rf_ds_chave_cte.Enabled = True
                rf_cst_cte.Enabled = True
                rf_dt_emissao_cte.Enabled = True
                rf_hr_cte.Enabled = True
                rf_mm_cte.Enabled = True
                rf_ss_cte.Enabled = True
                rv_hr_cte.Enabled = True
                rv_mm_cte.Enabled = True
                rv_ss_cte.Enabled = True
                rf_cfop_cte.Enabled = True
                rf_protocolo_cte.Enabled = True
                rf_uf_origem_cte.Enabled = True
                rf_uf_destino_cte.Enabled = True
                rf_ibge_origem_cte.Enabled = True
                rf_ibge_destino_cte.Enabled = True

                txt_nr_cte.Text = nfiscal.nr_cte.ToString
                txt_serie_cte.Text = nfiscal.nr_serie_cte
                txt_nr_valor_cte.Text = nfiscal.nr_valor_cte
                txt_ds_chave_cte.Text = nfiscal.ds_chave_cte
                cbo_CST_cte.SelectedValue = nfiscal.cd_cst_cte
                If nfiscal.cd_cst_cte.ToString.Equals("40") Then
                    rf_icms_cte.Enabled = False
                    rf_base_icms_cte.Enabled = False
                    txt_nr_icms_cte.Enabled = False
                Else
                    rf_icms_cte.Enabled = True
                    rf_base_icms_cte.Enabled = True
                    txt_nr_icms_cte.Enabled = True
                    txt_base_icms_cte.Text = nfiscal.nr_base_icms_cte
                    txt_nr_icms_cte.Text = nfiscal.nr_valor_icms_cte
                End If
                If Not (nfiscal.dt_emissao_completa_cte Is Nothing) Then
                    txt_dt_emissao_cte.Text = Format(DateTime.Parse(nfiscal.dt_emissao_completa_cte), "dd/MM/yyyy").ToString
                    txt_hr_emissao_cte.Text = Format(DateTime.Parse(nfiscal.dt_emissao_completa_cte), "HH")
                    txt_mm_emissao_cte.Text = Format(DateTime.Parse(nfiscal.dt_emissao_completa_cte), "mm")
                    txt_ss_emissao_cte.Text = Format(DateTime.Parse(nfiscal.dt_emissao_completa_cte), "ss")
                Else
                    rf_dt_emissao_cte.Enabled = True
                    rf_hr_cte.Enabled = True
                    rf_mm_cte.Enabled = True
                    rf_ss_cte.Enabled = True
                    rv_hr_cte.Enabled = True
                    rv_mm_cte.Enabled = True
                    rv_ss_cte.Enabled = True
                End If
                txt_protocolo_cte.Text = nfiscal.ds_protocolo_cte
                txt_cd_cfop_cte.Text = nfiscal.cd_cfop_cte
                txt_uf_origem_cte.Text = nfiscal.cd_uf_origem_cte
                txt_uf_destino_cte.Text = nfiscal.cd_uf_destino_cte
                txt_ibge_origem_cte.Text = nfiscal.cd_ibge_origem_cte
                txt_ibge_destino_cte.Text = nfiscal.cd_ibge_destino_cte

            Else
                txt_nr_cte.Text = String.Empty
                txt_serie_cte.Text = String.Empty
                txt_nr_valor_cte.Text = String.Empty
                txt_ds_chave_cte.Text = String.Empty
                cbo_CST_cte.SelectedValue = String.Empty
                txt_nr_icms_cte.Text = String.Empty
                txt_base_icms_cte.Text = String.Empty
                txt_dt_emissao_cte.Text = String.Empty
                txt_protocolo_cte.Text = String.Empty
                txt_cd_cfop_cte.Text = String.Empty
                txt_uf_origem_cte.Text = String.Empty
                txt_uf_destino_cte.Text = String.Empty
                txt_ibge_origem_cte.Text = String.Empty
                txt_ibge_destino_cte.Text = String.Empty
                txt_nr_cte.Enabled = False
                txt_serie_cte.Enabled = False
                txt_nr_valor_cte.Enabled = False
                txt_ds_chave_cte.Enabled = False
                cbo_CST_cte.Enabled = False
                txt_nr_icms_cte.Enabled = False
                rf_nr_cte.Enabled = False
                rf_serie_cte.Enabled = False
                rf_nr_valor_cte.Enabled = False
                rf_ds_chave_cte.Enabled = False
                rf_cst_cte.Enabled = False
                rf_icms_cte.Enabled = False
                rf_dt_emissao_cte.Enabled = False
                rf_hr_cte.Enabled = False
                rf_mm_cte.Enabled = False
                rf_ss_cte.Enabled = False
                rv_hr_cte.Enabled = False
                rv_mm_cte.Enabled = False
                rv_ss_cte.Enabled = False
                rf_cfop_cte.Enabled = False
                rf_protocolo_cte.Enabled = False
                rf_uf_origem_cte.Enabled = False
                rf_uf_destino_cte.Enabled = False
                rf_ibge_origem_cte.Enabled = False
                rf_ibge_destino_cte.Enabled = False
            End If
            'fran 03/2017 f


            If (nfiscal.nr_nota_fiscal > 0) Then
                txt_nr_nota_fiscal.Text = nfiscal.nr_nota_fiscal
                'fran 01/06/2011 chamado 1272 - deixar como antes i
                '' Adriana 15/02/2011 - chamado 1186 - Somente desabilitar campo se a Nota Fiscal já foi exportada para o EMS - i
                ''txt_nr_nota_fiscal.Enabled = False
                'If nfiscal.st_exportacao = "S" Then
                '    txt_nr_nota_fiscal.Enabled = False
                'Else
                '    txt_nr_nota_fiscal.Enabled = True
                'End If
                '' Adriana 15/02/2011 - chamado 1186 - Somente desabilitar campo se a Nota Fiscal já foi exportada para o EMS - f
                txt_nr_nota_fiscal.Enabled = False
                'fran 01/06/2011 chamado 1272 - deixar como antes f

            End If
            txt_nr_serie_nota_fiscal.Text = nfiscal.nr_serie
            If Not (nfiscal.dt_emissao Is Nothing) Then
                txt_dt_emissao_nota_fiscal.Text = DateTime.Parse(nfiscal.dt_emissao).ToString("dd/MM/yyyy")
            End If
            If Not (nfiscal.dt_transacao Is Nothing) Then
                txt_dt_transacao.Text = DateTime.Parse(nfiscal.dt_transacao).ToString("dd/MM/yyyy")
            Else
                txt_dt_transacao.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            End If

            If (nfiscal.id_situacao > 0) Then
                cbo_situacao.SelectedValue = nfiscal.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            'fran 21/10/2011 i
            cbo_tipo_nota_fiscal.SelectedValue = nfiscal.id_tipo_nota_fiscal.ToString


            ViewState.Item("atualizar_romaneio") = "N" 'fran 01/06/2011 chamado 1272

            'fran 05/11/2010 i gko item 2
            If nfiscal.id_romaneio > 0 Then
                tr_id_romaneio.Visible = True
                tr_exportacao_frete.Visible = True
                tr_exportacao_frete_dt.Visible = True

                lbl_id_romaneio.Text = nfiscal.id_romaneio.ToString
                If Not (nfiscal.id_natureza_operacao > 0) Or Not (nfiscal.id_natureza_operacao > 0) Then
                    lk_duplicata.Enabled = False
                    lk_itens_nota.Enabled = False
                Else
                    lk_duplicata.Enabled = True
                    lk_itens_nota.Enabled = True
                End If
                'fran 01/06/2011 chamado 1272 - se é nota de romaneio i
                'fran 11/2011 i
                If nfiscal.id_tipo_nota_fiscal = 4 Then 'se é tipo de nota fiscal de rateio
                    lk_rateio.Enabled = True
                Else
                    lk_rateio.Enabled = False
                End If
                'fran 11/2011 f

                'fran 03/2017 i
                'Dados 2a nota
                tr_dados_nota2.Visible = True
                If nfiscal.id_tipo_nota_fiscal2.Equals(0) Then
                    txt_nr_nota2.Text = String.Empty
                    txt_serie_nota2.Text = String.Empty
                    txt_nr_valor_nota2.Text = String.Empty
                    txt_nr_litros_nota2.Text = String.Empty
                    cbo_tipo_nota2.SelectedValue = String.Empty
                Else
                    txt_nr_nota2.Text = nfiscal.nr_nota_fiscal2.ToString
                    txt_serie_nota2.Text = nfiscal.nr_serie_nota_fiscal2.ToString
                    txt_nr_valor_nota2.Text = nfiscal.nr_valor_nota_fiscal2
                    txt_nr_litros_nota2.Text = nfiscal.nr_litros_nota_fiscal2
                    cbo_tipo_nota2.SelectedValue = nfiscal.id_tipo_nota_fiscal2
                End If
                'fran 03/2017 f

                'se nota exportada ao EMS
                If nfiscal.st_exportacao = "S" Then
                    txt_nr_nota_fiscal.Enabled = False 'não pode alterar
                Else
                    Dim romaneio As New Romaneio(nfiscal.id_romaneio)
                    'se já fez exportação de frete
                    If Not (romaneio.st_exportacao_frete Is Nothing) Then
                        If romaneio.st_exportacao_frete.ToString.Trim.Equals("S") Then
                            txt_nr_nota_fiscal.Enabled = False 'não pode alterar
                            lbl_dt_exportacao_frete.Text = DateTime.Parse(romaneio.dt_exportacao_frete).ToString("dd/MM/yyyy HH:mm")
                            lbl_exportacao_frete.Text = "Executada"
                        Else
                            txt_nr_nota_fiscal.Enabled = True 'pode alterar
                            ViewState.Item("atualizar_romaneio") = "S"
                            lbl_dt_exportacao_frete.Text = String.Empty
                            lbl_exportacao_frete.Text = "Não Executada"

                        End If
                    Else
                        txt_nr_nota_fiscal.Enabled = True 'pode alterar
                        ViewState.Item("atualizar_romaneio") = "S"
                        lbl_dt_exportacao_frete.Text = String.Empty
                        lbl_exportacao_frete.Text = "Não Executada"
                    End If

                    'se é cooperativa e a entrada é automatica... a nota nao pode ser alterada
                    If romaneio.id_cooperativa > 0 Then
                        If romaneio.st_tipo_romaneio_cooperativa.Equals("A") Then
                            lbl_informativo_romaneio.Text = "*Romaneio de Cooperativa com Abertura Automática de Nota Fiscal."
                            ViewState.Item("atualizar_romaneio") = "N"
                            cbo_estabelecimento.Enabled = False
                            cbo_tipo_nota_fiscal.Enabled = False
                            txt_cd_pessoa.Enabled = False
                            btn_lupa_produtor.Visible = False
                            txt_cnpj.Enabled = False
                            cbo_natureza_operacao.Enabled = False
                            txt_nr_nota_fiscal.Enabled = False
                            txt_nr_serie_nota_fiscal.Enabled = False
                            txt_dt_emissao_nota_fiscal.Enabled = False
                            txt_ds_chave_nfe.Enabled = False
                            txt_nr_valor_icms.Enabled = False
                            cbo_id_frete.Enabled = False
                            txt_nr_cte.Enabled = False
                            txt_serie_cte.Enabled = False
                            txt_nr_valor_cte.Enabled = False
                            txt_ds_chave_cte.Enabled = False
                            If Not cbo_CST_cte.SelectedValue.Equals(String.Empty) Then
                                cbo_CST_cte.Enabled = False
                                If cbo_CST_cte.SelectedValue = "40" Then
                                    txt_nr_icms_cte.Enabled = False
                                Else
                                    If txt_nr_icms_cte.Text.Equals(String.Empty) OrElse CDec(txt_nr_icms_cte.Text) = 0 Then
                                        txt_nr_icms_cte.Enabled = True
                                    Else
                                        txt_nr_icms_cte.Enabled = False
                                    End If
                                End If
                            Else
                                If nfiscal.id_frete_nf.Equals(2) Then
                                    cbo_CST_cte.Enabled = True
                                    txt_nr_icms_cte.Enabled = True
                                Else
                                    cbo_CST_cte.Enabled = False
                                    txt_nr_icms_cte.Enabled = False
                                End If
                            End If


                        Else
                            lbl_informativo_romaneio.Text = "*Romaneio de Cooperativa com Abertura Manual de Nota Fiscal."

                        End If

                    End If
                End If
                'fran 01/06/2011 chamado 1272 - se é nota de romaneio f


            Else
                lbl_id_romaneio.Text = String.Empty
                tr_id_romaneio.Visible = False
                tr_dados_nota2.Visible = False
                tr_exportacao_frete.Visible = False
                tr_exportacao_frete_dt.Visible = False
            End If

            txt_ds_chave_nfe.Text = nfiscal.ds_chave_nfe

            If nfiscal.nr_valor_icms > 0 Then
                'txt_nr_valor_icms.Text = FormatCurrency(nfiscal.nr_valor_icms, 2).ToString
                txt_nr_valor_icms.Text = nfiscal.nr_valor_icms   '  adri 19/01/2011 - Erro depois no update devido à formatação
            End If

            'fran 05/11/2010 f gko item 2

            lbl_modificador.Text = nfiscal.id_modificador.ToString()
            lbl_dt_modificacao.Text = nfiscal.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid() Then
            Try

                Dim nfiscal As New NotaFiscal()

                If Not (txt_cd_pessoa.Text.Trim.Equals(String.Empty)) Then
                    nfiscal.id_pessoa = Convert.ToInt32(hf_id_pessoa.Value)
                End If
                If Not (cbo_natureza_operacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    nfiscal.id_natureza_operacao = Convert.ToInt32(cbo_natureza_operacao.SelectedValue)
                End If
                If Not (txt_nr_nota_fiscal.Text.Trim().Equals(String.Empty)) Then
                    nfiscal.nr_nota_fiscal = txt_nr_nota_fiscal.Text.ToString
                End If
                nfiscal.nr_serie = txt_nr_serie_nota_fiscal.Text
                nfiscal.dt_emissao = txt_dt_emissao_nota_fiscal.Text
                nfiscal.dt_transacao = txt_dt_transacao.Text
                If Not (cbo_id_frete.SelectedValue.Trim().Equals(String.Empty)) Then
                    nfiscal.id_frete_nf = Convert.ToInt32(cbo_id_frete.SelectedValue)
                End If

                'fran 03/2017 - inclusao de dados da nota fiscal i
                If nfiscal.id_frete_nf.Equals(2) Then 'se FOB
                    nfiscal.nr_cte = Convert.ToInt32(txt_nr_cte.Text)
                    nfiscal.nr_serie_cte = txt_serie_cte.Text
                    nfiscal.nr_valor_cte = txt_nr_valor_cte.Text
                    nfiscal.ds_chave_cte = txt_ds_chave_cte.Text.Trim
                    nfiscal.cd_cst_cte = cbo_CST_cte.SelectedValue
                    If txt_nr_icms_cte.Text.Equals(String.Empty) Then
                        nfiscal.nr_valor_icms_cte = 0
                    Else
                        nfiscal.nr_valor_icms_cte = txt_nr_icms_cte.Text
                    End If
                    If txt_base_icms_cte.Text.Equals(String.Empty) Then
                        nfiscal.nr_base_icms_cte = 0
                    Else
                        nfiscal.nr_base_icms_cte = Convert.ToDecimal(txt_base_icms_cte.Text)
                    End If
                    nfiscal.dt_emissao_completa_cte = txt_dt_emissao_cte.Text & " " & txt_hr_emissao_cte.Text & ":" & txt_mm_emissao_cte.Text & ":00" & ":" & txt_ss_emissao_cte.Text & ":00"
                    nfiscal.cd_cfop_cte = txt_cd_cfop_cte.Text
                    nfiscal.ds_protocolo_cte = txt_protocolo_cte.Text
                    nfiscal.cd_uf_origem_cte = txt_uf_origem_cte.Text
                    nfiscal.cd_uf_destino_cte = txt_uf_destino_cte.Text
                    nfiscal.cd_ibge_origem_cte = txt_ibge_origem_cte.Text
                    nfiscal.cd_ibge_destino_cte = txt_ibge_destino_cte.Text

                Else
                    nfiscal.nr_cte = 0
                    nfiscal.nr_serie_cte = String.Empty
                    nfiscal.nr_valor_cte = 0
                    nfiscal.ds_chave_cte = String.Empty
                    nfiscal.cd_cst_cte = String.Empty
                    nfiscal.nr_valor_icms_cte = 0
                    nfiscal.nr_base_icms_cte = 0
                    nfiscal.dt_emissao_completa_cte = String.Empty
                    nfiscal.cd_cfop_cte = String.Empty
                    nfiscal.ds_protocolo_cte = String.Empty
                    nfiscal.cd_uf_origem_cte = String.Empty
                    nfiscal.cd_uf_destino_cte = String.Empty
                    nfiscal.cd_ibge_origem_cte = String.Empty
                    nfiscal.cd_ibge_destino_cte = String.Empty

                End If

                If cbo_tipo_nota2.SelectedValue.Equals(String.Empty) Then
                    nfiscal.id_tipo_nota_fiscal2 = 0
                    nfiscal.nr_nota_fiscal2 = String.Empty
                    nfiscal.nr_serie_nota_fiscal2 = String.Empty
                    nfiscal.nr_litros_nota_fiscal2 = 0
                    nfiscal.nr_valor_nota_fiscal2 = 0
                Else
                    nfiscal.id_tipo_nota_fiscal2 = cbo_tipo_nota2.SelectedValue
                    nfiscal.nr_nota_fiscal2 = txt_nr_nota2.Text.ToString
                    nfiscal.nr_serie_nota_fiscal2 = txt_serie_nota2.Text.ToString
                    nfiscal.nr_valor_nota_fiscal2 = Convert.ToDecimal(txt_nr_valor_nota2.Text)
                    nfiscal.nr_litros_nota_fiscal2 = Convert.ToDecimal(txt_nr_litros_nota2.Text)

                End If
                'fran 03/2017 - inclusao de dados da nota fiscal f


                If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then
                    nfiscal.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                End If

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    nfiscal.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If
                nfiscal.id_modificador = Session("id_login")
                'fran 05/11/2010 i gko item 2
                nfiscal.ds_chave_nfe = txt_ds_chave_nfe.Text
                If Not txt_nr_valor_icms.Text.ToString.Equals(String.Empty) Then
                    nfiscal.nr_valor_icms = Convert.ToDecimal(txt_nr_valor_icms.Text)
                End If
                'fran 05/11/2010 f gko item 2
                'fran 21/10/2011 i
                If Not (cbo_tipo_nota_fiscal.SelectedValue.trim().equals(String.Empty)) Then
                    nfiscal.id_tipo_nota_fiscal = Convert.ToInt32(cbo_tipo_nota_fiscal.SelectedValue)

                End If
                If Not (ViewState.Item("id_nota_fiscal") Is Nothing) Then

                    nfiscal.id_nota_fiscal = Convert.ToInt32(ViewState.Item("id_nota_fiscal"))
                    nfiscal.updateNotaFiscal()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 25
                    usuariolog.id_nr_processo = ViewState.Item("id_nota_fiscal")
                    usuariolog.nm_nr_processo = nfiscal.nr_nota_fiscal.ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    'fran chamado 1272 i
                    If ViewState.Item("atualizar_romaneio") = "S" Then
                        'atualiza as notas de romaneio para exportação de frete 
                        Dim romaneio As New Romaneio
                        romaneio.id_romaneio = Convert.ToInt32(lbl_id_romaneio.Text)
                        romaneio.nr_nota_fiscal = nfiscal.nr_nota_fiscal
                        romaneio.nr_serie_nota_fiscal = nfiscal.nr_serie
                        romaneio.dt_saida_nota = nfiscal.dt_emissao
                        romaneio.id_modificador = nfiscal.id_modificador
                        romaneio.updateRomaneioNota()

                        messageControl.Alert("Registro alterado com sucesso. Sr. Usuário, como a Exportação de Frete ainda não foi executada, qualquer manutenção neste documento será enviada ao Frete.")
                    Else
                        messageControl.Alert("Registro alterado com sucesso. Sr. Usuário, qualquer manutenção neste documento não será enviada ao Frete porque a Exportação de Frete já foi executada.")
                    End If
                    'fran chamado 1272 f

                    'messageControl.Alert("Registro alterado com sucesso. Sr. Usuário, qualquer manutenção neste documento não será enviada ao EMS.")
                    ' messageControl.Alert("Registro alterado com sucesso. Sr. Usuário, qualquer manutenção neste documento não será enviada ao Frete.")

                Else

                    ViewState.Item("id_nota_fiscal") = nfiscal.insertNotaFiscal()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 25
                    usuariolog.id_nr_processo = ViewState.Item("id_nota_fiscal")
                    usuariolog.nm_nr_processo = nfiscal.nr_nota_fiscal.ToString

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
        Response.Redirect("lst_nota_fiscal.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_nota_fiscal.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Public Sub New()

    End Sub

    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Visible = True
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub cv_cooperativa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_produtor.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidpessoa As Int32

            'pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)

            If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
            'lidpessoa = pessoa.validarCooperativa   
            lidpessoa = pessoa.validarProdutor      ' 06/10/2008

            If lidpessoa > 0 Then
                args.IsValid = True
                hf_id_pessoa.Value = lidpessoa
            Else
                hf_id_pessoa.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Emitente não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub


    Protected Sub lk_itens_nota_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_itens_nota.Click
        Response.Redirect("frm_item_nota_fiscal.aspx?id_nota_fiscal=" + ViewState.Item("id_nota_fiscal").ToString)

    End Sub

    Protected Sub lk_duplicata_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_duplicata.Click
        Response.Redirect("frm_duplicata.aspx?id_nota_fiscal=" + ViewState.Item("id_nota_fiscal").ToString)
    End Sub

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        'If Not (Me.cbo_estabelecimento.SelectedValue.ToString.Equals(String.Empty)) Then
        If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposProdutor()
            Dim pessoa As New Pessoa(Convert.ToInt32(hf_id_pessoa.Value))
            txt_cnpj.Text = pessoa.cd_cnpj
            'cbo_estabelecimento.SelectedValue = pessoa.id_estabelecimento
        Else
            txt_cd_pessoa.Text = String.Empty
            hf_id_pessoa.Value = String.Empty
            lbl_nm_pessoa.Text = String.Empty
            lbl_nm_pessoa.Visible = False
        End If
        'End If

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        lbl_nm_pessoa.Visible = False
        hf_id_pessoa.Value = String.Empty
        txt_cnpj.Text = String.Empty
        If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
            Dim pessoa As New Pessoa()

            'If Not cbo_estabelecimento.SelectedValue.Equals(String.Empty) Then
            'pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            'End If
            pessoa.cd_pessoa = Me.txt_cd_pessoa.Text.Trim

            'Dim dspessoa As DataSet = pessoa.getCooperativasByCodigo
            Dim dspessoa As DataSet = pessoa.getPessoaByFilters     ' 06/10/2008
            If dspessoa.Tables(0).Rows.Count > 0 Then
                With dspessoa.Tables(0).Rows(0)
                    lbl_nm_pessoa.Visible = True
                    lbl_nm_pessoa.Text = .Item("nm_pessoa").ToString
                    hf_id_pessoa.Value = .Item("id_pessoa").ToString
                    txt_cnpj.Text = .Item("cd_cnpj")
                    'cbo_estabelecimento.SelectedValue = .Item("id_estabelecimento")
                End With
            End If

        End If

    End Sub

    Protected Sub txt_cnpj_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cnpj.TextChanged
        'If Not txt_cnpj.Text.Equals(String.Empty) Then
        '    Dim pessoa As New Pessoa()

        '    'If Not cbo_estabelecimento.SelectedValue.Equals(String.Empty) Then
        '    'pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
        '    'End If
        '    pessoa.cd_cnpj = Me.txt_cnpj.Text.Trim

        '    'Dim dspessoa As DataSet = pessoa.getCooperativasByFilters
        '    Dim dspessoa As DataSet = pessoa.getPessoaByFilters()   ' 06/10/2008
        '    If dspessoa.Tables(0).Rows.Count > 0 Then
        '        With dspessoa.Tables(0).Rows(0)
        '            lbl_nm_pessoa.Visible = True
        '            lbl_nm_pessoa.Text = .Item("nm_pessoa").ToString
        '            hf_id_pessoa.Value = .Item("id_pessoa").ToString
        '            txt_cd_pessoa.Text = .Item("cd_pessoa")
        '            'cbo_estabelecimento.SelectedValue = .Item("id_estabelecimento")
        '        End With
        '    End If

        'End If
    End Sub
    'Private Sub carregarCamposCooperativa()

    '    Try



    '        If Not (customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").Equals(String.Empty)) Then
    '            Me.lbl_nm_pessoa.Visible = True
    '            Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").ToString
    '        End If

    '        If Not (customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").Equals(String.Empty)) Then
    '            Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").ToString
    '        End If

    '        'loadData()
    '        customPage.clearFilters("lupa_cooperativa")


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    Protected Sub cv_cnpj_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_cnpj.ServerValidate
        If Not txt_cnpj.Text.Equals(String.Empty) Then

            Dim pessoa As New Pessoa()
            pessoa.cd_cnpj = Me.txt_cnpj.Text.Trim

            Dim dspessoa As DataSet = pessoa.getPessoaByFilters()   ' 06/10/2008
            If dspessoa.Tables(0).Rows.Count > 0 Then
                'If txt_cd_pessoa.Text <> dspessoa.Tables(0).Rows(0).Item("cd_pessoa") Then  
                '    args.IsValid = False
                '    messageControl.Alert("CNPJ não pertence ao emitente.")
                'Else
                args.IsValid = True
                lbl_nm_pessoa.Visible = True
                lbl_nm_pessoa.Text = dspessoa.Tables(0).Rows(0).Item("nm_pessoa").ToString
                hf_id_pessoa.Value = dspessoa.Tables(0).Rows(0).Item("id_pessoa").ToString
                txt_cd_pessoa.Text = dspessoa.Tables(0).Rows(0).Item("cd_pessoa")
                'End If

            Else
                args.IsValid = False
                lbl_nm_pessoa.Text = ""
                hf_id_pessoa.Value = String.Empty
                txt_cd_pessoa.Text = ""
                messageControl.Alert("CNPJ não cadastrado.")
            End If


        End If

    End Sub

    Protected Sub cv_data_transacao_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_data_transacao.ServerValidate
        If Not txt_dt_transacao.Text.Equals(String.Empty) Then

            Dim data_ini As String
            Dim data_fim As String

            data_ini = "01/" & DateTime.Parse(Now).ToString("MM/yyyy")
            data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(data_ini)))
            If Convert.ToDateTime(txt_dt_transacao.Text) < Convert.ToDateTime(data_ini) Or Convert.ToDateTime(txt_dt_transacao.Text) > Convert.ToDateTime(data_fim) Then  ' Se Data de Transferência não estiver dentro do mes
                args.IsValid = False
                messageControl.Alert("A alteração não é permitida fora do mes corrente.")
            End If
        End If
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_nota_fiscal.aspx")

    End Sub

    Protected Sub cv_ds_chave_nfe_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_ds_chave_nfe.ServerValidate
        ' Adriana 16/02/2011 - chamado 1185 - Obrigar exatamente 44 posições (campo não é obrigatório) - i
        If Trim(Me.txt_ds_chave_nfe.Text) <> "" And Len(Me.txt_ds_chave_nfe.Text) <> 44 Then
            args.IsValid = False
            messageControl.Alert("Deve ser informado 44 dígitos para o campo Chave Acesso NF-e.")
        End If
        ' Adriana 16/02/2011 - chamado 1185 - Obrigar exatamente 44 posições - f

    End Sub

    Protected Sub cbo_tipo_nota_fiscal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_nota_fiscal.SelectedIndexChanged
        'se é uma nota do tipo rateio
        If cbo_tipo_nota_fiscal.SelectedValue = "4" Then

        End If
    End Sub

    Protected Sub cbo_id_frete_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_id_frete.SelectedIndexChanged
        Try

            If cbo_id_frete.SelectedValue.Equals("2") Then 'SE FOB  informa cte
                txt_nr_cte.Text = String.Empty
                txt_serie_cte.Text = String.Empty
                txt_nr_valor_cte.Text = String.Empty
                txt_ds_chave_cte.Text = String.Empty
                cbo_CST_cte.SelectedValue = String.Empty
                txt_nr_icms_cte.Text = String.Empty
                txt_nr_cte.Enabled = True
                txt_serie_cte.Enabled = True
                txt_nr_valor_cte.Enabled = True
                txt_ds_chave_cte.Enabled = True
                cbo_CST_cte.Enabled = True
                txt_nr_icms_cte.Enabled = True
                rf_nr_cte.Enabled = True
                rf_serie_cte.Enabled = True
                rf_nr_valor_cte.Enabled = True
                rf_ds_chave_cte.Enabled = True
                rf_cst_cte.Enabled = True
                rf_icms_cte.Enabled = False
            Else
                txt_nr_cte.Enabled = False
                txt_nr_valor_cte.Enabled = False
                txt_ds_chave_cte.Enabled = False
                txt_serie_cte.Enabled = False
                cbo_CST_cte.Enabled = False
                txt_nr_icms_cte.Enabled = False
                rf_nr_cte.Enabled = False
                rf_nr_valor_cte.Enabled = False
                rf_ds_chave_cte.Enabled = False
                rf_serie_cte.Enabled = False
                rf_cst_cte.Enabled = False
                rf_icms_cte.Enabled = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub cbo_tipo_nota2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_nota2.SelectedIndexChanged
        Try

            'se tipo nota 2 = selecione
            If cbo_tipo_nota2.SelectedValue.Equals(String.Empty) Then
                'nao obriga informações e limpa texto
                rf_nr_nota2.Enabled = False
                rf_nr_litros_nota2.Enabled = False
                rf_valornota2.Enabled = False
                txt_nr_nota2.Text = String.Empty
                txt_serie_nota2.Text = String.Empty
                txt_nr_litros_nota2.Text = String.Empty
                txt_nr_valor_nota2.Text = String.Empty
            Else
                'obriga informações e limpa texto
                rf_nr_nota2.Enabled = True
                rf_nr_litros_nota2.Enabled = True
                rf_valornota2.Enabled = True

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub cbo_CST_cte_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_CST_cte.SelectedIndexChanged
        Try

            If cbo_CST_cte.SelectedValue.Equals("40") Then 'SE for ISENTO ICMS
                txt_nr_icms_cte.Text = String.Empty
                txt_nr_icms_cte.Enabled = False
                rf_icms_cte.Enabled = False
            Else
                txt_nr_icms_cte.Enabled = True
                rf_icms_cte.Enabled = True
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try


    End Sub
End Class
