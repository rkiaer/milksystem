Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_relatorio_entrada_cooperativa
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click


        Dim data_fim As String

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = "01/" + txt_dt_referencia.Text.Trim()
            ViewState.Item("dt_referencia") = "01/" + txt_dt_referencia.Text.Trim()
            data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))) ' Adri
            ViewState.Item("dt_fim") = data_fim
        Else
            ViewState.Item("dt_inicio") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        End If



        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_relatorio_entrada_cooperativa.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_entrada_cooperativa.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 114
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try


            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
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
            Dim Nota As New NotaFiscal

            Nota.id_estabelecimento = cbo_estabelecimento.SelectedValue

            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                Nota.dt_inicio = Convert.ToString(ViewState.Item("dt_inicio"))
                Nota.dt_fim = Convert.ToString(ViewState.Item("dt_fim"))
                Nota.dt_referencia = Convert.ToString(ViewState.Item("dt_referencia"))
                Nota.dt_fim_1quinz = String.Concat("15/", Right(ViewState.Item("dt_inicio"), 7))
                Nota.dt_ini_2quinz = String.Concat("16/", Right(ViewState.Item("dt_inicio"), 7))

            End If

            Dim dsNota As DataSet = Nota.getRelatorioEntradaCooperativa

            If (dsNota.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                ViewState.Item("diferenca") = "0"
                gridResults.DataSource = Helper.getDataView(dsNota.Tables(0), "")
                gridResults.DataBind()

                Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_entrada_cooperativa.aspx?dt_inicio={0}", ViewState.Item("dt_inicio").ToString) & String.Format("&dt_fim={0}", ViewState.Item("dt_fim").ToString) & String.Format("&id_estabelecimento={0}", ViewState.Item("id_estabelecimento").ToString)
                Me.hl_imprimir.Enabled = True


            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
                Me.hl_imprimir.Enabled = False
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        'fran 24/01/2011 gko fase 2 i

        If (e.Row.RowType <> DataControlRowType.Header _
   And e.Row.RowType <> DataControlRowType.Footer _
   And e.Row.RowType <> DataControlRowType.Pager) Then
            Dim nr_diferenca As Decimal

            If e.Row.Cells(3).Text = "Total 1.a Quinzena" Then
                ' Coluna 12 - diferença
                nr_diferenca = CDbl(ViewState.Item("diferenca")) + CDbl(e.Row.Cells(12).Text)
                ViewState.Item("diferenca") = nr_diferenca.ToString
            End If
            If e.Row.Cells(3).Text = "Total 2.a Quinzena" Then
                ' Coluna 12 - diferença
                nr_diferenca = CDbl(ViewState.Item("diferenca")) + CDbl(e.Row.Cells(12).Text)
                ViewState.Item("diferenca") = nr_diferenca.ToString
            End If
            If e.Row.Cells(3).Text = "Cálculo Final" Or e.Row.Cells(3).Text = "C&#225;lculo Final" Then
                e.Row.Cells(12).Text = ViewState.Item("diferenca").ToString
                ViewState.Item("diferenca") = "0"
            End If
        End If

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "fornecedor"
                If (ViewState.Item("sortExpression")) = "fornecedor asc" Then
                    ViewState.Item("sortExpression") = "fornecedor desc"
                Else
                    ViewState.Item("sortExpression") = "fornecedor asc"
                End If
            Case "nome"
                If (ViewState.Item("sortExpression")) = "nome asc" Then
                    ViewState.Item("sortExpression") = "nome desc"
                Else
                    ViewState.Item("sortExpression") = "nome asc"
                End If
            Case "dt_entrada"
                If (ViewState.Item("sortExpression")) = "dt_entrada asc" Then
                    ViewState.Item("sortExpression") = "dt_entrada desc"
                Else
                    ViewState.Item("sortExpression") = "dt_entrada asc"
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



    Protected Sub gridResults_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridResults.SelectedIndexChanged

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        Dim data_fim As String

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = "01/" + txt_dt_referencia.Text.Trim()
            ViewState.Item("dt_referencia") = "01/" + txt_dt_referencia.Text.Trim()
            data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))) ' Adri
            ViewState.Item("dt_fim") = data_fim
        Else
            ViewState.Item("dt_inicio") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        End If

        loadData()
        'se o grid tiver mais que 65536  linhas não podemos exportar
        If gridResults.Visible = True Then
            If gridResults.Rows.Count.ToString + 1 < 65536 Then
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 8 'exporta~ção
                usuariolog.id_menu_item = 114
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                Response.Redirect("frm_relatorio_entrada_cooperativa_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia"))
            Else
                messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
            End If
        End If
    End Sub

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        Me.hl_imprimir.Enabled = False

    End Sub

    Protected Sub txt_dt_referencia_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_dt_referencia.TextChanged
        Me.hl_imprimir.Enabled = False

    End Sub
End Class

