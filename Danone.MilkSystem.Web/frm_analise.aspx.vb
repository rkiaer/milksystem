Imports Danone.MilkSystem.Business

Partial Class frm_analise
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_analise.aspx")

        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try



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

            'Dim faixareferencialogica As New FaixaReferenciaLogica

            'cbo_id_faixa_referencia_logica.DataSource = faixareferencialogica.getFaixasReferenciaLogicaByFilters()
            'cbo_id_faixa_referencia_logica.DataTextField = "nm_faixa_referencia_logica"
            'cbo_id_faixa_referencia_logica.DataValueField = "id_faixa_referencia_logica"
            'cbo_id_faixa_referencia_logica.DataBind()
            'cbo_id_faixa_referencia_logica.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            Dim situacoes As New Situacao

            cbo_situacao.DataSource = situacoes.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            cbo_situacao.Enabled = False

            Dim tipoanalise As New TipoAnalise

            cbo_tipo_analise.DataSource = tipoanalise.getTipoAnalisesByFilters()
            cbo_tipo_analise.DataTextField = "nm_tipo_analise"
            cbo_tipo_analise.DataValueField = "id_tipo_analise"
            cbo_tipo_analise.DataBind()
            cbo_tipo_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            'cbo_tipo_analise.Items.FindByValue("1").Selected = True
 
            Dim formatoanalise As New FormatoAnalise

            cbo_formato_analise.DataSource = formatoanalise.getFormatoAnalisesByFilters()
            cbo_formato_analise.DataTextField = "nm_formato_analise"
            cbo_formato_analise.DataValueField = "id_formato_analise"
            cbo_formato_analise.DataBind()
            'cbo_formato_analise.Items.FindByValue("1").Selected = True
            cbo_formato_analise.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            If Not (Request("id_analise") Is Nothing) Then
                ViewState.Item("id_analise") = Request("id_analise")
                txt_cd_analise.Enabled = False

                loadData()
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub


    Private Sub loadData()

        Try

            Dim id_analise As Int32 = Convert.ToInt32(ViewState.Item("id_analise"))
            Dim analise As New Analise(id_analise)

            txt_cd_analise.Text = analise.cd_analise
            txt_cd_analise.Enabled = False

            txt_nm_analise.Text = analise.nm_analise
            txt_nm_sigla.Text = analise.nm_sigla

            If (analise.id_estabelecimento > 0) Then
                cbo_estabelecimento.SelectedValue = analise.id_estabelecimento.ToString()
            End If

            If (analise.id_tipo_analise > 0) Then
                cbo_tipo_analise.SelectedValue = analise.id_tipo_analise.ToString()
            End If
            If (analise.id_item > 0) Then
                cbo_id_item.SelectedValue = analise.id_item
                cbo_id_item.Enabled = False
            End If

            If (analise.id_formato_analise > 0) Then
                cbo_formato_analise.SelectedValue = analise.id_formato_analise.ToString()
                cbo_formato_analise.Enabled = False
                If analise.id_formato_analise = 3 Then 'se for formato logico
                    Desabilitar_Faixas()
                    Habilitar_Faixa_Logica()
                    If (analise.id_faixa_referencia_logica > 0) Then
                        cbo_id_faixa_referencia_logica.SelectedValue = analise.id_faixa_referencia_logica.ToString()
                    End If

                Else
                    Desabilitar_Faixa_Logica()
                    Habilitar_Faixas()
                    txt_faixa_inicial.Text = analise.nr_faixa_inicial
                    txt_faixa_final.Text = analise.nr_faixa_final
                End If
            End If

            If Not analise.st_obrigatoria.Equals(String.Empty) Then
                If analise.st_obrigatoria = "S" Then
                    cbo_st_obrigatoria.SelectedValue = "S"
                Else
                    cbo_st_obrigatoria.SelectedValue = "N"
                End If
            End If
            If Not analise.st_laboratorio_externo.Equals(String.Empty) Then
                If analise.st_laboratorio_externo = "S" Then
                    chklist_analiserealizada.Items.FindByValue("chk_laboratorio_externo").Selected = True
                Else
                    chklist_analiserealizada.Items.FindByValue("chk_laboratorio_externo").Selected = False
                End If
            End If
            If Not analise.st_laboratorio_interno.Equals(String.Empty) Then
                If analise.st_laboratorio_interno = "S" Then
                    chklist_analiserealizada.Items.FindByValue("chk_laboratorio_interno").Selected = True
                Else
                    chklist_analiserealizada.Items.FindByValue("chk_laboratorio_interno").Selected = False
                End If
            End If

            If Not analise.st_re_analise.Equals(String.Empty) Then
                If analise.st_re_analise = "S" Then
                    chklist_analiserealizada.Items.FindByValue("chk_re_analise").Selected = True
                Else
                    chklist_analiserealizada.Items.FindByValue("chk_re_analise").Selected = False
                End If
            End If

            If Not analise.st_gera_ciq.Equals(String.Empty) Then
                If analise.st_gera_ciq = "S" Then
                    chklist_analiserealizada.Items.FindByValue("chk_gera_ciq").Selected = True
                Else
                    chklist_analiserealizada.Items.FindByValue("chk_gera_ciq").Selected = False
                End If
            End If
            'se todos ros romaneios (saida e entrada)
            If analise.id_participa_romaneio = 3 Then
                chklst_romaneios.Items.FindByValue("chk_romaneio_entrada").Selected = True
                chklst_romaneios.Items.FindByValue("chk_romaneio_saida").Selected = True
            Else
                If analise.id_participa_romaneio = 1 Then 'apenas romaneio entrada
                    chklst_romaneios.Items.FindByValue("chk_romaneio_entrada").Selected = True
                    chklst_romaneios.Items.FindByValue("chk_romaneio_saida").Selected = False
                End If
                If analise.id_participa_romaneio = 2 Then 'apenas romaneio saida
                    chklst_romaneios.Items.FindByValue("chk_romaneio_entrada").Selected = False
                    chklst_romaneios.Items.FindByValue("chk_romaneio_saida").Selected = True
                End If
            End If

            'fran 22/07/2011 i
            If Not analise.st_inibidor.Equals(String.Empty) Then
                If analise.st_inibidor = "S" Then
                    cbo_st_inibidor.SelectedValue = "S"
                Else
                    cbo_st_inibidor.SelectedValue = "N"
                End If
            End If
            'fran 22/07/2011 f


            If (analise.id_situacao > 0) Then
                cbo_situacao.SelectedValue = analise.id_situacao.ToString()
                cbo_situacao.Enabled = True
            End If

            lbl_modificador.Text = analise.id_modificador.ToString()
            lbl_dt_modificacao.Text = analise.dt_modificacao.ToString()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub updateData()
        If Page.IsValid Then
            Try

                Dim analise As New Analise()

                analise.cd_analise = txt_cd_analise.Text
                analise.nm_analise = txt_nm_analise.Text
                analise.nm_sigla = txt_nm_sigla.Text

                If Not (cbo_estabelecimento.SelectedValue.Trim().Equals(String.Empty)) Then
                    analise.id_estabelecimento = Convert.ToInt32(cbo_estabelecimento.SelectedValue)
                End If

                If Not (cbo_tipo_analise.SelectedValue.Trim().Equals(String.Empty)) Then
                    analise.id_tipo_analise = Convert.ToInt32(cbo_tipo_analise.SelectedValue)
                End If

                If Not (cbo_formato_analise.SelectedValue.Trim().Equals(String.Empty)) Then
                    analise.id_formato_analise = Convert.ToInt32(cbo_formato_analise.SelectedValue)
                End If
                If Not (cbo_id_item.SelectedValue.Trim().Equals(String.Empty)) Then
                    analise.id_item = Convert.ToInt32(cbo_id_item.SelectedValue)
                End If

                If Not (txt_faixa_inicial.Text.Trim.Equals(String.Empty)) Then
                    analise.nr_faixa_inicial = txt_faixa_inicial.Text
                End If

                If Not (txt_faixa_final.Text.Trim.Equals(String.Empty)) Then
                    analise.nr_faixa_final = txt_faixa_final.Text
                End If

                If Not (cbo_id_faixa_referencia_logica.SelectedValue.Trim().Equals(String.Empty)) Then
                    analise.id_faixa_referencia_logica = Convert.ToInt32(cbo_id_faixa_referencia_logica.SelectedValue)
                End If
                If Not (cbo_st_obrigatoria.SelectedValue.Trim().Equals(String.Empty)) Then
                    analise.st_obrigatoria = cbo_st_obrigatoria.SelectedValue.ToString
                End If

                If Not (cbo_situacao.SelectedValue.Trim().Equals(String.Empty)) Then
                    analise.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                End If
                If chklist_analiserealizada.Items.FindByValue("chk_laboratorio_externo").Selected = True Then
                    analise.st_laboratorio_externo = "S"
                Else
                    analise.st_laboratorio_externo = "N"
                End If
                If chklist_analiserealizada.Items.FindByValue("chk_laboratorio_interno").Selected = True Then
                    analise.st_laboratorio_interno = "S"
                Else
                    analise.st_laboratorio_interno = "N"
                End If
                If chklist_analiserealizada.Items.FindByValue("chk_re_analise").Selected = True Then
                    analise.st_re_analise = "S"
                Else
                    analise.st_re_analise = "N"
                End If
                If chklist_analiserealizada.Items.FindByValue("chk_gera_ciq").Selected = True Then
                    analise.st_gera_ciq = "S"
                Else
                    analise.st_gera_ciq = "N"
                End If

                If chklst_romaneios.Items.FindByValue("chk_romaneio_entrada").Selected = True Then
                    analise.id_participa_romaneio = 1
                    If chklst_romaneios.Items.FindByValue("chk_romaneio_saida").Selected = True Then
                        analise.id_participa_romaneio = 3
                    End If
                Else
                    analise.id_participa_romaneio = 2
                End If

                'fran 22/07/2011 i
                If cbo_st_inibidor.SelectedValue = "S" Then
                    analise.st_inibidor = "S"
                Else
                    analise.st_inibidor = "N"
                End If
                'fran 22/07/2011 f


                analise.id_modificador = Session("id_login")

                If Not (ViewState.Item("id_analise") Is Nothing) Then

                    analise.id_analise = Convert.ToInt32(ViewState.Item("id_analise"))
                    analise.updateAnalise()

                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 3 'alteração
                    usuariolog.id_menu_item = 12
                    usuariolog.nm_nr_processo = analise.cd_analise
                    usuariolog.id_nr_processo = ViewState.Item("id_analise").ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro alterado com sucesso.")
                Else
                    ViewState.Item("id_analise") = analise.insertAnalise()
                    'fran 08/12/2020 i dango
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 4 'inclusao
                    usuariolog.id_menu_item = 12
                    usuariolog.nm_nr_processo = analise.cd_analise
                    usuariolog.id_nr_processo = ViewState.Item("id_analise").ToString

                    usuariolog.insertUsuarioLog()
                    'fran 08/12/2020 f dango

                    messageControl.Alert("Registro inserido com sucesso.")

                End If

                loadData()

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_analise.aspx?st_incluirlog=N")
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("lst_analise.aspx?st_incluirlog=N")
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Protected Sub cv_chk_analise_realizadas_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_chk_analise_realizadas.ServerValidate
        Try
            args.IsValid = True
            If chklist_analiserealizada.SelectedIndex = -1 Then
                args.IsValid = False
                messageControl.Alert("Selecione uma ou mais opções para sinalizar quais as situações em que a análise poderá ser realizada.")
            End If
            If chklst_romaneios.SelectedIndex = -1 Then
                args.IsValid = False
                messageControl.Alert("Selecione em quais tipos de romaneios a análise será incluída.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cbo_formato_analise_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_formato_analise.SelectedIndexChanged
        If cbo_formato_analise.SelectedValue.Trim.Equals("3") Then
            Desabilitar_Faixas()
            Habilitar_Faixa_Logica()
        Else
            Desabilitar_Faixa_Logica()
            Habilitar_Faixas()
        End If

    End Sub

    Private Sub loadFaixaReferencia()

        Try

            cbo_id_faixa_referencia_logica.Enabled = True


            Dim faixareferencialogica As New FaixaReferenciaLogica

            cbo_id_faixa_referencia_logica.DataSource = faixareferencialogica.getFaixasReferenciaLogicaByFilters()
            cbo_id_faixa_referencia_logica.DataTextField = "nm_faixa_referencia_logica"
            cbo_id_faixa_referencia_logica.DataValueField = "id_faixa_referencia_logica"
            cbo_id_faixa_referencia_logica.DataBind()
            cbo_id_faixa_referencia_logica.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub Habilitar_Faixas()
        cv_faixainicialfinal.Visible = True
        rfv_faixainicial.Visible = True
        rfv_faixafinal.Visible = True
        txt_faixa_inicial.Enabled = True
        txt_faixa_final.Enabled = True

    End Sub
    Private Sub Desabilitar_Faixas()
        rfv_faixainicial.Visible = False
        rfv_faixafinal.Visible = False
        cv_faixainicialfinal.Visible = False
        txt_faixa_inicial.Text = String.Empty
        txt_faixa_final.Text = String.Empty
        txt_faixa_inicial.Enabled = False
        txt_faixa_final.Enabled = False
    End Sub
    Private Sub Habilitar_Faixa_Logica()
        rfv_referencialogica.Visible = True
        loadFaixaReferencia()

    End Sub
    Private Sub Desabilitar_Faixa_Logica()
        rfv_referencialogica.Visible = False
        cbo_id_faixa_referencia_logica.Items.Clear()
        cbo_id_faixa_referencia_logica.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
        cbo_id_faixa_referencia_logica.Enabled = False

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        'Fran 02/-3/2009 i rls17
        Response.Redirect("frm_analise.aspx")

    End Sub
End Class
