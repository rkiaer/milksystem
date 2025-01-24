Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_faixa_qualidade
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_categoria") = cbo_categoria_qualidade.SelectedValue
        ViewState.Item("ds_validade") = txt_ds_validade.Text.Trim()
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        'Fran 27/11/2009 i maracanau chamado 521
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        'Fran 27/11/2009 i maracanau chamado 521

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_faixa_qualidade.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_faixa_qualidade.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 37
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim categoria As New CategoriaQualidade

            cbo_categoria_qualidade.DataSource = categoria.getCategoriaByFilters()
            cbo_categoria_qualidade.DataTextField = "nm_categoria"
            cbo_categoria_qualidade.DataValueField = "id_categoria"
            cbo_categoria_qualidade.DataBind()
            cbo_categoria_qualidade.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim status As New Situacao

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            'Fran 27/11/2009 i chamado 521 Maracanau
            'cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_situacao.SelectedValue = 1

            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'Fran 27/11/2009 f chamado 521 Maracanau



            ViewState.Item("sortExpression") = "dt_validade asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("faixa", cbo_categoria_qualidade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_categoria") = customPage.getFilterValue("faixa", cbo_categoria_qualidade.ID)
            cbo_categoria_qualidade.Text = ViewState("id_categoria").ToString()
        Else
            ViewState.Item("id_categoria") = String.Empty
        End If

        If Not (customPage.getFilterValue("faixa", txt_ds_validade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_validade") = customPage.getFilterValue("faixa", txt_ds_validade.ID)
            txt_ds_validade.Text = ViewState.Item("ds_validade").ToString()
        Else
            ViewState.Item("ds_validade") = String.Empty
        End If

        If Not (customPage.getFilterValue("faixa", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("faixa", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If
        'Fran 27/11/2009 i chamado 521 Maracanau
        If Not (customPage.getFilterValue("faixa", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("faixa", cbo_estabelecimento.ID)
            cbo_situacao.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If
        'Fran 27/11/2009 f chamado 521 Maracanau

        If Not (customPage.getFilterValue("faixa", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("faixa", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("faixa")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim faixaqualidade As New FaixaQualidade


            faixaqualidade.id_categoria = Convert.ToInt32(ViewState.Item("id_categoria").ToString())
            faixaqualidade.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            faixaqualidade.ds_validade = ViewState.Item("ds_validade").ToString()
            If (faixaqualidade.ds_validade.ToString.Trim <> "") Then
                faixaqualidade.dt_validade = String.Concat("01/", faixaqualidade.ds_validade)
            End If

            'Fran 27/11/2009 i chamado 521 Maracanau
            If Not ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty) Then
                faixaqualidade.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
            End If
            'Fran 27/11/2009 f chamado 521 Maracanau

            Dim dsfaixaqualidade As DataSet = faixaqualidade.getFaixaQualidadeByFilters()

            If (dsfaixaqualidade.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsfaixaqualidade.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            'Fran 27/11/2009 i chamado 521 Maracanau
            Case "nm_estabelecimento"
                If (ViewState.Item("sortExpression")) = "nm_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "nm_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_estabelecimento asc"
                End If
                'Fran 27/11/2009 f chamado 521 Maracanau
            Case "dt_validade"
                If (ViewState.Item("sortExpression")) = "dt_validade asc" Then
                    ViewState.Item("sortExpression") = "dt_validade desc"
                Else
                    ViewState.Item("sortExpression") = "dt_validade asc"
                End If


            Case "nr_faixa_inicio"
                If (ViewState.Item("sortExpression")) = "nr_faixa_inicio asc" Then
                    ViewState.Item("sortExpression") = "nr_faixa_inicio desc"
                Else
                    ViewState.Item("sortExpression") = "nr_faixa_inicio asc"
                End If


            Case "nr_faixa_fim"
                If (ViewState.Item("sortExpression")) = "nr_faixa_fim asc" Then
                    ViewState.Item("sortExpression") = "nr_faixa_fim desc"
                Else
                    ViewState.Item("sortExpression") = "nr_faixa_fim asc"
                End If

            Case "nr_bonus_desconto"
                If (ViewState.Item("sortExpression")) = "nr_bonus_desconto asc" Then
                    ViewState.Item("sortExpression") = "nr_bonus_desconto desc"
                Else
                    ViewState.Item("sortExpression") = "nr_bonus_desconto asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("faixa", cbo_categoria_qualidade.ID, ViewState.Item("id_categoria").ToString)
            customPage.setFilter("faixa", txt_ds_validade.ID, ViewState.Item("ds_validade").ToString)
            customPage.setFilter("faixa", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            Dim Teste As Object = gridResults.PageIndex.ToString()
            customPage.setFilter("faixa", "PageIndex", gridResults.PageIndex.ToString())
            'Fran 27/11/2009 i chamado 521 Maracanau
            customPage.setFilter("faixa", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            'Fran 27/11/2009 f chamado 521 Maracanau

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_faixa_qualidade.aspx?id_faixa_qualidade=" + e.CommandArgument.ToString())

            Case "delete"
                deleteConta(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteConta(ByVal id_faixa_qualidade As Integer)

        Try

            Dim faixaqualidade As New FaixaQualidade()
            faixaqualidade.id_faixa_qualidade = id_faixa_qualidade
            faixaqualidade.id_modificador = Convert.ToInt32(Session("id_login"))
            faixaqualidade.deleteConta()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 37
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
        Response.Redirect("frm_faixa_qualidade.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub
End Class
