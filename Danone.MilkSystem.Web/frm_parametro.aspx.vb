Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_parametro
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_parametro.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 32
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
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
            cbo_situacao.Enabled = False

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try

            'Dim parametro As New Parametro(1)
            Dim parametro As New Parametro

            'txt_nr_perc_adto.Text = parametro.nr_perc_adto  ' 23/09/2009 - Chamado 446 (esta coluna não deve mais ser utilizada)

            txt_nr_deflator.Text = parametro.nr_deflator

            'txt_nr_perc_limite1q_cc.Text = parametro.nr_perc_limite1q_cc
            txt_nr_perc_limite1q_cc.Text = parametro.nr_perc_limite1q_cc  ' 23/09/2009 - Chamado 446 (esta coluna deve ser utilizada)

            txt_nr_perc_limite2q_cc.Text = parametro.nr_perc_limite2q_cc

            txt_nr_politica_parcelas.Text = parametro.nr_politica_parcelas 'fran 08/2014 fase 3


            If (parametro.id_situacao > 0) Then
                cbo_situacao.SelectedValue = parametro.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = parametro.id_modificador.ToString()
            lbl_dt_modificacao.Text = parametro.dt_modificacao.ToString()

            'fran 08/2017 i
            Dim antecipacao As New ParametroAntecipacao
            antecipacao.id_situacao = 1
            Dim ds_antecipacao As DataSet = antecipacao.getParametroAntecipacaoByFilters

            If ds_antecipacao.Tables(0).Rows.Count > 0 Then
                With ds_antecipacao.Tables(0).Rows(0)
                    txt_dt_referencia.Text = .Item("ds_referencia").ToString
                    txt_nr_dias_antecipacao.Text = .Item("nr_dias_antecipacao").ToString
                End With
            End If
            'fran 08/2017 f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()

        Try

            ''Assume 100 - X, caso apenas um dos limites esteja preenchido, sendo x o valor do limite preenchido.
            'If Not (txt_nr_perc_limite1q_cc.Text.Trim.Equals(String.Empty)) And _
            '   (txt_nr_perc_limite2q_cc.Text.Trim.Equals(String.Empty)) Then
            '    txt_nr_perc_limite2q_cc.Text = Convert.ToString(100 - Convert.ToDouble(txt_nr_perc_limite1q_cc.Text))
            'End If

            'If Not (txt_nr_perc_limite2q_cc.Text.Trim.Equals(String.Empty)) And _
            '   (txt_nr_perc_limite1q_cc.Text.Trim.Equals(String.Empty)) Then
            '    txt_nr_perc_limite1q_cc.Text = Convert.ToString(100 - Convert.ToDouble(txt_nr_perc_limite2q_cc.Text))
            'End If

            ''Dispara mensagem caso soma dos limites não totalize 100
            'If (txt_nr_perc_limite1q_cc.Text.Trim <> "") And (txt_nr_perc_limite2q_cc.Text.Trim <> "") Then
            '    If Not ((Convert.ToDouble(txt_nr_perc_limite1q_cc.Text) + _
            '       Convert.ToDouble(txt_nr_perc_limite2q_cc.Text)).Equals(100)) Then
            '        messageControl.Alert("Soma das Quinzenas de Limite Clube Compra deve equivaler a 100.")
            '        Exit Sub
            '    End If
            'End If
            If Page.IsValid Then

                Dim parametro As New Parametro()

                If Not (txt_nr_perc_limite1q_cc.Text.Trim().Equals(String.Empty)) Then
                    'parametro.nr_perc_adto = Convert.ToDecimal(txt_nr_perc_limite1q_cc.Text)
                    parametro.nr_perc_limite1q_cc = Convert.ToDecimal(txt_nr_perc_limite1q_cc.Text)  ' 23/09/2009 - Chamado 446 (esta coluna deve ser utilizada)
                Else
                    'parametro.nr_perc_adto = 0
                    parametro.nr_perc_limite1q_cc = 0   ' 23/09/2009 - Chamado 446 (esta coluna deve ser utilizada)
                End If

                If Not (txt_nr_deflator.Text.Trim().Equals(String.Empty)) Then
                    parametro.nr_deflator = Convert.ToDecimal(txt_nr_deflator.Text)
                Else
                    parametro.nr_deflator = 0
                End If

                'If Not (txt_nr_perc_limite1q_cc.Text.Trim().Equals(String.Empty)) Then
                '    parametro.nr_perc_limite1q_cc = Convert.ToDecimal(txt_nr_perc_limite1q_cc.Text)
                'End If

                If Not (txt_nr_perc_limite2q_cc.Text.Trim().Equals(String.Empty)) Then
                    parametro.nr_perc_limite2q_cc = Convert.ToDecimal(txt_nr_perc_limite2q_cc.Text)
                Else
                    parametro.nr_perc_limite2q_cc = 0
                End If

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    parametro.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If

                parametro.nr_politica_parcelas = txt_nr_politica_parcelas.Text 'fran 08/2014 fase 3

                parametro.id_modificador = Session("id_login")

                parametro.updateParametro()

                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'atualizacso
                usuariolog.id_menu_item = 32
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                If Not ViewState.Item("acao").ToString.Equals(String.Empty) Then
                    Dim antecipacao As New ParametroAntecipacao
                    antecipacao.dt_referencia = DateTime.Parse("01/" & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
                    antecipacao.nr_dias_antecipacao = txt_nr_dias_antecipacao.Text
                    antecipacao.id_modificador = Session("id_login")

                    If ViewState.Item("acao").ToString = "I" Then
                        antecipacao.insertParametroAntecipacao()
                        'fran 08/12/2020 i dango
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 4 'inclusao
                        usuariolog.ds_nm_processo = "Parâmetros - Antecipação"
                        usuariolog.id_menu_item = 32
                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango
                    End If
                    If ViewState.Item("acao").ToString = "U" Then
                        antecipacao.updateParametroAntecipacao()
                        'fran 08/12/2020 i dango
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alteracao
                        usuariolog.ds_nm_processo = "Parâmetros - Antecipação"
                        usuariolog.id_menu_item = 32
                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango                    
                    End If
                End If


                messageControl.Alert("Registro alterado com sucesso.")
                loadData()

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub

    Protected Sub cv_referencia_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_referencia.ServerValidate
        Try
            Dim lmsg As String
            Dim antecipacao As New ParametroAntecipacao
            Dim dsantecipacao As DataSet
            Dim lcalculodefinitivo As String
            args.IsValid = True
            ViewState.Item("acao") = String.Empty 'indica que não deve atualizar, nem incluir antecipacao

            Dim calculodefinitivo As New CalculoProdutor
            calculodefinitivo.dt_referencia_start = DateTime.Parse("01/" & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
            calculodefinitivo.dt_referencia_end = DateTime.Now.ToString("dd/MM/yyyy")
            If CDate(calculodefinitivo.dt_referencia_end) < CDate(calculodefinitivo.dt_referencia_start) Then
                calculodefinitivo.dt_referencia_end = calculodefinitivo.dt_referencia_start
            End If
            lcalculodefinitivo = calculodefinitivo.getCalculoDefinitivoByPeriodo

            If (lcalculodefinitivo Is Nothing) Then
                lcalculodefinitivo = String.Empty
            End If

            'busca todas as referencia existentes maiore ou igual a informada na tela (referencias posteriores ou ela mesma)
            antecipacao.id_situacao = 1 'ativo
            antecipacao.dt_referencia = DateTime.Parse("01/" & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
            dsantecipacao = antecipacao.getParametroAntecipacaoConsReferencia
            'tem referencia posterior ou ela mesma?
            If dsantecipacao.Tables(0).Rows.Count > 0 Then
                'se a data informada é a mesma que a data  cadastro
                If CDate(dsantecipacao.Tables(0).Rows(0).Item("dt_referencia").ToString) = CDate(antecipacao.dt_referencia) Then
                    'verifuca se dias de antecipacao é o mesmo , se for o mesmo não esta alterando se nao for o mesmo exibe msg que já existe referencia informada
                    If CInt(dsantecipacao.Tables(0).Rows(0).Item("nr_dias_antecipacao").ToString) <> CInt(txt_nr_dias_antecipacao.Text) Then
                        'se existe calculo definitivo
                        If Not lcalculodefinitivo.Equals(String.Empty) Then
                            'se calculo definitivo for maior ou igual a referencia informada
                            If CDate(lcalculodefinitivo) >= CDate(antecipacao.dt_referencia) Then
                                lmsg = "O número de dias para antecipação de cálculo informado não pode ser atualizado porque já existe cálculo definitivo para a referência. Altere a referência de validade para incluir o novo parametro de dias de antecipação."
                                args.IsValid = False
                            Else
                                ViewState.Item("acao") = "U" 'indica que deve atualizar  parametro
                            End If
                        Else 'se ainda nao tem calculo definitivo
                            ViewState.Item("acao") = "U" 'indica que deve atualizar  parametro
                        End If
                    End If

                Else
                    'se referencia é maior que a informada
                    lmsg = "Já existe referência maior que a informada no cadastro de parâmetro de antecipação de cálculo."
                    args.IsValid = False
                End If
            Else 'nao achou referencia posterior
                'verifica se a referencia informada ja tem calculo definitivo
                If Not lcalculodefinitivo.Equals(String.Empty) AndAlso CDate(lcalculodefinitivo) >= CDate(antecipacao.dt_referencia) Then
                    lmsg = "Esta referência não pode ser incluída em parâmetros de antecipação porque já foi efetuado cálculo definitivo para ela."
                    args.IsValid = False
                Else
                    ViewState.Item("acao") = "I" 'indica que não deve incluir novo parametro
                End If
            End If


            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
