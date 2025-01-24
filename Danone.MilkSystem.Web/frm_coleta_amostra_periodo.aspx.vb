Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail

Partial Class frm_coleta_amostra_periodo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_coleta_amostra_periodo.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            ViewState.Item("id_coleta_amostra_periodo_1") = "0"
            ViewState.Item("id_coleta_amostra_periodo_2") = "0"
            ViewState.Item("id_coleta_amostra_periodo_3") = "0"
            ViewState.Item("id_coleta_amostra_periodo_4") = "0"

            If Not (Request("dt_referencia") Is Nothing) Then
                ViewState.Item("dt_referencia") = Request("dt_referencia")
                ViewState.Item("id_estabelecimento") = Request("id_estabelecimento")

                loadData()
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim row As DataRow
            Dim ldata1acoleta As String = ""
            Dim coletaperiodo As New ColetaAmostraPeriodo()

            coletaperiodo.id_estabelecimento = ViewState.Item("id_estabelecimento")
            coletaperiodo.dt_referencia = ViewState.Item("dt_referencia")

            Dim dscoletaperiodo As DataSet = coletaperiodo.getColetaAmostraPeriodo

            'Dados
            cbo_estabelecimento.SelectedValue = coletaperiodo.id_estabelecimento
            cbo_estabelecimento.Enabled = False

            txt_referencia.Text = DateTime.Parse(coletaperiodo.dt_referencia).ToString("MM/yyyy")
            txt_referencia.Enabled = False

            Dim coletaamostra As New ColetaAmostra
            Dim dsultimacoleta As DataSet = coletaamostra.getColetaUltimaRotaCarregada
            If dsultimacoleta.Tables(0).Rows.Count > 0 Then
                With dsultimacoleta.Tables(0).Rows(0)

                    lbl_ultima_coleta.Text = String.Concat("Rota: ", .Item("nm_linha").ToString, " - ", "Data: ", DateTime.Parse(.Item("dt_criacao")).ToString("dd/MM/yyyy HH:mm"))
                    ViewState.Item("dataultimacoleta") = DateTime.Parse(.Item("dt_criacao")).ToString("dd/MM/yyyy")

                End With
            Else
                lbl_ultima_coleta.Text = String.Empty
                ViewState.Item("dataultimacoleta") = String.Empty
            End If

            'PERIODOS
            txt_dia_ini_1col.Text = String.Empty
            txt_dia_fim_1col.Text = String.Empty
            txt_dia_ini_2col.Text = String.Empty
            txt_dia_fim_2col.Text = String.Empty
            txt_dia_ini_3col.Text = String.Empty
            txt_dia_fim_3col.Text = String.Empty
            txt_dia_ini_4col.Text = String.Empty
            txt_dia_fim_4col.Text = String.Empty

            For Each row In dscoletaperiodo.Tables(0).Rows

                Select Case CInt(row.Item("id_tipo_coleta_analise_esalq"))
                    Case 1 '1a coleta
                        txt_dia_ini_1col.Text = DateTime.Parse(row.Item("dt_ini_amostra")).ToString("dd")
                        txt_dia_fim_1col.Text = DateTime.Parse(row.Item("dt_fim_amostra")).ToString("dd")

                        ViewState.Item("id_coleta_amostra_periodo_1") = row.Item("id_coleta_amostra_periodo").ToString

                        If Not ViewState.Item("dataultimacoleta").ToString.Equals(String.Empty) Then
                            'se data ult coleta maior dt ini amostra, nao deixa alterar
                            If CDate(ViewState.Item("dataultimacoleta")) >= CDate(DateTime.Parse(row.Item("dt_ini_amostra")).ToString("dd/MM/yyyy")) Then
                                txt_dia_ini_1col.Enabled = False
                            End If
                            'se data ult coleta maior dt fim amostra, nao deixa alterar
                            If CDate(ViewState.Item("dataultimacoleta")) >= CDate(DateTime.Parse(row.Item("dt_fim_amostra")).ToString("dd/MM/yyyy")) Then
                                txt_dia_fim_1col.Enabled = False
                            End If
                        End If

                        ldata1acoleta = DateTime.Parse(row.Item("dt_ini_amostra")).ToString("dd/MM/yyyy")

                        'controle sistema
                        lbl_modificador.Text = row.Item("ds_login")
                        lbl_dt_modificacao.Text = row.Item("dt_modificacao").ToString()
                        cbo_situacao.SelectedValue = row.Item("id_situacao").ToString()

                    Case 2 '2a coleta
                        txt_dia_ini_2col.Text = DateTime.Parse(row.Item("dt_ini_amostra")).ToString("dd")
                        txt_dia_fim_2col.Text = DateTime.Parse(row.Item("dt_fim_amostra")).ToString("dd")

                        ViewState.Item("id_coleta_amostra_periodo_2") = row.Item("id_coleta_amostra_periodo").ToString

                        If Not ViewState.Item("dataultimacoleta").ToString.Equals(String.Empty) Then
                            'se data ult coleta maior dt ini amostra, nao deixa alterar
                            If CDate(ViewState.Item("dataultimacoleta")) >= CDate(DateTime.Parse(row.Item("dt_ini_amostra")).ToString("dd/MM/yyyy")) Then
                                txt_dia_ini_2col.Enabled = False
                            End If
                            'se data ult coleta maior dt fim amostra, nao deixa alterar
                            If CDate(ViewState.Item("dataultimacoleta")) >= CDate(DateTime.Parse(row.Item("dt_fim_amostra")).ToString("dd/MM/yyyy")) Then
                                txt_dia_fim_2col.Enabled = False
                            End If
                        End If
                    Case 3 '3a coleta
                        'se tem data inicio amostra
                        If Not row.Item("dt_ini_amostra").ToString.Equals(String.Empty) Then

                            txt_dia_ini_3col.Text = DateTime.Parse(row.Item("dt_ini_amostra")).ToString("dd")
                            txt_dia_fim_3col.Text = DateTime.Parse(row.Item("dt_fim_amostra")).ToString("dd")

                            ViewState.Item("id_coleta_amostra_periodo_3") = row.Item("id_coleta_amostra_periodo").ToString

                            If Not ViewState.Item("dataultimacoleta").ToString.Equals(String.Empty) Then
                                'se data ult coleta maior dt ini amostra, nao deixa alterar
                                If CDate(ViewState.Item("dataultimacoleta")) >= CDate(DateTime.Parse(row.Item("dt_ini_amostra")).ToString("dd/MM/yyyy")) Then
                                    txt_dia_ini_3col.Enabled = False
                                End If
                                'se data ult coleta maior dt fim amostra, nao deixa alterar
                                If CDate(ViewState.Item("dataultimacoleta")) >= CDate(DateTime.Parse(row.Item("dt_fim_amostra")).ToString("dd/MM/yyyy")) Then
                                    txt_dia_fim_3col.Enabled = False
                                End If
                            End If
                        End If

                    Case 4 '4a coleta
                        'se tem data inicio amostra
                        If Not row.Item("dt_ini_amostra").ToString.Equals(String.Empty) Then
                            txt_dia_ini_4col.Text = DateTime.Parse(row.Item("dt_ini_amostra")).ToString("dd")
                            txt_dia_fim_4col.Text = DateTime.Parse(row.Item("dt_fim_amostra")).ToString("dd")

                            ViewState.Item("id_coleta_amostra_periodo_4") = row.Item("id_coleta_amostra_periodo").ToString

                            If Not ViewState.Item("dataultimacoleta").ToString.Equals(String.Empty) Then

                                'se data ult coleta maior dt ini amostra, nao deixa alterar
                                If CDate(ViewState.Item("dataultimacoleta")) >= CDate(DateTime.Parse(row.Item("dt_ini_amostra")).ToString("dd/MM/yyyy")) Then
                                    txt_dia_ini_4col.Enabled = False
                                End If
                                'se data ult coleta maior dt fim amostra, nao deixa alterar
                                If CDate(ViewState.Item("dataultimacoleta")) >= CDate(DateTime.Parse(row.Item("dt_fim_amostra")).ToString("dd/MM/yyyy")) Then
                                    txt_dia_fim_4col.Enabled = False
                                End If
                            End If
                        End If
                End Select

            Next

            'CONTROELE VISUAL
            If Not ViewState.Item("dataultimacoleta").ToString.Equals(String.Empty) Then
                'se data ultima coleta maior ou igual referencia nao atualiza, nao pode salvar
                If CDate(ViewState.Item("dataultimacoleta")) >= CDate(DateAdd(DateInterval.Month, 1, ViewState.Item("dt_referencia"))) Then
                    lk_concluir.Enabled = False
                    lk_concluirFooter.Enabled = False
                End If

                'se a data ultima coleta for maior data inicio 1a coleta nao pode inativar
                If CDate(ViewState.Item("dataultimacoleta")) >= CDate(ldata1acoleta) Then
                    cbo_situacao.Enabled = False
                End If
            End If

            If cbo_situacao.SelectedValue = 2 Then
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

                Dim coletaperiodo As New ColetaAmostraPeriodo()
                Dim lmsg As String = ""

                'Dados
                coletaperiodo.id_estabelecimento = cbo_estabelecimento.SelectedValue
                coletaperiodo.dt_referencia = DateTime.Parse("01/" & txt_referencia.Text).ToString("dd/MM/yyyy")
                coletaperiodo.id_modificador = Session("id_login")
                coletaperiodo.id_situacao = cbo_situacao.SelectedValue

                'se esta inativando todo o periodo
                If cbo_situacao.SelectedValue = 2 Then
                    coletaperiodo.deleteColetaAmostraPeriodoTodos()
                    lmsg = "Registro inativado com sucesso."

                Else
                    'DADOA 1a COLETA
                    coletaperiodo.id_tipo_coleta_analise_esalq = 1 '1a coleta
                    coletaperiodo.dt_ini_amostra = DateTime.Parse(Right("00" & txt_dia_ini_1col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
                    coletaperiodo.dt_fim_amostra = DateTime.Parse(Right("00" & txt_dia_fim_1col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")

                    'se nao tem 1a coleta
                    If ViewState.Item("id_coleta_amostra_periodo_1").ToString = "0" Then
                        ViewState.Item("id_coleta_amostra_periodo_1") = coletaperiodo.insertColetaAmostraPeriodo()
                        ViewState.Item("dt_referencia") = coletaperiodo.dt_referencia
                        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

                        lmsg = "Registro inserido com sucesso."
                    Else
                        coletaperiodo.id_coleta_amostra_periodo = Convert.ToInt32(ViewState.Item("id_coleta_amostra_periodo_1"))
                        coletaperiodo.updateColetaAmostraPeriodo()
                        lmsg = "Registro alterado com sucesso."
                    End If

                    'DADOS 2a COLETA
                    coletaperiodo.id_tipo_coleta_analise_esalq = 2 '2a coleta
                    coletaperiodo.dt_ini_amostra = DateTime.Parse(Right("00" & txt_dia_ini_2col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
                    coletaperiodo.dt_fim_amostra = DateTime.Parse(Right("00" & txt_dia_fim_2col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")

                    'se nao tem 2a coleta
                    If ViewState.Item("id_coleta_amostra_periodo_2").ToString = "0" Then
                        ViewState.Item("id_coleta_amostra_periodo_2") = coletaperiodo.insertColetaAmostraPeriodo()
                    Else
                        coletaperiodo.id_coleta_amostra_periodo = Convert.ToInt32(ViewState.Item("id_coleta_amostra_periodo_2"))
                        coletaperiodo.updateColetaAmostraPeriodo()
                    End If

                    'DADOS 3a COLETA

                    'se a data de inicio da 3a coleta nao foi informada
                    If txt_dia_ini_3col.Text.Equals(String.Empty) Then

                        'se nao tem id para 3a coleta, nao existia antes entao não faz nada
                        If ViewState.Item("id_coleta_amostra_periodo_3").ToString = "0" Then

                        Else 'se id da 3a coleta tinha id e na tela nao tem campo
                            coletaperiodo.id_coleta_amostra_periodo = Convert.ToInt32(ViewState.Item("id_coleta_amostra_periodo_3"))
                            coletaperiodo.deleteColetaAmostraPeriodo()
                        End If

                    Else
                        coletaperiodo.id_tipo_coleta_analise_esalq = 3 '3a coleta
                        coletaperiodo.dt_ini_amostra = DateTime.Parse(Right("00" & txt_dia_ini_3col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
                        coletaperiodo.dt_fim_amostra = DateTime.Parse(Right("00" & txt_dia_fim_3col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")

                        'se nao tem id para 3a coleta, insere
                        If ViewState.Item("id_coleta_amostra_periodo_3").ToString = "0" Then
                            ViewState.Item("id_coleta_amostra_periodo_3") = coletaperiodo.insertColetaAmostraPeriodo()

                        Else 'se id da 3a coleta tinha id e na tela nao tem campo
                            coletaperiodo.id_coleta_amostra_periodo = Convert.ToInt32(ViewState.Item("id_coleta_amostra_periodo_3"))
                            coletaperiodo.updateColetaAmostraPeriodo()
                        End If

                    End If

                    'DADOS 4a COLETA
                    'se a data de inicio da 4a coleta nao foi informada
                    If txt_dia_ini_4col.Text.Equals(String.Empty) Then

                        'se nao tem id para 4a coleta, nao existia antes entao não faz nada
                        If ViewState.Item("id_coleta_amostra_periodo_4").ToString = "0" Then

                        Else 'se id da 3a coleta tinha id e na tela nao tem campo
                            coletaperiodo.id_coleta_amostra_periodo = Convert.ToInt32(ViewState.Item("id_coleta_amostra_periodo_4"))
                            coletaperiodo.deleteColetaAmostraPeriodo()
                        End If

                    Else
                        coletaperiodo.id_tipo_coleta_analise_esalq = 4 '4a coleta
                        coletaperiodo.dt_ini_amostra = DateTime.Parse(Right("00" & txt_dia_ini_4col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
                        coletaperiodo.dt_fim_amostra = DateTime.Parse(Right("00" & txt_dia_fim_4col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")

                        'se nao tem id para 4a coleta, insere
                        If ViewState.Item("id_coleta_amostra_periodo_4").ToString = "0" Then
                            ViewState.Item("id_coleta_amostra_periodo_4") = coletaperiodo.insertColetaAmostraPeriodo()

                        Else 'se id da 4a coleta tinha id e na tela nao tem campo
                            coletaperiodo.id_coleta_amostra_periodo = Convert.ToInt32(ViewState.Item("id_coleta_amostra_periodo_4"))
                            coletaperiodo.updateColetaAmostraPeriodo()
                        End If

                    End If
                End If
                messageControl.Alert(lmsg)

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_coleta_amostra_periodo.aspx")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_coleta_amostra_periodo.aspx")
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
        Response.Redirect("frm_coleta_amostra_periodo.aspx")

    End Sub


    Protected Sub cv_salvar_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_salvar.ServerValidate
        Try
            Dim lmsg As String

            args.IsValid = True


            'verificar se já existe a referencia no banco
            If (ViewState.Item("dt_referencia") Is Nothing) Then
                Dim coletaperiodo As New ColetaAmostraPeriodo
                coletaperiodo.id_estabelecimento = cbo_estabelecimento.SelectedValue
                coletaperiodo.dt_referencia = DateTime.Parse(String.Concat("01/", txt_referencia.Text)).ToString("dd/MM/yyyy")

                'se tem a refencia e estabelecimento no cadastro de periodos
                If coletaperiodo.getColetaAmostraPeriodo.Tables(0).Rows.Count > 0 Then
                    args.IsValid = False
                    lmsg = "Já existe a referência informada nos cadastros de Período para Coleta de Amostras."
                End If
            End If


            'VERIFICAR SE OS PERIODOS COINCIDEM
            'Se a data final da 1a coleta for maior ou igual data inicial da 2a coleta
            If args.IsValid = True AndAlso CInt(txt_dia_fim_1col.Text) >= CInt(txt_dia_ini_2col.Text) Then
                args.IsValid = False
                lmsg = "O período para coleta da 1a. amostra não pode coincidir com outros períodos de coleta."
            End If

            'Se a data final da 2a coleta for maior ou igual data inicial da 3a coleta
            If args.IsValid = True AndAlso txt_dia_ini_3col.Text <> String.Empty AndAlso CInt(txt_dia_fim_2col.Text) >= CInt(txt_dia_ini_3col.Text) Then
                args.IsValid = False
                lmsg = "O período para coleta da 2a. amostra não pode coincidir com outros períodos de coleta."
            End If

            'Se a data final da 3a coleta for maior ou igual data inicial da 4a coleta
            If args.IsValid = True AndAlso txt_dia_ini_3col.Text <> String.Empty AndAlso txt_dia_ini_4col.Text <> String.Empty AndAlso CInt(txt_dia_fim_3col.Text) >= CInt(txt_dia_ini_4col.Text) Then
                args.IsValid = False
                lmsg = "O período para coleta da 3a. amostra não pode coincidir com outros períodos de coleta."
            End If


            'Dim coletamanual As New ColetaAmostraManual
            'coletamanual.id_estabelecimento = cbo_estabelecimento.SelectedValue
            'coletamanual.dt_referencia = DateTime.Parse(String.Concat("01/", txt_referencia.Text)).ToString("dd/MM/yyyy")

            ''Verificar se há coletas manuais coincidindo com os periodos
            'If args.IsValid = True Then
            '    coletamanual.dt_ini_amostra = DateTime.Parse(Right("00" & txt_dia_ini_1col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
            '    coletamanual.dt_fim_amostra = DateTime.Parse(Right("00" & txt_dia_fim_1col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")

            '    'verifica o perioda da 1a coleta em amostras manuais
            '    If coletamanual.getColetaAmostraManualbyPeriodo.Tables(0).Rows.Count > 0 Then
            '        args.IsValid = False
            '        lmsg = "Já existe o período informado para coleta da 1a. amostra em amostras manuais."
            '    Else
            '        'verifica o periodo da 2a coleta em amostras manuais
            '        coletamanual.dt_ini_amostra = DateTime.Parse(Right("00" & txt_dia_ini_2col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
            '        coletamanual.dt_fim_amostra = DateTime.Parse(Right("00" & txt_dia_fim_2col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")

            '        If coletamanual.getColetaAmostraManualbyPeriodo.Tables(0).Rows.Count > 0 Then
            '            args.IsValid = False
            '            lmsg = "Já existe o período informado para coleta da 2a. amostra em amostras manuais."
            '        End If
            '    End If
            'End If

            'If args.IsValid = True AndAlso txt_dia_ini_3col.Text <> String.Empty Then
            '    'verifica o periodo da 3a coleta em amostras manuais
            '    coletamanual.dt_ini_amostra = DateTime.Parse(Right("00" & txt_dia_ini_3col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
            '    coletamanual.dt_fim_amostra = DateTime.Parse(Right("00" & txt_dia_fim_3col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")

            '    If coletamanual.getColetaAmostraManualbyPeriodo.Tables(0).Rows.Count > 0 Then
            '        args.IsValid = False
            '        lmsg = "Já existe o período informado para coleta da 3a. amostra em amostras manuais."
            '    End If
            'End If

            'If args.IsValid = True AndAlso txt_dia_ini_4col.Text <> String.Empty Then
            '    'verifica o periodo da 4a coleta em amostras manuais
            '    coletamanual.dt_ini_amostra = DateTime.Parse(Right("00" & txt_dia_ini_4col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")
            '    coletamanual.dt_fim_amostra = DateTime.Parse(Right("00" & txt_dia_fim_4col.Text.Trim & "/", 3).ToString & txt_referencia.Text).ToString("dd/MM/yyyy")

            '    If coletamanual.getColetaAmostraManualbyPeriodo.Tables(0).Rows.Count > 0 Then
            '        args.IsValid = False
            '        lmsg = "Já existe o período informado para coleta da 4a. amostra em amostras manuais."
            '    End If
            'End If



            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub


End Class
