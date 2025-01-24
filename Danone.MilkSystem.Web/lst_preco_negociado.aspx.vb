Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail
Imports System.Net.Mime


Partial Class lst_preco_negociado

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia") = Me.txt_MesAno.Text()
        If txt_cd_tecnico.Text.Equals(String.Empty) Then
            ViewState.Item("id_tecnico") = "0"
        Else
            ViewState.Item("id_tecnico") = txt_cd_tecnico.Text
        End If
        ViewState.Item("st_aprovado") = Me.cbo_status.SelectedValue
        ViewState.Item("id_cluster") = Me.cbo_cluster.SelectedValue 'fran setembro/2014 fase 3

        insertData()   ' 22/08/2008

        updateData()    ' 17/02/2009 - Rls16 - Atualiza Volume Mensal e assume Preço Negociado = Preço Objetivo

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_preco_negociado.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_preco_negociado.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 35
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With img_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialogTecnico()")
            .ToolTip = "Filtrar Técnicos"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim statuspreconegociado As New StatusPrecoNegociado
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_status.DataSource = statuspreconegociado.getStatusPrecoNegociadoByFilters()
            cbo_status.DataTextField = "nm_aprovado"
            cbo_status.DataValueField = "st_aprovado"
            cbo_status.DataBind()
            cbo_status.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'fran fase 3 i
            Dim cluster As New Cluster
            cbo_cluster.DataSource = cluster.getClusterByFilters()
            cbo_cluster.DataTextField = "nm_cluster"
            cbo_cluster.DataValueField = "id_cluster"
            cbo_cluster.DataBind()
            cbo_cluster.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'fran fase 3 f

            'cbo_status.Items.Add(New ListItem("[Selecione]", "0"))
            'cbo_status.Items.Add(New ListItem("Aprovado", "1"))
            'cbo_status.Items.Add(New ListItem("Reprovado", "2"))
            'cbo_status.Items.Add(New ListItem("Em Análise", "3"))

            ViewState.Item("sortExpression") = "ds_produtor asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("preco_negociado", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("preco_negociado", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("preco_negociado", cbo_status.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("st_aprovado") = customPage.getFilterValue("preco_negociado", cbo_status.ID)
            Me.cbo_status.Text = ViewState.Item("st_aprovado").ToString()
        Else
            ViewState.Item("st_aprovado") = String.Empty
        End If


        If Not (customPage.getFilterValue("preco_negociado", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("preco_negociado", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If


        If Not (customPage.getFilterValue("preco_negociado", txt_MesAno.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("preco_negociado", txt_MesAno.ID)
            txt_MesAno.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        If Not (customPage.getFilterValue("preco_negociado", txt_cd_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_tecnico") = customPage.getFilterValue("preco_negociado", txt_cd_tecnico.ID)
            txt_cd_tecnico.Text = ViewState.Item("id_tecnico").ToString()
        Else
            ViewState.Item("id_tecnico") = String.Empty
        End If
        'fran fase 3 i
        If Not (customPage.getFilterValue("preco_negociado", cbo_cluster.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_cluster") = customPage.getFilterValue("preco_negociado", cbo_cluster.ID)
            cbo_cluster.SelectedValue = ViewState.Item("id_cluster").ToString()
        Else
            ViewState.Item("id_cluster") = String.Empty
        End If
        'fran fase 3 f

        If Not (customPage.getFilterValue("preco_negociado", lbl_nm_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_tecnico") = customPage.getFilterValue("preco_negociado", lbl_nm_tecnico.ID)
            lbl_nm_tecnico.Text = ViewState.Item("nm_tecnico").ToString()
            hf_id_tecnico.Value = ViewState.Item("id_tecnico").ToString
        Else
            ViewState.Item("nm_tecnico") = String.Empty
            hf_id_tecnico.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("preco_negociado", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("preco_negociado", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("preco_negociado")
        End If

    End Sub
    Private Sub insertData()
        Try

            Dim preconegociado As New PrecoNegociado
            preconegociado.id_tecnico = ViewState.Item("id_tecnico")
            preconegociado.dt_referencia = "01/" & ViewState.Item("dt_referencia")
            preconegociado.id_modificador = Session("id_login")
            preconegociado.insertPrecoNegociado()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Private Sub loadData()

        Try
            Dim preconegociado As New PrecoNegociado

            If Trim(ViewState.Item("id_tecnico")) <> "" Then
                preconegociado.id_tecnico = ViewState("id_tecnico").ToString
            End If
            preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'fran fase 3 i
            If Trim(ViewState.Item("id_cluster")) <> "" Then
                preconegociado.id_cluster = ViewState("id_cluster").ToString
            End If
            'fran fase 3 f

            If Trim(ViewState.Item("st_aprovado")) <> "0" Then
                preconegociado.st_aprovado = ViewState.Item("st_aprovado").ToString
            End If


            ' 17/02/2009 Rls16 - i
            'ViewState.Item("somatorio_volumeprecoobjetivo") = 0
            'ViewState.Item("somatorio_volumepreconegociado") = 0
            'ViewState.Item("somatorio_volume") = 0
            ViewState.Item("mixobj") = 0
            ViewState.Item("mixneg") = 0

            Dim nr_somatorio_volume As Decimal

            Dim dsPrecoNegociadoMix As DataSet = preconegociado.getPrecoNegociadoMix()  ' Traz os somatórios para o cálculo dos Mix's
            nr_somatorio_volume = Convert.ToDecimal(dsPrecoNegociadoMix.Tables(0).Rows(0).Item("somatoriovolume"))
            If nr_somatorio_volume > 0 Then
                ViewState.Item("mixobj") = Round(Convert.ToDecimal(dsPrecoNegociadoMix.Tables(0).Rows(0).Item("mixobj")) / nr_somatorio_volume, 2)
                ViewState.Item("mixneg") = Round(Convert.ToInt32(dsPrecoNegociadoMix.Tables(0).Rows(0).Item("mixneg")) / nr_somatorio_volume, 2)
            End If
            ' 17/02/2009 Rls16 - f



            Dim dsPrecoNegociado As DataSet = preconegociado.getPrecoNegociadoByFilters()

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
                lbl_precomedioprata.Text = "Preço Médio Negociação Gerencial:"
                lbl_precomediobronze.Text = "Preço Médio Mercado:"
                lbl_precomediocoml.Text = "Preço Médio Contrato:"

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

            Case "id_propriedade"
                ' 15/01/2009 - i
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If
                ' 15/01/2009 - f

            Case "nr_total_volume"
                If (ViewState.Item("sortExpression")) = "nr_total_volume asc" Then
                    ViewState.Item("sortExpression") = "nr_total_volume desc"
                Else
                    ViewState.Item("sortExpression") = "nr_total_volume asc"
                End If

            Case "nr_preco_base"
                If (ViewState.Item("sortExpression")) = "nr_preco_base asc" Then
                    ViewState.Item("sortExpression") = "nr_preco_base desc"
                Else
                    ViewState.Item("sortExpression") = "nr_preco_base asc"
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
                'fran fase 3
            Case "nm_cluster"
                If (ViewState.Item("sortExpression")) = "nm_cluster asc" Then
                    ViewState.Item("sortExpression") = "nm_cluster desc"
                Else
                    ViewState.Item("sortExpression") = "nm_cluster asc"
                End If

        End Select

        loadData()

    End Sub


    Private Sub carregarCamposTecnico()

        Try

            Me.txt_cd_tecnico.Text = hf_id_tecnico.Value

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                Me.lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If


            'loadData()
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try

            customPage.setFilter("preco_negociado", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("preco_negociado", cbo_status.ID, ViewState.Item("st_aprovado").ToString)
            customPage.setFilter("preco_negociado", txt_MesAno.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("preco_negociado", txt_cd_tecnico.ID, ViewState("id_tecnico").ToString)
            customPage.setFilter("preco_negociado", lbl_nm_tecnico.ID, lbl_nm_tecnico.Text)
            customPage.setFilter("preco_negociado", "PageIndex", gridResults.PageIndex.ToString())
            customPage.setFilter("preco_negociado", cbo_cluster.ID, ViewState.Item("id_cluster").ToString) 'fase 3 fran

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

    Private Sub deletePrecoNegociado(ByVal id_preco_negociado As Integer)

        Try
            Dim preconegociado As New PrecoNegociado()
            preconegociado.id_preco_negociado = id_preco_negociado
            preconegociado.id_modificador = Convert.ToInt32(Session("id_login"))
            preconegociado.deletePrecoNegociado()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    'Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
    '    saveFilters()
    '    Response.Redirect("frm_preco_negociado.aspx")
    'End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        Try
            If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

                'Se já fez a criação  da linha e esta sem valor no combo 
                Dim cbo_justificativa As DropDownList = CType(e.Row.FindControl("cbo_justificativa"), DropDownList)
                If Not (cbo_justificativa Is Nothing) Then
                    cbo_justificativa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                End If
                ViewState("label_justificativa") = Nothing 'Assume que  tem valor

            Else  ' Se não está editando

                If (e.Row.RowType <> DataControlRowType.Header _
                    And e.Row.RowType <> DataControlRowType.Footer _
                    And e.Row.RowType <> DataControlRowType.Pager) Then

                    Dim lsomatorio_volumeprecoobjetivo As Decimal
                    Dim lsomatorio_volumepreconegociado As Decimal
                    Dim lbl_preco_negociado As Label = CType(e.Row.FindControl("lbl_preco_negociado"), Label)


                    ' Volume => Coluna 2
                    ' Subtotal => coluna 7
                    ' Preco Negociado => coluna 8 (template)

                    ' Coluna Volume * Subtotal (preço objetivo mais adicionais)
                    lsomatorio_volumeprecoobjetivo = Convert.ToDecimal(e.Row.Cells(3).Text) * Convert.ToDecimal(e.Row.Cells(8).Text)

                    ' Coluna Volume * Preço Negociado
                    If Not (lbl_preco_negociado.Text.Trim.ToString.Equals(String.Empty)) Then
                        lsomatorio_volumepreconegociado = Convert.ToDecimal(e.Row.Cells(3).Text) * Convert.ToDecimal(lbl_preco_negociado.Text)
                    Else
                        lsomatorio_volumepreconegociado = 0
                    End If

                    ' 17/02/2009 Rls16 - i
                    'ViewState.Item("somatorio_volume") = Convert.ToDecimal(ViewState.Item("somatorio_volume")) + Convert.ToDecimal(e.Row.Cells(2).Text)
                    'ViewState.Item("somatorio_volumeprecoobjetivo") = Convert.ToDecimal(ViewState.Item("somatorio_volumeprecoobjetivo")) + lsomatorio_volumeprecoobjetivo
                    'ViewState.Item("somatorio_volumepreconegociado") = Convert.ToDecimal(ViewState.Item("somatorio_volumepreconegociado")) + lsomatorio_volumepreconegociado
                    ' 17/02/2009 Rls16 - f

                End If

            End If

            If (e.Row.RowType = DataControlRowType.Footer) Then

                ' 17/02/2009 Rls16 - i

                ' Calculo campos Mix Obj e Mix Neg
                'If Convert.ToInt32(ViewState.Item("somatorio_volume")) > 0 Then
                '    e.Row.Cells(6).Text = "Mix Obj "
                '    e.Row.Cells(7).Text = Round(Convert.ToInt32(ViewState.Item("somatorio_volumeprecoobjetivo")) / Convert.ToInt32(ViewState.Item("somatorio_volume")), 2)
                '    e.Row.Cells(8).Text = "Mix Neg "
                '    e.Row.Cells(9).Text = Round(Convert.ToInt32(ViewState.Item("somatorio_volumepreconegociado")) / Convert.ToInt32(ViewState.Item("somatorio_volume")), 2)
                'End If
                e.Row.Cells(7).Text = "Mix Obj "
                e.Row.Cells(8).Text = ViewState.Item("mixobj")  ' Calculado no loadData()
                e.Row.Cells(9).Text = "Mix Neg "
                e.Row.Cells(10).Text = ViewState.Item("mixneg")  ' Calculado no loadData()
                ' 17/02/2009 Rls16 - f

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try




    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub img_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_tecnico.Click
        If Not (hf_id_tecnico.Value.Trim.Equals(String.Empty)) Then
            Me.lbl_nm_tecnico.Visible = True
            carregarCamposTecnico()

        End If
    End Sub

    Protected Sub cv_tecnico_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_tecnico.ServerValidate
        Try
            Dim tecnico As New Tecnico()

            tecnico.id_tecnico = Me.txt_cd_tecnico.Text.Trim

            args.IsValid = tecnico.validarTecnico()

            If Not args.IsValid Then
                messageControl.Alert("Técnico não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
        lbl_nm_tecnico.Text = String.Empty
        lbl_nm_tecnico.Visible = False
        hf_id_tecnico.Value = String.Empty
    End Sub

    'Protected Function GetImagem(ByVal status As String) As String
    '    Dim ret As String = ""

    '    If (status = "1") Then
    '        ret = "~/img/icone_aprovado.gif"
    '    ElseIf (status = "2") Then
    '        ret = "~/img/icone_reprovado.GIF"
    '    Else
    '        ret = "~/img/icone_vazio.gif"
    '    End If

    '    Return ret
    'End Function

    Protected Sub gridResults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridResults.RowCancelingEdit
        Try

            gridResults.EditIndex = -1
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            Try
                If Not (ViewState("label_justificativa") Is Nothing) Then

                    Dim cbo_justificativa As DropDownList = CType(e.Row.FindControl("cbo_justificativa"), DropDownList)

                    Dim justificativa As New PrecoJustificativa

                    cbo_justificativa.DataSource = justificativa.getPrecoJustificativaByFilters()
                    cbo_justificativa.DataTextField = "nm_preco_justificativa"
                    cbo_justificativa.DataValueField = "id_preco_justificativa"
                    cbo_justificativa.DataBind()


                    If (ViewState("label_justificativa").ToString.Equals(String.Empty)) Then
                        cbo_justificativa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState("label_justificativa") = "SEM_VALOR" 'Assume que  esta sem valor
                    Else
                        cbo_justificativa.SelectedValue = cbo_justificativa.Items.FindByText(ViewState("label_justificativa").Trim.ToString).Value
                        ViewState("label_justificativa") = Nothing 'Assume que  tem valor
                    End If

                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub gridResults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridResults.RowEditing
        Try

            Dim lbl_justificativa As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_justificativa"), Label)
            ViewState.Item("label_justificativa") = Trim(lbl_justificativa.Text)
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

                Dim cbo_justificativa As DropDownList = CType(row.FindControl("cbo_justificativa"), DropDownList)

                preconegociado.id_preco_negociado = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)

                If Not (cbo_justificativa.SelectedValue.Trim().Equals(String.Empty)) Then
                    preconegociado.id_preco_justificativa = Convert.ToInt32(cbo_justificativa.SelectedValue)
                End If

                Dim txt_nr_preco_negociado As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_preco_negociado"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                If Not (txt_nr_preco_negociado.Text.Trim.ToString.Equals(String.Empty)) Then
                    preconegociado.nr_preco_negociado = Convert.ToDecimal(txt_nr_preco_negociado.Text)
                Else
                    preconegociado.nr_preco_negociado = 0
                End If
                preconegociado.id_modificador = Session("id_login")

                If preconegociado.nr_preco_negociado = 0 Then  ' Se limpou o preço
                    preconegociado.st_aprovado = "5" 'sem preco
                Else
                    'Fran julho/2018 dango 2018 i deve sempre aprovar
                    'If preconegociado.nr_preco_negociado = row.Cells(8).Text Then
                    '    'preconegociado.st_aprovado = "4"   ' Assume Aprovado 1.o Nivel
                    '    preconegociado.st_aprovado = "2"   ' 15/10/2008 Assume Aprovado 2.o Nivel (Se preço negociado = preço objetivo não passa pelo fluxo de aprovação - A procedure tb foi alterado)
                    'Else
                    '    preconegociado.st_aprovado = "1"   ' Pré-Aprovado
                    'End If
                    preconegociado.st_aprovado = "1" 'aguardando aprovação ficando disponive para notificador 1 nivel
                    'Fran julho/2018 dango 2018 f deve sempre aprovar
                End If


                erro = False
                'If preconegociado.nr_preco_negociado = 0 And Convert.ToDecimal(gridResults.Rows(e.RowIndex).Cells(4).Text) > 0 Then
                '    erro = True
                '    messageControl.Alert("O Preço deve ser informado!")
                'End If

                ' 18/05/2009 - Chamado 245 - Se variação for positiva (preço negociado maior que preço objetivo) deve obrigar a justificativa - Rls 17.5 - i
                '' 20/01/2008 - RLs15 Se informou Preço Negociado para Aprovação, a justificativa deve ser informada - i
                'If preconegociado.st_aprovado = "1" And cbo_justificativa.SelectedValue.Trim().Equals(String.Empty) Then  ' Se não tem justificativa
                '    erro = True
                '    messageControl.Alert("A justificativa deve ser informada!")
                'End If
                '' 20/01/2008 - RLs15 Se informou Preço Negociado para Aprovação, a justificativa deve ser informada - f

                'Fran julho/2018 dango 2018 i deve sempre aprovar e justificar
                'If (preconegociado.nr_preco_negociado > Convert.ToDecimal(row.Cells(8).Text)) And cbo_justificativa.SelectedValue.Trim().Equals(String.Empty) Then  ' Se não tem justificativa
                '    erro = True
                '    messageControl.Alert("A justificativa deve ser informada!")
                'End If
                'Fran julho/2018 dango 2018 f deve sempre aprovar
                ' 18/05/2009 - Chamado 245 - Se variação for positiva (maior que zero) deve obrigar a justificativa - Rls 17.5 - i

                If erro = False Then
                    preconegociado.updatePrecoNegociado()
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 35
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    gridResults.EditIndex = -1
                    loadData()
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        If Page.IsValid = True Then
            Try

                'Dim tecnico As New Tecnico(ViewState.Item("id_tecnico"))

                Dim notificacao As New Notificacao
                'fran dango 2018 i
                'Dim lAssunto As String = "Aprovação 1.o Nível de Preços Negociados para Produtores - Técnico " & tecnico.nm_tecnico
                'Dim lCorpo As String = "Existem preços negociados para as Propriedades do Técnico " & tecnico.nm_tecnico & " pendentes para aprovação 1.o Nível"
                Dim lAssunto As String = "Aprovação 1.o Nível de Preços Negociados para Produtores"
                Dim lCorpo As String = "Existem preços negociados para propriedades pendentes para aprovação 1.o Nível"
                'fran dango 2018 f

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 9 'ENVIO EMAIL
                usuariolog.id_menu_item = 35
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f


                'fRAN i 26/11/2009 - maracanau
                ' Parametro 3 - Preço Negociado 1.o Nível
                'If notificacao.enviaMensagemEmail(3, lAssunto, lCorpo, MailPriority.High) = True Then
                If notificacao.enviaMensagemEmail(3, lAssunto, lCorpo, MailPriority.High, , , Convert.ToInt32(ViewState.Item("id_estabelecimento"))) = True Then
                    'fRAN f 26/11/2009 - maracanau
                    messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível foi enviada aos destinatários com sucesso!")
                Else

                    messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        End If

    End Sub
    Private Sub updateData()
        Try

            'fran julho/2018 PROJETO DANGO 2018
            ' '' 17/02/2009 Rls16 - i

            ''Dim preconegociado As New PrecoNegociado
            ''Dim saldodisponivel As New SaldoDisponivel
            ''Dim nr_adic_volume As Decimal

            ''Dim li As Int32

            ''If Trim(ViewState.Item("id_tecnico")) <> "" Then
            ''    preconegociado.id_tecnico = ViewState("id_tecnico").ToString
            ''End If
            ''preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            ''preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            ''Dim dsPrecoNegociado As DataSet = preconegociado.getPrecoNegociadoTodos()  ' Traz as propriedades que não tem volume também


            ' '' Para cada Propriedade, atualiza o Volume Mensal Proporcionalizado
            ''saldodisponivel.dt_referencia = preconegociado.dt_referencia
            ''For li = 0 To dsPrecoNegociado.Tables(0).Rows.Count - 1

            ''    saldodisponivel.id_propriedade = Convert.ToInt32(dsPrecoNegociado.Tables(0).Rows(li).Item("id_propriedade"))
            ''    saldodisponivel.nr_volume_mensal = 0

            ''    preconegociado.id_propriedade = saldodisponivel.id_propriedade
            ''    preconegociado.nr_volume_mensal = saldodisponivel.getVolumeLeiteMes
            ''    preconegociado.updatePrecoNegociadoVolumeLeite()

            ''    'NOVO
            ''    If IsDBNull(dsPrecoNegociado.Tables(0).Rows(li).Item("nr_preco_negociado")) Then  ' Se ainda não assumiu o Preço Negociado 
            ''        ' Busca o adicional volume
            ''        nr_adic_volume = preconegociado.getPrecoNegociadoAdicionalVolume()
            ''        preconegociado.nr_preco_negociado = Convert.ToDecimal(dsPrecoNegociado.Tables(0).Rows(li).Item("nr_preco_objetivo")) + nr_adic_volume
            ''        preconegociado.updatePrecoNegociadoDefault()
            ''    End If
            ''Next
            ' 17/02/2009 Rls16 - f
            Dim preconegociado As New PrecoNegociado

            If Trim(ViewState.Item("id_tecnico")) <> "" Then
                preconegociado.id_tecnico = ViewState("id_tecnico").ToString
            End If
            preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            preconegociado.id_modificador = Session("id_login")

            'atualiza o volume de leite proporcionalizado
            preconegociado.updatePrecoNegociadoVolumeLeite()
            'atualiza preco negociado default (apenas para quem ainda é null)
            preconegociado.updatePrecoNegociadoDefault()

            'fran julho/2018 PROJETO DANGO 2018 f


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia") = Me.txt_MesAno.Text()
        ViewState.Item("id_tecnico") = txt_cd_tecnico.Text()
        ViewState.Item("st_aprovado") = Me.cbo_status.SelectedValue
        ViewState.Item("id_cluster") = Me.cbo_cluster.SelectedValue 'fran setembro/2014 fase 3

        insertData()

        updateData()    ' Atualiza Volume Mensal e assume Preço Negociado = Preço Objetivo

        loadData()

        'se o grid tiver mais que 65536  linhas não podemos exportar
        If gridResults.Visible = True Then
            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 8 'exporta~ção
                usuariolog.id_menu_item = 35
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Response.Redirect("frm_preco_negociado_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_tecnico=" + ViewState.Item("id_tecnico").ToString + "&id_cluster=" + ViewState.Item("id_cluster").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&st_aprovado=" + ViewState.Item("st_aprovado").ToString)
            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
            End If
        End If

    End Sub
End Class
