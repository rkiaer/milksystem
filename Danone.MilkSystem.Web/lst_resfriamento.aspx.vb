Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_resfriamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_transit_point_unidade") = cbo_transit_point.SelectedValue
        If txt_dt_referencia.Text.Equals(String.Empty) Then
            ViewState.Item("dt_referencia") = txt_dt_referencia.Text
        Else
            ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)
        End If
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_resfriamento.aspx?st_incluirlog=N")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_resfriamento.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 265
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = ""

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadFilters()

        Dim hasFilters As Boolean
        If Not customPage.getFilterValue("resfriamento", cbo_estabelecimento.ID).Equals(String.Empty) Then

            If Not (customPage.getFilterValue("resfriamento", cbo_estabelecimento.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_estabelecimento") = customPage.getFilterValue("resfriamento", cbo_estabelecimento.ID)
                cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
            Else
                ViewState.Item("id_estabelecimento") = "0"
            End If
            If Not (customPage.getFilterValue("resfriamento", cbo_transit_point.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_transit_point_unidade") = customPage.getFilterValue("resfriamento", cbo_transit_point.ID)
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
                ViewState.Item("id_transit_point_unidade") = "0"
            End If

            If Not (customPage.getFilterValue("resfriamento", cbo_situacao.ID).Equals("0")) Then
                ViewState.Item("id_situacao") = customPage.getFilterValue("resfriamento", cbo_situacao.ID)
                cbo_situacao.SelectedValue = ViewState.Item("id_situacao").ToString()
            End If

            If Not (customPage.getFilterValue("resfriamento", txt_dt_referencia.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("dt_referencia") = customPage.getFilterValue("resfriamento", txt_dt_referencia.ID)
                txt_dt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("MM/yyyy")
            Else
                ViewState.Item("dt_referencia") = String.Empty
            End If


            If Not (customPage.getFilterValue("resfriamento", "PageIndex").Equals(String.Empty)) Then
                ViewState.Item("PageIndex") = customPage.getFilterValue("resfriamento", "PageIndex").ToString()
                gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
            End If
        End If

        If (hasFilters) Then
            customPage.clearFilters("resfriamento")
            loadData()
        End If

    End Sub

    Private Sub loadData()

        Try


            Dim resfriamento As New Resfriamento

            resfriamento.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            resfriamento.id_estabelecimento = Convert.ToInt32(ViewState("id_estabelecimento"))
            resfriamento.id_transit_point_unidade = Convert.ToInt32(ViewState("id_transit_point_unidade"))
            resfriamento.dt_referencia = ViewState.Item("dt_referencia").ToString

            Dim dsresfriamento As DataSet = resfriamento.getResfriamentobyFilters

            If (dsresfriamento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsresfriamento.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("resfriamento", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("resfriamento", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("resfriamento", cbo_estabelecimento.ID, ViewState("id_estabelecimento").ToString())
            customPage.setFilter("resfriamento", cbo_transit_point.ID, ViewState.Item("id_transit_point_unidade").ToString)
            customPage.setFilter("resfriamento", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_resfriamento.aspx?id_resfriamento=" + e.CommandArgument.ToString())

            Case "delete"
                deleteResfriamento(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            If e.Row.Cells(4).Text.Trim.Equals("1") Then 'situacao
                e.Row.Cells(4).Text = "Ativo"
            Else
                e.Row.Cells(4).Text = "Inativo"
            End If

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Private Sub deleteResfriamento(ByVal id_resfriamento As Integer)

        Try

            Dim resfriamento As New Resfriamento
            resfriamento.id_resfriamento = id_resfriamento
            resfriamento.id_modificador = Convert.ToInt32(Session("id_login"))
            resfriamento.deleteResfriamento()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 265
            usuariolog.id_nr_processo = id_resfriamento
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso. Sr. Usuário, o Valor de Resfriamento deste registro não será mais enviado aos KPIs da Logística.")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

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
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        If cbo_estabelecimento.SelectedValue.ToString.Equals("0") Then
            ViewState.Item("id_transit_point_unidade") = "0"
            ViewState("id_estabelecimento") = "0"
        Else
            ViewState.Item("id_transit_point_unidade") = cbo_transit_point.SelectedValue
            ViewState("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        End If
        If txt_dt_referencia.Text.Equals(String.Empty) Then
            ViewState.Item("dt_referencia") = txt_dt_referencia.Text
        Else
            ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)
        End If

        saveFilters()
        Response.Redirect("frm_resfriamento.aspx")
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub
End Class
