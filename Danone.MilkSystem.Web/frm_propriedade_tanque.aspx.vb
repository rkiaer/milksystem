Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_propriedade_tanque
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_propriedade_tanque.aspx")
        If Not Page.IsPostBack Then
            loaddetails()
        End If
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With
    End Sub
    Private Sub loadDetails()
        If Not (Request("id_propriedade") Is Nothing) Then
            ViewState.Item("id_propriedade") = Request("id_propriedade")
            ViewState.Item("nr_unid_producao") = Request("nr_unid_producao")
            loadData()
        Else
            Dim proparceira As New PropriedadeTanque
            proparceira.id_propriedade = -1
            Dim dspropparceira As DataSet = proparceira.getPropriedadesParceiras()
            Dim dr As DataRow = dspropparceira.Tables(0).NewRow()
            dspropparceira.Tables(0).Rows.InsertAt(dr, 0)
            gridResults.Visible = True
            gridResults.DataSource = Helper.getDataView(dspropparceira.Tables(0), ViewState.Item("sortExpression"))
            gridResults.DataBind()
            gridResults.Rows(0).Cells.Clear()
            gridResults.Rows(0).Cells.Add(New TableCell())
            gridResults.Rows(0).Attributes.CssStyle.Add("text-align", "center")
            gridResults.Rows(0).Cells(0).Text = "Informe a propriedade e a unidade de produção proprietárias e adicione as propriedades parceiras."
            gridResults.Rows(0).Cells(0).ColumnSpan = 7
            ViewState.Item("id_propriedade") = 0
            ViewState.Item("id_unidade_producao") = 0

        End If
    End Sub
    Private Sub loadData()

        Try
            Dim propriedade As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade")))

            txt_id_propriedade.Text = ViewState.Item("id_propriedade")
            txt_id_propriedade.Enabled = False
            btn_lupa_propriedade.Visible = False
            lbl_nm_propriedade.Enabled = True
            lbl_nm_propriedade.Text = propriedade.nm_propriedade
            lbl_ds_produtor.Text = String.Concat(propriedade.cd_pessoa.ToString, " - ", propriedade.nm_pessoa.ToString) 'fran 28/12/2009 i chamado 593
            loadUnidProducaobyPropriedade()
            If Not (ViewState.Item("id_unidade_producao")) Is Nothing Then
                cbo_unid_producao.SelectedValue = ViewState.Item("id_unidade_producao").ToString
            Else
                cbo_unid_producao.SelectedValue = cbo_unid_producao.Items.FindByText(ViewState.Item("nr_unid_producao").Trim.ToString).Value
                ViewState.Item("id_unidade_producao") = cbo_unid_producao.SelectedValue

            End If

            cbo_unid_producao.Enabled = False

            loadGridParceiros()
            btn_adicionar.Enabled = True


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub gridResults_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridResults.PageIndexChanging
        gridResults.PageIndex = e.NewPageIndex
        'Me.loadData()
        loadGridParceiros()
    End Sub


    Protected Sub gridResults_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gridResults.RowCancelingEdit
        Try

            gridResults.EditIndex = -1
            ViewState.Item("incluirlinha") = "N"
            '            loadData()
            loadGridParceiros()
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Delete"
                deletepropparc(Convert.ToInt32(e.CommandArgument.ToString()))

            Case "Lupa"
                carregarcamposprop_parc(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select
    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                Dim btn_lupa_parc As Anthem.ImageButton = CType(e.Row.FindControl("btn_lupa_parc"), Anthem.ImageButton)
                Dim txt_id_prop_parc As Anthem.TextBox = CType(e.Row.FindControl("txt_id_prop_parc"), Anthem.TextBox)
                Dim cbo_up_parceiro As Anthem.DropDownList = CType(e.Row.FindControl("cbo_up_parceiro"), Anthem.DropDownList)
                Dim cbo_situacao As Anthem.DropDownList = CType(e.Row.FindControl("cbo_situacao"), Anthem.DropDownList)


                If ViewState.Item("incluirlinha") = "S" Then
                    If e.Row.RowIndex = 0 Then
                        ViewState.Item("labelsituacao") = ""
                        ViewState.Item("labelupparceiro") = ""
                    End If
                End If

                If ViewState.Item("incluirlinha") = "S" Then
                    btn_lupa_parc.Enabled = True
                    txt_id_prop_parc.Enabled = True
                    cbo_up_parceiro.Enabled = True
                    btn_lupa_parc.CommandArgument = e.Row.RowIndex.ToString
                    With btn_lupa_parc
                        .Attributes.Add("onclick", "javascript:ShowDialogPropParc()")
                        .ToolTip = "Filtrar Propriedades Parceiras"
                    End With
                Else
                    btn_lupa_parc.Visible = False
                    txt_id_prop_parc.Enabled = False
                    cbo_up_parceiro.Enabled = False
                End If

                If Not (ViewState.Item("incluirlinha") = "S") Then
                    Dim unidadeproducao As New UnidadeProducao(Convert.ToInt32(ViewState.Item("lbl_prop_parc")))
                    cbo_up_parceiro.DataSource = unidadeproducao.getUnidadeProducaoByFilters()
                    cbo_up_parceiro.DataTextField = "nr_unid_producao"
                    cbo_up_parceiro.DataValueField = "id_unid_producao"
                    cbo_up_parceiro.DataBind()
                    cbo_up_parceiro.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                End If

                Dim situacao As New Situacao

                cbo_situacao.DataSource = situacao.getSituacoesByFilters
                cbo_situacao.DataTextField = "nm_situacao"
                cbo_situacao.DataValueField = "id_situacao"
                cbo_situacao.DataBind()

                If Not (ViewState.Item("labelsituacao") Is Nothing) Then
                    If (ViewState.Item("labelsituacao").ToString.Equals(String.Empty)) Then
                        cbo_situacao.SelectedValue = 1 'ativo
                        ViewState.Item("labelsituacao") = Nothing
                    Else
                        cbo_situacao.SelectedValue = cbo_situacao.Items.FindByText(ViewState.Item("labelsituacao").Trim.ToString).Value
                        ViewState.Item("labelsituacao") = Nothing
                    End If

                End If
                If Not (ViewState.Item("labelupparceiro") Is Nothing) Then
                    If (ViewState.Item("labelupparceiro").ToString.Equals(String.Empty)) Then
                        cbo_up_parceiro.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                        ViewState.Item("labelupparceiro") = "SEM_VALOR"
                    Else
                        cbo_up_parceiro.SelectedValue = cbo_up_parceiro.Items.FindByText(ViewState.Item("labelupparceiro").Trim.ToString).Value
                        ViewState.Item("labelupparceiro") = Nothing
                    End If

                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try

        End If
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow AndAlso (e.Row.RowState = (DataControlRowState.Alternate Or DataControlRowState.Edit) OrElse e.Row.RowState = (DataControlRowState.Normal Or DataControlRowState.Edit)) Then
            Try
                Dim cbo_up_parceiro As Anthem.DropDownList = CType(e.Row.FindControl("cbo_up_parceiro"), Anthem.DropDownList)

                If ViewState.Item("labelupparceiro") = "SEM_VALOR" Then
                    'Se já fez a criação  da linha e esta sem valor no combo , força o 'Selecione'
                    If Not (cbo_up_parceiro Is Nothing) Then
                        cbo_up_parceiro.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
                    End If
                    ViewState.Item("labelupparceiro") = Nothing

                End If


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
        End If
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub btn_proriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        carregarcampospropriedade()
        'carrega combo unid produção
        loadUnidProducaobyPropriedade()
        loadProdutorbyPropriedadeProprietaria() 'Fran 28/12/2009 chamado 593
        loadGridParceiros()

    End Sub
    Private Sub carregarcampospropriedade()
        Try

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If
            If Not hf_id_propriedade.Value = "" Then
                txt_id_propriedade.Text = hf_id_propriedade.Value
                ViewState.Item("id_propriedade") = txt_id_propriedade.Text
            End If

            customPage.clearFilters("lupa_propriedade")

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cmv_propriedade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_propriedade.ServerValidate
        Try
            Dim propriedade As New Propriedade()

            propriedade.id_propriedade = Convert.ToInt32(txt_id_propriedade.Text)
            args.IsValid = propriedade.validarPropriedade
            If Not args.IsValid Then
                messageControl.Alert("Propriedade não cadastrada.")
                btn_adicionar.Enabled = False
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub btn_adicionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_adicionar.Click

        If ViewState.Item("incluirlinha") = "S" Then
            messageControl.Alert("Existem dados da Propriedade Parceira pendentes para a gravação. Salve-os ou cancele a operação através dos botões à direita dos dados.")
        Else
            'ViewState.Item("salvarlinha") = "S"
            ViewState.Item("incluirlinha") = "S"
            Dim PropriedadeTanque As New PropriedadeTanque
            PropriedadeTanque.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            PropriedadeTanque.id_unid_producao = Convert.ToInt32(ViewState.Item("id_unidade_producao"))
            Dim dspropriedade As DataSet = PropriedadeTanque.getPropriedadesParceiras
            Dim dr As DataRow = dspropriedade.Tables(0).NewRow()
            dspropriedade.Tables(0).Rows.InsertAt(dr, 0)
            gridResults.Visible = True
            gridResults.DataSource = Helper.getDataView(dspropriedade.Tables(0), ViewState.Item("sortExpression"))
            gridResults.EditIndex = 0
            gridResults.DataBind()
        End If
    End Sub

    Protected Sub txt_id_prop_parc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        Dim txt_id_prop_parc As Anthem.TextBox = CType(row.FindControl("txt_id_prop_parc"), Anthem.TextBox)
        Dim lbl_nm_prop_parc As Label = CType(row.FindControl("lbl_nm_prop_parc"), Label)
        Dim cbo_up_parceiro As Anthem.DropDownList = CType(row.FindControl("cbo_up_parceiro"), Anthem.DropDownList)

        Dim dspropriedade As DataSet
        lbl_nm_prop_parc.Text = String.Empty
        'cbo_up_parceiro = Nothing
        'se propriedade é valida
        If Not txt_id_prop_parc.Text.Equals(String.Empty) Then
            dspropriedade = validarPropriedade(CLng(txt_id_prop_parc.Text))
            If dspropriedade.Tables(0).Rows.Count > 0 Then
                hf_id_prop_parc.Value = txt_id_prop_parc.Text
                ViewState.Item("id_prop_parc") = hf_id_prop_parc.Value
                lbl_nm_prop_parc.Text = dspropriedade.Tables(0).Rows(0).Item("nm_propriedade").ToString

                Dim up As New UnidadeProducao
                up.id_propriedade = Convert.ToInt32(ViewState.Item("id_prop_parc"))
                cbo_up_parceiro.DataSource = up.getUnidadeProducaoByFilters
                cbo_up_parceiro.DataTextField = "nr_unid_producao"
                cbo_up_parceiro.DataValueField = "id_unid_producao"
                cbo_up_parceiro.DataBind()
                cbo_up_parceiro.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            Else
                ViewState.Item("id_prop_parc") = 0
                hf_id_prop_parc.Value = 0
                lbl_nm_prop_parc.Text = String.Empty
            End If

        End If

    End Sub

    Protected Sub btn_lupa_parc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim wc As WebControl = CType(sender, WebControl)
        Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
        carregarcamposprop_parc(row.RowIndex)

    End Sub

    Protected Sub gridResults_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gridResults.RowEditing
        Try
            If ViewState.Item("incluirlinha") = "S" And e.NewEditIndex = 0 Then
                ViewState.Item("incluirlinha") = "S"
                loadData()
            Else
                Dim lbl_situacao As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_situacao"), Label)
                Dim lbl_up_parceiro As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_up_parceiro"), Label)
                Dim lbl_prop_parc As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_prop_parc"), Label)
                Dim lbl_id_propriedade_tanque As Label = CType(gridResults.Rows(e.NewEditIndex).FindControl("lbl_id_propriedade_tanque"), Label)

                ViewState.Item("labelsituacao") = Trim(lbl_situacao.Text)
                ViewState.Item("labelupparceiro") = Trim(lbl_up_parceiro.Text)
                ViewState.Item("id_prop_parc") = Trim(lbl_prop_parc.Text)
                ViewState.Item("id_propriedade_tanque") = Trim(lbl_id_propriedade_tanque.Text)
                gridResults.EditIndex = e.NewEditIndex

                loadData()
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub carregarcamposprop_parc(ByVal id_index_row As Int32)
        Try
            Dim txt_id_prop_parc As Anthem.TextBox = CType(gridResults.Rows(id_index_row).FindControl("txt_id_prop_parc"), Anthem.TextBox)
            Dim lbl_nm_prop_parc As Label = CType(gridResults.Rows(id_index_row).FindControl("lbl_nm_prop_parc"), Label)
            Dim cbo_up_parceiro As Anthem.DropDownList = CType(gridResults.Rows(id_index_row).FindControl("cbo_up_parceiro"), Anthem.DropDownList)

            txt_id_prop_parc.Text = hf_id_prop_parc.Value
            ViewState.Item("id_prop_parc") = hf_id_prop_parc.Value

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                lbl_nm_prop_parc.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If

            Dim up As New UnidadeProducao
            up.id_propriedade = Convert.ToInt32(ViewState.Item("id_prop_parc"))
            cbo_up_parceiro.DataSource = up.getUnidadeProducaoByFilters
            cbo_up_parceiro.DataTextField = "nr_unid_producao"
            cbo_up_parceiro.DataValueField = "id_unid_producao"
            cbo_up_parceiro.DataBind()
            cbo_up_parceiro.Items.Insert(0, New ListItem("[Selecione]", String.Empty))

            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub


    Protected Sub gridResults_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gridResults.RowUpdating
        Dim row As GridViewRow = gridResults.Rows(e.RowIndex)
        Try
            If Page.IsValid Then



                Dim PropriedadeTanque As New PropriedadeTanque

                Dim cbo_up_parceiro As Anthem.DropDownList = CType(row.FindControl("cbo_up_parceiro"), Anthem.DropDownList)
                Dim txt_id_prop_parc As TextBox = CType(row.FindControl("txt_id_prop_parc"), TextBox)
                Dim cbo_situacao As Anthem.DropDownList = CType(row.FindControl("cbo_situacao"), Anthem.DropDownList)


                If (Not (row) Is Nothing) Then

                    PropriedadeTanque.id_propriedade = Convert.ToInt32(txt_id_propriedade.Text)
                    PropriedadeTanque.id_unid_producao = Convert.ToInt32(cbo_unid_producao.SelectedValue)
                    PropriedadeTanque.id_propriedade_parceira = Convert.ToInt32(txt_id_prop_parc.Text)
                    PropriedadeTanque.id_unid_producao_parceira = Convert.ToInt32(cbo_up_parceiro.SelectedValue)
                    PropriedadeTanque.id_situacao = Convert.ToInt32(cbo_situacao.SelectedValue)
                    PropriedadeTanque.id_modificador = Session("id_login")


                    If ViewState.Item("incluirlinha") = "S" Then
                        If txt_id_prop_parc.Text = txt_id_propriedade.Text Then
                            messageControl.Alert("Não é possível adicionar esta propriedade")
                            ViewState.Item("incluirlinha") = Nothing
                        Else
                            PropriedadeTanque.insertPropriedadeTanque()
                            ViewState.Item("incluirlinha") = Nothing
                        End If
                    Else
                        PropriedadeTanque.id_propriedade_tanque = Convert.ToInt32(ViewState.Item("id_propriedade_tanque"))
                        PropriedadeTanque.updatePropriedadeTanque()
                    End If

                        gridResults.EditIndex = -1
                        loadData()
                    End If

                End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub
    Private Sub deletepropparc(ByVal id_propriedade_tanque As Int32)
        Try
            Try

                Dim proparceiro As New PropriedadeTanque

                proparceiro.id_propriedade_tanque = id_propriedade_tanque
                proparceiro.id_modificador = Session("id_login")
                proparceiro.deletePropriedadeTanque()
                messageControl.Alert("Registro excluído com sucesso!")
                loadGridParceiros()


            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub



    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("lst_propriedade_tanque.aspx")
    End Sub

    Protected Sub cmv_propriedade_parceiro_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try
            Dim wc As WebControl = CType(source, WebControl)
            Dim row As GridViewRow = CType(wc.NamingContainer, GridViewRow)
            Dim txt_id_prop_parc As Anthem.TextBox = CType(row.FindControl("txt_id_prop_parc"), Anthem.TextBox)
            args.IsValid = True

            If txt_id_prop_parc.Text = txt_id_propriedade.Text Then
                args.IsValid = False
            End If

            If Not args.IsValid Then
                messageControl.Alert("A propriedade selecionada não pode ser a propriedade proprietária.")
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub txt_id_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_propriedade.TextChanged
        Dim dspropriedade As DataSet
        lbl_nm_propriedade.Text = String.Empty
        lbl_nm_propriedade.Visible = False
        hf_id_propriedade.Value = String.Empty
        ViewState.Item("id_propriedade") = 0
        'cbo_unid_producao = Nothing
        'se propriedade é valida
        If Not txt_id_propriedade.Text.Equals(String.Empty) Then
            dspropriedade = validarPropriedade(CLng(txt_id_propriedade.Text))
            If dspropriedade.Tables(0).Rows.Count > 0 Then
                ViewState.Item("id_propriedade") = txt_id_propriedade.Text.Trim
                hf_id_propriedade.Value = txt_id_propriedade.Text.Trim
                lbl_nm_propriedade.Enabled = True
                lbl_nm_propriedade.Text = dspropriedade.Tables(0).Rows(0).Item("nm_propriedade").ToString
                loadUnidProducaobyPropriedade()
                loadProdutorbyPropriedadeProprietaria() 'Fran 28/12/2009 chamado 593
            End If

        End If

    End Sub
    Private Function validarPropriedade(ByVal id_propriedade As Int32) As DataSet

        Try

            Dim propriedade As New Propriedade()

            propriedade.id_propriedade = id_propriedade
            validarPropriedade = propriedade.getPropriedadeByFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Function
    Private Sub loadUnidProducaobyPropriedade()

        Try
            If Not txt_id_propriedade.Text = "" Then
                Dim up As New UnidadeProducao
                up.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                cbo_unid_producao.DataSource = up.getUnidadeProducaoByFilters
                cbo_unid_producao.DataTextField = "nr_unid_producao"
                cbo_unid_producao.DataValueField = "id_unid_producao"
                cbo_unid_producao.DataBind()
                cbo_unid_producao.Items.Insert(0, New ListItem("[Selecione]", String.Empty))
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadProdutorbyPropriedadeProprietaria() 'Fran 28/12/2009 chamado 593

        Try
            If Not txt_id_propriedade.Text = "" Then
                Dim propriedade As New Propriedade
                propriedade.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters
                If dspropriedade.Tables(0).Rows.Count > 0 Then
                    lbl_ds_produtor.Text = dspropriedade.Tables(0).Rows(0).Item("pessoa").ToString
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Protected Sub cbo_unid_producao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_unid_producao.SelectedIndexChanged
        ViewState.Item("id_unidade_producao") = cbo_unid_producao.SelectedValue
        loadGridParceiros()
    End Sub
    Private Sub loadGridParceiros()

        Try

            If ViewState.Item("id_propriedade") Is Nothing Then
                ViewState.Item("id_propriedade") = 0
            End If
            If ViewState.Item("id_unidade_producao") Is Nothing Then
                ViewState.Item("id_unidade_producao") = 0
            End If
            'Carrega os dados do Grid
            Dim propparceiros As New PropriedadeTanque
            If CLng(ViewState.Item("id_propriedade")) > 0 And CLng(ViewState.Item("id_unidade_producao")) > 0 Then
                propparceiros.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
                propparceiros.id_unid_producao = Convert.ToInt32(ViewState.Item("id_unidade_producao"))

                Dim dspropriedade As DataSet = propparceiros.getPropriedadesParceiras

                If (dspropriedade.Tables(0).Rows.Count > 0) Then
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dspropriedade.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                    cbo_unid_producao.Enabled = False
                    txt_id_propriedade.Enabled = False
                    btn_lupa_propriedade.Visible = False
                Else
                    Dim dr As DataRow = dspropriedade.Tables(0).NewRow()
                    dspropriedade.Tables(0).Rows.InsertAt(dr, 0)
                    gridResults.Visible = True
                    gridResults.DataSource = Helper.getDataView(dspropriedade.Tables(0), ViewState.Item("sortExpression"))
                    gridResults.DataBind()
                    gridResults.Rows(0).Cells.Clear()
                    gridResults.Rows(0).Cells.Add(New TableCell())
                    gridResults.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                    gridResults.Rows(0).Cells(0).Text = "Não existe ainda nenhum parceiro de tanque informado para a Propriedade/UP selecionada!"
                    gridResults.Rows(0).Cells(0).ColumnSpan = 7

                End If
            Else
                propparceiros.id_propriedade = -1
                Dim dsparceiros As DataSet = propparceiros.getPropriedadesParceiras()
                Dim dr As DataRow = dsparceiros.Tables(0).NewRow()
                dsparceiros.Tables(0).Rows.InsertAt(dr, 0)
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsparceiros.Tables(0), ViewState.Item("sortExpression"))
                gridResults.DataBind()
                gridResults.Rows(0).Cells.Clear()
                gridResults.Rows(0).Cells.Add(New TableCell())
                gridResults.Rows(0).Attributes.CssStyle.Add("text-align", "center")
                gridResults.Rows(0).Cells(0).Text = "Informe a propriedade e a unidade de produção proprietárias e adicione as propriedades parceiras."
                gridResults.Rows(0).Cells(0).ColumnSpan = 7
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_propriedade_tanque.aspx")
    End Sub

    Protected Sub lk_novo_footer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo_footer.Click
        Response.Redirect("frm_propriedade_tanque.aspx")
    End Sub

    Protected Sub btn_gravar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

    End Sub
End Class
