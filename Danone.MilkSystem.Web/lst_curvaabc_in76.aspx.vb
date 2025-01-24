Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_curvaabc_in76

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("txt_dt_coleta_ini") = String.Concat("01/", Me.txt_dt_coleta_ini.Text.Trim)
        ViewState.Item("id_grupo") = Me.cbo_Grupo.SelectedValue
        ViewState.Item("tipopropriedade") = Me.cbo_tipo_propriedade.SelectedValue
        ViewState.Item("categoriatecnico") = Me.cbo_categoria.SelectedValue
        ViewState.Item("situacaorelatorio") = Me.cbo_situacoes.SelectedValue

        If txt_cd_tecnico.Text.Equals(String.Empty) Then
            ViewState.Item("id_tecnico") = "0"
        Else
            ViewState.Item("id_tecnico") = Me.hf_id_tecnico.Value
        End If

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_curvaabc_in76.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_curvaabc_in76.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 202
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
        End With
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With
        With img_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialogTecnico()")
            .ToolTip = "Filtrar Técnicos"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim codigoesalq As New CodigoEsalq

            estabelecimento.id_situacao = 1 '   Para trazer somente os ativos
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_estabelecimento.Items.RemoveAt(2)   ' Remove Aguas da Prata  -  acertos chamado 2500 

            Dim grupo As New Grupo
            cbo_Grupo.DataSource = grupo.getGruposByFilters()
            cbo_Grupo.DataTextField = "nm_grupo"
            cbo_Grupo.DataValueField = "id_grupo"
            cbo_Grupo.DataBind()
            cbo_Grupo.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_Grupo.Items.RemoveAt(2)   ' Remove item 2-Fornecedor de Insumos
            cbo_Grupo.Items.RemoveAt(2)   ' Remove item 3-Transportador
            cbo_Grupo.SelectedValue = 1   ' Assume como default na consulta o Produtor

            txt_dt_coleta_ini.Text = DateTime.Parse(Now).ToString("MM/yyyy")

            ViewState.Item("sortExpression") = ""



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim analiseesalq As New AnaliseEsalq

            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            analiseesalq.dt_coleta_start = DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))
            analiseesalq.dt_coleta_end = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
            analiseesalq.dt_referencia = ViewState.Item("txt_dt_coleta_ini")
            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            ' Trazer Poços e Aguas Juntos - i
            If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            Else
                analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            End If
            analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
            ' Trazer Poços e Aguas Juntos - f

            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            End If
            analiseesalq.st_categoria_tecnico = ViewState.Item("categoriatecnico").ToString
            If Trim(ViewState.Item("id_tecnico")) <> "" Then
                analiseesalq.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString)
            End If
            analiseesalq.st_tipo_propriedade = ViewState.Item("tipopropriedade").ToString

            Select Case ViewState.Item("situacaorelatorio").ToString
                Case "SA" 'trazer quem esta sem teor de cbt em qualquer dos ultimos 3 meses
                    analiseesalq.ds_compl = "---"

                Case "C" 'Crítico - trazer todas as analises que tem 2 ou mais analises NCOMPL CBT
                    analiseesalq.nr_compl = -1

                Case "D" 'Dispensar
                    analiseesalq.nr_compl = 3
            End Select

            Dim dsAnaliseEsalc As DataSet = analiseesalq.getCurvaAbcIN76()

            If (dsAnaliseEsalc.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsAnaliseEsalc.Tables(0), ViewState.Item("sortExpression"))
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

            Case "nm_estabelecimento"
                If (ViewState.Item("sortExpression")) = "nm_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "nm_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_estabelecimento asc"
                End If


            Case "tipopropriedade"
                If (ViewState.Item("sortExpression")) = "tipopropriedade asc" Then
                    ViewState.Item("sortExpression") = "tipopropriedade desc"
                Else
                    ViewState.Item("sortExpression") = "tipopropriedade asc"
                End If

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If

            Case "nm_pessoa"
                If (ViewState.Item("sortExpression")) = "nm_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_pessoa asc"
                End If

        End Select

        loadData()

    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            Else
                lbl_nm_pessoa.Text = String.Empty
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            Else
                txt_cd_pessoa.Text = String.Empty
                hf_id_pessoa.Value = String.Empty
            End If


            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposPropriedade()

        Try

            Me.lbl_nm_propriedade.Text = String.Empty
            Me.txt_cd_propriedade.Text = String.Empty

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If

            If Not hf_id_propriedade.Value.Equals(String.Empty) AndAlso CInt(hf_id_propriedade.Value.ToString) > 0 Then
                Me.txt_cd_propriedade.Text = Me.hf_id_propriedade.Value.ToString
            Else
                hf_id_propriedade.Value = String.Empty
            End If


            'If Not (customPage.getFilterValue("lupa_propriedade", "cd_pessoa").Equals(String.Empty)) Then
            '    Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "cd_pessoa").ToString
            'End If

            'If Not (customPage.getFilterValue("lupa_propriedade", "nm_pessoa").Equals(String.Empty)) Then
            '    Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "nm_pessoa").ToString
            'End If

            'If Not (customPage.getFilterValue("lupa_propriedade", "id_pessoa").Equals(String.Empty)) Then
            '    Me.hf_id_pessoa.Value = customPage.getFilterValue("lupa_propriedade", "id_pessoa").ToString
            'End If

            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType = DataControlRowType.Header) Then
            Dim lbl_teor_ctm_mensal As Label = CType(e.Row.FindControl("lbl_teor_ctm_mensal"), Label)
            Dim lbl_teor_ctm_mensal1 As Label = CType(e.Row.FindControl("lbl_teor_ctm_mensal1"), Label)
            Dim lbl_teor_ctm_mensal2 As Label = CType(e.Row.FindControl("lbl_teor_ctm_mensal2"), Label)

            Dim lbl_menor_amostra_mes As Label = CType(e.Row.FindControl("lbl_menor_amostra_mes"), Label)

            lbl_teor_ctm_mensal.Text = DateTime.Parse(ViewState.Item("txt_dt_coleta_ini")).ToString("MMM").ToUpper
            lbl_teor_ctm_mensal1.Text = DateTime.Parse(DateAdd(DateInterval.Month, -1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper
            lbl_teor_ctm_mensal2.Text = DateTime.Parse(DateAdd(DateInterval.Month, -2, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")))).ToString("MMM").ToUpper
            lbl_menor_amostra_mes.Text = lbl_teor_ctm_mensal.Text

        End If

        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then
            'fran 17/02/2017 i fran
            Dim lbl_nr_teor_ctm As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm"), Label)
            Dim lbl_nr_teor_ctm1 As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm1"), Label)
            Dim lbl_nr_teor_ctm2 As Label = CType(e.Row.FindControl("lbl_nr_teor_ctm2"), Label)
            Dim lbl_menoresalq As Label = CType(e.Row.FindControl("lbl_menoresalq"), Label)
            Dim nrcomplcbt As Label = CType(e.Row.FindControl("nrcomplcbt"), Label)
            Dim nrcomplcbt1 As Label = CType(e.Row.FindControl("nrcomplcbt1"), Label)
            Dim nrcomplcbt2 As Label = CType(e.Row.FindControl("nrcomplcbt2"), Label)
            Dim nranalisecomplcbt As Label = CType(e.Row.FindControl("nranalisecomplcbt"), Label)
            Dim nrnaocompl As Integer = 0
            Dim nr1 As Integer = 0
            Dim nr2 As Integer = 0

            If nrcomplcbt.Text = "0" Then
                nrnaocompl = nrnaocompl + 1
            End If
            If nrcomplcbt1.Text = "0" Then
                nrnaocompl = nrnaocompl + 1
            End If
            If nrcomplcbt2.Text = "0" Then
                nrnaocompl = nrnaocompl + 1
            End If

            If (nrnaocompl = 3 And nranalisecomplcbt.Text = "-1") OrElse nrnaocompl = 2 Then
                e.Row.BackColor = Drawing.Color.Yellow
                e.Row.Cells(6).BackColor = Drawing.Color.Yellow
                e.Row.Cells(7).BackColor = Drawing.Color.Yellow
                e.Row.Cells(8).BackColor = Drawing.Color.Yellow
                e.Row.Cells(9).BackColor = Drawing.Color.Yellow
                e.Row.Cells(10).BackColor = Drawing.Color.Yellow
                e.Row.Cells(11).BackColor = Drawing.Color.Yellow
                e.Row.Cells(12).BackColor = Drawing.Color.Yellow
                e.Row.Cells(13).BackColor = Drawing.Color.Yellow
            End If

            If Not lbl_nr_teor_ctm.Text.Equals(String.Empty) Then
                lbl_nr_teor_ctm.Text = FormatNumber(lbl_nr_teor_ctm.Text, 0).ToString
                If nrcomplcbt.Text = "0" Then
                    e.Row.Cells(11).BackColor = Drawing.Color.Red
                End If
            End If
            If Not lbl_nr_teor_ctm1.Text.Equals(String.Empty) Then
                lbl_nr_teor_ctm1.Text = FormatNumber(lbl_nr_teor_ctm1.Text, 0).ToString
                If nrcomplcbt1.Text = "0" Then
                    e.Row.Cells(9).BackColor = Drawing.Color.Red
                End If
            End If
            If Not lbl_nr_teor_ctm2.Text.Equals(String.Empty) Then
                lbl_nr_teor_ctm2.Text = FormatNumber(lbl_nr_teor_ctm2.Text, 0).ToString
                If nrcomplcbt2.Text = "0" Then
                    e.Row.Cells(7).BackColor = Drawing.Color.Red
                End If

            End If

            If Not lbl_menoresalq.Text.Equals(String.Empty) Then
                lbl_menoresalq.Text = FormatNumber(lbl_menoresalq.Text, 0).ToString
                If nranalisecomplcbt.Text = "0" Then
                    e.Row.Cells(13).BackColor = Drawing.Color.Red
                    'se tem 3 nao compl e menor analise tbm nao complience
                    If nrnaocompl = 3 Then
                        e.Row.BackColor = Drawing.Color.Red
                        e.Row.ForeColor = Drawing.Color.White
                        e.Row.Cells(6).BackColor = Drawing.Color.Red
                        e.Row.Cells(7).BackColor = Drawing.Color.Red
                        e.Row.Cells(8).BackColor = Drawing.Color.Red
                        e.Row.Cells(9).BackColor = Drawing.Color.Red
                        e.Row.Cells(10).BackColor = Drawing.Color.Red
                        e.Row.Cells(11).BackColor = Drawing.Color.Red
                        e.Row.Cells(12).BackColor = Drawing.Color.Red
                        e.Row.Cells(13).BackColor = Drawing.Color.Red
                        e.Row.Cells(6).ForeColor = Drawing.Color.White
                        e.Row.Cells(7).ForeColor = Drawing.Color.White
                        e.Row.Cells(8).ForeColor = Drawing.Color.White
                        e.Row.Cells(9).ForeColor = Drawing.Color.White
                        e.Row.Cells(10).ForeColor = Drawing.Color.White
                        e.Row.Cells(11).ForeColor = Drawing.Color.White
                        e.Row.Cells(12).ForeColor = Drawing.Color.White
                        e.Row.Cells(13).ForeColor = Drawing.Color.White

                    End If
                End If
            End If

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged

        'lbl_nm_pessoa.Text = ""
        'lbl_nm_pessoa.Visible = False

        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty
        'fran 04/2017 i 
        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                'produtor.id_situacao = 1
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

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        'If Me.cbo_estabelecimento.SelectedValue <> "0" Then
        'Me.lbl_nm_propriedade.Visible = True
        carregarCamposPropriedade()
        ' End If
    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
        'lbl_nm_propriedade.Text = ""
        'lbl_nm_propriedade.Visible = False
        lbl_nm_propriedade.Text = String.Empty
        hf_id_propriedade.Value = String.Empty
        'Fran 04/2017
        Try
            If Not txt_cd_propriedade.Text.Equals(String.Empty) Then
                Dim propriedade As New Propriedade
                propriedade.id_propriedade = Convert.ToInt32(txt_cd_propriedade.Text.Trim)

                Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters
                If dspropriedade.Tables(0).Rows.Count > 0 Then
                    lbl_nm_propriedade.Enabled = True
                    lbl_nm_propriedade.Text = dspropriedade.Tables(0).Rows(0).Item("nm_propriedade")
                    hf_id_propriedade.Value = dspropriedade.Tables(0).Rows(0).Item("id_propriedade").ToString
                End If

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        'Fran 11/03/2010 chamado 684

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("txt_dt_coleta_ini") = String.Concat("01/", Me.txt_dt_coleta_ini.Text.Trim)
        ViewState.Item("id_grupo") = Me.cbo_Grupo.SelectedValue
        ViewState.Item("tipopropriedade") = Me.cbo_tipo_propriedade.SelectedValue
        ViewState.Item("categoriatecnico") = Me.cbo_categoria.SelectedValue
        ViewState.Item("situacaorelatorio") = Me.cbo_situacoes.SelectedValue

        If txt_cd_tecnico.Text.Equals(String.Empty) Then
            ViewState.Item("id_tecnico") = "0"
        Else
            ViewState.Item("id_tecnico") = Me.hf_id_tecnico.Value
        End If
        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 202
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        Response.Redirect("frm_curvaabc_in76_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&txt_dt_coleta_ini=" + ViewState.Item("txt_dt_coleta_ini").ToString() + "&id_tecnico=" + ViewState.Item("id_tecnico").ToString() + "&categoriatecnico=" + ViewState.Item("categoriatecnico").ToString() + "&tipopropriedade=" + ViewState.Item("tipopropriedade").ToString() + "&situacaorelatorio=" + ViewState.Item("situacaorelatorio").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString())

    End Sub


    Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
        lbl_nm_tecnico.Text = String.Empty
        hf_id_tecnico.Value = String.Empty

        Try
            If Not txt_cd_tecnico.Text.Equals(String.Empty) Then
                Dim tecnico As New Tecnico
                tecnico.id_tecnico = Convert.ToInt32(txt_cd_tecnico.Text.Trim)

                Dim dstecnico As DataSet = tecnico.getTecnicoByFilters
                If dstecnico.Tables(0).Rows.Count > 0 Then
                    lbl_nm_tecnico.Enabled = True
                    lbl_nm_tecnico.Text = dstecnico.Tables(0).Rows(0).Item("nm_tecnico")
                    hf_id_tecnico.Value = dstecnico.Tables(0).Rows(0).Item("id_tecnico").ToString
                End If

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub img_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_tecnico.Click
        If Not (hf_id_tecnico.Value.Trim.Equals(String.Empty)) Then
            Me.lbl_nm_tecnico.Visible = True
            carregarCamposTecnico()

        End If
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
End Class
