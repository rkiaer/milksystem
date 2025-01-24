Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_grupo_relacionamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()

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
        If Not (Me.txt_id_propriedade_titular.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_propriedade_titular") = Me.txt_id_propriedade_titular.Text.Trim()
        Else
            ViewState.Item("id_propriedade_titular") = String.Empty
        End If

        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_grupo_relacionamento.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_grupo_relacionamento.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 179
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

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()


            ViewState.Item("sortExpression") = "nm_pessoa_titular, st_relacionamento desc,nm_pessoa,id_propriedade"

            'frn 06/2018 i DANGO 2018
            'BUSCA SE O USURIO TEM ACESSO AO PROCESSO GRUPO DE RELACIONAMENTO ALTERACAO
            Dim usuarioprocesso As New GrupoAcessoProcesso
            usuarioprocesso.id_menu_item_processo = 2 'Proceurar o processo 2 - GRUPO RELACIONAMENTO ATUALIZAÇÃO
            usuarioprocesso.id_usuario = Session("id_login") 'usuario de acesso
            Dim dsusuarioprocesso As DataSet = usuarioprocesso.getGrupoAcessoProcessoByFilters
            'SE TEM DIREIRO A ACESSAR GRUPO RELACIONAMENTO ATUALIZAÇÃO
            If dsusuarioprocesso.Tables(0).Rows.Count > 0 Then
                ViewState.Item("gruporelacionamentoatualizar") = True
                lk_novo.Visible = True
                img_novo.Visible = True
            Else 'SE NAO TEM ACESSO
                ViewState.Item("gruporelacionamentoatualizar") = False
                lk_novo.Visible = False
                img_novo.Visible = False
            End If
            'frn 06/2018 f DANGO 2018

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("gruporel", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("gruporel", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("gruporel", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("gruporel", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("gruporel", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("gruporel", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("gruporel", txt_id_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("gruporel", txt_id_propriedade.ID)
            txt_id_propriedade.Text = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("gruporel", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("gruporel", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("gruporel", txt_id_propriedade_titular.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade_titular") = customPage.getFilterValue("propriedade", txt_id_propriedade_titular.ID)
            txt_id_propriedade_titular.Text = ViewState.Item("id_propriedade_titular").ToString()
        Else
            ViewState.Item("id_propriedade_titular") = String.Empty
        End If

        If Not (customPage.getFilterValue("gruporel", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("gruporel", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("gruporel", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("gruporel", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("gruporel")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim grupo As New GrupoRelacionamento

            If Not (ViewState.Item("id_propriedade_titular").Equals(String.Empty)) Then
                grupo.id_propriedade_titular = Convert.ToInt32(ViewState.Item("id_propriedade_titular").ToString)
            Else
                grupo.id_propriedade_titular = 0
            End If
            If Not (ViewState.Item("id_propriedade").Equals(String.Empty)) Then
                grupo.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            Else
                grupo.id_propriedade = 0
            End If
            If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                grupo.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            Else
                grupo.id_pessoa = 0
            End If

            grupo.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            grupo.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

            Dim dsgrupo As DataSet = grupo.getGrupoRelacionamento()

            If (dsgrupo.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsgrupo.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                If ViewState.Item("gruporelacionamentoatualizar") = True Then
                    gridResults.Columns.Item(10).Visible = True 'não deixa editar
                Else
                    gridResults.Columns.Item(10).Visible = False 'não deixa editar
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

            Case "nm_pessoa"
                If (ViewState.Item("sortExpression")) = "nm_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_pessoa asc"
                End If

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If
            Case "id_propriedade_titular"
                If (ViewState.Item("sortExpression")) = "id_propriedade_titular asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade_titular desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade_titular asc"
                End If

            Case "cd_pessoa_titular"
                If (ViewState.Item("sortExpression")) = "cd_pessoa_titular asc" Then
                    ViewState.Item("sortExpression") = "cd_pessoa_titular desc"
                Else
                    ViewState.Item("sortExpression") = "cd_pessoa_titular asc"
                End If

            Case "nm_pessoa_titular"  ' 02/2012 Projeto Themis
                If (ViewState.Item("sortExpression")) = "nm_pessoa_titular asc" Then
                    ViewState.Item("sortExpression") = "nm_pessoa_titular desc"
                Else
                    ViewState.Item("sortExpression") = "nm_pessoa_titular asc"
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


            customPage.setFilter("gruporel", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("gruporel", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("gruporel", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("gruporel", txt_id_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("gruporel", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("gruporel", txt_id_propriedade_titular.ID, ViewState.Item("id_propriedade_titular").ToString)
            customPage.setFilter("gruporel", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("gruporel", "PageIndex", gridResults.PageIndex.ToString())

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
                Response.Redirect("frm_grupo_relacionamento.aspx?id_propriedade_titular=" + e.CommandArgument.ToString())

            Case "delete"
                deletePropriedade(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deletePropriedade(ByVal id_grupo_relacionamento As Integer)

        Try
            Dim grupo As New GrupoRelacionamento()
            grupo.id_grupo_relacionamento = id_grupo_relacionamento
            grupo.id_modificador = Convert.ToInt32(Session("id_login"))
            grupo.deleteGrupoRelacionamento()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 179
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_grupo_relacionamento.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then


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

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
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
        If Not (Me.txt_id_propriedade_titular.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_propriedade_titular") = Me.txt_id_propriedade_titular.Text.Trim()
        Else
            ViewState.Item("id_propriedade_titular") = String.Empty
        End If

        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

        loadData()

        customPage.clearFilters("gruporel")
        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 179
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        saveFilters()
        Response.Redirect("frm_grupo_relacionamento_excel.aspx?id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&id_propriedade_titular=" + ViewState.Item("id_propriedade_titular").ToString() + "&id_situacao=" + ViewState.Item("id_situacao").ToString())

    End Sub
End Class
