Imports Danone.MilkSystem.Business
Imports System.Data
Imports System.Math
Partial Class lst_preco_cooperativa_aprovar_2N

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("dt_referencia") = Me.txt_MesAno.Text()
        ViewState.Item("nr_periodo") = 0
        If chk_1quinz.Checked = True AndAlso chk_2quinz.Checked = False Then
            ViewState.Item("nr_periodo") = 1
        End If
        If chk_1quinz.Checked = False AndAlso chk_2quinz.Checked = True Then
            ViewState.Item("nr_periodo") = 2
        End If

        Dim preconegociado As New PrecoNegociadoCooperativa

        preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
        preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
        preconegociado.nr_periodo = ViewState("nr_periodo").ToString
        preconegociado.id_situacao = 1
        preconegociado.st_selecao = 0
        preconegociado.updatePrecoNegociadoCooperativaTodos2N()

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_preco_cooperativa_aprovar_2N.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_preco_cooperativa_aprovar_2N.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 242
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If


    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento
            estabelecimento.st_recepcao_leite = "S"
            Dim statuspreconegociado As New StatusPrecoNegociado

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))

            'If Day(Now) <= 15 Then
            '    chk_1quinz.Checked = True
            '    chk_2quinz.Checked = False
            'Else
            '    chk_1quinz.Checked = False
            '    chk_2quinz.Checked = True

            'End If
            ViewState.Item("sortExpression") = "ds_produtor asc"



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

 
    Private Sub loadData()

        Try
            Dim preconegociado As New PrecoNegociadoCooperativa

            preconegociado.dt_referencia = String.Concat("01/" & ViewState("dt_referencia").ToString)
            preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            preconegociado.nr_periodo = ViewState("nr_periodo").ToString
            preconegociado.id_situacao = 1
            preconegociado.st_aprovado = 1

            Me.lk_aprovar.Enabled = True
            Me.lk_reprovar.Enabled = True

            ' 30/11/2008 (não exibir itens aprovador 2.o Nível para a tela de Aprovação 1.o Nível)
            Dim dsPrecoNegociado As DataSet = preconegociado.getPrecoNegociadoCooperativaByFilters()

            If (dsPrecoNegociado.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsPrecoNegociado.Tables(0), ViewState.Item("sortExpression"))
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
        saveCheckBox()
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

            Case "nm_pessoa"
                If (ViewState.Item("sortExpression")) = "nm_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_pessoa asc"
                End If

            Case "nr_preco_anterior"
                If (ViewState.Item("sortExpression")) = "nr_preco_anterior asc" Then
                    ViewState.Item("sortExpression") = "nr_preco_anterior desc"
                Else
                    ViewState.Item("sortExpression") = "nr_preco_anterior asc"
                End If


            Case "nr_preco_negociado"
                If (ViewState.Item("sortExpression")) = "nr_preco_negociado asc" Then
                    ViewState.Item("sortExpression") = "nr_preco_negociado desc"
                Else
                    ViewState.Item("sortExpression") = "nr_preco_negociado asc"
                End If


            Case "st_aprovado"
                If (ViewState.Item("sortExpression")) = "st_aprovado asc" Then
                    ViewState.Item("sortExpression") = "st_aprovado desc"
                Else
                    ViewState.Item("sortExpression") = "st_aprovado asc"
                End If


        End Select

        loadData()

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
        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub


    Protected Sub lk_aprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_aprovar.Click
        Try
            Dim preconegociado As New PrecoNegociadoCooperativa


            If saveCheckBox() = True Then
                preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
                preconegociado.dt_referencia = String.Concat("01/" & ViewState.Item("dt_referencia").ToString)
                preconegociado.nr_periodo = ViewState.Item("nr_periodo").ToString
                preconegociado.st_aprovado = "2"   '  Aprovado 2.o Nível
                preconegociado.id_modificador = Session("id_login")

                preconegociado.updatePrecoNegociadoCooperativaAprovarSelecionados()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 242
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                loadData()

                messageControl.Alert("Aprovação 2.o Nível concluída com sucesso.")
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

    Protected Sub gridResults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridResults.RowEditing
        Try

            gridResults.EditIndex = e.NewEditIndex
            loadData()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridResults.RowUpdating
        'Capturar valores
        Dim row As GridViewRow = gridResults.Rows(e.RowIndex)
        Try

            If (Not (row) Is Nothing) Then

                'Dim preconegociado As New PrecoNegociadoCooperativa
                'Dim erro As Boolean


                'preconegociado.id_preco_negociado_cooperativa = Convert.ToInt32(gridResults.DataKeys.Item(e.RowIndex).Value)

                'Dim txt_nr_preco_negociado As RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox = CType(row.FindControl("txt_nr_preco_negociado"), RK.TextBox.AjaxOnlyDecimal.OnlyDecimalTextBox)
                'If Not (txt_nr_preco_negociado.Text.Trim.ToString.Equals(String.Empty)) Then
                '    preconegociado.nr_preco_negociado = Convert.ToDecimal(txt_nr_preco_negociado.Text)
                'Else
                '    preconegociado.nr_preco_negociado = 0
                'End If
                'preconegociado.id_modificador = Session("id_login")


                'erro = False
                ''If preconegociado.nr_preco_negociado = 0 And Convert.ToDecimal(gridResults.Rows(e.RowIndex).Cells(4).Text) > 0 Then
                ''    erro = True
                ''    messageControl.Alert("O Preço deve ser informado!")
                ''End If

                'If erro = False Then
                '    preconegociado.updatePrecoNegociadoAprovador()
                '    gridResults.EditIndex = -1
                '    loadData()
                'End If
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

            ' 30/11/2008  -  Seleciona tudo o que o botão Pesquisar trouxe - i
            Dim preconegociado As New PrecoNegociadoCooperativa
            preconegociado.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            preconegociado.dt_referencia = String.Concat("01/" & ViewState.Item("dt_referencia").ToString)
            preconegociado.nr_periodo = ViewState.Item("nr_periodo").ToString
            If ck_header.Checked = True Then
                preconegociado.st_selecao = "1"
            Else
                preconegociado.st_selecao = "0"
            End If
            preconegociado.updatePrecoNegociadoCooperativaTodos2N()
            ' 30/11/2008  -  Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function saveCheckBox() As Boolean

        Try

            Dim li As Integer

            For li = 0 To gridResults.Rows.Count - 1
                Dim preconegociado As New PrecoNegociadoCooperativa()
                preconegociado.id_preco_negociado_cooperativa = gridResults.DataKeys(li).Value.ToString
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    preconegociado.st_selecao = "1"
                    saveCheckBox = True     ' Indica que tem item selecionado
                Else
                    preconegociado.st_selecao = "0"
                End If
                preconegociado.updatePrecoNegociadoCooperativaSelecao()
            Next

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub lk_reprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_reprovar.Click
        Try
            Dim preconegociado As New PrecoNegociadoCooperativa

            If saveCheckBox() = True Then
                preconegociado.id_estabelecimento = ViewState.Item("id_estabelecimento")
                preconegociado.dt_referencia = String.Concat("01/" & ViewState.Item("dt_referencia").ToString)
                preconegociado.st_aprovado = "3"   '  Reprovado
                preconegociado.id_modificador = Session("id_login")
                preconegociado.nr_periodo = ViewState.Item("nr_periodo").ToString

                preconegociado.updatePrecoNegociadoCooperativaAprovarSelecionados()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'processo
                usuariolog.id_menu_item = 242
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                loadData()

                messageControl.Alert("Itens reprovados com sucesso.")
            Else
                messageControl.Alert("Nenhum item foi selecionado para ser reprovado. Por favor selecione alguma propriedade.")
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

End Class
