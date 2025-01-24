Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_propriedade_tanque
    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click
        ViewState.Item("id_propriedade") = txt_id_propriedade.Text
        ViewState.Item("id_situacao") = cbo_situacao.SelectedValue

        loadData()

    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_propriedade_tanque.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_propriedade_tanque.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 109
                usuariolog.insertUsuarioLog()
            End If
            'FRAN 08/12/2020  incluir log 

            loadDetails()
        End If
        With btn_lupa_propriedade
            .Attributes.Add("onclick", "javascript:ShowDialogPropriedade()")
            .ToolTip = "Filtrar Propriedades"
        End With
    End Sub


    Private Sub loadDetails()

        Try

            Dim status As New Situacao


            cbo_situacao.DataSource = status.getSituacoesByFilters()
            cbo_situacao.DataTextField = "nm_situacao"
            cbo_situacao.DataValueField = "id_situacao"
            cbo_situacao.DataBind()
            cbo_situacao.Items.FindByValue("1").Selected = True
            ViewState.Item("id_situacao") = Me.cbo_situacao.SelectedValue.ToString


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadData()

        Try
            Dim PropriedadeTanque As New PropriedadeTanque

            PropriedadeTanque.id_situacao = Convert.ToInt32(ViewState.Item("id_situacao"))
            If Not ViewState.Item("id_propriedade").Equals(String.Empty) Then
                PropriedadeTanque.id_propriedade = Convert.ToInt32(ViewState.Item("id_propriedade"))
            End If
            Dim dspropriedade As DataSet = PropriedadeTanque.getPropriedadesParceiras

            If (dspropriedade.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dspropriedade.Tables(0), ViewState.Item("sortExpression"))
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
    Protected Sub lk_novo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lk_novo.Click
        Response.Redirect("frm_propriedade_tanque.aspx")
    End Sub

    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand
       
        Select Case e.CommandName.ToString().ToLower()
            Case "edit"
                Dim id_index As Int32 = Convert.ToInt32(e.CommandArgument.ToString())
                Dim lbl_up As Label = CType(gridResults.Rows.Item(id_index).FindControl("lbl_up"), Label)
                Dim lbl_id_prop As Label = CType(gridResults.Rows.Item(id_index).FindControl("lbl_id_prop"), Label)

                Response.Redirect("frm_propriedade_tanque.aspx?id_propriedade=" + lbl_id_prop.Text.ToString + "&nr_unid_producao=" + lbl_up.Text.ToString)

        End Select
    End Sub

    Protected Sub gridResults_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridResults.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            Dim btneditar As ImageButton = CType(e.Row.FindControl("btneditar"), ImageButton)
            btneditar.CommandArgument = e.Row.RowIndex.ToString
        End If
    End Sub


    Protected Sub gridResults_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gridResults.RowDeleting
        e.Cancel = True
    End Sub

    Private Sub carregarcampospropriedade()
        Try

            If Not (customPage.getFilterValue("lupa_propriedade", "nm_propriedade").Equals(String.Empty)) Then
                lbl_nm_propriedade.Text = customPage.getFilterValue("lupa_propriedade", "nm_propriedade").ToString
            End If
            txt_id_propriedade.Text = hf_id_propriedade.Value
            customPage.clearFilters("lupa_propriedade")

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub cmv_propriedade_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cmv_propriedade.ServerValidate
        Try
            Dim propriedade As New Propriedade
            If Not txt_id_propriedade.Text.Trim.Equals(String.Empty) Then
                propriedade.id_propriedade = Convert.ToInt32(txt_id_propriedade.Text)
                args.IsValid = propriedade.validarPropriedade
                If Not args.IsValid Then
                    messageControl.Alert("Propriedade não cadastrada.")
                End If
            End If
        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try
    End Sub

    Protected Sub btn_lupa_proriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        carregarcampospropriedade()
    End Sub

    Protected Sub txt_id_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_propriedade.TextChanged
        lbl_nm_propriedade.Text = String.Empty
        hf_id_propriedade.Value = 0

    End Sub
End Class
