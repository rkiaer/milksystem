Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_curvaabc_overview_qualidade_excel

    Inherits System.Web.UI.Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Dim lbgridcomlinhas_CBT As Boolean = False
            Dim lbgridcomlinhas_CCS As Boolean = False
            Dim lbgridcomlinhas_Prot As Boolean = False
            Dim lbgridcomlinhas_MG As Boolean = False


            If (Not Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            Else
                ViewState.Item("id_estabelecimento") = String.Empty
            End If

            If (Not Request("txt_dt_referencia") Is Nothing) Then
                ViewState.Item("txt_dt_referencia") = Request("txt_dt_referencia")
            Else
                ViewState.Item("txt_dt_referencia") = String.Empty
            End If

            If (Not Request("id_grupo") Is Nothing) Then
                ViewState.Item("id_grupo") = Request("id_grupo")
            Else
                ViewState.Item("id_grupo") = String.Empty
            End If

            Dim analiseesalq As New AnaliseEsalq

            analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_referencia")
            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            Else
                analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            End If
            analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)

            Dim dsComplienceVolumeTotal As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotal()

            ViewState.Item("nr_volume_total") = 0   ' Total do Volume da referencia (COMPL e NCOMPL)
            If dsComplienceVolumeTotal.Tables(0).Rows.Count() > 0 Then
                ViewState.Item("nr_volume_total") = dsComplienceVolumeTotal.Tables(0).Rows(0).Item("nr_volume_total")   ' Total do Volume da referencia (COMPL e NCOMPL)
            End If

            Dim dsOverviewSinteticoCBT As DataSet = analiseesalq.getCurvaAbcOverviewCBTSintetico()

            If (dsOverviewSinteticoCBT.Tables(0).Rows.Count > 0) Then
                gridCBT.Visible = True
                gridCBT.DataSource = Helper.getDataView(dsOverviewSinteticoCBT.Tables(0), "")
                gridCBT.AllowPaging = False
                gridCBT.DataBind()
                lbgridcomlinhas_CBT = True
            End If

            Dim dsOverviewSinteticoCCS As DataSet = analiseesalq.getCurvaAbcOverviewCCSSintetico()

            If (dsOverviewSinteticoCCS.Tables(0).Rows.Count > 0) Then
                gridCCS.Visible = True
                gridCCS.DataSource = Helper.getDataView(dsOverviewSinteticoCCS.Tables(0), "")
                gridCCS.AllowPaging = False
                gridCCS.DataBind()
                lbgridcomlinhas_CCS = True

            End If

            Dim dsOverviewSinteticoProteina As DataSet = analiseesalq.getCurvaAbcOverviewProteinaSintetico()

            If (dsOverviewSinteticoProteina.Tables(0).Rows.Count > 0) Then
                gridProteina.Visible = True
                gridProteina.DataSource = Helper.getDataView(dsOverviewSinteticoProteina.Tables(0), "")
                gridProteina.AllowPaging = False
                gridProteina.DataBind()
                lbgridcomlinhas_Prot = True

            End If

            Dim dsOverviewSinteticoGordura As DataSet = analiseesalq.getCurvaAbcOverviewGorduraSintetico()

            If (dsOverviewSinteticoGordura.Tables(0).Rows.Count > 0) Then
                gridGordura.Visible = True
                gridGordura.DataSource = Helper.getDataView(dsOverviewSinteticoGordura.Tables(0), "")
                gridGordura.AllowPaging = False
                gridGordura.DataBind()
                lbgridcomlinhas_MG = True

            End If

            If gridCBT.Rows.Count.ToString + 1 < 65536 Then
                If lbgridcomlinhas_CBT = True OrElse lbgridcomlinhas_CCS = True OrElse lbgridcomlinhas_MG = True OrElse lbgridcomlinhas_Prot = True Then
                    Dim tw As New StringWriter()
                    Dim hw As New System.Web.UI.HtmlTextWriter(tw)
                    Dim frm As HtmlForm = New HtmlForm()
                    Response.ContentType = "application/vnd.ms-excel"
                    Response.AddHeader("content-disposition", "attachment;filename=" & "CurvaABCOverviewQuality" & ".xls")
                    Response.Charset = ""
                    EnableViewState = False
                    Controls.Add(frm)
                    If lbgridcomlinhas_CBT = True Then
                        frm.Controls.Add(gridCBT)
                    End If
                    If lbgridcomlinhas_CCS = True Then
                        frm.Controls.Add(gridCCS)
                    End If
                    If lbgridcomlinhas_Prot = True Then
                        frm.Controls.Add(gridProteina)
                    End If
                    If lbgridcomlinhas_MG = True Then
                        frm.Controls.Add(gridGordura)
                    End If
                    frm.RenderControl(hw)
                    Response.Write(tw.ToString())
                    Response.End()
                Else

                    messageControl.Alert("Não há linhas a serem exportadas!")
                End If


            Else

                messageControl.Alert(" Planilha possui muitas linhas, não é possível exportar para o Excel")

            End If

        Catch ex As Exception

            messageControl.Alert(ex.Message)
        End Try

    End Sub
 

    Protected Sub gridCBT_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCBT.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_faixa_ini As Label = CType(e.Row.FindControl("lbl_faixa_ini"), Label)
            Dim lbl_faixa_fim As Label = CType(e.Row.FindControl("lbl_faixa_fim"), Label)
            Dim lbl_geral_mensal As Label = CType(e.Row.FindControl("lbl_geral_mensal"), Label)
            Dim lbl_geral_trimestral As Label = CType(e.Row.FindControl("lbl_geral_trimestral"), Label)
            Dim lbl_geral_com_educampo As Label = CType(e.Row.FindControl("lbl_geral_com_educampo"), Label)
            Dim lbl_geral_sem_educampo As Label = CType(e.Row.FindControl("lbl_geral_sem_educampo"), Label)
            Dim lbl_geral_com_comquali As Label = CType(e.Row.FindControl("lbl_geral_com_comquali"), Label)
            Dim lbl_geral_sem_comquali As Label = CType(e.Row.FindControl("lbl_geral_sem_comquali"), Label)

            If ViewState.Item("nr_volume_total") > 0 Then

                '====================
                ' GERAL MENSAL
                '====================
                ViewState.Item("nr_volume_geral_mensal_faixa") = lbl_geral_mensal.Text  ' 14/08/2017 - chamado 2563
                lbl_geral_mensal.Text = FormatNumber((lbl_geral_mensal.Text / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"

                '====================
                ' GERAL TRIMESTRAL
                '====================
                Dim analiseesalq As New AnaliseEsalq
                analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_referencia")
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                End If
                analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                analiseesalq.id_conta_teor = "252"  ' conta 0092 teor CBT trimestral
                analiseesalq.nr_faixa_ini = CDec(lbl_faixa_ini.Text)
                analiseesalq.nr_faixa_fim = CDec(lbl_faixa_fim.Text)
                Dim dsVolumeTeor As DataSet = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixa()
                lbl_geral_trimestral.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MESAL COM EDUCAMPO
                '====================
                analiseesalq.id_conta_teor = "264"  ' conta 0092 teor CBT mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComEducampo()
                'lbl_geral_com_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                lbl_geral_com_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_geral_mensal_faixa")) * 100, 2).ToString & "%"   ' 14/08/2017 - chamado 2563

                '====================
                ' MESAL SEM EDUCAMPO
                '====================
                analiseesalq.id_conta_teor = "264"  ' conta 0092 teor CBT mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemEducampo()
                'lbl_geral_sem_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                lbl_geral_sem_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_geral_mensal_faixa")) * 100, 2).ToString & "%"    ' 14/08/2017 - chamado 2563

                '====================
                ' MESAL COM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "264"  ' conta 0092 teor CBT mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComComquali()
                'lbl_geral_com_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                lbl_geral_com_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_geral_mensal_faixa")) * 100, 2).ToString & "%"   ' 14/08/2017 - chamado 2563

                '====================
                ' MESAL SEM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "264"  ' conta 0092 teor CBT mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemComquali()
                'lbl_geral_sem_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                lbl_geral_sem_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_geral_mensal_faixa")) * 100, 2).ToString & "%"   ' 14/08/2017 - chamado 2563

            End If

        End If
    End Sub

    Protected Sub gridCCS_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCCS.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_faixa_ini As Label = CType(e.Row.FindControl("lbl_faixa_ini"), Label)
            Dim lbl_faixa_fim As Label = CType(e.Row.FindControl("lbl_faixa_fim"), Label)
            Dim lbl_geral_mensal As Label = CType(e.Row.FindControl("lbl_geral_mensal"), Label)
            Dim lbl_geral_trimestral As Label = CType(e.Row.FindControl("lbl_geral_trimestral"), Label)
            Dim lbl_geral_com_educampo As Label = CType(e.Row.FindControl("lbl_geral_com_educampo"), Label)
            Dim lbl_geral_sem_educampo As Label = CType(e.Row.FindControl("lbl_geral_sem_educampo"), Label)
            Dim lbl_geral_com_comquali As Label = CType(e.Row.FindControl("lbl_geral_com_comquali"), Label)
            Dim lbl_geral_sem_comquali As Label = CType(e.Row.FindControl("lbl_geral_sem_comquali"), Label)

            If ViewState.Item("nr_volume_total") > 0 Then

                '====================
                ' GERAL MENSAL
                '====================
                lbl_geral_mensal.Text = FormatNumber((lbl_geral_mensal.Text / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"

                '====================
                ' GERAL TRIMESTRAL
                '====================
                Dim analiseesalq As New AnaliseEsalq
                analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_referencia")
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                End If
                analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                analiseesalq.id_conta_teor = "253"  ' conta 0092 teor CCS trimestral
                analiseesalq.nr_faixa_ini = CDec(lbl_faixa_ini.Text)
                analiseesalq.nr_faixa_fim = CDec(lbl_faixa_fim.Text)
                Dim dsVolumeTeor As DataSet = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixa()
                lbl_geral_trimestral.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MESAL COM EDUCAMPO
                '====================
                analiseesalq.id_conta_teor = "265"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComEducampo()
                lbl_geral_com_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MESAL SEM EDUCAMPO
                '====================
                analiseesalq.id_conta_teor = "265"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemEducampo()
                lbl_geral_sem_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MESAL COM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "265"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComComquali()
                lbl_geral_com_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MESAL SEM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "265"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemComquali()
                lbl_geral_sem_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

            End If

        End If

    End Sub

    Protected Sub gridProteina_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridProteina.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_faixa_ini As Label = CType(e.Row.FindControl("lbl_faixa_ini"), Label)
            Dim lbl_faixa_fim As Label = CType(e.Row.FindControl("lbl_faixa_fim"), Label)
            Dim lbl_geral_mensal As Label = CType(e.Row.FindControl("lbl_geral_mensal"), Label)
            Dim lbl_geral_trimestral As Label = CType(e.Row.FindControl("lbl_geral_trimestral"), Label)
            Dim lbl_geral_com_educampo As Label = CType(e.Row.FindControl("lbl_geral_com_educampo"), Label)
            Dim lbl_geral_sem_educampo As Label = CType(e.Row.FindControl("lbl_geral_sem_educampo"), Label)
            Dim lbl_geral_com_comquali As Label = CType(e.Row.FindControl("lbl_geral_com_comquali"), Label)
            Dim lbl_geral_sem_comquali As Label = CType(e.Row.FindControl("lbl_geral_sem_comquali"), Label)

            If ViewState.Item("nr_volume_total") > 0 Then

                '====================
                ' GERAL MENSAL
                '====================
                lbl_geral_mensal.Text = FormatNumber((lbl_geral_mensal.Text / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"

                '====================
                ' GERAL TRIMESTRAL (não tem para proteína)
                ''====================
                'Dim analiseesalq As New AnaliseEsalq
                'analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_referencia")
                'analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                'If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                '    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                'Else
                '    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                'End If
                'analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                'analiseesalq.id_conta_teor = "253"  ' conta 0092 teor Proteina trimestral
                'analiseesalq.nr_faixa_ini = CDec(lbl_faixa_ini.Text)
                'analiseesalq.nr_faixa_fim = CDec(lbl_faixa_fim.Text)
                'Dim dsVolumeTeor As DataSet = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixa()
                lbl_geral_trimestral.Text = "-"  ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL COM EDUCAMPO
                '====================
                Dim analiseesalq As New AnaliseEsalq
                analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_referencia")
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                End If
                analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                analiseesalq.id_conta_teor = "251"  ' conta 0092 teor Proteina mensal
                analiseesalq.nr_faixa_ini = CDec(lbl_faixa_ini.Text)
                analiseesalq.nr_faixa_fim = CDec(lbl_faixa_fim.Text)
                Dim dsVolumeTeor As DataSet = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComEducampo()
                lbl_geral_com_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL SEM EDUCAMPO
                '====================
                analiseesalq.id_conta_teor = "251"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemEducampo()
                lbl_geral_sem_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL COM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "251"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComComquali()
                lbl_geral_com_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL SEM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "251"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemComquali()
                lbl_geral_sem_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

            End If

        End If

    End Sub

    Protected Sub gridGordura_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridGordura.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_faixa_ini As Label = CType(e.Row.FindControl("lbl_faixa_ini"), Label)
            Dim lbl_faixa_fim As Label = CType(e.Row.FindControl("lbl_faixa_fim"), Label)
            Dim lbl_geral_mensal As Label = CType(e.Row.FindControl("lbl_geral_mensal"), Label)
            Dim lbl_geral_trimestral As Label = CType(e.Row.FindControl("lbl_geral_trimestral"), Label)
            Dim lbl_geral_com_educampo As Label = CType(e.Row.FindControl("lbl_geral_com_educampo"), Label)
            Dim lbl_geral_sem_educampo As Label = CType(e.Row.FindControl("lbl_geral_sem_educampo"), Label)
            Dim lbl_geral_com_comquali As Label = CType(e.Row.FindControl("lbl_geral_com_comquali"), Label)
            Dim lbl_geral_sem_comquali As Label = CType(e.Row.FindControl("lbl_geral_sem_comquali"), Label)

            If ViewState.Item("nr_volume_total") > 0 Then

                '====================
                ' GERAL MENSAL
                '====================
                lbl_geral_mensal.Text = FormatNumber((lbl_geral_mensal.Text / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"

                '====================
                ' GERAL TRIMESTRAL (não tem teor trimestral para gordura)
                ''====================
                lbl_geral_trimestral.Text = "-"

                '====================
                ' MENSAL COM EDUCAMPO
                '====================
                Dim analiseesalq As New AnaliseEsalq
                analiseesalq.dt_referencia = "01/" & ViewState.Item("txt_dt_referencia")
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
                Else
                    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
                End If
                analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)
                analiseesalq.id_conta_teor = "156"  ' conta 0092 teor Gordura mensal
                analiseesalq.nr_faixa_ini = CDec(lbl_faixa_ini.Text)
                analiseesalq.nr_faixa_fim = CDec(lbl_faixa_fim.Text)
                Dim dsVolumeTeor As DataSet = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComEducampo()
                lbl_geral_com_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL SEM EDUCAMPO
                '====================
                analiseesalq.id_conta_teor = "156"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemEducampo()
                lbl_geral_sem_educampo.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL COM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "156"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaComComquali()
                lbl_geral_com_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

                '====================
                ' MENSAL SEM COMQUALI
                '====================
                analiseesalq.id_conta_teor = "156"  ' conta 0092 teor CCS mensal
                dsVolumeTeor = analiseesalq.getCurvaAbcOverviewVolumeTeorPorFaixaSemComquali()
                lbl_geral_sem_comquali.Text = FormatNumber((dsVolumeTeor.Tables(0).Rows(0).Item("nr_volume_faixa") / ViewState.Item("nr_volume_total")) * 100, 2).ToString & "%"   ' 13/02/2017 - Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null

            End If

        End If

    End Sub
End Class
