Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_coleta_amostra_manual
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_coleta_amostra_manual.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim situacoes As New SituacaoColetaAmostraManual

            cbo_situacao.DataSource = situacoes.getSituacoesColetaAmostraManualByFilters()
            cbo_situacao.DataTextField = "nm_situacao_coleta_amostra_manual"
            cbo_situacao.DataValueField = "id_situacao_coleta_amostra_manual"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            Dim analiseesalqtipocoleta As New AnaliseEsalqTipoColeta
            cbo_tipo_coleta.DataSource = analiseesalqtipocoleta.getAnaliseEsalqTipoColetaByFilters()
            cbo_tipo_coleta.DataTextField = "nm_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataValueField = "id_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataBind()
            cbo_tipo_coleta.Items.Insert(0, New ListItem("[Selecione]", "0"))


            If Not (Request("id_coleta_amostra_manual") Is Nothing) Then
                ViewState.Item("id_coleta_amostra_manual") = Request("id_coleta_amostra_manual")
                loadData()
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim coletamanual As New ColetaAmostraManual(ViewState.Item("id_coleta_amostra_manual"))

            'Dados
            cbo_estabelecimento.SelectedValue = coletamanual.id_estabelecimento
            cbo_estabelecimento.Enabled = False

            txt_referencia.Text = DateTime.Parse(coletamanual.dt_referencia).ToString("MM/yyyy")
            txt_referencia.Enabled = False

            txt_id_propriedade.Text = coletamanual.id_propriedade
            txt_id_propriedade.Enabled = False
            ViewState.Item("id_propriedade") = coletamanual.id_propriedade.ToString
            hf_id_propriedade.Value = ViewState.Item("id_propriedade").ToString
            loadUnidProducaobyPropriedade()
            cbo_unid_producao.SelectedValue = coletamanual.id_unid_producao
            cbo_unid_producao.Enabled = False
            btn_lupa_propriedade.Visible = False
            lbl_nm_propriedade.Text = coletamanual.nm_propriedade
            If coletamanual.id_propriedade_matriz > 0 Then
                lbl_proriedade_matriz.Text = coletamanual.id_propriedade_matriz.ToString
            Else
                lbl_proriedade_matriz.Text = String.Empty
            End If

            loadUltimaColetabyPropriedade(coletamanual.id_propriedade)

            cbo_tipo_coleta.SelectedValue = coletamanual.id_tipo_coleta_analise_esalq
            txt_dt_ini.Text = DateTime.Parse(coletamanual.dt_ini_amostra).ToString("dd")
            txt_dt_fim.Text = DateTime.Parse(coletamanual.dt_fim_amostra).ToString("dd")

            cbo_situacao.SelectedValue = coletamanual.id_situacao_coleta_amostra_manual

            'controle sistema
            lbl_modificador.Text = coletamanual.ds_login.ToString
            lbl_dt_modificacao.Text = coletamanual.dt_modificacao.ToString()
            'cbo_situacao.SelectedValue = coletamanual.id_situacao.ToString()

            'CONTROELE VISUAL

            'se data de hoje for maior ou igual referencia nao atualiza, nao pode salvar
            If CDate(DateTime.Now.ToString("dd/MM/yyyy")) >= CDate(DateAdd(DateInterval.Month, 1, CDate(coletamanual.dt_referencia))) Then
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
            Else 'se a referencia da tela for menor que hj
                If cbo_situacao.SelectedValue = 1 Then 'se situacao coleta manual é pendente
                    If Not ViewState.Item("dataultimacoleta").Equals(String.Empty) Then
                        If CDate(coletamanual.dt_fim_amostra) <= CDate(ViewState.Item("dataultimacoleta")) Then
                            lk_concluir.Enabled = False
                            lk_concluirFooter.Enabled = False
                        Else
                            'verifica se o inicio da coleta é maior que a ultima coleta
                            If CDate(coletamanual.dt_ini_amostra) <= CDate(ViewState.Item("dataultimacoleta")) Then
                                txt_dt_ini.Enabled = False
                                cbo_tipo_coleta.Enabled = False
                            End If
                        End If
                    End If
                Else 'se siyuacao coleta diferente de pendente nao deixa atualizar mais
                    lk_concluir.Enabled = False
                    lk_concluirFooter.Enabled = False
                End If
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid Then

            Try

                Dim coletamanual As New ColetaAmostraManual()
                Dim lmsg As String = ""

                'Dados
                coletamanual.id_estabelecimento = cbo_estabelecimento.SelectedValue
                coletamanual.dt_referencia = DateTime.Parse("01/" & txt_referencia.Text).ToString("dd/MM/yyyy")
                coletamanual.id_propriedade = txt_id_propriedade.Text
                coletamanual.id_unid_producao = cbo_unid_producao.SelectedValue
                If lbl_proriedade_matriz.Text.Equals(String.Empty) Then
                    coletamanual.id_propriedade_matriz = 0
                Else
                    coletamanual.id_propriedade_matriz = lbl_proriedade_matriz.Text
                End If
                coletamanual.id_tipo_coleta_analise_esalq = cbo_tipo_coleta.SelectedValue
                coletamanual.dt_ini_amostra = DateTime.Parse(Right("00" & txt_dt_ini.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
                coletamanual.dt_fim_amostra = DateTime.Parse(Right("00" & txt_dt_fim.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
                coletamanual.id_modificador = Session("id_login")
                coletamanual.id_situacao_coleta_amostra_manual = cbo_situacao.SelectedValue

                'se nao tem 1a coleta
                If (ViewState.Item("id_coleta_amostra_manual") Is Nothing) Then
                    ViewState.Item("id_coleta_amostra_manual") = coletamanual.insertColetaAmostraManual()
                    lmsg = "Registro inserido com sucesso."
                Else
                    coletamanual.id_coleta_amostra_manual = Convert.ToInt32(ViewState.Item("id_coleta_amostra_manual"))
                    coletamanual.updateColetaAmostraManual()
                    lmsg = "Registro alterado com sucesso."
                End If


                messageControl.Alert(lmsg)

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_coleta_amostra_manual.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_coleta_amostra_manual.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_coleta_amostra_manual.aspx")

    End Sub


    Protected Sub cv_salvar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_salvar.ServerValidate
        Try
            Dim lmsg As String

            Dim coletamanual As New ColetaAmostraManual
            coletamanual.id_estabelecimento = cbo_estabelecimento.SelectedValue
            coletamanual.dt_referencia = DateTime.Parse(String.Concat("01/", txt_referencia.Text)).ToString("dd/MM/yyyy")
            coletamanual.dt_ini_amostra = DateTime.Parse(Right("00" & txt_dt_ini.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
            coletamanual.dt_fim_amostra = DateTime.Parse(Right("00" & txt_dt_fim.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
            coletamanual.id_propriedade = txt_id_propriedade.Text
            coletamanual.id_unid_producao = cbo_unid_producao.SelectedValue

            Dim coletaperiodo As New ColetaAmostraPeriodo
            coletaperiodo.id_estabelecimento = cbo_estabelecimento.SelectedValue
            coletaperiodo.dt_referencia = DateTime.Parse(String.Concat("01/", txt_referencia.Text)).ToString("dd/MM/yyyy")
            coletaperiodo.dt_ini_amostra = DateTime.Parse(Right("00" & txt_dt_ini.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
            coletaperiodo.dt_fim_amostra = DateTime.Parse(Right("00" & txt_dt_fim.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")

            args.IsValid = True

            'VERIFICAR SE OS PERIODOS COINCIDEM

            'Verificar se há coletas manuais coincidindo com os periodos

            'SE NOVA COLETA MANUAL
            If (ViewState.Item("id_coleta_amostra_manual") Is Nothing) Then
                If CDate(coletamanual.dt_ini_amostra) < CDate(DateTime.Now.ToString("dd/MM/yyyy")) Then
                    args.IsValid = False
                    lmsg = "A data de início para coleta da amostra deve ser maior ou igual a data de hoje."
                Else
                    'se a data da ultima rota carregada for igual ou maior a data de inicio, nao pode
                    If CDate(coletamanual.dt_ini_amostra) <= CDate(ViewState.Item("dataultimacoleta")) Then
                        args.IsValid = False
                        lmsg = "A data de início para coleta da amostra deve ser maior que a data da última rota carregada."
                    End If
                End If
                If args.IsValid = True AndAlso coletamanual.getColetaAmostraManualbyPeriodo.Tables(0).Rows.Count > 0 Then
                    args.IsValid = False
                    lmsg = "Já existe o período informado para a propriedade no cadastro de amostras manuais."
                End If
            Else 'se ja existe a amostra manual
                If txt_dt_ini.Enabled = True Then
                    If CDate(coletamanual.dt_ini_amostra) < CDate(DateTime.Now.ToString("dd/MM/yyyy")) Then
                        args.IsValid = False
                        lmsg = "A data de início para coleta da amostra deve ser maior ou igual a data de hoje."
                    Else
                        'se a data da ultima rota carregada for igual ou maior a data de inicio, nao pode
                        If CDate(coletamanual.dt_ini_amostra) <= CDate(ViewState.Item("dataultimacoleta")) Then
                            args.IsValid = False
                            lmsg = "A data de início para coleta da amostra deve ser maior que a data da última rota carregada."
                        End If
                    End If
                End If
                If args.IsValid = True AndAlso txt_dt_fim.Enabled = True Then
                    If CDate(coletamanual.dt_fim_amostra) < CDate(DateTime.Now.ToString("dd/MM/yyyy")) Then
                        args.IsValid = False
                        lmsg = "A data final para coleta da amostra deve ser maior ou igual a data de hoje."
                    Else
                        'se a data da ultima rota carregada for igual ou maior a data de inicio, nao pode
                        If CDate(coletamanual.dt_fim_amostra) <= CDate(ViewState.Item("dataultimacoleta")) Then
                            args.IsValid = False
                            lmsg = "A data final para coleta da amostra deve ser maior que a data da última rota carregada."
                        End If
                    End If
                End If

                If args.IsValid = True Then
                    'inclui id atual para verificar periodo existente e nao considerar o registro da tela
                    coletamanual.id_coleta_amostra_manual = ViewState.Item("id_coleta_amostra_manual").ToString
                    If coletamanual.getColetaAmostraManualbyPeriodo.Tables(0).Rows.Count > 0 Then
                        args.IsValid = False
                        lmsg = "Já existe o período informado para a propriedade em outro cadastro de amostras manuais."
                    End If
                End If
            End If

            ''verifica o perioda  em amostras automaticas, 
            'If args.IsValid = True AndAlso coletaperiodo.getColetaAmostraPeriodobyPeriodo.Tables(0).Rows.Count > 0 Then
            '    args.IsValid = False
            '    lmsg = "Já existe o período informado em Coletas de Amostra automáticas no cadastro de Período de Amostras."
            'End If


            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub loadUnidProducaobyPropriedade()

        Try

            Dim up As New UnidadeProducao
            up.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            cbo_unid_producao.DataSource = up.getUnidadeProducaoByFilters
            cbo_unid_producao.DataTextField = "nr_unid_producao"
            cbo_unid_producao.DataValueField = "id_unid_producao"
            cbo_unid_producao.DataBind()
            cbo_unid_producao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            If cbo_unid_producao.Items.Count > 1 Then
                cbo_unid_producao.SelectedIndex = 1
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadUltimaColetabyPropriedade(ByVal id_propriedade As Integer)

        Try


            Dim coletaamostra As New ColetaAmostra
            Dim lpropmatriz As String = ""
            coletaamostra.id_propriedade = id_propriedade
            Dim dsultimacoleta As DataSet = coletaamostra.getColetaUltimaRotaCarregadaPropriedade
            If dsultimacoleta.Tables(0).Rows.Count > 0 Then
                With dsultimacoleta.Tables(0).Rows(0)
                    If Not .Item("id_propriedade_matriz").ToString.Equals("0") Then
                        lpropmatriz = " (Propriedade Matriz: " + .Item("id_propriedade_matriz").ToString + ")"
                    End If
                    lbl_ultima_coleta.Text = String.Concat("Rota: ", .Item("nm_linha").ToString, " - ", "Data: ", DateTime.Parse(.Item("dt_criacao")).ToString("dd/MM/yyyy HH:mm"), " - ", "Propriedade: ", .Item("id_propriedade").ToString, " Produtor: ", .Item("nm_pessoa").ToString, lpropmatriz)
                    ViewState.Item("dataultimacoleta") = DateTime.Parse(.Item("dt_criacao")).ToString("dd/MM/yyyy")

                End With
            Else
                lbl_ultima_coleta.Text = String.Empty
                ViewState.Item("dataultimacoleta") = String.Empty
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        carregarCamposPropriedade()
        'carrega combo unid produção
        loadUnidProducaobyPropriedade()
        If Not txt_id_propriedade.Text.Equals(String.Empty) Then
            loadUltimaColetabyPropriedade(Convert.ToInt32(ViewState.Item("id_propriedade")))

        End If

    End Sub

    Protected Sub txt_id_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_propriedade.TextChanged
        lbl_nm_propriedade.Text = String.Empty
        lbl_nm_propriedade.Visible = False
        hf_id_propriedade.Value = String.Empty
        ViewState.Item("id_propriedade") = 0
        'se propriedade é valida
        If Not txt_id_propriedade.Text.ToString.Equals(String.Empty) Then
            Dim propriedade As New Propriedade
            propriedade.id_propriedade = txt_id_propriedade.Text
            Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters
            If dspropriedade.Tables(0).Rows.Count > 0 Then
                With dspropriedade.Tables(0).Rows(0)
                    ViewState.Item("id_propriedade") = txt_id_propriedade.Text.Trim
                    hf_id_propriedade.Value = txt_id_propriedade.Text.Trim
                    lbl_nm_propriedade.Text = .Item("nm_propriedade").ToString
                    If Not IsDBNull(.Item("id_propriedade_matriz")) Then
                        lbl_proriedade_matriz.Text = .Item("id_propriedade_matriz").ToString
                    Else
                        lbl_proriedade_matriz.Text = String.Empty
                    End If
                End With
                loadUnidProducaobyPropriedade()
                loadUltimaColetabyPropriedade(Convert.ToInt32(ViewState.Item("id_propriedade")))

            End If
        Else
            cbo_unid_producao.Items.Clear()
            lbl_ultima_coleta.Text = String.Empty
            ViewState.Item("dataultimacoleta") = String.Empty

        End If

    End Sub

    Private Sub carregarCamposPropriedade()

        Try

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                ViewState.Item("id_propriedade") = Me.hf_id_propriedade.Value.ToString

                Dim propriedade As New Propriedade(Convert.ToInt32(Me.hf_id_propriedade.Value.ToString))

                Me.txt_id_propriedade.Text = propriedade.id_propriedade
                Me.lbl_nm_propriedade.Visible = True
                Me.lbl_nm_propriedade.Text = propriedade.nm_propriedade
                lbl_proriedade_matriz.Text = propriedade.id_propriedade_matriz.ToString

            End If


            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
