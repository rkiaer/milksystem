Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class lst_relatorio_fisicoquimica

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("data") = Me.txt_data.Text.Trim
        'ViewState.Item("cd_rota_ini") = Me.txt_cd_rota_ini.Text
        'ViewState.Item("cd_rota_fim") = Me.txt_cd_rota_fim.Text
        'If Trim(Me.txt_cd_rota_fim.Text) = "" Then
        '    ViewState.Item("cd_rota_fim") = Me.txt_cd_rota_ini.Text
        'End If
        ViewState.Item("data_fim") = Me.txt_dt_fim.Text 'fran melhoria fase 2
        ViewState.Item("nm_linha") = Me.txt_nm_linha.Text 'fran melhoria fase 2


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_relatorio_fisicoquimica.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_fisicoquimica.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 46
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


            txt_data.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            txt_dt_fim.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("relatorio_fisicoquimica", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("relatorio_fisicoquimica", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If


        If Not (customPage.getFilterValue("relatorio_fisicoquimica", txt_data.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("data") = customPage.getFilterValue("relatorio_fisicoquimica", txt_data.ID)
            txt_data.Text = ViewState.Item("data").ToString()
        Else
            ViewState.Item("data") = String.Empty
        End If

        'If Not (customPage.getFilterValue("relatorio_fisicoquimica", txt_data.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("cd_rota_ini") = customPage.getFilterValue("relatorio_fisicoquimica", txt_cd_rota_ini.ID)
        '    txt_cd_rota_ini.Text = ViewState.Item("cd_rota_ini").ToString()
        'Else
        '    ViewState.Item("cd_rota_ini") = String.Empty
        'End If

        'If Not (customPage.getFilterValue("relatorio_fisicoquimica", txt_data.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("cd_rota_fim") = customPage.getFilterValue("relatorio_fisicoquimica", txt_cd_rota_fim.ID)
        '    txt_cd_rota_fim.Text = ViewState.Item("cd_rota_fim").ToString()
        'Else
        '    ViewState.Item("cd_rota_fim") = String.Empty
        'End If

        If Not (customPage.getFilterValue("relatorio_fisicoquimica", txt_dt_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("data_fim") = customPage.getFilterValue("relatorio_fisicoquimica", txt_dt_fim.ID)
            txt_dt_fim.Text = ViewState.Item("data_fim").ToString()
        Else
            ViewState.Item("data_fim") = String.Empty
        End If

        If Not (customPage.getFilterValue("relatorio_fisicoquimica", txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_linha") = customPage.getFilterValue("relatorio_fisicoquimica", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_linha").ToString()
        Else
            ViewState.Item("nm_linha") = String.Empty
        End If

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
            'If ViewState.Item("cd_rota_ini") <> "" Then
            '    romaneio.id_linha_ini = Convert.ToInt32(ViewState.Item("cd_rota_ini"))
            'End If
            'If ViewState.Item("cd_rota_fim") <> "" Then
            '    romaneio.id_linha_fim = Convert.ToInt32(ViewState.Item("cd_rota_fim"))
            'End If
            romaneio.data_fim = ViewState.Item("data_fim").ToString
            romaneio.nm_linha = ViewState.Item("nm_linha").ToString


            Dim dsAnaliseFisicoQuimica As DataSet = romaneio.getRomaneioAnaliseFisicoQuimica()

            If (dsAnaliseFisicoQuimica.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsAnaliseFisicoQuimica.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            'Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_fisicoquimica.aspx?data={0}", Me.txt_data.Text) & String.Format("&id_estabelecimento={0}", Me.cbo_estabelecimento.SelectedValue) & String.Format("&cd_rota_ini={0}", Me.txt_cd_rota_ini.Text) & String.Format("&cd_rota_fim={0}", Me.txt_cd_rota_fim.Text)
            Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_fisicoquimica.aspx?data={0}", ViewState.Item("data").ToString) & String.Format("&id_estabelecimento={0}", ViewState.Item("id_estabelecimento").ToString) & String.Format("&data_fim={0}", ViewState.Item("data_fim").ToString) & String.Format("&nm_linha={0}", ViewState.Item("nm_linha").ToString) 'Fran 06/2015 relatorios
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


            customPage.setFilter("relatorio_fisicoquimica", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("relatorio_fisicoquimica", txt_data.ID, ViewState.Item("data").ToString)
            'customPage.setFilter("relatorio_fisicoquimica", txt_cd_rota_ini.ID, ViewState.Item("cd_rota_ini").ToString)
            'customPage.setFilter("relatorio_fisicoquimica", txt_cd_rota_fim.ID, ViewState.Item("cd_rota_fim").ToString)
            customPage.setFilter("relatorio_fisicoquimica", txt_dt_fim.ID, ViewState.Item("data_fim").ToString)
            customPage.setFilter("relatorio_fisicoquimica", txt_nm_linha.ID, ViewState.Item("nm_linha").ToString)
            customPage.setFilter("relatorio_fisicoquimica", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


    End Sub

    Private Sub deleteAnaliseEsalq(ByVal id_analise_esalq As Integer)


    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim li As Int32

            '' Busca Lacres Entrada e Saída
            'Fran 28/08/2009 i rls 19 desabilitado
            'If Not IsDBNull(gridResults.DataKeys.Item(e.Row.RowIndex).Item("id_romaneio_placa")) Then

            'Dim romaneiolacre As New RomaneioLacre

            'Dim llacres_entrada As String
            'Dim llacres_saida As String

            'Dim row As DataRow
            'romaneiolacre.id_romaneio_placa = Convert.ToInt32(gridResults.DataKeys.Item(e.Row.RowIndex).Item("id_romaneio_placa"))
            'Dim dsRomaneioLacre As DataSet = romaneiolacre.getRomaneioLacresByFilters()

            'Dim llacreentrada As Label = CType(e.Row.FindControl("lbllacreentrada"), Label)
            'Dim llacresaida As Label = CType(e.Row.FindControl("lbllacresaida"), Label)

            'llacres_entrada = ""
            'llacres_saida = ""
            'For Each row In dsRomaneioLacre.Tables(0).Rows
            '    If Not IsDBNull(row.Item("nr_lacre_entrada")) Then
            '        llacres_entrada = llacres_entrada & Convert.ToString(row.Item("nr_lacre_entrada")) & ", "
            '    End If
            '    If Not IsDBNull(row.Item("nr_lacre_saida")) Then
            '        llacres_saida = llacres_saida & Convert.ToString(row.Item("nr_lacre_saida")) & ", "
            '    End If

            'Next
            'If llacres_entrada <> "" Then
            '    llacres_entrada = Left(llacres_entrada, Len(llacres_entrada) - 2)
            'End If
            'If llacres_saida <> "" Then
            '    llacres_saida = Left(llacres_saida, Len(llacres_saida) - 2)
            'End If

            'llacreentrada.Text = llacres_entrada
            'llacresaida.Text = llacres_saida

            'End If
            'Fran 28/08/2009 f
            ' Busca Análises
            Dim lvalor_analise As String
            Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento()
            romaneioanalisecompartimento.id_romaneio_compartimento = Convert.ToInt32(gridResults.DataKeys.Item(e.Row.RowIndex).Item("id_romaneio_compartimento"))
            Dim dsAnalisesCompartimento As DataSet = romaneioanalisecompartimento.getRomaneioAnalisesCompartimentosByFilters()

            li = 0
            For li = 0 To dsAnalisesCompartimento.Tables(0).Rows.Count - 1


                If dsAnalisesCompartimento.Tables(0).Rows(li).Item("id_formato_analise") = 3 Then
                    If IsDBNull(dsAnalisesCompartimento.Tables(0).Rows(li).Item("nr_valor")) Then
                        lvalor_analise = ""
                    Else
                        'Fran 28/08/2009 i rls 18 
                        'lvalor_analise = dsAnalisesCompartimento.Tables(0).Rows(li).Item("nm_analise_logica")
                        Select Case CInt(dsAnalisesCompartimento.Tables(0).Rows(li).Item("nr_valor"))
                            Case 1
                                lvalor_analise = "Neg"
                            Case 2
                                lvalor_analise = "Pos"
                            Case 3
                                lvalor_analise = "Conf"
                            Case 4
                                lvalor_analise = "NConf"
                        End Select
                        'Fran 28/08/2009 f rls 18 


                    End If
                Else
                    If IsDBNull(dsAnalisesCompartimento.Tables(0).Rows(li).Item("nr_valor")) Then
                        lvalor_analise = 0
                    Else
                        lvalor_analise = dsAnalisesCompartimento.Tables(0).Rows(li).Item("nr_valor")
                    End If
                End If
                Select Case UCase(dsAnalisesCompartimento.Tables(0).Rows(li).Item("nm_sigla"))

                    Case "LCR" 'Fran 28/08/2009 i rls19
                        'e.Row.Cells(5).Text = lvalor_analise fran 17/05/2017 inclusao novas analises
                    Case "IDM"
                        'e.Row.Cells(6).Text = lvalor_analise fran 17/05/2017 inclusao novas analises
                    Case "HIM"
                        'e.Row.Cells(7).Text = lvalor_analise fran 17/05/2017 inclusao novas analises
                    Case "LIT"
                        'e.Row.Cells(8).Text = lvalor_analise
                        e.Row.Cells(6).Text = lvalor_analise
                    Case "LIB"
                        e.Row.Cells(7).Text = lvalor_analise
                    Case "LIM"
                        e.Row.Cells(8).Text = lvalor_analise
                    Case "CEA"
                        e.Row.Cells(9).Text = lvalor_analise
                    Case "DENS"
                        e.Row.Cells(11).Text = lvalor_analise
                    Case "MG"
                        'e.Row.Cells(14).Text = lvalor_analise
                        e.Row.Cells(12).Text = FormatNumber(lvalor_analise, 2)  ' 20/01/2009 - Rls15
                    Case "PROT"
                        'e.Row.Cells(15).Text = lvalor_analise
                        e.Row.Cells(13).Text = FormatNumber(lvalor_analise, 2)  ' 20/01/2009 - Rls15
                    Case "EST"
                        'e.Row.Cells(16).Text = lvalor_analise
                        e.Row.Cells(14).Text = FormatNumber(lvalor_analise, 2)  ' 20/01/2009 - Rls15
                    Case "ESD"
                        ' 24/11/2008 - i
                        'e.Row.Cells(17).Text = lvalor_analise
                        ' 20/01/2009 - Rls15 - Desabilitado pois esta análise não é mais preenchida
                        'If IsNumeric(e.Row.Cells(16).Text) And IsNumeric(e.Row.Cells(14).Text) Then
                        '    e.Row.Cells(17).Text = e.Row.Cells(16).Text - e.Row.Cells(14).Text
                        'End If
                        '03/12/2018  i - fran  esd é importado e nao precisa ser calculado
                        e.Row.Cells(15).Text = FormatNumber(lvalor_analise, 2)
                        '03/12/2018  f - fran  esd é importado e nao precisa ser calculado
                        'fran junho/2019 i
                        'Case "ACIDEZ"
                        '    e.Row.Cells(16).Text = lvalor_analise
                    Case "A.L."
                        e.Row.Cells(16).Text = lvalor_analise
                        'fran junho/2019 f

                        'fran 17/05/2017 inclusao novas analises i
                    Case "N. A."
                        e.Row.Cells(17).Text = lvalor_analise
                        'fran 17/05/2017 inclusao novas analises f
                    Case "TEMP"
                        'e.Row.Cells(19).Text = lvalor_analise
                        'e.Row.Cells(19).Text = FormatNumber(lvalor_analise, 2)  ' 20/01/2009 - Rls15
                        e.Row.Cells(18).Text = FormatNumber(lvalor_analise, 1)  ' 12/02/2009 - Rls16
                    Case "ALIZ78"
                        e.Row.Cells(19).Text = lvalor_analise
                    Case "ALIZ74"
                        'e.Row.Cells(21).Text = lvalor_analise fran 17/05/2017 inclusao novas analises
                    Case "CRIOSC"
                        ' 24/11/2008 - i
                        'e.Row.Cells(22).Text = lvalor_analise
                        If IsNumeric(lvalor_analise) Then
                            e.Row.Cells(20).Text = (lvalor_analise / -1000)
                        End If
                        'fran 02/2016 i devol foi retirada para verificar SNAP
                        'Case "DEVOL"
                        '    e.Row.Cells(23).Text = lvalor_analise
                    Case "SNAP"
                        e.Row.Cells(21).Text = lvalor_analise
                        'fran 02/2016 f devol foi retirada para verificar SNAP
                    Case "CHARM"
                        e.Row.Cells(22).Text = lvalor_analise
                    Case "REDUT"
                        e.Row.Cells(23).Text = lvalor_analise
                        'Case "PEROX" fran 17/05/2017 inclusao novas analises
                    Case "PEROXIDO"
                        e.Row.Cells(24).Text = lvalor_analise
                    Case "FOSFAT"
                        e.Row.Cells(25).Text = lvalor_analise
                        'fran 17/05/2017 inclusao novas analises i
                    Case "CLORETO"
                        e.Row.Cells(26).Text = lvalor_analise
                        'fran 17/05/2017 inclusao novas analises f
                    Case "No. Lacres".ToUpper
                        e.Row.Cells(27).Text = lvalor_analise

                End Select

            Next

            '03/12/2018  i - fran  esd é importado e nao precisa ser calculado
            ' 20/01/2009 - Rls15 - Formata coluna 17 - ESD - i ESD = EST - MG
            'If IsNumeric(e.Row.Cells(14).Text) And IsNumeric(e.Row.Cells(12).Text) Then
            '    e.Row.Cells(15).Text = FormatNumber(e.Row.Cells(14).Text - e.Row.Cells(12).Text, 2)
            'End If
            ' 20/01/2009 - Rls15 - Formata coluna 17 - F - f
            '03/12/2018  f - fran  esd é importado e nao precisa ser calculado

            If IsNumeric(e.Row.Cells(27).Text) Then
                e.Row.Cells(27).Text = FormatNumber(e.Row.Cells(27).Text, 0)
            End If

        End If


    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        hl_imprimir.Enabled = False
    End Sub

    Protected Sub txt_data_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_data.TextChanged
        hl_imprimir.Enabled = False

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("data") = Me.txt_data.Text.Trim
        ViewState.Item("data_fim") = Me.txt_dt_fim.Text 'fran melhoria fase 2
        ViewState.Item("nm_linha") = Me.txt_nm_linha.Text 'fran melhoria fase 2

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 46
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        loadData()


        Response.Redirect("frm_relatorio_fisicoquimica_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&data_inicio=" + ViewState.Item("data").ToString + "&data_fim=" + ViewState.Item("data_fim").ToString + "&nm_linha=" + ViewState.Item("nm_linha").ToString)

    End Sub
End Class
