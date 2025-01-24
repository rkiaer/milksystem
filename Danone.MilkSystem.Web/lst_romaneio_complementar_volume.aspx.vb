Imports Danone.MilkSystem.Business
Imports System.Data


Partial Class lst_romaneio_complementar_volume

    Inherits Page

    Private customPage As RK.PageTools.CustomPage

    Protected Sub btn_pesquisa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_pesquisa.Click

        Dim lberro As Boolean = False

        ViewState.Item("id_romaneio") = txt_id_romaneio.Text.Trim()
        ViewState.Item("id_propriedade") = txt_id_propriedade.Text

        loadData()



    End Sub

    Protected Sub btn_limparFiltros_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_limparFiltros.Click

        Response.Redirect("lst_romaneio_complementar_volume.aspx?st_incluirlog=N")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        customPage = MenuTools.getInitialContext(HttpContext.Current, "lst_romaneio_complementar_volume.aspx")
        If Not Page.IsPostBack Then
            'FRAN 08/12/2020 i incluir log 
            If (Request("st_incluirlog") Is Nothing) Then 'se nao tem parametro
                Dim usuariolog As New UsuarioLog
                usuariolog.id_usuario = Session("id_login")
                usuariolog.ds_id_session = Session.SessionID.ToString()
                usuariolog.id_tipo_log = 2 'ACESSO
                usuariolog.id_menu_item = 127
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

            ViewState.Item("sortExpression") = "id_romaneio asc"

            loadFilters()


        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub

    Private Sub loadFilters()

        Dim hasFilters As Boolean


        If Not (customPage.getFilterValue("lst_complvolume", txt_id_romaneio.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_romaneio") = customPage.getFilterValue("lst_complvolume", txt_id_romaneio.ID)
            txt_id_romaneio.Text = ViewState.Item("id_romaneio").ToString()
        Else
            ViewState.Item("id_romaneio") = String.Empty
        End If


        If Not (customPage.getFilterValue("lst_complvolume", txt_id_propriedade.ID).Equals(String.Empty)) Then
            hasFilters = True
            ViewState.Item("id_propriedade") = customPage.getFilterValue("lst_complvolume", txt_id_propriedade.ID)
            txt_id_propriedade.Text = ViewState.Item("id_propriedade").ToString()
            lbl_nm_propriedade.Text = customPage.getFilterValue("lst_complvolume", lbl_nm_propriedade.ID)
            hf_id_propriedade.Value = ViewState.Item("id_propriedade").ToString()
        Else
            ViewState.Item("id_propriedade") = String.Empty
            txt_id_propriedade.Text = String.Empty
            lbl_nm_propriedade.Text = String.Empty
            hf_id_propriedade.Value = String.Empty

        End If

        If Not (customPage.getFilterValue("lst_complvolume", "PageIndex").Equals(String.Empty)) Then
            ViewState.Item("PageIndex") = customPage.getFilterValue("lst_complvolume", "PageIndex").ToString()
            gridResults.PageIndex = Convert.ToInt32(ViewState.Item("PageIndex").ToString())
        End If


        If (hasFilters) Then
            loadData()
            customPage.clearFilters("lst_complvolume")
        End If

    End Sub

    Private Sub loadData()

        Try
            Dim romaneio As New Romaneio

            If Not (ViewState.Item("id_romaneio").ToString.Equals(String.Empty)) Then
                romaneio.id_romaneio = Convert.ToInt32(ViewState.Item("id_romaneio").ToString())
            End If
            romaneio.id_propriedade = ViewState.Item("id_propriedade").ToString()

            Dim dsromaneio As DataSet = romaneio.getRomaneioComplementarVolume()

            If (dsromaneio.Tables(0).Rows.Count > 0) Then
                gridResults.Visible = True
                gridResults.DataSource = Helper.getDataView(dsromaneio.Tables(0), ViewState.Item("sortExpression"))
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


            Case "id_romaneio"
                If (ViewState.Item("sortExpression")) = "id_romaneio asc" Then
                    ViewState.Item("sortExpression") = "id_romaneio desc"
                Else
                    ViewState.Item("sortExpression") = "id_romaneio asc"
                End If
            Case "ds_transportador"
                If (ViewState.Item("sortExpression")) = "ds_transportador asc" Then
                    ViewState.Item("sortExpression") = "ds_transportador desc"
                Else
                    ViewState.Item("sortExpression") = "ds_transportador asc"
                End If
            Case "dt_hora_entrada"
                If (ViewState.Item("sortExpression")) = "dt_hora_entrada asc" Then
                    ViewState.Item("sortExpression") = "dt_hora_entrada desc"
                Else
                    ViewState.Item("sortExpression") = "dt_hora_entrada asc"
                End If
            Case "ds_placa"
                If (ViewState.Item("sortExpression")) = "ds_placa asc" Then
                    ViewState.Item("sortExpression") = "ds_placa desc"
                Else
                    ViewState.Item("sortExpression") = "ds_placa asc"
                End If

        End Select

        loadData()

    End Sub
 
    Private Sub saveFilters()

        Try

            customPage.setFilter("lst_complvolume", txt_id_romaneio.ID, ViewState.Item("id_romaneio").ToString)
            customPage.setFilter("lst_complvolume", txt_id_propriedade.ID, ViewState.Item("id_propriedade").ToString)
            customPage.setFilter("lst_complvolume", lbl_nm_propriedade.ID, lbl_nm_propriedade.Text.ToString)
            customPage.setFilter("lst_complvolume", "PageIndex", gridResults.PageIndex.ToString())

        Catch ex As Exception
            messageControl.Alert(ex.Message)
        End Try

    End Sub



    Protected Sub gridResults_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridResults.RowCommand

        '        Dim id_romaneio As Int32
        '       Dim strMessage As String

        Select Case e.CommandName.ToString().ToLower()

            Case "selecionar"
                saveFilters()

                Response.Redirect("frm_romaneio_complementar_volume.aspx?id_romaneio=" + e.CommandArgument.ToString + "&id_propriedade=" + ViewState.Item("id_propriedade").ToString)


        End Select

    End Sub

    Protected Sub txt_id_propriedade_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_id_propriedade.TextChanged
        lbl_nm_propriedade.Text = String.Empty
        hf_id_propriedade.Value = 0
        If Not txt_id_propriedade.Text.Equals(String.Empty) Then
            Dim propriedade As New Propriedade
            propriedade.id_propriedade = Convert.ToInt32(txt_id_propriedade.Text)
            Dim dsprop As DataSet = propriedade.getPropriedadeByFilters
            If dsprop.Tables(0).Rows.Count > 0 Then
                lbl_nm_propriedade.Text = dsprop.Tables(0).Rows(0).Item("nm_propriedade").ToString
                hf_id_propriedade.Value = dsprop.Tables(0).Rows(0).Item("id_propriedade").ToString
            End If
        End If

    End Sub

    Protected Sub btn_lupa_propriedade_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btn_lupa_propriedade.Click
        carregarcampospropriedade()

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
End Class
