Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_romaneio_abertura_transvase
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        Dim lberro As Boolean = False

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        ViewState.Item("id_transvase") = txt_id_transit_point.Text.Trim()
        ViewState.Item("ds_placa") = txt_placa.Text.Trim()
        ViewState.Item("nm_linha") = txt_nm_linha.Text.Trim.ToString
        If txt_dt_ini.Text.Trim.Equals(String.Empty) Then
            If Not txt_dt_fim.Text.Trim.Equals(String.Empty) Then
                txt_dt_ini.Text = txt_dt_fim.Text
            End If
        End If
        If txt_dt_fim.Text.Trim.Equals(String.Empty) Then
            If Not txt_dt_ini.Text.Trim.Equals(String.Empty) Then
                txt_dt_fim.Text = txt_dt_ini.Text
            End If
        End If
        ViewState.Item("dt_ini") = txt_dt_ini.Text.Trim.ToString
        ViewState.Item("dt_fim") = txt_dt_fim.Text.Trim.ToString
        If Not txt_dt_ini.Text.Trim.Equals(String.Empty) Then
            If CDate(txt_dt_ini.Text) > CDate(txt_dt_fim.Text) Then
                lberro = True
                messageControl.Alert("A data de abertura inicial deve ser menor do que a data final!")
            End If
        End If

        If lberro = False Then

            loadData()

        End If


    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_abertura_transvase.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_abertura_transvase.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 231
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


            ViewState.Item("sortExpression") = "id_transvase desc"
            'Fran
            'txt_dt_hora_entrada.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("romaneiotp", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("romaneiotp", cbo_estabelecimento.ID)
            cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If
        If Not (customPage.getFilterValue("romaneiotp", txt_id_transit_point.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_transvase") = customPage.getFilterValue("romaneiotp", txt_id_transit_point.ID)
            txt_id_transit_point.Text = ViewState.Item("id_transvase").ToString()
        Else
            ViewState.Item("id_transvase") = String.Empty
        End If


        If Not (customPage.getFilterValue("romaneiotp", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("romaneiotp", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If
        If Not (customPage.getFilterValue("romaneiotp", txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_linha") = customPage.getFilterValue("romaneiotp", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_linha").ToString()
        Else
            ViewState.Item("nm_linha") = String.Empty
        End If
        If Not (customPage.getFilterValue("romaneiotp", txt_dt_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_ini") = customPage.getFilterValue("romaneiotp", txt_dt_ini.ID)
            txt_dt_ini.Text = ViewState.Item("dt_ini").ToString()
        Else
            ViewState.Item("dt_ini") = String.Empty
        End If
        If Not (customPage.getFilterValue("romaneiotp", txt_dt_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_fim") = customPage.getFilterValue("romaneiotp", txt_dt_fim.ID)
            txt_dt_fim.Text = ViewState.Item("dt_fim").ToString()
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If
        'fran 20/12/2008 f
        If Not (customPage.getFilterValue("romaneiotp", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("romaneiotp", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("caderneta")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim transvase As New Transvase

            If Not (ViewState.Item("id_transvase").ToString.Equals(String.Empty)) Then
                transvase.id_transvase = Convert.ToInt32(ViewState.Item("id_transvase").ToString())
            End If
            If Not (ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty)) Then
                transvase.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString()
            End If
            transvase.ds_placa = ViewState.Item("ds_placa").ToString()
            transvase.nm_linha = ViewState.Item("nm_linha").ToString
            transvase.dt_ini = ViewState.Item("dt_ini").ToString
            transvase.dt_fim = ViewState.Item("dt_fim").ToString

            Dim dstransit As DataSet = transvase.getTransvaseAberturaRomaneio()

            If (dstransit.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dstransit.Tables(0), ViewState.Item("sortExpression"))
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


            Case "id_transvase"
                If (ViewState.Item("sortExpression")) = "id_transvase asc" Then
                    ViewState.Item("sortExpression") = "id_transvase desc"
                Else
                    ViewState.Item("sortExpression") = "id_transvase asc"
                End If


            Case "nm_linha"
                If (ViewState.Item("sortExpression")) = "nm_linha asc" Then
                    ViewState.Item("sortExpression") = "nm_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nm_linha asc"
                End If
            Case "ds_placa"
                If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
                End If
            Case "dt_abertura"
                If (ViewState.Item("sortExpression")) = "dt_abertura asc" Then
                    ViewState.Item("sortExpression") = "dt_abertura desc"
                Else
                    ViewState.Item("sortExpression") = "dt_abertura asc"
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

            customPage.setFilter("romaneiotp", txt_id_transit_point.ID, ViewState.Item("id_transvase").ToString)
            customPage.setFilter("romaneiotp", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            customPage.setFilter("romaneiotp", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            'Fran 29/12/2008 i
            customPage.setFilter("romaneiotp", txt_nm_linha.ID, ViewState.Item("nm_linha").ToString)
            customPage.setFilter("romaneiotp", txt_dt_ini.ID, ViewState.Item("dt_ini").ToString)
            customPage.setFilter("romaneiotp", txt_dt_fim.ID, ViewState.Item("dt_fim").ToString)
            'fran 29/12/2008 f
            customPage.setFilter("romaneiotp", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Dim id_romaneio As Int32


        Select Case e.CommandName.ToString().ToLower()
            Case "selecionar"
                'Dim strmessage As String

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 231
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                saveFilters()

                id_romaneio = abrirRomaneioTransvase(Convert.ToInt32(e.CommandArgument.ToString))
                If id_romaneio > 0 Then

                    Response.Redirect("frm_romaneio_mensagem.aspx?id_romaneio=" + id_romaneio.ToString + "&id_transvase=" + e.CommandArgument.ToString)


                End If


        End Select

    End Sub

    Protected Sub bt_lupa_veiculo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_veiculo.Click

        carregarCamposVeiculo()

    End Sub

    Private Function abrirRomaneioTransvase(ByVal id_transvase As Int32) As Int32
        If Page.IsValid = True Then

            Try

                Dim transvase As New Transvase(id_transvase)
                Dim romaneio As New Romaneio()

                romaneio.id_transvase = Convert.ToInt32(id_transvase)
                romaneio.id_modificador = Session("id_login")
                romaneio.id_estabelecimento = transvase.id_estabelecimento
                romaneio.romaneio_compartimento = New Romaneio_Compartimento
                romaneio.romaneio_compartimento.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento.romaneio_uproducao.id_modificador = Session("id_login")

                Return Convert.ToInt32(romaneio.abrirRomaneioTransvase())

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Function


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

    Protected Sub gridResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub


End Class
