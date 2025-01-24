Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_tipo_equipamento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        If Not (txt_cd_tipo_equipamento.Text.Trim().Equals(String.Empty)) Then
            ViewState.Item("id_tipo_equipamento") = txt_cd_tipo_equipamento.Text.Trim()
        Else
            ViewState.Item("id_tipo_equipamento") = String.Empty
        End If
        ViewState.Item("nm_tipo_equipamento") = txt_nm_tipo_equipamento.Text.Trim()
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_tipo_equipamento.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_silo.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 86
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 


            loadDetails()
        End If
    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao


            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ViewState.Item("sortExpression") = "nm_tipo_equipamento asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        If Not (customPage.getFilterValue("tipoequip", txt_cd_tipo_equipamento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("cd_tipo_equipamento") = customPage.getFilterValue("tipoequip", txt_cd_tipo_equipamento.ID)
            txt_cd_tipo_equipamento.Text = ViewState.Item("cd_tipo_equipamento").ToString()
        Else
            ViewState.Item("cd_tipo_equipamento") = String.Empty
        End If

        If Not (customPage.getFilterValue("tipoequip", txt_nm_tipo_equipamento.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("nm_tipo_equipamento") = customPage.getFilterValue("tipoequip", txt_nm_tipo_equipamento.ID)
            txt_nm_tipo_equipamento.Text = ViewState.Item("nm_tipo_equipamento").ToString()
        Else
            ViewState.Item("nm_tipo_equipamento") = String.Empty
        End If



        If Not (customPage.getFilterValue("tipoequip", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("tipoequip", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("tipoequip", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("tipoequip", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            loadData()
            customPage.clearFilters("tipoequip")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim tpequipamento As New TipoEquipamento

            If Not (ViewState("cd_tipo_equipamento").ToString().Equals(String.Empty)) Then
                tpequipamento.cd_tipo_equipamento = Convert.ToInt32(ViewState.Item("cd_tipo_equipamento"))
            End If
            tpequipamento.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())
            tpequipamento.nm_tipo_equipamento = ViewState.Item("nm_tipo_equipamento").ToString()

            Dim dsEquipamento As DataSet = tpequipamento.getTiposEquipamentosByFilters()

            If (dsEquipamento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsEquipamento.Tables(0), ViewState.Item("sortExpression"))
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


    Protected Sub gridResults_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gridResults.Sorting

        Select Case e.SortExpression.ToLower()


            Case "cd_tipo_equipamento"
                If (ViewState.Item("sortExpression")) = "cd_tipo_equipamento asc" Then
                    ViewState.Item("sortExpression") = "cd_tipo_equipamento desc"
                Else
                    ViewState.Item("sortExpression") = "cd_tipo_equipamento asc"
                End If


            Case "nm_tipo_equipamento"
                If (ViewState.Item("sortExpression")) = "nm_tipo_equipamento asc" Then
                    ViewState.Item("sortExpression") = "nm_tipo_equipamento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_tipo_equipamento asc"
                End If
            Case "nm_situacao"
                If (ViewState.Item("sortExpression")) = "nm_situacao asc" Then
                    ViewState.Item("sortExpression") = "nm_situacao desc"
                Else
                    ViewState.Item("sortExpression") = "nm_situacao asc"
                End If

        End Select

        loadData()

    End Sub

    Private Sub saveFilters()

        Try

            customPage.setFilter("tipoequip", txt_cd_tipo_equipamento.ID, ViewState.Item("cd_tipo_equipamento").ToString)
            customPage.setFilter("tipoequip", txt_nm_tipo_equipamento.ID, ViewState.Item("nm_tipo_equipamento").ToString)
            customPage.setFilter("tipoequip", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)
            customPage.setFilter("tipoequip", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_tipo_equipamento.aspx?id_tipo_equipamento=" + e.CommandArgument.ToString())

            Case "delete"
                deleteTipoEquipamento(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteTipoEquipamento(ByVal id_tipo_equipamento As Integer)

        Try
            Dim veiculo As New Veiculo
            veiculo.id_tipo_equipamento = id_tipo_equipamento
            veiculo.id_situacao = 1
            'Se não encontrou veiculos para o euipamento... deixa desativar
            If veiculo.getVeiculoByTipoEquipamento = 0 Then
                Dim tipoequipamento As New TipoEquipamento()
                tipoequipamento.id_tipo_equipamento = id_tipo_equipamento
                tipoequipamento.id_modificador = Convert.ToInt32(Session("id_login"))
                tipoequipamento.deleteTipoEquipamento()

                'FRAN 08/12/2020 i incluir log 
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 5 'delecao
                usuariolog.id_menu_item = 86
                usuariolog.insertUsuarioLog()
                'FRAN 08/12/2020  incluir log 

                messageControl.Alert("Registro desativado com sucesso!")
                loadData()
            Else 'se há veiculos relacionados a este tipo de equipamento, não deixa desativar.
                messageControl.Alert("Há veículos ativos relacionados com este Tipo de Equipamento. O registro não pode ser desativado!")
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_tipo_equipamento.aspx")
    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub
End Class
