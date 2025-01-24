Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_coleta_amostra_frasco
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

        Response.Redirect("lst_coleta_amostra_frasco.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_coleta_amostra_frasco.aspx")

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


            ViewState.Item("sortExpression") = "dt_validade desc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("colamofrasco", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            If Not (customPage.getFilterValue("colamofrasco", cbo_estabelecimento.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_estabelecimento") = customPage.getFilterValue("colamofrasco", cbo_estabelecimento.ID)
                cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
            Else
                ViewState.Item("id_estabelecimento") = 0
            End If
        Else
            ViewState.Item("id_estabelecimento") = 0
        End If
        If Not (customPage.getFilterValue("colamofrasco", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("colamofrasco", txt_dt_referencia.ID)
            txt_dt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia").ToString()).ToString("MM/yyyy")
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If


        If Not (customPage.getFilterValue("colamofrasco", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("colamofrasco", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("colamofrasco")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim coletafrasco As New ColetaAmostraFrasco

            coletafrasco.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

            If Not (ViewState("dt_referencia").ToString().Equals(String.Empty)) Then
                coletafrasco.dt_validade = DateTime.Parse(ViewState("dt_referencia").ToString).ToString("dd/MM/yyyy")
            End If

            Dim dscoletafrasco As DataSet = coletafrasco.getColetaAmostraFrascoFiltro()

            If (dscoletafrasco.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscoletafrasco.Tables(0), ViewState.Item("sortExpression"))
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


            Case "dt_validade"
                If ViewState.Item("sortExpression") = "dt_validade asc" Then
                    ViewState.Item("sortExpression") = "dt_validade desc"
                Else
                    ViewState.Item("sortExpression") = "dt_validade asc"
                End If

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("colamofrasco", cbo_estabelecimento.ID, cbo_estabelecimento.SelectedValue)
            customPage.setFilter("colamofrasco", txt_dt_referencia.ID, String.Concat("01/", DateTime.Parse(txt_dt_referencia.Text).ToString("MM/yyyy")))
            customPage.setFilter("colamofrasco", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_coleta_amostra_frasco.aspx?dt_referencia=" + e.CommandArgument.ToString() + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString)


            Case "delete"
                deleteColetaAmostraFrasco(e.CommandArgument.ToString())

        End Select

    End Sub

    Private Sub deleteColetaAmostraFrasco(ByVal dt_referencia As String)

        Try

            Dim coletafrasco As New ColetaAmostraFrasco()
            coletafrasco.id_estabelecimento = ViewState.Item("id_estabelecimento")
            coletafrasco.dt_validade = dt_referencia
            coletafrasco.id_modificador = Convert.ToInt32(Session("id_login"))
            coletafrasco.deleteColetaAmostraFrascoTodos()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_coleta_amostra_frasco.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
            Dim img_chk1 As Anthem.Image = CType(e.Row.FindControl("img_chk1"), Anthem.Image)
            Dim img_chk2 As Anthem.Image = CType(e.Row.FindControl("img_chk2"), Anthem.Image)
            Dim img_chk3 As Anthem.Image = CType(e.Row.FindControl("img_chk3"), Anthem.Image)
            Dim img_chk4 As Anthem.Image = CType(e.Row.FindControl("img_chk4"), Anthem.Image)

            Dim ldatavalidade As String = DateTime.Parse(gridResults.DataKeys.Item(e.Row.RowIndex).Value.ToString).ToString("dd/MM/yyyy")

            btn_delete.Visible = True

            If CDate(ViewState.Item("dataultimacoleta")) >= CDate(DateAdd(DateInterval.Month, 1, CDate(ldatavalidade))) Then
                btn_delete.Enabled = False
                btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                btn_delete.ToolTip = "Não é possível excluir o registro. Já foi efetuada carga de rotas após a criação da Referência."
            Else
                btn_delete.Enabled = True
                btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                btn_delete.ToolTip = String.Empty

            End If

            e.Row.Cells(1).Text = DateTime.Parse(e.Row.Cells(1).Text).ToString("MM/yyyy")

            'se descrição de visualizacao no coletor do frasco 1 for vazia
            If e.Row.Cells(3).Text.Equals(String.Empty) OrElse e.Row.Cells(3).Text.Equals("&nbsp;") Then
                img_chk1.ImageUrl = "~/img/ico_chk_false.gif"
            Else
                img_chk1.ImageUrl = "~/img/ico_chk_true.gif"
            End If
            'se descrição de visualizacao no coletor do frasco 2 for vazia
            If e.Row.Cells(5).Text.Equals(String.Empty) OrElse e.Row.Cells(5).Text.Equals("&nbsp;") Then
                img_chk2.ImageUrl = "~/img/ico_chk_false.gif"
            Else
                img_chk2.ImageUrl = "~/img/ico_chk_true.gif"
            End If
            'se descrição de visualizacao no coletor do frasco 3 for vazia

            If e.Row.Cells(7).Text.Equals(String.Empty) OrElse e.Row.Cells(7).Text.Equals("&nbsp;") Then
                img_chk3.ImageUrl = "~/img/ico_chk_false.gif"
            Else
                img_chk3.ImageUrl = "~/img/ico_chk_true.gif"
            End If
            'se descrição de visualizacao no coletor do frasco 4 for vazia
            If e.Row.Cells(9).Text.Equals(String.Empty) OrElse e.Row.Cells(9).Text.Equals("&nbsp;") Then
                img_chk4.ImageUrl = "~/img/ico_chk_false.gif"
            Else
                img_chk4.ImageUrl = "~/img/ico_chk_true.gif"
            End If


        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


End Class
