Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_propriedade
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
        ViewState.Item("cd_codigo_SAP") = Me.txt_codigo_SAP.Text.Trim() ' 02/2012 - Projeto themis - i

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

        ViewState.Item("nm_propriedade") = Me.txt_nm_propriedade.Text.Trim
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue
        If Me.cbo_transferencia.SelectedValue.Equals("S") Then
            ViewState.Item("st_transferencia") = "S" 'fran 07/2016
        Else
            If Me.cbo_transferencia.SelectedValue.Equals("N") Then
                ViewState.Item("st_transferencia") = "N" 'fran 07/2016
            Else
                ViewState.Item("st_transferencia") = String.Empty 'fran 07/2016

            End If
        End If

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_propriedade.aspx?st_incluirlog=N")

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
                usuariolog.id_menu_item = 5
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


            ViewState.Item("sortExpression") = "nm_pessoa asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("propriedade", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("propriedade", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("propriedade", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("propriedade", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("propriedade", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("propriedade", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("propriedade", txt_id_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("propriedade", txt_id_propriedade.ID)
            txt_id_propriedade.Text = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("propriedade", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("propriedade", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("propriedade", txt_nm_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_propriedade") = customPage.getFilterValue("propriedade", txt_nm_propriedade.ID)
            txt_nm_propriedade.Text = ViewState.Item("nm_propriedade").ToString()
        Else
            ViewState.Item("nm_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("propriedade", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("propriedade", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("propriedade", cbo_transferencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("st_transferencia") = customPage.getFilterValue("propriedade", cbo_transferencia.ID)
            cbo_transferencia.Text = ViewState.Item("st_transferencia").ToString()
        Else
            ViewState.Item("st_transferencia") = String.Empty
        End If

        ' 02/2012 - Projeto themis - i
        If Not (customPage.getFilterValue("propriedade", txt_codigo_SAP.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_codigo_SAP") = customPage.getFilterValue("propriedade", txt_codigo_SAP.ID)
            txt_codigo_SAP.Text = ViewState.Item("cd_codigo_SAP").ToString()
        Else
            ViewState.Item("cd_codigo_SAP") = String.Empty
        End If
        ' 02/2012 - Projeto themis - f


        If Not (customPage.getFilterValue("propriedade", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("propriedade", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("propriedade")
        End If

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
            propriedade.nm_propriedade = ViewState.Item("nm_propriedade").ToString()
            propriedade.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            propriedade.cd_pessoa = ViewState.Item("cd_pessoa").ToString
            propriedade.cd_codigo_SAP = ViewState.Item("cd_codigo_SAP").ToString  ' 02/2012 - Projeto Themis
            propriedade.st_transferencia = ViewState.Item("st_transferencia").ToString 'fran 07/2016 i

            Dim dsPropriedade As DataSet = propriedade.getPropriedadeByFilters()

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


            Case "cd_pessoa"
                If (ViewState.Item("sortExpression")) = "cd_pessoa asc" Then
                    ViewState.Item("sortExpression") = "cd_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "cd_pessoa asc"
                End If

            Case "nm_pessoa"
                If (ViewState.Item("sortExpression")) = "nm_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_pessoa asc"
                End If

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If

            Case "nm_propriedade"
                If (ViewState.Item("sortExpression")) = "nm_propriedade asc" Then
                    ViewState.Item("sortExpression") = "nm_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "nm_propriedade asc"
                End If

            Case "cd_codigo_SAP"  ' 02/2012 Projeto Themis
                If (ViewState.Item("sortExpression")) = "cd_codigo_SAP asc" Then
                    ViewState.Item("sortExpression") = "cd_codigo_SAP desc"
                Else
                    ViewState.Item("sortExpression") = "cd_codigo_SAP asc"
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


            customPage.setFilter("propriedade", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("propriedade", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("propriedade", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("propriedade", txt_id_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("propriedade", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("propriedade", txt_nm_propriedade.ID, ViewState.Item("nm_propriedade").ToString)
            customPage.setFilter("propriedade", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("propriedade", cbo_transferencia.ID, ViewState.Item("st_transferencia").ToString)
            customPage.setFilter("propriedade", txt_codigo_SAP.ID, ViewState.Item("cd_codigo_SAP").ToString)  ' 02/2012 - Projeto themis - i
            customPage.setFilter("propriedade", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    'Private Sub salvarParametrosLupa()

    '    Try
    '        customPage.clearFilters("lupa_estabel")
    '        customPage.setFilter("lupa_estabel", "id_estabelecimento.lupa", cbo_estabelecimento.SelectedValue)

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub
    'Private Sub adicionarAtributoLupa()

    '    Try
    '        With bt_lupa_produtor
    '            .Attributes.Add("onclick", "javascript:ShowDialog()")
    '            .ToolTip = "Filtrar Produtores"
    '        End With

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub


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
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 5
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
        Response.Redirect("frm_propriedade.aspx")
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
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
        End If
    End Sub


    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        lbl_nm_pessoa.Visible = False
        hf_id_pessoa.Value = String.Empty

    End Sub
End Class
