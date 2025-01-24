Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_curvaabc_overview_qualidade

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("txt_dt_referencia") = Me.txt_dt_referencia.Text.Trim
        ViewState.Item("id_grupo") = Me.cbo_Grupo.SelectedValue  ' adri 09/02/2017 - chamado 2500 acertos (filtro para Produtores / Cooperativas)

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_curvaabc_overview_qualidade.aspx?st_incluirlog=N")

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
                usuariolog.id_menu_item = 177
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If


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


            txt_dt_referencia.Text = DateTime.Parse(Now).ToString("MM/yyyy")

            ViewState.Item("sortExpression") = ""

            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim analiseesalq As New AnaliseEsalq

            analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_referencia")
            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            Else
                analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            End If
            analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)

            Dim dsComplienceVolumeTotal As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotal()

            ViewState.Item("nr_volume_total") = 0   ' Total do Volume da referencia (COMPL e NCOMPL)
            If dsComplienceVolumeTotal.Tables(0).Rows.Count() > 0 Then
                ViewState.Item("nr_volume_total") = dsComplienceVolumeTotal.Tables(0).Rows(0).Item("nr_volume_total")   ' Total do Volume da referencia (COMPL e NCOMPL)
            End If

            Dim dsOverviewSinteticoCBT As DataSet = analiseesalq.getCurvaAbcOverviewCBTSintetico()

            If (dsOverviewSinteticoCBT.Tables(0).Rows.Count > 0) Then
                gridCBT.Visible = True
                gridCBT.DataSource = Helper.getDataView(dsOverviewSinteticoCBT.Tables(0), "")
                gridCBT.DataBind()
            End If

            Dim dsOverviewSinteticoCCS As DataSet = analiseesalq.getCurvaAbcOverviewCCSSintetico()

            If (dsOverviewSinteticoCCS.Tables(0).Rows.Count > 0) Then
                gridCCS.Visible = True
                gridCCS.DataSource = Helper.getDataView(dsOverviewSinteticoCCS.Tables(0), "")
                gridCCS.DataBind()
            End If

            Dim dsOverviewSinteticoProteina As DataSet = analiseesalq.getCurvaAbcOverviewProteinaSintetico()

            If (dsOverviewSinteticoProteina.Tables(0).Rows.Count > 0) Then
                gridProteina.Visible = True
                gridProteina.DataSource = Helper.getDataView(dsOverviewSinteticoProteina.Tables(0), "")
                gridProteina.DataBind()
            End If

            Dim dsOverviewSinteticoGordura As DataSet = analiseesalq.getCurvaAbcOverviewGorduraSintetico()

            If (dsOverviewSinteticoGordura.Tables(0).Rows.Count > 0) Then
                gridGordura.Visible = True
                gridGordura.DataSource = Helper.getDataView(dsOverviewSinteticoGordura.Tables(0), "")
                gridGordura.DataBind()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("txt_dt_referencia") = Me.txt_dt_referencia.Text.Trim
        ViewState.Item("id_grupo") = Me.cbo_Grupo.SelectedValue  ' adri 09/02/2017 - chamado 2500 acertos (filtro para Produtores / Cooperativas)

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 177
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        Response.Redirect("frm_curvaabc_overview_qualidade_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&txt_dt_referencia=" + ViewState.Item("txt_dt_referencia").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString())

    End Sub
    'Mirella - 08/02/2017 - f


    Protected Sub gridCBT_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCBT.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_faixa_ini As Label = CType(e.Row.FindControl("lbl_faixa_ini"), Label)
            Dim lbl_faixa_fim As Label = CType(e.Row.FindControl("lbl_faixa_fim"), Label)
            Dim lbl_geral_mensal As Label = CType(e.Row.FindControl("lbl_geral_mensal"), Label)
            Dim lbl_geral_trimestral As Label = CType(e.Row.FindControl("lbl_geral_trimestral"), Label)
            Dim lbl_geral_com_educampo As Label = CType(e.Row.FindControl("lbl_geral_com_educampo"), Label)
            Dim lbl_geral_sem_educampo As Label = CType(e.Row.FindControl("lbl_geral_sem_educampo"), Label)
            Dim lbl_geral_com_comquali As Label = CType(e.Row.FindControl("lbl_geral_com_comquali"), Label)
            Dim lbl_geral_sem_comquali As Label = CType(e.Row.FindControl("lbl_geral_sem_comquali"), Label)

            If ViewState.Item("nr_volume_total") > 0 Then

                '====================
                ' GERAL MENSAL
                '====================
                ViewState.Item("nr_volume_geral_mensal_faixa") = lbl_geral_mensal.Text  ' 14/08/2017 - chamado 2563
                lbl_geral_mensal.Text = FormatNumber((lbl_geral_mensal.Text / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"

                '====================
                ' GERAL TRIMESTRAL
                '====================
                Dim analiseesalq As New AnaliseEsalq
                analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_referencia")
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                End If
                analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                analiseesalq.id_conta_teor = "252"  ' conta 0092 teor CBT trimestral
                analiseesalq.nr_faixa_ini = CDec(lbl_faixa_ini.Text)
                analiseesalq.nr_faixa_fim = CDec(lbl_faixa_fim.Text)
                Dim dsVolumeTeor As DataSet = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixa()
                lbl_geral_trimestral.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MESAL COM EDUCAMPO
                '====================
                analiseesalq.id_conta_teor = "264"  ' conta 0092 teor CBT mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComEducampo()
                'lbl_geral_com_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                lbl_geral_com_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_geral_mensal_faixa")) * 100, 2).ToString & "%"   ' 14/08/2017 - chamado 2563

                '====================
                ' MESAL SEM EDUCAMPO
                '====================
                analiseesalq.id_conta_teor = "264"  ' conta 0092 teor CBT mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemEducampo()
                'lbl_geral_sem_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                lbl_geral_sem_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_geral_mensal_faixa")) * 100, 2).ToString & "%"    ' 14/08/2017 - chamado 2563

                '====================
                ' MESAL COM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "264"  ' conta 0092 teor CBT mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComComquali()
                'lbl_geral_com_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                lbl_geral_com_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_geral_mensal_faixa")) * 100, 2).ToString & "%"   ' 14/08/2017 - chamado 2563

                '====================
                ' MESAL SEM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "264"  ' conta 0092 teor CBT mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemComquali()
                'lbl_geral_sem_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                lbl_geral_sem_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_geral_mensal_faixa")) * 100, 2).ToString & "%"   ' 14/08/2017 - chamado 2563

            End If

        End If
    End Sub

    Protected Sub gridCCS_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCCS.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_faixa_ini As Label = CType(e.Row.FindControl("lbl_faixa_ini"), Label)
            Dim lbl_faixa_fim As Label = CType(e.Row.FindControl("lbl_faixa_fim"), Label)
            Dim lbl_geral_mensal As Label = CType(e.Row.FindControl("lbl_geral_mensal"), Label)
            Dim lbl_geral_trimestral As Label = CType(e.Row.FindControl("lbl_geral_trimestral"), Label)
            Dim lbl_geral_com_educampo As Label = CType(e.Row.FindControl("lbl_geral_com_educampo"), Label)
            Dim lbl_geral_sem_educampo As Label = CType(e.Row.FindControl("lbl_geral_sem_educampo"), Label)
            Dim lbl_geral_com_comquali As Label = CType(e.Row.FindControl("lbl_geral_com_comquali"), Label)
            Dim lbl_geral_sem_comquali As Label = CType(e.Row.FindControl("lbl_geral_sem_comquali"), Label)

            If ViewState.Item("nr_volume_total") > 0 Then

                '====================
                ' GERAL MENSAL
                '====================
                lbl_geral_mensal.Text = FormatNumber((lbl_geral_mensal.Text / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"

                '====================
                ' GERAL TRIMESTRAL
                '====================
                Dim analiseesalq As New AnaliseEsalq
                analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_referencia")
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                End If
                analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                analiseesalq.id_conta_teor = "253"  ' conta 0092 teor CCS trimestral
                analiseesalq.nr_faixa_ini = CDec(lbl_faixa_ini.Text)
                analiseesalq.nr_faixa_fim = CDec(lbl_faixa_fim.Text)
                Dim dsVolumeTeor As DataSet = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixa()
                lbl_geral_trimestral.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MESAL COM EDUCAMPO
                '====================
                analiseesalq.id_conta_teor = "265"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComEducampo()
                lbl_geral_com_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MESAL SEM EDUCAMPO
                '====================
                analiseesalq.id_conta_teor = "265"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemEducampo()
                lbl_geral_sem_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MESAL COM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "265"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComComquali()
                lbl_geral_com_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MESAL SEM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "265"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemComquali()
                lbl_geral_sem_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

            End If

        End If

    End Sub

    Protected Sub gridProteina_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridProteina.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_faixa_ini As Label = CType(e.Row.FindControl("lbl_faixa_ini"), Label)
            Dim lbl_faixa_fim As Label = CType(e.Row.FindControl("lbl_faixa_fim"), Label)
            Dim lbl_geral_mensal As Label = CType(e.Row.FindControl("lbl_geral_mensal"), Label)
            Dim lbl_geral_trimestral As Label = CType(e.Row.FindControl("lbl_geral_trimestral"), Label)
            Dim lbl_geral_com_educampo As Label = CType(e.Row.FindControl("lbl_geral_com_educampo"), Label)
            Dim lbl_geral_sem_educampo As Label = CType(e.Row.FindControl("lbl_geral_sem_educampo"), Label)
            Dim lbl_geral_com_comquali As Label = CType(e.Row.FindControl("lbl_geral_com_comquali"), Label)
            Dim lbl_geral_sem_comquali As Label = CType(e.Row.FindControl("lbl_geral_sem_comquali"), Label)

            If ViewState.Item("nr_volume_total") > 0 Then

                '====================
                ' GERAL MENSAL
                '====================
                lbl_geral_mensal.Text = FormatNumber((lbl_geral_mensal.Text / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"

                '====================
                ' GERAL TRIMESTRAL (não tem para proteína)
                ''====================
                'Dim analiseesalq As New AnaliseEsalq
                'analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_referencia")
                'analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                'If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                '    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                'Else
                '    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                'End If
                'analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                'analiseesalq.id_conta_teor = "253"  ' conta 0092 teor Proteina trimestral
                'analiseesalq.nr_faixa_ini = CDec(lbl_faixa_ini.Text)
                'analiseesalq.nr_faixa_fim = CDec(lbl_faixa_fim.Text)
                'Dim dsVolumeTeor As DataSet = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixa()
                lbl_geral_trimestral.Text = "-"  ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL COM EDUCAMPO
                '====================
                Dim analiseesalq As New AnaliseEsalq
                analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_referencia")
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                End If
                analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                analiseesalq.id_conta_teor = "251"  ' conta 0092 teor Proteina mensal
                analiseesalq.nr_faixa_ini = CDec(lbl_faixa_ini.Text)
                analiseesalq.nr_faixa_fim = CDec(lbl_faixa_fim.Text)
                Dim dsVolumeTeor As DataSet = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComEducampo()
                lbl_geral_com_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL SEM EDUCAMPO
                '====================
                analiseesalq.id_conta_teor = "251"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemEducampo()
                lbl_geral_sem_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL COM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "251"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComComquali()
                lbl_geral_com_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL SEM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "251"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemComquali()
                lbl_geral_sem_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

            End If

        End If

    End Sub

    Protected Sub gridGordura_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridGordura.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_faixa_ini As Label = CType(e.Row.FindControl("lbl_faixa_ini"), Label)
            Dim lbl_faixa_fim As Label = CType(e.Row.FindControl("lbl_faixa_fim"), Label)
            Dim lbl_geral_mensal As Label = CType(e.Row.FindControl("lbl_geral_mensal"), Label)
            Dim lbl_geral_trimestral As Label = CType(e.Row.FindControl("lbl_geral_trimestral"), Label)
            Dim lbl_geral_com_educampo As Label = CType(e.Row.FindControl("lbl_geral_com_educampo"), Label)
            Dim lbl_geral_sem_educampo As Label = CType(e.Row.FindControl("lbl_geral_sem_educampo"), Label)
            Dim lbl_geral_com_comquali As Label = CType(e.Row.FindControl("lbl_geral_com_comquali"), Label)
            Dim lbl_geral_sem_comquali As Label = CType(e.Row.FindControl("lbl_geral_sem_comquali"), Label)

            If ViewState.Item("nr_volume_total") > 0 Then

                '====================
                ' GERAL MENSAL
                '====================
                lbl_geral_mensal.Text = FormatNumber((lbl_geral_mensal.Text / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"

                '====================
                ' GERAL TRIMESTRAL (não tem teor trimestral para gordura)
                ''====================
                lbl_geral_trimestral.Text = "-"

                '====================
                ' MENSAL COM EDUCAMPO
                '====================
                Dim analiseesalq As New AnaliseEsalq
                analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_referencia")
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                End If
                analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                analiseesalq.id_conta_teor = "156"  ' conta 0092 teor Gordura mensal
                analiseesalq.nr_faixa_ini = CDec(lbl_faixa_ini.Text)
                analiseesalq.nr_faixa_fim = CDec(lbl_faixa_fim.Text)
                Dim dsVolumeTeor As DataSet = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComEducampo()
                lbl_geral_com_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL SEM EDUCAMPO
                '====================
                analiseesalq.id_conta_teor = "156"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemEducampo()
                lbl_geral_sem_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL COM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "156"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComComquali()
                lbl_geral_com_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL SEM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "156"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemComquali()
                lbl_geral_sem_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

            End If

        End If

    End Sub
End Class
