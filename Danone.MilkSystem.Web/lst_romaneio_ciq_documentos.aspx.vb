Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_romaneio_ciq_documentos
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_ciq_documentos.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 220
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim estabel As New Estabelecimento
            estabel.id_situacao = 1
            estabel.st_recepcao_leite = "S"
            Dim dsestabel As DataSet = estabel.getEstabelecimentoByFilters
            cbo_estabelecimento.DataSource = Helper.getDataView(dsestabel.Tables(0), "nm_estabelecimento")
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_estabelecimento.Items.Insert(cbo_estabelecimento.Items.Count, New ListItem("Boa Esperança", "77"))

            loadFilters()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        If Not (txt_dt_hora_entrada_ini.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = txt_dt_hora_entrada_ini.Text.Trim()
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If
        If Not (txt_dt_hora_entrada_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = txt_dt_hora_entrada_fim.Text.Trim()
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If
        If Not (cbo_estabelecimento.SelectedValue = 0) Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        loadData()
        'se o grid tiver mais que 65536  linhas não podemos exportar
        If gridResults.Rows.Count = 0 Then
            messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
        Else
            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 8 'exporta~ção
                usuariolog.id_menu_item = 110
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Response.Redirect("frm_relacao_CIQ_CIQPEmitidos_excel.aspx?emitente=" + ViewState.Item("emitente").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento"))
            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")  ' Adri
            End If
        End If

    End Sub
    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Not (txt_dt_hora_entrada_ini.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = txt_dt_hora_entrada_ini.Text.Trim()
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If
        ViewState.Item("dt_fim") = Me.txt_dt_hora_entrada_fim.Text.Trim

        If (txt_dt_hora_entrada_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = ViewState.Item("dt_inicio")
        End If

        If Not (cbo_estabelecimento.SelectedValue = 0) Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        ViewState.Item("id_romaneio") = txt_id_romaneio.Text
        ViewState.Item("id_romaneio_compartimento") = txt_nr_ciq.Text
        ViewState.Item("emitente") = cbo_emitente.SelectedValue
        ViewState.Item("id_ciq") = cbo_ds_tipo_incidente.SelectedValue

        ViewState.Item("sortExpression") = ""

        Me.pnl_romaneio.Visible = False  ' Tira painel de consultas anteriores
        'limpa detalhe
        ViewState.Item("id_romaneio_detalhe") = 0
        ViewState.Item("id_romaneio_compartimento_detalhe") = 0
        ViewState.Item("id_romaneio_uproducao_detalhe") = 0
        ViewState.Item("id_ciq_detalhe") = 0


        loadData()

    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio

            romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            romaneio.data_inicio = ViewState.Item("dt_inicio").ToString
            romaneio.data_fim = ViewState.Item("dt_fim").ToString

            If Trim(ViewState.Item("id_romaneio")) <> "" Then
                romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            End If

            romaneio.id_ciq = ViewState.Item("id_ciq").ToString

            If Trim(ViewState.Item("id_romaneio_compartimento")) <> "" Then
                romaneio.id_romaneio_compartimento = ViewState.Item("id_romaneio_compartimento").ToString
            End If

            Dim dsromaneiociq As DataSet
            If ViewState.Item("emitente") = "P" Then
                dsromaneiociq = romaneio.getRomaneioCiqDocumentosGrid
            Else
                dsromaneiociq = romaneio.getRomaneioCiqDocumentosGridCooperativa

            End If

            If (dsromaneiociq.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsromaneiociq.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


            'Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_CIQ_CIQPEmitidos.aspx?dt_inicio={0}", Me.txt_dt_hora_entrada_ini.Text) & String.Format("&dt_fim={0}", Me.txt_dt_hora_entrada_fim.Text) & String.Format("&id_estabelecimento={0}", Me.cbo_estabelecimento.SelectedValue) & String.Format("&emitente={0}", Me.ViewState.Item("emitente").ToString)
            'Me.hl_imprimir.Enabled = True

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_ciq_documentos.aspx?st_incluirlog=N")

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "editar"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
                Dim lbl_id_romaneio_compartimento As Label = CType(row.FindControl("lbl_id_romaneio_compartimento"), Label) '
                Dim lbl_id_romaneio_uproducao As Label = CType(row.FindControl("lbl_id_romaneio_uproducao"), Label) '
                Dim lbl_id_ciq As Label = CType(row.FindControl("lbl_id_ciq"), Label) '

                Dim idromup As String = lbl_id_romaneio_uproducao.Text.ToString

                If idromup.Equals(String.Empty) Then
                    idromup = "0"
                End If

                saveFilters()

                Response.Redirect("frm_romaneio_ciq_documentos.aspx?id_ciq=" + lbl_id_ciq.Text + "&id_romaneio_compartimento=" + lbl_id_romaneio_compartimento.Text + "&id_romaneio_uproducao=" + idromup)
            Case "select"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

                Dim lbl_id_romaneio As Label = CType(row.FindControl("lbl_id_romaneio"), Label) '
                Dim lbl_id_romaneio_compartimento As Label = CType(row.FindControl("lbl_id_romaneio_compartimento"), Label) '
                Dim lbl_id_romaneio_uproducao As Label = CType(row.FindControl("lbl_id_romaneio_uproducao"), Label) '
                Dim lbl_id_ciq As Label = CType(row.FindControl("lbl_id_ciq"), Label) '
                Dim lbl_st_responsavel_ciq As Label = CType(row.FindControl("lbl_st_responsavel_ciq"), Label) '

                ViewState.Item("id_romaneio_compartimento_detalhe") = Convert.ToInt32(lbl_id_romaneio_compartimento.Text)
                ViewState.Item("id_romaneio_detalhe") = Convert.ToInt32(lbl_id_romaneio.Text)
                ViewState.Item("id_romaneio_uproducao_detalhe") = lbl_id_romaneio_uproducao.Text
                ViewState.Item("id_ciq_detalhe") = lbl_id_ciq.Text
                ViewState.Item("st_responsavel_ciq_detalhe") = lbl_st_responsavel_ciq.Text

                tr_detalhes.Visible = True
                pnl_romaneio.Visible = True
                loadDetalheRomaneio()


                'Response.Redirect("frm_relacao_CIQ_CIQPEmitidos_excel.aspx?emitente=" + ViewState.Item("emitente").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento"))

        End Select

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
     And e.Row.RowType <> DataControlRowType.Footer _
     And e.Row.RowType <> DataControlRowType.Pager) Then
            Dim lbl_id_romaneio As Label = CType(e.Row.FindControl("lbl_id_romaneio"), Label) '
            Dim lbl_id_romaneio_compartimento As Label = CType(e.Row.FindControl("lbl_id_romaneio_compartimento"), Label) '
            Dim lbl_id_romaneio_uproducao As Label = CType(e.Row.FindControl("lbl_id_romaneio_uproducao"), Label) '
            Dim lbl_id_ciq As Label = CType(e.Row.FindControl("lbl_id_ciq"), Label) '
            Dim lbl_id_transportador As Label = CType(e.Row.FindControl("lbl_id_transportador"), Label) '
            Dim lbl_st_responsavel_ciq As Label = CType(e.Row.FindControl("lbl_st_responsavel_ciq"), Label) '

            Dim hl_nr_incidente As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_nr_incidente"), System.Web.UI.WebControls.HyperLink)

            Select Case lbl_id_ciq.Text
                Case "1"
                    If (Not hl_nr_incidente.Text.ToString().Equals(String.Empty)) Then
                        hl_nr_incidente.NavigateUrl = String.Format("frm_relatorio_CIQ.aspx?id_romaneio_compartimento={0}", lbl_id_romaneio_compartimento.Text)
                    End If

                Case "2"
                    hl_nr_incidente.Text = lbl_id_romaneio_uproducao.Text
                    hl_nr_incidente.NavigateUrl = String.Format("frm_relatorio_CIQP.aspx?id_romaneio_uproducao={0}", lbl_id_romaneio_uproducao.Text)

                Case "3"
                    hl_nr_incidente.Text = String.Concat(lbl_id_romaneio_compartimento.Text, lbl_id_transportador.Text)
                    hl_nr_incidente.NavigateUrl = String.Format("frm_relatorio_CIQT.aspx?id_romaneio_compartimento={0}", lbl_id_romaneio_compartimento.Text)

                Case "4"
                    hl_nr_incidente.Text = lbl_id_romaneio_compartimento.Text
                    hl_nr_incidente.NavigateUrl = String.Format("frm_relatorio_CIQ.aspx?id_romaneio_compartimento={0}", lbl_id_romaneio_compartimento.Text)


            End Select
            ''se o romaneio clicado para consistencia é igual ao montado, troca cor de fi=undo
            'If ViewState.Item("id_romaneio_compartimento_detalhe") > 0 AndAlso ViewState.Item("id_romaneio_compartimento_detalhe").ToString = (gridResults.DataKeys.Item(e.Row.RowIndex).Value).ToString Then
            '    e.Row.ForeColor = Drawing.Color.Red
            '    e.Row.Font.Size = FontUnit.XSmall

            'End If


        End If
    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub
    Private Sub loadDetalheRomaneio()

        Try

            Dim romaneio As New Romaneio(ViewState.Item("id_romaneio_detalhe"))

            'se fot boa esperanca é pre romaneio
            If cbo_estabelecimento.SelectedValue = 77 Then
                lbl_romaneio.Text = "Pré Romaneio:"
            Else
                lbl_romaneio.Text = "Romaneio:"
            End If

            lbl_id_romaneio.Text = ViewState.Item("id_romaneio_detalhe").ToString
            lbl_situacao.Text = romaneio.nm_st_romaneio.ToString


            If cbo_emitente.SelectedValue = "C" Then
                lbl_rota.Text = String.Empty
                lbl_nome.Text = String.Concat("Cooperativa: ", romaneio.nm_cooperativa)
                lbl_nome2.Text = String.Concat("Transp.: ", romaneio.nm_transportador)
            Else
                lbl_caderneta.Text = String.Concat("Caderneta: ", romaneio.nr_caderneta.ToString)
                lbl_rota.Text = String.Concat("Rota: ", romaneio.nm_linha.ToString)
                Select Case ViewState.Item("id_ciq_detalhe")
                    Case "1", "3", "4" 'CIQ, cuqt ou ciqr
                        lbl_nome.Text = String.Concat("Transp.: ", romaneio.nm_transportador)
                        lbl_nome2.Text = String.Empty

                    Case "2" 'CIQP
                        Dim romup As New Romaneio_Comp_UProducao(ViewState.Item("id_romaneio_uproducao_detalhe"))
                        lbl_nome2.Text = String.Concat("Transp.: ", romaneio.nm_transportador)
                        lbl_nome.Text = String.Concat("Prod.: ", romup.nm_pessoa.ToString, " - Prop.: ", romup.id_propriedade.ToString)

                End Select
            End If

            'Se romaneio de transit point
            If romaneio.id_transit_point > 0 Then
                lbl_transit.Text = String.Concat("Transit Point: ", romaneio.id_transit_point.ToString)
                lbl_caderneta.Text = String.Empty
            Else
                lbl_transit.Text = String.Empty
            End If
            'Se romaneio de transvase
            If romaneio.id_transvase > 0 Then
                lbl_transit.Text = String.Concat("Transvase: ", romaneio.id_transvase.ToString)
                lbl_caderneta.Text = String.Empty
            Else
                If Not romaneio.id_transit_point > 0 Then
                    'so limpa campo se nao tem transit point nem transvase
                    lbl_transit.Text = String.Empty
                End If
            End If
            'Se romaneio transbordo
            If romaneio.st_romaneio_transbordo = "S" Then
                lbl_transbordo.Text = "Transbordo: SIM"
                lbl_caderneta.Text = String.Empty
            Else
                lbl_transbordo.Text = "Transbordo: NÃO"
            End If


            lbl_nr_ciq.Text = String.Concat("Nr CIQ: ", ViewState.Item("id_romaneio_compartimento_detalhe").ToString)

            If ViewState.Item("st_responsavel_ciq_detalhe") = "C" Then
                lbl_resp.Text = "Resp.: Cooperativa"
            Else
                If ViewState.Item("st_responsavel_ciq_detalhe") = "P" Then
                    lbl_resp.Text = "Resp.: Produtor"
                Else
                    If ViewState.Item("st_responsavel_ciq_detalhe") = "T" Then
                        lbl_resp.Text = "Resp.: Transportador"
                    Else
                        If ViewState.Item("st_responsavel_ciq_detalhe") = "R" Then
                            lbl_resp.Text = "Resp.: Recepção"

                        End If

                    End If
                End If
            End If
            pnl_romaneio.Visible = True

            romaneio.id_romaneio_compartimento = ViewState.Item("id_romaneio_compartimento_detalhe").ToString
            romaneio.id_ciq = ViewState.Item("id_ciq_detalhe").ToString
            If romaneio.id_ciq = 2 Then
                romaneio.id_romaneio_uproducao = ViewState.Item("id_romaneio_uproducao_detalhe").ToString
            Else
                romaneio.id_romaneio_uproducao = 0
            End If

            Dim dsromaneiodoc As DataSet = romaneio.getRomaneioCiqDocumentosAnexados

            If dsromaneiodoc.Tables(0).Rows.Count > 0 Then
                gridDoc.DataSource = Helper.getDataView(dsromaneiodoc.Tables(0), "")
                gridDoc.DataBind()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("lst_romciqdoctos", txt_id_romaneio.ID, ViewState.Item("id_romaneio").ToString)
            customPage.setFilter("lst_romciqdoctos", txt_nr_ciq.ID, ViewState.Item("id_romaneio_compartimento").ToString)
            customPage.setFilter("lst_romciqdoctos", cbo_ds_tipo_incidente.ID, ViewState.Item("id_ciq").ToString)
            customPage.setFilter("lst_romciqdoctos", txt_dt_hora_entrada_ini.ID, ViewState.Item("dt_inicio").ToString)
            customPage.setFilter("lst_romciqdoctos", txt_dt_hora_entrada_fim.ID, ViewState.Item("dt_fim").ToString)
            customPage.setFilter("lst_romciqdoctos", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("lst_romciqdoctos", cbo_emitente.ID, ViewState.Item("emitente").ToString)
            customPage.setFilter("lst_romciqdoctos", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("lst_romciqdoctos", txt_id_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("lst_romciqdoctos", txt_id_romaneio.ID)
            txt_id_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If
        If Not (customPage.getFilterValue("lst_romciqdoctos", txt_nr_ciq.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio_compartimento") = customPage.getFilterValue("lst_romciqdoctos", txt_nr_ciq.ID)
            txt_nr_ciq.Text = ViewState.Item("id_romaneio_compartimento").ToString()
        Else
            ViewState.Item("id_romaneio_compartimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("lst_romciqdoctos", cbo_ds_tipo_incidente.ID).Equals(String.Empty)) Then
            If Not (customPage.getFilterValue("lst_romciqdoctos", cbo_ds_tipo_incidente.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_ciq") = customPage.getFilterValue("lst_romciqdoctos", cbo_ds_tipo_incidente.ID)
                cbo_ds_tipo_incidente.SelectedValue = ViewState.Item("id_ciq").ToString()
            Else
                ViewState.Item("id_ciq") = "0"
                cbo_ds_tipo_incidente.SelectedValue = "0"
            End If
        Else
            ViewState.Item("id_ciq") = "0"
            cbo_ds_tipo_incidente.SelectedValue = "0"
        End If



        If Not (customPage.getFilterValue("lst_romciqdoctos", txt_dt_hora_entrada_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_inicio") = customPage.getFilterValue("lst_romciqdoctos", txt_dt_hora_entrada_ini.ID)
            txt_dt_hora_entrada_ini.Text = ViewState.Item("dt_inicio").ToString()
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If

        If Not (customPage.getFilterValue("lst_romciqdoctos", txt_dt_hora_entrada_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_fim") = customPage.getFilterValue("lst_romciqdoctos", txt_dt_hora_entrada_fim.ID)
            txt_dt_hora_entrada_fim.Text = ViewState.Item("dt_fim").ToString()
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If

        If Not (customPage.getFilterValue("lst_romciqdoctos", cbo_emitente.ID).Equals(String.Empty)) Then

            If Not (customPage.getFilterValue("lst_romciqdoctos", cbo_emitente.ID).Equals("P")) Then
                hasFilters = True
                ViewState.Item("emitente") = customPage.getFilterValue("lst_romciqdoctos", cbo_emitente.ID)
                cbo_emitente.SelectedValue = ViewState.Item("emitente").ToString()
            Else
                ViewState.Item("emitente") = "P"
            End If
        Else

            ViewState.Item("emitente") = "P"
        End If

        If Not (customPage.getFilterValue("lst_romciqdoctos", cbo_estabelecimento.ID).Equals(String.Empty)) Then

            If Not (customPage.getFilterValue("lst_romciqdoctos", cbo_estabelecimento.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_estabelecimento") = customPage.getFilterValue("lst_romciqdoctos", cbo_estabelecimento.ID)
                cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
            Else
                ViewState.Item("id_estabelecimento") = "0"
            End If
        Else
            ViewState.Item("id_estabelecimento") = "0"
        End If


        If Not (customPage.getFilterValue("lst_romciqdoctos", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("lst_romciqdoctos", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("lst_romciqdoctos")
            'Else
            '    'Se veio de outra tela
            '    If Not (Request("id_romaneio") Is Nothing) Then
            '        ViewState.Item("id_romaneio") = Request("id_romaneio")
            '        loadData()
            '    End If
        End If

    End Sub

    Protected Sub gridDoc_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridDoc.PageIndexChanging
        gridDoc.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub

    Protected Sub gridDoc_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridDoc.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then
            Dim hl_download As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_download"), System.Web.UI.WebControls.HyperLink)
            Dim hl_download_cadastro As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_download_cadastro"), System.Web.UI.WebControls.HyperLink)
            Dim lbl_id_ciq_documentos As Label = CType(e.Row.FindControl("lbl_id_ciq_documentos"), Label)
            Dim lbl_id_romaneio_ciq_documentos As Label = CType(e.Row.FindControl("lbl_id_romaneio_ciq_documentos"), Label)

            If lbl_id_ciq_documentos.Text.Equals(String.Empty) Then
                hl_download_cadastro.NavigateUrl = String.Empty
                hl_download_cadastro.Text = String.Empty
                e.Row.Cells(1).Text = "S"
            Else
                hl_download_cadastro.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", lbl_id_ciq_documentos.Text) + String.Format("&id_processo={0}", "1")

            End If

            If (Not hl_download.Text.ToString().Equals(String.Empty)) Then
                hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", lbl_id_romaneio_ciq_documentos.Text) + String.Format("&id_processo={0}", "2")
            End If

        End If
    End Sub
End Class

