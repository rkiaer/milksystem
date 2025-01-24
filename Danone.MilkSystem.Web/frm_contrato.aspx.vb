Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_contrato
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_contrato.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            Dim situacaocontrato As New SituacaoContrato

            cbo_situacao_contrato.DataSource = situacaocontrato.getSituacoesContratoByFilters()
            cbo_situacao_contrato.DataTextField = "nm_situacao_contrato"
            cbo_situacao_contrato.DataValueField = "id_situacao_contrato"
            cbo_situacao_contrato.DataBind()
            cbo_situacao_contrato.Items.FindByValue("1").Selected = True 'Incompleto
            cbo_situacao_contrato.Enabled = False

            'fran 04/2022 i flash
            Dim cluster As New Cluster
            cbo_cluster.DataSource = cluster.getClusterByFilters()
            cbo_cluster.DataTextField = "nm_cluster"
            cbo_cluster.DataValueField = "id_cluster"
            cbo_cluster.DataBind()
            cbo_cluster.Items.Insert(0, New ListItem("[Selecione]", "0"))

            If Not (Request("id_contrato_validade") Is Nothing) Then
                ViewState.Item("id_contrato_validade") = Request("id_contrato_validade")
                ViewState.Item("id_contrato") = Request("id_contrato")
                ViewState.Item("contrato_validade_unica") = "N" 'flag para controle visual de tela indicando que contrato com validade unico

                If Not (Request("st_nova_validade") Is Nothing) Then
                    ViewState.Item("st_nova_validade") = "S"
                    img_novavalidade.Visible = False
                    lk_novavalidade.Visible = False
                    lbl_separador.Visible = False
                    txt_dt_referencia.Enabled = True
                    lk_concluir.Enabled = True
                    lk_concluirFooter.Enabled = True

                Else
                    ViewState.Item("st_nova_validade") = "N"
                    lbl_st_vigente.Visible = True
                    lk_faixa_qualidade.Enabled = True
                    lk_adicional_volume.Enabled = True

                    Dim contrato As New Contrato
                    contrato.id_situacao = 1 'ativo
                    contrato.id_contrato = ViewState.Item("id_contrato")
                    contrato.id_situacao_contrato_validade = 1 'todas as validades ativas
                    'busca todas as validades do contrato. Se tiver apenas uma e pode alterar, deve consistir dados do contrato enquanto nao for aprovado 2 nivel
                    If contrato.getContratoSuasValidades.Tables(0).Rows.Count = 1 Then
                        ViewState.Item("contrato_validade_unica") = "S"
                    End If

                End If

                loadData()
            Else
                cbo_estabelecimento.Enabled = True
                txt_nr_contrato.Enabled = True
                txt_descricao.Enabled = True
                cbo_contrato_padrao.Enabled = True
                cbo_tipo_mercado.Enabled = True
                txt_dt_referencia.Enabled = True
                ViewState.Item("st_nova_validade") = "N"
                lk_concluir.Enabled = True
                lk_concluirFooter.Enabled = True
                cbo_cluster.Enabled = True
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim contrato As New Contrato(Convert.ToInt32(ViewState.Item("id_contrato")))
            Dim contratovalidade As New ContratoValidade(Convert.ToInt32(ViewState.Item("id_contrato_validade")))
            'verifica se o contrato é o primeiro, ou seja apenas um contrato validade existente

            'Contrato
            cbo_estabelecimento.SelectedValue = contrato.id_estabelecimento
            cbo_estabelecimento.Enabled = False

            txt_nr_contrato.Text = Mid(contrato.cd_contrato.ToString, 2)
            txt_descricao.Text = contrato.nm_contrato.ToString

            cbo_contrato_padrao.SelectedValue = contrato.st_contrato_comercial.ToString
            cbo_tipo_mercado.SelectedValue = contrato.st_contrato_mercado.ToString
            cbo_situacao_contrato.SelectedValue = contratovalidade.id_situacao_contrato.ToString
            cbo_situacao.SelectedValue = contrato.id_situacao.ToString
            cbo_cluster.SelectedValue = contrato.id_cluster.ToString 'fran 04/2022 flash

            txt_dt_referencia.Text = DateTime.Parse(contratovalidade.dt_referencia).ToString("MM/yyyy")

            'se esta incluindo uma nova referencia para o contrato
            If ViewState.Item("st_nova_validade").ToString.Equals("S") Then
                txt_dt_referencia.Enabled = True
                hf_dt_referencia_vigente.Value = DateTime.Parse(contratovalidade.dt_referencia).ToString("dd/MM/yyyy")
                ViewState.Item("st_referencia_vigente") = "N"
            Else

                lbl_st_vigente.Visible = True
                ViewState.Item("st_referencia_vigente") = contratovalidade.st_referencia_vigente.ToString
                'se esta validade é a vigente
                If contratovalidade.st_referencia_vigente.ToString.Equals("S") Then
                    lbl_st_vigente.Text = "(Referência Vigente Atualmente)"
                Else
                    lbl_st_vigente.Text = "(Referência Não Vigente Atualmente)"
                End If

                'CONTROELE VISUAL
                lk_adicional_volume.Enabled = True
                lk_faixa_qualidade.Enabled = True

                'se é contrato mercado que pega preço negociado de valor infoemado mes a mes
                If contrato.st_contrato_mercado.ToString.Equals("S") Then
                    lk_adicional_volume.Enabled = False
                    lk_adicional_volume.ToolTip = "Adicional de Volume não pode ser cadastrado para contratos do Tipo Mercado."
                End If

                'se o contrato nao foi aprovado em 2 nivel nem reprovado em 2 nivel, deixa alterar parcialmente
                If contratovalidade.id_situacao_contrato <> 5 AndAlso contratovalidade.id_situacao_contrato <> 6 Then
                    txt_dt_referencia.Enabled = True
                    lk_concluir.Enabled = True
                    lk_concluirFooter.Enabled = True
                    'Se o contrato validade é unico, deixa alterar dados do contrato, caso contrato apenas referencia
                    If ViewState.Item("contrato_validade_unica") = "S" Then
                        txt_descricao.Enabled = True
                        cbo_contrato_padrao.Enabled = True
                        cbo_tipo_mercado.Enabled = True
                        cbo_cluster.Enabled = True 'fran 04/2022 flash
                    End If
                Else
                    'se ja estiver aprovado ou reprovado, situação contrato for ativo e referencia vigente 
                    If contrato.id_situacao = 1 AndAlso ViewState.Item("st_referencia_vigente").ToString.Equals("S") Then
                        img_novavalidade.Visible = True
                        lk_novavalidade.Visible = True
                        lbl_separador.Visible = True
                    Else
                        img_novavalidade.Visible = False
                        lk_novavalidade.Visible = False
                        lbl_separador.Visible = False
                    End If
                End If
                'guarda variavel
                ViewState.Item("id_situacao_contrato") = contratovalidade.id_situacao_contrato.ToString

            End If

            'controle sistema
            lbl_modificador.Text = contrato.id_modificador.ToString()
            lbl_dt_modificacao.Text = contrato.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid Then

            Try

                Dim contrato As New Contrato
                Dim contratovalidade As New ContratoValidade

                'dados de contrato
                contrato.id_estabelecimento = cbo_estabelecimento.SelectedValue
                contrato.cd_contrato = String.Concat("C", txt_nr_contrato.Text)
                contrato.nm_contrato = txt_descricao.Text
                contrato.st_contrato_comercial = cbo_contrato_padrao.SelectedValue
                contrato.st_contrato_mercado = cbo_tipo_mercado.SelectedValue
                contrato.id_modificador = Session("id_login")
                contrato.id_cluster = cbo_cluster.SelectedValue 'fran 04/2022 flash

                'dados de contrato validade
                contratovalidade.dt_referencia = DateTime.Parse("01/" & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
                contratovalidade.id_modificador = Session("id_login")

                If Not (ViewState.Item("id_contrato") Is Nothing) Then

                    contrato.id_contrato = Convert.ToInt32(ViewState.Item("id_contrato"))
                    contratovalidade.id_contrato = Convert.ToInt32(ViewState.Item("id_contrato"))
                    contratovalidade.id_contrato_validade = Convert.ToInt32(ViewState.Item("id_contrato_validade"))

                    'se está criando nova validade
                    If ViewState.Item("st_nova_validade").ToString.Equals("S") Then
                        contratovalidade.id_contrato_validade_origem = contratovalidade.id_contrato_validade
                        contratovalidade.id_contrato_validade = contratovalidade.insertContratoValidade
                        'incluir qualidade e adicional de volume do contrato validade referencia
                        If contrato.st_contrato_mercado.Equals("S") Then 'se contrato do tipo mercado, nao inclui adicional de volume
                            contratovalidade.incluirQualidadeAdicionalVolumebyContratoValidade(False)
                        Else
                            contratovalidade.incluirQualidadeAdicionalVolumebyContratoValidade(True)
                        End If
                        ViewState.Item("st_nova_validade") = "N"

                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 4 'inclusao
                        usuariolog.id_menu_item = 178
                        usuariolog.nm_nr_processo = contrato.cd_contrato
                        usuariolog.id_nr_processo = ViewState.Item("id_contrato").ToString

                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                    Else
                        If txt_dt_referencia.Enabled = True Then
                            contratovalidade.updateContratoValidade()
                        End If
                        If ViewState.Item("contrato_validade_unica") = "S" Then
                            'se for unico contrato e nao estiver aprovado ou reprovado 2 nivel, pode alterar nome contrato e tipo contrato
                            contrato.id_contrato_validade = contratovalidade.id_contrato_validade
                            contrato.updateContrato()
                            'se contrato tem situacao ABERTO e contrato é de mercado
                            If ViewState.Item("id_situacao_contrato").ToString.Equals("1") AndAlso contrato.st_contrato_mercado.Equals("S") Then
                                'verifica se ja tem linhas de qualidade, se tiver atualiza contrato para situacao completo
                                Dim qualidade As New FaixaQualidade
                                qualidade.id_contrato_validade = contratovalidade.id_contrato_validade
                                qualidade.id_situacao = 1
                                'se encontrou linhas salvas em qualidade
                                If qualidade.getFaixaQualidadeByFilters.Tables(0).Rows.Count > 0 Then
                                    contratovalidade.id_situacao_contrato = 2 'Completo
                                    contratovalidade.updateContratoValidadeSituacao() 'atualiza situcao contrato para completo
                                End If
                            End If
                            'se contrato tem situacao diferente de ABERTO e contrato nao é de mercado (contrato nao mercado que esteja situacao completo ou aprovado 1 nivel DEVE ter linhas de ADICIONAL VOLUME, se nao tiver volta contrarto para aberto para forçar inclusão)
                            If Not (ViewState.Item("id_situacao_contrato").ToString.Equals("1")) AndAlso contrato.st_contrato_mercado.Equals("N") Then
                                'verifica se ja tem linhas de volume, se nao tiver, atualiza contrato para situacao aberto
                                Dim contratoadicional As New ContratoAdicionalVolume
                                contratoadicional.id_contrato_validade = contratovalidade.id_contrato_validade
                                contratoadicional.id_situacao = 1
                                'se nao tem linhas salvas em adicional de volume
                                If contratoadicional.getContratoAdicionalVolumeByFilters.Tables(0).Rows.Count = 0 Then
                                    contratovalidade.id_situacao_contrato = 1 'Aberto
                                    contratovalidade.updateContratoValidadeSituacao() 'atualiza situcao contrato para aberto
                                End If
                            End If
                        End If

                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alteracao
                        usuariolog.id_menu_item = 178
                        usuariolog.nm_nr_processo = contrato.cd_contrato
                        usuariolog.id_nr_processo = ViewState.Item("id_contrato").ToString

                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                    End If

                    messageControl.Alert("Registro alterado com sucesso.")
                    loadData()
                Else

                    contratovalidade.id_contrato = contrato.insertContrato()
                    If contratovalidade.id_contrato > 0 Then
                        contratovalidade.id_contrato_validade = contratovalidade.insertContratoValidade
                        ViewState.Item("id_contrato") = contratovalidade.id_contrato
                        ViewState.Item("id_contrato_validade") = contratovalidade.id_contrato_validade

                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 4 'inclusao
                        usuariolog.id_menu_item = 178
                        usuariolog.nm_nr_processo = contrato.cd_contrato
                        usuariolog.id_nr_processo = ViewState.Item("id_contrato").ToString


                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        messageControl.Alert("Registro inserido com sucesso.")
                        loadData()
                    Else
                        messageControl.Alert("Problemas na Inclusão do Contrato. Entre em contato com a área técnica.")

                    End If

                End If



            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_contrato.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_contrato.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_contrato.aspx")

    End Sub


    Private Sub deleteParametroQualidade(ByVal id_poupancaparametroqualidade As Integer)

        Try

            Dim poupancaparametroqualidade As New PoupancaParametroQualidade()
            poupancaparametroqualidade.id_poupanca_parametro_qualidade = id_poupancaparametroqualidade
            poupancaparametroqualidade.id_modificador = Convert.ToInt32(Session("id_login"))
            poupancaparametroqualidade.deletePoupancaParametroQualidade()
            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub cv_contrato_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_contrato.ServerValidate
        Try
            Dim lmsg As String
            Dim contrato As New Contrato
            Dim dscontrato As DataSet
            args.IsValid = True

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            'se é NOVO CONTRATO
            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            If (ViewState.Item("id_contrato") Is Nothing) Then

                'verifica se existe o contrato com mesmo código
                contrato.id_situacao = 1 'ativo
                contrato.id_estabelecimento = cbo_estabelecimento.SelectedValue
                contrato.cd_contrato = String.Concat("C", txt_nr_contrato.Text)
                If contrato.getContratoByFilters.Tables(0).Rows.Count > 0 Then
                    lmsg = "Já existe contrato cadastrado com o código de contrato e estabelecimento informados."
                    args.IsValid = False
                End If

                If cbo_contrato_padrao.SelectedValue.Equals("S") Then
                    'se foi informado opção de contrato comercial,  verifica se ja existe alçgum contrato comercial para o estabelecimento
                    contrato.id_situacao = 1 'ativo
                    contrato.id_estabelecimento = cbo_estabelecimento.SelectedValue
                    contrato.cd_contrato = String.Empty
                    contrato.st_contrato_comercial = "S"
                    If contrato.getContratoByFilters.Tables(0).Rows.Count > 0 Then
                        lmsg = "Apenas um contrato poadrão (default) por estabelecimento pode ser cadastrado. Já existe contrato padrão (default) para o estabelecimento informado."
                        args.IsValid = False
                    End If
                End If

                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'se é CONTRATO JA EXISTENTE
                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

            Else 'se ja existe

                'se esta salvando nova validade, ou seja contrato já existe apenas criando nova referencia por alguma alteração
                If ViewState.Item("st_nova_validade") = "S" Then
                    'se a referencia da tela é menor ou igual a referencia escondida  
                    If CDate(DateTime.Parse("01/" & txt_dt_referencia.Text).ToString("dd/MM/yyyy")) <= CDate(hf_dt_referencia_vigente.Value) Then
                        lmsg = "A validade informada não pode ser menor ou igual à última referência válida cadastrada para o Contrato."
                        args.IsValid = False

                    End If

                Else
                    'busca todas as validades do contrato. Se tiver apenas uma e pode alterar, deve consistir dados do contrato enquanto nao for aprovado 2 nivel
                    If ViewState.Item("contrato_validade_unica").Equals("S") Then
                        If cbo_contrato_padrao.SelectedValue.Equals("S") Then

                            'se foi informado opção de contrato comercial,  verifica se ja existe alçgum contrato comercial para o estabelecimento
                            contrato.id_situacao = 1 'ativo
                            contrato.id_estabelecimento = cbo_estabelecimento.SelectedValue
                            contrato.st_contrato_comercial = "S"
                            dscontrato = contrato.getContratoByFilters
                            If dscontrato.Tables(0).Rows.Count > 0 Then
                                'seencontrou apenas uma linha
                                If dscontrato.Tables(0).Rows.Count = 1 Then
                                    'se o contrato validade que existe no banco como comercial nao é o que está  cadastrado na tela, não pode cadastrar novo contrato comercial
                                    If CLng(ViewState.Item("id_contrato").ToString) <> CLng(dscontrato.Tables(0).Rows(0).Item("id_contrato").ToString) Then
                                        lmsg = "Apenas um contrato padrão (default) por estabelecimento pode ser cadastrado. Já existe contrato padrão (default) para o estabelecimento informado."
                                        args.IsValid = False

                                    End If
                                Else
                                    'se tem mais de uma linha exibe msg direto
                                    lmsg = "Apenas um contrato padrão (default) por estabelecimento pode ser cadastrado. Já existe contrato padrão (default) para o estabelecimento informado."
                                    args.IsValid = False

                                End If
                            End If
                        End If

                    Else
                        'se esta alterando quaçlquer contrato ja existente
                        contrato.id_contrato = Convert.ToInt32(ViewState.Item("id_contrato").ToString)
                        contrato.id_contrato_validade = Convert.ToInt32(ViewState.Item("id_contrato_validade").ToString)
                        contrato.dt_referencia = DateTime.Parse("01/" & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
                        'se encontrou validade maior ou igual no cadastro
                        If contrato.getContratoConsValidade.Tables(0).Rows.Count > 0 Then
                            lmsg = "A validade informada não pode ser menor ou igual à referências válidas já cadastradas para o Contrato."
                            args.IsValid = False

                        End If

                    End If

                End If

            End If


            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_faixa_qualidade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_faixa_qualidade.Click
        Response.Redirect("frm_contrato_faixa_qualidade.aspx?id_contrato_validade=" & ViewState.Item("id_contrato_validade").ToString & "&id_contrato=" & ViewState.Item("id_contrato").ToString)

    End Sub

    Protected Sub lk_novavalidade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novavalidade.Click

        Response.Redirect("frm_contrato.aspx?id_contrato_validade=" & ViewState.Item("id_contrato_validade").ToString & "&id_contrato=" & ViewState.Item("id_contrato").ToString & "&st_nova_validade=" & ViewState.Item("st_nova_validade").ToString)

    End Sub

    Protected Sub lk_adicional_volume_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_adicional_volume.Click

        Response.Redirect("frm_contrato_adicional_volume.aspx?id_contrato_validade=" & ViewState.Item("id_contrato_validade").ToString & "&id_contrato=" & ViewState.Item("id_contrato").ToString)

    End Sub

    Protected Sub cbo_tipo_mercado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_mercado.SelectedIndexChanged
        'se contrato do tipo mercado, ouseja, deve informar preco negociado
        If cbo_tipo_mercado.SelectedValue.Equals("S") Then
            lk_adicional_volume.Enabled = False
            lk_adicional_volume.ToolTip = "Adicional de Volume não pode ser cadastrado para contratos do Tipo Mercado."
        Else
            lk_adicional_volume.Enabled = True
            lk_adicional_volume.ToolTip = String.Empty

        End If
    End Sub
End Class
