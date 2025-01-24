Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_relatorio_propriedades_excel
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()

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
        ViewState.Item("id_grupo") = cbo_grupo.SelectedValue
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

        'chamado 15777 - 02/08/2012 - Mirella i
        If Not (txt_cd_sap.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_codigo_sap") = txt_cd_sap.Text.Trim()
        Else
            ViewState.Item("cd_codigo_sap") = String.Empty
        End If
        'chamado 1577 - 02/08/2012 - Mirella f

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_relatorio_propriedades_excel.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_propriedade.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 111
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Produtores"
            '.Style("cursor") = "hand"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()


            ViewState.Item("sortExpression") = "Produtor asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadData()

        Try
            Dim propriedade As New Propriedade

            If Not (ViewState.Item("id_propriedade").Equals(String.Empty)) Then
                propriedade.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            Else
                propriedade.id_propriedade = 0
            End If
            If Not (ViewState.Item("id_pessoa").Equals(String.Empty)) Then
                propriedade.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            Else
                propriedade.id_pessoa = 0
            End If

            propriedade.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            propriedade.id_grupo = ViewState.Item("id_grupo")
            propriedade.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            propriedade.cd_pessoa = ViewState.Item("cd_pessoa").ToString

            'chamado 1576 - 01/08/2012 - Mirella i
            If Not (ViewState("cd_codigo_sap").ToString().Equals(String.Empty)) Then
                propriedade.cd_codigo_SAP = Convert.ToString(ViewState.Item("cd_codigo_sap"))
            End If
            'chamado 1576 - 01/08/2012 - Mirella f


            Dim dsPropriedade As DataSet = propriedade.getRelatorioPropriedade()

            If (dsPropriedade.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPropriedade.Tables(0), ViewState.Item("sortExpression"))
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


            Case "cod_produtor"
                If (ViewState.Item("sortExpression")) = "cod_produtor asc" Then
                    ViewState.Item("sortExpression") = "cod_produtor desc"
                Else
                    ViewState.Item("sortExpression") = "cod_produtor asc"
                End If

            Case "produtor"
                If (ViewState.Item("sortExpression")) = "produtor asc" Then
                    ViewState.Item("sortExpression") = "produtor desc"
                Else
                    ViewState.Item("sortExpression") = "produtor asc"
                End If

            Case "cod_propriedade"
                If (ViewState.Item("sortExpression")) = "cod_propriedade asc" Then
                    ViewState.Item("sortExpression") = "cod_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "cod_propriedade asc"
                End If

            Case "propriedade"
                If (ViewState.Item("sortExpression")) = "propriedade asc" Then
                    ViewState.Item("sortExpression") = "propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "propriedade asc"
                End If
            Case "UP"
                If (ViewState.Item("sortExpression")) = "UP asc" Then
                    ViewState.Item("sortExpression") = "UP desc"
                Else
                    ViewState.Item("sortExpression") = "UP asc"
                End If

            Case "situacao"
                If (ViewState.Item("sortExpression")) = "situacao asc" Then
                    ViewState.Item("sortExpression") = "situacao desc"
                Else
                    ViewState.Item("sortExpression") = "situacao asc"
                End If

            Case "estabelecimento"
                If (ViewState.Item("sortExpression")) = "estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "estabelecimento asc"
                End If

            Case "nm_cluster" 'fran 06/2015
                If (ViewState.Item("sortExpression")) = "nm_cluster asc" Then
                    ViewState.Item("sortExpression") = "nm_cluster desc"
                Else
                    ViewState.Item("sortExpression") = "nm_cluster asc"
                End If

                'chamado 15777 - 02/08/2012 - Mirella i
            Case "cd_codigo_sap"
                If (ViewState.Item("sortExpression")) = "cd_codigo_sap asc" Then
                    ViewState.Item("sortExpression") = "cd_codigo_sap desc"
                Else
                    ViewState.Item("sortExpression") = "cd_codigo_sap asc"
                End If
                'chamado 15777 - 02/08/2012 - Mirella i
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

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_propriedade.aspx?id_propriedade=" + e.CommandArgument.ToString())

            Case "delete"
                deletePropriedade(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deletePropriedade(ByVal id_propriedade As Integer)

        Try
            Dim propriedade As New Propriedade()
            propriedade.id_propriedade = id_propriedade
            propriedade.id_modificador = Convert.ToInt32(Session("id_login"))
            propriedade.deletePropriedade()
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

 
    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click

        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()
    End Sub


    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        lbl_nm_pessoa.Visible = False
        hf_id_pessoa.Value = String.Empty

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = hf_id_pessoa.Value
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text
        ViewState.Item("id_propriedade") = txt_id_propriedade.Text
        ViewState.Item("id_grupo") = cbo_grupo.SelectedValue
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        'chamado 1576 - 02/08/2012 - Mirella i
        If Not (txt_cd_sap.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_codigo_sap") = txt_cd_sap.Text.Trim()
        Else
            ViewState.Item("cd_codigo_sap") = String.Empty
        End If
        'chamado 1576 - 02/08/2012 - Mirella f


        customPage.clearFilters("propriedade")
        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 111
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        saveFilters()
        Response.Redirect("frm_relatorio_propriedades_excel.aspx?id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&cd_pessoa=" + ViewState.Item("cd_pessoa").ToString() + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&id_grupo=" + ViewState.Item("id_grupo").ToString() + "&id_situacao=" + ViewState.Item("id_situacao").ToString() + "&cd_codigo_sap=" + ViewState.Item("cd_codigo_sap").ToString) 'chamado 1576 - 02/08/2012 - Mirella

    End Sub
    Private Sub saveFilters()

        Try
            customPage.setFilter("propriedade", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento"))
            customPage.setFilter("propriedade", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa"))
            customPage.setFilter("propriedade", hf_id_pessoa.ID, ViewState.Item("id_pessoa"))
            customPage.setFilter("propriedade", txt_id_propriedade.ID, ViewState.Item("id_propriedade"))
            customPage.setFilter("propriedade", cbo_grupo.ID, ViewState.Item("id_grupo").ToString)
            customPage.setFilter("propriedade", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("propriedade", txt_cd_sap.ID, ViewState.Item("cd_codigo_sap").ToString) 'chamado 1576 - 02/08/2012
            customPage.setFilter("propriedade", "PageIndex", gridResults.PageIndex.ToString())


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("propriedade", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("propriedade", cbo_estabelecimento.ID)
            cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("propriedade", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("propriedade", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If
        If Not (customPage.getFilterValue("propriedade", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("propriedade", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("propriedade", txt_id_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("propriedade", txt_id_propriedade.ID)
            txt_id_propriedade.Text = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If
        If Not (customPage.getFilterValue("propriedade", cbo_grupo.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_grupo") = customPage.getFilterValue("propriedade", cbo_grupo.ID)
            cbo_grupo.SelectedValue = ViewState.Item("id_grupo").ToString()
        Else
            ViewState.Item("id_grupo") = String.Empty
        End If
        If Not (customPage.getFilterValue("propriedade", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("propriedade", cbo_situacao.ID)
            cbo_situacao.SelectedValue = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        'chamado 1576 - 02/08/2012 - Mirella i
        If Not (customPage.getFilterValue("propriedade", txt_cd_sap.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_codigo_sap") = customPage.getFilterValue("propriedade", txt_cd_sap.ID)
            txt_cd_sap.Text = ViewState.Item("cd_codigo_sap").ToString()
        Else
            ViewState.Item("cd_codigo_sap") = String.Empty
        End If
        'chamado 1576 - 02/08/2012 - Mirella f

        If Not (customPage.getFilterValue("propriedade", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("propriedade", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("propriedade")
        End If

    End Sub
End Class
