Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class lst_frete_calculo_romaneio

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

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

        Response.Redirect("lst_frete_calculo_romaneio.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_frete_calculo_romaneio.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 257
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_estabelecimento.SelectedValue = 1
            cbo_tipofrete.SelectedValue = 1

            If Day(Now()) > 26 Then
                txt_dt_referencia.Text = DateTime.Parse(DateAdd(DateInterval.Month, 1, Now)).ToString("MM/yyyy")
            Else
                txt_dt_referencia.Text = DateTime.Parse(Now).ToString("MM/yyyy")
            End If
            Dim periodo As New FretePeriodo
            periodo.dt_referencia = String.Concat("01/", txt_dt_referencia.Text)

            Dim dsperiodo As DataSet = periodo.getFretePeriodo
            If dsperiodo.Tables(0).Rows.Count > 0 Then
                hf_id_frete_periodo.Value = dsperiodo.Tables(0).Rows(0).Item("id_frete_periodo")
                hf_dt_inicio.Value = dsperiodo.Tables(0).Rows(0).Item("dt_inicio").ToString
                hf_dt_fim.Value = dsperiodo.Tables(0).Rows(0).Item("dt_fim").ToString
            End If
            ViewState("aba_ativa") = 0


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim poupancacalculo As New PoupancaCalculoExecucao()

            If ViewState.Item("id_poupanca_calculo_execucao") > 0 Then
                'preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
                poupancacalculo.id_poupanca_calculo_execucao = Convert.ToInt32(ViewState.Item("id_poupanca_calculo_execucao").ToString)

                Dim dspoupancacalculoselecao As DataSet = poupancacalculo.getPoupancaCalculoExecucaoItensByFilters()

                If (dspoupancacalculoselecao.Tables(0).Rows.Count > 0) Then
                    'Me.lk_calcular.Enabled = True
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dspoupancacalculoselecao.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    ' Me.lk_calcular.Enabled = False
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If

                lbl_id_frete_calculo_execucao.Text = ViewState.Item("id_poupanca_calculo_execucao")
            Else
                messageControl.Alert("Houve problemas técnicos na seleção do cálculo de poupança. Contacte o administrador do sistema.")
                lbl_id_frete_calculo_execucao.Text = String.Empty

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    'Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

    '    Select Case e.SortExpression.ToLower()

    '        Case "ds_propriedade"
    '            If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
    '                ViewState.Item("sortExpression") = "ds_propriedade desc"
    '            Else
    '                ViewState.Item("sortExpression") = "ds_propriedade asc"
    '            End If
    '        Case "ds_produtor"
    '            If (ViewState.Item("sortExpression")) = "ds_produtor asc" Then
    '                ViewState.Item("sortExpression") = "ds_produtor desc"
    '            Else
    '                ViewState.Item("sortExpression") = "ds_produtor asc"
    '            End If



    '    End Select

    '    loadData()

    'End Sub

    'Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

    '    Try

    '        If (e.Row.RowType <> DataControlRowType.Header _
    '            And e.Row.RowType <> DataControlRowType.Footer _
    '            And e.Row.RowType <> DataControlRowType.Pager) Then

    '            Dim ck_item As Anthem.CheckBox = CType(e.Row.FindControl("ck_item"), Anthem.CheckBox)
    '            Dim id_selecao As Label = CType(e.Row.FindControl("id_selecao"), Label)
    '            Dim lbl_situacao_calculo As Label = CType(e.Row.FindControl("lbl_situacao_calculo"), Label)
    '            Dim st_poupanca_calculo_execucao_itens As Label = CType(e.Row.FindControl("st_poupanca_calculo_execucao_itens"), Label)

    '            Select Case st_poupanca_calculo_execucao_itens.Text
    '                Case "2"
    '                    lbl_situacao_calculo.Text = "Calculado com Sucesso."
    '                Case "3"
    '                    lbl_situacao_calculo.Text = "Não Participa Cálculo: Já efetuado Pagamento Mensal de Poupança."
    '                Case "4"
    '                    lbl_situacao_calculo.Text = "Não Participa Cálculo: Não possui Adesão à Poupança."
    '                Case "6"
    '                    lbl_situacao_calculo.Text = "Calculado: Não atingiu parâmetro de Qualidade Antibiótico."
    '                Case "7"
    '                    lbl_situacao_calculo.Text = "Não Participa Cálculo: Não possui Adesão à Poupança para mês de referência selecionado para cálculo."
    '                Case "8"
    '                    lbl_situacao_calculo.Text = "Calculado: Não atingiu parâmetro de Qualidade Proteína."
    '                Case "9"
    '                    lbl_situacao_calculo.Text = "Calculado: Não atingiu parâmetro de Qualidade CCS."
    '                Case "10"
    '                    lbl_situacao_calculo.Text = "Calculado: Não atingiu parâmetro de Qualidade Gordura."
    '                Case "11"
    '                    lbl_situacao_calculo.Text = "Calculado: Não atingiu parâmetro de Qualidade CTM."
    '                Case "12"
    '                    lbl_situacao_calculo.Text = "Não Participa: Não efetuou cálculo definitivo para referência."
    '                Case "13"
    '                    lbl_situacao_calculo.Text = "Calculado: Não atingiu parâmetro de Qualidade nas Análises de Romaneio."
    '                Case Else
    '                    lbl_situacao_calculo.Text = String.Empty
    '            End Select

    '            'se id_selecao =2 não pode ser selecionado para calculo... (se nao tiver adesão ou já tiver efetuado pagamento mensal
    '            If id_selecao.Text.Equals("2") Then
    '                ck_item.Enabled = False
    '                ck_item.ToolTip = "Não participa do cálculo."
    '            Else
    '                ck_item.Enabled = True
    '                ck_item.ToolTip = String.Empty
    '            End If

    '        End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub




    'Protected Sub lk_calcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_calcular.Click
    '    Try

    '        ' saveFilters()
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

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        Try

            If Page.IsValid Then

                Dim fretecalculo As New CalculoFrete

                fretecalculo.id_estabelecimento = cbo_estabelecimento.SelectedValue
                fretecalculo.id_tipo_frete = cbo_tipofrete.SelectedValue
                fretecalculo.dt_referencia = DateTime.Parse(String.Concat("01/", txt_dt_referencia.Text)).ToString("dd/MM/yyyy")
                fretecalculo.id_frete_periodo = hf_id_frete_periodo.Value
                If chk_calculo_definitivo.Checked = True Then
                    fretecalculo.st_calculo_definitivo = "S"
                Else
                    fretecalculo.st_calculo_definitivo = "N"
                End If
                fretecalculo.id_modificador = Session("id_login")

                ViewState.Item("id_calculo_frete_execucao") = fretecalculo.insertCalculoFreteExecucao()

                lbl_id_frete_calculo_execucao.Text = String.Concat(ViewState.Item("id_calculo_frete_execucao").ToString, " - Aguarde término da execução do cálculo...")

                'FRAN 08/12/2020 i incluir log 
                If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'processo
                    usuariolog.id_menu_item = 257
                    usuariolog.id_nr_processo = ViewState.Item("id_calculo_frete_execucao")
                    usuariolog.insertUsuarioLog()
                End If
                'FRAN 08/12/2020  incluir log 

                fretecalculo.id_calculo_frete_execucao = ViewState.Item("id_calculo_frete_execucao")
                fretecalculo.dt_inicio = hf_dt_inicio.Value
                fretecalculo.dt_fim = hf_dt_fim.Value
                fretecalculo.st_tipo_calculo = "P"
                Select Case cbo_tipofrete.SelectedValue
                    Case "1"
                        fretecalculo.CalcularFreteT1()
                    Case "2"
                        fretecalculo.CalcularFreteT2()
                    Case "3"
                        fretecalculo.CalcularFreteT3T4()
                End Select

                lbl_id_frete_calculo_execucao.Text = ViewState.Item("id_calculo_frete_execucao").ToString

                loadAbaAtiva(ViewState("aba_ativa"))

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
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
                hf_dt_inicio.Value = dsperiodo.Tables(0).Rows(0).Item("dt_inicio").ToString
                hf_dt_fim.Value = dsperiodo.Tables(0).Rows(0).Item("dt_fim").ToString

                If cbo_tipofrete.SelectedValue = 1 Then 'se t1
                    If dsperiodo.Tables(0).Rows(0).Item("st_calculo_definitivo_t1").ToString = "S" Then
                        lmsg = "Referência informada já tem cálculo definitivo para T1."
                        args.IsValid = False
                    End If
                End If
                If cbo_tipofrete.SelectedValue = 2 Then
                    If dsperiodo.Tables(0).Rows(0).Item("st_calculo_definitivo_t2").ToString = "S" Then
                        lmsg = "Referência informada já tem calculo definitivo para T2."
                        args.IsValid = False
                    End If
                End If
                If cbo_tipofrete.SelectedValue = 3 Then
                    If dsperiodo.Tables(0).Rows(0).Item("st_calculo_definitivo_tp").ToString = "S" Then
                        lmsg = "Referência informada já tem calculo definitivo para T2 de TP e de TVASE."
                        args.IsValid = False
                    End If
                End If
            Else
                lmsg = "Referência informada não está cadastrada em Período de Frete."
                args.IsValid = False
            End If


            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_resultados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_resultados.Click
        ViewState("aba_ativa") = 0
        loadabas()

    End Sub

    Protected Sub btn_romaneios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_romaneios.Click
        ViewState("aba_ativa") = 1
        loadabas()

    End Sub
    Private Sub loadabas()

        Try

            td_resultados.Attributes.Remove("class")
            If ViewState("aba_ativa") = 0 Then
                pnl_resultados.BackImageUrl = "~/img/aba_ativa.gif"
                pnl_resultados.ForeColor = System.Drawing.Color.FromName("#0000F5")
                pnl_resultados.ForeColor = System.Drawing.Color.FromName("#0000F5")
                'lid_aba_ativa = btn_resultados.CommandArgument
            Else
                pnl_resultados.BackImageUrl = "~/img/aba_nao_ativa.gif"
                pnl_resultados.ForeColor = System.Drawing.Color.FromName("#6767CC")
                btn_resultados.ForeColor = System.Drawing.Color.FromName("#6767CC")
            End If
            If ViewState("aba_ativa") = 1 Then
                pnl_romaneios.BackImageUrl = "~/img/aba_ativa_grande.gif"
                pnl_romaneios.ForeColor = System.Drawing.Color.FromName("#0000F5")
                btn_romaneios.ForeColor = System.Drawing.Color.FromName("#0000F5")
                'lid_aba_ativa = btn_romaneios.CommandArgument
            Else
                pnl_romaneios.BackImageUrl = "~/img/aba_nao_ativa_grande.gif"
                pnl_romaneios.ForeColor = System.Drawing.Color.FromName("#6767CC")
                btn_romaneios.ForeColor = System.Drawing.Color.FromName("#6767CC")
            End If

            loadAbaAtiva(ViewState("aba_ativa"))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadAbaAtiva(ByVal id_aba_ativa As Int32)

        Try

            If id_aba_ativa = 0 Then
                '=========================
                ' Se mostrar Resultados
                '=========================
                Dim fretecalculo As New CalculoFrete
                Dim dsfrete As DataSet

                fretecalculo.id_calculo_frete_execucao = ViewState.Item("id_calculo_frete_execucao")
                fretecalculo.id_estabelecimento = cbo_estabelecimento.SelectedValue
                fretecalculo.id_tipo_frete = cbo_tipofrete.SelectedValue
                fretecalculo.dt_referencia = DateTime.Parse(String.Concat("01/", txt_dt_referencia.Text)).ToString("dd/MM/yyyy")
                fretecalculo.id_frete_periodo = hf_id_frete_periodo.Value
                If chk_calculo_definitivo.Checked = True Then
                    fretecalculo.st_calculo_definitivo = "S"
                Else
                    fretecalculo.st_calculo_definitivo = "N"
                End If
                dsfrete = fretecalculo.getCalculoFretebyTransportador()

                'ViewState.Item("sortExpression") = "id_exportacao_batch_execucao desc, id_exportacao_batch_itens asc"
                gridRomaneios.Visible = False
                gridromaneiot2.Visible = False

                If (dsfrete.Tables(0).Rows.Count > 0) Then
                    lbl_preco_medio.Text = dsfrete.Tables(0).Rows(0).Item("nr_preco_medio_leite")
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If


            Else
                '================================
                ' Se mostrar Romaneios do Período
                '================================

                Dim fretecalculo As New CalculoFrete
                Dim dsfrete As DataSet

                fretecalculo.id_calculo_frete_execucao = ViewState.Item("id_calculo_frete_execucao")
                fretecalculo.id_estabelecimento = cbo_estabelecimento.SelectedValue
                fretecalculo.id_tipo_frete = cbo_tipofrete.SelectedValue
                fretecalculo.dt_referencia = DateTime.Parse(String.Concat("01/", txt_dt_referencia.Text)).ToString("dd/MM/yyyy")
                fretecalculo.id_frete_periodo = hf_id_frete_periodo.Value
                If chk_calculo_definitivo.Checked = True Then
                    fretecalculo.st_calculo_definitivo = "S"
                Else
                    fretecalculo.st_calculo_definitivo = "N"
                End If

                If cbo_tipofrete.SelectedValue = 2 Then
                    dsfrete = fretecalculo.getCalculoFreteRomaneiosErrosT2

                    gridResults.Visible = False
                    gridromaneios.Visible = False

                    If (dsfrete.Tables(0).Rows.Count > 0) Then
                        lbl_preco_medio.Text = dsfrete.Tables(0).Rows(0).Item("nr_preco_medio_leite")
                        gridromaneiot2.Visible = True
                        gridromaneiot2.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                        gridromaneiot2.DataBind()
                    Else
                        gridromaneiot2.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If

                Else
                    dsfrete = fretecalculo.getCalculoFreteRomaneiosErros

                    gridResults.Visible = False
                    gridromaneiot2.Visible = False

                    If (dsfrete.Tables(0).Rows.Count > 0) Then
                        lbl_preco_medio.Text = dsfrete.Tables(0).Rows(0).Item("nr_preco_medio_leite")
                        gridromaneios.Visible = True
                        gridromaneios.DataSource = Helper.getDataView(dsfrete.Tables(0), "")
                        gridromaneios.DataBind()
                    Else
                        gridromaneios.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If

                End If


            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

        ' adri 03/08/2012- chamado 1577 - Relatórios apoio Themis - f

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadAbaAtiva(ViewState("aba_ativa"))

    End Sub

    Protected Sub gridromaneios_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridromaneios.PageIndexChanging
        gridromaneios.PageIndex = e.NewPageIndex
        loadAbaAtiva(ViewState("aba_ativa"))

    End Sub
End Class
