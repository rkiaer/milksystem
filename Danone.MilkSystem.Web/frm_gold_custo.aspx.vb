Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_gold_custo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_gold_custo.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If


    End Sub

    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False



            If Not (Request("id_gold_custo") Is Nothing) Then 'Alteração
                Dim id_gold_custo As String = Request("id_gold_custo")
                ViewState.Item("id_gold_custo") = Convert.ToInt32(id_gold_custo)

                If Not (Request("acao") Is Nothing) Then
                    ViewState.Item("acao") = Request("acao")
                Else
                    ViewState.Item("acao") = ""
                End If

                loadData()
            Else 'Novo

                cbo_estabelecimento.Enabled = True
                txt_dt_referencia_inicial.Enabled = True
                txt_dt_referencia_final.Enabled = True

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try


            Dim id_gold_custo As Int32 = Convert.ToInt32(ViewState.Item("id_gold_custo"))
            Dim goldcusto As New GoldCusto(id_gold_custo)

            cbo_estabelecimento.SelectedValue = goldcusto.id_estabelecimento
            txt_dt_referencia_inicial.Text = goldcusto.dt_referencia_inicial
            txt_dt_referencia_final.Text = goldcusto.dt_referencia_final

            cbo_estabelecimento.Enabled = False
            txt_dt_referencia_inicial.Enabled = False
            txt_dt_referencia_final.Enabled = False

            btn_carregar_faixas.Visible = False

            '=========================================
            '  Carregar Custos Operacionais e Margens
            '=========================================
            Dim goldcustomargem As New GoldCustoMargem
            goldcustomargem.id_gold_custo = id_gold_custo
            Dim dsGoldCustoMargem As DataSet = goldcustomargem.getGoldCustoMargem()
            If (dsGoldCustoMargem.Tables(0).Rows.Count > 0) Then
                GridCustoMargem.Visible = True
                GridCustoMargem.DataSource = Helper.getDataView(dsGoldCustoMargem.Tables(0), ViewState.Item("sortExpression"))
                GridCustoMargem.DataBind()
            Else
                GridCustoMargem.Visible = False
            End If

            '=========================================
            '  Carregar Volume
            '=========================================
            Dim goldcustovolume As New GoldCustoVolume
            goldcustovolume.id_gold_custo = id_gold_custo
            Dim dsGoldCustoVolume As DataSet = goldcustovolume.getGoldCustoVolume()
            If (dsGoldCustoVolume.Tables(0).Rows.Count > 0) Then
                gridVolume.Visible = True
                gridVolume.DataSource = Helper.getDataView(dsGoldCustoVolume.Tables(0), ViewState.Item("sortExpression"))
                gridVolume.DataBind()
            Else
                gridVolume.Visible = False
            End If

            '=========================================
            '  Carregar Crescimento
            '=========================================
            Dim goldcustocrescimento As New GoldCustoCrescimento
            goldcustocrescimento.id_gold_custo = id_gold_custo
            Dim dsGoldCustoCrescimento As DataSet = goldcustocrescimento.getGoldCustoCrescimento()
            If (dsGoldCustoCrescimento.Tables(0).Rows.Count > 0) Then
                GridCrescimento.Visible = True
                GridCrescimento.DataSource = Helper.getDataView(dsGoldCustoCrescimento.Tables(0), ViewState.Item("sortExpression"))
                GridCrescimento.DataBind()
            Else
                GridCrescimento.Visible = False
            End If

            '=========================================
            '  Carregar Eficiencia Dieta
            '=========================================
            Dim goldcustoeficiencia As New GoldCustoEficiencia
            goldcustoeficiencia.id_gold_custo = id_gold_custo
            Dim dsGoldCustoEficiencia As DataSet = goldcustoeficiencia.getGoldCustoEficiencia()
            If (dsGoldCustoEficiencia.Tables(0).Rows.Count > 0) Then
                GridEficiencia.Visible = True
                GridEficiencia.DataSource = Helper.getDataView(dsGoldCustoEficiencia.Tables(0), ViewState.Item("sortExpression"))
                GridEficiencia.DataBind()
            Else
                GridEficiencia.Visible = False
            End If

            If (goldcusto.id_situacao > 0) Then
                cbo_situacao.SelectedValue = goldcusto.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            If goldcusto.id_modificador > 0 Then
                Dim usuario As New Usuario(goldcusto.id_modificador)
                lbl_modificador.Text = usuario.nm_usuario
            End If
            If IsDate(goldcusto.dt_modificacao) Then
                lbl_dt_modificacao.Text = DateTime.Parse(goldcusto.dt_modificacao.ToString).ToString("dd/MM/yyyy HH:mm:ss")
            End If

            If ViewState.Item("acao") = "C" Then  ' Se ação for CONSULTA (se veio das telas dos aprovadores ou do Preço Leite)
                img_voltar.Visible = False
                img_voltarfooter.Visible = False
                img_novo.Visible = False
                img_concluir.Visible = False
                img_concluirfooter.Visible = False
                img_email.Visible = False

                lk_voltar.Visible = False
                lk_voltarFooter.Visible = False
                lk_novo.Visible = False
                lk_concluir.Visible = False
                lk_concluirFooter.Visible = False
                lk_email.Visible = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub updateData()

        If Page.IsValid Then
            Try

                Dim goldcusto As New GoldCusto

                goldcusto.id_estabelecimento = cbo_estabelecimento.SelectedValue
                goldcusto.dt_referencia_inicial = String.Concat("01/" & txt_dt_referencia_inicial.Text)
                goldcusto.dt_referencia_final = String.Concat("01/" & txt_dt_referencia_final.Text)


                '====================================================================
                'Atualiza Gold Custo Margem (todas as margens de custos operacionais)
                '====================================================================
                Dim li As Integer
                Dim lbl_id_gold_custo_margem As Label
                For li = 0 To GridCustoMargem.Rows.Count - 1
                    lbl_id_gold_custo_margem = CType(GridCustoMargem.Rows(li).FindControl("lbl_id_gold_custo_margem"), Label)
                    goldcusto.id_gold_faixa_custo.Add(GridCustoMargem.DataKeys(li).Value.ToString)
                    goldcusto.id_gold_custo_margem.Add(lbl_id_gold_custo_margem.Text)   ' Array utilizado para o Update
                    If CType(GridCustoMargem.Rows(li).FindControl("txt_nr_margem"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text <> "" Then
                        goldcusto.nr_margem.Add(CType(GridCustoMargem.Rows(li).FindControl("txt_nr_margem"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text)
                    Else
                        goldcusto.nr_margem.Add(0)
                    End If
                Next

                '====================================================================
                'Atualiza Gold Custo Volume
                '====================================================================
                Dim lbl_id_gold_custo_volume As Label
                For li = 0 To gridVolume.Rows.Count - 1
                    lbl_id_gold_custo_volume = CType(gridVolume.Rows(li).FindControl("lbl_id_gold_custo_volume"), Label)
                    goldcusto.id_gold_faixa_volume.Add(gridVolume.DataKeys(li).Value.ToString)
                    goldcusto.id_gold_custo_volume.Add(lbl_id_gold_custo_volume.Text)   ' Array utilizado para o Update
                    If CType(gridVolume.Rows(li).FindControl("txt_nr_adicional_volume"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text <> "" Then
                        goldcusto.nr_adicional_volume.Add(CType(gridVolume.Rows(li).FindControl("txt_nr_adicional_volume"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text)
                    Else
                        goldcusto.nr_adicional_volume.Add(0)
                    End If
                Next

                '====================================================================
                'Atualiza Gold Custo Crescimento
                '====================================================================
                Dim lbl_id_gold_custo_crescimento As Label
                For li = 0 To GridCrescimento.Rows.Count - 1
                    lbl_id_gold_custo_crescimento = CType(GridCrescimento.Rows(li).FindControl("lbl_id_gold_custo_crescimento"), Label)
                    goldcusto.id_gold_faixa_crescimento.Add(GridCrescimento.DataKeys(li).Value.ToString)
                    goldcusto.id_gold_custo_crescimento.Add(lbl_id_gold_custo_crescimento.Text)   ' Array utilizado para o Update
                    If CType(GridCrescimento.Rows(li).FindControl("txt_nr_adicional_crescimento"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text <> "" Then
                        goldcusto.nr_adicional_crescimento.Add(CType(GridCrescimento.Rows(li).FindControl("txt_nr_adicional_crescimento"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text)
                    Else
                        goldcusto.nr_adicional_crescimento.Add(0)
                    End If
                Next

                '====================================================================
                'Atualiza Gold Custo Eficiencia
                '====================================================================
                Dim lbl_id_gold_custo_eficiencia As Label
                For li = 0 To GridEficiencia.Rows.Count - 1
                    lbl_id_gold_custo_eficiencia = CType(GridEficiencia.Rows(li).FindControl("lbl_id_gold_custo_eficiencia"), Label)
                    goldcusto.id_gold_faixa_eficiencia.Add(GridEficiencia.DataKeys(li).Value.ToString)
                    goldcusto.id_gold_custo_eficiencia.Add(lbl_id_gold_custo_eficiencia.Text)   ' Array utilizado para o Update
                    If CType(GridEficiencia.Rows(li).FindControl("txt_nr_adicional_eficiencia"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text <> "" Then
                        goldcusto.nr_adicional_eficiencia.Add(CType(GridEficiencia.Rows(li).FindControl("txt_nr_adicional_eficiencia"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text)
                    Else
                        goldcusto.nr_adicional_eficiencia.Add(0)
                    End If
                Next

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    goldcusto.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                goldcusto.id_modificador = Session("id_login")

                If Page.IsValid Then
                    If Not (ViewState.Item("id_gold_custo") Is Nothing) Then

                        goldcusto.id_gold_custo = Convert.ToInt32(ViewState("id_gold_custo").ToString)
                        goldcusto.updateGoldCusto()
                        messageControl.Alert("Registro alterado com sucesso.")

                    Else

                        ViewState.Item("id_gold_custo") = goldcusto.insertGoldCusto()
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
        Response.Redirect("lst_gold_custo.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_gold_custo.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    'Protected Sub carregaAdicionalVolume()
    '    Try


    '        Dim precoadicionalvolume As New PrecoAdicionalVolume

    '        precoadicionalvolume.id_preco_objetivo = ViewState.Item("id_preco_objetivo")
    '        'precoadicionalvolume.nr_mes = cbo_mes.SelectedValue

    '        Dim dsAdicionalVolume As DataSet = precoadicionalvolume.getAdicionalVolumeByFilters()

    '        If (dsAdicionalVolume.Tables(0).Rows.Count > 0) Then
    '            gridVolume.Visible = True
    '            gridVolume.DataSource = Helper.getDataView(dsAdicionalVolume.Tables(0), ViewState.Item("sortExpression"))
    '            gridVolume.DataBind()

    '            cbo_grupo_faixas.Enabled = False
    '            lbl_novo.Visible = False
    '        Else
    '            gridVolume.Visible = False
    '            cbo_grupo_faixas.Enabled = True
    '            cbo_grupo_faixas.SelectedValue = 0      ' Selecione
    '            lbl_novo.Visible = True
    '        End If

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub cbo_grupo_faixas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_grupo_faixas.SelectedIndexChanged
    '    carregaAdicionalVolumeNovo()

    'End Sub
    'Protected Sub carregaAdicionalVolumeNovo()
    '    Try

    '        If cbo_grupo_faixas.SelectedValue > 0 Then
    '            lbl_novo.Visible = False

    '            Dim faixavolume As New FaixaVolume

    '            faixavolume.nr_grupo_faixas = cbo_grupo_faixas.SelectedValue

    '            Dim dsFaixaVolume As DataSet = faixavolume.getFaixaVolumeByFilters()


    '            If (dsFaixaVolume.Tables(0).Rows.Count > 0) Then
    '                gridVolume.Visible = True
    '                gridVolume.DataSource = Helper.getDataView(dsFaixaVolume.Tables(0), ViewState.Item("sortExpression"))
    '                gridVolume.DataBind()
    '            End If
    '        Else
    '            gridVolume.Visible = False
    '            lbl_novo.Visible = True
    '        End If

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_gold_custo.aspx")

    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged


    End Sub
    Protected Sub carregaFaixaCusto(ByVal pid_estabelecimento As Int32, ByVal pdt_referencia_inicial As String, ByVal pdt_referencia_final As String)

        Dim goldfaixacusto As New GoldFaixaCusto

        goldfaixacusto.id_estabelecimento = pid_estabelecimento
        goldfaixacusto.dt_referencia_inicial = pdt_referencia_inicial  ' ver como tratar as datas de validade para as faixas
        goldfaixacusto.dt_referencia_final = pdt_referencia_final    ' ver como tratar as datas de validade para as faixas
        goldfaixacusto.id_situacao = 1

        Dim dsGoldFaixaCusto As DataSet = goldfaixacusto.getGoldFaixaCustoByFilters()

        If (dsGoldFaixaCusto.Tables(0).Rows.Count > 0) Then
            GridCustoMargem.Visible = True
            GridCustoMargem.DataSource = Helper.getDataView(dsGoldFaixaCusto.Tables(0), ViewState.Item("sortExpression"))
            GridCustoMargem.DataBind()
        Else
            GridCustoMargem.Visible = False
        End If

    End Sub
    Protected Sub carregaFaixaVolume(ByVal pid_estabelecimento As Int32, ByVal pdt_referencia_inicial As String, ByVal pdt_referencia_final As String)

        Dim goldfaixavolume As New GoldFaixaVolume

        goldfaixavolume.id_estabelecimento = pid_estabelecimento
        goldfaixavolume.dt_referencia_inicial = pdt_referencia_inicial  ' ver como tratar as datas de validade para as faixas
        goldfaixavolume.dt_referencia_final = pdt_referencia_final    ' ver como tratar as datas de validade para as faixas

        Dim dsGoldFaixaVolume As DataSet = goldfaixavolume.getGoldFaixaVolumeByFilters()

        If (dsGoldFaixaVolume.Tables(0).Rows.Count > 0) Then
            gridVolume.Visible = True
            gridVolume.DataSource = Helper.getDataView(dsGoldFaixaVolume.Tables(0), ViewState.Item("sortExpression"))
            gridVolume.DataBind()
        Else
            gridVolume.Visible = False
        End If

    End Sub
    Protected Sub carregaFaixaCrescimento(ByVal pid_estabelecimento As Int32, ByVal pdt_referencia_inicial As String, ByVal pdt_referencia_final As String)

        Dim goldfaixacrescimento As New GoldFaixaCrescimento

        goldfaixacrescimento.id_estabelecimento = pid_estabelecimento
        goldfaixacrescimento.dt_referencia_inicial = pdt_referencia_inicial  ' ver como tratar as datas de validade para as faixas
        goldfaixacrescimento.dt_referencia_final = pdt_referencia_final    ' ver como tratar as datas de validade para as faixas

        Dim dsGoldFaixaCrescimento As DataSet = goldfaixacrescimento.getGoldFaixaCrescimentoByFilters()

        If (dsGoldFaixaCrescimento.Tables(0).Rows.Count > 0) Then
            GridCrescimento.Visible = True
            GridCrescimento.DataSource = Helper.getDataView(dsGoldFaixaCrescimento.Tables(0), ViewState.Item("sortExpression"))
            GridCrescimento.DataBind()
        Else
            GridCrescimento.Visible = False
        End If

    End Sub
    Protected Sub carregaFaixaEficienciaDieta(ByVal pid_estabelecimento As Int32, ByVal pdt_referencia_inicial As String, ByVal pdt_referencia_final As String)

        Dim goldfaixaeficiencia As New GoldFaixaEficiencia

        goldfaixaeficiencia.id_estabelecimento = pid_estabelecimento
        goldfaixaeficiencia.dt_referencia_inicial = pdt_referencia_inicial  ' ver como tratar as datas de validade para as faixas
        goldfaixaeficiencia.dt_referencia_final = pdt_referencia_final    ' ver como tratar as datas de validade para as faixas

        Dim dsGoldFaixaEficiencia As DataSet = goldfaixaeficiencia.getGoldFaixaEficienciaByFilters()

        If (dsGoldFaixaEficiencia.Tables(0).Rows.Count > 0) Then
            GridEficiencia.Visible = True
            GridEficiencia.DataSource = Helper.getDataView(dsGoldFaixaEficiencia.Tables(0), ViewState.Item("sortExpression"))
            GridEficiencia.DataBind()
        Else
            GridEficiencia.Visible = False
        End If

    End Sub

    Protected Sub btn_carregar_faixas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_carregar_faixas.Click

        If Page.IsValid = True Then
            If btn_carregar_faixas.Text = "Buscar Dados" Then

                carregaFaixaCusto(cbo_estabelecimento.SelectedValue, "01/" & txt_dt_referencia_inicial.Text, "01/" & txt_dt_referencia_final.Text)
                carregaFaixaVolume(cbo_estabelecimento.SelectedValue, "01/" & txt_dt_referencia_inicial.Text, "01/" & txt_dt_referencia_final.Text)
                carregaFaixaCrescimento(cbo_estabelecimento.SelectedValue, "01/" & txt_dt_referencia_inicial.Text, "01/" & txt_dt_referencia_final.Text)
                carregaFaixaEficienciaDieta(cbo_estabelecimento.SelectedValue, "01/" & txt_dt_referencia_inicial.Text, "01/" & txt_dt_referencia_final.Text)

                btn_carregar_faixas.Text = "Limpar Dados"
                cbo_estabelecimento.Enabled = False
                txt_dt_referencia_inicial.Enabled = False
                txt_dt_referencia_final.Enabled = False

            Else

                carregaFaixaCusto(0, "", "")  ' Limpa o grid
                carregaFaixaVolume(0, "", "") ' Limpa o grid
                carregaFaixaCrescimento(0, "", "") ' Limpa o grid
                carregaFaixaEficienciaDieta(0, "", "") ' Limpa o grid

                btn_carregar_faixas.Text = "Buscar Dados"
                cbo_estabelecimento.Enabled = True
                txt_dt_referencia_inicial.Enabled = True
                txt_dt_referencia_final.Enabled = True

            End If
        End If

    End Sub

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        Try
            If Page.IsValid = True Then
                Try

                    Dim notificacao As New Notificacao
                    Dim lAssunto As String = "Aprovação 1.o Nível de Custos GOLD "
                    Dim lCorpo As String = "Existem margens/bonificações de custo efetivo, volume, crescimento e eficiência da dieta para Custos GOLD pendentes para aprovação 1.o Nível."

                    ' 10 - Custos Gold 1o. Nível
                    If notificacao.enviaMensagemEmail(10, lAssunto, lCorpo, MailPriority.High, , , Convert.ToInt32(ViewState.Item("id_estabelecimento"))) = True Then
                        messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível foi enviada aos destinatários com sucesso!")
                    Else
                        messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")
                    End If

                Catch ex As Exception
                    messageControl.Alert(ex.Message)
                End Try


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_data_validade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_data_validade.ServerValidate
        Try

            args.IsValid = True

            'If (ViewState.Item("id_gold_custo") Is Nothing) Then  ' Se está INCLUINDO (testar sempre pq caso estiver ativando um registro invalido)
            ' Verifica se já existe Custo  Ativo para o mesmo Estabelecimento e período
            ' Verifica se o período informado se intercala com algum período cadastrado (ex: 01/2014 a 03/2014  e  02/2014 a 04/2014)
            Dim goldcusto As New GoldCusto

            goldcusto.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            goldcusto.dt_referencia_inicial = String.Concat("01/" & txt_dt_referencia_inicial.Text)
            goldcusto.dt_referencia_final = String.Concat("01/" & txt_dt_referencia_final.Text)
            goldcusto.id_situacao = 1 ' Ativo
            If Not (ViewState.Item("id_gold_custo") Is Nothing) Then  ' Se está fazendo o Update
                goldcusto.id_gold_custo = Convert.ToInt32(ViewState.Item("id_gold_custo"))  ' 31/10/2014 - Passa o id_gold_custo para não consistir o próprio id que está sendo salvo no update
            End If
            Dim dsGoldCusto As DataSet = goldcusto.getGoldCustoByPeriodo()

            If (dsGoldCusto.Tables(0).Rows.Count > 0) Then
                args.IsValid = False
                messageControl.Alert("Já existem dados cadastrados para o Estabelecimento no mesmo Período de Validade.")
                Exit Sub
            End If

            'End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
