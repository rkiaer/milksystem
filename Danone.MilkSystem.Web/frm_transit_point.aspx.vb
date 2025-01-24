Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class frm_transit_point
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_transit_point.aspx")
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
        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportadores"
        End With
        With bt_lupa_veiculo
            .Attributes.Add("onclick", "javascript:ShowDialogVeiculo()")
            .ToolTip = "Filtrar Veículos"
            '.Style("cursor") = "hand"
        End With

    End Sub

    Private Sub loadDetails()

        Try


            If Not (Request("id_transit_point") Is Nothing) Then
                ViewState.Item("id_transit_point") = Request("id_transit_point")

                Dim transitpoint As New TransitPoint(ViewState.Item("id_transit_point"))

                ViewState.Item("id_estabelecimento") = transitpoint.id_estabelecimento

                Dim linha As New Linha
                linha.id_estabelecimento = transitpoint.id_estabelecimento
                cbo_rotas.DataSource = linha.getLinhaByTransitPoint()
                cbo_rotas.DataTextField = "nm_linha"
                cbo_rotas.DataValueField = "id_linha"
                cbo_rotas.DataBind()
                cbo_rotas.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

                Dim item As New Item
                cbo_id_item.DataSource = item.getItensByFilters()
                cbo_id_item.DataTextField = "nm_item"
                cbo_id_item.DataValueField = "id_item"
                cbo_id_item.DataBind()
                cbo_id_item.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

                loadMotoristaByTransportador(transitpoint.id_transportador, "")

                loadData()
            Else
                messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadData()

        Try

            Dim transitpoint As New TransitPoint(Convert.ToInt32(ViewState.Item("id_transit_point")))

            lbl_ds_estabelecimento.Text = transitpoint.ds_estabelecimento.ToString
            lbl_ds_unidade_transit_point.Text = transitpoint.ds_transit_point_unidade
            txt_cd_transportador.Text = transitpoint.cd_transportador
            lbl_nm_transportador.Text = transitpoint.nm_transportador
            hf_id_transportador.Value = transitpoint.id_transportador
            lbl_transit_point.Text = transitpoint.id_transit_point
            lbl_nm_situacao_transit_point.Text = transitpoint.nm_situacao_transit_point

            cbo_motorista.SelectedValue = transitpoint.id_motorista
            lbl_cd_cnh.Text = transitpoint.cd_cnh

            cbo_rotas.SelectedValue = transitpoint.id_linha
            cbo_id_item.SelectedValue = transitpoint.id_item
            If transitpoint.nr_total_litros > 0 Then
                lbl_nr_total_litros_transit_point.Text = FormatNumber(transitpoint.nr_total_litros, 0)
            End If

            loadGridTransitPointCompartimentos()
            loadGridTransitPointUProducao()

            'fran 06/2021
            Dim dsamostras As DataSet = transitpoint.getTransitPointAmostras

            'se tem amostras no transit pont
            If (dsamostras.Tables(0).Rows.Count > 0) Then
                gridAmostras.Visible = True

                If dsamostras.Tables(0).Rows(0).Item("id_tipo_frasco1") = 0 Then
                    gridAmostras.Columns.Item(5).Visible = False 'frasco amarelo
                Else
                    gridAmostras.Columns.Item(5).Visible = True 'frasco amarelo
                End If
                If dsamostras.Tables(0).Rows(0).Item("id_tipo_frasco2") = 0 Then
                    gridAmostras.Columns.Item(6).Visible = False 'frasco azul
                Else
                    gridAmostras.Columns.Item(6).Visible = True 'frasco azul
                End If
                If dsamostras.Tables(0).Rows(0).Item("id_tipo_frasco3") = 0 Then
                    gridAmostras.Columns.Item(7).Visible = False 'frasco branco
                Else
                    gridAmostras.Columns.Item(7).Visible = True 'frasco branco
                End If
                If dsamostras.Tables(0).Rows(0).Item("id_tipo_frasco4") = 0 Then
                    gridAmostras.Columns.Item(8).Visible = False 'frasco vermelho
                Else
                    gridAmostras.Columns.Item(8).Visible = True 'frasco verelho
                End If

                gridAmostras.DataSource = Helper.getDataView(dsamostras.Tables(0), "")
                gridAmostras.DataBind()
            Else
                Dim dr As DataRow = dsamostras.Tables(0).NewRow()
                dsamostras.Tables(0).Rows.InsertAt(dr, 0)
                gridAmostras.Visible = True
                gridAmostras.DataSource = Helper.getDataView(dsamostras.Tables(0), "")
                gridAmostras.DataBind()
                gridAmostras.Rows(0).Cells.Clear()
                gridAmostras.Rows(0).Cells.Add(New TableCell())
                gridAmostras.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridAmostras.Rows(0).Cells(0).Text = "Não existem amostras para os Pré-Romaneios deste Transit Point."
                gridAmostras.Rows(0).Cells(0).ColumnSpan = 13
            End If


            If transitpoint.id_situacao_transit_point = 3 Then 'situacao fechado
                gridTransitPointCompartimento.Columns(6).Visible = False
                btn_novo_compartimento.Enabled = False
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub updateData()
        If Page.IsValid Then


            Try

                Dim transitpoint As New TransitPoint()

                transitpoint.id_transit_point = ViewState.Item("id_transit_point")


                Dim lpos As Integer
                transitpoint.id_linha = cbo_rotas.SelectedValue
                lpos = InStr(cbo_motorista.SelectedValue, "&")
                transitpoint.id_motorista = Left(cbo_motorista.SelectedValue, lpos - 1).Trim
                transitpoint.id_transportador = Convert.ToInt32(hf_id_transportador.Value)
                transitpoint.id_item = Convert.ToInt32(cbo_id_item.SelectedValue)
                transitpoint.id_modificador = Session("id_login")
                transitpoint.updateTransitPoint()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Private Sub carregarCamposVeiculo(ByVal id_index_row As Integer)

        Try
            Dim txt_ds_placa As Anthem.TextBox = CType(gridTransitPointCompartimento.Rows.Item(id_index_row).FindControl("txt_placa"), Anthem.TextBox)
            Dim lbl_id_veiculo As Label = CType(gridTransitPointCompartimento.Rows.Item(id_index_row).FindControl("lbl_id_veiculo"), Label)
            txt_ds_placa.Text = ""
            lbl_id_veiculo.Text = String.Empty
            If Not (customPage.getFilterValue("lupa_veiculo", "ds_placa").Equals(String.Empty)) Then
                txt_ds_placa.Text = customPage.getFilterValue("lupa_veiculo", "ds_placa").ToString
                lbl_id_veiculo.Text = customPage.getFilterValue("lupa_veiculo", "id_veiculo").ToString
                loadCompartimentosByPlaca(txt_ds_placa.Text)
            End If

            'loadData()
            customPage.clearFilters("lupa_veiculo")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposTransportador()

        Try
            'fran 08/01/2011 i gko rls 27
            If Not (customPage.getFilterValue("lupa_transportador", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transportador", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transportador", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transportador", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_transportador")

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidtransportador As Int32
            If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_transportador.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_transportador.Text.Trim
            lidtransportador = pessoa.validarTransportador


            If lidtransportador > 0 Then
                args.IsValid = True
                hf_id_transportador.Value = lidtransportador
            Else
                hf_id_transportador.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Transportador não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_transit_point.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_transit_point.aspx")

    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub
    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged

        lbl_nm_transportador.Text = String.Empty
        hf_id_transportador.Value = String.Empty
        cbo_motorista.Items.Clear()
        cbo_motorista.Enabled = False

        Try
            If Not txt_cd_transportador.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_transportador.Text.Trim
                'produtor.id_estabelecimento = cbo_estabelecimento.SelectedValue
                Dim dsprodutor As DataSet = produtor.getTransportadorByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_transportador.Enabled = True
                    lbl_nm_transportador.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_transportador.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                    loadMotoristaByTransportador(hf_id_transportador.Value)

                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_transportador_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_transportador.Click
        'If Not (Me.cbo_estabelecimento.SelectedValue.ToString.Equals(String.Empty)) Then
        If Not (Me.hf_id_transportador.Value.Trim.Equals(String.Empty)) Then
            'A´pós retornar da modal, carrega os campos
            carregarCamposTransportador()
            loadMotoristaByTransportador(Convert.ToInt32(hf_id_transportador.Value))
        Else
            txt_cd_transportador.Text = String.Empty
            hf_id_transportador.Value = String.Empty
            lbl_nm_transportador.Text = String.Empty
            cbo_motorista.Items.Clear()
            cbo_motorista.Enabled = False
        End If
        'End If

    End Sub

    Protected Sub btn_novo_compartimento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_compartimento.Click
        If Page.IsValid Then

            Try
                Dim tpveiculo As New TransitPointVeiculo
                Dim tpcompartimento As New TransitPointCompartimento

                tpveiculo.id_transit_point = ViewState.Item("id_transit_point").ToString
                tpveiculo.id_veiculo = hf_id_veiculo.Value

                Dim dsveiculo As DataSet = tpveiculo.getTransitPointVeiculoByFilters
                'se encontrou a placa
                If dsveiculo.Tables(0).Rows.Count > 0 Then
                    tpcompartimento.id_transit_point_veiculo = dsveiculo.Tables(0).Rows(0).Item("id_transit_point_veiculo")
                Else
                    'se nao encontrou, cria a placa
                    tpveiculo.st_principal = "N"
                    tpveiculo.id_modificador = Session("id_login")
                    tpcompartimento.id_transit_point_veiculo = tpveiculo.insertTransitPointVeiculo()
                End If

                'Criar Compartimento
                tpcompartimento.id_transit_point = tpveiculo.id_transit_point
                tpcompartimento.id_compartimento = cbo_compartimento.SelectedValue
                tpcompartimento.id_modificador = Session("id_login")

                tpcompartimento.insertTransitPointCompartimento()

                txt_placa.Text = String.Empty
                hf_id_veiculo.Value = String.Empty
                cbo_compartimento.Items.Clear()

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)

            End Try

        End If
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
            cbo_motorista.DataSource = motorista.getMotoristasByFilters()
            cbo_motorista.DataTextField = "nm_motorista"
            cbo_motorista.DataValueField = "id_motorista"
            cbo_motorista.DataBind()
            cbo_motorista.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub deleteTransitPointCompartimento(ByVal id_index_row As Integer)

        Try

            'gridTransitPointCompartimento.Rows(id_index_row).Visible = False
            'loadGridEscolaridade()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    'Protected Sub gridRomaneioCompartimento_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridTransitPointCompartimento.RowCreated
    '    If (e.Row.RowType = DataControlRowType.DataRow) Then
    '        Try
    '            Dim btnexcluir As ImageButton = CType(e.Row.FindControl("img_delete"), ImageButton)
    '            Dim bt_lupa_veiculo As Anthem.ImageButton = CType(e.Row.FindControl("bt_lupa_veiculo"), Anthem.ImageButton)
    '            btnexcluir.CommandArgument = e.Row.RowIndex.ToString
    '            bt_lupa_veiculo.CommandArgument = e.Row.RowIndex.ToString
    '            With bt_lupa_veiculo
    '                .Attributes.Add("onclick", "javascript:ShowDialog()")
    '                .ToolTip = "Filtrar Veículos"
    '                '.Style("cursor") = "hand"
    '            End With
    '            If ViewState.Item("incluirlinha") = "S" Then
    '                Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
    '                If Not (dr Is Nothing) Then
    '                    If Not (dr.Item(0).ToString.Equals(String.Empty)) Then
    '                        Dim cbo_compartimento As Anthem.DropDownList = CType(e.Row.FindControl("cbo_compartimento"), Anthem.DropDownList)
    '                        cbo_compartimento.Enabled = True
    '                        Dim compartimento As New Compartimento
    '                        compartimento.ds_placa = dr.Item(0).ToString
    '                        cbo_compartimento.DataSource = compartimento.getCompartimentoByFilters()
    '                        cbo_compartimento.DataTextField = "ds_compartimento"
    '                        cbo_compartimento.DataValueField = "id_compartimento"
    '                        cbo_compartimento.DataBind()
    '                        cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
    '                    End If
    '                End If
    '            End If
    '        Catch ex As Exception
    '            messageControl.Alert(ex.Message)
    '        End Try

    '    End If


    'End Sub


    Protected Sub txt_placa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_placa.TextChanged


        cbo_compartimento.Items.Clear()
        cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        cbo_compartimento.Enabled = False
        hf_id_veiculo.Value = String.Empty
        If Not txt_placa.Text.Equals(String.Empty) Then
            Dim veiculo As New Veiculo
            veiculo.ds_placa = txt_placa.Text.Trim.ToString
            Dim dsveiculo As DataSet = veiculo.getVeiculoByFilters()
            If dsveiculo.Tables(0).Rows.Count > 0 Then
                hf_id_veiculo.Value = dsveiculo.Tables(0).Rows(0).Item("id_veiculo")
                loadCompartimentosByPlaca(txt_placa.Text.Trim.ToString)
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

    'Protected Sub gridRomaneioCompartimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridTransitPointCompartimento.RowDataBound
    '    If (e.Row.RowType = DataControlRowType.DataRow) And ViewState.Item("incluirlinha") = "S" Then
    '        Dim dr As DataRow = CType(ViewState.Item("gridtable"), DataTable).Rows.Item(e.Row.RowIndex)
    '        If Not (dr Is Nothing) Then
    '            Dim txt_placa As Anthem.TextBox = CType(e.Row.FindControl("txt_placa"), Anthem.TextBox)
    '            Dim check As Anthem.CheckBox = CType(e.Row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)
    '            Dim cbo_compartimento As Anthem.DropDownList = CType(e.Row.FindControl("cbo_compartimento"), Anthem.DropDownList)
    '            Dim txt_volcomp As DataControlFieldCell = CType(e.Row.Cells(3), DataControlFieldCell)
    '            Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(e.Row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
    '            Dim txt_id_index As DataControlFieldCell = CType(e.Row.Cells(6), DataControlFieldCell)
    '            Dim txt_id_compartimento As DataControlFieldCell = CType(e.Row.Cells(7), DataControlFieldCell)
    '            Dim lbl_id_veiculo As Label = CType(e.Row.FindControl("lbl_id_veiculo"), Label)

    '            txt_placa.Text = dr.Item(0).ToString
    '            If dr.Item(2).ToString.Equals(String.Empty) Then
    '                If Not (dr.Item(0).ToString.Equals(String.Empty)) Then
    '                    cbo_compartimento.Enabled = True
    '                    cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
    '                Else
    '                    cbo_compartimento.Enabled = False
    '                End If
    '            Else
    '                cbo_compartimento.Enabled = True
    '                cbo_compartimento.SelectedValue = dr.Item(2).ToString
    '            End If
    '            If dr.Item(1).ToString = "S" Then
    '                check.Checked = True
    '            Else
    '                check.Checked = False
    '            End If

    '            txt_volcomp.Text = dr.Item(3).ToString
    '            txt_nr_total_litros.Text = dr.Item(4).ToString
    '            txt_id_index.Text = dr.Item(5).ToString
    '            txt_id_compartimento.Text = dr.Item(6).ToString
    '            lbl_id_veiculo.Text = dr.Item(7).ToString
    '        End If
    '    End If
    'End Sub

    'Protected Sub gridRomaneioCompartimento_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridTransitPointCompartimento.RowDeleting
    '    e.Cancel = True

    'End Sub

    Protected Sub cbo_motorista_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_motorista.SelectedIndexChanged
        Dim lpos As Integer

        'Guarda no value do compartimento o id e o volume max do compartimento
        lpos = InStr(cbo_motorista.SelectedValue, "&")
        lbl_cd_cnh.Visible = True
        lbl_cnh.Visible = True
        lbl_cd_cnh.Text = Mid(cbo_motorista.SelectedValue, lpos + 1).Trim

    End Sub

    Protected Sub cmv_placa_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_placa.ServerValidate
        Try
            Dim veiculo As New Veiculo()

            veiculo.ds_placa = txt_placa.Text
            args.IsValid = veiculo.validarPlaca()
            If Not args.IsValid Then
                messageControl.Alert("Placa não cadastrada.")
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

    Protected Sub cv_transitpointsalvar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transitpointsalvar.ServerValidate
        Try

            Dim transitpoint As New TransitPoint
            Dim lmsg As String
            Dim lnrplacaprincipal As Int32

            args.IsValid = True

            transitpoint.id_transit_point = ViewState.Item("id_transit_point")
            lnrplacaprincipal = transitpoint.getTransitPointConsPlacasPrincipal

            If lnrplacaprincipal = 0 Then
                args.IsValid = False
                lmsg = "Uma Placa Principal deve ser informada para o Transit Point."
            Else
                If lnrplacaprincipal > 1 Then
                    args.IsValid = False
                    lmsg = "Apenas uma Placa Principal pode ser informada para o Transit Point."
                End If
            End If

            If transitpoint.getTransitPointConsPlacasTransportador > 1 Then
                args.IsValid = False
                lmsg = "Foram selecionadas placas para o TRANSIT POINT de transportadores diferentes. O Transit Point deve ter apenas um transportador."
            End If

            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Private Sub loadCombosbyEstabelecimento(ByVal id_estabelecimento As Int32)

        Try

            'cbo_transit_point_unidade.Enabled = True

            'Dim transit As New TransitPointUnidade
            'transit.id_estabelecimento = id_estabelecimento
            'transit.id_situacao = 1 'ativo

            'cbo_transit_point_unidade.DataSource = transit.getTransitPointUnidadeByFilters()
            'cbo_transit_point_unidade.DataTextField = "ds_transit_point_unidade"
            'cbo_transit_point_unidade.DataValueField = "id_transit_point_unidade"
            'cbo_transit_point_unidade.DataBind()
            'cbo_transit_point_unidade.Items.Insert(0, New ListItem("[Selecione]", "0"))
            'cbo_transit_point_unidade.SelectedValue = 0

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

    Protected Sub lk_transitpont_preromaneio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_transitpont_preromaneio.Click
        Try

            Response.Redirect("frm_transit_point_pre_romaneio.aspx?id_transit_point=" + ViewState.Item("id_transit_point"))

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub
    Private Sub loadGridTransitPointCompartimentos()


        Dim tpcomp As New TransitPointCompartimento

        txt_placa.Text = String.Empty
        hf_id_veiculo.Value = String.Empty
        cbo_compartimento.Items.Clear()

        tpcomp.id_transit_point = ViewState.Item("id_transit_point").ToString
        Dim dstpcompartimento As DataSet = tpcomp.getTransitPointCompartimentoByFilters()

        'se tem linhas em compartimento
        If (dstpcompartimento.Tables(0).Rows.Count > 0) Then
            gridTransitPointCompartimento.Visible = True
            gridTransitPointCompartimento.DataSource = Helper.getDataView(dstpcompartimento.Tables(0), "")
            gridTransitPointCompartimento.DataBind()
            ViewState.Item("gridLinhasAdicionadas") = "S"
        Else
            Dim dr As DataRow = dstpcompartimento.Tables(0).NewRow()
            dstpcompartimento.Tables(0).Rows.InsertAt(dr, 0)
            gridTransitPointCompartimento.Visible = True
            gridTransitPointCompartimento.DataSource = Helper.getDataView(dstpcompartimento.Tables(0), "")
            gridTransitPointCompartimento.DataBind()
            gridTransitPointCompartimento.Rows(0).Cells.Clear()
            gridTransitPointCompartimento.Rows(0).Cells.Add(New TableCell())
            gridTransitPointCompartimento.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            gridTransitPointCompartimento.Rows(0).Cells(0).Text = "Não existe nenhum compartimento informado para o Transit Point!"
            gridTransitPointCompartimento.Rows(0).Cells(0).ColumnSpan = 10
            ViewState.Item("gridLinhasAdicionadas") = Nothing

        End If

    End Sub
    Private Sub loadGridTransitPointUProducao()
        Try

            If ViewState.Item("id_transit_point_compartimento") Is Nothing Then
                ViewState.Item("id_transit_point_compartimento") = 0
            End If

            Dim tpup As New TransitPointUProducao
            If CLng(ViewState.Item("id_transit_point_compartimento")) > 0 Then
                tpup.id_transit_point_compartimento = Convert.ToInt32(ViewState.Item("id_transit_point_compartimento"))
                lbl_detalhe_placa.Text = ViewState.Item("lbl_detalhe_placa").ToString
                lbl_detalhe_compartimento.Text = ViewState.Item("lbl_detalhe_compartimento").ToString
                tpup.id_transit_point = ViewState.Item("id_transit_point").ToString
                Dim dstpup As DataSet = tpup.getTransitPointUPByFilters()

                'se tem linhas em compartimento
                If (dstpup.Tables(0).Rows.Count > 0) Then
                    grdColetas.Visible = True
                    grdColetas.DataSource = Helper.getDataView(dstpup.Tables(0), "")
                    grdColetas.DataBind()
                Else
                    Dim dr As DataRow = dstpup.Tables(0).NewRow()
                    dstpup.Tables(0).Rows.InsertAt(dr, 0)
                    grdColetas.Visible = True
                    grdColetas.DataSource = Helper.getDataView(dstpup.Tables(0), "")
                    grdColetas.DataBind()
                    grdColetas.Rows(0).Cells.Clear()
                    grdColetas.Rows(0).Cells.Add(New TableCell())
                    grdColetas.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    grdColetas.Rows(0).Cells(0).Text = "Não existe nenhuma coleta selecionada para o Transit Point!"
                    grdColetas.Rows(0).Cells(0).ColumnSpan = 12
                End If
            Else
                tpup.id_transit_point_compartimento = -1
                tpup.id_transit_point = ViewState.Item("id_transit_point").ToString
                Dim dstpup As DataSet = tpup.getTransitPointUPByFilters()

                Dim dr As DataRow = dstpup.Tables(0).NewRow()
                dstpup.Tables(0).Rows.InsertAt(dr, 0)
                grdColetas.Visible = True
                grdColetas.DataSource = Helper.getDataView(dstpup.Tables(0), "")
                grdColetas.DataBind()
                grdColetas.Rows(0).Cells.Clear()
                grdColetas.Rows(0).Cells.Add(New TableCell())
                grdColetas.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdColetas.Rows(0).Cells(0).Text = "Selecione um compartimento para visualizar as coletas!"
                grdColetas.Rows(0).Cells(0).ColumnSpan = 12


            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try


    End Sub

    Protected Sub bt_lupa_veiculo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_veiculo.Click
        carregarCamposVeiculo()

    End Sub
    Private Sub carregarCamposVeiculo()

        Try
            txt_placa.Text = ""
            hf_id_veiculo.Value = String.Empty

            If Not (customPage.getFilterValue("lupa_veiculo", "ds_placa").Equals(String.Empty)) Then
                Me.txt_placa.Text = customPage.getFilterValue("lupa_veiculo", "ds_placa").ToString
                Me.hf_id_veiculo.Value = customPage.getFilterValue("lupa_veiculo", "id_veiculo").ToString
                loadCompartimentosByPlaca(txt_placa.Text)
            End If

            'loadData()
            customPage.clearFilters("lupa_veiculo")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadCompartimentosByPlaca(ByVal ds_placa As String)

        Try


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

    Protected Sub cv_tpcompartimento_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_tpcompartimento.ServerValidate
        Try

            Dim lmsg As String = String.Empty
            Dim tpcomp As New TransitPointCompartimento


            tpcomp.id_compartimento = cbo_compartimento.SelectedValue
            Dim dstpcomp As DataSet = tpcomp.getTransitPointCompartimentoByFilters

            args.IsValid = True

            'se tem linhas
            If dstpcomp.Tables(0).Rows.Count > 0 Then
                args.IsValid = False
                lmsg = "O compartimento selecionado para inclusão no Transit Point já existe no cadastro."
            End If


            If args.IsValid = False > 0 Then
                messageControl.Alert(lmsg)
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridTransitPointCompartimento_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridTransitPointCompartimento.PageIndexChanging
        gridTransitPointCompartimento.PageIndex = e.NewPageIndex
        loadGridTransitPointCompartimentos()

    End Sub

    Protected Sub gridTransitPointCompartimento_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridTransitPointCompartimento.RowCancelingEdit
        Try

            gridTransitPointCompartimento.EditIndex = -1
            loadGridTransitPointCompartimentos()
            loadGridTransitPointUProducao()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridTransitPointCompartimento_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridTransitPointCompartimento.RowCommand
        Try

            Select Case e.CommandName.ToString().ToLower()
                Case "compcoletas"
                    If gridTransitPointCompartimento.EditIndex = -1 Then
                        Dim lbl_id_transit_point_compartimento As Label = CType(gridTransitPointCompartimento.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_transit_point_compartimento"), Label)
                        Dim lbl_ds_placa As Label = CType(gridTransitPointCompartimento.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_ds_placa"), Label)
                        Dim ds_compartimento As DataControlFieldCell = CType(gridTransitPointCompartimento.Rows.Item(e.CommandArgument.ToString).Cells(3), DataControlFieldCell)

                        ViewState.Item("id_transit_point_compartimento") = lbl_id_transit_point_compartimento.Text
                        ViewState.Item("lbl_detalhe_placa") = lbl_ds_placa.Text
                        ViewState.Item("lbl_detalhe_compartimento") = ds_compartimento.Text

                        loadData()
                    End If
                Case "delete"
                    Dim lbl_id_transit_point_compartimento As Label = CType(gridTransitPointCompartimento.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_transit_point_compartimento"), Label)
                    Dim lbl_id_transit_point_veiculo As Label = CType(gridTransitPointCompartimento.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_transit_point_veiculo"), Label)

                    'verifica se pode deletar a romaneio compartimento
                    Dim transitpointup As New TransitPointUProducao
                    transitpointup.id_transit_point_compartimento = lbl_id_transit_point_compartimento.Text
                    If transitpointup.getTransitPointUPByFilters.Tables(0).Rows.Count = 0 Then

                        deleteCompartimento(Convert.ToInt32(lbl_id_transit_point_compartimento.Text), Convert.ToInt32(lbl_id_transit_point_veiculo.Text))

                    Else
                        messageControl.Alert("O compartimento não pode ser excluído pois possui volume de leite cadastrado.")
                    End If

            End Select
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub deleteCompartimento(ByVal id_transit_point_compartimento As Integer, ByVal id_transit_point_veiculo As Integer)

        Try

            Dim transitpointcomp As New TransitPointCompartimento
            Dim lqtde As Integer

            transitpointcomp.id_transit_point_veiculo = id_transit_point_veiculo
            lqtde = transitpointcomp.getTransitPointConsQtdeCompartimentobyVeiculo

            transitpointcomp.id_transit_point_compartimento = id_transit_point_compartimento
            transitpointcomp.deleteTransitPointCompartimento()

            'se para o veiculo existir mais de 1 compartimento, apenas exclui compartimento. Se tiver apenas 1, exclui comp e veiculo
            If lqtde <= 1 Then
                'exclui veiculo
                Dim transitpointveiculo As New TransitPointVeiculo
                transitpointveiculo.id_transit_point_veiculo = id_transit_point_veiculo
                transitpointveiculo.deleteTransitPointVeiculo()
            End If

            messageControl.Alert("Registro excluído com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
 
    Protected Sub gridTransitPointCompartimento_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridTransitPointCompartimento.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btn_detalhe_item As ImageButton = CType(e.Row.FindControl("btn_detalhe_item"), ImageButton)
                btn_detalhe_item.CommandArgument = e.Row.RowIndex.ToString
                Dim btn_delete As ImageButton = CType(e.Row.FindControl("btn_delete"), ImageButton)
                btn_delete.CommandArgument = e.Row.RowIndex.ToString
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub

    Protected Sub gridTransitPointCompartimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridTransitPointCompartimento.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

            Else
                If e.Row.RowType = DataControlRowType.DataRow Then

                    Try
                        Dim lbl_st_principal As Label = CType(e.Row.FindControl("lbl_st_principal"), Label)
                        Dim img_check As Anthem.Image = CType(e.Row.FindControl("img_check"), Anthem.Image)

                        If lbl_st_principal.Text.Trim.Equals("S") Then
                            img_check.ImageUrl = "~/img/ico_chk_true.gif"
                        Else
                            img_check.ImageUrl = "~/img/ico_chk_false.gif"
                        End If

                    Catch ex As Exception
                        messageControl.Alert(ex.Message)
                    End Try

                End If
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then

                If (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

                    Dim lbl_st_principal As Label = CType(e.Row.FindControl("lbl_st_principal"), Label)
                    Dim chk_st_principal As Anthem.CheckBox = CType(e.Row.FindControl("chk_st_principal"), Anthem.CheckBox)
                    Dim lbl_id_transit_point_compartimento As Label = CType(e.Row.FindControl("lbl_id_transit_point_compartimento"), Label)

                    If lbl_st_principal.Text.Trim.Equals("S") Then
                        chk_st_principal.Checked = True
                    Else
                        chk_st_principal.Checked = False
                    End If

                    If (Not lbl_id_transit_point_compartimento.Text.Equals(String.Empty)) AndAlso CLng(lbl_id_transit_point_compartimento.Text) = CLng(ViewState.Item("id_transit_point_compartimento")) Then
                        e.Row.ForeColor = Drawing.Color.Red
                        'lbl_id_propriedade_titular.ForeColor = Drawing.Color.Red 'fran 25/08/2015
                    Else
                        e.Row.ForeColor = System.Drawing.Color.FromName("#333333")
                    End If
                Else
                    Dim lbl_st_principal As Label = CType(e.Row.FindControl("lbl_st_principal"), Label)
                    Dim img_check As Anthem.Image = CType(e.Row.FindControl("img_check"), Anthem.Image)
                    Dim lbl_id_transit_point_compartimento As Label = CType(e.Row.FindControl("lbl_id_transit_point_compartimento"), Label)

                    If (Not lbl_id_transit_point_compartimento.Text.Equals(String.Empty)) AndAlso CLng(lbl_id_transit_point_compartimento.Text) = CLng(ViewState.Item("id_transit_point_compartimento")) Then
                        e.Row.ForeColor = Drawing.Color.Red
                        ' lbl_st_participa_poupanca.ForeColor = Drawing.Color.Red
                    Else
                        e.Row.ForeColor = System.Drawing.Color.FromName("#333333")
                        'lbl_st_participa_poupanca.ForeColor = System.Drawing.Color.FromName("#333333")
                    End If

                    ''se tempo de adesao é vazio
                    'If e.Row.Cells(3).Text.Trim.Equals(String.Empty) Or e.Row.Cells(3).Text.Trim.Equals("&nbsp;") Then
                    '    Dim btn_editar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)
                    '    btn_editar.Enabled = False
                    '    btn_editar.ImageUrl = "~/img/icone_editar_grid_desabilitado.gif"
                    '    btn_editar.ToolTip = "Não existe adesão à poupança."
                    'Else
                    '    Dim btn_editar As ImageButton = CType(e.Row.FindControl("btn_editar"), ImageButton)
                    '    btn_editar.Enabled = True
                    '    btn_editar.ImageUrl = "~/img/icone_editar_grid.gif"
                    '    btn_editar.ToolTip = String.Empty
                    'End If
                End If
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridTransitPointCompartimento_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridTransitPointCompartimento.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub gridTransitPointCompartimento_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridTransitPointCompartimento.RowEditing
        Try

            Dim lbl_id_transit_point_compartimento As Label = CType(gridTransitPointCompartimento.Rows(e.NewEditIndex).FindControl("lbl_id_transit_point_compartimento"), Label)
            Dim lbl_st_principal As Label = CType(gridTransitPointCompartimento.Rows.Item(e.NewEditIndex).FindControl("lbl_st_principal"), Label)
            Dim lbl_ds_placa As Label = CType(gridTransitPointCompartimento.Rows.Item(e.NewEditIndex).FindControl("lbl_ds_placa"), Label)
            Dim ds_compartimento As DataControlFieldCell = CType(gridTransitPointCompartimento.Rows.Item(e.NewEditIndex).Cells(3), DataControlFieldCell)

            ViewState.Item("id_transit_point_compartimento") = lbl_id_transit_point_compartimento.Text
            ViewState.Item("lbl_detalhe_placa") = lbl_ds_placa.Text
            ViewState.Item("lbl_detalhe_compartimento") = ds_compartimento.Text

            gridTransitPointCompartimento.EditIndex = e.NewEditIndex
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridTransitPointCompartimento_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridTransitPointCompartimento.RowUpdating
        Dim row As GridViewRow = gridTransitPointCompartimento.Rows(e.RowIndex)
        Try
            If Page.IsValid Then


                If (Not (row) Is Nothing) Then

                    Dim tpVeiculo As New TransitPointVeiculo

                    Dim chk_st_principal As Anthem.CheckBox = CType(row.FindControl("chk_st_principal"), Anthem.CheckBox)
                    Dim lbl_id_transit_point_veiculo As Label = CType(row.FindControl("lbl_id_transit_point_veiculo"), Label)
                    Dim lbl_ds_placa As Label = CType(row.FindControl("lbl_ds_placa"), Label)
                    Dim lbl_id_transit_point As Label = CType(row.FindControl("lbl_id_transit_point"), Label)

                    'atualizar transit point veiculo e tranit pont se for placa principal
                    If chk_st_principal.Checked = True Then
                        tpVeiculo.st_principal = "S"
                    Else
                        tpVeiculo.st_principal = "N"
                    End If
                    tpVeiculo.id_transit_point = lbl_id_transit_point.Text
                    tpVeiculo.id_transit_point_veiculo = lbl_id_transit_point_veiculo.Text
                    tpVeiculo.ds_placa = lbl_ds_placa.Text
                    tpVeiculo.id_modificador = Session("id_login")
                    tpVeiculo.updateTransitPointVeiculo()

                    gridTransitPointCompartimento.EditIndex = -1

                    loadData()

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_fechar_transit_point_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_fechar_transit_point.Click
        Try
            If Page.IsValid Then

                'consiste fechar transit point
                If consistirFecharTransitPoint() = True Then

                    Dim transitpoint As New TransitPoint
                    transitpoint.id_transit_point = ViewState.Item("id_transit_point")
                    transitpoint.id_modificador = Session("id_login")

                    transitpoint.updateTransitPointFechar()
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 6 'processo
                    usuariolog.id_menu_item = 167
                    usuariolog.ds_nm_processo = "Transit Point - Fechar"
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    loadData()

                End If

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub
    Private Function consistirFecharTransitPoint() As Boolean
        Try

            Dim transitpoint As New TransitPoint
            Dim lmsg As String
            Dim bisvalid As Boolean = True
            Dim lnrqtdeplacaprincipal As Int32
            Dim lnrqtdeCompSemVolume As Int32


            transitpoint.id_transit_point = ViewState.Item("id_transit_point")
            lnrqtdeplacaprincipal = transitpoint.getTransitPointConsPlacas
            lnrqtdeCompSemVolume = transitpoint.getTransitPointConsVolumeCompartimento

            If lnrqtdeplacaprincipal = 0 Then
                bisvalid = False
                lmsg = "Uma Placa Principal deve ser informada para o Transit Point."
            Else
                If lnrqtdeplacaprincipal > 1 Then
                    bisvalid = False
                    lmsg = "Apenas uma Placa Principal pode ser informada para o Transit Point."
                End If
            End If

            If lnrqtdeCompSemVolume > 0 Then
                bisvalid = False
                lmsg = "Para prosseguir com o fechamento do Transit Point, todas as placas/compartimentos adicionados no Transit Point devem ter volume de leite (coletas) informados."
            End If

            'fran 06/2021 i
            'Busca se tem amostras pendentes do tp
            If bisvalid = True AndAlso transitpoint.getTransitPointAmostrasSemRegistro.Tables(0).Rows.Count > 0 Then
                bisvalid = False
                lmsg = "Para prosseguir com o fechamento do Transit Point, o envio das Amostras das coletas devem ser registradas no link 'Envio das Amostras Pré_Romaneio'."
            End If
            'fran 06/2021 f



            If bisvalid = False Then
                consistirFecharTransitPoint = False
                messageControl.Alert(lmsg)
            Else
                consistirFecharTransitPoint = True
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Function


    Protected Sub lk_pre_romaneio_amostra_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_pre_romaneio_amostra.Click
        Try

            Response.Redirect("frm_transit_point_amostras.aspx?id_transit_point=" + ViewState.Item("id_transit_point"))

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub gridAmostras_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridAmostras.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_id_situacao_coleta_amostra As Label = CType(e.Row.FindControl("lbl_id_situacao_coleta_amostra"), Label)
            Dim lbl_id_situacao_tp_amostra As Label = CType(e.Row.FindControl("lbl_id_situacao_tp_amostra"), Label)
            Dim lbl_id_transit_point_registro As Label = CType(e.Row.FindControl("lbl_id_transit_point_registro"), Label)

            'se a situação da coleta amostra é realizada
            If lbl_id_situacao_coleta_amostra.Text.Trim.Equals("2") Then
                'se aq situacao do tp amostra é pendente
                If lbl_id_situacao_tp_amostra.Text.Trim.Equals("1") Then
                    e.Row.ForeColor = Drawing.Color.Red
                Else
                    '7983
                    'se aq situacao do tp amostra é prox tp
                    If lbl_id_situacao_tp_amostra.Text.Trim.Equals("4") Then
                        'se o registro foi feito por esse transit point
                        If CLng(lbl_id_transit_point_registro.Text) = CLng(ViewState.Item("id_transit_point").ToString) Then
                            e.Row.Cells(9).BackColor = Drawing.Color.LightYellow
                        Else
                            e.Row.Cells(9).Text = "Pendente" 'troca situação de prox tp para pendente
                            e.Row.ForeColor = Drawing.Color.Red
                        End If
                    Else
                        If lbl_id_situacao_tp_amostra.Text.Trim.Equals("2") Then ' enviada
                            e.Row.Cells(9).BackColor = Drawing.Color.Aquamarine
                        Else
                            e.Row.Cells(9).BackColor = System.Drawing.Color.FromName("#FF7983")

                        End If
                    End If
                End If

            Else
                'se a situação da coleta amostra é DESCARTADA e a situação do tp e pendente (significa que a amostra foi descartada no coletor)
                If lbl_id_situacao_tp_amostra.Text.Trim.Equals("3") Then 'descartada
                    e.Row.Cells(9).BackColor = System.Drawing.Color.FromName("#FF7983")
                End If
            End If


        End If


    End Sub
End Class
