Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_frete_flash_fechamento

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            If Not (txt_cd_transportador.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("id_transportador") = Me.hf_id_transportador.Value
            Else
                ViewState.Item("id_transportador") = "0"
            End If
            If Not (txt_cd_cooperativa.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("id_cooperativa") = Me.hf_id_cooperativa.Value
            Else
                ViewState.Item("id_cooperativa") = "0"
            End If

            ViewState.Item("id_visao") = Me.cbo_visao.SelectedValue
            ViewState.Item("id_tipo_frete") = Me.cbo_tipofrete.SelectedValue
            ViewState.Item("dt_referencia") = String.Concat("01/", Me.txt_dt_referencia.Text.Trim)
            ViewState.Item("id_frete_periodo") = Me.hf_id_frete_periodo.Value
            ViewState.Item("salvar") = False
            loadData()
        End If
    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_frete_flash_fechamento.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_frete_flash_fechamento.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then '
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 258
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If

        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportadores"
        End With
        With btn_lupa_cooperativa
            .Attributes.Add("onclick", "javascript:ShowDialogCooperativa()")
            .ToolTip = "Filtrar Cooperativas"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento

            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_estabelecimento.SelectedValue = 1

            txt_dt_referencia.Text = DateTime.Parse(Now).ToString("MM/yyyy")
            ViewState.Item("salvar") = False

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim frete As New CalculoFrete

            If Trim(ViewState.Item("id_transportador")) <> "" Then
                frete.id_transportador = Convert.ToInt32(ViewState.Item("id_transportador").ToString)
            End If
            If Trim(ViewState.Item("id_cooperativa")) <> "" Then
                frete.id_cooperativa = Convert.ToInt32(ViewState.Item("id_cooperativa").ToString)
            End If
            frete.id_estabelecimento = ViewState.Item("id_estabelecimento")
            If ViewState.Item("dt_referencia").Equals(String.Empty) Then
                frete.dt_referencia = String.Empty
            Else
                frete.dt_referencia = ViewState.Item("dt_referencia").ToString()
            End If
            frete.id_frete_periodo = ViewState.Item("id_frete_periodo").ToString
            frete.id_tipo_frete = ViewState.Item("id_tipo_frete").ToString
            frete.dt_inicio = ViewState.Item("dt_inicio").ToString
            frete.dt_fim = ViewState.Item("dt_fim").ToString

            Dim dsfrete As DataSet

            Select Case ViewState.Item("id_tipo_frete").ToString
                Case "1", "3", "4"  'T1 'T2 produtor (tp
                    Select Case ViewState.Item("id_visao").ToString
                        Case "F"

                            gridRomaneioT2.Visible = False
                            gridResultsT2.Visible = False
                            gridromaneio.Visible = False
                            gridTotal.Visible = False
                            gridTotalT2.Visible = False
                            lk_concluir.Enabled = False

                            dsfrete = frete.getCalculoFreteFlashFechamento
                            If (dsfrete.Tables(0).Rows.Count > 0) Then
                                gridResults.Visible = True
                                gridResults.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                                gridResults.DataBind()
                            Else
                                gridResults.Visible = False
                                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                            End If
                        Case "FM"
                            gridRomaneioT2.Visible = False
                            gridResultsT2.Visible = False
                            gridromaneio.Visible = False
                            gridResults.Visible = False
                            gridTotalT2.Visible = False
                            lk_concluir.Enabled = True

                            dsfrete = frete.getCalculoFreteFlashFechamentoTotais
                            If (dsfrete.Tables(0).Rows.Count > 0) Then
                                gridTotal.Visible = True
                                gridTotal.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                                gridTotal.DataBind()
                            Else
                                gridTotal.Visible = False
                                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                            End If

                        Case "R"
                            gridRomaneioT2.Visible = False
                            gridResultsT2.Visible = False
                            gridResults.Visible = False
                            gridTotal.Visible = False
                            gridTotalT2.Visible = False
                            lk_concluir.Enabled = False

                            dsfrete = frete.getCalculoFreteRomaneiosErros
                            If (dsfrete.Tables(0).Rows.Count > 0) Then
                                gridromaneio.Visible = True
                                gridromaneio.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                                gridromaneio.DataBind()
                            Else
                                gridromaneio.Visible = False
                                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                            End If

                        Case "RC"
                            gridRomaneioT2.Visible = False
                            gridResultsT2.Visible = False
                            gridResults.Visible = False
                            gridTotal.Visible = False
                            gridTotalT2.Visible = False
                            lk_concluir.Enabled = False

                            dsfrete = frete.getCalculoFreteRomaneios
                            If (dsfrete.Tables(0).Rows.Count > 0) Then
                                gridromaneio.Visible = True
                                gridromaneio.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                                gridromaneio.DataBind()
                            Else
                                gridromaneio.Visible = False
                                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                            End If



                    End Select
                Case "2" 'T2
                    Select Case ViewState.Item("id_visao").ToString
                        Case "F"
                            gridRomaneioT2.Visible = False
                            gridResults.Visible = False
                            gridromaneio.Visible = False
                            gridTotal.Visible = False
                            gridTotalT2.Visible = False
                            lk_concluir.Enabled = False

                            dsfrete = frete.getCalculoFreteFlashFechamentoT2
                            If (dsfrete.Tables(0).Rows.Count > 0) Then
                                gridResultsT2.Visible = True
                                gridResultsT2.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                                gridResultsT2.DataBind()
                            Else
                                gridResultsT2.Visible = False
                                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                            End If

                        Case "FM"
                            gridRomaneioT2.Visible = False
                            gridResultsT2.Visible = False
                            gridromaneio.Visible = False
                            gridResults.Visible = False
                            gridTotal.Visible = False
                            lk_concluir.Enabled = True

                            dsfrete = frete.getCalculoFreteFlashFechamentoTotaisT2
                            If (dsfrete.Tables(0).Rows.Count > 0) Then
                                gridTotalT2.Visible = True
                                gridTotalT2.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                                gridTotalT2.DataBind()
                            Else
                                gridTotalT2.Visible = False
                                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                            End If

                        Case "R" 'divergencia
                            gridResultsT2.Visible = False
                            gridResults.Visible = False
                            gridromaneio.Visible = False
                            gridTotal.Visible = False
                            gridTotalT2.Visible = False
                            lk_concluir.Enabled = False

                            dsfrete = frete.getCalculoFreteRomaneiosErrosT2
                            If (dsfrete.Tables(0).Rows.Count > 0) Then
                                gridRomaneioT2.Visible = True
                                gridRomaneioT2.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                                gridRomaneioT2.DataBind()
                            Else
                                gridRomaneioT2.Visible = False
                                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                            End If



                        Case "RC" 'calculado
                            gridResultsT2.Visible = False
                            gridResults.Visible = False
                            gridromaneio.Visible = False
                            gridTotal.Visible = False
                            gridTotalT2.Visible = False
                            lk_concluir.Enabled = False

                            dsfrete = frete.getCalculoFreteRomaneiosT2
                            If (dsfrete.Tables(0).Rows.Count > 0) Then
                                gridRomaneioT2.Visible = True
                                gridRomaneioT2.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                                gridRomaneioT2.DataBind()
                            Else
                                gridRomaneioT2.Visible = False
                                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                            End If


                    End Select

            End Select



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean

    '    If Not (customPage.getFilterValue("freteflashf", cbo_estabelecimento.ID).Equals("0")) Then
    '        ViewState.Item("id_estabelecimento") = 0
    '        cbo_estabelecimento.SelectedValue = 0
    '    Else
    '        hasFilters = True
    '        ViewState.Item("id_estabelecimento") = customPage.getFilterValue("freteflashf", cbo_estabelecimento.ID)
    '        Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
    '    End If

    '    If Not (customPage.getFilterValue("freteflashf", txt_cd_transportador.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        txt_cd_transportador.Text = customPage.getFilterValue("freteflashf", txt_cd_transportador.ID)
    '    Else
    '        txt_cd_transportador.Text = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("freteflashf", lbl_nm_transportador.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        lbl_nm_transportador.Text = customPage.getFilterValue("freteflashf", lbl_nm_transportador.ID)
    '    Else
    '        lbl_nm_transportador.Text = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("freteflashf", hf_id_transportador.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_transportador") = customPage.getFilterValue("freteflashf", hf_id_transportador.ID)
    '        hf_id_transportador.Value = ViewState.Item("id_transportador").ToString()
    '    Else
    '        ViewState.Item("id_transportador") = String.Empty
    '    End If
    '    If Not (customPage.getFilterValue("freteflashf", txt_cd_cooperativa.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        txt_cd_cooperativa.Text = customPage.getFilterValue("freteflashf", txt_cd_cooperativa.ID)
    '    Else
    '        txt_cd_cooperativa.Text = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("freteflashf", lbl_nm_cooperativa.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        lbl_nm_cooperativa.Text = customPage.getFilterValue("freteflashf", lbl_nm_cooperativa.ID)
    '    Else
    '        lbl_nm_cooperativa.Text = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("freteflashf", hf_id_cooperativa.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_cooperativa") = customPage.getFilterValue("freteflashf", hf_id_cooperativa.ID)
    '        hf_id_cooperativa.Value = ViewState.Item("id_cooperativa").ToString()
    '    Else
    '        ViewState.Item("id_cooperativa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("freteflashf", txt_cd_conta.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("cd_conta") = customPage.getFilterValue("freteflashf", txt_cd_conta.ID)
    '        txt_cd_conta.Text = ViewState.Item("cd_conta").ToString()
    '    Else
    '        ViewState.Item("cd_conta") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("freteflashf", txt_nm_conta.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("nm_conta") = customPage.getFilterValue("freteflashf", txt_nm_conta.ID)
    '        txt_nm_conta.Text = ViewState.Item("nm_conta").ToString()
    '    Else
    '        ViewState.Item("nm_conta") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("freteflashf", txt_nr_romaneio.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_romaneio") = customPage.getFilterValue("freteflashf", txt_nr_romaneio.ID)
    '        txt_nr_romaneio.Text = ViewState.Item("id_romaneio").ToString()
    '    Else
    '        ViewState.Item("id_romaneio") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("freteflashf", txt_dt_referencia.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("dt_referencia") = customPage.getFilterValue("freteflashf", txt_dt_referencia.ID)
    '        txt_dt_referencia.Text = ViewState.Item("dt_referencia").ToString()
    '    Else
    '        ViewState.Item("dt_referencia") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("freteflashf", cbo_situacao.ID).Equals("0")) Then
    '        ViewState.Item("id_situacao") = 0
    '        cbo_situacao.SelectedValue = 0
    '    Else
    '        hasFilters = True
    '        ViewState.Item("id_situacao") = customPage.getFilterValue("freteflashf", cbo_situacao.ID)
    '        cbo_situacao.SelectedValue = ViewState.Item("id_situacao").ToString()
    '    End If

    '    'If Not (customPage.getFilterValue("lancfrete", txt_id_importacao.ID).Equals(String.Empty)) Then
    '    '    hasFilters = True
    '    '    ViewState.Item("id_importacao") = customPage.getFilterValue("lancfrete", txt_id_importacao.ID)
    '    '    txt_id_importacao.Text = ViewState.Item("id_importacao").ToString()
    '    'Else
    '    '    ViewState.Item("id_importacao") = String.Empty
    '    'End If

    '    If Not (customPage.getFilterValue("freteflashf", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("freteflashf", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("lancfrete")
    '    End If

    'End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_seq As Label = CType(e.Row.FindControl("lbl_seq"), Label)

            If lbl_seq.Text = "4" Then
                e.Row.BackColor = Drawing.Color.CornflowerBlue
                e.Row.ForeColor = Drawing.Color.White
                e.Row.Font.Bold = True
            End If

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
    Protected Sub txt_cd_cooperativa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_cooperativa.TextChanged
        If Not txt_cd_cooperativa.Text.Equals(String.Empty) Then
            loadCooperativaByCodigo()
        Else
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            hf_id_cooperativa.Value = String.Empty
            lbl_cd_cnpj.Text = String.Empty
            lbl_cd_cnpj.Visible = False
            Me.lbl_nm_cnpj.Visible = False
        End If
    End Sub
    Private Sub loadCooperativaByCodigo()

        Try


            Dim cooperativa As New Pessoa
            cooperativa.cd_pessoa = txt_cd_cooperativa.Text
            Dim dscooperativa As DataSet = cooperativa.getCooperativasByCodigo()
            If dscooperativa.Tables(0).Rows.Count > 0 Then
                lbl_nm_cooperativa.Visible = True
                lbl_cd_cnpj.Visible = True
                Me.lbl_nm_cnpj.Visible = True
                lbl_nm_cooperativa.Text = dscooperativa.Tables(0).Rows(0).Item("nm_pessoa")
                lbl_cd_cnpj.Text = dscooperativa.Tables(0).Rows(0).Item("cd_cnpj")
                hf_id_cooperativa.Value = dscooperativa.Tables(0).Rows(0).Item("id_pessoa")
                ViewState.Item("id_estado_cooperativa") = dscooperativa.Tables(0).Rows(0).Item("id_estado")
            Else
                lbl_nm_cooperativa.Visible = False
                lbl_cd_cnpj.Visible = False
                Me.lbl_nm_cnpj.Visible = False
                hf_id_cooperativa.Value = String.Empty
                ViewState.Item("id_estado_cooperativa") = 0
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadTransportadorByCodigo()

        Try


            Dim transp As New Pessoa
            transp.cd_pessoa = txt_cd_transportador.Text
            Dim dstransp As DataSet = transp.getTransportadorCooperativaByFilters()
            If dstransp.Tables(0).Rows.Count > 0 Then
                lbl_nm_transportador.Visible = True
                lbl_nm_transportador.Text = dstransp.Tables(0).Rows(0).Item("nm_pessoa")
                hf_id_transportador.Value = dstransp.Tables(0).Rows(0).Item("id_pessoa")
            Else
                lbl_nm_transportador.Visible = False
                hf_id_transportador.Value = String.Empty
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        If Not txt_cd_transportador.Text.Equals(String.Empty) Then
            loadTransportadorByCodigo()
        Else
            lbl_nm_transportador.Text = String.Empty
            lbl_nm_transportador.Visible = False
            hf_id_transportador.Value = String.Empty
        End If

    End Sub

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
        Else
            txt_cd_transportador.Text = String.Empty
            hf_id_transportador.Value = String.Empty
            lbl_nm_transportador.Text = String.Empty
            lbl_nm_transportador.Visible = False
        End If

    End Sub
    Private Sub carregarCamposTransportador()

        Try

            If Not (customPage.getFilterValue("lupa_transcoop", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transcoop", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transcoop", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transcoop", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_transcoop")

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposCooperativa()

        Try

            If Not (customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").Equals(String.Empty)) Then
                Me.lbl_nm_cooperativa.Visible = True
                Me.lbl_nm_cooperativa.Text = customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").Equals(String.Empty)) Then
                Me.txt_cd_cooperativa.Text = customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").Equals(String.Empty)) Then
                Me.lbl_cd_cnpj.Visible = True
                Me.lbl_cd_cnpj.Text = customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").ToString
                Me.lbl_nm_cnpj.Visible = True
            End If

            'loadData()
            customPage.clearFilters("lupa_cooperativa")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_cooperativa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_cooperativa.Click
        If Not (Me.hf_id_cooperativa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposCooperativa()
        Else
            txt_cd_cooperativa.Text = String.Empty
            hf_id_cooperativa.Value = String.Empty
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            lbl_cd_cnpj.Text = String.Empty
            lbl_cd_cnpj.Visible = False
            Me.lbl_nm_cnpj.Visible = False
        End If
    End Sub

    Protected Sub cv_calculo_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_calculo.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True

            Dim periodo As New FretePeriodo
            periodo.dt_referencia = String.Concat("01/", txt_dt_referencia.Text)

            Dim dsperiodo As DataSet = periodo.getFretePeriodo
            If dsperiodo.Tables(0).Rows.Count > 0 Then
                hf_id_frete_periodo.Value = dsperiodo.Tables(0).Rows(0).Item("id_frete_periodo")
                ViewState.Item("dt_inicio") = dsperiodo.Tables(0).Rows(0).Item("dt_inicio").ToString
                ViewState.Item("dt_fim") = dsperiodo.Tables(0).Rows(0).Item("dt_fim").ToString

                If cbo_tipofrete.SelectedValue = 1 Then 'se t1
                    If dsperiodo.Tables(0).Rows(0).Item("st_calculo_definitivo_t1").ToString = "S" Then
                        lbl_referencia.Text = "*Para a referência e tipo de frete informados o cálculo definitivo já foi efetuado."
                    End If
                End If
                If cbo_tipofrete.SelectedValue = 2 Then
                    If dsperiodo.Tables(0).Rows(0).Item("st_calculo_definitivo_t2").ToString = "S" Then
                        lbl_referencia.Text = "*Para a referência e tipo de frete informados o cálculo definitivo já foi efetuado."
                    End If
                End If
                If cbo_tipofrete.SelectedValue = 3 Then
                    If dsperiodo.Tables(0).Rows(0).Item("st_calculo_definitivo_tp").ToString = "S" Then
                        lbl_referencia.Text = "*Para a referência e tipo de frete informados o cálculo definitivo já foi efetuado."
                    End If
                End If
            Else
                lbl_referencia.Text = String.Empty
                lmsg = "Referência informada não está cadastrada em Período de Frete."
                args.IsValid = False
            End If

            If Not txt_cd_cooperativa.Text.Equals(String.Empty) AndAlso hf_id_cooperativa.Value.Equals(String.Empty) Then
                lmsg = "Cooperativa não cadastrada."
                args.IsValid = False

            End If
            If Not txt_cd_transportador.Text.Equals(String.Empty) AndAlso hf_id_transportador.Value.Equals(String.Empty) Then
                lmsg = "Transportador não cadastrado."
                args.IsValid = False

            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Page.IsValid Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            If Not (txt_cd_transportador.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("id_transportador") = Me.hf_id_transportador.Value
            Else
                ViewState.Item("id_transportador") = "0"
            End If
            If Not (txt_cd_cooperativa.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("id_cooperativa") = Me.hf_id_cooperativa.Value
            Else
                ViewState.Item("id_cooperativa") = "0"
            End If

            ViewState.Item("id_visao") = Me.cbo_visao.SelectedValue
            ViewState.Item("id_tipo_frete") = Me.cbo_tipofrete.SelectedValue
            ViewState.Item("dt_referencia") = String.Concat("01/", Me.txt_dt_referencia.Text.Trim)
            ViewState.Item("id_frete_periodo") = Me.hf_id_frete_periodo.Value

            loadData()

            If ViewState.Item("id_tipo_frete").ToString = "2" Then
                Select Case ViewState.Item("id_visao").ToString
                    Case "F"
                        If gridResultsT2.Visible = True Then
                            If gridResultsT2.Rows.Count.ToString + 1 < 65536 Then
                                'FRAN 08/12/2020 i incluir log 
                                Dim usuariolog As New UsuarioLog
                                usuariolog.id_usuario = Session("id_login")
                                usuariolog.ds_id_session = Session.SessionID.ToString()
                                usuariolog.id_tipo_log = 8 'exporta~ção
                                usuariolog.id_menu_item = 258
                                usuariolog.insertUsuarioLog()
                                'FRAN 08/12/2020  incluir log 

                                Response.Redirect("frm_frete_flash_fechamentot2_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_tipo_frete=" + ViewState.Item("id_tipo_frete").ToString + "&id_visao=" + ViewState.Item("id_visao").ToString + "&id_transportador=" + ViewState.Item("id_transportador").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_frete_periodo=" + ViewState.Item("id_frete_periodo").ToString)
                            Else
                                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
                            End If
                        End If

                    Case "R", "RC"
                        'se o grid tiver mais que 65536  linhas não podemos exportar
                        If gridRomaneioT2.Visible = True Then
                            If gridRomaneioT2.Rows.Count.ToString + 1 < 65536 Then
                                'FRAN 08/12/2020 i incluir log 
                                Dim usuariolog As New UsuarioLog
                                usuariolog.id_usuario = Session("id_login")
                                usuariolog.ds_id_session = Session.SessionID.ToString()
                                usuariolog.id_tipo_log = 8 'exporta~ção
                                usuariolog.id_menu_item = 258
                                usuariolog.insertUsuarioLog()
                                'FRAN 08/12/2020  incluir log 

                                Response.Redirect("frm_frete_flash_fechamentot2_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_tipo_frete=" + ViewState.Item("id_tipo_frete").ToString + "&id_visao=" + ViewState.Item("id_visao").ToString + "&id_transportador=" + ViewState.Item("id_transportador").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_frete_periodo=" + ViewState.Item("id_frete_periodo").ToString)
                            Else
                                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
                            End If
                        End If
                End Select

            Else
                Select Case ViewState.Item("id_visao").ToString
                    Case "F"
                        'se o grid tiver mais que 65536  linhas não podemos exportar
                        If gridResults.Visible = True Then
                            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                                'FRAN 08/12/2020 i incluir log 
                                Dim usuariolog As New UsuarioLog
                                usuariolog.id_usuario = Session("id_login")
                                usuariolog.ds_id_session = Session.SessionID.ToString()
                                usuariolog.id_tipo_log = 8 'exporta~ção
                                usuariolog.id_menu_item = 258
                                usuariolog.insertUsuarioLog()
                                'FRAN 08/12/2020  incluir log 

                                Response.Redirect("frm_frete_flash_fechamento_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_tipo_frete=" + ViewState.Item("id_tipo_frete").ToString + "&id_visao=" + ViewState.Item("id_visao").ToString + "&id_transportador=" + ViewState.Item("id_transportador").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_frete_periodo=" + ViewState.Item("id_frete_periodo").ToString)
                            Else
                                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
                            End If
                        End If

                    Case "R", "RC"
                        'se o grid tiver mais que 65536  linhas não podemos exportar
                        If gridromaneio.Visible = True Then
                            If gridromaneio.Rows.Count.ToString + 1 < 65536 Then
                                'FRAN 08/12/2020 i incluir log 
                                Dim usuariolog As New UsuarioLog
                                usuariolog.id_usuario = Session("id_login")
                                usuariolog.ds_id_session = Session.SessionID.ToString()
                                usuariolog.id_tipo_log = 8 'exporta~ção
                                usuariolog.id_menu_item = 258
                                usuariolog.insertUsuarioLog()
                                'FRAN 08/12/2020  incluir log 

                                Response.Redirect("frm_frete_flash_fechamento_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_tipo_frete=" + ViewState.Item("id_tipo_frete").ToString + "&id_visao=" + ViewState.Item("id_visao").ToString + "&id_transportador=" + ViewState.Item("id_transportador").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_frete_periodo=" + ViewState.Item("id_frete_periodo").ToString)
                            Else
                                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
                            End If
                        End If

                End Select


            End If
        End If
    End Sub

    Protected Sub gridResultsT2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResultsT2.PageIndexChanging
        gridResultsT2.PageIndex = e.NewPageIndex
        loadData()


    End Sub

    Protected Sub gridResultsT2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsT2.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
       And e.Row.RowType <> DataControlRowType.Footer _
       And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_seq As Label = CType(e.Row.FindControl("lbl_seq"), Label)

            If lbl_seq.Text = "4" Then
                e.Row.BackColor = Drawing.Color.CornflowerBlue
                e.Row.ForeColor = Drawing.Color.White
                e.Row.Font.Bold = True
            End If

        End If
    End Sub

    Protected Sub gridResultsT2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResultsT2.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub txt_nr_cte_multi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txt_nr_cte_multi As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_cte_multi"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

        txt_nr_cte_multi.ForeColor = Drawing.Color.Red
        ViewState.Item("salvar") = True

    End Sub

    Protected Sub txt_nr_viagem_multi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txt_nr_viagem_multi As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_viagem_multi"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

        txt_nr_viagem_multi.ForeColor = Drawing.Color.Red
        ViewState.Item("salvar") = True

    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub
    Private Sub updateData()
        If Page.IsValid = True Then

            Try

                Dim calctransp As New CalculoFrete
                Dim row As GridViewRow

                If ViewState.Item("id_tipo_frete").ToString = "2" Then
                    For Each row In gridTotalT2.Rows
                        If row.Visible = True Then
                            Dim lbl_st_tipo_calculo As Label = CType(row.FindControl("lbl_st_tipo_calculo"), Label)
                            Dim txt_nr_viagem_multi As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_viagem_multit2"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                            Dim txt_nr_cte_multi As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_cte_multit2"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                            calctransp.id_calculo_frete_transportador = Me.gridTotalT2.DataKeys(row.RowIndex).Value.ToString

                            If Not txt_nr_cte_multi.Text.Equals(String.Empty) Then
                                calctransp.nr_cte_multi = txt_nr_cte_multi.Text
                            Else
                                calctransp.nr_cte_multi = String.Empty
                            End If
                            If Not txt_nr_viagem_multi.Text.Equals(String.Empty) Then
                                calctransp.nr_viagem_multi = txt_nr_viagem_multi.Text
                            Else
                                calctransp.nr_viagem_multi = 0
                            End If

                            calctransp.id_modificador = Session("id_login")

                            calctransp.updateCalculoFreteTransportadorMulti()

                        End If
                    Next

                Else
                    For Each row In gridTotal.Rows
                        If row.Visible = True Then
                            Dim lbl_st_tipo_calculo As Label = CType(row.FindControl("lbl_st_tipo_calculo"), Label)
                            Dim txt_nr_viagem_multi As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_viagem_multi"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                            Dim txt_nr_cte_multi As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_cte_multi"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                            calctransp.id_calculo_frete_transportador = Me.gridTotal.DataKeys(row.RowIndex).Value.ToString

                            If Not txt_nr_cte_multi.Text.Equals(String.Empty) Then
                                calctransp.nr_cte_multi = txt_nr_cte_multi.Text
                            Else
                                calctransp.nr_cte_multi = String.Empty
                            End If
                            If Not txt_nr_viagem_multi.Text.Equals(String.Empty) Then
                                calctransp.nr_viagem_multi = txt_nr_viagem_multi.Text
                            Else
                                calctransp.nr_viagem_multi = 0
                            End If

                            calctransp.id_modificador = Session("id_login")

                            calctransp.updateCalculoFreteTransportadorMulti()

                        End If
                    Next

                End If

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'alteracao
                usuariolog.id_menu_item = 258
                usuariolog.ds_nm_processo = String.Concat("Tipo Frete: ", ViewState.Item("id_tipo_frete").ToString, " Periodo: ", ViewState.Item("id_frete_periodo").ToString)
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Dados Multi atualizados com sucesso.")

                loadData()




            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub gridTotal_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridTotal.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "anexar"
                Response.Redirect("frm_calculo_frete_transportador_anexo.aspx?id=" + e.CommandArgument.ToString())

        End Select

    End Sub

    Protected Sub gridTotal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridTotal.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_st_tipo_calculo As Label = CType(e.Row.FindControl("lbl_st_tipo_calculo"), Label)
            Dim txt_nr_viagem_multi As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_viagem_multi"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
            Dim txt_nr_cte_multi As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_cte_multi"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
            Dim btn_anexar As Anthem.ImageButton = CType(e.Row.FindControl("btn_anexar"), Anthem.ImageButton)

            If lbl_st_tipo_calculo.Text = "D" Then
                txt_nr_viagem_multi.Enabled = True
                txt_nr_cte_multi.Enabled = True
                btn_anexar.Enabled = True
                txt_nr_viagem_multi.ToolTip = String.Empty
                txt_nr_cte_multi.ToolTip = String.Empty
                btn_anexar.ToolTip = String.Empty
            Else
                txt_nr_viagem_multi.Enabled = False
                txt_nr_cte_multi.Enabled = False
                btn_anexar.Enabled = False
                txt_nr_viagem_multi.ToolTip = "Cálculo deve ser definitivo."
                txt_nr_cte_multi.ToolTip = "Cálculo deve ser definitivo."
                btn_anexar.ToolTip = "Cálculo deve ser definitivo."

            End If

        End If

    End Sub

    Protected Sub gridTotalT2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridTotalT2.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "anexar"
                Response.Redirect("frm_calculo_frete_transportador_anexo.aspx?id=" + e.CommandArgument.ToString())

        End Select

    End Sub

    Protected Sub gridTotalT2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridTotalT2.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_st_tipo_calculo As Label = CType(e.Row.FindControl("lbl_st_tipo_calculo"), Label)
            Dim txt_nr_viagem_multi As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_viagem_multit2"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
            Dim txt_nr_cte_multi As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_nr_cte_multit2"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
            Dim btn_anexar As Anthem.ImageButton = CType(e.Row.FindControl("btn_anexar"), Anthem.ImageButton)

            If lbl_st_tipo_calculo.Text = "D" Then
                txt_nr_viagem_multi.Enabled = True
                txt_nr_cte_multi.Enabled = True
                btn_anexar.Enabled = True
                txt_nr_viagem_multi.ToolTip = String.Empty
                txt_nr_cte_multi.ToolTip = String.Empty
                btn_anexar.ToolTip = String.Empty
            Else
                txt_nr_viagem_multi.Enabled = False
                txt_nr_cte_multi.Enabled = False
                btn_anexar.Enabled = False
                txt_nr_viagem_multi.ToolTip = "Cálculo deve ser definitivo."
                txt_nr_cte_multi.ToolTip = "Cálculo deve ser definitivo."
                btn_anexar.ToolTip = "Cálculo deve ser definitivo."

            End If

        End If
    End Sub

    Protected Sub txt_nr_cte_multit2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txt_nr_cte_multi As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_cte_multit2"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

        txt_nr_cte_multi.ForeColor = Drawing.Color.Red
        ViewState.Item("salvar") = True

    End Sub

    Protected Sub txt_nr_viagem_multit2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txt_nr_viagem_multi As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_viagem_multit2"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

        txt_nr_viagem_multi.ForeColor = Drawing.Color.Red
        ViewState.Item("salvar") = True

    End Sub
End Class
