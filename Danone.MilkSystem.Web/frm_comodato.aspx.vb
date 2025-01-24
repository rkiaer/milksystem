Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_comodato
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_comodato.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
        End With

    End Sub

    Private Sub loadDetails()

        Try
            'Dim tipobem As New TipoBem

            'cbo_tipo_bem.DataSource = tipobem.getTipoBensByFilters()
            'cbo_tipo_bem.DataTextField = "nm_tipobem"
            'cbo_tipo_bem.DataValueField = "id_tipobem"
            'cbo_tipo_bem.DataBind()
            'cbo_tipo_bem.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            Dim voltagens As New Voltagem

            cbo_id_voltagem.DataSource = voltagens.getVoltagensByFilters()
            cbo_id_voltagem.DataTextField = "nm_voltagem"
            cbo_id_voltagem.DataValueField = "id_voltagem"
            cbo_id_voltagem.DataBind()
            cbo_id_voltagem.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim proprietario As New ProprietarioEquipamento

            cbo_id_proprietario.DataSource = proprietario.getProprietariosByFilters()
            cbo_id_proprietario.DataTextField = "nm_proprietario"
            cbo_id_proprietario.DataValueField = "id_proprietario"
            cbo_id_proprietario.DataBind()
            cbo_id_proprietario.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            If Not (Request("id_comodato") Is Nothing) Then
                ViewState.Item("id_comodato") = Request("id_comodato")

                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub




    Private Sub loadData()

        Try

            Dim id_comodato As Int32 = Convert.ToInt32(ViewState.Item("id_comodato"))
            Dim comodato As New Comodato(id_comodato)

            label_codigo.Visible = True
            txt_cd_comodato.Visible = True
            txt_cd_comodato.Text = comodato.id_comodato.ToString
            txt_nm_comodato.Text = comodato.nm_comodato

            txt_nm_fabricante.Text = comodato.nm_fabricante
            txt_nm_modelo.Text = comodato.nm_modelo
            txt_nr_serie.Text = comodato.nr_serie
            txt_nr_capacidade.Text = comodato.nr_capacidade
            If (comodato.nr_qtde_ordenhas_dia > 0) Then
                txt_nr_qtde_ordenhas_dia.Text = comodato.nr_qtde_ordenhas_dia
            End If
            If (comodato.id_voltagem > 0) Then
                cbo_id_voltagem.SelectedValue = comodato.id_voltagem.ToString()
            End If
            If (comodato.nr_nota_fiscal > 0) Then
                txt_nr_nota_fiscal.Text = comodato.nr_nota_fiscal
            End If
            txt_nr_serie_nota_fiscal.Text = comodato.nr_serie_nota_fiscal
            If Not (comodato.dt_emissao_nota_fiscal Is Nothing) Then
                txt_dt_emissao_nota_fiscal.Text = DateTime.Parse(comodato.dt_emissao_nota_fiscal).ToString("dd/MM/yyyy")
            End If
            txt_nr_valor.Text = comodato.nr_valor
            If (comodato.nr_nota_fiscal_devolucao > 0) Then
                txt_nr_nota_fiscal_devolucao.Text = comodato.nr_nota_fiscal_devolucao
            End If
            If Not (comodato.dt_nota_fiscal_devolucao Is Nothing) Then
                txt_dt_nota_fiscal_devolucao.Text = DateTime.Parse(comodato.dt_nota_fiscal_devolucao).ToString("dd/MM/yyyy")
            End If

            If (comodato.id_proprietario > 0) Then
                cbo_id_proprietario.SelectedValue = comodato.id_proprietario.ToString()
            End If

            If comodato.id_pessoa > 0 Then
                Dim pessoa As New Pessoa(comodato.id_pessoa)
                Habilitar_Produtor()
                txt_cd_pessoa.Text = pessoa.cd_pessoa
                hf_id_pessoa.Value = pessoa.id_pessoa
                lbl_nm_pessoa.Visible = True
                lbl_nm_pessoa.Text = pessoa.nm_pessoa
            End If
            txt_nr_contrato.Text = comodato.nr_contrato
            txt_nr_patrimonio.Text = comodato.nr_patrimonio
            If Not (comodato.st_alocado.Trim().Equals(String.Empty)) Then
                cbo_id_alocado.SelectedValue = comodato.st_alocado
            End If

            'If (comodato.id_tipobem > 0) Then
            '    cbo_tipo_bem.SelectedValue = comodato.id_tipobem.ToString()
            'End If

            'If Not (comodato.dt_aquisicao Is Nothing) Then
            '    txt_dt_aquisicao.Text = DateTime.Parse(comodato.dt_aquisicao).ToString("dd/MM/yyyy")
            'End If

            'If Not (comodato.dt_baixa Is Nothing) Then
            '    txt_dt_baixa.Text = DateTime.Parse(comodato.dt_baixa).ToString("dd/MM/yyyy")
            'End If


            If (comodato.id_situacao > 0) Then
                cbo_situacao.SelectedValue = comodato.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = comodato.id_modificador.ToString()
            lbl_dt_modificacao.Text = comodato.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid() Then
            Try

                Dim comodato As New Comodato()

                comodato.nm_comodato = txt_nm_comodato.Text
                comodato.nm_fabricante = txt_nm_fabricante.Text
                comodato.nm_modelo = txt_nm_modelo.Text
                comodato.nr_serie = txt_nr_serie.Text
                If Not (txt_nr_capacidade.Text.Trim.Equals(String.Empty)) Then
                    comodato.nr_capacidade = Convert.ToDouble(txt_nr_capacidade.Text)
                End If
                If Not (txt_nr_qtde_ordenhas_dia.Text.Trim().Equals(String.Empty)) Then
                    comodato.nr_qtde_ordenhas_dia = Convert.ToInt32(txt_nr_qtde_ordenhas_dia.Text)
                End If
                If Not (cbo_id_voltagem.SelectedValue.Trim().Equals(String.Empty)) Then
                    comodato.id_voltagem = Convert.ToInt32(cbo_id_voltagem.SelectedValue)
                End If
                If Not (txt_nr_nota_fiscal.Text.Trim().Equals(String.Empty)) Then
                    comodato.nr_nota_fiscal = Convert.ToInt32(txt_nr_nota_fiscal.Text)
                End If

                comodato.nr_serie_nota_fiscal = txt_nr_serie_nota_fiscal.Text
                comodato.dt_emissao_nota_fiscal = txt_dt_emissao_nota_fiscal.Text
                If Not (txt_nr_valor.Text.Trim.Equals(String.Empty)) Then
                    comodato.nr_valor = Convert.ToDouble(txt_nr_valor.Text)
                End If
                If Not (txt_nr_nota_fiscal_devolucao.Text.Trim().Equals(String.Empty)) Then
                    comodato.nr_nota_fiscal_devolucao = Convert.ToInt32(txt_nr_nota_fiscal_devolucao.Text)
                End If
                comodato.dt_nota_fiscal_devolucao = txt_dt_nota_fiscal_devolucao.Text
                If Not (cbo_id_proprietario.SelectedValue.Trim().Equals(String.Empty)) Then
                    comodato.id_proprietario = Convert.ToInt32(cbo_id_proprietario.SelectedValue)
                End If
                If Not (txt_cd_pessoa.Text.Trim.Equals(String.Empty)) Then
                    comodato.id_pessoa = Convert.ToInt32(hf_id_pessoa.Value)
                End If

                comodato.nr_contrato = txt_nr_contrato.Text

                'If Not (cbo_tipo_bem.SelectedValue.Trim().Equals(String.Empty)) Then
                '    comodato.id_tipobem = Convert.ToInt32(cbo_tipo_bem.SelectedValue)
                'End If

                'comodato.dt_aquisicao = txt_dt_aquisicao.Text
                'comodato.dt_baixa = txt_dt_baixa.Text

                comodato.nr_patrimonio = txt_nr_patrimonio.Text
                If Not (cbo_id_alocado.SelectedValue.Trim().Equals(String.Empty)) Then
                    comodato.st_alocado = cbo_id_alocado.SelectedValue
                End If

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    comodato.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                comodato.id_modificador = Session("id_login")

                If Not (ViewState.Item("id_comodato") Is Nothing) Then

                    comodato.id_comodato = Convert.ToInt32(ViewState.Item("id_comodato"))
                    comodato.updateComodato()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteração
                    usuariolog.id_menu_item = 13
                    usuariolog.nm_nr_processo = comodato.nm_comodato
                    usuariolog.id_nr_processo = ViewState.Item("id_comodato").ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")

                Else

                    ViewState.Item("id_comodato") = comodato.insertComodato()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'insert
                    usuariolog.id_menu_item = 13
                    usuariolog.nm_nr_processo = comodato.nm_comodato
                    usuariolog.id_nr_processo = ViewState.Item("id_comodato").ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango
                    messageControl.Alert("Registro inserido com sucesso.")

                End If

                loadData()
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_comodato.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_comodato.aspx")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Public Sub New()

    End Sub
    Private Sub Habilitar_Produtor()
        rfv_produtor.Visible = True
        cv_produtor.Visible = True
        txt_cd_pessoa.Enabled = True
        btn_lupa_produtor.Visible = True
    End Sub
    Private Sub Desabilitar_Produtor()
        rfv_produtor.Visible = False
        cv_produtor.Visible = False
        lbl_nm_pessoa.Text = String.Empty
        txt_cd_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty
        lbl_nm_pessoa.Enabled = False
        txt_cd_pessoa.Enabled = False
        btn_lupa_produtor.Visible = False
 
    End Sub

 
    Protected Sub cbo_id_proprietario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_id_proprietario.SelectedIndexChanged
        If cbo_id_proprietario.SelectedValue = "2" Then 'se produtor força exibir pessoa
            Habilitar_Produtor()
        Else
            Desabilitar_Produtor()
        End If
    End Sub

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        If Me.cbo_id_proprietario.SelectedValue.ToString = "2" Then
            'A´pós retornar da modal, carrega os campos
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
        End If

    End Sub
    Private Sub carregarCamposProdutor()

        Try



            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub cv_produtor_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_produtor.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidpessoa As Int32

            If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
            End If
            pessoa.cd_pessoa = Me.txt_cd_pessoa.Text.Trim

            lidpessoa = pessoa.validarProdutor()

            If lidpessoa > 0 Then
                args.IsValid = True
                hf_id_pessoa.Value = lidpessoa
            Else
                hf_id_pessoa.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Produtor não cadastrado.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'Fran 02/03/2009 i rls17
        Response.Redirect("frm_comodato.aspx")
    End Sub
End Class
