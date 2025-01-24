Imports Danone.MilkSystem.Business
Imports System.Data
Partial Class frm_grupo_acessos
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "frm_grupo_acessos.aspx")
        If Not Page.IsPostBack Then
            loadDetails()
        End If
    End Sub

    Private Sub loadDetails()

        Try



            Dim tipoacesso As New TipoAcesso

            cbo_tipo_acesso.DataSource = tipoacesso.getTipoAcessosByFilters
            cbo_tipo_acesso.DataTextField = "nm_tipo_acesso"
            cbo_tipo_acesso.DataValueField = "id_tipo_acesso"
            cbo_tipo_acesso.DataBind()
            cbo_tipo_acesso.Items.Insert(0, New ListItem("[Selecione]", String.Empty))


            If Not (Request("id_grupo") Is Nothing) Then
                ViewState.Item("id_grupo") = Request("id_grupo")
                loadData()
            End If


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub




    Private Sub loadData()

        Try

            Dim id_grupo As Int32 = Convert.ToInt32(ViewState.Item("id_grupo"))
            Dim grupo As New GrupoCadastro(id_grupo)

            lbl_nm_grupo.Text = grupo.nm_grupo

            'If (grupoacesso.id_tipo_acesso > 0) Then
            '    cbo_tipo_acesso.SelectedValue = Grupo.id_tipo_acesso.ToString()
            'End If


            'lbl_modificador.Text = grupo.id_modificador.ToString()
            'lbl_dt_modificacao.Text = grupo.dt_modificacao.ToString()

            loadTreeMenu()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try


    End Sub
    Private Sub loadTreeMenu()

        Try
            Dim li As Int32

            TreeMenu.Nodes.Clear()


            Dim nodeRoot As New TreeNode()
            nodeRoot.Text = "Evolution"
            nodeRoot.Value = "0"
            nodeRoot.SelectAction = TreeNodeSelectAction.Expand


            Dim menu As New Menu
            Dim dsMenu As DataSet = menu.getMenuByFilters()



            For li = 0 To dsMenu.Tables(0).Rows.Count - 1

                Dim node As New TreeNode()

                node.Text = dsMenu.Tables(0).Rows(li).Item("nm_menu")

                node.Target = "mainFrame"
                node.Value = dsMenu.Tables(0).Rows(li).Item("id_menu")

                node.SelectAction = TreeNodeSelectAction.Expand
                'If (node.NavigateUrl.Equals(String.Empty)) Then
                '    node.SelectAction = TreeNodeSelectAction.Expand
                'End If

                loadMenuItem(node, dsMenu.Tables(0).Rows(li).Item("id_menu"))
                nodeRoot.ChildNodes.Add(node)


            Next

            TreeMenu.Nodes.Add(nodeRoot)



        Catch ex As Exception
            MenuTools.errorHandler(Me, ex)
        End Try


    End Sub
    Private Sub loadMenuItem(ByVal __node As TreeNode, ByVal id_menu As Int32)

        Dim li_item As Int32

        Dim menuitem As New MenuItem
        menuitem.id_menu = id_menu
        menuitem.id_grupo = ViewState.Item("id_grupo")
        Dim dsMenuItem As DataSet = menuitem.getMenuItemByFilters()

        For li_item = 0 To dsMenuItem.Tables(0).Rows.Count - 1

            Dim node As New TreeNode()

            node.Value = dsMenuItem.Tables(0).Rows(li_item).Item("id_menu_item")
            If Not IsDBNull(dsMenuItem.Tables(0).Rows(li_item).Item("id_tipo_acesso")) Then
                node.Target = dsMenuItem.Tables(0).Rows(li_item).Item("id_tipo_acesso")
                node.Text = dsMenuItem.Tables(0).Rows(li_item).Item("nm_menu_item") & " (" & dsMenuItem.Tables(0).Rows(li_item).Item("nm_tipo_acesso") & ")"
                If dsMenuItem.Tables(0).Rows(li_item).Item("id_tipo_acesso") = 3 Then  ' Se controle total
                    node.ImageUrl = "img/icon_status_verde.gif"
                Else
                    node.ImageUrl = "img/icon_status_vermelho.gif"
                End If
            Else
                node.Target = ""
                node.Text = dsMenuItem.Tables(0).Rows(li_item).Item("nm_menu_item") & " (Acesso Negado)"
                node.ImageUrl = "img/icon_status_vermelho.gif"  ' Acesso negado
            End If


            'If Not (dsMenuItem.Tables(0).Rows(li_item).Item("ds_navigateurl").ToString().Trim().Equals(String.Empty)) Then
            '    node.NavigateUrl = dsMenuItem.Tables(0).Rows(li_item).Item("ds_navigateurl").ToString().Trim()
            'End If

            'node.SelectAction = TreeNodeSelectAction.Expand

            If (node.NavigateUrl.Equals(String.Empty)) Then
                node.SelectAction = TreeNodeSelectAction.Expand
            Else
                node.SelectAction = TreeNodeSelectAction.Select
            End If

            __node.ChildNodes.Add(node)

        Next

    End Sub

    Private Sub updateData()

        Try
            Dim i As Int32
            Dim texto As String
            Dim grupoacesso As New GrupoAcesso

            i = 0
            For Each node As TreeNode In TreeMenu.Nodes ' Sistema
                If node.Checked = True Then  ' Selecionou todo o sistema

                    For Each nodemenu As TreeNode In node.ChildNodes   ' Menus
                        texto = nodemenu.Text
                        For Each nodechild As TreeNode In nodemenu.ChildNodes
                            grupoacesso.menuitem.Add(Convert.ToInt32(nodechild.Value))
                            i = i + 1
                        Next
                    Next

                Else

                    For Each nodemenu As TreeNode In node.ChildNodes   ' Menus
                        texto = nodemenu.Text
                        If nodemenu.Checked = True Then
                            For Each nodechild As TreeNode In nodemenu.ChildNodes
                                grupoacesso.menuitem.Add(Convert.ToInt32(nodechild.Value))
                                i = i + 1
                            Next

                        Else
                            For Each nodechild As TreeNode In nodemenu.ChildNodes
                                If nodechild.Checked = True Then
                                    grupoacesso.menuitem.Add(Convert.ToInt32(nodechild.Value))
                                    i = i + 1
                                End If
                            Next
                        End If
                    Next
                End If
            Next

            If i > 0 Then  'Se selecionou alguem
                grupoacesso.id_grupo = ViewState.Item("id_grupo")
                grupoacesso.id_tipo_acesso = cbo_tipo_acesso.SelectedValue
                grupoacesso.id_modificador = Session("id_login")
                grupoacesso.updateGrupoAcesso()
                'fran 08/12/2020 i dango
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 3 'alteração
                usuariolog.id_menu_item = 59
                usuariolog.ds_nm_processo = "Grupo - Acessos do Grupo"
                usuariolog.insertUsuarioLog()
                'fran 08/12/2020 f dango

                messageControl.Alert("Acessos do Grupo atualizados com sucesso.")
                loadTreeMenu()
            Else
                messageControl.Alert("Selecione algum menu ou item de menu para atualização.")
            End If



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_grupo.aspx?id_grupo=" + ViewState.Item("id_grupo").ToString)
    End Sub

    Protected Sub lk_voltarFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltarFooter.Click
        Response.Redirect("frm_grupo.aspx?id_grupo=" + ViewState.Item("id_grupo").ToString)
    End Sub



    Protected Sub lk_concluir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluir.Click
        updateData()
    End Sub

    Protected Sub lk_concluirFooter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_concluirFooter.Click
        updateData()
    End Sub


    Public Sub New()

    End Sub

    Protected Sub TreeMenu_TreeNodeCheckChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.TreeNodeEventArgs) Handles TreeMenu.TreeNodeCheckChanged
        'For Each node As TreeNode In TreeMenu.Nodes ' Sistema
        '    If node.Checked = True Then  ' Selecionou todo o sistema
        '        For Each nodemenu As TreeNode In node.ChildNodes   ' Menus
        '            nodemenu.Checked = True
        '            For Each nodechild As TreeNode In nodemenu.ChildNodes
        '                nodechild.Checked = True
        '            Next
        '        Next
        '    Else

        '        For Each nodemenu As TreeNode In node.ChildNodes   ' Menus
        '            If nodemenu.Checked = True Then
        '                For Each nodechild As TreeNode In nodemenu.ChildNodes
        '                    nodechild.Checked = True
        '                Next
        '            End If
        '        Next
        '    End If
        'Next

    End Sub

    Protected Sub cbo_tipo_acesso_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbo_tipo_acesso.SelectedIndexChanged

    End Sub

    Protected Sub TreeMenu_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeMenu.SelectedNodeChanged

    End Sub
End Class
