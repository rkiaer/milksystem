Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail

Partial Class lst_adiantamento_solicitar

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("dt_referencia") = Me.txt_MesAno.Text()
        'fran nov/2014 fase 3 melhoria i
        If txt_cd_tecnico.Text.Equals(String.Empty) Then
            ViewState.Item("id_tecnico") = 0

        Else
            'fran nov/2014 fase 3 melhoria f
            ViewState.Item("id_tecnico") = txt_cd_tecnico.Text()
        End If

        'ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue  ' 02/12/2009 - Chamado 522 Maracanau
        ViewState.Item("st_aprovado") = Me.cbo_status.SelectedValue


        '02/12/2009 - Chamado 522 - Maracanau - i
        grdPropriedade.Visible = True
        Me.btn_adicionar_propriedade.Visible = True

        Dim dsPropriedade As New DataTable
        dsPropriedade.Rows.Clear()
        dsPropriedade.Columns.Add("propriedade")
        dsPropriedade.Columns.Add("valoradto")
        dsPropriedade.Columns.Add("justificativa")
        dsPropriedade.Columns.Add("portador")

        Dim dr As DataRow

        dr = dsPropriedade.NewRow()
        dr.Item(0) = String.Empty
        dr.Item(1) = String.Empty

        dsPropriedade.Rows.InsertAt(dr, 0)
        grdPropriedade.Visible = True
        grdPropriedade.DataSource = Helper.getDataView(dsPropriedade, "")
        grdPropriedade.DataBind()

        ' Para grid com todas as Propriedades do Técnico
        ViewState.Item("sortExpression") = "ds_produtor asc"
        '02/12/2009 - Chamado 522 - Maracanau - f



        insertData()

        updateData()    ' Atualiza Volume Mensal, Valor Disponível, Valor de Descontos

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_adiantamento_solicitar.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_adiantamento_solicitar.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 40
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

            ' 02/12/2009 - Chamado 522 Maracanau - i
            'Dim status As New Situacao

            'cbo_situacao.DataSource = status.getSituacoesByFilters()
            'cbo_situacao.DataTextField = "nm_situacao"
            'cbo_situacao.DataValueField = "id_situacao"
            'cbo_situacao.DataBind()
            'cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))
            ' 02/12/2009 - Chamado 522 Maracanau - f

            cbo_status.Items.Add(New ListItem("[Selecione]", "0"))
            cbo_status.Items.Add(New ListItem("Pré-Aprovado", "1"))
            cbo_status.Items.Add(New ListItem("Aprovado", "2"))
            cbo_status.Items.Add(New ListItem("Reprovado", "3"))
            'cbo_status.Items.Add(New ListItem("Ultrapassou", "4"))


            loadFilters()

            ''01/12/2009 - Chamado 522 - Maracanau - i
            'If Not (Request("novo") Is Nothing) Then
            '    loadData()
            'End If
            ''01/12/2009 - Chamado 522 - Maracanau - i

            ''02/12/2009 - Chamado 522 - Maracanau - i
            'grdPropriedade.Visible = True

            'Dim dsPropriedade As New DataTable
            'dsPropriedade.Rows.Clear()
            'dsPropriedade.Columns.Add("propriedade")
            'dsPropriedade.Columns.Add("valoradto")
            'dsPropriedade.Columns.Add("justificativa")
            'dsPropriedade.Columns.Add("portador")

            'Dim dr As DataRow

            'dr = dsPropriedade.NewRow()
            'dr.Item(0) = String.Empty
            'dr.Item(1) = String.Empty

            'dsPropriedade.Rows.InsertAt(dr, 0)
            'grdPropriedade.Visible = True
            'grdPropriedade.DataSource = Helper.getDataView(dsPropriedade, ViewState.Item("sortExpression"))
            'grdPropriedade.DataBind()

            '' Para grid com todas as Propriedades do Técnico
            'ViewState.Item("sortExpression") = "ds_produtor asc"
            ''02/12/2009 - Chamado 522 - Maracanau - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("adiantamento_solicitar", cbo_status.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("st_aprovado") = customPage.getFilterValue("adiantamento_solicitar", cbo_status.ID)
            Me.cbo_status.Text = ViewState.Item("st_aprovado").ToString()
        Else
            ViewState.Item("st_aprovado") = String.Empty
        End If

        ' 02/12/2009 - Chamado 522 Maracanau - 
        'If Not (customPage.getFilterValue("adiantamento_solicitar", cbo_situacao.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("id_situacao") = customPage.getFilterValue("adiantamento_solicitar", cbo_situacao.ID)
        '    cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        'Else
        '    ViewState.Item("id_situacao") = String.Empty
        'End If
        ' 02/12/2009 - Chamado 522 Maracanau - f

        If Not (customPage.getFilterValue("adiantamento_solicitar", txt_MesAno.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("adiantamento_solicitar", txt_MesAno.ID)
            txt_MesAno.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        If Not (customPage.getFilterValue("adiantamento_solicitar", txt_cd_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_tecnico") = customPage.getFilterValue("adiantamento_solicitar", txt_cd_tecnico.ID)
            txt_cd_tecnico.Text = ViewState.Item("id_tecnico").ToString()
        Else
            ViewState.Item("id_tecnico") = String.Empty
        End If

        If Not (customPage.getFilterValue("adiantamento_solicitar", lbl_nm_tecnico.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_tecnico") = customPage.getFilterValue("adiantamento_solicitar", lbl_nm_tecnico.ID)
            lbl_nm_tecnico.Text = ViewState.Item("nm_tecnico").ToString()
            hf_id_tecnico.Value = ViewState.Item("id_tecnico").ToString
        Else
            ViewState.Item("nm_tecnico") = String.Empty
            hf_id_tecnico.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("adiantamento_solicitar", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("adiantamento_solicitar", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("adiantamento_solicitar")
        End If

    End Sub
    Private Sub insertData()
        Try

            Dim adiantamento As New Adiantamento
            adiantamento.id_tecnico = ViewState.Item("id_tecnico")
            adiantamento.dt_referencia = "01/" & ViewState.Item("dt_referencia")
            adiantamento.insertAdiantamento()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Private Sub loadData()

        Try
            Dim adiantamento As New Adiantamento

            If Trim(ViewState.Item("id_tecnico")) <> "" Then
                adiantamento.id_tecnico = ViewState("id_tecnico").ToString
            End If
            'adiantamento.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())   ' 02/12/2009 - Chamado 522 Maracanau
            If Trim(ViewState.Item("st_aprovado")) <> "0" Then
                adiantamento.st_aprovado = ViewState.Item("st_aprovado").ToString
            End If
            adiantamento.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)

            lk_email.Enabled = True

            Dim dsAdiantamento As DataSet = adiantamento.getAdiantamentoByFilters()

            If (dsAdiantamento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsAdiantamento.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            '' 01/12/2009 - Chamado 522 - Maracanau - i 
            'Me.hl_novo.NavigateUrl = String.Format("frm_solicitar_adiantamento_novo.aspx?dt_referencia={0}", Me.txt_MesAno.Text) & String.Format("&id_tecnico={0}", Me.txt_cd_tecnico.Text)
            'Me.hl_novo.Enabled = True
            '' 01/12/2009 - Chamado 522 - Maracanau - f 

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub updateData()
        Try

            ' 22/07/2008 - Release 1 - i
            'Dim adiantamento As New Adiantamento

            'adiantamento.dt_referencia = "01/" & ViewState.Item("dt_referencia")
            'adiantamento.id_tecnico = ViewState.Item("id_tecnico")

            'adiantamento.updateAdiantamentoVolumeLeite()

            'adiantamento.updateAdiantamentoDescontos()

            'adiantamento.updateAdiantamentoValorDisponivel()


            Dim adiantamento As New Adiantamento
            Dim saldodisponivel As New SaldoDisponivel
            Dim pedidosabertos As New Pedido 'fran fase 2 melhoria
            Dim li As Int16

            adiantamento.id_tecnico = ViewState("id_tecnico").ToString
            adiantamento.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)

            ' 17/02/2009 Rls16 - i
            'Dim dsAdiantamento As DataSet = adiantamento.getAdiantamentoByFilters()
            Dim dsAdiantamento As DataSet = adiantamento.getAdiantamentoTodos()  ' Traz as propriedades sem volume também
            ' 17/02/2009 Rls16 - f

            ' Para cada Propriedade, atualiza o saldo disponível
            saldodisponivel.dt_referencia = adiantamento.dt_referencia
            For li = 0 To dsAdiantamento.Tables(0).Rows.Count - 1

                saldodisponivel.nr_volume_mensal = 0
                saldodisponivel.nr_valor_descontos = 0

                saldodisponivel.id_propriedade = Convert.ToInt32(dsAdiantamento.Tables(0).Rows(li).Item("id_propriedade"))
                adiantamento.nr_valor_disponivel = saldodisponivel.getSaldoDisponivel()

                adiantamento.id_propriedade = Convert.ToInt32(dsAdiantamento.Tables(0).Rows(li).Item("id_propriedade"))

                ' Adri 25/11/2009 - Chamado 499 - Novas colunas para adiantamento - i
                'adiantamento.updateAdiantamentoValorDisponivel()

                'adiantamento.nr_volume_mensal = saldodisponivel.nr_volume_mensal
                'adiantamento.updateAdiantamentoVolumeLeite()

                'adiantamento.nr_valor_descontos = saldodisponivel.nr_valor_descontos
                'adiantamento.updateAdiantamentoDescontos()
                'fran fase 2 melhoria i
                pedidosabertos.id_propriedade = adiantamento.id_propriedade
                adiantamento.nr_valor_pedidos_abertos = pedidosabertos.getTotalPedidosAbertos
                'fran fase 2 melhoria f

                 ' Atualiza as colunas nr_valor_disponivel, nr_volume_mensal, nr_valor_descontos, nr_valor_descontos_sem_adto
                adiantamento.nr_volume_mensal = saldodisponivel.nr_volume_mensal
                adiantamento.nr_valor_descontos = saldodisponivel.nr_valor_descontos
                adiantamento.nr_valor_descontos_sem_adto = saldodisponivel.nr_valor_descontos_sem_adto ' NOVO
                adiantamento.nr_valor_mensal = saldodisponivel.nr_valor_faturamento  ' NOVO
                adiantamento.updateAdiantamentoValorDisponivelAnalitico()

                ' Adri 25/11/2009 - Chamado 499 - Novas colunas para adiantamento - f

            Next


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
                ' 15/01/2009 - i

            Case "nr_percentual_adto"
                If (ViewState.Item("sortExpression")) = "nr_percentual_adto asc" Then
                    ViewState.Item("sortExpression") = "nr_percentual_adto desc"
                Else
                    ViewState.Item("sortExpression") = "nr_percentual_adto asc"
                End If

            Case "nr_valor_adto"
                If (ViewState.Item("sortExpression")) = "nr_valor_adto asc" Then
                    ViewState.Item("sortExpression") = "nr_valor_adto desc"
                Else
                    ViewState.Item("sortExpression") = "nr_valor_adto asc"
                End If

            Case "nr_volume_mensal"
                If (ViewState.Item("sortExpression")) = "nr_volume_mensal asc" Then
                    ViewState.Item("sortExpression") = "nr_volume_mensal desc"
                Else
                    ViewState.Item("sortExpression") = "nr_volume_mensal asc"
                End If


            Case "st_aprovado"
                If (ViewState.Item("sortExpression")) = "st_aprovado asc" Then
                    ViewState.Item("sortExpression") = "st_aprovado desc"
                Else
                    ViewState.Item("sortExpression") = "st_aprovado asc"
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

            customPage.setFilter("adiantamento_solicitar", cbo_status.ID, ViewState.Item("st_aprovado").ToString)
            'customPage.setFilter("adiantamento_solicitar", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)  ' 02/12/2009 - Chamado 522 Maracanau
            customPage.setFilter("adiantamento_solicitar", txt_MesAno.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("adiantamento_solicitar", txt_cd_tecnico.ID, ViewState("id_tecnico").ToString)
            customPage.setFilter("adiantamento_solicitar", lbl_nm_tecnico.ID, lbl_nm_tecnico.Text)
            customPage.setFilter("adiantamento_solicitar", "PageIndex", gridResults.PageIndex.ToString())

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

        'hl_novo.Enabled = False  ' Adri 01/12/2009 - Chamado 522 Maracanau

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

            '' Adri 01/12/2009 - Chamado 522 Maracanau - i
            'If ViewState.Item("incluirlinha") = "S" And e.NewEditIndex = 0 Then
            '    ViewState.Item("incluirlinha") = "S"
            '    loadData()
            'Else
            '    ' Adri 01/12/2009 - Chamado 522 Maracanau - f

            Dim lbl_justificativa As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_justificativa"), Label)
            ViewState.Item("label_justificativa") = Trim(lbl_justificativa.Text)
            Dim lbl_portador As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_portador"), Label)
            ViewState.Item("label_portador") = Trim(lbl_portador.Text)
            gridResults.EditIndex = e.NewEditIndex
            loadData()
            'End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub gridResults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridResults.RowUpdating
        'Capturar valores
        Dim row As GridViewRow = gridResults.Rows(e.RowIndex)
        Try

            If (Not (row) Is Nothing) Then

                Dim adiantamento As New Adiantamento
                Dim erro As Boolean

                Dim cbo_justificativa As DropDownList = CType(row.FindControl("cbo_justificativa"), DropDownList)
                Dim cbo_portador As DropDownList = CType(row.FindControl("cbo_portador"), DropDownList)

                adiantamento.id_adiantamento = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)

                If Not (cbo_justificativa.SelectedValue.Trim().Equals(String.Empty)) Then
                    adiantamento.id_adiantamento_justificativa = Convert.ToInt32(cbo_justificativa.SelectedValue)
                End If
                If Not (cbo_portador.SelectedValue.Trim().Equals(String.Empty)) Then
                    adiantamento.id_portador = Convert.ToInt32(cbo_portador.SelectedValue)
                End If

                Dim txt_nr_percentual_adto As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_percentual_adto"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                If Not (txt_nr_percentual_adto.Text.Trim.ToString.Equals(String.Empty)) Then
                    adiantamento.nr_percentual_adto = Convert.ToDecimal(txt_nr_percentual_adto.Text)
                Else
                    adiantamento.nr_percentual_adto = 0
                End If

                Dim txt_nr_valor_adto As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_adto"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                If Not (txt_nr_valor_adto.Text.Trim.ToString.Equals(String.Empty)) Then
                    adiantamento.nr_valor_adto = Convert.ToDecimal(txt_nr_valor_adto.Text)
                Else
                    adiantamento.nr_valor_adto = 0
                End If
                adiantamento.id_modificador = Session("id_login")

                erro = False
                ' 22/07/2008 - i
                'If adiantamento.nr_percentual_adto = 0 And adiantamento.nr_valor_adto = 0 Then
                '    erro = True
                '    messageControl.Alert("O percentual ou valor de adiantamento deve ser informado.")
                'Else
                '    Dim parametro As New Parametro
                '    If adiantamento.nr_percentual_adto > parametro.nr_perc_adto Then
                '        erro = True
                '        messageControl.Alert("O percentual não pode ser maior que " & parametro.nr_perc_adto)
                '    Else
                '        If adiantamento.nr_valor_adto > gridResults.Rows(e.RowIndex).Cells(4).Text Then
                '            erro = True
                '            messageControl.Alert("O valor do adiantamento não pode ultrapassar o valor disponível.")
                '        Else
                '            If adiantamento.nr_percentual_adto > 0 And adiantamento.nr_valor_adto > 0 Then
                '                erro = True
                '                messageControl.Alert("O percentual do adiantamento e o valor do adiantamento não podem ser informados simultaneamente.")
                '            End If
                '        End If
                '    End If
                'End If
                If adiantamento.nr_valor_adto = 0 And Convert.ToDecimal(gridResults.Rows(e.RowIndex).Cells(4).Text) > 0 Then
                    erro = True
                    messageControl.Alert("O Valor do Adiantamento deve ser informado!")
                End If
                If adiantamento.nr_valor_adto > Convert.ToDecimal(gridResults.Rows(e.RowIndex).Cells(4).Text) Then  ' Se ultrapassou
                    'If Convert.ToDecimal(gridResults.Rows(e.RowIndex).Cells(4).Text) = 0 Then  'Se Saldo Disponível zerado
                    '    erro = True
                    '    messageControl.Alert("Não há saldo disponível para o adiantamento!")
                    'Else
                    If (cbo_justificativa.SelectedValue.Trim().Equals(String.Empty)) Then
                        erro = True
                        messageControl.Alert("O valor do adiantamento ultrapassou o Saldo Disponível. Informar a justificativa!")
                    End If
                    'End If
                End If
                ' 22/07/2008 - f

                If erro = False Then
                    'If adiantamento.nr_valor_adto >= gridResults.Rows(e.RowIndex).Cells(4).Text Then  ' Se ultrapassou
                    'adiantamento.nr_percentual_adto = 100
                    'Else
                    'End If
                    ' 05/11/2008 - i 
                    If Convert.ToDecimal(gridResults.Rows(e.RowIndex).Cells(4).Text) > 0 Then
                        adiantamento.nr_percentual_adto = (100 * adiantamento.nr_valor_adto) / Convert.ToDecimal(gridResults.Rows(e.RowIndex).Cells(4).Text)
                    Else
                        adiantamento.nr_percentual_adto = 100
                    End If
                    ' 05/11/2008 - f 
                    adiantamento.updateAdiantamento()
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 40
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
    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated

        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            '' Adri 01/12/2009 - Chamado 522 Maracanau -i
            'If ViewState.Item("incluirlinha") = "S" Then
            '    If e.Row.RowIndex = 0 Then
            '        ViewState.Item("label_justificativa") = ""
            '        ViewState.Item("label_portador") = ""
            '    End If

            'End If
            '' Adri 01/12/2009 - Chamado 522 Maracanau - f

            Try
                If Not (ViewState("label_justificativa") Is Nothing) Then

                    Dim cbo_justificativa As DropDownList = CType(e.Row.FindControl("cbo_justificativa"), DropDownList)

                    Dim justificativaadiantamento As New JustificativaAdiantamento

                    cbo_justificativa.DataSource = justificativaadiantamento.getAdiantamentoJustificativaByFilters()
                    cbo_justificativa.DataTextField = "nm_adiantamento_justificativa"
                    cbo_justificativa.DataValueField = "id_adiantamento_justificativa"
                    cbo_justificativa.DataBind()

                    If (ViewState("label_justificativa").ToString.Equals(String.Empty)) Then
                        cbo_justificativa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState("label_justificativa") = "SEM_VALOR" 'Assume que  esta sem valor
                    Else
                        cbo_justificativa.SelectedValue = cbo_justificativa.Items.FindByText(ViewState("label_justificativa").Trim.ToString).Value
                        ViewState("label_justificativa") = Nothing 'Assume que  tem valor
                    End If

                End If

                If Not (ViewState("label_portador") Is Nothing) Then

                    Dim cbo_portador As DropDownList = CType(e.Row.FindControl("cbo_portador"), DropDownList)

                    Dim portador As New Portador

                    cbo_portador.DataSource = portador.getPortadoresByFilters()
                    cbo_portador.DataTextField = "nm_portador"
                    cbo_portador.DataValueField = "id_portador"
                    cbo_portador.DataBind()

                    If (ViewState("label_portador").ToString.Equals(String.Empty)) Then
                        cbo_portador.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState("label_portador") = "SEM_VALOR" 'Assume que  esta sem valor
                    Else
                        cbo_portador.SelectedValue = cbo_portador.Items.FindByText(ViewState("label_portador").Trim.ToString).Value
                        ViewState("label_portador") = Nothing 'Assume que  tem valor
                    End If

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub
    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Edit", "Editar", "Cancel", "Cancelar", "Update"
                Return
            Case "Delete"
                deleteAdiantamento(Convert.ToInt32(e.CommandArgument.ToString()))
        End Select


        ' 02/12/2009 - Rls23 Maracanau chamado 522 - i
        'Select Case e.CommandName.ToString().ToLower()
        '    Case "novo"
        '        ViewState.Item("incluirlinha") = "S"
        '        Dim adiantamento As New Adiantamento
        '        adiantamento.id_adiantamento = Convert.ToInt32(e.CommandArgument.ToString())

        '        Dim dsAdiantamento As DataSet = adiantamento.getAdiantamentoNovo()
        '        Dim dr As DataRow = dsAdiantamento.Tables(0).NewRow()
        '        dsAdiantamento.Tables(0).Rows.InsertAt(dr, 0)
        '        dsAdiantamento.Tables(0).Rows(0).Item("id_propriedade") = dsAdiantamento.Tables(0).Rows(1).Item("id_propriedade").ToString
        '        gridResults.Visible = True
        '        gridResults.DataSource = Helper.getDataView(dsAdiantamento.Tables(0), ViewState.Item("sortExpression"))
        '        gridResults.EditIndex = 0
        '        gridResults.DataBind()
        '        ViewState.Item("incluirlinha") = Nothing
        'End Select
        ' 02/12/2009 - Rls23 Maracanau chamado 522 - f

    End Sub
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvalor_adto As Decimal
            Dim listaprovado As Integer = 0
            If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
                Dim txt_valor_adto As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_valor_adto"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                lvalor_adto = txt_valor_adto.Text
            Else
                Dim lbl_valor_adto As Label = CType(e.Row.FindControl("lbl_nr_valor_adto"), Label)
                lvalor_adto = lbl_valor_adto.Text

                'fran out/2014 fase 3 i
                Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("btn_delete"), Anthem.ImageButton)
                Dim lbl_st_aprovado As Label = CType(e.Row.FindControl("lbl_st_aprovado"), Label)


                Select Case lbl_st_aprovado.Text
                    Case "1" 'Pre-aprovado ou aprovado 1o nivel deixa excluir
                        btn_delete.Enabled = True
                        btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                        btn_delete.ToolTip = "Excluir adiantamento pré aprovado."
                        listaprovado = 1
                    Case "4" 'aprovado 1o nivel deixa excluir
                        btn_delete.Enabled = True
                        btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                        btn_delete.ToolTip = "Excluir adiantamento já aprovado em 1o Nível."
                        listaprovado = 4

                    Case "2" 'Aprovado 2o nivel
                        btn_delete.Enabled = False
                        btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                        btn_delete.ToolTip = "Registro não pode ser excluído pois já foi aprovado em 2o Nível."
                        'De acordo com ricardo francisco pode editar mesmo depois da aprovação
                        listaprovado = 2

                    Case "3" 'Reprovado
                        btn_delete.Enabled = False
                        btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                        btn_delete.ToolTip = "Registro não pode ser excluído pois já foi reprovado."
                        listaprovado = 3

                    Case Else 'aprovado ou reprovado
                        btn_delete.Enabled = False
                        btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                        btn_delete.ToolTip = "Registro não pode ser excluído."


                End Select

                'fran out/2014 fase 3 f

            End If


            'If (e.Row.Cells(9).Text.Trim().Equals("1")) Then  ' 25/11/2009 - Chamado 499 (inclusão de novas colnas)
            If (e.Row.Cells(14).Text.Trim().Equals("1")) Then
                e.Row.Cells(14).Text = "Pré-aprovado"
            Else
                If (e.Row.Cells(14).Text.Trim().Equals("2")) Then
                    e.Row.Cells(14).Text = "Aprovado"
                Else
                    If (e.Row.Cells(14).Text.Trim().Equals("3")) Then
                        e.Row.Cells(14).Text = "Reprovado"
                    Else
                        'If (e.Row.Cells(9).Text.Trim().Equals("4")) Then
                        '    e.Row.Cells(9).Text = "Ultrapassou"
                        'End If
                    End If
                End If
            End If

            ' 25/11/2009 - Chamado 499 - i
            ' Calcular % Comprometido (Total Desc + Adtos) / Valor Mensal Estimado
            If IsNumeric(e.Row.Cells(3).Text.Trim()) Then  ' Se tem Valor Mensal Estimado
                If Convert.ToDecimal(e.Row.Cells(3).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    'e.Row.Cells(7).Text = Round(Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim()), 2)
                    'fran 16/05/2014 fase 2 Foi solicitado que o % comprometido tivesse o valor de adiantamento na somado aos descontos
                    'e.Row.Cells(7).Text = Round((Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim())) * 100, 2)   ' Adri 10/02/2010 - chamado 651
                    'fran fase 3 out/2014 i
                    'e.Row.Cells(7).Text = Round(((Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) + Convert.ToDecimal(lvalor_adto)) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim())) * 100, 2)   ' Adri 10/02/2010 - chamado 651
                    If listaprovado = 2 Then 'se for aprovado 2 nivel, a rotina de saldo disponivel já traz o adiantamento como descontos + adiantamewntos
                        e.Row.Cells(7).Text = FormatPercent(Round(((Convert.ToDecimal(e.Row.Cells(6).Text.Trim())) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim())), 2), 2)
                    Else
                        e.Row.Cells(7).Text = FormatPercent(Round((Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) + Convert.ToDecimal(lvalor_adto)) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim()), 2), 2)
                    End If

                    'fran fase 3 out/2014 f
                    'fran 16/05/2014 fase 2

                End If
            End If
            ' 25/11/2009 - Chamado 499 - f

            ' fran fase 2 melhorias - i
            Dim laux As Decimal
            If e.Row.Cells(6).Text.Trim.Equals(String.Empty) Then 'Pega o total dos desc + adto
                laux = 0
            Else
                laux = e.Row.Cells(6).Text.Trim
            End If
            If Not e.Row.Cells(8).Text.Trim.Equals(String.Empty) Then 'Pega o total pedidos abertos
                laux = laux + e.Row.Cells(8).Text.Trim
            End If
            e.Row.Cells(9).Text = Convert.ToDecimal(laux)   'Total Desc + aadto + pedidos abertos
            ' fran fase 2 melhorias - f


            'If IsNumeric(e.Row.Cells(6).Text.Trim()) Then  ' Se tem total desc+ adto
            '    If Convert.ToDecimal(e.Row.Cells(3).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
            '        'e.Row.Cells(7).Text = Round(Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim()), 2)
            '        e.Row.Cells(7).Text = Round((Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim())) * 100, 2)   ' Adri 10/02/2010 - chamado 651
            '    End If
            'End If


            ' Calcular % Comprometido  (Total Desc + Adtos + Ped em Aberto) / Valor Mensal Estimado
            If IsNumeric(e.Row.Cells(3).Text.Trim()) Then  ' Se tem Valor Mensal Estimado
                If Convert.ToDecimal(e.Row.Cells(3).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    'fran 16/05/2014 fase 2 Foi solicitado que o % comprometido tivesse o valor de adiantamento somado aos Total Desc + Adtos + Ped em Aberto
                    'e.Row.Cells(10).Text = Round((Convert.ToDecimal(e.Row.Cells(9).Text.Trim()) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim())) * 100, 2)
                    'fran fase 3 i 
                    'e.Row.Cells(10).Text = Round(((Convert.ToDecimal(e.Row.Cells(9).Text.Trim()) + Convert.ToDecimal(lvalor_adto)) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim())) * 100, 2)
                    If listaprovado = 2 Then 'se for aprovado 2 nivel, a rotina de saldo disponivel já traz o adiantamento como descontos + adiantamewntos
                        e.Row.Cells(10).Text = FormatPercent(Round(((Convert.ToDecimal(e.Row.Cells(9).Text.Trim())) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim())), 2), 2)
                    Else
                        e.Row.Cells(10).Text = FormatPercent(Round(((Convert.ToDecimal(e.Row.Cells(9).Text.Trim()) + Convert.ToDecimal(lvalor_adto)) / Convert.ToDecimal(e.Row.Cells(3).Text.Trim())), 2), 2)
                    End If
                    'fran fase 3 f 
                    'fran 16/05/2014 fase 2 
                End If
            End If

            ' fran fase 2 melhorias - f

            'fran fase 3 i


            'Total descontos + adto deve ser somado ao novo adto
            If IsNumeric(lvalor_adto) And listaprovado <> 2 Then  ' Se tem valor adto e nao é aprovado 2o nivel
                e.Row.Cells(6).Text = (Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) + Convert.ToDecimal(lvalor_adto))

                'Total descontos + adto + ped abertos deve ser somado ao novo adto
                e.Row.Cells(9).Text = (Convert.ToDecimal(e.Row.Cells(9).Text.Trim()) + Convert.ToDecimal(lvalor_adto))
            End If

            If IsNumeric(e.Row.Cells(13).Text.Trim()) Then  ' Se tem Saldo x Polit Adto
                If Convert.ToDecimal(e.Row.Cells(13).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    ' e.Row.Cells(13).Text = (Convert.ToDecimal(e.Row.Cells(13).Text.Trim()) - Convert.ToDecimal(lvalor_adto)) 'este campo deve considerar o adto que esta tentando fazer
                    e.Row.Cells(13).Text = (Convert.ToDecimal(e.Row.Cells(13).Text.Trim()) - Convert.ToDecimal(e.Row.Cells(9).Text.Trim()))
                End If
            End If

            'Formatações
            If IsNumeric(e.Row.Cells(2).Text.Trim()) Then  ' volume
                If Convert.ToInt64(e.Row.Cells(2).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(2).Text = FormatNumber(Convert.ToInt64(e.Row.Cells(2).Text.Trim()))
                End If
            End If
            If IsNumeric(e.Row.Cells(3).Text.Trim()) Then  ' valor mensal
                If Convert.ToDecimal(e.Row.Cells(3).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(3).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(3).Text.Trim()), 2, , , TriState.True)
                End If
            End If
            If IsNumeric(e.Row.Cells(4).Text.Trim()) Then  ' descontos
                If Convert.ToDecimal(e.Row.Cells(4).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(4).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(4).Text.Trim()), 2, , , TriState.True)
                End If
            End If
            If IsNumeric(lvalor_adto) Then  ' valor adto
                If Convert.ToDecimal(lvalor_adto) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(5).Text = FormatNumber(Convert.ToDecimal(lvalor_adto), 2, , , TriState.True)
                End If
            End If
            If IsNumeric(e.Row.Cells(6).Text.Trim()) Then  ' total desc + adto
                If Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(6).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(6).Text.Trim()), 2, , , TriState.True)
                End If
            End If

            If IsNumeric(e.Row.Cells(8).Text.Trim()) Then  ' valor pedidos abertos
                If Convert.ToDecimal(e.Row.Cells(8).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(8).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(8).Text.Trim()), 2, , , TriState.True)
                End If
            End If
            If IsNumeric(e.Row.Cells(9).Text.Trim()) Then  ' valor total desc + ped+ adian/o
                If Convert.ToDecimal(e.Row.Cells(9).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(9).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(9).Text.Trim()), 2, , , TriState.True)
                End If
            End If

            If IsNumeric(e.Row.Cells(13).Text.Trim()) Then  ' valor Saldo Politica
                If Convert.ToDecimal(e.Row.Cells(13).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
                    e.Row.Cells(13).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(13).Text.Trim()), 2, , , TriState.True)
                End If
            End If
            'fran fase 3 f



        End If


        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try

                'If ViewState("label_justificativa") = "SEM_VALOR" Then 'Assume que está sem valor
                'Se já fez a criação  da linha e esta sem valor no combo 
                Dim cbo_justificativa As DropDownList = CType(e.Row.FindControl("cbo_justificativa"), DropDownList)
                If Not (cbo_justificativa Is Nothing) Then
                    cbo_justificativa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                End If
                ViewState("label_justificativa") = Nothing 'Assume que  tem valor
                'End If

                If ViewState("label_portador") = "SEM_VALOR" Then 'Assume que está sem valor
                    'Se já fez a criação  da linha e esta sem valor no combo 
                    Dim cbo_portador As DropDownList = CType(e.Row.FindControl("cbo_portador"), DropDownList)
                    If Not (cbo_portador Is Nothing) Then
                        cbo_portador.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    End If
                    ViewState("label_portador") = Nothing 'Assume que  tem valor
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        If Page.IsValid = True Then
            Try


                Dim tecnico As New Tecnico(ViewState.Item("id_tecnico"))


                Dim notificacao As New Notificacao
                Dim lAssunto As String = "Aprovação 1.o Nível de Solicitação de Adiantamento para Produtores - Técnico " & tecnico.nm_tecnico
                Dim lCorpo As String = "Existem solicitações de adiantamento para as Propriedades do Técnico " & tecnico.nm_tecnico & " pendentes para aprovação 1.o Nível"

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 9 'email
                usuariolog.id_menu_item = 40
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                ' Parametro 5 - Adiantamento 1.o Nível
                If notificacao.enviaMensagemEmail(5, lAssunto, lCorpo, MailPriority.High) = True Then

                    messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível foi enviada aos destinatários com sucesso!")
                Else

                    messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        End If
    End Sub

    Protected Sub txt_MesAno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MesAno.TextChanged
        'hl_novo.Enabled = False  ' Adri 01/12/2009 - Chamado 522 Maracanau
    End Sub

    Protected Sub btn_adicionar_propriedade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar_propriedade.Click
        ' Adri 02/12/2009 - Chamado 522 Maracanau - i
        If Page.IsValid Then
            Try

                'If consistirAdicionarPropriedadeRomaneio() = True Then

                Dim row As GridViewRow = grdPropriedade.Rows(0)
                Dim cbo_propriedade As Anthem.DropDownList = CType(row.FindControl("cbo_propriedade"), Anthem.DropDownList)
                Dim txt_nr_valor_adto As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_adto"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim cbo_justificativa As Anthem.DropDownList = CType(row.FindControl("cbo_justificativa"), Anthem.DropDownList)
                Dim cbo_portador As Anthem.DropDownList = CType(row.FindControl("cbo_portador"), Anthem.DropDownList)

                Dim adiantamento As New Adiantamento
                'rcunidprod.id_romaneio_compartimento = cbo_placa_compartimento.SelectedValue
                'rcunidprod.id_propriedade = txt_propriedade.Text
                'rcunidprod.nr_unid_producao = txt_unidade_producao.Text
                'rcunidprod.dt_coleta = txt_dt_coleta.Text
                'rcunidprod.nr_temperatura = txt_nr_temperatura.Text
                'rcunidprod.id_alizarol = cbo_alizarol.SelectedValue
                'rcunidprod.id_modificador = Session("id_login")

                'rcunidprod.insertRomaneioUProducaoPropriedade()

                adiantamento.id_propriedade = Convert.ToInt32(cbo_propriedade.SelectedValue)
                adiantamento.dt_referencia = String.Concat("01/", Me.txt_MesAno.Text.Trim)
                If Not (txt_nr_valor_adto.Text.Trim().Equals(String.Empty)) Then
                    adiantamento.nr_valor_adto = txt_nr_valor_adto.Text
                End If
                If Not (cbo_justificativa.SelectedValue.Trim().Equals(String.Empty)) Then
                    adiantamento.id_adiantamento_justificativa = Convert.ToInt32(cbo_justificativa.SelectedValue)
                End If
                If Not (cbo_portador.SelectedValue.Trim().Equals(String.Empty)) Then
                    adiantamento.id_portador = Convert.ToInt32(cbo_portador.SelectedValue)
                End If

                ' Apura dados do saldo disponível
                Dim saldodisponivel As New SaldoDisponivel
                saldodisponivel.dt_referencia = adiantamento.dt_referencia
                saldodisponivel.id_propriedade = adiantamento.id_propriedade
                adiantamento.nr_valor_disponivel = saldodisponivel.getSaldoDisponivel()
                adiantamento.nr_volume_mensal = saldodisponivel.nr_volume_mensal
                adiantamento.nr_valor_descontos = saldodisponivel.nr_valor_descontos
                adiantamento.nr_valor_descontos_sem_adto = saldodisponivel.nr_valor_descontos_sem_adto ' NOVO
                adiantamento.nr_valor_mensal = saldodisponivel.nr_valor_faturamento  ' NOVO
                adiantamento.id_modificador = Session("id_login")

                'fran fase 2 melhorias i
                Dim pedidosabertos As New Pedido
                pedidosabertos.id_propriedade = adiantamento.id_propriedade
                adiantamento.nr_valor_pedidos_abertos = pedidosabertos.getTotalPedidosAbertos
                'fran fase 2 melhorias f

                ViewState.Item("id_adiantamento") = adiantamento.insertAdiantamentoNovo()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inserir
                usuariolog.id_menu_item = 40
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                'Limpa grid de inclusão
                Dim dsPropriedade As New DataTable
                dsPropriedade.Rows.Clear()
                dsPropriedade.Columns.Add("propriedade")
                dsPropriedade.Columns.Add("valoradto")
                dsPropriedade.Columns.Add("justificativa")
                dsPropriedade.Columns.Add("portador")

                Dim dr As DataRow

                dr = dsPropriedade.NewRow()
                dr.Item(0) = String.Empty
                dr.Item(1) = String.Empty

                dsPropriedade.Rows.InsertAt(dr, 0)
                grdPropriedade.Visible = True
                grdPropriedade.DataSource = Helper.getDataView(dsPropriedade, "")
                grdPropriedade.DataBind()

                messageControl.Alert("Novo Adiantamento incluído para a Propriedade com sucesso!")

                loadData()
                'End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
        ' Adri 02/12/2009 - Chamado 522 Maracanau - f

    End Sub

    Protected Sub grdPropriedade_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPropriedade.RowCreated
        ' Adri 02/12/2009 - Chamado 522 Maracanau - i
        If e.Row.RowType = DataControlRowType.DataRow Then
            Try
                Dim cbo_propriedade As DropDownList = CType(e.Row.FindControl("cbo_propriedade"), DropDownList)
                Dim propriedade As New Propriedade()
                propriedade.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico"))
                cbo_propriedade.DataSource = propriedade.getPropriedadeByFilters()
                cbo_propriedade.DataTextField = "ds_propriedade"
                cbo_propriedade.DataValueField = "id_propriedade"
                cbo_propriedade.DataBind()


                Dim cbo_justificativa As DropDownList = CType(e.Row.FindControl("cbo_justificativa"), DropDownList)
                Dim justificativa As New JustificativAadiantamento()
                cbo_justificativa.DataSource = justificativa.getAdiantamentoJustificativaByFilters()
                cbo_justificativa.DataTextField = "nm_adiantamento_justificativa"
                cbo_justificativa.DataValueField = "id_adiantamento_justificativa"
                cbo_justificativa.DataBind()
                cbo_justificativa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

                Dim cbo_portador As DropDownList = CType(e.Row.FindControl("cbo_portador"), DropDownList)
                Dim portador As New Portador
                cbo_portador.DataSource = portador.getPortadoresByFilters()
                cbo_portador.DataTextField = "nm_portador"
                cbo_portador.DataValueField = "id_portador"
                cbo_portador.DataBind()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
        ' Adri 02/12/2009 - Chamado 522 Maracanau - f

    End Sub

    Protected Sub grdPropriedade_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdPropriedade.RowDataBound
        'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
        Dim cbo_propriedade As DropDownList = CType(e.Row.FindControl("cbo_propriedade"), DropDownList)
        If Not (cbo_propriedade Is Nothing) Then
            cbo_propriedade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        End If

        Dim cbo_justificativa As DropDownList = CType(e.Row.FindControl("cbo_justificativa"), DropDownList)
        If Not (cbo_justificativa Is Nothing) Then
            cbo_justificativa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        End If

        Dim cbo_portador As DropDownList = CType(e.Row.FindControl("cbo_portador"), DropDownList)
        If Not (cbo_portador Is Nothing) Then
            cbo_portador.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        End If

    End Sub

    Private Sub deleteAdiantamento(ByVal id_adiantamento As Integer)

        Try

            Dim adiantamento As New Adiantamento()
            adiantamento.id_adiantamento = id_adiantamento
            adiantamento.id_modificador = Convert.ToInt32(Session("id_login"))
            adiantamento.deleteAdiantamento()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'deleçao
            usuariolog.id_menu_item = 40
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 
            messageControl.Alert("Registro excluído com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        ViewState.Item("dt_referencia") = Me.txt_MesAno.Text()
        'fran nov/2014 fase 3 melhoria i
        If txt_cd_tecnico.Text.Equals(String.Empty) Then
            ViewState.Item("id_tecnico") = 0

        Else
            'fran nov/2014 fase 3 melhoria f
            ViewState.Item("id_tecnico") = txt_cd_tecnico.Text()
        End If

        'ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue  ' 02/12/2009 - Chamado 522 Maracanau
        ViewState.Item("st_aprovado") = Me.cbo_status.SelectedValue

        '02/12/2009 - Chamado 522 - Maracanau - i
        grdPropriedade.Visible = True
        Me.btn_adicionar_propriedade.Visible = True

        Dim dsPropriedade As New DataTable
        dsPropriedade.Rows.Clear()
        dsPropriedade.Columns.Add("propriedade")
        dsPropriedade.Columns.Add("valoradto")
        dsPropriedade.Columns.Add("justificativa")
        dsPropriedade.Columns.Add("portador")

        Dim dr As DataRow

        dr = dsPropriedade.NewRow()
        dr.Item(0) = String.Empty
        dr.Item(1) = String.Empty

        dsPropriedade.Rows.InsertAt(dr, 0)
        grdPropriedade.Visible = True
        grdPropriedade.DataSource = Helper.getDataView(dsPropriedade, "")
        grdPropriedade.DataBind()

        ' Para grid com todas as Propriedades do Técnico
        ViewState.Item("sortExpression") = "ds_produtor asc"

        insertData()

        updateData()    ' Atualiza Volume Mensal, Valor Disponível, Valor de Descontos

        loadData()

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'Exportação Dados
        usuariolog.id_menu_item = 40
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        'se o grid tiver mais que 65536  linhas não podemos exportar
        If gridResults.Visible = True Then
            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                Response.Redirect("frm_adiantamento_solicitar_excel.aspx?id_tecnico=" + ViewState.Item("id_tecnico").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&st_aprovado=" + ViewState.Item("st_aprovado").ToString)
            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
            End If
        End If

    End Sub
End Class
