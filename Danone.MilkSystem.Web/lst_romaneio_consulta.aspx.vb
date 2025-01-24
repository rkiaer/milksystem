Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_romaneio_consulta

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_romaneio") = txt_id_romaneio.Text.Trim()
        ViewState.Item("id_transit_point") = txt_transit_point.Text.Trim()
        ViewState.Item("id_transvase") = txt_transvase.Text.Trim()
        ViewState.Item("ds_placa") = txt_placa.Text.Trim()
        ViewState.Item("id_st_romaneio") = cbo_situacao.SelectedValue.ToString
        ' 22/01/2011 - gko fase 2 - i
        Dim lberro As Boolean = False
        ViewState.Item("tipo") = cbo_tipo.SelectedValue.ToString
        If txt_dt_hora_entrada_ini.Text.Trim.Equals(String.Empty) Then
            If Not txt_dt_hora_entrada_fim.Text.Trim.Equals(String.Empty) Then
                txt_dt_hora_entrada_ini.Text = txt_dt_hora_entrada_fim.Text
            End If
        End If
        If txt_dt_hora_entrada_fim.Text.Trim.Equals(String.Empty) Then
            If Not txt_dt_hora_entrada_ini.Text.Trim.Equals(String.Empty) Then
                txt_dt_hora_entrada_fim.Text = txt_dt_hora_entrada_ini.Text
            End If
        End If
        ViewState.Item("dt_hora_entrada_ini") = txt_dt_hora_entrada_ini.Text.Trim.ToString
        ViewState.Item("dt_hora_entrada_fim") = txt_dt_hora_entrada_fim.Text.Trim.ToString
        If Not txt_dt_hora_entrada_ini.Text.Trim.Equals(String.Empty) Then
            If CDate(txt_dt_hora_entrada_ini.Text) > CDate(txt_dt_hora_entrada_fim.Text) Then
                lberro = True
                messageControl.Alert("A data de entrada inicial deve ser menor do que a data de entrada final!")
            End If
        End If
        ' 22/01/2011 - gko fase 2 - f

        If lberro = False Then

            loadData()

        End If





    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_consulta.aspx?limpar=S")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_consulta.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("limpar") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 62
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

            Dim status As New StatusRomaneio

            cbo_situacao.DataSource = status.getStatusRomaneioByFilters()
            cbo_situacao.DataTextField = "nm_st_romaneio"
            cbo_situacao.DataValueField = "id_st_romaneio"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))
            'fran 02/2017 retirar itens de TRANSIT POINT
            cbo_situacao.Items.RemoveAt(7)
            cbo_situacao.Items.RemoveAt(7)
            cbo_situacao.Items.RemoveAt(7)
            cbo_situacao.Items.RemoveAt(7)
            cbo_situacao.Items.RemoveAt(7)
            cbo_situacao.Items.RemoveAt(7)
            'fran 02/2017 retirar itens de TRANSIT POINT

            cbo_situacao.Items.FindByValue("0").Selected = True

            ' adri 26/01/2011 (gko fase 2) - i
            If Not (Request("limpar") Is Nothing) Then  '  Se veio do Limpar Filtro
                txt_dt_hora_entrada_ini.Text = ""
                txt_dt_hora_entrada_fim.Text = ""
            Else
                txt_dt_hora_entrada_ini.Text = Format(Date.Today, "dd/MM/yyyy").ToString()
                txt_dt_hora_entrada_fim.Text = Format(Date.Today, "dd/MM/yyyy").ToString()
            End If
            ' adri 26/01/2011 (gko fase 2) f

            ViewState.Item("sortExpression") = "id_romaneio asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("lst_r_consulta", txt_id_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("lst_r_consulta", txt_id_romaneio.ID)
            txt_id_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If


        If Not (customPage.getFilterValue("lst_r_consulta", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("lst_r_consulta", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If

        If Not (customPage.getFilterValue("lst_r_consulta", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_st_romaneio") = customPage.getFilterValue("lst_r_consulta", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_st_romaneio").ToString()
        Else
            ViewState.Item("id_st_romaneio") = String.Empty
        End If

        ' 26/01/2011 - adri gko fase 2 - i
        If Not (customPage.getFilterValue("lst_r_consulta", txt_dt_hora_entrada_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_hora_entrada_ini") = customPage.getFilterValue("lst_r_consulta", txt_dt_hora_entrada_ini.ID)
            txt_dt_hora_entrada_ini.Text = ViewState.Item("dt_hora_entrada_ini").ToString()
        Else
            ViewState.Item("dt_hora_entrada_ini") = String.Empty
        End If

        If Not (customPage.getFilterValue("lst_r_consulta", txt_dt_hora_entrada_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_hora_entrada_fim") = customPage.getFilterValue("lst_r_consulta", txt_dt_hora_entrada_fim.ID)
            txt_dt_hora_entrada_fim.Text = ViewState.Item("dt_hora_entrada_fim").ToString()
        Else
            ViewState.Item("dt_hora_entrada_fim") = String.Empty
        End If

        If Not (customPage.getFilterValue("lst_r_consulta", cbo_tipo.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("tipo") = customPage.getFilterValue("lst_r_consulta", cbo_tipo.ID)
            cbo_tipo.Text = ViewState.Item("tipo").ToString()
        Else
            ViewState.Item("tipo") = String.Empty
        End If
        ' 26/01/2011 - adri gko fase 2 - i


        If Not (customPage.getFilterValue("lst_r_consulta", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("lst_r_consulta", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("lst_r_consulta")
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
            Dim dsromaneio As DataSet

            If Not (ViewState.Item("id_romaneio").ToString.Equals(String.Empty)) Then
                romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString())
            End If
            If Not (ViewState.Item("id_transit_point").ToString.Equals(String.Empty)) Then
                romaneio.id_transit_point = Convert.ToInt32(ViewState.Item("id_transit_point").ToString())
            End If
            If Not (ViewState.Item("id_transvase").ToString.Equals(String.Empty)) Then
                romaneio.id_transvase = Convert.ToInt32(ViewState.Item("id_transvase").ToString())
            End If

            romaneio.ds_placa = ViewState.Item("ds_placa").ToString()
            romaneio.id_st_romaneio = ViewState.Item("id_st_romaneio").ToString()
            ' 22/01/2011 - gko fase 2 - i
            'Dim dsromaneio As DataSet = romaneio.getRomaneioByFilters()
            romaneio.dt_hora_entrada_ini = ViewState.Item("dt_hora_entrada_ini").ToString
            romaneio.dt_hora_entrada_fim = ViewState.Item("dt_hora_entrada_fim").ToString
            dsromaneio = romaneio.getRomaneioByFilters()
            If ViewState.Item("tipo").ToString = "1" Then
                dsromaneio = romaneio.getRomaneioCooperativa()
            End If
            If ViewState.Item("tipo").ToString = "2" Then
                dsromaneio = romaneio.getRomaneioProdutor()
            End If
            ' 22/01/2011 - gko fase 2 - i


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

            customPage.setFilter("lst_r_consulta", txt_id_romaneio.ID, ViewState.Item("id_romaneio").ToString)
            customPage.setFilter("lst_r_consulta", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            customPage.setFilter("lst_r_consulta", cbo_situacao.ID, ViewState.Item("id_st_romaneio").ToString)
            customPage.setFilter("lst_r_consulta", "PageIndex", gridResults.PageIndex.ToString())

            ' 26/01/2011 - adri gko fase 2 - i
            customPage.setFilter("lst_r_consulta", txt_dt_hora_entrada_ini.ID, ViewState.Item("dt_hora_entrada_ini").ToString)
            customPage.setFilter("lst_r_consulta", txt_dt_hora_entrada_fim.ID, ViewState.Item("dt_hora_entrada_fim").ToString)
            customPage.setFilter("lst_r_consulta", cbo_tipo.ID, ViewState.Item("tipo").ToString)
            ' 26/01/2011 - adri gko fase 2 - i

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

                Response.Redirect("frm_romaneio_consulta.aspx?id_romaneio=" + e.CommandArgument.ToString)


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

    Protected Sub txt_dt_hora_entrada_ini_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dt_hora_entrada_ini.Load

    End Sub


    Protected Sub txt_dt_hora_entrada_ini_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dt_hora_entrada_ini.TextChanged

    End Sub

    Protected Sub txt_dt_hora_entrada_fim_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dt_hora_entrada_fim.TextChanged

    End Sub
End Class
