Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Imports System.Net.Mail
Imports System.IO


Partial Class frm_transferencia_volume
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_transferencia_volume.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades Origem"
        End With
        With btn_lupa_propriedade_destino
            .Attributes.Add("onclick", "javascript:ShowDialogPropDestino()")
            .ToolTip = "Filtrar Propriedades Destino"
        End With

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            If Not (Request("id_propriedade") Is Nothing) Then
                ViewState.Item("id_propriedade") = Request("id_propriedade")
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                ViewState.Item("dt_referencia") = Request("dt_referencia")
                ViewState.Item("nr_volume_anual") = Request("nr_volume_anual")
                'carrega cotações
                tr_referencia.Visible = True

                tr_buscardados.Visible = False
                btn_buscardados.Visible = False
                loadData()
            Else
                ViewState.Item("id_propriedade") = "0"
                tr_buscardados.Visible = True
                btn_buscardados.Visible = True
                tr_referencia.Visible = True
                gridResults.Visible = True
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()

        Try

            cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString
            cbo_estabelecimento.Enabled = False
            lk_transferir_volumes.Enabled = True
            txt_dt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("MM/yyyy")
            txt_dt_referencia.Enabled = False
            lbl_nr_volume_anual_coletado.Text = FormatNumber(ViewState.Item("nr_volume_anual"), 0)

            Dim propriedade As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade")))
            txt_id_propriedade.Text = propriedade.id_propriedade.ToString
            txt_id_propriedade.Enabled = False
            btn_lupa_propriedade.Visible = False
            lbl_nm_propriedade.Text = propriedade.nm_propriedade.ToString
            lbl_nm_cidade.Text = propriedade.nm_cidade
            lbl_cd_uf.Text = propriedade.cd_uf
            lbl_nm_produtor.Text = String.Concat(propriedade.cd_pessoa, " - ", propriedade.nm_pessoa)

            If Not (ViewState.Item("id_propriedade_destino") Is Nothing) Then
                If CLng(ViewState.Item("id_propriedade_destino")) > 0 Then
                    Dim prop As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade_destino")))
                    txt_id_propriedade_destino.Text = prop.id_propriedade.ToString
                    btn_lupa_propriedade_destino.Visible = False
                    lbl_nm_propriedade_destino.Text = prop.nm_propriedade.ToString
                    lbl_nm_cidade_destino.Text = prop.nm_cidade
                    lbl_cd_uf_destino.Text = prop.cd_uf
                    lbl_produtor_destino.Text = String.Concat(prop.cd_pessoa, " - ", prop.nm_pessoa)
                End If
            End If


            loadGrid()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_transferencia_volume.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_transferencia_volume.aspx")


    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_transferencia_volume.aspx")


    End Sub

    Private Sub carregarCamposPropriedade()

        Try

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                carregarCamposPropriedadeProdutor(Convert.ToInt32(Me.hf_id_propriedade.Value.ToString))
                ViewState.Item("id_propriedade") = Me.hf_id_propriedade.Value.ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click

        carregarCamposPropriedade()
        'carrega combo unid produção
        'loadUnidProducaobyPropriedade()
        carregarCamposPropriedadeProdutor(Convert.ToInt32(ViewState.Item("id_propriedade").ToString))

    End Sub
    'Private Sub loadUnidProducaobyPropriedade()

    '    Try

    '        Dim up As New UnidadeProducao
    '        up.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
    '        cbo_unid_producao_destino.DataSource = up.getUnidadeProducaoByFilters
    '        cbo_unid_producao_destino.DataTextField = "nr_unid_producao"
    '        cbo_unid_producao_destino.DataValueField = "id_unid_producao"
    '        cbo_unid_producao_destino.DataBind()
    '        cbo_unid_producao_destino.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    Protected Sub txt_id_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_propriedade.TextChanged
        lbl_nm_propriedade.Text = String.Empty
        lbl_nm_propriedade.Visible = False
        hf_id_propriedade.Value = String.Empty
        ViewState.Item("id_propriedade") = 0
        'se propriedade é valida
        If Not txt_id_propriedade.Text.ToString.Equals(String.Empty) Then
            If validarPropriedade(txt_id_propriedade.Text).Tables(0).Rows.Count > 0 Then
                ViewState.Item("id_propriedade") = txt_id_propriedade.Text.Trim
                hf_id_propriedade.Value = txt_id_propriedade.Text.Trim
                carregarCamposPropriedadeProdutor(Convert.ToInt32(txt_id_propriedade.Text.Trim))
                'loadUnidProducaobyPropriedade()
            End If
        Else
            lbl_cd_uf.Text = String.Empty
            lbl_nm_cidade.Text = String.Empty
            lbl_nm_produtor.Text = String.Empty

        End If

    End Sub
    Private Function validarPropriedade(ByVal id_propriedade As Int32) As DataSet

        Try

            Dim propriedade As New Propriedade()

            propriedade.id_propriedade = id_propriedade
            validarPropriedade = propriedade.getPropriedadeByFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function
    Private Sub carregarCamposPropriedadeProdutor(ByVal id_propriedade As Int32)
        Try
            Dim propriedade As New Propriedade(id_propriedade)
            Dim produtor As New Pessoa(propriedade.id_pessoa)

            Me.txt_id_propriedade.Text = id_propriedade
            Me.lbl_nm_propriedade.Visible = True
            Me.lbl_nm_propriedade.Text = propriedade.nm_propriedade
            lbl_cd_uf.Text = propriedade.cd_uf
            lbl_nm_cidade.Text = propriedade.nm_cidade
            lbl_nm_produtor.Text = String.Concat(produtor.cd_pessoa, " - ", produtor.nm_pessoa)
            lbl_cd_ie.text = propriedade.cd_inscricao_estadual



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


 

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub
    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()
            Case "cotacoes"

                'If gridResults.EditIndex = -1 Then

                '    Dim lbl_id_central_cotacao_item As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_central_cotacao_item"), Label)
                '    Dim lbl_item As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_item"), Label)
                '    Dim lbl_nr_quantidade As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_nr_quantidade"), Label)
                '    Dim cd_item As DataControlFieldCell = CType(gridResults.Rows.Item(e.CommandArgument.ToString).Cells(1), DataControlFieldCell)
                '    Dim nm_item As DataControlFieldCell = CType(gridResults.Rows.Item(e.CommandArgument.ToString).Cells(2), DataControlFieldCell)
                '    Dim st_ver_mercado As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("st_ver_mercado"), Label)
                '    Dim lbl_ds_tipo_medida As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_ds_tipo_medida"), Label)   ' Adriana 16/06/2010 - chamado 870
                '    ViewState.Item("id_central_cotacao_item") = lbl_id_central_cotacao_item.Text
                '    ViewState.Item("lbl_detalhe_item") = String.Concat(cd_item.Text, " - ", nm_item.Text)
                '    ViewState.Item("id_item") = lbl_item.Text
                '    ViewState.Item("nr_quantidade_item") = lbl_nr_quantidade.Text
                '    ViewState.Item("st_ver_mercado") = st_ver_mercado.Text
                '    ViewState.Item("ds_tipo_medida") = lbl_ds_tipo_medida.Text   ' Adriana 16/06/2010 - chamado 870
                '    If ViewState.Item("id_situacao_cotacao") < 3 Then
                '        btn_adicionar_cotacao.Enabled = True
                '    End If
                '    loadGridItens()
                'End If
                'loadGridCotacoes()

            Case "delete"
                'deleteItemCotacao(Convert.ToInt32(e.CommandArgument.ToString()))


        End Select



    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim chk_selec As Anthem.CheckBox = CType(e.Row.FindControl("chk_selec"), Anthem.CheckBox)

                If chk_selec.Checked = True Then
                    ViewState.Item("volume_selecionado") = FormatNumber(CDec(ViewState.Item("volume_selecionado")) + CDec(e.Row.Cells(3).Text), 0).ToString
                End If

                ViewState.Item("volume_mensal") = CDec(ViewState.Item("volume_mensal")) + CDec(e.Row.Cells(3).Text)
                'acerta volume, retirando casas decimais
                e.Row.Cells(3).Text = FormatNumber(e.Row.Cells(3).Text, 0)
                'Acerta situacao romaneio
                Select Case e.Row.Cells(4).Text.ToString.Trim
                    Case "1"
                        e.Row.Cells(4).Text = "Aberto Incompleto"
                    Case "2"
                        e.Row.Cells(4).Text = "Aberto"
                    Case "3"
                        e.Row.Cells(4).Text = "Em Análise"
                    Case "4"
                        e.Row.Cells(4).Text = "Fechado"
                End Select
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadGrid()


        Try

            Dim transfvolume As New TransferenciaVolume
            transfvolume.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            transfvolume.dt_referencia = ViewState.Item("dt_referencia").ToString
            Dim dsvolumes As DataSet = transfvolume.getTransferenciaVolumeByPropriedade()
            ViewState.Item("volume_selecionado") = 0
            ViewState.Item("volume_mensal") = 0

            If (dsvolumes.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsvolumes.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                lbl_nr_volume_selecionado.Text = ViewState.Item("volume_selecionado").ToString
                lbl_nr_volume_mensal.Text = ViewState.Item("volume_mensal").ToString
                ViewState.Item("volume_selecionado") = 0
                ViewState.Item("volume_mensal") = 0

                Dim dsvolumemensal As DataSet = transfvolume.getVolumeMensalByPropriedade
                If dsvolumemensal.Tables(0).Rows.Count > 0 Then
                    lbl_nr_volume_mensal.Text = FormatNumber(dsvolumemensal.Tables(0).Rows(0).Item("nr_volume_mensal"), 0)
                    ViewState.Item("volume_aberto") = FormatNumber(dsvolumemensal.Tables(0).Rows(0).Item("nr_volume_aberto"), 0)
                End If

            Else
                gridResults.Visible = False
                messageControl.Alert("Não há volume de leite coletado para a propriedade origem, na referência informada. A transferência de volume não pode ser efetuada.")
                lk_transferir_volumes.Enabled = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try


    End Sub
 
    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True

    End Sub



    Protected Sub lk_transferir_volumes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_transferir_volumes.Click
        If Page.IsValid Then
            Try
                Dim transfvolume As New TransferenciaVolume()
                Dim row As GridViewRow
                transfvolume.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
                transfvolume.dt_referencia = ViewState.Item("dt_referencia")
                transfvolume.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                transfvolume.id_propriedade_origem = transfvolume.id_propriedade
                transfvolume.id_propriedade_destino = Convert.ToInt32(ViewState.Item("id_propriedade_destino"))
                transfvolume.nr_unid_producao_destino = Convert.ToInt32(cbo_unid_producao_destino.SelectedItem.Text)
                transfvolume.id_unid_producao_destino = Convert.ToInt32(cbo_unid_producao_destino.SelectedValue)
                transfvolume.nr_volume_anual_fechado = Convert.ToDecimal(ViewState.Item("volume_anual"))
                transfvolume.nr_volume_mensal = Convert.ToDecimal(lbl_nr_volume_mensal.Text)
                transfvolume.nr_volume_aberto = Convert.ToDecimal(ViewState.Item("volume_aberto"))
                transfvolume.nr_volume_selecionado = Convert.ToDecimal(lbl_nr_volume_selecionado.Text)
                transfvolume.ano_referencia = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("yyyy")
                transfvolume.id_modificador = Session("id_login")
                transfvolume.st_transferencia_destino = ViewState.Item("st_transferencia_destino").ToString 'fran 07/2016

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 156
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log

                For Each row In gridResults.Rows
                    Dim id_romaneio As DataControlFieldCell = CType(row.Cells(1), DataControlFieldCell)
                    Dim chk As Anthem.CheckBox = CType(row.FindControl("chk_selec"), Anthem.CheckBox)

                    If chk.Checked = False Then
                        transfvolume.id_romaneio_selecionado.Add(id_romaneio.Text)
                    End If

                Next

                If transfvolume.transferirVolume() = True Then
                    'fran 08/12/2020 i dango
                    usuariolog.id_tipo_log = 9 'emil
                    usuariolog.id_menu_item = 156
                    usuariolog.insertUsuarioLog()

                    'fran 08/12/2020 f dango

                    'fran 19/07/2016 i
                    'envia mensagem informando sobre a transferencia
                    Dim notificacao As New Notificacao
                    Dim lAssunto As String = "Transferência Titularidade"
                    Dim lCorpo As String

                    If ViewState.Item("st_transferencia_destino").ToString.Equals("N") Then
                        lCorpo = String.Concat("Foi realizado no MILKSYSTEM, a transferência de titularidade da propriedade ", ViewState.Item("id_propriedade").ToString, ", produtor ", lbl_nm_produtor.Text, " PARA A propriedade ", ViewState.Item("id_propriedade_destino").ToString, ", do produtor ", lbl_produtor_destino.Text, ". Este processo entrará em vigor a partir da referência ", Right(ViewState.Item("dt_referencia").ToString.Trim, 7), ", salientando que, a propriedade origem foi inativada por transferência.")
                    Else
                        lCorpo = String.Concat("Foi realizado no MILKSYSTEM, a transferência de titularidade da propriedade ", ViewState.Item("id_propriedade").ToString, ", produtor ", lbl_nm_produtor.Text, " PARA A propriedade ", ViewState.Item("id_propriedade_destino").ToString, ", do produtor ", lbl_produtor_destino.Text, ". Este processo entrará em vigor a partir da referência ", Right(ViewState.Item("dt_referencia").ToString.Trim, 7), ", salientando que, a propriedade origem foi inativada por transferência e a propriedade destino foi reativada.")
                    End If
                    ' Parametro 16 - Transferencia de Titularidade
                    If notificacao.enviaMensagemEmail(16, lAssunto, lCorpo, MailPriority.High, , , Convert.ToInt32(ViewState.Item("id_estabelecimento"))) = True Then
                    End If
                    'fran 19/07/2016 f


                    messageControl.Alert("Transferência de Volume realizada com sucesso!")
                Else
                    messageControl.Alert("Ocorreram problemas na transferência de volumes. Contate o administrador do sistema.")

                End If


                loadDataDesabilitado()
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub cv_trasferencia_volume_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_trasferencia_volume.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True

            'valida calculo definitivo das propriedades
            If ValidarCalculoDefinitivo(lmsg, CLng(ViewState.Item("id_propriedade")), CLng(ViewState.Item("id_propriedade_destino"))) = False Then
                args.IsValid = False
            End If

            'valida se incrições estaduais são diferentes
            'se incrições forem vazias não há problema pois há propriedades sem ie
            If Not (lbl_cd_ie.Text.ToString.Trim.Equals(String.Empty) And lbl_cd_ie_destino.Text.ToString.Trim.Equals(String.Empty)) Then
                If lbl_cd_ie.Text.ToString.Trim = lbl_cd_ie_destino.Text.ToString.Trim Then
                    args.IsValid = False
                    lmsg = "As inscrições estaduais das propriedades devem ser diferentes."
                End If
            End If
            'valida se propriedades são diferentes
            If CLng(ViewState.Item("id_propriedade")) = CLng(ViewState.Item("id_propriedade_destino")) Then
                args.IsValid = False
                lmsg = "As propriedades origem e destino devem ser diferentes."
            End If

            If CLng(lbl_nr_volume_selecionado.Text) <= 0 Then
                args.IsValid = False
                lmsg = "Os volumes dos romaneios devem estar selecionados."
            End If

            'If CLng(lbl_nr_volume_selecionado.Text) <> CLng(lbl_nr_volume_mensal.Text) Then
            '    args.IsValid = False
            '    lmsg = "Todos os volumes dos romaneios devem estar selecionados para transferência."

            'End If
            If args.IsValid = True Then
                If CLng(ViewState.Item("id_propriedade")) > 0 And CLng(ViewState.Item("id_propriedade_destino")) > 0 Then
                    Dim proporigem As New Propriedade(ViewState.Item("id_propriedade"))
                    Dim propdestino As New Propriedade(ViewState.Item("id_propriedade_destino"))

                    If proporigem.id_propriedade_matriz = 0 Then
                        args.IsValid = False
                        lmsg = String.Concat("A propriedade origem não pode ser transferida porque não participa de grupo Matriz/Filial.")
                    End If

                    If propdestino.id_propriedade_matriz = 0 Then
                        args.IsValid = False
                        lmsg = String.Concat("A propriedade destino não pode receber transferência de volume porque não participa de grupo Matriz/Filial. Selecione outra propriedade.")
                    End If

                    If args.IsValid = True Then
                        If proporigem.id_propriedade_matriz <> propdestino.id_propriedade_matriz Then
                            args.IsValid = False
                            lmsg = String.Concat("A propriedade destino pertence ao grupo da Propriedade Matriz ", propdestino.id_propriedade_matriz.ToString, ", e a propriedade origem pertence ao grupo da Propriedade Matriz ", proporigem.id_propriedade_matriz.ToString, ". A transferência não pode ser realizada entre grupos de Matriz/Filial diferentes.")
                        End If
                    End If

                End If
            End If

            If args.IsValid = False Then


                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

 
    Private Function ValidarCalculoDefinitivo(ByRef lmsg As String, Optional ByVal pid_propriedade As Int64 = 0, Optional ByVal pid_propriedade_destino As Int64 = 0) As Boolean
        'validarcalculodefinitivo = false => significa que a rotina não é válida ou seja existe calculo definitivo
        'validarcalculodefinitivo = true => significa que a rotina é válida ou seja não existe calculo definitivo para propriedade

        Try
            ValidarCalculoDefinitivo = True

            Dim calcdefinitivo As New InterrupcaoFornecimento()
            calcdefinitivo.dt_referencia = String.Concat("01/", txt_dt_referencia.Text)
            'validar calculo para propriedade origem
            If pid_propriedade > 0 Then
                calcdefinitivo.id_propriedade = pid_propriedade
                'se tem calculo definitico para a propriedade não pode trasferir volume
                If calcdefinitivo.getCalculoDefinitivoByPropriedade > 0 Then
                    ValidarCalculoDefinitivo = False
                    lmsg = String.Concat("Há cálculo definitivo efetuado para a referência informada e propriedade ", pid_propriedade.ToString, ". A Transferência de volume não poderá ser realizada!")
                End If
            End If

            'validar calculo para propriedade destino
            If ValidarCalculoDefinitivo = True Then
                If pid_propriedade_destino > 0 Then
                    calcdefinitivo.id_propriedade = pid_propriedade_destino
                    'se tem calculo definitico para a propriedade destino não pode trasferir volume
                    If calcdefinitivo.getCalculoDefinitivoByPropriedade > 0 Then
                        ValidarCalculoDefinitivo = False
                        lmsg = String.Concat("A propriedade destino ", pid_propriedade.ToString, " já possui efetivação de cálculo definitivo para a referência informada. A Transferência de volume não poderá ser realizada para esta propriedade destino!")
                    End If
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Function


    Protected Sub btn_lupa_propriedade_destino_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade_destino.Click
        carregarCamposPropriedadeDestino()
        'carrega combo unid produção
        loadUnidProducaobyPropriedadeDestino()
        carregarCamposPropriedadeDestinoProdutor(Convert.ToInt32(ViewState.Item("id_propriedade_destino").ToString))

    End Sub
    Private Sub carregarCamposPropriedadeDestino()

        Try
            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                carregarCamposPropriedadeDestinoProdutor(Convert.ToInt32(Me.hf_id_propriedade_destino.Value.ToString))
                ViewState.Item("id_propriedade_destino") = Me.hf_id_propriedade_destino.Value.ToString
            End If
            'loadData()
            customPage.clearFilters("lupa_propriedade")
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposPropriedadeDestinoProdutor(ByVal id_propriedade_destino As Int32)
        Try
            Dim propriedade As New Propriedade(id_propriedade_destino)
            Dim produtor As New Pessoa(propriedade.id_pessoa)

            Me.txt_id_propriedade_destino.Text = id_propriedade_destino
            Me.lbl_nm_propriedade_destino.Visible = True
            Me.lbl_nm_propriedade_destino.Text = propriedade.nm_propriedade
            lbl_cd_uf_destino.Text = propriedade.cd_uf
            lbl_nm_cidade_destino.Text = propriedade.nm_cidade
            lbl_produtor_destino.Text = String.Concat(produtor.cd_pessoa, " - ", produtor.nm_pessoa)
            lbl_cd_ie_destino.Text = propriedade.cd_inscricao_estadual
            'Fran 19/07/2016 i 
            'se propriedade destino é inativa por transferencia, após o processo deve ativar propriedade destino
            If propriedade.id_situacao.Equals(2) Then
                ViewState.Item("st_transferencia_destino") = propriedade.st_transferencia
            Else
                ViewState.Item("st_transferencia_destino") = "N"
            End If
            'Fran 19/07/2016 f 


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadUnidProducaobyPropriedadeDestino()

        Try

            Dim up As New UnidadeProducao
            up.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade_destino"))
            cbo_unid_producao_destino.DataSource = up.getUnidadeProducaoByFilters
            cbo_unid_producao_destino.DataTextField = "nr_unid_producao"
            cbo_unid_producao_destino.DataValueField = "id_unid_producao"
            cbo_unid_producao_destino.DataBind()
            cbo_unid_producao_destino.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_id_propriedade_destino_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_propriedade_destino.TextChanged
        lbl_nm_propriedade_destino.Text = String.Empty
        lbl_nm_propriedade_destino.Visible = False
        hf_id_propriedade_destino.Value = String.Empty
        ViewState.Item("id_propriedade_destino") = 0
        'se propriedade é valida
        If Not txt_id_propriedade_destino.Text.ToString.Equals(String.Empty) Then
            If validarPropriedade(txt_id_propriedade_destino.Text).Tables(0).Rows.Count > 0 Then
                ViewState.Item("id_propriedade_destino") = txt_id_propriedade_destino.Text.Trim
                hf_id_propriedade_destino.Value = txt_id_propriedade_destino.Text.Trim
                carregarCamposPropriedadeDestinoProdutor(Convert.ToInt32(txt_id_propriedade_destino.Text.Trim))
                loadUnidProducaobyPropriedadeDestino()
            End If
        Else
            lbl_cd_uf_destino.Text = String.Empty
            lbl_nm_cidade_destino.Text = String.Empty
            lbl_produtor_destino.Text = String.Empty
            cbo_unid_producao_destino.Items.Clear()
        End If

    End Sub

    
    Protected Sub chk_selec_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim chk_selec As Anthem.CheckBox = CType(row.FindControl("chk_selec"), Anthem.CheckBox)

        If chk_selec.Checked = True Then
            lbl_nr_volume_selecionado.Text = FormatNumber(CDec(lbl_nr_volume_selecionado.Text) + CDec(row.Cells(3).Text), 0).ToString
        Else
            lbl_nr_volume_selecionado.Text = FormatNumber(CDec(lbl_nr_volume_selecionado.Text) - CDec(row.Cells(3).Text), 0).ToString

        End If

    End Sub

    Protected Sub btn_buscardados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_buscardados.Click
        Try
            If Page.IsValid = True Then

                ViewState.Item("id_propriedade") = txt_id_propriedade.Text
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("dt_referencia") = String.Concat("01/", txt_dt_referencia.Text)

                Dim transf As New TransferenciaVolume
                transf.id_propriedade = Convert.ToInt32(txt_id_propriedade.Text)
                transf.dt_referencia = String.Concat("01/", txt_dt_referencia.Text)
                transf.ano_referencia = DateTime.Parse(String.Concat("01/", txt_dt_referencia.Text)).ToString("yyyy")
                ViewState.Item("nr_volume_anual") = transf.getVolumeTotalByPropriedade
                lbl_nr_volume_anual_coletado.Text = FormatNumber(ViewState.Item("nr_volume_anual"), 0)

                loadGrid()
                lk_transferir_volumes.Enabled = True

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub cv_buscardados_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_buscardados.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True

            'valida calculo definitivo das propriedades
            If (ViewState.Item("id_propriedade_destino") Is Nothing) Then
                ViewState.Item("id_propriedade_destino") = 0
            End If
            If ValidarCalculoDefinitivo(lmsg, CLng(ViewState.Item("id_propriedade")), CLng(ViewState.Item("id_propriedade_destino"))) = False Then
                args.IsValid = False
            End If

            'fran 07/2016 i
            'se propriedade destino esta inativa e está transfererida, verifica se já pode retornar para destino
            If args.IsValid = True AndAlso ViewState.Item("st_transferencia_destino") = "S" Then
                Dim transfvolume As New TransferenciaVolume
                transfvolume.id_propriedade_origem = ViewState.Item("id_propriedade_destino")
                Dim dstransferencia As DataSet = transfvolume.getTransferenciaVolumeHistorico()

                If dstransferencia.Tables(0).Rows.Count > 0 Then
                    'se o ano da transferencia da propridade destino é igual a data de referencia da transferencia atual, a propriedade destino não pode receber dados de transferencia por causa das regras de transferencia titularidade
                    If Year(CDate(String.Concat("01/", txt_dt_referencia.Text))) = Year(CDate(dstransferencia.Tables(0).Rows(0).Item("dt_referencia").ToString)) Then
                        args.IsValid = False
                        lmsg = String.Concat("A propriedade destino está inativa por transferência realizada em  ", Right(dstransferencia.Tables(0).Rows(0).Item("dt_referencia").ToString, 7), ". De acordo com as regras da transferência de titularidade, esta propriedade poderá ser reutilizada apenas no próximo ano fiscal, ou seja, a partir de janeiro do próximo ano.")
                    End If
                End If

            End If
            'fran 07/2016 f

            If args.IsValid = True Then
                If CLng(ViewState.Item("id_propriedade")) > 0 And CLng(ViewState.Item("id_propriedade_destino")) > 0 Then
                    Dim proporigem As New Propriedade(ViewState.Item("id_propriedade"))
                    Dim propdestino As New Propriedade(ViewState.Item("id_propriedade_destino"))

                    If proporigem.id_propriedade_matriz = 0 Then
                        args.IsValid = False
                        lmsg = String.Concat("A propriedade origem não pode ser transferida porque não participa de grupo Matriz/Filial.")
                    End If

                    If propdestino.id_propriedade_matriz = 0 Then
                        args.IsValid = False
                        lmsg = String.Concat("A propriedade destino não pode receber transferência de volume porque não participa de grupo Matriz/Filial. Selecione outra propriedade.")
                    End If

                    If args.IsValid = True Then
                        If proporigem.id_propriedade_matriz <> propdestino.id_propriedade_matriz Then
                            args.IsValid = False
                            lmsg = String.Concat("A propriedade destino pertence ao grupo da Propriedade Matriz ", propdestino.id_propriedade_matriz.ToString, ", e a propriedade origem pertence ao grupo da Propriedade Matriz ", proporigem.id_propriedade_matriz.ToString, ". A transferência não pode ser realizada entre grupos de Matriz/Filial diferentes.")
                        End If
                    End If

                End If
            End If


            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_propriedade_destino_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_propriedade_destino.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True

            If Not txt_id_propriedade_destino.Text.ToString.Equals(String.Empty) Then
                If Not validarPropriedade(txt_id_propriedade_destino.Text).Tables(0).Rows.Count > 0 Then
                    args.IsValid = False
                    lmsg = "O código da propriedade destino informado não é válido."
                End If
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_propriedade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_propriedade.ServerValidate
        Try
            Dim lmsg As String = String.Empty
            args.IsValid = True

            If Not txt_id_propriedade.Text.ToString.Equals(String.Empty) Then
                If Not validarPropriedade(txt_id_propriedade.Text).Tables(0).Rows.Count > 0 Then
                    args.IsValid = False
                    lmsg = "O código da propriedade informado não é válido."
                End If
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadDataDesabilitado()

        Try

            tr_buscardados.Visible = False

            cbo_estabelecimento.Enabled = False
            lk_transferir_volumes.Enabled = True
            txt_dt_referencia.Enabled = False
            txt_id_propriedade.Enabled = False
            btn_lupa_propriedade.Visible = False
            cbo_unid_producao_destino.Enabled = False
            txt_id_propriedade_destino.Enabled = False
            btn_lupa_propriedade_destino.Visible = False
            lk_transferir_volumes.Enabled = False

            loadGrid()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

End Class
