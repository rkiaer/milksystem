Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_gestao_qualidade_dados_epl

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_gestao_qualidade_dados_epl.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 212
                usuariolog.ds_nm_processo = "Base de Dados EPLs"
                usuariolog.insertUsuarioLog()
            End If

            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim tecnico As New Tecnico
            Dim codigoesalq As New CodigoEsalq

            estabelecimento.id_situacao = 1
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            tecnico.id_situacao = 1
            tecnico.st_categoria = "D" 'tecnico danone 
            cbo_tecnico.DataSource = Helper.getDataView(tecnico.getTecnicoByFilters.Tables(0), "nm_abreviado")
            cbo_tecnico.DataTextField = "ds_tecnico"
            cbo_tecnico.DataValueField = "id_tecnico"
            cbo_tecnico.DataBind()
            cbo_tecnico.Items.Insert(0, New ListItem("[Selecione]", 0))

            If (Not Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            Else
                ViewState.Item("id_estabelecimento") = String.Empty
            End If

            If (Not Request("dt_referencia") Is Nothing) Then
                ViewState.Item("dt_referencia") = Request("dt_referencia")
            End If

            If (Not Request("ano") Is Nothing) Then
                ViewState.Item("ano") = Request("ano")
            End If
            ViewState.Item("sortExpression") = ""
            ViewState.Item("ds_tecnico") = String.Empty

            If ViewState.Item("id_estabelecimento").Equals(String.Empty) Then
                cbo_tecnico.Enabled = False
                messageControl.Alert("Problemas na passagem de parâmetros! Contate o administrador ou tente novamente mais tarde.")
            Else
                lbl_ano.Text = ViewState.Item("ano").ToString
                cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString
                loadData()
            End If


            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadData()

        Try
            Dim dadosEPL As New AnaliseEsalq

            dadosEPL.dt_referencia_ini = "01/01/" & (CInt(ViewState.Item("ano").ToString) - 1).ToString
            dadosEPL.dt_referencia_fim = "31/12/" & ViewState.Item("ano").ToString
            dadosEPL.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            dadosEPL.id_tecnico = 0 'dados do DAL
            dadosEPL.id_tecnico_comquali = 0
            dadosEPL.id_tecnico_educampo = 0

            Dim dsDadosEPLMG As DataSet = dadosEPL.getGestaoDadosEPLGordura
            Dim dsDadosEPLProt As DataSet = dadosEPL.getGestaoDadosEPLProteina
            Dim dsDadosEPLCCS As DataSet = dadosEPL.getGestaoDadosEPLCCS

            If (dsDadosEPLMG.Tables(0).Rows.Count > 0) Then

                gridGordura.Visible = True
                gridGordura.DataSource = Helper.getDataView(dsDadosEPLMG.Tables(0), "")
                gridGordura.DataBind()

                gridProteina.Visible = True
                gridProteina.DataSource = Helper.getDataView(dsDadosEPLProt.Tables(0), "")
                gridProteina.DataBind()

                gridCCS.Visible = True
                gridCCS.DataSource = Helper.getDataView(dsDadosEPLCCS.Tables(0), "")
                gridCCS.DataBind()

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadDataTecnico()

        Try
            Dim dadosEPL As New AnaliseEsalq

            dadosEPL.dt_referencia_ini = "01/01/" & (CInt(ViewState.Item("ano").ToString) - 1).ToString
            dadosEPL.dt_referencia_fim = "31/12/" & ViewState.Item("ano").ToString
            dadosEPL.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            dadosEPL.id_tecnico = Convert.ToInt32(ViewState.Item("id_tecnico").ToString) 'dados do DAL
            dadosEPL.id_tecnico_comquali = 0
            dadosEPL.id_tecnico_educampo = 0

            Dim dsDadosEPLMG As DataSet = dadosEPL.getGestaoDadosEPLGordura
            Dim dsDadosEPLProt As DataSet = dadosEPL.getGestaoDadosEPLProteina
            Dim dsDadosEPLCCS As DataSet = dadosEPL.getGestaoDadosEPLCCS

            If (dsDadosEPLMG.Tables(0).Rows.Count > 0) Then

                gridEPLGordura.Visible = True
                gridEPLGordura.DataSource = Helper.getDataView(dsDadosEPLMG.Tables(0), "")
                gridEPLGordura.DataBind()

                gridEPLProteina.Visible = True
                gridEPLProteina.DataSource = Helper.getDataView(dsDadosEPLProt.Tables(0), "")
                gridEPLProteina.DataBind()

                gridEPLCCS.Visible = True
                gridEPLCCS.DataSource = Helper.getDataView(dsDadosEPLCCS.Tables(0), "")
                gridEPLCCS.DataBind()

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        'saveFilters()
        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 212
        usuariolog.ds_nm_processo = "Base de Dados EPLs"
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        Response.Redirect("frm_gestao_qualidade_dados_epl_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&ano=" + ViewState.Item("ano").ToString() + "&id_tecnico=" + ViewState.Item("id_tecnico").ToString() + "&ds_tecnico=" + ViewState.Item("ds_tecnico").ToString())

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

    Protected Sub cbo_tecnico_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tecnico.SelectedIndexChanged
        Try
            If Not cbo_tecnico.SelectedValue.Equals("0") Then
                'monta os grids do tecnico
                lbl_mg_tecnico.CssClass = "borda"
                lbl_mg_tecnico.Text = "Técnico Gordura"
                tr_tecnico_gordura_grid.Visible = True
                lbl_prot_tecnico.CssClass = "borda"
                lbl_prot_tecnico.Text = "Técnico Proteína"
                tr_tecnico_proteina_grid.Visible = True
                lbl_ccs_tecnico.CssClass = "borda"
                lbl_ccs_tecnico.Text = "Técnico CCS"
                tr_tecnico_ccs_grid.Visible = True

                ViewState.Item("id_tecnico") = cbo_tecnico.SelectedValue
                ViewState.Item("ds_tecnico") = cbo_tecnico.SelectedItem.Text

                loadDataTecnico()
            Else
                ViewState.Item("id_tecnico") = 0
                ViewState.Item("ds_tecnico") = String.Empty
                lbl_mg_tecnico.CssClass = String.Empty
                lbl_mg_tecnico.Text = String.Empty
                tr_tecnico_gordura_grid.Visible = False
                lbl_prot_tecnico.Text = String.Empty
                lbl_prot_tecnico.CssClass = String.Empty
                tr_tecnico_proteina_grid.Visible = False
                lbl_ccs_tecnico.CssClass = String.Empty
                lbl_ccs_tecnico.Text = String.Empty
                tr_tecnico_ccs_grid.Visible = False

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridGordura_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridGordura.RowDataBound
        If (e.Row.RowType = DataControlRowType.Header) Then
            Dim lbl_tecnico As Label = CType(e.Row.FindControl("lbl_tecnico_mg"), Label)
            Dim lsaux As String
            Dim lpos As Integer

            'lsaux = ViewState.Item("ds_tecnico").ToString.Trim
            'lpos = InStr(1, lsaux, "-")
            'If lpos > 0 Then
            '    lsaux = Mid(lsaux, lpos + 2)
            '    lsaux = Left(lsaux, InStr(1, lsaux, "-") - 1).ToString

            '    lbl_tecnico.Text = lsaux
            'End If
        End If


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
        If (e.Row.RowType = DataControlRowType.Header) Then
            Dim lbl_tecnico As Label = CType(e.Row.FindControl("lbl_tecnico_prot"), Label)
            Dim lsaux As String
            Dim lpos As Integer

            'lsaux = ViewState.Item("ds_tecnico").ToString.Trim
            'lpos = InStr(1, lsaux, "-")
            'If lpos > 0 Then
            '    lsaux = Mid(lsaux, lpos + 2)
            '    lsaux = Left(lsaux, InStr(1, lsaux, "-") - 1).ToString

            '    lbl_tecnico.Text = lsaux
            'End If
        End If


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
        If (e.Row.RowType = DataControlRowType.Header) Then
            Dim lbl_tecnico As Label = CType(e.Row.FindControl("lbl_tecnico_ccs"), Label)
            Dim lsaux As String
            Dim lpos As Integer

            'lsaux = ViewState.Item("ds_tecnico").ToString.Trim
            'lpos = InStr(1, lsaux, "-")
            'If lpos > 0 Then
            '    lsaux = Mid(lsaux, lpos + 2)
            '    lsaux = Left(lsaux, InStr(1, lsaux, "-") - 1).ToString

            '    lbl_tecnico.Text = lsaux
            'End If
        End If


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

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_gestao_qualidade_home.aspx")

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_gestao_qualidade_home.aspx")

    End Sub
End Class
