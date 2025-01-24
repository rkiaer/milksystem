Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_romaneio_saida_abertura
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click


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

        ViewState.Item("id_romaneio") = txt_id_romaneio.Text
        ViewState.Item("nm_linha") = txt_nm_linha.Text


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_saida_abertura.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_saida_abertura.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 246
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
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_estabelecimento.SelectedValue = 1

            ViewState.Item("sortExpression") = "id_romaneio desc"

            'txt_dt_inicio.Text = Format(DateAdd(DateInterval.Day, -1, Date.Today), "dd/MM/yyyy").ToString()
            txt_dt_inicio.Text = Format(Date.Today, "dd/MM/yyyy").ToString()
            txt_dt_fim.Text = Format(Date.Today, "dd/MM/yyyy").ToString()


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
            Dim dsromaneio As DataSet

            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                romaneio.dt_hora_entrada_ini = Convert.ToString(ViewState.Item("dt_inicio"))
            End If
            If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                romaneio.dt_hora_entrada_fim = Convert.ToString(ViewState.Item("dt_fim"))
            End If

            romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

            If Not ViewState.Item("id_romaneio").ToString.Equals(String.Empty) Then
                romaneio.id_romaneio = ViewState.Item("id_romaneio")
            End If

            romaneio.nm_linha = ViewState.Item("nm_linha").ToString
            romaneio.id_st_romaneio = 4

            dsromaneio = romaneio.getRomaneioByFilters

            If (dsromaneio.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsromaneio.Tables(0), ViewState.Item("sortExpression"))
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

            Case "selecionar"
                Response.Redirect("frm_romaneio_saida_abertura.aspx?id_romaneio=" + e.CommandArgument.ToString)


        End Select

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then
            Try
                Dim lbl_nm_cooperativa As Label = CType(e.Row.FindControl("lbl_nm_cooperativa"), Label)
                Dim lbl_nr_peso_liquido_nota As Label = CType(e.Row.FindControl("lbl_nr_peso_liquido_nota"), Label)

                'transportador
                e.Row.Cells(2).Text = Left(e.Row.Cells(2).Text, 20).ToString

                'se é cooperativa
                If Not lbl_nm_cooperativa.Text.Equals(String.Empty) Then
                    e.Row.Cells(1).Text = Left(lbl_nm_cooperativa.Text, 20).ToString
                    e.Row.Cells(9).Text = FormatNumber(lbl_nr_peso_liquido_nota.Text, 0).ToString
                End If

                'transit
                If e.Row.Cells(4).Text = "0" Then
                    e.Row.Cells(4).Text = String.Empty
                End If
                'transvase
                If e.Row.Cells(5).Text = "0" Then
                    e.Row.Cells(5).Text = String.Empty
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If

    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub

End Class

