Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_linha
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_linha") = txt_cd_linha.Text.Trim()
        ViewState.Item("nm_linha") = txt_nm_linha.Text.Trim()
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_linha.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_linha.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 7
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If
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

            ViewState.Item("sortExpression") = "nm_linha asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("linha", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("linha", cbo_estabelecimento.ID)
            cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("linha", txt_cd_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_linha") = customPage.getFilterValue("linha", txt_cd_linha.ID)
            txt_cd_linha.Text = ViewState.Item("id_linha").ToString()
            If ViewState.Item("id_linha").ToString() = String.Empty Then
                txt_cd_linha.Text = ""
            End If
        Else
            ViewState.Item("id_linha") = String.Empty
            txt_cd_linha.Text = ""
        End If

        If Not (customPage.getFilterValue("linha", txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_linha") = customPage.getFilterValue("linha", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_linha").ToString()
        Else
            ViewState.Item("nm_linha") = String.Empty
        End If



        If Not (customPage.getFilterValue("linha", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("linha", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("linha", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("linha", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("linha")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim linha As New Linha

            If Not (ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty)) Then
                linha.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString()
            End If
            If Not (ViewState.Item("id_linha").ToString.Equals(String.Empty)) Then
                linha.id_linha = Convert.ToInt32(ViewState.Item("id_linha"))
            End If
            If Not (ViewState.Item("id_situacao").ToString.Equals(String.Empty)) Then
                linha.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            End If
            linha.nm_linha = ViewState.Item("nm_linha").ToString()

            Dim dsLinha As DataSet = linha.getLinhaByFilters()

            If (dsLinha.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsLinha.Tables(0), ViewState.Item("sortExpression"))
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

            Case "id_linha"
                If (ViewState.Item("sortExpression")) = "id_linha asc" Then
                    ViewState.Item("sortExpression") = "id_linha desc"
                Else
                    ViewState.Item("sortExpression") = "id_linha asc"
                End If


            Case "nm_linha"
                If (ViewState.Item("sortExpression")) = "nm_linha asc" Then
                    ViewState.Item("sortExpression") = "nm_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nm_linha asc"
                End If

            Case "ds_placa"
                If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
                End If

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("linha", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("linha", txt_cd_linha.ID, ViewState.Item("id_linha").ToString)
            customPage.setFilter("linha", txt_nm_linha.ID, ViewState.Item("nm_linha").ToString)
            customPage.setFilter("linha", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("linha", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_linha.aspx?id_linha=" + e.CommandArgument.ToString())

            Case "delete"
                deleteLinha(Convert.ToInt32(e.CommandArgument.ToString()))

            Case "detalhe"
                saveFilters()
                Response.Redirect("lst_linha_detalhe.aspx?id_linha=" + e.CommandArgument.ToString())

            Case "atividade"
                saveFilters()
                Response.Redirect("lst_linha_atividade.aspx?id_linha=" + e.CommandArgument.ToString())


        End Select

    End Sub

    Private Sub deleteLinha(ByVal id_linha As Integer)

        Try

            Dim linha As New Linha()
            linha.id_linha = id_linha
            linha.id_modificador = Convert.ToInt32(Session("id_login"))
            linha.deleteLinha()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 7
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
        Response.Redirect("frm_linha.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            If e.Row.Cells(3).Text.Trim = "1" Then 'se transbordo SIM
                e.Row.Cells(3).Text = "Sim"
            End If
            If e.Row.Cells(3).Text.Trim = "2" Then 'se transbordo NAO
                e.Row.Cells(3).Text = "Não"
            End If
            If e.Row.Cells(4).Text.Trim = "1" Then 'se transit point SIM
                e.Row.Cells(4).Text = "Sim"
            End If
            If e.Row.Cells(4).Text.Trim = "2" Then 'se transit point NAO
                e.Row.Cells(4).Text = "Não"
            End If         
            If e.Row.Cells(5).Text.Trim = "1" Then 'se transvase
            End If
            If e.Row.Cells(5).Text.Trim = "2" Then 'se transvase
                e.Row.Cells(5).Text = "Não"
            End If

        End If


    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
End Class
