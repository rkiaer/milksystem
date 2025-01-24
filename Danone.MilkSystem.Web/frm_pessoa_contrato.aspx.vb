Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_pessoa_contrato
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_pessoa_contrato.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        'fran 07/2017 i
        With btn_lupa_contrato
            .Attributes.Add("onclick", "javascript:ShowDialogContrato()")
            .ToolTip = "Filtrar Contratos"
        End With

    End Sub
    Private Sub loadDetails()

        Try

            Dim estabel As New Estabelecimento

            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim grupo As New Grupo

            cbo_grupo.DataSource = grupo.getGruposByFilters()
            cbo_grupo.DataTextField = "nm_grupo"
            cbo_grupo.DataValueField = "id_grupo"
            cbo_grupo.DataBind()
            cbo_grupo.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim cluster As New Cluster
            cbo_cluster.DataSource = cluster.getClusterByFilters()
            cbo_cluster.DataTextField = "nm_cluster"
            cbo_cluster.DataValueField = "id_cluster"
            cbo_cluster.DataBind()
            cbo_cluster.Items.Insert(0, New ListItem("[Selecione]", 0))

            If Not (Request("id_pessoa") Is Nothing) Then
                ViewState.Item("id_pessoa") = Request("id_pessoa")
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub



    Private Sub loadData()

        Try

            Dim id_pessoa As Int32 = Convert.ToInt32(ViewState.Item("id_pessoa"))
            Dim pessoa As New Pessoa(id_pessoa)

            txt_cd_pessoa.Text = pessoa.cd_pessoa
            txt_codigo_SAP.Text = pessoa.cd_codigo_SAP  ' 02/2012 - Projeto Themis Rls 31

            If Not (pessoa.st_categoria.Trim().Equals(String.Empty)) Then
                cbo_categoria.SelectedValue = pessoa.st_categoria
            End If

            txt_nm_pessoa.Text = pessoa.nm_pessoa

            txt_nm_abreviado.Text = pessoa.nm_abreviado

            If (pessoa.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = pessoa.id_estabelecimento.ToString()
            End If

            If (pessoa.id_grupo > 0) Then
                cbo_grupo.SelectedValue = pessoa.id_grupo.ToString()
            End If


            'se for grupo produtor
            If pessoa.id_grupo.Equals(1) Then
                'fran 04/2022 - flash i
                'rf_cluster.Enabled = True
                'cbo_cluster.Enabled = True
                rf_cluster.Enabled = False
                cbo_cluster.Enabled = False
                'fran 04/2022 - flash f
                'fran 07/2017 i
                cbo_adicional_volume.Enabled = True
                If pessoa.nr_adicional_volume > 0 Then
                    cbo_adicional_volume.SelectedValue = pessoa.nr_adicional_volume
                Else
                    cbo_adicional_volume.SelectedValue = 24
                End If
                rf_contrato.Enabled = True
                cv_contrato.Enabled = True
                txt_cd_contrato.Enabled = True
                btn_lupa_contrato.Visible = True
                btn_lupa_contrato.Enabled = True

                If pessoa.id_contrato > 0 Then
                    txt_cd_contrato.Text = pessoa.cd_contrato.ToString
                    hf_id_contrato.Value = pessoa.id_contrato
                    lbl_nm_contrato.Text = pessoa.nm_contrato.ToString
                    If pessoa.id_cluster > 0 Then
                        cbo_cluster.SelectedValue = pessoa.id_cluster
                    End If
                Else
                    cbo_cluster.SelectedValue = 0
                End If

            End If

            'Grid Historico Contrato
            loadGridContratoHistorico()

            If ViewState.Item("id_situacao_pessoa_contrato").ToString = "2" Then 'se for aprovação de 1o nivel, nao deixa salvar para aguardar a reprovação ou aprovação 2 nivel
                lk_concluir.Enabled = False
                lk_concluir.ToolTip = "Esta ação não pode ser efetuada no momento. Aguardando aprovação/reprovação dem 2o nível."
                lk_concluirFooter.Enabled = False
                lk_concluirFooter.ToolTip = "Esta ação não pode ser efetuada no momento. Aguardando aprovação/reprovação dem 2o nível."
                lk_email.Enabled = True
            Else
                If ViewState.Item("id_situacao_pessoa_contrato").ToString = "1" Then 'aguardando aprovacao
                    lk_email.Enabled = True
                Else
                    lk_email.Enabled = False
                End If
                lk_concluir.Enabled = True
                lk_concluir.ToolTip = String.Empty
                lk_concluirFooter.Enabled = True
                lk_concluirFooter.ToolTip = String.Empty

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadGridContratoHistorico()
        Try

            If ViewState.Item("id_pessoa") Is Nothing Then
                ViewState.Item("id_pessoa") = 0
            End If

            lbl_situacao.Text = String.Empty
            ViewState.Item("id_situacao_pessoa_contrato") = "0"
            ViewState.Item("id_pessoa_contrato") = "0"
            ViewState.Item("id_contrato_ultimo") = "0"
            ViewState.Item("id_cluster_ultimo") = "0"
            ViewState.Item("nr_adicional_volume_ultimo") = "0"

            Dim pessoacontrato As New PessoaContrato
            If CLng(ViewState.Item("id_pessoa")) > 0 Then
                pessoacontrato.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
                Dim dspessoacontrato As DataSet = pessoacontrato.getPessoaContratoByFilters()

                If (dspessoacontrato.Tables(0).Rows.Count > 0) Then
                    'pega o ultima situação contrato incluido
                    lbl_situacao.Text = dspessoacontrato.Tables(0).Rows(0).Item("nm_situacao_pessoa_contrato").ToString
                    ViewState.Item("id_pessoa_contrato") = dspessoacontrato.Tables(0).Rows(0).Item("id_pessoa_contrato").ToString
                    ViewState.Item("id_situacao_pessoa_contrato") = dspessoacontrato.Tables(0).Rows(0).Item("id_situacao_pessoa_contrato").ToString
                    ViewState.Item("id_contrato_ultimo") = dspessoacontrato.Tables(0).Rows(0).Item("id_contrato").ToString
                    ViewState.Item("id_cluster_ultimo") = dspessoacontrato.Tables(0).Rows(0).Item("id_cluster").ToString
                    ViewState.Item("nr_adicional_volume_ultimo") = dspessoacontrato.Tables(0).Rows(0).Item("nr_adicional_volume").ToString

                    If Not IsDBNull(dspessoacontrato.Tables(0).Rows(0).Item("dt_inicio_contrato")) Then
                        txt_dt_inicio_contrato.Text = DateTime.Parse(dspessoacontrato.Tables(0).Rows(0).Item("dt_inicio_contrato").ToString).ToString("dd/MM/yyyy")
                    End If

                    If Not IsDBNull(dspessoacontrato.Tables(0).Rows(0).Item("dt_fim_contrato")) Then
                        txt_dt_fim_contrato.Text = DateTime.Parse(dspessoacontrato.Tables(0).Rows(0).Item("dt_fim_contrato").ToString).ToString("dd/MM/yyyy")
                    End If

                    If Not IsDBNull(dspessoacontrato.Tables(0).Rows(0).Item("dt_rescisao")) Then
                        txt_dt_rescisao.Text = DateTime.Parse(dspessoacontrato.Tables(0).Rows(0).Item("dt_rescisao").ToString).ToString("dd/MM/yyyy")
                    End If

                    gridcontratohistorico.Visible = True
                    gridcontratohistorico.DataSource = Helper.getDataView(dspessoacontrato.Tables(0), "dt_modificacao desc")
                    gridcontratohistorico.DataBind()
                Else

                    Dim dr As DataRow = dspessoacontrato.Tables(0).NewRow()
                    dspessoacontrato.Tables(0).Rows.InsertAt(dr, 0)
                    gridcontratohistorico.Visible = True
                    gridcontratohistorico.DataSource = Helper.getDataView(dspessoacontrato.Tables(0), "")
                    gridcontratohistorico.DataBind()
                    gridcontratohistorico.Rows(0).Cells.Clear()
                    gridcontratohistorico.Rows(0).Cells.Add(New TableCell())
                    gridcontratohistorico.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridcontratohistorico.Rows(0).Cells(0).Text = "Não existe nenhum histórico de Modelo de Contrato para o Produtor!"
                    gridcontratohistorico.Rows(0).Cells(0).ColumnSpan = 20
                End If
            Else
                pessoacontrato.id_pessoa = -1
                Dim dspessoacontrato As DataSet = pessoacontrato.getPessoaContratoByFilters()

                Dim dr As DataRow = dspessoacontrato.Tables(0).NewRow()
                dspessoacontrato.Tables(0).Rows.InsertAt(dr, 0)
                gridcontratohistorico.Visible = True
                gridcontratohistorico.DataSource = Helper.getDataView(dspessoacontrato.Tables(0), "")
                gridcontratohistorico.DataBind()
                gridcontratohistorico.Rows(0).Cells.Clear()
                gridcontratohistorico.Rows(0).Cells.Add(New TableCell())
                gridcontratohistorico.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridcontratohistorico.Rows(0).Cells(0).Text = "Não existe nenhum histórico de Modelo de Contrato para o Produtor!"
                gridcontratohistorico.Rows(0).Cells(0).ColumnSpan = 20


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try


    End Sub

    Private Sub updateData()

        If Page.IsValid Then

            Try
                'se nao alterou contrato, cluster e nem adicional volume, altera apenas datas de contrato
                If ViewState.Item("id_contrato_ultimo").ToString = hf_id_contrato.Value.ToString And ViewState.Item("id_cluster_ultimo").ToString = cbo_cluster.SelectedValue.ToString And ViewState.Item("nr_adicional_volume_ultimo").ToString = cbo_adicional_volume.SelectedValue.ToString Then
                    Dim pessoacontrato As New PessoaContrato()
                    pessoacontrato.dt_inicio_contrato = txt_dt_inicio_contrato.Text
                    pessoacontrato.dt_fim_contrato = txt_dt_fim_contrato.Text
                    pessoacontrato.dt_rescisao = txt_dt_rescisao.Text
                    pessoacontrato.id_modificador = Session("id_login")
                    pessoacontrato.id_pessoa_contrato = Convert.ToInt32(ViewState.Item("id_pessoa_contrato"))
                    pessoacontrato.updatePessoaContratoDatas()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'alteracao
                    usuariolog.id_menu_item = 4
                    usuariolog.ds_nm_processo = "Fornecedor - Produtor Contrato"
                    usuariolog.id_nr_processo = ViewState.Item("id_pessoa_contrato")

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Datas do Contrato atualizadas com sucesso.")

                Else


                    Dim pessoa As New PessoaContrato()
                    pessoa.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
                    pessoa.id_contrato = hf_id_contrato.Value
                    pessoa.id_cluster = cbo_cluster.SelectedValue
                    pessoa.nr_adicional_volume = cbo_adicional_volume.SelectedValue
                    pessoa.dt_inicio_contrato = txt_dt_inicio_contrato.Text
                    pessoa.dt_fim_contrato = txt_dt_fim_contrato.Text
                    pessoa.dt_rescisao = txt_dt_rescisao.Text
                    If Not (cbo_cluster.SelectedValue.Trim.Equals(String.Empty)) Then
                        pessoa.id_cluster = cbo_cluster.SelectedValue
                    End If
                    pessoa.id_modificador = Session("id_login")

                    'se estuver aguardando alteração, deixa alterar campos
                    If ViewState.Item("id_situacao_pessoa_contrato").Equals("1") Then
                        pessoa.id_pessoa_contrato = Convert.ToInt32(ViewState.Item("id_pessoa_contrato"))
                        pessoa.atualizarPessoaContrato()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 4 'alteracao
                        usuariolog.id_menu_item = 4
                        usuariolog.id_nr_processo = ViewState.Item("id_pessoa_contrato")
                        usuariolog.ds_nm_processo = "Fornecedor - Produtor Contrato"
                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro alterado com sucesso.")
                    Else
                        pessoa.incluirPessoaContrato()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'inclusao
                        usuariolog.id_menu_item = 4
                        usuariolog.ds_nm_processo = "Fornecedor - Produtor Contrato"
                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango
                        messageControl.Alert("Registro inserido com sucesso.")
                    End If
                End If

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_pessoa.aspx?id_pessoa=" & ViewState.Item("id_pessoa"))
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("frm_pessoa.aspx?id_pessoa=" & ViewState.Item("id_pessoa"))
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Sub cv_contrato_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_contrato.ServerValidate
        Try
            Dim contrato As New Contrato()
            Dim dscontrato As DataSet
            Dim lidcontrato As Int32 = 0
            Dim lmsg As String

            If Not (Me.hf_id_contrato.Value.Trim.Equals(String.Empty)) Then
                contrato.id_contrato = Convert.ToInt32(Me.hf_id_contrato.Value)
            End If

            contrato.id_estabelecimento = cbo_estabelecimento.SelectedValue
            contrato.cd_contrato = Me.txt_cd_contrato.Text.Trim
            dscontrato = contrato.getContratoByFilters

            args.IsValid = True

            If dscontrato.Tables(0).Rows.Count > 0 Then
                lidcontrato = dscontrato.Tables(0).Rows(0).Item("id_contrato").ToString
                If dscontrato.Tables(0).Rows(0).Item("id_situacao").ToString.Equals("2") Then
                    args.IsValid = False
                    lmsg = "Contrato desativado."
                Else

                    If (Me.hf_id_contrato.Value.Trim.Equals(String.Empty)) Then
                        hf_id_contrato.Value = Convert.ToInt32(dscontrato.Tables(0).Rows(0).Item("id_contrato").ToString)
                        lbl_nm_contrato.Text = dscontrato.Tables(0).Rows(0).Item("nm_contrato").ToString
                    End If

                End If
            Else
                args.IsValid = False
                lmsg = "Contrato não cadastrado para o Estabelecimento."
            End If

            If args.IsValid = False Then
                hf_id_contrato.Value = String.Empty
                messageControl.Alert(lmsg)
            Else
                hf_id_contrato.Value = lidcontrato
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_contrato_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_contrato.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposContrato()
        End If

    End Sub
    Private Sub carregarCamposContrato()

        Try


            If Not (customPage.getFilterValue("lupa_contrato", "nm_contrato").Equals(String.Empty)) Then
                Me.lbl_nm_contrato.Text = customPage.getFilterValue("lupa_contrato", "nm_contrato").ToString
            End If

            If Not (customPage.getFilterValue("lupa_contrato", "cd_contrato").Equals(String.Empty)) Then
                Me.txt_cd_contrato.Text = customPage.getFilterValue("lupa_contrato", "cd_contrato").ToString

                Dim contrato As New Contrato(hf_id_contrato.Value)
                cbo_cluster.SelectedValue = contrato.id_cluster
            End If

            'loadData()
            customPage.clearFilters("lupa_contrato")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_contrato_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_contrato.TextChanged
        lbl_nm_contrato.Text = String.Empty
        hf_id_contrato.Value = String.Empty

        Try
            If Not txt_cd_contrato.Text.Equals(String.Empty) Then
                Dim contrato As New Contrato
                contrato.cd_contrato = Me.txt_cd_contrato.Text.Trim
                contrato.id_estabelecimento = cbo_estabelecimento.SelectedValue
                contrato.id_situacao = 1
                Dim dscontrato As DataSet = contrato.getContratoByFilters
                'se encontrou contrato ativo
                If dscontrato.Tables(0).Rows.Count > 0 Then
                    lbl_nm_contrato.Enabled = True
                    lbl_nm_contrato.Text = dscontrato.Tables(0).Rows(0).Item("nm_contrato")
                    hf_id_contrato.Value = dscontrato.Tables(0).Rows(0).Item("id_contrato")
                    cbo_cluster.SelectedValue = dscontrato.Tables(0).Rows(0).Item("id_cluster")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        If Page.IsValid = True Then
            Try

                Dim notificacao As New Notificacao
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 9 'email
                usuariolog.id_menu_item = 4
                usuariolog.ds_nm_processo = "Fornecedor - Produtor Contrato"
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                If ViewState.Item("id_situacao_pessoa_contrato").ToString = "1" Then ' se em aprovacao
                    Dim lAssunto As String = "Aprovação 1.o Nível para Modelo de Contrato de Produtor "
                    Dim lCorpo As String = "Existem modelo de contrato de Produtor(es) pendente(s) para aprovação 1.o Nível."
                    ' Parametro 19 - MODELO DE CONTRATAO 1.o Nível
                    If notificacao.enviaMensagemEmail(19, lAssunto, lCorpo, MailPriority.High) = True Then
                        messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível foi enviada aos destinatários com sucesso!")
                    Else
                        messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")
                    End If
                End If

                If ViewState.Item("id_situacao_pessoa_contrato").ToString = "2" Then ' se aprovado 1 nivel
                    Dim lAssunto As String = "Aprovação 2.o Nível para Modelo de Contrato de Produtor "
                    Dim lCorpo As String = "Existem modelo de contrato de Produtor(es) pendente(s) para aprovação 2.o Nível."
                    ' Parametro 20 - MODELO DE CONTRATAO 2.o Nível
                    If notificacao.enviaMensagemEmail(20, lAssunto, lCorpo, MailPriority.High) = True Then
                        messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível foi enviada aos destinatários com sucesso!")
                    Else
                        messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")
                    End If
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        End If
    End Sub
End Class
