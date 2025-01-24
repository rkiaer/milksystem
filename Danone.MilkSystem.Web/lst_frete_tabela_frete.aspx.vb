Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data
Partial Class lst_frete_tabela_frete

    Inherits Page

    Private customPage As RK.PageTools.CustomPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_frete_tabela_frete.aspx")
        If Not Page.IsPostBack Then
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

            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            gridDetalhe.Visible = False
            gridResults.Visible = False
            pnl_detalhes.Visible = False


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadgridfrete()

        Try

            Dim freteexecucao As New ExportacaoFreteExecucao
            freteexecucao.id_exportacao_frete_execucao = Convert.ToInt32(ViewState.Item("id_frete_execucao"))
            Dim dsfreteexecucao As DataSet = freteexecucao.getExportacaoFreteExecucaoByFilters
            If (dsfreteexecucao.Tables(0).Rows.Count > 0) Then
                'ViewState.Item("status_execucao") = dsfreteexecucao.Tables(0).Rows(0).Item("st_exportacao_frete_execucao")
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsfreteexecucao.Tables(0), "")
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadgridfreteerro()

        Try

            Dim freteexecucao As New ExportacaoFreteExecucao
            freteexecucao.id_exportacao_frete_execucao = Convert.ToInt32(ViewState.Item("id_frete_execucao"))
            Dim dsfreteexecucao As DataSet = freteexecucao.getExportacaoFreteExecucaoErrosByFilters
            If (dsfreteexecucao.Tables(0).Rows.Count > 0) Then
                gridDetalhe.Visible = True
                gridDetalhe.DataSource = Helper.getDataView(dsfreteexecucao.Tables(0), "")
                gridDetalhe.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    'Private Sub exportData()

    '    Try

    '        Dim romaneio As New Romaneio
    '        Dim execucaofrete As New ExportacaoFreteExecucao
    '        Dim dsFreteRomaneio As DataSet

    '        romaneio.st_exportacao_frete = ViewState.Item("st_exportacao_frete") 'fran 20/12/2009 i
    '        romaneio.id_estabelecimento = ViewState.Item("id_estabelecimento")
    '        'fran 03/2017 i 
    '        'romaneio.dt_hora_entrada_ini = ViewState.Item("dt_inicio").ToString
    '        'romaneio.dt_hora_entrada_fim = ViewState.Item("dt_fim").ToString
    '        romaneio.dt_hora_saida_ini = ViewState.Item("dt_inicio").ToString
    '        romaneio.dt_hora_saida_fim = ViewState.Item("dt_fim").ToString
    '        'fran 03/2017 f

    '        romaneio.path_arquivofrete = ViewState.Item("caminho_arquivo")
    '        'If Not txt_id_romaneio.Text.Trim.Equals(String.Empty) Then
    '        '    romaneio.id_romaneio = txt_id_romaneio.Text
    '        'End If

    '        'frsn 03/2017 i 
    '        'se arquivo de cooperativas
    '        If ViewState.Item("st_cooperativas").Equals("S") Then
    '            dsFreteRomaneio = romaneio.getFreteRomaneioCooperativaByTransportadora
    '        Else
    '            dsFreteRomaneio = romaneio.getFreteRomaneioByTransportadora
    '        End If

    '        'Se tem linhas 
    '        'If (romaneio.getFreteRomaneioByTransportadora).Tables(0).Rows.Count > 0 Then fran 03/2017
    '        If dsFreteRomaneio.Tables(0).Rows.Count > 0 Then
    '            execucaofrete.id_estabelecimento_filtro = ViewState.Item("id_estabelecimento")
    '            execucaofrete.dt_ini_filtro = ViewState.Item("dt_inicio").ToString
    '            execucaofrete.dt_fim_filtro = ViewState.Item("dt_fim").ToString
    '            execucaofrete.st_exportacao_frete = ViewState.Item("st_exportacao_frete") 'fran 20/12/2009
    '            execucaofrete.st_cooperativas = ViewState.Item("st_cooperativas") 'fran 20/12/2009

    '            'If Not txt_id_romaneio.Text.Trim.Equals(String.Empty) Then
    '            '    execucaofrete.id_romaneio_filtro = txt_id_romaneio.Text
    '            'End If
    '            'romaneio.id_exportacao_frete_execucao = execucaofrete.insertExportacaoFreteExecucao()
    '            'lbl_status.Visible = False
    '            'lbl_id_exportacao_frete_execucao.Visible = False
    '            'lbl_nr_execucao.Visible = False
    '            'lbl_status_execucao.Visible = False
    '            gridResults.Visible = False
    '            gridDetalhe.Visible = False
    '            If romaneio.id_exportacao_frete_execucao = 0 Then
    '                messageControl.Alert("Para esta seleção, todos os registros já foram exportados. Por favor tente novamente.")
    '                'pnl_tela2.Visible = False
    '                'pnl_tela1.Visible = False

    '            Else

    '                ViewState.Item("id_frete_execucao") = romaneio.id_exportacao_frete_execucao
    '                If romaneio.exportFrete() = True Then
    '                    Dim exportacaoerros As New ExportacaoFreteExecucao
    '                    exportacaoerros.id_exportacao_frete_execucao = Convert.ToInt32(ViewState.Item("id_frete_execucao").ToString)
    '                    If exportacaoerros.getExportacaoFreteExecucaoErrosByFilters.Tables(0).Rows.Count > 0 Then
    '                        'messageControl.Alert("Exportação de Frete finalizada com inconsistências.")
    '                        'pnl_tela2.Visible = True
    '                        'pnl_tela1.Visible = True
    '                        'Me.btn_erros.Visible = True
    '                    Else
    '                        messageControl.Alert("Exportação de Frete realizada com Sucesso.")
    '                        'pnl_tela2.Visible = False
    '                        'pnl_tela1.Visible = True

    '                    End If
    '                Else
    '                    messageControl.Alert("Exportação de Frete realizada com erros. O período selecionado não foi finalizado completamente.")
    '                    'pnl_tela2.Visible = True
    '                    'pnl_tela1.Visible = True
    '                    'Me.btn_erros.Visible = True
    '                    'Me.btn_erros.CommandArgument = .Item("id_romaneio_placa")
    '                End If
    '                ViewState.Item("tela_ativa") = 0 'Assume que a tela ativa é a da 1a aba
    '                gridResults.Visible = True
    '                'lbl_nr_execucao.Visible = True
    '                'lbl_id_exportacao_frete_execucao.Visible = True
    '                'lbl_id_exportacao_frete_execucao.Text = ViewState.Item("id_frete_execucao").ToString
    '                'lbl_status.Visible = True
    '                'lbl_status_execucao.Visible = True
    '                execucaofrete.id_exportacao_frete_execucao = Convert.ToInt32(ViewState.Item("id_frete_execucao").ToString)
    '                ViewState.Item("st_exportacao_frete_execucao") = execucaofrete.getExportacaoFreteExecucaoByFilters.Tables(0).Rows(0).Item("st_exportacao_frete_execucao").ToString
    '                'If ViewState.Item("st_exportacao_frete_execucao").ToString.Trim = "I" Then
    '                '    lbl_status_execucao.Text = "Iniciada"
    '                'Else
    '                '    If ViewState.Item("st_exportacao_frete_execucao").ToString.Trim = "F" Then
    '                '        lbl_status_execucao.Text = "Finalizada"
    '                '    Else
    '                '        lbl_status_execucao.Text = "Com Erros"
    '                '    End If

    '                'End If
    '                loadabas()
    '            End If
    '        Else
    '            messageControl.Alert("Nenhum registro foi encontrado para exportação. Por favor tente novamente.")
    '        End If


    '        '            lbl_totallidas.Text = romaneio.nr_linhaslidas
    '        '           lbl_totallinhas.Text = romaneio.nr_linhasexportadas


    '    Catch ex As Exception
    '        'pnl_tela2.Visible = True
    '        'pnl_tela1.Visible = True
    '        'Me.btn_erros.Visible = True
    '        ViewState.Item("tela_ativa") = 0 'Assume que a tela ativa é a da 1a aba
    '        gridResults.Visible = True
    '        'lbl_nr_execucao.Visible = True
    '        'lbl_id_exportacao_frete_execucao.Visible = True
    '        'lbl_id_exportacao_frete_execucao.Text = ViewState.Item("id_frete_execucao").ToString
    '        'lbl_status.Visible = True
    '        'lbl_status_execucao.Visible = True
    '        'Dim execucaofrete As New ExportacaoFreteExecucao
    '        'execucaofrete.id_exportacao_frete_execucao = Convert.ToInt32(ViewState.Item("id_frete_execucao").ToString)
    '        'ViewState.Item("st_exportacao_frete_execucao") = execucaofrete.getExportacaoFreteExecucaoByFilters.Tables(0).Rows(0).Item("st_exportacao_frete_execucao").ToString
    '        'If ViewState.Item("st_exportacao_frete_execucao").ToString.Trim = "I" Then
    '        '    lbl_status_execucao.Text = "Iniciada"
    '        'Else
    '        '    If ViewState.Item("st_exportacao_frete_execucao").ToString.Trim = "F" Then
    '        '        lbl_status_execucao.Text = "Finalizada"
    '        '    Else
    '        '        lbl_status_execucao.Text = "Com Erros"
    '        '    End If

    '        'End If
    '        loadabas()

    '        messageControl.Alert("Exportação de Frete realizada com erros. O período selecionado não foi finalizado completamente.")

    '    End Try

    'End Sub


    Protected Sub deleteArquivos()
        Dim arquivos() As String
        Dim index As Integer
        Dim ldata As Date
        Dim ldata_limite As Date

        ldata_limite = DateAdd(DateInterval.Day, -3, Now)  ' 3 dias atras

        'Obtem a lista de arquivos no diretório 
        arquivos = Directory.GetFiles(ViewState.Item("caminho_arquivo").ToString)

        For index = 0 To arquivos.Length - 1
            arquivos(index) = New FileInfo(arquivos(index)).FullName


            Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(arquivos(index))
            'Se o arquivo existir no servidor


            If InStr(arquivos(index), "MilkSystem_EstoqueMensal") <> 0 Then
                ldata = Arquivo.CreationTime
                If ldata < ldata_limite Then
                    Arquivo.Delete()
                End If
            End If
        Next index



    End Sub


    Private Sub loadabas()

        Try

            'Dim lid_tela_ativa As Int32
            'td_tela1.Attributes.Remove("class")
            'If ViewState("tela_ativa") = 0 Then
            '    pnl_tela1.BackImageUrl = "~/img/aba_ativa.gif"
            '    pnl_tela1.ForeColor = System.Drawing.Color.FromName("#0000F5")
            '    btn_resultado.ForeColor = System.Drawing.Color.FromName("#0000F5")
            '    lid_tela_ativa = 0
            'Else
            '    pnl_tela1.BackImageUrl = "~/img/aba_nao_ativa.gif"
            '    pnl_tela1.ForeColor = System.Drawing.Color.FromName("#6767CC")
            '    btn_resultado.ForeColor = System.Drawing.Color.FromName("#6767CC")
            'End If
            'If btn_erros.Visible = True Then
            '    'td_placa2.Attributes.Remove("class")
            '    If ViewState("tela_ativa") = 1 Then
            '        'td_placa2.Attributes.Add("class", "aba_ativa")
            '        pnl_tela2.BackImageUrl = "~/img/aba_ativa.gif"
            '        pnl_tela2.ForeColor = System.Drawing.Color.FromName("#0000F5")
            '        btn_erros.ForeColor = System.Drawing.Color.FromName("#0000F5")
            '        lid_tela_ativa = 1
            '    Else
            '        'td_placa2.Attributes.Add("class", "aba_nao_ativa")
            '        pnl_tela2.BackImageUrl = "~/img/aba_nao_ativa.gif"
            '        pnl_tela2.ForeColor = System.Drawing.Color.FromName("#6767CC")
            '        btn_erros.ForeColor = System.Drawing.Color.FromName("#6767CC")
            '    End If
            'End If
            'loadAbaAtiva(lid_tela_ativa)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadAbaAtiva(ByVal id_aba As Int32)

        Try
            If id_aba = 0 Then
                gridDetalhe.Visible = False
                gridResults.Visible = True
                loadgridfrete()
            Else
                gridDetalhe.Visible = True
                gridResults.Visible = False
                loadgridfreteerro()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()
            Case "selecionar"
                Dim lbl_id_cooperativa As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_idcooperativa"), Label)
                Dim lbl_id_transportador As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_idtransportador"), Label)
                Response.Redirect("frm_frete_tabela_frete.aspx?id_transportador=" + lbl_id_transportador.Text.ToString + "&id_cooperativa=" + lbl_id_cooperativa.Text.ToString)

            Case "delete"
                'deleteTransitPoint(Convert.ToInt32(e.CommandArgument.ToString()))

            Case "consistencias"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
                'Dim lbl_id_linha As Label = CType(row.FindControl("lbl_id_linha"), Label)
                ViewState.Item("id_romaneio_consistencia") = Convert.ToInt32(e.CommandArgument.ToString())
                'loadConsistencias(Convert.ToInt32(e.CommandArgument.ToString()), CInt(lbl_id_linha.Text))
                'loadData()

            Case "detalhes"

                'Dim lbl_id_propriedade_titular As Label = CType(gridGrupoTitular.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_propriedade_titular"), Label)
                'Dim lbl_id_grupo_relacionamento As Label = CType(gridGrupoTitular.Rows.Item(e.CommandArgument.ToString).FindControl("id_grupo_relacionamento"), Label)
                'ViewState.Item("id_propriedade_titular") = lbl_id_propriedade_titular.Text
                'ViewState.Item("lbl_detalhe_item") = lbl_id_propriedade_titular.Text

                'loadData()
        End Select

    End Sub
    'Private Sub loadConsistencias(ByVal pid_romaneio As Int32, ByVal pid_linha As Int32)

    '    Try
    '        Dim romaneio As New Romaneio
    '        romaneio.id_romaneio = pid_romaneio
    '        romaneio.id_linha = pid_linha

    '        'Dim dsRomaneioRotaDetalhes As DataSet = romaneio.getRomaneioConciliacaoRotaDetalhes() ' Traz todas as propriedades coletadas e não coletadas da Rota
    '        Dim dsRomaneioRotaDetalhes As DataSet

    '        Select Case CInt(ViewState.Item("cbo_tipo_romaneio").ToString)
    '            Case 1 'romaneio
    '                dsRomaneioRotaDetalhes = romaneio.getRomaneioConciliacaoRotaDetalhes()
    '            Case 2, 3, 4, 5 'pre romaneios transit point e transbordo
    '                dsRomaneioRotaDetalhes = romaneio.getRomaneioConciliacaoRotaPreDetalhes()

    '        End Select


    '        If (dsRomaneioRotaDetalhes.Tables(0).Rows.Count > 0) Then
    '            pnl_detalhes.Visible = True
    '            gridDetalhe.Visible = True
    '            gridDetalhe.DataSource = Helper.getDataView(dsRomaneioRotaDetalhes.Tables(0), "")
    '            gridDetalhe.DataBind()
    '        Else
    '            pnl_detalhes.Visible = True
    '            gridDetalhe.Visible = False
    '        End If

    '        'lbl_id_romaneio.Text = pid_romaneio

    '        'Dim dsRomaneioConciliacaoRotasKm As DataSet = romaneio.getRomaneioConciliacaoRotasKm() ' Traz KM Original e Frete (alterado) do Romaneio
    '        'If (dsRomaneioConciliacaoRotasKm.Tables(0).Rows.Count > 0) Then
    '        '    Me.lbl_km_original.Text = dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("kmtotal").ToString
    '        '    Me.txt_nr_km_frete.Text = dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("nr_km_frete").ToString
    '        '    'fran 03/2017 i
    '        '    Me.lbl_km_coletor.Text = dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("nr_km_original_coletor").ToString
    '        '    If Not IsDBNull(dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("dt_importacao")) Then
    '        '        Me.lbl_dt_importacao.Text = DateTime.Parse(dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("dt_importacao").ToString).ToString("dd/MM/yyyy hh:mm:ss")
    '        '    Else
    '        '        Me.lbl_dt_importacao.Text = String.Empty
    '        '    End If
    '        '    'fran 03/2017 f

    '        '    If IsDBNull(dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("id_justificativa_km_frete")) Then
    '        '        Me.cbo_justificativa_km_frete.SelectedValue = 0
    '        '    Else
    '        '        Me.cbo_justificativa_km_frete.SelectedValue = dsRomaneioConciliacaoRotasKm.Tables(0).Rows(0).Item("id_justificativa_km_frete")
    '        '    End If
    '        'End If

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try


    'End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btn_editar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)
                btn_editar.CommandArgument = e.Row.RowIndex.ToString
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            'Dim hl_download As HyperLink = CType(e.Row.FindControl("hl_download"), HyperLink)

            'If Not hl_download.Text.ToString.Equals(String.Empty) Then
            '    hl_download.NavigateUrl = String.Format("frm_download.aspx?arquivo={0}", hl_download.Text.ToString)
            'End If

            'If e.Row.Cells(3).Text = 2 Then  ' Se finalizado com sucesso
            '    hl_download.Enabled = True
            'Else
            '    hl_download.Enabled = False
            'End If
        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting
        Select Case e.SortExpression.ToLower()

            Case "ds_transportadora"
                If (ViewState.Item("sortExpression")) = "ds_transportadora asc" Then
                    ViewState.Item("sortExpression") = "ds_transportadora desc"
                Else
                    ViewState.Item("sortExpression") = "ds_transportadora asc"
                End If


            Case "id_romaneio"
                If (ViewState.Item("sortExpression")) = "id_romaneio asc" Then
                    ViewState.Item("sortExpression") = "id_romaneio desc"
                Else
                    ViewState.Item("sortExpression") = "id_romaneio asc"
                End If

            Case "ds_placa_frete"
                If (ViewState.Item("sortExpression")) = "ds_placa_frete asc" Then
                    ViewState.Item("sortExpression") = "ds_placa_frete desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa_frete asc"
                End If

            Case "ds_cooperativa"
                If (ViewState.Item("sortExpression")) = "ds_cooperativa asc" Then
                    ViewState.Item("sortExpression") = "ds_cooperativa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_cooperativa asc"
                End If
            Case "nr_caderneta"
                If (ViewState.Item("sortExpression")) = "nr_caderneta asc" Then
                    ViewState.Item("sortExpression") = "nr_caderneta desc"
                Else
                    ViewState.Item("sortExpression") = "nr_caderneta asc"
                End If
            Case "nm_arquivo"
                If (ViewState.Item("sortExpression")) = "nm_arquivo asc" Then
                    ViewState.Item("sortExpression") = "nm_arquivo desc"
                Else
                    ViewState.Item("sortExpression") = "nm_arquivo asc"
                End If
            Case "st_exportacao_frete_execucao_itens"
                If (ViewState.Item("sortExpression")) = "st_exportacao_frete_execucao_itens asc" Then
                    ViewState.Item("sortExpression") = "st_exportacao_frete_execucao_itens desc"
                Else
                    ViewState.Item("sortExpression") = "st_exportacao_frete_execucao_itens asc"
                End If

        End Select

        loadgridfrete()

    End Sub

    Protected Sub grderros_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridDetalhe.PageIndexChanging
        gridDetalhe.PageIndex = e.NewPageIndex
        Me.loadgridfreteerro()

    End Sub

    Protected Sub grderros_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridDetalhe.Sorting
        Select Case e.SortExpression.ToLower()

            Case "nm_erro"
                If (ViewState.Item("sortExpression")) = "nm_erro asc" Then
                    ViewState.Item("sortExpression") = "nm_erro desc"
                Else
                    ViewState.Item("sortExpression") = "nm_erro asc"
                End If

        End Select

        loadgridfreteerro()


    End Sub

    Protected Sub btn_fechar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_fechar.Click
        Me.pnl_detalhes.Visible = False
        ViewState.Item("id_romaneio_consistencia") = 0
        'loadData()
    End Sub

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            If hf_id_transportador.Value = String.Empty Then
                ViewState.Item("id_transportador") = 0
            Else
                ViewState.Item("id_transportador") = hf_id_transportador.Value

            End If
            ViewState.Item("id_cooperativa") = 0
            loadData()

        End If


    End Sub
    Private Sub loadData()

        Try
            Dim frete As New FreteTabela

            If Not (ViewState("id_cooperativa").ToString().Equals(String.Empty)) Then
                frete.id_cooperativa = Convert.ToInt32(ViewState.Item("id_cooperativa"))
            End If
            If Not (ViewState("id_transportador").ToString().Equals(String.Empty)) Then
                frete.id_transportador = Convert.ToInt32(ViewState.Item("id_transportador"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                frete.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If

            Dim dsfrete As DataSet = frete.getFreteTabelaHeader

            If (dsfrete.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsfrete.Tables(0), "nm_transportador, nm_cooperativa")
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        Response.Redirect("lst_frete_tabela_frete.aspx")

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

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        lbl_nm_transportador.Text = String.Empty
        lbl_nm_transportador.Visible = False
        hf_id_transportador.Value = String.Empty

    End Sub

    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_frete_tabela_frete.aspx")

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
End Class
