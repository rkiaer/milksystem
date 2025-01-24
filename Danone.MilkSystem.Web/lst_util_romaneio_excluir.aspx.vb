Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail

Partial Class lst_util_romaneio_excluir


    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_util_romaneio_excluir.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 199
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

        End If


    End Sub



    Protected Sub btn_executar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_executar.Click
        If Page.IsValid Then

            Try
                Dim lmsg As String

                Dim utilitario As New Utilitario
                utilitario.id_romaneio = Convert.ToInt32(txt_nr_romaneio.Text.Trim)
                utilitario.excluirRomaneio()
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 199
                usuariolog.id_nr_processo = txt_nr_romaneio.Text
                usuariolog.nm_nr_processo = txt_nr_romaneio.Text

                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                lmsg = String.Concat("Exclusão do romaneio ", Me.txt_nr_romaneio.Text, " realizada com sucesso!")
                messageControl.Alert(lmsg)

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub

    Protected Sub txt_nr_romaneio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nr_romaneio.TextChanged
        Dim romaneio As New Romaneio

        ViewState.Item("st_exportacao_batch") = String.Empty
        ViewState.Item("st_exportacao_frete") = String.Empty
        ViewState.Item("id_st_romaneio") = String.Empty
        ViewState.Item("dt_referencia") = String.Empty
        ViewState.Item("dt_ultimo_calculo") = String.Empty
        ViewState.Item("st_leite_pago_referencia") = String.Empty

        If Me.txt_nr_romaneio.Text.Trim.Equals(String.Empty) Then
            lbl_situacao.Text = String.Empty
            lbl_ds_estabelecimento.Text = String.Empty
            lbl_dt_abertura.Text = String.Empty
            lbl_transit_point.Text = String.Empty
            lbl_transbordo.Text = String.Empty
            lbl_exportacao_batch.Text = String.Empty
            lbl_exportacao_frete.Text = String.Empty
            lbl_ultimo_calculo.Text = String.Empty
        Else
            romaneio.id_romaneio = Convert.ToInt32(Me.txt_nr_romaneio.Text.Trim)
            Dim dsromaneio As DataSet = romaneio.getRomaneioByFilters()

            If dsromaneio.Tables(0).Rows.Count > 0 Then
                With dsromaneio.Tables(0).Rows(0)

                    ViewState.Item("id_st_romaneio") = .Item("id_st_romaneio").ToString()

                    lbl_situacao.Text = .Item("nm_st_romaneio").ToString()
                    lbl_ds_estabelecimento.Text = .Item("ds_estabelecimento").ToString()
                    lbl_dt_abertura.Text = Format(DateTime.Parse(.Item("dt_hora_entrada")), "dd/MM/yyyy HH:mm").ToString
                    lbl_transit_point.Text = .Item("id_transit_point").ToString()
                    If .Item("st_romaneio_transbordo").ToString().Equals("S") Then
                        lbl_transbordo.Text = "Sim"
                    Else
                        lbl_transbordo.Text = String.Empty
                    End If
                    If Not IsDBNull(.Item("st_exportacao_batch")) AndAlso .Item("st_exportacao_batch").ToString().Equals("S") Then
                        lbl_exportacao_batch.Text = "Sim"
                        ViewState.Item("st_exportacao_batch") = "S"
                    Else
                        lbl_exportacao_batch.Text = String.Empty
                    End If
                    If Not IsDBNull(.Item("st_exportacao_frete")) AndAlso .Item("st_exportacao_frete").ToString().Equals("S") Then
                        lbl_exportacao_frete.Text = "Sim"
                        ViewState.Item("st_exportacao_frete") = "S"
                    Else
                        lbl_exportacao_frete.Text = String.Empty
                    End If

                    Dim dsromaneiocalculado As DataSet = romaneio.getRomaneioCalculado
                    If dsromaneiocalculado.Tables(0).Rows.Count > 0 Then
                        ViewState.Item("dt_ultimo_calculo") = Format(DateTime.Parse(dsromaneiocalculado.Tables(0).Rows(0).Item("ultima_referencia").ToString), "dd/MM/yyyy").ToString
                        lbl_ultimo_calculo.Text = Format(DateTime.Parse(ViewState.Item("dt_ultimo_calculo")), "MMM/yyyy").ToString

                        If ViewState.Item("id_st_romaneio").ToString.Equals("4") Then
                            ViewState.Item("dt_referencia") = Format(DateTime.Parse(dsromaneiocalculado.Tables(0).Rows(0).Item("dt_referencia")), "dd/MM/yyyy").ToString
                            ViewState.Item("st_leite_pago_referencia") = dsromaneiocalculado.Tables(0).Rows(0).Item("st_leite_pago_referencia").ToString
                        End If
                    End If
                End With
            Else
                lbl_situacao.Text = String.Empty
                lbl_ds_estabelecimento.Text = String.Empty
                lbl_dt_abertura.Text = String.Empty
                lbl_transit_point.Text = String.Empty
                lbl_transbordo.Text = String.Empty
                lbl_exportacao_batch.Text = String.Empty
                lbl_exportacao_frete.Text = String.Empty
                lbl_ultimo_calculo.Text = String.Empty

            End If
        End If

    End Sub

    Protected Sub cv_romaneio_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_romaneio.ServerValidate
        Try

            Dim lmsg As String

            args.IsValid = True

            If lbl_situacao.Text.Equals(String.Empty) Then

                lmsg = "O romaneio de número " + txt_nr_romaneio.Text.ToString + " não existe nos cadastros!"
                args.IsValid = False

            Else
                Select Case CInt(ViewState.Item("id_st_romaneio").ToString)
                    Case 4
                        If ViewState.Item("st_leite_pago_referencia").ToString.Equals("S") Then
                            args.IsValid = False
                            lmsg = "O romaneio de número " + txt_nr_romaneio.Text.ToString + " não pode ser excluído porque já entrou para o cálculo mensal definitivo."
                        Else
                            'se a referencia do mapa leite do romaneio for maior ou igual a data do ultimo calculo realizado no milk
                            If CDate(ViewState.Item("dt_referencia").ToString) >= CDate(ViewState.Item("dt_ultimo_calculo").ToString) Then
                                If ViewState.Item("st_exportacao_batch").Equals("S") Then
                                    args.IsValid = False
                                    lmsg = "O romaneio de número " + txt_nr_romaneio.Text.ToString + " não pode ser excluído porque o BATCH já foi exportado."
                                End If
                                If ViewState.Item("st_exportacao_frete").Equals("S") Then
                                    args.IsValid = False
                                    lmsg = "O romaneio de número " + txt_nr_romaneio.Text.ToString + " não pode ser excluído porque o FRETE já foi exportado."
                                End If
                            Else
                                args.IsValid = False
                                lmsg = "O romaneio de número " + txt_nr_romaneio.Text.ToString + " não pode ser excluído porque já foi realizado Cálculo Mensal Definitivo após sua finalização."

                            End If
                        End If
                    Case Is < 4
                        If ViewState.Item("st_exportacao_batch").Equals("S") Then
                            args.IsValid = False
                            lmsg = "O romaneio de número " + txt_nr_romaneio.Text.ToString + " não pode ser excluído porque o BATCH já foi exportado."
                        End If
                    Case Is > 4
                        args.IsValid = False
                        lmsg = "O romaneio de número " + txt_nr_romaneio.Text.ToString + " não pode ser excluído porque é um pré romaneio de Transit Point."
                End Select

            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
