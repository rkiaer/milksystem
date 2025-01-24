Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_central_relatorio_resultados
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        btn_exportar.Visible = True

        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_referencia") = txt_dt_referencia.Text
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        ViewState.Item("tiporelatorio") = cbo_tipo.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_relatorio_resultados.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_relatorio_resultados.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 239
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 


            loadDetails()
        End If
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
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("dt_referencia").ToString().Equals(String.Empty)) Then
                pedido.dt_inicio = Convert.ToDateTime(String.Concat("01/01/", ViewState.Item("dt_referencia"))).ToString("dd/MM/yyyy")
                pedido.dt_fim = Convert.ToDateTime(String.Concat("01/01/", (CInt(ViewState.Item("dt_referencia")) + 1).ToString)).ToString("dd/MM/yyyy")
            End If


            If ViewState.Item("tiporelatorio").Equals("2") Then
                gridAnalitico.Visible = False
                gridMatriz.Visible = False

                Dim dsresultados As DataSet = pedido.getCentralRelatorioResultados

                Dim lano As String = ViewState("dt_referencia").ToString
                pedido.dt_inicio = DateTime.Parse(String.Concat("01/01/", lano.Trim)).ToString("dd/MM/yyyy")
                pedido.dt_fim = DateTime.Parse(String.Concat("01/12/", lano.Trim)).ToString("dd/MM/yyyy")
                pedido.dt_fornec_fim = DateTime.Parse(String.Concat("31/12/", lano.Trim)).ToString("dd/MM/yyyy")

                Dim dsPedidoVisaoSintetica As DataSet = pedido.getCentralConciliacaoContabilidadeSintetico()

                If (dsresultados.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsresultados.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()

                    Dim row As GridViewRow
                    Dim ilinha As Integer = 0
                    Dim irow As Integer = 0

                    For Each row In gridResults.Rows
                        Dim lbl_total_desconto As Anthem.Label = CType(row.FindControl("lbl_total_desconto"), Anthem.Label)
                        Dim lbl_total_pagto As Anthem.Label = CType(row.FindControl("lbl_total_pagto"), Anthem.Label)
                        Dim lbl_dt_referencia As Label = CType(row.FindControl("lbl_dt_referencia"), Label)

                        irow = row.RowIndex

                        If (dsPedidoVisaoSintetica.Tables(0).Rows.Count > 0) Then
                            For ilinha = irow To dsPedidoVisaoSintetica.Tables(0).Rows.Count - 1
                                If CDate(dsPedidoVisaoSintetica.Tables(0).Rows(ilinha).Item("dt_referencia")) = CDate(lbl_dt_referencia.Text) Then

                                    If Not IsDBNull(dsPedidoVisaoSintetica.Tables(0).Rows(ilinha).Item("nr_credito")) Then
                                        lbl_total_desconto.Text = FormatNumber(dsPedidoVisaoSintetica.Tables(0).Rows(ilinha).Item("nr_credito").ToString, 2)
                                    Else
                                        lbl_total_desconto.Text = String.Empty
                                    End If

                                    If Not IsDBNull(dsPedidoVisaoSintetica.Tables(0).Rows(ilinha).Item("nr_debito")) Then
                                        lbl_total_pagto.Text = FormatNumber(dsPedidoVisaoSintetica.Tables(0).Rows(ilinha).Item("nr_debito").ToString, 2)
                                    Else
                                        lbl_total_pagto.Text = String.Empty
                                    End If

                                Else
                                    If CDate(dsPedidoVisaoSintetica.Tables(0).Rows(ilinha).Item("dt_referencia")) > CDate(lbl_dt_referencia.Text) Then
                                        Exit For
                                    End If
                                End If
                            Next
                        Else
                            Exit For
                        End If
                    Next

                Else
                    gridResults.Visible = False
                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                End If
            Else
                If ViewState.Item("tiporelatorio").Equals("1") Then
                    gridResults.Visible = False
                    gridMatriz.Visible = False

                    Dim dsresultados As DataSet = pedido.getCentralRelatorioResultadosAnalitico

                    If (dsresultados.Tables(0).Rows.Count > 0) Then
                        gridAnalitico.Visible = True
                        gridAnalitico.DataSource = Helper.getDataView(dsresultados.Tables(0), ViewState.Item("sortExpression"))
                        gridAnalitico.DataBind()
                    Else
                        gridResults.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If
                Else
                    gridResults.Visible = False
                    gridAnalitico.Visible = False

                    Dim dsresultados As DataSet = pedido.getCentralRelatorioResultadosMatriz

                    If (dsresultados.Tables(0).Rows.Count > 0) Then
                        gridMatriz.Visible = True
                        gridMatriz.DataSource = Helper.getDataView(dsresultados.Tables(0), "")
                        gridMatriz.DataBind()
                    Else
                        gridMatriz.Visible = False
                        messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                    End If
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

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

        ViewState.Item("tiporelatorio") = cbo_tipo.SelectedValue

        loadData()

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 239
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 
        If ViewState.Item("tiporelatorio").ToString.Equals("1") Then
            Response.Redirect("frm_central_relatorio_resultados_analitico_excel.aspx?&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString)
        Else
            If ViewState.Item("tiporelatorio").ToString.Equals("2") Then
                Response.Redirect("frm_central_relatorio_resultados_excel.aspx?&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString)
            Else
                Response.Redirect("frm_central_relatorio_resultados_matriz_excel.aspx?&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString)

            End If
        End If


    End Sub


    Protected Sub gridAnalitico_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridAnalitico.PageIndexChanging
        gridAnalitico.PageIndex = e.NewPageIndex
        loadData()

    End Sub

    Protected Sub gridAnalitico_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridAnalitico.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
         And e.Row.RowType <> DataControlRowType.Footer _
         And e.Row.RowType <> DataControlRowType.Pager) Then

            If (e.Row.Cells(9).Text.Trim().Equals("&nbsp;")) OrElse (e.Row.Cells(9).Text.Trim().Equals(String.Empty)) Then
                e.Row.Cells(9).Text = String.Empty
            Else
                e.Row.Cells(9).Text = Left(e.Row.Cells(1).Text, 15)
            End If
            'produtor
            e.Row.Cells(1).Text = Left(e.Row.Cells(1).Text, 25)

            'tecnico
            e.Row.Cells(3).Text = Left(e.Row.Cells(3).Text, 15)

        End If
    End Sub

    Protected Sub gridAnalitico_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridAnalitico.RowDeleting
        e.Cancel = True

    End Sub
End Class

