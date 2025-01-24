Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_contrato_adicional_volume
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_contrato_adicional_volume.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try
            Dim indicadortipo As New IndicadorTipo
            indicadortipo.id_situacao = 1
            cbo_indicador_tipo.DataSource = indicadortipo.getIndicadorTipoByFilters()
            cbo_indicador_tipo.DataTextField = "cd_indicador_tipo"
            cbo_indicador_tipo.DataValueField = "id_indicador_tipo"
            cbo_indicador_tipo.DataBind()
            cbo_indicador_tipo.Items.FindByValue("1").Selected = True 'forca cpea nacional

            If Not (Request("id_contrato_validade") Is Nothing) Then
                ViewState.Item("id_contrato_validade") = Request("id_contrato_validade")
                ViewState.Item("id_contrato") = Request("id_contrato")
                loadData()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()

        Try

            Dim contratovalidade As New Contrato
            Dim dscontratovalidade As DataSet

            contratovalidade.id_contrato_validade = Convert.ToInt32(ViewState.Item("id_contrato_validade"))
            dscontratovalidade = contratovalidade.getContratoSuasValidades()

            'CABEÇALHO
            If dscontratovalidade.Tables(0).Rows.Count > 0 Then
                With dscontratovalidade.Tables(0).Rows(0)
                    lbl_estabelecimento.Text = .Item("ds_estabelecimento").ToString
                    lbl_contrato.Text = String.Concat(.Item("cd_contrato").ToString, " - ", .Item("nm_contrato").ToString)
                    lbl_contrato_padrao.Text = IIf(.Item("st_contrato_comercial").ToString.Equals("S"), "SIM", "NÃO")
                    lbl_contrato_mercado.Text = IIf(.Item("st_contrato_mercado").ToString.Equals("S"), "SIM", "NÃO")
                    lbl_referencia.Text = DateTime.Parse(.Item("dt_referencia").ToString).ToString("MM/yyyy")
                    lbl_situacao.Text = .Item("nm_situacao").ToString
                    lbl_situacao_contrato.Text = String.Concat(.Item("nm_situacao_contrato_validade").ToString, " - ", .Item("nm_situacao_contrato").ToString)
                    ViewState.Item("id_estabelecimento") = .Item("id_estabelecimento").ToString
                    ViewState.Item("dt_referencia") = .Item("dt_referencia").ToString
                    ViewState.Item("id_situacao_contrato") = .Item("id_situacao_contrato").ToString

                    'se o contrato estiver inativo ou contrato validade estiver inativo
                    If .Item("id_situacao").ToString = 2 OrElse .Item("id_situacao_contrato_validade").ToString = 2 Then
                        grdAdicionalVolume.Columns.Item(6).Visible = True 'não deixa exluir
                        tr_painelincluir.Visible = False
                    End If
                    'se a situacao contrato estiver aprovado, reprovado em 1 ou 2 nivel, nao pode exluir
                    If Not (.Item("id_situacao_contrato").ToString = 1) AndAlso Not (.Item("id_situacao_contrato").ToString = 2) Then
                        grdAdicionalVolume.Columns.Item(6).Visible = True 'não deixa exluir
                        tr_painelincluir.Visible = False
                    End If
                    lbl_modificador.Text = .Item("id_modificador_validade").ToString()
                    lbl_dt_modificacao.Text = .Item("dt_modificacao_validade").ToString()

                End With
            End If

            loadGridAdicionalVolume()



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadGridAdicionalVolume()

        Try

            Dim contratoadicvolume As New ContratoAdicionalVolume

            contratoadicvolume.id_contrato_validade = Convert.ToInt32(ViewState.Item("id_contrato_validade"))
            contratoadicvolume.id_situacao = 1

            Dim dscontratovolume As DataSet = contratoadicvolume.getContratoAdicionalVolumeByFilters()

            If (dscontratovolume.Tables(0).Rows.Count > 0) Then
                grdAdicionalVolume.Visible = True
                grdAdicionalVolume.DataSource = Helper.getDataView(dscontratovolume.Tables(0), "")
                grdAdicionalVolume.DataBind()
            Else
                grdAdicionalVolume.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_contrato.aspx?id_contrato_validade=" & ViewState.Item("id_contrato_validade").ToString & "&id_contrato=" & ViewState.Item("id_contrato").ToString)
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("frm_contrato.aspx?id_contrato_validade=" & ViewState.Item("id_contrato_validade").ToString & "&id_contrato=" & ViewState.Item("id_contrato").ToString)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub btn_incluirqualidade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_incluirqualidade.Click
        Try

            If Page.IsValid Then

                Dim contratovolume As New ContratoAdicionalVolume()
                Dim batualizousituacao As Boolean = False
                'BUSCAR DADOS DOS CAMPOS INFORMADOS PARA INCLUSAO

                If Not (txt_nr_litros_ini.Text.Trim().Equals(String.Empty)) Then
                    contratovolume.nr_litros_ini = Convert.ToInt64(txt_nr_litros_ini.Text)
                End If

                If Not (txt_nr_litros_fim.Text.Trim().Equals(String.Empty)) Then
                    contratovolume.nr_litros_fim = Convert.ToInt64(txt_nr_litros_fim.Text)
                End If

                contratovolume.id_indicador_tipo = cbo_indicador_tipo.SelectedValue
                If Not (txt_nr_indicador_percentual.Text.Trim().Equals(String.Empty)) Then
                    contratovolume.nr_indicador_percentual = Convert.ToDouble(txt_nr_indicador_percentual.Text)
                End If
                contratovolume.nr_mes_indicador = cbo_nr_mes_indicador.SelectedValue

                If Not (txt_nr_adicional_24hrs.Text.Trim().Equals(String.Empty)) Then
                    contratovolume.nr_adicional_24hrs = Convert.ToDouble(txt_nr_adicional_24hrs.Text)
                End If
                contratovolume.st_formato_24hrs = cbo_st_formato_24hrs.SelectedValue
                If Not (txt_nr_adicional_48hrs.Text.Trim().Equals(String.Empty)) Then
                    contratovolume.nr_adicional_48hrs = Convert.ToDouble(txt_nr_adicional_48hrs.Text)
                End If
                contratovolume.st_formato_48hrs = cbo_st_formato48hrs.SelectedValue

                'BUSCAR DADOS CABECALHO QUE VEM DE CONTRATO 
                contratovolume.id_situacao = 1
                contratovolume.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
                contratovolume.dt_referencia = DateTime.Parse(ViewState.Item("dt_referencia").ToString).ToString("dd/MM/yyyy")
                contratovolume.id_contrato_validade = Convert.ToInt32(ViewState.Item("id_contrato_validade"))
                contratovolume.id_modificador = Session("id_login")

                'incluir adicional volume
                contratovolume.insertContratoAdicionalVolume()

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.ds_nm_processo = "Contrato - Adicional Volume"
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                If ViewState.Item("id_situacao_contrato").ToString.Equals("1") Then 'se situacao contrato aberta
                    'verifica se ja incluiu volume
                    Dim qualidade As New FaixaQualidade
                    qualidade.id_contrato_validade = contratovolume.id_contrato_validade
                    qualidade.id_situacao = 1
                    'se encontrou linhas salvas em adicional de volume
                    If qualidade.getFaixaQualidadeByFilters.Tables(0).Rows.Count > 0 Then
                        Dim contrato As New ContratoValidade
                        contrato.id_contrato_validade = contratovolume.id_contrato_validade
                        contrato.id_modificador = contratovolume.id_modificador
                        contrato.id_situacao_contrato = 2 'Completo
                        contrato.updateContratoValidadeSituacao() 'atualiza situcao contrato para completo
                        batualizousituacao = True
                    End If
                End If
                messageControl.Alert("Registro inserido com sucesso.")

                'atualiza tela
                txt_nr_litros_ini.Text = String.Empty
                txt_nr_litros_fim.Text = String.Empty
                txt_nr_indicador_percentual.Text = String.Empty
                txt_nr_adicional_24hrs.Text = String.Empty
                txt_nr_adicional_48hrs.Text = String.Empty
                If batualizousituacao = True Then
                    loadData()
                Else
                    loadGridAdicionalVolume()

                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub grdAdicionalVolume_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdAdicionalVolume.PageIndexChanging
        grdAdicionalVolume.PageIndex = e.NewPageIndex
        loadGridAdicionalVolume()

    End Sub

    Protected Sub grdAdicionalVolume_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdAdicionalVolume.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "delete"
                deleteadicionalvolume(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteAdicionalVolume(ByVal id_contrato_adicional_volume As Integer)

        Try

            Dim contratovolume As New ContratoAdicionalVolume()
            contratovolume.id_contrato_adicional_volume = id_contrato_adicional_volume
            contratovolume.id_modificador = Convert.ToInt32(Session("id_login"))
            contratovolume.deleteContratoAdicionalVolume()


            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.ds_nm_processo = "Contrato - Adicional Volume"
            usuariolog.id_nr_processo = id_contrato_adicional_volume
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadGridAdicionalVolume()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdAdicionalVolume_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAdicionalVolume.RowDataBound
        Try

            If (e.Row.RowType <> DataControlRowType.Header _
                And e.Row.RowType <> DataControlRowType.Footer _
                And e.Row.RowType <> DataControlRowType.Pager) Then

                Dim lbl_nr_mes_indicador As Label = CType(e.Row.FindControl("lbl_nr_mes_indicador"), Label)
                Dim lbl_referencia_indicador As Label = CType(e.Row.FindControl("lbl_referencia_indicador"), Label)

                Select Case CInt(lbl_nr_mes_indicador.Text)
                    Case 0
                        lbl_referencia_indicador.Text = "Mês Atual"
                    Case -1
                        lbl_referencia_indicador.Text = "Mês -1"
                    Case -2
                        lbl_referencia_indicador.Text = "Mês -2"
                    Case -3
                        lbl_referencia_indicador.Text = "Mês -3"
                    Case -4
                        lbl_referencia_indicador.Text = "Mês -4"
                    Case -5
                        lbl_referencia_indicador.Text = "Mês -5"

                End Select

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub grdAdicionalVolume_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdAdicionalVolume.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub cv_adicionalvolume_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_adicionalvolume.ServerValidate
        Try
            Dim lmsg As String
            Dim contratoadicional As New ContratoAdicionalVolume

            args.IsValid = True

            contratoadicional.id_contrato_validade = Convert.ToInt32(ViewState.Item("id_contrato_validade").ToString)
            contratoadicional.id_situacao = 1
            contratoadicional.nr_litros = Convert.ToInt64(txt_nr_litros_ini.Text)
            If contratoadicional.getContratoAdicionalVolumeByFilters.Tables(0).Rows.Count > 0 Then
                lmsg = "O valor da faixa de Litros por Dia Inicial informada já existe entre as faixas desta contrato."
                args.IsValid = False
            End If

            If args.IsValid = True Then
                contratoadicional.nr_litros = Convert.ToInt64(txt_nr_litros_ini.Text)
                If contratoadicional.getContratoAdicionalVolumeByFilters.Tables(0).Rows.Count > 0 Then
                    lmsg = "O valor da faixa de Litros por Dia Final informada já existe entre as faixas desta contrato."
                    args.IsValid = False
                End If
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class
