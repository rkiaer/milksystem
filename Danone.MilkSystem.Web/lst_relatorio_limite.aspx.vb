Imports Danone.MilkSystem.Business
Imports System.Data
'Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Math


Partial Class lst_relatorio_limite
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        Dim data_fim As String

        'If Not (txt_cd_sap.Text.Trim().Equals(String.Empty)) Then
        '    ViewState.Item("cd_codigo_sap") = txt_cd_sap.Text.Trim()
        'Else
        '    ViewState.Item("cd_codigo_sap") = String.Empty
        'End If

        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia") = "01/" + txt_dt_referencia.Text.Trim()
            data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_referencia"))))
            ViewState.Item("dt_fim") = data_fim
        Else
            ViewState.Item("dt_referencia") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        End If

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        If Not (txt_cd_tecnico.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_tecnico") = txt_cd_tecnico.Text.Trim()
        Else
            ViewState.Item("id_tecnico") = String.Empty
        End If

        If Not (txt_cd_pessoa.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If
        If Not (hf_id_pessoa.Value.Equals(String.Empty)) Then
            ViewState.Item("id_pessoa") = hf_id_pessoa.Value
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If

        If Not (txt_id_propriedade.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_propriedade") = txt_id_propriedade.Text.Trim()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        ViewState.Item("tipo_emissao") = cbo_tipo_emissao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_relatorio_limite.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_limite.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 151
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
        End With
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With
        With img_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialogTecnico()")
            .ToolTip = "Filtrar EPL"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))



            ViewState.Item("sortExpression") = "id_propriedade asc"

            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim relsaldodisponivel As New SaldoDisponivel

            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                relsaldodisponivel.id_tecnico = Convert.ToString(ViewState.Item("id_tecnico"))
            End If
            If Not (ViewState("id_pessoa").ToString().Equals(String.Empty)) Then
                relsaldodisponivel.id_pessoa = Convert.ToString(ViewState.Item("id_pessoa"))
            End If

            If Not (ViewState("dt_referencia").ToString().Equals(String.Empty)) Then
                relsaldodisponivel.dt_referencia = Convert.ToString(ViewState.Item("dt_referencia"))
                relsaldodisponivel.dt_referencia_end = Convert.ToString(ViewState.Item("dt_fim"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                relsaldodisponivel.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("id_propriedade").ToString().Equals(String.Empty)) Then
                relsaldodisponivel.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If


            If ViewState.Item("tipo_emissao").ToString.Equals("A") Then 'Se relatorio analitico
                gridResultsAnalitico.Visible = True
                gridResultsSintetico.Visible = False

                Dim dsRelSaldoDisponivel As DataSet = relsaldodisponivel.getRelatorioSaldoDisponivelAnalitico
                If (dsRelSaldoDisponivel.Tables(0).Rows.Count > 0) Then
                    gridResultsAnalitico.Visible = True
                    gridResultsAnalitico.DataSource = Helper.getDataView(dsRelSaldoDisponivel.Tables(0), "id_propriedade")
                    gridResultsAnalitico.DataBind()

                    btn_exportar.Enabled = True

                Else
                    gridResultsAnalitico.Visible = False
                    btn_exportar.Enabled = False

                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

                End If

            Else 'se relatorio sintetico
                gridResultsAnalitico.Visible = False
                gridResultsSintetico.Visible = True
                Dim dsRelSaldoDisponivel As DataSet = relsaldodisponivel.getRelatorioSaldoDisponivelSintetico
                If (dsRelSaldoDisponivel.Tables(0).Rows.Count > 0) Then
                    Dim row As DataRow
                    Dim rowprop As DataRow
                    Dim dspropriedades As DataSet
                    Dim saldoanalitico As New SaldoDisponivel
                    Dim lvolumedia As Decimal = 0
                    Dim lvolumemensal As Decimal = 0

                    'quando fizer rel sintetico, os produtores que tenhamm mais de uma propriedade, devemm ser demonstrado o somatorio.
                    'ocorre que cada propriedade tem um saldo disponivel diferente inclusive por ter parametros diferentes como por exemplo ultimo dia de coleta que influenciara o volume total mensal
                    'por isso nao basta agrupar por propriedade, o valor sintetico é a soma do agrupamento por proriedade, isto para o volume mensal e volume diario

                    ''Encontra no dataset produtores que tenham mais de uma propriedade
                    'For Each row In dsRelSaldoDisponivel.Tables(0).Select("nr_propriedades > 1")
                    '    'abre nova instancia de saldodisponivel para buscar saldo apenas propriedades do produtor
                    '    saldoanalitico.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
                    '    saldoanalitico.dt_referencia = Convert.ToString(ViewState.Item("dt_referencia"))
                    '    saldoanalitico.dt_referencia_end = Convert.ToString(ViewState.Item("dt_fim"))
                    '    saldoanalitico.id_pessoa = row.Item("id_pessoa")

                    '    dspropriedades = saldoanalitico.getRelatorioSaldoDisponivelAnalitico
                    '    For Each rowprop In dspropriedades.Tables(0).Rows
                    '        'pega os somatorios de volumes para cada propriedade
                    '        lvolumedia = lvolumedia + CDec(rowprop.Item("nr_volume_dia").ToString)
                    '        lvolumemensal = lvolumemensal + CDec(rowprop.Item("nr_volume_mensal").ToString)
                    '    Next

                    '    'atualiza dataset que vai montar grid com somatoria correta
                    '    row.Item("nr_volume_dia") = lvolumedia
                    '    row.Item("nr_volume_mensal") = lvolumemensal
                    '    lvolumedia = 0
                    '    lvolumemensal = 0
                    'Next

                    gridResultsSintetico.Visible = True
                    gridResultsSintetico.DataSource = Helper.getDataView(dsRelSaldoDisponivel.Tables(0), "")
                    gridResultsSintetico.DataBind()

                    btn_exportar.Enabled = True

                Else
                    gridResultsSintetico.Visible = False
                    btn_exportar.Enabled = False

                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

                End If

            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResultsAnalitico_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsAnalitico.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Try
                If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
                End If

                'Dim lbl_nr_preco_negociado As Decimal = CType(e.Row.FindControl("nr_preco_negociado"), Label).Text
                'Dim lbl_nr_perc_limite1q_cc As Decimal = CType(e.Row.FindControl("nr_perc_limite1q_cc"), Label).Text
                'Dim lbl_nr_perc_limite2q_cc As Decimal = CType(e.Row.FindControl("nr_perc_limite2q_cc"), Label).Text
                'Dim lbl_nr_descontos As Decimal = CType(e.Row.FindControl("nr_descontos"), Label).Text
                'Dim lbl_nr_contas_parceladas As Decimal = CType(e.Row.FindControl("nr_contas_parceladas"), Label).Text
                'Dim lnr_volume_mensal As Decimal = CType(e.Row.FindControl("lbl_nr_volume_mensal"), Label).Text
                'Dim lbl_volume_mensal As Label = CType(e.Row.FindControl("lbl_nr_volume_mensal"), Label)
                'Dim hl_pedidosabertos As HyperLink = CType(e.Row.FindControl("hl_pedidosabertos"), HyperLink)
                'Dim lnr_pedidosabertos As Decimal = hl_pedidosabertos.Text
                ''Atualiza Coluna Valor Mensal estimado
                'e.Row.Cells(5).Text = Round(lnr_volume_mensal * lbl_nr_preco_negociado, 2)

                ''Atualiza limite calculado
                'If lbl_nr_preco_negociado > 0 Then
                '    If Day(Now) <= 15 Then   ' Se 1.a quinzena
                '        e.Row.Cells(6).Text = Round((Round(lnr_volume_mensal * lbl_nr_preco_negociado, 2)) * (lbl_nr_perc_limite1q_cc / 100), 2)
                '    Else
                '        e.Row.Cells(6).Text = Round((Round(lnr_volume_mensal * lbl_nr_preco_negociado, 2)) * (lbl_nr_perc_limite2q_cc / 100), 2)
                '    End If
                'Else
                '    e.Row.Cells(5).Text = "Sem Preço"
                'End If

                ''Atualiza Descontos
                'e.Row.Cells(7).Text = lbl_nr_descontos + lbl_nr_contas_parceladas

                ''Atualiza Total descontos + adto + ped abertos + pedidos finalizados contas parceladas proximo s meses
                'e.Row.Cells(11).Text = (Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) + Convert.ToDecimal(e.Row.Cells(8).Text.Trim()) + Convert.ToDecimal(e.Row.Cells(9).Text.Trim()) + Convert.ToDecimal(lnr_pedidosabertos))

                'If lbl_nr_preco_negociado > 0 Then
                '    'Atualiza % sobre limite calculado
                '    'e.Row.Cells(12).Text = FormatPercent(Round(((Convert.ToDecimal(e.Row.Cells(11).Text.Trim())) / Convert.ToDecimal(e.Row.Cells(6).Text.Trim())), 2), 2)

                '    'Atualiza % sobre mensal estimado
                '    e.Row.Cells(13).Text = FormatPercent(Round(((Convert.ToDecimal(e.Row.Cells(11).Text.Trim())) / Convert.ToDecimal(e.Row.Cells(5).Text.Trim())), 2), 2)
                '    'Atualiza Saldo Disponível
                '    e.Row.Cells(14).Text = (Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) - Convert.ToDecimal(e.Row.Cells(11).Text.Trim()))
                'Else
                '    'e.Row.Cells(12).Text = "0,00%"
                '    e.Row.Cells(13).Text = "0,00%"
                '    e.Row.Cells(14).Text = -Convert.ToDecimal(e.Row.Cells(10).Text.Trim())
                'End If


                ''Formatações
                'If IsNumeric(lbl_volume_mensal.Text.Trim()) Then  ' volume
                '    If CLng(lbl_volume_mensal.Text) > 0 Then  ' Se o valor é maior que zero
                '        lbl_volume_mensal.Text = FormatNumber(CLng(lbl_volume_mensal.Text), 0)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(5).Text.Trim()) Then  ' valor mensal
                '    If Convert.ToDecimal(e.Row.Cells(5).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(5).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(5).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(6).Text.Trim()) Then  ' limite calculado
                '    If Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(6).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(6).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(7).Text.Trim()) Then  ' descontos
                '    If Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(7).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(7).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(8).Text.Trim()) Then  ' adiantamento
                '    If Convert.ToDecimal(e.Row.Cells(8).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(8).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(8).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(9).Text.Trim()) Then  ' Pedido Contas parcelados
                '    If Convert.ToDecimal(e.Row.Cells(9).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(9).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(9).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(hl_pedidosabertos.Text.Trim()) Then  ' Pedidos Abrtos
                '    If Convert.ToDecimal(hl_pedidosabertos.Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        hl_pedidosabertos.Text = FormatNumber(Convert.ToDecimal(hl_pedidosabertos.Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If

                'If IsNumeric(e.Row.Cells(11).Text.Trim()) Then  ' valor total desc + ped+ adian/o
                '    If Convert.ToDecimal(e.Row.Cells(11).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(11).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(11).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If

                'If IsNumeric(e.Row.Cells(14).Text.Trim()) Then  ' valor Saldo Disponivel
                '    If Convert.ToDecimal(e.Row.Cells(14).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(14).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(14).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub gridResultsAnalitico_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResultsAnalitico.Sorting

        Select Case e.SortExpression.ToLower()


            Case "nm_pessoa"
                If (ViewState.Item("sortExpression")) = "nm_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_pessoa asc"
                End If


            Case "nm_tecnico"
                If (ViewState.Item("sortExpression")) = "nm_tecnico asc" Then
                    ViewState.Item("sortExpression") = "nm_tecnico desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tecnico asc"
                End If


            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If



        End Select

        loadData()

    End Sub



    Protected Sub gridResultsAnalitico_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
        e.Cancel = True
    End Sub

    Protected Sub gridResultsAnalitico_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResultsAnalitico.PageIndexChanging
        gridResultsAnalitico.PageIndex = e.NewPageIndex
        loadData()
    End Sub


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        'Fran 01/04/2009 i
        Dim data_fim As String

        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia") = "01/" + txt_dt_referencia.Text.Trim()
            data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_referencia"))))
            ViewState.Item("dt_fim") = data_fim
        Else
            ViewState.Item("dt_referencia") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        End If

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        If Not (txt_cd_tecnico.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_tecnico") = txt_cd_tecnico.Text.Trim()
        Else
            ViewState.Item("id_tecnico") = String.Empty
        End If

        If Not (txt_cd_pessoa.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If
        If Not (hf_id_pessoa.Value.Equals(String.Empty)) Then
            ViewState.Item("id_pessoa") = hf_id_pessoa.Value
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If

        If Not (txt_id_propriedade.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_propriedade") = txt_id_propriedade.Text.Trim()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        ViewState.Item("tipo_emissao") = cbo_tipo_emissao.SelectedValue

        loadData()

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 151
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        If ViewState.Item("tipo_emissao").Equals("A") Then
            If gridResultsAnalitico.Rows.Count.ToString + 1 < 65536 Then
                Response.Redirect("frm_relatorio_limite_analitico_excel.aspx?id_tecnico=" + ViewState.Item("id_tecnico").ToString + "&cd_pessoa=" + ViewState.Item("cd_pessoa").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString())
            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
            End If
        Else
            If gridResultsSintetico.Rows.Count.ToString + 1 < 65536 Then
                Response.Redirect("frm_relatorio_limite_sintetico_excel.aspx?id_tecnico=" + ViewState.Item("id_tecnico").ToString + "&cd_pessoa=" + ViewState.Item("cd_pessoa").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString())

            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
            End If

        End If
    End Sub

    Protected Sub img_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_tecnico.Click
        If Not (hf_id_tecnico.Value.Trim.Equals(String.Empty)) Then
            Me.lbl_nm_tecnico.Visible = True
            carregarCamposTecnico()
        End If

    End Sub


    Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
        lbl_nm_tecnico.Text = String.Empty
        'lbl_nm_tecnico.Visible = False
        hf_id_tecnico.Value = String.Empty
        Try
            If Not txt_cd_tecnico.Text.Equals(String.Empty) Then

                Dim tecnico As New Tecnico
                tecnico.id_tecnico = Convert.ToInt32(Me.txt_cd_tecnico.Text.Trim)
                tecnico.id_situacao = 1
                Dim dstecnico As DataSet = tecnico.getTecnicoByFilters
                'se encontrou produtor
                If dstecnico.Tables(0).Rows.Count > 0 Then
                    lbl_nm_tecnico.Enabled = True
                    lbl_nm_tecnico.Text = dstecnico.Tables(0).Rows(0).Item("nm_tecnico")
                    hf_id_tecnico.Value = dstecnico.Tables(0).Rows(0).Item("id_tecnico")
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposTecnico()

        Try

            Me.txt_cd_tecnico.Text = hf_id_tecnico.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True

        carregarCamposProdutor()

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty

        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then

                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'grupo de produtores 
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

    Protected Sub txt_id_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_propriedade.TextChanged
        lbl_nm_propriedade.Text = String.Empty
        hf_id_propriedade.Value = String.Empty
        Try
            If Not txt_id_propriedade.Text.Equals(String.Empty) Then
                Dim propriedade As New Propriedade
                propriedade.id_propriedade = Convert.ToInt32(txt_id_propriedade.Text.Trim)
                Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters
                If dspropriedade.Tables(0).Rows.Count > 0 Then
                    lbl_nm_propriedade.Enabled = True
                    lbl_nm_propriedade.Text = dspropriedade.Tables(0).Rows(0).Item("nm_propriedade")
                    hf_id_propriedade.Value = dspropriedade.Tables(0).Rows(0).Item("id_propriedade").ToString
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        Me.lbl_nm_propriedade.Visible = True
        carregarCamposPropriedade()
    End Sub
    Private Sub carregarCamposPropriedade()

        Try
            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.txt_id_propriedade.Text = Me.hf_id_propriedade.Value.ToString
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResultsSintetico_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResultsSintetico.PageIndexChanging
        gridResultsSintetico.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResultsSintetico_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsSintetico.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Try
                If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
                End If

                'Dim lbl_nr_preco_negociado As Decimal = CType(e.Row.FindControl("nr_preco_negociado"), Label).Text
                'Dim lbl_nr_perc_limite1q_cc As Decimal = CType(e.Row.FindControl("nr_perc_limite1q_cc"), Label).Text
                'Dim lbl_nr_perc_limite2q_cc As Decimal = CType(e.Row.FindControl("nr_perc_limite2q_cc"), Label).Text
                'Dim lbl_nr_descontos As Decimal = CType(e.Row.FindControl("nr_descontos"), Label).Text
                'Dim lbl_nr_contas_parceladas As Decimal = CType(e.Row.FindControl("nr_contas_parceladas"), Label).Text
                'Dim lnr_volume_mensal As Decimal = CType(e.Row.FindControl("lbl_nr_volume_mensal"), Label).Text
                'Dim lbl_volume_mensal As Label = CType(e.Row.FindControl("lbl_nr_volume_mensal"), Label)

                ''Atualiza Coluna Valor Mensal estimado
                'e.Row.Cells(4).Text = Round(lnr_volume_mensal * lbl_nr_preco_negociado, 2)

                ''Atualiza limite calculado
                'If lbl_nr_preco_negociado > 0 Then

                '    If Day(Now) <= 15 Then   ' Se 1.a quinzena
                '        e.Row.Cells(5).Text = Round((Round(lnr_volume_mensal * lbl_nr_preco_negociado, 2)) * (lbl_nr_perc_limite1q_cc / 100), 2)
                '    Else
                '        e.Row.Cells(5).Text = Round((Round(lnr_volume_mensal * lbl_nr_preco_negociado, 2)) * (lbl_nr_perc_limite2q_cc / 100), 2)
                '    End If
                'Else
                '    e.Row.Cells(5).Text = "Sem Preço"
                'End If
                ''Atualiza Descontos
                'e.Row.Cells(6).Text = lbl_nr_descontos + lbl_nr_contas_parceladas

                ''Atualiza Total descontos + adto + ped abertos + pedidos finalizados contas parceladas proximo s meses
                'e.Row.Cells(10).Text = (Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) + Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) + Convert.ToDecimal(e.Row.Cells(8).Text.Trim()) + Convert.ToDecimal(e.Row.Cells(9).Text.Trim()))

                'If lbl_nr_preco_negociado > 0 Then

                '    'Atualiza % sobre limite calculado
                '    'e.Row.Cells(11).Text = FormatPercent(Round(((Convert.ToDecimal(e.Row.Cells(10).Text.Trim())) / Convert.ToDecimal(e.Row.Cells(5).Text.Trim())), 2), 2)

                '    'Atualiza % sobre mensal estimado
                '    e.Row.Cells(12).Text = FormatPercent(Round(((Convert.ToDecimal(e.Row.Cells(10).Text.Trim())) / Convert.ToDecimal(e.Row.Cells(4).Text.Trim())), 2), 2)
                '    'Atualiza Saldo Disponível
                '    e.Row.Cells(13).Text = (Convert.ToDecimal(e.Row.Cells(5).Text.Trim()) - Convert.ToDecimal(e.Row.Cells(10).Text.Trim()))
                'Else
                '    'e.Row.Cells(11).Text = "0,00%"
                '    e.Row.Cells(12).Text = "0,00%"
                '    'Atualiza Saldo Disponível
                '    e.Row.Cells(13).Text = (-Convert.ToDecimal(e.Row.Cells(10).Text.Trim()))

                'End If

                ''Formatações
                'If IsNumeric(lbl_volume_mensal.Text.Trim()) Then  ' volume
                '    If CLng(lbl_volume_mensal.Text) > 0 Then  ' Se o valor é maior que zero
                '        lbl_volume_mensal.Text = FormatNumber(CLng(lbl_volume_mensal.Text), 0)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(4).Text.Trim()) Then  ' valor mensal
                '    If Convert.ToDecimal(e.Row.Cells(4).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(4).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(4).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(5).Text.Trim()) Then  ' limite calculado
                '    If Convert.ToDecimal(e.Row.Cells(5).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(5).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(5).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(6).Text.Trim()) Then 'descontos
                '    If Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(6).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(6).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(7).Text.Trim()) Then  ' adiantamento
                '    If Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(7).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(7).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(8).Text.Trim()) Then  ' central parcelamento
                '    If Convert.ToDecimal(e.Row.Cells(8).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(8).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(8).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(9).Text.Trim()) Then  ' Pedido abertos
                '    If Convert.ToDecimal(e.Row.Cells(9).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(9).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(9).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If
                'If IsNumeric(e.Row.Cells(10).Text.Trim()) Then  ' valor total desc + ped+ adian/o
                '    If Convert.ToDecimal(e.Row.Cells(10).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(10).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(10).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If

                'If IsNumeric(e.Row.Cells(13).Text.Trim()) Then  ' valor Saldo Disponivel
                '    If Convert.ToDecimal(e.Row.Cells(13).Text.Trim()) >= 0 Then  ' Se o valor é maior que zero
                '        e.Row.Cells(13).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(13).Text.Trim()), 2, , , TriState.True)
                '    End If
                'End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
End Class

