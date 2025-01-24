Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_custo_financeiro_parametros

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then

            ViewState.Item("nr_ano") = txt_ano_referencia.Text
            ViewState.Item("id_tipo_custo_financeiro") = cbo_tipo_custo_financeiro.SelectedValue

            loadData()
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_custo_financeiro_parametros.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_custo_financeiro_parametros.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 223
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim tipocustofinanceiro As New CustoFinanceiro

            tipocustofinanceiro.id_situacao = 1
            cbo_tipo_custo_financeiro.DataSource = tipocustofinanceiro.getTipoCustoFinanceiro()
            cbo_tipo_custo_financeiro.DataTextField = "nm_tipo_custo_financeiro"
            cbo_tipo_custo_financeiro.DataValueField = "id_tipo_custo_financeiro"
            cbo_tipo_custo_financeiro.DataBind()
            cbo_tipo_custo_financeiro.Items.Insert(0, New ListItem("[Selecione]", 0))


            txt_ano_referencia.Text = DateTime.Parse(Now).ToString("yyyy")

            ViewState.Item("sortExpression") = ""

            loadfilters()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("lst_cf_parametros", txt_ano_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nr_ano") = customPage.getFilterValue("lst_cf_parametros", txt_ano_referencia.ID)
            txt_ano_referencia.Text = ViewState.Item("nr_ano").ToString()
        Else
            ViewState.Item("nr_ano") = String.Empty
        End If


        If Not (customPage.getFilterValue("lst_cf_parametros", cbo_tipo_custo_financeiro.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_tipo_custo_financeiro") = customPage.getFilterValue("lst_cf_parametros", cbo_tipo_custo_financeiro.ID)
            cbo_tipo_custo_financeiro.SelectedValue = ViewState.Item("id_tipo_custo_financeiro").ToString()
        Else
            ViewState.Item("id_tipo_custo_financeiro") = "0"
        End If


        If Not (customPage.getFilterValue("lst_cf_parametros", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("lst_cf_parametros", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("lst_cf_parametros")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim custo As New CustoFinanceiro

            custo.nr_ano = ViewState.Item("nr_ano")
            custo.id_tipo_custo_financeiro = ViewState.Item("id_tipo_custo_financeiro")

            Dim dscusto As DataSet = custo.getCustoFinanceiroByFilters()

            If (dscusto.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscusto.Tables(0), "")
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try

            customPage.setFilter("lst_cf_parametros", txt_ano_referencia.ID, ViewState.Item("nr_ano").ToString)
            customPage.setFilter("lst_cf_parametros", cbo_tipo_custo_financeiro.ID, ViewState.Item("id_tipo_custo_financeiro").ToString)
            customPage.setFilter("lst_cf_parametros", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()

                Response.Redirect("frm_custo_financeiro_parametros.aspx?nr_ano=" + e.CommandArgument.ToString)


        End Select

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(2).Text = String.Concat("JAN/", ViewState.Item("nr_ano").ToString)
            e.Row.Cells(3).Text = String.Concat("FEV/", ViewState.Item("nr_ano").ToString)
            e.Row.Cells(4).Text = String.Concat("MAR/", ViewState.Item("nr_ano").ToString)
            e.Row.Cells(5).Text = String.Concat("ABR/", ViewState.Item("nr_ano").ToString)
            e.Row.Cells(6).Text = String.Concat("MAI/", ViewState.Item("nr_ano").ToString)
            e.Row.Cells(7).Text = String.Concat("JUN/", ViewState.Item("nr_ano").ToString)
            e.Row.Cells(8).Text = String.Concat("JUL/", ViewState.Item("nr_ano").ToString)
            e.Row.Cells(9).Text = String.Concat("AGO/", ViewState.Item("nr_ano").ToString)
            e.Row.Cells(10).Text = String.Concat("SET/", ViewState.Item("nr_ano").ToString)
            e.Row.Cells(11).Text = String.Concat("OUT/", ViewState.Item("nr_ano").ToString)
            e.Row.Cells(12).Text = String.Concat("NOV/", ViewState.Item("nr_ano").ToString)
            e.Row.Cells(13).Text = String.Concat("DEZ/", ViewState.Item("nr_ano").ToString)
        End If

        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim mes1 As DataControlFieldCell = CType(e.Row.Cells.Item(2), DataControlFieldCell)
            Dim mes2 As DataControlFieldCell = CType(e.Row.Cells.Item(3), DataControlFieldCell)
            Dim mes3 As DataControlFieldCell = CType(e.Row.Cells.Item(4), DataControlFieldCell)
            Dim mes4 As DataControlFieldCell = CType(e.Row.Cells.Item(5), DataControlFieldCell)
            Dim mes5 As DataControlFieldCell = CType(e.Row.Cells.Item(6), DataControlFieldCell)
            Dim mes6 As DataControlFieldCell = CType(e.Row.Cells.Item(7), DataControlFieldCell)
            Dim mes7 As DataControlFieldCell = CType(e.Row.Cells.Item(8), DataControlFieldCell)
            Dim mes8 As DataControlFieldCell = CType(e.Row.Cells.Item(9), DataControlFieldCell)
            Dim mes9 As DataControlFieldCell = CType(e.Row.Cells.Item(10), DataControlFieldCell)
            Dim mes10 As DataControlFieldCell = CType(e.Row.Cells.Item(11), DataControlFieldCell)
            Dim mes11 As DataControlFieldCell = CType(e.Row.Cells.Item(12), DataControlFieldCell)
            Dim mes12 As DataControlFieldCell = CType(e.Row.Cells.Item(13), DataControlFieldCell)
            Dim lbl_id_conta As Label = CType(e.Row.FindControl("lbl_id_conta"), Label)

            Dim lbl_id_tipo_custo_financeiro As Label = CType(e.Row.FindControl("lbl_id_tipo_custo_financeiro"), Label)

            Select Case CInt(lbl_id_tipo_custo_financeiro.Text)

                Case 4, 19 ' necessidade de leite e volume de coop e
                    If (Not mes1.Text.Equals(String.Empty) And Not mes1.Text = "&nbsp;") Then
                        mes1.Text = FormatNumber(mes1.Text, 0).ToString()
                    End If
                    If (Not mes2.Text.Equals(String.Empty) And Not mes2.Text = "&nbsp;") Then
                        mes2.Text = FormatNumber(mes2.Text, 0).ToString()
                    End If
                    If (Not mes3.Text.Equals(String.Empty) And Not mes3.Text = "&nbsp;") Then
                        mes3.Text = FormatNumber(mes3.Text, 0).ToString()
                    End If
                    If (Not mes4.Text.Equals(String.Empty) And Not mes4.Text = "&nbsp;") Then
                        mes4.Text = FormatNumber(mes4.Text, 0).ToString()
                    End If
                    If (Not mes5.Text.Equals(String.Empty) And Not mes5.Text = "&nbsp;") Then
                        mes5.Text = FormatNumber(mes5.Text, 0).ToString()
                    End If
                    If (Not mes6.Text.Equals(String.Empty) And Not mes6.Text = "&nbsp;") Then
                        mes6.Text = FormatNumber(mes6.Text, 0).ToString()
                    End If
                    If (Not mes7.Text.Equals(String.Empty) And Not mes7.Text = "&nbsp;") Then
                        mes7.Text = FormatNumber(mes7.Text, 0).ToString()
                    End If
                    If (Not mes8.Text.Equals(String.Empty) And Not mes8.Text = "&nbsp;") Then
                        mes8.Text = FormatNumber(mes8.Text, 0).ToString()
                    End If
                    If (Not mes9.Text.Equals(String.Empty) And Not mes9.Text = "&nbsp;") Then
                        mes9.Text = FormatNumber(mes9.Text, 0).ToString()
                    End If
                    If (Not mes10.Text.Equals(String.Empty) And Not mes10.Text = "&nbsp;") Then
                        mes10.Text = FormatNumber(mes10.Text, 0).ToString()
                    End If
                    If (Not mes11.Text.Equals(String.Empty) And Not mes11.Text = "&nbsp;") Then
                        mes11.Text = FormatNumber(mes11.Text, 0).ToString()
                    End If
                    If (Not mes12.Text.Equals(String.Empty) And Not mes12.Text = "&nbsp;") Then
                        mes12.Text = FormatNumber(mes12.Text, 0).ToString()
                    End If


            End Select

            If e.Row.Cells(0).Text = "N" OrElse CInt(lbl_id_tipo_custo_financeiro.Text) = 20 Then
                If (Not mes1.Text.Equals(String.Empty) And Not mes1.Text = "&nbsp;") Then
                    mes1.Text = FormatNumber(mes1.Text, 2).ToString()
                End If
                If (Not mes2.Text.Equals(String.Empty) And Not mes2.Text = "&nbsp;") Then
                    mes2.Text = FormatNumber(mes2.Text, 2).ToString()
                End If
                If (Not mes3.Text.Equals(String.Empty) And Not mes3.Text = "&nbsp;") Then
                    mes3.Text = FormatNumber(mes3.Text, 2).ToString()
                End If
                If (Not mes4.Text.Equals(String.Empty) And Not mes4.Text = "&nbsp;") Then
                    mes4.Text = FormatNumber(mes4.Text, 2).ToString()
                End If
                If (Not mes5.Text.Equals(String.Empty) And Not mes5.Text = "&nbsp;") Then
                    mes5.Text = FormatNumber(mes5.Text, 2).ToString()
                End If
                If (Not mes6.Text.Equals(String.Empty) And Not mes6.Text = "&nbsp;") Then
                    mes6.Text = FormatNumber(mes6.Text, 2).ToString()
                End If
                If (Not mes7.Text.Equals(String.Empty) And Not mes7.Text = "&nbsp;") Then
                    mes7.Text = FormatNumber(mes7.Text, 2).ToString()
                End If
                If (Not mes8.Text.Equals(String.Empty) And Not mes8.Text = "&nbsp;") Then
                    mes8.Text = FormatNumber(mes8.Text, 2).ToString()
                End If
                If (Not mes9.Text.Equals(String.Empty) And Not mes9.Text = "&nbsp;") Then
                    mes9.Text = FormatNumber(mes9.Text, 2).ToString()
                End If
                If (Not mes10.Text.Equals(String.Empty) And Not mes10.Text = "&nbsp;") Then
                    mes10.Text = FormatNumber(mes10.Text, 2).ToString()
                End If
                If (Not mes11.Text.Equals(String.Empty) And Not mes11.Text = "&nbsp;") Then
                    mes11.Text = FormatNumber(mes11.Text, 2).ToString()
                End If
                If (Not mes12.Text.Equals(String.Empty) And Not mes12.Text = "&nbsp;") Then
                    mes12.Text = FormatNumber(mes12.Text, 2).ToString()
                End If
            End If
        End If


    End Sub



    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Page.IsValid Then
            ViewState.Item("id_tipo_custo_financeiro") = cbo_tipo_custo_financeiro.SelectedValue
            ViewState.Item("nr_ano") = txt_ano_referencia.Text

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 223
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 
            loadData()
            Response.Redirect("frm_custo_financeiro_parametros_excel.aspx?nr_ano=" + ViewState.Item("nr_ano").ToString())
        End If
    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()

        Response.Redirect("frm_custo_financeiro_parametros.aspx")

    End Sub
End Class
