Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class lst_contrato
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia") = String.Concat("01/", DateTime.Parse(txt_dt_referencia.Text).ToString("MM/yyyy"))
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If
        ViewState.Item("cd_contrato") = txt_cd_contrato.Text
        ViewState.Item("nm_contrato") = txt_nm_contrato.Text
        ViewState.Item("id_situacao_contrato") = cbo_situacao_contrato.SelectedValue
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        ViewState.Item("id_cluster") = cbo_cluster.SelectedValue 'fran 04/2022 i

        If chk_contrato_comercial.Checked = True Then
            ViewState.Item("st_contrato_comercial") = "S"
        Else
            ViewState.Item("st_contrato_comercial") = String.Empty
        End If
        If chk_contrato_mercado.Checked = True Then
            ViewState.Item("st_contrato_mercado") = "S"
        Else
            ViewState.Item("st_contrato_mercado") = String.Empty
        End If
        If chk_referenciavigente.Checked = True Then
            ViewState.Item("st_referencia_vigente") = "S"
        Else
            ViewState.Item("st_referencia_vigente") = String.Empty
        End If
        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_contrato.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_contrato.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 178
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim statusContrato As New SituacaoContrato
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
            cbo_cluster.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao_contrato.DataSource = statusContrato.getSituacoesContratoByFilters()
            cbo_situacao_contrato.DataTextField = "nm_situacao_contrato"
            cbo_situacao_contrato.DataValueField = "id_situacao_contrato"
            cbo_situacao_contrato.DataBind()
            cbo_situacao_contrato.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            If cbo_situacao.Items.Count > 1 Then
                cbo_situacao.SelectedValue = 1 'assume que traz parametros ativos
            End If

            ViewState.Item("sortExpression") = String.Empty

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("contrato", cbo_estabelecimento.ID).Equals(String.Empty)) AndAlso Not (customPage.getFilterValue("contrato", cbo_estabelecimento.ID).Equals("0")) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("contrato", cbo_estabelecimento.ID)
            cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = 0
        End If

        If Not (customPage.getFilterValue("contrato", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("contrato", txt_dt_referencia.ID)
            txt_dt_referencia.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        If Not (customPage.getFilterValue("contrato", txt_cd_contrato.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_contrato") = customPage.getFilterValue("contrato", txt_cd_contrato.ID)
            txt_cd_contrato.Text = ViewState.Item("cd_contrato").ToString()
        Else
            ViewState.Item("cd_contrato") = String.Empty
        End If
        If Not (customPage.getFilterValue("contrato", txt_nm_contrato.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_contrato") = customPage.getFilterValue("contrato", txt_nm_contrato.ID)
            txt_nm_contrato.Text = ViewState.Item("nm_contrato").ToString()
        Else
            ViewState.Item("nm_contrato") = String.Empty
        End If

        If Not (customPage.getFilterValue("contrato", cbo_situacao_contrato.ID).Equals(String.Empty)) AndAlso Not (customPage.getFilterValue("contrato", cbo_situacao_contrato.ID).Equals("0")) Then
            hasFilters = True
            ViewState.Item("id_situacao_contrato") = customPage.getFilterValue("contrato", cbo_situacao_contrato.ID)
            cbo_situacao_contrato.SelectedValue = ViewState.Item("id_situacao_contrato").ToString()
        Else
            ViewState.Item("id_situacao_contrato") = "0"
        End If

        If Not (customPage.getFilterValue("contrato", cbo_cluster.ID).Equals(String.Empty)) Then
            If Not (customPage.getFilterValue("contrato", cbo_cluster.ID).Equals("0")) Then
                ViewState.Item("id_cluster") = customPage.getFilterValue("contrato", cbo_cluster.ID)
                cbo_cluster.SelectedValue = ViewState.Item("id_cluster").ToString()
            Else
                ViewState.Item("id_cluster") = "0"
                cbo_cluster.SelectedValue = "0"
            End If
        Else
            ViewState.Item("id_cluster") = "0"
            cbo_cluster.SelectedValue = "0"
        End If


        If Not (customPage.getFilterValue("contrato", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            If Not (customPage.getFilterValue("contrato", cbo_situacao.ID).Equals("0")) Or Not (customPage.getFilterValue("contrato", cbo_situacao.ID).Equals("")) Then
                ViewState.Item("id_situacao") = customPage.getFilterValue("contrato", cbo_situacao.ID)
                cbo_situacao.SelectedValue = ViewState.Item("id_situacao").ToString()
            Else
                ViewState.Item("id_situacao") = String.Empty
            End If
        Else
            ViewState.Item("id_situacao") = 1
        End If
        If (customPage.getFilterValue("contrato", chk_contrato_comercial.ID) = "S") Then
            hasFilters = True
            ViewState.Item("st_contrato_comercial") = "S"
            chk_contrato_comercial.Checked = True
        Else
            ViewState.Item("st_contrato_comercial") = String.Empty
            chk_contrato_comercial.Checked = False
        End If
        If (customPage.getFilterValue("contrato", chk_contrato_mercado.ID) = "S") Then
            hasFilters = True
            ViewState.Item("st_contrato_mercado") = "S"
            chk_contrato_mercado.Checked = True
        Else
            ViewState.Item("st_contrato_mercado") = String.Empty
            chk_contrato_mercado.Checked = False
        End If
        If (customPage.getFilterValue("contrato", chk_referenciavigente.ID) = "S") Then
            hasFilters = True
            ViewState.Item("st_referencia_vigente") = "S"
            chk_referenciavigente.Checked = True
        Else
            ViewState.Item("st_referencia_vigente") = String.Empty
            chk_referenciavigente.Checked = False
        End If

        If Not (customPage.getFilterValue("contrato", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("contrato", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("contrato")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim contrato As New Contrato

            contrato.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

            If Not (ViewState("dt_referencia").ToString().Equals(String.Empty)) Then
                contrato.dt_referencia_inicio = DateTime.Parse(ViewState("dt_referencia").ToString).ToString("dd/MM/yyyy")
            End If
            contrato.cd_contrato = txt_cd_contrato.Text
            contrato.nm_contrato = txt_nm_contrato.Text
            contrato.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            If contrato.id_situacao = 1 Then 'se for contratos ativos
                contrato.id_situacao_contrato_validade = 1 'ativos
            Else
                contrato.id_situacao_contrato_validade = 0 'se contrato inativo, traz todas as validades que automaticamente estão inativas tb
            End If
            contrato.id_situacao_contrato = Convert.ToInt32(ViewState.Item("id_situacao_contrato").ToString())
            contrato.st_contrato_comercial = ViewState.Item("st_contrato_comercial").ToString
            contrato.st_contrato_mercado = ViewState.Item("st_contrato_mercado").ToString
            contrato.st_referencia_vigente = ViewState.Item("st_referencia_vigente").ToString
            contrato.id_cluster = Convert.ToInt32(ViewState.Item("id_cluster").ToString()) 'fran 04/2022

            Dim dscontrato As DataSet = contrato.getContratoSuasValidades()

            If (dscontrato.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscontrato.Tables(0), ViewState.Item("sortExpression"))
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


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "ds_validade"
                If ViewState.Item("sortExpression") = "ds_validade asc" Then
                    ViewState.Item("sortExpression") = "ds_validade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_validade asc"
                End If

            Case "cd_contrato"
                If ViewState.Item("sortExpression") = "cd_contrato asc" Then
                    ViewState.Item("sortExpression") = "cd_contrato desc"
                Else
                    ViewState.Item("sortExpression") = "cd_contrato asc"
                End If

            Case "nm_contrato"
                If ViewState.Item("sortExpression") = "nm_contrato asc" Then
                    ViewState.Item("sortExpression") = "nm_contrato desc"
                Else
                    ViewState.Item("sortExpression") = "nm_contrato asc"
                End If
            Case "st_contrato_comercial"
                If ViewState.Item("sortExpression") = "st_contrato_comercial asc" Then
                    ViewState.Item("sortExpression") = "st_contrato_comercial desc"
                Else
                    ViewState.Item("sortExpression") = "st_contrato_comercial asc"
                End If
            Case "st_contrato_mercado"
                If ViewState.Item("sortExpression") = "st_contrato_mercado asc" Then
                    ViewState.Item("sortExpression") = "st_contrato_mercado desc"
                Else
                    ViewState.Item("sortExpression") = "st_contrato_mercado asc"
                End If
            Case "st_referencia_vigente"
                If ViewState.Item("sortExpression") = "st_referencia_vigente asc" Then
                    ViewState.Item("sortExpression") = "st_referencia_vigente desc"
                Else
                    ViewState.Item("sortExpression") = "st_referencia_vigente asc"
                End If
            Case "nm_situacao_contrato_validade"
                If ViewState.Item("sortExpression") = "nm_situacao_contrato_validade asc" Then
                    ViewState.Item("sortExpression") = "nm_situacao_contrato_validade desc"
                Else
                    ViewState.Item("sortExpression") = "nm_situacao_contrato_validade asc"
                End If
            Case "nm_situacao_contrato"
                If ViewState.Item("sortExpression") = "nm_situacao_contrato asc" Then
                    ViewState.Item("sortExpression") = "nm_situacao_contrato desc"
                Else
                    ViewState.Item("sortExpression") = "nm_situacao_contrato asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("contrato", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("contrato", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("contrato", txt_cd_contrato.ID, ViewState.Item("cd_contrato").ToString)
            customPage.setFilter("contrato", txt_nm_contrato.ID, ViewState.Item("nm_contrato").ToString)
            customPage.setFilter("contrato", cbo_situacao_contrato.ID, ViewState.Item("id_situacao_contrato").ToString)
            customPage.setFilter("contrato", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("contrato", cbo_cluster.ID, ViewState.Item("id_cluster").ToString)
            customPage.setFilter("contrato", chk_contrato_comercial.ID, ViewState.Item("st_contrato_comercial").ToString)
            customPage.setFilter("contrato", chk_contrato_mercado.ID, ViewState.Item("st_contrato_mercado").ToString)
            customPage.setFilter("contrato", chk_referenciavigente.ID, ViewState.Item("st_referencia_vigente").ToString)
            customPage.setFilter("contrato", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


        Select Case e.CommandName.ToString().ToLower()
 
            Case "edit"
                Dim lbl_id_contrato As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_contrato"), Label)
                Dim lbl_id_contrato_validade As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_contrato_validade"), Label)

                saveFilters()
                Response.Redirect("frm_contrato.aspx?id_contrato_validade=" & lbl_id_contrato_validade.Text & "&id_contrato=" & lbl_id_contrato.Text)

            Case "delete"

                Dim lbl_id_contrato As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_contrato"), Label)
                Dim lbl_id_contrato_validade As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_contrato_validade"), Label)

                deleteContrato(Convert.ToInt32(lbl_id_contrato.Text), Convert.ToInt32(lbl_id_contrato_validade.Text))

        End Select

    End Sub

    Private Sub deleteContrato(ByVal id_contrato As Integer, ByVal id_contrato_validade As Integer)

        Try
            Dim lmsg As String
            Dim contratovalidade As New ContratoValidade()
            contratovalidade.id_contrato_validade = id_contrato_validade
            contratovalidade.id_modificador = Convert.ToInt32(Session("id_login"))
            contratovalidade.deleteContratoValidade()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'delecao
            usuariolog.id_menu_item = 178
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            lmsg = "Registro de validade do Contrato foi desativado com sucesso!"

            'busca todos os contratos validade ativos existentes para o contrato. Se não retornou nenhuma linha desativada contrato também
            contratovalidade.id_contrato_validade = 0
            contratovalidade.id_contrato = id_contrato
            contratovalidade.id_situacao = 1 'ativo
            If contratovalidade.getContratoValidadeByFilters.Tables(0).Rows.Count = 0 Then
                Dim contrato As New Contrato
                contrato.id_contrato = id_contrato
                contrato.id_modificador = Convert.ToInt32(Session("id_login"))
                contrato.deleteContrato()
                lmsg = "Todas as informações relacionadas ao contrato foram desativadas com sucesso!"
            End If


            messageControl.Alert(lmsg)
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_contrato.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
            Dim lbl_id_situacao_contrato As Label = CType(e.Row.FindControl("lbl_id_situacao_contrato"), Label)

            If lbl_id_situacao_contrato.Text.ToString.Equals("5") OrElse lbl_id_situacao_contrato.Text.ToString.Equals("6") Then 'se for aprovado 2o nivel nao pode destaivar
                btn_delete.Enabled = False
                btn_delete.ImageUrl = "~/img/icone_excluir_desabilitado.gif"
                btn_delete.ToolTip = "Não é possível excluir o registro. O contrato já foi aprovado/reprovado em 2o Nível."
            Else
                btn_delete.Enabled = True
                btn_delete.ImageUrl = "~/img/icone_excluir.gif"
                btn_delete.ToolTip = String.Empty
            End If

        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
                Dim btn_editar As Anthem.ImageButton = CType(e.Row.FindControl("img_editar"), Anthem.ImageButton)

                btn_delete.CommandArgument = e.Row.RowIndex.ToString
                btn_editar.CommandArgument = e.Row.RowIndex.ToString

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        If Page.IsValid = True Then
            Try

                Dim notificacao As New Notificacao
                Dim lAssunto As String = "Aprovação 1.o Nível para Contratos "
                Dim lCorpo As String = "Existem contrato(s) pendente(s) para aprovação 1.o Nível."

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 9 'ENVIO EMAIL
                usuariolog.id_menu_item = 178
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f

                ' Parametro 17 - Adiantamento 1.o Nível
                If notificacao.enviaMensagemEmail(17, lAssunto, lCorpo, MailPriority.High) = True Then

                    messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível foi enviada aos destinatários com sucesso!")
                Else

                    messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        End If

    End Sub
End Class
