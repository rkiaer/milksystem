Imports Danone.MilkSystem.Business
Imports System.IO
Imports System.Data
Imports System.Windows.Forms



Partial Class lst_exportar_batch

    Inherits Page

    Private customPage As RK.PageTools.CustomPage



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_exportar_batch.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 2 'ACESSO
            usuariolog.id_menu_item = 124
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        btn_exportar.Attributes.Add("onClick", "lbl_aguarde.className='aguardedestaque';")

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))
            ViewState.Item("tela_ativa") = 0 'Assume que a tela ativa é a da 1a aba
            grderros.Visible = False
            gridResults.Visible = False
            lbl_nr_execucao.Visible = False
            lbl_id_exportacao_batch_execucao.Visible = False
            lbl_status.Visible = False
            lbl_status_execucao.Visible = False
            pnl_tela1.Visible = False
            pnl_tela2.Visible = False
            'fran 25/09/2012 i - vir data do dia default
            txt_dt_inicio.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            txt_dt_fim.Text = DateTime.Parse(Now).ToString("dd/MM/yyyy")
            'fran 25/09/2012 f - vir data do dia default


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadgridbatch()

        Try

            Dim batchexecucao As New ExportacaoBatch
            batchexecucao.id_exportacao_batch_execucao = Convert.ToInt32(ViewState.Item("id_batch_execucao"))
            Dim dsbatchexecucao As DataSet = batchexecucao.getExportacaoBatchExecucaoByFilters
            If (dsbatchexecucao.Tables(0).Rows.Count > 0) Then
                'ViewState.Item("status_execucao") = dsfreteexecucao.Tables(0).Rows(0).Item("st_exportacao_frete_execucao")
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsbatchexecucao.Tables(0), "")
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadgridbatcherro()

        Try

            Dim batchexecucao As New ExportacaoBatch
            batchexecucao.id_exportacao_batch_execucao = Convert.ToInt32(ViewState.Item("id_batch_execucao"))
            Dim dsbatchexecucao As DataSet = batchexecucao.getExportacaoBatchErrosByFilters
            If (dsbatchexecucao.Tables(0).Rows.Count > 0) Then
                grderros.Visible = True
                grderros.DataSource = Helper.getDataView(dsbatchexecucao.Tables(0), "")
                grderros.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub exportData()

        Try

            'Dim romaneio As New Romaneio fran
            Dim execucaobatch As New ExportacaoBatch


            execucaobatch.st_exportacao_batch = ViewState.Item("st_exportacao_batch")
            execucaobatch.id_estabelecimento_filtro = ViewState.Item("id_estabelecimento")
            execucaobatch.dt_ini_filtro = ViewState.Item("dt_inicio").ToString
            execucaobatch.dt_fim_filtro = ViewState.Item("dt_fim").ToString
            execucaobatch.path_arquivobatch = ViewState.Item("caminho_arquivo")
            execucaobatch.st_aplicativo_gerador = "W" 'E para executavel e W para WEB 'fran 05/04/2012
            execucaobatch.id_modificador_batch = Session("id_login")
            If Not txt_id_romaneio.Text.Trim.Equals(String.Empty) Then
                execucaobatch.id_romaneio_filtro = txt_id_romaneio.Text
            End If
            'Se tem linhas 
            If (execucaobatch.getRomaneioExportacaoBatch).Tables(0).Rows.Count > 0 Then
                'execucaobatch.id_estabelecimento_filtro = ViewState.Item("id_estabelecimento")
                'execucaobatch.dt_ini_filtro = ViewState.Item("dt_inicio").ToString
                'execucaobatch.dt_fim_filtro = ViewState.Item("dt_fim").ToString
                'execucaobatch.st_exportacao_batch = ViewState.Item("st_exportacao_batch")
                'If Not txt_id_romaneio.Text.Trim.Equals(String.Empty) Then
                '    execucaobatch.id_romaneio_filtro = txt_id_romaneio.Text
                'End If
                execucaobatch.id_exportacao_batch_execucao = execucaobatch.insertExportacaoBatchExecucao()
                lbl_status.Visible = False
                lbl_id_exportacao_batch_execucao.Visible = False
                lbl_nr_execucao.Visible = False
                lbl_status_execucao.Visible = False
                gridResults.Visible = False
                grderros.Visible = False
                If execucaobatch.id_exportacao_batch_execucao = 0 Then
                    messageControl.Alert("Para esta seleção, todos os registros já foram exportados. Por favor tente novamente.")
                    pnl_tela2.Visible = False
                    pnl_tela1.Visible = False

                Else

                    ViewState.Item("id_batch_execucao") = execucaobatch.id_exportacao_batch_execucao
                    If execucaobatch.exportBatchDeclaration() = True Then
                        Dim exportacaoerros As New ExportacaoBatch
                        exportacaoerros.id_exportacao_batch_execucao = Convert.ToInt32(ViewState.Item("id_batch_execucao").ToString)
                        If exportacaoerros.getExportacaoBatchErrosByFilters.Tables(0).Rows.Count > 0 Then
                            messageControl.Alert("Exportação de Batch Declaration finalizada com inconsistências.")
                            pnl_tela2.Visible = True
                            pnl_tela1.Visible = True
                            Me.btn_erros.Visible = True
                        Else
                            messageControl.Alert("Exportação de Batch Declaration realizada com Sucesso.")
                            pnl_tela2.Visible = False
                            pnl_tela1.Visible = True

                        End If
                    Else
                        messageControl.Alert("Exportação de Batch Declaration realizada com erros. O período selecionado não foi finalizado completamente.")
                        pnl_tela2.Visible = True
                        pnl_tela1.Visible = True
                        Me.btn_erros.Visible = True
                        'Me.btn_erros.CommandArgument = .Item("id_romaneio_placa")
                    End If
                    ViewState.Item("tela_ativa") = 0 'Assume que a tela ativa é a da 1a aba
                    gridResults.Visible = True
                    lbl_nr_execucao.Visible = True
                    lbl_id_exportacao_batch_execucao.Visible = True
                    lbl_id_exportacao_batch_execucao.Text = ViewState.Item("id_batch_execucao").ToString
                    lbl_status.Visible = True
                    lbl_status_execucao.Visible = True
                    execucaobatch.id_exportacao_batch_execucao = Convert.ToInt32(ViewState.Item("id_batch_execucao").ToString)
                    ViewState.Item("st_exportacao_batch_execucao") = execucaobatch.getExportacaoBatchExecucaoByFilters.Tables(0).Rows(0).Item("st_exportacao_batch_execucao").ToString
                    If ViewState.Item("st_exportacao_batch_execucao").ToString.Trim = "I" Then
                        lbl_status_execucao.Text = "Iniciada"
                    Else
                        If ViewState.Item("st_exportacao_batch_execucao").ToString.Trim = "F" Then
                            lbl_status_execucao.Text = "Finalizada"
                        Else
                            lbl_status_execucao.Text = "Com Erros"
                        End If

                    End If
                    loadabas()
                End If
            Else
                messageControl.Alert("Nenhum registro foi encontrado para exportação. Por favor tente novamente.")
            End If


            '            lbl_totallidas.Text = romaneio.nr_linhaslidas
            '           lbl_totallinhas.Text = romaneio.nr_linhasexportadas


        Catch ex As Exception
            pnl_tela2.Visible = True
            pnl_tela1.Visible = True
            Me.btn_erros.Visible = True
            ViewState.Item("tela_ativa") = 0 'Assume que a tela ativa é a da 1a aba
            gridResults.Visible = True
            lbl_nr_execucao.Visible = True
            lbl_id_exportacao_batch_execucao.Visible = True
            lbl_id_exportacao_batch_execucao.Text = ViewState.Item("id_batch_execucao").ToString
            lbl_status.Visible = True
            lbl_status_execucao.Visible = True
            Dim execucao As New ExportacaoBatch
            execucao.id_exportacao_batch_execucao = Convert.ToInt32(ViewState.Item("id_batch_execucao").ToString)
            ViewState.Item("st_exportacao_batch_execucao") = execucao.getExportacaoBatchExecucaoByFilters.Tables(0).Rows(0).Item("st_exportacao_batch_execucao").ToString
            If ViewState.Item("st_exportacao_batch_execucao").ToString.Trim = "I" Then
                lbl_status_execucao.Text = "Iniciada"
            Else
                If ViewState.Item("st_exportacao_batch_execucao").ToString.Trim = "F" Then
                    lbl_status_execucao.Text = "Finalizada"
                Else
                    lbl_status_execucao.Text = "Com Erros"
                End If

            End If
            loadabas()

            messageControl.Alert("Exportação de Batch Declaration realizada com erros. O período selecionado não foi finalizado completamente.")

        End Try

    End Sub


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        Try

            Cursor.Current = Cursors.WaitCursor
            Dim lnomearquivo As String


            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("dt_inicio") = txt_dt_inicio.Text
            ViewState.Item("dt_fim") = txt_dt_fim.Text
            If (Me.txt_dt_fim.Text.Trim) = "" Then
                ViewState.Item("dt_fim") = Me.txt_dt_inicio.Text.Trim
            End If
            ViewState.Item("id_romaneio") = txt_id_romaneio.Text.Trim
            If chk_romaneios_exportados.Checked = True Then
                ViewState.Item("st_exportacao_batch") = "S"
            Else
                ViewState.Item("st_exportacao_batch") = "N"
            End If
            ViewState.Item("caminho_arquivo") = System.Configuration.ConfigurationManager.AppSettings("ArquivoBatch").ToString()

            'deleteArquivos()

            'lbl_totallidas.Visible = True
            'lbl_totallinhas.Visible = True
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 6 'processo
            usuariolog.id_menu_item = 124
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            exportData()
            lbl_aguarde.CssClass = "aguardenormal"

            Cursor.Current = Cursors.Default
 
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub deleteArquivos()
        Dim arquivos() As String
        Dim index As Integer
        Dim ldata As Date
        Dim ldata_limite As Date

        ldata_limite = DateAdd(DateInterval.Day, -3, Now)  ' 3 dias atras

        'Obtem a lista de arquivos no diretório 
        arquivos = Directory.GetFiles(ViewState.Item("caminho_arquivo").ToString)

        For index = 0 To arquivos.Length - 1
            arquivos(index) = New FileInfo(arquivos(index)).FullName


            Dim Arquivo As System.IO.FileInfo = New System.IO.FileInfo(arquivos(index))
            'Se o arquivo existir no servidor


            If InStr(arquivos(index), "MilkSystem_EstoqueMensal") <> 0 Then
                ldata = Arquivo.CreationTime
                If ldata < ldata_limite Then
                    Arquivo.Delete()
                End If
            End If
        Next index



    End Sub

    Protected Sub btn_resultado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_resultado.Click
        ViewState("tela_ativa") = 0
        loadabas()

    End Sub
    Private Sub loadabas()

        Try

            Dim lid_tela_ativa As Int32
            td_tela1.Attributes.Remove("class")
            If ViewState("tela_ativa") = 0 Then
                pnl_tela1.BackImageUrl = "~/img/aba_ativa.gif"
                pnl_tela1.ForeColor = System.Drawing.Color.FromName("#0000F5")
                btn_resultado.ForeColor = System.Drawing.Color.FromName("#0000F5")
                lid_tela_ativa = 0
            Else
                pnl_tela1.BackImageUrl = "~/img/aba_nao_ativa.gif"
                pnl_tela1.ForeColor = System.Drawing.Color.FromName("#6767CC")
                btn_resultado.ForeColor = System.Drawing.Color.FromName("#6767CC")
            End If
            If btn_erros.Visible = True Then
                'td_placa2.Attributes.Remove("class")
                If ViewState("tela_ativa") = 1 Then
                    'td_placa2.Attributes.Add("class", "aba_ativa")
                    pnl_tela2.BackImageUrl = "~/img/aba_ativa.gif"
                    pnl_tela2.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    btn_erros.ForeColor = System.Drawing.Color.FromName("#0000F5")
                    lid_tela_ativa = 1
                Else
                    'td_placa2.Attributes.Add("class", "aba_nao_ativa")
                    pnl_tela2.BackImageUrl = "~/img/aba_nao_ativa.gif"
                    pnl_tela2.ForeColor = System.Drawing.Color.FromName("#6767CC")
                    btn_erros.ForeColor = System.Drawing.Color.FromName("#6767CC")
                End If
            End If
            loadAbaAtiva(lid_tela_ativa)

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadAbaAtiva(ByVal id_aba As Int32)

        Try
            If id_aba = 0 Then
                grderros.Visible = False
                gridResults.Visible = True
                loadgridbatch()
            Else
                grderros.Visible = True
                gridResults.Visible = False
                loadgridbatcherro()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub btn_erros_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_erros.Click
        ViewState("tela_ativa") = 1
        loadabas()

    End Sub


    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        Me.loadgridbatch()

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
    And e.Row.RowType <> DataControlRowType.Footer _
    And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim hl_download As HyperLink = CType(e.Row.FindControl("hl_download"), HyperLink)

            If Not hl_download.Text.ToString.Equals(String.Empty) Then
                hl_download.NavigateUrl = String.Format("frm_download.aspx?arquivo={0}", hl_download.Text.ToString)
            End If

            'If e.Row.Cells(3).Text = 2 Then  ' Se finalizado com sucesso
            '    hl_download.Enabled = True
            'Else
            '    hl_download.Enabled = False
            'End If
        End If

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting
        'Select Case e.SortExpression.ToLower()

        '    Case "ds_transportadora"
        '        If (ViewState.Item("sortExpression")) = "ds_transportadora asc" Then
        '            ViewState.Item("sortExpression") = "ds_transportadora desc"
        '        Else
        '            ViewState.Item("sortExpression") = "ds_transportadora asc"
        '        End If


        '    Case "id_romaneio"
        '        If (ViewState.Item("sortExpression")) = "id_romaneio asc" Then
        '            ViewState.Item("sortExpression") = "id_romaneio desc"
        '        Else
        '            ViewState.Item("sortExpression") = "id_romaneio asc"
        '        End If

        '    Case "ds_placa_frete"
        '        If (ViewState.Item("sortExpression")) = "ds_placa_frete asc" Then
        '            ViewState.Item("sortExpression") = "ds_placa_frete desc"
        '        Else
        '            ViewState.Item("sortExpression") = "ds_placa_frete asc"
        '        End If

        '    Case "ds_cooperativa"
        '        If (ViewState.Item("sortExpression")) = "ds_cooperativa asc" Then
        '            ViewState.Item("sortExpression") = "ds_cooperativa desc"
        '        Else
        '            ViewState.Item("sortExpression") = "ds_cooperativa asc"
        '        End If
        '    Case "nr_caderneta"
        '        If (ViewState.Item("sortExpression")) = "nr_caderneta asc" Then
        '            ViewState.Item("sortExpression") = "nr_caderneta desc"
        '        Else
        '            ViewState.Item("sortExpression") = "nr_caderneta asc"
        '        End If
        '    Case "nm_arquivo"
        '        If (ViewState.Item("sortExpression")) = "nm_arquivo asc" Then
        '            ViewState.Item("sortExpression") = "nm_arquivo desc"
        '        Else
        '            ViewState.Item("sortExpression") = "nm_arquivo asc"
        '        End If
        '    Case "st_exportacao_frete_execucao_itens"
        '        If (ViewState.Item("sortExpression")) = "st_exportacao_frete_execucao_itens asc" Then
        '            ViewState.Item("sortExpression") = "st_exportacao_frete_execucao_itens desc"
        '        Else
        '            ViewState.Item("sortExpression") = "st_exportacao_frete_execucao_itens asc"
        '        End If

        'End Select

        'loadgridbatch()

    End Sub

    Protected Sub grderros_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grderros.PageIndexChanging
        grderros.PageIndex = e.NewPageIndex
        Me.loadgridbatcherro()

    End Sub

    Protected Sub grderros_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grderros.Sorting
        Select Case e.SortExpression.ToLower()

            Case "nm_erro"
                If (ViewState.Item("sortExpression")) = "nm_erro asc" Then
                    ViewState.Item("sortExpression") = "nm_erro desc"
                Else
                    ViewState.Item("sortExpression") = "nm_erro asc"
                End If

        End Select

        loadgridbatcherro()


    End Sub
End Class
