Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_po_ordem_compra
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If cbo_tipo_fornecedor.SelectedValue.Equals("P") Then 'se tipo for produtor
            ViewState.Item("id_estado") = cbo_estado.SelectedValue
            If txt_dt_referencia.Text.Equals(String.Empty) Then
                ViewState.Item("dt_referencia") = txt_dt_referencia.Text
            Else
                ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)

            End If
        Else
            ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
            If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            Else
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            End If
            ViewState.Item("dt_inicio_start") = txt_dt_ini.Text
            ViewState.Item("dt_inicio_end") = txt_dt_fim.Text
        End If

        ViewState.Item("nr_po") = txt_nr_po.Text
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        ViewState.Item("tipo_fornecedor") = cbo_tipo_fornecedor.SelectedValue
        ViewState("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState("id_item") = cbo_item.SelectedValue
        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_po_ordem_compra.aspx?st_incluirlog=N")

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_po_ordem_compra.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 123
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
        With btn_lupa_cooperativa
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Cooperativas"
        End With
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtor Agropecuária"
        End With

    End Sub


    Private Sub loadDetails()

        Try


            Dim estado As New Estado

            cbo_estado.DataSource = estado.getEstadosByFilters()
            cbo_estado.DataTextField = "nm_estado"
            cbo_estado.DataValueField = "id_estado"
            cbo_estado.DataBind()
            cbo_estado.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim status As New Situacao
            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim item As New Item
            cbo_item.DataSource = item.getItensByFilters()
            cbo_item.DataTextField = "nm_item"
            cbo_item.DataValueField = "id_item"
            cbo_item.DataBind()
            cbo_item.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ViewState.Item("sortExpression") = ""

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If (customPage.getFilterValue("po", cbo_tipo_fornecedor.ID).Equals("P")) Then
            ViewState.Item("tipo_fornecedor") = "P"
            cbo_tipo_fornecedor.SelectedValue = "P"

            If Not (customPage.getFilterValue("po", cbo_estado.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("id_estado") = customPage.getFilterValue("po", cbo_estado.ID)
                Me.cbo_estado.Text = ViewState.Item("id_estado").ToString()
            Else
                ViewState.Item("id_estado") = String.Empty
            End If
            If Not (customPage.getFilterValue("po", txt_dt_referencia.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("dt_referencia") = customPage.getFilterValue("po", txt_dt_referencia.ID)
                txt_dt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("MM/yyyy")
            Else
                ViewState.Item("dt_referencia") = String.Empty
            End If

            lbl_periodo.Text = "Data Referência:"
            txt_dt_referencia.Visible = True
            txt_dt_ini.Visible = False
            txt_dt_fim.Visible = False
            lbl_separador.Visible = False
            lbl_cooperativa_estado.Text = "Estado:"
            cbo_estado.Visible = True
            txt_cd_pessoa.Visible = False
            lbl_nm_pessoa.Visible = False
            btn_lupa_cooperativa.Visible = False
            btn_lupa_produtor.Visible = False 'fran chamado 1548

            ViewState.Item("sortExpression") = "cd_uf, dt_referencia desc"

        Else
            'fran 15/05/2012 i chamado 1548
            'ViewState.Item("tipo_fornecedor") = "C"
            'cbo_tipo_fornecedor.SelectedValue = "C"
            cbo_tipo_fornecedor.SelectedValue = customPage.getFilterValue("po", cbo_tipo_fornecedor.ID).ToString
            If cbo_tipo_fornecedor.SelectedValue = "C" Then
                ViewState.Item("tipo_fornecedor") = "C"
            End If
            If cbo_tipo_fornecedor.SelectedValue = "A" Then
                ViewState.Item("tipo_fornecedor") = "A"
            End If
            'fran 15/05/2012 f chamado 1548

            If Not (customPage.getFilterValue("po", txt_dt_ini.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("dt_inicio_start") = customPage.getFilterValue("po", txt_dt_ini.ID)
                txt_dt_ini.Text = ViewState.Item("dt_inicio_start").ToString()
            Else
                ViewState.Item("dt_inicio_start") = String.Empty
            End If
            If Not (customPage.getFilterValue("po", txt_dt_fim.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("dt_inicio_end") = customPage.getFilterValue("po", txt_dt_fim.ID)
                txt_dt_fim.Text = ViewState.Item("dt_inicio_end").ToString()
            Else
                ViewState.Item("dt_inicio_end") = String.Empty
            End If
            If Not (customPage.getFilterValue("po", txt_cd_pessoa.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("cd_pessoa") = customPage.getFilterValue("po", txt_cd_pessoa.ID)
                txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
            Else
                ViewState.Item("cd_pessoa") = String.Empty
            End If

            If Not (customPage.getFilterValue("po", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("nm_pessoa") = customPage.getFilterValue("po", lbl_nm_pessoa.ID)
                lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
            Else
                ViewState.Item("nm_pessoa") = String.Empty
            End If

            If Not (customPage.getFilterValue("po", hf_id_pessoa.ID).Equals(String.Empty)) Then
                hasFilters = True
                ViewState.Item("id_pessoa") = customPage.getFilterValue("po", hf_id_pessoa.ID)
                hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
            Else
                ViewState.Item("id_pessoa") = String.Empty
                hf_id_pessoa.Value = String.Empty
            End If
            If cbo_tipo_fornecedor.SelectedValue = "C" Then
                lbl_cooperativa_estado.Text = "Cooperativa:"
                btn_lupa_cooperativa.Visible = True
                btn_lupa_produtor.Visible = False 'fran chamado 1548

                ViewState.Item("sortExpression") = "cd_cooperativa, dt_inicio desc"
            End If
            'fran 15/05/2012 i chamado 1548
            If cbo_tipo_fornecedor.SelectedValue = "A" Then
                lbl_cooperativa_estado.Text = "Produtor Agropecuária:"
                btn_lupa_cooperativa.Visible = False
                btn_lupa_produtor.Visible = True 'fran chamado 1548

                ViewState.Item("sortExpression") = "cd_agropecuaria, dt_inicio desc"
            End If
            'fran 15/05/2012 f chamado 1548
            If cbo_tipo_fornecedor.SelectedValue = "C" Or cbo_tipo_fornecedor.SelectedValue = "A" Then

                lbl_periodo.Text = "Data Início entre:"
                txt_dt_referencia.Visible = False
                txt_dt_ini.Visible = True
                txt_dt_fim.Visible = True
                lbl_separador.Visible = True
                cbo_estado.Visible = False
                txt_cd_pessoa.Visible = True
                lbl_nm_pessoa.Visible = False
            End If

        End If

        If Not (customPage.getFilterValue("po", cbo_situacao.ID).Equals("0")) And Not (customPage.getFilterValue("po", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("po", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = 0
        End If
        'fran 22/08/2012 i 
        If Not (customPage.getFilterValue("po", txt_nr_po.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_po") = customPage.getFilterValue("po", txt_nr_po.ID)
            txt_nr_po.Text = ViewState.Item("nr_po").ToString()
        Else
            ViewState.Item("nr_po") = String.Empty
        End If
        'fran 22/08/2012 f 
        If Not (customPage.getFilterValue("po", cbo_estabelecimento.ID).Equals("0")) And Not (customPage.getFilterValue("po", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("po", cbo_estabelecimento.ID)
            cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = 0
        End If
        If Not (customPage.getFilterValue("po", cbo_item.ID).Equals("0")) And Not (customPage.getFilterValue("po", cbo_item.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_item") = customPage.getFilterValue("po", cbo_item.ID)
            cbo_item.Text = ViewState.Item("id_item").ToString()
        Else
            ViewState.Item("id_item") = 0
        End If
        If cbo_tipo_fornecedor.Text = "P" Then
            If Not (customPage.getFilterValue("po", "PageIndex").Equals(String.Empty)) Then
                ViewState.Item("PageIndex") = customPage.getFilterValue("po", "PageIndex").ToString()
                gridResultsprod.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
            End If
        End If
        If cbo_tipo_fornecedor.Text = "C" Then
            If Not (customPage.getFilterValue("po", "PageIndex").Equals(String.Empty)) Then
                ViewState.Item("PageIndex") = customPage.getFilterValue("po", "PageIndex").ToString()
                gridResultscoop.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
            End If
        End If
        If cbo_tipo_fornecedor.Text = "A" Then
            If Not (customPage.getFilterValue("po", "PageIndex").Equals(String.Empty)) Then
                ViewState.Item("PageIndex") = customPage.getFilterValue("po", "PageIndex").ToString()
                gridResultsAgro.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
            End If
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("po")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim dspo As DataSet

            If ViewState.Item("tipo_fornecedor").Equals("P") Then
                Dim poprodutor As New POProdutor
                If Not (ViewState.Item("id_estado").Equals(String.Empty)) Then
                    poprodutor.id_estado = ViewState.Item("id_estado")
                Else
                    poprodutor.id_estado = 0
                End If

                poprodutor.dt_referencia = ViewState.Item("dt_referencia").ToString
                poprodutor.nr_po = ViewState.Item("nr_po").ToString
                poprodutor.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
                poprodutor.id_estabelecimento = Convert.ToInt32(ViewState("id_estabelecimento"))
                poprodutor.id_item = Convert.ToInt32(ViewState("id_item"))

                gridResultscoop.Visible = False
                gridResultsagro.Visible = False

                dspo = poprodutor.getPOProdutorbyFilters()
                If (dspo.Tables(0).Rows.Count > 0) Then
                    gridResultsProd.Visible = True
                    gridResultsProd.DataSource = Helper.getDataView(dspo.Tables(0), ViewState.Item("sortExpression"))
                    gridResultsProd.DataBind()
                Else
                    gridResultsProd.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If


            Else
                If ViewState.Item("tipo_fornecedor").Equals("C") Then

                    Dim pocoop As New POCooperativa

                    If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                        pocoop.id_cooperativa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
                    Else
                        pocoop.id_cooperativa = 0
                    End If

                    pocoop.dt_inicio_start = ViewState.Item("dt_inicio_start").ToString
                    pocoop.dt_inicio_end = ViewState.Item("dt_inicio_end").ToString
                    pocoop.nr_po = ViewState.Item("nr_po").ToString
                    pocoop.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
                    pocoop.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
                    pocoop.id_item = Convert.ToInt32(ViewState.Item("id_item").ToString())
                    dspo = pocoop.getPOCooperativabyFilters()

                    gridResultsProd.Visible = False
                    gridResultsagro.Visible = False

                    If (dspo.Tables(0).Rows.Count > 0) Then
                        gridResultscoop.Visible = True
                        gridResultscoop.DataSource = Helper.getDataView(dspo.Tables(0), ViewState.Item("sortExpression"))
                        gridResultscoop.DataBind()
                    Else
                        gridResultscoop.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If
                Else
                    'fran 15/05/2012 i themis chamado 1548
                    'se agropecuaria 
                    Dim poagro As New POAgropecuaria

                    If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                        poagro.id_agropecuaria = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
                    Else
                        poagro.id_agropecuaria = 0
                    End If

                    poagro.dt_inicio_start = ViewState.Item("dt_inicio_start").ToString
                    poagro.dt_inicio_end = ViewState.Item("dt_inicio_end").ToString
                    poagro.nr_po = ViewState.Item("nr_po").ToString
                    poagro.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
                    poagro.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
                    poagro.id_item = Convert.ToInt32(ViewState.Item("id_item").ToString())
                    dspo = poagro.getPOagropecuariabyFilters()

                    gridResultsProd.Visible = False
                    gridResultscoop.Visible = False

                    If (dspo.Tables(0).Rows.Count > 0) Then
                        gridResultsAgro.Visible = True
                        gridResultsAgro.DataSource = Helper.getDataView(dspo.Tables(0), ViewState.Item("sortExpression"))
                        gridResultsAgro.DataBind()
                    Else
                        gridResultsAgro.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If

                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResultscoop_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResultscoop.Sorting

        Select Case e.SortExpression.ToLower()


            Case "ds_cooperativa"
                If (ViewState.Item("sortExpression")) = "ds_cooperativa asc" Then
                    ViewState.Item("sortExpression") = "ds_cooperativa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_cooperativa asc"
                End If

            Case "dt_inicio"
                If (ViewState.Item("sortExpression")) = "dt_inicio asc" Then
                    ViewState.Item("sortExpression") = "dt_inicio desc"
                Else
                    ViewState.Item("sortExpression") = "dt_inicio asc"
                End If

            Case "dt_fim"
                If (ViewState.Item("sortExpression")) = "dt_fim asc" Then
                    ViewState.Item("sortExpression") = "dt_fim desc"
                Else
                    ViewState.Item("sortExpression") = "dt_fim asc"
                End If

            Case "nr_po"
                If (ViewState.Item("sortExpression")) = "nr_po asc" Then
                    ViewState.Item("sortExpression") = "nr_po desc"
                Else
                    ViewState.Item("sortExpression") = "nr_po asc"
                End If
            Case "id_situacao"
                If (ViewState.Item("sortExpression")) = "id_situacao asc" Then
                    ViewState.Item("sortExpression") = "id_situacao desc"
                Else
                    ViewState.Item("sortExpression") = "id_situacao asc"
                End If
            Case "nm_estabelecimento"
                If (ViewState.Item("sortExpression")) = "nm_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "nm_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_estabelecimento asc"
                End If
            Case "nm_item"
                If (ViewState.Item("sortExpression")) = "nm_item asc" Then
                    ViewState.Item("sortExpression") = "nm_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_item asc"
                End If


        End Select

        loadData()

    End Sub
    Private Sub carregarCamposCooperativa()

        Try

            If Not (customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Visible = True
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_cooperativa", "nm_cooperativa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_cooperativa", "cd_cooperativa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_cooperativa")


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

    Protected Sub cv_pessoa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_pessoa.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidpessoa As Int32

            'pessoa.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)

            If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
            lidpessoa = pessoa.validarCooperativa

            If lidpessoa > 0 Then
                args.IsValid = True
                hf_id_pessoa.Value = lidpessoa
            Else
                hf_id_pessoa.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Cooperativa não cadastrada.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("po", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("po", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("po", txt_nr_po.ID, ViewState.Item("nr_po").ToString)
            customPage.setFilter("po", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("po", cbo_tipo_fornecedor.ID, ViewState.Item("tipo_fornecedor").ToString)
            customPage.setFilter("po", txt_dt_ini.ID, ViewState.Item("dt_inicio_start").ToString)
            customPage.setFilter("po", txt_dt_fim.ID, ViewState.Item("dt_inicio_end").ToString)
            customPage.setFilter("po", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("po", cbo_estabelecimento.ID, ViewState("id_estabelecimento").ToString())
            customPage.setFilter("po", cbo_item.ID, ViewState("id_item").ToString())
            'fran 22/08/2012
            Select Case ViewState.Item("tipo_fornecedor").ToString
                Case "P"
                    customPage.setFilter("po", cbo_estado.ID, ViewState.Item("id_estado").ToString)
                    customPage.setFilter("po", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
                    customPage.setFilter("po", "PageIndex", gridResultsprod.PageIndex.ToString())

                Case "C"
                    customPage.setFilter("po", "PageIndex", gridResultscoop.PageIndex.ToString())

                Case "A"
                    customPage.setFilter("po", "PageIndex", gridResultsAgro.PageIndex.ToString())
            End Select

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResultscoop_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResultscoop.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_po_cooperativa.aspx?id_po_cooperativa=" + e.CommandArgument.ToString())

            Case "delete"
                deletePOCooperativa(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub


    Protected Sub lk_novo_produtor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo_produtor.Click
        If cbo_tipo_fornecedor.SelectedValue.Equals("P") Then 'se tipo for produtor
            ViewState.Item("id_estado") = cbo_estado.SelectedValue
            If txt_dt_referencia.Text.Equals(String.Empty) Then
                ViewState.Item("dt_referencia") = txt_dt_referencia.Text
            Else
                ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)

            End If
        Else
            ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
            If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            Else
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            End If
            ViewState.Item("dt_inicio_start") = txt_dt_ini.Text
            ViewState.Item("dt_inicio_end") = txt_dt_fim.Text
        End If

        ViewState.Item("nr_po") = txt_nr_po.Text
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        ViewState.Item("tipo_fornecedor") = cbo_tipo_fornecedor.SelectedValue
        ViewState("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState("id_item") = cbo_item.SelectedValue

        saveFilters()
        Response.Redirect("frm_po_produtor.aspx")
    End Sub

    Protected Sub gridResultscoop_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultscoop.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            e.Row.Cells(3).Text = DateTime.Parse(e.Row.Cells(3).Text).ToString("dd/MM/yyyy") 'dt_inicio
            e.Row.Cells(4).Text = DateTime.Parse(e.Row.Cells(4).Text).ToString("dd/MM/yyyy") 'dt_fim
            If e.Row.Cells(6).Text.Trim.Equals("1") Then 'situacao
                e.Row.Cells(6).Text = "Ativo"

            Else
                e.Row.Cells(6).Text = "Inativo"
            End If

        End If
    End Sub

    Protected Sub gridResultscoop_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResultscoop.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_cooperativa.Click
        'If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
        If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposCooperativa()
        Else
            txt_cd_pessoa.Text = String.Empty
            hf_id_pessoa.Value = String.Empty
            lbl_nm_pessoa.Text = String.Empty
            lbl_nm_pessoa.Visible = False
        End If
        'End If

    End Sub
    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        lbl_nm_pessoa.Visible = False
        hf_id_pessoa.Value = String.Empty
    End Sub
    Private Sub deletePOAgropecuaria(ByVal id_po_agropecuaria As Integer)

        Try

            Dim po As New POAgropecuaria
            po.id_po_agropecuaria = id_po_agropecuaria
            po.id_modificador = Convert.ToInt32(Session("id_login"))
            po.deletePOagropecuaria()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 123
            usuariolog.ds_nm_processo = "Purchase Order (PO) - Agropecuária"
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso. Sr. Usuário, o número de PO deste registro não será mais enviado à exportação do Batch Declaration.")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub deletePOCooperativa(ByVal id_po_cooperativa As Integer)

        Try

            Dim po As New POCooperativa
            po.id_po_cooperativa = id_po_cooperativa
            po.id_modificador = Convert.ToInt32(Session("id_login"))
            po.deletePOCooperativa()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 123
            usuariolog.ds_nm_processo = "Purchase Order (PO) - Cooperativa"
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso. Sr. Usuário, o número de PO deste registro não será mais enviado à exportação do Batch Declaration.")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub deletePOProdutor(ByVal id_po_produtor As Integer)

        Try

            Dim po As New POProdutor
            po.id_po_produtor = id_po_produtor
            po.id_modificador = Convert.ToInt32(Session("id_login"))
            po.deletePOProdutor()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 123
            usuariolog.ds_nm_processo = "Purchase Order (PO) - Produtor"
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso. Sr. Usuário, o número de PO deste registro não será mais enviado à exportação do Batch Declaration.")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cbo_tipo_fornecedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_fornecedor.SelectedIndexChanged
        Select Case cbo_tipo_fornecedor.SelectedValue
            Case "P"
                lbl_periodo.Text = "Data Referência:"
                txt_dt_referencia.Visible = True
                txt_dt_ini.Visible = False
                txt_dt_fim.Visible = False
                lbl_separador.Visible = False
                lbl_cooperativa_estado.Text = "Estado:"
                cbo_estado.Visible = True
                txt_cd_pessoa.Visible = False
                lbl_nm_pessoa.Visible = False
                btn_lupa_cooperativa.Visible = False
                btn_lupa_produtor.Visible = False

                ViewState.Item("sortExpression") = "nm_estabelecimento,cd_uf,dt_referencia desc, nm_item"
            Case "C"
                lbl_periodo.Text = "Data Início entre:"
                txt_dt_referencia.Visible = False
                txt_dt_ini.Visible = True
                txt_dt_fim.Visible = True
                lbl_separador.Visible = True
                lbl_cooperativa_estado.Text = "Cooperativa:"
                cbo_estado.Visible = False
                txt_cd_pessoa.Visible = True
                lbl_nm_pessoa.Visible = False
                btn_lupa_cooperativa.Visible = True
                btn_lupa_produtor.Visible = False

                ViewState.Item("sortExpression") = "nm_estabelecimento,cd_cooperativa,dt_inicio desc, nm_item"
            Case "A"
                lbl_periodo.Text = "Data Início entre:"
                txt_dt_referencia.Visible = False
                txt_dt_ini.Visible = True
                txt_dt_fim.Visible = True
                lbl_separador.Visible = True
                lbl_cooperativa_estado.Text = "Agropecuária:"
                cbo_estado.Visible = False
                txt_cd_pessoa.Visible = True
                lbl_nm_pessoa.Visible = False
                btn_lupa_cooperativa.Visible = False
                btn_lupa_produtor.Visible = True
                ViewState.Item("sortExpression") = "nm_estabelecimento, cd_agropecuaria, dt_inicio desc, nm_item"

        End Select
    End Sub


    Protected Sub gridResultscoop_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResultscoop.PageIndexChanging
        gridResultscoop.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResultsProd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResultsProd.PageIndexChanging
        gridResultsProd.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResultsProd_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResultsProd.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_po_produtor.aspx?id_po_produtor=" + e.CommandArgument.ToString())

            Case "delete"
                deletePOProdutor(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select
    End Sub

    Protected Sub gridResultsProd_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsProd.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            e.Row.Cells(3).Text = DateTime.Parse(e.Row.Cells(3).Text).ToString("MM/yyyy") 'dt_referencia
            If e.Row.Cells(5).Text.Trim.Equals("1") Then 'situacao
                e.Row.Cells(5).Text = "Ativo"

            Else
                e.Row.Cells(5).Text = "Inativo"
            End If

        End If

    End Sub

    Protected Sub gridResultsProd_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResultsProd.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub gridResultsProd_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResultsProd.Sorting
        Select Case e.SortExpression.ToLower()


            Case "ds_estabelecimenro"
                If (ViewState.Item("sortExpression")) = "ds_estabelecimenro asc" Then
                    ViewState.Item("sortExpression") = "ds_estabelecimenro desc"
                Else
                    ViewState.Item("sortExpression") = "ds_estabelecimenro asc"
                End If

            Case "dt_referencia"
                If (ViewState.Item("sortExpression")) = "dt_referencia asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia asc"
                End If

            Case "nr_po"
                If (ViewState.Item("sortExpression")) = "nr_po asc" Then
                    ViewState.Item("sortExpression") = "nr_po desc"
                Else
                    ViewState.Item("sortExpression") = "nr_po asc"
                End If
            Case "id_situacao"
                If (ViewState.Item("sortExpression")) = "id_situacao asc" Then
                    ViewState.Item("sortExpression") = "id_situacao desc"
                Else
                    ViewState.Item("sortExpression") = "id_situacao asc"
                End If
            Case "nm_estabelecimento"
                If (ViewState.Item("sortExpression")) = "nm_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "nm_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_estabelecimento asc"
                End If
            Case "nm_item"
                If (ViewState.Item("sortExpression")) = "nm_item asc" Then
                    ViewState.Item("sortExpression") = "nm_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_item asc"
                End If


        End Select

        loadData()

    End Sub

    Protected Sub lk_novo_cooperativa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo_cooperativa.Click
        'inicializa variaveis
        If cbo_tipo_fornecedor.SelectedValue.Equals("P") Then 'se tipo for produtor
            ViewState.Item("id_estado") = cbo_estado.SelectedValue
            If txt_dt_referencia.Text.Equals(String.Empty) Then
                ViewState.Item("dt_referencia") = txt_dt_referencia.Text
            Else
                ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)

            End If
        Else
            ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
            If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            Else
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            End If
            ViewState.Item("dt_inicio_start") = txt_dt_ini.Text
            ViewState.Item("dt_inicio_end") = txt_dt_fim.Text
        End If

        ViewState.Item("nr_po") = txt_nr_po.Text
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        ViewState.Item("tipo_fornecedor") = cbo_tipo_fornecedor.SelectedValue
        ViewState("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState("id_item") = cbo_item.SelectedValue

        saveFilters()
        Response.Redirect("frm_po_cooperativa.aspx")


    End Sub

    Protected Sub lk_nova_agropecuaria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_nova_agropecuaria.Click
        'inicializa variaveis
        If cbo_tipo_fornecedor.SelectedValue.Equals("P") Then 'se tipo for produtor
            ViewState.Item("id_estado") = cbo_estado.SelectedValue
            If txt_dt_referencia.Text.Equals(String.Empty) Then
                ViewState.Item("dt_referencia") = txt_dt_referencia.Text
            Else
                ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)

            End If
        Else
            ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
            If Not (Me.hf_id_pessoa.Value.Equals(String.Empty)) Then
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            Else
                ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
            End If
            ViewState.Item("dt_inicio_start") = txt_dt_ini.Text
            ViewState.Item("dt_inicio_end") = txt_dt_fim.Text
        End If

        ViewState.Item("nr_po") = txt_nr_po.Text
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        ViewState.Item("tipo_fornecedor") = cbo_tipo_fornecedor.SelectedValue
        ViewState("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState("id_item") = cbo_item.SelectedValue

        saveFilters()
        Response.Redirect("frm_po_agropecuaria.aspx")


    End Sub

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposProdutor()
        Else
            txt_cd_pessoa.Text = String.Empty
            hf_id_pessoa.Value = String.Empty
            lbl_nm_pessoa.Text = String.Empty
            lbl_nm_pessoa.Visible = False
        End If

    End Sub

    Protected Sub gridResultsAgro_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResultsAgro.PageIndexChanging
        gridResultsAgro.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResultsAgro_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResultsAgro.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_po_agropecuaria.aspx?id_po_agropecuaria=" + e.CommandArgument.ToString())

            Case "delete"
                deletePOAgropecuaria(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select


    End Sub

    Protected Sub gridResultsAgro_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResultsAgro.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            e.Row.Cells(3).Text = DateTime.Parse(e.Row.Cells(3).Text).ToString("dd/MM/yyyy") 'dt_inicio
            e.Row.Cells(4).Text = DateTime.Parse(e.Row.Cells(4).Text).ToString("dd/MM/yyyy") 'dt_fim
            If e.Row.Cells(6).Text.Trim.Equals("1") Then 'situacao
                e.Row.Cells(6).Text = "Ativo"

            Else
                e.Row.Cells(6).Text = "Inativo"
            End If

        End If
    End Sub

    Protected Sub gridResultsAgro_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResultsAgro.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub gridResultsAgro_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResultsAgro.Sorting
        Select Case e.SortExpression.ToLower()


            Case "ds_agropecuaria"
                If (ViewState.Item("sortExpression")) = "ds_agropecuaria asc" Then
                    ViewState.Item("sortExpression") = "ds_agropecuaria desc"
                Else
                    ViewState.Item("sortExpression") = "ds_agropecuaria asc"
                End If

            Case "dt_inicio"
                If (ViewState.Item("sortExpression")) = "dt_inicio asc" Then
                    ViewState.Item("sortExpression") = "dt_inicio desc"
                Else
                    ViewState.Item("sortExpression") = "dt_inicio asc"
                End If

            Case "dt_fim"
                If (ViewState.Item("sortExpression")) = "dt_fim asc" Then
                    ViewState.Item("sortExpression") = "dt_fim desc"
                Else
                    ViewState.Item("sortExpression") = "dt_fim asc"
                End If

            Case "nr_po"
                If (ViewState.Item("sortExpression")) = "nr_po asc" Then
                    ViewState.Item("sortExpression") = "nr_po desc"
                Else
                    ViewState.Item("sortExpression") = "nr_po asc"
                End If
            Case "id_situacao"
                If (ViewState.Item("sortExpression")) = "id_situacao asc" Then
                    ViewState.Item("sortExpression") = "id_situacao desc"
                Else
                    ViewState.Item("sortExpression") = "id_situacao asc"
                End If
            Case "nm_estabelecimento"
                If (ViewState.Item("sortExpression")) = "nm_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "nm_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_estabelecimento asc"
                End If
            Case "nm_item"
                If (ViewState.Item("sortExpression")) = "nm_item asc" Then
                    ViewState.Item("sortExpression") = "nm_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_item asc"
                End If


        End Select

        loadData()

    End Sub
End Class
