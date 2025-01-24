Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_coleta_amostra_manual
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
        ViewState.Item("dt_referencia") = DateTime.Parse("01/" & txt_dt_referencia.Text).ToString("dd/MM/yyyy")

        ViewState.Item("id_tipo_coleta") = cbo_tipo_coleta.SelectedValue

        If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
            ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        Else
            ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        End If

        If Not (Me.txt_id_propriedade.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_propriedade") = Me.txt_id_propriedade.Text.Trim()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If
        If Not (Me.txt_id_propriedade_matriz.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_propriedade_matriz") = Me.txt_id_propriedade_matriz.Text.Trim()
        Else
            ViewState.Item("id_propriedade_matriz") = String.Empty
        End If

        If txt_dia_ini.Text.Equals(String.Empty) Then
            ViewState.Item("dt_ini") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        Else
            ViewState.Item("dt_ini") = String.Concat(Right("00" & txt_dia_ini.Text.Trim, 2), Right(ViewState.Item("dt_referencia").ToString, 8))
            ViewState.Item("dt_fim") = String.Concat(Right("00" & txt_dia_fim.Text.Trim, 2), Right(ViewState.Item("dt_referencia").ToString, 8))
        End If

        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_coleta_amostra_manual.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_coleta_amostra_manual.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 200
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If

        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Produtores"
            '.Style("cursor") = "hand"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim analiseesalqtipocoleta As New AnaliseEsalqTipoColeta
            Dim status As New SituacaoColetaAmostraManual
            Dim estabelecimento As New Estabelecimento

            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao.DataSource = status.getSituacoesColetaAmostraManualByFilters()
            cbo_situacao.DataTextField = "nm_situacao_coleta_amostra_manual"
            cbo_situacao.DataValueField = "id_situacao_coleta_amostra_manual"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_tipo_coleta.DataSource = AnaliseEsalqTipoColeta.getAnaliseEsalqTipoColetaByFilters()
            cbo_tipo_coleta.DataTextField = "nm_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataValueField = "id_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataBind()
            cbo_tipo_coleta.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = ""

            loadFilters()
            'fran 11/2021 - simula seleção de usuario
            If cbo_estabelecimento.SelectedValue.Equals("0") Then
                'simula seleção do usuario em poços
                cbo_estabelecimento.SelectedValue = 1 'força poços de caldas
            End If
            If txt_dt_referencia.Text.Equals(String.Empty) Then
                txt_dt_referencia.Text = DateTime.Parse(Now).ToString("MM/yyyy")
                ViewState.Item("dt_referencia") = "01/" + Me.txt_dt_referencia.Text.Trim
            End If
            'fran 11/2021 - simula seleção de usuario

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("colamomanual", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            If Not (customPage.getFilterValue("colamomanual", cbo_estabelecimento.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_estabelecimento") = customPage.getFilterValue("colamomanual", cbo_estabelecimento.ID)
                cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
            Else
                ViewState.Item("id_estabelecimento") = 0
            End If
        Else
            ViewState.Item("id_estabelecimento") = 0
        End If

        If Not (customPage.getFilterValue("colamomanual", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("colamomanual", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamomanual", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("colamomanual", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamomanual", txt_id_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("colamomanual", txt_id_propriedade.ID)
            txt_id_propriedade.Text = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamomanual", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("colamomanual", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("colamomanual", txt_id_propriedade_matriz.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade_matriz") = customPage.getFilterValue("colamomanual", txt_id_propriedade_matriz.ID)
            txt_id_propriedade_matriz.Text = ViewState.Item("id_propriedade_matriz").ToString()
        Else
            ViewState.Item("id_propriedade_matriz") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamomanual", cbo_situacao.ID).Equals(String.Empty)) Then
            If Not (customPage.getFilterValue("colamomanual", cbo_situacao.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_situacao") = customPage.getFilterValue("colamomanual", cbo_situacao.ID)
                cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
            Else
                ViewState.Item("id_situacao") = "0"
            End If
        Else
            ViewState.Item("id_situacao") = "0"

        End If


        If Not (customPage.getFilterValue("colamomanual", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("colamomanual", txt_dt_referencia.ID)
            txt_dt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("MM/yyyy")
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If
        If Not (customPage.getFilterValue("colamomanual", txt_dia_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_ini") = customPage.getFilterValue("colamomanual", txt_dia_ini.ID)
            txt_dia_ini.Text = DateTime.Parse(ViewState.Item("dt_ini").ToString).ToString("dd")
        Else
            ViewState.Item("dt_ini") = String.Empty
        End If
        If Not (customPage.getFilterValue("colamomanual", txt_dia_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_fim") = customPage.getFilterValue("colamomanual", txt_dia_fim.ID)
            txt_dia_fim.Text = DateTime.Parse(ViewState.Item("dt_fim").ToString).ToString("dd")
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamomanual", cbo_tipo_coleta.ID).Equals(String.Empty)) Then
            If Not (customPage.getFilterValue("colamomanual", cbo_tipo_coleta.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_tipo_coleta") = customPage.getFilterValue("colamomanual", cbo_tipo_coleta.ID)
                cbo_tipo_coleta.Text = ViewState.Item("id_tipo_coleta").ToString()
            Else
                ViewState.Item("id_tipo_coleta") = "0"
            End If
        Else
            ViewState.Item("id_tipo_coleta") = "0"

        End If

 

        If Not (customPage.getFilterValue("colamomanual", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("colamomanual", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("colamomanual")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim coletamanual As New ColetaAmostraManual

            If Not (ViewState.Item("id_propriedade_matriz").Equals(String.Empty)) Then
                coletamanual.id_propriedade_matriz = Convert.ToInt32(ViewState.Item("id_propriedade_matriz").ToString)
            Else
                coletamanual.id_propriedade_matriz = 0
            End If
            If Not (ViewState.Item("id_propriedade").Equals(String.Empty)) Then
                coletamanual.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            Else
                coletamanual.id_propriedade = 0
            End If
            If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                coletamanual.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            Else
                coletamanual.id_pessoa = 0
            End If

            coletamanual.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            coletamanual.id_situacao_coleta_amostra_manual = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            coletamanual.dt_referencia = (ViewState.Item("dt_referencia").ToString)
            coletamanual.dt_ini_amostra = (ViewState.Item("dt_ini").ToString)
            coletamanual.dt_fim_amostra = (ViewState.Item("dt_fim").ToString)
            coletamanual.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta").ToString())

            Dim dscoletamanual As DataSet = coletamanual.getColetaAmostraManual()

            If (dscoletamanual.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscoletamanual.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                If ViewState.Item("colamomanualriedadesatualizar") = True Then
                    gridResults.Columns.Item(8).Visible = True 'não deixa editar
                Else
                    gridResults.Columns.Item(8).Visible = False 'não deixa editar
                End If
                If ViewState.Item("id_situacao").ToString = "2" Then 'inativo
                    gridResults.Columns.Item(8).Visible = False 'não deixa editar
                Else
                    gridResults.Columns.Item(8).Visible = True ' deixa editar
                End If

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


            Case "cd_pessoa"
                If (ViewState.Item("sortExpression")) = "cd_pessoa asc" Then
                    ViewState.Item("sortExpression") = "cd_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "cd_pessoa asc"
                End If

            Case "nm_abreviado"
                If (ViewState.Item("sortExpression")) = "nm_abreviado asc" Then
                    ViewState.Item("sortExpression") = "nm_abreviado desc"
                Else
                    ViewState.Item("sortExpression") = "nm_abreviado asc"
                End If

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If
            Case "id_propriedade_matriz"
                If (ViewState.Item("sortExpression")) = "id_propriedade_matriz asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade_matriz desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade_matriz asc"
                End If

            Case "nm_tipo_coleta_analise_esalq"
                If (ViewState.Item("sortExpression")) = "nm_tipo_coleta_analise_esalq asc" Then
                    ViewState.Item("sortExpression") = "nm_tipo_coleta_analise_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tipo_coleta_analise_esalq asc"
                End If

            Case "nm_situacao_coleta_amostra_manual"
                If (ViewState.Item("sortExpression")) = "nm_situacao_coleta_amostra_manual asc" Then
                    ViewState.Item("sortExpression") = "nm_situacao_coleta_amostra_manual desc"
                Else
                    ViewState.Item("sortExpression") = "nm_situacao_coleta_amostra_manual asc"
                End If


        End Select

        loadData()

    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("colamomanual", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("colamomanual", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("colamomanual", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("colamomanual", txt_id_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("colamomanual", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("colamomanual", txt_id_propriedade_matriz.ID, ViewState.Item("id_propriedade_matriz").ToString)
            customPage.setFilter("colamomanual", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("colamomanual", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("colamomanual", txt_dia_ini.ID, ViewState.Item("dt_ini").ToString)
            customPage.setFilter("colamomanual", txt_dia_fim.ID, ViewState.Item("dt_fim").ToString)
            customPage.setFilter("colamomanual", cbo_tipo_coleta.ID, ViewState.Item("id_tipo_coleta").ToString)

            customPage.setFilter("colamomanual", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    'Private Sub salvarParametrosLupa()

    '    Try
    '        customPage.clearFilters("lupa_estabel")
    '        customPage.setFilter("lupa_estabel", "id_estabelecimento.lupa", cbo_estabelecimento.SelectedValue)

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub
    'Private Sub adicionarAtributoLupa()

    '    Try
    '        With bt_lupa_produtor
    '            .Attributes.Add("onclick", "javascript:ShowDialog()")
    '            .ToolTip = "Filtrar Produtores"
    '        End With

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub


    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_coleta_amostra_manual.aspx?id_coleta_amostra_manual=" + e.CommandArgument.ToString())

            Case "delete"
                cancelarAmostraManual(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub cancelarAmostraManual(ByVal id_coleta_amostra_manual As Integer)

        Try
            Dim amostramanual As New ColetaAmostraManual()
            amostramanual.id_coleta_amostra_manual = id_coleta_amostra_manual
            amostramanual.id_modificador = Convert.ToInt32(Session("id_login"))
            amostramanual.updateColetaAmostraManualCancelar()

            ''FRAN 08/12/2020 i incluir log 
            'Dim usuariolog As New UsuarioLog
            'usuariolog.id_usuario = Session("id_login")
            'usuariolog.ds_id_session = Session.SessionID.ToString()
            'usuariolog.id_tipo_log = 5 'delecao
            'usuariolog.id_menu_item = 200
            'usuariolog.id_nr_processo = id_grupo_propriedades
            'usuariolog.insertUsuarioLog()
            ''FRAN 08/12/2020  incluir log 
            messageControl.Alert("Registro cancelado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_coleta_amostra_manual.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
                Dim lbl_id_situacao_coleta_amostra_manual As Label = CType(e.Row.FindControl("lbl_id_situacao_coleta_amostra_manual"), Label)
                Dim lbl_dt_ini_amostra As Label = CType(e.Row.FindControl("lbl_dt_ini_amostra"), Label)

                btn_delete.Visible = True

                e.Row.Cells(0).Text = DateTime.Parse(e.Row.Cells(0).Text).ToString("MM/yyyy")

                btn_delete.Enabled = True
                btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                btn_delete.ToolTip = String.Empty

                'se data de hoje for maior ou igual referencia nao atualiza, nao pode salvar
                If CDate(DateTime.Now.ToString("dd/MM/yyyy")) >= CDate(DateAdd(DateInterval.Month, 1, ViewState.Item("dt_referencia"))) Then
                    btn_delete.Enabled = False
                    btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                    btn_delete.ToolTip = "Não é possível cancelar a amostra porque a Referência já foi finalizada."
                Else 'se a referencia da tela for menor que hj
                    If lbl_id_situacao_coleta_amostra_manual.Text.Equals("1") Then 'se situacao coleta manual é pendente
                        'verifica se o inicio da coleta é maior que a data de hoje
                        If CDate(lbl_dt_ini_amostra.Text) <= CDate(DateTime.Now.ToString("dd/MM/yyyy")) Then
                            btn_delete.Enabled = False
                            btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                            btn_delete.ToolTip = "Não é possível cancelar a amostra porque o periodo para coleta da Amostra já foi iniciado."
                        End If
                    Else 'se siyuacao coleta diferente de pendente nao deixa atualizar mais
                        btn_delete.Enabled = False
                        btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                        btn_delete.ToolTip = "Não é possível cancelar a amostra porque a situação da solicitação é diferente de 'Pendente'."
                    End If
                End If

                'se a coleta manual esta realizada, mostra a rota
                If lbl_id_situacao_coleta_amostra_manual.Text.Equals("2") Then
                    Dim coletaamostra As New ColetaAmostra
                    coletaamostra.id_coleta_amostra_manual = gridResults.DataKeys.Item(e.Row.RowIndex).Value

                    Dim dscoleta As DataSet = coletaamostra.getColetaAmostraDadosbyColetaManual
                    If (dscoleta.Tables(0).Rows.Count > 0) Then
                        e.Row.Cells(8).Text = dscoleta.Tables(0).Rows(0).Item("nm_linha").ToString 'Rota
                        e.Row.Cells(9).Text = dscoleta.Tables(0).Rows(0).Item("nr_caderneta").ToString 'caderneta
                    End If
                End If
            End If


        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        Me.lbl_nm_pessoa.Text = ""
        Me.txt_cd_pessoa.Text = ""
        Me.hf_id_pessoa.Value = ""
        Me.lbl_nm_pessoa.Visible = False
    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
        End If
    End Sub


    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        lbl_nm_pessoa.Visible = False
        hf_id_pessoa.Value = String.Empty

    End Sub

 
End Class
