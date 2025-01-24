Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_frete_lancamento

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        If Not (txt_cd_transportador.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_transportador") = Me.hf_id_transportador.Value
        Else
            ViewState.Item("id_transportador") = "0"
        End If
        'ViewState.Item("cd_transportador") = txt_cd_transportador.Text.Trim()
        If Not (txt_cd_cooperativa.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_cooperativa") = Me.hf_id_cooperativa.Value
        Else
            ViewState.Item("id_cooperativa") = "0"
        End If

        If Not (txt_nr_romaneio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_romaneio") = Me.txt_nr_romaneio.Text.Trim()
        Else
            ViewState.Item("id_romaneio") = "0"
        End If
        ViewState.Item("cd_conta") = Me.txt_cd_conta.Text.Trim
        ViewState.Item("nm_conta") = Me.txt_nm_conta.Text.Trim
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue
        ViewState.Item("dt_referencia") = Me.txt_dt_referencia.Text.Trim

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_frete_lancamento.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_frete_lancamento.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 256
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If

        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportadores"
        End With
        With btn_lupa_cooperativa
            .Attributes.Add("onclick", "javascript:ShowDialogCooperativa()")
            .ToolTip = "Filtrar Cooperativas"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento

            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = "dt_referencia desc, ds_frete_conta asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("lancfrete", cbo_estabelecimento.ID).Equals("0")) Then
            ViewState.Item("id_estabelecimento") = 0
            cbo_estabelecimento.SelectedValue = 0
        Else
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("lancfrete", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        End If

        If Not (customPage.getFilterValue("lancfrete", txt_cd_transportador.ID).Equals(String.Empty)) Then
            hasFilters = True
            txt_cd_transportador.Text = customPage.getFilterValue("lancfrete", txt_cd_transportador.ID)
        Else
            txt_cd_transportador.Text = String.Empty
        End If

        If Not (customPage.getFilterValue("lancfrete", lbl_nm_transportador.ID).Equals(String.Empty)) Then
            hasFilters = True
            lbl_nm_transportador.Text = customPage.getFilterValue("lancfrete", lbl_nm_transportador.ID)
        Else
            lbl_nm_transportador.Text = String.Empty
        End If

        If Not (customPage.getFilterValue("lancfrete", hf_id_transportador.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_transportador") = customPage.getFilterValue("lancfrete", hf_id_transportador.ID)
            hf_id_transportador.Value = ViewState.Item("id_transportador").ToString()
        Else
            ViewState.Item("id_transportador") = String.Empty
        End If
        If Not (customPage.getFilterValue("lancfrete", txt_cd_cooperativa.ID).Equals(String.Empty)) Then
            hasFilters = True
            txt_cd_cooperativa.Text = customPage.getFilterValue("lancfrete", txt_cd_cooperativa.ID)
        Else
            txt_cd_cooperativa.Text = String.Empty
        End If

        If Not (customPage.getFilterValue("lancfrete", lbl_nm_cooperativa.ID).Equals(String.Empty)) Then
            hasFilters = True
            lbl_nm_cooperativa.Text = customPage.getFilterValue("lancfrete", lbl_nm_cooperativa.ID)
        Else
            lbl_nm_cooperativa.Text = String.Empty
        End If

        If Not (customPage.getFilterValue("lancfrete", hf_id_cooperativa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_cooperativa") = customPage.getFilterValue("lancfrete", hf_id_cooperativa.ID)
            hf_id_cooperativa.Value = ViewState.Item("id_cooperativa").ToString()
        Else
            ViewState.Item("id_cooperativa") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancfrete", txt_cd_conta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_conta") = customPage.getFilterValue("lancfrete", txt_cd_conta.ID)
            txt_cd_conta.Text = ViewState.Item("cd_conta").ToString()
        Else
            ViewState.Item("cd_conta") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancfrete", txt_nm_conta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_conta") = customPage.getFilterValue("lancfrete", txt_nm_conta.ID)
            txt_nm_conta.Text = ViewState.Item("nm_conta").ToString()
        Else
            ViewState.Item("nm_conta") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancfrete", txt_nr_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("lancfrete", txt_nr_romaneio.ID)
            txt_nr_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancfrete", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("lancfrete", txt_dt_referencia.ID)
            txt_dt_referencia.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancfrete", cbo_situacao.ID).Equals("0")) Then
            ViewState.Item("id_situacao") = 0
            cbo_situacao.SelectedValue = 0
        Else
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("lancfrete", cbo_situacao.ID)
            cbo_situacao.SelectedValue = ViewState.Item("id_situacao").ToString()
        End If

        'If Not (customPage.getFilterValue("lancfrete", txt_id_importacao.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("id_importacao") = customPage.getFilterValue("lancfrete", txt_id_importacao.ID)
        '    txt_id_importacao.Text = ViewState.Item("id_importacao").ToString()
        'Else
        '    ViewState.Item("id_importacao") = String.Empty
        'End If

        If Not (customPage.getFilterValue("lancfrete", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("lancfrete", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("lancfrete")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim lancamento As New FreteLancamento

            If Trim(ViewState.Item("id_transportador")) <> "" Then
                lancamento.id_transportador = Convert.ToInt32(ViewState.Item("id_transportador").ToString)
            End If
            If Trim(ViewState.Item("id_cooperativa")) <> "" Then
                lancamento.id_cooperativa = Convert.ToInt32(ViewState.Item("id_cooperativa").ToString)
            End If
            lancamento.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            lancamento.cd_frete_conta = ViewState.Item("cd_conta").ToString
            lancamento.nm_frete_conta = ViewState.Item("nm_conta").ToString
            lancamento.id_estabelecimento = ViewState.Item("id_estabelecimento")
            If ViewState.Item("dt_referencia").Equals(String.Empty) Then
                lancamento.dt_referencia = String.Empty
            Else
                lancamento.dt_referencia = String.Concat("01/", ViewState.Item("dt_referencia").ToString())
            End If
            'If Trim(ViewState.Item("id_importacao")) <> "" Then
            '    lancamento.id_importacao = Convert.ToInt32(ViewState.Item("id_importacao").ToString)
            'End If

            Dim dsLancamento As DataSet = lancamento.getFreteLancamentoByFilters()

            If (dsLancamento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsLancamento.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


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


            Case "ds_transportador"
                If (ViewState.Item("sortExpression")) = "ds_transportador asc" Then
                    ViewState.Item("sortExpression") = "ds_transportador desc"
                Else
                    ViewState.Item("sortExpression") = "ds_transportador asc"
                End If

            Case "id_romaneio"
                If (ViewState.Item("sortExpression")) = "id_romaneio asc" Then
                    ViewState.Item("sortExpression") = "id_romaneio desc"
                Else
                    ViewState.Item("sortExpression") = "id_romaneio asc"
                End If

            Case "cd_conta"
                If (ViewState.Item("sortExpression")) = "cd_frete_conta asc" Then
                    ViewState.Item("sortExpression") = "cd_frete_conta desc"
                Else
                    ViewState.Item("sortExpression") = "cd_frete_conta asc"
                End If

            Case "nm_conta"
                If (ViewState.Item("sortExpression")) = "nm_frete_conta asc" Then
                    ViewState.Item("sortExpression") = "nm_frete_conta desc"
                Else
                    ViewState.Item("sortExpression") = "nm_frete_conta asc"
                End If
            Case "nm_linha"
                If (ViewState.Item("sortExpression")) = "nm_linha asc" Then
                    ViewState.Item("sortExpression") = "nm_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nm_linha asc"
                End If
            Case "ds_tipo_frete"
                If (ViewState.Item("sortExpression")) = "ds_tipo_frete asc" Then
                    ViewState.Item("sortExpression") = "ds_tipo_frete desc"
                Else
                    ViewState.Item("sortExpression") = "ds_tipo_frete asc"
                End If

            Case "dt_referencia"
                If (ViewState.Item("sortExpression")) = "dt_referencia asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia asc"
                End If

        End Select

        loadData()

    End Sub
    Private Sub saveFilters()

        Try


            'customPage.setFilter("lancfrete", txt_id_importacao.ID, ViewState.Item("id_importacao").ToString)
            customPage.setFilter("lancfrete", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("lancfrete", txt_cd_transportador.ID, txt_cd_transportador.Text.ToString)
            customPage.setFilter("lancfrete", lbl_nm_transportador.ID, lbl_nm_transportador.Text)
            customPage.setFilter("lancfrete", hf_id_transportador.ID, ViewState.Item("id_transportador").ToString)
            customPage.setFilter("lancfrete", txt_cd_cooperativa.ID, txt_cd_cooperativa.Text.ToString)
            customPage.setFilter("lancfrete", hf_id_cooperativa.ID, ViewState.Item("id_cooperativa").ToString)
            customPage.setFilter("lancfrete", lbl_nm_cooperativa.ID, lbl_nm_cooperativa.Text)
            customPage.setFilter("lancfrete", txt_cd_conta.ID, ViewState.Item("cd_conta").ToString)
            customPage.setFilter("lancfrete", txt_nm_conta.ID, ViewState.Item("nm_conta").ToString)
            customPage.setFilter("lancfrete", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("lancfrete", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("lancfrete", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_frete_lancamento.aspx?id_frete_lancamento=" + e.CommandArgument.ToString())

            Case "delete"
                deleteLancamento(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteLancamento(ByVal id_frete_lancamento As Integer)

        Try
            Dim lancamento As New FreteLancamento()
            lancamento.id_frete_lancamento = id_frete_lancamento
            lancamento.id_modificador = Convert.ToInt32(Session("id_login"))
            lancamento.deleteFreteLancamento()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 256
            usuariolog.id_nr_processo = id_frete_lancamento
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_frete_lancamento.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then


        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
    Protected Sub txt_cd_cooperativa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_cooperativa.TextChanged
        If Not txt_cd_cooperativa.Text.Equals(String.Empty) Then
            loadCooperativaByCodigo()
        Else
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            hf_id_cooperativa.Value = String.Empty
            lbl_cd_cnpj.Text = String.Empty
            lbl_cd_cnpj.Visible = False
            Me.lbl_nm_cnpj.Visible = False
        End If
    End Sub
    Private Sub loadCooperativaByCodigo()

        Try


            Dim cooperativa As New Pessoa
            cooperativa.cd_pessoa = txt_cd_cooperativa.Text
            Dim dscooperativa As DataSet = cooperativa.getCooperativasByCodigo()
            If dscooperativa.Tables(0).Rows.Count > 0 Then
                lbl_nm_cooperativa.Visible = True
                lbl_cd_cnpj.Visible = True
                Me.lbl_nm_cnpj.Visible = True
                lbl_nm_cooperativa.Text = dscooperativa.Tables(0).Rows(0).Item("nm_pessoa")
                lbl_cd_cnpj.Text = dscooperativa.Tables(0).Rows(0).Item("cd_cnpj")
                hf_id_cooperativa.Value = dscooperativa.Tables(0).Rows(0).Item("id_pessoa")
                ViewState.Item("id_estado_cooperativa") = dscooperativa.Tables(0).Rows(0).Item("id_estado")
            Else
                lbl_nm_cooperativa.Visible = False
                lbl_cd_cnpj.Visible = False
                Me.lbl_nm_cnpj.Visible = False
                hf_id_cooperativa.Value = String.Empty
                ViewState.Item("id_estado_cooperativa") = 0
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadTransportadorByCodigo()

        Try


            Dim transp As New Pessoa
            transp.cd_pessoa = txt_cd_transportador.Text
            Dim dstransp As DataSet = transp.getTransportadorCooperativaByFilters()
            If dstransp.Tables(0).Rows.Count > 0 Then
                lbl_nm_transportador.Visible = True
                lbl_nm_transportador.Text = dstransp.Tables(0).Rows(0).Item("nm_pessoa")
                hf_id_transportador.Value = dstransp.Tables(0).Rows(0).Item("id_pessoa")
            Else
                lbl_nm_transportador.Visible = False
                hf_id_transportador.Value = String.Empty
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        If Not txt_cd_transportador.Text.Equals(String.Empty) Then
            loadTransportadorByCodigo()
        Else
            lbl_nm_transportador.Text = String.Empty
            lbl_nm_transportador.Visible = False
            hf_id_transportador.Value = String.Empty
        End If

    End Sub

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
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

            customPage.clearFilters("lupa_transcoop")

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposCooperativa()

        Try

            If Not (customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").Equals(String.Empty)) Then
                Me.lbl_nm_cooperativa.Visible = True
                Me.lbl_nm_cooperativa.Text = customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").Equals(String.Empty)) Then
                Me.txt_cd_cooperativa.Text = customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").Equals(String.Empty)) Then
                Me.lbl_cd_cnpj.Visible = True
                Me.lbl_cd_cnpj.Text = customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").ToString
                Me.lbl_nm_cnpj.Visible = True
            End If

            'loadData()
            customPage.clearFilters("lupa_cooperativa")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_cooperativa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_cooperativa.Click
        If Not (Me.hf_id_cooperativa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposCooperativa()
        Else
            txt_cd_cooperativa.Text = String.Empty
            hf_id_cooperativa.Value = String.Empty
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            lbl_cd_cnpj.Text = String.Empty
            lbl_cd_cnpj.Visible = False
            Me.lbl_nm_cnpj.Visible = False
        End If
    End Sub
End Class
