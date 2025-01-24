Imports System.io
Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_curvaabc_kpi_qualidade_excel

    Inherits System.Web.UI.Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            If (Not Request("id_estabelecimento") Is Nothing) Then
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
            Else
                ViewState.Item("id_estabelecimento") = String.Empty
            End If
            If (Not Request("id_pessoa") Is Nothing) Then
                ViewState.Item("id_pessoa") = Request("id_pessoa")
            Else
                ViewState.Item("id_pessoa") = String.Empty
            End If
            If (Not Request("id_propriedade") Is Nothing) Then
                ViewState.Item("id_propriedade") = Request("id_propriedade")
            Else
                ViewState.Item("id_propriedade") = String.Empty
            End If
            If (Not Request("txt_ano") Is Nothing) Then
                ViewState.Item("txt_ano") = Request("txt_ano")
            Else
                ViewState.Item("txt_ano") = String.Empty
            End If

            If (Not Request("id_grupo") Is Nothing) Then
                ViewState.Item("id_grupo") = Request("id_grupo")
            Else
                ViewState.Item("id_grupo") = String.Empty
            End If

            Dim analiseesalq As New AnaliseEsalq

            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            analiseesalq.dt_referencia_ini = "01/01/" & (ViewState.Item("txt_ano") - 1)
            analiseesalq.dt_referencia_fim = "31/12/" & ViewState.Item("txt_ano")
            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)

            If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
                analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            Else
                analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            End If
            analiseesalq.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString)

            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            End If

            Dim dsComplienceSintetico As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceSinteticoKPI()

            Dim dsvolumecompl As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalComplienceKPI

            analiseesalq.id_conta_teor = 265  ' conta teor CCS Mensal
            Dim dsccsmes As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI

            analiseesalq.id_conta_teor = 253  ' conta teor CCS trimestral
            Dim dsccstri As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI

            analiseesalq.id_conta_teor = 264  ' conta teor cbt Mensal
            Dim dscbtmes As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI

            analiseesalq.id_conta_teor = 252  ' conta teor cbt tri
            Dim dscbttri As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI

            analiseesalq.id_conta_teor = 251  ' conta teor proteina
            Dim dsproteina As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI

            analiseesalq.id_conta_teor = 156  ' conta teor mg
            Dim dsgordura As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceMediaGeoKPI

            If (dsvolumecompl.Tables(0).Rows.Count > 0) Then

                gridVolumeTotalComplience.Visible = True
                gridVolumeTotalComplience.DataSource = Helper.getDataView(dsvolumecompl.Tables(0), "")
                gridVolumeTotalComplience.DataBind()

                gridCCSMensal.Visible = True
                gridCCSMensal.DataSource = Helper.getDataView(dsccsmes.Tables(0), "")
                gridCCSMensal.DataBind()

                gridCCSTrimestral.Visible = True
                gridCCSTrimestral.DataSource = Helper.getDataView(dsccstri.Tables(0), "")
                gridCCSTrimestral.DataBind()

                gridCBTMensal.Visible = True
                gridCBTMensal.DataSource = Helper.getDataView(dscbtmes.Tables(0), "")
                gridCBTMensal.DataBind()

                gridCBTTrimestral.Visible = True
                gridCBTTrimestral.DataSource = Helper.getDataView(dscbttri.Tables(0), "")
                gridCBTTrimestral.DataBind()

                gridProteinaMensal.Visible = True
                gridProteinaMensal.DataSource = Helper.getDataView(dsproteina.Tables(0), "")
                gridProteinaMensal.DataBind()

                gridGorduraMensal.Visible = True
                gridGorduraMensal.DataSource = Helper.getDataView(dsgordura.Tables(0), "")
                gridGorduraMensal.DataBind()

            End If

            ' Monta grid Volume Rejeitado ATB
            Dim dsVolumeRejeitadoSintetico As DataSet = analiseesalq.getCurvaAbcVolumeLeiteRejeitadoATB()
            If (dsVolumeRejeitadoSintetico.Tables(0).Rows.Count > 0) Then

                gridVolumeRejeitado.Visible = True
                gridVolumeRejeitado.DataSource = Helper.getDataView(dsVolumeRejeitadoSintetico.Tables(0), "")
                gridVolumeRejeitado.DataBind()
            End If

            ' Monta grid Traçado Controlado (somente do ano corrente)
            analiseesalq.dt_referencia_ini = "01/01/" & ViewState.Item("txt_ano")
            analiseesalq.dt_referencia_fim = "31/12/" & ViewState.Item("txt_ano")
            Dim dsVolumeTracadoControlado As DataSet = analiseesalq.getCurvaAbcVolumeTracadoControladoSintetico()
            If (dsVolumeTracadoControlado.Tables(0).Rows.Count > 0) Then

                gridTracadoControlado.Visible = True
                gridTracadoControlado.DataSource = Helper.getDataView(dsVolumeTracadoControlado.Tables(0), "")
                gridTracadoControlado.DataBind()
            End If

            Dim tw As New StringWriter()
            Dim hw As New System.Web.UI.HtmlTextWriter(tw)
            Dim frm As HtmlForm = New HtmlForm()
            Response.ContentType = "application/vnd.ms-excel"
            Response.AddHeader("content-disposition", "attachment;filename=" & "CurvaABC_KPIQualidade" & ViewState.Item("txt_ano").ToString & ".xls")
            Response.Charset = ""
            EnableViewState = False
            Controls.Add(frm)
            frm.Controls.Add(gridVolumeTotalComplience)
            frm.Controls.Add(gridCCSMensal)
            frm.Controls.Add(gridCCSTrimestral)
            frm.Controls.Add(gridCBTMensal)
            frm.Controls.Add(gridCBTTrimestral)
            frm.Controls.Add(gridProteinaMensal)
            frm.Controls.Add(gridGorduraMensal)
            frm.Controls.Add(gridVolumeRejeitado)
            frm.Controls.Add(gridTracadoControlado)

            frm.RenderControl(hw)
            Response.Write(tw.ToString())
            Response.End()
  


        Catch ex As Exception

            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridCCSMensal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCCSMensal.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            If Not lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If Not lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 0)
            End If
            If Not lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 0)
            End If
            If Not lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 0)
            End If
            If Not lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 0)
            End If
            If Not lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 0)
            End If
            If Not lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 0)
            End If
            If Not lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 0)
            End If
            If Not lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = FormatNumber(lbl_set.Text, 0)
            End If
            If Not lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = FormatNumber(lbl_out.Text, 0)
            End If
            If Not lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 0)
            End If
            If Not lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 0)
            End If

            lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 0).ToString   ' 22/08/2017 chamado 2565
        End If

    End Sub

    Protected Sub gridCCSTrimestral_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCCSTrimestral.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            If Not lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If Not lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 0)
            End If
            If Not lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 0)
            End If
            If Not lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 0)
            End If
            If Not lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 0)
            End If
            If Not lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 0)
            End If
            If Not lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 0)
            End If
            If Not lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 0)
            End If
            If Not lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = FormatNumber(lbl_set.Text, 0)
            End If
            If Not lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = FormatNumber(lbl_out.Text, 0)
            End If
            If Not lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 0)
            End If
            If Not lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 0)
            End If

            lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 0).ToString   ' 22/08/2017 chamado 2565

        End If

    End Sub

    Protected Sub gridCBTMensal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCBTMensal.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565


            If Not lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If Not lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 0)
            End If
            If Not lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 0)
            End If
            If Not lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 0)
            End If
            If Not lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 0)
            End If
            If Not lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 0)
            End If
            If Not lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 0)
            End If
            If Not lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 0)
            End If
            If Not lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = FormatNumber(lbl_set.Text, 0)
            End If
            If Not lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = FormatNumber(lbl_out.Text, 0)
            End If
            If Not lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 0)
            End If
            If Not lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 0)
            End If
            lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 0).ToString   ' 22/08/2017 chamado 2565




        End If

    End Sub

    Protected Sub gridCBTTrimestral_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCBTTrimestral.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            If Not lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If Not lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 0)
            End If
            If Not lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 0)
            End If
            If Not lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 0)
            End If
            If Not lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 0)
            End If
            If Not lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 0)
            End If
            If Not lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 0)
            End If
            If Not lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 0)
            End If
            If Not lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = FormatNumber(lbl_set.Text, 0)
            End If
            If Not lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = FormatNumber(lbl_out.Text, 0)
            End If
            If Not lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 0)
            End If
            If Not lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 0)
            End If
            lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 0).ToString   ' 22/08/2017 chamado 2565
        End If

    End Sub

    Protected Sub gridProteinaMensal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridProteinaMensal.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            If Not lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 2)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If Not lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 2)
            End If
            If Not lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 2)
            End If
            If Not lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 2)
            End If
            If Not lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 2)
            End If
            If Not lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 2)
            End If
            If Not lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 2)
            End If
            If Not lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 2)
            End If
            If Not lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = FormatNumber(lbl_set.Text, 2)
            End If
            If Not lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = FormatNumber(lbl_out.Text, 2)
            End If
            If Not lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 2)
            End If
            If Not lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 2)
            End If

            lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 2).ToString   ' 22/08/2017 chamado 2565
            'desabilitado pois resolve no sql


        End If

    End Sub

    Protected Sub gridGorduraMensal_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridGorduraMensal.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            If Not lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 2)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If Not lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 2)
            End If
            If Not lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 2)
            End If
            If Not lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 2)
            End If
            If Not lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 2)
            End If
            If Not lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 2)
            End If
            If Not lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 2)
            End If
            If Not lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 2)
            End If
            If Not lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = FormatNumber(lbl_set.Text, 2)
            End If
            If Not lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = FormatNumber(lbl_out.Text, 2)
            End If
            If Not lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 2)
            End If
            If Not lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 2)
            End If
            lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 2).ToString   ' 22/08/2017 chamado 2565
        End If

    End Sub

    Protected Sub gridVolumeTotalComplience_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridVolumeTotalComplience.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565


            ''Inicializa porque a conta 276-complience total passou a existir a partir de 2017
            If lbl_jan.Text.Equals(String.Empty) Then
                lbl_jan.Text = "0"
            Else
                lbl_jan.Text = FormatNumber(lbl_jan.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_fev.Text.Equals(String.Empty) Then
                lbl_fev.Text = "0"
            Else
                lbl_fev.Text = FormatNumber(lbl_fev.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_mar.Text.Equals(String.Empty) Then
                lbl_mar.Text = "0"
            Else
                lbl_mar.Text = FormatNumber(lbl_mar.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_abr.Text.Equals(String.Empty) Then
                lbl_abr.Text = "0"
            Else
                lbl_abr.Text = FormatNumber(lbl_abr.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_mai.Text.Equals(String.Empty) Then
                lbl_mai.Text = "0"
            Else
                lbl_mai.Text = FormatNumber(lbl_mai.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_jun.Text.Equals(String.Empty) Then
                lbl_jun.Text = "0"
            Else
                lbl_jun.Text = FormatNumber(lbl_jun.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_jul.Text.Equals(String.Empty) Then
                lbl_jul.Text = "0"
            Else
                lbl_jul.Text = FormatNumber(lbl_jul.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_ago.Text.Equals(String.Empty) Then
                lbl_ago.Text = "0"
            Else
                lbl_ago.Text = FormatNumber(lbl_ago.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_set.Text.Equals(String.Empty) Then
                lbl_set.Text = "0"
            Else
                lbl_set.Text = FormatNumber(lbl_set.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_out.Text.Equals(String.Empty) Then
                lbl_out.Text = "0"
            Else
                lbl_out.Text = FormatNumber(lbl_out.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_nov.Text.Equals(String.Empty) Then
                lbl_nov.Text = "0"
            Else
                lbl_nov.Text = FormatNumber(lbl_nov.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_dez.Text.Equals(String.Empty) Then
                lbl_dez.Text = "0"
            Else
                lbl_dez.Text = FormatNumber(lbl_dez.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
            If lbl_media_anual.Text.Equals(String.Empty) Then
                lbl_media_anual.Text = "0"
            Else
                lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 2).ToString & "%"  ' (%) Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
            End If
        End If

    End Sub

    Protected Sub gridVolumeRejeitado_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridVolumeRejeitado.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_seq As Label = CType(e.Row.FindControl("lbl_seq"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565


            Select Case lbl_seq.Text.Trim
                Case "1", "2"
                    If lbl_seq.Text.Trim = "1" Then
                        lbl_nr_ano.Text = "Volume total " & lbl_nr_ano.Text
                    Else
                        lbl_nr_ano.Text = "Volume rejeitado " & lbl_nr_ano.Text
                    End If
                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 0)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 0)
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 0)
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 0)
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 0)
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 0)
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 0)
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 0)
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 0)
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 0)
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 0)
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 0)
                    End If

                    lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text), 0).ToString

                Case "3"
                    lbl_nr_ano.Text = "%"

                    'Inicializa
                    lbl_jan.Text = IIf(Not IsNumeric(lbl_jan.Text), 0, lbl_jan.Text)
                    lbl_fev.Text = IIf(Not IsNumeric(lbl_fev.Text), 0, lbl_fev.Text)
                    lbl_mar.Text = IIf(Not IsNumeric(lbl_mar.Text), 0, lbl_mar.Text)
                    lbl_abr.Text = IIf(Not IsNumeric(lbl_abr.Text), 0, lbl_abr.Text)
                    lbl_mai.Text = IIf(Not IsNumeric(lbl_mai.Text), 0, lbl_mai.Text)
                    lbl_jun.Text = IIf(Not IsNumeric(lbl_jun.Text), 0, lbl_jun.Text)
                    lbl_jul.Text = IIf(Not IsNumeric(lbl_jul.Text), 0, lbl_jul.Text)
                    lbl_ago.Text = IIf(Not IsNumeric(lbl_ago.Text), 0, lbl_ago.Text)
                    lbl_set.Text = IIf(Not IsNumeric(lbl_set.Text), 0, lbl_set.Text)
                    lbl_out.Text = IIf(Not IsNumeric(lbl_out.Text), 0, lbl_out.Text)
                    lbl_nov.Text = IIf(Not IsNumeric(lbl_nov.Text), 0, lbl_nov.Text)
                    lbl_dez.Text = IIf(Not IsNumeric(lbl_dez.Text), 0, lbl_dez.Text)

                    If Not lbl_jan.Text.Equals(String.Empty) Then
                        lbl_jan.Text = FormatNumber(lbl_jan.Text, 3)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                    End If
                    If Not lbl_fev.Text.Equals(String.Empty) Then
                        lbl_fev.Text = FormatNumber(lbl_fev.Text, 3)
                    End If
                    If Not lbl_mar.Text.Equals(String.Empty) Then
                        lbl_mar.Text = FormatNumber(lbl_mar.Text, 3)
                    End If
                    If Not lbl_abr.Text.Equals(String.Empty) Then
                        lbl_abr.Text = FormatNumber(lbl_abr.Text, 3)
                    End If
                    If Not lbl_mai.Text.Equals(String.Empty) Then
                        lbl_mai.Text = FormatNumber(lbl_mai.Text, 3)
                    End If
                    If Not lbl_jun.Text.Equals(String.Empty) Then
                        lbl_jun.Text = FormatNumber(lbl_jun.Text, 3)
                    End If
                    If Not lbl_jul.Text.Equals(String.Empty) Then
                        lbl_jul.Text = FormatNumber(lbl_jul.Text, 3)
                    End If
                    If Not lbl_ago.Text.Equals(String.Empty) Then
                        lbl_ago.Text = FormatNumber(lbl_ago.Text, 3)
                    End If
                    If Not lbl_set.Text.Equals(String.Empty) Then
                        lbl_set.Text = FormatNumber(lbl_set.Text, 3)
                    End If
                    If Not lbl_out.Text.Equals(String.Empty) Then
                        lbl_out.Text = FormatNumber(lbl_out.Text, 3)
                    End If
                    If Not lbl_nov.Text.Equals(String.Empty) Then
                        lbl_nov.Text = FormatNumber(lbl_nov.Text, 3)
                    End If
                    If Not lbl_dez.Text.Equals(String.Empty) Then
                        lbl_dez.Text = FormatNumber(lbl_dez.Text, 3)
                    End If

                    lbl_media_anual.Text = FormatNumber(lbl_media_anual.Text, 2).ToString & "%"



                    lbl_jan.Text = IIf(CDec(lbl_jan.Text) = 0, "", lbl_jan.Text)
                    lbl_fev.Text = IIf(CDec(lbl_fev.Text) = 0, "", lbl_fev.Text)
                    lbl_mar.Text = IIf(CDec(lbl_mar.Text) = 0, "", lbl_mar.Text)
                    lbl_abr.Text = IIf(CDec(lbl_abr.Text) = 0, "", lbl_abr.Text)
                    lbl_mai.Text = IIf(CDec(lbl_mai.Text) = 0, "", lbl_mai.Text)
                    lbl_jun.Text = IIf(CDec(lbl_jun.Text) = 0, "", lbl_jun.Text)
                    lbl_jul.Text = IIf(CDec(lbl_jul.Text) = 0, "", lbl_jul.Text)
                    lbl_ago.Text = IIf(CDec(lbl_ago.Text) = 0, "", lbl_ago.Text)
                    lbl_set.Text = IIf(CDec(lbl_set.Text) = 0, "", lbl_set.Text)
                    lbl_out.Text = IIf(CDec(lbl_out.Text) = 0, "", lbl_out.Text)
                    lbl_nov.Text = IIf(CDec(lbl_nov.Text) = 0, "", lbl_nov.Text)
                    lbl_dez.Text = IIf(CDec(lbl_dez.Text) = 0, "", lbl_dez.Text)

            End Select


        End If

    End Sub

    Protected Sub gridTracadoControlado_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridTracadoControlado.RowDataBound
        If (e.Row.RowType = DataControlRowType.Header) Then

            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            lbl_nr_ano.Text = ViewState.Item("txt_ano").ToString

        End If



        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvolumetotal As Decimal
            Dim lvolumetotalcooperativa As Decimal
            Dim lvolumetotalprodutor As Decimal

            Dim li As Integer
            Dim lbl_nr_ano As Label = CType(e.Row.FindControl("lbl_nr_ano"), Label)
            Dim lbl_seq As Label = CType(e.Row.FindControl("lbl_seq"), Label)
            Dim lbl_jan As Label = CType(e.Row.FindControl("lbl_jan"), Label)
            Dim lbl_fev As Label = CType(e.Row.FindControl("lbl_fev"), Label)
            Dim lbl_mar As Label = CType(e.Row.FindControl("lbl_mar"), Label)
            Dim lbl_abr As Label = CType(e.Row.FindControl("lbl_abr"), Label)
            Dim lbl_mai As Label = CType(e.Row.FindControl("lbl_mai"), Label)
            Dim lbl_jun As Label = CType(e.Row.FindControl("lbl_jun"), Label)
            Dim lbl_jul As Label = CType(e.Row.FindControl("lbl_jul"), Label)
            Dim lbl_ago As Label = CType(e.Row.FindControl("lbl_ago"), Label)
            Dim lbl_set As Label = CType(e.Row.FindControl("lbl_set"), Label)
            Dim lbl_out As Label = CType(e.Row.FindControl("lbl_out"), Label)
            Dim lbl_nov As Label = CType(e.Row.FindControl("lbl_nov"), Label)
            Dim lbl_dez As Label = CType(e.Row.FindControl("lbl_dez"), Label)
            Dim lbl_media_anual As Label = CType(e.Row.FindControl("lbl_media_anual"), Label)  ' 22/08/2017 chamado 2565
            Dim lvolumetotal_anual As Decimal = 0 ' 22/08/2017 chamado 2565

            ' ''Dim analiseesalq As New AnaliseEsalq

            ' ''analiseesalq.dt_referencia_ini = "01/01/" & lbl_nr_ano.Text
            ' ''analiseesalq.dt_referencia_fim = "31/12/" & lbl_nr_ano.Text
            ' ''analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            ' ''If ViewState.Item("id_estabelecimento").ToString = "1" Then  ' Se Poços
            ' ''    analiseesalq.estabelecimentos = "1|6"  ' Passa estabelecimento Poços e Águas (devem sempre ser analisados juntos
            ' ''Else
            ' ''    analiseesalq.estabelecimentos = analiseesalq.id_estabelecimento
            ' ''End If

            '' '' adri 16/08/2017 - chamado 2564 - i
            ' ''If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
            ' ''    analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            ' ''End If

            ' ''If Trim(ViewState.Item("id_propriedade")) <> "" Then
            ' ''    analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            ' ''End If
            '' '' adri 16/08/2017 - chamado 2564 - f


            '=======================================================
            ' VOLUME TOTAL DE PRODUTORES 
            '=======================================================
            If lbl_seq.Text = 1 Then  'Se linha do Volume Total Produtores

                'lbl_nr_ano.Text = "% Traçado e Controlado "
                lbl_nr_ano.Text = "% Volume Produtores "  ' 22/08/2017 chamado xxxx
                ''analiseesalq.id_grupo = 1  ' Produtores
                ' ''Dim dsVolume As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI   ' Traz volume agrupados por referencia
                ''Dim dsVolume As DataSet = analiseesalq.getCurvaAbcVolumeLeiteProdutores   ' Traz volume agrupados por referencia sem verificar se tem contas de teor

                ''lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

                ''For li = 0 To dsVolume.Tables(0).Rows.Count - 1
                ''    Select Case dsVolume.Tables(0).Rows(li).Item("nr_mes").ToString
                ''        Case 1
                ''            lbl_jan.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 2
                ''            lbl_fev.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 3
                ''            lbl_mar.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 4
                ''            lbl_abr.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 5
                ''            lbl_mai.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 6
                ''            lbl_jun.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 7
                ''            lbl_jul.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 8
                ''            lbl_ago.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 9
                ''            lbl_set.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 10
                ''            lbl_out.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 11
                ''            lbl_nov.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''        Case 12
                ''            lbl_dez.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_total"), 0)
                ''    End Select

                ''    lbl_media_anual.Text = lbl_media_anual.Text + dsVolume.Tables(0).Rows(li).Item("nr_volume_total")  ' 22/08/2017 chamado 2565 (volume do produtor no ano)

                ''Next

                '=======================================================
                ' CALCULO DO % PRODUTORES
                '=======================================================
                'Inicializa
                lbl_jan.Text = IIf(Not IsNumeric(lbl_jan.Text), 0, lbl_jan.Text)
                lbl_fev.Text = IIf(Not IsNumeric(lbl_fev.Text), 0, lbl_fev.Text)
                lbl_mar.Text = IIf(Not IsNumeric(lbl_mar.Text), 0, lbl_mar.Text)
                lbl_abr.Text = IIf(Not IsNumeric(lbl_abr.Text), 0, lbl_abr.Text)
                lbl_mai.Text = IIf(Not IsNumeric(lbl_mai.Text), 0, lbl_mai.Text)
                lbl_jun.Text = IIf(Not IsNumeric(lbl_jun.Text), 0, lbl_jun.Text)
                lbl_jul.Text = IIf(Not IsNumeric(lbl_jul.Text), 0, lbl_jul.Text)
                lbl_ago.Text = IIf(Not IsNumeric(lbl_ago.Text), 0, lbl_ago.Text)
                lbl_set.Text = IIf(Not IsNumeric(lbl_set.Text), 0, lbl_set.Text)
                lbl_out.Text = IIf(Not IsNumeric(lbl_out.Text), 0, lbl_out.Text)
                lbl_nov.Text = IIf(Not IsNumeric(lbl_nov.Text), 0, lbl_nov.Text)
                lbl_dez.Text = IIf(Not IsNumeric(lbl_dez.Text), 0, lbl_dez.Text)
                lbl_media_anual.Text = IIf(Not IsNumeric(lbl_media_anual.Text), 0, lbl_media_anual.Text)


                ''Dim dsVolumeCooperativa As DataSet = analiseesalq.getCurvaAbcVolumeLeiteCooperativa()   ' Traz volume cooperativas agrupados por referencia
                ''For li = 0 To dsVolumeCooperativa.Tables(0).Rows.Count - 1

                ''    lvolumetotalcooperativa = dsVolumeCooperativa.Tables(0).Rows(li).Item("nr_volume_cooperativa")

                ''    Select Case dsVolumeCooperativa.Tables(0).Rows(li).Item("nr_mes").ToString
                ''        Case 1
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_jan.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_jan.Text = FormatNumber((lbl_jan.Text / lvolumetotal) * 100, 2)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                ''        Case 2
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_fev.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_fev.Text = FormatNumber((lbl_fev.Text / lvolumetotal) * 100, 2)
                ''        Case 3
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_mar.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_mar.Text = FormatNumber((lbl_mar.Text / lvolumetotal) * 100, 2)
                ''        Case 4
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_abr.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_abr.Text = FormatNumber((lbl_abr.Text / lvolumetotal) * 100, 2)
                ''        Case 5
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_mai.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_mai.Text = FormatNumber((lbl_mai.Text / lvolumetotal) * 100, 2)
                ''        Case 6
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_jun.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_jun.Text = FormatNumber((lbl_jun.Text / lvolumetotal) * 100, 2)
                ''        Case 7
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_jul.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_jul.Text = FormatNumber((lbl_jul.Text / lvolumetotal) * 100, 2)
                ''        Case 8
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_ago.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_ago.Text = FormatNumber((lbl_ago.Text / lvolumetotal) * 100, 2)
                ''        Case 9
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_set.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_set.Text = FormatNumber((lbl_set.Text / lvolumetotal) * 100, 2)
                ''        Case 10
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_out.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_out.Text = FormatNumber((lbl_out.Text / lvolumetotal) * 100, 2)
                ''        Case 11
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_nov.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_nov.Text = FormatNumber((lbl_nov.Text / lvolumetotal) * 100, 2)
                ''        Case 12
                ''            lvolumetotal = lvolumetotalcooperativa + CDec(lbl_dez.Text)  ' soma volume cooperativa + volume produtor
                ''            lbl_dez.Text = FormatNumber((lbl_dez.Text / lvolumetotal) * 100, 2)
                ''    End Select

                ''    lvolumetotal_anual = lvolumetotal_anual + lvolumetotal ' 22/08/2017 chamado 2565  *volume total de produtores + cooperativas no ano)

                ''Next

                ''lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text / lvolumetotal_anual) * 100, 2).ToString   ' 22/08/2017 chamado 2565

                lbl_jan.Text = IIf(CDec(lbl_jan.Text) = 0, "", FormatNumber(lbl_jan.Text, 2))
                lbl_fev.Text = IIf(CDec(lbl_fev.Text) = 0, "", FormatNumber(lbl_fev.Text, 2))
                lbl_mar.Text = IIf(CDec(lbl_mar.Text) = 0, "", FormatNumber(lbl_mar.Text, 2))
                lbl_abr.Text = IIf(CDec(lbl_abr.Text) = 0, "", FormatNumber(lbl_abr.Text, 2))
                lbl_mai.Text = IIf(CDec(lbl_mai.Text) = 0, "", FormatNumber(lbl_mai.Text, 2))
                lbl_jun.Text = IIf(CDec(lbl_jun.Text) = 0, "", FormatNumber(lbl_jun.Text, 2))
                lbl_jul.Text = IIf(CDec(lbl_jul.Text) = 0, "", FormatNumber(lbl_jul.Text, 2))
                lbl_ago.Text = IIf(CDec(lbl_ago.Text) = 0, "", FormatNumber(lbl_ago.Text, 2))
                lbl_set.Text = IIf(CDec(lbl_set.Text) = 0, "", FormatNumber(lbl_set.Text, 2))
                lbl_out.Text = IIf(CDec(lbl_out.Text) = 0, "", FormatNumber(lbl_out.Text, 2))
                lbl_nov.Text = IIf(CDec(lbl_nov.Text) = 0, "", FormatNumber(lbl_nov.Text, 2))
                lbl_dez.Text = IIf(CDec(lbl_dez.Text) = 0, "", FormatNumber(lbl_dez.Text, 2))
                lbl_media_anual.Text = IIf(CDec(lbl_media_anual.Text) = 0, "", FormatNumber(lbl_media_anual.Text, 2))

                ' '' Se o campo tem valor e não tem casas decimais, significa que não calculou o percentual, e se não calculou é porque não tinha o volume da cooperativa no mes, então assume 100%
                ''lbl_jan.Text = IIf(IsNumeric(lbl_jan.Text) And InStr(1, lbl_jan.Text, ",", 1) = 0, 100, lbl_jan.Text)
                ''lbl_fev.Text = IIf(IsNumeric(lbl_fev.Text) And InStr(1, lbl_fev.Text, ",", 1) = 0, 100, lbl_fev.Text)
                ''lbl_mar.Text = IIf(IsNumeric(lbl_mar.Text) And InStr(1, lbl_mar.Text, ",", 1) = 0, 100, lbl_mar.Text)
                ''lbl_abr.Text = IIf(IsNumeric(lbl_abr.Text) And InStr(1, lbl_abr.Text, ",", 1) = 0, 100, lbl_abr.Text)
                ''lbl_mai.Text = IIf(IsNumeric(lbl_mai.Text) And InStr(1, lbl_mai.Text, ",", 1) = 0, 100, lbl_mai.Text)
                ''lbl_jun.Text = IIf(IsNumeric(lbl_jun.Text) And InStr(1, lbl_jun.Text, ",", 1) = 0, 100, lbl_jun.Text)
                ''lbl_jul.Text = IIf(IsNumeric(lbl_jul.Text) And InStr(1, lbl_jul.Text, ",", 1) = 0, 100, lbl_jul.Text)
                ''lbl_ago.Text = IIf(IsNumeric(lbl_ago.Text) And InStr(1, lbl_ago.Text, ",", 1) = 0, 100, lbl_ago.Text)
                ''lbl_set.Text = IIf(IsNumeric(lbl_set.Text) And InStr(1, lbl_set.Text, ",", 1) = 0, 100, lbl_set.Text)
                ''lbl_out.Text = IIf(IsNumeric(lbl_out.Text) And InStr(1, lbl_out.Text, ",", 1) = 0, 100, lbl_out.Text)
                ''lbl_nov.Text = IIf(IsNumeric(lbl_nov.Text) And InStr(1, lbl_nov.Text, ",", 1) = 0, 100, lbl_nov.Text)
                ''lbl_dez.Text = IIf(IsNumeric(lbl_dez.Text) And InStr(1, lbl_dez.Text, ",", 1) = 0, 100, lbl_dez.Text)

            End If


            '=======================================================
            '  VOLUME TOTAL DE COOPERATIVAS 
            '=======================================================
            If lbl_seq.Text = 2 Then  'Se linha do Volume Cooperativas

                'lbl_nr_ano.Text = "% Traçado "
                lbl_nr_ano.Text = "% Volume Cooperativas "  ' 22/08/2017 chamado xxxx

                ' ''Dim dsVolume As DataSet = analiseesalq.getCurvaAbcVolumeLeiteCooperativa()   ' Traz volume cooperativas agrupados por referencia

                ' ''lbl_media_anual.Text = "0"  ' 22/08/2017 chamado 2565

                ' ''For li = 0 To dsVolume.Tables(0).Rows.Count - 1
                ' ''    Select Case dsVolume.Tables(0).Rows(li).Item("nr_mes").ToString
                ' ''        Case 1
                ' ''            lbl_jan.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 2
                ' ''            lbl_fev.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 3
                ' ''            lbl_mar.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 4
                ' ''            lbl_abr.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 5
                ' ''            lbl_mai.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 6
                ' ''            lbl_jun.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 7
                ' ''            lbl_jul.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 8
                ' ''            lbl_ago.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 9
                ' ''            lbl_set.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 10
                ' ''            lbl_out.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 11
                ' ''            lbl_nov.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''        Case 12
                ' ''            lbl_dez.Text = FormatNumber(dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa"), 0)
                ' ''    End Select

                ' ''    lbl_media_anual.Text = lbl_media_anual.Text + dsVolume.Tables(0).Rows(li).Item("nr_volume_cooperativa")  ' 22/08/2017 chamado 2565

                ' ''Next

                '=======================================================
                ' CALCULO DO % COOPERATIVAS
                '=======================================================
                'Inicializa 
                lbl_jan.Text = IIf(Not IsNumeric(lbl_jan.Text), 0, lbl_jan.Text)
                lbl_fev.Text = IIf(Not IsNumeric(lbl_fev.Text), 0, lbl_fev.Text)
                lbl_mar.Text = IIf(Not IsNumeric(lbl_mar.Text), 0, lbl_mar.Text)
                lbl_abr.Text = IIf(Not IsNumeric(lbl_abr.Text), 0, lbl_abr.Text)
                lbl_mai.Text = IIf(Not IsNumeric(lbl_mai.Text), 0, lbl_mai.Text)
                lbl_jun.Text = IIf(Not IsNumeric(lbl_jun.Text), 0, lbl_jun.Text)
                lbl_jul.Text = IIf(Not IsNumeric(lbl_jul.Text), 0, lbl_jul.Text)
                lbl_ago.Text = IIf(Not IsNumeric(lbl_ago.Text), 0, lbl_ago.Text)
                lbl_set.Text = IIf(Not IsNumeric(lbl_set.Text), 0, lbl_set.Text)
                lbl_out.Text = IIf(Not IsNumeric(lbl_out.Text), 0, lbl_out.Text)
                lbl_nov.Text = IIf(Not IsNumeric(lbl_nov.Text), 0, lbl_nov.Text)
                lbl_dez.Text = IIf(Not IsNumeric(lbl_dez.Text), 0, lbl_dez.Text)
                lbl_media_anual.Text = IIf(Not IsNumeric(lbl_media_anual.Text), 0, lbl_media_anual.Text)

                ' ''analiseesalq.id_grupo = 1  ' Produtores
                '' ''Dim dsVolumeProdutores As DataSet = analiseesalq.getCurvaAbcProdutoresComplienceVolumeTotalKPI   ' Traz volume agrupados por referencia
                ' ''Dim dsVolumeProdutores As DataSet = analiseesalq.getCurvaAbcVolumeLeiteProdutores   ' 23/08/2017 Traz volume agrupados por referencia sem verificar se tem contas de teor

                ' ''For li = 0 To dsVolumeProdutores.Tables(0).Rows.Count - 1

                ' ''    lvolumetotalprodutor = dsVolumeProdutores.Tables(0).Rows(li).Item("nr_volume_total")

                ' ''    Select Case dsVolumeProdutores.Tables(0).Rows(li).Item("nr_mes").ToString
                ' ''        Case 1
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_jan.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_jan.Text = FormatNumber((lbl_jan.Text / lvolumetotal) * 100, 2)   ' Divide pelo volume já descontado do somatório de volumes com teor mensal igual a zero ou null
                ' ''        Case 2
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_fev.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_fev.Text = FormatNumber((lbl_fev.Text / lvolumetotal) * 100, 2)
                ' ''        Case 3
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_mar.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_mar.Text = FormatNumber((lbl_mar.Text / lvolumetotal) * 100, 2)
                ' ''        Case 4
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_abr.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_abr.Text = FormatNumber((lbl_abr.Text / lvolumetotal) * 100, 2)
                ' ''        Case 5
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_mai.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_mai.Text = FormatNumber((lbl_mai.Text / lvolumetotal) * 100, 2)
                ' ''        Case 6
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_jun.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_jun.Text = FormatNumber((lbl_jun.Text / lvolumetotal) * 100, 2)
                ' ''        Case 7
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_jul.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_jul.Text = FormatNumber((lbl_jul.Text / lvolumetotal) * 100, 2)
                ' ''        Case 8
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_ago.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_ago.Text = FormatNumber((lbl_ago.Text / lvolumetotal) * 100, 2)
                ' ''        Case 9
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_set.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_set.Text = FormatNumber((lbl_set.Text / lvolumetotal) * 100, 2)
                ' ''        Case 10
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_out.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_out.Text = FormatNumber((lbl_out.Text / lvolumetotal) * 100, 2)
                ' ''        Case 11
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_nov.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_nov.Text = FormatNumber((lbl_nov.Text / lvolumetotal) * 100, 2)
                ' ''        Case 12
                ' ''            lvolumetotal = lvolumetotalprodutor + CDec(lbl_dez.Text)  ' soma volume cooperativa + volume produtor
                ' ''            lbl_dez.Text = FormatNumber((lbl_dez.Text / lvolumetotal) * 100, 2)
                ' ''    End Select

                ' ''    lvolumetotal_anual = lvolumetotal_anual + lvolumetotal ' 22/08/2017 chamado 2565

                ' ''Next

                ' ''lbl_media_anual.Text = FormatNumber((lbl_media_anual.Text / lvolumetotal_anual) * 100, 2).ToString   ' 22/08/2017 chamado 2565

                lbl_jan.Text = IIf(CDec(lbl_jan.Text) = 0, "", FormatNumber(lbl_jan.Text, 2))
                lbl_fev.Text = IIf(CDec(lbl_fev.Text) = 0, "", FormatNumber(lbl_fev.Text, 2))
                lbl_mar.Text = IIf(CDec(lbl_mar.Text) = 0, "", FormatNumber(lbl_mar.Text, 2))
                lbl_abr.Text = IIf(CDec(lbl_abr.Text) = 0, "", FormatNumber(lbl_abr.Text, 2))
                lbl_mai.Text = IIf(CDec(lbl_mai.Text) = 0, "", FormatNumber(lbl_mai.Text, 2))
                lbl_jun.Text = IIf(CDec(lbl_jun.Text) = 0, "", FormatNumber(lbl_jun.Text, 2))
                lbl_jul.Text = IIf(CDec(lbl_jul.Text) = 0, "", FormatNumber(lbl_jul.Text, 2))
                lbl_ago.Text = IIf(CDec(lbl_ago.Text) = 0, "", FormatNumber(lbl_ago.Text, 2))
                lbl_set.Text = IIf(CDec(lbl_set.Text) = 0, "", FormatNumber(lbl_set.Text, 2))
                lbl_out.Text = IIf(CDec(lbl_out.Text) = 0, "", FormatNumber(lbl_out.Text, 2))
                lbl_nov.Text = IIf(CDec(lbl_nov.Text) = 0, "", FormatNumber(lbl_nov.Text, 2))
                lbl_dez.Text = IIf(CDec(lbl_dez.Text) = 0, "", FormatNumber(lbl_dez.Text, 2))
                lbl_media_anual.Text = IIf(CDec(lbl_media_anual.Text) = 0, "", FormatNumber(lbl_media_anual.Text, 2))

                '' '' Se o campo tem valor e não tem casas decimais, significa que não calculou o percentual, e se não calculou é porque não tinha o volume do produtor no mes, então assume 100%
                ' ''lbl_jan.Text = IIf(IsNumeric(lbl_jan.Text) And InStr(1, lbl_jan.Text, ",", 1) = 0, 100, lbl_jan.Text)
                ' ''lbl_fev.Text = IIf(IsNumeric(lbl_fev.Text) And InStr(1, lbl_fev.Text, ",", 1) = 0, 100, lbl_fev.Text)
                ' ''lbl_mar.Text = IIf(IsNumeric(lbl_mar.Text) And InStr(1, lbl_mar.Text, ",", 1) = 0, 100, lbl_mar.Text)
                ' ''lbl_abr.Text = IIf(IsNumeric(lbl_abr.Text) And InStr(1, lbl_abr.Text, ",", 1) = 0, 100, lbl_abr.Text)
                ' ''lbl_mai.Text = IIf(IsNumeric(lbl_mai.Text) And InStr(1, lbl_mai.Text, ",", 1) = 0, 100, lbl_mai.Text)
                ' ''lbl_jun.Text = IIf(IsNumeric(lbl_jun.Text) And InStr(1, lbl_jun.Text, ",", 1) = 0, 100, lbl_jun.Text)
                ' ''lbl_jul.Text = IIf(IsNumeric(lbl_jul.Text) And InStr(1, lbl_jul.Text, ",", 1) = 0, 100, lbl_jul.Text)
                ' ''lbl_ago.Text = IIf(IsNumeric(lbl_ago.Text) And InStr(1, lbl_ago.Text, ",", 1) = 0, 100, lbl_ago.Text)
                ' ''lbl_set.Text = IIf(IsNumeric(lbl_set.Text) And InStr(1, lbl_set.Text, ",", 1) = 0, 100, lbl_set.Text)
                ' ''lbl_out.Text = IIf(IsNumeric(lbl_out.Text) And InStr(1, lbl_out.Text, ",", 1) = 0, 100, lbl_out.Text)
                ' ''lbl_nov.Text = IIf(IsNumeric(lbl_nov.Text) And InStr(1, lbl_nov.Text, ",", 1) = 0, 100, lbl_nov.Text)
                ' ''lbl_dez.Text = IIf(IsNumeric(lbl_dez.Text) And InStr(1, lbl_dez.Text, ",", 1) = 0, 100, lbl_dez.Text)

            End If
        End If

    End Sub

End Class
