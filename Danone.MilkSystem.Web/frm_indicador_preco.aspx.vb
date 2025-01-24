Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_indicador_preco
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_indicador_preco.aspx")
        If Not Page.IsPostBack Then
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

            Dim indicadortipo As New IndicadorTipo
            indicadortipo.id_situacao = 1
            cbo_indicador_tipo.DataSource = indicadortipo.getIndicadorTipoByFilters()
            cbo_indicador_tipo.DataTextField = "ds_indicador_tipo"
            cbo_indicador_tipo.DataValueField = "id_indicador_tipo"
            cbo_indicador_tipo.DataBind()
            cbo_indicador_tipo.Items.Insert(0, New ListItem("[Selecione]", "0"))


            If Not (Request("id_indicador_preco") Is Nothing) Then
                ViewState.Item("id_indicador_preco") = Request("id_indicador_preco")
                loadData()
            Else
                cbo_indicador_tipo.Enabled = True
                'txt_dt_referencia.Enabled = True
             End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim indicador As New IndicadorPreco(Convert.ToInt32(ViewState.Item("id_indicador_preco")))

            'indicador preco
            cbo_indicador_tipo.SelectedValue = indicador.id_indicador_tipo.ToString
            cbo_situacao.SelectedValue = indicador.id_situacao.ToString
            txt_dt_referencia.Text = DateTime.Parse(indicador.dt_referencia).ToString("MM/yyyy")
            txt_nr_valor.Text = indicador.nr_valor
            lbl_situacao_indicador_preco.text = indicador.nm_situacao_indicador_preco.ToString
            ViewState.Item("id_situacao_indicador_preco") = indicador.id_situacao_indicador_preco

            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            'CONTROELE VISUAL
            '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            'verifica se o contrato é o primeiro, ou seja apenas um contrato validade existente
            Dim calculodefinitivo As New CalculoProdutor
            calculodefinitivo.dt_referencia_start = DateTime.Parse(indicador.dt_referencia).ToString("dd/MM/yyyy")
            calculodefinitivo.dt_referencia_end = DateTime.Now.ToString("dd/MM/yyyy")
            If CDate(calculodefinitivo.dt_referencia_end) < CDate(calculodefinitivo.dt_referencia_start) Then
                calculodefinitivo.dt_referencia_end = calculodefinitivo.dt_referencia_start
            End If
            ViewState.Item("CalculoDefinitivo") = calculodefinitivo.getCalculoDefinitivoByPeriodo

            If (ViewState.Item("CalculoDefinitivo") Is Nothing) Then
                ViewState.Item("CalculoDefinitivo") = String.Empty
            End If
            'se ja fez calculo definitivo na referencia ou depois dela desabilita tela nao pode fazer nenhuma alteração
            If Not ViewState.Item("CalculoDefinitivo").ToString.Equals(String.Empty) Then
                cbo_indicador_tipo.Enabled = False
                txt_dt_referencia.Enabled = False
                txt_nr_valor.Enabled = False
                cbo_situacao.Enabled = False
                lk_concluir.Enabled = False
                lk_concluirFooter.Enabled = False
            Else
                txt_nr_valor.Enabled = True
                cbo_situacao.Enabled = True
            End If
            lk_email.Enabled = False
            If indicador.id_situacao_indicador_preco <> 1 Then 'se nao esta aguardando aprovacao e for aprovado em 1 e segundo nivel
                'nao deixa alterar
                cbo_indicador_tipo.Enabled = False
                txt_dt_referencia.Enabled = False
                txt_nr_valor.Enabled = False

                If indicador.id_situacao_indicador_preco = 2 Then
                    lk_email.Enabled = True
                End If
            Else
                lk_email.enabled = True
            End If

            'controle sistema
            lbl_modificador.Text = indicador.id_modificador.ToString()
            lbl_dt_modificacao.Text = indicador.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid Then

            Try

                Dim indicador As New IndicadorPreco

                'dados de indicador
                indicador.id_indicador_tipo = cbo_indicador_tipo.SelectedValue
                indicador.dt_referencia = DateTime.Parse("01/" & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
                indicador.nr_valor = Convert.ToDecimal(txt_nr_valor.Text)
                indicador.id_situacao = cbo_situacao.SelectedValue
                indicador.id_modificador = Session("id_login")

                If Not (ViewState.Item("id_indicador_preco") Is Nothing) Then
                    indicador.id_indicador_preco = Convert.ToInt32(ViewState.Item("id_indicador_preco"))
                    'se  nao tem calculo definitivo
                    If ViewState.Item("CalculoDefinitivo").ToString.Equals(String.Empty) Then
                        indicador.updateIndicadorPreco()
                        'fran 08/12/2020 i dango
                        Dim usuariolog As New UsuarioLog
                        usuariolog.id_usuario = Session("id_login")
                        usuariolog.ds_id_session = Session.SessionID.ToString()
                        usuariolog.id_tipo_log = 3 'alyeracao
                        usuariolog.id_menu_item = 180
                        usuariolog.id_nr_processo = ViewState.Item("id_indicador_preco").ToString

                        usuariolog.insertUsuarioLog()
                        'fran 08/12/2020 f dango

                        'se está inativando
                        If indicador.id_situacao = 2 Then
                            indicador.updateIndicadorPrecoSituacao()
                            'fran 08/12/2020 i dango
                            'Dim usuariolog As New UsuarioLog
                            usuariolog.id_usuario = Session("id_login")
                            usuariolog.ds_id_session = Session.SessionID.ToString()
                            usuariolog.id_tipo_log = 5 'delecao
                            usuariolog.id_menu_item = 180
                            usuariolog.id_nr_processo = ViewState.Item("id_indicador_preco").ToString

                            usuariolog.insertUsuarioLog()
                            'fran 08/12/2020 f dango

                        End If
                    End If

                    messageControl.Alert("Registro alterado com sucesso.")
                    loadData()
                Else
                    indicador.id_situacao_indicador_preco = 1 'aguardando aprovação
                    indicador.id_indicador_preco = indicador.insertIndicadorPreco()
                    ViewState.Item("id_indicador_preco") = indicador.id_indicador_preco.ToString

                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 180
                    usuariolog.id_nr_processo = ViewState.Item("id_indicador_preco").ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro inserido com sucesso.")

                    loadData()

                End If


            Catch ex As Exception
            messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_indicador_preco.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_indicador_preco.aspx")
    End Sub

    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_indicador_preco.aspx")

    End Sub

    Protected Sub cbo_indicador_tipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_indicador_tipo.SelectedIndexChanged
        Try


            Dim indicador As New IndicadorPreco
            indicador.id_indicador_tipo = Convert.ToInt32(cbo_indicador_tipo.SelectedValue)
            ViewState.Item("maior_referencia") = indicador.getIndicadorPrecoMaiorReferencia
            If CDate(ViewState.Item("maior_referencia")) = CDate("01/01/1900") Then
                ViewState.Item("maior_referencia") = String.Empty
            End If
            If Not ViewState.Item("maior_referencia").ToString.Equals(String.Empty) Then
                ViewState.Item("maior_referencia") = DateTime.Parse(ViewState.Item("maior_referencia")).ToString("dd/MM/yyyy")
                txt_dt_referencia.Text = DateTime.Parse(DateAdd(DateInterval.Month, 1, CDate(ViewState.Item("maior_referencia")))).ToString("MM/yyyy")
                txt_dt_referencia.Enabled = False
            Else
                ViewState.Item("maior_referencia") = String.Empty
                txt_dt_referencia.Text = DateTime.Now.ToString("MM/yyyy")
                txt_dt_referencia.Enabled = True
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub lk_email_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_email.Click
        If Page.IsValid = True Then
            Try

                Dim notificacao As New Notificacao
                If ViewState.Item("id_situacao_indicador_preco").ToString = "1" Then ' se em aprovacao
                    Dim lAssunto As String = "Aprovação 1.o Nível para Indicador de Preço"
                    Dim lCorpo As String = "Existem indicador(es) de preço pendente(s) para aprovação 1.o Nível."

                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 9 'e-mail
                    usuariolog.id_menu_item = 180
                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    ' Parametro 21 - Indicador Preço 1.o Nível
                    If notificacao.enviaMensagemEmail(21, lAssunto, lCorpo, MailPriority.High) = True Then
                        messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível foi enviada aos destinatários com sucesso!")
                    Else
                        messageControl.Alert("A mensagem de solicitação de aprovação 1.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")
                    End If
                End If

                If ViewState.Item("id_situacao_pessoa_contrato").ToString = "2" Then ' se aprovado 1 nivel
                    Dim lAssunto As String = "Aprovação 2.o Nível para Indicador de Preço "
                    Dim lCorpo As String = "Existem indicador(es) de preço pendente(s) para aprovação 2.o Nível."
                    ' Parametro 20 - MODELO DE CONTRATAO 2.o Nível
                    If notificacao.enviaMensagemEmail(20, lAssunto, lCorpo, MailPriority.High) = True Then
                        messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível foi enviada aos destinatários com sucesso!")
                    Else
                        messageControl.Alert("A mensagem de solicitação de aprovação 2.o Nível não pode ser enviada. Verifique há destinatários cadastrados para este tipo de notificação.")
                    End If
                End If

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        End If

    End Sub
End Class
