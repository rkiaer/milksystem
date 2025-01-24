Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_romaneio_saida_controle_saida
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_saida_controle_saida.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 261
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
            cbo_estabelecimento.SelectedValue = 1

            'tipo de leite 
            Dim item As New Item
            cbo_item.DataSource = item.getItensByFilters()
            cbo_item.DataTextField = "nm_item"
            cbo_item.DataValueField = "id_item"
            cbo_item.DataBind()
            cbo_item.Items.Insert(0, New ListItem("[Selecione]", 0))

            Dim motivo As New MotivoSaida
            cbo_motivo_saida.DataSource = motivo.getMotivoSaidaByFilters()
            cbo_motivo_saida.DataTextField = "nm_motivo_saida"
            cbo_motivo_saida.DataValueField = "id_motivo_saida"
            cbo_motivo_saida.DataBind()
            cbo_motivo_saida.Items.Insert(0, New ListItem("[Selecione]", 0))

            'Dim frete As New FreteNotaFiscal
            'frete.id_situacao = 1
            'cbo_tipo_frete.DataSource = frete.getFretesNotasFiscaisByFilters()
            'cbo_tipo_frete.DataTextField = "nm_frete_nf"
            'cbo_tipo_frete.DataValueField = "id_frete_nf"
            'cbo_tipo_frete.DataBind()
            'cbo_tipo_frete.Items.Insert(0, New ListItem("[Selecione]", 0))

            Dim tipooperacao As New TipoOperacao
            tipooperacao.id_situacao = 1
            cbo_tipo_operacao.DataSource = tipooperacao.getTipoOperacaoByFilters()
            cbo_tipo_operacao.DataTextField = "nm_tipo_operacao"
            cbo_tipo_operacao.DataValueField = "id_tipo_operacao"
            cbo_tipo_operacao.DataBind()
            cbo_tipo_operacao.Items.Insert(0, New ListItem("[Selecione]", 0))

            txt_dt_inicio.Text = Format(DateAdd(DateInterval.Day, -15, Date.Today), "dd/MM/yyyy").ToString()
            txt_dt_fim.Text = Format(Date.Today, "dd/MM/yyyy").ToString()

            'loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = txt_dt_inicio.Text.Trim()
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If
        ViewState.Item("dt_fim") = Me.txt_dt_fim.Text.Trim

        If (txt_dt_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = ViewState.Item("dt_inicio")
        End If

        If Not (cbo_estabelecimento.SelectedValue = 0) Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If
        If txt_id_romaneio_saida.Text.Equals(String.Empty) Then
            ViewState.Item("id_romaneio_saida") = 0
        Else
            ViewState.Item("id_romaneio_saida") = txt_id_romaneio_saida.Text

        End If
        If txt_id_romaneio_saida.Text.Equals(String.Empty) Then
            ViewState.Item("id_romaneio_entrada") = 0
        Else
            ViewState.Item("id_romaneio_entrada") = txt_id_romaneio_entrada.Text
        End If
        ViewState.Item("id_tipo_operacao") = cbo_tipo_operacao.SelectedValue
        ViewState.Item("id_item") = cbo_item.SelectedValue
        ViewState.Item("id_motivo_saida") = cbo_motivo_saida.SelectedValue

        ViewState.Item("sortExpression") = ""

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
                usuariolog.id_menu_item = 261
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Response.Redirect("frm_romaneio_saida_controle_saida_excel.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida").ToString + "&id_romaneio_entrada=" + ViewState.Item("id_romaneio_entrada").ToString + "&id_item=" + ViewState.Item("id_item").ToString + "&id_tipo_operacao=" + ViewState.Item("id_tipo_operacao").ToString + "&id_motivo_saida=" + ViewState.Item("id_motivo_saida").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento"))
            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
            End If
        End If


    End Sub
    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = txt_dt_inicio.Text.Trim()
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If
        ViewState.Item("dt_fim") = Me.txt_dt_fim.Text.Trim

        If (txt_dt_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = ViewState.Item("dt_inicio")
        End If

        If Not (cbo_estabelecimento.SelectedValue = 0) Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        ViewState.Item("id_romaneio_saida") = txt_id_romaneio_saida.Text
        ViewState.Item("id_romaneio_entrada") = txt_id_romaneio_entrada.Text
        ViewState.Item("id_tipo_operacao") = cbo_tipo_operacao.SelectedValue
        ViewState.Item("id_item") = cbo_item.SelectedValue
        ViewState.Item("id_motivo_saida") = cbo_motivo_saida.SelectedValue

        ViewState.Item("sortExpression") = ""


        loadData()

    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New RomaneioSaida

            romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            romaneio.dt_inicio = ViewState.Item("dt_inicio").ToString
            romaneio.dt_fim = ViewState.Item("dt_fim").ToString

            If Trim(ViewState.Item("id_romaneio_saida")) <> "" Then
                romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            End If
            If Trim(ViewState.Item("id_romaneio_entrada")) <> "" Then
                romaneio.id_romaneio_entrada = Convert.ToInt32(ViewState.Item("id_romaneio_entrada").ToString)
            End If
            If Trim(ViewState.Item("id_tipo_operacao")) <> "" Then
                romaneio.id_tipo_operacao = Convert.ToInt32(ViewState.Item("id_tipo_operacao").ToString)
            End If
            If Trim(ViewState.Item("id_item")) <> "" Then
                romaneio.id_item = Convert.ToInt32(ViewState.Item("id_item").ToString)
            End If
            If Trim(ViewState.Item("id_motivo_saida")) <> "" Then
                romaneio.id_motivo_saida = Convert.ToInt32(ViewState.Item("id_motivo_saida").ToString)
            End If

            Dim dsromaneio As DataSet = romaneio.getRomaneioSaidaControleSaida

            If (dsromaneio.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsromaneio.Tables(0), ViewState.Item("sortExpression"))
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

        Response.Redirect("lst_romaneio_saida_controle_saida.aspx?st_incluirlog=N")

    End Sub



End Class

