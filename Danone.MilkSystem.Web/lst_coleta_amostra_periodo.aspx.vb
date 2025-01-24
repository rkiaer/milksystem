Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_coleta_amostra_periodo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia") = String.Concat("01/", DateTime.Parse(txt_dt_referencia.Text).ToString("MM/yyyy"))
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_coleta_amostra_periodo.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_coleta_amostra_periodo.aspx")

        If Not Page.IsPostBack Then
            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim statusPoupanca As New SituacaoPoupanca
            Dim estabelecimento As New Estabelecimento

            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim coletaamostra As New ColetaAmostra
            Dim dsultimacoleta As DataSet = coletaamostra.getColetaUltimaRotaCarregada
            If dsultimacoleta.Tables(0).Rows.Count > 0 Then
                With dsultimacoleta.Tables(0).Rows(0)

                    lbl_ultima_coleta.Text = String.Concat("Rota: ", .Item("nm_linha").ToString, " - ", "Data: ", DateTime.Parse(.Item("dt_criacao")).ToString("dd/MM/yyyy HH:mm"))
                    ViewState.Item("dataultimacoleta") = DateTime.Parse(.Item("dt_criacao")).ToString("dd/MM/yyyy")

                End With
            Else
                lbl_ultima_coleta.Text = String.Empty
                ViewState.Item("dataultimacoleta") = String.Empty
            End If


            ViewState.Item("sortExpression") = "dt_referencia desc"

            loadFilters()

            'fran 11/2021 - simula seleção de usuario
            If cbo_estabelecimento.SelectedValue.Equals("0") Then
                'simula seleção do usuario em poços
                cbo_estabelecimento.SelectedValue = 1 'força poços de caldas
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                If txt_dt_referencia.Text.Equals(String.Empty) Then
                    txt_dt_referencia.Text = DateTime.Parse(Now).ToString("MM/yyyy")
                    ViewState.Item("dt_referencia") = "01/" + Me.txt_dt_referencia.Text.Trim
                End If
                loadData()
            End If
            'fran 11/2021 - simula seleção de usuario




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("colamoperiodo", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            If Not (customPage.getFilterValue("colamoperiodo", cbo_estabelecimento.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_estabelecimento") = customPage.getFilterValue("colamoperiodo", cbo_estabelecimento.ID)
                cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
            Else
                ViewState.Item("id_estabelecimento") = 0
            End If
        Else
            ViewState.Item("id_estabelecimento") = 0
        End If
        If Not (customPage.getFilterValue("colamoperiodo", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("colamoperiodo", txt_dt_referencia.ID)
            txt_dt_referencia.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If


        If Not (customPage.getFilterValue("colamoperiodo", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("colamoperiodo", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("colamoperiodo")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim coletaperiodo As New ColetaAmostraPeriodo

            coletaperiodo.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

            If Not (ViewState("dt_referencia").ToString().Equals(String.Empty)) Then
                coletaperiodo.dt_referencia = DateTime.Parse(ViewState("dt_referencia").ToString).ToString("dd/MM/yyyy")
            End If

            Dim dscoletaperiodo As DataSet = coletaperiodo.getColetaAmostraPeriodoFiltro()

            If (dscoletaperiodo.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscoletaperiodo.Tables(0), ViewState.Item("sortExpression"))
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


            Case "dt_referencia"
                If ViewState.Item("sortExpression") = "dt_referencia asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia asc"
                End If

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("colamoperiodo", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("colamoperiodo", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("colamoperiodo", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_coleta_amostra_periodo.aspx?dt_referencia=" + e.CommandArgument.ToString() + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString)


            Case "delete"
                deleteColetaAmostraPeriodo(e.CommandArgument.ToString())

        End Select

    End Sub

    Private Sub deleteColetaAmostraPeriodo(ByVal dt_referencia As String)

        Try

            Dim coletaperiodo As New ColetaAmostraPeriodo()
            coletaperiodo.id_estabelecimento = ViewState.Item("id_estabelecimento")
            coletaperiodo.dt_referencia = dt_referencia
            coletaperiodo.id_modificador = Convert.ToInt32(Session("id_login"))
            coletaperiodo.deleteColetaAmostraPeriodoTodos()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_coleta_amostra_periodo.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
            Dim lbl_dt_ini_amostra As Label = CType(e.Row.FindControl("lbl_dt_ini_amostra"), Label)

            btn_delete.Visible = True

            If CDate(ViewState.Item("dataultimacoleta")) >= CDate(lbl_dt_ini_amostra.Text) Then
                btn_delete.Enabled = False
                btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                btn_delete.ToolTip = "Não é possível excluir o registro. Já foi efetuada carga de rotas para a Referência, após o dia inicial do período para coleta de amostras."
            Else
                btn_delete.Enabled = True
                btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                btn_delete.ToolTip = String.Empty

            End If

            e.Row.Cells(1).Text = DateTime.Parse(e.Row.Cells(1).Text).ToString("MM/yyyy")



        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub lk_copiarreferencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_copiarreferencia.Click
        If Page.IsValid Then

            Try

                Dim coletaperiodo As New ColetaAmostraPeriodo()
                Dim lmsg As String = ""

                'Dados
                coletaperiodo.id_estabelecimento = cbo_estabelecimento.SelectedValue
                coletaperiodo.dt_referencia = DateTime.Parse(ViewState.Item("maior_referencia_periodo").ToString).ToString("dd/MM/yyyy")
                coletaperiodo.id_modificador = Session("id_login")

                If coletaperiodo.insertColetaAmostraPeriodoCopiarReferencia > 0 Then
                    txt_dt_referencia.Text = String.Empty
                    ViewState.Item("dt_referencia") = String.Empty
                    lmsg = "Nova referência copiada com sucesso."
                Else
                    lmsg = "Referência não pode ser copiada."
                End If

                messageControl.Alert(lmsg)

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub cv_copiarreerencia_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_copiarreerencia.ServerValidate
        Try
            Dim lmsg As String

            args.IsValid = True


            Dim coletaperiodo As New ColetaAmostraPeriodo
            coletaperiodo.id_estabelecimento = cbo_estabelecimento.SelectedValue

            'verifica a maior referencia cadastrada para o estabelecimento 
            'se ainda nao cadastrou referencia
            ViewState.Item("maior_referencia_periodo") = coletaperiodo.getColetaAmostraPeriodoMaiorReferencia
            If ViewState.Item("maior_referencia_periodo") = String.Empty Then
                args.IsValid = False
                lmsg = "A cópia não pode ser realizada! Não existe nenhuma referência para o estabelecimento informado nos cadastros de Período para Coleta de Amostras."
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class
