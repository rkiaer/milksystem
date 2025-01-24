Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.Math


Partial Class lst_poupanca_aplicacao_bonus

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            Dim poupancacalculo As New PoupancaCalculoExecucao

            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("id_poupanca_parametro") = cbo_referencia_poupanca.SelectedValue
            ViewState.Item("id_cluster") = cbo_cluster.SelectedValue
            ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()

            If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            Else
                ViewState.Item("id_pessoa") = String.Empty
            End If

            If Not (Me.txt_id_propriedade.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("id_propriedade") = Me.txt_id_propriedade.Text.Trim()
            Else
                ViewState.Item("id_propriedade") = String.Empty
            End If

            Select Case cbo_aplicacao_bonus.SelectedValue
                Case 1 'Aplicação do bonus na central
                    ViewState.Item("st_bonus_poupanca_lancamento") = "S"
                    ViewState.Item("st_bonus_poupanca_central") = "S"

                Case 2 'aplicação do bonus em lancamentos
                    ViewState.Item("st_bonus_poupanca_lancamento") = "S"
                    ViewState.Item("st_bonus_poupanca_central") = "N"
                Case 3 'bonus nao aplicado
                    ViewState.Item("st_bonus_poupanca_lancamento") = "N"
                    ViewState.Item("st_bonus_poupanca_central") = "N"
                Case Else
                    ViewState.Item("st_bonus_poupanca_lancamento") = ""
                    ViewState.Item("st_bonus_poupanca_central") = ""

            End Select
            If Not (Me.txt_propriedade_titular.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("id_propriedade_titular") = Me.txt_propriedade_titular.Text.Trim()
            Else
                ViewState.Item("id_propriedade_titular") = String.Empty
            End If
            ViewState.Item("dt_referencia_ini_poupanca_parametro") = String.Concat("01/", Left(cbo_referencia_poupanca.SelectedItem.Text.Trim, 7)).ToString
            ViewState.Item("dt_referencia_fim_poupanca_parametro") = String.Concat("01/", Right(cbo_referencia_poupanca.SelectedItem.Text.Trim, 7)).ToString

            If chk_bonus_extra_concessao.Checked = True Then
                ViewState.Item("st_bonus_extra_concessao") = "S"
            Else
                ViewState.Item("st_bonus_extra_concessao") = "N"

            End If

            ' Sempre limpar todas as seleções do estabelecimento e referencia quando efetuar novo filtro - i
            Dim poupancaadesao As New PoupancaAdesao
            poupancaadesao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
            poupancaadesao.dt_referencia_fim = ViewState.Item("dt_referencia_fim_poupanca_parametro")
            poupancaadesao.st_selecao = "0"
            poupancaadesao.updatePoupancaAplicacaoBonusSelecaoTodos()


            loadData()
        End If
    End Sub
    Private Sub incluirPoupancaCalculoExecucao()

        Try

            Dim calculopoupanca As New PoupancaCalculoExecucao()

            ViewState.Item("id_poupanca_calculo_execucao") = 0
            calculopoupanca.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            If Trim(ViewState.Item("id_pessoa")) <> "" Then
                calculopoupanca.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            calculopoupanca.cd_pessoa = ViewState.Item("cd_pessoa")
            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                calculopoupanca.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If
            calculopoupanca.id_modificador = Session("id_login")
            calculopoupanca.st_tipo_calculo = "M" 'Indica que é calculo depoupanca MENSAL (M) e nao ANUAL (A)
            calculopoupanca.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
            calculopoupanca.dt_referencia = ViewState.Item("dt_referencia").ToString
            ViewState.Item("id_poupanca_calculo_execucao") = calculopoupanca.insertPoupancaCalculoExecucao()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_poupanca_aplicacao_bonus.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_poupanca_aplicacao_bonus.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
            '.Style("cursor") = "hand"
        End With


    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim cluster As New Cluster
            cbo_cluster.DataSource = cluster.getClusterByFilters()
            cbo_cluster.DataTextField = "nm_cluster"
            cbo_cluster.DataValueField = "id_cluster"
            cbo_cluster.DataBind()
            cbo_cluster.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim motivoconcessao As New PoupancaMotivoBonusConcessao
            cbo_motivoconcessaobonus.DataSource = motivoconcessao.getPoupancaMotivoBonusConcessao()
            cbo_motivoconcessaobonus.DataTextField = "nm_motivo_bonus_concessao"
            cbo_motivoconcessaobonus.DataValueField = "id_motivo_bonus_concessao"
            cbo_motivoconcessaobonus.DataBind()
            cbo_motivoconcessaobonus.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ViewState.Item("sortExpression") = "id_propriedade"
            ViewState.Item("aba_ativa") = 0 'Assume que a aba ativa é a da 1a aba
            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("poupancaaplicbonus", cbo_estabelecimento.ID).Equals("0")) And Not (customPage.getFilterValue("poupancaaplicbonus", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("poupancaaplicbonus", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = "0"
        End If

        If Not (customPage.getFilterValue("poupancaaplicbonus", cbo_referencia_poupanca.ID).Equals("0")) And Not (customPage.getFilterValue("poupancaaplicbonus", cbo_referencia_poupanca.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_poupanca_parametro") = customPage.getFilterValue("poupancaaplicbonus", cbo_referencia_poupanca.ID)
            cbo_referencia_poupanca.Enabled = True
            cbo_referencia_poupanca.Text = ViewState.Item("id_poupanca_parametro").ToString()
        Else
            ViewState.Item("id_poupanca_parametro") = "0"
        End If

        If Not (customPage.getFilterValue("poupancaaplicbonus", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("poupancaaplicbonus", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("poupancaaplicbonus", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("poupancaaplicbonus", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("poupancaaplicbonus", txt_id_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("poupancaaplicbonus", txt_id_propriedade.ID)
            txt_id_propriedade.Text = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("poupancaaplicbonus", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("poupancaaplicbonus", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("poupancaaplicbonus", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("poupancaaplicbonus", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If
        If (hasFilters) Then
            loadData()
            customPage.clearFilters("poupancaaplicbonus")
        End If

    End Sub

    Private Sub loadData()

        Try


            Dim poupancaparametro As New PoupancaParametro(ViewState.Item("id_poupanca_parametro"))

            Dim poupancaadesao As New PoupancaAdesao
            poupancaadesao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
            poupancaadesao.id_cluster = ViewState.Item("id_cluster")
            If Not ViewState.Item("id_propriedade").Equals(String.Empty) Then
                poupancaadesao.id_propriedade = ViewState.Item("id_propriedade")
            End If

            If Not ViewState.Item("id_pessoa").Equals(String.Empty) Then
                poupancaadesao.id_pessoa = ViewState.Item("id_pessoa")
            End If

            If Not ViewState.Item("id_propriedade_titular").Equals(String.Empty) Then
                poupancaadesao.id_propriedade_titular = ViewState.Item("id_propriedade_titular")
            End If
            poupancaadesao.st_bonus_poupanca_lancamento = ViewState.Item("st_bonus_poupanca_lancamento")
            poupancaadesao.st_bonus_poupanca_central = ViewState.Item("st_bonus_poupanca_central")

            poupancaadesao.dt_referencia_fim = ViewState.Item("dt_referencia_fim_poupanca_parametro")
            Dim dspoupancaadesao As DataSet

            'se situação de poupanca é ABERTA significa que não pode selecionar para aplicação de bonus
            Select Case poupancaparametro.id_situacao_poupanca
                Case "1" 'Aberto
                    Me.lbl_situacao_poupanca.Text = "Aberto"
                    Me.lk_bonus_central.Enabled = False
                    Me.lk_bonus_central.ToolTip = "Bônus de Poupança só pode ser aplicado após liberação do período de poupança."
                    Me.lk_bonus_lancamento.Enabled = False
                    Me.lk_bonus_lancamento.ToolTip = "Bônus de Poupança só pode ser aplicado após liberação do período de poupança."
                    Me.gridResults.Columns.Item(0).Visible = False 'coluna de seleção


                Case "2" 'Finalizado
                    Me.lbl_situacao_poupanca.Text = "Finalizado"
                    Me.lk_bonus_central.Enabled = False
                    Me.lk_bonus_central.ToolTip = "Bônus de Poupança só pode ser aplicado para períodos de poupança com situação Liberado."
                    Me.lk_bonus_lancamento.Enabled = False
                    Me.lk_bonus_lancamento.ToolTip = "Bônus de Poupança só pode ser aplicado para períodos de poupança com situação Liberado."
                    Me.gridResults.Columns.Item(0).Visible = False 'coluna de seleção

 
                Case "3" 'Liberado
                    Me.lbl_situacao_poupanca.Text = "Liberado"

                    Dim calculodefinitivo As New CalculoProdutor
                    calculodefinitivo.dt_referencia_start = DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_referencia_fim_poupanca_parametro"))).ToString("dd/MM/yyyy")
                    calculodefinitivo.dt_referencia_end = DateTime.Parse(calculodefinitivo.dt_referencia_start).ToString("dd/MM/yyyy")

                    'se não tem calculo definitivo do mes posterior ao final do periodo, deixa reaplicar bonus (O bonus de poupanca se paga na referencia posteior ao pedido)
                    If (calculodefinitivo.getCalculoDefinitivoByPeriodo Is Nothing) Then
                        Me.lk_bonus_central.Enabled = True
                        Me.lk_bonus_central.ToolTip = "Aplicar bônus de poupança na Central de Compras."
                        Me.lk_bonus_lancamento.Enabled = True
                        Me.lk_bonus_lancamento.ToolTip = "Aplicar bônus de poupança em Lançamentos para o próximo cálculo de produtor."
                    Else ' se tem calculo definitivo do mes posterior ao final do periodo, não deixa reaplicar bonus
                        Me.lk_bonus_central.Enabled = False
                        Me.lk_bonus_central.ToolTip = "Cálculo Definitivo já realizado para referência final do Programa de Poupança. O bônus não pode ser (re)aplicado."
                        Me.lk_bonus_lancamento.Enabled = False
                        Me.lk_bonus_lancamento.ToolTip = "Cálculo Definitivo já realizado para referência final do Programa de Poupança. O bônus não pode ser (re)aplicado."
                        Me.gridResults.Columns.Item(0).Visible = False 'coluna de seleção

                    End If

                    ''Busca os dados de bonus adesão com join com tabela de seleção (para buscar checks selecionados)
                    'poupancaadesao.tablename = "ms_poupanca_selecao"
                    'poupancaadesao.id_poupanca_selecao_execucao = poupancaadesao.getExecucaoPoupancaAdesao 'pega novo numero de execucao


            End Select

            If ViewState("aba_ativa") = 0 Then 'grupo produtores
                dspoupancaadesao = poupancaadesao.getPoupancaBonusbyAdesaoSelecao()
            Else
                If ViewState("aba_ativa") = 1 Then 'grupo produtores com relacionamento
                    dspoupancaadesao = poupancaadesao.getPoupancaBonusbyAdesaoSelecaoGrupos()
                End If
            End If
            Me.lbl_parametro_spend.Text = poupancaparametro.nr_spend_periodo.ToString

            Dim poupanca As New Poupanca
            poupanca.dt_referencia_ini = Convert.ToDateTime(ViewState.Item("dt_referencia_ini_poupanca_parametro")).ToString("dd/MM/yyyy")
            poupanca.dt_referencia_fim = Convert.ToDateTime(ViewState.Item("dt_referencia_fim_poupanca_parametro")).ToString("dd/MM/yyyy")
            Me.lbl_ultimo_calculo_poupanca.Text = poupanca.getPoupancaUltimoCalculoMensal

            If (dspoupancaadesao.Tables(0).Rows.Count > 0) Then
                If ViewState("aba_ativa") = 0 Then
                    Me.gridResults.Columns.Item(6).Visible = False
                Else
                    Me.gridResults.Columns.Item(6).Visible = True
                End If

                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dspoupancaadesao.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                Me.lk_bonus_central.Enabled = False
                Me.lk_bonus_central.ToolTip = String.Empty
                Me.lk_bonus_lancamento.Enabled = False
                Me.lk_bonus_lancamento.ToolTip = String.Empty
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()
            Case "nr_valor_spend"
                If (ViewState.Item("sortExpression")) = "nr_valor_spend asc" Then
                    ViewState.Item("sortExpression") = "nr_valor_spend desc"
                Else
                    ViewState.Item("sortExpression") = "nr_valor_spend asc"
                End If
            Case "nm_cluster"
                If (ViewState.Item("sortExpression")) = "nm_cluster asc" Then
                    ViewState.Item("sortExpression") = "nm_cluster desc"
                Else
                    ViewState.Item("sortExpression") = "nm_cluster asc"
                End If
            Case "dt_ref_ini_calc"
                If (ViewState.Item("sortExpression")) = "dt_ref_ini_calc asc" Then
                    ViewState.Item("sortExpression") = "dt_ref_ini_calc desc"
                Else
                    ViewState.Item("sortExpression") = "dt_ref_ini_calc asc"
                End If
           

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If
            Case "ds_produtor_abreviado"
                If (ViewState.Item("sortExpression")) = "ds_produtor_abreviado asc" Then
                    ViewState.Item("sortExpression") = "ds_produtor_abreviado desc"
                Else
                    ViewState.Item("sortExpression") = "ds_produtor_abreviado asc"
                End If
            Case "dt_adesao"
                If (ViewState.Item("sortExpression")) = "dt_adesao asc" Then
                    ViewState.Item("sortExpression") = "dt_adesao desc"
                Else
                    ViewState.Item("sortExpression") = "dt_adesao asc"
                End If
            Case "nr_tempo_adesao"
                If (ViewState.Item("sortExpression")) = "nr_tempo_adesao asc" Then
                    ViewState.Item("sortExpression") = "nr_tempo_adesao desc"
                Else
                    ViewState.Item("sortExpression") = "nr_tempo_adesao asc"
                End If
        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("poupancaaplicbonus", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("poupancaaplicbonus", cbo_referencia_poupanca.ID, ViewState.Item("id_poupanca_parametro").ToString)
            customPage.setFilter("poupancaaplicbonus", "PageIndex", gridResults.PageIndex.ToString())
            customPage.setFilter("poupancaaplicbonus", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("poupancaaplicbonus", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("poupancaaplicbonus", txt_id_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("poupancaaplicbonus", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function verificarCheckBox() As Boolean

        Try

            Dim li As Integer
            verificarCheckBox = False
            For li = 0 To gridResults.Rows.Count - 1
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    verificarCheckBox = True     ' Indica que tem alguma propriedade selecionada para o cálculo
                    Exit For
                End If
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        Try

            If (e.Row.RowType <> DataControlRowType.Header _
                And e.Row.RowType <> DataControlRowType.Footer _
                And e.Row.RowType <> DataControlRowType.Pager) Then

                Dim ck_item As Anthem.CheckBox = CType(e.Row.FindControl("ck_item"), Anthem.CheckBox)
                Dim st_selecao As Label = CType(e.Row.FindControl("st_selecao"), Label)
                Dim lbl_nr_volume As Label = CType(e.Row.FindControl("lbl_nr_volume"), Label)
                Dim lbl_nr_valor_compras_central As Label = CType(e.Row.FindControl("lbl_nr_valor_compras_central"), Label)
                Dim lbl_valor_bonus As Label = CType(e.Row.FindControl("lbl_valor_bonus"), Label)
                Dim lbl_valor_bonus_poupanca As Label = CType(e.Row.FindControl("lbl_valor_bonus_poupanca"), Label)
                Dim lbl_valor_bonus_transf As Label = CType(e.Row.FindControl("lbl_valor_bonus_transf"), Label)
                Dim lbl_nr_valor_spend As Label = CType(e.Row.FindControl("lbl_nr_valor_spend"), Label)
                Dim lbl_nr_bonus_extra_spend As Label = CType(e.Row.FindControl("lbl_nr_bonus_extra_spend"), Label)
                Dim lbl_valor_bonus_central As Label = CType(e.Row.FindControl("lbl_valor_bonus_central"), Label)
                Dim lbl_valor_bonus_extra As Label = CType(e.Row.FindControl("lbl_valor_bonus_extra"), Label)
                Dim nr_tempo_adesao As Integer = CType(e.Row.Cells(5).Text.Trim, Integer)
                Dim img_bonus_central As Image = CType(e.Row.FindControl("img_bonus_central"), Image)
                Dim img_bonus_lancamento As Image = CType(e.Row.FindControl("img_bonus_lancamento"), Image)
                Dim dt_bonus_aplicacao As Label = CType(e.Row.FindControl("dt_bonus_aplicacao"), Label)
                Dim st_bonus_central As Label = CType(e.Row.FindControl("st_bonus_central"), Label)
                Dim st_bonus_lancamemto As Label = CType(e.Row.FindControl("st_bonus_lancamento"), Label)
                Dim lbl_id_propriedade As Label = CType(e.Row.FindControl("id_propriedade"), Label)
                Dim lbl_dt_ref_ini_calc As Label = CType(e.Row.FindControl("lbl_dt_ref_ini_calc"), Label)
                Dim dt_referencia_ini As String = CType(e.Row.Cells(7).Text.Trim, String)
                Dim lbl_nr_valor_compras_central_transferencia As Label = CType(e.Row.FindControl("lbl_nr_valor_compras_central_transferencia"), Label)
                Dim lbl_nr_valor_volume_transferencia = CType(e.Row.FindControl("lbl_nr_valor_volume_transferencia"), Label)

                Dim nr_volume_periodo As Decimal
                Dim nr_total_compras_central As Decimal
                Dim nr_valor_bonus As Decimal
                Dim nr_valor_bonus_extra As Decimal
                Dim nr_valor_bonus_transf As Decimal
                Dim nr_volume_transf As Decimal
                Dim nr_compras_central_transf As Decimal

                If lbl_valor_bonus_poupanca.Text.Equals(String.Empty) Then

                    If ViewState("aba_ativa") = 0 Then 'se aba de produtores
                        'Dim poupancaadesao As New PoupancaAdesao
                        'poupancaadesao.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro").ToString)
                        'poupancaadesao.id_propriedade = lbl_id_propriedade.Text

                        ''BUSCA VOLUME DE LEITE DAS CONTAS 0010
                        'Dim ficha As New FichaFinanceira

                        ''ficha.dt_referencia_ficha_start = DateTime.Parse(ViewState.Item("dt_referencia_ini_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'ficha.dt_referencia_ficha_start = DateTime.Parse(lbl_dt_ref_ini_calc.Text.ToString).ToString("dd/MM/yyyy")
                        'ficha.dt_referencia_ficha_end = DateTime.Parse(ViewState.Item("dt_referencia_fim_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'ficha.id_propriedade = lbl_id_propriedade.Text
                        'nr_volume_periodo = ficha.getFichaFinanceiraVolumeLeite
                        'lbl_nr_volume.Text = nr_volume_periodo.ToString
                        'poupancaadesao.nr_valor_volume_leite = nr_volume_periodo

                        ''BUSCA COMPRAS CENTRAL
                        'Dim pedido As New Pedido
                        'pedido.id_propriedade = lbl_id_propriedade.Text
                        ''pedido.dt_inicio = DateTime.Parse(ViewState.Item("dt_referencia_ini_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'pedido.dt_inicio = DateTime.Parse(lbl_dt_ref_ini_calc.Text.ToString).ToString("dd/MM/yyyy")
                        'pedido.dt_fim = DateTime.Parse(ViewState.Item("dt_referencia_fim_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'nr_total_compras_central = pedido.getCentralPedidoTotalCompras
                        'lbl_nr_valor_compras_central.Text = nr_total_compras_central.ToString
                        'poupancaadesao.nr_valor_compras_central = nr_total_compras_central

                        ''SOMATORIO DAS CONTAS DE BONUS POUPANCA
                        'Dim bonus As New Poupanca
                        'bonus.id_propriedade = lbl_id_propriedade.Text
                        'bonus.dt_referencia_ini = DateTime.Parse(lbl_dt_ref_ini_calc.Text.ToString).ToString("dd/MM/yyyy") 'Referencia que se deve iniciar calculo bonus poupanca (muda caso deixe de entregar leite)
                        'bonus.dt_referencia_fim = DateTime.Parse(ViewState.Item("dt_referencia_fim_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'nr_valor_bonus = bonus.getPoupancaValorBonus
                        'lbl_valor_bonus.Text = nr_valor_bonus.ToString
                        'poupancaadesao.nr_valor_bonus_poupanca = nr_valor_bonus

                        ''SOMATORIO DAS CONTAS DE BONUS POUPANCA TRANSFERIDOS
                        'bonus.id_propriedade = lbl_id_propriedade.Text
                        'bonus.dt_referencia_ini = DateTime.Parse(lbl_dt_ref_ini_calc.Text.ToString).ToString("dd/MM/yyyy") 'Referencia que se deve iniciar calculo bonus poupanca (muda caso deixe de entregar leite)
                        'bonus.dt_referencia_fim = DateTime.Parse(ViewState.Item("dt_referencia_fim_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'nr_valor_bonus_transf = bonus.getPoupancaValorBonusTransferencia
                        'poupancaadesao.nr_valor_bonus_transferencia = nr_valor_bonus_transf

                        'nr_valor_bonus = nr_valor_bonus + nr_valor_bonus_transf
                        'lbl_valor_bonus.Text = nr_valor_bonus

                        ''SPEND
                        'If nr_total_compras_central <= 0 Or nr_volume_periodo <= 0 Then
                        '    lbl_nr_valor_spend.Text = String.Empty
                        '    lbl_valor_bonus_central.Text = nr_valor_bonus.ToString
                        '    poupancaadesao.nr_valor_bonus_extra = 0
                        '    poupancaadesao.nr_valor_spend = 0
                        'Else
                        '    'Se o valor do spend do periodo (gastos da central divbidido pelo volume total) for maior ou igual ao parametro especificado, o bonus da poupanca ganha valor extra para ser aplicado na central.
                        '    lbl_nr_valor_spend.Text = CDec(nr_total_compras_central / nr_volume_periodo).ToString
                        '    poupancaadesao.nr_valor_spend = Round(CDec(lbl_nr_valor_spend.Text), 4)
                        '    'Se o spend for menor que o parametro definido, nao acrescenta nada ao bonus
                        '    If poupancaadesao.nr_valor_spend >= CDec(lbl_parametro_spend.Text) Then
                        '        lbl_valor_bonus_central.Text = CDec(nr_valor_bonus + ((nr_valor_bonus * CDec(lbl_nr_bonus_extra_spend.Text)) / 100)).ToString
                        '        poupancaadesao.nr_valor_bonus_extra = ((nr_valor_bonus * CDec(lbl_nr_bonus_extra_spend.Text)) / 100)
                        '    Else
                        '        lbl_valor_bonus_central.Text = nr_valor_bonus.ToString
                        '        poupancaadesao.nr_valor_bonus_extra = 0

                        '    End If

                        'End If
                        'lbl_valor_bonus_extra.Text = poupancaadesao.nr_valor_bonus_extra

                        ''atualiza valores para propriedade
                        'poupancaadesao.updatePoupancaAdesaoValores()


                    End If

                    If ViewState("aba_ativa") = 1 Then 'se aba de grupo relacionamento

                        ''para grupo de relacionamento a referencia utilizada deve ser do periodo de pouspanca completo
                        'Dim poupancaadesao As New PoupancaAdesao
                        'poupancaadesao.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro").ToString)
                        'poupancaadesao.id_propriedade = lbl_id_propriedade.Text

                        ''BUSCA VOLUME DE LEITE DAS CONTAS 0010
                        'Dim ficha As New FichaFinanceira

                        'ficha.dt_referencia_ficha_start = DateTime.Parse(ViewState.Item("dt_referencia_ini_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'ficha.dt_referencia_ficha_end = DateTime.Parse(ViewState.Item("dt_referencia_fim_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'ficha.id_propriedade = lbl_id_propriedade.Text
                        'nr_volume_periodo = ficha.getFichaFinanceiraVolumeLeitebyGrupo
                        'lbl_nr_volume.Text = nr_volume_periodo.ToString
                        'poupancaadesao.nr_valor_volume_leite = nr_volume_periodo

                        ''BUSCA COMPRAS CENTRAL
                        'Dim pedido As New Pedido
                        'pedido.id_propriedade = lbl_id_propriedade.Text
                        ''pedido.dt_inicio = DateTime.Parse(ViewState.Item("dt_referencia_ini_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'pedido.dt_inicio = DateTime.Parse(ViewState.Item("dt_referencia_ini_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'pedido.dt_fim = DateTime.Parse(ViewState.Item("dt_referencia_fim_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'nr_total_compras_central = pedido.getCentralPedidoTotalComprasbyGrupo
                        'lbl_nr_valor_compras_central.Text = nr_total_compras_central.ToString
                        'poupancaadesao.nr_valor_compras_central = nr_total_compras_central

                        ''SOMATORIO DAS CONTAS DE BONUS POUPANCA
                        'Dim bonus As New Poupanca
                        'bonus.id_propriedade = lbl_id_propriedade.Text
                        'bonus.dt_referencia_ini = DateTime.Parse(ViewState.Item("dt_referencia_ini_poupanca_parametro")).ToString("dd/MM/yyyy") 'Referencia que se deve iniciar calculo bonus poupanca (muda caso deixe de entregar leite)
                        'bonus.dt_referencia_fim = DateTime.Parse(ViewState.Item("dt_referencia_fim_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'nr_valor_bonus = bonus.getPoupancaValorBonusbyGrupo
                        'lbl_valor_bonus.Text = nr_valor_bonus.ToString
                        'poupancaadesao.nr_valor_bonus_poupanca = nr_valor_bonus

                        ''SOMATORIO DAS CONTAS DE BONUS POUPANCA TRANSFERIDOS
                        'bonus.id_propriedade = lbl_id_propriedade.Text
                        'bonus.dt_referencia_ini = DateTime.Parse(ViewState.Item("dt_referencia_ini_poupanca_parametro")).ToString("dd/MM/yyyy") 'Referencia que se deve iniciar calculo bonus poupanca (muda caso deixe de entregar leite)
                        'bonus.dt_referencia_fim = DateTime.Parse(ViewState.Item("dt_referencia_fim_poupanca_parametro")).ToString("dd/MM/yyyy")
                        'nr_valor_bonus_transf = bonus.getPoupancaValorBonusTransferenciabyGrupo
                        'poupancaadesao.nr_valor_bonus_transferencia = nr_valor_bonus_transf

                        'nr_valor_bonus = nr_valor_bonus + nr_valor_bonus_transf
                        'lbl_valor_bonus.Text = nr_valor_bonus

                        ''SPEND
                        'If nr_total_compras_central <= 0 Or nr_volume_periodo <= 0 Then
                        '    lbl_nr_valor_spend.Text = String.Empty
                        '    lbl_valor_bonus_central.Text = nr_valor_bonus.ToString
                        '    poupancaadesao.nr_valor_bonus_extra = 0
                        '    poupancaadesao.nr_valor_spend = 0
                        'Else
                        '    'Se o valor do spend do periodo (gastos da central divbidido pelo volume total) for maior ou igual ao parametro especificado, o bonus da poupanca ganha valor extra para ser aplicado na central.
                        '    lbl_nr_valor_spend.Text = CDec(nr_total_compras_central / nr_volume_periodo).ToString
                        '    poupancaadesao.nr_valor_spend = Round(CDec(lbl_nr_valor_spend.Text), 4)
                        '    'Se o spend for menor que o parametro definido, nao acrescenta nada ao bonus
                        '    If poupancaadesao.nr_valor_spend >= CDec(lbl_parametro_spend.Text) Then
                        '        lbl_valor_bonus_central.Text = CDec(nr_valor_bonus + ((nr_valor_bonus * CDec(lbl_nr_bonus_extra_spend.Text)) / 100)).ToString
                        '        poupancaadesao.nr_valor_bonus_extra = ((nr_valor_bonus * CDec(lbl_nr_bonus_extra_spend.Text)) / 100)
                        '    Else
                        '        lbl_valor_bonus_central.Text = nr_valor_bonus.ToString
                        '        poupancaadesao.nr_valor_bonus_extra = 0

                        '    End If

                        'End If
                        'lbl_valor_bonus_extra.Text = poupancaadesao.nr_valor_bonus_extra

                        ''atualiza valores para propriedade
                        'poupancaadesao.updatePoupancaAdesaoValores()

                    End If

                Else
                    'se ja tem bonus nao precisa recalcular todas as contas
                    If lbl_nr_volume.Text.Equals(String.Empty) Then
                        nr_volume_periodo = 0
                    Else
                        nr_volume_periodo = lbl_nr_volume.Text
                    End If
                    'BUSCA volume de transferencia
                    If lbl_nr_valor_volume_transferencia.Text.Equals(String.Empty) Then
                        nr_volume_transf = 0
                    Else
                        nr_volume_transf = lbl_nr_valor_volume_transferencia.Text
                    End If

                    'BUSCA COMPRAS CENTRAL
                    If lbl_nr_valor_compras_central.Text.Equals(String.Empty) Then
                        nr_total_compras_central = 0
                    Else
                        nr_total_compras_central = lbl_nr_valor_compras_central.Text
                    End If

                    'compras central transferencia
                    If lbl_nr_valor_compras_central_transferencia.Text.Equals(String.Empty) Then
                        nr_compras_central_transf = 0
                    Else
                        nr_compras_central_transf = lbl_nr_valor_compras_central_transferencia.Text
                    End If

                    'SOMATORIO DAS CONTAS DE BONUS POUPANCA
                    If lbl_valor_bonus_poupanca.Text.Equals(String.Empty) Then
                        nr_valor_bonus = 0
                    Else
                        nr_valor_bonus = lbl_valor_bonus_poupanca.Text
                    End If

                    lbl_valor_bonus.Text = nr_valor_bonus.ToString

                    'SOMATORIO DAS CONTAS DE BONUS POUPANCA TRANSFERIDOS
                    nr_valor_bonus_transf = lbl_valor_bonus_transf.Text

                    nr_valor_bonus = nr_valor_bonus + nr_valor_bonus_transf
                    lbl_valor_bonus.Text = nr_valor_bonus

                    'Valor Bonus extra
                    nr_valor_bonus_extra = lbl_valor_bonus_extra.Text

                    'SPEND
                    If nr_total_compras_central <= 0 Or nr_volume_periodo <= 0 Then
                        lbl_nr_valor_spend.Text = String.Empty
                        lbl_valor_bonus_central.Text = nr_valor_bonus.ToString

                    Else
                        'Se o valor do spend do periodo (gastos da central divbidido pelo volume total) for maior ou igual ao parametro especificado, o bonus da poupanca ganha valor extra para ser aplicado na central.
                        lbl_nr_valor_spend.Text = CDec(nr_total_compras_central / nr_volume_periodo).ToString

                        'Se o spend for menor que o parametro definido, nao acrescenta nada ao bonus
                        If CDec(lbl_nr_valor_spend.Text) >= CDec(lbl_parametro_spend.Text) Then
                            lbl_valor_bonus_central.Text = CDec(nr_valor_bonus + nr_valor_bonus_extra).ToString
                        Else
                            lbl_valor_bonus_central.Text = nr_valor_bonus.ToString
                        End If

                    End If
                End If

                'referencia inicial de poupanca de acordo com regra de calculo: se ficar 1 mes sem entregar leite
                e.Row.Cells(7).Text = DateTime.Parse(e.Row.Cells(7).Text).ToString("MM/yyyy")

                'Total Volume
                lbl_nr_volume.Text = FormatNumber(lbl_nr_volume.Text, 0)

                'Valor Total Compra Central
                If Not lbl_nr_valor_compras_central.Text.Equals(String.Empty) Then
                    lbl_nr_valor_compras_central.Text = FormatNumber(Round(CDec(lbl_nr_valor_compras_central.Text), 2).ToString)
                End If
                'valor bonus
                lbl_valor_bonus.Text = FormatNumber(Round(CDec(lbl_valor_bonus.Text), 2).ToString)

                'Valor Spend
                If Not lbl_nr_valor_spend.Text.Equals(String.Empty) Then
                    lbl_nr_valor_spend.Text = Round(CDec(lbl_nr_valor_spend.Text), 4).ToString
                End If

                '%
                If Not lbl_nr_bonus_extra_spend.Text.Equals(String.Empty) Then
                    lbl_nr_bonus_extra_spend.Text = Round(CDec(lbl_nr_bonus_extra_spend.Text), 2).ToString
                End If
                'bonus extra
                If Not lbl_valor_bonus_extra.Text.Equals(String.Empty) Then
                    lbl_valor_bonus_extra.Text = Round(CDec(lbl_valor_bonus_extra.Text), 2).ToString
                End If

                'Bonus na central
                If Not lbl_valor_bonus_central.Text.Equals(String.Empty) Then
                    lbl_valor_bonus_central.Text = Round(CDec(lbl_valor_bonus_central.Text), 2).ToString
                End If

                If st_bonus_central.Text.ToString.Equals("S") Then
                    img_bonus_central.ImageUrl = "~/img/ico_chk_true.gif"
                Else
                    img_bonus_central.ImageUrl = "~/img/ico_chk_false.gif"
                End If

                If st_bonus_lancamemto.Text.ToString.Equals("S") Then
                    img_bonus_lancamento.ImageUrl = "~/img/ico_chk_true.gif"
                Else
                    img_bonus_lancamento.ImageUrl = "~/img/ico_chk_false.gif"
                End If

                ''se id_selecao =2 não pode ser selecionado para calculo... (se nao tiver adesão ou já tiver efetuado pagamento mensal
                'If id_selecao.Text.Equals("2") Then
                '    ck_item.Enabled = False
                '    ck_item.ToolTip = "Não participa do cálculo."
                'Else
                '    ck_item.Enabled = True
                '    ck_item.ToolTip = String.Empty
                'End If

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try



    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    'Protected Sub lk_calcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_calcular.Click
    '    Try

    '        saveFilters()
    '        If verificarCheckBox() = True Then
    '            Dim poupancacalculoexecucao As New PoupancaCalculoExecucao()

    '            ' Inicializa Cálculo
    '            poupancacalculoexecucao.id_poupanca_calculo_execucao = ViewState.Item("id_poupanca_calculo_execucao")
    '            poupancacalculoexecucao.dt_referencia = ViewState.Item("dt_referencia").ToString
    '            poupancacalculoexecucao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
    '            poupancacalculoexecucao.id_modificador = Session("id_login")

    '            poupancacalculoexecucao.PrepararProdutoresCalculoMensal()

    '            poupancacalculoexecucao.CalcularProdutorPoupancaMensal()

    '            messageControl.Alert("Cálculo efetuado com sucesso.")

    '            loadData()

    '        Else
    '            messageControl.Alert("Nenhum registro foi selecionado para o cálculo. Por favor selecione alguma propriedade.")
    '        End If




    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try
    'End Sub

    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox
            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                If ch.Enabled = True Then 'se estiver habilitado, pode ser selecionado
                    ch.Checked = ck_header.Checked
                End If
            Next

            '' Seleciona tudo o que o botão Pesquisar trouxe - i
            Dim poupancaaplicacaobonusselecao As New PoupancaAdesao
            poupancaaplicacaobonusselecao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
            poupancaaplicacaobonusselecao.id_cluster = ViewState.Item("id_cluster")
            If Not ViewState.Item("id_propriedade").Equals(String.Empty) Then
                poupancaaplicacaobonusselecao.id_propriedade = ViewState.Item("id_propriedade")
            End If
            If Not ViewState.Item("id_pessoa").Equals(String.Empty) Then
                poupancaaplicacaobonusselecao.id_pessoa = ViewState.Item("id_pessoa")
            End If

            If Not ViewState.Item("id_propriedade_titular").Equals(String.Empty) Then
                poupancaaplicacaobonusselecao.id_propriedade_titular = ViewState.Item("id_propriedade_titular")
            End If
            poupancaaplicacaobonusselecao.st_bonus_poupanca_lancamento = ViewState.Item("st_bonus_poupanca_lancamento")
            poupancaaplicacaobonusselecao.st_bonus_poupanca_central = ViewState.Item("st_bonus_poupanca_central")


            poupancaaplicacaobonusselecao.dt_referencia_fim = ViewState.Item("dt_referencia_fim_poupanca_parametro")

            If ck_header.Checked = True Then
                poupancaaplicacaobonusselecao.st_selecao = "1"
            Else
                poupancaaplicacaobonusselecao.st_selecao = "0"
            End If
            If ViewState.Item("aba_ativa").Equals(0) Then 'se aba ativa é de produtores
                poupancaaplicacaobonusselecao.updatePoupancaAplicacaoBonusSelecaoTodos()
            End If
            If ViewState.Item("aba_ativa").Equals(1) Then 'se aba ativa é de grupo relacionamento
                poupancaaplicacaobonusselecao.updatePoupancaAplicacaoBonusSelecaoTodosGrupo()
            End If

            '  Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        'lbl_nm_pessoa.Text = String.Empty
        'lbl_nm_pessoa.Visible = False
        'hf_id_pessoa.Value = String.Empty

        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty
        'fran chamado 684 i 
        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
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

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
        End If

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



    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        If cbo_estabelecimento.SelectedValue <> "0" Then
            cbo_referencia_poupanca.Enabled = True

            Dim poupancaparametro As New PoupancaParametro

            poupancaparametro.id_estabelecimento = cbo_estabelecimento.SelectedValue
            poupancaparametro.id_situacao_poupanca = 3 'liberado (traz apenas as referencias liberadas

            cbo_referencia_poupanca.DataSource = poupancaparametro.getPoupancaParametro()
            cbo_referencia_poupanca.DataTextField = "ds_periodo_poupanca"
            cbo_referencia_poupanca.DataValueField = "id_poupanca_parametro"
            cbo_referencia_poupanca.DataBind()
            cbo_referencia_poupanca.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_referencia_poupanca.SelectedValue = 0
        Else
            cbo_referencia_poupanca.Items.Clear()
            cbo_referencia_poupanca.Enabled = False
        End If
    End Sub

    Protected Sub ck_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim chk_selec As CheckBox

        chk_selec = CType(sender, CheckBox)

        '' Seleciona o item selecionado
        Dim poupancaaplicacaobonusselecao As New PoupancaAdesao
        poupancaaplicacaobonusselecao.id_poupanca_adesao = Convert.ToInt32(gridResults.DataKeys.Item(row.RowIndex).Value)
        If chk_selec.Checked = True Then
            poupancaaplicacaobonusselecao.st_selecao = "1"
        Else
            poupancaaplicacaobonusselecao.st_selecao = "0"
        End If
        poupancaaplicacaobonusselecao.updatePoupancaAplicacaoBonusSelecao()

    End Sub

    Protected Sub cbo_referencia_poupanca_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_referencia_poupanca.SelectedIndexChanged
        'If Not cbo_referencia_poupanca.SelectedValue.Equals("0") Then
        '    dt_referencia_ini.Text = String.Concat("01/", Left(cbo_referencia_poupanca.Text.Trim, 7)).ToString
        '    dt_referencia_fim.Text = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("01/", Format(Right(cbo_referencia_poupanca.Text.Trim, 7), "MM/yyyy").ToString)))))

        'End If

    End Sub

    Protected Sub lk_bonus_lancamento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_bonus_lancamento.Click
        If Page.IsValid Then
            Try

                Try

                    ' Aplicar bonus Lancamento
                    Dim poupancaadesao As New PoupancaAdesao
                    poupancaadesao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
                    poupancaadesao.st_bonus_poupanca_central = "N"
                    poupancaadesao.st_bonus_poupanca_lancamento = "S"
                    poupancaadesao.id_modificador = Session("id_login")
                    poupancaadesao.updatePoupancaAdesaoAplicacaoBonus()

                    loadData()

                Catch ex As Exception
                    messageControl.Alert(ex.Message)

                End Try



            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub btn_produtores_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aba_produtores.Click
        ViewState("aba_ativa") = 0
        loadabas()

    End Sub
    Sub loadabas()

        Try

            td_aba1.Attributes.Remove("class")
            If ViewState("aba_ativa") = 0 Then
                'td_placa1.Attributes.Add("class", "aba_ativa")
                pnl_panel1.BackImageUrl = "~/img/aba_ativa.gif"
                pnl_panel1.ForeColor = System.Drawing.Color.FromName("#0000F5")
                btn_aba_produtores.ForeColor = System.Drawing.Color.FromName("#0000F5")
                'btn_placa1.Attributes.Add("forecolor", "#0000F5")
            Else
                pnl_panel1.BackImageUrl = "~/img/aba_nao_ativa.gif"
                pnl_panel1.ForeColor = System.Drawing.Color.FromName("#6767CC")
                btn_aba_produtores.ForeColor = System.Drawing.Color.FromName("#6767CC")
            End If
            'td_placa2.Attributes.Remove("class")
            If ViewState("aba_ativa") = 1 Then
                'td_placa2.Attributes.Add("class", "aba_ativa")
                pnl_panel2.BackImageUrl = "~/img/aba_ativa.gif"
                pnl_panel2.ForeColor = System.Drawing.Color.FromName("#0000F5")
                btn_aba_grupo.ForeColor = System.Drawing.Color.FromName("#0000F5")
            Else
                'td_placa2.Attributes.Add("class", "aba_nao_ativa")
                pnl_panel2.BackImageUrl = "~/img/aba_nao_ativa.gif"
                pnl_panel2.ForeColor = System.Drawing.Color.FromName("#6767CC")
                btn_aba_grupo.ForeColor = System.Drawing.Color.FromName("#6767CC")
            End If

            ' Sempre limpar todas as seleções do estabelecimento e referencia quando efetuar novo filtro - i
            Dim poupancaadesao As New PoupancaAdesao
            poupancaadesao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
            poupancaadesao.dt_referencia_fim = ViewState.Item("dt_referencia_fim_poupanca_parametro")
            poupancaadesao.st_selecao = "0"
            poupancaadesao.updatePoupancaAplicacaoBonusSelecaoTodos()
            poupancaadesao.updatePoupancaAplicacaoBonusSelecaoTodosGrupo()

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try


    End Sub

    Protected Sub btn_aba_grupo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aba_grupo.Click
        ViewState("aba_ativa") = 1
        loadabas()

    End Sub

    Protected Sub lk_bonus_central_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_bonus_central.Click
        If Page.IsValid Then
            Try

                ' Aplicar bonus Central
                Dim poupancaadesao As New PoupancaAdesao
                poupancaadesao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
                poupancaadesao.st_bonus_poupanca_central = "S"
                poupancaadesao.st_bonus_poupanca_lancamento = "S"
                poupancaadesao.id_modificador = Session("id_login")
                poupancaadesao.updatePoupancaAdesaoAplicacaoBonus()

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If
    End Sub

    Protected Sub lk_conceder_bonus_extra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_conceder_bonus_extra.Click
        If Page.IsValid Then
            Try

                ' Aplicar bonus Central
                Dim poupancaadesao As New PoupancaAdesao
                poupancaadesao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
                poupancaadesao.id_modificador = Session("id_login")
                poupancaadesao.id_motivo_bonus_concessao = cbo_motivoconcessaobonus.SelectedValue
                poupancaadesao.updatePoupancaAdesaoBonusExtraConcessao()

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If

    End Sub

    Protected Sub cv_concederbonus_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_concederbonus.ServerValidate
        Try
            If Page.IsValid = True Then

                Dim lmsg As String
                Dim li As Integer = 0

                args.IsValid = False ' assume que tem erro

                'se tem linha no grid

                If gridResults.Rows.Count = 0 Then
                    lmsg = "Para prosseguir com a ação, os filtros devem ser informados e a pesquisa deve ser realizada."

                Else
                    lmsg = "Para prosseguir com a ação, algum registro deve ser  selecionado."

                    For li = 0 To gridResults.Rows.Count - 1
                        'se o item do grid foi selecionado
                        If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked = True Then
                            args.IsValid = True
                            Exit For
                        End If
                    Next
                End If

                If args.IsValid = True Then
                    Dim bonusconcessao As New PoupancaAdesao
                    bonusconcessao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")

                    'se não tem linhas selecionadas com bonusextra = zero
                    If bonusconcessao.getPoupancaAdesaoSemBonusExtra.Tables(0).Rows.Count = 0 Then
                        args.IsValid = False
                        lmsg = "Para prosseguir com a ação, algum registro sem  bônus extra deve ser selecionado."
                    End If

                End If

                If Not args.IsValid Then
                    messageControl.Alert(lmsg)
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
