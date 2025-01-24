Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_romaneio_registros_finais_placas
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_registros_finais.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try


            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                If Not (Request("id_romaneio_placa") Is Nothing) Then
                    ViewState.Item("id_romaneio_placa") = Request("id_romaneio_placa")
                End If

                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                Dim silo As New Silo
                silo.id_estabelecimento = romaneio.id_estabelecimento
                silo.id_situacao = 1

                cbo_id_silo1.DataSource = silo.getSiloByFilters
                cbo_id_silo1.DataTextField = "nm_silo"
                cbo_id_silo1.DataValueField = "id_silo"
                cbo_id_silo1.DataBind()
                cbo_id_silo1.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

                cbo_id_silo2.DataSource = cbo_id_silo1.DataSource
                cbo_id_silo2.DataTextField = "nm_silo"
                cbo_id_silo2.DataValueField = "id_silo"
                cbo_id_silo2.DataBind()
                cbo_id_silo2.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try

            Dim id_romaneio_placa As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_placa").ToString)
            Dim rplaca As New RomaneioPlaca(id_romaneio_placa)

            lbl_id_romaneio.Text = rplaca.id_romaneio
            lbl_placa.Text = rplaca.ds_placa.ToString

            lbl_nr_total_volume_coletado.Text = rplaca.getRomaneioCompartimentosSomaVolumeByPlaca
            lbl_nr_total_volume_rejeitado.Text = rplaca.getRomaneioCompartimentosSomaVolumeRejeitadoByPlaca

            'fran 16/05/2012 i chamadi 1548
            If CDec(lbl_nr_total_volume_rejeitado.Text) > 0 Then
                tr_destino_leite_rejeitado.Visible = True
                If Not rplaca.st_destino_leite_rejeitado Is Nothing Then
                    cbo_destino_leite_rejeitado.SelectedValue = rplaca.st_destino_leite_rejeitado
                Else
                    cbo_destino_leite_rejeitado.SelectedValue = String.Empty

                End If
            Else
                tr_destino_leite_rejeitado.Visible = False

            End If
            'fran 16/05/2012 i chamadi 1548

            'lbl_nr_total_volume_coletado.Text = rplaca.nr_total_volume_coletado
            'lbl_nr_total_volume_rejeitado.Text = rplaca.nr_total_volume_rejeitado
            lbl_nr_volume_descarregado_sugerido.Text = CDec(lbl_nr_total_volume_coletado.Text) - CDec(lbl_nr_total_volume_rejeitado.Text)
            'txt_nr_volume_descarregado.Text = rplaca.nr_volume_descarregado
            If (rplaca.id_nr_silo1 > 0) Then
                cbo_id_silo1.SelectedValue = rplaca.id_nr_silo1
            Else
                'fran 24/09/2012 - assumir 1 silo se nao tiver
                cbo_id_silo1.SelectedValue = cbo_id_silo1.Items.FindByText("Silo 1").Value
                'fran 24/09/2012 - assumir 1 silo se nao tiver
            End If
            If (rplaca.id_nr_silo2 > 0) Then
                cbo_id_silo2.SelectedValue = rplaca.id_nr_silo2
            End If
            If Not rplaca.dt_ini_descarga Is Nothing Then
                txt_hr_ini_descarga.Text = Format(DateTime.Parse(rplaca.dt_ini_descarga), "HH")
                txt_mm_ini_descarga.Text = DatePart(DateInterval.Minute, DateTime.Parse(rplaca.dt_ini_descarga))
                txt_dt_ini_descarga.Text = Format(DateTime.Parse(rplaca.dt_ini_descarga), "dd/MM/yyyy")
            Else
                txt_hr_ini_descarga.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_ini_descarga.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
                txt_dt_ini_descarga.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")

            End If
            If Not rplaca.dt_fim_descarga Is Nothing Then
                txt_hr_fim_descarga.Text = Format(DateTime.Parse(rplaca.dt_fim_descarga), "HH")
                txt_mm_fim_descarga.Text = DatePart(DateInterval.Minute, DateTime.Parse(rplaca.dt_fim_descarga))
                txt_dt_fim_descarga.Text = Format(DateTime.Parse(rplaca.dt_fim_descarga), "dd/MM/yyyy")
            Else
                txt_hr_fim_descarga.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_fim_descarga.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
                txt_dt_fim_descarga.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            End If
            If Not rplaca.dt_ini_CIP Is Nothing Then
                txt_hr_ini_cip.Text = Format(DateTime.Parse(rplaca.dt_ini_CIP), "HH")
                txt_mm_ini_cip.Text = DatePart(DateInterval.Minute, DateTime.Parse(rplaca.dt_ini_CIP))
                txt_dt_ini_cip.Text = Format(DateTime.Parse(rplaca.dt_ini_CIP), "dd/MM/yyyy")
            Else
                txt_hr_ini_cip.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_ini_cip.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
                txt_dt_ini_cip.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            End If
            If Not rplaca.dt_fim_CIP Is Nothing Then
                txt_hr_fim_cip.Text = Format(DateTime.Parse(rplaca.dt_fim_CIP), "HH")
                txt_mm_fim_cip.Text = DatePart(DateInterval.Minute, DateTime.Parse(rplaca.dt_fim_CIP))
                txt_dt_fim_cip.Text = Format(DateTime.Parse(rplaca.dt_fim_CIP), "dd/MM/yyyy")
            Else
                txt_hr_fim_cip.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_fim_cip.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
                txt_dt_fim_cip.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            End If

            Dim dsrplaca As DataSet = rplaca.getRomaneioPlacasByFilters
            If dsrplaca.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(dsrplaca.Tables(0).Rows(0).Item("nr_ph_solucao")) Then
                    txt_nr_ph_solucao.Text = dsrplaca.Tables(0).Rows(0).Item("nr_ph_solucao")
                End If
            End If

            'Fran 22/05/2012 chamado1548 - com o escopo pertmitindo que leite rejeitado vá para o batch, os dados de descarga devem continuar serem preenchidos
            'fran themis batch i
            cbo_leite_descarregado.SelectedValue = rplaca.st_leite_descarregado
            cbo_motido_leite_nao_descarregado.SelectedValue = rplaca.st_motivo_leite_nao_descarregado
            If rplaca.st_leite_descarregado = "N" Then
                'cbo_motido_leite_nao_descarregado.Enabled = True
                'Fran 22/05/2012 chamado1548 i desabilitado deve continuar a ser preenchido pois romaneio rejeitado tb pode ir para o batch
                'txt_dt_ini_descarga.Enabled = False
                'txt_dt_fim_descarga.Enabled = False
                'txt_hr_ini_descarga.Enabled = False
                'txt_hr_fim_descarga.Enabled = False
                'txt_mm_ini_descarga.Enabled = False
                'txt_mm_fim_descarga.Enabled = False
                'Fran 22/05/2012 chamado1548 f

                'lbl_motivo.Enabled = False
                'cbo_id_silo1.Enabled = False
                'Fran 22/05/2012 chamado1548 i desabilitado deve continuar a ser preenchido pois romaneio rejeitado tb pode ir para o batch
                'cbo_id_silo2.Enabled = False
                'txt_dt_ini_descarga.Text = String.Empty
                'txt_dt_fim_descarga.Text = String.Empty
                'txt_hr_ini_descarga.Text = String.Empty
                'txt_hr_fim_descarga.Text = String.Empty
                'txt_mm_ini_descarga.Text = String.Empty
                'txt_mm_fim_descarga.Text = String.Empty
                'cbo_id_silo2.SelectedValue = String.Empty
                'rv_inidescarga.Enabled = False
                'rv_fimdescarga.Enabled = False
                'rv_mininidescarga.Enabled = False
                'rv_hrinidescarga.Enabled = False
                'rv_minfimdescarga.Enabled = False
                'rv_hrfimdescarga.Enabled = False
                'Fran 22/05/2012 chamado1548 f desabilitado deve continuar a ser preenchido pois romaneio rejeitado tb pode ir para o batch

            Else
                'cbo_motido_leite_nao_descarregado.Enabled = False
                txt_dt_ini_descarga.Enabled = True
                txt_dt_fim_descarga.Enabled = True
                txt_hr_ini_descarga.Enabled = True
                txt_hr_fim_descarga.Enabled = True
                txt_mm_ini_descarga.Enabled = True
                txt_mm_fim_descarga.Enabled = True
                'lbl_motivo.Enabled = True
                'cbo_id_silo1.Enabled = True
                cbo_id_silo2.Enabled = True
                rv_inidescarga.Enabled = True
                rv_fimdescarga.Enabled = True
                rv_mininidescarga.Enabled = True
                rv_hrinidescarga.Enabled = True
                rv_minfimdescarga.Enabled = True
                rv_hrfimdescarga.Enabled = True

            End If

            Dim romaneio As New Romaneio(rplaca.id_romaneio)
            If romaneio.id_registro_exportacao_batch > 1 Then 'já fez registro... não deixa mais alterar dados
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
            End If
            'fran themis batch f

            loadgridlacre()



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub updateData()
        If Page.IsValid Then


            Try

                Dim id_romaneio_placa As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_placa").ToString)
                Dim rplaca As New RomaneioPlaca(id_romaneio_placa)
                rplaca.nr_total_volume_coletado = Convert.ToDecimal(lbl_nr_total_volume_coletado.Text)
                rplaca.nr_total_volume_rejeitado = Convert.ToDecimal(lbl_nr_total_volume_rejeitado.Text)
                'rplaca.nr_volume_descarregado = Convert.ToDecimal(txt_nr_volume_descarregado.Text)
                rplaca.nr_volume_descarregado = Convert.ToDecimal(lbl_nr_volume_descarregado_sugerido.Text)
                If Not txt_dt_ini_descarga.Text.Equals(String.Empty) Then
                    rplaca.dt_ini_descarga = txt_dt_ini_descarga.Text & " " & txt_hr_ini_descarga.Text & ":" & txt_mm_ini_descarga.Text & ":00"
                Else
                    rplaca.dt_ini_descarga = String.Empty
                End If
                If Not txt_dt_fim_descarga.Text.Equals(String.Empty) Then
                    rplaca.dt_fim_descarga = txt_dt_fim_descarga.Text & " " & txt_hr_fim_descarga.Text & ":" & txt_mm_fim_descarga.Text & ":00"
                Else
                    rplaca.dt_fim_descarga = String.Empty

                End If
                rplaca.id_nr_silo1 = Convert.ToInt32(cbo_id_silo1.SelectedValue)
                If Not (cbo_id_silo2.SelectedValue.Trim().Equals(String.Empty)) Then
                    rplaca.id_nr_silo2 = Convert.ToInt32(cbo_id_silo2.SelectedValue)
                Else
                    rplaca.id_nr_silo2 = 0
                End If
                rplaca.dt_ini_CIP = txt_dt_ini_cip.Text & " " & txt_hr_ini_cip.Text & ":" & txt_mm_ini_cip.Text & ":00"
                rplaca.dt_fim_CIP = txt_dt_fim_cip.Text & " " & txt_hr_fim_cip.Text & ":" & txt_mm_fim_cip.Text & ":00"
                If Not txt_nr_ph_solucao.Text.Trim.Equals(String.Empty) Then
                    rplaca.nr_ph_solucao = Convert.ToDecimal(txt_nr_ph_solucao.Text)
                End If
                rplaca.id_modificador = Session("id_login")

                'fran themis batch i
                rplaca.st_leite_descarregado = cbo_leite_descarregado.SelectedValue
                'rplaca.st_motivo_leite_nao_descarregado = cbo_motido_leite_nao_descarregado.SelectedValue
                If rplaca.st_leite_descarregado = "N" Then
                    'rplaca.nr_volume_descarregado = 0    'Fran 22/05/2012 chamado1548 i desabilitado deve continuar a ser preenchido pois romaneio rejeitado tb pode ir para o batch

                End If
                'fran themis batch f
                'fran 16/05/2012 i chamadi 1548
                If CDec(lbl_nr_total_volume_rejeitado.Text) > 0 Then
                    rplaca.st_destino_leite_rejeitado = cbo_destino_leite_rejeitado.SelectedValue
                End If
                'fran 16/05/2012 i chamadi 1548

                rplaca.updateRomaneioPlaca()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.id_menu_item = 63
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio_placa").ToString
                usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                usuariolog.ds_nm_processo = "Registros Finais - Placas"
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 


                messageControl.Alert("Dados para Placa " & rplaca.ds_placa & " salvos com sucesso.")

                Response.Redirect("frm_romaneio_registros_finais.aspx?id_romaneio=" + ViewState.Item("id_romaneio"))


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_romaneio_registros_finais.aspx?id_romaneio=" + ViewState.Item("id_romaneio"))


    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("frm_romaneio_registros_finais.aspx?id_romaneio=" + ViewState.Item("id_romaneio"))

    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub




    Protected Sub grdlacres_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdlacres.PageIndexChanging
        grdlacres.PageIndex = e.NewPageIndex

    End Sub

    Protected Sub grdlacres_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdlacres.RowCancelingEdit
        Try

            grdlacres.EditIndex = -1
            loadgridlacre()
            'loadgridcompartimento()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub grdlacres_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdlacres.RowEditing
        Try

            grdlacres.EditIndex = e.NewEditIndex
            loadgridlacre()
            'loadgridcompartimento()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub grdlacres_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdlacres.RowUpdating
        'Capturar valores
        Dim row As GridViewRow = grdlacres.Rows(e.RowIndex)
        Try
            Dim lacre As New RomaneioLacre(grdlacres.DataKeys.Item(e.RowIndex).Value)

            If (Not (row) Is Nothing) Then

                Dim txt_nr_lacre_saida As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_lacre_saida"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                lacre.nr_lacre_saida = txt_nr_lacre_saida.Text.Trim.ToString
            End If
            lacre.id_modificador = Session("id_login")

            lacre.updateRomaneioLacre()


            grdlacres.EditIndex = -1
            loadgridlacre()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadgridlacre()

        Try

            Dim id_romaneio_placa As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_placa").ToString)
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

    Protected Sub cv_lacres_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_lacres.ServerValidate

        Try
            Dim id_romaneio_placa As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_placa").ToString)
            Dim lacre As New RomaneioLacre

            lacre.id_romaneio_placa = id_romaneio_placa

            Dim dslacre As DataSet = lacre.getRomaneioLacresByFilters()
            Dim row As DataRow
            args.IsValid = True
            For Each row In dslacre.Tables(0).Rows
                If Not IsDBNull(row.Item("nr_lacre_saida")) Then
                    If row.Item("nr_lacre_saida").ToString.Equals(String.Empty) Then
                        args.IsValid = False
                    End If
                Else
                    args.IsValid = False
                    Exit For
                End If
            Next
            If args.IsValid = False Then
                messageControl.Alert("Todos os lacres de saída devem ser preenchidos para continuar.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)

    End Sub
    'themis batch
    Protected Sub cbo_leite_descarregado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_leite_descarregado.SelectedIndexChanged
        If cbo_leite_descarregado.SelectedValue.Equals("N") Then
            'Fran 22/05/2012 chamado1548 i desabilitado deve continuar a ser preenchido pois romaneio rejeitado tb pode ir para o batch
            'txt_nr_volume_descarregado.Text = String.Empty
            'txt_dt_ini_descarga.Text = String.Empty
            'txt_dt_fim_descarga.Text = String.Empty
            'txt_hr_ini_descarga.Text = String.Empty
            'txt_hr_fim_descarga.Text = String.Empty
            'txt_mm_ini_descarga.Text = String.Empty
            'txt_mm_fim_descarga.Text = String.Empty
            ''cbo_motido_leite_nao_descarregado.SelectedValue = String.Empty
            ''cbo_id_silo1.SelectedValue = String.Empty
            'cbo_id_silo2.SelectedValue = String.Empty
            'txt_dt_ini_descarga.Enabled = False
            'txt_dt_fim_descarga.Enabled = False
            'txt_hr_ini_descarga.Enabled = False
            'txt_hr_fim_descarga.Enabled = False
            'txt_mm_ini_descarga.Enabled = False
            'txt_mm_fim_descarga.Enabled = False
            ''cbo_motido_leite_nao_descarregado.Enabled = False
            ''lbl_motivo.Enabled = False
            ''            cbo_id_silo1.Enabled = False
            'cbo_id_silo2.Enabled = False
            'rv_inidescarga.Enabled = False
            'rv_fimdescarga.Enabled = False
            'rv_mininidescarga.Enabled = False
            'rv_hrinidescarga.Enabled = False
            'rv_minfimdescarga.Enabled = False
            'rv_hrfimdescarga.Enabled = False
            'Fran 22/05/2012 chamado1548 f desabilitado deve continuar a ser preenchido pois romaneio rejeitado tb pode ir para o batch

        Else
            'cbo_motido_leite_nao_descarregado.Enabled = True
            'lbl_motivo.Enabled = True
            'cbo_id_silo1.Enabled = True
            'Fran 22/05/2012 chamado1548 i desabilitado deve continuar a ser preenchido pois romaneio rejeitado tb pode ir para o batch

            'cbo_id_silo2.Enabled = True
            'txt_dt_ini_descarga.Enabled = True
            'txt_dt_fim_descarga.Enabled = True
            'txt_hr_ini_descarga.Enabled = True
            'txt_hr_fim_descarga.Enabled = True
            'txt_mm_ini_descarga.Enabled = True
            'txt_mm_fim_descarga.Enabled = True
            'txt_hr_ini_descarga.Text = Format(DateTime.Parse(Now), "HH")
            'txt_mm_ini_descarga.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
            'txt_dt_ini_descarga.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            'txt_hr_fim_descarga.Text = Format(DateTime.Parse(Now), "HH")
            'txt_mm_fim_descarga.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
            'txt_dt_fim_descarga.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            'rv_inidescarga.Enabled = True
            'rv_fimdescarga.Enabled = True
            'rv_mininidescarga.Enabled = True
            'rv_hrinidescarga.Enabled = True
            'rv_minfimdescarga.Enabled = True
            'rv_hrfimdescarga.Enabled = True
            'Fran 22/05/2012 chamado1548 f desabilitado deve continuar a ser preenchido pois romaneio rejeitado tb pode ir para o batch

        End If
    End Sub

    Protected Sub cv_destino_leite_rejeitado_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_destino_leite_rejeitado.ServerValidate
        Try
            args.IsValid = True
            If cbo_destino_leite_rejeitado.SelectedValue = String.Empty Then
                args.IsValid = False
            End If
            If args.IsValid = False Then
                messageControl.Alert("Preencha o campo Destino Leite Rejeitado para continuar.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class
