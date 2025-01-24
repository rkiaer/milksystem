Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_pre_romaneio_transvase_consulta

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click


        ViewState.Item("id_romaneio") = txt_id_romaneio.Text.Trim()
        ViewState.Item("nr_caderneta") = txt_nr_caderneta.Text.Trim()
        ViewState.Item("ds_placa") = txt_placa.Text.Trim()
        ViewState.Item("id_st_romaneio") = cbo_situacao.SelectedValue.ToString
        ViewState.Item("nm_linha") = txt_nm_linha.Text.Trim()
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue.ToString
        Dim lberro As Boolean = False
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

        If lberro = False Then

            loadData()

        End If





    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_pre_romaneio_transvase_consulta.aspx?limpar=S")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_pre_romaneio_transvase_consulta.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("limpar") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 229
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
            cbo_situacao.Items.RemoveAt(1)
            cbo_situacao.Items.RemoveAt(1)
            cbo_situacao.Items.RemoveAt(1)
            cbo_situacao.Items.RemoveAt(1)
            cbo_situacao.Items.RemoveAt(1)
            cbo_situacao.Items.RemoveAt(1)
            cbo_situacao.Items.RemoveAt(1)
            cbo_situacao.Items.RemoveAt(1)
            cbo_situacao.Items.RemoveAt(1)
            cbo_situacao.Items.RemoveAt(1)
            cbo_situacao.Items.RemoveAt(1)
            cbo_situacao.Items.RemoveAt(1)
            cbo_situacao.Items.FindByValue("0").Selected = True

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            If Not (Request("limpar") Is Nothing) Then  '  Se veio do Limpar Filtro
                txt_dt_hora_entrada_ini.Text = ""
                txt_dt_hora_entrada_fim.Text = ""
            Else
                txt_dt_hora_entrada_ini.Text = Format(Date.Today, "dd/MM/yyyy").ToString()
                txt_dt_hora_entrada_fim.Text = Format(Date.Today, "dd/MM/yyyy").ToString()
            End If

            ViewState.Item("sortExpression") = "id_romaneio asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("pre_cons_transv", txt_id_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("pre_cons_transv", txt_id_romaneio.ID)
            txt_id_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If
        If Not (customPage.getFilterValue("pre_cons_transv", txt_nr_caderneta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_caderneta") = customPage.getFilterValue("pre_cons_transv", txt_nr_caderneta.ID)
            txt_nr_caderneta.Text = ViewState.Item("nr_caderneta").ToString()
        Else
            ViewState.Item("nr_caderneta") = String.Empty
        End If
        If Not (customPage.getFilterValue("pre_cons_transv", txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_linha") = customPage.getFilterValue("pre_cons_transv", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_linha").ToString()
        Else
            ViewState.Item("nm_linha") = String.Empty
        End If

        If Not (customPage.getFilterValue("pre_cons_transv", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("pre_cons_transv", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If

        If Not (customPage.getFilterValue("pre_cons_transv", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_st_romaneio") = customPage.getFilterValue("pre_cons_transv", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_st_romaneio").ToString()
        Else
            ViewState.Item("id_st_romaneio") = String.Empty
        End If
        If Not (customPage.getFilterValue("pre_cons_transv", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("pre_cons_transv", cbo_estabelecimento.ID)
            cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
            'ViewState.Item("id_transit_point_unidade") = String.Empty
            'Dim transit As New TransitPointUnidade
            'cbo_transit_point.Enabled = True
            'cbo_transit_point.DataSource = transit.getTransitPointUnidadeByFilters()
            'cbo_transit_point.DataTextField = "ds_transit_point_unidade"
            'cbo_transit_point.DataValueField = "id_transit_point_unidade"
            'cbo_transit_point.DataBind()
            'cbo_transit_point.Items.Insert(0, New ListItem("[Selecione]", "0"))
            'cbo_transit_point.SelectedValue = 0

            'ViewState.Item("id_transit_point_unidade") = customPage.getFilterValue("pre_cons_transv", cbo_transit_point.ID)
            'cbo_transit_point.Text = ViewState.Item("id_transit_point_unidade").ToString()
        End If

        ' 26/01/2011 - adri gko fase 2 - i
        If Not (customPage.getFilterValue("pre_cons_transv", txt_dt_hora_entrada_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_hora_entrada_ini") = customPage.getFilterValue("pre_cons_transv", txt_dt_hora_entrada_ini.ID)
            txt_dt_hora_entrada_ini.Text = ViewState.Item("dt_hora_entrada_ini").ToString()
        Else
            ViewState.Item("dt_hora_entrada_ini") = String.Empty
        End If

        If Not (customPage.getFilterValue("pre_cons_transv", txt_dt_hora_entrada_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_hora_entrada_fim") = customPage.getFilterValue("pre_cons_transv", txt_dt_hora_entrada_fim.ID)
            txt_dt_hora_entrada_fim.Text = ViewState.Item("dt_hora_entrada_fim").ToString()
        Else
            ViewState.Item("dt_hora_entrada_fim") = String.Empty
        End If



        If Not (customPage.getFilterValue("pre_cons_transv", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("pre_cons_transv", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("pre_cons_transv")
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
            If Not (ViewState.Item("nr_caderneta").ToString.Equals(String.Empty)) Then
                romaneio.nr_caderneta = Convert.ToInt32(ViewState.Item("nr_caderneta").ToString())
            End If
            romaneio.nm_linha = ViewState.Item("nm_linha").ToString()
            romaneio.ds_placa = ViewState.Item("ds_placa").ToString()
            romaneio.id_st_romaneio = ViewState.Item("id_st_romaneio").ToString()
            romaneio.dt_hora_entrada_ini = ViewState.Item("dt_hora_entrada_ini").ToString
            romaneio.dt_hora_entrada_fim = ViewState.Item("dt_hora_entrada_fim").ToString
            dsromaneio = romaneio.getPreRomaneioTransvaseSelecionar

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
            Case "nr_caderneta"
                If (ViewState.Item("sortExpression")) = "nr_caderneta asc" Then
                    ViewState.Item("sortExpression") = "nr_caderneta desc"
                Else
                    ViewState.Item("sortExpression") = "nr_caderneta asc"
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

            customPage.setFilter("pre_cons_transv", txt_id_romaneio.ID, ViewState.Item("id_romaneio").ToString)
            customPage.setFilter("pre_cons_transv", txt_nr_caderneta.ID, ViewState.Item("nr_caderneta").ToString)
            customPage.setFilter("pre_cons_transv", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            customPage.setFilter("pre_cons_transv", cbo_situacao.ID, ViewState.Item("id_st_romaneio").ToString)
            customPage.setFilter("pre_cons_transv", txt_nm_linha.ID, ViewState.Item("nm_linha").ToString)
            customPage.setFilter("pre_cons_transv", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("pre_cons_transv", "PageIndex", gridResults.PageIndex.ToString())

            customPage.setFilter("pre_cons_transv", txt_dt_hora_entrada_ini.ID, ViewState.Item("dt_hora_entrada_ini").ToString)
            customPage.setFilter("pre_cons_transv", txt_dt_hora_entrada_fim.ID, ViewState.Item("dt_hora_entrada_fim").ToString)

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

                Response.Redirect("frm_pre_romaneio_transvase_consulta.aspx?id_romaneio=" + e.CommandArgument.ToString)


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
