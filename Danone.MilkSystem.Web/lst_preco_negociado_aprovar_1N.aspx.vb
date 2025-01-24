Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.Math
Partial Class lst_preco_negociado_aprovar_1N

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia") = Me.txt_MesAno.Text()
        ViewState.Item("id_cluster") = Me.cbo_cluster.SelectedValue 'fran setembro/2014 fase 3

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_preco_negociado_aprovar_1N.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_preco_negociado_aprovar_1N.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 38
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim statuspreconegociado As New StatusPrecoNegociado

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'fran fase 3 i
            Dim cluster As New Cluster
            cbo_cluster.DataSource = cluster.getClusterByFilters()
            cbo_cluster.DataTextField = "nm_cluster"
            cbo_cluster.DataValueField = "id_cluster"
            cbo_cluster.DataBind()
            cbo_cluster.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'fran fase 3 f

            ViewState.Item("sortExpression") = "ds_produtor asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("preco_negociado_aprovar", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("preco_negociado_aprovar", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If



        If Not (customPage.getFilterValue("preco_negociado_aprovar", txt_MesAno.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("preco_negociado_aprovar", txt_MesAno.ID)
            txt_MesAno.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If
        'fran fase 3 i
        If Not (customPage.getFilterValue("preco_negociado_aprovar", cbo_cluster.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_cluster") = customPage.getFilterValue("preco_negociado_aprovar", cbo_cluster.ID)
            cbo_cluster.SelectedValue = ViewState.Item("id_cluster").ToString()
        Else
            ViewState.Item("id_cluster") = String.Empty
        End If
        'fran fase 3 f


        If Not (customPage.getFilterValue("preco_negociado_aprovar", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("preco_negociado_aprovar", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("preco_negociado_aprovar")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim preconegociado As New PrecoNegociado

            preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'fran fase 3 i
            If Trim(ViewState.Item("id_cluster")) <> "" Then
                preconegociado.id_cluster = ViewState("id_cluster").ToString
            End If
            'fran fase 3 f


            Me.lk_aprovar.Enabled = True
            Me.lk_reprovar.Enabled = True
            Me.lk_email.Enabled = True

            ' 30/11/2008 (não exibir itens aprovador 2.o Nível para a tela de Aprovação 1.o Nível)
            'Dim dsPrecoNegociado As DataSet = preconegociado.getPrecoNegociadoByFilters()
            Dim dsPrecoNegociado As DataSet = preconegociado.getPrecoNegociado1NByFilters()

            If (dsPrecoNegociado.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPrecoNegociado.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

                'fran fase 3 set/2014 i
                'Busaca os preços medios negociados para cada grupo de cluster
                'Formula: SOMATORIO (VOLUME X NEGOCIADO) / SOMA(VOLUMES)
                Dim dsPrecoMedio As DataSet = preconegociado.getPrecoNegociadoMedioCluster()
                Dim row As DataRow
                Dim nr_total_volume_mensal As Int32 = 0
                Dim nr_total_volume_preco_negociado As Decimal = 0

                lbl_precomediototal.Visible = True
                lbl_precomedioouro.Visible = True
                lbl_precomedioprata.Visible = True
                lbl_precomediobronze.Visible = True
                lbl_precomediocoml.Visible = True
                lbl_preco_medio_cluster_total.Visible = True
                lbl_preco_medio_cluster_ouro.Visible = True
                lbl_preco_medio_cluster_prata.Visible = True
                lbl_preco_medio_cluster_bronze.Visible = True
                lbl_preco_medio_cluster_coml.Visible = True
                lbl_preco_medio_cluster_total.Text = String.Empty
                lbl_preco_medio_cluster_ouro.Text = String.Empty
                lbl_preco_medio_cluster_prata.Text = String.Empty
                lbl_preco_medio_cluster_bronze.Text = String.Empty
                lbl_preco_medio_cluster_coml.Text = String.Empty
                lbl_precomedioouro.Text = "Preço Médio CPM:"
                lbl_precomedioprata.Visible = "Preço Médio Negociação Gerencial:"
                lbl_precomediobronze.Visible = "Preço Médio Mercado:"
                lbl_precomediocoml.Visible = "Preço Médio Contrato:"

                If (dsPrecoMedio.Tables(0).Rows.Count > 0) Then
                    For Each row In dsPrecoMedio.Tables(0).Rows
                        Select Case row.Item("id_cluster")
                            Case 1 'Se Cluster OURO
                                lbl_preco_medio_cluster_ouro.Text = Round(row.Item("nr_preco_medio"), 4)
                                nr_total_volume_mensal = nr_total_volume_mensal + row.Item("nr_volume_mensal")
                                nr_total_volume_preco_negociado = nr_total_volume_preco_negociado + CDec(row.Item("nr_volume_preco_negociado"))
                                'Case 2 'Se CLUSTER PRATA
                                '    lbl_preco_medio_cluster_prata.Text = Round(row.Item("nr_preco_medio"), 4)
                                '    nr_total_volume_mensal = nr_total_volume_mensal + row.Item("nr_volume_mensal")
                                '    nr_total_volume_preco_negociado = nr_total_volume_preco_negociado + CDec(row.Item("nr_volume_preco_negociado"))
                                'Case 3 'Se CLUSTER Bronze
                                '    lbl_preco_medio_cluster_bronze.Text = Round(row.Item("nr_preco_medio"), 4)
                                '    nr_total_volume_mensal = nr_total_volume_mensal + row.Item("nr_volume_mensal")
                                '    nr_total_volume_preco_negociado = nr_total_volume_preco_negociado + CDec(row.Item("nr_volume_preco_negociado"))
                                'Case 4 'Se CLUSTER Comercial
                                '    lbl_preco_medio_cluster_coml.Text = Round(row.Item("nr_preco_medio"), 4)
                                '    nr_total_volume_mensal = nr_total_volume_mensal + row.Item("nr_volume_mensal")
                                '    nr_total_volume_preco_negociado = nr_total_volume_preco_negociado + CDec(row.Item("nr_volume_preco_negociado"))
                            Case 5 'Se CLUSTER PRATA

                                lbl_preco_medio_cluster_prata.Text = Round(row.Item("nr_preco_medio"), 4)
                                nr_total_volume_mensal = nr_total_volume_mensal + row.Item("nr_volume_mensal")
                                nr_total_volume_preco_negociado = nr_total_volume_preco_negociado + CDec(row.Item("nr_volume_preco_negociado"))
                            Case 6 'Se CLUSTER Bronze
                                lbl_preco_medio_cluster_bronze.Text = Round(row.Item("nr_preco_medio"), 4)
                                nr_total_volume_mensal = nr_total_volume_mensal + row.Item("nr_volume_mensal")
                                nr_total_volume_preco_negociado = nr_total_volume_preco_negociado + CDec(row.Item("nr_volume_preco_negociado"))
                            Case 7 'Se CLUSTER Comercial
                                lbl_preco_medio_cluster_coml.Text = Round(row.Item("nr_preco_medio"), 4)
                                nr_total_volume_mensal = nr_total_volume_mensal + row.Item("nr_volume_mensal")
                                nr_total_volume_preco_negociado = nr_total_volume_preco_negociado + CDec(row.Item("nr_volume_preco_negociado"))
                        End Select
                    Next

                    lbl_preco_medio_cluster_total.Text = Round(CDec(nr_total_volume_preco_negociado / nr_total_volume_mensal), 4)
                End If
                'fran fase 3 set/2014 f

            Else
                lbl_precomediototal.Visible = False
                lbl_precomedioouro.Visible = False
                lbl_precomedioprata.Visible = False
                lbl_precomediobronze.Visible = False
                lbl_precomediocoml.Visible = False
                lbl_preco_medio_cluster_total.Visible = False
                lbl_preco_medio_cluster_ouro.Visible = False
                lbl_preco_medio_cluster_prata.Visible = False
                lbl_preco_medio_cluster_bronze.Visible = False
                lbl_preco_medio_cluster_coml.Visible = False
                lbl_preco_medio_cluster_total.Text = String.Empty
                lbl_preco_medio_cluster_ouro.Text = String.Empty
                lbl_preco_medio_cluster_prata.Text = String.Empty
                lbl_preco_medio_cluster_bronze.Text = String.Empty
                lbl_preco_medio_cluster_coml.Text = String.Empty

                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        saveCheckBox()
        loadData()

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "ds_produtor"
                If (ViewState.Item("sortExpression")) = "ds_produtor asc" Then
                    ViewState.Item("sortExpression") = "ds_produtor desc"
                Else
                    ViewState.Item("sortExpression") = "ds_produtor asc"
                End If

            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If

            Case "nm_tecnico"
                If (ViewState.Item("sortExpression")) = "nm_tecnico asc" Then
                    ViewState.Item("sortExpression") = "nm_tecnico desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tecnico asc"
                End If

            Case "nr_total_volume"
                If (ViewState.Item("sortExpression")) = "nr_total_volume asc" Then
                    ViewState.Item("sortExpression") = "nr_total_volume desc"
                Else
                    ViewState.Item("sortExpression") = "nr_total_volume asc"
                End If

            Case "nr_preco_mes_anterior"
                If (ViewState.Item("sortExpression")) = "nr_preco_mes_anterior asc" Then
                    ViewState.Item("sortExpression") = "nr_preco_mes_anterior desc"
                Else
                    ViewState.Item("sortExpression") = "nr_preco_mes_anterior asc"
                End If

            Case "nr_adic_regiao"
                If (ViewState.Item("sortExpression")) = "nr_adic_regiao asc" Then
                    ViewState.Item("sortExpression") = "nr_adic_regiao desc"
                Else
                    ViewState.Item("sortExpression") = "nr_adic_regiao asc"
                End If

            Case "nr_adicional_mercado"
                If (ViewState.Item("sortExpression")) = "nr_adicional_mercado asc" Then
                    ViewState.Item("sortExpression") = "nr_adicional_mercado desc"
                Else
                    ViewState.Item("sortExpression") = "nr_adicional_mercado asc"
                End If

            Case "nr_adic_volume"
                If (ViewState.Item("sortExpression")) = "nr_adic_volume asc" Then
                    ViewState.Item("sortExpression") = "nr_adic_volume desc"
                Else
                    ViewState.Item("sortExpression") = "nr_adic_volume asc"
                End If

            Case "subtotal"
                If (ViewState.Item("sortExpression")) = "subtotal asc" Then
                    ViewState.Item("sortExpression") = "subtotal desc"
                Else
                    ViewState.Item("sortExpression") = "subtotal asc"
                End If

            Case "variacao"
                If (ViewState.Item("sortExpression")) = "variacao asc" Then
                    ViewState.Item("sortExpression") = "variacao desc"
                Else
                    ViewState.Item("sortExpression") = "variacao asc"
                End If

            Case "nr_preco_negociado"
                If (ViewState.Item("sortExpression")) = "nr_preco_negociado asc" Then
                    ViewState.Item("sortExpression") = "nr_preco_negociado desc"
                Else
                    ViewState.Item("sortExpression") = "nr_preco_negociado asc"
                End If

            Case "nr_preco_negociado_aprovado"
                If (ViewState.Item("sortExpression")) = "nr_preco_negociado_aprovado asc" Then
                    ViewState.Item("sortExpression") = "nr_preco_negociado_aprovado desc"
                Else
                    ViewState.Item("sortExpression") = "nr_preco_negociado_aprovado asc"
                End If

            Case "st_aprovado"
                If (ViewState.Item("sortExpression")) = "st_aprovado asc" Then
                    ViewState.Item("sortExpression") = "st_aprovado desc"
                Else
                    ViewState.Item("sortExpression") = "st_aprovado asc"
                End If

            Case "nm_preco_justificativa"
                If (ViewState.Item("sortExpression")) = "nm_preco_justificativa asc" Then
                    ViewState.Item("sortExpression") = "nm_preco_justificativa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_preco_justificativa asc"
                End If

            Case "nm_aprovado"
                If (ViewState.Item("sortExpression")) = "nm_aprovado asc" Then
                    ViewState.Item("sortExpression") = "nm_aprovado desc"
                Else
                    ViewState.Item("sortExpression") = "nm_aprovado asc"
                End If

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("preco_negociado_aprovar", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("preco_negociado_aprovar", txt_MesAno.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("preco_negociado_aprovar", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.Trim.ToString
            Case "Edit", "Editar", "Cancel", "Cancelar", "Update"
                Return
        End Select

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


    Protected Sub lk_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_aprovar.Click
        Try
            Dim preconegociado As New PrecoNegociado

            If saveCheckBox() = True Then

                'Filtro
                preconegociado.id_estabelecimento = ViewState.Item("id_estabelecimento")  ' 11/09/2008
                preconegociado.dt_referencia = String.Concat("01/" & ViewState.Item("dt_referencia").ToString)
                If Trim(ViewState.Item("id_cluster")) <> "" Then
                    preconegociado.id_cluster = ViewState("id_cluster").ToString
                End If

                'Dados para o Update
                preconegociado.st_aprovado = "4"   '  Aprovado 1.o Nível
                preconegociado.id_modificador = Session("id_login")

                preconegociado.updatePrecoNegociadoAprovarSelecionados()
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 38
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                loadData()

                messageControl.Alert("Aprovação 1.o Nível concluída com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para a aprovação. Por favor selecione alguma propriedade.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridResults.RowCancelingEdit
        Try

            gridResults.EditIndex = -1
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridResults.RowEditing
        Try

            gridResults.EditIndex = e.NewEditIndex
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridResults.RowUpdating
        'Capturar valores
        Dim row As GridViewRow = gridResults.Rows(e.RowIndex)
        Try

            If (Not (row) Is Nothing) Then

                Dim preconegociado As New PrecoNegociado
                Dim erro As Boolean


                preconegociado.id_preco_negociado = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)

                Dim txt_nr_preco_negociado As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_preco_negociado"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                If Not (txt_nr_preco_negociado.Text.Trim.ToString.Equals(String.Empty)) Then
                    preconegociado.nr_preco_negociado = Convert.ToDecimal(txt_nr_preco_negociado.Text)
                Else
                    preconegociado.nr_preco_negociado = 0
                End If
                preconegociado.id_modificador = Session("id_login")


                erro = False
                'If preconegociado.nr_preco_negociado = 0 And Convert.ToDecimal(gridResults.Rows(e.RowIndex).Cells(4).Text) > 0 Then
                '    erro = True
                '    messageControl.Alert("O Preço deve ser informado!")
                'End If

                If erro = False Then
                    preconegociado.updatePrecoNegociadoAprovador()
                    gridResults.EditIndex = -1
                    loadData()
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                ch.Checked = ck_header.Checked
            Next

            ' 30/11/2008  -  Seleciona tudo o que o botão Pesquisar trouxe - i
            Dim preconegociado As New PrecoNegociado
            preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            'fran dango 2018 i
            If Trim(ViewState.Item("id_cluster")) <> "" Then
                preconegociado.id_cluster = ViewState("id_cluster").ToString
            End If
            'fran dango 2018 f

            If ck_header.Checked = True Then
                preconegociado.st_selecao = "1"
            Else
                preconegociado.st_selecao = "0"
            End If
            preconegociado.updatePrecoNegociadoTodos1N()
            ' 30/11/2008  -  Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function saveCheckBox() As Boolean

        Try

            Dim li As Integer

            For li = 0 To gridResults.Rows.Count - 1
                Dim preconegociado As New PrecoNegociado()
                preconegociado.id_preco_negociado = gridResults.DataKeys(li).Value.ToString
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    preconegociado.st_selecao = "1"
                    saveCheckBox = True     ' Indica que tem item selecionado
                Else
                    preconegociado.st_selecao = "0"
                End If
                preconegociado.updatePrecoNegociadoSelecao()
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub lk_reprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_reprovar.Click
        Try
            Dim preconegociado As New PrecoNegociado

            If saveCheckBox() = True Then

                ' Dados do filtro
                preconegociado.id_estabelecimento = ViewState.Item("id_estabelecimento")  ' 11/09/2008
                preconegociado.dt_referencia = String.Concat("01/" & ViewState.Item("dt_referencia").ToString)
                'fran dango 2018 i
                If Trim(ViewState.Item("id_cluster")) <> "" Then
                    preconegociado.id_cluster = ViewState("id_cluster").ToString
                End If
                'fran dango 2018 f

                'Dados para o update
                preconegociado.st_aprovado = "3"   '  Reprovado
                preconegociado.id_modificador = Session("id_login")

                preconegociado.updatePrecoNegociadoAprovarSelecionados()
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 38
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 


                loadData()

                messageControl.Alert("Itens reprovados com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione alguma propriedade.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        Try
            If Page.IsValid = True Then
                Try

                    Dim notificacao As New Notificacao
                    Dim lAssunto As String = "Aprovação 2.o Nível de Preços Negociados para Produtores "
                    Dim lCorpo As String = "Existem preços negociados para Produtores aprovados em 1.o Nível pendentes para aprovação 2.o Nível."

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 9 'ENVIO EMAIL
                    usuariolog.id_menu_item = 38
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f

                    'fran 26/11/2009 i maracanau chamado 518
                    ' Parametro 4 - Preço Negociado 2.o Nível
                    'If notificacao.enviaMensagemEmail(4, lAssunto, lCorpo, MailPriority.High) = True Then
                    If notificacao.enviaMensagemEmail(4, lAssunto, lCorpo, MailPriority.High, , , Convert.ToInt32(ViewState.Item("id_estabelecimento"))) = True Then
                        'fran 26/11/2009 f maracanau chamado 518
                        messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível foi enviada aos destinatários com sucesso!")
                    Else

                        messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")

                    End If

                Catch ex As Exception
                    messageControl.Alert(ex.Message)
                End Try


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class
