Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_compartimento
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        'Fran 16/02/2009 i - Rls 16
        'If (txt_placa.Text.Trim().Equals(String.Empty)) Then
        'messageControl.Alert("A placa do Veículo deve ser informada. Por favor tente novamente.")
        'Else
        'ViewState.Item("nr_compartimento") = txt_nr_compartimento.Text.Trim()
        'ViewState.Item("nm_compartimento") = txt_nm_compartimento.Text.Trim()
        'ViewState.Item("ds_placa") = txt_placa.Text.Trim()
        'ViewState.Item("id_veiculo") = hf_id_veiculo.Value.ToString
        'ViewState.Item("id_situacao") = cbo_situacao.SelectedValue
        'loadData()
        'End If

        ViewState.Item("ds_placa") = lbl_placa.Text.Trim()
        ViewState.Item("id_veiculo") = lbl_id_veiculo.Text.Trim()
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()
        'Fran 16/02/2009 f

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_compartimento.aspx?id_veiculo=" + ViewState.Item("id_veiculo").Value.ToString + "&st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_compartimento.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 8
                usuariolog.ds_nm_processo = "Veículo - Compartimentos"
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
        'With bt_lupa_veiculo
        '    .Attributes.Add("onclick", "javascript:ShowDialog()")
        '    .ToolTip = "Filtrar Veículos"
        '    '.Style("cursor") = "hand"
        'End With

    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao


            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.Insert(0, New ListItem("[Selecione]", "0"))

            ViewState.Item("sortExpression") = "nr_compartimento asc"

            'FRAN 08/12/2020 i incluir log 
            If Not Page.IsPostBack Then
                If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                    Dim usuariolog As New UsuarioLog
                    usuariolog.id_usuario = Session("id_login")
                    usuariolog.ds_id_session = Session.SessionID.ToString()
                    usuariolog.id_tipo_log = 2 'ACESSO
                    usuariolog.ds_nm_processo = "Compartimento"
                    usuariolog.insertUsuarioLog()
                End If
            End If
            'FRAN 08/12/2020  incluir log 

            'Fran 16/02/2009 i rls 16
            'loadFilters()
            If Not (Request("id_veiculo") Is Nothing) Then
                ViewState.Item("id_veiculo") = Request("id_veiculo")
                Dim veiculo As New Veiculo(Convert.ToInt32(ViewState.Item("id_veiculo")))
                ViewState.Item("ds_placa") = veiculo.ds_placa.ToString
                ViewState.Item("id_situacao") = 0
                lbl_id_veiculo.Text = ViewState.Item("id_veiculo")
                lbl_placa.Text = ViewState.Item("ds_placa")
                loadData()
            Else
                loadFilters()
            End If
            'Fran 16/02/2009 f rls 16



        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean

        'Fran 16/02/2008 i Rls 16
        'If Not (customPage.getFilterValue("compartimento", txt_nr_compartimento.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("nr_compartimento") = customPage.getFilterValue("compartimento", txt_nr_compartimento.ID)
        '    txt_nr_compartimento.Text = ViewState.Item("nr_compartimento").ToString()
        'Else
        '    ViewState.Item("nr_compartimento") = String.Empty
        'End If

        'If Not (customPage.getFilterValue("compartimento", txt_nm_compartimento.ID).Equals(String.Empty)) Then
        '    hasFilters = True
        '    ViewState.Item("nm_compartimento") = customPage.getFilterValue("compartimento", txt_nm_compartimento.ID)
        '    txt_nm_compartimento.Text = ViewState.Item("nm_compartimento").ToString()
        'Else
        '    ViewState.Item("nm_compartimento") = String.Empty
        'End If
        'Fran 16/02/2008 f Rls 16

        If Not (customPage.getFilterValue("compartimento", "ds_placa").Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("ds_placa") = customPage.getFilterValue("compartimento", "ds_placa")
            lbl_placa.Text = ViewState.Item("ds_placa").ToString()
        Else
            ViewState.Item("ds_placa") = String.Empty
        End If

        If Not (customPage.getFilterValue("compartimento", lbl_id_veiculo.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_veiculo") = customPage.getFilterValue("compartimento", lbl_id_veiculo.ID)
            lbl_id_veiculo.Text = ViewState.Item("id_veiculo").ToString()
        Else
            ViewState.Item("id_veiculo") = String.Empty
        End If


        If Not (customPage.getFilterValue("compartimento", cbo_situacao.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_situacao") = customPage.getFilterValue("compartimento", cbo_situacao.ID)
            cbo_situacao.Text = ViewState.Item("id_situacao").ToString()
        Else
            ViewState.Item("id_situacao") = String.Empty
        End If


        If Not (customPage.getFilterValue("compartimento", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("compartimento", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If

        If (hasFilters) Then
            '16/02/2009 rls 16
            'loadData()
            customPage.clearFilters("compartimento")
        End If

        loadData()

    End Sub

    Private Sub loadData()

        Try
            Dim compartimento As New Compartimento

            'Fran 16/02/2009 i rls16
            'If Not (ViewState.Item("nr_compartimento").ToString.Equals(String.Empty)) Then
            '    compartimento.nr_compartimento = Convert.ToInt32(ViewState.Item("nr_compartimento").ToString())
            'End If
            'compartimento.nm_compartimento = ViewState.Item("nm_compartimento").ToString()
            'Fran 16/02/2009 f
            compartimento.ds_placa = ViewState.Item("ds_placa").ToString()
            If Not (ViewState.Item("id_veiculo").ToString.Equals(String.Empty)) Then
                compartimento.id_veiculo = ViewState.Item("id_veiculo").ToString()
            End If
            compartimento.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao").ToString())

            Dim dsCompartimento As DataSet = compartimento.getCompartimentoByFilters()

            If (dsCompartimento.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsCompartimento.Tables(0), ViewState.Item("sortExpression"))
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


            Case "nr_compartimento"
                If (ViewState.Item("sortExpression")) = "nr_compartimento asc" Then
                    ViewState.Item("sortExpression") = "nr_compartimento desc"
                Else
                    ViewState.Item("sortExpression") = "nr_compartimento asc"
                End If


            Case "nm_compartimento"
                If (ViewState.Item("sortExpression")) = "nm_compartimento asc" Then
                    ViewState.Item("sortExpression") = "nm_compartimento desc"
                Else
                    ViewState.Item("sortExpression") = "nm_compartimento asc"
                End If

        End Select

        loadData()

    End Sub
    Private Sub carregarCamposVeiculo()

        Try

            If Not (customPage.getFilterValue("lupa_veiculo", "ds_placa").Equals(String.Empty)) Then
                Me.txt_placa.Text = customPage.getFilterValue("lupa_veiculo", "ds_placa").ToString
            End If

            'loadData()
            customPage.clearFilters("lupa_veiculo")


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub saveFilters()

        Try

            'Fran 16/02/2009 i 
            'customPage.setFilter("compartimento", txt_nr_compartimento.ID, ViewState.Item("nr_compartimento").ToString)
            'customPage.setFilter("compartimento", txt_nm_compartimento.ID, ViewState.Item("nm_compartimento").ToString)
            'customPage.setFilter("compartimento", txt_placa.ID, ViewState.Item("ds_placa").ToString)
            'customPage.setFilter("compartimento", hf_id_veiculo.ID, ViewState.Item("id_veiculo").ToString)
            customPage.setFilter("compartimento", "ds_placa", ViewState.Item("ds_placa").ToString)
            customPage.setFilter("compartimento", lbl_id_veiculo.ID, ViewState.Item("id_veiculo").ToString)
            'Fran 16/02/2009 f
            customPage.setFilter("compartimento", cbo_situacao.ID, ViewState.Item("id_situacao").ToString)

            customPage.setFilter("compartimento", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        Select Case e.CommandName.ToString().ToLower()

            Case "edit"
                saveFilters()
                Response.Redirect("frm_compartimento.aspx?id_compartimento=" + e.CommandArgument.ToString())

            Case "delete"
                deleteCompartimento(Convert.ToInt32(e.CommandArgument.ToString()))

        End Select

    End Sub

    Private Sub deleteCompartimento(ByVal id_compartimento As Integer)

        Try

            Dim compartimento As New Compartimento()
            compartimento.id_compartimento = id_compartimento
            compartimento.id_modificador = Convert.ToInt32(Session("id_login"))
            compartimento.deleteCompartimento()

            'FRAN 08/12/2020 i incluir log 
            Dim usuariolog As New UsuarioLog
            usuariolog.id_usuario = Session("id_login")
            usuariolog.ds_id_session = Session.SessionID.ToString()
            usuariolog.id_tipo_log = 5 'Deleção
            usuariolog.id_menu_item = 8
            usuariolog.ds_nm_processo = "Veículo - Compartimento"
            usuariolog.insertUsuarioLog()
            'FRAN 08/12/2020  incluir log 

            messageControl.Alert("Registro desativado com sucesso!")
            loadData()

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub


    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        saveFilters()
        Response.Redirect("frm_compartimento.aspx")
    End Sub

    Protected Sub gridResults_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowDataBound
    End Sub

    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Protected Sub bt_lupa_veiculo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles bt_lupa_veiculo.Click

        carregarCamposVeiculo()

    End Sub

    'Fran 16/02/2009 i rls16
    Protected Sub lk_voltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_voltar.Click
        Response.Redirect("frm_veiculo.aspx?id_veiculo=" + ViewState.Item("id_veiculo").ToString)

    End Sub
End Class
