Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_romaneio_saida_analise_selecao

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_romaneio_saida") = txt_id_romaneio.Text.Trim()
        ViewState.Item("ds_placa") = txt_placa.Text.Trim()
        ViewState.Item("dt_hora_entrada") = txt_dt_hora_entrada.Text.Trim.ToString
        ViewState.Item("btnpesquisar") = "S"

        loadData()


    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_saida_analise_selecao.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_saida_analise_selecao.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 248
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


            ViewState.Item("sortExpression") = "id_romaneio_saida desc"
            'Fran
            txt_dt_hora_entrada.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("rsaidaa_selecao", txt_id_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio_saida") = customPage.getFilterValue("rsaidaa_selecao", txt_id_romaneio.ID)
            txt_id_romaneio.Text = ViewState.Item("id_romaneio_sadia").ToString()
        Else
            ViewState.Item("id_romaneio_saida") = String.Empty
        End If

        If Not (customPage.getFilterValue("rsaidaa_selecao", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("rsaidaa_selecao", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If

        If Not (customPage.getFilterValue("rsaidaa_selecao", txt_dt_hora_entrada.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_hora_entrada") = customPage.getFilterValue("rsaidaa_selecao", txt_dt_hora_entrada.ID)
            txt_dt_hora_entrada.Text = ViewState.Item("dt_hora_entrada").ToString()
        Else
            ViewState.Item("dt_hora_entrada") = String.Empty
        End If

        If (customPage.getFilterValue("rsaidaa_selecao", "btnpesquisar") = "S") Then
            hasFilters = True
            ViewState.Item("btnpesquisar") = customPage.getFilterValue("rsaidaa_selecao", "btnpesquisar")
        Else
            ViewState.Item("btnpesquisar") = "N"
        End If

        If Not (customPage.getFilterValue("rsaidaa_selecao", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("rsaidaa_selecao", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("rsaidaa_selecao")
        Else
            'Se veio da tela de analises
            If Not (Request("id_romaneio_saida") Is Nothing) Then
                ViewState.Item("id_romaneio_saida") = Request("id_romaneio_saida")
                loadData()
            End If
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New RomaneioSaida

            If Not (ViewState.Item("id_romaneio_saida").ToString.Equals(String.Empty)) Then
                romaneio.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida").ToString())
            End If
            romaneio.ds_placa = ViewState.Item("ds_placa").ToString()
            romaneio.dt_hora_entrada = ViewState.Item("dt_hora_entrada").ToString

            Dim dsromaneio As DataSet = romaneio.getRomaneioSaidaCarregadoEmAnalise()

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
                If (ViewState.Item("sortExpression")) = "id_romaneio_saida asc" Then
                    ViewState.Item("sortExpression") = "id_romaneio_saida desc"
                Else
                    ViewState.Item("sortExpression") = "id_romaneio_saida asc"
                End If
            Case "nm_st_analise_compartimento"
                If (ViewState.Item("sortExpression")) = "nm_st_analise_compartimento asc" Then
                    ViewState.Item("sortExpression") = "nm_st_analise_compartimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_st_analise_compartimento asc"
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

            customPage.setFilter("rsaidaa_selecao", txt_id_romaneio.ID, ViewState.Item("id_romaneio_saida").ToString)
            customPage.setFilter("rsaidaa_selecao", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            customPage.setFilter("rsaidaa_selecao", "btnpesquisar", ViewState.Item("btnpesquisar").ToString)
            customPage.setFilter("rsaidaa_selecao", "PageIndex", gridResults.PageIndex.ToString())
            'fran 17/06/2009 i
            customPage.setFilter("rsaidaa_selecao", txt_dt_hora_entrada.ID, ViewState.Item("dt_hora_entrada").ToString)
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

                Response.Redirect("frm_romaneio_saida_analise_comp_veiculo.aspx?id_romaneio_saida=" + e.CommandArgument.ToString)
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
