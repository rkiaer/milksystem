Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_romaneio_caderneta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        Dim lberro As Boolean = False

        ViewState.Item("nr_caderneta") = txt_nr_caderneta.Text.Trim()
        ViewState.Item("ds_placa") = txt_placa.Text.Trim()
        ViewState.Item("cd_cnh") = txt_cd_transportador.Text.Trim.ToString
        'fran 30/12/2008 i
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
        'Fran 29/12/2008 f

        If lberro = False Then

            loadData()

        End If


    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_caderneta.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_caderneta.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 17
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
        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportadores"
        End With

    End Sub


    Private Sub loadDetails()

        Try


            ViewState.Item("sortExpression") = "dt_transmissao asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("romaneio_caderneta", txt_nr_caderneta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_caderneta") = customPage.getFilterValue("romaneio_caderneta", txt_nr_caderneta.ID)
            txt_nr_caderneta.Text = ViewState.Item("nr_caderneta").ToString()
        Else
            ViewState.Item("nr_caderneta") = String.Empty
        End If

        If Not (customPage.getFilterValue("romaneio_caderneta", txt_cd_transportador.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_cnh") = customPage.getFilterValue("romaneio_caderneta", txt_cd_transportador.ID)
            txt_cd_transportador.Text = ViewState.Item("cd_cnh").ToString()
        Else
            ViewState.Item("cd_cnh") = String.Empty
        End If


        If Not (customPage.getFilterValue("romaneio_caderneta", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("romaneio_caderneta", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If
        'Fran 29/12/2008 i
        If Not (customPage.getFilterValue("romaneio_caderneta", txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_linha") = customPage.getFilterValue("romaneio_caderneta", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_linha").ToString()
        Else
            ViewState.Item("nm_linha") = String.Empty
        End If
        If Not (customPage.getFilterValue("romaneio_caderneta", txt_dt_transmissao_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_transmissao_ini") = customPage.getFilterValue("romaneio_caderneta", txt_dt_transmissao_ini.ID)
            txt_dt_transmissao_ini.Text = ViewState.Item("dt_transmissao_ini").ToString()
        Else
            ViewState.Item("dt_transmissao_ini") = String.Empty
        End If
        If Not (customPage.getFilterValue("romaneio_caderneta", txt_dt_transmissao_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_transmissao_fim") = customPage.getFilterValue("romaneio_caderneta", txt_dt_transmissao_fim.ID)
            txt_dt_transmissao_fim.Text = ViewState.Item("dt_transmissao_fim").ToString()
        Else
            ViewState.Item("dt_transmissao_fim") = String.Empty
        End If
        'fran 20/12/2008 f
        If Not (customPage.getFilterValue("romaneio_caderneta", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("romaneio_caderneta", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("caderneta")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim caderneta As New Caderneta

            If Not (ViewState.Item("nr_caderneta").ToString.Equals(String.Empty)) Then
                caderneta.nr_caderneta = Convert.ToInt32(ViewState.Item("nr_caderneta").ToString())
            End If
            caderneta.cd_transportador = ViewState.Item("cd_cnh").ToString()
            caderneta.ds_placa = ViewState.Item("ds_placa").ToString()
            caderneta.st_leite_desviado = "N"

            'Fran 29/12/2008 i
            caderneta.nm_linha = ViewState.Item("nm_linha").ToString
            caderneta.dt_transmissao_ini = ViewState.Item("dt_transmissao_ini").ToString
            caderneta.dt_transmissao_fim = ViewState.Item("dt_transmissao_fim").ToString
            'caderneta.st_leite_desviado = "N"
            'Fran 29/12/2008 f

            Dim dsCadernetaHeader As DataSet = caderneta.getRomaneioCadernetaByFilters()

            If (dsCadernetaHeader.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsCadernetaHeader.Tables(0), ViewState.Item("sortExpression"))
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


            Case "nr_caderneta"
                If (ViewState.Item("sortExpression")) = "id_protocolo asc" Then
                    ViewState.Item("sortExpression") = "id_protocolo desc"
                Else
                    ViewState.Item("sortExpression") = "id_protocolo asc"
                End If


            Case "ds_transportador"
                If (ViewState.Item("sortExpression")) = "ds_transportador asc" Then
                    ViewState.Item("sortExpression") = "ds_transportador desc"
                Else
                    ViewState.Item("sortExpression") = "ds_transportador asc"
                End If
            Case "ds_placa"
                If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
                End If
            Case "dt_transmissao"
                If (ViewState.Item("sortExpression")) = "dt_transmissao asc" Then
                    ViewState.Item("sortExpression") = "dt_transmissao desc"
                Else
                    ViewState.Item("sortExpression") = "dt_transmissao asc"
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
    Private Sub carregarCamposTransportador()

        Try



            If Not (customPage.getFilterValue("lupa_transportador", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transportador", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transportador", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transportador", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_transportador")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try

            customPage.setFilter("romaneio_caderneta", txt_nr_caderneta.ID, ViewState.Item("nr_caderneta").ToString)
            customPage.setFilter("romaneio_caderneta", txt_cd_transportador.ID, ViewState.Item("cd_cnh").ToString)
            customPage.setFilter("romaneio_caderneta", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            'Fran 29/12/2008 i
            customPage.setFilter("romaneio_caderneta", txt_nm_linha.ID, ViewState.Item("nm_linha").ToString)
            customPage.setFilter("romaneio_caderneta", txt_dt_transmissao_ini.ID, ViewState.Item("dt_transmissao_ini").ToString)
            customPage.setFilter("romaneio_caderneta", txt_dt_transmissao_fim.ID, ViewState.Item("dt_transmissao_fim").ToString)
            'fran 29/12/2008 f
            customPage.setFilter("romaneio_caderneta", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Dim id_romaneio As Int32


        Select Case e.CommandName.ToString().ToLower()
            Case "selecionar"
                'Dim strmessage As String
                If Page.IsValid Then
                    saveFilters()

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'processo
                    usuariolog.id_menu_item = 17
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 


                    id_romaneio = abrirRomaneio(Convert.ToInt32(e.CommandArgument.ToString))
                    If id_romaneio > 0 Then

                        Response.Redirect("frm_romaneio_mensagem.aspx?id_romaneio=" + id_romaneio.ToString + "&nr_caderneta=" + e.CommandArgument.ToString)


                    End If
                End If

        End Select

    End Sub

    Protected Sub bt_lupa_veiculo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_veiculo.Click

        carregarCamposVeiculo()

    End Sub

    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidtransportador As Int32
            If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
            lidtransportador = pessoa.validarTransportador

            If lidtransportador > 0 Then
                args.IsValid = True
                hf_id_pessoa.Value = lidtransportador
            Else
                hf_id_pessoa.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Transportador não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function abrirRomaneio(ByVal nr_caderneta As Int32) As Int32
        If Page.IsValid = True Then

            Try

                Dim romaneio As New Romaneio()

                romaneio.nr_caderneta = Convert.ToInt32(nr_caderneta)
                romaneio.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento = New Romaneio_Compartimento
                romaneio.romaneio_compartimento.id_modificador = Session("id_login")
                romaneio.romaneio_compartimento.romaneio_uproducao.id_modificador = Session("id_login")

                Return Convert.ToInt32(romaneio.abrirRomaneio())

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Function

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
        Else
            txt_cd_transportador.Text = String.Empty
            hf_id_pessoa.Value = String.Empty
            lbl_nm_transportador.Text = String.Empty
            lbl_nm_transportador.Visible = False
        End If


    End Sub

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        lbl_nm_transportador.Text = String.Empty
        lbl_nm_transportador.Visible = False
        hf_id_pessoa.Value = String.Empty

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

    Protected Sub gridResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub
    

    Protected Sub img_editar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        messageControl.Alert("OI")
        Response.Redirect("frmromaneio.aspx")


    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim ds_tempo_coleta_now As Label = CType(e.Row.FindControl("ds_tempo_coleta_now"), Label)
                Dim img_editar As Anthem.ImageButton = CType(e.Row.FindControl("img_editar"), Anthem.ImageButton)

                If Not ds_tempo_coleta_now.Text.Equals(String.Empty) Then

                    If CDec(ds_tempo_coleta_now.Text) > 0 Then
                        img_editar.Enabled = True
                        img_editar.ImageUrl = "~/img/abrir_romaneio.gif"
                    Else
                        img_editar.Enabled = False
                        img_editar.ImageUrl = "~/img/abrir_romaneio_desabilitado.gif"
                        img_editar.ToolTip = "Não pode ser Aberto! Data de Coleta é MAIOR que a data/hora atual."
                    End If
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
End Class
