Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_relatorio_motorista

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_hora_ini") = Me.txt_dt_hora_ini.Text.Trim
        ViewState.Item("dt_hora_fim") = Me.txt_dt_hora_fim.Text.Trim
        If (Me.txt_dt_hora_fim.Text.Trim) = "" Then
            ViewState.Item("dt_hora_fim") = Me.txt_dt_hora_ini.Text.Trim
        End If

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_relatorio_motorista.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_motorista.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 48
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
            Dim codigoesalq As New CodigoEsalq

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            txt_dt_hora_ini.Text = "01/" & DateTime.Parse(Now).ToString("MM/yyyy")
            txt_dt_hora_fim.Text = "01/" & DateTime.Parse(DateAdd(DateInterval.Month, 1, Convert.ToDateTime(txt_dt_hora_ini.Text))).ToString("MM/yyyy")

            'ViewState.Item("sortExpression") = "dt_hora_entrada asc"

            'Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_motorista.aspx?dt_hora_ini={0}", Me.txt_dt_hora_ini.Text) & String.Format("&dt_hora_fim={0}", Me.txt_dt_hora_fim.Text)

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("relatorio_motorista", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("relatorio_motorista", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If


        If Not (customPage.getFilterValue("relatorio_motorista", txt_dt_hora_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_hora_ini") = customPage.getFilterValue("relatorio_motorista", txt_dt_hora_ini.ID)
            txt_dt_hora_ini.Text = ViewState.Item("dt_hora_ini").ToString()
        Else
            ViewState.Item("dt_hora_ini") = String.Empty
        End If

        If Not (customPage.getFilterValue("relatorio_motorista", txt_dt_hora_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_hora_fim") = customPage.getFilterValue("relatorio_motorista", txt_dt_hora_fim.ID)
            txt_dt_hora_fim.Text = ViewState.Item("txt_dt_hora_fim").ToString()
        Else
            ViewState.Item("txt_dt_hora_fim") = String.Empty
        End If



        If Not (customPage.getFilterValue("relatorio_motorista", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("relatorio_motorista", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("relatorio_motorista")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio

            romaneio.data_inicio = ViewState.Item("dt_hora_ini").ToString
            romaneio.data_fim = ViewState.Item("dt_hora_fim").ToString
            romaneio.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString

            Dim dsMotoristas As DataSet = romaneio.getRomaneioMotoristaByFilters()

            If (dsMotoristas.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsMotoristas.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_motorista.aspx?dt_hora_ini={0}", Me.txt_dt_hora_ini.Text) & String.Format("&dt_hora_fim={0}", Me.txt_dt_hora_fim.Text) & String.Format("&id_estabelecimento={0}", Me.cbo_estabelecimento.SelectedValue)
            Me.hl_imprimir.Enabled = True

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


            Case "dt_hora_entrada"
                If (ViewState.Item("sortExpression")) = "dt_hora_entrada asc" Then
                    ViewState.Item("sortExpression") = "dt_hora_entrada desc"
                Else
                    ViewState.Item("sortExpression") = "dt_hora_entrada asc"
                End If


        End Select

        loadData()

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("relatorio_motorista", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("relatorio_motorista", txt_dt_hora_ini.ID, ViewState.Item("dt_hora_ini").ToString)
            customPage.setFilter("relatorio_motorista", txt_dt_hora_fim.ID, ViewState.Item("dt_hora_fim").ToString)
            customPage.setFilter("relatorio_motorista", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


    End Sub

    Private Sub deleteAnaliseEsalq(ByVal id_analise_esalq As Integer)


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


    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        hl_imprimir.Enabled = False
    End Sub

    Protected Sub txt_dt_hora_ini_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dt_hora_ini.TextChanged
        hl_imprimir.Enabled = False

    End Sub

    Protected Sub txt_dt_hora_fim_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dt_hora_fim.TextChanged
        hl_imprimir.Enabled = False

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        'Fran 01/06/2015 i

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_hora_ini") = Me.txt_dt_hora_ini.Text.Trim
        ViewState.Item("dt_hora_fim") = Me.txt_dt_hora_fim.Text.Trim
        If (Me.txt_dt_hora_fim.Text.Trim) = "" Then
            ViewState.Item("dt_hora_fim") = Me.txt_dt_hora_ini.Text.Trim
        End If

        loadData()

        If gridResults.Rows.Count.ToString + 1 < 65536 Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 48
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 
            Response.Redirect("frm_relatorio_motorista_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&dt_hora_ini=" + ViewState.Item("dt_hora_ini").ToString + "&dt_hora_fim=" + ViewState.Item("dt_hora_fim").ToString)
        Else
            messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
        End If

    End Sub
End Class
