Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_central_demonst_participacao_produtores
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        btn_exportar.Visible = True

        If Not (txt_cd_tecnico.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("nm_tecnico") = lbl_nm_tecnico.Text.Trim()
            ViewState.Item("id_tecnico") = txt_cd_tecnico.Text 'fran 10/05/2010 i chamado 833
        Else
            ViewState.Item("nm_tecnico") = String.Empty
            ViewState.Item("id_tecnico") = String.Empty 'fran 10/05/2010 i chamado 833
        End If

        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia") = txt_dt_referencia.Text
        Else
            ViewState.Item("dt_referencia") = String.Empty

        End If

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        gridResults.Visible = False

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click
        'fran 10/05/2010 i chamado 833
        'Response.Redirect("lst_demonst_participacao_produtores.aspx")
        Response.Redirect("lst_central_demonst_participacao_produtores.aspx?st_incluirlog=N")
        'fran 10/05/2010 f chamado 833
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_relacao_produtores.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 105
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 


            loadDetails()
        End If

        With img_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialogTecnico()")
            .ToolTip = "Filtrar Técnicos"
        End With


    End Sub


    Private Sub loadDetails()

        Try

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim pedido As New Pedido

            'fran 10/05/2010 i chamado 833
            'If Not (ViewState("nm_tecnico").ToString().Equals(String.Empty)) Then
            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                'fran 10/05/2010 f chamado 833
                pedido.id_tecnico = Convert.ToString(ViewState.Item("id_tecnico"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("dt_referencia").ToString().Equals(String.Empty)) Then
                pedido.ano = ViewState.Item("dt_referencia")
            End If
            pedido.dt_inicio = String.Concat("01/01/", pedido.ano.ToString)
            pedido.dt_fim = String.Concat("01/12/", pedido.ano.ToString)

            Dim row As DataRow
            Dim dspedido As DataSet = pedido.getParticipacaoProdutores
            Dim dsparticipacaototaiscentral As DataSet = pedido.getParticipacaoProdutoresTotaisCentral

            For Each row In dspedido.Tables(0).Rows

                Select Case row.Item("periodo")
                    Case 1
                        If dsparticipacaototaiscentral.Tables(0).Select("periodo = 1").Length = 1 Then
                            row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 1")(0).ItemArray(1)
                            row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 1")(0).ItemArray(2)
                            row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 1")(0).ItemArray(3)
                            row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 1")(0).ItemArray(4)
                        End If
                    Case 2
                        If dsparticipacaototaiscentral.Tables(0).Select("periodo = 2").Length = 1 Then
                            row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 2")(0).ItemArray(1)
                            row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 2")(0).ItemArray(2)
                            row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 2")(0).ItemArray(3)
                            row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 2")(0).ItemArray(4)
                        End If
                    Case 3
                        If dsparticipacaototaiscentral.Tables(0).Select("periodo = 3").Length = 1 Then
                            row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 3")(0).ItemArray(1)
                            row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 3")(0).ItemArray(2)
                            row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 3")(0).ItemArray(3)
                            row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 3")(0).ItemArray(4)
                        End If
                    Case 4
                        If dsparticipacaototaiscentral.Tables(0).Select("periodo = 4").Length = 1 Then
                            row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 4")(0).ItemArray(1)
                            row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 4")(0).ItemArray(2)
                            row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 4")(0).ItemArray(3)
                            row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 4")(0).ItemArray(4)
                        End If
                    Case 5
                        If dsparticipacaototaiscentral.Tables(0).Select("periodo = 5").Length = 1 Then
                            row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 5")(0).ItemArray(1)
                            row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 5")(0).ItemArray(2)
                            row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 5")(0).ItemArray(3)
                            row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 5")(0).ItemArray(4)
                        End If
                    Case 6
                        If dsparticipacaototaiscentral.Tables(0).Select("periodo = 6").Length = 1 Then
                            row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 6")(0).ItemArray(1)
                            row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 6")(0).ItemArray(2)
                            row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 6")(0).ItemArray(3)
                            row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 6")(0).ItemArray(4)
                        End If
                    Case 7
                        If dsparticipacaototaiscentral.Tables(0).Select("periodo = 7").Length = 1 Then
                            row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 7")(0).ItemArray(1)
                            row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 7")(0).ItemArray(2)
                            row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 7")(0).ItemArray(3)
                            row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 7")(0).ItemArray(4)
                        End If
                    Case 8
                        If dsparticipacaototaiscentral.Tables(0).Select("periodo = 8").Length = 1 Then
                            row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 8")(0).ItemArray(1)
                            row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 8")(0).ItemArray(2)
                            row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 8")(0).ItemArray(3)
                            row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 8")(0).ItemArray(4)
                        End If
                    Case 9
                        If dsparticipacaototaiscentral.Tables(0).Select("periodo = 9").Length = 1 Then
                            row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 9")(0).ItemArray(1)
                            row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 9")(0).ItemArray(2)
                            row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 9")(0).ItemArray(3)
                            row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 9")(0).ItemArray(4)
                        End If
                    Case 10
                        If dsparticipacaototaiscentral.Tables(0).Select("periodo = 10").Length = 1 Then
                            row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 10")(0).ItemArray(1)
                            row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 10")(0).ItemArray(2)
                            row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 10")(0).ItemArray(3)
                            row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 10")(0).ItemArray(4)
                        End If
                    Case 11
                        If dsparticipacaototaiscentral.Tables(0).Select("periodo = 11").Length = 1 Then
                            row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 11")(0).ItemArray(1)
                            row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 11")(0).ItemArray(2)
                            row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 11")(0).ItemArray(3)
                            row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 11")(0).ItemArray(4)
                        End If
                    Case 12
                        If dsparticipacaototaiscentral.Tables(0).Select("periodo = 12").Length = 1 Then
                            row.Item("nr_compras_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 12")(0).ItemArray(1)
                            row.Item("nr_produtores_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 12")(0).ItemArray(2)
                            row.Item("nr_educampo_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 12")(0).ItemArray(3)
                            row.Item("nr_volume_central") = dsparticipacaototaiscentral.Tables(0).Select("periodo = 12")(0).ItemArray(4)
                        End If
                End Select
            Next

            If (dspedido.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dspedido.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            'fran 10/05/2010 i chamado 833
            'Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_central_demonst_participacao_produtores.aspx?dt_referencia={0}", Me.txt_dt_referencia.Text) & String.Format("&id_estabelecimento={0}", Me.cbo_estabelecimento.SelectedValue) & String.Format("&id_tecnico={0}", Me.hf_id_tecnico.Value)
            Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_central_demonst_participacao_produtores.aspx?dt_referencia={0}", pedido.ano.ToString) & String.Format("&id_estabelecimento={0}", pedido.id_estabelecimento.ToString) & String.Format("&id_tecnico={0}", pedido.id_tecnico.ToString)
            'fran 10/05/2010 f chamado 833
            Me.hl_imprimir.Enabled = True

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
          And e.Row.RowType <> DataControlRowType.Footer _
          And e.Row.RowType <> DataControlRowType.Pager) Then
            Dim data As Date = Convert.ToDateTime(e.Row.Cells(0).Text + "/" + ViewState.Item("dt_referencia"))
            If (e.Row.Cells(0).Text.Trim() > 0) Then
                e.Row.Cells(0).Text = Format(data, "MMM").ToString.ToUpper
            End If

            ' Adriana 10/11/2009 - i
            Dim pedido As New Pedido
            Dim nr_percentual As Decimal

            pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            pedido.dt_referencia = "01/" & Month( data ) & "/" & ViewState.Item("dt_referencia")
            pedido.dt_inicio = "01/" & Month(data) & "/" & ViewState.Item("dt_referencia")
            pedido.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pedido.dt_inicio)))
            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                'fran 10/05/2010 f chamado 833
                pedido.id_tecnico = Convert.ToString(ViewState.Item("id_tecnico"))
            End If

            ' Faturamento Mensal de todos os Produtores
            e.Row.Cells(1).Text = FormatNumber(pedido.getCentralFaturamentoMesProdutores(), 2)

            ' Volume Mensal de todos os Produtores no mes
            'fran chamado 833 i - 12/05/2010
            'e.Row.Cells(2).Text = FormatNumber(pedido.getCentralVolumeMesProdutores(), 0)
            e.Row.Cells(2).Text = FormatNumber(e.Row.Cells(2).Text, 0)
            'fran chamado 833 i - 12/05/2010

            ' Número de Produtores no mes
            'fran chamado 833 i - 12/05/2010
            'e.Row.Cells(3).Text = FormatNumber(pedido.getCentralQtdMesProdutores(), 0)
            e.Row.Cells(3).Text = FormatNumber(e.Row.Cells(3).Text, 0)
            'fran chamado 833 i - 12/05/2010

            ' Número de Produtores Educampo no mes
            'fran chamado 833 i - 12/05/2010
            'e.Row.Cells(4).Text = FormatNumber(pedido.getCentralQtdMesProdutoresEducampo(), 0)
            e.Row.Cells(4).Text = FormatNumber(e.Row.Cells(4).Text, 0)
            'e.Row.Cells(7).Text = FormatNumber(pedido.getCentralComprasCentral(), 2)

            'pedido.dt_fim = pedido.dt_inicio 'mesma referencia inico e fim (faz between)

            'e.Row.Cells(9).Text = FormatNumber(pedido.getValorTotalComprasbyPeriodo, 2) 'fran 2016
            'e.Row.Cells(11).Text = FormatNumber(pedido.getCentralVolumeCentral(), 0)
            e.Row.Cells(9).Text = FormatNumber(e.Row.Cells(9).Text, 2)
            e.Row.Cells(11).Text = FormatNumber(e.Row.Cells(11).Text, 0)

            'fran chamado 833 f - 12/05/2010

            ' Número de Produtores Central no mes
            'pedido.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pedido.dt_inicio)))
            'e.Row.Cells(5).Text = FormatNumber(pedido.getCentralQtdMesProdutoresCentral(), 0)
            e.Row.Cells(5).Text = FormatNumber(e.Row.Cells(5).Text, 0)

            ' % Produtores Central no mes
            If Convert.ToDecimal(e.Row.Cells(3).Text) > 0 Then
                nr_percentual = FormatNumber((Convert.ToDecimal(e.Row.Cells(5).Text) / Convert.ToDecimal(e.Row.Cells(3).Text)) * 100, 2)
            Else
                nr_percentual = 0
            End If

            e.Row.Cells(6).Text = Convert.ToString(nr_percentual) & "%"

            ' Número de Produtores Central Educampo no mes
            'e.Row.Cells(7).Text = FormatNumber(pedido.getCentralQtdMesProdutoresCentralEducampo(), 0)
            e.Row.Cells(7).Text = FormatNumber(e.Row.Cells(7).Text, 0)

            ' % Produtores Central Educampo no mes
            If Convert.ToDecimal(e.Row.Cells(4).Text) > 0 Then
                nr_percentual = FormatNumber((Convert.ToDecimal(e.Row.Cells(7).Text) / Convert.ToDecimal(e.Row.Cells(4).Text)) * 100, 2)
            Else
                nr_percentual = 0
            End If

            e.Row.Cells(8).Text = Convert.ToString(nr_percentual) & "%"

            ' % Compras na Central
            If Convert.ToDecimal(e.Row.Cells(1).Text) > 0 Then
                nr_percentual = FormatNumber((Convert.ToDecimal(e.Row.Cells(9).Text) / Convert.ToDecimal(e.Row.Cells(1).Text)) * 100, 2)
            Else
                nr_percentual = 0
            End If

            e.Row.Cells(10).Text = Convert.ToString(nr_percentual) & "%"


            ' % Volume Central
            If Convert.ToDecimal(e.Row.Cells(2).Text) > 0 Then
                nr_percentual = FormatNumber((Convert.ToDecimal(e.Row.Cells(11).Text) / Convert.ToDecimal(e.Row.Cells(2).Text)) * 100, 2)
            Else
                nr_percentual = 0
            End If

            e.Row.Cells(12).Text = Convert.ToString(nr_percentual) & "%"

            ' Adriana 10/11/2009 - f

        End If
    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "cd_parceiro"
                If (ViewState.Item("sortExpression")) = "cd_parceiro asc" Then
                    ViewState.Item("sortExpression") = "cd_parceiro desc"
                Else
                    ViewState.Item("sortExpression") = "cd_parceiro asc"
                End If

        End Select

        loadData()

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()
    End Sub


    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click


        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia") = txt_dt_referencia.Text
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        'ViewState.Item("id_tecnico") = hf_id_tecnico.Value 'fran 10/05/2010 i chamado 833
        ViewState.Item("id_tecnico") = txt_cd_tecnico.Text.ToString 'fran 10/05/2010 i chamado 833

        gridResults.Visible = False
        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 105
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 

        loadData()

        Response.Redirect("frm_central_demonst_participacao_produtores_excel.aspx?id_tecnico=" + ViewState.Item("id_tecnico").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString)


    End Sub
    Protected Sub img_lupa_tecnico_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_tecnico.Click
        carregarCampostecnico()
    End Sub
    Private Sub carregarCampostecnico()
        Try

            If Not (customPage.getFilterValue("lupa_tecnico", "nm_tecnico").Equals(String.Empty)) Then
                lbl_nm_tecnico.Text = customPage.getFilterValue("lupa_tecnico", "nm_tecnico").ToString
            End If

            txt_cd_tecnico.Text = hf_id_tecnico.Value

            Me.ViewState.Item("id_tecnico") = hf_id_tecnico.Value
            customPage.clearFilters("lupa_tecnico")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
        ' Fran 04/05/2010 - i
        lbl_nm_tecnico.Text = String.Empty
        hf_id_tecnico.Value = String.Empty
        Try
            If Not txt_cd_tecnico.Text.ToString.Equals(String.Empty) Then
                Dim tecnico As New Tecnico
                tecnico.id_tecnico = txt_cd_tecnico.Text.Trim
                Dim dstecnico As DataSet = tecnico.getTecnicoByFilters
                If dstecnico.Tables(0).Rows.Count > 0 Then
                    lbl_nm_tecnico.Enabled = True
                    lbl_nm_tecnico.Text = dstecnico.Tables(0).Rows(0).Item("nm_tecnico")
                    hf_id_tecnico.Value = dstecnico.Tables(0).Rows(0).Item("id_tecnico").ToString

                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' Fran 04/05/2010 - f

    End Sub
End Class

