Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class frm_transit_point_novo

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_transit_point_novo.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        Else
            If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then

                gridTransitPointCompartimento.Rows(0).Cells.Clear()
                gridTransitPointCompartimento.Rows(0).Cells.Add(New TableCell())
                gridTransitPointCompartimento.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridTransitPointCompartimento.Rows(0).Cells(0).Text = "Não existe nenhuma Placa/Compartimento cadastrados!"
                gridTransitPointCompartimento.Rows(0).Cells(0).ColumnSpan = 7
            End If

        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Transportadores"
        End With

    End Sub

    Private Sub loadDetails()

        Try

            Dim estabel As New Estabelecimento

            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim item As New Item
            cbo_id_item.DataSource = item.getItensByFilters()
            cbo_id_item.DataTextField = "nm_item"
            cbo_id_item.DataValueField = "id_item"
            cbo_id_item.DataBind()
            cbo_id_item.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim dsgrid As New DataTable
            dsgrid.Rows.InsertAt(dsgrid.NewRow(), 0)

            gridTransitPointCompartimento.Visible = True
            gridTransitPointCompartimento.DataSource = Helper.getDataView(dsgrid, ViewState.Item("sortExpression"))
            gridTransitPointCompartimento.DataBind()
            gridTransitPointCompartimento.Rows(0).Cells.Clear()
            gridTransitPointCompartimento.Rows(0).Cells.Add(New TableCell())
            gridTransitPointCompartimento.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            gridTransitPointCompartimento.Rows(0).Cells(0).Text = "Não existe nenhuma Placa/Compartimento cadastrados!"
            gridTransitPointCompartimento.Rows(0).Cells(0).ColumnSpan = 7


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub updateData()
        If Page.IsValid = True Then

            Try

                Dim transitpoint As New TransitPoint
                Dim row As GridViewRow

                transitpoint.id_transit_point_unidade = Convert.ToInt32(cbo_transit_point_unidade.SelectedValue)
                transitpoint.id_linha = cbo_rotas.SelectedValue
                transitpoint.id_motorista = cbo_motorista.SelectedValue
                transitpoint.id_transportador = Convert.ToInt32(hf_id_pessoa.Value)
                transitpoint.id_item = Convert.ToInt32(cbo_id_item.SelectedValue)
                transitpoint.id_modificador = Session("id_login")

                For Each row In gridTransitPointCompartimento.Rows
                    If row.Visible = True Then
                        Dim txt_placa As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
                        Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_id_compartimento As DataControlFieldCell = CType(row.Cells(7), DataControlFieldCell)
                        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                        Dim chk As Anthem.CheckBox = CType(row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)
                        Dim lbl_id_veiculo As Label = CType(row.FindControl("lbl_id_veiculo"), Label)

                        If chk.Checked = True Then
                            transitpoint.ds_placa = txt_placa.Text.ToString
                            transitpoint.tpc_st_placa_principal.Add("S")
                        Else
                            transitpoint.tpc_st_placa_principal.Add("N")
                        End If

                        transitpoint.tpc_id_veiculo.Add(lbl_id_veiculo.Text.ToString)
                        transitpoint.tpc_id_compartimento.Add(Convert.ToInt32(cbo_compartimento.SelectedValue))

                    End If
                Next

                transitpoint.id_transit_point = transitpoint.abrirTransitPoint
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 4 'incluir
                usuariolog.id_menu_item = 167
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 


                Dim lmsg As String
                lmsg = "O TRANSIT POINT foi aberto com sucesso! O número que é a identificação necessária para acompanhamento deste processo é " & transitpoint.id_transit_point.ToString & "."
                Response.Redirect("frm_mensagem.aspx?msg=" + lmsg + "&tela=frm_transit_point.aspx?id_transit_point=" + transitpoint.id_transit_point.ToString)



            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Private Sub carregarCamposVeiculo(ByVal id_index_row As Integer)

        Try
            Dim txt_ds_placa As Anthem.TextBox = CType(gridTransitPointCompartimento.Rows.Item(id_index_row).FindControl("txt_placa"), Anthem.TextBox)
            Dim lbl_id_veiculo As Label = CType(gridTransitPointCompartimento.Rows.Item(id_index_row).FindControl("lbl_id_veiculo"), Label)
            Dim lbl_id_transportador As Label = CType(gridTransitPointCompartimento.Rows.Item(id_index_row).FindControl("lbl_id_transportador"), Label)
            txt_ds_placa.Text = ""
            lbl_id_veiculo.Text = String.Empty
            If Not (customPage.getFilterValue("lupa_veiculo", "ds_placa").Equals(String.Empty)) Then
                txt_ds_placa.Text = customPage.getFilterValue("lupa_veiculo", "ds_placa").ToString
                lbl_id_veiculo.Text = customPage.getFilterValue("lupa_veiculo", "id_veiculo").ToString
                lbl_id_transportador.Text = customPage.getFilterValue("lupa_veiculo", "id_veiculo").ToString
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
            If Not (customPage.getFilterValue("lupa_transportador", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Visible = True
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_transportador", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transportador", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_transportador", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_transportador")

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_transit_point.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_transit_point.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        If Me.cbo_estabelecimento.SelectedValue.ToString <> "0" Then
            'A´pós retornar da modal, carrega os campos
            Me.lbl_nm_pessoa.Visible = True
            carregarCamposTransportador()
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                carregarCamposTransportador()
                'se encontrou produtor
                loadMotoristaByTransportador(hf_id_pessoa.Value)
            Else
                txt_cd_pessoa.Text = String.Empty
                hf_id_pessoa.Value = String.Empty
                lbl_nm_pessoa.Text = String.Empty
                cbo_motorista.Items.Clear()
                cbo_motorista.Enabled = False
            End If

        End If
    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        ViewState.Item("cboestabelecimentoanterior") = cbo_estabelecimento.SelectedValue.ToString
        Me.lbl_nm_pessoa.Text = ""
        Me.txt_cd_pessoa.Text = ""
        Me.lbl_nm_pessoa.Visible = False
        Me.hf_id_pessoa.Value = ""
        If cbo_estabelecimento.SelectedValue <> "0" Then
            loadCombosbyEstabelecimento(cbo_estabelecimento.SelectedValue)
        Else
            cbo_transit_point_unidade.Items.Clear()
            cbo_transit_point_unidade.Enabled = False
        End If
    End Sub


    Protected Sub cv_produtor_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_produtor.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidtransportador As Int32
            If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
            lidtransportador = pessoa.validarTransportador


            If lidtransportador > 0 Then
                args.IsValid = True
                hf_id_pessoa.Value = lidtransportador
            Else
                hf_id_pessoa.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Transportador não cadastrado.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = String.Empty
        hf_id_pessoa.Value = String.Empty
        cbo_motorista.Items.Clear()
        cbo_motorista.Enabled = False

        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_estabelecimento = cbo_estabelecimento.SelectedValue
                Dim dsprodutor As DataSet = produtor.getTransportadorByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                    loadMotoristaByTransportador(hf_id_pessoa.Value)

                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadMotoristaByTransportador(Optional ByVal id_transportador As Int32 = 0, Optional ByVal cd_transportador As String = "")

        Try

            cbo_motorista.Enabled = True

            Dim motorista As New Motorista
            If id_transportador > 0 Then
                motorista.id_pessoa = id_transportador
            End If
            If Not (cd_transportador.Equals(String.Empty)) Then
                motorista.cd_pessoa = cd_transportador
            End If
            motorista.id_situacao = 1 'fran 03/2017
            cbo_motorista.DataSource = motorista.getMotoristasByFilters()
            cbo_motorista.DataTextField = "nm_motorista"
            cbo_motorista.DataValueField = "id_motorista"
            cbo_motorista.DataBind()
            cbo_motorista.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadCompartimentosByPlaca(ByVal id_index_row As Int32, ByVal ds_placa As String)

        Try

            Dim cbo_compartimento As Anthem.DropDownList = CType(gridTransitPointCompartimento.Rows.Item(id_index_row).FindControl("cbo_compartimento"), Anthem.DropDownList)

            Dim txt_id_index As DataControlFieldCell = CType(gridTransitPointCompartimento.Rows.Item(id_index_row).Cells(6), DataControlFieldCell)

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

    Protected Sub gridTransitPointCompartimento_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridTransitPointCompartimento.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "delete"
                deleteTransitPointCompartimento(Convert.ToInt32(e.CommandArgument.ToString()))

            Case "Lupa"
                'Me.txt_placa.Text = ""

                carregarCamposVeiculo(Convert.ToInt32(e.CommandArgument.ToString()))
        End Select

    End Sub
    Private Sub deleteTransitPointCompartimento(ByVal id_index_row As Integer)

        Try

            gridTransitPointCompartimento.Rows(id_index_row).Visible = False
            'loadGridEscolaridade()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridTransitPointCompartimento_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridTransitPointCompartimento.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btnexcluir As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)
                Dim bt_lupa_veiculo As Anthem.ImageButton = CType(e.Row.FindControl("bt_lupa_veiculo"), Anthem.ImageButton)
                btnexcluir.CommandArgument = e.Row.RowIndex.ToString
                bt_lupa_veiculo.CommandArgument = e.Row.RowIndex.ToString
                With bt_lupa_veiculo
                    .Attributes.Add("onclick", "javascript:ShowDialog()")
                    .ToolTip = "Filtrar Veículos"
                    '.Style("cursor") = "hand"
                End With
                If ViewState.Item("incluirlinha") = "S" Then
                    Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
                    If Not (dr Is Nothing) Then
                        If Not (dr.Item(0).ToString.Equals(String.Empty)) Then
                            Dim cbo_compartimento As Anthem.DropDownList = CType(e.Row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                            cbo_compartimento.Enabled = True
                            Dim compartimento As New Compartimento
                            compartimento.ds_placa = dr.Item(0).ToString
                            compartimento.id_situacao = 1
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

    Protected Sub gridTransitPointCompartimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridTransitPointCompartimento.RowDataBound
        If (e.Row.RowType = DataControlRowType.DataRow) And ViewState.Item("incluirlinha") = "S" Then
            Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
            If Not (dr Is Nothing) Then
                Dim txt_placa As Anthem.TextBox = CType(e.Row.FindControl("txt_placa"), Anthem.TextBox)
                Dim check As Anthem.CheckBox = CType(e.Row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)
                Dim cbo_compartimento As Anthem.DropDownList = CType(e.Row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                Dim txt_volcomp As DataControlFieldCell = CType(e.Row.Cells(3), DataControlFieldCell)
                Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_id_index As DataControlFieldCell = CType(e.Row.Cells(6), DataControlFieldCell)
                Dim txt_id_compartimento As DataControlFieldCell = CType(e.Row.Cells(7), DataControlFieldCell)
                Dim lbl_id_veiculo As Label = CType(e.Row.FindControl("lbl_id_veiculo"), Label)

                txt_placa.Text = dr.Item(0).ToString
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
                lbl_id_veiculo.Text = dr.Item(7).ToString
            End If
        End If

    End Sub

    Protected Sub gridTransitPointCompartimento_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridTransitPointCompartimento.RowDeleting
        e.Cancel = True

    End Sub
    Private Sub loadCombosbyEstabelecimento(ByVal id_estabelecimento As Int32)

        Try

            cbo_transit_point_unidade.Enabled = True

            Dim transit As New TransitPointUnidade
            transit.id_estabelecimento = id_estabelecimento
            transit.id_situacao = 1 'ativo

            cbo_transit_point_unidade.DataSource = transit.getTransitPointUnidadeByFilters()
            cbo_transit_point_unidade.DataTextField = "ds_transit_point_unidade"
            cbo_transit_point_unidade.DataValueField = "id_transit_point_unidade"
            cbo_transit_point_unidade.DataBind()
            cbo_transit_point_unidade.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_transit_point_unidade.SelectedValue = 0

            cbo_rotas.Enabled = True
            Dim linha As New Linha
            linha.id_estabelecimento = id_estabelecimento
            cbo_rotas.DataSource = linha.getLinhaByTransitPoint()
            cbo_rotas.DataTextField = "nm_linha"
            cbo_rotas.DataValueField = "id_linha"
            cbo_rotas.DataBind()
            cbo_rotas.Items.Insert(0, New ListItem("[Selecione]", String.Empty))



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub btn_novo_compartimento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_compartimento.Click
        Dim dstable As New DataTable
        Dim ilinha As Integer
        If ViewState.Item("gridLinhasAdicionadas") Is Nothing Then
            Dim rc As New Romaneio_Compartimento
            Dim ds As New DataSet
            rc.id_romaneio = -1
            ds = rc.getRomaneio_CompartimentoByFilters
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
            dstable.Columns.Add("id_veiculo")
            dstable.Columns.Add("id_transportador")

            Dim row As GridViewRow
            ilinha = 0
            For Each row In gridTransitPointCompartimento.Rows
                If row.Visible = True Then
                    Dim txt_placa As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
                    Dim check As Anthem.CheckBox = CType(row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)
                    Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                    Dim txt_volcomp As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)
                    Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                    Dim txt_id_index As DataControlFieldCell = CType(row.Cells(6), DataControlFieldCell)
                    Dim txt_id_compartimento As DataControlFieldCell = CType(row.Cells(7), DataControlFieldCell)
                    Dim lbl_id_veiculo As Label = CType(row.FindControl("lbl_id_veiculo"), Label)
                    Dim lbl_id_transportador As Label = CType(row.FindControl("lbl_id_transportador"), Label)

                    dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
                    With dstable.Rows.Item(ilinha)
                        .Item(0) = txt_placa.Text
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
                        .Item(7) = lbl_id_veiculo.Text
                        .Item(8) = lbl_id_transportador.Text
                    End With
                    ilinha = ilinha + 1
                End If
            Next

            ViewState.Item("gridtable") = dstable

        End If

        dstable.Rows.InsertAt(dstable.NewRow(), ilinha)
        gridTransitPointCompartimento.Visible = True
        gridTransitPointCompartimento.DataSource = Helper.getDataView(dstable, ViewState.Item("sortExpression"))

        gridTransitPointCompartimento.DataBind()

        ViewState.Item("incluirlinha") = "N"

    End Sub

    Protected Sub txt_placa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtplaca As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
        Dim txtvolmaxcomp As DataControlFieldCell = CType(row.Cells.Item(3), DataControlFieldCell)
        Dim lbl_id_veiculo As Label = CType(row.FindControl("lbl_id_veiculo"), Label)

        txtvolmaxcomp.Text = String.Empty
        cbo_compartimento.Items.Clear()
        cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        cbo_compartimento.Enabled = False
        lbl_id_veiculo.Text = String.Empty
        If Not txtplaca.Text.Equals(String.Empty) Then
            Dim veiculo As New Veiculo
            veiculo.ds_placa = txtplaca.Text.Trim.ToString
            Dim dsveiculo As DataSet = veiculo.getVeiculoByFilters()
            If dsveiculo.Tables(0).Rows.Count > 0 Then
                lbl_id_veiculo.Text = dsveiculo.Tables(0).Rows(0).Item("id_veiculo")
                loadCompartimentosByPlaca(row.RowIndex, txtplaca.Text.Trim.ToString)
            End If

        End If

    End Sub

    Protected Sub cbo_compartimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)

        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
        Dim txtvolmaxcomp As DataControlFieldCell = CType(row.Cells.Item(3), DataControlFieldCell)

        Dim compartimento As New Compartimento(Convert.ToInt32(cbo_compartimento.SelectedValue))
        Dim ds As DataSet = compartimento.getCompartimentoByFilters()

        txtvolmaxcomp.Text = ds.Tables(0).Rows(0).Item("nr_volume")

    End Sub

    Protected Sub cbo_motorista_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_motorista.SelectedIndexChanged

        If cbo_motorista.SelectedValue > 0 Then
            Dim motorista As New Motorista(cbo_motorista.SelectedValue)
            lbl_cd_cnh.Text = motorista.cd_cnh
        Else
            lbl_cd_cnh.Text = String.Empty

        End If

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
            For Each row In gridTransitPointCompartimento.Rows
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
End Class

