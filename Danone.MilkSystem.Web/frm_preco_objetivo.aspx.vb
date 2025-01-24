Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_preco_objetivo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_preco_objetivo.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

        With bt_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Técnicos"
        End With

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

            'fran 07/2018 DANGO 2018 i - desabilitar deve ficar apenas adicional de mercado
            'cbo_mes.Items.Add(New ListItem("Janeiro", "01"))
            'cbo_mes.Items.Add(New ListItem("Fevereiro", "02"))
            'cbo_mes.Items.Add(New ListItem("Março", "03"))
            'cbo_mes.Items.Add(New ListItem("Abril", "04"))
            'cbo_mes.Items.Add(New ListItem("Maio", "05"))
            'cbo_mes.Items.Add(New ListItem("Junho", "06"))
            'cbo_mes.Items.Add(New ListItem("Julho", "07"))
            'cbo_mes.Items.Add(New ListItem("Agosto", "08"))
            'cbo_mes.Items.Add(New ListItem("Setembro", "09"))
            'cbo_mes.Items.Add(New ListItem("Outubro", "10"))
            'cbo_mes.Items.Add(New ListItem("Novembro", "11"))
            'cbo_mes.Items.Add(New ListItem("Dezembro", "12"))

            '' 15/08/2008 - Monta combo de Grupo de Faixas
            'Dim faixa As New FaixaVolume()
            'cbo_grupo_faixas.DataSource = faixa.getFaixaVolumeGrupos()
            'cbo_grupo_faixas.DataTextField = "nm_grupo_faixas"
            'cbo_grupo_faixas.DataValueField = "nr_grupo_faixas"
            'cbo_grupo_faixas.DataBind()
            'cbo_grupo_faixas.Items.Insert(0, New ListItem("[Selecione]", "0"))
            'fran 07/2018 DANGO 2018 f


            If Not (Request("id_preco_objetivo") Is Nothing) Then 'Alteração
                Dim id_preco_objetivo As String = Request("id_preco_objetivo")
                ViewState.Item("id_preco_objetivo") = Convert.ToInt32(id_preco_objetivo)

                loadData()
            Else 'Novo

                txt_ano.Enabled = True
                txt_cd_tecnico.Enabled = True
                lbl_novo.Visible = True


                'Dim dsFaixa As DataSet = faixa.getFaixaVolumeByFilters()
                'Dim nfaixas As Integer = dsFaixa.Tables(0).Rows.Count
                'If nfaixas >= 1 Then
                '    lbl_volume_faixa1.Text = dsFaixa.Tables(0).Rows(0).Item("nm_faixa_volume").ToString()
                '    ViewState("faixa1") = dsFaixa.Tables(0).Rows(0).Item("id_faixa_volume").ToString()
                'End If
                'If nfaixas >= 2 Then
                '    lbl_volume_faixa2.Text = dsFaixa.Tables(0).Rows(1).Item("nm_faixa_volume").ToString()
                '    ViewState("faixa2") = dsFaixa.Tables(0).Rows(1).Item("id_faixa_volume").ToString()
                'End If
                'If nfaixas >= 3 Then
                '    lbl_volume_faixa3.Text = dsFaixa.Tables(0).Rows(2).Item("nm_faixa_volume").ToString()
                '    ViewState("faixa3") = dsFaixa.Tables(0).Rows(2).Item("id_faixa_volume").ToString()
                'End If
                'If nfaixas >= 4 Then
                '    lbl_volume_faixa4.Text = dsFaixa.Tables(0).Rows(3).Item("nm_faixa_volume").ToString()
                '    ViewState("faixa4") = dsFaixa.Tables(0).Rows(3).Item("id_faixa_volume").ToString()
                'End If
                'If nfaixas >= 5 Then
                '    lbl_volume_faixa5.Text = dsFaixa.Tables(0).Rows(4).Item("nm_faixa_volume").ToString()
                '    ViewState("faixa5") = dsFaixa.Tables(0).Rows(4).Item("id_faixa_volume").ToString()
                'End If
                'faixasVisiveis(nfaixas)
                'ViewState("nr_faixas") = nfaixas
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub faixasVisiveis(ByVal nFaixas As Integer)

        'If nFaixas >= 1 Then
        '    lbl_volume_faixa1.Visible = True
        '    txt_adic_vol_f1_01.Visible = True
        '    txt_adic_vol_f1_02.Visible = True
        '    txt_adic_vol_f1_03.Visible = True
        '    txt_adic_vol_f1_04.Visible = True
        '    txt_adic_vol_f1_05.Visible = True
        '    txt_adic_vol_f1_06.Visible = True
        '    txt_adic_vol_f1_07.Visible = True
        '    txt_adic_vol_f1_08.Visible = True
        '    txt_adic_vol_f1_09.Visible = True
        '    txt_adic_vol_f1_10.Visible = True
        '    txt_adic_vol_f1_11.Visible = True
        '    txt_adic_vol_f1_12.Visible = True
        'Else
        '    lbl_volume_faixa1.Visible = False
        '    txt_adic_vol_f1_01.Visible = False
        '    txt_adic_vol_f1_02.Visible = False
        '    txt_adic_vol_f1_03.Visible = False
        '    txt_adic_vol_f1_04.Visible = False
        '    txt_adic_vol_f1_05.Visible = False
        '    txt_adic_vol_f1_06.Visible = False
        '    txt_adic_vol_f1_07.Visible = False
        '    txt_adic_vol_f1_08.Visible = False
        '    txt_adic_vol_f1_09.Visible = False
        '    txt_adic_vol_f1_10.Visible = False
        '    txt_adic_vol_f1_11.Visible = False
        '    txt_adic_vol_f1_12.Visible = False
        'End If

        'If nFaixas >= 2 Then
        '    lbl_volume_faixa2.Visible = True
        '    txt_adic_vol_f2_01.Visible = True
        '    txt_adic_vol_f2_02.Visible = True
        '    txt_adic_vol_f2_03.Visible = True
        '    txt_adic_vol_f2_04.Visible = True
        '    txt_adic_vol_f2_05.Visible = True
        '    txt_adic_vol_f2_06.Visible = True
        '    txt_adic_vol_f2_07.Visible = True
        '    txt_adic_vol_f2_08.Visible = True
        '    txt_adic_vol_f2_09.Visible = True
        '    txt_adic_vol_f2_10.Visible = True
        '    txt_adic_vol_f2_11.Visible = True
        '    txt_adic_vol_f2_12.Visible = True
        'Else
        '    lbl_volume_faixa2.Visible = False
        '    txt_adic_vol_f2_01.Visible = False
        '    txt_adic_vol_f2_02.Visible = False
        '    txt_adic_vol_f2_03.Visible = False
        '    txt_adic_vol_f2_04.Visible = False
        '    txt_adic_vol_f2_05.Visible = False
        '    txt_adic_vol_f2_06.Visible = False
        '    txt_adic_vol_f2_07.Visible = False
        '    txt_adic_vol_f2_08.Visible = False
        '    txt_adic_vol_f2_09.Visible = False
        '    txt_adic_vol_f2_10.Visible = False
        '    txt_adic_vol_f2_11.Visible = False
        '    txt_adic_vol_f2_12.Visible = False
        'End If

        'If nFaixas >= 3 Then
        '    lbl_volume_faixa3.Visible = True
        '    txt_adic_vol_f3_01.Visible = True
        '    txt_adic_vol_f3_02.Visible = True
        '    txt_adic_vol_f3_03.Visible = True
        '    txt_adic_vol_f3_04.Visible = True
        '    txt_adic_vol_f3_05.Visible = True
        '    txt_adic_vol_f3_06.Visible = True
        '    txt_adic_vol_f3_07.Visible = True
        '    txt_adic_vol_f3_08.Visible = True
        '    txt_adic_vol_f3_09.Visible = True
        '    txt_adic_vol_f3_10.Visible = True
        '    txt_adic_vol_f3_11.Visible = True
        '    txt_adic_vol_f3_12.Visible = True
        'Else
        '    lbl_volume_faixa3.Visible = False
        '    txt_adic_vol_f3_01.Visible = False
        '    txt_adic_vol_f3_02.Visible = False
        '    txt_adic_vol_f3_03.Visible = False
        '    txt_adic_vol_f3_04.Visible = False
        '    txt_adic_vol_f3_05.Visible = False
        '    txt_adic_vol_f3_06.Visible = False
        '    txt_adic_vol_f3_07.Visible = False
        '    txt_adic_vol_f3_08.Visible = False
        '    txt_adic_vol_f3_09.Visible = False
        '    txt_adic_vol_f3_10.Visible = False
        '    txt_adic_vol_f3_11.Visible = False
        '    txt_adic_vol_f3_12.Visible = False
        'End If

        'If nFaixas >= 4 Then
        '    lbl_volume_faixa4.Visible = True
        '    txt_adic_vol_f4_01.Visible = True
        '    txt_adic_vol_f4_02.Visible = True
        '    txt_adic_vol_f4_03.Visible = True
        '    txt_adic_vol_f4_04.Visible = True
        '    txt_adic_vol_f4_05.Visible = True
        '    txt_adic_vol_f4_06.Visible = True
        '    txt_adic_vol_f4_07.Visible = True
        '    txt_adic_vol_f4_08.Visible = True
        '    txt_adic_vol_f4_09.Visible = True
        '    txt_adic_vol_f4_10.Visible = True
        '    txt_adic_vol_f4_11.Visible = True
        '    txt_adic_vol_f4_12.Visible = True
        'Else
        '    lbl_volume_faixa4.Visible = False
        '    txt_adic_vol_f4_01.Visible = False
        '    txt_adic_vol_f4_02.Visible = False
        '    txt_adic_vol_f4_03.Visible = False
        '    txt_adic_vol_f4_04.Visible = False
        '    txt_adic_vol_f4_05.Visible = False
        '    txt_adic_vol_f4_06.Visible = False
        '    txt_adic_vol_f4_07.Visible = False
        '    txt_adic_vol_f4_08.Visible = False
        '    txt_adic_vol_f4_09.Visible = False
        '    txt_adic_vol_f4_10.Visible = False
        '    txt_adic_vol_f4_11.Visible = False
        '    txt_adic_vol_f4_12.Visible = False
        'End If

        'If nFaixas >= 5 Then
        '    lbl_volume_faixa5.Visible = True
        '    txt_adic_vol_f5_01.Visible = True
        '    txt_adic_vol_f5_02.Visible = True
        '    txt_adic_vol_f5_03.Visible = True
        '    txt_adic_vol_f5_04.Visible = True
        '    txt_adic_vol_f5_05.Visible = True
        '    txt_adic_vol_f5_06.Visible = True
        '    txt_adic_vol_f5_07.Visible = True
        '    txt_adic_vol_f5_08.Visible = True
        '    txt_adic_vol_f5_09.Visible = True
        '    txt_adic_vol_f5_10.Visible = True
        '    txt_adic_vol_f5_11.Visible = True
        '    txt_adic_vol_f5_12.Visible = True
        'Else
        '    lbl_volume_faixa5.Visible = False
        '    txt_adic_vol_f5_01.Visible = False
        '    txt_adic_vol_f5_02.Visible = False
        '    txt_adic_vol_f5_03.Visible = False
        '    txt_adic_vol_f5_04.Visible = False
        '    txt_adic_vol_f5_05.Visible = False
        '    txt_adic_vol_f5_06.Visible = False
        '    txt_adic_vol_f5_07.Visible = False
        '    txt_adic_vol_f5_08.Visible = False
        '    txt_adic_vol_f5_09.Visible = False
        '    txt_adic_vol_f5_10.Visible = False
        '    txt_adic_vol_f5_11.Visible = False
        '    txt_adic_vol_f5_12.Visible = False
        'End If

    End Sub

    Private Sub loadData()

        Try


            Dim id_preco_objetivo As Int32 = Convert.ToInt32(ViewState.Item("id_preco_objetivo"))
            Dim precoobjetivo As New PrecoObjetivo(id_preco_objetivo)

            txt_ano.Text = precoobjetivo.nr_ano.ToString

            txt_cd_tecnico.Text = Convert.ToString(precoobjetivo.id_tecnico)
            lbl_nm_tecnico.Visible = True
            lbl_nm_tecnico.Text = precoobjetivo.nm_tecnico.ToString
            hf_id_tecnico.Value = Convert.ToString(precoobjetivo.id_tecnico)
            txt_ano.Enabled = False
            txt_cd_tecnico.Enabled = False
            bt_lupa_tecnico.Visible = False

            'fran 07/2018 DANGO 2018 i - desabilitar deve ficar apenas adicional de mercado
            'Traz preco base
            'txt_preco_base_01.Text = precoobjetivo.nr_preco_base(0).ToString()
            'txt_preco_base_02.Text = precoobjetivo.nr_preco_base(1).ToString()
            'txt_preco_base_03.Text = precoobjetivo.nr_preco_base(2).ToString()
            'txt_preco_base_04.Text = precoobjetivo.nr_preco_base(3).ToString()
            'txt_preco_base_05.Text = precoobjetivo.nr_preco_base(4).ToString()
            'txt_preco_base_06.Text = precoobjetivo.nr_preco_base(5).ToString()
            'txt_preco_base_07.Text = precoobjetivo.nr_preco_base(6).ToString()
            'txt_preco_base_08.Text = precoobjetivo.nr_preco_base(7).ToString()
            'txt_preco_base_09.Text = precoobjetivo.nr_preco_base(8).ToString()
            'txt_preco_base_10.Text = precoobjetivo.nr_preco_base(9).ToString()
            'txt_preco_base_11.Text = precoobjetivo.nr_preco_base(10).ToString()
            'txt_preco_base_12.Text = precoobjetivo.nr_preco_base(11).ToString()

            ''Traz adicional região
            'txt_adic_reg_01.Text = precoobjetivo.nr_adic_regiao(0).ToString()
            'txt_adic_reg_02.Text = precoobjetivo.nr_adic_regiao(1).ToString()
            'txt_adic_reg_03.Text = precoobjetivo.nr_adic_regiao(2).ToString()
            'txt_adic_reg_04.Text = precoobjetivo.nr_adic_regiao(3).ToString()
            'txt_adic_reg_05.Text = precoobjetivo.nr_adic_regiao(4).ToString()
            'txt_adic_reg_06.Text = precoobjetivo.nr_adic_regiao(5).ToString()
            'txt_adic_reg_07.Text = precoobjetivo.nr_adic_regiao(6).ToString()
            'txt_adic_reg_08.Text = precoobjetivo.nr_adic_regiao(7).ToString()
            'txt_adic_reg_09.Text = precoobjetivo.nr_adic_regiao(8).ToString()
            'txt_adic_reg_10.Text = precoobjetivo.nr_adic_regiao(9).ToString()
            'txt_adic_reg_11.Text = precoobjetivo.nr_adic_regiao(10).ToString()
            'txt_adic_reg_12.Text = precoobjetivo.nr_adic_regiao(11).ToString()
            'fran 07/2018 DANGO 2018 f - desabilitar deve ficar apenas adicional de mercado

            'Traz adicional mercado
            txt_adic_merc_01.Text = precoobjetivo.nr_adic_mercado(0).ToString()
            txt_adic_merc_02.Text = precoobjetivo.nr_adic_mercado(1).ToString()
            txt_adic_merc_03.Text = precoobjetivo.nr_adic_mercado(2).ToString()
            txt_adic_merc_04.Text = precoobjetivo.nr_adic_mercado(3).ToString()
            txt_adic_merc_05.Text = precoobjetivo.nr_adic_mercado(4).ToString()
            txt_adic_merc_06.Text = precoobjetivo.nr_adic_mercado(5).ToString()
            txt_adic_merc_07.Text = precoobjetivo.nr_adic_mercado(6).ToString()
            txt_adic_merc_08.Text = precoobjetivo.nr_adic_mercado(7).ToString()
            txt_adic_merc_09.Text = precoobjetivo.nr_adic_mercado(8).ToString()
            txt_adic_merc_10.Text = precoobjetivo.nr_adic_mercado(9).ToString()
            txt_adic_merc_11.Text = precoobjetivo.nr_adic_mercado(10).ToString()
            txt_adic_merc_12.Text = precoobjetivo.nr_adic_mercado(11).ToString()

            'Traz adicionais volume

            '15/08/2008
            'fran 07/2018 DANGO 2018 i - desabilitar deve ficar apenas adicional de mercado
            'Dim faixa As New FaixaVolume(precoobjetivo.id_faixa_volume(0))
            'If (faixa.nr_grupo_faixas > 0) Then
            '    cbo_grupo_faixas.SelectedValue = faixa.nr_grupo_faixas.ToString()
            '    cbo_grupo_faixas.Enabled = False
            'End If

            'carregaAdicionalVolume()
            'fran 07/2018 DANGO 2018 f - desabilitar deve ficar apenas adicional de mercado

            'If precoobjetivo.nr_faixas >= 1 Then 'Faixa1

            '    Dim faixa As New FaixaVolume(precoobjetivo.id_faixa_volume(0))
            '    Dim dsFaixa As DataSet = faixa.getFaixaVolumeByFilters()
            '    lbl_volume_faixa1.Text = faixa.nm_faixa_volume
            '    ViewState("faixa1") = faixa.id_faixa_volume

            '    txt_adic_vol_f1_01.Text = precoobjetivo.nr_adic_volume(0).ToString()
            '    txt_adic_vol_f1_02.Text = precoobjetivo.nr_adic_volume(1).ToString()
            '    txt_adic_vol_f1_03.Text = precoobjetivo.nr_adic_volume(2).ToString()
            '    txt_adic_vol_f1_04.Text = precoobjetivo.nr_adic_volume(3).ToString()
            '    txt_adic_vol_f1_05.Text = precoobjetivo.nr_adic_volume(4).ToString()
            '    txt_adic_vol_f1_06.Text = precoobjetivo.nr_adic_volume(5).ToString()
            '    txt_adic_vol_f1_07.Text = precoobjetivo.nr_adic_volume(6).ToString()
            '    txt_adic_vol_f1_08.Text = precoobjetivo.nr_adic_volume(7).ToString()
            '    txt_adic_vol_f1_09.Text = precoobjetivo.nr_adic_volume(8).ToString()
            '    txt_adic_vol_f1_10.Text = precoobjetivo.nr_adic_volume(9).ToString()
            '    txt_adic_vol_f1_11.Text = precoobjetivo.nr_adic_volume(10).ToString()
            '    txt_adic_vol_f1_12.Text = precoobjetivo.nr_adic_volume(11).ToString()

            'End If

            'If precoobjetivo.nr_faixas >= 2 Then 'Faixa2

            '    Dim faixa As New FaixaVolume(precoobjetivo.id_faixa_volume(1))
            '    Dim dsFaixa As DataSet = faixa.getFaixaVolumeByFilters()
            '    lbl_volume_faixa2.Text = faixa.nm_faixa_volume
            '    ViewState("faixa2") = faixa.id_faixa_volume

            '    txt_adic_vol_f2_01.Text = precoobjetivo.nr_adic_volume(12).ToString()
            '    txt_adic_vol_f2_02.Text = precoobjetivo.nr_adic_volume(13).ToString()
            '    txt_adic_vol_f2_03.Text = precoobjetivo.nr_adic_volume(14).ToString()
            '    txt_adic_vol_f2_04.Text = precoobjetivo.nr_adic_volume(15).ToString()
            '    txt_adic_vol_f2_05.Text = precoobjetivo.nr_adic_volume(16).ToString()
            '    txt_adic_vol_f2_06.Text = precoobjetivo.nr_adic_volume(17).ToString()
            '    txt_adic_vol_f2_07.Text = precoobjetivo.nr_adic_volume(18).ToString()
            '    txt_adic_vol_f2_08.Text = precoobjetivo.nr_adic_volume(19).ToString()
            '    txt_adic_vol_f2_09.Text = precoobjetivo.nr_adic_volume(20).ToString()
            '    txt_adic_vol_f2_10.Text = precoobjetivo.nr_adic_volume(21).ToString()
            '    txt_adic_vol_f2_11.Text = precoobjetivo.nr_adic_volume(22).ToString()
            '    txt_adic_vol_f2_12.Text = precoobjetivo.nr_adic_volume(23).ToString()

            'End If

            'If precoobjetivo.nr_faixas >= 3 Then 'Faixa3

            '    Dim faixa As New FaixaVolume(precoobjetivo.id_faixa_volume(2))
            '    Dim dsFaixa As DataSet = faixa.getFaixaVolumeByFilters()
            '    lbl_volume_faixa3.Text = faixa.nm_faixa_volume
            '    ViewState("faixa3") = faixa.id_faixa_volume

            '    txt_adic_vol_f3_01.Text = precoobjetivo.nr_adic_volume(24).ToString()
            '    txt_adic_vol_f3_02.Text = precoobjetivo.nr_adic_volume(25).ToString()
            '    txt_adic_vol_f3_03.Text = precoobjetivo.nr_adic_volume(26).ToString()
            '    txt_adic_vol_f3_04.Text = precoobjetivo.nr_adic_volume(27).ToString()
            '    txt_adic_vol_f3_05.Text = precoobjetivo.nr_adic_volume(28).ToString()
            '    txt_adic_vol_f3_06.Text = precoobjetivo.nr_adic_volume(29).ToString()
            '    txt_adic_vol_f3_07.Text = precoobjetivo.nr_adic_volume(30).ToString()
            '    txt_adic_vol_f3_08.Text = precoobjetivo.nr_adic_volume(31).ToString()
            '    txt_adic_vol_f3_09.Text = precoobjetivo.nr_adic_volume(32).ToString()
            '    txt_adic_vol_f3_10.Text = precoobjetivo.nr_adic_volume(33).ToString()
            '    txt_adic_vol_f3_11.Text = precoobjetivo.nr_adic_volume(34).ToString()
            '    txt_adic_vol_f3_12.Text = precoobjetivo.nr_adic_volume(35).ToString()

            'End If

            'If precoobjetivo.nr_faixas >= 4 Then 'Faixa4

            '    Dim faixa As New FaixaVolume(precoobjetivo.id_faixa_volume(3))
            '    Dim dsFaixa As DataSet = faixa.getFaixaVolumeByFilters()
            '    lbl_volume_faixa4.Text = faixa.nm_faixa_volume
            '    ViewState("faixa4") = faixa.id_faixa_volume

            '    txt_adic_vol_f4_01.Text = precoobjetivo.nr_adic_volume(36).ToString()
            '    txt_adic_vol_f4_02.Text = precoobjetivo.nr_adic_volume(37).ToString()
            '    txt_adic_vol_f4_03.Text = precoobjetivo.nr_adic_volume(38).ToString()
            '    txt_adic_vol_f4_04.Text = precoobjetivo.nr_adic_volume(39).ToString()
            '    txt_adic_vol_f4_05.Text = precoobjetivo.nr_adic_volume(40).ToString()
            '    txt_adic_vol_f4_06.Text = precoobjetivo.nr_adic_volume(41).ToString()
            '    txt_adic_vol_f4_07.Text = precoobjetivo.nr_adic_volume(42).ToString()
            '    txt_adic_vol_f4_08.Text = precoobjetivo.nr_adic_volume(43).ToString()
            '    txt_adic_vol_f4_09.Text = precoobjetivo.nr_adic_volume(44).ToString()
            '    txt_adic_vol_f4_10.Text = precoobjetivo.nr_adic_volume(45).ToString()
            '    txt_adic_vol_f4_11.Text = precoobjetivo.nr_adic_volume(46).ToString()
            '    txt_adic_vol_f4_12.Text = precoobjetivo.nr_adic_volume(47).ToString()

            'End If

            'If precoobjetivo.nr_faixas >= 5 Then 'Faixa5

            '    Dim faixa As New FaixaVolume(precoobjetivo.id_faixa_volume(4))
            '    Dim dsFaixa As DataSet = faixa.getFaixaVolumeByFilters()
            '    lbl_volume_faixa5.Text = faixa.nm_faixa_volume
            '    ViewState("faixa5") = faixa.id_faixa_volume

            '    txt_adic_vol_f5_01.Text = precoobjetivo.nr_adic_volume(48).ToString()
            '    txt_adic_vol_f5_02.Text = precoobjetivo.nr_adic_volume(49).ToString()
            '    txt_adic_vol_f5_03.Text = precoobjetivo.nr_adic_volume(50).ToString()
            '    txt_adic_vol_f5_04.Text = precoobjetivo.nr_adic_volume(51).ToString()
            '    txt_adic_vol_f5_05.Text = precoobjetivo.nr_adic_volume(52).ToString()
            '    txt_adic_vol_f5_06.Text = precoobjetivo.nr_adic_volume(53).ToString()
            '    txt_adic_vol_f5_07.Text = precoobjetivo.nr_adic_volume(54).ToString()
            '    txt_adic_vol_f5_08.Text = precoobjetivo.nr_adic_volume(55).ToString()
            '    txt_adic_vol_f5_09.Text = precoobjetivo.nr_adic_volume(56).ToString()
            '    txt_adic_vol_f5_10.Text = precoobjetivo.nr_adic_volume(57).ToString()
            '    txt_adic_vol_f5_11.Text = precoobjetivo.nr_adic_volume(58).ToString()
            '    txt_adic_vol_f5_12.Text = precoobjetivo.nr_adic_volume(59).ToString()

            'End If

            'faixasVisiveis(precoobjetivo.nr_faixas)
            'ViewState("nr_faixas") = precoobjetivo.nr_faixas

            If (precoobjetivo.id_situacao > 0) Then
                cbo_situacao.SelectedValue = precoobjetivo.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = precoobjetivo.id_modificador.ToString()
            lbl_dt_modificacao.Text = precoobjetivo.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub carregarCamposTecnico()

        Try

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If
            Me.txt_cd_tecnico.Text = hf_id_tecnico.Value.ToString
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub updateData()

        If Page.IsValid Then
            Try

                Dim precoobjetivo As New PrecoObjetivo()

                'fran 07/2018 DANGO 2018 i - desabilitar deve ficar apenas adicional de mercado
                ''Carregamento de preços base
                'If Not (txt_preco_base_01.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_preco_base(0) = Convert.ToDouble(txt_preco_base_01.Text)
                'End If

                'If Not (txt_preco_base_02.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_preco_base(1) = Convert.ToDouble(txt_preco_base_02.Text)
                'End If

                'If Not (txt_preco_base_03.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_preco_base(2) = Convert.ToDouble(txt_preco_base_03.Text)
                'End If

                'If Not (txt_preco_base_04.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_preco_base(3) = Convert.ToDouble(txt_preco_base_04.Text)
                'End If

                'If Not (txt_preco_base_05.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_preco_base(4) = Convert.ToDouble(txt_preco_base_05.Text)
                'End If

                'If Not (txt_preco_base_06.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_preco_base(5) = Convert.ToDouble(txt_preco_base_06.Text)
                'End If

                'If Not (txt_preco_base_07.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_preco_base(6) = Convert.ToDouble(txt_preco_base_07.Text)
                'End If

                'If Not (txt_preco_base_08.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_preco_base(7) = Convert.ToDouble(txt_preco_base_08.Text)
                'End If

                'If Not (txt_preco_base_09.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_preco_base(8) = Convert.ToDouble(txt_preco_base_09.Text)
                'End If

                'If Not (txt_preco_base_10.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_preco_base(9) = Convert.ToDouble(txt_preco_base_10.Text)
                'End If

                'If Not (txt_preco_base_11.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_preco_base(10) = Convert.ToDouble(txt_preco_base_11.Text)
                'End If

                'If Not (txt_preco_base_12.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_preco_base(11) = Convert.ToDouble(txt_preco_base_12.Text)
                'End If

                ''Carrega adicionais região
                'If Not (txt_adic_reg_01.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_adic_regiao(0) = Convert.ToDouble(txt_adic_reg_01.Text)
                'End If

                'If Not (txt_adic_reg_02.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_adic_regiao(1) = Convert.ToDouble(txt_adic_reg_02.Text)
                'End If

                'If Not (txt_adic_reg_03.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_adic_regiao(2) = Convert.ToDouble(txt_adic_reg_03.Text)
                'End If

                'If Not (txt_adic_reg_04.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_adic_regiao(3) = Convert.ToDouble(txt_adic_reg_04.Text)
                'End If

                'If Not (txt_adic_reg_05.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_adic_regiao(4) = Convert.ToDouble(txt_adic_reg_05.Text)
                'End If

                'If Not (txt_adic_reg_06.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_adic_regiao(5) = Convert.ToDouble(txt_adic_reg_06.Text)
                'End If

                'If Not (txt_adic_reg_07.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_adic_regiao(6) = Convert.ToDouble(txt_adic_reg_07.Text)
                'End If

                'If Not (txt_adic_reg_08.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_adic_regiao(7) = Convert.ToDouble(txt_adic_reg_08.Text)
                'End If

                'If Not (txt_adic_reg_09.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_adic_regiao(8) = Convert.ToDouble(txt_adic_reg_09.Text)
                'End If

                'If Not (txt_adic_reg_10.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_adic_regiao(9) = Convert.ToDouble(txt_adic_reg_10.Text)
                'End If

                'If Not (txt_adic_reg_11.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_adic_regiao(10) = Convert.ToDouble(txt_adic_reg_11.Text)
                'End If

                'If Not (txt_adic_reg_12.Text.Trim().Equals(String.Empty)) Then
                '    precoobjetivo.nr_adic_regiao(11) = Convert.ToDouble(txt_adic_reg_12.Text)
                'End If
                'fran 07/2018 DANGO 2018 f - desabilitar deve ficar apenas adicional de mercado

                'Carrega adicionais mercardo
                If Not (txt_adic_merc_01.Text.Trim().Equals(String.Empty)) Then
                    precoobjetivo.nr_adic_mercado(0) = Convert.ToDouble(txt_adic_merc_01.Text)
                End If

                If Not (txt_adic_merc_02.Text.Trim().Equals(String.Empty)) Then
                    precoobjetivo.nr_adic_mercado(1) = Convert.ToDouble(txt_adic_merc_02.Text)
                End If

                If Not (txt_adic_merc_03.Text.Trim().Equals(String.Empty)) Then
                    precoobjetivo.nr_adic_mercado(2) = Convert.ToDouble(txt_adic_merc_03.Text)
                End If

                If Not (txt_adic_merc_04.Text.Trim().Equals(String.Empty)) Then
                    precoobjetivo.nr_adic_mercado(3) = Convert.ToDouble(txt_adic_merc_04.Text)
                End If

                If Not (txt_adic_merc_05.Text.Trim().Equals(String.Empty)) Then
                    precoobjetivo.nr_adic_mercado(4) = Convert.ToDouble(txt_adic_merc_05.Text)
                End If

                If Not (txt_adic_merc_06.Text.Trim().Equals(String.Empty)) Then
                    precoobjetivo.nr_adic_mercado(5) = Convert.ToDouble(txt_adic_merc_06.Text)
                End If

                If Not (txt_adic_merc_07.Text.Trim().Equals(String.Empty)) Then
                    precoobjetivo.nr_adic_mercado(6) = Convert.ToDouble(txt_adic_merc_07.Text)
                End If

                If Not (txt_adic_merc_08.Text.Trim().Equals(String.Empty)) Then
                    precoobjetivo.nr_adic_mercado(7) = Convert.ToDouble(txt_adic_merc_08.Text)
                End If

                If Not (txt_adic_merc_09.Text.Trim().Equals(String.Empty)) Then
                    precoobjetivo.nr_adic_mercado(8) = Convert.ToDouble(txt_adic_merc_09.Text)
                End If

                If Not (txt_adic_merc_10.Text.Trim().Equals(String.Empty)) Then
                    precoobjetivo.nr_adic_mercado(9) = Convert.ToDouble(txt_adic_merc_10.Text)
                End If

                If Not (txt_adic_merc_11.Text.Trim().Equals(String.Empty)) Then
                    precoobjetivo.nr_adic_mercado(10) = Convert.ToDouble(txt_adic_merc_11.Text)
                End If

                If Not (txt_adic_merc_12.Text.Trim().Equals(String.Empty)) Then
                    precoobjetivo.nr_adic_mercado(11) = Convert.ToDouble(txt_adic_merc_12.Text)
                End If

                'fran 07/2018 DANGO 2018 i - desabilitar deve ficar apenas adicional de mercado

                '' 15/08/2008 - Carrega adicionais volume
                'Dim li As Integer

                'For li = 0 To gridResults.Rows.Count - 1

                '    precoobjetivo.id_faixa_volume.Add(gridResults.DataKeys(li).Value.ToString)

                '    If CType(gridResults.Rows(li).FindControl("txt_nr_adicional_volume"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text <> "" Then
                '        precoobjetivo.nr_adic_volume.Add(CType(gridResults.Rows(li).FindControl("txt_nr_adicional_volume"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text)
                '    Else
                '        precoobjetivo.nr_adic_volume.Add(0)
                '    End If
                'Next
                'precoobjetivo.nr_faixas = li
                'precoobjetivo.nr_mes = cbo_mes.SelectedValue
                'If cbo_grupo_faixas.Enabled = True Then  ' Se está incluindo um novo mes
                '    precoobjetivo.st_insert_adic_volume = True
                'Else
                '    precoobjetivo.st_insert_adic_volume = False
                'End If
                'fran 07/2018 DANGO 2018 f - desabilitar deve ficar apenas adicional de mercado

                'If precoobjetivo.nr_faixas >= 1 Then 'Faixa1

                '    precoobjetivo.id_faixa_volume(0) = Convert.ToInt32(ViewState("faixa1").ToString())

                '    If Not (txt_adic_vol_f1_01.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(0) = Convert.ToDouble(txt_adic_vol_f1_01.Text)
                '    End If

                '    If Not (txt_adic_vol_f1_02.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(1) = Convert.ToDouble(txt_adic_vol_f1_02.Text)
                '    End If

                '    If Not (txt_adic_vol_f1_03.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(2) = Convert.ToDouble(txt_adic_vol_f1_03.Text)
                '    End If

                '    If Not (txt_adic_vol_f1_04.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(3) = Convert.ToDouble(txt_adic_vol_f1_04.Text)
                '    End If

                '    If Not (txt_adic_vol_f1_05.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(4) = Convert.ToDouble(txt_adic_vol_f1_05.Text)
                '    End If

                '    If Not (txt_adic_vol_f1_06.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(5) = Convert.ToDouble(txt_adic_vol_f1_06.Text)
                '    End If

                '    If Not (txt_adic_vol_f1_07.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(6) = Convert.ToDouble(txt_adic_vol_f1_07.Text)
                '    End If

                '    If Not (txt_adic_vol_f1_08.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(7) = Convert.ToDouble(txt_adic_vol_f1_08.Text)
                '    End If

                '    If Not (txt_adic_vol_f1_09.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(8) = Convert.ToDouble(txt_adic_vol_f1_09.Text)
                '    End If

                '    If Not (txt_adic_vol_f1_10.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(9) = Convert.ToDouble(txt_adic_vol_f1_10.Text)
                '    End If

                '    If Not (txt_adic_vol_f1_11.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(10) = Convert.ToDouble(txt_adic_vol_f1_11.Text)
                '    End If

                '    If Not (txt_adic_vol_f1_12.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(11) = Convert.ToDouble(txt_adic_vol_f1_12.Text)
                '    End If

                'End If

                'If precoobjetivo.nr_faixas >= 2 Then 'Faixa2

                '    precoobjetivo.id_faixa_volume(1) = Convert.ToInt32(ViewState("faixa2").ToString())

                '    If Not (txt_adic_vol_f2_01.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(12) = Convert.ToDouble(txt_adic_vol_f2_01.Text)
                '    End If

                '    If Not (txt_adic_vol_f2_02.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(13) = Convert.ToDouble(txt_adic_vol_f2_02.Text)
                '    End If

                '    If Not (txt_adic_vol_f2_03.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(14) = Convert.ToDouble(txt_adic_vol_f2_03.Text)
                '    End If

                '    If Not (txt_adic_vol_f2_04.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(15) = Convert.ToDouble(txt_adic_vol_f2_04.Text)
                '    End If

                '    If Not (txt_adic_vol_f2_05.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(16) = Convert.ToDouble(txt_adic_vol_f2_05.Text)
                '    End If

                '    If Not (txt_adic_vol_f2_06.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(17) = Convert.ToDouble(txt_adic_vol_f2_06.Text)
                '    End If

                '    If Not (txt_adic_vol_f2_07.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(18) = Convert.ToDouble(txt_adic_vol_f2_07.Text)
                '    End If

                '    If Not (txt_adic_vol_f2_08.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(19) = Convert.ToDouble(txt_adic_vol_f2_08.Text)
                '    End If

                '    If Not (txt_adic_vol_f2_09.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(20) = Convert.ToDouble(txt_adic_vol_f2_09.Text)
                '    End If

                '    If Not (txt_adic_vol_f2_10.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(21) = Convert.ToDouble(txt_adic_vol_f2_10.Text)
                '    End If

                '    If Not (txt_adic_vol_f2_11.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(22) = Convert.ToDouble(txt_adic_vol_f2_11.Text)
                '    End If

                '    If Not (txt_adic_vol_f2_12.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(23) = Convert.ToDouble(txt_adic_vol_f2_12.Text)
                '    End If

                'End If

                'If precoobjetivo.nr_faixas >= 3 Then 'Faixa3

                '    precoobjetivo.id_faixa_volume(2) = Convert.ToInt32(ViewState("faixa3").ToString())

                '    If Not (txt_adic_vol_f3_01.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(24) = Convert.ToDouble(txt_adic_vol_f3_01.Text)
                '    End If

                '    If Not (txt_adic_vol_f3_02.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(25) = Convert.ToDouble(txt_adic_vol_f3_02.Text)
                '    End If

                '    If Not (txt_adic_vol_f3_03.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(26) = Convert.ToDouble(txt_adic_vol_f3_03.Text)
                '    End If

                '    If Not (txt_adic_vol_f3_04.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(27) = Convert.ToDouble(txt_adic_vol_f3_04.Text)
                '    End If

                '    If Not (txt_adic_vol_f3_05.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(28) = Convert.ToDouble(txt_adic_vol_f3_05.Text)
                '    End If

                '    If Not (txt_adic_vol_f3_06.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(29) = Convert.ToDouble(txt_adic_vol_f3_06.Text)
                '    End If

                '    If Not (txt_adic_vol_f3_07.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(30) = Convert.ToDouble(txt_adic_vol_f3_07.Text)
                '    End If

                '    If Not (txt_adic_vol_f3_08.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(31) = Convert.ToDouble(txt_adic_vol_f3_08.Text)
                '    End If

                '    If Not (txt_adic_vol_f3_09.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(32) = Convert.ToDouble(txt_adic_vol_f3_09.Text)
                '    End If

                '    If Not (txt_adic_vol_f3_10.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(33) = Convert.ToDouble(txt_adic_vol_f3_10.Text)
                '    End If

                '    If Not (txt_adic_vol_f3_11.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(34) = Convert.ToDouble(txt_adic_vol_f3_11.Text)
                '    End If

                '    If Not (txt_adic_vol_f3_12.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(35) = Convert.ToDouble(txt_adic_vol_f3_12.Text)
                '    End If

                'End If

                'If precoobjetivo.nr_faixas >= 4 Then 'Faixa4

                '    precoobjetivo.id_faixa_volume(3) = Convert.ToInt32(ViewState("faixa4").ToString())

                '    If Not (txt_adic_vol_f4_01.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(36) = Convert.ToDouble(txt_adic_vol_f4_01.Text)
                '    End If

                '    If Not (txt_adic_vol_f4_02.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(37) = Convert.ToDouble(txt_adic_vol_f4_02.Text)
                '    End If

                '    If Not (txt_adic_vol_f4_03.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(38) = Convert.ToDouble(txt_adic_vol_f4_03.Text)
                '    End If

                '    If Not (txt_adic_vol_f4_04.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(39) = Convert.ToDouble(txt_adic_vol_f4_04.Text)
                '    End If

                '    If Not (txt_adic_vol_f4_05.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(40) = Convert.ToDouble(txt_adic_vol_f4_05.Text)
                '    End If

                '    If Not (txt_adic_vol_f4_06.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(41) = Convert.ToDouble(txt_adic_vol_f4_06.Text)
                '    End If

                '    If Not (txt_adic_vol_f4_07.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(42) = Convert.ToDouble(txt_adic_vol_f4_07.Text)
                '    End If

                '    If Not (txt_adic_vol_f4_08.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(43) = Convert.ToDouble(txt_adic_vol_f4_08.Text)
                '    End If

                '    If Not (txt_adic_vol_f4_09.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(44) = Convert.ToDouble(txt_adic_vol_f4_09.Text)
                '    End If

                '    If Not (txt_adic_vol_f4_10.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(45) = Convert.ToDouble(txt_adic_vol_f4_10.Text)
                '    End If

                '    If Not (txt_adic_vol_f4_11.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(46) = Convert.ToDouble(txt_adic_vol_f4_11.Text)
                '    End If

                '    If Not (txt_adic_vol_f4_12.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(47) = Convert.ToDouble(txt_adic_vol_f4_12.Text)
                '    End If

                'End If

                'If precoobjetivo.nr_faixas >= 5 Then 'Faixa5

                '    precoobjetivo.id_faixa_volume(4) = Convert.ToInt32(ViewState("faixa5").ToString())

                '    If Not (txt_adic_vol_f5_01.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(48) = Convert.ToDouble(txt_adic_vol_f5_01.Text)
                '    End If

                '    If Not (txt_adic_vol_f5_02.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(49) = Convert.ToDouble(txt_adic_vol_f5_02.Text)
                '    End If

                '    If Not (txt_adic_vol_f5_03.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(50) = Convert.ToDouble(txt_adic_vol_f5_03.Text)
                '    End If

                '    If Not (txt_adic_vol_f5_04.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(51) = Convert.ToDouble(txt_adic_vol_f5_04.Text)
                '    End If

                '    If Not (txt_adic_vol_f5_05.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(52) = Convert.ToDouble(txt_adic_vol_f5_05.Text)
                '    End If

                '    If Not (txt_adic_vol_f5_06.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(53) = Convert.ToDouble(txt_adic_vol_f5_06.Text)
                '    End If

                '    If Not (txt_adic_vol_f5_07.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(54) = Convert.ToDouble(txt_adic_vol_f5_07.Text)
                '    End If

                '    If Not (txt_adic_vol_f5_08.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(55) = Convert.ToDouble(txt_adic_vol_f5_08.Text)
                '    End If

                '    If Not (txt_adic_vol_f5_09.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(56) = Convert.ToDouble(txt_adic_vol_f5_09.Text)
                '    End If

                '    If Not (txt_adic_vol_f5_10.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(57) = Convert.ToDouble(txt_adic_vol_f5_10.Text)
                '    End If

                '    If Not (txt_adic_vol_f5_11.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(58) = Convert.ToDouble(txt_adic_vol_f5_11.Text)
                '    End If

                '    If Not (txt_adic_vol_f5_12.Text.Trim().Equals(String.Empty)) Then
                '        precoobjetivo.nr_adic_volume(59) = Convert.ToDouble(txt_adic_vol_f5_12.Text)
                '    End If

                'End If

                precoobjetivo.nr_ano = txt_ano.Text

                precoobjetivo.id_tecnico = txt_cd_tecnico.Text

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    precoobjetivo.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                precoobjetivo.id_modificador = Session("id_login")

                If Page.IsValid Then
                    If Not (ViewState.Item("id_preco_objetivo") Is Nothing) Then

                        precoobjetivo.id_preco_objetivo = Convert.ToInt32(ViewState("id_preco_objetivo").ToString)
                        precoobjetivo.updatePrecoObjetivo()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alteracao
                        usuariolog.id_menu_item = 34
                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro alterado com sucesso.")

                    Else

                        ViewState("id_preco_objetivo") = precoobjetivo.insertPrecoObjetivo()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 4 'inserir
                        usuariolog.id_menu_item = 34
                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro inserido com sucesso.")

                    End If

                    'ViewState("nr_faixas") = precoobjetivo.nr_faixas 'fran 07/2018 DANGO 2018 i - desabilitar deve ficar apenas adicional de mercado

                    loadData()
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_preco_objetivo.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_preco_objetivo.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub cmv_tecnico_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_tecnico.ServerValidate
        Try
            Dim tecnico As New Tecnico()

            tecnico.id_tecnico = Trim(txt_cd_tecnico.Text)
            Dim dstecnico As DataSet = tecnico.getTecnicoByFilters()

            args.IsValid = dstecnico.Tables(0).Rows.Count > 0
            If Not args.IsValid Then
                messageControl.Alert("Técnico não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
        lbl_nm_tecnico.Text = String.Empty
        lbl_nm_tecnico.Visible = False
        hf_id_tecnico.Value = String.Empty
    End Sub


    Protected Sub bt_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_tecnico.Click
        If Not (hf_id_tecnico.Value.Equals(String.Empty)) Then
            lbl_nm_tecnico.Visible = True
            carregarCamposTecnico()
        End If

    End Sub

    Protected Sub cbo_mes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_mes.SelectedIndexChanged
        Try

            ' 15/08/2008  -  Carrega Grid com as faixas para o mes selecionado (se alteracao)
            If Not (Request("id_preco_objetivo") Is Nothing) Then 'Alteração

                carregaAdicionalVolume()

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub carregaAdicionalVolume()
        Try


            Dim precoadicionalvolume As New PrecoAdicionalVolume

            precoadicionalvolume.id_preco_objetivo = ViewState.Item("id_preco_objetivo")
            precoadicionalvolume.nr_mes = cbo_mes.SelectedValue

            Dim dsAdicionalVolume As DataSet = precoadicionalvolume.getAdicionalVolumeByFilters()

            If (dsAdicionalVolume.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsAdicionalVolume.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

                cbo_grupo_faixas.Enabled = False
                lbl_novo.Visible = False
            Else
                gridResults.Visible = False
                cbo_grupo_faixas.Enabled = True
                cbo_grupo_faixas.SelectedValue = 0      ' Selecione
                lbl_novo.Visible = True
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cbo_grupo_faixas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_grupo_faixas.SelectedIndexChanged
        carregaAdicionalVolumeNovo()

    End Sub
    Protected Sub carregaAdicionalVolumeNovo()
        Try

            If cbo_grupo_faixas.SelectedValue > 0 Then
                lbl_novo.Visible = False

                Dim faixavolume As New FaixaVolume

                faixavolume.nr_grupo_faixas = cbo_grupo_faixas.SelectedValue

                Dim dsFaixaVolume As DataSet = faixavolume.getFaixaVolumeByFilters()


                If (dsFaixaVolume.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsFaixaVolume.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                End If
            Else
                gridResults.Visible = False
                lbl_novo.Visible = True
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_preco_objetivo.aspx")

    End Sub
End Class
