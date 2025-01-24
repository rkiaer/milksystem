Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_unidade_producao
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_unidade_producao.aspx?st_incluirlog=N")

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
                usuariolog.ds_nm_processo = "Propriedade - Unidade de Produção"
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao


            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue.ToString
            ViewState.Item("sortExpression") = "nm_unid_producao asc"

            If Not (Request("id_propriedade") Is Nothing) Then
                hf_id_propriedade.Value = Request("id_propriedade")
                loadFilters()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        Dim propriedade As New Propriedade(Convert.ToInt32(hf_id_propriedade.Value))

        lbl_estabelecimento.Text = propriedade.cd_estabelecimento.ToString & " - " & propriedade.nm_estabelecimento.ToString
        lbl_produtor.Text = propriedade.cd_pessoa.ToString & " - " & propriedade.nm_pessoa.ToString
        lbl_propriedade.Text = propriedade.id_propriedade.ToString & " - " & propriedade.nm_propriedade.ToString

        If Not (customPage.getFilterValue("unidadeproducao", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("unidadeproducao", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        End If

        If Not (customPage.getFilterValue("unidadeproducao", hf_id_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            hf_id_propriedade.Value = customPage.getFilterValue("unidadeproducao", hf_id_propriedade.ID)
        End If

        If Not (customPage.getFilterValue("unidadeproducao", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("unidadeproducao", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        'Sempre carrega os dados mesmo que nao tenha filtro
        loadData()
        If (hasFilters) Then

            customPage.clearFilters("unidadeproducao")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim unidadeproducao As New UnidadeProducao

            'unidadeproducao.id_unid_producao = Convert.ToInt32(ViewState.Item("id_unid_producao"))
            unidadeproducao.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            unidadeproducao.id_propriedade = Convert.ToInt32(Me.hf_id_propriedade.Value.ToString)

            Dim dsunidadeproducao As DataSet = unidadeproducao.getUnidadeProducaoByFilters

            If (dsunidadeproducao.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsunidadeproducao.Tables(0), ViewState.Item("sortExpression"))
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
        Me.loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "nr_unid_producao"
                If (ViewState.Item("sortExpression")) = "nr_unid_producao asc" Then
                    ViewState.Item("sortExpression") = "nr_unid_producao desc"
                Else
                    ViewState.Item("sortExpression") = "nr_unid_producao asc"
                End If


            Case "nm_unid_producao"
                If (ViewState.Item("sortExpression")) = "nm_unid_producao asc" Then
                    ViewState.Item("sortExpression") = "nm_unid_producao desc"
                Else
                    ViewState.Item("sortExpression") = "nm_unid_producao asc"
                End If

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("unidadeproducao", hf_id_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("unidadeproducao", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("unidadeproducao", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_unidade_producao.aspx?id_unid_producao=" + e.CommandArgument.ToString())

            Case "delete"
                deleteUnidadeProducao(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteUnidadeProducao(ByVal id_unid_producao As Integer)

        Try

            Dim unidadeproducao As New UnidadeProducao()
            unidadeproducao.id_unid_producao = id_unid_producao
            unidadeproducao.id_modificador = Convert.ToInt32(Session("id_login"))
            unidadeproducao.deleteUnidadeProducao()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 5
            usuariolog.ds_nm_processo = "Propriedade - Unidade de Produção"
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
        Response.Redirect("frm_unidade_producao.aspx?id_propriedade=" + Me.hf_id_propriedade.Value.ToString)
    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_propriedade.aspx?id_propriedade=" + Me.hf_id_propriedade.Value.ToString)
    End Sub

End Class
