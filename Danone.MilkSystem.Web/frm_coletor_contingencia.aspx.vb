Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_coletor_contingencia
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_coletor_contingencia.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If

    End Sub

    Private Sub loadDetails()

        Try
            Dim motivonaocoleta As New MotivoNaoColeta

            cbo_motivo_nao_coleta.DataSource = motivonaocoleta.getMotivoNaoColetaByFilters()
            cbo_motivo_nao_coleta.DataTextField = "nm_motivo_nao_coleta"
            cbo_motivo_nao_coleta.DataValueField = "id_motivo_nao_coleta"
            cbo_motivo_nao_coleta.DataBind()
            cbo_motivo_nao_coleta.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            If Not (Request("id_coleta") Is Nothing) Then
                ViewState.Item("id_coleta") = Request("id_coleta")
                '16/02/2009 - Rls16 - i
                If Not (Request("currentidentity") Is Nothing) Then
                    ViewState.Item("currentidentity") = Request("currentidentity")
                End If
                '16/02/2009 - Rls16 - f

                ' 23/09/2009 - Rls21 - Frete - i (Busca a placa alterada)
                Dim caderneta As New Caderneta
                caderneta.currentidentity = ViewState.Item("currentidentity")
                Dim dsCaderneta As DataSet = caderneta.getCadernetaPlacaFreteContingencia()
                If Not IsDBNull(dsCaderneta.Tables(0).Rows(0).Item("ds_placa_frete")) Then
                    lbl_placa_frete.Text = dsCaderneta.Tables(0).Rows(0).Item("ds_placa_frete")
                Else
                    lbl_placa_frete.Text = ""
                End If
                ' 23/09/2009 - Rls21 - Frete - f

                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()

        Dim caderneta As New Caderneta

        caderneta.id_coleta = ViewState.Item("id_coleta")
        Dim dsColetaHeader As DataSet = caderneta.getColetaHeaderContingencia()

        Me.lbl_produtor.Text = dsColetaHeader.Tables(0).Rows(0).Item("ds_produtor")
        Me.lbl_propriedade.Text = dsColetaHeader.Tables(0).Rows(0).Item("ds_propriedade")
        Me.lbl_unid_producao.Text = dsColetaHeader.Tables(0).Rows(0).Item("nr_unid_producao")
        'fran dez/2018 i
        If Not IsDBNull(dsColetaHeader.Tables(0).Rows(0).Item("dt_coleta")) Then
            txt_hr_coleta.Text = Format(DateTime.Parse(dsColetaHeader.Tables(0).Rows(0).Item("dt_coleta")), "HH")
            txt_mm_coleta.Text = Format(DateTime.Parse(dsColetaHeader.Tables(0).Rows(0).Item("dt_coleta")), "mm")
            txt_dt_coleta.Text = Format(DateTime.Parse(dsColetaHeader.Tables(0).Rows(0).Item("dt_coleta")), "dd/MM/yyyy").ToString
        Else
            txt_hr_coleta.Text = Format(DateTime.Parse(Now), "HH")
            txt_mm_coleta.Text = Format(DateTime.Parse(Now), "mm")
            txt_dt_coleta.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy").ToString
        End If
        'fran dez/2018 f

        If Not IsDBNull(dsColetaHeader.Tables(0).Rows(0).Item("id_motivo_nao_coleta")) Then
            cbo_motivo_nao_coleta.SelectedValue = dsColetaHeader.Tables(0).Rows(0).Item("id_motivo_nao_coleta")
            gridColetas.Visible = False
            btn_novo_compartimento.Visible = False
            btn_atualizar_data_coleta.Visible = False 'fran dez/2018
        Else
            gridColetas.Visible = True
            btn_novo_compartimento.Visible = True
            btn_atualizar_data_coleta.Visible = True 'fran dez/2018

            loadGridColetas()
        End If

        ' 13/02/2009 - Rls16 - i
        caderneta.currentidentity = ViewState.Item("currentidentity")
        lbl_total_litros.Text = FormatNumber(caderneta.getCadernetaTotalLitros, 0)
        ' 13/02/2009 - Rls16 - f

        loadGridNaoConformidades()    ' 28/09/2009 - Adriana Rls 21 Frete


    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_coletor_contingencia.aspx?id_coleta=" + ViewState.Item("id_coleta").ToString)

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_coletor_contingencia.aspx?id_coleta=" + ViewState.Item("id_coleta").ToString)

    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        'updateData()   ' 13/02/2009 - Rls16
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        'updateData()    ' 13/02/2009 - Rls16
    End Sub


    Protected Sub btn_novo_compartimento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_compartimento.Click

        ViewState.Item("incluirlinha") = "S"
        Dim caderneta As New Caderneta
        caderneta.id_coleta = Convert.ToInt32(ViewState.Item("id_coleta"))

        Dim dsColetaLitros As DataSet = caderneta.getColetaLitrosContingencia()
        Dim dr As DataRow = dsColetaLitros.Tables(0).NewRow()
        dsColetaLitros.Tables(0).Rows.InsertAt(dr, 0)
        gridColetas.Visible = True
        gridColetas.DataSource = Helper.getDataView(dsColetaLitros.Tables(0), ViewState.Item("sortExpression"))
        gridColetas.EditIndex = 0
        gridColetas.DataBind()
        ViewState.Item("incluirlinha") = Nothing
        'loadGridColetas()

    End Sub

    Private Sub loadCompartimentosByPlaca(ByVal id_index_row As Int32, ByVal ds_placa As String)

        Try

            Dim cbo_compartimento As Anthem.DropDownList = CType(gridColetas.Rows.Item(id_index_row).FindControl("cbo_compartimento"), Anthem.DropDownList)

            cbo_compartimento.Enabled = True
            Dim compartimento As New Compartimento
            compartimento.id_veiculo = ds_placa.Trim.ToString
            compartimento.id_situacao = 1    ' 15/01/2009 - Trazer somente ativos

            cbo_compartimento.DataSource = compartimento.getCompartimentoByFilters()
            cbo_compartimento.DataTextField = "nm_compartimento"
            cbo_compartimento.DataValueField = "id_compartimento"
            cbo_compartimento.DataBind()
            cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub




    'Protected Sub txt_placa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)



    'End Sub


    Protected Sub cbo_compartimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        'Dim wc As WebControl = CType(sender, WebControl)
        'Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        'Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)

        'Dim compartimento As New Compartimento(Convert.ToInt32(cbo_compartimento.SelectedValue))
        'Dim ds As DataSet = compartimento.getCompartimentoByFilters()





    End Sub


    Protected Sub cv_grid_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_grid.ServerValidate

        Try
            Dim i As Integer = 0
            Dim row As GridViewRow
            Dim placasid As New ArrayList
            args.IsValid = True
            For Each row In gridColetas.Rows
                If row.Visible = True Then
                    Dim cbo_placa As DropDownList = CType(row.FindControl("cbo_placa"), DropDownList)
                    Dim cbo_compartimento As DropDownList = CType(row.FindControl("cbo_compartimento"), DropDownList)
                    If Not (cbo_compartimento Is Nothing) Then
                        'placasid.Add(String.Concat(UCase(cbo_placa.SelectedValue), cbo_compartimento.SelectedValue))
                        placasid.Add(String.Concat(UCase(cbo_placa.SelectedItem.Text), cbo_compartimento.SelectedItem.Text))
                    Else
                        Dim lbl_placa As Label = CType(row.FindControl("lbl_placa"), Label)
                        Dim lbl_compartimento As Label = CType(row.FindControl("lbl_compartimento"), Label)
                        placasid.Add(String.Concat(UCase(lbl_placa.Text), lbl_compartimento.Text))
                    End If
                    i = i + 1
                End If
            Next
            Dim lsplacaid_ant As String
            Dim lbMesmaPlacaId As Boolean
            lbMesmaPlacaId = False
            placasid.Sort()
            lsplacaid_ant = ""

            For i = 0 To placasid.Count - 1
                If placasid.Item(i).ToString <> lsplacaid_ant.ToString Then
                    lsplacaid_ant = placasid.Item(i).ToString
                Else
                    lbMesmaPlacaId = True
                    Exit For
                End If
            Next

            If lbMesmaPlacaId = True Then
                args.IsValid = False
                messageControl.Alert("O mesmo compartimento não deve ser informado mais de uma vez para a mesma placa.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cbo_motivo_nao_coleta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_motivo_nao_coleta.SelectedIndexChanged

        ' 13/02/2009 - Rls16 - i
        Dim caderneta As New Caderneta
        caderneta.id_coleta = Convert.ToInt32(ViewState.Item("id_coleta"))
        Dim dsColetaLitros As DataSet = caderneta.getColetaLitrosContingencia()
        ' 13/02/2009 - Rls16 - f

        If cbo_motivo_nao_coleta.SelectedValue <> "" Then
            'Dim caderneta As New Caderneta
            'caderneta.id_coleta = Convert.ToInt32(ViewState.Item("id_coleta"))
            'Dim dsColetaLitros As DataSet = caderneta.getColetaLitrosContingencia()

            If (dsColetaLitros.Tables(0).Rows.Count > 0) Then  'Se tem coletas
                'cbo_motivo_nao_coleta.SelectedValue = 0
                messageControl.Alert("Há dados de coleta para a Propriedade. O motivo da não coleta não poderá ser informado.")
            Else
                gridColetas.Visible = False

                ' 13/02/2009 - Rls16 - i
                btn_novo_compartimento.Visible = False
                btn_atualizar_data_coleta.Visible = False 'fran dez/2018
                'messageControl.Alert("Salve a alteração para registrar o motivo da não coleta.")
                caderneta.id_motivo_nao_coleta = cbo_motivo_nao_coleta.SelectedValue
                caderneta.st_leite_coletado = "N"        ' Grava coleta com Motivo informado e status st_leite_coletado = 'N'
                caderneta.ds_placa_frete = Trim(lbl_placa_frete.Text)  ' 23/09/2009 - Rls21 Frete
                caderneta.updateMotivoNaoColetaContingencia()  ' Atualiza motivo e st_leite_coletado
                messageControl.Alert("Motivo da não coleta registrado com sucesso.")
                ' 13/02/2009 - Rls16 - f
            End If
        Else
            ' 13/02/2009 - Rls16 - i
            caderneta.id_motivo_nao_coleta = 0          ' Limpa o motivo
            If (dsColetaLitros.Tables(0).Rows.Count > 0) Then  'Se tem coletas
                caderneta.st_leite_coletado = "S"        ' Grava coleta com Motivo vazio e volta status st_leite_coletado = 'S'
            Else
                caderneta.st_leite_coletado = ""        ' Grava coleta com Motivo vazio e volta status st_leite_coletado = null
            End If
            caderneta.updateMotivoNaoColetaContingencia()  ' Atualiza motivo e st_leite_coletado
            messageControl.Alert("Motivo da não coleta registrado com sucesso.")
            ' 13/02/2009 - Rls16 - f


            gridColetas.Visible = True
            btn_novo_compartimento.Visible = True
            btn_atualizar_data_coleta.Visible = True 'fran dez/2018

            loadGridColetas()
        End If
    End Sub
    Private Sub updateData()

        Try
            ' 13/02/2009 - Rls16  - i
            'Dim caderneta As New Caderneta
            'caderneta.id_coleta = Convert.ToInt32(ViewState.Item("id_coleta"))

            'Dim dsColetaLitros As DataSet = caderneta.getColetaLitrosContingencia()

            'If (dsColetaLitros.Tables(0).Rows.Count > 0) Then  'Se tem coletas
            '    'Fran 12/11/2008 i - O combo é montado com selecione = vazio (estava ocorrendo a seguinte msg: "Conversion from string "" to type double is not valid")
            '    'If cbo_motivo_nao_coleta.SelectedValue <> 0 Then  ' Se selecionou motivo
            '    If cbo_motivo_nao_coleta.SelectedValue <> "" Then  ' Se selecionou motivo
            '        'Fran 12/11/2008 f
            '        messageControl.Alert("Há dados de coleta para a Propriedade. O motivo da não coleta não poderá ser informado.")
            '    Else
            '        messageControl.Alert("Acione o botão salvar somente para registrar o motivo da não coleta.")
            '    End If
            'Else
            '    If cbo_motivo_nao_coleta.SelectedValue <> "" Then  ' Se selecionou motivo
            '        caderneta.id_motivo_nao_coleta = cbo_motivo_nao_coleta.SelectedValue
            '    Else
            '        caderneta.id_motivo_nao_coleta = 0   ' Para retirar
            '    End If
            '    caderneta.updateMotivoNaoColetaContingencia()
            '    messageControl.Alert("Motivo da não coleta registrado com sucesso.")
            'End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridColetas_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridColetas.PageIndexChanging
        gridColetas.PageIndex = e.NewPageIndex
        loadData()

    End Sub
    Private Sub loadGridColetas()

        Try
            'Carrega os dados do Grid
            Dim caderneta As New Caderneta
            caderneta.id_coleta = Convert.ToInt32(ViewState.Item("id_coleta"))

            Dim dsColetaLitros As DataSet = caderneta.getColetaLitrosContingencia()

            If (dsColetaLitros.Tables(0).Rows.Count > 0) Then
                gridColetas.Visible = True
                gridColetas.DataSource = Helper.getDataView(dsColetaLitros.Tables(0), ViewState.Item("sortExpression"))
                gridColetas.DataBind()
            Else
                Dim dr As DataRow = dsColetaLitros.Tables(0).NewRow()
                dsColetaLitros.Tables(0).Rows.InsertAt(dr, 0)
                gridColetas.Visible = True
                gridColetas.DataSource = Helper.getDataView(dsColetaLitros.Tables(0), ViewState.Item("sortExpression"))
                gridColetas.DataBind()
                gridColetas.Rows(0).Cells.Clear()
                gridColetas.Rows(0).Cells.Add(New TableCell())
                gridColetas.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridColetas.Rows(0).Cells(0).Text = "Não existe nenhuma coleta cadastrada!"
                gridColetas.Rows(0).Cells(0).ColumnSpan = 7

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridColetas_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridColetas.RowCancelingEdit
        Try

            gridColetas.EditIndex = -1
            loadGridColetas()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridColetas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridColetas.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Insert"
                ViewState.Item("incluirlinha") = "S"

                Dim caderneta As New Caderneta
                caderneta.id_coleta = Convert.ToInt32(ViewState.Item("id_coleta"))

                Dim dsColetaLitros As DataSet = caderneta.getColetaLitrosContingencia()
                Dim dr As DataRow = dsColetaLitros.Tables(0).NewRow()
                dsColetaLitros.Tables(0).Rows.InsertAt(dr, 0)
                gridColetas.Visible = True
                gridColetas.DataSource = Helper.getDataView(dsColetaLitros.Tables(0), ViewState.Item("sortExpression"))
                gridColetas.EditIndex = 0
                gridColetas.DataBind()
            Case "delete"
                deleteColetaLitros(Convert.ToInt32(e.CommandArgument.ToString()))
        End Select

    End Sub

    Protected Sub gridColetas_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridColetas.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            If ViewState.Item("incluirlinha") = "S" Then
                If e.Row.RowIndex = 0 Then
                    ViewState.Item("label_placa") = ""
                    ViewState.Item("label_compartimento") = ""
                    ViewState.Item("label_alizarol") = ""
                End If

            End If

            Try
                If Not (ViewState.Item("label_placa") Is Nothing) Then
                    Dim cbo_placa As DropDownList = CType(e.Row.FindControl("cbo_placa"), DropDownList)
                    Dim coletaplacas As New ColetaPlacas

                    coletaplacas.id_coleta = ViewState.Item("id_coleta")
                    cbo_placa.DataSource = coletaplacas.getColetaPlacasByFilters()
                    cbo_placa.DataTextField = "ds_placa"
                    'cbo_placa.DataValueField = "ds_placa"
                    cbo_placa.DataValueField = "id_veiculo"
                    cbo_placa.DataBind()

                    If (ViewState.Item("label_placa").ToString.Equals(String.Empty)) Then
                        cbo_placa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState.Item("label_placa") = "SEM_VALOR"
                    Else
                        cbo_placa.SelectedValue = cbo_placa.Items.FindByText(ViewState.Item("label_placa").Trim.ToString).Value
                        ViewState.Item("label_placa") = Nothing
                    End If

                    Dim cbo_compartimento As DropDownList = CType(e.Row.FindControl("cbo_compartimento"), DropDownList)
                    'Dim cbo_compartimento As DropDownList = CType(e.Row.FindControl("cbo_compartimento"), DropDownList)

                    cbo_compartimento.Enabled = True

                    If cbo_placa.SelectedValue <> "" Then
                        Dim compartimento As New Compartimento
                        compartimento.id_veiculo = cbo_placa.SelectedValue
                        'Fran 23/12/2008 i
                        compartimento.id_situacao = 1 'ativo
                        'Fran 23/12/2008 f

                        cbo_compartimento.DataSource = compartimento.getCompartimentoByFilters()
                        cbo_compartimento.DataTextField = "nm_compartimento"
                        cbo_compartimento.DataValueField = "id_compartimento"
                        cbo_compartimento.DataBind()

                        If (ViewState.Item("label_compartimento").ToString.Equals(String.Empty)) Then
                            cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                            ViewState.Item("label_compartimento") = "SEM_VALOR"
                        Else
                            cbo_compartimento.SelectedValue = cbo_compartimento.Items.FindByText(ViewState.Item("label_compartimento").Trim.ToString).Value
                            ViewState.Item("label_compartimento") = Nothing
                        End If
                    End If

                    Dim cbo_alizarol As DropDownList = CType(e.Row.FindControl("cbo_alizarol"), DropDownList)
                    If (ViewState.Item("label_alizarol").ToString.Equals(String.Empty)) Then
                        cbo_alizarol.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState.Item("label_alizarol") = "SEM_VALOR"
                    Else
                        cbo_alizarol.SelectedValue = cbo_alizarol.Items.FindByText(ViewState.Item("label_alizarol").Trim.ToString).Value
                        ViewState.Item("label_alizarol") = Nothing
                    End If

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub gridColetas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridColetas.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                If ViewState.Item("label_placa") = "SEM_VALOR" Then
                    'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                    Dim cbo_placa As DropDownList = CType(e.Row.FindControl("cbo_placa"), DropDownList)
                    If Not (cbo_placa Is Nothing) Then
                        cbo_placa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    End If
                    ViewState.Item("label_placa") = Nothing
                End If
                If ViewState.Item("label_compartimento") = "SEM_VALOR" Then
                    'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                    Dim cbo_compartimento As DropDownList = CType(e.Row.FindControl("cbo_compartimento"), DropDownList)
                    If Not (cbo_compartimento Is Nothing) Then
                        cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    End If
                    ViewState.Item("label_compartimento") = Nothing
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub gridColetas_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles gridColetas.RowDeleted

    End Sub

    Protected Sub gridColetas_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridColetas.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridColetas_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridColetas.RowEditing
        Try

            If ViewState.Item("incluirlinha") = "S" And e.NewEditIndex = 0 Then
                ViewState.Item("incluirlinha") = "S"
                loadGridColetas()
            Else
                Dim lbl_placa As Label = CType(gridColetas.Rows(e.NewEditIndex).FindControl("lbl_placa"), Label)
                ViewState.Item("label_placa") = Trim(lbl_placa.Text)

                Dim lbl_compartimento As Label = CType(gridColetas.Rows(e.NewEditIndex).FindControl("lbl_compartimento"), Label)
                ViewState.Item("label_compartimento") = Trim(lbl_compartimento.Text)

                Dim lbl_alizarol As Label = CType(gridColetas.Rows(e.NewEditIndex).FindControl("lbl_alizarol"), Label)
                ViewState.Item("label_alizarol") = Trim(lbl_alizarol.Text)

                gridColetas.EditIndex = e.NewEditIndex
                loadGridColetas()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridColetas_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridColetas.RowUpdating
        Dim row As GridViewRow = gridColetas.Rows(e.RowIndex)
        Try

            If (Not (row) Is Nothing) Then

                Dim caderneta As New Caderneta
                Dim cbo_placa As DropDownList = CType(row.FindControl("cbo_placa"), DropDownList)
                Dim cbo_compartimento As DropDownList = CType(row.FindControl("cbo_compartimento"), DropDownList)
                Dim txt_nr_litros As TextBox = CType(row.FindControl("txt_nr_litros"), TextBox)
                Dim txt_nr_temperatura As TextBox = CType(row.FindControl("txt_nr_temperatura"), TextBox)
                Dim cbo_alizarol As DropDownList = CType(row.FindControl("cbo_alizarol"), DropDownList)

                'If Not (cbo_placa.SelectedValue.Trim().Equals(String.Empty)) Then
                '    caderneta.ds_placa = cbo_placa.SelectedValue
                'End If

                If Not (cbo_compartimento.SelectedValue.Trim().Equals(String.Empty)) Then
                    caderneta.id_compartimento = Convert.ToInt32(Convert.ToInt32(cbo_compartimento.SelectedValue))
                End If

                caderneta.nr_volume = Convert.ToDecimal(txt_nr_litros.Text)
                caderneta.nr_temperatura = Convert.ToDecimal(txt_nr_temperatura.Text)

                If Not (cbo_alizarol.SelectedValue.Trim().Equals(String.Empty)) Then
                    caderneta.nr_alizarol = Convert.ToInt32(Convert.ToInt32(cbo_alizarol.SelectedValue))
                End If

                caderneta.id_coleta = ViewState.Item("id_coleta")

                Dim coletaplacas As New ColetaPlacas
                coletaplacas.id_coleta = caderneta.id_coleta
                coletaplacas.id_veiculo = cbo_placa.SelectedValue
                Dim dsColetaPlacas As DataSet = coletaplacas.getColetaPlacasByFilters()
                caderneta.id_coleta_veiculo = dsColetaPlacas.Tables(0).Rows(0).Item("id_coleta_veiculo")

                'Se é um novo item
                If IsDBNull(gridColetas.DataKeys.Item(e.RowIndex).Value) Then
                    caderneta.ds_placa_frete = Trim(lbl_placa_frete.Text)  ' 23/09/2009 - Rls21 Frete
                    caderneta.insertColetasContingencia()
                Else
                    caderneta.updateColetasContingencia()
                End If

                gridColetas.EditIndex = -1

                loadGridColetas()

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub deleteColetaLitros(ByVal id_compartimento As Integer)

        Try

            Dim caderneta As New Caderneta()
            caderneta.id_coleta = ViewState.Item("id_coleta")
            caderneta.id_compartimento = id_compartimento
            caderneta.deleteColetasContingencia()
            messageControl.Alert("Registro excluído com sucesso!")
            loadGridColetas()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cbo_placa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim cbo_placa As DropDownList = CType(row.FindControl("cbo_placa"), DropDownList)
        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)

        cbo_compartimento.Items.Clear()
        cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        cbo_compartimento.Enabled = False

        'loadCompartimentosByPlaca(row.RowIndex, cbo_placa.Text.Trim.ToString)
        loadCompartimentosByPlaca(row.RowIndex, cbo_placa.SelectedValue.ToString)

    End Sub
    Private Sub loadGridNaoConformidades()

        ' 28/09/2009 - Adriana rls21 Frete - i
        Try
            'Carrega os dados do Grid
            Dim caderneta As New Caderneta
            caderneta.id_coleta = Convert.ToInt32(ViewState.Item("id_coleta"))

            Dim dsColetasNConf As DataSet = caderneta.getColetasNaoConformidades()

            If (dsColetasNConf.Tables(0).Rows.Count > 0) Then
                gridNConf.Visible = True
                gridNConf.DataSource = Helper.getDataView(dsColetasNConf.Tables(0), ViewState.Item("sortExpression"))
                gridNConf.DataBind()
            Else
                Dim dr As DataRow = dsColetasNConf.Tables(0).NewRow()
                dsColetasNConf.Tables(0).Rows.InsertAt(dr, 0)
                gridNConf.Visible = True
                gridNConf.DataSource = Helper.getDataView(dsColetasNConf.Tables(0), ViewState.Item("sortExpression"))
                gridNConf.DataBind()
                gridNConf.Rows(0).Cells.Clear()
                gridNConf.Rows(0).Cells.Add(New TableCell())
                gridNConf.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridNConf.Rows(0).Cells(0).Text = "Não existe nenhuma Não Conformidade cadastrada!"
                gridNConf.Rows(0).Cells(0).ColumnSpan = 3

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' 28/09/2009 - Adriana rls21 Frete - f

    End Sub
    ' 28/09/2009 - Adriana rls21 Frete - i

    Protected Sub btn_adicionar_nconf_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar_nconf.Click
        ViewState.Item("incluirlinha_nconf") = "S"
        Dim caderneta As New Caderneta
        caderneta.id_coleta = Convert.ToInt32(ViewState.Item("id_coleta"))

        Dim dsColetasNConf As DataSet = caderneta.getColetasNaoConformidades()
        Dim dr As DataRow = dsColetasNConf.Tables(0).NewRow()
        dsColetasNConf.Tables(0).Rows.InsertAt(dr, 0)
        gridNConf.Visible = True
        gridNConf.DataSource = Helper.getDataView(dsColetasNConf.Tables(0), ViewState.Item("sortExpression"))
        gridNConf.EditIndex = 0
        gridNConf.DataBind()
        ViewState.Item("incluirlinha_nconf") = Nothing

    End Sub


    Protected Sub gridNConf_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridNConf.RowCancelingEdit
        Try

            gridNConf.EditIndex = -1
            loadGridNaoConformidades()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridNConf_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridNConf.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Insert"
                ViewState.Item("incluirlinha_nconf") = "S"

                Dim caderneta As New Caderneta
                caderneta.id_coleta = Convert.ToInt32(ViewState.Item("id_coleta"))

                Dim dsColetasNConf As DataSet = caderneta.getColetasNaoConformidades()
                Dim dr As DataRow = dsColetasNConf.Tables(0).NewRow()
                dsColetasNConf.Tables(0).Rows.InsertAt(dr, 0)
                gridNConf.Visible = True
                gridNConf.DataSource = Helper.getDataView(dsColetasNConf.Tables(0), ViewState.Item("sortExpression"))
                gridNConf.EditIndex = 0
                gridNConf.DataBind()
            Case "delete"
                deleteColetaNConf(Convert.ToInt32(e.CommandArgument.ToString()))
        End Select

    End Sub
    Private Sub deleteColetaNConf(ByVal id_coleta_nao_conformidade As Integer)

        Try

            Dim caderneta As New Caderneta()
            caderneta.id_coleta_nao_conformidade = id_coleta_nao_conformidade
            caderneta.deleteColetasNaoConformidades()
            messageControl.Alert("Registro excluído com sucesso!")
            loadGridNaoConformidades()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridNConf_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridNConf.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            If ViewState.Item("incluirlinha_nconf") = "S" Then
                If e.Row.RowIndex = 0 Then
                    ViewState.Item("label_nao_conformidade") = ""
                End If

            End If

            Try
                If Not (ViewState.Item("label_nao_conformidade") Is Nothing) Then
                    Dim cbo_nao_conformidade As DropDownList = CType(e.Row.FindControl("cbo_nao_conformidade"), DropDownList)

                    Dim NaoConformidades As New NaoConformidades
                    cbo_nao_conformidade.DataSource = NaoConformidades.getNaoConformidadesByFilters()
                    cbo_nao_conformidade.DataTextField = "nm_nao_conformidade"
                    cbo_nao_conformidade.DataValueField = "id_nao_conformidade"
                    cbo_nao_conformidade.DataBind()

                    If (ViewState.Item("label_nao_conformidade").ToString.Equals(String.Empty)) Then
                        cbo_nao_conformidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState.Item("label_nao_conformidade") = "SEM_VALOR"
                    Else
                        cbo_nao_conformidade.SelectedValue = cbo_nao_conformidade.Items.FindByText(ViewState.Item("label_nao_conformidade").Trim.ToString).Value
                        ViewState.Item("label_nao_conformidade") = Nothing
                    End If


                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub gridNConf_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridNConf.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                If ViewState.Item("label_nao_conformidade") = "SEM_VALOR" Then
                    'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                    Dim cbo_nao_conformidade As DropDownList = CType(e.Row.FindControl("cbo_nao_conformidade"), DropDownList)
                    If Not (cbo_nao_conformidade Is Nothing) Then
                        cbo_nao_conformidade.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    End If
                    ViewState.Item("label_nao_conformidade") = Nothing
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub gridNConf_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridNConf.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridNConf_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridNConf.RowEditing
        'Try

        '    If ViewState.Item("incluirlinha_nconf") = "S" And e.NewEditIndex = 0 Then
        '        ViewState.Item("incluirlinha_nconf") = "S"
        '        loadGridNaoConformidades()
        '    Else
        '        Dim label_nao_conformidade As Label = CType(gridNConf.Rows(e.NewEditIndex).FindControl("label_nao_conformidade"), Label)
        '        ViewState.Item("label_nao_conformidade") = Trim(label_nao_conformidade.Text)


        '        gridNConf.EditIndex = e.NewEditIndex
        '        loadGridNaoConformidades()
        '    End If
        'Catch ex As Exception
        '    messageControl.Alert(ex.Message)
        'End Try
    End Sub

    Protected Sub gridNConf_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridNConf.RowUpdating
        Dim row As GridViewRow = gridNConf.Rows(e.RowIndex)
        Try

            If (Not (row) Is Nothing) Then

                Dim caderneta As New Caderneta
                Dim cbo_nao_conformidade As DropDownList = CType(row.FindControl("cbo_nao_conformidade"), DropDownList)


                If Not (cbo_nao_conformidade.SelectedValue.Trim().Equals(String.Empty)) Then
                    caderneta.id_nao_conformidade = Convert.ToInt32(Convert.ToInt32(cbo_nao_conformidade.SelectedValue))
                End If


                caderneta.id_coleta = ViewState.Item("id_coleta")


                'Se é um novo item
                If IsDBNull(gridNConf.DataKeys.Item(e.RowIndex).Value) Then
                    caderneta.insertColetasNaoConformidades()
                    ' não precisa alterar (excluir a linha e adicionar outra)
                    'Else
                    '    caderneta.updateColetasNaoConformidades()
                End If

                gridNConf.EditIndex = -1

                loadGridNaoConformidades()

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    ' 28/09/2009 - Adriana rls21 Frete - f

    Protected Sub btn_atualizar_data_coleta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_atualizar_data_coleta.Click
        If Page.IsValid Then

            Try
                Dim caderneta As New Caderneta()
                caderneta.id_coleta = Convert.ToInt32(ViewState.Item("id_coleta"))
                caderneta.dt_coleta = txt_dt_coleta.Text & " " & txt_hr_coleta.Text & ":" & txt_mm_coleta.Text & ":00"
                caderneta.id_modificador = Session("id_login")

                caderneta.updateColetasContingenciaDataColeta()

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteração
                usuariolog.id_menu_item = 15
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango
            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try
        End If

    End Sub
End Class
