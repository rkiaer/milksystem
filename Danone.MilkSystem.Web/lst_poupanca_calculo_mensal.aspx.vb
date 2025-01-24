Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class lst_poupanca_calculo_mensal

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            Dim poupancacalculo As New PoupancaCalculoExecucao

            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("id_poupanca_parametro") = cbo_referencia_poupanca.SelectedValue
            ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
            ViewState.Item("dt_referencia") = DateTime.Parse(String.Concat("01/", txt_dt_referencia.Text)).ToString("dd/MM/yyyy")

            If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            Else
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            End If

            If Not (Me.txt_id_propriedade.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("id_propriedade") = Me.txt_id_propriedade.Text.Trim()
            Else
                ViewState.Item("id_propriedade") = String.Empty
            End If

            'Ao realizar nova pesquisa, insere dados da execuao
            Me.incluirPoupancaCalculoExecucao()

            loadData()
        End If
    End Sub
    Private Sub incluirPoupancaCalculoExecucao()

        Try

            Dim calculopoupanca As New PoupancaCalculoExecucao()

            ViewState.Item("id_poupanca_calculo_execucao") = 0
            calculopoupanca.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            If Trim(ViewState.Item("id_pessoa")) <> "" Then
                calculopoupanca.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            calculopoupanca.cd_pessoa = ViewState.Item("cd_pessoa")
            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                calculopoupanca.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If
            calculopoupanca.id_modificador = Session("id_login")
            calculopoupanca.st_tipo_calculo = "M" 'Indica que é calculo depoupanca MENSAL (M) e nao ANUAL (A)
            calculopoupanca.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
            calculopoupanca.dt_referencia = ViewState.Item("dt_referencia").ToString
            ViewState.Item("id_poupanca_calculo_execucao") = calculopoupanca.insertPoupancaCalculoExecucao()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_poupanca_calculo_mensal.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_poupanca_calculo_mensal.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
            '.Style("cursor") = "hand"
        End With


    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = "id_selecao, ds_produtor, id_propriedade"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("poupancacalcmensal", lbl_id_poupanca_calculo_execucao.ID).Equals(String.Empty)) Then

            hasFilters = True
            ViewState.Item("id_poupanca_calculo_execucao") = customPage.getFilterValue("poupancacalcmensal", lbl_id_poupanca_calculo_execucao.ID)
            Me.lbl_id_poupanca_calculo_execucao.Text = ViewState.Item("id_poupanca_calculo_execucao").ToString

            If Not (customPage.getFilterValue("poupancacalcmensal", cbo_estabelecimento.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_estabelecimento") = customPage.getFilterValue("poupancacalcmensal", cbo_estabelecimento.ID)
                Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
            Else
                ViewState.Item("id_estabelecimento") = "0"
            End If

            If Not (customPage.getFilterValue("poupancacalcmensal", cbo_referencia_poupanca.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_poupanca_parametro") = customPage.getFilterValue("poupancacalcmensal", cbo_referencia_poupanca.ID)
                cbo_referencia_poupanca.Enabled = True
                cbo_referencia_poupanca.Text = ViewState.Item("id_poupanca_parametro").ToString()
            Else
                ViewState.Item("id_poupanca_parametro") = "0"
            End If
            If Not (customPage.getFilterValue("poupancacalcmensal", txt_dt_referencia.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("dt_referencia") = customPage.getFilterValue("poupancacalcmensal", txt_dt_referencia.ID)
                txt_dt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("MM/yyyy")
            Else
                ViewState.Item("dt_referencia") = String.Empty
            End If

            If Not (customPage.getFilterValue("poupancacalcmensal", txt_cd_pessoa.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("cd_pessoa") = customPage.getFilterValue("poupancacalcmensal", txt_cd_pessoa.ID)
                txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
            Else
                ViewState.Item("cd_pessoa") = String.Empty
            End If

            If Not (customPage.getFilterValue("poupancacalcmensal", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("nm_pessoa") = customPage.getFilterValue("poupancacalcmensal", lbl_nm_pessoa.ID)
                lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
            Else
                ViewState.Item("nm_pessoa") = String.Empty
            End If

            If Not (customPage.getFilterValue("poupancacalcmensal", txt_id_propriedade.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("id_propriedade") = customPage.getFilterValue("poupancacalcmensal", txt_id_propriedade.ID)
                txt_id_propriedade.Text = ViewState.Item("id_propriedade").ToString()
            Else
                ViewState.Item("id_propriedade") = String.Empty
            End If

            If Not (customPage.getFilterValue("poupancacalcmensal", hf_id_pessoa.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("id_pessoa") = customPage.getFilterValue("poupancacalcmensal", hf_id_pessoa.ID)
                hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
            Else
                ViewState.Item("id_pessoa") = String.Empty
                hf_id_pessoa.Value = String.Empty
            End If

            If Not (customPage.getFilterValue("poupancacalcmensal", "PageIndex").Equals(String.Empty)) Then
                ViewState.Item("PageIndex") = customPage.getFilterValue("poupancacalcmensal", "PageIndex").ToString()
                gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
            End If
        Else
            hasFilters = False

        End If
        If (hasFilters) Then
            loadData()
            customPage.clearFilters("poupancaadesao")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim poupancacalculo As New PoupancaCalculoExecucao()

            If ViewState.Item("id_poupanca_calculo_execucao") > 0 Then
                'preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
                poupancacalculo.id_poupanca_calculo_execucao = Convert.ToInt32(ViewState.Item("id_poupanca_calculo_execucao").ToString)

                Dim dspoupancacalculoselecao As DataSet = poupancacalculo.getPoupancaCalculoExecucaoItensByFilters()

                If (dspoupancacalculoselecao.Tables(0).Rows.Count > 0) Then
                    Me.lk_calcular.Enabled = True
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dspoupancacalculoselecao.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    Me.lk_calcular.Enabled = False
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If

                lbl_id_poupanca_calculo_execucao.Text = ViewState.Item("id_poupanca_calculo_execucao")
            Else
                messageControl.Alert("Houve problemas técnicos na seleção do cálculo de poupança. Contacte o administrador do sistema.")
                lbl_id_poupanca_calculo_execucao.Text = String.Empty

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

            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If
            Case "ds_produtor"
                If (ViewState.Item("sortExpression")) = "ds_produtor asc" Then
                    ViewState.Item("sortExpression") = "ds_produtor desc"
                Else
                    ViewState.Item("sortExpression") = "ds_produtor asc"
                End If
           


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("poupancacalcmensal", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("poupancacalcmensal", cbo_referencia_poupanca.ID, ViewState.Item("id_poupanca_parametro").ToString)
            customPage.setFilter("poupancacalcmensal", "PageIndex", gridResults.PageIndex.ToString())
            customPage.setFilter("poupancacalcmensal", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("poupancacalcmensal", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("poupancacalcmensal", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("poupancacalcmensal", txt_id_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("poupancacalcmensal", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("poupancacalcmensal", lbl_id_poupanca_calculo_execucao.ID, ViewState.Item("id_poupanca_calculo_execucao").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function verificarCheckBox() As Boolean

        Try

            Dim li As Integer
            verificarCheckBox = False
            For li = 0 To gridResults.Rows.Count - 1
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    verificarCheckBox = True     ' Indica que tem alguma propriedade selecionada para o cálculo
                    Exit For
                End If
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        Try

            If (e.Row.RowType <> DataControlRowType.Header _
                And e.Row.RowType <> DataControlRowType.Footer _
                And e.Row.RowType <> DataControlRowType.Pager) Then

                Dim ck_item As Anthem.CheckBox = CType(e.Row.FindControl("ck_item"), Anthem.CheckBox)
                Dim id_selecao As Label = CType(e.Row.FindControl("id_selecao"), Label)
                Dim lbl_situacao_calculo As Label = CType(e.Row.FindControl("lbl_situacao_calculo"), Label)
                Dim st_poupanca_calculo_execucao_itens As Label = CType(e.Row.FindControl("st_poupanca_calculo_execucao_itens"), Label)

                Select Case st_poupanca_calculo_execucao_itens.Text
                    Case "2"
                        lbl_situacao_calculo.Text = "Calculado com Sucesso."
                    Case "3"
                        lbl_situacao_calculo.Text = "Não Participa Cálculo: Já efetuado Pagamento Mensal de Poupança."
                    Case "4"
                        lbl_situacao_calculo.Text = "Não Participa Cálculo: Não possui Adesão à Poupança."
                    Case "6"
                        lbl_situacao_calculo.Text = "Calculado: Não atingiu parâmetro de Qualidade Antibiótico."
                    Case "7"
                        lbl_situacao_calculo.Text = "Não Participa Cálculo: Não possui Adesão à Poupança para mês de referência selecionado para cálculo."
                    Case "8"
                        lbl_situacao_calculo.Text = "Calculado: Não atingiu parâmetro de Qualidade Proteína."
                    Case "9"
                        lbl_situacao_calculo.Text = "Calculado: Não atingiu parâmetro de Qualidade CCS."
                    Case "10"
                        lbl_situacao_calculo.Text = "Calculado: Não atingiu parâmetro de Qualidade Gordura."
                    Case "11"
                        lbl_situacao_calculo.Text = "Calculado: Não atingiu parâmetro de Qualidade CTM."
                    Case "12"
                        lbl_situacao_calculo.Text = "Não Participa: Não efetuou cálculo definitivo para referência."
                    Case "13"
                        lbl_situacao_calculo.Text = "Calculado: Não atingiu parâmetro de Qualidade nas Análises de Romaneio."
                    Case Else
                        lbl_situacao_calculo.Text = String.Empty
                End Select

                'se id_selecao =2 não pode ser selecionado para calculo... (se nao tiver adesão ou já tiver efetuado pagamento mensal
                If id_selecao.Text.Equals("2") Then
                    ck_item.Enabled = False
                    ck_item.ToolTip = "Não participa do cálculo."
                Else
                    ck_item.Enabled = True
                    ck_item.ToolTip = String.Empty
                End If

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub lk_calcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_calcular.Click
        Try

            saveFilters()
            If verificarCheckBox() = True Then
                Dim poupancacalculoexecucao As New PoupancaCalculoExecucao()

                ' Inicializa Cálculo
                poupancacalculoexecucao.id_poupanca_calculo_execucao = ViewState.Item("id_poupanca_calculo_execucao")
                poupancacalculoexecucao.dt_referencia = ViewState.Item("dt_referencia").ToString
                poupancacalculoexecucao.id_poupanca_parametro = ViewState.Item("id_poupanca_parametro")
                poupancacalculoexecucao.id_modificador = Session("id_login")

                poupancacalculoexecucao.PrepararProdutoresCalculoMensal()

                poupancacalculoexecucao.CalcularProdutorPoupancaMensal()

                messageControl.Alert("Cálculo efetuado com sucesso.")

                loadData()

            Else
                messageControl.Alert("Nenhum registro foi selecionado para o cálculo. Por favor selecione alguma propriedade.")
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
            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                If ch.Enabled = True Then 'se estiver habilitado, pode ser selecionado para calculo
                    ch.Checked = ck_header.Checked
                End If
            Next

            '' Seleciona tudo o que o botão Pesquisar trouxe - i
            Dim poupancacalculoselecao As New PoupancaCalculoExecucao
            poupancacalculoselecao.id_poupanca_calculo_execucao = Convert.ToInt32(ViewState.Item("id_poupanca_calculo_execucao").ToString)
            If ck_header.Checked = True Then
                poupancacalculoselecao.id_selecao = "3"
            Else
                poupancacalculoselecao.id_selecao = "1"
            End If
            poupancacalculoselecao.updatePoupancaCalculoSelecaoTodos()
            '  Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        'lbl_nm_pessoa.Text = String.Empty
        'lbl_nm_pessoa.Visible = False
        'hf_id_pessoa.Value = String.Empty

        lbl_nm_pessoa.Text = String.Empty
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

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
        End If

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

   

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        If cbo_estabelecimento.SelectedValue <> "0" Then
            cbo_referencia_poupanca.Enabled = True

            Dim poupancaparametro As New PoupancaParametro

            poupancaparametro.id_estabelecimento = cbo_estabelecimento.SelectedValue
            poupancaparametro.id_situacao_poupanca = 1 'aberto (traz apenas as referencias abertas

            cbo_referencia_poupanca.DataSource = poupancaparametro.getPoupancaParametro()
            cbo_referencia_poupanca.DataTextField = "ds_periodo_poupanca"
            cbo_referencia_poupanca.DataValueField = "id_poupanca_parametro"
            cbo_referencia_poupanca.DataBind()
            cbo_referencia_poupanca.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_referencia_poupanca.SelectedValue = 0
        Else
            cbo_referencia_poupanca.Items.Clear()
            cbo_referencia_poupanca.Enabled = False
        End If
    End Sub

    Protected Sub ck_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim chk_selec As CheckBox

        chk_selec = CType(sender, CheckBox)

        Dim id_poupanca_calculo_execucao_itens As Label = CType(row.FindControl("id_poupanca_calculo_execucao_itens"), Label)
        '' Seleciona o item selecionado
        Dim poupancacalculoselecao As New PoupancaCalculoExecucao
        poupancacalculoselecao.id_poupanca_calculo_execucao_itens = Convert.ToInt32(id_poupanca_calculo_execucao_itens.Text)
        If chk_selec.Checked = True Then
            poupancacalculoselecao.id_selecao = 3
        Else
            poupancacalculoselecao.id_selecao = 1

        End If
        'poupancacalculoselecao.id_selecao = chk_selec.Checked
        poupancacalculoselecao.updatePoupancaCalculoSelecao()

    End Sub

    Protected Sub cbo_referencia_poupanca_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_referencia_poupanca.SelectedIndexChanged
        'If Not cbo_referencia_poupanca.SelectedValue.Equals("0") Then
        '    dt_referencia_ini.Text = String.Concat("01/", Left(cbo_referencia_poupanca.Text.Trim, 7)).ToString
        '    dt_referencia_fim.Text = DateAdd(DateInterval.Day, -1, (DateAdd(DateInterval.Month, 1, Convert.ToDateTime(String.Concat("01/", Format(Right(cbo_referencia_poupanca.Text.Trim, 7), "MM/yyyy").ToString)))))

        'End If

    End Sub


    Protected Sub cv_referencia_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_referencia.ServerValidate
        Try
            Dim lmsg As String
            Dim poupancaparametro As New PoupancaParametro(cbo_referencia_poupanca.SelectedValue)

            args.IsValid = True
            'datetime.compare retorna 0 quando a data for a mesma; <0 quando a primeira data for menor que segunda data; e >0 quando a data 1 for maior que a data 2)

            'se dat referencia for menor que data de inicio
            If DateTime.Compare(String.Concat("01/", txt_dt_referencia.Text), poupancaparametro.dt_referencia_ini) < 0 Then
                args.IsValid = False
                lmsg = "A referência deve ser maior ou igual à referência inicial do Período de Poupança selecionado."
            End If

            'se dat referencia for maior que data de fim
            If DateTime.Compare(String.Concat("01/", txt_dt_referencia.Text), poupancaparametro.dt_referencia_fim) > 0 Then
                args.IsValid = False
                lmsg = "A referência deve ser menor ou igual à referência final do Período de Poupança selecionado."
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class
