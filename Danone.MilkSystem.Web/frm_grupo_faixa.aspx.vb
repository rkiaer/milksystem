Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_grupo_faixa
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_grupo_faixa.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        Else
            If ViewState.Item("nr_grupo_faixas") Is Nothing Then
                If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then

                    grdFaixas.Rows(0).Cells.Clear()
                    grdFaixas.Rows(0).Cells.Add(New TableCell())
                    grdFaixas.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    grdFaixas.Rows(0).Cells(0).Text = "Não existe nenhuma Faixa de Volume cadastrada!"
                    grdFaixas.Rows(0).Cells(0).ColumnSpan = 5
                End If
            End If
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

            If Not (Request("nr_grupo_faixas") Is Nothing) Then
                ViewState.Item("nr_grupo_faixas") = Request("nr_grupo_faixas")
                loadData()
            Else

                Dim dsgrid As New DataTable
                dsgrid.Rows.InsertAt(dsgrid.NewRow(), 0)

                grdFaixas.Visible = True
                grdFaixas.DataSource = Helper.getDataView(dsgrid, ViewState.Item("sortExpression"))
                grdFaixas.DataBind()
                grdFaixas.Rows(0).Cells.Clear()
                grdFaixas.Rows(0).Cells.Add(New TableCell())
                grdFaixas.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdFaixas.Rows(0).Cells(0).Text = "Não existe nenhuma Faixa cadastrada!"
                grdFaixas.Rows(0).Cells(0).ColumnSpan = 5
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try

            Dim id_grupo As Int32 = Convert.ToInt32(ViewState.Item("nr_grupo_faixas").ToString)
            Dim grupofaixa As New FaixaVolume()

            grupofaixa.nr_grupo_faixas = id_grupo

            Dim ds_faixa As DataSet = grupofaixa.getFaixaVolumeByFilters()

            If (ds_faixa.Tables(0).Rows.Count > 0) Then
                txt_nm_grupo.Text = ds_faixa.Tables(0).Rows(0).Item("nm_grupo_faixas").ToString
                txt_nm_grupo.Enabled = False
                lbl_label_nm_grupo.Visible = True
                lbl_nr_grupo.Text = id_grupo

                grdFaixas.Visible = False
                cv_grid.Visible = False
                cv_validar_faixas_grid.Visible = False
                btn_nova_faixa.Visible = False

                grdfaixaconsulta.Visible = True
                grdfaixaconsulta.DataSource = Helper.getDataView(ds_faixa.Tables(0), "nr_faixa_inicio asc")
                grdfaixaconsulta.DataBind()
            Else
                grdfaixaconsulta.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Há problemas na passagem de parametros.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub updateData()
        Try
            If Not ViewState.Item("nr_grupo_faixas") Is Nothing Then

                Dim faixa As New FaixaVolume()

                faixa.nr_grupo_faixas = Convert.ToInt32(ViewState.Item("nr_grupo_faixas"))
                faixa.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                faixa.id_modificador = Session("id_login")

                faixa.updateFaixaVolume()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteracao
                usuariolog.id_menu_item = 29
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Registro atualizado com sucesso!")
                loadData()
            Else
                If Page.IsValid Then

                    Dim faixa As New FaixaVolume()
                    Dim row As GridViewRow

                    faixa.nm_grupo_faixas = txt_nm_grupo.Text.ToString
                    faixa.id_modificador = Session("id_login")
                    faixa.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                    faixa.fxs_nm_faixa = New ArrayList
                    faixa.fxs_nr_inicio = New ArrayList
                    faixa.fxs_nr_fim = New ArrayList

                    For Each row In grdFaixas.Rows
                        If row.Visible = True Then
                            Dim txt_nm_faixa As Anthem.TextBox = CType(row.FindControl("txt_nm_faixa"), Anthem.TextBox)
                            Dim txt_nr_faixa_inicio As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_inicio"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                            Dim txt_nr_faixa_fim As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_fim"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                            faixa.fxs_nm_faixa.Add(txt_nm_faixa.Text.ToString)
                            If Not (txt_nr_faixa_inicio.Text.ToString.Equals(String.Empty)) Then
                                faixa.fxs_nr_inicio.Add(CDec(txt_nr_faixa_inicio.Text))
                            Else
                                faixa.fxs_nr_inicio.Add(CDec(0))
                            End If
                            If Not (txt_nr_faixa_fim.Text.ToString.Equals(String.Empty)) Then
                                faixa.fxs_nr_fim.Add(CDec(txt_nr_faixa_fim.Text))
                            Else
                                faixa.fxs_nr_fim.Add(CDec(0))
                            End If

                        End If
                    Next

                    ViewState.Item("nr_grupo_faixas") = faixa.insertGrupoFaixasVolume()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 29
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("O Grupo de Faixas foi criado com sucesso!")

                    loadData()
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_grupo_faixa.aspx")



    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_grupo_faixa.aspx")

    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

 

    Protected Sub btn_nova_faixa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nova_faixa.Click

        Dim dstable As New DataTable
        Dim ilinha As Integer
        If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
            Dim faixa As New FaixaVolume
            Dim ds As New DataSet
            faixa.id_faixa_volume = 0
            ds = faixa.getFaixaVolumeByFilters
            ViewState.Item("gridLinhasAdicionadas") = "S"
            ilinha = 0
        Else
            ViewState.Item("incluirlinha") = "S"
            'dstable.Rows.InsertAt(dstable.NewRow(), dstable.Rows.Count + 1)
            dstable.Columns.Add("nm_faixa_volume")
            dstable.Columns.Add("nr_faixa_inicio")
            dstable.Columns.Add("nr_faixa_fim")
            dstable.Columns.Add("id_faixa_volume")

            Dim row As GridViewRow
            ilinha = 0
            For Each row In grdFaixas.Rows
                If row.Visible = True Then
                    Dim txt_nm_faixa As Anthem.TextBox = CType(row.FindControl("txt_nm_faixa"), Anthem.TextBox)
                    Dim txt_nr_faixa_inicio As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_inicio"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_nr_faixa_fim As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_fim"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                    dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
                    With dstable.Rows.Item(ilinha)
                        .Item(0) = txt_nm_faixa.Text
                        .Item(1) = txt_nr_faixa_inicio.Text
                        .Item(2) = txt_nr_faixa_fim.Text
                    End With
                    ilinha = ilinha + 1
                End If
            Next

            ViewState.Item("gridtable") = dstable

        End If

        dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
        grdFaixas.Visible = True
        grdFaixas.DataSource = Helper.getDataView(dstable, ViewState.Item("sortExpression"))

        grdFaixas.DataBind()

        ViewState.Item("incluirlinha") = "N"

    End Sub

    Protected Sub grdFaixas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdFaixas.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "delete"
                deleteFaixas(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub
    Private Sub deleteFaixas(ByVal id_index_row As Integer)

        Try

            grdFaixas.Rows(id_index_row).Visible = False
            'loadGridEscolaridade()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridFaixas_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdFaixas.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btnexcluir As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)
                btnexcluir.CommandArgument = e.Row.RowIndex.ToString
                If ViewState.Item("incluirlinha") = "S" Then
                    Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
                    'If Not (dr Is Nothing) Then
                    '    If Not (dr.Item(0).ToString.Equals(String.Empty)) Then
                    '        Dim cbo_compartimento As Anthem.DropDownList = CType(e.Row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                    '        cbo_compartimento.Enabled = True
                    '        Dim compartimento As New Compartimento
                    '        compartimento.ds_placa = dr.Item(0).ToString
                    '        cbo_compartimento.DataSource = compartimento.getCompartimentoByFilters()
                    '        cbo_compartimento.DataTextField = "ds_compartimento"
                    '        cbo_compartimento.DataValueField = "ds_id_nrvolume"
                    '        cbo_compartimento.DataBind()
                    '        cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    '    End If
                    'End If
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If


    End Sub


    Protected Sub grdFaixas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdFaixas.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) And ViewState.Item("incluirlinha") = "S" Then
            Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
            If Not (dr Is Nothing) Then
                Dim txt_nm_faixa As Anthem.TextBox = CType(e.Row.FindControl("txt_nm_faixa"), Anthem.TextBox)
                Dim txt_nr_faixa_inicio As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_faixa_inicio"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_nr_faixa_fim As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_faixa_fim"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                txt_nm_faixa.Text = dr.Item(0).ToString
                txt_nr_faixa_inicio.Text = dr.Item(1).ToString
                txt_nr_faixa_fim.Text = dr.Item(2).ToString

            End If
        End If
    End Sub

    Protected Sub gridRomaneioCompartimento_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdFaixas.RowDeleting
        e.Cancel = True

    End Sub

 
    Protected Sub cv_validar_faixas_grid_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_validar_faixas_grid.ServerValidate
        Try
            Dim i As Integer = 0
            Dim row As GridViewRow
            Dim iprincipal As Integer = 0
            Dim fx_ini As New ArrayList
            Dim lmsg As String
            args.IsValid = True

            For Each row In grdFaixas.Rows
                If row.Visible = True Then
                    Dim txt_nr_faixa_inicio As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_inicio"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_nr_faixa_fim As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_faixa_fim"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)

                    If Not txt_nr_faixa_inicio.Text.Equals(String.Empty) Then
                        If Not txt_nr_faixa_fim.Text.Equals(String.Empty) Then
                            If CDec(txt_nr_faixa_inicio.Text.Trim) > CDec(txt_nr_faixa_fim.Text.Trim) Then
                                args.IsValid = False
                                lmsg = "A faixa inicial '" & txt_nr_faixa_inicio.Text & "' não pode ser maior que a faixa final '" & txt_nr_faixa_fim.Text & "'."
                                Exit For
                            End If
                        End If
                    End If
                End If
            Next
            If args.IsValid = False Then

                messageControl.Alert(lmsg)

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_grid_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_grid.ServerValidate
        Try
            args.IsValid = True
            If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
                args.IsValid = False
                messageControl.Alert("Uma faixa deve ser informada para continuar.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_grupo_faixa.aspx")
    End Sub
End Class
