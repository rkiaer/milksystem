Imports Danone.MilkSystem.Business
Imports System.Data

Partial Class frm_grupo_pool_compras_propriedade
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_grupo_pool_compras_propriedade.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With

    End Sub

    Private Sub loadDetails()

        Try

            ' 04/11/2009 Adri - i
            'Dim grupopoolcompras As New GrupoPoolCompras

            'cbo_grupo_pool_compras.DataSource = grupopoolcompras.getGrupos_pool_comprasByFilters
            'cbo_grupo_pool_compras.DataTextField = "cd_grupo_pool_compras"
            'cbo_grupo_pool_compras.DataValueField = "id_grupo_pool_compras"
            'cbo_grupo_pool_compras.DataBind()
            'cbo_grupo_pool_compras.Items.Insert(0, New ListItem("[Selecione]", "0"))  
            ' 04/11/2009 Adri - f

            ViewState.Item("sortExpression") = "nm_abreviado asc"  ' 20/01/2010 - Chamado 600

            ' 04/11/2009 Adri - i
            If Not (Request("id_grupo_pool_compras") Is Nothing) Then
                ViewState.Item("id_grupo_pool_compras") = Request("id_grupo_pool_compras")
                'cbo_grupo_pool_compras.SelectedValue = Convert.ToInt32(ViewState.Item("id_grupo_pool_compras"))

                'gridpropriedade.Enabled = True 'Fran chamado 904 - não há mais grid de PROPRIEDADE i
                'cbo_grupo_pool_compras.Enabled = False
                loadData()
                loadgrupo()
            End If
            ' 04/11/2009 Adri - f

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub

    Private Sub loadgrupo()
        Try
            Dim GrupoPoolComprasPropriedade As New GrupoPoolComprasPropriedade()

            'If cbo_grupo_pool_compras.SelectedValue > 0 Then
            '    GrupoPoolComprasPropriedade.id_grupo_pool_compras = cbo_grupo_pool_compras.SelectedValue
            'End If
            GrupoPoolComprasPropriedade.id_grupo_pool_compras = Convert.ToInt32(ViewState.Item("id_grupo_pool_compras"))
            GrupoPoolComprasPropriedade.id_situacao = 1  ' Somente os ativos
            Dim dsgrupo_pool_compras_propriedade As DataSet = GrupoPoolComprasPropriedade.getGrupos_pool_comprasByFilters

            If (dsgrupo_pool_compras_propriedade.Tables(0).Rows.Count > 0) Then
                gridpropriedade_grupo.Visible = True
                gridpropriedade_grupo.DataSource = Helper.getDataView(dsgrupo_pool_compras_propriedade.Tables(0), ViewState.Item("sortExpressionGrupo"))
                gridpropriedade_grupo.DataBind()
            Else
                gridpropriedade_grupo.Visible = False
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub
    Private Sub loadData()

        Try
            'Fran chamado 904 - não há mais grid de PROPRIEDADE i
            ''Carrega grid das propriedades
            'Dim propriedade As New Propriedade
            'Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters
            'Fran chamado 904 - não há mais grid de PROPRIEDADE f

            ' 04/11/2009 - Adri - i
            Dim id_Grupo_Pool_Compras As Int32 = Convert.ToInt32(ViewState.Item("id_grupo_pool_compras"))
            Dim grupopoolcompras As New GrupoPoolCompras(id_Grupo_Pool_Compras)
            lbl_cd_grupo_pool_compras.Text = grupopoolcompras.cd_grupo_pool_compras
            lbl_ds_grupo_pool_compras.Text = grupopoolcompras.nm_grupo_pool_compras
            ' 04/11/2009 - Adri - f

            'Fran chamado 904 - não há mais grid de PROPRIEDADE i
            'If (dspropriedade.Tables(0).Rows.Count > 0) Then
            '    gridpropriedade.Visible = True
            '    gridpropriedade.DataSource = Helper.getDataView(dspropriedade.Tables(0), ViewState.Item("sortExpression"))
            '    gridpropriedade.DataBind()
            'Else
            '    gridpropriedade.Visible = False
            '    messageControl.Alert("Nenhum registro foi encontrado. Por favor tente novamente.")
            'End If
            'Fran chamado 904 - não há mais grid de PROPRIEDADE f
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    'Protected Sub cbo_grupo_pool_compras_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_grupo_pool_compras.SelectedIndexChanged

    '    Dim id_Grupo_Pool_Compras As Int32 = cbo_grupo_pool_compras.SelectedValue
    '    Dim grupopoolcompras As New GrupoPoolCompras(id_Grupo_Pool_Compras)
    '    lbl_ds_grupo_pool_compras.Text = grupopoolcompras.nm_grupo_pool_compras

    '    If cbo_grupo_pool_compras.SelectedValue = 0 Then
    '        lbl_ds_grupo_pool_compras.Text = ""
    '        gridpropriedade.Enabled = False
    '        gridpropriedade_grupo.Visible = False
    '    Else
    '        gridpropriedade.Enabled = True
    '        loadgrupo()
    '    End If
    'End Sub
    'Fran chamado 904 - não há mais grid de PROPRIEDADE i
    'Protected Sub gridpropriedade_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridpropriedade.PageIndexChanging
    '    gridpropriedade.PageIndex = e.NewPageIndex
    '    Me.loadData()
    'End Sub
    'Fran chamado 904 - não há mais grid de PROPRIEDADE f

    Protected Sub gridpropriedade_grupo_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridpropriedade_grupo.PageIndexChanging
        gridpropriedade_grupo.PageIndex = e.NewPageIndex
        Me.loadgrupo()
    End Sub

    'Fran chamado 904 - não há mais grid de PROPRIEDADE i

    'Protected Sub gridpropriedade_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridpropriedade.RowCommand
    '    Select Case e.CommandName.Trim.ToString
    '        Case "Insert"
    '            Dim id_index As Int32 = Convert.ToInt32(e.CommandArgument.ToString())
    '            Dim ds_grupo As DataSet

    '            Dim grupo_pool_compras_propriedade As New GrupoPoolComprasPropriedade

    '            Dim lbl_id_propriedade As Label = CType(gridpropriedade.Rows.Item(id_index).FindControl("lbl_id_propriedade"), Label)
    '            grupo_pool_compras_propriedade.id_propriedade = Convert.ToInt32(lbl_id_propriedade.Text)
    '            'grupo_pool_compras_propriedade.id_grupo_pool_compras = cbo_grupo_pool_compras.SelectedValue
    '            grupo_pool_compras_propriedade.id_grupo_pool_compras = Convert.ToInt32(ViewState.Item("id_grupo_pool_compras"))

    '            ds_grupo = grupo_pool_compras_propriedade.getGrupos_pool_comprasByFilters()

    '            If ds_grupo.Tables(0).Rows.Count > 0 Then
    '                grupo_pool_compras_propriedade.id_grupo_pool_compras_propriedade = ds_grupo.Tables(0).Rows(0).Item("id_grupo_pool_compras_propriedade")
    '            End If

    '            ViewState.Item("grupo_pool_compras_propriedade") = grupo_pool_compras_propriedade.id_grupo_pool_compras_propriedade

    '            If ViewState.Item("grupo_pool_compras_propriedade") <> 0 Then
    '                Dim grupo_pool_compras_propriedades As New GrupoPoolComprasPropriedade(Convert.ToInt32(ViewState.Item("grupo_pool_compras_propriedade")))
    '                grupo_pool_compras_propriedades.id_situacao = 1
    '                grupo_pool_compras_propriedades.updategrupo_pool_compras()
    '            Else
    '                ViewState.Item("grupo_pool_compras_propriedade") = grupo_pool_compras_propriedade.insertgrupo_pool_compras()
    '            End If

    '            loadgrupo()



    '    End Select
    'End Sub
    'Fran chamado 904 - não há mais grid de PROPRIEDADE f

    Protected Sub gridpropriedade_grupo_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridpropriedade_grupo.RowCommand
        Select Case e.CommandName.Trim.ToString
            Case "Delete"
                Dim id_index As Int32 = Convert.ToInt32(e.CommandArgument.ToString())
                Dim lbl_id_grupo_pool_compras_propriedade As Label = CType(gridpropriedade_grupo.Rows.Item(id_index).FindControl("lbl_id_grupo_pool_compras_propriedade"), Label)
                Dim grupo_pool_compras_propriedade As New GrupoPoolComprasPropriedade(Convert.ToInt32(lbl_id_grupo_pool_compras_propriedade.Text))
                grupo_pool_compras_propriedade.id_situacao = 2
                grupo_pool_compras_propriedade.updategrupo_pool_compras()
                loadgrupo()
        End Select
    End Sub
    'Fran chamado 904 - não há mais grid de PROPRIEDADE i
    'Protected Sub gridpropriedade_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridpropriedade.RowCreated
    '    If (e.Row.RowType = DataControlRowType.DataRow) Then
    '        Dim btn_adicionar As ImageButton = CType(e.Row.FindControl("btn_adicionar"), ImageButton)
    '        btn_adicionar.CommandArgument = e.Row.RowIndex
    '    End If
    'End Sub
    'Fran chamado 904 - não há mais grid de PROPRIEDADE f


    Protected Sub gridpropriedade_grupo_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridpropriedade_grupo.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim btn_retirar As ImageButton = CType(e.Row.FindControl("btn_retirar"), ImageButton)
            btn_retirar.CommandArgument = e.Row.RowIndex
        End If
    End Sub
 
    
    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_grupo_pool_compras.aspx?id_grupo_pool_compras=" + ViewState.Item("id_grupo_pool_compras").ToString())  ' Adri 04/11/2009 
    End Sub

    Protected Sub gridpropriedade_grupo_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridpropriedade_grupo.RowDeleting
        e.Cancel = True  ' 04/11/2009 Adri
    End Sub

    'Fran chamado 904 - não há mais grid de PROPRIEDADE i
    'Protected Sub gridpropriedade_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridpropriedade.Sorting
    '    Select Case e.SortExpression.ToLower()

    '        ' 20/01/2010 - Chamado 600  - i
    '        Case "id_propriedade"
    '            If (ViewState.Item("sortExpression")) = "id_propriedade asc" Then
    '                ViewState.Item("sortExpression") = "id_propriedade desc"
    '            Else
    '                ViewState.Item("sortExpression") = "id_propriedade asc"
    '            End If

    '        Case "cd_pessoa"
    '            If (ViewState.Item("sortExpression")) = "cd_pessoa asc" Then
    '                ViewState.Item("sortExpression") = "cd_pessoa desc"
    '            Else
    '                ViewState.Item("sortExpression") = "cd_pessoa asc"
    '            End If

    '        Case "nm_abreviado"
    '            If (ViewState.Item("sortExpression")) = "nm_abreviado asc" Then
    '                ViewState.Item("sortExpression") = "nm_abreviado desc"
    '            Else
    '                ViewState.Item("sortExpression") = "nm_abreviado asc"
    '            End If

    '        Case "id_linha_par"
    '            If (ViewState.Item("sortExpression")) = "id_linha_par asc" Then
    '                ViewState.Item("sortExpression") = "id_linha_par desc"
    '            Else
    '                ViewState.Item("sortExpression") = "id_linha_par asc"
    '            End If

    '        Case "id_linha_impar"
    '            If (ViewState.Item("sortExpression")) = "id_linha_impar asc" Then
    '                ViewState.Item("sortExpression") = "id_linha_impar desc"
    '            Else
    '                ViewState.Item("sortExpression") = "id_linha_impar asc"
    '            End If
    '            ' 20/01/2010 - Chamado 600  - f

    '    End Select

    '    loadData()

    'End Sub
    'Fran chamado 904 - não há mais grid de PROPRIEDADE f

    Protected Sub btn_nova_propriedade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_nova_propriedade.Click
        'Fran chamado 904 - não há mais grid de PROPRIEDADE i
        If Page.IsValid Then

            Try

                Dim ds_grupo As DataSet

                Dim grupo_pool_compras_propriedade As New GrupoPoolComprasPropriedade
                grupo_pool_compras_propriedade.id_propriedade = Convert.ToInt32(txt_id_propriedade.Text)
                grupo_pool_compras_propriedade.id_grupo_pool_compras = Convert.ToInt32(ViewState.Item("id_grupo_pool_compras"))
                ds_grupo = grupo_pool_compras_propriedade.getGrupos_pool_comprasByFilters()

                If ds_grupo.Tables(0).Rows.Count > 0 Then
                    grupo_pool_compras_propriedade.id_grupo_pool_compras_propriedade = ds_grupo.Tables(0).Rows(0).Item("id_grupo_pool_compras_propriedade")
                End If
                'ViewState.Item("grupo_pool_compras_propriedade") = grupo_pool_compras_propriedade.id_grupo_pool_compras_propriedade
                If grupo_pool_compras_propriedade.id_grupo_pool_compras_propriedade > 0 Then
                    Dim grupo_pool_compras_propriedades As New GrupoPoolComprasPropriedade(Convert.ToInt32(ViewState.Item("grupo_pool_compras_propriedade")))
                    grupo_pool_compras_propriedades.id_situacao = 1
                    grupo_pool_compras_propriedades.updategrupo_pool_compras()
                Else
                    grupo_pool_compras_propriedade.insertgrupo_pool_compras()
                End If

                loadgrupo()
            Catch ex As Exception
                messageControl.Alert(ex.Message)
            End Try
            'Fran chamado 904 - não há mais grid de PROPRIEDADE f

        End If
    End Sub
    Private Sub carregarCamposPropriedade()

        Try



            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                Me.txt_id_propriedade.Text = Me.hf_id_propriedade.Value.ToString
                Me.lbl_nm_propriedade.Visible = True
                Me.lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If


            'If Not (customPage.getFilterValue("lupa_propriedade", "pessoa").Equals(String.Empty)) Then
            '    Me.lbl_produtor.Visible = True
            '    Me.lbl_nm_produtor.Visible = True
            '    Me.lbl_nm_produtor.Text = customPage.getFilterValue("lupa_propriedade", "pessoa").ToString
            'End If


            'loadData()
            customPage.clearFilters("lupa_propriedade")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        carregarCamposPropriedade()

    End Sub

    Protected Sub txt_id_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_propriedade.TextChanged
        lbl_nm_propriedade.Text = String.Empty
        lbl_nm_propriedade.Visible = True
        hf_id_propriedade.Value = String.Empty

        If Not txt_id_propriedade.Text.Equals(String.Empty) Then
            Dim propriedade As New Propriedade
            propriedade.id_propriedade = Convert.ToInt32(Me.txt_id_propriedade.Text.Trim)
            propriedade.id_situacao = 1
            Dim dspropriedade As DataSet = propriedade.getPropriedadeByFilters
            'se encontrou propriedade
            If dspropriedade.Tables(0).Rows.Count > 0 Then
                lbl_nm_propriedade.Enabled = True
                lbl_nm_propriedade.Text = dspropriedade.Tables(0).Rows(0).Item("nm_propriedade")
                hf_id_propriedade.Value = dspropriedade.Tables(0).Rows(0).Item("id_propriedade")
            End If

        End If

    End Sub

    Protected Sub cv_propriedade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv_propriedade.ServerValidate
        Try
            Dim lmsg As String

            args.IsValid = True
            If Not hf_id_propriedade.Value.Equals(String.Empty) Then
                args.IsValid = True
            Else
                args.IsValid = False
                lmsg = "O propriedade deve ser válida para adicioná-la."
            End If
            If args.IsValid = False Then
                messageControl.Alert(lmsg)
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
End Class
