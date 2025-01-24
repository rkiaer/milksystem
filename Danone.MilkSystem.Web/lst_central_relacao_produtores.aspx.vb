Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Math


Partial Class lst_central_relacao_produtores
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If gridResults.Visible = True Then
            gridResults.Visible = False
        End If
        If Page.IsValid Then

            btn_exportar.Visible = True
            Dim data_fim As String

            ViewState.Item("cbo_referencia") = cbo_referencia.SelectedValue.ToString

            If ViewState.Item("cbo_referencia").ToString.Equals("1") Then 'mes/referencia
                If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
                    ViewState.Item("dt_inicio") = "01/" + txt_dt_referencia.Text.Trim()
                    data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))) ' Adri
                    ViewState.Item("dt_fim") = data_fim
                Else
                    ViewState.Item("dt_inicio") = String.Empty
                    ViewState.Item("dt_fim") = String.Empty
                End If
            Else 'periodo referencia
                If Not (txt_data_inicio.Text.Trim().Equals(String.Empty) AndAlso txt_data_fim.Text.Trim().Equals(String.Empty)) Then
                    ViewState.Item("dt_inicio") = "01/" + txt_data_inicio.Text.Trim()
                    ViewState.Item("dt_fim") = "01/" + txt_data_fim.Text.Trim
                Else
                    ViewState.Item("dt_inicio") = String.Empty
                    ViewState.Item("dt_fim") = String.Empty
                End If
            End If

            If Not (txt_cd_produtor.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("cd_pessoa") = txt_cd_produtor.Text.Trim()
            Else
                ViewState.Item("cd_pessoa") = String.Empty
            End If

            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("id_pessoa") = hf_id_produtor.Value 'fran 10/05/2010 chamado 831
            ViewState.Item("cbo_tipo") = cbo_tipo.SelectedValue.ToString


            loadData()
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_relacao_produtores.aspx?st_incluirlog=N")

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
                usuariolog.id_menu_item = 104
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtor"
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
            Dim dspedido As DataSet
            ' ''fran 10/05/2010 i chamado 831
            ' ''If Not (ViewState("nm_tecnico").ToString().Equals(String.Empty)) Then
            ''If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
            ''    'fran 10/05/2010 chamado 831
            ''    pedido.id_tecnico = Convert.ToString(ViewState.Item("id_tecnico"))
            ''End If
            ' ''fran 10/05/2010 i chamado 831
            ' ''If Not (ViewState("cd_fornecedor").ToString().Equals(String.Empty)) Then
            ''If Not (ViewState("id_fornecedor").ToString().Equals(String.Empty)) Then
            ''    'fran 10/05/2010 chamado 831
            ''    pedido.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor"))
            ''End If
            ' ''fran 10/05/2010 i chamado 831
            ''pedido.cd_produtor = ViewState("cd_pessoa").ToString
            ''pedido.cd_fornecedor = ViewState("cd_fornecedor").ToString
            ' ''fran 10/05/2010 f chamado 831

            If Not (ViewState("id_pessoa").ToString().Equals(String.Empty)) Then
                pedido.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                pedido.dt_inicio = ViewState.Item("dt_inicio")
                pedido.dt_fim = ViewState.Item("dt_fim")
            End If
            If ViewState.Item("cbo_tipo").ToString.Equals("1") Then 'se tipo do relatorio é ANALITICO
                dspedido = pedido.getSpendProdutoresAnalitico
            Else
                If ViewState.Item("cbo_tipo").ToString.Equals("2") Then
                    dspedido = pedido.getSpendProdutores
                Else
                    dspedido = pedido.getSpendProdutoresbyEstabelecimento
                End If
            End If

            If (dspedido.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                If ViewState.Item("cbo_tipo").ToString.Equals("1") Then 'se é tipo analitico
                    gridResults.Columns.Item(3).Visible = True 'propriedade
                    gridResults.Columns.Item(1).Visible = True 'produtor    
                    gridResults.Columns.Item(2).Visible = True 'nome         
                    gridResults.Columns.Item(4).Visible = True 'cluster        
                    gridResults.Columns.Item(5).Visible = True 'tecnico          

                Else
                    If ViewState.Item("cbo_tipo").ToString.Equals("2") Then
                        gridResults.Columns.Item(3).Visible = False 'propriedade
                        gridResults.Columns.Item(1).Visible = True 'produtor    
                        gridResults.Columns.Item(2).Visible = True 'nome         
                        gridResults.Columns.Item(4).Visible = True 'cluster        
                        gridResults.Columns.Item(5).Visible = True 'tecnico          

                    Else
                        gridResults.Columns.Item(1).Visible = False 'produtor    
                        gridResults.Columns.Item(2).Visible = False 'nome         
                        gridResults.Columns.Item(3).Visible = False 'propriedade
                        gridResults.Columns.Item(4).Visible = False 'cluster        
                        gridResults.Columns.Item(5).Visible = False 'tecnico          

                    End If
                End If
                gridResults.DataSource = Helper.getDataView(dspedido.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_central_relacao_produtores.aspx?dt_inicio={0}", ViewState.Item("dt_inicio").ToString) & String.Format("&dt_fim={0}", ViewState.Item("dt_fim").ToString) & String.Format("&id_estabelecimento={0}", ViewState.Item("id_estabelecimento").ToString) & String.Format("&id_pessoa={0}", ViewState.Item("id_pessoa").ToString) & String.Format("&cbo_tipo={0}", ViewState.Item("cbo_tipo").ToString)

            Me.hl_imprimir.Enabled = True

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        If (e.Row.RowType <> DataControlRowType.Header _
         And e.Row.RowType <> DataControlRowType.Footer _
         And e.Row.RowType <> DataControlRowType.Pager) Then


            Dim lbl_id_estabelecimento As Label = CType(e.Row.FindControl("lbl_id_estabelecimento"), Label)

            'Campo estabelecimento
            Select Case CInt(lbl_id_estabelecimento.Text)
                Case 1
                    e.Row.Cells(0).Text = "Poços de Caldas"
                Case 2
                    e.Row.Cells(0).Text = "Guaratinguetá"
                Case 6
                    e.Row.Cells(0).Text = "Águas da Prata"
                Case 9
                    e.Row.Cells(0).Text = "Maracanaú"
                Case Else
                    e.Row.Cells(0).Text = lbl_id_estabelecimento.Text
            End Select

            'referencia
            e.Row.Cells(6).Text = DateTime.Parse(e.Row.Cells(6).Text).ToString("MM/yyyy")

            'Valor Total da Nota
            'e.Row.Cells(7).Text = Round(CDec(e.Row.Cells(7).Text), 2).ToString

            'Total Volume
            'e.Row.Cells(8).Text = FormatNumber(e.Row.Cells(8).Text, 0)

            ''Valor Total Compra Central
            'e.Row.Cells(9).Text = Round(CDec(e.Row.Cells(9).Text), 2).ToString

            ''Valor Spend
            'e.Row.Cells(10).Text = Round(CDec(e.Row.Cells(10).Text), 4).ToString

            'If CDec(e.Row.Cells(5).Text) = 0 Then
            '    e.Row.Cells(7).Text = "00.00%"
            'Else
            '    e.Row.Cells(7).Text = FormatPercent((CDec(e.Row.Cells(6).Text) / CDec(e.Row.Cells(5).Text)), 2)

            'End If
        End If

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()

            Case "cd_pessoa"
                If (ViewState.Item("sortExpression")) = "cd_pessoa asc" Then
                    ViewState.Item("sortExpression") = "cd_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "cd_pessoa asc"
                End If
            Case "nm_pessoa"
                If (ViewState.Item("sortExpression")) = "nm_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_pessoa asc"
                End If
            Case "nm_abreviado"
                If (ViewState.Item("sortExpression")) = "nm_abreviado asc" Then
                    ViewState.Item("sortExpression") = "nm_abreviado desc"
                Else
                    ViewState.Item("sortExpression") = "nm_abreviado asc"
                End If
            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If
            Case "dt_referencia"
                If (ViewState.Item("sortExpression")) = "dt_referencia asc" Then
                    ViewState.Item("sortExpression") = "dt_referencia desc"
                Else
                    ViewState.Item("sortExpression") = "dt_referencia asc"
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
        If gridResults.Visible = True Then
            gridResults.Visible = False
        End If

        If Page.IsValid Then


            Dim data_fim As String

            ViewState.Item("cbo_referencia") = cbo_referencia.SelectedValue.ToString

            If ViewState.Item("cbo_referencia").ToString.Equals("1") Then 'mes/referencia
                If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
                    ViewState.Item("dt_inicio") = "01/" + txt_dt_referencia.Text.Trim()
                    data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))) ' Adri
                    ViewState.Item("dt_fim") = data_fim
                Else
                    ViewState.Item("dt_inicio") = String.Empty
                    ViewState.Item("dt_fim") = String.Empty
                End If
            Else 'periodo referencia
                If Not (txt_data_inicio.Text.Trim().Equals(String.Empty) AndAlso txt_data_fim.Text.Trim().Equals(String.Empty)) Then
                    ViewState.Item("dt_inicio") = "01/" + txt_data_inicio.Text.Trim()
                    ViewState.Item("dt_fim") = "01/" + txt_data_fim.Text.Trim
                Else
                    ViewState.Item("dt_inicio") = String.Empty
                    ViewState.Item("dt_fim") = String.Empty
                End If
            End If

            If Not (txt_cd_produtor.Text.Trim().Equals(String.Empty)) Then
                ViewState.Item("cd_pessoa") = txt_cd_produtor.Text.Trim()
            Else
                ViewState.Item("cd_pessoa") = String.Empty
            End If

            ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
            ViewState.Item("id_pessoa") = hf_id_produtor.Value 'fran 10/05/2010 chamado 831
            ViewState.Item("cbo_tipo") = cbo_tipo.SelectedValue.ToString


            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 8 'exporta~ção
            usuariolog.id_menu_item = 104
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            loadData()

            Response.Redirect("frm_central_relacao_produtores_excel.aspx?id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_pessoa=" + ViewState.Item("id_pessoa").ToString + "&dt_inicio=" + ViewState.Item("dt_inicio").ToString + "&dt_fim=" + ViewState.Item("dt_fim").ToString + "&cbo_tipo=" + ViewState.Item("cbo_tipo").ToString)

        End If
    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        carregarCamposprodutor()
    End Sub
    Private Sub carregarCamposprodutor()
        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                lbl_nm_produtor.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                txt_cd_produtor.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If
            Me.ViewState.Item("id_pessoa") = hf_id_produtor.Value
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub txt_cd_produtor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_produtor.TextChanged

        ' Fran 05/05/2010 - i
        lbl_nm_produtor.Text = String.Empty
        hf_id_produtor.Value = String.Empty
        Try
            If Not txt_cd_produtor.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.id_grupo = 1  ' Somente produtores
                produtor.cd_pessoa = Me.txt_cd_produtor.Text.Trim
                produtor.id_situacao = 1
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_produtor.Enabled = True
                    lbl_nm_produtor.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_produtor.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' Fran 05/05/2010 - f

    End Sub

    Protected Sub cbo_referencia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_referencia.SelectedIndexChanged

        txt_dt_referencia.Text = String.Empty
        txt_data_inicio.Text = String.Empty
        txt_data_fim.Text = String.Empty

        If cbo_referencia.SelectedValue.Equals("1") Then
            txt_dt_referencia.Visible = True
            rf_referencia.enabled = True
            txt_data_inicio.Visible = False
            txt_data_fim.Visible = False
            rf_dt_fim.enabled = False
            rf_dt_ini.enabled = False
            cv_dtini_fim.enabled = False
        End If
        If cbo_referencia.SelectedValue.Equals("2") Then
            txt_dt_referencia.Visible = False
            rf_referencia.enabled = False
            txt_data_inicio.Visible = True
            txt_data_fim.Visible = True
            rf_dt_ini.enabled = True
            rf_dt_fim.enabled = True
            cv_dtini_fim.enabled = True

        End If
    End Sub

    Protected Sub cv_dtini_fim_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_dtini_fim.ServerValidate
        Try
            Dim lmsg As String

            args.IsValid = True
            If (CDate("01/" & Me.txt_data_inicio.Text) > CDate("01/" & txt_data_fim.Text)) Then
                args.IsValid = False
                lmsg = "A Data Inicial do Período não pode ser maior que a Data Fim."
            End If
 
            If Not args.IsValid Then
                messageControl.Alert(lmsg)
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
End Class

