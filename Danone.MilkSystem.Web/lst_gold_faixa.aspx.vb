Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_gold_faixa
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("tipo_faixa") = cbo_tipo_faixa.SelectedValue
        ViewState.Item("dt_referencia_inicial") = txt_dt_referencia_inicial.Text.Trim()
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_gold_faixa.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_faixa_qualidade.aspx")
        If Not Page.IsPostBack Then
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
            cbo_situacao.SelectedValue = 1

            Dim estabelecimento As New Estabelecimento
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            ViewState.Item("sortExpression") = "dt_referencia_inicial desc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("faixa", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("faixa", cbo_estabelecimento.ID)
            cbo_estabelecimento.Text = ViewState("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("faixa", txt_dt_referencia_inicial.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia_inicial") = customPage.getFilterValue("faixa", txt_dt_referencia_inicial.ID)
            txt_dt_referencia_inicial.Text = ViewState.Item("dt_referencia_inicial").ToString()
        Else
            ViewState.Item("dt_referencia_inicial") = String.Empty
        End If

        If Not (customPage.getFilterValue("faixa", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("faixa", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If

        If Not (customPage.getFilterValue("faixa", cbo_tipo_faixa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("tipo_faixa") = customPage.getFilterValue("faixa", cbo_tipo_faixa.ID)
            cbo_tipo_faixa.Text = ViewState.Item("tipo_faixa").ToString()
        Else
            ViewState.Item("tipo_faixa") = String.Empty
        End If


        If Not (customPage.getFilterValue("faixa", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("faixa", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("faixa")
        End If

    End Sub

    Private Sub loadData()

        Try
            Select Case cbo_tipo_faixa.SelectedValue
                Case 1   ' Custo
                    loadCusto()
                Case 2   ' Volume
                    loadVolume()
                Case 3   ' Crescimento
                    loadCrescimento()
                Case 4   ' Eficiencia
                    loadEficiencia()
            End Select

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadVolume()

        Try

            Dim faixaVolume As New GoldFaixaVolume


            If Not ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty) Then
                faixaVolume.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
            End If
            faixaVolume.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            faixaVolume.dt_referencia_inicial = ViewState.Item("dt_referencia_inicial").ToString()

            If (faixaVolume.dt_referencia_inicial.ToString.Trim <> "") Then
                faixaVolume.dt_referencia_inicial = String.Concat("01/", faixaVolume.dt_referencia_inicial)
            End If


            Dim dsfaixavolume As DataSet = faixaVolume.getGoldFaixaVolumeGrupos()

            If (dsfaixavolume.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsfaixavolume.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadCusto()

        Try

            Dim faixaCusto As New GoldFaixaCusto


            If Not ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty) Then
                faixaCusto.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
            End If
            faixaCusto.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            faixaCusto.dt_referencia_inicial = ViewState.Item("dt_referencia_inicial").ToString()

            If (faixaCusto.dt_referencia_inicial.ToString.Trim <> "") Then
                faixaCusto.dt_referencia_inicial = String.Concat("01/", faixaCusto.dt_referencia_inicial)
            End If


            Dim dsfaixacusto As DataSet = faixaCusto.getGoldFaixaCustoGrupos()

            If (dsfaixacusto.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsfaixacusto.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadCrescimento()

        Try

            Dim faixaCrescimento As New GoldFaixaCrescimento


            If Not ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty) Then
                faixaCrescimento.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
            End If
            faixaCrescimento.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            faixaCrescimento.dt_referencia_inicial = ViewState.Item("dt_referencia_inicial").ToString()

            If (faixaCrescimento.dt_referencia_inicial.ToString.Trim <> "") Then
                faixaCrescimento.dt_referencia_inicial = String.Concat("01/", faixaCrescimento.dt_referencia_inicial)
            End If


            Dim dsfaixacrescimento As DataSet = faixaCrescimento.getGoldFaixaCrescimentoGrupos()

            If (dsfaixacrescimento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsfaixacrescimento.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadEficiencia()

        Try

            Dim faixaEficiencia As New GoldFaixaEficiencia


            If Not ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty) Then
                faixaEficiencia.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
            End If
            faixaEficiencia.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            faixaEficiencia.dt_referencia_inicial = ViewState.Item("dt_referencia_inicial").ToString()

            If (faixaEficiencia.dt_referencia_inicial.ToString.Trim <> "") Then
                faixaEficiencia.dt_referencia_inicial = String.Concat("01/", faixaEficiencia.dt_referencia_inicial)
            End If


            Dim dsfaixaeficiencia As DataSet = faixaEficiencia.getGoldFaixaEficienciaGrupos()

            If (dsfaixaeficiencia.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsfaixaeficiencia.Tables(0), ViewState.Item("sortExpression"))
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

            Case "nm_estabelecimento"
                If (ViewState.Item("sortExpression")) = "nm_estabelecimento asc" Then
                    ViewState.Item("sortExpression") = "nm_estabelecimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_estabelecimento asc"
                End If

            Case "dt_referencia_inicial"
                If (ViewState.Item("sortExpression")) = "dt_referencia_inicial asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia_inicial desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia_inicial asc"
                End If


            Case "nm_gold_faixa"
                If (ViewState.Item("sortExpression")) = "nm_gold_faixa asc" Then
                    ViewState.Item("sortExpression") = "nm_gold_faixa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_gold_faixa asc"
                End If

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try
            customPage.setFilter("faixa", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("faixa", cbo_tipo_faixa.ID, ViewState.Item("tipo_faixa").ToString)
            customPage.setFilter("faixa", txt_dt_referencia_inicial.ID, ViewState.Item("dt_referencia_inicial").ToString)
            customPage.setFilter("faixa", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            Dim Teste As Object = gridResults.PageIndex.ToString()
            customPage.setFilter("faixa", "PageIndex", gridResults.PageIndex.ToString())




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_gold_faixa.aspx?cd_gold_faixa=" + e.CommandArgument.ToString() + "&tipo_gold_faixa=" + cbo_tipo_faixa.SelectedValue.ToString)

            Case "delete"
                deleteFaixa(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteFaixa(ByVal cd_gold_faixa As Integer)

        Try

            Select Case cbo_tipo_faixa.SelectedValue
                Case 1   ' Custo
                    deleteCusto(cd_gold_faixa)
                Case 2   ' Volume
                    deleteVolume(cd_gold_faixa)
                Case 3   ' Crescimento
                    deleteCrescimento(cd_gold_faixa)
                Case 4   ' Eficiencia
                    deleteEficiencia(cd_gold_faixa)
            End Select

            Dim faixaqualidade As New FaixaQualidade()
            faixaqualidade.id_faixa_qualidade = cd_gold_faixa
            faixaqualidade.id_modificador = Convert.ToInt32(Session("id_login"))
            faixaqualidade.deleteConta()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub deleteCusto(ByVal cd_gold_faixa As Integer)

        Try
            Dim goldfaixacusto As New GoldFaixaCusto
            goldfaixacusto.cd_gold_faixa_custo = cd_gold_faixa
            goldfaixacusto.id_modificador = Convert.ToInt32(Session("id_login"))
            goldfaixacusto.deleteGoldFaixaCusto()
            messageControl.Alert("Registro desativado com sucesso!")
            loadCusto()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub deleteVolume(ByVal cd_gold_faixa As Integer)

        Try
            Dim goldfaixavolume As New GoldFaixaVolume
            goldfaixavolume.cd_gold_faixa_volume = cd_gold_faixa
            goldfaixavolume.id_modificador = Convert.ToInt32(Session("id_login"))
            goldfaixavolume.deleteGoldFaixavolume()
            messageControl.Alert("Registro desativado com sucesso!")
            loadVolume()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub deleteCrescimento(ByVal cd_gold_faixa As Integer)

        Try
            Dim goldfaixacrescimento As New GoldFaixaCrescimento
            goldfaixacrescimento.cd_gold_faixa_crescimento = cd_gold_faixa
            goldfaixacrescimento.id_modificador = Convert.ToInt32(Session("id_login"))
            goldfaixacrescimento.deleteGoldFaixaCrescimento()
            messageControl.Alert("Registro desativado com sucesso!")
            loadCrescimento()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub deleteEficiencia(ByVal cd_gold_faixa As Integer)

        Try
            Dim goldfaixaeficiencia As New GoldFaixaEficiencia
            goldfaixaeficiencia.cd_gold_faixa_eficiencia = cd_gold_faixa
            goldfaixaeficiencia.id_modificador = Convert.ToInt32(Session("id_login"))
            goldfaixaeficiencia.deleteGoldFaixaEficiencia()
            messageControl.Alert("Registro desativado com sucesso!")
            loadEficiencia()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_gold_faixa.aspx")
    End Sub
    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub
End Class
