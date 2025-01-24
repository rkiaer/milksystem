Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_central_pedido
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
        If Not (Me.hf_id_item.Value.Equals(String.Empty)) Then
            ViewState.Item("id_item") = Me.hf_id_item.Value
        Else
            ViewState.Item("id_item") = String.Empty
        End If
        ViewState.Item("cd_item") = Me.txt_cd_item.Text.Trim()
        ViewState.Item("nm_item") = Me.lbl_nm_item.Text.Trim()

        ViewState.Item("dt_pedido") = Me.txt_dt_pedido.Text.Trim
        ViewState.Item("id_situacao_pedido") = Me.cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_pedido.aspx?st_incluirlog=N")

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_pedido.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 97
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
        With btn_lupa_item
            .Attributes.Add("onclick", "javascript:ShowDialogItem()")
            .ToolTip = "Filtrar Itens"
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

            cbo_situacao.DataSource = status.getSituacoesPedidosByFilters()
            cbo_situacao.DataTextField = "nm_situacao_pedido"
            cbo_situacao.DataValueField = "id_situacao_pedido"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ViewState.Item("sortExpression") = "id_central_pedido desc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("ctrpedido", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("ctrpedido", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("ctrpedido", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("ctrpedido", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("ctrpedido", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("ctrpedido", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If
        If Not (customPage.getFilterValue("ctrpedido", txt_cd_fornecedor.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_fornecedor") = customPage.getFilterValue("ctrpedido", txt_cd_fornecedor.ID)
            txt_cd_fornecedor.Text = ViewState.Item("cd_fornecedor").ToString()
        Else
            ViewState.Item("cd_fornecedor") = String.Empty
        End If

        If Not (customPage.getFilterValue("ctrpedido", lbl_nm_fornecedor.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_fornecedor") = customPage.getFilterValue("ctrpedido", lbl_nm_fornecedor.ID)
            lbl_nm_fornecedor.Text = ViewState.Item("nm_fornecedor").ToString()
        Else
            ViewState.Item("nm_fornecedor") = String.Empty
        End If

        If Not (customPage.getFilterValue("ctrpedido", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("ctrpedido", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If
        If Not (customPage.getFilterValue("ctrpedido", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_fornecedor") = customPage.getFilterValue("ctrpedido", hf_id_fornecedor.ID)
            hf_id_fornecedor.Value = ViewState.Item("id_fornecedor").ToString()
        Else
            ViewState.Item("id_fornecedor") = String.Empty
            hf_id_fornecedor.Value = String.Empty
        End If


        If Not (customPage.getFilterValue("ctrpedido", txt_id_cotacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_central_cotacao") = customPage.getFilterValue("ctrpedido", txt_id_cotacao.ID)
            txt_id_cotacao.Text = ViewState.Item("id_central_cotacao").ToString()
        Else
            ViewState.Item("id_central_cotacao") = String.Empty
        End If
        If Not (customPage.getFilterValue("ctrpedido", txt_id_pedido.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_central_pedido") = customPage.getFilterValue("ctrpedido", txt_id_pedido.ID)
            txt_id_pedido.Text = ViewState.Item("id_central_pedido").ToString()
        Else
            ViewState.Item("id_central_pedido") = String.Empty
        End If

        If Not (customPage.getFilterValue("ctrpedido", txt_cd_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_item") = customPage.getFilterValue("ctrpedido", txt_cd_item.ID)
            txt_cd_item.Text = ViewState.Item("cd_item").ToString()
        Else
            ViewState.Item("cd_item") = String.Empty
        End If

        If Not (customPage.getFilterValue("ctrpedido", lbl_nm_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_item") = customPage.getFilterValue("ctrpedido", lbl_nm_item.ID)
            lbl_nm_item.Text = ViewState.Item("nm_item").ToString()
        Else
            ViewState.Item("nm_item") = String.Empty
        End If

        If Not (customPage.getFilterValue("ctrpedido", hf_id_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_item") = customPage.getFilterValue("ctrpedido", hf_id_item.ID)
            hf_id_item.Value = ViewState.Item("id_item").ToString()
        Else
            ViewState.Item("id_item") = String.Empty
            hf_id_item.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("ctrpedido", txt_dt_pedido.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_pedido") = customPage.getFilterValue("ctrpedido", txt_dt_pedido.ID)
            txt_dt_pedido.Text = ViewState.Item("dt_pedido").ToString()
        Else
            ViewState.Item("dt_pedido") = String.Empty
            txt_dt_pedido.Text = String.Empty
        End If


        If Not (customPage.getFilterValue("ctrpedido", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao_pedido") = customPage.getFilterValue("ctrpedido", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao_pedido").ToString()
        Else
            ViewState.Item("id_situacao_pedido") = String.Empty
        End If


        If Not (customPage.getFilterValue("ctrpedido", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("ctrpedido", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("ctrpedido")
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
            If Not (ViewState.Item("id_item").Equals(String.Empty)) Then
                pedido.id_item = Convert.ToInt32(ViewState.Item("id_item").ToString)
            Else
                pedido.id_item = 0
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

            'fRAN CHAMado 822 i 07/05/2010
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
            If Not (ViewState.Item("cd_item").Equals(String.Empty)) Then
                pedido.cd_item = ViewState.Item("cd_item").ToString
            Else
                pedido.cd_item = String.Empty
            End If
            'fran chamado 882 f

            Dim dsPedidoItens As DataSet = pedido.getCentralPedidoseSeusItensbyFilter()

            If (dsPedidoItens.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPedidoItens.Tables(0), ViewState.Item("sortExpression"))
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
                'fran 23/09/2013 i
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
                'fran 23/09/2013 f
            Case "dt_pedido"
                If (ViewState.Item("sortExpression")) = "dt_pedido asc" Then
                    ViewState.Item("sortExpression") = "dt_pedido desc"
                Else
                    ViewState.Item("sortExpression") = "dt_pedido asc"
                End If
                'fran 23/09/2013 i
            Case "cd_item"
                If (ViewState.Item("sortExpression")) = "cd_item asc" Then
                    ViewState.Item("sortExpression") = "cd_item desc"
                Else
                    ViewState.Item("sortExpression") = "cd_item asc"
                End If

            Case "nm_item"
                If (ViewState.Item("sortExpression")) = "nm_item asc" Then
                    ViewState.Item("sortExpression") = "nm_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_item asc"
                End If
            Case "dt_entrega"
                If (ViewState.Item("sortExpression")) = "dt_entrega asc" Then
                    ViewState.Item("sortExpression") = "dt_entrega desc"
                Else
                    ViewState.Item("sortExpression") = "dt_entrega asc"
                End If
                'fran 23/09/2013 f
            Case "nm_situacao_pedido"
                If (ViewState.Item("sortExpression")) = "nm_situacao_pedido asc" Then
                    ViewState.Item("sortExpression") = "nm_situacao_pedido desc"
                Else
                    ViewState.Item("sortExpression") = "nm_situacao_pedido asc"
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


            customPage.setFilter("ctrpedido", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("ctrpedido", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("ctrpedido", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("ctrpedido", txt_cd_fornecedor.ID, ViewState.Item("cd_fornecedor").ToString)
            customPage.setFilter("ctrpedido", lbl_nm_fornecedor.ID, lbl_nm_fornecedor.Text)
            customPage.setFilter("ctrpedido", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("ctrpedido", cbo_situacao.ID, ViewState.Item("id_situacao_pedido").ToString)
            customPage.setFilter("ctrpedido", txt_cd_item.ID, ViewState.Item("cd_item").ToString)
            customPage.setFilter("ctrpedido", lbl_nm_item.ID, ViewState.Item("nm_item").ToString)
            customPage.setFilter("ctrpedido", hf_id_item.ID, ViewState.Item("id_item").ToString)
            customPage.setFilter("ctrpedido", hf_id_fornecedor.ID, ViewState.Item("id_fornecedor").ToString)
            customPage.setFilter("ctrpedido", txt_id_pedido.ID, ViewState.Item("id_central_pedido").ToString)
            customPage.setFilter("ctrpedido", txt_id_cotacao.ID, ViewState.Item("id_central_cotacao").ToString)
            customPage.setFilter("ctrpedido", txt_dt_pedido.ID, ViewState.Item("dt_pedido").ToString)
            customPage.setFilter("ctrpedido", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_central_pedido.aspx?id_central_pedido=" + e.CommandArgument.ToString())

            Case "delete"
                deleteCentralPedido(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteCentralPedido(ByVal id_central_pedido As Integer)

        Try
            Dim pedido As New Pedido()
            pedido.id_central_pedido = id_central_pedido
            pedido.id_modificador = Convert.ToInt32(Session("id_login"))
            pedido.deleteCentralPedido()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 97
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            Try
                Dim id_central_pedido_item As Label = CType(e.Row.FindControl("id_central_pedido_item"), Label)
                Dim lbl_entrega As Label = CType(e.Row.FindControl("lbl_entrega"), Label)
                Dim entrega As New PedidoEntrega
                entrega.id_central_pedido_item = Convert.ToInt32(id_central_pedido_item.Text)
                lbl_entrega.Text = entrega.getCentralPedidoEntregaPrimeiraData
                If lbl_entrega.Text = "01/01/1900" Then
                    lbl_entrega.Text = String.Empty
                End If
                'chamado 1071 Fran 22/11/2010 i
                Dim nr_frete As Label = CType(e.Row.FindControl("nr_frete"), Label)
                Dim id_grupo As Label = CType(e.Row.FindControl("id_grupo"), Label)
                'atribui a cluna valor unitario o valor do frete se o fornecedor for tipo transportador (grupo =3)
                If id_grupo.Text.ToString.Trim.Equals("3") Then
                    e.Row.Cells(12).Text = nr_frete.Text.ToString.Trim
                End If
                'chamado 1071 Fran 22/11/2010 f

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

    Protected Sub btn_lupa_item_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_item.Click
        Me.lbl_nm_item.Visible = True
        carregarcampositem()

    End Sub

    Protected Sub btn_lupa_parceiro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_parceiro.Click
        Me.lbl_nm_fornecedor.Visible = True
        carregarCamposFornecedor()

    End Sub
    Private Sub carregarcampositem()
        Try

            If Not (customPage.getFilterValue("lupa_item", "cd_item").Equals(String.Empty)) Then
                Me.txt_cd_item.Text = customPage.getFilterValue("lupa_item", "cd_item").ToString
            End If

            If Not (customPage.getFilterValue("lupa_item", "nm_item").Equals(String.Empty)) Then
                Me.lbl_nm_item.Visible = True
                Me.lbl_nm_item.Text = customPage.getFilterValue("lupa_item", "nm_item").ToString
            End If
            'If Not (customPage.getFilterValue("lupa_item", "cd_unidade_medida").Equals(String.Empty)) Then
            'Me.lbl_unidade_medida.Text = customPage.getFilterValue("lupa_item", "cd_unidade_medida").ToString
            'End If
            customPage.clearFilters("lupa_item")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

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

    Protected Sub txt_cd_item_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_item.TextChanged
        lbl_nm_item.Text = String.Empty
        'lbl_nm_item.Visible = False  ' Adri 04/05/2010
        hf_id_item.Value = String.Empty
        'Fran 11/03/2010 chamado 684
        Try
            If Not txt_cd_item.Text.ToString.Equals(String.Empty) Then 'fran 05/05/2010
                Dim item As New Item
                item.cd_item = txt_cd_item.Text.Trim
                Dim dsitem As DataSet = item.getItensCentralByFilters
                If dsitem.Tables(0).Rows.Count > 0 Then
                    lbl_nm_item.Enabled = True
                    lbl_nm_item.Text = dsitem.Tables(0).Rows(0).Item("nm_item")
                    hf_id_item.Value = dsitem.Tables(0).Rows(0).Item("id_item").ToString

                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        'Fran 11/03/2010 chamado 684

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
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
        If Not (Me.hf_id_item.Value.Equals(String.Empty)) Then
            ViewState.Item("id_item") = Me.hf_id_item.Value
        Else
            ViewState.Item("id_item") = String.Empty
        End If
        ViewState.Item("cd_item") = Me.txt_cd_item.Text.Trim()
        ViewState.Item("nm_item") = Me.lbl_nm_item.Text.Trim()

        ViewState.Item("dt_pedido") = Me.txt_dt_pedido.Text.Trim
        ViewState.Item("id_situacao_pedido") = Me.cbo_situacao.SelectedValue

        loadData()

        'se o grid tiver mais que 65536  linhas não podemos exportar
        If gridResults.Visible = True Then
            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 8 'exporta~ção
                usuariolog.id_menu_item = 97
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Response.Redirect("frm_central_pedido_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString + "&id_fornecedor=" + ViewState.Item("id_fornecedor").ToString + "&id_central_cotacao=" + ViewState.Item("id_central_cotacao").ToString + "&id_central_pedido=" + ViewState.Item("id_central_pedido").ToString + "&id_item=" + ViewState.Item("id_item").ToString + "&cd_item=" + ViewState.Item("cd_item").ToString + "&cd_fornecedor=" + ViewState.Item("cd_fornecedor").ToString + "&cd_pessoa=" + ViewState.Item("cd_pessoa").ToString + "&dt_pedido=" + ViewState.Item("dt_pedido").ToString + "&id_situacao_pedido=" + ViewState.Item("id_situacao_pedido").ToString)
            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
            End If
        End If

    End Sub
End Class
