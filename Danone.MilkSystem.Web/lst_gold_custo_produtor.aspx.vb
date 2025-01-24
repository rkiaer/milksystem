Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_gold_custo_produtor

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("dt_referencia_inicial") = Me.txt_dt_referencia_inicial.Text()
            ViewState.Item("dt_referencia_final") = Me.txt_dt_referencia_final.Text()
            ViewState.Item("cd_pessoa") = Me.txt_cd_pessoa.Text.Trim()
            ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
            ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue

            loadData()
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_gold_custo_produtor.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_gold_custo_produtor.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Produtores"
        End With
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
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

            Dim status As New Situacao

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()

            ViewState.Item("sortExpression") = "dt_referencia_inicial desc"

            loadFilters()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("gold_custo_produtor", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("gold_custo_produtor", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("gold_custo_produtor", txt_dt_referencia_inicial.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia_inicial") = customPage.getFilterValue("gold_custo_produtor", txt_dt_referencia_inicial.ID)
            txt_dt_referencia_inicial.Text = ViewState.Item("dt_referencia_inicial").ToString()
        Else
            ViewState.Item("dt_referencia_inicial") = String.Empty
        End If


        If Not (customPage.getFilterValue("gold_custo_produtor", txt_dt_referencia_final.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia_final") = customPage.getFilterValue("gold_custo_produtor", txt_dt_referencia_final.ID)
            txt_dt_referencia_final.Text = ViewState.Item("dt_referencia_final").ToString()
        Else
            ViewState.Item("dt_referencia_final") = String.Empty
        End If


        If Not (customPage.getFilterValue("gold_custo_produtor", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("gold_custo_produtor", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If

        '===
        If Not (customPage.getFilterValue("gold_custo_produtor", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("gold_custo_produtor", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("gold_custo_produtor", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("gold_custo_produtor", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
            lbl_nm_pessoa.Visible = True
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("gold_custo_produtor", txt_cd_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("gold_custo_produtor", txt_cd_propriedade.ID)
            txt_cd_propriedade.Text = ViewState.Item("id_propriedade").ToString()
            hf_id_propriedade.Value = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("gold_custo_produtor", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("gold_custo_produtor", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
            hf_id_pessoa.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("gold_custo_produtor", lbl_nm_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_propriedade") = customPage.getFilterValue("gold_custo_produtor", lbl_nm_propriedade.ID)
            lbl_nm_propriedade.Text = ViewState.Item("nm_propriedade").ToString()
            lbl_nm_propriedade.Visible = True
        Else
            ViewState.Item("nm_propriedade") = String.Empty
        End If


        If Not (customPage.getFilterValue("gold_custo_produtor", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("gold_custo_produtor", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("gold_custo_produtor")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim goldcustoprodutor As New GoldCustoProdutor

            goldcustoprodutor.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            If ViewState("dt_referencia_inicial").ToString <> "" Then
                goldcustoprodutor.dt_referencia_inicial = String.Concat("01/" & ViewState("dt_referencia_inicial").ToString)
            End If
            If ViewState("dt_referencia_final").ToString <> "" Then
                goldcustoprodutor.dt_referencia_final = String.Concat("01/" & ViewState("dt_referencia_final").ToString)
            End If
            goldcustoprodutor.cd_pessoa = ViewState.Item("cd_pessoa").ToString
            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                goldcustoprodutor.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            If Trim(ViewState.Item("id_situacao")) <> "" Then
                goldcustoprodutor.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            End If

            Dim dsGoldCustoProdutor As DataSet = goldcustoprodutor.getGoldCustoProdutorByFilters()

            If (dsGoldCustoProdutor.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsGoldCustoProdutor.Tables(0), ViewState.Item("sortExpression"))
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


            Case "dt_referencia_inicial"
                If (ViewState.Item("sortExpression")) = "dt_referencia_inicial asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia_inicial desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia_inicial asc"
                End If

            Case "dt_referencia_final"
                If (ViewState.Item("sortExpression")) = "dt_referencia_final asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia_final desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia_final asc"
                End If


        End Select

        loadData()

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("gold_custo_produtor", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("gold_custo_produtor", txt_dt_referencia_inicial.ID, ViewState.Item("dt_referencia_inicial").ToString)
            customPage.setFilter("gold_custo_produtor", txt_dt_referencia_final.ID, ViewState.Item("dt_referencia_final").ToString)
            customPage.setFilter("gold_custo_produtor", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("gold_custo_produtor", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("gold_custo_produtor", txt_cd_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("gold_custo_produtor", hf_id_pessoa.ID, hf_id_pessoa.Value)
            customPage.setFilter("gold_custo_produtor", lbl_nm_propriedade.ID, lbl_nm_propriedade.Text)
            customPage.setFilter("gold_custo_produtor", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("gold_custo_produtor", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_gold_custo_produtor.aspx?id_gold_custo_produtor=" + e.CommandArgument.ToString())
            Case "delete"
                deleteGoldCustoProdutor(e.CommandArgument.ToString())

        End Select

    End Sub

    Private Sub deleteGoldCustoProdutor(ByVal id_gold_custo_produtor As String)

        Try

            Dim goldcustoprodutor As New GoldCustoProdutor()
            goldcustoprodutor.id_gold_custo_produtor = Convert.ToInt32(id_gold_custo_produtor)
            goldcustoprodutor.id_modificador = Convert.ToInt32(Session("id_login"))
            goldcustoprodutor.deleteGoldCustoProdutor()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_gold_custo_produtor.aspx")
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()
    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty

        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Visible = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        Me.lbl_nm_pessoa.Text = ""
        Me.txt_cd_pessoa.Text = ""
        Me.hf_id_pessoa.Value = ""
        Me.lbl_nm_pessoa.Visible = False

    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        Me.lbl_nm_propriedade.Visible = True
        carregarCamposPropriedade()
    End Sub

    Private Sub carregarCamposPropriedade()

        Try



            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                ViewState.Item("id_propriedade") = Me.hf_id_propriedade.Value.ToString
                Me.txt_cd_propriedade.Text = ViewState.Item("id_propriedade")
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString

            End If

            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
        lbl_nm_propriedade.Text = String.Empty
        hf_id_propriedade.Value = String.Empty

        Try
            If Not txt_cd_propriedade.Text.Equals(String.Empty) Then
                Dim propriedade As New Propriedade
                propriedade.id_propriedade = Convert.ToInt32(txt_cd_propriedade.Text.Trim)
                Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters
                If dspropriedade.Tables(0).Rows.Count > 0 Then
                    lbl_nm_propriedade.Visible = True
                    lbl_nm_propriedade.Text = dspropriedade.Tables(0).Rows(0).Item("nm_propriedade")
                    hf_id_propriedade.Value = dspropriedade.Tables(0).Rows(0).Item("id_propriedade").ToString
                End If

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
