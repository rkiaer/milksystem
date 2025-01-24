Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_relatorio_fisicoquimica
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_fisicoquimica.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 46
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
                'ViewState.Item("cd_rota_ini") = Request("cd_rota_ini")
                'ViewState.Item("cd_rota_fim") = Request("cd_rota_fim")
                ViewState.Item("data_fim") = Request("data_fim")
                ViewState.Item("nm_linha") = Request("nm_linha")

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
            'If ViewState.Item("cd_rota_ini") <> "" Then
            '    romaneio.id_linha_ini = Convert.ToInt32(ViewState.Item("cd_rota_ini"))
            'End If
            'If ViewState.Item("cd_rota_fim") <> "" Then
            '    romaneio.id_linha_fim = Convert.ToInt32(ViewState.Item("cd_rota_fim"))
            'End If
            romaneio.data_fim = ViewState.Item("data_fim").ToString
            romaneio.nm_linha = ViewState.Item("nm_linha").ToString

            Me.lbl_data_ini.Text = DateTime.Parse(ViewState.Item("data").ToString).ToString("dd/MM/yyyy")
            Dim estabelecimento As New Estabelecimento(romaneio.id_estabelecimento)
            Me.lbl_estabelecimento.Text = estabelecimento.cd_estabelecimento & " - " & estabelecimento.nm_estabelecimento

            Dim dsAnaliseFisicoQuimica As DataSet = romaneio.getRomaneioAnaliseFisicoQuimica()

            If (dsAnaliseFisicoQuimica.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsAnaliseFisicoQuimica.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            End If

            Dim dsAnaliseFisicoQuimicaComentarios As DataSet = romaneio.getRomaneioAnaliseFisicoQuimicaComentarios()

            If (dsAnaliseFisicoQuimicaComentarios.Tables(0).Rows.Count > 0) Then
                gridComentarios.Visible = True
                gridComentarios.DataSource = Helper.getDataView(dsAnaliseFisicoQuimicaComentarios.Tables(0), ViewState.Item("sortExpression"))
                gridComentarios.DataBind()
            End If

        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim li As Int32

            ' Busca Lacres Entrada e Saída
            'Fran 28/08/2009 i rls 19
            'If Not IsDBNull(gridResults.DataKeys.Item(e.Row.RowIndex).Item("id_romaneio_placa")) Then

            '    Dim romaneiolacre As New RomaneioLacre
            '    Dim llacres_entrada As String
            '    Dim llacres_saida As String
            '    Dim row As DataRow
            '    romaneiolacre.id_romaneio_placa = Convert.ToInt32(gridResults.DataKeys.Item(e.Row.RowIndex).Item("id_romaneio_placa"))
            '    Dim dsRomaneioLacre As DataSet = romaneiolacre.getRomaneioLacresByFilters()
            '    Dim llacreentrada As Label = CType(e.Row.FindControl("lbllacreentrada"), Label)
            '    Dim llacresaida As Label = CType(e.Row.FindControl("lbllacresaida"), Label)

            '    llacres_entrada = ""
            '    llacres_saida = ""
            '    For Each row In dsRomaneioLacre.Tables(0).Rows
            '        If Not IsDBNull(row.Item("nr_lacre_entrada")) Then
            '            llacres_entrada = llacres_entrada & Convert.ToString(row.Item("nr_lacre_entrada")) & ", "
            '        End If
            '        If Not IsDBNull(row.Item("nr_lacre_saida")) Then
            '            llacres_saida = llacres_saida & Convert.ToString(row.Item("nr_lacre_saida")) & ", "
            '        End If

            '    Next
            '    If llacres_entrada <> "" Then
            '        llacres_entrada = Left(llacres_entrada, Len(llacres_entrada) - 2)
            '    End If
            '    If llacres_saida <> "" Then
            '        llacres_saida = Left(llacres_saida, Len(llacres_saida) - 2)
            '    End If

            '    llacreentrada.Text = llacres_entrada
            '    llacresaida.Text = llacres_saida

            'End If
            'Fran 28/08/2009 f rls 19

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
                        'lvalor_analise = dsAnalisesCompartimento.Tables(0).Rows(li).Item("nm_analise_logica")
                        'Fran 21/08/2009 i rls 18 
                        'If dsAnalisesCompartimento.Tables(0).Rows(li).Item("nr_valor") = 1 Then
                        '    lvalor_analise = "Neg"
                        'Else
                        '    lvalor_analise = "Pos"
                        'End If
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
                        'Fran 21/08/2009 f rls 18 


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
                        'fran 06/2019 i
                        'Case "ACIDEZ"
                        '    e.Row.Cells(16).Text = lvalor_analise
                    Case "A.L."
                        e.Row.Cells(16).Text = lvalor_analise
                        'fran 06/2019 f

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

                End Select

            Next

            '03/12/2018  i - fran  esd é importado e nao precisa ser calculado
            '' 20/01/2009 - Rls15 - Formata coluna 17 - ESD - i ESD = EST - MG
            'If IsNumeric(e.Row.Cells(14).Text) And IsNumeric(e.Row.Cells(12).Text) Then
            '    e.Row.Cells(15).Text = FormatNumber(e.Row.Cells(14).Text - e.Row.Cells(12).Text, 2)
            'End If
            '' 20/01/2009 - Rls15 - Formata coluna 17 - ESD - f
            '03/12/2018  f - fran  esd é importado e nao precisa ser calculado

        End If



    End Sub
End Class
