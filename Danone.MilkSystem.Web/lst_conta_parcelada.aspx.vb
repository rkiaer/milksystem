Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_conta_parcelada

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("id_pessoa") = String.Empty
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("cd_conta") = Me.txt_cd_conta.Text.Trim
        ViewState.Item("nm_conta") = Me.txt_nm_conta.Text.Trim
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue
        ViewState.Item("dt_inicio") = Me.txt_dt_inicio.Text.Trim
        ViewState.Item("id_romaneio") = Me.txt_romaneio.Text.Trim 'fran 06/2016
        ViewState.Item("cbo_gridromaneio") = Me.cbo_gridromaneio.SelectedValue 'fran 06/2016

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_conta_parcelada.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_conta_parcelada.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 33
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

            ViewState.Item("sortExpression") = "cd_conta asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("conta_parcelada", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("conta_parcelada", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("conta_parcelada", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("conta_parcelada", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("conta_parcelada", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("conta_parcelada", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("conta_parcelada", txt_cd_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("conta_parcelada", txt_cd_propriedade.ID)
            txt_cd_propriedade.Text = ViewState.Item("id_propriedade").ToString()

        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("conta_parcelada", lbl_nm_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_propriedade") = customPage.getFilterValue("conta_parcelada", lbl_nm_propriedade.ID)
            lbl_nm_propriedade.Text = ViewState.Item("nm_propriedade").ToString()
            hf_id_propriedade.Value = ViewState.Item("id_propriedade")
        Else
            ViewState.Item("nm_propriedade") = String.Empty
            hf_id_propriedade.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("conta_parcelada", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("conta_parcelada", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("conta_parcelada", txt_cd_conta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_conta") = customPage.getFilterValue("conta_parcelada", txt_cd_conta.ID)
            txt_cd_conta.Text = ViewState.Item("cd_conta").ToString()
        Else
            ViewState.Item("cd_conta") = String.Empty
        End If

        If Not (customPage.getFilterValue("conta_parcelada", txt_nm_conta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_conta") = customPage.getFilterValue("conta_parcelada", txt_nm_conta.ID)
            txt_nm_conta.Text = ViewState.Item("nm_conta").ToString()
        Else
            ViewState.Item("nm_conta") = String.Empty
        End If

        If Not (customPage.getFilterValue("conta_parcelada", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("conta_parcelada", cbo_situacao.ID)
            cbo_situacao.SelectedValue = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If
        'fran 06/2016 i
        If Not (customPage.getFilterValue("conta_parcelada", cbo_gridromaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cbo_gridromaneio") = "S"
            cbo_gridromaneio.SelectedValue = "S"
            rf_produtor.Enabled = False
            rf_propriedade.Enabled = False
            txt_romaneio.Enabled = True
        Else
            ViewState.Item("cbo_gridromaneio") = "N"
        End If
        If Not (customPage.getFilterValue("conta_parcelada", txt_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("conta_parcelada", txt_romaneio.ID)
            txt_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If
        'fran 06/2016 f

        If Not (customPage.getFilterValue("conta_parcelada", txt_dt_inicio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_inicio") = customPage.getFilterValue("conta_parcelada", txt_dt_inicio.ID)
            txt_dt_inicio.Text = ViewState.Item("dt_inicio").ToString()
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If


        If Not (customPage.getFilterValue("conta_parcelada", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("conta_parcelada", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("conta_parcelada")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim contaparcelada As New ContaParcelada

            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                contaparcelada.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            contaparcelada.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            contaparcelada.cd_pessoa = ViewState.Item("cd_pessoa").ToString
            contaparcelada.cd_conta = ViewState.Item("cd_conta").ToString
            contaparcelada.nm_conta = ViewState.Item("nm_conta").ToString
            contaparcelada.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            contaparcelada.dt_inicio_desconto = ViewState.Item("dt_inicio").ToString


            If ViewState.Item("cbo_gridromaneio").ToString.Equals("S") Then
                If ViewState.Item("id_romaneio").Equals(String.Empty) Then
                    contaparcelada.id_romaneio = 0
                Else
                    contaparcelada.id_romaneio = ViewState.Item("id_romaneio")

                End If



                gridResults.Visible = False

                Dim dsContaParcelada As DataSet = contaparcelada.getContaParceladaRomaneio()

                If (dsContaParcelada.Tables(0).Rows.Count > 0) Then
                    gridContasRomaneio.Visible = True
                    gridContasRomaneio.DataSource = Helper.getDataView(dsContaParcelada.Tables(0), ViewState.Item("sortExpression"))
                    gridContasRomaneio.DataBind()
                Else
                    gridContasRomaneio.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If

            Else
                gridContasRomaneio.Visible = False
                Dim dsContaParcelada As DataSet = contaparcelada.getContaParceladaByFilters()

                If (dsContaParcelada.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsContaParcelada.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If

            End If




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridContasRomaneio_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridContasRomaneio.PageIndexChanging
        gridContasRomaneio.PageIndex = e.NewPageIndex
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


            Case "cd_conta"
                If (ViewState.Item("sortExpression")) = "cd_conta asc" Then
                    ViewState.Item("sortExpression") = "cd_conta desc"
                Else
                    ViewState.Item("sortExpression") = "cd_conta asc"
                End If

            Case "nm_conta"
                If (ViewState.Item("sortExpression")) = "nm_conta asc" Then
                    ViewState.Item("sortExpression") = "nm_conta desc"
                Else
                    ViewState.Item("sortExpression") = "nm_conta asc"
                End If

            Case "dt_inicio_desconto"
                If (ViewState.Item("sortExpression")) = "dt_inicio_desconto asc" Then
                    ViewState.Item("sortExpression") = "dt_inicio_desconto desc"
                Else
                    ViewState.Item("sortExpression") = "dt_inicio_desconto asc"
                End If

        End Select

        loadData()

    End Sub
    Protected Sub gridContasRomaneio_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridContasRomaneio.Sorting

        Select Case e.SortExpression.ToLower()


            Case "id_romaneio"
                If (ViewState.Item("sortExpression")) = "id_romaneio asc" Then
                    ViewState.Item("sortExpression") = "id_romaneio desc"
                Else
                    ViewState.Item("sortExpression") = "id_romaneio asc"
                End If


            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If


            Case "cd_conta"
                If (ViewState.Item("sortExpression")) = "cd_conta asc" Then
                    ViewState.Item("sortExpression") = "cd_conta desc"
                Else
                    ViewState.Item("sortExpression") = "cd_conta asc"
                End If

            Case "nm_conta"
                If (ViewState.Item("sortExpression")) = "nm_conta asc" Then
                    ViewState.Item("sortExpression") = "nm_conta desc"
                Else
                    ViewState.Item("sortExpression") = "nm_conta asc"
                End If

            Case "dt_inicio_desconto"
                If (ViewState.Item("sortExpression")) = "dt_inicio_desconto asc" Then
                    ViewState.Item("sortExpression") = "dt_inicio_desconto desc"
                Else
                    ViewState.Item("sortExpression") = "dt_inicio_desconto asc"
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


            customPage.setFilter("conta_parcelada", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("conta_parcelada", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("conta_parcelada", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("conta_parcelada", txt_cd_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("conta_parcelada", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("conta_parcelada", lbl_nm_propriedade.ID, ViewState.Item("nm_propriedade").ToString)
            customPage.setFilter("conta_parcelada", txt_cd_conta.ID, ViewState.Item("cd_conta").ToString)
            customPage.setFilter("conta_parcelada", txt_nm_conta.ID, ViewState.Item("nm_conta").ToString)
            customPage.setFilter("conta_parcelada", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("conta_parcelada", txt_dt_inicio.ID, ViewState.Item("dt_inicio").ToString)
            customPage.setFilter("conta_parcelada", txt_romaneio.ID, ViewState.Item("id_romaneio").ToString)
            customPage.setFilter("conta_parcelada", cbo_gridromaneio.ID, ViewState.Item("cbo_gridromaneio").ToString)
            customPage.setFilter("conta_parcelada", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_conta_parcelada.aspx?id_conta_parcelada=" + e.CommandArgument.ToString())

            Case "delete"
                deleteContaParcelada(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Protected Sub gridContasRomaneio_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridContasRomaneio.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_conta_parcelada.aspx?id_conta_parcelada=" + e.CommandArgument.ToString())

            Case "delete"
                deleteContaParcelada(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteContaParcelada(ByVal id_conta_parcelada As Integer)

        Try
            Dim contaparcelada As New ContaParcelada()
            contaparcelada.id_conta_parcelada = id_conta_parcelada
            contaparcelada.id_modificador = Convert.ToInt32(Session("id_login"))
            contaparcelada.deleteContaParcelada()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 33
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
        Response.Redirect("frm_conta_parcelada.aspx")
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
    Protected Sub gridContasRomaneio_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridContasRomaneio.RowDeleting
        e.Cancel = True
    End Sub
    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        Me.lbl_nm_pessoa.Text = ""
        Me.txt_cd_pessoa.Text = ""
        Me.hf_id_pessoa.Value = ""
        Me.lbl_nm_pessoa.Visible = False
        Me.lbl_nm_propriedade.Text = ""
        Me.txt_cd_propriedade.Text = ""
        Me.hf_id_propriedade.Value = ""
        Me.lbl_nm_propriedade.Visible = False

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

    Protected Sub cbo_gridromaneio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_gridromaneio.SelectedIndexChanged
        If cbo_gridromaneio.SelectedValue = "S" Then 'se deve visualizar as contas de romaneio
            rf_produtor.Enabled = False
            rf_propriedade.Enabled = False
            txt_romaneio.Enabled = True
        Else
            rf_produtor.Enabled = True
            rf_propriedade.Enabled = True
            txt_romaneio.Enabled = False
            txt_romaneio.Text = String.Empty
        End If
    End Sub
End Class
