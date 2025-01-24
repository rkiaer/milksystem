Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_curvaabc_kpi_qualidade

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("txt_ano") = Me.txt_ano.Text.Trim
        ViewState.Item("id_grupo") = Me.cbo_Grupo.SelectedValue  ' adri 09/02/2017 - chamado 2500 acertos (filtro para Produtores / Cooperativas)

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_curvaabc_kpi_qualidade.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_curvaabc_produtores_complience.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 176
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
        End With
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim codigoesalq As New CodigoEsalq

            estabelecimento.id_situacao = 1 '  adri 08/02/2017 - chamado 2500 - Para trazer somente os ativos
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_estabelecimento.Items.RemoveAt(2)   ' adri 08/02/2017 - Remove Aguas da Prata  -  acertos chamado 2500 

            ' adri 08/02/2017 - acertos chamado 2500 - i
            Dim grupo As New Grupo
            cbo_Grupo.DataSource = grupo.getGruposByFilters()
            cbo_Grupo.DataTextField = "nm_grupo"
            cbo_Grupo.DataValueField = "id_grupo"
            cbo_Grupo.DataBind()
            cbo_Grupo.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_Grupo.Items.RemoveAt(2)   ' Remove item 2-Fornecedor de Insumos
            cbo_Grupo.Items.RemoveAt(2)   ' Remove item 3-Transportador
            cbo_Grupo.SelectedValue = 1   ' Assume como default na consulta o Produtor
            ' adri 08/02/2017 - acertos chamado 2500 - i


            txt_ano.Text = DateTime.Parse(Now).ToString("yyyy")

            ViewState.Item("sortExpression") = ""

            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Private Sub loadData()

        Try
            Dim analiseesalq As New AnaliseEsalq

            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            analiseesalq.dt_referencia_ini = "01/01/" & (ViewState.Item("txt_ano") - 1)
            analiseesalq.dt_referencia_fim = "31/12/" & ViewState.Item("txt_ano")
            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            Else
                analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            End If
            analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)

            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            End If

            Dim dsComplienceSintetico As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceSinteticoKPI()
            'fran 07/2021i
            Dim dsvolumecompl As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalComplienceKPI

            analiseesalq.id_conta_teor = 265  ' conta teor CCS Mensal
            Dim dsccsmes As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI

            analiseesalq.id_conta_teor = 253  ' conta teor CCS trimestral
            Dim dsccstri As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI

            analiseesalq.id_conta_teor = 264  ' conta teor cbt Mensal
            Dim dscbtmes As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI

            analiseesalq.id_conta_teor = 252  ' conta teor cbt tri
            Dim dscbttri As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI

            analiseesalq.id_conta_teor = 251  ' conta teor proteina
            Dim dsproteina As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI

            analiseesalq.id_conta_teor = 156  ' conta teor mg
            Dim dsgordura As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI

            If (dsvolumecompl.Tables(0).Rows.Count > 0) Then

                gridVolumeTotalComplience.Visible = True
                gridVolumeTotalComplience.DataSource = Helper.getDataView(dsvolumecompl.Tables(0), "")
                gridVolumeTotalComplience.DataBind()

                gridCCSMensal.Visible = True
                gridCCSMensal.DataSource = Helper.getDataView(dsccsmes.Tables(0), "")
                gridCCSMensal.DataBind()

                gridCCSTrimestral.Visible = True
                gridCCSTrimestral.DataSource = Helper.getDataView(dsccstri.Tables(0), "")
                gridCCSTrimestral.DataBind()

                gridCBTMensal.Visible = True
                gridCBTMensal.DataSource = Helper.getDataView(dscbtmes.Tables(0), "")
                gridCBTMensal.DataBind()

                gridCBTTrimestral.Visible = True
                gridCBTTrimestral.DataSource = Helper.getDataView(dscbttri.Tables(0), "")
                gridCBTTrimestral.DataBind()

                gridProteinaMensal.Visible = True
                gridProteinaMensal.DataSource = Helper.getDataView(dsproteina.Tables(0), "")
                gridProteinaMensal.DataBind()

                gridGorduraMensal.Visible = True
                gridGorduraMensal.DataSource = Helper.getDataView(dsgordura.Tables(0), "")
                gridGorduraMensal.DataBind()

            End If

            ' Monta grid Volume Rejeitado ATB
            Dim dsVolumeRejeitadoSintetico As DataSet = analiseesalq.getCurvaAbcVolumeLeiteRejeitadoATB()
            If (dsVolumeRejeitadoSintetico.Tables(0).Rows.Count > 0) Then

                gridVolumeRejeitado.Visible = True
                gridVolumeRejeitado.DataSource = Helper.getDataView(dsVolumeRejeitadoSintetico.Tables(0), "")
                gridVolumeRejeitado.DataBind()
            End If

            ' Monta grid Traçado Controlado (somente do ano corrente)
            analiseesalq.dt_referencia_ini = "01/01/" & ViewState.Item("txt_ano")
            analiseesalq.dt_referencia_fim = "31/12/" & ViewState.Item("txt_ano")
            Dim dsVolumeTracadoControlado As DataSet = analiseesalq.getCurvaAbcVolumeTracadoControladoSintetico()
            If (dsVolumeTracadoControlado.Tables(0).Rows.Count > 0) Then

                gridTracadoControlado.Visible = True
                gridTracadoControlado.DataSource = Helper.getDataView(dsVolumeTracadoControlado.Tables(0), "")
                gridTracadoControlado.DataBind()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            Else
                lbl_nm_pessoa.Text = String.Empty
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            Else
                txt_cd_pessoa.Text = String.Empty
                hf_id_pessoa.Value = String.Empty
            End If


            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposPropriedade()

        Try

            Me.lbl_nm_propriedade.Text = String.Empty
            Me.txt_cd_propriedade.Text = String.Empty

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If

            If Not hf_id_propriedade.Value.Equals(String.Empty) AndAlso CInt(hf_id_propriedade.Value.ToString) > 0 Then
                Me.txt_cd_propriedade.Text = Me.hf_id_propriedade.Value.ToString
            Else
                hf_id_propriedade.Value = String.Empty
            End If


            'If Not (customPage.getFilterValue("lupa_propriedade", "cd_pessoa").Equals(String.Empty)) Then
            '    Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "cd_pessoa").ToString
            'End If

            'If Not (customPage.getFilterValue("lupa_propriedade", "nm_pessoa").Equals(String.Empty)) Then
            '    Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "nm_pessoa").ToString
            'End If

            'If Not (customPage.getFilterValue("lupa_propriedade", "id_pessoa").Equals(String.Empty)) Then
            '    Me.hf_id_pessoa.Value = customPage.getFilterValue("lupa_propriedade", "id_pessoa").ToString
            'End If

            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    'Private Sub saveFilters()

    '    Try


    '        customPage.setFilter("analise_esaq", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
    '        customPage.setFilter("analise_esaq", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
    '        customPage.setFilter("analise_esaq", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
    '        customPage.setFilter("analise_esaq", txt_cd_propriedade.ID, ViewState.Item("id_propriedade").ToString)
    '        customPage.setFilter("analise_esaq", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
    '        customPage.setFilter("analise_esaq", lbl_nm_propriedade.ID, ViewState.Item("nm_propriedade").ToString)
    '        customPage.setFilter("analise_esaq", txt_dt_coleta_ini.ID, ViewState.Item("txt_dt_coleta_ini").ToString)
    '        customPage.setFilter("analise_esaq", cbo_Grupo.ID, ViewState.Item("id_grupo").ToString)  ' adri - 09/02/2017 - chamado 2500 acertos
    '        customPage.setFilter("analise_esaq", "PageIndex", gridResults.PageIndex.ToString())

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    '    If (e.Row.RowType = DataControlRowType.Header) Then
    '        Dim lbl_teor_ctm_mensal As Label = CType(e.Row.FindControl("lbl_teor_ctm_mensal"), Label)
    '        Dim lbl_teor_ctm_mensal1 As Label = CType(e.Row.FindControl("lbl_teor_ctm_mensal1"), Label)
    '        Dim lbl_teor_ctm_mensal2 As Label = CType(e.Row.FindControl("lbl_teor_ctm_mensal2"), Label)

    '        Dim lbl_teor_ccs_mensal As Label = CType(e.Row.FindControl("lbl_teor_ccs_mensal"), Label)
    '        Dim lbl_teor_ccs_mensal1 As Label = CType(e.Row.FindControl("lbl_teor_ccs_mensal1"), Label)
    '        Dim lbl_teor_ccs_mensal2 As Label = CType(e.Row.FindControl("lbl_teor_ccs_mensal2"), Label)

    '        lbl_teor_ctm_mensal.Text = DateTime.Parse(ViewState.Item("txt_dt_coleta_ini")).ToString("MMM").ToUpper
    '        lbl_teor_ctm_mensal1.Text = DateTime.Parse(DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper
    '        lbl_teor_ctm_mensal2.Text = DateTime.Parse(DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper

    '        lbl_teor_ccs_mensal.Text = DateTime.Parse(ViewState.Item("txt_dt_coleta_ini")).ToString("MMM").ToUpper
    '        lbl_teor_ccs_mensal1.Text = DateTime.Parse(DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper
    '        lbl_teor_ccs_mensal2.Text = DateTime.Parse(DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper

    '    End If

    '    If (e.Row.RowType <> DataControlRowType.Header _
    '        And e.Row.RowType <> DataControlRowType.Footer _
    '        And e.Row.RowType <> DataControlRowType.Pager) Then
    '        'fran 17/02/2017 i fran
    '        Dim lbl_nr_teor_ctm_mensal As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm_mensal"), Label)
    '        Dim lbl_nr_teor_ctm_mensal1 As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm_mensal1"), Label)
    '        Dim lbl_nr_teor_ctm_mensal2 As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm_mensal2"), Label)
    '        Dim lbl_nr_teor_ctm_tri As DataControlFieldCell = CType(e.Row.Cells(8), DataControlFieldCell)
    '        Dim lbl_nr_teor_ccs_mensal As Label = CType(e.Row.FindControl("lbl_nr_teor_ccs_mensal"), Label)
    '        Dim lbl_nr_teor_ccs_mensal1 As Label = CType(e.Row.FindControl("lbl_nr_teor_ccs_mensal1"), Label)
    '        Dim lbl_nr_teor_ccs_mensal2 As Label = CType(e.Row.FindControl("lbl_nr_teor_ccs_mensal2"), Label)
    '        Dim lbl_nr_teor_ccs_tri As DataControlFieldCell = CType(e.Row.Cells(13), DataControlFieldCell)

    '        lbl_nr_teor_ctm_mensal.Text = IIf(lbl_nr_teor_ctm_mensal.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ctm_mensal.Text, 0).ToString)
    '        lbl_nr_teor_ctm_mensal1.Text = IIf(lbl_nr_teor_ctm_mensal1.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ctm_mensal1.Text, 0).ToString)
    '        lbl_nr_teor_ctm_mensal2.Text = IIf(lbl_nr_teor_ctm_mensal2.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ctm_mensal2.Text, 0).ToString)
    '        lbl_nr_teor_ctm_tri.Text = IIf(lbl_nr_teor_ctm_tri.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ctm_tri.Text, 0).ToString)

    '        lbl_nr_teor_ccs_mensal.Text = IIf(lbl_nr_teor_ccs_mensal.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ccs_mensal.Text, 0).ToString)
    '        lbl_nr_teor_ccs_mensal1.Text = IIf(lbl_nr_teor_ccs_mensal1.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ccs_mensal1.Text, 0).ToString)
    '        lbl_nr_teor_ccs_mensal2.Text = IIf(lbl_nr_teor_ccs_mensal2.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ccs_mensal2.Text, 0).ToString)
    '        lbl_nr_teor_ccs_tri.Text = IIf(lbl_nr_teor_ccs_tri.Text.Equals(String.Empty), "0", FormatNumber(lbl_nr_teor_ccs_tri.Text, 0).ToString)
    '        'fran 17/02/2017 f fran 


    '    End If
    'End Sub


    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged

        'lbl_nm_pessoa.Text = ""
        'lbl_nm_pessoa.Visible = False

        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty
        'fran 04/2017 i 
        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                'produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 'fran 05/05/2010
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        'If Me.cbo_estabelecimento.SelectedValue <> "0" Then
        'Me.lbl_nm_propriedade.Visible = True
        carregarCamposPropriedade()
        ' End If
    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
        'lbl_nm_propriedade.Text = ""
        'lbl_nm_propriedade.Visible = False
        lbl_nm_propriedade.Text = String.Empty
        hf_id_propriedade.Value = String.Empty
        'Fran 04/2017
        Try
            If Not txt_cd_propriedade.Text.Equals(String.Empty) Then
                Dim propriedade As New Propriedade
                propriedade.id_propriedade = Convert.ToInt32(txt_cd_propriedade.Text.Trim)

                Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters
                If dspropriedade.Tables(0).Rows.Count > 0 Then
                    lbl_nm_propriedade.Enabled = True
                    lbl_nm_propriedade.Text = dspropriedade.Tables(0).Rows(0).Item("nm_propriedade")
                    hf_id_propriedade.Value = dspropriedade.Tables(0).Rows(0).Item("id_propriedade").ToString
                End If

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        'Fran 11/03/2010 chamado 684

    End Sub


    'Protected Sub gridComplienceSintetico_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridComplienceSintetico.RowDataBound

    '    If (e.Row.RowType <> DataControlRowType.Header _
    'And e.Row.RowType <> DataControlRowType.Footer _
    'And e.Row.RowType <> DataControlRowType.Pager) Then

    '        Dim lbl_nr_volume_complience_perc As Label = CType(e.Row.FindControl("lbl_nr_volume_complience_perc"), Label)
    '        Dim lbl_nr_volume_complience As Label = CType(e.Row.FindControl("lbl_nr_volume_complience"), Label)

    '        Dim lbl_nr_volume_ncompl_perc As Label = CType(e.Row.FindControl("lbl_nr_volume_ncompl_perc"), Label)
    '        Dim lbl_nr_volume_ncompl As Label = CType(e.Row.FindControl("lbl_nr_volume_ncompl"), Label)

    '        If ViewState.Item("nr_volume_total") > 0 Then
    '            lbl_nr_volume_complience_perc.Text = (lbl_nr_volume_complience.Text / ViewState.Item("nr_volume_total")) * 100
    '            lbl_nr_volume_complience_perc.Text = FormatNumber(CDec(lbl_nr_volume_complience_perc.Text), 2)

    '            lbl_nr_volume_ncompl.Text = Convert.ToDouble(ViewState.Item("nr_volume_total")) - Convert.ToDouble(lbl_nr_volume_complience.Text)
    '            lbl_nr_volume_ncompl_perc.Text = (lbl_nr_volume_ncompl.Text / ViewState.Item("nr_volume_total")) * 100
    '            lbl_nr_volume_ncompl_perc.Text = FormatNumber(CDec(lbl_nr_volume_ncompl_perc.Text), 2)

    '        End If

    '        Dim lbl_nr_produtores_complience_perc As Label = CType(e.Row.FindControl("lbl_nr_produtores_complience_perc"), Label)
    '        Dim lbl_nr_produtores_complience As Label = CType(e.Row.FindControl("lbl_nr_produtores_complience"), Label)

    '        Dim lbl_nr_produtores_ncompl_perc As Label = CType(e.Row.FindControl("lbl_nr_produtores_ncompl_perc"), Label)
    '        Dim lbl_nr_produtores_ncompl As Label = CType(e.Row.FindControl("lbl_nr_produtores_ncompl"), Label)

    '        If ViewState.Item("nr_produtores_total") > 0 Then
    '            lbl_nr_produtores_complience_perc.Text = (lbl_nr_produtores_complience.Text / ViewState.Item("nr_produtores_total")) * 100
    '            lbl_nr_produtores_complience_perc.Text = FormatNumber(CDec(lbl_nr_produtores_complience_perc.Text), 2)

    '            lbl_nr_produtores_ncompl.Text = CInt(ViewState.Item("nr_produtores_total")) - CInt(lbl_nr_produtores_complience.Text)
    '            lbl_nr_produtores_ncompl_perc.Text = (lbl_nr_produtores_ncompl.Text / ViewState.Item("nr_produtores_total")) * 100
    '            lbl_nr_produtores_ncompl_perc.Text = FormatNumber(CDec(lbl_nr_produtores_ncompl_perc.Text), 2)
    '        End If

    '        ' Média Geometrica 
    '        Dim lbl_categoria As Label = CType(e.Row.FindControl("lbl_categoria"), Label)

    '        'If lbl_categoria.Text = "CBT" Or lbl_categoria.Text = "CCS" Then  ' adri 08/02/2017 - chamado 2500 - acertos (calcular para todas as categorias)

    '        Dim lbl_nr_media_geo_mensal As Label = CType(e.Row.FindControl("lbl_nr_media_geo_mensal"), Label)
    '        Dim lbl_nr_media_geo_trimestral As Label = CType(e.Row.FindControl("lbl_nr_media_geo_trimestral"), Label)
    '        Dim analiseesalq As New AnaliseEsalq

    '        analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_coleta_ini")
    '        analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
    '        ' adri 08/02/2017 - chamado 2500 - acertos - Trazer Poços e Aguas Juntos - i
    '        If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
    '            analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
    '        Else
    '            analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
    '        End If
    '        analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
    '        ' adri 08/02/2017 - chamado 2500 - acertos - Trazer Poços e Aguas Juntos - f


    '        If Left(lbl_categoria.Text, 3) = "CBT" Then  ' CBT/CTM
    '            analiseesalq.id_conta_teor_mensal = "264"   ' conta 0093
    '            analiseesalq.id_conta_teor_trimestral = "252"  ' conta 0092
    '        End If

    '        If Left(lbl_categoria.Text, 3) = "CCS" Then  ' CCS
    '            analiseesalq.id_conta_teor_mensal = "265"  ' conta 0106
    '            analiseesalq.id_conta_teor_trimestral = "253"  ' conta 0105
    '        End If

    '        ' adri 10/02/2017 - chamado 2500 acertos (calcular médias também para proteína e Gordura - i
    '        If Left(lbl_categoria.Text, 8) = "Proteína" Then  ' Proteína
    '            analiseesalq.id_conta_teor_mensal = "251"  ' conta 0082
    '            analiseesalq.id_conta_teor_trimestral = "251"  ' conta 0082 (repete porque não tem teor trimestral, no excel da Giovana os valores se repetem)
    '        End If

    '        If Left(lbl_categoria.Text, 7) = "Gordura" Then  ' Gordura
    '            analiseesalq.id_conta_teor_mensal = "156"  ' conta 0152
    '            analiseesalq.id_conta_teor_trimestral = "156"  ' conta 0152 (repete porque não tem teor trimestral, no excel da Giovana os valores se repetem)
    '        End If
    '        ' adri 10/02/2017 - chamado 2500 acertos (calcular médias também para proteína e Gordura - f

    '        If ViewState.Item("nr_volume_total") > 0 Then

    '            Dim dsMediaGeo As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeo()   ' Fran Maio/2017 - chamado 2526
    '            'fran 05/2017 i a procedure ja traz apenas os que devem participar do complieance
    '            'Dim dsVolumeDesprezadoTeorMensal As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalDesprezado()  ' adri 13/02/2017 - chamado 2500 - apurar volume total das propriedades sem teor ou teor zero
    '            'fran 05/2017 f
    '            Dim lvolumetotal As Decimal
    '            ' Definição da Giovana e Danone: Se não exisitr qualidade para o mes (teor igual a zero), o volume desta propriedade deve ser desprezado para o cálculo das duas médias ponderadas (mensal e trimestral)
    '            'fran 05/2017 i a procedure ja traz apenas os que devem participar do complieance
    '            'lvolumetotal = ViewState.Item("nr_volume_total") - dsVolumeDesprezadoTeorMensal.Tables(0).Rows(0).Item("nr_volume_teor_mensal_desprezado")
    '            lvolumetotal = ViewState.Item("nr_volume_total")
    '            'fran 05/2017 f

    '            If lvolumetotal > 0 Then

    '                ' adri 10/02/2017 - chamado 2500 acertos (calcular médias também para proteína e Gordura - i
    '                If Left(lbl_categoria.Text, 8) = "Proteína" Or Left(lbl_categoria.Text, 7) = "Gordura" Then
    '                    'lbl_nr_media_geo_mensal.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_mensal") / ViewState.Item("nr_volume_total"), 2) + "²"
    '                    'lbl_nr_media_geo_trimestral.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_trimestral") / ViewState.Item("nr_volume_total"), 4) + "²"
    '                    lbl_nr_media_geo_mensal.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_mensal") / lvolumetotal, 2)   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
    '                    'lbl_nr_media_geo_trimestral.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_trimestral") / lvolumetotal, 4)  ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal (mesmo que o trimestral) igual a zero ou null
    '                    lbl_nr_media_geo_trimestral.Text = String.Empty
    '                Else
    '                    ' adri 10/02/2017 - chamado 2500 acertos (calcular médias também para proteína e Gordura - f
    '                    'lbl_nr_media_geo_mensal.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_mensal") / ViewState.Item("nr_volume_total"), 0) + "¹"
    '                    'lbl_nr_media_geo_trimestral.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_trimestral") / ViewState.Item("nr_volume_total"), 0) + "¹"
    '                    lbl_nr_media_geo_mensal.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_mensal") / lvolumetotal, 0)   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
    '                    lbl_nr_media_geo_trimestral.Text = FormatNumber(dsMediaGeo.Tables(0).Rows(0).Item("nr_teor_trimestral") / lvolumetotal, 0)
    '                End If
    '            End If

    '        End If

    '        'End If ' Se CBT ou CCS


    '    End If


    'End Sub

    'Mirella - 08/02/2017 - i
    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("txt_ano") = Me.txt_ano.Text.Trim
        ViewState.Item("id_grupo") = Me.cbo_Grupo.SelectedValue  ' adri 09/02/2017 - chamado 2500 acertos (filtro para Produtores / Cooperativas)


        'customPage.clearFilters("farmerspayment")

        'saveFilters()
        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 176
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        Response.Redirect("frm_curvaabc_kpi_qualidade_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&txt_ano=" + ViewState.Item("txt_ano").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString())

    End Sub
    'Mirella - 08/02/2017 - f


    Protected Sub gridCCSMensal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCCSMensal.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            If Not lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If Not lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 0)
            End If
            If Not lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 0)
            End If
            If Not lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 0)
            End If
            If Not lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 0)
            End If
            If Not lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 0)
            End If
            If Not lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 0)
            End If
            If Not lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 0)
            End If
            If Not lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = FormatNumber(lbl_set.Text, 0)
            End If
            If Not lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = FormatNumber(lbl_out.Text, 0)
            End If
            If Not lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 0)
            End If
            If Not lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 0)
            End If

            lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 0).ToString   ' 22/08/2017 chamado 2565
            'desabilitado pois resolve no sql

            'Dim analiseesalq As New AnaliseEsalq

            'analiseesalq.dt_referencia_ini = "01/01/" & lbl_nr_ano.Text
            'analiseesalq.dt_referencia_fim = "31/12/" & lbl_nr_ano.Text
            'analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
            '    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            'Else
            '    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            'End If
            'analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
            'analiseesalq.id_conta_teor = "265"  ' conta teor CCS Mensal

            '' adri 16/08/2017 - chamado 2564 - i
            'If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
            '    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            'End If

            'If Trim(ViewState.Item("id_propriedade")) <> "" Then
            '    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            'End If
            '' adri 16/08/2017 - chamado 2564 - f

            'Dim dsMediaGeo As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI()   ' Traz teor x volume agrupados por referencia

            'lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

            'For li = 0 To dsMediaGeo.Tables(0).Rows.Count - 1
            '    Select Case dsMediaGeo.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 2
            '            lbl_fev.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 3
            '            lbl_mar.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 4
            '            lbl_abr.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 5
            '            lbl_mai.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 6
            '            lbl_jun.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 7
            '            lbl_jul.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 8
            '            lbl_ago.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 9
            '            lbl_set.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 10
            '            lbl_out.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 11
            '            lbl_nov.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 12
            '            lbl_dez.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '    End Select

            '    lbl_media_anual.Text = lbl_media_anual.Text + dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")  ' 22/08/2017 chamado 2565

            'Next


            'Dim dsComplienceVolumeTotal As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI()

            'For li = 0 To dsComplienceVolumeTotal.Tables(0).Rows.Count - 1

            '    lvolumetotal = dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_volume_total")
            '    lvolumetotal_anual = lvolumetotal_anual + lvolumetotal ' 22/08/2017 chamado 2565

            '    Select Case dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = FormatNumber(lbl_jan.Text / lvolumetotal, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            '        Case 2
            '            lbl_fev.Text = FormatNumber(lbl_fev.Text / lvolumetotal, 0)
            '        Case 3
            '            lbl_mar.Text = FormatNumber(lbl_mar.Text / lvolumetotal, 0)
            '        Case 4
            '            lbl_abr.Text = FormatNumber(lbl_abr.Text / lvolumetotal, 0)
            '        Case 5
            '            lbl_mai.Text = FormatNumber(lbl_mai.Text / lvolumetotal, 0)
            '        Case 6
            '            lbl_jun.Text = FormatNumber(lbl_jun.Text / lvolumetotal, 0)
            '        Case 7
            '            lbl_jul.Text = FormatNumber(lbl_jul.Text / lvolumetotal, 0)
            '        Case 8
            '            lbl_ago.Text = FormatNumber(lbl_ago.Text / lvolumetotal, 0)
            '        Case 9
            '            lbl_set.Text = FormatNumber(lbl_set.Text / lvolumetotal, 0)
            '        Case 10
            '            lbl_out.Text = FormatNumber(lbl_out.Text / lvolumetotal, 0)
            '        Case 11
            '            lbl_nov.Text = FormatNumber(lbl_nov.Text / lvolumetotal, 0)
            '        Case 12
            '            lbl_dez.Text = FormatNumber(lbl_dez.Text / lvolumetotal, 0)
            '    End Select
            'Next

            'lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text / lvolumetotal_anual), 0).ToString   ' 22/08/2017 chamado 2565

        End If

    End Sub

    Protected Sub gridCCSTrimestral_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCCSTrimestral.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            If Not lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If Not lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 0)
            End If
            If Not lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 0)
            End If
            If Not lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 0)
            End If
            If Not lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 0)
            End If
            If Not lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 0)
            End If
            If Not lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 0)
            End If
            If Not lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 0)
            End If
            If Not lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = FormatNumber(lbl_set.Text, 0)
            End If
            If Not lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = FormatNumber(lbl_out.Text, 0)
            End If
            If Not lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 0)
            End If
            If Not lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 0)
            End If

            lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 0).ToString   ' 22/08/2017 chamado 2565
            'desabilitado pois resolve no sql

            'Dim analiseesalq As New AnaliseEsalq

            'analiseesalq.dt_referencia_ini = "01/01/" & lbl_nr_ano.Text
            'analiseesalq.dt_referencia_fim = "31/12/" & lbl_nr_ano.Text
            'analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
            '    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            'Else
            '    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            'End If
            'analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
            'analiseesalq.id_conta_teor = "253"  ' conta teor CCS Trimestral

            '' adri 16/08/2017 - chamado 2564 - i
            'If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
            '    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            'End If

            'If Trim(ViewState.Item("id_propriedade")) <> "" Then
            '    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            'End If
            '' adri 16/08/2017 - chamado 2564 - f

            'Dim dsMediaGeo As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI()   ' Traz teor x volume agrupados por referencia

            'lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

            'For li = 0 To dsMediaGeo.Tables(0).Rows.Count - 1
            '    Select Case dsMediaGeo.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 2
            '            lbl_fev.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 3
            '            lbl_mar.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 4
            '            lbl_abr.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 5
            '            lbl_mai.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 6
            '            lbl_jun.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 7
            '            lbl_jul.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 8
            '            lbl_ago.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 9
            '            lbl_set.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 10
            '            lbl_out.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 11
            '            lbl_nov.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 12
            '            lbl_dez.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '    End Select

            '    lbl_media_anual.Text = lbl_media_anual.Text + dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")  ' 22/08/2017 chamado 2565

            'Next


            'Dim dsComplienceVolumeTotal As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI()

            'For li = 0 To dsComplienceVolumeTotal.Tables(0).Rows.Count - 1

            '    lvolumetotal = dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_volume_total")
            '    lvolumetotal_anual = lvolumetotal_anual + lvolumetotal ' 22/08/2017 chamado 2565

            '    Select Case dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = FormatNumber(lbl_jan.Text / lvolumetotal, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            '        Case 2
            '            lbl_fev.Text = FormatNumber(lbl_fev.Text / lvolumetotal, 0)
            '        Case 3
            '            lbl_mar.Text = FormatNumber(lbl_mar.Text / lvolumetotal, 0)
            '        Case 4
            '            lbl_abr.Text = FormatNumber(lbl_abr.Text / lvolumetotal, 0)
            '        Case 5
            '            lbl_mai.Text = FormatNumber(lbl_mai.Text / lvolumetotal, 0)
            '        Case 6
            '            lbl_jun.Text = FormatNumber(lbl_jun.Text / lvolumetotal, 0)
            '        Case 7
            '            lbl_jul.Text = FormatNumber(lbl_jul.Text / lvolumetotal, 0)
            '        Case 8
            '            lbl_ago.Text = FormatNumber(lbl_ago.Text / lvolumetotal, 0)
            '        Case 9
            '            lbl_set.Text = FormatNumber(lbl_set.Text / lvolumetotal, 0)
            '        Case 10
            '            lbl_out.Text = FormatNumber(lbl_out.Text / lvolumetotal, 0)
            '        Case 11
            '            lbl_nov.Text = FormatNumber(lbl_nov.Text / lvolumetotal, 0)
            '        Case 12
            '            lbl_dez.Text = FormatNumber(lbl_dez.Text / lvolumetotal, 0)
            '    End Select
            'Next

            'lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text / lvolumetotal_anual), 0).ToString   ' 22/08/2017 chamado 2565

        End If

    End Sub

    Protected Sub gridCBTMensal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCBTMensal.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565


            If Not lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If Not lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 0)
            End If
            If Not lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 0)
            End If
            If Not lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 0)
            End If
            If Not lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 0)
            End If
            If Not lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 0)
            End If
            If Not lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 0)
            End If
            If Not lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 0)
            End If
            If Not lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = FormatNumber(lbl_set.Text, 0)
            End If
            If Not lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = FormatNumber(lbl_out.Text, 0)
            End If
            If Not lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 0)
            End If
            If Not lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 0)
            End If
            lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 0).ToString   ' 22/08/2017 chamado 2565



            'fran 07/2021 desabilitado pois o sql ja traz os dados
            'Dim analiseesalq As New AnaliseEsalq

            'analiseesalq.dt_referencia_ini = "01/01/" & lbl_nr_ano.Text
            'analiseesalq.dt_referencia_fim = "31/12/" & lbl_nr_ano.Text
            'analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
            '    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            'Else
            '    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            'End If
            'analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
            'analiseesalq.id_conta_teor = "264"  ' conta teor CBT Mensal

            '' adri 16/08/2017 - chamado 2564 - i
            'If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
            '    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            'End If

            'If Trim(ViewState.Item("id_propriedade")) <> "" Then
            '    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            'End If
            '' adri 16/08/2017 - chamado 2564 - f

            'Dim dsMediaGeo As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI()   ' Traz teor x volume agrupados por referencia

            'lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

            'For li = 0 To dsMediaGeo.Tables(0).Rows.Count - 1
            '    Select Case dsMediaGeo.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 2
            '            lbl_fev.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 3
            '            lbl_mar.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 4
            '            lbl_abr.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 5
            '            lbl_mai.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 6
            '            lbl_jun.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 7
            '            lbl_jul.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 8
            '            lbl_ago.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 9
            '            lbl_set.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 10
            '            lbl_out.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 11
            '            lbl_nov.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 12
            '            lbl_dez.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '    End Select

            '    lbl_media_anual.Text = lbl_media_anual.Text + dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")  ' 22/08/2017 chamado 2565

            'Next


            'Dim dsComplienceVolumeTotal As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI()

            'For li = 0 To dsComplienceVolumeTotal.Tables(0).Rows.Count - 1

            '    lvolumetotal = dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_volume_total")
            '    lvolumetotal_anual = lvolumetotal_anual + lvolumetotal ' 22/08/2017 chamado 2565

            '    Select Case dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = FormatNumber(lbl_jan.Text / lvolumetotal, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            '        Case 2
            '            lbl_fev.Text = FormatNumber(lbl_fev.Text / lvolumetotal, 0)
            '        Case 3
            '            lbl_mar.Text = FormatNumber(lbl_mar.Text / lvolumetotal, 0)
            '        Case 4
            '            lbl_abr.Text = FormatNumber(lbl_abr.Text / lvolumetotal, 0)
            '        Case 5
            '            lbl_mai.Text = FormatNumber(lbl_mai.Text / lvolumetotal, 0)
            '        Case 6
            '            lbl_jun.Text = FormatNumber(lbl_jun.Text / lvolumetotal, 0)
            '        Case 7
            '            lbl_jul.Text = FormatNumber(lbl_jul.Text / lvolumetotal, 0)
            '        Case 8
            '            lbl_ago.Text = FormatNumber(lbl_ago.Text / lvolumetotal, 0)
            '        Case 9
            '            lbl_set.Text = FormatNumber(lbl_set.Text / lvolumetotal, 0)
            '        Case 10
            '            lbl_out.Text = FormatNumber(lbl_out.Text / lvolumetotal, 0)
            '        Case 11
            '            lbl_nov.Text = FormatNumber(lbl_nov.Text / lvolumetotal, 0)
            '        Case 12
            '            lbl_dez.Text = FormatNumber(lbl_dez.Text / lvolumetotal, 0)
            '    End Select
            'Next

            'lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text / lvolumetotal_anual), 0).ToString   ' 22/08/2017 chamado 2565

        End If

    End Sub

    Protected Sub gridCBTTrimestral_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCBTTrimestral.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            If Not lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If Not lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 0)
            End If
            If Not lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 0)
            End If
            If Not lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 0)
            End If
            If Not lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 0)
            End If
            If Not lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 0)
            End If
            If Not lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 0)
            End If
            If Not lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 0)
            End If
            If Not lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = FormatNumber(lbl_set.Text, 0)
            End If
            If Not lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = FormatNumber(lbl_out.Text, 0)
            End If
            If Not lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 0)
            End If
            If Not lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 0)
            End If
            lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 0).ToString   ' 22/08/2017 chamado 2565
            'desabilitado pois resolve no sql
            'Dim analiseesalq As New AnaliseEsalq

            'analiseesalq.dt_referencia_ini = "01/01/" & lbl_nr_ano.Text
            'analiseesalq.dt_referencia_fim = "31/12/" & lbl_nr_ano.Text
            'analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
            '    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            'Else
            '    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            'End If
            'analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
            'analiseesalq.id_conta_teor = "252"  ' conta teor CBT Trimestral

            '' adri 16/08/2017 - chamado 2564 - i
            'If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
            '    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            'End If

            'If Trim(ViewState.Item("id_propriedade")) <> "" Then
            '    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            'End If
            '' adri 16/08/2017 - chamado 2564 - f

            'Dim dsMediaGeo As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI()   ' Traz teor x volume agrupados por referencia

            'lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

            'For li = 0 To dsMediaGeo.Tables(0).Rows.Count - 1
            '    Select Case dsMediaGeo.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 2
            '            lbl_fev.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 3
            '            lbl_mar.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 4
            '            lbl_abr.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 5
            '            lbl_mai.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 6
            '            lbl_jun.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 7
            '            lbl_jul.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 8
            '            lbl_ago.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 9
            '            lbl_set.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 10
            '            lbl_out.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 11
            '            lbl_nov.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 12
            '            lbl_dez.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '    End Select

            '    lbl_media_anual.Text = lbl_media_anual.Text + dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")  ' 22/08/2017 chamado 2565

            'Next


            'Dim dsComplienceVolumeTotal As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI()

            'For li = 0 To dsComplienceVolumeTotal.Tables(0).Rows.Count - 1

            '    lvolumetotal = dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_volume_total")
            '    lvolumetotal_anual = lvolumetotal_anual + lvolumetotal ' 22/08/2017 chamado 2565

            '    Select Case dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = FormatNumber(lbl_jan.Text / lvolumetotal, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            '        Case 2
            '            lbl_fev.Text = FormatNumber(lbl_fev.Text / lvolumetotal, 0)
            '        Case 3
            '            lbl_mar.Text = FormatNumber(lbl_mar.Text / lvolumetotal, 0)
            '        Case 4
            '            lbl_abr.Text = FormatNumber(lbl_abr.Text / lvolumetotal, 0)
            '        Case 5
            '            lbl_mai.Text = FormatNumber(lbl_mai.Text / lvolumetotal, 0)
            '        Case 6
            '            lbl_jun.Text = FormatNumber(lbl_jun.Text / lvolumetotal, 0)
            '        Case 7
            '            lbl_jul.Text = FormatNumber(lbl_jul.Text / lvolumetotal, 0)
            '        Case 8
            '            lbl_ago.Text = FormatNumber(lbl_ago.Text / lvolumetotal, 0)
            '        Case 9
            '            lbl_set.Text = FormatNumber(lbl_set.Text / lvolumetotal, 0)
            '        Case 10
            '            lbl_out.Text = FormatNumber(lbl_out.Text / lvolumetotal, 0)
            '        Case 11
            '            lbl_nov.Text = FormatNumber(lbl_nov.Text / lvolumetotal, 0)
            '        Case 12
            '            lbl_dez.Text = FormatNumber(lbl_dez.Text / lvolumetotal, 0)
            '    End Select
            'Next

            'lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text / lvolumetotal_anual), 0).ToString   ' 22/08/2017 chamado 2565

        End If

    End Sub

    Protected Sub gridProteinaMensal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridProteinaMensal.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            If Not lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 2)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If Not lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 2)
            End If
            If Not lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 2)
            End If
            If Not lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 2)
            End If
            If Not lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 2)
            End If
            If Not lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 2)
            End If
            If Not lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 2)
            End If
            If Not lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 2)
            End If
            If Not lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = FormatNumber(lbl_set.Text, 2)
            End If
            If Not lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = FormatNumber(lbl_out.Text, 2)
            End If
            If Not lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 2)
            End If
            If Not lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 2)
            End If

            lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 2).ToString   ' 22/08/2017 chamado 2565
            'desabilitado pois resolve no sql

            'Dim analiseesalq As New AnaliseEsalq

            'analiseesalq.dt_referencia_ini = "01/01/" & lbl_nr_ano.Text
            'analiseesalq.dt_referencia_fim = "31/12/" & lbl_nr_ano.Text
            'analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
            '    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            'Else
            '    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            'End If
            'analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
            'analiseesalq.id_conta_teor = "251"  ' conta teor Proteina Mensal

            '' adri 16/08/2017 - chamado 2564 - i
            'If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
            '    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            'End If

            'If Trim(ViewState.Item("id_propriedade")) <> "" Then
            '    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            'End If
            '' adri 16/08/2017 - chamado 2564 - f

            'Dim dsMediaGeo As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI()   ' Traz teor x volume agrupados por referencia

            'lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

            'For li = 0 To dsMediaGeo.Tables(0).Rows.Count - 1
            '    Select Case dsMediaGeo.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 2
            '            lbl_fev.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 3
            '            lbl_mar.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 4
            '            lbl_abr.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 5
            '            lbl_mai.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 6
            '            lbl_jun.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 7
            '            lbl_jul.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 8
            '            lbl_ago.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 9
            '            lbl_set.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 10
            '            lbl_out.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 11
            '            lbl_nov.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 12
            '            lbl_dez.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '    End Select

            '    lbl_media_anual.Text = lbl_media_anual.Text + dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")  ' 22/08/2017 chamado 2565

            'Next


            'Dim dsComplienceVolumeTotal As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI()

            'For li = 0 To dsComplienceVolumeTotal.Tables(0).Rows.Count - 1

            '    lvolumetotal = dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_volume_total")
            '    lvolumetotal_anual = lvolumetotal_anual + lvolumetotal ' 22/08/2017 chamado 2565

            '    Select Case dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = FormatNumber(lbl_jan.Text / lvolumetotal, 2)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            '        Case 2
            '            lbl_fev.Text = FormatNumber(lbl_fev.Text / lvolumetotal, 2)
            '        Case 3
            '            lbl_mar.Text = FormatNumber(lbl_mar.Text / lvolumetotal, 2)
            '        Case 4
            '            lbl_abr.Text = FormatNumber(lbl_abr.Text / lvolumetotal, 2)
            '        Case 5
            '            lbl_mai.Text = FormatNumber(lbl_mai.Text / lvolumetotal, 2)
            '        Case 6
            '            lbl_jun.Text = FormatNumber(lbl_jun.Text / lvolumetotal, 2)
            '        Case 7
            '            lbl_jul.Text = FormatNumber(lbl_jul.Text / lvolumetotal, 2)
            '        Case 8
            '            lbl_ago.Text = FormatNumber(lbl_ago.Text / lvolumetotal, 2)
            '        Case 9
            '            lbl_set.Text = FormatNumber(lbl_set.Text / lvolumetotal, 2)
            '        Case 10
            '            lbl_out.Text = FormatNumber(lbl_out.Text / lvolumetotal, 2)
            '        Case 11
            '            lbl_nov.Text = FormatNumber(lbl_nov.Text / lvolumetotal, 2)
            '        Case 12
            '            lbl_dez.Text = FormatNumber(lbl_dez.Text / lvolumetotal, 2)
            '    End Select
            'Next

            'lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text / lvolumetotal_anual), 2).ToString   ' 22/08/2017 chamado 2565

        End If

    End Sub

    Protected Sub gridGorduraMensal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridGorduraMensal.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            If Not lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 2)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If Not lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 2)
            End If
            If Not lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 2)
            End If
            If Not lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 2)
            End If
            If Not lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 2)
            End If
            If Not lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 2)
            End If
            If Not lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 2)
            End If
            If Not lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 2)
            End If
            If Not lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = FormatNumber(lbl_set.Text, 2)
            End If
            If Not lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = FormatNumber(lbl_out.Text, 2)
            End If
            If Not lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 2)
            End If
            If Not lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 2)
            End If
            lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 2).ToString   ' 22/08/2017 chamado 2565
            'desabilitado pois resolve no sql
            'Dim analiseesalq As New AnaliseEsalq

            'analiseesalq.dt_referencia_ini = "01/01/" & lbl_nr_ano.Text
            'analiseesalq.dt_referencia_fim = "31/12/" & lbl_nr_ano.Text
            'analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
            '    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            'Else
            '    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            'End If
            'analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
            'analiseesalq.id_conta_teor = "156"  ' conta teor Gordura Mensal

            '' adri 16/08/2017 - chamado 2564 - i
            'If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
            '    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            'End If

            'If Trim(ViewState.Item("id_propriedade")) <> "" Then
            '    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            'End If
            '' adri 16/08/2017 - chamado 2564 - f

            'Dim dsMediaGeo As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI()   ' Traz teor x volume agrupados por referencia

            'lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

            'For li = 0 To dsMediaGeo.Tables(0).Rows.Count - 1
            '    Select Case dsMediaGeo.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 2
            '            lbl_fev.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 3
            '            lbl_mar.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 4
            '            lbl_abr.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 5
            '            lbl_mai.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 6
            '            lbl_jun.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 7
            '            lbl_jul.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 8
            '            lbl_ago.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 9
            '            lbl_set.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 10
            '            lbl_out.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 11
            '            lbl_nov.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '        Case 12
            '            lbl_dez.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")
            '    End Select

            '    lbl_media_anual.Text = lbl_media_anual.Text + dsMediaGeo.Tables(0).Rows(li).Item("nr_teor")  ' 22/08/2017 chamado 2565

            'Next


            'Dim dsComplienceVolumeTotal As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI()

            'For li = 0 To dsComplienceVolumeTotal.Tables(0).Rows.Count - 1

            '    lvolumetotal = dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_volume_total")
            '    lvolumetotal_anual = lvolumetotal_anual + lvolumetotal ' 22/08/2017 chamado 2565

            '    Select Case dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = FormatNumber(lbl_jan.Text / lvolumetotal, 2)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            '        Case 2
            '            lbl_fev.Text = FormatNumber(lbl_fev.Text / lvolumetotal, 2)
            '        Case 3
            '            lbl_mar.Text = FormatNumber(lbl_mar.Text / lvolumetotal, 2)
            '        Case 4
            '            lbl_abr.Text = FormatNumber(lbl_abr.Text / lvolumetotal, 2)
            '        Case 5
            '            lbl_mai.Text = FormatNumber(lbl_mai.Text / lvolumetotal, 2)
            '        Case 6
            '            lbl_jun.Text = FormatNumber(lbl_jun.Text / lvolumetotal, 2)
            '        Case 7
            '            lbl_jul.Text = FormatNumber(lbl_jul.Text / lvolumetotal, 2)
            '        Case 8
            '            lbl_ago.Text = FormatNumber(lbl_ago.Text / lvolumetotal, 2)
            '        Case 9
            '            lbl_set.Text = FormatNumber(lbl_set.Text / lvolumetotal, 2)
            '        Case 10
            '            lbl_out.Text = FormatNumber(lbl_out.Text / lvolumetotal, 2)
            '        Case 11
            '            lbl_nov.Text = FormatNumber(lbl_nov.Text / lvolumetotal, 2)
            '        Case 12
            '            lbl_dez.Text = FormatNumber(lbl_dez.Text / lvolumetotal, 2)
            '    End Select
            'Next

            'lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text / lvolumetotal_anual), 2).ToString   ' 22/08/2017 chamado 2565

        End If

    End Sub

    Protected Sub gridVolumeTotalComplience_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridVolumeTotalComplience.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            'Dim analiseesalq As New AnaliseEsalq

            'analiseesalq.dt_referencia_ini = "01/01/" & lbl_nr_ano.Text
            'analiseesalq.dt_referencia_fim = "31/12/" & lbl_nr_ano.Text
            'analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
            '    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            'Else
            '    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            'End If
            'analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)

            '' adri 16/08/2017 - chamado 2564 - i
            'If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
            '    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            'End If

            'If Trim(ViewState.Item("id_propriedade")) <> "" Then
            '    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            'End If
            '' adri 16/08/2017 - chamado 2564 - f

            'Dim dsMediaGeo As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalComplienceKPI()   ' Traz volume complience agrupados por referencia

            ''Inicializa porque a conta 276-complience total passou a existir a partir de 2017
            If lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = "0"
            Else
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = "0"
            Else
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = "0"
            Else
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = "0"
            Else
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = "0"
            Else
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = "0"
            Else
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = "0"
            Else
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = "0"
            Else
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = "0"
            Else
                lbl_set.Text = FormatNumber(lbl_set.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = "0"
            Else
                lbl_out.Text = FormatNumber(lbl_out.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = "0"
            Else
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = "0"
            Else
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_media_anual.Text.Equals(String.Empty) Then
                lbl_media_anual.Text = "0"
            Else
                lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            'lbl_fev.Text = "0"
            'lbl_mar.Text = "0"
            'lbl_abr.Text = "0"
            'lbl_mai.Text = "0"
            'lbl_jun.Text = "0"
            'lbl_jul.Text = "0"
            'lbl_ago.Text = "0"
            'lbl_set.Text = "0"
            'lbl_out.Text = "0"
            'lbl_nov.Text = "0"
            'lbl_dez.Text = "0"
            'lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

            'For li = 0 To dsMediaGeo.Tables(0).Rows.Count - 1
            '    Select Case dsMediaGeo.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")
            '        Case 2
            '            lbl_fev.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")
            '        Case 3
            '            lbl_mar.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")
            '        Case 4
            '            lbl_abr.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")
            '        Case 5
            '            lbl_mai.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")
            '        Case 6
            '            lbl_jun.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")
            '        Case 7
            '            lbl_jul.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")
            '        Case 8
            '            lbl_ago.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")
            '        Case 9
            '            lbl_set.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")
            '        Case 10
            '            lbl_out.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")
            '        Case 11
            '            lbl_nov.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")
            '        Case 12
            '            lbl_dez.Text = dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")
            '    End Select

            '    lbl_media_anual.Text = lbl_media_anual.Text + dsMediaGeo.Tables(0).Rows(li).Item("nr_volume_complience")  ' 22/08/2017 chamado 2565
            'Next


            'Dim dsComplienceVolumeTotal As DataSet = AnaliseEsalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI()

            'For li = 0 To dsComplienceVolumeTotal.Tables(0).Rows.Count - 1

            '    lvolumetotal = dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_volume_total")
            '    lvolumetotal_anual = lvolumetotal_anual + lvolumetotal ' 22/08/2017 chamado 2565

            '    Select Case dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_mes").ToString
            '        Case 1
            '            lbl_jan.Text = FormatNumber((lbl_jan.Text / lvolumetotal) * 100, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            '        Case 2
            '            lbl_fev.Text = FormatNumber((lbl_fev.Text / lvolumetotal) * 100, 2).ToString & "%"
            '        Case 3
            '            lbl_mar.Text = FormatNumber((lbl_mar.Text / lvolumetotal) * 100, 2).ToString & "%"
            '        Case 4
            '            lbl_abr.Text = FormatNumber((lbl_abr.Text / lvolumetotal) * 100, 2).ToString & "%"
            '        Case 5
            '            lbl_mai.Text = FormatNumber((lbl_mai.Text / lvolumetotal) * 100, 2).ToString & "%"
            '        Case 6
            '            lbl_jun.Text = FormatNumber((lbl_jun.Text / lvolumetotal) * 100, 2).ToString & "%"
            '        Case 7
            '            lbl_jul.Text = FormatNumber((lbl_jul.Text / lvolumetotal) * 100, 2).ToString & "%"
            '        Case 8
            '            lbl_ago.Text = FormatNumber((lbl_ago.Text / lvolumetotal) * 100, 2).ToString & "%"
            '        Case 9
            '            lbl_set.Text = FormatNumber((lbl_set.Text / lvolumetotal) * 100, 2).ToString & "%"
            '        Case 10
            '            lbl_out.Text = FormatNumber((lbl_out.Text / lvolumetotal) * 100, 2).ToString & "%"
            '        Case 11
            '            lbl_nov.Text = FormatNumber((lbl_nov.Text / lvolumetotal) * 100, 2).ToString & "%"
            '        Case 12
            '            lbl_dez.Text = FormatNumber((lbl_dez.Text / lvolumetotal) * 100, 2).ToString & "%"
            '    End Select

            'Next

            'lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text / lvolumetotal_anual) * 100, 2).ToString & "%"  ' 22/08/2017 chamado 2565

        End If

    End Sub

    Protected Sub gridVolumeRejeitado_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridVolumeRejeitado.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_seq As Label = CType(e.Row.FindControl("lbl_seq"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565


            Select Case lbl_seq.Text.Trim
                Case "1", "2"
                    If lbl_seq.Text.Trim = "1" Then
                        lbl_nr_ano.Text = "Volume total " & lbl_nr_ano.Text
                    Else
                        lbl_nr_ano.Text = "Volume rejeitado " & lbl_nr_ano.Text
                    End If
                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 0)
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 0)
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 0)
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 0)
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 0)
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 0)
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 0)
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 0)
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 0)
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 0)
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 0)
                    End If

                    lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 0).ToString

                Case "3"
                    lbl_nr_ano.Text = "%"

                    'Inicializa
                    lbl_jan.Text = IIf(Not IsNumeric(lbl_jan.Text), 0, lbl_jan.Text)
                    lbl_fev.Text = IIf(Not IsNumeric(lbl_fev.Text), 0, lbl_fev.Text)
                    lbl_mar.Text = IIf(Not IsNumeric(lbl_mar.Text), 0, lbl_mar.Text)
                    lbl_abr.Text = IIf(Not IsNumeric(lbl_abr.Text), 0, lbl_abr.Text)
                    lbl_mai.Text = IIf(Not IsNumeric(lbl_mai.Text), 0, lbl_mai.Text)
                    lbl_jun.Text = IIf(Not IsNumeric(lbl_jun.Text), 0, lbl_jun.Text)
                    lbl_jul.Text = IIf(Not IsNumeric(lbl_jul.Text), 0, lbl_jul.Text)
                    lbl_ago.Text = IIf(Not IsNumeric(lbl_ago.Text), 0, lbl_ago.Text)
                    lbl_set.Text = IIf(Not IsNumeric(lbl_set.Text), 0, lbl_set.Text)
                    lbl_out.Text = IIf(Not IsNumeric(lbl_out.Text), 0, lbl_out.Text)
                    lbl_nov.Text = IIf(Not IsNumeric(lbl_nov.Text), 0, lbl_nov.Text)
                    lbl_dez.Text = IIf(Not IsNumeric(lbl_dez.Text), 0, lbl_dez.Text)

                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 3)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 3)
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 3)
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 3)
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 3)
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 3)
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 3)
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 3)
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 3)
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 3)
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 3)
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 3)
                    End If

                    lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 2).ToString & "%"



                    lbl_jan.Text = IIf(CDec(lbl_jan.Text) = 0, "", lbl_jan.Text)
                    lbl_fev.Text = IIf(CDec(lbl_fev.Text) = 0, "", lbl_fev.Text)
                    lbl_mar.Text = IIf(CDec(lbl_mar.Text) = 0, "", lbl_mar.Text)
                    lbl_abr.Text = IIf(CDec(lbl_abr.Text) = 0, "", lbl_abr.Text)
                    lbl_mai.Text = IIf(CDec(lbl_mai.Text) = 0, "", lbl_mai.Text)
                    lbl_jun.Text = IIf(CDec(lbl_jun.Text) = 0, "", lbl_jun.Text)
                    lbl_jul.Text = IIf(CDec(lbl_jul.Text) = 0, "", lbl_jul.Text)
                    lbl_ago.Text = IIf(CDec(lbl_ago.Text) = 0, "", lbl_ago.Text)
                    lbl_set.Text = IIf(CDec(lbl_set.Text) = 0, "", lbl_set.Text)
                    lbl_out.Text = IIf(CDec(lbl_out.Text) = 0, "", lbl_out.Text)
                    lbl_nov.Text = IIf(CDec(lbl_nov.Text) = 0, "", lbl_nov.Text)
                    lbl_dez.Text = IIf(CDec(lbl_dez.Text) = 0, "", lbl_dez.Text)

            End Select

            'Dim analiseesalq As New AnaliseEsalq

            'analiseesalq.dt_referencia_ini = "01/01/" & lbl_nr_ano.Text
            'analiseesalq.dt_referencia_fim = "31/12/" & lbl_nr_ano.Text
            'analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
            '    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            'Else
            '    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            'End If
            'analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)

            '' adri 16/08/2017 - chamado 2564 - i
            'If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
            '    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            'End If

            'If Trim(ViewState.Item("id_propriedade")) <> "" Then
            '    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            'End If
            '' adri 16/08/2017 - chamado 2564 - f

            ''=======================================================
            '' VOLUME TOTAL
            ''=======================================================
            'If lbl_seq.Text = 1 Then  'Se linha do Volume Total

            '    lbl_nr_ano.Text = "Volume total " & lbl_nr_ano.Text
            '    'Dim dsVolume As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI   ' Traz volume agrupados por referencia
            '    Dim dsVolume As DataSet = analiseesalq.getCurvaAbcVolumeLeiteProdutores   ' 24/08/2017 - Traz volume dos produtores independente se possui teor

            '    lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

            '    For li = 0 To dsVolume.Tables(0).Rows.Count - 1
            '        Select Case dsVolume.Tables(0).Rows(li).Item("nr_mes").ToString
            '            Case 1
            '                lbl_jan.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
            '            Case 2
            '                lbl_fev.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
            '            Case 3
            '                lbl_mar.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
            '            Case 4
            '                lbl_abr.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
            '            Case 5
            '                lbl_mai.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
            '            Case 6
            '                lbl_jun.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
            '            Case 7
            '                lbl_jul.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
            '            Case 8
            '                lbl_ago.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
            '            Case 9
            '                lbl_set.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
            '            Case 10
            '                lbl_out.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
            '            Case 11
            '                lbl_nov.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
            '            Case 12
            '                lbl_dez.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
            '        End Select

            '        lbl_media_anual.Text = lbl_media_anual.Text + dsVolume.Tables(0).Rows(li).Item("nr_volume_total")  ' 22/08/2017 chamado 2565

            '    Next

            '    lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 0)  ' 22/08/2017 chamado 2565

            'End If


            ''=======================================================
            '' VOLUME REJEITADO
            ''=======================================================
            'If lbl_seq.Text = 2 Then  'Se linha do Volume Rejeitado

            '    lbl_nr_ano.Text = "Volume rejeitado " & lbl_nr_ano.Text
            '    Dim dsVolume As DataSet = analiseesalq.getCurvaAbcVolumeLeiteRejeitadoATB()   ' Traz volume rejeitado agrupados por referencia

            '    lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

            '    For li = 0 To dsVolume.Tables(0).Rows.Count - 1
            '        Select Case dsVolume.Tables(0).Rows(li).Item("nr_mes").ToString
            '            Case 1
            '                lbl_jan.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado"), 0)
            '            Case 2
            '                lbl_fev.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado"), 0)
            '            Case 3
            '                lbl_mar.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado"), 0)
            '            Case 4
            '                lbl_abr.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado"), 0)
            '            Case 5
            '                lbl_mai.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado"), 0)
            '            Case 6
            '                lbl_jun.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado"), 0)
            '            Case 7
            '                lbl_jul.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado"), 0)
            '            Case 8
            '                lbl_ago.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado"), 0)
            '            Case 9
            '                lbl_set.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado"), 0)
            '            Case 10
            '                lbl_out.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado"), 0)
            '            Case 11
            '                lbl_nov.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado"), 0)
            '            Case 12
            '                lbl_dez.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado"), 0)
            '        End Select

            '        lbl_media_anual.Text = lbl_media_anual.Text + dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")  ' 22/08/2017 chamado 2565

            '    Next

            '    lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 0)  ' 22/08/2017 chamado 2565

            'End If

            ''=======================================================
            '' CALCULO DO %
            ''=======================================================
            'If lbl_seq.Text = 3 Then  'Se linha do %

            '    'Inicializa 
            '    lbl_jan.Text = "0"
            '    lbl_fev.Text = "0"
            '    lbl_mar.Text = "0"
            '    lbl_abr.Text = "0"
            '    lbl_mai.Text = "0"
            '    lbl_jun.Text = "0"
            '    lbl_jul.Text = "0"
            '    lbl_ago.Text = "0"
            '    lbl_set.Text = "0"
            '    lbl_out.Text = "0"
            '    lbl_nov.Text = "0"
            '    lbl_dez.Text = "0"

            '    lbl_nr_ano.Text = "%"
            '    Dim dsVolume As DataSet = analiseesalq.getCurvaAbcVolumeLeiteRejeitadoATB   ' Traz volume agrupados por referencia

            '    lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

            '    For li = 0 To dsVolume.Tables(0).Rows.Count - 1
            '        Select Case dsVolume.Tables(0).Rows(li).Item("nr_mes").ToString
            '            Case 1
            '                lbl_jan.Text = dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")
            '            Case 2
            '                lbl_fev.Text = dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")
            '            Case 3
            '                lbl_mar.Text = dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")
            '            Case 4
            '                lbl_abr.Text = dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")
            '            Case 5
            '                lbl_mai.Text = dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")
            '            Case 6
            '                lbl_jun.Text = dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")
            '            Case 7
            '                lbl_jul.Text = dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")
            '            Case 8
            '                lbl_ago.Text = dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")
            '            Case 9
            '                lbl_set.Text = dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")
            '            Case 10
            '                lbl_out.Text = dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")
            '            Case 11
            '                lbl_nov.Text = dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")
            '            Case 12
            '                lbl_dez.Text = dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")
            '        End Select

            '        lbl_media_anual.Text = lbl_media_anual.Text + dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")  ' 22/08/2017 chamado 2565

            '    Next


            '    'Dim dsComplienceVolumeTotal As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI()
            '    Dim dsComplienceVolumeTotal As DataSet = analiseesalq.getCurvaAbcVolumeLeiteProdutores   ' 24/08/2017 - Traz volume dos produtores independente se possui teor

            '    'lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

            '    For li = 0 To dsComplienceVolumeTotal.Tables(0).Rows.Count - 1

            '        lvolumetotal = dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_volume_total")
            '        lvolumetotal_anual = lvolumetotal_anual + lvolumetotal

            '        Select Case dsComplienceVolumeTotal.Tables(0).Rows(li).Item("nr_mes").ToString
            '            Case 1
            '                lbl_jan.Text = FormatNumber((lbl_jan.Text / lvolumetotal) * 100, 3)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            '            Case 2
            '                lbl_fev.Text = FormatNumber((lbl_fev.Text / lvolumetotal) * 100, 3)
            '            Case 3
            '                lbl_mar.Text = FormatNumber((lbl_mar.Text / lvolumetotal) * 100, 3)
            '            Case 4
            '                lbl_abr.Text = FormatNumber((lbl_abr.Text / lvolumetotal) * 100, 3)
            '            Case 5
            '                lbl_mai.Text = FormatNumber((lbl_mai.Text / lvolumetotal) * 100, 3)
            '            Case 6
            '                lbl_jun.Text = FormatNumber((lbl_jun.Text / lvolumetotal) * 100, 3)
            '            Case 7
            '                lbl_jul.Text = FormatNumber((lbl_jul.Text / lvolumetotal) * 100, 3)
            '            Case 8
            '                lbl_ago.Text = FormatNumber((lbl_ago.Text / lvolumetotal) * 100, 3)
            '            Case 9
            '                lbl_set.Text = FormatNumber((lbl_set.Text / lvolumetotal) * 100, 3)
            '            Case 10
            '                lbl_out.Text = FormatNumber((lbl_out.Text / lvolumetotal) * 100, 3)
            '            Case 11
            '                lbl_nov.Text = FormatNumber((lbl_nov.Text / lvolumetotal) * 100, 3)
            '            Case 12
            '                lbl_dez.Text = FormatNumber((lbl_dez.Text / lvolumetotal) * 100, 3)
            '        End Select

            '        'lbl_media_anual.Text = lbl_media_anual.Text + dsVolume.Tables(0).Rows(li).Item("nr_volume_rejeitado")  ' 22/08/2017 chamado 2565

            '    Next

            '    If lvolumetotal_anual > 0 Then
            '        lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text / lvolumetotal_anual) * 100, 2).ToString & "%"  ' 22/08/2017 chamado 2565
            '    End If

            '    lbl_jan.Text = IIf(CDec(lbl_jan.Text) = 0, "", lbl_jan.Text)
            '    lbl_fev.Text = IIf(CDec(lbl_fev.Text) = 0, "", lbl_fev.Text)
            '    lbl_mar.Text = IIf(CDec(lbl_mar.Text) = 0, "", lbl_mar.Text)
            '    lbl_abr.Text = IIf(CDec(lbl_abr.Text) = 0, "", lbl_abr.Text)
            '    lbl_mai.Text = IIf(CDec(lbl_mai.Text) = 0, "", lbl_mai.Text)
            '    lbl_jun.Text = IIf(CDec(lbl_jun.Text) = 0, "", lbl_jun.Text)
            '    lbl_jul.Text = IIf(CDec(lbl_jul.Text) = 0, "", lbl_jul.Text)
            '    lbl_ago.Text = IIf(CDec(lbl_ago.Text) = 0, "", lbl_ago.Text)
            '    lbl_set.Text = IIf(CDec(lbl_set.Text) = 0, "", lbl_set.Text)
            '    lbl_out.Text = IIf(CDec(lbl_out.Text) = 0, "", lbl_out.Text)
            '    lbl_nov.Text = IIf(CDec(lbl_nov.Text) = 0, "", lbl_nov.Text)
            '    lbl_dez.Text = IIf(CDec(lbl_dez.Text) = 0, "", lbl_dez.Text)

            'End If

        End If

    End Sub

    Protected Sub gridTracadoControlado_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridTracadoControlado.RowDataBound
        If (e.Row.RowType = DataControlRowType.Header) Then

            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            lbl_nr_ano.Text = txt_ano.Text

        End If



        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim lvolumetotalcooperativa As Decimal
            Dim lvolumetotalprodutor As Decimal

            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_seq As Label = CType(e.Row.FindControl("lbl_seq"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            ' ''Dim analiseesalq As New AnaliseEsalq

            ' ''analiseesalq.dt_referencia_ini = "01/01/" & lbl_nr_ano.Text
            ' ''analiseesalq.dt_referencia_fim = "31/12/" & lbl_nr_ano.Text
            ' ''analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            ' ''If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
            ' ''    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            ' ''Else
            ' ''    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            ' ''End If

            '' '' adri 16/08/2017 - chamado 2564 - i
            ' ''If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
            ' ''    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            ' ''End If

            ' ''If Trim(ViewState.Item("id_propriedade")) <> "" Then
            ' ''    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            ' ''End If
            '' '' adri 16/08/2017 - chamado 2564 - f


            '=======================================================
            ' VOLUME TOTAL DE PRODUTORES 
            '=======================================================
            If lbl_seq.Text = 1 Then  'Se linha do Volume Total Produtores

                'lbl_nr_ano.Text = "% Traçado e Controlado "
                lbl_nr_ano.Text = "% Volume Produtores "  ' 22/08/2017 chamado xxxx
                ''analiseesalq.id_grupo = 1  ' Produtores
                ' ''Dim dsVolume As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI   ' Traz volume agrupados por referencia
                ''Dim dsVolume As DataSet = analiseesalq.getCurvaAbcVolumeLeiteProdutores   ' Traz volume agrupados por referencia sem verificar se tem contas de teor

                ''lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

                ''For li = 0 To dsVolume.Tables(0).Rows.Count - 1
                ''    Select Case dsVolume.Tables(0).Rows(li).Item("nr_mes").ToString
                ''        Case 1
                ''            lbl_jan.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 2
                ''            lbl_fev.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 3
                ''            lbl_mar.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 4
                ''            lbl_abr.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 5
                ''            lbl_mai.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 6
                ''            lbl_jun.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 7
                ''            lbl_jul.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 8
                ''            lbl_ago.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 9
                ''            lbl_set.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 10
                ''            lbl_out.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 11
                ''            lbl_nov.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 12
                ''            lbl_dez.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''    End Select

                ''    lbl_media_anual.Text = lbl_media_anual.Text + dsVolume.Tables(0).Rows(li).Item("nr_volume_total")  ' 22/08/2017 chamado 2565 (volume do produtor no ano)

                ''Next

                '=======================================================
                ' CALCULO DO % PRODUTORES
                '=======================================================
                'Inicializa
                lbl_jan.Text = IIf(Not IsNumeric(lbl_jan.Text), 0, lbl_jan.Text)
                lbl_fev.Text = IIf(Not IsNumeric(lbl_fev.Text), 0, lbl_fev.Text)
                lbl_mar.Text = IIf(Not IsNumeric(lbl_mar.Text), 0, lbl_mar.Text)
                lbl_abr.Text = IIf(Not IsNumeric(lbl_abr.Text), 0, lbl_abr.Text)
                lbl_mai.Text = IIf(Not IsNumeric(lbl_mai.Text), 0, lbl_mai.Text)
                lbl_jun.Text = IIf(Not IsNumeric(lbl_jun.Text), 0, lbl_jun.Text)
                lbl_jul.Text = IIf(Not IsNumeric(lbl_jul.Text), 0, lbl_jul.Text)
                lbl_ago.Text = IIf(Not IsNumeric(lbl_ago.Text), 0, lbl_ago.Text)
                lbl_set.Text = IIf(Not IsNumeric(lbl_set.Text), 0, lbl_set.Text)
                lbl_out.Text = IIf(Not IsNumeric(lbl_out.Text), 0, lbl_out.Text)
                lbl_nov.Text = IIf(Not IsNumeric(lbl_nov.Text), 0, lbl_nov.Text)
                lbl_dez.Text = IIf(Not IsNumeric(lbl_dez.Text), 0, lbl_dez.Text)
                lbl_media_anual.Text = IIf(Not IsNumeric(lbl_media_anual.Text), 0, lbl_media_anual.Text)


                ''Dim dsVolumeCooperativa As DataSet = analiseesalq.getCurvaAbcVolumeLeiteCooperativa()   ' Traz volume cooperativas agrupados por referencia
                ''For li = 0 To dsVolumeCooperativa.Tables(0).Rows.Count - 1

                ''    lvolumetotalcooperativa = dsVolumeCooperativa.Tables(0).Rows(li).Item("nr_volume_cooperativa")

                ''    Select Case dsVolumeCooperativa.Tables(0).Rows(li).Item("nr_mes").ToString
                ''        Case 1
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_jan.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_jan.Text = FormatNumber((lbl_jan.Text / lvolumetotal) * 100, 2)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                ''        Case 2
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_fev.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_fev.Text = FormatNumber((lbl_fev.Text / lvolumetotal) * 100, 2)
                ''        Case 3
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_mar.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_mar.Text = FormatNumber((lbl_mar.Text / lvolumetotal) * 100, 2)
                ''        Case 4
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_abr.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_abr.Text = FormatNumber((lbl_abr.Text / lvolumetotal) * 100, 2)
                ''        Case 5
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_mai.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_mai.Text = FormatNumber((lbl_mai.Text / lvolumetotal) * 100, 2)
                ''        Case 6
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_jun.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_jun.Text = FormatNumber((lbl_jun.Text / lvolumetotal) * 100, 2)
                ''        Case 7
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_jul.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_jul.Text = FormatNumber((lbl_jul.Text / lvolumetotal) * 100, 2)
                ''        Case 8
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_ago.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_ago.Text = FormatNumber((lbl_ago.Text / lvolumetotal) * 100, 2)
                ''        Case 9
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_set.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_set.Text = FormatNumber((lbl_set.Text / lvolumetotal) * 100, 2)
                ''        Case 10
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_out.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_out.Text = FormatNumber((lbl_out.Text / lvolumetotal) * 100, 2)
                ''        Case 11
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_nov.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_nov.Text = FormatNumber((lbl_nov.Text / lvolumetotal) * 100, 2)
                ''        Case 12
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_dez.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_dez.Text = FormatNumber((lbl_dez.Text / lvolumetotal) * 100, 2)
                ''    End Select

                ''    lvolumetotal_anual = lvolumetotal_anual + lvolumetotal ' 22/08/2017 chamado 2565  *volume total de produtores + cooperativas no ano)

                ''Next

                ''lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text / lvolumetotal_anual) * 100, 2).ToString   ' 22/08/2017 chamado 2565

                lbl_jan.Text = IIf(CDec(lbl_jan.Text) = 0, "", FormatNumber(lbl_jan.Text, 2))
                lbl_fev.Text = IIf(CDec(lbl_fev.Text) = 0, "", FormatNumber(lbl_fev.Text, 2))
                lbl_mar.Text = IIf(CDec(lbl_mar.Text) = 0, "", FormatNumber(lbl_mar.Text, 2))
                lbl_abr.Text = IIf(CDec(lbl_abr.Text) = 0, "", FormatNumber(lbl_abr.Text, 2))
                lbl_mai.Text = IIf(CDec(lbl_mai.Text) = 0, "", FormatNumber(lbl_mai.Text, 2))
                lbl_jun.Text = IIf(CDec(lbl_jun.Text) = 0, "", FormatNumber(lbl_jun.Text, 2))
                lbl_jul.Text = IIf(CDec(lbl_jul.Text) = 0, "", FormatNumber(lbl_jul.Text, 2))
                lbl_ago.Text = IIf(CDec(lbl_ago.Text) = 0, "", FormatNumber(lbl_ago.Text, 2))
                lbl_set.Text = IIf(CDec(lbl_set.Text) = 0, "", FormatNumber(lbl_set.Text, 2))
                lbl_out.Text = IIf(CDec(lbl_out.Text) = 0, "", FormatNumber(lbl_out.Text, 2))
                lbl_nov.Text = IIf(CDec(lbl_nov.Text) = 0, "", FormatNumber(lbl_nov.Text, 2))
                lbl_dez.Text = IIf(CDec(lbl_dez.Text) = 0, "", FormatNumber(lbl_dez.Text, 2))
                lbl_media_anual.Text = IIf(CDec(lbl_media_anual.Text) = 0, "", FormatNumber(lbl_media_anual.Text, 2))

                ' '' Se o campo tem valor e não tem casas decimais, significa que não calculou o percentual, e se não calculou é porque não tinha o volume da cooperativa no mes, então assume 100%
                ''lbl_jan.Text = IIf(IsNumeric(lbl_jan.Text) And InStr(1, lbl_jan.Text, ",", 1) = 0, 100, lbl_jan.Text)
                ''lbl_fev.Text = IIf(IsNumeric(lbl_fev.Text) And InStr(1, lbl_fev.Text, ",", 1) = 0, 100, lbl_fev.Text)
                ''lbl_mar.Text = IIf(IsNumeric(lbl_mar.Text) And InStr(1, lbl_mar.Text, ",", 1) = 0, 100, lbl_mar.Text)
                ''lbl_abr.Text = IIf(IsNumeric(lbl_abr.Text) And InStr(1, lbl_abr.Text, ",", 1) = 0, 100, lbl_abr.Text)
                ''lbl_mai.Text = IIf(IsNumeric(lbl_mai.Text) And InStr(1, lbl_mai.Text, ",", 1) = 0, 100, lbl_mai.Text)
                ''lbl_jun.Text = IIf(IsNumeric(lbl_jun.Text) And InStr(1, lbl_jun.Text, ",", 1) = 0, 100, lbl_jun.Text)
                ''lbl_jul.Text = IIf(IsNumeric(lbl_jul.Text) And InStr(1, lbl_jul.Text, ",", 1) = 0, 100, lbl_jul.Text)
                ''lbl_ago.Text = IIf(IsNumeric(lbl_ago.Text) And InStr(1, lbl_ago.Text, ",", 1) = 0, 100, lbl_ago.Text)
                ''lbl_set.Text = IIf(IsNumeric(lbl_set.Text) And InStr(1, lbl_set.Text, ",", 1) = 0, 100, lbl_set.Text)
                ''lbl_out.Text = IIf(IsNumeric(lbl_out.Text) And InStr(1, lbl_out.Text, ",", 1) = 0, 100, lbl_out.Text)
                ''lbl_nov.Text = IIf(IsNumeric(lbl_nov.Text) And InStr(1, lbl_nov.Text, ",", 1) = 0, 100, lbl_nov.Text)
                ''lbl_dez.Text = IIf(IsNumeric(lbl_dez.Text) And InStr(1, lbl_dez.Text, ",", 1) = 0, 100, lbl_dez.Text)

            End If


            '=======================================================
            '  VOLUME TOTAL DE COOPERATIVAS 
            '=======================================================
            If lbl_seq.Text = 2 Then  'Se linha do Volume Cooperativas

                'lbl_nr_ano.Text = "% Traçado "
                lbl_nr_ano.Text = "% Volume Cooperativas "  ' 22/08/2017 chamado xxxx

                ' ''Dim dsVolume As DataSet = analiseesalq.getCurvaAbcVolumeLeiteCooperativa()   ' Traz volume cooperativas agrupados por referencia

                ' ''lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

                ' ''For li = 0 To dsVolume.Tables(0).Rows.Count - 1
                ' ''    Select Case dsVolume.Tables(0).Rows(li).Item("nr_mes").ToString
                ' ''        Case 1
                ' ''            lbl_jan.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 2
                ' ''            lbl_fev.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 3
                ' ''            lbl_mar.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 4
                ' ''            lbl_abr.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 5
                ' ''            lbl_mai.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 6
                ' ''            lbl_jun.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 7
                ' ''            lbl_jul.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 8
                ' ''            lbl_ago.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 9
                ' ''            lbl_set.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 10
                ' ''            lbl_out.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 11
                ' ''            lbl_nov.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 12
                ' ''            lbl_dez.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''    End Select

                ' ''    lbl_media_anual.Text = lbl_media_anual.Text + dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa")  ' 22/08/2017 chamado 2565

                ' ''Next

                '=======================================================
                ' CALCULO DO % COOPERATIVAS
                '=======================================================
                'Inicializa 
                lbl_jan.Text = IIf(Not IsNumeric(lbl_jan.Text), 0, lbl_jan.Text)
                lbl_fev.Text = IIf(Not IsNumeric(lbl_fev.Text), 0, lbl_fev.Text)
                lbl_mar.Text = IIf(Not IsNumeric(lbl_mar.Text), 0, lbl_mar.Text)
                lbl_abr.Text = IIf(Not IsNumeric(lbl_abr.Text), 0, lbl_abr.Text)
                lbl_mai.Text = IIf(Not IsNumeric(lbl_mai.Text), 0, lbl_mai.Text)
                lbl_jun.Text = IIf(Not IsNumeric(lbl_jun.Text), 0, lbl_jun.Text)
                lbl_jul.Text = IIf(Not IsNumeric(lbl_jul.Text), 0, lbl_jul.Text)
                lbl_ago.Text = IIf(Not IsNumeric(lbl_ago.Text), 0, lbl_ago.Text)
                lbl_set.Text = IIf(Not IsNumeric(lbl_set.Text), 0, lbl_set.Text)
                lbl_out.Text = IIf(Not IsNumeric(lbl_out.Text), 0, lbl_out.Text)
                lbl_nov.Text = IIf(Not IsNumeric(lbl_nov.Text), 0, lbl_nov.Text)
                lbl_dez.Text = IIf(Not IsNumeric(lbl_dez.Text), 0, lbl_dez.Text)
                lbl_media_anual.Text = IIf(Not IsNumeric(lbl_media_anual.Text), 0, lbl_media_anual.Text)

                ' ''analiseesalq.id_grupo = 1  ' Produtores
                '' ''Dim dsVolumeProdutores As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI   ' Traz volume agrupados por referencia
                ' ''Dim dsVolumeProdutores As DataSet = analiseesalq.getCurvaAbcVolumeLeiteProdutores   ' 23/08/2017 Traz volume agrupados por referencia sem verificar se tem contas de teor

                ' ''For li = 0 To dsVolumeProdutores.Tables(0).Rows.Count - 1

                ' ''    lvolumetotalprodutor = dsVolumeProdutores.Tables(0).Rows(li).Item("nr_volume_total")

                ' ''    Select Case dsVolumeProdutores.Tables(0).Rows(li).Item("nr_mes").ToString
                ' ''        Case 1
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_jan.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_jan.Text = FormatNumber((lbl_jan.Text / lvolumetotal) * 100, 2)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                ' ''        Case 2
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_fev.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_fev.Text = FormatNumber((lbl_fev.Text / lvolumetotal) * 100, 2)
                ' ''        Case 3
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_mar.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_mar.Text = FormatNumber((lbl_mar.Text / lvolumetotal) * 100, 2)
                ' ''        Case 4
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_abr.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_abr.Text = FormatNumber((lbl_abr.Text / lvolumetotal) * 100, 2)
                ' ''        Case 5
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_mai.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_mai.Text = FormatNumber((lbl_mai.Text / lvolumetotal) * 100, 2)
                ' ''        Case 6
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_jun.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_jun.Text = FormatNumber((lbl_jun.Text / lvolumetotal) * 100, 2)
                ' ''        Case 7
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_jul.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_jul.Text = FormatNumber((lbl_jul.Text / lvolumetotal) * 100, 2)
                ' ''        Case 8
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_ago.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_ago.Text = FormatNumber((lbl_ago.Text / lvolumetotal) * 100, 2)
                ' ''        Case 9
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_set.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_set.Text = FormatNumber((lbl_set.Text / lvolumetotal) * 100, 2)
                ' ''        Case 10
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_out.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_out.Text = FormatNumber((lbl_out.Text / lvolumetotal) * 100, 2)
                ' ''        Case 11
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_nov.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_nov.Text = FormatNumber((lbl_nov.Text / lvolumetotal) * 100, 2)
                ' ''        Case 12
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_dez.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_dez.Text = FormatNumber((lbl_dez.Text / lvolumetotal) * 100, 2)
                ' ''    End Select

                ' ''    lvolumetotal_anual = lvolumetotal_anual + lvolumetotal ' 22/08/2017 chamado 2565

                ' ''Next

                ' ''lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text / lvolumetotal_anual) * 100, 2).ToString   ' 22/08/2017 chamado 2565

                lbl_jan.Text = IIf(CDec(lbl_jan.Text) = 0, "", FormatNumber(lbl_jan.Text, 2))
                lbl_fev.Text = IIf(CDec(lbl_fev.Text) = 0, "", FormatNumber(lbl_fev.Text, 2))
                lbl_mar.Text = IIf(CDec(lbl_mar.Text) = 0, "", FormatNumber(lbl_mar.Text, 2))
                lbl_abr.Text = IIf(CDec(lbl_abr.Text) = 0, "", FormatNumber(lbl_abr.Text, 2))
                lbl_mai.Text = IIf(CDec(lbl_mai.Text) = 0, "", FormatNumber(lbl_mai.Text, 2))
                lbl_jun.Text = IIf(CDec(lbl_jun.Text) = 0, "", FormatNumber(lbl_jun.Text, 2))
                lbl_jul.Text = IIf(CDec(lbl_jul.Text) = 0, "", FormatNumber(lbl_jul.Text, 2))
                lbl_ago.Text = IIf(CDec(lbl_ago.Text) = 0, "", FormatNumber(lbl_ago.Text, 2))
                lbl_set.Text = IIf(CDec(lbl_set.Text) = 0, "", FormatNumber(lbl_set.Text, 2))
                lbl_out.Text = IIf(CDec(lbl_out.Text) = 0, "", FormatNumber(lbl_out.Text, 2))
                lbl_nov.Text = IIf(CDec(lbl_nov.Text) = 0, "", FormatNumber(lbl_nov.Text, 2))
                lbl_dez.Text = IIf(CDec(lbl_dez.Text) = 0, "", FormatNumber(lbl_dez.Text, 2))
                lbl_media_anual.Text = IIf(CDec(lbl_media_anual.Text) = 0, "", FormatNumber(lbl_media_anual.Text, 2))

                '' '' Se o campo tem valor e não tem casas decimais, significa que não calculou o percentual, e se não calculou é porque não tinha o volume do produtor no mes, então assume 100%
                ' ''lbl_jan.Text = IIf(IsNumeric(lbl_jan.Text) And InStr(1, lbl_jan.Text, ",", 1) = 0, 100, lbl_jan.Text)
                ' ''lbl_fev.Text = IIf(IsNumeric(lbl_fev.Text) And InStr(1, lbl_fev.Text, ",", 1) = 0, 100, lbl_fev.Text)
                ' ''lbl_mar.Text = IIf(IsNumeric(lbl_mar.Text) And InStr(1, lbl_mar.Text, ",", 1) = 0, 100, lbl_mar.Text)
                ' ''lbl_abr.Text = IIf(IsNumeric(lbl_abr.Text) And InStr(1, lbl_abr.Text, ",", 1) = 0, 100, lbl_abr.Text)
                ' ''lbl_mai.Text = IIf(IsNumeric(lbl_mai.Text) And InStr(1, lbl_mai.Text, ",", 1) = 0, 100, lbl_mai.Text)
                ' ''lbl_jun.Text = IIf(IsNumeric(lbl_jun.Text) And InStr(1, lbl_jun.Text, ",", 1) = 0, 100, lbl_jun.Text)
                ' ''lbl_jul.Text = IIf(IsNumeric(lbl_jul.Text) And InStr(1, lbl_jul.Text, ",", 1) = 0, 100, lbl_jul.Text)
                ' ''lbl_ago.Text = IIf(IsNumeric(lbl_ago.Text) And InStr(1, lbl_ago.Text, ",", 1) = 0, 100, lbl_ago.Text)
                ' ''lbl_set.Text = IIf(IsNumeric(lbl_set.Text) And InStr(1, lbl_set.Text, ",", 1) = 0, 100, lbl_set.Text)
                ' ''lbl_out.Text = IIf(IsNumeric(lbl_out.Text) And InStr(1, lbl_out.Text, ",", 1) = 0, 100, lbl_out.Text)
                ' ''lbl_nov.Text = IIf(IsNumeric(lbl_nov.Text) And InStr(1, lbl_nov.Text, ",", 1) = 0, 100, lbl_nov.Text)
                ' ''lbl_dez.Text = IIf(IsNumeric(lbl_dez.Text) And InStr(1, lbl_dez.Text, ",", 1) = 0, 100, lbl_dez.Text)

            End If
        End If

    End Sub

    Protected Sub form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles form1.Load

    End Sub
End Class
