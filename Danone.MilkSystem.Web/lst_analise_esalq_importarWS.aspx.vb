Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data
Imports System.Windows.Forms


Partial Class lst_analise_esalq_importarWS
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_importar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_importar.Click
        Try
            Me.lbl_statusimportacaoclinica.Text = ""
            gridResults.Visible = False
            gridResults.UpdateAfterCallBack = True

            If Page.IsValid Then

                ' adri 09/10/2023 - insere linha na tabela ms_clinicaleiteheader para Servico ClinicaLeiteSrv ler e buscar os dados via WebService na data de processamento informada - i
                'ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("PathFiles").ToString()
                'ViewState.Item("nm_arquivo") = ViewState.Item("caminho_arquivo") + "\" + fup_nm_arquivo.FileName  ' 12/05/2010 chamado 835 (estava gravando em diretório incorreto)
                'If fup_nm_arquivo.FileName <> "" Then
                '    fup_nm_arquivo.SaveAs(ViewState.Item("nm_arquivo").ToString)
                'End If

                ViewState.Item("id_grupo") = Me.cbo_Grupo.SelectedValue  ' fran dez/2018
                ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
                ViewState.Item("id_tipo_coleta_analise_esalq") = cbo_tipo_coleta.SelectedValue 'fran 26/07/2016
                ViewState.Item("dt_processamento") = Me.txt_dt_processamento.Text

                Dim importacao As New Importacao
                importacao.st_tipo_importacao = 2
                importacao.dt_inicio_importacao = Now
                importacao.id_criacao = Convert.ToInt32(Session("id_login"))
                importacao.nm_arquivo = "importação WebService Clínica do Leite"
                importacao.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))

                ViewState.Item("id_importacao") = importacao.insertImportacao()

                ' Cria linha na ms_clinicaleiteheader para o Serviço de Importacao via WebService ler 
                Dim analiseesalq As New AnaliseEsalq
                Dim id_clinicaleiteheader As Int32
                analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
                analiseesalq.id_importacao = Convert.ToInt32(ViewState.Item("id_importacao"))
                analiseesalq.dt_processamento = ViewState.Item("dt_processamento").ToString
                analiseesalq.id_criacao = Convert.ToInt32(Session("id_login"))

                id_clinicaleiteheader = analiseesalq.insertClinicaLeiteHeader()  ' O serviço busca a cada 60s o dado nesta tabela e para visualizar o que foi importado deve ser acionado o botão Resultado

                ' adri 09/10/2023 - insere linha na tabela ms_clinicaleiteheader para Servico ClinicaLeiteSrv ler e buscar os dados via WebService na data de processamento informada - f



                ' adri 09/10/2023 desabiltado porque busca via WebService - i
                'lbl_totallidas.Visible = True
                'lbl_totalimportadas.Visible = True
                'lbl_totallinhaslidas.Visible = True
                'lbl_totallinhasimportadas.Visible = True

                'importData()        

                'deleteArquivos()
                ' adri 09/10/2023 desabiltado porque busca via WebService - f

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 241
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 


                'loadData()  '  09/10/2023 - rotina chamada no botão Resultado

                ' 10/10/2023
                'messageControl.Alert("O processo de importação foi solicitado e pode demorar alguns minutos. Verifique no botão Resultado os dados importados.")

                '19/10/2023
                'Raul 20081119 Coloquei 1 timer para atualizar a execucao e uma thread para executar o calculo
                btn_importar.Enabled = False
                btn_importar.UpdateAfterCallBack = True
                Label2.Visible = True
                ViewState.Item("tempo") = 0
                Label2.Text = "Execução em " & ViewState.Item("tempo").ToString & " segundos"
                Label2.UpdateAfterCallBack = True
                Image1.Visible = True
                Image1.UpdateAfterCallBack = True
                Timer1.Interval = 1000
                Timer1.Enabled = True
                Timer1.StartTimer()
                'SegundaThread = New Thread(AddressOf ThreadCode)
                'SegundaThread.Start()
                'Raul 20081119 Fim da alteracao

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_analise_esalq_importarWS.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 241
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020 i incluir log 

            loadDetails()
        End If
        btn_importar.Attributes.Add("onClick", "lbl_aguarde.className='aguardedestaque';")

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            'fran 27/11/2009 i maracanau chamado 523
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            ' adri - 19/10/2023 Fran pediu para deixar Tanque - i
            ''fran 27/11/2009 f maracanau chamado 523
            ''fran 26/07/2016 i 
            'Dim tipocoleta As New AnaliseEsalqTipoColeta
            'cbo_tipo_coleta.DataSource = tipocoleta.getAnaliseEsalqTipoColetaByFilters()
            'cbo_tipo_coleta.DataTextField = "nm_tipo_coleta_analise_esalq"
            'cbo_tipo_coleta.DataValueField = "id_tipo_coleta_analise_esalq"
            'cbo_tipo_coleta.DataBind()
            'cbo_tipo_coleta.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            ''fran 26/07/2016 f 
            ' adri - 19/10/2023 Fran pediu para deixar Tanque - f

            'fran dez/2018 i cooperativa
            Dim grupo As New Grupo
            cbo_Grupo.DataSource = grupo.getGruposByFilters()
            cbo_Grupo.DataTextField = "nm_grupo"
            cbo_Grupo.DataValueField = "id_grupo"
            cbo_Grupo.DataBind()
            cbo_Grupo.Items.Insert(0, New ListItem("[Selecione]", "0"))
            cbo_Grupo.Items.RemoveAt(2)   ' Remove item 2-Fornecedor de Insumos
            cbo_Grupo.Items.RemoveAt(2)   ' Remove item 3-Transportador
            cbo_Grupo.SelectedValue = 1   ' Assume como default na consulta o Produtor
            'fran dez/2018 f cooperativa

            ViewState.Item("id_importacao") = 0  ' adri 10/10/2023
            Me.lbl_statusimportacaoclinica.Text = "Não iniciada"


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()
        Try

            'Dim importacaolog As New ImportacaoLog

            'importacaolog.id_importacao = ViewState.Item("id_importacao")

            'Dim dsimportacaolog As DataSet = importacaolog.getImportacaoLogByFilters

            Dim analiseesalqerro As New AnaliseEsalqErro
            analiseesalqerro.id_importacao = ViewState.Item("id_importacao")
            Dim dsimportacaolog As DataSet = analiseesalqerro.getAnalisesEsalqErroByFilters()

            If (dsimportacaolog.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True

                'fran dez/2018 i
                If Convert.ToInt32(ViewState.Item("id_grupo")) = 4 Then 'grupo cooperativa
                    gridResults.Columns(2).Visible = True 'coluna cod cooperativa
                    gridResults.Columns(3).Visible = False 'coluna propriedade
                    gridResults.Columns(4).Visible = False 'coluna up
                Else
                    gridResults.Columns(2).Visible = False 'coluna cod cooperativa
                    gridResults.Columns(3).Visible = True 'coluna propriedade
                    gridResults.Columns(4).Visible = True 'coluna up
                End If
                'fran dez/2018 f

                gridResults.DataSource = Helper.getDataView(dsimportacaolog.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                ' 16/11/2008
            Else
                gridResults.Visible = False
                'messageControl.Alert("Não existem dados importados via WebService da Clínica do Leite para este Estabelecimento e Usuário.Aguarde alguns minutos e tente novamente.")
            End If

            'fran dez/2018 i
            If Convert.ToInt32(ViewState.Item("id_grupo")) = 4 Then 'grupo cooperativa
                Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_analise_esalq_cooperativa.aspx?id_importacao={0}", ViewState.Item("id_importacao").ToString)
                Me.hl_imprimir.Enabled = True

            Else
                ' 14/11/2008
                Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_analise_esalq.aspx?id_importacao={0}", ViewState.Item("id_importacao").ToString)
                Me.hl_imprimir.Enabled = True
            End If

            ' adri 11/10/2023
            Me.hl_imprimirWS.NavigateUrl = String.Format("frm_relatorio_analise_esalqWS.aspx?id_importacao={0}", ViewState.Item("id_importacao").ToString)
            Me.hl_imprimirWS.Enabled = True

            btn_importar.Enabled = True
            btn_importar.UpdateAfterCallBack = True


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub importData()

        Try

            Dim analiseesalq As New AnaliseEsalq
            'linha.id_estabelecimento = ViewState.Item("id_estabelecimento")
            analiseesalq.id_criacao = Convert.ToInt32(Session("id_login"))
            analiseesalq.nm_arquivo = ViewState.Item("nm_arquivo")
            'fran 27/11/2009 i maracanau chamado 523
            analiseesalq.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            'fran 27/11/2009 f maracanau chamado 523
            analiseesalq.id_tipo_coleta_analise_esalq = Convert.ToInt32(ViewState.Item("id_tipo_coleta_analise_esalq")) 'fran 26/07/2016

            'fran dez/2018 i
            If Convert.ToInt32(ViewState.Item("id_grupo")) = 4 Then
                ViewState.Item("id_importacao") = analiseesalq.importAnaliseEsalqCooperativa
                'fran dez/2018 f
            Else
                ViewState.Item("id_importacao") = analiseesalq.importAnaliseEsalq
            End If


            'lbl_totallinhaslidas.Text = analiseesalq.nr_linhaslidas
            lbl_statusimportacaoclinica.Text = analiseesalq.nr_linhasimportadas


        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "nr_linha"
                If (ViewState.Item("sortExpression")) = "nr_linha asc" Then
                    ViewState.Item("sortExpression") = "nr_linha desc"
                Else
                    ViewState.Item("sortExpression") = "nr_linha asc"
                End If


            Case "st_importacao"
                If (ViewState.Item("sortExpression")) = "st_importacao asc" Then
                    ViewState.Item("sortExpression") = "st_importacao desc"
                Else
                    ViewState.Item("sortExpression") = "st_importacao asc"
                End If

            Case "cd_erro"
                If (ViewState.Item("sortExpression")) = "cd_erro asc" Then
                    ViewState.Item("sortExpression") = "cd_erro desc"
                Else
                    ViewState.Item("sortExpression") = "cd_erro asc"
                End If

            Case "nm_erro"
                If (ViewState.Item("sortExpression")) = "nm_erro asc" Then
                    ViewState.Item("sortExpression") = "nm_erro desc"
                Else
                    ViewState.Item("sortExpression") = "nm_erro asc"
                End If

        End Select

        loadData()

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        'If (e.Row.RowType <> DataControlRowType.Header _
        '   And e.Row.RowType <> DataControlRowType.Footer _
        '   And e.Row.RowType <> DataControlRowType.Pager) Then

        '    If (e.Row.Cells(1).Text.Trim().Equals("1")) Then
        '        e.Row.Cells(1).Text = "Linha Importada com Sucesso"
        '    Else
        '        e.Row.Cells(1).Text = "Linha com Erro"
        '    End If

        'End If

    End Sub


    Protected Sub btn_resultado_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_resultado.Click
        Try

            If ViewState.Item("id_importacao") = 0 Then  ' Se saiu da sessão busca a ultima importação que o usuário fez via WebService
                Dim analiseesalq As New AnaliseEsalq
                'analiseesalq.id_criacao = Convert.ToInt32(Session("id_login"))  ' 19/10/2023 - Retirar filtro da busca por usuário que solicitou a importação 
                analiseesalq.id_estabelecimento = cbo_estabelecimento.SelectedValue

                ViewState.Item("id_importacao") = analiseesalq.getClinicaLeiteHeaderMax() ' traz a ultima importacao via WebService que o usuario fez para este estabelecimento
            End If

            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Protected Sub hl_imprimir_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles hl_imprimir.Load

    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Timer1.StopTimer()   'Para o timer para nao ter recursividade
        ViewState.Item("tempo") = Convert.ToInt32(ViewState.Item("tempo")) + 1
        Label2.Text = "Execução em " & ViewState.Item("tempo").ToString & " segundos"
        Label2.UpdateAfterCallBack = True

        Dim analiseesalq As New AnaliseEsalq
        Dim st_clinica_importacao As String = ""
        Dim dt_termino_importacao As String = ""
        Dim cd_statusclinica As String = ""
        analiseesalq.id_importacao = ViewState.Item("id_importacao")
        Dim dsanaliseesalq As DataSet = analiseesalq.getClinicaLeiteStatusImportacao()

        If (dsanaliseesalq.Tables(0).Rows.Count > 0) Then
            st_clinica_importacao = dsanaliseesalq.Tables(0).Rows(0).Item("st_importacaoWS").ToString
            dt_termino_importacao = dsanaliseesalq.Tables(0).Rows(0).Item("dt_termino_importacao").ToString
            cd_statusclinica = dsanaliseesalq.Tables(0).Rows(0).Item("cd_statusclinica").ToString
        End If

        If (st_clinica_importacao = "I" And dt_termino_importacao <> "") Or (st_clinica_importacao = "I" And cd_statusclinica <> "200") Then  ' Se fim do importacao (sucesso ou erro)
            Label2.Text = "Importação Clínica Leite Finalizada"
            Label2.Visible = True
            'Label2.Visible = False ' 19/10/2023 adri
            Label2.UpdateAfterCallBack = True
            Image1.Visible = False
            Image1.UpdateAfterCallBack = True
            btn_resultado.Enabled = True
            btn_resultado.UpdateAfterCallBack = True
            'gridResults.Enabled = False
            'gridResults.UpdateAfterCallBack = True

            Me.lbl_statusimportacaoclinica.Text = dsanaliseesalq.Tables(0).Rows(0).Item("cd_statusclinica").ToString + " - " + dsanaliseesalq.Tables(0).Rows(0).Item("ds_statusclinica").ToString

            loadData()
        Else
            If Convert.ToInt32(ViewState.Item("tempo")) >= 180 Then
                Label2.Text = "Importação Clínica Leite interrompida por tempo expirado."
                Label2.Visible = True
                Label2.UpdateAfterCallBack = True
                Image1.Visible = False
                Image1.UpdateAfterCallBack = True
                Me.lbl_statusimportacaoclinica.Text = "Servidor não está respondendo."

                btn_importar.Enabled = True
                btn_importar.UpdateAfterCallBack = True


            Else
                Timer1.StartTimer() 'se a execucao nao acabou continua com o timer
            End If

        End If


    End Sub

End Class
