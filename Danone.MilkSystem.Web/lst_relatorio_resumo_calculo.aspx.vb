Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class lst_relatorio_resumo_calculo

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("data") = Me.txt_data.Text.Trim

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_relatorio_resumo_calculo.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_resumo_calculo.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 49
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 


            loadDetails()
        End If

    End Sub


    Private Sub loadDetails()

        Try



            txt_data.Text = DateTime.Parse(Now).ToString("MM/yyyy")
            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("relatorio_resumocalculo", txt_data.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("data") = customPage.getFilterValue("relatorio_resumocalculo", txt_data.ID)
            txt_data.Text = ViewState.Item("data").ToString()
        Else
            ViewState.Item("data") = String.Empty
        End If


        If Not (customPage.getFilterValue("relatorio_resumocalculo", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("relatorio_resumocalculo", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("relatorio_resumocalculo")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim fichafinanceira As New FichaFinanceira


            ViewState.Item("total_volumereal") = 0
            ViewState.Item("total_negociado") = 0
            ViewState.Item("total_notafiscal") = 0
            ViewState.Item("total_incentivo") = 0
            ViewState.Item("total_frete") = 0
            ViewState.Item("total_qualidade") = 0
            ViewState.Item("total_geral") = 0

            fichafinanceira.dt_referencia = "01/" & ViewState.Item("data").ToString
            Dim dsResumoCalculo As DataSet = fichafinanceira.getCalculoResumoProdutor()

            If (dsResumoCalculo.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsResumoCalculo.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            ViewState.Item("total_volumereal_cp") = 0
            ViewState.Item("total_negociado_cp") = 0
            'ViewState.Item("total_notafiscal_cp") = 0
            ViewState.Item("total_incentivo_cp") = 0
            ViewState.Item("total_frete_cp") = 0
            ViewState.Item("total_qualidade_cp") = 0
            'ViewState.Item("total_geral") = 0

            Dim dsResumoCalculoCooperativa As DataSet = fichafinanceira.getCalculoResumoCooperativa()

            If (dsResumoCalculo.Tables(0).Rows.Count > 0) Then
                gridCooperativa.Visible = True
                gridCooperativa.DataSource = Helper.getDataView(dsResumoCalculoCooperativa.Tables(0), ViewState.Item("sortExpression"))
                gridCooperativa.DataBind()
            End If

            Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_resumo_calculo.aspx?data={0}", Me.txt_data.Text)
            Me.hl_imprimir.Enabled = True

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        'Select Case e.SortExpression.ToLower()


        '    Case "ds_placa"
        '        If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
        '            ViewState.Item("sortExpression") = "ds_placa desc"
        '        Else
        '            ViewState.Item("sortExpression") = "ds_placa asc"
        '        End If


        'End Select

        'loadData()

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("relatorio_controleleite", txt_data.ID, ViewState.Item("data").ToString)
            customPage.setFilter("relatorio_controleleite", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand


    End Sub

    Private Sub deleteAnaliseEsalq(ByVal id_analise_esalq As Integer)


    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvalor_total As Decimal


            ' Soma colunas Nota Fiscal + Incentivo + Frete+ Qualidade
            lvalor_total = FormatNumber(Convert.ToDecimal(e.Row.Cells(3).Text) + Convert.ToDecimal(e.Row.Cells(4).Text) + Convert.ToDecimal(e.Row.Cells(5).Text) + Convert.ToDecimal(e.Row.Cells(6).Text), 4)
            e.Row.Cells(7).Text = FormatNumber(lvalor_total, 4)

            ViewState.Item("total_volumereal") = Convert.ToDecimal(ViewState.Item("total_volumereal")) + Convert.ToDecimal(e.Row.Cells(1).Text)
            ViewState.Item("total_negociado") = Convert.ToDecimal(ViewState.Item("total_negociado")) + (Convert.ToDecimal(e.Row.Cells(2).Text) * Convert.ToDecimal(e.Row.Cells(1).Text))
            ViewState.Item("total_notafiscal") = Convert.ToDecimal(ViewState.Item("total_notafiscal")) + (Convert.ToDecimal(e.Row.Cells(3).Text) * Convert.ToDecimal(e.Row.Cells(1).Text))
            ViewState.Item("total_incentivo") = Convert.ToDecimal(ViewState.Item("total_incentivo")) + (Convert.ToDecimal(e.Row.Cells(4).Text) * Convert.ToDecimal(e.Row.Cells(1).Text))
            ViewState.Item("total_frete") = Convert.ToDecimal(ViewState.Item("total_frete")) + (Convert.ToDecimal(e.Row.Cells(5).Text) * Convert.ToDecimal(e.Row.Cells(1).Text))
            ViewState.Item("total_qualidade") = Convert.ToDecimal(ViewState.Item("total_qualidade")) + (Convert.ToDecimal(e.Row.Cells(6).Text) * Convert.ToDecimal(e.Row.Cells(1).Text))
            ViewState.Item("total_geral") = Convert.ToDecimal(ViewState.Item("total_geral")) + Convert.ToDecimal(e.Row.Cells(7).Text)

            'Formata as casas decimais e pontos
            e.Row.Cells(1).Text = FormatNumber(e.Row.Cells(1).Text, 0)
            e.Row.Cells(2).Text = FormatNumber(e.Row.Cells(2).Text, 4)
            e.Row.Cells(3).Text = FormatNumber(e.Row.Cells(3).Text, 4)
            e.Row.Cells(4).Text = FormatNumber(e.Row.Cells(4).Text, 4)
            e.Row.Cells(5).Text = FormatNumber(e.Row.Cells(5).Text, 4)
            e.Row.Cells(6).Text = FormatNumber(e.Row.Cells(6).Text, 4)
            e.Row.Cells(7).Text = FormatNumber(e.Row.Cells(7).Text, 4)

        End If

        If (e.Row.RowType = DataControlRowType.Footer) Then
            e.Row.Cells(0).Text = "Custo Produtor"
            If Convert.ToDecimal(ViewState.Item("total_volumereal")) <> 0 Then
                e.Row.Cells(1).Text = Convert.ToString(FormatNumber(ViewState.Item("total_volumereal"), 0))
                e.Row.Cells(2).Text = Convert.ToString(FormatNumber(Convert.ToDecimal(ViewState.Item("total_negociado")) / Convert.ToDecimal(ViewState.Item("total_volumereal")), 4))
                e.Row.Cells(3).Text = Convert.ToString(FormatNumber(Convert.ToDecimal(ViewState.Item("total_notafiscal")) / Convert.ToDecimal(ViewState.Item("total_volumereal")), 4))
                e.Row.Cells(4).Text = Convert.ToString(FormatNumber(Convert.ToDecimal(ViewState.Item("total_incentivo")) / Convert.ToDecimal(ViewState.Item("total_volumereal")), 4))
                e.Row.Cells(5).Text = Convert.ToString(FormatNumber(Convert.ToDecimal(ViewState.Item("total_frete")) / Convert.ToDecimal(ViewState.Item("total_volumereal")), 4))
                e.Row.Cells(6).Text = Convert.ToString(FormatNumber(Convert.ToDecimal(ViewState.Item("total_qualidade")) / Convert.ToDecimal(ViewState.Item("total_volumereal")), 4))
                e.Row.Cells(7).Text = Convert.ToString(FormatNumber(Convert.ToDecimal(ViewState.Item("total_geral")) / Convert.ToDecimal(ViewState.Item("total_volumereal")), 4))
            Else
                ' 21/10/2008
                e.Row.Cells(1).Text = 0
                e.Row.Cells(2).Text = 0
                e.Row.Cells(3).Text = 0
                e.Row.Cells(4).Text = 0
                e.Row.Cells(5).Text = 0
                e.Row.Cells(6).Text = 0
                e.Row.Cells(7).Text = 0
            End If

            ' Salva rodapé para calculo do Custo Total
            ViewState.Item("custo_produtor_volumereal") = e.Row.Cells(1).Text
            ViewState.Item("custo_produtor_negociado") = e.Row.Cells(2).Text
            ViewState.Item("custo_produtor_incentivo") = e.Row.Cells(4).Text
            ViewState.Item("custo_produtor_frete") = e.Row.Cells(5).Text
            ViewState.Item("custo_produtor_qualidade") = e.Row.Cells(6).Text
        End If


    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub txt_data_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_data.TextChanged
        hl_imprimir.Enabled = False

    End Sub

    Protected Sub gridCooperativa_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridCooperativa.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lvalor_total As Decimal


            ' Soma colunas Nota Fiscal + Incentivo + Frete+ Qualidade
            lvalor_total = FormatNumber(Convert.ToDecimal(e.Row.Cells(3).Text) + Convert.ToDecimal(e.Row.Cells(4).Text) + Convert.ToDecimal(e.Row.Cells(5).Text) + Convert.ToDecimal(e.Row.Cells(6).Text), 4)
            e.Row.Cells(7).Text = FormatNumber(lvalor_total, 4)

            ViewState.Item("total_volumereal_cp") = Convert.ToDecimal(ViewState.Item("total_volumereal_cp")) + Convert.ToDecimal(e.Row.Cells(1).Text)
            ViewState.Item("total_negociado_cp") = Convert.ToDecimal(ViewState.Item("total_negociado_cp")) + Convert.ToDecimal(e.Row.Cells(2).Text)
            'ViewState.Item("total_notafiscal_cp") = Convert.ToDecimal(ViewState.Item("total_notafiscal_cp")) + Convert.ToDecimal(e.Row.Cells(3).Text)
            ViewState.Item("total_incentivo_cp") = Convert.ToDecimal(ViewState.Item("total_incentivo_cp")) + Convert.ToDecimal(e.Row.Cells(4).Text)
            ViewState.Item("total_frete_cp") = Convert.ToDecimal(ViewState.Item("total_frete_cp")) + Convert.ToDecimal(e.Row.Cells(5).Text)
            ViewState.Item("total_qualidade_cp") = Convert.ToDecimal(ViewState.Item("total_qualidade_cp")) + Convert.ToDecimal(e.Row.Cells(6).Text)
            'ViewState.Item("total_geral") = Convert.ToDecimal(ViewState.Item("total_geral")) + Convert.ToDecimal(e.Row.Cells(7).Text)

            'Formata as casas decimais e pontos
            e.Row.Cells(1).Text = FormatNumber(e.Row.Cells(1).Text, 0)
            e.Row.Cells(2).Text = FormatNumber(e.Row.Cells(2).Text, 4)
            e.Row.Cells(3).Text = FormatNumber(e.Row.Cells(3).Text, 4)
            e.Row.Cells(4).Text = FormatNumber(e.Row.Cells(4).Text, 4)
            e.Row.Cells(5).Text = FormatNumber(e.Row.Cells(5).Text, 4)
            e.Row.Cells(6).Text = FormatNumber(e.Row.Cells(6).Text, 4)
            e.Row.Cells(7).Text = FormatNumber(e.Row.Cells(7).Text, 4)

        End If

        If (e.Row.RowType = DataControlRowType.Footer) Then

            Dim lvolume_real_final As Decimal
            Dim lnegociado_final As Decimal
            Dim lincentivo_final As Decimal
            Dim lfrete_final As Decimal
            Dim lqualidade_final As Decimal

            lvolume_real_final = Convert.ToDecimal(ViewState.Item("custo_produtor_volumereal")) + Convert.ToDecimal(ViewState.Item("total_volumereal_cp"))
            lnegociado_final = ((Convert.ToDecimal(ViewState.Item("custo_produtor_volumereal")) * Convert.ToDecimal(ViewState.Item("custo_produtor_negociado"))) + (Convert.ToDecimal(ViewState.Item("total_volumereal_cp")) * Convert.ToDecimal(ViewState.Item("total_negociado_cp")))) / lvolume_real_final
            lincentivo_final = ((Convert.ToDecimal(ViewState.Item("custo_produtor_volumereal")) * Convert.ToDecimal(ViewState.Item("custo_produtor_incentivo"))) + (Convert.ToDecimal(ViewState.Item("total_volumereal_cp")) * Convert.ToDecimal(ViewState.Item("total_incentivo_cp")))) / lvolume_real_final
            lfrete_final = ((Convert.ToDecimal(ViewState.Item("custo_produtor_volumereal")) * Convert.ToDecimal(ViewState.Item("custo_produtor_frete"))) + (Convert.ToDecimal(ViewState.Item("total_volumereal_cp")) * Convert.ToDecimal(ViewState.Item("total_frete_cp")))) / lvolume_real_final
            lqualidade_final = ((Convert.ToDecimal(ViewState.Item("custo_produtor_volumereal")) * Convert.ToDecimal(ViewState.Item("custo_produtor_qualidade"))) + (Convert.ToDecimal(ViewState.Item("total_volumereal_cp")) * Convert.ToDecimal(ViewState.Item("total_qualidade_cp")))) / lvolume_real_final

            e.Row.Cells(0).Text = "Custo Total"
            e.Row.Cells(1).Text = FormatNumber(lvolume_real_final, 0)
            e.Row.Cells(2).Text = Convert.ToString(FormatNumber(lnegociado_final, 4))
            e.Row.Cells(3).Text = Convert.ToString(FormatNumber(lnegociado_final, 4))
            e.Row.Cells(4).Text = Convert.ToString(FormatNumber(lincentivo_final, 4))
            e.Row.Cells(5).Text = Convert.ToString(FormatNumber(lfrete_final, 4))
            e.Row.Cells(6).Text = Convert.ToString(FormatNumber(lqualidade_final, 4))
            e.Row.Cells(7).Text = Convert.ToString(FormatNumber(Convert.ToDecimal(e.Row.Cells(3).Text) + Convert.ToDecimal(e.Row.Cells(4).Text) + Convert.ToDecimal(e.Row.Cells(5).Text) + Convert.ToDecimal(e.Row.Cells(5).Text), 4))
        End If

    End Sub
End Class
