Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class lst_relatorio_controleleite

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("data") = Me.txt_data_ini.Text.Trim

        ' adri 01/08/2012 - chamado 1577 - Implementação Projeto Themis - i
        ViewState.Item("data_fim") = Me.txt_data_fim.Text.Trim
        ViewState.Item("emitirpor") = cbo_emitirpor.SelectedValue
        ViewState.Item("cd_rota_ini") = Me.txt_cd_rota_ini.Text.Trim
        ViewState.Item("cd_rota_fim") = Me.txt_cd_rota_fim.Text.Trim
        ' adri 01/08/2012 - chamado 1577 - Implementação Projeto Themis - f

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_relatorio_controleleite.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_controleleite.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 47
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim codigoesalq As New CodigoEsalq

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            txt_data_ini.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("relatorio_controleleite", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("relatorio_controleleite", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If


        If Not (customPage.getFilterValue("relatorio_controleleite", txt_data_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("data") = customPage.getFilterValue("relatorio_controleleite", txt_data_ini.ID)
            txt_data_ini.Text = ViewState.Item("data").ToString()
        Else
            ViewState.Item("data") = String.Empty
        End If

        ' 01/08/2012 - chamado 1577 - i
        If Not (customPage.getFilterValue("relatorio_controleleite", txt_data_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("data_fim") = customPage.getFilterValue("relatorio_controleleite", txt_data_fim.ID)
            txt_data_ini.Text = ViewState.Item("data").ToString()
        Else
            ViewState.Item("data_fim") = String.Empty
        End If

        If Not (customPage.getFilterValue("relatorio_controleleite", txt_cd_rota_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_rota_ini") = customPage.getFilterValue("relatorio_controleleite", txt_cd_rota_ini.ID)
            txt_cd_rota_ini.Text = ViewState.Item("cd_rota_ini").ToString()
        Else
            ViewState.Item("cd_rota_ini") = String.Empty
        End If

        If Not (customPage.getFilterValue("relatorio_controleleite", txt_cd_rota_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_rota_fim") = customPage.getFilterValue("relatorio_controleleite", txt_cd_rota_fim.ID)
            txt_cd_rota_fim.Text = ViewState.Item("cd_rota_fim").ToString()
        Else
            ViewState.Item("cd_rota_fim") = String.Empty
        End If

        If Not (customPage.getFilterValue("relatorio_controleleite", cbo_emitirpor.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("emitirpor") = customPage.getFilterValue("relatorio_controleleite", cbo_emitirpor.ID)
            Me.cbo_emitirpor.Text = ViewState.Item("emitirpor").ToString()
        Else
            ViewState.Item("emitirpor") = String.Empty
        End If
        ' 01/08/2012 - chamado 1577 - f


        If Not (customPage.getFilterValue("relatorio_controleleite", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("relatorio_controleleite", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("relatorio_controleleite")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio

            romaneio.data_inicio = ViewState.Item("data").ToString
            romaneio.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
            ' 01/08/2012 - chamado 1577 - i
            If ViewState.Item("data_fim").ToString = "" Then
                romaneio.data_fim = ViewState.Item("data").ToString
            Else
                romaneio.data_fim = ViewState.Item("data_fim").ToString
            End If
            romaneio.nm_linha_ini = ViewState.Item("cd_rota_ini").ToString
            If ViewState.Item("cd_rota_fim").ToString = "" Then
                romaneio.nm_linha_fim = ViewState.Item("cd_rota_ini").ToString
            Else
                romaneio.nm_linha_fim = ViewState.Item("cd_rota_fim").ToString
            End If
            ' 01/08/2012 - chamado 1577 - f
            ' ''Fran 12/10/2023
            '' ''Fran rls 17 total voolume dia
            '' ''ViewState.Item("total_volume") = 0
            ' ''Dim ltotalvolume As Decimal = romaneio.getRomaneioSomaControleLeitebyDia
            ' ''ViewState.Item("total_volume") = ltotalvolume
            '' ''Fran rls 17 f

            ' ''ViewState.Item("total_leite") = 0
            ' ''ViewState.Item("total_creme") = 0

            ' adri 01/08/2012 - chamado 1577 - i
            'Dim dsControleLeite As DataSet = romaneio.getRomaneioControleLeite()
            Dim dsControleLeite As DataSet
            gridResults.Visible = False
            gridResultsRom.Visible = False

            If ViewState.Item("emitirpor") = 1 Then   ' Se vai emitir o relatório por 1-Compartimento
                dsControleLeite = romaneio.getRomaneioControleLeite()
                If (dsControleLeite.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsControleLeite.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If


            Else
                dsControleLeite = romaneio.getRomaneioControleLeiteByRomaneio()
                If (dsControleLeite.Tables(0).Rows.Count > 0) Then
                    gridResultsRom.Visible = True
                    gridResultsRom.DataSource = Helper.getDataView(dsControleLeite.Tables(0), ViewState.Item("sortExpression"))
                    gridResultsRom.DataBind()
                Else
                    gridResultsRom.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If
            End If
            ' adri 01/08/2012 - chamado 1577 - i


            'Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_controleleite.aspx?data={0}", Me.txt_data_ini.Text) & String.Format("&id_estabelecimento={0}", Me.cbo_estabelecimento.SelectedValue)
            Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_controleleite.aspx?data={0}", Me.txt_data_ini.Text) & String.Format("&id_estabelecimento={0}", Me.cbo_estabelecimento.SelectedValue) & String.Format("&data_fim={0}", Me.txt_data_fim.Text) & String.Format("&cd_rota_ini={0}", Me.txt_cd_rota_ini.Text) & String.Format("&cd_rota_fim={0}", Me.txt_cd_rota_fim.Text) & String.Format("&emitirpor={0}", Me.cbo_emitirpor.SelectedValue)   ' adri 01/08/2012 - chamado 1577
            Me.hl_imprimir.Enabled = True

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.Load

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "ds_placa"
                If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
                End If


        End Select

        loadData()

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("relatorio_controleleite", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("relatorio_controleleite", txt_data_ini.ID, ViewState.Item("data").ToString)
            customPage.setFilter("relatorio_controleleite", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


    End Sub

    Private Sub deleteAnaliseEsalq(ByVal id_analise_esalq As Integer)


    End Sub
    'Fran ROTINA DO RLS 16 -----
    'Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    '    'If (e.Row.RowType = DataControlRowType.Header) Then
    '    '    e.Row.Cells(12).Text = "XX"

    '    'End If

    '    If (e.Row.RowType <> DataControlRowType.Header _
    '        And e.Row.RowType <> DataControlRowType.Footer _
    '        And e.Row.RowType <> DataControlRowType.Pager) Then

    '        Dim lvalor_volume As Decimal
    '        Dim lvalor_creme As Decimal
    '        Dim lvalor_leite As Decimal

    '        e.Row.Cells(0).Text = e.Row.RowIndex + 1

    '        e.Row.Cells(9).Text = 0
    '        e.Row.Cells(11).Text = 0
    '        e.Row.Cells(12).Text = 0

    '        lvalor_volume = 0
    '        lvalor_creme = 0
    '        lvalor_creme = 0

    '        ' Busca Densidade e MG
    '        Dim lvalor_densidade As Decimal
    '        Dim lvalor_mg As Decimal

    '        If IsDBNull(gridResults.DataKeys.Item(e.Row.RowIndex).Value) Then
    '            lvalor_densidade = 0
    '            lvalor_densidade = 0
    '        Else
    '            Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento
    '            romaneioanalisecompartimento.id_romaneio_compartimento = Convert.ToInt32(gridResults.DataKeys.Item(e.Row.RowIndex).Value)
    '            romaneioanalisecompartimento.nm_sigla = "DENS"  ' Densidade
    '            lvalor_densidade = romaneioanalisecompartimento.getRomaneioAnaliseValorAnalise()

    '            romaneioanalisecompartimento.nm_sigla = "MG"  ' MG
    '            lvalor_mg = romaneioanalisecompartimento.getRomaneioAnaliseValorAnalise()
    '        End If
    '        'e.Row.Cells(8).Text = FormatNumber(lvalor_densidade, 0)
    '        e.Row.Cells(8).Text = FormatNumber(lvalor_densidade, 4)  ' 20/01/2009 - Rls15
    '        'e.Row.Cells(10).Text = FormatNumber(lvalor_mg, 0)
    '        e.Row.Cells(10).Text = FormatNumber(lvalor_mg, 2)   ' 20/01/2009 - Rls15

    '        'Calcula Volume
    '        Dim lpeso As Decimal

    '        If Trim(e.Row.Cells(7).Text) <> "" Then
    '            lpeso = Convert.ToDecimal(e.Row.Cells(7).Text)
    '        Else
    '            lpeso = 0
    '        End If
    '        If lvalor_densidade <> 0 Then
    '            lvalor_volume = Round(lpeso / lvalor_densidade, 4)
    '        Else
    '            lvalor_volume = 0
    '        End If

    '        ' Calculo Creme
    '        If lvalor_mg < 0.001 Then
    '            lvalor_creme = 0
    '        Else
    '            lvalor_creme = Round((lvalor_volume * lvalor_mg / 0.4) / 0.9884, 4)
    '        End If

    '        'Calcula Leite
    '        lvalor_leite = lvalor_volume - lvalor_leite

    '        ViewState.Item("total_volume") = Convert.ToDecimal(ViewState.Item("total_volume")) + Convert.ToDecimal(lvalor_volume)
    '        ViewState.Item("total_leite") = Convert.ToDecimal(ViewState.Item("total_leite")) + Convert.ToDecimal(lvalor_leite)
    '        ViewState.Item("total_creme") = Convert.ToDecimal(ViewState.Item("total_creme")) + Convert.ToDecimal(lvalor_creme)

    '        e.Row.Cells(9).Text = FormatNumber(lvalor_volume, 0)
    '        e.Row.Cells(11).Text = FormatNumber(lvalor_leite, 0)
    '        e.Row.Cells(12).Text = FormatNumber(lvalor_creme, 0)

    '    End If

    '    If (e.Row.RowType = DataControlRowType.Footer) Then
    '        e.Row.Cells(1).Text = "Total"
    '        e.Row.Cells(9).Text = Convert.ToString(FormatNumber(ViewState.Item("total_volume"), 0))
    '        e.Row.Cells(11).Text = Convert.ToString(FormatNumber(ViewState.Item("total_leite"), 0))
    '        e.Row.Cells(12).Text = Convert.ToString(FormatNumber(ViewState.Item("total_creme"), 0))
    '    End If


    'End Sub
    'Fran 
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        'If (e.Row.RowType = DataControlRowType.Header) Then
        '    e.Row.Cells(12).Text = "XX"

        'End If

        If (e.Row.RowType <> DataControlRowType.Header _
             And e.Row.RowType <> DataControlRowType.Footer _
             And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvalor_volume As Decimal
            Dim lvalor_creme As Decimal
            Dim lvalor_leite As Decimal
            Dim lvariacao_volume_real As Decimal

            e.Row.Cells(0).Text = e.Row.RowIndex + 1

            '' '' ''Fran rls17 i - A coluna de volume era coluna 9 e passou a ser 11
            '' '' ''A coluna 11 era Leite, mas foi excluida e a coluna 12 era creme e tb foi excluida
            '' '' ''e.Row.Cells(9).Text = 0
            '' '' ''e.Row.Cells(11).Text = 0
            '' '' ''e.Row.Cells(12).Text = 0
            ' '' ''e.Row.Cells(11).Text = 0
            '' '' ''Fran rls 17 f

            ' '' ''lvalor_volume = 0
            ' '' ''lvalor_creme = 0
            ' '' ''lvalor_creme = 0

            '' '' '' Busca Densidade e MG
            ' '' ''Dim lvalor_densidade As Decimal
            ' '' ''Dim lvalor_mg As Decimal

            '' '' ''If IsDBNull(gridResults.DataKeys.Item(e.Row.RowIndex).Value) Then
            ' '' ''If IsDBNull(gridResults.DataKeys.Item(e.Row.RowIndex).Value) Or gridResults.DataKeys.Item(e.Row.RowIndex).Value = 0 Then  ' adri 01/08/2012 chamado 1577 - Se está consultando por Romaneio
            ' '' ''    lvalor_mg = 0 ' adri 01/08/2012 - chamado 1577

            ' '' ''    'fran 17/08/2012 i deve colocar densidade emateria gorada (media caminhao)
            ' '' ''    'lvalor_densidade = 0
            ' '' ''    Dim romaneio As New Romaneio
            ' '' ''    romaneio.id_romaneio = Convert.ToInt64(e.Row.Cells(3).Text) 'romaneio
            ' '' ''    lvalor_densidade = romaneio.getRomaneioCompartimentoMediaDens()
            ' '' ''    'fran 17/08/2012 f deve colocar densidade emateria gorada (media caminhao)


            ' '' ''Else
            ' '' ''    Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento
            ' '' ''    romaneioanalisecompartimento.id_romaneio_compartimento = Convert.ToInt32(gridResults.DataKeys.Item(e.Row.RowIndex).Value)
            ' '' ''    romaneioanalisecompartimento.nm_sigla = "DENS"  ' Densidade
            ' '' ''    lvalor_densidade = romaneioanalisecompartimento.getRomaneioAnaliseValorAnalise()

            ' '' ''    romaneioanalisecompartimento.nm_sigla = "MG"  ' MG
            ' '' ''    lvalor_mg = romaneioanalisecompartimento.getRomaneioAnaliseValorAnalise()
            ' '' ''End If

            '' '' ''Fran rls 17 Coluna densidade era 8 e passa a ser 10 i
            '' '' ''e.Row.Cells(8).Text = FormatNumber(lvalor_densidade, 0)
            '' '' ''e.Row.Cells(8).Text = FormatNumber(lvalor_densidade, 4)  ' 20/01/2009 - Rls15
            ' '' ''e.Row.Cells(10).Text = FormatNumber(lvalor_densidade, 4)
            '' '' ''Fran f

            '' '' ''Fran rls 17 Coluna MG era 10 passa a ser 12  i
            '' '' ''e.Row.Cells(10).Text = FormatNumber(lvalor_mg, 0)
            '' '' ''e.Row.Cells(10).Text = FormatNumber(lvalor_mg, 2)   ' 20/01/2009 - Rls15
            ' '' ''e.Row.Cells(12).Text = FormatNumber(lvalor_mg, 2)   ' 20/01/2009 - Rls15
            '' '' ''Fran rls 17 f

            '' '' ''Calcula Volume
            ' '' ''Dim lpeso As Decimal

            '' '' ''Fran rls17 - coluna pesobalanca de 7 foi para 9 i
            '' '' ''If Trim(e.Row.Cells(7).Text) <> "" Then
            '' '' ''lpeso = Convert.ToDecimal(e.Row.Cells(7).Text)
            ' '' ''If Trim(e.Row.Cells(9).Text) <> "" Then
            ' '' ''    lpeso = Decimal.Truncate(Convert.ToDecimal(e.Row.Cells(9).Text))
            ' '' ''    e.Row.Cells(9).Text = lpeso.ToString
            ' '' ''    'Fran rls17 - coluna pesobalanca de 7 foi para 9 f
            ' '' ''Else
            ' '' ''    lpeso = 0
            ' '' ''End If
            ' '' ''If lvalor_densidade <> 0 Then
            ' '' ''    'Fran rls17 - volume(lts) passa a ser pesobalança * dens
            ' '' ''    'lvalor_volume = Round(lpeso / lvalor_densidade, 4)
            ' '' ''    'lvalor_volume = Round(lpeso * lvalor_densidade, 4)
            ' '' ''    lvalor_volume = Round(lpeso / lvalor_densidade, 4)  ' Adriana 11/01/2011 - chamado 1134
            ' '' ''    'Fran rls 17 f
            ' '' ''Else
            ' '' ''    lvalor_volume = 0
            ' '' ''End If

            '' '' ''Fran rls17 i - Creme foi retirado
            ' '' '' '' Calculo Creme
            '' '' ''If lvalor_mg < 0.001 Then
            '' '' ''    lvalor_creme = 0
            '' '' ''Else
            '' '' ''    lvalor_creme = Round((lvalor_volume * lvalor_mg / 0.4) / 0.9884, 4)
            '' '' ''End If
            '' '' ''Fran rls 17 f

            '' '' ''Fran rls17 - retirada calculo leite i
            '' '' ''Calcula Leite
            '' '' ''lvalor_leite = lvalor_volume - lvalor_leite
            '' '' ''Fran rls17 - retirada calculo leite f

            '' '' ''ViewState.Item("total_volume") = Convert.ToDecimal(ViewState.Item("total_volume")) + Convert.ToDecimal(lvalor_volume)
            '' '' ''Fran rls17 - retirada de leite e creme do gruid i
            '' '' ''ViewState.Item("total_leite") = Convert.ToDecimal(ViewState.Item("total_leite")) + Convert.ToDecimal(lvalor_leite)
            '' '' ''ViewState.Item("total_creme") = Convert.ToDecimal(ViewState.Item("total_creme")) + Convert.ToDecimal(lvalor_creme)
            '' '' ''Fran rls17  f

            '' '' ''Fran rls17 - coluna volume deixa de ser 9 e passa a ser 11 i
            '' '' ''e.Row.Cells(9).Text = FormatNumber(lvalor_volume, 0)
            ' '' ''e.Row.Cells(11).Text = Decimal.Truncate(lvalor_volume).ToString
            '' '' ''Fran rls17 - coluna volume deixa de ser 9 e passa a ser 11 f

            '' '' ''Fran rls17 - retirada de leite e creme do gruid i
            '' '' ''e.Row.Cells(11).Text = FormatNumber(lvalor_leite, 0)
            '' '' ''e.Row.Cells(12).Text = FormatNumber(lvalor_creme, 0)
            '' '' ''Fran rls17 - retirada de leite e creme do gruid f

            '' '' ''fran rls 17 i inclusão da coluna de variacao do volume
            ' '' ''lvariacao_volume_real = Decimal.Truncate(lvalor_volume - CDec(e.Row.Cells(13).Text))
            ' '' ''e.Row.Cells(14).Text = lvariacao_volume_real.ToString
            ' '' ''If Not e.Row.Cells(13).Text.Equals(String.Empty) Then
            ' '' ''    e.Row.Cells(13).Text = Decimal.Truncate(e.Row.Cells(13).Text)
            ' '' ''End If
            ' '' ''If Not e.Row.Cells(13).Text.Equals(String.Empty) Then
            ' '' ''    e.Row.Cells(13).Text = Decimal.Truncate(e.Row.Cells(13).Text)
            ' '' ''End If

            'Fran ls 17 f

        End If

        ' '' ''If (e.Row.RowType = DataControlRowType.Footer) Then
        ' '' ''    e.Row.Cells(1).Text = "Total"
        ' '' ''    'Fran rls 17 i 
        ' '' ''    'Ações: coluna 9 passou para 11; as colunas leite e creme foram excluidas; apartir deste rls o total será apurado por procedure pois deve ser visualizado no rodape o total do dia e não o total da pagina
        ' '' ''    'e.Row.Cells(9).Text = Convert.ToString(FormatNumber(ViewState.Item("total_volume"), 0))
        ' '' ''    'e.Row.Cells(11).Text = Convert.ToString(FormatNumber(ViewState.Item("total_leite"), 0))
        ' '' ''    'e.Row.Cells(12).Text = Convert.ToString(FormatNumber(ViewState.Item("total_creme"), 0))

        ' '' ''    e.Row.Cells(11).Text = Convert.ToString(FormatNumber(Decimal.Truncate(Convert.ToDecimal(ViewState.Item("total_volume"))), 0))

        ' '' ''    'Fran rls17 f
        ' '' ''End If


    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        hl_imprimir.Enabled = False
    End Sub

    Protected Sub txt_data_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_data_ini.TextChanged
        hl_imprimir.Enabled = False

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        'Mirella 07/08/2012 i 

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("data") = txt_data_ini.Text
        ViewState.Item("data_fim") = txt_data_fim.Text
        ViewState.Item("emitirpor") = cbo_emitirpor.SelectedValue
        ViewState.Item("cd_rota_ini") = txt_cd_rota_ini.Text
        ViewState.Item("cd_rota_fim") = txt_cd_rota_fim.Text

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 47
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        customPage.clearFilters("relatorio_controleleite")

        saveFilters()
        Response.Redirect("frm_relatorio_controleleite_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&data_ini=" + ViewState.Item("data").ToString() + "&data_fim=" + ViewState.Item("data_fim").ToString() + "&emitirpor=" + ViewState.Item("emitirpor").ToString() + "&cd_rota_ini=" + ViewState.Item("cd_rota_ini").ToString() + "&cd_rota_fim=" + ViewState.Item("cd_rota_fim").ToString())
    End Sub 'Mirella 07/08/2012 f

    Protected Sub gridResultsRom_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResultsRom.PageIndexChanging
        gridResultsRom.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResultsRom_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsRom.RowDataBound


        If (e.Row.RowType <> DataControlRowType.Header _
             And e.Row.RowType <> DataControlRowType.Footer _
             And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_id_cooperativa As Label = CType(e.Row.FindControl("lbl_id_cooperativa"), Label)

            Dim lbdescontotransp As Boolean = False

            e.Row.Cells(0).Text = e.Row.RowIndex + 1

            'se o volume rejeitado for 0 limpa o campo
            If e.Row.Cells(16).Text.Equals("0") Then
                e.Row.Cells(16).Text = String.Empty
            End If

            ''se o volume da balança é maior do que o volume da cadaerneta/nf,
            ''neste caso não emite desconto transportador (se o sinal da variacao for negativo caderneta 'e maior
            'If Not (Sign(CDec(e.Row.Cells(13).Text)) = -1) Or e.Row.Cells(11).Text.Equals("0") Then
            '    lbdescontotransp = False
            'Else
            '    If Sign(CDec(e.Row.Cells(13).Text)) = -1 Then 'se balança valor negativo
            '        lbdescontotransp = True
            '    Else
            '        lbdescontotransp = False
            '    End If
            'End If


            ''se a diferença de volume sem sinal for maior que o percentual de tolerancia deve emitir desconto caso contrario não deve emitir desconto
            'If +Abs(CDec(e.Row.Cells(13).Text)) > CDec(e.Row.Cells(22).Text) Then
            '    lbdescontotransp = True
            'Else
            '    lbdescontotransp = False
            'End If

            ''se for cooperativa nao deve ter desconto transportadr
            'If Not lbl_id_cooperativa.Text.Equals(String.Empty) AndAlso Not lbl_id_cooperativa.Text.Equals("0") Then
            '    lbdescontotransp = False
            'End If

            ''se não deve imprimir, não calcula valor a ser descontado  trasnportador
            'If lbdescontotransp = False Then
            '    e.Row.Cells(23).Text = String.Empty
            'Else
            '    'Valor a ser descontado do transportador (diferença - valor 0,2%
            '    e.Row.Cells(23).Text = Decimal.Truncate(+Abs(CDec(e.Row.Cells(13).Text)) - CDec(e.Row.Cells(22).Text))

            'End If

        End If




    End Sub

    Protected Sub gridResultsRom_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResultsRom.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub gridResultsRom_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResultsRom.Sorting
        Select Case e.SortExpression.ToLower()


            Case "ds_placa"
                If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
                End If


        End Select

        loadData()

    End Sub
End Class
