Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_gestao_qualidade_dados_epl_excel
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If gridGordura.Rows.Count.ToString + 1 < 65536 Then

            Try

                Dim btecnico As Boolean = False
                If (Not Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                Else
                    ViewState.Item("id_estabelecimento") = String.Empty
                End If
                If (Not Request("ano") Is Nothing) Then
                    ViewState.Item("ano") = Request("ano")
                Else
                    ViewState.Item("ano") = String.Empty
                End If
                If (Not Request("id_tecnico") Is Nothing) Then
                    ViewState.Item("id_tecnico") = Request("id_tecnico")
                Else
                    ViewState.Item("id_tecnico") = String.Empty
                End If

                If (Not Request("ds_tecnico") Is Nothing) Then
                    ViewState.Item("ds_tecnico") = Request("ds_tecnico")
                Else
                    ViewState.Item("ds_tecnico") = String.Empty
                End If

                Dim dadosEPL As New AnaliseEsalq

                dadosEPL.dt_referencia_ini = "01/01/" & (CInt(ViewState.Item("ano").ToString) - 1).ToString
                dadosEPL.dt_referencia_fim = "31/12/" & ViewState.Item("ano").ToString
                dadosEPL.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

                dadosEPL.id_tecnico = 0 'dados do DAL
                dadosEPL.id_tecnico_comquali = 0
                dadosEPL.id_tecnico_educampo = 0

                Dim dsDadosMG As DataSet = dadosEPL.getGestaoDadosEPLGordura
                Dim dsDadosProt As DataSet = dadosEPL.getGestaoDadosEPLProteina
                Dim dsDadosCCS As DataSet = dadosEPL.getGestaoDadosEPLCCS

                If (dsDadosMG.Tables(0).Rows.Count > 0) Then

                    gridGordura.Visible = True
                    gridGordura.DataSource = Helper.getDataView(dsDadosMG.Tables(0), "")
                    gridGordura.AllowPaging = False
                    gridGordura.DataBind()

                    gridProteina.Visible = True
                    gridProteina.DataSource = Helper.getDataView(dsDadosProt.Tables(0), "")
                    gridProteina.AllowPaging = False
                    gridProteina.DataBind()

                    gridCCS.Visible = True
                    gridCCS.DataSource = Helper.getDataView(dsDadosCCS.Tables(0), "")
                    gridCCS.AllowPaging = False
                    gridCCS.DataBind()

                    If Not ViewState.Item("id_tecnico").Equals(String.Empty) Then

                        dadosEPL.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString) 'dados do DAL
                        dadosEPL.id_tecnico_comquali = 0
                        dadosEPL.id_tecnico_educampo = 0

                        Dim dsDadosEPLMG As DataSet = dadosEPL.getGestaoDadosEPLGordura
                        Dim dsDadosEPLProt As DataSet = dadosEPL.getGestaoDadosEPLProteina
                        Dim dsDadosEPLCCS As DataSet = dadosEPL.getGestaoDadosEPLCCS

                        If (dsDadosEPLMG.Tables(0).Rows.Count > 0) Then

                            btecnico = True
                            gridEPLGordura.Visible = True
                            gridEPLGordura.DataSource = Helper.getDataView(dsDadosEPLMG.Tables(0), "")
                            gridEPLGordura.AllowPaging = False
                            gridEPLGordura.DataBind()

                            gridEPLProteina.Visible = True
                            gridEPLProteina.DataSource = Helper.getDataView(dsDadosEPLProt.Tables(0), "")
                            gridEPLProteina.AllowPaging = False
                            gridEPLProteina.DataBind()

                            gridEPLCCS.Visible = True
                            gridEPLCCS.DataSource = Helper.getDataView(dsDadosEPLCCS.Tables(0), "")
                            gridEPLCCS.AllowPaging = False
                            gridEPLCCS.DataBind()
                        End If
                    End If

                End If

                If gridGordura.Rows.Count > 0 Then
                    Dim tw As New StringWriter()
                    Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                    Dim frm As HtmlForm = New HtmlForm()
                    Response.ContentType = "application/vnd.ms-excel"
                    Response.AddHeader("content-disposition", "attachment;filename=" & "GestaoQualidade_BaseDadosEPLs_" & ViewState.Item("ano").ToString & ".xls")
                    Response.Charset = ""
                    EnableViewState = False
                    Controls.Add(frm)
                    frm.Controls.Add(tb_mg)
                    frm.Controls.Add(gridGordura)
                    frm.Controls.Add(tb_prot)
                    frm.Controls.Add(gridProteina)
                    frm.Controls.Add(tb_ccs)
                    frm.Controls.Add(gridCCS)

                    If btecnico = True Then
                        frm.Controls.Add(tb_mg_tecnico)
                        frm.Controls.Add(gridEPLGordura)
                        frm.Controls.Add(tb_prot_tecnico)
                        frm.Controls.Add(gridEPLProteina)
                        frm.Controls.Add(tb_ccs_tecnico)
                        frm.Controls.Add(gridEPLCCS)
                    End If

                    frm.RenderControl(hw)
                    Response.Write(tw.ToString())
                    Response.End()
                Else

                    messageControl.Alert("Não há linhas a serem exportadas!")
                End If



            Catch ex As Exception

                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub gridGordura_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridGordura.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano_mg"), Label)
            Dim lbl_nr_seq As Label = CType(e.Row.FindControl("lbl_nr_seq_mg"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan_mg"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev_mg"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar_mg"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr_mg"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai_mg"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun_mg"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul_mg"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago_mg"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set_mg"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out_mg"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov_mg"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez_mg"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_mg"), Label)  ' 22/08/2017 chamado 2565

            Select Case CInt(lbl_nr_seq.Text.Trim)
                Case 1, 2, 3, 4
                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 2).ToString
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 2).ToString
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 2).ToString
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 2).ToString
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 2).ToString
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 2).ToString
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 2).ToString
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 2).ToString
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 2).ToString
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 2).ToString
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 2).ToString
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 2).ToString
                    End If
                    If Not lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 2).ToString
                    End If
                Case 6, 7
                    If lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = String.Empty
                        lbl_jan.Text = String.Empty
                        lbl_fev.Text = String.Empty
                        lbl_mar.Text = String.Empty
                        lbl_abr.Text = String.Empty
                        lbl_mai.Text = String.Empty
                        lbl_jun.Text = String.Empty
                        lbl_jul.Text = String.Empty
                        lbl_ago.Text = String.Empty
                        lbl_set.Text = String.Empty
                        lbl_out.Text = String.Empty
                        lbl_nov.Text = String.Empty
                        lbl_dez.Text = String.Empty
                    Else
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 2).ToString

                        If Not lbl_jan.Text.Equals(String.Empty) Then
                            lbl_jan.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_fev.Text.Equals(String.Empty) Then
                            lbl_fev.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_mar.Text.Equals(String.Empty) Then
                            lbl_mar.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_abr.Text.Equals(String.Empty) Then
                            lbl_abr.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_mai.Text.Equals(String.Empty) Then
                            lbl_mai.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_jun.Text.Equals(String.Empty) Then
                            lbl_jun.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_jul.Text.Equals(String.Empty) Then
                            lbl_jul.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_ago.Text.Equals(String.Empty) Then
                            lbl_ago.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_set.Text.Equals(String.Empty) Then
                            lbl_set.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_out.Text.Equals(String.Empty) Then
                            lbl_out.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_nov.Text.Equals(String.Empty) Then
                            lbl_nov.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_dez.Text.Equals(String.Empty) Then
                            lbl_dez.Text = lbl_media_anual.Text
                        End If
                    End If

                Case 9, 10
                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 0).ToString
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 0).ToString
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 0).ToString
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 0).ToString
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 0).ToString
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 0).ToString
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 0).ToString
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 0).ToString
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 0).ToString
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 0).ToString
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 0).ToString
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 0).ToString
                    End If
                    lbl_media_anual.Text = String.Empty

            End Select


        End If

    End Sub

    Protected Sub gridProteina_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridProteina.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
      And e.Row.RowType <> DataControlRowType.Footer _
      And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano_prot"), Label)
            Dim lbl_nr_seq As Label = CType(e.Row.FindControl("lbl_nr_seq_prot"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan_prot"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev_prot"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar_prot"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr_prot"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai_prot"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun_prot"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul_prot"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago_prot"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set_prot"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out_prot"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov_prot"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez_prot"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_prot"), Label)

            Select Case CInt(lbl_nr_seq.Text.Trim)
                Case 1, 2, 3, 4
                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 2).ToString
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 2).ToString
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 2).ToString
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 2).ToString
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 2).ToString
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 2).ToString
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 2).ToString
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 2).ToString
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 2).ToString
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 2).ToString
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 2).ToString
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 2).ToString
                    End If
                    If Not lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 2).ToString
                    End If
                Case 6, 7
                    If lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = String.Empty
                        lbl_jan.Text = String.Empty
                        lbl_fev.Text = String.Empty
                        lbl_mar.Text = String.Empty
                        lbl_abr.Text = String.Empty
                        lbl_mai.Text = String.Empty
                        lbl_jun.Text = String.Empty
                        lbl_jul.Text = String.Empty
                        lbl_ago.Text = String.Empty
                        lbl_set.Text = String.Empty
                        lbl_out.Text = String.Empty
                        lbl_nov.Text = String.Empty
                        lbl_dez.Text = String.Empty
                    Else
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 2).ToString

                        If Not lbl_jan.Text.Equals(String.Empty) Then
                            lbl_jan.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_fev.Text.Equals(String.Empty) Then
                            lbl_fev.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_mar.Text.Equals(String.Empty) Then
                            lbl_mar.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_abr.Text.Equals(String.Empty) Then
                            lbl_abr.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_mai.Text.Equals(String.Empty) Then
                            lbl_mai.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_jun.Text.Equals(String.Empty) Then
                            lbl_jun.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_jul.Text.Equals(String.Empty) Then
                            lbl_jul.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_ago.Text.Equals(String.Empty) Then
                            lbl_ago.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_set.Text.Equals(String.Empty) Then
                            lbl_set.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_out.Text.Equals(String.Empty) Then
                            lbl_out.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_nov.Text.Equals(String.Empty) Then
                            lbl_nov.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_dez.Text.Equals(String.Empty) Then
                            lbl_dez.Text = lbl_media_anual.Text
                        End If
                    End If

            End Select


        End If

    End Sub

    Protected Sub gridCCS_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCCS.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano_ccs"), Label)
            Dim lbl_nr_seq As Label = CType(e.Row.FindControl("lbl_nr_seq_ccs"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan_ccs"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev_ccs"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar_ccs"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr_ccs"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai_ccs"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun_ccs"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul_ccs"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago_ccs"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set_ccs"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out_ccs"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov_ccs"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez_ccs"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_ccs"), Label)  ' 22/08/2017 chamado 2565

            Select Case CInt(lbl_nr_seq.Text.Trim)
                Case 1, 2, 3, 4
                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 0).ToString
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 0).ToString
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 0).ToString
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 0).ToString
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 0).ToString
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 0).ToString
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 0).ToString
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 0).ToString
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 0).ToString
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 0).ToString
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 0).ToString
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 0).ToString
                    End If
                    If Not lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 0).ToString
                    End If
                Case 6, 7
                    If lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = String.Empty
                        lbl_jan.Text = String.Empty
                        lbl_fev.Text = String.Empty
                        lbl_mar.Text = String.Empty
                        lbl_abr.Text = String.Empty
                        lbl_mai.Text = String.Empty
                        lbl_jun.Text = String.Empty
                        lbl_jul.Text = String.Empty
                        lbl_ago.Text = String.Empty
                        lbl_set.Text = String.Empty
                        lbl_out.Text = String.Empty
                        lbl_nov.Text = String.Empty
                        lbl_dez.Text = String.Empty
                    Else
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 0).ToString

                        If Not lbl_jan.Text.Equals(String.Empty) Then
                            lbl_jan.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_fev.Text.Equals(String.Empty) Then
                            lbl_fev.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_mar.Text.Equals(String.Empty) Then
                            lbl_mar.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_abr.Text.Equals(String.Empty) Then
                            lbl_abr.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_mai.Text.Equals(String.Empty) Then
                            lbl_mai.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_jun.Text.Equals(String.Empty) Then
                            lbl_jun.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_jul.Text.Equals(String.Empty) Then
                            lbl_jul.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_ago.Text.Equals(String.Empty) Then
                            lbl_ago.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_set.Text.Equals(String.Empty) Then
                            lbl_set.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_out.Text.Equals(String.Empty) Then
                            lbl_out.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_nov.Text.Equals(String.Empty) Then
                            lbl_nov.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_dez.Text.Equals(String.Empty) Then
                            lbl_dez.Text = lbl_media_anual.Text
                        End If
                    End If

                Case 8, 9, 10, 11
                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 0).ToString & "%"
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 0).ToString & "%"
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 0).ToString & "%"
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 0).ToString & "%"
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 0).ToString & "%"
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 0).ToString & "%"
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 0).ToString & "%"
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 0).ToString & "%"
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 0).ToString & "%"
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 0).ToString & "%"
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 0).ToString & "%"
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 0).ToString & "%"
                    End If
                    If Not lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 0).ToString & "%"
                    End If

            End Select


        End If

    End Sub

    Protected Sub gridEPLGordura_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridEPLGordura.RowDataBound
        If (e.Row.RowType = DataControlRowType.Header) Then
            Dim lbl_tecnico As Label = CType(e.Row.FindControl("lbl_tecnico_epl_mg"), Label)
            Dim lsaux As String
            Dim lpos As Integer

            lsaux = ViewState.Item("ds_tecnico").ToString.Trim
            lpos = InStr(1, lsaux, "-")
            If lpos > 0 Then
                lsaux = Mid(lsaux, lpos + 2)
                lsaux = Left(lsaux, InStr(1, lsaux, "-") - 1).ToString

                lbl_tecnico.Text = lsaux
            End If
        End If


        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano_epl_mg"), Label)
            Dim lbl_nr_seq As Label = CType(e.Row.FindControl("lbl_nr_seq_epl_mg"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan_epl_mg"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev_epl_mg"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar_epl_mg"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr_epl_mg"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai_epl_mg"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun_epl_mg"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul_epl_mg"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago_epl_mg"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set_epl_mg"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out_epl_mg"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov_epl_mg"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez_epl_mg"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_epl_mg"), Label)  ' 22/08/2017 chamado 2565

            Select Case CInt(lbl_nr_seq.Text.Trim)
                Case 1, 2, 3, 4
                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 2).ToString
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 2).ToString
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 2).ToString
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 2).ToString
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 2).ToString
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 2).ToString
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 2).ToString
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 2).ToString
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 2).ToString
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 2).ToString
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 2).ToString
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 2).ToString
                    End If
                    If Not lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 2).ToString
                    End If
                Case 6, 7
                    If lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = String.Empty
                        lbl_jan.Text = String.Empty
                        lbl_fev.Text = String.Empty
                        lbl_mar.Text = String.Empty
                        lbl_abr.Text = String.Empty
                        lbl_mai.Text = String.Empty
                        lbl_jun.Text = String.Empty
                        lbl_jul.Text = String.Empty
                        lbl_ago.Text = String.Empty
                        lbl_set.Text = String.Empty
                        lbl_out.Text = String.Empty
                        lbl_nov.Text = String.Empty
                        lbl_dez.Text = String.Empty
                    Else
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 2).ToString

                        If Not lbl_jan.Text.Equals(String.Empty) Then
                            lbl_jan.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_fev.Text.Equals(String.Empty) Then
                            lbl_fev.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_mar.Text.Equals(String.Empty) Then
                            lbl_mar.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_abr.Text.Equals(String.Empty) Then
                            lbl_abr.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_mai.Text.Equals(String.Empty) Then
                            lbl_mai.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_jun.Text.Equals(String.Empty) Then
                            lbl_jun.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_jul.Text.Equals(String.Empty) Then
                            lbl_jul.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_ago.Text.Equals(String.Empty) Then
                            lbl_ago.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_set.Text.Equals(String.Empty) Then
                            lbl_set.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_out.Text.Equals(String.Empty) Then
                            lbl_out.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_nov.Text.Equals(String.Empty) Then
                            lbl_nov.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_dez.Text.Equals(String.Empty) Then
                            lbl_dez.Text = lbl_media_anual.Text
                        End If
                    End If

                Case 9, 10
                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 0).ToString
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 0).ToString
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 0).ToString
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 0).ToString
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 0).ToString
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 0).ToString
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 0).ToString
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 0).ToString
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 0).ToString
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 0).ToString
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 0).ToString
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 0).ToString
                    End If
                    lbl_media_anual.Text = String.Empty

            End Select


        End If

    End Sub

    Protected Sub gridEPLProteina_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridEPLProteina.RowDataBound
        If (e.Row.RowType = DataControlRowType.Header) Then
            Dim lbl_tecnico As Label = CType(e.Row.FindControl("lbl_tecnico_epl_prot"), Label)
            Dim lsaux As String
            Dim lpos As Integer

            lsaux = ViewState.Item("ds_tecnico").ToString.Trim
            lpos = InStr(1, lsaux, "-")
            If lpos > 0 Then
                lsaux = Mid(lsaux, lpos + 2)
                lsaux = Left(lsaux, InStr(1, lsaux, "-") - 1).ToString

                lbl_tecnico.Text = lsaux
            End If
        End If


        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano_epl_prot"), Label)
            Dim lbl_nr_seq As Label = CType(e.Row.FindControl("lbl_nr_seq_epl_prot"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan_epl_prot"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev_epl_prot"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar_epl_prot"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr_epl_prot"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai_epl_prot"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun_epl_prot"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul_epl_prot"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago_epl_prot"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set_epl_prot"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out_epl_prot"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov_epl_prot"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez_epl_prot"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_epl_prot"), Label)

            Select Case CInt(lbl_nr_seq.Text.Trim)
                Case 1, 2, 3, 4
                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 2).ToString
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 2).ToString
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 2).ToString
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 2).ToString
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 2).ToString
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 2).ToString
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 2).ToString
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 2).ToString
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 2).ToString
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 2).ToString
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 2).ToString
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 2).ToString
                    End If
                    If Not lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 2).ToString
                    End If
                Case 6, 7
                    If lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = String.Empty
                        lbl_jan.Text = String.Empty
                        lbl_fev.Text = String.Empty
                        lbl_mar.Text = String.Empty
                        lbl_abr.Text = String.Empty
                        lbl_mai.Text = String.Empty
                        lbl_jun.Text = String.Empty
                        lbl_jul.Text = String.Empty
                        lbl_ago.Text = String.Empty
                        lbl_set.Text = String.Empty
                        lbl_out.Text = String.Empty
                        lbl_nov.Text = String.Empty
                        lbl_dez.Text = String.Empty
                    Else
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 2).ToString

                        If Not lbl_jan.Text.Equals(String.Empty) Then
                            lbl_jan.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_fev.Text.Equals(String.Empty) Then
                            lbl_fev.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_mar.Text.Equals(String.Empty) Then
                            lbl_mar.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_abr.Text.Equals(String.Empty) Then
                            lbl_abr.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_mai.Text.Equals(String.Empty) Then
                            lbl_mai.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_jun.Text.Equals(String.Empty) Then
                            lbl_jun.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_jul.Text.Equals(String.Empty) Then
                            lbl_jul.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_ago.Text.Equals(String.Empty) Then
                            lbl_ago.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_set.Text.Equals(String.Empty) Then
                            lbl_set.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_out.Text.Equals(String.Empty) Then
                            lbl_out.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_nov.Text.Equals(String.Empty) Then
                            lbl_nov.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_dez.Text.Equals(String.Empty) Then
                            lbl_dez.Text = lbl_media_anual.Text
                        End If
                    End If

            End Select


        End If


    End Sub

    Protected Sub gridEPLCCS_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridEPLCCS.RowDataBound
        If (e.Row.RowType = DataControlRowType.Header) Then
            Dim lbl_tecnico As Label = CType(e.Row.FindControl("lbl_tecnico_epl_ccs"), Label)
            Dim lsaux As String
            Dim lpos As Integer

            lsaux = ViewState.Item("ds_tecnico").ToString.Trim
            lpos = InStr(1, lsaux, "-")
            If lpos > 0 Then
                lsaux = Mid(lsaux, lpos + 2)
                lsaux = Left(lsaux, InStr(1, lsaux, "-") - 1).ToString

                lbl_tecnico.Text = lsaux
            End If
        End If


        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano_epl_ccs"), Label)
            Dim lbl_nr_seq As Label = CType(e.Row.FindControl("lbl_nr_seq_epl_ccs"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan_epl_ccs"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev_epl_ccs"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar_epl_ccs"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr_epl_ccs"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai_epl_ccs"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun_epl_ccs"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul_epl_ccs"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago_epl_ccs"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set_epl_ccs"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out_epl_ccs"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov_epl_ccs"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez_epl_ccs"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_epl_ccs"), Label)  ' 22/08/2017 chamado 2565

            Select Case CInt(lbl_nr_seq.Text.Trim)
                Case 1, 2, 3, 4
                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 0).ToString
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 0).ToString
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 0).ToString
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 0).ToString
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 0).ToString
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 0).ToString
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 0).ToString
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 0).ToString
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 0).ToString
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 0).ToString
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 0).ToString
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 0).ToString
                    End If
                    If Not lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 0).ToString
                    End If
                Case 6, 7
                    If lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = String.Empty
                        lbl_jan.Text = String.Empty
                        lbl_fev.Text = String.Empty
                        lbl_mar.Text = String.Empty
                        lbl_abr.Text = String.Empty
                        lbl_mai.Text = String.Empty
                        lbl_jun.Text = String.Empty
                        lbl_jul.Text = String.Empty
                        lbl_ago.Text = String.Empty
                        lbl_set.Text = String.Empty
                        lbl_out.Text = String.Empty
                        lbl_nov.Text = String.Empty
                        lbl_dez.Text = String.Empty
                    Else
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 0).ToString

                        If Not lbl_jan.Text.Equals(String.Empty) Then
                            lbl_jan.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_fev.Text.Equals(String.Empty) Then
                            lbl_fev.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_mar.Text.Equals(String.Empty) Then
                            lbl_mar.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_abr.Text.Equals(String.Empty) Then
                            lbl_abr.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_mai.Text.Equals(String.Empty) Then
                            lbl_mai.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_jun.Text.Equals(String.Empty) Then
                            lbl_jun.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_jul.Text.Equals(String.Empty) Then
                            lbl_jul.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_ago.Text.Equals(String.Empty) Then
                            lbl_ago.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_set.Text.Equals(String.Empty) Then
                            lbl_set.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_out.Text.Equals(String.Empty) Then
                            lbl_out.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_nov.Text.Equals(String.Empty) Then
                            lbl_nov.Text = lbl_media_anual.Text
                        End If
                        If Not lbl_dez.Text.Equals(String.Empty) Then
                            lbl_dez.Text = lbl_media_anual.Text
                        End If
                    End If

                Case 8, 9, 10, 11
                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 0).ToString & "%"
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 0).ToString & "%"
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 0).ToString & "%"
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 0).ToString & "%"
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 0).ToString & "%"
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 0).ToString & "%"
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 0).ToString & "%"
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 0).ToString & "%"
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 0).ToString & "%"
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 0).ToString & "%"
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 0).ToString & "%"
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 0).ToString & "%"
                    End If
                    If Not lbl_media_anual.Text.Equals(String.Empty) Then
                        lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 0).ToString & "%"
                    End If

            End Select


        End If

    End Sub
End Class
