Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_transferencia_volume
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid = True Then
            ViewState.Item("id_propriedade") = txt_id_propriedade.Text
            ViewState.Item("dt_referencia") = String.Concat("01/", Me.txt_dt_referencia.Text)
            ViewState.Item("dt_ini") = String.Concat("01/", Me.txt_dt_referencia.Text)
            'ViewState.Item("dt_ini") = DateAdd(DateInterval.Month, -1, CDate(String.Concat("01/", Me.txt_dt_referencia.Text)))
            ViewState.Item("dt_fim") = DateAdd(DateInterval.Month, 1, CDate(String.Concat("01/", Me.txt_dt_referencia.Text)))
            ViewState.Item("dt_fim") = String.Concat(DateAdd(DateInterval.Day, -1, CDate(ViewState.Item("dt_fim"))), " 23:59:59")
            ViewState.Item("ano_referencia") = DateTime.Parse(String.Concat("01/", Me.txt_dt_referencia.Text)).ToString("yyyy")

            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue.ToString
            loadData()
        End If
    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_transferencia_volume.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_transferencia_volume.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 156
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ViewState.Item("limite_incentivo") = System.Configuration.ConfigurationManager.AppSettings("limite_incentivo").ToString()
            ViewState.Item("sortExpression") = "Produtor asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadData()

        Try
            Dim transfvolume As New TransferenciaVolume

            If Not (ViewState.Item("id_propriedade").Equals(String.Empty)) Then
                transfvolume.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            Else
                transfvolume.id_propriedade = 0
            End If
            If Not (ViewState.Item("dt_referencia").Equals(String.Empty)) Then
                transfvolume.dt_referencia = ViewState.Item("dt_referencia").ToString
                transfvolume.dt_ini = ViewState.Item("dt_ini").ToString
                transfvolume.dt_fim = ViewState.Item("dt_fim").ToString
            Else
                transfvolume.dt_referencia = String.Empty
                transfvolume.dt_ini = String.Empty
                transfvolume.dt_fim = String.Empty
            End If
            transfvolume.limite_incentivo = ViewState.Item("limite_incentivo").ToString

            transfvolume.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

            transfvolume.ano_referencia = ViewState.Item("ano_referencia").ToString
            Dim dstransfvolume As DataSet = transfvolume.getTransferenciaVolumeByFilters()

            If (dstransfvolume.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dstransfvolume.Tables(0), ViewState.Item("sortExpression"))
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


            Case "cd_produtor"
                If (ViewState.Item("sortExpression")) = "cd_produtor asc" Then
                    ViewState.Item("sortExpression") = "cd_produtor desc"
                Else
                    ViewState.Item("sortExpression") = "cd_produtor asc"
                End If

            Case "produtor"
                If (ViewState.Item("sortExpression")) = "produtor asc" Then
                    ViewState.Item("sortExpression") = "produtor desc"
                Else
                    ViewState.Item("sortExpression") = "produtor asc"
                End If

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If

            Case "nm_propriedade"
                If (ViewState.Item("sortExpression")) = "nm_propriedade asc" Then
                    ViewState.Item("sortExpression") = "nm_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "nm_propriedade asc"
                End If

            Case "estabelecimento"
                If (ViewState.Item("sortExpression")) = "estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "estabelecimento asc"
                End If

        End Select

        loadData()

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Dim id_propriedade As DataControlFieldCell = CType(gridResults.Rows.Item(e.CommandArgument.ToString).Cells(3), DataControlFieldCell)
                Dim nr_volume_anual As DataControlFieldCell = CType(gridResults.Rows.Item(e.CommandArgument.ToString).Cells(6), DataControlFieldCell)

                Response.Redirect("frm_transferencia_volume.aspx?id_propriedade=" + id_propriedade.Text.ToString() + "&nr_volume_anual=" + nr_volume_anual.Text.ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString)


        End Select

    End Sub

 
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim img_calc_definitivo As Anthem.Image = CType(e.Row.FindControl("img_calc_definitivo"), Anthem.Image)
            Dim img_detalhe As Anthem.ImageButton = CType(e.Row.FindControl("img_detalhe"), Anthem.ImageButton)

            Dim aux As New InterrupcaoFornecimento
            aux.dt_referencia = ViewState.Item("dt_referencia").ToString
            aux.id_propriedade = e.Row.Cells(3).Text
            If aux.getCalculoDefinitivoByPropriedade > 0 Then 'se tem calculo definitivo para referecia atual
                img_calc_definitivo.ImageUrl = "~/img/ico_chk_true.gif"
                img_detalhe.Enabled = False
                img_detalhe.ImageUrl = "~/img/icon_preview_desabilitado.gif"
                img_detalhe.ToolTip = "O cálculo já foi efetivado para esta referência. A trasferência de volumes não pode ser efetuada."
            Else
                img_calc_definitivo.ImageUrl = "~/img/ico_chk_false.gif"
                img_detalhe.Enabled = True
                img_detalhe.ToolTip = "Detalhes da propriedades para transferência de volumes."
                img_detalhe.ImageUrl = "~/img/icon_preview.gif"
                img_detalhe.CommandArgument = e.Row.RowIndex.ToString()
            End If
            e.Row.Cells(6).Text = FormatNumber(e.Row.Cells(6).Text, 0)


        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub



    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        ViewState.Item("id_propriedade") = txt_id_propriedade.Text
        ViewState.Item("dt_referencia") = String.Concat("01/", Me.txt_dt_referencia.Text)
        'ViewState.Item("dt_ini") = DateAdd(DateInterval.Month, -1, CDate(String.Concat("01/", Me.txt_dt_referencia.Text)))
        ViewState.Item("dt_ini") = String.Concat("01/", Me.txt_dt_referencia.Text)
        ViewState.Item("dt_fim") = DateAdd(DateInterval.Month, 1, CDate(String.Concat("01/", Me.txt_dt_referencia.Text)))
        ViewState.Item("dt_fim") = String.Concat(DateAdd(DateInterval.Day, -1, CDate(ViewState.Item("dt_fim"))), " 23:59:59")
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        customPage.clearFilters("transfvolume")

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 156
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        saveFilters()
        Response.Redirect("frm_transferencia_volume_excel.aspx?id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString() + "&dt_ini=" + ViewState.Item("dt_ini").ToString() + "&dt_fim=" + ViewState.Item("dt_fim").ToString() + "&limite_incentivo=" + ViewState.Item("limite_incentivo").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString)

    End Sub
    Private Sub saveFilters()

        Try
            customPage.setFilter("transfvolume", txt_id_propriedade.ID, ViewState.Item("id_propriedade"))
            customPage.setFilter("transfvolume", "limite_incentivo", ViewState.Item("limite_incentivo").ToString)
            customPage.setFilter("transfvolume", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("transfvolume", "dt_ini", ViewState.Item("dt_ini").ToString)
            customPage.setFilter("transfvolume", "dt_fim", ViewState.Item("dt_fim").ToString)
            customPage.setFilter("transfvolume", "PageIndex", gridResults.PageIndex.ToString())
            customPage.setFilter("transfvolume", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("transfvolume", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("transfvolume", txt_dt_referencia.ID)
            txt_dt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia").ToString()).ToString("MM/yyyy")
            ViewState.Item("dt_ini") = customPage.getFilterValue("transfvolume", "dt_ini")
            ViewState.Item("dt_fim") = customPage.getFilterValue("transfvolume", "dt_fim")
            ViewState.Item("ano_referencia") = DateTime.Parse(String.Concat("01/", Me.txt_dt_referencia.Text)).ToString("yyyy")

        Else
            ViewState.Item("dt_referecia") = String.Empty
            txt_dt_referencia.Text = String.Empty
            ViewState.Item("dt_ini") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        End If
        If (customPage.getFilterValue("transfvolume", cbo_estabelecimento.ID).Equals("0")) Or (customPage.getFilterValue("transfvolume", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            ViewState.Item("id_estabelecimento") = String.Empty
        Else
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("transfvolume", cbo_estabelecimento.ID)
            cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        End If

        If Not (customPage.getFilterValue("transfvolume", txt_id_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("transfvolume", txt_id_propriedade.ID)
            txt_id_propriedade.Text = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If
        If Not (customPage.getFilterValue("transfvolume", "limite_incentivo").Equals(String.Empty)) Then
            ViewState.Item("limite_incentivo") = customPage.getFilterValue("transfvolume", "limite_incentivo")
        End If
        If Not (customPage.getFilterValue("transfvolume", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("transfvolume", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("transfvolume")
        End If

    End Sub

    'Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated
    '    If (e.Row.RowType = DataControlRowType.DataRow) Then
    '        Try
    '            Dim btn_detalhe_item As ImageButton = CType(e.Row.FindControl("btn_detalhe_item"), ImageButton)
    '            btn_detalhe_item.CommandArgument = e.Row.RowIndex.ToString
    '        Catch ex As Exception
    '            messageControl.Alert(ex.Message)
    '        End Try

    '    End If

    'End Sub

    Protected Sub lk_outra_propriedade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_outra_propriedade.Click
        saveFilters()
        Response.Redirect("frm_transferencia_volume.aspx")

    End Sub
End Class
