Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.Math

Partial Class lst_contrato_aprovar_2N

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = Me.cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia") = Me.txt_MesAno.Text()
        ViewState.Item("id_contrato_validade") = String.Empty

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_contrato_aprovar_2N.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_contrato_aprovar_2N.aspx")

        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 182
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If

    End Sub


    Private Sub loadDetails()

        Try

            ViewState.Item("sortExpression") = "dt_referencia desc, cd_contrato"

            Dim categoria As New CategoriaQualidade

            cbo_categoria.DataSource = categoria.getCategoriaByFilters()
            cbo_categoria.DataTextField = "nm_categoria"
            cbo_categoria.DataValueField = "id_categoria"
            cbo_categoria.DataBind()
            cbo_categoria.Items.FindByValue("1").Selected = True
            ViewState.Item("id_categoria") = cbo_categoria.SelectedValue

            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    'Private Sub loadFilters()

    '    Dim hasFilters As Boolean


    '    If Not (customPage.getFilterValue("adiantamento_solicitar", cbo_status.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("st_aprovado") = customPage.getFilterValue("adiantamento_solicitar", cbo_status.ID)
    '        Me.cbo_status.Text = ViewState.Item("st_aprovado").ToString()
    '    Else
    '        ViewState.Item("st_aprovado") = String.Empty
    '    End If


    '    If Not (customPage.getFilterValue("adiantamento_solicitar", cbo_situacao.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_situacao") = customPage.getFilterValue("adiantamento_solicitar", cbo_situacao.ID)
    '        cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
    '    Else
    '        ViewState.Item("id_situacao") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("adiantamento_solicitar", txt_MesAno.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("dt_referencia") = customPage.getFilterValue("adiantamento_solicitar", txt_MesAno.ID)
    '        txt_MesAno.Text = ViewState.Item("dt_referencia").ToString()
    '    Else
    '        ViewState.Item("dt_referencia") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("adiantamento_solicitar", txt_cd_tecnico.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("id_tecnico") = customPage.getFilterValue("adiantamento_solicitar", txt_cd_tecnico.ID)
    '        txt_cd_tecnico.Text = ViewState.Item("id_tecnico").ToString()
    '    Else
    '        ViewState.Item("id_tecnico") = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("adiantamento_solicitar", lbl_nm_tecnico.ID).Equals(String.Empty)) Then
    '        hasFilters = True
    '        ViewState.Item("nm_tecnico") = customPage.getFilterValue("adiantamento_solicitar", lbl_nm_tecnico.ID)
    '        lbl_nm_tecnico.Text = ViewState.Item("nm_tecnico").ToString()
    '        hf_id_tecnico.Value = ViewState.Item("id_tecnico").ToString
    '    Else
    '        ViewState.Item("nm_tecnico") = String.Empty
    '        hf_id_tecnico.Value = String.Empty
    '    End If

    '    If Not (customPage.getFilterValue("adiantamento_solicitar", "PageIndex").Equals(String.Empty)) Then
    '        ViewState.Item("PageIndex") = customPage.getFilterValue("adiantamento_solicitar", "PageIndex").ToString()
    '        gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
    '    End If

    '    If (hasFilters) Then
    '        loadData()
    '        customPage.clearFilters("adiantamento_solicitar")
    '    End If

    'End Sub

    Private Sub loadData()

        Try
            Dim contrato As New Contrato

            contrato.id_estabelecimento = ViewState("id_estabelecimento").ToString
            contrato.id_situacao = 1 'ativo
            contrato.id_situacao_contrato = 3 'aprovado 1o nivel
            contrato.id_situacao_contrato_validade = 1 'ativo
            contrato.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)


            Dim dscontrato As DataSet = contrato.getContratoSuasValidades()

            If (dscontrato.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dscontrato.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                Me.lk_aprovar.Enabled = True
                Me.lk_reprovar.Enabled = True

                'se  selecionou detalhe
                If Not (ViewState.Item("id_contrato_validade") Is Nothing) AndAlso Not (ViewState.Item("id_contrato_validade").ToString.Equals(String.Empty)) Then
                    If ViewState.Item("lbl_grid_detalhe") = "qualidade" Then
                        pnl_adicionalvolume.Visible = False
                        pnl_qualidade.Visible = True
                        pnl_qualidade.GroupingText = String.Concat("Detalhe Faixa Qualidade do Contrato ", ViewState.Item("lbl_detalhe_contrato").ToString)
                        loadGridQualidade()
                    End If
                    If ViewState.Item("lbl_grid_detalhe") = "volume" Then
                        pnl_adicionalvolume.Visible = True
                        pnl_qualidade.Visible = False
                        pnl_adicionalvolume.GroupingText = String.Concat("Detalhe Adicional de Volume do Contrato ", ViewState.Item("lbl_detalhe_contrato").ToString)
                        loadGridAdicionalVolume()

                    End If
                End If

            Else
                Me.lk_aprovar.Enabled = False
                Me.lk_reprovar.Enabled = False
                pnl_qualidade.Visible = False
                pnl_adicionalvolume.Visible = False

                gridResults.Visible = False
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadGridQualidade()


        Dim qualidade As New FaixaQualidade

        qualidade.id_contrato_validade = ViewState.Item("id_contrato_validade").ToString
        If CInt(ViewState.Item("id_categoria")) > 0 Then
            qualidade.id_categoria = ViewState.Item("id_categoria").ToString
        End If
        qualidade.id_situacao = 1
        Dim dsqualidade As DataSet = qualidade.getFaixaQualidadeByFilters()

        'se tem linhas em compartimento
        If (dsqualidade.Tables(0).Rows.Count > 0) Then
            gridQualidade.Visible = True
            gridQualidade.DataSource = Helper.getDataView(dsqualidade.Tables(0), "")
            gridQualidade.DataBind()
        Else
            Dim dr As DataRow = dsqualidade.Tables(0).NewRow()
            dsqualidade.Tables(0).Rows.InsertAt(dr, 0)
            gridQualidade.Visible = True
            gridQualidade.DataSource = Helper.getDataView(dsqualidade.Tables(0), "")
            gridQualidade.DataBind()
            gridQualidade.Rows(0).Cells.Clear()
            gridQualidade.Rows(0).Cells.Add(New TableCell())
            gridQualidade.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            gridQualidade.Rows(0).Cells(0).Text = "Não existe nenhuma qualidade informada para o Contrato!"
            gridQualidade.Rows(0).Cells(0).ColumnSpan = 8

        End If

    End Sub
    Private Sub loadGridAdicionalVolume()

        Try

            Dim contratoadicvolume As New ContratoAdicionalVolume

            contratoadicvolume.id_contrato_validade = Convert.ToInt32(ViewState.Item("id_contrato_validade"))
            contratoadicvolume.id_situacao = 1

            Dim dscontratovolume As DataSet = contratoadicvolume.getContratoAdicionalVolumeByFilters()

            If (dscontratovolume.Tables(0).Rows.Count > 0) Then
                grdAdicionalVolume.Visible = True
                grdAdicionalVolume.DataSource = Helper.getDataView(dscontratovolume.Tables(0), "")
                grdAdicionalVolume.DataBind()
            Else
                grdAdicionalVolume.Visible = False
                Dim dr As DataRow = dscontratovolume.Tables(0).NewRow()
                dscontratovolume.Tables(0).Rows.InsertAt(dr, 0)
                grdAdicionalVolume.Visible = True
                grdAdicionalVolume.DataSource = Helper.getDataView(dscontratovolume.Tables(0), "")
                grdAdicionalVolume.DataBind()
                grdAdicionalVolume.Rows(0).Cells.Clear()
                grdAdicionalVolume.Rows(0).Cells.Add(New TableCell())
                grdAdicionalVolume.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                grdAdicionalVolume.Rows(0).Cells(0).Text = "Não existe nenhum adicional de volume informado para o Contrato!"
                grdAdicionalVolume.Rows(0).Cells(0).ColumnSpan = 8
                messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        saveCheckBox()
        loadData()

    End Sub

    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        'Select Case e.SortExpression.ToLower()




        'End Select

        'loadData()

    End Sub
    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated

        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Try
                Dim btn_detalhe_qualidade As ImageButton = CType(e.Row.FindControl("btn_detalhe_qualidade"), ImageButton)
                btn_detalhe_qualidade.CommandArgument = e.Row.RowIndex.ToString
                Dim btn_detalhe_volume As ImageButton = CType(e.Row.FindControl("btn_detalhe_volume"), ImageButton)
                btn_detalhe_volume.CommandArgument = e.Row.RowIndex.ToString
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If

    End Sub
    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Try

            Select Case e.CommandName.ToString().ToLower()
                Case "detalhequalidade"
                    If gridResults.EditIndex = -1 Then
                        Dim lbl_id_contrato_validade As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_contrato_validade"), Label)
                        Dim cd_contrato As DataControlFieldCell = CType(gridResults.Rows.Item(e.CommandArgument.ToString).Cells(2), DataControlFieldCell)

                        ViewState.Item("id_contrato_validade") = lbl_id_contrato_validade.Text
                        ViewState.Item("lbl_detalhe_contrato") = cd_contrato.Text
                        ViewState.Item("lbl_grid_detalhe") = "qualidade"
                        loadData()
                    End If
                Case "detalhevolume"
                    If gridResults.EditIndex = -1 Then
                        Dim lbl_id_contrato_validade As Label = CType(gridResults.Rows.Item(e.CommandArgument.ToString).FindControl("lbl_id_contrato_validade"), Label)
                        Dim cd_contrato As DataControlFieldCell = CType(gridResults.Rows.Item(e.CommandArgument.ToString).Cells(2), DataControlFieldCell)

                        ViewState.Item("id_contrato_validade") = lbl_id_contrato_validade.Text
                        ViewState.Item("lbl_detalhe_contrato") = cd_contrato.Text
                        ViewState.Item("lbl_grid_detalhe") = "volume"
                        loadData()
                    End If

            End Select
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound

        '    ' 25/11/2009 - Chamado 499 - i
        '    If (e.Row.RowType <> DataControlRowType.Header _
        'And e.Row.RowType <> DataControlRowType.Footer _
        'And e.Row.RowType <> DataControlRowType.Pager) Then
        '        'Formatações
        '        If e.Row.Cells(7).Text.Equals(String.Empty) Then
        '            e.Row.Cells(7).Text = "0"
        '        End If
        '        'Total descontos + adto deve ser somado ao novo adto
        '        e.Row.Cells(7).Text = (Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) + Convert.ToDecimal(e.Row.Cells(6).Text.Trim()))
        '        ' Calcular % Comprometido (Total Desc + Adtos) / Valor Mensal Estimado
        '        If IsNumeric(e.Row.Cells(4).Text.Trim()) Then  ' Se tem Valor Mensal Estimado
        '            If Convert.ToDecimal(e.Row.Cells(4).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
        '                'fran fase 3 formatação i
        '                'e.Row.Cells(8).Text = Round(Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) / Convert.ToDecimal(e.Row.Cells(4).Text.Trim()), 2)
        '                e.Row.Cells(8).Text = FormatPercent(Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) / Convert.ToDecimal(e.Row.Cells(4).Text.Trim()), 2)
        '                'fran fase 3 formatação f
        '            End If
        '        End If
        '        If IsNumeric(e.Row.Cells(3).Text.Trim()) Then  ' volume
        '            If Convert.ToInt64(e.Row.Cells(3).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
        '                e.Row.Cells(3).Text = FormatNumber(Convert.ToInt64(e.Row.Cells(3).Text.Trim()))
        '            End If
        '        End If
        '        If IsNumeric(e.Row.Cells(4).Text.Trim()) Then  ' valor mensal
        '            If Convert.ToDecimal(e.Row.Cells(4).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
        '                e.Row.Cells(4).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(4).Text.Trim()), 2, , , TriState.True)
        '            End If
        '        End If
        '        If IsNumeric(e.Row.Cells(5).Text.Trim()) Then  ' descontos
        '            If Convert.ToDecimal(e.Row.Cells(5).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
        '                e.Row.Cells(5).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(5).Text.Trim()), 2, , , TriState.True)
        '            End If
        '        End If
        '        If IsNumeric(e.Row.Cells(6).Text.Trim()) Then  ' valor adto
        '            If Convert.ToDecimal(e.Row.Cells(6).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
        '                e.Row.Cells(6).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(6).Text.Trim()), 2, , , TriState.True)
        '            End If
        '        End If
        '        If IsNumeric(e.Row.Cells(7).Text.Trim()) Then  ' total desc + adto
        '            If Convert.ToDecimal(e.Row.Cells(7).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
        '                e.Row.Cells(7).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(7).Text.Trim()), 2, , , TriState.True)
        '            End If
        '        End If

        '        If IsNumeric(e.Row.Cells(11).Text.Trim()) Then  ' saldo x politica adto
        '            If Convert.ToDecimal(e.Row.Cells(11).Text.Trim()) > 0 Then  ' Se o valor é maior que zero
        '                e.Row.Cells(11).Text = FormatNumber(Convert.ToDecimal(e.Row.Cells(11).Text.Trim()), 2, , , TriState.True)
        '            End If
        '        End If
        '    End If
        '    ' 25/11/2009 - Chamado 499 - f
        Try
            If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

                'If (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then

                Dim lbl_id_contrato_validade As Label = CType(e.Row.FindControl("lbl_id_contrato_validade"), Label)

                If (Not lbl_id_contrato_validade.Text.Equals(String.Empty)) AndAlso Not (ViewState.Item("id_contrato_validade").Equals(String.Empty)) AndAlso CLng(lbl_id_contrato_validade.Text) = CLng(ViewState.Item("id_contrato_validade")) Then
                    e.Row.ForeColor = Drawing.Color.Red
                    'lbl_id_propriedade_titular.ForeColor = Drawing.Color.Red 'fran 25/08/2015
                Else
                    e.Row.ForeColor = System.Drawing.Color.FromName("#333333")
                End If
                'Else

                'End If
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub lk_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_aprovar.Click
        Try
            Dim contrato As New ContratoValidade

            If saveCheckBox() = True Then

                contrato.dt_referencia = String.Concat("01/" & ViewState.Item("dt_referencia").ToString)
                contrato.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
                contrato.id_modificador = Session("id_login")

                contrato.updateContratoAprovarSelecionados2Nivel()
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'PROCESSO
                usuariolog.id_menu_item = 182
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f
                loadData()

                messageControl.Alert("Aprovação 2.o Nível concluída com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser aprovado. Por favor selecione algum contrato.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function saveCheckBox() As Boolean

        Try

            Dim li As Integer

            For li = 0 To gridResults.Rows.Count - 1
                Dim contrato As New ContratoValidade()
                contrato.id_contrato_validade = gridResults.DataKeys(li).Value.ToString
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    contrato.st_selecao = "1"
                    saveCheckBox = True     ' Indica que tem item selecionado
                Else
                    contrato.st_selecao = "0"
                End If
                contrato.updateContratoSelecao()
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub lk_reprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_reprovar.Click
        Try
            Dim contrato As New ContratoValidade

            If saveCheckBox() = True Then
                contrato.dt_referencia = String.Concat("01/" & ViewState.Item("dt_referencia").ToString)
                contrato.id_estabelecimento = ViewState.Item("id_estabelecimento").ToString
                contrato.id_modificador = Session("id_login")
                contrato.updateContratoNaoAprovarSelecionados2Nivel()
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'PROCESSO
                usuariolog.id_menu_item = 182
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f
                loadData()

                messageControl.Alert("Itens reprovados com sucesso.")

            Else
                messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione algum contrato.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub ck_header_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim li As Integer
            Dim ch As CheckBox
            Dim ck_header As CheckBox

            ck_header = CType(sender, CheckBox)

            For li = 0 To gridResults.Rows.Count - 1
                ch = CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox)
                ch.Checked = ck_header.Checked
            Next

            ' Seleciona tudo o que o botão Pesquisar trouxer - i
            Dim contrato As New ContratoValidade
            contrato.id_estabelecimento = ViewState("id_estabelecimento").ToString
            contrato.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            contrato.id_situacao = 1 'contrato ativo
            contrato.id_situacao_contrato = 2 'contrato completo

            If ck_header.Checked = True Then
                contrato.st_selecao = "1"
            Else
                contrato.st_selecao = "0"
            End If
            contrato.updateContratoSelecaoTodos()
            ' Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub


    Protected Sub cbo_categoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_categoria.SelectedIndexChanged
        Try
            ViewState.Item("id_categoria") = cbo_categoria.SelectedValue
            loadGridQualidade()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
End Class
