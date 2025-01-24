Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail
Imports System.IO


Partial Class lst_poupanca_manutencao
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_poupanca_manutencao.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try
            Dim situacao As New Situacao
            Dim situacaoPoupanca As New SituacaoPoupanca
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao_poupanca.DataSource = situacaoPoupanca.getSituacoesPoupancaByFilters()
            cbo_situacao_poupanca.DataTextField = "nm_situacao_poupanca"
            cbo_situacao_poupanca.DataValueField = "id_situacao_poupanca"
            cbo_situacao_poupanca.DataBind()
            cbo_situacao_poupanca.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_situacao_poupanca.SelectedValue = 1

            ViewState.Item("sortExpression") = "dt_referencia_ini desc"
            ViewState.Item("id_situacao_poupanca") = 1
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("dt_referencia_ini") = String.Empty
            ViewState.Item("dt_referencia_fim") = String.Empty

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()

        Try

            Dim poupanca As New PoupancaParametro

            poupanca.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            If (Not ViewState.Item("dt_referencia_ini").ToString().Equals(String.Empty)) Then
                poupanca.dt_referencia_ini = DateTime.Parse(ViewState.Item("dt_referencia_ini").ToString).ToString("dd/MM/yyyy")
            End If
            If (Not ViewState("dt_referencia_fim").ToString().Equals(String.Empty)) Then
                poupanca.dt_referencia_fim = DateTime.Parse(ViewState.Item("dt_referencia_fim").ToString).ToString("dd/MM/yyyy")
            End If
            poupanca.id_situacao_poupanca = Convert.ToInt32(Me.ViewState("id_situacao_poupanca").ToString())

            Dim dspoupanca As DataSet = poupanca.getPoupancaManutencaoSite()

            If (dspoupanca.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dspoupanca.Tables(0), ViewState.Item("sortExpression").ToString)
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("poupancamanut", cbo_estabelecimento.ID).Equals("0")) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("poupancamanut", cbo_estabelecimento.ID)
            cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = "0"
        End If

        If Not (customPage.getFilterValue("poupancamanut", txt_dt_inicio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia_ini") = customPage.getFilterValue("poupancamanut", txt_dt_inicio.ID)
            txt_dt_inicio.Text = ViewState.Item("dt_referencia_ini").ToString()
        Else
            ViewState.Item("dt_referencia_ini") = String.Empty
        End If

        If Not (customPage.getFilterValue("poupancamanut", txt_dt_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia_fim") = customPage.getFilterValue("poupancamanut", txt_dt_fim.ID)
            txt_dt_fim.Text = ViewState.Item("dt_referencia_fim").ToString()
        Else
            ViewState.Item("dt_referencia_fim") = String.Empty
        End If

        If (Me.customPage.getFilterValue("poupancamanut", cbo_situacao_poupanca.ID).Equals("0")) Then
            ViewState.Item("id_situacao_poupanca") = "0"
        Else
            hasFilters = True
            ViewState.Item("id_situacao_poupanca") = customPage.getFilterValue("poupancamanut", cbo_situacao_poupanca.ID)
            cbo_situacao_poupanca.SelectedValue = ViewState("id_situacao_poupanca").ToString()
        End If

        If Not (customPage.getFilterValue("poupancamanut", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("poupancamanut", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("poupancamanut")
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        Response.Redirect("lst_poupanca_manutencao.aspx")
    End Sub

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If (Me.Page.IsValid) Then
            ViewState("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            If (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("dt_referencia_ini") = String.Empty
                ViewState.Item("dt_referencia_fim") = String.Empty
            Else
                ViewState.Item("dt_referencia_ini") = String.Concat("01/", txt_dt_inicio.Text.ToString("MM/yyyy"))
                ViewState.Item("dt_referencia_fim") = String.Concat("01/", txt_dt_fim.ToString("MM/yyyy"))
            End If
            ViewState.Item("id_situacao_poupanca") = cbo_situacao_poupanca.SelectedValue
            loadData()
        End If
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "edit"
                savefilters()
                Response.Redirect(String.Concat("frm_poupanca_manutencao.aspx?id_poupanca_parametro=", e.CommandArgument.ToString()))
        End Select
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        Try
            If (e.Row.RowType = DataControlRowType.DataRow) Then

                Dim btn_edit As Anthem.ImageButton = CType(e.Row.FindControl("img_edit"), Anthem.ImageButton)
                Dim lbl_id_situacao_poupanca As Label = CType(e.Row.FindControl("lbl_id_situacao_poupanca"), Label)
                Dim txt_ref_ini As DataControlFieldCell = CType(e.Row.Cells(1), DataControlFieldCell)
                Dim txt_ref_fim As DataControlFieldCell = CType(e.Row.Cells(2), DataControlFieldCell)
                Dim txt_dt_limite As DataControlFieldCell = CType(e.Row.Cells(3), DataControlFieldCell)

                txt_ref_ini.Text = DateTime.Parse(txt_ref_ini.Text).ToString("MM/yyyy")
                txt_ref_fim.Text = DateTime.Parse(txt_ref_fim.Text).ToString("MM/yyyy")
                If Not txt_dt_limite.Text.ToString.Equals(String.Empty) Then
                    txt_dt_limite.Text = DateTime.Parse(txt_dt_limite.Text).ToString("dd/MM/yyyy")
                End If

                If (Not lbl_id_situacao_poupanca.Text.Equals(1)) Then
                    btn_edit.Enabled = False
                    btn_edit.ImageUrl = "~/img/icone_editar_desabilitado.gif"
                    btn_edit.ToolTip = "O período não está mais aberto para edição."
                Else
                    btn_edit.Enabled = True
                End If
                Dim hl_download As Anthem.HyperLink = CType(e.Row.FindControl("lk_download"), Anthem.HyperLink)
                If (Not hl_download.Text.ToString().Equals(String.Empty)) Then
                    hl_download.NavigateUrl = String.Format("frm_download.aspx?id={0}", Me.gridResults.DataKeys(e.Row.RowIndex).Value)
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting
        Select Case e.SortExpression.ToLower()

            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If

            Case "ds_produtor"
                If (ViewState.Item("sortExpression")) = "ds_produtor asc" Then
                    ViewState.Item("sortExpression") = "ds_produtor desc"
                Else
                    ViewState.Item("sortExpression") = "ds_produtor asc"
                End If

        End Select

        loadData()

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("poupancamanut", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("poupancamanut", txt_dt_inicio.ID, ViewState.Item("dt_referencia_ini").ToString)
            customPage.setFilter("poupancamanut", txt_dt_fim.ID, ViewState.Item("dt_referencia_fim").ToString)
            customPage.setFilter("poupancamanut", cbo_situacao_poupanca.ID, ViewState.Item("id_situacao_poupanca").ToString)
            customPage.setFilter("poupancamanut", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

End Class