Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_propriedade_treinamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_propriedade_treinamento.aspx?id_propriedade=" + ViewState.Item("id_propriedade").ToString + "&st_incluirlog=N")

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
                usuariolog.ds_nm_processo = "Propriedade - Treinamento"
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

            ViewState.Item("sortExpression") = "dt_inicio desc"

            If Not (Request("id_propriedade") Is Nothing) Then
                ViewState.Item("id_propriedade") = Request("id_propriedade")
                loadFilters()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        Dim propriedade As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade").ToString))

        lbl_estabelecimento.Text = propriedade.cd_estabelecimento & " - " & propriedade.nm_estabelecimento
        lbl_produtor.Text = propriedade.cd_pessoa & " - " & propriedade.nm_pessoa
        lbl_propriedade.Text = propriedade.id_propriedade.ToString & " - " & propriedade.nm_propriedade

        If Not (customPage.getFilterValue("propriedadetreinamento", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("propriedadetreinamento", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = "1" 'assume ativo
        End If


        If Not (customPage.getFilterValue("propriedadetreinamento", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("propriedadetreinamento", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        loadData()
        If (hasFilters) Or Not Page.IsPostBack Then
            customPage.clearFilters("propriedadetreinamento")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim propriedadetreinamento As New PropriedadeTreinamento

            propriedadetreinamento.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString())
            propriedadetreinamento.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

            Dim dspropriedadetreinamento As DataSet = propriedadetreinamento.getPropriedadeTreinamentoByFilters()

            If (dspropriedadetreinamento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dspropriedadetreinamento.Tables(0), ViewState.Item("sortExpression"))
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


            Case "id_treinamento"
                If (ViewState.Item("sortExpression")) = "id_treinamento asc" Then
                    ViewState.Item("sortExpression") = "id_treinamento desc"
                Else
                    ViewState.Item("sortExpression") = "id_treinamento asc"
                End If

            Case "nm_treinamento"
                If (ViewState.Item("sortExpression")) = "nm_treinamento asc" Then
                    ViewState.Item("sortExpression") = "nm_treinamento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_treinamento asc"
                End If

            Case "nm_tecnico"
                If (ViewState.Item("sortExpression")) = "nm_tecnico asc" Then
                    ViewState.Item("sortExpression") = "nm_tecnico desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tecnico asc"
                End If

            Case "dt_inicio"
                If (ViewState.Item("sortExpression")) = "dt_inicio asc" Then
                    ViewState.Item("sortExpression") = "dt_inicio desc"
                Else
                    ViewState.Item("sortExpression") = "dt_inicio asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try


            customPage.setFilter("propriedadetreinamento", "id_propriedade", ViewState.Item("id_propriedade"))
            customPage.setFilter("propriedadetreinamento", cbo_situacao.ID, ViewState.Item("id_situacao"))
            customPage.setFilter("propriedadetreinamento", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_propriedade_treinamento.aspx?id_propriedadetreinamento=" + e.CommandArgument.ToString())

            Case "delete"
                deletePropriedadeTreinamento(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deletePropriedadeTreinamento(ByVal id_propriedadetreinamento As Integer)

        Try

            Dim propriedadetreinamento As New PropriedadeTreinamento()
            propriedadetreinamento.id_propriedadetreinamento = id_propriedadetreinamento
            propriedadetreinamento.id_modificador = Convert.ToInt32(Session("id_login"))
            propriedadetreinamento.deletePropriedadeTreinamento()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 5
            usuariolog.ds_nm_processo = "Propriedade - Treinamento"
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
        Response.Redirect("frm_propriedade_treinamento.aspx?id_propriedade=" + ViewState.Item("id_propriedade").ToString())
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_propriedade.aspx?id_propriedade=" + ViewState.Item("id_propriedade").ToString())

    End Sub
End Class
