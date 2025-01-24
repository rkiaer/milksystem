Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_romaneio_analises

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


        If Not (customPage.getFilterValue("romaneio_lst_analises", "id_romaneio").Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("romaneio_lst_analise", "id_romaneio")
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If

        If (hasFilters) Then
            customPage.clearFilters("romaneio_lst_analise")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))
            lbl_reanalise.Text = "Não Realizada"
            If romaneio.st_reanalise = "S" Then
                btn_reanalise.Enabled = False
                btn_reanalise.ToolTip = "Função desabilitada para este Romaneio. Re-Análise já foi gerada."
                lbl_reanalise.Text = "Realizada"
            End If

            Me.lbl_romaneio.Text = romaneio.id_romaneio.ToString
            Me.lbl_nm_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            Me.lbl_ds_transportador.Text = romaneio.ds_transportador.ToString
            Me.lbl_ds_placa.Text = romaneio.ds_placa.ToString
            Me.lbl_dt_hora_entrada.Text = romaneio.dt_hora_entrada.ToString
            'Me.lbl_nm_st_analise_global.Text = romaneio.nm_st_analise_global.ToString
            'lbl_nm_st_analise_compartimento.Text = romaneio.nm_st_analise_compartimento.ToString
            'lbl_nm_st_analise_uproducao.Text = romaneio.nm_st_analise_uproducao.ToString

            Dim romaneioanalisecompartimento As New RomaneioAnaliseCompartimento

            romaneioanalisecompartimento.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

            Dim dsromaneioanalisecomp As DataSet = romaneioanalisecompartimento.getRomaneioAnalisesCompartimentosByFilters

            'Se ha linhas na romaneio analise compartimento
            If (dsromaneioanalisecomp.Tables(0).Rows.Count > 0) Then

                Dim romaneiocompartimento As New Romaneio_Compartimento

                romaneiocompartimento.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

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

            customPage.setFilter("romaneio_lst_analise", "id_romaneio", ViewState.Item("id_romaneio").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToUpper.Trim
            Case "REGISTRAR_ANALISE_COMPARTIMENTO"
                saveFilters()
                Response.Redirect("frm_romaneio_analise_compartimento.aspx?id_romaneio_compartimento=" + e.CommandArgument.ToString)

            Case "REGISTRAR_ANALISE_UPRODUCAO"
                saveFilters()
                Response.Redirect("frm_romaneio_analise_uproducao.aspx?id_romaneio_uproducao=" + e.CommandArgument.ToString)
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

    'Protected Sub btn_registrar_analise_global_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_registrar_analise_global.Click
    '    saveFilters()
    '    Response.Redirect("frm_romaneio_analise_global.aspx?id_romaneio=" + lbl_romaneio.Text)
    '    'Response.Redirect("frm_propriedade.aspx?id_propriedade=" + e.CommandArgument.ToString())
    'End Sub

 

  
    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        'Response.Redirect("")
        'Response.Redirect("lst_romaneios_analise_selecao.aspx?id_romaneio=" + lbl_romaneio.Text)
        Response.Redirect("lst_romaneios_analise_selecao.aspx")
    End Sub

 
    Protected Sub btn_registrar_analise_uproducao_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        saveFilters()
        Response.Redirect("frm_romaneio_analise_uproducao.aspx?id_romaneio_uproducao=" + e.CommandArgument.ToString)

    End Sub


    Protected Sub btn_reanalise_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_reanalise.Click

        If Page.IsValid Then

            Try
                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                romaneio.gerarRomaneioReanalises()

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub cv_reanalise_obrigatorias_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_reanalise_obrigatorias.ServerValidate
        Try
            args.IsValid = True
            Dim analisesaprovadas As New Romaneio_Compartimento
            Dim lmsg As String
            analisesaprovadas.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            'Verifica se há compartimentos registrados aprovados ou sem registro
            If analisesaprovadas.getRomaneioCompartimentosAprovados > 0 Then
                'se existe
                'Verifica se há alguma analise sem valor
                If analisesaprovadas.getRomaneioAnaliseCompartimentoAprovadoNuloObrigatoriaSemValor > 0 Then
                    args.IsValid = False
                    lmsg = "A re-análise não pode ser gerada pois há Compartimentos com análises obrigatórias sem preenchimento de resultado."
                Else
                    'Busca todas as compartimento sem registro com analises rejeitafdas
                    If analisesaprovadas.getRomaneioCompartimentosSemRegistroAnaliseRejeitada > 0 Then
                        args.IsValid = False
                        lmsg = "A re-análise não pode ser gerada pois há Compartimentos não registrados com análises rejeitadas."
                    End If
                End If
            Else
                args.IsValid = False
                lmsg = "A re-análise não pode ser gerada pois todos os compartimentos já estão registrados como 'Rejeitado' ou 'Aprovado sob Concessão'."
            End If
            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
