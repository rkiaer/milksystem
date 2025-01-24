Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math


Partial Class frm_romaneio_saida_pesagem_balanca

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_romaneio_saida_pesagem_balanca.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try


            If Not (Request("id_romaneio_saida") Is Nothing) Then
                ViewState.Item("id_romaneio_saida") = Request("id_romaneio_saida")

                Dim romaneio As New RomaneioSaida(ViewState.Item("id_romaneio_saida"))

                Dim balanca As New Balanca

                balanca.id_estabelecimento = romaneio.id_estabelecimento  ' Traz somente as balanças do estabelecimento
                cbo_balanca_final.DataSource = balanca.getBalancaByFilters()
                cbo_balanca_final.DataTextField = "nm_balanca"
                cbo_balanca_final.DataValueField = "id_balanca"
                cbo_balanca_final.DataBind()
                cbo_balanca_final.Items.Insert(0, New ListItem("[Selecione]", String.Empty)) 'fran 22/05/2012

                ' carregar os combos inicial e intermediária
                balanca.id_estabelecimento = romaneio.id_estabelecimento  ' Traz somente as balanças do estabelecimento
                cbo_balanca_inicial.DataSource = balanca.getBalancaByFilters()
                cbo_balanca_inicial.DataTextField = "nm_balanca"
                cbo_balanca_inicial.DataValueField = "id_balanca"
                cbo_balanca_inicial.DataBind()
                cbo_balanca_inicial.Items.Insert(0, New ListItem("[Selecione]", String.Empty)) 'fran 22/05/2012

                balanca.id_estabelecimento = romaneio.id_estabelecimento  ' Traz somente as balanças do estabelecimento
                cbo_balanca_intermediaria.DataSource = balanca.getBalancaByFilters()
                cbo_balanca_intermediaria.DataTextField = "nm_balanca"
                cbo_balanca_intermediaria.DataValueField = "id_balanca"
                cbo_balanca_intermediaria.DataBind()
                cbo_balanca_intermediaria.Items.Insert(0, New ListItem("[Selecione]", String.Empty)) 'fran 22/05/2012

                ViewState.Item("id_usuario_leiturabalanca_inter") = 0
                ViewState.Item("dt_leiturabalanca_inter") = ""
                ViewState.Item("nr_peso_leiturabalanca_inter") = 0

                ViewState.Item("id_usuario_leiturabalanca_inicial") = 0
                ViewState.Item("dt_leiturabalanca_inicial") = ""
                ViewState.Item("nr_peso_leiturabalanca_inicial") = 0

                ViewState.Item("id_usuario_leiturabalanca_final") = 0
                ViewState.Item("dt_leiturabalanca_final") = ""
                ViewState.Item("nr_peso_leiturabalanca_final") = 0

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

            Dim id_romaneio As Int32 = Convert.ToInt32(ViewState.Item("id_romaneio_saida").ToString)
            Dim romaneio As New RomaneioSaida(id_romaneio)

            lbl_romaneio.Text = id_romaneio.ToString
            lbl_estabelecimento.Text = romaneio.ds_estabelecimento.ToString
            lbl_st_romaneio.Text = romaneio.nm_situacao_romaneio_saida.ToString
            lbl_transportador.Text = romaneio.nm_transportador.ToString
            If romaneio.id_motorista > 0 Then
                lbl_motorista.Text = romaneio.nm_motorista_cadastro
                lbl_cd_cnh.Text = romaneio.cd_cnh_cadastro
            Else
                lbl_motorista.Text = romaneio.nm_motorista
                lbl_cd_cnh.Text = romaneio.cd_cnh
            End If

            lbl_tipoleite.Text = romaneio.nm_item
            lbl_dt_entrada.Text = Format(DateTime.Parse(romaneio.dt_hora_entrada), "dd/MM/yyyy HH:mm").ToString
            lbl_placa.Text = romaneio.ds_placa.ToString
            lbl_tara.Text = FormatNumber(romaneio.nr_tara, 0).ToString

            lbl_destino.Text = romaneio.nm_cooperativa
            lbl_volume_estimado.Text = (CDec(romaneio.nr_volume_estimado)).ToString("######")

            '==========================
            ' Dados da Pesagem Inicial
            '==========================
            If Not romaneio.dt_pesagem_inicial Is Nothing Then
                txt_hr_ini_pesageminicial.Text = Format(DateTime.Parse(romaneio.dt_pesagem_inicial), "HH")
                txt_mm_ini_pesageminicial.Text = DatePart(DateInterval.Minute, DateTime.Parse(romaneio.dt_pesagem_inicial))
                txt_dt_pesagem_inicial.Text = Format(DateTime.Parse(romaneio.dt_pesagem_inicial), "dd/MM/yyyy") ' 09/05/2012 - chamado 1547
            Else
                txt_hr_ini_pesageminicial.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_ini_pesageminicial.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
                txt_dt_pesagem_inicial.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")
            End If
            txt_nr_pesagem_inicial.Text = romaneio.nr_pesagem_inicial

            '==========================
            ' Dados da Pesagem Intermediária
            '==========================
            ' Fazer (criar os campos na tabela e classe romaneio)

            ''If Not romaneio.dt_pesagem_intermediaria Is Nothing Then
            ''    txt_hr_ini_intermediaria.Text = Format(DateTime.Parse(romaneio.dt_pesagem_intermediaria), "HH")
            ''    txt_mm_ini_intermediaria.Text = DatePart(DateInterval.Minute, DateTime.Parse(romaneio.dt_pesagem_intermediaria))
            ''    txt_dt_pesagem_intermediaria.Text = Format(DateTime.Parse(romaneio.dt_pesagem_intermediaria), "dd/MM/yyyy")
            ''Else
            ''    txt_hr_ini_intermediaria.Text = Format(DateTime.Parse(Now), "HH")
            ''    txt_mm_ini_intermediaria.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
            ''    txt_dt_pesagem_intermediaria.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")

            ''End If
            ''txt_nr_pesagem_intermediaria.Text = romaneio.nr_pesagem_intermediaria



            '==========================
            ' Dados da Pesagem Final
            '==========================
            If Not romaneio.dt_pesagem_final Is Nothing Then
                txt_hr_ini_pesagemfinal.Text = Format(DateTime.Parse(romaneio.dt_pesagem_final), "HH")
                txt_mm_ini_pesagemfinal.Text = DatePart(DateInterval.Minute, DateTime.Parse(romaneio.dt_pesagem_final))
                txt_dt_pesagem_final.Text = Format(DateTime.Parse(romaneio.dt_pesagem_final), "dd/MM/yyyy")
            Else
                txt_hr_ini_pesagemfinal.Text = Format(DateTime.Parse(Now), "HH")
                txt_mm_ini_pesagemfinal.Text = DatePart(DateInterval.Minute, DateTime.Parse(Now))
                txt_dt_pesagem_final.Text = Format(DateTime.Parse(Now), "dd/MM/yyyy")

            End If
            txt_nr_pesagem_final.Text = romaneio.nr_pesagem_final

            ' 09/05/2012 - chamado 1547 - f


            ' 09/05/2012 - chamado 1547 (desabilitado - não exibir peso liquido da balança - tela só de atualização) - i
            'If Not txt_nr_pesagem_final.Text.Equals(String.Empty) Then
            '    lbl_nr_peso_liquido_balanca_final.Text = CLng(CDbl(lbl_nr_pesagem_inicial.Text) - CDbl(txt_nr_pesagem_final.Text))
            'End If
            ' 09/05/2012 - chamado 1547 (desabilitado - não exibir peso liquido da balança - tela só de atualização) - f



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub updatePesagemFinal()
        If Page.IsValid Then
            Try


                Dim romaneio As New RomaneioSaida(Convert.ToInt32(ViewState.Item("id_romaneio_saida")))

                'fran 22/05/2012 i o romaneio pode estar fechado desde que o registro de exportação de batch ainda nao tenha sido realizado
                'If (romaneio.id_situacao_romaneio_saida <> 9) Or (romaneio.id_situacao_romaneio_saida = 9  Then
                If (romaneio.id_situacao_romaneio_saida < 9) Then 'se ainda nao esta finalizado
                    'fran 22/05/2012 f o romaneio pode estar fechado desde que o registro de exportação de batch ainda nao tenha sido realizado

                    ' Dados da Pesagem Final
                    romaneio.nr_pesagem_final = Convert.ToDecimal(txt_nr_pesagem_final.Text)
                    romaneio.dt_pesagem_final = Convert.ToDateTime(Me.txt_dt_pesagem_final.Text & " " & txt_hr_ini_pesagemfinal.Text & ":" & txt_mm_ini_pesagemfinal.Text & ":00")

                    'romaneio.id_usuario_leiturabalanca_final = ViewState.Item("id_usuario_leiturabalanca_final")
                    romaneio.dt_leiturabalanca_final = ViewState.Item("dt_leiturabalanca_final")
                    romaneio.nr_peso_leiturabalanca_final = ViewState.Item("nr_peso_leiturabalanca_final")

                    'fran 22/05/2012 i
                    ' deve atualizar peso liquido
                    'se veio de entrada entao chegou vazio para carregar, entao peso liquido é final - inicial
                    If romaneio.st_solicitacao_entrada_transportador.ToString.Equals("S") Then
                        'If romaneio.nr_pesagem_inicial > 0 Then
                        '    romaneio.nr_peso_liquido = romaneio.nr_pesagem_inicial - romaneio.nr_pesagem_final
                        'End If
                        If romaneio.nr_pesagem_final > 0 Then
                            romaneio.nr_peso_liquido = romaneio.nr_pesagem_final - romaneio.nr_pesagem_inicial
                        End If
                    Else
                        'se é caminhao de romaneio que ja estava carregado

                        If romaneio.nr_pesagem_final > 0 Then
                            romaneio.nr_peso_liquido = romaneio.nr_pesagem_final - romaneio.nr_tara
                        End If
                    End If
                    'fran 22/05/2012 f deve atualizar peso liquido

                    romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
                    romaneio.id_modificador = Session("id_login")
                    romaneio.updateRomaneioSaidaPesagemFinal()  ' 

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 249
                    usuariolog.ds_nm_processo = "Atualizar Pesagem - Pesagem Final"
                    usuariolog.id_nr_processo = ViewState.Item("id_romaneio_saida").ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_romaneio_saida").ToString

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    messageControl.Alert("Dados da Pesagem Final atualizados com sucesso.")
                    loadData()
                Else
                    messageControl.Alert("Este romaneio de saída já está fechado.")
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Private Sub updatePesagemInicial()
        If Page.IsValid Then
            Try


                Dim romaneio As New RomaneioSaida(Convert.ToInt32(ViewState.Item("id_romaneio_saida")))

                If (romaneio.id_situacao_romaneio_saida <> 9) Then
                    'fran 22/05/2012 f o romaneio pode estar fechado desde que o registro de exportação de batch ainda nao tenha sido realizado

                    ' Dados da Pesagem Inicial

                    romaneio.nr_pesagem_inicial = Convert.ToDecimal(txt_nr_pesagem_inicial.Text)
                    romaneio.dt_pesagem_inicial = Convert.ToDateTime(Me.txt_dt_pesagem_inicial.Text & " " & txt_hr_ini_pesageminicial.Text & ":" & txt_mm_ini_pesageminicial.Text & ":00")

                    ' deve atualizar peso liquido
                    'If romaneio.nr_pesagem_final > 0 Then
                    '    romaneio.nr_peso_liquido = romaneio.nr_pesagem_inicial - romaneio.nr_pesagem_final
                    'End If
                    If romaneio.st_solicitacao_entrada_transportador.ToString.Equals("S") Then
                        If romaneio.nr_pesagem_final > 0 Then
                            romaneio.nr_peso_liquido = romaneio.nr_pesagem_final - romaneio.nr_pesagem_inicial
                        End If
                    Else
                        'se é caminhao de romaneio que ja estava carregado

                        If romaneio.nr_pesagem_final > 0 Then
                            romaneio.nr_peso_liquido = romaneio.nr_pesagem_final - romaneio.nr_tara
                        End If
                    End If

                    'romaneio.id_usuario_leiturabalanca_inicial = ViewState.Item("id_usuario_leiturabalanca_inicial")
                    romaneio.dt_leiturabalanca_inicial = ViewState.Item("dt_leiturabalanca_inicial")
                    romaneio.nr_peso_leiturabalanca_inicial = ViewState.Item("nr_peso_leiturabalanca_inicial")

                    romaneio.id_romaneio_saida = Convert.ToInt32(ViewState.Item("id_romaneio_saida"))
                    romaneio.id_modificador = Session("id_login")
                    romaneio.updateRomaneioSaidaPesagemInicial()  ' 

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 249
                    usuariolog.ds_nm_processo = "Atualizar Pesagem - Pesagem Inicial"
                    usuariolog.id_nr_processo = ViewState.Item("id_romaneio_saida").ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_romaneio_saida").ToString

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    messageControl.Alert("Dados da Pesagem inicial atualizados com sucesso.")
                    loadData()
                Else
                    messageControl.Alert("Este romaneio de saída já está fechado.")
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub
    Private Sub updatePesagemIntermediaria()
        If Page.IsValid Then
            Try


                Dim romaneio As New Romaneio(Convert.ToInt32(ViewState.Item("id_romaneio_saida")))

                'fran 22/05/2012 i o romaneio pode estar fechado desde que o registro de exportação de batch ainda nao tenha sido realizado
                'If (romaneio.id_st_romaneio <> 4)  Then
                If (romaneio.id_st_romaneio <> 4) Or (romaneio.id_st_romaneio = 4 And romaneio.id_registro_exportacao_batch = 1) Then
                    'fran 22/05/2012 f o romaneio pode estar fechado desde que o registro de exportação de batch ainda nao tenha sido realizado

                    ' 09/05/2012 - chamado 1547 - i
                    ' Dados da Pesagem intermediaria

                    romaneio.nr_pesagem_intermediaria = Convert.ToDecimal(txt_nr_pesagem_intermediaria.Text)
                    romaneio.dt_pesagem_intermediaria = Convert.ToDateTime(Me.txt_dt_pesagem_intermediaria.Text & " " & txt_hr_ini_intermediaria.Text & ":" & txt_mm_ini_intermediaria.Text & ":00")


                    'romaneio.id_usuario_leiturabalanca_inter = ViewState.Item("id_usuario_leiturabalanca_inter")
                    romaneio.dt_leiturabalanca_inter = ViewState.Item("dt_leiturabalanca_inter")
                    romaneio.nr_peso_leiturabalanca_inter = ViewState.Item("nr_peso_leiturabalanca_inter")

                    romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio"))
                    romaneio.id_modificador = Session("id_login")
                    romaneio.updateRomaneioPesagemIntermediaria()  ' 

                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteracao
                    usuariolog.id_menu_item = 129
                    usuariolog.ds_nm_processo = "Atualizar Pesagem Balança - Pesagem Intermediária"
                    usuariolog.id_nr_processo = ViewState.Item("id_romaneio").ToString
                    usuariolog.nm_nr_processo = ViewState.Item("id_romaneio").ToString

                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    messageControl.Alert("Dados da Pesagem intermediaria atualizados com sucesso.")
                    loadData()
                Else
                    messageControl.Alert("Este romaneio já está fechado.")
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_romaneio_saida_pesagem_balanca.aspx")

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_romaneio_saida_pesagem_balanca.aspx")


    End Sub


    Protected Sub btn_balanca_final_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_balanca_final.Click
        If Page.IsValid Then 'fran 22/05/2012

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
                    lbl_aguarde_final.CssClass = "aguardenormal"

                    'mirella themis chamado 1547
                    'ViewState.Item("id_usuario_leiturabalanca_final") = Session("id_login")
                    ViewState.Item("nr_peso_leiturabalanca_final") = Convert.ToDecimal(txt_nr_pesagem_final.Text)
                    ViewState.Item("dt_leiturabalanca_final") = Format(DateTime.Parse(Now), "dd/MM/yyyy HH:mm")

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

        End If

    End Sub
    Protected Sub btn_balanca_inicial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_balanca_inicial.Click
        If Page.IsValid Then
            '  adri 26/03/2012 - Projeto Themis - Leitura da Balança através do web service WSBalanca - i
            Try

                ' 21/03/2012 - Projeto Themis - i
                Dim iPeso As Int32
                Dim sServer As String
                Dim iPorta As Integer
                Dim iTimeout As Integer

                'Parametros que devm ser passados para a função
                Dim balanca As New Balanca(Convert.ToInt32(cbo_balanca_inicial.SelectedValue))

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
                    Me.txt_nr_pesagem_inicial.Text = iPeso.ToString()
                    lbl_aguarde_inicial.CssClass = "aguardenormal"

                    'mirella themis chamado 1547
                    'ViewState.Item("id_usuario_leiturabalanca_inicial") = Session("id_login")
                    ViewState.Item("dt_leiturabalanca_inicial") = Format(DateTime.Parse(Now), "dd/MM/yyyy HH:mm")
                    ViewState.Item("nr_peso_leiturabalanca_inicial") = Convert.ToDecimal(txt_nr_pesagem_inicial.Text)

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

        End If
    End Sub
    Protected Sub btn_balanca_intermediaria_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_balanca_intermediaria.Click

        If Page.IsValid Then 'fran 22/05/2012

            '  adri 26/03/2012 - Projeto Themis - Leitura da Balança através do web service WSBalanca - i
            Try

                ' 21/03/2012 - Projeto Themis - i
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
                    lbl_aguarde_intermediaria.CssClass = "aguardenormal"

                    'mirella themis chamado 1547
                    'ViewState.Item("id_usuario_leiturabalanca_inter") = Session("id_login")
                    ViewState.Item("dt_leiturabalanca_inter") = Format(DateTime.Parse(Now), "dd/MM/yyyy HH:mm")
                    ViewState.Item("nr_peso_leiturabalanca_inter") = Convert.ToDecimal(txt_nr_pesagem_intermediaria.Text)
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

        End If
    End Sub
    Protected Sub btn_salvar_inicial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salvar_inicial.Click
        updatePesagemInicial()
    End Sub

    Protected Sub btn_salvar_intermediaria_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salvar_intermediaria.Click
        updatePesagemIntermediaria()
    End Sub

    Protected Sub btn_salvar_final_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_salvar_final.Click
        updatePesagemFinal()
    End Sub


End Class
