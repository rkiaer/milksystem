Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_pre_romaneio_transvase_consulta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_pre_romaneio_transvase_consulta.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                ViewState.Item("placa_ativa") = 0 'Assume que a placa ativa é a da 1a aba

                Dim romaneio As New Romaneio(ViewState.Item("id_romaneio"))

                loadData()
            Else
                loadFilters()
                If ViewState.Item("id_romaneio").Equals(String.Empty) Then
                    messageControl.Alert("Há problemas na passagem de parametros. A tela não pode ser montada!")
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim romaneio As New Romaneio(id_romaneio)

            tr_pnl_nota_fiscal_transferencia.Visible = False
            'swe disponiovel ou em uso ou em usao completo
            If romaneio.id_st_romaneio = 14 OrElse romaneio.id_st_romaneio = 16 OrElse romaneio.id_st_romaneio = 17 Then
                tr_pnl_transit_point.Visible = True
            Else
                tr_pnl_transit_point.Visible = False
            End If

            lbl_romaneio.Text = romaneio.id_romaneio.ToString
            lbl_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            If Not romaneio.ds_estabelecimento Is Nothing Then
                lbl_estabelecimento.Text = romaneio.ds_estabelecimento.ToString
            End If

            If Not romaneio.ds_linha Is Nothing Then
                lbl_linha.Text = romaneio.ds_linha.ToString
            End If
            lbl_tipoleite.Text = romaneio.nm_item.ToString
            lbl_transportador.Text = romaneio.ds_transportador.ToString
            lbl_motorista.Text = romaneio.nm_motorista
            lbl_cd_cnh.Text = romaneio.cd_cnh
            lbl_placa.Text = romaneio.ds_placa.ToString
            lbl_dt_entrada.Text = Format(DateTime.Parse(romaneio.dt_hora_entrada), "dd/MM/yyyy HH:mm").ToString
            If Not (romaneio.dt_hora_saida Is Nothing) Then
                If Not (romaneio.dt_hora_saida.ToString.Equals(String.Empty)) Then
                    lbl_dt_saida.Text = Format(DateTime.Parse(romaneio.dt_hora_saida), "dd/MM/yyyy HH:mm").ToString
                End If
            End If
            lbl_tara.Text = FormatNumber(romaneio.nr_tara, 0).ToString

            lbl_caderneta.Text = romaneio.nr_caderneta.ToString
            hl_nr_caderneta.Text = romaneio.nr_caderneta.ToString
            hl_nr_caderneta.NavigateUrl = String.Format("frm_caderneta.aspx?nr_caderneta={0}", romaneio.nr_caderneta)

            lbl_peso_liquido_caderneta.Text = FormatNumber(romaneio.nr_peso_liquido_caderneta, 0).ToString
            lbl_litros_caderneta.Text = lbl_peso_liquido_caderneta.Text
            lbl_litros_rejeitados.Text = FormatNumber(romaneio.nr_peso_liquido_caderneta - romaneio.nr_total_litros_tp_disponivel, 0).ToString
            lbl_nr_volume_disponivel_tp.Text = FormatNumber(romaneio.nr_total_litros_tp_disponivel, 0).ToString
            lbl_nr_volume_transferido_tp.Text = FormatNumber(romaneio.nr_total_litros_tp_transferidos, 0).ToString
            lbl_litros_reais.Text = FormatNumber(romaneio.nr_total_litros_tp_disponivel - romaneio.nr_total_litros_tp_transferidos, 0).ToString

            'fran 12/2017 i
            lbl_nr_pesagem_inicial.Text = FormatNumber(romaneio.nr_pesagem_inicial, 0).ToString
            If Not romaneio.dt_pesagem_inicial Is Nothing Then
                lbl_dt_pesagem_inicial.Text = Format(DateTime.Parse(romaneio.dt_pesagem_inicial), "dd/MM/yyyy HH:mm")
            End If
            If Not romaneio.dt_pesagem_intermediaria Is Nothing Then
                lbl_dt_pesagem_intermediaria.Text = Format(DateTime.Parse(romaneio.dt_pesagem_intermediaria), "dd/MM/yyyy HH:mm")
            End If
            lbl_nr_pesagem_intermediaria.Text = FormatNumber(romaneio.nr_pesagem_intermediaria, 0).ToString
            If Not romaneio.dt_pesagem_final Is Nothing Then
                lbl_dt_pesagem_final.Text = Format(DateTime.Parse(romaneio.dt_pesagem_final), "dd/MM/yyyy HH:mm")
            End If
            lbl_nr_pesagem_final.Text = romaneio.nr_pesagem_final

            If Not lbl_nr_pesagem_final.Text.Equals(String.Empty) Then
                lbl_nr_peso_liquido_balanca.Text = CLng(CDbl(lbl_nr_pesagem_inicial.Text) - CDbl(lbl_nr_pesagem_final.Text))
                lbl_litros_balanca.Text = Decimal.Truncate(lbl_nr_peso_liquido_balanca.Text)
            End If

            If lbl_nr_pesagem_final.Text > 0 Then
                'lbl_nr_peso_liquido_balanca.Text = CLng(CDec(lbl_nr_pesagem_inicial.Text) - CDec(FormatNumber(lbl_nr_pesagem_final.Text, 0)))
                Dim batch As New ExportacaoBatch
                batch.dt_referencia = DateAdd(DateInterval.Month, -1, CDate(String.Concat("01/", DateTime.Parse(Now()).ToString("MM/yyyy"))))
                Dim mediadensidade As Decimal = batch.getBatchDensidade
                'Dim mediadensidade As Decimal = romaneio.getRomaneioCompartimentoMediaDens()
                lbl_litros_balanca.Text = Decimal.Truncate(CDec(lbl_nr_peso_liquido_balanca.Text) / mediadensidade)
                lbl_diferenca.Text = Decimal.Truncate((lbl_litros_caderneta.Text) - CDec(lbl_litros_balanca.Text))
                Select Case Sign(CDec(lbl_diferenca.Text))
                    Case -1 'se negativo, litros reais está com uma diferença maior que a caderneta, então muda o sinal
                        lbl_diferenca.Text = +Abs(Decimal.Truncate(CDec(lbl_diferenca.Text)))
                        lbl_diferenca_percentual.Text = FormatPercent(+Abs(CDec(lbl_diferenca.Text) / CDec(lbl_litros_caderneta.Text)))
                    Case 1  'se positivo, caderneta maior que o real
                        lbl_diferenca.Text = -Decimal.Truncate(CDec(lbl_diferenca.Text))
                        lbl_diferenca_percentual.Text = FormatPercent(-Abs(CDec(lbl_diferenca.Text) / CDec(lbl_litros_caderneta.Text)))
                End Select
            End If
            'fran 12/2017 f

            'fran tempo rota dez/2018 i
            'SE for pre romaneio transbordo nao deixa visualizar tempo rota
            tr_tempo_rota.Visible = True 'fran tempo rota dez/2018

            Dim dstemporota As DataSet = romaneio.getRomaneioTempoRotabyRomaneio
            If dstemporota.Tables(0).Rows.Count > 0 Then
                lbl_tempo_rota.Text = dstemporota.Tables(0).Rows(0).Item("ds_tempo_rota").ToString
                Dim lnr_tempo_rota As Decimal = dstemporota.Tables(0).Rows(0).Item("ds_tempo_rota_minutos")
                Select Case lnr_tempo_rota
                    Case Is <= 720 ' Até 12 horas (720 minutos)
                        lbl_tempo_rota_descr.Text = "Até 12 Horas"
                        lbl_tempo_rota_descr.CssClass = "text temporotagreen"
                        img_tempo_rota.ImageUrl = "~/img/icon_status_verde.gif"

                    Case Is <= 1200
                        lbl_tempo_rota_descr.Text = "De 12:01 à 20:00 Horas"
                        lbl_tempo_rota_descr.CssClass = "text temporotayellow"
                        img_tempo_rota.ImageUrl = "~/img/icon_status_amarelo.gif"

                    Case Is > 1200
                        lbl_tempo_rota_descr.Text = "Acima de 20 Horas"
                        lbl_tempo_rota_descr.CssClass = "text temporotared"
                        img_tempo_rota.ImageUrl = "~/img/icon_status_vermelho.gif"
                End Select
            Else 'se nao encontrou, tempo rota esta com valor negativo, ou sej adata coleta é maior que data entrada romaneio
                lbl_tempo_rota_descr.Text = "SEM TEMPO DE ROTA"
                lbl_tempo_rota_descr.CssClass = "text temporotadesabilitado"
                img_tempo_rota.ImageUrl = "~/img/icon_status_cinza.gif"
                lbl_tempo_rota.Text = String.Empty
            End If

            Dim dstransitpont As DataSet = romaneio.getPreRomaneioETransvase()

            'se tem linhas em compartimento
            If (dstransitpont.Tables(0).Rows.Count > 0) Then
                gridTransitPoint.Visible = True
                gridTransitPoint.DataSource = Helper.getDataView(dstransitpont.Tables(0), "")
                gridTransitPoint.DataBind()
            Else
                Dim dr As DataRow = dstransitpont.Tables(0).NewRow()
                dstransitpont.Tables(0).Rows.InsertAt(dr, 0)
                gridTransitPoint.Visible = True
                gridTransitPoint.DataSource = Helper.getDataView(dstransitpont.Tables(0), "")
                gridTransitPoint.DataBind()
                gridTransitPoint.Rows(0).Cells.Clear()
                gridTransitPoint.Rows(0).Cells.Add(New TableCell())
                gridTransitPoint.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridTransitPoint.Rows(0).Cells(0).Text = "Não existe nenhum Transit Point associado a este Pré-Romaneio!"
                gridTransitPoint.Rows(0).Cells(0).ColumnSpan = 4

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub atualizarResumo()

        Try

            lbl_nr_peso_liquido_balanca.Text = CLng(CDec(lbl_nr_pesagem_inicial.Text) - CDec(FormatNumber(lbl_nr_pesagem_final.Text, 0)))
            Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

            Dim batch As New ExportacaoBatch
            batch.dt_referencia = DateAdd(DateInterval.Month, -1, CDate(String.Concat("01/", DateTime.Parse(Now()).ToString("MM/yyyy"))))
            Dim mediadensidade As Decimal = batch.getBatchDensidade
            'Dim mediadensidade As Decimal = romaneio.getRomaneioCompartimentoMediaDens()
            lbl_litros_balanca.Text = Decimal.Truncate(CDec(lbl_nr_peso_liquido_balanca.Text) / mediadensidade)
            lbl_diferenca.Text = Decimal.Truncate((lbl_litros_caderneta.Text) - CDec(lbl_litros_balanca.Text))
            Select Case Sign(CDec(lbl_diferenca.Text))
                Case -1 'se negativo, litros reais está com uma diferença maior que a caderneta, então muda o sinal
                    lbl_diferenca.Text = +Abs(Decimal.Truncate(CDec(lbl_diferenca.Text)))
                    lbl_diferenca_percentual.Text = FormatPercent(+Abs(CDec(lbl_diferenca.Text) / CDec(lbl_litros_caderneta.Text)))
                Case 1  'se positivo, caderneta maior que o real
                    lbl_diferenca.Text = -Decimal.Truncate(CDec(lbl_diferenca.Text))
                    lbl_diferenca_percentual.Text = FormatPercent(-Abs(CDec(lbl_diferenca.Text) / CDec(lbl_litros_caderneta.Text)))
            End Select


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadplacas()

    '    Try

    '        Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
    '        Dim rplaca As New RomaneioPlaca
    '        Dim placa As Integer

    '        rplaca.id_romaneio = id_romaneio

    '        Dim dsplacas As DataSet = rplaca.getRomaneioPlacasByRomaneio()

    '        If (dsplacas.Tables(0).Rows.Count > 0) Then
    '            For placa = 0 To dsplacas.Tables(0).Rows.Count - 1
    '                With dsplacas.Tables(0).Rows(placa)
    '                    Select Case placa
    '                        Case 0
    '                            Me.btn_placa1.Text = .Item("ds_placa")
    '                            Me.btn_placa1.CommandArgument = .Item("id_romaneio_placa")
    '                        Case 1
    '                            Me.pnl_placa2.Visible = True
    '                            Me.btn_placa2.Visible = True
    '                            Me.btn_placa2.Text = .Item("ds_placa")
    '                            Me.btn_placa2.CommandArgument = .Item("id_romaneio_placa")
    '                        Case 2
    '                            Me.pnl_placa3.Visible = True
    '                            Me.btn_placa3.Visible = True
    '                            Me.btn_placa3.Text = .Item("ds_placa")
    '                            Me.btn_placa3.CommandArgument = .Item("id_romaneio_placa")
    '                        Case 3
    '                            Me.pnl_placa4.Visible = True
    '                            Me.btn_placa4.Visible = True
    '                            Me.btn_placa4.Text = .Item("ds_placa")
    '                            Me.btn_placa4.CommandArgument = .Item("id_romaneio_placa")
    '                        Case 4
    '                            Me.pnl_placa4.Visible = True
    '                            Me.btn_placa5.Visible = True
    '                            Me.btn_placa5.Text = .Item("ds_placa")
    '                            Me.btn_placa5.CommandArgument = .Item("id_romaneio_placa")
    '                    End Select
    '                End With
    '            Next
    '            loadabasplacas()
    '        Else
    '            messageControl.Alert("Não há placas cadastradas para este romaneio. Há problemas na passagem de parametros.")
    '        End If



    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try


    'End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_pre_romaneio_transvase_consulta.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_pre_romaneio_transvase_consulta.aspx")


    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("frm_pre_trans_consulta", "id_romaneio", ViewState.Item("id_romaneio").ToString)
            customPage.setFilter("frm_pre_trans_consulta", "placa_ativa", ViewState.Item("placa_ativa").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("frm_pre_trans_consulta", "id_romaneio").Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("frm_pre_trans_consulta", "id_romaneio")
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If

        'If Not (customPage.getFilterValue("frm_r_consulta", "placa_ativa").Equals(String.Empty)) Then
        'hasFilters = True
        'ViewState.Item("placa_ativa") = customPage.getFilterValue("frm_r_consulta", "placa_ativa")
        'Else
        ViewState.Item("placa_ativa") = 0
        'End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("frm_pre_consulta")
        End If

    End Sub


    Protected Sub lk_Placas_Comp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_Placas_Comp.Click
        saveFilters()
        Response.Redirect("frm_romaneio_consulta_placa.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString + "&tela=frm_pre_romaneio_transvase_consulta.aspx")

    End Sub
End Class
