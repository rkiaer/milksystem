Imports Danone.MilkSystem.Business
Imports System.Data



Partial Class lst_grupo_pool_compras_produtor
    Inherits Page

    Private customPage As RK.PageTools.CustomPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        customPage = MenuTools.getInitialContext(HttpContext.Current, "")
        If Not Page.IsPostBack Then
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

            ViewState.Item("sortExpression") = "nm_grupo_pool_compras asc"

            If Not (Request("id_pessoa") Is Nothing) Then
                ViewState.Item("id_pessoa") = Request("id_pessoa")
                loadData()
            Else
                ' Adriana 14/06/2010 - chamado 868 - i
                If Not (Request("id_propriedade") Is Nothing) Then
                    ViewState.Item("id_propriedade") = Request("id_propriedade")
                    Dim propriedade As New Propriedade(Convert.ToInt32(ViewState.Item("id_propriedade")))
                    ViewState.Item("id_pessoa") = propriedade.id_pessoa
                    loadData()
                Else
                    ' Adriana 14/06/2010 - chamado 868 - f
                    messageControl.Alert("Há problemas na passagem de parâmetros. A tela não pode ser montada!")
                End If
            End If

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Private Sub loadData()

        Try
            Dim pessoa As New Pessoa(Convert.ToInt32(ViewState.Item("id_pessoa").ToString()))
            cbo_estabelecimento.Enabled = True
            cbo_estabelecimento.SelectedValue = pessoa.id_estabelecimento
            cbo_estabelecimento.Enabled = False
            lbl_produtor.Text = String.Concat(pessoa.cd_pessoa, " - ", pessoa.nm_pessoa)

            Dim grupopoolcompras As New GrupoPoolCompras
            grupopoolcompras.id_pessoa = Convert.ToInt32(ViewState.Item("id_pessoa").ToString())

            Dim dsgrupopoolcompras As DataSet = grupopoolcompras.getGrupoPoolComprasbyPessoa()

            If (dsgrupopoolcompras.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsgrupopoolcompras.Tables(0), ViewState.Item("sortExpression"))
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
        Me.loadData()

    End Sub


    Protected Sub gridResults_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles gridResults.SelectedIndexChanging
        gridResults.PageIndex = e.NewSelectedIndex
        loadData()
    End Sub


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "cd_grupo_pool_compras"
                If ViewState.Item("sortExpression") = "cd_grupo_pool_compras asc" Then
                    ViewState.Item("sortExpression") = "cd_grupo_pool_compras desc"
                Else
                    ViewState.Item("sortExpression") = "cd_grupo_pool_compras asc"
                End If

            Case "nm_grupo_pool_compras"
                If ViewState.Item("sortExpression") = "nm_grupo_pool_compras asc" Then
                    ViewState.Item("sortExpression") = "nm_grupo_pool_compras desc"
                Else
                    ViewState.Item("sortExpression") = "nm_grupo_pool_compras asc"
                End If
            Case "cd_pessoa"
                If ViewState.Item("sortExpression") = "cd_pessoa asc" Then
                    ViewState.Item("sortExpression") = "cd_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "cd_pessoa asc"
                End If

            Case "nm_pessoa"
                If ViewState.Item("sortExpression") = "nm_pessoa asc" Then
                    ViewState.Item("sortExpression") = "nm_pessoa desc"
                Else
                    ViewState.Item("sortExpression") = "nm_pessoa asc"
                End If


            Case "id_propriedade"
                If ViewState.Item("sortExpression") = "id_propriedade asc" Then
                    ViewState.Item("sortExpression") = "id_propriedade desc"
                Else
                    ViewState.Item("sortExpression") = "id_propriedade asc"
                End If

        End Select

        loadData()

    End Sub


End Class
