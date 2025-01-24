Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.IO

Partial Class lst_central_pedido_cancelar
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
        ViewState.Item("nm_pessoa") = Me.lbl_nm_pessoa.Text.Trim()
        ViewState.Item("cd_fornecedor") = Me.txt_cd_fornecedor.Text.Trim()
        ViewState.Item("nm_fornecedor") = Me.lbl_nm_fornecedor.Text.Trim()
        If chk_pedidos_cancelados.Checked = True Then
            ViewState.Item("id_situacao_pedido") = "2" 'Cancelado
        Else
            ViewState.Item("id_situacao_pedido") = String.Empty
        End If

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
        If Not (Me.txt_id_pedido.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_central_pedido") = Me.txt_id_pedido.Text.Trim()
        Else
            ViewState.Item("id_central_pedido") = String.Empty
        End If

        ViewState.Item("dt_pedido") = Me.txt_dt_pedido.Text.Trim

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_pedido_cancelar.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_pedido_cancelar.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 112
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


            ViewState.Item("sortExpression") = "id_central_pedido desc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("pedidocanc", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("pedidocanc", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("pedidocanc", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("pedidocanc", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("pedidocanc", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("pedidocanc", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If
        If Not (customPage.getFilterValue("pedidocanc", txt_cd_fornecedor.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_fornecedor") = customPage.getFilterValue("pedidocanc", txt_cd_fornecedor.ID)
            txt_cd_fornecedor.Text = ViewState.Item("cd_fornecedor").ToString()
        Else
            ViewState.Item("cd_fornecedor") = String.Empty
        End If

        If Not (customPage.getFilterValue("pedidocanc", lbl_nm_fornecedor.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_fornecedor") = customPage.getFilterValue("pedidocanc", lbl_nm_fornecedor.ID)
            lbl_nm_fornecedor.Text = ViewState.Item("nm_fornecedor").ToString()
        Else
            ViewState.Item("nm_fornecedor") = String.Empty
        End If

        If Not (customPage.getFilterValue("pedidocanc", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("pedidocanc", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If
        If Not (customPage.getFilterValue("pedidocanc", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_fornecedor") = customPage.getFilterValue("pedidocanc", hf_id_fornecedor.ID)
            hf_id_fornecedor.Value = ViewState.Item("id_fornecedor").ToString()
        Else
            ViewState.Item("id_fornecedor") = String.Empty
            hf_id_fornecedor.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("pedidocanc", txt_id_pedido.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_central_pedido") = customPage.getFilterValue("pedidocanc", txt_id_pedido.ID)
            txt_id_pedido.Text = ViewState.Item("id_central_pedido").ToString()
        Else
            ViewState.Item("id_central_pedido") = String.Empty
        End If

        If Not (customPage.getFilterValue("pedidocanc", txt_dt_pedido.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_pedido") = customPage.getFilterValue("pedidocanc", txt_dt_pedido.ID)
            txt_dt_pedido.Text = ViewState.Item("dt_pedido").ToString()
        Else
            ViewState.Item("dt_pedido") = String.Empty
            txt_dt_pedido.Text = String.Empty
        End If
        If Not (customPage.getFilterValue("pedidocanc", chk_pedidos_cancelados.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao_pedido") = 2
            chk_pedidos_cancelados.Checked = True
        Else
            ViewState.Item("id_situacao_pedido") = String.Empty
            chk_pedidos_cancelados.Checked = False

        End If


        If Not (customPage.getFilterValue("pedidocanc", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("pedidocanc", "PageIndex").ToString()
            grdresults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("pedidocanc")
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
            If Not (ViewState.Item("id_estabelecimento").Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            Else
                pedido.id_estabelecimento = 0
            End If

            pedido.dt_pedido = txt_dt_pedido.Text.ToString

            'If Not (ViewState.Item("cd_pessoa").Equals(String.Empty)) Then
            '    pedido.cd_produtor = ViewState.Item("cd_pessoa").ToString
            'Else
            '    pedido.cd_produtor = String.Empty
            'End If
            'If Not (ViewState.Item("cd_fornecedor").Equals(String.Empty)) Then
            '    pedido.cd_fornecedor = ViewState.Item("cd_fornecedor").ToString
            'Else
            '    pedido.cd_fornecedor = String.Empty
            'End If
            'If Not (ViewState.Item("cd_item").Equals(String.Empty)) Then
            '    pedido.cd_item = ViewState.Item("cd_item").ToString
            'Else
            '    pedido.cd_item = String.Empty
            'End If

            Dim dsPedido As DataSet
            If ViewState.Item("id_situacao_pedido") = "2" Then
                pedido.id_situacao_pedido = 2
                dsPedido = pedido.getPedidoByFilters
            Else
                dsPedido = pedido.getPedidosCancelar
            End If


            If (dsPedido.Tables(0).Rows.Count > 0) Then
                grdresults.Visible = True
                grdresults.DataSource = Helper.getDataView(dsPedido.Tables(0), ViewState.Item("sortExpression"))
                grdresults.DataBind()
            Else
                'Fran 06/09/2011 - chamado 1348 i
                'se não tem linhas no dataset e o grid tem uma linha, significa que houve cancelamento do pedido então carrega o grid para que saia do modo de edição (vindo do rowupdate)
                If grdresults.Rows.Count > 0 Then
                    grdresults.DataSource = Helper.getDataView(dsPedido.Tables(0), ViewState.Item("sortExpression"))
                    grdresults.DataBind()
                End If
                'Fran 06/09/2011 - chamado 1348 f
                grdresults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            'loadgridresults()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

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


            customPage.setFilter("pedidocanc", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("pedidocanc", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("pedidocanc", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("pedidocanc", txt_cd_fornecedor.ID, ViewState.Item("cd_fornecedor").ToString)
            customPage.setFilter("pedidocanc", lbl_nm_fornecedor.ID, lbl_nm_fornecedor.Text)
            customPage.setFilter("pedidocanc", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("pedidocanc", hf_id_fornecedor.ID, ViewState.Item("id_fornecedor").ToString)
            customPage.setFilter("pedidocanc", txt_id_pedido.ID, ViewState.Item("id_central_pedido").ToString)
            customPage.setFilter("pedidocanc", txt_dt_pedido.ID, ViewState.Item("dt_pedido").ToString)
            customPage.setFilter("pedidocanc", chk_pedidos_cancelados.ID, ViewState.Item("id_situacao_pedido").ToString)
            customPage.setFilter("pedidocanc", "PageIndex", grdresults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub deleteCentralPedido(ByVal id_central_pedido As Integer)

        Try
            Dim pedido As New Pedido()
            pedido.id_central_pedido = id_central_pedido
            pedido.id_modificador = Convert.ToInt32(Session("id_login"))
            pedido.deleteCentralPedido()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

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
    Protected Sub cv_produtor_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_produtor.ServerValidate
        Try
            args.IsValid = True

            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then 'se tem cd pessoa
                If hf_id_pessoa.Value.ToString.Equals(String.Empty) Then '...e id_pessoa está vazio
                    args.IsValid = False 'pessoa nao cadastrada
                Else
                    args.IsValid = True
                End If
            End If
            If args.IsValid = False Then
                messageControl.Alert("Cód. Produtor não existe nos cadastros!")

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub
    Protected Sub cv_fornecedor_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_fornecedor.ServerValidate
        Try
            args.IsValid = True

            If Not txt_cd_fornecedor.Text.Equals(String.Empty) Then 'se tem cd fornecedor
                If hf_id_fornecedor.Value.ToString.Equals(String.Empty) Then '...e id_fornecedor está vazio
                    args.IsValid = False 'pessoa nao cadastrada
                Else
                    args.IsValid = True
                End If
            End If
            If args.IsValid = False Then
                messageControl.Alert("Cód. Parceiro não existe nos cadastros!")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub
    Protected Sub cv_id_pedido_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_id_pedido.ServerValidate
        Try
            args.IsValid = True
            If Not txt_id_pedido.Text.Equals(String.Empty) Then
                Dim pedido As New Pedido
                pedido.id_central_pedido = Convert.ToInt32(txt_id_pedido.Text)
                Dim dspedido As DataSet = pedido.getPedidosCancelar
                If dspedido.Tables(0).Rows.Count > 0 Then
                    If dspedido.Tables(0).Rows(0).Item("id_situacao_pedido").ToString = "2" Then
                        args.IsValid = False 'é pedido cancelado
                    End If
                End If
            End If
            If args.IsValid = False Then
                messageControl.Alert("O Nr. Pedido informado já está com situação 'Cancelado', não podendo ser cancelado novamente.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub
    Protected Sub grdresults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdresults.PageIndexChanging
        grdresults.PageIndex = e.NewPageIndex
        loadData()


    End Sub
    Protected Sub grdresults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdresults.RowCancelingEdit
        Try

            grdresults.EditIndex = -1
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub grdresults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdresults.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "EnviarEmail"
                Dim wc As WebControl = CType(e.CommandSource, WebControl)
                Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
                Dim nm_estabelecimento As Label = CType(row.FindControl("nm_estabelecimento"), Label)
                Dim nr_unid_producao As Label = CType(row.FindControl("nr_unid_producao"), Label)
                Dim id_propriedade As Label = CType(row.FindControl("id_propriedade"), Label)
                Dim id_produtor As Label = CType(row.FindControl("id_produtor"), Label)
                Dim id_fornecedor As Label = CType(row.FindControl("id_fornecedor"), Label)
                Dim nm_pedido_cancelar_motivo As Label = CType(row.FindControl("lbl_nm_pedido_cancelar_motivo"), Label)

                EnvioEmailCancelamentoFornecedor(Convert.ToInt32(e.CommandArgument.ToString), Convert.ToInt32(id_propriedade.Text), Convert.ToInt32(id_produtor.Text), Convert.ToInt32(id_fornecedor.Text), nm_estabelecimento.Text.ToString, nr_unid_producao.Text.ToString, nm_pedido_cancelar_motivo.Text.ToString)

        End Select

    End Sub

    Protected Sub grdresults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdresults.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                If Not (ViewState("label_cancelar_motivo") Is Nothing) Then
                    Dim cbo_pedido_cancelar_motivo As DropDownList = CType(e.Row.FindControl("cbo_pedido_cancelar_motivo"), DropDownList)
                    Dim motivo As New PedidoCancelarMotivo

                    cbo_pedido_cancelar_motivo.DataSource = motivo.getPedidoCancelarMotivoByFilters()
                    cbo_pedido_cancelar_motivo.DataTextField = "nm_pedido_cancelar_motivo"
                    cbo_pedido_cancelar_motivo.DataValueField = "id_pedido_cancelar_motivo"
                    cbo_pedido_cancelar_motivo.DataBind()

                    If (ViewState("label_cancelar_motivo").ToString.Equals(String.Empty)) Then
                        cbo_pedido_cancelar_motivo.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState("label_cancelar_motivo") = "SEM_VALOR" 'Assume que  esta sem valor
                    Else
                        cbo_pedido_cancelar_motivo.SelectedValue = cbo_pedido_cancelar_motivo.Items.FindByText(ViewState("label_cancelar_motivo").Trim.ToString).Value
                        ViewState("label_cancelar_motivo") = Nothing 'Assume que  tem valor
                    End If
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Protected Sub grdresults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdresults.RowDataBound
        Try
            'se esta editando
            If e.Row.RowType = DataControlRowType.DataRow Then
                If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

                    'Se já fez a criação  da linha e esta sem valor no combo 
                    Dim cbo_pedido_cancelar_motivo As DropDownList = CType(e.Row.FindControl("cbo_pedido_cancelar_motivo"), DropDownList)
                    If Not (cbo_pedido_cancelar_motivo Is Nothing) Then
                        cbo_pedido_cancelar_motivo.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    End If
                    ViewState("label_cancelar_motivo") = Nothing 'Assume que  tem valor
                Else
                    Dim btn_editar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)
                    Dim btn_envio_email As ImageButton = CType(e.Row.FindControl("btn_envio_email"), ImageButton)

                    'se quer visualizar apenas cancelados, exibe apenas email de cancelamento ao fornecedor
                    If ViewState.Item("id_situacao_pedido").ToString.Equals(String.Empty) Then
                        btn_envio_email.Visible = False
                        btn_editar.Visible = True
                    Else
                        btn_envio_email.Visible = True
                        btn_editar.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub grdresults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdresults.RowDeleting
        e.Cancel = True
    End Sub
    Protected Sub grdresults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdresults.RowEditing
        Try
            Dim lbl_nm_pedido_cancelar_motivo As Label = CType(grdresults.Rows(e.NewEditIndex).FindControl("lbl_nm_pedido_cancelar_motivo"), Label)
            ViewState.Item("label_cancelar_motivo") = Trim(lbl_nm_pedido_cancelar_motivo.Text)

            grdresults.EditIndex = e.NewEditIndex
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub grdresults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdresults.RowUpdating
        'Capturar valores

        If Page.IsValid = True Then
            Dim row As GridViewRow = grdresults.Rows(e.RowIndex)
            Try

                If (Not (row) Is Nothing) Then

                    Dim pedido As New Pedido
                    Dim id_propriedade As Label = CType(row.FindControl("id_propriedade"), Label)
                    Dim cbo_pedido_cancelar_motivo As Anthem.DropDownList = CType(row.FindControl("cbo_pedido_cancelar_motivo"), Anthem.DropDownList)
                    pedido.id_central_pedido = Convert.ToInt32(grdresults.DataKeys.Item(e.RowIndex).Value)
                    pedido.id_pedido_cancelar_motivo = Convert.ToInt32(cbo_pedido_cancelar_motivo.SelectedValue)
                    pedido.id_propriedade = Convert.ToInt32(id_propriedade.Text)

                    pedido.id_modificador = Session("id_login")

                    'FRAN 08/12/2020 i incluir log 
                    If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 6 'processo
                        usuariolog.id_nr_processo = pedido.id_central_pedido.ToString
                        usuariolog.id_menu_item = 112
                        usuariolog.insertUsuarioLog()
                    End If
                    'FRAN 08/12/2020  incluir log 

                    If pedido.cancelarPedido() = True Then
                        messageControl.Alert(String.Concat("Pedido ", pedido.id_central_pedido.ToString, " cancelado com sucesso!"))
                    Else
                        messageControl.Alert("Ocorreram problemas no cancelamento do Pedido. Contate o administrador do sistema.")
                    End If

                    grdresults.EditIndex = -1
                    loadData()
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Protected Sub grdresults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdresults.Sorting
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
            Case "dt_pedido"
                If (ViewState.Item("sortExpression")) = "dt_pedido asc" Then
                    ViewState.Item("sortExpression") = "dt_pedido desc"
                Else
                    ViewState.Item("sortExpression") = "dt_pedido asc"
                End If
            Case "nm_situacao_pedido"
                If (ViewState.Item("sortExpression")) = "nm_situacao_pedido asc" Then
                    ViewState.Item("sortExpression") = "nm_situacao_pedido desc"
                Else
                    ViewState.Item("sortExpression") = "nm_situacao_pedido asc"
                End If


        End Select

        loadData()

    End Sub
    Private Sub EnvioEmailCancelamentoFornecedor(ByVal id_central_pedido As Int32, ByVal id_propriedade As Int32, ByVal id_produtor As Int32, ByVal id_fornecedor As Int32, ByVal nm_estabelecimento As String, ByVal nr_unid_producao As String, ByVal nm_pedido_cancelar_motivo As String)

        Dim lassunto As String
        Dim lcorpo As String
        Dim arqTemp As StreamReader
        Dim lcaminhoservidor As String = System.Configuration.ConfigurationManager.AppSettings("PathReports").ToString()
        Dim propriedade As New Propriedade(Convert.ToInt32(id_propriedade))
        Dim produtor As New Pessoa(Convert.ToInt32(id_produtor))
        Dim fornecedor As New Pessoa(Convert.ToInt32(id_fornecedor))
        Dim lemail_parceiro As String
        Dim ldatahj As Date = DateTime.Parse(Now).ToString("dd/MM/yyyy")

        lemail_parceiro = fornecedor.ds_email
        If lemail_parceiro.Equals(String.Empty) Then
            If Not fornecedor.ds_email2 Is Nothing Then
                lemail_parceiro = fornecedor.ds_email2
            Else
                lemail_parceiro = String.Empty

            End If
        End If
        'lemail_parceiro = "franoliveira@hotmail.com"
        If Not lemail_parceiro.Equals(String.Empty) Then
            'lassunto = String.Concat("DANONE - Pedido de Compra ", "Nr ", id_central_pedido.ToString) fran 19/12/2013
            lassunto = String.Concat("DANONE - Cancelamento Pedido de Compra ", "Nr ", id_central_pedido.ToString)
            arqTemp = New StreamReader(lcaminhoservidor & "\central_pedido_email_fornecedor_cancelamento.HTML", Encoding.UTF7)
            lcorpo = ""
            Do While Not arqTemp.EndOfStream
                lcorpo = lcorpo & arqTemp.ReadLine
            Loop

            lcorpo = Replace(lcorpo, "$nm_estabelecimento", nm_estabelecimento.ToString)
            lcorpo = Replace(lcorpo, "$dt_hoje", String.Concat(Format(ldatahj, "dd").ToString, " de ", Format(ldatahj, "MMMM").ToString, " de ", Format(ldatahj, "yyyy").ToString & "."))
            lcorpo = Replace(lcorpo, "$id_pedido", id_central_pedido.ToString)
            lcorpo = Replace(lcorpo, "$nm_fornecedor", fornecedor.nm_pessoa)
            lcorpo = Replace(lcorpo, "$ds_fornec_contato", fornecedor.ds_contato)
            lcorpo = Replace(lcorpo, "$email", fornecedor.ds_email)
            lcorpo = Replace(lcorpo, "$fone1", fornecedor.ds_telefone_1)
            lcorpo = Replace(lcorpo, "$fone2", fornecedor.ds_telefone_2)
            ' Adriana 10/12/2010 - Erro reportado em reunião do dia 08/12/2010 - i
            lcorpo = Replace(lcorpo, "$nm_pedido_cancelar_motivo", nm_pedido_cancelar_motivo.ToString)
            ' Adriana 10/12/2010 - Erro reportado em reunião do dia 08/12/2010 - f

            lcorpo = Replace(lcorpo, "$nm_produtor", produtor.nm_pessoa)
            lcorpo = Replace(lcorpo, "$cd_produtor", produtor.cd_pessoa)
            lcorpo = Replace(lcorpo, "$nm_propriedade", propriedade.nm_propriedade)
            lcorpo = Replace(lcorpo, "$id_propriedade", propriedade.id_propriedade)
            lcorpo = Replace(lcorpo, "$nr_unid_producao", nr_unid_producao.ToString)
            lcorpo = Replace(lcorpo, "$bairro_produtor", produtor.ds_bairro)
            lcorpo = Replace(lcorpo, "$cidade_produtor", produtor.nm_cidade)
            lcorpo = Replace(lcorpo, "$nm_estado_produtor", produtor.nm_estado)
            If produtor.st_categoria = "F" Then
                lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cpf)
            Else
                lcorpo = Replace(lcorpo, "$cnpjprodutor", produtor.cd_cnpj)
            End If
            lcorpo = Replace(lcorpo, "$inscrestadualprodutor", produtor.cd_inscricao_estadual)
            lcorpo = Replace(lcorpo, "$ds_contato", produtor.ds_contato)
            lcorpo = Replace(lcorpo, "$prodfone3", produtor.ds_telefone_1)
            lcorpo = Replace(lcorpo, "$prodfone4", produtor.ds_telefone_2)


            Dim pedido As New Pedido
            pedido.id_central_pedido = Convert.ToInt32(id_central_pedido)
            Dim dsgrid As DataSet = pedido.getCentralPedidoEmailParceiroItens()
            Dim row As DataRow
            Dim ltable As String = String.Empty
            Dim i As Integer = 1
            For Each row In dsgrid.Tables(0).Rows
                If i > 1 Then
                    ltable = ltable & "<tr><td style='width: 20px; height: 15px;'>&nbsp;</td><td style='width: 27px; height: 15px;'>&nbsp;</td><td colspan='2' style='height: 15px'>&nbsp;</td><td colspan='4' style='height: 15px'>&nbsp;</td></tr>"
                End If
                ltable = "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td style='width: 27px; font-weight: bold; height: 17px;'>2." & i.ToString & ".</td>"
                ltable = ltable & "<td colspan='6' style='font-weight: bold; height: 17px'>" & row.Item("nm_item").ToString & "</td>"
                ltable = ltable & "</tr>"

                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style=' height: 17px;'>Quantidade:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & CInt(row.Item("nr_quantidade")).ToString & " " & row.Item("nm_unidade_medida").ToString & "</td>"
                ltable = ltable & "</tr>"
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Embalagem:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & row.Item("ds_tipo_medida").ToString & "</td>"
                ltable = ltable & "</tr>"
                If fornecedor.id_grupo <> 3 Then 'se o fornecedor for transportador de frete não exibe valor unitario e sacaria
                    ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                    ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Unitário:</td>"
                    ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_valor_unitario"), 2).ToString & "</td>"
                    ltable = ltable & "</tr>"
                    ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                    ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Sacaria:</td>"
                    ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_sacaria"), 2).ToString & "</td>"
                    ltable = ltable & "</tr>"
                End If

                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Preço Frete:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_frete"), 2).ToString & "</td>"
                ltable = ltable & "</tr>"
                ltable = ltable & "<tr><td style='width: 20px; height: 17px;'>&nbsp;</td><td style='width: 27px; height: 17px;'>&nbsp;</td>"
                ltable = ltable & "<td colspan='2' style='height: 17px'>Valor Total:</td>"
                ltable = ltable & "<td colspan='4' style='height: 17px'>" & FormatCurrency(row.Item("nr_valor_total"), 2).ToString & "</td>"
                ltable = ltable & "</tr>"

                'lcorpo = Replace(lcorpo, "$itens", i.ToString)
                i = i + 1
            Next


            lcorpo = Replace(lcorpo, "$dsgriditens", ltable.ToString)
            lcorpo = Replace(lcorpo, "ecxtextosmall", "textosmall")

            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 9 'envio e-mail
                usuariolog.id_menu_item = 112
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            Dim notificacao As New Notificacao
            arqTemp.Close()
            If notificacao.enviaMensagemEmail(lassunto, lcorpo, "central.compras@danone.com", lemail_parceiro, , MailPriority.High, True) = True Then
                messageControl.Alert("Email enviado ao parceiro com sucesso!")
            Else

                messageControl.Alert("Email ao parceiro não foi enviado com sucesso!")

            End If
        Else
            messageControl.Alert("O email não pode ser enviado pois não há nenhum email informado no cadastrado do Parceiro!")
        End If

    End Sub
End Class
