Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_gold_custo_produtor
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_preco_objetivo.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With bt_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
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


            If Not (Request("id_gold_custo_produtor") Is Nothing) Then 'Alteração

                Dim id_gold_custo_produtor As String = Request("id_gold_custo_produtor")
                ViewState.Item("id_gold_custo_produtor") = Convert.ToInt32(id_gold_custo_produtor)

                If Not (Request("acao") Is Nothing) Then
                    ViewState.Item("acao") = Request("acao")
                Else
                    ViewState.Item("acao") = ""
                End If

                loadData()

            Else 'Novo

                carregaCustoProdutorOperacionalItem()

                txt_cd_propriedade.Enabled = True
                txt_dt_referencia_inicial.Enabled = True
                txt_dt_referencia_final.Enabled = True

                lk_dieta.Visible = False
                lk_email.Enabled = False

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try

            lk_dieta.Visible = True

            Dim id_gold_custo_produtor As Int32 = Convert.ToInt32(ViewState.Item("id_gold_custo_produtor"))
            Dim goldcustoprodutor As New GoldCustoProdutor(id_gold_custo_produtor)

            If goldcustoprodutor.st_aprovado = "2" Then  ' Se já foi aprovado 2.o Nível, não pode mais alterar
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
            End If

            lbl_produtor.Text = goldcustoprodutor.ds_produtor
            lbl_estabelecimento.Visible = True
            lbl_estabelecimento.Text = goldcustoprodutor.ds_estabelecimento
            txt_cd_propriedade.Text = goldcustoprodutor.id_propriedade.ToString()
            lbl_nm_propriedade.Visible = True
            lbl_nm_propriedade.Text = goldcustoprodutor.nm_propriedade
            txt_cd_propriedade.Enabled = False
            bt_lupa_propriedade.Visible = False

            txt_dt_referencia_inicial.Text = DateTime.Parse(goldcustoprodutor.dt_referencia_inicial.ToString).ToString("MM/yyyy")
            txt_dt_referencia_final.Text = DateTime.Parse(goldcustoprodutor.dt_referencia_final.ToString).ToString("MM/yyyy")

            txt_cd_propriedade.Enabled = False
            txt_dt_referencia_inicial.Enabled = False
            txt_dt_referencia_final.Enabled = False

            Me.txt_nr_volume_planejado.Text = goldcustoprodutor.nr_volume_planejado
            Me.txt_nr_taxa_crescimento_ano.Text = goldcustoprodutor.nr_taxa_crescimento_ano
            Me.txt_nr_taxa_vacas_lactacao.Text = goldcustoprodutor.nr_taxa_vacas_lactacao


            Dim goldcustooperacional As New GoldCustoProdutorOperacional

            goldcustooperacional.id_gold_custo_produtor = Convert.ToInt32(ViewState.Item("id_gold_custo_produtor"))
            goldcustooperacional.id_situacao = 1
            Dim dsGoldCustoProdutorOperacional As DataSet = goldcustooperacional.getGoldCustoProdutorOperacionalByFilters()

            If (dsGoldCustoProdutorOperacional.Tables(0).Rows.Count > 0) Then
                GridCustoOperacional.Visible = True
                GridCustoOperacional.DataSource = Helper.getDataView(dsGoldCustoProdutorOperacional.Tables(0), ViewState.Item("sortExpression"))
                GridCustoOperacional.DataBind()
            Else
                GridCustoOperacional.Visible = False
            End If

            If (goldcustoprodutor.id_situacao > 0) Then
                cbo_situacao.SelectedValue = goldcustoprodutor.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            If goldcustoprodutor.id_modificador > 0 Then
                Dim usuario As New Usuario(goldcustoprodutor.id_modificador)
                lbl_modificador.Text = usuario.nm_usuario
            End If
            If IsDate(goldcustoprodutor.dt_modificacao) Then
                lbl_dt_modificacao.Text = DateTime.Parse(goldcustoprodutor.dt_modificacao.ToString).ToString("dd/MM/yyyy HH:mm:ss") 
            End If

            If ViewState.Item("acao") = "C" Then  ' Se ação for CONSULTA (se veio das telas dos aprovadores)
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
                lk_dieta.Visible = False
                lk_email.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub updateData()

        If Page.IsValid Then
            Try


                Dim goldcustoprodutor As New GoldCustoProdutor

                goldcustoprodutor.id_propriedade = Convert.ToInt32(txt_cd_propriedade.Text)
                goldcustoprodutor.dt_referencia_inicial = String.Concat("01/" & txt_dt_referencia_inicial.Text)
                goldcustoprodutor.dt_referencia_final = String.Concat("01/" & txt_dt_referencia_final.Text)
                goldcustoprodutor.nr_volume_planejado = Me.txt_nr_volume_planejado.Text
                goldcustoprodutor.nr_taxa_crescimento_ano = Me.txt_nr_taxa_crescimento_ano.Text
                goldcustoprodutor.nr_taxa_vacas_lactacao = Me.txt_nr_taxa_vacas_lactacao.Text


                'Carrega Custos Operacionais
                Dim li As Integer
                Dim lbl_id_gold_custo_produtor_operacional_item As Label

                For li = 0 To GridCustoOperacional.Rows.Count - 1

                    lbl_id_gold_custo_produtor_operacional_item = CType(GridCustoOperacional.Rows(li).FindControl("lbl_id_gold_custo_produtor_operacional_item"), Label)

                    If lbl_id_gold_custo_produtor_operacional_item.Text <> "0" Then   ' Se não for a linha de Custos Totais

                        goldcustoprodutor.id_gold_custo_produtor_operacional.Add(GridCustoOperacional.DataKeys(li).Value.ToString)  ' Array só utilizado no Update
                        goldcustoprodutor.id_gold_custo_produtor_operacional_item.Add(lbl_id_gold_custo_produtor_operacional_item.Text)

                        If CType(GridCustoOperacional.Rows(li).FindControl("txt_nr_custo_operacional"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text <> "" Then
                            goldcustoprodutor.nr_custo_operacional.Add(CType(GridCustoOperacional.Rows(li).FindControl("txt_nr_custo_operacional"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox).Text)
                        Else
                            goldcustoprodutor.nr_custo_operacional.Add(0)
                        End If
                    End If

                Next

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    goldcustoprodutor.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                goldcustoprodutor.id_modificador = Session("id_login")

                If Page.IsValid Then
                    If Not (ViewState.Item("id_gold_custo_produtor") Is Nothing) Then

                        goldcustoprodutor.id_gold_custo_produtor = Convert.ToInt32(ViewState("id_gold_custo_produtor").ToString)
                        goldcustoprodutor.updateGoldCustoProdutor()
                        messageControl.Alert("Registro alterado com sucesso.")

                    Else

                        ViewState.Item("id_gold_custo_produtor") = goldcustoprodutor.insertGoldCustoProdutor()
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
        Response.Redirect("lst_gold_custo_produtor.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_gold_custo_produtor.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_gold_custo_produtor.aspx")

    End Sub

    Protected Sub carregaCustoProdutorOperacionalItem()

        Dim goldcustooperacionalitem As New GoldCustoProdutorOperacionalItem

        goldcustooperacionalitem.id_situacao = 1
        Dim dsGoldCustoProdutorOperacionalItem As DataSet = goldcustooperacionalitem.getGoldCustoProdutorOperacionalItemByFilters()

        If (dsGoldCustoProdutorOperacionalItem.Tables(0).Rows.Count > 0) Then
            GridCustoOperacional.Visible = True
            GridCustoOperacional.DataSource = Helper.getDataView(dsGoldCustoProdutorOperacionalItem.Tables(0), ViewState.Item("sortExpression"))
            GridCustoOperacional.DataBind()
        Else
            GridCustoOperacional.Visible = False
        End If

    End Sub


    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        Try
            If Page.IsValid = True Then
                Try

                    ' Verifica se já informou a Dieta
                    Dim goldcustoprodutordieta As New GoldCustoProdutorDieta
                    goldcustoprodutordieta.id_gold_custo_produtor = Convert.ToInt32(ViewState.Item("id_gold_custo_produtor"))
                    Dim dsGoldCustoProdutorDieta As DataSet = goldcustoprodutordieta.getGoldCustoProdutorDietaByFilters()
                    If (dsGoldCustoProdutorDieta.Tables(0).Rows.Count <= 0) Then  ' Se não tem dieta cadastrada
                        messageControl.Alert("Não existe dieta cadastrada para o Produtor no Período. Cadastre a Dieta antes de Notificar os aprovadores!")
                        Exit Sub
                    End If

                    Dim notificacao As New Notificacao
                    Dim lAssunto As String = "Aprovação 1.o Nível de Custos Operacionais e Dieta para Produtor GOLD "
                    Dim lCorpo As String = "Existem custos operacionais e dieta para Produtores GOLD pendentes para aprovação 1.o Nível para o Período de " & txt_dt_referencia_inicial.Text & " à " & txt_dt_referencia_final.Text

                    ' 10 - Custos Gold 1o. Nível
                    If notificacao.enviaMensagemEmail(12, lAssunto, lCorpo, MailPriority.High, , , Convert.ToInt32(ViewState.Item("id_estabelecimento"))) = True Then
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

    Protected Sub bt_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_propriedade.Click
        If Not (Me.hf_id_propriedade.Value.Trim.Equals(String.Empty)) Then
            txt_cd_propriedade.Text = hf_id_propriedade.Value.ToString
            carregarCamposPropriedade()
        End If

    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
        hf_id_propriedade.Value = String.Empty
        lbl_estabelecimento.Text = String.Empty
        lbl_estabelecimento.Visible = False
        lbl_produtor.Text = String.Empty
        lbl_produtor.Visible = False
        lbl_titulo_estabelecimento.Visible = False
        lbl_titulo_produtor.Visible = False
        lbl_nm_propriedade.Text = String.Empty
        lbl_nm_propriedade.Visible = False

    End Sub

    Private Sub carregarCamposPropriedade()

        Try

            If Not (customPage.getFilterValue("lupa_propriedade", "pessoa").Equals(String.Empty)) Then
                Me.lbl_titulo_produtor.Visible = True
                Me.lbl_produtor.Visible = True
                Me.lbl_produtor.Text = customPage.getFilterValue("lupa_propriedade", "pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_propriedade", "estabelecimento").Equals(String.Empty)) Then
                Me.lbl_titulo_estabelecimento.Visible = True
                Me.lbl_estabelecimento.Visible = True
                Me.lbl_estabelecimento.Text = customPage.getFilterValue("lupa_propriedade", "estabelecimento").ToString
            End If
            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.lbl_nm_propriedade.Visible = True
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If

            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_dieta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_dieta.Click
        Response.Redirect("frm_gold_custo_produtor_dieta.aspx?id_gold_custo_produtor=" & ViewState("id_gold_custo_produtor").ToString)

    End Sub

    Protected Sub cmv_propriedade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_propriedade.ServerValidate
        Try
            Dim propriedade As New Propriedade()

            propriedade.id_propriedade = Trim(txt_cd_propriedade.Text)

            args.IsValid = propriedade.validarPropriedade()

            If Not args.IsValid Then
                messageControl.Alert("Propriedade não cadastrada.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_data_validade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_data_validade.ServerValidate
        Try

            args.IsValid = True

            'If (ViewState.Item("id_gold_custo_produtor") Is Nothing) Then  ' Se está INCLUINDO (testar sempre pq caso estiver ativando um registro invalido)
            ' Verifica se já existe Custo Produtor Ativo para o mesmo Produtor e período
            ' Verifica se o período informado se intercala com algum período cadastrado (ex: 01/2014 a 03/2014  e  02/2014 a 04/2014)
            Dim goldcustoprodutor As New GoldCustoProdutor

            goldcustoprodutor.id_propriedade = Convert.ToInt32(txt_cd_propriedade.Text)
            goldcustoprodutor.dt_referencia_inicial = String.Concat("01/" & txt_dt_referencia_inicial.Text)
            goldcustoprodutor.dt_referencia_final = String.Concat("01/" & txt_dt_referencia_final.Text)
            goldcustoprodutor.id_situacao = 1 ' Ativo
            If Not (ViewState.Item("id_gold_custo_produtor") Is Nothing) Then  ' Se está fazendo o Update
                goldcustoprodutor.id_gold_custo_produtor = Convert.ToInt32(ViewState.Item("id_gold_custo_produtor"))  ' 31/10/2014 - Passa o id_gold_custo_produtor para não consistir o próprio id que está sendo salvo no update
            End If
            Dim dsGoldCustoProdutor As DataSet = goldcustoprodutor.getGoldCustoProdutorByPeriodo()

            If (dsGoldCustoProdutor.Tables(0).Rows.Count > 0) Then
                args.IsValid = False
                messageControl.Alert("Já existem dados cadastrados para o Produtor no mesmo Período de Validade.")
            End If
            'End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class
