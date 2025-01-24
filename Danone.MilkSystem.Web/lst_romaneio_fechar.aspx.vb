Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_romaneio_fechar

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_romaneio") = txt_id_romaneio.Text.Trim()
        ViewState.Item("ds_placa") = txt_placa.Text.Trim()

        ' 22/01/2009 - Rls15 - i
        Dim lberro As Boolean = False
        ViewState.Item("nm_linha") = txt_nm_linha.Text.Trim.ToString
        If txt_dt_transmissao_ini.Text.Trim.Equals(String.Empty) Then
            If Not txt_dt_transmissao_fim.Text.Trim.Equals(String.Empty) Then
                txt_dt_transmissao_ini.Text = txt_dt_transmissao_fim.Text
            End If
        End If
        If txt_dt_transmissao_fim.Text.Trim.Equals(String.Empty) Then
            If Not txt_dt_transmissao_ini.Text.Trim.Equals(String.Empty) Then
                txt_dt_transmissao_fim.Text = txt_dt_transmissao_ini.Text
            End If
        End If
        ViewState.Item("dt_transmissao_ini") = txt_dt_transmissao_ini.Text.Trim.ToString
        ViewState.Item("dt_transmissao_fim") = txt_dt_transmissao_fim.Text.Trim.ToString
        If Not txt_dt_transmissao_ini.Text.Trim.Equals(String.Empty) Then
            If CDate(txt_dt_transmissao_ini.Text) > CDate(txt_dt_transmissao_fim.Text) Then
                lberro = True
                messageControl.Alert("A data de transmissão inicial deve ser menor do que a data de transmissão final!")
            End If
        End If
        ' 22/01/2009 - Rls15 - i

        If lberro = False Then

            loadData()

        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_fechar.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_fechar.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 24
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
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

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("lst_romfechar", txt_id_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("lst_romfechar", txt_id_romaneio.ID)
            txt_id_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If


        If Not (customPage.getFilterValue("lst_romfechar", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("lst_romfechar", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If

        ' 22/01/2009 - Rls15 - i
        If Not (customPage.getFilterValue("lst_romfechar", txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_linha") = customPage.getFilterValue("lst_romfechar", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_linha").ToString()
        Else
            ViewState.Item("nm_linha") = String.Empty
        End If
        If Not (customPage.getFilterValue("lst_romfechar", txt_dt_transmissao_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_transmissao_ini") = customPage.getFilterValue("lst_romfechar", txt_dt_transmissao_ini.ID)
            txt_dt_transmissao_ini.Text = ViewState.Item("dt_transmissao_ini").ToString()
        Else
            ViewState.Item("dt_transmissao_ini") = String.Empty
        End If
        If Not (customPage.getFilterValue("lst_romfechar", txt_dt_transmissao_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_transmissao_fim") = customPage.getFilterValue("lst_romfechar", txt_dt_transmissao_fim.ID)
            txt_dt_transmissao_fim.Text = ViewState.Item("dt_transmissao_fim").ToString()
        Else
            ViewState.Item("dt_transmissao_fim") = String.Empty
        End If
        ' 22/01/2009 - Rls15 - f

        If Not (customPage.getFilterValue("lst_romfechar", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("lst_romfechar", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("lst_romfechar")
        Else
            'Se veio de outra tela
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
            ' 22/01/2009 - Rls15 - i
            romaneio.nm_linha = ViewState.Item("nm_linha").ToString
            romaneio.dt_transmissao_ini = ViewState.Item("dt_transmissao_ini").ToString
            romaneio.dt_transmissao_fim = ViewState.Item("dt_transmissao_fim").ToString
            ' 22/01/2009 - Rls15 - i

            Dim dsromaneio As DataSet = romaneio.getRomaneioFecharEmAnaliseByFilters() ' 22/01/2009 (procedure alterada para a data de transmissao e rota) - Rls15

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
            Case "ds_transportador"
                If (ViewState.Item("sortExpression")) = "ds_transportador asc" Then
                    ViewState.Item("sortExpression") = "ds_transportador desc"
                Else
                    ViewState.Item("sortExpression") = "ds_transportador asc"
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

            customPage.setFilter("lst_romfechar", txt_id_romaneio.ID, ViewState.Item("id_romaneio").ToString)
            customPage.setFilter("lst_romfechar", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            '22/01/2009 - Rls15 i
            customPage.setFilter("lst_romfechar", txt_nm_linha.ID, ViewState.Item("nm_linha").ToString)
            customPage.setFilter("lst_romfechar", txt_dt_transmissao_ini.ID, ViewState.Item("dt_transmissao_ini").ToString)
            customPage.setFilter("lst_romfechar", txt_dt_transmissao_fim.ID, ViewState.Item("dt_transmissao_fim").ToString)
            '22/01/2009 - Rls15 f
            customPage.setFilter("lst_romfechar", "PageIndex", gridResults.PageIndex.ToString())

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

                Response.Redirect("frm_romaneio_fechar.aspx?id_romaneio=" + e.CommandArgument.ToString)


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


End Class
