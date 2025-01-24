Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_poupanca_parametro
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_poupanca_parametro.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

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

            Dim categoria As New CategoriaQualidade

            cbo_categoria_qualidade.DataSource = categoria.getCategoriaByFilters()
            cbo_categoria_qualidade.DataTextField = "nm_categoria"
            cbo_categoria_qualidade.DataValueField = "id_categoria"
            cbo_categoria_qualidade.DataBind()
            cbo_categoria_qualidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            If Not (Request("id_poupanca_parametro") Is Nothing) Then
                ViewState.Item("id_poupanca_parametro") = Request("id_poupanca_parametro")

                loadData()
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim poupancaparam As New PoupancaParametro(Convert.ToInt32(ViewState.Item("id_poupanca_parametro")))


            tr_qualidade.Visible = True 'visualiza grid qualidade

            'Parâmetros
            cbo_estabelecimento.SelectedValue = poupancaparam.id_estabelecimento
            cbo_estabelecimento.Enabled = False

            txt_referencia_ini.Text = DateTime.Parse(poupancaparam.dt_referencia_ini).ToString("MM/yyyy")
            txt_referencia_fim.Text = DateTime.Parse(poupancaparam.dt_referencia_fim).ToString("MM/yyyy")
            txt_referencia_ini.Enabled = False
            txt_referencia_fim.Enabled = False

            lbl_nm_situacao_poupanca.Text = poupancaparam.nm_situacao_poupanca.ToString

            'BNUS ADESAO
            txt_nr_bonus_1ano.Text = poupancaparam.nr_bonus_1ano.ToString
            txt_nr_bonus_2ano.Text = poupancaparam.nr_bonus_2ano.ToString
            txt_nr_bonus_3ano.Text = poupancaparam.nr_bonus_3ano.ToString

            'BNUS EXTRA CENTRAL
            txt_nr_spend_periodo.Text = poupancaparam.nr_spend_periodo.ToString
            txt_nr_bonus_extra_1ano.Text = poupancaparam.nr_bonus_extra_1ano.ToString
            txt_nr_bonus_extra_2ano.Text = poupancaparam.nr_bonus_extra_2ano.ToString
            txt_nr_bonus_extra_3ano.Text = poupancaparam.nr_bonus_extra_3ano.ToString

            'Verifica se já existe referencia comm calculo definitivo para o perido de poupanca
            Dim calculodefinitivo As New CalculoProdutor
            calculodefinitivo.dt_referencia_start = DateTime.Parse(poupancaparam.dt_referencia_ini).ToString("dd/MM/yyyy")
            calculodefinitivo.dt_referencia_end = DateTime.Parse(poupancaparam.dt_referencia_fim).ToString("dd/MM/yyyy")
            ViewState.Item("CalculoDefinitivo") = calculodefinitivo.getCalculoDefinitivoByPeriodo

            If (ViewState.Item("CalculoDefinitivo") Is Nothing) Then
                ViewState.Item("CalculoDefinitivo") = String.Empty
            End If

            'Verifica se já existe referencia comm calculo de poupanca para o perido de poupanca
            Dim poupanca As New Poupanca
            poupanca.id_estabelecimento = poupancaparam.id_estabelecimento
            poupanca.dt_referencia_ini = DateTime.Parse(poupancaparam.dt_referencia_ini).ToString("dd/MM/yyyy")
            poupanca.dt_referencia_fim = DateTime.Parse(poupancaparam.dt_referencia_fim).ToString("dd/MM/yyyy")
            ViewState.Item("PoupancaUltimoCalculo") = poupanca.getPoupancaUltimoCalculoMensal
            If (ViewState.Item("PoupancaUltimoCalculo") Is Nothing) Then
                ViewState.Item("PoupancaUltimoCalculo") = String.Empty
            End If


            'PARAMETROS DE QUALIDADE
            loadParamQualidade()

            'controle sistema
            lbl_modificador.Text = poupancaparam.id_modificador.ToString()
            lbl_dt_modificacao.Text = poupancaparam.dt_modificacao.ToString()
            cbo_situacao.SelectedValue = poupancaparam.id_situacao.ToString()

            'CONTROELE VISUAL
            ViewState.Item("id_situacao_poupanca") = poupancaparam.id_situacao_poupanca
            If poupancaparam.id_situacao_poupanca.Equals("2") Then ' se estiver finalizado periodo
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
                btn_incluirqualidade.Enabled = False
                btn_incluirqualidade.ToolTip = "Período de Poupança Finalizado."
                grdQualidade.Columns(6).Visible = False 'Coluna de edição do grid de qualidade deve ficar invisivel
            End If

            'se tem calculo definitivo no periodo
            If Not ViewState.Item("CalculoDefinitivo").Equals(String.Empty) Then
                lbl_calculo_definitivo.Text = DateTime.Parse(ViewState.Item("CalculoDefinitivo")).ToString("MM/yyyy")
            End If

            'se tem calculo poupanca no periodo, bonus não deve ser alterado
            If Not ViewState.Item("PoupancaUltimoCalculo").Equals(String.Empty) Then
                lbl_ultimo_calculo_poupanca.Text = DateTime.Parse(ViewState.Item("PoupancaUltimoCalculo")).ToString("MM/yyyy")
                txt_nr_bonus_1ano.Enabled = False
                txt_nr_bonus_2ano.Enabled = False
                txt_nr_bonus_3ano.Enabled = False
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadParamQualidade()

        Try
            Dim paramQualidade As New PoupancaParametroQualidade


            'preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            paramQualidade.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro").ToString)

            Dim dsqualidade As DataSet = paramQualidade.getPoupancaParametroQualidade()

            If (dsqualidade.Tables(0).Rows.Count > 0) Then
                grdQualidade.Visible = True
                grdQualidade.DataSource = Helper.getDataView(dsqualidade.Tables(0), ViewState.Item("sortExpression"))
                grdQualidade.DataBind()

            Else
                grdQualidade.Visible = False
                'messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub updateData()
        If Page.IsValid Then

            Try

                Dim poupancaparam As New PoupancaParametro()

                'Parâmetros
                poupancaparam.id_estabelecimento = cbo_estabelecimento.SelectedValue

                poupancaparam.dt_referencia_ini = DateTime.Parse("01/" & txt_referencia_ini.Text).ToString("dd/MM/yyyy")
                poupancaparam.dt_referencia_fim = DateTime.Parse("01/" & txt_referencia_fim.Text).ToString("dd/MM/yyyy")

                'BNUS ADESAO
                poupancaparam.nr_bonus_1ano = txt_nr_bonus_1ano.Text
                poupancaparam.nr_bonus_2ano = txt_nr_bonus_2ano.Text
                poupancaparam.nr_bonus_3ano = txt_nr_bonus_3ano.Text

                'BNUS EXTRA CENTRAL
                poupancaparam.nr_spend_periodo = txt_nr_spend_periodo.Text
                poupancaparam.nr_bonus_extra_1ano = txt_nr_bonus_extra_1ano.Text
                poupancaparam.nr_bonus_extra_2ano = txt_nr_bonus_extra_2ano.Text
                poupancaparam.nr_bonus_extra_3ano = txt_nr_bonus_extra_3ano.Text

                poupancaparam.id_modificador = Session("id_login")


                If Not (ViewState.Item("id_poupanca_parametro") Is Nothing) Then

                    poupancaparam.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro"))
                    'se nao temm calculo poupanca para o  periodo de poupanca
                    'Entao pode atualizar qualquer campo de bonus
                    If ViewState.Item("PoupancaUltimoCalculo").ToString.Equals(String.Empty) Then
                        poupancaparam.updatePoupancaParametro()
                    Else
                        'se tem calculo definitivo, so pode alterar bonus poupanca pois é utilizado apenas no calculo de poupanca na finalizacao
                        poupancaparam.updatePoupancaParametroBonusCentral()
                    End If
                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_poupanca_parametro") = poupancaparam.insertPoupancaParametro()
                    messageControl.Alert("Registro inserido com sucesso.")

                End If

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_poupanca_parametro.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_poupanca_parametro.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_balanca.aspx")

    End Sub

    Protected Sub cv_parametroqualidade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_parametroqualidade.ServerValidate

        Try
            Dim lmsg As String
            Dim qualidade As New PoupancaParametroQualidade
            Dim dsqualidade As DataSet

            args.IsValid = True

            qualidade.id_poupanca_parametro = Convert.ToInt32(ViewState.Item("id_poupanca_parametro"))

            If cbo_categoria_qualidade.Enabled = True Then
                qualidade.id_categoria = cbo_categoria_qualidade.SelectedValue
            End If
            If chk_antib_analises.Items(0).Selected = True Then 'rejeição antibiotico
                qualidade.st_rejeicao_antibiotico = "S"
            Else
                qualidade.st_rejeicao_antibiotico = "N"
            End If

            If chk_antib_analises.Items(1).Selected = True Then 'analises romaneios
                qualidade.st_analises_romaneio = "S"
            Else
                qualidade.st_analises_romaneio = "N"
            End If

            qualidade.dt_referencia_ini = DateTime.Parse("01/" & txt_dt_inicio.Text).ToString("dd/MM/yyyy")

            'Busca todos os parametros de qualidade cadastrados para o id_poupanca_parametro e categoria informado onde data inicial seja maior que a data informada ou a data final seja maior que data informada
            '(deve verificar se o periodo a ser inserido ja existe no banco)
            If qualidade.getPoupancaParametroQualidadeConsInclusao.Tables(0).Rows.Count > 0 Then
                args.IsValid = False
                lmsg = "A categoria selecionada já existe para o período de validade informado."
            End If
            If (CDate("01/" & txt_dt_inicio.Text) > CDate("01/" & txt_dt_fim.Text)) Then
                args.IsValid = False
                lmsg = "A data inicial do período de validade não pode ser maior que a data final do período."
            End If

            If (CDate("01/" & txt_dt_inicio.Text) < CDate("01/" & txt_referencia_ini.Text)) Or (CDate("01/" & txt_dt_inicio.Text) > CDate("01/" & txt_referencia_fim.Text)) Then
                args.IsValid = False
                lmsg = "Data de início de qualidade deve estar entre o ínicio e fim do período da Poupança."
            End If
            If (CDate("01/" & txt_dt_fim.Text) < CDate("01/" & txt_referencia_ini.Text)) Or (CDate("01/" & txt_dt_fim.Text) > CDate("01/" & txt_referencia_fim.Text)) Then
                args.IsValid = False
                lmsg = "Data final de qualidade deve estar entre o ínicio e fim do período da Poupança."
            End If

            If Not (lbl_ultimo_calculo_poupanca.Text.Equals(String.Empty)) AndAlso (CDate("01/" & txt_dt_inicio.Text) <= CDate("01/" & lbl_ultimo_calculo_poupanca.Text)) Then
                args.IsValid = False
                lmsg = "O início do período de validade deve ser maior que a última referência de cálculo de poupança."
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try



    End Sub

    Protected Sub grdQualidade_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdQualidade.PageIndexChanging
        grdQualidade.PageIndex = e.NewPageIndex

    End Sub

    Protected Sub grdQualidade_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdQualidade.RowCancelingEdit
        Try

            grdQualidade.EditIndex = -1
            loadData()
            'loadgridcompartimento()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub grdQualidade_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdQualidade.RowCommand
        Select Case e.CommandName.Trim.ToString
           
            Case "delete"
                deleteParametroQualidade(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select
    End Sub
    Private Sub deleteParametroQualidade(ByVal id_poupancaparametroqualidade As Integer)

        Try

            Dim poupancaparametroqualidade As New PoupancaParametroQualidade()
            poupancaparametroqualidade.id_poupanca_parametro_qualidade = id_poupancaparametroqualidade
            poupancaparametroqualidade.id_modificador = Convert.ToInt32(Session("id_login"))
            poupancaparametroqualidade.deletePoupancaParametroQualidade()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub grdQualidade_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdQualidade.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            'so edita o grid de qualidade se situacao poupanca for aberto e calculo definitivo ja tiver sido realizado para periodo
            'Apenas permmite edição da data final de validade da qualidade, sendo que deve ser maior que a data de referencia do ultimo calculo e menor ou igual a data fim periodo
            'Dim cpv_periodofinalpoupanca As Anthem.CompareValidator = CType(e.Row.FindControl("cpv_periodofinalpoupanca"), Anthem.CompareValidator)
            'Dim cpv_calcdefinitivo As Anthem.CompareValidator = CType(e.Row.FindControl("cpv_calcdefinitivo"), Anthem.CompareValidator)

            'If ViewState.Item("CalculoDefinitivo").Equals(String.Empty) Then
            '    cpv_calcdefinitivo.Visible = False
            'Else
            '    cpv_calcdefinitivo.Visible = True
            '    cpv_calcdefinitivo.ValueToCompare = ViewState.Item("CalculoDefinitivo").ToString
            'End If

            'cpv_periodofinalpoupanca.ValueToCompare = txt_referencia_fim.Text.ToString
            Dim txt_dt_referencia_fim_qualidade As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(e.Row.FindControl("txt_dt_referencia_fim_qualidade"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)

            txt_dt_referencia_fim_qualidade.Text = DateTime.Parse(txt_dt_referencia_fim_qualidade.Text).ToString("MM/yyyy")

        Else
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim btn_editar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)
                Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("btn_delete"), Anthem.ImageButton)
                Dim lbl_dt_referencia_ini As Label = CType(e.Row.FindControl("lbl_dt_referencia_ini"), Label)
                Dim lbl_dt_referencia_fim As Label = CType(e.Row.FindControl("lbl_dt_referencia_fim"), Label)
                Dim st_rejeicao_antibiotico As Label = CType(e.Row.FindControl("st_rejeicao_antibiotico"), Label)
                Dim st_analises_romaneio As Label = CType(e.Row.FindControl("st_analises_romaneio"), Label)
                Dim img_rejeicao_antibiotico As Anthem.Image = CType(e.Row.FindControl("img_rejeicao_antibiotico"), Anthem.Image)
                Dim img_analises_romaneio As Anthem.Image = CType(e.Row.FindControl("img_analises_romaneio"), Anthem.Image)


                'se nao tem calculo definitivo para o perifo de poupanca, deixa excluir a qualidade e incluir nova
                If ViewState.Item("PoupancaUltimoCalculo").Equals(String.Empty) Then
                    btn_editar.Visible = False
                    btn_delete.Visible = True
                Else
                    btn_editar.Visible = True
                    btn_delete.Visible = True

                    'se data calculo definitivo for maior ou  igual a data de validade inmicial nao deixa excluir
                    If CDate(ViewState.Item("PoupancaUltimoCalculo").ToString) >= CDate(lbl_dt_referencia_ini.Text) Then
                        btn_delete.Enabled = False
                        btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                        btn_delete.ToolTip = "Não é possível excluir o registro. Já existe cálculo definitivo."
                    Else
                        'se data calculo for menor, deixa excluir linha
                        btn_editar.Visible = False
                        btn_delete.Enabled = True
                        btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                        btn_delete.ToolTip = String.Empty
                    End If
                End If
                lbl_dt_referencia_ini.Text = DateTime.Parse(lbl_dt_referencia_ini.Text).ToString("MM/yyyy")
                lbl_dt_referencia_fim.Text = DateTime.Parse(lbl_dt_referencia_fim.Text).ToString("MM/yyyy")
                If st_rejeicao_antibiotico.Text.Equals("S") Then
                    img_rejeicao_antibiotico.ImageUrl = "~/img/ico_chk_true.gif"
                    e.Row.Cells(5).Text = String.Empty 'faixa inicial
                    e.Row.Cells(6).Text = String.Empty 'faixa final
                Else
                    img_rejeicao_antibiotico.ImageUrl = "~/img/ico_chk_false.gif"

                End If
                If st_analises_romaneio.Text.Equals("S") Then
                    img_analises_romaneio.ImageUrl = "~/img/ico_chk_true.gif"
                    e.Row.Cells(5).Text = String.Empty 'faixa inicial
                    e.Row.Cells(6).Text = String.Empty 'faixa final
                Else
                    img_analises_romaneio.ImageUrl = "~/img/ico_chk_false.gif"

                End If

            End If
        End If

    End Sub

    Protected Sub grdQualidade_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdQualidade.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub grdQualidade_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdQualidade.RowEditing
        Try

            grdQualidade.EditIndex = e.NewEditIndex
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdQualidade_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdQualidade.RowUpdating
        Dim row As GridViewRow = grdQualidade.Rows(e.RowIndex)
        Try
            If Page.IsValid Then


                If (Not (row) Is Nothing) Then

                    Dim qualidade As New PoupancaParametroQualidade

                    Dim lbl_id_poupanca_parametro_qualidade As Label = CType(row.FindControl("lbl_id_poupanca_parametro_qualidade"), Label)
                    Dim txt_dt_referencia_fim_qualidade As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_referencia_fim_qualidade"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)

                    qualidade.dt_referencia_fim = DateTime.Parse(String.Concat("01/", txt_dt_referencia_fim_qualidade.Text)).ToString("dd/MM/yyyy")
                    qualidade.id_modificador = Session("id_login")
                    qualidade.id_poupanca_parametro_qualidade = Convert.ToInt32(lbl_id_poupanca_parametro_qualidade.Text)
                    qualidade.updatePoupancaParametroQualidade()
                    grdQualidade.EditIndex = -1

                    loadParamQualidade()

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cv_parametros_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_parametros.ServerValidate
        Try
            Dim lmsg As String
            Dim parametro As New PoupancaParametro

            args.IsValid = True
            parametro.id_estabelecimento = cbo_estabelecimento.SelectedValue
            parametro.dt_referencia_ini = DateTime.Parse(String.Concat("01/", txt_referencia_ini.Text)).ToString("dd/MM/yyyy")

            'Busca todos os periodos de poupança qualidade cadastrados para oestabelecimento informado
            '(deve verificar se o periodo a ser inserido ja existe no banco)
            If parametro.getPoupancaParametroConsInclusao.Tables(0).Rows.Count > 0 Then
                args.IsValid = False
                lmsg = "O período da Poupança informado já existe no sistema para o estabelecimento selecionado."
            End If

            If (CDate("01/" & txt_referencia_ini.Text) >= CDate("01/" & txt_referencia_fim.Text)) Then
                args.IsValid = False
                lmsg = "A data inicial do período de referência não pode ser maior ou igual à data final do período."
            End If



            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub btn_incluirqualidade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluirqualidade.Click
        If Page.IsValid Then

            Try

                Dim poupancaparamqualidade As New PoupancaParametroQualidade()

                'Parâmetros
                poupancaparamqualidade.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
                poupancaparamqualidade.dt_referencia_ini = DateTime.Parse("01/" & txt_dt_inicio.Text).ToString("dd/MM/yyyy")
                poupancaparamqualidade.dt_referencia_fim = DateTime.Parse("01/" & txt_dt_fim.Text).ToString("dd/MM/yyyy")
                If cbo_categoria_qualidade.SelectedValue.Equals(String.Empty) Then
                    poupancaparamqualidade.id_categoria = 0
                Else
                    poupancaparamqualidade.id_categoria = cbo_categoria_qualidade.SelectedValue
                End If

                poupancaparamqualidade.id_modificador = Session("id_login")

                'se os dois tipos de analise estão  selecionadas inclui uma linnha para cada check
                If chk_antib_analises.Items(0).Selected = True OrElse chk_antib_analises.Items(1).Selected = True Then 'se analise romaneio ou antibiotico está selecionada
                    poupancaparamqualidade.nr_faixa_inicio = 0
                    poupancaparamqualidade.nr_faixa_fim = 0

                    If chk_antib_analises.Items(0).Selected = True Then 'rejeicao antibioticoa
                        poupancaparamqualidade.st_rejeicao_antibiotico = "S"
                        poupancaparamqualidade.st_analises_romaneio = "N"
                        poupancaparamqualidade.insertPoupancaParametroQualidade() 'insere parametro de qualidade de antibiotica
                    End If
                    If chk_antib_analises.Items(1).Selected = True Then
                        poupancaparamqualidade.st_analises_romaneio = "S"
                        poupancaparamqualidade.st_rejeicao_antibiotico = "N"
                        poupancaparamqualidade.insertPoupancaParametroQualidade() 'insere parametro de qualidade de nalaise de romaneio
                    End If
                Else
                    poupancaparamqualidade.st_rejeicao_antibiotico = "N"
                    poupancaparamqualidade.st_analises_romaneio = "N"
                    poupancaparamqualidade.nr_faixa_inicio = txt_faixa_inicial.Text
                    poupancaparamqualidade.nr_faixa_fim = txt_faixa_final.Text
                    poupancaparamqualidade.insertPoupancaParametroQualidade()
                End If

                messageControl.Alert("Registro inserido com sucesso.")


                loadParamQualidade()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub cv_parametrogrid_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try
            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim lbl_dt_referencia_ini As Label = CType(row.FindControl("lbl_dt_referencia_ini"), Label)
            Dim txt_dt_referencia_fim_qualidade As RK.TextBox.AjaxOnlyDate.OnlyDateTextBox = CType(row.FindControl("txt_dt_referencia_fim_qualidade"), RK.TextBox.AjaxOnlyDate.OnlyDateTextBox)
            Dim lmsg As String
            args.IsValid = True

            If (CDate(txt_dt_referencia_fim_qualidade.Text) <= CDate(lbl_calculo_definitivo.Text)) Then
                args.IsValid = False
                lmsg = "A data do Período Fim deve ser maior que a última referência de cálculo definitivo."
            End If

            If (CDate(txt_dt_referencia_fim_qualidade.Text) > CDate(Me.txt_referencia_fim.Text)) Then
                args.IsValid = False
                lmsg = "Período Fim deve ser menor que o Período de Referência final da Poupança."
            End If


            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub chk_antib_analises_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_antib_analises.SelectedIndexChanged

        If chk_antib_analises.Items(0).Selected = True OrElse chk_antib_analises.Items(1).Selected = True Then  'se analise romaneio ou antibiotico está selecionada
            cbo_categoria_qualidade.SelectedValue = String.Empty
            cbo_categoria_qualidade.Enabled = False
            txt_faixa_inicial.Text = String.Empty
            txt_faixa_final.Text = String.Empty
            txt_faixa_inicial.Enabled = False
            txt_faixa_final.Enabled = False
            cv_faixainicialfinal.Visible = False
            rfv_categoria.Enabled = False
            rfv_faixafinal.Enabled = False
            rfv_faixainicial.Enabled = False
        Else
            cbo_categoria_qualidade.Enabled = True
            txt_faixa_inicial.Enabled = True
            txt_faixa_final.Enabled = True
            cv_faixainicialfinal.Visible = True
            rfv_categoria.Enabled = True
            rfv_faixafinal.Enabled = True
            rfv_faixainicial.Enabled = True

        End If
    End Sub
End Class
