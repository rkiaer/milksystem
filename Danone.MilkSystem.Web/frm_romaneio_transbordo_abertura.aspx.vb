Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math



Partial Class frm_romaneio_transbordo_abertura
    Inherits Page
    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_transbordo_abertura.aspx")

        If Not Page.IsPostBack Then
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
        With btn_lupa_transportador
            .Attributes.Add("onclick", "javascript:ShowDialogTransportador()")
            .ToolTip = "Filtrar Transportadores"
        End With

    End Sub

    Private Sub loadDetails()

        Try

            Dim llistacaderneta As String
            If Not (customPage.getFilterValue("romaneiotransbordo", "listacadernetas").Equals(String.Empty)) Then
                ViewState.Item("listacadernetas") = customPage.getFilterValue("romaneiotransbordo", "listacadernetas").ToString()
                customPage.clearFilters("romaneiotransbordo")

                llistacaderneta = Replace(ViewState.Item("listacadernetas").ToString, "''", "|")
                llistacaderneta = Replace(llistacaderneta, "'", "")

                Dim romaneio As New Romaneio
                romaneio.cadernetas = llistacaderneta
                lbl_soma_nr_peso_liquido_caderneta.Text = romaneio.getRomaneioSomaVolumebyCadernetas

                lbl_cadernetas.Text = Replace(llistacaderneta, "|", ", ")

                Dim estabel As New Estabelecimento

                cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
                cbo_estabelecimento.DataTextField = "nm_estabelecimento"
                cbo_estabelecimento.DataValueField = "id_estabelecimento"
                cbo_estabelecimento.DataBind()
                cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

                Dim item As New Item
                cbo_id_item.DataSource = item.getItensByFilters()
                cbo_id_item.DataTextField = "nm_item"
                cbo_id_item.DataValueField = "id_item"
                cbo_id_item.DataBind()
                cbo_id_item.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

                Dim linha As New Linha
                cbo_rotas.DataSource = linha.getLinhaByTransbordo()
                cbo_rotas.DataTextField = "nm_linha"
                cbo_rotas.DataValueField = "id_linha"
                cbo_rotas.DataBind()
                cbo_rotas.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

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

                If txt_dt_pesagem_inicial.Text.Equals(String.Empty) Then
                    txt_hr_ini.Text = Format(DateTime.Parse(Now), "HH")
                    txt_mm_ini.Text = Format(DateTime.Parse(Now), "mm")
                    txt_dt_pesagem_inicial.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
                End If

                ' Themis - 14/05/2012 - chamado 1547 (inicializa variáveis de execução para guardar pesos originais lidos da balança) - i
                ViewState.Item("nr_peso_leiturabalanca_inicial") = 0
                ViewState.Item("dt_leiturabalanca_inicial") = ""
                ' Themis - 14/05/2012 - chamado 1547 (inicializa variáveis de execução para guardar pesos originais lidos da balança) - f

            Else
                messageControl.Alert("Há problemas com a passagem de parâmetros. Por favor, tente novamente.")

            End If



            'Dim notatransf As New Romaneio
            'notatransf.id_st_romaneio = 5 'Pre-Romaneio
            'cbo_nr_nota_fiscal_transf.DataSource = notatransf.getRomaneioNotaTransfByStatus()
            'cbo_nr_nota_fiscal_transf.DataTextField = "nr_nota_fiscal_transf"
            'cbo_nr_nota_fiscal_transf.DataValueField = "nr_nota_fiscal_transf"
            'cbo_nr_nota_fiscal_transf.DataBind()
            'cbo_nr_nota_fiscal_transf.Items.Insert(0, New ListItem("[Selecione]", String.Empty))



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub



    Private Sub updateData()
        If Page.IsValid Then


            Try

                Dim romaneio As New Romaneio()
                Dim row As GridViewRow
                romaneio.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                romaneio.id_transportador = Convert.ToInt32(hf_id_transportador.Value)
                romaneio.cd_cnh = lbl_cd_cnh.Text
                'fran 09/2016 i transbordo nao possui nota de transferencia
                'romaneio.nr_nota_fiscal_transf = cbo_nr_nota_fiscal_transf.SelectedValue
                'romaneio.nr_serie_nota_fiscal_transf = txt_serie_nota_fiscal.Text.ToString
                'romaneio.dt_emissao_nota_transf = txt_dt_saida_nota.Text.ToString
                'If Not (txt_nr_peso_liquido_nota.Text.Trim.Equals(String.Empty)) Then
                '    romaneio.nr_peso_liquido_nota_transf = Convert.ToDecimal(txt_nr_peso_liquido_nota.Text)
                'End If
                romaneio.id_item = Convert.ToInt32(cbo_id_item.SelectedValue)
                romaneio.id_linha = Convert.ToInt32(cbo_rotas.SelectedValue)
                'fran 09/2016 f

                ''romaneio.nr_valor_nota_fiscal = Convert.ToDecimal(txt_nr_valor_nota_fiscal.Text)
                romaneio.id_modificador = Session("id_login")
                'romaneio.id_st_romaneio = 1 'Status Aberto Inompleto

                romaneio.cadernetas = ViewState.Item("listacadernetas").ToString

                distribuirVolumeCompartimento()
                romaneio.nr_peso_liquido_caderneta = ViewState.Item("total_nr_peso_liquido_caderneta")
                For Each row In gridRomaneioCompartimento.Rows
                    If row.Visible = True Then
                        Dim txt_placa As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
                        Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_id_compartimento As DataControlFieldCell = CType(row.Cells(7), DataControlFieldCell)
                        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                        Dim chk As Anthem.CheckBox = CType(row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)

                        If chk.Checked = True Then
                            romaneio.ds_placa = txt_placa.Text.ToString
                        End If

                        romaneio.rc_ds_placa.Add(txt_placa.Text.ToString)
                        romaneio.rc_id_compartimento.Add(Convert.ToInt32(cbo_compartimento.SelectedValue))
                        If Not (txt_nr_total_litros.Text.ToString.Equals(String.Empty)) Then
                            romaneio.rc_nr_total_volume.Add(Convert.ToDecimal(txt_nr_total_litros.Text))
                        Else
                            romaneio.rc_nr_total_volume.Add(Convert.ToDecimal(0))
                        End If

                    End If
                Next
                'Fran 30/09/2008 i pesagem inicial 
                If Not (txt_pesagem_inicial.Text.Trim.Equals(String.Empty)) Then
                    romaneio.nr_pesagem_inicial = Convert.ToDecimal(txt_pesagem_inicial.Text)
                Else
                    romaneio.nr_pesagem_inicial = 0
                End If
                romaneio.dt_pesagem_inicial = txt_dt_pesagem_inicial.Text & " " & txt_hr_ini.Text & ":" & txt_mm_ini.Text & ":00"
                'assume que status esta aberto pois ja informou dados pesagem
                'caso queira cadastrar lacre, a tela complementar deixara visualizar cooperativa com status 2 até que registre analise
                romaneio.id_st_romaneio = 2 'Status Aberto
                'Fran 30/09/2008 f
                romaneio.total_volume_max_compartimentos = ViewState.Item("total_volumes_compartimentos")

                ' Projeto Themis -15/05/2012 - adri - chamado 1547 - i
                romaneio.nr_peso_leiturabalanca_inicial = ViewState.Item("nr_peso_leiturabalanca_inicial")
                romaneio.dt_leiturabalanca_inicial = ViewState.Item("dt_leiturabalanca_inicial")
                ' Projeto Themis -15/05/2012 - adri - chamado 1547 - f


                romaneio.id_romaneio = romaneio.abrirRomaneioTransbordo()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 20
                usuariolog.id_nr_processo = romaneio.id_romaneio.ToString
                usuariolog.nm_nr_processo = romaneio.id_romaneio.ToString

                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 


                Dim lmsg As String
                lmsg = "O Romaneio foi aberto com sucesso! O número que é a identificação necessária para acompanhamento deste processo é " & romaneio.id_romaneio.ToString & "."
                Response.Redirect("frm_mensagem.aspx?msg=" + lmsg + "&tela=frm_romaneio.aspx?id_romaneio=" + Convert.ToString(romaneio.id_romaneio))


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Private Sub carregarCamposVeiculo(ByVal id_index_row As Integer)

        Try
            Dim txt_ds_placa As Anthem.TextBox = CType(gridRomaneioCompartimento.Rows.Item(id_index_row).FindControl("txt_placa"), Anthem.TextBox)
            'Dim lbl_id_transportador As Anthem.TextBox = CType(gridRomaneioCompartimento.Rows.Item(id_index_row).FindControl("lbl_id_transportador"), Anthem.TextBox)
            txt_ds_placa.Text = ""
            If Not (customPage.getFilterValue("lupa_veiculo", "ds_placa").Equals(String.Empty)) Then
                txt_ds_placa.Text = customPage.getFilterValue("lupa_veiculo", "ds_placa").ToString
                'lbl_id_transportador.Text = customPage.getFilterValue("lupa_veiculo", "id_transportador").ToString
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
                Me.lbl_nm_transportador.Visible = True
                Me.lbl_nm_transportador.Text = customPage.getFilterValue("lupa_transportador", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_transportador", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_transportador.Text = customPage.getFilterValue("lupa_transportador", "cd_pessoa").ToString
            End If

            'loadData()
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



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    'Protected Sub bt_lupa_veiculo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_veiculo.Click
    '    Me.txt_placa.Text = ""
    '    carregarCamposVeiculo()

    'End Sub

    Protected Sub txt_cd_transportador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_transportador.TextChanged
        lbl_nm_transportador.Text = String.Empty
        lbl_nm_transportador.Visible = False
        hf_id_transportador.Value = String.Empty
        loadMotoristaByTransportador(, txt_cd_transportador.Text.Trim)


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
            lbl_nm_transportador.Visible = False
        End If
        'End If

    End Sub



    Protected Sub btn_novo_compartimento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_compartimento.Click
        Try

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

                Dim row As GridViewRow
                ilinha = 0
                For Each row In gridRomaneioCompartimento.Rows
                    If row.Visible = True Then
                        Dim txt_placa As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
                        Dim check As Anthem.CheckBox = CType(row.FindControl("chk_st_placa_principal"), Anthem.CheckBox)
                        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
                        Dim txt_volcomp As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)
                        Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim txt_id_index As DataControlFieldCell = CType(row.Cells(6), DataControlFieldCell)
                        Dim txt_id_compartimento As DataControlFieldCell = CType(row.Cells(7), DataControlFieldCell)

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
            cbo_motorista.DataValueField = "ds_id_cdcnh"
            cbo_motorista.DataBind()
            cbo_motorista.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

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

    Private Sub loadCNHByMotorista(ByVal id_motorista As Int32)

        Try

            If id_motorista > 0 Then
                Dim motorista As New Motorista()
                motorista.id_motorista = id_motorista
                lbl_cnh.Visible = True
                lbl_cd_cnh.Visible = True
                lbl_cd_cnh.Text = motorista.getMotoristaCNH()
            Else
                lbl_cd_cnh.Text = String.Empty
                lbl_cnh.Visible = False
                lbl_cd_cnh.Visible = False
            End If
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


    Protected Sub txt_placa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        'Dim NomeControle As String = CType(sender, TextBox).ClientID
        '        Dim teste As TextBox = CType(sender, TextBox)
        '       Dim row As GridViewRow = CType(gridRomaneioCompartimento.SelectedRow, GridViewRow)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txtplaca As Anthem.TextBox = CType(row.FindControl("txt_placa"), Anthem.TextBox)
        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)
        Dim txtvolmaxcomp As DataControlFieldCell = CType(row.Cells.Item(3), DataControlFieldCell)

        txtvolmaxcomp.Text = String.Empty
        cbo_compartimento.Items.Clear()
        cbo_compartimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        cbo_compartimento.Enabled = False

        loadCompartimentosByPlaca(row.RowIndex, txtplaca.Text.Trim.ToString)


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

    Protected Sub gridRomaneioCompartimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridRomaneioCompartimento.RowDataBound
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

            End If
        End If
    End Sub

    Protected Sub gridRomaneioCompartimento_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridRomaneioCompartimento.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub cbo_motorista_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_motorista.SelectedIndexChanged
        Dim lpos As Integer

        'Guarda no value do compartimento o id e o volume max do compartimento
        lpos = InStr(cbo_motorista.SelectedValue, "&")
        lbl_cd_cnh.Visible = True
        lbl_cnh.Visible = True
        lbl_cd_cnh.Text = Mid(cbo_motorista.SelectedValue, lpos + 1).Trim

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

                'Busca os volumes maximos para cada compartiment o informado
                Dim ltotalvolumescompartimento As Decimal
                Dim ltotalcoletadopreromaneios As Decimal
                Dim lpercentualcompartimento As Decimal
                ltotalvolumescompartimento = 0
                'fran 09/2016 i transbordo nao possui nota de transferencia
                'Dim romaneio As New Romaneio
                'romaneio.id_st_romaneio = 5
                'romaneio.nr_nota_fiscal_transf = cbo_nr_nota_fiscal_transf.SelectedValue
                'ltotalcoletadopreromaneios = romaneio.getRomaneioSomaCadernetasbyNotaTransf
                ltotalcoletadopreromaneios = CDec(lbl_soma_nr_peso_liquido_caderneta.Text)
                'fran 09/2016 f
                ViewState.Item("total_nr_peso_liquido_caderneta") = ltotalcoletadopreromaneios
                For Each row In gridRomaneioCompartimento.Rows
                    If row.Visible = True Then
                        Dim lbl_max_compartimento As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)
                        'Guarda o somatório dos volumes maximos permitidos para cada compartimento
                        ltotalvolumescompartimento = ltotalvolumescompartimento + CDec(lbl_max_compartimento.Text)
                    End If
                Next
                ViewState.Item("total_volumes_compartimentos") = ltotalvolumescompartimento

                For Each row In gridRomaneioCompartimento.Rows
                    If row.Visible = True Then
                        Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                        Dim lbl_max_compartimento As DataControlFieldCell = CType(row.Cells(3), DataControlFieldCell)
                        Dim cbo_compartimento As Anthem.DropDownList = CType(row.FindControl("cbo_compartimento"), Anthem.DropDownList)

                        'Acha o percentual referente ao vol maximo de cada compartimento com relação ao total dos volumes maximos informados
                        lpercentualcompartimento = (CDec(lbl_max_compartimento.Text) * 100) / ltotalvolumescompartimento
                        'atribui a coluna invisivel total litro compratimento, o valor total liquido dos romaneios de cada nota vezes o percentual do compartimento
                        txt_nr_total_litros.Text = Round(CDec(ltotalcoletadopreromaneios * (lpercentualcompartimento / 100)), 4)

                    End If
                Next


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
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

            If ltotalvolumescompartimento < CDec(lbl_soma_nr_peso_liquido_caderneta.Text) Then
                args.IsValid = False
            Else
                args.IsValid = True
            End If

            If args.IsValid = False Then
                messageControl.Alert("A somatória do volume máximo dos compartimentos informados não pode ser inferior aos Litros das Cadernetas do Transbordo.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_balanca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_balanca.Click

        '  Mirella 28/03/2012 - Projeto Themis - Leitura da Balança através do web service WSBalanca - i
        Try

            ' 21/03/2012 - Projeto Themis - i
            Dim iPeso As Int32
            Dim sServer As String
            Dim iPorta As Integer
            Dim iTimeout As Integer

            'Parametros que devm ser passados para a função
            Dim balanca As New Balanca(Convert.ToInt32(cbo_balanca.SelectedValue))

            'sServer = "192.168.1.50"
            'iPorta = 2101
            sServer = balanca.ds_end_ip
            iPorta = balanca.ds_porta

            iTimeout = 3000
            iPeso = 0

            Dim svcBalanca As New clsBalanca.clsBal

            ' O retorno da função é o peso da balança
            iPeso = svcBalanca.GetPeso(sServer, iPorta, iTimeout)

            If iPeso >= 0 Then
                Me.txt_pesagem_inicial.Text = iPeso.ToString()
                ViewState.Item("nr_peso_leiturabalanca_inicial") = iPeso
                ViewState.Item("dt_leiturabalanca_inicial") = Format(DateTime.Parse(Now), "dd/MM/yyyy HH:mm")
                lbl_aguarde.CssClass = "aguardenormal"
            Else
                Select Case iPeso
                    Case -10
                        messageControl.Alert("Erro de comunicação com a balança")
                    Case -99
                        messageControl.Alert("Peso instável")
                    Case -90
                        messageControl.Alert("Erro de argumentos")
                    Case -80
                        messageControl.Alert("Erro na conversão de valores")
                End Select
            End If

            '1.	Todo valor positivo é peso válido
            '2.	Todo valor negativo possui a seguinte representação:
            ' -10 Erro de comunicação com a balança
            ' -99 Peso Instavel
            ' -90 Erro de argumentos
            ' -80 Erro na conversao de valores

            ' 21/03/2012 - Projeto Themis - f

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        '  Mirella 28/03/2012 - Projeto Themis - Leitura da Balança através do web service WSBalanca - f


    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        ' Mirella 28/03/2012 - Projeto Themis i
        If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then

            loadBalancabyEstabelecimento(Convert.ToInt32(cbo_estabelecimento.SelectedValue))
            txt_pesagem_inicial.Text = 0

        Else
            cbo_balanca.Items.Clear()
            'cbo_balanca.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            cbo_balanca.Enabled = False
            btn_balanca.Enabled = False


        End If
        ' Mirella 28/03/2012 - Projeto Themis f
    End Sub

    Private Sub loadBalancabyEstabelecimento(ByVal id_estabelecimento As Int32)
        ' Mirella 28/03/2012 - Projeto Themis 

        Try

            cbo_balanca.Enabled = True
            btn_balanca.Enabled = True

            Dim balanca As New Balanca

            balanca.id_estabelecimento = id_estabelecimento ' Traz somente as balanças do estabelecimento
            cbo_balanca.DataSource = balanca.getBalancaByFilters()
            cbo_balanca.DataTextField = "nm_balanca"
            cbo_balanca.DataValueField = "id_balanca"
            cbo_balanca.DataBind()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

        ' Mirella 28/03/2012 - Projeto Themis - Carrega combo com as balanças cadastradas - f

    End Sub


End Class
