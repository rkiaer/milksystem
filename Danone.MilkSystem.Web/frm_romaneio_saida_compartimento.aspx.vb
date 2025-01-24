Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_romaneio_saida_compartimento
    Inherits Page
    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_saida_compartimento.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 247
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 


            If Not (Request("id_romaneio_saida") Is Nothing) Then
                ViewState.Item("id_romaneio_saida") = Request("id_romaneio_saida")
            Else
                ViewState.Item("id_romaneio_saida") = 0
            End If

            loadDetails()
        Else
            If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
                gridRomaneioCompartimento.Rows(0).Cells.Clear()
                gridRomaneioCompartimento.Rows(0).Cells.Add(New TableCell())
                gridRomaneioCompartimento.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridRomaneioCompartimento.Rows(0).Cells(0).Text = "Não existe nenhuma Placa/Compartimento cadastrados!"
                gridRomaneioCompartimento.Rows(0).Cells(0).ColumnSpan = 7
            End If
        End If
        'With btn_lupa_transportador
        '    .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
        '    .ToolTip = "Filtrar Transportadores"
        'End With

    End Sub

    Private Sub loadDetails()

        Try



            Dim dsgrid As New DataTable
            dsgrid.Rows.InsertAt(dsgrid.NewRow(), 0)

            gridRomaneioCompartimento.Visible = True
            gridRomaneioCompartimento.DataSource = Helper.getDataView(dsgrid, ViewState.Item("sortExpression"))
            gridRomaneioCompartimento.DataBind()
            gridRomaneioCompartimento.Rows(0).Cells.Clear()
            gridRomaneioCompartimento.Rows(0).Cells.Add(New TableCell())
            gridRomaneioCompartimento.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            gridRomaneioCompartimento.Rows(0).Cells(0).Text = "Não existe nenhuma Placa/Compartimento cadastrados!"
            gridRomaneioCompartimento.Rows(0).Cells(0).ColumnSpan = 7


            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()

        Try

            Dim romaneio As New RomaneioSaida
            romaneio.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))

            Dim dsromaneio As DataSet = romaneio.getRomaneioSaidaByFilters

            lbl_romaneio_saida.Text = ViewState.Item("id_romaneio_saida").ToString

            With dsromaneio.Tables(0).Rows(0)

                ViewState.Item("id_estabelecimento") = .Item("id_estabelecimento").ToString
                lbl_estabelecimento.Text = .Item("ds_estabelecimento").ToString
                lbl_situacao.Text = .Item("nm_situacao_romaneio_saida").ToString
                lbl_dt_entrada.Text = Format(DateTime.Parse(.Item("dt_hora_entrada").ToString), "dd/MM/yyyy hh:mm").ToString
                lbl_tipo_operacao.Text = .Item("nm_tipo_operacao")
                lbl_motivo_saida.Text = .Item("nm_motivo_saida")
                lbl_tipo_leite.Text = .Item("nm_item")
                lbl_tipo_frete.Text = .Item("nm_frete_nf")
                lbl_nm_cooperativa.Text = .Item("ds_cooperativa").ToString
                lbl_cd_cnpj.Text = .Item("cd_cnpj_cooperativa").ToString
                lbl_nm_transportador.Text = .Item("ds_transportador").ToString
                lbl_cnpj_transportador.Text = .Item("cd_cnpj_transportador").ToString

                If .Item("id_motorista") > 0 Then
                    lbl_motorista.Text = .Item("nm_motorista_cadastro").ToString
                    lbl_cd_cnh.Text = .Item("cd_cnh_cadastro").ToString
                Else
                    lbl_motorista.Text = .Item("nm_motorista").ToString
                    lbl_cd_cnh.Text = .Item("cd_cnh").ToString
                End If
                If .Item("nr_pesagem_inicial") > 0 Then
                    lbl_peso_inicial.Text = FormatNumber(CDec(.Item("nr_pesagem_inicial")), 0).ToString
                Else
                    lbl_peso_inicial.Text = String.Empty
                End If

                hf_id_transportador.Value = .Item("id_transportador").ToString

                If Not IsDBNull(.Item("nr_volume_estimado")) Then
                    txt_nr_peso_liquido_estimado.Text = (CDec(.Item("nr_volume_estimado"))).ToString("######")
                Else
                    txt_nr_peso_liquido_estimado.Text = String.Empty
                End If
            End With


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid Then


            Try

                Dim romaneio As New RomaneioSaida()
                Dim row As GridViewRow
                romaneio.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida").ToString)
                If Not (txt_nr_peso_liquido_estimado.Text.Trim.Equals(String.Empty)) Then
                    romaneio.nr_volume_estimado = Convert.ToDecimal(txt_nr_peso_liquido_estimado.Text)
                End If
                romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                romaneio.id_modificador = Session("id_login")
                romaneio.id_situacao_romaneio_saida = 4 'Carregado
                romaneio.id_situacao = 4

                distribuirVolumeCompartimento()

                For Each row In gridRomaneioCompartimento.Rows
                    If row.Visible = True Then
                        'Dim txt_placa As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
                        Dim cbo_placa As Anthem.DropDownList = CType(row.FindControl("cbo_placa"), Anthem.DropDownList)
                        Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_id_compartimento As DataControlFieldCell = CType(row.Cells(7), DataControlFieldCell)
                        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                        Dim chk As Anthem.CheckBox = CType(row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)

                        If chk.Checked = True Then
                            romaneio.ds_placa = cbo_placa.SelectedItem.ToString
                        End If

                        romaneio.rc_ds_placa.Add(cbo_placa.SelectedItem.ToString)
                        romaneio.rc_id_compartimento.Add(Convert.ToInt32(cbo_compartimento.SelectedValue))
                        If Not (txt_nr_total_litros.Text.ToString.Equals(String.Empty)) Then
                            romaneio.rc_nr_total_volume.Add(Convert.ToDecimal(txt_nr_total_litros.Text))
                        Else
                            romaneio.rc_nr_total_volume.Add(Convert.ToDecimal(0))
                        End If

                    End If
                Next

                romaneio.incluirRomaneioSaidaCompartimento()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 247
                usuariolog.id_nr_processo = romaneio.id_romaneio_saida.ToString
                usuariolog.nm_nr_processo = romaneio.id_romaneio_saida.ToString

                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
                btn_novo_compartimento.Enabled = False

                Dim lmsg As String
                lmsg = "O registro dos compartimentos do romaneio de saída " + romaneio.id_romaneio_saida.ToString + " foi executado com sucesso!"
                messageControl.Alert(lmsg)

                loadData()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Private Sub carregarCamposVeiculo(ByVal id_index_row As Integer)

        Try
            Dim txt_ds_placa As Anthem.TextBox = CType(gridRomaneioCompartimento.Rows.Item(id_index_row).FindControl("txt_placa"), Anthem.TextBox)
            txt_ds_placa.Text = ""
            If Not (customPage.getFilterValue("lupa_veiculo", "ds_placa").Equals(String.Empty)) Then
                txt_ds_placa.Text = customPage.getFilterValue("lupa_veiculo", "ds_placa").ToString
                loadCompartimentosByPlaca(id_index_row, txt_ds_placa.Text)
            End If

            'loadData()
            customPage.clearFilters("lupa_veiculo")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposTransportador()

        Try

            If Not (customPage.getFilterValue("lupa_transcoop", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transcoop", "nm_pessoa").ToString
            End If

            'If Not (customPage.getFilterValue("lupa_transcoop", "cd_pessoa").Equals(String.Empty)) Then
            '    Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transcoop", "cd_pessoa").ToString
            'End If

            'loadData()
            customPage.clearFilters("lupa_transcoop")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    'Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate
    '    Try
    '        Dim pessoa As New Pessoa()
    '        Dim lidtransportador As Int32
    '        If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
    '            pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_transportador.Value)
    '        End If

    '        pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
    '        'lidtransportador = pessoa.validarTransportador Fran 09/01/2011 i
    '        lidtransportador = pessoa.validarTransportadorCooperativa

    '        If lidtransportador > 0 Then
    '            args.IsValid = True
    '            hf_id_transportador.Value = lidtransportador
    '        Else
    '            hf_id_transportador.Value = String.Empty
    '            args.IsValid = False
    '            messageControl.Alert("Transportador não cadastrado.")
    '        End If
    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try
    'End Sub



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub btn_novo_compartimento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_compartimento.Click
        Try

            Dim dstable As New DataTable
            Dim ilinha As Integer
            If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
                Dim rc As New RomaneioSaidaCompartimento
                Dim ds As New DataSet
                rc.id_romaneio_saida = -1
                ds = rc.getRomaneioSaidaCompartimentoByFilters
                ViewState.Item("gridLinhasAdicionadas") = "S"

                ilinha = 0
            Else
                ViewState.Item("incluirlinha") = "S"
                'dstable.Rows.InsertAt(dstable.NewRow(), dstable.Rows.Count + 1)
                dstable.Columns.Add("ds_placa")
                dstable.Columns.Add("st_placa_principal")
                dstable.Columns.Add("ds_id_nrvolume")
                dstable.Columns.Add("nr_volume")
                dstable.Columns.Add("nr_total_litros")
                dstable.Columns.Add("id_index")
                dstable.Columns.Add("id_compartimento")

                Dim row As GridViewRow
                ilinha = 0
                For Each row In gridRomaneioCompartimento.Rows
                    If row.Visible = True Then
                        'Dim txt_placa As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
                        Dim check As Anthem.CheckBox = CType(row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)
                        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                        Dim cbo_placa As Anthem.DropDownList = CType(row.FindControl("cbo_placa"), Anthem.DropDownList)
                        Dim txt_volcomp As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)
                        Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_id_index As DataControlFieldCell = CType(row.Cells(6), DataControlFieldCell)
                        Dim txt_id_compartimento As DataControlFieldCell = CType(row.Cells(7), DataControlFieldCell)

                        dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
                        With dstable.Rows.Item(ilinha)
                            .Item(0) = cbo_placa.SelectedItem.ToString
                            If check.Checked = True Then
                                .Item(1) = "S"
                            Else
                                .Item(1) = "N"
                            End If

                            .Item(2) = cbo_compartimento.SelectedValue
                            .Item(3) = txt_volcomp.Text
                            .Item(4) = txt_nr_total_litros.Text
                            .Item(5) = txt_id_index.Text
                            .Item(6) = txt_id_compartimento.Text
                        End With
                        ilinha = ilinha + 1
                    End If
                Next

                ViewState.Item("gridtable") = dstable

            End If

            dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
            gridRomaneioCompartimento.Visible = True
            gridRomaneioCompartimento.DataSource = Helper.getDataView(dstable, ViewState.Item("sortExpression"))

            gridRomaneioCompartimento.DataBind()

            ViewState.Item("incluirlinha") = "N"
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub


    Private Sub loadCompartimentosByPlaca(ByVal id_index_row As Int32, ByVal ds_placa As String)

        Try

            Dim cbo_compartimento As Anthem.DropDownList = CType(gridRomaneioCompartimento.Rows.Item(id_index_row).FindControl("cbo_compartimento"), Anthem.DropDownList)

            Dim txt_id_index As DataControlFieldCell = CType(gridRomaneioCompartimento.Rows.Item(id_index_row).Cells(6), DataControlFieldCell)

            txt_id_index.Text = id_index_row.ToString
            cbo_compartimento.Enabled = True
            Dim compartimento As New Compartimento
            compartimento.ds_placa = ds_placa.Trim.ToString
            compartimento.id_situacao = 1
            cbo_compartimento.DataSource = compartimento.getCompartimentoByFilters()
            cbo_compartimento.DataTextField = "ds_compartimento"
            cbo_compartimento.DataValueField = "id_compartimento"
            cbo_compartimento.DataBind()
            cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridRomaneioCompartimento_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridRomaneioCompartimento.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "delete"
                deleteRomaneioCompartimento(Convert.ToInt32(e.CommandArgument.ToString()))

            Case "Lupa"
                'Me.txt_placa.Text = ""

                carregarCamposVeiculo(Convert.ToInt32(e.CommandArgument.ToString()))


        End Select

    End Sub
    Private Sub deleteRomaneioCompartimento(ByVal id_index_row As Integer)

        Try

            gridRomaneioCompartimento.Rows(id_index_row).Visible = False
            'loadGridEscolaridade()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridRomaneioCompartimento_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridRomaneioCompartimento.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btnexcluir As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)
                'Dim bt_lupa_veiculo As Anthem.ImageButton = CType(e.Row.FindControl("bt_lupa_veiculo"), Anthem.ImageButton)
                btnexcluir.CommandArgument = e.Row.RowIndex.ToString
                'bt_lupa_veiculo.CommandArgument = e.Row.RowIndex.ToString
                'With bt_lupa_veiculo
                '    .Attributes.Add("onclick", "javascript:ShowDialog()")
                '    .ToolTip = "Filtrar Veículos"
                '    '.Style("cursor") = "hand"
                'End With

                Dim cbo_placa As Anthem.DropDownList = CType(e.Row.FindControl("cbo_placa"), Anthem.DropDownList)
                cbo_placa.Enabled = True
                Dim rsplaca As New RomaneioSaidaPlaca
                rsplaca.id_romaneio_saida = ViewState.Item("id_romaneio_saida")
                cbo_placa.DataSource = rsplaca.getRomaneioSaidaPlacasByRomaneio()
                cbo_placa.DataTextField = "ds_placa"
                cbo_placa.DataValueField = "id_romaneio_saida_placa"
                cbo_placa.DataBind()
                cbo_placa.Items.Insert(0, New ListItem("[Selecione]", 0))

                If ViewState.Item("incluirlinha") = "S" Then
                    Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
                    If Not (dr Is Nothing) Then

                        If Not (dr.Item(0).ToString.Equals(String.Empty)) Then
                            Dim cbo_compartimento As Anthem.DropDownList = CType(e.Row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                            cbo_compartimento.Enabled = True
                            Dim compartimento As New Compartimento
                            compartimento.id_situacao = 1
                            compartimento.ds_placa = dr.Item(0).ToString
                            cbo_compartimento.DataSource = compartimento.getCompartimentoByFilters()
                            cbo_compartimento.DataTextField = "ds_compartimento"
                            cbo_compartimento.DataValueField = "id_compartimento"
                            cbo_compartimento.DataBind()
                            cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        End If
                    End If
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If


    End Sub
    'Protected Sub txt_placa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    'Dim NomeControle As String = CType(sender, TextBox).ClientID
    '    '        Dim teste As TextBox = CType(sender, TextBox)
    '    '       Dim row As GridViewRow = CType(gridRomaneioCompartimento.SelectedRow, GridViewRow)
    '    Dim wc As WebControl = CType(sender, WebControl)
    '    Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
    '    Dim txtplaca As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
    '    Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
    '    Dim txtvolmaxcomp As DataControlFieldCell = CType(row.Cells.Item(3), DataControlFieldCell)

    '    txtvolmaxcomp.Text = String.Empty
    '    cbo_compartimento.Items.Clear()
    '    cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
    '    cbo_compartimento.Enabled = False

    '    loadCompartimentosByPlaca(row.RowIndex, txtplaca.Text.Trim.ToString)


    'End Sub


    Protected Sub cbo_compartimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
        Dim txtvolmaxcomp As DataControlFieldCell = CType(row.Cells.Item(3), DataControlFieldCell)

        Dim compartimento As New Compartimento(Convert.ToInt32(cbo_compartimento.SelectedValue))
        Dim ds As DataSet = compartimento.getCompartimentoByFilters()

        txtvolmaxcomp.Text = ds.Tables(0).Rows(0).Item("nr_volume")




    End Sub

    Protected Sub gridRomaneioCompartimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridRomaneioCompartimento.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) And ViewState.Item("incluirlinha") = "S" Then
            Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
            If Not (dr Is Nothing) Then
                Dim cbo_placa As Anthem.DropDownList = CType(e.Row.FindControl("cbo_placa"), Anthem.DropDownList)
                'Dim txt_placa As Anthem.TextBox = CType(e.Row.FindControl("txt_placa"), Anthem.TextBox)
                Dim check As Anthem.CheckBox = CType(e.Row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)
                Dim cbo_compartimento As Anthem.DropDownList = CType(e.Row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                Dim txt_volcomp As DataControlFieldCell = CType(e.Row.Cells(3), DataControlFieldCell)
                Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_id_index As DataControlFieldCell = CType(e.Row.Cells(6), DataControlFieldCell)
                Dim txt_id_compartimento As DataControlFieldCell = CType(e.Row.Cells(7), DataControlFieldCell)

                If Not (dr.Item(0).ToString.Equals(String.Empty)) Then
                    cbo_placa.SelectedValue = cbo_placa.Items.FindByText(dr.Item(0).ToString).Value
                Else
                    cbo_placa.Items.Insert(0, New ListItem("[Selecione]", 0))
                    cbo_placa.SelectedValue = 0
                End If
                If dr.Item(2).ToString.Equals(String.Empty) Then
                    If Not (dr.Item(0).ToString.Equals(String.Empty)) Then
                        cbo_compartimento.Enabled = True
                        cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    Else
                        cbo_compartimento.Enabled = False
                    End If
                Else
                    cbo_compartimento.Enabled = True
                    cbo_compartimento.SelectedValue = dr.Item(2).ToString
                End If
                If dr.Item(1).ToString = "S" Then
                    check.Checked = True
                Else
                    check.Checked = False
                End If

                txt_volcomp.Text = dr.Item(3).ToString
                txt_nr_total_litros.Text = dr.Item(4).ToString
                txt_id_index.Text = dr.Item(5).ToString
                txt_id_compartimento.Text = dr.Item(6).ToString

            End If
        Else
            If (e.Row.RowType = DataControlRowType.DataRow) AndAlso ViewState.Item("gridLinhasAdicionadas") = "S" Then
                Dim cbo_placa As Anthem.DropDownList = CType(e.Row.FindControl("cbo_placa"), Anthem.DropDownList)

                cbo_placa.Items.Insert(0, New ListItem("[Selecione]", 0))

            End If
        End If
    End Sub

    Protected Sub gridRomaneioCompartimento_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridRomaneioCompartimento.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub cmv_placa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try
            Dim veiculo As New Veiculo()

            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim txt_placa As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)

            veiculo.ds_placa = txt_placa.Text
            args.IsValid = veiculo.validarPlaca()
            If Not args.IsValid Then
                messageControl.Alert("Placa não cadastrada.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_placa_principal_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_placa_principal.ServerValidate
        Try
            Dim i As Integer = 0
            Dim row As GridViewRow
            Dim iprincipal As Integer = 0
            Dim placasid As New ArrayList
            args.IsValid = True
            For Each row In gridRomaneioCompartimento.Rows
                If row.Visible = True Then
                    Dim txt_placa As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
                    Dim chk_placa_principal As Anthem.CheckBox = CType(row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)
                    Dim txt_id_compartimento As DataControlFieldCell = CType(row.Cells(7), DataControlFieldCell)
                    Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)

                    If chk_placa_principal.Checked = True Then
                        iprincipal = iprincipal + 1
                    End If
                    placasid.Add(String.Concat(UCase(txt_placa.Text), cbo_compartimento.SelectedValue))
                    i = i + 1
                End If
            Next
            If iprincipal = 1 Then 'Se não há erros, se selecionou uma placa
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
            Else
                If iprincipal = 0 Then
                    args.IsValid = False
                    messageControl.Alert("Informe uma placa como principal para continuar.")
                End If
                If iprincipal > 1 Then
                    args.IsValid = False
                    messageControl.Alert("Apenas uma placa deve ser informada como principal.")
                End If

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
                messageControl.Alert("Uma placa deve ser informada para continuar.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub distribuirVolumeCompartimento()
        If Page.IsValid Then


            Try

                Dim row As GridViewRow

                'Fran 20/03/2009 i RLS 17

                ''Busca os volumes maximos para cada compartiment o informado
                'Dim ltotalvolumescompartimento As Decimal
                'Dim lpercentual As Decimal
                'ltotalvolumescompartimento = 0
                'For Each row In gridRomaneioCompartimento.Rows
                '    If row.Visible = True Then
                '        Dim lbl_max_compartimento As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)
                '        'Guarda o somatório dos volumes maximos permitidos para cada compartimento
                '        ltotalvolumescompartimento = ltotalvolumescompartimento + CDec(lbl_max_compartimento.Text)
                '    End If
                'Next
                'For Each row In gridRomaneioCompartimento.Rows
                '    If row.Visible = True Then
                '        Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                '        Dim lbl_max_compartimento As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)
                '        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)

                '        'Acha o percentual referente ao vol maximo de cada compartimento com relação ao total dos volumes maximos informados
                '        lpercentual = (CDec(lbl_max_compartimento.Text) * 100) / ltotalvolumescompartimento
                '        'atribui a coluna invisivel total litro compratimento, o valor liquido da nota vezes o percentual do compartimento
                '        txt_nr_total_litros.Text = Round(CDec(Me.txt_nr_peso_liquido_nota.Text * (lpercentual / 100)), 4)

                '    End If
                'Next


                Dim lqtdecomp As Int32 = 0 'qtde compartimentos a realizar a distribuição
                Dim lvolrestantecomp As Decimal 'volume restante de cada compartimento apos retirar o valor de distribuição
                Dim lcompNCheio As New ArrayList 'guarda a linha dos compartimento que ainda não estão cheios para participarem da redistribuição
                Dim lvoldistribuido As Decimal
                Dim lresto As Decimal

                'Na priomeira vez busco qtos compartimentos foram inseridos
                For Each row In gridRomaneioCompartimento.Rows
                    If row.Visible = True Then
                        Dim lbl_comp_cheio As Label = CType(row.FindControl("lbl_comp_cheio"), Label)
                        'Guarda o somatório dos compartimenros
                        lqtdecomp = lqtdecomp + 1
                        lcompNCheio.Add(row.RowIndex)
                        lbl_comp_cheio.Text = "N" 'seta que cada compratimento não esta cheio ainda
                    End If
                Next

                'Esta operação '\' divide devolvendo a parte inteira apenas
                lvoldistribuido = CDec(Me.txt_nr_peso_liquido_estimado.Text) \ lqtdecomp
                'Devolve o resto da divisão
                lresto = Decimal.Remainder(CDec(Me.txt_nr_peso_liquido_estimado.Text), lqtdecomp)
                lqtdecomp = 0

                Do While lresto >= 0

                    If lqtdecomp > 0 Then 'Se é a 2a vez
                        'Esta operação '\' divide devolvendo a parte inteira apenas
                        lvoldistribuido = CDec(lresto) \ lqtdecomp
                        'Devolve o resto da divisão
                        lresto = Decimal.Remainder(CDec(lresto), lqtdecomp)
                    End If
                    lqtdecomp = 0
                    For Each row In gridRomaneioCompartimento.Rows
                        Dim lbl_comp_cheio As Label = CType(row.FindControl("lbl_comp_cheio"), Label)

                        If row.Visible = True Then
                            'Se o compartimento ainda não esta cheio
                            If lbl_comp_cheio.Text = "N" Then

                                Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                                Dim lbl_max_compartimento As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)

                                If txt_nr_total_litros.Text.Equals(String.Empty) Then
                                    txt_nr_total_litros.Text = "0"
                                End If

                                'Se a parte inteira da divisao deu 0 tenta colocar o resto no primeiro compartimento que der
                                If lvoldistribuido > 0 Then
                                    lvolrestantecomp = (CDec(lbl_max_compartimento.Text) - CDec(txt_nr_total_litros.Text)) - lvoldistribuido

                                    'SE o vol restante for maior que zero
                                    If lvolrestantecomp >= 0 Then
                                        'Guarda a linha do compartimento
                                        lcompNCheio.Add(row.RowIndex)
                                        txt_nr_total_litros.Text = CDec(txt_nr_total_litros.Text) + lvoldistribuido
                                        lbl_comp_cheio.Text = "N"
                                        lqtdecomp = lqtdecomp + 1
                                    Else
                                        'Soma o resto
                                        lresto = lresto + Math.Abs(lvolrestantecomp)
                                        txt_nr_total_litros.Text = CDec(txt_nr_total_litros.Text) + (lvoldistribuido - Math.Abs(lvolrestantecomp))
                                        lbl_comp_cheio.Text = "S"

                                    End If
                                Else
                                    lvolrestantecomp = (CDec(lbl_max_compartimento.Text) - CDec(txt_nr_total_litros.Text)) - lresto
                                    'SE o vol restante for maior que zero
                                    If lvolrestantecomp >= 0 Then
                                        txt_nr_total_litros.Text = CDec(txt_nr_total_litros.Text) + lresto
                                        lbl_comp_cheio.Text = "N"
                                        If lvolrestantecomp = 0 Then
                                            lbl_comp_cheio.Text = "S"
                                        End If
                                        lresto = -1 'força sair do laço
                                        Exit For
                                    Else
                                        txt_nr_total_litros.Text = CDec(txt_nr_total_litros.Text) + (lresto - Math.Abs(lvolrestantecomp))
                                        lbl_comp_cheio.Text = "S"
                                        'Soma o resto
                                        lresto = Math.Abs(lvolrestantecomp)

                                    End If

                                End If
                            End If
                        End If
                    Next
                    If lresto = 0 Then
                        lresto = -1
                    End If
                Loop
                'fran 20/03/2009 f


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_romaneio_saida_registro_compartimento.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida").ToString)

    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_saida_registro_compartimento.aspx?id_romaneio_saida=" + ViewState.Item("id_romaneio_saida").ToString)

    End Sub

    Protected Sub cbo_placa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim cboplaca As Anthem.DropDownList = CType(row.FindControl("cbo_placa"), Anthem.DropDownList)
        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
        Dim txtvolmaxcomp As DataControlFieldCell = CType(row.Cells.Item(3), DataControlFieldCell)
        Dim chk_st_placa_principal As Anthem.CheckBox = CType(row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)

        If CInt(cboplaca.SelectedValue) > 0 Then
            Dim romaneiosaidaplaca As New RomaneioSaidaPlaca(cboplaca.SelectedValue)

            If romaneiosaidaplaca.st_placa_principal = "S" Then
                chk_st_placa_principal.Checked = True
            Else
                chk_st_placa_principal.Checked = False

            End If

            chk_st_placa_principal.Enabled = False
        End If

        txtvolmaxcomp.Text = String.Empty
        cbo_compartimento.Items.Clear()
        cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        cbo_compartimento.Enabled = False

        loadCompartimentosByPlaca(row.RowIndex, cboplaca.SelectedItem.ToString)

    End Sub

    Protected Sub cv_verificarvolume_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_verificarvolume.ServerValidate
        Try
            Dim row As GridViewRow
            Dim ltotalvolumescompartimento As Decimal
            For Each row In gridRomaneioCompartimento.Rows
                If row.Visible = True Then
                    Dim lbl_max_compartimento As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)
                    'Guarda o somatório dos volumes maximos permitidos para cada compartimento
                    ltotalvolumescompartimento = ltotalvolumescompartimento + CDec(lbl_max_compartimento.Text)
                End If
            Next

            If ltotalvolumescompartimento < CDec(txt_nr_peso_liquido_estimado.Text) Then
                args.IsValid = False
            Else
                args.IsValid = True
            End If

            If args.IsValid = False Then
                messageControl.Alert("'Litros da Nota Fiscal' não pode ser maior que a somatória do 'Volume Máximo' dos compartimentos informados.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class
