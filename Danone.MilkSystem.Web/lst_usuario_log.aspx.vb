Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_usuario_log
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then
            ViewState.Item("dt_inicio") = DateTime.Parse(txt_dt_inicio.Text).ToString("dd/MM/yyyy")
            'assume um dia a data fim para nao ter problema com os segundos da data de termino informada
            ViewState.Item("dt_fim") = DateAdd(DateInterval.Day, 1, Convert.ToDateTime(txt_dt_fim.Text)).ToString("dd/MM/yyyy")
            ViewState.Item("id_tipo_log") = cbo_tipo_log.SelectedValue
            ViewState.Item("id_menu") = cbo_menu.SelectedValue
            ViewState.Item("id_menu_item") = cbo_menu_item.SelectedValue

            ViewState.Item("ds_login") = Me.txt_ds_login.Text.Trim()
            ViewState.Item("opt_log") = opt_log.SelectedValue
            loadData()
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_usuario_log.aspx?st_incluirlog=N")

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_usuario_log.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 204
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim tipolog As New TipoLog

            cbo_tipo_log.DataSource = tipolog.getTipoLogByFilters
            cbo_tipo_log.DataTextField = "nm_tipo_log"
            cbo_tipo_log.DataValueField = "id_tipo_log"
            cbo_tipo_log.DataBind()
            cbo_tipo_log.Items.Insert(0, New ListItem("[Selecione]", 0))

            Dim menu As New Menu
            menu.id_situacao = 1
            Dim dsmenu As DataSet = menu.getMenuByFilters()
            cbo_menu.DataSource = Helper.getDataView(dsmenu.Tables(0), "nm_menu")
            cbo_menu.DataTextField = "nm_menu"
            cbo_menu.DataValueField = "id_menu"
            cbo_menu.DataBind()
            cbo_menu.Items.Insert(0, New ListItem("[Selecione]", 0))

            cbo_menu_item.Items.Insert(0, New ListItem("[Selecione]", 0))
            cbo_menu_item.Enabled = False

            ViewState.Item("sortExpression") = ""



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

 
    Private Sub loadData()

        Try
            Dim usuariolog As New UsuarioLog

            usuariolog.id_tipo_log = Convert.ToInt32(ViewState.Item("id_tipo_log").ToString)
            usuariolog.id_menu = Convert.ToInt32(ViewState.Item("id_menu").ToString())
            usuariolog.id_menu_item = Convert.ToInt32(ViewState.Item("id_menu_item").ToString())
            usuariolog.ds_login = ViewState.Item("ds_login").ToString
            usuariolog.dt_inicio = ViewState.Item("dt_inicio").ToString
            usuariolog.dt_fim = ViewState.Item("dt_fim").ToString

            If ViewState.Item("opt_log").ToString.Equals("A") Then
                gridCriticos.Visible = False
                Dim dsusuariolog As DataSet = usuariolog.getUsuarioLogByFilters()

                If (dsusuariolog.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsusuariolog.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()

                Else
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If
            Else
                gridResults.Visible = False

                Dim dscritico As DataSet = usuariolog.getUsuarioLogCriticos

                If (dscritico.Tables(0).Rows.Count > 0) Then
                    gridCriticos.Visible = True
                    gridCriticos.DataSource = Helper.getDataView(dscritico.Tables(0), ViewState.Item("sortExpression"))
                    gridCriticos.DataBind()

                Else
                    gridCriticos.Visible = False
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


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "ds_login"
                If (ViewState.Item("sortExpression")) = "ds_login asc" Then
                    ViewState.Item("sortExpression") = "ds_login desc"
                Else
                    ViewState.Item("sortExpression") = "ds_login asc"
                End If

            Case "dt_criacao"
                If (ViewState.Item("sortExpression")) = "dt_criacao asc" Then
                    ViewState.Item("sortExpression") = "dt_criacao desc"
                Else
                    ViewState.Item("sortExpression") = "dt_criacao asc"
                End If

            Case "nm_tipo_log"
                If (ViewState.Item("sortExpression")) = "nm_tipo_log asc" Then
                    ViewState.Item("sortExpression") = "nm_tipo_log desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tipo_log asc"
                End If
            Case "nm_menu"
                If (ViewState.Item("sortExpression")) = "nm_menu asc" Then
                    ViewState.Item("sortExpression") = "nm_menu desc"
                Else
                    ViewState.Item("sortExpression") = "nm_menu asc"
                End If

            Case "nm_menu_item"
                If (ViewState.Item("sortExpression")) = "nm_menu_item asc" Then
                    ViewState.Item("sortExpression") = "nm_menu_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_menu_item asc"
                End If

            Case "ds_nm_processo"
                If (ViewState.Item("sortExpression")) = "ds_nm_processo asc" Then
                    ViewState.Item("sortExpression") = "ds_nm_processo desc"
                Else
                    ViewState.Item("sortExpression") = "ds_nm_processo asc"
                End If
            Case "ds_id_session"
                If (ViewState.Item("sortExpression")) = "ds_id_session asc" Then
                    ViewState.Item("sortExpression") = "ds_id_session desc"
                Else
                    ViewState.Item("sortExpression") = "ds_id_session asc"
                End If


        End Select

        loadData()

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then


        End If
    End Sub



    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Page.IsValid Then

            ViewState.Item("dt_inicio") = DateTime.Parse(txt_dt_inicio.Text).ToString("dd/MM/yyyy")
            'assume um dia a data fim para nao ter problema com os segundos da data de termino informada
            ViewState.Item("dt_fim") = DateAdd(DateInterval.Day, 1, Convert.ToDateTime(txt_dt_fim.Text)).ToString("dd/MM/yyyy")
            ViewState.Item("id_tipo_log") = cbo_tipo_log.SelectedValue
            ViewState.Item("id_menu") = cbo_menu.SelectedValue
            ViewState.Item("id_menu_item") = cbo_menu_item.SelectedValue
            ViewState.Item("ds_login") = Me.txt_ds_login.Text.Trim()
            ViewState.Item("opt_log") = opt_log.SelectedValue

            loadData()
            If ViewState.Item("opt_log").ToString.Equals("A") Then
                If gridResults.Rows.Count > 0 Then
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 8 'exporta~ção
                    usuariolog.id_menu_item = 204
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    Response.Redirect("frm_usuario_log_excel.aspx?dt_inicio=" + ViewState.Item("dt_inicio").ToString() + "&dt_fim=" + ViewState.Item("dt_fim").ToString() + "&id_tipo_log=" + ViewState.Item("id_tipo_log").ToString() + "&id_menu=" + ViewState.Item("id_menu").ToString() + "&id_menu_item=" + ViewState.Item("id_menu_item").ToString() + "&ds_login=" + ViewState.Item("ds_login").ToString())

                End If
            Else
                If gridCriticos.Rows.Count > 0 Then
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 8 'exporta~ção
                    usuariolog.id_menu_item = 204
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    Response.Redirect("frm_usuario_log_critico_excel.aspx?dt_inicio=" + ViewState.Item("dt_inicio").ToString() + "&dt_fim=" + ViewState.Item("dt_fim").ToString() + "&id_tipo_log=" + ViewState.Item("id_tipo_log").ToString() + "&id_menu=" + ViewState.Item("id_menu").ToString() + "&id_menu_item=" + ViewState.Item("id_menu_item").ToString() + "&ds_login=" + ViewState.Item("ds_login").ToString())

                End If

            End If
        End If
    End Sub

    Protected Sub cbo_menu_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_menu.SelectedIndexChanged
        cbo_menu_item.Items.Clear()

        If cbo_menu.SelectedValue <> "0" Then
            cbo_menu_item.Enabled = True

            Dim menuitem As New MenuItem
            menuitem.id_menu = cbo_menu.SelectedValue
            menuitem.id_situacao = 1
            Dim dsmenuitem As DataSet = menuitem.getMenuItem
            cbo_menu_item.DataSource = Helper.getDataView(dsmenuitem.Tables(0), "nm_menu_item")
            cbo_menu_item.DataTextField = "nm_menu_item"
            cbo_menu_item.DataValueField = "id_menu_item"
            cbo_menu_item.DataBind()
            cbo_menu_item.Items.Insert(0, New ListItem("[Selecione]", 0))
            cbo_menu_item.SelectedValue = "0"

        Else
            cbo_menu_item.Items.Insert(0, New ListItem("[Selecione]", 0))
            cbo_menu_item.SelectedValue = "0"
            cbo_menu_item.Enabled = False
        End If
    End Sub



    Protected Sub gridCriticos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridCriticos.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridCriticos_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridCriticos.Sorting
        Select Case e.SortExpression.ToLower()


            Case "ds_login"
                If (ViewState.Item("sortExpression")) = "ds_login asc" Then
                    ViewState.Item("sortExpression") = "ds_login desc"
                Else
                    ViewState.Item("sortExpression") = "ds_login asc"
                End If

            Case "dt_criacao"
                If (ViewState.Item("sortExpression")) = "dt_criacao asc" Then
                    ViewState.Item("sortExpression") = "dt_criacao desc"
                Else
                    ViewState.Item("sortExpression") = "dt_criacao asc"
                End If

            Case "nm_menu"
                If (ViewState.Item("sortExpression")) = "nm_menu asc" Then
                    ViewState.Item("sortExpression") = "nm_menu desc"
                Else
                    ViewState.Item("sortExpression") = "nm_menu asc"
                End If

            Case "nm_menu_item"
                If (ViewState.Item("sortExpression")) = "nm_menu_item asc" Then
                    ViewState.Item("sortExpression") = "nm_menu_item desc"
                Else
                    ViewState.Item("sortExpression") = "nm_menu_item asc"
                End If

            Case "nm_erro"
                If (ViewState.Item("sortExpression")) = "nm_erro asc" Then
                    ViewState.Item("sortExpression") = "nm_erro desc"
                Else
                    ViewState.Item("sortExpression") = "nm_erro asc"
                End If


        End Select

        loadData()


    End Sub
End Class
