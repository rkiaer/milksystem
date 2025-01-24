Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_poupanca_liberacao


    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("id_poupanca_parametro") = Me.cbo_referencia_poupanca.SelectedValue
        ViewState.Item("st_participa_fechamento") = Me.cbo_fechamento_poupanca.SelectedValue
        ViewState.Item("id_propriedade_titular") = Me.txt_id_propriedade_titular.Text
        ViewState.Item("id_situacao_adesao") = Me.cbo_situacao_adesao.SelectedValue
        If chk_gruporelacionamento.Checked = True Then
            ViewState.Item("st_apenas_grupo") = "S"
            ViewState.Item("sortExpression") = "id_propriedade_titular, st_relacionamento desc, id_propriedade"
        Else
            ViewState.Item("st_apenas_grupo") = "N"
            ViewState.Item("sortExpression") = "nm_pessoa, id_propriedade"
        End If
        ViewState.Item("consistencia") = cbo_consistencia.SelectedValue

        Dim poupancaparametro As New PoupancaParametro(Convert.ToInt32(Me.cbo_referencia_poupanca.SelectedValue))
        ViewState.Item("id_situacao_poupanca_parametro") = poupancaparametro.id_situacao_poupanca

        ViewState.Item("dt_referencia_ini_poupanca_parametro") = poupancaparametro.dt_referencia_ini
        ViewState.Item("dt_referencia_fim_poupanca_parametro") = poupancaparametro.dt_referencia_fim


        'Limpar qualquer seleção do grid antes de reiniciar pesquisa
        Dim poupancaadesao As New PoupancaAdesao
        poupancaadesao.id_poupanca_parametro = cbo_referencia_poupanca.SelectedValue
        poupancaadesao.st_selecao = "0"
        poupancaadesao.updatePoupancaLiberarSelecaoTodos()


        If gridResults.Rows.Count > 0 Then
            gridResults.DataSource = String.Empty
            gridResults.Visible = False
        End If

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_poupanca_liberacao.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_poupanca_liberacao.aspx")

        If Not Page.IsPostBack Then
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

            Dim estabelecimento As New Estabelecimento
            Dim statusPoupanca As New SituacaoPoupanca

            cbo_situacao_adesao.DataSource = statusPoupanca.getSituacoesPoupancaByFilters()
            cbo_situacao_adesao.DataTextField = "nm_situacao_poupanca"
            cbo_situacao_adesao.DataValueField = "id_situacao_poupanca"
            cbo_situacao_adesao.DataBind()
            cbo_situacao_adesao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'Dim cluster As New Cluster
            'cbo_cluster.DataSource = cluster.getClusterByFilters()
            'cbo_cluster.DataTextField = "nm_cluster"
            'cbo_cluster.DataValueField = "id_cluster"
            'cbo_cluster.DataBind()
            'cbo_cluster.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim bAtivarBotoes As Boolean = True
            Dim poupanca As New PoupancaAdesao
            Dim dspoupancaliberar As DataSet

            poupanca.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro").ToString)
            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                poupanca.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                poupanca.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            poupanca.st_participa_fechamento = ViewState.Item("st_participa_fechamento")
            poupanca.id_situacao_poupanca = ViewState.Item("id_situacao_adesao")
            If Trim(ViewState.Item("id_propriedade_titular")) <> "" Then
                poupanca.id_propriedade_titular = Convert.ToInt32(ViewState.Item("id_propriedade_titular").ToString)
            End If
            'se o check grupo está selecionado
            If ViewState.Item("st_apenas_grupo").ToString.Equals("S") Then
                poupanca.st_relacionamento = "T"
                poupanca.st_relacionamento2 = "A"
            Else
                poupanca.st_relacionamento = String.Empty
                poupanca.st_relacionamento2 = String.Empty
            End If

            Select Case ViewState.Item("id_situacao_adesao").ToString
                Case "2", "3" 'Finalizado OU LIBERADO
                    bAtivarBotoes = False
            End Select

            'Busca dados de acordo com filtro
            dspoupancaliberar = poupanca.getPoupancaLiberarbyAdesaoSelecao

            Select Case ViewState.Item("consistencia").ToString
                Case "1" 'Todos registros cujo participa fechamento é nulo (n~~ao tem registro)
                    dspoupancaliberar = poupanca.getPoupancaLiberarConsFechamentoNulo
                Case "2" '2 prop inativa 
                    dspoupancaliberar = poupanca.getPoupancaLiberarConsPropInativas
                    bAtivarBotoes = False
                Case "3" '3- grupo sem parametros
                    dspoupancaliberar = poupanca.getPoupancaLiberarConsGrupoSemParametro
                    bAtivarBotoes = False
                Case "4" '4 - grupo responsavel inativo
                    dspoupancaliberar = poupanca.getPoupancaLiberarConsGrupoRespInativo
                    bAtivarBotoes = False
            End Select
            If bAtivarBotoes = True Then
                btn_participar_fechamento.Enabled = True
                btn_nao_participar_fechamento.Enabled = True
                Me.gridResults.Columns.Item(0).Visible = True 'coluna de seleção
            Else
                btn_participar_fechamento.Enabled = False
                btn_nao_participar_fechamento.Enabled = False
                Me.gridResults.Columns.Item(0).Visible = False 'coluna de seleção
            End If
            'independente da pesquisa, se situacao parametro ja estiver liberada ou finalizada
            Select Case ViewState.Item("id_situacao_poupanca_parametro").ToString
                Case "2", "3" 'Finalizado OU LIBERADO
                    lk_liberar.Enabled = False
                    btn_participar_fechamento.Enabled = False
                    btn_participar_fechamento.ToolTip = "Participar do Fechamento Poupança - Desabilitado pois Status Poupança é diferente de aberto."
                    btn_nao_participar_fechamento.Enabled = False
                    btn_nao_participar_fechamento.ToolTip = "Não Participar do Fechamento Poupança - Desabilitado pois Status Poupança é diferente de aberto."
                    Me.gridResults.Columns.Item(0).Visible = False 'coluna de seleção
            End Select

            If (dspoupancaliberar.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dspoupancaliberar.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        'saveCheckBox()
        loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "id_unid_producao"
                If (ViewState.Item("sortExpression")) = "id_unid_producao asc" Then
                    ViewState.Item("sortExpression") = "id_unid_producao desc"
                Else
                    ViewState.Item("sortExpression") = "id_unid_producao asc"
                End If


            Case "dt_coleta"
                If (ViewState.Item("sortExpression")) = "dt_coleta asc" Then
                    ViewState.Item("sortExpression") = "dt_coleta desc"
                Else
                    ViewState.Item("sortExpression") = "dt_coleta asc"
                End If


            Case "dt_processamento"
                If (ViewState.Item("sortExpression")) = "dt_processamento asc" Then
                    ViewState.Item("sortExpression") = "dt_processamento desc"
                Else
                    ViewState.Item("sortExpression") = "dt_processamento asc"
                End If

            Case "dt_analise"
                If (ViewState.Item("sortExpression")) = "dt_analise asc" Then
                    ViewState.Item("sortExpression") = "dt_analise desc"
                Else
                    ViewState.Item("sortExpression") = "dt_analise asc"
                End If

            Case "ds_analise_esalq"
                If (ViewState.Item("sortExpression")) = "ds_analise_esalq asc" Then
                    ViewState.Item("sortExpression") = "ds_analise_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "ds_analise_esalq asc"
                End If

            Case "nr_valor_esalq"
                If (ViewState.Item("sortExpression")) = "nr_valor_esalq asc" Then
                    ViewState.Item("sortExpression") = "nr_valor_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "nr_valor_esalq asc"
                End If

            Case "nr_media_mg"
                If (ViewState.Item("sortExpression")) = "nr_media_mg asc" Then
                    ViewState.Item("sortExpression") = "nr_media_mg desc"
                Else
                    ViewState.Item("sortExpression") = "nr_media_mg asc"
                End If

            Case "nr_variacao_mg"
                If (ViewState.Item("sortExpression")) = "nr_variacao_mg asc" Then
                    ViewState.Item("sortExpression") = "nr_variacao_mg desc"
                Else
                    ViewState.Item("sortExpression") = "nr_variacao_mg asc"
                End If


            Case "nm_aprovacao_analise_esalq"
                If (ViewState.Item("sortExpression")) = "nm_aprovacao_analise_esalq asc" Then
                    ViewState.Item("sortExpression") = "nm_aprovacao_analise_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "nm_aprovacao_analise_esalq asc"
                End If

            Case "id_tipo_coleta_analise_esalq"
                If (ViewState.Item("sortExpression")) = "id_tipo_coleta_analise_esalq asc" Then
                    ViewState.Item("sortExpression") = "id_tipo_coleta_analise_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "id_tipo_coleta_analise_esalq asc"
                End If
            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If

        End Select

        loadData()

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
    Private Sub carregarCamposPropriedade()

        Try

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If

            Me.txt_cd_propriedade.Text = Me.hf_id_propriedade.Value.ToString

            If Not (customPage.getFilterValue("lupa_propriedade", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "cd_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Visible = True
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_propriedade", "id_pessoa").Equals(String.Empty)) Then
                Me.hf_id_pessoa.Value = customPage.getFilterValue("lupa_propriedade", "id_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_id_poupanca_adesao As Label = CType(e.Row.FindControl("lbl_id_poupanca_adesao"), Label)
            Dim lbl_id_situacao_poupanca As Label = CType(e.Row.FindControl("lbl_id_situacao_poupanca"), Label)
            Dim lbl_id_situacao_propriedade As Label = CType(e.Row.FindControl("lbl_id_situacao_propriedade"), Label)
            Dim lbl_id_propriedade_titular As Label = CType(e.Row.FindControl("lbl_id_propriedade_titular"), Label)
            Dim lbl_st_participa_fechamento As Label = CType(e.Row.FindControl("lbl_st_participa_fechamento"), Label)
            Dim lbl_st_participa_poupanca As Label = CType(e.Row.FindControl("lbl_st_participa_poupanca"), Label)
            Dim chk_item As CheckBox = CType(e.Row.FindControl("ck_item"), CheckBox)

            chk_item.Enabled = True
            chk_item.ToolTip = String.Empty

            If Me.gridResults.Columns.Item(0).Visible = True Then 'se coluna selecao
                'se esta finalizado ou liberado
                If lbl_id_situacao_poupanca.Text.Equals("3") OrElse lbl_id_situacao_poupanca.Text.Equals("2") Then
                    chk_item.Enabled = False
                    chk_item.ToolTip = "Não pode ser selecionado. Status da adesão é diferente de aberto."
                End If
                'se esta prop inativa
                If lbl_id_situacao_propriedade.Text.Equals("2") Then
                    chk_item.Enabled = False
                    chk_item.ToolTip = "Não pode ser selecionado. Propriedade Inativa."
                End If
                'se os parametros de poupanca para grupo de relacionamento nao foram informados
                If (Not lbl_id_propriedade_titular.Text.Equals(String.Empty)) AndAlso lbl_st_participa_poupanca.Text.Equals(String.Empty) Then
                    chk_item.Enabled = False
                    chk_item.ToolTip = "Não pode ser selecionado. Parâmetros de Poupança para Grupo de Relacionamento devem ser informados."
                End If
            End If

        End If
    End Sub


    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        If cbo_estabelecimento.SelectedValue <> "0" Then
            cbo_referencia_poupanca.Enabled = True

            Dim poupancaparametro As New PoupancaParametro

            poupancaparametro.id_estabelecimento = cbo_estabelecimento.SelectedValue
            poupancaparametro.situacao = "1|3" 'aberto e liberado

            cbo_referencia_poupanca.DataSource = poupancaparametro.getPoupancaParametrobySituacao()
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

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()
    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged

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

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        If Me.cbo_estabelecimento.SelectedValue <> "0" Then
            Me.lbl_nm_propriedade.Visible = True
            carregarCamposPropriedade()
        End If
    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
        lbl_nm_propriedade.Text = ""
        lbl_nm_propriedade.Visible = False

    End Sub


    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                If ch.Enabled = True Then
                    ch.Checked = ck_header.Checked
                End If
            Next

            ' Seleciona tudo o que o botão Pesquisar trouxer - i
            Dim poupanca As New PoupancaAdesao

            poupanca.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro").ToString)
            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                poupanca.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                poupanca.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            poupanca.st_participa_fechamento = ViewState.Item("st_participa_fechamento")
            poupanca.id_situacao_poupanca = ViewState.Item("id_situacao_adesao")
            If Trim(ViewState.Item("id_propriedade_titular")) <> "" Then
                poupanca.id_propriedade_titular = Convert.ToInt32(ViewState.Item("id_propriedade_titular").ToString)
            End If
            'se o check grupo está selecionado
            If ViewState.Item("st_apenas_grupo").ToString.Equals("S") Then
                poupanca.st_relacionamento = "T"
                poupanca.st_relacionamento2 = "A"
            Else
                poupanca.st_relacionamento = String.Empty
                poupanca.st_relacionamento2 = String.Empty
            End If

            If ck_header.Checked = True Then
                poupanca.st_selecao = "1"
            Else
                poupanca.st_selecao = "0"
            End If

            If ViewState.Item("consistencia").ToString.Equals("1") Then
                poupanca.updatePoupancaLiberarSelecaoTodasFechamentoNulo()
            Else
                poupanca.updatePoupancaLiberarSelecaoTodos()
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_liberar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_liberar.Click
        Try
            If Page.IsValid Then

                Dim poupanca As New PoupancaAdesao
                poupanca.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro"))
                poupanca.id_modificador = Session("id_login")

                poupanca.updatePoupancaLiberar()

                poupanca.dt_referencia_ini = ViewState.Item("dt_referencia_ini_poupanca_parametro")
                poupanca.dt_referencia_fim = ViewState.Item("dt_referencia_fim_poupanca_parametro")
                poupanca.updatePoupancaAdesaoValoresBonus()

                loadData()

                messageControl.Alert("Os registros de adesão que participam do fechamento da poupança foram liberados com sucesso!")

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_participar_fechamento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_participar_fechamento.Click
        Try
            If Page.IsValid Then

                Dim poupancaadesao As New PoupancaAdesao

                poupancaadesao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
                poupancaadesao.st_participa_fechamento = "S"
                poupancaadesao.id_modificador = Session("id_login")

                poupancaadesao.updatePoupancaLiberarParticiparFechamentoSelecionadas()

                loadData()

                messageControl.Alert("Participação no Fechamento de Poupança confirmada com sucesso.")

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub btn_nao_participar_fechamento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nao_participar_fechamento.Click
        Try
            If Page.IsValid Then

                Dim poupancaadesao As New PoupancaAdesao

                poupancaadesao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
                poupancaadesao.st_participa_fechamento = "N"
                poupancaadesao.id_modificador = Session("id_login")

                poupancaadesao.updatePoupancaLiberarParticiparFechamentoSelecionadas()

                loadData()

                messageControl.Alert("Não Participação no Fechamento de Poupança confirmada com sucesso.")

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub


    Protected Sub ck_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim chk_selec As CheckBox

            chk_selec = CType(sender, CheckBox)

            '' Seleciona o item selecionado
            Dim poupanca As New PoupancaAdesao

            poupanca.id_poupanca_adesao = Convert.ToInt32(gridResults.DataKeys.Item(row.RowIndex).Value)
            If chk_selec.Checked = True Then
                poupanca.st_selecao = "1"
            Else
                poupanca.st_selecao = "0"
            End If
            poupanca.updatePoupancaLiberarSelecao()

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try


    End Sub

    Protected Sub cvliberar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvliberar.ServerValidate
        Try
            If Page.IsValid = True Then

                Dim lmsg As String
                Dim poupanca As New PoupancaAdesao
                Dim dspoupancacons As DataSet

                poupanca.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro"))
                poupanca.id_situacao_poupanca = 1 'em aberto
                poupanca.id_situacao = 1 'em aberto situacao propriedade

                args.IsValid = True

                'CONSISTE REGISTROS CUJO FECHAMENTO NAO TENHA SIDO REALIZADO (st_participa_fechamento informado)
                dspoupancacons = poupanca.getPoupancaLiberarConsFechamentoNulo
                If dspoupancacons.Tables(0).Rows.Count > 0 Then
                    args.IsValid = False
                    lmsg = "A Liberação não pode ser efetuada. Há registros que ainda não tem a indicação de participação no fechamento da poupancça."
                End If

                'CONSISTE REGISTROS CUJO GRUPO REALACIONAMENTO NÂO TEM PARAMETROS DE POUPANCA CADASTRADO
                dspoupancacons = poupanca.getPoupancaLiberarConsGrupoSemParametro
                If dspoupancacons.Tables(0).Rows.Count > 0 Then
                    args.IsValid = False
                    lmsg = "A Liberação não pode ser efetuada. Há registros de Grupo de Relacionamento sem os parâmetros de poupança."
                End If

                'CONSISTE REGISTROS GRUPO REALACIONAMENTO esta com o responsabvel pelo bonus inativo
                dspoupancacons = poupanca.getPoupancaLiberarConsGrupoRespInativo
                If dspoupancacons.Tables(0).Rows.Count > 0 Then
                    args.IsValid = False
                    lmsg = "A Liberação não pode ser efetuada. Há registros de Grupo de Relacionamento cuja propriedade responsável pelo bônus está inativa."
                End If


                If Not args.IsValid Then
                    messageControl.Alert(lmsg)
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cvparticiparfechamento_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvparticiparfechamento.ServerValidate
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

                If Not args.IsValid Then
                    messageControl.Alert(lmsg)
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class
