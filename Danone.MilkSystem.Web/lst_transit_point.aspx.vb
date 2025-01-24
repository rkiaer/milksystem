Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_transit_point

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then

            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("id_transit_point_unidade") = cbo_transit_point.SelectedValue
            ViewState.Item("id_pre_romaneio") = txt_id_romaneio.Text.Trim()
            ViewState.Item("ds_placa") = txt_placa.Text.Trim()
            ViewState.Item("nm_linha") = txt_nm_linha.Text.Trim.ToString
            ViewState.Item("dt_abertura") = txt_dt_hora_entrada.Text.Trim.ToString
            ViewState.Item("id_situacao_transit_point") = cbo_situacao.SelectedValue
            ViewState.Item("id_transit_point") = txt_id_transit_point.Text
            ViewState.Item("btnpesquisar") = "S"

            loadData()

        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_transit_point.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_transit_point.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 167
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 


            ViewState.Item("btnpesquisar") = "N"
        End If


        With bt_lupa_veiculo
            .Attributes.Add("onclick", "javascript:ShowDialogVeiculo()")
            .ToolTip = "Filtrar Veículos"
            '.Style("cursor") = "hand"
        End With

    End Sub


    Private Sub loadDetails()

        Try


            ViewState.Item("sortExpression") = "id_transit_point desc"
            'Fran
            'txt_dt_hora_entrada.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim situacaotransit As New SituacaoTransitPoint

            cbo_situacao.DataSource = situacaotransit.getSituacoesTransitPointByFilters()
            cbo_situacao.DataTextField = "nm_situacao_transit_point"
            cbo_situacao.DataValueField = "id_situacao_transit_point"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("transit_selecao", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("transit_selecao", cbo_estabelecimento.ID)
            cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If
        If Not (customPage.getFilterValue("transit_selecao", cbo_transit_point.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_transit_point_unidade") = customPage.getFilterValue("transit_selecao", cbo_transit_point.ID)
            Dim transit As New TransitPointUnidade
            transit.id_estabelecimento = cbo_estabelecimento.SelectedValue
            transit.id_situacao = 1 'ativo
            cbo_transit_point.DataSource = transit.getTransitPointUnidadeByFilters()
            cbo_transit_point.DataTextField = "ds_transit_point_unidade"
            cbo_transit_point.DataValueField = "id_transit_point_unidade"
            cbo_transit_point.DataBind()
            cbo_transit_point.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_transit_point.SelectedValue = ViewState.Item("id_transit_point_unidade")

            cbo_transit_point.Text = ViewState.Item("id_transit_point_unidade").ToString()
        Else
            ViewState.Item("id_transit_point_unidade") = String.Empty
        End If

        If Not (customPage.getFilterValue("transit_selecao", txt_id_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pre_romaneio") = customPage.getFilterValue("transit_selecao", txt_id_romaneio.ID)
            txt_id_romaneio.Text = ViewState.Item("id_pre_romaneio").ToString()
        Else
            ViewState.Item("id_pre_romaneio") = String.Empty
        End If

        If Not (customPage.getFilterValue("transit_selecao", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("transit_selecao", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If

        If Not (customPage.getFilterValue("transit_selecao", txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_linha") = customPage.getFilterValue("transit_selecao", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_linha").ToString()
        Else
            ViewState.Item("nm_linha") = String.Empty
        End If

        If Not (customPage.getFilterValue("transit_selecao", txt_dt_hora_entrada.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_abertura") = customPage.getFilterValue("transit_selecao", txt_dt_hora_entrada.ID)
            txt_dt_hora_entrada.Text = ViewState.Item("dt_abertura").ToString()
        Else
            ViewState.Item("dt_abertura") = String.Empty
        End If
        If Not (customPage.getFilterValue("transit_selecao", txt_id_transit_point.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_transit_point") = customPage.getFilterValue("transit_selecao", txt_id_transit_point.ID)
            txt_id_transit_point.Text = ViewState.Item("id_transit_point").ToString()
        Else
            ViewState.Item("id_transit_point") = String.Empty
        End If

        If Not (customPage.getFilterValue("transit_selecao", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao_transit_point") = customPage.getFilterValue("transit_selecao", cbo_situacao.ID)
            txt_id_transit_point.Text = ViewState.Item("id_situacao_transit_point").ToString()
        Else
            ViewState.Item("id_situacao_transit_point") = 0
        End If
        If (customPage.getFilterValue("transit_selecao", "btnpesquisar") = "S") Then
            hasFilters = True
            ViewState.Item("btnpesquisar") = customPage.getFilterValue("transit_selecao", "btnpesquisar")
        Else
            ViewState.Item("btnpesquisar") = "N"
        End If

        If Not (customPage.getFilterValue("transit_selecao", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("transit_selecao", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            customPage.clearFilters("transit_selecao")
            loadData()
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim transitpoint As New TransitPoint()

            transitpoint.id_estabelecimento = ViewState.Item("id_estabelecimento")
            transitpoint.id_transit_point_unidade = ViewState.Item("id_transit_point_unidade")
            transitpoint.ds_placa = ViewState.Item("ds_placa").ToString
            transitpoint.nm_linha = ViewState.Item("nm_linha").ToString
            transitpoint.dt_abertura = ViewState.Item("dt_abertura").ToString
            transitpoint.id_situacao_transit_point = ViewState.Item("id_situacao_transit_point").ToString
            If Not (ViewState.Item("id_pre_romaneio").ToString.Equals(String.Empty)) Then
                transitpoint.id_pre_romaneio = Convert.ToInt32(ViewState.Item("id_pre_romaneio").ToString())
            End If
            If Not (ViewState.Item("id_transit_point").ToString.Equals(String.Empty)) Then
                transitpoint.id_transit_point = Convert.ToInt32(ViewState.Item("id_transit_point").ToString())
            End If

            Dim dstransitpoint As DataSet = transitpoint.getTransitPointSelecionar()

            If (dstransitpoint.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dstransitpoint.Tables(0), ViewState.Item("sortExpression"))
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
        Me.loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "id_transit_point"
                If (ViewState.Item("sortExpression")) = "id_transit_point asc" Then
                    ViewState.Item("sortExpression") = "id_transit_point desc"
                Else
                    ViewState.Item("sortExpression") = "id_transit_point asc"
                End If
            Case "cd_transit_point_unidade"
                If (ViewState.Item("sortExpression")) = "cd_transit_point_unidade asc" Then
                    ViewState.Item("sortExpression") = "cd_transit_point_unidade desc"
                Else
                    ViewState.Item("sortExpression") = "cd_transit_point_unidade asc"
                End If
            Case "ds_placa"
                If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
                End If
            Case "nm_linha"
                If (ViewState.Item("sortExpression")) = "nm_linha asc" Then
                    ViewState.Item("sortExpression") = "nm_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nm_linha asc"
                End If
            Case "dt_abertura"
                If (ViewState.Item("sortExpression")) = "dt_abertura asc" Then
                    ViewState.Item("sortExpression") = "dt_abertura desc"
                Else
                    ViewState.Item("sortExpression") = "dt_abertura asc"
                End If
            Case "nm_situacao_transit_point"
                If (ViewState.Item("sortExpression")) = "nm_situacao_transit_point asc" Then
                    ViewState.Item("sortExpression") = "nm_situacao_transit_point desc"
                Else
                    ViewState.Item("sortExpression") = "nm_situacao_transit_point asc"
                End If
            Case "ds_transportador"
                If (ViewState.Item("sortExpression")) = "ds_transportador asc" Then
                    ViewState.Item("sortExpression") = "ds_transportador desc"
                Else
                    ViewState.Item("sortExpression") = "ds_transportador asc"
                End If

        End Select

        loadData()

    End Sub
    Private Sub carregarCamposVeiculo()

        Try

            If Not (customPage.getFilterValue("lupa_veiculo", "ds_placa").Equals(String.Empty)) Then
                Me.txt_placa.Text = customPage.getFilterValue("lupa_veiculo", "ds_placa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_veiculo")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try

            customPage.setFilter("transit_selecao", txt_id_romaneio.ID, ViewState.Item("id_pre_romaneio").ToString)
            customPage.setFilter("transit_selecao", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("transit_selecao", cbo_transit_point.ID, ViewState.Item("id_transit_point_unidade").ToString)
            customPage.setFilter("transit_selecao", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            customPage.setFilter("transit_selecao", txt_nm_linha.ID, ViewState.Item("nm_linha").ToString)
            customPage.setFilter("transit_selecao", "btnpesquisar", ViewState.Item("btnpesquisar").ToString)
            customPage.setFilter("transit_selecao", "PageIndex", gridResults.PageIndex.ToString())
            customPage.setFilter("transit_selecao", txt_dt_hora_entrada.ID, ViewState.Item("dt_abertura").ToString)
            customPage.setFilter("transit_selecao", txt_id_transit_point.ID, ViewState.Item("id_transit_point").ToString)
            customPage.setFilter("transit_selecao", cbo_situacao.ID, ViewState.Item("id_situacao_transit_point").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        '        Dim id_romaneio As Int32
        '       Dim strMessage As String

        Select Case e.CommandName.ToString().ToLower()

            Case "selecionar"
                saveFilters()

                'Response.Redirect("lst_romaneio_analises.aspx?id_romaneio=" + e.CommandArgument.ToString)
                Response.Redirect("frm_transit_point.aspx?id_transit_point=" + e.CommandArgument.ToString)
        End Select

    End Sub

    Protected Sub bt_lupa_veiculo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_veiculo.Click

        carregarCamposVeiculo()

    End Sub



    Protected Sub cmv_placa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_placa.ServerValidate
        Try
            Dim veiculo As New Veiculo()

            veiculo.ds_placa = txt_placa.Text
            args.IsValid = veiculo.validarPlaca()
            If Not args.IsValid Then
                messageControl.Alert("Placa não cadastrada.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim lbl_id_transit_point_situacao As Label = CType(e.Row.FindControl("lbl_id_situacao_transit_point"), Label)
                Dim hl_imprimir_ciq As Anthem.HyperLink = CType(e.Row.FindControl("hl_imprimir_ciq"), Anthem.HyperLink)


                'Se o romaneio compartimento é reanalise
                If lbl_id_transit_point_situacao.Text.Trim = "3" Then
                    hl_imprimir_ciq.Enabled = True
                    hl_imprimir_ciq.ImageUrl = "~/img/ic_impressao.gif"
                    hl_imprimir_ciq.NavigateUrl = String.Format("frm_transit_point_impressao.aspx?id_transit_point={0}", gridResults.DataKeys.Item(e.Row.RowIndex).Value)
                Else
                    hl_imprimir_ciq.Enabled = False
                    hl_imprimir_ciq.ImageUrl = "~/img/ic_impressao_desabilitado.gif"
                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        If cbo_estabelecimento.SelectedValue <> "0" Then
            cbo_transit_point.Enabled = True

            Dim transit As New TransitPointUnidade

            transit.id_estabelecimento = cbo_estabelecimento.SelectedValue
            transit.id_situacao = 1 'ativo

            cbo_transit_point.DataSource = transit.getTransitPointUnidadeByFilters()
            cbo_transit_point.DataTextField = "ds_transit_point_unidade"
            cbo_transit_point.DataValueField = "id_transit_point_unidade"
            cbo_transit_point.DataBind()
            cbo_transit_point.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_transit_point.SelectedValue = 0
        Else
            cbo_transit_point.Items.Clear()
            cbo_transit_point.Enabled = False
        End If

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        If Page.IsValid Then
            Try

                saveFilters()
                Response.Redirect("frm_transit_point_novo.aspx")

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If
    End Sub
End Class
