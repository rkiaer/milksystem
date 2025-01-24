Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math


Partial Class lst_batch_declaration

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_romaneio") = txt_id_romaneio.Text.Trim()
        ViewState.Item("id_execucao") = txt_nr_execucao.Text.Trim()
        ViewState.Item("st_exportacao_batch_itens") = cbo_situacao.SelectedValue
        Dim lberro As Boolean = False
        If txt_dt_ini.Text.Trim.Equals(String.Empty) Then
            If Not txt_dt_fim.Text.Trim.Equals(String.Empty) Then
                txt_dt_ini.Text = txt_dt_fim.Text
            End If
        End If
        If txt_dt_fim.Text.Trim.Equals(String.Empty) Then
            If Not txt_dt_ini.Text.Trim.Equals(String.Empty) Then
                txt_dt_fim.Text = txt_dt_ini.Text
            End If
        End If
        ViewState.Item("dt_ini") = txt_dt_ini.Text.Trim.ToString
        ViewState.Item("dt_fim") = txt_dt_fim.Text.Trim.ToString
        If Not txt_dt_ini.Text.Trim.Equals(String.Empty) Then
            If CDate(txt_dt_ini.Text) > CDate(txt_dt_fim.Text) Then
                lberro = True
                messageControl.Alert("A data de entrada inicial deve ser menor do que a data de entrada final!")
            End If
        End If


        If lberro = False Then

            'loadData()
            loadAbaAtiva(ViewState("aba_ativa"))  ' adri 07/08/2012 - chamado 1577

        End If





    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_batch_declaration.aspx?limpar=S&st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_batch_declaration.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 125
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try


            If Not (Request("limpar") Is Nothing) Then  '  Se veio do Limpar Filtro
                txt_dt_ini.Text = ""
                txt_dt_fim.Text = ""
            Else
                txt_dt_ini.Text = Format(Date.Today, "dd/MM/yyyy").ToString()
                txt_dt_fim.Text = Format(Date.Today, "dd/MM/yyyy").ToString()
            End If

            ViewState.Item("sortExpression") = "id_exportacao_batch_execucao desc, id_exportacao_batch_itens asc"
            ViewState.Item("sortExpression_romaneios") = "id_romaneio asc"  ' adri 07/08/2012 - chamado 1577

            ViewState("aba_ativa") = 0  ' adri 07/08/2012 - chamado 1577 - Assume aba de Resultados como default

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    

    Private Sub loadData()

        Try
            Dim export As New ExportacaoBatch
            Dim dsbatch As DataSet

            If Not (ViewState.Item("id_romaneio").ToString.Equals(String.Empty)) Then
                export.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString())
            End If
            export.st_exportacao_batch_itens = ViewState.Item("st_exportacao_batch_itens").ToString()
            If Not ViewState.Item("id_execucao").ToString.Equals(String.Empty) Then
                export.id_exportacao_batch_execucao = ViewState.Item("id_execucao").ToString()
            End If
            export.dt_ini_filtro = ViewState.Item("dt_ini").ToString
            export.dt_fim_filtro = ViewState.Item("dt_fim").ToString
            dsbatch = export.getExportacaoBatchExecucaoByFilters()

            If (dsbatch.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsbatch.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


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


            Case "id_romaneio"
                If (ViewState.Item("sortExpression")) = "id_romaneio asc" Then
                    ViewState.Item("sortExpression") = "id_romaneio desc"
                Else
                    ViewState.Item("sortExpression") = "id_romaneio asc"
                End If
            Case "id_exportacao_batch_execucao"
                If (ViewState.Item("sortExpression")) = "id_exportacao_batch_execucao asc" Then
                    ViewState.Item("sortExpression") = "id_exportacao_batch_execucao desc"
                Else
                    ViewState.Item("sortExpression") = "id_exportacao_batch_execucao asc"
                End If
            Case "dt_hora_entrada"
                If (ViewState.Item("sortExpression")) = "dt_hora_entrada asc" Then
                    ViewState.Item("sortExpression") = "dt_hora_entrada desc"
                Else
                    ViewState.Item("sortExpression") = "dt_hora_entrada asc"
                End If
            Case "dt_ini_execucao_itens"
                If (ViewState.Item("sortExpression")) = "dt_ini_execucao_itens asc" Then
                    ViewState.Item("sortExpression") = "dt_ini_execucao_itens desc"
                Else
                    ViewState.Item("sortExpression") = "dt_ini_execucao_itens asc"
                End If
            Case "dt_ini_descarga"
                If (ViewState.Item("sortExpression")) = "dt_ini_descarga asc" Then
                    ViewState.Item("sortExpression") = "dt_ini_descarga desc"
                Else
                    ViewState.Item("sortExpression") = "dt_ini_descarga asc"
                End If

                ' adri 07/08/2012 - chamado 1577 - i
            Case "nr_caderneta"
                If (ViewState.Item("sortExpression")) = "nr_caderneta asc" Then
                    ViewState.Item("sortExpression") = "nr_caderneta desc"
                Else
                    ViewState.Item("sortExpression") = "nr_caderneta asc"
                End If
                ' adri 07/08/2012 - chamado 1577 - f

        End Select

        loadData()

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()
            Case "consultar"
                ViewState.Item("id_exportacao_batch_itens") = e.CommandArgument.ToString
                'loadGridErro()
                loadGridResults()
        End Select

    End Sub

   
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
And e.Row.RowType <> DataControlRowType.Footer _
And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_situacao As Anthem.Label = CType(e.Row.FindControl("lbl_situacao"), Anthem.Label)
            Dim lk_erros As Anthem.LinkButton = CType(e.Row.FindControl("lk_erro"), Anthem.LinkButton)

            If lbl_situacao.Text = "F" Then
                lbl_situacao.Text = "Finalizada"
                lk_erros.Visible = False
                lbl_situacao.Visible = True
            End If
            If lbl_situacao.Text = "I" Then
                lbl_situacao.Text = "Inicializada"
                lk_erros.Visible = False
                lbl_situacao.Visible = True
            End If
            If lbl_situacao.Text = "E" Then
                lbl_situacao.Text = "Finalizada"
                lk_erros.Visible = True
                lbl_situacao.Visible = False
            End If
            e.Row.Cells(3).Text = DateTime.Parse(e.Row.Cells(3).Text).ToString("dd/MM/yyyy")
            e.Row.Cells(4).Text = DateTime.Parse(e.Row.Cells(4).Text).ToString("dd/MM/yyyy")

            e.Row.Cells(5).Text = CInt(e.Row.Cells(5).Text).ToString
            If Not e.Row.Cells(6).Text.Equals("0") Then
                e.Row.Cells(6).Text = CInt(e.Row.Cells(6).Text).ToString

            End If

            e.Row.Cells(13).Text = Mid(e.Row.Cells(13).Text, InStr(e.Row.Cells(13).Text, "\") + 1)

            If (e.Row.RowType = DataControlRowType.DataRow) Then
                Try
                    If CLng(gridResults.DataKeys.Item(e.Row.RowIndex).Value) = CLng(ViewState.Item("id_exportacao_batch_itens")) Then
                        e.Row.ForeColor = Drawing.Color.Red
                    Else
                        e.Row.ForeColor = System.Drawing.Color.FromName("#333333")
                    End If
                Catch ex As Exception
                    messageControl.Alert(ex.Message)
                End Try
            End If

            'Dim lk_erros As Anthem.LinkButton = CType(e.Row.FindControl("lk_erro"), Anthem.LinkButton)
            'lk_erros.CommandArgument = e.Row.RowIndex.ToString
            With lk_erros
                .Attributes.Add("onclick", "javascript:ShowDialog(" + gridResults.DataKeys.Item(e.Row.RowIndex).Value.ToString + ")")
                .ToolTip = "Inconsistências"
                '.Style("cursor") = "hand"
            End With


        End If

    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                'Dim lk_erros As Anthem.LinkButton = CType(e.Row.FindControl("lk_erro"), Anthem.LinkButton)
                'lk_erros.CommandArgument = e.Row.RowIndex.ToString
                'With lk_erros
                '    .Attributes.Add("onclick", "javascript:ShowDialog()")
                '    .ToolTip = "Inconsistências"
                '    '.Style("cursor") = "hand"
                'End With
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub
    Private Sub loadGridErro()

        Try
            'Carrega os dados do Grid
            Dim batch As New ExportacaoBatch
            batch.id_exportacao_batch_itens = Convert.ToInt32(ViewState.Item("id_exportacao_batch_itens"))

            Dim erro As DataSet = batch.getExportacaoBatchErrosByFilters

            If (erro.Tables(0).Rows.Count > 0) Then
                grderros.Visible = True
                grderros.DataSource = Helper.getDataView(erro.Tables(0), ViewState.Item("sortExpression"))
                grderros.DataBind()

            Else
                grderros.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadGridResults()

        Try
            'Carrega os dados do Grid
            Dim export As New ExportacaoBatch
            Dim dsbatch As DataSet

            If Not (ViewState.Item("id_romaneio").ToString.Equals(String.Empty)) Then
                export.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString())
            End If
            export.st_exportacao_batch_itens = ViewState.Item("st_exportacao_batch_itens").ToString()
            If Not ViewState.Item("id_execucao").ToString.Equals(String.Empty) Then
                export.id_exportacao_batch_execucao = ViewState.Item("id_execucao").ToString()
            End If
            export.dt_ini_filtro = ViewState.Item("dt_ini").ToString
            export.dt_fim_filtro = ViewState.Item("dt_fim").ToString
            dsbatch = export.getExportacaoBatchExecucaoByFilters()

            If (dsbatch.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsbatch.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub grderros_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grderros.PageIndexChanging
        grderros.PageIndex = e.NewPageIndex
        loadGridErro()

    End Sub

    Protected Sub grderros_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grderros.Sorting
        Select Case e.SortExpression.ToLower()



            Case "nm_erro"
                If (ViewState.Item("sortExpression")) = "nm_erro asc" Then
                    ViewState.Item("sortExpression") = "nm_erro desc"
                Else
                    ViewState.Item("sortExpression") = "cd_analise asc"
                End If


        End Select

        loadGridErro()

    End Sub

    Protected Sub btn_resultados_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_resultados.Click
        ' adri 03/08/2012- chamado 1577 - Relatórios apoio Themis - i
        ViewState("aba_ativa") = 0
        loadabas()
        ' adri 03/08/2012- chamado 1577 - Relatórios apoio Themis - f

    End Sub

    Protected Sub btn_romaneios_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_romaneios.Click
        ' adri 03/08/2012- chamado 1577 - Relatórios apoio Themis - i
        ViewState("aba_ativa") = 1
        loadabas()
        ' adri 03/08/2012- chamado 1577 - Relatórios apoio Themis - f
    End Sub
    Private Sub loadabas()
        ' adri 03/08/2012- chamado 1577 - Relatórios apoio Themis - i

        Try

            'Dim lid_aba_ativa As Int32
            td_resultados.Attributes.Remove("class")
            If ViewState("aba_ativa") = 0 Then
                pnl_resultados.BackImageUrl = "~/img/aba_ativa.gif"
                pnl_resultados.ForeColor = System.Drawing.Color.FromName("#0000F5")
                pnl_resultados.ForeColor = System.Drawing.Color.FromName("#0000F5")
                'lid_aba_ativa = btn_resultados.CommandArgument
            Else
                pnl_resultados.BackImageUrl = "~/img/aba_nao_ativa.gif"
                pnl_resultados.ForeColor = System.Drawing.Color.FromName("#6767CC")
                btn_resultados.ForeColor = System.Drawing.Color.FromName("#6767CC")
            End If
            If ViewState("aba_ativa") = 1 Then
                pnl_romaneios.BackImageUrl = "~/img/aba_ativa.gif"
                pnl_romaneios.ForeColor = System.Drawing.Color.FromName("#0000F5")
                btn_romaneios.ForeColor = System.Drawing.Color.FromName("#0000F5")
                'lid_aba_ativa = btn_romaneios.CommandArgument
            Else
                pnl_romaneios.BackImageUrl = "~/img/aba_nao_ativa.gif"
                pnl_romaneios.ForeColor = System.Drawing.Color.FromName("#6767CC")
                btn_romaneios.ForeColor = System.Drawing.Color.FromName("#6767CC")
            End If

            loadAbaAtiva(ViewState("aba_ativa"))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

        ' adri 03/08/2012- chamado 1577 - Relatórios apoio Themis - f

    End Sub
    Private Sub loadAbaAtiva(ByVal id_aba_ativa As Int32)
        ' adri 03/08/2012- chamado 1577 - Relatórios apoio Themis - i

        Try

            If id_aba_ativa = 0 Then
                '=========================
                ' Se mostrar Resultados
                '=========================
                Dim export As New ExportacaoBatch
                Dim dsbatch As DataSet

                If Not (ViewState.Item("id_romaneio").ToString.Equals(String.Empty)) Then
                    export.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString())
                End If
                export.st_exportacao_batch_itens = ViewState.Item("st_exportacao_batch_itens").ToString()
                If Not ViewState.Item("id_execucao").ToString.Equals(String.Empty) Then
                    export.id_exportacao_batch_execucao = ViewState.Item("id_execucao").ToString()
                End If
                export.dt_ini_filtro = ViewState.Item("dt_ini").ToString
                export.dt_fim_filtro = ViewState.Item("dt_fim").ToString
                dsbatch = export.getExportacaoBatchExecucaoByFilters()

                'ViewState.Item("sortExpression") = "id_exportacao_batch_execucao desc, id_exportacao_batch_itens asc"
                gridRomaneios.Visible = False

                If (dsbatch.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsbatch.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                Else
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If


            Else
                '================================
                ' Se mostrar Romaneios do Período
                '================================

                ' adri 07/08/2012 - chamado 1577 - i
                If ViewState.Item("id_romaneio") = "" And ViewState.Item("dt_ini") = "" And ViewState.Item("dt_fim") = "" Then
                    messageControl.Alert("Informar o período de processamento ou o número do Romaneio!")
                    Exit Sub
                End If
                ' adri 07/08/2012 - chamado 1577- f

                Dim romaneio As New Romaneio
                Dim dsbatch As DataSet

                If Not (ViewState.Item("id_romaneio").ToString.Equals(String.Empty)) Then
                    romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString())
                End If

                'fran 09/08/2012 - deve exibir todos os romaneios
                'romaneio.id_st_romaneio = 4   ' Somente Romaneios Fechados
                romaneio.data_inicio = ViewState.Item("dt_ini").ToString
                romaneio.data_fim = ViewState.Item("dt_fim").ToString
                dsbatch = romaneio.getExportacaoBatchRomaneio()

                gridResults.Visible = False

                If (dsbatch.Tables(0).Rows.Count > 0) Then
                    gridRomaneios.Visible = True
                    gridRomaneios.DataSource = Helper.getDataView(dsbatch.Tables(0), ViewState.Item("sortExpression_romaneios"))
                    gridRomaneios.DataBind()
                Else
                    gridRomaneios.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If


            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

        ' adri 03/08/2012- chamado 1577 - Relatórios apoio Themis - f

    End Sub

    Protected Sub gridRomaneios_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridRomaneios.PageIndexChanging
        ' adri 07/08/2012- chamado 1577 - Relatórios apoio Themis - i
        gridRomaneios.PageIndex = e.NewPageIndex
        Me.loadAbaAtiva(ViewState("aba_ativa"))
        ' adri 03/08/2012- chamado 1577 - Relatórios apoio Themis - f

    End Sub

    Protected Sub gridRomaneios_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridRomaneios.RowDataBound
        'Fran 9/08/2012
        If (e.Row.RowType <> DataControlRowType.Header _
     And e.Row.RowType <> DataControlRowType.Footer _
     And e.Row.RowType <> DataControlRowType.Pager) Then
            Try
                Dim lvalor_volume As Decimal
                Dim lvariacao_volume_real As Decimal

                'coluna de volume em litros (litros reais)
                e.Row.Cells(5).Text = 0

                lvalor_volume = 0

                ' Busca Densidade e MG
                Dim lvalor_densidade As Decimal

                Dim romaneio As New Romaneio
                romaneio.id_romaneio = CLng(gridRomaneios.DataKeys.Item(e.Row.RowIndex).Value)
                lvalor_densidade = romaneio.getRomaneioCompartimentoMediaDens()

                'densidade
                e.Row.Cells(4).Text = FormatNumber(lvalor_densidade, 4)

                'Peso Liquido Balanca
                Dim lpeso As Decimal
                If Trim(e.Row.Cells(3).Text) <> "" Then
                    lpeso = Decimal.Truncate(Convert.ToDecimal(e.Row.Cells(3).Text))
                    e.Row.Cells(3).Text = lpeso.ToString
                Else
                    lpeso = 0
                End If
                If lvalor_densidade <> 0 Then
                    lvalor_volume = Decimal.Truncate(CDec(lpeso / lvalor_densidade))
                Else
                    lvalor_volume = 0
                End If

                e.Row.Cells(5).Text = lvalor_volume.ToString

                'variacao do volume
                'Peso liquido balança em litros - volume caderneta/nf em litros
                lvariacao_volume_real = Decimal.Truncate(lvalor_volume - CDec(e.Row.Cells(6).Text))
                If CLng(lvalor_volume) = 0 Then
                    e.Row.Cells(7).Text = String.Empty
                Else
                    e.Row.Cells(7).Text = lvariacao_volume_real.ToString
                End If

                If Not e.Row.Cells(6).Text.Equals(String.Empty) Then
                    e.Row.Cells(6).Text = Decimal.Truncate(e.Row.Cells(6).Text)
                End If
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If


    End Sub

    Protected Sub gridRomaneios_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridRomaneios.Sorting
        ' adri 07/08/2012 - chamado 1577 - i
        Select Case e.SortExpression.ToLower()

            Case "id_romaneio"
                If (ViewState.Item("sortExpression_romaneios_romaneios")) = "id_romaneio asc" Then
                    ViewState.Item("sortExpression_romaneios") = "id_romaneio desc"
                Else
                    ViewState.Item("sortExpression_romaneios") = "id_romaneio asc"
                End If
            Case "dt_hora_entrada"
                If (ViewState.Item("sortExpression_romaneios")) = "dt_hora_entrada asc" Then
                    ViewState.Item("sortExpression_romaneios") = "dt_hora_entrada desc"
                Else
                    ViewState.Item("sortExpression_romaneios") = "dt_hora_entrada asc"
                End If
            Case "dt_ini_descarga"
                If (ViewState.Item("sortExpression_romaneios")) = "dt_ini_descarga asc" Then
                    ViewState.Item("sortExpression_romaneios") = "dt_ini_descarga desc"
                Else
                    ViewState.Item("sortExpression_romaneios") = "dt_ini_descarga asc"
                End If

            Case "nr_caderneta"
                If (ViewState.Item("sortExpression_romaneios")) = "nr_caderneta asc" Then
                    ViewState.Item("sortExpression_romaneios") = "nr_caderneta desc"
                Else
                    ViewState.Item("sortExpression_romaneios") = "nr_caderneta asc"
                End If

            Case "st_exportacao_batch"
                If (ViewState.Item("sortExpression_romaneios")) = "st_exportacao_batch asc" Then
                    ViewState.Item("sortExpression_romaneios") = "st_exportacao_batch desc"
                Else
                    ViewState.Item("sortExpression_romaneios") = "st_exportacao_batch asc"
                End If

            Case "nm_registro_exportacao_batch"
                If (ViewState.Item("sortExpression_romaneios")) = "nm_registro_exportacao_batch asc" Then
                    ViewState.Item("sortExpression_romaneios") = "nm_registro_exportacao_batch desc"
                Else
                    ViewState.Item("sortExpression_romaneios") = "nm_registro_exportacao_batch asc"
                End If
                'fran 09/08/2012 i
            Case "nm_st_romaneio"
                If (ViewState.Item("sortExpression_romaneios")) = "nm_st_romaneio asc" Then
                    ViewState.Item("sortExpression_romaneios") = "nm_st_romaneio desc"
                Else
                    ViewState.Item("sortExpression_romaneios") = "nm_st_romaneio asc"
                End If
            Case "dt_registro_exportacao_batch"
                If (ViewState.Item("sortExpression_romaneios")) = "dt_registro_exportacao_batch asc" Then
                    ViewState.Item("sortExpression_romaneios") = "dt_registro_exportacao_batch desc"
                Else
                    ViewState.Item("sortExpression_romaneios") = "dt_registro_exportacao_batch asc"
                End If
            Case "dt_exportacao_batch"
                If (ViewState.Item("sortExpression_romaneios")) = "dt_exportacao_batch asc" Then
                    ViewState.Item("sortExpression_romaneios") = "dt_exportacao_batch desc"
                Else
                    ViewState.Item("sortExpression_romaneios") = "dt_exportacao_batch asc"
                End If

                'fran 09/08/2012 f
        End Select

        Me.loadAbaAtiva(ViewState("aba_ativa"))
        ' adri 07/08/2012 - chamado 1577 - f

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        ' adri 07/08/2012 - chamado 1577 - i
        ViewState.Item("id_romaneio") = txt_id_romaneio.Text.Trim()
        ViewState.Item("id_execucao") = txt_nr_execucao.Text.Trim()
        ViewState.Item("st_exportacao_batch_itens") = cbo_situacao.SelectedValue
        Dim lberro As Boolean = False
        If txt_dt_ini.Text.Trim.Equals(String.Empty) Then
            If Not txt_dt_fim.Text.Trim.Equals(String.Empty) Then
                txt_dt_ini.Text = txt_dt_fim.Text
            End If
        End If
        If txt_dt_fim.Text.Trim.Equals(String.Empty) Then
            If Not txt_dt_ini.Text.Trim.Equals(String.Empty) Then
                txt_dt_fim.Text = txt_dt_ini.Text
            End If
        End If
        ViewState.Item("dt_ini") = txt_dt_ini.Text.Trim.ToString
        ViewState.Item("dt_fim") = txt_dt_fim.Text.Trim.ToString
        If Not txt_dt_ini.Text.Trim.Equals(String.Empty) Then
            If CDate(txt_dt_ini.Text) > CDate(txt_dt_fim.Text) Then
                lberro = True
                messageControl.Alert("A data de entrada inicial deve ser menor do que a data de entrada final!")
            End If
        End If

        If ViewState("aba_ativa").ToString = "1" Then
            If ViewState.Item("id_romaneio") = "" And ViewState.Item("dt_ini") = "" And ViewState.Item("dt_fim") = "" Then
                lberro = True
                messageControl.Alert("Informar o período de processamento ou o número do Romaneio!")
            End If
        End If

        If lberro = False Then

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 125
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadAbaAtiva(ViewState("aba_ativa"))

            If (gridResults.Rows.Count.ToString + 1 > 65536) Or (gridRomaneios.Rows.Count.ToString + 1 > 65536) Then
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
            Else
                Response.Redirect("frm_batch_declaration_excel.aspx?id_romaneio=" + ViewState.Item("id_romaneio").ToString + "&id_execucao=" + ViewState.Item("id_execucao").ToString + "&st_exportacao_batch_itens=" + ViewState.Item("st_exportacao_batch_itens").ToString + "&dt_ini=" + ViewState.Item("dt_ini").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&aba_ativa=" + ViewState("aba_ativa").ToString)
            End If

        End If
        ' adri 07/08/2012 - chamado 1577 - f

    End Sub
End Class
