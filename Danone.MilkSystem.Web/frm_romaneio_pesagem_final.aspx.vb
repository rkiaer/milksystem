Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
'Imports clsBalanca      ' adri 26/03/2012 - Projeto Themis - i


Partial Class frm_romaneio_pesagem_final

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_pesagem_final.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try


            If Not (Request("id_romaneio") Is Nothing) Then
                ViewState.Item("id_romaneio") = Request("id_romaneio")

                Dim romaneio As New Romaneio(ViewState.Item("id_romaneio"))

                ' adri 26/03/2012 - Projeto Themis - Carrega combo com as balanças cadastradas - i
                Dim balanca As New Balanca

                balanca.id_estabelecimento = romaneio.id_estabelecimento  ' Traz somente as balanças do estabelecimento
                cbo_balanca_final.DataSource = balanca.getBalancaByFilters()
                cbo_balanca_final.DataTextField = "nm_balanca"
                cbo_balanca_final.DataValueField = "id_balanca"
                cbo_balanca_final.DataBind()
                ' adri 26/03/2012 - Projeto Themis - Carrega combo com as balanças cadastradas - f

                ' Themis - 14/05/2012 - chamado 1547 i
                Dim balanca_inter As New Balanca

                balanca_inter.id_estabelecimento = romaneio.id_estabelecimento  ' Traz somente as balanças do estabelecimento
                cbo_balanca_intermediaria.DataSource = balanca_inter.getBalancaByFilters()
                cbo_balanca_intermediaria.DataTextField = "nm_balanca"
                cbo_balanca_intermediaria.DataValueField = "id_balanca"
                cbo_balanca_intermediaria.DataBind()
                ' Themis - 14/05/2012 - chamado 1547 f

                ' Themis - 14/05/2012 - chamado 1547 (inicializa variáveis de execução para guardar pesos originais lidos da balança) - i
                ViewState.Item("nr_peso_leiturabalanca_inter") = 0
                ViewState.Item("nr_peso_leiturabalanca_final") = 0
                ViewState.Item("dt_leiturabalanca_inter") = ""
                ViewState.Item("dt_leiturabalanca_final") = ""
                ' Themis - 14/05/2012 - chamado 1547 (inicializa variáveis de execução para guardar pesos originais lidos da balança) - f

                loadData()
            Else
                messageControl.Alert("Há problemas na passagem de parametros. A tela não pode ser montada!")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio").ToString)
            Dim romaneio As New Romaneio(id_romaneio)

            If romaneio.nr_caderneta > 0 Then
                ViewState.Item("cooperativa") = "N"
                tr_pnl_dados_cooperativa.Visible = False
                lbl_caderneta.Text = romaneio.nr_caderneta.ToString
                lbl_peso_liquido_caderneta.Text = FormatNumber(romaneio.nr_peso_liquido_caderneta, 0).ToString
                lbl_tipoleite.Text = romaneio.nm_item
                If romaneio.nr_nota_fiscal_transf Is Nothing Then
                    tr_pnl_nota_fiscal_transferencia.Visible = False
                Else
                    If romaneio.nr_nota_fiscal_transf.Equals(String.Empty) Then
                        tr_pnl_nota_fiscal_transferencia.Visible = False
                    Else
                        tr_pnl_nota_fiscal_transferencia.Visible = True
                        lbl_nr_nota_fiscal_transf.Text = romaneio.nr_nota_fiscal_transf
                        lbl_nr_serie_nota_transf.Text = romaneio.nr_serie_nota_fiscal_transf
                        If Not (romaneio.dt_emissao_nota_transf Is Nothing) Then
                            If Not (romaneio.dt_emissao_nota_transf.ToString.Equals(String.Empty)) Then
                                lbl_dt_emissao_nota_transf.Text = Format(DateTime.Parse(romaneio.dt_emissao_nota_transf), "dd/MM/yyyy").ToString
                            End If
                        End If
                        lbl_nr_peso_nota_transf.Text = romaneio.nr_peso_liquido_nota_transf
                    End If
                End If

            End If
            If romaneio.id_cooperativa > 0 Then
                ViewState.Item("cooperativa") = "S"
                tr_pnl_nota_fiscal_transferencia.Visible = False
                tr_caderneta.Visible = False
                tr_caderneta2.Visible = False
                lbl_labeltipoleite.Visible = False
                lbl_tipoleite.Visible = False
                'Dados cooperativa
                lbl_cooperativa.Text = String.Concat(romaneio.cd_cooperativa.ToString, " - ", romaneio.nm_cooperativa.ToString)
                lbl_nr_nota_fiscal.Text = romaneio.nr_nota_fiscal.ToString
                lbl_dt_saida_nota.Text = DateTime.Parse(romaneio.dt_saida_nota.ToString).ToString
                lbl_nm_item.Text = romaneio.nm_item.ToString
                lbl_nr_valor_nota.Text = FormatCurrency(romaneio.nr_valor_nota_fiscal, 2)
                lbl_nr_peso_liquido_nota.Text = romaneio.nr_peso_liquido_nota.ToString
            End If
            If romaneio.st_romaneio_transbordo = "S" Then
                ViewState.Item("cooperativa") = "N"
                tr_caderneta.Visible = False
                tr_caderneta2.Visible = False
                tr_pnl_dados_cooperativa.Visible = False
                'tr_pnl_nota_fiscal_transferencia.Visible = True
                tr_pnl_nota_fiscal_transferencia.Visible = False
                lbl_nr_nota_fiscal_transf.Text = romaneio.nr_nota_fiscal_transf
                lbl_nr_serie_nota_transf.Text = romaneio.nr_serie_nota_fiscal_transf
                If Not (romaneio.dt_emissao_nota_transf Is Nothing) Then
                    If Not (romaneio.dt_emissao_nota_transf.ToString.Equals(String.Empty)) Then
                        lbl_dt_emissao_nota_transf.Text = Format(DateTime.Parse(romaneio.dt_emissao_nota_transf), "dd/MM/yyyy").ToString
                    End If
                End If
                If romaneio.nr_peso_liquido_nota_transf > 0 Then
                    lbl_nr_peso_nota_transf.Text = romaneio.nr_peso_liquido_nota_transf
                End If
                tr_transbordo.Visible = True
                lbl_nr_peso_liquido_caderneta.Text = FormatNumber(romaneio.nr_peso_liquido_caderneta, 0).ToString
                lbl_id_item.Text = romaneio.nm_item

            End If

            lbl_romaneio.Text = romaneio.id_romaneio.ToString
            lbl_estabelecimento.Text = romaneio.ds_estabelecimento.ToString
            lbl_st_romaneio.Text = romaneio.nm_st_romaneio.ToString
            lbl_transportador.Text = romaneio.ds_transportador.ToString
            lbl_motorista.Text = romaneio.nm_motorista
            lbl_cd_cnh.Text = romaneio.cd_cnh
            lbl_dt_entrada.Text = Format(DateTime.Parse(romaneio.dt_hora_entrada), "dd/MM/yyyy HH:mm").ToString
            If Not (romaneio.dt_hora_saida Is Nothing) Then
                If Not (romaneio.dt_hora_saida.ToString.Equals(String.Empty)) Then
                    txt_dt_hora_saida.Text = DateTime.Parse(romaneio.dt_hora_saida.ToString).ToString
                End If
            End If
            If Not romaneio.ds_linha Is Nothing Then
                lbl_linha.Text = romaneio.ds_linha.ToString
            End If
            lbl_placa.Text = romaneio.ds_placa.ToString
            lbl_tara.Text = FormatNumber(romaneio.nr_tara, 0).ToString
            lbl_nr_pesagem_inicial.Text = FormatNumber(romaneio.nr_pesagem_inicial, 0).ToString
            If Not romaneio.dt_pesagem_inicial Is Nothing Then
                lbl_dt_pesagem_inicial.Text = Format(DateTime.Parse(romaneio.dt_pesagem_inicial), "dd/MM/yyyy HH:mm")
            End If
            ' Themis - 15/05/2012 - adri - chamado 1547 - i
            If Not romaneio.dt_pesagem_intermediaria Is Nothing Then
                txt_hr_inter.Text = Format(DateTime.Parse(romaneio.dt_pesagem_intermediaria), "HH")
                txt_mm_inter.Text = DatePart(DateInterval.Minute, DateTime.Parse(romaneio.dt_pesagem_intermediaria))
                txt_dt_pesagem_intermediaria.Text = Format(DateTime.Parse(romaneio.dt_pesagem_intermediaria), "dd/MM/yyyy")
            Else
                txt_hr_inter.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_inter.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
                txt_dt_pesagem_intermediaria.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")

            End If
            ' Themis - 15/05/2012 - adri - chamado 1547 - f
            If Not romaneio.dt_pesagem_final Is Nothing Then
                txt_hr_final.Text = Format(DateTime.Parse(romaneio.dt_pesagem_final), "HH")
                txt_mm_final.Text = DatePart(DateInterval.Minute, DateTime.Parse(romaneio.dt_pesagem_final))
                txt_dt_pesagem_final.Text = Format(DateTime.Parse(romaneio.dt_pesagem_final), "dd/MM/yyyy")
            Else
                txt_hr_final.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_final.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
                txt_dt_pesagem_final.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")

            End If
            If Not romaneio.dt_hora_saida Is Nothing Then
                txt_hr_saida.Text = Format(DateTime.Parse(romaneio.dt_hora_saida), "HH")
                txt_mm_saida.Text = DatePart(DateInterval.Minute, DateTime.Parse(romaneio.dt_hora_saida))
                txt_dt_hora_saida.Text = Format(DateTime.Parse(romaneio.dt_hora_saida), "dd/MM/yyyy")
            Else
                txt_hr_saida.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_saida.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
                txt_dt_hora_saida.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            End If
            txt_nr_pesagem_intermediaria.Text = romaneio.nr_pesagem_intermediaria   ' Projeto Themis - 15/05/2012 - chamado 1547
            txt_nr_pesagem_final.Text = romaneio.nr_pesagem_final
            If Not txt_nr_pesagem_final.Text.Equals(String.Empty) Then
                lbl_nr_peso_liquido_balanca.Text = CLng(CDbl(lbl_nr_pesagem_inicial.Text) - CDbl(txt_nr_pesagem_final.Text))
            End If

            loadCampos()



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub updateData()
        If Page.IsValid Then
            Try


                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                If romaneio.id_st_romaneio <> 4 Then
                    romaneio.nr_pesagem_final = Convert.ToDecimal(txt_nr_pesagem_final.Text)
                    romaneio.dt_hora_saida = Convert.ToDateTime(Me.txt_dt_hora_saida.Text & " " & txt_hr_saida.Text & ":" & txt_mm_saida.Text & ":00")
                    romaneio.dt_pesagem_final = Convert.ToDateTime(Me.txt_dt_pesagem_final.Text & " " & txt_hr_final.Text & ":" & txt_mm_final.Text & ":00")
                    If Not (lbl_nr_peso_liquido_balanca.Text.Trim.Equals(String.Empty)) Then
                        romaneio.nr_peso_liquido = Convert.ToDecimal(lbl_nr_peso_liquido_balanca.Text)
                    End If
                    romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                    romaneio.id_modificador = Session("id_login")
                    'romaneio.id_st_romaneio = 4 'Status Fechado   

                    ''Busca dados do compartimento where status seja <> APROVADO
                    'Dim romaneiocomp As New Romaneio_Compartimento
                    ' romaneiocomp.id_romaneio = romaneio.id_romaneio
                    'Dim lerro As Boolean
                    'lerro = False
                    'Dim dsromaneiocomp As DataSet = romaneiocomp.getRomaneioCompartimentosRejeitados

                    ''Se não ha linhas com situação Positiva 
                    'If (dsromaneiocomp.Tables(0).Rows.Count = 0) Then
                    '    If romaneio.id_st_analise_global = 2 Then 'Se análise global for Positiva
                    '        messageControl.Alert("O Romaneio não pode ser fechado pois há divergências nos registros de análises: todos os registros de compartimentos estão NEGATIVOS enquanto a Análise Global está POSITIVA.")
                    '        lerro = True
                    '    End If
                    'Else 'se tem linhas positiva
                    '    If romaneio.id_st_analise_global = 1 Then 'Se análise global for Negativa
                    '        lerro = True
                    '        messageControl.Alert("O Romaneio não pode ser fechado pois há divergências nos registros de análises: há registros de compartimentos POSITIVO enquanto a Análise Global está NEGATIVA.")
                    '    End If
                    'End If
                    'UnidadeProducao
                    'If lerro = False Then
                    '    Dim romaneiouprod As New Romaneio_Comp_UProducao
                    '    romaneiouprod.id_romaneio = romaneio.id_romaneio
                    '    Dim dsromaneiouprod As DataSet = romaneiouprod.getRomaneioUProducaoRejeitados
                    '    If (dsromaneiocomp.Tables(0).Rows.Count = 0) Then
                    '        If romaneio.id_st_analise_global = 2 Then 'Se análise global for Positiva
                    '            messageControl.Alert("O Romaneio não pode ser fechado pois há divergências nos registros de análises: todos os registros de produtores estão NEGATIVOS enquanto a Análise Global está POSITIVA.")
                    '            lerro = True
                    '        End If
                    '    Else 'se tem linhas positiva
                    '        If romaneio.id_st_analise_global = 1 Then 'Se análise global for Negativa
                    '            lerro = True
                    '            messageControl.Alert("O Romaneio não pode ser fechado pois há divergências nos registros de análises: há registros de Produtores POSITIVOS enquanto a Análise Global está NEGATIVA.")
                    '        End If
                    '    End If
                    'End If
                    'Se não ha erros

                    'If lerro = False Then

                    ' 16/10/2008 - i
                    'romaneio.FecharRomaneio()
                    romaneio.nr_peso_leiturabalanca_final = ViewState.Item("nr_peso_leiturabalanca_final")   ' Projeto Themis - 15/05/2012 - chamado 1547
                    romaneio.dt_leiturabalanca_final = ViewState.Item("dt_leiturabalanca_final")             ' Projeto Themis - 15/05/2012 - chamado 1547
                    romaneio.updateRomaneioPesagemFinal()  ' Só atualiza dados da pesagem mas não fecha

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 61
                    usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 
                    ' 16/10/2008 - f
                    messageControl.Alert("Registro alterado com sucesso.")
                    loadData()
                    'End If
                Else
                    messageControl.Alert("Este romaneio já está fechado.")
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_romaneio_pesagem_final.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_pesagem_final.aspx")


    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub
    Private Sub loadCampos()

        Dim hascampos As Boolean

        hascampos = False
        If Not (customPage.getFilterValue("romaneiofechar", txt_dt_hora_saida.ID).Equals(String.Empty)) Then
            txt_dt_hora_saida.Text = customPage.getFilterValue("romaneiofechar", txt_dt_hora_saida.ID)
            hascampos = True
        End If

        If Not (customPage.getFilterValue("romaneiofechar", txt_hr_saida.ID).Equals(String.Empty)) Then
            txt_hr_saida.Text = customPage.getFilterValue("romaneiofechar", txt_hr_saida.ID)
            hascampos = True
        End If

        If Not (customPage.getFilterValue("romaneiofechar", txt_mm_saida.ID).Equals(String.Empty)) Then
            txt_mm_saida.Text = customPage.getFilterValue("romaneiofechar", txt_mm_saida.ID)
            hascampos = True
        End If

        If Not (customPage.getFilterValue("romaneiofechar", txt_dt_pesagem_final.ID).Equals(String.Empty)) Then
            txt_dt_pesagem_final.Text = customPage.getFilterValue("romaneiofechar", txt_dt_pesagem_final.ID)
            hascampos = True
        End If

        If Not (customPage.getFilterValue("romaneiofechar", txt_hr_final.ID).Equals(String.Empty)) Then
            txt_hr_final.Text = customPage.getFilterValue("romaneiofechar", txt_hr_final.ID)
            hascampos = True
        End If

        If Not (customPage.getFilterValue("romaneiofechar", txt_mm_saida.ID).Equals(String.Empty)) Then
            txt_mm_final.Text = customPage.getFilterValue("romaneiofechar", txt_mm_final.ID)
            hascampos = True
        End If
        If Not (customPage.getFilterValue("romaneiofechar", txt_nr_pesagem_final.ID).Equals(String.Empty)) Then
            txt_nr_pesagem_final.Text = customPage.getFilterValue("romaneiofechar", txt_nr_pesagem_final.ID)
            hascampos = True
        End If

        If Not (customPage.getFilterValue("romaneiofechar", lbl_nr_peso_liquido_balanca.ID).Equals(String.Empty)) Then
            lbl_nr_peso_liquido_balanca.Text = customPage.getFilterValue("romaneiofechar", lbl_nr_peso_liquido_balanca.ID)
            hascampos = True
        End If


        If (hascampos) Then
            customPage.clearFilters("romaneiofechar")
        End If

    End Sub
    Private Sub saveCampos()

        Try

            customPage.setFilter("romaneiofechar", txt_dt_hora_saida.ID, txt_dt_hora_saida.Text)
            customPage.setFilter("romaneiofechar", txt_hr_saida.ID, txt_hr_saida.Text)
            customPage.setFilter("romaneiofechar", txt_mm_saida.ID, txt_mm_saida.Text)
            customPage.setFilter("romaneiofechar", txt_dt_pesagem_final.ID, txt_dt_pesagem_final.Text)
            customPage.setFilter("romaneiofechar", txt_hr_final.ID, txt_hr_final.Text)
            customPage.setFilter("romaneiofechar", txt_mm_final.ID, txt_mm_final.Text)
            customPage.setFilter("romaneiofechar", txt_nr_pesagem_final.ID, txt_nr_pesagem_final.Text)
            customPage.setFilter("romaneiofechar", lbl_nr_peso_liquido_balanca.ID, lbl_nr_peso_liquido_balanca.Text)


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub txt_nr_pesagem_final_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_nr_pesagem_final.TextChanged

        If Not txt_nr_pesagem_final.Text.Equals(String.Empty) Then
            'atualizarResumo()
            lbl_nr_peso_liquido_balanca.Text = CLng(CDec(lbl_nr_pesagem_inicial.Text) - CDec(FormatNumber(txt_nr_pesagem_final.Text, 0)))
        Else
            lbl_nr_peso_liquido_balanca.Text = String.Empty

        End If
    End Sub

    Protected Sub btn_balanca_final_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_balanca_final.Click

        '  adri 26/03/2012 - Projeto Themis - Leitura da Balança através do web service WSBalanca - i
        Try

            ' 21/03/2012 - Projeto Themis - i
            Dim iPeso As Int32
            Dim sServer As String
            Dim iPorta As Integer
            Dim iTimeout As Integer

            'Parametros que devm ser passados para a função
            Dim balanca As New Balanca(Convert.ToInt32(cbo_balanca_final.SelectedValue))

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
                Me.txt_nr_pesagem_final.Text = iPeso.ToString()
                ViewState.Item("nr_peso_leiturabalanca_final") = iPeso   ' 15/05/2012 - chamado 1547
                ViewState.Item("dt_leiturabalanca_final") = Format(DateTime.Parse(Now), "dd/MM/yyyy HH:mm")
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
        '  adri 26/03/2012 - Projeto Themis - Leitura da Balança através do web service WSBalanca - f


    End Sub

    Protected Sub btn_salvar_pesagem_intermediaria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salvar_pesagem_intermediaria.Click
        updateData_PesagemIntermediaria()   '  14/05/2012 - chamado 1547
    End Sub

    '  14/05/2012 - chamado 1547 - i
    Private Sub updateData_PesagemIntermediaria()
        If Page.IsValid Then
            Try


                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio")))

                If romaneio.id_st_romaneio <> 4 Then
                    romaneio.nr_pesagem_intermediaria = Convert.ToDecimal(txt_nr_pesagem_intermediaria.Text)
                    romaneio.dt_pesagem_intermediaria = Convert.ToDateTime(Me.txt_dt_pesagem_intermediaria.Text & " " & txt_hr_inter.Text & ":" & txt_mm_inter.Text & ":00")
                    romaneio.nr_peso_leiturabalanca_inter = Convert.ToDecimal(ViewState.Item("nr_peso_leiturabalanca_inter"))  ' Peso original lido na balança
                    romaneio.dt_leiturabalanca_inter = ViewState.Item("dt_leiturabalanca_inter")
                    romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                    romaneio.id_modificador = Session("id_login")
                    romaneio.updateRomaneioPesagemIntermediaria()  ' Só atualiza dados da pesagem mas não fecha
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteração
                    usuariolog.id_menu_item = 61
                    usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    messageControl.Alert("Dados da Pesagem Intermediária alterados com sucesso.")
                    loadData()
                Else
                    messageControl.Alert("Este romaneio já está fechado.")
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    '  14/05/2012 - chamado 1547 - f

    Protected Sub btn_balanca_intermediaria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_balanca_intermediaria.Click
        '  adri 14/05/2012 - chamado 1547 - i
        Try

            Dim iPeso As Int32
            Dim sServer As String
            Dim iPorta As Integer
            Dim iTimeout As Integer

            'Parametros que devm ser passados para a função
            Dim balanca As New Balanca(Convert.ToInt32(cbo_balanca_intermediaria.SelectedValue))

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
                Me.txt_nr_pesagem_intermediaria.Text = iPeso.ToString()
                ViewState.Item("nr_peso_leiturabalanca_inter") = iPeso
                ViewState.Item("dt_leiturabalanca_inter") = Format(DateTime.Parse(Now), "dd/MM/yyyy HH:mm")
                lbl_aguarde_inter.CssClass = "aguardenormal"
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


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        '  adri 14/05/2012 - chamado 1547 - i

    End Sub
End Class
