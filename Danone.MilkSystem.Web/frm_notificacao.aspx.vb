Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_notificacao
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_notificacao.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        Else
            'If ViewState.Item("id_tipo_notificacao") Is Nothing Then
            'fran 01/07/2010 - a qualquer evento, se no houver linhas deve posicionar grid
            If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then

                grdEmailPara.Rows(0).Cells.Clear()
                grdEmailPara.Rows(0).Cells.Add(New TableCell())
                grdEmailPara.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdEmailPara.Rows(0).Cells(0).Text = "Não existe nenhum Email de Destino cadastrado!"
                grdEmailPara.Rows(0).Cells(0).ColumnSpan = 2
            End If
            If ViewState.Item("gridLinhasAdicionadasCC") Is Nothing Then

                grdEmailCopia.Rows(0).Cells.Clear()
                grdEmailCopia.Rows(0).Cells.Add(New TableCell())
                grdEmailCopia.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdEmailCopia.Rows(0).Cells(0).Text = "Não existe nenhum Email com Cópia cadastrado!"
                grdEmailCopia.Rows(0).Cells(0).ColumnSpan = 2
            End If
            'End If
        End If
    End Sub

    Private Sub loadDetails()

        Try
            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True

            Dim notificacao As New TipoNotificacao

            cbo_notificacao.DataSource = notificacao.getTiposNotificacaoByFilters()
            cbo_notificacao.DataTextField = "nm_tipo_notificacao"
            cbo_notificacao.DataValueField = "id_tipo_notificacao"
            cbo_notificacao.DataBind()
            cbo_notificacao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            'Fran 24/11/2009 i chamado 518 - Maracanau
            Dim estabel As New Estabelecimento
            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'Fran 24/11/2009 f

            If Not (Request("id_tipo_notificacao") Is Nothing) Then
                ViewState.Item("id_tipo_notificacao") = Request("id_tipo_notificacao")
                'Fran 24/11/2009 i chamado 518 - Maracanau
                If Not (Request("id_estabelecimento") Is Nothing) Then
                    ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")
                    If ViewState.Item("id_estabelecimento").ToString.Equals(String.Empty) Then
                        ViewState.Item("id_estabelecimento") = 0
                    End If
                Else
                    ViewState.Item("id_estabelecimento") = 0
                End If
                'Fran 24/11/2009 f chamado 518 - Maracanau
                loadData()
            Else

                Dim dsgrid As New DataTable
                dsgrid.Rows.InsertAt(dsgrid.NewRow(), 0)

                grdEmailPara.Visible = True
                grdEmailPara.DataSource = Helper.getDataView(dsgrid, ViewState.Item("sortExpression"))
                grdEmailPara.DataBind()
                grdEmailPara.Rows(0).Cells.Clear()
                grdEmailPara.Rows(0).Cells.Add(New TableCell())
                grdEmailPara.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdEmailPara.Rows(0).Cells(0).Text = "Não existe nenhum Email de destino cadastrado!"
                grdEmailPara.Rows(0).Cells(0).ColumnSpan = 2

                Dim dsgrid2 As New DataTable
                dsgrid2.Rows.InsertAt(dsgrid2.NewRow(), 0)

                grdEmailCopia.Visible = True
                grdEmailCopia.DataSource = Helper.getDataView(dsgrid2, ViewState.Item("sortExpression"))
                grdEmailCopia.DataBind()
                grdEmailCopia.Rows(0).Cells.Clear()
                grdEmailCopia.Rows(0).Cells.Add(New TableCell())
                grdEmailCopia.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdEmailCopia.Rows(0).Cells(0).Text = "Não existe nenhum Email com Cópia cadastrado!"
                grdEmailCopia.Rows(0).Cells(0).ColumnSpan = 5
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try

            Dim id_tipo_notificacao As Int32 = Convert.ToInt32(ViewState.Item("id_tipo_notificacao").ToString)

            Dim notificacao As New Notificacao()

            cbo_notificacao.SelectedValue = id_tipo_notificacao.ToString
            cbo_notificacao.Enabled = False
            notificacao.id_tipo_notificacao = id_tipo_notificacao
            notificacao.st_para_copia = "P"
            'Fran 24/11/2009 i chamado 518 - Maracanau
            notificacao.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            'Fran 24/11/2009 f chamado 518 - Maracanau

            Dim ds_notificacao As DataSet = notificacao.getNotificacoesByFilters()

            If (ds_notificacao.Tables(0).Rows.Count > 0) Then
                'Fran 24/11/2009 i chamado 518 - Maracanau
                If Not IsDBNull(ds_notificacao.Tables(0).Rows(0).Item("id_estabelecimento")) Then
                    cbo_estabelecimento.SelectedValue = ds_notificacao.Tables(0).Rows(0).Item("id_estabelecimento")
                    cbo_estabelecimento.Enabled = False
                Else
                    cbo_estabelecimento.SelectedValue = String.Empty
                    cbo_estabelecimento.Enabled = True
                End If
                'Fran 24/11/2009 f
                cbo_situacao.SelectedValue = ds_notificacao.Tables(0).Rows(0).Item("id_situacao")
                txt_ds_email_remetente.Text = ds_notificacao.Tables(0).Rows(0).Item("ds_email_remetente")
                notificacao.ds_email_remetente = txt_ds_email_remetente.Text.ToString
                notificacao.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                ViewState.Item("situacao") = notificacao.id_situacao
                ViewState.Item("gridLinhasAdicionadas") = "S"

                ViewState.Item("gridtable") = ds_notificacao.Tables(0)
                ViewState.Item("incluirlinha") = "S"
                grdEmailPara.Visible = True
                grdEmailPara.DataSource = Helper.getDataView(ds_notificacao.Tables(0), "ds_email asc")
                grdEmailPara.DataBind()
                ViewState.Item("incluirlinha") = "N"
            Else
                grdEmailPara.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Há problemas na passagem de parametros.")
            End If

            notificacao.st_para_copia = "C"

            Dim ds_notificacaoCC As DataSet = notificacao.getNotificacoesByFilters()

            If (ds_notificacaoCC.Tables(0).Rows.Count > 0) Then
                ViewState.Item("gridLinhasAdicionadasCC") = "S"
                grdEmailCopia.Visible = True
                ViewState.Item("gridtablecc") = ds_notificacaoCC.Tables(0)
                ViewState.Item("incluirlinhacc") = "S"
                grdEmailCopia.DataSource = Helper.getDataView(ds_notificacaoCC.Tables(0), "ds_email asc")
                grdEmailCopia.DataBind()
                ViewState.Item("incluirlinhacc") = "N"
            Else
                Dim dsgrid2 As New DataTable
                dsgrid2.Rows.InsertAt(dsgrid2.NewRow(), 0)

                grdEmailCopia.Visible = True
                grdEmailCopia.DataSource = Helper.getDataView(dsgrid2, ViewState.Item("sortExpression"))
                grdEmailCopia.DataBind()
                grdEmailCopia.Rows(0).Cells.Clear()
                grdEmailCopia.Rows(0).Cells.Add(New TableCell())
                grdEmailCopia.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdEmailCopia.Rows(0).Cells(0).Text = "Não existe nenhum Email com Cópia cadastrado!"
                grdEmailCopia.Rows(0).Cells(0).ColumnSpan = 2
            End If

            If notificacao.id_situacao = 2 Then
                btn_novo_email_copia.Visible = False
                txt_ds_email_remetente.Enabled = False
                cv_grid.Visible = False
                btn_novo_email_para.Visible = False
                grdEmailPara.Columns.Item(1).Visible = False
                grdEmailCopia.Columns.Item(1).Visible = False
            Else
                btn_novo_email_copia.Visible = True
                cv_grid.Visible = True
                btn_novo_email_para.Visible = True
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub updateData()
        If Page.IsValid Then
            Try
                Dim notificacao As New Notificacao()
                Dim row As GridViewRow
                Dim linha As Integer

                notificacao.id_tipo_notificacao = Convert.ToInt32(cbo_notificacao.SelectedValue)
                notificacao.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                notificacao.id_modificador = Session("id_login")
                notificacao.ds_email_remetente = txt_ds_email_remetente.Text.ToString
                'Fran 24/11/2009 i Maracanau chamado 518
                If Not cbo_estabelecimento.SelectedValue.Equals(String.Empty) Then
                    notificacao.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                End If
                'Fran 24/11/2009 f

                If notificacao.id_situacao = 2 Then
                    'desativa todas as notificações para o tipo de notificação X
                    notificacao.deleteNotificacoes()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 5 'delecao
                    usuariolog.id_menu_item = 14
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango
                Else
                    notificacao.email_para_insert = New ArrayList
                    notificacao.email_para_update = New ArrayList
                    notificacao.id_para_update = New ArrayList
                    notificacao.id_para_delete = New ArrayList

                    For Each row In grdEmailPara.Rows
                        Dim txt_id_notificacao As DataControlFieldCell = CType(grdEmailPara.Rows(linha).Cells(2), DataControlFieldCell)
                        If row.Visible = True Then
                            Dim txt_ds_email As Anthem.TextBox = CType(row.FindControl("txt_ds_email"), Anthem.TextBox)
                            'Se não tem id 
                            If txt_id_notificacao.Text.Trim.Equals(String.Empty) Then
                                'Guarda para Inserir
                                notificacao.email_para_insert.Add(txt_ds_email.Text)
                            Else
                                'Se tem id
                                'Guarda email e id para atualizar
                                notificacao.email_para_update.Add(txt_ds_email.Text)
                                notificacao.id_para_update.Add(Convert.ToInt32(txt_id_notificacao.Text))
                            End If
                        Else 'Se não está visivel
                            'se tem id
                            If Not txt_id_notificacao.Text.Trim.Equals(String.Empty) Then
                                'guarda para deletar
                                notificacao.id_para_delete.Add(Convert.ToInt32(txt_id_notificacao.Text))
                            End If
                        End If

                        linha = linha + 1

                    Next
                    linha = 0
                    notificacao.email_copia_insert = New ArrayList
                    notificacao.email_copia_update = New ArrayList
                    notificacao.id_copia_update = New ArrayList
                    notificacao.id_copia_delete = New ArrayList

                    If grdEmailCopia.Rows(0).Cells.Count > 1 Then
                        For Each row In grdEmailCopia.Rows
                            Dim txt_id_notificacao As DataControlFieldCell = CType(grdEmailCopia.Rows(linha).Cells(2), DataControlFieldCell)
                            If row.Visible = True Then
                                Dim txt_ds_email As Anthem.TextBox = CType(row.FindControl("txt_ds_email"), Anthem.TextBox)
                                'Se não tem id 
                                If txt_id_notificacao.Text.Trim.Equals(String.Empty) Then
                                    'Guarda para Inserir
                                    notificacao.email_copia_insert.Add(txt_ds_email.Text)
                                Else
                                    'Se tem id
                                    'Guarda email e id para atualizar
                                    notificacao.email_copia_update.Add(txt_ds_email.Text)
                                    notificacao.id_copia_update.Add(Convert.ToInt32(txt_id_notificacao.Text))
                                End If
                            Else 'Se não está visivel
                                'se tem id
                                If Not txt_id_notificacao.Text.Trim.Equals(String.Empty) Then
                                    'guarda para deletar
                                    notificacao.id_copia_delete.Add(Convert.ToInt32(txt_id_notificacao.Text))
                                End If
                            End If

                            linha = linha + 1

                        Next
                    End If
                    notificacao.atualizarNotificacao()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'altercao
                    usuariolog.id_menu_item = 14
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango
                End If
                    messageControl.Alert("Registro atualizado com sucesso!")
                ViewState.Item("id_tipo_notificacao") = notificacao.id_tipo_notificacao
                ViewState.Item("id_estabelecimento") = notificacao.id_estabelecimento
                    loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_notificacao.aspx")



    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_notificacao.aspx")

    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub



    Protected Sub btn_novo_email_para_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_email_para.Click
        Dim dstable As New DataTable
        Dim ilinha As Integer
        If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
            Dim emailpara As New Notificacao
            Dim ds As New DataSet
            emailpara.id_notificacao = 0
            ds = emailpara.getNotificacoesByFilters
            ViewState.Item("gridLinhasAdicionadas") = "S"
            ilinha = 0
        Else
            ViewState.Item("incluirlinha") = "S"
            'dstable.Rows.InsertAt(dstable.NewRow(), dstable.Rows.Count + 1)
            dstable.Columns.Add("ds_email")
            dstable.Columns.Add("id_notificacao")

            Dim row As GridViewRow
            ilinha = 0
            For Each row In grdEmailPara.Rows
                If row.Visible = True Then
                    Dim txt_ds_email As Anthem.TextBox = CType(row.FindControl("txt_ds_email"), Anthem.TextBox)
                    Dim txt_id_notificacao As DataControlFieldCell = CType(row.Cells(2), DataControlFieldCell)

                    dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
                    With dstable.Rows.Item(ilinha)
                        .Item("ds_email") = txt_ds_email.Text
                        .Item("id_notificacao") = txt_id_notificacao.Text
                    End With
                    ilinha = ilinha + 1
                End If
            Next
            ViewState.Item("gridtable") = dstable

        End If

        dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
        grdEmailPara.Visible = True
        grdEmailPara.DataSource = Helper.getDataView(dstable, ViewState.Item("sortExpression"))
        grdEmailPara.DataBind()

        ViewState.Item("incluirlinha") = "N"


    End Sub

    Protected Sub grdEmailPara_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdEmailPara.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "delete"
                deleteEmailPara(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteEmailPara(ByVal id_index_row As Integer)

        Try

            grdEmailPara.Rows(id_index_row).Visible = False

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub grdEmailPara_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEmailPara.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btnexcluir As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)
                btnexcluir.CommandArgument = e.Row.RowIndex.ToString
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If


    End Sub


    Protected Sub grdEmailPara_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEmailPara.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) And ViewState.Item("incluirlinha") = "S" Then
            Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
            If Not (dr Is Nothing) Then
                Dim txt_ds_email As Anthem.TextBox = CType(e.Row.FindControl("txt_ds_email"), Anthem.TextBox)
                Dim txt_id_notificacao As DataControlFieldCell = CType(e.Row.Cells(2), DataControlFieldCell)
                If ViewState.Item("situacao") = "2" Then
                    txt_ds_email.Enabled = False
                Else
                    txt_ds_email.Enabled = True
                End If

                txt_ds_email.Text = dr.Item("ds_email").ToString
                txt_id_notificacao.Text = dr.Item("id_notificacao").ToString

            End If


        End If
    End Sub




    Protected Sub cv_grid_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_grid.ServerValidate
        Try
            args.IsValid = True
            If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
                args.IsValid = False
            Else
                Dim row As GridViewRow
                args.IsValid = False
                For Each row In grdEmailPara.Rows
                    If row.Visible = True Then
                        args.IsValid = True
                        Exit For
                    End If
                Next
                'ViewState.Item("gridLinhasAdicionadas")
            End If

            If args.IsValid = False Then
                messageControl.Alert("Um Email de Destino deve ser informado para continuar.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdEmailPara_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdEmailPara.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub btn_novo_email_copia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_email_copia.Click
        Dim dstable As New DataTable
        Dim ilinha As Integer
        If ViewState.Item("gridLinhasAdicionadasCC") Is Nothing Then
            Dim emailcopia As New Notificacao
            Dim ds As New DataSet
            emailcopia.id_notificacao = 0
            ds = emailcopia.getNotificacoesByFilters
            ViewState.Item("gridLinhasAdicionadasCC") = "S"
            ilinha = 0
        Else
            ViewState.Item("incluirlinhacc") = "S"
            'dstable.Rows.InsertAt(dstable.NewRow(), dstable.Rows.Count + 1)
            dstable.Columns.Add("ds_email")
            dstable.Columns.Add("id_notificacao")

            Dim row As GridViewRow
            ilinha = 0
            For Each row In grdEmailCopia.Rows
                If row.Visible = True Then
                    Dim txt_ds_email As Anthem.TextBox = CType(row.FindControl("txt_ds_email"), Anthem.TextBox)
                    Dim txt_id_notificacao As DataControlFieldCell = CType(row.Cells(2), DataControlFieldCell)

                    dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
                    With dstable.Rows.Item(ilinha)
                        .Item("ds_email") = txt_ds_email.Text
                        .Item("id_notificacao") = txt_id_notificacao.Text
                    End With
                    ilinha = ilinha + 1
                End If
            Next

            ViewState.Item("gridtablecc") = dstable

        End If

        dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
        grdEmailCopia.Visible = True
        grdEmailCopia.DataSource = Helper.getDataView(dstable, ViewState.Item("sortExpression"))
        grdEmailCopia.DataBind()

        ViewState.Item("incluirlinhacc") = "N"

    End Sub

    Protected Sub grdEmailCopia_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdEmailCopia.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "delete"
                deleteEmailCopia(Convert.ToInt32(e.CommandArgument.ToString()))
        End Select
    End Sub
    Private Sub deleteEmailCopia(ByVal id_index_row As Integer)

        Try

            grdEmailCopia.Rows(id_index_row).Visible = False
            'loadGridEscolaridade()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdEmailCopia_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEmailCopia.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btnexcluir As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)
                btnexcluir.CommandArgument = e.Row.RowIndex.ToString
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub grdEmailCopia_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEmailCopia.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) And ViewState.Item("incluirlinhacc") = "S" Then
            Dim dr As DataRow = CType(ViewState.Item("gridtablecc"), DataTable).Rows.Item(e.Row.RowIndex)
            If Not (dr Is Nothing) Then
                Dim txt_ds_email As Anthem.TextBox = CType(e.Row.FindControl("txt_ds_email"), Anthem.TextBox)
                Dim txt_id_notificacao As DataControlFieldCell = CType(e.Row.Cells(2), DataControlFieldCell)
                If ViewState.Item("situacao") = "2" Then
                    txt_ds_email.Enabled = False
                Else
                    txt_ds_email.Enabled = True
                End If

                txt_ds_email.Text = dr.Item("ds_email").ToString
                txt_id_notificacao.Text = dr.Item("id_notificacao").ToString

            End If


        End If

    End Sub

    Protected Sub grdEmailCopia_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdEmailCopia.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'Fran 02/03/2009 i rls17
        Response.Redirect("frm_notificacao.aspx")
    End Sub

    Protected Sub cbo_notificacao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_notificacao.SelectedIndexChanged
        If Not cbo_notificacao.SelectedValue.ToString.Equals(String.Empty) Then
            Select Case CInt(cbo_notificacao.SelectedValue)
                Case 1, 2, 3, 4, 8
                    rfv_estabelecimento.Visible = True
                Case 5, 6
                    rfv_estabelecimento.Visible = False
            End Select
        End If
    End Sub
End Class
