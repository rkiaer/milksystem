Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.Math

Partial Class lst_pessoa_contrato_aprovar_2N

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = Me.cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        ViewState.Item("id_contrato") = Me.cbo_contrato.SelectedValue
        ViewState.Item("id_cluster") = Me.cbo_cluster.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_pessoa_contrato_aprovar_2N.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_pessoa_contrato_aprovar_2N.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 189
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Produtores"
            '.Style("cursor") = "hand"
        End With

    End Sub


    Private Sub loadDetails()

        Try

            ViewState.Item("sortExpression") = "nm_pessoa"


            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim cluster As New Cluster
            cbo_cluster.DataSource = cluster.getClusterByFilters()
            cbo_cluster.DataTextField = "nm_cluster"
            cbo_cluster.DataValueField = "id_cluster"
            cbo_cluster.DataBind()
            cbo_cluster.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim contrato As New PessoaContrato

            contrato.id_estabelecimento = ViewState("id_estabelecimento").ToString
            contrato.id_situacao = 1 'ativo
            contrato.id_situacao_pessoa_contrato = 2 'aprovacao 1o nivel
            If ViewState("id_pessoa").ToString.Equals(String.Empty) Then
                contrato.id_pessoa = 0
            Else
                contrato.id_pessoa = ViewState("id_pessoa").ToString
            End If
            contrato.id_contrato = ViewState("id_contrato").ToString
            If ViewState("id_cluster").ToString.Equals(String.Empty) Then
                contrato.id_cluster = 0
            Else
                contrato.id_cluster = ViewState("id_cluster").ToString
            End If

            Dim dscontrato As DataSet = contrato.getPessoaContratoAprovacao()

            If (dscontrato.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscontrato.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                Me.lk_aprovar.Enabled = True
                Me.lk_reprovar.Enabled = True

            Else
                Me.lk_aprovar.Enabled = False
                Me.lk_reprovar.Enabled = False
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        saveCheckBox()
        loadData()

    End Sub


    Protected Sub lk_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_aprovar.Click
        Try
            Dim contrato As New PessoaContrato

            If saveCheckBox() = True Then

                contrato.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
                contrato.id_modificador = Session("id_login")

                contrato.updatePessoaContratoAprovarSelecionados2Nivel()
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 189
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 
                loadData()

                messageControl.Alert("Aprovação 2.o Nível concluída com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser aprovado. Por favor selecione algum contrato.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function saveCheckBox() As Boolean

        Try

            Dim li As Integer

            For li = 0 To gridResults.Rows.Count - 1
                Dim contrato As New PessoaContrato()
                contrato.id_pessoa_contrato = gridResults.DataKeys(li).Value.ToString
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    contrato.st_selecao = "1"
                    saveCheckBox = True     ' Indica que tem item selecionado
                Else
                    contrato.st_selecao = "0"
                End If
                contrato.updatePessoaContratoSelecao()
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub lk_reprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_reprovar.Click
        Try
            Dim contrato As New PessoaContrato

            If saveCheckBox() = True Then
                contrato.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
                contrato.id_modificador = Session("id_login")
                contrato.updatePessoaContratoNaoAprovarSelecionados2Nivel()
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 189
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 
                loadData()

                messageControl.Alert("Itens reprovados com sucesso.")

            Else
                messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione algum modelo de contrato.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                ch.Checked = ck_header.Checked
            Next

            ' Seleciona tudo o que o botão Pesquisar trouxer - i
            Dim contrato As New PessoaContrato
            contrato.id_estabelecimento = ViewState("id_estabelecimento").ToString
            contrato.id_situacao = 1 'ativo
            contrato.id_situacao_pessoa_contrato = 2 'aprovado 10 nivel
            If ViewState("id_pessoa").ToString.Equals(String.Empty) Then
                contrato.id_pessoa = 0
            Else
                contrato.id_pessoa = ViewState("id_pessoa").ToString
            End If
            contrato.id_contrato = ViewState("id_contrato").ToString
            If ViewState("id_cluster").ToString.Equals(String.Empty) Then
                contrato.id_cluster = 0
            Else
                contrato.id_cluster = ViewState("id_cluster").ToString
            End If

            If ck_header.Checked = True Then
                contrato.st_selecao = "1"
            Else
                contrato.st_selecao = "0"
            End If

            contrato.updatePessoaContratoSelecaoTodos()
            ' Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        If cbo_estabelecimento.SelectedValue.ToString = "0" Then 'se nao selecioou estabelecimento

            cbo_contrato.SelectedValue = 0
            cbo_contrato.Enabled = False
            txt_cd_pessoa.Text = String.Empty
            hf_id_pessoa.Value = String.Empty
            txt_cd_pessoa.Enabled = False
            btn_lupa_produtor.Enabled = False

            gridResults.Visible = False
        Else

            Dim contrato As New Contrato
            contrato.id_estabelecimento = cbo_estabelecimento.SelectedValue
            contrato.id_situacao = 1
            cbo_contrato.DataSource = contrato.getContratoByFilters()
            cbo_contrato.DataTextField = "ds_contrato"
            cbo_contrato.DataValueField = "id_contrato"
            cbo_contrato.DataBind()
            cbo_contrato.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_contrato.Enabled = True
            txt_cd_pessoa.Text = String.Empty
            hf_id_pessoa.Value = String.Empty
            txt_cd_pessoa.Enabled = True
            btn_lupa_produtor.Enabled = True

        End If
    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        'lbl_nm_pessoa.Text = String.Empty
        'lbl_nm_pessoa.Visible = False
        'hf_id_pessoa.Value = String.Empty

        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty

        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 'fran 05/05/2010
                produtor.id_estabelecimento = cbo_estabelecimento.SelectedValue
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
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

End Class
