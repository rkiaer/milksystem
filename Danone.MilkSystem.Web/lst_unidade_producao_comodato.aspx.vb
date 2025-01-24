Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_unidade_producao_comodato
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_unidade_producao_comodato.aspx?id_unid_producao=" + ViewState.Item("id_unid_producao").ToString + "&st_incluirlog=N")

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
                usuariolog.ds_nm_processo = "Propriedade - Unidade de Produção - Comodato"
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

            ViewState.Item("sortExpression") = "id_comodato desc"

            If Not (Request("id_unid_producao") Is Nothing) Then
                ViewState.Item("id_unid_producao") = Request("id_unid_producao")
                loadFilters()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        Dim unidproducao As New UnidadeProducao(Convert.ToInt32(ViewState.Item("id_unid_producao").ToString))

        lbl_estabelecimento.Text = unidproducao.cd_estabelecimento & " - " & unidproducao.nm_estabelecimento
        lbl_produtor.Text = unidproducao.cd_pessoa & " - " & unidproducao.nm_pessoa
        lbl_propriedade.Text = unidproducao.id_propriedade.ToString & " - " & unidproducao.nm_propriedade
        lbl_unidade_producao.Text = unidproducao.nr_unid_producao.ToString & " - " & unidproducao.nm_unid_producao.ToString
        If Not (customPage.getFilterValue("propriedadecomodato", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("propriedadecomodato", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = "1"
        End If


        If Not (customPage.getFilterValue("propriedadecomodato", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("propriedadecomodato", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        loadData()
        If (hasFilters) Or Not Page.IsPostBack Then
            customPage.clearFilters("propriedadecomodato")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim propriedadecomodato As New UnidadeProducaoComodato

            propriedadecomodato.id_unid_producao = Convert.ToInt32(ViewState.Item("id_unid_producao").ToString())
            propriedadecomodato.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

            Dim dspropriedadecomodato As DataSet = propriedadecomodato.getUnidProducaoComodatoByFilters

            If (dspropriedadecomodato.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dspropriedadecomodato.Tables(0), ViewState.Item("sortExpression"))
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


            Case "cd_comodato"
                If (ViewState.Item("sortExpression")) = "cd_comodato asc" Then
                    ViewState.Item("sortExpression") = "cd_comodato desc"
                Else
                    ViewState.Item("sortExpression") = "cd_comodato asc"
                End If

            Case "nm_comodato"
                If (ViewState.Item("sortExpression")) = "nm_comodato asc" Then
                    ViewState.Item("sortExpression") = "nm_comodato desc"
                Else
                    ViewState.Item("sortExpression") = "nm_comodato asc"
                End If

            Case "nm_proprietario"
                If (ViewState.Item("sortExpression")) = "nm_proprietario asc" Then
                    ViewState.Item("sortExpression") = "nm_proprietario desc"
                Else
                    ViewState.Item("sortExpression") = "nm_proprietario asc"
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

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try


            customPage.setFilter("propriedadecomodato", "id_unid_producao", ViewState.Item("id_unid_producao"))
            customPage.setFilter("propriedadecomodato", cbo_situacao.ID, ViewState.Item("id_situacao"))
            customPage.setFilter("propriedadecomodato", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_unidade_producao_comodato.aspx?id_unidproducaocomodato=" + e.CommandArgument.ToString())

            Case "delete"
                deleteunidadeproducaocomodato(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteunidadeproducaocomodato(ByVal id_unidproducaocomodato As Integer)

        Try

            Dim unidproducaocomodato As New UnidadeProducaoComodato()
            unidproducaocomodato.id_unidproducaocomodato = id_unidproducaocomodato
            unidproducaocomodato.id_modificador = Convert.ToInt32(Session("id_login"))
            unidproducaocomodato.deleteUnidProducaoComodato()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 5
            usuariolog.ds_nm_processo = "Propriedade - Unidade de Produção - Comodato"
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
        Response.Redirect("frm_unidade_producao_comodato.aspx?id_unid_producao=" + ViewState.Item("id_unid_producao").ToString())
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_unidade_producao.aspx?id_unid_producao=" + ViewState.Item("id_unid_producao").ToString())

    End Sub
End Class
