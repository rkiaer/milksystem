Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_lancamento

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        'If Not (txt_cd_propriedade.Text.Trim().Equals(String.Empty)) Then
        'ViewState.Item("id_pessoa") = Me.hf_id_pessoa
        'Else
        'ViewState.Item("id_pessoa") = "0"
        'End If
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        'If Not (txt_cd_propriedade.Text.Trim().Equals(String.Empty)) Then
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        'Else
        'ViewState.Item("id_propriedade") = "0"
        'End If
        ViewState.Item("cd_conta") = Me.txt_cd_conta.Text.Trim
        ViewState.Item("nm_conta") = Me.txt_nm_conta.Text.Trim
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue
        ViewState.Item("ds_referencia") = Me.txt_ds_referencia.Text.Trim
        ViewState.Item("id_importacao") = Me.txt_id_importacao.Text.Trim()

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_lancamento.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_lancamento.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 31
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If

        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Produtores"
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
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = "ds_conta asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("lancamento", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("lancamento", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancamento", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("lancamento", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancamento", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("lancamento", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancamento", txt_cd_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("lancamento", txt_cd_propriedade.ID)
            txt_cd_propriedade.Text = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancamento", lbl_nm_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_propriedade") = customPage.getFilterValue("lancamento", lbl_nm_propriedade.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_propriedade").ToString()
        Else
            ViewState.Item("nm_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancamento", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("lancamento", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancamento", txt_cd_conta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_conta") = customPage.getFilterValue("lancamento", txt_cd_conta.ID)
            txt_cd_conta.Text = ViewState.Item("cd_conta").ToString()
        Else
            ViewState.Item("cd_conta") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancamento", txt_nm_conta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_conta") = customPage.getFilterValue("lancamento", txt_nm_conta.ID)
            txt_nm_conta.Text = ViewState.Item("nm_conta").ToString()
        Else
            ViewState.Item("nm_conta") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancamento", txt_ds_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_referencia") = customPage.getFilterValue("lancamento", txt_ds_referencia.ID)
            txt_ds_referencia.Text = ViewState.Item("ds_referencia").ToString()
        Else
            ViewState.Item("ds_referencia") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancamento", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("lancamento", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancamento", txt_id_importacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_importacao") = customPage.getFilterValue("lancamento", txt_id_importacao.ID)
            txt_id_importacao.Text = ViewState.Item("id_importacao").ToString()
        Else
            ViewState.Item("id_importacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("lancamento", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("lancamento", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("lancamento")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim lancamento As New Lancamento

            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                lancamento.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            lancamento.nm_propriedade = ViewState.Item("nm_propriedade").ToString()
            lancamento.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            lancamento.cd_pessoa = ViewState.Item("cd_pessoa").ToString
            lancamento.cd_conta = ViewState.Item("cd_conta").ToString
            lancamento.nm_conta = ViewState.Item("nm_conta").ToString
            lancamento.id_estabelecimento = ViewState.Item("id_estabelecimento")
            lancamento.ds_referencia = ViewState.Item("ds_referencia").ToString()
            If (lancamento.ds_referencia.ToString.Trim <> "") Then
                lancamento.dt_referencia = String.Concat("01/", lancamento.ds_referencia)
            End If
            If Trim(ViewState.Item("id_importacao")) <> "" Then
                lancamento.id_importacao = Convert.ToInt32(ViewState.Item("id_importacao").ToString)
            End If

            Dim dsLancamento As DataSet = lancamento.getLancamentoByFilters()

            If (dsLancamento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsLancamento.Tables(0), ViewState.Item("sortExpression"))
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

            Case "id_conta"
                If (ViewState.Item("sortExpression")) = "id_conta asc" Then
                    ViewState.Item("sortExpression") = "id_conta desc"
                Else
                    ViewState.Item("sortExpression") = "id_conta asc"
                End If

            Case "nm_conta"
                If (ViewState.Item("sortExpression")) = "nm_conta asc" Then
                    ViewState.Item("sortExpression") = "nm_conta desc"
                Else
                    ViewState.Item("sortExpression") = "nm_conta asc"
                End If

            Case "ds_referencia"
                If (ViewState.Item("sortExpression")) = "ds_referencia asc" Then
                    ViewState.Item("sortExpression") = "ds_referencia desc"
                Else
                    ViewState.Item("sortExpression") = "ds_referencia asc"
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
    Private Sub saveFilters()

        Try


            customPage.setFilter("lancamento", txt_id_importacao.ID, ViewState.Item("id_importacao").ToString)
            customPage.setFilter("lancamento", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("lancamento", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("lancamento", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("lancamento", txt_cd_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("lancamento", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("lancamento", lbl_nm_propriedade.ID, ViewState.Item("nm_propriedade").ToString)
            customPage.setFilter("lancamento", txt_cd_conta.ID, ViewState.Item("cd_conta").ToString)
            customPage.setFilter("lancamento", txt_nm_conta.ID, ViewState.Item("nm_conta").ToString)
            customPage.setFilter("lancamento", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("lancamento", txt_ds_referencia.ID, ViewState.Item("ds_referencia").ToString)
            customPage.setFilter("lancamento", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_lancamento.aspx?id_lancamento=" + e.CommandArgument.ToString())

            Case "delete"
                deleteLancamento(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteLancamento(ByVal id_lancamento As Integer)

        Try
            Dim lancamento As New Lancamento()
            lancamento.id_lancamento = id_lancamento
            lancamento.id_modificador = Convert.ToInt32(Session("id_login"))
            lancamento.deleteLancamento()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 31
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_lancamento.aspx")
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
        Me.lbl_nm_pessoa.Text = ""
        Me.txt_cd_pessoa.Text = ""
        Me.hf_id_pessoa.Value = ""
        Me.lbl_nm_pessoa.Visible = False
    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()
    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        hf_id_pessoa.Value = String.Empty
        lbl_nm_pessoa.Text = String.Empty
        lbl_nm_pessoa.Visible = False
    End Sub
End Class
