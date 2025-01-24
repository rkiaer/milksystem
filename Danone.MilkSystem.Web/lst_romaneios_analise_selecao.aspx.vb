Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_romaneios_analise_selecao

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_romaneio") = txt_id_romaneio.Text.Trim()
        ViewState.Item("ds_placa") = txt_placa.Text.Trim()
        ' 21/01/2009 - Rls15 - i
        ViewState.Item("nr_caderneta") = txt_nr_caderneta.Text.Trim.ToString
        ViewState.Item("nm_linha") = txt_nm_linha.Text.Trim.ToString
        ' 21/01/2009 - Rls15 - f
        'fran 17/06/2009 i
        ViewState.Item("dt_hora_entrada") = txt_dt_hora_entrada.Text.Trim.ToString
        'fran 17/06/2009 f
        ViewState.Item("btnpesquisar") = "S"

        loadData()


    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneios_analise_selecao.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneios_analise_selecao.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 22
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
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


            ViewState.Item("sortExpression") = "id_romaneio asc"
            'Fran
            txt_dt_hora_entrada.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("ra_selecao", txt_id_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("ra_selecao", txt_id_romaneio.ID)
            txt_id_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If

        If Not (customPage.getFilterValue("ra_selecao", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("ra_selecao", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If

        ' 21/01/2009 - Rls15 - i 
        If Not (customPage.getFilterValue("ra_selecao", txt_nr_caderneta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_caderneta") = customPage.getFilterValue("ra_selecao", txt_nr_caderneta.ID)
            txt_nr_caderneta.Text = ViewState.Item("nr_caderneta").ToString()
        Else
            ViewState.Item("nr_caderneta") = String.Empty
        End If

        If Not (customPage.getFilterValue("ra_selecao", txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_linha") = customPage.getFilterValue("ra_selecao", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_linha").ToString()
        Else
            ViewState.Item("nm_linha") = String.Empty
        End If

        ' 21/01/2009 - Rls15 - f 
        'fran 17/06/2009 i
        If Not (customPage.getFilterValue("ra_selecao", txt_dt_hora_entrada.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_hora_entrada") = customPage.getFilterValue("ra_selecao", txt_dt_hora_entrada.ID)
            txt_dt_hora_entrada.Text = ViewState.Item("dt_hora_entrada").ToString()
        Else
            ViewState.Item("dt_hora_entrada") = String.Empty
        End If
        'fran 17/06/2009 f

        If (customPage.getFilterValue("ra_selecao", "btnpesquisar") = "S") Then
            hasFilters = True
            ViewState.Item("btnpesquisar") = customPage.getFilterValue("ra_selecao", "btnpesquisar")
        Else
            ViewState.Item("btnpesquisar") = "N"
        End If

        If Not (customPage.getFilterValue("ra_selecao", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("ra_selecao", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("ra_selecao")
        Else
            'Se veio da tela de analises
            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                loadData()
            End If
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio

            If Not (ViewState.Item("id_romaneio").ToString.Equals(String.Empty)) Then
                romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString())
            End If
            romaneio.ds_placa = ViewState.Item("ds_placa").ToString()
            '21/01/2009 - Rls15 i
            romaneio.nm_linha = ViewState.Item("nm_linha").ToString
            If Not (ViewState.Item("nr_caderneta").ToString.Equals(String.Empty)) Then
                romaneio.nr_caderneta = Convert.ToInt32(ViewState.Item("nr_caderneta").ToString())
            End If
            '21/01/2009 - Rls15 f
            'fran 17/06/2009 i
            romaneio.dt_hora_entrada = ViewState.Item("dt_hora_entrada").ToString
            'fran 17/06/2009 f
            'romaneio.id_st_romaneio = 2 'romaneio aberto totalmente

            '21/01/2009 - Rls15 (Alterada a procedure para implementar busca pela Rota) 
            Dim dsromaneio As DataSet = romaneio.getRomaneioAbertoEmAnaliseByFilters()

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


    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "id_romaneio"
                If (ViewState.Item("sortExpression")) = "id_romaneio asc" Then
                    ViewState.Item("sortExpression") = "id_romaneio desc"
                Else
                    ViewState.Item("sortExpression") = "id_romaneio asc"
                End If
            Case "nm_st_analise_global"
                If (ViewState.Item("sortExpression")) = "nm_st_analise_global asc" Then
                    ViewState.Item("sortExpression") = "nm_st_analise_global desc"
                Else
                    ViewState.Item("sortExpression") = "nm_st_analise_global asc"
                End If
            Case "nm_st_analise_compartimento"
                If (ViewState.Item("sortExpression")) = "nm_st_analise_compartimento asc" Then
                    ViewState.Item("sortExpression") = "nm_st_analise_compartimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_st_analise_compartimento asc"
                End If
            Case "nm_st_analise_uproducao"
                If (ViewState.Item("sortExpression")) = "nm_st_analise_uproducao asc" Then
                    ViewState.Item("sortExpression") = "nm_st_analise_uproducao desc"
                Else
                    ViewState.Item("sortExpression") = "nm_st_analise_uproducao asc"
                End If
            Case "dt_hora_entrada"
                If (ViewState.Item("sortExpression")) = "dt_hora_entrada asc" Then
                    ViewState.Item("sortExpression") = "dt_hora_entrada desc"
                Else
                    ViewState.Item("sortExpression") = "dt_hora_entrada asc"
                End If
            Case "ds_placa"
                If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
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

            customPage.setFilter("ra_selecao", txt_id_romaneio.ID, ViewState.Item("id_romaneio").ToString)
            customPage.setFilter("ra_selecao", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            ' 21/01/2009 - Rls15 - i
            customPage.setFilter("ra_selecao", txt_nr_caderneta.ID, ViewState.Item("nr_caderneta").ToString)
            customPage.setFilter("ra_selecao", txt_nm_linha.ID, ViewState.Item("nm_linha").ToString)
            ' 21/01/2009 - Rls15 - f
            customPage.setFilter("ra_selecao", "btnpesquisar", ViewState.Item("btnpesquisar").ToString)
            customPage.setFilter("ra_selecao", "PageIndex", gridResults.PageIndex.ToString())
            'fran 17/06/2009 i
            customPage.setFilter("ra_selecao", txt_dt_hora_entrada.ID, ViewState.Item("dt_hora_entrada").ToString)
            'fran 17/06/2009 f

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
                Response.Redirect("frm_romaneio_analise_comp_veiculo.aspx?id_romaneio=" + e.CommandArgument.ToString)
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

    End Sub
End Class
