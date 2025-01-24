Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_importar_pedidos_dados

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        If Page.IsValid Then

            ViewState.Item("id_fornecedor") = Me.hf_id_fornecedor.Value
            ViewState.Item("id_produtor") = Me.hf_id_pessoa.Value
            ViewState.Item("txt_dt_pagto_ini") = Me.txt_dt_pagto_ini.Text.Trim
            ViewState.Item("txt_dt_pagto_fim") = Me.txt_dt_pagto_fim.Text.Trim
            If (Me.txt_dt_pagto_fim.Text.Trim) = "" Then
                ViewState.Item("txt_dt_pagto_fim") = Me.txt_dt_pagto_ini.Text.Trim
            End If
            ViewState.Item("id_propriedade") = Me.txt_id_propriedade.Text
            ViewState.Item("nr_nota") = Me.txt_nr_nota.Text
            ViewState.Item("id_importacao") = Me.txt_id_importacao.Text

            loadData()
        End If

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_importar_pedidos_dados.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_importar_pedidos_dados.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 214
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
        With btn_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialogProdutor()")
            .ToolTip = "Filtrar Produtores"
            '.Style("cursor") = "hand"
        End With
        With btn_lupa_parceiro
            .Attributes.Add("onclick", "javascript:ShowDialogFornecedor()")
            .ToolTip = "Filtrar Parceiros"
            '.Style("cursor") = "hand"
        End With


    End Sub


    Private Sub loadDetails()

        Try


            txt_dt_pagto_ini.Text = "01/" & DateTime.Parse(Now).ToString("MM/yyyy")
            txt_dt_pagto_fim.Text = "01/" & DateTime.Parse(DateAdd(DateInterval.Month, 1, Convert.ToDateTime(txt_dt_pagto_ini.Text))).ToString("MM/yyyy")

            ViewState.Item("sortExpression") = ""

            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

 
    Private Sub loadData()

        Try
            Dim pedido As New ImportacaoPedido

            If Trim(ViewState.Item("id_fornecedor")) <> "" Then
                pedido.id_fornecedor = Convert.ToInt32(ViewState.Item("id_fornecedor").ToString)
            End If
            If Trim(ViewState.Item("id_produtor")) <> "" Then
                pedido.id_produtor = Convert.ToInt32(ViewState.Item("id_produtor").ToString)
            End If
            If Trim(ViewState.Item("id_importacao")) <> "" Then
                pedido.id_importacao = Convert.ToInt32(ViewState.Item("id_importacao").ToString)
            End If
            If Trim(ViewState.Item("nr_nota")) <> "" Then
                pedido.nr_nota = Convert.ToInt32(ViewState.Item("nr_nota").ToString)
            End If
            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                pedido.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            pedido.dt_pagto_ini = ViewState.Item("txt_dt_pagto_ini").ToString
            pedido.dt_pagto_fim = ViewState.Item("txt_dt_pagto_fim").ToString
            Dim dspedido As DataSet = pedido.getImportacaoPedidoIncluidosByFilters()

            If (dspedido.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dspedido.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
            Else
                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        loadData()

    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "ds_produtor"
                If (ViewState.Item("sortExpression")) = "ds_produtor asc" Then
                    ViewState.Item("sortExpression") = "ds_produtor desc"
                Else
                    ViewState.Item("sortExpression") = "ds_produtor asc"
                End If


            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If


            Case "nm_fornecedor"
                If (ViewState.Item("sortExpression")) = "nm_fornecedor asc" Then
                    ViewState.Item("sortExpression") = "nm_fornecedor desc"
                Else
                    ViewState.Item("sortExpression") = "nm_fornecedor asc"
                End If
            Case "dt_desconto_produtor"
                If (ViewState.Item("sortExpression")) = "dt_desconto_produtor asc" Then
                    ViewState.Item("sortExpression") = "dt_desconto_produtor desc"
                Else
                    ViewState.Item("sortExpression") = "dt_desconto_produtor asc"
                End If


            Case "nr_nota"
                If (ViewState.Item("sortExpression")) = "nr_nota asc" Then
                    ViewState.Item("sortExpression") = "nr_nota desc"
                Else
                    ViewState.Item("sortExpression") = "nr_nota asc"
                End If
            Case "id_central_pedido"
                If (ViewState.Item("sortExpression")) = "id_central_pedido asc" Then
                    ViewState.Item("sortExpression") = "id_central_pedido desc"
                Else
                    ViewState.Item("sortExpression") = "id_central_pedido asc"
                End If


            Case "dt_pagto_fornecedor"
                If (ViewState.Item("sortExpression")) = "dt_pagto_fornecedor asc" Then
                    ViewState.Item("sortExpression") = "dt_pagto_fornecedor desc"
                Else
                    ViewState.Item("sortExpression") = "dt_pagto_fornecedor asc"
                End If
        End Select

        loadData()

    End Sub

    'Private Sub saveFilters()

    '    Try


    '        customPage.setFilter("analise_esaq", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
    '        customPage.setFilter("analise_esaq", txt_cd_transportador.ID, ViewState.Item("cd_pessoa").ToString)
    '        customPage.setFilter("analise_esaq", lbl_nm_transportador.ID, lbl_nm_transportador.Text)
    '        customPage.setFilter("analise_esaq", txt_cd_propriedade.ID, ViewState.Item("id_propriedade").ToString)
    '        customPage.setFilter("analise_esaq", hf_id_transportador.ID, ViewState.Item("id_pessoa").ToString)
    '        customPage.setFilter("analise_esaq", lbl_nm_propriedade.ID, ViewState.Item("nm_propriedade").ToString)
    '        customPage.setFilter("analise_esaq", txt_dt_coleta_ini.ID, ViewState.Item("txt_dt_coleta_ini").ToString)
    '        customPage.setFilter("analise_esaq", txt_dt_coleta_fim.ID, ViewState.Item("txt_dt_coleta_fim").ToString)
    '        customPage.setFilter("analise_esaq", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
    '        customPage.setFilter("analise_esaq", cbo_codigo_esalq.ID, ViewState.Item("cd_analise_esalq").ToString)
    '        customPage.setFilter("analise_esaq", "PageIndex", gridResults.PageIndex.ToString())

    '    Catch ex As Exception
    '        messageControl.Alert(ex.Message)
    '    End Try

    'End Sub



    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then


            If Not e.Row.Cells(1).Text.Equals(String.Empty) Then
                e.Row.Cells(1).Text = Left(e.Row.Cells(1).Text, 25)
            End If
            If Not e.Row.Cells(4).Text.Equals(String.Empty) Then
                e.Row.Cells(4).Text = Left(e.Row.Cells(4).Text, 25)
            End If
            If Not e.Row.Cells(8).Text.Equals(String.Empty) Then
                e.Row.Cells(8).Text = Left(e.Row.Cells(8).Text.Trim, 10)
            End If
            If Not e.Row.Cells(9).Text.Equals(String.Empty) Then
                e.Row.Cells(9).Text = Left(e.Row.Cells(9).Text.Trim, 10)
            End If
        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub btn_lupa_parceiro_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_parceiro.Click

        Me.lbl_nm_parceiro.Visible = True
        carregarCamposFornecedor()

    End Sub
    Private Sub carregarCamposFornecedor()

        Try
            If Not (customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_parceiro.Text = customPage.getFilterValue("lupa_fornecedor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_fornecedor.Text = customPage.getFilterValue("lupa_fornecedor", "cd_pessoa").ToString
            End If

            customPage.clearFilters("lupa_fornecedor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_transportador_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_transportador.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidfornecedor As Int32
            If Not (Me.hf_id_fornecedor.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_fornecedor.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_fornecedor.Text.Trim
            'lidtransportador = pessoa.validarTransportador Fran 09/01/2011 i
            lidfornecedor = pessoa.validarFornecedor

            If lidfornecedor > 0 Then
                args.IsValid = True
                hf_id_fornecedor.Value = lidfornecedor
            Else
                hf_id_fornecedor.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Fornecedor não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_exportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_exportar.Click
        If Page.IsValid Then

            ViewState.Item("id_produtor") = Me.hf_id_pessoa.Value
            ViewState.Item("id_fornecedor") = Me.hf_id_fornecedor.Value
            ViewState.Item("txt_dt_pagto_ini") = Me.txt_dt_pagto_ini.Text.Trim
            ViewState.Item("txt_dt_pagto_fim") = Me.txt_dt_pagto_fim.Text.Trim
            If (Me.txt_dt_pagto_fim.Text.Trim) = "" Then
                ViewState.Item("txt_dt_pagto_fim") = Me.txt_dt_pagto_ini.Text.Trim
            End If
            ViewState.Item("id_propriedade") = Me.txt_id_propriedade.Text
            ViewState.Item("id_importacao") = Me.txt_id_importacao.Text
            ViewState.Item("nr_nota") = Me.txt_nr_nota.Text

            loadData()

            'se o grid tiver mais que 65536  linhas não podemos exportar
            If gridResults.Visible = True Then
                If gridResults.Rows.Count.ToString + 1 < 65536 Then
                    'FRAN 08/12/2020 i incluir log 
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 8 'exporta~ção
                    usuariolog.id_menu_item = 214
                    usuariolog.insertUsuarioLog()
                    'FRAN 08/12/2020  incluir log 

                    Response.Redirect("frm_importar_pedido_excel.aspx?id_produtor=" + ViewState.Item("id_produtor").ToString + "&id_fornecedor=" + ViewState.Item("id_fornecedor").ToString + "&dt_pagto_ini=" + ViewState.Item("txt_dt_pagto_ini").ToString + "&dt_pagto_fim=" + ViewState.Item("txt_dt_pagto_fim").ToString + "&id_propriedade=" + ViewState.Item("id_propriedade") + "&nr_nota=" + ViewState.Item("nr_nota") + "&id_importacao=" + ViewState.Item("id_importacao"))
                Else
                    messageControl.Alert("Existem muitas linhas para serem exportadas para o Excel!")
                End If
            End If

        End If

    End Sub

    Protected Sub txt_cd_produtor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_produtor.TextChanged
        lbl_produtor.Text = String.Empty
        hf_id_pessoa.Value = String.Empty
        Try
            If Not txt_cd_produtor.Text.Equals(String.Empty) Then
                Dim produtor As New Pessoa
                produtor.cd_pessoa = Me.txt_cd_produtor.Text.Trim
                produtor.id_situacao = 1
                produtor.id_grupo = 1 'produtores 
                Dim dsprodutor As DataSet = produtor.getPessoaByFilters
                'se encontrou produtor
                If dsprodutor.Tables(0).Rows.Count > 0 Then
                    lbl_produtor.Enabled = True
                    lbl_produtor.Text = dsprodutor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_pessoa.Value = dsprodutor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_produtor.Click
        Me.lbl_produtor.Visible = True
        carregarCamposProdutor()

    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_produtor.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_produtor.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub txt_cd_fornecedor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_fornecedor.TextChanged
        lbl_nm_parceiro.Text = String.Empty
        hf_id_fornecedor.Value = String.Empty
        Try
            If Not txt_cd_fornecedor.Text.Equals(String.Empty) Then
                Dim fornecedor As New Pessoa
                fornecedor.cd_pessoa = Me.txt_cd_fornecedor.Text.Trim  ' Adri 04/05/2010
                fornecedor.id_situacao = 1
                Dim dsfornecedor As DataSet = fornecedor.getFornecedorByFilters
                'se encontrou produtor
                If dsfornecedor.Tables(0).Rows.Count > 0 Then
                    lbl_nm_parceiro.Enabled = True
                    lbl_nm_parceiro.Text = dsfornecedor.Tables(0).Rows(0).Item("nm_pessoa")
                    hf_id_fornecedor.Value = dsfornecedor.Tables(0).Rows(0).Item("id_pessoa")
                End If

            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub cv_produtor_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_produtor.ServerValidate
        Try
            Dim pessoa As New Pessoa()
            Dim lidprodutor As Int32
            If Not (Me.hf_id_pessoa.Value.Trim.Equals(String.Empty)) Then
                pessoa.id_pessoa = Convert.ToInt32(Me.hf_id_pessoa.Value)
            End If

            pessoa.cd_pessoa = Me.txt_cd_produtor.Text.Trim
            'lidtransportador = pessoa.validarTransportador Fran 09/01/2011 i
            lidprodutor = pessoa.validarProdutor

            If lidprodutor > 0 Then
                args.IsValid = True
                hf_id_pessoa.Value = lidprodutor
            Else
                hf_id_pessoa.Value = String.Empty
                args.IsValid = False
                messageControl.Alert("Produtor não cadastrado.")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
End Class
