Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_coleta_amostra


    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia") = "01/" + Me.txt_dt_referencia.Text.Trim
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("id_propriedade_matriz") = Me.txt_id_propriedade_matriz.Text.Trim()

        If txt_dia_fim.Text.Equals(String.Empty) Then
            ViewState.Item("dt_ini") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        Else
            ViewState.Item("dt_ini") = DateTime.Parse(Right("00" & txt_dia_ini.Text.Trim & "/", 3).ToString & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
            ViewState.Item("dt_fim") = DateTime.Parse(Right("00" & txt_dia_fim.Text.Trim & "/", 3).ToString & txt_dt_referencia.Text).ToString("dd/MM/yyyy")
        End If

        ViewState.Item("id_tipo_coleta_analise_esalq") = Me.cbo_tipo_coleta.SelectedValue
        ViewState.Item("nm_rota") = Me.txt_nm_linha.Text
        ViewState.Item("nr_caderneta") = Me.txt_nr_caderneta.Text
        ViewState.Item("id_situacao_coleta_amostra") = Me.cbo_situacao.SelectedValue
        ViewState.Item("id_situacao_coleta") = Me.cbo_situacao_caderneta.SelectedValue
        ViewState.Item("ds_consistencia") = Me.cbo_consistencia.SelectedValue
        ViewState.Item("id_motivo_nao_coleta_amostra") = Me.cbo_motivo_nao_coleta.SelectedValue

        'ViewState.Item("sortExpression") = "id_propriedade, id_tipo_coleta_analise_esalq, ds_analise_esalq, dt_coleta"

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_coleta_amostra.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_coleta_amostra.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 209
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
        End With
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With

    End Sub

    Private Sub loadDetails()

        Try

            Dim status As New SituacaoColetaAmostra
            Dim estabelecimento As New Estabelecimento
            Dim analiseesalqtipocoleta As New AnaliseEsalqTipoColeta 'fran 26/07/2016
            Dim motivonaocoleta As New MotivoNaoColetaAmostra

            estabelecimento.st_recepcao_leite = "S"
            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            cbo_situacao.DataSource = status.getSituacoesColetaAmostraByFilters()
            cbo_situacao.DataTextField = "nm_situacao_coleta_amostra"
            cbo_situacao.DataValueField = "id_situacao_coleta_amostra"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_motivo_nao_coleta.DataSource = motivonaocoleta.getMotivoNaoColetaAmostraByFilters()
            cbo_motivo_nao_coleta.DataTextField = "nm_motivo_nao_coleta_amostra"
            cbo_motivo_nao_coleta.DataValueField = "id_motivo_nao_coleta_amostra"
            cbo_motivo_nao_coleta.DataBind()
            cbo_motivo_nao_coleta.Items.Insert(0, New ListItem("[Selecione]", "0"))

            cbo_tipo_coleta.DataSource = analiseesalqtipocoleta.getAnaliseEsalqTipoColetaByFilters()
            cbo_tipo_coleta.DataTextField = "nm_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataValueField = "id_tipo_coleta_analise_esalq"
            cbo_tipo_coleta.DataBind()
            cbo_tipo_coleta.Items.Insert(0, New ListItem("[Selecione]", "0"))


            txt_dt_referencia.Text = DateTime.Parse(Now).ToString("MM/yyyy")
            ViewState.Item("dt_referencia") = "01/" + Me.txt_dt_referencia.Text.Trim

            ViewState.Item("sortExpression") = ""
            lbl_referencia.Text = String.Empty
            lbl_periodo.Text = String.Empty
            lbl_coleta1.Text = String.Empty
            lbl_coleta2.Text = String.Empty
            lbl_coleta3.Text = String.Empty
            lbl_coleta4.Text = String.Empty

            loadFilters()

            'fran 11/2021 - simula seleção de usuario
            If cbo_estabelecimento.SelectedValue.Equals(String.Empty) Then
                'simula seleção do usuario em poços
                cbo_estabelecimento.SelectedValue = 1 'força poços de caldas
            End If
            If txt_dt_referencia.Text.Equals(String.Empty) Then
                txt_dt_referencia.Text = DateTime.Parse(Now).ToString("MM/yyyy")
                ViewState.Item("dt_referencia") = "01/" + Me.txt_dt_referencia.Text.Trim
            End If
            'fran 11/2021 - simula seleção de usuario


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("colamostra", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("colamostra", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If
        If Not (customPage.getFilterValue("colamostra", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("colamostra", txt_dt_referencia.ID)
            txt_dt_referencia.Text = DateTime.Parse(ViewState.Item("dt_referencia")).ToString("MM/yyyy")
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamostra", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("colamostra", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamostra", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("colamostra", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamostra", txt_cd_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("colamostra", txt_cd_propriedade.ID)
            txt_cd_propriedade.Text = ViewState.Item("id_propriedade").ToString()

        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamostra(", lbl_nm_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_propriedade") = customPage.getFilterValue("colamostra", lbl_nm_propriedade.ID)
            lbl_nm_propriedade.Text = ViewState.Item("nm_propriedade").ToString()
            hf_id_propriedade.Value = ViewState.Item("id_propriedade")
        Else
            ViewState.Item("nm_propriedade") = String.Empty
            hf_id_propriedade.Value = String.Empty
        End If

        If Not (customPage.getFilterValue("colamostra", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("colamostra", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamostra", txt_dia_fim.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dia_ini") = customPage.getFilterValue("colamostra", txt_dia_ini.ID)
            ViewState.Item("dia_fim") = customPage.getFilterValue("colamostra", txt_dia_fim.ID)

            txt_dia_ini.Text = DateTime.Parse(ViewState.Item("dia_ini")).ToString("dd")
            txt_dia_fim.Text = DateTime.Parse(ViewState.Item("dia_fim")).ToString("dd")

        Else
            ViewState.Item("dia_ini") = String.Empty
            ViewState.Item("dia_fim") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamostra", txt_id_propriedade_matriz.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade_matriz") = customPage.getFilterValue("colamostra", txt_id_propriedade_matriz.ID)
            txt_id_propriedade_matriz.Text = ViewState.Item("id_propriedade_matriz").ToString()

        Else
            ViewState.Item("id_propriedade_matriz") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamostra", txt_nm_linha.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_rota") = customPage.getFilterValue("colamostra", txt_nm_linha.ID)
            txt_nm_linha.Text = ViewState.Item("nm_rota").ToString()
        Else
            ViewState.Item("nm_rota") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamostra", txt_nr_caderneta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_caderneta") = customPage.getFilterValue("colamostra", txt_nr_caderneta.ID)
            txt_nr_caderneta.Text = ViewState.Item("nr_caderneta").ToString()
        Else
            ViewState.Item("nr_caderneta") = String.Empty
        End If
        If Not (customPage.getFilterValue("colamostra", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao_coleta_amostra") = customPage.getFilterValue("colamostra", cbo_situacao.ID)
            cbo_situacao.SelectedValue = ViewState.Item("id_situacao_coleta_amostra").ToString()
        Else
            ViewState.Item("id_situacao_coleta_amostra") = String.Empty
        End If

        If Not (customPage.getFilterValue("colamostra", cbo_situacao_caderneta.ID).Equals(String.Empty)) Then
            ViewState.Item("id_situacao_coleta") = customPage.getFilterValue("colamostra", cbo_tipo_coleta.ID)
            cbo_situacao_caderneta.SelectedValue = ViewState.Item("id_situacao_coleta").ToString()
        Else
            ViewState.Item("id_situacao_coleta") = 0
        End If

        If Not (customPage.getFilterValue("colamostra", cbo_motivo_nao_coleta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_motivo_nao_coleta_amostra") = customPage.getFilterValue("colamostra", cbo_motivo_nao_coleta.ID)
            cbo_motivo_nao_coleta.SelectedValue = ViewState.Item("id_motivo_nao_coleta_amostra").ToString()
        Else
            ViewState.Item("id_motivo_nao_coleta_amostra") = 0
        End If
        If Not (customPage.getFilterValue("colamostra", cbo_consistencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_consistencia") = customPage.getFilterValue("colamostra", cbo_consistencia.ID)
            cbo_consistencia.SelectedValue = ViewState.Item("ds_consistencia").ToString()
        Else
            ViewState.Item("ds_consistencia") = 0
        End If
        If Not (customPage.getFilterValue("colamostra", cbo_tipo_coleta.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_tipo_coleta_analise_esalq") = customPage.getFilterValue("colamostra", cbo_tipo_coleta.ID)
            cbo_tipo_coleta.SelectedValue = ViewState.Item("id_tipo_coleta_analise_esalq").ToString()
        Else
            ViewState.Item("id_tipo_coleta_analise_esalq") = 0
        End If

        If Not (customPage.getFilterValue("colamostra", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("colamostra", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("colamostra")
        End If

    End Sub

    Private Sub loadData()

        Try

            Dim periodo As New ColetaAmostraPeriodo

            periodo.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            periodo.dt_referencia = ViewState.Item("dt_referencia").ToString

            Dim dsperiodo As DataSet = periodo.getColetaAmostraPeriodoFiltro

            If dsperiodo.Tables(0).Rows.Count > 0 Then
                With dsperiodo.Tables(0).Rows(0)
                    lbl_referencia.Text = String.Concat("Referência: ", DateTime.Parse(ViewState.Item("dt_referencia")).ToString("MM/yyyy"))
                    lbl_periodo.Text = "Períodos para Coleta das Amostras:"
                    lbl_coleta1.Text = String.Concat("1a Coleta de ", .Item("coleta1").ToString)
                    lbl_coleta2.Text = String.Concat("2a Coleta de ", .Item("coleta2").ToString)
                    If .Item("coleta3").ToString.Equals(String.Empty) Then
                        lbl_coleta3.Text = String.Empty
                    Else
                        lbl_coleta3.Text = String.Concat("3a Coleta de ", .Item("coleta3").ToString)
                    End If
                    If .Item("coleta4").ToString.Equals(String.Empty) Then
                        lbl_coleta4.Text = String.Empty
                    Else
                        lbl_coleta4.Text = String.Concat("4a Coleta de ", .Item("coleta4").ToString)
                    End If

                End With
            Else
                lbl_referencia.Text = String.Empty
                lbl_periodo.Text = String.Empty
                lbl_coleta1.Text = String.Empty
                lbl_coleta2.Text = String.Empty
                lbl_coleta3.Text = String.Empty
                lbl_coleta4.Text = String.Empty

            End If

            Dim amostra As New ColetaAmostra

            amostra.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            amostra.dt_referencia = ViewState.Item("dt_referencia").ToString
            amostra.dt_ini_amostra = ViewState.Item("dt_ini").ToString
            amostra.dt_fim_amostra = ViewState.Item("dt_fim").ToString
            If Trim(ViewState.Item("id_pessoa")) <> "" Then
                amostra.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString)
            End If

            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                amostra.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            If Trim(ViewState.Item("id_propriedade_matriz")) <> "" Then
                amostra.id_propriedade_matriz = Convert.ToInt32(ViewState.Item("id_propriedade_matriz").ToString)
            End If
            amostra.id_tipo_coleta_analise_esalq = ViewState.Item("id_tipo_coleta_analise_esalq").ToString
            amostra.nm_linha = ViewState.Item("nm_rota").ToString
            If Trim(ViewState.Item("nr_caderneta").ToString) <> "" Then
                amostra.id_currentidentity = Convert.ToInt32(ViewState.Item("nr_caderneta").ToString)
            End If

            amostra.id_situacao_coleta = Convert.ToInt32(ViewState.Item("id_situacao_coleta").ToString()) 'se caderneta transmitida ou pendente
            amostra.id_situacao_coleta_amostra = Convert.ToInt32(ViewState.Item("id_situacao_coleta_amostra").ToString()) 'se pendente realizada ou nao realizada
            amostra.id_motivo_nao_coleta_amostra = Convert.ToInt32(ViewState.Item("id_motivo_nao_coleta_amostra").ToString())

            Dim bgridProdutores As Boolean = False

            Select Case ViewState.Item("ds_consistencia").ToString
                Case "1" 'Descarte Frascos
                    ViewState.Item("id_situacao_coleta") = "2"
                    ViewState.Item("id_motivo_nao_coleta_amostra") = 0
                    cbo_situacao_caderneta.SelectedValue = 2 'força coleta transmitida
                    cbo_motivo_nao_coleta.SelectedValue = 0 'força selecione
                    amostra.id_motivo_nao_coleta_amostra = 56 'força motivo 5 e 6 (Descarte frasco etiqueta e duplicidade)
                    amostra.id_situacao_coleta = 2 'força coleta transmitida
                    bgridProdutores = False
                    gridResults.Visible = True
                    gridResults.Columns(12).Visible = True 'Frasco
                    gridResults.Columns(13).Visible = True 'Protocolo
                    gridResults.Columns(14).Visible = False 'Exportacao
                Case "2" 'produtores que nao fizeram coleta das amostras
                    ViewState.Item("id_situacao_coleta") = "2"
                    ViewState.Item("id_motivo_nao_coleta_amostra") = 0
                    cbo_situacao_caderneta.SelectedValue = 2 'força coleta transmitida
                    cbo_motivo_nao_coleta.SelectedValue = 0 'força selecione
                    amostra.id_motivo_nao_coleta_amostra = 0
                    amostra.id_situacao_coleta = 2 'força coleta transmitida
                    amostra.id_situacao_coleta_amostra = 1 'Pendente (n~~ao existe protocolo ) - 2-existe protocolo usa variavel
                    amostra.st_coleta_amostra_manual = "" 'traz as coletas nao realizadas manuais e automaticas
                    bgridProdutores = True
                Case "3" 'amostra manual pendente
                    ViewState.Item("id_situacao_coleta") = "2" 'caderneta transmitidas
                    ViewState.Item("id_motivo_nao_coleta_amostra") = 0
                    cbo_situacao_caderneta.SelectedValue = 2 'força coleta transmitida
                    cbo_motivo_nao_coleta.SelectedValue = 0 'força selecione
                    amostra.id_motivo_nao_coleta_amostra = 0
                    amostra.id_situacao_coleta = 2 'força coleta transmitida
                    amostra.id_situacao_coleta_amostra = 1 'Pendente (n~~ao existe protocolo ) - 2-existe protocolo
                    amostra.st_coleta_amostra_manual = "S" 'traz as coletas nao realizadas manuais e automaticas
                    bgridProdutores = True
            End Select


            If bgridProdutores = False Then
                gridprodutor.Visible = False

                Dim dsamostra As DataSet = amostra.getColetaAmostrabyFilters()
                If (dsamostra.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsamostra.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If
            Else
                gridResults.Visible = False

                Dim dsamostra As DataSet = amostra.getColetaAmostraProdutores()
                If (dsamostra.Tables(0).Rows.Count > 0) Then
                    gridprodutor.Visible = True
                    gridprodutor.DataSource = Helper.getDataView(dsamostra.Tables(0), ViewState.Item("sortExpression"))
                    gridprodutor.DataBind()
                Else
                    gridprodutor.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        'saveCheckBox()
        loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "cd_pessoa"
                If (ViewState.Item("sortExpression")) = "cd_pessoa asc" Then
                    ViewState.Item("sortExpression") = "cd_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "cd_pessoa asc"
                End If

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If

            Case "id_propriedade_matriz"
                If (ViewState.Item("sortExpression")) = "id_propriedade_matriz asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade_matriz desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade_matriz asc"
                End If

            Case "dt_coleta"
                If (ViewState.Item("sortExpression")) = "dt_coleta asc" Then
                    ViewState.Item("sortExpression") = "dt_coleta desc"
                Else
                    ViewState.Item("sortExpression") = "dt_coleta asc"
                End If


            Case "nm_abreviado"
                If (ViewState.Item("sortExpression")) = "nm_abreviado asc" Then
                    ViewState.Item("sortExpression") = "nm_abreviado desc"
                Else
                    ViewState.Item("sortExpression") = "nm_abreviado asc"
                End If
            Case "nm_linha"
                If (ViewState.Item("sortExpression")) = "nm_linha asc" Then
                    ViewState.Item("sortExpression") = "nm_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nm_linha asc"
                End If
            Case "id_currentidentity"
                If (ViewState.Item("sortExpression")) = "id_currentidentity asc" Then
                    ViewState.Item("sortExpression") = "id_currentidentity desc"
                Else
                    ViewState.Item("sortExpression") = "id_currentidentity asc"
                End If

            Case "id_tipo_coleta_analise_esalq"
                If (ViewState.Item("sortExpression")) = "id_tipo_coleta_analise_esalq asc" Then
                    ViewState.Item("sortExpression") = "id_tipo_coleta_analise_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "id_tipo_coleta_analise_esalq asc"
                End If

            Case "nm_situacao_coleta_amostra"
                If (ViewState.Item("sortExpression")) = "nm_situacao_coleta_amostra asc" Then
                    ViewState.Item("sortExpression") = "nm_situacao_coleta_amostra desc"
                Else
                    ViewState.Item("sortExpression") = "nm_situacao_coleta_amostra asc"
                End If

            Case "nm_motivo_nao_coleta_amostra"
                If (ViewState.Item("sortExpression")) = "nm_motivo_nao_coleta_amostra asc" Then
                    ViewState.Item("sortExpression") = "nm_motivo_nao_coleta_amostra desc"
                Else
                    ViewState.Item("sortExpression") = "nm_motivo_nao_coleta_amostra asc"
                End If

            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If

        End Select

        loadData()

    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_produtor")



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub carregarCamposPropriedade()

        Try

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If

            Me.txt_cd_propriedade.Text = Me.hf_id_propriedade.Value.ToString

            If Not (customPage.getFilterValue("lupa_propriedade", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "cd_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Visible = True
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_propriedade", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_propriedade", "id_pessoa").Equals(String.Empty)) Then
                Me.hf_id_pessoa.Value = customPage.getFilterValue("lupa_propriedade", "id_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("colamostra", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("colamostra", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("colamostra", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("colamostra", txt_cd_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("colamostra", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("colamostra", lbl_nm_propriedade.ID, ViewState.Item("nm_propriedade").ToString)
            customPage.setFilter("colamostra", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("colamostra", txt_dia_ini.ID, ViewState.Item("dt_ini").ToString)
            customPage.setFilter("colamostra", txt_dia_fim.ID, ViewState.Item("dt_fim").ToString)
            customPage.setFilter("colamostra", cbo_situacao.ID, ViewState.Item("id_situacao_coleta_amostra").ToString)
            customPage.setFilter("colamostra", cbo_consistencia.ID, ViewState.Item("ds_consistencia").ToString)
            customPage.setFilter("colamostra", cbo_situacao_caderneta.ID, ViewState.Item("id_situacao_coleta").ToString)
            customPage.setFilter("colamostra", cbo_tipo_coleta.ID, ViewState.Item("id_tipo_coleta_analise_esalq").ToString)
            customPage.setFilter("colamostra", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            'Case "consistencias"
            '    loadConsistencias(Convert.ToInt32(e.CommandArgument.ToString()))

            'Case "delete"
            '    deleteAnaliseEsalq(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteAnaliseEsalq(ByVal id_analise_esalq As Integer)

        Try
            Dim analiseesalq As New AnaliseEsalq()
            analiseesalq.id_analise_esalq = id_analise_esalq
            analiseesalq.id_modificador = Convert.ToInt32(Session("id_login"))
            analiseesalq.deleteAnaliseEsalq()


            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 159
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim btn_delete As Anthem.ImageButton = CType(e.Row.FindControl("img_delete"), Anthem.ImageButton)
            Dim img_exportacao As Anthem.Image = CType(e.Row.FindControl("img_exportacao"), Anthem.Image)
            Dim img_manual As Anthem.Image = CType(e.Row.FindControl("img_manual"), Anthem.Image)
            Dim txt_dt_coleta As DataControlFieldCell = CType(e.Row.Cells(9), DataControlFieldCell)
            Dim txt_exportacao As Label = CType(e.Row.FindControl("st_exportacao"), Label)
            Dim txt_amostra_manual As Label = CType(e.Row.FindControl("id_coleta_amostra_manual"), Label)

            If txt_dt_coleta.Text.Equals(String.Empty) Or txt_dt_coleta.Text.Equals("&nbsp;") Then
                txt_dt_coleta.Text = String.Empty 'data de coleta
            Else
                txt_dt_coleta.Text = DateTime.Parse(txt_dt_coleta.Text).ToString("dd/MM/yyyy HH:mm") 'data de coleta
            End If

            'se amostra manual
            If txt_amostra_manual.Text.Equals(String.Empty) Then
                img_manual.ImageUrl = "~/img/ico_chk_false.gif"
            Else
                If CInt(txt_amostra_manual.Text) > 0 Then 'se amostra manual
                    img_manual.ImageUrl = "~/img/ico_chk_true.gif"
                Else
                    img_manual.ImageUrl = "~/img/ico_chk_false.gif"
                End If

            End If

            'se foi exportado
            If txt_exportacao.Text.Equals("S") Then 'se exportacao
                img_exportacao.ImageUrl = "~/img/ico_chk_true.gif"
            Else
                img_exportacao.ImageUrl = "~/img/ico_chk_false.gif"
            End If

        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        'fran 28/11/2009 i chamado 523 - o estabelecimento é para saber para qual estabel é o arquivo a ser importado
        'Me.lbl_nm_pessoa.Text = ""
        'Me.txt_cd_pessoa.Text = ""
        'Me.hf_id_pessoa.Value = ""
        'Me.lbl_nm_pessoa.Visible = False
        'Me.lbl_nm_propriedade.Text = ""
        'Me.txt_cd_propriedade.Text = ""
        'Me.hf_id_propriedade.Value = ""
        'Me.lbl_nm_propriedade.Visible = False
        'fran 28/11/2009 f chamado 523
    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()



    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged

        Try
            If Not txt_cd_pessoa.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_pessoa.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 'fran 05/05/2010
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_pessoa.Enabled = True
                    lbl_nm_pessoa.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        If Me.cbo_estabelecimento.SelectedValue <> "0" Then
            Me.lbl_nm_propriedade.Visible = True
            carregarCamposPropriedade()
        End If
    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged
        lbl_nm_propriedade.Text = ""
        lbl_nm_propriedade.Visible = False

    End Sub


    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                'se aprovacao <> 3- nao aprovado pelo sistema
                If Not CType(gridResults.Rows(li).FindControl("lbl_id_aprovacao_analise_esalq"), Label).Text.Equals(3) Then
                    ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                    ch.Checked = ck_header.Checked
                End If
            Next

            ' Seleciona tudo o que o botão Pesquisar trouxer - i

            Dim analiseesalq As New AnaliseEsalq
            analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")

            If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
                analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
                analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
            Else
                analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
                analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
            End If

            If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If
            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
            analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
            analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
            analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
            analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))  ' adri 02/09/2016 - chamado 2480 

            If ck_header.Checked = True Then
                analiseesalq.st_selecao = "1"
            Else
                analiseesalq.st_selecao = "0"
            End If
            analiseesalq.updateAnalisesEsalqSelecaoTodas()
            ' Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Protected Sub btn_ativar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_ativar.Click
    '    Try
    '        Dim analiseesalq As New AnaliseEsalq

    '        'If saveCheckBox() = True Then
    '        If Page.IsValid Then
    '            'Filtro
    '            analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
    '            If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
    '                analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
    '                analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
    '            Else
    '                analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
    '                analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
    '            End If

    '            If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
    '                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
    '            End If

    '            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
    '                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
    '            End If
    '            analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
    '            analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
    '            analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
    '            analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
    '            analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))

    '            'Dados para o Update
    '            analiseesalq.id_situacao = 1  '  Ativo
    '            analiseesalq.id_modificador = Session("id_login")
    '            analiseesalq.updateAnalisesEsalqSituacaoSelecionadasAtivar()

    '            loadData()

    '            messageControl.Alert("Análises Ativadas com sucesso.")
    '        End If
    '        'Else
    '        'messageControl.Alert("Nenhum item foi selecionado para ser ativado. Por favor selecione alguma análise.")
    '        'End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub
    'Protected Sub btn_inativar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_desativar.Click
    '    Try
    '        Dim analiseesalq As New AnaliseEsalq

    '        'If saveCheckBox() = True Then
    '        If Page.IsValid Then
    '            'Filtro
    '            analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
    '            If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
    '                analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
    '                analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
    '            Else
    '                analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
    '                analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
    '            End If

    '            If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
    '                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
    '            End If
    '            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
    '                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
    '            End If
    '            analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
    '            analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
    '            analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
    '            analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
    '            analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))


    '            'Dados para o Update
    '            analiseesalq.id_situacao = 2  '  Inativo
    '            analiseesalq.id_modificador = Session("id_login")
    '            analiseesalq.updateAnalisesEsalqSituacaoSelecionadas()

    '            loadData()

    '            messageControl.Alert("Análises Desativadas com sucesso.")
    '        End If
    '        'Else
    '        'messageControl.Alert("Nenhum item foi selecionado para ser desativado. Por favor selecione alguma análise.")
    '        'End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub
    'Private Function saveCheckBox() As Boolean

    '    Try

    '        Dim li As Integer

    '        Dim analiseesalq As New AnaliseEsalq
    '        For li = 0 To gridResults.Rows.Count - 1
    '            analiseesalq.id_analise_esalq = gridResults.DataKeys(li).Value.ToString
    '            If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
    '                analiseesalq.st_selecao = "1"
    '                saveCheckBox = True     ' Indica que tem item selecionado
    '            Else
    '                analiseesalq.st_selecao = "0"
    '            End If
    '            analiseesalq.updateAnalisesEsalqSelecao()
    '        Next

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Function

    'Protected Sub lk_liberar_calculo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_liberar_calculo.Click
    '    Try
    '        If Page.IsValid Then
    '            Dim li As Integer

    '            ' Verifica se selecionou linhas, pois mão pode haver seleção, a liberação é para toda a referencia/estabelecimento
    '            Dim analiseesalq As New AnaliseEsalq
    '            For li = 0 To gridResults.Rows.Count - 1
    '                analiseesalq.id_analise_esalq = gridResults.DataKeys(li).Value.ToString
    '                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
    '                    messageControl.Alert("Nenhum item deve estar selecionado pois todas as análises aprovadas do estabelecimento e referência serão liberadas para o Cálculo.")
    '                    Exit Sub
    '                End If
    '            Next

    '            ' Verifica se informou outros filtros
    '            If Me.txt_cd_propriedade.Text.Trim() <> "" Or cbo_codigo_esalq.SelectedIndex <> 0 Then
    '                messageControl.Alert("Nenhum filtro deve ser informado para a liberação das análises para o Cálculo, exceto o estabelecimento e referência.")
    '                Exit Sub
    '            End If

    '            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
    '            ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
    '            'ViewState.Item("id_pessoa") = String.Empty
    '            ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
    '            ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
    '            ViewState.Item("txt_dt_coleta_ini") = "01/" + Me.txt_dt_referencia.Text.Trim
    '            ViewState.Item("txt_dt_coleta_fim") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
    '            ViewState.Item("cd_analise_esalq") = Me.cbo_codigo_esalq.SelectedValue()
    '            ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue
    '            ViewState.Item("id_situacao_analise_esalq") = Me.cbo_consistencia.SelectedValue
    '            ViewState.Item("id_aprovacao_analise_esalq") = Me.cbo_aprovacao_analise_esalq.SelectedValue
    '            ViewState.Item("txt_dt_coleta") = Me.txt_dt_coleta.Text 'fran 26/07
    '            ViewState.Item("id_tipo_coleta_analise_esalq") = Me.cbo_tipo_coleta.SelectedValue 'fran 26/07

    '            'Filtro
    '            analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
    '            analiseesalq.dt_referencia = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
    '            analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
    '            analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
    '            analiseesalq.id_modificador = Session("id_login")
    '            analiseesalq.updateAnalisesEsalqHeader() ' Atualiza a coluna st_liberado_calculo para "S"

    '            'FRAN 08/12/2020 i incluir log 
    '            Dim usuariolog As New UsuarioLog
    '            usuariolog.id_usuario = Session("id_login")
    '            usuariolog.ds_id_session = Session.SessionID.ToString()
    '            usuariolog.id_tipo_log = 6 'processo
    '            usuariolog.id_menu_item = 159
    '            usuariolog.ds_nm_processo = "Conciliação Análises Esalq - Liberar para Cálculo"
    '            usuariolog.insertUsuarioLog()
    '            'FRAN 08/12/2020  incluir log 



    '            Me.lk_liberar_calculo.Enabled = False
    '            Me.btn_ativar.Enabled = False
    '            Me.btn_desativar.Enabled = False
    '            messageControl.Alert("As análises aprovadas do Estabelecimento/Referência foram liberadas para o Cálculo com sucesso!")

    '        End If

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub btn_consistir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_consistir.Click
    '    Try

    '        If Page.IsValid Then
    '            Dim analiseesalq As New AnaliseEsalq


    '            analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
    '            analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
    '            analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
    '            analiseesalq.id_modificador = Session("id_login")
    '            analiseesalq.ConsistirAnalises()

    '            messageControl.Alert("Consistências efetuadas com sucesso!")

    '            loadData()
    '        End If

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub btn_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_aprovar.Click
    '    Try
    '        If Page.IsValid Then

    '            Dim analiseesalq As New AnaliseEsalq

    '            'If saveCheckBox() = True Then

    '            'Filtro - deve sempre assumir as viewstates que vem do pesquisar
    '            analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
    '            If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
    '                analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
    '                analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
    '            Else
    '                analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
    '                analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
    '            End If

    '            If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
    '                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
    '            End If
    '            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
    '                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
    '            End If
    '            analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
    '            analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
    '            analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
    '            analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
    '            analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))

    '            'Dados para o Update
    '            analiseesalq.id_situacao = 1  '  Ativo
    '            analiseesalq.id_modificador = Session("id_login")

    '            analiseesalq.updateAnalisesEsalqAprovarSelecionadas()

    '            loadData()

    '            messageControl.Alert("Análises Aprovadas com sucesso.")
    '            'Else
    '            'messageControl.Alert("Nenhum item foi selecionado para ser aprovado. Por favor selecione alguma análise.")
    '            'End If

    '        End If

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub


    'Protected Sub btn_nao_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nao_aprovar.Click
    '    Try
    '        Dim analiseesalq As New AnaliseEsalq

    '        'If saveCheckBox() = True Then
    '        If Page.IsValid Then
    '            'Filtro
    '            analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
    '            If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
    '                analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
    '                analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
    '            Else
    '                analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
    '                analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
    '            End If

    '            If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
    '                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
    '            End If
    '            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
    '                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
    '            End If
    '            analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
    '            analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
    '            analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
    '            analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
    '            analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))


    '            'Dados para o Update
    '            analiseesalq.id_situacao = 1  '  Ativo
    '            analiseesalq.id_modificador = Session("id_login")
    '            analiseesalq.updateAnalisesEsalqNaoAprovarSelecionadas()

    '            loadData()

    '            messageControl.Alert("Análises Não Aprovadas com sucesso.")
    '        End If
    '        'Else
    '        'messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione alguma análise.")
    '        'End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub btn_Cancelar_aprovacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Cancelar_aprovacao.Click
    '    Try
    '        Dim analiseesalq As New AnaliseEsalq

    '        'If saveCheckBox() = True Then
    '        If Page.IsValid Then
    '            'Filtro
    '            analiseesalq.id_estabelecimento = ViewState.Item("id_estabelecimento")
    '            If ViewState.Item("txt_dt_coleta").Equals(String.Empty) Then 'fran 26/07/2016  i
    '                analiseesalq.dt_coleta_start = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini")).ToString("dd/MM/yyyy")
    '                analiseesalq.dt_coleta_end = Convert.ToDateTime(ViewState.Item("txt_dt_coleta_fim")).ToString("dd/MM/yyyy")
    '            Else
    '                analiseesalq.dt_coleta_start = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
    '                analiseesalq.dt_coleta_end = ViewState.Item("txt_dt_coleta").ToString 'fran 26/07/2016  i
    '            End If

    '            If Trim(Me.txt_cd_propriedade.Text.Trim()) <> "" Then
    '                analiseesalq.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
    '            End If
    '            If Not ViewState.Item("id_pessoa").ToString.Equals(String.Empty) Then
    '                analiseesalq.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
    '            End If
    '            analiseesalq.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
    '            analiseesalq.cd_analise_esalq = ViewState.Item("cd_analise_esalq")
    '            analiseesalq.id_situacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_situacao_analise_esalq"))
    '            analiseesalq.id_aprovacao_analise_esalq = Convert.ToInt32(ViewState.Item("id_aprovacao_analise_esalq"))
    '            analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq"))


    '            'Dados para o Update
    '            analiseesalq.id_situacao = 1  '  Ativo
    '            analiseesalq.id_modificador = Session("id_login")
    '            analiseesalq.updateAnalisesEsalqAprovacaoCancelarSelecionadas()

    '            loadData()

    '            messageControl.Alert("Análises Aprovadas/Não Aprovadas canceladas com sucesso.")
    '        End If
    '        'Else
    '        'messageControl.Alert("Nenhum item foi selecionado para ser carcelada aprovação/não aprovação. Por favor selecione alguma análise.")
    '        'End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub

    'Protected Sub cv_filtros_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_filtros.ServerValidate
    '    Dim lberro As Boolean = False
    '    Dim lmsg As String = String.Empty
    '    args.IsValid = True

    '    Try
    '        If Not (ViewState.Item("id_estabelecimento").ToString = cbo_estabelecimento.SelectedValue.ToString) Then
    '            lberro = True
    '        End If
    '        If Not (ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value) Then
    '            lberro = True
    '        End If
    '        If Not (ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()) Then
    '            lberro = True
    '        End If
    '        If Not (ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()) Then
    '            lberro = True
    '        End If
    '        If Not (ViewState.Item("txt_dt_coleta_ini") = "01/" + Me.txt_dt_referencia.Text.Trim) Then
    '            lberro = True
    '        End If
    '        If Not (ViewState.Item("cd_analise_esalq") = Me.cbo_codigo_esalq.SelectedValue()) Then
    '            lberro = True
    '        End If
    '        If Not (ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue) Then
    '            lberro = True
    '        End If
    '        If Not (ViewState.Item("id_situacao_analise_esalq") = Me.cbo_consistencia.SelectedValue) Then
    '            lberro = True
    '        End If
    '        If Not (ViewState.Item("id_aprovacao_analise_esalq") = Me.cbo_aprovacao_analise_esalq.SelectedValue) Then
    '            lberro = True
    '        End If
    '        If Not (ViewState.Item("txt_dt_coleta") = Me.txt_dt_coleta.Text) Then
    '            lberro = True
    '        End If
    '        If Not (ViewState.Item("id_tipo_coleta_analise_esalq") = Me.cbo_tipo_coleta.SelectedValue) Then
    '            lberro = True
    '        End If

    '        If lberro = True Then
    '            args.IsValid = False
    '            lmsg = "Os filtros selecionados estão divergentes dos resultados da pesquisa realizada. Por favor, selecione o botão 'Pesquisar' antes de prosseguir com qualquer ação."
    '        Else 'se não tem erro
    '            'assume que não selecionou nenhum item
    '            lmsg = "Nenhum item foi selecionado. Por favor, selecione alguma análise e prossiga com a ação desejada."
    '            lberro = True

    '            'verifica se tem item selecionado
    '            Dim li As Integer
    '            For li = 0 To gridResults.Rows.Count - 1
    '                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
    '                    lberro = False 'não tem erro, selecionou item
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '        If lberro = True Then
    '            args.IsValid = False
    '        End If

    '        If Not args.IsValid Then
    '            messageControl.Alert(lmsg)
    '        End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try
    'End Sub

    'Protected Sub cbo_situacao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_situacao.SelectedIndexChanged
    '    Try

    '        Select Case cbo_situacao.SelectedValue
    '            Case "1" 'ativo
    '                btn_ativar.Enabled = True
    '                btn_desativar.Enabled = True
    '                If cbo_aprovacao_analise_esalq.SelectedValue.Equals("0") Then 'se nao selecionou aprovacao
    '                    btn_aprovar.Enabled = True
    '                    btn_Cancelar_aprovacao.Enabled = True
    '                    btn_nao_aprovar.Enabled = True
    '                End If

    '            Case "2" 'inativo
    '                'se inativo
    '                btn_ativar.Enabled = True
    '                btn_aprovar.Enabled = False
    '                btn_Cancelar_aprovacao.Enabled = False
    '                btn_desativar.Enabled = False
    '                btn_nao_aprovar.Enabled = False

    '            Case "0" 'Selecione
    '                btn_ativar.Enabled = True
    '                btn_desativar.Enabled = True
    '                If cbo_aprovacao_analise_esalq.SelectedValue.Equals("0") Then 'se nao selecionou aprovacao
    '                    btn_aprovar.Enabled = True
    '                    btn_Cancelar_aprovacao.Enabled = True
    '                    btn_nao_aprovar.Enabled = True
    '                End If
    '        End Select


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)

    '    End Try
    'End Sub

    'Protected Sub cbo_aprovacao_analise_esalq_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_aprovacao_analise_esalq.SelectedIndexChanged
    '    Try

    '        Select Case cbo_aprovacao_analise_esalq.SelectedValue
    '            Case "1" 'aprovada
    '                btn_aprovar.Enabled = False
    '                btn_Cancelar_aprovacao.Enabled = True
    '                btn_nao_aprovar.Enabled = False
    '            Case "2" 'nçao aprovada
    '                btn_aprovar.Enabled = False
    '                btn_Cancelar_aprovacao.Enabled = True
    '                btn_nao_aprovar.Enabled = False
    '            Case "3" ' não aprovada sistema
    '                btn_aprovar.Enabled = False
    '                btn_Cancelar_aprovacao.Enabled = False
    '                btn_nao_aprovar.Enabled = False
    '            Case "4" 'agradandoaprovacao
    '                btn_aprovar.Enabled = True
    '                btn_Cancelar_aprovacao.Enabled = True
    '                btn_nao_aprovar.Enabled = True
    '            Case "0" 'selecionar
    '                btn_aprovar.Enabled = True
    '                btn_Cancelar_aprovacao.Enabled = True
    '                btn_nao_aprovar.Enabled = True

    '        End Select

    '        If cbo_situacao.SelectedValue.Equals("2") Then
    '            'se inativo
    '            btn_aprovar.Enabled = False
    '            btn_ativar.Enabled = True
    '            btn_Cancelar_aprovacao.Enabled = False
    '            btn_desativar.Enabled = False
    '            btn_nao_aprovar.Enabled = False

    '        End If


    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)

    '    End Try
    'End Sub

    Protected Sub ck_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim chk_selec As CheckBox

            chk_selec = CType(sender, CheckBox)

            '' Seleciona o item selecionado
            Dim analiseesalq As New AnaliseEsalq

            analiseesalq.id_analise_esalq = Convert.ToInt32(gridResults.DataKeys.Item(row.RowIndex).Value)
            If chk_selec.Checked = True Then
                analiseesalq.st_selecao = "1"
            Else
                analiseesalq.st_selecao = "0"
            End If
            analiseesalq.updateAnalisesEsalqSelecao()

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try


    End Sub
    '21/12/2016 - Mirella i 
    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click


        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("txt_dt_coleta_ini") = "01/" + Me.txt_dt_referencia.Text.Trim
        ViewState.Item("txt_dt_coleta_fim") = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_coleta_ini"))))
        'ViewState.Item("cd_analise_esalq") = Me.cbo_codigo_esalq.SelectedValue()
        ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue
        ViewState.Item("id_situacao_analise_esalq") = Me.cbo_consistencia.SelectedValue
        'ViewState.Item("txt_dt_coleta") = Me.txt_dt_coleta.Text
        ViewState.Item("id_tipo_coleta_analise_esalq") = Me.cbo_tipo_coleta.SelectedValue
        'ViewState.Item("id_aprovacao_analise_esalq") = Me.cbo_aprovacao_analise_esalq.SelectedValue

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 159
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 



        customPage.clearFilters("analise_esalq_conciliacao")

        saveFilters()
        Response.Redirect("frm_analise_esalq_conciliacao_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString() + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString() + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString() + "&txt_dt_coleta_ini=" + ViewState.Item("txt_dt_coleta_ini").ToString() + "&txt_dt_coleta_fim=" + ViewState.Item("txt_dt_coleta_fim").ToString() + "&cd_analise_esalq=" + ViewState.Item("cd_analise_esalq").ToString() + "&id_situacao=" + ViewState.Item("id_situacao").ToString() + "&id_situacao_analise_esalq=" + ViewState.Item("id_situacao_analise_esalq").ToString() + "&txt_dt_coleta=" + ViewState.Item("txt_dt_coleta").ToString() + "&id_tipo_coleta_analise_esalq=" + ViewState.Item("id_tipo_coleta_analise_esalq").ToString() + "&id_aprovacao_analise_esalq=" + ViewState.Item("id_aprovacao_analise_esalq"))

    End Sub   '21/12/2016 - Mirella f

    Protected Sub gridprodutor_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridprodutor.PageIndexChanging
        gridprodutor.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridprodutor_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridprodutor.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim img_manual As Anthem.Image = CType(e.Row.FindControl("img_amostramanual"), Anthem.Image)
            Dim st_coleta_amostra_manual As Label = CType(e.Row.FindControl("st_coleta_amostra_manual"), Label)


            'se amostra manual
            If st_coleta_amostra_manual.Text.Equals("S") Then 'se amostra manual st_coleta_amostra_manual
                img_manual.ImageUrl = "~/img/ico_chk_true.gif"
            Else
                img_manual.ImageUrl = "~/img/ico_chk_false.gif"
            End If

        End If

    End Sub

    Protected Sub gridprodutor_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridprodutor.Sorting
        Select Case e.SortExpression.ToLower()

            Case "cd_pessoa"
                If (ViewState.Item("sortExpression")) = "cd_pessoa asc" Then
                    ViewState.Item("sortExpression") = "cd_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "cd_pessoa asc"
                End If

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If

            Case "id_propriedade_matriz"
                If (ViewState.Item("sortExpression")) = "id_propriedade_matriz asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade_matriz desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade_matriz asc"
                End If

            Case "nm_abreviado"
                If (ViewState.Item("sortExpression")) = "nm_abreviado asc" Then
                    ViewState.Item("sortExpression") = "nm_abreviado desc"
                Else
                    ViewState.Item("sortExpression") = "nm_abreviado asc"
                End If
            Case "nm_pessoa"
                If (ViewState.Item("sortExpression")) = "nm_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_pessoa asc"
                End If

            Case "id_tipo_coleta_analise_esalq"
                If (ViewState.Item("sortExpression")) = "id_tipo_coleta_analise_esalq asc" Then
                    ViewState.Item("sortExpression") = "id_tipo_coleta_analise_esalq desc"
                Else
                    ViewState.Item("sortExpression") = "id_tipo_coleta_analise_esalq asc"
                End If

            Case "ds_periodo_dias"
                If (ViewState.Item("sortExpression")) = "ds_periodo_dias asc" Then
                    ViewState.Item("sortExpression") = "ds_periodo_dias desc"
                Else
                    ViewState.Item("sortExpression") = "ds_periodo_dias asc"
                End If


            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If

        End Select

        loadData()
    End Sub
End Class
