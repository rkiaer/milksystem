Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_romaneio_analises_uproducao

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneios_analise_selecao.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub


    Private Sub loadDetails()

        Try

            'Se veio da tela da seleção do romaneio
            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                ViewState.Item("id_romaneio_compartimento") = Request("id_romaneio_compartimento")
                'fran 12/2016 i
                If Not (Request("nm_tela") Is Nothing) Then
                    ViewState.Item("nm_tela") = Request("nm_tela")
                Else
                    ViewState.Item("nm_tela") = String.Empty
                End If
            Else 'Se veio da tela de registro de analises
                loadFilters()
            End If

            If Not (ViewState.Item("id_romaneio").ToString.Equals(String.Empty)) Then
                'ViewState.Item("sortExpression") = "nr_compartimento asc"
                loadData()
            Else
                messageControl.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("rom_lst_anaprod", "id_romaneio").Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("rom_lst_anaprod", "id_romaneio")
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If
        If Not (customPage.getFilterValue("rom_lst_anaprod", "id_romaneio_compartimento").Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio_compartimento") = customPage.getFilterValue("rom_lst_anaprod", "id_romaneio_compartimento")
        Else
            ViewState.Item("id_romaneio_compartimento") = String.Empty
        End If

        If (hasFilters) Then
            customPage.clearFilters("rom_lst_anaprod")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))
            lbl_reanalise.Text = "Não Realizada"

            Me.lbl_romaneio.Text = romaneio.id_romaneio.ToString
            Me.lbl_nm_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            Me.lbl_dt_hora_entrada.Text = romaneio.dt_hora_entrada.ToString

            Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento

            romaneioanalisecompartimento.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            romaneioanalisecompartimento.id_romaneio_compartimento = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento"))

            Dim dsromaneioanalisecomp As DataSet = romaneioanalisecompartimento.getRomaneioAnalisesCompartimentosByFilters

            'Se ha linhas na romaneio analise compartimento
            If (dsromaneioanalisecomp.Tables(0).Rows.Count > 0) Then

                Dim romaneiocompartimento As New Romaneio_Compartimento

                romaneiocompartimento.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                romaneiocompartimento.id_romaneio_compartimento = Convert.ToInt32(ViewState.Item("id_romaneio_compartimento"))

                Dim dsromaneiocomp As DataSet = romaneiocompartimento.getRomaneio_CompartimentoByFilters

                If (dsromaneiocomp.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsromaneiocomp.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                    'messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If
            Else
                gridResults.Visible = False
                'messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub


    Private Sub saveFilters()

        Try

            customPage.setFilter("rom_lst_anaprod", "id_romaneio", ViewState.Item("id_romaneio").ToString)
            customPage.setFilter("rom_lst_anaprod", "id_romaneio_compartimento", ViewState.Item("id_romaneio_compartimento").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToUpper.Trim
            Case "REGISTRAR_ANALISE_COMPARTIMENTO"
                saveFilters()
                If ViewState.Item("nm_tela").Equals(String.Empty) Then
                    Response.Redirect("frm_romaneio_analise_compartimento.aspx?id_romaneio_compartimento=" + e.CommandArgument.ToString)
                Else
                    Response.Redirect("frm_romaneio_analise_compartimento.aspx?id_romaneio_compartimento=" + e.CommandArgument.ToString + "&nm_tela=" + ViewState.Item("nm_tela").ToString)
                End If

            Case "REGISTRAR_ANALISE_UPRODUCAO"
                saveFilters()
                If ViewState.Item("nm_tela").Equals(String.Empty) Then
                    Response.Redirect("frm_romaneio_analise_uproducao.aspx?id_romaneio_uproducao=" + e.CommandArgument.ToString)
                Else
                    Response.Redirect("frm_romaneio_analise_uproducao.aspx?id_romaneio_uproducao=" + e.CommandArgument.ToString + "&nm_tela=" + ViewState.Item("nm_tela").ToString)
                End If

        End Select
    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbl_nm_status_compartimento As Label = CType(e.Row.FindControl("lbl_nm_st_compartimento"), Label)
            If Not lbl_nm_status_compartimento.Text.Trim.ToUpper.Equals(String.Empty) And lbl_nm_status_compartimento.Text.Trim.ToUpper = "REJEITADO" Then
                Dim idromaneiocompartimento As Label = CType(e.Row.FindControl("lbl_id_romaneio_compartimento"), Label)
                If Not (idromaneiocompartimento.Text.Trim.Equals(String.Empty)) Then
                    Dim romaneiouproducao As New Romaneio_Comp_UProducao
                    romaneiouproducao.id_romaneio_compartimento = Convert.ToInt32(idromaneiocompartimento.Text.Trim)
                    romaneiouproducao.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                    'romaneiouproducao.id_romaneio_uproducao = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)

                    Dim dsromaneiouprod As DataSet = romaneiouproducao.getRomaneio_Comp_UProducaoByFilters
                    Dim gridAnalisesUproducao As GridView = CType(e.Row.FindControl("gridAnalisesUproducao"), GridView)

                    If (dsromaneiouprod.Tables(0).Rows.Count > 0) Then
                        gridAnalisesUproducao.Visible = True
                        gridAnalisesUproducao.DataSource = Helper.getDataView(dsromaneiouprod.Tables(0), ViewState.Item("sortExpression"))
                        gridAnalisesUproducao.DataBind()
                    Else
                        gridAnalisesUproducao.Visible = False
                    End If
                End If
            End If
        End If

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        If ViewState.Item("nm_tela").Equals(String.Empty) Then
            Response.Redirect("frm_romaneio_analise_comp_veiculo.aspx?id_romaneio=" + ViewState.Item("id_romaneio"))
        Else
            Response.Redirect("frm_pre_romaneio_analise_comp_veiculo.aspx?id_romaneio=" + ViewState.Item("id_romaneio"))
        End If

    End Sub


    Protected Sub btn_registrar_analise_uproducao_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        saveFilters()
        If ViewState.Item("nm_tela").Equals(String.Empty) Then
            Response.Redirect("frm_romaneio_analise_uproducao.aspx?id_romaneio_uproducao=" + e.CommandArgument.ToString)
        Else
            Response.Redirect("frm_romaneio_analise_uproducao.aspx?id_romaneio_uproducao=" + e.CommandArgument.ToString + "&nm_tela=" + ViewState.Item("nm_tela").ToString)
        End If
    End Sub

End Class
