Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class lst_central_contrato
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio_contrato") = String.Concat("01/", DateTime.Parse(txt_dt_referencia.Text).ToString("MM/yyyy"))
        Else
            ViewState.Item("dt_inicio_contrato") = String.Empty
        End If
        ViewState.Item("id_central_contrato") = txt_id_contrato.Text
        ViewState.Item("nm_fornecedor") = txt_nm_fornecedor.Text
        ViewState.Item("nm_item") = txt_nm_item.Text
        ViewState.Item("id_situacao_contrato") = cbo_situacao_contrato.SelectedValue
        ViewState.Item("st_tipo_central_contrato") = cbo_tipo_contrato.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_contrato.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_contrato.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 236
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim statusContrato As New SituacaoContrato
            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = String.Empty

            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()


    '    Dim hasFilters As Boolean

    '    If Not (customPage.getFilterValue("contrato", cbo_estabelecimento.ID).Equals(String.Empty)) AndAlso Not (customPage.getFilterValue("contrato", cbo_estabelecimento.ID).Equals("0")) Then
    '        hasFilters = True
    '        ViewState.Item("id_estabelecimento") = customPage.getFilterValue("contrato", cbo_estabelecimento.ID)
    '        cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
    '    Else
    '        ViewState.Item("id_estabelecimento") = 0
    '    End If

    '    If Not (customPage.getFilterValue("contrato", txt_dt_referencia.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("dt_referencia") = customPage.getFilterValue("contrato", txt_dt_referencia.ID)
    '        txt_dt_referencia.Text = ViewState.Item("dt_referencia").ToString()
    '    Else
    '        ViewState.Item("dt_referencia") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("contrato", txt_cd_contrato.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("cd_contrato") = customPage.getFilterValue("contrato", txt_cd_contrato.ID)
    '        txt_cd_contrato.Text = ViewState.Item("cd_contrato").ToString()
    '    Else
    '        ViewState.Item("cd_contrato") = String.Empty
    '    End If
    '    If Not (customPage.getFilterValue("contrato", txt_nm_contrato.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("nm_contrato") = customPage.getFilterValue("contrato", txt_nm_contrato.ID)
    '        txt_nm_contrato.Text = ViewState.Item("nm_contrato").ToString()
    '    Else
    '        ViewState.Item("nm_contrato") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("contrato", cbo_situacao_contrato.ID).Equals(String.Empty)) AndAlso Not (customPage.getFilterValue("contrato", cbo_situacao_contrato.ID).Equals("0")) Then
    '        hasFilters = True
    '        ViewState.Item("id_situacao_contrato") = customPage.getFilterValue("contrato", cbo_situacao_contrato.ID)
    '        cbo_situacao_contrato.SelectedValue = ViewState.Item("id_situacao_contrato").ToString()
    '    Else
    '        ViewState.Item("id_situacao_contrato") = "0"
    '    End If

    '    If Not (customPage.getFilterValue("contrato", cbo_cluster.ID).Equals(String.Empty)) Then
    '        If Not (customPage.getFilterValue("contrato", cbo_cluster.ID).Equals("0")) Then
    '            ViewState.Item("id_cluster") = customPage.getFilterValue("contrato", cbo_cluster.ID)
    '            cbo_cluster.SelectedValue = ViewState.Item("id_cluster").ToString()
    '        Else
    '            ViewState.Item("id_cluster") = "0"
    '            cbo_cluster.SelectedValue = "0"
    '        End If
    '    Else
    '        ViewState.Item("id_cluster") = "0"
    '        cbo_cluster.SelectedValue = "0"
    '    End If


    '    If Not (customPage.getFilterValue("contrato", cbo_estabelecimento.ID).Equals(String.Empty)) Then
    '        If Not (customPage.getFilterValue("contrato", cbo_tipo_contrato.ID).Equals("0")) Or Not (customPage.getFilterValue("contrato", cbo_tipo_contrato.ID).Equals("")) Then
    '            ViewState.Item("id_situacao") = customPage.getFilterValue("contrato", cbo_tipo_contrato.ID)
    '            cbo_tipo_contrato.SelectedValue = ViewState.Item("id_situacao").ToString()
    '        Else
    '            ViewState.Item("id_situacao") = String.Empty
    '        End If
    '    Else
    '        ViewState.Item("id_situacao") = 1
    '    End If
    '    If (customPage.getFilterValue("contrato", chk_contrato_comercial.ID) = "S") Then
    '        hasFilters = True
    '        ViewState.Item("st_contrato_comercial") = "S"
    '        chk_contrato_comercial.Checked = True
    '    Else
    '        ViewState.Item("st_contrato_comercial") = String.Empty
    '        chk_contrato_comercial.Checked = False
    '    End If
    '    If (customPage.getFilterValue("contrato", chk_contrato_mercado.ID) = "S") Then
    '        hasFilters = True
    '        ViewState.Item("st_contrato_mercado") = "S"
    '        chk_contrato_mercado.Checked = True
    '    Else
    '        ViewState.Item("st_contrato_mercado") = String.Empty
    '        chk_contrato_mercado.Checked = False
    '    End If
    '    If (customPage.getFilterValue("contrato", chk_referenciavigente.ID) = "S") Then
    '        hasFilters = True
    '        ViewState.Item("st_referencia_vigente") = "S"
    '        chk_referenciavigente.Checked = True
    '    Else
    '        ViewState.Item("st_referencia_vigente") = String.Empty
    '        chk_referenciavigente.Checked = False
    '    End If

    '    If Not (customPage.getFilterValue("contrato", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("contrato", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("contrato")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim contrato As New CentralContrato

            contrato.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

            If Not (ViewState("dt_inicio_contrato").ToString().Equals(String.Empty)) Then
                contrato.dt_inicio_contrato = DateTime.Parse(ViewState("dt_inicio_contrato").ToString).ToString("dd/MM/yyyy")
            End If
            If Not txt_id_contrato.Text.Equals(String.Empty) Then
                contrato.id_central_contrato = txt_id_contrato.Text

            End If
            contrato.nm_fornecedor = txt_nm_fornecedor.Text
            contrato.nm_item = txt_nm_item.Text
            contrato.id_situacao_central_contrato = cbo_situacao_contrato.SelectedValue
            contrato.st_tipo_central_contrato = cbo_tipo_contrato.SelectedValue

            Dim dscontrato As DataSet = contrato.getCentralContratoByFilters()

            If (dscontrato.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscontrato.Tables(0), ViewState.Item("sortExpression"))
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


            Case "ds_descricao_contrato"
                If ViewState.Item("sortExpression") = "ds_descricao_contrato asc" Then
                    ViewState.Item("sortExpression") = "ds_descricao_contrato desc"
                Else
                    ViewState.Item("sortExpression") = "ds_descricao_contrato asc"
                End If

            Case "id_central_contrato"
                If ViewState.Item("sortExpression") = "id_central_contrato asc" Then
                    ViewState.Item("sortExpression") = "id_central_contrato desc"
                Else
                    ViewState.Item("sortExpression") = "id_central_contrato asc"
                End If

            Case "nm_abreviado_fornecedor"
                If ViewState.Item("sortExpression") = "nm_abreviado_fornecedor asc" Then
                    ViewState.Item("sortExpression") = "nm_abreviado_fornecedor desc"
                Else
                    ViewState.Item("sortExpression") = "nm_abreviado_fornecedor asc"
                End If
            Case "nm_item"
                If ViewState.Item("sortExpression") = "nm_item asc" Then
                    ViewState.Item("sortExpression") = "nm_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_item asc"
                End If
            Case "dt_inicio_contrato"
                If ViewState.Item("sortExpression") = "dt_inicio_contrato asc" Then
                    ViewState.Item("sortExpression") = "dt_inicio_contrato desc"
                Else
                    ViewState.Item("sortExpression") = "dt_inicio_contrato asc"
                End If
            Case "id_situacao_central_contrato"
                If ViewState.Item("sortExpression") = "id_situacao_central_contrato asc" Then
                    ViewState.Item("sortExpression") = "id_situacao_central_contrato desc"
                Else
                    ViewState.Item("sortExpression") = "id_situacao_central_contrato asc"
                End If
            Case "ds_tipo_central_contrato"
                If ViewState.Item("sortExpression") = "st_tipo_central_contrato asc" Then
                    ViewState.Item("sortExpression") = "st_tipo_central_contrato desc"
                Else
                    ViewState.Item("sortExpression") = "st_tipo_central_contrato asc"
                End If

        End Select

        loadData()

    End Sub

    'Private Sub saveFilters()

    '    Try

    '        customPage.setFilter("contrato", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
    '        customPage.setFilter("contrato", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
    '        customPage.setFilter("contrato", txt_cd_contrato.ID, ViewState.Item("cd_contrato").ToString)
    '        customPage.setFilter("contrato", txt_nm_contrato.ID, ViewState.Item("nm_contrato").ToString)
    '        customPage.setFilter("contrato", cbo_situacao_contrato.ID, ViewState.Item("id_situacao_contrato").ToString)
    '        customPage.setFilter("contrato", cbo_tipo_contrato.ID, ViewState.Item("id_situacao").ToString)
    '        customPage.setFilter("contrato", cbo_cluster.ID, ViewState.Item("id_cluster").ToString)
    '        customPage.setFilter("contrato", chk_contrato_comercial.ID, ViewState.Item("st_contrato_comercial").ToString)
    '        customPage.setFilter("contrato", chk_contrato_mercado.ID, ViewState.Item("st_contrato_mercado").ToString)
    '        customPage.setFilter("contrato", chk_referenciavigente.ID, ViewState.Item("st_referencia_vigente").ToString)
    '        customPage.setFilter("contrato", "PageIndex", gridResults.PageIndex.ToString())

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                Dim lbl_id_contrato As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_contrato"), Label)
                Dim lbl_st_tipo_central_contrato As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_st_tipo_central_contrato"), Label)
                'saveFilters()
                If lbl_st_tipo_central_contrato.Text = "C" Then
                    Response.Redirect("frm_central_pedido_abertura_contrato.aspx?id_central_contrato=" & lbl_id_contrato.Text)
                Else
                    Response.Redirect("frm_central_pedido_abertura_grupo.aspx?id_central_contrato=" & lbl_id_contrato.Text)
                End If

                'Case "delete"

                '    Dim lbl_id_contrato As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_contrato"), Label)
                '    Dim lbl_id_contrato_validade As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_contrato_validade"), Label)

                '    deleteContrato(Convert.ToInt32(lbl_id_contrato.Text), Convert.ToInt32(lbl_id_contrato_validade.Text))

        End Select

    End Sub

    'Private Sub deleteContrato(ByVal id_contrato As Integer, ByVal id_contrato_validade As Integer)

    '    Try
    '        Dim lmsg As String
    '        Dim contratovalidade As New ContratoValidade()
    '        contratovalidade.id_contrato_validade = id_contrato_validade
    '        contratovalidade.id_modificador = Convert.ToInt32(Session("id_login"))
    '        contratovalidade.deleteContratoValidade()

    '        'FRAN 08/12/2020 i incluir log 
    '        Dim usuariolog As New UsuarioLog
    '        usuariolog.id_usuario = Session("id_login")
    '        usuariolog.ds_id_session = Session.SessionID.ToString()
    '        usuariolog.id_tipo_log = 5 'delecao
    '        usuariolog.id_menu_item = 178
    '        usuariolog.insertUsuarioLog()
    '        'FRAN 08/12/2020  incluir log 

    '        lmsg = "Registro de validade do Contrato foi desativado com sucesso!"

    '        'busca todos os contratos validade ativos existentes para o contrato. Se não retornou nenhuma linha desativada contrato também
    '        contratovalidade.id_contrato_validade = 0
    '        contratovalidade.id_contrato = id_contrato
    '        contratovalidade.id_situacao = 1 'ativo
    '        If contratovalidade.getContratoValidadeByFilters.Tables(0).Rows.Count = 0 Then
    '            Dim contrato As New Contrato
    '            contrato.id_contrato = id_contrato
    '            contrato.id_modificador = Convert.ToInt32(Session("id_login"))
    '            contrato.deleteContrato()
    '            lmsg = "Todas as informações relacionadas ao contrato foram desativadas com sucesso!"
    '        End If


    '        messageControl.Alert(lmsg)
    '        loadData()

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'saveFilters()
        Response.Redirect("frm_central_pedido_abertura_contrato.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        'If e.Row.RowType = DataControlRowType.DataRow Then
        '    Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
        '    Dim lbl_id_situacao_contrato As Label = CType(e.Row.FindControl("lbl_id_situacao_contrato"), Label)

        '    If lbl_id_situacao_contrato.Text.ToString.Equals("5") OrElse lbl_id_situacao_contrato.Text.ToString.Equals("6") Then 'se for aprovado 2o nivel nao pode destaivar
        '        btn_delete.Enabled = False
        '        btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
        '        btn_delete.ToolTip = "Não é possível excluir o registro. O contrato já foi aprovado/reprovado em 2o Nível."
        '    Else
        '        btn_delete.Enabled = True
        '        btn_delete.ImageUrl = "~/img/icone_excluir.gif"
        '        btn_delete.ToolTip = String.Empty
        '    End If

        'End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                'Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
                Dim btn_editar As Anthem.ImageButton = CType(e.Row.FindControl("img_editar"), Anthem.ImageButton)

                'btn_delete.CommandArgument = e.Row.RowIndex.ToString
                btn_editar.CommandArgument = e.Row.RowIndex.ToString

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub

 
End Class
