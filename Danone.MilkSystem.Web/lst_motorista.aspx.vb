Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_motorista
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("cd_cnh") = txt_cd_cnh.Text.Trim().ToString
        ViewState.Item("nm_motorista") = txt_nm_motorista.Text.Trim().ToString
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue.ToString
        ViewState.Item("st_categoria_cnh") = cbo_categoria.SelectedValue.ToString 'fase 3

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_motorista.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_motorista.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 11
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


            ViewState.Item("sortExpression") = "nm_motorista asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("motorista", txt_cd_cnh.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_cnh") = customPage.getFilterValue("motorista", txt_cd_cnh.ID)
            txt_cd_cnh.Text = ViewState.Item("cd_cnh").ToString()
        Else
            ViewState.Item("cd_cnh") = String.Empty
        End If

        If Not (customPage.getFilterValue("motorista", txt_nm_motorista.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_motorista") = customPage.getFilterValue("motorista", txt_nm_motorista.ID)
            txt_nm_motorista.Text = ViewState.Item("nm_motorista").ToString()
        Else
            ViewState.Item("nm_motorista") = String.Empty
        End If



        If Not (customPage.getFilterValue("motorista", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("motorista", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If
        'fase 3
        If Not (customPage.getFilterValue("motorista", cbo_categoria.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("st_categoria_cnh") = customPage.getFilterValue("motorista", cbo_categoria.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("st_categoria_cnh") = String.Empty
        End If


        If Not (customPage.getFilterValue("motorista", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("motorista", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("motorista")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim motorista As New Motorista

            motorista.cd_cnh = ViewState.Item("cd_cnh").ToString()
            motorista.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            motorista.nm_motorista = ViewState.Item("nm_motorista").ToString
            motorista.st_categoria_cnh = ViewState.Item("st_categoria_cnh").ToString 'fran fase 3

            Dim dsmotorista As DataSet = motorista.getMotoristasByFilters()

            If (dsmotorista.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsmotorista.Tables(0), ViewState.Item("sortExpression"))
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


    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "cd_cnh"
                If (ViewState.Item("sortExpression")) = "cd_cnh asc" Then
                    ViewState.Item("sortExpression") = "cd_cnh desc"
                Else
                    ViewState.Item("sortExpression") = "cd_cnh asc"
                End If


            Case "nm_motorista"
                If (ViewState.Item("sortExpression")) = "nm_motorista asc" Then
                    ViewState.Item("sortExpression") = "nm_motorista desc"
                Else
                    ViewState.Item("sortExpression") = "nm_motorista asc"
                End If


            Case "dt_validade_cnh"
                If (ViewState.Item("sortExpression")) = "dt_validade_cnh asc" Then
                    ViewState.Item("sortExpression") = "dt_validade_cnh desc"
                Else
                    ViewState.Item("sortExpression") = "dt_validade_cnh asc"
                End If

            Case "st_categoria_cnh"
                If (ViewState.Item("sortExpression")) = "st_categoria_cnh asc" Then
                    ViewState.Item("sortExpression") = "st_categoria_cnh desc"
                Else
                    ViewState.Item("sortExpression") = "st_categoria_cnh asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("motorista", txt_cd_cnh.ID, ViewState.Item("cd_cnh").ToString)
            customPage.setFilter("motorista", txt_nm_motorista.ID, ViewState.Item("nm_motorista").ToString)
            customPage.setFilter("motorista", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("motorista", cbo_categoria.ID, ViewState.Item("st_categoria_cnh").ToString)
            customPage.setFilter("motorista", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_motorista.aspx?id_motorista=" + e.CommandArgument.ToString())

            Case "delete"
                deleteMotorista(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteMotorista(ByVal id_motorista As Integer)

        Try

            Dim motorista As New Motorista()
            motorista.id_motorista = id_motorista
            motorista.id_modificador = Convert.ToInt32(Session("id_login"))
            motorista.deleteMotorista()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 11
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_motorista.aspx")

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        ViewState.Item("cd_cnh") = txt_cd_cnh.Text.Trim().ToString
        ViewState.Item("nm_motorista") = txt_nm_motorista.Text.Trim().ToString
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue.ToString
        ViewState.Item("st_categoria_cnh") = cbo_categoria.SelectedValue.ToString 'fase 3

        loadData()

        'se o grid tiver mais que 65536  linhas não podemos exportar
        If gridResults.Visible = True Then
            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 8 'exporta~ção
                usuariolog.id_menu_item = 11
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Response.Redirect("frm_motorista_excel.aspx?cd_cnh=" + ViewState.Item("cd_cnh").ToString + "&st_categoria_cnh=" + ViewState.Item("st_categoria_cnh").ToString + "&nm_motorista=" + ViewState.Item("nm_motorista").ToString + "&id_situacao=" + ViewState.Item("id_situacao").ToString)
            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
            End If
        End If

    End Sub
End Class
