Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class lst_calculo_adiantamento

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        ViewState.Item("id_estabelecimento") = cbo_estabelecimento.SelectedValue
        ViewState.Item("id_pessoa") = Me.hf_id_pessoa.Value
        ViewState.Item("cd_pessoa") = txt_cd_pessoa.Text.Trim()
        ViewState.Item("id_propriedade") = Me.txt_cd_propriedade.Text.Trim()
        ViewState.Item("dt_referencia") = Me.txt_dt_referencia.Text.Trim()


        insertCalculoAdiantamento()

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_calculo_adiantamento.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_calculo_adiantamento.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 43
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 
            loadDetails()
        End If

        With img_lupa_produtor
            .Attributes.Add("onclick", "javascript:ShowDialog()")
            .ToolTip = "Filtrar Produtores"
        End With

    End Sub

    Private Sub insertCalculoAdiantamento()

        Try

            Dim calculoprodutor As New CalculoProdutor()

            calculoprodutor.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento"))
            If Trim(ViewState.Item("id_pessoa")) <> "" Then
                calculoprodutor.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa"))
            End If
            calculoprodutor.cd_pessoa = ViewState.Item("cd_pessoa")
            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                calculoprodutor.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If
            calculoprodutor.id_modificador = Session("id_login")
            calculoprodutor.id_selecao = ViewState.Item("id_selecao")
            calculoprodutor.dt_referencia = "01/" & ViewState.Item("dt_referencia")

            calculoprodutor.insertCalculoAdiantamento()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadDetails()

        Try

            Dim status As New Situacao
            Dim estabelecimento As New Estabelecimento

            cbo_estabelecimento.DataSource = estabelecimento.getEstabelecimentoByFilters()
            cbo_estabelecimento.DataTextField = "nm_estabelecimento"
            cbo_estabelecimento.DataValueField = "id_estabelecimento"
            cbo_estabelecimento.DataBind()
            cbo_estabelecimento.Items.Insert(0, New ListItem("[Selecione]", "0"))


            ViewState.Item("sortExpression") = "ds_produtor asc"

            ViewState.Item("id_selecao") = Session.SessionID.ToString()

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("calculo_produtor", cbo_estabelecimento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_estabelecimento") = customPage.getFilterValue("calculo_produtor", cbo_estabelecimento.ID)
            Me.cbo_estabelecimento.Text = ViewState.Item("id_estabelecimento").ToString()
        Else
            ViewState.Item("id_estabelecimento") = String.Empty
        End If

        If Not (customPage.getFilterValue("calculo_produtor", txt_cd_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_pessoa") = customPage.getFilterValue("calculo_produtor", txt_cd_pessoa.ID)
            txt_cd_pessoa.Text = ViewState.Item("cd_pessoa").ToString()
        Else
            ViewState.Item("cd_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("calculo_produtor", lbl_nm_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_pessoa") = customPage.getFilterValue("calculo_produtor", lbl_nm_pessoa.ID)
            lbl_nm_pessoa.Text = ViewState.Item("nm_pessoa").ToString()
        Else
            ViewState.Item("nm_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("calculo_produtor", txt_cd_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("calculo_produtor", txt_cd_propriedade.ID)
            txt_cd_propriedade.Text = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("calculo_produtor", lbl_nm_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_propriedade") = customPage.getFilterValue("calculo_produtor", lbl_nm_propriedade.ID)
            lbl_nm_propriedade.Text = ViewState.Item("nm_propriedade").ToString()
        Else
            ViewState.Item("nm_propriedade") = String.Empty
        End If

        If Not (customPage.getFilterValue("calculo_produtor", hf_id_pessoa.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_pessoa") = customPage.getFilterValue("calculo_produtor", hf_id_pessoa.ID)
            hf_id_pessoa.Value = ViewState.Item("id_pessoa").ToString()
        Else
            ViewState.Item("id_pessoa") = String.Empty
        End If

        If Not (customPage.getFilterValue("calculo_produtor", txt_dt_referencia.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("dt_referencia") = customPage.getFilterValue("calculo_produtor", txt_dt_referencia.ID)
            txt_dt_referencia.Text = ViewState.Item("dt_referencia").ToString()
        Else
            ViewState.Item("dt_referencia") = String.Empty
        End If

        If Not (customPage.getFilterValue("calculo_produtor", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("calculo_produtor", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("calculo_produtor")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim calculoprodutor As New CalculoProdutor

            calculoprodutor.id_estabelecimento = Convert.ToInt32(ViewState.Item("id_estabelecimento").ToString)
            If Trim(ViewState.Item("id_pessoa")) <> "" Then
                calculoprodutor.id_pessoa = ViewState.Item("id_pessoa").ToString
            End If
            If Trim(ViewState.Item("id_propriedade")) <> "" Then
                calculoprodutor.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade").ToString)
            End If
            calculoprodutor.id_selecao = ViewState.Item("id_selecao")

            Dim dsCalculoProdutor As DataSet = calculoprodutor.getCalculoAdiantamentoByFilters()

            If (dsCalculoProdutor.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsCalculoProdutor.Tables(0), ViewState.Item("sortExpression"))
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


            Case "ds_propriedade"
                If (ViewState.Item("sortExpression")) = "ds_propriedade asc" Then
                    ViewState.Item("sortExpression") = "ds_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "ds_propriedade asc"
                End If


        End Select

        loadData()

    End Sub
    Private Sub carregarCamposProdutor()

        Try

            If Not (customPage.getFilterValue("lupa_produtor", "nm_pessoa").Equals(String.Empty)) Then
                Me.lbl_nm_pessoa.Text = customPage.getFilterValue("lupa_produtor", "nm_pessoa").ToString
            End If

            If Not (customPage.getFilterValue("lupa_produtor", "cd_pessoa").Equals(String.Empty)) Then
                Me.txt_cd_pessoa.Text = customPage.getFilterValue("lupa_produtor", "cd_pessoa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_produtor")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub saveFilters()

        Try


            customPage.setFilter("calculo_produtor", cbo_estabelecimento.ID, ViewState.Item("id_estabelecimento").ToString)
            customPage.setFilter("calculo_produtor", txt_cd_pessoa.ID, ViewState.Item("cd_pessoa").ToString)
            customPage.setFilter("calculo_produtor", lbl_nm_pessoa.ID, lbl_nm_pessoa.Text)
            customPage.setFilter("calculo_produtor", txt_cd_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("calculo_produtor", hf_id_pessoa.ID, ViewState.Item("id_pessoa").ToString)
            customPage.setFilter("calculo_produtor", lbl_nm_propriedade.ID, ViewState.Item("nm_propriedade").ToString)
            customPage.setFilter("calculo_produtor", txt_dt_referencia.ID, ViewState.Item("dt_referencia").ToString)
            customPage.setFilter("calculo_produtor", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Function saveCheckBox() As Boolean

        Try

            Dim li As Integer

            For li = 0 To gridResults.Rows.Count - 1
                Dim calculoprodutor As New CalculoProdutor()
                calculoprodutor.id_calculo_produtor = gridResults.DataKeys(li).Value.ToString
                If CType(gridResults.Rows(li).FindControl("ck_item"), CheckBox).Checked() Then
                    calculoprodutor.st_selecao = "1"
                    saveCheckBox = True     ' Indica que tem alguma propriedade selecionada para o cálculo
                Else
                    calculoprodutor.st_selecao = "0"
                End If
                calculoprodutor.updateCalculoAdiantamento()
            Next


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                'saveFilters()
                'Response.Redirect("frm_conta_parcelada.aspx?id_conta_parcelada=" + e.CommandArgument.ToString())

            Case "delete"
                'deleteContaParcelada(Convert.ToInt32(e.CommandArgument.ToString()))


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

    Protected Sub cbo_estabelecimento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_estabelecimento.SelectedIndexChanged
        Me.lbl_nm_pessoa.Text = ""
        Me.txt_cd_pessoa.Text = ""
        Me.hf_id_pessoa.Value = ""
        Me.lbl_nm_pessoa.Visible = False
    End Sub

    Protected Sub img_lupa_produtor_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles img_lupa_produtor.Click
        Me.lbl_nm_pessoa.Visible = True
        carregarCamposProdutor()

    End Sub

    Protected Sub txt_cd_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_propriedade.TextChanged

    End Sub

    Protected Sub txt_cd_pessoa_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_cd_pessoa.TextChanged
        lbl_nm_pessoa.Text = ""
        lbl_nm_pessoa.Visible = False

    End Sub

    Protected Sub lk_calcular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_calcular.Click
        Try

            saveFilters()
            If saveCheckBox() = True Then
                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 6 'PROCESSO
                usuariolog.id_menu_item = 43
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f

                Response.Redirect("frm_calculo_produtor.aspx?id_selecao=" + ViewState.Item("id_selecao").ToString + "&tp_pagamento=Q" + "&dt_referencia=" + ViewState.Item("dt_referencia").ToString + "&id_estabelecimento=" + ViewState.Item("id_estabelecimento").ToString)
            Else
                messageControl.Alert("Nenhum registro foi selecionado para o cálculo. Por favor selecione alguma propriedade.")
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

            ' 13/01/2009  -  Seleciona tudo o que o botão Pesquisar trouxe - i
            Dim calculoprodutor As New CalculoProdutor
            calculoprodutor.id_selecao = ViewState.Item("id_selecao")
            If ck_header.Checked = True Then
                calculoprodutor.st_selecao = "1"
            Else
                calculoprodutor.st_selecao = "0"
            End If
            calculoprodutor.updateCalculoAdiantamentoTodos()
            ' 13/01/2009  -  Seleciona tudo o que o botão Pesquisar trouxe - f


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
End Class
