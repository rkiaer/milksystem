Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_transit_point_unidade
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        If Not (txt_nm_sigla.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("nm_sigla") = txt_nm_sigla.Text.Trim()
        Else
            ViewState.Item("nm_sigla") = String.Empty
        End If
        ViewState.Item("nm_transit_point_unidade") = txt_nm_transit_point.Text.Trim()
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_transit_point_unidade.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_transit_point_unidade.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 171
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

            ViewState.Item("sortExpression") = "nm_transit_point_unidade asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("transitpointuni", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("transitpointuni", cbo_estabelecimento.ID)
            cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("transitpointuni", txt_nm_sigla.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_sigla") = customPage.getFilterValue("transitpointuni", txt_nm_sigla.ID)
            txt_nm_sigla.Text = ViewState.Item("nm_sigla").ToString()
        Else
            ViewState.Item("nm_sigla") = String.Empty
        End If

        If Not (customPage.getFilterValue("transitpointuni", txt_nm_transit_point.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_transit_point_unidade") = customPage.getFilterValue("transitpointuni", txt_nm_transit_point.ID)
            txt_nm_transit_point.Text = ViewState.Item("nm_transit_point_unidade").ToString()
        Else
            ViewState.Item("nm_transit_point_unidade") = String.Empty
        End If


        If Not (customPage.getFilterValue("transitpointuni", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("transitpointuni", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("transitpointuni", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("transitpointuni", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("transitpointuni")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim transitpoint As New TransitPointUnidade

            transitpoint.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            transitpoint.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            transitpoint.nm_transit_point_unidade = ViewState.Item("nm_transit_point_unidade").ToString()
            transitpoint.cd_transit_point_unidade = ViewState.Item("nm_sigla").ToString()

            Dim dsTransitPoint As DataSet = transitpoint.getTransitPointUnidadeByFilters()

            If (dsTransitPoint.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsTransitPoint.Tables(0), ViewState.Item("sortExpression"))
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


            Case "ds_estabelecimento"
                If ViewState.Item("sortExpression") = "ds_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "ds_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "ds_estabelecimento asc"
                End If
            Case "nm_transit_point_unidade"
                If ViewState.Item("sortExpression") = "nm_transit_point_unidade asc" Then
                    ViewState.Item("sortExpression") = "nm_transit_point_unidade desc"
                Else
                    ViewState.Item("sortExpression") = "nm_transit_point_unidade asc"
                End If
            Case "nm_sigla"
                If ViewState.Item("sortExpression") = "cd_transit_point_unidade asc" Then
                    ViewState.Item("sortExpression") = "cd_transit_point_unidade desc"
                Else
                    ViewState.Item("sortExpression") = "cd_transit_point_unidade asc"
                End If
            Case "id_situacao"
                If ViewState.Item("sortExpression") = "id_situacao asc" Then
                    ViewState.Item("sortExpression") = "id_situacao desc"
                Else
                    ViewState.Item("sortExpression") = "id_situacao asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("transitpointuni", cbo_estabelecimento.ID, cbo_estabelecimento.SelectedValue)
            customPage.setFilter("transitpointuni", txt_nm_sigla.ID, txt_nm_sigla.Text)
            customPage.setFilter("transitpointuni", txt_nm_transit_point.ID, txt_nm_transit_point.Text)
            customPage.setFilter("transitpointuni", cbo_situacao.ID, cbo_situacao.SelectedValue)
            customPage.setFilter("transitpointuni", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_transit_point_unidade.aspx?id_transit_point_unidade=" + e.CommandArgument.ToString())

            Case "delete"
                deleteTransitPoint(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteTransitPoint(ByVal id_transit_point_unidade As Integer)

        Try

            Dim transit As New TransitPointUnidade()
            transit.id_transit_point_unidade = id_transit_point_unidade
            transit.id_modificador = Convert.ToInt32(Session("id_login"))
            transit.deleteTransitPointUnidade()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 171
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
        Response.Redirect("frm_transit_point_unidade.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
End Class
