Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math


Partial Class frm_romaneio
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_caderneta.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")
                If Not (Request("nm_tela") Is Nothing) Then
                    ViewState.Item("voltar_para_tela") = Request("nm_tela")
                End If
                loadData()
            End If

            ' Themis - 14/05/2012 - chamado 1547 (inicializa variáveis de execução para guardar pesos originais lidos da balança) - i
            ViewState.Item("nr_peso_leiturabalanca_inicial") = 0
            ViewState.Item("dt_leiturabalanca_inicial") = ""
            ' Themis - 14/05/2012 - chamado 1547 (inicializa variáveis de execução para guardar pesos originais lidos da balança) - f

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim romaneio As New Romaneio(id_romaneio)


            Dim estabel As New Estabelecimento
            estabel.id_situacao = 1
            cbo_estabelecimento.DataSource = estabel.getEstabelecimentosByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'Se é um romaneio com entrada de produtores
            If romaneio.nr_caderneta > 0 Then
                ViewState.Item("cooperativa") = "N"
                tr_pnl_dados_cooperativa.Visible = False
                tr_pnl_nota_fiscal_transferencia.Visible = True
                txt_nr_nota_fiscal_transf.Text = romaneio.nr_nota_fiscal_transf
                txt_serie_nota_fiscal_transf.Text = romaneio.nr_serie_nota_fiscal_transf
                If Not (romaneio.dt_emissao_nota_transf Is Nothing) Then
                    If Not (romaneio.dt_emissao_nota_transf.ToString.Equals(String.Empty)) Then
                        txt_dt_emissao_nota.Text = Format(DateTime.Parse(romaneio.dt_emissao_nota_transf), "dd/MM/yyyy").ToString
                    End If
                End If
                If romaneio.nr_peso_liquido_nota_transf > 0 Then
                    txt_nr_peso_liquido_nota_transf.Text = romaneio.nr_peso_liquido_nota_transf
                End If
                'td_dados_cooperativa.Visible = False
                'tr_caderneta.Visible = True
                'lbl_label_caderneta.Visible = True
                'lbl_caderneta.Visible = True
                gridRomaneioCompartimento.Columns.Item(4).Visible = False
                cv_gridcomp.Visible = False
                lbl_caderneta.Text = romaneio.nr_caderneta.ToString
                lbl_peso_liquido_caderneta.Text = FormatNumber(romaneio.nr_peso_liquido_caderneta, 0).ToString
                lbl_tipoleite.Text = romaneio.nm_item
                cbo_estabelecimento.SelectedValue = romaneio.id_estabelecimento
                'fran 6/08/2012 i se não selecionou estabelecimento, não carrega balança
                If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then
                    'fran 6/08/2012 f se não selecionou estabelecimento, não carrega balança
                    loadBalancabyEstabelecimento(cbo_estabelecimento.SelectedValue)     ' Themis adri 17/05/2012 - chamado 1547 

                End If
                If romaneio.id_st_romaneio = 2 Then
                    cbo_estabelecimento.Enabled = False

                End If

            End If
            'Se é um romaneio de cooperativa
            If romaneio.id_cooperativa > 0 Then
                ViewState.Item("cooperativa") = "S"
                'td_dados_cooperativa.Visible = True
                tr_caderneta.Visible = False
                tr_caderneta2.Visible = False
                tr_pnl_nota_fiscal_transferencia.Visible = False
                lbl_labeltipoleite.Visible = False
                lbl_tipoleite.Visible = False

                'Dados cooperativa
                lbl_cooperativa.Text = String.Concat(romaneio.cd_cooperativa.ToString, " - ", romaneio.nm_cooperativa.ToString)
                lbl_nr_nota_fiscal.Text = romaneio.nr_nota_fiscal.ToString
                lbl_dt_saida_nota.Text = DateTime.Parse(romaneio.dt_saida_nota.ToString).ToString
                lbl_nm_item.Text = romaneio.nm_item.ToString
                lbl_nr_valor_nota.Text = FormatCurrency(romaneio.nr_valor_nota_fiscal, 2)
                lbl_nr_peso_liquido_nota.Text = romaneio.nr_peso_liquido_nota.ToString
                cbo_estabelecimento.SelectedValue = romaneio.id_estabelecimento
                'fran 6/08/2012 i se não selecionou estabelecimento, não carrega balança
                If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then
                    'fran 6/08/2012 f se não selecionou estabelecimento, não carrega balança
                    loadBalancabyEstabelecimento(cbo_estabelecimento.SelectedValue)     ' Themis adri 17/05/2012 - chamado 1547 
                End If
                cbo_estabelecimento.Enabled = False
            End If
            If romaneio.st_romaneio_transbordo = "S" Then
                ViewState.Item("cooperativa") = "N"
                tr_pnl_dados_cooperativa.Visible = False
                'tr_pnl_nota_fiscal_transferencia.Visible = True
                tr_pnl_nota_fiscal_transferencia.Visible = False
                txt_nr_nota_fiscal_transf.Text = romaneio.nr_nota_fiscal_transf
                txt_nr_nota_fiscal_transf.Enabled = False
                txt_serie_nota_fiscal_transf.Text = romaneio.nr_serie_nota_fiscal_transf
                If Not (romaneio.dt_emissao_nota_transf Is Nothing) Then
                    If Not (romaneio.dt_emissao_nota_transf.ToString.Equals(String.Empty)) Then
                        txt_dt_emissao_nota.Text = Format(DateTime.Parse(romaneio.dt_emissao_nota_transf), "dd/MM/yyyy").ToString
                    End If
                End If
                If romaneio.nr_peso_liquido_nota_transf > 0 Then
                    txt_nr_peso_liquido_nota_transf.Text = romaneio.nr_peso_liquido_nota_transf
                End If
                gridRomaneioCompartimento.Columns.Item(4).Visible = False
                cv_gridcomp.Visible = False
                tr_transbordo.Visible = True
                lbl_nr_peso_liquido_caderneta.Text = FormatNumber(romaneio.nr_peso_liquido_caderneta, 0).ToString
                lbl_id_item.Text = romaneio.nm_item
                cbo_estabelecimento.SelectedValue = romaneio.id_estabelecimento
                'fran 6/08/2012 i se não selecionou estabelecimento, não carrega balança
                If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then
                    'fran 6/08/2012 f se não selecionou estabelecimento, não carrega balança
                    loadBalancabyEstabelecimento(cbo_estabelecimento.SelectedValue)     ' Themis adri 17/05/2012 - chamado 1547 
                End If
                'Fran 23/11/2009 i Maracanau chamado 519
                cbo_estabelecimento.Enabled = False
                'Fran 23/11/2009 f
                tr_caderneta.Visible = False
                tr_caderneta2.Visible = False

            End If
            lbl_romaneio.Text = romaneio.id_romaneio.ToString
            lbl_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            lbl_transportador.Text = romaneio.ds_transportador.ToString
            lbl_motorista.Text = romaneio.nm_motorista
            lbl_cd_cnh.Text = romaneio.cd_cnh
            lbl_dt_entrada.Text = Format(DateTime.Parse(romaneio.dt_hora_entrada.ToString), "dd/MM/yyyy HH:mm")
            If Not (romaneio.dt_hora_saida Is Nothing) Then
                If Not (romaneio.dt_hora_saida.ToString.Equals(String.Empty)) Then
                    lbl_saida.Text = DateTime.Parse(romaneio.dt_hora_saida.ToString).ToString
                End If
            End If
            If Not romaneio.ds_linha Is Nothing Then
                lbl_linha.Text = romaneio.ds_linha.ToString
            End If
            lbl_placa.Text = romaneio.ds_placa.ToString
            lbl_tara.Text = FormatNumber(romaneio.nr_tara, 0).ToString
            txt_pesagem_inicial.Text = romaneio.nr_pesagem_inicial.ToString
            If Not romaneio.dt_pesagem_inicial Is Nothing Then
                txt_hr_ini.Text = Format(DateTime.Parse(romaneio.dt_pesagem_inicial), "HH")
                txt_mm_ini.Text = DatePart(DateInterval.Minute, DateTime.Parse(romaneio.dt_pesagem_inicial))
                txt_dt_pesagem_inicial.Text = Format(DateTime.Parse(romaneio.dt_pesagem_inicial), "dd/MM/yyyy")
            Else
                txt_hr_ini.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_ini.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
                txt_dt_pesagem_inicial.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            End If
            loadgridcompartimento()
            loadgridlacre()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadgridcompartimento()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim rc As New Romaneio_Compartimento

            rc.id_romaneio = id_romaneio

            Dim dsrcompartimento As DataSet = rc.getRomaneio_CompartimentoByFilters()

            If (dsrcompartimento.Tables(0).Rows.Count > 0) Then
                gridRomaneioCompartimento.Visible = True
                gridRomaneioCompartimento.DataSource = Helper.getDataView(dsrcompartimento.Tables(0), "ds_placa asc, nr_compartimento asc")
                gridRomaneioCompartimento.DataBind()
            Else
                gridRomaneioCompartimento.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadgridlacre()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim lacre As New RomaneioLacre

            lacre.id_romaneio = id_romaneio

            Dim dslacre As DataSet = lacre.getRomaneioLacresByFilters()

            If (dslacre.Tables(0).Rows.Count > 0) Then
                grdlacres.Visible = True
                grdlacres.DataSource = Helper.getDataView(dslacre.Tables(0), "ds_placa asc")
                grdlacres.DataBind()
            Else
                Dim dr As DataRow = dslacre.Tables(0).NewRow()
                'dr("id_candidato_idioma") = -1
                dslacre.Tables(0).Rows.InsertAt(dr, 0)
                grdlacres.Visible = True
                grdlacres.DataSource = Helper.getDataView(dslacre.Tables(0), ViewState.Item("sortExpression"))
                grdlacres.DataBind()
                grdlacres.Rows(0).Cells.Clear()
                grdlacres.Rows(0).Cells.Add(New TableCell())
                grdlacres.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdlacres.Rows(0).Cells(0).Text = "Não existe nenhum lacre cadastrado!"
                grdlacres.Rows(0).Cells(0).ColumnSpan = 4
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    'Private Sub updateData()
    '    If Page.IsValid Then

    '        Try

    '            Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

    '            If Not (txt_pesagem_inicial.Text.Trim.Equals(String.Empty)) Then
    '                romaneio.nr_pesagem_inicial = Convert.ToDecimal(txt_pesagem_inicial.Text)
    '            Else
    '                romaneio.nr_pesagem_inicial = 0
    '            End If
    '            romaneio.dt_pesagem_inicial = txt_dt_pesagem_inicial.Text & " " & txt_hr_ini.Text & ":" & txt_mm_ini.Text & ":00"

    '            romaneio.nr_nota_fiscal_transf = txt_nr_nota_fiscal_transf.Text
    '            romaneio.nr_serie_nota_fiscal_transf = txt_serie_nota_fiscal_transf.Text
    '            romaneio.dt_emissao_nota_transf = txt_dt_emissao_nota.Text
    '            If Not (txt_nr_peso_liquido_nota_transf.Text.Trim.Equals(String.Empty)) Then
    '                romaneio.nr_peso_liquido_nota_transf = Convert.ToDecimal(txt_nr_peso_liquido_nota_transf.Text)
    '            Else
    '                romaneio.nr_peso_liquido_nota_transf = 0
    '            End If

    '            romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
    '            romaneio.id_modificador = Session("id_login")
    '            If Not (cbo_estabelecimento.SelectedValue.Trim.Equals(String.Empty)) Then
    '                romaneio.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.Text)
    '            End If

    '            'Lacre não obrigatório
    '            'Dim row As GridViewRow = grdlacres.Rows(0)
    '            'Dim lbl As Label = CType(row.FindControl("lbl_ds_placa"), Label)
    '            'If Not lbl Is Nothing Then
    '            'If Not lbl.Text.Equals(String.Empty) Then
    '            'romaneio.id_st_romaneio = 2 'Status Aberto 
    '            'Else
    '            'romaneio.id_st_romaneio = 1 'Status Aberto Incompleto
    '            'End If
    '            'End If
    '            'fran 23/11/2009 i maracanau chamado 519
    '            Dim lnovoromaneioprodutor As Boolean = False
    '            If romaneio.id_st_romaneio = 1 Then
    '                If romaneio.nr_caderneta > 0 Then
    '                    lnovoromaneioprodutor = True
    '                End If
    '            End If
    '            'fran 23/11/2009 f maracanau chamado 519
    '            romaneio.id_st_romaneio = 2 'Status Aberto 

    '            ' Projeto Themis -15/05/2012 - adri - chamado 1547 - i
    '            romaneio.nr_peso_leiturabalanca_inicial = ViewState.Item("nr_peso_leiturabalanca_inicial")
    '            romaneio.dt_leiturabalanca_inicial = ViewState.Item("dt_leiturabalanca_inicial")
    '            ' Projeto Themis -15/05/2012 - adri - chamado 1547 - f

    '            romaneio.updateRomaneio()
    '            If romaneio.id_st_romaneio = 1 Then
    '                messageControl.Alert("Registro alterado com sucesso! Para dar continuidade ao processo de Romaneio o cadastro ainda deve ser completado")
    '            Else
    '                'fran 23/11/2009 i maracanau chamado 519
    '                If lnovoromaneioprodutor = True Then
    '                    'se for um novo romaneio de produtor, insere as analises de compartimento.
    '                    Dim analise As New RomaneioAnaliseCompartimento
    '                    analise.id_romaneio = romaneio.id_romaneio
    '                    analise.id_estabelecimento = romaneio.id_estabelecimento
    '                    analise.id_modificador = romaneio.id_modificador
    '                    analise.insertRomaneioAnaliseCompartimento()
    '                End If
    '                'fran 23/11/2009 f
    '                messageControl.Alert("Registro alterado com sucesso! O processo do Romaneio pode ser continuado!")
    '            End If


    '            loadData()

    '        Catch ex As Exception
    '            messageControl.Alert(ex.Message)
    '        End Try
    '    End If
    'End Sub

    Private Sub updateData()
        If Page.IsValid Then

            Try

                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                If Not (txt_pesagem_inicial.Text.Trim.Equals(String.Empty)) Then
                    romaneio.nr_pesagem_inicial = Convert.ToDecimal(txt_pesagem_inicial.Text)
                Else
                    romaneio.nr_pesagem_inicial = 0
                End If
                romaneio.dt_pesagem_inicial = txt_dt_pesagem_inicial.Text & " " & txt_hr_ini.Text & ":" & txt_mm_ini.Text & ":00"

                romaneio.nr_nota_fiscal_transf = txt_nr_nota_fiscal_transf.Text
                romaneio.nr_serie_nota_fiscal_transf = txt_serie_nota_fiscal_transf.Text
                romaneio.dt_emissao_nota_transf = txt_dt_emissao_nota.Text
                If Not (txt_nr_peso_liquido_nota_transf.Text.Trim.Equals(String.Empty)) Then
                    romaneio.nr_peso_liquido_nota_transf = Convert.ToDecimal(txt_nr_peso_liquido_nota_transf.Text)
                Else
                    romaneio.nr_peso_liquido_nota_transf = 0
                End If

                romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                romaneio.id_modificador = Session("id_login")
                If Not (cbo_estabelecimento.SelectedValue.Trim.Equals(String.Empty)) Then
                    romaneio.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.Text)
                End If

                'Lacre não obrigatório
                'Dim row As GridViewRow = grdlacres.Rows(0)
                'Dim lbl As Label = CType(row.FindControl("lbl_ds_placa"), Label)
                'If Not lbl Is Nothing Then
                'If Not lbl.Text.Equals(String.Empty) Then
                'romaneio.id_st_romaneio = 2 'Status Aberto 
                'Else
                'romaneio.id_st_romaneio = 1 'Status Aberto Incompleto
                'End If
                'End If
                'fran 23/11/2009 i maracanau chamado 519
                Dim lnovoromaneioprodutor As Boolean = False
                If romaneio.id_st_romaneio = 1 Then
                    If romaneio.nr_caderneta > 0 Then
                        lnovoromaneioprodutor = True
                    End If
                End If
                'fran 23/11/2009 f maracanau chamado 519
                romaneio.id_st_romaneio = 2 'Status Aberto 

                ' Projeto Themis -15/05/2012 - adri - chamado 1547 - i
                romaneio.nr_peso_leiturabalanca_inicial = ViewState.Item("nr_peso_leiturabalanca_inicial")
                romaneio.dt_leiturabalanca_inicial = ViewState.Item("dt_leiturabalanca_inicial")
                ' Projeto Themis -15/05/2012 - adri - chamado 1547 - f

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteração
                usuariolog.id_menu_item = 21
                usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                'romaneio.updateRomaneio() ' adri 01/02/2013 (Desabilitado)
                If romaneio.id_st_romaneio = 1 Then
                    romaneio.updateRomaneio()   ' adri 01/02/2013 - chamado 1644 - se não precisa criar análise, pode fazer o update sozinho
                    messageControl.Alert("Registro alterado com sucesso! Para dar continuidade ao processo de Romaneio o cadastro ainda deve ser completado")
                Else
                    'fran 23/11/2009 i maracanau chamado 519
                    If lnovoromaneioprodutor = True Then
                        'se for um novo romaneio de produtor, insere as analises de compartimento.
                        'Dim analise As New RomaneioAnaliseCompartimento
                        'analise.id_romaneio = romaneio.id_romaneio
                        'analise.id_estabelecimento = romaneio.id_estabelecimento
                        'analise.id_modificador = romaneio.id_modificador
                        'analise.insertRomaneioAnaliseCompartimento()
                        romaneio.ComplementarRomaneioAnaliseCompartimento() ' adri 01/02/2013 - chamado 1644 - se não precisa criar análise, pode fazer o update sozinho
                        messageControl.Alert("Registro alterado com sucesso! O processo do Romaneio pode ser continuado!")
                    Else
                        romaneio.updateRomaneio()   ' adri 01/02/2013 - chamado 1644 - se não precisa criar análise, pode fazer o update sozinho

                        messageControl.Alert("Registro alterado com sucesso! O processo do Romaneio pode ser continuado!")
                    End If
                    'fran 23/11/2009 f
                    'messageControl.Alert("Registro alterado com sucesso! O processo do Romaneio pode ser continuado!") ' adri 01/02/2013 chamado 1644 (Desabilitado)
                End If


                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        If Not (ViewState.Item("voltar_para_tela") Is Nothing) Then
            Select Case ViewState.Item("voltar_para_tela").ToString
                Case "complementar_dados"
                    Response.Redirect("lst_romaneio_complementar_dados.aspx")
            End Select
        Else
            Response.Redirect("lst_romaneio_caderneta.aspx")
        End If


    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        If Not (ViewState.Item("voltar_para_tela") Is Nothing) Then
            Select Case ViewState.Item("voltar_para_tela").ToString
                Case "complementar_dados"
                    Response.Redirect("lst_romaneio_complementar_dados.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString)
            End Select
        Else
            Response.Redirect("lst_romaneio_caderneta.aspx")
        End If

    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub gridRomaneioCompartimento_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridRomaneioCompartimento.RowCancelingEdit
        Try

            gridRomaneioCompartimento.EditIndex = -1
            loadgridcompartimento()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridRomaneioCompartimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridRomaneioCompartimento.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Try

                'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                Dim txt_nr_total_litros As Label = CType(e.Row.FindControl("lbl_nr_total_litros"), Label)
                If Not (txt_nr_total_litros Is Nothing) Then
                    If Not txt_nr_total_litros.Text.Equals(String.Empty) Then
                        If CLng(txt_nr_total_litros.Text) = 0 Then
                            txt_nr_total_litros.Text = String.Empty
                        End If
                    End If
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub gridRomaneioCompartimento_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridRomaneioCompartimento.RowEditing
        Try

            gridRomaneioCompartimento.EditIndex = e.NewEditIndex
            loadgridcompartimento()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridRomaneioCompartimento_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridRomaneioCompartimento.RowUpdating
        'Capturar valores


        Dim row As GridViewRow = gridRomaneioCompartimento.Rows(e.RowIndex)
        Try

            If (Not (row) Is Nothing) Then

                Dim rc As New Romaneio_Compartimento

                rc.id_romaneio_compartimento = Convert.ToInt32(gridRomaneioCompartimento.DataKeys.Item(e.RowIndex).Value)

                'Fran 24/03/2009 rls 17 i
                'Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                Dim txt_nr_total_litros As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_total_litros"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)
                'Fran 24/03/2009 rls 17 f
                If Not (txt_nr_total_litros.Text.Trim.ToString.Equals(String.Empty)) Then
                    rc.nr_total_litros = Convert.ToDecimal(txt_nr_total_litros.Text)
                End If
                'Fran 20/04/2009 i não entendi porque esta positivando analise antes de inciar ALERTA
                'rc.id_st_analise = 1 'Analise de compartimento negativa
                'Fran 20/04/2009 f não entendi porque esta positivando analise antes de inciar ALERTA
                rc.id_modificador = Session("id_login")

                rc.updateRomaneio_Compartimento()
                gridRomaneioCompartimento.EditIndex = -1
                loadgridcompartimento()
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub btn_novo_lacre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_novo_lacre.Click
        ViewState.Item("incluirlinhalacre") = "S"
        Dim lacre As New RomaneioLacre
        lacre.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
        Dim dslacre As DataSet = lacre.getRomaneioLacresByFilters()
        Dim dr As DataRow = dslacre.Tables(0).NewRow()
        dslacre.Tables(0).Rows.InsertAt(dr, 0)
        grdlacres.Visible = True
        grdlacres.DataSource = Helper.getDataView(dslacre.Tables(0), "ds_placa asc")
        grdlacres.EditIndex = 0
        grdlacres.DataBind()
        ViewState.Item("incluirlinhalacre") = Nothing
        'loadgridcompartimento()

    End Sub

    Protected Sub grdlacres_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdlacres.PageIndexChanging
        grdlacres.PageIndex = e.NewPageIndex
        'loadData()

    End Sub

    Protected Sub grdlacres_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdlacres.RowCancelingEdit
        Try

            grdlacres.EditIndex = -1
            loadGridLacre()
            'loadgridcompartimento()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdlacres_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdlacres.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Insert"
                ViewState.Item("incluirlinhalacre") = "S"
                Dim lacre As New RomaneioLacre
                lacre.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                Dim dslacre As DataSet = lacre.getRomaneioLacresByFilters()
                Dim dr As DataRow = dslacre.Tables(0).NewRow()
                'dr("id_candidato_idioma") = -1
                dslacre.Tables(0).Rows.InsertAt(dr, 0)
                grdlacres.Visible = True
                grdlacres.DataSource = Helper.getDataView(dslacre.Tables(0), ViewState.Item("sortExpression"))
                grdlacres.EditIndex = 0
                grdlacres.DataBind()
            Case "Delete"
                deleteRomaneioLacre(Convert.ToInt32(e.CommandArgument.ToString()))
        End Select

    End Sub
    Private Sub deleteRomaneioLacre(ByVal id_romaneio_lacre As Integer)

        Try

            Dim lacre As New RomaneioLacre()
            lacre.id_romaneio_lacre = id_romaneio_lacre
            lacre.deleteRomaneioLacre()
            messageControl.Alert("Registro excluído com sucesso!")
            '            loadGridIdiomas()
            loadGridlacre()
            loadgridcompartimento()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdlacres_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdlacres.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            If ViewState.Item("incluirlinhalacre") = "S" Then
                If e.Row.RowIndex = 0 Then
                    ViewState.Item("label_ds_placa") = ""
                End If
            End If

            Try
                If Not (ViewState.Item("label_ds_placa") Is Nothing) Then
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    'COMBO IDIOMA NO MODO EDIÇÂO
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    Dim cbo_ds_placa As DropDownList = CType(e.Row.FindControl("cbo_ds_placa"), DropDownList)
                    Dim romaneio_placa As New RomaneioPlaca

                    romaneio_placa.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))

                    cbo_ds_placa.DataSource = romaneio_placa.getRomaneioPlacasByFilters()
                    cbo_ds_placa.DataTextField = "ds_placa"
                    cbo_ds_placa.DataValueField = "id_romaneio_placa"
                    cbo_ds_placa.DataBind()

                    If (ViewState.Item("label_ds_placa").ToString.Equals(String.Empty)) Then
                        cbo_ds_placa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState.Item("label_ds_placa") = "SEM_VALOR" 'Assume que o nm esta sem valor
                    Else
                        cbo_ds_placa.SelectedValue = cbo_ds_placa.Items.FindByText(ViewState.Item("label_ds_placa").Trim.ToString).Value
                        ViewState.Item("label_ds_placa") = Nothing 'Assume que tem valor
                    End If

                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub

    Protected Sub grdlacres_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdlacres.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                If ViewState.Item("label_ds_placa") = "SEM_VALOR" Then 'Assume que o nm_st_analise esta sem valor
                    'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                    Dim cbo_ds_placa As DropDownList = CType(e.Row.FindControl("cbo_ds_placa"), DropDownList)
                    If Not (cbo_ds_placa Is Nothing) Then
                        cbo_ds_placa.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    End If
                    ViewState.Item("label_ds_placa") = Nothing 'Assume que o nm_st_analise tem valor
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub

    Protected Sub grdlacres_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdlacres.RowDeleting
        e.Cancel = True

    End Sub

    Protected Sub grdlacres_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdlacres.RowEditing
        Try

            If ViewState.Item("incluirlinhalacre") = "S" And e.NewEditIndex = 0 Then
                ViewState.Item("incluirlinhalacre") = "S"
                loadGridlacre()
                'loadgridcompartimento()
            Else
                Dim lbl_ds_placa As Label = CType(grdlacres.Rows(e.NewEditIndex).FindControl("lbl_ds_placa"), Label)
                ViewState.Item("label_ds_placa") = Trim(lbl_ds_placa.Text)
                grdlacres.EditIndex = e.NewEditIndex
                loadGridlacre()
                'loadgridcompartimento()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub grdlacres_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdlacres.RowUpdating
        'Capturar valores
        Dim row As GridViewRow = grdlacres.Rows(e.RowIndex)
        Try
            Dim lacre As New RomaneioLacre

            If (Not (row) Is Nothing) Then

                Dim cbo_ds_placa As DropDownList = CType(row.FindControl("cbo_ds_placa"), DropDownList)
                Dim txt_nr_lacre_entrada As RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox = CType(row.FindControl("txt_nr_lacre_entrada"), RK.TextBox.AjaxOnlyNumbers.OnlyNumbersTextBox)

                'romaneioanaliseglobal.id_analise_global = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)
                If Not (cbo_ds_placa.SelectedValue.Trim().Equals(String.Empty)) Then
                    lacre.id_romaneio_placa = Convert.ToInt32(Convert.ToInt32(cbo_ds_placa.SelectedValue))
                End If
                lacre.nr_lacre_entrada = txt_nr_lacre_entrada.Text.Trim.ToString
            End If
            lacre.id_modificador = Session("id_login")

            'Se é um novo idioma
            If IsDBNull(grdlacres.DataKeys.Item(e.RowIndex).Value) Then
                lacre.id_romaneio_lacre = lacre.insertRomaneioLacre
            Else
                lacre.id_romaneio_lacre = grdlacres.DataKeys.Item(e.RowIndex).Value
                lacre.updateRomaneioLacre()
            End If

            grdlacres.EditIndex = -1
            loadGridlacre()
            loadgridcompartimento()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub cv_gridcomp_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_gridcomp.ServerValidate

        Dim row As GridViewRow
        Dim ltotallitros As Decimal
        args.IsValid = True
        For Each row In gridRomaneioCompartimento.Rows
            Dim txt_nr_total_litros As Label = CType(row.FindControl("lbl_nr_total_litros"), Label)

            If Not txt_nr_total_litros.Text.Equals(String.Empty) Then
                ltotallitros = ltotallitros + Convert.ToDecimal(txt_nr_total_litros.Text)
                If CLng(txt_nr_total_litros.Text) = 0 Then
                    args.IsValid = False
                    'Exit For
                End If
            Else
                'Se algum campo estiver vazio, não deve salvar
                args.IsValid = False

            End If
        Next
        If args.IsValid = False Then
            messageControl.Alert("O volume total do item contido em cada compartimento deve ser informado.")
        Else
            If Convert.ToDecimal(lbl_nr_peso_liquido_nota.Text) <> ltotallitros Then
                args.IsValid = False
                messageControl.Alert("O volume total cadastrado de " & ltotallitros.ToString & " não pode ser diferente do volume liquido informado na NOTA FISCAL. Caso a nota esteja errada, cadastre o valor e depois altere na tela de Ajustes de Valor do Romaneio.")
            End If
        End If

    End Sub
    Protected Sub cv_gridlacre_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_gridlacre.ServerValidate

        args.IsValid = True
        Dim row As GridViewRow = grdlacres.Rows(0)

        If CType(row.FindControl("lbl_ds_placa"), Label) Is Nothing Then
            args.IsValid = False
        End If
        If args.IsValid = False Then
            messageControl.Alert("O volume total do item contido em cada compartimento deve ser informado.")
        End If

    End Sub

 
 
    Protected Sub txt_nr_nota_fiscal_transf_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nr_nota_fiscal_transf.TextChanged
        If Not txt_nr_nota_fiscal_transf.Text.Equals(String.Empty) Then
            rfv_peso_nota_transf.Visible = True
        End If
    End Sub

    Protected Sub btn_balanca_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_balanca.Click

        '  Mirella 28/03/2012 - Projeto Themis - Leitura da Balança através do web service WSBalanca - i
        Try

            '  adri 09/05/2012 - chamado 1547 - alterações de escopo da leitura da balança - i


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

    Protected Sub lk_AnexarDocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_AnexarDocumento.Click
        If Page.IsValid Then
            Response.Redirect("frm_romaneio_anexos.aspx?id=" + ViewState.Item("id_romaneio").ToString() + "&tela=frm_romaneio.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString)
        End If
    End Sub
End Class
