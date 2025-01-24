Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math

Partial Class frm_relatorio_resumo_calculo
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_resumo_calculo.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 10 'impressão
            usuariolog.id_menu_item = 49
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            If Not (Request("data") Is Nothing) Then
                ViewState.Item("data") = Request("data")
                loadData()
            Else
                messagecontrol.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
            End If


        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio


            Me.lbl_data_ini.Text = DateTime.Parse(ViewState.Item("data").ToString).ToString("MM/yyyy")


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
            End If

            ViewState.Item("total_volumereal_cp") = 0
            ViewState.Item("total_negociado_cp") = 0
            ViewState.Item("total_incentivo_cp") = 0
            ViewState.Item("total_frete_cp") = 0
            ViewState.Item("total_qualidade_cp") = 0

            Dim dsResumoCalculoCooperativa As DataSet = fichafinanceira.getCalculoResumoCooperativa()

            If (dsResumoCalculo.Tables(0).Rows.Count > 0) Then
                gridCooperativa.Visible = True
                gridCooperativa.DataSource = Helper.getDataView(dsResumoCalculoCooperativa.Tables(0), ViewState.Item("sortExpression"))
                gridCooperativa.DataBind()
            End If

        Catch ex As Exception
            messagecontrol.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResults_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.DataBound

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
            ViewState.Item("total_incentivo_cp") = Convert.ToDecimal(ViewState.Item("total_incentivo_cp")) + Convert.ToDecimal(e.Row.Cells(4).Text)
            ViewState.Item("total_frete_cp") = Convert.ToDecimal(ViewState.Item("total_frete_cp")) + Convert.ToDecimal(e.Row.Cells(5).Text)
            ViewState.Item("total_qualidade_cp") = Convert.ToDecimal(ViewState.Item("total_qualidade_cp")) + Convert.ToDecimal(e.Row.Cells(6).Text)

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
