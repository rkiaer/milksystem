Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_faixa_qualidade_complience
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_categoria") = cbo_categoria_qualidade.SelectedValue
        ViewState.Item("dt_validade") = txt_dt_validade.Text.Trim()
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_faixa_qualidade_complience.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_faixa_qualidade_complience.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 172
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim categoria As New CategoriaQualidade

            cbo_categoria_qualidade.DataSource = categoria.getCategoriaComplience()
            cbo_categoria_qualidade.DataTextField = "nm_categoria"
            cbo_categoria_qualidade.DataValueField = "id_categoria"
            cbo_categoria_qualidade.DataBind()
            cbo_categoria_qualidade.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim status As New Situacao

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.SelectedValue = 1

            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))




            ViewState.Item("sortExpression") = "ds_validade asc"

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

        If Not (customPage.getFilterValue("faixa", txt_dt_validade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_validade") = customPage.getFilterValue("faixa", txt_dt_validade.ID)
            txt_dt_validade.Text = ViewState.Item("dt_validade").ToString()
        Else
            ViewState.Item("dt_validade") = String.Empty
        End If

        If Not (customPage.getFilterValue("faixa", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("faixa", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("faixa", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("faixa", cbo_estabelecimento.ID)
            cbo_situacao.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If


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
            Dim faixaqualidade As New FaixaQualidadeComplience


            faixaqualidade.id_categoria = Convert.ToInt32(ViewState.Item("id_categoria").ToString())
            faixaqualidade.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            faixaqualidade.dt_validade = ViewState.Item("dt_validade").ToString()
            If (faixaqualidade.dt_validade.ToString.Trim <> "") Then
                faixaqualidade.dt_validade = String.Concat("01/", faixaqualidade.dt_validade)
            End If


            If Not ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty) Then
                faixaqualidade.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
            End If


            Dim dsfaixaqualidade As DataSet = faixaqualidade.getFaixaQualidadeComplienceByFilters()

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


            Case "nm_estabelecimento"
                If (ViewState.Item("sortExpression")) = "nm_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "nm_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_estabelecimento asc"
                End If


            Case "ds_validade"
                If (ViewState.Item("sortExpression")) = "ds_validade asc" Then
                    ViewState.Item("sortExpression") = "ds_validade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_validade asc"
                End If

            Case "ds_faixa_qualidade_complience"
                If (ViewState.Item("sortExpression")) = "ds_faixa_qualidade_complience asc" Then
                    ViewState.Item("sortExpression") = "ds_faixa_qualidade_complience desc"
                Else
                    ViewState.Item("sortExpression") = "ds_faixa_qualidade_complience asc"
                End If





        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("faixa", cbo_categoria_qualidade.ID, ViewState.Item("id_categoria").ToString)
            customPage.setFilter("faixa", txt_dt_validade.ID, ViewState.Item("dt_validade").ToString)
            customPage.setFilter("faixa", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)

            Dim Teste As Object = gridResults.PageIndex.ToString()
            customPage.setFilter("faixa", "PageIndex", gridResults.PageIndex.ToString())
            customPage.setFilter("faixa", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_faixa_qualidade_complience.aspx?id_faixa_qualidade_complience=" + e.CommandArgument.ToString())

            Case "delete"
                deleteConta(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteConta(ByVal id_faixa_qualidade As Integer)

        Try

            Dim faixaqualidade As New FaixaQualidadeComplience()
            faixaqualidade.id_faixa_qualidade_complience = id_faixa_qualidade
            faixaqualidade.id_modificador = Convert.ToInt32(Session("id_login"))
            faixaqualidade.deleteConta()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 172
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
        Response.Redirect("frm_faixa_qualidade_complience.aspx")
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
