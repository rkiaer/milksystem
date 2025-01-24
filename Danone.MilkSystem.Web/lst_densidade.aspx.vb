Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_densidade
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If txt_dt_referencia.Text.Equals(String.Empty) Then
            ViewState.Item("dt_referencia") = txt_dt_referencia.Text
        Else
            ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)
        End If
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_densidade.aspx?st_incluirlog=N")

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_densidade.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 130
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

            ViewState.Item("sortExpression") = ""

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("densidade", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("densidade", txt_dt_referencia.ID)
            txt_dt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("MM/yyyy")
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        ViewState.Item("sortExpression") = "dt_referencia desc"

        If Not (customPage.getFilterValue("densidade", cbo_situacao.ID).Equals("0")) And Not (customPage.getFilterValue("densidade", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("densidade", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = 0
        End If

        If Not (customPage.getFilterValue("densidade", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("densidade", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("densidade")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim dsdensidade As DataSet

            Dim densidade As New Densidade
            densidade.dt_referencia = ViewState.Item("dt_referencia").ToString
            densidade.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

            dsdensidade = densidade.getDensidadebyFilters()
            If (dsdensidade.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsdensidade.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    
    Private Sub saveFilters()

        Try


            customPage.setFilter("densidade", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("densidade", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("densidade", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub




    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click

        If txt_dt_referencia.Text.Equals(String.Empty) Then
            ViewState.Item("dt_referencia") = txt_dt_referencia.Text
        Else
            ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)

        End If
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        saveFilters()
        Response.Redirect("frm_densidade.aspx")
    End Sub

    Private Sub deleteDensidade(ByVal id_densidade As Integer)

        Try

            Dim densidade As New Densidade
            densidade.id_densidade = id_densidade
            densidade.id_modificador = Convert.ToInt32(Session("id_login"))
            densidade.deleteDensidade()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 130
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 
            messageControl.Alert("Registro desativado com sucesso. Sr. Usuário, o valor de densidade deste registro não será mais utilizado pela exportação do Batch Declaration.")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_densidade.aspx?id_densidade=" + e.CommandArgument.ToString())

            Case "delete"
                deleteDensidade(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            e.Row.Cells(0).Text = DateTime.Parse(e.Row.Cells(0).Text).ToString("MM/yyyy") 'dt_referencia
            If e.Row.Cells(2).Text.Trim.Equals("1") Then 'situacao
                e.Row.Cells(2).Text = "Ativo"

            Else
                e.Row.Cells(2).Text = "Inativo"
            End If

        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting
        Select Case e.SortExpression.ToLower()



            Case "dt_referencia"
                If (ViewState.Item("sortExpression")) = "dt_referencia asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia asc"
                End If

            Case "nr_valor_densidade"
                If (ViewState.Item("sortExpression")) = "nr_valor_densidade asc" Then
                    ViewState.Item("sortExpression") = "nr_valor_densidade desc"
                Else
                    ViewState.Item("sortExpression") = "nr_valor_densidade asc"
                End If
            Case "id_situacao"
                If (ViewState.Item("sortExpression")) = "id_situacao asc" Then
                    ViewState.Item("sortExpression") = "id_situacao desc"
                Else
                    ViewState.Item("sortExpression") = "id_situacao asc"
                End If


        End Select

        loadData()

    End Sub

End Class
