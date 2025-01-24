Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_calculo_historico

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia") = Me.txt_dt_referencia.Text.Trim
        ViewState.Item("st_tipo_pagamento") = Me.cbo_tipo_pagamento.SelectedValue
        ViewState.Item("id_calculo_execucao") = Me.txt_id_calculo_execucao.Text.Trim
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim     ' 17/02/2009 Rls16

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_calculo_historico.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_calculo_historico.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 45
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


            'cbo_tipo_pagamento.Items.Add(New ListItem("Consolidado", "C")) ' Retirado adri 06/03/2012 - projeto Themis - Processo de Cálculo unificado por IE 
            cbo_tipo_pagamento.Items.Add(New ListItem("Quinzenal", "Q"))
            cbo_tipo_pagamento.Items.Add(New ListItem("Mensal", "M"))

            ViewState.Item("sortExpression") = "id_calculo_execucao asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("calculo_historico", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("calculo_historico", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("calculo_historico", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("calculo_historico", txt_dt_referencia.ID)
            txt_dt_referencia.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        If Not (customPage.getFilterValue("calculo_historico", txt_id_calculo_execucao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_calculo_execucao") = customPage.getFilterValue("calculo_historico", txt_id_calculo_execucao.ID)
            txt_id_calculo_execucao.Text = ViewState.Item("id_calculo_execucao").ToString()
        Else
            ViewState.Item("id_calculo_execucao") = String.Empty
        End If

        If Not (customPage.getFilterValue("calculo_historico", cbo_tipo_pagamento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("st_tipo_pagamento") = customPage.getFilterValue("calculo_historico", cbo_tipo_pagamento.ID)
            cbo_tipo_pagamento.Text = ViewState.Item("st_tipo_pagamento").ToString()
        Else
            ViewState.Item("st_tipo_pagamento") = String.Empty
        End If

        ' 17/02/2009 Rls16 - i
        If Not (customPage.getFilterValue("calculo_historico", txt_cd_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("calculo_historico", txt_cd_propriedade.ID)
            txt_cd_propriedade.Text = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If
        ' 17/02/2009 Rls16 - f

        If Not (customPage.getFilterValue("calculo_historico", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("calculo_historico", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("calculo_historico")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim calculoexecucao As New CalculoExecucao

            calculoexecucao.id_estabelecimento = ViewState.Item("id_estabelecimento")
            calculoexecucao.dt_referencia = "01/" & ViewState.Item("dt_referencia").ToString()
            calculoexecucao.st_tipo_pagamento = ViewState.Item("st_tipo_pagamento").ToString()
            If ViewState.Item("id_calculo_execucao") <> "" Then
                calculoexecucao.id_calculo_execucao = ViewState.Item("id_calculo_execucao")
            End If
            ' 17/02/2009 Rls16 - i
            If ViewState.Item("id_propriedade") <> "" Then
                calculoexecucao.id_propriedade = ViewState.Item("id_propriedade")
            End If
            ' 17/02/2009 Rls16 - f

            Dim dsCalculoExecucao As DataSet = calculoexecucao.getCalculoExecucaoHistoricoByFilters()

            If (dsCalculoExecucao.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsCalculoExecucao.Tables(0), ViewState.Item("sortExpression"))
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
        loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "id_calculo_execucao"
                If (ViewState.Item("sortExpression")) = "id_calculo_execucao asc" Then
                    ViewState.Item("sortExpression") = "id_calculo_execucao desc"
                Else
                    ViewState.Item("sortExpression") = "id_calculo_execucao asc"
                End If

            Case "dt_inicio_execucao"
                If (ViewState.Item("sortExpression")) = "dt_inicio_execucao asc" Then
                    ViewState.Item("sortExpression") = "dt_inicio_execucao desc"
                Else
                    ViewState.Item("sortExpression") = "dt_inicio_execucao asc"
                End If

            Case "dt_termino_execucao"
                If (ViewState.Item("sortExpression")) = "dt_termino_execucao asc" Then
                    ViewState.Item("sortExpression") = "dt_termino_execucao desc"
                Else
                    ViewState.Item("sortExpression") = "dt_termino_execucao asc"
                End If


        End Select

        loadData()

    End Sub
    Private Sub saveFilters()

        Try

            customPage.setFilter("calculo_historico", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("calculo_historico", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("calculo_historico", cbo_tipo_pagamento.ID, ViewState.Item("st_tipo_pagamento").ToString)
            customPage.setFilter("calculo_historico", txt_id_calculo_execucao.ID, ViewState.Item("id_calculo_execucao").ToString)
            customPage.setFilter("calculo_historico", txt_cd_propriedade.ID, ViewState.Item("id_propriedade").ToString)  ' Rls16
            customPage.setFilter("calculo_historico", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 45
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                ' 17/02/2009 Rls16 - i
                'Response.Redirect("lst_calculo_acompanhamento.aspx?id_calculo_execucao=" + e.CommandArgument.ToString() + "&historico=S")
                Response.Redirect("lst_calculo_acompanhamento.aspx?id_calculo_execucao=" + e.CommandArgument.ToString() + "&historico=S" + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString())
                ' 17/02/2009 Rls16 - f

            Case "delete"
                'deleteLancamento(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteCalculoExecucao(ByVal id_lancamento As Integer)

        'Try
        '    Dim lancamento As New Lancamento()
        '    lancamento.id_lancamento = id_lancamento
        '    lancamento.id_modificador = Convert.ToInt32(Session("id_login"))
        '    lancamento.deleteLancamento()
        '    messageControl.Alert("Registro desativado com sucesso!")
        '    loadData()

        'Catch ex As Exception
        '    messageControl.Alert(ex.Message)
        'End Try

    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            If (e.Row.Cells(3).Text.Trim().Equals("P")) Then
                e.Row.Cells(3).Text = "Provisório"
            Else
                If (e.Row.Cells(4).Text.Trim().Equals("D")) Then
                    e.Row.Cells(4).Text = "Definitivo"
                End If
            End If
        End If

    End Sub
End Class
