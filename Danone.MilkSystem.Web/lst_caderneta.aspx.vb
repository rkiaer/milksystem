Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_caderneta
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        Dim lberro As Boolean = False
        ViewState.Item("nr_caderneta") = txt_nr_caderneta.Text.Trim()
        ViewState.Item("ds_placa") = txt_placa.Text.Trim()
        ViewState.Item("cd_cnh") = txt_cd_transportador.Text.Trim.ToString
        'Fran 29/12/2008 i
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
        ViewState.Item("dt_ini_transmissao") = txt_dt_transmissao_ini.Text.Trim.ToString
        ViewState.Item("dt_fim_transmissao") = txt_dt_transmissao_fim.Text.Trim.ToString
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

        Response.Redirect("lst_caderneta.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_caderneta.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 16
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
        'With btn_lupa_transportador
        '    .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
        '    .ToolTip = "Filtrar Transportadores"
        'End With

    End Sub


    Private Sub loadDetails()

        Try


            ViewState.Item("sortExpression") = "id_protocolo asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("caderneta", txt_nr_caderneta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_caderneta") = customPage.getFilterValue("caderneta", txt_nr_caderneta.ID)
            txt_nr_caderneta.Text = ViewState.Item("nr_caderneta").ToString()
        Else
            ViewState.Item("nr_caderneta") = String.Empty
        End If
        'Fran 29/12/2008 i
        If Not (customPage.getFilterValue("caderneta", txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_linha") = customPage.getFilterValue("caderneta", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_linha").ToString()
        Else
            ViewState.Item("nm_linha") = String.Empty
        End If
        If Not (customPage.getFilterValue("caderneta", txt_dt_transmissao_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_ini_transmissao") = customPage.getFilterValue("caderneta", txt_dt_transmissao_ini.ID)
            txt_dt_transmissao_ini.Text = ViewState.Item("dt_ini_transmissao").ToString()
        Else
            ViewState.Item("dt_ini_transmissao") = String.Empty
        End If
        If Not (customPage.getFilterValue("caderneta", txt_dt_transmissao_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_fim_transmissao") = customPage.getFilterValue("caderneta", txt_dt_transmissao_fim.ID)
            txt_dt_transmissao_fim.Text = ViewState.Item("dt_fim_transmissao").ToString()
        Else
            ViewState.Item("dt_fim_transmissao") = String.Empty
        End If
        'fran 20/12/2008 f
        If Not (customPage.getFilterValue("caderneta", txt_cd_transportador.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_cnh") = customPage.getFilterValue("caderneta", txt_cd_transportador.ID)
            txt_cd_transportador.Text = ViewState.Item("cd_cnh").ToString()
        Else
            ViewState.Item("cd_cnh") = String.Empty
        End If


        If Not (customPage.getFilterValue("caderneta", txt_placa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("caderneta", txt_placa.ID)
            txt_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If

        If Not (customPage.getFilterValue("caderneta", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("caderneta", "PageIndex").ToString()
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
            caderneta.cd_cnh = ViewState.Item("cd_cnh").ToString()
            caderneta.ds_placa = ViewState.Item("ds_placa").ToString()
            'Fran 29/12/2008 i
            caderneta.nm_linha = ViewState.Item("nm_linha").ToString

            ' Adri 15/01/2009 - i
            'caderneta.dt_transmissao_ini = ViewState.Item("dt_ini_transmissao").ToString
            'caderneta.dt_transmissao_fim = ViewState.Item("dt_fim_transmissao").ToString
            If Not (ViewState.Item("dt_ini_transmissao").ToString.Equals(String.Empty)) Then
                caderneta.dt_transmissao_ini = ViewState.Item("dt_ini_transmissao").ToString
            End If
            If Not (ViewState.Item("dt_fim_transmissao").ToString.Equals(String.Empty)) Then
                caderneta.dt_transmissao_fim = ViewState.Item("dt_fim_transmissao").ToString
            End If
            ' Adri 15/01/2009 - f

            'caderneta.st_leite_desviado = "N"
            'Fran 29/12/2008 f
            Dim dsCadernetaHeader As DataSet = caderneta.getCadernetaHeaderByFilters()

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


            Case "ds_motorista"
                If (ViewState.Item("sortExpression")) = "ds_motorista asc" Then
                    ViewState.Item("sortExpression") = "ds_motorista desc"
                Else
                    ViewState.Item("sortExpression") = "ds_motorista asc"
                End If
            Case "ds_placa"
                If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
                End If
            Case "nm_linha"
                If (ViewState.Item("sortExpression")) = "nm_linha asc" Then
                    ViewState.Item("sortExpression") = "nm_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nm_linha asc"
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

            customPage.setFilter("caderneta", txt_nr_caderneta.ID, ViewState.Item("nr_caderneta").ToString)
            customPage.setFilter("caderneta", txt_cd_transportador.ID, ViewState.Item("cd_cnh").ToString)
            customPage.setFilter("caderneta", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            customPage.setFilter("caderneta", "PageIndex", gridResults.PageIndex.ToString())
            'Fran 29/12/2008 i
            customPage.setFilter("caderneta", txt_nm_linha.ID, ViewState.Item("nm_linha").ToString)
            customPage.setFilter("caderneta", txt_dt_transmissao_ini.ID, ViewState.Item("dt_ini_transmissao").ToString)
            customPage.setFilter("caderneta", txt_dt_transmissao_fim.ID, ViewState.Item("dt_fim_transmissao").ToString)
            'fran 29/12/2008 f
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "selecionar"
                saveFilters()
                Response.Redirect("frm_caderneta.aspx?nr_caderneta=" + e.CommandArgument.ToString())
            Case "delete"
                deleteCaderneta(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteCaderneta(ByVal id_protocolo As Integer)

        Try

            Dim caderneta As New Caderneta()
            caderneta.id_protocolo = id_protocolo
            caderneta.id_modificador = Convert.ToInt32(Session("id_login"))
            caderneta.deleteCaderneta()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 16
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro excluído com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

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

    'Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
    '    'If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
    '    '    'A´pós retornar da modal, carrega os campos
    '    '    carregarCamposTransportador()
    '    'Else
    '    '    txt_cd_transportador.Text = String.Empty
    '    '    hf_id_pessoa.Value = String.Empty
    '    '    lbl_nm_transportador.Text = String.Empty
    '    '    lbl_nm_transportador.Visible = False
    '    'End If


    'End Sub

    'Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
    '    lbl_nm_transportador.Text = String.Empty
    '    lbl_nm_transportador.Visible = False
    '    hf_id_pessoa.Value = String.Empty

    'End Sub

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
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try

                Dim lbl_id_romaneio As Label = CType(e.Row.FindControl("lbl_id_romaneio"), Label)
                Dim img_delete As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)


                'Se tem romaneio não pode excluir caderneta
                If lbl_id_romaneio.Text.Trim > 0 Then
                    img_delete.Enabled = False
                    img_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                    img_delete.ToolTip = "O romaneio para esta caderneta já foi aberto. A exclusão não é permitida!"
                Else
                    img_delete.Enabled = True
                    img_delete.ImageUrl = "~/img/icone_excluir.gif"
                    img_delete.ToolTip = "Excluir Caderneta"
                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If


    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub txt_dt_transmissao_ini_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dt_transmissao_ini.TextChanged
        If Not txt_dt_transmissao_ini.Text.Trim.Equals(String.Empty) Then
            If txt_dt_transmissao_fim.Text.Trim.Equals(String.Empty) Then
                txt_dt_transmissao_fim.Text = txt_dt_transmissao_ini.Text
            End If
        End If
    End Sub
End Class
