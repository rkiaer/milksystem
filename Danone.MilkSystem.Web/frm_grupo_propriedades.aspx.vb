Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_grupo_propriedades
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_grupo_propriedades.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtor para Propriedade Matriz"
        End With
        With btn_lupa_produtor_filial
            .Attributes.Add("onclick", "javascript:ShowDialogProdutorFilial()")
            .ToolTip = "Filtrar Produtor para Propriedade Filial"
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
        If Not (Request("id_propriedade_matriz") Is Nothing) Then
            ViewState.Item("id_propriedade_matriz") = Request("id_propriedade_matriz")

            loadData()

        End If
    End Sub
    Private Sub loadData()

        Try
            Dim grupo As New GrupoPropriedades

            grupo.id_propriedade_matriz = (Convert.ToInt32(ViewState.Item("id_propriedade_matriz")))
            grupo.st_tipo_propriedade = "M"
            grupo.id_situacao = 1

            Dim dsgrupo As DataSet = grupo.getGrupoPropriedades()

            If dsgrupo.Tables(0).Rows.Count > 0 Then
                With dsgrupo.Tables(0).Rows(0)
                    cbo_estabelecimento.SelectedValue = .Item("id_estabelecimento")
                    txt_cd_pessoa.Text = .Item("cd_pessoa")
                    lbl_nm_pessoa.Text = .Item("nm_pessoa")
                    hf_id_pessoa.Value = .Item("id_pessoa")
                    cbo_estabelecimento.Enabled = False
                    txt_cd_pessoa.Enabled = False
                    btn_lupa_produtor.Visible = False
                    carregarPropriedadesMatriz()
                    cbo_propriedade.SelectedValue = .Item("id_propriedade_matriz")
                    cbo_propriedade.Enabled = False
                    btn_adicionar_matriz.Visible = False
                    txt_cd_pessoa_filial.Enabled = True
                    btn_lupa_produtor_filial.Enabled = True
                    cbo_situacao.SelectedValue = .Item("id_situacao")
                    btn_adicionar.Enabled = True
                    lk_concluir.Enabled = True
                    lk_concluirFooter.Enabled = True
                    If cbo_situacao.SelectedValue.Equals("1") Then 'se ativo deixa inativar
                        cbo_situacao.Enabled = True
                    End If
                    'carregarPropriedadesgrupo()


                End With
            End If

            grupo.st_tipo_propriedade = String.Empty
            grupo.id_situacao = 1 'trazer apenas ativos
            dsgrupo = grupo.getGrupoPropriedades()

            If (dsgrupo.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsgrupo.Tables(0), "nm_pessoa_matriz, st_tipo_propriedade desc,nm_pessoa,id_propriedade")
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
                deletegrupopropriedades(Convert.ToInt32(e.CommandArgument.ToString()))

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
                If lbl_st_relacionamento.Text.Equals("F") Then
                    btn_desativar.Enabled = True
                    btn_desativar.ImageUrl = "~/img/icone_excluir.gif"
                    btn_desativar.ToolTip = "Desativar registro propriedade filial."
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
                Dim grupo As New GrupoPropriedades
                grupo.id_propriedade_matriz = ViewState.Item("id_propriedade_matriz")
                grupo.id_propriedade = cbo_propriedade_filial.SelectedValue
                grupo.st_tipo_propriedade = "F" 'filial
                grupo.id_modificador = Session("id_login")
                grupo.insertGrupoPropriedades()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 200
                usuariolog.id_nr_processo = grupo.id_propriedade_matriz

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub


    Private Sub deletegrupopropriedades(ByVal id_grupo_propriedades As Int32)
        Try
            Try

                Dim grupo As New GrupoPropriedades

                grupo.id_grupo_propriedades = id_grupo_propriedades
                grupo.id_modificador = Session("id_login")
                grupo.deleteGrupoPropriedades()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 5 'deleção
                usuariolog.id_menu_item = 200
                usuariolog.id_nr_processo = grupo.id_grupo_propriedades

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
        Response.Redirect("lst_grupo_propriedades.aspx")
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_grupo_propriedades.aspx")
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

                    carregarPropriedadesMatriz()
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_pessoa_filial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa_filial.TextChanged
        lbl_nm_pessoa_filial.Text = String.Empty
        hf_id_pessoa_filial.Value = String.Empty
        'fran chamado 684 i 
        Try
            If Not txt_cd_pessoa_filial.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa_filial.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 'fran 05/05/2010
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa_filial.Enabled = True
                    lbl_nm_pessoa_filial.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa_filial.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")

                    carregarPropriedadesFilial()

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
            carregarPropriedadesMatriz()
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
    Private Sub carregarPropriedadesMatriz()

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
    Private Sub carregarPropriedadesGrupoPropriedades()

        Try

            Dim grupo As New GrupoPropriedades

            grupo.id_propriedade_matriz = ViewState.Item("id_propriedade_matriz")
            grupo.id_situacao = 1
            grupo.id_situacao_propriedade = 1




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarPropriedadesFilial()

        Try

            Dim propriedade As New Propriedade

            propriedade.id_pessoa = hf_id_pessoa_filial.Value

            cbo_propriedade_filial.Enabled = True
            cbo_propriedade_filial.DataSource = propriedade.getPropriedadeByFilters()
            cbo_propriedade_filial.DataTextField = "ds_propriedade"
            cbo_propriedade_filial.DataValueField = "id_propriedade"
            cbo_propriedade_filial.DataBind()
            cbo_propriedade_filial.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_propriedade_filial.SelectedValue = 0



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub btn_lupa_produtor_filial_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor_filial.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            Me.lbl_nm_pessoa_filial.Visible = True
            carregarCamposProdutorFilial()
            carregarPropriedadesFilial()
        End If

    End Sub
    Private Sub carregarCamposProdutorFilial()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa_filial.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa_filial.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
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

    Protected Sub btn_adicionar_matriz_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar_matriz.Click
        Try
            If Page.IsValid Then
                Dim grupo As New GrupoPropriedades
                grupo.id_propriedade_matriz = cbo_propriedade.SelectedValue
                grupo.id_propriedade = cbo_propriedade.SelectedValue
                grupo.st_tipo_propriedade = "M" 'matriz
                grupo.id_modificador = Session("id_login")
                grupo.insertGrupoPropriedades()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'inclusao
                usuariolog.id_menu_item = 200
                usuariolog.id_nr_processo = grupo.id_propriedade_matriz
                usuariolog.nm_nr_processo = grupo.id_propriedade_matriz.ToString

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                ViewState.Item("id_propriedade_matriz") = cbo_propriedade.SelectedValue

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

                Dim grupo As New GrupoPropriedades()

                grupo.id_propriedade_matriz = Convert.ToInt32(ViewState.Item("id_propriedade_matriz"))
                grupo.id_situacao = cbo_situacao.SelectedValue
                grupo.id_modificador = Session("id_login")

                grupo.updateGrupoPropriedades()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.id_menu_item = 200
                usuariolog.id_nr_processo = grupo.id_propriedade_matriz

                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro alterado com sucesso.")
                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub cv_propriedadefilial_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_propriedadefilial.ServerValidate
        Try
            Dim lmsg As String
            Dim grupo As New GrupoPropriedades
            Dim dsgrupo As DataSet
            args.IsValid = True

            'verifica se a propriedade a ser incluida já existe em algum grupo
            grupo.id_propriedade = Convert.ToInt32(cbo_propriedade_filial.SelectedValue)
            grupo.id_situacao = 1
            dsgrupo = grupo.getGrupoPropriedades
            If dsgrupo.Tables(0).Rows.Count > 0 Then
                lmsg = "Já existe a propriedade informada nos cadastros de GRUPO PROPRIEDADES para a propriedade matriz " & dsgrupo.Tables(0).Rows(0).Item("id_propriedade_matriz").ToString
                args.IsValid = False
            End If

            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_propriedadematriz_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_propriedadematriz.ServerValidate
        Try
            Dim lmsg As String
            Dim grupo As New GrupoPropriedades
            Dim dsgrupo As DataSet
            args.IsValid = True

            'verifica se a propriedade a ser incluida já existe em algum grupo
            grupo.id_propriedade = Convert.ToInt32(cbo_propriedade.SelectedValue)
            grupo.id_situacao = 1
            dsgrupo = grupo.getGrupoPropriedades
            If dsgrupo.Tables(0).Rows.Count > 0 Then
                lmsg = "Já existe a propriedade informada nos cadastros de GRUPO PROPRIEDADES para a propriedade matriz " & dsgrupo.Tables(0).Rows(0).Item("id_propriedade_matriz").ToString
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
