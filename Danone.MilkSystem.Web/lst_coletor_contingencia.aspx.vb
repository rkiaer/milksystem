Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class lst_coletor_contingencia

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("dt_coleta") = Me.txt_dt_coleta.Text()
        ViewState.Item("cd_cnh") = Me.txt_cnh.Text
        ViewState.Item("ds_placa") = Me.txt_placa.Text
        ViewState.Item("ds_placa_julieta") = Me.txt_placa_julieta.Text
        ViewState.Item("st_tipo_rota") = Me.cbo_tipo_rota.SelectedValue
        ViewState.Item("nm_linha") = Me.txt_nm_linha.Text   ' 15/09/2009 - Rls21 Frete

        If Page.IsValid Then  ' 15/09/2009 - Rls21 Frete (não estava verificando se a placa é válida)
            If insertData() = True Then
                loadData()
            End If
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_coletor_contingencia.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_AbortTransaction(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AbortTransaction

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_coletor_contingencia.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 15
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With bt_lupa_veiculo
            .Attributes.Add("onclick", "javascript:ShowDialogVeiculo()")
            .ToolTip = "Filtrar Veículos"
        End With

        ' Rls21 - Frete - i
        With lk_alterarplaca
            .Attributes.Add("onclick", "javascript:ShowDialogAlterarPlaca()")
            .ToolTip = "Alterar Placa"
        End With
        ' Rls21 - Frete - f

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao


            cbo_tipo_rota.Items.Add(New ListItem("Ímpar", "1"))
            cbo_tipo_rota.Items.Add(New ListItem("Par", "2"))

            ViewState.Item("sortExpression") = "nr_ordem asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("coletor_contingencia", txt_dt_coleta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_coleta") = customPage.getFilterValue("coletor_contingencia", txt_dt_coleta.ID)
            txt_dt_coleta.Text = ViewState.Item("dt_coleta").ToString()
        Else
            ViewState.Item("dt_coleta") = String.Empty
        End If

        If Not (customPage.getFilterValue("coletor_contingencia", Me.txt_cnh.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_cnh") = customPage.getFilterValue("coletor_contingencia", txt_cnh.ID)
            txt_cnh.Text = ViewState.Item("cd_cnh").ToString()
        Else
            ViewState.Item("cd_cnh") = String.Empty
        End If

        If Not (customPage.getFilterValue("coletor_contingencia", Me.txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("coletor_contingencia", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If

        If Not (customPage.getFilterValue("coletor_contingencia", Me.txt_placa_julieta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa_julieta") = customPage.getFilterValue("coletor_contingencia", txt_placa_julieta.ID)
            txt_placa_julieta.Text = ViewState.Item("ds_placa_julieta").ToString()
        Else
            ViewState.Item("ds_placa_julieta") = String.Empty
        End If

        If Not (customPage.getFilterValue("coletor_contingencia", cbo_tipo_rota.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("st_tipo_rota") = customPage.getFilterValue("coletor_contingencia", cbo_tipo_rota.ID)
            Me.cbo_tipo_rota.Text = ViewState.Item("st_tipo_rota").ToString()
        Else
            ViewState.Item("st_tipo_rota") = String.Empty
        End If

        ' 15/09/2009 - Rls21 Frete - i
        If Not (customPage.getFilterValue("coletor_contingencia", Me.txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_linha") = customPage.getFilterValue("coletor_contingencia", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_linha").ToString()
        Else
            ViewState.Item("nm_linha") = String.Empty
        End If
        ' 15/09/2009 - Rls21 Frete - f

        If Not (customPage.getFilterValue("coletor_contingencia", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("coletor_contingencia", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("coletor_contingencia")
        End If

    End Sub
    Private Function insertData() As Boolean
        Try

            Dim caderneta As New Caderneta
            caderneta.dt_coleta = ViewState.Item("dt_coleta")
            caderneta.cd_transportador = ViewState.Item("cd_cnh")
            caderneta.ds_placa = ViewState.Item("ds_placa")
            caderneta.dia_impar_par = ViewState.Item("st_tipo_rota")
            If ViewState.Item("ds_placa_julieta") <> "" Then
                caderneta.ds_placa_julieta = ViewState.Item("ds_placa_julieta")
            End If
            caderneta.nm_linha = ViewState.Item("nm_linha")  ' 15/09/2009 - Rls 21 Frete

            insertData = True

            'Verifica se a caderneta já foi transmitida para a Data/Placa/Motorista
            Dim dsRoteiroTransmitido = caderneta.getRoteiroTransmitidoContingencia()
            If (dsRoteiroTransmitido.Tables(0).Rows.Count > 0) Then  ' Se já foi transmitido
                messageControl.Alert("A caderneta para a Data/Placa/Rota já foi transmitida . Utilize o menu Visualizar Cadernetas para visualizar os dados.")
                insertData = False
            Else
                Dim dsRoteiro As DataSet = caderneta.getRoteiroContingencia()
                If Not (dsRoteiro.Tables(0).Rows.Count > 0) Then  ' Se ainda nao tem caderneta para a data/placa/rota com id_situcao_coleta=6
                    '' 15/09/2009 - Rls 21 Frete - i
                    'Dim linha As New Linha
                    'linha.nm_linha = ViewState.Item("nm_linha")
                    'Dim dsLinha As DataSet = linha.getLinhaByFilters()
                    'If (dsLinha.Tables(0).Rows.Count > 0) Then
                    '    If Not IsDBNull(dsLinha.Tables(0).Rows(0).Item("ds_placa")) <> ViewState.Item("ds_placa") Then
                    '        ' mesnagem de aviso com confirmação ????  (não temos como resolver!!!)
                    '    End If
                    'End If
                    '' 15/09/2009 - Rls 21 Frete - f
                    caderneta.loadColetasContingencia()

                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 15
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango
                End If
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Function

    Private Sub loadData()

        Try
            Dim caderneta As New Caderneta

            pnl_roteiro.Visible = True
            Panel5.Visible = True

            caderneta.dt_coleta = ViewState.Item("dt_coleta")
            caderneta.cd_transportador = ViewState.Item("cd_cnh")
            caderneta.ds_placa = ViewState.Item("ds_placa")
            caderneta.dia_impar_par = ViewState.Item("st_tipo_rota")
            If ViewState.Item("ds_placa_julieta") <> "" Then
                caderneta.ds_placa_julieta = ViewState.Item("ds_placa_julieta")
            End If
            caderneta.nm_linha = ViewState.Item("nm_linha")  ' 15/09/2009 - Rls 21 Frete

            Dim dsRoteiro As DataSet = caderneta.getRoteiroContingencia()

            If (dsRoteiro.Tables(0).Rows.Count > 0) Then
                gridRoteiro.Visible = True
                btn_adicionar_propriedade.Enabled = True
                gridRoteiro.DataSource = Helper.getDataView(dsRoteiro.Tables(0), ViewState.Item("sortExpression"))
                gridRoteiro.DataBind()

                ' 13/02/2009 - Rls16 - i
                caderneta.currentidentity = dsRoteiro.Tables(0).Rows(0).Item("currentidentity")
                lbl_total_litros.Text = FormatNumber(caderneta.getCadernetaTotalLitros, 0)
                ViewState.Item("currentidentity") = caderneta.currentidentity       ' Salva o N.o da Caderneta
                ' 13/02/2009 - Rls16 - f

                ' 23/09/2009 - Rls21 - Frete - i (Busca a placa alterada)
                caderneta.currentidentity = ViewState.Item("currentidentity")
                Me.hf_currentidentity.Value = Convert.ToInt32(ViewState.Item("currentidentity"))
                Dim dsCaderneta As DataSet = caderneta.getCadernetaPlacaFreteContingencia()
                If Not IsDBNull(dsCaderneta.Tables(0).Rows(0).Item("ds_placa_frete")) Then
                    lbl_placa_frete.Text = dsCaderneta.Tables(0).Rows(0).Item("ds_placa_frete")
                Else
                    lbl_placa_frete.Text = ""
                End If
                ' 23/09/2009 - Rls21 - Frete - f

                ' Rls21 - Frete - i
                Me.hl_alterarplaca.NavigateUrl = String.Format("frm_coletor_alterarplaca.aspx?currentidentity={0}", caderneta.currentidentity)
                Me.hl_alterarplaca.Enabled = True
                ' Rls21 - Frete - f

            Else
                gridRoteiro.Visible = False
                btn_adicionar_propriedade.Enabled = False
                Me.hl_alterarplaca.Enabled = False  ' Rls21 - Frete
                messageControl.Alert("Não foi possível carregar os dados. Verifique se existe Rota cadastrada para a Placa ou se a(s) Placa(s), Compartimento(s) e Motorista estão cadastrados no sistema.")
            End If


            Dim dsColetas As DataSet = caderneta.getColetasContingencia()

            If (dsColetas.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsColetas.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            End If

            Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_caderneta.aspx?dt_coleta={0}", ViewState.Item("dt_coleta")) & String.Format("&cd_cnh={0}", ViewState.Item("cd_cnh")) & String.Format("&ds_placa={0}", ViewState.Item("ds_placa")) & String.Format("&tipo_rota={0}", ViewState.Item("st_tipo_rota"))
            Me.hl_imprimir.Enabled = True



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

            Case "nr_ordem"
                If (ViewState.Item("sortExpression")) = "nr_ordem asc" Then
                    ViewState.Item("sortExpression") = "nr_ordem desc"
                Else
                    ViewState.Item("sortExpression") = "nr_ordem asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub carregarCamposVeiculo()

        Try

            If Not (customPage.getFilterValue("lupa_veiculo", "ds_placa").Equals(String.Empty)) Then
                Me.txt_placa.Text = customPage.getFilterValue("lupa_veiculo", "ds_placa").ToString
            End If

            customPage.clearFilters("lupa_veiculo")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try

            customPage.setFilter("coletor_contingencia", txt_dt_coleta.ID, ViewState.Item("dt_coleta").ToString)
            customPage.setFilter("coletor_contingencia", txt_cnh.ID, ViewState("cd_cnh").ToString)
            customPage.setFilter("coletor_contingencia", txt_placa.ID, ViewState("ds_placa").ToString)
            customPage.setFilter("coletor_contingencia", txt_placa_julieta.ID, ViewState("ds_placa_julieta").ToString)
            customPage.setFilter("coletor_contingencia", cbo_tipo_rota.ID, ViewState.Item("st_tipo_rota").ToString)
            customPage.setFilter("coletor_contingencia", txt_nm_linha.ID, ViewState("nm_linha").ToString)  ' 15/09/2009 - Rls21 Frete
            customPage.setFilter("coletor_contingencia", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub bt_lupa_veiculo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_veiculo.Click

        carregarCamposVeiculo()

    End Sub

    Protected Sub cmv_placa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_placa.ServerValidate
        Try
            Dim veiculo As New Veiculo()

            veiculo.ds_placa = txt_placa.Text
            args.IsValid = veiculo.validarPlaca()
            If Not args.IsValid Then
                messageControl.Alert("Placa não cadastrada.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridResults.RowCancelingEdit
        Try

            gridResults.EditIndex = -1
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
     Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
    End Sub
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound


    End Sub

    Protected Sub gridRoteiro_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridRoteiro.PageIndexChanging
        gridRoteiro.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridRoteiro_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridRoteiro.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                ' 16/02/2009 - Rls16 - i
                'Response.Redirect("frm_coletor_contingencia.aspx?id_coleta=" + e.CommandArgument.ToString() )
                Response.Redirect("frm_coletor_contingencia.aspx?id_coleta=" + e.CommandArgument.ToString() + "&currentidentity=" + ViewState.Item("currentidentity").ToString)
                ' 16/02/2009 - Rls16 - f

        End Select

    End Sub

    Protected Sub lk_transmitir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_transmitir.Click
        Try

            Dim caderneta As New Caderneta
            Dim nr_caderneta As Int32   ' 13/02/3009 - Rls16

            caderneta.dt_coleta = ViewState.Item("dt_coleta")
            caderneta.cd_transportador = ViewState.Item("cd_cnh")
            caderneta.ds_placa = ViewState.Item("ds_placa")
            caderneta.dia_impar_par = ViewState.Item("st_tipo_rota")
            If ViewState.Item("ds_placa_julieta") <> "" Then
                caderneta.ds_placa_julieta = ViewState.Item("ds_placa_julieta")
            End If
            caderneta.nm_linha = ViewState.Item("nm_linha")  ' 15/09/2009 - Rls21 Frete

            Dim dsColetaPendente As DataSet = caderneta.getColetaPendenteContingencia()

            If (dsColetaPendente.Tables(0).Rows.Count > 0) Then  ' Se tem coletas pendentes
                messageControl.Alert("Existem coletas pendentes. A transmissão não poderá ser realizada.")
            Else
                ' 13/02/3009 - Rls16 - Obtem n.o da caderenta - i
                'Verifica se a caderneta já foi transmitida para a Data/Placa/Motorista
                nr_caderneta = 0
                Dim dsRoteiro = caderneta.getRoteiroContingencia
                If (dsRoteiro.Tables(0).Rows.Count > 0) Then
                    nr_caderneta = dsRoteiro.Tables(0).Rows(0).Item("currentidentity")
                End If
                ' 13/02/3009 - Rls16 - Obtem n.o da caderenta - f

                caderneta.transmitir()

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 15
                usuariolog.ds_nm_processo = "Criar Cadernetas - Transmitir"
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                gridRoteiro.Enabled = False
                messageControl.Alert("A caderneta N.o " & nr_caderneta & " foi transmitida com sucesso. Utilize o menu Visualizar Cadernetas para visualizar os dados.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub


    Protected Sub btn_adicionar_propriedade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar_propriedade.Click
        Try

            If Trim(txt_propriedade.Text) <> "" And Trim(txt_unidade_producao.Text <> "") Then
                Dim caderneta As New Caderneta
                Dim lrow As Int16
                caderneta.dt_coleta = ViewState.Item("dt_coleta")
                caderneta.cd_transportador = ViewState.Item("cd_cnh")
                caderneta.ds_placa = ViewState.Item("ds_placa")
                caderneta.dia_impar_par = ViewState.Item("st_tipo_rota")
                If ViewState.Item("ds_placa_julieta") <> "" Then
                    caderneta.ds_placa_julieta = ViewState.Item("ds_placa_julieta")
                End If
                caderneta.nm_linha = ViewState.Item("nm_linha")  ' 15/09/2009 - Rls21 Frete


                Dim dsRoteiro As DataSet = caderneta.getRoteiroContingencia()

                If (dsRoteiro.Tables(0).Rows.Count > 0) Then
                    lrow = dsRoteiro.Tables(0).Rows.Count - 1
                    caderneta.id_linha = dsRoteiro.Tables(0).Rows(lrow).Item("id_linha")
                    caderneta.id_linha_item = dsRoteiro.Tables(0).Rows(lrow).Item("id_linha_item")
                    caderneta.nm_linha = dsRoteiro.Tables(0).Rows(lrow).Item("nm_linha")
                    caderneta.cd_transportador = dsRoteiro.Tables(0).Rows(lrow).Item("cd_transportador")
                    caderneta.nm_transportador = dsRoteiro.Tables(0).Rows(lrow).Item("nm_transportador")
                    caderneta.cd_transportador2 = dsRoteiro.Tables(0).Rows(lrow).Item("cd_transportador2")
                    caderneta.nm_transportador2 = dsRoteiro.Tables(0).Rows(lrow).Item("nm_transportador2")
                    caderneta.nr_unid_producao = Trim(txt_unidade_producao.Text)
                    caderneta.id_propriedade = Trim(txt_propriedade.Text)
                    caderneta.id_motivo_nao_coleta = 0
                    caderneta.id_motivo_desvio = 0
                    caderneta.nr_ordem = Convert.ToInt32(dsRoteiro.Tables(0).Rows(lrow).Item("nr_ordem") + 1)
                    caderneta.id_situacao_coleta = 6        ' 6 - Contingência
                    caderneta.currentidentity = dsRoteiro.Tables(0).Rows(lrow).Item("currentidentity")
                    caderneta.ds_placa_julieta = ViewState.Item("ds_placa_julieta")
                    ' 13/02/2009 - Rls16 - i
                    Dim dsColetaNaoProgramada As DataSet = caderneta.getColetaNaoProgramadaContingencia
                    If dsColetaNaoProgramada.Tables(0).Rows.Count > 0 Then  ' Se a propriedade/Up já existe 
                        messageControl.Alert("A Propriedade/Unidade Produção já existe para esta caderneta!")
                    Else
                        ' 13/02/2009 - Rls16 - f
                        caderneta.insertColetaNaoProgramadaContingencia() ' Rls16 (verifica se a propriedade está ATIVA)
                        txt_propriedade.Text = ""
                        txt_unidade_producao.Text = ""
                        loadData()
                        messageControl.Alert("A Propriedade foi incluída com sucesso.")
                    End If
                End If
            Else
                messageControl.Alert("Propriedade e Unidade de Produção devem ser informadas.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_alterarplaca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_alterarplaca.Click
        ' Rls 21 - Frete - i
        If Not (hf_ds_placa_frete.Value.Trim.Equals(String.Empty)) Then
            Me.lbl_placa_frete.Visible = True
            Me.lbl_placa_frete.Text = hf_ds_placa_frete.Value

        End If
        ' Rls 21 - Frete - f

    End Sub
End Class
