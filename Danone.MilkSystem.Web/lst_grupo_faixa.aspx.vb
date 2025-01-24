Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_grupo_faixa

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("nr_grupo_faixas") = txt_nr_grupo_faixas.Text.Trim()
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_grupo_faixa.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_grupo_faixa.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 29
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
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = "nm_grupo_faixas asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("faixavol", txt_nr_grupo_faixas.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_grupo_faixas") = customPage.getFilterValue("faixavol", txt_nr_grupo_faixas.ID)
            txt_nr_grupo_faixas.Text = ViewState.Item("nr_grupo_faixas").ToString()
        Else
            ViewState.Item("nr_grupo_faixas") = String.Empty
        End If

        If Not (customPage.getFilterValue("faixavol", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("faixavol", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("faixavol", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("faixavol", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("faixavol")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim faixa As New FaixaVolume

            If Not ViewState.Item("nr_grupo_faixas").ToString.Equals(String.Empty) Then
                faixa.nr_grupo_faixas = Convert.ToInt32(ViewState.Item("nr_grupo_faixas").ToString())
            End If
            If Not ViewState.Item("id_situacao").ToString.Equals(String.Empty) Then
                faixa.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            End If

            Dim dsfaixa As DataSet = faixa.getFaixaVolumeGrupos()

            If (dsfaixa.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsfaixa.Tables(0), ViewState.Item("sortExpression"))
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


            Case "nr_grupo_faixas"
                If (ViewState.Item("sortExpression")) = "nr_grupo_faixas asc" Then
                    ViewState.Item("sortExpression") = "nr_grupo_faixas desc"
                Else
                    ViewState.Item("sortExpression") = "nr_grupo_faixas asc"
                End If


            Case "nm_grupo_faixas"
                If (ViewState.Item("sortExpression")) = "nm_grupo_faixas asc" Then
                    ViewState.Item("sortExpression") = "nm_grupo_faixas desc"
                Else
                    ViewState.Item("sortExpression") = "nm_grupo_faixas asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("faixavol", txt_nr_grupo_faixas.ID, ViewState.Item("nr_grupo_faixas").ToString)
            customPage.setFilter("faixavol", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            Dim Teste As Object = gridResults.PageIndex.ToString()
            customPage.setFilter("faixavol", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_grupo_faixa.aspx?nr_grupo_faixas=" + e.CommandArgument.ToString())

            Case "delete"
                deleteGrupo(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteGrupo(ByVal id_grupo As Integer)

        Try

            Dim faixa As New FaixaVolume()
            faixa.nr_grupo_faixas = id_grupo
            faixa.id_modificador = Convert.ToInt32(Session("id_login"))
            faixa.deleteGrupoFaixaVolume()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 29
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
        Response.Redirect("frm_grupo_faixa.aspx")
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
