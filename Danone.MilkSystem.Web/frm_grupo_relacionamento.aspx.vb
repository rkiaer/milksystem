Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_grupo_relacionamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_grupo_relacionamento.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtor para Propriedade Titular"
        End With
        With btn_lupa_produtor_agregada
            .Attributes.Add("onclick", "javascript:ShowDialogProdutorAgregada()")
            .ToolTip = "Filtrar Produtor para Propriedade Agregada"
        End With
    End Sub
    Private Sub loadDetails()

        Dim situacoes As New Situacao

        cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
        cbo_situacao.DataTextField = "nm_situacao"
        cbo_situacao.DataValueField = "id_situacao"
        cbo_situacao.DataBind()
        cbo_situacao.Items.FindByValue("1").Selected = True
        cbo_situacao.Enabled = False

        Dim estabelecimento As New Estabelecimento

        cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
        cbo_estabelecimento.DataTextField = "nm_estabelecimento"
        cbo_estabelecimento.DataValueField = "id_estabelecimento"
        cbo_estabelecimento.DataBind()
        cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
        If Not (Request("id_propriedade_titular") Is Nothing) Then
            ViewState.Item("id_propriedade_titular") = Request("id_propriedade_titular")

            loadData()
        Else
            'Dim gruporelacionamento As New GrupoRelacionamento
            'gruporelacionamento.id_propriedade_titular = -1
            'Dim dsgrupo As DataSet = gruporelacionamento.getGrupoRelacionamento()
            'Dim dr As DataRow = dsgrupo.Tables(0).NewRow()
            'dsgrupo.Tables(0).Rows.InsertAt(dr, 0)
            'gridResults.Visible = True
            'gridResults.DataSource = Helper.getDataView(dsgrupo.Tables(0), "")
            'gridResults.DataBind()
            'gridResults.Rows(0).Cells.Clear()
            'gridResults.Rows(0).Cells.Add(New TableCell())
            'gridResults.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            'gridResults.Rows(0).Cells(0).Text = "Informe a propriedade e a unidade de produção proprietárias e adicione as propriedades parceiras."
            'gridResults.Rows(0).Cells(0).ColumnSpan = 7
            'ViewState.Item("id_propriedade") = 0
            'ViewState.Item("id_unidade_producao") = 0

        End If
    End Sub
    Private Sub loadData()

        Try
            Dim gruporelacionamento As New GrupoRelacionamento

            gruporelacionamento.id_propriedade_titular = (Convert.ToInt32(ViewState.Item("id_propriedade_titular")))
            gruporelacionamento.st_relacionamento = "T"

            Dim dsgrupo As DataSet = gruporelacionamento.getGrupoRelacionamento()

            If dsgrupo.Tables(0).Rows.Count > 0 Then
                With dsgrupo.tables(0).rows(0)
                    cbo_estabelecimento.SelectedValue = .Item("id_estabelecimento")
                    txt_cd_pessoa.Text = .item("cd_pessoa")
                    lbl_nm_pessoa.Text = .item("nm_pessoa")
                    hf_id_pessoa.Value = .Item("id_pessoa")
                    cbo_estabelecimento.Enabled = False
                    txt_cd_pessoa.Enabled = False
                    btn_lupa_produtor.Visible = False
                    carregarPropriedadesTitular()
                    cbo_propriedade.SelectedValue = .item("id_propriedade_titular")
                    cbo_propriedade.Enabled = False
                    btn_adicionar_titular.Visible = False
                    txt_cd_pessoa_agregada.Enabled = True
                    btn_lupa_produtor_agregada.Enabled = True
                    cbo_situacao.SelectedValue = .item("id_situacao")
                    If .Item("st_participa_poupanca").Equals("G") Then
                        lbl_participa_poupanca.Text = "Em Grupo"
                    End If
                    If .Item("st_participa_poupanca").Equals("I") Then
                        lbl_participa_poupanca.Text = "Individual"
                    End If
                    btn_adicionar.Enabled = True
                    lk_concluir.Enabled = True
                    lk_concluirFooter.Enabled = True
                    If cbo_situacao.SelectedValue.Equals("1") Then 'se ativo deixa inativar
                        cbo_situacao.Enabled = True
                    End If
                    'carregarPropriedadesGrupoRelacionamento()

                    If IsDBNull(.Item("id_propriedade_responsavel_bonus")) Then
                        lbl_responsavel_bonus.Text = String.Empty
                    Else
                        lbl_responsavel_bonus.Text = .Item("id_propriedade_responsavel_bonus")
                    End If

                    cbo_compartilha_qualidade.SelectedValue = .Item("st_compartilha_qualidade")
                    cbo_compartilha_volume.SelectedValue = .Item("st_compartilha_volume")

                End With
            End If

            gruporelacionamento.st_relacionamento = String.Empty
            gruporelacionamento.id_situacao = 1 'trazer apenas ativos
            dsgrupo = gruporelacionamento.getGrupoRelacionamento()

            If (dsgrupo.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsgrupo.Tables(0), "nm_pessoa_titular, st_relacionamento desc,nm_pessoa,id_propriedade")
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

 

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Delete"
                deletegruporelacionamento(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select
    End Sub


    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        Try

            If (e.Row.RowType <> DataControlRowType.Header _
                And e.Row.RowType <> DataControlRowType.Footer _
                And e.Row.RowType <> DataControlRowType.Pager) Then

                Dim lbl_st_relacionamento As Label = CType(e.Row.FindControl("lbl_st_relacionamento"), Label)
                Dim btn_desativar As Anthem.ImageButton = CType(e.Row.FindControl("btn_desativar"), Anthem.ImageButton)

                'se já aderiu a poupanca nao deixa selecionar
                If lbl_st_relacionamento.Text.Equals("A") Then
                    btn_desativar.Enabled = True
                    btn_desativar.ImageUrl = "~/img/icone_excluir.gif"
                    btn_desativar.ToolTip = "Desativar registro propriedade agregada."
                Else
                    btn_desativar.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                    btn_desativar.Enabled = False
                    btn_desativar.ToolTip = String.Empty
                End If

            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub btn_adicionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar.Click
        Try
            If Page.IsValid Then
                Dim grupo As New GrupoRelacionamento
                grupo.id_propriedade_titular = ViewState.Item("id_propriedade_titular")
                grupo.id_propriedade = cbo_propriedade_agregada.SelectedValue
                grupo.st_participa_poupanca = "G" 'em grupo assume como default
                grupo.st_relacionamento = "A" 'agregado
                grupo.id_modificador = Session("id_login")
                grupo.st_compartilha_qualidade = cbo_compartilha_qualidade.SelectedValue
                grupo.st_compartilha_volume = cbo_compartilha_volume.SelectedValue
                grupo.insertGrupoRelacionamento()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 179
                usuariolog.id_nr_processo = grupo.id_propriedade_titular

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    
    Private Sub deletegruporelacionamento(ByVal id_grupo_relacionamento As Int32)
        Try
            Try

                Dim grupo As New GrupoRelacionamento

                grupo.id_grupo_relacionamento = id_grupo_relacionamento
                grupo.id_modificador = Session("id_login")
                grupo.deleteGrupoRelacionamento()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 5 'delecao
                usuariolog.id_menu_item = 179
                usuariolog.id_nr_processo = grupo.id_grupo_relacionamento

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro excluído com sucesso!")
                loadData()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_grupo_relacionamento.aspx")
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_grupo_relacionamento.aspx")
    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty

        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")

                    carregarPropriedadesTitular()
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_pessoa_agregada_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa_agregada.TextChanged
        lbl_nm_pessoa_agregada.Text = String.Empty
        hf_id_pessoa_agregada.Value = String.Empty
        'fran chamado 684 i 
        Try
            If Not txt_cd_pessoa_agregada.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa_agregada.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 'fran 05/05/2010
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa_agregada.Enabled = True
                    lbl_nm_pessoa_agregada.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa_agregada.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")

                    carregarPropriedadesAgregada()

                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposProdutor()
            carregarPropriedadesTitular()
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
    Private Sub carregarPropriedadesTitular()

        Try

            Dim propriedade As New Propriedade

            propriedade.id_pessoa = hf_id_pessoa.Value

            cbo_propriedade.Enabled = True
            cbo_propriedade.DataSource = propriedade.getPropriedadeByFilters()
            cbo_propriedade.DataTextField = "ds_propriedade"
            cbo_propriedade.DataValueField = "id_propriedade"
            cbo_propriedade.DataBind()
            cbo_propriedade.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_propriedade.SelectedValue = 0



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarPropriedadesGrupoRelacionamento()

        Try

            Dim grupo As New GrupoRelacionamento

            grupo.id_propriedade_titular = ViewState.Item("id_propriedade_titular")
            grupo.id_situacao = 1
            grupo.id_situacao_propriedade = 1




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarPropriedadesAgregada()

        Try

            Dim propriedade As New Propriedade

            propriedade.id_pessoa = hf_id_pessoa_agregada.Value

            cbo_propriedade_agregada.Enabled = True
            cbo_propriedade_agregada.DataSource = propriedade.getPropriedadeByFilters()
            cbo_propriedade_agregada.DataTextField = "ds_propriedade"
            cbo_propriedade_agregada.DataValueField = "id_propriedade"
            cbo_propriedade_agregada.DataBind()
            cbo_propriedade_agregada.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_propriedade_agregada.SelectedValue = 0



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub btn_lupa_produtor_agregada_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor_agregada.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa_agregada.Visible = True
            carregarCamposProdutorAgregada()
            carregarPropriedadesAgregada()
        End If
        
    End Sub
    Private Sub carregarCamposProdutorAgregada()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa_agregada.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa_agregada.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

  
    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        If cbo_estabelecimento.SelectedValue <> 0 Then
            txt_cd_pessoa.Enabled = True
            btn_lupa_produtor.Enabled = True

        End If
    End Sub

    Protected Sub cbo_propriedade_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_propriedade.SelectedIndexChanged
        If cbo_propriedade.SelectedValue > 0 Then
            btn_adicionar.Enabled = True
        End If
    End Sub

    Protected Sub btn_adicionar_titular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar_titular.Click
        Try
            If Page.IsValid Then
                Dim grupo As New GrupoRelacionamento
                grupo.id_propriedade_titular = cbo_propriedade.SelectedValue
                grupo.id_propriedade = cbo_propriedade.SelectedValue
                grupo.st_participa_poupanca = "G" 'em grupo assume como default
                grupo.st_relacionamento = "T" 'titular
                grupo.id_modificador = Session("id_login")
                grupo.st_compartilha_qualidade = cbo_compartilha_qualidade.SelectedValue
                grupo.st_compartilha_volume = cbo_compartilha_volume.SelectedValue
                grupo.insertGrupoRelacionamento()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 179
                usuariolog.id_nr_processo = grupo.id_propriedade_titular

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                ViewState.Item("id_propriedade_titular") = cbo_propriedade.SelectedValue

                loadData()
            End If
            

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()

    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()

    End Sub
    Private Sub updateData()

        If Page.IsValid Then
            Try

                Dim grupo As New GrupoRelacionamento()

                grupo.id_propriedade_titular = Convert.ToInt32(ViewState.Item("id_propriedade_titular"))
                grupo.st_compartilha_qualidade = cbo_compartilha_qualidade.SelectedValue
                grupo.st_compartilha_volume = cbo_compartilha_volume.SelectedValue
                grupo.id_situacao = cbo_situacao.SelectedValue
                grupo.id_modificador = Session("id_login")

                grupo.updateGrupoRelacionamento()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.id_menu_item = 179
                usuariolog.id_nr_processo = grupo.id_propriedade_titular

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro alterado com sucesso.")
                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub cv_propriedadeagregada_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_propriedadeagregada.ServerValidate
        Try
            Dim lmsg As String
            Dim grupo As New GrupoRelacionamento
            Dim dsgrupo As DataSet
            args.IsValid = True

            'verifica se a propriedade a ser incluida já existe em algum grupo
            grupo.id_propriedade = Convert.ToInt32(cbo_propriedade_agregada.SelectedValue)
            grupo.id_situacao = 1
            dsgrupo = grupo.getGrupoRelacionamento
            If dsgrupo.Tables(0).Rows.Count > 0 Then
                lmsg = "Já existe a propriedade informada nos cadastros de GRUPO DE RELACIONAMENTO para a propriedade titular " & dsgrupo.Tables(0).Rows(0).Item("id_propriedade_titular").ToString
                args.IsValid = False
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_propriedadetitular_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_propriedadetitular.ServerValidate
        Try
            Dim lmsg As String
            Dim grupo As New GrupoRelacionamento
            Dim dsgrupo As DataSet
            args.IsValid = True

            'verifica se a propriedade a ser incluida já existe em algum grupo
            grupo.id_propriedade = Convert.ToInt32(cbo_propriedade.SelectedValue)
            grupo.id_situacao = 1
            dsgrupo = grupo.getGrupoRelacionamento
            If dsgrupo.Tables(0).Rows.Count > 0 Then
                lmsg = "Já existe a propriedade informada nos cadastros de GRUPO DE RELACIONAMENTO para a propriedade titular " & dsgrupo.Tables(0).Rows(0).Item("id_propriedade_titular").ToString
                args.IsValid = False
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

End Class
