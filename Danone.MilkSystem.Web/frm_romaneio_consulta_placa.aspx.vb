Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_romaneio_consulta_placa
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_consulta.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                ViewState.Item("placa_ativa") = 0 'Assume que a placa ativa é a da 1a aba
                If Not (Request("tela") Is Nothing) Then
                    ViewState.Item("telachamadora") = Request("tela")
                Else
                    ViewState.Item("telachamadora") = String.Empty
                End If
                If Not (Request("titulo") Is Nothing) Then
                    ViewState.Item("titulo") = Request("titulo")
                    lbl_titulo.Text = ViewState.Item("titulo").ToString & " -  Consulta de Placas/Compartimentos"
                Else
                    ViewState.Item("titulo") = String.Empty
                End If
                loadData()
            Else
                loadParams()
                If ViewState.Item("id_romaneio").Equals(String.Empty) Then
                    messageControl.Alert("Há problemas na passagem de parametros. A tela não pode ser montada!")
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try



    End Sub

    Private Sub loadData()
        Try
            Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

            lbl_romaneio.Text = romaneio.id_romaneio
            lbl_st_romaneio.Text = romaneio.nm_st_romaneio

            'fran 20/02/2017 i se é um pre-romaneio de transit point i
            If romaneio.id_transit_point_unidade > 0 Then
                lbl_titulo.Text = "Consulta do Pré-Romaneio para Transit Point - Placas/Compartimentos"
                pnl_dados_cip.Visible = False
                pnl_dados_lacres.Visible = False
                tr_dados_descarga.Visible = False
                tr_dados_silo.Visible = False
                tr_dados_volumedescarregadoreal.Visible = False
                pnl_romaneio.GroupingText = "Dados Pré-Romaneio"
                lbl_titulo_romaneio.Text = "Nr. Pré-Romaneio"
                lbl_titulo_situacao.Text = "Situação Pré-Romaneio"
            End If
            'fran 20/02/2017 i se é um pre-romaneio de transit point f
            'fran 07/2022
            If romaneio.id_st_romaneio >= 13 Then
                lbl_titulo.Text = "Consulta do Pré-Romaneio para Transvase - Placas/Compartimentos"
                pnl_dados_cip.Visible = False
                pnl_dados_lacres.Visible = False
                tr_dados_descarga.Visible = False
                tr_dados_silo.Visible = False
                tr_dados_volumedescarregadoreal.Visible = False
                pnl_romaneio.GroupingText = "Dados Pré-Romaneio"
                lbl_titulo_romaneio.Text = "Nr. Pré-Romaneio"
                lbl_titulo_situacao.Text = "Situação Pré-Romaneio"
            End If

            loadplacas()

            If romaneio.id_st_romaneio >= 13 Then
                gridCompartimento.Columns(4).Visible = False
                gridCompartimento.Columns(5).Visible = False

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadplacas()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim rplaca As New RomaneioPlaca
            Dim placa As Integer

            rplaca.id_romaneio = id_romaneio
            
            Dim dsplacas As DataSet = rplaca.getRomaneioPlacasByRomaneio()

            If (dsplacas.Tables(0).Rows.Count > 0) Then
                For placa = 0 To dsplacas.Tables(0).Rows.Count - 1
                    With dsplacas.Tables(0).Rows(placa)
                        Select Case placa
                            Case 0
                                Me.btn_placa1.Text = .Item("ds_placa")
                                Me.btn_placa1.CommandArgument = .Item("id_romaneio_placa")
                            Case 1
                                Me.pnl_placa2.Visible = True
                                Me.btn_placa2.Visible = True
                                Me.btn_placa2.Text = .Item("ds_placa")
                                Me.btn_placa2.CommandArgument = .Item("id_romaneio_placa")
                            Case 2
                                Me.pnl_placa3.Visible = True
                                Me.btn_placa3.Visible = True
                                Me.btn_placa3.Text = .Item("ds_placa")
                                Me.btn_placa3.CommandArgument = .Item("id_romaneio_placa")
                            Case 3
                                Me.pnl_placa4.Visible = True
                                Me.btn_placa4.Visible = True
                                Me.btn_placa4.Text = .Item("ds_placa")
                                Me.btn_placa4.CommandArgument = .Item("id_romaneio_placa")
                            Case 4
                                Me.pnl_placa4.Visible = True
                                Me.btn_placa5.Visible = True
                                Me.btn_placa5.Text = .Item("ds_placa")
                                Me.btn_placa5.CommandArgument = .Item("id_romaneio_placa")
                        End Select
                    End With
                Next
                loadabasplacas()
            Else
                messageControl.Alert("Não há placas cadastradas para este romaneio. Há problemas na passagem de parametros.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadabasplacas()

        Try

            Dim lid_romaneio_placa_ativa As Int32
            td_placa1.Attributes.Remove("class")
            If ViewState("placa_ativa") = 0 Then
                'td_placa1.Attributes.Add("class", "aba_ativa")
                pnl_placa1.BackImageUrl = "~/img/aba_ativa.gif"
                pnl_placa1.ForeColor = System.Drawing.Color.FromName("#0000F5")
                btn_placa1.ForeColor = System.Drawing.Color.FromName("#0000F5")
                'btn_placa1.Attributes.Add("forecolor", "#0000F5")
                lid_romaneio_placa_ativa = btn_placa1.CommandArgument
            Else
                pnl_placa1.BackImageUrl = "~/img/aba_nao_ativa.gif"
                pnl_placa1.ForeColor = System.Drawing.Color.FromName("#6767CC")
                btn_placa1.ForeColor = System.Drawing.Color.FromName("#6767CC")
            End If
            If btn_placa2.Visible = True Then
                'td_placa2.Attributes.Remove("class")
                If ViewState("placa_ativa") = 1 Then
                    'td_placa2.Attributes.Add("class", "aba_ativa")
                    pnl_placa2.BackImageUrl = "~/img/aba_ativa.gif"
                    pnl_placa2.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    btn_placa2.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    lid_romaneio_placa_ativa = btn_placa2.CommandArgument
                Else
                    'td_placa2.Attributes.Add("class", "aba_nao_ativa")
                    pnl_placa2.BackImageUrl = "~/img/aba_nao_ativa.gif"
                    pnl_placa2.ForeColor = System.Drawing.Color.FromName("#6767CC")
                    btn_placa2.ForeColor = System.Drawing.Color.FromName("#6767CC")
                End If
            End If
            If btn_placa3.Visible = True Then
                'td_placa3.Attributes.Remove("class")
                If ViewState("placa_ativa") = 2 Then
                    pnl_placa3.BackImageUrl = "~/img/aba_ativa.gif"
                    pnl_placa3.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    btn_placa3.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    lid_romaneio_placa_ativa = btn_placa3.CommandArgument
                Else
                    pnl_placa3.BackImageUrl = "~/img/aba_nao_ativa.gif"
                    pnl_placa3.ForeColor = System.Drawing.Color.FromName("#6767CC")
                    btn_placa3.ForeColor = System.Drawing.Color.FromName("#6767CC")
                End If
            End If
            If btn_placa4.Visible = True Then
                'td_placa4.Attributes.Remove("class")
                If ViewState("placa_ativa") = 3 Then
                    pnl_placa4.BackImageUrl = "~/img/aba_ativa.gif"
                    pnl_placa4.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    btn_placa4.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    lid_romaneio_placa_ativa = btn_placa4.CommandArgument

                Else
                    pnl_placa4.BackImageUrl = "~/img/aba_nao_ativa.gif"
                    pnl_placa4.ForeColor = System.Drawing.Color.FromName("#6767CC")
                    btn_placa4.ForeColor = System.Drawing.Color.FromName("#6767CC")
                End If
            End If
            If btn_placa5.Visible = True Then
                'td_placa5.Attributes.Remove("class")
                If ViewState("placa_ativa") = 4 Then
                    pnl_placa5.BackImageUrl = "~/img/aba_ativa.gif"
                    pnl_placa5.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    btn_placa5.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    lid_romaneio_placa_ativa = btn_placa5.CommandArgument

                Else
                    pnl_placa5.BackImageUrl = "~/img/aba_nao_ativa.gif"
                    pnl_placa5.ForeColor = System.Drawing.Color.FromName("#6767CC")
                    btn_placa5.ForeColor = System.Drawing.Color.FromName("#6767CC")

                End If
            End If

            loadPlacaAtiva(lid_romaneio_placa_ativa)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Protected Sub btn_placa1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa1.Click
        ViewState("placa_ativa") = 0
        loadabasplacas()

    End Sub
    Private Sub loadPlacaAtiva(ByVal id_romaneio_placa As Int32)

        Try

            'Dim id_romaneio_placa As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_placa").ToString)
            Dim rplaca As New RomaneioPlaca(id_romaneio_placa)

            lbl_nr_total_volume_coletado.Text = rplaca.nr_total_volume_coletado
            lbl_nr_total_volume_rejeitado.Text = rplaca.nr_total_volume_rejeitado
            lbl_nr_volume_descarregado.Text = rplaca.nr_volume_descarregado
            If (rplaca.id_nr_silo1 > 0) Then
                lbl_id_silo1.Text = rplaca.nr_silo1.ToString & " - " & rplaca.nm_silo1.ToString
            End If
            If (rplaca.id_nr_silo2 > 0) Then
                lbl_id_silo2.Text = rplaca.nr_silo2.ToString & " - " & rplaca.nm_silo2.ToString
            End If
            If Not rplaca.dt_ini_descarga Is Nothing Then
                lbl_dt_ini_descarga.Text = Format(DateTime.Parse(rplaca.dt_ini_descarga), "dd/MM/yyyy HH:mm")
            End If
            If Not rplaca.dt_fim_descarga Is Nothing Then
                lbl_dt_fim_descarga.Text = Format(DateTime.Parse(rplaca.dt_fim_descarga), "dd/MM/yyyy HH:mm")
            End If
            If Not rplaca.dt_ini_CIP Is Nothing Then
                lbl_dt_ini_cip.Text = Format(DateTime.Parse(rplaca.dt_ini_descarga), "dd/MM/yyyy HH:mm")
            End If
            If Not rplaca.dt_fim_CIP Is Nothing Then
                lbl_dt_fim_cip.Text = Format(DateTime.Parse(rplaca.dt_fim_CIP), "dd/MM/yyyy HH:mm")
            End If

            'Alternativa para o 0 do framework pois o inteiro qdo sem valor sempre assume 0 porem 0 para este campo é um valor válido
            Dim dsrplaca As DataSet = rplaca.getRomaneioPlacasByFilters
            If dsrplaca.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(dsrplaca.Tables(0).Rows(0).Item("nr_ph_solucao")) Then
                    lbl_nr_ph_solucao.Text = dsrplaca.Tables(0).Rows(0).Item("nr_ph_solucao")
                End If
            End If

            loadgridlacre(id_romaneio_placa)

            loadgridcompartimento(rplaca.ds_placa)
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadgridlacre(ByVal id_romaneio_placa As Int32)

        Try

            Dim lacre As New RomaneioLacre

            lacre.id_romaneio_placa = id_romaneio_placa

            Dim dslacre As DataSet = lacre.getRomaneioLacresByFilters()

            If (dslacre.Tables(0).Rows.Count > 0) Then
                grdlacres.Visible = True
                grdlacres.DataSource = Helper.getDataView(dslacre.Tables(0), "nr_lacre_entrada asc")
                grdlacres.DataBind()
            Else
                Dim dr As DataRow = dslacre.Tables(0).NewRow()
                'dr("id_candidato_idioma") = -1
                dslacre.Tables(0).Rows.InsertAt(dr, 0)
                grdlacres.Visible = True
                grdlacres.DataSource = Helper.getDataView(dslacre.Tables(0), ViewState.Item("sortExpression"))
                grdlacres.DataBind()
                grdlacres.Rows(0).Cells.Clear()
                grdlacres.Rows(0).Cells.Add(New TableCell())
                grdlacres.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdlacres.Rows(0).Cells(0).Text = "Não existe nenhum lacre cadastrado!"
                grdlacres.Rows(0).Cells(0).ColumnSpan = 4
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadgridcompartimento(ByVal ds_placa As String)

        Try

            Dim rc As New Romaneio_Compartimento

            rc.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
            rc.ds_placa = ds_placa

            Dim dsrc As DataSet = rc.getRomaneio_CompartimentoByFilters()

            If (dsrc.Tables(0).Rows.Count > 0) Then
                gridCompartimento.Visible = True
                gridCompartimento.DataSource = Helper.getDataView(dsrc.Tables(0), "")
                gridCompartimento.DataBind()

            Else
                Dim dr As DataRow = dsrc.Tables(0).NewRow()
                'dr("id_candidato_idioma") = -1
                dsrc.Tables(0).Rows.InsertAt(dr, 0)
                gridCompartimento.Visible = True
                gridCompartimento.DataSource = Helper.getDataView(dsrc.Tables(0), ViewState.Item("sortExpression"))
                gridCompartimento.DataBind()
                gridCompartimento.Rows(0).Cells.Clear()
                gridCompartimento.Rows(0).Cells.Add(New TableCell())
                gridCompartimento.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridCompartimento.Rows(0).Cells(0).Text = "Não existe nenhum compartimento cadastrado!"
                gridCompartimento.Rows(0).Cells(0).ColumnSpan = 6
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Protected Sub btn_placa2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa2.Click
        ViewState("placa_ativa") = 1
        loadabasplacas()

    End Sub

    Protected Sub btn_placa3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa3.Click
        ViewState("placa_ativa") = 2
        loadabasplacas()

    End Sub

    Protected Sub btn_placa4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa4.Click
        ViewState("placa_ativa") = 3
        loadabasplacas()

    End Sub

    Protected Sub btn_placa5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_placa5.Click
        ViewState("placa_ativa") = 4
        loadabasplacas()

    End Sub

    Protected Sub gridCompartimento_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridCompartimento.RowCommand
        Select Case e.CommandName.ToString().ToLower()
            Case "anexar"
                Response.Redirect("frm_romaneio_analise_comp_anexos.aspx?id=" + ViewState.Item("id_romaneio").ToString() + "&tela=frm_romaneio_consulta_placa.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString)

            Case "analises"
                saveParams()

                Response.Redirect("frm_romaneio_consulta_analise.aspx?id_romaneio_compartimento=" + e.CommandArgument.ToString)
        End Select

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub gridCompartimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCompartimento.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try

                Dim lbl_st_reanalise As Label = CType(e.Row.FindControl("lbl_st_reanalise"), Label)
                Dim img_reanalise As Image = CType(e.Row.FindControl("img_reanalise"), Image)
                Dim lbl_st_registro As Label = CType(e.Row.FindControl("lbl_st_registro"), Label)


                'Se o romaneio compartimento é reanalise
                If lbl_st_reanalise.Text.Trim = "S" Then
                    img_reanalise.ImageUrl = "~/img/ico_chk_true.gif"
                Else
                    img_reanalise.ImageUrl = "~/img/ico_chk_false.gif"
                End If



            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub
    Private Sub loadParams()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("frm_rconsplaca", "id_romaneio").Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("frm_rconsplaca", "id_romaneio")
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If

        If Not (customPage.getFilterValue("frm_rconsplaca", "placa_ativa").Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("placa_ativa") = customPage.getFilterValue("frm_rconsplaca", "placa_ativa")
        Else
            ViewState.Item("placa_ativa") = 0
        End If
        If Not (customPage.getFilterValue("frm_rconsplaca", "tela").Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("telachamadora") = customPage.getFilterValue("frm_rconsplaca", "tela")
        Else
            ViewState.Item("telachamadora") = String.Empty
        End If
        If Not (customPage.getFilterValue("frm_rconsplaca", "titulo").Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("titulo") = customPage.getFilterValue("frm_rconsplaca", "titulo")
            lbl_titulo.Text = ViewState.Item("titulo") & " -  Consulta de Placas/Compartimentos"
        Else
            ViewState.Item("titulo") = String.Empty
        End If

        If (hasFilters) Then

            customPage.clearFilters("frm_rconsplaca")
            loadData()
        End If

    End Sub
    Private Sub saveParams()

        Try

            customPage.setFilter("frm_rconsplaca", "id_romaneio", ViewState.Item("id_romaneio").ToString)
            customPage.setFilter("frm_rconsplaca", "placa_ativa", ViewState.Item("placa_ativa").ToString)
            customPage.setFilter("frm_rconsplaca", "titulo", ViewState.Item("titulo").ToString)
            customPage.setFilter("frm_rconsplaca", "tela", ViewState.Item("telachamadora").ToString)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click

        If ViewState.Item("telachamadora").Equals(String.Empty) Then
            Response.Redirect("frm_romaneio_consulta.aspx")
        Else
            Response.Redirect(ViewState.Item("telachamadora").ToString)
        End If


    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        If ViewState.Item("telachamadora").Equals(String.Empty) Then
            Response.Redirect("frm_romaneio_consulta.aspx")
        Else
            Response.Redirect(ViewState.Item("telachamadora").ToString)
        End If

    End Sub
End Class
