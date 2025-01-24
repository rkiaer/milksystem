Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_central_pedido_reabrir
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
        ViewState.Item("nm_pessoa") = Me.lbl_nm_pessoa.Text.Trim()
        ViewState.Item("cd_fornecedor") = Me.txt_cd_fornecedor.Text.Trim()
        ViewState.Item("nm_fornecedor") = Me.lbl_nm_fornecedor.Text.Trim()

        If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
            ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If

        If Not (Me.hf_id_fornecedor.Value.Equals(String.Empty)) Then
            ViewState.Item("id_fornecedor") = Me.hf_id_fornecedor.Value
        Else
            ViewState.Item("id_fornecedor") = String.Empty
        End If
        If Not (Me.txt_id_cotacao.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_central_cotacao") = Me.txt_id_cotacao.Text.Trim()
        Else
            ViewState.Item("id_central_cotacao") = String.Empty
        End If
        If Not (Me.txt_id_pedido.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_central_pedido") = Me.txt_id_pedido.Text.Trim()
        Else
            ViewState.Item("id_central_pedido") = String.Empty
        End If

        ViewState.Item("dt_pedido") = Me.txt_dt_pedido.Text.Trim
        ViewState.Item("id_situacao_pedido") = Me.cbo_situacao.SelectedValue
        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_pedido_reabrir.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_pedido_reabrir.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 133
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 


            loadDetails()
        End If

        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
            '.Style("cursor") = "hand"
        End With
        With btn_lupa_parceiro
            .Attributes.Add("onclick", "javascript:ShowDialogFornecedor()")
            .ToolTip = "Filtrar Parceiros"
            '.Style("cursor") = "hand"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New SituacaoPedido
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'so deve ficar situacao Finalizado e Reaberto
            cbo_situacao.DataSource = status.getSituacoesPedidosByFilters()
            cbo_situacao.DataTextField = "nm_situacao_pedido"
            cbo_situacao.DataValueField = "id_situacao_pedido"
            cbo_situacao.DataBind()
            cbo_situacao.Items.RemoveAt(0) 'remove situacao ativo
            cbo_situacao.Items.RemoveAt(0) 'remove situacao cancela


            ViewState.Item("sortExpression") = "id_central_pedido desc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("pedidoreabrir", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("pedidoreabrir", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("pedidoreabrir", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("pedidoreabrir", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("pedidoreabrir", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("pedidoreabrir", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If
        If Not (customPage.getFilterValue("pedidoreabrir", txt_cd_fornecedor.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_fornecedor") = customPage.getFilterValue("pedidoreabrir", txt_cd_fornecedor.ID)
            txt_cd_fornecedor.Text = ViewState.Item("cd_fornecedor").ToString()
        Else
            ViewState.Item("cd_fornecedor") = String.Empty
        End If

        If Not (customPage.getFilterValue("pedidoreabrir", lbl_nm_fornecedor.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_fornecedor") = customPage.getFilterValue("pedidoreabrir", lbl_nm_fornecedor.ID)
            lbl_nm_fornecedor.Text = ViewState.Item("nm_fornecedor").ToString()
        Else
            ViewState.Item("nm_fornecedor") = String.Empty
        End If

        If Not (customPage.getFilterValue("pedidoreabrir", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("pedidoreabrir", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If
        If Not (customPage.getFilterValue("pedidoreabrir", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_fornecedor") = customPage.getFilterValue("pedidoreabrir", hf_id_fornecedor.ID)
            hf_id_fornecedor.Value = ViewState.Item("id_fornecedor").ToString()
        Else
            ViewState.Item("id_fornecedor") = String.Empty
            hf_id_fornecedor.Value = String.Empty
        End If


        If Not (customPage.getFilterValue("pedidoreabrir", txt_id_cotacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_central_cotacao") = customPage.getFilterValue("pedidoreabrir", txt_id_cotacao.ID)
            txt_id_cotacao.Text = ViewState.Item("id_central_cotacao").ToString()
        Else
            ViewState.Item("id_central_cotacao") = String.Empty
        End If
        If Not (customPage.getFilterValue("pedidoreabrir", txt_id_pedido.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_central_pedido") = customPage.getFilterValue("pedidoreabrir", txt_id_pedido.ID)
            txt_id_pedido.Text = ViewState.Item("id_central_pedido").ToString()
        Else
            ViewState.Item("id_central_pedido") = String.Empty
        End If

        If Not (customPage.getFilterValue("pedidoreabrir", txt_dt_pedido.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_pedido") = customPage.getFilterValue("pedidoreabrir", txt_dt_pedido.ID)
            txt_dt_pedido.Text = ViewState.Item("dt_pedido").ToString()
        Else
            ViewState.Item("dt_pedido") = String.Empty
            txt_dt_pedido.Text = String.Empty
        End If
        If Not (customPage.getFilterValue("pedidoreabrir", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao_pedido") = customPage.getFilterValue("pedidoreabrir", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao_pedido").ToString()
        Else
            ViewState.Item("id_situacao_pedido") = String.Empty
        End If


        If Not (customPage.getFilterValue("pedidoreabrir", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("pedidoreabrir", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("pedidoreabrir")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim pedido As New Pedido

            If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                pedido.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            Else
                pedido.id_pessoa = 0
            End If
            If Not (ViewState.Item("id_fornecedor").Equals(String.Empty)) Then
                pedido.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor").ToString)
            Else
                pedido.id_fornecedor = 0
            End If
            If Not (ViewState.Item("id_central_pedido").Equals(String.Empty)) Then
                pedido.id_central_pedido = Convert.ToInt32(ViewState.Item("id_central_pedido").ToString)
            Else
                pedido.id_central_pedido = 0
            End If
            If Not (ViewState.Item("id_central_cotacao").Equals(String.Empty)) Then
                pedido.id_central_cotacao = Convert.ToInt32(ViewState.Item("id_central_cotacao").ToString)
            Else
                pedido.id_central_cotacao = 0
            End If
            If Not (ViewState.Item("id_estabelecimento").Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            Else
                pedido.id_estabelecimento = 0
            End If

            pedido.dt_pedido = txt_dt_pedido.Text.ToString

            If Not (ViewState.Item("id_situacao_pedido").Equals(String.Empty)) Then
                pedido.id_situacao_pedido = Convert.ToInt32(ViewState.Item("id_situacao_pedido").ToString)
            Else
                pedido.id_situacao_pedido = 0
            End If

            If Not (ViewState.Item("cd_pessoa").Equals(String.Empty)) Then
                pedido.cd_produtor = ViewState.Item("cd_pessoa").ToString
            Else
                pedido.cd_produtor = String.Empty
            End If
            If Not (ViewState.Item("cd_fornecedor").Equals(String.Empty)) Then
                pedido.cd_fornecedor = ViewState.Item("cd_fornecedor").ToString
            Else
                pedido.cd_fornecedor = String.Empty
            End If

            Dim dsPedidoReabrir As DataSet

            If (ViewState.Item("id_situacao_pedido").Equals("3")) Then 'se procura por finalizados
                dsPedidoReabrir = pedido.getCentralPedidoReabrir() 'busca todos os pedidos finalizados que tenham parcelas ao produtor abertas
            Else
                dsPedidoReabrir = pedido.getCentralPedidoseSeusItensbyFilter()
            End If

            If (dsPedidoReabrir.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPedidoReabrir.Tables(0), ViewState.Item("sortExpression"))
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

            Case "nm_abreviado_pessoa"
                If (ViewState.Item("sortExpression")) = "nm_abreviado_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_abreviado_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_abreviado_pessoa asc"
                End If

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If

            Case "nr_unid_producao"
                If (ViewState.Item("sortExpression")) = "nr_unid_producao asc" Then
                    ViewState.Item("sortExpression") = "nr_unid_producao desc"
                Else
                    ViewState.Item("sortExpression") = "nr_unid_producao asc"
                End If

            Case "id_central_pedido"
                If (ViewState.Item("sortExpression")) = "id_central_pedido asc" Then
                    ViewState.Item("sortExpression") = "id_central_pedido desc"
                Else
                    ViewState.Item("sortExpression") = "id_central_pedido asc"
                End If
            Case "cd_fornecedor"
                If (ViewState.Item("sortExpression")) = "cd_fornecedor asc" Then
                    ViewState.Item("sortExpression") = "cd_fornecedor desc"
                Else
                    ViewState.Item("sortExpression") = "cd_fornecedor asc"
                End If

            Case "nm_abreviado_fornecedor"
                If (ViewState.Item("sortExpression")) = "nm_abreviado_fornecedor asc" Then
                    ViewState.Item("sortExpression") = "nm_abreviado_fornecedor desc"
                Else
                    ViewState.Item("sortExpression") = "nm_abreviado_fornecedor asc"
                End If
            Case "dt_pedido"
                If (ViewState.Item("sortExpression")) = "dt_pedido asc" Then
                    ViewState.Item("sortExpression") = "dt_pedido desc"
                Else
                    ViewState.Item("sortExpression") = "dt_pedido asc"
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


            customPage.setFilter("pedidoreabrir", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("pedidoreabrir", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("pedidoreabrir", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("pedidoreabrir", txt_cd_fornecedor.ID, ViewState.Item("cd_fornecedor").ToString)
            customPage.setFilter("pedidoreabrir", lbl_nm_fornecedor.ID, lbl_nm_fornecedor.Text)
            customPage.setFilter("pedidoreabrir", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("pedidoreabrir", hf_id_fornecedor.ID, ViewState.Item("id_fornecedor").ToString)
            customPage.setFilter("pedidoreabrir", cbo_situacao.ID, ViewState.Item("id_situacao_pedido").ToString)
            customPage.setFilter("pedidoreabrir", txt_id_pedido.ID, ViewState.Item("id_central_pedido").ToString)
            customPage.setFilter("pedidoreabrir", txt_id_cotacao.ID, ViewState.Item("id_central_cotacao").ToString)
            customPage.setFilter("pedidoreabrir", txt_dt_pedido.ID, ViewState.Item("dt_pedido").ToString)
            customPage.setFilter("pedidoreabrir", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Try

            Select Case e.CommandName.ToString().ToLower()
                Case "reabrir"
                    Dim pedido As New Pedido(Convert.ToInt32(e.CommandArgument.ToString))
                    pedido.id_modificador = Session("id_login")
                    pedido.reabrirPedido()

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'PROCESSO
                    usuariolog.id_menu_item = 133
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f

                    saveFilters()
                    Response.Redirect("frm_central_pedido.aspx?id_central_pedido=" + e.CommandArgument.ToString() + "&tela=lst_central_pedido_reabrir.aspx")


                Case "edit"
                    saveFilters()
                    Response.Redirect("frm_central_pedido.aspx?id_central_pedido=" + e.CommandArgument.ToString() + "&tela=lst_central_pedido_reabrir.aspx")

            End Select

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            Try
                Dim btn_editar As ImageButton = CType(e.Row.FindControl("img_editar"), ImageButton)
                Dim btn_reabrirpedido As LinkButton = CType(e.Row.FindControl("lk_reabrirpedido"), LinkButton)

                If ViewState.Item("id_situacao_pedido").Equals("3") Then
                    btn_editar.Visible = False
                    btn_reabrirpedido.Visible = True
                Else
                    btn_editar.Visible = True
                    btn_reabrirpedido.Visible = False

                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()

    End Sub


    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        'lbl_nm_pessoa.Visible = False  ' Adri 04/05/2010
        hf_id_pessoa.Value = String.Empty
        'fran chamado 684 i 
        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 'fran 05/05/2010
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_parceiro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_parceiro.Click
        Me.lbl_nm_fornecedor.Visible = True
        carregarCamposFornecedor()

    End Sub
 
    Private Sub carregarCamposFornecedor()

        Try
            If Not (customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_fornecedor.Text = customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_fornecedor.Text = customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_fornecedor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_fornecedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_fornecedor.TextChanged
        lbl_nm_fornecedor.Text = String.Empty
        'lbl_nm_fornecedor.Visible = False   ' Adri 04/05/2010
        hf_id_fornecedor.Value = String.Empty
        'fran chamado 684 i 
        Try
            If Not txt_cd_fornecedor.Text.Equals(String.Empty) Then
                Dim fornecedor As New Pessoa
                'fornecedor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                fornecedor.cd_pessoa = Me.txt_cd_fornecedor.Text.Trim  ' Adri 04/05/2010
                fornecedor.id_situacao = 1
                'Dim dsfornecedor As DataSet = fornecedor.getPessoaByFilters
                Dim dsfornecedor As DataSet = fornecedor.getFornecedorByFilters
                'se encontrou produtor
                If dsfornecedor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_fornecedor.Enabled = True
                    lbl_nm_fornecedor.Text = dsfornecedor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_fornecedor.Value = dsfornecedor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If
            'fran chamado 684 f

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


End Class
