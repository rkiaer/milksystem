Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail
Imports System.Net.Mime

Partial Class lst_preco_negociado_cooperativa

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Page.IsValid Then
            ViewState.Item("dt_referencia") = Me.txt_MesAno.Text()
            ViewState.Item("st_aprovado") = Me.cbo_status.SelectedValue
            ViewState.Item("id_estabelecimento") = Me.cbo_estabelecimento.SelectedValue
            ViewState.Item("id_cooperativa") = Me.hf_id_cooperativa.Value
            ViewState.Item("cd_cooperativa") = Me.txt_cd_cooperativa.Text
            ViewState.Item("nr_periodo") = Me.cbo_periodo.SelectedValue

            loadData()
        End If
    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_preco_negociado_cooperativa.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_preco_negociado_cooperativa.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 36
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
        With btn_lupa_cooperativa
            .Attributes.Add("onclick", "javascript:ShowDialogCooperativa()")
            .ToolTip = "Filtrar Cooperativas"
        End With


    End Sub


    Private Sub loadDetails()

        Try

            Dim statuspreconegociado As New StatusPrecoNegociado
            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_estabelecimento.SelectedValue = 1 'pocos 

            cbo_status.DataSource = statuspreconegociado.getStatusPrecoNegociadoByFilters()
            cbo_status.DataTextField = "nm_aprovado"
            cbo_status.DataValueField = "st_aprovado"
            cbo_status.DataBind()
            'deve retirar item 4 que nao existe 1o nivel aprovacao cooperativa
            cbo_status.Items(3).Enabled = False

            cbo_status.Items.Insert(0, New ListItem("[Selecione]", ""))


            ViewState.Item("sortExpression") = "nm_pessoa"

            loadFilters()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean



        If Not (customPage.getFilterValue("preco_negociado_cooperativa", cbo_status.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("preco_negociado_cooperativa", cbo_status.ID)
            cbo_status.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("preco_negociado_cooperativa", txt_MesAno.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("preco_negociado_cooperativa", txt_MesAno.ID)
            txt_MesAno.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If


        If Not (customPage.getFilterValue("preco_negociado_cooperativa", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("preco_negociado_cooperativa", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("preco_negociado_cooperativa")
        End If

    End Sub
    Private Sub insertData()
        Try

            Dim preconegociadocooperativa As New PrecoNegociadoCooperativa

            preconegociadocooperativa.dt_referencia = "01/" & ViewState.Item("dt_referencia")
            preconegociadocooperativa.insertPrecoNegociadoCooperativa()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Private Sub loadData()

        Try
            Dim preconegociado As New PrecoNegociadoCooperativa
            preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
            If Not (ViewState.Item("id_cooperativa").ToString.Equals(String.Empty)) Then
                preconegociado.id_pessoa = Convert.ToInt32(ViewState.Item("id_cooperativa").ToString())
            End If
            preconegociado.nr_periodo = Convert.ToInt32(ViewState.Item("nr_periodo").ToString())
            preconegociado.st_aprovado = ViewState.Item("st_aprovado").ToString()
            preconegociado.id_situacao = 1

            Dim dsPreco As DataSet = preconegociado.getPrecoNegociadoCooperativaByFilters()

            If (dsPreco.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPreco.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()

                'atualizar totalizadores por referencia
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente ou inclua Cooperativas.")
            End If

            'atualizar totalizadores da referencia informada
            Dim dstotais As DataSet = preconegociado.getPrecoNegociadoCooperativaTotalizador
            Dim row As DataRow

            lbl_total_1a.Text = String.Empty
            lbl_total_1a_aprovada.Text = String.Empty
            lbl_total_2a.Text = String.Empty
            lbl_total_2a_aprovada.Text = String.Empty
            Dim lbaguardandoaprovacao As Boolean = False

            For Each row In dstotais.Tables(0).Rows
                Select Case row.Item("nr_periodo").ToString
                    Case "1"
                        lbl_total_1a.Text = row.Item("nr_coop_periodo").ToString
                        lbl_total_1a_aprovada.Text = row.Item("nr_coop_aprovada").ToString

                    Case "2"
                        lbl_total_2a.Text = row.Item("nr_coop_periodo").ToString
                        lbl_total_2a_aprovada.Text = row.Item("nr_coop_aprovada").ToString
                End Select
                If CInt(row.Item("nr_coop_aguardando").ToString) > 0 Then
                    lbaguardandoaprovacao = True
                End If
            Next
            
            If lbaguardandoaprovacao = True Then
                lk_email.Enabled = True
            Else
                lk_email.Enabled = False
                lk_email.ToolTip = "Não existem cooperativas aguardando aprovação para a Referência."

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

            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If



        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("preco_negociado_cooperativa", cbo_status.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("preco_negociado_cooperativa", txt_MesAno.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("preco_negociado_cooperativa", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
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

            'Dim lbl_justificativa As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_justificativa"), Label)
            'ViewState.Item("label_justificativa") = Trim(lbl_justificativa.Text)
            'Dim lbl_portador As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_portador"), Label)
            'ViewState.Item("label_portador") = Trim(lbl_portador.Text)

            gridResults.EditIndex = e.NewEditIndex
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub gridResults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridResults.RowUpdating
        'Capturar valores
        If Page.IsValid Then

            Dim row As GridViewRow = gridResults.Rows(e.RowIndex)
            Try

                If (Not (row) Is Nothing) Then

                    Dim preconegociadocooperativa As New PrecoNegociadoCooperativa
                    Dim erro As Boolean


                    preconegociadocooperativa.id_preco_negociado_cooperativa = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)
                    Dim txt_nr_preco_negociado As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_preco_negociado"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_volume As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_volume"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                    If Not (txt_nr_preco_negociado.Text.Trim.ToString.Equals(String.Empty)) Then
                        preconegociadocooperativa.nr_preco_negociado = Convert.ToDecimal(txt_nr_preco_negociado.Text)
                    Else
                        preconegociadocooperativa.nr_preco_negociado = 0
                    End If

                    If Not (txt_volume.Text.Trim.ToString.Equals(String.Empty)) Then
                        preconegociadocooperativa.nr_volume = Convert.ToDecimal(txt_volume.Text)
                    Else
                        preconegociadocooperativa.nr_volume = 0
                    End If

                    'Dim txt_nr_preco_negociado_1q As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_preco_negociado_1q"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    'If Not (txt_nr_preco_negociado_1q.Text.Trim.ToString.Equals(String.Empty)) Then
                    '    preconegociadocooperativa.nr_preco_negociado_1q = Convert.ToDecimal(txt_nr_preco_negociado_1q.Text)
                    'Else
                    '    preconegociadocooperativa.nr_preco_negociado_1q = 0
                    'End If

                    'Dim txt_nr_preco_negociado_2q As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_preco_negociado_2q"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    'If Not (txt_nr_preco_negociado_2q.Text.Trim.ToString.Equals(String.Empty)) Then
                    '    preconegociadocooperativa.nr_preco_negociado_2q = Convert.ToDecimal(txt_nr_preco_negociado_2q.Text)
                    'Else
                    '    preconegociadocooperativa.nr_preco_negociado_2q = 0
                    'End If

                    'Dim txt_nr_valor_frete As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_valor_frete"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    'If Not (txt_nr_valor_frete.Text.Trim.ToString.Equals(String.Empty)) Then
                    '    preconegociadocooperativa.nr_valor_frete = Convert.ToDecimal(txt_nr_valor_frete.Text)
                    'Else
                    '    preconegociadocooperativa.nr_valor_frete = 0
                    'End If

                    preconegociadocooperativa.id_modificador = Session("id_login")

                    erro = False
                    'If preconegociadocooperativa.nr_preco_negociado_1q = 0 And preconegociadocooperativa.nr_preco_negociado_2q = 0 Then
                    '    erro = True
                    '    messageControl.Alert("O preço para 1.a Quinzena ou 2.a Quinzena deve ser informado!")
                    'End If

                    If erro = False Then
                        preconegociadocooperativa.updatePrecoNegociadoCooperativa()

                        'FRAN 08/12/2020 i incluir log 
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alteracao
                        usuariolog.id_menu_item = 36
                        usuariolog.insertUsuarioLog()
                        'FRAN 08/12/2020  incluir log 

                        gridResults.EditIndex = -1
                        loadData()
                    End If
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated

        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            Try


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub
    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Edit", "Editar", "Cancel", "Cancelar", "Update"
                Return
            Case "delete"
                deletePrecoNegociadoCooperativa(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select
    End Sub
    Private Sub deletePrecoNegociadoCooperativa(ByVal id_preco_negociado_cooperativa As Integer)

        Try
            Dim preco As New PrecoNegociadoCooperativa()
            preco.id_preco_negociado_cooperativa = id_preco_negociado_cooperativa
            preco.id_modificador = Convert.ToInt32(Session("id_login"))
            preco.deletePrecoNegociadoCooperativa()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 36
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro excluído com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound


        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Dim txt_volume As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(e.Row.FindControl("txt_volume"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

            If Not txt_volume.Text.Equals(String.Empty) Then
                txt_volume.Text = CLng(txt_volume.Text)
            End If
        Else
            If (e.Row.RowType <> DataControlRowType.Header _
                    And e.Row.RowType <> DataControlRowType.Footer _
                    And e.Row.RowType <> DataControlRowType.Pager) Then
                Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
                Dim btn_editar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)

                Dim lbl_st_aprovado As Label = CType(e.Row.FindControl("lbl_st_aprovado"), Label)

                If lbl_st_aprovado.Text.ToString.Equals("5") OrElse lbl_st_aprovado.Text.ToString.Equals("1") Then 'se for aguardando aprovacao ou sem preco pode exluir
                    btn_delete.Enabled = True
                    btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                    btn_delete.ToolTip = "Exlui registro permanentemente."
                    btn_editar.Enabled = True
                    btn_editar.ImageUrl = "~/img/icone_editar_grid.gif"
                Else

                    btn_delete.Enabled = False
                    btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                    btn_delete.ToolTip = "Não é possível excluir o registro. Já foi aprovado/reprovado em 2o Nível."
                    btn_editar.Enabled = False
                    btn_editar.ImageUrl = "~/img/icone_editar_grid_desabilitado.gif"

                End If
            End If

        End If

    End Sub

    Protected Sub cv_incluir_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_incluir.ServerValidate
        Try

            Dim pessoa As New Pessoa()
            Dim lmsg As String = String.Empty
            args.IsValid = True


            'se o periodo é mes deve selecionar 1a ou 2a quinzena
            If cbo_periodo.SelectedValue = 0 Then
                lmsg = "Para incluir a Cooperativa, o período selecionado deve ser 1a.Quinz ou 2a.Quinz."
                args.IsValid = False
            End If

            If args.IsValid = True Then
                If Not (Me.hf_id_cooperativa.Value.Trim.Equals(String.Empty)) Then

                    'se tem id da cooperativa valida
                    Dim lidcooperativa As Int32

                    pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_cooperativa.Value)
                    pessoa.cd_pessoa = Me.txt_cd_cooperativa.Text.Trim
                    lidcooperativa = pessoa.validarCooperativa

                    If lidcooperativa > 0 Then
                        args.IsValid = True
                    Else
                        hf_id_cooperativa.Value = String.Empty
                        args.IsValid = False
                        lmsg = "Cooperativa não cadastrada para o código informado."
                    End If

                    If args.IsValid = True Then

                        'verifica se existe a cooperativa para a referencia, estabelecimento e periodo
                        Dim preconegociado As New PrecoNegociadoCooperativa
                        preconegociado.dt_referencia = String.Concat("01/" & txt_MesAno.Text)
                        preconegociado.id_estabelecimento = cbo_estabelecimento.SelectedValue
                        preconegociado.id_pessoa = Convert.ToInt32(Me.hf_id_cooperativa.Value)
                        preconegociado.nr_periodo = cbo_periodo.SelectedValue
                        preconegociado.id_situacao = 1

                        Dim dspreco As DataSet = preconegociado.getPrecoNegociadoCooperativaByFilters
                        Dim row As DataRow
                        Dim bincluir As Boolean = True

                        'se encontrou linhas
                        If (dspreco.Tables(0).Rows.Count > 0) Then
                            'se encontrou linhas apenas de reprovado, deixa incluir
                            For Each row In dspreco.Tables(0).Rows

                                If dspreco.Tables(0).Rows(0).Item("st_aprovado").ToString.Equals("3") Then
                                    bincluir = True
                                Else
                                    bincluir = False 'se apenas 1 linha for <> reprovado nao pode incluir porque ja existe
                                    Exit For
                                End If
                            Next

                            If bincluir = False Then
                                lmsg = "A cooperativa não pode ser incluída porque já foi incluída para o estabelecimento, referência e período informados."
                                args.IsValid = False
                            End If
                        End If
                    End If
                Else
                    lmsg = "Para incluir a Cooperativa, uma Cooperativa válida deve ser informada."
                    args.IsValid = False

                End If
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_cooperativa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_cooperativa.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidcooperativa As Int32

            'If Not cbo_estabelecimento.SelectedValue.Equals(String.Empty) Then
            'pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
            'End If
            If Not (Me.hf_id_cooperativa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_cooperativa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_cooperativa.Text.Trim
            lidcooperativa = pessoa.validarCooperativa

            If lidcooperativa > 0 Then
                args.IsValid = True
                hf_id_cooperativa.Value = lidcooperativa
            Else
                hf_id_cooperativa.Value = String.Empty
                args.IsValid = False
                'messageControl.Alert("Cooperativa não cadastrada.")
                messageControl.Alert("Cooperativa não cadastrada para o código informado!")  ' 19/08/2010 Adriana Chamado 932
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadCooperativaByCodigo()

        Try


            Dim cooperativa As New Pessoa
            cooperativa.cd_pessoa = txt_cd_cooperativa.Text
            Dim dscooperativa As DataSet = cooperativa.getCooperativasByCodigo()
            If dscooperativa.Tables(0).Rows.Count > 0 Then
                lbl_nm_cooperativa.Visible = True
                lbl_cd_cnpj.Visible = True
                Me.lbl_nm_cnpj.Visible = True
                lbl_nm_cooperativa.Text = dscooperativa.Tables(0).Rows(0).Item("nm_pessoa")
                lbl_cd_cnpj.Text = dscooperativa.Tables(0).Rows(0).Item("cd_cnpj")
                hf_id_cooperativa.Value = dscooperativa.Tables(0).Rows(0).Item("id_pessoa")
            Else
                lbl_nm_cooperativa.Visible = False
                lbl_cd_cnpj.Visible = False
                Me.lbl_nm_cnpj.Visible = False
                hf_id_cooperativa.Value = String.Empty
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposCooperativa()

        Try

            If Not (customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").Equals(String.Empty)) Then
                Me.lbl_nm_cooperativa.Visible = True
                Me.lbl_nm_cooperativa.Text = customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").Equals(String.Empty)) Then
                Me.txt_cd_cooperativa.Text = customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").Equals(String.Empty)) Then
                Me.lbl_cd_cnpj.Visible = True
                Me.lbl_cd_cnpj.Text = customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").ToString
                Me.lbl_nm_cnpj.Visible = True
            End If

            'loadData()
            customPage.clearFilters("lupa_cooperativa")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_cooperativa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_cooperativa.TextChanged
        If Not txt_cd_cooperativa.Text.Equals(String.Empty) Then
            loadCooperativaByCodigo()
        Else
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            hf_id_cooperativa.Value = String.Empty
            lbl_cd_cnpj.Text = String.Empty
            lbl_cd_cnpj.Visible = False
            Me.lbl_nm_cnpj.Visible = False
        End If

    End Sub

    Protected Sub btn_lupa_cooperativa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_cooperativa.Click
        If Not (Me.hf_id_cooperativa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposCooperativa()
        Else
            txt_cd_cooperativa.Text = String.Empty
            hf_id_cooperativa.Value = String.Empty
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            lbl_cd_cnpj.Text = String.Empty
            lbl_cd_cnpj.Visible = False
            Me.lbl_nm_cnpj.Visible = False
        End If
    End Sub

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        If Page.IsValid = True Then
            Try


                Dim notificacao As New Notificacao
                Dim lAssunto As String = "Aprovação 2.o Nível de Preços e Volumes Negociados para Cooperativas"
                Dim lCorpo As String = "Existem preços negociados e volumes para Cooperativas pendentes para aprovação 2.o Nível."

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 9 'ENVIO EMAIL
                usuariolog.id_menu_item = 36
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f


                If notificacao.enviaMensagemEmail(26, lAssunto, lCorpo, MailPriority.High, , , Convert.ToInt32(ViewState.Item("id_estabelecimento"))) = True Then
                    messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível foi enviada aos destinatários com sucesso!")
                Else

                    messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível não pode ser enviada. Verifique se há destinatários cadastrados para este tipo de notificação.")

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        End If

    End Sub

    Protected Sub btn_incluir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_incluir.Click
        If Page.IsValid = True Then
            Try
                ViewState.Item("dt_referencia") = Me.txt_MesAno.Text()
                ViewState.Item("st_aprovado") = Me.cbo_status.SelectedValue
                ViewState.Item("id_estabelecimento") = Me.cbo_estabelecimento.SelectedValue
                ViewState.Item("id_cooperativa") = Me.hf_id_cooperativa.Value
                ViewState.Item("cd_cooperativa") = Me.txt_cd_cooperativa.Text
                ViewState.Item("nr_periodo") = Me.cbo_periodo.SelectedValue

                Dim preconegociado As New PrecoNegociadoCooperativa
                Dim bincluiuvolume As Boolean = False
                Dim bincluiupreco As Boolean = False

                preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
                preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
                preconegociado.id_pessoa = Convert.ToInt32(ViewState.Item("id_cooperativa").ToString())
                preconegociado.nr_periodo = Convert.ToInt32(ViewState.Item("nr_periodo").ToString())
                If Not txt_volume_incluir.Text.Equals(String.Empty) AndAlso CInt(txt_volume_incluir.Text) > 0 Then
                    preconegociado.nr_volume = Convert.ToDecimal(txt_volume_incluir.Text)
                    bincluiuvolume = True
                End If
                If Not txt_preco_incluir.Text.Equals(String.Empty) AndAlso CDec(txt_preco_incluir.Text) > 0 Then
                    preconegociado.nr_preco_negociado = Convert.ToDecimal(txt_preco_incluir.Text)
                    bincluiupreco = True
                End If
                If bincluiupreco = True AndAlso bincluiuvolume = True Then
                    preconegociado.st_aprovado = 1 'agraudando aprovacao
                Else
                    preconegociado.st_aprovado = 5 'sem preco negociado

                End If
                preconegociado.id_modificador = Session("id_login")

                preconegociado.insertPrecoNegociadoCooperativa()

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
End Class
