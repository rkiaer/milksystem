Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_romaneio_saida_fechar
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = String.Concat(Me.txt_dt_inicio.Text.Trim, " 00:00:00")
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_romaneio_saida") = txt_id_romaneio.Text
        ViewState.Item("id_item") = cbo_id_item.SelectedValue
        If hf_id_transportador.Value = String.Empty Then
            ViewState.Item("id_transportador") = 0
        Else
            ViewState.Item("id_transportador") = hf_id_transportador.Value
        End If
        ViewState.Item("ds_placa") = txt_placa.Text
        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_saida_fechar.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_saida_fechar.aspx")

        If Not Page.IsPostBack Then
            ' i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 253
                usuariolog.insertUsuarioLog()


            End If
            'incluir log 

            loadDetails()
        End If
        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportadores"
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
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_estabelecimento.SelectedValue = 1

            'tipo de leite 
            Dim item As New Item
            cbo_id_item.DataSource = item.getItensByFilters()
            cbo_id_item.DataTextField = "nm_item"
            cbo_id_item.DataValueField = "id_item"
            cbo_id_item.DataBind()
            cbo_id_item.Items.Insert(0, New ListItem("[Selecione]", 0))

            ViewState.Item("sortExpression") = "id_romaneio_saida desc"
            If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("dt_inicio") = String.Concat(Me.txt_dt_inicio.Text.Trim, " 00:00:00")
            Else
                ViewState.Item("dt_inicio") = String.Empty
            End If

            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("id_romaneio_saida") = txt_id_romaneio.Text
            ViewState.Item("id_item") = cbo_id_item.SelectedValue
            ViewState.Item("id_transportador") = 0
            ViewState.Item("ds_placa") = txt_placa.Text

            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean


    '    If Not (customPage.getFilterValue("rsfechar", txt_dt_fim.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("dt_fim") = customPage.getFilterValue("rsnf", txt_dt_fim.ID)
    '        txt_dt_fim.Text = ViewState.Item("dt_fim").ToString()
    '    Else
    '        ViewState.Item("dt_fim") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("rsnf", txt_dt_inicio.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("dt_inicio") = customPage.getFilterValue("rsnf", txt_dt_inicio.ID)
    '        txt_dt_inicio.Text = ViewState.Item("dt_inicio").ToString()
    '    Else
    '        ViewState.Item("dt_inicio") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("rsnf", cbo_estabelecimento.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_estabelecimento") = customPage.getFilterValue("rsnf", cbo_estabelecimento.ID)
    '        cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
    '    Else
    '        ViewState.Item("id_estabelecimento") = String.Empty
    '    End If
    '    If Not (customPage.getFilterValue("rsnf", cbo_id_item.ID).Equals(0)) Then
    '        hasFilters = True
    '        ViewState.Item("id_item") = customPage.getFilterValue("rsnf", cbo_id_item.ID)
    '        cbo_id_item.SelectedValue = ViewState.Item("id_item").ToString()
    '    Else
    '        ViewState.Item("id_item") = 0
    '    End If

    '    If Not (customPage.getFilterValue("rsnf", cbo_situacao.ID).Equals("0")) Then
    '        hasFilters = True
    '        ViewState.Item("id_situacao") = customPage.getFilterValue("rsnf", cbo_situacao.ID)
    '        cbo_situacao.SelectedValue = ViewState.Item("id_situacao").ToString()
    '    Else
    '        ViewState.Item("id_situacao") = 0
    '    End If

    '    If Not (customPage.getFilterValue("rsnf", txt_placa.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("ds_placa") = customPage.getFilterValue("rsnf", txt_placa.ID)
    '        txt_placa.Text = ViewState.Item("ds_placa").ToString()
    '    Else
    '        ViewState.Item("ds_placa") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("rsnf", hf_id_transportador.ID).Equals(0)) Then
    '        hasFilters = True

    '        ViewState.Item("id_transportador") = customPage.getFilterValue("rsnf", hf_id_transportador.ID)
    '        Dim pessoa As New Pessoa(Convert.ToInt32(ViewState.Item("id_transportador")))
    '        Me.lbl_nm_transportador.Visible = True
    '        Me.lbl_nm_transportador.Text = pessoa.nm_pessoa
    '        Me.txt_cd_transportador.Text = pessoa.cd_pessoa
    '        hf_id_transportador.Value = ViewState.Item("id_transportador")

    '    Else
    '        ViewState.Item("id_transportador") = 0
    '    End If

    '    If Not (customPage.getFilterValue("rsnf", txt_id_romaneio.ID).Equals(String.Empty)) Then
    '        hasFilters = True

    '        ViewState.Item("id_romaneio_saida") = customPage.getFilterValue("rsnf", txt_id_romaneio.ID)
    '        txt_id_romaneio.Text = ViewState.Item("id_romaneio_saida")

    '    Else
    '        ViewState.Item("id_romaneio_saida") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("rsnf", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("rsnf", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("rsnf")
    '    End If

    'End Sub

    Private Sub loadData()

        Try

            Dim romaneio As New RomaneioSaida

            romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                romaneio.dt_inicio = Convert.ToString(ViewState.Item("dt_inicio"))
            End If
            If hf_id_transportador.Value = String.Empty Then
                ViewState.Item("id_transportador") = 0
            Else
                ViewState.Item("id_transportador") = hf_id_transportador.Value
            End If

            romaneio.ds_placa = ViewState.Item("ds_placa").ToString

            romaneio.id_item = ViewState.Item("id_item").ToString

            If Not ViewState.Item("id_romaneio_saida").ToString.Equals(String.Empty) Then
                romaneio.id_romaneio_saida = ViewState.Item("id_romaneio_saida")
            End If

            Dim dsRomaneios As DataSet = romaneio.getRomaneioSaidaFechar()

            If (dsRomaneios.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsRomaneios.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

            Else

                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "fechar"
                ViewState.Item("id_romaneio_saida_selecionado") = e.CommandArgument.ToString
                fecharRomaneio()

        End Select

    End Sub
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim hl_download As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_download"), System.Web.UI.WebControls.HyperLink)
            Dim hl_download_cte As System.Web.UI.WebControls.HyperLink = CType(e.Row.FindControl("hl_download_cte"), System.Web.UI.WebControls.HyperLink)
            Dim lbl_id_romaneio_saida_nota_anexo_cte As Label = CType(e.Row.FindControl("lbl_id_romaneio_saida_nota_anexo_cte"), Label)
            Dim lbl_id_romaneio_saida_nota_anexo_nf As Label = CType(e.Row.FindControl("lbl_id_romaneio_saida_nota_anexo_nf"), Label)
            If (Not lbl_id_romaneio_saida_nota_anexo_nf.Text.ToString().Equals(String.Empty)) Then
                hl_download.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", lbl_id_romaneio_saida_nota_anexo_nf.Text) + String.Format("&id_processo={0}", "11")
            End If
            If (Not lbl_id_romaneio_saida_nota_anexo_cte.Text.ToString().Equals(String.Empty)) Then
                hl_download_cte.NavigateUrl = String.Format("frm_download_documentos.aspx?id={0}", lbl_id_romaneio_saida_nota_anexo_cte.Text) + String.Format("&id_processo={0}", "11")
            End If
        End If

    End Sub


    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
            'loadMotoristaByTransportador(Convert.ToInt32(hf_id_transportador.Value))
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

            'loadData()
            customPage.clearFilters("lupa_transcoop")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidtransportador As Int32
            If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_transportador.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
            lidtransportador = pessoa.validarTransportadorCooperativa

            If lidtransportador > 0 Then
                args.IsValid = True
                hf_id_transportador.Value = lidtransportador
            Else
                hf_id_transportador.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Transportador não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        lbl_nm_transportador.Text = String.Empty
        lbl_nm_transportador.Visible = False
        hf_id_transportador.Value = String.Empty

    End Sub
    'Private Sub saveFilters()

    '    Try

    '        customPage.setFilter("rsnf", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
    '        customPage.setFilter("rsnf", txt_dt_inicio.ID, ViewState.Item("dt_inicio").ToString)
    '        customPage.setFilter("rsnf", txt_dt_fim.ID, ViewState.Item("dt_fim").ToString)
    '        customPage.setFilter("rsnf", hf_id_transportador.ID, ViewState.Item("id_transportador").ToString)
    '        customPage.setFilter("rsnf", cbo_id_item.ID, ViewState.Item("id_item").ToString)
    '        customPage.setFilter("rsnf", cbo_situacao.ID, ViewState.Item("id_situacao_transit_point").ToString)
    '        customPage.setFilter("rsnf", txt_id_romaneio.ID, ViewState.Item("id_romaneio_saida").ToString)
    '        customPage.setFilter("rsnf", "PageIndex", gridResults.PageIndex.ToString())

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub
    Private Sub fecharRomaneio()

        Try

            If Page.IsValid Then
                Dim romaneio As New RomaneioSaida

                romaneio.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida_selecionado").ToString)
                romaneio.id_modificador = Session("id_login")
                romaneio.updateRomaneioSaidaFechar()
                romaneio.id_situacao = 9
                romaneio.insertRomaneioSaidaSituacaoLog()

                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 253
                usuariolog.ds_nm_processo = "Finalizar Romaneio"
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio_saida_selecionado").ToString

                usuariolog.insertUsuarioLog()

                messageControl.Alert("Romaneio de Saída finalizado com sucesso!")
                loadData()


            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

End Class

