Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_central_conciliacao_contabilidade

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Page.IsValid Then


            ViewState.Item("txt_dt_referencia_ini") = String.Concat("01/", Me.txt_dt_referencia_ini.Text.Trim)
            ViewState.Item("txt_dt_referencia_fim") = String.Concat("01/", Me.txt_dt_referencia_fim.Text.Trim)
            ViewState.Item("st_tipo_visao") = opt_tipo_visao.SelectedValue

            ViewState.Item("chk_pedidos_abertos") = chk_pedidos_abertos.Checked

            If Not (txt_nr_saldoacumuladoSAP.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("nr_saldoacumuladoSAP") = Me.txt_nr_saldoacumuladoSAP.Text
            Else
                ViewState.Item("nr_saldoacumuladoSAP") = "0"
            End If

            loadData()
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_conciliacao_contabilidade.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_conciliacao_contabilidade.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 221
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

    End Sub


    Private Sub loadDetails()

        Try

            txt_dt_referencia_ini.Text = DateTime.Parse(Now).ToString("MM/yyyy")
            txt_dt_referencia_fim.Text = DateTime.Parse(Now).ToString("MM/yyyy")

            Dim pedido As New Pedido

            Dim dsPedidoSaldoAcumuladoSAP As DataSet = pedido.getCentralSaldoAcumuladoSAP()
            If dsPedidoSaldoAcumuladoSAP.Tables(0).Rows.Count > 0 Then
                With dsPedidoSaldoAcumuladoSAP.Tables(0).Rows(0)
                    txt_dt_referencia_saldoSAP.Text = .Item("dt_referencia").ToString
                    txt_nr_saldoacumuladoSAP.Text = .Item("nr_saldoacumuladoSAP").ToString
                End With
            End If

            ViewState.Item("sortExpression") = ""

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim pedido As New Pedido

            gridResults.Visible = False
            gridResultsSintetico.Visible = False
            gridAbertos.Visible = False
            lbl_abertos.Visible = False
            lbl_pedidos.Visible = False
            Select Case ViewState.Item("st_tipo_visao").ToString
                Case "A" ' Visão Analítica

                    pedido.dt_inicio = ViewState.Item("txt_dt_referencia_ini")
                    pedido.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_referencia_fim"))))
                    If ViewState.Item("chk_pedidos_abertos") = False Then

                        Dim dsPedidoVisaoAnalitica As DataSet = pedido.getCentralConciliacaoContabilidadeAnalitico()
                        If (dsPedidoVisaoAnalitica.Tables(0).Rows.Count > 0) Then
                            gridResults.Visible = True
                            lbl_pedidos.Visible = True

                            gridResults.DataSource = Helper.getDataView(dsPedidoVisaoAnalitica.Tables(0), ViewState.Item("sortExpression"))
                            gridResults.DataBind()
                        Else
                            gridResults.Visible = False
                            lbl_pedidos.Visible = False

                            messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                        End If
                    Else
                        Dim dsPedidoVisaoAnaliticaAbertos As DataSet = pedido.getCentralConciliacaoContabilidadeAnaliticoAbertos()
                        If (dsPedidoVisaoAnaliticaAbertos.Tables(0).Rows.Count > 0) Then
                            gridAbertos.Visible = True
                            lbl_abertos.Visible = True
                            gridAbertos.DataSource = Helper.getDataView(dsPedidoVisaoAnaliticaAbertos.Tables(0), ViewState.Item("sortExpression"))
                            gridAbertos.DataBind()
                        Else
                            gridAbertos.Visible = False
                            lbl_abertos.Visible = False

                            messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                        End If
                    End If

                Case "S" ' Visão Sintética

                    'Conforme solicitado, a visao sintetica deve ser anual, entao monta data em cima do ano da data fim
                    'pedido.dt_inicio = ViewState.Item("txt_dt_referencia_ini")
                    'pedido.dt_fim = ViewState.Item("txt_dt_referencia_fim")
                    'pedido.dt_fornec_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("txt_dt_referencia_fim"))))
                    Dim lano As String = DatePart(DateInterval.Year, CDate(ViewState.Item("txt_dt_referencia_ini"))).ToString
                    pedido.dt_inicio = DateTime.Parse(String.Concat("01/01/", lano.Trim)).ToString("dd/MM/yyyy")
                    pedido.dt_fim = DateTime.Parse(String.Concat("01/12/", lano.Trim)).ToString("dd/MM/yyyy")
                    pedido.dt_fornec_fim = DateTime.Parse(String.Concat("31/12/", lano.Trim)).ToString("dd/MM/yyyy")
                    pedido.nr_saldoacumuladoSAP = Convert.ToDecimal(txt_nr_saldoacumuladoSAP.Text)

                    Dim dsPedidoVisaoSintetica As DataSet = pedido.getCentralConciliacaoContabilidadeSintetico()
                    If (dsPedidoVisaoSintetica.Tables(0).Rows.Count > 0) Then
                        ViewState.Item("saldoacumuladoanterior") = 0
                        gridResultsSintetico.Visible = True
                        gridResultsSintetico.DataSource = Helper.getDataView(dsPedidoVisaoSintetica.Tables(0), ViewState.Item("sortExpression"))
                        gridResultsSintetico.DataBind()
                        ViewState.Item("saldoacumuladoanterior") = 0
                    Else
                        gridResultsSintetico.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If

            End Select

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        If Page.IsValid Then

            Try

                'FRAN ViewState.Item("st_tipo_visao") 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 8 'exporta~ção
                usuariolog.id_menu_item = 221
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                ViewState.Item("txt_dt_referencia_ini") = String.Concat("01/", Me.txt_dt_referencia_ini.Text.Trim)
                ViewState.Item("txt_dt_referencia_fim") = String.Concat("01/", Me.txt_dt_referencia_fim.Text.Trim)
                ViewState.Item("st_tipo_visao") = opt_tipo_visao.SelectedValue
                ViewState.Item("chk_pedidos_abertos") = chk_pedidos_abertos.Checked

                If Not (txt_nr_saldoacumuladoSAP.Text.Trim().Equals(String.Empty)) Then
                    ViewState.Item("nr_saldoacumuladoSAP") = Me.txt_nr_saldoacumuladoSAP.Text
                Else
                    ViewState.Item("nr_saldoacumuladoSAP") = "0"
                End If
                loadData()

                Select Case ViewState.Item("st_tipo_visao").ToString
                    Case "A" ' Visão Analítica

                        Response.Redirect("frm_central_conciliacao_analitico_excel.aspx?dt_referencia_ini=" + ViewState.Item("txt_dt_referencia_ini").ToString() + "&dt_referencia_fim=" + ViewState.Item("txt_dt_referencia_fim").ToString() + "&pedidos_abertos=" + ViewState.Item("chk_pedidos_abertos").ToString())

                    Case "S" ' Visão Sintética
                        'If Not (txt_nr_saldoacumuladoSAP.Text.Trim().Equals(String.Empty)) Then
                        '    ViewState.Item("nr_saldoacumuladoSAP") = txt_nr_saldoacumuladoSAP.Text
                        'Else
                        '    ViewState.Item("nr_saldoacumuladoSAP") = "0"
                        'End If

                        Response.Redirect("frm_central_conciliacao_sintetico_excel.aspx?dt_referencia_ini=" + ViewState.Item("txt_dt_referencia_ini").ToString() + "&dt_referencia_fim=" + ViewState.Item("txt_dt_referencia_fim").ToString() + "&nr_saldoacumuladoSAP=" + ViewState.Item("nr_saldoacumuladoSAP").ToString())

                End Select

            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If


    End Sub

    Protected Sub btn_atualizarsaldoSAP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_atualizarsaldoSAP.Click
        Try
            If Page.IsValid Then
                Dim pedido As New Pedido

                pedido.dt_referencia = String.Concat("01/", Me.txt_dt_referencia_saldoSAP.Text.Trim)

                If Not (txt_nr_saldoacumuladoSAP.Text.Trim().Equals(String.Empty)) Then
                    pedido.nr_saldoacumuladoSAP = Convert.ToDecimal(txt_nr_saldoacumuladoSAP.Text)
                Else
                    pedido.nr_saldoacumuladoSAP = 0
                End If

                pedido.id_modificador = Session("id_login")

                pedido.insertCentralSaldoAcumuladoSAP()

                messageControl.Alert("Saldo atualizado com sucesso.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Protected Sub cv_periodo_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_periodo.ServerValidate
        Try
            args.IsValid = True

            If CDate(String.Concat("01/", Me.txt_dt_referencia_fim.Text.Trim)) < CDate(String.Concat("01/", Me.txt_dt_referencia_ini.Text.Trim)) Then
                args.IsValid = False
                messageControl.Alert("A data final do período deve ser maior que a data inicial.")
            Else
                Dim lqtd_meses As Integer
                lqtd_meses = DateDiff(DateInterval.Month, CDate(String.Concat("01/", Me.txt_dt_referencia_ini.Text.Trim)), CDate(String.Concat("01/", Me.txt_dt_referencia_fim.Text.Trim)))
                If lqtd_meses > 12 Then
                    args.IsValid = False
                    messageControl.Alert("O período de consulta não deve ultrapassar um ano.")
                End If
            End If

            If args.IsValid = False Then
                gridResults.Visible = False
                gridAbertos.Visible = False
                gridResultsSintetico.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridAbertos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridAbertos.PageIndexChanging
        gridAbertos.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub


End Class
