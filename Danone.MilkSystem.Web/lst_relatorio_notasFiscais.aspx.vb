Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_relatorio_notasFiscais
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click


        Dim data_fim As String


        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = "01/" + txt_dt_referencia.Text.Trim()
            ViewState.Item("dt_referencia") = "01/" + txt_dt_referencia.Text.Trim()
            data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))) ' Adri
            ViewState.Item("dt_fim") = data_fim
        Else
            ViewState.Item("dt_inicio") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        End If

        'chamado 1576 - 03/08/2012 - Mirella i
        If Not (txt_cd_sap.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_codigo_sap") = txt_cd_sap.Text.Trim()
        Else
            ViewState.Item("cd_codigo_sap") = String.Empty
        End If
        'chamado 1576 - 03/08/2012 - Mirella f


        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_relatorio_notasFiscais.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_relatorio_notasFiscais.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 84
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try


            ' cbo_emitente.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'ViewState.Item("sortExpression") = "Emitente asc"




        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim Nota As New NotaFiscalExel




            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                Nota.dt_referencia_ini = Convert.ToString(ViewState.Item("dt_inicio"))
                Nota.dt_referencia_fim = Convert.ToString(ViewState.Item("dt_fim"))
                Nota.dt_referencia = Convert.ToString(ViewState.Item("dt_referencia"))
            End If


            'chamado 1576 - 03/08/2012 - Mirella i
            If Not (ViewState("cd_codigo_sap").ToString().Equals(String.Empty)) Then
                Nota.cd_codigo_sap = Convert.ToString(ViewState.Item("cd_codigo_sap"))
            End If
            'chamado 1576 - 03/08/2012 - Mirella f



            If (cbo_emitente.SelectedValue = "Produtor") Then
                ViewState.Item("emitente") = 1

                Dim dsNota As DataSet = Nota.getNotaProdutorbyFilters

                If (dsNota.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    'fran 24/01/2011 gko fase 2 i
                    gridResults.Columns(11).Visible = False 'placa
                    gridResults.Columns(12).Visible = False 'variação
                    gridResults.Columns(13).Visible = False 'valor icms
                    'fran 24/01/2011 gko fase 2 f

                    gridResults.DataSource = Helper.getDataView(dsNota.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()

                Else
                    gridResults.Visible = False



                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

                End If
            ElseIf (cbo_emitente.SelectedValue = "Cooperativa") Then
                ViewState.Item("emitente") = 2
                Dim dsNota As DataSet = Nota.getNotaCooperativabyFilters

                If (dsNota.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    'fran 24/01/2011 gko fase 2 i
                    gridResults.Columns(11).Visible = True 'placa
                    gridResults.Columns(12).Visible = True 'variação
                    gridResults.Columns(13).Visible = True 'valor icms
                    'fran 24/01/2011 gko fase 2 f

                    gridResults.DataSource = Helper.getDataView(dsNota.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()

                Else
                    gridResults.Visible = False



                    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")

                End If
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
            If (cbo_emitente.SelectedValue = "Cooperativa") Then
                Dim id_romaneio As Label = CType(e.Row.FindControl("id_romaneio"), Label)
                Dim diferenca_pesagem As Label = CType(e.Row.FindControl("diferenca_pesagem"), Label)
                Dim nr_litros_reais_romaneio As Decimal
                Dim romaneio As New Romaneio

                romaneio.id_romaneio = Convert.ToInt32(id_romaneio.Text)
                Dim nr_mediadens As Decimal = romaneio.getRomaneioCompartimentoMediaDens()

                'litros reais do romaneio = (Pesagem Inicial – Pesagem Final) * Média Dens.	Romaneio
                nr_litros_reais_romaneio = CDbl(diferenca_pesagem.Text) * nr_mediadens

                ' Coluna 12 - Variação = Litros Reais Romaneio - Quantidade de litros da Nota Fiscal 
                e.Row.Cells(12).Text = FormatNumber((nr_litros_reais_romaneio - CDbl(e.Row.Cells(8).Text)), 4)
            End If
        End If

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "st_categoria"
                If (ViewState.Item("sortExpression")) = "st_categoria asc" Then
                    ViewState.Item("sortExpression") = "st_categoria desc"
                Else
                    ViewState.Item("sortExpression") = "st_categoria asc"
                End If

                'chamado 1576 - 03/08/2012 - Mirella i
            Case "cd_codigo_sap"
                If (ViewState.Item("sortExpression")) = "cd_codigo_sap asc" Then
                    ViewState.Item("sortExpression") = "cd_codigo_sap desc"
                Else
                    ViewState.Item("sortExpression") = "cd_codigo_sap asc"
                End If
                'chamado 1576 - 03/08/2012 - Mirella f

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


        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = "01/" + txt_dt_referencia.Text.Trim()
            ViewState.Item("dt_referencia") = "01/" + txt_dt_referencia.Text.Trim()
            data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))) ' Adri
            ViewState.Item("dt_fim") = data_fim
        Else
            ViewState.Item("dt_inicio") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        End If


        'chamado 1576 - 03/08/2012 - Mirella i
        If Not (txt_cd_sap.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_codigo_sap") = txt_cd_sap.Text.Trim()
        Else
            ViewState.Item("cd_codigo_sap") = String.Empty
        End If
        'chamado 1576 - 03/08/2012 - Mirella f


        loadData()
        'se o grid tiver mais que 65536  linhas não podemos exportar

        If gridResults.Rows.Count.ToString + 1 < 65536 Then
            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 84
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            Response.Redirect("frm_relatorio_notasFiscais.aspx?emitente=" + ViewState.Item("emitente").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia") + "&cd_codigo_sap=" + ViewState.Item("cd_codigo_sap").ToString) 'chamado 1576 - 03/08/2012 - Mirella
        Else
            messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")  ' Adri
        End If
    End Sub

End Class

