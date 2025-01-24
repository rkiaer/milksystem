Imports Danone.MilkSystem.Business
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.IO

Partial Class lst_central_pagto_fornecedor_conciliacao
    Inherits Page

    Private customPage As RK.PageTools.CustomPage
  
    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        btn_exportar.Visible = True
        Dim data_fim As String
        If Not (txt_cd_tecnico.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("nm_tecnico") = lbl_nm_tecnico.Text.Trim()
            ViewState.Item("id_tecnico") = txt_cd_tecnico.Text.Trim() 'fran 10/05/2010 i chamado 830
        Else
            ViewState.Item("nm_tecnico") = String.Empty
            ViewState.Item("id_tecnico") = String.Empty 'fran 10/05/2010 i chamado 830
        End If

        If Not (txt_dt_referencia.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("dt_inicio") = "01/" + txt_dt_referencia.Text.Trim()
            data_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(ViewState.Item("dt_inicio")))) ' Adri
            ViewState.Item("dt_fim") = data_fim
        Else
            ViewState.Item("dt_inicio") = String.Empty
            ViewState.Item("dt_fim") = String.Empty
        End If

        If Not (txt_cd_produtor.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_pessoa") = txt_cd_produtor.Text.Trim()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If
        ViewState.Item("id_pessoa") = hf_id_produtor.Value 'fran 10/05/2010 chamado 830

        If Not (txt_cd_fornecedor.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("cd_fornecedor") = txt_cd_fornecedor.Text.Trim()
        Else
            ViewState.Item("cd_fornecedor") = String.Empty
        End If
        ViewState.Item("id_fornecedor") = hf_id_fornecedor.Value 'fran 10/05/2010 chamado 830
        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_pagto_fornecedor_conciliacao.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_pagto_fornecedor_conciliacao.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 154
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

        With img_lupa_tecnico
            .Attributes.Add("onclick", "javascript:ShowDialogTecnico()")
            .ToolTip = "Filtrar Técnicos"
        End With
        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtor"
        End With
        With img_lupa_fornecedor
            .Attributes.Add("onclick", "javascript:ShowDialogFornecedor()")
            .ToolTip = "Filtrar Fornecedor"
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
            'fran 10/05/2010 i chamado 830
            'If Not (ViewState("nm_tecnico").ToString().Equals(String.Empty)) Then
            If Not (ViewState("id_tecnico").ToString().Equals(String.Empty)) Then
                'fran 10/05/2010 chamado 830
                pedido.id_tecnico = Convert.ToString(ViewState.Item("id_tecnico"))
            End If
            'fran 10/05/2010 i chamado 830
            'If Not (ViewState("cd_pessoa").ToString().Equals(String.Empty)) Then
            If Not (ViewState("id_pessoa").ToString().Equals(String.Empty)) Then
                'fran 10/05/2010 f chamado 830
                pedido.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            'fran 10/05/2010 i chamado 830
            'If Not (ViewState("cd_fornecedor").ToString().Equals(String.Empty)) Then
            If Not (ViewState("id_fornecedor").ToString().Equals(String.Empty)) Then
                'fran 10/05/2010 chamado 830
                pedido.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor"))
            End If
            If Not (ViewState("id_estabelecimento").ToString().Equals(String.Empty)) Then
                pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            End If
            If Not (ViewState("dt_inicio").ToString().Equals(String.Empty)) Then
                pedido.dt_inicio = ViewState.Item("dt_inicio")
                pedido.dt_fim = ViewState.Item("dt_fim")
            End If
            'fran 10/05/2010 i chamado 830
            pedido.cd_produtor = ViewState("cd_pessoa").ToString
            pedido.cd_fornecedor = ViewState("cd_fornecedor").ToString
            'fran 10/05/2010 f chamado 830

            Dim dspedido As DataSet = pedido.getParcelamento_Parceiros

            If (dspedido.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dspedido.Tables(0), ViewState.Item("sortExpression"))
                ViewState.Item("totalsaldo") = "0" 'fran 09/12/2010 i
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

            'fran 10/05/2010 i chamado 830
            'Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_central_demonst_parcelas.aspx?dt_referencia={0}", Me.txt_dt_referencia.Text) & String.Format("&id_produtor={0}", Me.hf_id_produtor.Value) & String.Format("&id_estabelecimento={0}", Me.cbo_estabelecimento.SelectedValue) & String.Format("&id_tecnico={0}", Me.hf_id_tecnico.Value) & String.Format("&id_fornecedor={0}", Me.hf_id_fornecedor.Value)
            Me.hl_imprimir.NavigateUrl = String.Format("frm_relatorio_central_demonst_parcelas.aspx?dt_referencia={0}", Me.txt_dt_referencia.Text) & String.Format("&id_produtor={0}", pedido.id_pessoa.ToString) & String.Format("&id_estabelecimento={0}", pedido.id_estabelecimento.ToString) & String.Format("&id_tecnico={0}", pedido.id_tecnico.ToString) & String.Format("&id_fornecedor={0}", pedido.id_fornecedor.ToString) & String.Format("&cd_produtor={0}", pedido.cd_produtor.ToString) & String.Format("&cd_fornecedor={0}", pedido.cd_fornecedor.ToString)
            'fran 10/05/2010 f chamado 830

            Me.hl_imprimir.Enabled = True

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        ' Adri 04/11/2009 - i
        If (e.Row.RowType <> DataControlRowType.Header _
           And e.Row.RowType <> DataControlRowType.Footer _
           And e.Row.RowType <> DataControlRowType.Pager) Then

            ' Coluna 6 - Nome do Técnico
            If (e.Row.Cells(6).Text.Trim().Equals("Total")) Then  ' Se é a linha de total, limpa o código do parceiro
                e.Row.Cells(0).Text = ""
                e.Row.Cells(13).Text = ViewState.Item("totalsaldo").ToString 'fran 09/12/2010 i
                ViewState.Item("totalsaldo") = "0" 'fran 09/12/2010 i
            Else
                'fran 09/12/2010 i
                Dim pedido As New Pedido
                Dim dt_pagto As Label = CType(e.Row.FindControl("dt_pagto"), Label)
                Dim nrsaldo As Decimal
                pedido.id_central_pedido = Convert.ToInt32(e.Row.Cells(7).Text.Trim)
                pedido.dt_fim = dt_pagto.Text.ToString
                nrsaldo = pedido.getCentralParcelamentoSaldo
                e.Row.Cells(13).Text = nrsaldo.ToString
                nrsaldo = CDbl(ViewState.Item("totalsaldo").ToString) + nrsaldo
                ViewState.Item("totalsaldo") = nrsaldo.ToString
                'fran 09/12/2010 f
            End If

            ' Adri 04/11/2009 - f

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

        'ViewState.Item("id_tecnico") = hf_id_tecnico.Value 'fran 10/05/2010 i chamado 830
        'ViewState.Item("id_produtor") = hf_id_produtor.Value 'fran 10/05/2010 i chamado 830
        ViewState.Item("id_fornecedor") = hf_id_fornecedor.Value

        'fran 10/05/2010 i chamado 830
        ViewState.Item("id_tecnico") = txt_cd_tecnico.Text
        ViewState.Item("id_pessoa") = hf_id_produtor.Value
        ViewState.Item("cd_pessoa") = txt_cd_produtor.Text
        ViewState.Item("cd_fornecedor") = txt_cd_fornecedor.Text
        'fran 10/05/2010 f chamado 830


        loadData()

        'FRAN 08/12/2020 i incluir log 
        Dim usuariolog As New UsuarioLog
        usuariolog.id_usuario = Session("id_login")
        usuariolog.ds_id_session = Session.SessionID.ToString()
        usuariolog.id_tipo_log = 8 'exporta~ção
        usuariolog.id_menu_item = 154
        usuariolog.insertUsuarioLog()
        'FRAN 08/12/2020  incluir log 


        'fran 10/05/2010 i chamado 830
        'Response.Redirect("frm_central_demonst_parcelas_excel.aspx?id_tecnico=" + ViewState.Item("id_tecnico").ToString + "&id_produtor=" + ViewState.Item("id_produtor").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_fornecedor=" + ViewState.Item("id_fornecedor").ToString)
        Response.Redirect("frm_central_demonst_parcelas_excel.aspx?id_tecnico=" + ViewState.Item("id_tecnico").ToString + "&id_produtor=" + ViewState.Item("id_pessoa").ToString + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString + "&id_fornecedor=" + ViewState.Item("id_fornecedor").ToString + "&cd_produtor=" + ViewState.Item("cd_pessoa").ToString + "&cd_fornecedor=" + ViewState.Item("cd_fornecedor").ToString)
        'fran 10/05/2010 f chamado 830


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

    Protected Sub img_lupa_fornecedor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_fornecedor.Click
        carregarCamposfornecedor()
    End Sub
    Private Sub carregarCamposfornecedor()
        Try

            If Not (customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").Equals(String.Empty)) Then
                lbl_nm_fornecedor.Text = customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").Equals(String.Empty)) Then
                txt_cd_fornecedor.Text = customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").ToString
            End If
            Me.ViewState.Item("id_fornecedor") = hf_id_fornecedor.Value
            customPage.clearFilters("lupa_fornecedor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
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

    Public Sub New()

    End Sub

    Protected Sub txt_cd_tecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_tecnico.TextChanged
        ' Adri 04/05/2010 - i
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
        ' Adri 04/05/2010 - f

    End Sub

    Protected Sub txt_cd_fornecedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_fornecedor.TextChanged

        ' Adri 04/05/2010 - i
        lbl_nm_fornecedor.Text = String.Empty
        hf_id_fornecedor.Value = String.Empty
        Try
            If Not txt_cd_fornecedor.Text.Equals(String.Empty) Then
                Dim fornecedor As New Pessoa
                fornecedor.cd_pessoa = Me.txt_cd_fornecedor.Text.Trim
                fornecedor.id_situacao = 1
                Dim dsfornecedor As DataSet = fornecedor.getFornecedorByFilters
                'se encontrou 
                If dsfornecedor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_fornecedor.Enabled = True
                    lbl_nm_fornecedor.Text = dsfornecedor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_fornecedor.Value = dsfornecedor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
        ' Adri 04/05/2010 - f

    End Sub

    Protected Sub txt_cd_produtor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_produtor.TextChanged

        ' Adri 04/05/2010 - i
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
        ' Adri 04/05/2010 - f

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

