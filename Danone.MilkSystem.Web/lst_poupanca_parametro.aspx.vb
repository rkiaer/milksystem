Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_poupanca_parametro
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia_ini") = String.Concat("01/", DateTime.Parse(txt_dt_inicio.Text).ToString("MM/yyyy"))
            ViewState.Item("dt_referencia_fim") = String.Concat("01/", DateTime.Parse(txt_dt_fim.Text).ToString("MM/yyyy"))
        Else
            ViewState.Item("dt_referencia_ini") = String.Empty
            ViewState.Item("dt_referencia_fim") = String.Empty
        End If
        ViewState.Item("id_situacao_poupanca") = cbo_situacao_poupanca.SelectedValue
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_poupanca_parametro.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_poupanca_parametro.aspx")

        If Not Page.IsPostBack Then
            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim statusPoupanca As New SituacaoPoupanca
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao_poupanca.DataSource = statusPoupanca.getSituacoesPoupancaByFilters()
            cbo_situacao_poupanca.DataTextField = "nm_situacao_poupanca"
            cbo_situacao_poupanca.DataValueField = "id_situacao_poupanca"
            cbo_situacao_poupanca.DataBind()
            cbo_situacao_poupanca.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            If cbo_situacao.Items.Count > 1 Then
                cbo_situacao.SelectedValue = 1 'assume que traz parametros ativos
            End If

            ViewState.Item("sortExpression") = "dt_referencia_ini desc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("poupancaparametro", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            If Not (customPage.getFilterValue("poupancaparametro", cbo_estabelecimento.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_estabelecimento") = customPage.getFilterValue("poupancaparametro", cbo_estabelecimento.ID)
                cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
            Else
                ViewState.Item("id_estabelecimento") = 0
            End If
        Else
            ViewState.Item("id_estabelecimento") = 0
        End If
        If Not (customPage.getFilterValue("poupancaparametro", txt_dt_inicio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia_ini") = customPage.getFilterValue("poupancaparametro", txt_dt_inicio.ID)
            txt_dt_inicio.Text = ViewState.Item("dt_referencia_ini").ToString()
        Else
            ViewState.Item("dt_referencia_ini") = String.Empty
        End If

        If Not (customPage.getFilterValue("poupancaparametro", txt_dt_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia_fim") = customPage.getFilterValue("poupancaparametro", txt_dt_fim.ID)
            txt_dt_fim.Text = ViewState.Item("dt_referencia_fim").ToString()
        Else
            ViewState.Item("dt_referencia_fim") = String.Empty
        End If

        If Not (customPage.getFilterValue("poupancaparametro", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            If Not (customPage.getFilterValue("poupancaparametro", cbo_situacao_poupanca.ID).Equals("0")) Then
                hasFilters = True
                ViewState.Item("id_situacao_poupanca") = customPage.getFilterValue("poupancaparametro", cbo_situacao_poupanca.ID)
                cbo_situacao_poupanca.Text = ViewState.Item("id_situacao_poupanca").ToString()
            Else
                ViewState.Item("id_situacao_poupanca") = "0"
            End If
        Else
            ViewState.Item("id_situacao_poupanca") = 0
        End If

        If Not (customPage.getFilterValue("poupancaparametro", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            If Not (customPage.getFilterValue("poupancaparametro", cbo_situacao.ID).Equals("0")) Or Not (customPage.getFilterValue("poupancaparametro", cbo_situacao.ID).Equals("")) Then
                hasFilters = True
                ViewState.Item("id_situacao") = customPage.getFilterValue("poupancaparametro", cbo_situacao.ID)
                cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
            Else
                ViewState.Item("id_situacao") = String.Empty
            End If
        Else
            ViewState.Item("id_situacao") = 0
        End If


        If Not (customPage.getFilterValue("poupancaparametro", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("poupancaparametro", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("poupancaparametro")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim poupancaparametro As New PoupancaParametro

            poupancaparametro.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

            If Not (ViewState("dt_referencia_ini").ToString().Equals(String.Empty)) Then
                poupancaparametro.dt_referencia_ini = DateTime.Parse(ViewState("dt_referencia_ini").ToString).ToString("dd/MM/yyyy")
            End If
            If Not (ViewState("dt_referencia_fim").ToString().Equals(String.Empty)) Then
                poupancaparametro.dt_referencia_fim = DateTime.Parse(ViewState("dt_referencia_fim").ToString).ToString("dd/MM/yyyy")
            End If

            poupancaparametro.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            poupancaparametro.id_situacao_poupanca = Convert.ToInt32(ViewState.Item("id_situacao_poupanca").ToString())

            Dim dsPoupancaParam As DataSet = poupancaparametro.getPoupancaParametro()

            If (dsPoupancaParam.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPoupancaParam.Tables(0), ViewState.Item("sortExpression"))
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


            Case "dt_referencia_ini"
                If ViewState.Item("sortExpression") = "dt_referencia_ini asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia_ini desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia_ini asc"
                End If

            Case "dt_referencia_fim"
                If ViewState.Item("sortExpression") = "dt_referencia_fim asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia_fim desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia_fim asc"
                End If

            Case "nm_situacao_poupanca"
                If ViewState.Item("sortExpression") = "nm_situacao_poupanca asc" Then
                    ViewState.Item("sortExpression") = "nm_situacao_poupanca desc"
                Else
                    ViewState.Item("sortExpression") = "nm_situacao_poupanca asc"
                End If
            
        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("poupancaparametro", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("poupancaparametro", txt_dt_inicio.ID, ViewState.Item("dt_referencia_ini").ToString)
            customPage.setFilter("poupancaparametro", txt_dt_fim.ID, ViewState.Item("dt_referencia_fim").ToString)
            customPage.setFilter("poupancaparametro", cbo_situacao_poupanca.ID, ViewState.Item("id_situacao_poupanca").ToString)
            customPage.setFilter("poupancaparametro", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("poupancaparametro", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_poupanca_parametro.aspx?id_poupanca_parametro=" + e.CommandArgument.ToString())

            Case "delete"
                deletePoupancaParametro(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deletePoupancaParametro(ByVal id_poupanca_parametro As Integer)

        Try

            Dim poupancaparametro As New PoupancaParametro()
            poupancaparametro.id_poupanca_parametro = id_poupanca_parametro
            poupancaparametro.id_modificador = Convert.ToInt32(Session("id_login"))
            poupancaparametro.deletePoupancaParametro()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_poupanca_parametro.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
            Dim lbl_id_situacao_poupanca As Label = CType(e.Row.FindControl("lbl_id_situacao_poupanca"), Label)

            e.Row.Cells(1).Text = DateTime.Parse(e.Row.Cells(1).Text).ToString("MM/yyyy")
            e.Row.Cells(2).Text = DateTime.Parse(e.Row.Cells(2).Text).ToString("MM/yyyy")

            If lbl_id_situacao_poupanca.Text.Equals(1) Then
                btn_delete.Visible = True

                Dim poupancaparam As New PoupancaParametro
                poupancaparam.id_poupanca_parametro = Convert.ToInt32(gridResults.DataKeys.Item(e.Row.RowIndex).Value)
                If poupancaparam.getPoupancaCalculoMensalbyParametro > 0 Then
                    btn_delete.Enabled = False
                    btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                    btn_delete.ToolTip = "Não é possível excluir o registro. Já foi efetuado cálculo de poupança mensal para este parâmetro."
                Else
                    btn_delete.Enabled = True
                    btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                    btn_delete.ToolTip = String.Empty
                End If
            Else 'se finalizado a poupanca
                btn_delete.Visible = False
            End If

        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
End Class
