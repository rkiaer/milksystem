Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_romaneio_complementar_dados

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            Dim lberro As Boolean = False
            ViewState.Item("id_romaneio") = txt_id_romaneio.Text.Trim()
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
        End If


    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_complementar_dados.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_complementar_dados.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 21
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


            ViewState.Item("sortExpression") = "id_romaneio asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("romaneio_compl_dados", txt_id_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("romaneio_compl_dados", txt_id_romaneio.ID)
            txt_id_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If

        If Not (customPage.getFilterValue("romaneio_compl_dados", txt_cd_transportador.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_cnh") = customPage.getFilterValue("romaneio_compl_dados", txt_cd_transportador.ID)
            txt_cd_transportador.Text = ViewState.Item("cd_cnh").ToString()
        Else
            ViewState.Item("cd_cnh") = String.Empty
        End If


        If Not (customPage.getFilterValue("romaneio_compl_dados", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("romaneio_compl_dados", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If
        'Fran 29/12/2008 i
        If Not (customPage.getFilterValue("romaneio_compl_dados", txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_linha") = customPage.getFilterValue("romaneio_compl_dados", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_linha").ToString()
        Else
            ViewState.Item("nm_linha") = String.Empty
        End If
        If Not (customPage.getFilterValue("romaneio_compl_dados", txt_dt_transmissao_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_transmissao_ini") = customPage.getFilterValue("romaneio_compl_dados", txt_dt_transmissao_ini.ID)
            txt_dt_transmissao_ini.Text = ViewState.Item("dt_transmissao_ini").ToString()
        Else
            ViewState.Item("dt_transmissao_ini") = String.Empty
        End If
        If Not (customPage.getFilterValue("romaneio_compl_dados", txt_dt_transmissao_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_transmissao_fim") = customPage.getFilterValue("romaneio_compl_dados", txt_dt_transmissao_fim.ID)
            txt_dt_transmissao_fim.Text = ViewState.Item("dt_transmissao_fim").ToString()
        Else
            ViewState.Item("dt_transmissao_fim") = String.Empty
        End If
        'fran 20/12/2008 f

        If Not (customPage.getFilterValue("romaneio_compl_dados", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("romaneio_compl_dados", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("romaneio_compl_dados")
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
            If Not (hf_id_pessoa.Value.ToString.Equals(String.Empty)) Then
                romaneio.id_transportador = Convert.ToInt32(hf_id_pessoa.Value)
            End If

            romaneio.cd_transportador = ViewState.Item("cd_cnh").ToString()
            romaneio.ds_placa = ViewState.Item("ds_placa").ToString()
            romaneio.id_st_romaneio = 1 'romaneio aberto incompleto
            'Fran 29/12/2008 i
            romaneio.nm_linha = ViewState.Item("nm_linha").ToString
            romaneio.dt_transmissao_ini = ViewState.Item("dt_transmissao_ini").ToString
            romaneio.dt_transmissao_fim = ViewState.Item("dt_transmissao_fim").ToString
            'caderneta.st_leite_desviado = "N"
            'Fran 29/12/2008 f

            'Fran 30/09/2008 i faz outra procedures para buscar tb as cooperativas com status ABERTO (2)
            'Dim dsromaneio As DataSet = romaneio.getRomaneioByFilters()
            Dim dsromaneio As DataSet

            If chk_cooperativa_nota.Checked = True Then
                dsromaneio = romaneio.getRomaneiosComplementarCooperativa

            Else
                dsromaneio = romaneio.getRomaneiosComplementarByFilters()
            End If
            'Fran 30/09/2008 f
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

            customPage.setFilter("romaneio_compl_dados", txt_id_romaneio.ID, ViewState.Item("i_romaneio").ToString)
            customPage.setFilter("romaneio_compl_dados", txt_cd_transportador.ID, ViewState.Item("cd_cnh").ToString)
            customPage.setFilter("romaneio_compl_dados", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            customPage.setFilter("romaneio_compl_dados", "PageIndex", gridResults.PageIndex.ToString())
            'Fran 29/12/2008 i
            customPage.setFilter("romaneio_compl_dados", txt_nm_linha.ID, ViewState.Item("nm_linha").ToString)
            customPage.setFilter("romaneio_compl_dados", txt_dt_transmissao_ini.ID, ViewState.Item("dt_transmissao_ini").ToString)
            customPage.setFilter("romaneio_compl_dados", txt_dt_transmissao_fim.ID, ViewState.Item("dt_transmissao_fim").ToString)
            'fran 29/12/2008 f

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

                If chk_cooperativa_nota.Checked = True Then
                    Response.Redirect("frm_romaneio_cooperativa_abertura.aspx?id_romaneio_cooperativa=" + e.CommandArgument.ToString + "&nm_tela=complementar_dados")

                Else
                    Response.Redirect("frm_romaneio.aspx?id_romaneio=" + e.CommandArgument.ToString + "&nm_tela=complementar_dados")

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


End Class
