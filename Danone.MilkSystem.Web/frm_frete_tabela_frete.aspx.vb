Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.Math

Partial Class frm_frete_tabela_frete
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_frete_tabela_frete.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 255
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        Else
            If ViewState.Item("temlinhas") = False Then
                grdFrete.Rows(0).Cells.Clear()
                grdFrete.Rows(0).Cells.Add(New TableCell())
                grdFrete.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdFrete.Rows(0).Cells(0).Text = "Não existe nenhuma Tabela de Frete cadastrada."
                grdFrete.Rows(0).Cells(0).ColumnSpan = 7

            End If

            If ViewState.Item("temlinhasexcecao") = False Then
                grdExcecao.Rows(0).Cells.Clear()
                grdExcecao.Rows(0).Cells.Add(New TableCell())
                grdExcecao.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdExcecao.Rows(0).Cells(0).Text = "Não existe nenhuma Tabela de Frete Exceção cadastrada."
                grdExcecao.Rows(0).Cells(0).ColumnSpan = 7
            End If
        End If
            With btn_lupa_transportador
                .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
                .ToolTip = "Filtrar Transportadores"
            End With
            With btn_lupa_cooperativa
                .Attributes.Add("onclick", "javascript:ShowDialogCooperativa()")
                .ToolTip = "Filtrar Cooperativas"
            End With

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            Dim tipoequipamento As New TipoEquipamento
            Dim dstipoequipamento As DataSet
            tipoequipamento.id_situacao = 1
            dstipoequipamento = tipoequipamento.getTiposEquipamentosByFilters

            cbo_tipo_equipamento.DataSource = dstipoequipamento
            cbo_tipo_equipamento.DataTextField = "cd_tipo_equipamento"
            cbo_tipo_equipamento.DataValueField = "id_tipo_equipamento"
            cbo_tipo_equipamento.DataBind()
            cbo_tipo_equipamento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_tipo_equipamento_excecao.DataSource = dstipoequipamento
            cbo_tipo_equipamento_excecao.DataTextField = "cd_tipo_equipamento"
            cbo_tipo_equipamento_excecao.DataValueField = "id_tipo_equipamento"
            cbo_tipo_equipamento_excecao.DataBind()
            cbo_tipo_equipamento_excecao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim linha As New Linha
            linha.id_situacao = 1
            linha.id_estabelecimento = 1
            Dim dslinha As DataSet = linha.getLinhaByFilters

            cbo_rota.DataSource = Helper.getDataView(dslinha.Tables(0), "nm_linha")
            cbo_rota.DataTextField = "nm_linha"
            cbo_rota.DataValueField = "id_linha"
            cbo_rota.DataBind()
            cbo_rota.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim frete As New FreteTabela
            frete.id_frete_tabela = -1
            frete.id_frete_tabela_excecao = -1
            Dim dsgrid As DataSet = frete.getFreteTabelaByFilters
            Dim dr As DataRow = dsgrid.Tables(0).NewRow()
            dsgrid.Tables(0).Rows.InsertAt(dr, 0)

            ViewState.Item("temlinhas") = False
            grdFrete.Visible = True
            grdFrete.DataSource = Helper.getDataView(dsgrid.Tables(0), ViewState.Item("sortExpression"))
            grdFrete.DataBind()
            grdFrete.Rows(0).Cells.Clear()
            grdFrete.Rows(0).Cells.Add(New TableCell())
            grdFrete.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            grdFrete.Rows(0).Cells(0).Text = "Não existe nenhuma Tabela de Frete cadastrada."
            grdFrete.Rows(0).Cells(0).ColumnSpan = 7

            dsgrid = frete.getFreteTabelaExcecao
            dr = dsgrid.Tables(0).NewRow()
            dsgrid.Tables(0).Rows.InsertAt(dr, 0)
            ViewState.Item("temlinhasexcecao") = False
            grdExcecao.Visible = True
            grdExcecao.DataSource = Helper.getDataView(dsgrid.Tables(0), ViewState.Item("sortExpression"))
            grdExcecao.DataBind()
            grdExcecao.Rows(0).Cells.Clear()
            grdExcecao.Rows(0).Cells.Add(New TableCell())
            grdExcecao.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            grdExcecao.Rows(0).Cells(0).Text = "Não existe nenhuma Tabela de Frete de Exceção cadastrada."
            grdExcecao.Rows(0).Cells(0).ColumnSpan = 7


            If Not (Request("id_transportador") Is Nothing) Then
                ViewState.Item("id_transportador") = Request("id_transportador")
                If Request("id_cooperativa").ToString.Equals(String.Empty) Then
                    ViewState.Item("id_cooperativa") = "0"
                Else
                    ViewState.Item("id_cooperativa") = Request("id_cooperativa")
                End If
                'grdFrete.Columns(6).Visible = True
                'grdExcecao.Columns(6).Visible = True
                btn_incluir_frete.Visible = True
                btn_incluir_frete_excecao.Visible = True

                loadData()
            Else

            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim frete As New FreteTabela

            frete.id_transportador = ViewState.Item("id_transportador")
            frete.id_cooperativa = ViewState.Item("id_cooperativa")
            frete.st_referencia_vigente = "S"

            Dim dsfrete As DataSet = frete.getFreteTabelaByFilters

            If dsfrete.Tables(0).Rows.Count > 0 Then
                With dsfrete.Tables(0).Rows(0)
                    cbo_estabelecimento.SelectedValue = .Item("id_estabelecimento").ToString
                    cbo_estabelecimento.Enabled = False

                    lbl_nm_transportador.Visible = True
                    hf_id_transportador.Value = ViewState.Item("id_transportador").ToString
                    txt_cd_transportador.Text = .Item("cd_transportador").ToString
                    lbl_nm_transportador.Text = .Item("nm_transportador").ToString
                    btn_lupa_transportador.Visible = False
                    txt_cd_transportador.Enabled = False

                    If ViewState.Item("id_cooperativa") = "0" Then
                        btn_lupa_cooperativa.Visible = False
                        txt_cd_cooperativa.Enabled = False
                    Else
                        lbl_nm_cooperativa.Visible = True
                        lbl_cd_cnpj.Visible = True
                        Me.lbl_nm_cnpj.Visible = True
                        lbl_nm_cooperativa.Text = .Item("nm_cooperativa").ToString
                        lbl_cd_cnpj.Text = .Item("cd_cnpj_cooperativa").ToString
                        hf_id_cooperativa.Value = ViewState.Item("id_cooperativa").ToString
                    End If

                    'controle sistema
                    lbl_modificador.Text = .Item("id_modificador").ToString
                    lbl_dt_modificacao.Text = .Item("dt_modificacao").ToString
                    cbo_situacao.SelectedValue = .Item("id_situacao").ToString


                End With
            End If


            loadGridFrete()
            loadGridExcecao()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadGridExcecao()

        Try
            Dim excecao As New FreteTabela

            excecao.id_estabelecimento = cbo_estabelecimento.SelectedValue
            excecao.id_transportador = hf_id_transportador.Value.ToString
            If hf_id_cooperativa.Value.ToString.Equals(String.Empty) Then
                excecao.id_cooperativa = 0
            Else
                excecao.id_cooperativa = hf_id_cooperativa.Value.ToString
            End If

            Dim dsexcecao As DataSet = excecao.getFreteTabelaExcecao

            If (dsexcecao.Tables(0).Rows.Count > 0) Then
                ViewState.Item("temlinhasexcecao") = True

                grdExcecao.Visible = True
                grdExcecao.DataSource = Helper.getDataView(dsexcecao.Tables(0), "dt_inicio desc,id_tipo_frete,nm_tipo_equipamento")
                grdExcecao.DataBind()

            Else
                ViewState.Item("temlinhasexcecao") = False

                'grdExcecao.Visible = False
                grdExcecao.Rows(0).Cells.Clear()
                grdExcecao.Rows(0).Cells.Add(New TableCell())
                grdExcecao.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdExcecao.Rows(0).Cells(0).Text = "Não existe nenhuma Tabela de Frete de Exceção cadastrada."
                grdExcecao.Rows(0).Cells(0).ColumnSpan = 7
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadGridFrete()

        Try
            Dim frete As New FreteTabela
            ViewState.Item("precisaaprovacao1nivel") = False
            ViewState.Item("precisaaprovacao2nivel") = False

            frete.id_estabelecimento = cbo_estabelecimento.SelectedValue
            frete.id_transportador = hf_id_transportador.Value.ToString
            If hf_id_cooperativa.Value.ToString.Equals(String.Empty) Then
                frete.id_cooperativa = 0
            Else
                frete.id_cooperativa = hf_id_cooperativa.Value.ToString
            End If
            frete.st_referencia_vigente = "S"

            Dim dsfrete As DataSet = frete.getFreteTabelaByFilters

            If (dsfrete.Tables(0).Rows.Count > 0) Then
                ViewState.Item("temlinhas") = True

                grdFrete.Visible = True
                grdFrete.DataSource = Helper.getDataView(dsfrete.Tables(0), "id_tipo_frete,nm_tipo_equipamento")
                grdFrete.DataBind()

                'se alguma linha  esta aprovada
                If ViewState.Item("precisaaprovacao1nivel") = True OrElse ViewState.Item("precisaaprovacao2nivel") = True Then
                    grdFrete.Columns.Item(10).Visible = True
                    lk_email.Enabled = True
                Else
                    grdFrete.Columns.Item(10).Visible = False
                    lk_email.Enabled = False
                End If
            Else
                ViewState.Item("temlinhas") = False
                lk_email.Enabled = False

                grdFrete.Rows(0).Cells.Clear()
                grdFrete.Rows(0).Cells.Add(New TableCell())
                grdFrete.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdFrete.Rows(0).Cells(0).Text = "Não existe nenhuma Tabela de Frete cadastrada."
                grdFrete.Rows(0).Cells(0).ColumnSpan = 13
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub updateData()
    '    If Page.IsValid Then

    '        Try

    '            Dim poupancaparam As New PoupancaParametro()

    '            'Parâmetros
    '            poupancaparam.id_estabelecimento = cbo_estabelecimento.SelectedValue

    '            poupancaparam.dt_referencia_ini = DateTime.Parse("01/" & txt_referencia_ini.Text).ToString("dd/MM/yyyy")
    '            poupancaparam.dt_referencia_fim = DateTime.Parse("01/" & txt_referencia_fim.Text).ToString("dd/MM/yyyy")

    '            'BNUS ADESAO
    '            poupancaparam.nr_bonus_1ano = txt_nr_bonus_1ano.Text
    '            poupancaparam.nr_bonus_2ano = txt_nr_bonus_2ano.Text
    '            poupancaparam.nr_bonus_3ano = txt_nr_bonus_3ano.Text

    '            'BNUS EXTRA CENTRAL
    '            poupancaparam.nr_spend_periodo = txt_nr_spend_periodo.Text
    '            poupancaparam.nr_bonus_extra_1ano = txt_nr_bonus_extra_1ano.Text
    '            poupancaparam.nr_bonus_extra_2ano = txt_nr_bonus_extra_2ano.Text
    '            poupancaparam.nr_bonus_extra_3ano = txt_nr_bonus_extra_3ano.Text

    '            poupancaparam.id_modificador = Session("id_login")


    '            If Not (ViewState.Item("id_poupanca_parametro") Is Nothing) Then

    '                poupancaparam.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro"))
    '                'se nao temm calculo poupanca para o  periodo de poupanca
    '                'Entao pode atualizar qualquer campo de bonus
    '                If ViewState.Item("PoupancaUltimoCalculo").ToString.Equals(String.Empty) Then
    '                    poupancaparam.updatePoupancaParametro()
    '                Else
    '                    'se tem calculo definitivo, so pode alterar bonus poupanca pois é utilizado apenas no calculo de poupanca na finalizacao
    '                    poupancaparam.updatePoupancaParametroBonusCentral()
    '                End If
    '                messageControl.Alert("Registro alterado com sucesso.")

    '            Else

    '                ViewState.Item("id_poupanca_parametro") = poupancaparam.insertPoupancaParametro()
    '                messageControl.Alert("Registro inserido com sucesso.")

    '            End If

    '            loadData()

    '        Catch ex As Exception
    '            messageControl.Alert(ex.Message)
    '        End Try
    '    End If

    'End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_frete_tabela_frete.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_frete_tabela_frete.aspx")
    End Sub



    'Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
    '    updateData()
    'End Sub

    'Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
    '    updateData()
    'End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_frete_tabela_frete.aspx")

    End Sub

    'Protected Sub cv_parametroqualidade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_tabelafrete.ServerValidate

    '    'Try
    '    '    Dim lmsg As String
    '    '    Dim qualidade As New PoupancaParametroQualidade
    '    '    Dim dsqualidade As DataSet

    '    '    args.IsValid = True

    '    '    qualidade.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro"))

    '    '    If cbo_categoria_qualidade.Enabled = True Then
    '    '        qualidade.id_categoria = cbo_categoria_qualidade.SelectedValue
    '    '    End If
    '    '    If chk_antib_analises.Items(0).Selected = True Then 'rejeição antibiotico
    '    '        qualidade.st_rejeicao_antibiotico = "S"
    '    '    Else
    '    '        qualidade.st_rejeicao_antibiotico = "N"
    '    '    End If

    '    '    If chk_antib_analises.Items(1).Selected = True Then 'analises romaneios
    '    '        qualidade.st_analises_romaneio = "S"
    '    '    Else
    '    '        qualidade.st_analises_romaneio = "N"
    '    '    End If

    '    '    qualidade.dt_referencia_ini = DateTime.Parse("01/" & txt_dt_inicio.Text).ToString("dd/MM/yyyy")

    '    '    'Busca todos os parametros de qualidade cadastrados para o id_poupanca_parametro e categoria informado onde data inicial seja maior que a data informada ou a data final seja maior que data informada
    '    '    '(deve verificar se o periodo a ser inserido ja existe no banco)
    '    '    If qualidade.getPoupancaParametroQualidadeConsInclusao.Tables(0).Rows.Count > 0 Then
    '    '        args.IsValid = False
    '    '        lmsg = "A categoria selecionada já existe para o período de validade informado."
    '    '    End If
    '    '    If (CDate("01/" & txt_dt_inicio.Text) > CDate("01/" & txt_dt_fim_validade.Text)) Then
    '    '        args.IsValid = False
    '    '        lmsg = "A data inicial do período de validade não pode ser maior que a data final do período."
    '    '    End If

    '    '    If (CDate("01/" & txt_dt_inicio.Text) < CDate("01/" & txt_referencia_ini.Text)) Or (CDate("01/" & txt_dt_inicio.Text) > CDate("01/" & txt_referencia_fim.Text)) Then
    '    '        args.IsValid = False
    '    '        lmsg = "Data de início de qualidade deve estar entre o ínicio e fim do período da Poupança."
    '    '    End If
    '    '    If (CDate("01/" & txt_dt_fim.Text) < CDate("01/" & txt_referencia_ini.Text)) Or (CDate("01/" & txt_dt_fim.Text) > CDate("01/" & txt_referencia_fim.Text)) Then
    '    '        args.IsValid = False
    '    '        lmsg = "Data final de qualidade deve estar entre o ínicio e fim do período da Poupança."
    '    '    End If

    '    '    If Not (lbl_ultimo_calculo_poupanca.Text.Equals(String.Empty)) AndAlso (CDate("01/" & txt_dt_inicio.Text) <= CDate("01/" & lbl_ultimo_calculo_poupanca.Text)) Then
    '    '        args.IsValid = False
    '    '        lmsg = "O início do período de validade deve ser maior que a última referência de cálculo de poupança."
    '    '    End If

    '    '    If Not args.IsValid Then
    '    '        messageControl.Alert(lmsg)
    '    '    End If


    '    'Catch ex As Exception
    '    '    messageControl.Alert(ex.Message)
    '    'End Try



    'End Sub

    Protected Sub grdFrete_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdFrete.PageIndexChanging
        grdFrete.PageIndex = e.NewPageIndex

    End Sub

    'Protected Sub grdQualidade_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdFrete.RowCancelingEdit
    '    Try

    '        grdFrete.EditIndex = -1
    '        loadData()
    '        'loadgridcompartimento()
    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try
    'End Sub

    Protected Sub grdFrete_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdFrete.RowCommand
        Select Case e.CommandName.Trim.ToString

            Case "delete"
                deleteFreteTabela(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select
    End Sub
    Private Sub deleteFreteTabela(ByVal id As Integer)

        Try

            Dim frete As New FreteTabela()
            frete.id_frete_tabela = id
            frete.id_modificador = Convert.ToInt32(Session("id_login"))
            frete.deleteFreteTabela()
            messageControl.Alert("Registro desativado com sucesso!")
            loadGridFrete()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub deleteFreteTabelaExcecao(ByVal id As Integer)

        Try

            Dim frete As New FreteTabela()
            frete.id_frete_tabela_excecao = id
            frete.id_modificador = Convert.ToInt32(Session("id_login"))
            frete.deleteFreteTabelaExcecao()
            messageControl.Alert("Registro desativado com sucesso!")
            loadGridExcecao()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub grdFrete_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdFrete.RowDataBound
        If ViewState.Item("temlinhas") = True Then

            If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            Else
                If e.Row.RowType = DataControlRowType.DataRow Then

                    Dim lbl_dt_referencia_ini As Label = CType(e.Row.FindControl("lbl_dt_referencia_ini"), Label)
                    Dim lbl_id_situacao_aprovacao As Label = CType(e.Row.FindControl("lbl_id_situacao_aprovacao"), Label)


                    lbl_dt_referencia_ini.Text = DateTime.Parse(lbl_dt_referencia_ini.Text).ToString("MM/yyyy")
                    'se situacao aprovacao 2a nivel
                    Select Case lbl_id_situacao_aprovacao.Text
                        Case "1", "3", "5"
                            ViewState.Item("precisaaprovacao1nivel") = True
                        Case "2"
                            ViewState.Item("precisaaprovacao2nivel") = True

                    End Select


                End If
            End If
        End If
    End Sub

    Protected Sub grdFrete_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdFrete.RowDeleting
        e.Cancel = True

    End Sub

    'Protected Sub grdQualidade_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdFrete.RowEditing
    '    Try

    '        grdFrete.EditIndex = e.NewEditIndex
    '        loadData()

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    Protected Sub grdFrete_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdFrete.RowUpdating
        Dim row As GridViewRow = grdFrete.Rows(e.RowIndex)
        Try
            'If Page.IsValid Then


            '    If (Not (row) Is Nothing) Then

            '        Dim qualidade As New PoupancaParametroQualidade

            '        Dim lbl_id_poupanca_parametro_qualidade As Label = CType(row.FindControl("lbl_id_poupanca_parametro_qualidade"), Label)
            '        Dim txt_dt_referencia_fim_qualidade As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_referencia_fim_qualidade"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)

            '        qualidade.dt_referencia_fim = DateTime.Parse(String.Concat("01/", txt_dt_referencia_fim_qualidade.Text)).ToString("dd/MM/yyyy")
            '        qualidade.id_modificador = Session("id_login")
            '        qualidade.id_poupanca_parametro_qualidade = Convert.ToInt32(lbl_id_poupanca_parametro_qualidade.Text)
            '        qualidade.updatePoupancaParametroQualidade()
            '        grdFrete.EditIndex = -1

            '        'loadParamQualidade()

            '    End If
            'End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    'Protected Sub cv_parametros_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_parametros.ServerValidate
    '    'Try
    '    '    Dim lmsg As String
    '    '    Dim parametro As New PoupancaParametro

    '    '    args.IsValid = True
    '    '    parametro.id_estabelecimento = cbo_estabelecimento.SelectedValue
    '    '    parametro.dt_referencia_ini = DateTime.Parse(String.Concat("01/", txt_referencia_ini.Text)).ToString("dd/MM/yyyy")

    '    '    'Busca todos os periodos de poupança qualidade cadastrados para oestabelecimento informado
    '    '    '(deve verificar se o periodo a ser inserido ja existe no banco)
    '    '    If parametro.getPoupancaParametroConsInclusao.Tables(0).Rows.Count > 0 Then
    '    '        args.IsValid = False
    '    '        lmsg = "O período da Poupança informado já existe no sistema para o estabelecimento selecionado."
    '    '    End If

    '    '    If (CDate("01/" & txt_referencia_ini.Text) >= CDate("01/" & txt_referencia_fim.Text)) Then
    '    '        args.IsValid = False
    '    '        lmsg = "A data inicial do período de referência não pode ser maior ou igual à data final do período."
    '    '    End If



    '    '    If Not args.IsValid Then
    '    '        messageControl.Alert(lmsg)
    '    '    End If


    '    'Catch ex As Exception
    '    '    messageControl.Alert(ex.Message)
    '    'End Try
    'End Sub

    'Protected Sub btn_incluirqualidade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluirqualidade.Click
    '    If Page.IsValid Then

    '        Try

    '            Dim poupancaparamqualidade As New PoupancaParametroQualidade()

    '            'Parâmetros
    '            poupancaparamqualidade.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
    '            poupancaparamqualidade.dt_referencia_ini = DateTime.Parse("01/" & txt_dt_inicio.Text).ToString("dd/MM/yyyy")
    '            poupancaparamqualidade.dt_referencia_fim = DateTime.Parse("01/" & txt_dt_fim_validade.Text).ToString("dd/MM/yyyy")
    '            If cbo_categoria_qualidade.SelectedValue.Equals(String.Empty) Then
    '                poupancaparamqualidade.id_categoria = 0
    '            Else
    '                poupancaparamqualidade.id_categoria = cbo_categoria_qualidade.SelectedValue
    '            End If

    '            poupancaparamqualidade.id_modificador = Session("id_login")

    '            'se os dois tipos de analise estão  selecionadas inclui uma linnha para cada check
    '            If chk_antib_analises.Items(0).Selected = True OrElse chk_antib_analises.Items(1).Selected = True Then 'se analise romaneio ou antibiotico está selecionada
    '                poupancaparamqualidade.nr_faixa_inicio = 0
    '                poupancaparamqualidade.nr_faixa_fim = 0

    '                If chk_antib_analises.Items(0).Selected = True Then 'rejeicao antibioticoa
    '                    poupancaparamqualidade.st_rejeicao_antibiotico = "S"
    '                    poupancaparamqualidade.st_analises_romaneio = "N"
    '                    poupancaparamqualidade.insertPoupancaParametroQualidade() 'insere parametro de qualidade de antibiotica
    '                End If
    '                If chk_antib_analises.Items(1).Selected = True Then
    '                    poupancaparamqualidade.st_analises_romaneio = "S"
    '                    poupancaparamqualidade.st_rejeicao_antibiotico = "N"
    '                    poupancaparamqualidade.insertPoupancaParametroQualidade() 'insere parametro de qualidade de nalaise de romaneio
    '                End If
    '            Else
    '                poupancaparamqualidade.st_rejeicao_antibiotico = "N"
    '                poupancaparamqualidade.st_analises_romaneio = "N"
    '                poupancaparamqualidade.nr_faixa_inicio = txt_faixa_inicial.Text
    '                poupancaparamqualidade.nr_faixa_fim = txt_faixa_final.Text
    '                poupancaparamqualidade.insertPoupancaParametroQualidade()
    '            End If

    '            messageControl.Alert("Registro inserido com sucesso.")


    '            loadParamQualidade()

    '        Catch ex As Exception
    '            messageControl.Alert(ex.Message)
    '        End Try
    '    End If

    'End Sub

    '    Protected Sub cv_parametrogrid_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
    '        Try
    '            Dim wc As WebControl = CType(source, WebControl)
    '            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
    '            Dim lbl_dt_referencia_ini As Label = CType(row.FindControl("lbl_dt_referencia_ini"), Label)
    '            Dim txt_dt_referencia_fim_qualidade As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_referencia_fim_qualidade"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
    '            Dim lmsg As String
    '            args.IsValid = True

    '            If (CDate(txt_dt_referencia_fim_qualidade.Text) <= CDate(lbl_calculo_definitivo.Text)) Then
    '                args.IsValid = False
    '                lmsg = "A data do Período Fim deve ser maior que a última referência de cálculo definitivo."
    '            End If

    '            If (CDate(txt_dt_referencia_fim_qualidade.Text) > CDate(Me.txt_referencia_fim.Text)) Then
    '                args.IsValid = False
    '                lmsg = "Período Fim deve ser menor que o Período de Referência final da Poupança."
    '            End If


    '            If args.IsValid = False Then
    '                messageControl.Alert(lmsg)
    '            End If

    '        Catch ex As Exception
    '            messageControl.Alert(ex.Message)
    '        End Try

    '    End Sub

    '    Protected Sub chk_antib_analises_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_antib_analises.SelectedIndexChanged

    '        If chk_antib_analises.Items(0).Selected = True OrElse chk_antib_analises.Items(1).Selected = True Then  'se analise romaneio ou antibiotico está selecionada
    '            cbo_categoria_qualidade.SelectedValue = String.Empty
    '            cbo_categoria_qualidade.Enabled = False
    '            txt_faixa_inicial.Text = String.Empty
    '            txt_faixa_final.Text = String.Empty
    '            txt_faixa_inicial.Enabled = False
    '            txt_faixa_final.Enabled = False
    '            cv_faixainicialfinal.Visible = False
    '            rfv_custokm.Enabled = False
    '            rfv_faixafinal.Enabled = False
    '            rfv_custofixodiaria.Enabled = False
    '        Else
    '            cbo_categoria_qualidade.Enabled = True
    '            txt_faixa_inicial.Enabled = True
    '            txt_faixa_final.Enabled = True
    '            cv_faixainicialfinal.Visible = True
    '            rfv_custokm.Enabled = True
    '            rfv_faixafinal.Enabled = True
    '            rfv_custofixodiaria.Enabled = True

    '        End If
    '    End Sub

    '    Protected Sub cbo_tipofrete_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipofrete.SelectedIndexChanged
    '        If cbo_tipofrete.SelectedValue = "T1" Then
    '            tr()
    '        End If
    '    End Sub

    Protected Sub btn_incluir_frete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluir_frete.Click
        If Page.IsValid Then
            Dim frete As New FreteTabela
            frete.id_estabelecimento = cbo_estabelecimento.SelectedValue
            frete.id_transportador = hf_id_transportador.Value
            If hf_id_cooperativa.Value.Equals(String.Empty) Then
                frete.id_cooperativa = 0
            Else
                frete.id_cooperativa = hf_id_cooperativa.Value
            End If
            frete.id_tipo_frete = cbo_tipofrete.SelectedValue
            frete.id_tipo_equipamento = cbo_tipo_equipamento.SelectedValue
            frete.dt_validade = String.Concat("01/", txt_dt_inicio.Text).ToString
            If txt_custofixodiaria.Text = "" Then
                frete.nr_custo_fixo_diaria = 0
            Else
                frete.nr_custo_fixo_diaria = CDec(txt_custofixodiaria.Text)
            End If
            If txt_custokm.Text = "" Then
                frete.nr_custo_km = 0
            Else
                frete.nr_custo_km = CDec(txt_custokm.Text)
            End If
            If txt_nr_custo_fixo_mes.Text = "" Then
                frete.nr_custo_fixo_mes = 0
            Else
                frete.nr_custo_fixo_mes = CDec(txt_nr_custo_fixo_mes.Text)
            End If
            frete.id_custo_fixo_mes_tipo = cbo_custo_mensal_tipo.SelectedValue

            If txt_nr_veiculos.Text = "" Then
                frete.nr_custo_fixo_mes_veiculos = 0
            Else
                frete.nr_custo_fixo_mes_veiculos = CInt(txt_nr_veiculos.Text)
            End If
            If txt_seguro_carga.Text = "" Then
                frete.nr_perc_seguro_carga = 0
            Else
                frete.nr_perc_seguro_carga = CDec(txt_seguro_carga.Text)
            End If
            frete.id_modificador = Session("id_login")

            frete.insertFreteTabela()
            loadGridFrete()

        End If

    End Sub


    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        lbl_nm_transportador.Text = String.Empty
        lbl_nm_transportador.Visible = False
        hf_id_transportador.Value = String.Empty

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

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
        Else
            txt_cd_transportador.Text = String.Empty
            hf_id_transportador.Value = String.Empty
            lbl_nm_transportador.Text = String.Empty
            lbl_nm_transportador.Visible = False
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
    Private Sub carregarCamposTransportador()

        Try

            If Not (customPage.getFilterValue("lupa_transcoop", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transcoop", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transcoop", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transcoop", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_transcoop")


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
                ViewState.Item("id_estado_cooperativa") = dscooperativa.Tables(0).Rows(0).Item("id_estado")
            Else
                lbl_nm_cooperativa.Visible = False
                lbl_cd_cnpj.Visible = False
                Me.lbl_nm_cnpj.Visible = False
                hf_id_cooperativa.Value = String.Empty
                ViewState.Item("id_estado_cooperativa") = 0
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

    Protected Sub cv_tabelafrete_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_tabelafrete.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True

            If hf_id_cooperativa.Value.Equals(String.Empty) Then
                If cbo_tipofrete.SelectedValue = 2 Then
                    args.IsValid = False
                    lmsg = "Para o tipo de Frete 'T2' a cooperativa deve ser informada!"
                End If
            Else
                Select Case cbo_tipofrete.SelectedValue
                    Case 1, 3, 4
                        args.IsValid = False
                        lmsg = "Para tabela de Frete por Cooperativa o tipo de frete deve ser 'T2'!"
                End Select
            End If

            If txt_custokm.Text.Equals(String.Empty) OrElse CDbl(txt_custokm.Text).Equals(0) Then
                If txt_custofixodiaria.Text.Equals(String.Empty) OrElse CDbl(txt_custofixodiaria.Text).Equals(0) Then
                    If txt_nr_custo_fixo_mes.Text.Equals(String.Empty) OrElse CDbl(txt_nr_custo_fixo_mes.Text).Equals(0) Then

                        args.IsValid = False
                        lmsg = "Para incluir Tabela de Frete custo do KM ou custo fixo diária ou custo fixo mensal deve ser informado!"

                    End If

                End If
            End If

            If Not txt_custofixodiaria.Text.Equals(String.Empty) AndAlso CDbl(txt_custofixodiaria.Text) > 0 Then
                If Not txt_nr_custo_fixo_mes.Text.Equals(String.Empty) AndAlso CDbl(txt_nr_custo_fixo_mes.Text) > 0 Then
                    args.IsValid = False
                    lmsg = "Os campos 'Custo Fixo Diária' e 'Custo Fixo Mensal' não podem ser informados ao mesmo tempo."

                End If

            End If

            If args.IsValid = True Then
                If txt_nr_custo_fixo_mes.Text.Equals(String.Empty) OrElse CDbl(txt_nr_custo_fixo_mes.Text).Equals(0) Then

                    If cbo_custo_mensal_tipo.SelectedValue <> "0" Then
                        args.IsValid = False
                        lmsg = "O campo 'Calcular o Custo Fixo Mensal Por' deve ser informado apenas quando o custo da tabela for FIXO MENSAL."

                    End If

                Else
                    Select Case cbo_custo_mensal_tipo.SelectedValue
                        Case 0
                            args.IsValid = False
                            lmsg = "O campo 'Calcular o Custo Fixo Mensal Por' deve ser informado."
                        Case 1 'se tipo for nr veiculos acordados
                            If txt_nr_veiculos.Text.Equals(String.Empty) OrElse CInt(txt_nr_veiculos.Text).Equals(0) Then
                                args.IsValid = False
                                lmsg = "O campo 'Nr Veículos' deve ser informado."
                            End If

                    End Select

                End If
            End If
            If args.IsValid Then
                Dim frete As New FreteTabela
                frete.id_estabelecimento = cbo_estabelecimento.SelectedValue
                frete.id_transportador = hf_id_transportador.Value
                If hf_id_cooperativa.Value.Equals(String.Empty) Then
                    frete.id_cooperativa = 0
                Else
                    frete.id_cooperativa = hf_id_cooperativa.Value
                End If
                frete.id_tipo_frete = cbo_tipofrete.SelectedValue
                frete.id_tipo_equipamento = cbo_tipo_equipamento.SelectedValue
                frete.dt_validade = String.Concat("01/", txt_dt_inicio.Text)

                If frete.getFreteTabelaConsValidade.Tables(0).Rows.Count > 0 Then
                    args.IsValid = False
                    lmsg = "A validade informada não pode ser menor ou igual à referências válidas já cadastradas para a Tabela de Frete, para o mesmo transportador, tipo de frete, tipo de equipamento."

                End If
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_incluir_frete_excecao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluir_frete_excecao.Click
        If Page.IsValid Then
            Dim freteexcecao As New FreteTabela
            freteexcecao.id_estabelecimento = cbo_estabelecimento.SelectedValue
            freteexcecao.id_transportador = hf_id_transportador.Value
            If hf_id_cooperativa.Value.Equals(String.Empty) Then
                freteexcecao.id_cooperativa = 0
            Else
                freteexcecao.id_cooperativa = hf_id_cooperativa.Value
            End If
            freteexcecao.id_tipo_frete = cbo_tipo_frete_excecao.SelectedValue
            freteexcecao.id_tipo_equipamento = cbo_tipo_equipamento_excecao.SelectedValue
            freteexcecao.id_linha = cbo_rota.SelectedValue
            freteexcecao.dt_inicio = txt_dt_ini_validade.Text
            freteexcecao.dt_fim = txt_dt_fim_validade.Text
            If txt_custokmexcecao.Text = "" Then
                freteexcecao.nr_custo_km = 0
            Else
                freteexcecao.nr_custo_km = CDec(txt_custokmexcecao.Text)
            End If
            If txt_custofixodiariaexcecao.Text = "" Then
                freteexcecao.nr_custo_fixo_diaria = 0
            Else
                freteexcecao.nr_custo_fixo_diaria = CDec(txt_custofixodiariaexcecao.Text)
            End If
            If txt_custofixomesexcecao.Text = "" Then
                freteexcecao.nr_custo_fixo_mes = 0
            Else
                freteexcecao.nr_custo_fixo_mes = CDec(txt_custofixomesexcecao.Text)
            End If
            freteexcecao.id_custo_fixo_mes_tipo = cbo_customestipoexcecao.SelectedValue

            If txt_nr_veiculos_excecao.Text = "" Then
                freteexcecao.nr_custo_fixo_mes_veiculos = 0
            Else
                freteexcecao.nr_custo_fixo_mes_veiculos = CInt(txt_nr_veiculos_excecao.Text)
            End If


            freteexcecao.id_modificador = Session("id_login")

            freteexcecao.insertFreteTabelaExcecao()
            loadGridExcecao()

        End If
    End Sub

    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidtransportador As Int32
            If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_transportador.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
            lidtransportador = pessoa.validarTransportadorCooperativa

            If lidtransportador > 0 Then
                args.IsValid = True
                hf_id_transportador.Value = lidtransportador
            Else
                hf_id_transportador.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Transportador não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdExcecao_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdExcecao.RowCommand
        Select Case e.CommandName.Trim.ToString

            Case "delete"
                deleteFreteTabelaExcecao(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub


    Protected Sub cbo_custo_mensal_tipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_custo_mensal_tipo.SelectedIndexChanged
        If cbo_custo_mensal_tipo.SelectedValue = "1" Then
            txt_nr_veiculos.Enabled = True
        Else
            txt_nr_veiculos.Text = String.Empty
            txt_nr_veiculos.Enabled = False
        End If
    End Sub

    Protected Sub cbo_customestipoexcecao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_customestipoexcecao.SelectedIndexChanged
        If cbo_customestipoexcecao.SelectedValue = "1" Then
            txt_nr_veiculos_excecao.Enabled = True
        Else
            txt_nr_veiculos_excecao.Text = String.Empty
            txt_nr_veiculos_excecao.Enabled = False
        End If

    End Sub

    Protected Sub cv_freteexcecao_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_freteexcecao.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True

            If hf_id_cooperativa.Value.Equals(String.Empty) Then
                If cbo_tipofrete.SelectedValue = 2 Then
                    args.IsValid = False
                    lmsg = "Para o tipo de Frete 'T2' a cooperativa deve ser informada!"
                End If
            Else
                Select Case cbo_tipofrete.SelectedValue
                    Case 1, 3, 4
                        args.IsValid = False
                        lmsg = "Para tabela de Frete por Cooperativa o tipo de frete deve ser 'T2'!"
                End Select
            End If

            If txt_custokmexcecao.Text.Equals(String.Empty) OrElse CDbl(txt_custokmexcecao.Text).Equals(0) Then
                If txt_custofixodiariaexcecao.Text.Equals(String.Empty) OrElse CDbl(txt_custofixodiariaexcecao.Text).Equals(0) Then
                    If txt_custofixomesexcecao.Text.Equals(String.Empty) OrElse CDbl(txt_custofixomesexcecao.Text).Equals(0) Then

                        args.IsValid = False
                        lmsg = "Para incluir Tabela de Frete de Exceção custo do KM ou custo fixo diária ou custo fixo mensal deve ser informado!"

                    End If

                End If
            End If

            If Not txt_custofixodiariaexcecao.Text.Equals(String.Empty) AndAlso CDbl(txt_custofixodiariaexcecao.Text) > 0 Then
                If Not txt_custofixomesexcecao.Text.Equals(String.Empty) AndAlso CDbl(txt_custofixomesexcecao.Text) > 0 Then
                    args.IsValid = False
                    lmsg = "Para incluir Tabela de Frete de Exceção os campos 'Custo Fixo Diária' e 'Custo Fixo Mensal' não podem ser informados ao mesmo tempo."

                End If

            End If

            If args.IsValid = True Then
                If txt_custofixomesexcecao.Text.Equals(String.Empty) OrElse CDbl(txt_custofixomesexcecao.Text).Equals(0) Then

                    If cbo_customestipoexcecao.SelectedValue <> "0" Then
                        args.IsValid = False
                        lmsg = "O campo 'Calcular o Custo Fixo Mensal Por' deve ser informado apenas quando o custo da tabela exceção for FIXO MENSAL."

                    End If

                Else
                    Select Case cbo_customestipoexcecao.SelectedValue
                        Case "0"
                            args.IsValid = False
                            lmsg = "O campo 'Calcular o Custo Fixo Mensal Por' deve ser informado."
                        Case "1" 'se tipo for nr veiculos acordados
                            If txt_nr_veiculos_excecao.Text.Equals(String.Empty) OrElse CInt(txt_nr_veiculos_excecao.Text).Equals(0) Then
                                args.IsValid = False
                                lmsg = "O campo 'Nr Veículos' deve ser informado pára Tabela Frete Exceção."
                            End If

                    End Select

                End If
            End If
            'If args.IsValid Then
            '    Dim frete As New FreteTabela
            '    frete.id_estabelecimento = cbo_estabelecimento.SelectedValue
            '    frete.id_transportador = hf_id_transportador.Value
            '    If hf_id_cooperativa.Value.Equals(String.Empty) Then
            '        frete.id_cooperativa = 0
            '    Else
            '        frete.id_cooperativa = hf_id_cooperativa.Value
            '    End If
            '    frete.id_tipo_frete = cbo_tipofrete.SelectedValue
            '    frete.id_tipo_equipamento = cbo_tipo_equipamento.SelectedValue
            '    frete.dt_validade = String.Concat("01/", txt_dt_inicio.Text)

            '    If frete.getFreteTabelaConsValidade.Tables(0).Rows.Count > 0 Then
            '        args.IsValid = False
            '        lmsg = "A validade informada não pode ser menor ou igual à referências válidas já cadastradas para a Tabela de Frete, para o mesmo transportador, tipo de frete, tipo de equipamento."

            '    End If
            'End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        If Page.IsValid = True Then
            Try

                Dim notificacao As New Notificacao
                If ViewState.Item("precisaaprovacao1nivel") = True Then ' se em aprovacao
                    Dim lAssunto As String = "Aprovação 1.o Nível de Frete (Tabela de Frete)"
                    Dim lCorpo As String = "Existem itens de Frete, da Tabela de Frete para cálculo de frete, pendente(s) para aprovação 1.o Nível."

                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 9 'e-mail
                    usuariolog.id_menu_item = 255
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    ' Parametro 21 - tabella frete 1.o Nível
                    If notificacao.enviaMensagemEmail(29, lAssunto, lCorpo, MailPriority.High) = True Then
                        messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível foi enviada aos destinatários com sucesso!")
                    Else
                        messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")
                    End If
                Else
                    If ViewState.Item("precisaaprovacao2nivel") = True Then ' se aprovado 1 nivel
                        Dim lAssunto As String = "Aprovação 2.o Nível de Frete (Tabela de Frete)"
                        Dim lCorpo As String = "Existem itens de Frete, da Tabela de Frete para cálculo de frete, pendente(s) para aprovação 2.o Nível."
                        If notificacao.enviaMensagemEmail(30, lAssunto, lCorpo, MailPriority.High) = True Then
                            messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível foi enviada aos destinatários com sucesso!")
                        Else
                            messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")
                        End If
                    End If

                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        End If

    End Sub
End Class
