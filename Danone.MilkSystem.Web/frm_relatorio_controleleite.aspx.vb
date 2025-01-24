Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_relatorio_controleleite
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_relatorio_controleleite.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 47
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("data") Is Nothing) Then
                ViewState.Item("data") = Request("data")
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")

                ' adri 01/08/2012 - chamado 1577 - Implementação Projeto Themis - i
                ViewState.Item("data_fim") = Request("data_fim")
                ViewState.Item("emitirpor") = Request("emitirpor")
                ViewState.Item("cd_rota_ini") = Request("cd_rota_ini")
                ViewState.Item("cd_rota_fim") = Request("cd_rota_fim")
                ' adri 01/08/2012 - chamado 1577 - Implementação Projeto Themis - f

                loadData()
            Else
                messagecontrol.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
            End If


        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


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

            'Fran rls 17 total voolume dia
            'ViewState.Item("total_volume") = 0
            Dim ltotalvolume As Decimal = romaneio.getRomaneioSomaControleLeitebyDia
            ViewState.Item("total_volume") = ltotalvolume
            'Fran rls 17 f

            ViewState.Item("total_leite") = 0
            ViewState.Item("total_creme") = 0

            Me.lbl_data_ini.Text = DateTime.Parse(ViewState.Item("data").ToString).ToString("dd/MM/yyyy")
            'Me.lbl_data_fim.Text = DateTime.Parse(ViewState.Item("data_fim").ToString).ToString("dd/MM/yyyy")
            Dim estabelecimento As New Estabelecimento(romaneio.id_estabelecimento)
            Me.lbl_estabelecimento.Text = estabelecimento.cd_estabelecimento & " - " & estabelecimento.nm_estabelecimento

            Dim dsControleLeite As DataSet = romaneio.getRomaneioControleLeite()

            If (dsControleLeite.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsControleLeite.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            End If


        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResults_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.DataBound

    End Sub
    'Fran rls 17 - rotina anterior ao rls 17 i
    'Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

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
    '            lvalor_volume = round(lpeso / lvalor_densidade, 4)
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
    '        e.Row.Cells(9).Text = FormatNumber(ViewState.Item("total_volume"), 0)
    '        e.Row.Cells(11).Text = FormatNumber(ViewState.Item("total_leite"), 0)
    '        e.Row.Cells(12).Text = FormatNumber(ViewState.Item("total_creme"), 0)
    '    End If


    'End Sub
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvalor_volume As Decimal
            Dim lvalor_creme As Decimal
            Dim lvalor_leite As Decimal
            Dim lvariacao_volume_real As Decimal

            e.Row.Cells(0).Text = e.Row.RowIndex + 1

            'Fran rls17 i - A coluna de volume era coluna 9 e passou a ser 11
            'A coluna 11 era Leite, mas foi excluida e a coluna 12 era creme e tb foi excluida
            'e.Row.Cells(9).Text = 0
            'e.Row.Cells(11).Text = 0
            'e.Row.Cells(12).Text = 0
            e.Row.Cells(11).Text = 0
            'Fran rls 17 f

            lvalor_volume = 0
            lvalor_creme = 0
            lvalor_creme = 0

            ' Busca Densidade e MG
            Dim lvalor_densidade As Decimal
            Dim lvalor_mg As Decimal

            If IsDBNull(gridResults.DataKeys.Item(e.Row.RowIndex).Value) Then
                lvalor_densidade = 0
                'fran 17/08/2012 i deve colocar densidade emateria gorada (media caminhao)
                'lvalor_densidade = 0
                Dim romaneio As New Romaneio
                romaneio.id_romaneio = Convert.ToInt64(e.Row.Cells(3).Text) 'romaneio
                lvalor_densidade = romaneio.getRomaneioCompartimentoMediaDens()
                'fran 17/08/2012 f deve colocar densidade emateria gorada (media caminhao)
            Else
                Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento
                romaneioanalisecompartimento.id_romaneio_compartimento = Convert.ToInt32(gridResults.DataKeys.Item(e.Row.RowIndex).Value)
                romaneioanalisecompartimento.nm_sigla = "DENS"  ' Densidade
                lvalor_densidade = romaneioanalisecompartimento.getRomaneioAnaliseValorAnalise()

                romaneioanalisecompartimento.nm_sigla = "MG"  ' MG
                lvalor_mg = romaneioanalisecompartimento.getRomaneioAnaliseValorAnalise()
            End If

            'Fran rls 17 Coluna densidade era 8 e passa a ser 10 i
            'e.Row.Cells(8).Text = FormatNumber(lvalor_densidade, 0)
            'e.Row.Cells(8).Text = FormatNumber(lvalor_densidade, 4)  ' 20/01/2009 - Rls15
            e.Row.Cells(10).Text = FormatNumber(lvalor_densidade, 4)
            'Fran f

            'Fran rls 17 Coluna MG era 10 passa a ser 12  i
            'e.Row.Cells(10).Text = FormatNumber(lvalor_mg, 0)
            'e.Row.Cells(10).Text = FormatNumber(lvalor_mg, 2)   ' 20/01/2009 - Rls15
            e.Row.Cells(12).Text = FormatNumber(lvalor_mg, 2)   ' 20/01/2009 - Rls15
            'Fran rls 17 f

            'Calcula Volume
            Dim lpeso As Decimal

            'Fran rls17 - coluna pesobalanca de 7 foi para 9 i
            'If Trim(e.Row.Cells(7).Text) <> "" Then
            'lpeso = Convert.ToDecimal(e.Row.Cells(7).Text)
            If Trim(e.Row.Cells(9).Text) <> "" Then
                lpeso = Decimal.Truncate(Convert.ToDecimal(e.Row.Cells(9).Text))
                e.Row.Cells(9).Text = lpeso.ToString
                'Fran rls17 - coluna pesobalanca de 7 foi para 9 f
            Else
                lpeso = 0
            End If
            If lvalor_densidade <> 0 Then
                'Fran rls17 - volume(lts) passa a ser pesobalança * dens
                'lvalor_volume = Round(lpeso / lvalor_densidade, 4)
                'lvalor_volume = Round(lpeso * lvalor_densidade, 4)
                lvalor_volume = Round(lpeso / lvalor_densidade, 4)  ' Adriana 11/01/2011 - chamado 1134
                'Fran rls 17 f
            Else
                lvalor_volume = 0
            End If

            'Fran rls17 i - Creme foi retirado
            '' Calculo Creme
            'If lvalor_mg < 0.001 Then
            '    lvalor_creme = 0
            'Else
            '    lvalor_creme = Round((lvalor_volume * lvalor_mg / 0.4) / 0.9884, 4)
            'End If
            'Fran rls 17 f

            'Fran rls17 - retirada calculo leite i
            'Calcula Leite
            'lvalor_leite = lvalor_volume - lvalor_leite
            'Fran rls17 - retirada calculo leite f

            'ViewState.Item("total_volume") = Convert.ToDecimal(ViewState.Item("total_volume")) + Convert.ToDecimal(lvalor_volume)
            'Fran rls17 - retirada de leite e creme do gruid i
            'ViewState.Item("total_leite") = Convert.ToDecimal(ViewState.Item("total_leite")) + Convert.ToDecimal(lvalor_leite)
            'ViewState.Item("total_creme") = Convert.ToDecimal(ViewState.Item("total_creme")) + Convert.ToDecimal(lvalor_creme)
            'Fran rls17  f

            'Fran rls17 - coluna volume deixa de ser 9 e passa a ser 11 i
            'e.Row.Cells(9).Text = FormatNumber(lvalor_volume, 0)
            e.Row.Cells(11).Text = Decimal.Truncate(lvalor_volume).ToString
            'Fran rls17 - coluna volume deixa de ser 9 e passa a ser 11 f

            'Fran rls17 - retirada de leite e creme do gruid i
            'e.Row.Cells(11).Text = FormatNumber(lvalor_leite, 0)
            'e.Row.Cells(12).Text = FormatNumber(lvalor_creme, 0)
            'Fran rls17 - retirada de leite e creme do gruid f

            'fran rls 17 i inclusão da coluna de variacao do volume
            lvariacao_volume_real = Decimal.Truncate(lvalor_volume - CDec(e.Row.Cells(13).Text))
            e.Row.Cells(14).Text = lvariacao_volume_real.ToString
            If Not e.Row.Cells(13).Text.Equals(String.Empty) Then
                e.Row.Cells(13).Text = Decimal.Truncate(e.Row.Cells(13).Text)
            End If
            If Not e.Row.Cells(13).Text.Equals(String.Empty) Then
                e.Row.Cells(13).Text = Decimal.Truncate(e.Row.Cells(13).Text)
            End If

            'Fran ls 17 f

        End If

        If (e.Row.RowType = DataControlRowType.Footer) Then
            e.Row.Cells(1).Text = "Total"
            'Fran rls 17 i 
            'Ações: coluna 9 passou para 11; as colunas leite e creme foram excluidas; apartir deste rls o total será apurado por procedure pois deve ser visualizado no rodape o total do dia e não o total da pagina
            'e.Row.Cells(9).Text = Convert.ToString(FormatNumber(ViewState.Item("total_volume"), 0))
            'e.Row.Cells(11).Text = Convert.ToString(FormatNumber(ViewState.Item("total_leite"), 0))
            'e.Row.Cells(12).Text = Convert.ToString(FormatNumber(ViewState.Item("total_creme"), 0))

            e.Row.Cells(11).Text = Convert.ToString(FormatNumber(Decimal.Truncate(Convert.ToDecimal(ViewState.Item("total_volume"))), 0))

            'Fran rls17 f
        End If


    End Sub
End Class
