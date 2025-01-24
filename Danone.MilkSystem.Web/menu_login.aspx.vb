Imports System.Data
Imports Danone.MilkSystem.Business


Partial Class menu_login
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "")
        loadData()

    End Sub


    Private Sub loadMenuItem(ByVal __node As TreeNode, ByVal id_menu As Int32)


        Dim li_item As Int32

        Dim menuitem As New MenuItem
        menuitem.id_usuario = Convert.ToInt32(Session("id_login"))
        menuitem.id_menu = id_menu
        menuitem.id_grupo = ViewState.Item("id_grupo")
        'Dim dsMenuItem As DataSet = menuitem.getMenuItemByFilters()
        Dim dsMenuItem As DataSet = menuitem.getLoginMenuItemByFilters()  ' 29/10/2008

        For li_item = 0 To dsMenuItem.Tables(0).Rows.Count - 1

            Dim node As New TreeNode()

            node.Text = dsMenuItem.Tables(0).Rows(li_item).Item("nm_menu_item")
            node.NavigateUrl = dsMenuItem.Tables(0).Rows(li_item).Item("ds_navigateurl").ToString().Trim()
            node.Target = "mainFrame"
            node.SelectAction = TreeNodeSelectAction.Select

            'node.Value = dsMenuItem.Tables(0).Rows(li_item).Item("id_menu_item")
            'If Not IsDBNull(dsMenuItem.Tables(0).Rows(li_item).Item("id_tipo_acesso")) Then
            '    node.Target = dsMenuItem.Tables(0).Rows(li_item).Item("id_tipo_acesso")
            '    node.Text = dsMenuItem.Tables(0).Rows(li_item).Item("nm_menu_item") & " (" & dsMenuItem.Tables(0).Rows(li_item).Item("nm_tipo_acesso") & ")"
            '    If dsMenuItem.Tables(0).Rows(li_item).Item("id_tipo_acesso") = 3 Then  ' Se controle total
            '        node.ImageUrl = "img/icon_status_verde.gif"
            '    Else
            '        node.ImageUrl = "img/icon_status_vermelho.gif"
            '    End If
            'Else
            '    node.Target = ""
            '    node.Text = dsMenuItem.Tables(0).Rows(li_item).Item("nm_menu_item") & " (Acesso Negado)"
            '    node.ImageUrl = "img/icon_status_vermelho.gif"  ' Acesso negado
            'End If


            'If Not (dsMenuItem.Tables(0).Rows(li_item).Item("ds_navigateurl").ToString().Trim().Equals(String.Empty)) Then
            '    node.NavigateUrl = dsMenuItem.Tables(0).Rows(li_item).Item("ds_navigateurl").ToString().Trim()
            'End If

            ''node.SelectAction = TreeNodeSelectAction.Expand

            'If (node.NavigateUrl.Equals(String.Empty)) Then
            '    node.SelectAction = TreeNodeSelectAction.Expand
            'Else
            '    node.SelectAction = TreeNodeSelectAction.Select
            'End If

            __node.ChildNodes.Add(node)

        Next

    End Sub


    Private Sub loadData()

        Try

            Dim li As Int32

            treeMenu.Nodes.Clear()


            'Dim nodeRoot As New TreeNode()
            'nodeRoot.Text = "Evolution"
            'nodeRoot.Value = "0"
            'nodeRoot.SelectAction = TreeNodeSelectAction.Expand


            Dim menu As New Menu()
            menu.id_usuario = Convert.ToInt32(Session("id_login"))
            Dim dsMenu As DataSet = menu.getLoginMenuByFilters()



            For li = 0 To dsMenu.Tables(0).Rows.Count - 1

                Dim node As New TreeNode()

                node.Text = dsMenu.Tables(0).Rows(li).Item("nm_menu")

                node.Target = "mainFrame"
                node.Value = dsMenu.Tables(0).Rows(li).Item("id_menu")
                'node.NavigateUrl = dsMenu.Tables(0).Rows(li).Item("ds_navigateURL")

                node.SelectAction = TreeNodeSelectAction.None
                'If (node.NavigateUrl.Equals(String.Empty)) Then
                '    node.SelectAction = TreeNodeSelectAction.Expand
                'End If

                loadMenuItem(node, dsMenu.Tables(0).Rows(li).Item("id_menu"))
                'nodeRoot.ChildNodes.Add(node)
                treeMenu.Nodes.Add(node)


            Next

            'treeMenu.Nodes.Add(nodeRoot)


        Catch ex As Exception
            MenuTools.errorHandler(Me, ex)
        End Try


    End Sub




End Class
