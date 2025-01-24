Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_RelacaoCIQ_CIQPEmitidos
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_RelacaoCIQ_CIQPEmitidos.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 110
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try

            Dim estabel As New Estabelecimento
            estabel.id_situacao = 1
            Dim dsestabel As DataSet = estabel.getEstabelecimentoByFilters
            cbo_estabelecimento.DataSource = Helper.getDataView(dsestabel.Tables(0), "nm_estabelecimento")
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(2, New ListItem("Boa Esperança", "77"))
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click

        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = txt_dt_inicio.Text.Trim()
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If
        If Not (txt_dt_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = txt_dt_fim.Text.Trim()
        Else
            ViewState.Item("dt_fim") = String.Empty
        End If
        If Not (cbo_estabelecimento.SelectedValue = 0) Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        loadData()
        'se o grid tiver mais que 65536  linhas não podemos exportar
        If gridResults.Rows.Count = 0 Then
            messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
        Else
            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 8 'exporta~ção
                usuariolog.id_menu_item = 110
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Response.Redirect("frm_relacao_CIQ_CIQPEmitidos_excel.aspx?emitente=" + ViewState.Item("emitente").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento"))
            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")  ' Adri
            End If
        End If

    End Sub
    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Not (txt_dt_inicio.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = txt_dt_inicio.Text.Trim()
        Else
            ViewState.Item("dt_inicio") = String.Empty
        End If
        ViewState.Item("dt_fim") = Me.txt_dt_fim.Text.Trim

        If (txt_dt_fim.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_fim") = ViewState.Item("dt_inicio")
        End If


        If Not (cbo_estabelecimento.SelectedValue = 0) Then
            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If
        loadData()

    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio

            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                romaneio.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                romaneio.data_inicio = ViewState.Item("dt_inicio").ToString
            End If
            If Not (ViewState("dt_fim").ToString().Equals(String.Empty)) Then
                romaneio.data_fim = ViewState.Item("dt_fim").ToString
            End If

            If (cbo_emitente.SelectedValue = "Produtor") Then
                ViewState.Item("emitente") = 1

                Dim dsromaneio As DataSet = romaneio.getRelacaoCIQPEmitidos

                If (dsromaneio.Tables(0).Rows.Count > 0) Then
                    gridResults.Columns(4).Visible = False
                    gridResults.Columns(2).Visible = True
                    gridResults.Columns(6).Visible = True
                    gridResults.Columns(7).Visible = True
                    gridResults.Columns(8).Visible = True
                    gridResults.Columns(9).HeaderText = "Cód. Produtor"
                    gridResults.Columns(10).HeaderText = "Nome Produtor"
                    gridResults.Columns(11).Visible = True
                    gridResults.Columns(12).Visible = True
                    gridResults.Columns(13).Visible = True
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsromaneio.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()

                Else
                    gridResults.Visible = False

                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

                End If
            ElseIf (cbo_emitente.SelectedValue = "Cooperativa") Then
                ViewState.Item("emitente") = 2
                Dim dsromaneio As DataSet = romaneio.getRelacaoCIQEmitidos

                If (dsromaneio.Tables(0).Rows.Count > 0) Then
                    gridResults.Columns(2).Visible = False
                    gridResults.Columns(4).Visible = True
                    gridResults.Columns(6).Visible = False
                    gridResults.Columns(7).Visible = True
                    gridResults.Columns(8).Visible = False
                    gridResults.Columns(9).HeaderText = "Cód. Cooperativa"
                    gridResults.Columns(10).HeaderText = "Nome Cooperativa"
                    gridResults.Columns(11).Visible = False
                    gridResults.Columns(12).Visible = False
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dsromaneio.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()

                Else
                    gridResults.Visible = False

                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

                End If
            End If
            Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_CIQ_CIQPEmitidos.aspx?dt_inicio={0}", Me.txt_dt_inicio.Text) & String.Format("&dt_fim={0}", Me.txt_dt_fim.Text) & String.Format("&id_estabelecimento={0}", Me.cbo_estabelecimento.SelectedValue) & String.Format("&emitente={0}", Me.ViewState.Item("emitente").ToString)
            Me.hl_imprimir.Enabled = True

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_RelacaoCIQ_CIQPEmitidos.aspx?st_incluirlog=N")

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
     And e.Row.RowType <> DataControlRowType.Footer _
     And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim lbl_nr_total_litros As Label = CType(e.Row.FindControl("lbl_nr_total_litros"), Label)
            Dim lbl_nr_litros As Label = CType(e.Row.FindControl("lbl_nr_litros"), Label)

            'If e.Row.Cells(7).Text.Equals(String.Empty) Then
            '    e.Row.Cells(7).Text = "0"
            'Else
            '    e.Row.Cells(7).Text = FormatNumber(e.Row.Cells(7).Text, 0).ToString
            'End If

            'If Me.ViewState.Item("emitente").ToString = "1" Then
            '    If e.Row.Cells(8).Text.Equals(String.Empty) Then
            '        e.Row.Cells(8).Text = "0"
            '    Else
            '        e.Row.Cells(8).Text = FormatNumber(e.Row.Cells(8).Text, 0).ToString
            '    End If
            'End If
            If lbl_nr_total_litros.Text.Equals(String.Empty) Then
                lbl_nr_total_litros.Text = "0"
            Else
                lbl_nr_total_litros.Text = FormatNumber(lbl_nr_total_litros.Text, 0).ToString
            End If

            If Me.ViewState.Item("emitente").ToString = "1" Then
                If lbl_nr_litros.Text.Equals(String.Empty) Then
                    lbl_nr_litros.Text = String.Empty
                Else
                    lbl_nr_litros.Text = FormatNumber(lbl_nr_litros.Text, 0).ToString
                End If
            End If
        End If
    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "id_romaneio"
                If (ViewState.Item("sortExpression")) = "id_romaneio asc" Then
                    ViewState.Item("sortExpression") = "id_romaneio desc"
                Else
                    ViewState.Item("sortExpression") = "id_romaneio asc"
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

End Class

