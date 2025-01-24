Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_analise_esalq

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        'ViewState.Item("id_pessoa") = String.Empty
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("txt_dt_coleta_ini") = Me.txt_dt_coleta_ini.Text.Trim
        ViewState.Item("txt_dt_coleta_fim") = Me.txt_dt_coleta_fim.Text.Trim
        If (Me.txt_dt_coleta_fim.Text.Trim) = "" Then
            ViewState.Item("txt_dt_coleta_fim") = Me.txt_dt_coleta_ini.Text.Trim
        End If
        ViewState.Item("cd_analise_esalq") = Me.cbo_codigo_esalq.SelectedValue()
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue
        ViewState.Item("id_cooperativa") = Me.hf_id_cooperativa.Value
        ViewState.Item("cd_cooperativa") = txt_cd_cooperativa.Text.Trim()
        ViewState.Item("id_grupo") = Me.cbo_grupo.SelectedValue
        If Me.hf_id_cooperativa.Value.Equals(String.Empty) Then
            txt_cd_cooperativa.Text = String.Empty
        End If

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_analise_esalq.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_analise_esalq.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 27
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
        With btn_lupa_cooperativa
            .Attributes.Add("onclick", "javascript:ShowDialogCooperativa()")
            .ToolTip = "Filtrar Cooperativas"
        End With


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim codigoesalq As New CodigoEsalq

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_codigo_esalq.DataSource = codigoesalq.getCodigosEsalqByFilters()
            cbo_codigo_esalq.DataTextField = "ds_analise_esalq"
            cbo_codigo_esalq.DataValueField = "cd_analise_esalq"
            cbo_codigo_esalq.DataBind()
            cbo_codigo_esalq.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'fran dez/2018 i cooperativa
            Dim grupo As New Grupo
            cbo_grupo.DataSource = grupo.getGruposByFilters()
            cbo_grupo.DataTextField = "nm_grupo"
            cbo_grupo.DataValueField = "id_grupo"
            cbo_grupo.DataBind()
            cbo_grupo.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_grupo.Items.RemoveAt(2)   ' Remove item 2-Fornecedor de Insumos
            cbo_grupo.Items.RemoveAt(2)   ' Remove item 3-Transportador
            cbo_grupo.SelectedValue = 1   ' Assume como default na consulta o Produtor
            'fran dez/2018 f cooperativa


            txt_dt_coleta_ini.Text = "01/" & DateTime.Parse(Now).ToString("MM/yyyy")
            txt_dt_coleta_fim.Text = "01/" & DateTime.Parse(DateAdd(DateInterval.Month, 1, Convert.ToDateTime(txt_dt_coleta_ini.Text))).ToString("MM/yyyy")

            ViewState.Item("sortExpression") = ""

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("analise_esalq", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("analise_esalq", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("analise_esalq", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("analise_esalq", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq", txt_cd_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("analise_esalq", txt_cd_propriedade.ID)
            txt_cd_propriedade.Text = ViewState.Item("id_propriedade").ToString()

        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq(", lbl_nm_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_propriedade") = customPage.getFilterValue("analise_esalq", lbl_nm_propriedade.ID)
            lbl_nm_propriedade.Text = ViewState.Item("nm_propriedade").ToString()
            hf_id_propriedade.Value = ViewState.Item("id_propriedade")
        Else
            ViewState.Item("nm_propriedade") = String.Empty
            hf_id_propriedade.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("analise_esalq", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq", txt_dt_coleta_ini.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_coleta_ini") = customPage.getFilterValue("analise_esalq", txt_dt_coleta_ini.ID)
            txt_dt_coleta_ini.Text = ViewState.Item("txt_dt_coleta_ini").ToString()
        Else
            ViewState.Item("txt_dt_coleta_ini") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq", txt_dt_coleta_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("txt_dt_coleta_fim") = customPage.getFilterValue("analise_esalq", txt_dt_coleta_fim.ID)
            txt_dt_coleta_fim.Text = ViewState.Item("txt_dt_coleta_fim").ToString()
        Else
            ViewState.Item("txt_dt_coleta_fim") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq", cbo_codigo_esalq.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_analise_esalq") = customPage.getFilterValue("analise_esalq", cbo_codigo_esalq.ID)
            cbo_codigo_esalq.Text = ViewState.Item("cd_analise_esalq").ToString()
        Else
            ViewState.Item("cd_analise_esalq") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("analise_esalq", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If
        If Not (customPage.getFilterValue("analise_esalq", cbo_grupo.ID).Equals(String.Empty)) Then
            ViewState.Item("id_grupo") = customPage.getFilterValue("analise_esalq", cbo_grupo.ID)
            cbo_grupo.Text = ViewState.Item("id_grupo").ToString()
        Else
            ViewState.Item("id_grupo") = String.Empty
        End If
        If Not (customPage.getFilterValue("analise_esalq", hf_id_cooperativa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_cooperativa") = customPage.getFilterValue("analise_esalq", hf_id_cooperativa.ID)
            hf_id_cooperativa.Value = ViewState.Item("id_cooperativa").ToString()
        Else
            ViewState.Item("id_cooperativa") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq", txt_cd_cooperativa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_cooperativa") = customPage.getFilterValue("analise_esalq", txt_cd_cooperativa.ID)
            txt_cd_cooperativa.Text = ViewState.Item("cd_cooperativa").ToString()
        Else
            ViewState.Item("cd_cooperativa") = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq", lbl_nm_cooperativa.ID).Equals(String.Empty)) Then
            hasFilters = True
            lbl_nm_cooperativa.Text = customPage.getFilterValue("analise_esalq", lbl_nm_cooperativa.ID)
        Else
            lbl_nm_cooperativa.Text = String.Empty
        End If

        If Not (customPage.getFilterValue("analise_esalq", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("analise_esalq", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If
       
        If (hasFilters) Then
            loadData()
            customPage.clearFilters("analise_esalq")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim analiseesalq As New AnaliseEsalq

            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta_ini").ToString
            analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta_fim").ToString
            analiseesalq.cd_analise_esalq = Convert.ToInt32(ViewState.Item("cd_analise_esalq").ToString())
            'fran 27/11/2009 i maracanau chamado 523
            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'fran 27/11/2009 f maracanau chamado 523

            If Trim(ViewState.Item("id_pessoa")) <> "" Then
                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            End If
            If Trim(ViewState.Item("id_cooperativa")) <> "" Then
                analiseesalq.id_cooperativa = Convert.ToInt32(ViewState.Item("id_cooperativa").ToString)
            End If

            Dim dsAnaliseEsalc As DataSet = analiseesalq.getAnaliseEsalqByFilters()
            If Trim(ViewState.Item("id_grupo").ToString) = "4" Then 'cooperativa
                dsAnaliseEsalc = analiseesalq.getAnaliseEsalqCoopByFilters()
            End If

            If (dsAnaliseEsalc.Tables(0).Rows.Count > 0) Then
                If Trim(ViewState.Item("id_grupo").ToString) = "4" Then 'cooperativa
                    gridResults.Columns(0).Visible = True 'cd cooperativa
                    gridResults.Columns(1).Visible = True 'nm resumido cooperativa
                    gridResults.Columns(4).Visible = True 'nota fiscal
                    gridResults.Columns(2).Visible = False 'propriedade
                    gridResults.Columns(6).Visible = False 'data processamento
                Else
                    gridResults.Columns(0).Visible = False 'cd cooperativa
                    gridResults.Columns(1).Visible = False 'nm resumido cooperativa
                    gridResults.Columns(4).Visible = False 'nota fiscal
                    gridResults.Columns(2).Visible = True 'propriedade
                    gridResults.Columns(6).Visible = True 'data processamento

                End If
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


            Case "id_unid_producao"
                If (ViewState.Item("sortExpression")) = "id_unid_producao asc" Then
                    ViewState.Item("sortExpression") = "id_unid_producao desc"
                Else
                    ViewState.Item("sortExpression") = "id_unid_producao asc"
                End If


            Case "dt_coleta"
                If (ViewState.Item("sortExpression")) = "dt_coleta asc" Then
                    ViewState.Item("sortExpression") = "dt_coleta desc"
                Else
                    ViewState.Item("sortExpression") = "dt_coleta asc"
                End If


            Case "dt_processamento"
                If (ViewState.Item("sortExpression")) = "dt_processamento asc" Then
                    ViewState.Item("sortExpression") = "dt_processamento desc"
                Else
                    ViewState.Item("sortExpression") = "dt_processamento asc"
                End If

            Case "dt_analise"
                If (ViewState.Item("sortExpression")) = "dt_analise asc" Then
                    ViewState.Item("sortExpression") = "dt_analise desc"
                Else
                    ViewState.Item("sortExpression") = "dt_analise asc"
                End If

            Case "cd_analise_esalq"
                If (ViewState.Item("sortExpression")) = "ds_analise_esalq asc" Then
                    ViewState.Item("sortExpression") = "ds_analise_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "cd_analise_esalq asc"
                End If

            Case "nr_valor_esalq"
                If (ViewState.Item("sortExpression")) = "nr_valor_esalq asc" Then
                    ViewState.Item("sortExpression") = "nr_valor_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "nr_valor_esalq asc"
                End If
        End Select

        loadData()

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
    Private Sub carregarCamposPropriedade()

        Try

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If

            Me.txt_cd_propriedade.Text = Me.hf_id_propriedade.Value.ToString

            If Not (customPage.getFilterValue("lupa_propriedade", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "cd_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Visible = True
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_propriedade", "id_pessoa").Equals(String.Empty)) Then
                Me.hf_id_pessoa.Value = customPage.getFilterValue("lupa_propriedade", "id_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("analise_esaq", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("analise_esaq", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("analise_esaq", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("analise_esaq", txt_cd_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("analise_esaq", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("analise_esaq", lbl_nm_propriedade.ID, ViewState.Item("nm_propriedade").ToString)
            customPage.setFilter("analise_esaq", txt_dt_coleta_ini.ID, ViewState.Item("txt_dt_coleta_ini").ToString)
            customPage.setFilter("analise_esaq", txt_dt_coleta_fim.ID, ViewState.Item("txt_dt_coleta_fim").ToString)
            customPage.setFilter("analise_esaq", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("analise_esaq", cbo_codigo_esalq.ID, ViewState.Item("cd_analise_esalq").ToString)
            customPage.setFilter("analise_esaq", txt_cd_cooperativa.ID, ViewState.Item("cd_cooperativa").ToString)
            customPage.setFilter("analise_esaq", lbl_nm_cooperativa.ID, lbl_nm_cooperativa.Text)
            customPage.setFilter("analise_esaq", hf_id_cooperativa.ID, ViewState.Item("id_cooperativa").ToString)
            customPage.setFilter("analise_esaq", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_analise_esalq.aspx?id_analise_esalq=" + e.CommandArgument.ToString())

            Case "delete"
                deleteAnaliseEsalq(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteAnaliseEsalq(ByVal id_analise_esalq As Integer)

        Try
            Dim analiseesalq As New AnaliseEsalq()
            analiseesalq.id_analise_esalq = id_analise_esalq
            analiseesalq.id_modificador = Convert.ToInt32(Session("id_login"))
            analiseesalq.deleteAnaliseEsalq()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 27
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

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

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        'fran 28/11/2009 i chamado 523 - o estabelecimento é para saber para qual estabel é o arquivo a ser importado
        'Me.lbl_nm_pessoa.Text = ""
        'Me.txt_cd_pessoa.Text = ""
        'Me.hf_id_pessoa.Value = ""
        'Me.lbl_nm_pessoa.Visible = False
        'Me.lbl_nm_propriedade.Text = ""
        'Me.txt_cd_propriedade.Text = ""
        'Me.hf_id_propriedade.Value = ""
        'Me.lbl_nm_propriedade.Visible = False
        'fran 28/11/2009 f chamado 523
    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged

        lbl_nm_pessoa.Text = ""
        lbl_nm_pessoa.Visible = False
    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        If Me.cbo_estabelecimento.SelectedValue <> "0" Then
            Me.lbl_nm_propriedade.Visible = True
            carregarCamposPropriedade()
        End If
    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
        lbl_nm_propriedade.Text = ""
        lbl_nm_propriedade.Visible = False

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
            'lbl_cd_cnpj.Text = String.Empty
            'lbl_cd_cnpj.Visible = False
            'Me.lbl_nm_cnpj.Visible = False
        End If

    End Sub

    Protected Sub txt_cd_cooperativa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_cooperativa.TextChanged
        If Not txt_cd_cooperativa.Text.Equals(String.Empty) Then
            loadCooperativaByCodigo()
        Else
            lbl_nm_cooperativa.Text = String.Empty
            lbl_nm_cooperativa.Visible = False
            hf_id_cooperativa.Value = String.Empty
            'lbl_cd_cnpj.Text = String.Empty
            'lbl_cd_cnpj.Visible = False
            'Me.lbl_nm_cnpj.Visible = False
        End If

    End Sub
    Private Sub loadCooperativaByCodigo()

        Try


            Dim cooperativa As New Pessoa
            cooperativa.cd_pessoa = txt_cd_cooperativa.Text
            Dim dscooperativa As DataSet = cooperativa.getCooperativasByCodigo()
            If dscooperativa.Tables(0).Rows.Count > 0 Then
                lbl_nm_cooperativa.Visible = True
                'lbl_cd_cnpj.Visible = True
                'Me.lbl_nm_cnpj.Visible = True
                lbl_nm_cooperativa.Text = dscooperativa.Tables(0).Rows(0).Item("nm_pessoa")
                'lbl_cd_cnpj.Text = dscooperativa.Tables(0).Rows(0).Item("cd_cnpj")
                hf_id_cooperativa.Value = dscooperativa.Tables(0).Rows(0).Item("id_pessoa")
            Else
                lbl_nm_cooperativa.Visible = False
                'lbl_cd_cnpj.Visible = False
                'Me.lbl_nm_cnpj.Visible = False
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

            'If Not (customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").Equals(String.Empty)) Then
            '    Me.lbl_cd_cnpj.Visible = True
            '    Me.lbl_cd_cnpj.Text = customPage.getFilterValue("lupa_cooperativa", "cnpj_cooperativa").ToString
            '    Me.lbl_nm_cnpj.Visible = True
            'End If

            'loadData()
            customPage.clearFilters("lupa_cooperativa")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        'ViewState.Item("id_pessoa") = String.Empty
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("txt_dt_coleta_ini") = Me.txt_dt_coleta_ini.Text.Trim
        ViewState.Item("txt_dt_coleta_fim") = Me.txt_dt_coleta_fim.Text.Trim
        If (Me.txt_dt_coleta_fim.Text.Trim) = "" Then
            ViewState.Item("txt_dt_coleta_fim") = Me.txt_dt_coleta_ini.Text.Trim
        End If
        ViewState.Item("cd_analise_esalq") = Me.cbo_codigo_esalq.SelectedValue()
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue
        ViewState.Item("id_cooperativa") = Me.hf_id_cooperativa.Value
        ViewState.Item("cd_cooperativa") = txt_cd_cooperativa.Text.Trim()
        ViewState.Item("id_grupo") = Me.cbo_grupo.SelectedValue
        If Me.hf_id_cooperativa.Value.Equals(String.Empty) Then
            txt_cd_cooperativa.Text = String.Empty
        End If

        loadData()


        saveFilters()

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 27
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 


        Response.Redirect("frm_analise_esalq_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&txt_dt_coleta_ini=" + ViewState.Item("txt_dt_coleta_ini").ToString() + "&txt_dt_coleta_fim=" + ViewState.Item("txt_dt_coleta_fim").ToString() + "&cd_analise_esalq=" + ViewState.Item("cd_analise_esalq").ToString() + "&id_situacao=" + ViewState.Item("id_situacao").ToString() + "&id_cooperativa=" + ViewState.Item("id_cooperativa").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString())

    End Sub
End Class
