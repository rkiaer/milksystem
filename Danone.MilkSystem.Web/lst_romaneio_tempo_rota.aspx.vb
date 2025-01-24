Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_romaneio_tempo_rota
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        btn_exportar.Visible = True


        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = String.Concat(Me.txt_dt_inicio.Text.Trim, " 00:00:00")
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If

        If Not (txt_dt_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = String.Concat(Me.txt_dt_fim.Text.Trim, " 23:59:59")
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        If opt_periodo.SelectedValue.Equals("1") Then 'se data de entreda
            ViewState.Item("periodo") = "1" 'data de erada  
        Else
            ViewState.Item("periodo") = "2" ' data de transmisaao
        End If

        ViewState.Item("temporota") = cbo_tempo_rota.SelectedValue
        ViewState.Item("tiporomaneio") = cbo_tiporomaneio.SelectedValue
        ViewState.Item("id_romaneio") = txt_id_romaneio.Text
        ViewState.Item("id_transit_point") = txt_id_transit_point.Text
        ViewState.Item("id_transvase") = txt_id_transvase.Text
        ViewState.Item("nm_rota") = txt_nm_linha.Text

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_tempo_rota.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_tempo_rota.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 193
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            ViewState.Item("sortExpression") = ""


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean


    '    If Not (customPage.getFilterValue("exportar3", dt_inicio.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("dt_fim") = customPage.getFilterValue("exportar", dt_inicio.ID)
    '        dt_inicio.Text = ViewState.Item("dt_fim").ToString()
    '    Else
    '        ViewState.Item("dt_fim") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("exportar3", dt_inicio.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("dt_inicio") = customPage.getFilterValue("exportar", dt_inicio.ID)
    '        dt_inicio.Text = ViewState.Item("dt_inicio").ToString()
    '    Else
    '        ViewState.Item("dt_inicio") = String.Empty
    '    End If
    '    'fran 27/11/2009 i chamado 527 Maracanau
    '    If Not (customPage.getFilterValue("exportar3", cbo_estabelecimento.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_estabelecimento") = customPage.getFilterValue("exportar", dt_inicio.ID)
    '        dt_inicio.Text = ViewState.Item("dt_inicio").ToString()
    '    Else
    '        ViewState.Item("dt_inicio") = String.Empty
    '    End If
    '    'fran 27/11/2009 f chamado 527 Maracanau

    '    If Not (customPage.getFilterValue("exportar3", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("exportar3", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("exportar")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio

            If ViewState.Item("periodo") = "1" Then 'data de abertura de romaneio
                If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                    romaneio.dt_hora_entrada_ini = Convert.ToString(ViewState.Item("dt_inicio"))
                End If
                If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                    romaneio.dt_hora_entrada_fim = Convert.ToString(ViewState.Item("dt_fim"))
                End If
            Else 'data de tarnsmissao
                If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                    romaneio.dt_transmissao_ini = Convert.ToString(ViewState.Item("dt_inicio"))
                End If
                If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                    romaneio.dt_transmissao_fim = Convert.ToString(ViewState.Item("dt_fim"))
                End If

            End If

            romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

            Select Case ViewState.Item("tiporomaneio").ToString
                Case "0" 'todos
                    romaneio.st_romaneio_transbordo_nulo = "0"
                    romaneio.st_romaneio_transbordo = "S"
                    romaneio.id_st_romaneio_ini = 1
                    romaneio.id_st_romaneio = 12
                    romaneio.id_transit_point = 0


                Case "N" 'romaneios normais
                    romaneio.st_romaneio_transbordo_nulo = "0" 'traz transbordo nulo
                    romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                    romaneio.id_st_romaneio_ini = 1
                    romaneio.id_st_romaneio = 4
                    romaneio.id_transit_point = -1 'nenhum transit point

                Case "T" 'transbordo
                    romaneio.st_romaneio_transbordo_nulo = "1" ' nao traz transbordo nulo
                    romaneio.st_romaneio_transbordo = "S" 'apenas trannsbordo S
                    romaneio.id_st_romaneio_ini = 1
                    romaneio.id_st_romaneio = 4
                    romaneio.id_transit_point = -1 'nenhum transit point

                Case "PRTP" ' pre romaneio transit point
                    romaneio.st_romaneio_transbordo_nulo = "0" 'traz transbordo nulo
                    romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                    romaneio.id_st_romaneio_ini = 7
                    romaneio.id_st_romaneio = 12
                    romaneio.id_transit_point = -1 'nenhum transit point

                Case "TP" 'trasit point
                    romaneio.st_romaneio_transbordo_nulo = "1" 'nao traz transbordo nulo
                    romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                    romaneio.id_transit_point = 0 'nenhum transit point

                Case "PRTV" ' pre romaneio pre transvase
                    romaneio.st_romaneio_transbordo_nulo = "0" 'traz transbordo nulo
                    romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                    romaneio.id_st_romaneio_ini = 13
                    romaneio.id_st_romaneio = 17
                    romaneio.id_transvase = -1 'nenhum transvase

                Case "TV" 'trasvase
                    romaneio.st_romaneio_transbordo_nulo = "1" 'nao traz transbordo nulo
                    romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                    romaneio.id_transvase = 0 'nenhum transvase

            End Select

            If Not ViewState.Item("id_romaneio").ToString.Equals(String.Empty) Then
                romaneio.id_romaneio = ViewState.Item("id_romaneio") 'nenhum transit point

            End If

            If Not ViewState.Item("id_transit_point").ToString.Equals(String.Empty) Then
                'se informou transit point, nao pode deixar vir os outros tipos de romaneios, entao forca parametros de TP
                romaneio.st_romaneio_transbordo_nulo = "1" 'nao traz transbordo nulo
                romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                romaneio.id_transit_point = ViewState.Item("id_transit_point") 'nenhum transit point

            End If

            If Not ViewState.Item("id_transvase").ToString.Equals(String.Empty) Then
                'se informou transvase, nao pode deixar vir os outros tipos de romaneios, entao forca parametros de TP
                romaneio.st_romaneio_transbordo_nulo = "1" 'nao traz transbordo nulo
                romaneio.st_romaneio_transbordo = "N" 'retira trannsbordo N
                romaneio.id_transvase = ViewState.Item("id_transvase") 'nenhum transit point

            End If
            romaneio.nm_linha = ViewState.Item("nm_rota").ToString

            'Buscar dados para percentuaus... 
            romaneio.nr_tempo_rota_ini = ViewState.Item("temporota").ToString

            Dim dstemporotasintetico As DataSet = romaneio.getRomaneioTempoRotaSintetico
            Dim lrow As DataRow
            Dim lnr_romaneios_1 As Decimal = 0
            Dim lnr_romaneios_2 As Decimal = 0
            Dim lnr_romaneios_3 As Decimal = 0
            Dim lnr_romaneios_total As Decimal = 0

            For Each lrow In dstemporotasintetico.Tables(0).Rows
                Select Case lrow.Item("id_tempo_rota_minutos")
                    Case "1" 'ate 720 minutos
                        lnr_romaneios_1 = lrow.Item("nr_romaneios")
                    Case "2" 'entre 721 e 1200
                        lnr_romaneios_2 = lrow.Item("nr_romaneios")
                    Case "3" 'acima 1200
                        lnr_romaneios_3 = lrow.Item("nr_romaneios")
                End Select
            Next
            lnr_romaneios_total = lnr_romaneios_1 + lnr_romaneios_2 + lnr_romaneios_3

            If lnr_romaneios_1 > 0 Then
                lbl_tempo_rota_green.Text = FormatPercent(lnr_romaneios_1 / lnr_romaneios_total, 2).ToString
            Else
                lbl_tempo_rota_green.Text = "00,00%"
            End If

            If lnr_romaneios_2 > 0 Then
                lbl_tempo_rota_yellow.Text = FormatPercent(lnr_romaneios_2 / lnr_romaneios_total, 2).ToString
            Else
                lbl_tempo_rota_yellow.Text = "00,00%"
            End If
            If lnr_romaneios_3 > 0 Then
                lbl_tempo_rota_red.Text = FormatPercent(lnr_romaneios_3 / lnr_romaneios_total, 2).ToString
            Else
                lbl_tempo_rota_red.Text = "00,00%"
            End If

            'acerta variavel de tempo rota para buscar os dados do grid
            Select Case ViewState.Item("temporota").ToString
                Case "0" 'sem seleçao
                    romaneio.nr_tempo_rota_ini = 0
                    romaneio.nr_tempo_rota_fim = 0

                Case "1" 'ate 12 horas
                    romaneio.nr_tempo_rota_ini = 0
                    romaneio.nr_tempo_rota_fim = 720

                Case "2" 'entre 12:01 e 20 horas
                    romaneio.nr_tempo_rota_ini = 721
                    romaneio.nr_tempo_rota_fim = 1200

                Case "3" 'acima de 20 horas
                    romaneio.nr_tempo_rota_ini = 1201
                    romaneio.nr_tempo_rota_fim = 99999
            End Select

            Dim dsRomaneios As DataSet = romaneio.getRomaneioTempoRota()
 
            If (dsRomaneios.Tables(0).Rows.Count > 0) Then
                pnl_controle_rota.Visible = True
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsRomaneios.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

            Else
                pnl_controle_rota.Visible = False

                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then
            Try
                Dim ds_tempo_rota_minutos As Label = CType(e.Row.FindControl("lbl_ds_tempo_rota_minutos"), Label)

                Select Case CDec(ds_tempo_rota_minutos.Text)
                    Case Is <= 720 ' Até 12 horas (720 minutos)
                        e.Row.Cells(14).BackColor = System.Drawing.Color.FromName("#00C000") 'verde coluna tempo rota
                    Case Is <= 1200
                        e.Row.Cells(14).BackColor = System.Drawing.Color.Yellow 'amarelo coluna tempo rota
                    Case Is > 1200
                        e.Row.Cells(14).BackColor = System.Drawing.Color.Red 'vermelho coluna tempo rota
                End Select


            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            'Case "id_tecnico"
            '    If (ViewState.Item("sortExpression")) = "id_tecnico asc" Then
            '        ViewState.Item("sortExpression") = "id_tecnico desc"
            '    Else
            '        ViewState.Item("sortExpression") = "id_tecnico asc"
            '    End If



        End Select

        loadData()

    End Sub






    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub



    Protected Sub gridResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = String.Concat(Me.txt_dt_inicio.Text.Trim, " 00:00:00")
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If

        If Not (txt_dt_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = String.Concat(Me.txt_dt_fim.Text.Trim, " 23:59:59")
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        If opt_periodo.SelectedValue.Equals("1") Then 'se data de entreda
            ViewState.Item("periodo") = "1" 'data de erada  
        Else
            ViewState.Item("periodo") = "2" ' data de transmisaao
        End If

        ViewState.Item("temporota") = cbo_tempo_rota.SelectedValue
        ViewState.Item("tiporomaneio") = cbo_tiporomaneio.SelectedValue
        ViewState.Item("id_romaneio") = txt_id_romaneio.Text
        ViewState.Item("id_transit_point") = txt_id_transit_point.Text
        ViewState.Item("id_transvase") = txt_id_transvase.Text
        ViewState.Item("nm_rota") = txt_nm_linha.Text

        loadData()

        If gridResults.Rows.Count.ToString + 1 < 65536 Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 193
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            Response.Redirect("frm_romaneio_tempo_rota_excel.aspx?dt_fim=" + ViewState.Item("dt_fim").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&periodo=" + ViewState.Item("periodo").ToString + "&temporota=" + ViewState.Item("temporota").ToString + "&tiporomaneio=" + ViewState.Item("tiporomaneio").ToString + "&id_romaneio=" + ViewState.Item("id_romaneio").ToString + "&id_transit_point=" + ViewState.Item("id_transit_point").ToString + "&id_transvase=" + ViewState.Item("id_transvase").ToString + "&nm_rota=" + ViewState.Item("nm_rota").ToString)
        Else
            messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
        End If
    End Sub


End Class

