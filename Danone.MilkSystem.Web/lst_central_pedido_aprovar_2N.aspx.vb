Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Net.Mail
Imports System.Math
Partial Class lst_central_pedido_aprovar_2N

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia") = Me.txt_MesAno.Text

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_central_pedido_aprovar_2N.aspx?st_incluirlog=N")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_central_pedido_aprovar_2N.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 197
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

            ViewState.Item("sortExpression") = "ds_produtor asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("central_pedido_aprovar_2N", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("central_pedido_aprovar_2N", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.SelectedValue = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If



        If Not (customPage.getFilterValue("central_pedido_aprovar_2N", txt_MesAno.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("central_pedido_aprovar_2N", txt_MesAno.ID)
            txt_MesAno.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If
        
        If Not (customPage.getFilterValue("central_pedido_aprovar_2N", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("central_pedido_aprovar_2N", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("central_pedido_aprovar_2N")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim pedido As New Pedido


            pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            pedido.dt_inicio = String.Concat("01/" & ViewState("dt_referencia").ToString)
            pedido.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pedido.dt_inicio)))

            Me.lk_aprovar.Enabled = True
            Me.lk_reprovar.Enabled = True

            Dim dspedido As DataSet = pedido.getCentralPedidoAprovacao2Nivel()

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

            Case "id_propriedade"
                If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If


        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("central_pedido_aprovar_2N", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("central_pedido_aprovar_2N", txt_MesAno.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("central_pedido_aprovar_2N", "PageIndex", gridResults.PageIndex.ToString())


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.Trim.ToString
            Case "Edit", "Editar", "Cancel", "Cancelar", "Update"
                Return
        End Select

    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If (e.Row.RowType <> DataControlRowType.Header _
            And e.Row.RowType <> DataControlRowType.Footer _
            And e.Row.RowType <> DataControlRowType.Pager) Then

            Dim txt_parcelas As DataControlFieldCell = CType(e.Row.Cells(11), DataControlFieldCell)

            Dim lbl_saldo_disponivel As Label = CType(e.Row.FindControl("lbl_saldo_disponivel"), Label)
            Dim lbl_percentual As Label = CType(e.Row.FindControl("lbl_percentual"), Label)
            Dim lbl_faturamento As Label = CType(e.Row.FindControl("lbl_faturamento"), Label)
            Dim lbl_percentual_faturamento As Label = CType(e.Row.FindControl("lbl_percentual_faturamento"), Label)
            Dim lbl_id_propriedade_matriz As Label = CType(e.Row.FindControl("lbl_id_propriedade_matriz"), Label)

            Dim saldodisponivel As New SaldoDisponivel
            saldodisponivel.dt_referencia = String.Concat("01/" & Format(DateTime.Parse(Now), "MM/yyyy").ToString)
            saldodisponivel.id_propriedade = Convert.ToInt32(e.Row.Cells(2).Text)

            lbl_saldo_disponivel.Text = FormatNumber(saldodisponivel.getSaldoDisponivel(True), 2) 'se nao tiver saldo em mapa de leite pega fdos romaneios abertos

            lbl_faturamento.Text = FormatNumber(saldodisponivel.nr_valor_faturamento, 2)

            saldodisponivel.dt_referencia = String.Concat("01/", DateTime.Now.ToString("MM/yyyy")).ToString
            If Not lbl_id_propriedade_matriz.Text.Equals(String.Empty) Then
                saldodisponivel.id_propriedade = lbl_id_propriedade_matriz.Text
            Else
                saldodisponivel.id_propriedade = Convert.ToInt32(e.Row.Cells(2).Text)
            End If

            Dim dslimite As DataSet = saldodisponivel.getSaldoDisponivelPropriedadeEMatriz
            If dslimite.Tables(0).Rows.Count > 0 Then
                With dslimite.Tables(0).Rows(0)
                    lbl_saldo_disponivel.Text = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                End With

            Else
                'se nao tem faturamento na ficha do mes anterior, busca do projetado na ficha custo financeiro
                Dim dslimitecusto As DataSet = saldodisponivel.getSaldoDisponivelFichaCustoPropriedadeEMatriz
                If dslimitecusto.Tables(0).Rows.Count > 0 Then
                    With dslimitecusto.Tables(0).Rows(0)
                        lbl_saldo_disponivel.Text = FormatNumber(.Item("nr_limite_mes_liquido").ToString, 2).ToString
                    End With
                Else
                    lbl_saldo_disponivel.Text = String.Empty
                End If
            End If



            If IsNumeric(lbl_saldo_disponivel.Text) Then
                If lbl_saldo_disponivel.Text > 0 And IsNumeric(e.Row.Cells(6).Text) Then
                    ' Divide o Valor Total pelo Saldo Disponível
                    lbl_percentual.Text = FormatNumber((Convert.ToDecimal(e.Row.Cells(6).Text) / Convert.ToDecimal(lbl_saldo_disponivel.Text)) * 100, 2)  ' 08/12/2010 - Erro pego na validação em reunião
                End If
            End If

            If IsNumeric(lbl_faturamento.Text) Then
                If lbl_faturamento.Text > 0 And IsNumeric(e.Row.Cells(6).Text) Then
                    ' Divide o Valor Total pelo Faturamento Mensal
                    lbl_percentual_faturamento.Text = FormatNumber((Convert.ToDecimal(e.Row.Cells(6).Text) / Convert.ToDecimal(lbl_faturamento.Text)) * 100, 2)
                End If
            End If

            If txt_parcelas.Text.Equals("0") Then
                txt_parcelas.Text = 1
            End If
        End If

    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub lk_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_aprovar.Click
        Try
            Dim pedido As New Pedido

            If verificarCheckBox() = True Then

                'Filtro
                pedido.id_estabelecimento = ViewState.Item("id_estabelecimento")  ' 11/09/2008
                pedido.dt_inicio = String.Concat("01/" & ViewState("dt_referencia").ToString)
                pedido.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pedido.dt_inicio)))

                'Dados para o Update
                pedido.id_central_status_aprovacao = 4
                pedido.id_modificador = Session("id_login")

                pedido.updateCentralPedidoAprovarSelecionados2Nivel()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'PROCESSO
                usuariolog.id_menu_item = 197
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f

                loadData()

                messageControl.Alert("Aprovação 2.o Nível Técnico concluída com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para a aprovação. Por favor selecione alguma propriedade.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Protected Sub gridResults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridResults.RowCancelingEdit
        Try

            gridResults.EditIndex = -1
            loadData()
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

            Dim pedido As New Pedido
            pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            pedido.dt_inicio = String.Concat("01/" & ViewState("dt_referencia").ToString)
            pedido.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pedido.dt_inicio))).ToString

            If ck_header.Checked = True Then
                pedido.st_selecao = "1"
            Else
                pedido.st_selecao = "0"
            End If
            pedido.updateCentralPedidoAprovacaoTodos2N()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_reprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_reprovar.Click
        Try
            Dim pedido As New Pedido

            If verificarCheckBox() = True Then

                ' Dados do filtro
                pedido.id_estabelecimento = ViewState.Item("id_estabelecimento")
                pedido.dt_inicio = String.Concat("01/" & ViewState("dt_referencia").ToString)
                pedido.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pedido.dt_inicio)))

                pedido.id_central_status_aprovacao = 3  '  Reprovado Técnico
                pedido.id_modificador = Session("id_login")

                pedido.updateCentralPedidoAprovarSelecionados2Nivel()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'PROCESSO
                usuariolog.id_menu_item = 197
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f

                loadData()

                messageControl.Alert("Itens reprovados com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione alguma propriedade.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

  
    Protected Sub ck_item_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim wc As WebControl = CType(sender, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim chk_selec As CheckBox

            chk_selec = CType(sender, CheckBox)

            Dim pedido As New Pedido

            pedido.id_central_pedido = Convert.ToInt32(gridResults.DataKeys.Item(row.RowIndex).Value)
            If chk_selec.Checked = True Then
                pedido.st_selecao = "1"
            Else
                pedido.st_selecao = "0"
            End If
            pedido.updateCentralPedidoAprovacaoSelecao()

        Catch ex As Exception
            messageControl.Alert(ex.Message)

        End Try
    End Sub

    Private Function verificarCheckBox() As Boolean

        Try

            Dim pedido As New Pedido
            pedido.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString())
            pedido.dt_inicio = String.Concat("01/" & ViewState("dt_referencia").ToString)
            pedido.dt_fim = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, Convert.ToDateTime(pedido.dt_inicio)))

            pedido.id_central_status_aprovacao = 2

            Dim dspedido As DataSet = pedido.getCentralPedidoAprovacaoSelecionados

            If dspedido.Tables(0).Rows.Count > 0 Then
                verificarCheckBox = True
            Else
                verificarCheckBox = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

End Class
