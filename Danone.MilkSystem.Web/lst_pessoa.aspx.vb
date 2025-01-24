Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail



Partial Class lst_pessoa
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue.ToString
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim().ToString
        ViewState.Item("nm_pessoa") = txt_nm_pessoa.Text.Trim().ToString
        ViewState.Item("st_categoria") = cbo_categoria.SelectedValue.ToString
        ViewState.Item("id_grupo") = cbo_Grupo.SelectedValue.ToString
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue.ToString
        ViewState.Item("cd_codigo_SAP") = txt_codigo_SAP.text.ToString    ' 02/2012 Projeto Themis
        'fran 06/2018 - dango 2018 i 
        ViewState.Item("id_contrato") = cbo_contrato.SelectedValue.ToString
        ViewState.Item("id_cluster") = cbo_cluster.SelectedValue.ToString
        'fran 06/2018 - dango 2018 f

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_pessoa.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_pessoa.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 4
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            Dim grupo As New Grupo

            ' 08/08/2008 - Somente nesta tela pode exibir o estabelecimento reservado '999' para pessoas vindas do EMS
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoPessoaByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_categoria.Items.Add(New ListItem("[Selecione]", String.Empty))
            cbo_categoria.Items.Add(New ListItem("Fisica", "F"))
            cbo_categoria.Items.Add(New ListItem("Juridica", "J"))

            cbo_Grupo.DataSource = grupo.getGruposByFilters()
            cbo_Grupo.DataTextField = "nm_grupo"
            cbo_Grupo.DataValueField = "id_grupo"
            cbo_Grupo.DataBind()
            cbo_Grupo.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'frn 06/2018 i DANGO 2018
            Dim cluster As New Cluster
            cbo_cluster.DataSource = cluster.getClusterByFilters()
            cbo_cluster.DataTextField = "nm_cluster"
            cbo_cluster.DataValueField = "id_cluster"
            cbo_cluster.DataBind()
            cbo_cluster.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim contrato As New Contrato
            cbo_contrato.DataSource = contrato.getContratoByFilters()
            cbo_contrato.DataTextField = "ds_contrato"
            cbo_contrato.DataValueField = "id_contrato"
            cbo_contrato.DataBind()
            cbo_contrato.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'BUSCA SE O USURIO TEM ACESSO AO PROCESSO MODELO DE CONTRATO PRODUTOR
            Dim usuarioprocesso As New GrupoAcessoProcesso
            usuarioprocesso.id_menu_item_processo = 1 'Proceurar o processo 1 - Modelo de COntrato Produtor
            usuarioprocesso.id_usuario = Session("id_login") 'usuario de acesso
            Dim dsusuarioprocesso As DataSet = usuarioprocesso.getGrupoAcessoProcessoByFilters
            'SE TEM DIREIRO A ACESSAR MODELO DE CONBTRATO
            If dsusuarioprocesso.Tables(0).Rows.Count > 0 Then
                Dim contratoaprovacao As New PessoaContrato
                contratoaprovacao.id_situacao_pessoa_contrato = 1 'todos os contratos para aprovacao 1o nivel ('EM APROVACAO')
                If contratoaprovacao.getPessoaContratoAprovacao.Tables(0).Rows.Count > 0 Then
                    ViewState.Item("notificar1nivel") = True
                Else
                    ViewState.Item("notificar1nivel") = False
                End If

                contratoaprovacao.id_situacao_pessoa_contrato = 2 'todos os contratos para aprovacao 2o nivel 
                If contratoaprovacao.getPessoaContratoAprovacao.Tables(0).Rows.Count > 0 Then
                    ViewState.Item("notificar2nivel") = True
                Else
                    ViewState.Item("notificar2nivel") = False
                End If

                If ViewState.Item("notificar1nivel") = True OrElse ViewState.Item("notificar2nivel") = True Then
                    img_notificacao.Visible = True
                    lk_email.Visible = True
                    lk_email.Enabled = True
                Else
                    lk_email.Visible = True
                    lk_email.Enabled = False
                End If

            Else 'SE NAO TEM ACESSO
                ViewState.Item("notificar1nivel") = False
                ViewState.Item("notificar2nivel") = False
            End If
            'frn 06/2018 f DANGO 2018

            ViewState.Item("sortExpression") = "nm_pessoa asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("pessoa", cbo_estabelecimento.ID).Equals("0")) And Not (customPage.getFilterValue("pessoa", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("pessoa", cbo_estabelecimento.ID)
            cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = "0"
            cbo_estabelecimento.SelectedValue = "0"
        End If

        If Not (customPage.getFilterValue("pessoa", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("pessoa", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("pessoa", txt_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("pessoa", txt_nm_pessoa.ID)
            txt_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If


        If Not (customPage.getFilterValue("pessoa", cbo_categoria.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("st_categoria") = customPage.getFilterValue("pessoa", cbo_categoria.ID)
            cbo_categoria.Text = ViewState.Item("st_categoria").ToString()
        Else
            ViewState.Item("st_categoria") = String.Empty
        End If


        If Not (customPage.getFilterValue("pessoa", cbo_situacao.ID).Equals("0")) And Not (customPage.getFilterValue("pessoa", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("pessoa", cbo_situacao.ID)
            cbo_situacao.SelectedValue = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = "0"
            cbo_situacao.SelectedValue = "0"
        End If

        If Not (customPage.getFilterValue("pessoa", cbo_Grupo.ID).Equals(String.Empty)) And Not (customPage.getFilterValue("pessoa", cbo_Grupo.ID).Equals("0")) Then
            hasFilters = True
            ViewState.Item("id_grupo") = customPage.getFilterValue("pessoa", cbo_Grupo.ID)
            cbo_Grupo.SelectedValue = ViewState.Item("id_grupo").ToString()
        Else
            ViewState.Item("id_grupo") = "0"
            cbo_Grupo.SelectedValue = "0"
        End If
        'fran dango 2018 i
        If Not (customPage.getFilterValue("pessoa", cbo_contrato.ID).Equals("0")) And Not (customPage.getFilterValue("pessoa", cbo_contrato.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_contrato") = customPage.getFilterValue("pessoa", cbo_contrato.ID)
            cbo_contrato.SelectedValue = ViewState.Item("id_grupo").ToString()
        Else
            ViewState.Item("id_contrato") = "0"
            cbo_contrato.SelectedValue = "0"
        End If
        If Not (customPage.getFilterValue("pessoa", cbo_cluster.ID).Equals(String.Empty)) And Not (customPage.getFilterValue("pessoa", cbo_cluster.ID).Equals("0")) Then
            hasFilters = True
            ViewState.Item("id_cluster") = customPage.getFilterValue("pessoa", cbo_cluster.ID)
            cbo_cluster.SelectedValue = ViewState.Item("id_cluster").ToString()
        Else
            ViewState.Item("id_cluster") = "0"
            cbo_cluster.SelectedValue = "0"
        End If
        'fran dango 2018 f

        ' 02/2012 - Projeto themis - i
        If Not (customPage.getFilterValue("pessoa", txt_codigo_SAP.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_codigo_SAP") = customPage.getFilterValue("pessoa", txt_codigo_SAP.ID)
            txt_codigo_SAP.Text = ViewState.Item("cd_codigo_SAP").ToString()
        Else
            ViewState.Item("cd_codigo_SAP") = String.Empty
        End If
        ' 02/2012 - Projeto themis - f


        If Not (customPage.getFilterValue("pessoa", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("pessoa", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("pessoa")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim pessoa As New Pessoa

            pessoa.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString()
            pessoa.cd_pessoa = ViewState.Item("cd_pessoa").ToString()
            pessoa.st_categoria = ViewState.Item("st_categoria").ToString()
            pessoa.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            pessoa.id_grupo = Convert.ToInt32(ViewState.Item("id_grupo").ToString())
            pessoa.nm_pessoa = ViewState.Item("nm_pessoa").ToString
            pessoa.cd_codigo_SAP = ViewState.Item("cd_codigo_SAP").ToString  ' 02/2012 - Projeto Themis
            'fran dango 2018 i
            pessoa.id_contrato = ViewState.Item("id_contrato").ToString()
            pessoa.id_cluster = ViewState.Item("id_cluster").ToString()
            'fran dango 2018 f 

            Dim dsPessoa As DataSet = pessoa.getPessoaByFilters()

            If (dsPessoa.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPessoa.Tables(0), ViewState.Item("sortExpression"))
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
        Me.loadData()

    End Sub


    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "cd_pessoa"
                If (ViewState.Item("sortExpression")) = "cd_pessoa asc" Then
                    ViewState.Item("sortExpression") = "cd_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "cd_pessoa asc"
                End If


            Case "nm_pessoa"
                If (ViewState.Item("sortExpression")) = "nm_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_pessoa asc"
                End If

            Case "nm_grupo"
                If (ViewState.Item("sortExpression")) = "nm_grupo asc" Then
                    ViewState.Item("sortExpression") = "nm_grupo desc"
                Else
                    ViewState.Item("sortExpression") = "nm_grupo asc"
                End If

            Case "st_categoria"
                If (ViewState.Item("sortExpression")) = "st_categoria asc" Then
                    ViewState.Item("sortExpression") = "st_categoria desc"
                Else
                    ViewState.Item("sortExpression") = "st_categoria asc"
                End If

            Case "cd_codigo_SAP"  ' 02/2012 Projeto Themis
                If (ViewState.Item("sortExpression")) = "cd_codigo_SAP asc" Then
                    ViewState.Item("sortExpression") = "cd_codigo_SAP desc"
                Else
                    ViewState.Item("sortExpression") = "cd_codigo_SAP asc"
                End If
            Case "cd_contrato"  ' 02/2012 Projeto Themis
                If (ViewState.Item("sortExpression")) = "cd_contrato asc" Then
                    ViewState.Item("sortExpression") = "cd_contrato desc"
                Else
                    ViewState.Item("sortExpression") = "cd_contrato asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("pessoa", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("pessoa", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("pessoa", txt_nm_pessoa.ID, ViewState.Item("nm_pessoa").ToString)
            customPage.setFilter("pessoa", cbo_categoria.ID, ViewState.Item("st_categoria").ToString)
            customPage.setFilter("pessoa", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("pessoa", cbo_Grupo.ID, ViewState.Item("id_grupo").ToString)
            customPage.setFilter("pessoa", txt_codigo_SAP.ID, ViewState.Item("cd_codigo_SAP").ToString)  ' 02/2012 - Projeto themis - i
            customPage.setFilter("pessoa", cbo_cluster.ID, ViewState.Item("id_cluster").ToString)
            customPage.setFilter("pessoa", cbo_contrato.ID, ViewState.Item("id_contrato").ToString)
            customPage.setFilter("pessoa", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_pessoa.aspx?id_pessoa=" + e.CommandArgument.ToString())

            Case "delete"
                deletePessoa(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deletePessoa(ByVal id_pessoa As Integer)

        Try

            Dim pessoa As New Pessoa()
            pessoa.id_pessoa = id_pessoa
            pessoa.id_modificador = Convert.ToInt32(Session("id_login"))
            pessoa.deletePessoa()
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 4
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    'Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
    'saveFilters()
    'Response.Redirect("frm_pessoa.aspx")
    'End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            If (e.Row.Cells(3).Text.Trim().Equals("J")) Then
                e.Row.Cells(3).Text = "Jurídica"
            Else
                e.Row.Cells(3).Text = "Física"
            End If

        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_pessoa.aspx")
    End Sub

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        If Page.IsValid = True Then
            Try

                Dim notificacao As New Notificacao
                Dim lAssunto As String
                Dim lCorpo As String
                Dim bmsgOK As Boolean = True

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 9 'ENVIO EMAIL
                usuariolog.id_menu_item = 4
                usuariolog.id_menu_item_processo = 1
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f


                If ViewState.Item("notificar1nivel") = True Then
                    lAssunto = "Aprovação 1.o Nível para Modelo de Contrato do Produtor "
                    lCorpo = "Existem modelos de contrato(s) de Produtor(es) pendente(s) para aprovação 1.o Nível."

                    If notificacao.enviaMensagemEmail(19, lAssunto, lCorpo, MailPriority.High) = True Then
                        bmsgOK = True
                    Else
                        bmsgOK = False
                    End If
                End If

                If ViewState.Item("notificar2nivel") = True And bmsgOK = True Then 'se deve notificar 2 nivel e msg foi enviada com sucesso
                    lAssunto = "Aprovação 2.o Nível para Modelo de Contrato do Produtor "
                    lCorpo = "Existem modelos de contrato(s) de Produtor(es) pendente(s) para aprovação 2.o Nível."

                    If notificacao.enviaMensagemEmail(20, lAssunto, lCorpo, MailPriority.High) = True Then
                        bmsgOK = True
                    Else
                        bmsgOK = False
                    End If
                End If

                If bmsgOK = True Then
                    messageControl.Alert("A mensagem de solicitação de aprovação para Modelo de Contrato de Produtor foi enviada aos destinatários com sucesso!")
                Else
                    messageControl.Alert("A mensagem de solicitação de aprovação para Modelo de Contrato de Produtor não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        End If

    End Sub
End Class
