Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_Itens
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_itens.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim situacoes As New Situacao


            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            Dim unidadeMedida As New UnidadeMedida

            cbo_unidade_medida.DataSource = unidadeMedida.getunidade_medidaByfilters
            cbo_unidade_medida.DataTextField = "ds_unidade_medida"
            cbo_unidade_medida.DataValueField = "id_unidade_medida"
            cbo_unidade_medida.DataBind()
            cbo_unidade_medida.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim grupo_itens As New GrupoItens()
            cbo_cd_grupo.DataSource = grupo_itens.getGrupos_itensByFilters
            cbo_cd_grupo.DataTextField = "ds_grupo_itens"
            cbo_cd_grupo.DataValueField = "id_grupo_itens"
            cbo_cd_grupo.DataBind()
            cbo_cd_grupo.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim conta As New Conta()
            conta.st_clube_compra = "S"  ' 30/10/2009 - Adri
            cbo_cd_conta.DataSource = conta.getContaByFilters
            cbo_cd_conta.DataTextField = "ds_conta"
            cbo_cd_conta.DataValueField = "id_conta"
            cbo_cd_conta.DataBind()
            cbo_cd_conta.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            'fran fase 3
            Dim categoria As New CategoriaItem()
            cbo_categoria.DataSource = categoria.getCategoriaItemByFilters
            cbo_categoria.DataTextField = "nm_categoria_item"
            cbo_categoria.DataValueField = "id_categoria_item"
            cbo_categoria.DataBind()
            cbo_categoria.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            'fran fase 3
            Dim canal As New Canal
            cbo_canal.DataSource = canal.getCanalByFilters
            cbo_canal.DataTextField = "nm_canal"
            cbo_canal.DataValueField = "id_canal"
            cbo_canal.DataBind()
            cbo_canal.SelectedValue = 1 'Defaul Canal Direto


            If Not (Request("id_itens") Is Nothing) Then
                ViewState.Item("id_itens") = Request("id_itens")
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_item As Int32 = Convert.ToInt32(ViewState.Item("id_itens"))
            Dim item As New Item(id_item)

            ' 19/01/2010 - Chamado 597 - i
            If Not (ViewState.Item("id_itens") Is Nothing) Then     ' Não permite alteração do Código do Grupo
                txt_cd_item.Enabled = False
            Else
                txt_cd_item.Enabled = True
            End If
            ' 19/01/2010 - Chamado 597 - f

            txt_cd_item_sap.Text = item.cd_item_sap 'fran 17/04/2012 i themis

            txt_cd_item.Text = item.cd_item
            txt_nm_item.Text = item.nm_item
            cbo_unidade_medida.SelectedValue = item.id_unidade_medida
            If item.id_grupo_itens > 0 Then 'fran chamado 841 17/05/2010
                cbo_cd_grupo.SelectedValue = item.id_grupo_itens
            End If
            If item.id_conta > 0 Then
                cbo_cd_conta.SelectedValue = item.id_conta
            Else
                cbo_cd_conta.SelectedValue = String.Empty
            End If
            txt_classificacao_fiscal.Text = item.cd_classificacao_fiscal
            txt_cd_deposito.Text = item.cd_deposito

            If item.st_central_compras = "S" Then
                rb_central_compras_sim.Checked = True
                rfv_cd_conta.Enabled = True
                rfv_cd_grupo.Enabled = True
            Else
                rb_central_compras_nao.Checked = True
                rfv_cd_conta.Enabled = False
                rfv_cd_grupo.Enabled = False
            End If

            If (item.id_situacao > 0) Then
                cbo_situacao.SelectedValue = item.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            'fran fase 3 i
            If item.id_categoria_item > 0 Then
                cbo_categoria.SelectedValue = item.id_categoria_item.ToString
            End If

            If item.id_canal > 0 Then
                cbo_canal.SelectedValue = item.id_canal.ToString
            End If
            'fran fase 3 f

            txt_ds_descricao.Text = item.ds_descricao_item

            'fran 8/12/2020 i vizir
            cbo_visualizar_item_web.SelectedValue = item.st_visualizar_web
            cbo_importar_pedido.SelectedValue = item.st_importacao_pedido

            lbl_modificador.Text = item.nm_modificador.ToString()  ' 04/11/2009 - Adri
            lbl_dt_modificacao.Text = item.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try
            Dim item As New Item()

            item.cd_item = txt_cd_item.Text
            item.nm_item = txt_nm_item.Text
            item.cd_item_sap = txt_cd_item_sap.Text 'fran 16/04/2012
            If Not cbo_cd_conta.SelectedValue = "" Then
                item.id_conta = Convert.ToInt32(cbo_cd_conta.SelectedValue)
            End If
            If Not cbo_unidade_medida.SelectedValue = "" Then
                item.id_unidade_medida = Convert.ToInt32(cbo_unidade_medida.SelectedValue)
            End If
            If Not cbo_cd_grupo.SelectedValue = "" Then
                item.id_grupo_itens = Convert.ToInt32(cbo_cd_grupo.SelectedValue)
            End If
            item.cd_classificacao_fiscal = txt_classificacao_fiscal.Text
            item.cd_deposito = txt_cd_deposito.Text

            If rb_central_compras_sim.Checked = True Then
                item.st_central_compras = "S"
            Else
                item.st_central_compras = "N"
            End If

            ' 04/11/2009 - Adri (padrão de update) - i
            'If Not (lbl_modificador.Text.Trim().Equals(String.Empty)) Then
            '    item.id_modificador = Convert.ToInt32(lbl_modificador.Text)
            'End If
            item.id_modificador = Session("id_login")
            ' 04/11/2009 - Adri - f

            If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                item.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
            End If

            'fran fase 3 i
            If Not (cbo_categoria.SelectedValue.Trim().Equals(String.Empty)) Then
                item.id_categoria_item = Convert.ToInt32(cbo_categoria.SelectedValue)
            End If

            If Not (cbo_canal.SelectedValue.Trim().Equals(String.Empty)) Then
                item.id_canal = Convert.ToInt32(cbo_canal.SelectedValue)
            End If
            'fran fase 3 f

            item.ds_descricao_item = txt_ds_descricao.Text
            item.st_visualizar_web = cbo_visualizar_item_web.SelectedValue
            item.st_importacao_pedido = cbo_importar_pedido.SelectedValue

            If Not (ViewState.Item("id_itens") Is Nothing) Then
                item.id_item = Convert.ToInt32(ViewState.Item("id_itens"))
                item.updateitem()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'altercaço
                usuariolog.id_menu_item = 90
                usuariolog.id_nr_processo = ViewState.Item("id_itens")
                usuariolog.nm_nr_processo = item.cd_item

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango
                messageControl.Alert("Registro alterado com sucesso.")
            Else
                ViewState.Item("id_itens") = item.insertitem
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'insert
                usuariolog.id_menu_item = 90
                usuariolog.id_nr_processo = ViewState.Item("id_itens")
                usuariolog.nm_nr_processo = item.cd_item
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango
                messageControl.Alert("Registro inserido com sucesso.")

            End If

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_itens.aspx?")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_itens.aspx")
    End Sub
    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub
    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_itens.aspx")  ' Adri
    End Sub

    Protected Sub lk_parceiros_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_parceiros.Click
        Response.Redirect("frm_central_item_parceiro.aspx?id_item=" & ViewState.Item("id_itens").ToString)  ' 05/11/2009 Adri
    End Sub

    Protected Sub rb_central_compras_sim_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_central_compras_sim.CheckedChanged
        'Fran chamado 841 17/05/2010
        If rb_central_compras_sim.Checked = True Then
            rfv_cd_conta.Enabled = True
            rfv_cd_grupo.Enabled = True
        Else
            rfv_cd_conta.Enabled = False
            rfv_cd_grupo.Enabled = False
        End If

    End Sub

    Protected Sub rb_central_compras_nao_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rb_central_compras_nao.CheckedChanged
        'Fran chamado 841 17/05/2010
        If rb_central_compras_nao.Checked = True Then
            rfv_cd_conta.Enabled = False
            rfv_cd_grupo.Enabled = False
        Else
            rfv_cd_conta.Enabled = True
            rfv_cd_grupo.Enabled = True
        End If

    End Sub
End Class
